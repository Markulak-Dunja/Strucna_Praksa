using System;
using System.Collections.Generic;

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

            List<Novel> novel = new List<Novel> { n1, n2, n3 };
            List<Drama> drama = new List<Drama> { d1, d2 };
            List<Educational> edu = new List<Educational> { e1, e2 };


            Readers r1 = new Readers("Talia", "Huang", "female");
            Readers r2 = new Readers("Allison", "Blaese", "female");
            Readers r3 = new Readers("Jackob", "Bonilla", "male");
            List<Readers> r = new List<Readers> { r1, r2, r3 };
            r1.Read(n1, 5);
            r1.Read(d1, 3.2);
            r1.Read(n3, 5);

            r2.Read(e1, 3.5);
            r2.Read(e2, 4.3);

            r3.Read(d2, 3.5);
            r3.Read(d1, 4.6);
            r3.Read(n2, 3.2);

            Console.WriteLine("List of all novels: {0}, {1}, {2}\n", n1.name, n2.name, n3.name);
            Console.WriteLine("List of all dramas: {0}, {1}\n", d1.name, d2.name);
            Console.WriteLine("List of all educations: {0}, {1}\n", e1.name, e2.name);

            Console.WriteLine("Do you want info about one of the books? Y/N");

            string user1 = Console.ReadLine();

            while (user1 != "n" && user1 != "N") { 
    
                Console.WriteLine("Is book a novel, drama or educational?");
                string user2 = Console.ReadLine();
                Console.WriteLine("What is the name of the book?");
                string user3 = Console.ReadLine();

                if (user2 == "novel" || user2 == "Novel" || user2 == "NOVEL")
                {
                    foreach(Novel n in novel) { if (n.name == user3) n.Info(); }
                }
                if (user2 == "drama" || user2 == "Drama" || user2 == "DRAMA")
                {
                    foreach (Drama n in drama) { if (n.name == user3) n.Info(); }
                }
                if (user2 == "educational" || user2 == "Educational" || user2 == "EDUCATIONAL")
                {
                    foreach (Educational n in edu) { if (n.name == user3) n.Info(); }
                }
               
                Console.WriteLine("Do you want info about one of the books? Y/N");

                user1 = Console.ReadLine();
            }



            Console.WriteLine("\n List of readers: {0} {1}, {2} {3}, {4} {5}\n",r1.name,r1.lastname,r2.name, r2.lastname, r3.name, r3.lastname);

            Console.WriteLine("Do you want to know what books specific reader read?Y/N");
            string user4 = Console.ReadLine();

            while (user4 != "n" && user4 != "N")
            {
                Console.WriteLine("enter first name of reader: ");
                string user5 = Console.ReadLine();
                Console.WriteLine("enter last name of reader: ");
                string user6 = Console.ReadLine();

                foreach (Readers n in r) { if (n.name == user5 && n.lastname == user6) n.PrintReadTitles(); }
                Console.WriteLine("Do you want to know what books specific reader read?Y/N");
                 user4 = Console.ReadLine();
            }

        }
    }
}
