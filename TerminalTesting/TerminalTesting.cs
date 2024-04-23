using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalTesting
{
    public partial class TerminalTesting : Form
    {
        public TerminalTesting()
        {
            InitializeComponent();
        }

        private void SetConfigSerialPortForHeater()
        {
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.Even;
            serialPort1.StopBits = StopBits.One;
            serialPort1.WriteTimeout = 100;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            comPort.Items.Clear();
            comPort.Items.AddRange(puertos);
        }

        private void btnRefreshCOM_Click(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            comPort.Items.Clear();
            comPort.Items.AddRange(puertos);
        }

        private bool reconocerCOMForComponents(string COM)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    return false;
                }
                // Remember Baud Rate
                serialPort1.PortName = COM;
                serialPort1.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.BackColor == Color.Red)
            {
                if (reconocerCOMForComponents(comPort.SelectedItem.ToString()))
                {
                    btnConnect.BackColor = Color.Green;
                    btnRefreshCOM.Enabled = false;
                }
            }
            else
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    btnConnect.BackColor = Color.Red;
                    btnRefreshCOM.Enabled = true;
                }
            }
        }

        private void sendRequestTCTemp()
        {
            SetConfigSerialPortForHeater();
            string hexCommand;
            string[] hexBytes;
            byte[] binaryData;

            hexCommand = "01 03 20 00 00 01 8F CA";

            hexBytes = hexCommand.Split(' ');

            binaryData = new byte[hexBytes.Length];

            for (int i = 0; i < hexBytes.Length; i++)
            {
                binaryData[i] = Convert.ToByte(hexBytes[i], 16);
            }
            serialPort1.Write(binaryData, 0, binaryData.Length);
        }

        private void btnSendCommandRequestTC_Click(object sender, EventArgs e)
        {
            sendRequestTCTemp();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }
    }
}
