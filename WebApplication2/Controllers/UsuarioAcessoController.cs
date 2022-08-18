using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2;
using WebApplication2.facade;

namespace WebApplication2.Controllers
{
    public class UsuarioAcessoController : Controller
    {
        private readonly db_projetoEntities db = new db_projetoEntities();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioAcesso user)
        {
            using(var context = new db_projetoEntities())
            {
                user.dsSenha = FcUsuarioAcesso.md5Encrypt(user.dsSenha);

                var objUser = context.UsuarioAcesso.Where(a => a.dsEmail == user.dsEmail && a.dsSenha == user.dsSenha)
                    .FirstOrDefault();

                if (objUser != null)
                {
                    FormsAuthentication.SetAuthCookie(user.nmLogin, false);

                    Session["idUsuario"] = objUser.idUsuario;
                    Session["idEmpresa"] = objUser.idEmpresa;


                    return RedirectToAction("Index", "Empresa");
                }

                ModelState.AddModelError("", "Usuário ou senha incorretos");
                return View();
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(UsuarioAcesso user)
        {
            using (db)
            {
                // Criptografando senha em MD5
                user.dsSenha = FcUsuarioAcesso.md5Encrypt(user.dsSenha);

                db.UsuarioAcesso.Add(user);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
