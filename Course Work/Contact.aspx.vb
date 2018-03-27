Public Class Contact
    Inherits Page
    Public usertable As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim email As New StringBuilder
        testbox1.Text = Session("username")

        email.Append("mailto:ADMIN@CROSSLEYHEATH.ORG.UK")
        If Session("logged_in") = True Then
            email.Append("?Cc=")

            TestBox2.Text = usertable.get_email_return(Session("username")).ToString

            email.Append((usertable.get_email_return(Session("username"))).ToString)


        End If
        TestBox3.Text = email.ToString
        h_email.ResolveUrl(email.ToString)
    End Sub
End Class