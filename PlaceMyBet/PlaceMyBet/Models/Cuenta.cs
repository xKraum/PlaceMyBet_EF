using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public double Saldo { get; set; }
        public string NombreBanco { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cuenta() { }
        public Cuenta(int cuentaId, double saldo, string nombreBanco, string usuarioId)
        {
            CuentaId = cuentaId;
            Saldo = saldo;
            NombreBanco = nombreBanco;
            UsuarioId = usuarioId;
        }
    }
}