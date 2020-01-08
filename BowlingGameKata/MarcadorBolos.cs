using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BowlingGameKata
{
    public partial class MarcadorBolos : Form
    {
        private const int MAXIMO_NUMERO_BOLOS = 10;
        List<Ronda> todasLasRondasTranscurridas = new List<Ronda>();

        public MarcadorBolos()
        {
            InitializeComponent();
        }

        public void ActualizarMarcador(Ronda ronda)
        {
            todasLasRondasTranscurridas.Add(ronda);
            ActualizarRonda(ronda);           
            ActualizarTotal(ronda);
        }

        private void ActualizarTotal(Ronda ronda)
        {
            var lblTotalRonda = ObtenerLabelTotal(ronda.NumeroRonda);
            lblTotalRonda.Text = ObtenerTotalAcumulado(todasLasRondasTranscurridas).ToString();
        }

        private int ObtenerTotalAcumulado(List<Ronda> rondas)
        {
            ///todo logica semiplenos y plenos
            int totalAcumulado = 0;
            foreach( Ronda ronda in rondas){
                var valorRonda = ronda.CalcularSumaTiradas();
                if (valorRonda.Equals(string.Empty))
                {

                } 
                totalAcumulado += Int32.Parse(valorRonda);
            }
            return totalAcumulado;
        }

        private void ActualizarRonda(Ronda ronda)
        {
            var primeraTirada = ronda.PrimeraTirada;
            var segundaTirada = ronda.SegundaTirada;
            var lblRonda = ObtenerLabelRonda(ronda.NumeroRonda);
            EscribirPorTirada(primeraTirada, lblRonda);
            if (segundaTirada != null)
            {
                EscribirPorTirada(segundaTirada, lblRonda);
            }
        }

        private Label ObtenerLabelRonda(int numeroRonda)
        {
            return (Label)Controls.Find("lblronda" + numeroRonda, true)[0];
        }
        private Label ObtenerLabelTotal(int numeroRonda)
        {
            return (Label)Controls.Find("lbltotal" + numeroRonda, true)[0];
        }

        private void EscribirPorTirada(Tirada tirada, Label lblRonda)
        {
            if (tirada.NumeroTirada == 1)
            {
                lblRonda.Text = ObtenerTextoPrimeraTirada(tirada.NumeroBolosTirado);
                return;
            }
            if (EsSemipleno(tirada, lblRonda))
            {
                lblRonda.Text += "|/";
                return;
            }
            lblRonda.Text += "|" + tirada.NumeroBolosTirado.ToString();
        }

        private bool EsSemipleno(Tirada tirada, Label lblRonda)
        {
            return tirada.NumeroTirada == 2 && int.Parse(lblRonda.Text) + tirada.NumeroBolosTirado == MAXIMO_NUMERO_BOLOS;
        }
        private bool EsPleno(Tirada tirada, Label lblRonda)
        {
            return tirada.NumeroTirada == 1 && tirada.NumeroBolosTirado == MAXIMO_NUMERO_BOLOS;
        }

        private string ObtenerTextoPrimeraTirada(int bolosTirados)
        {
            var textoPrimeraTirada = bolosTirados.ToString();
            if (bolosTirados == 10)
            {
                textoPrimeraTirada = "X";
            }
            return textoPrimeraTirada;
        }
    }
}
