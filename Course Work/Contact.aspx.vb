Public Class Contact
    Inherits Page
    Public usertable As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim str_email As New StringBuilder
        str_email.Append("mailto:ADMIN@CROSSLEYHEATH.ORG.UK")
        If Session("logged_in") = True Then
            str_email.Append("?cc=")
            str_email.Append((usertable.Get_email(Session("username"))).ToString)
        End If
        h_email.NavigateUrl = str_email.ToString

    End Sub
End Class