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
                bets = context.Apuestas.ToList();
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

        //private double CalculateQuota(Apuesta bet, Mercado market, bool isOver)
        //{
        //    double probability;

        //    if (isOver)
        //        probability = market.DineroOver / (market.DineroOver + market.DineroUnder);
        //    else
        //        probability = market.DineroUnder / (market.DineroOver + market.DineroUnder);

        //    return 1 / probability * 0.95;
        //}
    }
}