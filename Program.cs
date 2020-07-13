using System;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            Person fScott = new Person("F.Scott", "Fitzgerald", "male");
            Novel n1 = new Novel("THE GREAT GATSBY", fScott, "Tragedy", "Charles Scribner's Sons", 5, 218, "9781897412977");

            Person eWarthon = new Person("Edith", " Wharton", "female");
            Novel n2 = new Novel("THE AGE OF INNOCENCE", eWarthon, "Romance", " D. Appleton & Company", 4, 293, "9781547897410");

            Person Tolkein = new Person(" John Ronald Reuel", "Tolkien", "male");
            Novel n3 = new Novel("THE LORD OF THE RINGS, THE FELLOWSIP OF THE RING)", Tolkein, "Fantasy", "Allen & Unwin", 4, 423, "9781123541875");

            Person Shakespeare = new Person("William", "Shakespeare", "male");
            Drama d1 = new Drama("HAMLET", Shakespeare, "Tragycomedy", "Simon & Schuster", 3, 500, "9781126710393");

            Person eAlbee = new Person("Edward", "Albee", "male");
            Drama d2 = new Drama("WHO'S AFRAID OF VIRGINIA WOOLF?", eAlbee, "Melodrama", "Berkley ", 3, 130, "9780451158710");


            Person jSax = new Person("Jr.John H.", "Saxon", "male");
            Educational e1 = new Educational("ADVANCED MATHEMATICS", jSax, "math", "Saxon publishers ", 2, 245, "9781565770393", "advanced");

            Person tHorman = new Person("Thomas", "H. Cormen", "male");
            Educational e2 = new Educational("Introduction to Algorithms", tHorman, "computer science", "The Massachusetts Institute of Technology", 2, 120002, "9781235754393", "intermediate");


            Readers r1 = new Readers("Talia", "Huang", "female");
            Readers r2 = new Readers("Allison", "Blaese", "female");
            Readers r3 = new Readers("Jackob", "Bonilla", "male");


            n3.Info();
            d2.Info();
            r1.Read(n1, 5);
            r1.Read(d1, 3.2);
            r1.Read(n3, 5);

            r2.Read(e1, 3.5);
            r2.Read(e2, 4.3);

            r3.Read(d2, 3.5);
            r3.Read(d1, 4.6);
            r3.Read(n2, 3.2);

            Console.WriteLine("\n {0} {1} has read these books: \n",r2.name, r2.lastname);
            r2.PrintReadTitles();


            Console.WriteLine("\n {0} is rated as {1} \n", n3.name, n3.GetRate());


        }
    }
}
