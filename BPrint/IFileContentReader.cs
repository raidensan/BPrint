using System;
namespace WirelessPrintHelper
{
    public interface IFileContentReader
    {
        string Filename { get; }
        byte[] ReadAllAsByte();
        byte[] ReadAllAsByte(string fileName);
        string ReadAllAsString();
        string ReadAllAsString(string fileName);
    }
}
