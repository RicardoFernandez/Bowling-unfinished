using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class Ronda
    {
        private Tirada primeraTirada;
        private Tirada segundaTirada;
        private int numeroRonda;

        public Ronda(Tirada primeraTirada, Tirada segundaTirada, int numeroRonda)
        {
            this.PrimeraTirada = primeraTirada;
            this.SegundaTirada = segundaTirada;
            this.NumeroRonda = numeroRonda;
        }

        public Tirada PrimeraTirada { get => primeraTirada; set => primeraTirada = value; }
        public Tirada SegundaTirada { get => segundaTirada; set => segundaTirada = value; }
        public int NumeroRonda { get => numeroRonda; set => numeroRonda = value; }

        public string CalcularSumaTiradas()
        {
            var total = this.PrimeraTirada.NumeroBolosTirado;
            if (segundaTirada != null)
            {
                total += this.SegundaTirada.NumeroBolosTirado;
            }

            if (total == 10)
            {
                return string.Empty;
            }

            return total.ToString();
        }
    }
}
