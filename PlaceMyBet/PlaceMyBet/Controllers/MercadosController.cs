using PlaceMyBet.Models;
using System;
using System.Collections;
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
        public List<MercadoDTO> Get() => new MercadosRepository().RetrieveDTO();

        // GET: api/Mercados/5
        public Mercado Get(int id) => new MercadosRepository().Retrieve(id);//No pide DTO (aunque está implementado el método).

        // POST: api/Mercados
        public void Post([FromBody] Mercado mercado) => new MercadosRepository().Save(mercado);

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]Mercado mercado)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
