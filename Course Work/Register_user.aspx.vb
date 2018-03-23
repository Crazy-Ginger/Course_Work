﻿Public Class Register
    Inherits System.Web.UI.Page
    Public User_reg As New DataSet1TableAdapters.UsersTableAdapter
    Public Vehicle_reg As New DataSet1TableAdapters.TrucksTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("logged_in") = True Then
            Response.Redirect("Stopover.aspx")
        End If
    End Sub

    Protected Sub b_Register_Click(sender As Object, e As EventArgs) Handles b_Register.Click
        Dim today As DateTime = DateTime.Today
        Dim username As String = tb_uname.Text
        Dim email As String = tb_email.Text
        If tb_password.Text <> tb_passwordcon.Text Then
            l_passwordmatch.Visible = True
        End If

        If User_reg.dupe_Check(username, email) > 0 Then
            l_username.Visible = True
            l_email.Visible = True

        ElseIf User_reg.dupe_Email(email) > 0 Then
            l_email.Visible = True

        ElseIf User_reg.dupe_Username(username) > 0 Then
            l_username.Visible = True

        ElseIf User_reg.dupe_Check(username, email) Is Nothing And tb_password.Text = tb_passwordcon.Text Then
        User_reg.add_User_Details(tb_uname.Text, tb_password.Text, today.ToString("d"), tb_email.Text, 0, False, tb_fname.Text, tb_lname.Text, False)
            Vehicle_reg.add_truck_details(CInt(tb_vehicleage.Text), tb_lastMOT.Text, tb_nextMOT.Text, tb_vehiclemake.Text, tb_vehiclemodel.Text, tb_license.Text)
            Server.Transfer("Register_confirm.aspx", True)
        End If
    End Sub
End Class