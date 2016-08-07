using System.IO;

namespace FastTemplate.Engine.Utilities
{
    public class TemplateProcessor
    {
        public static void ProcessFolderTemplate(string templateFolder, string outputFolder, object model)
        {
            outputFolder.CreateDirectory();
            Engine.GetEngine().ProcessFolder(templateFolder, outputFolder, model);
        }

        public static void ProcessFileTemplate(string templateFile, string outputFileName, object model)
        {
            string template = File.ReadAllText(templateFile);
            Engine.GetEngine().ProcessString(template, model);
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
