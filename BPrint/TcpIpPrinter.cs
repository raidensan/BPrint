using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WirelessPrintHelper
{
    public class TcpIpPrinter : IWirelessPrinter
    {
        public event EventHandler AfterPrint;

        protected virtual void OnAfterPrint(EventArgs e)
        {
            var handler = AfterPrint;
            if(handler!=null)
                handler(this,e);
        }

        public IPEndPoint IPEndPoint { get; set; }

        public Encoding CurrentEncoding { get; private set; }

        public Socket Socket { get; private set; }

        public TcpIpPrinter(string ip, int port)
        {
            if (string.IsNullOrEmpty(ip))
                throw new ArgumentException("ip cannot be null or empty string", "ip");

            this.IPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.PersistConnection = false;
            this.CurrentEncoding = Encoding.UTF8;
        }

        public void Dispose()
        {
            GC.Collect();
        }

        public bool PersistConnection { get; set; }

        public void Print(string toPrint, IContentParameters parameters)
        {
            IContentReplacer replacer = new ContentReplacer(parameters);

            Print(replacer.Replace(CurrentEncoding.GetBytes(toPrint)));
        }

        public void Print(FileInfo filename, Encoding fileEncoding, IContentParameters parameters)
        {
            if (filename == null)
                throw new ArgumentNullException("filename cannot be null", "filename");

            if (fileEncoding == null)
                throw new ArgumentNullException("encoding", "encoding cannot be null");

            if (parameters == null)
                throw new ArgumentNullException("parameters", "parameters cannot be null");

            this.CurrentEncoding = fileEncoding;

            IFileContentReader fileReader = new FileContentReader(filename.Name);

            var readedBytes = fileReader.ReadAllAsByte();

            IContentReplacer replacer = new ContentReplacer(parameters,fileEncoding);

            var result = replacer.Replace(readedBytes);

            if (result != null)
                Print(result);
        }

        public void Print(string toPrint)
        {
            Print(CurrentEncoding.GetBytes(toPrint));
        }

        public void Print(byte[] toPrint)
        {
            if (toPrint == null)
                throw new ArgumentNullException("toPrint", "toPrint cannot be null");

            if (!PersistConnection)
                Socket.Connect(IPEndPoint);

            Socket.Send(toPrint);

            if (!PersistConnection)
                Socket.Close();
        }

        public void Print(byte[] toPrint, IContentParameters parameters)
        {
            if (toPrint == null)
                throw new ArgumentNullException("toPrint", "toPrint cannot be null");
            if (parameters == null)
                throw new ArgumentNullException("parameters", "parameters cannot be null");

            IContentReplacer replacer = new ContentReplacer(parameters);

            var result = replacer.Replace(toPrint);

            if (result != null)
                Print(result);
        }

        public void Print(FileInfo payloadFile)
        {
            if (payloadFile == null)
                throw new ArgumentNullException("payloadFile", "payloadFile cannont be null");

            IFileContentReader reader = new FileContentReader(payloadFile.Name);

            Print(reader.ReadAllAsByte());
        }
    }
}
