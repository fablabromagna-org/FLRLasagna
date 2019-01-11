using System;
namespace FLRLasagna.Models
{
    public class RecordStampa
    {
        // Chi
        public string Proprietario { get; set; }

        // Cosa
        public string NomeDocumento { get; set; }
        public string FormatoStampa { get; set; }
        public string TipoCarta { get; set; }
        public string NumeroTotalePagine { get; set; }
        public string LarghezzaCarta { get; set; }
        public string LunghezzaCarta { get; set; }

        // Quando
        public DateTime OraInizioStampa { get; set; }
        public DateTime OraFineStampa { get; set; }
        public TimeSpan Durata { get { return OraFineStampa - OraInizioStampa; } }

        // Consumi
        public double InchiostroConsumato { get; set; }
        public double CartaConsumata { get; set; }
        public double Euro
        {
            get
            {
                double d = InchiostroConsumato * 0.5 + CartaConsumata * 0.6 + (Durata.TotalSeconds / 60);
                return Math.Round(d, 2);
            }
        }

        // Altro
        public string RisultatoStampa { get; set; }


        //
        // Utility
        //
        public override string ToString()
        {
            return $"{NomeDocumento}\nUtente: {Proprietario}\nDalle {OraInizioStampa}, alle {OraFineStampa}\nDurata: {Durata}\nTipo carta: {TipoCarta}\nFormato: {FormatoStampa}\nInchiostro(ml): {InchiostroConsumato}\nCarta(m2): {CartaConsumata}\nEuro: {Euro}";
        }

        public string Utente
        {
            get
            {
                return $"{Proprietario} ({FormatoStampa}) {Euro}€";
            }
        }

        public string Dettagli
        {
            get
            {
                return $"eseguita {OraInizioStampa} con {InchiostroConsumato}ml di inchiostro";
            }
        }



        public static DateTime ToDateTime(string str)
        {
            DateTime d;
            DateTime.TryParse(str, out d);
            return d;
        }
        public static double ToDouble(string str)
        {
            int len = str.Length - 2;
            string ml = str.Substring(0, len).Replace('.', ',');

            double retVal;
            Double.TryParse(ml, out retVal);

            return retVal;
        }
    }
}