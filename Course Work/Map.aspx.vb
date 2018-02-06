Public Class Map
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub AddDestination_Click(sender As Object, e As EventArgs) Handles AddDestination.Click



        'Dim Destination As New Textboxmaker
        'Destination.ID = "Destination"

        ''suffix += 1
        'Me.Controls.Add(Destination)
        'Destination.Visible = True
        'Destination.
        Dim rowsCount As Integer = CInt(Tx_Destinations.Text)
        GenerateTable(rowsCount)
    End Sub

    'Public Class Textboxmaker
    '    Inherits TextBox
    '    Public ID As String
    'End Class

    Private Sub GenerateTable(ByVal rowsCount As Integer)
        'Creat the Table and Add it to the Page
        Dim table As New Table()
        table.ID = "Table1"
        Page.Form.Controls.Add(table)
        ' Now iterate through the table and add your controls 
        For i As Integer = 0 To rowsCount - 1
            Dim row As New TableRow()

            Dim cell As New TableCell()
            Dim tb As New TextBox()

            ' Set a unique ID for each TextBox added
            tb.ID = "TextBoxRow_" & i

            ' Add the control to the TableCell
            cell.Controls.Add(tb)
            ' Add the TableCell to the TableRow
            row.Cells.Add(cell)
            table.Rows.Add(row)
        Next
        ' Add the TableRow to the Table


    End Sub
End Class

