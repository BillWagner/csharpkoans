using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpKoans
{
    public class Library
    {
        public IList<Book> Books { get; set; }
        public Library()
        {
            Books = new List<Book> { 
                new Book("Lolita, light of my life, fire of my loins.")
                {
                    Title = "Lolita", Author = "Nabokov", PublicationYear = 1955
                },

                new Book("All this happened, more or less.")
                {
                    Title="Slaughterhouse-Five", Author="Vonnegut", PublicationYear=1969
                },

                new Book("Sir. Neither you nor I speak English, but there are some things that can be said only in English.")
                {
                    Title="The White Tiger", Author="Adiga", PublicationYear=2008
                },

                new Book("Happy families are all alike; every unhappy family is unhappy in its own way.")
                {
                    Title="Anna Karenina" ,Author="Tolstoy",PublicationYear=1877
                }
            };
        }
    }

    public class Book
    {
        public Book(string firstSentence) 
        {
            FirstSentence = firstSentence;
        }
       
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string FirstSentence{get;private set;}
        public string StartReading()
        {
            return FirstSentence;
        }
    }
}
