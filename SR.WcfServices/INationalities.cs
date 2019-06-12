using SR.ApplicationServices.DTOs;
using SR.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SR.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INationalities" in both code and config file together.
    [ServiceContract]
    public interface INationalities
    {
        [OperationContract]
        List<NationalityDTO> GetNationalities();

        [OperationContract]
        string PostNationality(NationalityDTO natDTO);

        [OperationContract]
        string PutNationality(NationalityDTO natDTO);

        [OperationContract]
        string DeleteNationality(int id);
    }
}
