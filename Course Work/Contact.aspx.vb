Public Class Contact
    Inherits Page
    Public usertable As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim str_email As New StringBuilder
        TestBox2.Text = Session("username")
        testbox1.Text = Session("logged_in")
        str_email.Append("mailto:ADMIN@CROSSLEYHEATH.ORG.UK")
        If Session("logged_in") = True Then
            str_email.Append("?cc=")

            TestBox3.Text = usertable.Get_email(Session("username")).ToString

            str_email.Append((usertable.Get_email(Session("username"))).ToString)


        End If
        TestBox4.Text = str_email.ToString

        'h_email.ResolveUrl("mailto:ADMIN@CROSSLEYHEATH.ORG.UK?cc=mattydwardle@gmail.com")
    End Sub
End Class