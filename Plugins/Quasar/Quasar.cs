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
    public class Quasar : PluginBase
    {
        /// <summary>
        /// List of quasars to draw.
        /// </summary>
        List<Instance> instances = new List<Instance>();
        /// <summary>
        /// Random quasar generation.
        /// </summary>
        Random rand = new Random();

        /// JLB <summary>
        /// Check assembly signature.  Warn if this is not an official build.
        /// </summary>
        public Quasar()
        {
        }

        /// JLB <summary>
        /// Just call drawer, which may be NullDraw.
        /// </summary>
        public override void Draw()
        {
            RenderState.SetPerspective(60f, Parent.Aspect, Parent.Bounds);
            Gl.glPushMatrix();
            Glu.gluLookAt(0, 0, -750, 0, 0, 0, 0, 1, 0);

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);

            // Make sure we have the right count according to settings.
            while (instances.Count < PluginSettings.Default.QuasarCount)
                instances.Add(new Instance(rand.Next(-1000,1000)));
            while (instances.Count > PluginSettings.Default.QuasarCount)
                instances.RemoveAt(instances.Count - 1);

            if (instances.Count == 1)
                instances[0].Draw(PluginSettings.Default.QuasarDetail, PluginSettings.Default.QuasarPointSmooth, false);
            else
                foreach (Instance quasar in instances)
                    quasar.Draw(PluginSettings.Default.QuasarDetail, PluginSettings.Default.QuasarPointSmooth, true);

            Gl.glDisable(Gl.GL_POINT_SMOOTH);
            Gl.glDisable(Gl.GL_BLEND);
            Gl.glPopMatrix();
        }

        /// JLB <summary>
        /// Use MawenzyConfig for configuration in options window.
        /// </summary>
        public override System.Windows.Forms.Control ConfigControl
        {
            get
            {
                return new QuasarConfig();
            }
        }

        /// JLB <summary>
        /// Use Uberdash icon.
        /// </summary>
        public override System.Drawing.Image OptionsIcon
        {
            get
            {
                return Resources.quasar;
            }
        }

        /// JLB <summary>
        /// Set up logo and start load of new plugins if selected.
        /// </summary>
        public override void Activate()
        {
            Instance.Quad = Glu.gluNewQuadric();
            Glu.gluQuadricDrawStyle(Instance.Quad, Glu.GLU_POINT);

            for (int i = 0; i < PluginSettings.Default.QuasarCount; ++i)
                instances.Add(new Instance(rand.Next(-1000,1000)));

            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();

            Glu.gluDeleteQuadric(Instance.Quad);
        }

        public override void WriteSettings()
        {
            // Get ErrorMode
            GlobalSettings.Default.Save();
        }

        public override void ReadSettings()
        {
            GlobalSettings.Default.Reload();
        }
    }
}
