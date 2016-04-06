using System;
using System.Threading;

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

        // Scan one port asynchronously
        public async void ExecuteOnceAsync(string hostname, int port, int timeout, ScanMode scanMode, MainWindow.ExecuteOnceAsyncCallback callback, CancellationToken ct)
        {
            switch (scanMode)
            {
                case ScanMode.TCP:
                    portScanner = new TCPPortScanner();
                    break;
                case ScanMode.UDP:
                    portScanner = new UDPPortScanner();
                    break;
            }
            // Assign values
            portScanner.Hostname = hostname;
            portScanner.Port = port;
            portScanner.Timeout = timeout;

            // Await for the result of this operation
            var task = portScanner.CheckOpenAsync(ct);
            await task;

            // If a cancellation request has been triggered through CancellationToken ct, we must advise the callback function
            bool cancelled = ct.IsCancellationRequested;

            // Callback with the result and the port
            callback(port, task.Result, cancelled);
        }
    }
}

