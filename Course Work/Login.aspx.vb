Imports System.Data.OleDb
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub B_Login_Click(sender As Object, e As EventArgs) Handles B_Login.Click
        Dim login As String = Tb_username.Text
        Dim password As String = Tb_password.Text

    End Sub
End Class