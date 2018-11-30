using PI_OTDAV_Domain.Entities;
using PI_OTDAV_ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI_OTDAV_Data.Infrastructure;

namespace PI_OTDAV_Services.Services
{
    public class PerceptionService : Service<perciption>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public PerceptionService() : base(uow)
        {


        }
    }
}
