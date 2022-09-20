//Javascript
var str;
var glo_cat2 = 0;
var browser = navigator.appName;
//var browserversion = msieversion();
function fillAdCat2() {
    //dan
    var strtextd = "";
    var httpRequest = null;
    httpRequest = new XMLHttpRequest();
    if (httpRequest.overrideMimeType) {
        httpRequest.overrideMimeType('text/xml');
    }
    //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

    httpRequest.open("GET", "checksessiondan.aspx", false);
    httpRequest.send('');
    //alert(httpRequest.readyState);
    if (httpRequest.readyState == 4) {
        //alert(httpRequest.status);
        if (httpRequest.status == 200) {
            strtextd = httpRequest.responseText;
        }
        else {
            //alert('There was a problem with the request.');
            if (browser != "Microsoft Internet Explorer") {
                //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
            }
        }
    }
    if (strtextd != "sess") {
        alert('session expired');
        window.location.href = "Default.aspx";
        return false;
    }
    var compcode = document.getElementById("hiddencompcode").value;
    ProofReading.fillCat2(document.getElementById('drpadvcatcode').value, compcode, fillCat2_callback);

}
function fillCat2_callback(response) {
    var ds = response.value;
    var pkgitem = document.getElementById("drpadvsubcatcode");
    pkgitem.options.length = 1;
    pkgitem.options[0] = new Option("--Select Sub Category--", "0");


    if (ds != null) {
        // fillAdCat1();    //alert(pkgitem.options.length);
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name, ds.Tables[0].Rows[i].Adv_Subcat_Code);

            pkgitem.options.length;
        }
        document.getElementById("drpadvsubcatcode").value = glo_cat2;
        glo_cat2 = 0;
    }

    return false;
}
function btnSubmit2() {  // document.getElementById('DataGrid2').style.display="block";
    if (document.getElementById('txtFromDate').value == "") {
        alert("Please Select From Date ");
        document.getElementById('txtFromDate').focus();
        // document.getElementById('DataGrid2').style.display="none";
        return false;
    }
    if (document.getElementById('txtToDate').value == "") {
        alert("Please Select To Date ");
        document.getElementById('txtToDate').focus();
        // document.getElementById('DataGrid2').style.display="none";
        return false;
    }

    if (document.getElementById('dpd_printcent').value == "0") {
        alert("Please Select Printing Center ");
        document.getElementById('dpd_printcent').focus();
        // document.getElementById('DataGrid2').style.display="none";
        return false;
    }









    if (document.getElementById('drpfilter').value == "0") {
        alert("Please Select Filter ");
        document.getElementById('drpfilter').focus();
        // document.getElementById('DataGrid2').style.display="none";
        return false;
    }
    //chk date=====//
    var fromdate = document.getElementById('txtFromDate').value;
    var todate = document.getElementById('txtToDate').value;

    if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
        var startdateC = fromdate.split("/")[1] + '/' + fromdate.split("/")[0] + '/' + fromdate.split("/")[2];
        var enddateC = todate.split("/")[1] + '/' + todate.split("/")[0] + '/' + todate.split("/")[2];
    }
    else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd") {
        var startdateC = fromdate.split("/")[1] + '/' + fromdate.split("/")[2] + '/' + fromdate.split("/")[0];
        var enddateC = todate.split("/")[1] + '/' + todate.split("/")[2] + '/' + todate.split("/")[0];
    }
    else if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
        var startdateC = document.getElementById("txtdate").value;
        var enddateC = document.getElementById("txtaddate").value;
    }
    var ftdate = new Date(startdateC);
    var eddate = new Date(enddateC);
    if (eddate < ftdate) {
        alert("To Date must be greater than From Date ");
        document.getElementById('txtToDate').focus();
        return false;
    }
}
function selectAll() {
    if (document.getElementById("checkall").checked == true) {
        for (var k = 0; k < document.getElementById("DataGrid2").rows.length - 1; k++) {
            var chkid = "chk" + k;
            if (document.getElementById(chkid).disabled == false)
                document.getElementById(chkid).checked = true;
        }
    }
    else {
        for (var k = 0; k < document.getElementById("DataGrid2").rows.length - 1; k++) {
            var chkid = "chk" + k;
            document.getElementById(chkid).checked = false;
        }
    }
}
function openprev(res, res1, res2, val, packagecode, multifilename) {
    var str = document.getElementById("DataGrid2");
    //var win;
    var agencycode;
    bookid = res;
    agencycode = res1;
    filename = multifilename;


    var compcode = document.getElementById("hiddencompcode").value;
    var frmdate = document.getElementById('txtFromDate').value;
    var todate = document.getElementById('txtToDate').value;
    var cat = document.getElementById('drpadvcatcode').value;
    var filter = document.getElementById('drpfilter').value;
    var cat2 = document.getElementById('hiddencat2').value;
    var bookingtype = document.getElementById('drpbooktyp').value;
    var InsertionType = document.getElementById('InsertionType').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var userid = document.getElementById('usercode').value;

    /* comment by lokmat client no need 
  
    if (res2.length ==1)
    {
    alert("Firstly Upload Material from Transaction then do the Proof Reading");
    return false;
    }
    else{
    */
    var win = window.open('editorproofread.aspx?val=' + val + '&bookid=' + bookid + "&agencycode=" + agencycode + "&filename=" + filename + "&compcode=" + compcode + "&frmdate=" + frmdate + "&todate=" + todate + "&cat=" + cat + "&filter=" + filter + "&cat2=" + cat2 + "&bookingtype=" + bookingtype + "&InsertionType=" + InsertionType + "&dateformat=" + dateformat + "&userid=" + userid + "&packagecode=" + packagecode, '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
    //window.open('editorproofread.aspx?booking=' + bookid + '&rono=' + bookid);
    //win=(window.open('editorproofread.aspx?val='+val,'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes'));
    //  win.focus();
    return false;
    //}
}
function proofFirstLevel() {
    if (document.getElementById("DataGrid2") == null)
        return false;
    str = document.getElementById("DataGrid2");
    var booking_id = "";
    var flag = false;
    for (var i = 0; i < document.getElementById("DataGrid2").rows.length - 1; i++) {
        var chkid = "chk" + i;
        booking_id = "";
        if (document.getElementById(chkid).checked == true) {
            var arr = document.getElementById(chkid).value.split("~");
            booking_id = arr[0].toString();
            //var filename = arr[1].toString();
            //ProofReading.proofad(booking_id,filename);                       

            document.getElementById(chkid).disabled = true;
            document.getElementById(chkid).checked = true;

            flag = true;

        }
    }
    if (flag == false)
        alert("Select Any atleast 1 checkbox");
    else

    //alert("Proof Successfully");

        return;
}
function prevclick() {
    if (document.getElementById("DataGrid2") == null)
        return false;
    str = document.getElementById("DataGrid2");
    var booking_id = "";
    var flag = false;
    for (var i = 0; i < document.getElementById("DataGrid2").rows.length - 1; i++) {
        var chkid = "chk" + i;
        booking_id = "";
        if (document.getElementById(chkid).checked == true) {
            var arr = document.getElementById(chkid).value.split("~");
            booking_id = arr[0].toString();
            var filename = arr[1].toString();
            if (filename == "") {
                alert("Please Update Matter");
                document.getElementById(chkid).checked = false;

                return false
            }


            var username = document.getElementById("hdnusername").value;
            ProofReading.proofad(booking_id, filename, document.getElementById("hiddenprtype").value, username);
            document.getElementById(chkid).disabled = true;
            document.getElementById(chkid).checked = false;
            // chk_booking_id=booking_id;
            flag = true;
        }
    }
    if (flag == false)
        alert("Select Any atleast 1 checkbox");
    else

        if (document.getElementById("hiddenprtype").value !== "agencyroaudit") {
            alert("Proof Successfully");
        }
        else {
            alert("Audit Sucsessfully");
        }
    //return false;    
}
function fillcat() {
    document.getElementById('hiddencat2').value = document.getElementById('drpadvsubcatcode').value;
}
function exitclick() {
    //if(confirm("Do You Want To Skip This Page"))
    //{
    window.close();
    return false;
    //}
    //return false;
}

function datepack(res) {
    var str = document.getElementById("DataGrid2");
    p_bkid = res;
    var compcode = document.getElementById("hiddencompcode").value;
    var frmdate = document.getElementById('txtFromDate').value;
    var todate = document.getElementById('txtToDate').value;
    var cat = document.getElementById('drpadvcatcode').value;
    var filter = document.getElementById('drpfilter').value;
    var cat2 = document.getElementById('hiddencat2').value;
    var bookingtype = document.getElementById('drpbooktyp').value;
    var InsertionType = document.getElementById('InsertionType').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var userid = document.getElementById('hiddenuserid').value;

    var cioid = res;

    var pextra1 = "";
    var pextra2 = "";
    var pextra3 = "";
    var pextra4 = "";
    var pextra5 = "";
    if (document.getElementById('hiddenprtype').value == "agencyroaudit") {

        win = window.open('QBC.aspx?prcioid=' + cioid + '&userid=', '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
        return false;
    }



    var res = ProofReading.datepack(frmdate, todate, cat, filter, compcode, dateformat, cat2, InsertionType, bookingtype, p_bkid, pextra1, pextra2, pextra3, pextra4, pextra5, userid, binddate);


}
function binddate(res) {
    var ds = res.value;
    var tbl = "";
    document.getElementById('dvmainpackage').style.display = "block";
    document.getElementById('dvdate').innerHTML = "";
    //if (ds.Tables[1].Rows.Count > 0)
    //{
    tbl = "<table  border='1' cellpadding='0px' cellspacing='0px'><tr>";
    tbl += "<td class='middleproffnew' colspan='2'>Package Name</td><td class='middleproffnew' colspan='2'>Date</td></tr>";
    for (var i = 0; i < ds.Tables[1].Rows.length; i++) {
        tbl += "<tr>";
        tbl += "<td  class='rep_datapro' colspan='2'>" + ds.Tables[1].Rows[i].Package_Name + "</td><td  class='rep_datapro' colspan='2' align='center'>" + ds.Tables[1].Rows[i].Insert_Date + "</td></tr>";
    }
    tbl += "</table>";
    document.getElementById('dvdate').innerHTML = tbl.toString();
    //}
    return false;

}
function cancelpack() {
    document.getElementById('dvmainpackage').style.display = "none";

}
function binduser(event) {
    //  if(document.activeElement.id=="drpuserid")
    //  {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 27) {
        if (document.activeElement.id == "lst_user") {
            document.getElementById('div1').style.display = "none";

        }
    }
    //    if (key == 13) {
    //        if (document.activeElement.id == "lstmaingrp") {
    //            fillmaingrp(event);
    //        }

    //    }
    if ((key == 8) || (key == 46)) {
        // document.getElementById('txtrole').value = "";
        document.getElementById('usercode').value = "";
        document.getElementById('drpuserid').value = "";
        // document.getElementById('listbox2').options.length = 0; 
    }

    if (key == 113) {
        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        var userhome = document.getElementById('hiddenuserhome').value;
        var revenue = document.getElementById('hiddenrevenue').value;
        var admin = document.getElementById('hiddenadmin').value;
        var username = document.getElementById('drpuserid').value;
        document.getElementById("div1").style.display = "block";
        document.getElementById('div1').style.top = findPos(document.getElementById("drpuserid"), "top");
        document.getElementById('div1').style.left = findPos(document.getElementById("drpuserid"), "left");
        document.getElementById('lst_user').value = "0";
        document.getElementById('lst_user').focus();

        var res = ProofReading.UserBind(compcode, userid, userhome, revenue, admin, username);
        var ds = res.value;
        if (ds != null && ds.Tables[0].Rows.length > 0) {
            var pkgitem = document.getElementById("lst_user");
            pkgitem.options.length = 0;
            pkgitem.options[0] = new Option("-Select user-", "0");
            pkgitem.options.length = 1;
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username + "--" + ds.Tables[0].Rows[i].userid + "--" + fndnull(ds.Tables[0].Rows[i].ROLE_NAME), ds.Tables[0].Rows[i].userid);
                pkgitem.options.length;
            }
        }
        //  }
    }

    //  return false;
}

function findPos(obj, val) {
    var curleft = curtop = 0;

    if (obj.offsetParent) {
        curleft = obj.offsetLeft

        curtop = obj.offsetTop

        while (obj = obj.offsetParent) {
            curleft += obj.offsetLeft

            curtop += obj.offsetTop

        }

    }
    curtop = curtop += 5;
    if (val == "top")
        return curtop + "px";
    else
        return curleft + "px";
}

function filluser(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (document.activeElement.id == "lst_user") {
            if (document.getElementById('lst_user').value == "0") {
                alert("Please select user");
                return false;
            }
            document.getElementById("div1").style.display = "none";
            var page = document.getElementById('lst_user').value;
            loccode = page;

            for (var k = 0; k <= document.getElementById("lst_user").length - 1; k++) {
                if (document.getElementById('lst_user').options[k].value == page) {
                    if (browser == "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lst_user').options[k].innerText;
                    }
                    else {
                        var abc = document.getElementById('lst_user').options[k].textContent;
                    }
                    var fival = abc.split("--");
                    document.getElementById('usercode').value = fival[1];
                    document.getElementById('drpuserid').value = fival[0];
                    //document.getElementById('txtrole').value=fival[2];
                    //  document.getElementById('txtrole').disabled=true;
                    document.getElementById('drpuserid').focus();
                    break;
                }
            }
        }
    }



    if (keycode == 27) {

        document.getElementById("div1").style.display = "none";

    }
}

function fndnull(myval) {
    if (myval == "undefined") {
        myval = "";
    }
    else if (myval == null) {
        myval = "";
    }
    return myval
}


/////////////add by anuja

//function pubdetail() {
//    if (document.getElementById("DataGrid2") == null)
//        return false;
//    str = document.getElementById("DataGrid2");
//    var booking_id = "";
//    var rono = "";
//    var comcode = document.getElementById("hiddencompcode").value;
//    var flag = false;
//    for (var i = 0; i < document.getElementById("DataGrid2").rows.length - 1; i++) {
//        var chkid = "chkpub" + i;
//        booking_id = "";
//        if (document.getElementById(chkid).checked == true) {
//            var arr = document.getElementById(chkid).value.split("~");
//            booking_id = arr[0].toString();
//            rono = arr[1].toString();
//            flag = true;

//            window.open('proofrepubdetail.aspx?booking=' + booking_id + '&rono=' + rono);
//            return false;
//        }
//    }
//    if (flag == false)
//        alert("Select Any atleast 1 checkbox");
//    else

//    //alert("Proof Successfully");

//        return;
//}