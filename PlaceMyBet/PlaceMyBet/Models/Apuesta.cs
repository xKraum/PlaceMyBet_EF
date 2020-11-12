using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public string TipoOverUnder { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public DateTime Fecha { get; set; }
        public int ApuestaId { get; set; }
        public double TipoMercado { get; set; }
        public int MercadoId { get; set; }
        public string UsuarioId { get; set; }
        public Mercado Mercado { get; set; }
        public Usuario Usuario { get; set; }

        public Apuesta() { }
        public Apuesta(string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha, int apuestaId, double tipoMercado, int mercadoId, string usuarioId)
        {
            TipoOverUnder = tipoOverUnder;
            Cuota = cuota;
            DineroApostado = dineroApostado;
            Fecha = fecha;
            ApuestaId = apuestaId;
            TipoMercado = tipoMercado;
            MercadoId = mercadoId;
            UsuarioId = usuarioId;
        }
    }
}