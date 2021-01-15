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

    public class ApuestaDTO
    {
        public string UsuarioId { get; set; }
        public int EventoId { get; set; }
        public string TipoOverUnder { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }

        public ApuestaDTO(string usuarioId, int eventoId, string tipoOverUnder, double cuota, double dineroApostado)
        {
            UsuarioId = usuarioId;
            EventoId = eventoId;
            TipoOverUnder = tipoOverUnder;
            Cuota = cuota;
            DineroApostado = dineroApostado;
        }
    }

    public class ApuestaPMM_DTO : Apuesta
    {
        public int EventoId { get; set; }

        public ApuestaPMM_DTO(string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha, int apuestaId, double tipoMercado, int mercadoId, string usuarioId, int eventoId)
            : base(tipoOverUnder, cuota, dineroApostado, fecha, apuestaId, tipoMercado, mercadoId, usuarioId)
        {
            EventoId = eventoId;
        }
    }
}