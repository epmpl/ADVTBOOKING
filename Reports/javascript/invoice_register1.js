//javascript


function Exit() {
    if (confirm("Do you want to skip this page. ")) {
        window.close();
        return false;
    }
    return false;
}

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
    document.getElementById('dppubcent').value = "0";
    document.getElementById('dpbranch').value = "0";
    document.getElementById('dpedition').value = "0";
    document.getElementById('dpregion').value = "0";
    document.getElementById('ddldistrict').value = "0";
    document.getElementById('drpdestination').value = "0";
    document.getElementById('dpcategory').value = "0";
    document.getElementById('dpadcat').value = "0";
    document.getElementById('dpadsubcat').value = "0";
    document.getElementById('dpagtype').value = "0";
    document.getElementById('dpagcat').value = "0";
    document.getElementById('dpproduct').value = "0";
    document.getElementById('dpteam').value = "0";
    document.getElementById('dpexec').value = "0";
    document.getElementById('txtage').value = "";
    document.getElementById('txtclient').value = "";
    document.getElementById('drpbreak').value = "D";
    document.getElementById('drpdestination').value = "1";
    document.getElementById('txtfrmdate').focus();
    return false;

}
function blankfields1() {

    document.getElementById("txtfrmdate").value = "";
    document.getElementById("txttodate1").value = "";
    document.getElementById('dppub1').value = "0";
    document.getElementById('dppubcent').value = "0";
    document.getElementById('dpbranch').value = "0";
    document.getElementById('dpedition').value = "0";
    document.getElementById('dpregion').value = "0";
    document.getElementById('ddldistrict').value = "0";
    document.getElementById('drpdestination').value = "0";
    document.getElementById('dpcategory').value = "0";
    document.getElementById('dpadcat').value = "0";
    document.getElementById('dpadsubcat').value = "0";
    document.getElementById('dpagtype').value = "0";
    document.getElementById('dpagcat').value = "0";
    document.getElementById('dpproduct').value = "0";
    document.getElementById('dpteam').value = "0";
    document.getElementById('dpexec').value = "0";
    document.getElementById('txtage').value = "";
    document.getElementById('txtclient').value = "";
    document.getElementById('drpbreak').value = "D";
    document.getElementById('drpdestination').value = "1";
    document.getElementById('txtfrmdate').focus();


    return false;

}
function billclick1() {
    if (document.getElementById("bill").checked == true) {
        document.getElementById("bill").checked = true;
        document.getElementById("schedule").checked = false;
        return true;
    }
    else {
        document.getElementById("bill").checked = true
        return true;
    }
}


function scheduleclick1() {
    if (document.getElementById("schedule").checked == true) {
        document.getElementById("bill").checked = false;
        document.getElementById("schedule").checked = true;
        return true;
    }
    else {
        document.getElementById("schedule").checked = true
        return true;
    }
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
    invoice_register.edition_bind(publication, pub_cent, comp_code, call_bind_edition);

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

/////////////f2 bil register
////function F2fillexecutivecr_bill(event) {
////    if (event.keyCode == 113) {
////        divid = "div3";
////        listboxid = "lstexecutive";
////        txtbxid = eval(document.getElementById('txt_executive'))
////        txtboxid = "txt_executive";
////        if (document.activeElement.id == "txt_executive") {
////            //$('txtagency').value="";
////            var compcode = document.getElementById('hiddencompcode').value;
////            var executive = document.getElementById('txt_executive').value;
////            document.getElementById("div3").style.display = "block";
////            document.getElementById('div3').style.top = 366 + "px";
////            document.getElementById('div3').style.left = 500 + "px";
////            document.getElementById('lstexecutive').focus();
////            invoice_register.fillF2_Creditexecutive(compcode, executive, bindexecutive_callbackreg);
////        }
////    }

////}
////function Clickexecutive_bill(event) {
////    if (event.keyCode == 13 || event.type == "click") {
////        if (document.activeElement.id == "lstexecutive") {
////            if (document.getElementById('lstexecutive').value == "0") {
////                alert("Please select Executive Name");
////                return false;
////            }

////            var page = document.getElementById('lstexecutive').value;
////            agencycode = page;
////            for (var k = 0; k <= document.getElementById('lstexecutive').length - 1; k++) {
////                if (document.getElementById('lstexecutive').options[k].value == page) {
////                    if (browser != "Microsoft Internet Explorer") {
////                       var abc = document.getElementById('lstexecutive').options[k].textContent;
////                    }
////                    else {
////                    var abc = document.getElementById('lstexecutive').options[k].innerText;

////                }
////            }
////                document.getElementById('txt_executive').value = abc;

////                document.getElementById('hdnexecode').value = page;

////                document.getElementById('hdnexename').value = abc;

////                document.getElementById("div3").style.display = "none";
////                document.getElementById('txt_executive').focus();
////                return false;

////            }
////        }
////    }
////    else if (event.keyCode == 27) {

////        document.getElementById("div3").style.display = "none";
////        document.getElementById('txt_executive').focus();
////    }

////}
//////}

function bind_exe_represen() {
    var comp_code = document.getElementById('hiddencompcode').value;
    var team = document.getElementById('dpteam').value;
    var userid = document.getElementById('hiddenuserid').value;


    invoice_register.exe_bind(comp_code, userid, team, call_bind_team_exe);

}

function call_bind_team_exe(response) {
    ds = response.value;
    var edition = document.getElementById('dpexec');
    edition.options.length = 0;
    edition.options[0] = new Option("--Select Executive Name--");
    document.getElementById("dpexec").options.length = 1;

    for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
        edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Exec_name, ds.Tables[0].Rows[i].Exe_no);
        edition.options.length;
    }


    return false
}


function bindexecutive_callbackreg(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstexecutive");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Executive Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0  ; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Exec_name, ds_AccName.Tables[0].Rows[i].Exe_no);
            pkgitem.options.length;
        }
    }

    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        txtbxid = eval(txtbxid.offsetParent);
        leftpos += txtbxid.offsetLeft;
        toppos += txtbxid.offsetTop;
        btag = eval(txtbxid)
    } while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
    var tot = document.getElementById('div3').scrollLeft;
    var scrolltop = document.getElementById('div3').scrollTop;
    document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; //"510px";


    document.getElementById("lstexecutive").value = "0";
    document.getElementById("div3").value = "";
    document.getElementById('lstexecutive').focus();

    return false;

}


////////Client F2/////////////////


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
            invoice_register.fillF2_client(compcode, client, bindclient_callback);
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
            invoice_register.fillF2_Agency(compcode, agn, bindAgency_callback);
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
    invoice_register.adcatbnd(adtype1, compcode, call_adcatbind);

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


function bindsubcat() {
    var compcode = document.getElementById('hiddencompcode').value;
    var adcat1 = document.getElementById('dpadcat').value;
    //billwismxls.subcatbind(compcode,adcat1,call_adsubcatbind);
    invoice_register.subcatbind(compcode, adcat1, call_adsubcatbind);
}



function call_adsubcatbind(response) {
    ds = response.value;
    var brand = document.getElementById('dpadsubcat');
    brand.options.length = 0;
    brand.options[0] = new Option("Select AdSubCat");
    document.getElementById("dpadsubcat").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name, ds.Tables[0].Rows[i].Adv_Subcat_Code);
            brand.options.length;
        }
    }

    return false;
}

function bindsubcat345(id) {

    var compcode = document.getElementById('hiddencompcode').value;
    if (id == 'dpadsubcat') {
        var adsubcat1 = document.getElementById('dpadsubcat').value;
        invoice_register.subcat345(adsubcat1, compcode, "", "", call_adsubcat345);
    }
    else if (id == 'dpadsubcat3') {
        var adsubcat3 = document.getElementById('dpadsubcat3').value;
        invoice_register.subcat345("", compcode, adsubcat3, "", call_adsubcat4);
    }
    else if (id == 'dpadsubcat4') {
        var adsubcat4 = document.getElementById('dpadsubcat4').value;
        invoice_register.subcat345("", compcode, "", adsubcat4, call_adsubcat5);
    }

}

function call_adsubcat345(response) {
    ds = response.value;

    var brand = document.getElementById('dpadsubcat');
    brand.options.length = 0;
    brand.options[0] = new Option("Select AdSubCat3");
    document.getElementById("dpadsubcat").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].catname, ds.Tables[0].Rows[i].catcode);
            brand.options.length;
        }
    }


    return false;
}

function call_adsubcat4(response) {
    ds = response.value;
    var edition = document.getElementById('dpadsubcat4');
    edition.options.length = 0;
    edition.options[0] = new Option("Select AdSubCat4");
    document.getElementById("dpadsubcat4").options.length = 1;


    if (ds.Tables[1].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[1].Rows.length; i++) {
            edition.options[edition.options.length] = new Option(ds.Tables[1].Rows[i].Cat_Name, ds.Tables[1].Rows[i].Cat_Code);
            edition.options.length;
        }
    }

    return false;
}

function call_adsubcat5(response) {
    ds = response.value;
    var agency = document.getElementById('dpadsubcat5');
    agency.options.length = 0;
    agency.options[0] = new Option("Select AdSubCat5");
    document.getElementById("dpadsubcat5").options.length = 1;


    if (ds.Tables[2].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[2].Rows.length; i++) {
            agency.options[agency.options.length] = new Option(ds.Tables[2].Rows[i].Cat_Name, ds.Tables[2].Rows[i].Cat_Code);
            agency.options.length;
        }
    }

    return false;
}

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
    var region = document.getElementById('dpregion').value;
    var dist = document.getElementById('ddldistrict').value;
    var dest = document.getElementById('drpdestination').value;
    var adtype = document.getElementById('dpcategory').value
    var adcat = document.getElementById('dpadcat').value;
    var adsubcat = document.getElementById('dpadsubcat').value;
    var agtype = document.getElementById('dpagtype').value;
    var agcat = document.getElementById('dpagcat').value;
    var product = document.getElementById('dpproduct').value;
    var executiveCd = document.getElementById('dpexec').value;
    var pcent = document.getElementById('dppubcent').value;
    var agcd = document.getElementById('hdnagncode').value;
    var agname = document.getElementById('hdnagencytxt').value;
    var clientcd = document.getElementById('hdnclntcode').value;
    var clientnm = document.getElementById('hdnclienttxt').value;
    var brkon = document.getElementById('drpbreak').value;
    var billtype = "";
    var req_parent_child = "";
    var paymode = "";
    var extra4 = "";
    var extra5 = "";
    var extra12 = "";///productsubcat
    var extra14 = "";
    var extra15 = document.getElementById('dpcategory').value;





    var adcatNM = "";
    if (document.getElementById("dpadcat").selectedIndex == -1 || document.getElementById("dpadcat").selectedIndex == 0) {
        adcatNM = "";
    }
    else {
        adcatNM = document.getElementById("dpadcat").options[document.getElementById("dpadcat").selectedIndex].text;
    }
    var exename = "";
    if (document.getElementById("dpexec").selectedIndex == -1 || document.getElementById("dpexec").selectedIndex == 0) {
        exename = "";
    }
    else {
        exename = document.getElementById("dpexec").options[document.getElementById("dpexec").selectedIndex].text;
    }
    //var extra5 = "";
    invoice_register.setSessionmis_run(fromdate, todate, branch, pub, edtn, region, dist, dest, adtype, adcat, adsubcat, agtype, agcat, product, executiveCd, exename, agcd, agname, clientcd, clientnm, brkon, billtype, req_parent_child, paymode, extra4, extra5, extra12, extra14, extra15, adcatNM, pcent);
    window.open('rpt_invoice_register.aspx');
    return false;

}



function forclick() {
    //$('btnprint').style.display="none";
    document.getElementById('btnprint').style.display = "none";
    window.print();
    return false;

}
