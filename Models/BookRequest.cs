namespace Library.Models;

public record BookRequest(string Title, string Author, int PublicationYear, string Gender, double Price, string ImageUrl);