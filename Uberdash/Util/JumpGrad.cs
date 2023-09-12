using System;
using System.Collections.Generic;
using System.Text;

namespace Mawenzy.Util
{
    /// JLB <summary>
    /// A generic class that handles any number of smooth "jumping" float gradient values.
    /// </summary>
    public class Jumper : IDisposable
    {
        /// JLB <summary>
        /// Stores previous, current, destination, and home positions along any number of axes.
        /// </summary>
        protected float[,] matrix;
        /// JLB <summary>
        /// Inversely affects jump duration.
        /// </summary>
        public float Speed = 2;
        /// JLB <summary>
        /// Stores how many axes (dimensions) are being tracked.
        /// </summary>
        private int depth;
        /// JLB <summary>
        /// How many advances this JumpGrad has before calling FrameEvent.
        /// </summary>
        private int life = -1;

        /// JLB <summary>
        /// Optionally associate any object with a Jumper.
        /// </summary>
        public object Tag = null;

        protected enum Pos : int
        {
            Is = 0,
            Going = 1,
            Was = 2,
            Home = 3
        }

        /// John Boero <summary>
        /// Allows external routines to initialize once we create the rendering context.
        /// </summary>
        public delegate void EventOnFrame(Jumper sender);

        /// John Boero <summary>
        /// </summary>
        public event EventOnFrame FrameEvent;

        /// JLB <summary>
        /// Creates an abstract default Jumper only for extenders.
        /// </summary>
        protected Jumper()
        {
        }

        /// JLB <summary>
        /// Create an abstract Jumper with any number of dimensions.
        /// </summary>
        /// <param name="speed">Inverse speed of jumps.</param>
        /// <param name="axes">Initial values of the number of dimensions desired.</param>
        public Jumper(float speed, params float[] axes)
        {
            Speed = speed;
            depth = axes.Length;
            matrix = new float[axes.Length, 4];

            for (int pos = 0; pos < 4; ++pos)
                for (int arg = 0; arg < axes.Length; ++arg)
                    matrix[arg, pos] = axes[arg];
        }

        /// <summary>
        /// Advances all gradients and fires AfterExpire event if applicable.
        /// </summary>
        /// <returns> True if jumper did not expire. </returns>
        virtual public bool Advance()
        {
            for (int axis = 0; axis < depth; ++axis)
                matrix[axis, (int)Pos.Is] += (matrix[axis, (int)Pos.Going] - matrix[axis, (int)Pos.Is]) / Speed;

            if (--life == 0 && FrameEvent != null)
            {
                FrameEvent(this);
                return false;
            }
            return true;
        }

        public void EventIn(uint frames)
        {
            life = (int)frames;
        }

        public void Force(int index, float value)
        {
            matrix[index, (int)Pos.Was] = 
                matrix[index, (int)Pos.Is] = 
                matrix[index, (int)Pos.Going] = value;
        }

        public void Reverse(int index)
        {
            float swap = matrix[index, (int)Pos.Going];
            matrix[index, (int)Pos.Going] = matrix[index, (int)Pos.Was];
            matrix[index, (int)Pos.Was] = swap;
        }

        public void Reverse()
        {
            for (int i = 0; i < matrix.Length / 4; ++i)
                Reverse(i);
        }

        public void GoHome()
        {
            for (int i = 0; i < matrix.Length / 4; ++i)
                matrix[i, (int)Pos.Going] = matrix[i, (int)Pos.Home];
        }

        public float this[int index]
        {
            get
            {
                return matrix[index, (int)Pos.Is];
            }
            set
            {
                matrix[index, (int)Pos.Was] = matrix[index, (int)Pos.Going];
                matrix[index, (int)Pos.Going] = value;
            }
        }

        /// JLB <summary>
        /// Gets whether or not the jumper's days are numbered.
        /// </summary>
        public bool EventPending
        {
            get { return life > -1; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Speed.ToString());

            for (int index = 0; index < matrix.Length / 4; ++index)
            {
                sb.Append(',');
                sb.Append(matrix[index, (int)Pos.Is].ToString());
            }

            return sb.ToString();
        }

        public static Jumper FromString(string src)
        {
            string [] strs = src.Split(',');
            float[] res = new float[strs.Length - 1];

            float speed = float.Parse(strs[0]);

            for (int i = 0; i < res.Length; ++i)
                res[i] = float.Parse(strs[i + 1]);

            return new Jumper(speed, res);
        }

        #region IDisposable Members

        public virtual void Dispose()
        {
        }

        #endregion
    }
}
