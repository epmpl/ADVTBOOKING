<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Agent_master.aspx.cs" EnableEventValidation ="false"  Inherits="Agent_master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking &amp; Sheduling Agency Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		
		

		<style type="text/css">
		    .style3
		    {
		        width: 129px;
		    }

		    .style4
		    {
		        height: 18px;
		        width: 114px;
		    }

		    .style5
		    {
		        height: 19px;
		        width: 129px;
		    }

		    .style6
		    {
		        height: 17px;
		        width: 129px;
		    }

		    .style7
		    {
		        height: 21px;
		        width: 129px;
		    }

		    .style8
		    {
		        height: 18px;
		        width: 129px;
		    }

		    .style9
		    {
		        height: 18px;
		        width: 549px;
		    }

		    .style10
		    {
		        width: 549px;
		    }

		    .style11
		    {
		        height: 19px;
		        width: 549px;
		    }

		    .style12
		    {
		        height: 17px;
		        width: 549px;
		    }
		</style>
		
	
		<script type="text/javascript" language="JavaScript1.2">




		    /*
            Auto Maximize Window Script- By Nick Lowe (nicklowe@ukonline.co.uk)
            */

		    top.window.moveTo(0, 0);
		    if (document.all) {
		        top.window.resizeTo(screen.availWidth, screen.availHeight);
		    }
		    else if (document.layers || document.getElementById) {
		        if (top.window.outerHeight < screen.availHeight || top.window.outerWidth < screen.availWidth) {
		            top.window.outerHeight = screen.availHeight;
		            top.window.outerWidth = screen.availWidth;
		        }
		    }

</script>
		
		
		
		<script type="text/javascript"  language="javascript">




		    function special_character(event) {

		        var charCode = (event.which) ? event.which : event.keyCode
		        if (charCode == 47 || charCode == 64 || charCode == 35 || charCode == 38 || charCode == 94 || charCode == 37 || charCode == 44 || charCode == 45 || charCode == 95 || (charCode == 31 || charCode == 38) || (charCode == 40 || charCode == 41 || charCode == 46 || charCode == 45) || (charCode == 8) || (charCode >= 97 && charCode <= 122) || (charCode >= 65 && charCode <= 90))
		            return true;
		        else
		            return false;

		    }

		    if (navigator.appName.indexOf("Microsoft") != -1) {
		        document.writeln('<LINK href ="css/main.css" type= "text/css" rel = "stylesheet">');
		    }
		    else {
		        document.writeln('<LINK href ="css/main_mozilla.css" type= "text/css" rel = "stylesheet">');

		    }



		    //		function agencyclientdate()
		    //		{
		    //		 if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11)||(event.keyCode==9))
		    //	{
		    //		
		    //		return true;
		    //	}
		    //	else
		    //	{
		    //		return false;
		    //	}
		    //	



		    function logout() {
		        window.location.href = 'logout.aspx';
		        return false;
		    }
		    function home() {
		        window.location.href = 'EnterPage.aspx';
		        return false;

		    }

		    function abcabc() {
		        window.location.href = 'agent_master.aspx';
		        return false;
		    }



		    function abc1212() {
		        window.location.href = 'module_detail.aspx';
		        return false;
		    }
		    function abc123123() {
		        window.location.href = 'date.aspx';
		        return false;
		    }

		    function ClientSpecial(event) {
		        var browser = navigator.appName;
		        if (browser != "Microsoft Internet Explorer") {
		            if ((event.which >= 48 && event.which <= 57) || (event.which == 8) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || (event.which == 9 || event.which == 32) || (event.which >= 65 && event.which <= 90)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		        else {
		            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		    }


		    function checkagency() {

		        var a = document.getElementById('txtagencode').value;


		        var abc = document.getElementById('txtagencode').value.length - 1;


		        if (parseInt(abc) > 0) {
		            if (a.substring(0, 1) == "%" && a.substring(parseInt(abc)) == "%") {
		                //alert("true");
		                return true;
		            }
		            else {
		                alert("The First Character Should Start With % And Last Character Shoul End With %");
		                document.getElementById('txtagencode').focus();
		                return false;
		            }
		        }
		        else {
		            alert("The First Character Should Start With % And Last Character Shoul End With %");
		            document.getElementById('txtagencode').focus();
		            return false;
		        }
		        //return true;
		    }
		    function addstate() {
		        Agent_master.addstate0(document.Form1.drpcity.value, state);

		    }
		    function state(response) {
		        var ds = response.value;
		        //alert(response);	
		        if (ds != null && typeof (ds) == "object" && ds.Tables != null) {
		            document.forms[0].item("txtstate").options.length = 0;
		            document.forms[0].item("txtstate").options.length = ds.Tables[0].Rows.length;
		            //alert((document.forms[0].item("drpregion").options.length));	
		            for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
		                document.forms[0].item("txtstate").options[i] = new Option(ds.Tables[0].Rows[i].state_name, ds.Tables[0].Rows[i].state_code);

		            }
		        }
		    }


		</script>
		<script type="text/javascript" language="javascript">


		    function check_it() {

		        var theurl = document.Form1.txturl.value;
		        // var tomatch= /http:\/\/[A-Za-z0-9\.-]{3,}\.[A-Za-z]{3}/
		        var tomatch = /[A-Za-z0-9\.-]{3,}\.:_[A-Za-z]{3}/
		        if (tomatch.test(theurl) || document.getElementById('txturl').value == "") {
		            //window.alert("URL OK.");
		            return true;
		        }
		        else {
		            window.alert("Invalid URL ");
		            document.getElementById('txturl').focus();
		            document.getElementById('txturl').value = "";
		            return false;
		        }
		    }

		    /*function agencode()
            {
            var i=document.getElementById('txtagencode').value;
            int a=i.length;
            int b=a-1;
            alert(b);
            
            
            if(i.substring(1)="%")
            {
            return true;
            }
            
            
            }*/







		    function Upperremarks(a) {


		        document.getElementById(a).value = trim(document.getElementById(a).value.toUpperCase());
		        return;

		    }

		    function uppercase2() {

		        document.getElementById('txtsagencycode').value = trim(document.getElementById('txtsagencycode').value.toUpperCase());
		        document.getElementById('getagsubcode').value = trim(document.getElementById('txtsagencycode').value);
		        return;

		    }

		    function uppercase1() {

		        document.getElementById('txtalias').value = trim(document.getElementById('txtalias').value.toUpperCase());
		        return;

		    }
		    var str;


		    function fillstr(res) {
		        var ds = res.value;
		        var newstr = ds.Tables[0].Rows[0].agency_code;
		        alert(newstr);
		        if (newstr != null) {
		            var code = newstr.substr(2, 4);
		            code++;
		            alert(code);

		            document.getElementById('txtagencode').value = str.substr(0, 2) + code;
		        }
		        else {
		            document.getElementById('txtagencode').value = str.substr(0, 2) + "0";
		        }
		        document.getElementById('getagcode').value = document.getElementById('txtagencode').value;
		        return false;
		    }

		    function uppercase4() {

		        document.getElementById('txtadd').value = trim(document.getElementById('txtadd').value.toUpperCase());
		        return;

		    }

		    function uppercase5() {

		        document.getElementById('txtstreet').value = trim(document.getElementById('txtstreet').value.toUpperCase());
		        return;

		    }

		    function uppercase6() {

		        document.getElementById('txtstacno').value = trim(document.getElementById('txtstacno').value.toUpperCase());
		        return;

		    }


		    function uppercasepin() {

		        document.getElementById('txtpincode').value = trim(document.getElementById('txtpincode').value.toUpperCase());
		        return;

		    }
		    function uppercase7() {

		        document.getElementById('txtbill').value = trim(document.getElementById('txtbill').value.toUpperCase());
		        return;

		    }

		    function uppercase8() {

		        document.getElementById('txtagencyho').value = trim(document.getElementById('txtagencyho').value.toUpperCase());
		        return;

		    }

		    function uppercase9() {

		        document.getElementById('txtsugagencyho').value = trim(document.getElementById('txtsugagencyho').value.toUpperCase());
		        return;

		    }

		    function uppercase10() {

		        document.getElementById('txtmryrefno').value = trim(document.getElementById('txtmryrefno').value.toUpperCase());
		        return;

		    }

		    function uppercase11() {

		        document.getElementById('txtnoofvts').value = trim(document.getElementById('txtnoofvts').value.toUpperCase());
		        return;

		    }

		    function uppercase12() {

		        document.getElementById('txtpan').value = trim(document.getElementById('txtpan').value.toUpperCase());
		        return;

		    }

		    function uppercase13() {

		        document.getElementById('txttan').value = trim(document.getElementById('txttan').value.toUpperCase());
		        return;

		    }

		    function agencode() {
		        /*if(document.getElementById('txtagencode').value=="")
                {
                alert("Please, enter Agency Code");
                document.getElementById('txtagencode').focus();
                return(false);
                }*/
		        var a = document.getElementById('txtagencode').value;
		        var abc = document.getElementById('txtagencode').value.length;
		        if (a.substring(0, 1) == "%" && a.substring(abc, abc - 1) == "%") {
		            return true;
		        }
		        else {
		            alert("The First Character Should Start With % And Last Character Shoul End With %");
		            return false;
		        }
		        //return true;

		    }
		    function uppercase14() {

		        document.getElementById('txtaddress1').value = trim(document.getElementById('txtaddress1').value.toUpperCase());
		        return;

		    }

		    function uppercaseregion() {

		        document.getElementById('mrvregion').value = trim(document.getElementById('mrvregion').value.toUpperCase());
		        return;

		    }

		    function uppercase15() {

		        document.getElementById('txtaddress2').value = trim(document.getElementById('txtaddress2').value.toUpperCase());
		        return;

		    }




		    var dtCh = "/";
		    var minYear = 1900;
		    var maxYear = 2100;

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

		    function isDate(dtStr) {
		        var daysInMonth = DaysArray(12)
		        var pos1 = dtStr.indexOf(dtCh)
		        var pos2 = dtStr.indexOf(dtCh, pos1 + 1)
		        var strMonth = dtStr.substring(0, pos1)
		        var strDay = dtStr.substring(pos1 + 1, pos2)
		        var strYear = dtStr.substring(pos2 + 1)
		        strYr = strYear
		        if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
		        if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
		        for (var i = 1; i <= 3; i++) {
		            if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
		        }
		        month = parseInt(strMonth)
		        day = parseInt(strDay)
		        year = parseInt(strYr)
		        if (pos1 == -1 || pos2 == -1) {
		            alert("The date format should be : mm/dd/yyyy")
		            return false
		        }
		        if (strMonth.length < 1 || month < 1 || month > 12) {
		            alert("Please enter a valid month")
		            return false
		        }
		        if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
		            alert("Please enter a valid day")
		            return false
		        }
		        if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
		            alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear)
		            return false
		        }
		        if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
		            alert("Please enter a valid date")
		            return false
		        }
		        return true
		    }



		    //function checkEmail() 
		    //{

		    //var theurl=document.Form1.txtmail.value;

		    //if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById('txtmail').value=="")
		    //{
		    //return (true)
		    //}
		    //alert("Invalid E-mail Address! Please re-enter.")
		    //document.getElementById('txtmail').focus();
		    //return (false)





		    //}




		    function isEmail(email) {
		        if (document.Form1.txtmail.value.indexOf("@") != "-1" && document.Form1.txtmail.value.indexOf(".") != "-1")
		            return true;
		        else
		            return false;
		    }

		    function checkEmail() {


		        if (isEmail(document.Form1.txtmail.value) == false && document.Form1.txtmail.value != "") {
		            alert("Enter your correct Email ID");
		            document.Form1.txtmail.value = "";
		            document.Form1.txtmail.focus();
		            return false;
		        }
		    }





		    function checkEmailcc() {


		        if (isEmail(document.Form1.txtmailcc.value) == false && document.Form1.txtmailcc.value != "") {
		            alert("Enter your correct Email ID");
		            document.Form1.txtmailcc.value = "";
		            document.Form1.txtmailcc.focus();
		            return false;
		        }
		    }



		    function abc(str) {
		        var a = "0123456789()-";
		        var i = 0;
		        do {
		            var pos = 0;
		            for (var j = 0; j < a.length; j++)
		                if (str.charAt(i) == a.charAt(j)) {
		                    pos = 1;
		                    break;
		                }
		            i++;

		        }
		        while (pos == 1 && i < str.length)
		        if (pos == 0)
		            return false;
		        return true;
		    }

		    function abc1(str) {
		        var a = "0123456789.";
		        var i = 0;
		        do {
		            var pos = 0;
		            for (var j = 0; j < a.length; j++)
		                if (str.charAt(i) == a.charAt(j)) {
		                    pos = 1;
		                    break;
		                }
		            i++;

		        }
		        while (pos == 1 && i < str.length)
		        if (pos == 0)
		            return false;
		        return true;
		    }


		    function abc3(str) {
		        var a = "0123456789";
		        var i = 0;
		        do {
		            var pos = 0;
		            for (var j = 0; j < a.length; j++)
		                if (str.charAt(i) == a.charAt(j)) {
		                    pos = 1;
		                    break;
		                }
		            i++;

		        }
		        while (pos == 1 && i < str.length)
		        if (pos == 0)
		            return false;
		        return true;
		    }

		    function notchar() {
		        if ((event.keyCode >= 48 && event.keyCode <= 57) ||
                (event.keyCode == 8) ||
                (event.keyCode == 189) ||
                (event.keyCode == 36) ||
                (event.keyCode == 35) ||
                (event.keyCode == 46) ||
                (event.keyCode == 37) ||
                (event.keyCode == 39) ||
                (event.keyCode >= 96 && event.keyCode <= 105) ||
                (event.keyCode == 9 || event.keyCode == 32)) {
		            return true;
		        }
		        else {
		            return false;
		        }
		    }



		    //function enteruse(tindx)
		    //{
		    //if(event.keyCode==13)
		    //{
		    //tindx++;
		    //document.getElementById('txtagenname')
		    //}
		    //return false;
		    //}




		    function notcharagency(event, id) {
		        var browser = navigator.appName;
		        if (browser != "Microsoft Internet Explorer") {
		            if ((event.which >= 48 && event.which <= 57) ||
                    (event.which == 127) || (event.which == 37) ||
                    (event.which >= 97 && event.which <= 122) ||
                    (event.which >= 65 && event.which <= 90) ||
                    (event.which == 9 || event.which == 0 || event.which == 32 || event.which == 8)) {
		                id.value = trim(id.value.toUpperCase());
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		        else {
		            if ((event.keyCode >= 48 && event.keyCode <= 57) ||
                   (event.keyCode == 127) || (event.keyCode == 37) ||
                   (event.keyCode >= 97 && event.keyCode <= 122) ||
                   (event.keyCode >= 65 && event.keyCode <= 90) ||
                   (event.keyCode == 9 || event.keyCode == 32)) {
		                id.value = trim(id.value.toUpperCase());
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		    }



		    function notchar2(event) {
		        //alert(event.keyCode);
		        var browser = navigator.appName;
		        if (browser != "Microsoft Internet Explorer") {
		            if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		        else {
		            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		    }


		    function validateform(form) {

		        if (document.getElementById('txtagencode').value == "") {
		            alert("Please, enter Agency Code ");
		            document.getElementById('txtagencode').focus();
		            return (false);
		        }

		        else if (document.getElementById('txtsagencycode').value == "") {
		            alert("Please, enter Agency Sub Code ");
		            document.getElementById('txtsagencycode').focus();
		            return (false);
		        }






		        else if (document.getElementById('drpagetyp').value == "0") {
		            //alert(document.getElementById('txtenrolldate').value);
		            alert("please enter the Agency Type.");
		            document.getElementById('drpagetyp').focus();
		            return (false);
		        }



		        else if (document.getElementById('drpagecate').value == "0") {
		            //alert(document.getElementById('txtenrolldate').value);
		            alert("please enter the Agency Category.");
		            document.getElementById('drpagecate').focus();
		            return (false);
		        }



		        else if (document.getElementById('drpagescat').value == "0") {
		            //alert(document.getElementById('txtenrolldate').value);
		            alert("please enter the Agent Sub Category.");
		            document.getElementById('drpagescat').focus();
		            return (false);
		        }

		        else if (document.getElementById('txtagenname').value == "") {
		            alert("Please Enter the Agency Name");
		            document.getElementById('txtagenname').focus();

		            return (false);
		        }

		        else if (document.getElementById('txtalias').value == "") {
		            alert("Please Enter the Alias");
		            document.getElementById('txtalias').focus();
		            return (false);
		        }

		        else if (document.getElementById('drpcity').value == "0") {
		            alert("Please Select The City");
		            document.getElementById('drpcity').focus();
		            return (false);
		        }




		        //alert("please enter the date");
		        //return(true);



























		        saveclick();

		    }
		    var toper = 200;


		    //var popUpWin = null; 

		    /*function contact()
            { 
              for ( var index = 0; index < 200; index++ ) 
              { 
              
              var agecode=document.getElementById('txtagencode').value;
                var hidden=document.getElementById('hiddentxt').value;
                var agencysubcode=document.getElementById('txtsagencycode').value;
                if(document.getElementById('hiddencompcode').value != null && document.getElementById('hiddencompcode').value != "")
                {
                popUpWin 
                 = window.open('contact_detail.aspx?agecode='+agecode+'&agencysubcode='+agencysubcode+',&show='+show,'Ankur','resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px'); 
                popUpWin.focus();
                }
                else
                {
                alert("Your Session Expired Please Login Again");
                return false;
                }
                 return false;
              } 
            
            } 
            
            
            function commission()
            { 
            
              for ( var index = 0; index < 200; index++ ) 
              { 
             
              var agecode=document.getElementById('txtagencode').value;
                var hidden=document.getElementById('hiddentxt').value;
                var agencysubcode=document.getElementById('txtsagencycode').value;
                popUpWin1 
                 = window.open('Comm_detail.aspx?agecode='+agecode+'&agencysubcode='+agencysubcode+'&show='+show,'Ankur1', 'toolbar=0,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px'); 
              popUpWin1.focus();
                 return false;
              } 
            
            } 
            
            function  bank()
            { 
            
              for ( var index = 0; index < 200; index++ ) 
              { 
             
              var agecode=document.getElementById('txtagencode').value;
                var agencysubcode=document.getElementById('txtsagencycode').value;
                popUpWin2 
                 = window.open('bank_detail.aspx?agecode='+agecode+'&agencysubcode='+agencysubcode+'&show='+show,'Ankur2', 'status=0,toolbar=0,resizable=1,scrollbars=yes,top=244,left=210,width=780px,height=415px'); 
              popUpWin2.focus();
                 return false;
              } 
            
            } 
            
            function  status123()
            { 
            
              for ( var index = 0; index < 200; index++ ) 
              { 
             
            var agecode=document.getElementById('txtagencode').value;
            var agencysubcode=document.getElementById('txtsagencycode').value;
                popUpWin3 
                 = window.open('status_detail.aspx?agecode='+agecode+'&agencysubcode='+agencysubcode+'&show='+show,'Ankur3', 'status=0,toolbar=0,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px'); 
              popUpWin3.focus();
                 return false;
              } 
            
            } 
            
            function  paymode()
            { 
            
              for ( var index = 0; index < 200; index++ ) 
              { 
             
            var agecode=document.getElementById('txtagencode').value;
            var agencysubcode=document.getElementById('txtsagencycode').value;
            var akhil=document.getElementById('hiddenexecute').value;
                popUpWin4 
                 = window.open('paymode.aspx?agecode='+agecode+'&agencysubcode='+agencysubcode+'&akhil='+akhil+'&show='+show,'Ankur4', 'status=0,toolbar=0,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px'); 
              popUpWin4.focus();
                 return false;
              } 
            
            } */


		    function akhil1() {
		        /*
                alert("hi");
                color:#fff;
                background-color:red;*/

		        //alert(document.getElementById('1'));
		        document.getElementById('1').style.visibility = "visible";
		        return false;

		    }
		    function agencyclientdate(event) {
		        if (browser != "Microsoft Internet Explorer") {
		            if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 9)) {

		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		        else {
		            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 11 || (event.which == 9))) {

		                return true;
		            }
		            else {
		                return false;
		            }
		        }
		    }



		    //  End -->

		</script>
		
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="css/main.css" type="text/css" rel="stylesheet" />
        <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />  
      <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />  
   
   
       
		
	</head>
	<body id="bdy" margin-left:-2px; margin-top:-2px; onload="document.getElementById('chkvat').disabled=true;javascript:return blankagency();"  onkeydown="javascript:return tabvalue(event,'txtremarks');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
		<asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
		<div id="div2" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency1" Width="500px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>

            <div id="divgstclty" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstgstclty" Width="500px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        
        
        		<div id="divmrv" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstmrv" runat="server" CssClass="btextlistdouble">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        
         <div id="div3" style="position: absolute; top: 0px; left: 0px; border: 0; display:none;z-index:1;" >
            <table cellpadding="0" cellspacing="0" style="border: thin double #000000; height:80px; width:300px; background-color: #D4D0C8;">
                <tr>
                    <td valign="top"><asp:Label ID="lblagaddf2" runat="server" CssClass="TextField" Text="Agency Address"></asp:Label></td>
                    <td valign="top"><asp:TextBox ID="txtagaddf2" Width="180px" Height="50px" runat="server" CssClass="btext1forbooknew" Enabled="true" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                <td colspan="2" valign="top" align="left" style="padding-right:10px"><input type="button" value="Close" runat="server" style="height:18px;" id="close3" class ="buttonsmall"  /></td>
                <td colspan="2" valign="top" align="right" style="padding-right:10px"><input type="button" value="Search" runat="server" style="height:18px;" id="btnagencysearch" class ="buttonsmall"  /></td>
                </tr>
            </table>
        </div>
        
        
		<div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="500px"  Height="100px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
			 
<%--<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstclient" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> --%>
			<%--<table id="OuterTable" cellspacing="0" cellpadding="0"  border="0" width="100%">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Agency Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					<td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top"  >
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" >
							<tr valign="top" style="width: 74.6%">--%>
             <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Agency Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                       
                    </td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
										
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:10px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>
                         Agency Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table class="intable" cellpadding="0" cellspacing="0">
			<tr>
				<td>
				   <asp:linkbutton id="lbcommdetail" style="cursor:pointer" runat="server" CssClass="btnlink_n">Commission Details |</asp:linkbutton><asp:linkbutton id="lbpaymode" style="cursor:pointer" runat="server" CssClass="btnlink_n">Pay Mode |</asp:linkbutton><asp:linkbutton id="lbcontactdetails" style="cursor:pointer" runat="server" CssClass="btnlink_n" Font-Underline="False">Contact Details |</asp:linkbutton><asp:linkbutton id="lbbankdetail" style="cursor:pointer" runat="server" CssClass="btnlink_n">Bank Details |</asp:linkbutton><asp:linkbutton id="lbstatusdetail" style="cursor:pointer" runat="server" CssClass="btnlink_n">Status Details |</asp:linkbutton>
									<asp:linkbutton id="lbbankmast" style="cursor:pointer" runat="server" CssClass="btnlink_n">Bank Master |</asp:linkbutton>
                                    <asp:linkbutton id="linkuom" style="cursor:pointer; display:none" runat="server" CssClass="btnlink_n">Uom Wise Permission |</asp:linkbutton>
				</td>
			</tr>
			</table>
			<table class="ontable"  border="0" >
									<tr>
									<td id="frsttd" class="style3">
									<tr>
                                            <td class="style8">
                                                <asp:Label ID="Parent" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td class="style9">
                                                <asp:DropDownList ID="drpparent" runat="server" CssClass="dropdown"><asp:ListItem Value="0">--Select Type--</asp:ListItem>
<asp:ListItem Value="C">Child</asp:ListItem>
<asp:ListItem Value="P">Parent</asp:ListItem>
<asp:ListItem Value="E">Extra level</asp:ListItem>
</asp:DropDownList></td>
                                            <td style="height: 18px; width: 112px;">
                                                <asp:Label ID="rategroup" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="height: 18px"><asp:DropDownList ID="drprate" runat="server" CssClass="dropdown" Enabled="False">
                                               </asp:DropDownList></td>
                                        </tr>
                                        
                                        <tr>
									    <td class="style3"><asp:label id="lblbranch" runat="server" CssClass="TextField"></asp:label></td>
								        <td class="style10">
                                              <asp:DropDownList ID="drpbranch" runat="server" CssClass="dropdown">
                                              <asp:ListItem Value="0">--Select Branch--</asp:ListItem>
                                              </asp:DropDownList>
                                        </td>
									</tr>
									   		<%--	
									   			<tr>
									   				<asp:label id="agdesig" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3">
												<asp:textbox id="txtdesg" runat="server"   CssClass="btext" MaxLength="50"></asp:textbox>
									   			</tr>--%>
									   			
									   				<tr>
											<td class="style3">
												<asp:label id="agdesig" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3" >
												<asp:textbox id="txtdesg" runat="server"   CssClass="btext" MaxLength="50"  onkeypress="return notchar_b123(event);"></asp:textbox></td>
										</tr>
									
									   			
									   			
									   						
										<tr>
											<td class="style5"><asp:label id="AgencyName" runat="server" CssClass="TextField"></asp:label></td>
											<td id="tdagen3"  colspan="3">
                                                <asp:textbox id="txtagenname" runat="server" CssClass="btext" onkeypress="return notchar_b(event);"
													MaxLength="50"></asp:textbox></td>
											<td colspan="1" ><img src='Images/Search.png' id="Imgadvance" onclick='openadvpopup()' runat="server" height="20" width="20" /> 
											<asp:UpdatePanel ID="up1" runat="server"><ContentTemplate> 
                                                <asp:Button ID="btnagencyname" runat="server"   CssClass="topbutton" Width="75px"  text="Agency Name" /></ContentTemplate>
											</asp:UpdatePanel></td>
										
									
                                            
											<%--<td > <asp:UpdatePanel ID="up1" runat="server"><ContentTemplate> <asp:Button ID="btnagencyname" runat="server"   CssClass="topbutton" Width="75px" 
                        text="Agency Name" /></ContentTemplate></asp:UpdatePanel></td>--%>
											
										</tr>
										
										
									  <%--  <tr>
										
										
										
										
										
								    <td style="height:20px"></td>
											
										    <td colspan="3"></td>
										
										
										
										
									    </tr>--%>
										
										
									<tr id="selectagencode">
			
			<td class="style5">
			<asp:label id="lblselectcode" runat="server" CssClass="TextField"></asp:label></td>
			
			<%--<asp:dropdownlist ID="selectcode"  CssClass="dropdownbillto" runat="server" >
			</asp:dropdownlist>--%>
			<td colspan="4" ><asp:TextBox ID="selectcode"  runat="server" CssClass="btext1" MaxLength="50" Width="300px"></asp:TextBox>
			</td>
			
				
			
			</tr>
										
										
										
										
										
										
										<tr>
											<td class="style5"><asp:label id="AgencyCode" runat="server" CssClass="TextField"></asp:label></td>
											<td id="tdagen" class="style11"><asp:textbox  id="txtagencode" onpaste="return false;" onkeypress="return notchar1(event);" runat="server" CssClass="btext1"
													MaxLength="8"></asp:textbox></td>
											<td style="width: 112px; height: 19px;"><asp:label id="SubAgencyCode" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px"><asp:textbox  id="txtsagencycode" onpaste="return false;" onkeypress="return notchar1(event);" runat="server" CssClass="btext1"
													MaxLength="8"></asp:textbox></td>
													<td style="width: 112px; height: 19px;"><asp:label id="lblsubsubagcd" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px"><asp:textbox  id="txtsubsubagcd" onpaste="return false;" onkeypress="return notchar1(event);" runat="server" CssClass="btext1"
													MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style8">
												<asp:label id="AgencyType" runat="server" CssClass="TextField"></asp:label></td>
											<td rowspan="1" class="style9">
												<asp:dropdownlist id="drpagetyp" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
											<td id="lab" style=" width: 112px; height: 18px; vertical-align:top; left:auto;" align="left" >
												<asp:label id="AgencyCategory" runat="server" CssClass="TextField"></asp:label></td>
											<td id="txt" rowspan="1" style=" height: 18px;">
												<asp:dropdownlist id="drpagecate" runat="server" CssClass="dropdown" Width="144px">
                                                    <asp:ListItem Value="0" Selected="True">--Select Category--</asp:ListItem>
                                                </asp:dropdownlist></td>
										</tr>
										<tr  >
											<td class="style6">
												<asp:label id="AgencySubCategory" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style12">
												<asp:dropdownlist id="drpagescat" runat="server" CssClass="dropdown">
                                                    <asp:ListItem Value="0">--Select sub Category--</asp:ListItem>
                                                </asp:dropdownlist></td>
                                            
										
										</tr>
                                                    <tr id="txt1" style="display:none"> <td class="style6"  > &nbsp;</td>   </tr>
										<tr>
											<td class="style5">
												<asp:label id="Alias" runat="server" CssClass="TextField"></asp:label></td> 
											<td colspan="3" style="height: 19px">
												<asp:textbox  id="txtalias" runat="server" CssClass="btext" MaxLength="50" onkeypress="return notchar_b(event);"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style3">
												<asp:label id="Address1" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3">
												<asp:textbox id="txtadd" runat="server"   CssClass="btext" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
                                            <td class="style7">
                                                <asp:Label ID="Address2" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td colspan="3" style="height: 21px">
                                                <asp:TextBox ID="txtaddress1"    runat="server" CssClass="btext" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="Address3" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtaddress2" runat="server"  CssClass="btext" MaxLength="50"></asp:TextBox></td>
                                        </tr>
										<tr>
											<td class="style3"><asp:label id="Street" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3"><asp:textbox id="txtstreet"  runat="server" CssClass="btext" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style3"><asp:label id="AgencyMailID" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox id="txtmail" runat="server" CssClass="btextmail"></asp:textbox></td>
											<td style="HEIGHT: 10px"><asp:label id="Country" runat="server" CssClass="TextField"></asp:label></td>
											<td style="HEIGHT: 10px">
												<asp:dropdownlist id="txtcountry" runat="server" CssClass="dropdown" OnSelectedIndexChanged="txtcountry_SelectedIndexChanged"></asp:dropdownlist></td>
																						
										</tr>
										<tr>
											<td class="style3"><asp:label id="AgencyMailIDcc" runat="server" 
                                                    CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox id="txtmailcc" runat="server" CssClass="btextmail"></asp:textbox></td>
											<td style="HEIGHT: 10px">&nbsp;</td>
											<td style="HEIGHT: 10px">
												&nbsp;</td>
																						
										</tr>
										<tr>
										<td class="style3"><asp:label id="City" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:dropdownlist id="drpcity" runat="server" CssClass="dropdown">
                                                <asp:ListItem Value="0">--Select City--</asp:ListItem>
                                            </asp:dropdownlist></td>
											<td style="HEIGHT: 10px; width: 120px;"><asp:label id="astate" runat="server" CssClass="TextField"></asp:label></td>
											<td style="HEIGHT: 10px"><asp:textbox id="txtstate" runat="server" CssClass="btext1"></asp:textbox></td>
										</tr>
										<tr>
										<td class="style3"><asp:label id="District" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox id="txtdistrict" runat="server" CssClass="btext1"></asp:textbox></td>
											
											<td align="left" style="width: 112px"><asp:label id="PinCode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox style="text-align:right" onkeypress="return notchar2(event);"  id="txtpincode" onpaste="return false;" runat="server" CssClass="btext1"
													MaxLength="12"></asp:textbox></td>
										</tr>
										<tr>
										<td class="style3"><asp:label id="lbltaluka" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:dropdownlist id="drptaluka" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
											
											<td style="width: 112px"><asp:label id="Region" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpregion" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="style3"><asp:label id="Phone" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox style="text-align:right" onkeypress="return notchar2(event);" id="txtphone1" onpaste="return false;" runat="server"  CssClass="btextsmallphone"
													MaxLength="5"></asp:textbox><asp:textbox style="text-align:right" onkeypress="return ClientisNumberforcompany(event);" id="txtphone2" onpaste="return false;" runat="server"  CssClass="btextsmall"
													MaxLength="18"></asp:textbox></td>
											<td style="width: 112px"><asp:label id="Zone" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpzone" runat="server" CssClass="dropdown">
                                            </asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="style3">
                                                <asp:Label ID="Fax" runat="server" CssClass="TextField"></asp:Label></td>
											<td class="style10">
                                                <asp:TextBox style="text-align:right" ID="txtfax" onpaste="return false;" runat="server" CssClass="btextsmallphone" MaxLength="5"
                                                    onkeypress="return notchar2(event);"></asp:TextBox><asp:TextBox style="text-align:right" ID="txtfax1" runat="server" CssClass="btextsmall" MaxLength="20" onkeypress="return ClientisNumberforcompany(event);"></asp:TextBox></td>
											<td style="width: 120px"><asp:label id="MRVReferenceNo" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox   id="txtmryrefno" runat="server" CssClass="btext1"
													MaxLength="25"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style3"><asp:label id="Url" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox id="txturl" runat="server" CssClass="btext1" MaxLength="30"></asp:textbox></td>
											<td style="width: 112px"><asp:label id="mrvregio" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="mrvregion" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style3"><asp:label id="CreditDays" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox onkeypress="return notchar2(event);" id="txtcredit" runat="server" CssClass="btext1"
													MaxLength="4"></asp:textbox></td>
											<td style="width: 112px"><asp:label id="PanNo" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return notchar1(event);" id="txtpan" runat="server" CssClass="btext1" MaxLength="15"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style3"><asp:label id="Creditlimit" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10" >
                                                <asp:TextBox ID="txtcrlimit" runat="server" CssClass="btextsmall" MaxLength="10"
                                                    onkeypress="return notchar2(event);"></asp:TextBox>
                                                <asp:DropDownList ID="drpcurtyp" runat="server" CssClass="dropdownsmall">
                                                </asp:DropDownList></td>
											<td style="width: 112px"><asp:label id="TanNo" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return notchar1(event);" id="txttan" runat="server" CssClass="btext1" MaxLength="15"></asp:textbox></td>
										</tr>
										
										
											
										<tr>
											<td><asp:label id="creditlimitdays" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox onkeypress="return notchar2(event);" id="txtcreditlimitdays" runat="server" CssClass="btext1"
													MaxLength="4"></asp:textbox></td>
													
													 <td style="width: 112px">
                                                <asp:label id="crlimitfromdate" runat="server" CssClass="TextField"></asp:label></td>
                                            <td>
                                                <asp:textbox  onkeypress="javascript:return agencyclientdate(event);" id="txtcrlimitfromdate"   runat="server" CssClass="startandenddate" MaxLength="10" onpaste="return false;"></asp:textbox>
                                               <img alt="Calender"  src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, Form1.txtcrlimitfromdate, "mm/dd/yyyy")' onfocus="abc()" height="14" width="14"/>
                                                </td>
											</tr>
										<tr>
											<td><asp:label id="recoverylimit" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox onkeypress="return notchar2(event);" id="txtrecoverylimit" runat="server" CssClass="btext1"
													MaxLength="4"></asp:textbox></td>
												</tr>
										
										
										
                                        <tr>
                                            <td class="style3">
                                                <asp:label id="NoofVTS" runat="server" CssClass="TextField"></asp:label></td>
                                            <td class="style10">
                                                <asp:textbox onkeypress="return notchar1(event);" id="txtnoofvts" runat="server" CssClass="btext1"
													MaxLength="12"></asp:textbox></td>
                                            <td style="width: 112px">
                                                <asp:label id="ServiceTaxACNo" runat="server" CssClass="TextField"></asp:label></td>
                                            <td>
                                                <asp:textbox onkeypress="return notchar1(event);" id="txtstacno" runat="server" CssClass="btext1"
													MaxLength="15"></asp:textbox></td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:label id="Buisness" runat="server" CssClass="TextField"></asp:label></td>
                                            <td class="style10">
                                                <asp:textbox onkeydown="javascript:return agencyclientdate(event);" id="txtbusineedate" runat="server" CssClass="startandenddate" MaxLength="10" onpaste="return false;"></asp:textbox>
                                                <img alt="Calender"  src='Images/cal1.gif'  id="div1" onclick='popUpCalendar(this, Form1.txtbusineedate, "mm/dd/yyyy")' onfocus="abc()" height="14" width="14"/>
												</td>
                                            <td style="width: 112px">
                                                <asp:label id="EnrolmentDate" runat="server" CssClass="TextField"></asp:label></td>
                                            <td>
                                                <asp:textbox  onkeydown="javascript:return agencyclientdate(event);" id="txtenrolldate"   runat="server" CssClass="startandenddate" MaxLength="10" onpaste="return false;"></asp:textbox>
                                               <img alt="Calender"  src='Images/cal1.gif' id="dav2" onclick='popUpCalendar(this, Form1.txtenrolldate, "mm/dd/yyyy")' onfocus="abc()" height="14" width="14"/>
                                                </td>
                                        </tr>
										<tr>
											<td class="style5"><asp:label id="BillTO" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style11">
                                                <asp:dropdownlist id="biltodrp" runat="server" CssClass="dropdown" OnSelectedIndexChanged="txtcountry_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select Bill To--</asp:ListItem>
                                                </asp:dropdownlist>
                                                
                                                </td>
											<td style="width: 112px; height: 19px;"><asp:label id="Representative" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px"><asp:dropdownlist id="drprepres" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
										</tr>
										<tr id="agtr" runat="server">
											<td class="style5"><asp:label id="agcode" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style11">
                                                <asp:dropdownlist id="txtbill" runat="server" CssClass="dropdownbillto" OnSelectedIndexChanged="txtbill_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select A/C Agency--</asp:ListItem>
                                            </asp:dropdownlist></td>
											<td style="height: 19px; width: 112px;"><asp:label id="agsubcode" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px"><asp:textbox onkeypress="return notcharagency(event,this);" onkeyup="return notcharagency(event,this);" id="getagsubcode" runat="server" CssClass="btext1"
													MaxLength="8" ReadOnly="True" Enabled="False"></asp:textbox></td>
										</tr>
										<tr id="agtr1" runat="server">
											<td class="style5">
                                                <asp:label id="AgencyHO" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style11"><asp:textbox onkeypress="return notchar1(event);" id="txtagencyho" runat="server" CssClass="btext1"
													MaxLength="15"></asp:textbox></td>
											<td style="height: 19px; width: 112px;"><asp:label id="SubAgencyHO" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px"><asp:textbox onkeypress="return notchar1(event);" id="txtsugagencyho" runat="server" CssClass="btext1"
													MaxLength="15"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style3"><asp:label id="Status" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style10"><asp:textbox id="txtstatus" runat="server" CssClass="btext1"></asp:textbox></td>
											<td style="width: 112px"><asp:label id="StatusDate" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtstatusdate" runat="server" CssClass="btext1"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style8"><asp:label id="StatusReason" runat="server" CssClass="TextField"></asp:label></td>
											<td class="style9"><asp:textbox id="txtstatus2" runat="server" CssClass="btext1" MaxLength="200"></asp:textbox></td>
											<td style="HEIGHT: 17px;"><asp:label id="lbldepocode" runat="server" CssClass="TextField"></asp:label></td>
												<td style="HEIGHT: 17px;">
												<asp:TextBox id="txtdepocode" runat="server" CssClass="btext1" MaxLength="50"></asp:TextBox></td>
												<td style="HEIGHT: 17px;display:none;"><asp:label id="lbluserid" runat="server" CssClass="TextField"></asp:label></td>
												<td style="HEIGHT: 17px;display:none;">
												<asp:dropdownlist id="drpuserid" Enabled="false" runat="server" CssClass="dropdown">
                                                  
                                                </asp:dropdownlist></td>
										</tr>
										<tr>
										<td class="style3"><asp:Label ID="lblbillf" runat="server" CssClass="TextField"></asp:Label></td>
										<td class="style10"><asp:DropDownList ID="drpbillf" runat="server" CssClass="dropdown">
										<asp:ListItem Value="0">---Bill Frequency---</asp:ListItem>
										<asp:ListItem Value="W">Weekly</asp:ListItem>
										<asp:ListItem Value="M">Monthly</asp:ListItem>
										<asp:ListItem Value="D">Day Wise</asp:ListItem></asp:DropDownList></td>
										<td><asp:label id="lblbooktype" runat="server" CssClass="TextField"></asp:label></td>
								        <td rowspan="2"><asp:ListBox ID="bktype" runat="server" SelectionMode="Multiple" style="width:138px;" CssClass="btextlistqbcnew"></asp:ListBox>
                                        </td>	
										</tr>
										<tr>
										<td class="style3"><asp:Label ID="lbEdition_wise_Billing" runat="server" CssClass="TextField"></asp:Label></td>
										<td class="style10"><asp:DropDownList ID="drpEdition_wise_Billing" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList></td>
										</tr>
										<tr>
										<td class="style3"><asp:Label ID="lbloldagen" runat="server" CssClass="TextField"></asp:Label></td>
										<td class="style10"><asp:TextBox ID="txtoldagen" runat="server" CssClass="btext1" MaxLength="50" ></asp:TextBox></td>
										<td><asp:label id="lblexecutive" runat="server" CssClass="TextField"></asp:label></td>
								        <td><asp:ListBox ID="Libexecutive" runat="server" SelectionMode="Multiple" style="width:138px;" CssClass="btextlistqbcnew"></asp:ListBox>
                                        </td>
										
										</tr>
										<tr>
										<td class="style3"><asp:Label ID="lblemail" runat="server" CssClass="TextField"></asp:Label></td>
										<td class="style10"><asp:DropDownList ID="drpemail" runat="server" CssClass="dropdown" Enabled="false">
									</asp:DropDownList></td>
										<td><asp:label id="lblretainer" runat="server" CssClass="TextField"></asp:label></td>
								        <td><asp:ListBox ID="liretainer" runat="server" SelectionMode="Multiple" style="width:138px;" CssClass="btextlistqbcnew"></asp:ListBox></td>
										
										</tr>
										<tr>
											<td class="style3"><asp:label id="Alert" runat="server" CssClass="TextField">Alert</asp:label></td>
											<td colspan="3"><asp:textbox id="txtalert" runat="server" CssClass="btext" MaxLength="200"></asp:textbox></td>
										</tr>
										<tr>
											<td class="style3"><asp:label id="Remarks" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3"><asp:textbox id="txtremarks" runat="server" CssClass="btext" MaxLength="200"></asp:textbox></td>
										</tr>
										<%--/*............For intrest Calulation On Increase...........................*/--%>
										<tr>
												<td class="style3"><asp:Label ID="intrestcalc" runat="server" CssClass="TextField"></asp:Label></td>
										<td class="style10"><asp:DropDownList ID="drpcalc" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                                                
                            <td><asp:label id="lblsapcode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtsapcode" runat="server"  ></asp:textbox></td>
										</tr>
										
										<tr>
												<td class="style3"><asp:Label ID="lblbilflag" runat="server" CssClass="TextField"></asp:Label></td>
										<td class="style10"><asp:DropDownList ID="drpbilflag" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                            <%--//////////////////add by anuja for security lokmat/////////////--%>
                                             <td><asp:label id="lblsecure" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtsecure" runat="server"  onkeypress="return notchar1(event);"></asp:textbox></td>
										</tr>

                                        <tr>
													<td class="style3"><asp:Label ID="Label1" runat="server" CssClass="TextField"></asp:Label></td>
										<td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                            <%--//////////////////add by anuja for security lokmat/////////////--%>
                                             <td><asp:label id="Label2" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="Textbox1" runat="server"  onkeypress="return notchar1(event);"></asp:textbox></td>
										</tr>

                                        <tr>
                                        <td class="style3"><asp:Label ID="lblgstatus" runat="server" CssClass="TextField" Text="Gst Applicable"></asp:Label></td>
										<td class="style10"><asp:DropDownList ID="drpgstatus" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList></td>
												<td class="style3"><asp:Label ID="lblgstus" runat="server" CssClass="TextField"></asp:Label></td>
										<td><asp:DropDownList ID="drpgstus" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Registered</asp:ListItem>
                                            <asp:ListItem Value="N">Unregistered</asp:ListItem>
                                            </asp:DropDownList></td>
                                            <%--//////////////////add by anuja for security lokmat/////////////--%>
                                             
										</tr>
                                              <tr>
                                            <td><asp:label id="lblarnno" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtarno" runat="server" CssClass="btext" MaxLength="15" Width="141px" ></asp:textbox></td>
                                            <td><asp:label id="lblgstprovid" runat="server" CssClass="TextField" ></asp:label></td>
											<td><asp:textbox id="txtgstprovid" runat="server" CssClass="btext"  MaxLength="15" Width="141px"></asp:textbox>
                                                											</td>
                                            
                                        </tr>
                                        <tr>
                                            <td><asp:label id="lblgst" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtgstin" runat="server" CssClass="btext" MaxLength="15" Width="141px" ></asp:textbox></td>
                                            <td><asp:label id="lblgstdt" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtgstdt" runat="server"  ></asp:textbox>
                                                <img alt="Calender"  src='Images/cal1.gif'  id="Img2" onclick='popUpCalendar(this, Form1.txtgstdt, "mm/dd/yyyy")' onfocus="abc()" height="14" width="14"/>
											</td>
                                            
                                        </tr>

                                        <tr>
                                            <td><asp:label id="lblgstclty" runat="server" CssClass="TextField" ></asp:label></td>
											<td><asp:textbox id="txtgstclty" runat="server" CssClass="btext" Width="137px" ></asp:textbox></td>
                                            
                                        </tr>
										 <tr>
                                       
                                            <td class="style10"><asp:label id="lblbnkcheque" runat="server" CssClass="TextField"></asp:label>
											<asp:CheckBox ID="chkcheque" runat="server" CssClass="TextField" /></td>
                                            <td><asp:label id="lblbondrecvd" runat="server" CssClass="TextField"></asp:label>
                                            <asp:CheckBox ID="chkbondrecvd" runat="server" CssClass="TextField" /></td>
                                            <td><asp:label id="lblkyc" runat="server" CssClass="TextField"></asp:label><asp:CheckBox ID="chkyc" runat="server" CssClass="TextField" /></td>
                                            <td><asp:label id="lbladdproof" runat="server" CssClass="TextField"></asp:label><asp:CheckBox ID="chkadproof" runat="server" CssClass="TextField" />
                                           </td>
                                        </tr>
										
											<%--/*............For intrest Calulation On Increase...........................*/--%>
										
										</td>
										<tr>
										<td class="style3"><asp:label id="lblvat" runat="server" CssClass="TextField"></asp:label></td>
										<td class="style10"><asp:CheckBox ID="chkvat" runat="server" CssClass="TextField" /><asp:label id="lblraterevise" runat="server" CssClass="TextField"></asp:label>
										<asp:CheckBox ID="chkraterevise" runat="server" CssClass="TextField" />
										</td>
										<td><asp:Button ID="btnshowremark" Text="Remark Detail" Width="120px" runat="server" Enabled="false" /></td>
										<td></td>
										</tr>
										</tr>
										<tr>
										<td class="style3"><asp:Label ID="Bank0" runat="server" CssClass="TextField" Text="Attachment"></asp:Label></td>
										<td class="style10"><asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton></td>
										<td>&nbsp;</td>
										<td>&nbsp;</td>
										</tr>
										</table> 
            <input id="hiddencenter" type="hidden" name="hiddencenter" runat="server" />
			<input id="hiddenstatuslabel" type="hidden" name="hiddenstatuslabel" runat="server" />
			<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
			<input id="hiddenpermission" type="hidden" name="hiddenpermission" runat="server"/>
			<input id="UserLabel" type="hidden" name="UserLabel" runat="server"/> <input id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server"/>
			<input id="hiddentxt" type="hidden" name="hiddentxt" runat="server"/> <input id="hiddenregion" type="hidden" name="hiddenregion" runat="server"/>
			<input id="hiddenexecute" type="hidden" name="hiddenexecute" runat="server"/> <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/>
			<input id="hiddenratecode" type="hidden" name="hiddenuserid" runat="server"/>
			<input id="hiddensaurabh" type="hidden" name="hiddenuserid" runat="server"/>
			<input id="hiddenagencyname" type="hidden" name="hiddenagencyname" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" onserverchange="hiddenauto_ServerChange" />
			<input id="hiddenbhanu" type="hidden" size="5" name="hide" runat="server"/>
			<input id="hiddenchk" type="hidden" size="5" name="hide" runat="server"/>
			<input id="hiddenquery" type="hidden" size="5" name="hide" runat="server"/>
			<input id="ip1" type="hidden" name="ip1" runat="server" />
			<input id="hiddenagency" type ="hidden" name="hiddenagency" runat="server" />
			<input id="hiddendistcode" type="hidden" name="hiddendistcode" runat="server" />
			<input id="hiddenstatecode" type="hidden" name="hiddendistcode" runat="server" />
			<input id="hdnremarkmod" type="hidden" name="hdnremarkmod" runat="server" />
			<input id="hdnmobiledetail" runat="server" name="hiddendelsau" size="1" type="hidden" />
			<input id="hdnmrv" runat="server" name="hdnmrv" size="1" type="hidden" />
			<input id="hiddenmrv" runat="server" name="hiddenmrv" size="1" type="hidden" />
			<input id="hidkyc" type="hidden" name="hidkyc" runat="server"/>

			<input id="hdngstclty" type="hidden" name="hidkyc" runat="server"/>
			<%--<div id="selectagencode" style="position:absolute; visibility:hidden;">
			<table>
		
			</table>
			</div>--%>
			<table>
		
			<tr><td style ="display:none"><asp:TextBox ID="agencode" runat="server"></asp:TextBox></td>
			<td style ="display:none"><asp:TextBox ID="subagencode" runat="server"></asp:TextBox></td>
			<td style ="display:none"><asp:TextBox ID="dcity" runat="server"></asp:TextBox></td>
			<td style ="display:none"><asp:TextBox ID="dtaluka" runat="server"></asp:TextBox></td>
			<td style ="display:none"><asp:TextBox ID="tdistrict" runat="server"></asp:TextBox></td>
			<td style ="display:none"><asp:TextBox ID="tstate" runat="server"></asp:TextBox></td>
			<td style ="display:none"><asp:TextBox ID="dbillto" runat="server"></asp:TextBox></td>
			<td style ="display:none"><asp:TextBox ID="tbill" runat="server"></asp:TextBox></td>
		    </tr>
			</table>
				<div id="fillbill" style="position:relative; visibility:hidden;left:394px;  bottom:175px ">
			<!--<asp:dropdownlist id="textbill" runat="server" CssClass="dropdownbillto" OnSelectedIndexChanged="txtbill_SelectedIndexChanged">
                                            </asp:dropdownlist>-->
                                            </div>
                    	 <div id="Divgrid1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0; background-color:White; overflow:auto; width:445px; height:390px"  runat="server" >
       
										<table id="Table3" style="WIDTH: 435px; HEIGHT: 268px" align="center">
											<tr>
												  <td runat="server" id="view19" padding-left="10px" align="center" valign="top" >
												
														</td>
											</tr>
											
										</table>
										  <table cellpadding="0" cellspacing="0" id="pagingtab" runat="server" width="250px" style="display:none;padding-left:6px;">
                     <tr>
                          <td id="prepage" colspan="3" runat="server" onclick="javascript:return pageprev(this.value);" class="previousPage1">
                              Previous;&quot; class=&quot;previousPage1&quot;&gt;Previous</td>
                           <td id="next1" colspan='0' runat="server" class="style4" ></td>
                        <td id="nextpage" class ="nextpage" runat="server" width="10px" onclick="javascript:return pagenext(this.value);">
                            Next</td>
               </tr>
                       </table>
                       
                         <asp:Button ID="Button1" runat="server"   CssClass="topbutton" Width="40px" 
                        text="Close"   />
									</div>
		</form>
	</body>
<script language="javascript" type="text/javascript" src="javascript/jquery.min.js"></script>
<script language="javascript" type="text/javascript" src="javascript/jquery-ui.min.js"></script>
<script language="javascript" type="text/javascript" src="javascript/jquery-1.5.js"></script>
<script language="javascript" type="text/javascript" src="javascript/jquery-1.7.1.min.js"></script>

<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
<script language="javascript" type="text/javascript" src="javascript/Agency.js"></script>
<script language="javascript" type="text/javascript" src="javascript/tree.js" ></script>
<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
<script language="javascript" type="text/javascript" src="javascript/saveagent.js"></script>
<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
<script language="javascript" type="text/javascript" src="javascript/permission.js" ></script>
<script language="javascript" type="text/javascript" src="javascript/givepermission.js"></script>
<script language="javascript" type="text/javascript" src="javascript/entertotabagency.js"></script>

</html >
