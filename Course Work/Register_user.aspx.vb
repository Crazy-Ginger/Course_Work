Public Class Register
    Inherits System.Web.UI.Page
    Public regconnection As New DataSet1TableAdapters.UsersTableAdapter
    Public truckreg As New DataSet1TableAdapters.TrucksTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub b_Register_Click(sender As Object, e As EventArgs) Handles b_Register.Click
        Dim today As DateTime = DateTime.Today
        Dim username As String = tx_uname.Text
        Dim email As String = tx_email.Text
        If regconnection.dupeCheck(username, email) Is Nothing And tx_password.Text = tx_passwordcon.Text Then
            regconnection.addUserDetails(tx_uname.Text, tx_password.Text, tx_email.Text, tx_fname.Text, tx_lname.Text, today.ToString("d"))
            truckreg.addTruckDetails(CInt(tx_truckage.Text), tx_lastMOT.Text, tx_nextMOT.Text, tx_truckbrand.Text, tx_truckmodel.Text)
            Session("logged_in") = "in"
            Server.Transfer("Register_confirm.aspx", True)
        ElseIf tx_password.Text <> tx_passwordcon.Text Then
            L_password_match.Visible = True
        ElseIf regconnection.dupeCheck(username, email) > 0 Then
            L_username.Visible = True
            L_email.Visible = True
        ElseIf regconnection.dupeEmail(email) > 0 Then
            L_email.Visible = True
        ElseIf regconnection.dupeUsername(username) > 0 Then
            L_username.Visible = True
        End If
    End Sub
End Class