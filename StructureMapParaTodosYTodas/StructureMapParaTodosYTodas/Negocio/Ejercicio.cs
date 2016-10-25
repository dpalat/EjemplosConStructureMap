using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureMapParaTodosYTodas.Negocio
{
    public class Ejercicio
    {
        public void Correr() 
        { 
            IPersona personaBase = ObjectFactory.GetInstance<IPersona>();
            personaBase.Correr(25);
            personaBase.Descansar( 5 );
            personaBase.Correr(25);
            personaBase.Descansar(15);
        }
    }
}
