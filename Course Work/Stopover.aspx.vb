Imports System.Threading
Public Class Stopover
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("logged_in") = True Then
            l_LoggedIn.Visible = True
            Thread.Sleep(20000)
            Response.Redirect("Map.aspx")
        Else Session("logged_in") = False
            l_Not_loggedIn.Visible = True
            Thread.Sleep(20000)
            Response.Redirect("Login.aspx")
        End If
    End Sub

End Class