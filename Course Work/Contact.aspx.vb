Public Class Contact
    Inherits Page
    Public usertable As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim var_email As New StringBuilder
        var_email.Append("mailto:ADMIN@CROSSLEYHEATH.ORG.UK")
        If Session("logged_in") = True Then
            var_email.Append("?Cc=")
            var_email.Append((usertable.get_email_return(Session("username"))).ToString)
        End If
        h_email.ResolveUrl(var_email.ToString)
    End Sub
End Class