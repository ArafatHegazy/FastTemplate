using System;
using FastTemplate.Engine;

namespace FastEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("FastTemplate ConfigurationFile TempalteLocation OutputLocation ");
                return;
            }
            Console.WriteLine("Generation started.");
            try
            {
                Engine.ProcessTemplate(args[0], args[1], args[2]);
                Console.WriteLine("Generation finished successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurs during generation , details: " + e.Message);
            }
        }
    }
}
