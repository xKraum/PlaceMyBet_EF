using MySql.Data.MySqlClient;
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
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                users = context.Usuarios.ToList();
            }
            return users;
        }

        internal void Remove(string UsuarioId)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Usuario u = context.Usuarios.Where(x => x.UsuarioId == UsuarioId).FirstOrDefault();
                if (u != null)
                    context.Usuarios.Remove(u);
                context.SaveChanges();
            }
        }
    }
}