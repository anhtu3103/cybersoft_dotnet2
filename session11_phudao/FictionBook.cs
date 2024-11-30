using System;

class FictionBook: Book {
    public string genre;
    public string year;

    public FictionBook(
        string bookId,
        string bookName,
        string author,
        double price,
        string genre,
        string year
    ): base(bookId, bookName, author, price) {
        this.genre = genre;
        this.year = year;
    }

    public override void displayInfo()
    {
        base.displayInfo();
        Console.WriteLine($"Genre: {genre}, Year: {year}");
    }
}