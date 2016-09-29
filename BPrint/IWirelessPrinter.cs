using System;
using System.Text;
using System.IO;
namespace WirelessPrintHelper
{
    public interface IWirelessPrinter : IDisposable
    {
        event EventHandler AfterPrint;
        Encoding CurrentEncoding { get; }
        bool PersistConnection { get; set; }
        void Print(string toPrint);
        void Print(string toPrint, IContentParameters parameters);
        void Print(byte[] toPrint);
        void Print(byte[] toPrint, IContentParameters parameters);
        void Print(FileInfo payloadFile);
        void Print(FileInfo payloadFile, Encoding fileEncoding, IContentParameters parameters);
    }
}
