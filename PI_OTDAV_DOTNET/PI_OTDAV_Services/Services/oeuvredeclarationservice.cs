using PI_OTDAV_Data.Infrastructure;
using PI_OTDAV_Domain.Entities;
using PI_OTDAV_ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PI_OTDAV_Services.Services
{
   public class oeuvredeclarationservice: Service<oeuvredeclaration>, Ioeuvredeclarationservice
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);

       public static List<oeuvredeclaration> liste = new List<oeuvredeclaration>();


        public oeuvredeclarationservice() : base(uow)
        {
            
        }

        public List<oeuvredeclaration> getAlll()
        {
            //List<oeuvredeclaration> ListOeuvre = GetAll().ToList();
            //return ListOeuvre;
            List<oeuvredeclaration> ListOeuvre = new List<oeuvredeclaration>();
            ListOeuvre = GetAll().Where(x => x.user_ID == 1 && x.etat == "Accepter").ToList();
            return ListOeuvre;
        }

        public List<oeuvredeclaration> getSimpleArtworkByUserId(int id)
        {
            List<oeuvredeclaration> ListSA = new List<oeuvredeclaration>();
            ListSA = GetAll().Where(x => x.user_ID == 1 && x.etat=="Simple" ).OrderBy(x => x.Categorie).ToList();
            liste = ListSA;
            return ListSA;
        }

        public List<oeuvredeclaration> getAccepterArtworkByUserId(int id)
        {
            List<oeuvredeclaration> ListSA = new List<oeuvredeclaration>();
            ListSA = GetAll().Where(x => x.user_ID == 1 && x.etat == "Accepter").OrderBy(x => x.Categorie).ToList();
            return ListSA;
        }

        public List<oeuvredeclaration> getEnAttenteArtworkByUserId(int id)
        {
            List<oeuvredeclaration> ListSA = new List<oeuvredeclaration>();
            ListSA = GetAll().Where(x => x.user_ID == id && x.etat == "EnAttente").OrderBy(x => x.Categorie).ToList();
            liste = ListSA;
            return ListSA;
        }

        public List<oeuvredeclaration> getSupprimerArtworkByUserId(int id)
        {
            List<oeuvredeclaration> ListSA = new List<oeuvredeclaration>();
            ListSA = GetAll().Where(x => x.user_ID == id && x.etat == "Supprimer").OrderBy(x => x.Categorie).ToList();
            liste = ListSA;
            return ListSA;
        }

        public void EditSipmleArtwork( oeuvredeclaration o)
        {
            uow.getRepository<oeuvredeclaration>().Update(o);
            uow.Commit();
        }


        public int CountSimpleArtWork(int u)
        {
            Ioeuvredeclarationservice oeuvredeclarationservice = new oeuvredeclarationservice();
            int simple = oeuvredeclarationservice.GetAll().Where(x => x.etat == "Simple" && x.user_ID==u).Count();
            return simple;
        }

        public int CountRefuserArtWork(int u)
        {
            Ioeuvredeclarationservice oeuvredeclarationservice = new oeuvredeclarationservice();
            int simple = oeuvredeclarationservice.GetAll().Where(x => x.etat == "Refuser" && x.user_ID == u).Count();
            return simple;
        }

        public int CountEnAttenteArtWork(int u)
        {
            Ioeuvredeclarationservice oeuvredeclarationservice = new oeuvredeclarationservice();
            int EnAttente = oeuvredeclarationservice.GetAll().Where(x => x.etat == "EnAttente" && x.user_ID == u).Count();
            return EnAttente;
        }

        public int CountSupprimerArtWork(int u)
        {
            Ioeuvredeclarationservice oeuvredeclarationservice = new oeuvredeclarationservice();
            int Supprimer = oeuvredeclarationservice.GetAll().Where(x => x.etat == "Supprimer" && x.user_ID == u).Count();
            return Supprimer;
        }

        public int CountAccepterArtWork(int u)
        {
            Ioeuvredeclarationservice oeuvredeclarationservice = new oeuvredeclarationservice();
            int acc = oeuvredeclarationservice.GetAll().Where(x => x.etat == "Accepter" && x.user_ID == u).Count();
            return acc;
        }

        public int CountAccepterArtWorAll()
        {
            Ioeuvredeclarationservice oeuvredeclarationservice = new oeuvredeclarationservice();
            int acc = oeuvredeclarationservice.GetAll().Where(x => x.etat == "Accepter").Count();
            return acc;
        }

        public int CountAllArtWork(int u)
        {
            Ioeuvredeclarationservice oeuvredeclarationservice = new oeuvredeclarationservice();
            int all = oeuvredeclarationservice.GetAll().Where(x => x.user_ID == u).GroupBy(x=>x.Categorie).Count();
            return all;
        }

        public void EditOeuvreDeclaration(int id, oeuvredeclaration o)
        {
            uow.getRepository<oeuvredeclaration>().Update(o);
            uow.Commit();
        }


        public void SuppOeuvreDeclaration(int id, oeuvredeclaration o)
        {
            o.etat = "Supprimer";
            uow.getRepository<oeuvredeclaration>().Update(o);
            uow.Commit();
        }


        public List<oeuvredeclaration> SearchOeuvreDeclarationByCategory()
        {
            List<oeuvredeclaration> ListOeuvre = new List<oeuvredeclaration>();
            ListOeuvre = GetAll().Where(x => x.Categorie=="Musical").ToList();
            return ListOeuvre;
        }


    }
}
