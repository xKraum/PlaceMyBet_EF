using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        private string idEmail;
        private string nombre;
        private string apellidos;
        private int edad;

        public string IdEmail { get => idEmail; set => idEmail = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }

        public Usuario(string idEmail, string nombre, string apellidos, int edad)
        {
            this.idEmail = idEmail;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }
    }
}