using PI_OTDAV_Domain.Entities;
using PI_OTDAV_ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_OTDAV_Services.Services
{
    public interface Ioeuvredeclarationservice : IService<oeuvredeclaration>
    {

        //List<oeuvredeclaration> getByUserId(int id);
        List<oeuvredeclaration> getAlll();
        List<oeuvredeclaration> getSimpleArtworkByUserId(int id);
        List<oeuvredeclaration> getEnAttenteArtworkByUserId(int id);
        List<oeuvredeclaration> getAccepterArtworkByUserId(int id);

        int CountSimpleArtWork(int u);
        int CountEnAttenteArtWork(int u);
        int CountSupprimerArtWork(int u);
        int CountAccepterArtWork(int u);
        int CountAllArtWork(int u);


    }
}
