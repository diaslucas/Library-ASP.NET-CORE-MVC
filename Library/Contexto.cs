using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Contexto : DbContext
    {
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Emprestimos> Emprestimos { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
