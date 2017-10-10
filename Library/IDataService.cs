using Library.Models;
using System.Collections.Generic;

namespace Library
{
    public interface IDataService
    {
        void InicializaDB();
        List<Livros> GetLivros();
        Livros GetLivro(int livroId);
        void AddLivro(Livros livro);
        void UpdateLivro(Livros livro);
        void DeleteLivro(int livroId);
        List<Usuarios> GetUsuarios();
        Usuarios GetUsuario(int usuarioId);
        void AddUsuario(Usuarios usuario);
        void UpdateUsuario(Usuarios usuario);
        void DeleteUsuario(int usuarioId);
        List<Emprestimos> GetEmprestimos();
        Emprestimos GetEmprestimo(int emprestimoId);
        Emprestimos GetEmprestimoIncludingLivro(int emprestimoId);
        void AddEmprestimo(Emprestimos emprestimo);
        void UpdateEmprestimo(Emprestimos emprestimo);
        void DeleteEmprestimo(int emprestimoId);
        void DiminuirQuantidadeLivro(int livroId);
        void AumentarQuantidadeLivro(int livroId);
        List<Emprestimos> GetEmprestimosNaoDevolvidos();
    }
}