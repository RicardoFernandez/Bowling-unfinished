using BowlingGameKata;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKataTests
{
    public class MyDataTest
    {
        public static IEnumerable TestCasesRonda
        {
            get
            {
                yield return new TestCaseData(new Ronda(new Tirada(1, 5), new Tirada(2, 4), 1)).Returns("5|4");
                yield return new TestCaseData(new Ronda(new Tirada(1, 5), new Tirada(2, 4), 2)).Returns("5|4");
                yield return new TestCaseData(new Ronda(new Tirada(1, 5), new Tirada(2, 5), 3)).Returns("5|/");
                yield return new TestCaseData(new Ronda(new Tirada(1, 10), null, 1)).Returns("X");
            }
        }
        public static IEnumerable TestCasesTotalAcumulado
        {
            get
            {
                yield return new TestCaseData(new List<Ronda> {
                    new Ronda(new Tirada(1, 5), new Tirada(2, 4), 1),
                    new Ronda(new Tirada(1, 5), new Tirada(2, 4), 2),
                    new Ronda(new Tirada(1, 5), new Tirada(2, 4), 3)
                }).Returns("27");

                yield return new TestCaseData(new List<Ronda> {
                new Ronda(new Tirada(1, 5), new Tirada(2, 5), 1)
                }).Returns("");

                yield return new TestCaseData(new List<Ronda> {
                new Ronda(new Tirada(1, 10), null, 1)
                }).Returns("");
            }
        }
    }
}
