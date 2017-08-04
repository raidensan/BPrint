namespace PrintSample_ParameterizedContent
{
    partial class FormParameterizedContent
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
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.radioButtonTcpIp = new System.Windows.Forms.RadioButton();
            this.radioButtonBtSpp = new System.Windows.Forms.RadioButton();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectPayloadFile = new System.Windows.Forms.Button();
            this.textBoxPayloadFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.numericUpDownPort.Location = new System.Drawing.Point(168, 55);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownPort.TabIndex = 19;
            this.numericUpDownPort.Value = new decimal(new int[] {
            9100,
            0,
            0,
            0});
            this.numericUpDownPort.Visible = false;
            // 
            // textBoxIp
            // 
            this.textBoxIp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxIp.Location = new System.Drawing.Point(85, 55);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(77, 19);
            this.textBoxIp.TabIndex = 18;
            this.textBoxIp.Visible = false;
            // 
            // radioButtonTcpIp
            // 
            this.radioButtonTcpIp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.radioButtonTcpIp.Location = new System.Drawing.Point(3, 55);
            this.radioButtonTcpIp.Name = "radioButtonTcpIp";
            this.radioButtonTcpIp.Size = new System.Drawing.Size(77, 20);
            this.radioButtonTcpIp.TabIndex = 17;
            this.radioButtonTcpIp.TabStop = false;
            this.radioButtonTcpIp.Text = "TCP IP";
            // 
            // radioButtonBtSpp
            // 
            this.radioButtonBtSpp.Checked = true;
            this.radioButtonBtSpp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.radioButtonBtSpp.Location = new System.Drawing.Point(3, 29);
            this.radioButtonBtSpp.Name = "radioButtonBtSpp";
            this.radioButtonBtSpp.Size = new System.Drawing.Size(77, 20);
            this.radioButtonBtSpp.TabIndex = 16;
            this.radioButtonBtSpp.Text = "BT SPP";
            this.radioButtonBtSpp.CheckedChanged += new System.EventHandler(this.radioButtonBtSpp_CheckedChanged);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.buttonPrint.Location = new System.Drawing.Point(3, 81);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(232, 23);
            this.buttonPrint.TabIndex = 15;
            this.buttonPrint.Text = "Print !";
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCOM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.comboBoxCOM.Location = new System.Drawing.Point(85, 29);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(150, 19);
            this.comboBoxCOM.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.Text = "Payload Path";
            // 
            // buttonSelectPayloadFile
            // 
            this.buttonSelectPayloadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectPayloadFile.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.buttonSelectPayloadFile.Location = new System.Drawing.Point(212, 4);
            this.buttonSelectPayloadFile.Name = "buttonSelectPayloadFile";
            this.buttonSelectPayloadFile.Size = new System.Drawing.Size(23, 19);
            this.buttonSelectPayloadFile.TabIndex = 14;
            this.buttonSelectPayloadFile.Text = "...";
            this.buttonSelectPayloadFile.Click += new System.EventHandler(this.buttonSelectPayloadFile_Click);
            // 
            // textBoxPayloadFilePath
            // 
            this.textBoxPayloadFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPayloadFilePath.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBoxPayloadFilePath.Location = new System.Drawing.Point(85, 3);
            this.textBoxPayloadFilePath.Name = "textBoxPayloadFilePath";
            this.textBoxPayloadFilePath.Size = new System.Drawing.Size(121, 19);
            this.textBoxPayloadFilePath.TabIndex = 13;
            // 
            // FormParameterizedContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.numericUpDownPort);
            this.Controls.Add(this.textBoxIp);
            this.Controls.Add(this.radioButtonTcpIp);
            this.Controls.Add(this.radioButtonBtSpp);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.comboBoxCOM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSelectPayloadFile);
            this.Controls.Add(this.textBoxPayloadFilePath);
            this.Name = "FormParameterizedContent";
            this.Text = "ParameterizedContent";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.RadioButton radioButtonTcpIp;
        private System.Windows.Forms.RadioButton radioButtonBtSpp;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectPayloadFile;
        private System.Windows.Forms.TextBox textBoxPayloadFilePath;
    }
}

