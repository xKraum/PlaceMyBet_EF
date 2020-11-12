using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public Cuenta Cuenta { get; set; }

        public Usuario() { }
        public Usuario(string usuarioId, string nombre, string apellidos, int edad)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
        }
    }
}