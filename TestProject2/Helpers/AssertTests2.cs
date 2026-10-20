using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.Helpers
{
    public class AssertTests2
    {
        [Fact]
        [Trait("Assert", "Boolean")]
        public void Boolean_Assert_Returns_True()
        {
            bool condition = true;
            int a = 5;

            Assert.False(a==10, "no debe de ser 10");
        }

        [Fact]
        [Trait("Assert", "Equality")]
        public void Equality_Assert_Returns_True()
        {
            var actual = "Hello World";

            Assert.Equal("Hello World", actual);
            Assert.NotEqual("Hello World", actual);
        }

        [Fact]
        public void Equal_ComparaColecciones()
        {
            //Assert.Equal() compara los valores y, cuando recibe colecciones, compara sus elementos en orden.
            var esperado = new[] { 1, 2, 3 };
            var actual = new[] { 1, 2, 3 };

            Assert.Equal(esperado, actual);
            /*La prueba pasa porque ambas colecciones contienen los mismos elementos en el mismo orden, aunque sean arreglos diferentes en memoria.*/
        }

        [Fact]
        public void StrictEqual_ComparaColeccionesEstrictamente()
        {
            /*
                Assert.StrictEqual() realiza una comparación estricta de igualdad. 
                En xUnit v3, para colecciones, exige que se cumplan las condiciones de igualdad estricta definidas por el comparador, en lugar de recurrir 
                a las comparaciones flexibles de Equal().
             */
            //Assert.StrictEqual() comprueba que dos valores sean estrictamente iguales según la semántica de igualdad del tipo que estás comparando.
            var esperado = new[] { 1, 2, 3 };
            var actual = new[] { 1, 2, 3 };

            Assert.Equal(esperado, actual);       // Pasa
            Assert.StrictEqual(esperado, actual); // Falla

            /*
                Equal() compara los elementos de los arreglos y encuentra que son iguales.
                StrictEqual() comprueba la igualdad estricta de los arreglos. Como son dos instancias diferentes, la comparación falla.
             */
        }


        ///////////XUnit Identity Assertions - Assert.Same vs Assert.NotSame | XUnit Tutorial #19
        [Fact]
        public void Same_ComparaColecciones()
        {
            
            var esperado = new[] { 1, 2, 3 };
            var actual = new[] { 1, 2, 3 };
            //Assert.Same() y Assert.NotSame() comparan identidad de objetos, es decir, si dos variables apuntan exactamente a la misma instancia en memoria.
            /*
                Assert.Same() — ¿Es exactamente el mismo objeto?
                Comprueba si ambas variables hacen referencia a la misma instancia.
             */
            Assert.Same(esperado, actual);
        }

        //[Fact]
        //public void ProcesarUsuario_DevuelveLaMismaInstancia()
        //{
        //    var servicio = new UsuarioService();
        //    var usuario = new Usuario { Nombre = "Carlos" };

        //    var resultado = servicio.ProcesarUsuario(usuario);

        //    Assert.Same(usuario, resultado);
        //}
        //public Usuario ProcesarUsuario(Usuario usuario)
        //{
        //debe devolver exactamente ese mismo objeto, sin crear una copia.
        //    // Realiza alguna operación sobre el usuario.
        //    return usuario;
        //}

    }
}
