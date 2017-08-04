using WirelessPrintHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for ContentParametersTest and is intended
    ///to contain all ContentParametersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContentParametersTest
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
        ///A test for Parameters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WirelessPrintHelper.dll")]
        public void ParametersTest()
        {
            ContentParameters_Accessor target = new ContentParameters_Accessor(); // TODO: Initialize to an appropriate value
            Dictionary<string, string> expected = new Dictionary<string,string>(); // TODO: Initialize to an appropriate value
            expected.Add("<barcode>", "8693332221117");
            expected.Add("<name>", "plu1");
            Dictionary<string, string> actual;
            target.Parameters = expected;
            actual = target.Parameters;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            ContentParameters target = new ContentParameters(); // TODO: Initialize to an appropriate value
            string paramName = string.Empty; // TODO: Initialize to an appropriate value
            string paramValue = string.Empty; // TODO: Initialize to an appropriate value
            target.Add(paramName, paramValue);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ContentParameters Constructor
        ///</summary>
        [TestMethod()]
        public void ContentParametersConstructorTest1()
        {
            ContentParameters target = new ContentParameters();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ContentParameters Constructor
        ///</summary>
        [TestMethod()]
        public void ContentParametersConstructorTest()
        {
            Dictionary<string, string> paramDictionary = null; // TODO: Initialize to an appropriate value
            ContentParameters target = new ContentParameters(paramDictionary);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
