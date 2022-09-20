function bind_edition5() {
    var comp_code = document.getElementById('hiddencompcode').value;
    var publication = document.getElementById('dppub1').value;

    Reports_Ad_bussiness_target.edition_bind(publication, comp_code, call_bind_edition);
}


function call_bind_edition(response) {
    ds = response.value;
    var edition = document.getElementById('drpedition');
    edition.options.length = 0;
    edition.options[0] = new Option("--Select Edition Name--");
    document.getElementById("drpedition").options.length = 1;
    if (ds != null && ds.Tables.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias, ds.Tables[0].Rows[i].edition_code);
            edition.options.length;
        }

    }
    return false
}

/*function binduom() 
{
if (document.getElementById("drpadtype").value != "" && document.getElementById("drpadtype").value != "0") {
var skillsSelect = document.getElementById("drpadtype");
var adtype = skillsSelect.options[skillsSelect.selectedIndex].text;
var copcode = document.getElementById('hiddencompcode').value;
var userid = document.getElementById('hdnuserid').value;
Reports_Ad_bussiness_target.bind_uom(copcode, userid, adtype, call_bind_uom);
return false
}
else 
{
var edition = document.getElementById('drpuom');
edition.options.length = 0;
edition.options[0] = new Option("--Select Uom Name--");
document.getElementById("drpuom").options.length = 1;
return false

}
return false
}
function call_bind_uom(response) {

ds = response.value;
var edition = document.getElementById('drpuom');
edition.options.length = 0;
edition.options[0] = new Option("--Select Uom Name--");
document.getElementById("drpuom").options.length = 1;
if (ds != null && ds.Tables.length > 0) {
for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Uom_Name, ds.Tables[0].Rows[i].Uom_Code);
edition.options.length;
}

}
return false
}*/

function F2fillagencycr_allagency(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "dpagency") {
            var compcode = document.getElementById('hiddencompcode').value;
            var agn = document.getElementById('dpagency').value;
            document.getElementById("div1").style.display = "block";
            document.getElementById('div1').style.top = 215 + "px"; //314//290
            document.getElementById('div1').style.left = 580 + "px"; //395//1004
            document.getElementById('lstagency').focus();
            Reports_Ad_bussiness_target.fillF2_CreditAgency(compcode, agn, bindAgency_callback1);
        }
    }
    else if (((key == 8) || (key == 46)) || (event.ctrlKey == true && key == 88)) {

        if (document.activeElement.id == "dpagency") {
            document.getElementById('dpagency').value = "";
            document.getElementById('hdnagency1').value = "";
            return false;
        }
        return key;
    }
}
function bindAgency_callback1(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency Type Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Type_Name, ds_AccName.Tables[0].Rows[i].Agency_Type_Code);
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

    return false;

}

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
                    //document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hdnagency1').value = abc;

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

    if (document.getElementById('dppub1').value == "0" || document.getElementById('dppub1').value == "") {
        alert('Please Select Publication')
        document.getElementById('dppub1').focus();
        return false;
    }


    var chkaccess = "";
    var compcode = document.getElementById('hiddencompcode').value;
    var datefrom = document.getElementById('txtfrmdate').value;
    var todate = document.getElementById('txttodate1').value;
    var publication = document.getElementById('dppub1').value;
    var edition = document.getElementById('drpedition').value;
    var adtype = document.getElementById('drpadtype').value;
    //    var uom = document.getElementById('drpuom').value;
    var uom_multi = "";
    var sel = document.getElementById("drpuom");
    var listLength = sel.options.length;
    for (var i = 1; i < listLength; i++) {
        if (document.getElementById("drpuom").options[i].selected == true) {
            uom_multi = uom_multi + document.getElementById("drpuom").options[i].value + ",";
        }

    }
    var uom = uom_multi.slice(0, -1);
    var paymade = document.getElementById('drppaymode').value;
    var basedon = document.getElementById('drpbasedon').value;
    var destination = document.getElementById('drpdestination').value;

    if (document.getElementById('rdoexecutive').checked == true) {
        chkaccess = "E";
    }
    else if (document.getElementById('rdoagencywise').checked == true) {
        chkaccess = "A";
    }
    else if (document.getElementById('rdouomwise').checked == true) {
        chkaccess = "U";
    }
    else if (document.getElementById('rdosupplinentwise').checked == true) {
        chkaccess = "S";
    }
    var dateformat = document.getElementById('hiddendateformat').value;
    var userid = document.getElementById('hdnuserid').value;
    var agencycode = document.getElementById('hdnagency1').value;
    var extra1 = "";
    var extra2 = "";

    window.open("Ad_bussiness_target_view.aspx?&compcode=" + compcode + "&userid=" + userid + "&dateformat=" + dateformat + "&datefrom=" + datefrom + "&todate=" + todate + "&publication=" + publication + "&edition=" + edition + "&adtype=" + adtype + "&uom=" + uom + "&paymade=" + paymade + "&extra1=" + extra1 + "&extra2=" + extra2 + "&basedon=" + basedon + "&destination=" + destination + "&agencycode=" + agencycode + "&chkaccess=" + chkaccess, '')
    return false;
}

function clear_onload() {
    document.getElementById('txtfrmdate').value = "";
    document.getElementById('txttodate1').value = "";
    document.getElementById('dppub1').value = "0";
    document.getElementById('drpedition').value = "";
    document.getElementById('drpadtype').value = "";
    document.getElementById('drpuom').value = "";
    document.getElementById('drppaymode').value = "0";
    document.getElementById('drpbasedon').value = "0";
    document.getElementById('drpdestination').value = "1";
    document.getElementById('hdnagency1').value = "";
    return false;
}




/******************************Date validation*******************/

var dtCh = "/";
var minYear = 1900;
var maxYear = 2100;
function ValidateForm(event, id) {
    var dt = $(id).value;
    if (isDate12(dt, id) == false) {
        $(id).focus();
        return false;
    }
    else {
        if (document.getElementById('txtfrmdate').value != "") {
            var frmdate = document.getElementById('txtfrmdate').value;
            var dateformat = document.getElementById('hiddendateformat').value;

            Reports_Ad_bussiness_target.getlastday(frmdate, dateformat, call_bind_lastday);
            return true;
        }
        return true;
    }
}


function isDate12(dtStr, id) {

    if ($(id).value == "" || $(id).value == $('hiddendateformat').value) {
        $(id).value = "";
    }


    else {

        if ($('hiddendateformat').value == "mm/dd/yyyy") {

            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strMonth = dtStr.substring(0, pos1);
            var strDay = dtStr.substring(pos1 + 1, pos2);
            if (strDay != "26") {
                alert('Please select only date 26th  of this month');
                $(id).value = "";
                $(id).focus();
                return false;
            }
            var strYear = dtStr.substring(pos2 + 1);
            strYr = strYear;
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            month = parseInt(strMonth);
            day = parseInt(strDay);
            year = parseInt(strYr);
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : mm/dd/yyyy")
                $(id).value = "";
                $(id).focus();
                return false;
            }
        }


        else if (($('hiddendateformat').value == "dd/mm/yyyy")) {
            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strDay = dtStr.substring(0, pos1);
            if (strDay != "26") {
                alert('Please select only date 26th  of this month');
                $(id).value = "";
                $(id).focus();
                return false;
            }
            var strMonth = dtStr.substring(pos1 + 1, pos2);
            var strYear = dtStr.substring(pos2 + 1);
            strYr = strYear;
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            day = parseInt(strDay);
            month = parseInt(strMonth);
            year = parseInt(strYr);
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : dd/mm/yyyy")
                $(id).value = "";
                $(id).focus();
                return false;
            }

        }
        else {
            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strYear = dtStr.substring(0, pos1);
            var strMonth = dtStr.substring(pos1 + 1, pos2);
            var strDay = dtStr.substring(pos2 + 1);
            if (strDay != "26") {
                alert('Please select only date 26th  of this month');
                $(id).value = "";
                $(id).focus();
                return false;
            }
            strYr = strYear;
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            day = parseInt(strDay);
            month = parseInt(strMonth);
            year = parseInt(strYr);
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : yyyy/mm/dd")
                $(id).value = "";
                $(id).focus();
                return false;
            }
        }
        if (strMonth.length < 1 || month < 1 || month > 12) {
            alert("Please enter a valid month")
            $(id).focus();
            return false;
        }
        if (strDay.length < 1 || day < 1 || day > 31 || day > daysInMonth[month]) {
            alert("Please enter a valid day")
            $(id).focus();
            return false;
        }

        if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
            alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear)
            $(id).focus();
            return false;
        }
        if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
            alert("Please enter a valid date")
            $(id).focus();
            return false;
        }
    }

}

function isInteger(s) {
    var i;
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    return true;
}

function stripCharsInBag(s, bag) {
    var i;
    var returnString = "";
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}


function DaysArray(n) {
    for (var i = 1; i <= n; i++) {
        this[i] = 31
        if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
        if (i == 2) { this[i] = 29 }
    }
    return this
}



function call_bind_lastday(res) {
    var ds = res.value;
    for (var i = 0; i <= ds.Tables[0].Rows.length - 1; i++) {

        document.getElementById('txttodate1').value = CHKDATE(ds.Tables[0].Rows[i].LASTDAY);
    }
    return false;
}

var chkdtforupdt = "";
var dateconvert;
function CHKDATE(userdate) {
    var mycondate = ""
    if (userdate == null || userdate == "") {
        mycondate = ""
        userdate = "";
        return mycondate
    }
    else {
        var dateformate = document.getElementById('hiddendateformat').value;
        if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
            var spmonth = "'" + userdate + "'";
            var pp = spmonth.split(" ");
            var mon = pp[1];
            var myDate = new Date(userdate);
            var date = myDate.getDate();

            if (date == 1 || date == 2 || date == 3 || date == 4 || date == 5 || date == 6 || date == 7 || date == 8 || date == 9)
                date = "0" + date;
            var month = myDate.getMonth() + 1;
            if (month == 1 || month == 2 || month == 3 || month == 4 || month == 5 || month == 6 || month == 7 || month == 8 || month == 9)
                month = "0" + month;
            var year = myDate.getFullYear();
            mycondate = date + "/" + month + "/" + year;
            dateconvert = mycondate;
            return mycondate;
        }
        else if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
            var spmonth = "'" + userdate + "'";
            var pp = spmonth.split(" ");
            var mon = pp[1];
            var myDate = new Date(userdate);
            var date = myDate.getDate();
            var month = myDate.getMonth() + 1;
            var year = myDate.getFullYear();
            mycondate = month + "/" + date + "/" + year;
            dateconvert = mycondate;
            return mycondate;
        }
        else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd") {
            var spmonth = "'" + userdate + "'";
            var pp = spmonth.split(" ");
            var mon = pp[1];
            var myDate = new Date(userdate);
            var date = myDate.getDate();
            var month = myDate.getMonth() + 1;
            var year = myDate.getFullYear();
            mycondate = year + "/" + month + "/" + date;
            dateconvert = mycondate;
            return mycondate;
        }
    }
}


function enabledisable(id) {

    if (id == "rdoagencywise") {
        document.getElementById('dpagency').disabled = false;
        document.getElementById('rdoagencywise').checked = true;

    }
    else {
        document.getElementById('dpagency').disabled = true;
        document.getElementById(id).checked = true;

    }


}