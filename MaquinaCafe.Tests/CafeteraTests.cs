using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaquinaCafe;
using Xunit;

namespace MaquinaCafe.Tests
{
    public class CafeteraTests
    {
        [Fact]
        public void DeberiaDevolverVerdaderoSiExisteCafe()
        {
            var cafetera = new Cafetera(10);

            bool resultado = cafetera.HasCafe(5);

            Assert.True(resultado);
        }

        [Fact]
        public void DeberiaDevolverFalsoSiNoExisteCafe()
        {
            var cafetera = new Cafetera(10);

            bool resultado = cafetera.HasCafe(11);

            Assert.False(resultado);
        }

        [Fact]
        public void DeberiaRestarCafeALaCafetera()
        {
            var cafetera = new Cafetera(10);

            cafetera.GiveCafe(7);

            Assert.Equal(3, cafetera.CantidadCafe);
        }
    }
}
