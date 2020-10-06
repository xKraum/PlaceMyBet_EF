﻿using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class CuentasController : ApiController
    {
        // GET: api/Cuentas
        public List<Cuenta> Get() => new CuentasRepository().Retrieve();

        // GET: api/Cuentas/5
        public Cuenta Get(int id) => new CuentasRepository().Retrieve(id);

        // POST: api/Cuentas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cuentas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cuentas/5
        public void Delete(int id)
        {
        }
    }
}
