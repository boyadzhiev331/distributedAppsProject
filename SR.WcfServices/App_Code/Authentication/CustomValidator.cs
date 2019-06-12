using SR.WcfServices.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace SR.WcfServices.App_Code.Authentication
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            AccountModel accModel = new AccountModel();
            if (accModel.Login(userName, password))
            {
                return; 
            }

            throw new SecurityTokenException("Access denied!");
        }
    }
}