﻿namespace PortScanner
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hostnameTextBox = new System.Windows.Forms.TextBox();
            this.hostnameLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBoxMin = new System.Windows.Forms.TextBox();
            this.checkPortButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.dashLabel = new System.Windows.Forms.Label();
            this.portTextBoxMax = new System.Windows.Forms.TextBox();
            this.portRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // hostnameTextBox
            // 
            this.hostnameTextBox.Location = new System.Drawing.Point(76, 12);
            this.hostnameTextBox.MaxLength = 15;
            this.hostnameTextBox.Name = "hostnameTextBox";
            this.hostnameTextBox.Size = new System.Drawing.Size(174, 20);
            this.hostnameTextBox.TabIndex = 0;
            // 
            // hostnameLabel
            // 
            this.hostnameLabel.AutoSize = true;
            this.hostnameLabel.Location = new System.Drawing.Point(12, 15);
            this.hostnameLabel.Name = "hostnameLabel";
            this.hostnameLabel.Size = new System.Drawing.Size(58, 13);
            this.hostnameLabel.TabIndex = 1;
            this.hostnameLabel.Text = "Hostname:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(256, 15);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(34, 13);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Ports:";
            // 
            // portTextBoxMin
            // 
            this.portTextBoxMin.Location = new System.Drawing.Point(296, 12);
            this.portTextBoxMin.MaxLength = 5;
            this.portTextBoxMin.Name = "portTextBoxMin";
            this.portTextBoxMin.Size = new System.Drawing.Size(38, 20);
            this.portTextBoxMin.TabIndex = 3;
            // 
            // checkPortButton
            // 
            this.checkPortButton.Location = new System.Drawing.Point(356, 35);
            this.checkPortButton.Name = "checkPortButton";
            this.checkPortButton.Size = new System.Drawing.Size(75, 23);
            this.checkPortButton.TabIndex = 4;
            this.checkPortButton.Text = "Check Ports";
            this.checkPortButton.UseVisualStyleBackColor = true;
            this.checkPortButton.Click += new System.EventHandler(this.checkPortButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Enabled = false;
            this.statusTextBox.Location = new System.Drawing.Point(76, 38);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(253, 20);
            this.statusTextBox.TabIndex = 5;
            this.statusTextBox.Text = "Standby...";
            this.statusTextBox.TextChanged += new System.EventHandler(this.statusTextBox_TextChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(30, 41);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Status:";
            // 
            // dashLabel
            // 
            this.dashLabel.AutoSize = true;
            this.dashLabel.Location = new System.Drawing.Point(340, 15);
            this.dashLabel.Name = "dashLabel";
            this.dashLabel.Size = new System.Drawing.Size(10, 13);
            this.dashLabel.TabIndex = 7;
            this.dashLabel.Text = "-";
            // 
            // portTextBoxMax
            // 
            this.portTextBoxMax.Enabled = false;
            this.portTextBoxMax.Location = new System.Drawing.Point(356, 12);
            this.portTextBoxMax.MaxLength = 5;
            this.portTextBoxMax.Name = "portTextBoxMax";
            this.portTextBoxMax.Size = new System.Drawing.Size(38, 20);
            this.portTextBoxMax.TabIndex = 8;
            // 
            // portRangeCheckBox
            // 
            this.portRangeCheckBox.AutoSize = true;
            this.portRangeCheckBox.Location = new System.Drawing.Point(400, 14);
            this.portRangeCheckBox.Name = "portRangeCheckBox";
            this.portRangeCheckBox.Size = new System.Drawing.Size(80, 17);
            this.portRangeCheckBox.TabIndex = 9;
            this.portRangeCheckBox.Text = "Port Range";
            this.portRangeCheckBox.UseVisualStyleBackColor = true;
            this.portRangeCheckBox.CheckedChanged += new System.EventHandler(this.portRangeCheckBox_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 71);
            this.Controls.Add(this.portRangeCheckBox);
            this.Controls.Add(this.portTextBoxMax);
            this.Controls.Add(this.dashLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.checkPortButton);
            this.Controls.Add(this.portTextBoxMin);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.hostnameLabel);
            this.Controls.Add(this.hostnameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "PortScanner 0.1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hostnameTextBox;
        private System.Windows.Forms.Label hostnameLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBoxMin;
        private System.Windows.Forms.Button checkPortButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label dashLabel;
        private System.Windows.Forms.TextBox portTextBoxMax;
        private System.Windows.Forms.CheckBox portRangeCheckBox;
    }
}
