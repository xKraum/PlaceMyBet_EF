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

    #region DTO Pedidos - AE4
    public class BetsByEmailAndMarketTypeDTO
    {
        private int idEvento;
        private string tipoOverUnder;
        private double cuota;
        private double dineroApostado;

        public int IdEvento { get => idEvento; set => idEvento = value; }
        public string TipoOverUnder { get => tipoOverUnder; set => tipoOverUnder = value; }
        public double Cuota { get => cuota; set => cuota = value; }
        public double DineroApostado { get => dineroApostado; set => dineroApostado = value; }

        public BetsByEmailAndMarketTypeDTO(int idEvento, string tipoOverUnder, double cuota, double dineroApostado)
        {
            this.idEvento = idEvento;
            this.tipoOverUnder = tipoOverUnder;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
        }
    }

    public class BetsByMarketAndEmailDTO
    {
        private double tipoMercado;
        private string tipoOverUnder;
        private double cuota;
        private double dineroApostado;

        public double TipoMercado { get => tipoMercado; set => tipoMercado = value; }
        public string TipoOverUnder { get => tipoOverUnder; set => tipoOverUnder = value; }
        public double Cuota { get => cuota; set => cuota = value; }
        public double DineroApostado { get => dineroApostado; set => dineroApostado = value; }

        public BetsByMarketAndEmailDTO(double tipoMercado, string tipoOverUnder, double cuota, double dineroApostado)
        {
            this.tipoMercado = tipoMercado;
            this.tipoOverUnder = tipoOverUnder;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
        }
    }
    #endregion
}