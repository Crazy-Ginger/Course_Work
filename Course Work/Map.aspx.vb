Public Class Map
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim suffix As Integer = 1
    End Sub
    Protected Sub AddDestination_Click(sender As Object, e As EventArgs, ByRef suffix) Handles AddDestination.Click

        Dim Destination As New Textboxmaker
        Destination.ID = "Destination" & suffix

        suffix += 1
        Me.Controls.Add(Destination)
        Destination.Visible = True

    End Sub
End Class
Public Class Textboxmaker
    Inherits TextBox
    Public ID As String


End Class