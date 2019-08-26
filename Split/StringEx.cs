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
                    if(delimiter.Length > 1)
                    {
                        int sourceCharsLeft = source.Length - sourceIdx;

                        // edge case ( not enough characters to look ahead ) ==> always false
                        if(sourceCharsLeft < delimiter.Length)
                        {
                            // TODO(rafa): Cover this case with test
                            throw new NotImplementedException();
                        }
                        // common case ( enough characters to look ahead ) ==> compare all characters
                        else
                        {
                            bool completeMatch = true;
                            for( int delimiterIdx = 1; delimiterIdx < delimiter.Length; delimiterIdx++)
                            {
                                bool partialMatch = delimiter[delimiterIdx] == source[sourceIdx + delimiterIdx];
                                if(!partialMatch)
                                {
                                    completeMatch = false;
                                    break;
                                }
                            }

                            if (completeMatch)
                            {
                                // Note(rafa): -1 is needed because current index is already skipped
                                sourceIdx += delimiter.Length - 1;
                                // If match, close and store fragment until now, and skip match
                                if (sb.Length > 0)
                                {
                                    fragments.Add(sb.ToString());
                                    sb.Clear();
                                }
                            }
                            else // Not delimiter match
                            {
                                sb.Append(current);
                                if (sourceIdx == (source.Length - 1))
                                {
                                    fragments.Add(sb.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        // If match, close and store fragment until now, and skip match
                        if(sb.Length > 0)
                        {
                            fragments.Add(sb.ToString());
                            sb.Clear();
                        }
                    }
                }
                else // Not delimiter match
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
