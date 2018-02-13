Public Class Route

    Private privateRouteNodes() As Node

    ReadOnly Property routeNodes() As Node
        Get
            Return routeNodes
        End Get
    End Property

    Public Sub New(ByVal startpoint As Node, ByVal endpoint As Node, ByVal points As Node)
        privateRouteNodes = plotRoute(startpoint, endpoint)
    End Sub

    Private Function plotRoute(ByVal startpoint As Node, ByVal endpoint As Node) As Node()
        'Traveling salesman code goes here
    End Function

    Public Function coordinate(ByVal Location As String)

    End Function
End Class

Sub main()
    Dim nodes As New list(Of Integer)
    Dim numNodes As Integer
    numNodes = console.readline()
    For i As Integer = 1 To numNodes
        nodes.add(i)
    Next
    Permutation(nodes, numNodes)
End Sub
Public Structure Node
    Dim X As Int32
    Dim Y As Int32
End Structure

Public Function Permutation(ByVal nodes As list(Of Integer), ByVal low As Integer = 0)
    If low + 1 >= nodes.Count Then

    End If
End Function
