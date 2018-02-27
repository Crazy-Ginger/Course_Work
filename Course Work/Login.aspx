<%@ Page Title="Login" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="Course_Work.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Spaces"><br/>
    </div>

    <div class="login">
        User Name:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Tb_username" runat="server" Width="150px"></asp:TextBox>
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Tb_password" runat="server" Width="150px"></asp:TextBox>
        <br />

        <asp:Button ID="B_Login" runat="server" Text="Login" />
        <br />
        <asp:Label ID="L_Incorrect" runat="server" ForeColor="Red" Text="Incorrect password for username" Visible="False"></asp:Label><br />
        
        <br />

        Dont have an account? 
        <asp:HyperLink ID="h_register" runat="server" href="Register_user.aspx">Click here</asp:HyperLink>
&nbsp;to register</div>
    <%-- This is to test git gui and I hope it recognises this change --%>

</asp:Content>
