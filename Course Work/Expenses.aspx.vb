﻿Imports System.Data.OleDb
Public Class Expenses
    Inherits System.Web.UI.Page
    Public dataQueries As New DataSet1TableAdapters.TableAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim testExpenses As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= W:\6th Form\Year 2\Computer Science\Course_Work\Course Work\User Details.accdb")
        'testExpenses.Open()
        'Dim query1 As String = "SELECT * FROM *"
        'Dim command1 As New OleDbCommand(query1, testExpenses)
        'Dim reader As OleDbDataReader = command1.ExecuteReader()
        'Dim id As String = ""
        'While reader.Read
        'testbox.textbox(reader["ID"])

        '#id = id & CStr(reader["ID"]) & "  "
        'End While
        Dim NET As String = ddlMake.SelectedItem.Text
        Session("Make") = NET
    End Sub

    Private Function ddlMake() As Object
        Throw New NotImplementedException
    End Function
End Class