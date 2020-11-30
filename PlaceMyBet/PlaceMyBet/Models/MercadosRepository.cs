using Microsoft.EntityFrameworkCore;
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
        //Retrieves with All Data
        internal List<Mercado> Retrieve()
        {
            List<Mercado> markets = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                markets = context.Mercados.ToList();
                //markets = context.Mercados.Include(e => e.Evento).Include(a => a.Apuestas).ToList();
            }
            return markets;
        }

        internal Mercado Retrieve(int id)
        {
            Mercado m = null;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                m = context.Mercados.Where(s => s.MercadoId == id).FirstOrDefault();
                //m = context.Mercados.Where(db => db.MercadoId == id).Include(e => e.Evento).FirstOrDefault();
            }
            return m;
        }

        //Retrieves with DTO
        private MercadoDTO ToDTO(Mercado m) => new MercadoDTO(m.TipoMercado, m.CuotaOver, m.CuotaUnder);

        internal List<MercadoDTO> RetrieveDTO()
        {
            List<Mercado> markets = new List<Mercado>();
            List<MercadoDTO> marketsDTO = new List<MercadoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                markets = context.Mercados.ToList();
            }
            foreach (var m in markets)
            {
                marketsDTO.Add(new MercadoDTO(m.TipoMercado, m.CuotaOver, m.CuotaUnder));
            }
            return marketsDTO;
        }

        internal MercadoDTO RetrieveDTO(int id)
        {
            Mercado m = null;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                m = context.Mercados.Where(s => s.MercadoId == id).FirstOrDefault();
            }
            return ToDTO(m);
        }

        internal void Save(Mercado market)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Mercados.Add(market);
                context.SaveChanges();
            }
        }

        internal void UpdateMoney(int marketId, double dineroOver, double dineroUnder)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Mercado dbMarket = context.Mercados.Where(m => m.MercadoId == marketId).FirstOrDefault();
                dbMarket.DineroOver += dineroOver;
                dbMarket.DineroUnder += dineroUnder;
                context.SaveChanges();
            }
        }

        internal void UpdateQuota(int marketId, double newQuotaOver, double newQuotaUnder)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Mercado dbMarket = context.Mercados.Where(m => m.MercadoId == marketId).FirstOrDefault();
                dbMarket.CuotaOver = newQuotaOver;
                dbMarket.CuotaUnder = newQuotaUnder;
                context.SaveChanges();
            }
        }
    }
}