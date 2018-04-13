var count = 1
function boxes() {
    var parent = document.getElementById("p_routenodes");
    var tb = document.createElement("input");
    tb.setAttribute("Id", "tb_waypoints" + count);
    tb.setAttribute("placeholder", "Waypoint address");
    parent.appendChild(tb);
    count += 1
}