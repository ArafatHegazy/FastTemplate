using NUnit.Framework;
using Shouldly;

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
        public void JenkinsTemplate()
        {
            Engine.GetEngine().ProcessTemplate(@"C:\FastTemplate.Engine.Test\Models\Model1.json",
                @"C:\FastTemplate.Engine.Test\Templates\Jenkins", @"C:\FastTemplate.Engine.Test\Output\Model1.Jenkins");
        }

        [Test]
        public void SimpleJenkinsTemplate()
        {
            Engine.GetEngine().ProcessTemplate(@"C:\FastTemplate.Engine.Test\Models\Model1.json",
                @"C:\FastTemplate.Engine.Test\Templates\SimpleJenkins", @"C:\FastTemplate.Engine.Test\Output\Model1.SimpleJenkins");
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
            result.ShouldNotBeEmpty();
        }
    }

}
