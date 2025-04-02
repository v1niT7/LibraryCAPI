namespace Library.Models;

public record BookRequest(string Title, string Author, int YearPublication, string Gender, double Price, string ImageUrl);