using PI_OTDAV_Data.Infrastructure;
using PI_OTDAV_Domain.Entities;
using PI_OTDAV_ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_OTDAV_Services.Services
{
    public class PaimentService : Service<paiment>, IPaimentService
    {
        private static DatabaseFactory Dbf = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(Dbf);

        public PaimentService() : base(utw)
        {

        }
        public void deletePaiment(paiment p)
        {
            this.Delete(p);
            this.Commit();
        }

        public paiment getPaiment(int id)
        {
            return this.GetById(id);
        }
    }
}
