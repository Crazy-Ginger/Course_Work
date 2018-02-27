﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register_user.aspx.vb" Inherits="Course_Work.Register" %>
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
            <asp:Label ID="L_username" runat="server" ForeColor="Red" Text="Username must be unique" Visible="False"></asp:Label>
<br />
        <asp:TextBox ID="tx_password" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox><br />
<br />
            <asp:TextBox ID="tx_passwordcon" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox><br />
            <asp:Label ID="L_password_match" runat="server" ForeColor="Red" Text="Passwords don't match" Visible="False"></asp:Label>
<br />
        <asp:TextBox ID="tx_email" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
            <br />
            <asp:Label ID="L_email" runat="server" ForeColor="Red" Text="You need a unique email" Visible="False"></asp:Label>
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
