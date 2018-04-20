Public Class Weekly_Summary
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("logged_in") <> True Then
            MsgBox("You need to login to access this feature")
            Server.Transfer("Login.aspx")

        End If
    End Sub

End Class