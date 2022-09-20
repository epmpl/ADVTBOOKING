var cate;
function filladcat() {
    var comcode = document.getElementById('hiddencompcode').value;
    var adtype = document.getElementById('drpadtype').value;
    var center = "";
    eyecater_report.adcat(comcode, adtype, center, callcount);
    return false;
}

function callcount(res) {
    var ds = res.value;

    var pkgitem = document.getElementById("drpcatg");
    if (ds.Tables[0].Rows.length == 0) {
        pkgitem.options.length = 1;
        pkgitem.options[0] = new Option("--Select Category--", "0");
        alert("Matching Value Not Found");
        return false;
    }
    pkgitem.options.length = 1;
    pkgitem.options[0] = new Option("--Select Category--", "0");
    for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Adv_Cat_Name, res.value.Tables[0].Rows[i].Adv_Cat_Code);
        pkgitem.options.length;
    }

    if (cate == undefined || cate == "") {
        document.getElementById('drpcatg').value = "0";

    }
    else {
        document.getElementById('drpcatg').value = cate;
        cate = "";
    }
   
}


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
    if (document.getElementById('drbranch').value == "" || document.getElementById('drbranch').value == "0") {
        alert('Please Select Reporttype')
        document.getElementById('drbranch').focus();
        return false;
    }
    if (document.getElementById('drpreportfor').value == "" || document.getElementById('drpreportfor').value == "0") {
        alert('Please Select Reportfor')
        document.getElementById('drpreportfor').focus();
        return false;
    }
    if (document.getElementById('drbranch').value == "B") {
    if(document.getElementById('drpcenter').value=="" ||document.getElementById('drpcenter').value=="0")
    {
        alert('Please select Center');
        document.getElementById('drpcenter').focus();
    return false;
    }
    }
    var compcode = document.getElementById('hiddencompcode').value;
    var frdate = document.getElementById('txtfrmdate').value;
    var todate = document.getElementById('txttodate1').value;
    if (document.getElementById('drpcenter').value == "0") {
        var unit = "";
    }
    else {
        var unit = document.getElementById('drpcenter').value;
    }
    if (document.getElementById('drpbrn').value == "0") {
        var branch = "";
    }
    else {
        var branch = document.getElementById('drpbrn').value;
    }
    if (document.getElementById('drpadtype').value == "0") {
        var adtype = "";
    }
    else {
        var adtype = document.getElementById('drpadtype').value;
    }
    if (document.getElementById('dpuom').value == "0") {
        var uom = "";
    }
    else {
        var uom = document.getElementById('dpuom').value;
    }
    if (document.getElementById('drpeyecat').value == "0") {
        var bullet = "";
    }
    else {
        var bullet = document.getElementById('drpeyecat').value;
    }
    if (document.getElementById('drpcatg').value == "0") {
        var catg = "";
    }
    else {
        var catg = document.getElementById('drpcatg').value;
    }
    if (document.getElementById('drbranch').value == "0") {
        var reporttype = "";
    }
    else {
        var reporttype = document.getElementById('drbranch').value;
    }
    if (document.getElementById('drpreportfor').value == "0") {
        var reportfor = "";
    }
    else {
        var reportfor = document.getElementById('drpreportfor').value;
    }
    var destination = document.getElementById('drpdestination').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var userid = document.getElementById('hdnuserid').value;
    var comanyname = document.getElementById('hdncompname').value;
    var extra3 = "";
    var extra1 = document.getElementById("drpratecode").value;// ratecode
    var extra2 = "";
    var extra4 = "";
    var extra5 = "";
  
    window.open("eyecatherview_report.aspx?&compcode=" + compcode + "&userid=" + userid + "&dateformat=" + dateformat + "&frdate=" + frdate + "&todate=" + todate + "&unit=" + unit + "&branch=" + branch + "&adtype=" + adtype + "&uom=" + uom + "&bullet=" + bullet + "&catg=" + catg + "&reporttype=" + reporttype + "&reportfor=" + reportfor + "&extra1=" + extra1 + "&extra2=" + extra2 + "&extra3=" + extra3 + "&destination=" + destination + "&comanyname=" + comanyname + "&extra4=" + extra4 + "&extra5=" + extra5, '')
    return false;
}


function clear_onload() {
    document.getElementById('txtfrmdate').value = "";
    document.getElementById('txttodate1').value = "";
    document.getElementById('drpadtype').value = "0";
    document.getElementById('drpcatg').value = "0";
    document.getElementById('dpuom').value = "0";
    document.getElementById('drpcenter').value = "0";
    document.getElementById('drbranch').value = "0";
    document.getElementById('drpeyecat').value = "0";
    document.getElementById('drpreportfor').value = "1"; 
    return false;
}


