using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public class Novel:Book
    {
        public static List<string> all_genre = new List<string> { "Crime", "Drama", "Fantasy", "Adventure", "SF", "Fairytale", "Mystery", "Poetry", "Romance", "Tragedy" };

        public string genre;
        public bool status;
        private int specId { set; get; }

        public Novel(string name1, Person author1, string genre1, string publisher1, int edition1, int pageNum1, string ISBN1) :
            base(name1, author1, publisher1, edition1, pageNum1, ISBN1)
        {
            if (all_genre.Contains(genre1))
                genre = genre1;
            else
                throw new System.ArgumentException("genre is unknown");
        }

        public override void Info()
        {
            Console.WriteLine("name: {0} \n author: {1} \n publisher: {2} \n edition: {3}. edition \n genre: {4}",
                name, author, publisher, edition, genre);
            return;
        }

    }
}
