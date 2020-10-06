using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        private int idMercado;
        private int refEvento;
        private double tipoMercado;
        private double cuotaOver;
        private double cuotaUnder;
        private double dineroOver;
        private double dineroUnder;

        public int IdMercado { get => idMercado; set => idMercado = value; }
        public int RefEvento { get => refEvento; set => refEvento = value; }
        public double TipoMercado { get => tipoMercado; set => tipoMercado = value; }
        public double CuotaOver { get => cuotaOver; set => cuotaOver = value; }
        public double CuotaUnder { get => cuotaUnder; set => cuotaUnder = value; }
        public double DineroOver { get => dineroOver; set => dineroOver = value; }
        public double DineroUnder { get => dineroUnder; set => dineroUnder = value; }

        public Mercado(int idMercado, int refEvento, double tipoMercado, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder)
        {
            this.idMercado = idMercado;
            this.refEvento = refEvento;
            this.tipoMercado = tipoMercado;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
        }
    }
}