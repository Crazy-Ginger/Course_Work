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
End Class


Public Class Map
    Inherits System.Web.UI.Page
    Public count As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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


    'Protected Sub AddDestination_Click(sender As Object, e As EventArgs) Handles b_AddDestination.Click
    '    'ddl_Destinations.SelectedValue = Session("boxes")
    '    'Session("boxes") += 1
    '    'count += 1
    '    '<script>
    '    '        var count = 1
    '    '        Function boxes() {
    '    '            var Parent = document.getElementById("p_routenodes");
    '    '            var tb = document.createElement("input");
    '    '            tb.setAttribute("Id", "tb_waypoints" + count);
    '    '            tb.setAttribute("placeholder", "Waypoint address");
    '    '            Parent.appendChild(tb);
    '    '            count += 1
    '    '        }
    '    '    </script>
    'End Sub


    Protected Sub RouteCalc_Click(sender As Object, e As EventArgs) Handles b_RouteCalc.Click
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'If Session("logged_in") = False Then
        '    MsgBox("You need to login to access this feature")
        '    Server.Transfer("Login.aspx")
        'End If
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        Dim last As Boolean = True
        Dim nodes As New List(Of String)    'will contain the addresses so it can be passed between subs
        nodes.Add(tb_Start.Text)    'adds the start

        'cycles through the text boxes created and adds their text to the node list
        For Each tb As TextBox In p_routenodes.Controls.OfType(Of TextBox)()
            If String.IsNullOrEmpty(tb.Text) = True Or tb.Text = " " Then
                'stops a blank address being added and posisbly causing problem
            Else
                nodes.Add(tb.Text)
            End If
        Next
        If nodes.Count < 2 Then
            l_destinations.Text = "2 addresses are required"
            l_destinations.Visible = True
        End If
        Dim test As New StringBuilder
        For i As Integer = 0 To nodes.Count - 1
            test.Append(nodes.Item(i) & ", ")
        Next
        'tb_URL.Text = test.ToString
        'checks if there is a designated final destination
        If String.IsNullOrEmpty(tb_End.Text) = True Or tb_End.Text = " " Then
            last = False
        Else
            last = True
            nodes.Add(tb_End.Text)
        End If

        'removes spaces from the addresses in the nodes
        For i As Integer = 0 To nodes.Count - 1
            nodes.Item(i) = nodes.Item(i).Replace(" ", "+")
        Next

        Dim shortest As Shorter = Permute(nodes.Count, nodes, last)
        If shortest.duration = -1 Then
            MsgBox("One or more of the addresses is invalid")
        ElseIf shortest.duration = -2 Then
            MsgBox("Contact your admin as reagards to query limit")
        ElseIf shortest.duration = -3 Then
            MsgBox("You have too many destinations. The limit is 23")
        Else
            l_Distance.Text = shortest.distance
            l_Duration.Text = shortest.duration
            'tb_URL.Text = shortest.url
            For i As Integer = 0 To shortest.nodes.Count - 1
                bl_nodes.Items.Insert(i, shortest.nodes.Item(i))
            Next
        End If
    End Sub

End Class
