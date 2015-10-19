using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class OfficeLog:DbContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryTag> EntryTags { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
