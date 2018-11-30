using PI_OTDAV_Domain.Entities;
using PI_OTDAV_ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_OTDAV_Services
{
    public interface IRepartitionService : IService<repartition>
    {


        void CalculateRepartitionOtdav(int idPerception);
 
    

        
        List<repartition> getAlll();
        List<repartition> getRepartitionByUserId(int id);
        List<repartition> getRepartitionByArtWork(int idoeuvre);
        int countRepartitions();













    }
}
