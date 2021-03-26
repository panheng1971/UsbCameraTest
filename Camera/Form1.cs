using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace Camera
{
  
    public partial class Form1 : Form
    {

        private FilterInfoCollection videoDevices;//所有摄像设备
        private VideoCaptureDevice videoDevice;//摄像设备

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);//得到所有接入的摄像设备
            if (videoDevices.Count != 0)
            {
                foreach (FilterInfo device in videoDevices)
                {
                    comboBoxSelectCam.Items.Add(device.Name);//把摄像设备添加到摄像列表中
                    comboBoxSelectCam.SelectedIndex=0;
                    videoDevice = new VideoCaptureDevice(videoDevices[comboBoxSelectCam.SelectedIndex].MonikerString);
                }
            }
            else
            {
                MessageBox.Show("没有找到摄像头！");
            }

        }

        private void start_Click(object sender, EventArgs e)
        {
           
            videoSourcePlayer1.VideoSource = videoDevice;
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            videoSourcePlayer1.Start();
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }

        private void stop_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.Stop();
        }

        private void buttonAdj_Click(object sender, EventArgs e)
        {
            videoDevice.DisplayPropertyPage(IntPtr.Zero);
        }
    }
}
