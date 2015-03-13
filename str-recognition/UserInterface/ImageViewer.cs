using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace str_recognition.UserInterface
{
    public partial class ImageViewer : Form
    {
        public ImageViewer()
        {
            InitializeComponent();
        }

        private Bitmap _ImageToShow;

        public Bitmap ImageToShow
        {
            get { return _ImageToShow; }
            set { pictureBox.Image = value;
            _ImageToShow = value;
            }
        }
    }
}
