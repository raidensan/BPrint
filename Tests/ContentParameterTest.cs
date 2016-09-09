using BPrint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for ContentParametersContentParameterTest and is intended
    ///to contain all ContentParametersContentParameterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContentParameterTest
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
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddIsAddParametersSuccessful()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("barcode", "8693332221117");

            ContentParameters target = new ContentParameters(); // TODO: Initialize to an appropriate value
            string paramName = "barcode"; // TODO: Initialize to an appropriate value
            string paramValue = "8693332221117"; // TODO: Initialize to an appropriate value
            target.Add(paramName, paramValue);
            Assert.AreEqual(dict, target.Parameters);
        }
    }
}
