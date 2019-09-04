using System;
using System.Collections.Generic;
using System.Text;

namespace LJD.App.Model.ViewModels
{
    public class LoginInfo
    {
        public string ULoginName { get; set; }
        public string ULoginPwd { get; set; }
        public string Vercode { get; set; }


        public bool Remember { get; set; }
    }
}
