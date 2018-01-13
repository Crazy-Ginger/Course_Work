﻿<%@ Page Title="Map" Language="VB" Masterpagefile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.vb" Inherits="Course_Work.Map" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
        <%--<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d4855861.9722248465!2d-2.456570850324048!3d54.73551770561395!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2suk!4v1508513543217" width="800" height="600" style="border:0"></iframe>--%>
        <div id='map' class="Map_Map" style='position:relative;width: 1050px; height: 800px; align-content:center'>

        </div>
        
        <script src='https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-directions/v3.1.1/mapbox-gl-directions.js'></script>
        <link rel='stylesheet' href='https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-directions/v3.1.1/mapbox-gl-directions.css' type='text/css' />
        <script>
            //var bounds = [
            //    [20.434570, 36.949892], [-18.500977, 62.714462]   commented as it breaks the map, dont know why
            //]
            mapboxgl.accessToken = 'pk.eyJ1IjoiY3JhenlnaW5nZXIiLCJhIjoiY2piMHUwZWl0MXJpdzJxczd5aHBrbWE0diJ9.rmrLoP64MNSp4ETaj53fPQ';

            var map = new mapboxgl.Map({
                container: 'map',
                style: 'mapbox://styles/mapbox/streets-v9',
                //maxBounds: bounds,
                //zoom: 13,
                //center: [0, 54.098060]    this dont work for some reason
            });
            

            map.addControl(new mapboxgl.NavigationControl());
            //https://www.mapbox.com/mapbox-gl-js/example/mapbox-gl-directions/ add this at a later date (driving directions)
            //https://www.mapbox.com/mapbox-gl-js/example/mapbox-gl-geocoder/ geocoder
            map.addControl(new MapboxDirections({accessToken: mapboxgl.accessToken}), 'top-left');
        </script>
    </div>
</asp:Content>