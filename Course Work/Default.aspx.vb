﻿Imports System.Data.OleDb
Public Class Login
    Inherits System.Web.UI.Page
    Dim username As String
    Dim password As String
    Public dataqueries As New DataSet1TableAdapters.TableAdapter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub B_Login_Click(sender As Object, e As EventArgs) Handles B_Login.Click
        username = Tb_username.text
        password = Tb_password.text
        If dataqueries.Equals(username As String , password As String) = True Then
            Response.Redirect() 'insert link to logged in page here, True)s
        End If
    End Sub
End Class