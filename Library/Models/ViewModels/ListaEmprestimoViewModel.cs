using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class ListaEmprestimoViewModel
    {
        public List<Emprestimos> Emprestimos { get; set; }
        public Livros Livro { get; set; }

        public ListaEmprestimoViewModel()
        {

        }

    }
}
