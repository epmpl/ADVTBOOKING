
function bindedtn() {
    var compcode = document.getElementById('hiddencompcode').value;
    var publcod = document.getElementById('dppub1').value
    var dateformat = document.getElementById('hiddendateformat').value
    var extra1 = "";
    var extra2 = "";
    Reports_issuebillreport.bindedtn(compcode, publcod, dateformat, extra1, extra2, bindedtion)
}

function bindedtion(res) {
    var ds = res.value;

    var edition = document.getElementById('ddledtn');
    edition.options.length = 0;
    edition.options[0] = new Option("-Select Edition-");
    document.getElementById("ddledtn").options.length = 1;

    if (ds != null && ds.Tables.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias, ds.Tables[0].Rows[i].edition_code);
            edition.options.length;
        }
    }

    return false
}

/*
function suppbind() {

    var compcode = document.getElementById('hdncompcode').value;
    var edition = document.getElementById('dpedition').value;
    Reports_issuebillreport.bindsupp(compcode, edition, call_suppbind);
}
function call_suppbind(response) {
    ds = response.value;
    var edition = document.getElementById('dpsuppliment');
    edition.options.length = 0;
    edition.options[0] = new Option("Select Supplement");
    document.getElementById("dpsuppliment").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name, ds.Tables[0].Rows[i].Supp_Code);
            edition.options.length;
        }
    }

    return false;

}*/


function suppbind()
{

var compcode=document.getElementById('hiddencompcode').value;
var edition=document.getElementById('ddledtn').value;
Reports_issuebillreport.bindsupp(compcode,edition,call_suppbind);
}

function call_suppbind(response)
{
ds= response.value;
    var edition=document.getElementById('dpsuppliment');
    edition.options.length=0;
    edition.options[0]=new Option("Select Supplement");
    document.getElementById("dpsuppliment").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
                edition.options.length;    
             }
 }         
 
       return false;

}

function forreport()
{
if(document.getElementById('txtfrmdate').value=="")
    {
    alert("Please Enter From Date!")
    document.getElementById('txtfrmdate').focus();
    return false;
    }    
    var ab = isDateaa_enter(document.getElementById('txtfrmdate').value, 'txtfrmdate', document.getElementById('hiddendateformat'), document.getElementById('HDN_server_date').value);
         if (ab == "valfalse") {
             document.getElementById('txtfrmdate').focus();
             return false;
         }
         
         if(document.getElementById('txttodate1').value=="")
    {
    alert("Please Enter To Date!")
    document.getElementById('txttodate1').focus();
    return false;
    }    
    var ab = isDateaa_enter(document.getElementById('txttodate1').value, 'txttodate1', document.getElementById('hiddendateformat'), document.getElementById('HDN_server_date').value);
         if (ab == "valfalse") {
             document.getElementById('txttodate1').focus();
             return false;
         }
    

var compcode=document.getElementById('hiddencompcode').value;
var printcent=document.getElementById('Drppubcent').value;
if(document.getElementById('Drppubcent').value != "")
{
var ind1=document.getElementById("Drppubcent").selectedIndex;
if (ind1 != -1) {
var printcentname = document.getElementById("Drppubcent").options[ind1].text; //pindex.options[pindex.selectedIndex].text;
 }
 else {
 var printcentname = "";
 }
}
var edition=document.getElementById('ddledtn').value;
if(document.getElementById('ddledtn').value!="")
{
var ind3=document.getElementById("ddledtn").selectedIndex;
if (ind3 != -1) {
var edinname = document.getElementById("ddledtn").options[ind3].text; //pindex.options[pindex.selectedIndex].text;
 }
 else {
 var edinname = "";
 }
}
var fromdate=document.getElementById('txtfrmdate').value;
var todate=document.getElementById('txttodate1').value;
var dateformat=document.getElementById('hiddendateformat').value;
var userid=document.getElementById('hiddenuserid').value;
var chk_access=document.getElementById('chk_access').value;
var publ_name=document.getElementById('dppub1').value;
if(document.getElementById('dppub1').value!="0")
{
var ind2=document.getElementById("dppub1").selectedIndex;
if (ind2 != -1) {
var publicationname = document.getElementById("dppub1").options[ind2].text; //pindex.options[pindex.selectedIndex].text;
 }
 else {
 var publicationname = "";
 }
}
var district_name=document.getElementById('ddldistrict').value;
if(document.getElementById('ddldistrict').value!="0")
{
var ind4=document.getElementById("ddldistrict").selectedIndex;
if (ind4 != -1) {
var distname = document.getElementById("ddldistrict").options[ind4].text; //pindex.options[pindex.selectedIndex].text;
 }
 else {
 var distname = "";
 }
}
var supl_name=document.getElementById('dpsuppliment').value;
if(document.getElementById('dpsuppliment').value!="")
{
var ind5=document.getElementById("dpsuppliment").selectedIndex;
if (ind5 != -1) {
var supnname = document.getElementById("dpsuppliment").options[ind5].text; //pindex.options[pindex.selectedIndex].text;
 }
 else {
 var supnname = "";
 }
}
var ratio_type="";
var extra1="";
var extra2="";
var branch=document.getElementById('branch').value;
//var branchname=document.getElementById('branchname').value;
var destination=document.getElementById('Txtdest').value;
window.open("issue_billwise_rpt.aspx?compcode=" + compcode + "&printcent=" + printcent + "&edition=" + edition + "&fromdate=" + fromdate + "&todate=" + todate + "&dateformat=" + dateformat + "&userid=" + userid + "&chk_access=" + chk_access + "&ratio_type=" + ratio_type + "&extra1=" + extra1 + "&extra2=" + extra2 + "&destination=" + destination + "&publ_name=" + publ_name + "&district_name=" + district_name + "&branch=" + branch + "&printcentname=" + printcentname + "&publicationname=" + publicationname + "&edinname=" + edinname + "&distname=" + distname + "&supnname=" + supnname + "&supl_name=" + supl_name);
return false;
}

function blankfields()
{
document.getElementById('txtfrmdate').value="";
document.getElementById('txttodate1').value="";
document.getElementById('Drppubcent').value="";
document.getElementById('dppub1').value="0";
document.getElementById('ddledtn').value="";
document.getElementById('ddldistrict').value="0";
document.getElementById('Txtdest').value="0";
document.getElementById('dpsuppliment').value="";
document.getElementById('txtfrmdate').focus();
return false;
}

function chkfld(event)
{
var browser = navigator.appName;
if (browser != "Microsoft Internet Explorer")
    {
    var key=event.which;   
    }
    else
    {
    var key=event.keyCode;
    }
    
    if(key==13)
    {
    if(document.activeElement.id=="btnRun")
    {
    forreport();
    return false;
    }
    if(document.activeElement.id=="txtfrmdate")
    {
    if(document.getElementById('txtfrmdate').value=="")
    {
    alert("Please Enter From Date!")
    document.getElementById('txtfrmdate').focus();
    return false;
    }
    else
    {
    var ab = isDateaa_enter(document.getElementById('txtfrmdate').value, 'txtfrmdate', document.getElementById('hiddendateformat'), document.getElementById('HDN_server_date').value);
         if (ab == "valfalse") {
             document.getElementById('txtfrmdate').focus();
             return false;
         }
         else
         {
    document.getElementById('txttodate1').focus();
    return false;
    }
    }
    }
    
    if(document.activeElement.id=="txttodate1")
    {
    if(document.getElementById('txttodate1').value=="")
    {
    alert("Please Enter To Date!")
    document.getElementById('txttodate1').focus();
    return false;
    }
    else
    {
    var ab = isDateaa_enter(document.getElementById('txttodate1').value, 'txttodate1', document.getElementById('hiddendateformat'), document.getElementById('HDN_server_date').value);
         if (ab == "valfalse") {
             document.getElementById('txttodate1').focus();
             return false;
         }
         else
         {
    document.getElementById('Drppubcent').focus();
    return false;
    }
    }
    }
    
    if(document.activeElement.id=="Drppubcent")
    {
    document.getElementById('dppub1').focus();
    return false;
    }
    
    if(document.activeElement.id=="dppub1")
    {
    document.getElementById('ddledtn').focus();
    return false;
    }
    
    if(document.activeElement.id=="ddledtn")
    {
    document.getElementById('dpsuppliment').focus();
    return false;
    }
    
    if(document.activeElement.id=="dpsuppliment")
    {
    document.getElementById('ddldistrict').focus();
    return false;
    }
    
    if(document.activeElement.id=="ddldistrict")
    {
    document.getElementById('Txtdest').focus();
    return false;
    }
    
    if(document.activeElement.id=="Txtdest")
    {
    document.getElementById('btnRun').focus();
    return false;
    }
    
    return false;
    }
    
    
//return false;
}


var dtCh= "/";
var minYear=1900;
var maxYear=2100;

function isDateaa_enter(dtStr, txtid, dateformat, hiddenvalue) {

    if (document.getElementById(txtid).value == "") {
        document.getElementById(txtid).value = "";
    }


    else {

        if (document.getElementById(dateformat.id).value == "mm/dd/yyyy") {

            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strMonth = dtStr.substring(0, pos1);
            var strDay = dtStr.substring(pos1 + 1, pos2);
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
                chk_user_flag = "true"
                document.getElementById(txtid).value = "";
                document.getElementById(txtid).focus();

                return "valfalse";
            }
        }


        else if ((document.getElementById(dateformat.id).value == "dd/mm/yyyy")) {
            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strDay = dtStr.substring(0, pos1);
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
                chk_user_flag = "true"
                document.getElementById(txtid).value = "";
                document.getElementById(txtid).focus();
                return "valfalse";
            }

        }



        else {

            var daysInMonth = DaysArray(12);
            var pos1 = dtStr.indexOf(dtCh);
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1);
            var strYear = dtStr.substring(0, pos1);
            var strMonth = dtStr.substring(pos1 + 1, pos2);
            var strDay = dtStr.substring(pos2 + 1);
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
                chk_user_flag = "true"
                document.getElementById(txtid).value = "";
                document.getElementById(txtid).focus();
                return "valfalse";
            }
            else {
                chk_user_flag = "False"
            }
        }




        if (strMonth.length < 1 || month < 1 || month > 12) {
            alert("Please enter a valid month")
            chk_user_flag = "true"
            document.getElementById(txtid).value = "";
            document.getElementById(txtid).focus();
            return "valfalse";
        }
        else {
            chk_user_flag = "False"
        }

        if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
            alert("Please enter a valid day")
            chk_user_flag = "true"
            document.getElementById(txtid).value = "";
            document.getElementById(txtid).focus();
            return "valfalse";
        }
        else {
            chk_user_flag = "False"
        }


        if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
            alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear)
            chk_user_flag = "true"
            document.getElementById(txtid).value = "";
            document.getElementById(txtid).focus();
            return "valfalse";
        }
        else {
            chk_user_flag = "False"
        }


        if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
            alert("Please enter a valid date")
            chk_user_flag = "true"
            document.getElementById(txtid).value = "";
            document.getElementById(txtid).focus();
            return "valfalse";
        }
        else {
            chk_user_flag = "False"
        }


    }
    //	if(chk_user_flag=="False")
    //	{
    //	   if(Date.parse(dtStr)<Date.parse(hiddenvalue))
    //	    {
    //	        alert('Please select date greater then today date');
    //	        $(txtid).value=""
    //	        $(txtid).focus();
    //	        
    //	        chk_user_flag="False"
    //	    }
    //	}
    if (txtid == "txtPVTodate") {
        chkdate11();
    }

    else if (txtid == "txttilldate") {
        chkdate12();
    }



}

function daysInFebruary(year) {
    // February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
}
function DaysArray(n) {
    for (var i = 1; i <= n; i++) {
        this[i] = 31
        if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
        if (i == 2) { this[i] = 29 }
    }
    return this
}

var dtCh = "/";
var minYear = 1900;
var maxYear = 2100;
var chk_user_flag = "False"
function isInteger(s) {
    var i;
    for (i = 0; i < s.length; i++) {
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

function stripCharsInBag(s, bag) {
    var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}