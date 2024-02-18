using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace OperS_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            // Получаем информацию о дисках
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    listBox1.Items.Add("Диск: " + drive.Name);
                    listBox1.Items.Add("Тип: " + drive.DriveType);
                    listBox1.Items.Add("Объем: " + drive.TotalSize);
                    listBox1.Items.Add("Свободно: " + drive.AvailableFreeSpace);
                    listBox1.Items.Add("");
                }
            }

            // Получаем информацию о подключенных устройствах
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            foreach (ManagementObject device in searcher.Get())
            {
                string deviceId = device["DeviceID"].ToString();
                string model = device["Model"].ToString();
                listBox2.Items.Add("Устройство: " + model + " (" + deviceId + ")");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Очищаем ListBox перед обновлением данных
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            // Получаем информацию о дисках
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    listBox1.Items.Add("Диск: " + drive.Name);
                    listBox1.Items.Add("Тип: " + drive.DriveType);
                    listBox1.Items.Add("Объем: " + drive.TotalSize);
                    listBox1.Items.Add("Свободно: " + drive.AvailableFreeSpace);
                    listBox1.Items.Add("");
                }
            }
            // Получаем информацию о подключенных устройствах
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            foreach (ManagementObject device in searcher.Get())
            {
                string deviceId = device["DeviceID"].ToString();
                string model = device["Model"].ToString();
                listBox2.Items.Add("Устройство: " + model + " (" + deviceId + ")");
            }
        }
    }
}
