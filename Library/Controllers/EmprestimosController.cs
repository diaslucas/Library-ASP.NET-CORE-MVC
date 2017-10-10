using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Models.ViewModels;

namespace Library.Controllers
{
    public class EmprestimosController : Controller
    {

        private readonly IDataService _dataService;

        public EmprestimosController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        public IActionResult Lista()
        {
            List<Emprestimos> emprestimos = _dataService.GetEmprestimosNaoDevolvidos();
            return View(emprestimos);
        }


        public IActionResult ListaTodos()
        {
            List<Emprestimos> emprestimos = _dataService.GetEmprestimos();
            return View(emprestimos);
        }


        public IActionResult Cadastro(int id)
        {
            if(id > 0)
            {
                var emprestimo = this._dataService.GetEmprestimo(id);
                EmprestimoViewModel viewModel = GetEmprestimoViewModelEdicao(emprestimo);
                return View(viewModel);
            }
            else
            {
                EmprestimoViewModel viewModel = GetEmprestimoViewModelAdicao();
                return View(viewModel);
            }
            
        }

        private ListaEmprestimoViewModel GetListaEmprestimoViewModel()
        {
            var emprestimos = this._dataService.GetEmprestimos();
            ListaEmprestimoViewModel viewModel = new ListaEmprestimoViewModel();
            return viewModel;
        }

        private EmprestimoViewModel GetEmprestimoViewModelAdicao()
        {
            List<Livros> livros = this._dataService.GetLivros();
            List<Usuarios> usuarios = this._dataService.GetUsuarios();

            EmprestimoViewModel viewModel = new EmprestimoViewModel(livros, usuarios);
            return viewModel;
        }

        private EmprestimoViewModel GetEmprestimoViewModelEdicao(Emprestimos emprestimo)
        {
            List<Livros> livros = this._dataService.GetLivros();
            List<Usuarios> usuarios = this._dataService.GetUsuarios();
            EmprestimoViewModel emprestimoViewModel = new EmprestimoViewModel();
            emprestimoViewModel.Id = emprestimo.Id;
            emprestimoViewModel.LivroId = emprestimo.Livro.Id;
            emprestimoViewModel.UsuarioId = emprestimo.Usuario.Id;
            emprestimoViewModel.DataEmprestimo = emprestimo.DataEmprestimo;
            emprestimoViewModel.DataDevolucao = emprestimo.DataDevolucao;
            emprestimoViewModel.Devolvido = emprestimo.Devolvido;
            emprestimoViewModel.Livros = livros;
            emprestimoViewModel.Usuarios = usuarios;
            return emprestimoViewModel;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(EmprestimoViewModel emprestimoViewModel)
        {
            if (ModelState.IsValid)
            {
                Livros livro = _dataService.GetLivro(emprestimoViewModel.LivroId);

                if (emprestimoViewModel.Devolvido)
                {
                    this._dataService.AumentarQuantidadeLivro(emprestimoViewModel.LivroId);
                }
                else
                {
                    if (livro.Quantidade < 1)
                    {
                        ViewBag.Error = "This book cannot be borrowred because it's out of stock.";
                        EmprestimoViewModel viewModel = GetEmprestimoViewModelAdicao();
                        return View(viewModel);
                    }
                    else
                    {
                        this._dataService.DiminuirQuantidadeLivro(emprestimoViewModel.LivroId);
                    }
                }

                if(emprestimoViewModel.Id > 0)
                {
                    Usuarios usuario = _dataService.GetUsuario(emprestimoViewModel.UsuarioId);
                    Emprestimos emprestimo = new Emprestimos(emprestimoViewModel.Id, livro, usuario, emprestimoViewModel.DataEmprestimo, emprestimoViewModel.DataDevolucao, emprestimoViewModel.Devolvido);
                    _dataService.UpdateEmprestimo(emprestimo);
                }
                else
                {
                    Usuarios usuario = _dataService.GetUsuario(emprestimoViewModel.UsuarioId);
                    Emprestimos emprestimo = new Emprestimos(emprestimoViewModel.Id, livro, usuario, emprestimoViewModel.DataEmprestimo, emprestimoViewModel.DataDevolucao, emprestimoViewModel.Devolvido);
                    _dataService.AddEmprestimo(emprestimo);
                }
                return RedirectToAction("Lista");
            }
            else
            {
                return View();
            }
            
        }


        public int DeleteEmprestimo([FromBody]int emprestimoId)
        {
            var emprestimo = this._dataService.GetEmprestimo(emprestimoId);
            if (emprestimo.Devolvido)
            {
                this._dataService.DeleteEmprestimo(emprestimoId);
                return 0;
            }
            else
            {
                return 1;
            }
            
        }
    }
}