using System.IO;
using SmartFormat;

namespace FastTemplate.Engine
{
    /// <summary>
    /// A set of extenstion methods to the string class.
    /// </summary>
    static class StringExtentions
    {
        /// <summary>
        /// Process the tempalte represented in the string
        /// </summary>
        /// <param name="s">The string contains the template</param>
        /// <param name="model">The model data</param>
        /// <returns></returns>
        public static string ProcessTemplate(this string s, object model)
        {
            return Engine.GetEngine().ProcessString(s, model);
        }

        /// <summary>
        /// Write the content of the string into a file
        /// </summary>
        /// <param name="s">The string</param>
        /// <param name="fileName">File name with full path</param>
        public static void WriteToFile(this string s, string fileName)
        {
            File.WriteAllText(fileName, s);
        }


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

        public static void CreateDirectory(this string s)
        {
            bool exists = Directory.Exists(s);

            if (!exists)
            {
                Directory.CreateDirectory(s);
            }
        }
    }
}
