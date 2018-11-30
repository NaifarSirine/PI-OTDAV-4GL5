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
   public class MembershipCategoryService : Service<membershipcategory> ,IMembershipCategoryService
    {
        private static IDatabaseFactory dbf;
        private static IUnitOfWork ut;

        public MembershipCategoryService() : base(ut)
        {
            dbf = new DatabaseFactory();
            ut = new UnitOfWork(dbf);
           
        }
        public void createmembership(membershipcategory mc)
        {
          /*  List<string> string1 = new List<string>();
            string1.Add("Peintre");
            string1.Add("Cinematographe");
            string1.Add("Musicien");
            string1.Add("Compositeur");
            string1.Add("Sculteur");

            foreach (string str in mc.nom)
            {
                if (string1.Contains(str) == true)
                {*/
                    ut.getRepository<membershipcategory>().Add(mc);
                    ut.Commit();
              //  }
              //  else
              //  {

               // }
            //}


        }
        public membershipcategory getmembershipcategoryById(int id)
        {
            return ut.getRepository<membershipcategory>().GetById(id);


        }
        public List<membershipcategory> getAllmembershipcategory()
        {
            return ut.getRepository<membershipcategory>().GetAll().ToList();
        }
     /*   public void deletemembershipcategory(membershipcategory mc)
        {
            ut.getRepository<membershipcategory>().Delete(mc);
            ut.Commit();

        }*/
        public void updatemembershipcategory(membershipcategory mc)
        {
            ut.getRepository<membershipcategory>().Update(mc);
            ut.Commit();
        }
    }
}
