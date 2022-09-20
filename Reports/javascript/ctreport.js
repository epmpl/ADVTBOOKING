// JScript File
var distcode = "";
var browser = navigator.appName;
///////////////////////////////////////////////////

function bindadcat1() {
    var compcode = document.getElementById('hdncompcode').value;
    var adtype1 = document.getElementById('dpdadtype').value;
    report2.adcatbnd(adtype1, compcode, call_adcatbind1);
    //cwreport.adcatbnd(adtype1,compcode,call_adcatbind);
}
function call_adcatbind1(response) {
    ds = response.value;
    var brand = document.getElementById('dpadcatgory');
    brand.options.length = 0;
    brand.options[0] = new Option("--Select Ad Cat--");
    document.getElementById("dpadcatgory").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name, ds.Tables[0].Rows[i].Adv_Cat_Code);
            brand.options.length;
        }
    }

    return false;
}
////////////////////////////Ad subcategory/////////////////////////

function bindsubcat() {
    var compcode = document.getElementById('hdncompcode').value;
    var adcat1 = document.getElementById('dpadcat').value;
    ctreport_main.subcatbind(compcode, adcat1, call_adsubcatbind);

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

function bindsubcat345() {
    var compcode = document.getElementById('hdncompcode').value;
    var adsubcat1 = document.getElementById('dpadsubcat').value;
    ctreport_main.subcat345(adsubcat1, compcode, "", "", call_adsubcat345);
}
function call_adsubcat345(response) {
    ds = response.value;

    var brand = document.getElementById('dpadsubcat3');
    brand.options.length = 0;
    brand.options[0] = new Option("Select AdSubCat2");
    document.getElementById("dpadsubcat3").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].catname, ds.Tables[0].Rows[i].catcode);
            brand.options.length;
        }
    }

    /*var edition=document.getElementById('dpadsubcat4');
        edition.options.length=0;
        edition.options[0]=new Option("Select AdSubCat4");
        document.getElementById("dpadsubcat4").options.length = 1;
        
    
    if(ds.Tables[1].Rows.length>0)
    {
                 for(var i=0; i<ds.Tables[1].Rows.length; i++)
                 {
                    edition.options[edition.options.length] = new Option(ds.Tables[1].Rows[i].Cat_Name,ds.Tables[1].Rows[i].Cat_Code);
                    edition.options.length;    
                 }
     }
                 
         var agency=document.getElementById('dpadsubcat5');
        agency.options.length=0;
        agency.options[0]=new Option("Select AdSubCat5");
        document.getElementById("dpadsubcat5").options.length = 1;
        
    
    if(ds.Tables[2].Rows.length>0)
    {
                 for(var i=0; i<ds.Tables[2].Rows.length; i++)
                 {
                     agency.options[agency.options.length] = new Option(ds.Tables[2].Rows[i].Cat_Name,ds.Tables[2].Rows[i].Cat_Code);
                    agency.options.length;    
                 }
     }   */

    return false;
}
///////////////////////////////////Ad category////////////////
function bindadcat() {
    var compcode = document.getElementById('hdncompcode').value;
    var adtype1 = document.getElementById('dpadtype').value;
    ctreport_main.adcatbnd(adtype1, compcode, call_adcatbind);
    //billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
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

function blankfields() {
    $('Txtdest').disabled = false;

}


///////////////////////function chkrun()////////////////////////////////////////////////

function chkrun() {



    if (document.getElementById('txtfromdate').value == "") {
        alert("Please Enter From Date");
        document.getElementById('txtfromdate').focus();
        return false;
    }

    if (document.getElementById('txtdistrict').value != "") {
        if (document.getElementById('hidden_dist').value == "") {
            alert("Please select district by F2");
            document.getElementById('txtfromdate').focus();
            return false;
        }
    }



    if (document.getElementById('txttodate').value == "") {
        alert("Please Enter To Date");
        document.getElementById('txttodate').focus();
        return false;
    }
    //if(document.getElementById('dpprintcenter').value=="Select Printing Center" || document.getElementById('dpprintcenter').value=="")
    //  {
    //      alert("Please select printing center");
    //      document.getElementById('dpprintcenter').focus();
    //      return false;
    //  }
    var puserid = document.getElementById('hiddenuseid').value
    var from_date = document.getElementById('txtfromdate').value
    var todate = document.getElementById('txttodate').value
    // var unitcode=document.getElementById('hdnunitcode').value

    //var userid=document.getElementById('hiddenuseid').value
    //
    var adcat_type = document.getElementById('dpadtype').value
    var des_adty1 = document.getElementById('dpadtype').options.selectedIndex;
    if (des_adty1 != -1) document.getElementById('hiddpadtype').value = document.getElementById('dpadtype').options[des_adty1].text;
    var ad_type = document.getElementById('hiddpadtype').value
    ///

    var adcat_code1 = trim(document.getElementById('dpadcat').value)
    var des_adcat1 = document.getElementById('dpadcat').options.selectedIndex;
    if (des_adcat1 != -1) document.getElementById('hdnadcat').value = document.getElementById('dpadcat').options[des_adcat1].text;
    var ad_cat = trim(document.getElementById('hdnadcat').value)
    //
    var adsubcat_code = trim(document.getElementById('dpadsubcat').value)
    var des_adcat2 = document.getElementById('dpadsubcat').options.selectedIndex;
    if (des_adcat2 != -1) document.getElementById('hdnadsubcat').value = document.getElementById('dpadsubcat').options[des_adcat2].text;
    var ad_subcat = trim(document.getElementById('hdnadsubcat').value)
    //
    var adsubcat3_code = document.getElementById('dpadsubcat3').value
    var des_adcat3 = document.getElementById('dpadsubcat3').options.selectedIndex;
    if (des_adcat3 != -1) document.getElementById('hdnadsubcat3').value = document.getElementById('dpadsubcat3').options[des_adcat3].text;
    var ad_subcat3 = document.getElementById('hdnadsubcat3').value
    ////
    //var adsubcat4_code=document.getElementById('adsubcat4').value
    //		 var des_pub14=document.getElementById('adsubcat4').options.selectedIndex;
    //        if(des_pub14!=-1)document.getElementById('hdnadsubcat4').value=document.getElementById('adsubcat4').options[des_pub14].text;        
    //		var ad_subcat4=document.getElementById('hdnadsubcat4').value
    //		//
    //		//var adsubcat5_code=document.getElementById('adsubcat5').value
    //		 var des_pub15=document.getElementById('adsubcat5').options.selectedIndex;
    //        if(des_pub15!=-1)document.getElementById('hdnadsubcat5').value=document.getElementById('adsubcat5').options[des_pub15].text;        
    //		var ad_subcat5=document.getElementById('hdnadsubcat5').value
    //
    var branch_code = document.getElementById('dpbranch').value
    var des_branch = document.getElementById('dpbranch').options.selectedIndex;
    if (des_branch != -1) document.getElementById('hdnbranch').value = document.getElementById('dpbranch').options[des_branch].text;
    var branch_name = document.getElementById('hdnbranch').value

    var teamcode = document.getElementById('dpteam').value
    var des_team = document.getElementById('dpteam').options.selectedIndex;
    if (des_team != -1) document.getElementById('hdnteam').value = document.getElementById('dpteam').options[des_team].text;
    var teamname = document.getElementById('hdnteam').value

    var execcode = document.getElementById('dpexec').value
    var des_execcode = document.getElementById('dpexec').options.selectedIndex;
    if (des_execcode != -1) document.getElementById('hiddenexecutivename').value = document.getElementById('dpexec').options[des_execcode].text;
    var execname = document.getElementById('hiddenexecutivename').value

    var pubcode = document.getElementById('dppub1').value
    var des_pubcode = document.getElementById('dppub1').options.selectedIndex;
    if (des_pubcode != -1) document.getElementById('hiddenpubname').value = document.getElementById('dppub1').options[des_pubcode].text;
    var pubname = document.getElementById('hiddenpubname').value

    var edicode = document.getElementById('dpedition').value
    var des_edicode = document.getElementById('dpedition').options.selectedIndex;
    if (des_edicode != -1) document.getElementById('hiddenediname').value = document.getElementById('dpedition').options[des_edicode].text;
    var ediname = document.getElementById('hiddenediname').value

    var district_code = document.getElementById('hidden_dist').value

    var district_name = distcode;

    var printcenter_code = "";//document.getElementById('dpprintcenter').value
    var des_printcent = "";//document.getElementById('dpprintcenter').options.selectedIndex;
    //if(des_printcent!=-1)document.getElementById('hdnprintcenter').value=document.getElementById('dpprintcenter').options[des_printcent].text;        
    var printcenter_name = "";//document.getElementById('hdnprintcenter').value
    //
    var destination_code = document.getElementById('Txtdest').value
    var reptype = document.getElementById('drpreptype').value
    //var destination=document.getElementById('Txtdest').value
    //var des_destination=document.getElementById('Txtdest').options.selectedIndex;
    //if(des_destination!=-1)document.getElementById('hdnTxtdest').value=document.getElementById('Txtdest').options[des_destination].text;        
    //var destination_name=document.getElementById('hdnTxtdest').value
    //var destination=document.getElementById('destination').value
    //
    window.open("ctreport_view.aspx?fromdate=" + from_date + "&destination_code=" + destination_code + "&puserid=" + puserid + "&edicode=" + edicode + "&pubcode=" + pubcode + "&ediname=" + ediname + "&pubname=" + pubname + "&teamname=" + teamname + "&execcode=" + execcode + "&execname=" + execname + "&teamcode=" + teamcode + "&Todate=" + todate + "&des_adty1=" + adcat_type + "&des_adcat1=" + adcat_code1 + "&des_adcat2=" + adsubcat_code + "&des_adcat3=" + adsubcat3_code + "&des_branch=" + branch_code + "&branch_name=" + branch_name + "&des_district=" + district_code + "&district_name=" + district_name + "&des_printcent=" + printcenter_code + "&printcenter_name=" + printcenter_name + "&reptype=" + reptype);

    return false;
}



function formexit() {
    if (confirm("Do you want to skip this page")) {
        window.close();
    }
    return false;
}

///////////////////////////////////District///////////////////////////////

function F2filldistrict(event) {

    var key = event.keyCode ? event.keyCode : event.which;

    //if(key!=113)
    //if( key!=8 )
    //{
    //alert("Press [F2]")
    //return false;
    //}
    if (key == 113) {

        if (document.activeElement.id == "txtdistrict") {
            var distnam = document.getElementById('txtdistrict').value;
            var compcode = document.getElementById('hdncompcode').value;
            var uid = document.getElementById('hiddenuseid').value.toUpperCase();
            document.getElementById("divdistrict").style.display = "block";
            document.getElementById('divdistrict').style.top = 250 + "px";
            document.getElementById('divdistrict').style.left = 500 + "px";
            document.getElementById('lstdistrict').focus();
            ctreport_main.fillF2_Creditexecutive(compcode, uid, distnam, F2filldistrict_callback);
            // return false;
        }

    }
    if (key == 8 || key == 46) {
        document.getElementById('txtdistrict').value = "";
    }

}
function F2filldistrict_callback(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstdistrict");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select District-", "0");
        pkgitem.options.length = 1;
        for (var i = 0  ; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Dist_Name + "`" + ds_AccName.Tables[0].Rows[i].Dist_Code, ds_AccName.Tables[0].Rows[i].Dist_Code);
            pkgitem.options.length;
        }
    }

    var aTag = eval(document.getElementById('txtdistrict'))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById('divdistrict').scrollLeft;
    var scrolltop = document.getElementById('divdistrict').scrollTop;
    document.getElementById('divdistrict').style.left = document.getElementById('txtdistrict').offsetLeft + leftpos - tot + "px";
    document.getElementById('divdistrict').style.top = document.getElementById('txtdistrict').offsetTop + toppos - scrolltop + "px"; //"510px";



    document.getElementById("lstdistrict").value = "0";
    document.getElementById("divdistrict").value = "";
    document.getElementById('lstdistrict').focus();

    return false;

}




function Clickdistrict(event) {

    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstdistrict") {
            if (document.getElementById('lstdistrict').value == "0") {
                alert("Please select District");
                return false;
            }

            var page = document.getElementById('lstdistrict').value;
            agencycode = page;

            for (var k = 0; k <= document.getElementById('lstdistrict').length - 1; k++) {
                if (document.getElementById('lstdistrict').options[k].value == page) {
                    //var abc=document.getElementById('lstdistrict').options[k].innerText;
                    var abc;
                    if (browser != "Microsoft Internet Explorer") {
                        abc = document.getElementById('lstdistrict').options[k].innerHTML;
                    }
                    else {
                        abc = document.getElementById('lstdistrict').options[k].innerText;
                    }

                    var splitpub = abc;
                    var str = splitpub.split("`");
                    abc = str[0];
                    abc1 = str[1];
                    distcode = abc;
                    document.getElementById('txtdistrict').value = abc;
                    document.getElementById('hidden_dist_text').value = abc
                    document.getElementById('hidden_dist').value = page;
                    document.getElementById("divdistrict").style.display = "none";
                    ass = "";
                    xyz1 = "";

                    document.getElementById('txtdistrict').focus();
                    return false;

                }
            }




        }
    }
    else if (key == 27) {

        document.getElementById("divdistrict").style.display = "none";
        document.getElementById('txtdistrict').value = "";
        document.getElementById('txtdistrict').focus();
    }


}
////////////////////////////////////////////
function deviation_f2() {
    var newstr = "";
    var newstr1 = "";
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
    loadXML('xml/disschreg.xml');

    var abc = document.getElementById('txttodate1').value
    var abc1 = document.getElementById('txtfrmdate').value
    var alrt;

    alrt = document.getElementById('lbDateFrom').innerText;
    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txtfrmdate').value == "") {
            var abc = alrt.replace("*", "");
            alert('Please Enter ' + abc);
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    }

    alrt = document.getElementById('lbToDate').innerText;
    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txttodate1').value == "") {
            var abc = alrt.replace("*", "");
            alert('Please Enter ' + abc);
            document.getElementById('txttodate1').focus();
            return false;

        }
    }

}
function eventcalling(event) {

    if (event.keyCode == 97)
        event.keyCode = 65;
    if (event.keyCode == 98)
        event.keyCode = 66;
    if (event.keyCode == 99)
        event.keyCode = 67;
    if (event.keyCode == 100)
        event.keyCode = 68;
    if (event.keyCode == 101)
        event.keyCode = 69;
    if (event.keyCode == 102)
        event.keyCode = 70;
    if (event.keyCode == 103)
        event.keyCode = 71;
    if (event.keyCode == 104)
        event.keyCode = 72;
    if (event.keyCode == 105)
        event.keyCode = 73;
    if (event.keyCode == 106)
        event.keyCode = 74;
    if (event.keyCode == 107)
        event.keyCode = 75;
    if (event.keyCode == 108)
        event.keyCode = 76;
    if (event.keyCode == 109)
        event.keyCode = 77;
    if (event.keyCode == 110)
        event.keyCode = 78;
    if (event.keyCode == 111)
        event.keyCode = 79;
    if (event.keyCode == 112)
        event.keyCode = 80;
    //if(event.keyCode==113) 
    //    event.keyCode= 81;
    if (event.keyCode == 114)
        event.keyCode = 82;
    if (event.keyCode == 115)
        event.keyCode = 83;
    if (event.keyCode == 116)
        event.keyCode = 84;
    if (event.keyCode == 117)
        event.keyCode = 85;
    if (event.keyCode == 118)
        event.keyCode = 86;
    if (event.keyCode == 119)
        event.keyCode = 87;
    if (event.keyCode == 120)
        event.keyCode = 88;
    if (event.keyCode == 121)
        event.keyCode = 89;
    if (event.keyCode == 122)
        event.keyCode = 90;
}


function compareDates() {
    var fromDate = document.getElementById('txtfromdate').value;
    var toDate = document.getElementById('txttodate').value;
    var splitChar = "";
    if (fromDate.indexOf("/") >= 0) {
        splitChar = "/";
    }
    else if (fromDate.indexOf("-") >= 0) {
        splitChar = "-";
    }
    else if (fromDate.indexOf(".") >= 0) {
        splitChar = ".";
    }

    var fromDateArray = fromDate.split(splitChar);
    var toDateArray = toDate.split(splitChar);
    if (document.getElementById('hiddendateformat').value = "dd/mm/yyyy") {
        var from_day = parseInt(fromDateArray[0], 10);
        var from_month = parseInt(fromDateArray[1], 10);
        var from_year = parseInt(fromDateArray[2], 10);

        var to_day = parseInt(toDateArray[0], 10);
        var to_month = parseInt(toDateArray[1], 10);
        var to_year = parseInt(toDateArray[2], 10);
    }
    else if (document.getElementById('hiddendateformat').value = "mm/dd/yyyy") {
        var from_day = parseInt(fromDateArray[1], 10);
        var from_month = parseInt(fromDateArray[0], 10);
        var from_year = parseInt(fromDateArray[2], 10);

        var to_day = parseInt(toDateArray[1], 10);
        var to_month = parseInt(toDateArray[0], 10);
        var to_year = parseInt(toDateArray[2], 10);

    }
    else if (document.getElementById('hiddendateformat').value = "yyyy/mm/dd") {
        var from_day = parseInt(fromDateArray[2], 10);
        var from_month = parseInt(fromDateArray[1], 10);
        var from_year = parseInt(fromDateArray[0], 10);

        var to_day = parseInt(toDateArray[2], 10);
        var to_month = parseInt(toDateArray[1], 10);
        var to_year = parseInt(toDateArray[0], 10);

    }
    if (to_year > from_year) {
        return true;
    }
    else {
        if (to_year == from_year && to_month > from_month) {
            return true;
        }
        else if (to_year == from_year && to_month == from_month && to_day >= from_day) {
            return true;

        }
        else {
            alert("From Date should be less than To date.");
            document.getElementById('txtfromdate').focus();
            return false;
        }

    }

}


function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}
function forclick() {
    //$('btnprint').style.display="none";
    document.getElementById('btnprint').style.display = "none";
    window.print();
    return false;

}
/////////////////////////////////////////executive////////////////

function bind_team_exe() {
    var comp_code = document.getElementById('hiddencompcode').value;
    var team = document.getElementById('dpteam').value;
    var userid = document.getElementById('hiddenuserid').value;


    ctreport_main.exe_bind(comp_code, userid, team, call_bind_team_exe);

}
function bind_exe_represen() {
    var comp_code = document.getElementById('hiddencompcode').value;
    var team = document.getElementById('dpteam').value;
    var userid = document.getElementById('hiddenuserid').value;


    ctreport_main.exe_bind(comp_code, userid, team, call_bind_team_exe);

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

function keySort1(dropdownlist, caseSensitive) {
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

//////////////////edition/////////////////


function bind_edition5() {
    var comp_code = document.getElementById('hiddencompcode').value;
    var pub_cent = document.getElementById('dpprintcenter').value;
    var publication = document.getElementById('dppub1').value;

    ctreport_main.edition_bind(publication, pub_cent, comp_code, call_bind_edition);
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



function tabvaluectrepo(event) {
    var key = event.keyCode ? event.keyCode : event.which;

    //alert(id)
    if (key == 13) {
        //if(document.activeElement.id==id)
        //{
        //    if(document.getElementById('btnSave').disabled==false)
        //    {
        //document.getElementById('btnSave').focus();
        //    }
        //return;

        //}
        //else 
        if (document.activeElement.type == "button" || document.activeElement.type == "submit") {
            event.keyCode = 13;
            return event.keyCode;

        }
        else {
            //alert(event.keyCode);
            event.keyCode = 9;
            //alert(event.keyCode);
            return event.keyCode;
        }
    }

    if (key == 116) {

        //window.close();
        //alert("avi")
        window.open('ctreport_main.aspx', '_self', '', false)
        return false;
        //window.open("ctreport_main.aspx");
    }



}