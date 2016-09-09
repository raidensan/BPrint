using System;
namespace BPrint
{
    public interface IContentParameters
    {
        void Add(string paramName, string paramValue);
        System.Collections.Generic.Dictionary<string, string> Parameters { get; }
    }
}
