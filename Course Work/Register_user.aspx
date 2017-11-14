<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register_user.aspx.vb" Inherits="Course_Work.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="reg_usertruck">
        <br />
        <br />        
        <div class="reg_user">
            First Name
        <br />
        <asp:TextBox ID="tx_fname" runat="server"></asp:TextBox>
    <br />
        Last Name<br />
        <asp:TextBox ID="tx_lname" runat="server"></asp:TextBox>
    <br />
        Username<br />
        <asp:TextBox ID="tx_uname" runat="server"></asp:TextBox>
    <br />
        Password<br />
        <asp:TextBox ID="tx_password" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            Confirm password<br />
            <asp:TextBox ID="tx_passwordcon" runat="server" TextMode="Password"></asp:TextBox>
    <br />
        email<br />
        <asp:TextBox ID="tx_email" runat="server" TextMode="Email"></asp:TextBox>
    <br />
        </div>
        <div class="reg_truck">
            Truck brand<br />
            <asp:TextBox ID="tx_truckbrand" runat="server"></asp:TextBox>
            <br />
            Model<br />
            <asp:TextBox ID="tx_truckmodel" runat="server"></asp:TextBox>
            <br />
            Age of truck<br />
            <asp:TextBox ID="tx_truckage" runat="server"></asp:TextBox>
            <br />
            Last MOT<br />
            <asp:TextBox ID="tx_lastMOT" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            Next MOT<br />
            <asp:TextBox ID="tx_nextMOT" runat="server" TextMode="Date"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Next"/>
        </div>
        </div>

    </asp:Content>
