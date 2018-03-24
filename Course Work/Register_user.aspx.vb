Public Class Register
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

        If String.IsNullOrWhiteSpace(tb_email.Text) = True Or String.IsNullOrWhiteSpace(tb_fname.Text) = True Or String.IsNullOrWhiteSpace(tb_lname.Text) = True Or String.IsNullOrWhiteSpace(tb_uname.Text) = True Or String.IsNullOrWhiteSpace(tb_vehiclemake.Text) = True Or String.IsNullOrWhiteSpace(tb_vehiclemodel.Text) = True Or tb_vehicleage.Text = 0 Or tb_vehicleage.Text = Nothing Or String.IsNullOrWhiteSpace(tb_license.Text) = True Then
            l_empty.Visible = True

        ElseIf tb_password.Text <> tb_passwordcon.Text Then
            l_passwordmatch.Visible = True

        ElseIf (tb_password.Text).Length < 7 Then
            l_passwordlength.Visible = True

        ElseIf User_reg.dupe_Email(tb_email.text) > 0 Then
            l_email.Visible = True

        ElseIf User_reg.dupe_Username(tb_uname.text) > 0 Then
            l_username.Visible = True

        ElseIf Vehicle_reg.dupe_License(tb_license.Text) > 0 Then
            l_license.Visible = True

        Else
            User_reg.add_User_Details(tb_uname.Text, tb_password.Text, today.ToString("d"), tb_email.Text, 0, False, tb_fname.Text, tb_lname.Text, False)
            Vehicle_reg.add_truck_details(CInt(tb_vehicleage.Text), tb_lastMOT.Text, tb_nextMOT.Text, tb_vehiclemake.Text, tb_vehiclemodel.Text, tb_license.Text)
            Server.Transfer("Register_confirm.aspx", True)
        End If
    End Sub
End Class