using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafe
{
    /// <summary>
    /// Depósito de azúcar, medido en cucharadas.
    /// </summary>
    public class Azucarero
    {
        /// <summary>Cucharadas de azúcar disponibles.</summary>
        public int CantidadAzucar { get; private set; }

        public Azucarero(int cantidadAzucar)
        {
            CantidadAzucar = cantidadAzucar;
        }

        /// <summary>Indica si hay al menos las cucharadas solicitadas.</summary>
        public bool HasAzucar(int cantidadSolicitada) => CantidadAzucar >= cantidadSolicitada;

        /// <summary>Entrega (descuenta) las cucharadas solicitadas.</summary>
        public void GiveAzucar(int cantidadSolicitada) => CantidadAzucar -= cantidadSolicitada;
    }
}
