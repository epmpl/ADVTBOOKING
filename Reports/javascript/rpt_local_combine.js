var browser = navigator.appName;
var dsmain = "";
var total_records = 0;
var trntype = "";
var ptmp_type = "";
var next = 0;
var count = 0;
var count1 = 0;

function clear_onload() {
    document.getElementById('txtfromdate').value = "";
    document.getElementById('txttodate').value = "";
    document.getElementById('dpd_branch').value = "0";
    document.getElementById('dppub1').value = "0";
    document.getElementById('drpdest').value = "1";
    document.getElementById('drprprttype').value = "0";
    document.getElementById('drpratetype').value = "0";
   

    return false;

}

function exitclick() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
        return false;
    }
    return false;
}


function compareDates121() {
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
            //alert("From Date should be less than To date.");
            //document.getElementById('txtRedemfromdate').focus();
            //return false;
        }

    }

}
function fndnull(val) {
    if (val == 0 || val == "0" || val == undefined || val == "undefined" || val == "")
        val = null;
    return val;
}


function getreport() {
    if (document.getElementById('txtfromdate').value == "") {
        alert("Please Fill From Date.")
        document.getElementById('txtfromdate').focus();
        return false;
    }
    if (document.getElementById('txttodate').value == "") {
        alert("Please Fill To Date.")
        document.getElementById('txttodate').focus();
        return false;
    }
    //if (document.getElementById('drprprttype').value == "") {
    //    alert("Please Select Report Type")
    //    document.getElementById('drprprttype').focus();
    //    return false;
    //}
    //if (document.getElementById('drpratetype').value == "") {
    //    alert("Please Select Rate Type")
    //    document.getElementById('drpratetype').focus();
    //    return false;
    //}
    //if (document.getElementById('drpdest').value == "") {
    //    alert("Please Select Destination")
    //    document.getElementById('drpdest').focus();
    //    return false;
    //}

  

    var frdt = document.getElementById('txtfromdate').value;
    var todt = document.getElementById('txttodate').value;
    //alert(fndnull(document.getElementById('dpd_branch').value))
   
        var branch = (document.getElementById('dpd_branch').value);
    var pub = document.getElementById('dppub1').value;
    
    var dest = document.getElementById('drpdest').value;
    var rprttype = document.getElementById('drprprttype').value;
    var ratetype = document.getElementById('drpratetype').value;
    //var branchname = document.getElementById('dpd_branch').options[document.getElementById('dpd_branch').selectedIndex].text;
    //var pubname = document.getElementById('dppub1').options[document.getElementById('dppub1').selectedIndex].text;


    var extra1 = "";
    var extra2 = "";
    var extra3 = "";
    var extra4 = "";
    var extra5 = "";

    var flagDate = compareDates121();

    if (flagDate == true) {


        Reports_rpt_local_combine.setSessionmis_run(branch, frdt, todt, pub, dest, rprttype, ratetype, extra1, extra2, extra3, extra4, extra5)
        window.open('localcombineview.aspx');

    }
    return false;

}
