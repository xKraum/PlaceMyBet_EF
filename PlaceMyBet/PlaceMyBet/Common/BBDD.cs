﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Common
{/*
    public class BBDD
    {
        private const string connectionString = "datasource=127.0.0.1;" + "port=3306;" + "username=root;" + "password=;" + "database=placemybet;" + "SslMode=none;";

        private static bool connectionWorking;
        private static List<ArrayList> dataRows;
        public static bool ConnectionWorking => connectionWorking;
        public static List<ArrayList> DataRows => dataRows;

        //SELECT QUERIES
        /// <summary>
        /// Ejecuta una consulta de SELECT pasada por parámetro.
        /// </summary>
        /// <param name="querySQL">Parámetro SQL Query (Select).</param>
        /// <returns>Devuelve una lista que incluye un array de valores dentro de ella por cada fila encontrada al hacer el SELECT.</returns>
        public static List<ArrayList> GetData(string querySQL)
        {
            connectionWorking = true;
            dataRows = new List<ArrayList>();

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(querySQL, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            ExecuteGetDataQuery(databaseConnection, commandDatabase, dataRows);

            return dataRows;
        }

        //SELECT QUERIES PARAMETERIZED
        /// <summary>
        /// Ejecuta una consulta de SELECT parametrizada (MySqlCommand), para mayor seguridad.
        /// Se debe de cargar cada parámetro del MySqlCommand previamente. Ej: "commandDatabase.Parameters.AddWithValue("@name", "Example");"
        /// </summary>
        /// <param name="commandDatabase">Parámetro SQL Query (Select).</param>
        /// <returns>Devuelve una lista que incluye un array de valores dentro de ella por cada fila encontrada al hacer el SELECT.</returns>
        public static List<ArrayList> GetData(MySqlCommand commandDatabase)
        {
            connectionWorking = true;
            dataRows = new List<ArrayList>();

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            commandDatabase.CommandTimeout = 60;
            commandDatabase.Connection = databaseConnection;

            ExecuteGetDataQuery(databaseConnection, commandDatabase, dataRows);

            return dataRows;
        }

        private static void ExecuteGetDataQuery(MySqlConnection databaseConnection, MySqlCommand commandDatabase, List<ArrayList> dataRows)
        {
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    ArrayList data = new ArrayList();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        data.Add(reader[i]);//Add values to the ArrayList
                    }
                    dataRows.Add(data);//Add the ArrayList to the List
                }
            }
            catch
            {
                connectionWorking = false;
            }

            databaseConnection.Close();
        }


        //INSERT, UPDATE, DELETE QUERIES
        /// <summary>
        /// Ejecuta una consulta de INSERT, UPDATE o DELETE pasada por parámetro.
        /// </summary>
        /// <param name="querySQL">Parámetro SQL Query (Insert, Update, Delete).</param>
        /// <returns>Devuelve 'True' si se ha visto afectada alguna fila.</returns>
        public static bool SetData(string querySQL)
        {
            using (MySqlConnection databaseConnection = new MySqlConnection(connectionString))
            {
                MySqlCommand commandDatabase = new MySqlCommand(querySQL, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    int rowsAffected = commandDatabase.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
        }
        /*
        Añadir SetData parametrizado - PENDIENTE

        MySqlCommand commandDatabase = new MySqlCommand("INSERT INTO `tabla1` (`id`, `campo1`) VALUES (@id, @campo1)");
        commandDatabase.Parameters.AddWithValue("@id", id);
        commandDatabase.Parameters.AddWithValue("@campo1", valor1);
        
    }*/
}