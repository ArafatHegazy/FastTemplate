using System.Collections.Generic;
using System.IO;
using AH.SimpleStorage;
using AH.SimpleStorage.Implementations;
using FastTemplate.Engine;

namespace FastTemplate.Extensions
{
    public class TemplateProcessor : ITemplateExtension
    {
        public static TemplateProcessor templateProcessor;

        private readonly IStorage _storage;

        public TemplateProcessor()
        {
            _storage = new FileStorage();
            templateProcessor = this;
        }

        public TemplateProcessor(IStorage storage)
        {
            _storage = storage;
            templateProcessor = this;
        }

        public void RegisterTemplateEngine(Engine.Engine engine)
        {
            CurrentEngine = engine;
        }

        public Engine.Engine CurrentEngine { get; set; }

        public Dictionary<string,string> DataStore = new Dictionary<string, string>(); 
        public void ProcessFolderTemplate(string templateFolder, string outputFolder, object model)
        {
            _storage.CreateDirectory(outputFolder);
            CurrentEngine.ProcessFolder(templateFolder, outputFolder, model);
        }

        public void ProcessFileTemplate(string templateFile, string outputFileName, object model)
        {
            string template = File.ReadAllText(templateFile);
            var result = CurrentEngine.ProcessString(template, model);
            _storage.WriteTextToFile(outputFileName, result);
        }

        public string GetCurrentTemplatePath()
        {
            return CurrentEngine.CurrentTemplatePath;
        }

        public string GetCurrentOutputPath()
        {
            return CurrentEngine.CurrentOutputPath;
        }

    }
}
