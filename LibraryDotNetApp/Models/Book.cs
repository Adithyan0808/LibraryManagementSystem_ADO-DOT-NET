using System;


namespace Models.Book
{
    public class Book
    {
        // note no ; after properties
        public int? BookID { set; get; }
        public string? Title { set; get; }
        public string? Author { set; get; }
        public string? Genre { set; get; }
        public int? PublicationYear { set; get; }
        public int? IsAvailable { set; get; }
        public decimal? Price { set; get; }
        public int? CopiesAvailable { set; get; }

        public Book()
        {}

        public Book(string Title,string Author,string Genre,int PublicationYear,int IsAvailable,decimal Price,int CopiesAvailable)
        {
            this.Title = Title;
            this.Author = Author;
            this.Genre = Genre;
            this.PublicationYear = PublicationYear;
            this.IsAvailable = IsAvailable;
            this.Price = Price;
            this.CopiesAvailable = CopiesAvailable;
        }

    }




}















