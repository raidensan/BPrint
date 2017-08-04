using WirelessPrintHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for ContentReplacerTest and is intended
    ///to contain all ContentReplacerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContentReplacerTest
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
        ///A test for Encoding
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WirelessPrintHelper.dll")]
        public void EncodingTest()
        {
            ContentReplacer_Accessor target = new ContentReplacer_Accessor(); // TODO: Initialize to an appropriate value
            Encoding expected = Encoding.UTF8; // TODO: Initialize to an appropriate value
            Encoding actual;
            target.Encoding = expected;
            actual = target.Encoding;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContentParameters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WirelessPrintHelper.dll")]
        public void ContentParametersTest()
        {
            ContentReplacer_Accessor target = new ContentReplacer_Accessor(); // TODO: Initialize to an appropriate value
            var param = new Dictionary<string, string>();
            param.Add("<barcode>", "8693332221117");
            param.Add("<name>", "plu1");
            IContentParameters expected = new ContentParameters(); // TODO: Initialize to an appropriate value
            IContentParameters actual;
            target.ContentParameters = expected;
            actual = target.ContentParameters;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ReplaceFirstOccurance
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WirelessPrintHelper.dll")]
        public void ReplaceFirstOccuranceTest()
        {
            IFileContentReader fileReader = new Fake_FileContentReader();

            ContentReplacer_Accessor target = new ContentReplacer_Accessor(); // TODO: Initialize to an appropriate value
            byte[] oldContent = fileReader.ReadAllAsByte(); // TODO: Initialize to an appropriate value
            string toBeChanged = "<barcode>"; // TODO: Initialize to an appropriate value
            string newValue = "8695556664448"; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.ReplaceFirstOccurance(oldContent, toBeChanged, newValue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Replace
        ///</summary>
        [TestMethod()]
        public void ReplaceTest1()
        {
            ContentReplacer target = new ContentReplacer(); // TODO: Initialize to an appropriate value
            byte[] source = null; // TODO: Initialize to an appropriate value
            IContentParameters contentParameters = null; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.Replace(source, contentParameters);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Replace
        ///</summary>
        [TestMethod()]
        public void ReplaceTest()
        {
            ContentReplacer target = new ContentReplacer(); // TODO: Initialize to an appropriate value
            byte[] source = null; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.Replace(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsMatch
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WirelessPrintHelper.dll")]
        public void IsMatchTest()
        {
            ContentReplacer_Accessor target = new ContentReplacer_Accessor(); // TODO: Initialize to an appropriate value
            byte[] content = null; // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            byte[] bytesToBeSearched = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsMatch(content, index, bytesToBeSearched);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IndexOf
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WirelessPrintHelper.dll")]
        public void IndexOfTest()
        {
            ContentReplacer_Accessor target = new ContentReplacer_Accessor(); // TODO: Initialize to an appropriate value
            byte[] content = null; // TODO: Initialize to an appropriate value
            byte[] bytesToBeSearched = null; // TODO: Initialize to an appropriate value
            int startIndex = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.IndexOf(content, bytesToBeSearched, startIndex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContentReplacer Constructor
        ///</summary>
        [TestMethod()]
        public void ContentReplacerConstructorTest2()
        {
            ContentReplacer target = new ContentReplacer();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ContentReplacer Constructor
        ///</summary>
        [TestMethod()]
        public void ContentReplacerConstructorTest1()
        {
            IContentParameters contentParameters = null; // TODO: Initialize to an appropriate value
            ContentReplacer target = new ContentReplacer(contentParameters);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ContentReplacer Constructor
        ///</summary>
        [TestMethod()]
        public void ContentReplacerConstructorTest()
        {
            IContentParameters contentParameters = null; // TODO: Initialize to an appropriate value
            Encoding encoding = null; // TODO: Initialize to an appropriate value
            ContentReplacer target = new ContentReplacer(contentParameters, encoding);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}

