Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Data
Imports System.Threading
Public Class Shorter
    Public distance As Integer
    Public duration As Integer
    Public nodes As New List(Of String)
    Public url As String
    Public status As Integer
End Class


Public Module Persistence
    Public Destinations As New List(Of TextBox)
    'Public rfv As New List(Of RequiredFieldValidator)

    'Sub addrfvcontrols()
    '    If Destinations.Count < 1 Then
    '        Dim newtb As New TextBox
    '        newtb.ID = "tb_waypoints" & Destinations.Count
    '        Destinations.Add(newtb)
    '    End If

    '    For i As Integer = 0 To Destinations.Count - 1
    '        Dim newrfv As New RequiredFieldValidator
    '        newrfv.ControlToValidate = Destinations.Item(i).ID
    '        newrfv.ForeColor = Drawing.Color.Red
    '        newrfv.ErrorMessage = "This is a required field"
    '        newrfv.ValidationGroup = "routing"
    '        rfv.Add(newrfv)
    '        
    '    Next

    '    Dim lastrfv As New RequiredFieldValidator
    '    lastrfv.ControlToValidate = Destinations.Last.ID
    '    lastrfv.ForeColor = Drawing.Color.Red
    '    lastrfv.ErrorMessage = "This is a required field"
    '    lastrfv.ValidationGroup = "routing"
    '    rfv.Add(lastrfv)
    'End Sub

    'Sub clearrfv()
    '    rfv.Clear()
    'End Sub
End Module


Public Class Map
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        p_routenodes.Controls.Clear()
        'clearrfv()
        'Persistence.addrfvcontrols()

        'adds the text boxes stored in "Persistence" to the panel
        Dim count As Integer = 0
        For Each tb As TextBox In Persistence.Destinations
            p_routenodes.Controls.Add(tb)

            'p_routenodes.Controls.Add(Persistence.rfv.Item(count))

            'Console.WriteLine("tb id: " & tb.ID & vbTab & "rfv ctv: " & Persistence.rfv.Item(count).ControlToValidate)
            count += 1
            'Dim br As New HtmlGenericControl("br")
            'p_routenodes.Controls.Add(br)
            'p_routenodes.Controls.Remove(br)
        Next

        'Dim script As String = ""
        'script = "<script> </script>"
        'Page.ClientScript.RegisterClientScriptInclude("Map_Scripts.js", "~/Scripts/Map_Scripts.js")

        'consider using GetType
        'For Each rfv As RequiredFieldValidator In Persistence.rfv
        '    p_routenodes.Controls.Add(rfv)
        'Next

        'If boxes.numb > 20 Then
        '    boxes.numb = 20
        '    lb_toomany.Visible = True
        'End If
        'For i As Integer = 1 To Session("boxes")
        '    Dim tb_dest As New TextBox
        '    tb_dest.ID = "tb_dest_" & i
        '    tb_dest.AutoCompleteType = AutoCompleteType.HomeZipCode
        '    tb_dest.Width = 200
        '    p_routenodes.Controls.Add(tb_dest)
        'Next
        'tb_Distance.Text = Session("boxes")
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Dim tb_list As New List(Of TextBox)
        'Dim rfv_list As New List(Of RequiredFieldValidator)

        '''adds the textboxes in the panel to the list
        'For Each tb As TextBox In p_routenodes.Controls
        '    tb_list.Add(tb)
        'Next

        For Each tb As Control In p_routenodes.Controls
            If TypeOf tb Is TextBox Then
                tb_list.Add(tb)
            End If
        Next
        'sets the value of the remote variable so that the textboxes are preservered between page loads
        Persistence.Destinations = tb_list

        'For Each rfv As Control In p_routenodes.Controls
        '    If TypeOf rfv Is RequiredFieldValidator Then
        '        rfv_list.Add(rfv)

        '    End If
        'Next
        'sets the value of the remote variable so that the rfv's are preservered between page loads
        'Persistence.rfv = rfv_list
        'p_routenodes.Controls.Clear()
    End Sub

    Protected Sub AddDestination_Click(sender As Object, e As EventArgs) Handles b_AddDestination.Click
        Dim tb As New TextBox()
        'Dim rfv As New RequiredFieldValidator()

        Dim id As String = "tb_waypoints" & Persistence.Destinations.Count
        tb.ID = id


        'rfv.ControlToValidate = id
        'p_routenodes.Controls.Add(rfv)
        'flubadub
        p_routenodes.Controls.Add(tb)
    End Sub

    Protected Sub RemoveDestination_click(sender As Object, e As EventArgs) Handles b_LessDestination.Click
        Dim tb As TextBox = Persistence.Destinations.Last
        'Dim rfv As RequiredFieldValidator = Persistence.rfv.Last

        'Persistence.clearrfv()
        p_routenodes.Controls.Remove(tb)

        'Dim rfv As RequiredFieldValidator = Persistance.rfv(Persistance.rfv.Length - 1)
        'p_routenodes.Controls.Remove(rfv)
    End Sub

    Protected Sub RouteCalc_Click(sender As Object, e As EventArgs) Handles b_RouteCalc.Click
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'If Session("logged_in") = False Then
        '    MsgBox("You need to login to access this feature")
        '    Server.Transfer("Login.aspx")
        'End If
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        'this will tell the extenral code if a final destination was added to the route
        Dim last As Boolean = False
        'this list will contain all the addresses of the route and will be used to pass them to the routing algorithms
        Dim nodes As New List(Of String)
        'adds the starting destination
        nodes.Add(tb_Start.Text)

        'cycles through the text boxes created and adds their text to the node list
        For Each tb As TextBox In p_routenodes.Controls.OfType(Of TextBox)()
            'checks the textboxes contain valid data
            If String.IsNullOrEmpty(tb.Text) = True Or String.IsNullOrWhiteSpace(tb.Text) = True Then
                'stops a blank address being added and posisbly causing problem
            Else
                nodes.Add(tb.Text)
            End If
        Next

        'adds a final destination if one is inputted
        If String.IsNullOrEmpty(tb_End.Text) = False And String.IsNullOrWhiteSpace(tb_End.Text) = False Then
            nodes.Add(tb_End.Text)
            last = True
        End If

        If nodes.Count < 2 Then
            l_destinations.Text = "2 addresses are required"
            l_destinations.Visible = True
        ElseIf nodes.Count > 23 Then
            l_destinations.Text = "Too many waypoints. A maximum of 21 are allowed"
            l_destinations.Visible = True
        End If

        'removes spaces from the addresses in the nodes
        For i As Integer = 0 To nodes.Count - 1
            nodes.Item(i) = nodes.Item(i).Replace(" ", "+")
        Next

        'finds the shortest route and assigns it to a local variable
        Dim shortest As New Shorter
        If nodes.Count < 7 Then
            shortest = Permute(nodes.Count, nodes, last)
        ElseIf nodes.Count > 6 Then
            shortest = Approximation(nodes, last)
        End If

        'checks the validity of the returned route
        If shortest.status = -1 Then
            MsgBox("One or more of the addresses is invalid")
        ElseIf shortest.status = -2 Then
            MsgBox("Contact your admin in reagards to query limit")
        ElseIf shortest.status = -3 Then
            MsgBox("You have too many destinations. The limit is 23")
        ElseIf shortest.status = 0 Then
            MsgBox("There was an error, please retry")
        ElseIf shortest.status = 1 Then
            l_Distance.Text = shortest.distance
            l_Duration.Text = shortest.duration
            tb_routeURL.Text = shortest.url
            For Each node As String In shortest.nodes
                bl_nodes.Items.Add(node)
            Next
            MsgBox("Success")
        Else
            MsgBox("There was an error, please retry")
        End If
    End Sub

End Class
