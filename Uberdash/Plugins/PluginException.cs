using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Mawenzy.Properties;

namespace Mawenzy.Plugins
{
    /// JLB <summary>
    /// An exception that was thrown by a specific plugin instance.
    /// </summary>
    public class PluginException : ApplicationException
    {
        private PluginBase offender = null;

        /// JLB <summary>
        /// Create an exception from a plugin that caused it.
        /// </summary>
        /// <param name="offender"></param>
        /// <param name="message"></param>
        /// <param name="baseException"></param>
        public PluginException(PluginBase offendingPlugin, string message, Exception baseException)
            : base(message, baseException)
        {
            offender = offendingPlugin;
        }

        /// JLB <summary>
        /// Gets the icon for this plugin.
        /// </summary>
        public Image Icon
        {
            get
            {
                if (offender != null)
                    return offender.OptionsIcon;
                else
                    return Resources.Crystal_Clear_not_found;
            }
        }
        
        /// JLB <summary>
        /// Confess exception with our plugin.
        /// </summary>
        public override string Message
        {
            get
            {
                return String.Format(
                    Resources.ERR_PluginException,
                    offender.GetType().ToString().Replace('_', ' '),
                    base.Message);
            }
        }
    }
}
