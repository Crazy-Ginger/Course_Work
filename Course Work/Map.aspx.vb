Imports travelingSalesman
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Data
Imports System.Threading

Public Class Map
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim boxes As Integer = Session("boxes")
        Dim numboxes As Integer = boxes
        If boxes <> 0 Then
            For i As Integer = 1 To (numboxes)
                Dim tb_dest As New TextBox
                tb_dest.ID = "tb_dest_" & i
                tb_dest.Width = 200
                P_Dest_cont.Controls.Add(tb_dest)
            Next
        End If
        Testing.Text = numboxes
    End Sub

    Protected Sub AddDestination_Click(sender As Object, e As EventArgs) Handles AddDestination.Click
        Session("boxes") += 1
    End Sub


    Protected Sub RouteCalc_Click(sender As Object, e As EventArgs) Handles RouteCalc.Click
        If Start.Text = "" Then

        End If
        'Dim starts As Node
        'starts.X = FindLat(Start.Text)
        'starts.Y = FindLng(Start.Text)
        'For i As Integer = 1 To ((Session("boxes")) - 1)
        '    Dim (point & i) As Node
        '    Dim currentbox As Object = "tb_dest_" & i
        '    If currentbox = "" Then
        '        Exit For
        '    End If
        '    point.X = FindLat(currentbox.text)
        '    point.Y = FindLng(currentbox.text)
        '    Console.WriteLine(point.X & vbTab & point.Y)

        'Next

        'Dim currentRoute As New Route(start, ending,)
        'plot(currentRoute.routeNodes)
    End Sub



    Protected Function FindLat(ByVal destination As String)
        'https://www.aspsnippets.com/Articles/Find-Co-ordinates-Latitude-And-Longitude-of-an-Address-Location-using-Google-Geocoding-API-in-ASPNet-using-C-And-VBNet.aspx
        Dim url As String = "http://maps.google.com/maps/api/geocode/xml?address=" + destination + "&sensor=false"
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim dsResult As New DataSet()
                dsResult.ReadXml(reader)
                Dim dtCoordinates As New DataTable()
                dtCoordinates.Columns.AddRange(New DataColumn(3) {New DataColumn("Id", GetType(Integer)), New DataColumn("Address", GetType(String)), New DataColumn("Latitude", GetType(String)), New DataColumn("Longitude", GetType(String))})
                Dim geometry_id As String = dsResult.Tables("geometry").[Select]("result_id = " + ("result_id").ToString())(0)("geometry_id").ToString()
                Dim location As DataRow = dsResult.Tables("location").[Select](Convert.ToString("geometry_id = ") & geometry_id)(0)
                'dtCoordinates.Rows.Add(row("result_id"), row("formatted_address"), location("lat"), location("lng"))
                Return location("Lat")
            End Using
        End Using
    End Function

    Protected Function FindLng(ByVal destination As String)
        'https://www.aspsnippets.com/Articles/Find-Co-ordinates-Latitude-and-Longitude-of-an-Address-Location-using-Google-Geocoding-API-in-ASPNet-using-C-and-VBNet.aspx
        Dim url As String = "http://maps.google.com/maps/api/geocode/xml?address=" + destination + "&sensor=false"
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim dsResult As New DataSet()
                dsResult.ReadXml(reader)
                Dim dtCoordinates As New DataTable()
                dtCoordinates.Columns.AddRange(New DataColumn(3) {New DataColumn("Id", GetType(Integer)), New DataColumn("Address", GetType(String)), New DataColumn("Latitude", GetType(String)), New DataColumn("Longitude", GetType(String))})
                Dim geometry_id As String = dsResult.Tables("geometry").[Select]("result_id = " + ("result_id").ToString())(0)("geometry_id").ToString()
                Dim location As DataRow = dsResult.Tables("location").[Select](Convert.ToString("geometry_id = ") & geometry_id)(0)
                'dtCoordinates.Rows.Add(row("result_id"), row("formatted_address"), location("lat"), location("lng"))
                Return location("lng")
            End Using
        End Using
    End Function

End Class
