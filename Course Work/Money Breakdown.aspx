<%@ Page Title="Weekly Summary" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Money Breakdown.aspx.vb" Inherits="Course_Work.Weekly_Summary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <span style="font-size: larger; border: inset; border-color: grey; padding: 18px 10px 18px 10px;">
        <asp:TextBox ID="tb_distance" runat="server" Font-Size="Large" Height="40px"></asp:TextBox>km
        <asp:TextBox ID="tb_duration" runat="server" Font-Size="large" Height="40px"></asp:TextBox>hours
        <asp:TextBox ID="tb_URL" runat="server" Font-Size="Medium" Height="40px" placeholder="Route URL"></asp:TextBox>
        <asp:BulletedList ID="bl_nodes" runat="server" DisplayMode="text" BulletStyle="Numbered"></asp:BulletedList>
    </span>
    <br />
    <br />
    <span style="font-size: x-large; border: inset; border-color: grey; padding: 11px 10px 11px 10px;">Select your license
        <asp:DropDownList ID="ddl_Licenses" runat="server" Font-Size="x-Large" DataSourceID="SqlDataSource1" DataTextField="License_Plate" DataValueField="License_Plate"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:User_DetailsConnectionString %>" ProviderName="<%$ ConnectionStrings:User_DetailsConnectionString.ProviderName %>" SelectCommand="SELECT [License Plate] AS License_Plate FROM [Trucks]"></asp:SqlDataSource>
    </span>
    <br />
    <br />
    <div style="border: inset; border-color: grey; padding: 18px 10px 18px 10px;">
        <asp:TextBox ID="tb_grossProfit" runat="server" Font-Size="x-Large" Height="50px" placeholder="Gross profit of journey"></asp:TextBox>
        <asp:TextBox ID="tb_fuelConsumption" runat="server" Font-Size="x-Large" Height="50px" Width="270px" placeholder="Fuel consumption of vehicle (in L/km)"></asp:TextBox>
        <span style="float: right;">
            <asp:Button ID="b_calculateNet" runat="server" Font-Size="X-Large" Height="50px" Text="Calculate Net Profit" />
            <asp:TextBox ID="tb_netProfit" runat="server" Font-Size="x-large" Height="50px"></asp:TextBox>
        </span>
    </div>
    <br />
    <br />
    <asp:Button ID="b_submitRoute" runat="server" heigth="50px" Font-Size="Medium" Text="Add the route to the Database" />
</asp:Content> 
