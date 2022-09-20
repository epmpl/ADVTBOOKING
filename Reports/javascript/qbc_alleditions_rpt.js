var browser = navigator.appName;
var dsmain = "";
var total_records = 0;
var trntype = "";
var ptmp_type = "";
var next = 0;
var count = 0;
var count1 = 0;
var jq = jQuery.noConflict();

window.onload = function () {
    OnLoadFrom();
    return false;
}
function OnLoadFrom() {
    trntype = ""; next = 0; total_records = 0; count = 0;
    ptmp_type = ""; trn_unk_id = "";

    jq('#txtcomp_name').attr("disabled", true);
    jq('#txtcomp_code').attr("disabled", true);
    jq('#txt_unit').attr("disabled", false);
    jq('#txt_unitcode').attr("disabled", true);
    jq('#txtbranch').attr("disabled", false);
    jq('#txtbranch_code').attr("disabled", true);
    jq('#txtfromdate').attr("disabled", false);
    jq('#txttodate').attr("disabled", false);
    jq('#txtdest').attr("disabled", false);
    jq('#drpdatetype').attr("disabled", false);
    jq('#drpyeartyp').attr("disabled", false);
   
    jq('#txt_unit').val('');
    jq('#txt_unitcode').val('');
    jq('#txtbranch').val('');
    jq('#txtbranch_code').val('');
    jq('#txtfromdate').val('');
    jq('#txttodate').val('');
    jq('#txtdest').val('');
    jq('#drpdatetype').val('');
    jq('#drpyeartyp').val('');
    

    ////for current date 
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    var day1 = '01';
    var today = dd + '/' + mm + '/' + yyyy;
    var firstdate = day1 + '/' + mm + '/' + yyyy;
    
    document.getElementById('txt_unit').focus();
    return false;
}

function exitclick() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
        return false;
    }
    return false;
}

function fillunit(event) {
    if (jq("#divunit").css("display") == "none") {
        var key = event.keyCode ? event.keyCode : event.which;

        if (key == 40) {
            if (jq('#lstunit').disabled != true) {
                jq('#lstunit').val = "0";
                jq('#lstunit').focus();
                return false;
            }
        }
        if (key == 27) {
            jq('#lstunit').val = "";
            //document.getElementById('hdnpublication').value="";
            jq('#lstunit').focus();
            jq('#divunit').css("display", "none");
            return false;
        }
        if (key == 8) {
            jq('#lstunit').val = "";
            document.getElementById('hdnpublication').value = "";
            document.getElementById('txt_unit').value = "";
            document.getElementById('txt_unitcode').value = "";
            jq('#lstunit').focus();
            jq('#divunit').css("display", "none");
            return false;
        }
        if (key == 13) {
            return false;
        }
        if (key == 113) {
            offset(document.activeElement.id, "divunit", "lstunit");
            var compcode = jq('#hdncomp_code').val()
            var userid = jq('#hdnuserid').val()
            var dateformate = jq('#hdndateformat').val()

            //var unit = document.getElementById('hdnunitcode').value;
            var extra1 = jq('#txt_unit').val()
            var extra2 = "";
            var extra3 = "";
            var extra4 = "";
            var extra5 = "";
            document.getElementById('lstunit').focus();
            Reports_qbc_alleditions_rpt.fill_unit(compcode, extra1, userid, extra1, extra2, extra3, extra4, extra5, bindpub_callback)
        }
    }
    else {
        var key = event.keyCode ? event.keyCode : event.which;
        if (key == 1) {
            jq('#divunit').hide("slow");
            jq('#txt_unit').focus();
        }
    }
}

function onclickunit(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (jq('#lstunit').val() == "") {
            alert("Please Fill Unit Name By [F2]");
            return false;
        }
        var page = jq('#lstunit').val();
        if (page != null) {
            var str = page.split("~");
            jq('#txt_unit').val(str[0])
            jq('#txt_unitcode').val(str[1])
            document.getElementById('hdnpublication').value = str[1];
            jq('#divunit').css("display", "none");
            jq('#txt_unit').focus();
            return false;
        }
    }
    else if (keycode == 27) {
        jq('#divunit').css("display", "none");
        jq('#txt_unit').focus();
    }
}
function bindpub_callback(res) {
    var ds = res.value;
    var pkgitem = document.getElementById('lstunit')
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("---Select Unit---", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].center + "~" + ds.Tables[0].Rows[i].Pub_cent_Code, ds.Tables[0].Rows[i].center + "~" + ds.Tables[0].Rows[i].Pub_cent_Code);
            pkgitem.options.length;
        }
    }
    else {
        pkgitem.options[0] = new Option("---There is no data accourding your search---", "");
        return false;
    }
    jq('#lstunit').focus();
    return false;
}


function fillbrn(event) {
    if (jq("#divbrn").css("display") == "none") {
        var key = event.keyCode ? event.keyCode : event.which;

        if (key == 40) {
            if (jq('#lstbrn').disabled != true) {
                jq('#lstbrn').val = "0";
                jq('#lstbrn').focus();
                return false;
            }
        }
        if (key == 27) {
            jq('#lstunit').val = "";
            //document.getElementById('hdnpublication').value="";
            jq('#lstbrn').focus();
            jq('#divbrn').css("display", "none");
            return false;
        }
        if (key == 8) {
            jq('#lstbrn').val = "";
            document.getElementById('txtbranch_code').value = "";
            document.getElementById('txtbranch').value = "";

            jq('#lstbrn').focus();
            jq('#divbrn').css("display", "none");
            return false;
        }
        if (key == 13) {
            return false;
        }
        if (key == 113) {
            offset(document.activeElement.id, "divbrn", "lstbrn");
            var compcode = jq('#hdncomp_code').val()
            var userid = jq('#hdnuserid').val()
            var dateformate = jq('#hdndateformat').val()

            var unit = document.getElementById('txt_unitcode').value;
            unit = "NA0";
            if (unit == "") {

                alert("Please select Unit bye F2 first!!!!")
                return false;
            }
            var extra1 = jq('#txtbranch').val()
            var extra2 = "";
            document.getElementById('lstbrn').focus();

            Reports_qbc_alleditions_rpt.bind_branch(userid, unit, extra1, bindbrn_callback)
        }
    }
    else {
        var key = event.keyCode ? event.keyCode : event.which;
        if (key == 1) {
            jq('#divbrn').hide("slow");
            jq('#txtbranch').focus();
        }
    }
}

function onclickbrn(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (jq('#lstunit').val() == "") {
            alert("Please Fill Branch Name By [F2]");
            return false;
        }
        var page = jq('#lstbrn').val();
        if (page != null) {
            var str = page.split("~");
            jq('#txtbranch').val(str[0])
            jq('#txtbranch_code').val(str[1])
            document.getElementById('hdnpublication').value = str[1];
            jq('#divbrn').css("display", "none");
            jq('#txtbranch').focus();
            return false;
        }
    }
    else if (keycode == 27) {
        jq('#divbrn').css("display", "none");
        jq('#txtbranch').focus();
    }
}

function bindbrn_callback(res) {
    var ds = res.value;
    var pkgitem = document.getElementById('lstbrn')
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("---Select Branch---", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name + "~" + ds.Tables[0].Rows[i].Branch_Code, ds.Tables[0].Rows[i].Branch_Name + "~" + ds.Tables[0].Rows[i].Branch_Code);
            pkgitem.options.length;
        }
    }
    else {
        pkgitem.options[0] = new Option("---There is no data accourding your search---", "");
        return false;
    }
    jq('#lstbrn').focus();
    return false;
}

function compareDates121() {
    var fromDate = document.getElementById('txtfromdate').value;
    var toDate  = document.getElementById('txttodate').value;

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
            document.getElementById('txtRedemfromdate').focus();
            return false;
        }

    }

}
function getreport() {
        if(document.getElementById('txtfromdate').value=="")
        {
        alert("Please Fill From Date.")
        document.getElementById('txtfromdate').focus();
        return false;
        }
         if(document.getElementById('txttodate').value=="")
        {
        alert("Please Fill To Date.")
        document.getElementById('txttodate').focus();
        return false;
        }
        if(document.getElementById('drpdatetype').value=="0")
        {
        alert("Please Select Date Based On.")
        document.getElementById('drpdatetype').focus();
        return false;
        }
        if(document.getElementById('drpyeartyp').value=="0")
        {
        alert("Please Select Year Based On.")
        document.getElementById('drpyeartyp').focus();
        return false;
        }
        if(document.getElementById('txtdest').value=="0")
        {
        alert("Please Select Destination.")
        document.getElementById('txtdest').focus();
        return false;
        }
        var compcode            = document.getElementById('txtcomp_code').value;
        var unitcode            = document.getElementById('txt_unitcode').value;
        var brancode            = document.getElementById('txtbranch_code').value;
        var frdt                = document.getElementById('txtfromdate').value;
        var todt                = document.getElementById('txttodate').value;
        var dest                = document.getElementById('txtdest').value;
        var date_basedon        = document.getElementById('drpdatetype').value;
        var year_basedon        = document.getElementById('drpyeartyp').value;
        var userid              = document.getElementById('hdnuserid').value;
        var dateformat          = document.getElementById('hiddendateformat').value;
        var extra1              = document.getElementById('drp_year_month').value;
        var extra2              = "";
        var extra3              = "";
        var extra4              = "";
        var extra5 = dest;
       
    var flagDate = compareDates121();

    if (flagDate == true) {

       

            window.open("qbc_alleditions_rpt_view.aspx?compcode=" + compcode + "&unitcode=" + unitcode + "&brancode=" + brancode + "&frdt=" + frdt + "&todt=" + todt + "&date_basedon=" + date_basedon + "&year_basedon=" + year_basedon + "&userid=" + userid + "&dateformat=" + dateformat + "&extra1=" + extra1 + "&extra2=" + extra2 + "&extra3=" + extra3 + "&extra4=" + extra4 + "&extra5=" + extra5, '');
       
    }
    return false;

}