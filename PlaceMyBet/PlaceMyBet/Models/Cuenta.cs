using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Cuenta
    {
        private int idTarjeta;
        private double saldo;
        private string nombreBanco;
        private string refEmail;

        public int IdTarjeta { get => idTarjeta; set => idTarjeta = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string NombreBanco { get => nombreBanco; set => nombreBanco = value; }
        public string RefEmail { get => refEmail; set => refEmail = value; }

        public Cuenta(int idTarjeta, double saldo, string nombreBanco, string refEmail)
        {
            this.idTarjeta = idTarjeta;
            this.saldo = saldo;
            this.nombreBanco = nombreBanco;
            this.refEmail = refEmail;
        }
    }
}