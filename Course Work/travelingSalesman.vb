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

Public Sub Permute(n As Integer, Optional printem As Boolean = True)
    'Generate, count and print (if printem is not false) all permutations of first n integers

    Dim P() As Integer
    Dim t As Integer, i As Integer, j As Integer, k As Integer
    Dim count As Long
    Dim Last As Boolean

    If n <= 1 Then
        'Debug.Print "Please give a number greater than 1"
        Exit Sub
    End If
    'Initialize
    ReDim P(n)
    For i = 1 To n
        P(i) = i
    Next
    count = 0
    Last = False
    Do While Not Last
        'print?
        If printem Then

            For t = 1 To n
                'Debug.Print P(t)
            Next
            Debug.Print
        End If
        count = count + 1
        Last = True
        i = n - 1
        Do While i > 0
            If P(i) < P(i + 1) Then
                Last = False
                Exit Do
            End If
            i = i - 1
        Loop
        j = i + 1
        k = n
        While j < k
            ' Swap p(j) and p(k)
            t = P(j)
            P(j) = P(k)
            P(k) = t
            j = j + 1
            k = k - 1
        End While
        j = n
        While P(j) > P(i)
            j = j - 1
        End While
        j = j + 1
        'Swap p(i) and p(j)
        t = P(i)
        P(i) = P(j)
        P(j) = t
    Loop 'While not last

    'Debug.Print "Number of permutations: "; count

End Sub
