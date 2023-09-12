/** /
 * This file comes from an article by user kian01.
 * Special thanks for providing it and saving me some time.
 * http://www.codeproject.com/KB/threads/SingletonApp.aspx
/**/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using System.Reflection;
using System.Windows.Forms;

namespace Mawenzy.Util
{
    [Serializable]
    internal class SingletonController : MarshalByRefObject
    {
        private static IpcChannel m_TCPChannel = null;
        private static Mutex m_Mutex = null;

        public delegate void ReceiveDelegate(string[] args);

        static private ReceiveDelegate m_Receive = null;
        static public ReceiveDelegate Receiver
        {
            
            get
            {
                return m_Receive;
            }
            set
            {
                m_Receive = value;
            }
        }

        public static bool IamFirst(ReceiveDelegate r)
        {
            if (IamFirst())
            {
                Receiver += r;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IamFirst()
        {
            m_Mutex = new Mutex(false, AssemblyContext);

            if (m_Mutex.WaitOne(1, true))
            {
                //We locked it! We are the first instance!!!    
                CreateInstanceChannel();
                return true;
            }
            else
            {
                //Not the first instance!!!
                m_Mutex.Close();
                m_Mutex = null;
                return false;
            }
        }

        private static void CreateInstanceChannel()
        {
            m_TCPChannel = new IpcChannel(AssemblyContext);
            ChannelServices.RegisterChannel(m_TCPChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(SingletonController),
                "SingletonController",
                WellKnownObjectMode.SingleCall);
        }

        public static void Cleanup()
        {
            if (m_Mutex != null)
            {
                m_Mutex.Close();
            }

            if (m_TCPChannel != null)
            {
                m_TCPChannel.StopListening(null);
            }

            m_Mutex = null;
            m_TCPChannel = null;
        }

        public static string AssemblyContext
        {
            get
            {
                return Assembly.GetExecutingAssembly().ToString().Replace("\\", "_");
            }
        }

        public static void Send(string[] s)
        {
            SingletonController ctrl = null;
            IpcChannel channel = new IpcChannel();
            ChannelServices.RegisterChannel(channel, false);
            try
            {
                ctrl = (SingletonController)Activator.GetObject(typeof(SingletonController), 
                    string.Format("ipc://{0}/SingletonController", AssemblyContext));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                MessageBox.Show(e.ToString(), "Unable to communicate with running instance...");
            }

            if (ctrl != null)
                ctrl.Receive(s);
        }

        public void Receive(string[] s)
        {
            if (m_Receive != null)
                m_Receive(s);
        }
    }
}
