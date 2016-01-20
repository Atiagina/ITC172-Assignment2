using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for BooksAndAuthors
/// </summary>
public class BooksAndAuthors
{
		SqlConnection connect;
	public BooksAndAuthors()
	{
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksAuthorConnectionString"].ToString());
	}

    public DataTable GetAuthors() {

        string sql = "SELECT AuthorKey, AuthorName FROM Author";

        SqlCommand cmd = new SqlCommand(sql, connect);

        DataTable tbl = null;

        try {
            tbl = ProcessQuery(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        

        return tbl;
    }

    public DataTable GetBooks(int AuthorKey)
    {
        string sql = "SELECT * FROM Book INNER JOIN AuthorBook ON Book.BookKey=AuthorBook.BookKey WHERE Authorkey = @AuthorKey";

        SqlCommand cmd = new SqlCommand(sql, connect);

        cmd.Parameters.AddWithValue("@Authorkey", AuthorKey);

        DataTable tbl = null;

        try
        {
            tbl = ProcessQuery(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }


        return tbl;

    }

    private DataTable ProcessQuery(SqlCommand cmd) {

        DataTable table = new DataTable();
        SqlDataReader reader;

        try
        {
            connect.Open();
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.Close();
        }
        catch (Exception ex) {
            throw ex;
        }

        return table;
    }
	
}