using NModbus;
using NModbus.Device;
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
        // Variable to store temperature value
        private double temperatureValue = 0.0;

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
            ////SetConfigSerialPortForHeater();
            ////string hexCommand;
            ////string[] hexBytes;
            ////byte[] binaryData;



            //////hexCommand = "01 03 20 00 00 01 8F CA";


            ////// Command Echo Back Test
            ////hexCommand = "01 08 00 00 12 34 ED C7";

            ////hexBytes = hexCommand.Split(' ');

            ////binaryData = new byte[hexBytes.Length];

            ////for (int i = 0; i < hexBytes.Length; i++)
            ////{
            ////    binaryData[i] = Convert.ToByte(hexBytes[i], 16);
            ////}
            ////serialPort1.Write(binaryData, 0, binaryData.Length);
            ///

            SetConfigSerialPortForHeater();
            //string hexCommand = "01 03 20 00 00 01 8F CA";
            string hexCommand = "02 03 20 00 00 01 8F F9";
            SendHexCommand(hexCommand);
        }

        private void sendSP20()
        {
            SetConfigSerialPortForHeater();
            string hexCommand;
            string[] hexBytes;
            byte[] binaryData;

            hexCommand = "01 06 21 03 00 14 73 F9";

            hexBytes = hexCommand.Split(' ');

            binaryData = new byte[hexBytes.Length];

            for (int i = 0; i < hexBytes.Length; i++)
            {
                binaryData[i] = Convert.ToByte(hexBytes[i], 16);
            }
            serialPort1.Write(binaryData, 0, binaryData.Length);
        }

        private void sendSP0()
        {
            SetConfigSerialPortForHeater();
            string hexCommand;
            string[] hexBytes;
            byte[] binaryData;

            hexCommand = "01 06 21 03 00 00 73 F6";

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
            textBox1.Text = temperatureValue.ToString();

            sendRequestTCTemp();
        }

        // Helper method to send a hexadecimal command
        private void SendHexCommand(string hexCommand)
        {
            string[] hexBytes = hexCommand.Split(' ');
            byte[] binaryData = new byte[hexBytes.Length];
            for (int i = 0; i < hexBytes.Length; i++)
            {
                binaryData[i] = Convert.ToByte(hexBytes[i], 16);
            }
            serialPort1.Write(binaryData, 0, binaryData.Length);
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            // Read data from the serial port
            int bytesToRead = serialPort1.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            serialPort1.Read(buffer, 0, bytesToRead);

            //// Convert the buffer data to hexadecimal format and print to console
            //Console.WriteLine("Received data in hexadecimal format:");
            //Console.WriteLine(BitConverter.ToString(buffer));

            string receivedData = BitConverter.ToString(buffer);

            string[] hexValues = receivedData.Split('-');

            if(hexValues.Length >= 5)
            {
                // Assuming the temperature value is represented by the bytes "02-00"
                string temperatureHex = $"{hexValues[3]}-{hexValues[4]}"; // Combine the bytes representing the temperature value
                int temperatureValueInt = Convert.ToInt32(temperatureHex.Replace("-", ""), 16);

                temperatureValue = temperatureValueInt;

                //// Assuming the received data contains the temperature value in ASCII representation
                //string receivedData = Encoding.ASCII.GetString(buffer);

                //// Parse the received data to extract the temperature value
                //double.TryParse(receivedData, out temperatureValue);


                Console.WriteLine("temperatureValueInt: ");
                Console.WriteLine(temperatureValueInt);

                // Update the label with the temperature value
                UpdateTemperatureLabel();
            } 
            else
            {
                Console.WriteLine("incomplete data received");
            }
        }

        // Method to update the temperature label
        private void UpdateTemperatureLabel()
        {
            // Check if the UI update is required to be done on the UI thread
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UpdateTemperatureLabel));
            }
            else
            {
                // Update the label text with the temperature value
                temperatureLabel.Text = $"Temperature: {temperatureValue} °C";
            }
        }

        private void btnSP20_Click(object sender, EventArgs e)
        {
            sendSP20();
        }

        private void btnSP0_Click(object sender, EventArgs e)
        {
            sendSP0();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }
    }
}
