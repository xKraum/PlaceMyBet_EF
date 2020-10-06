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
        public Usuario Get(int id) => new UsuariosRepository().Retrieve(id);
        //api/usuarios/0 - Al no tener una Primary Key numérica autoincrementativa se debe empezar por índice 0 (En los demás casos el primer valor empieza por índice 1).

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
