using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafe
{
    /// <summary>
    /// Depósito de café, medido en onzas.
    /// </summary>
    public class Cafetera
    {
        /// <summary>Onzas de café disponibles.</summary>
        public int CantidadCafe { get; private set; }

        public Cafetera(int cantidadCafe)
        {
            CantidadCafe = cantidadCafe;
        }

        /// <summary>Indica si hay al menos la cantidad de café solicitada.</summary>
        public bool HasCafe(int cantidadSolicitada) => CantidadCafe >= cantidadSolicitada;

        /// <summary>Entrega (descuenta) la cantidad de café solicitada.</summary>
        public void GiveCafe(int cantidadSolicitada) => CantidadCafe -= cantidadSolicitada;
    }
}
