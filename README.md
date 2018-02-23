# SimpleUdp
Net.Sockets Udp Wrapper C#.

#### Dependencies
- .Net Framework 4.5.2+
- System.Net
- System.Windows.Forms
- System.Threading

## How to
Create a new instance of the UdpConnection object.
```C#
UdpConnection Udpcon = new UdpConnection("Receiving IpAddress", ReceivingPort, "Sending IpAdress", SendingPort);
```
Bind the Udp connection to start receiving packets.
```C#
Udpcon.Bind(); //Bind socket
Udpcon.Unbind(); //Unbinds the socket
```
Sending messages over Udp
```C#
Udpcon.Send("Enter string here");
```

Subscribe EventHandler
```C#
Udpcon.NewMessage += NewMessageEventMethod;

Args returns a message when a message is received.
```

