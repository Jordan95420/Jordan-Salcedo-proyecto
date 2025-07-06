using Alphtmost.Modelos;
using Alphtmost.Servicios.VistasModelos;
using AlphtmostAPI.Consumer;
using Microsoft.AspNetCore.Mvc;

namespace Alphtmost.MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(LoginViewModel modelLogin)
        //{
        //    var clientes= Crud<UsuarioCliente>.GetAll();
        //    var admins = Crud<Administrador>.GetAll();
        //    var artistaCliente = Crud<ArtistaCliente>.GetAll();

        //    if(ModelState.IsValid)
        //    {
                
        //        var cliente = clientes.FirstOrDefault(c => c.Email == modelLogin.Email && c.ContraseñaHash == modelLogin.Contraseña);
        //        var admin = admins.FirstOrDefault(a => a.Email == modelLogin.Email && a.ContraseñaHash == modelLogin.Contraseña);
        //        if (cliente !=null);
        //        {
        //            // Redirigir a la página de la musica
        //            return RedirectToAction("Views\\Home\\Index.cshtml", "UsuarioClientes");
        //        }
        //        else if (admins !=null)
        //        {
        //            // Redirigir a la página de administrador
        //            return RedirectToAction("Index", "Administrador");
        //        }
        //        else if (artistaCliente.Any(ac => ac.Email == modelLogin.Email && ac.ContraseñaHash == modelLogin.Contraseña))
        //        {
        //            // Redirigir a la página de artista cliente
        //            return RedirectToAction("Index", "ArtistaClientes");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Credenciales inválidas.");
        //        }
        //    }



        //}
    }
}
