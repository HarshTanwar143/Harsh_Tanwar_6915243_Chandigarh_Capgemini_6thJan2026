using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LibraryFrontend
{
    internal class Program
    {
        static string connectionString =
            "Data Source=DESKTOP-CT4MMTD\\SQLEXPRESS01;Initial Catalog=LibraryDB;TrustServerCertificate=True;Integrated Security=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n---- Library Management ----");
                Console.WriteLine("1. Insert Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");
                Console.Write("Select Option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: InsertBook(); break;
                    case 2: GetAllBooks(); break;
                    case 3: UpdateBook(); break;
                    case 4: DeleteBook(); break;
                    case 5: return;
                    default: Console.WriteLine("Invalid Option"); break;
                }
            }
        }

        static void ShowAuthors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Authors", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("\nAvailable Authors:");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["AuthorId"] + " - " + row["AuthorName"]);
                }
            }
        }

        static void InsertBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();

            ShowAuthors();
            Console.Write("Enter AuthorId: ");
            int authorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Published Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand("sp_InsertBook", con);
                da.InsertCommand.CommandType = CommandType.StoredProcedure;

                da.InsertCommand.Parameters.AddWithValue("@Title", title);
                da.InsertCommand.Parameters.AddWithValue("@AuthorId", authorId);
                da.InsertCommand.Parameters.AddWithValue("@PublishedYear", year);

                con.Open();
                da.InsertCommand.ExecuteNonQuery();
                Console.WriteLine("Book Inserted Successfully");
            }
        }

        static void GetAllBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetAllBooks", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(row["BookId"] + " | " +
                                      row["Title"] + " | " +
                                      row["AuthorName"] + " | " +
                                      row["PublishedYear"]);
                }
            }
        }

        static void UpdateBook()
        {
            Console.Write("BookId: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Title: ");
            string title = Console.ReadLine();

            ShowAuthors();
            Console.Write("AuthorId: ");
            int authorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Published Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = new SqlCommand("sp_UpdateBook", con);
                da.UpdateCommand.CommandType = CommandType.StoredProcedure;

                da.UpdateCommand.Parameters.AddWithValue("@BookId", id);
                da.UpdateCommand.Parameters.AddWithValue("@Title", title);
                da.UpdateCommand.Parameters.AddWithValue("@AuthorId", authorId);
                da.UpdateCommand.Parameters.AddWithValue("@PublishedYear", year);

                con.Open();
                da.UpdateCommand.ExecuteNonQuery();
                Console.WriteLine("Book Updated Successfully");
            }
        }

        static void DeleteBook()
        {
            Console.Write("BookId: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.DeleteCommand = new SqlCommand("sp_DeleteBook", con);
                da.DeleteCommand.CommandType = CommandType.StoredProcedure;

                da.DeleteCommand.Parameters.AddWithValue("@BookId", id);

                con.Open();
                da.DeleteCommand.ExecuteNonQuery();
                Console.WriteLine("Book Deleted Successfully");
            }
        }
    }
}