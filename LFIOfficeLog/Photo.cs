using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Photo
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> PhotoTime { get; set; }
        public byte[] PhotoData { get; set; } 
    }
}
