Imports System.Data.OleDb
Imports System.Threading
Public Class Login
    Inherits System.Web.UI.Page
    Public myConnection As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim executable As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        'Dim datapath As String = (System.IO.Path.GetDirectoryName(executable))
        'AppDomain.CurrentDomain.SetData("DataDirectory", datapath)
        Dim Login As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|User details.accdb")
        Login.Open()
        Dim commandstring As New OleDbCommand("SELECT Username FROM Users", Login)
        Dim reader As OleDbDataReader = (commandstring.ExecuteReader())
        While reader.Read()
            TextBox1.Text = (reader("Username")).ToString
        End While

    End Sub

    Protected Sub B_Login_Click(sender As Object, e As EventArgs) Handles B_Login.Click
        'Dim Login As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|User details.accdb")
        'Login.Open()
        'Dim logincommand As New OleDbCommand("SELECT COUNT(*) FROM users WHERE username=@username AND password=@password", Login)
        'logincommand.Parameters.AddWithValue("@username", Tb_username)
        'logincommand.Parameters.AddWithValue("@password", Tb_password)
        'Dim check As Integer = 0
        'Dim reader As OleDbDataReader = (logincommand.ExecuteReader())
        'While reader.Read()
        '    check = Val(logincommand.ExecuteScalar())
        '    If check > 0 Then
        '        Session("logged in") = True
        '        L_Incorrect.Text = "Logged in"
        '        L_Incorrect.Visible = True
        '        'Server.Transfer("Weekly Summary.aspx", True)
        '    Else
        '        L_Incorrect.Visible = True
        '    End If
        'End While

        If myConnection.Login(Tb_username.Text, Tb_password.Text) Is Nothing Then
            L_Incorrect.Visible = True
        Else
            L_Incorrect.Text = "Logged in"
            L_Incorrect.Visible = True
            Thread.Sleep(1500)
            Server.Transfer("Weekly Summary.aspx", True)
        End If


    End Sub
End Class