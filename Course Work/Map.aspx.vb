Imports travelingSalesman

Public Class Map
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BoxNumVal.Text = boxNum
        If boxNum <> 0 Then
            For i As Integer = 1 To (boxNum)
                Dim testBox As New TextBox
                P_Dest_cont.Controls.Add(testBox)
            Next
        End If

        Dim start As Node
        start.X = 12
        start.Y = 54
        Dim ending As Node
        ending.X = 321
        ending.Y = -1234

        Dim currentRoute As New Route(start, ending)
        plot(currentRoute.routeNodes)
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

