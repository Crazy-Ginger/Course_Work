<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register_user.aspx.vb" Inherits="Course_Work.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="class_reg">
        <br />
        <br />
        <div class="reg_user">
            <asp:TextBox ID="tb_fname" runat="server" placeholder="First Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_fname" runat="server" ForeColor="Red" ControlToValidate="tb_fname" ErrorMessage="Please enter a first name"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:TextBox ID="tb_lname" runat="server" placeholder="Last Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_lname" runat="server" ForeColor="Red" ControlToValidate="tb_lname" ErrorMessage="Please enter a surname"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:TextBox ID="tb_uname" runat="server" placeholder="Username"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_username" runat="server" ForeColor="Red" ControlToValidate="tb_uname" ErrorMessage="Please enter a username"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="l_username" runat="server" ForeColor="Red" Text="This username is taken" Visible="False"></asp:Label>
            <br />

            <asp:TextBox ID="tb_password" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_password" runat="server" ForeColor="Red" ControlToValidate="tb_password" ErrorMessage="Please enter a password"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="l_passwordlength" runat="server" Text="Password must be 8 characters or more" ForeColor="Red" Visible="false"></asp:Label>
            <br />

            <asp:TextBox ID="tb_passwordmatch" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_passwordMatch" runat="server" ForeColor="Red" ControlToValidate="tb_passwordmatch" ErrorMessage="Please re-enter your password"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="l_passwordmatch" runat="server" ForeColor="Red" Text="Passwords don't match" Visible="False"></asp:Label>
            <br />

            <asp:TextBox ID="tb_email" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_email" runat="server" ForeColor="Red" ControlToValidate="tb_email" ErrorMessage="Please enter am email"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="l_email" runat="server" ForeColor="Red" Text="This email  is taken" Visible="False"></asp:Label>
            <br />
        </div>

        <div class="reg_vehicle">
            <asp:TextBox ID="tb_vehiclemake" runat="server" placeholder="Vehicle Make"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_vehicleMake" runat="server" ForeColor="Red" ControlToValidate="tb_vehiclemake" ErrorMessage="Please enter a vehicle make"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:TextBox ID="tb_vehiclemodel" runat="server" placeholder="Vehicle Model"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_vehicleModel" runat="server" ForeColor="Red" ControlToValidate="tb_vehiclemodel" ErrorMessage="Please enter a vehcile model"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:TextBox ID="tb_vehicleage" runat="server" placeholder="Age of vehicle" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_vehicleage" runat="server" ForeColor="Red" ControlToValidate="tb_vehicleage" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:TextBox ID="tb_license" runat="server" placeholder="License Plate"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_license" runat="server" ForeColor="Red" ControlToValidate="tb_uname" ErrorMessage="Please enter the license plate"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="l_license" runat="server" Text="The license plate should be unique" ForeColor="Red" Visible="false"></asp:Label>
            <br />

            Last MOT
            <asp:TextBox ID="tb_lastMOT" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_lastMOT" runat="server" ForeColor="Red" ControlToValidate="tb_lastMOT" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
            <asp:Label ID="l_lastMOT" runat="server" ForeColor="Red" Text="Invalid date" Visible="false"></asp:Label>
            <br />
            <br />

            Next MOT
            <asp:TextBox ID="tb_nextMOT" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nextMOT" runat="server" ForeColor="Red" ControlToValidate="tb_nextMOT" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
            <asp:Label ID="l_nextMOT" runat="server" ForeColor="Red" Text="Invalid date" Visible="false"></asp:Label>
            <br />
            <br />
            <asp:Button ID="b_Register" runat="server" Text="Next" />
        </div>
    </div>
    </asp:Content>
