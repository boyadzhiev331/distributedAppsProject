using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;

namespace SR.MVCWebSite.Models
{
    public class NationalitiesClientModel
    {
        public NationalitiesService.NationalitiesClient Service { get; set; }

        public NationalitiesClientModel()
        {
            this.Service = new NationalitiesService.NationalitiesClient();
            this.Service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                X509CertificateValidationMode.None;
            this.Service.ClientCredentials.UserName.UserName = "firstAcc";
            this.Service.ClientCredentials.UserName.Password = "qwerty1";
        }
    }
}