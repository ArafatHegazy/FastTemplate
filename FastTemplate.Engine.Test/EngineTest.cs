using System;
using NUnit.Framework;

namespace FastTemplate.Engine.Test
{
    [TestFixture]
    public class EngineTest
    {
        [SetUp]
        public void Setup()
        {
            Engine.InitializeEngine(null);
        }

        [Test]
        public void TestGenerateFromTemplate()
        {
            Engine.GetEngine().ProcessTemplate("d:\\ConfigFile.json", "D:\\Templates\\Noitso.Templates.CSharpLibrary", "d:\\Output");
        }

        [Test]
        public void TestTemplateEngine()
        {
            var model = new
            {
                Name = "arafat",
                IsActive = false
            };
            string template =
@"Hello @(Model.Name)212
@if(Model.IsActive) {
<text>
yes
</text>
}else{
<text>
no
</text>
}
welcome to RazorEngine!
";
            var result = Engine.GetEngine().ProcessString(template, model);
            Console.WriteLine(result);
        }

        [Test]
        public void TestPath()
        {
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
        }


    }

}
