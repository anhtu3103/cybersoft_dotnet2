using System.IO;
using Newtonsoft.Json;

class LibraryManager {
    public string libraryId { get; set; }
    public string libraryName { get; set; }
    public List<Book> books { get; set; }
    public string filePath = "libary.json";

    private void loadFromFile() {
        if (File.Exists(filePath)) {
            string json = File.ReadAllText(filePath);

            //convert json to list
            books = JsonConvert.DeserializeObject<List<Book>>(json);
            Console.WriteLine("Load file thành công");
        } else { 
            books = new List<Book>();
            Console.WriteLine("file không tồn tại. Tạo mới danh sách");
        }
    }

    private void saveToFile()
    {
        //convert list to json
        string json = JsonConvert.SerializeObject(books, Formatting.Indented);

        //Save file
        File.WriteAllText(filePath, json);
        Console.WriteLine("Lưu file thành công");
    }

    public LibraryManager(string libaryId, string libaryName)
    {
        this.libraryId = libaryId;
        this.libraryName = libaryName;
        loadFromFile();
    }

    public void addBook(Book book)
    {
        if(books.Any(b => b.bookId == book.bookId))
        {
            Console.WriteLine("Mã sách đã tồn tại. Vui lòng nhập mã khác!");
        }
        else
        {
            books.Add(book);
            saveToFile();
            Console.WriteLine("Thêm sách thành công");
        }    
    }

    public void addTextBook() {
        Console.WriteLine("Nhập mã sách: ");
        string bookId = Console.ReadLine();

        Console.WriteLine("Nhập tên sách: ");
        string bookName = Console.ReadLine();


        Console.WriteLine("Nhập tác giả: ");
        string author = Console.ReadLine();

        Console.WriteLine("Nhập giá sách: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Nhập môn học: ");
        string subject = Console.ReadLine();

        Console.WriteLine("Nhập lớp: ");
        string grade = Console.ReadLine();

        TextBook textBook = new TextBook(bookId, bookName, author, price, subject, grade);
        addBook(textBook);
    }

    public void addReferenceBook() {
        Console.WriteLine("Nhập mã sách: ");
        string bookId = Console.ReadLine();

        Console.WriteLine("Nhập tên sách: ");
        string bookName = Console.ReadLine();

        Console.WriteLine("Nhập tác giả: ");
        string author = Console.ReadLine();

        Console.WriteLine("Nhập giá sách: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Nhập chủ đề: ");
        string topic = Console.ReadLine();

        Console.WriteLine("Nhập nhà xuất bản: ");
        string publisher = Console.ReadLine();

        ReferenceBook referenceBook = new ReferenceBook(bookId, bookName, author, price, topic, publisher);
        addBook(referenceBook);

    }

    public void displayAllBook()
    {
        Console.WriteLine("====== Libary book ======");
        if (books.Count == 0)
        {
            Console.WriteLine("Không có sách nào trong thư viện!");
            return;
        }
        foreach (Book book in books)
        {
            book.displayInfo();
        }
    }
}