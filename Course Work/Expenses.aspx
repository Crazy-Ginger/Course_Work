<%@ Page Title="Expenses" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Expenses.aspx.vb" Inherits="Course_Work._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>This is where the expenses will be.<br />
    </div>
    <asp:GridView ID="Expenses_gv" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:User-Expenses %>" ProviderName="<%$ ConnectionStrings:User-Expenses.ProviderName %>" SelectCommand="SELECT [Expenses], [Net Profit] AS Net_Profit, [Wage], [Gross Profit] AS Gross_Profit FROM [Money]"></asp:SqlDataSource>
    <br />
</asp:Content> 
