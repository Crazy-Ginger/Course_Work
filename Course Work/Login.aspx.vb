Imports System.Data.OleDb
Imports System.Threading
Public Class Login
    Inherits System.Web.UI.Page
    Public myConnection As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim Login As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|User details.accdb")
        'Login.Open()
        'Dim commandstring As New OleDbCommand("SELECT Username FROM Users", Login)
        'Dim reader As OleDbDataReader = (commandstring.ExecuteReader())
        'While reader.Read()
        '    TextBox1.Text = (reader("Username")).ToString
        'End While      this code does succesfully access the database and pull a user name from the users databased
        Dim strings As String = Session("logged_in")
        If strings = "in" Then
            Response.Redirect("Map.aspx") 'use response.readirect to remove this page from the memory
        End If
    End Sub

    Protected Sub B_Login_Click(sender As Object, e As EventArgs) Handles B_Login.Click
        If myConnection.Login(Tb_username.Text, Tb_password.Text) Is Nothing Then
            L_Incorrect.Visible = True
        Else
            Session("logged_in") = "in"
            Response.Redirect("Weekly Summary.aspx", True) 'used response.redirect as apposed to Server.transfer to minimise the size of the website in memory
        End If
    End Sub
End Class