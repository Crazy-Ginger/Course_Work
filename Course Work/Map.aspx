<%@ Page Title="Map" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.vb" Inherits="Course_Work.Map" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent" EnableEventValidation="True">
    <div class="jumbotron" onload="setcount()">
        <%--<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d4855861.9722248465!2d-2.456570850324048!3d54.73551770561395!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2suk!4v1508513543217" width="800" height="600" style="border:0"></iframe>--%>
        <div class="d_Boxes">
            <span id="Left" class="Left">
                
                <asp:TextBox ID="tb_Start" runat="server" Width="200px" Placeholder="Start Location" AutoCompleteType="HomeZipCode" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_noStart" ControlToValidate="tb_start" Enabled="false" runat="server" ForeColor="Red" ErrorMessage="The route needs a Start"></asp:RequiredFieldValidator>
            </span>

            <div id="ToRight" class="ToRight">
                <asp:TextBox ID="tb_End" runat="server" Width="300px" Placeholder="Final Destination (optional)" AutoCompleteType="HomeZipCode" Height="40px"></asp:TextBox>
            </div>

            <br />
            <%--<input id="B_adDestination" type="button" runat="server" value="Add a Destination" OnClick="javascript:boxes()"/>--%>
            <%--<input id="B_removeDestination" type="button" runat="server" value="Add a Destination" OnClick="javascript:lessboxes()"/>--%>

            <asp:Button ID="b_AddDestination" runat="server" Text="Add a Destination" Font-Size="Medium" Height="40px" />    <%--OnClientClick="javascript:addboxes()--%>
            <asp:Button ID="b_LessDestination" runat="server" Text="Remove Destinations" Font-Size="Medium" Height="40px" />    <%--OnClientClick="reduceboxes(); return false"--%>
            <%--<asp:Button ID="testcallback" runat="server" Text="Test ME" OnClientClick="reduceboxes(); return false;" />--%>

            <asp:Label ID="l_destinations" runat="server" Text="You can only have 23 destinations" ForeColor="Red" Style="display: none;"></asp:Label>
            <%--<div id="d_routenodes"></div>--%>
            <asp:Panel ID="p_routenodes" runat="server"></asp:Panel>
        </div>

        <br />
        <%--<asp:Label ID="l_toomany" runat="server" ForeColor="Red" Text="Only 20 destinations are supported" Visible="False"></asp:Label>--%>

        <br />
        <asp:Button ID="b_RouteCalc" runat="server" Width="180px" Height="40px" Text="Calculate Route" Font-Size="Medium"/>
        <br />


        <%-- output details--%>
        <%--<asp:TextBox ID="tb_URL" runat="server"></asp:TextBox>--%>
        <asp:Label ID="l_Distance" runat="server"></asp:Label>
        <asp:Label ID="l_Duration" runat="server"></asp:Label>
        <asp:BulletedList ID="bl_nodes" runat="server"></asp:BulletedList>

        <%-- Change --%>
        <div id='map' class="mainMap" style='position: relative; width: 1050px; height: 800px; align-content: center'>
        </div>

        <script src='https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-directions/v3.1.1/mapbox-gl-directions.js'></script>

        <link rel='stylesheet' href='https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-directions/v3.1.1/mapbox-gl-directions.css' type='text/css' />

        <asp:Panel ID="p_bugtest" runat="server"></asp:Panel>
        
        <script>
            <%--var count = 1
            var parent = document.getElementById("<%=p_routenodes.ClientID%>");
            var current_ID=""
            function addboxes() {
                if (count <= 20) {
                    var tb = document.createElement("input");
                    current_ID = "tb_waypoints" + count
                    tb.setAttribute("Id", current_ID);
                    tb.setAttribute("placeholder", "Waypoint address");
                    //tb.setAttribute("max-width", "240px");
                    parent.appendChild(tb);
                    document.getElementById("tb_waypoints" + count).style.width = "210px";
                    count += 1;
                    console.log(count);
                    autocomplete(document.getElementById("tb_waypoints" + count), towns);
                }
                else {
                    document.getElementById("<%=l_destinations.ClientID%>").style.display = "inherit";
                }
                return false;
            }

            function reduceboxes() {
                console.log(count);
                if (count > 1) {
                    console.log(count);
                    document.getElementById("tb_waypoints" + count).remove;
                    count -= 1;
                    current_ID = "tb_waypoints" + count;
                }
            }--%>


            function map() {
                mapboxgl.accessToken = 'pk.eyJ1IjoiY3JhenlnaW5nZXIiLCJhIjoiY2piMHUwZWl0MXJpdzJxczd5aHBrbWE0diJ9.rmrLoP64MNSp4ETaj53fPQ';

                var map = new mapboxgl.Map({
                    container: 'map', style: 'mapbox://styles/mapbox/streets-v9',
                    //maxBounds: bounds,
                    //zoom: 13,
                    //center: [0, 54.098060]    this dont work for some reason
                    //https://api.mapbox.com base url for referencing
                });
                //var bounds = [
                //    [20.434570, 36.949892], [-18.500977, 62.714462]   commented as it breaks the map, dont know why
                //]
                map.addControl(new mapboxgl.NavigationControl());
                //https://www.mapbox.com/mapbox-gl-js/example/mapbox-gl-directions/ add this at a later date (driving directions)
                //https://www.mapbox.com/mapbox-gl-js/example/mapbox-gl-geocoder/ geocoder
                map.addControl(new MapboxDirections({ accessToken: mapboxgl.accessToken }), 'top-left');
                //https://blog.mapbox.com/efficient-multi-stop-routes-with-the-optimization-api-60d2beb7c82 optimised multi point system?
            }
            Map_Scripts.autocomplete(document.getElementById("<%=tb_Start.ClientID%>"), towns);
            <%--autocomplete(document.getElementById("<%=tb_Start.ClientID%>"), towns);
            autocomplete(document.getElementById("<%=tb_End.ClientID%>"), towns);--%>
            </script>
    </div>
</asp:Content>
