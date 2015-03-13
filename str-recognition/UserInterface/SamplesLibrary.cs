using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using str_recognition.Logic;

namespace str_recognition
{
    public partial class frmSamplesLibrary : Form
    { 
        public frmSamplesLibrary()
        {
            InitializeComponent();
        }

        private void bnLoadFromFile_Click(object sender, EventArgs e)
        {
            if (!CheckForSaveWarning()) return;
            if (openFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            Logic.SamplesLibrary<Logic.QuadraticSample> qudraticSampleLib=null;
            Logic.SamplesLibrary<Logic.LinearSample> linearSampleLib=null;
            XmlSerializer xsQuadratic = new XmlSerializer(typeof(Logic.SamplesLibrary<Logic.QuadraticSample>));
            XmlSerializer xsLinear = new XmlSerializer(typeof(Logic.SamplesLibrary<Logic.LinearSample>));
            bool IsQuadrtaticOk = true, IsLinearOk = true;
            try
            {
                using (Stream s = openFileDialog.OpenFile())
                {
                    qudraticSampleLib = (Logic.SamplesLibrary<Logic.QuadraticSample>)
                        xsQuadratic.Deserialize(s);
                    s.Close();
                }
            }
            catch
            {
                IsQuadrtaticOk = false;
            }
            try
            {
                using (Stream s = openFileDialog.OpenFile())
                {
                    linearSampleLib = (Logic.SamplesLibrary<Logic.LinearSample>)
                        xsLinear.Deserialize(s);
                    s.Close();
                }
            }
            catch
            {
                IsLinearOk = false;
            }
            if (!(IsLinearOk || IsQuadrtaticOk))
                MessageBox.Show(this,"You have selected a wrong XML Sample Library file");
            else
            {
                parentData.IsQuadraticSampleLib = IsQuadrtaticOk;
                parentData.LibraryFilename = openFileDialog.FileName;
                parentData.fontForSpaceNormalisation = null;
                if (IsQuadrtaticOk)
                {
                    parentData.quadraticSampleLib = qudraticSampleLib;
                    parentData.isQuadraticSampleLibSaved = true;
                    SetSampleLibFields(qudraticSampleLib);
                }
                else
                {
                    parentData.linearSampleLib = linearSampleLib;
                    parentData.isLinearSampleLibSaved = true;
                    SetSampleLibFields(linearSampleLib);
                }
                
            }
        }

        private void SetSampleLibFields<TSample>(Logic.SamplesLibrary<TSample> library)
            where TSample: Logic.Sample
        {
            if (library == null) return;
            GenerateSampleImage();
            if (parentData.LibraryFilename != null)
            {
                txFileName.Text = parentData.LibraryFilename;
                txFileName.Select(parentData.LibraryFilename.Length - 1, 1);
            }
            txSampleNumber.Text = library.Count.ToString();
            txHeight.Text = library.Height.ToString();
            txType.Text = parentData.IsQuadraticSampleLib ? "Quadratic" : "Linear";
            txAllSymbols.Text = library.AllSymbols();
        }

        private void GenerateSampleImage()
        {
            if (parentData.IsQuadraticSampleLib && parentData.quadraticSampleLib != null)
            {
                RImage img = new RImage(parentData.quadraticSampleLib.AllSymbols(), parentData.quadraticSampleLib);
                pbSamplePreview.Image = img.GetBitmap();
            }
        }
        private frmMain.frmMainData parentData;

        private void frmSamplesLibrary_Load(object sender, EventArgs e)
        {
            parentData = ((frmMain)Owner).Data;
            SetSampleLibFields(parentData.linearSampleLib);
            SetSampleLibFields(parentData.quadraticSampleLib);
            if (parentData.fontForSpaceNormalisation != null)
            {
                txSymbols.Font = parentData.fontForSpaceNormalisation;
                fontDialog.Font = parentData.fontForSpaceNormalisation;
            }
        }

        private void bnSelectFont_Click(object sender, EventArgs e)
        {
            if (parentData.fontForSpaceNormalisation != null)
                fontDialog.Font = parentData.fontForSpaceNormalisation;
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txSymbols.Font = fontDialog.Font;
                txHeightFont.Text = fontDialog.Font.Height.ToString();
            }
        }

        private void bnAddEnglish_Click(object sender, EventArgs e)
        {
            txSymbols.Text += @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',";
        }

        private void bnAddRussian_Click(object sender, EventArgs e)
        {
            txSymbols.Text += @"АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя',";
        }

        private void bnAddNumbers_Click(object sender, EventArgs e)
        {
            txSymbols.Text += "0123456789";
        }

        private void bnSaveSampleLib_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (parentData.IsQuadraticSampleLib)
                    {
                        var xsQuadratic =
                            new XmlSerializer(typeof(Logic.SamplesLibrary<Logic.QuadraticSample>));
                        using (Stream s = File.Create(saveFileDialog.FileName))
                            xsQuadratic.Serialize(s, parentData.quadraticSampleLib);
                        parentData.isQuadraticSampleLibSaved = true;
                    }
                    else
                    {
                        var xsLinear =
                            new XmlSerializer(typeof(Logic.SamplesLibrary<Logic.LinearSample>));
                        using (Stream s = File.Create(saveFileDialog.FileName))
                            xsLinear.Serialize(s, parentData.quadraticSampleLib);
                        parentData.isLinearSampleLibSaved = true;

                    }
                    parentData.LibraryFilename = saveFileDialog.FileName;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private void bnGenerateSamples_Click(object sender, EventArgs e)
        {
            if (!CheckForSaveWarning()) return;
            parentData.fontForSpaceNormalisation = fontDialog.Font;
            //clean repeating characters
            string alphabet = "";
            string input = txSymbols.Text + " ";
            foreach (char c in input)
            {
                if (alphabet.IndexOf(c) == -1) alphabet += c;
            }
            parentData.quadraticSampleLib =
            Logic.QuadraticSamplesServices.
                QSLibFromFont(parentData.fontForSpaceNormalisation, alphabet);
            parentData.IsQuadraticSampleLib = true;

            SetSampleLibFields(parentData.linearSampleLib);
            SetSampleLibFields(parentData.quadraticSampleLib);

        }

        private void txSymbols_TextChanged(object sender, EventArgs e)
        {
            if(txSymbols.Text.Contains(' '))
                txSamplesNumberFont.Text = txSymbols.TextLength.ToString();
            else
                txSamplesNumberFont.Text = (txSymbols.TextLength+1).ToString();
        }

        private bool CheckForSaveWarning()
        {
            if ((parentData.IsQuadraticSampleLib &&
                !parentData.isQuadraticSampleLibSaved) ||
                (!parentData.IsQuadraticSampleLib &&
                parentData.isLinearSampleLibSaved)) // Current sample lib unsaved
            {
                if (MessageBox.
                    Show(this, "Current unsaved sample library will be overwritten", "Warning",
                    MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) 
                    != System.Windows.Forms.DialogResult.OK)
                    return false;
            }
            return true;
        }
    }
}
