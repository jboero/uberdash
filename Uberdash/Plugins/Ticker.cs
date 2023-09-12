using System;
using System.Collections.Generic;
using System.Text;
using Mawenzy.Util;
using System.Drawing;
using System.Threading;
using Mawenzy.UI;
using Tao.OpenGl;
using System.Windows.Forms;
using Mawenzy.Properties;

namespace Mawenzy.Plugins
{
    /// <summary>
    /// A wrapper to rotate shown plugins without affecting PluginBase.Active Property.
    /// </summary>
    public abstract class Ticker : PluginBase, ICollection<TickerTock>
    {
        private List<TickerTock> ActivePlugs = new List<TickerTock>();
        private List<JumpRect> jumpers = new List<JumpRect>();
        private JumpRect selectedJumper = null;
        private bool boundsCheck = false;
        private System.Windows.Forms.Timer boundsTimer;
        private Rectangle selRect = new Rectangle(-1, 1, 3, 3);
        private Point offscreen = new Point(-2000, 1);
        private int[] hits = new int[512];
        private int dlDraw;

        /// <summary>
        /// Camera scroll (x);
        /// </summary>
        private Jumper cam;

        private int insPoint = 0;

        /// <summary>
        /// The minimum preferred size of a marquee item.
        /// </summary>
        public Size PreferredSize;

        /// <summary>
        /// The maximum preferred size of a marquee item.
        /// </summary>
        public Size MaxSize;

        /// <summary>
        /// The currently active index of activeplugins (uses % to container size).
        /// </summary>
        protected int currentPlug = 0;

        /// <summary>
        /// Advances to the next plugin in our queue and restarts the timer.
        /// </summary>
        public void Advance()
        {
            // Find first plugin in list that is not already loading.
            // Usually this will be the first one we try, but still.
            // Note this also works when there are 0 plugins.
            TickerTock next = null;
            for (int i = 0; i < ActivePlugs.Count; ++i)
            {
                next = ActivePlugs[currentPlug++ % ActivePlugs.Count];
                if (!next.IsLoading)
                    break;
            }
            if (next == null || next.IsLoading)
                return;

            next.IsLoading = true;
            ParameterizedThreadStart start = new ParameterizedThreadStart(LoadNext);
            Thread loader = new Thread(start);
            loader.Priority = ThreadPriority.Lowest;
            loader.IsBackground = true;
            loader.Start(next);
        }

        /// <summary>
        /// Helper for threaded load.  Forked by timer from Advance()
        /// </summary>
        /// <param name="mPlug">Next marquee plugin.</param>
        private void LoadNext(object mPlug)
        {
            TickerTock mp = mPlug as TickerTock;
            List<Image> tex = null;

            Thread.Sleep(100);

            try
            {
                tex = mp.Fetch();

                if (tex != null)
                    Parent.Invoke(new JoinRenderThreadParam(TexBuild), tex);
            }
            catch (Exception ex)
            {
                ErrForm.Show(ex);
                return;
            }
            
            mp.IsLoading = false;
        }

        /// <summary>
        /// Rejoin the render thread and add textures to Jumpers.
        /// </summary>
        /// <param name="texList">List<Image> with created texture images.</Image></param>
        private void TexBuild(object texList)
        {
            List<Image> newTex = texList as List<Image>;
            int w;
            foreach (Image img in newTex)
            {
                w = img.Width;
                JumpRect jr = new JumpRect(img, 50,
                    w / 2 + insPoint, 0, 0,
                    0, 0, 0,
                    1, 1, 1, 1);

                // Remember tag may contain a ClickBundle...
                jr.ClickHandler = img.Tag as JumpRect.ClickBundle;
                jr.Anchor = GlobalSettings.Default.TickerAnchor;

                jumpers.Add(jr);
                insPoint += w;
            }

            Gl.glNewList(dlDraw, Gl.GL_COMPILE);
            foreach (JumpRect jumper in jumpers)
                jumper.Draw();
            Gl.glEndList();
        }

        public override void Activate()
        {
            dlDraw = Gl.glGenLists(1);
            cam = new Jumper(30, 0, 0);
            base.Activate();

            boundsTimer = new System.Windows.Forms.Timer();
            boundsTimer.Interval = 5000;
            boundsTimer.Tick += new EventHandler(boundsTimer_Tick);
            boundsTimer.Start();
        }

        public override void Deactivate()
        {
            boundsTimer.Stop();
            base.Deactivate();
            cam.Dispose();
            Gl.glDeleteLists(dlDraw, 1);
        }

        private void boundsTimer_Tick(object sender, EventArgs e)
        {
            boundsCheck = true;
        }

        /// <summary>
        /// Draw all jumpers in this ticker and select one if the mouse is over it.
        /// </summary>
        public override void Draw()
        {
            if (ActivePlugs.Count == 0)
                return;

            float scroll = cam[0] + cam[1];
            float x = 0, y = 0;
            AnchorStyles anchor = GlobalSettings.Default.TickerAnchor;

            // Figure out rendering position.
            #region Rendering position
            if ((anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) != AnchorStyles.None)
            {
                x = scroll;
                if ((anchor & AnchorStyles.Bottom) != AnchorStyles.None)
                    y = Screen.PrimaryScreen.WorkingArea.Bottom;
            }
            else
            {
                y = scroll;
                if ((anchor & AnchorStyles.Right) != AnchorStyles.None)
                    x = Screen.PrimaryScreen.WorkingArea.Right;
            }
            #endregion

            // First delete expired tocks (waaaay off-screen)
            #region Expire off-screeners.
            if (boundsCheck)
            {
                boundsCheck = false;
                int[] viewport = new int[4];
                Point p = new Point(Parent.Width / 2, Parent.Height / 2);

                Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);
                Gl.glSelectBuffer(hits.Length, hits);
                Gl.glRenderMode(Gl.GL_SELECT);
                Gl.glInitNames();

                p.Y += viewport[3] - Parent.Height;
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Glu.gluPickMatrix(
                    p.X - Parent.Width, viewport[3] - Parent.Height, 
                    Parent.Width * 2, Parent.Height * 2, viewport);
                Gl.glOrtho(p.X - Parent.Width, p.X + Parent.Width, p.Y - Parent.Height, p.Y + Parent.Height, -100, 100);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();
                Gl.glPushName(1);
                Gl.glTranslatef(x, y, 0);
                for (int i = 0; i < jumpers.Count; ++i)
                {
                    Gl.glLoadName(i);
                    jumpers[i].DrawSelectMode();
                }
                if (Gl.glRenderMode(Gl.GL_RENDER) > 0)
                {
                    for (int i = 0; i < hits[3]; ++i)
                    {
                        jumpers[0].Dispose();
                        jumpers.RemoveAt(0);
                    }
                }
            }
            #endregion

            // Sadly in my experience glPushName does not take in display lists,
            // though the ARB declares it part of the standard.
            #region Selected Jumper
            selectedJumper = null;
            if (Parent.Focused)
            {
                // Draw cursor selection.
                RenderState.PrepSelectOrtho(ref hits, Cursor.Position, Parent.Bounds);
                Gl.glPushName(1);
                Gl.glTranslatef(x, y, 0);
                for (int i = 0; i < jumpers.Count; ++i)
                {
                    Gl.glLoadName(i);
                    jumpers[i].DrawSelectMode();
                }
                if (Gl.glRenderMode(Gl.GL_RENDER) > 0)
                {
                    selectedJumper = jumpers[hits[3]];
                    Cursor.Current = Cursors.Hand;
                }
            }
            #endregion

            // Now draw screen.
            #region Render
            RenderState.SetOrtho(Parent.Bounds);
            Gl.glColor3f(1, 1, 1);
            Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glTranslatef(x, y, 0);
            Gl.glCallList(dlDraw);
            Gl.glDisable(Gl.GL_TEXTURE_RECTANGLE_ARB);
            if (selectedJumper != null)
            {
                Gl.glColor4f(1, 1, 1, 0.5f);
                selectedJumper.DrawColorless();
            }
            Gl.glDisable(Gl.GL_BLEND);

            cam[0] -= 20;
            cam.Advance();
            #endregion

            // Then start fetching more if necessary.
            if (jumpers.Count < 20)
                Advance();
        }

        /// <summary>
        /// Shift the ticker with mouse scroll.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        /// <returns>True iff we handled this</returns>
        public override bool HandleMouseWheel(System.Windows.Forms.MouseEventArgs e)
        {
            if (selectedJumper != null)
            {
                cam[1] += e.Delta * 4;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Show the ticker context menu.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool HandleMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            // Call ClickBundle if any (show context menu).
            if (selectedJumper != null && selectedJumper.ClickHandler != null)
                return selectedJumper.ClickHandler.Show(e);

            return base.HandleMouseClick(e);
        }

        public bool Contains(TickerTock marqueePlugin)
        {
            return ActivePlugs.Contains(marqueePlugin);
        }

        #region ICollection<> Members

        public void Add(TickerTock item)
        {
            ActivePlugs.Add(item);
        }

        public void Clear()
        {
            ActivePlugs.Clear();
        }

        public void CopyTo(TickerTock[] array, int arrayIndex)
        {
            ActivePlugs.CopyTo(array);
        }

        public int Count
        {
            get { return ActivePlugs.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(TickerTock item)
        {
            return ActivePlugs.Remove(item);
        }

        #endregion

        public IEnumerator<TickerTock> GetEnumerator()
        {
            return ActivePlugs.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ActivePlugs.GetEnumerator();
        }
    }
}
