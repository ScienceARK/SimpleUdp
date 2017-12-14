using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleUdp
{
    public class UdpConnection
    {
        private UdpClient UdpListen = new UdpClient();

        private UdpClient UdpSend = new UdpClient();

        private IPEndPoint ListenEndpoint;

        private IPEndPoint SendEndPoint;

        private Thread ListenThread;

        public static bool UseLogger { get; set; } = false;

        public UdpConnection(string ListenIp, int ListenPort, string SendIp, int SendPort)
        {
            try
            {
                ListenEndpoint = new IPEndPoint(IPAddress.Parse(ListenIp), ListenPort);
                SendEndPoint = new IPEndPoint(IPAddress.Parse(SendIp), SendPort);
            }
            catch (Exception)
            {
                Log.Instance.Write($"Failed to create {this}, parsing error.");
            }
        }

        public void Send(string Message)
        {
            try
            {
                byte[] Bytes = Encoding.ASCII.GetBytes(Message);
                UdpSend.Send(Bytes, Bytes.Length, SendEndPoint);
                Log.Instance.Write($"Send [{Message}] to: ]{SendEndPoint}]");
            }
            catch (Exception Exc)
            {

                Log.Instance.Write($"Failed to send message, exception: {Exc}");
            }

        }

        public void Bind()
        {

            try
            {
                UdpListen.Client.Bind(ListenEndpoint);
                ListenThread = new Thread(StartListening);
                ListenThread.Start();
                Log.Instance.Write($"Udp Listener successfully bound to: {ListenEndpoint}");
            }

            catch (Exception Exc)
            {
                Log.Instance.Write($"Failed to bind {this}, exception: {Exc}");
            }


        }

        public void Unbind()
        {
            try
            {

                ListenThread.Suspend(); //Deprecated
                UdpListen.Close();
                Log.Instance.Write("Udp Listener Unbound, connections will be actively refused.");

            }
            catch (Exception Exc)
            {
                Log.Instance.Write($"Udp Listener failed to unbind, exception: {Exc}");
            }


        }

        private void StartListening()
        {
            while (true)
            {
                byte[] Receiving = UdpListen.Receive(ref ListenEndpoint);

                if (Receiving != null || Receiving.Length > 0)
                {
                    Log.Instance.Write($"Received: {Encoding.ASCII.GetString(Receiving)}");
                }
            }
        }

        public override string ToString()
        {
            return $"UdpConnection, EndPoints: [LISTEN]{ListenEndpoint}, [SEND]{SendEndPoint}";
        }
    }
}
