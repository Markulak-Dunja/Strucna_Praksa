using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public class Drama:Book
    {
        public static List<string> types = new List<string> { "Comedy", "Tragic", "Tragycomedy", "Melodrama" };

        public string type;


        public Drama(string name1, Person author1, string type1, string publisher1, int edition1, int pageNum1, string ISBN1) :
            base(name1, author1, publisher1, edition1, pageNum1, ISBN1)
        {
            if (types.Contains(type1))
                type = type1;
            else
                throw new System.ArgumentException("type is unknown");
        }

        public override void Info()
        {
            Console.WriteLine("name: {0} \n author: {1} {2} \n publisher: {3} \n edition: {4}. edition \n type: {5}",
                name, author.name, author.lastname, publisher, edition, type);
            return;
        }
    }
}
