using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

namespace Face_Detection
{
    public partial class Form1 : Form
    {

        private Capture capture;
        private CascadeClassifier haar;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            haar = new CascadeClassifier("C:/Emgu/emgucv-windows-universal 3.0.0.2157/opencv/opencv-master/opencv-master/data/haarcascades/haarcascade_eye.xml");

            using (var imageFrame = capture.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (imageFrame != null)
                    {
                        var grayframe = imageFrame.Convert<Gray, byte>();
                        var eyes = haar.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual eye detection happens here
                        foreach (var eye in eyes)
                        {
                            imageFrame.Draw(eye, new Bgr(Color.BurlyWood), 4); //the detected eye(s) is highlighted here using a box that is drawn around it/them 
                        }
                    }
                    imageBox1.Image = imageFrame;                    
                }
         }   
        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new Capture();
           // haar = new HaarCascade("..\\..\\..\\..\\lib\\haarcascade_frontalface_alt2.xml");
        }
    }
}
