using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public List<Apuesta> Get() => new ApuestasRepository().Retrieve();

        // GET: api/Apuestas/5
        public Apuesta Get(int id) => new ApuestasRepository().Retrieve(id);

        // POST: api/Apuestas
        //[Authorize]
        public void Post([FromBody]Apuesta bet)
        {
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
