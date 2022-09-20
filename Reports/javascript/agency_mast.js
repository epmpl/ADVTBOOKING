//javascript
function Exit() {
    if (confirm("Do you want to skip this page. ")) {
        window.close();
        return false;
    }
    return false;
}
function forCancel() {
    document.getElementById('txtcompname').value = document.getElementById('hdncompname').value;
    document.getElementById('txtcompname').disabled = true;
    document.getElementById('dpagencytype').value = 0;
    document.getElementById('dpzone').value = 0;
    document.getElementById('drpdestination').value = 0;
    document.getElementById('dpregion').value = 0;
    document.getElementById('dpstate').value = 0;
    document.getElementById('dppubcent').value = 0;
    document.getElementById('dpbranch').value = 0;
    document.getElementById('dpdistrict').value = 0;
    document.getElementById('dpcity').value = 0;
   
    return false;
}
function blankfields1() {
      document.getElementById('txtcompname').value = document.getElementById('hdncompname').value;
    document.getElementById('txtcompname').disabled = true;
    document.getElementById('dpagencytype').value = 0;
    document.getElementById('dpzone').value = 0;
    document.getElementById('drpdestination').value = 1;
    document.getElementById('dpregion').value = 0;
    document.getElementById('dpstate').value = 0;
    document.getElementById('dppubcent').value = 0;
    document.getElementById('dpbranch').value = 0;
    document.getElementById('dpdistrict').value = 0;
    document.getElementById('dpcity').value = 0;
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

function F2fillagencycr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "dpagency") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value;
            var agn = document.getElementById('dpagency').value;
            document.getElementById("div1").style.display = "block";
            document.getElementById('div1').style.top = 350 + "px";//314//290
            document.getElementById('div1').style.left = 278 + "px";//395//1004
            document.getElementById('lstagency').focus();
            // billwismxls.fillF2_CreditAgency(compcode,agn,bindAgency_callback1);
            Reports_AGENCY_MAST.fillF2_CreditAgency(compcode, agn, bindAgency_callback1);
        }
    }

    function bindAgency_callback1(res) {
        var ds_AccName = res.value;

        if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
            var pkgitem = document.getElementById("lstagency");
            pkgitem.options.length = 0;
            pkgitem.options[0] = new Option("-Select Agency Name-", "0");
            pkgitem.options.length = 1;
            for (var i = 0  ; i < ds_AccName.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name, ds_AccName.Tables[0].Rows[i].Agency_Code);
                pkgitem.options.length;
            }
        }

        var aTag = eval(document.getElementById('dpagency'))
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
        document.getElementById('div1').style.left = document.getElementById('dpagency').offsetLeft + leftpos - tot + "px";
        document.getElementById('div1').style.top = document.getElementById('dpagency').offsetTop + toppos - scrolltop + "px"; //"510px";



        document.getElementById("lstagency").value = "0";
        document.getElementById("div1").value = "";
        document.getElementById('lstagency').focus();
        //alert(ds_AccName.Tables[0].Rows[i].Agency_Name)
        return false;

    }
    //////////////////


    function ClickAgaency1(event) {
        var key = event.keyCode ? event.keyCode : event.which;
        if (key == 13 || event.type == "click") {
            if (document.activeElement.id == "lstagency") {
                if (document.getElementById('lstagency').value == "0") {
                    alert("Please select Agency Name");
                    return false;
                }

                var page = document.getElementById('lstagency').value;
                agencycode = page;
                for (var k = 0; k <= document.getElementById('lstagency').length - 1; k++) {
                    if (document.getElementById('lstagency').options[k].value == page) {
                        if (browser != "Microsoft Internet Explorer") {
                            var abc = document.getElementById('lstagency').options[k].textContent;
                        }
                        else {
                            var abc = document.getElementById('lstagency').options[k].innerText;
                        }
                        document.getElementById('dpagency').value = abc;
                        document.getElementById('hdnagencytxt').value = abc;
                        document.getElementById('hdnagency1').value = page;

                        document.getElementById("div1").style.display = "none";
                        document.getElementById('dpagency').focus();
                        return false;

                    }
                }
            }
        }
        else if (key == 27) {

            document.getElementById("div1").style.display = "none";
            document.getElementById('dpagency').focus();
        }
    }
}
//////////////////////client
function F2fillclientcr() {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtclient") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value;
            var client = document.getElementById('txtclient').value;
            document.getElementById("div2").style.display = "block";
            document.getElementById('div2').style.top = 366 + "px";
            document.getElementById('div2').style.left = 500 + "px";
            document.getElementById('lstclintf2').focus();
            Reports_AGENCY_MAST.fillF2_client(compcode, client, bindclient_callback);
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


function Clickclient() {
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
/////////////////////////////////////////exe
function F2fillexecutivecr_bill(event) {
    if (event.keyCode == 113) {
        divid = "div3";
        listboxid = "lstexecutive";
        txtbxid = eval(document.getElementById('txt_executive'))
        txtboxid = "txt_executive";
        if (document.activeElement.id == "txt_executive") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value;
            var executive = document.getElementById('txt_executive').value;
            document.getElementById("div3").style.display = "block";
            document.getElementById('div3').style.top = 366 + "px";
            document.getElementById('div3').style.left = 500 + "px";
            document.getElementById('lstexecutive').focus();
            Reports_AGENCY_MAST.fillF2_Creditexecutive(compcode, executive, bindexecutive_callbackreg);
        }
    }

}
function Clickexecutive_bill(event) {
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstexecutive") {
            if (document.getElementById('lstexecutive').value == "0") {
                alert("Please select Executive Name");
                return false;
            }

            var page = document.getElementById('lstexecutive').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstexecutive').length - 1; k++) {
                if (document.getElementById('lstexecutive').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstexecutive').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstexecutive').options[k].innerText;

                    }
                    document.getElementById('txt_executive').value = abc;

                    document.getElementById('hdnexecode').value = page;

                    document.getElementById('hdnexename').value = abc;

                    document.getElementById("div3").style.display = "none";
                    document.getElementById('txt_executive').focus();
                    return false;

                }
            }
        }
    }
    else if (event.keyCode == 27) {

        document.getElementById("div3").style.display = "none";
        document.getElementById('txt_executive').focus();
    }

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



function forreport() {

  
    var agencycode = document.getElementById('dpagencytype').value;
    var agencycat = "";
    var zone = document.getElementById('dpzone').value;
    var agcd = "";
    var dpcd = "";
    var dest = document.getElementById('drpdestination').value;
    var region = document.getElementById('dpregion').value
    var state = document.getElementById('dpstate').value;
    var unit = document.getElementById('dppubcent').value;
    var branch = document.getElementById('dpbranch').value;
    var dist = document.getElementById('dpdistrict').value;
    var city = document.getElementById('dpcity').value;
    var taluka = "";
    var client = document.getElementById('hdnclntcode').value;
    var exe = document.getElementById('hdnexecode').value;
    var reptype=document.getElementById('drprep').value;
    var zonenm = "";
    if (document.getElementById("dpzone").selectedIndex == -1 || document.getElementById("dpzone").selectedIndex == 0) {
        zonenm = "";
    }
    else {
        zonenm = document.getElementById("dpzone").options[document.getElementById("dpzone").selectedIndex].text;
    }
    var unitnm = "";
   
    unitnm = document.getElementById("dppubcent").options[document.getElementById("dppubcent").selectedIndex].text;
    
    var brnchnm = "";

    brnchnm = document.getElementById("dpbranch").options[document.getElementById("dpbranch").selectedIndex].text;
    Reports_AGENCY_MAST.setSessionmis_run(agencycode, agencycat, zone, agcd, dpcd, dest, region, state, unit, branch, dist, city, taluka, unitnm, brnchnm, zonenm, client,exe,reptype);
    window.open('rpt_agency_mast.aspx');
    return false;

}

function forclick() {
    //$('btnprint').style.display="none";
    document.getElementById('btnprint').style.display = "none";
    window.print();
    return false;

}
