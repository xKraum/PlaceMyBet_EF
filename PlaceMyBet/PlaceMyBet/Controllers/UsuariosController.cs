﻿using PlaceMyBet.Models;
using System;
using System.Collections;
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

        // GET: api/Usuarios?idEmail=example@gmail.com

        //[Authorize(Roles = "Admin")]
        //public List<BetsByEmailAndMarketTypeDTO> Get(string idEmail, double tipoMercado) => new UsuariosRepository().RetrieveBetsByEmail(idEmail, tipoMercado);
        
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
