using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureMapParaTodosYTodas.Negocio
{
    public class Persona : IPersona
    {
        private string _Nombre = "Base";

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
