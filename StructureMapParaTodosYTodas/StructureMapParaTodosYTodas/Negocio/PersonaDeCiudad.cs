using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureMapParaTodosYTodas.Negocio
{
    public class PersonaDeCiudad : IPersona
    {
        private string _Nombre = "Ciudad";

        public void SetearNombre( string nombre )
        {
            this._Nombre = nombre;
        }

        public string ObtenerNombre()
        {
            return this._Nombre;
        }
    }
}
