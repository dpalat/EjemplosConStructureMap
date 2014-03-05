using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMapParaTodosYTodas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureMapParaTodosYTodas
{
    class Principal
    {
        static void Main(string[] args)
        {
            //------------------------------------------------------------------------------------
            //Asi se inicializa la fabrica de objectos declarando más de una dependencia.
            //ObjectFactory.Initialize(x =>
            //{
            //    x.For<IPersona>().Use<Persona>();
            //    x.For<IPersona>().Use<PersonaDeCiudad>().Named("PersonaQueViveEnCiudad");
            //    x.For<IPersona>().Use<PersonaDePueblo>().Named("PersonaQueViveEnProvincia");
            //});

            //------------------------------------------------------------------------------------
            //Asi se inicializa la fabrica de objectos incluyendo un conjunto de definiciones lo que se llama Registry.
            ObjectFactory.Initialize(x => x.IncludeRegistry(new RegistryPersonalizada()));

            //------------------------------------------------------------------------------------
            //Asi se inicializa la fabrica de objectos incluyendo un conjunto de Registry's.
            //ObjectFactory.Initialize(x =>
            //{
            //    x.IncludeRegistry(new RegistryPersonalizada());
            //    x.IncludeRegistry(new RegistryPersonalizadaAdicionalUno());
            //    x.IncludeRegistry(new RegistryPersonalizadaAdicionalDos());
            //});

            //------------------------------------------------------------------------------------
            // Para agregar más Registry's despues de utilizar el Initialize se utiliza el Configure
            ObjectFactory.Configure(x => x.IncludeRegistry(new RegistryPersonalizadaAdicionalUno()));
            ObjectFactory.Configure(x => x.IncludeRegistry(new RegistryPersonalizadaAdicionalDos()));
            
            
            try{
                IPersona personaConError = ObjectFactory.GetNamedInstance<IPersona>("PersonaQueNoViveEnEsteMundo");
            }
            catch (Exception error){ Console.WriteLine( error.Message.ToString() ); }

            IPersona personaBase = ObjectFactory.GetInstance<IPersona>();
            Console.WriteLine( "PersonaBase:" + personaBase.ObtenerNombre());

            IPersona personaDeCiudad = ObjectFactory.GetNamedInstance<IPersona>("PersonaQueViveEnCiudad");
            Console.WriteLine("PersonaDeCiudad:" + personaDeCiudad.ObtenerNombre());

            IPersona personaDeProvincia = ObjectFactory.GetNamedInstance<IPersona>("PersonaQueViveEnProvincia");
            Console.WriteLine("PersonaDeProvincia:" + personaDeProvincia.ObtenerNombre());

            Console.ReadLine();
        }


        private class RegistryPersonalizada : Registry
        {
            public RegistryPersonalizada()
            {
                //this.For<IPersona>().Use<Persona>();
                this.For<IPersona>().Transient().Use<Persona>();
                //this.ForRequestedType<IPersona>().TheDefault.Is.OfConcreteType<Persona>();
                //this.ForRequestedType<IPersona>().TheDefaultIsConcreteType<Persona>();
            }  
        }

        private class RegistryPersonalizadaAdicionalUno : Registry
        {
            public RegistryPersonalizadaAdicionalUno()
            {
                this.For<IPersona>().Use<PersonaDeCiudad>().Named("PersonaQueViveEnCiudad" );
            }
        }

        private class RegistryPersonalizadaAdicionalDos : Registry
        {
            public RegistryPersonalizadaAdicionalDos()
            {
                this.For<IPersona>().Use<PersonaDePueblo>().Named("PersonaQueViveEnProvincia");
            }
        }
    }
}

