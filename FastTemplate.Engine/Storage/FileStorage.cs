﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FastTemplate.Engine.Storage
{
    public class FileStorage : IStorage
    {
        public void CreateDirectory(string directoryName)
        {
            bool exists = Directory.Exists(directoryName);

            if (!exists)
            {
                Directory.CreateDirectory(directoryName);
            }
        }

        public List<string> GetFiles(string directoryName)
        {
            return Directory.GetFiles(directoryName).ToList();
        }

        public List<string> GetDirectories(string directoryName)
        {
            return Directory.GetDirectories(directoryName).ToList();
        }

        public string ReadFromFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public void WriteToFile(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
        }
    }
}