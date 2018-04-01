// JavaScript source code
function add (count) {
    var textbox = document.createElement("input");
    textbox.setAttribute("type", "text");
    textbox.setAttribute("value", "");
    textbox.setAttribute("name", "tb_dest" + count);
    Textbox.setAttribute("style", "width:200px");
    var panel = document.getElementById("p_routenodes");
    panel.appendchild(textbox);
}
