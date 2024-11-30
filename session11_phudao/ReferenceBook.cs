using System;

class ReferenceBook: Book {
    public string topic;
    public string publisher;

    public ReferenceBook(
        string bookId,
        string bookName,
        string author,
        double price,
        string topic,
        string publisher
    ): base(bookId, bookName, author, price) {
        this.topic = topic;
        this.publisher = publisher;
    }

    public override void displayInfo()
    {
        base.displayInfo();
        Console.WriteLine($"Topic: {topic}, Publisher: {publisher}");
    }
}