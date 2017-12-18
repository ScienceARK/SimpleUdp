using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUdp
{
    public class ReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
        public UdpConnection Udpcon { get; set; }

        public ReceivedEventArgs(string Message, UdpConnection Udpcon)
        {
            this.Message = Message;
            this.Udpcon = Udpcon;
        }

    }
}
