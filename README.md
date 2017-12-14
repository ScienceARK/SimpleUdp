# SimpleUdp
Net.Sockets Udp Wrapper C#.

# How to
- Create a new instance of the UdpConnection object.
```C#
UdpConnection Udpcon = new UdpConnection("Receiving IpAddress", "Receiving Port", "Sending IpAdress", "Sending Port")
Udpcon.Bind(); //Enables the receiving of Udp packets
Udpcon.Unbind(); //Disables the receiving of Udp packets

Udpcon.Send("Enter string here") //Sends a message to the udp sending IpAddress:Port
```

# Enable output to a ListBox [Thread-safe]
- UdpConnection.UseLogger = true
- SimpleUdp.Log.LogListForm = ListBox
