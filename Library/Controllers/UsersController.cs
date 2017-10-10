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
    [Route("api/Users")]
    public class UsersController : Controller
    {

        private readonly IDataService _dataService;

        public UsersController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        [HttpGet (Name="GetUsuarios")]
        public IList<Usuarios> Gett()
        {
            IList<Usuarios> usuarios = this._dataService.GetUsuarios();
            return usuarios;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public Usuarios Gett(int id)
        {
            Usuarios usuarios = this._dataService.GetUsuario(id);
            return usuarios;
        }

        public string Post([FromBody]Usuarios usuario)
        {
            this._dataService.AddUsuario(usuario);
            return "Success";
        }

        [Route("update")]
        public string Put([FromBody]Usuarios usuario)
        {
            this._dataService.UpdateUsuario(usuario);
            return "Success";

        }

        [Route("delete")]
        public string Delete([FromBody]Usuarios usuario)
        {
            this._dataService.DeleteUsuario(usuario.Id);
            return "Success";

        }
    }
}
