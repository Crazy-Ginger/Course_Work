<%@ Page Title="Expenses" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Expenses.aspx.vb" Inherits="Course_Work._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>This is where the expenses will be.<br />
    </div>
    <asp:GridView ID="Expenses_gv" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Expenses" HeaderText="Expenses" SortExpression="Expenses" />
            <asp:BoundField DataField="Net_Profit" HeaderText="Net Profit" SortExpression="Net_Profit" />
            <asp:BoundField DataField="Wage" HeaderText="Wage" SortExpression="Wage" />
            <asp:BoundField DataField="Gross_Profit" HeaderText="Gross Profit" SortExpression="Gross_Profit" />
        </Columns>
</asp:GridView>&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:User-Expenses %>" ProviderName="<%$ ConnectionStrings:User-Expenses.ProviderName %>" SelectCommand="SELECT [Expenses], [Net Profit] AS Net_Profit, [Wage], [Gross Profit] AS Gross_Profit FROM [Money]"></asp:SqlDataSource>
    <br />
</asp:Content> 
