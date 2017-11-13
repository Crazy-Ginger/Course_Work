<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register_user.aspx.vb" Inherits="Course_Work.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Reg_user">
        <br />
        <br />
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
            <asp:TextBox ID="tx_lastMOT" runat="server"></asp:TextBox>
            <br />
            Next MOT<br />
            <asp:TextBox ID="tx_nextMOT" runat="server"></asp:TextBox>

    </div>
        First Name
        <br />
        <asp:TextBox ID="tx_fname" runat="server" align="center"></asp:TextBox>
    <br />
        Last Name<br />
        <asp:TextBox ID="tx_lname" runat="server" align="center"></asp:TextBox>
    <br />
        Username<br />
        <asp:TextBox ID="tx_uname" runat="server" align="center"></asp:TextBox>
    <br />
        Password<br />
        <asp:TextBox ID="tx_password" runat="server" align="center"></asp:TextBox>
    <br />
        email<br />
        <asp:TextBox ID="tx_email" runat="server" align="center"></asp:TextBox>
    <br />
        </div>
    <asp:Button ID="next1" align="centre" runat="server" Text="Next"/>
    </asp:Content>
