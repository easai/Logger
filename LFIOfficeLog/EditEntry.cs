using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class EditEntry:NewEntry
    {
        int id;
        LoggerForm logger;

        public EditEntry(int id, LoggerForm logger):base(logger)
        {
            this.logger = logger;
            this.id = id;
        }
        public override void save() 
        {
            using (var db = new OfficeLog())
            {
                var entry = db.Entries.Single(x => x.Id == id);
                entry.LogText = getRtf();

                int recordsAffected = db.SaveChanges();
            }
            logger.refreshScreen();
            Dispose();
        }
    }
}
