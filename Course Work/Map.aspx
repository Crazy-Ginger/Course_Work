<%@ Page Title="Map" Language="VB" Masterpagefile="~/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.vb" Inherits="Course_Work.Map" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <head>
        <script src='https://api.mapbox.com/mapbox-gl-js/v0.42.0/mapbox-gl.js'></script>
        <link href='https://api.mapbox.com/mapbox-gl-js/v0.42.0/mapbox-gl.css' rel='stylesheet' />
    </head>
        <div class="jumbotron">
            <%--<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d4855861.9722248465!2d-2.456570850324048!3d54.73551770561395!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2suk!4v1508513543217" width="800" height="600" style="border:0"></iframe>--%>
             <div id='map' style='width: 2000px; height: 800px;'></div>
    <script>
        mapboxgl.accessToken = 'pk.eyJ1IjoiY3JhenlnaW5nZXIiLCJhIjoiY2piMHUwZWl0MXJpdzJxczd5aHBrbWE0diJ9.rmrLoP64MNSp4ETaj53fPQ';
        var map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v10'
        });
        map.addControl(new mapboxgl.NavigationControl());
    </script>
        </div>
   
</asp:Content>