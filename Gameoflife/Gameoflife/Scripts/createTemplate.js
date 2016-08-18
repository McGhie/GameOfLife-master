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


    while (i < y.value) {

        while (j < x.value) {

            var thisCell = document.getElementById("cell_" + idNumber);
            insert = thisCell.getAttribute("value");
            thisCell.setAttribute("onclick", null);
            template = template.concat(insert);
            console.log(idNumber);
            j++;
            idNumber++;
        }
        template = template.concat("\n");
        i++;
        j = 0;
    }

    console.log("the template is:\n " + template);
    document.getElementById("CellInputDevice").innerHTML = template;

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
            cell.setAttribute("class", "newcell");
            console.log("the cellid is " + cell.id);
            var id = cell.id;
            console.log(id);
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
        thisCell.style.background = "blue";
        thisCell.setAttribute("value", "O");
    }
    else {
        console.log(val);
        thisCell.style.background = "white";
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

                thisCell.style.background = "green";
                thisCell.setAttribute('value', "O");
                console.log(idNumber + "= " + thisCell.value);
            }
            else {

                thisCell.style.background = "white";
                thisCell.setAttribute('value', "X");
            }

            j++;
            idNumber++;
        }
        i++;
        j = 0;
    }

}