using System;

using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WirelessPrintHelper
{
    /// <summary>
    /// Used to read contents of a file
    /// </summary>
    public class FileContentReader : IFileContentReader
    {
        /// <summary>
        /// Full path of file
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// Gets size of read buffer
        /// </summary>
        public int ReadBuffer { get; private set; }

        public FileContentReader()
        {
            this.ReadBuffer = 1024;
        }

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="payloadFilename">Full path of file</param>
        public FileContentReader(string payloadFilename)
        {
            this.Filename = payloadFilename;
        }

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="payloadFilename">Full path of file</param>
        /// <param name="readBuffer">Size of read buffer</param>
        public FileContentReader(string payloadFilename, int readBuffer)
        {
            this.Filename = payloadFilename;
            this.ReadBuffer = readBuffer;
        }

        /// <summary>
        /// Return all content of file as string
        /// </summary>
        /// <param name="fileName">Full path of file</param>
        /// <returns>All content of file as string</returns>
        public string ReadAllAsString(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// Returns all content of file as byte[]
        /// </summary>
        /// <param name="fileName">Full file path</param>
        /// <returns>All content of file as byte[]</returns>
        public byte[] ReadAllAsByte(string fileName)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buff = new byte[ReadBuffer];
            
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

            ms.Flush();

            byte[] allBytes = ms.ToArray();

            ms.Close();

            return allBytes;
        }

        public byte[] ReadAllAsByte()
        {
            return ReadAllAsByte(Filename);
        }

        public string ReadAllAsString()
        {
            return ReadAllAsString(Filename);
        }
    }
}
