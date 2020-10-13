using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta : ApuestaDTO
    {
        private int idApuesta;

        public int IdApuesta { get => idApuesta; set => idApuesta = value; }

        public Apuesta(int idApuesta, string refEmail, int refMercado, string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha) 
            : base(refEmail, refMercado, tipoOverUnder, cuota, dineroApostado, fecha)
        {
            this.idApuesta = idApuesta;
            base.refEmail = refEmail;
            base.refMercado = refMercado;
            base.tipoOverUnder = tipoOverUnder;
            base.cuota = cuota;
            base.dineroApostado = dineroApostado;
            base.fecha = fecha;
        }
    }

    public class ApuestaDTO
    {
        protected string refEmail;
        protected int refMercado;
        protected string tipoOverUnder;
        protected double cuota;
        protected double dineroApostado;
        protected DateTime fecha;

        public string RefEmail { get => refEmail; set => refEmail = value; }
        public int RefMercado { get => refMercado; set => refMercado = value; }
        public string TipoOverUnder { get => tipoOverUnder; set => tipoOverUnder = value; }
        public double Cuota { get => cuota; set => cuota = value; }
        public double DineroApostado { get => dineroApostado; set => dineroApostado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }

        public ApuestaDTO(string refEmail, int refMercado, string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha)
        {
            this.refEmail = refEmail;
            this.refMercado = refMercado;
            this.tipoOverUnder = tipoOverUnder;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.fecha = fecha;
        }
    }
}