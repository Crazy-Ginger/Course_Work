Imports System.Security.Cryptography
Public Class Login
    Inherits System.Web.UI.Page
    Public Login_Connection As New DataSet1TableAdapters.UsersTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim logged_In As Boolean = Session("logged_in")
        If Session("logged_in") = True Then
            MsgBox("You are already logged in. Redirecting to Map")
            Response.Redirect("Map.aspx") 'use response.readirect to remove this page from the memory and change the URL
        End If
    End Sub

    Protected Sub B_Login_Click(sender As Object, e As EventArgs) Handles b_Login.Click
        If Login_Connection.check_username(tb_username.Text) > 0 Then
            Dim salt As String = Login_Connection.get_Salt(tb_username.Text)
            Dim password As String = Hash512(tb_password.Text & salt)
            If Login_Connection.Login(tb_username.Text, password) Is Nothing Or Login_Connection.Login(tb_username.Text, password) <= 0 Then
                l_Incorrect.Visible = True
            ElseIf Login_Connection.Login(tb_username.Text, password) >= 1 Then
                Session("username") = tb_username.Text
                Session("logged_in") = True
                MsgBox("You are now logged in")
                Server.Transfer("Map.aspx", True)
            End If
        Else
            l_Incorrect.Visible = True
        End If

    End Sub

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