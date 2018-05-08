/*autocomplete___________________________________________________________________________________________________________________*/
/*function that takes the ID of the textbox being autocompleted and the list of possible autocompletes*/
function autocomplete(inp, arr) {
    /*creates local variable that will be used to select the autocomplete options*/
    var currentFocus;

    /*execute a function when someone writes in the text field:*/
    inp.addEventListener("input", function (e) {
        /*assigns the following variables with the text in the text box*/
        var a, b, i, val = this.value;
        /*close any already open lists of autocompleted values*/
        closeAllLists();
        /*returns false if the text box has no value assigned so no list appears*/
        if (!val) { return false; }
        currentFocus = -1;
        /*create a DIV element that will contain the items (values):*/
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "autocomplete-items");
        /*append the DIV element as a child of the autocomplete container:*/
        this.parentNode.appendChild(a);
        /*for limitting the size of the list*/
        var limit = 0
        /*for each item in the array*/
        for (i = 0; i < arr.length; i++) {
            /*allows the listed items to limited to only 10*/
            if (limit < 10) {
                /*checks if the item starts with the same letters as the text field value*/
                if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
                    limit += 1
                    /*create a DIV element for each matching element:*/
                    b = document.createElement("DIV");

                    /*makes the matching letters bold:*/
                    b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
                    b.innerHTML += arr[i].substr(val.length);
                    /*inserts an input field that will hold the current array item's value:*/
                    b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                    /*executes a function when someone clicks on the item value (DIV element):*/
                    b.addEventListener("click", function (e) {
                        /*insert the value for the autocomplete text field:*/
                        inp.value = this.getElementsByTagName("input")[0].value;
                        /*close the list of autocompleted values,
                        (or any other open lists of autocompleted values:*/
                        closeAllLists();
                    });
                    a.appendChild(b);
                }
            }
        }
    });

    /*execute a function presses a key on the keyboard*/
    inp.addEventListener("keydown", function (e) {
        var list = document.getElementById(this.id + "autocomplete-list");
        /*checks if the list is void*/
        if (list) {
            list = list.getElementsByTagName("div");
        }
        if (e.keyCode == 40 /*DOWN*/) {
            currentFocus++;
            addActive(list);
        } else if (e.keyCode == 38 /*UP*/) {
            currentFocus--;
            addActive(list);
        } else if (e.keyCode == 13 /*ENTER*/) {

            e.preventDefault();
            if (currentFocus > -1) {
                /*takes current selected item and places it in the text box*/
                if (list) {
                    list[currentFocus].click();
                }
            }
        }
    });

    /*highlights the current selected item to indicate that it is active*/
    function addActive(list) {
        /*removes all previosuly selected items*/
        if (!list) {
            return false;
        }
        /*start by removing the "active" class on all items:*/
        removeActive(list);
        /*if the current selection is beyond the lists length the first item is automatically selected*/
        if (currentFocus >= list.length) {
            currentFocus = 0;
        }
        /*if the current selection is less than 0 the last item in the list if selected*/
        if (currentFocus < 0) {
            currentFocus = (list.length - 1);
        }
        /*adds the current item to a class that will highlight the current item*/
        list[currentFocus].classList.add("autocomplete-active");
    }

    function removeActive(list) {
        /*cycles through all the items in the list*/
        for (var i = 0; i < list.length; i++) {
            list[i].classList.remove("autocomplete-active");
        }
    }
    /*closes the list except the chosen item*/
    function closeAllLists(elmnt) {
        /*selects the list by its class name*/
        var list = document.getElementsByClassName("autocomplete-items");
        for (var i = 0; i < list.length; i++) {
            if (elmnt != list[i] && elmnt != inp) {
                list[i].parentNode.removeChild(list[i]);
            }
        }
    }

    /*execute a function when someone clicks in the document:*/
    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });
}
