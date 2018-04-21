Imports System.IO
Imports System.Net

Module Routing
    Public shortest As New Shorter
    Public Current_URL As New StringBuilder

    Public Function Permute(ByVal length As Integer, ByRef nodes As List(Of String), ByVal End_dest As Boolean)
        shortest.distance = 2147483646

        'Creates the variables to be used in the algorithm
        Dim P(length - 1) As Integer
        Dim swapper As Integer
        Dim initial_comp As Integer
        Dim rearrange As Integer
        Dim asc_swapper As Integer
        Dim count As Long = 0
        Dim Last As Boolean = False

        'Fills the array with pointers that can be sorted
        For i = 0 To length - 1
            P(i) = i
            shortest.nodes.Add(i)
        Next
        'Checks if there is a set end point that should not be shuffled
        If End_dest = True Then
            length -= 1
        End If

        'records the time it takes for all the permutations to be calculated (temp)
        Dim watch As Stopwatch = Stopwatch.StartNew()

        If Comparator(P, length, nodes, End_dest) = -1 Then
            shortest.duration = -1
        ElseIf Comparator(P, length, nodes, End_dest) = -2 Then
            shortest.duration = -2
        ElseIf Comparator(P, length, nodes, End_dest) = -3 Then
            shortest.duration = -3
        Else
            Do While Not Last
                'finds the length of the current route and sees if it is the shortest route currently created
                Comparator(P, length, nodes, End_dest)

                count += 1
                Last = True
                initial_comp = length - 2

                'finds the largest pointer out of place (from the back)
                Do While initial_comp > 0
                    If P(initial_comp) < P(initial_comp + 1) Then
                        Last = False
                        Exit Do
                    End If
                    initial_comp = initial_comp - 1
                Loop

                rearrange = initial_comp + 1
                asc_swapper = length - 1

                'rearranges all the pointers behind the out of place pointer into ascending numerical order
                While rearrange < asc_swapper
                    ' Swap p(j) and p(k)
                    swapper = P(rearrange)
                    P(rearrange) = P(asc_swapper)
                    P(asc_swapper) = swapper
                    rearrange += 1
                    asc_swapper -= 1
                End While

                rearrange = length - 1
                'finds the pointer to be swapped with the out of place pointer
                While P(rearrange) > P(initial_comp)
                    rearrange -= 1
                End While

                rearrange += 1

                'makes the swap to place the large number in front
                swapper = P(initial_comp)
                P(initial_comp) = P(rearrange)
                P(rearrange) = swapper
            Loop
        End If
        watch.Stop()

        'Console.WriteLine("Number of permutations: " & count & vbTab & "That was: " & watch.Elapsed.TotalMilliseconds & "ms, " & watch.ElapsedTicks & " ticks")
        Return shortest
    End Function


    Public Function Comparator(ByRef array() As Integer, ByVal length As Integer, ByRef nodes As List(Of String), ByVal end_dest As Boolean)
        'if there was an end destination being used then the length must be increased so that it is printed
        If end_dest = True Then
            length += 1
        End If

        'For t As Integer = 0 To length - 1
        '    Console.Write(array(t) & ": " & nodes.Item(array(t)) & ", ")
        'Next

        'sends this to the function that should return the length/duration of the route
        Dim current_route() As Integer = Datapull(array, length, nodes)
        'Dim retest As Integer = shortest.distance

        If current_route(0) = 2147483645 And current_route(1) = -1 Then
            Return current_route(1)
        ElseIf current_route(0) = 2147483645 And current_route(1) = -2 Then
            Return current_route(1)
        ElseIf current_route(0) = 2147483645 And current_route(1) = -3 Then
            Return current_route(1)
        Else
            Return 0
            'compares the existing shortest route with the current one
            If current_route(0) < shortest.distance Then
                shortest.distance = current_route(0)
                shortest.duration = current_route(1)
                shortest.url = Current_URL.ToString
                For i As Integer = 0 To array.Length - 1
                    shortest.nodes.Item(i) = nodes.Item(array(i))
                Next
            End If
        End If
        'Console.WriteLine("Shortest: " & shortest.distance)
        'Console.WriteLine()
    End Function


    Function Datapull(ByRef array() As Integer, ByVal length As String, ByRef nodes As List(Of String)) As Integer()
        'Builds request string
        'Dim waypointkey As String = "AIzaSyBqN-1pDwR8taEDQESDP5mnJjiJkIXmv-w"
        'Dim request_url As String = "https://maps.googleapis.com/maps/api/directions/json?origin="
        'request_url += nodes.Item(0)
        'request_url += "&destination=" & nodes.Item(array(length - 1)) & "&waypoints="
        'For t As Integer = 1 To length - 2
        '    request_url += "via:" & nodes.Item(array(t)) & "|"
        'Nexts
        'request_url += "&key=" & waypointkey


        Dim waypointkey As String = "AIzaSyBqN-1pDwR8taEDQESDP5mnJjiJkIXmv-w"
        Current_URL.Clear()
        Current_URL.Append("https://maps.googleapis.com/maps/api/directions/json?origin=")
        Current_URL.Append(nodes.Item(0))
        Current_URL.Append("&destination=" & nodes.Item(array(length - 1)) & "&waypoints=")
        For t As Integer = 1 To length - 2
            Current_URL.Append("via:" & nodes.Item(array(t)) & "|")
        Next
        Current_URL.Append("&key=" & waypointkey)

        Dim passed() As Integer = Status_check(Current_URL.ToString)
        'pulls the GEOJSON data and puts it into a string
        'Console.WriteLine(request_url)

        'Try
        '    Dim test_stream As Stream = client.OpenRead(request_url)
        '    Console.WriteLine("It worked inside the try")
        '    sucess = True
        'Catch ex As Exception
        '    sucess = False
        '    Console.WriteLine("It did't work")
        'End Try

        'For count As Integer = 1 To 4


        '    Dim client As New WebClient()
        '    'client.DownloadFile(request_url, "JSON_data.json")
        '    'Dim client_Stream As Stream = client.OpenRead(request_url)
        '    Dim client_Stream As Stream = client.OpenRead(Current_URL.ToString)     'Dim client_Stream As Stream = client.OpenRead(request_url)
        '    Dim streamreading As New StreamReader(client_Stream)
        '    Dim JSON_str As String = streamreading.ReadToEnd()



        '    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '    'using the class system (that doesn't work yet)
        '    'Dim JSON_token As JToken = JObject.Parse(JSON_str)
        '    'Dim distance As Integer = JSON_token.SelectToken("value")
        '    'Dim temp_json As DynamicObject = JsonConvert.DeserializeObject(Of ExpandoObject)(JSON_str)
        '    'tried to make this convert the string from the website to a class to make getting data really easily
        '    'above are the ones that I don't think will ever work


        '    'promising ========================================================
        '    'Dim temp_json As JSON_data.Rootobject = JsonConvert.DeserializeObject(Of JSON_data.Rootobject)(JSON_str)
        '    'Dim temp_jsonlist As List(Of JSON_data.Rootobject) = JsonConvert.DeserializeObject(Of List(Of JSON_data.Rootobject))(JSON_str)
        '    streamreading.Close()


        '    'Dim distance As Integer
        '    'Dim duration As Integer
        '    'Console.WriteLine(temp_json.status)
        '    ''Console.WriteLine(temp_jsonlist.Item(0).status)
        '    'If temp_json.status = "OK" Then
        '    '    'If temp_jsonlist.Item(0).status = "OK" Then

        '    '    distance = temp_json.routes.legs.distance.value
        '    '    duration = temp_json.routes.legs.duration.value

        '    '    'distance = temp_jsonlist.Item(0).routes.legs.distance.value
        '    '    'duration = temp_jsonlist.Item(0).routes.legs.duration.value
        '    'Else
        '    '    distance = 2147483646
        '    '    duration = 2147483646
        '    'End If
        '    'Console.WriteLine("The distance is: " & distance)
        '    'Console.WriteLine("The duration is: " & duration)
        '    'Dim passed(1) As Integer
        '    'passed(0) = distance    'distance
        '    'passed(1) = duration   'duration
        '    'Return passed
        '    '----------------------------------------------------------------------------------------------------------------------------------------------------




        '    'searches for a key phrase then retrieves the value associated with the key phrase
        '    'finds the length and estimated duration of the journey
        '    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        '    Dim status_search As String = Chr(34) & "status" & Chr(34)
        '    Dim status_index As Integer = JSON_str.IndexOf(status_search)
        '    status_index += 12
        '    Dim status As String = ""
        '    For i As Integer = status_index To JSON_str.Length
        '        If JSON_str.Substring(i, 1) = "" Then
        '            Exit For
        '            count += 1
        '        Else
        '            status += JSON_str.Substring(i, 1)
        '        End If
        '    Next

        '    'test if the status of the route is valid or not
        '    If status = "OK" Then

        '        'find the distance of the route
        '        Dim dist_char As Integer = JSON_str.IndexOf("value")
        '        dist_char += 9
        '        Dim dist_converter As String = ""
        '        For i As Integer = dist_char To JSON_str.Length
        '            If JSON_str.Substring(i, 1) = " " Then
        '                Exit For
        '            Else
        '                dist_converter += JSON_str.Substring(i, 1)
        '            End If
        '        Next
        '        Dim distance As Integer = CInt(dist_converter)
        '        'Console.WriteLine("Dist converter: " & dist_converter)


        '        'finds the time length of the journey
        '        Dim damaged_JSON As String = Right(JSON_str, JSON_str.Length - dist_char)

        '        Dim dura_char As Integer

        '        dura_char = damaged_JSON.IndexOf("value")
        '        dura_char += 9
        '        Dim dura_converter As String = ""
        '        For i As Integer = dura_char To damaged_JSON.Length
        '            If damaged_JSON.Substring(i, 1) = " " Then
        '                Exit For
        '            Else
        '                dura_converter += damaged_JSON.Substring(i, 1)
        '            End If
        '        Next
        '        Dim duration As Integer = CInt(dura_converter)

        '        'Console.WriteLine("Dist converter: " & dura_converter)
        '        '------------------------------------------------------------------------------------------------------------------------------------------------

        '        'Console.WriteLine("Distance: " & distance & " (m)")
        '        'Console.WriteLine("Duration: " & duration & " (s)" & vbTab & Math.Floor(duration / 3600) & " hours  " & Math.Round((duration Mod 3600) / 60) & " minutes")


        '        'passed(0) = temp_json.routes.legs.distance.value    'distance using the class
        '        'passed(1) = temp_json.routes.legs.duration.value    'duration using the class
        '        passed(0) = distance                        'distance using string parser
        '        passed(1) = duration                        'distance using string parser

        '        Return passed
        '        Exit Function

        '        'Else
        '        'Return Nothing
        '        'End If
        '    ElseIf status = "ZERO_RESULTS" Then
        '        passed(0) = 2147483645
        '        passed(1) = 2147483645
        '        Exit For

        '    ElseIf status = "NOT_FOUND" Then
        '        passed(0) = 2147483645
        '        passed(1) = -1
        '        Exit For

        '    ElseIf status = "OVER_QUERY_LIMIT" Then
        '        passed(0) = 2147483645
        '        passed(1) = -2
        '        Exit For

        '    ElseIf status = "MAX_WAYPOINTS_EXCEEDED" Then
        '        passed(0) = 2147483645
        '        passed(1) = -3
        '        Exit For

        '    ElseIf status = "MAX_ROUTE_LENGTH_EXCEEDED" Then
        '        passed(0) = 2147483645
        '        passed(1) = 2147483645
        '        Exit For

        '    Else
        '        passed(0) = 2147483645
        '        passed(1) = 2147483645
        '    End If
        'Next
        Return passed
    End Function


    Public Function Approximation(ByVal nodes As List(Of String), ByVal last As Boolean)
        'creates length that is the number of addresses being used
        Dim length As Integer = nodes.Count - 1
        'shortens length to ensure that if a last destination is chosen it remains the last address
        If last = True Then
            length -= 1
        End If
        'instantiating key variables
        Dim using_URL As New StringBuilder
        Dim next_nodes As List(Of String) = nodes
        Dim final_route As New List(Of String)
        Dim distance As Integer = 0
        Dim comp_dist As Integer = Integer.MaxValue
        Dim shortest_tree As New Integer

        'add the starting address and remove it from next_nodes
        final_route.Add(next_nodes.Item(0))
        next_nodes.RemoveAt(0)
        length -= 1

        'List_print(next_nodes, False)
        'Console.WriteLine("final_route:")
        'List_print(final_route, False)

        'run whilst there are still nodes within the copied list this will loop
        'While next_nodes.Count > 0
        While length > -1
            distance = Integer.MaxValue
            For current_index As Integer = 0 To length

                'creates URL to query distance between last node and the current node
                using_URL.Append("https://maps.googleapis.com/maps/api/directions/json?origin=")
                using_URL.Append(final_route.Item(final_route.Count - 1))
                using_URL.Append("&destination=" & next_nodes.Item(current_index) & "&key=AIzaSyBqN-1pDwR8taEDQESDP5mnJjiJkIXmv-w")

                Dim passed() As String = Status_check(using_URL.ToString)

                If passed(2) = -1 Then
                    'Console.WriteLine("Well that didn't work")
                ElseIf passed(2) = -2 Then
                    'Return -2
                    'Console.WriteLine("Well that didn't work: " & comp_dist)
                    Exit While
                ElseIf passed(2) = -3 Then
                    'Return -3
                    'Console.WriteLine("Well that didn't work: " & comp_dist)
                    Exit While
                ElseIf passed(2) = -4 Then
                    'Return -4
                    'Console.WriteLine("Well that didn't work: " & comp_dist)
                    Exit While
                ElseIf passed(0) < distance And comp_dist > 0 Then
                    distance = passed(0)
                    shortest_tree = current_index
                End If
                'Console.ReadLine()
                'List_print(next_nodes, False)
                'Console.WriteLine("final_route:")
                'List_print(final_route, False)
                using_URL.Clear()
            Next
            'adds the closest address to final_routes and removes it from the unvisited nodes list
            final_route.Add(next_nodes.Item(shortest_tree))
            next_nodes.RemoveAt(shortest_tree)
            length -= 1
        End While

        'if there was a fixed final destination this is now added to the final route
        If last = True Then
            final_route.Add(nodes.Item(nodes.Count - 1))
        End If
        Current_URL.Clear()
        'checks the approximate route is valid using the API
        Current_URL.Append("https://maps.googleapis.com/maps/api/directions/json?origin=")
        'adds the addresses to the URL
        Current_URL.Append(final_route.Item(0) & "&destination=")
        Current_URL.Append(final_route.Item(final_route.Count - 1) & "&waypoints=")
        For t As Integer = 1 To final_route.Count - 2
            Current_URL.Append("via:" & final_route.Item(t) & "|")
        Next
        Current_URL.Append("&key=AIzaSyBqN-1pDwR8taEDQESDP5mnJjiJkIXmv-w")

        'Dim passed(1) As Integer

        'tries 3 times to get a connection and the appropriate data unless 
        Dim passed() As Integer = Status_check(Current_URL.ToString)
        shortest.url = Current_URL.ToString
        shortest.distance = passed(0)
        shortest.duration = passed(1)
        Return shortest
    End Function

    Function Status_check(ByVal URL As String)
        Dim passed(2) As Integer
        For count As Integer = 1 To 4

            Dim client As New WebClient()
            Dim client_Stream As Stream = client.OpenRead(URL)
            Dim streamreading As New StreamReader(client_Stream)
            Dim JSON_str As String = streamreading.ReadToEnd()
            client_Stream.Close()

            Dim status_search As String = Chr(34) & "status" & Chr(34)
            Dim status_index As Integer = JSON_str.IndexOf(status_search)
            status_index += 12
            Dim status As New StringBuilder
            For i As Integer = status_index To JSON_str.Length
                If JSON_str.Substring(i, 1) = "" Then
                    Exit For
                    count += 1
                Else
                    status.Append(JSON_str.Substring(i, 1))
                End If
            Next

            'test if the status of the route is valid or not
            If status.ToString = "OK" Then
                passed(2) = 1

                'find the distance of the route
                Dim dist_char As Integer = JSON_str.IndexOf("value")
                dist_char += 9
                Dim dist_converter As String = ""
                For i As Integer = dist_char To JSON_str.Length
                    If JSON_str.Substring(i, 1) = " " Then
                        Exit For
                    Else
                        dist_converter += JSON_str.Substring(i, 1)
                    End If
                Next
                passed(0) = CInt(dist_converter)
                'Console.WriteLine("Dist converter: " & dist_converter)


                'finds the time length of the journey
                Dim damaged_JSON As String = Right(JSON_str, JSON_str.Length - dist_char)

                Dim dura_char As Integer

                dura_char = damaged_JSON.IndexOf("value")
                dura_char += 9
                Dim dura_converter As String = ""
                For i As Integer = dura_char To damaged_JSON.Length
                    If damaged_JSON.Substring(i, 1) = " " Then
                        Exit For
                    Else
                        dura_converter += damaged_JSON.Substring(i, 1)
                    End If
                Next
                passed(1) = CInt(dura_converter)

                Return passed
                Exit Function

            ElseIf status.tostring = "ZERO_RESULTS" Then
                passed(0) = 2147483645
                passed(1) = 2147483645
                passed(2) = 0
                Exit For

            ElseIf status.ToString = "NOT_FOUND" Then
                passed(0) = 2147483645
                passed(1) = -1
                passed(2) = -1
                Exit For

            ElseIf status.ToString = "OVER_QUERY_LIMIT" Then
                passed(0) = 2147483645
                passed(1) = -2
                passed(2) = -2
                Exit For

            ElseIf status.ToString = "MAX_WAYPOINTS_EXCEEDED" Then
                passed(0) = 2147483645
                passed(1) = -3
                passed(2) = -3
                Exit For

            ElseIf status.ToString = "MAX_ROUTE_LENGTH_EXCEEDED" Then
                passed(0) = 2147483645
                passed(1) = 2147483645
                passed(0) = 0
                Exit For

            Else
                passed(0) = 2147483645
                passed(1) = 2147483645
                passed(2) = 0
            End If
        Next
        Return passed
    End Function
End Module


'Function Datapull(ByRef array() As Integer, ByVal length As String, ByRef nodes As List(Of String)) As Integer()
'    'Builds request string
'    'Dim waypointkey As String = "AIzaSyBqN-1pDwR8taEDQESDP5mnJjiJkIXmv-w"
'    Current_URL.Equals("https://maps.googleapis.com/maps/api/directions/json?origin=")
'    Current_URL.Append(nodes.Item(0))
'    Current_URL.Append("&destination=" & nodes.Item(array(length - 1)) & "&waypoints=")
'    For t As Integer = 1 To length - 2
'        Current_URL.Append("via:" & nodes.Item(array(t)) & "|")
'    Next
'    Current_URL.Append("&key=" & "AIzaSyBqN-1pDwR8taEDQESDP5mnJjiJkIXmv-w")
'    'tb_URL.Text = request_url

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
'    client.DownloadFile(Current_URL.ToString, "Temp_JSONfile.json")
'    Dim client_Stream As Stream = client.OpenRead(Current_URL.ToString)
'    Dim streamreading As New StreamReader(client_Stream)
'    Dim Server_JSON_str As String = streamreading.ReadToEnd()
'    streamreading.Close()

'    'tries To make the JSON data Using JObject (did't know how to search the JObject for useful data
'    'Dim jdata As JObject = JObject.Parse(Server_JSON_str)


'    'searches for a key phrase then retrieves the value associated with the key phrase
'    'finds the physical length of the journey
'    'Dim search_dist As String = "distance"
'    Dim dist_char As Integer ' = Server_JSON_str.IndexOf(search_dist)

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

'    Dim distance As Integer = Integer.Parse(dist_converter)

'    'finds the time length of the journey
'    Dim damaged_JSON As String = Right(Server_JSON_str, Server_JSON_str.Length - dist_char)
'    'Dim search_dura As String = "duration"
'    Dim dura_char As Integer ' = damaged_JSON.IndexOf(search_dura)
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
'    Dim passed(2) As Integer
'    passed(0) = distance
'    passed(1) = duration
'    Return passed
'    'Else
'    '    Return Nothing
'    'End If
'End Function