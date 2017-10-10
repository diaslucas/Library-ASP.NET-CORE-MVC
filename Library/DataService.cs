using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class DataService : IDataService
    {
        private readonly Contexto _contexto;
        public DataService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public void InicializaDB()
        {
            this._contexto.Database.EnsureCreated();
            if (this._contexto.Livros.Count() == 0)
            {
                List<Livros> livros = new List<Livros>
                {
                    new Livros("Harry Potter", "J.K. Rowling", 15),
                    new Livros("Clean Code", "Joaseph K.", 5),
                    new Livros("Strength Training Anatomy", "Frederic Delavier", 6),
                    new Livros("1984", "George Orwell", 10)
                };

                foreach (var livro in livros)
                {
                    this._contexto.Livros.Add(livro);
                    this._contexto.SaveChanges();
                }
            }
        }

        public List<Livros> GetLivros()
        {
            return this._contexto.Livros.ToList();
        }

        public void AddLivro(Livros livro)
        {
            this._contexto.Livros.Add(livro);
            this._contexto.SaveChanges();
        }

        public void UpdateLivro(Livros livro)
        {
            this._contexto.Livros.Update(livro);
            this._contexto.SaveChanges();
        }

        public void DeleteLivro(int livroId)
        {
            var livroDB = GetLivro(livroId);
            this._contexto.Remove(livroDB);
            this._contexto.SaveChanges();
        }

        public Livros GetLivro(int livroId)
        {
            return this._contexto.Livros.Where(l => l.Id == livroId).Single();
        }


        public List<Usuarios> GetUsuarios()
        {
            return this._contexto.Usuarios.ToList();
        }

        public void AddUsuario(Usuarios usuario)
        {
            this._contexto.Usuarios.Add(usuario);
            this._contexto.SaveChanges();
        }

        public Usuarios GetUsuario(int usuarioId)
        {
            return this._contexto.Usuarios.Where(u => u.Id == usuarioId).Single();
        }

        public void UpdateUsuario(Usuarios usuario)
        {
            this._contexto.Usuarios.Update(usuario);
            this._contexto.SaveChanges();
        }

        public void DeleteUsuario(int usuarioId)
        {
            var usuarioDB = GetUsuario(usuarioId);
            this._contexto.Usuarios.Remove(usuarioDB);
            this._contexto.SaveChanges();
        }

        public List<Emprestimos> GetEmprestimos()
        {
            return this._contexto.Emprestimos.Include(e => e.Livro).Include(e => e.Usuario).ToList();
        }

        public void AddEmprestimo(Emprestimos emprestimo)
        {
            this._contexto.Emprestimos.Add(emprestimo);
            this._contexto.SaveChanges();
        }

        public Emprestimos GetEmprestimo(int emprestimoId)
        {
            return this._contexto.Emprestimos.Where(e => e.Id == emprestimoId).Single();
        }

        public Emprestimos GetEmprestimoIncludingLivro(int emprestimoId)
        {
            return this._contexto.Emprestimos.Where(e => e.Id == emprestimoId).Include(e => e.Livro).Single();
        }


        public void UpdateEmprestimo(Emprestimos emprestimo)
        {
            this._contexto.Emprestimos.Update(emprestimo);
            this._contexto.SaveChanges();
        }

        public void DeleteEmprestimo(int emprestimoId)
        {
            var empretimoDB = GetEmprestimo(emprestimoId);
            this._contexto.Remove(empretimoDB);
            this._contexto.SaveChanges();
        }

        public void DiminuirQuantidadeLivro(int livroId)
        {
            var livroDB = GetLivro(livroId);
            livroDB.Quantidade--;
            UpdateLivro(livroDB);
        }

        public void AumentarQuantidadeLivro(int livroId)
        {
            var livroDB = GetLivro(livroId);
            livroDB.Quantidade++;
            UpdateLivro(livroDB);
        }

        public List<Emprestimos> GetEmprestimosNaoDevolvidos()
        {
            return this._contexto.Emprestimos.Where(e => e.Devolvido == false).Include(e => e.Livro).Include(e => e.Usuario).ToList();
        }
    }
}
