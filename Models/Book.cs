namespace Library.Models;

public class Book
{
    // init diz que quando tiver a instancia do objeto, ele vai setar os valores automaticamente
    // se nao for um caso de guid ele pode ser alterado somente uma vez
    public Guid Id { get; init; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
    public string Gender { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }

    public Book()
    {
        
    }

    public Book(string title, string author, int publicationYear, string gender, double price, string imageUrl)
    {
        // toda vez que uma instancia for criada gera um novo UID
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        Gender = gender;
        Price = price;
        ImageUrl = imageUrl;
    }
}