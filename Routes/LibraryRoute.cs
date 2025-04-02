using Library.Models;

namespace Library.Routes;

//Criando static para não ter que instanciar a classe e ja ser instanciada em tempo de execução
//Quando uma classe é estatica todos os membros devem ser static tambem
public static class LibraryRoute
{
    // this antes do tipo de objeto diz que é metodo de extensão
    public static void LibraryRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");
        route.MapPost("", async (BookRequest request, LibraryContext context) =>
        {
            var book = new Book(request.Title, request.Author, request.YearPublication, request.Gender, request.Price,
                request.ImageUrl);
            await context.AddAsync(book);
            await context.SaveChangesAsync();
        });
    }
}