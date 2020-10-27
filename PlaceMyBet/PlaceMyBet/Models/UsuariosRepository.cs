﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class UsuariosRepository
    {
        internal List<Usuario> Retrieve()
        {
            List<Usuario> users = new List<Usuario>();

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM usuarios;");

            foreach (var item in dataReceived)
            {
                users.Add(new Usuario((string)item[0], (string)item[1], (string)item[2], (int)item[3]));
            }

            return users;
        }

        internal List<BetsByEmailAndMarketTypeDTO> RetrieveBetsByEmail(string idEmail, double tipoMercado)
        {
            List<BetsByEmailAndMarketTypeDTO> betsInfo = new List<BetsByEmailAndMarketTypeDTO>();

            string query = "SELECT `idEvento`, `tipoOverUnder`, `cuota`, `dineroApostado` FROM apuestas " +
                "INNER JOIN mercados ON apuestas.refMercado = mercados.idMercado " +
                "INNER JOIN eventos ON eventos.idEvento = mercados.refEvento " +
                "WHERE `refEmail` = @refEmail AND `tipoMercado` = @tipoMercado;";

            MySqlCommand commandDatabase = new MySqlCommand(query);
            commandDatabase.Parameters.AddWithValue("@refEmail", idEmail);
            commandDatabase.Parameters.AddWithValue("@tipoMercado", tipoMercado);

            List<ArrayList> dataReceived = Common.BBDD.GetData(commandDatabase);//Recibo una List de ArrayList donde cada ArrayList es una fila de datos.

            foreach (var betInfo in dataReceived)//Por cada fila de datos
            {
                betsInfo.Add(new BetsByEmailAndMarketTypeDTO((int)betInfo[0], (string)betInfo[1], (double)betInfo[2], (double)betInfo[3]));
            }

            return betsInfo;
        }

        //Desactivado (Ya funciona correctamente) Ej: api/usuarios?idEmail=example@gmail.com.
        //internal Usuario Retrieve(string idEmail)
        //{
        //    Usuario u = null;

        //    MySqlCommand commandDatabase = new MySqlCommand("SELECT * FROM usuarios WHERE `idEmail` = @idEmail;");
        //    commandDatabase.Parameters.AddWithValue("@idEmail", idEmail);

        //    List<ArrayList> dataReceived = Common.BBDD.GetData(commandDatabase);

        //    if (dataReceived.Count > 0)
        //        u = new Usuario((string)dataReceived[0][0], (string)dataReceived[0][1], (string)dataReceived[0][2], (int)dataReceived[0][3]);

        //    return u;
        //}
    }
}