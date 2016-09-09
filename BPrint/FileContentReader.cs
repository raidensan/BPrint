using System;

using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BPrint
{
    public class FileContentReader : IFileContentReader
    {
        public string Filename { get; private set; }
        public int ReadBuffer { get; private set; }
        public FileContentReader(string payloadFilename)
        {
            this.Filename = payloadFilename;
        }

        public FileContentReader(string payloadFilename, int readBuffer)
        {
            this.Filename = payloadFilename;
            this.ReadBuffer = readBuffer;
        }

        public string ReadAllAsString(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public byte[] ReadAllAsByte(string fileName)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buff = new byte[2048];

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
            byte[] allBytes = ms.ToArray();
            return allBytes;
        }
    }
}
