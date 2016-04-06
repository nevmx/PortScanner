using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortScanner
{
    static class InputChecker
    {
        // Check that a hostname string is valid
        public static bool IsValidHostname(string hostname)
        {
            return false;
        }

        // Check that a port is valid - returns -1 if port is invalid
        public static int ParsePort(string portString)
        {
            int port;

            try
            {
                port = Int32.Parse(portString);
            }
            catch (Exception e)
            {
                return -1;
            }

            if (port < 1 || port > 65535)
            {
                return -1;
            }

            return port;
        }
    }
}
