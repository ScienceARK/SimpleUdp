# SimpleUdp
Net.Sockets Udp Wrapper C#.

# How to
- Create a new instance of the UdpConnection object.
Example: UdpConnection Udpcon = new UdpConnection("Receiving IpAddress", "Receiving Port", "Sending IpAdress", "Sending Port")
- .Bind (Opens the receiving connection)
- .Unbind (Closes the receiving connection)

# Enable output to a ListBox [Thread-safe]
- UdpConnection.UseLogger = true
- SimpleUdp.Log.LogListForm = ListBox
