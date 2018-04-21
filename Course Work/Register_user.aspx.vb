Imports System.Security.Cryptography

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
            Dim salt As String = CreateSalt()
            Dim password As String = Hash512(tb_password.Text & salt)
            User_reg.add_Userdata(tb_uname.Text, password, today.ToString("d"), tb_email.Text, False, tb_fname.Text, tb_lname.Text, False, salt)
            Vehicle_reg.add_truck_details(tb_license.Text, tb_vehiclemodel.Text, Convert.ToDateTime(tb_nextMOT.Text), tb_vehiclemake.Text, False, Convert.ToDateTime(tb_lastMOT.Text), CInt(tb_vehicleage.Text))
            MsgBox("Successfully registered. You will now have to await authentication")
            Response.Redirect("https://google.co.uk", True)
        End If
    End Sub


    Public Function CreateSalt() As String
        'creates a string of possible salt characters
        Dim Saltchars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=][}{<>"
        Dim salt As New StringBuilder
        Dim rnd As New Random

        'a for loop to ensure it creates a salt 50 characters in length
        For i As Integer = 1 To 50
            salt.Append(Saltchars.Substring(rnd.Next(0, Saltchars.Length - 1), 1))
        Next
        Return salt.ToString
    End Function


    Public Function Hash512(password As String) As String
        'converts the password string to a byte array
        Dim convertToBytes As Byte() = Encoding.UTF8.GetBytes(password)
        'generates a new hash method
        Dim hashType As HashAlgorithm = New SHA512Managed()
        'hashes the byte array creating from the passoword string
        Dim hashBytes As Byte() = hashType.ComputeHash(convertToBytes)
        'converts the hashed byte array back into a string so it can be saved
        Dim hashedResult As String = Convert.ToBase64String(hashBytes)
        Return hashedResult
    End Function
End Class