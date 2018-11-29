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
    public class UserServices : Service<user>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public UserServices() : base(ut){ }
    }
}
