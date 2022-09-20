var mes;
var saurabh_agarwal;
var chkmodname;
var global_ds;

var z = 0;
var code10;
var code11;
//var flag="";
var flag1 = "0";
var flag2 = "0";
var show = "0";
var cityvar;
var zonevar;
var regionvar;
var ds;

//var akh;
var show;
var chkpcm;
var flag = 0;

var modify = "0";
var popwin;
var a = 1;


var next = 0;

//-----------------
//this flag is for permission
var flag = "";
var hiddentext;
var auto = "";
var hiddentext1 = "";
var global_ds;

var gbcentcode;
var gbcentname;
var gbalias;
var gbcity;
var gbcountry;
//var gbregion;
//var gbzone;
var i = "0";
var chknamemod;
var browser = navigator.appName;

var xmlDoc = null;
var xmlObj = null;

var req = null;
var res2;
function loadXML(xmlFile) {
    var httpRequest = null;

    if (browser != "Microsoft Internet Explorer") {

        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET", xmlFile, true);
        req.send('');

    }
    else {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = "false";
        xmlDoc.onreadystatechange = verify;
        xmlDoc.load(xmlFile);
        xmlObj = xmlDoc.documentElement;
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }

    //  pcmcancel('PubCatMast');

}

function getMessage() {
    var response = "";
    if (req.readyState == 4) {
        if (req.status == 200) {
            response = req.responseText;
            //alert(response);
        }
    }

    var parser = new DOMParser();
    xmlDoc = parser.parseFromString(response, "text/xml");
    xmlObj = xmlDoc.documentElement;
}

function verify() {
    // 0 Object is not initialized 
    // 1 Loading object is loading data 
    // 2 Loaded object has loaded data 
    // 3 Data from object can be worked with 
    // 4 Object completely initialized 
    if (xmlDoc.readyState != 4) {
        return false;
    }
}


function clientaddcode1(response) {
    var ds = response.value;

    if (ds.Tables[1].Rows.length > 0 || ds.Tables[2].Rows.length > 0 || ds.Tables[0].Rows.length > 0) {
        document.getElementById('drpcity').value = ds.Tables[2].Rows[0].state_name;
        document.getElementById('txtdistrict').value = ds.Tables[1].Rows[0].dist_name;
        document.getElementById('txtstate').value = ds.Tables[2].Rows[0].state_name;
        document.getElementById('txtcountry').value = ds.Tables[0].Rows[0].country_name;
        document.getElementById('txtdistrict').disabled = true;
        document.getElementById('txtstate').disabled = true;
        document.getElementById('txtcountry').disabled = true;
    }
    return false;
}
//*******************************************************************************//
//**************************This Function For New Button*************************//
//*******************************************************************************//
function pcmnew() {
    var msg = checkSession();
    if (msg == false)
        return false;
    flag1 = "0";
    flag2 = "0";
    show = "1";
    i = "0";
    modify = "0";
    saurabh_agarwal = 1;
    document.getElementById('hiddensaurabh').value = "1";

    //show="0";
    //z=1;
    //z=0;

    //a=1;
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

    PubCatMast.blankSession();
    //document.getElementById('txtcentercode').disabled=false;
    document.getElementById('txtcentername').disabled = false;
    document.getElementById('drpprint').disabled = false;
    document.getElementById('drpprint').value = "N";
    document.getElementById('txtalias').disabled = false;
    document.getElementById('txtadd1').disabled = false;
    document.getElementById('txtstreet').disabled = false;
    document.getElementById('txtintegration').disabled = false;
    document.getElementById('txtintegration').value="";

    //document.getElementById('txtdistrict').disabled=false;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('txtphone1').disabled = false;
    document.getElementById('txtphone2').disabled = false;
    document.getElementById('txtstatusreason').disabled = false;
    //***
    document.getElementById('drpzone').disabled = false;
    document.getElementById('drpregion').disabled = false;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtimgpath').disabled = false;
    document.getElementById('txtcir_imgpath').disabled = false;
    document.getElementById('txtlogofile').disabled = false;

    document.getElementById('txtfax1').disabled = false;

    document.getElementById('txtfax1').disabled = false;

    document.getElementById('txtBoxadd').disabled = false;
    document.getElementById('dpstatebooking').disabled = false;

    document.getElementById('txtmrv').disabled = false;
    document.getElementById('txtmessage').disabled = false;
    if (document.getElementById('hiddenauto').value == 1) {
        document.getElementById('txtcentercode').disabled = true;
    }
    else {
        document.getElementById('txtcentercode').disabled = false;
    }

    document.getElementById('txtpincode').disabled = false;
    //document.getElementById('txtstate').disabled=false;
    document.getElementById('txtfax').disabled = false;
    document.getElementById('txtfax1').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    document.getElementById('txtstatusdate').disabled = false;
    document.getElementById('txtstatus1').disabled = false;
    document.getElementById('hiddenchk').value = "0";
    document.getElementById('txtcomp_name').disabled = false;
    document.getElementById('lbStatusDetail').disabled = false;
    document.getElementById('lbClientContactDetail').disabled = false;

    document.getElementById('po_update').disabled = false;

    if (document.getElementById('hiddenauto').value == 1) {
        document.getElementById('drpprint').focus();
    }
    else {
        document.getElementById('txtcentercode').focus();
    }
    document.getElementById('txtstatus1').style.visibility = "hidden";
    document.getElementById('txtstatusdate').style.visibility = "hidden";
    document.getElementById('lbStatus').style.visibility = "hidden";
    document.getElementById('lbStatusDate').style.visibility = "hidden";
    //document.getElementById('Label23').style.visibility="hidden";
    //document.getElementById('Label31').style.visibility="hidden";
    //document.getElementById('hiddencompcode').style.visibility="hidden";
    //document.getElementById('hiddenuserid').style.visibility="hidden";

    document.getElementById('hiddenchk').value = "0";
    document.getElementById('txtcentercode').value = "";
    document.getElementById('txtcentername').value = "";
    document.getElementById('txtalias').value = "";
    document.getElementById('txtadd1').value = "";
    document.getElementById('txtstreet').value = "";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('drpcity').value = "0";
    document.getElementById('txtpincode').value = "";
    document.getElementById('drpregion').value = "0";
    document.getElementById('drpzone').value = "0";
    document.getElementById('txtfax1').value = "";
    document.getElementById('txtcomp_name').value = document.getElementById('hiddcompanyname').value;
    document.getElementById('txtfax').value = "";
    document.getElementById('txtphone1').value = "";
    document.getElementById('txtphone2').value = "";
    document.getElementById('txtBoxadd').value = "";
    document.getElementById('txtimgpath').value = "";
    document.getElementById('txtcir_imgpath').value = "";
    document.getElementById('txtlogofile').value = "";

    document.getElementById('txtdistrict').value = "";
    document.getElementById('dpstatebooking').value = "0";


    //document.getElementById('drpzone').value="0";


    document.getElementById('txtstatusreason').value = "";

    document.getElementById('txtmessage').value = "";

    document.getElementById('po_update').value = "";

    document.getElementById('txtpincode').disabled = false;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = false;
    document.getElementById('txtfax1').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    //document.getElementById('txtstatusdate').disabled=false;
    document.getElementById('txtstatus1').disabled = false;
    //document.getElementById('txtcut_time').disabled = true;
    document.getElementById('txtcut_time').value = "";

    modify = "0";

    //			document.getElementById('CheckBox1').checked=false;
    //			document.getElementById('CheckBox2').checked=false;
    //			document.getElementById('CheckBox3').checked=false;
    //			document.getElementById('CheckBox4').checked=false;
    //			document.getElementById('CheckBox5').checked=false;
    //			document.getElementById('CheckBox6').checked=false;
    //			document.getElementById('CheckBox7').checked=false;
    //			document.getElementById('CheckBox8').checked=false;

    //			chkstatus(FlagStatus);

    chkstatus(FlagStatus);
    hiddentext = "new";

    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;

    /*document.getElementById('CheckBox1').disabled=false;
    document.getElementById('CheckBox2').disabled=false;
    document.getElementById('CheckBox3').disabled=false;
    document.getElementById('CheckBox4').disabled=false;
    document.getElementById('CheckBox5').disabled=false;
    document.getElementById('CheckBox6').disabled=false;
    document.getElementById('CheckBox7').disabled=false;
    document.getElementById('CheckBox8').disabled=false;*/
    flag = "0";
    setButtonImages();
    return false;
}
//*******************************************************************************//
//**************************This Function For Cancle Button*********************//
//*******************************************************************************//
function pcmcancel(formname) {
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

    //PubCatMast.blankSession();
    document.getElementById('hiddensubmod').value = "0";
    flag1 = "0";
    flag2 = "0";
    modify = "0";
    i = "0";
    chkstatus(FlagStatus);
    givebuttonpermission(formname);
    show = "0";
    document.getElementById('hiddensaurabh').value = "0";
    document.getElementById('btnNew').disabled=false;
    document.getElementById('btnSave').disabled=true;
    document.getElementById('btnModify').disabled=true;
    document.getElementById('btnDelete').disabled=true;
    document.getElementById('btnQuery').disabled=false;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnCancel').disabled=false;		
    document.getElementById('btnfirst').disabled=true;				
    document.getElementById('btnnext').disabled=true;					
    document.getElementById('btnprevious').disabled=true;			
    document.getElementById('btnlast').disabled=true;			
    document.getElementById('btnExit').disabled=false;

    document.getElementById('txtcentercode').value = "";
    document.getElementById('txtcentername').value = "";
    document.getElementById('txtalias').value = "";
    document.getElementById('txtadd1').value = "";
    document.getElementById('txtstreet').value = "";
    document.getElementById('drpcity').value = "0";
    document.getElementById('txtdistrict').value = "";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('txtphone1').value = "";
    document.getElementById('txtphone2').value = "";
    //document.getElementById('txtstatus1').value="";
    document.getElementById('txtpincode').value = "";
    document.getElementById('txtstate').value = "";
    document.getElementById('txtfax').value = "";
    document.getElementById('txtfax1').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtimgpath').value = "";
    document.getElementById('txtcir_imgpath').value = "";
    document.getElementById('txtlogofile').value = "";
    document.getElementById('dpstatebooking').value = "0";
    document.getElementById('txtmrv').value = "";
    document.getElementById('txtmessage').value = "";
    document.getElementById('po_update').value = "";
    document.getElementById('txtcut_time').value = "";
    //document.getElementById('txtstatusdate').value="";

    document.getElementById('txtintegration').value="";
    document.getElementById('txtBoxadd').value = "";
    document.getElementById('txtstatusreason').value = "";
    document.getElementById('drpprint').value = "N";
    document.getElementById('txtcomp_name').value = document.getElementById('hiddcompanyname').value;
    //-----Pankaj
    //document.getElementById('drpzone').value="";
    var len = document.getElementById('drpregion').options.length;
    for (i = 0; i < len; i++) {
        document.getElementById('drpregion').remove(0); //It is 0 (zero) intentionally
    }

    // document.getElementById('drpregion').value="0";

    var len = document.getElementById('drpzone').options.length;
    for (i = 0; i < len; i++) {
        document.getElementById('drpzone').remove(0); //It is 0 (zero) intentionally
    }
    // document.getElementById('drpzone').value="0";			

    document.getElementById('txtstatus1').style.visibility = "hidden";
    document.getElementById('txtstatusdate').style.visibility = "hidden";
    document.getElementById('lbStatus').style.visibility = "hidden";
    document.getElementById('lbStatusDate').style.visibility = "hidden";
    document.getElementById('txtcomp_name').disabled = true;
    document.getElementById('txtcentername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtimgpath').disabled = true;
    document.getElementById('txtcir_imgpath').disabled = true;
    //document.getElementById('txtfax1').disabled=true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('lbStatusDetail').disabled = true;
    document.getElementById('lbClientContactDetail').disabled = true;

    document.getElementById('txtBoxadd').disabled = true;
    document.getElementById('drpprint').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('txtlogofile').disabled = true;

    document.getElementById('dpstatebooking').disabled = true;
    document.getElementById('txtmrv').disabled = true;

    document.getElementById('po_update').disabled = true;
    document.getElementById('txtcut_time').value = "";
    document.getElementById('txtintegration').disabled = true;

    /*document.getElementById('CheckBox1').checked=false;
    document.getElementById('CheckBox2').checked=false;
    document.getElementById('CheckBox3').checked=false;
    document.getElementById('CheckBox4').checked=false;
    document.getElementById('CheckBox5').checked=false;
    document.getElementById('CheckBox6').checked=false;
    document.getElementById('CheckBox7').checked=false;
    document.getElementById('CheckBox8').checked=false;
						
    document.getElementById('CheckBox1').disabled=true;
    document.getElementById('CheckBox2').disabled=true;
    document.getElementById('CheckBox3').disabled=true;
    document.getElementById('CheckBox4').disabled=true;
    document.getElementById('CheckBox5').disabled=true;
    document.getElementById('CheckBox6').disabled=true;
    document.getElementById('CheckBox7').disabled=true;
    document.getElementById('CheckBox8').disabled=true;*/

    if (document.getElementById('btnNew').disabled == false)
        document.getElementById('btnNew').focus();
    //				var page="query";
    //		        var chk="query";
    //            	var xml = new ActiveXObject("Microsoft.XMLHTTP");
    //		        xml.Open( "GET","chkpubcatmast.aspx?page="+page+"&chk="+chk, false );
    //		        xml.Send();
    //		        var id=xml.responseText;

    //saurabh change

    //var contactperson=document.getElementById('txtcontactperson').value;
    //				//var txtdob=document.getElementById('txtdob').value;
    //				var txtphoneno=document.getElementById('txtphoneno').value;
    //				var txtext=document.getElementById('txtext').value;
    //				var txtfaxno=document.getElementById('txtfaxno').value;
    //				var mail=document.getElementById('txtemailid').value;
    //				
    //				

    var centcode = document.getElementById('hiddencentcode').value;



    //alert(browser);
    var dl = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null; ;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "contactnull.aspx?centcode=" + centcode, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == "yes") {
            alert('Session Expired.Please Login Again.');
            return false;
        }
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                dl = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
                return false;
            }
        }
        else {
            alert('Session Expired.Please Login Again.');
            return false;
        }
    }
    else {

        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "contactnull.aspx?centcode=" + centcode, false);
        xml.Send();
        dl = xml.responseText;
        //	            if(dl=="yes")
        //	            {
        //	                   alert('Session Expired.Please Login Again.');
        //                        return false;
        //	            }
    }
    setButtonImages();
    return false;
}
//*******************************************************************************//	
//**************************This Function For Save Button************************//
//*******************************************************************************//
function pcmsave() {

    //				if(a==1)
    //				{
    //					pcmchk();
    //					return false;
    //				}
    //				else
    //				{
    //					pcmsavemodify();
    //				return false;;
    ////        if(modify=="1")
    ////            {
    ////                pcmsavemodify();
    ////			    return false;
    ////            }
    ////        else
    ////            {
    ////                    pcmchk();
    ////					//return ;
    ////            }
    return;

}
//}
//*******************************************************************************//
//***********This Is For When U Click the Save Button for First Time*************//
//*******************************************************************************//
function pcmchk() {//debugger;
    document.getElementById('txtcentername').value = trim(document.getElementById('txtcentername').value);

    var sa = trim(document.getElementById('txtcentercode').value);
    var sa2 = trim(document.getElementById('txtcentername').value);
    var sa3 = trim(document.getElementById('txtalias').value);

    if (document.getElementById('hiddenauto').value != 1) {

        //                    var sa = trim(document.getElementById('txtcentercode').value);

        if (sa == "") {
            alert("Please enter Center Code");
            document.getElementById('txtcentercode').value == "";
            document.getElementById('txtcentercode').focus();
            return false;
        }
        //return false;
    }

    var bc = "";

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbcentername').textContent;
    }
    else {
        bc = document.getElementById('lbcentername').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtcentername').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtcentername').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbalias').textContent;
    }
    else {
        bc = document.getElementById('lbalias').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtalias').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtalias').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbCountry').textContent;
    }
    else {
        bc = document.getElementById('lbCountry').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtcountry').value) == "0") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtcountry').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbcity').textContent;
    }
    else {
        bc = document.getElementById('lbcity').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('drpcity').value) == "0") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('drpcity').focus();
            return false;
        }
    }

    var msg = ClientEmailCheck1("txtemailid");
    if (msg == false)
        return false;
    var compcode = document.getElementById('hiddencompcode').value;
    var centername = document.getElementById('txtcentername').value;
    var country = document.getElementById('txtcountry').value;
    var city = document.getElementById('drpcity').value;
    var userid = document.getElementById('hiddenuserid').value;
    var code = document.getElementById('txtcentercode').value;
    var statecode = document.getElementById('dpstatebooking').value;
    var poupdt = document.getElementById('po_update').value;

    var companyname = document.getElementById('txtcomp_name').value;
    var MRV = document.getElementById('txtmrv').value;
    var mes = document.getElementById('txtmessage').value;
    var BOOKING_CUTOF_TIME = document.getElementById('txtcut_time').value;
    
    var centername = centername;
    var city = city;



    if (modify == "1") {
        var dl = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

            httpRequest.open("GET", "chkpubcatmast1.aspx?centername=" + centername + "&city=" + city + "&modify=" + modify + "&code=" + code, false);
            httpRequest.send('');
            if (httpRequest.readyState == "yes") {
                alert('Session Expired Please Login Again.');
                return false;
            }
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) {
                    dl = httpRequest.responseText;
                }
                else {
                    alert('Session Expired.Please Login Again.');
                }
            }
            else {
                alert('Session Expired.Please Login Again.');
                return false;
            }

        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "chkpubcatmast1.aspx?centername=" + centername + "&city=" + city + "&modify=" + modify + "&code=" + code, false);
            xml.Send();
            dl = xml.responseText;
        }
        if (dl == "yes") {
            alert('Session Expired.Please Login Again.');
            return false;
        }

        if (dl == "Y") {
            alert("This Publication Center is already assigned");
            return false;
        }

        if (chknamemod == document.getElementById('txtcentername').value) {
            //updatestate();
            pcmsavemodify();
        }
        else {
            PubCatMast.chkpubname(document.getElementById('txtcentername').value, call_modifyclick);
            return false;
        }


        return false;
    }
    var dl = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null; ;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "chkpubcatmast1.aspx?centername=" + centername + "&city=" + city + "&modify=" + modify + "&code=" + code, false);
        httpRequest.send('');
        if (httpRequest.readyState == "yes") {
            alert('Session Expired Please Login Again.');
            return false;
        }
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                dl = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
            }
        }
        else {
            alert('Session Expired.Please Login Again.');
            return false;
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "chkpubcatmast1.aspx?centername=" + centername + "&city=" + city + "&modify=" + modify + "&code=" + code, false);
        xml.Send();
        dl = xml.responseText;
    }
    if (dl == "yes") {
        alert('Session Expired.Please Login Again.');
        return false;
    }

    if (dl == "Y") {

        alert("This city has been already assigned for this publication center");
        return false;


    }


    if (dl == "NO2") {
        alert("Please Fill the Contact detail Pop Up");
        return false;
    }

//    if (dl == "NO3") {
//        alert("Please Fill the Status detail Pop Up");
//        return false;
//    }


    var compcode = document.getElementById('hiddencompcode').value;
    var centercode = document.getElementById('txtcentercode').value;

    var centername = document.getElementById('txtcentername').value;
    document.getElementById('txtcentname').value = document.getElementById('txtcentername').value;

    var alias = document.getElementById('txtalias').value;
    document.getElementById('txtcentalias').value = document.getElementById('txtalias').value;

    var add1 = document.getElementById('txtadd1').value;
    document.getElementById('Street12').value = document.getElementById('txtadd1').value;

    var street = document.getElementById('txtstreet').value;
    document.getElementById('Street12').value = document.getElementById('txtstreet').value;

    var centercode = document.getElementById('txtcentercode').value;
    document.getElementById('txtcentcode').value = document.getElementById('txtcentercode').value;

    var dist = document.getElementById('txtdistrict').value;
    document.getElementById('district').value = document.getElementById('txtdistrict').value;

    var country = document.getElementById('txtcountry').value;
    document.getElementById('txtcountryname').value = document.getElementById('txtcountry').value;

    var city = document.getElementById('drpcity').value;
    document.getElementById('cityname').value = document.getElementById('drpcity').value;

    var phone1 = document.getElementById('txtphone1').value;
    document.getElementById('txtph1').value = document.getElementById('txtphone1').value;

    var phone2 = document.getElementById('txtphone2').value;
    document.getElementById('txtph2').value = document.getElementById('txtphone2').value;

    var status = document.getElementById('txtstatus1').value;

    var pin = document.getElementById('txtpincode').value;
    document.getElementById('txtpin').value = document.getElementById('txtpincode').value;

    var state = document.getElementById('txtstate').value;
    document.getElementById('Statecode12').value = document.getElementById('txtstate').value;

    var fax = document.getElementById('txtfax').value;
    document.getElementById('txtph2').value = document.getElementById('txtphone2').value;

    var fax1 = document.getElementById('txtfax1').value;
    document.getElementById('txtph2').value = document.getElementById('txtphone2').value;

    var email = document.getElementById('txtemailid').value;
    document.getElementById('email_id').value = document.getElementById('txtemailid').value;

    var dateformat = document.getElementById('hiddendateformat').value;
    var statusdate = document.getElementById('txtstatusdate').value;

    var remarks = document.getElementById('txtstatusreason').value;
    document.getElementById('txtremarks').value = document.getElementById('txtstatusreason').value;

    var userid = document.getElementById('hiddenuserid').value;

    var region = document.getElementById('drpregion').value;
    document.getElementById('txtregon').value = document.getElementById('drpregion').value;

    var zone = document.getElementById('drpzone').value;
    document.getElementById('txtzone').value = document.getElementById('drpzone').value;

    var boxaddress = document.getElementById('txtBoxadd').value;
    document.getElementById('boxadd').value = boxaddress;

    var imgpath = document.getElementById('txtimgpath').value;
    var cir_imgpath = document.getElementById('txtcir_imgpath').value;
    //		document.getElementById('txtremarks').value=document.getElementById('txtBoxadd').value;
    var logofilename = document.getElementById('txtlogofile').value;

    var companyname = document.getElementById('txtcomp_name').value;

    var statecode = document.getElementById('dpstatebooking').value;
    document.getElementById('state1').value = document.getElementById('dpstatebooking').value;

   // var poupdt = document.getElementById('po_update').value;
    var agcode = document.getElementById('Hiddenpub').value;
    var dpcode = document.getElementById('Hiddenpub1').value;

    //var statecode=document.getElementById('dpstatebooking').value;

    var integration = document.getElementById('txtintegration').value;

    if (dateformat == "dd/mm/yyyy") {
        var txt = document.getElementById('txtstatusdate').value;
        var txt1 = txt.split("/");
        var dd = txt1[0];
        var mm = txt1[1];
        var yy = txt1[2];
        var statusdate = mm + '/' + dd + '/' + yy;
    }

    if (dateformat == "mm/dd/yyyy") {
        var statusdate = document.getElementById('txtstatusdate').value;
    }

    if (dateformat == "yyyy/mm/dd") {
        var txt = document.getElementById('txtstatusdate').value;
        var txt1 = txt.split("/");
        var yy = txt1[0];
        var mm = txt1[1];
        var dd = txt1[2];
        var statusdate = mm + '/' + dd + '/' + yy;
    }

    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        var statusdate = document.getElementById('txtstatusdate').value;
    }

    //saurabhajax    
    //       PubCatMast.savepcm(compcode,centercode,centername,alias,add1,street,city,dist,country,phone1,phone2,pin,state,fax,email,remarks,userid,region,zone,statusdate)
    //             
    //                    pcmsavenew();
    var ip2 = document.getElementById('ip1').value;
    PubCatMast.savepcm(compcode, centercode, centername, alias, add1, street, city, dist, country, phone1, phone2, pin, state, fax, email, remarks, userid, region, zone, fax1, document.getElementById('boxadd').value, document.getElementById('drpprint').value, imgpath, cir_imgpath, companyname, logofilename, statecode, MRV, mes, agcode, dpcode, BOOKING_CUTOF_TIME,ip2,integration);



    //*********************************************************************************************************

    //********************************** for contact detail

    var contactperson = document.getElementById('hidden1').value;
    var dob = document.getElementById('hidden2').value;
    var desi = document.getElementById('hidden3').value;
    var phone = document.getElementById('hidden4').value;
    var ext = document.getElementById('hidden5').value;
    var fax = document.getElementById('hidden6').value;
    var email = document.getElementById('hidden7').value;
    var centcode = document.getElementById('hiddencrcd').value;
    var userid = document.getElementById('hiddenuid').value;
    var compcode = document.getElementById('hiddencpcd').value;

    var dl = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null; ;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "savecontact.aspx?contactperson=" + contactperson + "&dob=" + dob + "&desi=" + desi + "&phone=" + phone + "&ext=" + ext + "&fax=" + fax + "&email=" + email + "&userid=" + userid + "&centcode=" + centcode + "&compcode=" + compcode, false);
        httpRequest.send('');
        if (httpRequest.readyState == "yes") {
            alert('Session Expired Please Login Again.');
            return false;
        }
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                dl = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
            }
        }
        else {
            alert('Session Expired.Please Login Again.');
            return false;
        }

    }
    else {
        var xml1 = new ActiveXObject("Microsoft.XMLHTTP");
        xml1.Open("GET", "savecontact.aspx?contactperson=" + contactperson + "&dob=" + dob + "&desi=" + desi + "&phone=" + phone + "&ext=" + ext + "&fax=" + fax + "&email=" + email + "&userid=" + userid + "&centcode=" + centcode + "&compcode=" + compcode, false);
        // txtdob, desi, txtphoneno, txtext, txtfaxno, mail, userid, centercode, compcode);
        xml1.Send();
        dl = xml1.responseText;
    }

    //*********************************************************************************************************

    //********************************** for status detail


    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    //       var centcode =document.getElementById('hiddencentcode').value;
    var centcode = document.getElementById('hiddencrcds').value;


    //                  var status=document.getElementById('drpstatus').value;
    var status = document.getElementById('hidden2s').value;


    var dateformat = document.getElementById('hiddendateformat').value;

    //                  var circular=document.getElementById('txtCircular').value;
    var circular = document.getElementById('hidden4s').value;


    //                    var dateformat=dateformat;
    //                    var status=status;
    //                    var centcode=centcode;
    //                    var fdate=fromdate;
    //                    var todate=todate;
    //                    var circular=circular;
    var dateformat = "";
    var status = "";
    var centcode = centcode;
    var fdate = "";
    var todate = "";
    var circular = "";

    var dl = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null; ;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
        httpRequest.send('');
        if (httpRequest.readyState == "yes") {
            alert('Session Expired Please Login Again.');
            return false;
        }

        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                dl = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
            }
        }
        else {
            alert('Session Expired.Please Login Again.');
            return false;
        }

    }
    else {

        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
        xml.Send();
        dl = xml.responseText;
    }


    var fromdate = document.getElementById('hidden1s').value;
    var status = document.getElementById('hidden2s').value;
    var todate = document.getElementById('hidden3s').value;
    var circular = document.getElementById('hidden4s').value;

    //                var ext=document.getElementById('hidden5').value;
    //                var fax=document.getElementById('hidden6').value;
    var compcode = document.getElementById('hiddencpcds').value;
    var centercode = document.getElementById('hiddencrcds').value;
    var userid = document.getElementById('hiddenuids').value;

    var dateformat = document.getElementById('hiddendfs').value;



    //                if(dl=="N")     //saurabh gave
    //                {
    var compcode = document.getElementById('hiddencpcds').value;
    var userid = document.getElementById('hiddenuids').value;
    var centercode = document.getElementById('hiddencrcds').value;
    //     var status=document.getElementById('drpstatus').value;
    var dateformat = document.getElementById('hiddendfs').value;
    var circular = document.getElementById('hidden4s').value;

    var dl = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null; ;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "savestatus.aspx?centercode=" + centercode + "&userid=" + userid + "&dateformat=" + dateformat + "&compcode=" + compcode + "&fromdate=" + fromdate + "&status=" + status + "&todate=" + todate + "&circular=" + circular + "&circular=" + circular, false);
        httpRequest.send('');
        if (httpRequest.readyState == "yes") {
            alert('Session Expired Please Login Again.');
            return false;
        }
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                dl = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
            }
        }
        else {
            alert('Session Expired.Please Login Again.');
            return false;
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "savestatus.aspx?centercode=" + centercode + "&userid=" + userid + "&dateformat=" + dateformat + "&compcode=" + compcode + "&fromdate=" + fromdate + "&status=" + status + "&todate=" + todate + "&circular=" + circular + "&circular=" + circular, false);
        xml.Send();
        dl = xml.responseText;
    }

    //                }

    //alert-data saved successfully

    if (browser != "Microsoft Internet Explorer") {
        alert("Data Saved Successfully");
    }
    else {
        alert("Data Saved Successfully");
    }

    document.getElementById('hiddensaurabh').value = "0";

    var centcode = document.getElementById('hiddencentcode').value;

    var dl = "";
   
    if (browser != "Microsoft Internet Explorer") {
       
      
        var httpRequest = null; ;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

    
        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "contactnull.aspx?centcode=" + centcode, false);
        httpRequest.send('');
    
        if (httpRequest.readyState == "yes") {
            alert('Session Expired Please Login Again.');
            return false;
        }
       
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                dl = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
            }
        }
        else {
            alert('Session Expired.Please Login Again.');
            return false;
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "contactnull.aspx?centcode=" + centcode, false);
        xml.Send();
        dl = xml.responseText;
    }

    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = true;

    document.getElementById('txtcentercode').disabled = true;
    document.getElementById('txtcentername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('lbClientContactDetail').disabled = true;
    document.getElementById('lbStatusDetail').disabled = true;
    document.getElementById('drpprint').disabled = true;
    document.getElementById('txtimgpath').disabled = true;
    document.getElementById('txtcir_imgpath').disabled = true;
    document.getElementById('txtlogofile').disabled = true;
    document.getElementById('txtcomp_name').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtmessage').disabled = true;
    document.getElementById('txtintegration').disabled = true;
    
    
    document.getElementById('po_update').disabled = true;
    document.getElementById('txtcentercode').value = "";
 
    document.getElementById('txtcentername').value = "";
    document.getElementById('txtalias').value = "";
    document.getElementById('txtadd1').value = "";
    document.getElementById('txtstreet').value = "";
    document.getElementById('drpcity').value = "0";
    document.getElementById('txtdistrict').value = "";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('txtphone1').value = "";
    document.getElementById('txtphone2').value = "";
    document.getElementById('txtstatus1').value = "";
    document.getElementById('txtpincode').value = "";
    document.getElementById('txtstate').value = "";
    document.getElementById('txtfax').value = "";
    document.getElementById('txtfax1').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtstatusreason').value = "";
    document.getElementById('drpregion').options.length = 0;
    document.getElementById('drpzone').options.length = 0;
    document.getElementById('drpregion').value = "0";
    document.getElementById('drpzone').value = "0";
    document.getElementById('txtBoxadd').value = "";
    document.getElementById('txtimgpath').value = "";
    document.getElementById('txtcir_imgpath').value = "";
    document.getElementById('txtlogofile').value = "";
    document.getElementById('txtmrv').value = "";
    document.getElementById('txtmessage').value = "";
    document.getElementById('txtcut_time').value = "";
    document.getElementById('txtintegration').value = "";
    setButtonImages();
    return false;
}



//*******************************************************************************//

function call_modifyclick(response) {
    var compcode = document.getElementById('hiddencompcode').value;
    var centercode = document.getElementById('txtcentercode').value;
    var centername = document.getElementById('txtcentername').value;
    var alias = document.getElementById('txtalias').value;
    var add1 = document.getElementById('txtadd1').value;
    var street = document.getElementById('txtstreet').value;
    var city = document.getElementById('drpcity').value;
    var dist = document.getElementById('txtdistrict').value;
    var country = document.getElementById('txtcountry').value;
    var phone1 = document.getElementById('txtphone1').value;
    var phone2 = document.getElementById('txtphone2').value;
    //var status=document.getElementById('txtstatus1').value;
    var pin = document.getElementById('txtpincode').value;
    var state = document.getElementById('txtstate').value;
    var fax = document.getElementById('txtfax').value;
    var fax1 = document.getElementById('txtfax1').value;
    var email = document.getElementById('txtemailid').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    //var statusdate=document.getElementById('txtstatusdate').value;
    var remarks = document.getElementById('txtstatusreason').value;
    var userid = document.getElementById('hiddenuserid').value;

    var region = document.getElementById('drpregion').value;
    var zone = document.getElementById('drpzone').value;
    var boxadd = document.getElementById('txtBoxadd').value;
    //var sa=trim(document.getElementById('txtcentercode').value);
    var sa2 = trim(document.getElementById('txtcentername').value);
    var sa3 = trim(document.getElementById('txtalias').value);
    var integration = trim(document.getElementById('txtintegration').value);

    var ds = response.value;
    if (chknamemod != document.getElementById('txtcentername').value) {
        if (ds.Tables[2].Rows.length >= 1) {
            alert("This Center Name Already Exists.");
            document.getElementById('txtcentername').value = "";
            document.getElementById('txtalias').value = "";
            return false;
        }
        pcmsavemodify();
    }
}

//******************This Is The Responce Of The ModifySave Button****************//
//*******************************************************************************//
function pcmsavemodify() {

    var compcode = document.getElementById('hiddencompcode').value;
    var centercode = document.getElementById('txtcentercode').value;
    var centername = document.getElementById('txtcentername').value;
    var alias = trim(document.getElementById('txtalias').value);
    var add1 = trim(document.getElementById('txtadd1').value);
    var street = trim(document.getElementById('txtstreet').value);
    var city = document.getElementById('drpcity').value;
    var dist = document.getElementById('txtdistrict').value;
    var country = document.getElementById('txtcountry').value;
    var phone1 = document.getElementById('txtphone1').value;
    var phone2 = document.getElementById('txtphone2').value;
    //var status=document.getElementById('txtstatus1').value;
    var pin = document.getElementById('txtpincode').value;
    var state = document.getElementById('txtstate').value;
    var fax = document.getElementById('txtfax').value;
    var fax1 = document.getElementById('txtfax1').value;
    var email = document.getElementById('txtemailid').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    //var statusdate=document.getElementById('txtstatusdate').value;
    var remarks = trim(document.getElementById('txtstatusreason').value);
    var userid = document.getElementById('hiddenuserid').value;

    var region = document.getElementById('drpregion').value;
    var zone = document.getElementById('drpzone').value;
    var boxadd = document.getElementById('txtBoxadd').value;
    //var sa=trim(document.getElementById('txtcentercode').value);
    var sa2 = trim(document.getElementById('txtcentername').value);
    var sa3 = trim(document.getElementById('txtalias').value);
    var imgpath = trim(document.getElementById('txtimgpath').value);
    var cir_imgpath = trim(document.getElementById('txtcir_imgpath').value);
    var companyname = document.getElementById('txtcomp_name').value;
    var logofilename = document.getElementById('txtlogofile').value;
    //var state = document.getElementById('dpstatebooking').value;
    var MRV = document.getElementById('txtmrv').value;
    var mes = document.getElementById('txtmessage').value;
    var statecode = document.getElementById('dpstatebooking').value;

    if (dateformat == "dd/mm/yyyy") {
        var txt = document.getElementById('txtstatusdate').value;
        var txt1 = txt.split("/");
        var dd = txt1[0];
        var mm = txt1[1];
        var yy = txt1[2];
        var statusdate = mm + '/' + dd + '/' + yy;
    }

    if (dateformat == "mm/dd/yyyy") {
        var statusdate = document.getElementById('txtstatusdate').value;
    }

    if (dateformat == "yyyy/mm/dd") {
        var txt = document.getElementById('txtstatusdate').value;
        var txt1 = txt.split("/");
        var yy = txt1[0];
        var mm = txt1[1];
        var dd = txt1[2];
        var statusdate = mm + '/' + dd + '/' + yy;
    }

    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        var statusdate = document.getElementById('txtstatusdate').value;
    }

    //		    if(document.getElementById('hiddenauto').value!=1)
    //                {


    //saurabh Change

    if (document.getElementById('hiddenauto').value != 1) {

        var sa = trim(document.getElementById('txtcentercode').value);

        if (sa == "") {
            alert("Please enter center name");
            document.getElementById('txtcentercode').value == "";
            document.getElementById('txtcentercode').focus();
            return false;
        }
        //return false;
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbcentername').textContent;
    }
    else {
        bc = document.getElementById('lbcentername').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtcentername').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtcentername').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbalias').textContent;
    }
    else {
        bc = document.getElementById('lbalias').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtalias').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtalias').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbCountry').textContent;
    }
    else {
        bc = document.getElementById('lbCountry').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtcountry').value) == "0") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtcountry').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbcity').textContent;
    }
    else {
        bc = document.getElementById('lbcity').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('drpcity').value) == "0") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('drpcity').focus();
            return false;
        }
    }
    var BOOKING_CUTOF_TIME = document.getElementById('txtcut_time').value;
    var ip2 = document.getElementById('ip1').value;
    var agcode = document.getElementById('Hiddenpub').value;
    var dpcode = document.getElementById('Hiddenpub1').value;
    var integration = document.getElementById('txtintegration').value;
    PubCatMast.updatepcm(compcode, centercode, centername, alias, add1, street, city, dist, country, phone1, phone2, pin, state, fax, email, remarks, userid, region, zone, fax1, boxadd, document.getElementById('drpprint').value, ip2, imgpath, cir_imgpath, companyname, logofilename, statecode, MRV, mes, agcode, dpcode, BOOKING_CUTOF_TIME,  integration);



    //global_ds=global_ds.value;

    global_ds.Tables[0].Rows[z].Pub_cent_Code = document.getElementById('txtcentercode').value;
    global_ds.Tables[0].Rows[z].PRINT_CENT = document.getElementById('drpprint').value;
    global_ds.Tables[0].Rows[z].Pub_Cent_name = document.getElementById('txtcentername').value;
    // saurabh change					global_ds.Tables[0].Rows[0].Pub_Cent_name=document.getElementById('txtalias').value;

    global_ds.Tables[0].Rows[z].Pub_Cent_Alias = document.getElementById('txtalias').value;

    global_ds.Tables[0].Rows[z].Remarks = document.getElementById('txtstatusreason').value;
    global_ds.Tables[0].Rows[z].street = document.getElementById('txtstreet').value;
    global_ds.Tables[0].Rows[z].Dist_Code = document.getElementById('txtdistrict').value;
    global_ds.Tables[0].Rows[z].Country_Code = document.getElementById('txtcountry').value;



    global_ds.Tables[0].Rows[z].Region_code = document.getElementById('drpregion').value;
    global_ds.Tables[0].Rows[z].Zone_code = document.getElementById('drpzone').value;
    global_ds.Tables[0].Rows[z].Phone1 = document.getElementById('txtphone1').value;
    global_ds.Tables[0].Rows[z].Phone2 = document.getElementById('txtphone2').value;
    global_ds.Tables[0].Rows[z].zip = document.getElementById('txtpincode').value;
    global_ds.Tables[0].Rows[z].Fax = document.getElementById('txtfax').value;
    global_ds.Tables[0].Rows[z].EmailID = document.getElementById('txtemailid').value;
    global_ds.Tables[0].Rows[z].Fax1 = document.getElementById('txtfax1').value;
    global_ds.Tables[0].Rows[z].Status_date = document.getElementById('txtstatusdate').value;
    global_ds.Tables[0].Rows[z].Pub_Cent_Status = document.getElementById('txtstatus1').value;
    global_ds.Tables[0].Rows[z].FILE_PATH = document.getElementById('txtimgpath').value;
    global_ds.Tables[0].Rows[z].CIR_FILE_PATH = document.getElementById('txtcir_imgpath').value;
    global_ds.Tables[0].Rows[z].LOGO_FILE_PATH = document.getElementById('txtlogofile').value;
    global_ds.Tables[0].Rows[z].INTEGRATION_ID = document.getElementById('txtintegration').value;
    document.getElementById('hiddensaurabh').value = "0";

    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnModify').disabled = false;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = false;
    document.getElementById('btnlast').disabled = false;

    document.getElementById('txtcentercode').disabled = true;
    document.getElementById('txtcentername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('txtintegration').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtcomp_name').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtBoxadd').disabled = true;
    document.getElementById('drpprint').disabled = true;
    document.getElementById('txtimgpath').disabled = true;
    document.getElementById('txtlogofile').disabled = true;
    document.getElementById('txtcir_imgpath').disabled = true;
    document.getElementById('dpstatebooking').disabled = true;
    document.getElementById('txtmrv').disabled = true;
    document.getElementById('po_update').disabled = true;


    if (modify == "1") {
        show = "0";
    }

    //			document.getElementById('CheckBox1').disabled=true;
    //			document.getElementById('CheckBox2').disabled=true;
    //			document.getElementById('CheckBox3').disabled=true;
    //			document.getElementById('CheckBox4').disabled=true;
    //			document.getElementById('CheckBox5').disabled=true;
    //			document.getElementById('CheckBox6').disabled=true;
    //			document.getElementById('CheckBox7').disabled=true;
    //			document.getElementById('CheckBox8').disabled=true;

    //alert("value updated");
    if (browser != "Microsoft Internet Explorer") {
        alert("Data Updated Successfully");
    }
    else {
        alert("Data Updated Successfully");
    }
    flag = 0;

    document.getElementById('txtmessage').disabled = true;
    //document.getElementById('txtcut_time').disabled = true;
    updateStatus();


    if (document.getElementById('btnModify').disabled == false)
        document.getElementById('btnModify').focus();

    if (z == 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
    }

    if (z == (global_ds.Tables[0].Rows.length - 1)) {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        //document.getElementById('btnModify').disabled=true;
    }
    setButtonImages(); 	                    //document.getElementById('btnModify').focus();

    return false;
}
//*******************************************************************************//
//**********************This Function For The Modify Button**********************//
//*******************************************************************************//
function pcmmodify() {
    //	z=2;
    flag1 = "1";
    flag2 = "1";
    document.getElementById('hiddensaurabh').value = "modify";
    chknamemod = document.getElementById('txtcentername').value;
    show = "2";
    modify = "1";
    document.getElementById('hiddensubmod').value = "1";
    document.getElementById('hiddenchk').value = "1";
    document.getElementById('txtcentercode').disabled = true;
    document.getElementById('txtcentername').disabled = false;
    document.getElementById('txtalias').disabled = false;
    document.getElementById('txtadd1').disabled = false;
    document.getElementById('txtstreet').disabled = false;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('txtphone1').disabled = false;
    document.getElementById('txtphone2').disabled = false;
    document.getElementById('txtstatusreason').disabled = false;
    document.getElementById('hiddenchk').value = "1";
    document.getElementById('drpregion').disabled = false;
    document.getElementById('drpzone').disabled = false;
    document.getElementById('txtcomp_name').disabled = false;

    document.getElementById('txtcut_time').disabled = false;

    document.getElementById('po_update').disabled = false;

    document.getElementById('dpstatebooking').disabled = false;
    document.getElementById('txtmrv').disabled = false;
    document.getElementById('txtmessage').disabled = false;

    //document.getElementById('drpregion').value="0";
    //document.getElementById('drpzone').value="0";

    document.getElementById('txtpincode').disabled = false;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = false;
    document.getElementById('txtfax1').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtBoxadd').disabled = false;
    document.getElementById('drpprint').disabled = false;
    document.getElementById('txtimgpath').disabled = false;
    document.getElementById('txtcir_imgpath').disabled = false;
    document.getElementById('txtlogofile').disabled = false;
    document.getElementById('txtintegration').disabled = false;
   // document.getElementById('po_update').disabled = false;
    //			document.getElementById('txtstatus1').style.visibility="hidden";
    //			document.getElementById('txtstatusdate').style.visibility="hidden";
    //			document.getElementById('lbStatus').style.visibility="hidden";
    //			document.getElementById('lbStatusDate').style.visibility="hidden";

    document.getElementById('btnNew').disabled=true;
    document.getElementById('btnSave').disabled=false;
    document.getElementById('btnModify').disabled=true;
    document.getElementById('btnDelete').disabled=true;
    document.getElementById('btnQuery').disabled=true;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnCancel').disabled=false;		
    document.getElementById('btnfirst').disabled=true;				
    document.getElementById('btnnext').disabled=true;					
    document.getElementById('btnprevious').disabled=true;			
    document.getElementById('btnlast').disabled=true;	
    document.getElementById('btnExit').disabled=false;
    document.getElementById('btnDelete').disabled = true;

    //          document.getElementById('CheckBox1').disabled=false;
    //			document.getElementById('CheckBox2').disabled=false;
    //			document.getElementById('CheckBox3').disabled=false;
    //			document.getElementById('CheckBox4').disabled=false;
    //			document.getElementById('CheckBox5').disabled=false;
    //			document.getElementById('CheckBox6').disabled=false;
    //			document.getElementById('CheckBox7').disabled=false;
    //			document.getElementById('CheckBox8').disabled=false;

    /*document.getElementById('CheckBox1').disabled=false;
    document.getElementById('CheckBox2').disabled=false;
    document.getElementById('CheckBox3').disabled=false;
    document.getElementById('CheckBox4').disabled=false;
    document.getElementById('CheckBox5').disabled=false;
    document.getElementById('CheckBox6').disabled=false;
    document.getElementById('CheckBox7').disabled=false;
    document.getElementById('CheckBox8').disabled=false;*/

    chkstatus(FlagStatus);
    //document.getElementById('btnModify').disabled=true;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    hiddentext = "modify";


    flag = 1;

    //var co=document.getElementById('txtcountry').value;
    //				addcount(co);


    //saurabh change************************************
    //		var gag=document.getElementById('hiddendelsau').value;
    //		gau="0";

    //**************************************************
    //document.getElementById('txtcentername').focus();
    setButtonImages();
    document.getElementById('btnSave').focus();

    return false;
}

//*******************************************************************************//
//**********************This Function For The Execute Button*********************//
//*******************************************************************************//

function pcmexecute() {
    var compcode = document.getElementById('hiddencompcode').value;
    var centcode = document.getElementById('txtcentercode').value;
    var centname = document.getElementById('txtcentername').value;
    var alias = document.getElementById('txtalias').value;
    var city = document.getElementById('drpcity').value;

    var country = document.getElementById('txtcountry').value;
    var region = document.getElementById('drpregion').value;
    var zone = document.getElementById('drpzone').value;
    var state = document.getElementById('dpstatebooking').value;
    var MRV = document.getElementById('txtmrv').value;
    var mes = document.getElementById('txtmessage').value;

   // var poupdt = document.getElementById('po_update').value;
   


    var agcode = document.getElementById('Hiddenpub').value;
    var dpcode = document.getElementById('Hiddenpub1').value;

    document.getElementById('hiddensaurabh').value = "0";

    document.getElementById('hiddensubmod').value = "0";

    gbcentcode = centcode;
    gbcentname = centname;
    gbalias = alias;
    gbcity = city;
    gbcountry = country;
    //		gbregion=region;
    //		gbzone=zone;
    //alert("ok");
    var dateformat = document.getElementById('hiddendateformat').value;
    var userid = document.getElementById('hiddenuserid').value;
    var companyname = document.getElementById('txtcomp_name').value;
    //PubCatMast.exepcm(compcode,centcode,centname,alias,city,userid,exepcmcall,country,region,zone)

    var resexe = PubCatMast.exepcm(compcode, centcode, centname, alias, country, city, companyname, state, MRV, agcode, dpcode);
    exepcmcall(resexe);

    document.getElementById('txtstatus1').style.visibility = "visible";
    document.getElementById('txtstatusdate').style.visibility = "visible";
    document.getElementById('lbStatus').style.visibility = "visible";
    document.getElementById('lbStatusDate').style.visibility = "visible";
    document.getElementById('dpstatebooking').style.visibility = "visible";


    document.getElementById('btnNew').disabled=true;
    document.getElementById('btnSave').disabled=true;
    document.getElementById('btnModify').disabled=false;
    document.getElementById('btnDelete').disabled=true;
    document.getElementById('btnQuery').disabled=false;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnCancel').disabled=false;		
    document.getElementById('btnfirst').disabled=true;				
    document.getElementById('btnnext').disabled=false;					
    document.getElementById('btnprevious').disabled=true;			
    document.getElementById('btnlast').disabled=false;	
    document.getElementById('btnExit').disabled=false;
    document.getElementById('btnDelete').disabled = false;
    
    document.getElementById('txtcentercode').disabled = true;
    document.getElementById('txtcentername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    //alert('fedfe');
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtBoxadd').disabled = true;
    document.getElementById('drpprint').disabled = true;
    document.getElementById('txtimgpath').disabled = true;
    document.getElementById('txtcir_imgpath').disabled = true;
    document.getElementById('txtcomp_name').disabled = true;
    document.getElementById('txtcut_time').disabled = true;
    document.getElementById('po_update').disabled = true;
    document.getElementById('txtintegration').disabled = true;
    updateStatus();
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;
    setButtonImages();
    if (document.getElementById('btnModify').disabled == false)
        document.getElementById('btnModify').focus();

    gag = "0";
    return false;
}

function get_agency_name(agcd_code, dpcd_code) 

{

    var compcode = document.getElementById('hiddencompcode').value;
    var unit = document.getElementById('hdnunit').value;
    var get_agname = PubCatMast.get_ag_name(compcode, unit, agcd_code, dpcd_code);
    /*if (get_agname.value.Tables[0].Rows.length > 0) {

        document.getElementById('po_update').value = get_agname.value.Tables[0].Rows[0].AG_NAME;
    }
    else {*/
        document.getElementById('po_update').value = "";
    //}
}


//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//
function exepcmcall(response) {
   // alert('1')

    global_ds = response.value;
    
    if (global_ds == null) {
        alert(response.error.description);
        return false;
    }
   // alert(global_ds.Tables[0].Rows.length )
    if (global_ds.Tables[0].Rows.length > 0) {
        document.getElementById('lbClientContactDetail').disabled = false;
        document.getElementById('lbStatusDetail').disabled = false;

     //  alert('2')
        document.getElementById('txtcentercode').value = global_ds.Tables[0].Rows[0].Pub_cent_Code;
        document.getElementById('drpprint').value = global_ds.Tables[0].Rows[0].PRINT_CENT;
        document.getElementById('txtcentername').value = global_ds.Tables[0].Rows[0].Pub_Cent_name;
        document.getElementById('txtalias').value = global_ds.Tables[0].Rows[0].Pub_Cent_Alias;
       // alert(global_ds.Tables[0].Rows[0].CIR_PO_UPD_AGCD);
        document.getElementById('Hiddenpub').value = global_ds.Tables[0].Rows[0].CIR_PO_UPD_AGCD;
       // alert(document.getElementById('Hiddenpub').value)
        document.getElementById('Hiddenpub1').value = global_ds.Tables[0].Rows[0].CIR_PO_UPD_DPCD;
        get_agency_name(document.getElementById('Hiddenpub').value, document.getElementById('Hiddenpub1').value)
        
        
        if (global_ds.Tables[0].Rows[0].FILE_PATH != null) {
            document.getElementById('txtimgpath').value = global_ds.Tables[0].Rows[0].FILE_PATH;
        }
        else {
            document.getElementById('txtimgpath').value = "";
        }
        if (global_ds.Tables[0].Rows[0].LOGO_FILE_PATH != null)
            document.getElementById('txtlogofile').value = global_ds.Tables[0].Rows[0].LOGO_FILE_PATH;
        else
            document.getElementById('txtlogofile').value = "";

        if (global_ds.Tables[0].Rows[0].CIR_FILE_PATH != null) {
            document.getElementById('txtcir_imgpath').value = global_ds.Tables[0].Rows[0].CIR_FILE_PATH;
        }
        else {
            document.getElementById('txtcir_imgpath').value = "";
        }



        if (global_ds.Tables[0].Rows[0].center_comp_name != null) {
            document.getElementById('txtcomp_name').value = global_ds.Tables[0].Rows[0].center_comp_name;
        }
        else {
            document.getElementById('txtcomp_name').value = "";
        }

        if (global_ds.Tables[0].Rows[0].Remarks == "" || global_ds.Tables[0].Rows[0].Remarks == null || global_ds.Tables[0].Rows[0].Remarks == "Undefined") {
            document.getElementById('txtstatusreason').value = "";
        }
        else {
            document.getElementById('txtstatusreason').value = global_ds.Tables[0].Rows[0].Remarks;
        }

        if (global_ds.Tables[0].Rows[0].Add1 == "" || global_ds.Tables[0].Rows[0].Add1 == null || global_ds.Tables[0].Rows[0].Add1 == "undefined") {
            document.getElementById('txtadd1').value = "";
        }
        else {
            document.getElementById('txtadd1').value = global_ds.Tables[0].Rows[0].Add1;
        }

        if (global_ds.Tables[0].Rows[0].street == "" || global_ds.Tables[0].Rows[0].street == null || global_ds.Tables[0].Rows[0].street == "undefined") {
            document.getElementById('txtstreet').value = "";
        }
        else {
            document.getElementById('txtstreet').value = global_ds.Tables[0].Rows[0].street;
        }

        //document.getElementById('drpcity').value=ds.Tables[0].Rows[0].City_Code;

        document.getElementById('txtcountry').value = global_ds.Tables[0].Rows[0].Country_Code;

        cityvar = global_ds.Tables[0].Rows[0].City_Code;
        document.getElementById('drpcity').value = cityvar;
        addcount(global_ds.Tables[0].Rows[0].Country_Code);
        document.getElementById('drpcity').disabled = true;

        if (global_ds.Tables[0].Rows[0].Dist_Code == null || global_ds.Tables[0].Rows[0].Dist_Code == "null") {
            document.getElementById('txtdistrict').value = "";

        }
        else {
            document.getElementById('txtdistrict').value = global_ds.Tables[0].Rows[0].Dist_Code;
        }
        document.getElementById('drpregion').value = global_ds.Tables[0].Rows[0].Region_code;
        document.getElementById('drpzone').value = global_ds.Tables[0].Rows[0].Zone_code;


        if (global_ds.Tables[0].Rows[0].Phone1 == "" || global_ds.Tables[0].Rows[0].Phone1 == null || global_ds.Tables[0].Rows[0].Phone1 == "undefined") {
            document.getElementById('txtphone1').value = "";
        }
        else {
            document.getElementById('txtphone1').value = global_ds.Tables[0].Rows[0].Phone1;
        }

        if (global_ds.Tables[0].Rows[0].Phone2 == "" || global_ds.Tables[0].Rows[0].Phone2 == null || global_ds.Tables[0].Rows[0].Phone2 == "undefined") {
            document.getElementById('txtphone2').value = "";

        }
        else {
            document.getElementById('txtphone2').value = global_ds.Tables[0].Rows[0].Phone2;
        }
        //document.getElementById('txtstatus1').value=ds.Tables[0].Rows.;

        if (global_ds.Tables[0].Rows[0].zip == "" || global_ds.Tables[0].Rows[0].zip == null || global_ds.Tables[0].Rows[0].zip == "undefined") {
            document.getElementById('txtpincode').value = "";
        }
        else {
            document.getElementById('txtpincode').value = global_ds.Tables[0].Rows[0].zip;
        }

        document.getElementById('txtstate').value = global_ds.Tables[0].Rows[0].State_Code;

        if (global_ds.Tables[0].Rows[0].Fax == "" || global_ds.Tables[0].Rows[0].Fax == null || global_ds.Tables[0].Rows[0].Fax == "undefined") {
            document.getElementById('txtfax').value = "";
        }
        else {
            document.getElementById('txtfax').value = global_ds.Tables[0].Rows[0].Fax;
        }

        if (global_ds.Tables[0].Rows[0].EmailID == "" || global_ds.Tables[0].Rows[0].EmailID == null || global_ds.Tables[0].Rows[0].EmailID == "Undefined") {
            document.getElementById('txtemailid').value = "";
        }
        else {
            document.getElementById('txtemailid').value = global_ds.Tables[0].Rows[0].EmailID;
        }

        if (global_ds.Tables[0].Rows[0].Fax1 != null) {
            document.getElementById('txtfax1').value = global_ds.Tables[0].Rows[0].Fax1;
        }
        else {
            document.getElementById('txtfax1').value = "";
        }

        if (global_ds.Tables[0].Rows[0].BOXADDRESS != null) {
            document.getElementById('txtBoxadd').value = global_ds.Tables[0].Rows[0].BOXADDRESS;
        }
        else {
            document.getElementById('txtBoxadd').value = "";
        }


        if (global_ds.Tables[0].Rows[0].STATE != null) {
            document.getElementById('dpstatebooking').value = global_ds.Tables[0].Rows[0].STATE;
        }
        else {
            document.getElementById('dpstatebooking').value = "";
        }

        if (global_ds.Tables[0].Rows[0].MRV_MEMBER_CODE != null) {
            document.getElementById('txtmrv').value = global_ds.Tables[0].Rows[0].MRV_MEMBER_CODE;
        }
        else {
            document.getElementById('txtmrv').value = "";
        }

        if (global_ds.Tables[0].Rows[0].MESSAGE != null) {
            document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[0].MESSAGE;
        }
        else {
            document.getElementById('txtmessage').value;
        }



        var dateformat = document.getElementById('hiddendateformat').value;
        document.getElementById('txtstatusdate').value = global_ds.Tables[0].Rows[0].Status_date;

        if (global_ds.Tables[0].Rows[0].BOOKING_CUTOF_TIME != null) {
            document.getElementById('txtcut_time').value = global_ds.Tables[0].Rows[0].BOOKING_CUTOF_TIME;
        }
        else {
            document.getElementById('txtcut_time').value = "";
        }
        if (global_ds.Tables[0].Rows[0].INTEGRATION_ID != null) {
            document.getElementById('txtintegration').value = global_ds.Tables[0].Rows[0].INTEGRATION_ID;
        }
        else {
            document.getElementById('txtintegration').value = "";
        }
        var tdate2 = global_ds.Tables[0].Rows[0].Status_date;
        var tdate = new Date(tdate2);
        var dd = tdate.getDate();
        var mm = tdate.getMonth() + 1;
        var yyyy = tdate.getFullYear();
        if (dateformat == "dd/mm/yyyy") {
            tdate = dd + '/' + mm + '/' + yyyy;
        }
        else if (dateformat == "mm/dd/yyyy") {
            tdate = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "yyyy/mm/dd") {
            tdate = yyyy + '/' + mm + '/' + dd;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            tdate = mm + '/' + dd + '/' + yyyy;
        }

        //var ttdate = new Date(tdate);
        var ttdate = tdate;

        document.getElementById('txtstatusdate').value = tdate;
        var tdate1 = global_ds.Tables[0].Rows[0].To_date;
        var cdate = new Date(tdate1);

        var dd1 = cdate.getDate();
        var mm1 = cdate.getMonth() + 1;
        var yyyy1 = cdate.getFullYear();
        if (dateformat == "dd/mm/yyyy") {
            cdate = dd1 + '/' + mm1 + '/' + yyyy1;
        }
        else if (dateformat == "mm/dd/yyyy") {
            cdate = mm1 + '/' + dd1 + '/' + yyyy1;
        }
        else if (dateformat == "yyyy/mm/dd") {
            cdate = yyyy1 + '/' + mm1 + '/' + dd1;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            cdate = mm1 + '/' + dd1 + '/' + yyyy1;
        }

        var ccdate = new Date(cdate);


        if (global_ds.Tables[0].Rows[0].Pub_Cent_Status == null || global_ds.Tables[0].Rows[0].Pub_Cent_Status == "")
            document.getElementById('txtstatus1').value = "Active";
        else
            document.getElementById('txtstatus1').value = global_ds.Tables[0].Rows[0].Pub_Cent_Status;

        /*	if (tdate2>tdate1)
        { 
        if(cdate<=tdate)
        {
        document.getElementById('txtstatus1').value="Active";
					   
        }
        else
        {
        document.getElementById('txtstatus1').value="Banned";
        }
        }
        else
        {
        if(global_ds.Tables[0].Rows[0].pub_cent_status == null)
        document.getElementById('txtstatus1').value="Active";
        else
        document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[0].pub_cent_status;
        //document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[0].Pub_Cent_Status;
        }*/
        if (cityvar != null) {
            PubCatMast.addreg(cityvar, FillDropDownList_CallBackMaindoc);
        }
        //				   if(tdate>=cdate)
        //					  {
        //					    document.getElementById('txtstatus1').value="Active";
        //					  }

        //return false;
    }

    else {
        alert("Your search criteria does not exist");
        pcmcancel('PubCatMast');
        return false;
    }

    document.getElementById('btnfirst').disabled=true;				
    document.getElementById('btnnext').disabled=false;					
    document.getElementById('btnprevious').disabled=true;			
    document.getElementById('btnlast').disabled=false;	
    document.getElementById('lbClientContactDetail').disabled=false;
    document.getElementById('lbStatusDetail').disabled=false;
    //						document.getElementById('lbClientContactDetail').disabled=false;
    //                        document.getElementById('lbStatusDetail').disabled=false;


    if (global_ds.Tables[0].Rows.length == 1) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('lbClientContactDetail').disabled = false;
        document.getElementById('lbStatusDetail').disabled = false;



    }
    setButtonImages();
    return false;
}


//*******************************************************************************//
//**********************This Function For The Query Button***********************//
//*******************************************************************************//

function pcmquery() {
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

    PubCatMast.blankSession();
    saurabh_clear = "1";
    saurabh = 0;  // saurabh change
    saurabh_agarwal = 0;
    z = 0;
    show = "0";

    
    
    document.getElementById('hiddensubmod').value = "0";
    document.getElementById('hiddensaurabh').value = "0";

    document.getElementById('Hiddenpub').value = "";
    document.getElementById('Hiddenpub1').value = "";

    document.getElementById('txtcentercode').value = "";
    document.getElementById('txtlogofile').value = "";
    document.getElementById('txtcentername').value = "";
    document.getElementById('txtalias').value = "";
    document.getElementById('txtadd1').value = "";
    document.getElementById('txtstreet').value = "";
    document.getElementById('drpcity').value = "0";
    document.getElementById('txtdistrict').value = "";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('txtphone1').value = "";
    document.getElementById('txtphone2').value = "";
    //document.getElementById('txtstatus1').value="";
    document.getElementById('txtpincode').value = "";
    document.getElementById('txtstate').value = "";
    document.getElementById('txtfax').value = "";
    document.getElementById('txtfax1').value = "";

    document.getElementById('po_update').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtstatusreason').value = "";
    document.getElementById('drpregion').value = "0";
    document.getElementById('drpzone').value = "0";
    document.getElementById('txtBoxadd').value = "";
    document.getElementById('txtimgpath').value = "";
    document.getElementById('txtcir_imgpath').value = "";
    document.getElementById('txtcomp_name').value = "";
    document.getElementById('txtstatus1').style.visibility = "hidden";
    document.getElementById('txtstatusdate').style.visibility = "hidden";
    document.getElementById('lbStatus').style.visibility = "hidden";
    document.getElementById('lbStatusDate').style.visibility = "hidden";
    document.getElementById('hiddencompcode').style.visibility = "hidden";
    document.getElementById('hiddenuserid').style.visibility = "hidden";
    document.getElementById('txtmessage').style.visibility = "";

    document.getElementById('txtcomp_name').disabled = false;
    document.getElementById('txtcentercode').disabled = false;
    document.getElementById('txtcentername').disabled = false;
    document.getElementById('txtalias').disabled = false;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtintegration').disabled = true;
    //					document.getElementById('lbStatusDetail').disabled=false;
    //			        document.getElementById('lbClientContactDetail').disabled=false;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtimgpath').disabled = true;
    document.getElementById('txtcir_imgpath').disabled = true;
    document.getElementById('txtlogofile').disabled = true;
    document.getElementById('txtmessage').disabled = true;

    //document.getElementById('txtcut_time').disabled = true;
    
    document.getElementById('po_update').disabled = true;

    chkstatus(FlagStatus);

    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnSave').disabled = true;
    hiddentext = "query";

    document.getElementById('btnQuery').disabled=true;
    document.getElementById('btnExecute').disabled=false;
    document.getElementById('btnSave').disabled=true;
    //document.getElementById('btnnew').disabled=true;
    document.getElementById('btnDelete').disabled=true;

    //document.getElementById('CheckBox1').disabled=true;
    //document.getElementById('CheckBox2').disabled=true;
    //document.getElementById('CheckBox3').disabled=true;
    //document.getElementById('CheckBox4').disabled=true;
    //document.getElementById('CheckBox5').disabled=true;
    //document.getElementById('CheckBox6').disabled=true;
    //document.getElementById('CheckBox7').disabled=true;
    //document.getElementById('CheckBox8').disabled=true;

    //document.getElementById('CheckBox1').checked=false;
    //document.getElementById('CheckBox2').checked=false;
    //document.getElementById('CheckBox3').checked=false;
    //document.getElementById('CheckBox4').checked=false;
    //document.getElementById('CheckBox5').checked=false;
    //document.getElementById('CheckBox6').checked=false;
    //document.getElementById('CheckBox7').checked=false;
    //document.getElementById('CheckBox8').checked=false;

    document.getElementById('btnNew').disabled=true;
    document.getElementById('btnSave').disabled=true;
    document.getElementById('btnModify').disabled=true;
    document.getElementById('btnDelete').disabled=true;
    document.getElementById('btnQuery').disabled=true;
    document.getElementById('btnExecute').disabled=false;
    document.getElementById('btnCancel').disabled=false;		
    document.getElementById('btnfirst').disabled=true;				
    document.getElementById('btnnext').disabled=true;					
    document.getElementById('btnprevious').disabled=true;			
    document.getElementById('btnlast').disabled=true;			
    document.getElementById('btnExit').disabled=false;
    document.getElementById('btnDelete').disabled = true;


    document.getElementById('lbClientContactDetail').disabled = true;
    document.getElementById('lbStatusDetail').disabled = true;

    document.getElementById('btnExecute').focus();
    var centcode = document.getElementById('hiddencentcode').value;

    var dl = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null; ;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "contactnull.aspx?centcode=" + centcode, false);
        httpRequest.send('');

        if (httpRequest.readyState == "yes") {
            alert('Session Expired Please Login Again.');
            return false;
        }
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                dl = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
            }
        }
        else {
            alert('Session Expired.Please Login Again.');
            return false;
        }
    }
    else {

        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "contactnull.aspx?centcode=" + centcode, false);
        xml.Send();
        dl = xml.responseText;
    }




    document.getElementById('lbClientContactDetail').disabled = true;
    document.getElementById('lbStatusDetail').disabled = true;
    setButtonImages();
    document.getElementById('btnExecute').focus();


    return false;

}

//*******************************************************************************//
//***********************This Function For The First Button**********************//
//*******************************************************************************//

function pcmfirst() {
    z = 0;
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

    PubCatMast.blankSession();
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    //	PubCatMast.fnplclick(compcode,userid)//,firstcall)

    document.getElementById('txtcentercode').disabled = true;
    document.getElementById('txtcentername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtimgpath').disabled = true;
    document.getElementById('txtcir_imgpath').disabled = true;
    document.getElementById('txtlogofile').disabled = true;
    document.getElementById('dpstatebooking').disabled = true;
    document.getElementById('txtmrv').disabled = true;
    document.getElementById('txtmessage').disabled = true;
    document.getElementById('txtintegration').disabled = true;
    //document.getElementById('txtcut_time').disabled = true;

    document.getElementById('po_update').disabled = true;
    updateStatus();

    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnExit').disabled = false;



    //		return false;
    //		}
    //		
    ////*******************************************************************************//
    ////********************This Is The Responce Of The First Button*******************//
    ////*******************************************************************************//		
    //		function firstcall(response)
    //		{

    // ds=response.value;


    document.getElementById('Hiddenpub').value = global_ds.Tables[0].Rows[0].CIR_PO_UPD_AGCD;
    document.getElementById('Hiddenpub1').value = global_ds.Tables[0].Rows[0].CIR_PO_UPD_DPCD;
    get_agency_name(document.getElementById('Hiddenpub').value, document.getElementById('Hiddenpub1').value)
    document.getElementById('txtcentercode').value = global_ds.Tables[0].Rows[0].Pub_cent_Code;
    document.getElementById('drpprint').value = global_ds.Tables[0].Rows[0].PRINT_CENT;
    document.getElementById('txtcentername').value = global_ds.Tables[0].Rows[0].Pub_Cent_name;
    document.getElementById('txtalias').value = global_ds.Tables[0].Rows[0].Pub_Cent_Alias;
    document.getElementById('txtmrv').value = global_ds.Tables[0].Rows[0].MRV_MEMBER_CODE;
    document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[0].MESSAGE;
    document.getElementById('dpstatebooking').value = global_ds.Tables[0].Rows[0].STATE;
    document.getElementById('txtintegration').value = global_ds.Tables[0].Rows[0].INTEGRATION_ID;

    if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD != null)
        document.getElementById('Hiddenpub').value = global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD;
    else
        document.getElementById('Hiddenpub').value = "";

    if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD != null)
        document.getElementById('Hiddenpub1').value = global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD;
    else
        document.getElementById('Hiddenpub1').value = "";
    if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD != null && global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD != null) {
        get_agency_name(document.getElementById('Hiddenpub').value, document.getElementById('Hiddenpub1').value)
    }
    else {
        document.getElementById('po_update').value = "";
    } 
    
    if (global_ds.Tables[0].Rows[0].CIR_FILE_PATH != null) {
        document.getElementById('txtcir_imgpath').value = global_ds.Tables[0].Rows[0].CIR_FILE_PATH;
    }
    else {
        document.getElementById('txtcir_imgpath').value = "";
    }
    if (global_ds.Tables[0].Rows[0].LOGO_FILE_PATH != null)
        document.getElementById('txtlogofile').value = global_ds.Tables[0].Rows[0].LOGO_FILE_PATH;
    else
        document.getElementById('txtlogofile').value = "";

    if (global_ds.Tables[0].Rows[0].FILE_PATH != null) {
        document.getElementById('txtimgpath').value = global_ds.Tables[0].Rows[0].FILE_PATH;
    }
    else {
        document.getElementById('txtimgpath').value = "";
    }
    //PubCatMast.addcity(city,clientaddcode1);
    if (global_ds.Tables[0].Rows[0].Add1 == "" || global_ds.Tables[0].Rows[0].Add1 == null || global_ds.Tables[0].Rows[0].Add1 == "undefined") {
        document.getElementById('txtadd1').value = "";
    }
    else {
        document.getElementById('txtadd1').value = global_ds.Tables[0].Rows[0].Add1;
    }
    if (global_ds.Tables[0].Rows[0].CENTER_COMP_NAME != null) {
        document.getElementById('txtcomp_name').value = global_ds.Tables[0].Rows[0].CENTER_COMP_NAME;
    }
    else {
        document.getElementById('txtcomp_name').value = "";
    }

    if (global_ds.Tables[0].Rows[0].Remarks == "" || global_ds.Tables[0].Rows[0].Remarks == null || global_ds.Tables[0].Rows[0].Remarks == "Undefined") {
        document.getElementById('txtstatusreason').value = "";
    }
    else {
        document.getElementById('txtstatusreason').value = global_ds.Tables[0].Rows[0].Remarks;
    }

    if (global_ds.Tables[0].Rows[0].street == "" || global_ds.Tables[0].Rows[0].street == null || global_ds.Tables[0].Rows[0].street == "undefined") {
        document.getElementById('txtstreet').value = "";
    }
    else {
        document.getElementById('txtstreet').value = global_ds.Tables[0].Rows[0].street;
    }

    //document.getElementById('drpcity').value=global_ds.Tables[0].Rows[0].City_Code;
    if (global_ds.Tables[0].Rows[0].Dist_Code == null || global_ds.Tables[0].Rows[0].Dist_Code == "null") {
        document.getElementById('txtdistrict').value = "";
    }
    else {
        document.getElementById('txtdistrict').value = global_ds.Tables[0].Rows[0].Dist_Code;
    }


    if (global_ds.Tables[0].Rows[0].BOXADDRESS == null || global_ds.Tables[0].Rows[0].Dist_Code == "BOXADDRESS") {
        document.getElementById('txtBoxadd').value = "";
    }
    else {
        document.getElementById('txtBoxadd').value = global_ds.Tables[0].Rows[0].BOXADDRESS;
    }
    if (global_ds.Tables[0].Rows[0].MESSAGE == null || global_ds.Tables[0].Rows[0].Dist_Code == "MESSAGE") {
        document.getElementById('txtmessage').value = "";
    }
    else {
        document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[0].MESSAGE;
    }

    document.getElementById('txtcountry').value = global_ds.Tables[0].Rows[0].Country_Code;
    cityvar = global_ds.Tables[0].Rows[0].City_Code;
    addcount(global_ds.Tables[0].Rows[0].Country_Code);

    document.getElementById('drpregion').value = global_ds.Tables[0].Rows[0].Region_code;
    document.getElementById('drpzone').value = global_ds.Tables[0].Rows[0].Zone_code;
    document.getElementById('txtfax1').value = global_ds.Tables[0].Rows[0].Fax1;
    document.getElementById('drpcity').disabled = true;
    if (global_ds.Tables[0].Rows[0].Phone1 == "" || global_ds.Tables[0].Rows[0].Phone1 == null || global_ds.Tables[0].Rows[0].Phone1 == "undefined") {
        document.getElementById('txtphone1').value = "";
    }
    else {
        document.getElementById('txtphone1').value = global_ds.Tables[0].Rows[0].Phone1;
    }

    if (global_ds.Tables[0].Rows[0].Phone2 == "" || global_ds.Tables[0].Rows[0].Phone2 == null || global_ds.Tables[0].Rows[0].Phone2 == "undefined") {
        document.getElementById('txtphone2').value = "";

    }
    else {
        document.getElementById('txtphone2').value = global_ds.Tables[0].Rows[0].Phone2;
    }
    //document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows.;

    if (global_ds.Tables[0].Rows[0].zip == "" || global_ds.Tables[0].Rows[0].zip == null || global_ds.Tables[0].Rows[0].zip == "undefined") {
        document.getElementById('txtpincode').value = "";
    }
    else {
        document.getElementById('txtpincode').value = global_ds.Tables[0].Rows[0].zip;
    }

    document.getElementById('txtstate').value = global_ds.Tables[0].Rows[0].State_Code;

    if (global_ds.Tables[0].Rows[0].Fax == "" || global_ds.Tables[0].Rows[0].Fax == null || global_ds.Tables[0].Rows[0].Fax == "undefined") {
        document.getElementById('txtfax').value = "";
    }
    else {
        document.getElementById('txtfax').value = global_ds.Tables[0].Rows[0].Fax;
    }

    if (global_ds.Tables[0].Rows[0].EmailID == "" || global_ds.Tables[0].Rows[0].EmailID == null || global_ds.Tables[0].Rows[0].EmailID == "Undefined") {
        document.getElementById('txtemailid').value = "";
    }
    else {
        document.getElementById('txtemailid').value = global_ds.Tables[0].Rows[0].EmailID;
    }

    //document.getElementById('txtstatusdate').value=global_ds.Tables[0].Rows[0].Status_date;

    var dateformat = document.getElementById('hiddendateformat').value;
    document.getElementById('txtstatusdate').value = global_ds.Tables[0].Rows[0].Status_date;

    var tdate1 = global_ds.Tables[0].Rows[0].To_date;
    var tdate = new Date(tdate1);
    var dd = tdate.getDate();
    var mm = tdate.getMonth() + 1;
    var yyyy = tdate.getFullYear();
    if (dateformat == "dd/mm/yyyy") {
        tdate = dd + '/' + mm + '/' + yyyy;
    }
    else if (dateformat == "mm/dd/yyyy") {
        tdate = mm + '/' + dd + '/' + yyyy;
    }
    else if (dateformat == "yyyy/mm/dd") {
        tdate = yyyy + '/' + mm + '/' + dd;
    }
    else if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        tdate = mm + '/' + dd + '/' + yyyy;
    }

    var cdate1 = global_ds.Tables[0].Rows[0].Status_date;
    var cdate = new Date(cdate1);
    var dd1 = cdate.getDate();
    var mm1 = cdate.getMonth() + 1;
    var yyyy1 = cdate.getFullYear();
    if (dateformat == "dd/mm/yyyy") {
        cdate = dd1 + '/' + mm1 + '/' + yyyy1;
    }
    else if (dateformat == "mm/dd/yyyy") {
        cdate = mm1 + '/' + dd1 + '/' + yyyy1;
    }
    else if (dateformat == "yyyy/mm/dd") {
        cdate = yyyy1 + '/' + mm1 + '/' + dd1;
    }
    else if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        cdate = mm1 + '/' + dd1 + '/' + yyyy1;
    }
    document.getElementById('txtstatusdate').value = cdate;

    if (global_ds.Tables[0].Rows[0].Pub_Cent_Status == null || global_ds.Tables[0].Rows[0].Pub_Cent_Status == "")
        document.getElementById('txtstatus1').value = "Active";
    else
        document.getElementById('txtstatus1').value = global_ds.Tables[0].Rows[0].Pub_Cent_Status;
    //					if (tdate<cdate)
    //					{ 
    ////					   else if(cdate<=tdate)
    ////					   {
    ////                            document.getElementById('txtstatus1').value="Active";
    ////					   
    ////					   }
    ////					   else
    ////					   {
    //					  document.getElementById('txtstatus1').value="Banned";
    //					   // }
    //					}
    //					else
    //					{
    //					document.getElementById('txtstatus1').value="Active";
    //					//document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[0].Pub_Cent_Status;
    //					}

    //					var tdate=global_ds.Tables[0].Rows[0].To_date;
    //					var cdate=global_ds.Tables[0].Rows[0].Status_date;
    //		
    //					if (tdate<cdate)
    //					{
    //					document.getElementById('txtstatus1').value="Banned";
    //					
    //					}
    //					else
    //					{
    //					document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[0].Pub_Cent_Status;
    //					}
    //					var akh=document.getElementById('txtcentercode').value
    //				    fillCheckBoxes(akh);
    setButtonImages();
    return false;


}

//*******************************************************************************//
//**********************This Function For The Previous Button********************//
//*******************************************************************************//

function pcmprevious() {
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

    PubCatMast.blankSession();
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    //		PubCatMast.fnplclick(compcode,userid)//,precall)

    document.getElementById('txtcentercode').disabled = true;
    document.getElementById('txtcentername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtintegration').disabled = true;
    document.getElementById('dpstatebooking').disabled = true;
    document.getElementById('txtmrv').disabled = true;

    document.getElementById('txtmessage').disabled = true;

    //document.getElementById('txtcut_time').disabled = true;

    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtBoxadd').disabled = true;
    document.getElementById('txtimgpath').disabled = true;

    document.getElementById('po_update').disabled = true;


    //		return false;
    //	}
    //	
    ////*******************************************************************************//
    ////*******************This Is The Responce Of The Previous Button*****************//
    ////*******************************************************************************//
    //	function precall(response)
    //	{
    z = z - 1;
    //global_ds=response.value;

    var x = global_ds.Tables[0].Rows.length;

    if (z > x) {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnlast').disabled = true;
        return false;
    }
    //PubCatMast.addcity(city,clientaddcode1);

    if (z != -1 && z >= 0) {
        if (global_ds.Tables[0].Rows.length != z) {
            document.getElementById('txtcentercode').value = global_ds.Tables[0].Rows[z].Pub_cent_Code;
            document.getElementById('drpprint').value = global_ds.Tables[0].Rows[z].PRINT_CENT;
            document.getElementById('txtcentername').value = global_ds.Tables[0].Rows[z].Pub_Cent_name;
            document.getElementById('txtalias').value = global_ds.Tables[0].Rows[z].Pub_Cent_Alias;

            document.getElementById('dpstatebooking').value = global_ds.Tables[0].Rows[z].STATE;
            document.getElementById('txtmrv').value = global_ds.Tables[0].Rows[z].MRV_MEMBER_CODE;
            document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[z].MESSAGE;


            if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD != null)
                document.getElementById('Hiddenpub').value = global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD;
            else
                document.getElementById('Hiddenpub').value = "";

            if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD != null)
                document.getElementById('Hiddenpub1').value = global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD;
            else
                document.getElementById('Hiddenpub1').value = "";
            if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD != null && global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD != null) {
                get_agency_name(document.getElementById('Hiddenpub').value, document.getElementById('Hiddenpub1').value)
            }
            else {
                document.getElementById('po_update').value = "";
            }


            if (global_ds.Tables[0].Rows[z].MESSAGE != null)
                document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[z].MESSAGE;
            else
                document.getElementById('txtmessage').value = "";



            if (global_ds.Tables[0].Rows[z].LOGO_FILE_PATH != null)
                document.getElementById('txtlogofile').value = global_ds.Tables[0].Rows[z].LOGO_FILE_PATH;
            else
                document.getElementById('txtlogofile').value = "";
            if (global_ds.Tables[0].Rows[z].CIR_FILE_PATH != null) {
                document.getElementById('txtcir_imgpath').value = global_ds.Tables[0].Rows[z].CIR_FILE_PATH;
            }
            else {
                document.getElementById('txtcir_imgpath').value = "";
            }

            if (global_ds.Tables[0].Rows[z].FILE_PATH != null) {
                document.getElementById('txtimgpath').value = global_ds.Tables[0].Rows[z].FILE_PATH;
            }
            else {
                document.getElementById('txtimgpath').value = "";
            }
            if (global_ds.Tables[0].Rows[z].Add1 == "" || global_ds.Tables[0].Rows[z].Add1 == null || global_ds.Tables[0].Rows[z].Add1 == "undefined") {
                document.getElementById('txtadd1').value = "";
            }
            else {
                document.getElementById('txtadd1').value = global_ds.Tables[0].Rows[z].Add1;
            }

            if (global_ds.Tables[0].Rows[z].CENTER_COMP_NAME != null) {
                document.getElementById('txtcomp_name').value = global_ds.Tables[0].Rows[z].CENTER_COMP_NAME;
            }
            else {
                document.getElementById('txtcomp_name').value = "";
            }

            if (global_ds.Tables[0].Rows[z].Remarks == "" || global_ds.Tables[0].Rows[z].Remarks == null || global_ds.Tables[0].Rows[z].Remarks == "Undefined") {
                document.getElementById('txtstatusreason').value = "";
            }
            else {
                document.getElementById('txtstatusreason').value = global_ds.Tables[0].Rows[z].Remarks;
            }

            if (global_ds.Tables[0].Rows[z].street == "" || global_ds.Tables[0].Rows[z].street == null || global_ds.Tables[0].Rows[z].street == "undefined") {
                document.getElementById('txtstreet').value = "";
            }
            else {
                document.getElementById('txtstreet').value = global_ds.Tables[0].Rows[z].street;
            }

            //document.getElementById('drpcity').value=global_ds.Tables[0].Rows[z].City_Code;
            if (global_ds.Tables[0].Rows[z].Dist_Code == null || global_ds.Tables[0].Rows[z].Dist_Code == "null") {
                document.getElementById('txtdistrict').value = "";

            }
            else {
                document.getElementById('txtdistrict').value = global_ds.Tables[0].Rows[z].Dist_Code;
            }
            document.getElementById('txtcountry').value = global_ds.Tables[0].Rows[z].Country_Code;
            cityvar = global_ds.Tables[0].Rows[z].City_Code;
            addcount(global_ds.Tables[0].Rows[z].Country_Code);
            document.getElementById('drpregion').value = global_ds.Tables[0].Rows[z].Region_code;
            document.getElementById('drpzone').value = global_ds.Tables[0].Rows[z].Zone_code;

            if (global_ds.Tables[0].Rows[z].Fax1 != null) {
                document.getElementById('txtfax1').value = global_ds.Tables[0].Rows[z].Fax1;
            }
            else {
                document.getElementById('txtfax1').value = "";
            }

            document.getElementById('drpcity').disabled = true;
            if (global_ds.Tables[0].Rows[z].Phone1 == "" || global_ds.Tables[0].Rows[z].Phone1 == null || global_ds.Tables[0].Rows[z].Phone1 == "undefined") {
                document.getElementById('txtphone1').value = "";
            }
            else {
                document.getElementById('txtphone1').value = global_ds.Tables[0].Rows[z].Phone1;
            }

            if (global_ds.Tables[0].Rows[z].Phone2 == "" || global_ds.Tables[0].Rows[z].Phone2 == null || global_ds.Tables[0].Rows[z].Phone2 == "undefined") {
                document.getElementById('txtphone2').value = "";

            }
            else {
                document.getElementById('txtphone2').value = global_ds.Tables[0].Rows[z].Phone2;
            }
            //document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows.;

            if (global_ds.Tables[0].Rows[z].zip == "" || global_ds.Tables[0].Rows[z].zip == null || global_ds.Tables[0].Rows[z].zip == "undefined") {
                document.getElementById('txtpincode').value = "";
            }
            else {
                document.getElementById('txtpincode').value = global_ds.Tables[0].Rows[z].zip;
            }

            document.getElementById('txtstate').value = global_ds.Tables[0].Rows[z].State_Code;

            if (global_ds.Tables[0].Rows[z].Fax == "" || global_ds.Tables[0].Rows[z].Fax == null || global_ds.Tables[0].Rows[z].Fax == "undefined") {
                document.getElementById('txtfax').value = "";
            }
            else {
                document.getElementById('txtfax').value = global_ds.Tables[0].Rows[z].Fax;
            }

            if (global_ds.Tables[0].Rows[z].EmailID == "" || global_ds.Tables[0].Rows[z].EmailID == null || global_ds.Tables[0].Rows[z].EmailID == "Undefined") {
                document.getElementById('txtemailid').value = "";
            }
            else {
                document.getElementById('txtemailid').value = global_ds.Tables[0].Rows[z].EmailID;
            }

            if (global_ds.Tables[0].Rows[z].BOXADDRESS != null) {
                document.getElementById('txtBoxadd').value = global_ds.Tables[0].Rows[z].BOXADDRESS;
            }
            else {
                document.getElementById('txtBoxadd').value = "";
            }
            if (global_ds.Tables[0].Rows[z].INTEGRATION_ID != null) {
                document.getElementById('txtintegration').value = global_ds.Tables[0].Rows[z].INTEGRATION_ID;
            }
            else {
                document.getElementById('txtintegration').value = "";
            }



            var dateformat = document.getElementById('hiddendateformat').value;
            document.getElementById('txtstatusdate').value = global_ds.Tables[0].Rows[z].Status_date;

            var tdate1 = global_ds.Tables[0].Rows[z].To_date;
            var tdate = new Date(tdate1);
            var dd = tdate.getDate();
            var mm = tdate.getMonth() + 1;
            var yyyy = tdate.getFullYear();
            if (dateformat == "dd/mm/yyyy") {
                tdate = dd + '/' + mm + '/' + yyyy;
            }
            else if (dateformat == "mm/dd/yyyy") {
                tdate = mm + '/' + dd + '/' + yyyy;
            }
            else if (dateformat == "yyyy/mm/dd") {
                tdate = yyyy + '/' + mm + '/' + dd;
            }
            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                tdate = mm + '/' + dd + '/' + yyyy;
            }

            var cdate1 = global_ds.Tables[0].Rows[z].Status_date;
            var cdate = new Date(cdate1);
            var dd1 = cdate.getDate();
            var mm1 = cdate.getMonth() + 1;
            var yyyy1 = cdate.getFullYear();
            if (dateformat == "dd/mm/yyyy") {
                cdate = dd1 + '/' + mm1 + '/' + yyyy1;
            }
            else if (dateformat == "mm/dd/yyyy") {
                cdate = mm1 + '/' + dd1 + '/' + yyyy1;
            }
            else if (dateformat == "yyyy/mm/dd") {
                cdate = yyyy1 + '/' + mm1 + '/' + dd1;
            }
            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                cdate = mm1 + '/' + dd1 + '/' + yyyy1;
            }
            document.getElementById('txtstatusdate').value = cdate;

            if (global_ds.Tables[0].Rows[z].Pub_Cent_Status == null || global_ds.Tables[0].Rows[z].Pub_Cent_Status == "")
                document.getElementById('txtstatus1').value = "Active";
            else
                document.getElementById('txtstatus1').value = global_ds.Tables[0].Rows[z].Pub_Cent_Status;

            if (global_ds.Tables[0].Rows[z].BOOKING_CUTOF_TIME != null)
             {
                document.getElementById('txtcut_time').value = global_ds.Tables[0].Rows[z].BOOKING_CUTOF_TIME;
            }
            else {
                document.getElementById('txtcut_time').value = "";
            }
            

            //					if (tdate>cdate)
            //					{ 
            ////					   else if(cdate<=tdate)
            ////					   {
            ////                            document.getElementById('txtstatus1').value="Active";
            ////					   
            ////					   }
            ////					   else
            ////					   {
            //					  document.getElementById('txtstatus1').value="Banned";
            //					   // }
            //					}
            //					else
            //					{
            //					document.getElementById('txtstatus1').value="Active";
            //					//document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[0].Pub_Cent_Status;
            //					}

            //					document.getElementById('txtstatusdate').value=global_ds.Tables[0].Rows[0].Status_date;

            //					var tdate=global_ds.Tables[0].Rows[z].To_date;
            //					var cdate=global_ds.Tables[0].Rows[z].Status_date;
            //		
            //					if (tdate<cdate)
            //					{
            //					document.getElementById('txtstatus1').value="Banned";
            //					
            //					}
            //					else
            //					{
            //					document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[z].Pub_Cent_Status;
            //					}

            //					var akh=document.getElementById('txtcentercode').value
            //				    fillCheckBoxes(akh);


            updateStatus();
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnExit').disabled = false;

        }
        else {
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        }


    }
    else {
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
    }
    if (z <= 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;
        setButtonImages();
        return false;
    }
    setButtonImages();
    return false;
}

//*******************************************************************************//
//***********************This Function For The Next Button***********************//
//*******************************************************************************//

function pcmnext() {
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

    PubCatMast.blankSession();

    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;


    document.getElementById('btnModify').disabled=false;
    document.getElementById('btnDelete').disabled=false;
    document.getElementById('btnQuery').disabled=false;
    //document.getElementById('btnExecute').disabled=false;
    document.getElementById('btnCancel').disabled=false;		
    document.getElementById('btnfirst').disabled=false;				
    document.getElementById('btnnext').disabled=false;					
    document.getElementById('btnprevious').disabled=false;			
    document.getElementById('btnlast').disabled=false;			
    document.getElementById('btnExit').disabled=false;
    document.getElementById('btnDelete').disabled = false;

    PubCatMast.fnplclick(compcode, userid, nextcall)

    document.getElementById('txtcentercode').disabled = true;
    document.getElementById('txtcentername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;

    document.getElementById('drpcity').disabled = true;

    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtimgpath').disabled = true;

    document.getElementById('po_update').disabled = true;
    document.getElementById('txtmrv').disabled = true;
    document.getElementById('txtmessage').disabled = true;

    //document.getElementById('txtcut_time').disabled = true;
    
    document.getElementById('dpstatebooking').disabled = true;

    return false;
}
////*******************************************************************************//
////********************This Is The Responce Of The Next Button*******************//
////*******************************************************************************//
function nextcall(response) {
    z = z + 1;
    //global_ds=response.value;
    var x = global_ds.Tables[0].Rows.length;
    
    
 
    if (z <= x && z >= 0) {
        if (global_ds.Tables[0].Rows.length != z && z != -1) {
            //var city=global_ds.Tables[0].Rows[0].City_Code;
            document.getElementById('txtcentercode').value = global_ds.Tables[0].Rows[z].Pub_cent_Code;
            document.getElementById('drpprint').value = global_ds.Tables[0].Rows[z].PRINT_CENT;
            document.getElementById('txtcentername').value = global_ds.Tables[0].Rows[z].Pub_Cent_name;
            document.getElementById('txtalias').value = global_ds.Tables[0].Rows[z].Pub_Cent_Alias;
            document.getElementById('dpstatebooking').value = global_ds.Tables[0].Rows[z].STATE;
            document.getElementById('txtmrv').value = global_ds.Tables[0].Rows[z].MRV_MEMBER_CODE;
            document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[z].MESSAGE;

           // document.getElementById('Hiddenpub').value = global_ds.Tables[0].Rows[0].CIR_PO_UPD_AGCD;
            // document.getElementById('Hiddenpub1').value = global_ds.Tables[0].Rows[0].CIR_PO_UPD_DPCD;

            if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD != null)
                document.getElementById('Hiddenpub').value = global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD;
            else
                document.getElementById('Hiddenpub').value = "";

            if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD != null)
                document.getElementById('Hiddenpub1').value = global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD;
            else
                document.getElementById('Hiddenpub1').value = "";
            if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD != null && global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD != null) {
                get_agency_name(document.getElementById('Hiddenpub').value, document.getElementById('Hiddenpub1').value)
            }
            else {
                document.getElementById('po_update').value = "";
            }
           

            if (global_ds.Tables[0].Rows[z].LOGO_FILE_PATH != null)
                document.getElementById('txtlogofile').value = global_ds.Tables[0].Rows[z].LOGO_FILE_PATH;
            else
                document.getElementById('txtlogofile').value = "";
            if (global_ds.Tables[0].Rows[z].CIR_FILE_PATH != null) {
                document.getElementById('txtcir_imgpath').value = global_ds.Tables[0].Rows[z].CIR_FILE_PATH;
            }
            else {
                document.getElementById('txtcir_imgpath').value = "";
            }

            if (global_ds.Tables[0].Rows[z].FILE_PATH != null) {
                document.getElementById('txtimgpath').value = global_ds.Tables[0].Rows[z].FILE_PATH;
            }
            else {
                document.getElementById('txtimgpath').value = "";
            }
            //PubCatMast.addcity(city,clientaddcode1);
            if (global_ds.Tables[0].Rows[z].Add1 == "" || global_ds.Tables[0].Rows[z].Add1 == null || global_ds.Tables[0].Rows[z].Add1 == "undefined") {
                document.getElementById('txtadd1').value = "";
            }
            else {
                document.getElementById('txtadd1').value = global_ds.Tables[0].Rows[z].Add1;
            }


            if (global_ds.Tables[0].Rows[z].Remarks == "" || global_ds.Tables[0].Rows[z].Remarks == null || global_ds.Tables[0].Rows[z].Remarks == "Undefined") {
                document.getElementById('txtstatusreason').value = "";
            }
            else {
                document.getElementById('txtstatusreason').value = global_ds.Tables[0].Rows[z].Remarks;
            }


            if (global_ds.Tables[0].Rows[z].street == "" || global_ds.Tables[0].Rows[z].street == null || global_ds.Tables[0].Rows[z].street == "undefined") {
                document.getElementById('txtstreet').value = "";
            }
            else {
                document.getElementById('txtstreet').value = global_ds.Tables[0].Rows[z].street;
            }

            if (global_ds.Tables[0].Rows[z].CENTER_COMP_NAME != null) {
                document.getElementById('txtcomp_name').value = global_ds.Tables[0].Rows[z].CENTER_COMP_NAME;
            }
            else {
                document.getElementById('txtcomp_name').value = "";
            }


            //document.getElementById('drpcity').value=global_ds.Tables[0].Rows[z].City_Code;
            if (global_ds.Tables[0].Rows[z].Dist_Code == null || global_ds.Tables[0].Rows[z].Dist_Code == "null") {
                document.getElementById('txtdistrict').value = "";

            }
            else {
                document.getElementById('txtdistrict').value = global_ds.Tables[0].Rows[z].Dist_Code;
            }
            document.getElementById('txtcountry').value = global_ds.Tables[0].Rows[z].Country_Code;
            cityvar = global_ds.Tables[0].Rows[z].City_Code;
            addcount(global_ds.Tables[0].Rows[z].Country_Code);
            document.getElementById('drpregion').value = global_ds.Tables[0].Rows[z].Region_code;
            document.getElementById('drpzone').value = global_ds.Tables[0].Rows[z].Zone_code;

            if (global_ds.Tables[0].Rows[z].Fax1 != null) {
                document.getElementById('txtfax1').value = global_ds.Tables[0].Rows[z].Fax1;
            }
            else {
                document.getElementById('txtfax1').value = "";
            }
            document.getElementById('drpcity').disabled = true;
            if (global_ds.Tables[0].Rows[z].Phone1 == "" || global_ds.Tables[0].Rows[z].Phone1 == null || global_ds.Tables[0].Rows[z].Phone1 == "undefined") {
                document.getElementById('txtphone1').value = "";
            }
            else {
                document.getElementById('txtphone1').value = global_ds.Tables[0].Rows[z].Phone1;
            }

            if (global_ds.Tables[0].Rows[z].Phone2 == "" || global_ds.Tables[0].Rows[z].Phone2 == null || global_ds.Tables[0].Rows[z].Phone2 == "undefined") {
                document.getElementById('txtphone2').value = "";

            }
            else {
                document.getElementById('txtphone2').value = global_ds.Tables[0].Rows[z].Phone2;
            }
            //document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows.;

            if (global_ds.Tables[0].Rows[z].zip == "" || global_ds.Tables[0].Rows[z].zip == null || global_ds.Tables[0].Rows[z].zip == "undefined") {
                document.getElementById('txtpincode').value = "";
            }
            else {
                document.getElementById('txtpincode').value = global_ds.Tables[0].Rows[z].zip;
            }

            document.getElementById('txtstate').value = global_ds.Tables[0].Rows[z].State_Code;

            if (global_ds.Tables[0].Rows[z].Fax == "" || global_ds.Tables[0].Rows[z].Fax == null || global_ds.Tables[0].Rows[z].Fax == "undefined") {
                document.getElementById('txtfax').value = "";
            }
            else {
                document.getElementById('txtfax').value = global_ds.Tables[0].Rows[z].Fax;
            }


            if (global_ds.Tables[0].Rows[z].BOXADDRESS != null) {
                document.getElementById('txtBoxadd').value = global_ds.Tables[0].Rows[z].BOXADDRESS;
            }
            else {
                document.getElementById('txtBoxadd').value = "";
            }





            if (global_ds.Tables[0].Rows[z].EmailID == "" || global_ds.Tables[0].Rows[z].EmailID == null || global_ds.Tables[0].Rows[z].EmailID == "Undefined") {
                document.getElementById('txtemailid').value = "";
            }
            else {
                document.getElementById('txtemailid').value = global_ds.Tables[0].Rows[z].EmailID;
            }
            if (global_ds.Tables[0].Rows[z].MESSAGE == "" || global_ds.Tables[0].Rows[z].MESSAGE == null || global_ds.Tables[0].Rows[z].MESSAGE == "Undefined") {
                document.getElementById('txtmessage').value = "";
            }
            else {
                document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[z].MESSAGE;
            }
            if (global_ds.Tables[0].Rows[z].INTEGRATION_ID == "" || global_ds.Tables[0].Rows[z].INTEGRATION_ID == null || global_ds.Tables[0].Rows[z].INTEGRATION_ID == "Undefined") {
                document.getElementById('txtmessage').value = "";
            }
            else {
                document.getElementById('txtintegration').value = global_ds.Tables[0].Rows[z].INTEGRATION_ID;
            }

            var dateformat = document.getElementById('hiddendateformat').value;
            document.getElementById('txtstatusdate').value = global_ds.Tables[0].Rows[z].Status_date;

            var tdate1 = global_ds.Tables[0].Rows[z].To_date;
            var tdate = new Date(tdate1);
            var dd = tdate.getDate();
            var mm = tdate.getMonth() + 1;
            var yyyy = tdate.getFullYear();
            if (dateformat == "dd/mm/yyyy") {
                tdate = dd + '/' + mm + '/' + yyyy;
            }
            else if (dateformat == "mm/dd/yyyy") {
                tdate = mm + '/' + dd + '/' + yyyy;
            }
            else if (dateformat == "yyyy/mm/dd") {
                tdate = yyyy + '/' + mm + '/' + dd;
            }
            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                tdate = mm + '/' + dd + '/' + yyyy;
            }

            var cdate1 = global_ds.Tables[0].Rows[z].Status_date;
            var cdate = new Date(cdate1);
            var dd1 = cdate.getDate();
            var mm1 = cdate.getMonth() + 1;
            var yyyy1 = cdate.getFullYear();
            if (dateformat == "dd/mm/yyyy") {
                cdate = dd1 + '/' + mm1 + '/' + yyyy1;
            }
            else if (dateformat == "mm/dd/yyyy") {
                cdate = mm1 + '/' + dd1 + '/' + yyyy1;
            }
            else if (dateformat == "yyyy/mm/dd") {
                cdate = yyyy1 + '/' + mm1 + '/' + dd1;
            }
            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                cdate = mm1 + '/' + dd1 + '/' + yyyy1;
            }
            document.getElementById('txtstatusdate').value = cdate;

            if (global_ds.Tables[0].Rows[z].Pub_Cent_Status == null || global_ds.Tables[0].Rows[z].Pub_Cent_Status == "")
                document.getElementById('txtstatus1').value = "Active";
            else
                document.getElementById('txtstatus1').value = global_ds.Tables[0].Rows[z].Pub_Cent_Status;


            if (global_ds.Tables[0].Rows[z].BOOKING_CUTOF_TIME != null) {
                document.getElementById('txtcut_time').value = global_ds.Tables[0].Rows[z].BOOKING_CUTOF_TIME;
            }
            else {
                document.getElementById('txtcut_time').value = "";
            } 
                
                
                

            //					if (tdate<cdate)
            //					{ 
            ////					   else if(cdate<=tdate)
            ////					   {
            ////                            document.getElementById('txtstatus1').value="Active";
            ////					   
            ////					   }
            ////					   else
            ////					   {
            //					  document.getElementById('txtstatus1').value="Banned";
            //					   // }
            //					}
            //					else
            //					{
            //					document.getElementById('txtstatus1').value="Active";
            //					//document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[0].Pub_Cent_Status;
            //					}
            //					if(global_ds.Tables[0].Rows[z].Pub_Cent_Status!=null)
            //					document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[z].Pub_Cent_Status;
            //					else
            //					document.getElementById('txtstatus1').value="Active";
            //					document.getElementById('txtstatusdate').value=global_ds.Tables[0].Rows[z].Status_date;
            //		
            //					var tdate=global_ds.Tables[0].Rows[z].To_date;
            //					var cdate=global_ds.Tables[0].Rows[z].Status_date;
            //		
            //					if (tdate<cdate)
            //					{
            //					document.getElementById('txtstatus1').value="Banned";
            //					
            //					}
            //					else
            //					{
            //					document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[z].Pub_Cent_Status;
            //					}

            //					var akh=document.getElementById('txtcentercode').value
            //				    fillCheckBoxes(akh);
            //					
            updateStatus();

            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
        }
        else {
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
        }
    }
    else {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
    }
    if (z == x - 1) {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
    }
    setButtonImages();
    return false;
}


//*******************************************************************************//
//***********************This Function For The Last Button***********************//
//*******************************************************************************//


function pcmlast() {
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

    PubCatMast.blankSession();
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    PubCatMast.fnplclick(compcode, userid, lastcall);


    document.getElementById('txtcentercode').disabled = true;
    document.getElementById('txtcentername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtfax1').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtimgpath').disabled = true;
    document.getElementById('txtcir_imgpath').disabled = true;
    document.getElementById('dpstatebooking').disabled = true;
    document.getElementById('txtmrv').disabled = true;
    document.getElementById('txtmessage').disabled = true;

    document.getElementById('txtintegration').disabled = true
    //document.getElementById('txtcut_time').disabled = true;
    
    updateStatus();
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnprevious').disabled = false;

    return false;
}

////*******************************************************************************//
////********************This Is The Responce Of The Last Button*******************//
////*******************************************************************************//
function lastcall(response) {
    //alert("hi");
    //global_ds= response.value;
    var x = global_ds.Tables[0].Rows.length;
    z = x - 1;
    x = x - 1;

    //PubCatMast.addcity(city,clientaddcode1);

    document.getElementById('txtcentercode').value = global_ds.Tables[0].Rows[x].Pub_cent_Code;
    document.getElementById('drpprint').value = global_ds.Tables[0].Rows[x].PRINT_CENT;
    document.getElementById('txtcentername').value = global_ds.Tables[0].Rows[x].Pub_Cent_name;
    document.getElementById('txtalias').value = global_ds.Tables[0].Rows[x].Pub_Cent_Alias;
    document.getElementById('dpstatebooking').value = global_ds.Tables[0].Rows[x].STATE;
    document.getElementById('txtmrv').value = global_ds.Tables[0].Rows[x].MRV_MEMBER_CODE;
    document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[x].MESSAGE;


    if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD != null)
        document.getElementById('Hiddenpub').value = global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD;
    else
        document.getElementById('Hiddenpub').value = "";

    if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD != null)
        document.getElementById('Hiddenpub1').value = global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD;
    else
        document.getElementById('Hiddenpub1').value = "";
    if (global_ds.Tables[0].Rows[z].CIR_PO_UPD_AGCD != null && global_ds.Tables[0].Rows[z].CIR_PO_UPD_DPCD != null) {
        get_agency_name(document.getElementById('Hiddenpub').value, document.getElementById('Hiddenpub1').value)
    }
    else {
        document.getElementById('po_update').value = "";
    }
    
    if (global_ds.Tables[0].Rows[x].LOGO_FILE_PATH != null)
        document.getElementById('txtlogofile').value = global_ds.Tables[0].Rows[x].LOGO_FILE_PATH;
    else
        document.getElementById('txtlogofile').value = "";
    if (global_ds.Tables[0].Rows[x].CIR_FILE_PATH != null) {
        document.getElementById('txtcir_imgpath').value = global_ds.Tables[0].Rows[x].CIR_FILE_PATH;
    }
    else {
        document.getElementById('txtcir_imgpath').value = "";
    }

    if (global_ds.Tables[0].Rows[x].FILE_PATH != null) {
        document.getElementById('txtimgpath').value = global_ds.Tables[0].Rows[x].FILE_PATH;
    }
    else {
        document.getElementById('txtimgpath').value = "";
    }

    if (global_ds.Tables[0].Rows[x].Add1 == "" || global_ds.Tables[0].Rows[x].Add1 == null || global_ds.Tables[0].Rows[x].Add1 == "undefined") {
        document.getElementById('txtadd1').value = "";
    }
    else {
        document.getElementById('txtadd1').value = global_ds.Tables[0].Rows[x].Add1;
    }


    if (global_ds.Tables[0].Rows[x].street == "" || global_ds.Tables[0].Rows[x].street == null || global_ds.Tables[0].Rows[x].street == "undefined") {
        document.getElementById('txtstreet').value = "";
    }
    else {
        document.getElementById('txtstreet').value = global_ds.Tables[0].Rows[x].street;
    }

    if (global_ds.Tables[0].Rows[x].CENTER_COMP_NAME != null) {
        document.getElementById('txtcomp_name').value = global_ds.Tables[0].Rows[x].CENTER_COMP_NAME;
    }
    else {
        document.getElementById('txtcomp_name').value = "";
    }


    //document.getElementById('drpcity').value=global_ds.Tables[0].Rows[x].City_Code;
    if (global_ds.Tables[0].Rows[x].Dist_Code == null || global_ds.Tables[0].Rows[x].Dist_Code == "null") {
        document.getElementById('txtdistrict').value = "";

    }
    else {
        document.getElementById('txtdistrict').value = global_ds.Tables[0].Rows[x].Dist_Code;
    }
    document.getElementById('txtcountry').value = global_ds.Tables[0].Rows[x].Country_Code;
    cityvar = global_ds.Tables[0].Rows[x].City_Code;
    addcount(global_ds.Tables[0].Rows[x].Country_Code);
    document.getElementById('drpregion').value = global_ds.Tables[0].Rows[x].Region_code;
    document.getElementById('drpzone').value = global_ds.Tables[0].Rows[x].Zone_code;

    if (global_ds.Tables[0].Rows[x].Fax1 == "" || global_ds.Tables[0].Rows[x].Fax1 == null || global_ds.Tables[0].Rows[x].Fax1 == "undefined") {
        document.getElementById('txtfax1').value = "";
    }
    else {
        document.getElementById('txtfax1').value = global_ds.Tables[0].Rows[x].Fax1;
    }

    document.getElementById('drpcity').disabled = true;
    if (global_ds.Tables[0].Rows[x].Phone1 == "" || global_ds.Tables[0].Rows[x].Phone1 == null || global_ds.Tables[0].Rows[x].Phone1 == "undefined") {
        document.getElementById('txtphone1').value = "";
    }
    else {
        document.getElementById('txtphone1').value = global_ds.Tables[0].Rows[x].Phone1;
    }

    if (global_ds.Tables[0].Rows[x].Phone2 == "" || global_ds.Tables[0].Rows[x].Phone2 == null || global_ds.Tables[0].Rows[x].Phone2 == "undefined") {
        document.getElementById('txtphone2').value = "";

    }
    else {
        document.getElementById('txtphone2').value = global_ds.Tables[0].Rows[x].Phone2;
    }
    //document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows.;

    if (global_ds.Tables[0].Rows[x].zip == "" || global_ds.Tables[0].Rows[x].zip == null || global_ds.Tables[0].Rows[x].zip == "undefined") {
        document.getElementById('txtpincode').value = "";
    }
    else {
        document.getElementById('txtpincode').value = global_ds.Tables[0].Rows[x].zip;
    }

    document.getElementById('txtstate').value = global_ds.Tables[0].Rows[x].State_Code;

    if (global_ds.Tables[0].Rows[x].Fax == "" || global_ds.Tables[0].Rows[x].Fax == null || global_ds.Tables[0].Rows[x].Fax == "undefined") {
        document.getElementById('txtfax').value = "";
    }
    else {
        document.getElementById('txtfax').value = global_ds.Tables[0].Rows[x].Fax;
    }

    if (global_ds.Tables[0].Rows[x].EmailID == "" || global_ds.Tables[0].Rows[x].EmailID == null || global_ds.Tables[0].Rows[x].EmailID == "Undefined") {
        document.getElementById('txtemailid').value = "";
    }
    else {
        document.getElementById('txtemailid').value = global_ds.Tables[0].Rows[x].EmailID;
    }

    if (global_ds.Tables[0].Rows[x].BOXADDRESS == "" || global_ds.Tables[0].Rows[x].BOXADDRESS == null || global_ds.Tables[0].Rows[x].BOXADDRESS == "undefined") {
        document.getElementById('txtBoxadd').value = "";
    }
    else {
        document.getElementById('txtBoxadd').value = global_ds.Tables[0].Rows[x].BOXADDRESS;
    }

    if (global_ds.Tables[0].Rows[x].MESSAGE == "" || global_ds.Tables[0].Rows[x].MESSAGE == null || global_ds.Tables[0].Rows[x].MESSAGE == "undefined") {
        document.getElementById('txtmessage').value = "";
    }
    else {
        document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[x].MESSAGE;
    }

    if (global_ds.Tables[0].Rows[x].INTEGRATION_ID == "" || global_ds.Tables[0].Rows[x].INTEGRATION_ID == null || global_ds.Tables[0].Rows[x].INTEGRATION_ID == "undefined") {
        document.getElementById('txtintegration').value = "";
    }
    else {
        document.getElementById('txtintegration').value = global_ds.Tables[0].Rows[x].INTEGRATION_ID;
    }



    var dateformat = document.getElementById('hiddendateformat').value;
    document.getElementById('txtstatusdate').value = global_ds.Tables[0].Rows[x].Status_date;

    var tdate1 = global_ds.Tables[0].Rows[x].To_date;
    var tdate = new Date(tdate1);
    var dd = tdate.getDate();
    var mm = tdate.getMonth() + 1;
    var yyyy = tdate.getFullYear();
    if (dateformat == "dd/mm/yyyy") {
        tdate = dd + '/' + mm + '/' + yyyy;
    }
    else if (dateformat == "mm/dd/yyyy") {
        tdate = mm + '/' + dd + '/' + yyyy;
    }
    else if (dateformat == "yyyy/mm/dd") {
        tdate = yyyy + '/' + mm + '/' + dd;
    }
    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        tdate = mm + '/' + dd + '/' + yyyy;
    }

    var cdate1 = global_ds.Tables[0].Rows[x].Status_date;
    var cdate = new Date(cdate1);
    var dd1 = cdate.getDate();
    var mm1 = cdate.getMonth() + 1;
    var yyyy1 = cdate.getFullYear();
    if (dateformat == "dd/mm/yyyy") {
        cdate = dd1 + '/' + mm1 + '/' + yyyy1;
    }
    else if (dateformat == "mm/dd/yyyy") {
        cdate = mm1 + '/' + dd1 + '/' + yyyy1;
    }
    else if (dateformat == "yyyy/mm/dd") {
        cdate = yyyy1 + '/' + mm1 + '/' + dd1;
    }
    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        cdate = mm1 + '/' + dd1 + '/' + yyyy1;
    }
    document.getElementById('txtstatusdate').value = cdate;

    if (global_ds.Tables[0].Rows[0].Pub_Cent_Status == null || global_ds.Tables[0].Rows[0].Pub_Cent_Status == "")
        document.getElementById('txtstatus1').value = "Active";
    else
        document.getElementById('txtstatus1').value = global_ds.Tables[0].Rows[0].Pub_Cent_Status;

    if (global_ds.Tables[0].Rows[0].BOOKING_CUTOF_TIME != null) {
        document.getElementById('txtcut_time').value = global_ds.Tables[0].Rows[0].BOOKING_CUTOF_TIME;
    }
    else {
        document.getElementById('txtcut_time').value = "";
    }
        
        
        
        
        
        

    //					if (tdate<cdate)
    //					{ 
    ////					   else if(cdate<=tdate)
    ////					   {
    ////                            document.getElementById('txtstatus1').value="Active";
    ////					   
    ////					   }
    ////					   else
    ////					   {
    //					  document.getElementById('txtstatus1').value="Banned";
    //					   // }
    //					}
    //					else
    //					{
    //					document.getElementById('txtstatus1').value="Active";
    //					//document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[0].Pub_Cent_Status;
    //					}


    //					document.getElementById('txtstatusdate').value=global_ds.Tables[0].Rows[x].Status_date;
    //		
    //					var tdate=global_ds.Tables[0].Rows[x].To_date;
    //					var cdate=global_ds.Tables[0].Rows[x].Status_date;
    //		
    //					if (tdate<cdate)
    //					{
    //					document.getElementById('txtstatus1').value="Banned";
    //					
    //					}
    //					else
    //					{
    //					document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[x].Pub_Cent_Status;
    //					}
    setButtonImages();
    return false;
}

//*******************************************************************************//
//**********************This Function For The Delete Button**********************//
//*******************************************************************************//

function pcmdelete() {

    boolReturn = confirm("Are you sure you wish to delete this?");
    if (boolReturn == 1) {
        var compcode = document.getElementById('hiddencompcode').value;
        var centercode = document.getElementById('txtcentercode').value;
        var userid = document.getElementById('hiddenuserid').value;
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
        var ag = "";
        var dp = "";
        var MRV = document.getElementById('txtmrv').value;
        var ip2 = document.getElementById('ip1').value;
        PubCatMast.delclick(compcode, centercode, userid, ip2);

        document.getElementById('btnfirst').disabled=false;
        document.getElementById('btnprevious').disabled=false;
        document.getElementById('btnnext').disabled=false;
        document.getElementById('btnlast').disabled=false;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnExit').disabled=false;
        document.getElementById('btnDelete').disabled = false;
       // document.getElementById('txtpaycode').value="";
//        document.getElementById('txtpayment').value="";
//        document.getElementById('txtpaycode').disabled=true;
//        //							document.getElementById('txtpayment').disabled=true;

        //alert("Data Deleted");s
        if (browser != "Microsoft Internet Explorer") {
            alert("Data deleted Successfully");
        }
        else {
            alert("Data deleted Successfully");
        }
        //PubCatMast.fnplclick(compcode,userid,call_deletepub)exepcmcall
var state = document.getElementById('dpstatebooking').value;
var userid = document.getElementById('hiddenuserid').value;
    var companyname = document.getElementById('txtcomp_name').value;
        //PubCatMast.exepcm(compcode,gbcentcode,gbcentname,gbalias,gbcountry,gbcity,userid,call_deletepub)
        PubCatMast.exepcm(compcode, gbcentcode, gbcentname, gbalias, gbcountry, gbcity,userid,companyname,state, MRV,ag,dp, call_deletepub);


        //return true;
    }
    else {
        return false;
    }
    return false;


}
//*******************************************************************************//
//********************This Is The Responce Of The Last Button*******************//
//*******************************************************************************//
function call_deletepub(response) {

    global_ds = response.value;
    //var ds=response.value;
    var a = global_ds.Tables[0].Rows.length;
    //var y=a-1;

    if (global_ds.Tables[0].Rows.length == 0)

    //if(ds.Tables[0].Rows.length==0)
    {
        alert("No more data is here to be deleted");
        document.getElementById('txtcentercode').value = "";
        document.getElementById('txtimgpath').value = "";
        document.getElementById('txtcentername').value = "";
        document.getElementById('txtalias').value = "";
        document.getElementById('txtadd1').value = "";
        document.getElementById('txtstreet').value = "";
        document.getElementById('drpcity').value = "0";
        document.getElementById('txtdistrict').value = "";
        document.getElementById('txtcountry').value = "0";
        document.getElementById('txtphone1').value = "";
        document.getElementById('txtphone2').value = "";
        document.getElementById('txtstatusreason').value = "";
        document.getElementById('txtfax').value = "";
        document.getElementById('txtfax1').value = "";
        document.getElementById('drpregion').value = "0";
        document.getElementById('drpzone').value = "0";
        document.getElementById('txtcir_imgpath').value = "";
        document.getElementById('lbClientContactDetail').disabled = true;
        document.getElementById('lbStatusDetail').disabled = true;
        document.getElementById('drpcity').disabled = true;
        document.getElementById('txtintegration').disabled = true;

        pcmcancel('PubCatMast');
    }

    else if (z == -1 || z >= a) {

        document.getElementById('txtcentercode').value = global_ds.Tables[0].Rows[0].Pub_cent_Code;
        document.getElementById('drpprint').value = global_ds.Tables[0].Rows[0].PRINT_CENT;
        document.getElementById('txtcentername').value = global_ds.Tables[0].Rows[0].Pub_Cent_Alias;
        document.getElementById('txtalias').value = global_ds.Tables[0].Rows[0].Pub_Cent_name;
        if (global_ds.Tables[0].Rows[0].LOGO_FILE_PATH != null)
            document.getElementById('txtlogofile').value = global_ds.Tables[0].Rows[0].LOGO_FILE_PATH;
        else
            document.getElementById('txtlogofile').value = "";

        if (global_ds.Tables[0].Rows[0].CIR_FILE_PATH != null) {
            document.getElementById('txtcir_imgpath').value = global_ds.Tables[0].Rows[0].CIR_FILE_PATH;
        }
        else {
            document.getElementById('txtcir_imgpath').value = "";
        }

        if (global_ds.Tables[0].Rows[0].FILE_PATH != null) {
            document.getElementById('txtimgpath').value = global_ds.Tables[0].Rows[0].FILE_PATH;
        }
        else {
            document.getElementById('txtimgpath').value = "";
        }


        if (global_ds.Tables[0].Rows[0].Add1 == "" || global_ds.Tables[0].Rows[0].Add1 == null || global_ds.Tables[0].Rows[0].Add1 == "undefined") {
            document.getElementById('txtadd1').value = "";
        }
        else {
            document.getElementById('txtadd1').value = global_ds.Tables[0].Rows[0].Add1;
        }
        if (global_ds.Tables[0].Rows[0].Remarks == "" || global_ds.Tables[0].Rows[0].Remarks == null || global_ds.Tables[0].Rows[0].Remarks == "Undefined") {
            document.getElementById('txtstatusreason').value = "";
        }
        else {
            document.getElementById('txtstatusreason').value = global_ds.Tables[0].Rows[0].Remarks;
        }

        if (global_ds.Tables[0].Rows[0].street == "" || global_ds.Tables[0].Rows[0].street == null || global_ds.Tables[0].Rows[0].street == "undefined") {
            document.getElementById('txtstreet').value = "";
        }
        else {
            document.getElementById('txtstreet').value = global_ds.Tables[0].Rows[0].street;
        }

        //	document.getElementById('drpcity').value=global_ds.Tables[0].Rows[0].City_Code;
        if (global_ds.Tables[0].Rows[0].Dist_Code == null || global_ds.Tables[0].Rows[0].Dist_Code == "null") {
            document.getElementById('txtdistrict').value = "";

        }
        else {
            document.getElementById('txtdistrict').value = global_ds.Tables[0].Rows[0].Dist_Code;
        }
        document.getElementById('txtcountry').value = global_ds.Tables[0].Rows[0].Country_Code;
        cityvar = global_ds.Tables[0].Rows[0].City_Code;
        addcount(global_ds.Tables[0].Rows[0].Country_Code);
        document.getElementById('drpregion').value = global_ds.Tables[0].Rows[0].Region_code;
        document.getElementById('drpzone').value = global_ds.Tables[0].Rows[0].Zone_code;

        //saurabh change					document.getElementById('txtfax1').value=ds.Tables[0].Rows[0].Fax1;

        //   global_ds.getElementById('txtfax1').value=global_ds.Tables[0].Rows[0].Fax1;

        if (global_ds.Tables[0].Rows[0].Fax1 == "" || global_ds.Tables[0].Rows[0].Fax1 == null || global_ds.Tables[0].Rows[0].Fax1 == "undefined") {
            document.getElementById('txtfax1').value = "";
        }
        else {
            document.getElementById('txtfax1').value = global_ds.Tables[0].Rows[0].Fax1;
        }

        if (global_ds.Tables[0].Rows[0].Phone1 == "" || global_ds.Tables[0].Rows[0].Phone1 == null || global_ds.Tables[0].Rows[0].Phone1 == "undefined") {
            document.getElementById('txtphone1').value = "";
        }
        else {
            document.getElementById('txtphone1').value = global_ds.Tables[0].Rows[0].Phone1;
        }

        if (global_ds.Tables[0].Rows[0].Phone2 == "" || global_ds.Tables[0].Rows[0].Phone2 == null || global_ds.Tables[0].Rows[0].Phone2 == "undefined") {
            document.getElementById('txtphone2').value = "";

        }
        else {
            document.getElementById('txtphone2').value = global_ds.Tables[0].Rows[0].Phone2;
        }
        //document.getElementById('txtstatus1').value=ds.Tables[0].Rows.;

        if (global_ds.Tables[0].Rows[0].zip == "" || global_ds.Tables[0].Rows[0].zip == null || global_ds.Tables[0].Rows[0].zip == "undefined") {
            document.getElementById('txtpincode').value = "";
        }
        else {
            document.getElementById('txtpincode').value = global_ds.Tables[0].Rows[0].zip;
        }

        //	document.getElementById('txtstate').value=ds.Tables[0].Rows[0].State_Code;

        if (global_ds.Tables[0].Rows[0].State_Code == "" || global_ds.Tables[0].Rows[0].State_Code == null || global_ds.Tables[0].Rows[0].State_Code == "undefined") {
            document.getElementById('txtstate').value = "";
        }
        else {
            document.getElementById('txtstate').value = global_ds.Tables[0].Rows[0].State_Code;
        }

        if (global_ds.Tables[0].Rows[0].Fax == "" || global_ds.Tables[0].Rows[0].Fax == null || global_ds.Tables[0].Rows[0].Fax == "undefined") {
            document.getElementById('txtfax').value = "";
        }
        else {
            document.getElementById('txtfax').value = global_ds.Tables[0].Rows[0].Fax;
        }

        if (global_ds.Tables[0].Rows[0].EmailID == "" || global_ds.Tables[0].Rows[0].EmailID == null || global_ds.Tables[0].Rows[0].EmailID == "Undefined") {
            document.getElementById('txtemailid').value = "";
        }
        else {
            document.getElementById('txtemailid').value = global_ds.Tables[0].Rows[0].EmailID;
        }

        if (global_ds.Tables[0].Rows[0].MESSAGE == "" || global_ds.Tables[0].Rows[0].MESSAGE == null || global_ds.Tables[0].Rows[0].MESSAGE == "Undefined") {
            document.getElementById('txtmessage').value = "";
        }
        else {
            document.getElementById('txtmessage').value = "";
        }
        if (global_ds.Tables[0].Rows[0].INTEGRATION_ID == "" || global_ds.Tables[0].Rows[0].INTEGRATION_ID == null || global_ds.Tables[0].Rows[0].INTEGRATION_ID == "Undefined") {
            document.getElementById('txtintegration').value = "";
        }
        else {
            document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[0].INTEGRATION_ID;
        }


        document.getElementById('txtstatusdate').value = global_ds.Tables[0].Rows[0].Status_date;

        var tdate = global_ds.Tables[0].Rows[0].To_date;
        var cdate = global_ds.Tables[0].Rows[0].Status_date;

        if (global_ds.Tables[0].Rows[0].Pub_Cent_Status == null || global_ds.Tables[0].Rows[0].Pub_Cent_Status == "")
            document.getElementById('txtstatus1').value = "Active";
        else
            document.getElementById('txtstatus1').value = global_ds.Tables[0].Rows[0].Pub_Cent_Status;
        //					if (tdate<cdate)
        //					{
        //					document.getElementById('txtstatus1').value="Banned";
        //					
        //					}
        //					else
        //					{
        //					document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[0].Pub_Cent_Status;
        //					}
        //					


        //					var akh=document.getElementById('txtpubcode').value;
        //		             fillCheckBoxes(akh);
        setButtonImages(); 			//disablecheck();
        return false;
    }

    else {

        document.getElementById('txtcentercode').value = global_ds.Tables[0].Rows[z].Pub_cent_Code;
        document.getElementById('drpprint').value = global_ds.Tables[0].Rows[z].PRINT_CENT;
        document.getElementById('txtcentername').value = global_ds.Tables[0].Rows[z].Pub_Cent_name;
        document.getElementById('txtalias').value = global_ds.Tables[0].Rows[z].Pub_Cent_Alias;
        document.getElementById('txtintegration').value = global_ds.Tables[0].Rows[z].INTEGRATION_ID;
        if (global_ds.Tables[0].Rows[z].LOGO_FILE_PATH != null)
            document.getElementById('txtlogofile').value = global_ds.Tables[0].Rows[z].LOGO_FILE_PATH;
        else
            document.getElementById('txtlogofile').value = "";
        if (global_ds.Tables[0].Rows[z].CIR_FILE_PATH != null) {
            document.getElementById('txtcir_imgpath').value = global_ds.Tables[0].Rows[z].CIR_FILE_PATH;
        }
        else {
            document.getElementById('txtcir_imgpath').value = "";
        }

        if (global_ds.Tables[0].Rows[z].FILE_PATH != null) {
            document.getElementById('txtimgpath').value = global_ds.Tables[0].Rows[z].FILE_PATH;
        }
        else {
            document.getElementById('txtimgpath').value = "";
        }
        //var akh=document.getElementById('txtpubcode').value;
        //fillCheckBoxes(akh);
        if (global_ds.Tables[0].Rows[z].Add1 == "" || global_ds.Tables[0].Rows[z].Add1 == null || global_ds.Tables[0].Rows[z].Add1 == "undefined") {
            document.getElementById('txtadd1').value = "";
        }
        else {
            document.getElementById('txtadd1').value = global_ds.Tables[0].Rows[z].Add1;
        }

        if (global_ds.Tables[0].Rows[z].Remarks == "" || global_ds.Tables[0].Rows[z].Remarks == null || global_ds.Tables[0].Rows[z].Remarks == "Undefined") {
            document.getElementById('txtstatusreason').value = "";
        }
        else {
            document.getElementById('txtstatusreason').value = global_ds.Tables[0].Rows[z].Remarks;
        }

        if (global_ds.Tables[0].Rows[z].street == "" || global_ds.Tables[0].Rows[z].street == null || global_ds.Tables[0].Rows[z].street == "undefined") {
            document.getElementById('txtstreet').value = "";
        }
        else {
            document.getElementById('txtstreet').value = global_ds.Tables[0].Rows[z].street;
        }

        //document.getElementById('drpcity').value=global_ds.Tables[0].Rows[z].City_Code;
        if (global_ds.Tables[0].Rows[z].Dist_Code == null || global_ds.Tables[0].Rows[z].Dist_Code == "null") {
            document.getElementById('txtdistrict').value = "";

        }
        else {
            document.getElementById('txtdistrict').value = global_ds.Tables[0].Rows[z].Dist_Code;
        }

        if (global_ds.Tables[0].Rows[z].MESSAGE == null || global_ds.Tables[0].Rows[z].Dist_Code == "null") {
            document.getElementById('txtmessage').value = "";

        }
        else {
            document.getElementById('txtmessage').value = global_ds.Tables[0].Rows[z].MESSAGE;
        }

        document.getElementById('txtcountry').value = global_ds.Tables[0].Rows[z].Country_Code;

        cityvar = global_ds.Tables[0].Rows[z].City_Code;
        addcount(global_ds.Tables[0].Rows[z].Country_Code);
        document.getElementById('drpregion').value = global_ds.Tables[0].Rows[z].Region_code;
        document.getElementById('drpzone').value = global_ds.Tables[0].Rows[z].Zone_code;

        document.getElementById('txtfax1').value = global_ds.Tables[0].Rows[z].Fax1;
        if (global_ds.Tables[0].Rows[z].Phone1 == "" || global_ds.Tables[0].Rows[z].Phone1 == null || global_ds.Tables[0].Rows[z].Phone1 == "undefined") {
            document.getElementById('txtphone1').value = "";
        }
        else {
            document.getElementById('txtphone1').value = global_ds.Tables[0].Rows[z].Phone1;
        }

        if (global_ds.Tables[0].Rows[z].Phone2 == "" || global_ds.Tables[0].Rows[z].Phone2 == null || global_ds.Tables[0].Rows[z].Phone2 == "undefined") {
            document.getElementById('txtphone2').value = "";

        }
        else {
            document.getElementById('txtphone2').value = global_ds.Tables[0].Rows[z].Phone2;
        }
        //document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows.;

        if (global_ds.Tables[0].Rows[z].zip == "" || global_ds.Tables[0].Rows[z].zip == null || global_ds.Tables[0].Rows[z].zip == "undefined") {
            document.getElementById('txtpincode').value = "";
        }
        else {
            document.getElementById('txtpincode').value = global_ds.Tables[0].Rows[z].zip;
        }

        document.getElementById('txtstate').value = global_ds.Tables[0].Rows[z].State_Code;

        if (global_ds.Tables[0].Rows[z].Fax == "" || global_ds.Tables[0].Rows[z].Fax == null || global_ds.Tables[0].Rows[z].Fax == "undefined") {
            document.getElementById('txtfax').value = "";
        }
        else {
            document.getElementById('txtfax').value = global_ds.Tables[0].Rows[z].Fax;
        }

        if (global_ds.Tables[0].Rows[z].EmailID == "" || global_ds.Tables[0].Rows[z].EmailID == null || global_ds.Tables[0].Rows[z].EmailID == "Undefined") {
            document.getElementById('txtemailid').value = "";
        }
        else {
            document.getElementById('txtemailid').value = global_ds.Tables[0].Rows[z].EmailID;
        }

        document.getElementById('txtstatusdate').value = global_ds.Tables[0].Rows[0].Status_date;

        var tdate = global_ds.Tables[0].Rows[z].To_date;
        var cdate = global_ds.Tables[0].Rows[z].Status_date;

        if (global_ds.Tables[0].Rows[z].Pub_Cent_Status == null || global_ds.Tables[0].Rows[z].Pub_Cent_Status == "")
            document.getElementById('txtstatus1').value = "Active";
        else
            document.getElementById('txtstatus1').value = global_ds.Tables[0].Rows[z].Pub_Cent_Status;

        //					if (tdate<cdate)
        //					{
        //					document.getElementById('txtstatus1').value="Banned";
        //					
        //					}
        //					else
        //					{
        //					document.getElementById('txtstatus1').value=global_ds.Tables[0].Rows[z].Pub_Cent_Status;
        //					}

        setButtonImages();
        return false;
    }
    return false;
}

/*****************************Selec The Country And City*****************/

// saurabh Change  function addcount(ab)

function addcount() {

    var country = document.getElementById('txtcountry').value;
    //document.getElementById('drpcity').disabled=false;
    if (country != 0) {
        document.getElementById('drpcity').disabled = false;
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
        PubCatMast.addcou(country, callcount);
    }
    else {
        var pkgitem = document.getElementById("drpcity");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("------Select City------", "0");
        addregcity()
    }

    return false;
}

function callcount(res) {
    if (hiddentext == "new" || hiddentext == "modify") {
        document.getElementById('drpcity').value = "0";
        document.getElementById('drpregion').value = "";
        document.getElementById('drpzone').value = "";
        document.getElementById('txtdistrict').value = "";
        document.getElementById('Statecode12').value = "";
        document.getElementById('txtstate').value = "";

    }
    var ds = res.value;
    var pkgitem = document.getElementById("drpcity");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("------Select City------", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        if (document.getElementById('hiddensaurabh').value == "1") {
            document.getElementById('drpcity').disabled = false;
        }

        var pkgitem = document.getElementById('drpcity');
        pkgitem.options[0] = new Option("------Select City------", "0");

        //var pkgitem = document.getElementById("drpcity");
        //alert(pkgitem);
        pkgitem.options.length = 1;
        //alert(pkgitem.options.length);
        for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name, res.value.Tables[0].Rows[i].City_Code);

            pkgitem.options.length;

        }
        if (cityvar == undefined || cityvar == "") {
            // document.getElementById('drpcity').value=res.value.Tables[0].Rows[0].City_Code;
            document.getElementById('drpcity').value = "0";
        }
        else {
            document.getElementById('drpcity').value = cityvar;
            cityvar = "";
        }
    }

    else {
        if (document.getElementById('txtcountry').disabled == false) {
            alert("There is no matching value(s) found");
        }
        pkgitem.options.length = 0;
        addregcity();
        document.getElementById('drpcity').value = "0";
        document.getElementById('drpregion').value = "";
        document.getElementById('drpzone').value = "";
        document.getElementById('txtdistrict').value = "";
        document.getElementById('Statecode12').value = "";
        document.getElementById('txtstate').value = "";


        return false;

    }

    return false;
}
//*******************************************************************************************************
//function for display the state ,district jone according to city
//**********************************************************************************************************

function addregcity() {
    var city1 = document.getElementById('drpcity').value;
    if (city1 == 0) {
        document.getElementById('txtstate').value = "";
        document.getElementById('txtdistrict').value = "";

        var zone1 = document.getElementById('drpzone');
        zone1.options.length = 0;
        zone1.options[0] = new Option("------Select Zone------", "0");

        var region1 = document.getElementById('drpregion');
        region1.options.length = 0;
        region1.options[0] = new Option("------Select Region------", "0");
        //var pkgitem = document.getElementById("drpcity");
        //pkgitem.options.length = 0; 
        //pkgitem.options[0]=new Option("------Select City------","0");
    }
    else {
        if (document.Form1.drpcity.value != "") {
            PubCatMast.addreg(document.Form1.drpcity.value, FillDropDownList_CallBackMaindoc);
        }
    } 				//document.getElementById('dpstate').focus();	
    return false;

}

function FillDropDownList_CallBackMaindoc(response) {

    var ds = response.value;


    var region = document.getElementById('drpregion');
    var zone = document.getElementById('drpzone');

    //	Saurabh* /*	if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
    /*			{	
    document.getElementById('drpregion').disabled=false;
    var region=document.getElementById('drpregion');
    region.options[0]=new Option("--Select region--","0");
    // document.forms[0].item("drpregion").options.length=0;		
    //document.forms[0].item("drpregion").options.length=ds.Tables[2].Rows.length;
    region.options.length=1;

//saurabh chnage				for(var i=0;i<ds.Tables[2].Rows.length;++i) 

                for(var i=0;i<ds.Tables[0].Rows.length;++i)
    {
    //document.forms[0].item("drpregion").options[i]=new Option(ds.Tables[2].Rows[i].region_name,ds.Tables[2].Rows[i].region_code);

//saurabh chnage					region.options[region.options.length]=new Option(ds.Tables[2].Rows[i].region_name,ds.Tables[2].Rows[i].region_code);

					region.options[region.options.length]=new Option(ds.Tables[0].Rows[i].region_name,ds.Tables[0].Rows[i].region_code);
    region.options.length;
					
    }	
				
    document.getElementById('drpregion').value="0";
				
    //document.getElementById('drpregion').value=ds.Tables[3].Rows[0].region_code;
    // saurabh changed				region.value=ds.Tables[0].Rows[0].region_code;
				
    //document.getElementById("hiddenregion").value=document.getElementById("drpregion").value;
					
    // saurabh changed	  document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
    // saurabh changed	  document.getElementById('txtdistrict').value=ds.Tables[1].Rows[0].dist_name;


// saurabh changed 					addzone();      //this line to below line:-
    // saurabh changed                    PubCatMast.addzone();
    // saurabh changed					document.getElementById('drpzone').value=ds.Tables[0].Rows[0].zone_code;
    //}/*/
    if (document.getElementById('drpcity').value != "0" && document.getElementById('drpcity').value != "") {
        if (ds != null && typeof (ds) == "object" && ds.Tables != null) {
            //			if(ds.Tables.length>4)		
            //			{
            //if(browser!="Microsoft Internet Explorer")
            document.getElementById("drpzone").options[0] = new Option("------Select Zone------", "0");
            document.getElementById("drpregion").options[0] = new Option("-----Select Region-----", "0");

            document.getElementById("drpregion").options.length = 0;
            document.getElementById("drpregion").options.length = ds.Tables[2].Rows.length;

            document.getElementById("drpzone").options.length = 0;
            document.getElementById("drpzone").options.length = ds.Tables[4].Rows.length;



            //alert((document.forms[0].item("drpregion").options.length));	
            //alert(ds.Tables[0].Rows.length);
            if (ds.Tables[3].Rows.length > 0) {
                for (var i = 0; i < ds.Tables[2].Rows.length; ++i) {
                    document.getElementById("drpregion").options[i] = new Option(ds.Tables[2].Rows[i].region_name, ds.Tables[2].Rows[i].region_code);
                }
                document.getElementById('drpregion').value = ds.Tables[3].Rows[0].region_code;
            }
            else {

                if (document.getElementById('drpcity').disabled == false) {
                    //alert("There is no matching value(s) found for region");
                }
                //document.getElementById('drpregion').disabled=true;
                region.options.length = 0;
                //return false;

            }
            /*document.forms[0].item("drpzone").options[0]=new Option("------Select Zone------","0");
            document.forms[0].item("drpregion").options[0]=new Option("-----Select Region-----","0");
				
				document.forms[0].item("drpregion").options.length=0;		
            document.forms[0].item("drpregion").options.length=ds.Tables[2].Rows.length;
				
				document.forms[0].item("drpzone").options.length=0;		
            document.forms[0].item("drpzone").options.length=ds.Tables[4].Rows.length;
				
				
				
            //alert((document.forms[0].item("drpregion").options.length));	
            //alert(ds.Tables[0].Rows.length);
            if(ds.Tables[3].Rows.length>0)
            {	
            for(var i=0;i<ds.Tables[2].Rows.length;++i) 
            {
            document.forms[0].item("drpregion").options[i]=new Option(ds.Tables[2].Rows[i].region_name,ds.Tables[2].Rows[i].region_code);
            }	
            document.getElementById('drpregion').value=ds.Tables[3].Rows[0].region_code;
            }
            else
            {
            if(document.getElementById('drpcity').disabled==false)
            {
            alert("There is no matching value(s) found for region");
            }
            //document.getElementById('drpregion').disabled=true;
            region.options.length=0;
            return false;

                    }*/

            //document.getElementById("hiddenregion").value=document.getElementById("drpregion").value;


            if (ds.Tables[0].Rows.length > 0) {
                document.getElementById('txtstate').value = ds.Tables[0].Rows[0].state_name;
            }
            else {
                if (document.getElementById('drpcity').disabled == false) {
                    alert("There is no matching value for state");
                }
                document.getElementById('txtstate').value = "";
                //document.getElementById('txtstate').disabled=true;

            }



            if (ds.Tables[1].Rows.length > 0) {
                document.getElementById('txtdistrict').value = ds.Tables[1].Rows[0].dist_name;
            }
            else {

                if (document.getElementById('drpcity').disabled == false) {
                    //alert("There is no matching value for district");
                }
                document.getElementById('txtdistrict').value = "";

            }



            //	PubCatMast.addzone();

            //		if(ds.Tables[2].Rows.length>0)
            //		{
            //		    for(var j=0;j<ds.Tables[5].Rows.length;++j) 
            //		    {
            //	    		document.forms[0].item("drpregion").options[j]=new Option(ds.Tables[2].Rows[j].region_name,ds.Tables[2].Rows[j].region_code);
            //		    }
            //		    document.getElementById('drpregion').value=ds.Tables[3].Rows[0].region_code;
            //		}
            //				else
            //                {
            //                    alert("There is no matching value(s) found for region");
            //                    region.options.length=0;
            //                    return false;

            //                }



            //				if(ds.Tables[5].Rows.length>0)
            //				{
            ////					document.getElementById('drpzone').value=ds.Tables[5].Rows[0].zone_code;
            //				}
            //				else
            //                {
            //                    alert("There is no matching value(s) found for Zone");
            //                    zone.options.length=0;
            //                    return false;

            //                }	

            // saurabh Change

            if (ds.Tables[5].Rows.length > 0) {
                for (var i = 0; i < ds.Tables[4].Rows.length; ++i) {
                    document.getElementById("drpzone").options[i] = new Option(ds.Tables[4].Rows[i].zone_name, ds.Tables[4].Rows[i].zone_code);
                }
                document.getElementById('drpzone').value = ds.Tables[5].Rows[0].zone_code;
            }
            else {
                if (document.getElementById('drpcity').disabled == false) {
                    //alert("There is no matching value(s) found for Zone");
                }
                zone.options.length = 0;
                document.getElementById('drpzone').disabled = true;
                return false;
            }

            if (document.getElementById('hiddensaurabh').value == "1") {
                document.getElementById('drpregion').disabled = false;
                document.getElementById('drpzone').disabled = false;
            }

            //				}	

        }


    }
    //document.getElementById('txtdistrict').value="";
    return false;
}
/**********************************END***************************************************************************/
/*==============================status Details=========================*/

function statusdetails() {
    if (hiddentext == "new") {
        checkcode();
        var ds = res2.value;
        if (ds == null) {
            return false;
        }
        if (ds.Tables[0].Rows.length != 0)//&& ds1.Tables[1].Rows.length!=0)
        {
            alert("This center code has already been assigned !! ");
            document.getElementById('txtcentercode').value = "";
            //document.getElementById('txtalias').value="";
            if (document.getElementById('txtcentercode').disabled == false)
                document.getElementById('txtcentercode').focus();
            return false;
        }
    }

    if ((trim(document.getElementById('txtcentercode').value) != "") && (document.getElementById('txtcentercode').value != null)) {
        var centercode = document.getElementById('txtcentercode').value;

        for (var index = 0; index < 200; index++) {

            var centercode = document.getElementById('txtcentercode').value;

            popUpWin1 = window.open("pubstatdetails.aspx?centcode=" + centercode + "&show=" + show, 'a2', "status=0,toolbar=0,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px");
            popUpWin1.focus();
            return false;
        }

        return false;
    }
    else if (document.getElementById('hiddenauto').value != 1) {
        alert("Please Enter The Publication Center Code");
        document.getElementById('txtcentercode').disabled = false;
        document.getElementById('txtcentercode').value = "";
        document.getElementById('txtcentercode').focus();
        return false;
    }
    else {
        alert("Please Enter The Publication Center Name");
        document.getElementById('txtcentername').disabled = false;
        document.getElementById('txtcentername').value = "";
        document.getElementById('txtcentername').focus();
        return false;

    }

}
//*************************************************************************************************

function submitstatus() {
    //var flag = 1;
    //   opener.document.getElementById('hidden0s').value=document.getElementById('hiddencentcode').value;        

    opener.document.getElementById('hidden1s').value = document.getElementById('txtfrom').value;
    opener.document.getElementById('hidden2s').value = document.getElementById('drpstatus').value;
    opener.document.getElementById('hidden3s').value = document.getElementById('txtto').value;
    opener.document.getElementById('hidden4s').value = document.getElementById('txtCircular').value;
    //	    opener.document.getElementById('hidden5s').value=document.getElementById('txtext').value;
    //	    opener.document.getElementById('hidden6s').value=document.getElementById('txtfaxno').value;
    //	    opener.document.getElementById('hidden7s').value=document.getElementById('txtemailid').value;

    opener.document.getElementById('hiddencpcds').value = document.getElementById('hiddencompcode').value;
    opener.document.getElementById('hiddenuids').value = document.getElementById('hiddenuserid').value;
    opener.document.getElementById('hiddencrcds').value = document.getElementById('hiddencentcode').value;
    opener.document.getElementById('hiddendfs').value = document.getElementById('hiddendateformat').value;

    //if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null)
    //{

    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var centcode = document.getElementById('hiddencentcode').value;
    var status = document.getElementById('drpstatus').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var circular = document.getElementById('txtCircular').value;
    //hiddenccode
    var codepass = document.getElementById('hiddenccode').value;

    var fromdate = document.getElementById('txtfrom').value;
    var todate = document.getElementById('txtto').value;

    var fd = new Date(fromdate);
    var td = new Date(todate);

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbFrom').textContent;
    }
    else {
        bc = document.getElementById('lbFrom').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtfrom').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtfrom').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbStaus').textContent;
    }
    else {
        bc = document.getElementById('lbStaus').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('drpstatus').value) == "0") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('drpstatus').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbTO').textContent;
    }
    else {
        bc = document.getElementById('lbTO').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtto').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtto').focus();
            return false;
        }
    }

    //////////////////




    ///////////////////	

























    //            if(td<fd)
    //            {
    //                alert('To date should be greater than from date');
    //                document.getElementById('txtto').value="";
    //				document.getElementById('txtto').focus();
    //                return false;
    //            }

    if (dateformat == "dd/mm/yyyy") {
        var txt = document.getElementById('txtfrom').value;
        var txt1 = txt.split("/");
        var dd = txt1[0];
        var mm = txt1[1];
        var yy = txt1[2];
        fromdate = mm + '/' + dd + '/' + yy;
        document.getElementById('ttformdate').value = document.getElementById('txtfrom').value;
    }
    else if (dateformat == "mm/dd/yyyy") {
        fromdate = document.getElementById('txtfrom').value;
        document.getElementById('ttformdate').value = document.getElementById('txtfrom').value;
    }

    else if (dateformat == "yyyy/mm/dd") {
        var txt = document.getElementById('txtfrom').value;
        var txt1 = txt.split("/");
        var yy = txt1[0];
        var mm = txt1[1];
        var dd = txt1[2];
        fromdate = mm + '/' + dd + '/' + yy;
        document.getElementById('ttformdate').value = document.getElementById('txtfrom').value;
    }
    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        alert("Dateformat  is either null or undefined");
        fromdate = document.getElementById('txtfrom').value;
    }


    /*===========================todate===================*/


    if (dateformat == "dd/mm/yyyy") {
        var txt = document.getElementById('txtto').value;
        var txt1 = txt.split("/");
        var dd = txt1[0];
        var mm = txt1[1];
        var yy = txt1[2];
        todate = mm + '/' + dd + '/' + yy;
        document.getElementById('tttodate').value = document.getElementById('txtto').value;
    }
    if (dateformat == "mm/dd/yyyy") {
        todate = document.getElementById('txtto').value;
        document.getElementById('tttodate').value = todate;
    }

    if (dateformat == "yyyy/mm/dd") {
        var txt = document.getElementById('txtto').value;
        var txt1 = txt.split("/");
        var yy = txt1[0];
        var mm = txt1[1];
        var dd = txt1[2];
        todate = mm + '/' + dd + '/' + yy;
        document.getElementById('tttodate').value = document.getElementById('txtto').value;
    }
    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        alert("dateformat  is either null or undefined");
        todate = document.getElementById('txtto').value;
    }

    //				document.getElementById('txtto').value=todate;
    //				document.getElementById('txtfrom').valu=fromdate;
    //}

    var fdate = new Date(fromdate);
    var tdate = new Date(todate);



    if (fdate > tdate) {
        alert("To date must be greater then from date");
        return false;
    }
    //}
    //alert(pubstatdetails);

    //if(codepass=="" ||codepass== null)

    //        {

    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var centcode = document.getElementById('hiddencentcode').value;
    var status = document.getElementById('drpstatus').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var circular = document.getElementById('txtCircular').value;
    //var todate=document.getElementById('txtto').value;

    var dateformat = dateformat;
    var status = status;
    var centcode = centcode;
    var fdate = fromdate;
    var todate = todate;

    var circular = circular;
    if (modify != "1") {
        //pubstatdetails.insertpcm(compcode,userid,centcode,status,circular,todate,fromdate,dateformat,insertpcmcall)
        //                    var dateformat="";
        //                    var status="";
        //                    var centcode=centcode;
        //                    var fdate="";
        //                    var todate="";
        //                    var circular="";
        var hidfdate = document.getElementById('hiddenfdate').value;
        var hidtdate = document.getElementById('hiddentdate').value;
        if (hidfdate != "") {
            var arrfdate = hidfdate.split(",");
            var arrtdate = hidtdate.split(",");
            for (var a = 0; a < arrfdate.length; a++) {
                var fdate = arrfdate[a].split("/");
                var fday = fdate[1];
                var fmonth = fdate[0];
                var fyear = fdate[2];

                var txtfdatev = document.getElementById('txtfrom').value;
                var txtfdate = txtfdatev.split("/");
                var txtfday = txtfdate[1];
                var txtfmonth = txtfdate[0];
                var txtfyear = txtfdate[2];

                var tdate = arrtdate[a].split("/");
                var tday = tdate[1];
                var tmonth = tdate[0];
                var tyear = tdate[2];

                var txttdatev = document.getElementById('txtto').value;
                var txttdate = txttdatev.split("/");
                var txttday = txttdate[1];
                var txttmonth = txttdate[0];
                var txttyear = txttdate[2];

                if (((txtfyear >= fyear) && (txtfyear <= tyear)) || ((txttyear >= fyear) && (txttyear <= tyear))) {
                    if (((txtfmonth >= fmonth) && (txtfmonth <= tmonth)) || ((txttmonth >= fmonth) && (txttmonth <= tmonth))) {
                        if (((txtfday >= fday) && (txtfday <= tday)) || ((txttday >= fday) && (txttday <= tday))) {
                            alert("This date is already assigned");
                            return false;
                        }
                    }
                }
            }
        }

        var dl = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

            httpRequest.open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
            httpRequest.send('');
            if (httpRequest.readyState == "yes") {
                alert('Session Expired Please Login Again.');
                return false;
            }

            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) {
                    dl = httpRequest.responseText;
                }
                else {
                    alert('Session Expired.Please Login Again.');
                }
            }

            else {
                alert('Session Expired.Please Login Again.');
                return false;
            }

        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
            xml.Send();
            dl = xml.responseText;
        }
        if (dl == "yes") {
            alert('Session Expired.Please Login Again.');
            return false;
        }

        var splitval = dl.split(",");
        dl = splitval[0];
        //		            var statusorignal=splitval[1];
        //		             opener.document.getElementById('txtstatus1').value=statusorignal;

        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        var centcode = document.getElementById('hiddencentcode').value;
        var status = document.getElementById('drpstatus').value;
        var dateformat = document.getElementById('hiddendateformat').value;
        var circular = document.getElementById('txtCircular').value;
        //var todate=document.getElementById('txtto').value;


        if (dl == "yes") {
            alert('Session Expired.Please Login Again.');
            return false;
        }
        if (dl == "Y") {

            alert("This date is already assigned");
            return false;

        }
        else {

            if (opener.document.getElementById('hiddenchk').value == "1") {
                if (flag2 == "1") {
                    // pubstatdetails.updatepcm(compcode,userid,centcode,status,circular,todate,fromdate,dateformat,codepass,updatepcmcall);
                    pubstatdetails.updatepcm12(compcode, userid, centcode, status, circular, todate, fromdate, codepass);

                    var dl = "";
                    if (browser != "Microsoft Internet Explorer") {
                        var httpRequest = null; ;
                        httpRequest = new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                            httpRequest.overrideMimeType('text/xml');
                        }

                        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                        httpRequest.open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
                        httpRequest.send('');
                        if (httpRequest.readyState == "yes") {
                            alert('Session Expired Please Login Again.');
                            return false;
                        }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) {
                                dl = httpRequest.responseText;
                            }
                            else {
                                alert('Session Expired.Please Login Again.');
                            }
                        }
                        else {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                    }
                    else {
                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                        xml.Open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
                        xml.Send();
                        dl = xml.responseText;
                    }
                    if (dl == "yes") {
                        alert('Session Expired.Please Login Again.');
                        return false;
                    }
                    var splitval = dl.split(",");
                    dl = splitval[0];
                    var statusorignal = splitval[1].replace("'", "");
                    statusorignal = statusorignal.replace("'", "");
                    if (statusorignal == "")
                        opener.document.getElementById('txtstatus1').value = "Active";
                    else
                        opener.document.getElementById('txtstatus1').value = statusorignal;

                    window.location = window.location;
                    return false;
                }
                else {
                    pubstatdetails.insertpcm(compcode, userid, centcode, status, circular, todate, fromdate, dateformat, insertpcmcall);

                    var dl = "";
                    if (browser != "Microsoft Internet Explorer") {
                        var httpRequest = null; ;
                        httpRequest = new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                            httpRequest.overrideMimeType('text/xml');
                        }

                        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                        httpRequest.open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
                        httpRequest.send('');
                        if (httpRequest.readyState == "yes") {
                            alert('Session Expired Please Login Again.');
                            return false;
                        }
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) {
                                dl = httpRequest.responseText;
                            }
                            else {
                                alert('Session Expired.Please Login Again.');
                            }
                        }
                        else {
                            alert('Session Expired.Please Login Again.');
                            return false;
                        }
                    }
                    else {
                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                        xml.Open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
                        xml.Send();
                        dl = xml.responseText;
                    }
                    if (dl == "yes") {
                        alert('Session Expired.Please Login Again.');
                        return false;
                    }
                    var splitval = dl.split(",");
                    dl = splitval[0];
                    var statusorignal = splitval[1];
                    opener.document.getElementById('txtstatus1').value = statusorignal;

                    return false;
                }
            }
            else {
                return;
            }
        }


    }
    else {

        //	pubstatdetails.updatepcm(compcode,userid,centcode,status,circular,todate,fromdate,dateformat,codepass,updatepcmcall);
        pubstatdetails.updatepcm12(compcode, userid, centcode, status, circular, todate, fromdate, codepass);

        var dl = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

            httpRequest.open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
            httpRequest.send('');
            if (httpRequest.readyState == "yes") {
                alert('Session Expired Please Login Again.');
                return false;
            }
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) {
                    dl = httpRequest.responseText;
                }
                else {
                    alert('Session Expired.Please Login Again.');
                }
            }
            else {
                alert('Session Expired.Please Login Again.');
                return false;
            }

        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
            xml.Send();
            dl = xml.responseText;
        }

        if (dl == "yes") {
            alert('Session Expired.Please Login Again.');
            return false;
        }
        var splitval = dl.split(",");
        dl = splitval[0];
        var statusorignal = splitval[1];
        opener.document.getElementById('txtstatus1').value = statusorignal;

        window.location = window.location;
        return false;
    }

    var dl = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null; ;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                dl = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "chkpubcatmaststatus.aspx?centcode=" + centcode + "&status=" + status + "&dateformat=" + dateformat + "&fdate=" + fdate + "&todate=" + todate + "&circular=" + circular, false);
        xml.Send();
        dl = xml.responseText;
    }
    if (dl == "yes") {
        alert('Session Expired.Please Login Again.');
        return false;
    }
    var splitval = dl.split(",");
    dl = splitval[0];
    var statusorignal = splitval[1];
    opener.document.getElementById('txtstatus1').value = statusorignal;
}
//}

function updatepcmcall(response) {
    var ds = response.value;
    if (ds == "fail") {
        alert("This date has been already assigned");
        return false;

    }

    else {

        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        var centcode = document.getElementById('hiddencentcode').value;
        var status = document.getElementById('drpstatus').value;
        var dateformat = document.getElementById('hiddendateformat').value;
        var circular = document.getElementById('txtCircular').value;
        var codepass = document.getElementById('hiddenccode').value;

        var fromdate, todate;

        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbFrom').textContent;
        }
        else {
            bc = document.getElementById('lbFrom').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (trim(document.getElementById('txtfrom').value) == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtfrom').focus();
                return false;
            }
        }

        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbStaus').textContent;
        }
        else {
            bc = document.getElementById('lbStaus').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (trim(document.getElementById('drpstatus').value) == "0") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('drpstatus').focus();
                return false;
            }
        }

        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbTO').textContent;
        }
        else {
            bc = document.getElementById('lbTO').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (trim(document.getElementById('txtto').value) == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtto').focus();
                return false;
            }
        }




        if (dateformat == "dd/mm/yyyy") {
            var txt = document.getElementById('txtfrom').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            fromdate = mm + '/' + dd + '/' + yy;
        }
        else if (dateformat == "mm/dd/yyyy") {
            fromdate = document.getElementById('txtfrom').svalue;
        }

        else if (dateformat == "yyyy/mm/dd") {
            var txt = document.getElementById('txtfrom').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            fromdate = mm + '/' + dd + '/' + yy;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            alert("dateformat  is either null or undefined");
            fromdate = document.getElementById('txtfrom').value;
        }


        /*===========================todate===================*/


        if (dateformat == "dd/mm/yyyy") {
            var txt = document.getElementById('txtto').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            todate = mm + '/' + dd + '/' + yy;
        }
        if (dateformat == "mm/dd/yyyy") {
            todate = document.getElementById('txtto').value;
        }

        if (dateformat == "yyyy/mm/dd") {
            var txt = document.getElementById('txtto').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            todate = mm + '/' + dd + '/' + yy;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            alert("dateformat  is either null or undefined");
            todate = document.getElementById('txtto').value;
        }


        var fdate = new Date(fromdate);
        var tdate = new Date(todate);


        if (fdate > tdate) {
            alert("To date must be greater then from date");
            return false;
        }


        pubstatdetails.updatepcm12(compcode, userid, centcode, status, circular, todate, fromdate, codepass)


        //alert("Data Modified");
        //alert(xmlObj.childNodes(0).childNodes(1).text);

        window.location = window.location;


        return false;

    }



}
function insertpcmcall(response) {

    var ds = response.value;
    if (ds == "fail") {
        alert("This date has been already assigned");
        return false;

    }

    else {

        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        var centcode = document.getElementById('hiddencentcode').value;
        var status = document.getElementById('drpstatus').value;
        var dateformat = document.getElementById('hiddendateformat').value;
        var circular = document.getElementById('txtCircular').value;

        var fromdate, todate;

        if (trim(document.getElementById('txtfrom').value) == "") {
            alert("Please enter from date");
            document.getElementById('txtfrom').value = "";
            document.getElementById('txtfrom').focus();
            return false;
        }
        else if (document.getElementById('drpstatus').value == "0") {
            alert("Please select status");
            document.getElementById('drpstatus').focus();
            return false;
        }
        else if (trim(document.getElementById('txtto').value) == "") {
            alert("Please enter to date");
            document.getElementById('txtfrom').value = "";
            document.getElementById('txtto').focus();
            return false;
        }


        if (dateformat == "dd/mm/yyyy") {
            var txt = document.getElementById('txtfrom').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            fromdate = mm + '/' + dd + '/' + yy;
        }
        else if (dateformat == "mm/dd/yyyy") {
            fromdate = document.getElementById('txtfrom').value;
        }

        else if (dateformat == "yyyy/mm/dd") {
            var txt = document.getElementById('txtfrom').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            fromdate = mm + '/' + dd + '/' + yy;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            alert("dateformat  is either null or undefined");
            fromdate = document.getElementById('txtfrom').value;
        }


        /*===========================todate===================*/


        if (dateformat == "dd/mm/yyyy") {
            var txt = document.getElementById('txtto').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            todate = mm + '/' + dd + '/' + yy;
        }
        if (dateformat == "mm/dd/yyyy") {
            todate = document.getElementById('txtto').value;
        }

        if (dateformat == "yyyy/mm/dd") {
            var txt = document.getElementById('txtto').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            todate = mm + '/' + dd + '/' + yy;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            alert("dateformat  is either null or undefined");
            todate = document.getElementById('txtto').value;
        }


        var fdate = new Date(fromdate);
        var tdate = new Date(todate);


        if (fdate > tdate) {
            alert("To date must be greater then from date");
            return false;
        }
        var dateformat = document.getElementById('hiddendateformat').value;

        pubstatdetails.insertpcm12(compcode, userid, centcode, status, fromdate, todate, circular, dateformat);


        //alert("Data Saved");
        //alert(xmlObj.childNodes(0).childNodes(0).text);

        window.location = window.location;


        return;

    }

}


//************************************Code Of PoP Up of  Staus Details************************************
//Select Status//
function selectstatus(ab) {
    var id = ab;
    //saurabh code------------------------------------------------------------------------

    if (document.getElementById(id).checked == false) {
        flag2 = "0";
        document.getElementById('txtfrom').value = "";
        document.getElementById('txtto').value = "";
        document.getElementById('drpstatus').value = "0";
        document.getElementById('txtCircular').value = "";
        if (opener.document.getElementById('hiddensubmod').value == 0) {
            document.getElementById('btnsubmit').disabled = true;
        }
        else {
            document.getElementById('btnsubmit').disabled = false;
        }
        document.getElementById('btndelete').disabled = true;
        document.getElementById(ab).checked = false;
        return; // false;

    }





    //--------------------------------------------------------------------------------------


    var centcode = document.getElementById('hiddencentcode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var datagrid = document.getElementById('DataGrid1')
    var dateformat = document.getElementById('hiddendateformat').value;
    var j;
    var k = 0;

    var i = document.getElementById("DataGrid1").rows.length - 1;

    for (j = 0; j < i; j++) {
        //var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
        var str = "DataGrid1__ctl_CheckBox1" + j;
        document.getElementById(str).checked = false;
        document.getElementById(id).checked = true;
        // saurabh change    
        if (document.getElementById('hiddendelsau').value == "1") {
            document.getElementById('btndelete').disabled = false;
        }

        if (id == str) {
            if (document.getElementById(id).checked == true) {
                k = k + 1;
                code11 = document.getElementById(str).value;
                chkclick = document.getElementById(id);

                //saurabh change

                if (document.getElementById('hiddendelsau').value == "1") {
                    document.getElementById('btndelete').disabled = false;
                }

            }
        }
    }
    if (k == 1) {
        if ((document.getElementById('hiddenshow').value == "1")) {
            document.getElementById('btndelete').disabled = false;
        }
        //	else
        //	{
        //		document.getElementById('btndelete').disabled=false;
        //	
        //	}
        pubstatdetails.bandstatus(centcode, compcode, userid, code11, dateformat, callselectstatus);
    }
    else if (k == 0) {
        chkclick.checked = false;
        document.getElementById('txtfrom').value = "";
        document.getElementById('txtto').value = "";
        document.getElementById('drpstatus').value = "0";
        document.getElementById('txtCircular').value = "";

        return false;
    }
    document.getElementById(ab).checked = true;

    if (document.getElementById('hiddenshow').value == "2") {
        if (document.getElementById('btnsubmit').disabled == false) {
            flag2 = "1";
        }
        else {
            flag2 = "0";
        }
    }
    else {
        flag2 = "0";
    }


    //	show="3";
    //	return;
    //popclear();
}

//For Clear The Field//
function popclear() {
    //chkclick.checked=false;

    flag2 = "0";

    document.getElementById('txtfrom').value = "";
    document.getElementById('txtto').value = "";
    document.getElementById('drpstatus').value = "0";
    document.getElementById('txtCircular').value = "";


    if (((document.getElementById('btndelete').disabled == true) && (document.getElementById('btnsubmit').disabled == true)) || ((document.getElementById('btndelete').disabled == false) && (document.getElementById('btnsubmit').disabled == false))) {

        var j;
        var k = 0;

        var i = document.getElementById("DataGrid1").rows.length - 1;

        for (j = 0; j < i; j++) {
            //var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
            var str = "DataGrid1__ctl_CheckBox1" + j;
            document.getElementById(str).checked = false;
            document.getElementById('btndelete').disabled = true;
            if (opener.document.getElementById('hiddensubmod').value == 0) {
                document.getElementById('btnsubmit').disabled = true;
            }
            else {
                document.getElementById('btnsubmit').disabled = false;
            }
            //document.getElementById('btnsubmit').disabled=true;
        }
    }
    //document.getElementById('txtfrom').disabled=false;
    //document.getElementById('txtto').disabled=false;
    //document.getElementById('drpstatus').disabled=false;
    //document.getElementById('txtCircular').disabled=false;
    return false;
}

//responce of Select Status//
function callselectstatus(response) {
    var ds = response.value;
    if (ds == null) {
        alert(response.error.description);
        return false;
    }
    document.getElementById('hiddenccode').value = ds.Tables[0].Rows[0].stat_code;
    document.getElementById('drpstatus').value = ds.Tables[0].Rows[0].cent_status;

    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;


    document.getElementById('txtfrom').value = ds.Tables[0].Rows[0].From_date;
    document.getElementById('txtto').value = ds.Tables[0].Rows[0].to_date;
    if (ds.Tables[0].Rows[0].circular != null) {
        document.getElementById('txtCircular').value = ds.Tables[0].Rows[0].circular;
    }
    else {
        document.getElementById('txtCircular').value = "";
    }

    if (document.getElementById('hiddenshow').value == "1") {
        document.getElementById('btndelete').disabled = true;
        document.getElementById('btnsubmit').disabled = true;
    }
    else if (document.getElementById('hiddenshow').value == "2") {
        document.getElementById('btndelete').disabled = false;
        document.getElementById('btnsubmit').disabled = false;
    }
    //	else
    //	{
    //		document.getElementById('btndelete').disabled=false;
    //	    document.getElementById('btnsubmit').disabled=false;
    //	}
    //document.getElementById('btnsubmit').disabled=false;
    //document.getElementById('btnDelete').disabled= false;
    //document.getElementById('btnselect').disabled=false;
    //document.getElementById('btnSave').disabled=false;


    return false;
}

//Delete the select status//
function statusdelete() {
    var centcode = document.getElementById('hiddencentcode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var codepass = document.getElementById('hiddenccode').value;


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
    pubstatdetails.deletestatuspcm(centcode, compcode, userid, codepass);

    document.getElementById('drpstatus').value = "0";
    document.getElementById('txtfrom').value = "";
    document.getElementById('txtto').value = "";
    document.getElementById('hiddenccode').value = "";
    //alert("Data Deletd") ;
    //alert(xmlObj.childNodes(0).childNodes(2).text);

    window.location = window.location;
    return false;

}


function contactdetails() {
    if (hiddentext == "new") {
        checkcode();
        var ds = res2.value;
        if (ds == null) {
            return false;
        }
        if (ds.Tables[0].Rows.length != 0)//&& ds1.Tables[1].Rows.length!=0)
        {
            alert("This center code has already been assigned !! ");
            document.getElementById('txtcentercode').value = "";
            //document.getElementById('txtalias').value="";
            if (document.getElementById('txtcentercode').disabled == false)
                document.getElementById('txtcentercode').focus();
            return false;
        }
    }

    //  return false;
    //var cc= document.getElementById('txtcentercode').value;
    if ((trim(document.getElementById('txtcentercode').value) != "") && (document.getElementById('txtcentercode').value != null)) {
        for (var index = 0; index < 200; index++) {

            var centercode = document.getElementById('txtcentercode').value;

            popUpWin = window.open("pcmcontdetails.aspx?centcode=" + centercode + "&show=" + show, 'a1', "status=0,toolbar=0,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px");
            popUpWin.focus();
            return false;
        }

        return false;
    }

    else if (document.getElementById('hiddenauto').value != 1) {
        alert("Please Enter The Publication Center Code");
        document.getElementById('txtcentercode').disabled = false;
        document.getElementById('txtcentercode').value = "";
        document.getElementById('txtcentercode').focus();
        return false;
    }
    else {
        alert("Please Enter The Publication Center Name");
        document.getElementById('txtcentername').disabled = false; ;
        document.getElementById('txtcentername').value = "";
        document.getElementById('txtcentername').focus();
        return false;
    }
}

//***************************************Code Of PoP Up Of Contact Details********************************

//  Change by Saurabh Agarwal

function saurabhClientEmailCheck(q) {
    var theurl = document.getElementById(q).value;

    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == "") {
        return (true)
    }
    alert("Invalid e-mail address! please re-enter.")
    document.getElementById(q).value = "";
    document.getElementById(q).focus();
    return (false)
}

//*************************************************************************************************************

//********************************************************************************************************

//submit contact//
function submitcont() {

    opener.document.getElementById('hidden1').value = document.getElementById('txtcontactperson').value;
    opener.document.getElementById('hidden2').value = document.getElementById('txtphoneno').value;
    opener.document.getElementById('hidden3').value = document.getElementById('txtdesignation').value;
    opener.document.getElementById('hidden4').value = document.getElementById('txtphoneno').value;
    opener.document.getElementById('hidden5').value = document.getElementById('txtext').value;
    opener.document.getElementById('hidden6').value = document.getElementById('txtfaxno').value;
    opener.document.getElementById('hidden7').value = document.getElementById('txtemailid').value;

    opener.document.getElementById('hiddencpcd').value = document.getElementById('hiddencompcode').value;
    opener.document.getElementById('hiddenuid').value = document.getElementById('hiddenuserid').value;
    opener.document.getElementById('hiddencrcd').value = document.getElementById('hiddencentcode').value;



    //var dt=document.getElementById('txtdob').value;



    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbcontperson').textContent;
    }
    else {
        bc = document.getElementById('lbcontperson').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtcontactperson').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtcontactperson').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbphoneno').textContent;
    }
    else {
        bc = document.getElementById('lbphoneno').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtphoneno').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtphoneno').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbdob').textContent;
    }
    else {
        bc = document.getElementById('lbdob').innerText;
    }
    //    if(bc.indexOf('*')>= 0 )
    //    {
    //        if(trim(document.getElementById('txtdob').value)== "" )
    //        {   
    //	        alert('Please Enter '+(bc.replace('*', "")));
    //            document.getElementById('txtdob').focus();
    //            return false;
    //        }
    //    }



    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbdesignation').textContent;
    }
    else {
        bc = document.getElementById('lbdesignation').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtdesignation').value) == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtdesignation').focus();
            return false;
        }
    }
    var msg1 = ClientEmailCheck1("txtemailid");
    if (msg1 == false)
        return false;

    var contactperson = trim(document.getElementById('txtcontactperson').value);
    //var txtdob=document.getElementById('txtdob').value;
    var txtphoneno = trim(document.getElementById('txtphoneno').value);
    var txtext = trim(document.getElementById('txtext').value);
    var txtfaxno = trim(document.getElementById('txtfaxno').value);
    var mail = document.getElementById('txtemailid').value;



    var centcode = document.getElementById('hiddencentcode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var hiddenccode = document.getElementById('hiddenccode').value;
    var desi = document.getElementById('txtdesignation').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var txtdob = "";
    if (document.getElementById('txtdob').value != "") {
        if (dateformat == "dd/mm/yyyy") {
            var txt = document.getElementById('txtdob').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            txtdob = mm + '/' + dd + '/' + yy;
        }
        else if (dateformat == "mm/dd/yyyy") {
            txtdob = document.getElementById('txtdob').value;
        }

        else if (dateformat == "yyyy/mm/dd") {
            var txt = document.getElementById('txtdob').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            txtdob = mm + '/' + dd + '/' + yy;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            alert("dateformat  is either null or undefined");
            txtdob = document.getElementById('txtdob').value;
        }

        var dt = txtdob;
        var dts = new Date(dt);
        var dn = new Date();
        if (dn < dts) {
            alert("Date should be less than current Date.");
            document.getElementById('txtdob').value = "";
            document.getElementById('txtdob').focus();
            return false;

        }
    }
    //     var contactperson=document.getElementById('hiddencentcode').value;
    var compcode = compcode;
    var centcode = centcode;

    // pcmcontdetails.chkcontact(contactperson,centcode, compcode,insert_call);
    //                txtphoneno,txtext,txtfaxno,mail,desi,txtdob
    var hidden = document.getElementById('hiddenDup');

    if (hidden.value != "") {
        var hiddata = hidden.value;
        var arr = hiddata.split(",");

        for (var a = 0; a < arr.length; a++) {
            if (arr[a] == document.getElementById('txtcontactperson').value) {
                alert('This contact name already exists');
                return false;
            }
        }
    }




    // saurabh    
    if (modify != "1") {
        if (opener.document.getElementById('hiddenchk').value == "1") {
            if (flag1 == "1") {
                var sau = "saurabh";

                var dl = "";
                if (browser != "Microsoft Internet Explorer") {
                    var httpRequest = null; ;
                    httpRequest = new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml');
                    }

                    httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                    httpRequest.open("GET", "chkpcmcontact.aspx?contactperson=" + contactperson + "&sau=" + sau + "&centcode=" + centcode + "&txtphoneno=" + txtphoneno + "&txtext=" + txtext + "&txtfaxno=" + txtfaxno + "&mail=" + mail + "&desi=" + desi + "&txtdob=" + txtdob, false);
                    httpRequest.send('');
                    //alert(httpRequest.readyState);
                    if (httpRequest.readyState == 4) {
                        //alert(httpRequest.status);
                        if (httpRequest.status == 200) {
                            dl = httpRequest.responseText;
                        }
                        else {
                            alert('Session Expired.Please Login Again.');
                        }
                    }
                }
                else {
                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
                    xml.Open("GET", "chkpcmcontact.aspx?contactperson=" + contactperson + "&sau=" + sau + "&centcode=" + centcode + "&txtphoneno=" + txtphoneno + "&txtext=" + txtext + "&txtfaxno=" + txtfaxno + "&mail=" + mail + "&desi=" + desi + "&txtdob=" + txtdob, false);
                    xml.Send();
                    dl = xml.responseText;
                }
                if (dl == "Y" && contactperson != chkmodname) {
                    alert("This contact name already exists");
                    document.getElementById('txtcontactperson').focus();
                    return false;

                }
                sau = "";
                var dateformat = document.getElementById('hiddendateformat').value;
                compcode = trim(compcode);
                userid = trim(userid);
                centcode = trim(centcode);
                hiddenccode = trim(hiddenccode);
                pcmcontdetails.submitcontact(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, centcode, compcode, userid, hiddenccode, dateformat);
                if (browser != "Microsoft Internet Explorer") {
                    //alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else {
                    //alert(xmlObj.childNodes(0).childNodes(1).text);
                }
                window.location = window.location;
                return false;
            }
            else {

                var sau = "";
                var dl = "";
                if (browser != "Microsoft Internet Explorer") {
                    var httpRequest = null; ;
                    httpRequest = new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml');
                    }

                    httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                    httpRequest.open("GET", "chkpcmcontact.aspx?contactperson=" + contactperson + "&centcode=" + centcode + "&sau=" + sau + "&txtphoneno=" + txtphoneno + "&txtext=" + txtext + "&txtfaxno=" + txtfaxno + "&mail=" + mail + "&desi=" + desi + "&txtdob=" + txtdob, false);
                    httpRequest.send('');
                    if (httpRequest.readyState == "yes") {
                        alert('Session Expired Please Login Again.');
                        return false;
                    }
                    //alert(httpRequest.readyState);
                    if (httpRequest.readyState == 4) {
                        //alert(httpRequest.status);
                        if (httpRequest.status == 200) {
                            dl = httpRequest.responseText;
                        }
                        else {
                            alert('Session Expired.Please Login Again.');
                        }
                    }

                    else {
                        alert('Session Expired.Please Login Again.');
                        return false;
                    }
                }
                else {
                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
                    xml.Open("GET", "chkpcmcontact.aspx?contactperson=" + contactperson + "&centcode=" + centcode + "&sau=" + sau + "&txtphoneno=" + txtphoneno + "&txtext=" + txtext + "&txtfaxno=" + txtfaxno + "&mail=" + mail + "&desi=" + desi + "&txtdob=" + txtdob, false);
                    xml.Send();
                    dl = xml.responseText;
                }

                if (dl == "yes") {
                    alert('Session Expired.Please Login Again.');
                    return false;
                }
                if (dl == "Y") {
                    alert("This contact name already exists");

                    document.getElementById('txtcontactperson').focus();
                    return false;

                }

                pcmcontdetails.chkcontact(contactperson, centcode, compcode, insert_call);
                return false;
            }
            //                          pcmcontdetails.insertcontact(contactperson1,txtdob1,txtphoneno1,desi,txtext1,txtfaxno1,mail1,centcode1,compcode1,userid1);
        }
        else {
            return;
        }


    }
    else {
        var sau = "saurabh";

        var dl = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

            httpRequest.open("GET", "chkpcmcontact.aspx?contactperson=" + contactperson + "&centcode=" + centcode + "&sau=" + sau + "&txtphoneno=" + txtphoneno + "&txtext=" + txtext + "&txtfaxno=" + txtfaxno + "&mail=" + mail + "&desi=" + desi + "&txtdob=" + txtdob, false);
            httpRequest.send('');
            if (httpRequest.readyState == "yes") {
                alert('Session Expired Please Login Again.');
                return false;
            }
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) {
                    dl = httpRequest.responseText;
                }
                else {
                    alert('Session Expired.Please Login Again.');
                }
            }
            else {
                alert('Session Expired.Please Login Again.');
                return false;
            }
        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "chkpcmcontact.aspx?contactperson=" + contactperson + "&centcode=" + centcode + "&sau=" + sau + "&txtphoneno=" + txtphoneno + "&txtext=" + txtext + "&txtfaxno=" + txtfaxno + "&mail=" + mail + "&desi=" + desi + "&txtdob=" + txtdob, false);
            xml.Send();
            dl = xml.responseText;
        }

        if (dl == "yes") {
            alert('Session Expired.Please Login Again.');
            return false;
        }
        sau = "";

        pcmcontdetails.submitcontact(contactperson, txtdob, desi, txtphoneno, txtext, txtfaxno, mail, centcode, compcode, userid, hiddenccode, dateformat);
        //         alert(xmlObj.childNodes(0).childNodes(1).text);
        window.location = window.location;
        return false;
    }

}


//REsponce//
function insert_call(response) {

    var ds = response.value;
    if (ds == "fail") {
        alert("This person has been already assigned");
        return false;

    }

    else {

        var contactperson1 = trim(document.getElementById('txtcontactperson').value);
        var txtdob1 = document.getElementById('txtdob').value;
        var txtphoneno1 = trim(document.getElementById('txtphoneno').value);
        var txtext1 = trim(document.getElementById('txtext').value);
        var txtfaxno1 = trim(document.getElementById('txtfaxno').value);
        var mail1 = document.getElementById('txtemailid').value;
        var centcode1 = document.getElementById('hiddencentcode').value;
        var compcode1 = document.getElementById('hiddencompcode').value;
        var userid1 = document.getElementById('hiddenuserid').value;
        var desi = document.getElementById('txtdesignation').value;

        var dt = document.getElementById('txtdob').value;
        if (dt != "") {
            var dts = new Date(dt);
            var dn = new Date();
        }

        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbcontperson').textContent;
        }
        else {
            bc = document.getElementById('lbcontperson').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (trim(document.getElementById('txtcontactperson').value) == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtcontactperson').focus();
                return false;
            }
        }

        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbphoneno').textContent;
        }
        else {
            bc = document.getElementById('lbphoneno').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (trim(document.getElementById('txtphoneno').value) == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtphoneno').focus();
                return false;
            }
        }

        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbdob').textContent;
        }
        else {
            bc = document.getElementById('lbdob').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (trim(document.getElementById('txtdob').value) == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtdob').focus();
                return false;
            }
        }

        //				if(dn<dts)
        //				{
        //				   alert("Date of birth should not be greater than or equal to today's date.");
        //				document.getElementById('txtdob').value="";
        //				document.getElementById('txtdob').focus();
        //				return false;
        //				}


        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbdesignation').textContent;
        }
        else {
            bc = document.getElementById('lbdesignation').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (trim(document.getElementById('txtdesignation').value) == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtdesignation').focus();
                return false;
            }
        }


        var dateformat = document.getElementById('hiddendateformat').value;
        var txtdob1 = "";
        if (document.getElementById('txtdob').value != "") {
            if (dateformat == "dd/mm/yyyy") {
                var txt = document.getElementById('txtdob').value;
                var txt1 = txt.split("/");
                var dd = txt1[0];
                var mm = txt1[1];
                var yy = txt1[2];
                txtdob1 = mm + '/' + dd + '/' + yy;
            }
            else if (dateformat == "mm/dd/yyyy") {
                txtdob1 = document.getElementById('txtdob').value;
            }

            else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txtdob').value;
                var txt1 = txt.split("/");
                var yy = txt1[0];
                var mm = txt1[1];
                var dd = txt1[2];
                txtdob1 = mm + '/' + dd + '/' + yy;
            }
            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                alert("dateformat  is either null or undefined");
                txtdob1 = document.getElementById('txtdob').value;
            }
        }
        pcmcontdetails.insertcontact(contactperson1, txtdob1, desi, txtphoneno1, txtext1, txtfaxno1, mail1, centcode1, compcode1, userid1, dateformat);


        //alert("Data Saved");
        //alert(xmlObj.childNodes(0).childNodes(0).text);

        window.location = window.location;


        return;

    }

}
//*************************************
//select contact//
function selectcont(ab) {
    var id = ab;

    //saurabh code------------------------------------------------------------------------

    if (document.getElementById(id).checked == false) {
        flag1 = "0";
        document.getElementById('txtphoneno').value = "";
        document.getElementById('txtext').value = "";
        document.getElementById('txtfaxno').value = "";
        //  document.getElementById('txtfaxno').value="";
        document.getElementById('txtemailid').value = "";
        document.getElementById('txtdesignation').value = "";
        document.getElementById('txtdob').value = "";
        document.getElementById('txtcontactperson').value = "";
        //   document.getElementById('txtdate').value="";
        if (opener.document.getElementById('hiddensubmod').value == 0) {
            document.getElementById('btnsubmit').disabled = true;
        }
        else {
            document.getElementById('btnsubmit').disabled = false;
        }
        document.getElementById('btndelete').disabled = true;
        document.getElementById(ab).checked = false;
        return; // false;

    }





    //--------------------------------------------------------------------------------------

    var centcode = document.getElementById('hiddencentcode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var datagrid = document.getElementById('DataGrid1')
    var dateformat = document.getElementById('hiddendateformat').value;

    var j;
    var k = 0;

    //var DataGrid1__ctl_CheckBox1= new Array();
    var i = document.getElementById("DataGrid1").rows.length - 1;

    for (j = 0; j < i; j++) {
        //var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
        var str = "DataGrid1__ctl_CheckBox1" + j;
        document.getElementById(str).checked = false;
        document.getElementById(id).checked = true;

        //saurabh change

        if (document.getElementById('hiddendelsau').value == "1") {
            document.getElementById('btndelete').disabled = false;
        }



        //	alert(document.getElementById(str));
        if (id == str) {
            if (document.getElementById(id).checked == true) {
                k = k + 1;
                //alert(document.getElementById(str).value);
                code10 = document.getElementById(str).value;
                chkpcm = document.getElementById(id);

                //saurabh change

                if (document.getElementById('hiddendelsau').value == "1") {
                    document.getElementById('btndelete').disabled = false;
                }

            }
        }
    }
    if (k == 1) {
        if ((document.getElementById('hiddenshow').value == "1")) {
            document.getElementById('btndelete').disabled = false;
        }
        pcmcontdetails.pcmcontsel(centcode, compcode, userid, code10, call_selectpcm);

    }
    else if (k == 0) {
        chk123.checked = false;
        document.getElementById('txtphoneno').value = "";
        document.getElementById('txtext').value = "";
        document.getElementById('txtfaxno').value = "";
        //                    document.getElementById('txtfaxno').value="";
        document.getElementById('txtemailid').value = "";
        document.getElementById('txtdesignation').value = "";
        document.getElementById('txtdob').value = "";
        document.getElementById('txtcontactperson').value = "";

        return false;
    }
    document.getElementById(ab).checked = true;

    if (document.getElementById('hiddenshow').value == "2") {
        if (document.getElementById('btnsubmit').disabled == false) {
            flag1 = "1";
        }
        else {
            flag1 = "0";
        }
    }
    else {
        flag1 = "0";
    }

    //return false;



}

//Responce of select contact//
function call_selectpcm(response) {

    var ds = response.value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    document.getElementById('hiddenccode').value = ds.Tables[0].Rows[0].cont_code;

    var dateformat = document.getElementById('hiddendateformat').value;

    if (ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "") {
        var enrolldate = ds.Tables[0].Rows[0].dob;
        var dd = enrolldate.getDate();
        var mm = enrolldate.getMonth() + 1;
        var yyyy = enrolldate.getFullYear();
        //var enrolldate1=mm+'/'+dd+'/'+yyyy;

        if (dateformat == "yyyy/mm/dd") {
            var enrolldate1 = yyyy + '/' + mm + '/' + dd;
        }
        else if (dateformat == "mm/dd/yyyy") {
            var enrolldate1 = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "dd/mm/yyyy") {
            var enrolldate1 = dd + '/' + mm + '/' + yyyy;
        }
        else {
            var enrolldate1 = mm + '/' + dd + '/' + yyyy;
        }
    }
    else {
        document.getElementById('txtdob').value = "";
    }

    document.getElementById('txtcontactperson').value = ds.Tables[0].Rows[0].cont_person;
    chkmodname = ds.Tables[0].Rows[0].cont_person;

    if (ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "") {
        document.getElementById('txtdob').value = enrolldate1;
    }
    else {
        document.getElementById('txtdob').value = "";
    }
    document.getElementById('txtphoneno').value = ds.Tables[0].Rows[0].phone;
    if (ds.Tables[0].Rows[0].extention != null) {
        document.getElementById('txtext').value = ds.Tables[0].Rows[0].extention;
    }
    else {
        document.getElementById('txtext').value = "";
    }
    if (ds.Tables[0].Rows[0].fax != null) {
        document.getElementById('txtfaxno').value = ds.Tables[0].Rows[0].fax;
    }
    else {
        document.getElementById('txtfaxno').value = "";
    }
    if (ds.Tables[0].Rows[0].emailid != null) {
        document.getElementById('txtemailid').value = ds.Tables[0].Rows[0].emailid;
    }
    else {
        document.getElementById('txtemailid').value = "";
    }
    document.getElementById('txtdesignation').value = ds.Tables[0].Rows[0].Designation;

    document.getElementById('hiddenccode').value = ds.Tables[0].Rows[0].cont_code;
    if (document.getElementById('hiddenshow').value == "1") {
        document.getElementById('btndelete').disabled = false;
        document.getElementById('btnsubmit').disabled = false;
    }
    else if (document.getElementById('hiddenshow').value == "2") {
        document.getElementById('btndelete').disabled = false;
        document.getElementById('btnsubmit').disabled = false;
    }


    return false;

}
//Function Of clear//
function pcmcontclear() {
    flag1 = "0";
    document.getElementById('txtcontactperson').value = "";
    document.getElementById('txtphoneno').value = "";
    document.getElementById('txtext').value = "";
    document.getElementById('txtfaxno').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtdob').value = "";
    document.getElementById('txtdesignation').value = "";
    document.getElementById('txtemcode').value = "";


    if (((document.getElementById('btndelete').disabled == true) && (document.getElementById('btnsubmit').disabled == true)) || ((document.getElementById('btndelete').disabled == false) && (document.getElementById('btnsubmit').disabled == false))) {

        var j;
        var k = 0;

        //var DataGrid1__ctl_CheckBox1= new Array();
        var i = document.getElementById("DataGrid1").rows.length - 1;

        for (j = 0; j < i; j++) {
            //var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
            var str = "DataGrid1__ctl_CheckBox1" + j;
            document.getElementById(str).checked = false;
            document.getElementById('btndelete').disabled = true;
            if (opener.document.getElementById('hiddensubmod').value == 0) {
                document.getElementById('btnsubmit').disabled = true;
            }
            else {
                document.getElementById('btnsubmit').disabled = false;
            }
        }
    }
    ////document.getElementById('txtcontactperson').disabled= false;
    //if(document.getElementById('txtcontactperson').disabled==false)
    //{
    //    document.getElementById('txtcontactperson').disabled= false;
    //}
    ////document.getElementById('txtphoneno').disabled= false;
    //if(document.getElementById('drpissday').disabled==false)
    //{
    //    document.getElementById('drpissday').disabled= false;
    //}
    ////document.getElementById('txtext').disabled= false;
    //if(document.getElementById('drpissday').disabled==false)
    //{
    //    document.getElementById('drpissday').disabled= false;
    //}
    ////document.getElementById('txtfaxno').disabled= false;
    //if(document.getElementById('drpissday').disabled==false)
    //{
    //    document.getElementById('drpissday').disabled= false;
    //}
    ////document.getElementById('txtemailid').disabled= false;
    //if(document.getElementById('drpissday').disabled==false)
    //{
    //    document.getElementById('drpissday').disabled= false;
    //}
    ////document.getElementById('txtdob').disabled= false;
    //if(document.getElementById('drpissday').disabled==false)
    //{
    //    document.getElementById('drpissday').disabled= false;
    //}
    ////document.getElementById('txtdesignation').disabled= false;
    //if(document.getElementById('drpissday').disabled==false)
    //{
    //    document.getElementById('drpissday').disabled= false;
    //}

    //saurabh change



    //document.getElementById('btnNew').disabled= false;
    //document.getElementById('btnNew').focus();
    //chkpcm.checked=false;
    //chkclick.checked=false;
    return false;
}
//*****************************************************************************************************
//Code for delete from contant details popup
//For delete//
//****************************************************************************************************
function contdelete() {
    document.getElementById('btndelete').disabled = true;

    //var custcode=document.getElementById('txtcontactperson').value;
    var centcode = document.getElementById('hiddencentcode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var update = document.getElementById('hiddenccode').value;
    //var datagrid=document.getElementById('DataGrid1')
    //var update=document.getElementById('hiddenccode').value;
    var userid = document.getElementById('hiddenuserid').value;


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
    pcmcontdetails.deletecontpcm(centcode, compcode, userid, update);


    document.getElementById('txtcontactperson').value = "";
    document.getElementById('txtdob').value = "";
    document.getElementById('txtphoneno').value = "";
    document.getElementById('txtext').value = "";
    document.getElementById('txtfaxno').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('hiddenccode').value = "";

    //alert("Data Deleted");
    //alert(xmlObj.childNodes(0).childNodes(2).text);

    window.location = window.location;

    return false;

}
//************************************End Of Code of Contact Details*******************************

//*******************************************************************************//
//**************************This Function For Exit Button************************//
//*******************************************************************************//
function pcmexit() {

    if (confirm("Do you want to skip this page")) {
        if (typeof (popUpWin) != "undefined") {
            popUpWin.close();
        }

        if (typeof (popUpWin1) != "undefined") {
            popUpWin1.close();
        }


        //window.location.href='EnterPage.aspx'

        window.close();

        return false;

    }
    return false

}




//	function getstatus(response)
//	{
//	      var compcode=document.getElementById('hiddencompcode').value;
//        var centercode=document.getElementById('txtcentercode').value;
//        var userid=document.getElementById('hiddenuserid').value;
//        
//        PubCatMast.getstatus1(compcode,centercode,userid,get_statusdate);
//        
//	}
//	

//	function get_statusdate(response)
//	{
//	 var ds=response.value;
//	 
//	
//	}

//*******************************************************************************//
//**********************This Function For Select Publication Day*****************//
//*******************************************************************************//
//function selectpubday(response)
//{
//var compcode=document.getElementById('hiddencompcode').value;
//var centercode=document.getElementById('txtcentercode').value;
//var userid=document.getElementById('hiddenuserid').value;

//PubCatMast.checkpubcode1(compcode,centercode,userid,pubcodever);

//return false;
//}

//function pubcodever(response)
//{
//var ds=response.value;
//var chk1;
//var chk2;
//var chk3;
//var chk4;
//var chk5;
//var chk6;
//var chk7;
//var chk8;
//var compcode=document.getElementById('hiddencompcode').value;
//var centercode=document.getElementById('txtcentercode').value;
//var userid=document.getElementById('hiddenuserid').value;
//if(document.getElementById('CheckBox1').checked==true)
//{
//chk1="Y";
//}
//else
//{
//chk1="N";
//}
//if(document.getElementById('CheckBox2').checked==true)
//{
//chk2="Y";
//}
//else
//{
//chk2="N";
//}
//if(document.getElementById('CheckBox3').checked==true)
//{
//chk3="Y";
//}
//else
//{
//chk3="N";
//}
//if(document.getElementById('CheckBox4').checked==true)
//{
//chk4="Y";
//}
//else
//{
//chk4="N";
//}
//if(document.getElementById('CheckBox5').checked==true)
//{
//chk5="Y";
//}
//else
//{
//chk5="N";
//}
//if(document.getElementById('CheckBox6').checked==true)
//{
//chk6="Y";
//}
//else
//{
//chk6="N";
//}
//if(document.getElementById('CheckBox7').checked==true)
//{
//chk7="Y";
//}
//else
//{
//chk7="N";
//}
//if(document.getElementById('CheckBox8').checked==true)
//{
//chk8="Y";
//chk1="Y";
//chk2="Y";
//chk3="Y"
//chk4="Y"
//chk5="Y"
//chk6="Y"
//chk7="Y"
//chk8="Y"
//}
//else
//{
//chk8="N";
//}

//if(ds.Tables[0].Rows.length>0)
//{
//PubCatMast.selectpubdaymodify1(compcode,centercode,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,userid);
//return false;
//}
//else
//{
//PubCatMast.selectpubdaysave1(compcode,centercode,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,userid);
//return false;
//}
//}

//*******************************************************************************//
//***********************This Function For Fill The Check Boxes******************//
//*******************************************************************************//

//function fillCheckBoxes(response)
//{
//var compcode=document.getElementById('hiddencompcode').value;
//var centercode=document.getElementById('txtcentercode').value;
//var userid=document.getElementById('hiddenuserid').value;
//PubCatMast.checkpubcode1(compcode,centercode,userid,fillcheck);
//return false;
//}

//function fillcheck(response)
//{
//var ds=response.value;
//if(ds.Tables[0].Rows.length>0)
//{
//var sun=ds.Tables[0].Rows[0].sun;
//var mon=ds.Tables[0].Rows[0].mon;
//var tue=ds.Tables[0].Rows[0].tue;
//var wed=ds.Tables[0].Rows[0].wed;
//var thu=ds.Tables[0].Rows[0].thu;
//var fri=ds.Tables[0].Rows[0].fri;
//var sat=ds.Tables[0].Rows[0].sat;
//var all=ds.Tables[0].Rows[0].all;

//if(sun=="Y")
//{
//document.getElementById('CheckBox1').checked=true;
//}
//else
//{
//document.getElementById('CheckBox1').checked=false;
//}

//if(mon=="Y")
//{
//document.getElementById('CheckBox2').checked=true;
//}
//else
//{
//document.getElementById('CheckBox2').checked=false;
//}
//if(tue=="Y")
//{
//document.getElementById('CheckBox3').checked=true;
//}
//else
//{
//document.getElementById('CheckBox3').checked=false;
//}
//if(wed=="Y")
//{
//document.getElementById('CheckBox4').checked=true;
//}
//else
//{
//document.getElementById('CheckBox4').checked=false;
//}
//if(thu=="Y")
//{
//document.getElementById('CheckBox5').checked=true;
//}
//else
//{
//document.getElementById('CheckBox5').checked=false;
//}
//if(fri=="Y")
//{
//document.getElementById('CheckBox6').checked=true;
//}
//else
//{
//document.getElementById('CheckBox6').checked=false;
//}
//if(sat=="Y")
//{
//document.getElementById('CheckBox7').checked=true;
//}
//else
//{
//document.getElementById('CheckBox7').checked=false;
//}
//if(all=="Y")
//{
//document.getElementById('CheckBox1').checked=true;
//document.getElementById('CheckBox2').checked=true;
//document.getElementById('CheckBox3').checked=true;
//document.getElementById('CheckBox4').checked=true;
//document.getElementById('CheckBox5').checked=true;
//document.getElementById('CheckBox6').checked=true;
//document.getElementById('CheckBox7').checked=true;
//document.getElementById('CheckBox8').checked=false;
//}
//else
//{
//document.getElementById('CheckBox8').checked=false;
//}
//}
//}

////******************************************************************************//
////**********************This Function For Check The Fill Check Box**************//
////*******************************For Check Or Un Check**************************//
////******************************************************************************//
//function checkedunchecked(q)
//{
//	var status = document.getElementById(q).checked;
//	if(status==true)
//	{
//		document.getElementById('CheckBox1').checked=true;
//		document.getElementById('CheckBox2').checked=true;
//		document.getElementById('CheckBox3').checked=true;
//		document.getElementById('CheckBox4').checked=true;
//		document.getElementById('CheckBox5').checked=true;
//		document.getElementById('CheckBox6').checked=true;
//		document.getElementById('CheckBox7').checked=true;
//		document.getElementById('CheckBox8').checked=true;
//	}
//	else
//	{
//		document.getElementById('CheckBox1').checked=false;
//		document.getElementById('CheckBox2').checked=false;
//		document.getElementById('CheckBox3').checked=false;
//		document.getElementById('CheckBox4').checked=false;
//		document.getElementById('CheckBox5').checked=false;
//		document.getElementById('CheckBox6').checked=false;
//		document.getElementById('CheckBox7').checked=false;
////		document.getElementById(q).checked=false;
//	}
//	}

//*******************************************************************************//
//**********************This Function For Disable Check Boxes********************//
//*******************************************************************************//
//function disablecheck()
//{
//		document.getElementById('CheckBox1').disabled=true;
//		document.getElementById('CheckBox2').disabled=true;
//		document.getElementById('CheckBox3').disabled=true;
//		document.getElementById('CheckBox4').disabled=true;
//		document.getElementById('CheckBox5').disabled=true;
//		document.getElementById('CheckBox6').disabled=true;
//		document.getElementById('CheckBox7').disabled=true;
//		document.getElementById('CheckBox8').disabled=true;
//		//getPermission('PubCatMast');
//		return false;
//}




//function fillalias()
//{
//document.getElementById('txtalias').value=document.getElementById('txtcentername').value.toUpperCase();
//}


// ******************************Code For Auto Generation********************

function autoornot() {
    document.getElementById('txtcentername').value = document.getElementById('txtcentername').value.toUpperCase();
    if (hiddentext == "new") {
        if (document.getElementById('hiddenauto').value == 1) {
            changeoccured();
            return false;
        }
        else {
            userdefine();

            return false;
        }
        return false;
    }
}
// Auto generated
// This Function is for check that whether this is case for new or modify
function changeoccured() {
    if (hiddentext == "new") {

        uppercase3();

    }
    else {
        document.getElementById('txtcentername').value = document.getElementById('txtcentername').value.toUpperCase();
        document.getElementById('txtalias').focus();
        //document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
        return false;
    }
    //return false;
    //return false;
}


//auto generated
//this is used for increment in code
function UpperCase(field) {
    document.getElementById(field).value = trim(document.getElementById(field).value.toUpperCase());
    return false;
}
function uppercase3() {

    document.getElementById('txtcentername').value = trim(document.getElementById('txtcentername').value);
    document.getElementById('txtalias').value = trim(document.getElementById('txtalias').value);

    lstr = document.getElementById('txtcentername').value;
    cstr = lstr.substring(0, 1);
    var mstr = "";
    if (lstr.indexOf(" ") == 1) {
        var leng = lstr.length;
        mstr = cstr + lstr.substring(2, leng);
    }
    else {
        var leng = lstr.length;
        mstr = cstr + lstr.substring(1, leng);
    }

    if (document.getElementById('txtcentername').value != "") {


        document.getElementById('txtcentername').value = document.getElementById('txtcentername').value.toUpperCase();
        //	     if(hiddentext=="new")
        //		{
        document.getElementById('txtalias').value = document.getElementById('txtcentername').value;
        document.getElementById('txtalias').focus();
        //}
        str = mstr;
        //		  str=document.getElementById('txtcentername').value;
        //	      cod=document.getElementById('txtcentercode').value;
        //city=document.getElementById('drpcity').value;
        // saurabh change		  PubCatMast.chkpubcatmast1(/*cod,*/str,fillcall);

        PubCatMast.chkpubcatmast1(/*cod,*/str, fillcall);

        //PubCatMast.chkpubcatmast(str,fillcall);
        return false;
    }


    return false;

}

function fillcall(res) {


    var ds = res.value;

    //var ds1= res.value;

    var newstr;

    if (ds.Tables[0].Rows.length != 0)//&& ds1.Tables[1].Rows.length!=0)
    {
        //if(saurabh_agarwal==1)
        // {
        alert("This center name has already been assigned !! ");
        document.getElementById('txtcentername').value = "";
        document.getElementById('txtalias').value = "";
        document.getElementById('txtcentername').focus();

        //document.getElementById('drpcity').focus();
        return false;
    }
    //}
    else {
        //if(hiddentext=="new")
        // {

        //var s=parseFloat(document.getElementById('txtcentername').value);

        if (ds.Tables[1].Rows.length == 0) {
            newstr = null;
        }
        else {
            newstr = ds.Tables[1].Rows[0].Pub_cent_Code;
        }
        if (newstr != null) {
            //   var code=newstr.substr(2,4);
            var code = newstr;
            code++;
            document.getElementById('txtcentercode').value = str.substr(0, 2) + code;
        }
        else {
            document.getElementById('txtcentercode').value = str.substr(0, 2) + "0";
        }
        //document.getElementById('txtalias').focus();

        // if(s==0)
        //                    {
        //                    alert("Center name should not be zero.");
        //                    document.getElementById('txtcentercode').value="";
        //                    document.getElementById('txtcentername').value="";
        //                    document.getElementById('txtalias').value="";
        //                    document.getElementById('txtcentername').focus();
        //                    }
        //}
    }
    return false;
}

function userdefine() {
    if (hiddentext == "new") {

        document.getElementById('txtcentercode').disabled = false;
        document.getElementById('txtcentername').value = document.getElementById('txtcentername').value.toUpperCase();
        document.getElementById('txtalias').value = document.getElementById('txtcentername').value;
        auto = document.getElementById('hiddenauto').value;
        PubCatMast.chkpubcatmast1(document.getElementById('txtcentername').value, fillcall1);
        document.getElementById('txtalias').focus();
        return false;
    }

    return false;
}

function fillcall1(res) {
    var ds = res.value;
    var newstr;
    if (ds.Tables[0].Rows.length != 0)//&& ds1.Tables[1].Rows.length!=0)
    {
        alert("This center name has already been assigned !! ");
        document.getElementById('txtcentername').value = "";
        document.getElementById('txtalias').value = "";
        document.getElementById('txtcentername').focus();
        return false;
    }
    return false;
}
//*******************************************************************************//


function checkcode() {
    document.getElementById('txtcentercode').value
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
    res2 = PubCatMast.chkpubcatcode(document.getElementById('txtcentercode').value);

}
function fillcall12(res) {
    var ds = res.value;
    var newstr;
    if (ds == null) {
        return false;
    }
    if (ds.Tables[0].Rows.length != 0)//&& ds1.Tables[1].Rows.length!=0)
    {
        alert("This center code has already been assigned !! ");
        document.getElementById('txtcentercode').value = "";
        //document.getElementById('txtalias').value="";
        if (document.getElementById('txtcentercode').disabled == false)
            document.getElementById('txtcentercode').focus();
        return false;
    }
    return false;
}
//********************This Function For Call The Event Of Caps lock*************//
//******************************************************************************//	

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
    if (event.keyCode == 113)
        event.keyCode = 81;
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

//function fillchk_chkbox()
//{
//	 if((document.getElementById('CheckBox1').disabled==false)&&(document.getElementById('CheckBox1').checked==false))
//    {
//    document.getElementById('CheckBox8').checked=false;
//    }
//  
//    if((document.getElementById('CheckBox2').disabled==false)&&(document.getElementById('CheckBox2').checked==false))
//    {
//    document.getElementById('CheckBox8').checked=false;
//    }
//    if((document.getElementById('CheckBox3').disabled==false)&&(document.getElementById('CheckBox3').checked==false))
//    {
//    document.getElementById('CheckBox8').checked=false;
//    }
//    if((document.getElementById('CheckBox4').disabled==false)&&(document.getElementById('CheckBox4').checked==false))
//    {
//   document.getElementById('CheckBox8').checked=false;
//    }
//    if((document.getElementById('CheckBox5').disabled==false)&&(document.getElementById('CheckBox5').checked==false))
//    {
//    document.getElementById('CheckBox8').checked=false;
//    }
//     if((document.getElementById('CheckBox6').disabled==false)&&(document.getElementById('CheckBox6').checked==false))
//    {
//   document.getElementById('CheckBox8').checked=false;
//    }
//     if((document.getElementById('CheckBox7').disabled==false)&&(document.getElementById('CheckBox7').checked==false))
//    {
//    document.getElementById('CheckBox8').checked=false;
//    }
// 
// return ;
// }
//}


function Checkdate(input) {
    var dateformat = document.getElementById('hiddendateformat').value;

    if (dateformat == "mm/dd/yyyy") {
        var validformat = /^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity

    }
    if (dateformat == "yyyy/mm/dd") {
        var validformat = /^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
    }
    if (dateformat == "dd/mm/yyyy") {
        var validformat = /^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
    }

    if (!validformat.test()) {
        if (input.value == "") {
            return true;
        }
        alert(" Please fill the date in " + dateformat + " format");
        document.getElementById('txtdob').value = "";
        return false;
    }
}


function saurabh_ClientSpecialchar() {
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 45) || (event.keyCode == 46)) {
        return true;
    }
    else {
        return false;
    }
}
function saurabh_ClientSpecialchar1() {
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 45) || (event.keyCode == 46) || (event.keyCode == 44) || (event.keyCode == 47)) {
        return true;
    }
    else {
        return false;
    }
}





//function ClientEmailCheck1(q) {
//    var theurl = document.getElementById('txtemailid').value;

//    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == ""||document.getElementById(q).value.indexOf(",") > 0) {
//        return (true)
//    }
//    alert("Invalid E-mail Address! Please re-enter.")
//    document.getElementById('txtemailid').value = "";
//    document.getElementById('txtemailid').focus();
//    return false;
//}







function ClientEmailCheck1(q) {
    var theurl = document.Form1.txtemailid.value;

    var splt = theurl.split(',');
    if (splt.length > 1) {
        for (var i = 0; i < splt.length; i++) {
            var eml2 = splt[i];
            if (eml2 != "") {
                if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(splt[i]) || document.getElementById(q).value == "") {

                }
                else {
                    alert("Invalid E-mail Address! Please re-enter.")
                    //document.getElementById(q).value="";
                    document.getElementById(q).focus();
                    return (false)
                }
            }
            else {
                //        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(splt[i]) || document.getElementById(q).value=="")
                //	{
                //		return (true)
                //	}
                //	alert("Invalid E-mail Address! Please re-enter.")
                //	//document.getElementById(q).value="";
                //	document.getElementById(q).focus();
                return (true)
            }
        }
    }
    else
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == "") {
        return (true)
    }
    //	var splt= theurl.split(',');
    else {
        alert("Invalid E-mail Address! Please re-enter.")
        //document.getElementById(q).value="";
        document.getElementById(q).focus();
        return (false)
    }
}

function isEmail(email) {
    if (document.Form1.txtemailid.value.indexOf("@") != "-1" && document.Form1.txtemailid.value.indexOf(".") != "-1")
        return true;
    else
        return false;
}

function checkEmail() {


    if (isEmail(document.Form1.txtemailid.value) == false && document.Form1.txtemailid.value != "") {
        alert("Enter your correct Email ID");
        document.Form1.txtemailid.value = "";
        document.Form1.txtemailid.focus();
        return false;
    }
}

function chkdateformat(dt) {
    var dateformat = document.getElementById('hiddendateformat').value;
    var retdate = "";
    if (dateformat == "dd/mm/yyyy") {
        var txt = dt;
        var txt1 = txt.split("/");
        var dd = txt1[0];
        var mm = txt1[1];
        var yy = txt1[2];
        retdate = mm + '/' + dd + '/' + yy;
    }

    if (dateformat == "mm/dd/yyyy") {
        retdate = dt;
    }

    if (dateformat == "yyyy/mm/dd") {
        var txt = dt;
        var txt1 = txt.split("/");
        var yy = txt1[0];
        var mm = txt1[1];
        var dd = txt1[2];
        retdate = mm + '/' + dd + '/' + yy;
    }
    return retdate;
}

function usercodechk() {
    var compcode = document.getElementById('hiddencompcode').value;
    var code = document.getElementById('txtcentercode').value;
    if (hiddentext == "new") {
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
        PubCatMast.chkusercode(compcode, code, usercodechk_call);
    }
}

function usercodechk_call(res) {

    var ds = res.value;
    if (ds.Tables[0].Rows.length > 0) {
        alert("This Publication Centre Code has been already assign");
        document.getElementById('txtcentercode').value = "";
        document.getElementById('txtcentercode').focus();
        return false;
    }

}

function checkSpace(event) {
    if (event.keyCode == 32) {
        return false;
    }
}



//	if(document.getElementById('hiddencentcode').value == "" )//&& document.getElementById('hiddencentcode').value != null)
//if(opener.document.getElementById('hiddenchk').value="0")
//{
//}
//if(modify!="1")
//			{
//				var contactperson=document.getElementById('txtcontactperson').value;
//				//var txtdob=document.getElementById('txtdob').value;
//				var txtphoneno=document.getElementById('txtphoneno').value;
//				var txtext=document.getElementById('txtext').value; 
//				var txtfaxno=document.getElementById('txtfaxno').value;
//				var mail=document.getElementById('txtemailid').value;
//				var centcode=document.getElementById('hiddencentcode').value; 
//				var compcode=document.getElementById('hiddencompcode').value; 
//				var userid=document.getElementById('hiddenuserid').value; 
//				var hiddenccode=document.getElementById('hiddenccode').value; 
//				var desi= document.getElementById('txtdesignation').value;
//				var dateformat=document.getElementById('hiddenDateFormat').value;
//				var txtdob;
//				if(dateformat=="dd/mm/yyyy")
//							{
//								var txt=document.getElementById('txtdob').value;
//								var txt1=txt.split("/");
//								var dd=txt1[0];
//								var mm=txt1[1];
//								var yy=txt1[2];
//								txtdob=mm+'/'+dd+'/'+yy;
//							}
//							else if(dateformat=="mm/dd/yyyy")
//							{
//								txtdob=document.getElementById('txtdob').value;
//							}
//								
//							else if(dateformat=="yyyy/mm/dd")
//							{
//								var txt=document.getElementById('txtdob').value;
//								var txt1=txt.split("/");
//								var yy=txt1[0];
//								var mm=txt1[1];
//								var dd=txt1[2];
//								txtdob=mm+'/'+dd+'/'+yy;
//							}
//							if(dateformat==null || dateformat=="" || dateformat=="undefined")
//							{
//								alert("dateformat  is either null or undefined");
//								txtdob=document.getElementById('txtdob').value;
//							}

//		if  (opener.document.getElementById('hiddenchk').value=="1")
//        {
//            //pcmcontdetails.insertcontact(contactperson1,txtdob1,txtphoneno1,desi,txtext1,txtfaxno1,mail1,centcode1,compcode1,userid1);
//		pcmcontdetails.submitcontact(contactperson,txtdob,desi,txtphoneno,txtext,txtfaxno,mail,centcode,compcode,userid,hiddenccode);
//			}
//			else
//			{
//			return;
//			
//			}

////////				document.getElementById('txtcontactperson').value="";
////////				document.getElementById('txtdob').value="";
////////				document.getElementById('txtphoneno').value="";
////////				document.getElementById('txtext').value=""; 
////////				document.getElementById('txtfaxno').value="";
////////				document.getElementById('txtemailid').value="";
////////				document.getElementById('hiddenccode').value=""; 
////////				
////////				//alert("Data Modified");
////////				alert(xmlObj.childNodes(0).childNodes(1).text);

////////				window.location=window.location;
////////					
////////				return ;
////////			}

////////	else
////////		{

//			var contactperson1=document.getElementById('txtcontactperson').value;
//			var txtdob1=document.getElementById('txtdob').value;
//			var txtphoneno1=document.getElementById('txtphoneno').value;
//			var txtext1=document.getElementById('txtext').value; 
//			var txtfaxno1=document.getElementById('txtfaxno').value;
//			var mail1=document.getElementById('txtemailid').value;
//			var centcode1=document.getElementById('hiddencentcode').value; 
//			var compcode1=document.getElementById('hiddencompcode').value; 
//			var userid1=document.getElementById('hiddenuserid').value; 
//			var desi= document.getElementById('txtdesignation').value;

//////////////////////var contactperson="";
//////////////////////var compcode="";
//////////////////////var centcode="";

//////////////////////var xml = new ActiveXObject("Microsoft.XMLHTTP");
//////////////////////xml.Open( "GET","chkpcmcontact.aspx?contactperson="+contactperson+"&centcode="+centcode, false );
//////////////////////xml.Send();
//////////////////////var dl=xml.responseText;



//////////////////////if(dl=="Y")
//////////////////////{

//////////////////////alert("This Contact Person ");
//////////////////////return false;
//alert(clientcontactdetails);

//			pcmcontdetails.insertcontact(contactperson1,txtdob1,txtphoneno1,desi,txtext1,txtfaxno1,mail1,centcode1,compcode1,userid1);

//			document.getElementById('txtcontactperson').value="";
//			document.getElementById('txtdob').value="";
//			document.getElementById('txtphoneno').value="";
//			document.getElementById('txtext').value=""; 
//			document.getElementById('txtfaxno').value="";
//			document.getElementById('txtemailid').value="";

////////////////			//alert("Data Saved");
////////////////			alert(xmlObj.childNodes(0).childNodes(0).text);

////////////////			window.location=window.location;
////////////////			

////////////////			return ;

////////////////		}
////////////////		return;

////////////////}


//*******************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//

/*function pcmsavenew()
{
var compcode=document.getelementbyid('hiddencompcode').value;
//var centercode =document.getelementbyid('txtcentercode').value;
		
var centername=document.getelementbyid('txtcentername').value;
//document.getelementbyid('txtcentname').value=document.getelementbyid('txtcentername').value;
		
var alias=document.getelementbyid('txtalias').value;
//document.getelementbyid('txtcentalias').value=document.getelementbyid('txtalias').value;
		
var add1=document.getelementbyid('txtadd1').value;
//document.getelementbyid('street12').value=document.getelementbyid('txtadd1').value;
		
var street=document.getelementbyid('txtstreet').value;
//document.getelementbyid('street12').value=document.getelementbyid('txtstreet').value;
		
var centercode=document.getelementbyid('txtcentercode').value;
//document.getelementbyid('txtcentcode').value=document.getelementbyid('txtcentercode').value;
		
var dist=document.getelementbyid('txtdistrict').value;
//document.getelementbyid('district').value=document.getelementbyid('txtdistrict').value;
		
var country=document.getelementbyid('txtcountry').value;
//document.getelementbyid('txtcountryname').value=document.getelementbyid('txtcountry').value;
		
var city=document.getelementbyid('drpcity').value;
//document.getelementbyid('cityname').value=document.getelementbyid('drpcity').value;
		
var phone1=document.getelementbyid('txtphone1').value;
//document.getelementbyid('txtph1').value=document.getelementbyid('txtphone1').value;

var phone2=document.getelementbyid('txtphone2').value;
//document.getelementbyid('txtph2').value=document.getelementbyid('txtphone2').value;

//var status=document.getelementbyid('txtstatus1').value;
var pin=document.getelementbyid('txtpincode').value;
//document.getelementbyid('txtpin').value=document.getelementbyid('txtpincode').value;
		
var state=document.getelementbyid('txtstate').value;
//document.getelementbyid('statecode12').value=document.getelementbyid('txtstate').value;
		
var fax=document.getelementbyid('txtfax').value;
//document.getelementbyid('txtph2').value=document.getelementbyid('txtphone2').value;
		
var fax1=document.getelementbyid('txtfax1').value;
// document.getelementbyid('txtph2').value=document.getelementbyid('txtphone2').value;
	    
var email=document.getelementbyid('txtemailid').value;
//document.getelementbyid('email_id').value=document.getelementbyid('txtemailid').value;
		
var dateformat=document.getelementbyid('hiddendateformat').value;
//var statusdate=document.getelementbyid('txtstatusdate').value;
var remarks=document.getelementbyid('txtstatusreason').value;
//document.getelementbyid('txtremarks').value=document.getelementbyid('txtstatusreason').value;
		
var userid=document.getelementbyid('hiddenuserid').value;
		
var region=document.getelementbyid('drpregion').value;
//document.getelementbyid('txtregon').value=document.getelementbyid('drpregion').value;
var zone=document.getelementbyid('drpzone').value;
//document.getelementbyid('txtzone').value=document.getelementbyid('drpzone').value;
		

		
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getelementbyid('txtstatusdate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var statusdate=mm+'/'+dd+'/'+yy;
}
					
if(dateformat=="mm/dd/yyyy")
{
var statusdate=document.getelementbyid('txtstatusdate').value;
}
					
if(dateformat=="yyyy/mm/dd")
{
var txt=document.getelementbyid('txtstatusdate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var statusdate=mm+'/'+dd+'/'+yy;
}
					
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var statusdate=document.getelementbyid('txtstatusdate').value;
}
					
// var akh=document.getelementbyid('txtcentercode').value
// selectpubday(akh);
//  fillcheckboxes(akh);*/

//pubcatmast.savepcm(compcode,centercode,centername,alias,add1,street,city,dist,country,phone1,phone2,pin,state,fax,email,remarks,userid,region,zone,statusdate)
//			
//pubcatmast.savepcm(compcode,centercode,centername,alias,add1,street,city,dist,country,phone1,phone2,pin,state,fax,email,remarks,userid,region,zone,fax1)
//			
//			
//					// pubcatmast.citychk(compcode,centername,city,userid,city_check);
//					
//					alert('hashdgj');
//					document.getelementbyid('btnnew').disabled=false;
//					document.getelementbyid('btnquery').disabled=false;
//					document.getelementbyid('btncancel').disabled=false;		
//					document.getelementbyid('btnexit').disabled=false;	
//					document.getelementbyid('btnsave').disabled=true;
//					document.getelementbyid('btnmodify').disabled=true;
//					document.getelementbyid('btndelete').disabled=true;
//					document.getelementbyid('btnexecute').disabled=true;
//					document.getelementbyid('btnfirst').disabled=true;				
//					document.getelementbyid('btnnext').disabled=true;					
//					document.getelementbyid('btnprevious').disabled=true;			
//					document.getelementbyid('btnlast').disabled=true;
//					
//					document.getelementbyid('txtcentercode').disabled=true;
//					document.getelementbyid('txtcentername').disabled=true;
//					document.getelementbyid('txtalias').disabled=true;
//					document.getelementbyid('txtadd1').disabled=true;
//					document.getelementbyid('txtstreet').disabled=true;
//					document.getelementbyid('drpcity').disabled=true;
//					document.getelementbyid('txtdistrict').disabled=true;
//					document.getelementbyid('txtcountry').disabled=true;
//					document.getelementbyid('txtphone1').disabled=true;
//					document.getelementbyid('txtphone2').disabled=true;
//					document.getelementbyid('txtstatus1').disabled=true;
//					document.getelementbyid('txtpincode').disabled=true;
//					document.getelementbyid('txtstate').disabled=true;
//					document.getelementbyid('txtfax').disabled=true;
//					document.getelementbyid('txtfax1').disabled=true;
//					document.getelementbyid('txtemailid').disabled=true;
//					document.getelementbyid('txtstatusdate').disabled=true;
//					document.getelementbyid('txtstatusreason').value=true;
//					
//				//document.getelementbyid('txtstatusreason').disabled=true;
//						
//					document.getelementbyid('drpregion').disabled=true;
//					document.getelementbyid('drpzone').disabled=true;
//					
//					document.getelementbyid('txtcentercode').value="";
//					document.getelementbyid('txtcentername').value="";
//					document.getelementbyid('txtalias').value="";
//					document.getelementbyid('txtadd1').value="";
//					document.getelementbyid('txtstreet').value="";
//					document.getelementbyid('drpcity').value="0";
//					document.getelementbyid('txtdistrict').value="";
//					document.getelementbyid('txtcountry').value="0";
//					document.getelementbyid('txtphone1').value="";
//					document.getelementbyid('txtphone2').value="";
//					document.getelementbyid('txtstatus1').value="";
//					document.getelementbyid('txtpincode').value="";
//					document.getelementbyid('txtstate').value="";
//					document.getelementbyid('txtfax').value="";
//					document.getelementbyid('txtfax1').value="";
//					document.getelementbyid('txtemailid').value="";
//					document.getelementbyid('txtstatusreason').value="";
//					document.getelementbyid('drpregion').value="0";
//					document.getelementbyid('drpzone').value="0";
//        


//function pcmsavenew(response)
//{
//var ds = response.value;

////if(ds.Tables[1].Rows.length>0)
////{
////alert("This Code Has Been Assigned");
////return false;
////}
////if (ds.Tables[0].Rows.length>0)
////{
////alert("This City has been assigned for this City");
////return false;
////}

//if(ds.Tables[0].Rows.length>0)
//{
//alert("This Code Has Been Assigned");
//return false;
//}
//else
//{		
//////////	 var compcode=document.getElementById('hiddencompcode').value;
//////////		//var centercode =document.getElementById('txtcentercode').value;
//////////		
//////////		var centername=document.getElementById('txtcentername').value;
//////////		//document.getElementById('txtcentname').value=document.getElementById('txtcentername').value;
//////////		
//////////		var alias=document.getElementById('txtalias').value;
//////////		//document.getElementById('txtcentalias').value=document.getElementById('txtalias').value;
//////////		
//////////		var add1=document.getElementById('txtadd1').value;
//////////		//document.getElementById('Street12').value=document.getElementById('txtadd1').value;
//////////		
//////////		var street=document.getElementById('txtstreet').value;
//////////		//document.getElementById('Street12').value=document.getElementById('txtstreet').value;
//////////		
//////////		var centercode=document.getElementById('txtcentercode').value;
//////////		//document.getElementById('txtcentcode').value=document.getElementById('txtcentercode').value;
//////////		
//////////		var dist=document.getElementById('txtdistrict').value;
//////////		//document.getElementById('district').value=document.getElementById('txtdistrict').value;
//////////		
//////////		var country=document.getElementById('txtcountry').value;
//////////		//document.getElementById('txtcountryname').value=document.getElementById('txtcountry').value;
//////////		
//////////		var city=document.getElementById('drpcity').value;
//////////		//document.getElementById('cityname').value=document.getElementById('drpcity').value;
//////////		
//////////		var phone1=document.getElementById('txtphone1').value;
//////////		//document.getElementById('txtph1').value=document.getElementById('txtphone1').value;

//////////		var phone2=document.getElementById('txtphone2').value;
//////////		//document.getElementById('txtph2').value=document.getElementById('txtphone2').value;

//////////	  //var status=document.getElementById('txtstatus1').value;
//////////		var pin=document.getElementById('txtpincode').value;
//////////		//document.getElementById('txtpin').value=document.getElementById('txtpincode').value;
//////////		
//////////		var state=document.getElementById('txtstate').value;
//////////		//document.getElementById('Statecode12').value=document.getElementById('txtstate').value;
//////////		
//////////		var fax=document.getElementById('txtfax').value;
//////////		//document.getElementById('txtph2').value=document.getElementById('txtphone2').value;
//////////		
//////////	    var fax1=document.getElementById('txtfax1').value;
//////////	   // document.getElementById('txtph2').value=document.getElementById('txtphone2').value;
//////////	    
//////////		var email=document.getElementById('txtemailid').value;
//////////		//document.getElementById('email_id').value=document.getElementById('txtemailid').value;
//////////		
//////////		var dateformat=document.getElementById('hiddenDateFormat').value;
//////////	  //var statusdate=document.getElementById('txtstatusdate').value;
//////////		var remarks=document.getElementById('txtstatusreason').value;
//////////		//document.getElementById('txtremarks').value=document.getElementById('txtstatusreason').value;
//////////		
//////////		var userid=document.getElementById('hiddenuserid').value;
//////////		
//////////		var region=document.getElementById('drpregion').value;
//////////		//document.getElementById('txtregon').value=document.getElementById('drpregion').value;
//////////		var zone=document.getElementById('drpzone').value;
//////////		//document.getElementById('txtzone').value=document.getElementById('drpzone').value;
//////////		

//////////		
//////////		if(dateformat=="dd/mm/yyyy")
//////////					{
//////////							var txt=document.getElementById('txtstatusdate').value;
//////////							var txt1=txt.split("/");
//////////							var dd=txt1[0];
//////////							var mm=txt1[1];
//////////							var yy=txt1[2];
//////////							var statusdate=mm+'/'+dd+'/'+yy;
//////////					}
//////////					
//////////					if(dateformat=="mm/dd/yyyy")
//////////					{
//////////							var statusdate=document.getElementById('txtstatusdate').value;
//////////					}
//////////					
//////////					if(dateformat=="yyyy/mm/dd")
//////////					{
//////////							var txt=document.getElementById('txtstatusdate').value;
//////////							var txt1=txt.split("/");
//////////							var yy=txt1[0];
//////////							var mm=txt1[1];
//////////							var dd=txt1[2];
//////////							var statusdate=mm+'/'+dd+'/'+yy;
//////////					}
//////////					
//////////					if(dateformat==null || dateformat=="" || dateformat=="undefined")
//////////					{
//////////							var statusdate=document.getElementById('txtstatusdate').value;
//////////					}
////					
////		        // var akh=document.getElementById('txtcentercode').value
////                 // selectpubday(akh);
////                  //  fillCheckBoxes(akh);
////                    
////PubCatMast.savepcm(compcode,centercode,centername,alias,add1,street,city,dist,country,phone1,phone2,pin,state,fax,email,remarks,userid,region,zone,statusdate)
////			
//PubCatMast.savepcm(compcode,centercode,centername,alias,add1,street,city,dist,country,phone1,phone2,pin,state,fax,email,remarks,userid,region,zone,fax1)
////			
////			
////					// PubCatMast.citychk(compcode,centername,city,userid,city_check);
//					
//					alert('hashdgj');
//					document.getElementById('btnNew').disabled=false;
//					document.getElementById('btnQuery').disabled=false;
//					document.getElementById('btnCancel').disabled=false;		
//					document.getElementById('btnExit').disabled=false;	
//					document.getElementById('btnSave').disabled=true;
//					document.getElementById('btnModify').disabled=true;
//					document.getElementById('btnDelete').disabled=true;
//					document.getElementById('btnExecute').disabled=true;
//					document.getElementById('btnfirst').disabled=true;				
//					document.getElementById('btnnext').disabled=true;					
//					document.getElementById('btnprevious').disabled=true;			
//					document.getElementById('btnlast').disabled=true;
//					
//					document.getElementById('txtcentercode').disabled=true;
//					document.getElementById('txtcentername').disabled=true;
//					document.getElementById('txtalias').disabled=true;
//					document.getElementById('txtadd1').disabled=true;
//					document.getElementById('txtstreet').disabled=true;
//					document.getElementById('drpcity').disabled=true;
//					document.getElementById('txtdistrict').disabled=true;
//					document.getElementById('txtcountry').disabled=true;
//					document.getElementById('txtphone1').disabled=true;
//					document.getElementById('txtphone2').disabled=true;
//					document.getElementById('txtstatus1').disabled=true;
//					document.getElementById('txtpincode').disabled=true;
//					document.getElementById('txtstate').disabled=true;
//					document.getElementById('txtfax').disabled=true;
//					document.getElementById('txtfax1').disabled=true;
//					document.getElementById('txtemailid').disabled=true;
//					document.getElementById('txtstatusdate').disabled=true;
//					document.getElementById('txtstatusreason').value=true;
////					
////				//document.getElementById('txtstatusreason').disabled=true;
////						
//					document.getElementById('drpregion').disabled=true;
//					document.getElementById('drpzone').disabled=true;
////					
//					document.getElementById('txtcentercode').value="";
//					document.getElementById('txtcentername').value="";
//					document.getElementById('txtalias').value="";
//					document.getElementById('txtadd1').value="";
//					document.getElementById('txtstreet').value="";
//					document.getElementById('drpcity').value="0";
//					document.getElementById('txtdistrict').value="";
//					document.getElementById('txtcountry').value="0";
//					document.getElementById('txtphone1').value="";
//					document.getElementById('txtphone2').value="";
//					document.getElementById('txtstatus1').value="";
//					document.getElementById('txtpincode').value="";
//					document.getElementById('txtstate').value="";
//					document.getElementById('txtfax').value="";
//					document.getElementById('txtfax1').value="";
//					document.getElementById('txtemailid').value="";
//					document.getElementById('txtstatusreason').value="";
//					document.getElementById('drpregion').value="0";
//					document.getElementById('drpzone').value="0";
//					
//	

//					//return;

//			  /*document.getElementById('CheckBox1').checked=false;
//				document.getElementById('CheckBox2').checked=false;
//				document.getElementById('CheckBox3').checked=false;
//				document.getElementById('CheckBox4').checked=false;
//				document.getElementById('CheckBox5').checked=false;
//				document.getElementById('CheckBox6').checked=false;
//				document.getElementById('CheckBox7').checked=false;
//				document.getElementById('CheckBox8').checked=false;
//				document.getElementById('CheckBox1').disabled=true;
//				document.getElementById('CheckBox2').disabled=true;
//				document.getElementById('CheckBox3').disabled=true;
//				document.getElementById('CheckBox4').disabled=true;
//				document.getElementById('CheckBox5').disabled=true;
//				document.getElementById('CheckBox6').disabled=true;
//				document.getElementById('CheckBox7').disabled=true;
//				document.getElementById('CheckBox8').disabled=true;*/
//					
//					//alert("value save sucessfully");
//					//alert(xmlObj.childNodes(0).childNodes(0).text);
//return false ;


//}
////else
////{
////alert("Please Enter the Status Details ");
////return false;
////}
//return false;
//}


//*********************************
//function city_check(response)
//{
//var global_ds=response.value;
//if(global_ds.Tables[0].Rows[0].length>0)
//{

//}
//}
//*********************************




//************************************************SAURABH CODE**********************************
//**********************************************************************************************
////			if (global_ds.Tables[0].Rows.length>0)
////					{
////					document.getElementById('lbClientContactDetail').disabled=false;
////                    document.getElementById('lbStatusDetail').disabled=false;

////					document.getElementById('txtcentercode').value=global_ds.Tables[0].Rows[0].Pub_cent_Code;
////					document.getElementById('txtcentername').value=global_ds.Tables[0].Rows[0].Pub_Cent_name;
////					document.getElementById('txtalias').value=global_ds.Tables[0].Rows[0].Pub_Cent_Alias;
////					
////					if(global_ds.Tables[0].Rows[0].Remarks=="" || global_ds.Tables[0].Rows[0].Remarks==null ||global_ds.Tables[0].Rows[0].Remarks=="Undefined")
////					{
////					document.getElementById('txtstatusreason').value="";
////					}
////					else
////					{
////					document.getElementById('txtstatusreason').value=global_ds.Tables[0].Rows[0].Remarks;
////					}
////					
////					if(global_ds.Tables[0].Rows[0].Add1=="" || global_ds.Tables[0].Rows[0].Add1==null || global_ds.Tables[0].Rows[0].Add1=="undefined")
////					{
////						document.getElementById('txtadd1').value="";
////					}
////					else
////					{
////						document.getElementById('txtadd1').value=global_ds.Tables[0].Rows[0].Add1;
////					}
////					
////					if(global_ds.Tables[0].Rows[0].street=="" ||global_ds.Tables[0].Rows[0].street==null ||global_ds.Tables[0].Rows[0].street=="undefined")
////					{
////						document.getElementById('txtstreet').value="";
////					}
////					else
////					{   
////						document.getElementById('txtstreet').value=global_ds.Tables[0].Rows[0].street;
////					}
////					
////					//document.getElementById('drpcity').value=ds.Tables[0].Rows[0].City_Code;
////					
////					document.getElementById('txtdistrict').value=global_ds.Tables[0].Rows[0].Dist_Code;
////					document.getElementById('txtcountry').value=global_ds.Tables[0].Rows[0].Country_Code;
////					
////					    cityvar=global_ds.Tables[0].Rows[0].City_Code;
////			            addcount(global_ds.Tables[0].Rows[0].Country_Code);
////			      
////					document.getElementById('drpregion').value=global_ds.Tables[0].Rows[0].Region_code;
////					document.getElementById('drpzone').value=global_ds.Tables[0].Rows[0].Zone_code;
////					
////					
////					if(global_ds.Tables[0].Rows[0].Phone1=="" || global_ds.Tables[0].Rows[0].Phone1==null || global_ds.Tables[0].Rows[0].Phone1=="undefined")
////					{
////						document.getElementById('txtphone1').value="";
////					}
////					else
////					{
////						document.getElementById('txtphone1').value=global_ds.Tables[0].Rows[0].Phone1;
////					}
////					
////					if(global_ds.Tables[0].Rows[0].Phone2=="" || global_ds.Tables[0].Rows[0].Phone2==null || global_ds.Tables[0].Rows[0].Phone2=="undefined")
////					{
////						document.getElementById('txtphone2').value="";

////					}
////					else
////					{
////							document.getElementById('txtphone2').value=global_ds.Tables[0].Rows[0].Phone2;
////					}
////					//document.getElementById('txtstatus1').value=ds.Tables[0].Rows.;
////					
////					if( global_ds.Tables[0].Rows[0].zip == "" || global_ds.Tables[0].Rows[0].zip==null || global_ds.Tables[0].Rows[0].zip=="undefined")
////					{
////						document.getElementById('txtpincode').value="";
////					}
////					else
////					{
////						document.getElementById('txtpincode').value=global_ds.Tables[0].Rows[0].zip;
////					}
////					
////					document.getElementById('txtstate').value=global_ds.Tables[0].Rows[0].State_Code;
////					
////					if( global_ds.Tables[0].Rows[0].Fax=="" || global_ds.Tables[0].Rows[0].Fax==null || global_ds.Tables[0].Rows[0].Fax=="undefined")
////					{
////						document.getElementById('txtfax').value="";
////					}
////					else
////					{
////						document.getElementById('txtfax').value=global_ds.Tables[0].Rows[0].Fax;
////					}
////					
////					if (global_ds.Tables[0].Rows[0].EmailID=="" || global_ds.Tables[0].Rows[0].EmailID==null || global_ds.Tables[0].Rows[0].EmailID=="Undefined"  )
////					{
////						document.getElementById('txtemailid').value="";
////					}
////					else
////					{
////						document.getElementById('txtemailid').value=global_ds.Tables[0].Rows[0].EmailID;
////					}
////					
////					document.getElementById('txtfax1').value=global_ds.Tables[0].Rows[0].Fax1;
////					
//////		var akh=document.getElementById('txtcentercode').value
//////		fillCheckBoxes(akh);
////		//z=0;
//////		var tdate=global_ds.Tables[0].Rows[0].To_date;
//////	    var cdate=global_ds.Tables[0].Rows[0].Status_date;

////		            var dateformat = document.getElementById('hiddendateformat').value;
////					document.getElementById('txtstatusdate').value=global_ds.Tables[0].Rows[0].Status_date;
////		
////					var tdate1=global_ds.Tables[0].Rows[0].To_date;
////					var tdate=new Date(tdate1);
////					    var dd=tdate.getDate();
////					    var mm=tdate.getMonth() + 1;
////					    var yyyy=tdate.getFullYear();
////				if(dateformat=="dd/mm/yyyy")
////					{
////					tdate=dd+'/'+mm+'/'+yyyy;
////					}
////					else if(dateformat=="mm/dd/yyyy")
////					{
////					tdate=mm+'/'+dd+'/'+yyyy;
////					}
////					else if(dateformat=="yyyy/mm/dd")
////					{
////					tdate=yyyy+'/'+mm+'/'+dd;
////					}
////					else (dateformat==null || dateformat=="" || dateformat=="undefined")
////					{
////						tdate=mm+'/'+dd+'/'+yyyy;			
////					}
////					document.getElementById('txtstatusdate').value=tdate;
////					var cdate1=global_ds.Tables[0].Rows[0].Status_date;
////		                var cdate=new Date(cdate1);
////					    var dd1=cdate.getDate();
////					    var mm1=cdate.getMonth() + 1;
////					    var yyyy1=cdate.getFullYear();
////				if(dateformat=="dd/mm/yyyy")
////					{
////					cdate=dd1+'/'+mm1+'/'+yyyy1;
////					}
////					else if(dateformat=="mm/dd/yyyy")
////					{
////					cdate=mm1+'/'+dd1+'/'+yyyy1;
////					}
////					else if(dateformat=="yyyy/mm/dd")
////					{
////					cdate=yyyy1+'/'+mm1+'/'+dd1;
////					}
////					else (dateformat==null || dateformat=="" || dateformat=="undefined")
////					{
////						cdate=mm1+'/'+dd1+'/'+yyyy1;			
////					}
////					
////					
//************************************************************************************************
// function for current date & future date
//************************************************************************************************
function setButtonImages() {
    if (document.getElementById('btnNew').disabled == true)
        document.getElementById('btnNew').src = "btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src = "btimages/new.jpg";

    if (document.getElementById('btnSave').disabled == true)
        document.getElementById('btnSave').src = "btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src = "btimages/save.jpg";

    if (document.getElementById('btnModify').disabled == true)
        document.getElementById('btnModify').src = "btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src = "btimages/modify.jpg";

    if (document.getElementById('btnQuery').disabled == true)
        document.getElementById('btnQuery').src = "btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src = "btimages/query.jpg";

    if (document.getElementById('btnExecute').disabled == true)
        document.getElementById('btnExecute').src = "btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src = "btimages/execute.jpg";

    if (document.getElementById('btnCancel').disabled == true)
        document.getElementById('btnCancel').src = "btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src = "btimages/clear.jpg";

    if (document.getElementById('btnfirst').disabled == true)
        document.getElementById('btnfirst').src = "btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src = "btimages/first.jpg";

    if (document.getElementById('btnprevious').disabled == true)
        document.getElementById('btnprevious').src = "btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src = "btimages/previous.jpg";

    if (document.getElementById('btnnext').disabled == true)
        document.getElementById('btnnext').src = "btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src = "btimages/next.jpg";

    if (document.getElementById('btnlast').disabled == true)
        document.getElementById('btnlast').src = "btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src = "btimages/last.jpg";

    if (document.getElementById('btnDelete').disabled == true)
        document.getElementById('btnDelete').src = "btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src = "btimages/delete.jpg";

    if (document.getElementById('btnExit').disabled == true)
        document.getElementById('btnExit').src = "btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src = "btimages/exit.jpg";
    
}


function F2fillempcode(event) {

    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtemcode") {

            var compcode = document.getElementById('hiddencompcode').value;
            var empname = document.getElementById('txtemcode').value;
            //    document.getElementById("divempcode").style.display = "block";
            document.getElementById("lstempcode").style.display = "block";
            //     document.getElementById('divempcode').style.top = 278 + "px";
            //     document.getElementById('divempcode').style.left = 580 + "px";
            document.getElementById('lstempcode').focus();
            var ds = pcmcontdetails.empcodebind(compcode, empname);
            bindempcode_callbackb(ds);
        }
    }

}


function bindempcode_callbackb(res) {
    ds_AccName = res.value;

    if (ds_AccName != null) {
        var pkgitem = document.getElementById("lstempcode");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Employe Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].NAME + '(' + ds_AccName.Tables[0].Rows[i].EMP_CODE + ')' + '/' + ds_AccName.Tables[0].Rows[i].FATHER_NAME + '/' + ds_AccName.Tables[0].Rows[i].BRANCH_NAME + '/' + ds_AccName.Tables[0].Rows[i].ADDR1 + '/' + ds_AccName.Tables[0].Rows[i].PIN + '/' + ds_AccName.Tables[0].Rows[i].EMAIL + '/' + ds_AccName.Tables[0].Rows[i].PHONE + '/' + ds_AccName.Tables[0].Rows[i].DATE_OF_BIRTH + '/' + ds_AccName.Tables[0].Rows[i].DESIG, ds_AccName.Tables[0].Rows[i].EMP_CODE);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstempcode").value = "0";
    // document.getElementById("divempcode").value = "";
    document.getElementById('lstempcode').focus();

    return false;

}


function ClientisNumberforcompany(event) {
    var browser = navigator.appName;
    //alert(event.which);
    if (event.shiftKey == true)
        return false;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 9) || (event.which == 0) || (event.which == 8) || (event.which == 11) || (event.which == 13) || (event.which == 44)) {

            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 9) || (event.keyCode == 11) || (event.keyCode == 13) || (event.keyCode == 44)) {

            return true;
        }
        else {
            return false;
        }
    }

}

function fillpocrltn(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "po_update") {
            document.getElementById('lstprint').value = "";

            activeid = document.activeElement.id;
            aTag = eval(document.getElementById(activeid))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = document.getElementById('div_print').scrollLeft;
            var scrolltop = document.getElementById('div_print').scrollTop;
            document.getElementById('div_print').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById('div_print').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";

            var comp = document.getElementById('hiddencompcode').value;
            var unit = document.getElementById('hdnunit').value;
            var dateformat = document.getElementById('hiddendateformat').value;
            var extra1 = "";
            var extra2 = "";
            document.getElementById("div_print").style.display = "block";


            document.getElementById('lstprint').focus();
            PubCatMast.fillpocrl(comp,unit, "", dateformat, extra1,extra2 ,bind_pub_callback);
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
    document.getElementById('po_update').value = "";
       // document.getElementById('Hiddenscm').value = "";
        return false;
    }

    else if (event.ctrlKey == true && event.keyCode == 88) {
    document.getElementById('po_update').value = "";
      //  document.getElementById('Hiddenscm').value = "";

        return false;
    }
    else if (event.keyCode == 9) {
        return event.keyCode;
    }

    return true;
}

function onclickpoupd(event) {
    var browser = navigator.appName;
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstprint") {
            if (document.getElementById('lstprint').value == "0") {
                document.getElementById('po_update').value = "";
                document.getElementById('Hiddenscm').value = "";
                document.getElementById("div_print").style.display = "none";
                document.getElementById('po_update').focus();
                return false;
            }
            document.getElementById("div_print").style.display = "none";
            var page = document.getElementById('lstprint').value;
            var dpcd = "";
            agencycodeglo = page;
            for (var k = 0; k <= document.getElementById("lstprint").length - 1; k++) {
                if (document.getElementById('lstprint').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstprint').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstprint').options[k].innerText;
                    }
                    var splitpub = abc;
                    var str = splitpub.split("-");
                    scmname = str[0];
                    scmcode = str[1];
                    dpcd = str[2];

                    document.getElementById('po_update').value = scmname;
                    document.getElementById('Hiddenpub').value = scmcode;
                    document.getElementById('Hiddenpub1').value = dpcd;
                    document.getElementById('po_update').focus();
                    return false;
                }
            }
        }
    }
    else if (event.keyCode == 27) {
        document.getElementById('div_print').style.display = "none";
        document.getElementById('txtprint_cent').focus();
        return false;
    }
}

function bind_pub_callback(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        var pkgitem = document.getElementById("lstprint");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Scheme-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].AG_NAME + "-" + ds.Tables[0].Rows[i].AGCD + "-" + ds.Tables[0].Rows[i].DPCD, ds.Tables[0].Rows[i].AGCD);


            pkgitem.options.length;
        }
    }
    document.getElementById("lstprint").value = "0";
    return false;
}


// 1-24 value in text box

function maxfield(event) {

    var a = document.getElementById('txtcut_time').value;
    
    if (a == "") {
    }
     else
    {
        var d = parseFloat(a);
        var min = 1;
        var max = 24;

        if (d >= min && d <= max) {
            
        }
        else {
            alert("Insert Value Only Between 1 to 24");
            //$('txtcut_time').focus();
            document.getElementById("txtcut_time").focus();
            document.getElementById("txtcut_time").value = "";
            return false;
        }
    }
    
}

