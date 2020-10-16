using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestasRepository
    {
        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> bets = new List<Apuesta>();

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM apuestas;");

            foreach (var item in dataReceived)
            {
                bets.Add(new Apuesta((int)item[0], (string)item[1], (int)item[2], (string)item[3], (double)item[4], (double)item[5], (DateTime)item[6], (double)item[9]));
            }

            return bets;
        }

        internal Apuesta Retrieve(int id)
        {
            Apuesta b = null;

            List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM apuestas WHERE `idApuesta` = {id};");

            if (dataReceived.Count > 0)
                b = new Apuesta((int)dataReceived[0][0], (string)dataReceived[0][1], (int)dataReceived[0][2], (string)dataReceived[0][3], (double)dataReceived[0][4],
                    (double)dataReceived[0][5], (DateTime)dataReceived[0][6], (double)dataReceived[0][9]);

            return b;
        }

        //Obtener objeto sin información sensible (ids, datos importantes, etc.)
        internal List<ApuestaDTO> RetrieveDTO()
        {
            List<ApuestaDTO> bets = new List<ApuestaDTO>();

            List<ArrayList> dataReceived = Common.BBDD.GetData("SELECT * FROM apuestas INNER JOIN mercados ON apuestas.refMercado = mercados.idMercado;");

            foreach (var item in dataReceived)
            {
                bets.Add(new ApuestaDTO((string)item[1], (string)item[3], (double)item[4], (double)item[5], (DateTime)item[6], (double)item[9]));
            }

            return bets;
        }

        internal ApuestaDTO RetrieveDTO(int id)
        {
            ApuestaDTO b = null;

            //List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM apuestas WHERE `idApuesta` = {id};");
            List<ArrayList> dataReceived = Common.BBDD.GetData($"SELECT * FROM apuestas INNER JOIN mercados ON apuestas.refMercado = mercados.idMercado " +
                $"WHERE `idApuesta` = {id};");

            if (dataReceived.Count > 0)
                b = new ApuestaDTO((string)dataReceived[0][1], (string)dataReceived[0][3], (double)dataReceived[0][4],
                    (double)dataReceived[0][5], (DateTime)dataReceived[0][6], (double)dataReceived[0][9]);

            return b;
        }


        internal void Save(Apuesta bet)
        {
            Mercado market = new MercadosRepository().Retrieve(bet.RefMercado);
            Evento e = new EventosRepository().Retrieve(market.RefEvento);

            double quota = (bet.TipoOverUnder == "Over") ? market.CuotaOver : market.CuotaUnder; 
            
            //Inserto una nueva apuesta, con el correspondiente DINERO APOSTADO a Over o Under.
            Common.BBDD.SetData($"INSERT INTO `APUESTAS` (`idApuesta`, `refEmail`, `refMercado`, `tipoOverUnder`, `cuota`, `dineroApostado`, `fecha`) " +
                $"VALUES (NULL, '{bet.RefEmail}', {bet.RefMercado}, '{bet.TipoOverUnder}', {quota.ToString().Replace(',', '.')}," +
                $" {bet.DineroApostado.ToString().Replace(',', '.')}, '{e.Fecha.ToString("yyyy-MM-dd")}')");

            //Actualizo el DINERO OVER/UNDER de la tabla MERCADOS para poder actualizar luego la cuota.
            if (bet.TipoOverUnder == "Over")
                Common.BBDD.SetData($"UPDATE `MERCADOS` " +
                    $"SET `dineroOver`={(bet.DineroApostado + market.DineroOver).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)} " +
                    $"WHERE `idMercado`={bet.RefMercado};");
            else
                Common.BBDD.SetData($"UPDATE `MERCADOS` " +
                    $"SET `dineroUnder`={(bet.DineroApostado + market.DineroUnder).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)} " +
                    $"WHERE `idMercado`={bet.RefMercado};");

            //Vuelvo a crear el objeto MERCADO para que tenga el DINERO OVER/UNDER actualizado
            market = new MercadosRepository().Retrieve(bet.RefMercado);

            //Calculo la nueva CUOTA OVER o UNDER.
            string newQuota = CalculateQuota(bet, market).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            //Actualizo la CUOTA según sea OVER o UNDER en la tabla MERCADOS.
            if (bet.TipoOverUnder == "Over")
                Common.BBDD.SetData($"UPDATE `MERCADOS` SET `cuotaOver`={newQuota} WHERE `idMercado`={bet.RefMercado};");
            else
                Common.BBDD.SetData($"UPDATE `MERCADOS` SET `cuotaUnder`={newQuota} WHERE `idMercado`={bet.RefMercado};");
        }

        private double CalculateQuota(Apuesta bet, Mercado market)
        {
            double probability;

            if (bet.TipoOverUnder == "Over")
                probability = market.DineroOver / (market.DineroOver + market.DineroUnder);
            else
                probability = market.DineroUnder / (market.DineroOver + market.DineroUnder);

            return 1 / probability * 0.95;
        }
    }
}