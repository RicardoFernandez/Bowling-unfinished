using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
   public class Tirada
    {
        private int numeroTirada;
        private int numeroBolosTirado;

        public Tirada(int numeroTirada, int numeroBolosTirado)
        {
            this.NumeroTirada = numeroTirada;
            this.NumeroBolosTirado = numeroBolosTirado;
        }

        public int NumeroTirada { get => numeroTirada; set => numeroTirada = value; }
        public int NumeroBolosTirado { get => numeroBolosTirado; set => numeroBolosTirado = value; }
    }
}
