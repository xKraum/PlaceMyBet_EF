using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventosExamenRepository
    {
        /*** Ejercicio 1 ***/
        //http://localhost:50091/api/EventosExamen?val=Espanyol
        internal List<Ej1> Retrieve(string val)
        {
            List<MercadoDTOEj1> mercadosDTOEj1 = new List<MercadoDTOEj1>();
            List<Ej1> eventosEj1 = new List<Ej1>();
            List<Mercado> mercados = new List<Mercado>();
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.Where(e => e.EquipoVisitante == val || e.EquipoLocal == val).ToList();
                mercados = context.Mercados.Include(m => m.Evento).Where(e => e.Evento.EquipoVisitante == val || e.Evento.EquipoLocal == val).ToList();
            }

            foreach (var evento in eventos)
            {
                mercadosDTOEj1 = new List<MercadoDTOEj1>();
                foreach (var mercado in mercados)
                {
                    
                    if (mercado.EventoId == evento.EventoId)
                    {
                        mercadosDTOEj1.Add(new MercadoDTOEj1(mercado.MercadoId, mercado.CuotaOver, mercado.CuotaUnder));
                    }
                }
                if (evento.EquipoLocal == val)
                    eventosEj1.Add(new Ej1(evento.EquipoVisitante, mercadosDTOEj1));
                else
                    eventosEj1.Add(new Ej1(evento.EquipoLocal, mercadosDTOEj1));
            }

            return eventosEj1;
        }
        /*** Fin Ejercicio 1 ***/

        /*** Ejercicio 2 ***/
        internal void Save(Ej2 e)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                int maxEvent = context.Eventos.Max(p => p.EventoId);
                int maxMarket = context.Mercados.Max(p => p.MercadoId);
                Evento evento = new Evento(maxEvent + 1, e.EquipoLocal, e.EquipoVisitante, DateTime.Now);
                Mercado mercado = new Mercado(maxMarket + 1, e.TipoMercado, e.CuotaOver, e.CuotaUnder, e.DineroOver, e.DineroUnder, evento.EventoId);
                context.Eventos.Add(evento);
                context.Mercados.Add(mercado);
                context.SaveChanges();
            }
        }
        /*** Fin Ejercicio 2 ***/
    }
}