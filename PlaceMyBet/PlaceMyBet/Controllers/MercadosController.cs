using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public List<MercadoDTO> Get() => new MercadosRepository().RetrieveDTO(); //new MercadosRepository().Retrieve();

        // GET: api/Mercados/5
        public MercadoDTO Get(int id) => new MercadosRepository().RetrieveDTO(id); //new MercadosRepository().Retrieve(id);

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
