using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WirelessPrintHelper;

namespace PrintSample_ParameterizedContent
{
    public partial class FormParameterizedContent : Form
    {
        public FormParameterizedContent()
        {
            InitializeComponent();

            textBoxPayloadFilePath.Text = Path.GetFullPath(@"afterParameterizing.LBL");
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
            if (radioButtonBtSpp.Checked)
                BtSppPrint(comboBoxCOM.SelectedItem.ToString(), new FileInfo(textBoxPayloadFilePath.Text));
            else if (radioButtonTcpIp.Checked)
                TcpIpPrint(textBoxIp.Text, numericUpDownPort.Value, new FileInfo(textBoxPayloadFilePath.Text));
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

        private void TcpIpPrint(string ip, decimal port, FileInfo filename)
        {
            using (IWirelessPrinter btpHelper = new TcpIpPrinter(ip, (int)port))
            {
                btpHelper.Print(PrepareContent(filename.FullName));   
            }
        }

        private void BtSppPrint(string port, FileInfo file)
        {
            using (IWirelessPrinter btpHelper = new BtSppPrinter(port))
            {
                btpHelper.Print(PrepareContent(file.FullName));   
            }
        }

        private byte[] PrepareContent(string filename)
        {
            // Prepare content parameters and their values
            // Parameters are <ProductName>, <StockCode> & <Barcode>
            // see afterParameterizing.LBL contents
            IContentParameters param = new ContentParameters();
            param.Add("<ProductName>", "My Sample Products");
            param.Add("<StockCode>", "PC-01");
            param.Add("<Barcode>", "8693332221117");

            // Read payload file
            IFileContentReader reader = new FileContentReader(filename);
            byte[] payload = reader.ReadAllAsByte();

            // Do the replacing
            IContentReplacer replacer = new ContentReplacer(param, Encoding.UTF8);
            return replacer.Replace(payload);
        }
    }
}