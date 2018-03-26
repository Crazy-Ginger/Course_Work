<%@ Page Title="Login" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="Course_Work.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="LoginPage">
        <br />
        <span class="loginUsername">User Name:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_username" runat="server" Width="150px"></asp:TextBox>
        </span>
       <asp:RequiredFieldValidator ID="rfv_noUsername" runat="server" ForeColor="Red" ControlToValidate="tb_username" ErrorMessage="Please enter a username"></asp:RequiredFieldValidator>
        <br />
        <span class="loginPassword">Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tb_password" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
        </span>
        -<asp:RequiredFieldValidator ID="rfv_noPassword" runat="server" ForeColor="Red" ControlToValidate="tb_username" ErrorMessage="Please enter a password"></asp:RequiredFieldValidator>
        
        <br />
        <span class="loginButton">
            <asp:Button ID="b_Login" runat="server" Text="Login" />
            <br />

           <asp:Label ID="l_Incorrect" runat="server" ForeColor="Red" Text="Incorrect password or username" Visible="False"></asp:Label>
            <br />
            <br />

            Dont have an account? 
        <asp:HyperLink ID="h_register" runat="server" href="Register_user.aspx">Click here</asp:HyperLink>
            &nbsp;to register
        </span>
    </div>
</asp:Content>
