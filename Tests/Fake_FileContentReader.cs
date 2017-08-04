using System;

using System.Collections.Generic;
using System.Text;
using WirelessPrintHelper;

namespace Tests
{
    public class Fake_FileContentReader:IFileContentReader
    {
        #region IFileContentReader Members
        private string fileContents = "T 1 23 <barcode>\r\nT 0 53 <name>";
        private string filename;
        public string Filename
        {
            get { return this.filename; }
        }

        public Fake_FileContentReader()
        {
            this.filename = "fake_filename";
        }

        public byte[] ReadAllAsByte()
        {
            return Encoding.UTF8.GetBytes(this.fileContents);
        }

        public byte[] ReadAllAsByte(string fileName)
        {
            return ReadAllAsByte();
        }

        public string ReadAllAsString()
        {
            return this.fileContents;
        }

        public string ReadAllAsString(string fileName)
        {
            return ReadAllAsString();
        }

        #endregion
    }
}
