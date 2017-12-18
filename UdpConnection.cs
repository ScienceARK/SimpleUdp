using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SimpleUdp
{
    public class UdpConnection
    {
        private UdpClient UdpListen = new UdpClient();

        private UdpClient UdpSend = new UdpClient();

        private IPEndPoint ListenEndpoint;

        private IPEndPoint SendEndPoint;

        private Thread ListenThread;


        public delegate void ReceivedMessage(object sender, ReceivedEventArgs args);

        public event ReceivedMessage NewMessage;   

        protected virtual void OnReceivedMessage(string Message)
        {
            NewMessage(this, new ReceivedEventArgs(Message, this));           
        }

        public UdpConnection(string ListenIp, int ListenPort, string SendIp, int SendPort)
        {
            try
            {
                ListenEndpoint = new IPEndPoint(IPAddress.Parse(ListenIp), ListenPort);
                SendEndPoint = new IPEndPoint(IPAddress.Parse(SendIp), SendPort);
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }
           
        }

        public void Send(string Message)
        {
            try
            {
                byte[] Bytes = Encoding.ASCII.GetBytes(Message);
                UdpSend.Send(Bytes, Bytes.Length, SendEndPoint);
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }

        }

        public void Bind()
        {

            try
            {
                UdpListen.Client.Bind(ListenEndpoint);
                ListenThread = new Thread(StartListening);
                ListenThread.Start();
            }

            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }


        }

        public void Unbind()
        {
            try
            {

                ListenThread.Suspend(); //Deprecated
                UdpListen.Close();

            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.ToString());
            }


        }

        private void StartListening()
        {
            while (true)
            {
                byte[] Receiving = UdpListen.Receive(ref ListenEndpoint);

                if (Receiving != null || Receiving.Length > 0)
                {
                    OnReceivedMessage(Encoding.ASCII.GetString(Receiving));
                }
            }
        }

        public override string ToString()
        {
            return $"UdpConnection, EndPoints: [LISTEN]{ListenEndpoint}, [SEND]{SendEndPoint}";
        }

    }

}
