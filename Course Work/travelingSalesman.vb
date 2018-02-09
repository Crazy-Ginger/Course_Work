Public Class Route

    Private privateRouteNodes() As Node

    ReadOnly Property routeNodes() As Node
        Get
            Return routeNodes
        End Get
    End Property

    Public Sub New(ByVal startpoint As Node, ByVal endpoint As Node)
        privateRouteNodes = plotRoute(startpoint, endpoint)
    End Sub

    Private Function plotRoute(ByVal startpoint As Node, ByVal endpoint As Node) As Node()
        'Traveling salesman code goes here
    End Function
End Class

Public Structure Node
    Dim X As Int32
    Dim Y As Int32
End Structure
