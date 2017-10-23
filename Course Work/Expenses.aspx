<%@ Page Title="Expenses" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Expenses.aspx.vb" Inherits="Course_Work.Expenses" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>This is where the expenses will be.<br />
    </div>
    <asp:GridView ID="Expenses_gv" runat="server" AutoGenerateColumns="False" DataSourceID="Db_Money" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Expenses" HeaderText="Expenses" SortExpression="Expenses" />
            <asp:BoundField DataField="Gross_Profit" HeaderText="Gross_Profit" SortExpression="Gross_Profit" />
            <asp:BoundField DataField="Wage" HeaderText="Wage" SortExpression="Wage" />
            <asp:BoundField DataField="Net_Profit" HeaderText="Net_Profit" SortExpression="Net_Profit" />
        </Columns>
</asp:GridView>
    <asp:SqlDataSource ID="Db_Money" runat="server" ConnectionString="<%$ ConnectionStrings:Expenses_Money %>" ProviderName="<%$ ConnectionStrings:Expenses_Money.ProviderName %>" SelectCommand="SELECT [ID], [Expenses], [Gross Profit] AS Gross_Profit, [Wage], [Net Profit] AS Net_Profit FROM [Money]"></asp:SqlDataSource>
    <br />
</asp:Content> 
