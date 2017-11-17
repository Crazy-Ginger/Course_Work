Public Class Register
    Inherits System.Web.UI.Page
    Public regconnection As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub b_Register_Click(sender As Object, e As EventArgs) Handles b_Register.Click
        Dim username As String
        Dim email As String
        If regconnection.dupeCheck(username, email) Is Nothing Then

        End If
    End Sub
End Class