using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;

namespace Mawenzy.Util
{
    /// JLB <summary>
    /// An extended JumpRect that throws an event when it leaves the scene.
    /// Detection involves some overhead, so use sparingly.
    /// </summary>
    /// <remarks>JumpElvis has left the building.</remarks>
    public class JumpElvis: JumpRect
    {
        private static int[] hits = new int[32];
        /// JLB <summary>
        /// Track state of this jumper.
        /// </summary>
        private enum State
        {
            /// <summary>
            /// Hasn't been shown in the scene yet.
            /// </summary>
            PreScreen,
            /// <summary>
            /// Has been rendered on scene.
            /// </summary>
            OnScreen,
            /// <summary>
            /// Has exited and does not need event.
            /// </summary>
            OffScreen
        }
        
        /// JLB <summary>
        /// Stores whether we have been in the scene yet.
        /// </summary>
        private State sceneState = State.PreScreen;

        /// JLB <summary>
        /// Allows an event for a JumpGrad that is leaving the scene.
        /// </summary>
        public delegate void LeftScene(JumpElvis sender);

        /// JLB <summary>
        /// Triggered when a JumpElvis has gone from drawing in the scene to drawing off-camera.
        /// </summary>
        public event LeftScene OnExitScene;

        public JumpElvis()
            : base() { }

        public JumpElvis(string imageFile, float speed, params float[] dimensions)
            : base(imageFile, speed, dimensions) { }

        public JumpElvis(Control texControl, float speed, params float[] dimensions)
            : base(texControl, speed, dimensions) { }

        /// JLB <summary>
        /// Draw with exit detection.
        /// </summary>
        public void DrawCheckExit()
        {
            if (OnExitScene != null)
            {
                Gl.glSelectBuffer(hits.Length, hits);
                Gl.glRenderMode(Gl.GL_SELECT);
                Gl.glInitNames();

                // Draw it in select mode using existing modelview.
                base.Draw();

                if (Gl.glRenderMode(Gl.GL_RENDER) == 0)
                {
                    if (sceneState == State.OnScreen)
                    {
                        OnExitScene(this);
                        sceneState = State.OffScreen;
                    }
                    return;
                }
                else if (sceneState == State.PreScreen)
                    sceneState = State.OnScreen;
            }

            base.Draw();
        }
    }
}
