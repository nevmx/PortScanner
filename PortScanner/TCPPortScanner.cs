using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanner
{
    class TCPPortScanner : PortScannerBase
    {
        // The TCP client for port scanning 
        private TcpClient tcpClient;

        // Constructor - uses base class constructor
        public TCPPortScanner() : base()
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
                tcpClient.SendTimeout = Timeout;
                tcpClient.ReceiveTimeout = Timeout;
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

        // Implementing the base's abstract method CheckOpenAsync(), cancellation token ct passed from MainWindow, triggered in the cancel button click event
        public override async Task<bool> CheckOpenAsync(CancellationToken ct)
        {
            using (tcpClient = new TcpClient())
            {
                // connection is the Task returned by ConnectAsync
                var connection = tcpClient.ConnectAsync(Hostname, Port);

                bool returnValue;
                
                // In case the ct is triggered, this will act as if delay expired right when the click occurrs
                if (await Task.WhenAny(connection, Task.Delay(Timeout, ct)) == connection)
                {
                    // If connection was refused, return false
                    // The exception within the task is a SocketException if the connection failed
                    if (connection.Exception != null)
                    {
                        returnValue = false;
                    }
                    else
                    {
                        returnValue = true;
                    }
                }
                else
                {
                    // Timeout occurred, this means that there is no connection and port is closed
                    returnValue = false;
                }

                tcpClient.Close();
                return returnValue;
            }
        }
    }
}