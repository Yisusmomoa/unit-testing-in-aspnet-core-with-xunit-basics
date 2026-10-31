using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace TestProject2.Fixture
{
    //Su responsabilidad principal es administrar el ciclo de vida de LibraryDbContext durante las pruebas.

    public class LibraryDbContextFixture2 : IAsyncLifetime //IAsyncLifetime es una interfaz de xUnit que permite ejecutar operaciones asíncronas durante el ciclo de vida de una clase de pruebas o Fixture.
    {
        public LibraryDbContext DbContext { get; private set; } = default;

        public async Task InitializeAsync()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase("TestLibraryDb")
                .Options;
            DbContext = new LibraryDbContext(options);
            await DbContext.Database.EnsureCreatedAsync();
            DbInitializer.Initialize(DbContext);
        }

        public async Task DisposeAsync()
        {
            await DbContext.Database.EnsureDeletedAsync();
            await DbContext.DisposeAsync();
        }

        /*
         ¿Cuál es el propósito de esta clase?
            Imagina que quieres probar un servicio llamado BookService, que necesita consultar libros en una base de datos.

            Para probarlo necesitas:
            1. Crear una base de datos de prueba.
            2. Configurar Entity Framework Core.
            3. Crear un DbContext.
            4. Insertar algunos datos iniciales.
            5. Ejecutar las pruebas.
            6. Eliminar la base de datos y liberar los recursos.
            En lugar de repetir esos pasos en cada prueba, creas un Fixture que se encargue de todo.

            En este caso, LibraryDbContextFixture2 es el responsable de esa preparación y limpieza.|
            

         */

    }
}
