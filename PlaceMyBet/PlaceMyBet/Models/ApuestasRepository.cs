using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestasRepository
    {
        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> bets = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                bets = context.Apuestas.Include(m => m.Mercado).ToList();
            }
            return bets;
        }

        internal Apuesta Retrieve(int id)
        {
            Apuesta bet = null;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                bet = context.Apuestas.Where(s => s.ApuestaId == id).FirstOrDefault();
            }
            return bet;
        }

        internal void Save(Apuesta bet)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //Completar datos faltantes de la apuesta
                Mercado mercado = new MercadosRepository().Retrieve(bet.MercadoId);
                bet.TipoMercado = mercado.TipoMercado;
                if (bet.TipoOverUnder == "Over")
                    bet.Cuota = mercado.CuotaOver;
                else
                    bet.Cuota = mercado.CuotaUnder;
                bet.Fecha = DateTime.Now;

                //Insertar apuesta (dinero apostado, tipo de mercado...)
                context.Apuestas.Add(bet);
                context.SaveChanges();

                //Actualizar/Añadir el dinero Over o Under en mercados antes de actualizar la cuota.
                if (bet.TipoOverUnder == "Over")
                    new MercadosRepository().UpdateMoney(bet.MercadoId, bet.DineroApostado, 0);
                else
                    new MercadosRepository().UpdateMoney(bet.MercadoId, 0, bet.DineroApostado);

                //Refrescar objeto MERCADO para que tengo el dinero apostado actualizado.
                Mercado market = new MercadosRepository().Retrieve(bet.MercadoId);

                //Recálculo de las cuotas Over y Under
                double newQuotaOver = CalculateQuota(market, true);
                double newQuotaUnder = CalculateQuota(market, false);

                //Insertar las nuevas cuotas en MERCADOS.
                new MercadosRepository().UpdateQuota(market.MercadoId, newQuotaOver, newQuotaUnder);
            }
        }

        private double CalculateQuota(Mercado market, bool isOver)
        {
            double probability;

            if (isOver)
                probability = market.DineroOver / (market.DineroOver + market.DineroUnder);
            else
                probability = market.DineroUnder / (market.DineroOver + market.DineroUnder);

            return (double)Decimal.Round((decimal)(1 / probability * 0.95), 2);
        }

        private ApuestaDTO ToDTO(Apuesta bet, Mercado market) => new ApuestaDTO(bet.UsuarioId, market.EventoId, bet.TipoOverUnder, bet.Cuota, bet.DineroApostado);

        internal List<ApuestaDTO> RetrieveDTO()
        {
            List<Apuesta> bets = new List<Apuesta>();
            List<ApuestaDTO> betsDTO = new List<ApuestaDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                bets = context.Apuestas.Include(m => m.Mercado).ToList();
            }
            foreach (var bet in bets)
            {
                //betsDTO.Add(new ApuestaDTO(bet.UsuarioId, bet.Mercado.EventoId, bet.TipoOverUnder, bet.Cuota, bet.DineroApostado));
                betsDTO.Add(ToDTO(bet, bet.Mercado));
            }
            return betsDTO;
        }

        internal ApuestaDTO RetrieveDTO(int id)
        {
            Apuesta bet = null;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                bet = context.Apuestas.Where(s => s.ApuestaId == id).Include(m => m.Mercado).FirstOrDefault();
            }
            return ToDTO(bet, bet.Mercado);
        }

        private ApuestaPMM_DTO ToBackofficeDTO(Apuesta bet, Mercado market) => new ApuestaPMM_DTO(bet.TipoOverUnder, bet.Cuota, bet.DineroApostado, 
            bet.Fecha, bet.ApuestaId, bet.TipoMercado, bet.MercadoId, bet.UsuarioId, market.EventoId);

        internal List<ApuestaPMM_DTO> RetrieveToBackoffice()
        {
            List<Apuesta> bets = new List<Apuesta>();
            List<ApuestaPMM_DTO> betsDTO = new List<ApuestaPMM_DTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                bets = context.Apuestas.Include(m => m.Mercado).ToList();
            }
            foreach (var bet in bets)
            {
                betsDTO.Add(ToBackofficeDTO(bet, bet.Mercado));
            }
            return betsDTO;
        }
    }
}