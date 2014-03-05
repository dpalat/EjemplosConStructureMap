using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureMapParaTodosYTodas.Negocio
{
    public interface IPersona
    {
        void SetearNombre(string nombre);
        string ObtenerNombre();
    }
}
