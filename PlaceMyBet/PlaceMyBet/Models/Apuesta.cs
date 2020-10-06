using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        private int idApuesta;
        private string refEmail;
        private int refMercado;
        private string tipoOverUnder;
        private double cuota;
        private double dineroApostado;
        private DateTime fecha;

        public int IdApuesta { get => idApuesta; set => idApuesta = value; }
        public string RefEmail { get => refEmail; set => refEmail = value; }
        public int RefMercado { get => refMercado; set => refMercado = value; }
        public string TipoOverUnder { get => tipoOverUnder; set => tipoOverUnder = value; }
        public double Cuota { get => cuota; set => cuota = value; }
        public double DineroApostado { get => dineroApostado; set => dineroApostado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }

        public Apuesta(int idApuesta, string refEmail, int refMercado, string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha)
        {
            this.idApuesta = idApuesta;
            this.refEmail = refEmail;
            this.refMercado = refMercado;
            this.tipoOverUnder = tipoOverUnder;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.fecha = fecha;
        }
    }
}