Imports System.Threading
Public Class Login
    Inherits System.Web.UI.Page
    Public Connection As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim logged_In As Boolean = Session("logged_in")
        If logged_In = True Then
            Response.Redirect("Stopover.aspx") 'use response.readirect to remove this page from the memory
        End If
    End Sub

    Protected Sub B_Login_Click(sender As Object, e As EventArgs) Handles b_Login.Click

        If Connection.Login(tb_username.Text, tb_password.Text) Is Nothing Or Connection.Login(tb_username.Text, tb_password.Text) < 0 Then
            l_Incorrect.Visible = True
        Else
            Session("logged_in") = True
            Response.Redirect("Map.aspx", True) 'used response.redirect as apposed to Server.transfer to minimise the size of the website in memory
        End If
    End Sub
End Class