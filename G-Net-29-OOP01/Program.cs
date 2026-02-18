#region Part 01
/*
Q1) Class vs Struct:
- class: reference type, copied by reference, can be null, supports inheritance.
- struct: value type, copied by value, cannot be null (unless nullable), no inheritance (except from ValueType).

Q2) public vs private:
- public: accessible from anywhere.
- private: accessible only inside the same class (encaps).

Q3) Steps to create/use Class Library in Visual Studio:
1) Create new project -> Class Library (.NET)
2) Add classes and build the library
3) In the main project: Add -> Project Reference -> select the library
4) Use the namespace and call the library classes.

Q4) What is a class library? Why use it?
- A reusable project that contains classes (DLL) used by other projects.
- Benefits: reuse, clean architecture, separation of concerns, easier maintenance/testing.
*/
#endregion

#region Part 02 - Movie Ticket Booking System
enum TicketType
{
    Standard = 0,
    VIP = 1,
    IMAX = 2
}
struct Seat
{
    public char Row;
    public int Number;

    public Seat(char row, int number)
    {
        Row = row;
        Number = number;
    }

    public override string ToString() => $"{Row}{Number}";
}

// 3) Ticket class
class Ticket
{
    
    public string MovieName;
    public TicketType Type;
    public Seat Seat;
    private double Price;

    public Ticket(string movieName, TicketType type, Seat seat, double price)
    {
        MovieName = movieName;
        Type = type;
        Seat = seat;
        Price = price;
    }
    public Ticket(string movieName)
        : this(movieName, TicketType.Standard, new Seat('A', 1), 50)
    {
    }
    public double CalcTotal(double taxPercent)
    {
        return Price + (Price * taxPercent / 100.0);
    }
    public void ApplyDiscount(ref double discountAmount)
    {
        if (discountAmount > 0 && discountAmount <= Price)
        {
            Price -= discountAmount;
            discountAmount = 0;
        }
    }
    public void PrintTicket(double taxPercent)
    {
        System.Console.WriteLine("===== Ticket Info =====");
        System.Console.WriteLine($"Movie : {MovieName}");
        System.Console.WriteLine($"Type  : {Type}");
        System.Console.WriteLine($"Seat  : {Seat}");
        System.Console.WriteLine($"Price : {Price:F2}");
        System.Console.WriteLine($"Total ({taxPercent}% tax) : {CalcTotal(taxPercent):F2}");
    }
}
class Program
{
    static void Main()
    {
        const double taxPercent = 14;

        System.Console.Write("Enter Movie Name: ");
        string movie = System.Console.ReadLine();

        System.Console.Write("Enter Ticket Type (0 = Standard, 1 = VIP, 2 = IMAX): ");
        TicketType type = (TicketType)int.Parse(System.Console.ReadLine());

        System.Console.Write("Enter Seat Row (A, B, C...): ");
        char row = char.Parse(System.Console.ReadLine());

        System.Console.Write("Enter Seat Number: ");
        int number = int.Parse(System.Console.ReadLine());

        System.Console.Write("Enter Price: ");
        double price = double.Parse(System.Console.ReadLine());

        System.Console.Write("Enter Discount Amount: ");
        double discount = double.Parse(System.Console.ReadLine());

        // Create ticket with all info
        Ticket ticket = new Ticket(movie, type, new Seat(row, number), price);

        // Before discount
        System.Console.WriteLine();
        ticket.PrintTicket(taxPercent);

        // After discount
        System.Console.WriteLine();
        System.Console.WriteLine("===== After Discount =====");
        double discountBefore = discount;
        ticket.ApplyDiscount(ref discount);

        System.Console.WriteLine($"Discount Before : {discountBefore:F2}");
        System.Console.WriteLine($"Discount After  : {discount:F2}");
        ticket.PrintTicket(taxPercent);
    }
}
#endregion
