using biblioteca.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;

namespace biblioteca.web.Pages.Books
{
    public class DeleteModel : PageModel
    {

        public string errorMessage = string.Empty;
        public string successMessage = string.Empty;

        public string connectionString = "Data Source=.\\SQLSERVERNAME;Initial Catalog=databasename;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True";

        public Book book = new Book();

        public void OnGet()
        {
            string sBookId = Request.Query["id"].ToString();
            int iBookId = int.Parse(sBookId);
            book.id = iBookId;

            getBookInfo();
        }

        public void OnPost()
        {
            int iId;
            Int32.TryParse(Request.Form["idHidden"].ToString(), out iId);


            deleteBookInfo(iId);

            successMessage = "book deleted correctly";

        }

        public void getBookInfo()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlsentence = string.Format("Select * from libros where id={0}", book.id);

                    using (SqlCommand cmd = new SqlCommand(sqlsentence, connection))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                book.id = reader.GetInt32(0);
                                book.name = reader.GetString(1);
                                book.autor = reader.GetString(2);
                                book.pages = reader.GetInt16(3);
                                book.genre = reader.GetString(4);
                                book.year = reader.GetString(5);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception: " + ex.ToString());
            }
        }

        public void deleteBookInfo(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlsentence = string.Format("delete libros where id=@id;");

                using (SqlCommand command = new SqlCommand(sqlsentence, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}