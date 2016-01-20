<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Classic ADO Assignment 2: Books</title>
    <link href="Assignment2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4>Assignment 2
            <br />
            ITC172 W16
            <br />
            Student: Anna Atiagina
        </h4>
        <h1>Books and Authors Table</h1>
        <asp:DropDownList ID="AuthorDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AuthorDownList_SelectedIndexChanged"></asp:DropDownList>
        <asp:GridView ID="BooksView" runat="server"></asp:GridView>
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
