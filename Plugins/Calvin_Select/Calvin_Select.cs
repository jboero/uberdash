using System;
using System.Collections.Generic;
using System.Text;
using Mawenzy.Util;
using System.Windows.Forms;
using Tao.OpenGl;
using Mawenzy.Plugins.Properties;
using ShellDll;
using System.Drawing;
using Mawenzy.UI;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using Microsoft.Win32;
using Mawenzy.Properties;
using Mawenzy.Plugins;

namespace Mawenzy.Toys
{
    /// <summary>
    /// A toy plugin to demonstrate custom drag selection rectangles.
    /// Calvin & Hobbes copyright Bill Watterson
    /// </summary>
    public class Calvin_Select : PluginBase
    {
        private JumpRect faces;
        private Rectangle subRect;
        private Random faceRand;
        private bool change = false;

        /// <summary>
        /// Check assembly signature.  Warn if this is not an official build.
        /// </summary>
        public Calvin_Select()
        {
        }

        /// <summary>
        /// Draw only when drag selecting.
        /// </summary>
        public override void Draw()
        {
            // Now is our time to shine - are we drag-selecting?
            if (Parent.DragSelectStatus != null)
            {
                if (change)
                {
                    subRect.X = (faceRand.Next() % 4) * subRect.Width;
                    subRect.Y = (faceRand.Next() % 3) * subRect.Height;
                    change = false;
                }
                Parent.SelectBoxDisplayList = Gl.glGenLists(1);

                Gl.glNewList(Parent.SelectBoxDisplayList, Gl.GL_COMPILE);
                RenderState.SetOrtho(Parent.Bounds);
                Gl.glEnable(Gl.GL_TEXTURE_RECTANGLE_ARB);
                Gl.glEnable(Gl.GL_BLEND);
                Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

                Rectangle reg;
                // Keep our textures upright.
                if (Cursor.Position.Y <= Parent.DragSelectStatus.Y)
                    reg = new Rectangle(
                        Parent.DragSelectStatus.X, 
                        Parent.DragSelectStatus.Y,
                        Cursor.Position.X - Parent.DragSelectStatus.X,
                        Cursor.Position.Y - Parent.DragSelectStatus.Y);
                else
                    reg = new Rectangle(
                        Parent.DragSelectStatus.X,
                        Cursor.Position.Y,
                        Cursor.Position.X - Parent.DragSelectStatus.X,
                        Parent.DragSelectStatus.Y - Cursor.Position.Y);

                faces.DrawManualUV(reg, subRect);
                Gl.glEndList();
            }
            else
                change = true;
        }

        /// JLB <summary>
        /// Use MawenzyConfig for configuration in options window.
        /// </summary>
        public override System.Windows.Forms.Control ConfigControl
        {
            get
            {
                return new CalvinConfig();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override System.Drawing.Image OptionsIcon
        {
            get
            {
                return Resources.calvin_32;
            }
        }

        /// <summary>
        /// Set up logo and start load of new plugins if selected.
        /// </summary>
        public override void Activate()
        {
            faceRand = new Random();
            faces = new JumpRect(Resources.calvin_faces, 50, 0,0,0, 0,0,0, 1,1,1, 0.5f);
            subRect = new Rectangle(0, 0, faces.Bounds.Width / 4, faces.Bounds.Height / 3);
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
            
            // Reset selectboxdisplaylist to default.
            Parent.SelectBoxDisplayList = 0;

            faces.Dispose();
            faces = null;
            faceRand = null;
        }
    }
}
