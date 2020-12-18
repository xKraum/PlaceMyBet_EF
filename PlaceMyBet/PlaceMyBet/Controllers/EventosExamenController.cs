using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class EventosExamenController : ApiController
    {
        /*** Ejercicio 1 ***/
        // GET: api/EventosExamen?val=
        public List<Ej1> Get(string val) => new EventosExamenRepository().Retrieve(val);
        /*** Fin Ejercicio 1 ***/

        // GET: api/EventosExamen
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EventosExamen/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EventosExamen
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EventosExamen/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EventosExamen/5
        public void Delete(int id)
        {
        }
    }
}
