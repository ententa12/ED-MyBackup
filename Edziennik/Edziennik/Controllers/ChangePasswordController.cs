using Edziennik.BLL;
using Edziennik.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edziennik.Controllers
{
    public class ChangePasswordController : Controller
    {
        DatabaseLogic db;
        public ChangePasswordController()
        {
            db = new DatabaseLogic();
        }
        // test
        public ActionResult Index()
        {
            return View(Index("{\"Id\":\"1\",\"password\":\"aaa\",\"confirmedPassword\":\"aaa\"}"));
        }

        [HttpPost]
        public string Index(string jsonString)
        {
            ChangePasswordViewModel changePasswordWiev = JsonConvert.DeserializeObject<ChangePasswordViewModel>(jsonString);
            var login = db.GetPerson(changePasswordWiev.Id).Login;
            if (login!=null)
            {
                if (changePasswordWiev.Password == changePasswordWiev.ConfirmedPassword)
                {
                    login.Password = PasswordManager.GetMd5Hash(changePasswordWiev.Password);
                    db.ChangePassword(login);
                    return "Zmieniono Hasło";
                }
                else return "Hasła nie zgadzają się";
            }
            return "Nie zmieniono hasła";
        }
    }
}