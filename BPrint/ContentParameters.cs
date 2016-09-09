using System;

using System.Collections.Generic;
using System.Text;

namespace BPrint
{
    public class ContentParameters : BPrint.IContentParameters
    {
        public Dictionary<string, string> Parameters { get; private set; }

        public ContentParameters()
        {
            Parameters = new Dictionary<string, string>();
        }

        public ContentParameters(Dictionary<string, string> paramDictionary)
        {
            if (paramDictionary == null)
                throw new ArgumentNullException("paramDictionary", "paramDictionary cannot be null");
            Parameters = paramDictionary;
        }

        public void Add(string paramName, string paramValue)
        {
            if (string.IsNullOrEmpty(paramName))
                throw new ArgumentException("paramName cannot be null or empty", "paramName");

            if (string.IsNullOrEmpty(paramValue))
                throw new ArgumentException( "paramValue cannot be null or empty", "paramValue");

            Parameters.Add(paramName, paramValue);
        }
    }
}
