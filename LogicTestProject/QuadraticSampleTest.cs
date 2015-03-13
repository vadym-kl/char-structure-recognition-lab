using str_recognition.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace LogicTestProject
{
    
    
    /// <summary>
    ///This is a test class for QuadraticSampleTest and is intended
    ///to contain all QuadraticSampleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QuadraticSampleTest
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
        ///A test for Item
        ///</summary>
        /*[TestMethod()]
        public void ItemTest()
        {
            int width = 0; // TODO: Initialize to an appropriate value
            int height = 0; // TODO: Initialize to an appropriate value
            QuadraticSample target = new QuadraticSample(width, height); // TODO: Initialize to an appropriate value
            int columnIndex = 0; // TODO: Initialize to an appropriate value
            RColumn expected = null; // TODO: Initialize to an appropriate value
            RColumn actual;
            target[columnIndex] = expected;
            actual = target[columnIndex];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }*/

        /// <summary>
        ///A test for Fine
        ///</summary>
        /*[TestMethod()]
        public void FineTest()
        {
            int width = 0; // TODO: Initialize to an appropriate value
            int height = 0; // TODO: Initialize to an appropriate value
            QuadraticSample target = new QuadraticSample(width, height); // TODO: Initialize to an appropriate value
            int sampleColumnNumber = 0; // TODO: Initialize to an appropriate value
            RColumn column = null; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.Fine(sampleColumnNumber, column);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }*/

        /// <summary>
        ///A test for QuadraticSample Constructor
        ///</summary>
        [TestMethod()]
        public void QuadraticSampleConstructorTest()
        {
            int width = 100; // TODO: Initialize to an appropriate value
            int height = 10; // TODO: Initialize to an appropriate value
            QuadraticSample target = new QuadraticSample(width, height);
            Assert.IsTrue(true);
        }

        /// <summary>
        ///A test for QuadraticSample Constructor
        ///</summary>
        /*[TestMethod()]
        public void QuadraticSampleConstructorTest1()
        {
            Bitmap bitmap = null; // TODO: Initialize to an appropriate value
            int width = 0; // TODO: Initialize to an appropriate value
            int height = 0; // TODO: Initialize to an appropriate value
            int startx = 0; // TODO: Initialize to an appropriate value
            int starty = 0; // TODO: Initialize to an appropriate value
            QuadraticSample target = new QuadraticSample(bitmap, width, height, startx, starty);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }*/

        /// <summary>
        ///A test for Xml Serialisation / Deserialisation
        ///</summary>
        [TestMethod()]
        public void QuadraticSampleXmlTest()
        {
            QuadraticSample target = new QuadraticSample(1, 1); 
            target[0][0] = 25;
            XmlSerializer xs = new XmlSerializer(typeof(QuadraticSample));
            using (Stream s = File.Create("QuadraticSample.xml"))
                xs.Serialize(s, target);
            QuadraticSample result;
            using (Stream s = File.OpenRead("QuadraticSample.xml"))
                result = (QuadraticSample)xs.Deserialize(s);
            Assert.AreEqual(result.Width, target.Width);
            Assert.AreEqual(result.Height, target.Height);
            Assert.AreEqual<QuadraticSample>(target, result);
        }


    }
}
