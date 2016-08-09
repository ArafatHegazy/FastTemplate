using System.Collections.Generic;
using System.IO;

namespace FastTemplate.Engine.Utilities
{
    public class TemplateProcessor
    {
        public static Dictionary<string,string> DataStore = new Dictionary<string, string>(); 
        public static void ProcessFolderTemplate(string templateFolder, string outputFolder, object model)
        {
            outputFolder.CreateDirectory();
            Engine.GetEngine().ProcessFolder(templateFolder, outputFolder, model);
        }

        public static void ProcessFileTemplate(string templateFile, string outputFileName, object model)
        {
            string template = File.ReadAllText(templateFile);
            var result = Engine.GetEngine().ProcessString(template, model);
            result.WriteToFile(outputFileName);
        }

        public static string GetCurrentTemplatePath()
        {
            return Engine.GetEngine().CurrentTemplatePath;
        }

        public static string GetCurrentOutputPath()
        {
            return Engine.GetEngine().CurrentOutputPath;
        }
    }
}
