using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Tests.Builders.BlogBuilders
{
    public class BlogBuilder
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public int Hits { get; set; }
        public bool IsDeleted { get; set; }

        private BlogBuilder() { }

        public static BlogBuilder aClient()
            => new BlogBuilder();
    }
}
