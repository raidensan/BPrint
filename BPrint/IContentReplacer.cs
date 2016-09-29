using System;
namespace WirelessPrintHelper
{
    public interface IContentReplacer
    {
        IContentParameters ContentParameters { get; }
        System.Text.Encoding Encoding { get; }
        byte[] Replace(byte[] source, IContentParameters contentParameters);
        byte[] Replace(byte[] source);
    }
}
