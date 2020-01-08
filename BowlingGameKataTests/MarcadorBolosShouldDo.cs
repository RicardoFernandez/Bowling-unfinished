using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BowlingGameKata;
using NUnit.Framework;

namespace BowlingGameKataTests
{
    [TestFixture]
    public class MarcadorBolosShouldDo
    {

        [Test]
        [TestCaseSource(typeof(MyDataTest),"TestCasesRonda")]
        public string ActualizarMarcador_Numero_MuestraValorEnLabelRonda(Ronda ronda)
        {
            MarcadorBolos marcador = new MarcadorBolos();
            marcador.ActualizarMarcador(ronda);
            var lblRonda = (Label)marcador.Controls.Find("lblronda" + ronda.NumeroRonda, true)[0];
            return lblRonda.Text;
        }

        [Test]
        [TestCaseSource(typeof(MyDataTest), "TestCasesTotalAcumulado")]
        public string ActualizarMarcador_Numero_MuestraValorEnLabelTotal(List<Ronda> rondas)
        {
            MarcadorBolos marcador = new MarcadorBolos();
            List<Ronda> rondasActuales = new List<Ronda>();
            Ronda ultimaRondaJugada = null;
            foreach (var ronda in rondas)
            {
                rondasActuales.Add(ronda);
                ultimaRondaJugada = rondasActuales.Last();
                marcador.ActualizarMarcador(ultimaRondaJugada);
            }
            var lblTotal = (Label)marcador.Controls.Find("lbltotal" + ultimaRondaJugada.NumeroRonda, true)[0];
            return lblTotal.Text;
        }

    }
}