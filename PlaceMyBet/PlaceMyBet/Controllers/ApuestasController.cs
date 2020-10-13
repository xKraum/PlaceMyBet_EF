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
        public List<ApuestaDTO> Get() => new ApuestasRepository().RetrieveDTO(); //new ApuestasRepository().Retrieve();

        // GET: api/Apuestas/5
        public ApuestaDTO Get(int id) => new ApuestasRepository().RetrieveDTO(id); //new ApuestasRepository().Retrieve(id);

        // POST: api/Apuestas
        public void Post([FromBody]string value)
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
