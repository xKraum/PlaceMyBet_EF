using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento : EventoDTO
    {
        private int idEvento;
        public int IdEvento { get { return idEvento; } set { idEvento = value; } }


        public Evento(int idEvento, string equipoLocal, string equipoVisitante, DateTime fecha) : base(equipoLocal, equipoVisitante, fecha)
        {
            this.idEvento = idEvento;
            base.equipoLocal = equipoLocal;
            base.equipoVisitante = equipoVisitante;
            base.fecha = fecha;
        }
    }

    public class EventoDTO
    {
        protected string equipoLocal;
        protected string equipoVisitante;
        protected DateTime fecha;

        public string EquipoLocal { get { return equipoLocal; } set { equipoLocal = value; } }
        public string EquipoVisitante { get { return equipoVisitante; } set { equipoVisitante = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }

        public EventoDTO(string equipoLocal, string equipoVisitante, DateTime fecha)
        {
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.fecha = fecha;
        }
    }
}