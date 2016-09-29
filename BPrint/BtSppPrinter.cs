using System;

using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.IO;

namespace WirelessPrintHelper
{
    public class BtSppPrinter : IDisposable, IWirelessPrinter
    {
        /// <summary>
        /// Gets current instance of SerialPort class
        /// </summary>
        public SerialPort SerialPort { get; private set; }

        /// <summary>
        /// Gets current port name
        /// </summary>
        public string CurrentPortName {get; private set;}

        /// <summary>
        /// Gets current Encoding
        /// </summary>
        public Encoding CurrentEncoding {get; private set;}

        /// <summary>
        /// Gets or Sets flag to persist connection
        /// </summary>
        public bool PersistConnection { get; set; }

        /// <summary>
        /// Instance of IFileReader
        /// </summary>
        private IFileContentReader fileReader;
        private IContentParameters parameters;
        private IContentReplacer replacer;

        public event EventHandler AfterPrint;

        protected virtual void OnAfterPrint(EventArgs e)
        {
            var handler = AfterPrint;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Inıtializes SerialPort property with new instance of SerialPort class with default connection settings.
        /// </summary>
        /// <param name="port">Port name e.g. COM8</param>
        private void InitSerialPort(string port)
        {
            if (SerialPort != null)
            {
                SerialPort = new SerialPort(port);
            }
        }

        /// <summary>
        /// Writes contents of toPrint to designated Port
        /// </summary>
        /// <param name="toPrint">Content to write</param>
        public void Print(byte[] toPrint)
        {
            if (toPrint == null)
                throw new ArgumentNullException("toPrint", "toPrint cannot be null");

            InitSerialPort(CurrentPortName);

            if (PersistConnection)
            {
                if (!SerialPort.IsOpen)
                    SerialPort.Open();

                SerialPort.Write(toPrint, 0, toPrint.Length);
            }
            else
            {
                if (!SerialPort.IsOpen)
                    SerialPort.Open();
                SerialPort.Write(toPrint, 0, toPrint.Length);
                SerialPort.Close();
            }
            
        }

        /// <summary>
        /// Writes replaced contents of toPrint to designated Port based on parameters>
        /// </summary>
        /// <param name="toPrint">Content to write</param>
        /// <param name="parameters">Replace parameters</param>
        public void Print(byte[] toPrint, IContentParameters parameters)
        {
            if (toPrint == null)
                throw new ArgumentNullException("toPrint", "toPrint cannot be null");
            if (parameters == null)
                throw new ArgumentNullException("parameters", "parameters cannot be null");

            IContentReplacer replacer = new ContentReplacer(parameters);

            var result = replacer.Replace(toPrint);

            if(result != null)
                Print(result);
        }

        /// <summary>
        /// Writes contents of toPrint with default encoding
        /// </summary>
        /// <param name="toPrint">Content to write</param>
        public void Print(string toPrint)
        {
            if (string.IsNullOrEmpty(toPrint))
                throw new ArgumentException("toPrint cannot be empty or null", "toPrint");
            Print(CurrentEncoding.GetBytes(toPrint));
        }

        /// <summary>
        /// Writes contents of toPrint to designated Port based on parameters
        /// </summary>
        /// <param name="toPrint"></param>
        /// <param name="parameters"></param>
        public void Print(string toPrint, IContentParameters parameters)
        {
            if (string.IsNullOrEmpty(toPrint))
                throw new ArgumentException("toPrint cannot be empty or null", "toPrint");
            
            if (parameters == null)
                throw new ArgumentNullException("parameters", "parameters cannot be null");


        }

        /// <summary>
        /// Initiliazies a new Instance
        /// </summary>
        /// <param name="reader">Content reader</param>
        /// <param name="parameters">Parameters</param>
        public BtSppPrinter(IFileContentReader reader, IContentParameters parameters)
        {
            this.fileReader = reader;
            this.parameters = parameters;
            this.replacer = new ContentReplacer(this.parameters);
        }

        /// <summary>
        /// Writes contents of toPrint to designated Port based on parameters
        /// </summary>
        /// <param name="filename">Payload path</param>
        /// <param name="fileEncoding">Read encoding</param>
        /// <param name="parameters">Parameters</param>
        public void Print(string filename, Encoding fileEncoding, IContentParameters parameters)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename cannot be empty or null", "filename");

            if (fileEncoding == null)
                throw new ArgumentNullException("encoding", "encoding cannot be null");

            if (parameters == null)
                throw new ArgumentNullException("parameters", "parameters cannot be null");

            this.CurrentEncoding = fileEncoding;

            var readedBytes = fileReader.ReadAllAsByte(filename);

            IContentReplacer replacer = new ContentReplacer(parameters);

            var result = replacer.Replace(readedBytes);

            if (result != null)
                Print(result);

        }

        public BtSppPrinter(string comPort)
        {
            this.CurrentPortName = comPort;
            this.PersistConnection = false;
        }

        /// <summary>
        /// Initializes a new Instance
        /// </summary>
        /// <param name="comPort">COM Port</param>
        /// <param name="filename">Payload path</param>
        /// <param name="fileEncoding">Payload Encoding</param>
        public BtSppPrinter(SerialPort comPort, string filename, Encoding fileEncoding)
        {
            if (comPort == null)
                throw new ArgumentNullException("comPort", "comPort cannot be null");

            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException("filename cannot be empty or null", "filename");

            if (fileEncoding == null)
                throw new ArgumentNullException("encoding", "encoding cannot be null");

            this.SerialPort = comPort;
            this.fileReader = new FileContentReader(filename);
            this.CurrentEncoding = fileEncoding;
            this.PersistConnection = false;
        }

        /// <summary>
        /// Initializes a new Instance
        /// </summary>
        /// <param name="comPort">COM Port</param>
        /// <param name="persistSerialConnection">Persist serialPort connection</param>
        public BtSppPrinter(string comPort, bool persistSerialConnection)
        {
            this.CurrentPortName = comPort;
            this.PersistConnection = persistSerialConnection;
        }

        public void Dispose()
        {
            if (PersistConnection)
                if (SerialPort.IsOpen)
                    SerialPort.Close();
            SerialPort.Dispose();

            /* GC.Collect(); may seem redundant at this point but sometimes 
             * even after SerialPort.Close() - same goes for Dispose() - is called you cannot re-open
             * same port for an unknown period of time.
             * It seems like sometimes SerialPort.Close() hasn't executed in OS.
             * Best workaround I found is to call GC.Collect(), which force serial port
             * to actually close.
             */
            GC.Collect();
        }

        public void Print(FileInfo payloadFile)
        {
            if (payloadFile == null)
                throw new ArgumentNullException("payloadFile", "payloadFile cannot be null");

            IFileContentReader reader = new FileContentReader(payloadFile.Name);

            Print(reader.ReadAllAsByte());
        }

        public void Print(FileInfo payloadFile, Encoding fileEncoding, IContentParameters parameters)
        {
            if (payloadFile == null)
                throw new ArgumentNullException("payloadFile", "payloadFile cannot be null");

            if (fileEncoding == null)
                throw new ArgumentNullException("encoding", "encoding cannot be null");

            if (parameters == null)
                throw new ArgumentNullException("parameters", "parameters cannot be null");

            this.CurrentEncoding = fileEncoding;

            IFileContentReader fileReader = new FileContentReader(payloadFile.Name);

            var readedBytes = fileReader.ReadAllAsByte();

            IContentReplacer replacer = new ContentReplacer(parameters, fileEncoding);

            var result = replacer.Replace(readedBytes);

            if (result != null)
                Print(result);
        }
    }
}
