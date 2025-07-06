using Alphtmost.Modelos;
using AlphtmostAPI.Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Alphtmost.MVC.Controllers
{
    public class UsuarioClientesController : Controller
    {
        // GET: UsuarioClientesController
        public ActionResult Index()
        {
            var data  = Crud<UsuarioCliente>.GetAll();
            return View(data);
        }
        // GET: UsuarioClientesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<UsuarioCliente>.GetById(id);
            return View(data);
        }

        // GET: UsuarioClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioCliente data)
        {
            try
            {
                Crud<UsuarioCliente>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al crear el usuario: {ex.Message}");
                return View(data);
            }
        }

        // GET: UsuarioClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<UsuarioCliente>.GetById(id);

            return View(data);
        }

        // POST: UsuarioClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioCliente data)
        {
            try
            {
                Crud<UsuarioCliente>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error al editar el usuario: {ex.Message}");
                return View(data);
            }
                    
        }

        // GET: UsuarioClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<UsuarioCliente>.GetById(id);
            return View(data);
        }

        // POST: UsuarioClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioCliente data)
        {
            try
            {
                Crud<UsuarioCliente>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al eliminar el usuario: {ex.Message}");
                {
                    return View(data);
                }
            }
        }
    }
}
