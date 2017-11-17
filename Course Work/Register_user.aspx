<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register_user.aspx.vb" Inherits="Course_Work.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="reg_usertruck">
        <br />
        <br />        
        <div class="reg_user">

        <asp:TextBox ID="tx_fname" runat="server" placeholder="First Name"></asp:TextBox><br />
<br />
        <asp:TextBox ID="tx_lname" runat="server" placeholder="Last Name"></asp:TextBox><br />
<br />
        <asp:TextBox ID="tx_uname" runat="server" placeholder="Username"></asp:TextBox><br />
<br />
        <asp:TextBox ID="tx_password" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox><br />
<br />
            <asp:TextBox ID="tx_passwordcon" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox><br />
<br />
        <asp:TextBox ID="tx_email" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
            <br />
            Admin<br />
            <asp:DropDownList ID="Dd_Admins" runat="server" DataSourceID="Database" DataTextField="Username" placeholder="Admins" DataValueField="Username" Height="16px" Width="125px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="Database" runat="server" ConnectionString="<%$ ConnectionStrings:Dropdown_Admins %>" ProviderName="<%$ ConnectionStrings:Dropdown_Admins.ProviderName %>" SelectCommand="SELECT [Username] FROM [Users] WHERE ([Admin] = ?)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="True" Name="Admin" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
    <br />
        </div>
        
        <div class="reg_truck">
            <asp:TextBox ID="tx_truckbrand" runat="server" placeholder="Truck Brand"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="tx_truckmodel" runat="server" placeholder="Model"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="tx_truckage" runat="server" placeholder="Age of truck"></asp:TextBox>
            <br /><br />Last MOT
            
            <asp:TextBox ID="tx_lastMOT" runat="server" TextMode="Date"></asp:TextBox>
            <br /><br />
            Next MOT
            <asp:TextBox ID="tx_nextMOT" runat="server" TextMode="Date"></asp:TextBox><br /><br />
            <asp:Button ID="b_Register" runat="server" Text="Next"/>
        </div>
        </div>

    </asp:Content>
