using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace ComPort
{
    public partial class Form1 : Form
    {
        string dataOUT;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = cBoxCOMPORT.Text;
                serialPort.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                serialPort.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);

                serialPort.Open();

                progressBar1.Value = 100;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                progressBar1.Value = 0;
            }
        }

        private void btnSendData_Click_1(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                dataOUT = tBoxDataOut.Text;
                // serialPort.WriteLine(dataOUT);
                serialPort.Write(dataOUT);
            }
        }
    }
}
