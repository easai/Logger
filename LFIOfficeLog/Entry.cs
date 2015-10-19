using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Entry
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; } 
        public string LogText { get; set; } 
    }
}
