<%@ Page Title="Map" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.vb" Inherits="Course_Work.Map" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent" EnableEventValidation="True">
    <div class="jumbotron" onload="setcount()">
        <%--<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d4855861.9722248465!2d-2.456570850324048!3d54.73551770561395!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2suk!4v1508513543217" width="800" height="600" style="border:0"></iframe>--%>
        <div class="d_Boxes">
            <span id="Left" class="Left">
                <asp:TextBox ID="tb_Start" runat="server" Width="200px" Placeholder="Start Location" AutoCompleteType="BusinessCity" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_noStart"  Enabled="true" runat="server" ForeColor="Red" ErrorMessage="The route needs a Start" ValidationGroup="routing" ControlToValidate="tb_start"></asp:RequiredFieldValidator>  <%--ControlToValidate="tb_start"--%>
            </span>

            <div id="ToRight" class="ToRight">
                <asp:TextBox ID="tb_End" runat="server" Width="300px" Placeholder="Final Destination (optional)" AutoCompleteType="BusinessCity" Height="40px"></asp:TextBox>
            </div>
            <br />

            <asp:Button ID="b_AddDestination" runat="server" Text="Add a Destination" CausesValidation="false" Font-Size="Medium" Height="40px"/>    <%--OnClientClick="javascript:addboxes()--%>
            <asp:Button ID="b_LessDestination" runat="server" Text="Remove Destination" CausesValidation="false" Font-Size="Medium" Height="40px" />    <%--OnClientClick="reduceboxes(); return false"--%>
           


            <asp:Label ID="l_destinations" runat="server" ForeColor="Red" visibible="false"></asp:Label>

            <asp:Panel ID="p_routenodes" runat="server"></asp:Panel>
        </div>

        <br />

        <%--<asp:Label ID="l_toomany" runat="server" ForeColor="Red" Text="Only 20 destinations are supported" Visible="False"></asp:Label>--%>

        <br />
        <asp:Button ID="b_RouteCalc" runat="server" Width="180px" Height="40px" Text="Calculate Route" Font-Size="Medium" ValidationGroup="routing" CausesValidation="true"/>
        <br />

        <div style="float:right;">
        <asp:Label ID="l_Distance" runat="server"></asp:Label>
        <asp:Label ID="l_Duration" runat="server"></asp:Label>
        <asp:BulletedList ID="bl_nodes" runat="server"></asp:BulletedList>
        </div>

        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d4855861.9722248465!2d-2.456570850324048!3d54.73551770561395!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2suk!4v1508513543217" width="700" height="600" style="border: hidden; position: absolute; float: left;"></iframe>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <script>
            <%--autocomplete(document.getElementById("<%=tb_Start.ClientID%>"), towns);
            autocomplete(document.getElementById("<%=tb_End.ClientID%>"), towns);--%>
</script>
    </div>
</asp:Content>
