using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanner
{
    class UDPPortScanner: PortScannerBase
    {
        // The UDP client used for scanning a port
        private UdpClient udpClient;

        // Constructor - use base constructor
        public UDPPortScanner(): base()
        {
        }

        // TODO:
        public async override Task<bool> CheckOpenAsync(CancellationToken ct)
        {
            return false;
        }

        // Implementing the base's abstract method CheckOpen()
        public override bool CheckOpen()
        {
            // We are using a UDP client to see whether the port is open or not
            // Therefore, the absence of a response means that the port is open
            // If there is any respone, it is closed
            using (udpClient = new UdpClient())
            {
                try
                {
                    // Connect to the server
                    udpClient.Connect(Hostname, Port);

                    // Set the timeout
                    udpClient.Client.ReceiveTimeout = Timeout;

                    // Sends a message over UDP
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("Are you open?");
                    udpClient.Send(sendBytes, sendBytes.Length);

                    // IPEndPoint object will allow us to read datagrams sent from any source.
                    // Port 0 means any available port
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                    // Blocks until a message returns on this socket from a remote host.
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    string returnData = Encoding.ASCII.GetString(receiveBytes);

                    // Uses the IPEndPoint object to determine which of these two hosts responded.
                    udpClient.Close();
                    
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.ErrorCode);
                }

                return false;
            }
        }
    }
}
