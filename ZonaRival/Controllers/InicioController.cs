using Microsoft.AspNetCore.Mvc;
using ZonaRival.Data;
using ZonaRival.Models;
using ZonaRival.Services;

namespace ZonaRival.Controllers
{
    public class InicioController : Controller
    {
        private readonly InicioService _inicioService;

        public InicioController(InicioService inicioService)
        {
            _inicioService = inicioService;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistroUsuario(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                _inicioService.RegistrarUsuario(usuario);
                return RedirectToAction("index", "Home");
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult RegistroEquipo(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _inicioService.RegistrarEquipo(equipo);
                return RedirectToAction("index", "Home");
            }
            return View(equipo);
        }


    }
}
