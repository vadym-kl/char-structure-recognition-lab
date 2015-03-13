using str_recognition.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Serialization;
using System.IO;

namespace LogicTestProject
{
    
    
    /// <summary>
    ///This is a test class for SamplesLibraryTest and is intended
    ///to contain all SamplesLibraryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SamplesLibraryTest
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

        [TestMethod()]
        public void StringWidthInColumnsTest()
        {
            var samplesLibrary = new SamplesLibrary<QuadraticSample>(1);
            QuadraticSample SampleC = new QuadraticSample(1, 1);
            SampleC[0][0] = 50;
            samplesLibrary.Add("c", SampleC);
            QuadraticSample SampleB = new QuadraticSample(2, 1);
            SampleB[0][0] = 100;
            samplesLibrary.Add("b", SampleB);
            QuadraticSample SampleD = new QuadraticSample(1, 1);
            SampleD[0][0] = 150;
            samplesLibrary.Add("d", SampleD);
            QuadraticSample SampleE = new QuadraticSample(1, 1);
            SampleE[0][0] = 200;
            samplesLibrary.Add("e", SampleE);
            int width = samplesLibrary.StringWidthInColumns("cbb");
            Assert.AreEqual(5, width);
        }

        [TestMethod()]
        public void SamplesLibraryXmlSerialisation()
        {
            var samplesLibrary = new SamplesLibrary<QuadraticSample>(1);
            QuadraticSample SampleC = new QuadraticSample(1, 1);
            SampleC[0][0] = 50;
            samplesLibrary.Add("c", SampleC);
            QuadraticSample SampleB = new QuadraticSample(2, 1);
            SampleB[0][0] = 100;
            samplesLibrary.Add("b", SampleB);
            QuadraticSample SampleD = new QuadraticSample(1, 1);
            SampleD[0][0] = 150;
            samplesLibrary.Add("d", SampleD);
            QuadraticSample SampleE = new QuadraticSample(1, 1);
            SampleE[0][0] = 200;
            samplesLibrary.Add("e", SampleE);
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
