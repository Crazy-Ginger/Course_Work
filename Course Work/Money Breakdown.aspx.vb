Imports System
Public Class Weekly_Summary
    Inherits System.Web.UI.Page
    Public Journeys As New DataSet1TableAdapters.DeliveriesTableAdapter
    Public Journey_nodes As New DataSet1TableAdapters.NodesTableAdapter
    Public Users As New DataSet1TableAdapters.UsersTableAdapter
    Public Vehicles As New DataSet1TableAdapters.TrucksTableAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("logged_in") <> True Then
            MsgBox("You need to login to access this feature")
            Server.Transfer("Login.aspx")
        End If
        If Session("Passed") = True Then
            tb_distance.Text = (shortest.distance / 1000)
            Dim rounded As Double = Math.round((shortest.duration / 3600), 2)
            tb_duration.Text = rounded
            tb_URL.Text = shortest.url
            For Each node As String In shortest.nodes
                bl_nodes.Items.Add(node)
            Next

        End If
    End Sub

    'calculates and estimate for net profit
    Public Sub NetCalc_click(sender As Object, e As EventArgs) Handles b_calculateNet.Click
        'estimates fuel cost with user input and current pricing of diesel (in metric)
        Dim fuelcost As New Double
        If Session("passed") = True Then
            fuelcost = (tb_fuelConsumption.Text) * (shortest.distance / 1000) * 1.23
        Else
            fuelcost = (tb_fuelConsumption.Text) * (tb_distance.Text) * 1.23
        End If
        Dim passer As Double = (tb_grossProfit.Text - fuelcost)
        tb_netProfit.Text = passer
        'this can easily be relplaced or altered to fit the clients wishes
    End Sub

    Public Sub SubmitRoute_click(sender As Object, e As EventArgs) Handles b_submitRoute.Click
        'finds the drivers vehichle ID
        Dim vehID As Integer = Vehicles.get_ID(ddl_Licenses.SelectedItem.ToString)
        'finds the users ID
        Dim DriverID As Integer = Users.get_UserID(Session("username"))
        Journeys.add_Journey(DriverID, vehID, DateTime.Today, tb_distance.Text, tb_duration.Text, tb_URL.Text, tb_netProfit.Text, tb_grossProfit.Text)
        Dim ID As Integer = Journeys.get_ID(DriverID, DateTime.Today, vehID, tb_distance.Text, tb_duration.Text, tb_grossProfit.Text, tb_URL.Text, tb_netProfit.Text)
        For Each node In bl_nodes.Items
            Journey_nodes.add_Node(ID, node.ToString)
        Next
    End Sub
End Class