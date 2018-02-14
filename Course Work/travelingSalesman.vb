Public Function Start()
    Dim nodes As New List(Of Integer)
Dim numNodes As Integer
numNodes = Console.ReadLine()
    For i As Integer = 1 To numNodes
        nodes.Add(i)
    Next
    Permute(nodes, numNodes)
End Sub