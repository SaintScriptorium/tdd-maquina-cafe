using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafe
{
    /// <summary>
    /// Máquina dispensadora: coordina los vasos, la cafetera y el azucarero
    /// para servir café al cliente.
    /// </summary>
    public class MaquinaDeCafe
    {
        public const string MensajeNoHayVasos = "No hay Vasos";
        public const string MensajeNoHayCafe = "No hay Cafe";
        public const string MensajeNoHayAzucar = "No hay Azucar";
        public const string MensajeExito = "Felicitaciones";

        public Cafetera Cafetera { get; set; }
        public Vaso VasosPequeno { get; set; }
        public Vaso VasosMediano { get; set; }
        public Vaso VasosGrande { get; set; }
        public Azucarero Azucarero { get; set; }

        /// <summary>
        /// Devuelve el depósito de vasos según el tamaño: "pequeno", "mediano" o "grande".
        /// Si el tamaño no existe, devuelve null.
        /// </summary>
        public Vaso GetTipoDeVaso(string tipoDeVaso)
        {
            return tipoDeVaso switch
            {
                "pequeno" => VasosPequeno,
                "mediano" => VasosMediano,
                "grande" => VasosGrande,
                _ => null
            };
        }

        /// <summary>
        /// Intenta servir café. Revisa en orden: vasos, café y azúcar.
        /// Si algo falta, devuelve el mensaje correspondiente sin descontar nada.
        /// Si todo alcanza, descuenta los insumos y devuelve "Felicitaciones".
        /// </summary>
        public string GetVasoDeCafe(Vaso tipoDeVaso, int cantidadDeVasos, int cantidadDeAzucar)
        {
            int cafeNecesario = tipoDeVaso.Contenido * cantidadDeVasos;

            if (!tipoDeVaso.HasVasos(cantidadDeVasos))
                return MensajeNoHayVasos;

            if (!Cafetera.HasCafe(cafeNecesario))
                return MensajeNoHayCafe;

            if (!Azucarero.HasAzucar(cantidadDeAzucar))
                return MensajeNoHayAzucar;

            Servir(tipoDeVaso, cantidadDeVasos, cafeNecesario, cantidadDeAzucar);
            return MensajeExito;
        }

        /// <summary>Descuenta los vasos, el café y el azúcar utilizados.</summary>
        private void Servir(Vaso tipoDeVaso, int cantidadDeVasos, int cafeNecesario, int cantidadDeAzucar)
        {
            tipoDeVaso.GiveVasos(cantidadDeVasos);
            Cafetera.GiveCafe(cafeNecesario);
            Azucarero.GiveAzucar(cantidadDeAzucar);
        }
    }
}
