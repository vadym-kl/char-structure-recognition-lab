using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using str_recognition.Logic;
using str_recognition.ImageProcessing;
using str_recognition.UserInterface;

namespace str_recognition
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            Data = new frmMainData();
            imageViewer = new ImageViewer();
        }

        private void bnSamples_Click(object sender, EventArgs e)
        {
            frmSamplesLibrary frms = new frmSamplesLibrary();
            frms.ShowDialog(this);
            SetSampleLibFields();
        }
        public frmMainData Data;//Data that stored in the form context
        public ImageViewer imageViewer;

        public class frmMainData
        {
            public Logic.SamplesLibrary<Logic.QuadraticSample> quadraticSampleLib;
            public Logic.SamplesLibrary<Logic.LinearSample> linearSampleLib;
            public bool IsQuadraticSampleLib;
            public Font fontForSpaceNormalisation;
            public string LibraryFilename;
            public bool isQuadraticSampleLibSaved;
            public bool isLinearSampleLibSaved;
            public Bitmap imageForRecognition;
        }

        private void SetSampleLibFields<TSample>(Logic.SamplesLibrary<TSample> library)
            where TSample : Logic.Sample
        {
            if (library == null) return;
            txSampleNumber.Text = library.Count.ToString();
            txHeight.Text = library.Height.ToString();
            txType.Text = Data.IsQuadraticSampleLib ? "Quadratic" : "Linear";
            txAllSymbols.Text = library.AllSymbols();
        }

        private void SetSampleLibFields()
        {
            if (Data.IsQuadraticSampleLib && Data.quadraticSampleLib != null)
            {
                RImage img = new RImage(Data.quadraticSampleLib.AllSymbols(), Data.quadraticSampleLib);
                pbSamplePreview.Image = img.GetBitmap();
            }
            else
                pbSamplePreview.Image = null;
            SetSampleLibFields(Data.quadraticSampleLib);
            SetSampleLibFields(Data.linearSampleLib);
        }

        private void bnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                Data.imageForRecognition =
                    ImageUtility.MakeGrayscale( new Bitmap(openFileDialog.FileName));
                pbSourceImage.Image = Data.imageForRecognition;
            }
        }

        private void bnAddNoise_Click(object sender, EventArgs e)
        {
            double Dispersion = Convert.ToDouble(txDispersion.Text);
            ImageUtility.AddGreyscaleGaussianNoise(Dispersion, Data.imageForRecognition);
            pbSourceImage.Image = Data.imageForRecognition;
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Data.imageForRecognition.Save(saveFileDialog.FileName);
            }
        }

        private void bnGenerate_Click(object sender, EventArgs e)
        {
            var TestString = txSampleString.Text;
            int x0 = Convert.ToInt32(txLeft.Text);
            int y0 = Convert.ToInt32(txTop.Text); ;
            int xmargin = Convert.ToInt32(txRight.Text);
            int ymargin = Convert.ToInt32(txBottom.Text);
            Bitmap res = CreateBitmapFromString(TestString, x0, y0, xmargin, ymargin);
            if (res == null)
                MessageBox.Show(this, "Choose font for sample generation or load Quaratic Sample Library"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Data.imageForRecognition = res;
                pbSourceImage.Image = res;
            }
        }

        private Bitmap CreateBitmapFromString(string TestString, int x0, int y0, int xmargin, int ymargin, bool TryUseGDI=true,bool ExpandSpaces = true)
        {
            Bitmap result = null;
            if ((Data.fontForSpaceNormalisation != null) && TryUseGDI)//use internal GDI+ function
            {
                var font = Data.fontForSpaceNormalisation;
                Bitmap bm = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bm);
                StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
                sf.Trimming = StringTrimming.None;
                SizeF sz = g.MeasureString(TestString, font, new PointF(0, 0), sf);
                g.Dispose();
                result = new Bitmap((int)sz.Width + 1 + x0 + xmargin,
                    font.Height + y0 + ymargin);
                Graphics gs = Graphics.FromImage(result);
                gs.FillRectangle(new SolidBrush(Color.White), 0, 0,result.Width,
                    result.Height);
                gs.DrawString(TestString, font, new SolidBrush(Color.Black), new PointF(x0, y0), sf);
                gs.Dispose();
                result = ImageProcessing.ImageUtility.MakeGrayscale(result);
                return result;
            }
            else //use RImage facilities
            {
                if (Data.quadraticSampleLib != null)
                {
                    var img = new RImage(TestString, Data.quadraticSampleLib,ExpandSpaces);
                    using (var bm = img.GetBitmap())
                    {
                        result = new Bitmap(bm.Width + x0 + xmargin,
                            bm.Height + y0 + ymargin);
                        Graphics gs = Graphics.FromImage(result);
                        gs.FillRectangle(new SolidBrush(Color.White), 0, 0, result.Width,
                            result.Height);
                        gs.DrawImage(bm, new Point(x0, y0));
                        gs.Dispose();
                    }
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        private void bnSelectFont_Click(object sender, EventArgs e)
        {
            if (Data.fontForSpaceNormalisation != null)
                fontDialog.Font = Data.fontForSpaceNormalisation;
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Data.fontForSpaceNormalisation = fontDialog.Font;
            }
        }

        private void cbFontSpacing_CheckedChanged(object sender, EventArgs e)
        {
            if (Data.fontForSpaceNormalisation == null)
            {
                if (cbFontSpacing.Checked)
                {
                    MessageBox.Show(this, "Choose font at first"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bnSelectFont_Click(null, null);
                    if (Data.fontForSpaceNormalisation == null)cbFontSpacing.Checked = false;
                }
            }
        }

        private void bnRecognise_Click(object sender, EventArgs e)
        {
            if (Data.imageForRecognition == null)
            {
                MessageBox.Show(this, "You should load an image for recognition at first",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Data.IsQuadraticSampleLib)//the case of quadratic sample lib
            {
                if (Data.quadraticSampleLib != null)
                {
                    lbProcessing.Visible = true;
                    long shift = 0;
                    string result = "";
                    if (cbFontSpacing.Checked)
                    {
                        result = QuadraticSamplesServices.RecogniseBitmap(
                            Data.quadraticSampleLib,
                            Data.imageForRecognition,
                            out shift, Data.fontForSpaceNormalisation);
                        pbRegenrated.Image = CreateBitmapFromString(result, 0, (int)shift, 0, 0);
                        if(result.CompareTo(txSampleString.Text)==0)
                        {
                            lbIdentical.Visible = true;
                            lbIdentical.Text = "Strings are identiacal";
                        }
                        else
                            lbIdentical.Visible = false;
                    }
                    else
                    {
                        result = QuadraticSamplesServices.RecogniseBitmap(
                            Data.quadraticSampleLib,
                            Data.imageForRecognition,
                            out shift, null);
                        pbRegenrated.Image = CreateBitmapFromString(result, 0, (int)shift, 0, 0, false, false);
                        if (result.Replace(" ","").CompareTo(txSampleString.Text.Replace(" ","")) == 0)
                        {
                            lbIdentical.Visible = true;
                            lbIdentical.Text = "If we remove extra spaces strings will be identical";
                        }
                        else
                            lbIdentical.Visible = false;
                    }
                    lbProcessing.Visible = false;
                    txResult.Text = result;
                    txShift.Text = shift.ToString();
 
                }
                else //No lib loaded
                {
                    MessageBox.Show(this, "Load sample library at first",
                         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bnSamples_Click(null, null);
                }

            }
            else//the case of linear sample lib
            {
                if (Data.linearSampleLib != null)
                {
                    long shift = 0;
                    string result = QuadraticSamplesServices.RecogniseBitmap(
                        Data.linearSampleLib,
                        Data.imageForRecognition,
                        out shift, Data.fontForSpaceNormalisation);
                    txfff.Text = result;
                    txShift.Text = shift.ToString();
                    if (result.Replace(" ", "").CompareTo(txSampleString.Text.Replace(" ", "")) == 0)
                    {
                        lbIdentical.Visible = true;
                        lbIdentical.Text = "If we remove extra spaces strings will be identical";
                    }
                    else
                        lbIdentical.Visible = false;
                    lbProcessing.Visible = false;
                    
                }
                else //No lib loaded
                {
                    MessageBox.Show(this, "Load sample library at first",
                         "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bnSamples_Click(null, null);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            fontDialog.Font = txSampleString.Font;
            Data.fontForSpaceNormalisation = fontDialog.Font;
        }

        private void txDispersion_Validating(object sender, CancelEventArgs e)
        {
            ValidateNumberTextBox(sender, e, 255, 0);
        }

        private void txTop_Validating(object sender, CancelEventArgs e)
        {
            ValidateNumberTextBox(sender, e, int.MaxValue, 0);
        }

        private void ValidateNumberTextBox(object sender, CancelEventArgs e, int maxvalue, int minvalue)
        {
            try
            {
                TextBox tx = (TextBox)sender;
                int numberEntered = int.Parse(tx.Text);
                if (numberEntered < minvalue || numberEntered > maxvalue)
                {
                   
                    e.Cancel = true;
                    MessageBox.Show(this, "You have to enter a number not less then 0 ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show(this, "You need to enter an integer", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ShowImageViewer(PictureBox parent)
        {
            if (parent.Image != null)
            {
                imageViewer.ImageToShow = new Bitmap(parent.Image);
                imageViewer.ShowDialog(this);
            }
        }
        private void pbSamplePreview_Click(object sender, EventArgs e)
        {
            ShowImageViewer(pbSamplePreview);
        }

        private void pbSourceImage_Click(object sender, EventArgs e)
        {
            ShowImageViewer(pbSourceImage);
        }

        private void pbRegenrated_Click(object sender, EventArgs e)
        {
            ShowImageViewer(pbRegenrated);
        }

        private void bnCompareImages_Click(object sender, EventArgs e)
        {
            if(pbRegenrated.Image != null)
            {
                Bitmap compBmp = new Bitmap( 
                    pbSourceImage.Image.Width,  
                    pbSourceImage.Image.Height + pbRegenrated.Image.Height+ 5);
                Graphics gs = Graphics.FromImage(compBmp);
                gs.DrawImage(pbSourceImage.Image, new Point(0, 0));
                gs.DrawImage(pbRegenrated.Image, new Point(0,pbSourceImage.Image.Height + 5));
                gs.Dispose();
                imageViewer.ImageToShow =compBmp;
                imageViewer.ShowDialog();
                compBmp.Dispose();
            }
        }
    }
}
