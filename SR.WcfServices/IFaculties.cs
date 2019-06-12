using SR.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SR.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFaculties" in both code and config file together.
    [ServiceContract]
    public interface IFaculties
    {
        [OperationContract]
        List<FacultyDTO> GetFaculties();

        [OperationContract]
        string PostFaculty(FacultyDTO facDTO);

        [OperationContract]
        string PutFaculty(FacultyDTO facDTO);

        [OperationContract]
        string DeleteFaculty(int id);
    }
}
