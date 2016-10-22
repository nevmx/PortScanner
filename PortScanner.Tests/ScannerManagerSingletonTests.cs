using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using PortScanner;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;

namespace PortScanner.Tests
{
    [TestFixture]
    public class ScannerManagerSingletonTests
    {
        [Test]
        public void ShouldIntiateUDPPortScanner()
        {
            //Arrange
            var scannerManagerSingleton = new ScannerManagerSingleton();
            ScannerManagerSingleton.ScanMode scanMode;
            scanMode = ScannerManagerSingleton.ScanMode.UDP;
            string hostname = "127.0.0.1";
            int port = 80;
            int timeout = 2000;


            MainWindow.ExecuteOnceAsyncCallback callback = new MainWindow.ExecuteOnceAsyncCallback();
            CancellationToken cancellationToken = new CancellationToken();


            //Act
            A.CallTo(
                () =>
                    scannerManagerSingleton.ExecuteOnceAsync(hostname, port, timeout, scanMode, callback,
                        cancellationToken)).MustHaveHappened();

            //Assert
            scannerManagerSingleton.ExecuteOnceAsync(hostname, port, timeout, scanMode, callback,
                cancellationToken);


        }
    }
    //public enum ScanMode
    //{
    //    TCP = 1,
    //    UDP = 2
    //}

}

