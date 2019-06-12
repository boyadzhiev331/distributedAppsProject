using SR.ApplicationServices.DTOs;
using SR.ApplicationServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SR.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Students" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Students.svc or Students.svc.cs at the Solution Explorer and start debugging.
    public class Students : IStudents
    {
        StudentManagementService service = new StudentManagementService();

        public string DeleteStudent(int id)
        {
            if (!service.Delete(id))
            {
                return "Student was not deleted!";
            }
            else
            {
                return "Student was deleted successfully.";
            }
        }

        public List<StudentDTO> GetStudents()
        {
            return service.Get();
        }

        public StudentDTO GetById(int id)
        {
            return service.GetById(id);
        }

        public string PostStudent(StudentDTO stuDTO)
        {
            if (!service.Save(stuDTO))
            {
                return "Student was not inserted!";
            }
            else
            {
                return "Student was inserted successfully.";
            }
        }

        public string PutStudent(StudentDTO stuDTO)
        {
            if (!service.Update(stuDTO))
            {
                return "Student was not updated!";
            }
            else
            {
                return "Student was updated successfully.";
            }
        }
    }
}
