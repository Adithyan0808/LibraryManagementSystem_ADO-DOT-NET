
using System;
using System.Text;
using Microsoft.Data.SqlClient;
using Models.Book;



namespace LibraryDotNetApp
{
    public class Program
    {
        public static class ConnectionStringProvider
        {
            public static string ConnectionString {get;} = "Server=localhost;Database=Library;User ID=sa;Password=YourPassword123!;Trusted_Connection=False;Persist Security Info=False;Encrypt=False";
        }
        public static string connection = ConnectionStringProvider.ConnectionString;

        // adding book
        public static void AddBook(Book book)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("insert into Book(Title,Author,Genre,PublicationYear,IsAvailable,Price,CopiesAvailable)");
            query.AppendLine("values(@Title,@Author,@Genre,@PublicationYear,@IsAvailable,@Price,@CopiesAvailable);");
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query.ToString(),conn))
                {
                    cmd.Parameters.AddWithValue("@Title",book.Title);
                    cmd.Parameters.AddWithValue("@Author",book.Author);
                    cmd.Parameters.AddWithValue("@Genre",book.Genre);
                    cmd.Parameters.AddWithValue("@PublicationYear",book.PublicationYear);
                    cmd.Parameters.AddWithValue("@IsAvailable",book.IsAvailable);
                    cmd.Parameters.AddWithValue("@Price",book.Price);
                    cmd.Parameters.AddWithValue("@CopiesAvailable",book.CopiesAvailable);
                    int rows_affected = cmd.ExecuteNonQuery();
                    if(rows_affected>0)
                        Console.WriteLine("Book added successfully.");
                }
            }

        }

        public static void DisplayAllBooks()
        {
            string query = "select * from Book;";
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Book obj = new Book();
                            obj.BookID = (int)reader["BookID"];
                            obj.Title = (string)reader["Title"];
                            obj.Genre = (string)reader["Genre"];
                            obj.PublicationYear = (int)reader["PublicationYear"];
                            obj.IsAvailable = (int)reader["IsAvailable"];
                            obj.Price = (decimal)reader["Price"];
                            obj.CopiesAvailable = (int)reader["CopiesAvailable"];
                            Console.WriteLine($"BookID:{obj.BookID},Title:{obj.Title},Author:{obj.Author},Genre:{obj.Genre},PublicationYear:{obj.PublicationYear}\nIsAvailable:{obj.IsAvailable},Price:{obj.Price},CopiesAvailable:{obj.CopiesAvailable}\n");
                        }
                    }
                }
            }
        }


        public static void UpdateBook(string oldTitle,string oldAuthor,Book book)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("update Book set Title=@Title,Genre=@Genre,PublicationYear=@PublicationYear,IsAvailable=@IsAvailable,Price=@Price,CopiesAvailable=@CopiesAvailable");
            query.AppendLine("where Title=@oldTitle and Author=@oldAuthor");
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query.ToString(),conn))
                {
                    cmd.Parameters.AddWithValue("@Title",book.Title);
                    cmd.Parameters.AddWithValue("@Author",book.Author);
                    cmd.Parameters.AddWithValue("@Genre",book.Genre);
                    cmd.Parameters.AddWithValue("@PublicationYear",book.PublicationYear);
                    cmd.Parameters.AddWithValue("@IsAvailable",book.IsAvailable);
                    cmd.Parameters.AddWithValue("@Price",book.Price);
                    cmd.Parameters.AddWithValue("@CopiesAvailable",book.CopiesAvailable);
                    cmd.Parameters.AddWithValue("@oldTitle",oldTitle);
                    cmd.Parameters.AddWithValue("@oldAuthor",oldAuthor);
                    int rows_affected = cmd.ExecuteNonQuery();
                    if(rows_affected>0)
                        Console.WriteLine("Book updated successfully.");  
                }              
            }
        }

        public static void DeleteBook(string title,string author)
        {
            string query = "delete * from Book where Title=@title and Author = @author;";
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@title",title);
                    cmd.Parameters.AddWithValue("@author",author);
                    int rows_affected = cmd.ExecuteNonQuery();
                    if(rows_affected>0)
                        Console.WriteLine("Book deleted successfully.");
                }
            }
        }

        public static void SearchBooksByTitle(string title)
        {
            string query = "select * from Book where Title=@title";
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@title",title);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Book obj = new Book();
                            obj.BookID = (int)reader["BookID"];
                            obj.Title = (string)reader["Title"];
                            obj.Genre = (string)reader["Genre"];
                            obj.PublicationYear = (int)reader["PublicationYear"];
                            obj.IsAvailable = (int)reader["IsAvailable"];
                            obj.Price = (decimal)reader["Price"];
                            obj.CopiesAvailable = (int)reader["CopiesAvailable"];
                            Console.WriteLine($"BookID:{obj.BookID},Title:{obj.Title},Author:{obj.Author},Genre:{obj.Genre},PublicationYear:{obj.PublicationYear}\nIsAvailable:{obj.IsAvailable},Price:{obj.Price},CopiesAvailable:{obj.CopiesAvailable}\n");
                        }
                    }
                }
            }
        }

        public static void BooksByAvailability(int IsAvailable)
        {
            string query = "select * from Book where IsAvailable = @IsAvailable";
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@IsAvailable",IsAvailable);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Book obj = new Book();
                            obj.BookID = (int)reader["BookID"];
                            obj.Title = (string)reader["Title"];
                            obj.Genre = (string)reader["Genre"];
                            obj.PublicationYear = (int)reader["PublicationYear"];
                            obj.IsAvailable = (int)reader["IsAvailable"];
                            obj.Price = (decimal)reader["Price"];
                            obj.CopiesAvailable = (int)reader["CopiesAvailable"];
                            Console.WriteLine($"BookID:{obj.BookID},Title:{obj.Title},Author:{obj.Author},Genre:{obj.Genre},PublicationYear:{obj.PublicationYear}\nIsAvailable:{obj.IsAvailable},Price:{obj.Price},CopiesAvailable:{obj.CopiesAvailable}\n");
                        }
                    }
                }
            }
        }



        public static void Main(string[] args)
        {
            Console.WriteLine("   ----- Library Management System -----   ");
            while(true)
            {
                Console.WriteLine("        1. AddBook");
                Console.WriteLine("        2. Display All Books");
                Console.WriteLine("        3. Update Book Details");
                Console.WriteLine("        4. Delete Book");
                Console.WriteLine("        5. Search Books By Title");
                Console.WriteLine("        6. Filter Books By Availability");
                Console.WriteLine("        7. Exit \n");

                Console.WriteLine("Enter the Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Book book = new Book();
                        Console.WriteLine("Enter Book Details");
                        Console.WriteLine("Title : ");
                        book.Title = Console.ReadLine();
                        Console.WriteLine("Genre : ");
                        book.Genre = Console.ReadLine();
                        Console.WriteLine("Publication Year : ");
                        book.PublicationYear = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("IsAvailable : ");
                        book.IsAvailable = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Price : ");
                        book.Price = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Copies Available : ");
                        book.CopiesAvailable = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Author : ");
                        book.Author = Console.ReadLine();
                        AddBook(book);
                        break;

                    case 2:
                        DisplayAllBooks();
                        break;
                    case 3:
                        Book book1 = new Book();
                        Console.WriteLine("Old Title : ");
                        string oldTitle = Console.ReadLine();
                        Console.WriteLine("Old Author : ");
                        string oldAuthor = Console.ReadLine();
                        Console.WriteLine("Enter Book Details to Update ");
                        Console.WriteLine("Title : ");
                        book1.Title = Console.ReadLine();
                        Console.WriteLine("Genre : ");
                        book1.Genre = Console.ReadLine();
                        Console.WriteLine("Publication Year : ");
                        book1.PublicationYear = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("IsAvailable : ");
                        book1.IsAvailable = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Price : ");
                        book1.Price = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Copies Available : ");
                        book1.CopiesAvailable = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Author : ");
                        book1.Author = Console.ReadLine();
                        UpdateBook(oldTitle,oldAuthor,book1);
                        break;

                    case 4:
                        Console.WriteLine("Delete Book");
                        Console.WriteLine("Enter Title : ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter Author : ");
                        string Author = Console.ReadLine();
                        DeleteBook(title,Author);
                        break;

                    case 5:
                        Console.WriteLine("Search books by title");
                        Console.WriteLine("Title : ");
                        string title2 = Console.ReadLine();
                        SearchBooksByTitle(title2);
                        break;

                    case 6:
                        Console.WriteLine("Filter Books By Availability");
                        Console.WriteLine("Availability (1/0) : ");
                        int val = Convert.ToInt32(Console.ReadLine());
                        BooksByAvailability(val);
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice....");
                        break;


                }




            }
            
        }



    }
}