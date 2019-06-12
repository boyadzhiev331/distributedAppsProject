using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;

namespace SR.MVCWebSite.Models
{
    public class StudentsClientModel
    {
        public StudentsService.StudentsClient Service { get; set; }

        public StudentsClientModel()
        {
            this.Service = new StudentsService.StudentsClient();
            this.Service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = 
                X509CertificateValidationMode.None;
            this.Service.ClientCredentials.UserName.UserName = "firstAcc";
            this.Service.ClientCredentials.UserName.Password = "qwerty1";
        }
    }
}