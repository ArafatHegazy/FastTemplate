using System;
using System.Collections.Generic;

namespace FastTemplate.Engine
{
    public class TemplateRequest
    {
        public IDictionary<string, object> Data { get; set;}

        public DateTimeHelper DateTimeHelper => new DateTimeHelper();
    }

    public class TemplateRequest2
    {
        public object Data { get; set; }

        public DateTimeHelper DateTimeHelper => new DateTimeHelper();
    }

    public class DateTimeHelper
    {
        public string Now {get { return DateTime.Now.ToString(); }}
    }
}
