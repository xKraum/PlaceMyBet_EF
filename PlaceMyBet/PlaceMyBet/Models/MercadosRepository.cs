using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class MercadosRepository
    {
        internal List<Mercado> Retrieve()
        {
            List<Mercado> markets = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                markets = context.Mercados.ToList();
            }
            return markets;
        }

        internal Mercado Retrieve(int id)
        {
            Mercado m = null;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                m = context.Mercados.Where(s => s.MercadoId == id).FirstOrDefault();
            }
            return m;
        }
    }
}