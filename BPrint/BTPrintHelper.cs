using System;

using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace BPrint
{
    public class BTPrintHelper : IDisposable
    {
        private string port;
        private Encoding encoding;
        private IFileContentReader fileReader;
        public SerialPort SerialPort { get; private set;}
        public void Print(byte[] toPrint)
        {
            if (toPrint == null)
                throw new ArgumentNullException("toPrint", "toPrint cannot be null");

            InitSerialPort(port);

            SerialPort.Open();

            SerialPort.Write(toPrint, 0, toPrint.Length);
            
            SerialPort.Close();

            /* GC.Collect(); may seem redundant at this point but sometimes 
             * even after SerialPort.Close() - same goes for Dispose() - is called you cannot re-open
             * same port for a unknown period.
             * It seems like sometimes SerialPort.Close() hasn't executed in OS.
             * Best workaround I found is to call GC.Collect(), which force serial port
             * to actually close.
             */
            GC.Collect();

        }

        private void InitSerialPort(string port)
        {
            if (SerialPort != null)
            {
                SerialPort = new SerialPort(port);
            }
        }

        public void Print(string toPrint)
        {
            if (string.IsNullOrEmpty(toPrint))
                throw new ArgumentException("toPrint cannot be empty or null", "toPrint");
            Print(encoding.GetBytes(toPrint));
        }

        public void Print(string filename, Encoding fileEncoding)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename cannot be empty or null", "filename");

            if (fileEncoding == null)
                throw new ArgumentNullException("encoding", "encoding cannot be null");

            this.encoding = fileEncoding;

            var readedBytes = fileReader.ReadAllAsByte(filename);
            if (readedBytes != null)
                Print(readedBytes);

        }

        public BTPrintHelper(string comPort, string filename, Encoding fileEncoding)
        {
            this.port = comPort;
            this.encoding = fileEncoding;
            this.fileReader = new FileContentReader(filename);
        }

        public BTPrintHelper(SerialPort comPort, string filename, Encoding fileEncoding)
        {
            if (comPort == null)
                throw new ArgumentNullException("comPort", "comPort cannot be null");

            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename cannot be empty or null", "filename");

            if (fileEncoding == null)
                throw new ArgumentNullException("encoding", "encoding cannot be null");

            this.SerialPort = comPort;
            this.fileReader = new FileContentReader(filename);
            this.encoding = fileEncoding;
        }

        public void Dispose()
        {
            SerialPort.Dispose();
            throw new NotImplementedException();
        }

    }
}
