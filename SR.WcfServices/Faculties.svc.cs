using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SR.ApplicationServices.DTOs;
using SR.ApplicationServices.Implementations;

namespace SR.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Faculties" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Faculties.svc or Faculties.svc.cs at the Solution Explorer and start debugging.
    public class Faculties : IFaculties
    {
        private FacultyManagementService service = new FacultyManagementService();
        public string DeleteFaculty(int id)
        {
            if (!service.Delete(id))
            {
                return "Faculty was not deleted!";
            }
            else
            {
                return "Faculty was deleted successfully.";
            }
        }

        public List<FacultyDTO> GetFaculties()
        {
            return service.Get();
        }

        public string PostFaculty(FacultyDTO facDTO)
        {
            if (!service.Save(facDTO))
            {
                return "Faculty was not inserted!";
            }
            else
            {
                return "Faculty was inserted successfully.";
            }
        }

        public string PutFaculty(FacultyDTO facDTO)
        {
            if (!service.Update(facDTO))
            {
                return "Faculty was not updated!";
            }
            else
            {
                return "Faculty was updated successfully.";
            }
        }
    }
}
