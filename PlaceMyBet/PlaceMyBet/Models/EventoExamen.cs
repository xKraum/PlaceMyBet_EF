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

    /*** Ejercicio 2 ***/
    public class Ej2
    {
        public Ej2(string equipoLocal, string equipoVisitante, double tipoMercado, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            TipoMercado = tipoMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
        }

        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public double TipoMercado { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
    }
    /*** Fin Ejercicio 2 ***/
}