<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register_user.aspx.vb" Inherits="Course_Work.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="class_reg">
        <br />
        <br />
        <div class="reg_user">

            <asp:TextBox ID="tb_fname" runat="server" placeholder="First Name"></asp:TextBox><br />
            <br />
            <asp:TextBox ID="tb_lname" runat="server" placeholder="Last Name"></asp:TextBox><br />
            <br />
            <asp:TextBox ID="tb_uname" runat="server" placeholder="Username"></asp:TextBox><br />
            <asp:Label ID="l_username" runat="server" ForeColor="Red" Text="Username must be unique" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="tb_password" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox><br />
            <br />
            <asp:TextBox ID="tb_passwordcon" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox><br />
            <asp:Label ID="l_passwordmatch" runat="server" ForeColor="Red" Text="Passwords don't match" Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="tb_email" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
            <br />
            <asp:Label ID="l_email" runat="server" ForeColor="Red" Text="You need a unique email" Visible="False"></asp:Label>
            <br />
        </div>  

        <div class="reg_vehicle">
            <asp:TextBox ID="tb_vehiclemake" runat="server" placeholder="Vehicle Make"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="tb_vehiclemodel" runat="server" placeholder="Vehicle Model"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="tb_vehicleage" runat="server" placeholder="Age of vehicle"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="tb_license" runat="server" placeholder="License Plate"></asp:TextBox>
            <br />
            <br />
            Last MOT
            
            <asp:TextBox ID="tb_lastMOT" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
            Next MOT
            <asp:TextBox ID="tb_nextMOT" runat="server" TextMode="Date"></asp:TextBox><br />
            <br />
            <asp:Button ID="b_Register" runat="server" Text="Next" />
        </div>
    </div>
    </asp:Content>
