using AH.SimpleStorage.Implementations;
using NUnit.Framework;
using Shouldly;

namespace FastTemplate.Engine.Test
{
    [TestFixture]
    public class EngineTest
    {
        private Engine engine;
        [SetUp]
        public void Setup()
        {
            engine = new Engine(new MemoryStorage("base"), null);
        }

        [Test]
        public void SimpleTextTempalteProcessingTest()
        {
            var model = new
            {
                Name = "arafat",
                IsActive = true
            };
            var template =
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
            var expected =
@"Hello arafat212

yes

welcome to RazorEngine!
";
            var result = engine.ProcessString(template, model);
            result.ShouldNotBeEmpty();
            result.ShouldBe(expected);
        }
        [Test]
        public void TestEngineWithStorage()
        {
            var storage = new MemoryStorage("base");
            storage.CreateDirectory("base\\model");
            storage.WriteTextToFile("base\\model\\model.json", @"{
	                'ApplicationData': {
		                'Name': 'ApplicationOne',
		                'Description': 'This is a greate application', 
		                'Namespace': 'Company.Application.Library',
		                'ProjectType': 'DotNetLibrary'
	                },
	                'Modules': [
		                {'Name':'module1','InlcudeInJenkinsBuild':true},
		                {'Name':'module2','InlcudeInJenkinsBuild':false},
		                {'Name':'module3','InlcudeInJenkinsBuild':true}
		                ]
                }");
            storage.CreateDirectory("base\\template");
            storage.WriteTextToFile("base\\template\\sample.txt","Application Name:");
            storage.WriteTextToFile("base\\template\\sample1.txt", "Application Name:@Model.ApplicationData.Name");
            storage.CreateDirectory("base\\output");
            engine = new Engine(storage, null);
            engine.ProcessTemplate("base\\model\\model.json", "base\\template", "base\\output");
            storage.GetFiles("base\\output").Count.ShouldBe(2);
            storage.ReadTextFromFile("base\\output\\sample.txt").ShouldBe("Application Name:");
            storage.ReadTextFromFile("base\\output\\sample1.txt").ShouldBe("Application Name:ApplicationOne");
        }
    }



}
