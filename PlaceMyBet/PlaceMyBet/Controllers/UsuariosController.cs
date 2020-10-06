using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public List<Usuario> Get() => new UsuariosRepository().Retrieve();

        // GET: api/Usuarios/5
        public string Get(int id) => /*new UsuariosRepository().Retrieve(id);*/"Null (temp)";
        //De momento lo dejo devolviendo un string porque la Primary Key de Usuario
        //es un string y no se puede acceder mediante su índice.

        // POST: api/Usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
