using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using WirelessPrintHelper;

namespace BTPrintSample1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadAvailableCOMPorts()
        {
            var ports = SerialPort.GetPortNames();

            comboBoxCOM.Items.Clear();

            foreach (var port in ports)
                comboBoxCOM.Items.Add(port);
        }

        private void buttonSelectPayloadFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                textBoxPayloadFilePath.Text = ofd.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAvailableCOMPorts();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (comboBoxCOM.SelectedItem == null)
            {
                MessageBox.Show("Please select a COM Port");
                return;
            }

            if (string.IsNullOrEmpty(textBoxPayloadFilePath.Text))
            {
                MessageBox.Show("Please select a file");
                return;
            }

            if (!File.Exists(textBoxPayloadFilePath.Text))
            {
                MessageBox.Show("Payload file does not exist");
                return;
            }
            if(radioButtonBtSpp.Checked)
                BtSppPrint(comboBoxCOM.SelectedItem.ToString(), new FileInfo(textBoxPayloadFilePath.Text));
            else if(radioButtonTcpIp.Checked)
                TcpIpPrint(textBoxIp.Text, numericUpDownPort.Value, new FileInfo(textBoxPayloadFilePath.Text));
        }

        private void TcpIpPrint(string ip, decimal port, FileInfo filename)
        {
            using (IWirelessPrinter btpHelper = new TcpIpPrinter(ip,(int)port))
            {
                btpHelper.Print(filename);
            }
        }

        private void BtSppPrint(string port, FileInfo file)
        {
            using (IWirelessPrinter btpHelper = new BtSppPrinter(port))
            {
                btpHelper.Print(file);
            }
        }

        private void radioButtonBtSpp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBtSpp.Checked)
            {
                comboBoxCOM.Visible = true;
                textBoxIp.Visible = false;
                numericUpDownPort.Visible = false;
            }
            else
            {
                comboBoxCOM.Visible = false;
                textBoxIp.Visible = true;
                numericUpDownPort.Visible = true;
            }
        }
    }
}