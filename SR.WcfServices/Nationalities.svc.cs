using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SR.ApplicationServices.DTOs;
using SR.ApplicationServices.Implementations;
using SR.DataAccess.Entities;

namespace SR.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Nationalities" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Nationalities.svc or Nationalities.svc.cs at the Solution Explorer and start debugging.
    public class Nationalities : INationalities
    {
        private NationalityManagementService service = new NationalityManagementService();

        public string DeleteNationality(int id)
        {
            if (!service.Delete(id))
            {
                return "Nationality was not deleted!";
            }
            else
            {
                return "Nationality was deleted successfully.";
            }
        }

        public List<NationalityDTO> GetNationalities()
        {
            return service.Get();
         }

        public string PostNationality(NationalityDTO natDTO)
        {
            if (!service.Save(natDTO))
            {
                return "Nationality was not inserted!";
            }
            else
            {
                return "Nationality was inserted successfully.";
            }
        }

        public string PutNationality(NationalityDTO natDTO)
        {
            if (!service.Update(natDTO))
            {
                return "Nationality was not updated!";
            }
            else
            {
                return "Nationality was updated successfully.";
            }
        }
    }
}
