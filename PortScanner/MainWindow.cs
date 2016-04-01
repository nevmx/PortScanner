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
        // Delegate to report back with an open port
        public delegate void WriteOpenPortDelegate(int openPort);

        ScannerManager sm;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Write an open port to status bar
        private void WriteOpenPort(int port)
        {
            statusTextBox.Text = String.Format("{0} {1}", statusTextBox.Text, port);
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
            ToggleInputs(false);

            // Simple one port check
            if (portRangeCheckBox.Enabled)
            {
                // Get inputs
                string hostname = hostnameTextBox.Text;
                int port = System.Int32.Parse(portTextBoxMin.Text);

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
            }
            // Port range check
            else
            {
                WriteOpenPortDelegate writeDelegate = new WriteOpenPortDelegate(WriteOpenPort);

                string hostname = hostnameTextBox.Text;
                int portMin = Int32.Parse(portTextBoxMin.Text);
                int portMax = Int32.Parse(portTextBoxMax.Text);

                statusTextBox.Text = "Open: ";

                sm.ExecuteRange(hostname, portMin, portMax, writeDelegate);
            }
            // Enable inputs
            ToggleInputs(true);
        }

        private void portRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (portRangeCheckBox.Checked)
            {
                portTextBoxMax.Enabled = true;
            }
            else
            {
                portTextBoxMax.Enabled = false;
            }
        }

        // Toggle all inputs
        private void ToggleInputs(bool setting)
        {
            hostnameTextBox.Enabled = setting;
            portTextBoxMin.Enabled = setting;
            checkPortButton.Enabled = setting;
            portTextBoxMax.Enabled = setting;
            portRangeCheckBox.Enabled = setting;
        }
    }
}
