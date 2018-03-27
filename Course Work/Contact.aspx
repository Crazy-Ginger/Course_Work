<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="Course_Work.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
        <%--<iframe class="Cont_map" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1181.8192193945974!2d-1.8240724916383704!3d53.671245984000315!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x487bdce435863ad9%3A0x41e2d54f3c40f42f!2sGrimescar+Rd%2C+Huddersfield+HD2+2EB!5e0!3m2!1sen!2suk!4v1506872212219" width="600" height="600"  style="border:0"></iframe>--%>
    <div id='map' class="Map_cont" style='width: 800px; height: 400px; float: right;'>
    </div>
    <script>
        mapboxgl.accessToken = 'pk.eyJ1IjoiY3JhenlnaW5nZXIiLCJhIjoiY2piMHUwZWl0MXJpdzJxczd5aHBrbWE0diJ9.rmrLoP64MNSp4ETaj53fPQ';
        var map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v10'
        });
        map.addControl(new mapboxgl.NavigationControl());
    </script>
    <div ID="address-words">
        <p>The Crossley Heath School</p>
        <p>Savile Park</p>
        <p>Halifax</p>
        <p>HX3 0HG </p>
        <asp:TextBox ID="TestBox1" runat="server"></asp:TextBox>
         <asp:TextBox ID="TestBox2" runat="server"></asp:TextBox>
         <asp:TextBox ID="TestBox3" runat="server"></asp:TextBox>
         <asp:TextBox ID="TestBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
    </div>
    <div id="Contact" style="position: fixed; bottom: 0;">
        <pre>
            <abbr title="Phone">Phone: 01422 360272</abbr>      <a id="A_email" runat="server" href=" " >email</a></pre>
    </div>
</asp:Content>
