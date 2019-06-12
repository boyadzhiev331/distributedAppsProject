using SR.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SR.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudents" in both code and config file together.
    [ServiceContract]
    public interface IStudents
    {
        [OperationContract]
        List<StudentDTO> GetStudents();

        [OperationContract]
        StudentDTO GetById(int id);

        [OperationContract]
        string PostStudent(StudentDTO stuDTO);

        [OperationContract]
        string PutStudent(StudentDTO stuDTO);

        [OperationContract]
        string DeleteStudent(int id);
    }
}
