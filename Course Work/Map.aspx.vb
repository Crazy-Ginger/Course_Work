Imports plot
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Data
Imports System.Threading

Public Class Map
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim boxes As Integer = Session("boxes")
        If boxes > 20 Then
            boxes = 20
            lb_toomany.Visible = True
        End If
        For i As Integer = 1 To (boxes)
            Dim tb_dest As New TextBox
            tb_dest.ID = "tb_dest_" & i
            tb_dest.AutoCompleteType = AutoCompleteType.HomeZipCode
            tb_dest.Width = 200
            P_Dest_cont.Controls.Add(tb_dest)

        Next

        boxes += 1
    End Sub

    Protected Sub AddDestination_Click(sender As Object, e As EventArgs) Handles b_AddDestination.Click
        Session("boxes") += 1
    End Sub


    Protected Sub RouteCalc_Click(sender As Object, e As EventArgs) Handles b_RouteCalc.Click
        If tb_Start.Text = "" Or tb_Start.Text = Nothing Then
            lb_noStart.Visible = True
        Else
            If tb_End.Text = "" Or tb_End.Text = Nothing Then
                Dim points(Session("boxes"), 1) As Integer
                points(0, 0) = FindLat(tb_Start.Text)
                points(0, 1) = FindLng(tb_Start.Text)
                For i As Integer = 1 To ((Session("boxes")) - 1)
                    Dim currentbox As Object = "tb_dest_" & i
                    If currentbox = "" Or currentbox = Nothing Then
                        Exit For
                    End If
                    points(i, 0) = FindLat(currentbox.text)
                    points(i, 1) = FindLng(currentbox.text)
                    Console.WriteLine(points(i, 0) & vbTab & points(i, 1))
                Next
            Else
                Dim points(Session("boxes") + 1, 1) As Integer
                points(0, 0) = FindLat(tb_Start.Text)
                points(0, 1) = FindLng(tb_Start.Text)
                For i As Integer = 1 To ((Session("boxes")) - 1)
                    Dim currentbox As Object = "tb_dest_" & i
                    If currentbox = "" Or currentbox = Nothing Then
                        Exit For
                    End If
                    points(i, 0) = FindLat(currentbox.text)
                    points(i, 1) = FindLng(currentbox.text)
                    Console.WriteLine(points(i, 0) & vbTab & points(i, 1))
                Next
            End If
        End If

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
