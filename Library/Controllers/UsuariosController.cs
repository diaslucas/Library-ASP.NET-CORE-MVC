using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IDataService _dataService;

        public UsuariosController(IDataService dataService)
        {
            this._dataService = dataService;
        }


        public IActionResult Lista()
        {
            List<Usuarios> usuarios = this._dataService.GetUsuarios();
            return View(usuarios);
        }

        
        public IActionResult Cadastro(int id)
        {
            if (id > 0)
            {
                Usuarios usuario = this._dataService.GetUsuario(id);
                return View(usuario);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Id > 0)
                {
                    this._dataService.UpdateUsuario(usuario);
                }
                else
                {
                    this._dataService.AddUsuario(usuario);
                }

                return RedirectToAction("Lista");
            }
            else
            {
                return View();
            }
        }

        public void DeleteUsuario([FromBody]int usuarioId)
        {
            this._dataService.DeleteUsuario(usuarioId);
        }


    }
}