using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books
{
    interface IReader
    {
        public void Read(Book b, double rate);
       
        public void PrintReadTitles();

    }
    public class Readers : Person, IReader
    {
        List<string> ReadTitles = new List<string>();
        Dictionary<string, string> allTypeRead = new Dictionary<string, string>();

        public Readers(string name, string lastn, string gen) : base(name, lastn, gen) { }

        public void Read(Book b, double rate)
        {
            ReadTitles.Add(b.name);
            b.rate += rate;
            b.numRates++;
        }

        public void PrintReadTitles()
        {
            foreach (string i in ReadTitles)
            {
                Console.WriteLine("{0}, \n", i);
            }
            return;
        }


    }
}
