using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public class Person
    {
        public string name, lastname, gender;
        public Person(string firstn, string lastn, string gen)
        {
            name = firstn;
            lastname = lastn;
            gender = gen;
        }
    }
    public abstract class Book
    {
        public string name { get; }
        protected string ISBN;
        public Person author { get; }
        public string publisher, variation;
        public int edition, pageNum, numRates;
        public double rate;


        public Book(string name1, Person author1, string publisher1, int edition1, int pageNum1, string ISBN1)
        {
            name = name1;
            author = author1;
            publisher = publisher1;
            edition = edition1;
            pageNum = pageNum1;

            if (ISBN1.Length == 13)
                ISBN = ISBN1;
            else
                throw new System.ArgumentException("invalid ISBN");

            if (variation != "paperback" || variation != "hardcover")
                ISBN = ISBN1;
            else
                throw new System.ArgumentException("invalid atribute variation");

            rate = 0;
            numRates = 0;
        }
        public abstract void Info();

        public double GetRate()
        {
            if (numRates > 0)
            {
                return rate / numRates;

            }

            else
                Console.WriteLine("The book hasn't been rated yet");
            return -1;

        }

    }
}
