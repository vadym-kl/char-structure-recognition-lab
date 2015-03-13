using str_recognition.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace LogicTestProject
{
    
    
    /// <summary>
    ///This is a test class for RImageTest and is intended
    ///to contain all RImageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RImageTest
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
        ///A test for RImage Constructor
        ///</summary>
        [TestMethod()]
        public void RImageConstructorTest()
        {
            int width = 100; // TODO: Initialize to an appropriate value
            int height = 10; // TODO: Initialize to an appropriate value
            RImage target = new RImage(width, height);
            Assert.IsTrue(true);
        }

        /// <summary>
        ///A test for Recognise
        ///</summary>
        [TestMethod()]
        public void SimpleRecogniseTest()
        {
            //define the simplest sample library
            var samplesLibrary = new SamplesLibrary<QuadraticSample>(1);
            QuadraticSample SampleC = new QuadraticSample(1, 1);
            SampleC[0][0] = 50;
            samplesLibrary.Add("c", SampleC);
            QuadraticSample SampleB = new QuadraticSample(2, 1);
            SampleB[0][0] = 100;
            SampleB[1][0] = 100;
            samplesLibrary.Add("b", SampleB);
            QuadraticSample SampleD = new QuadraticSample(1, 1);
            SampleD[0][0] = 150;
            samplesLibrary.Add("d", SampleD);
            QuadraticSample SampleE = new QuadraticSample(1, 1);
            SampleE[0][0] = 200;
            samplesLibrary.Add("e", SampleE);
            //llet's create image based on it
            string expected = "ccbede";
            RImage target = new RImage(expected, samplesLibrary); // create an "ccbede" image
            target.AddGaussianNoise(10);//add some small noise
            string actual = "ccbede";
            long Fine = 0;
            actual = target.Recognise(samplesLibrary,out Fine);
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        ///A test for Recognise
        ///</summary>
        [TestMethod()]
        public void RImageBitmapGeneratingTest()
        {
            //define the simplest sample library
            var samplesLibrary = new SamplesLibrary<QuadraticSample>(1);
            QuadraticSample SampleC = new QuadraticSample(1, 1);
            SampleC[0][0] = 50;
            samplesLibrary.Add("c", SampleC);
            QuadraticSample SampleB = new QuadraticSample(2, 1);
            SampleB[0][0] = 100;
            SampleB[1][0] = 100;
            samplesLibrary.Add("b", SampleB);
            QuadraticSample SampleD = new QuadraticSample(1, 1);
            SampleD[0][0] = 150;
            samplesLibrary.Add("d", SampleD);
            QuadraticSample SampleE = new QuadraticSample(1, 1);
            SampleE[0][0] = 200;
            samplesLibrary.Add("e", SampleE);
            //llet's create image based on it
            string expected = "ccbede";
            RImage target = new RImage(expected, samplesLibrary); // create an "ccbede" image
            target.AddGaussianNoise(10);//add some small noise
            target.GetBitmap().Save("ccbede.png");
        }

        /// <summary>
        ///A test for RImage Constructor
        ///</summary>
        /*[TestMethod()]
        public void RImageConstructorTest1()
        {
            Bitmap bitmap = null; // TODO: Initialize to an appropriate value
            RImage target = new RImage(bitmap);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }*/

        /// <summary>
        ///A test for RImage Constructor
        ///</summary>
        /*[TestMethod()]
        public void RImageConstructorTest2()
        {
            Bitmap bitmap = null; // TODO: Initialize to an appropriate value
            int width = 0; // TODO: Initialize to an appropriate value
            int height = 0; // TODO: Initialize to an appropriate value
            int startx = 0; // TODO: Initialize to an appropriate value
            int starty = 0; // TODO: Initialize to an appropriate value
            RImage target = new RImage(bitmap, width, height, startx, starty);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }*/
    }
}
