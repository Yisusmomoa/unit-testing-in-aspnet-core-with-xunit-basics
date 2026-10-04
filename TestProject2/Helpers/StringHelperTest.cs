using LibraryApi.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.Helpers
{
    public class StringHelperTest
    {
        [Fact]
        /*
            Arrange (Organizar/Preparar): Se inicializan los objetos, se configuran las dependencias (como mocks) y se establecen los datos de entrada necesarios para el escenario de prueba. 
            Act (Actuar/Ejecutar): Se invoca el método o función que se está probando, realizando la acción principal bajo evaluación. 
            Assert (Afirmar/Verificar): Se comprueba si el resultado obtenido coincide con el comportamiento o valor esperado, validando así la corrección del código. 
         */
        public void IsEmpty_WithEmptyString_ReturnsTrue()
        {
            //Arrange
            var stringHelper = new StringHelper();

            //Act
            var result = stringHelper.IsEmpty(string.Empty);

            //Assert
            Assert.True(result);
        }

        [Fact]
        /*
            Arrange (Organizar/Preparar): Se inicializan los objetos, se configuran las dependencias (como mocks) y se establecen los datos de entrada necesarios para el escenario de prueba. 
            Act (Actuar/Ejecutar): Se invoca el método o función que se está probando, realizando la acción principal bajo evaluación. 
            Assert (Afirmar/Verificar): Se comprueba si el resultado obtenido coincide con el comportamiento o valor esperado, validando así la corrección del código. 
         */
        public void IsEmpty_WithNullString_ReturnsTrue()
        {
            //Arrange
            var stringHelper = new StringHelper();

            //Act
            var result = stringHelper.IsEmpty(null);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmpty_WithValidString_ReturnsFalse()
        {
            //Arrange
            var stringHelper = new StringHelper();

            //Act
            var result = stringHelper.IsEmpty("abc");

            //Assert
            Assert.False(result);
        }


        [Fact]
        public void CountWords_WithMultipleWords_ReturnsCorrectCount()
        {
            //Arrange
            var stringHelper = new StringHelper();

            //Act
            var result = stringHelper.CountWords("hello world from unit tests");

            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void CountWords_WithOneWord_ReturnsCorrectCount()
        {
            //Arrange
            var stringHelper = new StringHelper();

            //Act
            var result = stringHelper.CountWords("Hello");

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void CountWords_WithEmptyValue_ReturnsCorrectCount()
        {
            //Arrange
            var stringHelper = new StringHelper();

            //Act
            var result = stringHelper.CountWords(string.Empty);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountWords_WithNullValue_ReturnsCorrectCount()
        {
            //Arrange
            var stringHelper = new StringHelper();

            //Act
            var result = stringHelper.CountWords(null);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountWords_WithWhiteSpace_ReturnsCorrectCount()
        {
            //Arrange
            var stringHelper = new StringHelper();

            //Act
            var result = stringHelper.CountWords(" ");

            //Assert
            Assert.Equal(0, result);
        }

    }
}
