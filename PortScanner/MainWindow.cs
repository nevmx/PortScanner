using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScanner
{
    public partial class MainWindow : Form
    {
        // Delegate to report back with one open port
        public delegate void ExecuteOnceCallback(int openPort);

        // Delegate to report back with one open port (Async)
        public delegate void ExecuteOnceAsyncCallback(int port, bool isOpen, bool isCancelled);

        // The manager instance
        ScannerManagerSingleton smc;

        // Cancellation token source for the cancel button
        CancellationTokenSource cts;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Get the ScannerManagerSingleton instance
            smc = ScannerManagerSingleton.Instance;

            // Add new line to log text box
            statusTextBox.Text += Environment.NewLine;

            // Populate the timeout times list box
            PopulateTimeoutListBox();
        }

        private void PopulateTimeoutListBox()
        {
            // Assign the list to the ComboBox's DataSource property
            timeoutComboBox.DataSource = TimeoutListItem.CreateTimeoutListItems();
            timeoutComboBox.DisplayMember = "DisplayMember";
            timeoutComboBox.ValueMember = "ValueMember";

            // Set default value
            timeoutComboBox.SelectedValue = 2000;
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void PortResult(int port, bool isOpen, bool isCancelled)
        {
            string status;

            if (isOpen)
            {
                status = String.Format("{0}, port {1} is open.{2}", hostnameTextBox.Text, port, Environment.NewLine);
            }
            else
            {
                if (!isCancelled)
                {
                    status = String.Format("{0}, port {1} is closed.{2}", hostnameTextBox.Text, port, Environment.NewLine); 
                }
                else
                {
                    status = "Operation cancelled." + Environment.NewLine;
                }
            }

            statusTextBox.AppendText(status);
            ToggleInputs(true);
        }

        private void checkPortButton_Click(object sender, EventArgs e)
        {
            ToggleInputs(false);

            // Get user inputs
            string hostname = hostnameTextBox.Text;
            int portMin = System.Int32.Parse(portTextBoxMin.Text);
            ScannerManagerSingleton.ScanMode scanMode = ReadScanMode();
            int timeout = (int)timeoutComboBox.SelectedValue;

            // Instantiate CTS
            cts = new CancellationTokenSource();

            // Simple one port check
            if (!portRangeCheckBox.Enabled)
            {
                // Set status box text
                statusTextBox.AppendText(String.Format("Connecting to {0}, port {1}...{2}", hostname, portMin, Environment.NewLine));

                // The callback for scan result
                var callback = new ExecuteOnceAsyncCallback(PortResult);

                // Send one check request
                smc.ExecuteOnceAsync(hostname, portMin, timeout, scanMode, callback, cts.Token);
            }

            // Port range check
            else
            {
                // var callback = new ExecuteOnceCallback(WriteOpenPort);
                int portMax = System.Int32.Parse(portTextBoxMax.Text);

                // TODO: sm.ExecuteRange(hostname, portMin, portMax, writeDelegate);
            }
        }

        // Read scan mode radio button selection
        private ScannerManagerSingleton.ScanMode ReadScanMode()
        {
            if (tcpModeRadioButton.Checked)
                return ScannerManagerSingleton.ScanMode.TCP;
            else
                return ScannerManagerSingleton.ScanMode.UDP;
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

            // Re-disable the portMax text box
            if (!portRangeCheckBox.Checked)
            {
                portTextBoxMax.Enabled = false;
            }

            // Set focus to hostnameTextBox
            if (setting)
                hostnameTextBox.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // If cts is instantiated (i.e. the scanning operation is in progress, request cancellation
            if (cts != null)
            {
                cts.Cancel();
            }
        }
    }
}
