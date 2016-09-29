using System;

using System.Collections.Generic;
using System.Text;

namespace WirelessPrintHelper
{
    /// <summary>
    /// Used to store content parameters
    /// </summary>
    public class ContentParameters : IContentParameters
    {
        /// <summary>
        /// Gets parameter dictionary
        /// </summary>
        public Dictionary<string, string> Parameters { get; private set; }

        /// <summary>
        /// Creates a new instance of ContentParameters
        /// </summary>
        public ContentParameters()
        {
            Parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Creates a new instance of ContentParameters with given paramDictionary
        /// </summary>
        /// <param name="paramDictionary">Parameter dictionary</param>
        public ContentParameters(Dictionary<string, string> paramDictionary)
        {
            if (paramDictionary == null)
                throw new ArgumentNullException("paramDictionary", "paramDictionary cannot be null");
            Parameters = paramDictionary;
        }

        /// <summary>
        /// Add a new entry to parameter dictionary
        /// </summary>
        /// <param name="paramName">Name of parameter</param>
        /// <param name="paramValue">Value of parameter</param>
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
