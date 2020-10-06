using System;
using System.Collections;
using System.Collections.Generic;
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

        //Desactivado temporalmente dado que no se puede hacer un SELECT por índice numérico.
        //internal Usuario Retrieve(int id)
        //{
        //    Usuario u = null;

        //    List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM usuarios WHERE `idEmail` = {id};");

        //    if (dataReceived.Count > 0)
        //        u = new Usuario((string)dataReceived[0][0], (string)dataReceived[0][1], (string)dataReceived[0][2], (int)dataReceived[0][3]);

        //    return u;
        //}
    }
}