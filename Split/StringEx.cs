using System;
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

            throw new NotImplementedException();
        }
    }
}
