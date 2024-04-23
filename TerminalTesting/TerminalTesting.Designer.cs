namespace TerminalTesting
{
    partial class TerminalTesting
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
            this.components = new System.ComponentModel.Container();
            this.comPort = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnRefreshCOM = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSendCommandRequestTC = new System.Windows.Forms.Button();
            this.btnSP20 = new System.Windows.Forms.Button();
            this.btnSP0 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comPort
            // 
            this.comPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPort.FormattingEnabled = true;
            this.comPort.Location = new System.Drawing.Point(39, 62);
            this.comPort.Name = "comPort";
            this.comPort.Size = new System.Drawing.Size(121, 21);
            this.comPort.TabIndex = 0;
            // 
            // serialPort1
            // 
            this.serialPort1.Parity = System.IO.Ports.Parity.Even;
            this.serialPort1.WriteTimeout = 100;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnRefreshCOM
            // 
            this.btnRefreshCOM.Location = new System.Drawing.Point(39, 142);
            this.btnRefreshCOM.Name = "btnRefreshCOM";
            this.btnRefreshCOM.Size = new System.Drawing.Size(121, 23);
            this.btnRefreshCOM.TabIndex = 1;
            this.btnRefreshCOM.Text = "Refresh COM Ports";
            this.btnRefreshCOM.UseVisualStyleBackColor = true;
            this.btnRefreshCOM.Click += new System.EventHandler(this.btnRefreshCOM_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Red;
            this.btnConnect.Location = new System.Drawing.Point(39, 99);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(121, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSendCommandRequestTC
            // 
            this.btnSendCommandRequestTC.Location = new System.Drawing.Point(607, 62);
            this.btnSendCommandRequestTC.Name = "btnSendCommandRequestTC";
            this.btnSendCommandRequestTC.Size = new System.Drawing.Size(249, 54);
            this.btnSendCommandRequestTC.TabIndex = 3;
            this.btnSendCommandRequestTC.Text = "Send Request Command";
            this.btnSendCommandRequestTC.UseVisualStyleBackColor = true;
            this.btnSendCommandRequestTC.Click += new System.EventHandler(this.btnSendCommandRequestTC_Click);
            // 
            // btnSP20
            // 
            this.btnSP20.Location = new System.Drawing.Point(607, 186);
            this.btnSP20.Name = "btnSP20";
            this.btnSP20.Size = new System.Drawing.Size(249, 54);
            this.btnSP20.TabIndex = 4;
            this.btnSP20.Text = "Send SP 20";
            this.btnSP20.UseVisualStyleBackColor = true;
            this.btnSP20.Click += new System.EventHandler(this.btnSP20_Click);
            // 
            // btnSP0
            // 
            this.btnSP0.Location = new System.Drawing.Point(607, 258);
            this.btnSP0.Name = "btnSP0";
            this.btnSP0.Size = new System.Drawing.Size(249, 54);
            this.btnSP0.TabIndex = 5;
            this.btnSP0.Text = "Send SP 0";
            this.btnSP0.UseVisualStyleBackColor = true;
            // 
            // TerminalTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(965, 499);
            this.Controls.Add(this.btnSP0);
            this.Controls.Add(this.btnSP20);
            this.Controls.Add(this.btnSendCommandRequestTC);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRefreshCOM);
            this.Controls.Add(this.comPort);
            this.Name = "TerminalTesting";
            this.Text = "Terminal Testing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnRefreshCOM;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSendCommandRequestTC;
        private System.Windows.Forms.Button btnSP20;
        private System.Windows.Forms.Button btnSP0;
    }
}

