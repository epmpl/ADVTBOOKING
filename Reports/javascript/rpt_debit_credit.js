var divid = "";
var listboxid = "";
var txtboxid = "";
var txtbxid = "";
var browser = navigator.appName;

function compareDates121() {
    var fromDate = document.getElementById('txtfrmdate').value;
    var toDate = document.getElementById('txttodate1').value;

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
            //alert("From Date should be less than To date.");
            //document.getElementById('txtRedemfromdate').focus();
            //return false;
        }

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
  

    //if (document.getElementById('txtpublicentr').value == "0") {
    //    alert('Please Select Publication ')
    //    document.getElementById('txtpublicentr').focus();
    //    return false;
    //}
    //var compcode = document.getElementById('hiddencompcode').value;
    var frdt = document.getElementById('txtfrmdate').value;
    var todt = document.getElementById('txttodate1').value;
    if (document.getElementById('txtpublicentr').value == "0") {
        var pub = "";

    }
    else {
        var pub = document.getElementById('txtpublicentr').value;
    }
    if (document.getElementById('dpbranch').value == "0") {
        var branch = "";
    }
    else {
        var branch = document.getElementById('dpbranch').value;
    }

    //var type1 = document.getElementById('txtpublicentr');
    //var center_name = type1.options[type1.selectedIndex].text;
    var rprttype = document.getElementById('dprpttype').value
    var dest = document.getElementById('dpdestination').value;
    //var dateformat = document.getElementById('hiddendateformat').value;
    //var userid = document.getElementById('hdnuserid').value;
    //var comanyname = document.getElementById('hdncompname').value;

    var extra1 = "";
    var extra2 = "";
    var extra3 = "";
    var extra4 = "";
    var extra5 = "";

    var flagDate = compareDates121();

    if (flagDate == true) {


        Reports_rpt_debit_credit.setSessionmis_run(branch, frdt, todt, pub, dest, rprttype, extra1, extra2, extra3, extra4, extra5)
        window.open('debcresummary_view.aspx');

    }

   // window.open("creditdebitview.aspx?&compcode=" + compcode + "&userid=" + userid + "&dateformat=" + dateformat + "&frdate=" + frdate + "&todate=" + todate + "&publication=" + publication + "&branch=" + branch + "&reporttype=" + reporttype + "&extra1=" + extra1 + "&extra2=" + extra2 + "&extra3=" + extra3 + "&destination=" + destination + "&comanyname=" + comanyname + "&extra4=" + extra4 + "&extra5=" + extra5 + "&center_name=" + center_name, '')
    return false;
}


