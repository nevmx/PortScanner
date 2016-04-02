using System;

namespace PortScanner
{
    class ScannerManagerSingleton
    {
        // The instance variable - this is a singleton class
        private static ScannerManagerSingleton _instance;

        // The PortScanner used to scan ports
        private PortScannerBase portScanner;

        // Enumeration for scanning modes
        public enum ScanMode
        {
            TCP = 1,
            UDP = 2
        }

        // Private constructor - this is a singleton class
        private ScannerManagerSingleton()
        {
        }

        // Instance property - this is a singleton class
        public static ScannerManagerSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ScannerManagerSingleton();
                
                return _instance;
            }
        }

        // Scan one port
        public bool ExecuteOnce(string hostname, int port, ScanMode scanMode, MainWindow.ExecuteOnceCallback callback)
        {
            switch(scanMode)
            {
                case ScanMode.TCP:
                    portScanner = new TCPPortScanner();
                    portScanner.Hostname = hostname;
                    portScanner.Port = port;

                    return portScanner.CheckOpen();
                
                case ScanMode.UDP:
                    // Code for UDP scanning mode
                    // TODO
                    break;

            }
            return false;
        }
    }
}

