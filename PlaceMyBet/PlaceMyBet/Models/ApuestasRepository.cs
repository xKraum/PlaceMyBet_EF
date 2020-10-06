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

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM apuestas;");

            foreach (var item in dataReceived)
            {
                bets.Add(new Apuesta((int)item[0], (string)item[1], (int)item[2], (string)item[3], (double)item[4], (double)item[5], (DateTime)item[6]));
            }

            return bets;
        }

        internal Apuesta Retrieve(int id)
        {
            Apuesta b = null;

            List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM apuestas WHERE `idApuesta` = {id};");

            if (dataReceived.Count > 0)
                b = new Apuesta((int)dataReceived[0][0], (string)dataReceived[0][1], (int)dataReceived[0][2], (string)dataReceived[0][3], (double)dataReceived[0][4],
                    (double)dataReceived[0][5], (DateTime)dataReceived[0][6]);

            return b;
        }
    }
}