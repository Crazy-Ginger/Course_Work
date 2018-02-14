Public Class TSP
    Public Sub Decision(ByRef points() As Object, ByVal numNodes As Integer)
        If numNodes < 10 Then
            Permutation(points, numNodes)
        End If

    End Sub

    Public Function Permutation(ByVal points() As Object, ByVal numNodes As Integer)
        Return Nothing
    End Function
End Class
