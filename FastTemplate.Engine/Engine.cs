using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using System.Linq;

namespace FastTemplate.Engine
{
    /// <summary>
    /// Template engine
    /// </summary>
    public class Engine
    {
        private static Engine _engine;

        public static Engine GetEngine()
        {
            return _engine;
        }

        public static Engine InitializeEngine(List<String> namespaces)
        {
            return _engine ?? (_engine = new Engine(namespaces));
        }

        private Engine(List<String> namespaces)
        {
            InitializeRazorEngine(namespaces);
        }

        private void InitializeRazorEngine(List<String> namespaces)
        {
            var config = new TemplateServiceConfiguration();
            config.Language = Language.CSharp;
            config.EncodedStringFactory = new RawStringFactory();
            config.Namespaces.Add("FastTemplate.Engine.Utilities");
            namespaces?.ForEach(ns => config.Namespaces.Add(ns));
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
            string modelJson = File.ReadAllText(modelFile);
            dynamic model = JsonConvert.DeserializeObject<dynamic>(modelJson);
            ProcessFolder(templateFolder, outputFolder, model);
        }

        public void ProcessFolder(string templateFolder, string outputFolder, object data)
        {
            CurrentTemplatePath = templateFolder;
            CurrentOutputPath = outputFolder;

            string[] files = Directory.GetFiles(templateFolder);
            files.ToList().ForEach( file => ProcessFile(file, outputFolder, data));

            string[] directories = Directory.GetDirectories(templateFolder);
            directories.ToList().FindAll(directory => !directory.EndsWith(".template")).ForEach(directory =>
            {
                var newOutputFolder = directory.RemovePath().ProcessTemplate(data).AddPath(outputFolder);
                newOutputFolder.CreateDirectory();
                ProcessFolder(directory, newOutputFolder, data);

            });
        }

        public void ProcessFile(string file, string outputFolder, object data)
        {
            var extention = file.GetExtention();
            if (extention == ".template")
                return;
            string template = File.ReadAllText(file);
            var result = ProcessString(template, data);
            if (extention == ".templatecode")
                return;
            var outputfile = file.RemovePath().ProcessTemplate(data).AddPath(outputFolder);
            result.WriteToFile(outputfile);
        }

    }
}
