
function updatefont(val) {


    var compcode = document.getElementById('hiddencompcode').value;

    var editioncode = document.getElementById('hiddenedition').value;

    var fontsize = document.getElementById('exe2' + val).value;
    var fontleading1 = document.getElementById('exe' + val).value;
    var langcode = document.getElementById('exe3' + val).value;
    var fontname = document.getElementById('exe4' + val).value;



    var res = fontleading.update(compcode, langcode, fontleading1, fontsize, editioncode,fontname);
    if (res.error == null) {
        alert("Update Successfully");
    }
    else {
        alert(Error.description)
    }

    return false;
}

function saveclick() {

  


    var aa = document.getElementById('DataGrid1').rows.length


    for (var i = 0; i < aa - 1; i++) {
        var grdDatos = document.getElementById('DataGrid1');
        var fontsize = document.getElementById('exe2' + i).value;
        var fontleading1 = document.getElementById('exe' + i).value;
        var langcode = document.getElementById('exe3' + i).value;
        var fontname = document.getElementById('exe4' + i).value;
//        var langcode = grdDatos.rows[1].childNodes[3].innerText    
             var editioncode = document.getElementById('hiddenedition').value;
            var compcode = document.getElementById('hiddencompcode').value;
            var res = fontleading.save(compcode, langcode, fontleading1, fontsize, editioncode,fontname);
        }

        alert("Saved Successfully");

          





    return false;
}