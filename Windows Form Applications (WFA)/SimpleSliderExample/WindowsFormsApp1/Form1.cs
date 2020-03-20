using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Image> Images { get; set; }
        private Image CurrentImage { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            // resim picturebox'ı kaplasın
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // timer'ın interval'i 2sn
            timer1.Interval = 2000;

            // resimleri içeren listeyi oluşturdum
            // bu kısmı veritabanından çekip doldurabilirsin
            Images = new List<Image>
            {
                new Image
                {
                    ImagePath = "https://picsum.photos/500/500",
                },
                new Image
                {
                    ImagePath = "https://picsum.photos/500/500",
                },
                new Image
                {
                    ImagePath = "https://picsum.photos/500/500",
                },
                new Image
                {
                    ImagePath = "https://picsum.photos/500/500",
                }
            };

            // ilk resmi atayalım
            CurrentImage = Images.First();
            pictureBox1.Load(CurrentImage.ImagePath);

            // döngü için timer'ı başlatalım
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // şuanki index'i alalım
            var currentIndex = Images.FindIndex(x => x == CurrentImage);

            // eğer son resime gelinmiş ise
            if (currentIndex + 1 == Images.Count())
            {
                // ilk resmi seçelim
                CurrentImage = Images.First();
            }
            else
            {
                // sıradaki resmi seçelim
                CurrentImage = Images[currentIndex + 1];
            }

            // resmi gösterelim
            pictureBox1.Load(CurrentImage.ImagePath);
        }
    }

    public class Image
    {
        public string ImagePath { get; set; }
    }
}
