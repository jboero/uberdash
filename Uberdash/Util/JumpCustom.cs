using System;
using System.Collections.Generic;
using System.Text;

namespace Mawenzy.Util
{
    /// <summary>
    /// A freeform drawable class based on JumpRect.
    /// </summary>
    public class JumpCustom : JumpRect
    {
        private RenderState.Drawer customDraw;

        /// <summary>
        /// Gets or sets the delegate for drawing.
        /// Note that transormations are applied first.
        /// </summary>
        public RenderState.Drawer CustomDraw
        {
            get
            {
                return customDraw;
            }
            set
            {
                customDraw = value;
            }
        }

        public JumpCustom()
        {
            customDraw = RenderState.NullDraw;
        }

        public JumpCustom(RenderState.Drawer drawRoutine)
        {
            customDraw = drawRoutine;
        }

        public override void Draw()
        {
            customDraw();
        }
    }
}
