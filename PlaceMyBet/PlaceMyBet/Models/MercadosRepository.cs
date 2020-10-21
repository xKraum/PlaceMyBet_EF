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

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM mercados;");

            foreach (var item in dataReceived)
            {
                markets.Add(new Mercado((int)item[0], (int)item[1], (double)item[2], (double)item[3], (double)item[4], (double)item[5], (double)item[6]));
            }

            return markets;
        }

        internal Mercado Retrieve(int id)
        {
            Mercado m = null;

            //List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM mercados WHERE `idMercado` = {id};");
            MySqlCommand commandDatabase = new MySqlCommand("SELECT * FROM mercados WHERE `idMercado` = @id;");
            commandDatabase.Parameters.AddWithValue("@id", id);
            List<ArrayList> dataReceived = Common.BBDD.GetData(commandDatabase);

            if (dataReceived.Count > 0)
                m = new Mercado((int)dataReceived[0][0], (int)dataReceived[0][1], (double)dataReceived[0][2], (double)dataReceived[0][3], (double)dataReceived[0][4],
                    (double)dataReceived[0][5], (double)dataReceived[0][6]);

            return m;
        }

        //Obtener objeto sin información sensible (ids, datos importantes, etc.)
        internal List<MercadoDTO> RetrieveDTO()
        {
            List<MercadoDTO> markets = new List<MercadoDTO>();

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM mercados;");

            foreach (var item in dataReceived)
            {
                markets.Add(new MercadoDTO((double)item[2], (double)item[3], (double)item[4]));
            }

            return markets;
        }

        internal MercadoDTO RetrieveDTO(int id)
        {
            MercadoDTO m = null;

            //List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM mercados WHERE `idMercado` = {id};");
            MySqlCommand commandDatabase = new MySqlCommand("SELECT * FROM mercados WHERE `idMercado` = @id;");
            commandDatabase.Parameters.AddWithValue("@id", id);
            List<ArrayList> dataReceived = Common.BBDD.GetData(commandDatabase);

            if (dataReceived.Count > 0)
                m = new MercadoDTO((double)dataReceived[0][2], (double)dataReceived[0][3], (double)dataReceived[0][4]);

            return m;
        }
    }
}