using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
    [Produces("application/json")]
    [Route("api/Loans")]
    public class LoansController : Controller
    {
        private readonly IDataService _dataService;

        public LoansController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        [HttpGet(Name = "GetLoans")]
        public IList<Emprestimos> Get()
        {
            IList<Emprestimos> emprestimos = this._dataService.GetEmprestimos();
            return emprestimos;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetLoan")]
        public Emprestimos Get(int id)
        {
            Emprestimos emprestimos = this._dataService.GetEmprestimo(id);
            return emprestimos;
        }

        public string Post([FromBody]Emprestimos emprestimo)
        {
            this._dataService.AddEmprestimo(emprestimo);
            return "Success";
        }

        [Route("update")]
        public string Put([FromBody]Emprestimos emprestimo)
        {
            this._dataService.UpdateEmprestimo(emprestimo);
            return "Success";

        }

        [Route("delete")]
        public string Delete([FromBody]Emprestimos emprestimo)
        {
            this._dataService.DeleteEmprestimo(emprestimo.Id);
            return "Success";

        }
    }
}
