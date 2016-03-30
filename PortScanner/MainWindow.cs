using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScanner
{
    public partial class MainWindow : Form
    {

        ScannerManager sm;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Get the manager instance
            sm = ScannerManager.Instance;

            // Initialize ScannerManager
            sm.Initialize();
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkPortButton_Click(object sender, EventArgs e)
        {
            // Disable inputs
            hostnameTextBox.Enabled = false;
            portTextBox.Enabled = false;
            checkPortButton.Enabled = false;

            // Get inputs
            string hostname = hostnameTextBox.Text;
            int port = System.Int32.Parse(portTextBox.Text);

            // Set status box text
            statusTextBox.Text = String.Format("Connecting to {0}, port {1}...", hostname, port);

            // Send one check request
            bool result = sm.ExecuteOnce(hostname, port);

            if (result)
            {
                statusTextBox.Text = String.Format("{0}, port {1} is open. Standby...", hostname, port);
            }
            else
            {
                statusTextBox.Text = String.Format("{0}, port {1} is closed. Standby...", hostname, port);
            }

            // Enable inputs
            hostnameTextBox.Enabled = true;
            portTextBox.Enabled = true;
            checkPortButton.Enabled = true;
        }
    }
}
