using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortScanner
{
    class ScannerManager
    {
        private static ScannerManager instance;

        private PortScanner portScanner;

        private ScannerManager()
        {
            portScanner = PortScanner.Instance;
        }

        public static ScannerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScannerManager();
                }

                return instance;
            }
        }
    }
}
