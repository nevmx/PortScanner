using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PortScanner
{
    class PortScanner
    {
        // Hostname and port for connections
        public string Hostname { get; set; }
        public int Port { get; set; }

	// Timeout property for TCP client timeout in milleseconds
        public int Timeout { get; set; }

	// Instance property - this is a singleton class
        private static PortScanner instance;

	// The TCP client used to 
        private TcpClient tcpClient;

        // Private constructor - singleton class
        private PortScanner()
        {
            Hostname = "127.0.0.1";
            Port = 22;
            Timeout = 1000;
        }

        public static PortScanner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PortScanner();
                }

                return instance;
            }
        }

        // Instantiate the TcpClient
        public void Initialize()
        {
        }

        // Try to connect to see whether port is open or not
        public bool CheckOpen()
        {
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
}
