using PI_OTDAV_ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI_OTDAV_Data.Infrastructure;
using PI_OTDAV_Domain.Entities;
using PI_OTDAV_Services.Services;

namespace PI_OTDAV_Services
{
    public class RepartitionService : Service<repartition>, IRepartitionService
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public RepartitionService() : base(uow)
        {
        }

        oeuvredeclarationservice oeuvser = new oeuvredeclarationservice();
        PI_OTDAV_Services.Services.PerceptionService ps = new Services.PerceptionService();
        public void  CalculateRepartitionOtdav(int idPerception )
        {
            perciption perception = ps.GetById(idPerception);
           
            double resultatOtdav;
            double resultatUser;
            double resultatimpot;
            double resultatNet;

            if (perception.oeuvredeclaration.Categorie.Equals("Musical"))


                resultatOtdav = (perception.montantotale * 20) / 100;
           
            
            else if (perception.oeuvredeclaration.Categorie.Equals("Literature"))

                resultatOtdav = (perception.montantotale * 17) / 100;
            else if (perception.oeuvredeclaration.Categorie.Equals("Theatre"))
                resultatOtdav = (perception.montantotale * 10) / 100;
            else
                resultatOtdav = 0;

            


            if (perception.oeuvredeclaration.Categorie.Equals("Musical"))
                resultatUser = ((perception.montantotale)-resultatOtdav)*30 / 100;
           else if (perception.oeuvredeclaration.Categorie.Equals("Literature"))
                resultatUser = ((perception.montantotale) - resultatOtdav) * 10 / 100;
            else if (perception.oeuvredeclaration.Categorie.Equals("Theatre"))
                resultatUser = ((perception.montantotale) - resultatOtdav) * 40  / 100;
            else
                resultatUser = ((perception.montantotale) - resultatOtdav) * 20 / 100;

            

            resultatimpot = (resultatUser * 15) / 100;

            


            resultatNet = resultatUser - resultatimpot;

            repartition r = new repartition() { benificeOTDAV=resultatOtdav,benificeUser=resultatUser,impot=resultatimpot,netPercue=resultatNet,perception_idPerception=perception.idPerception};
            Add(r);
            Commit();
            
           



        }
    

      


        public List<repartition> getAlll()
        {
            return uow.getRepository<repartition>().GetAll().ToList();
        }

        public List<repartition> getRepartitionByArtWork(int idoeuvre)
        {
         
           return uow.getRepository<repartition>().GetAll().Where(a=>a.perciption.OeuvreD_id==idoeuvre).ToList();
            
            
        }

        public List<repartition> getRepartitionByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public int countRepartitions()
        {
            int simple = GetAll().Where(x => x.netPercue>30.00 ).Count();
            return simple;
        //     public int CountSimpleArtWork(int u)
        //{
        //    Ioeuvredeclarationservice oeuvredeclarationservice = new oeuvredeclarationservice();
        //    int simple = oeuvredeclarationservice.GetAll().Where(x => x.etat == "Simple" && x.user_ID == u).Count();
        //    return simple;
        //}


    }
    }
}
