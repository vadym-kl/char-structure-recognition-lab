using str_recognition.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace LogicTestProject
{
    
    
    /// <summary>
    ///This is a test class for LinearSampleTest and is intended
    ///to contain all LinearSampleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LinearSampleTest
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
            LinearSample target = new LinearSample(width, height); // TODO: Initialize to an appropriate value
            int columnIndex = 0; // TODO: Initialize to an appropriate value
            uint ParamNumber = 0; // TODO: Initialize to an appropriate value
            RColumn expected = null; // TODO: Initialize to an appropriate value
            RColumn actual;
            target[columnIndex, ParamNumber] = expected;
            actual = target[columnIndex, ParamNumber];
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
            LinearSample target = new LinearSample(width, height); // TODO: Initialize to an appropriate value
            int sampleColumnNumber = 0; // TODO: Initialize to an appropriate value
            RColumn column = null; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.Fine(sampleColumnNumber, column);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }*/

        /// <summary>
        ///A test for LinearSample Constructor
        ///</summary>
        [TestMethod()]
        public void LinearSampleConstructorTest()
        {
            int width = 100; // TODO: Initialize to an appropriate value
            int height = 10; // TODO: Initialize to an appropriate value
            LinearSample target = new LinearSample(width, height);
            Assert.IsTrue(true);
        }
        /// <summary>
        /// A test for XML serialisation of LinearSample
        /// </summary>
        [TestMethod()]
        public void LinearSampleXmlTest()
        {
            LinearSample target = new LinearSample(2, 1);
            target[0,0][0] = 25;
            target[0, 1][0] = 50;
            target[1, 0][0] = 30;
            target[1, 1][0] = 60;
            XmlSerializer xs = new XmlSerializer(typeof(LinearSample));
            using (Stream s = File.Create("LinearSample.xml"))
                xs.Serialize(s, target);
            LinearSample result;
            using (Stream s = File.OpenRead("LinearSample.xml"))
                result = (LinearSample)xs.Deserialize(s);
            Assert.AreEqual(result.Width, target.Width);
            Assert.AreEqual(result.Height, target.Height);
            Assert.AreEqual<LinearSample>(target, result);
        }
    }
}
