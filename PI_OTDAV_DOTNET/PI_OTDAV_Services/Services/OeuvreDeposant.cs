﻿using PI_OTDAV_Data.Infrastructure;
using PI_OTDAV_Domain.Entities;
using PI_OTDAV_ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_OTDAV_Services.Services
{
    public class OeuvreDeposant : Service<oeuvredeposant>, IOeuvreDeposant
    {
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(dbFactory);

        public OeuvreDeposant() : base(utw)
        {
        }


    }
}


