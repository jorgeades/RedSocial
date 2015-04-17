using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RedSocial.Servicios;
using RedSocialApi.Models;

namespace RedSocial.Controllers
{
    public class AutenticacionController : Controller
    {
        // GET: Autenticacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario model)
        {

            var srv = new BaseServicios<Usuario>("http://localhost:1544/api/Usuarios");
            var param = new Dictionary<String, object>()
            {
                {"login", model.login},
                {"password", model.password}
            };

            var u = srv.Get(param);

            if (u != null)
            {
                var identity = new GenericIdentity(u.nombre);
                
                var provider = new GenericPrincipal(identity, new string[] {});
                
                HttpContext.User = provider;

                Session["usuario"] = u;

            }

            else
            {
                return View(model);
            }
   
            return View("Index","Home");

        }

        public ActionResult Registro()
        {
            return View(new Usuario());

        }

        [HttpPost]
        public async Task<ActionResult> Registro(Usuario model)
        {
            var srv = new BaseServicios<Usuario>("http://localhost:1544/api/Usuarios");

            try
            {
               await srv.Add(model);
            }
            catch (Exception e)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }


    }

}