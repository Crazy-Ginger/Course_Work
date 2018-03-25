Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Data
Imports System.Threading

Public Class Shorter
    Public distance As Integer
    Public duration As Integer
    Public nodes As New List(Of Integer)
    Public url As String
End Class


Public Class Map
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For i As Integer = 1 To 100
            ddl_Destinations.Items.Add(i)
        Next
        'If boxes.numb > 20 Then
        '    boxes.numb = 20
        '    lb_toomany.Visible = True
        'End If
        For i As Integer = 1 To Session("boxes")
            Dim tb_dest As New TextBox
            tb_dest.ID = "tb_dest_" & i
            tb_dest.AutoCompleteType = AutoCompleteType.HomeZipCode
            tb_dest.Width = 200
            p_routenodes.Controls.Add(tb_dest)
        Next
        tb_Distance.Text = Session("boxes")
        'tb_Distance.Text = Session("boxes")
    End Sub


    Protected Sub AddDestination_Click(sender As Object, e As EventArgs) Handles b_AddDestination.Click
        ddl_Destinations.SelectedValue = Session("boxes")
        tb_Distance.Text = Session("boxes")
    End Sub


    Protected Sub RouteCalc_Click(sender As Object, e As EventArgs) Handles b_RouteCalc.Click
        If Session("logged_in") = False Then
            Response.Redirect("Stopover.aspx")
        End If
        If String.IsNullOrEmpty(tb_Start.Text) = True Or Session("boxes") = 0 Then   'if there is no start destination the algorithm doesn't run
            l_noStart.Visible = True
        Else

            Dim last As Boolean = True
            Dim nodes As New List(Of String)    'will contain the addresses so it can be passed between subs
            nodes.Add(tb_Start.Text)    'adds the start
            For Each tb As TextBox In p_routenodes.Controls.OfType(Of TextBox)()    'cycles through the text boxes created and adds their text to the node list
                If String.IsNullOrEmpty(tb.Text) = True Or tb.Text = " " Then
                    'stops a blank address being added and posisbly causing problem
                Else
                    nodes.Add(tb.Text)
                End If
            Next

            'checks if there is a designated final destination
            If String.IsNullOrEmpty(tb_End.Text) = True Or tb_End.Text = " " Then
                last = False
            Else
                last = True
                nodes.Add(tb_End.Text)
            End If

            'removes spaces from the addresses in the nodes
            For i As Integer = 0 To nodes.Count() - 1
                nodes.Item(i) = nodes.Item(i).Replace(" ", "")
            Next

            Dim shortest As Shorter = Permute(nodes.Count, nodes, last)
        End If
    End Sub


    'Public Sub Permute(ByVal length As Integer, ByRef nodes As List(Of String), ByVal End_dest As Boolean)
    '    'Creates the variables to be used in the algorithm
    '    Dim P(length - 1) As Integer
    '    Dim swapper As Integer
    '    Dim initial_comp As Integer
    '    Dim rearrange As Integer
    '    Dim asc_swapper As Integer
    '    Dim count As Long
    '    Dim Last As Boolean

    '    'Fills the array with pointers that can be sorted
    '    For i = 0 To length - 1
    '        P(i) = i
    '        shortest.nodes.Add(i)
    '    Next
    '    'Checks if there is a set end point that should not be shuffled
    '    If End_dest = True Then
    '        length -= 1
    '    End If

    '    count = 0
    '    Last = False
    '    Dim watch As Stopwatch = Stopwatch.StartNew()   'records the time it takes for all the permutations to be calculated (temp)

    '    Do While Not Last
    '        'outputs the pointers and destinations in order
    '        Sort_array(P, length, nodes, End_dest)
    '        count += 1
    '        Last = True
    '        initial_comp = length - 2
    '        'finds the largest pointer out of place (from the back)
    '        Do While initial_comp > 0
    '            If P(initial_comp) < P(initial_comp + 1) Then
    '                Last = False
    '                Exit Do
    '            End If
    '            initial_comp = initial_comp - 1
    '        Loop

    '        rearrange = initial_comp + 1
    '        asc_swapper = length - 1
    '        'rearranges all the pointers behind the out of place pointer into ascending numerical order
    '        While rearrange < asc_swapper
    '            ' Swap p(j) and p(k)
    '            swapper = P(rearrange)
    '            P(rearrange) = P(asc_swapper)
    '            P(asc_swapper) = swapper
    '            rearrange += 1
    '            asc_swapper -= 1
    '        End While

    '        rearrange = length - 1
    '        'finds the pointer to be swapped with the out of place pointer
    '        While P(rearrange) > P(initial_comp)
    '            rearrange -= 1
    '        End While

    '        rearrange += 1

    '        'makes the swap to place the large number in front
    '        swapper = P(initial_comp)
    '        P(initial_comp) = P(rearrange)
    '        P(rearrange) = swapper
    '    Loop
    '    watch.Stop()
    '    Console.WriteLine("Number of permutations: " & count & vbTab & "That was: " & watch.Elapsed.TotalMilliseconds & "ms, " & watch.ElapsedTicks & " ticks")

    'End Sub


    'Public Sub Sort_array(ByRef array() As Integer, ByVal length As Integer, ByRef nodes As List(Of String), ByVal end_dest As Boolean)
    '    If end_dest = True Then 'if there was an end destination being used then the length must be increased so that it is printed
    '        length += 1
    '    End If

    '    For t As Integer = 0 To length - 1
    '        Console.Write(array(t) & ": " & nodes.Item(array(t)) & ", ")
    '    Next

    '    Dim dist_dura() As Integer = Waypointing(array, length, nodes)   'sends this to the function that should return the length/duration of the route
    '    Dim retest As Integer = shortest.distance

    '    If dist_dura(0) < retest Then   'compares the existing shortest route with the current one
    '        shortest.distance = dist_dura(0)
    '        shortest.duration = dist_dura(1)
    '        For i As Integer = 0 To array.Length - 1
    '            shortest.nodes.Item(i) = array(i)
    '        Next
    '    Else

    '    End If
    '    Console.WriteLine("Shortest: " & shortest.distance)
    '    Console.WriteLine()
    'End Sub


    'Function Waypointing(ByRef array() As Integer, ByVal length As String, ByRef nodes As List(Of String)) As Integer()
    '    'Builds request string
    '    Dim waypointkey As String = "AIzaSyBqN-1pDwR8taEDQESDP5mnJjiJkIXmv-w"
    '    Dim request_url As String = "https://maps.googleapis.com/maps/api/directions/json?origin="
    '    request_url += nodes.Item(0)
    '    request_url += "&destination=" & nodes.Item(array(length - 1)) & "&waypoints="
    '    For t As Integer = 1 To length - 2
    '        request_url += "via:" & nodes.Item(array(t)) & "|"
    '    Next
    '    request_url += "&key=" & waypointkey
    '    tb_URL.Text = request_url
    '    'pulls the GEOJSON data and puts it into a string
    '    'Console.WriteLine(request_url)

    '    'Try
    '    '    Dim test_stream As Stream = client.OpenRead(request_url)
    '    '    Console.WriteLine("It worked inside the try")
    '    '    sucess = True
    '    'Catch ex As Exception
    '    '    sucess = False
    '    '    Console.WriteLine("It did't work")
    '    'End Try
    '    Dim client As New WebClient()
    '    Dim client_Stream As Stream = client.OpenRead(request_url)
    '    Dim streamreading As New StreamReader(client_Stream)
    '    Dim Server_JSON_str As String = streamreading.ReadToEnd()
    '    streamreading.Close()

    '    'tries To make the JSON data Using JObject (did't know how to search the JObject for useful data
    '    'Dim jdata As JObject = JObject.Parse(Server_JSON_str)


    '    'searches for a key phrase then retrieves the value associated with the key phrase
    '    'finds the physical length of the journey
    '    Dim search_dist As String = "distance"
    '    Dim dist_char As Integer = Server_JSON_str.IndexOf(search_dist)

    '    dist_char = Server_JSON_str.IndexOf("value")
    '    dist_char += 9
    '    Dim dist_converter As String = ""
    '    For i As Integer = dist_char To Server_JSON_str.Length
    '        If Server_JSON_str.Substring(i, 1) = " " Then
    '            Exit For
    '        Else
    '            dist_converter += Server_JSON_str.Substring(i, 1)
    '        End If
    '    Next
    '    Console.WriteLine()
    '    Console.WriteLine("Dist converter: " & dist_converter)

    '    Dim distance As Integer = CInt(dist_converter)

    '    'finds the time length of the journey
    '    Dim damaged_JSON As String = Right(Server_JSON_str, Server_JSON_str.Length - dist_char)
    '    Dim search_dura As String = "duration"
    '    Dim dura_char As Integer = damaged_JSON.IndexOf(search_dura)
    '    'Console.WriteLine(dura_char)
    '    dura_char = damaged_JSON.IndexOf("value")
    '    dura_char += 9
    '    Dim dura_converter As String = ""
    '    For i As Integer = dura_char To damaged_JSON.Length
    '        If damaged_JSON.Substring(i, 1) = " " Then
    '            Exit For
    '        Else
    '            dura_converter += damaged_JSON.Substring(i, 1)
    '        End If
    '    Next
    '    Dim duration As Integer = Integer.Parse(dura_converter)

    '    'tried to make this convert the string from the website to a class to make getting data really easily
    '    'Dim JSON_object As List(Of JSON_data.Rootobject) = JsonConvert.DeserializeObject(Of List(Of JSON_data.Rootobject))(Server_JSON_str)

    '    Console.WriteLine("Distance: " & distance & " (m)")
    '    Console.WriteLine("Duration: " & duration & " (s)" & vbTab & Math.Floor(duration / 3600) & " hours  " & Math.Round((duration Mod 3600) / 60) & " minutes")
    '    Dim passed(1) As Integer
    '    passed(0) = distance
    '    passed(1) = duration
    '    Return passed
    '    'Else
    '    '    Return Nothing
    '    'End If
    'End Function
End Class
