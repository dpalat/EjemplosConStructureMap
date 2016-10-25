using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMapParaTodosYTodas.Negocio;
using StructureMap;
using Rhino.Mocks;

namespace StructureMapParaTodosYTodas.Test
{
    [TestClass]
    public class UnitTest1
    {
        #region Test 1
        [TestMethod]
        public void TestCorrerSimple()
        {
            ObjectFactory.Initialize(x => { x.For<IPersona>().Use<Persona>(); });

            Ejercicio ejercicioDePersonas = new Ejercicio();
            ejercicioDePersonas.Correr();
        }
        #endregion

        #region Test 2
        [TestMethod]
        public void TestCorrerSimpleValidandoMinutos()
        {
            IPersona persona = MockRepository.GenerateMock<IPersona>();
            persona.Expect(e => e.Correr(25)).Repeat.Once();
            persona.Expect(e => e.Descansar(5)).Repeat.Once();
            persona.Expect(e => e.Correr(25)).Repeat.Once();
            persona.Expect(e => e.Descansar(15)).Repeat.Once();

            ObjectFactory.Initialize(x => { x.For<IPersona>().Use(persona); });

            Ejercicio ejercicioDePersonas = new Ejercicio();
            ejercicioDePersonas.Correr();

            persona.VerifyAllExpectations();
        }
        #endregion

        #region Test 3
        [TestMethod]
        public void TestCorrerEstrictaValidandoMinutos()
        {
            IPersona persona = MockRepository.GenerateStrictMock<IPersona>();
            ObjectFactory.Initialize(x => { x.For<IPersona>().Use(persona); });

            persona.Expect(e => e.Correr(25)).Repeat.Twice();
            persona.Expect(e => e.Descansar(5)).Repeat.Once();
            persona.Expect(e => e.Descansar(15)).Repeat.Once();

            Ejercicio ejercicioDePersonas = new Ejercicio();
            ejercicioDePersonas.Correr();
        }
        #endregion
    }
}
