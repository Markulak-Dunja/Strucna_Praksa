using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public class Educational:Book
    {
        public static List<string> fields = new List<string> { "math", "physics", "chemistry", "biology", "computer science", "art" };
        public static List<string> lvls = new List<string> { "beginner", "intermediate", "advanced", "expert" };



        public string field, lvl;


        public Educational(string name1, Person author1, string field1, string publisher1, int edition1, int pageNum1, string ISBN1, string lvl1) :
            base(name1, author1, publisher1, edition1, pageNum1, ISBN1)
        {
            if (fields.Contains(field1))
                field = field1;
            else
                throw new System.ArgumentException("field is unknown");

            if (lvls.Contains(lvl1))
                lvl = lvl1;
            else
                throw new System.ArgumentException("level is unknown");

        }

        public override void Info()
        {
            Console.WriteLine(" name: {0} \n author: {1} {2} \n publisher: {3} \n edition: {4}. edition \n field: {5}\n rate: {6}",
                name, author.name,author.lastname, publisher, edition, field, GetRate());
            return;
        }
    }
}
