using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;

namespace Mawenzy.Util
{
    /// JLB <summary>
    /// A basic collection of JumpRects implementing basic inverse kinematics.
    /// The groups matrix state is applied before elements of the group are drawn.
    /// </summary>
    public class JumpRectTree : JumpRect 
    {
        /// JLB <summary>
        /// List of "sub JumpRects" that are first offset by the group's transformations.
        /// Note this list may also include another JumpRectGroup.
        /// </summary>
        private List<JumpRect> groupies;

        /// JLB <summary>
        /// Gets our subjumpers/branches of our IK tree.
        /// </summary>
        public List<JumpRect> Nodes
        {
            get
            {
                return groupies;
            }
        }

        /// <summary>
        /// Use the imageless constructor.
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="dimensions"></param>
        public JumpRectTree(float speed, params float[] dimensions) 
            : base(speed, dimensions)
        {
            groupies = new List<JumpRect>();
        }

        /// JLB <summary>
        /// Draw all JumpRects in the group.
        /// </summary>
        public override void Draw()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(base[X], base[Y], base[Z]);
            Gl.glRotatef(base[S], 1, 0, 0);
            Gl.glRotatef(base[T], 0, 1, 0);
            Gl.glRotatef(base[U], 0, 0, 1);
            Gl.glScalef(base[ScaleX], base[ScaleY], base[ScaleZ]);

            // Draw all groupies.  Note jr may be another group.
            foreach (JumpRect jr in groupies)
                jr.Draw();

            Gl.glPopMatrix();
        }
    }
}
