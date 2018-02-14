Public Class plot
    Public Sub Decisions(ByRef nodes As Object, ByVal numNodes As Integer)
        numNodes = Console.ReadLine()
        If numNodes < 10 Then
            Permute(nodes, numNodes)
        End If

    End Sub

    Private Function Permute(ByVal nodes As Object, ByVal numNodes As Integer)
        Return Nothing
    End Function

End Class