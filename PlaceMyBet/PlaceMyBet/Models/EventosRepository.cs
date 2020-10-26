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
        #region FullRetrieves - Obtienen información sensible como la ID - (Fuera de uso)
        internal List<Evento> Retrieve()
        {
            List<Evento> events = new List<Evento>();

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM eventos;");

            foreach (var item in dataReceived)
            {
                events.Add(new Evento((int)item[0], (string)item[1], (string)item[2], (DateTime)item[3]));
            }

            return events;
        }

        internal Evento Retrieve(int id)
        {
            Evento e = null;

            //List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM eventos WHERE `idEvento` = {id};");
            MySqlCommand commandDatabase = new MySqlCommand("SELECT * FROM eventos WHERE `idEvento` = @id;");
            commandDatabase.Parameters.AddWithValue("@id", id);
            List<ArrayList> dataReceived = Common.BBDD.GetData(commandDatabase);

            if (dataReceived.Count > 0)
                e = new Evento((int)dataReceived[0][0], (string)dataReceived[0][1], (string)dataReceived[0][2], (DateTime)dataReceived[0][3]);

            return e;
        }
        #endregion

        //Obtener objeto sin información sensible (ids, datos importantes, etc.)
        internal List<EventoDTO> RetrieveDTO()
        {
            List<EventoDTO> events = new List<EventoDTO>();

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM eventos;");

            foreach (var item in dataReceived)
            {
                events.Add(new EventoDTO((string)item[1], (string)item[2], (DateTime)item[3]));
            }

            return events;
        }

        internal EventoDTO RetrieveDTO(int id)
        {
            EventoDTO e = null;

            //List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM eventos WHERE `idEvento` = {id};");
            MySqlCommand commandDatabase = new MySqlCommand("SELECT * FROM eventos WHERE `idEvento` = @id;");
            commandDatabase.Parameters.AddWithValue("@id", id);
            List<ArrayList> dataReceived = Common.BBDD.GetData(commandDatabase);

            if (dataReceived.Count > 0)
                e = new EventoDTO((string)dataReceived[0][1], (string)dataReceived[0][2], (DateTime)dataReceived[0][3]);

            return e;
        }

        internal List<Mercado> RetrieveByEventAndMarketType(int id, double tipoMercado)
        {
            List<Mercado> markets = new List<Mercado>();

            MySqlCommand commandDatabase = new MySqlCommand("SELECT * FROM mercados WHERE `refEvento`=@refEvento AND `tipoMercado`=@tipoMercado;");
            commandDatabase.Parameters.AddWithValue("@refEvento", id);
            commandDatabase.Parameters.AddWithValue("@tipoMercado", tipoMercado);

            List<ArrayList> dataReceived = Common.BBDD.GetData(commandDatabase);

            foreach (var item in dataReceived)
            {
                markets.Add(new Mercado((int)item[0], (int)item[1], (double)item[2], (double)item[3], (double)item[4], (double)item[5], (double)item[6]));
            }

            return markets;
        }
    }
}