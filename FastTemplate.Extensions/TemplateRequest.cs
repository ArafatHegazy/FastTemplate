using System;
using FastTemplate.Engine;

namespace FastTemplate.Extensions
{
    public class DateTimeHelper : ITemplateExtension
    {
        public static DateTimeHelper Current;

        public Engine.Engine CurrentEngine { get; set; }

        public DateTimeHelper()
        {
            Current = this;
        }

        public void RegisterTemplateEngine(Engine.Engine engine)
        {
            CurrentEngine = engine;
        }

        public string Now {get { return DateTime.Now.ToString(); }}
    }
}
