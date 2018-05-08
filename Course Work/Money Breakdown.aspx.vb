Imports System
Public Class Weekly_Summary
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("logged_in") <> True Then
        '    MsgBox("You need to login to access this feature")
        '    Server.Transfer("Login.aspx")
        'End If
        If Session("Passed") = True Then
            tb_distance.Text = (shortest.distance / 1000)
            Dim rounded As Double = Math.round((shortest.duration / 3600), 2)
            tb_duration.Text = rounded
            tb_URL.Text = shortest.url
            For Each node As String In shortest.nodes
                bl_nodes.Items.Add(node)
            Next
        End If
    End Sub

End Class