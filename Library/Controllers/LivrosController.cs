using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class LivrosController : Controller
    {

        private readonly IDataService _dataService;

        public LivrosController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        public IActionResult Lista()
        {
            List<Livros> livros = _dataService.GetLivros();
            return View(livros);
        }

        [HttpGet]
        public IActionResult Cadastro(int id)
        {
            if (id > 0)
            {
                Livros livro = this._dataService.GetLivro(id);
                return View(livro);
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Livros livro)
        {
            if (ModelState.IsValid)
            {
                if (livro.Id > 0)
                {
                    this._dataService.UpdateLivro(livro);
                }
                else
                {
                    this._dataService.AddLivro(livro);
                }
                
                return RedirectToAction("Lista");
            }
            else
            {
                return View();
            }
        }

        public void DeleteLivro([FromBody]int livroId)
        {
            this._dataService.DeleteLivro(livroId);
        }



    }
}
