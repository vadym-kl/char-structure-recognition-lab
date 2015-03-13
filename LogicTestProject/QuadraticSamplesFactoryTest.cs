using str_recognition.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using str_recognition.ImageProcessing;
using System.Text;

namespace LogicTestProject
{
    
    
    /// <summary>
    ///This is a test class for QuadraticSamplesFactoryTest and is intended
    ///to contain all QuadraticSamplesFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QuadraticSamplesFactoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ceates a set of samples from a given font, then creates
        ///a test image using SampleLibrary building method, adds noise 
        ///to it and tries to recognise it
        ///it the source string and the result of recognition are equal 
        ///the test counts as passed
        ///</summary>
        [TestMethod()]
        public void RecognitionFromFontTestArial36()
        {
            Font font =  new Font("Arial", 36);
            string Alphabet = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$1234567890 ";
            var FontQuadraticSampleLibrary = QuadraticSamplesServices.QSLibFromFont(font, Alphabet);
            RImage img = new RImage(Alphabet, FontQuadraticSampleLibrary);
            Bitmap bmp = img.GetBitmap();
            bmp.Save("SampleStringArial36.png");
            img.AddGaussianNoise(100);
            Bitmap bmpNoise = img.GetBitmap();
            bmpNoise.Save("SampleStringWithNoiseArial36.png");
            string resultString = img.Recognise(FontQuadraticSampleLibrary);
            Assert.AreEqual(System.Text.RegularExpressions.Regex.Replace(resultString, @"\s+", " "), Alphabet);
        }
        /// <summary>
        ///Ceates a set of samples from a given font, then creates
        ///a test image using standart GDI+ procedure, adds noise to it 
        ///and tries to recognise it
        ///it the source string and the result of recognition are equal 
        ///the test counts as passed
        ///</summary>
        [TestMethod()]
        public void RecognitionFromFontTestArial48()
        {
            Font font = new Font("Arial",48);
            string Alphabet = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$1234567890', ";
            string TestString = "The Comedy of Errors is one of William Shakespeare's earliest plays, believed to have been written between 1592 and 1594";
            var FontQuadraticSampleLibrary = QuadraticSamplesServices.QSLibFromFont(font, Alphabet);

            Bitmap bm = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bm);
            StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
            sf.Trimming = StringTrimming.None;
            SizeF sz = g.MeasureString(TestString, font, new PointF(0, 0), sf);
            g.Dispose();
            Bitmap sampleBitmap = new Bitmap((int)sz.Width, font.Height);
            Graphics gs = Graphics.FromImage(sampleBitmap);
            gs.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)sz.Width, font.Height);
            gs.DrawString(TestString, font, new SolidBrush(Color.Black), new PointF(0, 0), sf);
            gs.Dispose();
            RImage img = new RImage(sampleBitmap);
            sampleBitmap.Save("SampleStringArial48.png");
            img.AddGaussianNoise(50);
            Bitmap bmpNoise = img.GetBitmap();
            bmpNoise.Save("SampleStringWithNoiseArial48.png");
            string resultString = img.Recognise(FontQuadraticSampleLibrary);
            //no we should clean whitespaces
            string res = QuadraticSamplesServices.AdditionalSpacesRemover(font, resultString);
            Assert.AreEqual(res, TestString);
        }
        /// <summary>
        ///Ceates a set of samples from a given font, then creates
        ///a test image using standart GDI+ procedure, adds noise to it 
        ///and tries to recognise it
        ///it the source string and the result of recognition are equal 
        ///the test counts as passed
        ///</summary>
        [TestMethod()]
        public void RecognitionFromFontTestArial12()
        {
            Font font = new Font("Arial", 12);
            string Alphabet = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$1234567890', ";
            string TestString = "The Comedy of Errors is one of William Shakespeare's earliest plays, believed to have been written between 1592 and 1594";
            var FontQuadraticSampleLibrary = QuadraticSamplesServices.QSLibFromFont(font, Alphabet);

            Bitmap bm = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bm);
            StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
            sf.Trimming = StringTrimming.None;
            SizeF sz = g.MeasureString(TestString, font, new PointF(0, 0), sf);
            g.Dispose();
            Bitmap sampleBitmap = new Bitmap((int)sz.Width, font.Height);
            Graphics gs = Graphics.FromImage(sampleBitmap);
            gs.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)sz.Width, font.Height);
            gs.DrawString(TestString, font, new SolidBrush(Color.Black), new PointF(0, 0), sf);
            gs.Dispose();
            RImage img = new RImage(sampleBitmap);
            sampleBitmap.Save("SampleStringArial12.png");
            img.AddGaussianNoise(30);
            Bitmap bmpNoise = img.GetBitmap();
            bmpNoise.Save("SampleStringWithNoiseArial12.png");
            string resultString = img.Recognise(FontQuadraticSampleLibrary);
            //no we should clean whitespaces
            string res = QuadraticSamplesServices.AdditionalSpacesRemover(font, resultString);
            
            Assert.AreEqual(res, TestString);
        }
        /// <summary>
        ///Ceates a set of samples from a given font, then creates
        ///a test image with white margins using standart GDI+ procedure,
        ///adds noise to it and tries to recognise it
        ///if the shift of source and the shift value returned by recognition program are equal
        ///the test counts as passed
        ///</summary>
        [TestMethod()]
        public void RecognitionFromFontTest_Arial12_Shifted()
        {
            Font font = new Font("Arial", 12);
            string Alphabet = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$1234567890', ";
            string TestString = "The Comedy of Errors is one of William Shakespeare's earliest plays, believed to have been written between 1592 and 1594";
            var FontQuadraticSampleLibrary = QuadraticSamplesServices.QSLibFromFont(font, Alphabet);
            //Draws test string with additional white margins
            int x0 = 10;
            int y0 = 5;
            int xmargin = 10;
            int ymargin = 5;
            Bitmap bm = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bm);
            StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
            sf.Trimming = StringTrimming.None;
            SizeF sz = g.MeasureString(TestString, font, new PointF(0, 0), sf);
            g.Dispose();
            Bitmap sampleBitmap = new Bitmap((int)sz.Width + x0 + xmargin,
                font.Height + y0 + ymargin);
            Graphics gs = Graphics.FromImage(sampleBitmap);
            gs.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)sz.Width + x0 + xmargin,
                font.Height + y0 + ymargin);
            gs.DrawString(TestString, font, new SolidBrush(Color.Black), new PointF(x0, y0), sf);
            gs.Dispose();
            //saving images to files
            sampleBitmap.Save("SampleStringArial12+Margins.png");
            ImageUtility.AddGreyscaleGaussianNoise(100, sampleBitmap);
            sampleBitmap.Save("SampleStringArial12+Margins+Noise.png");
            long yshift=0;
            string resultString =
                QuadraticSamplesServices.RecogniseBitmap(font, Alphabet, sampleBitmap, out yshift);
            //Assert.AreEqual(resultString, TestString);
            StreamWriter sq = new StreamWriter("results.txt");
            sq.WriteLine(TestString);
            sq.WriteLine(resultString);
            sq.Close();
            sq.Dispose();
            Assert.AreEqual(y0, yshift);
        }

        /// <summary>
        /// Creates a library from font and English alphabet
        /// then saves it and loads to memory from file
        /// </summary>
        [TestMethod()]
        public void StorageOfLibraryFromFontTestArial12()
        {
            Font font = new Font("Arial", 12);
            string Alphabet = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#$1234567890', ";
            var samplesLibrary=QuadraticSamplesServices.QSLibFromFont(font, Alphabet);
            XmlSerializer xs = new XmlSerializer(typeof(SamplesLibrary<QuadraticSample>));
            using (Stream s = File.Create("QuadraticSampleLib.xml"))
                xs.Serialize(s, samplesLibrary);
            SamplesLibrary<QuadraticSample> result;
            using (Stream s = File.OpenRead("QuadraticSampleLib.xml"))
                result = (SamplesLibrary<QuadraticSample>)xs.Deserialize(s);
            Assert.AreEqual<SamplesLibrary<QuadraticSample>>(samplesLibrary, result);
        }
    }
}
