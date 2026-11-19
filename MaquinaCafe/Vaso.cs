using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafe
{
    /// <summary>
    /// Representa el depósito de vasos de un tamaño (pequeño, mediano o grande).
    /// </summary>
    public class Vaso
    {
        /// <summary>Cantidad de vasos disponibles.</summary>
        public int CantidadVasos { get; private set; }

        /// <summary>Onzas de café que lleva cada vaso de este tamaño.</summary>
        public int Contenido { get; }

        public Vaso(int cantidadVasos, int contenido)
        {
            CantidadVasos = cantidadVasos;
            Contenido = contenido;
        }

        /// <summary>Indica si hay al menos la cantidad de vasos solicitada.</summary>
        public bool HasVasos(int cantidadSolicitada) => CantidadVasos >= cantidadSolicitada;

        /// <summary>Entrega (descuenta) la cantidad de vasos solicitada.</summary>
        public void GiveVasos(int cantidadSolicitada) => CantidadVasos -= cantidadSolicitada;
    }
}
