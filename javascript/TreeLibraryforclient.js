var hiddentext = "";
var show = "0";
/*Genric Library for Master Priviledges*/
var chkNM = "1";
var mod = "";
//Get Permission is used to retrieve the current permission level of the form
var z = 0;
var currenttime = new Date();
var ds_exe;
var client;
var save;
//var show1="0";
var cityvar;
var falge23 = 0;
var global_ds;
var browser = navigator.appName;
var nam = "";

//'<!--#config timefmt="%B %d, %Y %H:%M:%S"--><!--#echo var="DATE_LOCAL" -->' //SSI method of getting server date
//var currenttime = '<? print date("F d, Y H:i:s", time())?>' //PHP method of getting server date

///////////Stop editting here/////////////////////////////////

var montharray = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec")
var serverdate = new Date(currenttime)

function padlength(what) {
    var output = (what.toString().length == 1) ? "0" + what : what
    return output
}

function displaytime() {
    serverdate.setSeconds(serverdate.getSeconds() + 1)
    var username = document.getElementById('hiddenusername').value;
    var datestring = montharray[serverdate.getMonth()] + " " + padlength(serverdate.getDate()) + "," + serverdate.getFullYear()
    var timestring = padlength(serverdate.getHours()) + ":" + padlength(serverdate.getMinutes()) + ":" + padlength(serverdate.getSeconds())
    document.getElementById("tP1").innerHTML = "<br>" + username + ":&nbsp" + datestring + " " + timestring

}

function Clock() {
    setInterval("displaytime()", 1000);

    //getPermission(ClientMaster);
}


function ChangeCssss() {
    if (navigator.appName.indexOf("Microsoft") != -1) {
        document.writeln('<LINK href ="css/main.css" type= "text/css" rel = "stylesheet">');
    }
    else {
        document.writeln('<LINK href ="css/main_mozilla.css" type= "text/css" rel = "stylesheet">');
    }
}

//window.onload=function(){
//setInterval("displaytime()", 1000)
//}

function EnableAdBooking(q) {
    document.getElementById('1').style.visibility = "visible";
    document.getElementById('2').style.visibility = "visible";

    document.getElementById('Topbar1_lbldisplay').style.color = "red";
    return false;
}


var FlagStatus;
function getPermission(formname) {

    var userid = document.getElementById('hiddenuserid').value;
    var compcode = document.getElementById('hiddencompcode').value;
    //ClientMaster.submitpermission(compcode,userid,formname,getPermission_CallBack);
    UOM.submitpermission(compcode, userid, formname, getPermission_CallBack_client);

    return false;
}


//Get Permission CallBack
function getPermission_CallBack_client(response) {


    var ds = response.value;

    if (ds.Tables[0].Rows.length > 0) {
        var id = ds.Tables[0].Rows[0].button_id;

        if (id == "0" || id == "8") {
            document.getElementById('bdy').style.visibility = "hidden";

            FlagStatus = 0;
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnCancel').disabled = true;
            document.getElementById('btnExit').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnModify').disabled = true;

            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('Topbar1_lbldisplay').style.visibility = "hidden";
            document.getElementById('Topbar1_Label3').style.visibility = "hidden";
            document.getElementById('Topbar1_Label4').style.visibility = "hidden";
            document.getElementById('Topbar1_Label5').style.visibility = "hidden";
            document.getElementById('Topbar1_Label2').style.visibility = "hidden";


            window.location.href = 'EnterPage.aspx';
            alert("You Are Not Authorised To See This Form");
            FlagStatus = 0;
            return false;

        }
        if (id == "1" || id == "9") {
            document.getElementById('btnNew').disabled = false;
            document.getElementById('btnQuery').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnExecute').disabled = true;

            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;
            FlagStatus = 1;
            return false;
        }
        if (id == "2" || id == "10") {

            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnModify').disabled = true;

            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnExit').disabled = false;
            FlagStatus = 2;
            return false;

        }
        if (id == "3" || id == "11") {
            document.getElementById('btnNew').disabled = false;
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnDelete').disabled = true;


            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;


            FlagStatus = 3;
            return false;

        }
        if (id == "4" || id == "12") {
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnExecute').disabled = true;

            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;


            document.getElementById('btnModify').disabled = true;

            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;


            FlagStatus = 4;
            return false;
        }
        if (id == "5" || id == "13") {
            document.getElementById('btnNew').disabled = false;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            document.getElementById('btnModify').disabled = true;
            FlagStatus = 5;
            return false;

        }
        if (id == "6" || id == "14") {
            document.getElementById('btnNew').disabled = true;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            FlagStatus = 6;
            return false;
        }
        if (id == "7" || id == "15") {
            document.getElementById('btnNew').disabled = false;
            document.getElementById('btnSave').disabled = true;
            document.getElementById('btnQuery').disabled = false;
            document.getElementById('btnModify').disabled = true;
            document.getElementById('btnCancel').disabled = false;
            document.getElementById('btnExit').disabled = false;
            document.getElementById('btnDelete').disabled = true;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnExecute').disabled = true;
            FlagStatus = 7;
            return false;
        }
    }
    else {
        alert("Please Register your form for Administrator only");
        return false;
    }
    return false;
}



//Set Permission is used to Update/Change the current permission level of the form
function setPermission(formname) {
    var userid = document.getElementById('hiddenuserid').value;
    var compcode = document.getElementById('hiddencompcode').value;
    Master.MasterPrev(userid, compcode, formname);
    return false;
}


function chkstatus(FlagStatus) {
    if (FlagStatus == 0 || FlagStatus == 8) {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnCancel').disabled = true;
        document.getElementById('btnModify').disabled = true;

        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnExit').disabled = true;
        alert("You Are Not Authorised To See This Form");
        return false;

    }
    if (FlagStatus == 1 || FlagStatus == 9) {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnModify').disabled = true;

        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnExit').disabled = false;
        return false;
    }
    if (FlagStatus == 2 || FlagStatus == 10) {
        document.getElementById('btnExecute').disabled = false;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnExit').disabled = false;

        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnExit').disabled = false;
        return false;

    }

    if (FlagStatus == 3 || FlagStatus == 11) {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;


        document.getElementById('btnModify').disabled = true;

        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
    }

    if (FlagStatus == 4 || FlagStatus == 12) {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;


        document.getElementById('btnModify').disabled = true;

        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
    }
    if (FlagStatus == 5 || FlagStatus == 13) {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;


        document.getElementById('btnModify').disabled = true;

        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
    }
    if (FlagStatus == 6 || FlagStatus == 14) {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;


        document.getElementById('btnModify').disabled = true;

        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
    }
    if (FlagStatus == 7 || FlagStatus == 15) {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;


        document.getElementById('btnModify').disabled = true;

        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = true;
    }
    return false;
}


/*-----------------------------Client Master coding starts-------------------------- */



var xmlDoc = null;
var xmlObj = null;

var req = null;

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

}

function getMessage() {
    var response = "";
    if (req.readyState == 4) {
        if (req.status == 200) {
            response = req.responseText;
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

//***********************************************************************************************************//
//*****************************************ExitButton********************************************************//
function ClientExit_client(formname) {



    if (confirm("Do You Want To Skip This Page")) {

        var compcode = document.getElementById('hiddencompcode').value;
        var custcodestatus11 = document.getElementById('txtcustcode').value;
        var userid = document.getElementById('hiddenuserid').value;

        if (custcodestatus != "") {
            ClientMaster.clearclientchildtable(compcode, custcodestatus11, userid);
        }

        if (typeof (paywind) != "undefined") {
            paywind.close();
        }
        if (typeof (statuswind) != "undefined") {
            statuswind.close();
        }
        if (typeof (contwind) != "undefined") {
            contwind.close();
        }
        window.close();
        //window.location.href='enterpage.aspx';
        return false;
    }

    return false;
}

function NewClick_client(formname) {
    ClientMaster.blankSession();
    hiddentext = "new";
    document.getElementById("divclient").style.display = "none";

    document.getElementById('hiddenquery').value = "0";
    document.getElementById('lbClientProductDetail').disabled = false;
    document.getElementById('lbClientContactDetail').disabled = false;
    document.getElementById('lbStatusDetail').disabled = false;
    document.getElementById('lbtnClientPaymode').disabled = false;
    document.getElementById('lbClientExecDetail').disabled = false;
    document.getElementById('lbClientBrandDetail').disabled = false;
    show = "1";
    ValidateStatus = "1";
    chkNM = "1";
    document.getElementById('txtstatus1').style.visibility = "hidden";
    document.getElementById('txtstatusdate').style.visibility = "hidden";
    document.getElementById('Status').style.visibility = "hidden";
    document.getElementById('StatusDate').style.visibility = "hidden";
    document.getElementById('txtcustomername').disabled = false;
    document.getElementById('CustomerName').innerHTML = "Customer Name<FONT color ='Red'>*</FONT>";

    document.getElementById('drpbranch').disabled = false;  //30sep15


    if (document.getElementById('hdnagencyclientflag').value == "Y") {
        document.getElementById('txtagencycode').disabled = false;
        //document.getElementById('txtagencycode').value = "";
    }
    document.getElementById('btnshowremark').disabled = true;
    document.getElementById('txtalias').disabled = false;
    document.getElementById('txtadd1').disabled = false;
    document.getElementById('txtstreet').disabled = false;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('drptaluka').disabled = false;
    document.getElementById('txtdistrict').disabled = false;
    document.getElementById('txtcountry').disabled = false;
    //document.getElementById('txtstate').disabled=false;						
    document.getElementById('txtphone1').disabled = false;
    document.getElementById('txtphone2').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    document.getElementById('txtUrl').disabled = false;
    document.getElementById('txtvts').disabled = false;
    document.getElementById('txtservicetax').disabled = false;
    document.getElementById('txtPan').disabled = false;
    document.getElementById('txtcreditdays').disabled = false;
    document.getElementById('txtcrlimit').disabled = false;
    document.getElementById('btnagencyname').disabled = false;

    document.getElementById('txtstatusreason').disabled = false;
    document.getElementById('drpzone').disabled = false;
    document.getElementById('drpregion').disabled = false;
    document.getElementById('drprategroup').disabled = false;

    document.getElementById('txtalert').disabled = false;
    document.getElementById('drpdiscount').disabled = false;
    document.getElementById('txtamount').disabled = false;
    document.getElementById('drpffdis').disabled = false;
    document.getElementById('txtffdisc').disabled = false;
    document.getElementById('drpcsdis').disabled = false;
    document.getElementById('txtcsdisc').disabled = false;
    document.getElementById('txtpincode').disabled = false;

    document.getElementById('txtfax').disabled = false;



    document.getElementById('txtstatus1').visible = false;
    document.getElementById('txtstatusdate').visible = false;
    document.getElementById('drpclientcat').disabled = false;
    document.getElementById('drpclinttype').disabled = false;
    document.getElementById('drptype').disabled = false;
    document.getElementById('txtparent').disabled = false;
    document.getElementById('txtclientcode').disabled = false;
    document.getElementById('drpgstus').disabled = false;
    document.getElementById('txtgstdt').disabled = false;
    document.getElementById('txtgstin').disabled = false;
    document.getElementById('drpgstatus').disabled = false;
    document.getElementById('txtgstclty').disabled = false;
    document.getElementById('txtarno').disabled = false;
    document.getElementById('txtgstprovid').disabled = false;
    


    document.getElementById('txtcustcode').value = "";
    document.getElementById('txtcustomername').value = "";
    document.getElementById('txtalias').value = "";
    if (document.getElementById('hiddenbookclientname1').value == "1") {
        document.getElementById('txtcustomername').value = document.getElementById('hiddenbookclientname').value;
        document.getElementById('txtcustomername').disabled = true;
        autogen_client();
    }

    document.getElementById('txtadd1').value = "";
    document.getElementById('txtstreet').value = "";
    document.getElementById('drpcity').value = "0";
    document.getElementById('drptaluka').value = "0";
    document.getElementById('txtdistrict').value = "";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('txtphone1').value = "";
    document.getElementById('txtphone2').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtUrl').value = "";
    document.getElementById('txtvts').value = "";
    document.getElementById('txtservicetax').value = "";
    document.getElementById('txtPan').value = "";
    document.getElementById('txtcreditdays').value = "";
    document.getElementById('txtcrlimit').value = "";
    document.getElementById('drpbranch').value = "0";
    document.getElementById('drpgstus').value = "0";
    document.getElementById('txtgstdt').value = "";
    document.getElementById('txtgstin').value = "";
    document.getElementById('txtgstclty').value = "";
    document.getElementById('drpgstatus').value = "Y";
    document.getElementById('hdngstclty').value = "";
    document.getElementById('txtarno').value = "";
    document.getElementById('txtgstprovid').value = "";

    if (document.getElementById('hiddenagency').value == "0" || document.getElementById('hiddenagency').value == "") {
        document.getElementById('drpclinttype').value = "B";
    }
    else {
        document.getElementById('drpclinttype').value = "Q";
    }

    document.getElementById('drptype').value = "P";
    document.getElementById('txtstatusreason').value = "";
    document.getElementById('txtstatus1').value = "";
    document.getElementById('txtalert').value = "";
    document.getElementById('drpdiscount').value = "0";
    document.getElementById('txtamount').value = "";
    document.getElementById('drpffdis').value = "0";
    document.getElementById('txtffdisc').value = "";
    document.getElementById('drpcsdis').value = "0";
    document.getElementById('txtcsdisc').value = "";
    document.getElementById('txtpincode').value = "";
    document.getElementById('txtstate').value = "";
    document.getElementById('txtfax').value = "";
    document.getElementById('txtstatusdate').value = "";
    document.getElementById('drpclientcat').value = "0";
    document.getElementById('drprategroup').value = document.getElementById('hiddenrate').value;
    chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;

    if (document.getElementById('hiddenauto').value == "1") {
        document.getElementById('txtcustcode').disabled = true;
        if (document.getElementById('drptype').disabled == false)
            document.getElementById('drptype').focus();
    }
    else {
        document.getElementById('txtcustcode').disabled = false;
        document.Form1.txtcustcode.focus();
    }
    setButtonImages();
    return false;

}
var Mycustcode;
var custcodestatus;

function CancelClick_client(formname) {
    ClientMaster.blankSession();
    document.getElementById('CustomerName').innerHTML = "Customer Name<FONT color ='Red'>*</FONT>";

    document.getElementById('txtdesg').value = "";
    document.getElementById("divclient").style.display = "none";
    document.getElementById('lbClientProductDetail').disabled = true;
    document.getElementById('lbClientContactDetail').disabled = true;
    document.getElementById('lbStatusDetail').disabled = true;
    document.getElementById('lbtnClientPaymode').disabled = true;
    document.getElementById('lbClientExecDetail').disabled = true;
    document.getElementById('lbClientBrandDetail').disabled = true;
    document.getElementById('hiddenquery').value = "0"
    show = "0";
    ValidateStatus = "0";
    var compcode = document.getElementById('hiddencompcode').value;
    custcodestatus = document.getElementById('txtcustcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    if (custcodestatus != "") {
        ClientMaster.clearclientchildtable(compcode, custcodestatus, userid);
    }

    //check whether the user has been registered in retainer master or not
    //if not then delete all data in pop ups
    //or do nothing just clear the values
    //delete data from all popups
    /*if(custcodestatus =="")
    {
	
	}
    else
    {
    ClientMaster.CheckClientPopup(compcode,custcodestatus,userid,1,CheckClientUser_CallBack);
    }*/
    document.getElementById('btnagencyname').disabled = true;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('txtcustcode').disabled = true;
    document.getElementById('txtcustomername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('drptaluka').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtUrl').disabled = true;
    document.getElementById('txtvts').disabled = true;
    document.getElementById('txtservicetax').disabled = true;
    document.getElementById('txtPan').disabled = true;
    document.getElementById('txtcreditdays').disabled = true;
    document.getElementById('txtcrlimit').disabled = true;
    document.getElementById('drpclientcat').disabled = true;

    document.getElementById('btnshowremark').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtalert').disabled = true;
    document.getElementById('drpdiscount').disabled = true;
    document.getElementById('txtamount').disabled = true;
    document.getElementById('drpffdis').disabled = true;
    document.getElementById('txtffdisc').disabled = true;
    document.getElementById('drpcsdis').disabled = true;
    document.getElementById('txtcsdisc').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('drprategroup').disabled = true;
    document.getElementById('drpclinttype').disabled = true;
    document.getElementById('drptype').disabled = true;
    document.getElementById('txtclientcode').disabled = true;
    document.getElementById('drpgstus').disabled = true;
    document.getElementById('txtgstdt').disabled = true;
    document.getElementById('txtgstin').disabled = true;
    document.getElementById('txtgstclty').disabled = true;
    document.getElementById('drpgstatus').disabled = true;
    document.getElementById('txtarno').disabled = true;
    document.getElementById('txtgstprovid').disabled = true;
   
    if (document.getElementById('hiddenagency').value == "0" || document.getElementById('hiddenagency').value == "") {
        document.getElementById('drpclinttype').value = "B";
    }
    else {
        document.getElementById('drpclinttype').value = "Q";
    }
    if (document.getElementById('hdnagencyclientflag').value == "Y") {
        document.getElementById('txtagencycode').disabled = true;
           document.getElementById('txtagencycode').value = "";
    }
    document.getElementById('txtagencycode').value = "";
    document.getElementById('txtcustcode').value = "";
    document.getElementById('txtcustomername').value = "";
    document.getElementById('txtalias').value = "";
    document.getElementById('txtadd1').value = "";
    document.getElementById('txtstreet').value = "";
    document.getElementById('drpcity').value = "0";
    document.getElementById('drptype').value = "P";
    document.getElementById('drpregion').value = "0";
    document.getElementById('drpregion').options.length = 0;
    document.getElementById('drpzone').options.length = 0;
    document.getElementById('drptaluka').options.length = 0;
    document.getElementById('drpcity').options.length = 0;
    document.getElementById('drpzone').value = "0";
    document.getElementById('txtdistrict').value = "";
    document.getElementById('txtparent').value = "";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('drptaluka').value = "0";
    document.getElementById('txtphone1').value = "";
    document.getElementById('txtphone2').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtUrl').value = "";
    document.getElementById('txtvts').value = "";
    document.getElementById('txtservicetax').value = "";
    document.getElementById('txtPan').value = "";
    document.getElementById('txtcreditdays').value = "";
    document.getElementById('txtcrlimit').value = "";
    document.getElementById('txtstatusreason').value = "";
    document.getElementById('txtstatus1').value = "";
    document.getElementById('txtalert').value = "";
    document.getElementById('drpdiscount').value = "0";
    document.getElementById('txtamount').value = "";
    document.getElementById('drpffdis').value = "0";
    document.getElementById('txtffdisc').value = "";
    document.getElementById('drpcsdis').value = "0";
    document.getElementById('txtcsdisc').value = "";
    document.getElementById('txtpincode').value = "";
    document.getElementById('txtstate').value = "";
    document.getElementById('txtfax').value = "";
    document.getElementById('txtstatusdate').value = "";
    document.getElementById('modify').value = "";
    document.getElementById('drprategroup').value = "0";
    document.getElementById('drpclientcat').value = "0";
    document.getElementById('drpbranch').value = "0";//30sep15
    document.getElementById('txtclientcode').value = "";
    document.getElementById('drpgstus').value = "0";
    document.getElementById('txtgstdt').value = "";
    document.getElementById('txtgstin').value = "";
    document.getElementById('txtgstclty').value = "";
    document.getElementById('drpgstatus').value = "Y";
    document.getElementById('hdngstclty').value = "";
    document.getElementById('txtarno').value = "";
    document.getElementById('txtgstprovid').value = "";
    document.getElementById("txtparent").style.display = "none";
    document.getElementById("lbparent").style.display = "none";
   
    client = "new";
    save = "N_CONT";
    var custcode13 = document.getElementById('txtcustcode').value;
    var ds13 = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode13 + '&client=' + client, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                ds13 = httpRequest.responseText;
            }
            else {
                alert('There was a problem with the request.');
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode13 + '&client=' + client, false);
        xml.Send();
        ds13 = xml.responseText;
    }
    //getPermission(formname);

    givebuttonpermission(formname);
    if (document.getElementById('btnNew').disabled == false) {
        document.getElementById('btnNew').focus();
    }
    setButtonImages();
    return false;
}
function CheckClientUser_CallBack(response) {
    var ds = response.value;
    if (ds.Tables[0].Rows.length == 0) {
        var compcode = document.getElementById('hiddencompcode').value;
        custcodestatus = document.getElementById('txtcustcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        ClientMaster.ClientDelete(compcode, custcodestatus, userid);
        return false;
    }
    return false;
}

function QueryClickclient_client(formname) {
    ClientMaster.blankSession();
    hiddentext = "query";
    document.getElementById("divclient").style.display = "none";
    document.getElementById('hiddenquery').value = "query";
    show = "0";
    z = 0;
    chkNM = "2";
    document.getElementById('txtdesg').disabled = false;
    document.getElementById('btnshowremark').disabled = true;
    document.getElementById('txtcustcode').disabled = false;
    document.getElementById('txtcustomername').disabled = false;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtUrl').disabled = true;
    document.getElementById('txtvts').disabled = true;
    document.getElementById('txtservicetax').disabled = true;
    document.getElementById('txtPan').disabled = true;
    document.getElementById('txtcreditdays').disabled = true;
    document.getElementById('txtcrlimit').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtstatus1').disabled = false;
    document.getElementById('txtalert').disabled = true;
    document.getElementById('drpdiscount').disabled = false;
    document.getElementById('txtamount').disabled = false;
    document.getElementById('drpffdis').disabled = false;
    document.getElementById('txtffdisc').disabled = false;
    document.getElementById('drpcsdis').disabled = false;
    document.getElementById('txtcsdisc').disabled = false;	
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('drprategroup').disabled = false;
    document.getElementById('drpclientcat').disabled = false;
    document.getElementById('drpclinttype').disabled = true;
    document.getElementById('drptype').disabled = false;
    document.getElementById('drptaluka').disabled = true;
    document.getElementById('drpgstus').disabled = true;
    document.getElementById('txtgstdt').disabled = true;
    document.getElementById('txtgstin').disabled = true;
    document.getElementById('txtarno').disabled = true;
    document.getElementById('txtgstprovid').disabled = true;
    document.getElementById('drptaluka').options.length = 0;
    document.getElementById('drpregion').options.length = 0;
    document.getElementById('drpzone').options.length = 0;
    document.getElementById("txtparent").style.display = "none";
    document.getElementById("lbparent").style.display = "none";
    document.getElementById('txtparent').disabled = true;
    document.getElementById('btnagencyname').disabled = true;
    document.getElementById('drptype').value = "P";
    document.getElementById('drprategroup').value = "0";
    document.getElementById('txtcustcode').value = "";
    document.getElementById('txtcustomername').value = "";
    document.getElementById('txtalias').value = "";
    document.getElementById('txtadd1').value = "";
    document.getElementById('txtstreet').value = "";
    document.getElementById('drpcity').options.length = 0;
    document.getElementById('txtdistrict').value = "";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('txtphone1').value = "";
    document.getElementById('txtphone2').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtUrl').value = "";
    document.getElementById('txtvts').value = "";
    document.getElementById('txtservicetax').value = "";
    document.getElementById('txtPan').value = "";
    document.getElementById('txtcreditdays').value = "";
    document.getElementById('txtcrlimit').value = "";
    document.getElementById('txtstatusreason').value = "";
    document.getElementById('txtstatus1').value = "";
    document.getElementById('txtalert').value = "";
    document.getElementById('drpdiscount').value = "0";
    document.getElementById('txtamount').value = "";
    document.getElementById('drpffdis').value = "0";
    document.getElementById('txtffdisc').value = "";
    document.getElementById('drpcsdis').value = "0";
    document.getElementById('txtcsdisc').value = "";
    document.getElementById('txtpincode').value = "";
    document.getElementById('txtstate').value = "";
    document.getElementById('txtfax').value = "";
    document.getElementById('txtstatusdate').value = "";
    document.getElementById('drpclientcat').value = "0";
    document.getElementById('drpgstus').value = "0";
    document.getElementById('txtgstdt').value = "";
    document.getElementById('txtgstin').value = "";
    document.getElementById('txtgstclty').value = "";
    document.getElementById('drpgstatus').value = "0";
    document.getElementById('txtarno').value = "";
    document.getElementById('txtgstprovid').value = "";
    document.getElementById('txtstatus1').style.visibility = "hidden";
    document.getElementById('txtstatusdate').style.visibility = "hidden";
    document.getElementById('Status').style.visibility = "hidden";
    document.getElementById('StatusDate').style.visibility = "hidden";
    document.getElementById('txtclientcode').disabled = true;
    document.getElementById('txtclientcode').value = "";
    chkstatus(FlagStatus);
    document.getElementById('btnQuery').disabled = true;
    if (document.getElementById('hdnagencyclientflag').value == "Y") {
        document.getElementById('txtagencycode').disabled = true;
        document.getElementById('txtagencycode').value = "";
    }
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnnext').disabled = true;

    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnExecute').focus();
    document.getElementById('btnSave').disabled = true;
    //------------ for pop up disable --------------------------//
    document.getElementById('lbClientProductDetail').disabled = true;
    document.getElementById('lbClientContactDetail').disabled = true;
    document.getElementById('lbStatusDetail').disabled = true;
    document.getElementById('lbtnClientPaymode').disabled = true;
    document.getElementById('lbClientExecDetail').disabled = true;
    document.getElementById('lbClientBrandDetail').disabled = true;
    //===========================================================================//
    z = 0;
    client = "new";
    save = "N_CONT";
    var custcode13 = document.getElementById('txtcustcode').value;
    var ds13 = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode13 + '&client=' + client, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                ds13 = httpRequest.responseText;
            }
            else {
                alert('There was a problem with the request.');
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode13 + '&client=' + client, false);
        xml.Send();
        ds13 = xml.responseText;
    }
    document.getElementById('txtcustomername').title = "Press F2 to view entered client.";
    setButtonImages();
    return false;

}

function modifynext(response) {


    ds_exe = response.value;
    var z = ds_exe.Tables[0].Rows.length;
    //z=0;


    document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[0].Cust_Code;
    document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[0].Cust_Name;
    document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[0].Cust_Alias;

    document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[0].Stree;
    document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[0].Zip;
    document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[0].phone1;
    document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[0].Phone2;
    document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[0].Fax;
    //No_of_VTS
    document.getElementById('txtvts').value = ds_exe.Tables[0].Rows[0].No_of_VTS;
    document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[0].EmailID;
    document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[0].URL;
    document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[0].ST_ACC_NO;
    document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[0].PAN_NO;
    if (ds_exe.Tables[0].Rows[0].Credit_Days != null && ds_exe.Tables[0].Rows[0].Credit_Days != 0) {
        document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[0].Credit_Days;
    }
    else {
        document.getElementById('txtcreditdays').value = "";
    }

    document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[0].Status_Reason;
    //alert(ds_exe.Tables[0].Rows[0].Country_code);
    document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[0].Country_Code;
    cityvar = ds_exe.Tables[0].Rows[0].City_Code;
    addcount_client(ds_exe.Tables[0].Rows[0].City_Code);


    document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[0].State_Code;
    if (ds_exe.Tables[0].Rows[0].Dist_Code != null) {
        document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[0].Dist_Code;
    }
    else {
        document.getElementById('txtdistrict').value = "";
    }
    //addregcity();
    addregcity_client(cityvar);
    document.getElementById('drpzone').value = ds_exe.Tables[0].Rows[0].Zone_code;
    document.getElementById('drpregion').value = ds_exe.Tables[0].Rows[0].Region_code;
    document.getElementById('drptaluka').value = ds_exe.Tables[0].Rows[0].TALUKA;
    document.getElementById('txtcrlimit').value = ds_exe.Tables[0].Rows[0].Credit_limit;
    document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[0].Rate_Gr_Code;

    document.getElementById('txtstatus1').style.visibility = "hidden";
    document.getElementById('txtstatusdate').style.visibility = "hidden";
    document.getElementById('Status').style.visibility = "hidden";
    document.getElementById('StatusDate').style.visibility = "hidden";
    var dateformat = document.getElementById('hiddendateformat').value;
    //var currentdate=ds_exe.Tables[0].Rows[0].Creation_Datetime;
    var currentdate = new Date();
    var dd = currentdate.getDate();
    var mm = currentdate.getMonth() + 1;
    var yyyy = currentdate.getFullYear();
    //var enrolldate1=mm+'/'+dd+'/'+yyyy;

    if (dateformat == "yyyy/mm/dd") {
        var currentdate1 = yyyy + '/' + mm + '/' + dd;
    }
    else if (dateformat == "mm/dd/yyyy") {
        var currentdate1 = mm + '/' + dd + '/' + yyyy;
    }
    else if (dateformat == "dd/mm/yyyy") {
        var currentdate1 = dd + '/' + mm + '/' + yyyy;
    }
    else {
        var currentdate1 = mm + '/' + dd + '/' + yyyy;
    }



    var todate7 = ds_exe.Tables[0].Rows[0].to_date;
    var dd = todate7.getDate();
    var mm = todate7.getMonth() + 1;
    var yyyy = todate7.getFullYear();
    //var enrolldate1=mm+'/'+dd+'/'+yyyy;

    if (dateformat == "yyyy/mm/dd") {
        var todate17 = yyyy + '/' + mm + '/' + dd;
    }
    else if (dateformat == "mm/dd/yyyy") {
        var todate17 = mm + '/' + dd + '/' + yyyy;
    }
    else if (dateformat == "dd/mm/yyyy") {
        var todate17 = dd + '/' + mm + '/' + yyyy;
    }
    else {
        var todate17 = mm + '/' + dd + '/' + yyyy;
    }




    document.getElementById('txtstatusdate').value = currentdate1;
    document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[0].Remarks;
    document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[0].UserId;
    document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[0].Add1;
    document.getElementById('txtstatus1').style.visibility = "visible";
    document.getElementById('txtstatusdate').style.visibility = "visible";
    document.getElementById('Status').style.visibility = "visible";
    document.getElementById('StatusDate').style.visibility = "visible";

    var tdate = new Date(todate17);
    var cdate = new Date(currentdate1);
    if (cdate > tdate) {
        document.getElementById('txtstatus1').value = "Banned"
    }
    else {
        document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[0].Cust_Status;
    }
    document.getElementById('btnSave').disabled = false;


    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnExit').disabled = false;
    setButtonImages();
    return false;


}
function Modify_client(formname) {
    hiddentext = "modify";
    document.getElementById("divclient").style.display = "none";
    document.getElementById('hiddenquery').value = "0";
    show = "1";
    chkNM = "0";
    mod = document.getElementById('txtcustomername').value;
    document.getElementById('modify').value = "modify";
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('txtclientcode').disabled = false;
    document.getElementById('txtcustcode').disabled = true;
    document.getElementById('txtcustomername').disabled = false;
    document.getElementById('drprategroup').disabled = false;
    document.getElementById('txtalias').disabled = false;
    document.getElementById('txtadd1').disabled = false;
    document.getElementById('txtstreet').disabled = false;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('txtdistrict').disabled = false;
    document.getElementById('drptaluka').disabled = false;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('txtphone1').disabled = false;
    document.getElementById('txtphone2').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    document.getElementById('txtUrl').disabled = false;
    document.getElementById('txtvts').disabled = false;
    document.getElementById('txtservicetax').disabled = false;
    document.getElementById('txtPan').disabled = false;
    document.getElementById('txtcreditdays').disabled = false;
    document.getElementById('txtcrlimit').disabled = false;
    document.getElementById('txtstatusreason').disabled = false;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtalert').disabled = false;
    document.getElementById('drpdiscount').disabled = false;
    document.getElementById('txtamount').disabled = false;
    document.getElementById('drpffdis').disabled = false;
    document.getElementById('txtffdisc').disabled = false;
    document.getElementById('drpcsdis').disabled = false;
    document.getElementById('txtcsdisc').disabled = false;
    document.getElementById('txtpincode').disabled = false;
    document.getElementById('txtstate').disabled = false;
    document.getElementById('txtfax').disabled = false;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnQuery').disabled = true
    document.getElementById('drpclientcat').disabled = false;
    document.getElementById('drpbranch').disabled = false; //30sep15
    document.getElementById('drpclinttype').disabled = false;
    document.getElementById('drptype').disabled = false;
    document.getElementById('txtparent').disabled = false;
    chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;
    document.getElementById('drpgstus').disabled = false;
    document.getElementById('txtgstdt').disabled = false;
    document.getElementById('txtgstin').disabled = false;
    document.getElementById('txtgstclty').disabled = false;
    document.getElementById('drpgstatus').disabled = false;
    document.getElementById('txtarno').disabled = false;
    document.getElementById('txtgstprovid').disabled = false;
    if (document.getElementById('hdnagencyclientflag').value == "Y") {
        document.getElementById('txtagencycode').disabled = false;
       // document.getElementById('txtagencycode').value = "";
    }
    flag = 1;
    setButtonImages();
    return false;


}
var coco;
var cuco;
var cuna;
var al;
var ci;
var st;
var us;
var ra;
var co;
function clickexecuteclient_client(formname) {


    document.getElementById('txtdesg').disabled = true;
    document.getElementById('lbClientProductDetail').disabled = false;
    document.getElementById('lbClientContactDetail').disabled = false;
    document.getElementById('lbStatusDetail').disabled = false;
    document.getElementById('lbtnClientPaymode').disabled = false;
    document.getElementById('lbClientExecDetail').disabled = false;
    document.getElementById('lbClientBrandDetail').disabled = false;
    document.getElementById("divclient").style.display = "none";
    document.getElementById('hiddenquery').value = "0";
    document.getElementById('drptype').disabled = true;
    document.getElementById('txtparent').disabled = true;
    document.getElementById('btnshowremark').disabled = false;
    document.getElementById('btnagencyname').disabled = true;
    var compcode = document.getElementById('hiddencompcode').value;
    coco = compcode;
    var custcode = document.getElementById('txtcustcode').value;
    cuco = custcode;
    var custname = document.getElementById('txtcustomername').value;
    cuna = custname;
    var alias = document.getElementById('txtalias').value;
    al = alias;
    var city = document.getElementById('drpcity').value;
    ci = city;
    var status1 = document.getElementById('txtstatus1').value;
    st = status1;
    var userid = document.getElementById('hiddenuserid').value;
    us = userid;
    var rategroup = document.getElementById('drprategroup').value;
    ra = rategroup;
    var country = document.getElementById('txtcountry').value;
    co = country;
    var discount = document.getElementById('drpdiscount').value;
    var amount = document.getElementById('txtamount').value;
    var ffdiscount = document.getElementById('drpffdis').value;
    var ffdamount = document.getElementById('txtffdisc').value;
    var casdisc = document.getElementById('drpcsdis').value;
    var cshdiscamount = document.getElementById('txtcsdisc').value;
    var type = document.getElementById('drptype').value;
    var agency_sav = document.getElementById('hiddenagency_uer').value;

    var resp = ClientMaster.clientexecute_client(compcode, custcode, custname, alias, city, status1, userid, rategroup, country, agency_sav, type, discount, amount, ffdiscount, ffdamount, casdisc, cshdiscamount);
    call_clientexecutsa_client(resp);
    
    return false;

}

function call_clientexecutsa_client(response) {
    //show1="5";

    ds_exe = response.value;
    chkstatus(FlagStatus);
    if (ds_exe.value == "" || ds_exe.value == "Undefined" || ds_exe.Tables[0].Rows.length == 0) {
        CancelClick('ClientMaster');
        alert("Your Search Criteria Does not Produce Any Search");
        document.getElementById('txtcustcode').value = "";
        document.getElementById('txtcustomername').value = "";
        document.getElementById('txtalias').value = "";
        document.getElementById('txtadd1').value = "";
        document.getElementById('txtstreet').value = "";
        //document.getElementById('drpcity').value=0;			
        document.getElementById('txtdistrict').value = "";
        document.getElementById('txtcountry').value = "0";
        document.getElementById('txtphone1').value = "";
        document.getElementById('txtphone2').value = "";
        document.getElementById('txtemailid').value = "";
        document.getElementById('txtUrl').value = "";
        document.getElementById('txtvts').value = "";
        document.getElementById('txtservicetax').value = "";
        document.getElementById('txtPan').value = "";
        document.getElementById('txtcreditdays').value = "";
        document.getElementById('txtcrlimit').value = "";
        document.getElementById('txtstatusreason').value = "";
        document.getElementById('txtstatus1').value = "";
        document.getElementById('txtalert').value = "";
        document.getElementById('drpdiscount').value = "0";
        document.getElementById('txtamount').value = "";
        document.getElementById('drpffdis').value = "0";
        document.getElementById('txtffdisc').value = "";
        document.getElementById('drpcsdis').value = "0";
        document.getElementById('txtcsdisc').value = "";
        document.getElementById('txtpincode').value = "";
        document.getElementById('txtstate').value = "";
        document.getElementById('txtfax').value = "";
        document.getElementById('txtstatusdate').value = "";
        document.getElementById('drprategroup').value = "0";
        document.getElementById('drpregion').value = "0";
        document.getElementById('drpzone').value = "0";
        document.getElementById('drpclientcat').value = "0";
        document.getElementById('drptype').value = "P";
        document.getElementById('drpgstus').value = "0";
        document.getElementById('txtgstdt').value = "";
        document.getElementById('txtgstin').value = "";
        document.getElementById('txtgstclty').value = "";
        document.getElementById('drpgstatus').value = "0";
        document.getElementById('hdngstclty').value = "";
        document.getElementById('txtarno').value = "";
        document.getElementById('txtgstprovid').value = "";

        document.getElementById('drpgstus').disabled = true;
        document.getElementById('txtgstdt').disabled = true;
        document.getElementById('txtgstin').disabled = true;
        document.getElementById('txtarno').disabled = true;
        document.getElementById('txtgstprovid').disabled = true;
        document.getElementById('txtcustcode').disabled = true;
        document.getElementById('txtcustomername').disabled = true;
        document.getElementById('txtalias').disabled = true;
        document.getElementById('txtadd1').disabled = true;
        document.getElementById('txtstreet').disabled = true;
        document.getElementById('drpcity').disabled = true;
        document.getElementById('txtdistrict').disabled = true;
        document.getElementById('txtcountry').disabled = true;
        document.getElementById('txtphone1').disabled = true;
        document.getElementById('txtphone2').disabled = true;
        document.getElementById('txtemailid').disabled = true;
        document.getElementById('txtUrl').disabled = true;
        document.getElementById('txtvts').disabled = true;
        document.getElementById('txtservicetax').disabled = true;
        document.getElementById('txtPan').disabled = true;
        document.getElementById('txtcreditdays').disabled = true;
        document.getElementById('txtcrlimit').disabled = true;
        document.getElementById('txtstatusreason').disabled = true;
        document.getElementById('txtstatus1').disabled = true;
        document.getElementById('txtalert').disabled = true;
        document.getElementById('drpdiscount').disabled = true;
        document.getElementById('txtamount').disabled = true;
        document.getElementById('drpffdis').disabled = true;
        document.getElementById('txtffdisc').disabled = true;
        document.getElementById('drpcsdis').disabled = true;
        document.getElementById('txtcsdisc').disabled = true;
        document.getElementById('txtpincode').disabled = true;
        document.getElementById('txtstate').disabled = true;
        document.getElementById('txtfax').disabled = true;
        document.getElementById('txtstatusdate').disabled = true;
        document.getElementById('drprategroup').disabled = true;
        document.getElementById('drpclientcat').disabled = true;
        document.getElementById('drptype').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        if (document.getElementById('hdnagencyclientflag').value == "Y") {
            document.getElementById('txtagencycode').disabled = true;
            //document.getElementById('txtagencycode').value = "";
        }
        return false;
    }

    if (ds_exe.Tables[0].Rows.length > 0) {
        document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[0].Cust_Code;
        document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[0].Cust_Name;
        document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[0].Cust_Alias;
        if (ds_exe.Tables[0].Rows[0].CLIENT_DESIGNATION != null) {
            document.getElementById('txtdesg').value = ds_exe.Tables[0].Rows[0].CLIENT_DESIGNATION;
        } else {
            document.getElementById('txtdesg').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].STREE != null) {
            document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[0].STREE;
        }
        else {
            document.getElementById('txtstreet').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].Zip != null) {
            document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[0].Zip;
        }
        else {
            document.getElementById('txtpincode').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].phone1 != null) {
            document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[0].phone1;
        }
        else {
            document.getElementById('txtphone1').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].Phone2 != null) {
            document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[0].Phone2;
        }
        else {
            document.getElementById('txtphone2').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].Fax != null) {
            document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[0].Fax;
        }
        else {
            document.getElementById('txtfax').value = "";
        }
        //No_of_VTS
        if (ds_exe.Tables[0].Rows[0].No_of_VTS != null) {
            document.getElementById('txtvts').value = ds_exe.Tables[0].Rows[0].No_of_VTS;
        }
        else {
            document.getElementById('txtvts').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].EMAILID != null) {
            document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[0].EMAILID;
        }
        else {
            document.getElementById('txtemailid').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].URL != null) {
            document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[0].URL;
        }
        else {
            document.getElementById('txtUrl').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].ST_ACC_NO != null) {
            document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[0].ST_ACC_NO;
        }
        else {
            document.getElementById('txtservicetax').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].PAN_NO != null) {
            document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[0].PAN_NO;
        }
        else {
            document.getElementById('txtPan').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].Credit_Days != null && ds_exe.Tables[0].Rows[0].Credit_Days != 0) {
            document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[0].Credit_Days;
        }
        else {
            document.getElementById('txtcreditdays').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].Status_Reason != null) {
            document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[0].Status_Reason;
        }
        else {
            document.getElementById('txtstatusreason').value = "";
        }
        document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[0].Country_Code;
        cityvar = ds_exe.Tables[0].Rows[0].City_Code;
        var country = ds_exe.Tables[0].Rows[0].Country_Code;//document.getElementById('txtcountry').value;
        var pkgitem = document.getElementById("drpcity");
        pkgitem.options.length = 0;
        var res = ClientMaster.addcou(country);
        var ds = res.value;
        var pkgitem = document.getElementById("drpcity");
        pkgitem.options.length = 0;
        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name, res.value.Tables[0].Rows[i].City_Code);
                pkgitem.options.length;
            }
            if (cityvar == 'undefined' || cityvar == undefined) {
                document.getElementById('drpcity').value = res.value.Tables[0].Rows[0].City_Code;
            }
            else {
                document.getElementById('drpcity').value = cityvar;
            }
        }
        else {
            alert("There is No Matching value Found");
            pkgitem.options.length = 0;
            document.getElementById('drpzone').value = "0";
            document.getElementById('drpregion').value = "0";
            document.getElementById('txtstate').value = "";
            document.getElementById('txtdistrict').value = "";
            return false;
        }
        if (ds_exe.Tables[0].Rows[0].State_Code != null) {
            document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[0].State_Code;
        }
        else {
            document.getElementById('txtstate').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].Dist_Code != null) {
            document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[0].Dist_Code;
        }
        else {
            document.getElementById('txtdistrict').value = "";
        }
        addregcity_client(cityvar);
        document.getElementById('drpzone').value = ds_exe.Tables[0].Rows[0].Zone_code;
        document.getElementById('drpregion').value = ds_exe.Tables[0].Rows[0].Region_code;

        if (ds_exe.Tables[0].Rows[0].TALUKA != null) {
            document.getElementById('drptaluka').value = ds_exe.Tables[0].Rows[0].TALUKA;
        }
        else {
            document.getElementById('drptaluka').value = "0";
        }

        if (ds_exe.Tables[0].Rows[0].Credit_limit != null) {
            document.getElementById('txtcrlimit').value = ds_exe.Tables[0].Rows[0].Credit_limit;
        }
        else {
            document.getElementById('txtcrlimit').value = "";
        }
        document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[0].Rate_Gr_Code;

        document.getElementById('txtstatus1').style.visibility = "hidden";
        document.getElementById('txtstatusdate').style.visibility = "hidden";
        document.getElementById('Status').style.visibility = "hidden";
        document.getElementById('StatusDate').style.visibility = "hidden";
        var dateformat = document.getElementById('hiddendateformat').value;
        var currentdate = new Date();
        var dd = currentdate.getDate();
        var mm = currentdate.getMonth() + 1;
        var yyyy = currentdate.getFullYear();
        if (dateformat == "yyyy/mm/dd") {
            var currentdate1 = yyyy + '/' + mm + '/' + dd;
        }
        else if (dateformat == "mm/dd/yyyy") {
            var currentdate1 = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "dd/mm/yyyy") {
            var currentdate1 = dd + '/' + mm + '/' + yyyy;
        }
        else {
            var currentdate1 = mm + '/' + dd + '/' + yyyy;
        }
        //******************************mychang****************************//
        var todate7 = ds_exe.Tables[0].Rows[0].to_date;
        if (todate7 != null) {
            var dd = todate7.getDate();
            var mm = todate7.getMonth() + 1;
            var yyyy = todate7.getFullYear();
            if (dateformat == "yyyy/mm/dd") {
                var todate17 = yyyy + '/' + mm + '/' + dd;
            }
            else if (dateformat == "mm/dd/yyyy") {
                var todate17 = mm + '/' + dd + '/' + yyyy;
            }
            else if (dateformat == "dd/mm/yyyy") {
                var todate17 = dd + '/' + mm + '/' + yyyy;
            }
            else {
                var todate17 = mm + '/' + dd + '/' + yyyy;
            }
        }
        else {
            todate17 = "";
        }
        //***********************************************************************//	
        document.getElementById('txtstatusdate').value = currentdate1;
        if (ds_exe.Tables[0].Rows[0].Remarks != null) {
            document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[0].Remarks;
        }
        else {
            document.getElementById('txtalert').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].DISC_TY != null) {
            document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[0].DISC_TY;
        }
        else {
            document.getElementById('drpdiscount').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].DISC_AMT != null) {
            document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[0].DISC_AMT;
        }
        else {
            document.getElementById('txtamount').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY != null) {
            document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY;
        }
        else {
            document.getElementById('drpffdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT != null) {
            document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT;
        }
        else {
            document.getElementById('txtffdisc').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].CASH_DISC != null) {
            document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[0].CASH_DISC;
        }
        else {
            document.getElementById('drpcsdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].CASH_AMT != null) {
            document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[0].CASH_AMT;
        }
        else {
            document.getElementById('txtcsdisc').value = "";
        }
        document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[0].UserId;
        if (ds_exe.Tables[0].Rows[0].ADD1 != null) {
            document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[0].ADD1;
        }
        else {
            document.getElementById('txtadd1').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].CLIENT_TYPE != null) {
            document.getElementById('drpclinttype').value = ds_exe.Tables[0].Rows[0].CLIENT_TYPE;
        }
        else {
            document.getElementById('drpclinttype').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].QBC_AGENCY != null) {
            document.getElementById('txtagencycode').value = ds_exe.Tables[0].Rows[0].QBC_AGENCY;
        }
        else {
            document.getElementById('txtagencycode').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].TYPE != null) {
            document.getElementById('drptype').value = ds_exe.Tables[0].Rows[0].TYPE;
        }
        else {
            document.getElementById('drptype').value = "P";
        }
        if (ds_exe.Tables[0].Rows[0].TYPE == "C") {
            if (ds_exe.Tables[0].Rows[0].PARENT_CLIENT != null && ds_exe.Tables[0].Rows[0].PARENT_CLIENT != "") {
                nam = ds_exe.Tables[0].Rows[0].PARENT_CLIENT;
                document.getElementById('txtparent').value = getclintname(ds_exe.Tables[0].Rows[0].PARENT_CLIENT)
                document.getElementById("txtparent").style.display = "block";
                document.getElementById("lbparent").style.display = "block";
            }
        }
        else {
            document.getElementById('txtparent').value = "";
            document.getElementById("txtparent").style.display = "none";
            document.getElementById("lbparent").style.display = "none";
        }

        if (ds_exe.Tables[0].Rows[0].OLD_CLIENT_CODE != null) {
            document.getElementById('txtclientcode').value = ds_exe.Tables[0].Rows[0].OLD_CLIENT_CODE;
        }
        else {
            document.getElementById('txtclientcode').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_REGISTRATION != null) {
            document.getElementById('drpgstus').value = ds_exe.Tables[0].Rows[0].GST_REGISTRATION;
        }
        else {
            document.getElementById('drpgstus').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].GST_REGISTRATION_DATE != null) {
            document.getElementById('txtgstdt').value = ds_exe.Tables[0].Rows[0].GST_REGISTRATION_DATE;
        }
        else {
            document.getElementById('txtgstdt').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].GSTIN != null) {
            document.getElementById('txtgstin').value = ds_exe.Tables[0].Rows[0].GSTIN;
        }
        else {
            document.getElementById('txtgstin').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_STATUS != null) {
            document.getElementById('drpgstatus').value = ds_exe.Tables[0].Rows[0].GST_STATUS;
        }
        else {
            document.getElementById('drpgstatus').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD != null) {
            document.getElementById('txtgstclty').value = ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD;
            var citytyp = ClientMaster.fill_gst(document.getElementById('hiddencompcode').value, ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD);
            var ccty = citytyp.value.Tables[0].Rows[0].CLIENT_TYPE_NAME;
            document.getElementById('txtgstclty').value = ccty;
        }
        else {
            document.getElementById('txtgstclty').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_ARN_NO != null) {
            document.getElementById('txtarno').value = ds_exe.Tables[0].Rows[0].GST_ARN_NO;
        }
        else {
            document.getElementById('txtarno').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_PROVISINAL_ID != null) {
            document.getElementById('txtgstprovid').value = ds_exe.Tables[0].Rows[0].GST_PROVISINAL_ID;
        }
        else {
            document.getElementById('txtgstprovid').value = "";
        }


        document.getElementById('drpclientcat').value = ds_exe.Tables[0].Rows[0].Client_category;
document.getElementById('drpbranch').value = ds_exe.Tables[0].Rows[0].BRANCH_CODE;  //30SEP15

        document.getElementById('txtstatus1').style.visibility = "visible";
        document.getElementById('txtstatusdate').style.visibility = "visible";
        document.getElementById('Status').style.visibility = "visible";
        document.getElementById('StatusDate').style.visibility = "visible";
        if (todate17 != "") {
            var tdate = new Date(todate17);
            var cdate = new Date(currentdate1);
            if (cdate > tdate) {
                // document.getElementById('txtstatus1').value="Banned"
                document.getElementById('txtstatus1').value = "Active"
            }
            else {
                if (ds_exe.Tables[0].Rows[0].Cust_Status != null)
                    document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[0].Cust_Status;
                else
                    document.getElementById('txtstatus1').value = "Active"
            }
        }
        else {
            if (ds_exe.Tables[0].Rows[0].Cust_Status != null)
                document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[0].Cust_Status;
            else
                document.getElementById('txtstatus1').value = "Active"
        }
        z = 0;
        document.getElementById('drpclientcat').disabled = true;
        document.getElementById('txtcustcode').disabled = true;
        document.getElementById('txtcustomername').disabled = true;
        document.getElementById('txtalias').disabled = true;
        document.getElementById('txtadd1').disabled = true;
        document.getElementById('txtstreet').disabled = true;
        document.getElementById('drpcity').disabled = true;
        document.getElementById('txtdistrict').disabled = true;
        document.getElementById('txtcountry').disabled = true;
        document.getElementById('txtphone1').disabled = true;
        document.getElementById('txtphone2').disabled = true;
        document.getElementById('txtemailid').disabled = true;
        document.getElementById('txtUrl').disabled = true;
        document.getElementById('txtvts').disabled = true;
        document.getElementById('txtservicetax').disabled = true;
        document.getElementById('txtPan').disabled = true;
        document.getElementById('txtcreditdays').disabled = true;
        document.getElementById('txtcrlimit').disabled = true;
        document.getElementById('txtstatusreason').disabled = true;
        document.getElementById('txtstatus1').disabled = true;
        document.getElementById('txtalert').disabled = true;
        document.getElementById('txtpincode').disabled = true;
        document.getElementById('txtstate').disabled = true;
        document.getElementById('txtfax').disabled = true;
        document.getElementById('txtstatusdate').disabled = true;
        document.getElementById('drprategroup').disabled = true;
        document.getElementById('drpgstus').disabled = true;
        document.getElementById('txtgstdt').disabled = true;
        document.getElementById('txtgstin').disabled = true;
        document.getElementById('txtgstclty').disabled = true;
        document.getElementById('drpgstatus').disabled = true;
        document.getElementById('txtarno').disabled = true;
        document.getElementById('txtgstprovid').disabled = true;
        
        if (document.getElementById('hdnagencyclientflag').value == "Y") {
            document.getElementById('txtagencycode').disabled = true;
            //document.getElementById('txtagencycode').value = "";
        }
    }
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnlast').disabled = false;

    if (FlagStatus == 2 || FlagStatus == 3 || FlagStatus == 6) {
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;

    }
    if (FlagStatus == 4) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;

    }
    if (FlagStatus == 5) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;

    }
    if (FlagStatus == 6 || FlagStatus == 7) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnlast').disabled = false;

    }

    if (ds_exe.Tables[0].Rows.length == 1) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        //document.getElementById('btnExit').disabled=false;
        document.getElementById('btnprevious').disabled = true;

    }
    document.getElementById('txtcreditdays').disabled = true;
    setButtonImages();
    return false;

}


function clientaddcode1(response) {
    var ds = response.value;
    if (ds.Tables[1].Rows.length > 0 || ds.Tables[2].Rows.length > 0 || ds.Tables[0].Rows.length > 0) {
        document.getElementById('drpcity').value = ds.Tables[3].Rows[0].City_Name;
        document.getElementById('txtdistrict').value = ds.Tables[1].Rows[0].dist_name;
        document.getElementById('txtstate').value = ds.Tables[2].Rows[0].state_name;
        document.getElementById('txtcountry').value = ds.Tables[0].Rows[0].country_name;
        document.getElementById('txtdistrict').disabled = true;
        document.getElementById('txtstate').disabled = true;
        document.getElementById('txtcountry').disabled = true;
    }
    return false;
}
//************************************************firstbutton*********************************************//
//********************************************************************************************************//
var z;
function ClientFirst_client() {
    ClientMaster.blankSession();
    z = 0;
    var city = ds_exe.Tables[0].Rows[0].City_Code;
    document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[0].Cust_Code;
    document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[0].Cust_Name;
    document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[0].Cust_Alias;
    if (ds_exe.Tables[0].Rows[0].CLIENT_DESIGNATION != null) {
        document.getElementById('txtdesg').value = ds_exe.Tables[0].Rows[0].CLIENT_DESIGNATION;
    }
    else {

        document.getElementById('txtdesg').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].Stree != null) {
        document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[0].Stree;
    }
    else {
        document.getElementById('txtstreet').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].Zip != null) {
        document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[0].Zip;
    }
    else {
        document.getElementById('txtpincode').value = "";
    }

    if (ds_exe.Tables[0].Rows[0].Dist_Code != null) {
        document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[0].Dist_Code;
    }
    else {
        document.getElementById('txtdistrict').value = "";
    }

    if (ds_exe.Tables[0].Rows[0].State_Code != null) {
        document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[0].State_Code;
    }
    else {
        document.getElementById('txtstate').value = "";
    }
    document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[0].Country_Code;
    if (ds_exe.Tables[0].Rows[0].phone1 != null) {
        document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[0].phone1;
    }
    else {
        document.getElementById('txtphone1').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].Phone2 != null) {
        document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[0].Phone2;
    }
    else {
        document.getElementById('txtphone2').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].Fax != null) {
        document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[0].Fax;
    }
    else {
        document.getElementById('txtfax').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].No_of_VTS != null) {
        document.getElementById('txtvts').value = ds_exe.Tables[0].Rows[0].No_of_VTS;
    }
    else {
        document.getElementById('txtvts').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].EmailID != null) {
        document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[0].EmailID;
    }
    else {
        document.getElementById('txtemailid').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].URL != null) {
        document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[0].URL;
    }
    else {
        document.getElementById('txtUrl').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].ST_ACC_NO != null) {
        document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[0].ST_ACC_NO;
    }
    else {
        document.getElementById('txtservicetax').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].PAN_NO != null) {
        document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[0].PAN_NO;
    }
    else {
        document.getElementById('txtPan').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].Credit_Days != null && ds_exe.Tables[0].Rows[0].Credit_Days != 0) {
        document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[0].Credit_Days;
    }
    else {
        document.getElementById('txtcreditdays').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].Cust_Status != null) {
        document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[0].Cust_Status;
    }
    else {
        document.getElementById('txtstatus1').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].Status_Reason != null) {
        document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[0].Status_Reason;
    }
    else {
        document.getElementById('txtstatusreason').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].Remarks != null) {
        document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[0].Remarks;
    }
    else {
        document.getElementById('txtalert').value = "";
    }

    if (ds_exe.Tables[0].Rows[0].DISC_TY != null) {
        document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[0].DISC_TY;
    }
    else {
        document.getElementById('drpdiscount').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].DISC_AMT != null) {
        document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[0].DISC_AMT;
    }
    else {
        document.getElementById('txtamount').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY != null) {
        document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY;
    }
    else {
        document.getElementById('drpffdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT != null) {
        document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT;
    }
    else {
        document.getElementById('txtffdisc').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].CASH_DISC != null) {
        document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[0].CASH_DISC;
    }
    else {
        document.getElementById('drpcsdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].CASH_AMT != null) {
        document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[0].CASH_AMT;
    }
    else {
        document.getElementById('txtcsdisc').value = "";
    }
    
    
    document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[0].UserId;
    if (ds_exe.Tables[0].Rows[0].Add1 != null) {
        document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[0].Add1;
    }
    else {
        document.getElementById('txtadd1').value = "";
    }

    document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[0].Country_Code;
    cityvar = ds_exe.Tables[0].Rows[0].City_Code;
    addcount_client(ds_exe.Tables[0].Rows[0].City_Code);
    addregcity_client(cityvar);
    document.getElementById('drpzone').value = ds_exe.Tables[0].Rows[0].Zone_code;
    document.getElementById('drpregion').value = ds_exe.Tables[0].Rows[0].Region_code;
    if (ds_exe.Tables[0].Rows[0].TALUKA != null) {
        document.getElementById('drptaluka').value = ds_exe.Tables[0].Rows[0].TALUKA;
    }
    else {
        document.getElementById('drptaluka').value = "0";
    }
    if (ds_exe.Tables[0].Rows[0].Credit_limit != null) {
        document.getElementById('txtcrlimit').value = ds_exe.Tables[0].Rows[0].Credit_limit;
    }
    else {
        document.getElementById('txtcrlimit').value = "";
    }
    document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[0].Rate_Gr_Code;


    var dateformat = document.getElementById('hiddendateformat').value;
    //var currentdate=ds_exe.Tables[0].Rows[0].Creation_Datetime;

    var currentdate = new Date();
    var dd = currentdate.getDate();
    var mm = currentdate.getMonth() + 1;
    var yyyy = currentdate.getFullYear();
    //var enrolldate1=mm+'/'+dd+'/'+yyyy;

    if (dateformat == "yyyy/mm/dd") {
        var currentdate1 = yyyy + '/' + mm + '/' + dd;
    }
    else if (dateformat == "mm/dd/yyyy") {
        var currentdate1 = mm + '/' + dd + '/' + yyyy;
    }
    else if (dateformat == "dd/mm/yyyy") {
        var currentdate1 = dd + '/' + mm + '/' + yyyy;
    }
    else {
        var currentdate1 = mm + '/' + dd + '/' + yyyy;
    }


    if (todate1 != null) {
        var todate1 = ds_exe.Tables[0].Rows[0].to_date;
        var dd = todate1.getDate();
        var mm = todate1.getMonth() + 1;
        var yyyy = todate1.getFullYear();
        //var enrolldate1=mm+'/'+dd+'/'+yyyy;

        if (dateformat == "yyyy/mm/dd") {
            var todate11 = yyyy + '/' + mm + '/' + dd;
        }
        else if (dateformat == "mm/dd/yyyy") {
            var todate11 = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "dd/mm/yyyy") {
            var todate11 = dd + '/' + mm + '/' + yyyy;
        }
        else {
            var todate11 = mm + '/' + dd + '/' + yyyy;
        }
    }
    else
        todate1 = "";



    document.getElementById('txtstatusdate').value = currentdate1;
    if (ds_exe.Tables[0].Rows[0].Remarks != null) {
        document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[0].Remarks;
    }
    else {
        document.getElementById('txtalert').value = "";
    }

    if (ds_exe.Tables[0].Rows[0].DISC_TY != null) {
        document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[0].DISC_TY;
    }
    else {
        document.getElementById('drpdiscount').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].DISC_AMT != null) {
        document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[0].DISC_AMT;
    }
    else {
        document.getElementById('txtamount').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY != null) {
        document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY;
    }
    else {
        document.getElementById('drpffdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT != null) {
        document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT;
    }
    else {
        document.getElementById('txtffdisc').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].CASH_DISC != null) {
        document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[0].CASH_DISC;
    }
    else {
        document.getElementById('drpcsdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].CASH_AMT != null) {
        document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[0].CASH_AMT;
    }
    else {
        document.getElementById('txtcsdisc').value = "";
    }
    
    
    document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[0].UserId;
    if (ds_exe.Tables[0].Rows[0].Add1 != null) {
        document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[0].Add1;
    }
    else {
        document.getElementById('txtadd1').value = "";
    }


    if (ds_exe.Tables[0].Rows[0].CLIENT_TYPE != null) {
        document.getElementById('drpclinttype').value = ds_exe.Tables[0].Rows[0].CLIENT_TYPE;
    }
    else {
        document.getElementById('drpclinttype').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].QBC_AGENCY != null) {
        document.getElementById('txtagencycode').value = ds_exe.Tables[0].Rows[0].QBC_AGENCY;
    }
    else {
        document.getElementById('txtagencycode').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].TYPE != null) {
        document.getElementById('drptype').value = ds_exe.Tables[0].Rows[0].TYPE;
    }
    else {
        document.getElementById('drptype').value = "P";
    }
    if (ds_exe.Tables[0].Rows[0].TYPE == "C") {
        if (ds_exe.Tables[0].Rows[0].PARENT_CLIENT != null && ds_exe.Tables[0].Rows[0].PARENT_CLIENT != "") {
            nam = ds_exe.Tables[0].Rows[0].PARENT_CLIENT;
            document.getElementById('txtparent').value = getclintname(ds_exe.Tables[0].Rows[0].PARENT_CLIENT)
            document.getElementById("txtparent").style.display = "block";
            document.getElementById("lbparent").style.display = "block";
        }
    }
    else {
        document.getElementById('txtparent').value = "";
        document.getElementById("txtparent").style.display = "none";
        document.getElementById("lbparent").style.display = "none";
    }

    if (ds_exe.Tables[0].Rows[0].OLD_CLIENT_CODE != null) {
        document.getElementById('txtclientcode').value = ds_exe.Tables[0].Rows[0].OLD_CLIENT_CODE;
    }
    else {
        document.getElementById('txtclientcode').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].GST_REGISTRATION != null) {
        document.getElementById('drpgstus').value = ds_exe.Tables[0].Rows[0].GST_REGISTRATION;
    }
    else {
        document.getElementById('drpgstus').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].GST_REGISTRATION_DATE != null) {
        document.getElementById('txtgstdt').value = ds_exe.Tables[0].Rows[0].GST_REGISTRATION_DATE;
    }
    else {
        document.getElementById('txtgstdt').value = "";
    }
    if (ds_exe.Tables[0].Rows[0].GSTIN != null) {
        document.getElementById('txtgstin').value = ds_exe.Tables[0].Rows[0].GSTIN;
    }
    else {
        document.getElementById('txtgstin').value = "";
    }


    if (ds_exe.Tables[0].Rows[0].GST_STATUS != null) {
        document.getElementById('drpgstatus').value = ds_exe.Tables[0].Rows[0].GST_STATUS;
    }
    else {
        document.getElementById('drpgstatus').value = "";
    }

    if (ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD != null) {
        document.getElementById('txtgstclty').value = ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD;
        var citytyp = ClientMaster.fill_gst(document.getElementById('hiddencompcode').value, ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD);
        var ccty = citytyp.value.Tables[0].Rows[0].CLIENT_TYPE_NAME;
        document.getElementById('txtgstclty').value = ccty;
    }
    else {
        document.getElementById('txtgstclty').value = "";
    }

    if (ds_exe.Tables[0].Rows[0].GST_ARN_NO != null) {
        document.getElementById('txtarno').value = ds_exe.Tables[0].Rows[0].GST_ARN_NO;
    }
    else {
        document.getElementById('txtarno').value = "";
    }

    if (ds_exe.Tables[0].Rows[0].GST_PROVISINAL_ID != null) {
        document.getElementById('txtgstprovid').value = ds_exe.Tables[0].Rows[0].GST_PROVISINAL_ID;
    }
    else {
        document.getElementById('txtgstprovid').value = "";
    }

    document.getElementById('drpclientcat').value = ds_exe.Tables[0].Rows[0].Client_category;
    document.getElementById('txtstatus1').style.visibility = "visible";
    document.getElementById('txtstatusdate').style.visibility = "visible";
    document.getElementById('Status').style.visibility = "visible";
    document.getElementById('StatusDate').style.visibility = "visible";
    if (todate1 != "") {
        var tdate7 = new Date(todate11);
        var cdate = new Date(currentdate1);
        if (cdate > tdate7) {
            document.getElementById('txtstatus1').value = "Banned"
        }
        else {
            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[0].Cust_Status;
        }
    }
    else {
        if (ds_exe.Tables[0].Rows[0].Cust_Status != null)
            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[0].Cust_Status;
    }

    //Disabled Fields

    document.getElementById('txtcustcode').disabled = true;
    document.getElementById('txtcustomername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtUrl').disabled = true;
    document.getElementById('txtvts').disabled = true;
    document.getElementById('txtservicetax').disabled = true;
    document.getElementById('txtPan').disabled = true;
    document.getElementById('txtcreditdays').disabled = true;
    document.getElementById('txtcrlimit').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtalert').disabled = true;

    document.getElementById('drpdiscount').disabled = true;
    document.getElementById('txtamount').disabled = true;
    document.getElementById('drpffdis').disabled = true;
    document.getElementById('txtffdisc').disabled = true;
    document.getElementById('drpcsdis').disabled = true;
    document.getElementById('txtcsdisc').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('drprategroup').disabled = true;
    document.getElementById('drpgstus').disabled = true;
    document.getElementById('txtgstdt').disabled = true;
    document.getElementById('txtgstin').disabled = true;
   
        document.getElementById('drpgstatus').disabled=true;
   
        document.getElementById('txtgstclty').disabled = true;

       
            document.getElementById('txtarno').disabled = true;
        
            document.getElementById('txtgstprovid').disabled = true;
       
   
    if (document.getElementById('hdnagencyclientflag').value == "Y") {
        document.getElementById('txtagencycode').disabled = true;
       // document.getElementById('txtagencycode').value = "";
    }
    //ToolBar Disabled Status

    chkstatus(FlagStatus);
    if (FlagStatus == 2 || FlagStatus == 3 || FlagStatus == 6) {
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnModify').disabled = false;

    }
    if (FlagStatus == 4) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = true;

    }
    if (FlagStatus == 5) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = true;

    }
    if (FlagStatus == 6 || FlagStatus == 7) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = false;

    }

    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;

    document.getElementById('btnExit').disabled = false;
    setButtonImages();
    return false;

}
//************************************NextButton*******************************************************//
//**************************************************************************************************//
function ClientNext_client() {
    ClientMaster.blankSession();

    z++;
    //alert(z);
    //var ds= response.value;
    var y = ds_exe.Tables[0].Rows.length;

    if (z <= y && z != -1) {
        if (ds_exe.Tables[0].Rows.length != z && z >= 0) {
            var city = ds_exe.Tables[0].Rows[z].City_Code;

            document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[z].Cust_Code;
            document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[z].Cust_Name;
            document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[z].Cust_Alias;
            //document.getElementById('drpcity').value=ds_exe.Tables[0].Rows[z].City_Code;

            //Function  CallBack
            //	ClientMaster.addcity(city,clientaddcode1);

            if (ds_exe.Tables[0].Rows[z].CLIENT_DESIGNATION != null) {
                document.getElementById('txtdesg').value = ds_exe.Tables[0].Rows[z].CLIENT_DESIGNATION;
            } else {

                document.getElementById('txtdesg').value = "";
            }


            if (ds_exe.Tables[0].Rows[z].Stree != null) {
                document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[z].Stree;
            }
            else {
                document.getElementById('txtstreet').value = "";
            }
            //document.getElementById('txtcountry').value=ds_exe.Tables[0].Rows[z].country_code;
            if (ds_exe.Tables[0].Rows[z].Zip != null) {
                document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[z].Zip;
            }
            else {
                document.getElementById('txtpincode').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].Dist_Code != null) {
                document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[z].Dist_Code;
            }
            else {
                document.getElementById('txtdistrict').value = "";
            }

            document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[z].State_Code;
            document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[z].Country_Code;
            if (ds_exe.Tables[0].Rows[z].phone1 != null) {
                document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[z].phone1;
            }
            else {
                document.getElementById('txtphone1').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Phone2 != null) {
                document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[z].Phone2;
            }
            else {
                document.getElementById('txtphone2').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Fax != null) {
                document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[z].Fax;
            }
            else {
                document.getElementById('txtfax').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].No_of_VTS != null) {
                document.getElementById('txtvts').value = ds_exe.Tables[0].Rows[z].No_of_VTS;
            }
            else {
                document.getElementById('txtvts').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].EmailID != null) {
                document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[z].EmailID;
            }
            else {
                document.getElementById('txtemailid').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].URL != null) {
                document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[z].URL;
            }
            else {
                document.getElementById('txtUrl').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].ST_ACC_NO != null) {
                document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[z].ST_ACC_NO;
            }
            else {
                document.getElementById('txtservicetax').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].PAN_NO != null) {
                document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[z].PAN_NO;
            }
            else {
                document.getElementById('txtPan').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Credit_Days != null && ds_exe.Tables[0].Rows[z].Credit_Days != 0) {
                document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[z].Credit_Days;
            }
            else {
                document.getElementById('txtcreditdays').value = "";
            }
            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;

            if (ds_exe.Tables[0].Rows[z].Status_Reason != null) {
                document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[z].Status_Reason;
            }
            else {
                document.getElementById('txtstatusreason').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Remarks != null) {
                document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[z].Remarks;
            }
            else {
                document.getElementById('txtalert').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].DISC_TY != null) {
                document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[z].DISC_TY;
            }
            else {
                document.getElementById('drpdiscount').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].DISC_AMT != null) {
                document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[z].DISC_AMT;
            }
            else {
                document.getElementById('txtamount').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
                document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY;
            }
            else {
                document.getElementById('drpffdis').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
                document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT;
            }
            else {
                document.getElementById('txtffdisc').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].CASH_DISC != null) {
                document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[z].CASH_DISC;
            }
            else {
                document.getElementById('drpcsdis').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].CASH_AMT != null) {
                document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[z].CASH_AMT;
            }
            else {
                document.getElementById('txtcsdisc').value = "";
            }
            
            
            document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[z].UserId;
            if (ds_exe.Tables[0].Rows[z].Add1 != null) {
                document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[z].Add1;
            }
            else {
                document.getElementById('txtadd1').value = "";
            }

            document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[z].Country_Code;
            cityvar = ds_exe.Tables[0].Rows[z].City_Code;
            addcount_client(ds_exe.Tables[0].Rows[z].City_Code);
            addregcity_client(cityvar);
            document.getElementById('drpzone').value = ds_exe.Tables[0].Rows[z].Zone_code;
            document.getElementById('drpregion').value = ds_exe.Tables[0].Rows[z].Region_code;
            if (ds_exe.Tables[0].Rows[z].TALUKA != null) {
                document.getElementById('drptaluka').value = ds_exe.Tables[0].Rows[z].TALUKA;
            }
            else {
                document.getElementById('drptaluka').value = "0";
            }
            if (ds_exe.Tables[0].Rows[z].Credit_limit != null) {
                document.getElementById('txtcrlimit').value = ds_exe.Tables[0].Rows[z].Credit_limit;
            }
            else {
                document.getElementById('txtcrlimit').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Rate_Gr_Code != null) {
                document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[z].Rate_Gr_Code;
            }
            else {
                document.getElementById('drprategroup').value = "";
            }

            var dateformat = document.getElementById('hiddendateformat').value;
            //var currentdate=ds_exe.Tables[0].Rows[z].Creation_Datetime;
            var currentdate = new Date();
            var dd = currentdate.getDate();
            var mm = currentdate.getMonth() + 1;
            var yyyy = currentdate.getFullYear();
            //var enrolldate1=mm+'/'+dd+'/'+yyyy;

            if (dateformat == "yyyy/mm/dd") {
                var currentdate1 = yyyy + '/' + mm + '/' + dd;
            }
            else if (dateformat == "mm/dd/yyyy") {
                var currentdate1 = mm + '/' + dd + '/' + yyyy;
            }
            else if (dateformat == "dd/mm/yyyy") {
                var currentdate1 = dd + '/' + mm + '/' + yyyy;
            }
            else {
                var currentdate1 = mm + '/' + dd + '/' + yyyy;
            }



            var todate2 = ds_exe.Tables[0].Rows[z].to_date;
            var todate12 = "";
            if (todate2 != null) {
                var dd = todate2.getDate();
                var mm = todate2.getMonth() + 1;
                var yyyy = todate2.getFullYear();
                //var enrolldate1=mm+'/'+dd+'/'+yyyy;

                if (dateformat == "yyyy/mm/dd") {
                    todate12 = yyyy + '/' + mm + '/' + dd;
                }
                else if (dateformat == "mm/dd/yyyy") {
                    todate12 = mm + '/' + dd + '/' + yyyy;
                }
                else if (dateformat == "dd/mm/yyyy") {
                    todate12 = dd + '/' + mm + '/' + yyyy;
                }
                else {
                    todate12 = mm + '/' + dd + '/' + yyyy;
                }
            }




            document.getElementById('txtstatusdate').value = currentdate1;
            if (ds_exe.Tables[0].Rows[z].Remarks != null) {
                document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[z].Remarks;
            }
            else {
                document.getElementById('txtalert').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].DISC_TY != null) {
                document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[z].DISC_TY;
            }
            else {
                document.getElementById('drpdiscount').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].DISC_AMT != null) {
                document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[z].DISC_AMT;
            }
            else {
                document.getElementById('txtamount').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
                document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY;
            }
            else {
                document.getElementById('drpffdis').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
                document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT;
            }
            else {
                document.getElementById('txtffdisc').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].CASH_DISC != null) {
                document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[z].CASH_DISC;
            }
            else {
                document.getElementById('drpcsdis').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].CASH_AMT != null) {
                document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[z].CASH_AMT;
            }
            else {
                document.getElementById('txtcsdisc').value = "";
            }
            document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[z].UserId;
            if (ds_exe.Tables[0].Rows[z].Add1 != null) {
                document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[z].Add1;
            }
            else {
                document.getElementById('txtadd1').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].CLIENT_TYPE != null) {
                document.getElementById('drpclinttype').value = ds_exe.Tables[0].Rows[z].CLIENT_TYPE;
            }
            else {
                document.getElementById('drpclinttype').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].QBC_AGENCY != null) {
                document.getElementById('txtagencycode').value = ds_exe.Tables[0].Rows[z].QBC_AGENCY;
            }
            else {
                document.getElementById('txtagencycode').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].TYPE != null) {
                document.getElementById('drptype').value = ds_exe.Tables[0].Rows[z].TYPE;
            }
            else {
                document.getElementById('drptype').value = "P";
            }
            if (ds_exe.Tables[0].Rows[z].TYPE == "C") {
                if (ds_exe.Tables[0].Rows[z].PARENT_CLIENT != null && ds_exe.Tables[0].Rows[z].PARENT_CLIENT != "") {
                    nam = ds_exe.Tables[0].Rows[z].PARENT_CLIENT;
                    document.getElementById('txtparent').value = getclintname(ds_exe.Tables[0].Rows[z].PARENT_CLIENT)
                    document.getElementById("txtparent").style.display = "block";
                    document.getElementById("lbparent").style.display = "block";
                }
            }
            else {
                document.getElementById("txtparent").style.display = "none";
                document.getElementById("lbparent").style.display = "none";
                document.getElementById('txtparent').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].OLD_CLIENT_CODE != null) {
                document.getElementById('txtclientcode').value = ds_exe.Tables[0].Rows[z].OLD_CLIENT_CODE;
            }
            else {
                document.getElementById('txtclientcode').value = "";
            }

            document.getElementById('drpclientcat').value = ds_exe.Tables[0].Rows[z].Client_category;
            document.getElementById('txtstatus1').style.visibility = "visible";
            document.getElementById('txtstatusdate').style.visibility = "visible";
            document.getElementById('Status').style.visibility = "visible";
            document.getElementById('StatusDate').style.visibility = "visible";
            if (todate12 != "") {
                var tdate1 = new Date(todate12);
                var cdate = new Date(currentdate1);
                if (cdate > tdate1) {
                    document.getElementById('txtstatus1').value = "Banned"
                }
                else {
                    document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;
                }
            }
            else {
                if (ds_exe.Tables[0].Rows[z].Cust_Status != null)
                    document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;
            }

            if (ds_exe.Tables[0].Rows[z].GST_REGISTRATION != null) {
                document.getElementById('drpgstus').value = ds_exe.Tables[0].Rows[z].GST_REGISTRATION;
            }
            else {
                document.getElementById('drpgstus').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].GST_REGISTRATION_DATE != null) {
                document.getElementById('txtgstdt').value = ds_exe.Tables[0].Rows[z].GST_REGISTRATION_DATE;
            }
            else {
                document.getElementById('txtgstdt').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].GSTIN != null) {
                document.getElementById('txtgstin').value = ds_exe.Tables[0].Rows[z].GSTIN;
            }
            else {
                document.getElementById('txtgstin').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].GST_STATUS != null) {
                document.getElementById('drpgstatus').value = ds_exe.Tables[0].Rows[z].GST_STATUS;
            }
            else {
                document.getElementById('drpgstatus').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD != null) {
                document.getElementById('txtgstclty').value = ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD;
                var citytyp = ClientMaster.fill_gst(document.getElementById('hiddencompcode').value, ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD);
                var ccty = citytyp.value.Tables[0].Rows[0].CLIENT_TYPE_NAME;
                document.getElementById('txtgstclty').value = ccty;
            }
            else {
                document.getElementById('txtgstclty').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].GST_ARN_NO != null) {
                document.getElementById('txtarno').value = ds_exe.Tables[0].Rows[z].GST_ARN_NO;
            }
            else {
                document.getElementById('txtarno').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].GST_PROVISINAL_ID != null) {
                document.getElementById('txtgstprovid').value = ds_exe.Tables[0].Rows[z].GST_PROVISINAL_ID;
            }
            else {
                document.getElementById('txtgstprovid').value = "";
            }
            //Disabled Fields

            document.getElementById('txtcustcode').disabled = true;
            document.getElementById('txtcustomername').disabled = true;
            document.getElementById('txtalias').disabled = true;
            document.getElementById('txtadd1').disabled = true;
            document.getElementById('txtstreet').disabled = true;
            document.getElementById('drpcity').disabled = true;
            document.getElementById('txtdistrict').disabled = true;
            document.getElementById('txtcountry').disabled = true;
            document.getElementById('txtphone1').disabled = true;
            document.getElementById('txtphone2').disabled = true;
            document.getElementById('txtemailid').disabled = true;
            document.getElementById('txtUrl').disabled = true;
            document.getElementById('txtvts').disabled = true;
            document.getElementById('txtservicetax').disabled = true;
            document.getElementById('txtPan').disabled = true;
            document.getElementById('txtcreditdays').disabled = true;
            document.getElementById('txtcrlimit').disabled = true;
            document.getElementById('txtstatusreason').disabled = true;
            document.getElementById('txtstatus1').disabled = true;
            document.getElementById('txtalert').disabled = true;
            document.getElementById('drpdiscount').disabled = true;
            document.getElementById('txtamount').disabled = true;
            document.getElementById('drpffdis').disabled = true;
            document.getElementById('txtffdisc').disabled = true;
            document.getElementById('drpcsdis').disabled = true;
            document.getElementById('txtcsdisc').disabled = true;
            
            document.getElementById('txtpincode').disabled = true;
            document.getElementById('txtstate').disabled = true;
            document.getElementById('txtfax').disabled = true;
            document.getElementById('txtstatusdate').disabled = true;
            document.getElementById('drprategroup').disabled = true;
            document.getElementById('drpgstus').disabled = true;
            document.getElementById('txtgstdt').disabled = true;
            document.getElementById('txtgstin').disabled = true;
            
                document.getElementById('drpgstatus').disabled =true;
           
                document.getElementById('txtgstclty').disabled = true;

               
                    document.getElementById('txtarno').disabled = true;
           
                    document.getElementById('txtgstprovid').disabled = true;
                
           
            if (document.getElementById('hdnagencyclientflag').value == "Y") {
                document.getElementById('txtagencycode').disabled = true;
               // document.getElementById('txtagencycode').value = "";
            }
            //ToolBar Disabled Status

            chkstatus(FlagStatus);
            if (FlagStatus == 2 || FlagStatus == 3 || FlagStatus == 6) {
                document.getElementById('btnQuery').disabled = false;
                document.getElementById('btnExecute').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnModify').disabled = false;

            }
            if (FlagStatus == 4) {
                document.getElementById('btnDelete').disabled = false;
                document.getElementById('btnExecute').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnQuery').disabled = false;
                document.getElementById('btnModify').disabled = true;

            }
            if (FlagStatus == 5) {
                document.getElementById('btnDelete').disabled = false;
                document.getElementById('btnExecute').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnQuery').disabled = false;
                document.getElementById('btnModify').disabled = true;

            }
            if (FlagStatus == 6 || FlagStatus == 7) {
                document.getElementById('btnDelete').disabled = false;
                document.getElementById('btnExecute').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnQuery').disabled = false;
                document.getElementById('btnModify').disabled = false;

            }


            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnnext').disabled = false;


            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnlast').disabled = false;

            document.getElementById('btnExit').disabled = false;

        }
        else {
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            setButtonImages();
            return false;

        }
    }
    else {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        setButtonImages();
        return false;

    }
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    if (z == y - 1) {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
    }
    setButtonImages();
    return false;
}


//Previous Record Fetching Function

//**********************************************************************************************************//
//******************************************PreviousButton*************************************************//

function ClientPrevious_client() {
    ClientMaster.blankSession();
    z--;
    var y = ds_exe.Tables[0].Rows.length;

    if (z > y) {
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        return false;
    }

    if (z != -1) {

        if (z >= 0 && z <= y - 1) {
            var city = ds_exe.Tables[0].Rows[z].City_Code;
            document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[z].Cust_Code;
            document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[z].Cust_Name;
            document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[z].Cust_Alias;

            if (ds_exe.Tables[0].Rows[z].CLIENT_DESIGNATION != null) {
                document.getElementById('txtdesg').value = ds_exe.Tables[0].Rows[z].CLIENT_DESIGNATION;
            }
            else {

                document.getElementById('txtdesg').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].Stree != null) {
                document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[z].Stree;
            }
            else {
                document.getElementById('txtstreet').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Zip != null) {
                document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[z].Zip;
            }
            else {
                document.getElementById('txtpincode').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].Dist_Code != null) {
                document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[z].Dist_Code;
            }
            else {
                document.getElementById('txtdistrict').value = "";
            }
            document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[z].State_Code;
            document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[z].Country_Code;
            if (ds_exe.Tables[0].Rows[z].phone1 != null) {
                document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[z].phone1;
            }
            else {
                document.getElementById('txtphone1').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Phone2 != null) {
                document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[z].Phone2;
            }
            else {
                document.getElementById('txtphone2').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Fax1 = null) {
                document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[z].Fax;
            }
            else {
                document.getElementById('txtfax').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].No_of_VTS != null) {
                document.getElementById('txtvts').value = ds_exe.Tables[0].Rows[z].No_of_VTS;
            }
            else {
                document.getElementById('txtvts').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].EmailID != null) {
                document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[z].EmailID;
            }
            else {
                document.getElementById('txtemailid').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].URL != null) {
                document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[z].URL;
            }
            else {
                document.getElementById('txtUrl').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].ST_ACC_NO != null) {
                document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[z].ST_ACC_NO;
            }
            else {
                document.getElementById('txtservicetax').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].PAN_NO != null) {
                document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[z].PAN_NO;
            }
            else {
                document.getElementById('txtPan').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Credit_Days != null && ds_exe.Tables[0].Rows[z].Credit_Days != 0) {
                document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[z].Credit_Days;
            }
            else {
                document.getElementById('txtcreditdays').value = "";
            }
            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;

            if (ds_exe.Tables[0].Rows[z].Status_Reason != null) {
                document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[z].Status_Reason;
            }
            else {
                document.getElementById('txtstatusreason').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Remarks != null) {
                document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[z].Remarks;
            }
            else {
                document.getElementById('txtalert').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].DISC_TY != null) {
                document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[z].DISC_TY;
            }
            else {
                document.getElementById('drpdiscount').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].DISC_AMT != null) {
                document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[z].DISC_AMT;
            }
            else {
                document.getElementById('txtamount').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
                document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY;
            }
            else {
                document.getElementById('drpffdis').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
                document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT;
            }
            else {
                document.getElementById('txtffdisc').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].CASH_DISC != null) {
                document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[z].CASH_DISC;
            }
            else {
                document.getElementById('drpcsdis').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].CASH_AMT != null) {
                document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[z].CASH_AMT;
            }
            else {
                document.getElementById('txtcsdisc').value = "";
            }
            
            
            document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[z].UserId;
            if (ds_exe.Tables[0].Rows[z].Add1 != null) {
                document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[z].Add1;
            }
            else {
                document.getElementById('txtadd1').value = "";
            }

            document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[z].Country_Code;
            cityvar = ds_exe.Tables[0].Rows[z].City_Code;
            addcount_client(ds_exe.Tables[0].Rows[z].City_Code);
            addregcity_client(cityvar);
            document.getElementById('drpzone').value = ds_exe.Tables[0].Rows[z].Zone_code;
            document.getElementById('drpregion').value = ds_exe.Tables[0].Rows[z].Region_code;
            if (ds_exe.Tables[0].Rows[z].TALUKA != null) {
                document.getElementById('drptaluka').value = ds_exe.Tables[0].Rows[z].TALUKA;
            }
            else {
                document.getElementById('drptaluka').value = "0";
            }
            if (ds_exe.Tables[0].Rows[z].Credit_limit != null) {
                document.getElementById('txtcrlimit').value = ds_exe.Tables[0].Rows[z].Credit_limit;
            }
            else {
                document.getElementById('txtcrlimit').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].Rate_Gr_Code != null) {
                document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[z].Rate_Gr_Code;
            }
            else {
                document.getElementById('drprategroup').value = "";
            }

            var dateformat = document.getElementById('hiddendateformat').value;
            var currentdate = new Date();
            var dd = currentdate.getDate();
            var mm = currentdate.getMonth() + 1;
            var yyyy = currentdate.getFullYear();
            if (dateformat == "yyyy/mm/dd") {
                var currentdate1 = yyyy + '/' + mm + '/' + dd;
            }
            else if (dateformat == "mm/dd/yyyy") {
                var currentdate1 = mm + '/' + dd + '/' + yyyy;
            }
            else if (dateformat == "dd/mm/yyyy") {
                var currentdate1 = dd + '/' + mm + '/' + yyyy;
            }
            else {
                var currentdate1 = mm + '/' + dd + '/' + yyyy;
            }
            var todate3 = ds_exe.Tables[0].Rows[z].to_date;
            var todate13 = "";
            if (todate3 != null) {
                var dd = todate3.getDate();
                var mm = todate3.getMonth() + 1;
                var yyyy = todate3.getFullYear();
                if (dateformat == "yyyy/mm/dd") {
                    todate13 = yyyy + '/' + mm + '/' + dd;
                }
                else if (dateformat == "mm/dd/yyyy") {
                    todate13 = mm + '/' + dd + '/' + yyyy;
                }
                else if (dateformat == "dd/mm/yyyy") {
                    todate13 = dd + '/' + mm + '/' + yyyy;
                }
                else {
                    todate13 = mm + '/' + dd + '/' + yyyy;
                }
            }
            document.getElementById('txtstatusdate').value = currentdate1;
            if (ds_exe.Tables[0].Rows[z].Remarks != null) {
                document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[z].Remarks;
            }
            else {
                document.getElementById('txtalert').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].DISC_TY != null) {
                document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[z].DISC_TY;
            }
            else {
                document.getElementById('drpdiscount').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].DISC_AMT != null) {
                document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[z].DISC_AMT;
            }
            else {
                document.getElementById('txtamount').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
                document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY;
            }
            else {
                document.getElementById('drpffdis').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
                document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT;
            }
            else {
                document.getElementById('txtffdisc').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].CASH_DISC != null) {
                document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[z].CASH_DISC;
            }
            else {
                document.getElementById('drpcsdis').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].CASH_AMT != null) {
                document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[z].CASH_AMT;
            }
            else {
                document.getElementById('txtcsdisc').value = "";
            }
            
            
            document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[z].UserId;
            if (ds_exe.Tables[0].Rows[z].Add1 != null) {
                document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[z].Add1;
            }
            else {
                document.getElementById('txtadd1').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].CLIENT_TYPE != null) {
                document.getElementById('drpclinttype').value = ds_exe.Tables[0].Rows[z].CLIENT_TYPE;
            }
            else {
                document.getElementById('drpclinttype').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].QBC_AGENCY != null) {
                document.getElementById('txtagencycode').value = ds_exe.Tables[0].Rows[z].QBC_AGENCY;
            }
            else {
                document.getElementById('txtagencycode').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].TYPE != null) {
                document.getElementById('drptype').value = ds_exe.Tables[0].Rows[z].TYPE;
            }
            else {
                document.getElementById('drptype').value = "P";
            }
            if (ds_exe.Tables[0].Rows[z].TYPE == "C") {
                if (ds_exe.Tables[0].Rows[z].PARENT_CLIENT != null && ds_exe.Tables[0].Rows[z].PARENT_CLIENT != "") {
                    nam = ds_exe.Tables[0].Rows[z].PARENT_CLIENT;
                    document.getElementById("txtparent").style.display = "block";
                    document.getElementById("lbparent").style.display = "block";
                    document.getElementById('txtparent').value = getclintname(ds_exe.Tables[0].Rows[z].PARENT_CLIENT)
                }
            }
            else {
                document.getElementById("txtparent").style.display = "none";
                document.getElementById("lbparent").style.display = "none";
                document.getElementById('txtparent').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].OLD_CLIENT_CODE != null) {
                document.getElementById('txtclientcode').value = ds_exe.Tables[0].Rows[z].OLD_CLIENT_CODE;
            }
            else {
                document.getElementById('txtclientcode').value = "";
            }

            document.getElementById('drpclientcat').value = ds_exe.Tables[0].Rows[z].Client_category;
            document.getElementById('txtstatus1').style.visibility = "visible";
            document.getElementById('txtstatusdate').style.visibility = "visible";
            document.getElementById('Status').style.visibility = "visible";
            document.getElementById('StatusDate').style.visibility = "visible";
            if (todate13 != "") {
                var tdate2 = new Date(todate13);
                var cdate = new Date(currentdate1);
                if (cdate > tdate2) {
                    document.getElementById('txtstatus1').value = "Banned"
                }
                else {
                    document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;
                }
            }
            else {
                if (ds_exe.Tables[0].Rows[z].Cust_Status != null)
                    document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;
            }

            if (ds_exe.Tables[0].Rows[z].GST_REGISTRATION != null) {
                document.getElementById('drpgstus').value = ds_exe.Tables[0].Rows[z].GST_REGISTRATION;
            }
            else {
                document.getElementById('drpgstus').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].GST_REGISTRATION_DATE != null) {
                document.getElementById('txtgstdt').value = ds_exe.Tables[0].Rows[z].GST_REGISTRATION_DATE;
            }
            else {
                document.getElementById('txtgstdt').value = "";
            }
            if (ds_exe.Tables[0].Rows[z].GSTIN != null) {
                document.getElementById('txtgstin').value = ds_exe.Tables[0].Rows[z].GSTIN;
            }
            else {
                document.getElementById('txtgstin').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].GST_STATUS != null) {
                document.getElementById('drpgstatus').value = ds_exe.Tables[0].Rows[z].GST_STATUS;
            }
            else {
                document.getElementById('drpgstatus').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD != null) {
                document.getElementById('hdngstclty').value = ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD;//txtgstclty
                var citytyp = ClientMaster.fill_gst(document.getElementById('hiddencompcode').value, ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD);
                var ccty = citytyp.value.Tables[0].Rows[0].CLIENT_TYPE_NAME;
                document.getElementById('txtgstclty').value = ccty;
            }
            else {
                document.getElementById('txtgstclty').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].GST_ARN_NO != null) {
                document.getElementById('txtarno').value = ds_exe.Tables[0].Rows[z].GST_ARN_NO;
            }
            else {
                document.getElementById('txtarno').value = "";
            }

            if (ds_exe.Tables[0].Rows[z].GST_PROVISINAL_ID != null) {
                document.getElementById('txtgstprovid').value = ds_exe.Tables[0].Rows[z].GST_PROVISINAL_ID;
            }
            else {
                document.getElementById('txtgstprovid').value = "";
            }
            //Disabled Fields

            document.getElementById('txtcustcode').disabled = true;
            document.getElementById('txtcustomername').disabled = true;
            document.getElementById('txtalias').disabled = true;
            document.getElementById('txtadd1').disabled = true;
            document.getElementById('txtstreet').disabled = true;
            document.getElementById('drpcity').disabled = true;
            document.getElementById('txtdistrict').disabled = true;
            document.getElementById('txtcountry').disabled = true;
            document.getElementById('txtphone1').disabled = true;
            document.getElementById('txtphone2').disabled = true;
            document.getElementById('txtemailid').disabled = true;
            document.getElementById('txtUrl').disabled = true;
            document.getElementById('txtvts').disabled = true;
            document.getElementById('txtservicetax').disabled = true;
            document.getElementById('txtPan').disabled = true;
            document.getElementById('txtcreditdays').disabled = true;
            document.getElementById('txtcrlimit').disabled = true;
            document.getElementById('txtstatusreason').disabled = true;
            document.getElementById('txtstatus1').disabled = true;
            document.getElementById('txtalert').disabled = true;
            document.getElementById('drpdiscount').disabled = true;
            document.getElementById('txtamount').disabled = true;
            document.getElementById('drpffdis').disabled = true;
            document.getElementById('txtffdisc').disabled = true;
            document.getElementById('drpcsdis').disabled = true;
            document.getElementById('txtcsdisc').disabled = true;
            
            document.getElementById('txtpincode').disabled = true;
            document.getElementById('txtstate').disabled = true;
            document.getElementById('txtfax').disabled = true;
            document.getElementById('txtstatusdate').disabled = true;
            document.getElementById('drprategroup').disabled = true;
            document.getElementById('drpgstus').disabled = true;
            document.getElementById('txtgstdt').disabled = true;
            document.getElementById('txtgstin').disabled = true;
            
                document.getElementById('drpgstatus').disabled = true;
         
                document.getElementById('txtgstclty').disabled = true;
                
                    document.getElementById('txtarno').disabled = true;
               
                    document.getElementById('txtgstprovid').disabled = true;
                
            
            //ToolBar Disabled Status
            if (document.getElementById('hdnagencyclientflag').value == "Y") {
                document.getElementById('txtagencycode').disabled = true;
              //  document.getElementById('txtagencycode').value = "";
            }
            chkstatus(FlagStatus);
            if (FlagStatus == 2 || FlagStatus == 3 || FlagStatus == 6) {
                document.getElementById('btnQuery').disabled = false;
                document.getElementById('btnExecute').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnModify').disabled = false;

            }
            if (FlagStatus == 4) {
                document.getElementById('btnDelete').disabled = false;
                document.getElementById('btnExecute').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnQuery').disabled = false;
                document.getElementById('btnModify').disabled = true;

            }
            if (FlagStatus == 5) {
                document.getElementById('btnDelete').disabled = false;
                document.getElementById('btnExecute').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnQuery').disabled = false;
                document.getElementById('btnModify').disabled = true;

            }
            if (FlagStatus == 6 || FlagStatus == 7) {
                document.getElementById('btnDelete').disabled = false;
                document.getElementById('btnExecute').disabled = true;
                document.getElementById('btnSave').disabled = true;
                document.getElementById('btnQuery').disabled = false;
                document.getElementById('btnModify').disabled = false;

            }


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
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    if (z <= 0) {
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        setButtonImages();
        return false;

    }
    setButtonImages();
    return false;

}



//Last Record Fetching Function
//**********************************************************************************************************//
//*******************************************LastButton****************************************************//
function ClientLast_client() {
    ClientMaster.blankSession();
    var y = ds_exe.Tables[0].Rows.length;
    z = y - 1;
    y = y - 1;
    var city = ds_exe.Tables[0].Rows[y].City_Code;
    document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[y].Cust_Code;
    document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[y].Cust_Name;
    document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[y].Cust_Alias;
    if (ds_exe.Tables[0].Rows[y].CLIENT_DESIGNATION != null) {
        document.getElementById('txtdesg').value = ds_exe.Tables[0].Rows[y].CLIENT_DESIGNATION;
    }

    else {

        document.getElementById('txtdesg').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Stree != null) {
        document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[y].Stree;
    }
    else {
        document.getElementById('txtstreet').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Zip != null) {
        document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[y].Zip;
    }
    else {
        document.getElementById('txtpincode').value = "";
    }

    if (ds_exe.Tables[0].Rows[y].Dist_Code != null) {
        document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[y].Dist_Code;
    }
    else {
        document.getElementById('txtdistrict').value = "";
    }
    //document.getElementById('txtdistrict').value=ds_exe.Tables[0].Rows[y].Dist_Code;
    document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[y].State_Code;
    if (ds_exe.Tables[0].Rows[y].phone1 != null) {
        document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[y].phone1;
    }
    else {
        document.getElementById('txtphone1').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Phone2 != null) {
        document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[y].Phone2;
    }
    else {
        document.getElementById('txtphone2').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Fax != null) {
        document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[y].Fax;
    }
    else {
        document.getElementById('txtfax').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].No_of_VTS != null) {
        document.getElementById('txtvts').value = ds_exe.Tables[0].Rows[y].No_of_VTS;
    }
    else {
        document.getElementById('txtvts').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].EmailID != null) {
        document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[y].EmailID;
    }
    else {
        document.getElementById('txtemailid').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].URL != null) {
        document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[y].URL;
    }
    else {
        document.getElementById('txtUrl').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].ST_ACC_NO != null) {
        document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[y].ST_ACC_NO;
    }
    else {
        document.getElementById('txtservicetax').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].PAN_NO != null) {
        document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[y].PAN_NO;
    }
    else {
        document.getElementById('txtPan').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Credit_Days != null && ds_exe.Tables[0].Rows[y].Credit_Days != 0) {
        document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[y].Credit_Days;
    }
    else {
        document.getElementById('txtcreditdays').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Cust_Status != null) {
        document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[y].Cust_Status;
    }
    else {
        document.getElementById('txtstatus1').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Status_Reason != null) {
        document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[y].Status_Reason;
    }
    else {
        document.getElementById('txtstatusreason').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Remarks != null) {
        document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[y].Remarks;
    }
    else {
        document.getElementById('txtalert').value = "";
    }


    if (ds_exe.Tables[0].Rows[y].DISC_TY != null) {
        document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[y].DISC_TY;
    }
    else {
        document.getElementById('drpdiscount').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].DISC_AMT != null) {
        document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[y].DISC_AMT;
    }
    else {
        document.getElementById('txtamount').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].F_FREQ_DISC_TY != null) {
        document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[y].F_FREQ_DISC_TY;
    }
    else {
        document.getElementById('drpffdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].F_FREQ_DISC_AMT != null) {
        document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[y].F_FREQ_DISC_AMT;
    }
    else {
        document.getElementById('txtffdisc').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].CASH_DISC != null) {
        document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[y].CASH_DISC;
    }
    else {
        document.getElementById('drpcsdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].CASH_AMT != null) {
        document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[y].CASH_AMT;
    }
    else {
        document.getElementById('txtcsdisc').value = "";
    }
    
    
    document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[y].UserId;
    if (ds_exe.Tables[0].Rows[y].Add1 != null) {
        document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[y].Add1;
    }
    else {
        document.getElementById('txtadd1').value = "";
    }


    document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[y].Country_Code;
    cityvar = ds_exe.Tables[0].Rows[y].City_Code;
    addcount_client(ds_exe.Tables[0].Rows[y].City_Code);
    addregcity_client(cityvar);
    document.getElementById('drpzone').value = ds_exe.Tables[0].Rows[y].Zone_code;
    document.getElementById('drpregion').value = ds_exe.Tables[0].Rows[y].Region_code;
    if (ds_exe.Tables[0].Rows[y].TALUKA != null) {
        document.getElementById('drptaluka').value = ds_exe.Tables[0].Rows[y].TALUKA;
    }
    else {
        document.getElementById('drptaluka').value = "0";
    }
    if (ds_exe.Tables[0].Rows[y].Credit_limit != null) {
        document.getElementById('txtcrlimit').value = ds_exe.Tables[0].Rows[y].Credit_limit;
    }
    else {
        document.getElementById('txtcrlimit').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].Rate_Gr_Code != null) {
        document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[y].Rate_Gr_Code;
    }
    else {
        document.getElementById('drprategroup').value = "";
    }

    var dateformat = document.getElementById('hiddendateformat').value;
    //var currentdate=ds_exe.Tables[0].Rows[y].Creation_Datetime;
    var currentdate = new Date();
    var dd = currentdate.getDate();
    var mm = currentdate.getMonth() + 1;
    var yyyy = currentdate.getFullYear();
    //var enrolldate1=mm+'/'+dd+'/'+yyyy;

    if (dateformat == "yyyy/mm/dd") {
        var currentdate1 = yyyy + '/' + mm + '/' + dd;
    }
    else if (dateformat == "mm/dd/yyyy") {
        var currentdate1 = mm + '/' + dd + '/' + yyyy;
    }
    else if (dateformat == "dd/mm/yyyy") {
        var currentdate1 = dd + '/' + mm + '/' + yyyy;
    }
    else {
        var currentdate1 = mm + '/' + dd + '/' + yyyy;
    }



    var todate4 = ds_exe.Tables[0].Rows[y].to_date;
    var todate14 = "";
    if (todate4 != null) {
        var dd = todate4.getDate();
        var mm = todate4.getMonth() + 1;
        var yyyy = todate4.getFullYear();
        //var enrolldate1=mm+'/'+dd+'/'+yyyy;

        if (dateformat == "yyyy/mm/dd") {
            todate14 = yyyy + '/' + mm + '/' + dd;
        }
        else if (dateformat == "mm/dd/yyyy") {
            todate14 = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "dd/mm/yyyy") {
            todate14 = dd + '/' + mm + '/' + yyyy;
        }
        else {
            todate14 = mm + '/' + dd + '/' + yyyy;
        }
    }




    document.getElementById('txtstatusdate').value = currentdate1;
    if (ds_exe.Tables[0].Rows[y].Remarks != null) {
        document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[y].Remarks;
    }
    else {
        document.getElementById('txtalert').value = "";
    }

    if (ds_exe.Tables[0].Rows[y].DISC_TY != null) {
        document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[y].DISC_TY;
    }
    else {
        document.getElementById('drpdiscount').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].DISC_AMT != null) {
        document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[y].DISC_AMT;
    }
    else {
        document.getElementById('txtamount').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].F_FREQ_DISC_TY != null) {
        document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[y].F_FREQ_DISC_TY;
    }
    else {
        document.getElementById('drpffdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].F_FREQ_DISC_AMT != null) {
        document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[y].F_FREQ_DISC_AMT;
    }
    else {
        document.getElementById('txtffdisc').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].CASH_DISC != null) {
        document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[y].CASH_DISC;
    }
    else {
        document.getElementById('drpcsdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].CASH_AMT != null) {
        document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[y].CASH_AMT;
    }
    else {
        document.getElementById('txtcsdisc').value = "";
    }
    
    
    
    document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[y].UserId;

    if (ds_exe.Tables[0].Rows[y].Add1 != null) {
        document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[y].Add1;
    }
    else {
        document.getElementById('txtadd1').value = "";
    }

    if (ds_exe.Tables[0].Rows[y].CLIENT_TYPE != null) {
        document.getElementById('drpclinttype').value = ds_exe.Tables[0].Rows[y].CLIENT_TYPE;
    }
    else {
        document.getElementById('drpclinttype').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].QBC_AGENCY != null) {
        document.getElementById('txtagencycode').value = ds_exe.Tables[0].Rows[y].QBC_AGENCY;
    }
    else {
        document.getElementById('txtagencycode').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].TYPE != null) {
        document.getElementById('drptype').value = ds_exe.Tables[0].Rows[y].TYPE;
    }
    else {
        document.getElementById('drptype').value = "P";
    }
    if (ds_exe.Tables[0].Rows[y].TYPE == "C") {
        if (ds_exe.Tables[0].Rows[y].PARENT_CLIENT != null && ds_exe.Tables[0].Rows[y].PARENT_CLIENT != "") {
            nam = ds_exe.Tables[0].Rows[y].PARENT_CLIENT;
            document.getElementById('txtparent').value = getclintname(ds_exe.Tables[0].Rows[y].PARENT_CLIENT)
            document.getElementById("txtparent").style.display = "block";
            document.getElementById("lbparent").style.display = "block";
        }
    }
    else {
        document.getElementById('txtparent').value = "";
        document.getElementById("txtparent").style.display = "none";
        document.getElementById("lbparent").style.display = "none";
    }

    if (ds_exe.Tables[0].Rows[y].OLD_CLIENT_CODE != null) {
        document.getElementById('txtclientcode').value = ds_exe.Tables[0].Rows[y].OLD_CLIENT_CODE;
    }
    else {
        document.getElementById('txtclientcode').value = "";
    }

    document.getElementById('drpclientcat').value = ds_exe.Tables[0].Rows[y].Client_category;
    document.getElementById('txtstatus1').style.visibility = "visible";
    document.getElementById('txtstatusdate').style.visibility = "visible";
    document.getElementById('Status').style.visibility = "visible";
    document.getElementById('StatusDate').style.visibility = "visible";
    if (todate14 != "") {
        var tdate3 = new Date(todate14);
        var cdate = new Date(currentdate1);
        if (cdate > tdate3) {
            document.getElementById('txtstatus1').value = "Banned"
        }
        else {
            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[y].Cust_Status;
        }
    }

    if (ds_exe.Tables[0].Rows[y].GST_REGISTRATION != null) {
        document.getElementById('drpgstus').value = ds_exe.Tables[0].Rows[y].GST_REGISTRATION;
    }
    else {
        document.getElementById('drpgstus').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].GST_REGISTRATION_DATE != null) {
        document.getElementById('txtgstdt').value = ds_exe.Tables[0].Rows[y].GST_REGISTRATION_DATE;
    }
    else {
        document.getElementById('txtgstdt').value = "";
    }
    if (ds_exe.Tables[0].Rows[y].GSTIN != null) {
        document.getElementById('txtgstin').value = ds_exe.Tables[0].Rows[y].GSTIN;
    }
    else {
        document.getElementById('txtgstin').value = "";
    }

    if (ds_exe.Tables[0].Rows[y].GST_STATUS != null) {
        document.getElementById('drpgstatus').value = ds_exe.Tables[0].Rows[y].GST_STATUS;
    }
    else {
        document.getElementById('drpgstatus').value = "";
    }

    if (ds_exe.Tables[0].Rows[y].GST_CLIENT_TYPE_CD != null) {
        document.getElementById('txtgstclty').value = ds_exe.Tables[0].Rows[y].GST_CLIENT_TYPE_CD;
        var citytyp = ClientMaster.fill_gst(document.getElementById('hiddencompcode').value, ds_exe.Tables[0].Rows[y].GST_CLIENT_TYPE_CD);
        var ccty = citytyp.value.Tables[0].Rows[0].CLIENT_TYPE_NAME;
        document.getElementById('txtgstclty').value = ccty;
    }
    else {
        document.getElementById('txtgstclty').value = "";
    }

    if (ds_exe.Tables[0].Rows[y].GST_ARN_NO != null) {
        document.getElementById('txtarno').value = ds_exe.Tables[0].Rows[y].GST_ARN_NO;
    }
    else {
        document.getElementById('txtarno').value = "";
    }

    if (ds_exe.Tables[0].Rows[y].GST_PROVISINAL_ID != null) {
        document.getElementById('txtgstprovid').value = ds_exe.Tables[0].Rows[y].GST_PROVISINAL_ID;
    }
    else {
        document.getElementById('txtgstprovid').value = "";
    }

    //Disabled Fields

    document.getElementById('txtcustcode').disabled = true;
    document.getElementById('txtcustomername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtUrl').disabled = true;
    document.getElementById('txtvts').disabled = true;
    document.getElementById('txtservicetax').disabled = true;
    document.getElementById('txtPan').disabled = true;
    document.getElementById('txtcreditdays').disabled = true;
    document.getElementById('txtcrlimit').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtalert').disabled = true;
    document.getElementById('drpdiscount').disabled = true;
    document.getElementById('txtamount').disabled = true;
    document.getElementById('drpffdis').disabled = true;
    document.getElementById('txtffdisc').disabled = true;
    document.getElementById('drpcsdis').disabled = true;
    document.getElementById('txtcsdisc').disabled = true;	
    
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('drprategroup').disabled = true;
    document.getElementById('txtgstin').disabled = true;
    document.getElementById('txtgstdt').disabled = true;
    document.getElementById('drpgstus').disabled = true;
    document.getElementById('drpgstatus').disabled = true;
    document.getElementById('txtgstclty').disabled = true;
    document.getElementById('txtarno').disabled = true;
    document.getElementById('txtgstprovid').disabled = true;
    
    
    if (document.getElementById('hdnagencyclientflag').value == "Y") {
        document.getElementById('txtagencycode').disabled = true;
       // document.getElementById('txtagencycode').value = "";
    }
    //ToolBar Disabled Status
    chkstatus(FlagStatus);
    if (FlagStatus == 2 || FlagStatus == 3 || FlagStatus == 6) {
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnModify').disabled = false;

    }
    if (FlagStatus == 4) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = true;

    }
    if (FlagStatus == 5) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = true;

    }
    if (FlagStatus == 6 || FlagStatus == 7) {
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnModify').disabled = false;

    }
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnprevious').disabled = false;
    document.getElementById('btnlast').disabled = true;

    document.getElementById('btnExit').disabled = false;
    setButtonImages();
    return false;

}


//Delete Function  
function ClientDelete_client() {
    var compcode = document.getElementById('hiddencompcode').value;
    var custcode = document.getElementById('txtcustcode').value;
    var userid = document.getElementById('userid2').value;
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
    if (confirm("Are you sure you wish to delete this?")) {
        var agency_sav = document.getElementById('hiddenagency_uer').value
        var type = document.getElementById('drptype').value;
        var ip2 = document.getElementById('ip1').value;
        ClientMaster.ClientDeletedetail_client(compcode, custcode, userid, agency_sav, ip2);
        ClientMaster.clientexecute_client(coco, cuco, cuna, al, ci, st, us, ra, co, agency_sav, type, Client_CallBack_client);
        //ClientMaster.first(compcode,userid,custcode,Client_CallBack);
        if (browser != "Microsoft Internet Explorer") {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
        //alert(xmlObj.childNodes(0).childNodes(2).text);
        //alert("Record is Deleted Successfully");
    }

    return false;
}
function fillCity(id, val) {
    document.getElementById(id).value = val;
}
function Client_CallBack_client(response) {
    ds_exe = response.value;
    var len = ds_exe.Tables[0].Rows.length;
    if (ds_exe.Tables[0].Rows.length == 0) {
        alert("No More Data is here to be deleted");

        document.getElementById('btnSave').disabled = true;
        document.getElementById('txtcustcode').disabled = true;
        document.getElementById('txtcustomername').disabled = true;
        document.getElementById('txtalias').disabled = true;
        document.getElementById('txtadd1').disabled = true;
        document.getElementById('txtstreet').disabled = true;
        document.getElementById('drpcity').disabled = true;
        document.getElementById('txtdistrict').disabled = true;
        document.getElementById('txtcountry').disabled = true;
        document.getElementById('txtphone1').disabled = true;
        document.getElementById('txtphone2').disabled = true;
        document.getElementById('txtemailid').disabled = true;
        document.getElementById('txtUrl').disabled = true;
        document.getElementById('txtvts').disabled = true;
        document.getElementById('txtservicetax').disabled = true;
        document.getElementById('txtPan').disabled = true;
        document.getElementById('txtcreditdays').disabled = true;
        document.getElementById('txtcrlimit').disabled = true;
        document.getElementById('txtstatusreason').disabled = true;
        document.getElementById('txtstatus1').disabled = true;
        document.getElementById('txtalert').disabled = true;
        document.getElementById('drpdiscount').disabled = true;
        document.getElementById('txtamount').disabled = true;
        document.getElementById('drpffdis').disabled = true;
        document.getElementById('txtffdisc').disabled = true;
        document.getElementById('drpcsdis').disabled = true;
        document.getElementById('txtcsdisc').disabled = true;
        
        document.getElementById('txtpincode').disabled = true;
        document.getElementById('txtstate').disabled = true;
        document.getElementById('txtfax').disabled = true;
        document.getElementById('txtstatusdate').disabled = true;
        document.getElementById('drprategroup').disabled = true;
        document.getElementById('drptype').disabled = true;
        document.getElementById('txtgstin').disabled = true;
        document.getElementById('txtgstdt').disabled = true;
        document.getElementById('drpgstus').disabled = true;
        document.getElementById('txtgstclty').disabled = true;
        document.getElementById('txtgstclty').disabled = true;
     
            document.getElementById('txtarno').disabled = true;
       
            document.getElementById('txtgstprovid').disabled = true;
        
       
        document.getElementById('drprategroup').value = "0";
        document.getElementById('txtcustcode').value = "";
        document.getElementById('txtcustomername').value = "";
        document.getElementById('txtalias').value = "";
        document.getElementById('txtadd1').value = "";
        document.getElementById('txtstreet').value = "";
        document.getElementById('drpcity').value = "0";
        document.getElementById('txtdistrict').value = "";
        document.getElementById('txtcountry').value = "0";
        document.getElementById('txtphone1').value = "";
        document.getElementById('txtphone2').value = "";
        document.getElementById('txtemailid').value = "";
        document.getElementById('txtUrl').value = "";
        document.getElementById('txtvts').value = "";
        document.getElementById('txtservicetax').value = "";
        document.getElementById('txtPan').value = "";
        document.getElementById('txtcreditdays').value = "";
        document.getElementById('txtcrlimit').value = "";
        document.getElementById('txtstatusreason').value = "";
        document.getElementById('txtstatus1').value = "";
        document.getElementById('txtalert').value = "";


        document.getElementById('drpdiscount').value = "0";
        document.getElementById('txtamount').value = "";
        document.getElementById('drpffdis').value = "0";
        document.getElementById('txtffdisc').value = "";
        document.getElementById('drpcsdis').value = "0";
        document.getElementById('txtcsdisc').value = "";
        
        
        document.getElementById('txtpincode').value = "";
        document.getElementById('txtstate').value = "";
        document.getElementById('txtfax').value = "";
        document.getElementById('txtstatusdate').value = "";
        document.getElementById('modify').value = "";

        document.getElementById('txtdesg').value = "";
        document.getElementById('txtgstin').value = "0";
        document.getElementById('txtgstdt').value = "";
        document.getElementById('drpgstus').value = "";
        document.getElementById('drpgstatus').value = "0";
        document.getElementById('txtgstclty').value = "";
      
            document.getElementById('txtarno').value = "";
      
            document.getElementById('txtgstprovid').value = "";
        
        
        CancelClick('ClientMaster');

    }
    else if (z == -1 || z >= len) {
        //ds=ds_exe.value;
        var country = ds_exe.Tables[0].Rows[0].Country_Code;




        if (ds_exe.Tables[0].Rows[0].CLIENT_DESIGNATION != null) {
            document.getElementById('txtdesg').value = ds_exe.Tables[0].Rows[0].CLIENT_DESIGNATION;
        } else {

            document.getElementById('txtdesg').value = "";


        }

        if (ds_exe.Tables[0].Rows[0].Cust_Code != null) {
            document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[0].Cust_Code;
        }
        else {
            document.getElementById('txtcustcode').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].Cust_Name != null) {
            document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[0].Cust_Name;
        }
        else {
            document.getElementById('txtcustomername').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].Cust_Alias != null) {
            document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[0].Cust_Alias;
        }
        else {
            document.getElementById('txtalias').value == "";
        }
        if (ds_exe.Tables[0].Rows[0].City_Code != null) {
            document.getElementById('drpcity').value = ds_exe.Tables[0].Rows[0].City_Code;
        }
        else {
            document.getElementById('drpcity').value = "";
        }

        //Function  CallBack 
        ClientMaster.addcou(country, callcount_client);

        if (ds_exe.Tables[0].Rows[0].Stree != null) {
            document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[0].Stree;
        }
        else {
            document.getElementById('txtstreet').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Country_Code != null) {
            //document.getElementById('txtcountry').value=ds_exe.Tables[0].Rows[0].Country_Code;
            setTimeout("fillCity('txtcountry','" + ds_exe.Tables[0].Rows[0].Country_Code + "',100)");
        }
        else {
            document.getElementById('txtcountry').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Zip != null) {
            document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[0].Zip;
        }
        else {
            document.getElementById('txtpincode').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Dist_code != null) {
            document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[0].Dist_code;
        }
        else {
            document.getElementById('txtdistrict').value == "";
        }


        if (ds_exe.Tables[0].Rows[0].State_code != null) {
            document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[0].State_code;
        }
        else {
            document.getElementById('txtstate').value = "";
        }





        if (ds_exe.Tables[0].Rows[0].phone1 != null) {
            document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[0].phone1;
        }
        else {
            document.getElementById('txtphone1').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Phone2 != null) {
            document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[0].Phone2;
        }
        else {
            document.getElementById('txtphone2').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Fax != null) {
            document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[0].Fax;
        }
        else {
            document.getElementById('txtfax').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].EmailID != null) {
            document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[0].EmailID;
        }
        else {
            document.getElementById('txtemailid').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].URL != null) {
            document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[0].URL;
        }
        else {
            document.getElementById('txtUrl').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].ST_ACC_NO != null) {
            document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[0].ST_ACC_NO;
        }
        else {
            document.getElementById('txtservicetax').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].PAN_NO != null) {
            document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[0].PAN_NO;
        }
        else {
            document.getElementById('txtPan').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Credit_Days != null && ds_exe.Tables[0].Rows[0].Credit_Days != 0) {
            document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[0].Credit_Days;
        }
        else {
            document.getElementById('txtcreditdays').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Cust_Status != null) {

            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[0].Cust_Status;
        }
        else {

            document.getElementById('txtstatus1').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Status_Reason != null) {
            document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[0].Status_Reason;
        }
        else {
            document.getElementById('txtstatusreason').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Remarks != null) {
            document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[0].Remarks;
        }
        else {
            document.getElementById('txtalert').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].DISC_TY != null) {
            document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[0].DISC_TY;
        }
        else {
            document.getElementById('drpdiscount').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].DISC_AMT != null) {
            document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[0].DISC_AMT;
        }
        else {
            document.getElementById('txtamount').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY != null) {
            document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY;
        }
        else {
            document.getElementById('drpffdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT != null) {
            document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT;
        }
        else {
            document.getElementById('txtffdisc').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].CASH_DISC != null) {
            document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[0].CASH_DISC;
        }
        else {
            document.getElementById('drpcsdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].CASH_AMT != null) {
            document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[0].CASH_AMT;
        }
        else {
            document.getElementById('txtcsdisc').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].UserId != null) {
            document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[0].UserId;
        }
        else {
            document.getElementById('hiddenuserid').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Add1 != null) {
            document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[0].Add1;
        }
        else {
            document.getElementById('txtadd1').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Rate_Gr_Code != null) {
            document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[0].Rate_Gr_Code;
        }
        else {
            document.getElementById('drprategroup').value = "";
        }


        var dateformat = document.getElementById('hiddendateformat').value;
        //var currentdate=ds_exe.Tables[0].Rows[0].Creation_Datetime;
        var currentdate = new Date();
        var dd = currentdate.getDate();
        var mm = currentdate.getMonth() + 1;
        var yyyy = currentdate.getFullYear();
        //var enrolldate1=mm+'/'+dd+'/'+yyyy;

        if (dateformat == "yyyy/mm/dd") {
            var currentdate1 = yyyy + '/' + mm + '/' + dd;
        }
        else if (dateformat == "mm/dd/yyyy") {
            var currentdate1 = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "dd/mm/yyyy") {
            var currentdate1 = dd + '/' + mm + '/' + yyyy;
        }
        else {
            var currentdate1 = mm + '/' + dd + '/' + yyyy;
        }



        var todate5 = ds_exe.Tables[0].Rows[0].to_date;
        var dd = todate5.getDate();
        var mm = todate5.getMonth() + 1;
        var yyyy = todate5.getFullYear();
        //var enrolldate1=mm+'/'+dd+'/'+yyyy;

        if (dateformat == "yyyy/mm/dd") {
            var todate15 = yyyy + '/' + mm + '/' + dd;
        }
        else if (dateformat == "mm/dd/yyyy") {
            var todate15 = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "dd/mm/yyyy") {
            var todate15 = dd + '/' + mm + '/' + yyyy;
        }
        else {
            var todate15 = mm + '/' + dd + '/' + yyyy;
        }

        document.getElementById('txtstatusdate').value = currentdate1;

        if (ds_exe.Tables[0].Rows[0].Remarks != null) {
            document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[0].Remarks;
        }
        else {
            document.getElementById('txtalert').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].DISC_TY != null) {
            document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[0].DISC_TY;
        }
        else {
            document.getElementById('drpdiscount').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].DISC_AMT != null) {
            document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[0].DISC_AMT;
        }
        else {
            document.getElementById('txtamount').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY != null) {
            document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_TY;
        }
        else {
            document.getElementById('drpffdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT != null) {
            document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[0].F_FREQ_DISC_AMT;
        }
        else {
            document.getElementById('txtffdisc').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].CASH_DISC != null) {
            document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[0].CASH_DISC;
        }
        else {
            document.getElementById('drpcsdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].CASH_AMT != null) {
            document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[0].CASH_AMT;
        }
        else {
            document.getElementById('txtcsdisc').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].UserId != null) {
            document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[0].UserId;
        }
        else {
            document.getElementById('hiddenuserid').value = "";
        }


        if (ds_exe.Tables[0].Rows[0].Add1 != null) {
            document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[0].Add1;
        }
        else {
            document.getElementById('txtadd1').value = "";
        }


        document.getElementById('txtstatus1').style.visibility = "visible";
        document.getElementById('txtstatusdate').style.visibility = "visible";
        document.getElementById('Status').style.visibility = "visible";
        document.getElementById('StatusDate').style.visibility = "visible";

        var tdate4 = new Date(todate15);
        var cdate = new Date(currentdate1);
        if (cdate > tdate4) {
            document.getElementById('txtstatus1').value = "Banned"
        }
        else {
            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[0].Cust_Status;
        }

        if (ds_exe.Tables[0].Rows[0].GST_REGISTRATION != null) {
            document.getElementById('drpgstus').value = ds_exe.Tables[0].Rows[0].GST_REGISTRATION;
        }
        else {
            document.getElementById('drpgstus').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].GST_REGISTRATION_DATE != null) {
            document.getElementById('txtgstdt').value = ds_exe.Tables[0].Rows[0].GST_REGISTRATION_DATE;
        }
        else {
            document.getElementById('txtgstdt').value = "";
        }
        if (ds_exe.Tables[0].Rows[0].GSTIN != null) {
            document.getElementById('txtgstin').value = ds_exe.Tables[0].Rows[0].GSTIN;
        }
        else {
            document.getElementById('txtgstin').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_STATUS != null) {
            document.getElementById('drpgstatus').value = ds_exe.Tables[0].Rows[0].GST_STATUS;
        }
        else {
            document.getElementById('drpgstatus').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD != null) {
            document.getElementById('txtgstclty').value = ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD;
            var citytyp = ClientMaster.fill_gst(document.getElementById('hiddencompcode').value, ds_exe.Tables[0].Rows[0].GST_CLIENT_TYPE_CD);
            var ccty = citytyp.value.Tables[0].Rows[0].CLIENT_TYPE_NAME;
            document.getElementById('txtgstclty').value = ccty;
        }
        else {
            document.getElementById('txtgstclty').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_ARN_NO != null) {
            document.getElementById('txtarno').value = ds_exe.Tables[0].Rows[0].GST_ARN_NO;
        }
        else {
            document.getElementById('txtarno').value = "";
        }

        if (ds_exe.Tables[0].Rows[0].GST_PROVISINAL_ID != null) {
            document.getElementById('txtgstprovid').value = ds_exe.Tables[0].Rows[0].GST_PROVISINAL_ID;
        }
        else {
            document.getElementById('txtgstprovid').value = "";
        }

    }

    else {

        var city = ds_exe.Tables[0].Rows[z].City_Code;

        document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[z].Cust_Code;
        document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[z].Cust_Name;
        document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[z].Cust_Alias;
        document.getElementById('drpcity').value = ds_exe.Tables[0].Rows[z].City_Code;

        //Function  CallBack 
        ClientMaster.addcity(city, clientaddcode1_client);

        if (ds_exe.Tables[0].Rows[z].CLIENT_DESIGNATION != null) {
            document.getElementById('txtdesg').value = ds_exe.Tables[0].Rows[z].CLIENT_DESIGNATION;
        } else {

            document.getElementById('txtdesg').value = "";


        }



        if (ds_exe.Tables[0].Rows[z].Stree != null) {
            document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[z].Stree;
        }
        else {
            document.getElementById('txtstreet').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].Zip != null) {
            document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[z].Zip;
        }
        else {
            document.getElementById('txtpincode').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].Dist_code != null) {
            document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[z].Dist_code;
        }
        else {
            document.getElementById('txtdistrict').value == "";
        }

        if (ds_exe.Tables[0].Rows[z].State_code != null) {
            document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[z].State_code;
        }
        else {
            document.getElementById('txtstate').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].Country_Code != null) {
            setTimeout("fillCity('txtcountry','" + ds_exe.Tables[0].Rows[z].Country_Code + "',100)");
        }
        else {
            document.getElementById('txtcountry').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].phone1 != null) {
            document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[z].phone1;
        }
        else {
            document.getElementById('txtphone1').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].Phone2 != null) {
            document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[z].Phone2;
        }
        else {
            document.getElementById('txtphone2').value = "";
        }


        if (ds_exe.Tables[0].Rows[z].Fax != null) {
            document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[z].Fax;
        }
        else {
            document.getElementById('txtfax').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].EmailID != null) {
            document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[z].EmailID;
        }
        else {
            document.getElementById('txtemailid').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].URL != null) {
            document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[z].URL;
        }
        else {
            document.getElementById('txtUrl').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].ST_ACC_NO != null) {
            document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[z].ST_ACC_NO;
        }
        else {
            document.getElementById('txtservicetax').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].PAN_NO != null) {
            document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[z].PAN_NO;
        }
        else {
            document.getElementById('txtPan').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].Credit_Days != null && ds_exe.Tables[0].Rows[z].Credit_Days != 0) {
            document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[z].Credit_Days;
        }
        else {
            document.getElementById('txtcreditdays').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].Cust_Status != null) {

            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;
        }
        else {

            document.getElementById('txtstatus1').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].Status_Reason != null) {
            document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[z].Status_Reason;
        }
        else {
            document.getElementById('txtstatusreason').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].Remarks != null) {
            document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[z].Remarks;
        }
        else {
            document.getElementById('txtalert').value = "";
        }


        if (ds_exe.Tables[0].Rows[z].DISC_TY != null) {
            document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[z].DISC_TY;
        }
        else {
            document.getElementById('drpdiscount').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].DISC_AMT != null) {
            document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[z].DISC_AMT;
        }
        else {
            document.getElementById('txtamount').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
            document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY;
        }
        else {
            document.getElementById('drpffdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
            document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT;
        }
        else {
            document.getElementById('txtffdisc').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].CASH_DISC != null) {
            document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[z].CASH_DISC;
        }
        else {
            document.getElementById('drpcsdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].CASH_AMT != null) {
            document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[z].CASH_AMT;
        }
        else {
            document.getElementById('txtcsdisc').value = "";
        }


        if (ds_exe.Tables[0].Rows[z].UserId != null) {
            document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[z].UserId;
        }
        else {
            document.getElementById('hiddenuserid').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].Add1 != null) {
            document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[z].Add1;
        }
        else {
            document.getElementById('txtadd1').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].Rate_Gr_Code != null) {
            document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[z].Rate_Gr_Code;
        }
        else {
            document.getElementById('drprategroup').value = "";
        }

        var dateformat = document.getElementById('hiddendateformat').value;
        //var currentdate=ds_exe.Tables[0].Rows[z].Creation_Datetime;
        var currentdate = new Date();
        var dd = currentdate.getDate();
        var mm = currentdate.getMonth() + 1;
        var yyyy = currentdate.getFullYear();
        //var enrolldate1=mm+'/'+dd+'/'+yyyy;

        if (dateformat == "yyyy/mm/dd") {
            var currentdate1 = yyyy + '/' + mm + '/' + dd;
        }
        else if (dateformat == "mm/dd/yyyy") {
            var currentdate1 = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "dd/mm/yyyy") {
            var currentdate1 = dd + '/' + mm + '/' + yyyy;
        }
        else {
            var currentdate1 = mm + '/' + dd + '/' + yyyy;
        }



        var todate6 = ds_exe.Tables[0].Rows[z].Creation_Datetime;
        var dd = todate6.getDate();
        var mm = todate6.getMonth() + 1;
        var yyyy = todate6.getFullYear();
        //var enrolldate1=mm+'/'+dd+'/'+yyyy;

        if (dateformat == "yyyy/mm/dd") {
            var todate16 = yyyy + '/' + mm + '/' + dd;
        }
        else if (dateformat == "mm/dd/yyyy") {
            var todate16 = mm + '/' + dd + '/' + yyyy;
        }
        else if (dateformat == "dd/mm/yyyy") {
            var todate16 = dd + '/' + mm + '/' + yyyy;
        }
        else {
            var todate16 = mm + '/' + dd + '/' + yyyy;
        }

        document.getElementById('txtstatusdate').value = currentdate1;


        if (ds_exe.Tables[0].Rows[z].Remarks != null) {
            document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[z].Remarks;
        }
        else {
            document.getElementById('txtalert').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].DISC_TY != null) {
            document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[z].DISC_TY;
        }
        else {
            document.getElementById('drpdiscount').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].DISC_AMT != null) {
            document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[z].DISC_AMT;
        }
        else {
            document.getElementById('txtamount').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
            document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY;
        }
        else {
            document.getElementById('drpffdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
            document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT;
        }
        else {
            document.getElementById('txtffdisc').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].CASH_DISC != null) {
            document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[z].CASH_DISC;
        }
        else {
            document.getElementById('drpcsdis').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].CASH_AMT != null) {
            document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[z].CASH_AMT;
        }
        else {
            document.getElementById('txtcsdisc').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].UserId != null) {
            document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[z].UserId;
        }
        else {
            document.getElementById('hiddenuserid').value = "";
        }


        if (ds_exe.Tables[0].Rows[z].Add1 != null) {
            document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[z].Add1;
        }
        else {
            document.getElementById('txtadd1').value = "";
        }

        document.getElementById('txtstatus1').style.visibility = "visible";
        document.getElementById('txtstatusdate').style.visibility = "visible";
        document.getElementById('Status').style.visibility = "visible";
        document.getElementById('StatusDate').style.visibility = "visible";

        var tdate5 = new Date(todate16);
        var cdate = new Date(currentdate1);
        if (cdate > tdate5) {
            document.getElementById('txtstatus1').value = "Banned"
        }
        else {
            document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;
        }

        if (ds_exe.Tables[0].Rows[z].GST_REGISTRATION != null) {
            document.getElementById('drpgstus').value = ds_exe.Tables[0].Rows[z].GST_REGISTRATION;
        }
        else {
            document.getElementById('drpgstus').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].GST_REGISTRATION_DATE != null) {
            document.getElementById('txtgstdt').value = ds_exe.Tables[0].Rows[z].GST_REGISTRATION_DATE;
        }
        else {
            document.getElementById('txtgstdt').value = "";
        }
        if (ds_exe.Tables[0].Rows[z].GSTIN != null) {
            document.getElementById('txtgstin').value = ds_exe.Tables[0].Rows[z].GSTIN;
        }
        else {
            document.getElementById('txtgstin').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].GST_STATUS != null) {
            document.getElementById('drpgstatus').value = ds_exe.Tables[0].Rows[z].GST_STATUS;
        }
        else {
            document.getElementById('drpgstatus').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD != null) {
            document.getElementById('txtgstclty').value = ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD;
            var citytyp = ClientMaster.fill_gst(document.getElementById('hiddencompcode').value, ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD);
            var ccty = citytyp.value.Tables[0].Rows[0].CLIENT_TYPE_NAME;
            document.getElementById('txtgstclty').value = ccty;
        }
        else {
            document.getElementById('txtgstclty').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].GST_ARN_NO != null) {
            document.getElementById('txtarno').value = ds_exe.Tables[0].Rows[z].GST_ARN_NO;
        }
        else {
            document.getElementById('txtarno').value = "";
        }

        if (ds_exe.Tables[0].Rows[z].GST_PROVISINAL_ID != null) {
            document.getElementById('txtgstprovid').value = ds_exe.Tables[0].Rows[z].GST_PROVISINAL_ID;
        }
        else {
            document.getElementById('txtgstprovid').value = "";
        }

    }
    //alert ("Data Deleted");
    setButtonImages();
    return false;
}




function ClientUpdate_client() {
    //Condition Check
    if (mod == document.getElementById('txtcustomername').value) {
        updateclient();
    }
    else {
        ClientMaster.adchkudefine(document.getElementById('txtcustcode').value, document.getElementById('txtcustomername').value, callbackusermod);
    }
}
function callbackusermod(res) {
    var ds = res.value;
    for (var i = 0; i <= ds.Tables[0].Rows.length - 1; i++) {
        if (document.getElementById('txtcustomername').value == ds.Tables[0].Rows[i].Cust_Name) {
            alert("This Customer Name has already been assigned !! ");

            document.getElementById('txtcustomername').value = "";
            document.getElementById('txtcustomername').focus();
            return false;
        }
    }
    updateclient();
    return false;
}

function updateclient() {

 var dateformat = document.getElementById('hiddendateformat').value;
    document.getElementById('btnSave').disabled = false;
    var compcode = document.getElementById('hiddencompcode').value;
    var custcode = document.getElementById('txtcustcode').value;
    var custname = document.getElementById('txtcustomername').value;

    var alias = document.getElementById('txtalias').value;
    var add1 = document.getElementById('txtadd1').value;
    var city = document.getElementById('drpcity').value;
    var street = document.getElementById('txtstreet').value;
    var country = document.getElementById('txtcountry').value;
    var pincode = document.getElementById('txtpincode').value;
    var dist = document.getElementById('txtdistrict').value;
    var state = document.getElementById('txtstate').value;
    var country = document.getElementById('txtcountry').value;
    var phone1 = document.getElementById('txtphone1').value;
    var phone2 = document.getElementById('txtphone2').value;
    var fax = document.getElementById('txtfax').value;
    var emailid = document.getElementById('txtemailid').value;
    var url = document.getElementById('txtUrl').value;
    var vts = document.getElementById('txtvts').value;
    var servicetax = document.getElementById('txtservicetax').value;
    var pan = document.getElementById('txtPan').value;
    var creditdays = document.getElementById('txtcreditdays').value;
    var paymode = "";
    var zone = document.getElementById('drpzone').value;
    var region = document.getElementById('drpregion').value;
    var crdlimit = document.getElementById('txtcrlimit').value;

    var status = document.getElementById('txtstatus1').value;
    var statusreason = document.getElementById('txtstatusreason').value;
    var alert1 = document.getElementById('txtalert').value;
    var discount = document.getElementById('drpdiscount').value;
    var amount = document.getElementById('txtamount').value;
    var ffdiscount = document.getElementById('drpffdis').value;
    var ffdamount = document.getElementById('txtffdisc').value;
    var casdisc = document.getElementById('drpcsdis').value;
    var cshdiscamount = document.getElementById('txtcsdisc').value;
    var userid = document.getElementById('userid2').value;
    var rategroup = document.getElementById('drprategroup').value;
    var clientcatcode = document.getElementById('drpclientcat').value;
    var taluka = document.getElementById('drptaluka').value;

    var agency_sav = document.getElementById('hiddenagency_uer').value;
    var ip2 = document.getElementById('ip1').value;
    var clinttype = document.getElementById('drpclinttype').value;
    var agencycode = document.getElementById('txtagencycode').value;

    var type = document.getElementById('drptype').value;
    var branch = document.getElementById('drpbranch').value;  //30sep15
    var parent = document.getElementById('txtparent').value;
    var oldclient = document.getElementById('txtclientcode').value;
    var gstaus=document.getElementById('drpgstus').value;
    //var gstdate=document.getElementById('txtgstdt').value; 
    
     var gstdate="";			
			if(dateformat=="dd/mm/yyyy")
			{
			    if(document.getElementById('txtgstdt').value!="")
			        {
			            var txt=document.getElementById('txtgstdt').value;
			            var txt1=txt.split("/");
			            var dd=txt1[0];
			            var mm=txt1[1];
			            var yy=txt1[2];
			            gstdate=mm+'/'+dd+'/'+yy;
			        }
			        else
			        {
			         gstdate=document.getElementById('txtgstdt').value;
			        }
			
			}
			if(dateformat=="mm/dd/yyyy")
			 {
			     gstdate=document.getElementById('txtgstdt').value;
			 }
			if(dateformat=="yyyy/mm/dd")
			    {
			    if(document.getElementById('txtgstdt').value!="")
			        {
			        var txt=document.getElementById('txtgstdt').value;
			        var txt1=txt.split("/");
			        var yy=txt1[0];
			        var mm=txt1[1];
			        var dd=txt1[2];
			        gstdate=mm+'/'+dd+'/'+yy;
			        }
			    else
			        {
			         gstdate=document.getElementById('txtgstdt').value;
			        }
			    }
			if(dateformat=="" || dateformat==null || dateformat=="undefined")
			{
			    gstdate=document.getElementById('txtgstdt').value;
			}
    
       
    var gstin = document.getElementById('txtgstin').value;
    var gstapp=document.getElementById('drpgstatus').value ;
    var gstclityp = document.getElementById('hdngstclty').value;//document.getElementById('txtgstclty').value ;
    var gstarno = document.getElementById('txtarno').value;
    var gstprovid = document.getElementById('txtgstprovid').value;

    var gsteftdt="";			
			if(dateformat=="dd/mm/yyyy")
			{
			    if(document.getElementById('txtgsteftdt').value!="")
			        {
			            var txt=document.getElementById('txtgsteftdt').value;
			            var txt1=txt.split("/");
			            var dd=txt1[0];
			            var mm=txt1[1];
			            var yy=txt1[2];
			            gsteftdt=mm+'/'+dd+'/'+yy;
			        }
			        else
			        {
			         gsteftdt=document.getElementById('txtgsteftdt').value;
			        }
			
			}
			if(dateformat=="mm/dd/yyyy")
			 {
			     gsteftdt=document.getElementById('txtgsteftdt').value;
			 }
			if(dateformat=="yyyy/mm/dd")
			    {
			    if(document.getElementById('txtgsteftdt').value!="")
			        {
			        var txt=document.getElementById('txtgsteftdt').value;
			        var txt1=txt.split("/");
			        var yy=txt1[0];
			        var mm=txt1[1];
			        var dd=txt1[2];
			        gsteftdt=mm+'/'+dd+'/'+yy;
			        }
			    else
			        {
			         gsteftdt=document.getElementById('txtgsteftdt').value;
			        }
			    }
			if(dateformat=="" || dateformat==null || dateformat=="undefined")
			{
			 gsteftdt=document.getElementById('txtgsteftdt').value;
			}

    ClientMaster.clientmodify(compcode, custcode, custname, alias, add1, street, city, pincode, dist, state, country, phone1, phone2, fax, emailid, url, vts, servicetax, pan, creditdays, paymode, status, statusreason, alert1, userid, zone, region, crdlimit, 1, rategroup, clientcatcode, taluka, agency_sav, ip2, clinttype, agencycode, type, nam, oldclient, discount, amount, ffdiscount, ffdamount, casdisc, cshdiscamount, branch, gstaus, gstdate, gstin, gstapp, gstclityp, gstarno, gstprovid,gsteftdt);
    //alert(xmlObj.childNodes(0).childNodes(1).text);
    alert("Data Modified Sucessfully");

    show = "0";

    chkNM = "2";

    document.getElementById('modify').value = "";
    document.getElementById('btnSave').disabled = true;
    document.getElementById('txtcustcode').disabled = true;
    document.getElementById('txtcustomername').disabled = true;
    document.getElementById('txtalias').disabled = true;
    document.getElementById('txtadd1').disabled = true;
    document.getElementById('txtstreet').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('txtdistrict').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('txtphone1').disabled = true;
    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtUrl').disabled = true;
    document.getElementById('txtvts').disabled = true;
    document.getElementById('txtservicetax').disabled = true;
    document.getElementById('drptaluka').disabled = true;
    document.getElementById('txtPan').disabled = true;
    document.getElementById('txtcreditdays').disabled = true;
    document.getElementById('txtcrlimit').disabled = true;
    document.getElementById('txtstatusreason').disabled = true;
    document.getElementById('txtstatus1').disabled = true;
    document.getElementById('txtalert').disabled = true;
    document.getElementById('txtamount').disabled = true;
    document.getElementById('drpffdis').disabled = true;
    document.getElementById('txtffdisc').disabled = true;
    document.getElementById('drpcsdis').disabled = true;
    document.getElementById('txtcsdisc').disabled = true;
    document.getElementById('txtpincode').disabled = true;
    document.getElementById('txtstate').disabled = true;
    document.getElementById('txtfax').disabled = true;
    document.getElementById('txtstatusdate').disabled = true;
    document.getElementById('drprategroup').disabled = true;
    document.getElementById('drpclientcat').disabled = true;
    document.getElementById('drpregion').disabled = true;
    document.getElementById('drpzone').disabled = true;
    document.getElementById('drpclinttype').disabled = true;
    document.getElementById('btnSave').disabled = true;
    //document.getElementById('btnModify').disabled=false;
    document.getElementById('btnModify').disabled = false;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = false;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnDelete').disabled = false;
    document.getElementById('drptype').disabled = true;
    document.getElementById('txtparent').disabled = true;
    document.getElementById('drpclinttype').disabled = true;
    document.getElementById('drpgstus').disabled = true;
    document.getElementById('txtgstdt').disabled = true;
    document.getElementById('txtgstin').disabled = true;
    document.getElementById('drpgstatus').disabled = true;
    document.getElementById('txtgstclty').disabled = true;
    document.getElementById('txtarno').disabled = true;
    document.getElementById('txtgstprovid').disabled = true;
    
    client = "new";
    save = "N_CONT";
    var ds12 = "";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode + '&client=' + client, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                ds12 = httpRequest.responseText;
            }
            else {
                alert('There was a problem with the request.');
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode + '&client=' + client, false);
        xml.Send();
        ds12 = xml.responseText;
    }
    ClientMaster.clientexecute_client(coco, cuco, cuna, al, ci, st, us, ra, co, agency_sav, type, discount, amount, ffdiscount, ffdamount, casdisc, cshdiscamount, call_showupdate);
    return false;
}

var ValidateStatus;
function call_showupdate(res) {
    ds_exe = res.value;
    //var z=ds_exe.Tables[0].Rows.length;
    //z=0;


    document.getElementById('txtcustcode').value = ds_exe.Tables[0].Rows[z].Cust_Code;
    document.getElementById('txtcustomername').value = ds_exe.Tables[0].Rows[z].Cust_Name;
    document.getElementById('txtalias').value = ds_exe.Tables[0].Rows[z].Cust_Alias;


    if (ds_exe.Tables[0].Rows[z].CLIENT_DESIGNATION != null) {
        document.getElementById('txtdesg').value = ds_exe.Tables[0].Rows[z].CLIENT_DESIGNATION;
    } else {

        document.getElementById('txtdesg').value = "";


    }


    if (ds_exe.Tables[0].Rows[z].Stree != null) {
        document.getElementById('txtstreet').value = ds_exe.Tables[0].Rows[z].Stree;
    }
    else {
        document.getElementById('txtstreet').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].Zip != null) {
        document.getElementById('txtpincode').value = ds_exe.Tables[0].Rows[z].Zip;
    }
    else {
        document.getElementById('txtpincode').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].phone1 != null) {
        document.getElementById('txtphone1').value = ds_exe.Tables[0].Rows[z].phone1;
    }
    else {
        document.getElementById('txtphone1').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].Phone2 != null) {
        document.getElementById('txtphone2').value = ds_exe.Tables[0].Rows[z].Phone2;
    }
    else {
        document.getElementById('txtphone2').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].Fax != null) {
        document.getElementById('txtfax').value = ds_exe.Tables[0].Rows[z].Fax;
    }
    else {
        document.getElementById('txtfax').value = "";
    }
    //No_of_VTS
    if (ds_exe.Tables[0].Rows[z].No_of_VTS != null) {
        document.getElementById('txtvts').value = ds_exe.Tables[0].Rows[z].No_of_VTS;
    }
    else {
        document.getElementById('txtvts').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].EmailID != null) {
        document.getElementById('txtemailid').value = ds_exe.Tables[0].Rows[z].EmailID;
    }
    else {
        document.getElementById('txtemailid').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].URL != null) {
        document.getElementById('txtUrl').value = ds_exe.Tables[0].Rows[z].URL;
    }
    else {
        document.getElementById('txtUrl').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].ST_ACC_NO != null) {
        document.getElementById('txtservicetax').value = ds_exe.Tables[0].Rows[z].ST_ACC_NO;
    }
    else {
        document.getElementById('txtservicetax').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].PAN_NO != null) {
        document.getElementById('txtPan').value = ds_exe.Tables[0].Rows[z].PAN_NO;
    }
    else {
        document.getElementById('txtPan').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].Credit_Days != null && ds_exe.Tables[0].Rows[z].Credit_Days != 0) {
        document.getElementById('txtcreditdays').value = ds_exe.Tables[0].Rows[z].Credit_Days;
    }
    else {
        document.getElementById('txtcreditdays').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].Status_Reason != null) {
        document.getElementById('txtstatusreason').value = ds_exe.Tables[0].Rows[z].Status_Reason;
    }
    else {
        document.getElementById('txtstatusreason').value = "";
    }
    //alert(ds_exe.Tables[0].Rows[0].Country_code);
    document.getElementById('txtcountry').value = ds_exe.Tables[0].Rows[z].Country_Code;
    cityvar = ds_exe.Tables[0].Rows[z].City_Code;
    addcount_client(ds_exe.Tables[0].Rows[z].City_Code);


    document.getElementById('txtstate').value = ds_exe.Tables[0].Rows[z].State_Code;

    if (ds_exe.Tables[0].Rows[z].Dist_Code != null) {
        document.getElementById('txtdistrict').value = ds_exe.Tables[0].Rows[z].Dist_Code;
    }
    else {
        document.getElementById('txtdistrict').value = "";
    }
    //document.getElementById('txtdistrict').value=ds_exe.Tables[0].Rows[z].Dist_Code;
    //addregcity();
    addregcity_client(cityvar);
    document.getElementById('drpzone').value = ds_exe.Tables[0].Rows[z].Zone_code;
    document.getElementById('drpregion').value = ds_exe.Tables[0].Rows[z].Region_code;
    document.getElementById('drptaluka').value = ds_exe.Tables[0].Rows[z].TALUKA;
    if (ds_exe.Tables[0].Rows[z].Credit_limit != null) {
        document.getElementById('txtcrlimit').value = ds_exe.Tables[0].Rows[z].Credit_limit;
    }
    else {
        document.getElementById('txtcrlimit').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].Rate_Gr_Code != null) {
        document.getElementById('drprategroup').value = ds_exe.Tables[0].Rows[z].Rate_Gr_Code;
    }
    else {
        document.getElementById('drprategroup').value = "";
    }
    document.getElementById('txtstatus1').style.visibility = "hidden";
    document.getElementById('txtstatusdate').style.visibility = "hidden";
    document.getElementById('Status').style.visibility = "hidden";
    document.getElementById('StatusDate').style.visibility = "hidden";
    var dateformat = document.getElementById('hiddendateformat').value;
    //var currentdate=ds_exe.Tables[0].Rows[0].Creation_Datetime;
    var currentdate = new Date();
    var dd = currentdate.getDate();
    var mm = currentdate.getMonth() + 1;
    var yyyy = currentdate.getFullYear();
    //var enrolldate1=mm+'/'+dd+'/'+yyyy;

    if (dateformat == "yyyy/mm/dd") {
        var currentdate1 = yyyy + '/' + mm + '/' + dd;
    }
    else if (dateformat == "mm/dd/yyyy") {
        var currentdate1 = mm + '/' + dd + '/' + yyyy;
    }
    else if (dateformat == "dd/mm/yyyy") {
        var currentdate1 = dd + '/' + mm + '/' + yyyy;
    }
    else {
        var currentdate1 = mm + '/' + dd + '/' + yyyy;
    }



    var todate7 = ds_exe.Tables[0].Rows[z].Creation_Datetime;
    var dd = todate7.getDate();
    var mm = todate7.getMonth() + 1;
    var yyyy = todate7.getFullYear();
    //var enrolldate1=mm+'/'+dd+'/'+yyyy;

    if (dateformat == "yyyy/mm/dd") {
        var todate17 = yyyy + '/' + mm + '/' + dd;
    }
    else if (dateformat == "mm/dd/yyyy") {
        var todate17 = mm + '/' + dd + '/' + yyyy;
    }
    else if (dateformat == "dd/mm/yyyy") {
        var todate17 = dd + '/' + mm + '/' + yyyy;
    }
    else {
        var todate17 = mm + '/' + dd + '/' + yyyy;
    }




    document.getElementById('txtstatusdate').value = currentdate1;
    if (ds_exe.Tables[0].Rows[z].Remarks != null) {
        document.getElementById('txtalert').value = ds_exe.Tables[0].Rows[z].Remarks;
    }
    else {
        document.getElementById('txtalert').value = "";
    }

    if (ds_exe.Tables[0].Rows[z].DISC_TY != null) {
        document.getElementById('drpdiscount').value = ds_exe.Tables[0].Rows[z].DISC_TY;
    }
    else {
        document.getElementById('drpdiscount').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].DISC_AMT != null) {
        document.getElementById('txtamount').value = ds_exe.Tables[0].Rows[z].DISC_AMT;
    }
    else {
        document.getElementById('txtamount').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY != null) {
        document.getElementById('drpffdis').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_TY;
    }
    else {
        document.getElementById('drpffdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT != null) {
        document.getElementById('txtffdisc').value = ds_exe.Tables[0].Rows[z].F_FREQ_DISC_AMT;
    }
    else {
        document.getElementById('txtffdisc').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].CASH_DISC != null) {
        document.getElementById('drpcsdis').value = ds_exe.Tables[0].Rows[z].CASH_DISC;
    }
    else {
        document.getElementById('drpcsdis').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].CASH_AMT != null) {
        document.getElementById('txtcsdisc').value = ds_exe.Tables[0].Rows[z].CASH_AMT;
    }
    else {
        document.getElementById('txtcsdisc').value = "";
    }
    
    document.getElementById('hiddenuserid').value = ds_exe.Tables[0].Rows[z].UserId;
    if (ds_exe.Tables[0].Rows[z].Add1 != null) {
        document.getElementById('txtadd1').value = ds_exe.Tables[0].Rows[z].Add1;
    }
    else {
        document.getElementById('txtadd1').value = "";
    }
    document.getElementById('txtstatus1').style.visibility = "visible";
    document.getElementById('txtstatusdate').style.visibility = "visible";
    document.getElementById('Status').style.visibility = "visible";
    document.getElementById('StatusDate').style.visibility = "visible";

    var tdate = new Date(todate17);
    var cdate = new Date(currentdate1);
    if (cdate > tdate) {
        document.getElementById('txtstatus1').value = "Banned"
    }
    else {
        document.getElementById('txtstatus1').value = ds_exe.Tables[0].Rows[z].Cust_Status;
    }
    if (ds_exe.Tables[0].Rows[z].GST_REGISTRATION != null) {
        document.getElementById('drpgstus').value = ds_exe.Tables[0].Rows[z].GST_REGISTRATION;
    }
    else {
        document.getElementById('drpgstus').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].GST_REGISTRATION_DATE != null) {
        document.getElementById('txtgstdt').value = ds_exe.Tables[0].Rows[z].GST_REGISTRATION_DATE;
    }
    else {
        document.getElementById('txtgstdt').value = "";
    }
    if (ds_exe.Tables[0].Rows[z].GSTIN != null) {
        document.getElementById('txtgstin').value = ds_exe.Tables[0].Rows[z].GSTIN;
    }
    else {
        document.getElementById('txtgstin').value = "";
    }

    if (ds_exe.Tables[0].Rows[z].GST_STATUS != null) {
        document.getElementById('drpgstatus').value = ds_exe.Tables[0].Rows[z].GST_STATUS;
    }
    else {
        document.getElementById('drpgstatus').value = "";
    }

    if (ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD != null) {
        document.getElementById('hdngstclty').value = ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD;//txtgstclty
        var citytyp = ClientMaster.fill_gst(document.getElementById('hiddencompcode').value, ds_exe.Tables[0].Rows[z].GST_CLIENT_TYPE_CD);
        var ccty = citytyp.value.Tables[0].Rows[0].CLIENT_TYPE_NAME;
        document.getElementById('txtgstclty').value = ccty;

    }
    else {
        document.getElementById('txtgstclty').value = "";
    }

    if (ds_exe.Tables[0].Rows[z].GST_ARN_NO != null) {
        document.getElementById('txtarno').value = ds_exe.Tables[0].Rows[z].GST_ARN_NO;
    }
    else {
        document.getElementById('txtarno').value = "";
    }

    if (ds_exe.Tables[0].Rows[z].GST_PROVISINAL_ID != null) {
        document.getElementById('txtgstprovid').value = ds_exe.Tables[0].Rows[z].GST_PROVISINAL_ID;
    }
    else {
        document.getElementById('txtgstprovid').value = "";
    }

    updateStatus();
    if (ds_exe.Tables[0].Rows.length == 1) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnprevious').disabled = true;

    }
    else if (z == 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;

    }
    else if (z == ds_exe.Tables[0].Rows.length - 1) {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;

    }
    setButtonImages();
}
function ValidateFields1() {
    var chmandat;
    if (document.getElementById('hiddenauto').value != 1) {
        if (document.getElementById('txtcustcode').value == "") {
            alert("Please Enter Customer Code");
            if (document.getElementById('txtcustcode').disabled == false)
                document.getElementById('txtcustcode').focus();
            ValidateStatus = 0;
            return false;
        }
    }

    if (browser == "Microsoft Internet Explorer") {
        chmandat = document.getElementById('RateGroup').innerText;
    }
    else {
        chmandat = document.getElementById('RateGroup').textContent;
    }

    if (chmandat.indexOf('*') >= 0) {
        if (document.getElementById('drprategroup').value == "" || document.getElementById('drprategroup').value == "0") {
            alert('Please Enter Rate Group');
            ValidateStatus = 0;
            document.getElementById('drprategroup').focus();
            return false;
        }

    }
    if (document.getElementById('txtcustomername').value == "") {
        alert("Please Enter Customer Name");
        document.getElementById('txtcustomername').focus();
        ValidateStatus = 0;
        return false;
    }

    if (document.getElementById('txtalias').value == "") {
        alert("Please Enter Alias Name");
        document.getElementById('txtalias').focus();
        ValidateStatus = 0;
        return false;
    }
    if (browser == "Microsoft Internet Explorer") {
        chmandat = document.getElementById('Address1').innerText;
    }
    else {
        chmandat = document.getElementById('Address1').textContent;
    }

    if (chmandat.indexOf('*') >= 0) {
        if (document.getElementById('txtadd1').value == "") {
            alert("Please Enter Customer Address1");
            document.getElementById('txtadd1').focus();
            ValidateStatus = 0;
            return false;
        }
    }
    if (document.getElementById('txtcountry').value == 0 || document.getElementById('txtcountry').value == "") {
        alert("Please Select  Country Name");
        document.getElementById('txtcountry').focus();
        ValidateStatus = 0;
        return false;
    }
    var chmandat = "";
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('City').textContent;
    }
    else {
        chmandat = document.getElementById('City').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (document.getElementById('drpcity').value == 0 || document.getElementById('drpcity').value == "") {
            alert("Please Select  City Name");
            document.getElementById('drpcity').focus();
            ValidateStatus = 0;
            return false;
        }
    }
    var chmandat3 = "";
    if (browser != "Microsoft Internet Explorer") {
        chmandat3 = document.getElementById('RateGroup').textContent;
    }
    else {
        chmandat3 = document.getElementById('RateGroup').innerText;
    }
    if (chmandat3.indexOf('*') >= 0) {
        if (document.getElementById('drprategroup').value == 0 || document.getElementById('drprategroup').value == "") {
            alert("Please Select  Rate Group");
            document.getElementById('drprategroup').focus();
            ValidateStatus = 0;
            return false;
        }
    }
    var chmandat1 = "";
    if (browser != "Microsoft Internet Explorer") {
        chmandat1 = document.getElementById('Region').textContent;
    }
    else {
        chmandat1 = document.getElementById('Region').innerText;
    }
    if (chmandat1.indexOf('*') >= 0) {
        if (document.getElementById('drpregion').value == 0 || document.getElementById('drpregion').value == "") {
            alert("Please Select  Region");
            if (document.getElementById('drpregion').disabled == false)
                document.getElementById('drpregion').focus();
            ValidateStatus = 0;
            return false;
        }
    }
    if (document.getElementById('drpzone').value == 0 || document.getElementById('drpzone').value == "") {
        alert("Please Select  Zone");
        if (document.getElementById('drpzone').disabled == false)
            document.getElementById('drpzone').focus();
        ValidateStatus = 0;
        return false;
    }
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('lbltaluka').textContent;
    }
    else {
        chmandat = document.getElementById('lbltaluka').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (document.getElementById('drptaluka').value == 0 || document.getElementById('drptaluka').value == "") {
            alert("Please Select  Taluka");
            if (document.getElementById('drptaluka').disabled == false)
                document.getElementById('drptaluka').focus();
            ValidateStatus = 0;
            return false;
        }
    }
    var chmandat2 = "";
    if (browser != "Microsoft Internet Explorer") {
        chmandat2 = document.getElementById('lbcliencat').textContent;
    }
    else {
        chmandat2 = document.getElementById('lbcliencat').innerText;
    }
    if (chmandat2.indexOf('*') >= 0) {
        if (document.getElementById('drpclientcat').value == 0 || document.getElementById('drpclientcat').value == "") {
            alert("Please Select  Client Category");
            document.getElementById('drpclientcat').focus();
            ValidateStatus = 0;
            return false;
        }
    }

    if (document.getElementById('drpgstatus').value == "Y") {
        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstclty').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstclty').innerText;
        }
        if (chmandat1.indexOf('*') >= 0) {
            if (document.getElementById('txtgstclty').value == "0" || document.getElementById('txtgstclty').value == "") {
                alert("Please enter the Gst Client Type");
                document.getElementById('txtgstclty').focus();
                return false;
            }
        }


        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstus').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstus').innerText;
        }
        if (chmandat1.indexOf('*') >= 0) {
            if (document.getElementById('drpgstus').value == "0" || document.getElementById('drpgstus').value == "") {
                alert("Please enter the Gst Status ");
                document.getElementById('drpgstus').focus();
                return false;
            }
        }


        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgstdt').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgstdt').innerText;
        }
        if (chmandat1.indexOf('*') >= 0) {
            if (document.getElementById('txtgstdt').value == "0" || document.getElementById('txtgstdt').value == "") {
                alert("Please enter the Gst Registration Date");
                document.getElementById('txtgstdt').focus();
                return false;
            }
        }



        var chmandat1 = "";
        if (browser != "Microsoft Internet Explorer") {
            chmandat1 = document.getElementById('lblgst').textContent;
        }
        else {
            chmandat1 = document.getElementById('lblgst').innerText;
        }
        if (chmandat1.indexOf('*') >= 0) {
            if (document.getElementById('txtgstin').value == "0" || document.getElementById('txtgstin').value == "") {
                alert("Please enter the Gst Registration");
                document.getElementById('txtgstin').focus();
                return false;
            }
        }
    }

    if (document.getElementById('txtcountry').value == 0 || document.getElementById('txtcountry').value == "") {
        alert("Please Select  Country Name");
        document.getElementById('txtcountry').focus();
        ValidateStatus = 0;
        return false;
    }
    else {
        ValidateStatus = 1;
    }

    if (document.getElementById('drptype').value == "C") {
        if (document.getElementById('txtparent').value == "") {
            //alert("Please Fill Parent Name");
            //document.getElementById('txtparent').focus();
            //ValidateStatus =0;
            //return false;
        }
    }
    else {
        ValidateStatus = 1;
    }
}

function ClientUrlCheck() {
    var theurl = document.Form1.txtUrl.value;
    var tomatch = /[A-Za-z0-9\.-]{3,}\.[A-Za-z]{3}/
    if (tomatch.test(theurl) || document.getElementById('txtUrl').value == "") {
        falge23 = 0;
        return true;

    }
    else {
        window.alert("Invalid URL ");
        document.getElementById('txtUrl').value = "";
        document.getElementById('txtUrl').focus();
        falge23 = 1;
        return false;
    }
}

var test = "false";
function ClientSave_client() {
    test = "true";
    ClientUrlCheck();

    if (falge23 == 1) {
        return false;
    }
    {
        ValidateFields1();
        var msg = ClientEmailCheck('txtemailid');
        if (msg == false)
            return false;
        var mod = document.getElementById('modify').value;
        var strtextd = "";
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }
        httpRequest.open("GET", "checksessiondan.aspx", false);
        httpRequest.send('');
        if (httpRequest.readyState == 4) {
            if (httpRequest.status == 200) {
                strtextd = httpRequest.responseText;
            }
            else {
                if (browser != "Microsoft Internet Explorer") {
                }
            }
        }
        if (strtextd != "sess") {
            alert('session expired');
            window.location.href = "Default.aspx";
            return false;
        }
        if (ValidateStatus == 1 && mod == "modify") {
            ClientUpdate_client();
            return false;
        }

        if (ValidateStatus == 1 && mod != "modify") {
            var compcode = document.getElementById('hiddencompcode').value;
            var custcode = document.getElementById('txtcustcode').value;
            var custname = document.getElementById('txtcustomername').value;
            var userid = document.getElementById('userid2').value;

            ClientMaster.CheckClientPopup(compcode, custcode, custname, userid, 0, CheckClientPopup_CallBack_client);
        }

        return false;
    }
}

function CheckClientPopup_CallBack_client(response) {
    var ds = response.value;
    client = "go";
    save = "Y";
    var ds_cont;
    var dateformat = document.getElementById('hiddendateformat').value;
    var custcode1 = document.getElementById('txtcustcode').value;
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

        httpRequest.open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode1 + '&client=' + client, false);
        httpRequest.send('');
        if (httpRequest.readyState == 4) {
            if (httpRequest.status == 200) {
                ds_cont = httpRequest.responseText;
            }
            else {
                alert('There was a problem with the request.');
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode1 + '&client=' + client, false);
        xml.Send();
        ds_cont = xml.responseText;
    }
    if (ds_cont == "NO3") {
    }
    if (ds_cont == "NO1") {
    }
    if (ds_cont == "NO2") {
        alert("Please Enter Status Details");
        return false;
    }
    if (ds_cont == "NO4") {
    }
    //***************************************************************//       
    else {
        if (document.getElementById('modify').value == "") {
            var compcode = document.getElementById('hiddencompcode').value;
            var custcode = document.getElementById('txtcustcode').value;
            var custname = document.getElementById('txtcustomername').value;
            var alias = document.getElementById('txtalias').value;
            var add1 = document.getElementById('txtadd1').value;
            var city = document.getElementById('drpcity').value;
            var street = document.getElementById('txtstreet').value;
            var country = document.getElementById('txtcountry').value;
            var pincode = document.getElementById('txtpincode').value;
            var dist = document.getElementById('txtdistrict').value;
            var state = document.getElementById('txtstate').value;
            var country = document.getElementById('txtcountry').value;
            var phone1 = document.getElementById('txtphone1').value;
            var phone2 = document.getElementById('txtphone2').value;
            var fax = document.getElementById('txtfax').value;
            var emailid = document.getElementById('txtemailid').value;
            var url = document.getElementById('txtUrl').value;
            var vts = document.getElementById('txtvts').value;
            var servicetax = document.getElementById('txtservicetax').value;
            var pan = document.getElementById('txtPan').value;
            var creditdays = document.getElementById('txtcreditdays').value;
            var paymode = "";
            var status1 = document.getElementById('txtstatus1').value;
            var statusreason = document.getElementById('txtstatusreason').value;
            var zone = document.getElementById('drpzone').value;
            var region = document.getElementById('drpregion').value;
            var crdlimit = document.getElementById('txtcrlimit').value;
            var alert1 = document.getElementById('txtalert').value;
            var discount = document.getElementById('drpdiscount').value;
            var amount = document.getElementById('txtamount').value;
            var ffdiscount = document.getElementById('drpffdis').value;
            var ffdamount = document.getElementById('txtffdisc').value;
            var casdisc = document.getElementById('drpcsdis').value;
            var cshdiscamount = document.getElementById('txtcsdisc').value;
            var userid2 = document.getElementById('userid2').value;
            var rategroup = document.getElementById('drprategroup').value;
            var clientcatcode = document.getElementById('drpclientcat').value;
            var taluka = document.getElementById('drptaluka').value;
            var clinttype = document.getElementById('drpclinttype').value;
            var agencycode = document.getElementById('txtagencycode').value;
            var type = document.getElementById('drptype').value;
            var parent = document.getElementById('txtparent').value;
            var oldclient = document.getElementById('txtclientcode').value;
            var branch = document.getElementById('drpbranch').value;
            var gstaus = document.getElementById('drpgstus').value;
            //var gstdate = document.getElementById('txtgstdt').value;
             var gstdate="";			
			if(dateformat=="dd/mm/yyyy")
			{
			    if(document.getElementById('txtgstdt').value!="")
			        {
			            var txt=document.getElementById('txtgstdt').value;
			            var txt1=txt.split("/");
			            var dd=txt1[0];
			            var mm=txt1[1];
			            var yy=txt1[2];
			            gstdate=mm+'/'+dd+'/'+yy;
			        }
			        else
			        {
			         gstdate=document.getElementById('txtgstdt').value;
			        }
			
			}
			if(dateformat=="mm/dd/yyyy")
			 {
			     gstdate=document.getElementById('txtgstdt').value;
			 }
			if(dateformat=="yyyy/mm/dd")
			    {
			    if(document.getElementById('txtgstdt').value!="")
			        {
			        var txt=document.getElementById('txtgstdt').value;
			        var txt1=txt.split("/");
			        var yy=txt1[0];
			        var mm=txt1[1];
			        var dd=txt1[2];
			        gstdate=mm+'/'+dd+'/'+yy;
			        }
			    else
			        {
			         gstdate=document.getElementById('txtgstdt').value;
			        }
			    }
			if(dateformat=="" || dateformat==null || dateformat=="undefined")
			{
			    gstdate=document.getElementById('txtgstdt').value;
			}
            var gstin = document.getElementById('txtgstin').value;

            var gstapp = document.getElementById('drpgstatus').value;
            var gstclityp = document.getElementById('hdngstclty').value;//document.getElementById('txtgstclty').value;
            var gstarno = document.getElementById('txtarno').value;
            var gstprovid = document.getElementById('txtgstprovid').value;
            
            var gsteftdt="";			
			if(dateformat=="dd/mm/yyyy")
			{
			    if(document.getElementById('txtgsteftdt').value!="")
			        {
			            var txt=document.getElementById('txtgsteftdt').value;
			            var txt1=txt.split("/");
			            var dd=txt1[0];
			            var mm=txt1[1];
			            var yy=txt1[2];
			            gsteftdt=mm+'/'+dd+'/'+yy;
			        }
			        else
			        {
			         gsteftdt=document.getElementById('txtgsteftdt').value;
			        }
			
			}
			if(dateformat=="mm/dd/yyyy")
			 {
			     gsteftdt=document.getElementById('txtgsteftdt').value;
			 }
			if(dateformat=="yyyy/mm/dd")
			    {
			    if(document.getElementById('txtgsteftdt').value!="")
			        {
			        var txt=document.getElementById('txtgsteftdt').value;
			        var txt1=txt.split("/");
			        var yy=txt1[0];
			        var mm=txt1[1];
			        var dd=txt1[2];
			        gsteftdt=mm+'/'+dd+'/'+yy;
			        }
			    else
			        {
			         gsteftdt=document.getElementById('txtgsteftdt').value;
			        }
			    }
			if(dateformat=="" || dateformat==null || dateformat=="undefined")
			{
			 gsteftdt=document.getElementById('txtgsteftdt').value;
			}
            
            
            //-----------------------------------------------------------------------------------
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
            document.getElementById('btnagencyname').disabled = true;
            var agency_sav = document.getElementById('hiddenagency_uer').value;
            var designantion = document.getElementById('txtdesg').value;
            var ip2 = document.getElementById('ip1').value;

            ClientMaster.clientsave(compcode, custcode, custname, alias, add1, street, city, pincode, dist, state, country, phone1, phone2, fax, emailid, url, vts, servicetax, pan, creditdays, paymode, status1, statusreason, alert1, userid2, zone, region, crdlimit, 0, rategroup, clientcatcode, taluka, agency_sav, ip2, clinttype, agencycode, type, nam, oldclient, designantion, discount, amount, ffdiscount, ffdamount, casdisc, cshdiscamount, branch, gstaus, gstdate, gstin,gstapp,gstclityp,gstarno,gstprovid,gsteftdt);
            if (document.getElementById('hiddenbookclientname1').value == "2") {
                opener.document.getElementById('drpclientname').value = document.getElementById('txtcustomername').value + "(" + document.getElementById('txtcustcode').value + ")";
            }
            else if (document.getElementById('hiddenbookclientname1').value == "1") {
                opener.document.getElementById('txtclient').value = document.getElementById('txtcustomername').value + "(" + document.getElementById('txtcustcode').value + ")";
                var client_val = opener.document.getElementById('txtclient').value;
                /////////////////
                opener.document.getElementById('txtclientadd').value = document.getElementById('txtadd1').value + " " + document.getElementById('txtstreet').value;
               }
            document.getElementById('drpclientcat').value = "0";
            document.getElementById('drpclientcat').disabled = true;
            document.getElementById('drprategroup').value = "0";
            document.getElementById('drprategroup').disabled = true;
            document.getElementById('drpregion').disabled = true;
            document.getElementById('drpzone').disabled = true;
            document.getElementById('drpregion').value = "0"
            document.getElementById('drpzone').value = "0"
            alert('Data Saved Successfully With Client Code ' + custcode);
            show = "0";
            chkNM = "2";
            CancelClick_client('ClientMaster');
            var ds11 = "";
            client = "new";
            save = "N_CONT";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }
                httpRequest.onreadystatechange = function() { alertContents(httpRequest) };
                httpRequest.open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode + '&client=' + client, false);
                httpRequest.send('');
                if (httpRequest.readyState == 4) {
                    if (httpRequest.status == 200) {
                        ds11 = httpRequest.responseText;
                    }
                    else {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open("GET", "chkclient.aspx?save=" + save + '&code=' + custcode + '&client=' + client, false);
                xml.Send();
                ds11 = xml.responseText;
            }
            setButtonImages();
            if (document.getElementById('hiddenbookclientname').value != "") {
                if (confirm("Do you want to update Previous Booking")) {
                    window.open("Modbukclient.aspx?clientnam=" + document.getElementById('hiddenbookclientname').value + '&clientcod=' + custcode);
                }
            }
        }
    }
    if (document.getElementById('hiddenbookclientname1').value == "1") {
        window.close();
        return false;
    }
}

/*-----------------------------Pop up coding starts-------------------------- */

/*Paymode Coding starts */
var mystatus;
//Client Pay Mode Submission

function ClientPayModeSubmit() {
    var chkList234 = document.getElementById("chklstSubmit");

    var MyArray = new Array(3)
    var str = new Array(3);
    MyArray[0] = document.getElementById("chklstSubmit_0").nextSibling;
    MyArray[1] = document.getElementById("chklstSubmit_1").nextSibling;
    MyArray[2] = document.getElementById("chklstSubmit_2").nextSibling;
    var arrayOfCheckBoxes = chkList234.getElementsByTagName("input");

    if (arrayOfCheckBoxes[0].checked == false && arrayOfCheckBoxes[1].checked == false && arrayOfCheckBoxes[2].checked == false) {
        alert('Please Checked Atleast One Mode of Payment');
        return false;
    }
    else {

        var compcode = document.getElementById('hiddencomcode').value;
        var custcode = document.getElementById('hiddenclientcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        Mycustcode = custcode;
        for (var i = 0; i < arrayOfCheckBoxes.length; i++) {
            if (arrayOfCheckBoxes[i].checked == true) {
                str[i] = MyArray[i].innerHTML;

            }
        }
        var compcode = document.getElementById('hiddencomcode').value;
        var custcode = document.getElementById('hiddenclientcode').value;
        var userid = document.getElementById('hiddenuserid').value;

        ClientPaymode.ClientPayModeInsert(compcode, custcode, userid, str);
        ClientPayModeUpdatedData();
        arrayOfCheckBoxes[0].checked = false;
        arrayOfCheckBoxes[1].checked = false;
        arrayOfCheckBoxes[2].checked = false;
        document.getElementById("chklstSubmit").disabled = true;
        document.getElementById("btnSubmit").disabled = true;
        mystatus = 1;
    }
    chk123();
    return false;
}


//Client Refereshed Data

function ClientPayModeUpdatedData() {

    var chkListSubmit = document.getElementById("chklstSubmit");
    var arrayOfCheckBoxesSubmit = chkListSubmit.getElementsByTagName("input");

    var chklstUpdate1 = document.getElementById("chklstUpdate");
    var arrayOfCheckBoxesUpdate = chklstUpdate1.getElementsByTagName("input");

    var compcode = document.getElementById('hiddencomcode').value;
    var custcode = document.getElementById('hiddenclientcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    for (var i = 0; i <= arrayOfCheckBoxesSubmit.length - 1; i++) {
        if (arrayOfCheckBoxesSubmit[i].checked == true) {
            arrayOfCheckBoxesUpdate[i].checked = true;
        }
    }



    document.getElementById('chklstUpdate').disabled = false;

    document.getElementById("btnUpdate").disabled = false;
    return false;
}


//Updating Values 


function ClientPayModeUpdate() {
    var chkList234 = document.getElementById("chklstUpdate");

    var MyArray = new Array(3)
    var str = new Array(3);
    MyArray[0] = document.getElementById("chklstUpdate_0").nextSibling;
    MyArray[1] = document.getElementById("chklstUpdate_1").nextSibling;
    MyArray[2] = document.getElementById("chklstUpdate_2").nextSibling;

    var arrayOfCheckBoxes = chkList234.getElementsByTagName("input");

    if (arrayOfCheckBoxes[0].checked == false && arrayOfCheckBoxes[1].checked == false && arrayOfCheckBoxes[2].checked == false) {
        alert('Please Checked Atleast One Mode of Payment');
        return false;
    }
    else {
        var compcode = document.getElementById('hiddencomcode').value;
        var custcode = document.getElementById('hiddenclientcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        for (var i = 0; i < arrayOfCheckBoxes.length; i++) {
            if (arrayOfCheckBoxes[i].checked == true) {
                str[i] = MyArray[i].innerHTML;

            }
        }
        var compcode = document.getElementById('hiddencomcode').value;
        var custcode = document.getElementById('hiddenclientcode').value;
        var userid = document.getElementById('hiddenuserid').value;

        ClientPaymode.ClientPayModeInsert(compcode, custcode, userid, str);
        //alert("Data saved");
    }
    return false;
}




//POP UP 
function ClientPay_client() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ClientName = document.getElementById('txtcustomername').value;
    var add = document.getElementById('txtadd1').value;
    var country = document.getElementById('txtcountry').value;
    var city = document.getElementById('drpcity').value;
    var ab;
    if (ClientName == "" || country == "0" || ClientCode == "") {
        alert("Please Fill All Mandatory Fields");
        //document.getElementById('txtagencode').focus();
        return false;
    }
    var chmandat = "";
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('City').textContent;
    }
    else {
        chmandat = document.getElementById('City').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (document.getElementById('drpcity').value == 0 || document.getElementById('drpcity').value == "") {
            alert("Please Fill All Mandatory Fields");
            document.getElementById('drpcity').focus();
            //ValidateStatus =0;
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('Address1').textContent;
    }
    else {
        chmandat = document.getElementById('Address1').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (add == "") {
            alert("Please Fill All Mandatory Fields");
            document.getElementById('txtadd1').focus();
            //ValidateStatus =0;
            return false;
        }
    }
    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {


            paywind = window.open("ClientPaymode.aspx?ClCode=" + ClientCode + '&show=' + show + '&n_m=' + chkNM, 'c', "status=0,toolbar=0,menubar=0 ,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px");

            paywind.focus();

            //alert(paywind);
            return false;
        }
    }
    else {
        alert('You must enter Client Name ');
    }
    return false;
}

function ClientStatusDetail_client() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ClientName = document.getElementById('txtcustomername').value;
    var add = document.getElementById('txtadd1').value;
    var country = document.getElementById('txtcountry').value;
    var city = document.getElementById('drpcity').value;
    var ab;
    if (ClientName == "" || country == "0" || ClientCode == "") {
        alert("Please Fill All Mandatory Fields");
        //document.getElementById('txtagencode').focus();
        return false;
    }
    var chmandat = "";
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('City').textContent;
    }
    else {
        chmandat = document.getElementById('City').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (document.getElementById('drpcity').value == 0 || document.getElementById('drpcity').value == "") {
            alert("Please Fill All Mandatory Fields");
            document.getElementById('drpcity').focus();
            //ValidateStatus =0;
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('Address1').textContent;
    }
    else {
        chmandat = document.getElementById('Address1').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (add == "") {
            alert("Please Fill All Mandatory Fields");
            document.getElementById('txtadd1').focus();
            //ValidateStatus =0;
            return false;
        }
    }
    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {


            statuswind = window.open("clientstatusmaster.aspx?custcode=" + ClientCode + '&show=' + show + '&n_m=' + chkNM, 'a', "status=0,toolbar=0,resizable=1,scrollbars=yes,top=244,left=210,width=780px,height=415px");
            statuswind.focus();
            return false;
        }
    }
    else {
        alert('You must enter Client Name ');
    }
    return false;
}

function ClientContactDetail_client() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ClientName = document.getElementById('txtcustomername').value;
    var add = document.getElementById('txtadd1').value;
    var country = document.getElementById('txtcountry').value;
    var city = document.getElementById('drpcity').value;
    var ab;
    if (ClientName == "" || country == "0" || ClientCode == "") {
        alert("Please Fill All Mandatory Fields");
        //document.getElementById('txtagencode').focus();
        return false;
    }
    var chmandat = "";
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('City').textContent;
    }
    else {
        chmandat = document.getElementById('City').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (document.getElementById('drpcity').value == 0 || document.getElementById('drpcity').value == "") {
            alert("Please Fill All Mandatory Fields");
            document.getElementById('drpcity').focus();
            //ValidateStatus =0;
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('Address1').textContent;
    }
    else {
        chmandat = document.getElementById('Address1').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (add == "") {
            alert("Please Fill All Mandatory Fields");
            document.getElementById('txtadd1').focus();
            //ValidateStatus =0;
            return false;
        }
    }
    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {


            contwind = window.open("clientcontactdetails.aspx?custcode=" + ClientCode + '&show=' + show + '&n_m=' + chkNM, 'b', "status=0,toolbar=0,menubar=0 ,resizable=1,scrollbars=yes,top=244,left=210,,width=780px,height=415px");
            contwind.focus();
            return false;
        }
    }
    else {
        alert('You must enter Client Name ');
    }
    return false;
}

function ClientProductDetail_client() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ClientName = document.getElementById('txtcustomername').value;
    var ClientName = document.getElementById('txtcustomername').value;
    var add = document.getElementById('txtadd1').value;
    var country = document.getElementById('txtcountry').value;
    var city = document.getElementById('drpcity').value;

    if (ClientName == "" || country == "0" || ClientCode == "") {
        alert("Please Fill All Mandatory Fields");
        //document.getElementById('txtagencode').focus();
        return false;
    }
    var chmandat = "";
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('City').textContent;
    }
    else {
        chmandat = document.getElementById('City').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (document.getElementById('drpcity').value == 0 || document.getElementById('drpcity').value == "") {
            alert("Please Fill All Mandatory Fields");
            document.getElementById('drpcity').focus();
            //ValidateStatus =0;
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        chmandat = document.getElementById('Address1').textContent;
    }
    else {
        chmandat = document.getElementById('Address1').innerText;
    }
    if (chmandat.indexOf('*') >= 0) {
        if (add == "") {
            alert("Please Fill All Mandatory Fields");
            document.getElementById('txtadd1').focus();
            //ValidateStatus =0;
            return false;
        }
    }
    if (document.getElementById('txtcustomername').value == "") {
        alert('You must enter Client Name ');
    }
    else if (document.getElementById('txtcustomername').value == "") {
        alert('You must enter Client Name');
    }

    //if(document.getElementById('txtcustcode').value!="" && 

    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {

            cont = window.open('ClientProdMastr.aspx?custcode=' + ClientCode + '&clientname=' + ClientName + '&show=' + show + '&n_m=' + chkNM, 'z', 'status=0,toolbar=0,resizable=1,top=244,left=250,scrollbars=yes,width=700px height=400px');
            cont.focus();
            return false;
        }


    }
    return false;
}

function clientaddcode() {
    document.getElementById('hiddencitycode').value = document.getElementById('drpcity').value;
    var city = document.getElementById('hiddencitycode').value;
    ClientMaster.addcity(city, clientaddcode1_client);
}

function addcity_client() {
    document.getElementById('hiddencitycode').value = document.getElementById('drpcity').value;
    var city = document.getElementById('hiddencitycode').value;
    ClientMaster.addcity(city, clientaddcode1_client);
}


function clientaddcode1_client(response) {
    var ds = response.value;
    if (ds == null) {
        return false;
    }
    if (ds.Tables[0].Rows.length > 0) {
        if (ds.Tables[1].Rows.length > 0)
            document.getElementById('txtdistrict').value = ds.Tables[1].Rows[0].dist_name;
        if (ds.Tables[2].Rows.length > 0)
            document.getElementById('txtstate').value = ds.Tables[2].Rows[0].state_name;
        document.getElementById('txtcountry').value = ds.Tables[0].Rows[0].country_name;
        document.getElementById('txtdistrict').disabled = true;
        document.getElementById('txtstate').disabled = true;
        document.getElementById('txtcountry').disabled = true;
    }
    else {
        document.getElementById('txtdistrict').value = "";
        document.getElementById('txtstate').value = "";
        document.getElementById('txtcountry').value = "0";
        document.getElementById('txtdistrict').disabled = true;
        document.getElementById('txtstate').disabled = true;
        document.getElementById('txtcountry').disabled = true;
    }
    return false;
}

//*****************************************************************************************************//


function autogen_client() {
    //    if((document.getElementById('query').value=="0"))
    //      {
    //         if(document.getElementById('save').value=="0")
    //          {
    //           if(document.getElementById('modify').value!="2")
    //           {
    //           if(document.getElementById('pnew').value=="1")
    //            {
    document.getElementById('txtcustomername').value = trim(document.getElementById('txtcustomername').value);
    if (hiddentext == "new" || hiddentext == "") {
        if ((document.getElementById('hiddenauto').value == "1")) {
            changeoccured_client();
            return false;
        }
        else {
            userdefine_client();
            return false;
        }
    }
    //             }
    //        }
    //    }
    //  } 
    //    

    return;
}




function changeoccured_client() {
    //if(hiddentext=="new" )
    //document.getElementById('btnExecute').focus;
    //{

    if (document.getElementById('hiddenauto').value == 1) {

        lstr = document.getElementById('txtcustomername').value;
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

        if (document.getElementById('txtcustomername').value != "") {

            document.getElementById('txtcustomername').value = document.getElementById('txtcustomername').value.toUpperCase();
            document.getElementById('txtalias').value = document.getElementById('txtcustomername').value;
            document.getElementById('txtalias').focus();
            str = mstr;
            str = str.replace('&', '');
            ClientMaster.adchkadvcode(str, fillcall_client)
            return false;
        }
        return false;
    }
    // }
}

// if((document.getElementById('hiddenauto').value=="1"))
//			{
//	
//           document.getElementById('txtcustomername').value=trim(document.getElementById('txtcustomername').value);
//		 //document.getElementById('txtalias').value=document.getElementById('txtprodesc').value;
//		  lstr=document.getElementById('txtcustomername').value;
//		  cstr=lstr.substring(0,1);
//            var mstr="";
//            			   if(lstr.indexOf(" ")==1)
//			            {
//			            var leng=lstr.length;
//			           mstr= cstr + lstr.substring(2,leng);
//			            }
//			            else
//			            {
//			             var leng=lstr.length;
//			            mstr=cstr + lstr.substring(1,leng);
//			            }
//		    if(document.getElementById('txtcustomername').value!="")
//                {
//               
//        
//		

//document.getElementById('txtcustomername').value=document.getElementById('txtcustomername').value.toUpperCase();
//	    if(chkNM=="1")
//                            {
//	    document.getElementById('txtalias').value=document.getElementById('txtcustomername').value;
//	    }
//		// str=document.getElementById('txtprodesc').value;
//		// cod=document.getElementById('txtadvcatcode').value;
//		str=mstr;
//		//var indus=document.getElementById('drpindustry').value;
//		ClientMaster.adchkadvcode(str,fillcall_client);
//		return false;
//                }
//		          
//       return false;
//		        
//           }
//            else
//            {
//            

//document.getElementById('txtcustomername').value=document.getElementById('txtcustomername').value.toUpperCase();
//            return false ;
//            }
//         return false ;
//     }

//function fillcall_modify(res)
//{
//}
//auto generated
//this is used for increment in code
//function uppercase31_client()
//		{
//		  

//document.getElementById('txtcustomername').value=trim(document.getElementById('txtcustomername').value);
//		 //document.getElementById('txtalias').value=document.getElementById('txtprodesc').value;
//		  lstr=document.getElementById('txtcustomername').value;
//		  cstr=lstr.substring(0,1);
//            var mstr="";
//            			   if(lstr.indexOf(" ")==1)
//			            {
//			            var leng=lstr.length;
//			           mstr= cstr + lstr.substring(2,leng);
//			            }
//			            else
//			            {
//			             var leng=lstr.length;
//			            mstr=cstr + lstr.substring(1,leng);
//			            }
//		    if(document.getElementById('txtcustomername').value!="")
//                {
//               
//        
//		

//document.getElementById('txtcustomername').value=document.getElementById('txtcustomername').value.toUpperCase();
//	    if(chkNM=="1")
//                            {
//	    document.getElementById('txtalias').value=document.getElementById('txtcustomername').value;
//	    }
//		// str=document.getElementById('txtprodesc').value;
//		// cod=document.getElementById('txtadvcatcode').value;
//		str=mstr;
//		//var indus=document.getElementById('drpindustry').value;
//		ClientMaster.adchkadvcode(str,fillcall_client);
//		return false;
//                }
//		       
//               
// return false;
//		
//}

function fillcall_client(res) {
    var ds = res.value;
    var newstr;
    //ds.Tables[4].Rows.length > 0
    //		if(ds.Tables[0].Rows.length!=0 )
    //		{
    //		    alert("This Customer Name has already been assigned !! ");
    //		    
    //				document.getElementById('txtcustomername').value="";	
    //				document.getElementById('txtalias').value="";
    //			    document.getElementById('txtcustomername').focus();
    //		  
    //    		
    //		    return false;
    //		 }
    //		 else
    //		 {
    if (chkNM == "1") {
        if (ds.Tables[1].Rows.length == 0) {
            newstr = null;
        }
        else {
            newstr = ds.Tables[1].Rows[0].cust_code1;
        }
        if (newstr == 0) {
            str = str.toUpperCase();
            document.getElementById('txtcustcode').value = str.substr(0, 2) + "1";
            //newstr=document.getElementById('txtadcatcode').value;
        }
        else if (newstr >= 1) {
            str = str.toUpperCase();
            var Autoincrement = parseInt(ds.Tables[1].Rows[0].cust_code1) + 1;
            document.getElementById('txtcustcode').value = str.substr(0, 2) + Autoincrement;
        }
        else if (newstr != null) {
            document.getElementById('txtcustomername').value = trim(document.getElementById('txtcustomername').value);
            var code = newstr.substr(2, 4);
            str = str.toUpperCase();
            var code = newstr;
            code++;
            document.getElementById('txtcustcode').value = str.substr(0, 2) + code;
            // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
        }
        else {
            str = str.toUpperCase();
            str = str.replace('&', '');
            document.getElementById('txtcustcode').value = str.substr(0, 2) + "0";
            //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
        }
    }
    //		     }
    return false;

    //		var ds=res.value;
    //		
    //		var newstr;
    //		
    //		    if(ds.Tables[0].Rows.length!=0)
    //		    {
    //		    if(chkNM!="0")
    //		    {
    //		    if(document.getElementById("txtcustomername").value!=mod)
    //		    {
    //		    alert("This Customer Name has already been assigned !! ");
    //		    
    //		    document.getElementById("txtcustomername").value="";
    //		    if(chkNM=="1")
    //            {
    //		    document.getElementById("txtalias").value="";
    //		    document.getElementById("txtcustcode").value="";
    //		    }
    //		    document.getElementById('txtcustomername').focus();
    //    		
    //		    return false;
    //		    }
    //		    }
    //		    }
    //		        else
    //		        {           
    //		                    if(chkNM=="1")
    //                            {
    //		                    if(ds.Tables[1].Rows.length==0)
    //		                        {
    //		                        newstr=null;
    //		                        }
    //		                    else
    //		                        {
    //		                         newstr=ds.Tables[1].Rows[0].cust_code;
    //		                        }
    //		                    if(newstr !=null )
    //		                        {
    //		                       // var code=newstr.substr(2,4);
    //		                       var code=newstr;
    //		                        code++;
    //		                        document.getElementById('txtcustcode').value=str.substr(0,2)+ code;
    //		                         }
    //		                    else
    //		                         {
    //		                          document.getElementById('txtcustcode').value=str.substr(0,2)+ "0";
    //		                          }
    //		     }
    //		     }
    //	return false;
}

function userdefine_client() {

    if (document.getElementById('hiddenauto').value !== "1") {

        document.getElementById('txtcustcode').disabled = false;



        document.getElementById('txtcustomername').value = trim(document.getElementById('txtcustomername').value.toUpperCase());
        document.getElementById('txtalias').value = document.getElementById('txtcustomername').value;
        auto = document.getElementById('hiddenauto').value;
        document.getElementById('txtalias').focus();

        ClientMaster.adchkudefine(document.getElementById('txtcustcode').value, document.getElementById('txtcustomername').value, callbackuser);
        //return false;
    }

    //return false;


}

function callbackuser(res) {
    var ds = res.value;
    //    if(ds.Tables.length >1)//if(ds.Tables[0].Rows.length>0)
    //    {
    // for(var i=0;i<=ds.Tables[0].Rows.length-1;i++)
    //{
    if (ds.Tables[0].Rows.length > 0)//if(document.getElementById('txtcustcode').value==ds.Tables[0].Rows[i].Cust_Code)
    {
        alert("This Customer Code has already been assigned !! ");

        document.getElementById('txtcustcode').value = "";
        if (document.getElementById('txtcustcode').disabled == false)
            document.getElementById('txtcustcode').focus();
        return false;
    }
    //            else  if(ds.Tables[1].Rows.length>0)//if(document.getElementById('txtcustomername').value==ds.Tables[0].Rows[i].Cust_Name)
    //            {
    //                alert("This Customer Name has already been assigned !! ");

    //                document.getElementById('txtcustomername').value="";	
    //                document.getElementById('txtalias').value="";
    //                document.getElementById('txtcustomername').focus();
    //                return false;
    //            }
    // }
    // }
}

/*************/
function addcount_client(ab) {
    var country = document.getElementById('txtcountry').value;
    var pkgitem = document.getElementById("drpcity");
    pkgitem.options.length = 0;
    //ClientMaster.addcou(country,callcount_client);
    var res = ClientMaster.addcou(country);
    var ds = res.value;
    var pkgitem = document.getElementById("drpcity");
    pkgitem.options.length = 0;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name, res.value.Tables[0].Rows[i].City_Code);

            pkgitem.options.length;

        }
        if (cityvar == 'undefined' || cityvar == undefined) {
            document.getElementById('drpcity').value = res.value.Tables[0].Rows[0].City_Code;

        }
        else {
            document.getElementById('drpcity').value = cityvar;
        }
    }
    else {
        alert("There is No Matching value Found");
        pkgitem.options.length = 0;
        document.getElementById('drpzone').value = "0";
        document.getElementById('drpregion').value = "0";
        document.getElementById('txtstate').value = "";
        document.getElementById('txtdistrict').value = "";
        return false;

    }
    return false;
}

function callcount_client(res) {

    var ds = res.value;
    var pkgitem = document.getElementById("drpcity");
    pkgitem.options.length = 0;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {

        //var pkgitem = document.getElementById("drpcity");
        //alert(pkgitem);

        //alert(pkgitem.options.length);
        for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name, res.value.Tables[0].Rows[i].City_Code);

            pkgitem.options.length;

        }
        if (cityvar == 'undefined' || cityvar == undefined) {
            document.getElementById('drpcity').value = res.value.Tables[0].Rows[0].City_Code;

        }
        else {
            document.getElementById('drpcity').value = cityvar;
        }
    }
    else {
        alert("There is No Matching value Found");
        pkgitem.options.length = 0;
        document.getElementById('drpzone').value = "0";
        document.getElementById('drpregion').value = "0";
        document.getElementById('txtstate').value = "";
        document.getElementById('txtdistrict').value = "";
        return false;

    }

    return false;
}


function addregcity_client(values) {
    //alert(document.Form1.drpcity.value);
    //alert(document.Form1.drpcity.value);
    if (values == "1") {
        values = document.getElementById('drpcity').value;
    }
    var res5;
    if (values != "0") {
        res5 = ClientMaster.addreg(values);
        //FillDropDownList_CallBackMaindoc_client(res);
        var ds6 = res5.value;
        if (ds6 == null)
            return false;
        var region = document.getElementById('drpregion');
        var taluka = document.getElementById('drptaluka');
        var zone = document.getElementById('drpzone');


        if (document.getElementById('drpcity').value != "0" && document.getElementById('drpcity').value != "") {
            if (ds6 != null && typeof (ds6) == "object" && ds6.Tables != null && ds6.Tables.length > 0) {

                document.getElementById("drpzone").options[0] = new Option("------Select Zone------", "0");
                document.getElementById("drpregion").options[0] = new Option("-----Select Region-----", "0");
                document.getElementById("drptaluka").options[0] = new Option("-----Select Taluka-----", "0");

                document.getElementById("drpregion").options.length = 0;

                document.getElementById("drpregion").options.length = ds6.Tables[1].Rows.length;

                document.getElementById("drpzone").options.length = 0;

                document.getElementById("drpzone").options.length = ds6.Tables[2].Rows.length;


                document.getElementById("drptaluka").options.length = 0;

                if (ds6.Tables[7] != null && ds6.Tables[7].Rows != null)
                    document.getElementById("drptaluka").options.length = ds6.Tables[7].Rows.length;

                if (ds6.Tables[3].Rows.length > 0) {
                    for (var i = 0; i <= ds6.Tables[2].Rows.length - 1; i++) {
                        document.getElementById('drpregion').options[i] = new Option(ds6.Tables[2].Rows[i].region_name, ds6.Tables[2].Rows[i].region_code);
                    }
                    document.getElementById('drpregion').value = ds6.Tables[3].Rows[0].region_code;

                }
                else {
                    if (document.getElementById('drpcity').disabled == false) {
                        // alert("There is no matching value(s) found for region");
                    }
                    document.getElementById('drpregion').disabled = true;
                    region.options.length = 0;
                    return false;

                }

                if (ds6.Tables[7] != null && ds6.Tables[7].Rows != null && ds6.Tables[7].Rows.length > 0) {
                    for (var i = 0; i < ds6.Tables[7].Rows.length; ++i) {
                        document.getElementById("drptaluka").options[i] = new Option(ds6.Tables[7].Rows[i].talu_name, ds6.Tables[7].Rows[i].talu_code);
                    }
                    //if(show1="5")	
                    document.getElementById('drptaluka').value = ds6.Tables[7].Rows[0].talu_code;
                    //if(show1="6")
                    //document.getElementById('drptaluka').value=ds_exe.Tables[0].Rows[z].(ds6.Tables[7].Rows[0].talu_code);
                }
                else {
                    if (document.getElementById('drpcity').disabled == false) {

                    }

                    taluka.options.length = 0;


                }

                //document.getElementById("hiddenregion").value=document.getElementById("drpregion").value;


                if (ds6.Tables[0].Rows.length > 0) {
                    document.getElementById('txtstate').value = ds6.Tables[0].Rows[0].state_name;
                    document.getElementById('hiddenstatecode').value = ds6.Tables[0].Rows[0].state_code;
                }
                else {
                    if (document.getElementById('drpcity').disabled == false) {
                        //alert("There is no matching value for state");
                    }
                    document.getElementById('txtstate').value = "";
                    document.getElementById('hiddenstatecode').value = "";
                    document.getElementById('txtstate').disabled = true;

                }

                if (ds6.Tables[1].Rows.length > 0) {
                    document.getElementById('txtdistrict').value = ds6.Tables[1].Rows[0].dist_name;
                }
                else {
                    //alert("There is no matching value for district");
                }
                if (ds6.Tables[5].Rows.length > 0) {
                    for (var i = 0; i < ds6.Tables[4].Rows.length; ++i) {
                        document.getElementById("drpzone").options[i] = new Option(ds6.Tables[4].Rows[i].zone_name, ds6.Tables[4].Rows[i].zone_code);
                    }
                    document.getElementById('drpzone').value = ds6.Tables[5].Rows[0].zone_code;
                }
                else {
                    if (document.getElementById('drpcity').disabled == false) {
                        // alert("There is no matching value(s) found for Zone");
                    }
                    zone.options.length = 0;
                    document.getElementById('drpzone').disabled = true;
                    return false;
                }
            }
            if (show == "1") {
                document.getElementById('drpregion').disabled = false;
                document.getElementById('drpzone').disabled = false;
            }

        }

    }
    else {
        document.forms[0].item("drpzone").options[0] = new Option("------Select Zone------", "0");
        document.forms[0].item("drpregion").options[0] = new Option("-----Select Region-----", "0");

        document.forms[0].item("drpregion").options.length = 1;
        //document.forms[0].item("drpregion").options.length=ds.Tables[1].Rows.length;

        document.forms[0].item("drpzone").options.length = 1;
        document.getElementById('txtstate').value = "";
        document.getElementById('txtdistrict').value = "";
        document.forms[0].item("drptaluka").options.length = 0;

        //document.forms[0].item("drpzone").options.length=ds.Tables[2].Rows.length;
    }


    //document.getElementById('dpstate').focus();	
    return false;

}






function FillDropDownList_CallBackMaindoc_client(response) {
    var ds6 = response.value;
    var region = document.getElementById('drpregion');
    var taluka = document.getElementById('drptaluka');
    var zone = document.getElementById('drpzone');


    if (document.getElementById('drpcity').value != "0" && document.getElementById('drpcity').value != "") {
        if (ds6 != null && typeof (ds6) == "object" && ds6.Tables != null && ds6.Tables.length > 0) {

            document.getElementById("drpzone").options[0] = new Option("------Select Zone------", "0");
            document.getElementById("drpregion").options[0] = new Option("-----Select Region-----", "0");

            document.getElementById("drpregion").options.length = 0;
            document.getElementById("drpregion").options.length = ds6.Tables[1].Rows.length;

            document.getElementById("drpzone").options.length = 0;
            document.getElementById("drpzone").options.length = ds6.Tables[2].Rows.length;

            document.getElementById("drptaluka").options.length = 0;
            document.getElementById("drptaluka").options.length = ds6.Tables[7].Rows.length;

            if (ds6.Tables[3].Rows.length > 0) {
                for (var i = 0; i <= ds6.Tables[2].Rows.length - 1; i++) {
                    document.getElementById('drpregion').options[i] = new Option(ds6.Tables[2].Rows[i].region_name, ds6.Tables[2].Rows[i].region_code);
                }
                document.getElementById('drpregion').value = ds6.Tables[3].Rows[0].region_code;

            }
            else {
                if (document.getElementById('drpcity').disabled == false) {
                    // alert("There is no matching value(s) found for region");
                }
                document.getElementById('drpregion').disabled = true;
                region.options.length = 0;
                return false;

            }

            if (ds6.Tables[7].Rows.length > 0) {
                for (var i = 0; i < ds6.Tables[7].Rows.length; ++i) {
                    document.getElementById("drptaluka").options[i] = new Option(ds6.Tables[7].Rows[i].talu_name, ds6.Tables[7].Rows[i].talu_code);
                }
                //if(show1="5")	
                document.getElementById('drptaluka').value = ds6.Tables[7].Rows[0].talu_code;
                //if(show1="6")
                //document.getElementById('drptaluka').value=ds_exe.Tables[0].Rows[z].(ds6.Tables[7].Rows[0].talu_code);
            }
            else {
                if (document.getElementById('drpcity').disabled == false) {

                }

                taluka.options.length = 0;


            }

            //document.getElementById("hiddenregion").value=document.getElementById("drpregion").value;


            if (ds6.Tables[0].Rows.length > 0) {
                document.getElementById('txtstate').value = ds6.Tables[0].Rows[0].state_name;
            }
            else {
                if (document.getElementById('drpcity').disabled == false) {
                    //alert("There is no matching value for state");
                }
                document.getElementById('txtstate').value = "";
                document.getElementById('txtstate').disabled = true;

            }

            if (ds6.Tables[1].Rows.length > 0) {
                document.getElementById('txtdistrict').value = ds6.Tables[1].Rows[0].dist_name;
            }
            else {
                //alert("There is no matching value for district");
            }
            if (ds6.Tables[5].Rows.length > 0) {
                for (var i = 0; i < ds6.Tables[4].Rows.length; ++i) {
                    document.getElementById("drpzone").options[i] = new Option(ds6.Tables[4].Rows[i].zone_name, ds6.Tables[4].Rows[i].zone_code);
                }
                document.getElementById('drpzone').value = ds6.Tables[5].Rows[0].zone_code;
            }
            else {
                if (document.getElementById('drpcity').disabled == false) {
                    // alert("There is no matching value(s) found for Zone");
                }
                zone.options.length = 0;
                document.getElementById('drpzone').disabled = true;
                return false;
            }
        }
        if (show == "1") {
            document.getElementById('drpregion').disabled = false;
            document.getElementById('drpzone').disabled = false;
        }

    }

    return false;
}

//		document.getElementById('txtdistrict').value="";

//}

function lowercase() {
    //alert('here');
    if (event.keyCode == 65)
        event.keyCode = 97;
    if (event.keyCode == 66)
        event.keyCode = 98;
    if (event.keyCode == 67)
        event.keyCode = 99;
    if (event.keyCode == 68)
        event.keyCode = 100;
    if (event.keyCode == 69)
        event.keyCode = 101;
    if (event.keyCode == 70)
        event.keyCode = 102;
    if (event.keyCode == 71)
        event.keyCode = 103;
    if (event.keyCode == 72)
        event.keyCode = 104;
    if (event.keyCode == 73)
        event.keyCode = 105;
    if (event.keyCode == 74)
        event.keyCode = 106;
    if (event.keyCode == 75)
        event.keyCode = 107;
    if (event.keyCode == 76)
        event.keyCode = 108;
    if (event.keyCode == 77)
        event.keyCode = 109;
    if (event.keyCode == 78)
        event.keyCode = 110;
    if (event.keyCode == 79)
        event.keyCode = 111;
    if (event.keyCode == 80)
        event.keyCode = 112;
    if (event.keyCode == 81)
        event.keyCode = 113;
    if (event.keyCode == 82)
        event.keyCode = 114;
    if (event.keyCode == 83)
        event.keyCode = 115;
    if (event.keyCode == 84)
        event.keyCode = 116;
    if (event.keyCode == 85)
        event.keyCode = 117;
    if (event.keyCode == 86)
        event.keyCode = 118;
    if (event.keyCode == 87)
        event.keyCode = 119;
    if (event.keyCode == 88)
        event.keyCode = 120;
    if (event.keyCode == 89)
        event.keyCode = 121;
    if (event.keyCode == 90)
        event.keyCode = 122;

}
//	if ((event.keyCode>=48 && event.keyCode<=57))
//	{
//		
//		return true;
//	}
//	else
//	{
//		return false;
//	}

//}

function trimalias() {
    document.getElementById('txtalias').value = trim(document.getElementById('txtalias').value);
}

function chkdupcode_Modify() {
    document.getElementById('txtcustcode').value = trim(document.getElementById('txtcustcode').value.toUpperCase());
    if (hiddentext == "new" || hiddentext == "") {
        ClientMaster.adchkudefine(document.getElementById('txtcustcode').value, document.getElementById('txtcustomername').value, callbackuser);
    }
}


/*********************************                changes by shachi         ***************************************/


function ClientExecDetail_client() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ClientName = document.getElementById('txtcustomername').value;
    var add = document.getElementById('txtadd1').value;
    var country = document.getElementById('txtcountry').value;
    var city = document.getElementById('drpcity').value;
    //var ab;
    if (ClientName == "" || add == "" || country == "0" || city == "0") {
        alert("Please Fill All Mandatory Fields");
        //document.getElementById('txtagencode').focus();
        return false;
    }
    /*if(document.getElementById('txtcustomername').value=="")
    {
    alert('You must enter Client Name ');
    }
    else if (document.getElementById('txtcustomername').value=="")
    {
    alert('You must enter Client Name');
    }*/

    //if(document.getElementById('txtcustcode').value!="" && 

    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {

            cont = window.open('clientexecutivemast.aspx?custcode=' + ClientCode + '&clientname=' + ClientName + '&show=' + show + '&n_m=' + chkNM, 'z', 'status=0,toolbar=0,resizable=1,top=244,left=250,scrollbars=yes,width=700px height=400px');
            cont.focus();
            return false;
        }


    }
    return false;
}



function ClientBrandDetail_client() {
    var ClientCode = document.getElementById('txtcustcode').value;
    var ClientName = document.getElementById('txtcustomername').value;
    var ClientName = document.getElementById('txtcustomername').value;
    var add = document.getElementById('txtadd1').value;
    var country = document.getElementById('txtcountry').value;
    var city = document.getElementById('drpcity').value;
    //var ab;
    if (ClientName == "" || add == "" || country == "0" || city == "0") {
        alert("Please Fill All Mandatory Fields");
        //document.getElementById('txtagencode').focus();
        return false;
    }
    /*if(document.getElementById('txtcustomername').value=="")
    {
    alert('You must enter Client Name ');
    }
    else if (document.getElementById('txtcustomername').value=="")
    {
    alert('You must enter Client Name');
    }*/

    //if(document.getElementById('txtcustcode').value!="" && 

    if (document.getElementById('txtcustcode').value != "") {
        for (var index = 0; index < 200; index++) {

            cont = window.open('clientbrandmast.aspx?custcode=' + ClientCode + '&clientname=' + ClientName + '&show=' + show + '&n_m=' + chkNM, 'z', 'status=0,toolbar=0,resizable=1,top=244,left=250,scrollbars=yes,width=700px height=400px');
            cont.focus();
            return false;
        }


    }
    return false;
}









/*********************************************************************************************************/


//       function timedelay11(aa)
//       {
//	        
//	        if(aa!=null)
//	        {
//	            document.getElementById('txtcountry').value=aa;
//	        }
//	        
//	   }    

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


function ttttt(event) {

    if (event.keyCode == 8) {




        if (document.activeElement.id == "txtparent") {

            document.getElementById('txtparent').value = "";
            return false;
        }


    }




    if (event.keyCode == 27) {
        document.getElementById("divclien").style.display = "none";

    }

    if (event.keyCode == 113) {

        if (document.activeElement.id == "txtparent") {
            document.getElementById("divclien").style.display = "block";
            document.getElementById('divclien').style.top = 190 + "px";
            document.getElementById('divclien').style.left = 570 + "px";
            ClientMaster.bindclient(document.getElementById('hiddencompcode').value, document.getElementById('txtparent').value, bindclientname_callba);
        }


    }








    ////////


    if (event.keyCode == 9) {





        if (document.activeElement.id == "lstclien") {

            insertclien();

            return false;
        }






    }


}


function insertclien(event) {

    if (event.keyCode == 27) {
        document.getElementById("divclien").style.display = "none";

    }


    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstclien") {
            if (document.getElementById('lstclien').value == "0") {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclien").style.display = "none";


            var page = document.getElementById('lstclien').value;


            agencycodeglo = page;


            var id = "";

            if (browser != "Microsoft Internet Explorer") {
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }

                httpRequest.onreadystatechange = function() { alertContents_name(httpRequest) };


                httpRequest.open('GET', "AgencyNameList.aspx?page=" + page + "&value=1", false);
                httpRequest.send('');
                id = httpRequest.responseText;



            }
            else if (browser == "Microsoft Internet Explorer") {

                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open("GET", "AgencyNameList.aspx?page=" + page + "&value=1", false);
                xml.Send();
                id = xml.responseText;


            }


            //          var xml = new ActiveXObject("Microsoft.XMLHTTP");
            //          xml.Open( "GET","AgencyNameList.aspx?page="+page+"&value=1", false );
            //          xml.Send();


            //  var id=xml.responseText;
            var split = id.split("+");

            var nameagen = split[0];
            var agenadd1 = split[1];
            var agenadd2 = split[2];
            var agenadd3 = split[3];



            document.getElementById('txtparent').value = nameagen;



            nam = agenadd1;

            document.getElementById("divclien").style.display = 'none';

            return false;
        }


    }

}



function bindclientname_callba(response) {

    ds = response.value;
    var pkgitem = document.getElementById("lstclien");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Client-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        //alert(pkgitem);


        //alert(pkgitem.options.length);
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name, ds.Tables[0].Rows[i].Cust_Code);

            pkgitem.options.length;

        }

    }
    document.getElementById('txtparent').value = "";
    document.getElementById("lstclien").value = "0";
    document.getElementById("lstclien").focus();

    return false;
}


function getclintname(a) {

    document.getElementById('hiddencompcode').value
    var ds = "";
    var returnval = ""
    var split = "";
    if (a != "" || a != "undefined") {

        ds = ClientMaster.getclintna(document.getElementById('hiddencompcode').value, a);
        if (ds.value != "" || ds.value != "null") {
            return ds.value;

            // var dsnew = ds.value;
        }
        else {
            return returnval;

        }

    }




}
function openremarkpopup() {
    var custcode1 = document.getElementById('txtcustcode').value;
    var type1 = "C";
    window.open('AgencyClientRemark.aspx?custcode=' + custcode1 + '&type=' + type1, 'bhati1', 'resizable=1,left=0,top=0,scrollbars=yes,width=' + screen.availWidth + ',height=' + screen.availHeight + '');
    return false
}



