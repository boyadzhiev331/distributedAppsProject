using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;

namespace SR.MVCWebSite.Models
{
    public class FacultiesClientModel
    {
        public FacultiesService.FacultiesClient Service { get; set; }

        public FacultiesClientModel()
        {
            this.Service = new FacultiesService.FacultiesClient();
            this.Service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                X509CertificateValidationMode.None;
            this.Service.ClientCredentials.UserName.UserName = "firstAcc";
            this.Service.ClientCredentials.UserName.Password = "qwerty1";
        }
    }
}