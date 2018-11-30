using PI_OTDAV_Domain.Entities;
using PI_OTDAV_ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_OTDAV_Services.Services
{
   public interface IMembershipCategoryService : IService<membershipcategory>
    {
        void createmembership(membershipcategory mc);
        membershipcategory getmembershipcategoryById(int id);
        List<membershipcategory> getAllmembershipcategory();
       // void deletemembershipcategory(membershipcategory mc);
        void updatemembershipcategory(membershipcategory mc);
    }
}
