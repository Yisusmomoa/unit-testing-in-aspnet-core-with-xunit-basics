using LibraryApi.Controllers;
using LibraryApi.Helpers;
using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.Controllers
{

    public class BooksControllerTests
    {
        [Fact]
        public async Task GetAllBooks_Returns_OkResult()
        {
            // Arrange: preparamos los libros que esperamos recibir del repositorio.
            // Usamos fechas fijas para que el resultado sea predecible y reproducible.
            List<Book> output = new List<Book>()
            {
                new Book()
                {
                    Id=1, Title="Book 1",  Author="Author 1", IsAvailable=true, PublishedDate=DateTime.Now,
                },
                new Book()
                {
                    Id=2, Title="Book 2",  Author="Author 2", IsAvailable=true, PublishedDate=DateTime.Now,
                },
            };
            // Creamos un mock del repositorio para no depender de una base de datos real.
            var booksRepositoryMock = new Mock<IBookRepository>();

            // Configuramos el mock: cuando se invoque GetAllBooksAsync(),
            // devolverá expectedBooks como resultado de la operación asíncrona.
            booksRepositoryMock.Setup(x => x.GetAllBooksAsync().Result).Returns(output);

            // Inyectamos el repositorio simulado en el controlador.
            var controller = new BooksController(booksRepositoryMock.Object);
            //Arrange

            // Act: ejecutamos el método que queremos probar.
            var result = await controller.GetAllBooks();
            //Act


            // Assert: verificamos que el repositorio se haya llamado exactamente una vez.
            booksRepositoryMock.Verify(s => s.GetAllBooksAsync(), Times.Once); //cuantas veces se llamó a este método
            // El controlador devuelve Ok(books), así que esperamos un OkObjectResult.
            var okResult=Assert.IsType<OkObjectResult>(result.Result);
            // Extraemos y verificamos que el cuerpo de la respuesta contenga libros.
            var actualBooks = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
            // Comparamos los libros esperados con los libros devueltos.
            Assert.Equal(output, actualBooks);



            //Assert


        }

        //volver a ver y ayudarse de chatgpt
        //https://www.youtube.com/watch?v=4VJFh-C50V0&list=PLaFzfwmPR7_LlpcyBEOZBrYpZv3MppZNB&index=26

        [Fact]
        public async Task GetAllBooks_Returns_OkResult1()
        {
            //Arrange
            List<Book> output = new List<Book>()
            {
                new Book()
                {
                    Id=1, Title="Book 1",  Author="Author 1", IsAvailable=true, PublishedDate=DateTime.Now,
                },
                new Book()
                {
                    Id=2, Title="Book 2",  Author="Author 2", IsAvailable=true, PublishedDate=DateTime.Now,
                },
            };
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(s => s.GetAllBooksAsync()).ReturnsAsync(output);
            var controller = new BooksController(bookRepositoryMock.Object);

            //Act

            var result=await controller.GetAllBooks();

            bookRepositoryMock.Verify(
             repository => repository.GetAllBooksAsync(),
             Times.Once);
            // El controlador devuelve Ok(books), así que esperamos un OkObjectResult.
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Extraemos y verificamos que el cuerpo de la respuesta contenga libros.
            var actualBooks = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);


            //Assert
            Assert.Equal(output, actualBooks);

        }

        [Fact]
        public async Task GetAllBooks_Returns_OkResult2()
        {
            //Arrange
            List<Book> output = new List<Book>()
            {
                new Book()
                {
                    Id=1, Title="Book 1",  Author="Author 1", IsAvailable=true, PublishedDate=DateTime.Now,
                },
                new Book()
                {
                    Id=2, Title="Book 2",  Author="Author 2", IsAvailable=true, PublishedDate=DateTime.Now,
                },
            };
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(s => s.GetAllBooksAsync()).ReturnsAsync(output);
            var controller = new BooksController(bookRepositoryMock.Object);

            //Act

            var result = await controller.GetAllBooks2();

            bookRepositoryMock.Verify(repository => repository.GetAllBooksAsync(), Times.Once);

            // El controlador devuelve Ok(books), así que esperamos un OkObjectResult.
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Extraemos y verificamos que el cuerpo de la respuesta contenga libros.
            var actualBooks = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);


            //Assert
            Assert.Equal(output, actualBooks);

        }

        [Fact]
        public async Task GetBook_Returns_ValidBooks()
        {
            var output = new Book()
            {
                Id = 1,
                Title = "Book 1",
                Author = "Author 1",
                IsAvailable = true,
                PublishedDate = DateTime.Now,
            };
            var bookRepositoryMock = new Mock<IBookRepository>();
            /*configura el mock de Moq para que devuelva output cuando se cumpla una condición sobre el identificador del libro.*/
            bookRepositoryMock.Setup(s => s.GetBookByIdAsync(It.Is<int>(y=>y>10)).Result).Returns(output);

            /*
            bookRepositoryMock.Setup(...)
                Define un comportamiento esperado para el mock. Le indica qué debe devolver cuando se invoque un método que coincida con la configuración.
            s => s.GetBookByIdAsync(...)
                Es una expresión lambda. s representa el repositorio simulado y estás configurando su método GetBookByIdAsync.

            It.Is<int>(y => y > 10)
                Es un argument matcher de Moq. Significa que el argumento entero debe cumplir la condición y > 10.
                Por ejemplo, los identificadores 11, 12 y 100 cumplen la condición; 9 y 10 no.
            .Result
                Accede al resultado de la tarea devuelta por GetBookByIdAsync.
                Moq permite configurar de esta forma métodos asíncronos, aunque normalmente es más claro y recomendable utilizar ReturnsAsync.

            .Returns(output)
                Indica que, cuando la invocación coincida con la configuración, el mock devolverá el objeto output.


             */


            var controller = new BooksController(bookRepositoryMock.Object);
            var result = await controller.GetBook(9);
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var book = Assert.IsAssignableFrom<Book>(okResult.Value);
            Assert.Equal("Book 1", book.Title);

        }

    }
}
