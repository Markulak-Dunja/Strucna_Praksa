using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BookDay2.webapi.Controllers
{
    public class TheController : ApiController
    {
        static public List<Book> bookList = new List<Book>() { new Book("LOTR", "JRR Tolkein"), new Book("Hamlet", "W.Shakespeare"), new Book("Souls Trilogy", "Deborah Harkness") };


        //POST
        [Route("api/create")]

        public HttpResponseMessage Post([FromBody] Book b)
        {
            bookList.Add(new Book(b.name, b.author));
            return Request.CreateResponse(HttpStatusCode.OK, bookList[bookList.Count - 1]);
        }

        //GET1
        [Route("api/get")]

        public HttpResponseMessage Get()
        {
            if (bookList.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, bookList);
        }

        //GET2
        [Route("api/getAuthor")]

        public HttpResponseMessage GetAuthor([FromUri] string name1)
        {

            foreach (Book b in bookList)
            {
                if (b.name == name1)
                    return Request.CreateResponse(HttpStatusCode.OK, b.author);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, name1);


        }

        //PUT
        [Route("api/put")]

        //https://localhost:44384/api/put?name1=LOTR&name2=TwoTowers
        public HttpResponseMessage PutName([FromUri] string name1, [FromUri] string name2)
        {
            foreach (Book b in bookList)
            {
                if (b.name == name1)
                {
                    b.name = name2;
                    return Request.CreateResponse(HttpStatusCode.OK, "new name of " + " " + name1 + " " + "is" + " " + name2);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        //DEL
        [Route("api/del")]

        public IHttpActionResult Delete([FromBody] Book b1)
        {
            foreach (Book b in bookList)
            {
                if (b.name == b1.name && b.author == b1.author)
                {
                    bookList.Remove(b);
                    return Ok("Book" + " " + b.name + " " + " " + "removed");
                }
            }
            return NotFound();

        }
    }


    //KLASA BOOK
    public class Book
    {
        public string name { get; set; }
        public string author { get; set; }
        public Book(string n, string a)
        {
            name = n; author = a;
        }
    }

}
