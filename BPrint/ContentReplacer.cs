using System;
using System.Collections.Generic;
using System.Text;

namespace WirelessPrintHelper
{
    /// <summary>
    /// Used to replace content of parameterized file with given parameters
    /// </summary>
    public class ContentReplacer : IContentReplacer
    {
        /// <summary>
        /// Gets current parameters
        /// </summary>
        public IContentParameters ContentParameters { get; private set; }

        /// <summary>
        /// Gets current encoding
        /// </summary>
        public Encoding Encoding { get; private set; }

        /// <summary>
        /// Creates a new Instance of ContentReplacer
        /// </summary>
        public ContentReplacer()
        {
            this.ContentParameters = new ContentParameters();
        }

        /// <summary>
        /// Creates a new Instance of ContentReplacer with given parameters
        /// </summary>
        /// <param name="contentParameters">Parameters</param>
        public ContentReplacer(IContentParameters contentParameters)
        {
            if (contentParameters == null)
                throw new ArgumentNullException("contentParameters", "contentParameters cannot be null");

            this.ContentParameters = contentParameters;
        }

        /// <summary>
        /// Creates a new Instance of ContentReplacer with given parameters and encoding
        /// </summary>
        /// <param name="contentParameters">Parameters</param>
        /// <param name="encoding">Encoding</param>
        public ContentReplacer(IContentParameters contentParameters,Encoding encoding)
        {
            if (contentParameters == null)
                throw new ArgumentNullException("contentParameters", "contentParameters cannot be null");
            if (encoding == null)
                throw new ArgumentNullException("encoding", "encoding cannot be null");

            this.ContentParameters = contentParameters;
            this.Encoding = encoding;
        }

        /// <summary>
        /// Replaces source contens with parameter values
        /// </summary>
        /// <param name="source">Source</param>
        /// <returns>Replaced source content</returns>
        public byte[] Replace(byte[] source)
        {
            if (source == null)
                throw new ArgumentNullException("source", "source cannot be null");

            foreach (var param in ContentParameters.Parameters)
            {
                source = ReplaceFirstOccurance(source, param.Key, param.Value);
            }

            return source;
        }

        /// <summary>
        /// Replaces source contens with given parameter values
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="contentParameters">Content paramaters</param>
        /// <returns>Replaced source content</returns>
        public byte[] Replace(byte[] source, IContentParameters contentParameters)
        {
            if (source == null)
                throw new ArgumentNullException("source", "source cannot be null");

            if (contentParameters == null)
                throw new ArgumentNullException("contentParameters", "contentParameters cannot be null");

            foreach (var param in contentParameters.Parameters)
            {
                source = ReplaceFirstOccurance(source, param.Key, param.Value);
            }

            return source;
        }

        /// <summary>
        /// Replaces first occurence of toBeChanged with newValue
        /// </summary>
        /// <param name="oldContent">Content to change</param>
        /// <param name="toBeChanged">Old value</param>
        /// <param name="newValue">New value</param>
        /// <returns></returns>
        private byte[] ReplaceFirstOccurance(byte[] oldContent, string toBeChanged, string newValue)
        {
            byte[] oldBytes = Encoding.GetBytes(toBeChanged);
            byte[] newBytes = Encoding.GetBytes(newValue);

            byte[] newContent = new byte[oldContent.Length + newBytes.Length - oldBytes.Length];

            int findIndex = IndexOf(oldContent, oldBytes, 0);

            if (findIndex == -1)
                return oldContent;

            Array.Copy(oldContent, newContent, findIndex);
            Array.Copy(newBytes, 0, newContent, findIndex, newBytes.Length);
            Array.Copy(oldContent, findIndex + oldBytes.Length, newContent, findIndex + newBytes.Length, oldContent.Length - (findIndex + oldBytes.Length));

            return newContent;
        }

        /// <summary>
        /// Finds starting index of bytesToBeSearched in content
        /// </summary>
        /// <param name="content">Content to search</param>
        /// <param name="bytesToBeSearched">Value to find</param>
        /// <param name="startIndex">Starting index</param>
        /// <returns>Starting index of bytesToBeSearched inside content</returns>
        private int IndexOf(byte[] content, byte[] bytesToBeSearched, int startIndex)
        {
            for (int i = startIndex; i < content.Length; i++)
            {
                if (content[i] == bytesToBeSearched[0])
                {
                    bool isMathing = IsMatch(content, i, bytesToBeSearched);
                    if (isMathing)
                        return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        /// <param name="bytesToBeSearched"></param>
        /// <returns></returns>
        private bool IsMatch(byte[] content, int index, byte[] bytesToBeSearched)
        {
            for (int i = 0; i < bytesToBeSearched.Length; i++)
            {
                if (content[index + i] != bytesToBeSearched[i])
                    return false;
            }
            return true;
        }

    }
}
