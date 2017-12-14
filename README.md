# SimpleUdp
Net.Sockets Udp Wrapper C#.

## How to
Create a new instance of the UdpConnection object.
```C#
UdpConnection Udpcon = new UdpConnection("Receiving IpAddress", ReceivingPort, "Sending IpAdress", SendingPort);
```
Bind the Udp connection to start receiving packets.
```C#
Udpcon.Bind(); //Enables the receiving of Udp packets
Udpcon.Unbind(); //Disables the receiving of Udp packets
```
Sending messages over Udp
```C#
Udpcon.Send("Enter string here"); //Sends a message to the udp sending IpAddress:Port
```

### Enable output to a ListBox [Thread-safe]
```C#
UdpConnection.UseLogger = true;
SimpleUdp.Log.LogListForm = ListBox;
```
