using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuth
{
    public class CustomerSecurity
    {

      
        public static bool Login(string userName, string passowrd)
        {

            //Please use database values to validate the userName and Password
            if (userName == "Brian" && passowrd == "1234")

                return true;
            else
                return false;
        }

    }
}