﻿using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public List<Evento> Get() => new EventosRepository().Retrieve();

        // GET: api/Eventos/5
        public Evento Get(int id) => new EventosRepository().Retrieve(id);

        // POST: api/Eventos
        public void Post([FromBody]Evento e) => new EventosRepository().Save(e);

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
