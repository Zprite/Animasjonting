using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gif
{
    public partial class Form1 : Form
    {

        Image displayImage = null;
        Image[] images;
        ImageCollection animation;
        int fps = 1;
        bool isPlayingF = false;
        bool isPlayingB = false;

        private void getImages()
        {
           ResourceSet resourceSet = Gif.Properties.animation.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            int i = 0;
            foreach (DictionaryEntry img in resourceSet)
            {
                i++;               
            }
            images = new Image[i];
            foreach (DictionaryEntry img in resourceSet)
            {
                // Bildene må ha ennumererte filnavn
                images[Int16.Parse((String) img.Key)-1] = (Image) img.Value;
            }
        }
        public Form1()
        {
            InitializeComponent();
            getImages();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isPlayingF)
            {
                timer1.Stop();
                button1.Text = "Spill animasjon";
                button2.Text = "Spill baklengs";
            }
            else
            {
                timer1.Interval = 1000 / fps;
                animation = new ImageCollection(images);
                timer1.Start();
                button1.Text = "Stop";
                button2.Text = "Spill baklengs";
                isPlayingB = false;
            }
            isPlayingF = !isPlayingF;
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (isPlayingB)
            {
                timer1.Stop();
                button2.Text = "Spill baklengs";
            }
            else
            {
                timer1.Interval = 1000 / fps;
                // Setter i revers
                animation = new ImageCollection(images, true);
                timer1.Start();
                button1.Text = "Spill animasjon";
                button2.Text = "Stopp";
                isPlayingF = false;
            }
            isPlayingB = !isPlayingB;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            displayImage = animation.GetNextImage();
            pictureBox1.Image = displayImage;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            fps = (int) numericUpDown2.Value;
            timer1.Interval = 1000 / fps;
        }
    }
}
