var browser = navigator.appName;
function bind_edition8() {
    var comp_code = document.getElementById('hiddencompcode').value;
    var pub_cent = document.getElementById('dppubcent').value;
    var publication = document.getElementById('dppub1').value;

    Reports_dummy_summaryrevenue.edition_bind(publication, pub_cent, comp_code, call_bind_edition);
}


function call_bind_edition(response) {
    ds = response.value;
    var edition = document.getElementById('dpedition');
    edition.options.length = 0;
    edition.options[0] = new Option("--Select Edition Name--");
    document.getElementById("dpedition").options.length = 1;
    if (ds != null && ds.Tables.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias, ds.Tables[0].Rows[i].edition_code);
            edition.options.length;
        }

    }
    return false
}



function chkpubnew(event) {

    var abc1 = document.getElementById('txtfrmdate').value
    var alrt="";
    if (browser != "Microsoft Internet Explorer") {
        alrt = document.getElementById('lbDateFrom').textContent;
    }
    else {
        alrt = document.getElementById('lbDateFrom').innerText;
    }
    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txtfrmdate').value == "") {
            var abc = alrt.replace("*", "");
            alert('Please Enter ' + abc);
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    }

    if (document.getElementById('dppub1').value == "0") {
        alert("Please Select Publication");
        document.getElementById('dppub1').focus();
        return false;
    }


    document.getElementById('hiddenedition').value = document.getElementById('dpedition').value;
    var des = document.getElementById('dpedition').options.selectedIndex;
    if (des != -1)
        document.getElementById('hiddeneditionname').value = document.getElementById('dpedition').options[des].text;

}
    