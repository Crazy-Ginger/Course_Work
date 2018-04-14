Public Class Register
    Inherits System.Web.UI.Page
    Public User_reg As New DataSet1TableAdapters.UsersTableAdapter
    Public Vehicle_reg As New DataSet1TableAdapters.TrucksTableAdapter

    Protected Sub b_Register_Click(sender As Object, e As EventArgs) Handles b_Register.Click
        Dim today As DateTime = DateTime.Today

        If tb_password.Text <> tb_passwordmatch.Text Then
            l_passwordmatch.Visible = True
        ElseIf (tb_password.Text).Length < 7 Then
            l_passwordlength.Visible = True

        ElseIf User_reg.dupe_Email(tb_email.Text) > 0 Then
            l_email.Visible = True

        ElseIf User_reg.dupe_Username(tb_uname.Text) > 0 Then
            l_username.Visible = True

        ElseIf Vehicle_reg.dupe_License(tb_license.Text) > 0 Then
            l_license.Visible = True

        Else
            User_reg.add_Userdata(tb_uname.Text, tb_password.Text, today.ToString("d"), tb_email.Text, False, tb_fname.Text, tb_lname.Text, False)
            Vehicle_reg.add_truck_details(tb_license.Text, tb_vehiclemodel.Text, Convert.ToDateTime(tb_nextMOT.Text), tb_vehiclemake.Text, False, Convert.ToDateTime(tb_lastMOT.Text), CInt(tb_vehicleage.Text))
            MsgBox("Successfully registered. You will now have to await authentication")
            Response.Redirect("https://google.co.uk", True)
        End If
    End Sub
End Class