﻿<%@ Page Title="Login" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="Course_Work.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Spaces"><br/>
    </div>

    <div class="login">
<<<<<<< HEAD
        User Name:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_username" runat="server" Width="150px"></asp:TextBox>
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_password" runat="server" Width="150px"></asp:TextBox>
=======
        User Name:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_username" runat="server" Width="150px"></asp:TextBox>
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_password" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
>>>>>>> 44046c4ff4a78c5e89859c627c45eb7bebb924db
        <br />

        <asp:Button ID="b_Login" runat="server" Text="Login" />
        <br />
        <asp:Label ID="l_Incorrect" runat="server" ForeColor="Red" Text="Incorrect password or username" Visible="False"></asp:Label><br />
        
        <br />

        Dont have an account? 
        <asp:HyperLink ID="h_register" runat="server" href="Register_user.aspx">Click here</asp:HyperLink>
&nbsp;to register</div>
</asp:Content>
