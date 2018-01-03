using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace DynaboxDebugger
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(byte[] f);
        int desired_data = 5;
        //int desired_data = 6;
        int received_data = 0;
        int position = 0;
        byte[] rxbytearray = new byte[5];
        //byte[] rxbytearray = new byte[6];
        enum PortStatus { Connected, Disconnected, Busy };

        public Form1()
        {
            InitializeComponent();
        }

        private void PortStatusInfo(PortStatus status)
        {
            if (status == PortStatus.Connected)
            {
                button_connection.Text = "Disconnect";
            }
            if (status == PortStatus.Disconnected)
            {
                button_connection.Text = "Connect";
            }
            if (status == PortStatus.Busy)
            {
                button_connection.Text = "Connect";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);

            foreach (string s in SerialPort.GetPortNames())
            {
                ports.Items.Add(s);
            }
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int numbytes = serial.BytesToRead;

            received_data += numbytes;
            if (received_data <= desired_data)
            {
                for (int i = position; i < received_data; i++)
                {
                    rxbytearray[i] = (byte)serial.ReadByte();
                }
                position += numbytes;
            }

            if (received_data == desired_data)
            {
                received_data = 0;
                position = 0;
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { rxbytearray });
            }

        }

        private void PiszLog(string r)
        {
            try
            {
                FileStream wFile;
                byte[] byteData = null;
                string czas = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff ");
                string ramka = czas + r;

                byteData = Encoding.ASCII.GetBytes(ramka);
                wFile = new FileStream(@"log.txt", FileMode.Append);
                wFile.Write(byteData, 0, byteData.Length);
                wFile.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SetText(byte[] f)
        {
            preview.SelectionColor = System.Drawing.Color.Red;
            string pos = (f[0] << 8 | f[1]).ToString() + ';' + f[2].ToString() + ';' + (f[3] << 8 | f[4]).ToString() + "\r\n";
            //string dane = f[0].ToString("X2") + ' ' + f[1].ToString("X2") + ' ' + f[2].ToString("X2") + ' ' + f[3].ToString("X2") + "\r\n";
            preview.AppendText(pos);
            preview.ScrollToCaret();
            PiszLog(pos);
        }

        private void button_connection_Click(object sender, EventArgs e)
        {
            if (ports.SelectedItem == null) return;
            if (serial.IsOpen == false)
            {
                serial.PortName = ports.SelectedItem.ToString();
                try
                {
                    serial.Open();
                }
                catch (Exception ex)
                {
                    //PortStatusInfo(PortStatus.Busy);
                }

                if (serial.IsOpen == true) PortStatusInfo(PortStatus.Connected);
            }
            else
            {
                serial.Close();
                PortStatusInfo(PortStatus.Disconnected);
            }
        }
    }
}
