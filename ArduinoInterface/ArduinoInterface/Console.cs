using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArduinoInterface
{
    public partial class Console : Form
    {
        public static System.IO.Ports.SerialPort serialPort1;

        public Console()
        {
            
            System.ComponentModel.IContainer components = new System.ComponentModel.Container();
            serialPort1 = new System.IO.Ports.SerialPort(components);
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;

            try
            {
                serialPort1.Open();
            }
            catch (Exception)
            {
                //throw;
            }

            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Error opening serial port " + serialPort1.PortName + ". Application exiting");
                //return;
            }


            serialPort1.DtrEnable = true;
            // start up 
            System.Threading.Thread.Sleep(2000);          
            serialPort1.DataReceived += OnReceived;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (serialPort1)
                {
                    serialPort1.Write(new byte[] { 97 }, 0, 1); // DEC 97 = Char a
                }

                if (checkBox1.Checked == true)
                    checkBox1.Checked = false;
                else
                    checkBox1.Checked = true;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (serialPort1)
                {
                    serialPort1.Write(new byte[] { 98 }, 0, 1); // DEC 98 = Char b
                }

                if (checkBox2.Checked == true)
                    checkBox2.Checked = false;
                else
                    checkBox2.Checked = true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (serialPort1)
                {
                    serialPort1.Write(new byte[] { 99 }, 0, 1); // DEC 99 = Char c
                }

                if (checkBox3.Checked == true)
                    checkBox3.Checked = false;
                else
                    checkBox3.Checked = true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Receives data from serial port and treats it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="c"></param>
        public void OnReceived(object sender, SerialDataReceivedEventArgs c)
        {
            try
            {

                listBox1.Items.Add(serialPort1.ReadExisting());
                listBox1.SelectedIndex = listBox1.Items.Count;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.ToString());

            }
        }
    }
}
