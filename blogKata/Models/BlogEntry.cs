namespace blogKata.Models
{
    using System;

    public class BlogEntry
    {
        public BlogEntry()
            : this(string.Empty)
        {
        }

        public BlogEntry(string title)
        {
            Title = title;
            Body = string.Empty;
            CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
    }
}