namespace blogKata.Models
{
    using System;

    public class BlogEntry
    {
        public BlogEntry(string title)
        {
            Title = title;
            Body = string.Empty;
        }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}