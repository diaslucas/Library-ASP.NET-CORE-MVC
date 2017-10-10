using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;


namespace Library.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/Books")]
    public class BooksController : Controller
    {

        private readonly IDataService _dataService;

        public BooksController(IDataService dataService)
        {
            
            this._dataService = dataService;
        }

        // GET: api/Books
        [HttpGet]
        public IList<Livros> Get()
        {
            IList<Livros> livros = this._dataService.GetLivros();
            return livros;
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public Livros Get(int id)
        {
            Livros livro = this._dataService.GetLivro(id);
            return livro;
        }

        public string Post([FromBody]Livros livro)
        {
            this._dataService.AddLivro(livro);
            return "Success";
        }

        [Route("update")]
        public string Put([FromBody]Livros livro)
        {
            this._dataService.UpdateLivro(livro);
            return "Success";

        }

        [Route("delete")]
        public string Delete([FromBody]Livros livro)
        {
            this._dataService.DeleteLivro(livro.Id);
            return "Success";

        }

    }
}
