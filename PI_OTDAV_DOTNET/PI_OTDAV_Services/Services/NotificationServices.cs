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
    public class NotificationServices : Service<notification>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public NotificationServices() : base(ut){ }
        public IEnumerable<notification> GetHistorique(int idUser)
        {
            return ut.getRepository<notification>().GetAll().Where(e => e.idUser == idUser).OrderByDescending(e => e.dateNotification);
        }
        public void UpdateEtatNotification(int idNotification)
        {
            notification n=ut.getRepository<notification>().GetById(idNotification);
            n.etat = "Lu";
            Update(n);
            Commit();
        }
        public int GetNbNotif(int idDestination)
        {
            return ut.getRepository<notification>().GetAll().Where(e => e.idDestination == idDestination).Count();
        }
    }
}
