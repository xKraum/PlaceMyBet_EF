using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class CuentasRepository
    {
        internal List<Cuenta> Retrieve()
        {
            List<Cuenta> accounts = new List<Cuenta>();

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM cuentas;");

            foreach (var item in dataReceived)
            {
                accounts.Add(new Cuenta((int)item[0], (double)item[1], (string)item[2], (string)item[3]));
            }

            return accounts;
        }

        internal Cuenta Retrieve(int id)
        {
            Cuenta a = null;

            List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM cuentas WHERE `idTarjeta` = {id};");

            if (dataReceived.Count > 0)
                a = new Cuenta((int)dataReceived[0][0], (double)dataReceived[0][1], (string)dataReceived[0][2], (string)dataReceived[0][3]);

            return a;
        }
    }
}