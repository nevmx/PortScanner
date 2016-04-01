using System.Net.Sockets;

// This is the base class for all Port Scanners

abstract class PortScannerBase
{
    // Hostname and port properties for scanning
    public string Hostname { get; set; }
    public int Port { get; set; }

    // Timeout property that specifies how long to wait for an answer
    public int Timeout { get; set; }

    // Base construcor - just set up default values for properties
    public PortScannerBase()
    {
        Hostname = "127.0.0.1";
        Port = 22;
        Timeout = 1000;
    }

    // Check that the hostname is listening on the port
    public abstract bool CheckOpen();
}

// Temp: TCP Port Scanner
class TCPPortScanner: PortScannerBase
{
    // The TCP client for port scanning 
    private TcpClient tcpClient;

    // Constructor - uses base class constructor
    public TCPPortScanner(): base()
    {
    }

    // Implementing the base's abstract method CheckOpen()
    public override bool CheckOpen()
    {
        // Use a TCP client to scan a port
        // If there is no connection established after the Timeout
        // period passes, the port is not being listened/is closed
        using (tcpClient = new TcpClient())
        {
            if (!tcpClient.ConnectAsync(Hostname, Port).Wait(Timeout))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}

