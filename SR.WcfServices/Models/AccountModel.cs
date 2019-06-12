using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SR.WcfServices.Models
{
    public class AccountModel
    {
        private List<Account> accountList = new List<Account>();

        public AccountModel()
        {
            accountList.Add(new Account { Username = "firstAcc", Password = "qwerty1" });
            accountList.Add(new Account { Username = "secondAcc", Password = "qwerty2" });
            accountList.Add(new Account { Username = "thirdAcc", Password = "qwerty3" });
        }

        public bool Login(string username, string password)
        {
            return accountList.Count(acc => acc.Username.Equals(username) && acc.Password.Equals(password)) > 0;
        }
    }
}