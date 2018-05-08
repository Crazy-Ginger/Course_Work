<%@ Page Title="Weekly Summary" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Money Breakdown.aspx.vb" Inherits="Course_Work.Weekly_Summary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <%--<asp:GridView ID="Route details" runat="server">

    </asp:GridView>--%>
    <asp:TextBox ID="tb_distance" runat="server" Font-Size="Medium" Height="40px"></asp:TextBox>km
    <asp:TextBox ID="tb_duration" runat="server" Font-Size="Medium" Height="40px"></asp:TextBox>hours
    <asp:TextBox ID="tb_URL" runat="server" Font-Size="Medium" Height="40px"></asp:TextBox>
    <asp:BulletedList ID="bl_nodes" runat="server" DisplayMode="text" BulletStyle="Numbered"></asp:BulletedList>
</asp:Content> 
