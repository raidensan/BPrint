using WirelessPrintHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for FileContentReaderContentParameterTest and is intended
    ///to contain all FileContentReaderContentParameterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FileContentReaderContentParameterTest
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
        ///A test for ReadBuffer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WirelessPrintHelper.dll")]
        public void ReadBufferIsAddParametersSuccessful()
        {
            FileContentReader_Accessor target = new FileContentReader_Accessor(); // TODO: Initialize to an appropriate value
            int expected = 1024; // TODO: Initialize to an appropriate value
            int actual;
            target.ReadBuffer = expected;
            actual = target.ReadBuffer;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Filename
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WirelessPrintHelper.dll")]
        public void FilenameIsAddParametersSuccessful()
        {
            FileContentReader_Accessor target = new FileContentReader_Accessor(); // TODO: Initialize to an appropriate value
            string expected = @"benetton.CSV"; // TODO: Initialize to an appropriate value
            string actual;
            target.Filename = expected;
            actual = target.Filename;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ReadAllAsString
        ///</summary>
        [TestMethod()]
        public void ReadAllAsStringIsAddParametersSuccessful()
        {
            FileContentReader target = new FileContentReader(); // TODO: Initialize to an appropriate value
            string fileName = @"mini_benetton.CSV"; // TODO: Initialize to an appropriate value
            string expected = new StreamReader(fileName).ReadToEnd(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ReadAllAsString(fileName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ReadAllAsByte
        ///</summary>
        [TestMethod()]
        public void ReadAllAsByteIsAddParametersSuccessful()
        {
            FileContentReader target = new FileContentReader(); // TODO: Initialize to an appropriate value
            string fileName = @"mini_benetton.CSV"; // TODO: Initialize to an appropriate value
            string readed = string.Empty;
            MemoryStream ms = new MemoryStream();
            byte[] buff = new byte[1024];

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                while (true)
                {
                    int len = fs.Read(buff, 0, buff.Length);
                    if (len > 0)
                    {
                        ms.Write(buff, 0, len);
                    }

                    if (len < buff.Length)
                        break;
                }
            }
            byte[] expected = ms.ToArray(); // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.ReadAllAsByte(fileName);
            CollectionAssert.AreEqual(actual, expected);
        }

        /// <summary>
        ///A test for FileContentReader Constructor
        ///</summary>
        [TestMethod()]
        public void FileContentReaderConstructorIsAddParametersSuccessful2()
        {
            FileContentReader target = new FileContentReader();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for FileContentReader Constructor
        ///</summary>
        [TestMethod()]
        public void FileContentReaderConstructorIsAddParametersSuccessful1()
        {
            string payloadFilename = string.Empty; // TODO: Initialize to an appropriate value
            FileContentReader target = new FileContentReader(payloadFilename);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for FileContentReader Constructor
        ///</summary>
        [TestMethod()]
        public void FileContentReaderConstructorIsAddParametersSuccessful()
        {
            string payloadFilename = string.Empty; // TODO: Initialize to an appropriate value
            int readBuffer = 0; // TODO: Initialize to an appropriate value
            FileContentReader target = new FileContentReader(payloadFilename, readBuffer);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
