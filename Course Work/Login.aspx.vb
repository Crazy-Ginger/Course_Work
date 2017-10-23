Imports System.Data.OleDb
Public Class Login
    Inherits System.Web.UI.Page
    Public dataQueries As New DataSet1TableAdapters.TableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Login As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|Datadirectory|User details.accdb")
        Login.Open()
        Dim username_query As String = "SELECT username FROM users"
        Dim password_query As String = "SELECT password from users"
        Dim usernames As New OleDbCommand(username_query, Login)
        Dim passwords As New OleDbCommand(password_query, Login)
        Dim reader_pass As OleDbDataReader = passwords.ExecuteReader()
        Dim reader_user As OleDbDataReader = usernames.ExecuteReader()

    End Sub

    Protected Sub B_Login_Click(sender As Object, e As EventArgs) Handles B_Login.Click
        Dim login As String = Tb_username.Text
        Dim password As String = Tb_password.Text
        If login <> reader_pass() And reader_user() Then

        End If
    End Sub
End Class