Imports System.Data.OleDb
Public Class Login
    Inherits System.Web.UI.Page
    Public dataQueries As New DataSet1TableAdapters.TableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim Login As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|Datadirectory|/User details.accdb")
        'Login.Open()
        'Dim username_query As String = "SELECT username FROM users"
        'Dim password_query As String = "SELECT password from users"
        'Dim usernames As New OleDbCommand(username_query, Login)
        'Dim passwords As New OleDbCommand(password_query, Login)
        'Dim reader_pass As OleDbDataReader = passwords.ExecuteReader()
        'Dim reader_user As OleDbDataReader = usernames.ExecuteReader()
        Dim Login As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|User details.accdb")
        Login.Open()
        Dim commandstring As New OleDbCommand("SELECT Username FROM users WHERE ID=3", Login)
        Dim reader As OleDbDataReader = (commandstring.ExecuteReader())
        TextBox1.Text = (reader).ToString
    End Sub

    Protected Sub B_Login_Click(sender As Object, e As EventArgs) Handles B_Login.Click
        Dim Login As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|User details.accdb")
        Login.Open()
        Dim commandstring As New OleDbCommand("SELECT Username FROM users WHERE ID=3", Login)
        Dim reader As OleDbDataReader = (commandstring.ExecuteReader())
        TextBox1.Text = (reader).ToString
        Dim logincommand As New OleDbCommand("SELECT COUNT(*) FROM users WHERE username=@username AND password=@password", Login)
        logincommand.Parameters.AddWithValue("@username", Tb_username)
        logincommand.Parameters.AddWithValue("@password", Tb_password)
        Dim check As Integer = 0
        check = Val(logincommand.ExecuteScalar())
        If check > 0 Then
            Session("logged in") = True
            L_Incorrect.Text = "Logged in"
            L_Incorrect.Visible = True
            'Server.Transfer("Weekly Summary.aspx", True)
        Else
            L_Incorrect.Visible = True
        End If
    End Sub
End Class