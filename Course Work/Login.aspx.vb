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
        If String.IsNullOrEmpty(tb_password.Text) = True Then
            l_noPassword.Visible = True
            l_noUsername.Visible = False
            l_Incorrect.Visible = False
        ElseIf String.IsNullOrEmpty(tb_username.Text) = True Then
            l_noUsername.Visible = True
            l_noPassword.Visible = False
            l_Incorrect.Visible = False
        ElseIf Connection.Login(tb_username.Text, tb_password.Text) Is Nothing Then
            l_Incorrect.Visible = True
            l_noPassword.Visible = False
            l_noUsername.Visible = False
        Else
            Session("logged_in") = True
            Response.Redirect("Map.aspx", True) 'used response.redirect as apposed to Server.transfer to minimise the size of the website in memory
        End If
    End Sub
End Class