using System;
using System.Text;
using System.Collections.Generic;
using Mawenzy.Util;
using System.Drawing;
using System.Windows.Forms;

namespace Mawenzy.Plugins
{
    public abstract class TickerTock : PluginBase
    {
        /// <summary>
        /// A queue of plugins in our rotation.
        /// </summary>
        protected Ticker ticker = null;

        /// <summary>
        /// Gets or sets the queue this plugin is in - if any.
        /// </summary>
        public Ticker ParentTicker
        {
            get { return ticker; }
            set { ticker = value; }
        }

        /// <summary>
        /// Special activation including joining the line of plugins in our marquee.
        /// </summary>
        public override void Activate()
        {
            if (ticker == null)
                return;

            if (!ticker.Contains(this))
                ticker.Add(this);

            if (!ticker.Active)
            {
                while (ticker.Layer == -1 || Options.ActivePlugins.Keys.Contains(ticker.Layer))
                    ++ticker.Layer;

                ticker.Activate();
            }

            base.Activate();
        }

        /// <summary>
        /// Deactivates, hides, and dequeues from the marquee.
        /// </summary>
        public override void Deactivate()
        {
            if (ticker != null && ticker.Contains(this))
            {
                ticker.Remove(this);
                if (ticker.Count == 0)
                    ticker.Deactivate();
            }
            base.Deactivate();
        }

        /// <summary>
        /// Fetch the next few texture images in this plugin's series.
        /// </summary>
        /// <returns>A list of images to add to the marquee textures.</returns>
        abstract public List<Image> Fetch();

        internal bool IsLoading;

        /// <summary>
        /// Gets the ContextMenuStrip used by this TickerTock (if any).
        /// </summary>
        public virtual ContextMenuStrip Menu
        {
            get { return null; }
        }
    }
}
