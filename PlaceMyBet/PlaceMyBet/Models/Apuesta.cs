using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta : ApuestaDTO
    {
        private int idApuesta;
        private int refMercado;

        public int IdApuesta { get => idApuesta; set => idApuesta = value; }
        public int RefMercado { get => refMercado; set => refMercado = value; }

        public Apuesta(int idApuesta, string refEmail, int refMercado, string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha, double tipoMercado) 
            : base(refEmail, tipoOverUnder, cuota, dineroApostado, fecha, tipoMercado)
        {
            this.idApuesta = idApuesta;
            base.refEmail = refEmail;
            this.refMercado = refMercado;
            base.tipoOverUnder = tipoOverUnder;
            base.cuota = cuota;
            base.dineroApostado = dineroApostado;
            base.fecha = fecha;

            base.tipoMercado = tipoMercado;
        }
    }

    public class ApuestaDTO
    {
        protected string refEmail;
        protected string tipoOverUnder;
        protected double cuota;
        protected double dineroApostado;
        protected DateTime fecha;


        protected double tipoMercado;

        public string RefEmail { get => refEmail; set => refEmail = value; }
        public string TipoOverUnder { get => tipoOverUnder; set => tipoOverUnder = value; }
        public double Cuota { get => cuota; set => cuota = value; }
        public double DineroApostado { get => dineroApostado; set => dineroApostado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }


        public double TipoMercado { get => tipoMercado; set => tipoMercado = value; }

        public ApuestaDTO(string refEmail, string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha, double tipoMercado)
        {
            this.refEmail = refEmail;
            this.tipoOverUnder = tipoOverUnder;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.fecha = fecha;


            this.tipoMercado = tipoMercado;
        }
    }
}