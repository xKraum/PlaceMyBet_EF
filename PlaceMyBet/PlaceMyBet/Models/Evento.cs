using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        private int idEvento;
        private string equipoLocal;
        private string equipoVisitante;
        private DateTime fecha;

        public int IdEvento { get { return idEvento; } set { idEvento = value; } }
        public string EquipoLocal { get { return equipoLocal; } set { equipoLocal = value; } }
        public string EquipoVisitante { get { return equipoVisitante; } set { equipoVisitante = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }

        public Evento(int idEvento, string equipoLocal, string equipoVisitante, DateTime fecha)
        {
            this.idEvento = idEvento;
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.fecha = fecha;
        }
    }
}