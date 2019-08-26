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
            StringBuilder fragmentBuilder = new StringBuilder();

            for( int sourceIdx = 0; sourceIdx < source.Length; sourceIdx++)
            {
                char current = source[sourceIdx];

                void AppendToFragment(char character)
                {
                    fragmentBuilder.Append(character);
                    if(sourceIdx == (source.Length -1))
                    {
                        fragments.Add(fragmentBuilder.ToString());
                    }
                }

                void StoreCurrentFragment()
                {
                    if (fragmentBuilder.Length > 0)
                    {
                        fragments.Add(fragmentBuilder.ToString());
                        fragmentBuilder.Clear();
                    }
                }

                
                int sourceCharsLeft = source.Length - sourceIdx;

                if( sourceCharsLeft >= delimiter.Length && current == delimiter [0] )
                {
                    if(delimiter.Length > 1)
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
                            // If match, close and store fragment until now, and skip match
                            sourceIdx += delimiter.Length - 1;
                            StoreCurrentFragment();
                        }
                        else
                        {
                            AppendToFragment(current);
                        }
                        
                    }
                    else
                    {
                        StoreCurrentFragment();
                    }
                }
                else // Not delimiter match
                {
                    AppendToFragment(current);
                }
            }

            return fragments.ToArray();
        }
    }
}
