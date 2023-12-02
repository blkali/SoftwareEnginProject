using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryProject
{
    class Library : ILibrary
    {
        private string connection_string = "Data Source=.;Initial Catalog=LibraryProject;Integrated Security=true";
        public bool delete(int bookId)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            try
            {
                string query = "delete from Library where bookId =" + bookId;
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool insert(string bookName, string published, string author, string ganer, int countPage, int price)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            try
            {
                string query = "insert into Library (bookName,published,ganer,author,countPage,price) values (@bookName,@published,@ganer,@author,@countPage,@price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@bookName", bookName);
                command.Parameters.AddWithValue("@published", published);
                command.Parameters.AddWithValue("@ganer", ganer);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@countPage", countPage);
                command.Parameters.AddWithValue("@price", price);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable search_author(string parameter)
        {
            string query = $"select * from Library where author like N'%{parameter}%'";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adaptor = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            return data;
        }

        public DataTable search_ganer(string parameter)
        {
            string query = $"select * from Library where ganer like N'%{parameter}%'";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adaptor = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            return data;
        }

        public DataTable search_name_book(string parameter)
        {
            string query = $"select * from Library where bookName like N'%{parameter}%'";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adaptor = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            return data;
        }

        public DataTable selectAll()
        {
            string query = "Select * From Library";
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable selectRow(int bookId)
        {
            string query = "select * from Library where bookId="+bookId;
            SqlConnection connection = new SqlConnection(connection_string);
            SqlDataAdapter adaptor = new SqlDataAdapter(query,connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            return data;
        }

        public bool update(int bookId, string bookName, string published,string ganer, string author, int countPage, int price)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            try
            {
                string query = "update Library set bookName=@bookName,published=@published,ganer=@ganer,author=@author,countPage=@countPage,price=@price where bookId="+bookId;
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@bookName", bookName);
                command.Parameters.AddWithValue("@published", published);
                command.Parameters.AddWithValue("@ganer", ganer);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@countPage", countPage);
                command.Parameters.AddWithValue("@price", price);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
