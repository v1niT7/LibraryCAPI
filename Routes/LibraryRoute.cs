using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Routes;

//Criando static para não ter que instanciar a classe e ja ser instanciada em tempo de execução
//Quando uma classe é estatica todos os membros devem ser static tambem
public static class LibraryRoute
{
    // this antes do tipo de objeto diz que é metodo de extensão
    public static void LibraryRoutes(this WebApplication app)
    {
        var route = app.MapGroup("books");
        route.MapGet("listar", async (LibraryContext context) =>
        {
            var books = await context.Books.ToListAsync();
            if (books.Count == 0)
            {
                return Results.NotFound();
            }
            return Results.Ok(books);
        });
        route.MapGet("buscar/{id:guid}", async (Guid id, LibraryContext context) =>
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(book);
        });
        // async indica que o metodo é assincrono
        route.MapPost("criar", async (BookRequest request, LibraryContext context) =>
        {
            var book = new Book(request.Title, request.Author, request.PublicationYear, request.Gender, request.Price,
                request.ImageUrl);
            //await é para reforçar que o metodo é assincrono
            await context.AddAsync(book);
            // commit
            await context.SaveChangesAsync();
        });
        route.MapPut("atualizar/{id:guid}", async (Guid id, BookRequest request, LibraryContext context) =>
        {
            // O metodo FirstOrDefaultAsync retorna um Book ou nulo se nao encontrar e nao gera excecao
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return Results.NotFound();
            }
            book.Title = request.Title;
            book.Author = request.Author;
            book.PublicationYear = request.PublicationYear;
            book.Gender = request.Gender;
            book.Price = request.Price;
            book.ImageUrl = request.ImageUrl;
            // commit
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
        route.MapPatch("/atualizar/preco/{id:guid}",
            async (Guid id,double price, LibraryContext context) =>
            {
                var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book == null)
                {
                    return Results.NotFound();
                }
                book.Price = price;
                // commit
                await context.SaveChangesAsync();
                return Results.NoContent();
            });
        route.MapDelete("deletar/{id:guid}", async (Guid id, LibraryContext context) =>
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return Results.NotFound();
            }

            context.Books.Remove(book);
            // commit
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}