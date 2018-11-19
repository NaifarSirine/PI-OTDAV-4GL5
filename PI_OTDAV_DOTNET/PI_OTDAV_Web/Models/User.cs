using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_OTDAV_Web.Models
{
    public class User
    {
        public User()
        {
          
        }

        public int id { get; set; }

        public DateTime? acceptationDate { get; set; }

        public string accountStatuts { get; set; }

        public string accountType { get; set; }

        public string address { get; set; }


        public DateTime? birthday { get; set; }


        public string cin { get; set; }


        public string commercialRegisterNumber { get; set; }


        public DateTime? dateCin { get; set; }

        public string firstName { get; set; }

        public int? fonction { get; set; }


        public string gouverment { get; set; }


        public string lastName { get; set; }


        public string password { get; set; }

        public int phone { get; set; }

        public int points { get; set; }

        public int postelCode { get; set; }

        public int? raisonSocial { get; set; }

        public DateTime? registrationDate { get; set; }


        public string userName { get; set; }


        public string mail { get; set; }

       
    }
}