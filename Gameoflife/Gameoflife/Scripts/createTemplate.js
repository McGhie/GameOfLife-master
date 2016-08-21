/*!
 * CreateTemmplate v1.0.0 
 * N/A Copyright 2016.
 * N/A license
 * Any one can use this content as they please
 */



function savetemplatedata() {

    var x = document.getElementById("x");
    var y = document.getElementById("y");
    var template = "";
    var insert;
    var idNumber = 0;
    var i = 0;
    var j = 0;
    var checkiftableisblank = 0;


    while (i < y.value) {

        while (j < x.value) {

            var thisCell = document.getElementById("cell_" + idNumber);
            insert = thisCell.getAttribute("value");
            if (insert === "O") {

                checkiftableisblank++;
            }
            thisCell.setAttribute("onclick", null);
            template = template.concat(insert);
            j++;
            idNumber++;
        }
        template = template.concat("\n");
        i++;
        j = 0;
    }

    if (checkiftableisblank === 0) {
        alert("This must be the first time you have played?" +
            " So we have inserted for you. Next time try clicking in the " +
            "black space so you get to create your own"
            );
        $("#seed_Cells").hide();
        seedCells();
    }
    else {
        document.getElementById("CellInputDevice").innerHTML = template;
        $("#seed_Cells").hide();
        $("#newTemplate").hide();
        $("#hiddenSubmitButton").slideToggle("slow");
    }
}

function createblanktemplate() {

    var i = 0;
    var j = 0;
    var cellID = 0;
    var table = document.getElementById("myTable");
    var x = document.getElementById("x");
    var y = document.getElementById("y");


    while (i < y.value) {
        var row = table.insertRow(i);

        while (j < x.value) {
            var cell = row.insertCell(j);
            cell.setAttribute("id", "cell_" + cellID);
            cell.setAttribute("value", "X");
            cell.style.background = "black";
            cell.setAttribute("class", "newcell");
         
            var id = cell.id;
           
            cell.setAttribute("onclick", "addOrRemove(id);");
            cellID++;
            j++;
        }
        i++;
        j = 0;
    }



}

function addOrRemove(id) {
    //cell.style.background="red";
    var thisCell = document.getElementById(id);
    var val = thisCell.getAttribute("value");

    if (val === "X") {
        console.log(val);
        thisCell.style.background = "#00a600";
        thisCell.setAttribute("value", "O");
    }
    else {
        console.log(val);
        thisCell.style.background = "black";
        thisCell.setAttribute("value", "X");


    }



}

function seedCells() {


    var x = document.getElementById("x");
    var y = document.getElementById("y");
    
    var idNumber = 0;
    var i = 0;
    var j = 0;
    while (i < y.value) {

        while (j < x.value) {

            var thisCell = document.getElementById("cell_" + idNumber);

            var num = Math.floor((Math.random() * 3) + 1);
            console.log(num);
            if (num > 2) {

                thisCell.style.background = "#00a600";
                thisCell.setAttribute('value', "O");
                console.log(idNumber + "= " + thisCell.value);
            }
            else {

                thisCell.style.background = "black";
                thisCell.setAttribute('value', "X");
            }

            j++;
            idNumber++;
        }
        i++;
        j = 0;
    }

}