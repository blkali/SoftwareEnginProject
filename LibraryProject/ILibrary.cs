using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibraryProject
{
    interface ILibrary
    {
        DataTable selectAll();
        DataTable selectRow(int bookId);
        DataTable search_name_book(string parameter);
        DataTable search_ganer(string parameter);
        DataTable search_author(string parameter);
        bool insert(string bookName, string published, string author,string ganer, int countPage, int price);
        bool update(int bookId, string bookName, string published,string ganer, string author, int countPage, int price);
        bool delete(int bookId);
        
    }
}
