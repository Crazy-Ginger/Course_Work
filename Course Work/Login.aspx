<%@ Page Title="Login" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Course_Work._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Spaces"><br/></div>
    <div class="login">

        User Name:&emsp;
        <asp:TextBox ID="tb_username" runat="server" Width="145px"></asp:TextBox>
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_password" runat="server" Width="145px"></asp:TextBox>
        <br />

        <asp:Button ID="B_Login" runat="server" Text="Login" />
        <br />
        Dont have an account
        <asp:HyperLink ID="h_register" runat="server">click here</asp:HyperLink>
&nbsp;to register</div>
    

   

</asp:Content>
