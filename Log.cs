using System;
using System.Windows.Forms;

namespace SimpleUdp
{
    public sealed class Log
    {
        private static Log instance = null;

        private static readonly object padlock = new object();

        public static ListBox ListBoxForm { get; set; }

        public static Log Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Log();
                    }
                    return instance;
                }
            }
        }

        public void Write(string Message)
        {
            if (UdpConnection.UseLogger && ListBoxForm != null)
            {
                try
                {
                    if (ListBoxForm.InvokeRequired)
                    {
                        ListBoxForm.BeginInvoke(new MethodInvoker(delegate
                        {
                            ListBoxForm.Items.Add(Message);
                        }));
                    }
                    else
                    {
                        ListBoxForm.Items.Add(Message);
                    }
                }
                catch (Exception Exc)
                {

                    MessageBox.Show($"Failed to add log entry, exception: {Exc}");
                }
            }
        }
    }
}
