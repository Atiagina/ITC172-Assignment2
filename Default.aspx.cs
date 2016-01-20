using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    BooksAndAuthors ba = new BooksAndAuthors();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAuthorDropDown();
        }
    }
    protected void AuthorDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGridView();
    }

    protected void FillAuthorDropDown()
    {

        DataTable table = ba.GetAuthors();

        AuthorDownList.DataSource = table;
        AuthorDownList.DataTextField = "AuthorName";
        AuthorDownList.DataValueField = "AuthorKey";
        AuthorDownList.DataBind();
    }

    protected void FillGridView()
    {

        int key = int.Parse(AuthorDownList.SelectedValue.ToString());
        DataTable table = null;

        try
        {
            table = ba.GetBooks(key);
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = ex.Message;
        }

        BooksView.DataSource = table;
        BooksView.DataBind();


    }
}