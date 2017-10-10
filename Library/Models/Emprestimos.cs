using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Emprestimos
    {
        public int Id { get; set; }
        public Livros Livro { get; set; }
        public Usuarios Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Boolean Devolvido { get; set; }

        public Emprestimos()
        {
                
        }

        public Emprestimos(int id, Livros livro, Usuarios usuario, DateTime dataEmprestimo, DateTime dataDevolucao, Boolean devolvido)
        {
            this.Id = id;
            this.Livro = livro;
            this.Usuario = usuario;
            this.DataEmprestimo = dataEmprestimo;
            this.DataDevolucao = dataDevolucao;
            this.Devolvido = devolvido;
        }

        //public Emprestimos(Livros livro, Usuarios usuario, DateTime dataEmprestimo, DateTime dataDevolucao)
        //{
        //    this.Livro = livro;
        //    this.Usuario = usuario;
        //    this.DataEmprestimo = dataEmprestimo;
        //    this.DataDevolucao = dataDevolucao;
        //}
    }
}
