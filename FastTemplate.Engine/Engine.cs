using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using FastTemplate.Engine.Storage;

namespace FastTemplate.Engine
{
    public class Engine
    {
        public IStorage Storage { get; set; }
         
        public Engine(IStorage storage, List<Type> extensions)
        {
            Storage = storage;
            InitializeRazorEngine(extensions);
        }

        public void InitializeRazorEngine(List<Type> extensions)
        {
            var config = new TemplateServiceConfiguration();
            config.Language = Language.CSharp;
            config.EncodedStringFactory = new RawStringFactory();
            extensions?.ForEach(e =>
            {
                config.Namespaces.Add(e.AssemblyQualifiedName);
                ITemplateExtension o = (ITemplateExtension)Activator.CreateInstance(e);
                o.RegisterTemplateEngine(this);
            });
            var service = RazorEngineService.Create(config);
            RazorEngine.Engine.Razor = service;
        }

        public string CurrentTemplatePath { get; private set; } = "";
        public string CurrentOutputPath { get; private set; } = "";

        public string ProcessString(string template, object model)
        {
            return RazorEngine.Engine.Razor.RunCompile(template, Guid.NewGuid().ToString(), null, model);
        }

        /// <summary>
        /// Process a template and generate the output of the processing
        /// </summary>
        /// <param name="templateFolder">Template full path</param>
        /// <param name="outputFolder">Output folder full path</param>
        /// <param name="modelFile">Model file full path</param>
        public void ProcessTemplate(string modelFile, string templateFolder, string outputFolder)
        {
            string modelJson = Storage.ReadFromFile(modelFile);
            dynamic model = JsonConvert.DeserializeObject<dynamic>(modelJson);
            ProcessFolder(templateFolder, outputFolder, model);
        }

        public void ProcessFolder(string templateFolder, string outputFolder, object data)
        {
            CurrentTemplatePath = templateFolder;
            CurrentOutputPath = outputFolder;

            var files = Storage.GetFiles(templateFolder);
            files.ForEach( file => ProcessFile(file, outputFolder, data));

            var directories = Storage.GetDirectories(templateFolder);
            directories.FindAll(directory => !directory.EndsWith(".template")).ForEach(directory =>
            {
                var newOutputFolder = ProcessString(directory.RemovePath(),data).AddPath(outputFolder);
                Storage.CreateDirectory(newOutputFolder);
                ProcessFolder(directory, newOutputFolder, data);

            });
        }

        public void ProcessFile(string file, string outputFolder, object data)
        {
            var extention = file.GetExtention();
            if (extention == ".template")
                return;
            string template = Storage.ReadFromFile(file);
            var result = ProcessString(template, data);
            if (extention == ".templatecode")
                return;
            var outputfile = ProcessString(file.RemovePath(),data).AddPath(outputFolder);
            Storage.WriteToFile(outputfile, result);
        }

    }
}
