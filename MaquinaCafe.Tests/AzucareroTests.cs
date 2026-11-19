
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaquinaCafe;
using Xunit;

namespace MaquinaCafe.Tests
{
    public class AzucareroTests
    {
        private readonly Azucarero azucarero;

        // Equivale al @Before de JUnit: xUnit crea una instancia nueva
        // de esta clase para cada prueba, así que esto se ejecuta antes de cada una.
        public AzucareroTests()
        {
            azucarero = new Azucarero(10);
        }

        [Fact]
        public void DeberiaDevolverVerdaderoSiHaySuficienteAzucarEnElAzucarero()
        {
            bool resultado = azucarero.HasAzucar(5);
            Assert.True(resultado);

            resultado = azucarero.HasAzucar(10);
            Assert.True(resultado);
        }

        [Fact]
        public void DeberiaDevolverFalsoPorqueNoHaySuficienteAzucarEnElAzucarero()
        {
            bool resultado = azucarero.HasAzucar(15);

            Assert.False(resultado);
        }

        [Fact]
        public void DeberiaRestarAzucarAlAzucarero()
        {
            azucarero.GiveAzucar(5);
            Assert.Equal(5, azucarero.CantidadAzucar);

            azucarero.GiveAzucar(2);
            Assert.Equal(3, azucarero.CantidadAzucar);
        }
    }
}
