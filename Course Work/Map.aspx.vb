Public Class Map
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If boxNum <> 0 Then
            For i As Integer = 0 To (boxNum)
                Dim testBox As New TextBox
                P_Dest_cont.Controls.Add(testBox)
            Next
        End If
    End Sub

    Protected Sub AddDestination_Click(sender As Object, e As EventArgs) Handles AddDestination.Click
        boxNum += 1
    End Sub
End Class

Public Module globalVariables
    Private priBoxNum As Int32 = 0
    Property boxNum As Int32
        Get
            Return priBoxNum
        End Get
        Set(value As Int32)
            priBoxNum = value
        End Set
    End Property
End Module

