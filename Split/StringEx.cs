using System;
using System.Collections.Generic;
using System.Text;

namespace Split
{
    public class StringEx
    {
        public static string[] Split(string source, string delimiter)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (delimiter == null || delimiter == string.Empty )
                return new string[] { source };

            List<string> fragments = new List<string>();
            StringBuilder sb = new StringBuilder();
            for( int sourceIdx = 0; sourceIdx < source.Length; sourceIdx++)
            {
                char current = source[sourceIdx];

                if(current == delimiter [0] )
                {
                    int skipSize = 1; // NOTE(rafa): only for single char delimiters
                    // Detect whether match ( for long matches )

                    // If match, close and store fragment until now, and skip match
                    if(sb.Length > 0)
                    {
                        fragments.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                else
                {
                    sb.Append(current);
                    if (sourceIdx == (source.Length - 1))
                    {
                        fragments.Add(sb.ToString());
                    }
                }
            }

            return fragments.ToArray();
        }
    }
}
