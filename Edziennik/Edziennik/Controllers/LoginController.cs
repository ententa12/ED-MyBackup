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
    public class LoginController : Controller
    {
        DatabaseLogic db;
        public LoginController()
        {
            db = new DatabaseLogic();
        }
        //testowe
        public ActionResult Index()
        {
            return View(Index("{\"login\":\"ententa12@gmail.com\",\"password\":\"iXSKp?@y\"}"));
        }

        [HttpPost]
        public string Index(string loginData)
        {
            LoginViewModel loginView = JsonConvert.DeserializeObject<LoginViewModel>(loginData);
            Login login = db.GetLogin(loginView.Login);

            if (login!=null)
            {
                if (login.Password == PasswordManager.GetMd5Hash(loginView.Password)) return JsonConvert.SerializeObject(new {
                    id = login.Person.ID_Person,
                    status = login.Person.Status
                });
            }
            return JsonConvert.SerializeObject(new
            {
                id = -1,
                status = "NoOne"
            });
        }
        //test
        public ActionResult ResetPassword()
        {
            return View(ResetPassword("{\"login\":\"ententa12@gmail.com\",\"password\":\"iXSKp?@y\"}"));
        }

        [HttpPost]
        public string ResetPassword(string loginData)
        {
            LoginViewModel loginView = JsonConvert.DeserializeObject<LoginViewModel>(loginData);
            Login login = db.GetLogin(loginView.Login);

            if (login != null)
            {
                var newPassword = PasswordManager.CreateRandomPassword();
                login.Password = PasswordManager.GetMd5Hash(newPassword);
                db.ChangePassword(login);
                SenderEmail sm = new SenderEmail(loginView.Login, $"Hasło zostało zmienione na: {newPassword}\nPo ponownym zalogowaniu zaleca się " +
                    $"zmianę hasła", "Zmiana Hasła");
                sm.SendEmail();
                return "Hasło zmienione";
            }
            return "Hasło nie zmienione";
        }


    }
}