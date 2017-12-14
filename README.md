# SimpleUdp
Net.Sockets Udp Wrapper C#.

# How to
- Create a new instance of the UdpConnection object (ListenIp, ListenPort, SendIp, SendPort)
- .Bind (Opens the receiving connection)
- .Unbind (Closes the receiving connection)

#Enable output to a ListBox [Thread-safe]
- UdpConnection.UseLogger = true
- SimpleUdp.Log.LogListForm = ListBox
