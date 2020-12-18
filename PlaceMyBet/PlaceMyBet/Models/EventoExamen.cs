using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventoExamen
    {
    }

    /*** Ejercicio 1 ***/
    public class Ej1
    {
        public Ej1(string equipo, List<MercadoDTOEj1> mercadosDTOEj1)
        {
            Equipo = equipo;
            MercadosDelEvento = mercadosDTOEj1;
        }

        public string Equipo { get; set; }
        public List<MercadoDTOEj1> MercadosDelEvento = new List<MercadoDTOEj1>();
    }

    public class MercadoDTOEj1
    {
        public MercadoDTOEj1(int mercadoId, double cuotaOver, double cuotaUnder)
        {
            MercadoId = mercadoId;
            this.CuotaOver = cuotaOver;
            this.CuotaUnder = cuotaUnder;
        }

        public int MercadoId { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
    }
    /*** Fin Ejercicio 1 ***/
}