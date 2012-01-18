namespace blogKata.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Blog
    {

        private ICollection<BlogEntry> _entries = new Collection<BlogEntry>();

        public IEnumerable<BlogEntry> Entries
        {
            get
            {
                return _entries;
            }
        }

        public void Add(BlogEntry blogEntry)
        {
            _entries.Add(blogEntry);
        }
    }
}