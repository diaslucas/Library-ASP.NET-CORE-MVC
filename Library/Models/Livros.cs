using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Livros
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public int Quantidade { get; set; }

        public Livros()
        {
                
        }

        public Livros(int id, string nome, string autor, int quantidade) : this(nome, autor, quantidade)
        {
            this.Id = id;
        }

        public Livros(string nome, string autor, int quantidade)
        {
            this.Nome = nome;
            this.Autor = autor;
            this.Quantidade = quantidade;
        }

    }
}
