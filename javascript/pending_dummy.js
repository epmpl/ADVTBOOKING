
function filledition() {


    pendingfordummy.fillEdition2(document.getElementById('drppublication').value, document.getElementById('drppubcenter').value, document.getElementById('hiddencompcode').value, fillCat2_callback);

}


function fillCat2_callback(response) {
    var ds = response.value;
    var pkgitem = document.getElementById("drpedition");
    pkgitem.options.length = 1;
    pkgitem.options[0] = new Option("--Select Edition--", "0");

    // document.getElementById("drpadvcatcode").options.length = 1; 
    //document.getElementById("drpadvcatcode").options[0]=new Option("--Select Ad Category3--","0");
    //alert(pkgitem.options.length);
    for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias, ds.Tables[0].Rows[i].edition_code);

        pkgitem.options.length;

    }
    // document.getElementById("drpadsubcategory").value=glo_cat2;
    //  fillAdCat3();
    return false;
}





function suppbind() {

    var compcode = document.getElementById('hiddencompcode').value;
    var edition = document.getElementById('drpedition').value;
    pendingfordummy.bindsupp(compcode, edition, call_suppbind);
}
function call_suppbind(response) {
    ds = response.value;
    var edition = document.getElementById('drpsuppli');
    edition.options.length = 0;
    edition.options[0] = new Option("--Select Supplement--");
    document.getElementById("drpsuppli").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name, ds.Tables[0].Rows[i].Supp_Code);
            edition.options.length;
        }
    }

    return false;

}

function btnsubmit1() {
    if (document.getElementById('drpadtype').value == "0") {
        alert("Please Select Ad Type")
        return false;
    }
    else if (document.getElementById('txtpubfrdate').value == "") {
        alert("Please Select From Publish date")
        document.getElementById('txtpubfrdate').focus();
        return false;
    }
     else if (document.getElementById('txtpubtodate').value == "") {
        document.getElementById('txtpubtodate').focus();
        alert("Please Select To Publish date")
        return false;
    }
    else if (document.getElementById('drppubcenter').value == "") {
        alert("Please Select Publication Center")
        return false;
    }
}

function catexitclick() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
        return false;
    }
    return false;
}


function openreport() 
{
    window.open("pendingdummyreport.aspx");
    return false;
}