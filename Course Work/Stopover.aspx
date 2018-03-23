<%@ Page Title="Stopover" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stopover.aspx.vb" Inherits="Course_Work.Stopover" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="l_LoggedIn" runat="server" Visible="false">You're already logged in</asp:Label>
    <asp:Label ID="l_Not_loggedIn" runat="server" Visible="false">You are not logged in </asp:Label>
    <p>

        Redirecting you now...
    </p>
</asp:Content> 
