﻿<%@ Page Title="Map" Language="VB" Masterpagefile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.vb" Inherits="Course_Work.Map"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent" EnableEventValidation="True">
    <div class="jumbotron" onload="setcount()">
        <%--<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d4855861.9722248465!2d-2.456570850324048!3d54.73551770561395!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2suk!4v1508513543217" width="800" height="600" style="border:0"></iframe>--%>
        <div class="d_Boxes">
            <span id="Left" class="Left">
                <asp:TextBox ID="tb_Start" runat="server" Width="200px" Placeholder="Start Location" AutoCompleteType="HomeZipCode"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_noStart" ControlToValidate="tb_start" Enabled="false" runat="server" ForeColor="Red" ErrorMessage="The route needs a Start"></asp:RequiredFieldValidator>
            </span>

            <div id="ToRight" class="ToRight">
                <asp:TextBox ID="tb_End" runat="server" Width="300px" Placeholder="Final Destination (optional)" AutoCompleteType="HomeZipCode"></asp:TextBox>
            </div>

            <br />
            <asp:Button ID="b_AddDestination" runat="server" Text="Add a Destination" Font-Size="Medium" Height="40px" 0nClick="addBox()" />
            <%--<asp:DropDownList ID="ddl_Destinations" runat="server"></asp:DropDownList>--%>
            <asp:Panel ID="p_routenodes" runat="server"></asp:Panel>
        </div>

        <br />
        <%--<asp:Label ID="l_toomany" runat="server" ForeColor="Red" Text="Only 20 destinations are supported" Visible="False"></asp:Label>--%>

        <br />
        <asp:Button ID="b_RouteCalc" runat="server" Width="180px" Height="40px" Text="Calculate Route" Font-Size="Medium" />
        <br />
        

        <%-- output details--%>
        <asp:TextBox ID="tb_URL" runat="server"></asp:TextBox>
        <asp:TextBox ID="tb_Distance" runat="server"></asp:TextBox>
        <asp:TextBox ID="tb_Duration" runat="server"></asp:TextBox>


        <%-- Change --%>
        <div id='map' class="mainMap" style='position: relative; width: 1050px; height: 800px; align-content: center'>
        </div>

        <script src='https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-directions/v3.1.1/mapbox-gl-directions.js'></script>

        <link rel='stylesheet' href='https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-directions/v3.1.1/mapbox-gl-directions.css' type='text/css' />
        
        <script>
            function AddElement(url, cFunction) {
                var xhttp;
                xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        cFunction(this);
                    }
                };
                xhttp.open("GET", url, true);
                xhttp.send();
            }

            //var bounds = [
            //    [20.434570, 36.949892], [-18.500977, 62.714462]   commented as it breaks the map, dont know why
            //]
            function map() {
                mapboxgl.accessToken = 'pk.eyJ1IjoiY3JhenlnaW5nZXIiLCJhIjoiY2piMHUwZWl0MXJpdzJxczd5aHBrbWE0diJ9.rmrLoP64MNSp4ETaj53fPQ';

                var map = new mapboxgl.Map({
                    container: 'map',
                    style: 'mapbox://styles/mapbox/streets-v9',
                    //maxBounds: bounds,
                    //zoom: 13,
                    //center: [0, 54.098060]    this dont work for some reason
                    //https://api.mapbox.com base url for referencing
                });


                map.addControl(new mapboxgl.NavigationControl());
                //https://www.mapbox.com/mapbox-gl-js/example/mapbox-gl-directions/ add this at a later date (driving directions)
                //https://www.mapbox.com/mapbox-gl-js/example/mapbox-gl-geocoder/ geocoder
                map.addControl(new MapboxDirections({ accessToken: mapboxgl.accessToken }), 'top-left');
                //https://blog.mapbox.com/efficient-multi-stop-routes-with-the-optimization-api-60d2beb7c82 optimised multi point system?
            }

            function addBox() {
                var count = 1
                var xhttp = new XMLHttpRequest();
                var textbox = document.createElement("input");
                textbox.setAttribute("type", "text");
                textbox.setAttribute("value", "");
                textbox.setAttribute("name", "tb_dest" + count);
                Textbox.setAttribute("style", "width:200px");
                var panel = document.getElementById("p_routenodes");
                panel.addchild(textbox);
                count += 1
                return count
            }

        </script>
    </div>
   </asp:Content>