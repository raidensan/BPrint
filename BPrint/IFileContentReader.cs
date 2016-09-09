using System;
namespace BPrint
{
    interface IFileContentReader
    {
        string Filename { get; }
        byte[] ReadAllAsByte(string fileName);
        string ReadAllAsString(string fileName);
    }
}
