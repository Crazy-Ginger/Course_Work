Imports System.Data.OleDb
Module Auto_log_out
    Dim log As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|Datadirectory|User details.accdb")
    log.Open()
    Dim logged_query As String = "SELECT Logged in? FROM users"
    Dim logger As New OleDbCommand(logged_query, log)
    Dim logged_writer As OleDbDataReader = logger.

End Module
