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

        private static PortScanner instance;

        private TcpClient tcpClient;

        // Private constructor - singleton class
        private PortScanner()
        {
            Hostname = "127.0.0.1";
            Port = 22;
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
            bool result = false;

            using (tcpClient = new TcpClient())
	    {

            	try
            	{
                	tcpClient.Connect(Hostname, Port);
                	result = true;
            	}
            	catch (Exception)
            	{
                	result = false;
            	}
	    }

            return result;
        }
    }
}
