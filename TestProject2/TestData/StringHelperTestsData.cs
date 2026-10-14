using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.TestData
{
    /*La idea central es que ClassData no ejecuta las pruebas ni contiene la lógica de negocio. Su responsabilidad es proporcionar los argumentos que xUnit utilizará para ejecutar una teoría.*/
    public class StringHelperTestsData : IEnumerable<object[]>
    {
        /*
            ¿Qué hace esta clase?
            1. Implementa IEnumerable<object[]>, por lo que puede proporcionar una secuencia de arreglos de objetos.
            2. Su método GetEnumerator() devuelve los datos utilizando yield return.
            3. Cada arreglo contiene dos valores: el texto que se probará y el resultado esperado.
         */
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetName(), 5 };
            yield return new object[] { "One two three", 3 };
            yield return new object[] { "One two three four", 4 };
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
        public static string GetName()
        {
            return "One two three four five";
        }

    }

    public class StringHelperTestsData1 : TheoryData<string, int>
    {
        /*
            ¿Qué hace esta clase?
            1. Implementa IEnumerable<object[]>, por lo que puede proporcionar una secuencia de arreglos de objetos.
            2. Su método GetEnumerator() devuelve los datos utilizando yield return.
            3. Cada arreglo contiene dos valores: el texto que se probará y el resultado esperado.
         */
        public StringHelperTestsData1()
        {
            Add(GetName(), 3);
            Add("One two three", 3);
            Add("One two three four", 4);
        }
        public static string GetName()
        {
            return "One two three four five";
        }

    }

}
