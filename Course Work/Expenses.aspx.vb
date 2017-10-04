Imports System.Data.OleDb
Public Class Expenses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim testExpenses As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= W:\6th Form\Year 2\Computer Science\Course_Work\Course Work\User Details.accdb")
        testExpenses.Open()
        Dim query1 As String = "SELECT * FROM *"
        Dim command1 As New OleDbCommand(query1, testExpenses)
        Dim reader As OleDbDataReader = command1.ExecuteReader()
        Dim id As String = ""
        While reader.Read
            testbox.textbox(reader["ID"])

            '#id = id & CStr(reader["ID"]) & "  "
        End While
    End Sub

End Class