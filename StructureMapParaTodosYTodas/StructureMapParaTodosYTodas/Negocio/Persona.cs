using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureMapParaTodosYTodas.Negocio
{
    public class Persona : IPersona
    {
        private string _Nombre = "Base";
        public int minutosEjercicio = 0;
        public int minutosDescanso = 0;

        public void SetearNombre( string nombre )
        {
            this._Nombre = nombre;
        }

        public string ObtenerNombre()
        {
            return this._Nombre;
        }

        public void Correr(int minutos)
        {
            this.minutosEjercicio =+ minutos;
        }

        public void Descansar(int minutos)
        {
            this.minutosDescanso =+ minutos;
        }
    }
}
