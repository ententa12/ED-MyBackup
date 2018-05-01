using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edziennik.Models
{
    public class ChangePasswordWievModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }

    }
}