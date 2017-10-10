using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class EmprestimoViewModel
    {
        public int Id { get; set; }
        public List<Livros> Livros { get; set; }
        public List<Usuarios> Usuarios { get; set; }
        public int LivroId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Boolean Devolvido { get; set; }

        public EmprestimoViewModel()
        {

        }

        public EmprestimoViewModel(int id, int livroId, int usuarioId, DateTime dataEmprestimo, DateTime dataDevolucao, Boolean devolvido)
        {
            this.Id = id;
            this.LivroId = livroId;
            this.UsuarioId = usuarioId;
            this.DataEmprestimo = dataEmprestimo;
            this.DataDevolucao = dataDevolucao;
            this.Devolvido = devolvido;
        }

        public EmprestimoViewModel(List<Livros> livros, List<Usuarios> usuarios)
        {
            this.Livros = livros;
            this.Usuarios = usuarios;

        }

        public EmprestimoViewModel(int id, int livroId, int usuarioId, DateTime dataEmprestimo, DateTime dataDevolucao, List<Livros> livros, List<Usuarios> usuarios)
        {
            this.Id = id;
            this.LivroId = livroId;
            this.UsuarioId = usuarioId;
            this.DataEmprestimo = dataEmprestimo;
            this.DataDevolucao = dataDevolucao;
            this.Livros = livros;
            this.Usuarios = usuarios;
        }


    }
}
