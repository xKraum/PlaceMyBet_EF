using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventosRepository
    {
        internal List<Evento> Retrieve()
        {
            List<Evento> events = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                events = context.Eventos.ToList();
            }
            return events;
        }

        internal Evento Retrieve(int id)
        {
            Evento e = null;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                e = context.Eventos.Where(s => s.EventoId == id).FirstOrDefault();
            }
            return e;
        }

        internal void Save(Evento e)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Eventos.Add(e);
                context.SaveChanges();
            }
        }
    }
}