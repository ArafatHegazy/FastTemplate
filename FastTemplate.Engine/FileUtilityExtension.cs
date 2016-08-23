using System.IO;

namespace FastTemplate.Engine
{
    /// <summary>
    /// A set of extenstion methods to the string class.
    /// </summary>
    static class FileUtilityExtension
    {
        /// <summary>
        /// Removes the path and return the file name only from the current string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemovePath(this string s)
        {
            return Path.GetFileName(s);
        }

        public static string GetExtention(this string s)
        {
            return Path.GetExtension(s);
        }

        public static string AddPath(this string name, string path)
        {
            return path + "\\" + name;
        }

    }
}
