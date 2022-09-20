var divid = "";
var listboxid = "";
var txtboxid = "";
var txtbxid = "";
var browser = navigator.appName;



function runreport() {

    if (document.getElementById('txtfrmdate').value == "") {
        alert('Please Select From Date')
        document.getElementById('txtfrmdate').focus();
        return false;
    }
    if (document.getElementById('txttodate1').value == "") {
        alert('Please Select To Date')
        document.getElementById('txttodate1').focus();
        return false;
    }
//    if (document.getElementById('dpbranch').value == "" || document.getElementById('dpbranch').value == "0") {
//        alert('Please Select Branch')
//        document.getElementById('dpbranch').focus();
//        return false;
//    }

    if (document.getElementById('txtpublicentr').value == "0") {
        alert('Please Select Publication ')
        document.getElementById('txtpublicentr').focus();
        return false;
    }
    var compcode = document.getElementById('hiddencompcode').value;
    var frdate = document.getElementById('txtfrmdate').value;
    var todate = document.getElementById('txttodate1').value;
    if (document.getElementById('txtpublicentr').value == "0") {
        var publication = "";
      
    }
    else {
        var publication  = document.getElementById('txtpublicentr').value;
    }
    if (document.getElementById('dpbranch').value == "0") {
        var branch = "";
    }
    else {
        var branch = document.getElementById('dpbranch').value;
    }

    var type1 = document.getElementById('txtpublicentr');
    var center_name = type1.options[type1.selectedIndex].text;
    var reporttype= document.getElementById('dprpttype').value
    var destination = document.getElementById('dpdestination').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var userid = document.getElementById('hdnuserid').value;
    var comanyname = document.getElementById('hdncompname').value;
    var extra3 = "";
    var extra1 = "";
    var extra2 = "";
    var extra4 = "";
    var extra5 = "";

    window.open("creditdebitview.aspx?&compcode=" + compcode + "&userid=" + userid + "&dateformat=" + dateformat + "&frdate=" + frdate + "&todate=" + todate + "&publication=" + publication + "&branch=" + branch + "&reporttype=" + reporttype + "&extra1=" + extra1 + "&extra2=" + extra2 + "&extra3=" + extra3 + "&destination=" + destination + "&comanyname=" + comanyname + "&extra4=" + extra4 + "&extra5=" + extra5 + "&center_name=" + center_name, '')
    return false;
}


