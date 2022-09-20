//javascript
function Exit() {
    if (confirm("Do you want to skip this page. ")) {
        window.close();
        return false;
    }
    return false;
}


function forCancel() {
    document.getElementById("txtfrmdate").value = "";
    document.getElementById("txttodate1").value = "";
    document.getElementById('dppub1').value = "0";
    document.getElementById('dpbranch').value = document.getElementById('hdnbranch').value;
    document.getElementById('dpedition').value = "0";
    document.getElementById('dpcategory').value = "0";
    document.getElementById('dpadcat').value = "0";
    document.getElementById('txtage').value = "";
    document.getElementById('txtclient').value = "";
    document.getElementById('drpdestination').value = "1";
    document.getElementById('txtfrmdate').focus();
    return false;

}
function blankfields1() {

    document.getElementById("txtfrmdate").value = "";
    document.getElementById("txttodate1").value = "";
    document.getElementById('dppub1').value = "0";
    document.getElementById('dpbranch').value = document.getElementById('hdnbranch').value;
    document.getElementById('dpedition').value = "0";
    document.getElementById('dpcategory').value = "0";
    document.getElementById('dpadcat').value = "0";
    document.getElementById('txtage').value = "";
    document.getElementById('txtclient').value = "";
    document.getElementById('drpdestination').value = "1";
    document.getElementById('txtfrmdate').focus();
    return false;


    return false;

}

function keySort(dropdownlist, caseSensitive) {
    // check the keypressBuffer attribute is defined on the dropdownlist
    var undefined;
    if (dropdownlist.keypressBuffer == undefined) {
        dropdownlist.keypressBuffer = '';
    }
    // get the key that was pressed
    var key = String.fromCharCode(window.event.keyCode);
    dropdownlist.keypressBuffer += key;
    if (!caseSensitive) {
        // convert buffer to lowercase
        dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
    }
    // find if it is the start of any of the options
    var optionsLength = dropdownlist.options.length;
    for (var n = 0; n < optionsLength; n++) {
        var optionText = dropdownlist.options[n].text;
        if (!caseSensitive) {
            optionText = optionText.toLowerCase();
        }
        if (optionText.indexOf(dropdownlist.keypressBuffer, 0) == 0) {
            dropdownlist.selectedIndex = n;
            return false;
            // cancel the default behavior since
            // we have selected our own value
        }
    }
    // reset initial key to be inline with default behavior
    dropdownlist.keypressBuffer = key;
    return true; // give default behavior
}

function bind_edition13() {

    var comp_code = document.getElementById('hiddencompcode').value;
    var publication = document.getElementById('dppub1').value;
    var pub_cent = "";
    consolidated_sch_reg.edition_bind(publication, pub_cent, comp_code, call_bind_edition);

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


function F2fillclientcr(event) {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtclient") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hiddencompcode').value;
            var client = document.getElementById('txtclient').value;
            document.getElementById("div2").style.display = "block";
            document.getElementById('div2').style.top = 450 + "px";
            document.getElementById('div2').style.left = 750 + "px";
            document.getElementById('lstclintf2').focus();
            consolidated_sch_reg.fillF2_client(compcode, client, bindclient_callback);
        }
    }

}
function bindclient_callback(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstclintf2");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Client Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name, ds_AccName.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstclintf2").value = "0";
    document.getElementById("div2").value = "";
    document.getElementById('lstclintf2').focus();

    return false;

}


function Clickclient(event) {
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstclintf2") {
            if (document.getElementById('lstclintf2').value == "0") {
                alert("Please select Client Name");
                return false;
            }

            var page = document.getElementById('lstclintf2').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstclintf2').length - 1; k++) {
                if (document.getElementById('lstclintf2').options[k].value == page) {
                    var abc = document.getElementById('lstclintf2').options[k].innerText;
                    document.getElementById('txtclient').value = abc;
                    document.getElementById('hdnclienttxt').value = abc;
                    document.getElementById('hdnclntcode').value = page;

                    document.getElementById("div2").style.display = "none";
                    document.getElementById('txtclient').focus();
                    return false;

                }
            }
        }
    }
    else if (event.keyCode == 27) {

        document.getElementById("div2").style.display = "none";
        document.getElementById('txtclient').focus();
    }
}

////////////////Agency F2///////////////
function F2fillagencycr(event) {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtage") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hiddencompcode').value;
            var agn = document.getElementById('txtage').value;
            document.getElementById("div1").style.display = "block";
            document.getElementById('div1').style.top = 350 + "px"; //314//290
            document.getElementById('div1').style.left = 278 + "px"; //395//1004
            document.getElementById('lstagencyf2').focus();
            consolidated_sch_reg.fillF2_Agency(compcode, agn, bindAgency_callback);
        }
    }

}



function bindAgency_callback(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstagencyf2");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name, ds_AccName.Tables[0].Rows[i].code_subcode);
            pkgitem.options.length;
        }
    }

    var aTag = eval(document.getElementById('txtage'))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById('div1').scrollLeft;
    var scrolltop = document.getElementById('div1').scrollTop;
    document.getElementById('div1').style.left = document.getElementById('txtage').offsetLeft + leftpos - tot + "px";
    document.getElementById('div1').style.top = document.getElementById('txtage').offsetTop + toppos - scrolltop + "px"; //"510px";


    document.getElementById("lstagencyf2").value = "0";
    document.getElementById("div1").value = "";
    document.getElementById('lstagencyf2').focus();

    return false;

}



function ClickAgaency(event) {
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstagencyf2") {
            if (document.getElementById('lstagencyf2').value == "0") {
                alert("Please select Agency Name");
                return false;
            }

            var page = document.getElementById('lstagencyf2').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstagencyf2').length - 1; k++) {
                if (document.getElementById('lstagencyf2').options[k].value == page) {

                    //if (browser != "Microsoft Internet Explorer") {
                    //    var abc = document.getElementById('lstagencyf2').options[k].textContent;
                    //}

                    //else {
                    var abc = document.getElementById('lstagencyf2').options[k].innerText;
                    //}
                    document.getElementById('txtage').value = abc;
                    document.getElementById('hdnagencytxt').value = abc;
                    document.getElementById('hdnagncode').value = page;

                    document.getElementById("div1").style.display = "none";
                    document.getElementById('txtage').focus();
                    return false;

                }
            }
        }
    }
    else if (event.keyCode == 27) {

        document.getElementById("div1").style.display = "none";
        //document.getElementById('txtage').focus();
    }
}

function bindadcat() {
    var compcode = document.getElementById('hiddencompcode').value;
    var adtype1 = document.getElementById('dpcategory').value;
    consolidated_sch_reg.adcatbnd(adtype1, compcode, call_adcatbind);

}
function call_adcatbind(response) {
    ds = response.value;
    var brand = document.getElementById('dpadcat');
    brand.options.length = 0;
    brand.options[0] = new Option("Select AdCat");
    document.getElementById("dpadcat").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name, ds.Tables[0].Rows[i].Adv_Cat_Code);
            brand.options.length;
        }
    }

    return false;
}


//function bindqbc_new() {

//    consolidated_sch_reg.fillQBC(document.getElementById('dppubcent').value, bindQBC_callback11);
//}

//function bindQBC_callback11(response) {
//    var ds = response.value;
//    agcatby = document.getElementById("dpbranch");
//    agcatby.options.length = 1;
//    agcatby.options[0] = new Option("--Select Branch--", "0");
//    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {

//        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i) {
//            agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name, ds.Tables[0].Rows[i].Branch_Code);
//            agcatby.options.length;

//        }
//    }
//}

function forreport() {
    if (document.getElementById('txtfrmdate').value == "") {
        alert("Please Fill From Date.")
        document.getElementById('txtfrmdate').focus();
        return false;
    }

    if (document.getElementById('txttodate1').value == "") {
        alert("Please Fill To Date.")
        document.getElementById('txttodate1').focus();
        return false;
    }

    //if (document.getElementById('dpbranch').value == "0") {
    //    alert("Please Select Branch.")
    //    document.getElementById('dpbranch').focus();
    //    return false;
    //}


    var fromdate = document.getElementById("txtfrmdate").value;
    var todate = document.getElementById("txttodate1").value;
    var pub = document.getElementById('dppub1').value;
    var branch = document.getElementById('dpbranch').value;
    var edtn = document.getElementById('dpedition').value;
    var dest = document.getElementById('drpdestination').value;
    var adtype = document.getElementById('dpcategory').value
    var adcat = document.getElementById('dpadcat').value;

    var agcd = document.getElementById('hdnagncode').value;
    var agname = document.getElementById('hdnagencytxt').value;
    var clientcd = document.getElementById('hdnclntcode').value;
    var clientnm = document.getElementById('hdnclienttxt').value;
   
    var extra1 = document.getElementById('hiddenuserid').value;
    var extra2 = "";
    var extra3 = "";
    var extra4 = "";
    var extra5 = "";





    var adcatNM = "";
    if (document.getElementById("dpadcat").selectedIndex == -1 || document.getElementById("dpadcat").selectedIndex == 0) {
        adcatNM = "";
    }
    else {
        adcatNM = document.getElementById("dpadcat").options[document.getElementById("dpadcat").selectedIndex].text;
    }
   
    
    consolidated_sch_reg.setSessionmis_run(fromdate, todate, branch, pub, edtn, dest, adtype, adcat, agcd, agname, clientcd, clientnm, extra1, extra2, extra3, extra4, extra5, adcatNM);
    window.open('consolidated_sch_reg_view.aspx');
    return false;

}

function forclick() {
    //$('btnprint').style.display="none";
    document.getElementById('btnprint').style.display = "none";
    window.print();
    return false;

}
