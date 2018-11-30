using PI_OTDAV_Data.Infrastructure;
using PI_OTDAV_Domain.Entities;
using PI_OTDAV_ServicePattern;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace PI_OTDAV_Services.Services
{
    public class ReclamationServices : Service<reclamation>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ReclamationServices() : base(ut){ }
        public IEnumerable<reclamation> GetReclamations (int idUser)
        {
            return ut.getRepository<reclamation>().GetAll().Where(a => a.userId == idUser).OrderByDescending(e => e.dateReclamation);
        }
        public IEnumerable<reclamation> GetReclamationsEtat(int indice,int idUser)
        {
            if (indice==0)
                return ut.getRepository<reclamation>().GetAll().Where(a=>a.etat.Equals("EnAttente")).Where(b=>b.userId == idUser).OrderByDescending(b=>b.dateReclamation);
            if (indice == 1)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.etat.Equals("EnCours")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation);
            if (indice == 2)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.etat.Equals("Traitée")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation);
            return null;
        }

        public int GetTotalReclamations(int idUser)
        {
            return ut.getRepository<reclamation>().GetAll().Where(a => a.userId == idUser).Count();
        }
        public reclamation GetReclamation(int idReclamation)
        {
            return ut.getRepository<reclamation>().GetById(idReclamation);
        }
        public int GetReclamationsEtatCount(int indice, int idUser)
        {
            if (indice == 0)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.etat.Equals("EnAttente")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation).Count();
            if (indice == 1)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.etat.Equals("EnCours")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation).Count();
            if (indice == 2)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.etat.Equals("Traitée")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation).Count();
            return 0;
        }
        public IEnumerable<reclamation> GetReclamationsType(int indice, int idUser)
        {
            if (indice == 0)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Autre")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation);
            if (indice == 1)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Suggestion")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation);
            if (indice == 2)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Financier")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation);
            if (indice == 3)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Oeuvre")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation);
            if (indice == 4)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Systeme")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation);
            return null;
        }
        public int GetReclamationsTypeCount(int indice, int idUser)
        {
            if (indice == 0)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Autre")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation).Count();
            if (indice == 1)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Suggestion")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation).Count();
            if (indice == 2)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Financier")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation).Count();
            if (indice == 3)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Oeuvre")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation).Count();
            if (indice == 4)
                return ut.getRepository<reclamation>().GetAll().Where(a => a.type.Equals("Systeme")).Where(b => b.userId == idUser).OrderByDescending(b => b.dateReclamation).Count();
            return 0;
        }
        public int GetUserId(int idReclamation)
        {
            reclamation r = ut.getRepository<reclamation>().GetById(idReclamation);
            return (int)r.userId;
        }
      


    }
}
