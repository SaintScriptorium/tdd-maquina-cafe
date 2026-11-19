using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaquinaCafe;
using Xunit;
namespace MaquinaCafe.Tests
{
    public class MaquinaDeCafeTests
    {
        private readonly MaquinaDeCafe maquinaDeCafe;

        // Equivale al setUp() con @Before de la guía.
        public MaquinaDeCafeTests()
        {
            maquinaDeCafe = new MaquinaDeCafe
            {
                Cafetera = new Cafetera(50),
                VasosPequeno = new Vaso(5, 10),
                VasosMediano = new Vaso(5, 20),
                VasosGrande = new Vaso(5, 30),
                Azucarero = new Azucarero(20)
            };
        }

        [Fact]
        public void DeberiaDevolverUnVasoPequeno()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            Assert.Same(maquinaDeCafe.VasosPequeno, vaso);
        }

        [Fact]
        public void DeberiaDevolverUnVasoMediano()
        {
            // correcion respecto a la guia, la versión original creaba aquí una
            // máquina nueva (new MaquinaDeCafe()) sin vasos configurados, por lo que
            // comparaba null con null y la prueba pasaba sin verificar nada.
            // Se usa la máquina preparada en el constructor (setUp) para que la prueba
            // compruebe de verdad que se devuelve el depósito de vasos medianos.
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("mediano");

            Assert.Same(maquinaDeCafe.VasosMediano, vaso);
        }

        [Fact]
        public void DeberiaDevolverUnVasoGrande()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("grande");

            Assert.Same(maquinaDeCafe.VasosGrande, vaso);
        }

        [Fact]
        public void DeberiaDevolverNoHayVasos()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 10, 2);

            Assert.Equal("No hay Vasos", resultado);
        }

        [Fact]
        public void DeberiaDevolverNoHayCafe()
        {
            maquinaDeCafe.Cafetera = new Cafetera(5);

            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 2);

            Assert.Equal("No hay Cafe", resultado);
        }

        [Fact]
        public void DeberiaDevolverNoHayAzucar()
        {
            maquinaDeCafe.Azucarero = new Azucarero(2);

            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            Assert.Equal("No hay Azucar", resultado);
        }

        [Fact]
        public void DeberiaRestarCafe()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            int resultado = maquinaDeCafe.Cafetera.CantidadCafe;

            Assert.Equal(40, resultado);
        }

        [Fact]
        public void DeberiaRestarVaso()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            int resultado = maquinaDeCafe.VasosPequeno.CantidadVasos;

            Assert.Equal(4, resultado);
        }

        [Fact]
        public void DeberiaRestarAzucar()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            int resultado = maquinaDeCafe.Azucarero.CantidadAzucar;

            Assert.Equal(17, resultado);

        }

        [Fact]
        public void DeberiaDevolverFelicitaciones()
        {
            Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

            string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

            Assert.Equal("Felicitaciones", resultado);
        }
    }
}
