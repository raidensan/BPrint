using System;

using System.Collections.Generic;
using System.Text;

namespace BPrint
{
    public class ContentReplacer
    {
        public IContentParameters ContentParameters { get; private set; }
        public Encoding Encoding { get; private set; }

        public ContentReplacer()
        {
            this.ContentParameters = new ContentParameters();
        }

        public ContentReplacer(IContentParameters contentParameters)
        {
            if (contentParameters == null)
                throw new ArgumentNullException("contentParameters", "contentParameters cannot be null");

            this.ContentParameters = contentParameters;
        }

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
