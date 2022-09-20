var flagPrio = "1";

var saurabh_agarwal;
var z = 0;
var flag = "0";
var modify = "0";
var chknamemod;
var cityvar;

var prioriry;

//this flag is for permission
var flag = "";
var hiddentext;
var auto = "";
var hiddentext1 = "";

var hiddendrop = "";

var dspublicationexecute;

var Daily = 1;
var Weekly = 2;
var FortNight = 3;
var Monthly = 4;
var Irregular = 5;

var Magazine;

var glapubcode;
var glapubname;
var glapubalias;
var glalanguage;
var glapubtype;
var glapreodicity;

var browser = navigator.appName;

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
    clickcancle1('PublicationMaster');

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

//var preocity;
//*******************************************************************************//
//**************************This Function For New Button*************************//
//*******************************************************************************/
function newclick1() {
    saurabh_agarwal = 1;
    document.getElementById('txtpubcode').value = "";
    document.getElementById('txtpubname').value = "";
    document.getElementById('txtpubalias').value = "";
    document.getElementById('drplanguage').value = "0";
    document.getElementById('txtpriority').value = "";
    document.getElementById('txtcontactperson').value = "";
    document.getElementById('txteshtabdate').value = "";
    document.getElementById('txtphoneno').value = "";
    document.getElementById('txtfaxno').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('drpcity').value = "0";
    document.getElementById('drpcity').value = "0";
    document.getElementById('txtintegration').value = "";
    $('txtsrvcacc').value = "";
    $('txtsubsrvcacc').value = "";
    $('txtsrvcacc').disabled = false
    $('txtsubsrvcacc').disabled = false;

    document.getElementById('txtphone2').value = "";
    document.getElementById('txtfaxno1').value = "";
    document.getElementById('txtgutter').value = "";
    document.getElementById('txtcolspc').value = "";
    document.getElementById('txthr').value = "";
    document.getElementById('txtmin').value = "";
    document.getElementById('txtproduction').value = "";
    document.getElementById('drpublisher').value = "0";
    document.getElementById('txtmrv').value = "";
    /*change ankur*/
    document.getElementById('txtnoofcolumn').value = "";
    document.getElementById('txtnoofcolumn').disabled = false;
    document.getElementById('drpublisher').disabled = false;
    document.getElementById('txtprefix').value = "";
    //////////////////////////////////////////////////



    chkstatus(FlagStatus);

    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    hiddentext = "new";


    //document.getElementById('txtpubcode').disabled=false;
    if (document.getElementById('hiddenauto').value == 1) {
        document.getElementById('txtpubcode').disabled = true;
    }
    else {
        document.getElementById('txtpubcode').disabled = false;
    }
    document.getElementById('txtpubname').disabled = false;
    document.getElementById('txtpubalias').disabled = false;
    document.getElementById('drplanguage').disabled = false;
    document.getElementById('txtpriority').disabled = false;
    document.getElementById('txtcontactperson').disabled = false;
    document.getElementById('txteshtabdate').disabled = false;
    document.getElementById('txtphoneno').disabled = false;
    document.getElementById('txtfaxno').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('txthr').disabled = false;
    document.getElementById('txtmin').disabled = false;
    document.getElementById('txtproduction').disabled = false;



    document.getElementById('txtphone2').disabled = false;
    document.getElementById('txtfaxno1').disabled = false;
    document.getElementById('txtgutter').disabled = false;
    document.getElementById('txtcolspc').disabled = false;
    document.getElementById('txtprefix').disabled = false;
    document.getElementById('txtmrv').disabled = false;
    document.getElementById('txtmobno').disabled = false;
    document.getElementById('txtintegration').disabled = false;
    //change by kanishk
    $('txtsrvcacc').disabled = false
    $('txtsubsrvcacc').disabled = false;
    //			document.getElementById('txthr').disabled=false;
    //            document.getElementById('txtmin').disabled=false;
    //            document.getElementById('txtproduction').disabled=false;


    if (document.getElementById('txtcountry').style.display != "none") {
        if (document.getElementById('hiddenauto').value == 1) {
            document.getElementById('txtcountry').focus();
        }
        else {
            document.getElementById('txtpubcode').focus();
        }
    }
    else {
        document.getElementById('txtpubname').focus();
    }

    modify = "0";

    document.getElementById('CheckBox1').disabled = false;
    document.getElementById('CheckBox2').disabled = false;
    document.getElementById('CheckBox3').disabled = false;
    document.getElementById('CheckBox4').disabled = false;
    document.getElementById('CheckBox5').disabled = false;
    document.getElementById('CheckBox6').disabled = false;
    document.getElementById('CheckBox7').disabled = false;
    document.getElementById('CheckBox8').disabled = false;


    document.getElementById('CheckBox1').checked = false;
    document.getElementById('CheckBox2').checked = false;
    document.getElementById('CheckBox3').checked = false;
    document.getElementById('CheckBox4').checked = false;
    document.getElementById('CheckBox5').checked = false;
    document.getElementById('CheckBox6').checked = false;
    document.getElementById('CheckBox7').checked = false;
    document.getElementById('CheckBox8').checked = false;


    setButtonImages();
    return false;
}

//*******************************************************************************//
//**************************This Function For save Button*************************//
//*******************************************************************************//

function saveclicknew() {
    if (flagPrio == "0") {
        return false;
    }
    document.getElementById('txtpubname').value = trim(document.getElementById('txtpubname').value);
    document.getElementById('txtpubalias').value = trim(document.getElementById('txtpubalias').value);
    document.getElementById('txtpubcode').value = trim(document.getElementById('txtpubcode').value);
    document.getElementById('txtcontactperson').value = trim(document.getElementById('txtcontactperson').value);
    document.getElementById('txtmrv').value = trim(document.getElementById('txtmrv').value);
    document.getElementById('txtmobno').value = trim(document.getElementById('txtmobno').value);
    document.getElementById('txtintegration').value = trim(document.getElementById('txtintegration').value);
    document.getElementById('txtsrvcacc').value = trim(document.getElementById('txtsrvcacc').value);
    document.getElementById('txtsubsrvcacc').value = trim(document.getElementById('txtsubsrvcacc').value);

    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('userid1').value;
    var pubcode = document.getElementById('txtpubcode').value;


    if (document.getElementById('txtcountry').value != 0 || document.getElementById('txtcountry').style.display == "none") {
        var pubtype = document.getElementById('txtcountry').value;
    }
    else {
        alert("Please Select Publication Type");
        document.getElementById('txtcountry').focus();
        return false;
    }

    if (document.getElementById('hiddenauto').value != 1) {
        if (document.getElementById('txtpubcode').value == "") {
            alert("Please Enter the Publication Code");
            document.getElementById('txtpubcode').focus();
            return false;
        }
        //return false;
    }

    var pb = trim(document.getElementById('txtpubname').value);

    if (pb != "") {
        var pubname = pb;
    }
    else {
        alert("Please Enter the Publication  Name");
        document.getElementById('txtpubname').value = "";
        document.getElementById('txtpubname').focus();
        return false;
    }

    var pa = trim(document.getElementById('txtpubalias').value);

    if (pa != "") {
        var pubalias = pa;
    }
    else {
        alert("Please Enter the Alias Name");
        document.getElementById('txtpubalias').value = "";
        document.getElementById('txtpubalias').focus();
        return false;
    }


    if (document.getElementById('drplanguage').value != 0) {
        var langcode = document.getElementById('drplanguage').value;
    }
    else {
        alert("Please Select Language");
        document.getElementById('drplanguage').focus();
        return false;
    }

    if (document.getElementById('drpcity').value != 0) {
        var preocity = document.getElementById('drpcity').value;


    }
    else {
        alert("Please Select Periodicity");
        document.getElementById('drpcity').focus();
        return false;
    }

    if (document.getElementById('txtgutter').value != "" || document.getElementById('tr3').style.display == "none") {
        var gut = document.getElementById('txtgutter').value;
    }
    else {
        if (browser != "Microsoft Internet Explorer") {
            if (document.getElementById('lbgutter').textContent.indexOf('*') >= 0) {
                alert("Please Enter Gutter Width");
                document.getElementById('txtgutter').focus();
                return false;
            }
        }
        else {

            if (document.getElementById('lbgutter').innerText.indexOf('*') >= 0) {
                alert("Please Enter Gutter Width");
                document.getElementById('txtgutter').focus();
                return false;
            }

        }
    }

    if (document.getElementById('txtcolspc').value != "" || document.getElementById('tr3').style.display == "none") {
        var colspc = document.getElementById('txtcolspc').value;
    }
    else {
        if (browser != "Microsoft Internet Explorer") {
            if (document.getElementById('lbcolspc').textContent.indexOf('*') >= 0) {
                alert("Please Enter Column Width");
                document.getElementById('txtcolspc').focus();
                return false;
            }
        }
        else {
            if (document.getElementById('lbcolspc').innerText.indexOf('*') >= 0) {
                alert("Please Enter Column Width");
                document.getElementById('txtcolspc').focus();
                return false;
            }
        }
    }

    if (document.getElementById('txthr').value != "") {
        var hr = document.getElementById('txthr').value;
    }

    var mint;
    if (document.getElementById('txtmin').value == "") {
        var mint = "";

    }
    else {
        var mint = document.getElementById('txtmin').value;
    }


    if (document.getElementById('txtproduction').value != "" || document.getElementById('tr5').style.display == "none") {
        var prod = document.getElementById('txtproduction').value;
    }

    if (document.getElementById('txthr').value == "" && document.getElementById('tr4').style.display != "none") {
        if (document.getElementById('txtmin').value == "") {
            if (document.getElementById('txtproduction').value == "") {
                alert("Please Enter the value for either 'RO Acceptance Time' or 'Production Day(s) Before' or both ");
                document.getElementById('txthr').focus();
                return false;
            }
        }
    }


    if (document.getElementById('CheckBox1').checked != true && document.getElementById('CheckBox2').checked != true && document.getElementById('CheckBox3').checked != true && document.getElementById('CheckBox4').checked != true && document.getElementById('CheckBox5').checked != true && document.getElementById('CheckBox6').checked != true && document.getElementById('CheckBox7').checked != true && document.getElementById('CheckBox8').checked != true) {
        alert("Please Select Publication Day(s)...");
        return false;
    }





    if (document.getElementById('drpcity').value == "FORTNIGHT" || document.getElementById('drpcity').value == "IRREGULAR" || document.getElementById('drpcity').value == "MONTHLY") {
        if (document.getElementById('txteshtabdate').value != "") {
            var preocity = document.getElementById('drpcity').value;
            // return false;
        }
        else {
            alert("please select  start date");
            document.getElementById('txteshtabdate').focus();
            return false;
        }

    }
    else {
        var preocity = document.getElementById('drpcity').value;
        //return false;

    }


    if (document.getElementById('txtcountry').value == "MAGAZINE") {
        if (document.getElementById('drpcity').value == "DAILY" || document.getElementById('drpcity').value == "WEEKLY") {
            //				     var pubtype=document.getElementById('txtcountry').value;

            alert("These Value is Not Allow");
            document.getElementById('drpcity').focus();
            return false;

        }
        else {

            //				      alert("These VAlue is Not Allow");
            //				      document.getElementById('drpcity').focus();
            //				      return false;
            var pubtype = document.getElementById('txtcountry').value;

        }

    }
    else {
        var pubtype = document.getElementById('txtcountry').value;

    }

    var bc = "";

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbPriority').textContent;
    }
    else {
        bc = document.getElementById('lbPriority').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (trim(document.getElementById('txtpriority').value) == "" && document.getElementById('lbPriority').style.display != "none") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtpriority').focus();
            return false;
        }
    }



    var compcode = document.getElementById('hiddencompcode').value;
    var priority = parseInt(document.getElementById('txtpriority').value);
    var publishercode = document.getElementById('drpublisher').value;
    var dateformat = document.getElementById('hiddendateformat').value;

    if (dateformat == "dd/mm/yyyy") {
        if (document.getElementById('txteshtabdate').value != "") {
            var txt = document.getElementById('txteshtabdate').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            var txtdob = mm + '/' + dd + '/' + yy;
        }
        else {
            var txtdob = document.getElementById('txteshtabdate').value;
        }

    }
    if (dateformat == "yyyy/mm/dd") {
        if (document.getElementById('txteshtabdate').value != "") {
            var txt = document.getElementById('txteshtabdate').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            var txtdob = mm + '/' + dd + '/' + yy;
        }
        else {
            var txtdob = document.getElementById('txteshtabdate').value;
        }
    }
    //if(dateformat=="mm/dd/yyyy")
    //{
    //var txtdob=document.getElementById('txteshtabdate').value;
    //}
    //if(dateformat==null || dateformat=="" || dateformat=="undefined")
    //{
    //var txtdob=document.getElementById('txteshtabdate').value;
    //}
    var myDate = dateformat;
    var chunks = myDate.split('/');
    var formattedDate = chunks[1] + '/' + chunks[0] + '/' + chunks[2];
    var contaperson = document.getElementById('txtcontactperson').value;

    var phone = document.getElementById('txtphoneno').value;
    var fax = document.getElementById('txtfaxno').value;
    var emailid = document.getElementById('txtemailid').value;
    var userid = document.getElementById('userid1').value;

    var phone2 = document.getElementById('txtphone2').value;
    var fax2 = document.getElementById('txtfaxno1').value;

    var gut = document.getElementById('txtgutter').value;
    var colspc = document.getElementById('txtcolspc').value;

    var hr = document.getElementById('txthr').value;
    var mint = document.getElementById('txtmin').value;
    var prod = document.getElementById('txtproduction').value;
    var MRV = document.getElementById('txtmrv').value;

    /*change ankur*/
    var noofcol = document.getElementById('txtnoofcolumn').value;
    var prefix = document.getElementById('txtprefix').value;
    var MRV = document.getElementById('txtmrv').value;
    var moblieno = document.getElementById('txtmobno').value;
    var integration = document.getElementById('txtintegration').value;

    if (integration == "" || integration == "undefined") {
        var integration = "";
    }
    else {
        var integration = document.getElementById('txtintegration').value;
    }
    var pacc_cd = document.getElementById('hdnsrvcacc').value;
    var psacc_cd = document.getElementById('hdnsubsrvcacc').value;
    //////////////////////////////////////////////////////////

    if (modify == "1") {

        if (chknamemod == document.getElementById('txtpubname').value) {

            var akh = document.getElementById('txtpubcode').value
            selectpubday(akh);

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
            var ip2 = document.getElementById('ip1').value;
            //hiddencompcode, txtpubcode, txtpubname, txtpubalias, drplanguage, txtpriority, txteshtabdate, txtcontactperson, txtphoneno, txtfaxno, txtemailid, userid1, pubtype, preocity, txtphone2, txtfaxno1, txtgutter, txtcolspc, hr, mint, prod, noofcol, publish_code, prefix, MRV, moblieno, pacc_cd, psacc_cd
            PublicationMaster.pubmodify1(compcode, pubcode, pubname, pubalias, langcode, priority, txtdob, contaperson, phone, fax, emailid, userid, pubtype, preocity, phone2, fax2, gut, colspc, hr, mint, prod, noofcol, publishercode, ip2, prefix, MRV, moblieno, integration, pacc_cd, psacc_cd);
            ///////////////////////
            fillcheckboxes(akh);

            updateStatus();

            dspublicationexecute.Tables[0].Rows[z].Pub_Code = document.getElementById('txtpubcode').value;
            dspublicationexecute.Tables[0].Rows[z].Pub_Name = document.getElementById('txtpubname').value;
            dspublicationexecute.Tables[0].Rows[z].pub_alias = document.getElementById('txtpubalias').value;
            dspublicationexecute.Tables[0].Rows[z].Lang_Code = document.getElementById('drplanguage').value;
            dspublicationexecute.Tables[0].Rows[z].Priority = document.getElementById('txtpriority').value;
            dspublicationexecute.Tables[0].Rows[z].Cont_Person = document.getElementById('txtcontactperson').value;
            dspublicationexecute.Tables[0].Rows[z].Phone1 = document.getElementById('txtphone2').value;
            dspublicationexecute.Tables[0].Rows[z].Fax1 = document.getElementById('txtfaxno1').value;
            dspublicationexecute.Tables[0].Rows[z].Phone = document.getElementById('txtphoneno').value;
            dspublicationexecute.Tables[0].Rows[z].Fax = document.getElementById('txtfaxno').value;
            dspublicationexecute.Tables[0].Rows[z].EmailID = document.getElementById('txtemailid').value;
            dspublicationexecute.Tables[0].Rows[z].publication_type = document.getElementById('txtcountry').value;
            dspublicationexecute.Tables[0].Rows[z].preodicity = document.getElementById('drpcity').value;
            dspublicationexecute.Tables[0].Rows[z].Gutter_Space = document.getElementById('txtgutter').value;
            dspublicationexecute.Tables[0].Rows[z].Column_Space = document.getElementById('txtcolspc').value;
            dspublicationexecute.Tables[0].Rows[z].hr = document.getElementById('txthr').value;
            dspublicationexecute.Tables[0].Rows[z].mint = document.getElementById('txtmin').value;
            dspublicationexecute.Tables[0].Rows[z].prod = document.getElementById('txtproduction').value;
            dspublicationexecute.Tables[0].Rows[z].Establish_Date = txtdob;
            dspublicationexecute.Tables[0].Rows[z].PREFIX = document.getElementById('txtprefix').value;
            dspublicationexecute.Tables[0].Rows[z].INTEGTATION_ID = document.getElementById('txtintegration').value;
            /*change ankur*/
            dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn = document.getElementById('txtnoofcolumn').value;
            //change by kanishk
            dspublicationexecute.Tables[0].Rows[z].SAC_CODE = document.getElementById('hdnsrvcacc').value;
            dspublicationexecute.Tables[0].Rows[z].SUB_SAC_CODE = document.getElementById('hdnsubsrvcacc').value;
            dspublicationexecute.Tables[0].Rows[z].MOBILENO = document.getElementById('txtmobno').value;
            ////////////////////////////////////////////////////////////////////
            //dspublicationexecute.Tables[0].Rows[z].High_Priority=hPriority;

            //document.getElementById('chkHPriority1').disabled=true;

            // Saurabh Agarwal
            var x = dspublicationexecute.Tables[0].Rows.length;
            y = z;
            if (z == 0) {
                document.getElementById('btnfirst').disabled = true;
                document.getElementById('btnprevious').disabled = true;
            }

            if (z == (dspublicationexecute.Tables[0].Rows.length - 1)) {
                document.getElementById('btnnext').disabled = true;
                document.getElementById('btnlast').disabled = true;
            }

            //alert("Value Updated Successfully");
            if (browser != "Microsoft Internet Explorer") {
                alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
            }
            else {
                alert(xmlObj.childNodes(0).childNodes(1).text);
            }


            document.getElementById('CheckBox1').disabled = true;
            document.getElementById('CheckBox2').disabled = true;
            document.getElementById('CheckBox3').disabled = true;
            document.getElementById('CheckBox4').disabled = true;
            document.getElementById('CheckBox5').disabled = true;
            document.getElementById('CheckBox6').disabled = true;
            document.getElementById('CheckBox7').disabled = true;
            document.getElementById('CheckBox8').disabled = true;

            document.getElementById('txtpubcode').disabled = true;
            document.getElementById('txtpubname').disabled = true;
            document.getElementById('txtpubalias').disabled = true;
            document.getElementById('drplanguage').disabled = true;
            document.getElementById('txtpriority').disabled = true;
            document.getElementById('txtcontactperson').disabled = true;
            document.getElementById('txteshtabdate').disabled = true;
            document.getElementById('txtphoneno').disabled = true;
            document.getElementById('txtfaxno').disabled = true;
            document.getElementById('txtemailid').disabled = true;
            document.getElementById('txtcountry').disabled = true;
            document.getElementById('drpcity').disabled = true;
            document.getElementById('txtphone2').disabled = true;
            document.getElementById('txtfaxno1').disabled = true;
            document.getElementById('txtgutter').disabled = true;
            document.getElementById('txtcolspc').disabled = true;
            document.getElementById('txthr').disabled = true;
            document.getElementById('txtmin').disabled = true;
            document.getElementById('txtproduction').disabled = true;
            /*change ankur*/
            document.getElementById('txtnoofcolumn').disabled = true;
            document.getElementById('txtprefix').disabled = true;
            document.getElementById('txtmrv').disabled = true;
            document.getElementById('txtmobno').disabled = true;
            ///////////////////////////////////////////////////////
            //change by kanishk
            $('txtsrvcacc').disabled = true;
            $('txtsubsrvcacc').disabled = true;

            setButtonImages();
            return false;

        }
        else {
            PublicationMaster.chkpublicationmast(document.getElementById('txtpubname').value, callmodify);
            //PublicationMaster.publicationcheck(compcode,pubcode,userid,callmodify);
            return false;
        }
    }

    var akh = document.getElementById('txtpubcode').value
    selectpubday(akh);
    //fillcheckboxes(akh);
    PublicationMaster.publicationcheck(compcode, pubcode, userid, callsave);


    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;

    document.getElementById('txtpubcode').disabled = false;
    document.getElementById('txtpubname').disabled = false;
    document.getElementById('txtpubalias').disabled = false;
    document.getElementById('drplanguage').disabled = false;
    document.getElementById('txtpriority').disabled = false;
    document.getElementById('txtcontactperson').disabled = false;
    document.getElementById('txteshtabdate').disabled = false;
    document.getElementById('txtphoneno').disabled = false;
    document.getElementById('txtfaxno').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('txtphone2').disabled = false;
    document.getElementById('txtfaxno1').disabled = false;
    document.getElementById('txtgutter').disabled = false;
    document.getElementById('txtcolspc').disabled = false;
    document.getElementById('txthr').disabled = false;
    document.getElementById('txtmin').disabled = false;
    document.getElementById('txtproduction').disabled = false;
    document.getElementById('txtintegration').disabled = false;
    /*change ankur*/
    document.getElementById('txtnoofcolumn').disabled = false;
    document.getElementById('txtprefix').disabled = false;
    ///////////////////////////////////////////////////////
    //change by kanishk
    $('txtsrvcacc').disabled = false
    $('txtsubsrvcacc').disabled = false;



    return false;
}
//*******************************************************************************//

function callmodify(res) {
    var ds = res.value;
    if (ds.Tables[0].Rows.length > 0) {
        alert("This Publication  Name Already Exist");
        //document.getElementById('txtpubcode').value="";
        document.getElementById('txtpubname').value = "";
        return false;
    }
    else {
        if (document.getElementById('txtcountry').value != 0 || document.getElementById('txtcountry').style.display == "none") {
            var pubtype = document.getElementById('txtcountry').value;
        }
        else {
            alert("Please Select Publication Type");
            document.getElementById('txtcountry').focus();
            return false;
        }

        if (document.getElementById('hiddenauto').value != 1) {
            if (document.getElementById('txtpubcode').value == "") {
                alert("Please Enter the Publication Code");
                document.getElementById('txtpubcode').focus();
                return false;
            }
            //return false;
        }

        var pb = trim(document.getElementById('txtpubname').value);

        if (pb != "") {
            var pubname = pb;
        }
        else {
            alert("Please Enter the Publication  Name");
            document.getElementById('txtpubname').value = "";
            document.getElementById('txtpubname').focus();
            return false;
        }

        var pa = trim(document.getElementById('txtpubalias').value);

        if (pa != "") {
            var pubalias = pa;
        }
        else {
            alert("Please Enter the Alias Name");
            document.getElementById('txtpubalias').value = "";
            document.getElementById('txtpubalias').focus();
            return false;
        }


        if (document.getElementById('drplanguage').value != 0) {
            var langcode = document.getElementById('drplanguage').value;
        }
        else {
            alert("Please Select Language");
            document.getElementById('drplanguage').focus();
            return false;
        }

        if (document.getElementById('drpcity').value != 0) {
            var preocity = document.getElementById('drpcity').value;


        }
        else {
            alert("Please Select Periodicity");
            document.getElementById('drpcity').focus();
            return false;
        }

        if (document.getElementById('txtgutter').value != "" || document.getElementById('tr3').style.display == "none") {
            var gut = document.getElementById('txtgutter').value;
        }
        else {
            alert("Please Enter Gutter Width");
            document.getElementById('txtgutter').focus();
            return false;
        }

        if (document.getElementById('txtcolspc').value != "" || document.getElementById('tr3').style.display == "none") {
            var colspc = document.getElementById('txtcolspc').value;
        }
        else {
            alert("Please Enter Column Width");
            document.getElementById('txtcolspc').focus();
            return false;
        }

        if (document.getElementById('txthr').value != "") {
            var hr = document.getElementById('txthr').value;
        }

        var mint;
        if (document.getElementById('txtmin').value == "") {
            mint = "";

        }
        else {
            mint = document.getElementById('txtmin').value;
        }


        if (document.getElementById('txtproduction').value != "" || document.getElementById('tr5').style.display == "none") {
            var prod = document.getElementById('txtproduction').value;
        }

        if (document.getElementById('txthr').value == "" && document.getElementById('tr4').style.display != "none") {
            if (document.getElementById('txtmin').value == "") {
                if (document.getElementById('txtproduction').value == "") {
                    alert("Please Enter the value for either 'RO Acceptance Time' or 'Production Day(s) Before' or both ");
                    document.getElementById('txthr').focus();
                    return false;
                }
            }
        }


        if (document.getElementById('CheckBox1').checked != true && document.getElementById('CheckBox2').checked != true && document.getElementById('CheckBox3').checked != true && document.getElementById('CheckBox4').checked != true && document.getElementById('CheckBox5').checked != true && document.getElementById('CheckBox6').checked != true && document.getElementById('CheckBox7').checked != true && document.getElementById('CheckBox8').checked != true) {
            alert("Please Select Publication Day(s)...");
            return false;
        }





        if (document.getElementById('drpcity').value == "FORTNIGHT" || document.getElementById('drpcity').value == "IRREGULAR" || document.getElementById('drpcity').value == "MONTHLY") {
            if (document.getElementById('txteshtabdate').value != "") {
                var preocity = document.getElementById('drpcity').value;
                // return false;
            }
            else {
                alert("please select  start date");
                document.getElementById('txteshtabdate').focus();
                return false;
            }

        }
        else {
            var preocity = document.getElementById('drpcity').value;
            //return false;

        }


        if (document.getElementById('txtcountry').value == "MAGAZINE") {
            if (document.getElementById('drpcity').value == "DAILY" || document.getElementById('drpcity').value == "WEEKLY") {
                //				     var pubtype=document.getElementById('txtcountry').value;

                alert("These Value is Not Allow");
                document.getElementById('drpcity').focus();
                return false;

            }
            else {

                //				      alert("These VAlue is Not Allow");
                //				      document.getElementById('drpcity').focus();
                //				      return false;
                var pubtype = document.getElementById('txtcountry').value;

            }

        }
        else {
            var pubtype = document.getElementById('txtcountry').value;

        }

        var bc = "";

        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbPriority').textContent;
        }
        else {
            bc = document.getElementById('lbPriority').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (trim(document.getElementById('txtpriority').value) == "" && document.getElementById('lbPriority').style.display != "none") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtpriority').focus();
                return false;
            }
        }

        var pubcode = document.getElementById('txtpubcode').value;
        var compcode = document.getElementById('hiddencompcode').value;
        var priority = parseInt(document.getElementById('txtpriority').value);
        var publishercode = document.getElementById('drpublisher').value;
        var dateformat = document.getElementById('hiddendateformat').value;

        if (dateformat == "dd/mm/yyyy") {
            if (document.getElementById('txteshtabdate').value != "") {
                var txt = document.getElementById('txteshtabdate').value;
                var txt1 = txt.split("/");
                var dd = txt1[0];
                var mm = txt1[1];
                var yy = txt1[2];
                var txtdob = mm + '/' + dd + '/' + yy;
            }
            else {
                var txtdob = document.getElementById('txteshtabdate').value;
            }

        }
        if (dateformat == "yyyy/mm/dd") {
            if (document.getElementById('txteshtabdate').value != "") {
                var txt = document.getElementById('txteshtabdate').value;
                var txt1 = txt.split("/");
                var yy = txt1[0];
                var mm = txt1[1];
                var dd = txt1[2];
                var txtdob = mm + '/' + dd + '/' + yy;
            }
            else {
                var txtdob = document.getElementById('txteshtabdate').value;
            }
        }
        if (dateformat == "mm/dd/yyyy") {
            var txtdob = document.getElementById('txteshtabdate').value;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            var txtdob = document.getElementById('txteshtabdate').value;
        }

        var contaperson = document.getElementById('txtcontactperson').value;
        var phone = document.getElementById('txtphoneno').value;
        var fax = document.getElementById('txtfaxno').value;
        var emailid = document.getElementById('txtemailid').value;
        var userid = document.getElementById('userid1').value;

        var phone2 = document.getElementById('txtphone2').value;
        var fax2 = document.getElementById('txtfaxno1').value;

        var gut = document.getElementById('txtgutter').value;
        var colspc = document.getElementById('txtcolspc').value;

        var hr = document.getElementById('txthr').value;
        var mint = document.getElementById('txtmin').value;
        var prod = document.getElementById('txtproduction').value;

        /*change ankur*/
        var noofcol = document.getElementById('txtnoofcolumn').value;

        var akh = document.getElementById('txtpubcode').value
        var prod = document.getElementById('txtprefix').value;
        var prefix = document.getElementById('txtprefix').value;
        selectpubday(akh);


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
        var MRV = document.getElementById('txtmrv').value;
        var moblieno = document.getElementById('txtmobno').value;
        var ip2 = document.getElementById('ip1').value;
        var integration = document.getElementById('txtintegration').value;
        //change by kanishk
        var acc_cd = document.getElementById('txtsrvcacc').value;
        var sacc_cd = document.getElementById('txtsubsrvcacc').value;
        PublicationMaster.pubmodify1(compcode, pubcode, pubname, pubalias, langcode, priority, txtdob, contaperson, phone, fax, emailid, userid, pubtype, preocity, phone2, fax2, gut, colspc, hr, mint, prod, noofcol, publishercode, ip2, prefix, MRV, moblieno, integration, acc_cd, sacc_cd);
        ///////////////////////
        fillcheckboxes(akh);

        updateStatus();

        dspublicationexecute.Tables[0].Rows[z].Pub_Code = document.getElementById('txtpubcode').value;
        dspublicationexecute.Tables[0].Rows[z].Pub_Name = document.getElementById('txtpubname').value;
        dspublicationexecute.Tables[0].Rows[z].pub_alias = document.getElementById('txtpubalias').value;
        dspublicationexecute.Tables[0].Rows[z].Lang_Code = document.getElementById('drplanguage').value;
        dspublicationexecute.Tables[0].Rows[z].Priority = document.getElementById('txtpriority').value;
        dspublicationexecute.Tables[0].Rows[z].Cont_Person = document.getElementById('txtcontactperson').value;
        dspublicationexecute.Tables[0].Rows[z].Phone1 = document.getElementById('txtphone2').value;
        dspublicationexecute.Tables[0].Rows[z].Fax1 = document.getElementById('txtfaxno1').value;
        dspublicationexecute.Tables[0].Rows[z].Phone = document.getElementById('txtphoneno').value;
        dspublicationexecute.Tables[0].Rows[z].Fax = document.getElementById('txtfaxno').value;
        dspublicationexecute.Tables[0].Rows[z].EmailID = document.getElementById('txtemailid').value;
        dspublicationexecute.Tables[0].Rows[z].publication_type = document.getElementById('txtcountry').value;
        dspublicationexecute.Tables[0].Rows[z].preodicity = document.getElementById('drpcity').value;
        dspublicationexecute.Tables[0].Rows[z].Gutter_Space = document.getElementById('txtgutter').value;
        dspublicationexecute.Tables[0].Rows[z].Column_Space = document.getElementById('txtcolspc').value;
        dspublicationexecute.Tables[0].Rows[z].hr = document.getElementById('txthr').value;
        dspublicationexecute.Tables[0].Rows[z].mint = document.getElementById('txtmin').value;
        dspublicationexecute.Tables[0].Rows[z].prod = document.getElementById('txtproduction').value;
        dspublicationexecute.Tables[0].Rows[z].Establish_Date = txtdob;
        dspublicationexecute.Tables[0].Rows[z].PREFIX = document.getElementById('txtprefix').value;
        dspublicationexecute.Tables[0].Rows[z].INTEGTATION_ID = document.getElementById('txtintegration').value;
        //change by kanishk
        dspublicationexecute.Tables[0].Rows[z].SAC_CODE = document.getElementById('txtsrvcacc').value;
        dspublicationexecute.Tables[0].Rows[z].SUB_SAC_CODE = document.getElementById('txtsubsrvcacc').value;
        /*change ankur*/
        dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn = document.getElementById('txtnoofcolumn').value;;
        ////////////////////////////////////////////////////////////////////
        //dspublicationexecute.Tables[0].Rows[z].High_Priority=hPriority;

        //document.getElementById('chkHPriority1').disabled=true;

        // Saurabh Agarwal
        var x = dspublicationexecute.Tables[0].Rows.length;
        y = z;
        if (z == 0) {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        }

        if (z == (dspublicationexecute.Tables[0].Rows.length - 1)) {
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
        }

        //alert("Value Updated Successfully");
        if (browser != "Microsoft Internet Explorer") {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }


        document.getElementById('CheckBox1').disabled = true;
        document.getElementById('CheckBox2').disabled = true;
        document.getElementById('CheckBox3').disabled = true;
        document.getElementById('CheckBox4').disabled = true;
        document.getElementById('CheckBox5').disabled = true;
        document.getElementById('CheckBox6').disabled = true;
        document.getElementById('CheckBox7').disabled = true;
        document.getElementById('CheckBox8').disabled = true;

        document.getElementById('txtpubcode').disabled = true;
        document.getElementById('txtpubname').disabled = true;
        document.getElementById('txtpubalias').disabled = true;
        document.getElementById('drplanguage').disabled = true;
        document.getElementById('txtpriority').disabled = true;
        document.getElementById('txtcontactperson').disabled = true;
        document.getElementById('txteshtabdate').disabled = true;
        document.getElementById('txtphoneno').disabled = true;
        document.getElementById('txtfaxno').disabled = true;
        document.getElementById('txtemailid').disabled = true;
        document.getElementById('txtcountry').disabled = true;
        document.getElementById('drpcity').disabled = true;
        document.getElementById('txtphone2').disabled = true;
        document.getElementById('txtfaxno1').disabled = true;
        document.getElementById('txtgutter').disabled = true;
        document.getElementById('txtcolspc').disabled = true;
        document.getElementById('txthr').disabled = true;
        document.getElementById('txtmin').disabled = true;
        document.getElementById('txtproduction').disabled = true;
        document.getElementById('txtintegration').disabled = true;
        //change by kanishk
        $('txtsrvcacc').disabled = true
        $('txtsubsrvcacc').disabled = true;
        /*change ankur*/
        document.getElementById('txtnoofcolumn').disabled = true;
        document.getElementById('txtprefix').disabled = true;
        ///////////////////////////////////////////////////////
        setButtonImages();
        return false;
    }
}

//********************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function callsave(res) {
    var ds = res.value;
    if (ds.Tables[0].Rows.length == 0) {
        var compcode = document.getElementById('hiddencompcode').value;
        var pubcode = document.getElementById('txtpubcode').value;
        var pubname = document.getElementById('txtpubname').value;
        var pubalias = document.getElementById('txtpubalias').value;
        var langcode = document.getElementById('drplanguage').value;
        var priority = parseFloat(document.getElementById('txtpriority').value);
        var txtdob = document.getElementById('txteshtabdate').value;
        var contaperson = document.getElementById('txtcontactperson').value;
        var phone = document.getElementById('txtphoneno').value;
        var fax = document.getElementById('txtfaxno').value;
        var emailid = document.getElementById('txtemailid').value;
        var userid = document.getElementById('userid1').value;
        var phone2 = document.getElementById('txtphone2').value;
        var fax2 = document.getElementById('txtfaxno1').value;
        var akh = document.getElementById('txtpubcode').value;
        var pubtype = document.getElementById('txtcountry').value;
        var preocity = document.getElementById('drpcity').value;
        var gut = document.getElementById('txtgutter').value;
        var colspc = document.getElementById('txtcolspc').value;
        var hr = document.getElementById('txthr').value;
        var mint = document.getElementById('txtmin').value;
        var prod = document.getElementById('txtproduction').value;
        var publishercode = document.getElementById('drpublisher').value;
        var dateformat = document.getElementById('hiddendateformat').value;
        /*change ankur*/
        var noofcol = document.getElementById('txtnoofcolumn').value;
        var prefix = document.getElementById('txtprefix').value;
        var MRV = document.getElementById('txtmrv').value;
        var mobileno = document.getElementById('txtmobno').value;
        var integration = document.getElementById('txtintegration').value;
        //change by kanishk
        var acc_cd = document.getElementById('hdnsrvcacc').value;
        var sacc_cd = document.getElementById('hdnsubsrvcacc').value;
        ///////////////////////////////////////////////////////////

        if (dateformat == "dd/mm/yyyy") {
            if (document.getElementById('txteshtabdate').value != "") {
                var txt = document.getElementById('txteshtabdate').value;
                var txt1 = txt.split("/");
                var dd = txt1[0];
                var mm = txt1[1];
                var yy = txt1[2];
                var txtdob = mm + '/' + dd + '/' + yy;
            }
            else {
                var txtdob = document.getElementById('txteshtabdate').value;
            }

        }
        if (dateformat == "yyyy/mm/dd") {
            if (document.getElementById('txteshtabdate').value != "") {
                var txt = document.getElementById('txteshtabdate').value;
                var txt1 = txt.split("/");
                var yy = txt1[0];
                var mm = txt1[1];
                var dd = txt1[2];
                var txtdob = mm + '/' + dd + '/' + yy;
            }
            else {
                var txtdob = document.getElementById('txteshtabdate').value;
            }
        }
        if (dateformat == "mm/dd/yyyy") {
            var txtdob = document.getElementById('txteshtabdate').value;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            var txtdob = document.getElementById('txteshtabdate').value;
        }

        //if()




        selectpubday(akh);

        //PublicationMaster.pubsave1(compcode,priority,pubcode,pubname,pubalias,langcode,txtdob,contaperson,phone,fax,emailid,userid);
        //PublicationMaster.pubsave1(compcode,pubcode);

        /*change ankur*/
        var ip2 = document.getElementById('ip1').value;
        PublicationMaster.pubsave1(compcode, pubcode, pubname, pubalias, langcode, priority, txtdob, contaperson, phone, fax, emailid, userid, pubtype, preocity, phone2, fax2, gut, colspc, hr, mint, prod, noofcol, publishercode, ip2, prefix, MRV, mobileno, integration, acc_cd, sacc_cd);
        ///////////////////

        fillcheckboxes(akh);
        //alert("Saved Successfully");
        if (browser != "Microsoft Internet Explorer") {
            alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
        }
        else {
            alert(xmlObj.childNodes(0).childNodes(0).text);
        }

        document.getElementById('txtpubcode').value = "";
        document.getElementById('txtpubname').value = "";
        document.getElementById('txtpubalias').value = "";
        document.getElementById('drplanguage').value = 0;
        document.getElementById('txtpriority').value = "";
        document.getElementById('txtcontactperson').value = "";
        document.getElementById('txteshtabdate').value = "";
        document.getElementById('txtphoneno').value = "";
        document.getElementById('txtfaxno').value = "";
        document.getElementById('txtemailid').value = "";

        document.getElementById('txtcountry').value = "0";
        document.getElementById('drpcity').value = "0";

        document.getElementById('txtphone2').value = "";
        document.getElementById('txtfaxno1').value = "";

        document.getElementById('txtgutter').value = "";
        document.getElementById('txtcolspc').value = "";
        document.getElementById('txthr').value = "";
        document.getElementById('txtmin').value = "";
        document.getElementById('txtproduction').value = "";
        document.getElementById('drpublisher').value = "0";
        /*change ankur*/
        document.getElementById('txtnoofcolumn').value = "";
        document.getElementById('txtnoofcolumn').disabled = true;
        document.getElementById('txtprefix').value = "";
        document.getElementById('txtmrv').value = "";
        document.getElementById('txtmobno').value = "";
        //////////////////////////////////////////////

        document.getElementById('txtpubcode').disabled = true;
        document.getElementById('txtpubname').disabled = true;
        document.getElementById('txtpubalias').disabled = true;
        document.getElementById('drplanguage').disabled = true;
        document.getElementById('txtpriority').disabled = true;
        document.getElementById('txtcontactperson').disabled = true;
        document.getElementById('txteshtabdate').disabled = true;
        document.getElementById('txtphoneno').disabled = true;
        document.getElementById('txtfaxno').disabled = true;
        document.getElementById('txtemailid').disabled = true;
        document.getElementById('txtcountry').disabled = true;
        document.getElementById('drpcity').disabled = true;
        document.getElementById('txtmrv').disabled = true;

        //change by kanishk
        $('txtsrvcacc').value = "";
        $('txtsubsrvcacc').value = "";
        document.getElementById('txtgutter').disabled = true;
        document.getElementById('txtcolspc').disabled = true;

        document.getElementById('txthr').disabled = true;
        document.getElementById('txtmin').disabled = true;
        document.getElementById('txtproduction').disabled = true;
        document.getElementById('drpublisher').disabled = true;
        document.getElementById('txtphone2').disabled = true;
        document.getElementById('txtfaxno1').disabled = true;
        document.getElementById('txtprefix').disabled = true;
        document.getElementById('txtmobno').disabled = true;

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

        document.getElementById('CheckBox1').checked = false;
        document.getElementById('CheckBox2').checked = false;
        document.getElementById('CheckBox3').checked = false;
        document.getElementById('CheckBox4').checked = false;
        document.getElementById('CheckBox5').checked = false;
        document.getElementById('CheckBox6').checked = false;
        document.getElementById('CheckBox7').checked = false;
        document.getElementById('CheckBox8').checked = false;

        document.getElementById('CheckBox1').disabled = true;
        document.getElementById('CheckBox2').disabled = true;
        document.getElementById('CheckBox3').disabled = true;
        document.getElementById('CheckBox4').disabled = true;
        document.getElementById('CheckBox5').disabled = true;
        document.getElementById('CheckBox6').disabled = true;
        document.getElementById('CheckBox7').disabled = true;
        document.getElementById('CheckBox8').disabled = true;

        clickcancle1('PublicationMaster');
        return false;
    }
    else {
        alert("This Publication Code  Already Exist");
        document.getElementById('txtpubcode').value = "";
        //document.getElementById('txtpubname').value="";
        return false;
    }
    setButtonImages();
    return false;
}

//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function clickmodify1() {
    modify = "1"


    chkstatus(FlagStatus);

    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    hiddentext = "modify";
    //			document.getElementById('btnSave').disabled = false;
    //			document.getElementById('btnQuery').disabled=true;

    document.getElementById('txtpubcode').disabled = true;
    document.getElementById('txtpubname').disabled = false;
    document.getElementById('txtpubalias').disabled = false;
    document.getElementById('drplanguage').disabled = false;
    document.getElementById('txtpriority').disabled = false;
    document.getElementById('txtcontactperson').disabled = false;
    document.getElementById('txteshtabdate').disabled = false;
    document.getElementById('txtphoneno').disabled = false;
    document.getElementById('txtfaxno').disabled = false;
    document.getElementById('txtemailid').disabled = false;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('drpublisher').disabled = false;
    document.getElementById('txtmrv').disabled = false;

    document.getElementById('txtphone2').disabled = false;
    document.getElementById('txtfaxno1').disabled = false;


    document.getElementById('CheckBox1').disabled = false;
    document.getElementById('CheckBox2').disabled = false;
    document.getElementById('CheckBox3').disabled = false;
    document.getElementById('CheckBox4').disabled = false;
    document.getElementById('CheckBox5').disabled = false;
    document.getElementById('CheckBox6').disabled = false;
    document.getElementById('CheckBox7').disabled = false;
    document.getElementById('CheckBox8').disabled = false;

    document.getElementById('txtgutter').disabled = false;
    document.getElementById('txtcolspc').disabled = false;
    document.getElementById('txthr').disabled = false;
    document.getElementById('txtmin').disabled = false;
    document.getElementById('txtproduction').disabled = false;
    document.getElementById('txtintegration').disabled = false;
    //change by kanishk
    $('txtsrvcacc').disabled = false
    $('txtsubsrvcacc').disabled = false;

    /*change ankur*/
    document.getElementById('txtnoofcolumn').disabled = false;
    document.getElementById('txtprefix').disabled = false;
    document.getElementById('txtmobno').disabled = false;

    chknamemod = document.getElementById('txtpubname').value;
    setButtonImages();
    //////////////////////////////////////////////////////
    return false;
}
//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//
function clickquery1() {

    saurabh_agarwal = 0;
    z = 0;
    chkstatus(FlagStatus);

    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').focus();

    hiddentext = "query";

    document.getElementById('txtpubcode').value = "";
    document.getElementById('txtpubname').value = "";
    document.getElementById('txtpubalias').value = "";
    document.getElementById('drplanguage').value = 0;
    document.getElementById('txtpriority').value = "";
    document.getElementById('txtcontactperson').value = "";
    document.getElementById('txteshtabdate').value = "";
    document.getElementById('txtphoneno').value = "";
    document.getElementById('txtfaxno').value = "";
    document.getElementById('txtemailid').value = "";

    document.getElementById('txtgutter').value = "";
    document.getElementById('txtcolspc').value = "";

    document.getElementById('txthr').value = "";
    document.getElementById('txtmin').value = "";
    document.getElementById('txtproduction').value = "";

    document.getElementById('txtcountry').value = "0";
    document.getElementById('drpcity').value = "0";

    document.getElementById('txtphone2').value = "";
    document.getElementById('txtfaxno1').value = "";

    /*change ankur*/
    document.getElementById('txtnoofcolumn').value = "";
    document.getElementById('txtnoofcolumn').disabled = false;
    document.getElementById('txtprefix').value = "";
    document.getElementById('txtintegration').value = "";
    //change by kanishk
    $('txtsrvcacc').value = "";
    $('txtsubsrvcacc').value = "";
    /////////////////////////////////////////////

    document.getElementById('txtpubcode').disabled = false;
    document.getElementById('txtpubname').disabled = false;
    document.getElementById('txtpubalias').disabled = false;
    document.getElementById('drplanguage').disabled = false;
    document.getElementById('txtpriority').disabled = true;
    document.getElementById('txtcontactperson').disabled = true;
    document.getElementById('txteshtabdate').disabled = true;
    document.getElementById('txtphoneno').disabled = true;
    document.getElementById('txtfaxno').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtcountry').disabled = false;
    document.getElementById('drpcity').disabled = false;
    document.getElementById('drpublisher').disabled = false;
    document.getElementById('txtgutter').disabled = true;
    document.getElementById('txtcolspc').disabled = true;
    document.getElementById('txtintegration').disabled = true;

    //change by kanishk
    $('txtsrvcacc').disabled = true
    $('txtsubsrvcacc').disabled = true;
    document.getElementById('txthr').disabled = true;
    document.getElementById('txtmin').disabled = true;
    document.getElementById('txtproduction').disabled = true;

    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtfaxno1').disabled = true;
    document.getElementById('txtprefix').disabled = true;

    document.getElementById('CheckBox1').disabled = true;
    document.getElementById('CheckBox2').disabled = true;
    document.getElementById('CheckBox3').disabled = true;
    document.getElementById('CheckBox4').disabled = true;
    document.getElementById('CheckBox5').disabled = true;
    document.getElementById('CheckBox6').disabled = true;
    document.getElementById('CheckBox7').disabled = true;
    document.getElementById('CheckBox8').disabled = true;

    document.getElementById('CheckBox1').checked = false;
    document.getElementById('CheckBox2').checked = false;
    document.getElementById('CheckBox3').checked = false;
    document.getElementById('CheckBox4').checked = false;
    document.getElementById('CheckBox5').checked = false;
    document.getElementById('CheckBox6').checked = false;
    document.getElementById('CheckBox7').checked = false;
    document.getElementById('CheckBox8').checked = false;


    setButtonImages();
    return false;
}

//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//
function clickcancle1(formname) {

    chkstatus(FlagStatus);
    givebuttonpermission(formname);


    document.getElementById('txtpubcode').value = "";
    document.getElementById('txtpubname').value = "";
    document.getElementById('txtpubalias').value = "";
    document.getElementById('drplanguage').value = 0;
    document.getElementById('txtpriority').value = "";
    document.getElementById('txtcontactperson').value = "";
    document.getElementById('txteshtabdate').value = "";
    document.getElementById('txtphoneno').value = "";
    document.getElementById('txtfaxno').value = "";
    document.getElementById('txtemailid').value = "";


    document.getElementById('txtgutter').value = "";
    document.getElementById('txtcolspc').value = "";

    document.getElementById('txthr').value = "";
    document.getElementById('txtmin').value = "";
    document.getElementById('txtproduction').value = "";
    document.getElementById('drpublisher').value = "0";
    document.getElementById('txtcountry').value = "0";
    document.getElementById('drpcity').value = "0";

    document.getElementById('txtphone2').value = "";
    document.getElementById('txtfaxno1').value = "";

    /*change ankur*/
    document.getElementById('txtnoofcolumn').value = "";
    document.getElementById('txtnoofcolumn').disabled = true;
    document.getElementById('txtprefix').value = "";
    document.getElementById('txtmrv').value = "";
    document.getElementById('txtmobno').value = "";
    document.getElementById('txtintegration').value = "";
    //change by kanishk
    $('txtsrvcacc').value = "";
    $('txtsubsrvcacc').value = "";

    ///////////////////////////////////////////////


    document.getElementById('txtpubcode').disabled = true;
    document.getElementById('txtpubname').disabled = true;
    document.getElementById('txtpubalias').disabled = true;
    document.getElementById('drplanguage').disabled = true;
    document.getElementById('txtpriority').disabled = true;
    document.getElementById('txtcontactperson').disabled = true;
    document.getElementById('txteshtabdate').disabled = true;
    document.getElementById('txtphoneno').disabled = true;
    document.getElementById('txtfaxno').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('drpcity').disabled = true;
    document.getElementById('drpublisher').disabled = true;
    document.getElementById('txtgutter').disabled = true;
    document.getElementById('txtcolspc').disabled = true;
    document.getElementById('txtmrv').disabled = true;

    document.getElementById('txthr').disabled = true;
    document.getElementById('txtmin').disabled = true;
    document.getElementById('txtproduction').disabled = true;

    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtfaxno1').disabled = true;
    document.getElementById('txtprefix').disabled = true;

    document.getElementById('CheckBox1').checked = false;
    document.getElementById('CheckBox2').checked = false;
    document.getElementById('CheckBox3').checked = false;
    document.getElementById('CheckBox4').checked = false;
    document.getElementById('CheckBox5').checked = false;
    document.getElementById('CheckBox6').checked = false;
    document.getElementById('CheckBox7').checked = false;
    document.getElementById('CheckBox8').checked = false;

    document.getElementById('CheckBox1').disabled = true;
    document.getElementById('CheckBox2').disabled = true;
    document.getElementById('CheckBox3').disabled = true;
    document.getElementById('CheckBox4').disabled = true;
    document.getElementById('CheckBox5').disabled = true;
    document.getElementById('CheckBox6').disabled = true;
    document.getElementById('CheckBox7').disabled = true;
    document.getElementById('CheckBox8').disabled = true;
    document.getElementById('txtintegration').disabled = true;
    //change by kanishk
    $('txtsrvcacc').disabled = true
    $('txtsubsrvcacc').disabled = true;
    document.getElementById('txtmobno').disabled = true;

    if (document.getElementById('btnNew').disable == false)
        document.getElementById('btnNew').focus();
    setButtonImages();
    return false;
}
//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//
function clickexecute1() {

    //var glapubcode;
    //var glapubname;
    //var glapubalias;
    //var glalanguage;
    //var glapubtype;
    //var glapreodicity;

    var compcode = document.getElementById('hiddencompcode').value;
    var pubcode = document.getElementById('txtpubcode').value;
    glapubcode = pubcode;
    var pubname = document.getElementById('txtpubname').value;
    glapubname = pubname;
    var pubalias = document.getElementById('txtpubalias').value;
    glapubalias = pubalias;
    var langcode = document.getElementById('drplanguage').value;
    glalanguage = langcode;
    var userid = document.getElementById('userid1').value;
    var pubtype = document.getElementById('txtcountry').value;
    glapubtype = pubtype;

    var phone2 = document.getElementById('txtphone2').value;
    var fax2 = document.getElementById('txtfaxno1').value;
    var integration = document.getElementById('txtintegration').value;
    //change by kanishk
    var acc_cd = document.getElementById('txtsrvcacc').value;
    var sacc_cd = document.getElementById('txtsubsrvcacc').value;
    var preocity = document.getElementById('drpcity').value;
    var MRV = document.getElementById('txtmrv').value;
    //		    var hr=document.getElementById('txthr').value;
    //            var mint=document.getElementById('txtmin').value;
    //            var prod=document.getElementById('txtproduction').value;

    glapreodicity = preocity;

    ////	    	var gtrspc=document.getElementById('txtgutter').value;
    ////            var colspc=document.getElementById('txtcolspc').value;

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
    PublicationMaster.pubexecute1(compcode, pubcode, pubname, pubalias, langcode, pubtype, preocity, executeresponse);//,userid



    updateStatus();
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnModify').disabled == false;
    if (document.getElementById('btnModify').disabled == false)
        document.getElementById('btnModify').focus();

    return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	

function executeresponse(response) {


    //var ds=response.value;
    dspublicationexecute = response.value;
    if (dspublicationexecute.Tables[0].Rows.length > 0) {
        document.getElementById('txtpubcode').value = dspublicationexecute.Tables[0].Rows[0].Pub_Code;
        document.getElementById('txtpubname').value = dspublicationexecute.Tables[0].Rows[0].Pub_Name;
        document.getElementById('txtpubalias').value = dspublicationexecute.Tables[0].Rows[0].pub_alias;
        document.getElementById('drplanguage').value = dspublicationexecute.Tables[0].Rows[0].Lang_Code;
        document.getElementById('txtpriority').value = dspublicationexecute.Tables[0].Rows[0].Priority;        
        document.getElementById('txtmrv').value = dspublicationexecute.Tables[0].Rows[0].MRV_MEMBER_CODE;
        document.getElementById('txtmobno').value = dspublicationexecute.Tables[0].Rows[0].MOBILENO;       
        document.getElementById('txtintegration').value = dspublicationexecute.Tables[0].Rows[0].INTEGRATION_ID;     
        document.getElementById('txtsrvcacc').value = dspublicationexecute.Tables[0].Rows[0].SAC_CODE;
        document.getElementById('txtsubsrvcacc').value = dspublicationexecute.Tables[0].Rows[0].SUB_SAC_CODE;
        document.getElementById('txtcontactperson').value = dspublicationexecute.Tables[0].Rows[0].Cont_Person;      
        document.getElementById('txtcountry').value = dspublicationexecute.Tables[0].Rows[0].publication_type;
        document.getElementById('txtgutter').value = dspublicationexecute.Tables[0].Rows[0].Gutter_Space;
        document.getElementById('txtcolspc').value = dspublicationexecute.Tables[0].Rows[0].Column_Space;

        if (dspublicationexecute.Tables[0].Rows[0].hr != null) {
            document.getElementById('txthr').value = dspublicationexecute.Tables[0].Rows[0].hr;
        }
        else {
            document.getElementById('txthr').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].mint != null) {
            document.getElementById('txtmin').value = dspublicationexecute.Tables[0].Rows[0].mint;
        }
        else {
            document.getElementById('txtmin').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].prod != null) {
            document.getElementById('txtproduction').value = dspublicationexecute.Tables[0].Rows[0].prod;
        }
        else {
            document.getElementById('txtproduction').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].Phone1 != null) {
            document.getElementById('txtphone2').value = dspublicationexecute.Tables[0].Rows[0].Phone1;
        }
        else {
            document.getElementById('txtphone2').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].Fax1 != null) {
            document.getElementById('txtfaxno1').value = dspublicationexecute.Tables[0].Rows[0].Fax1;
        }
        else {
            document.getElementById('txtfaxno1').value = "";
        }

        //		     cityvar=dspublicationexecute.Tables[0].Rows[0].City_Code;
        //			addcount(dspublicationexecute.Tables[0].Rows[0].Country_Code);
        document.getElementById('drpcity').value = dspublicationexecute.Tables[0].Rows[0].preodicity;
        /*change ankur*/
        if (dspublicationexecute.Tables[0].Rows[0].No_Of_Collumn != null) {
            document.getElementById('txtnoofcolumn').value = dspublicationexecute.Tables[0].Rows[0].No_Of_Collumn;
        }
        else {
            document.getElementById('txtnoofcolumn').value = "";
        }

        if (dspublicationexecute.Tables[0].Rows[0].PUBLISHER_CODE != null) {
            document.getElementById('drpublisher').value = dspublicationexecute.Tables[0].Rows[0].PUBLISHER_CODE;
        }
        else {
            document.getElementById('drpublisher').value = "0";
        }

        if (dspublicationexecute.Tables[0].Rows[0].PREFIX != null) {
            document.getElementById('txtprefix').value = dspublicationexecute.Tables[0].Rows[0].PREFIX;
        }
        else {
            document.getElementById('txtprefix').value = "";
        }
        ///////////////////////////////////////////////////

        var akh = document.getElementById('txtpubcode').value;
        fillcheckboxes(akh);


        var dateformat = document.getElementById('hiddendateformat').value;
        if (dspublicationexecute.Tables[0].Rows[0].Establish_Date == null || dspublicationexecute.Tables[0].Rows[0].Establish_Date == "") {
            document.getElementById('txteshtabdate').value = "";
        }
        else {
            var enrolldate = dspublicationexecute.Tables[0].Rows[0].Establish_Date;
            var dd = enrolldate.getDate();
            var mm = enrolldate.getMonth() + 1;
            var yyyy = enrolldate.getFullYear();

            //var enrolldate1=mm+'/'+dd+'/'+yyyy;
            if (dateformat == "dd/mm/yyyy") {
                var enrolldate1 = dd + '/' + mm + '/' + yyyy;
            }
            if (dateformat == "yyyy/mm/dd") {
                var enrolldate1 = yyyy + '/' + mm + '/' + dd;
            }
            if (dateformat == "mm/dd/yyyy") {
                var enrolldate1 = mm + '/' + dd + '/' + yyyy;
            }
            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                var enrolldate1 = mm + '/' + dd + '/' + yyyy;
            }
            document.getElementById('txteshtabdate').value = enrolldate1;
        }

        if (dspublicationexecute.Tables[0].Rows[0].Phone != null) {
            document.getElementById('txtphoneno').value = dspublicationexecute.Tables[0].Rows[0].Phone;
        }
        else {
            document.getElementById('txtphoneno').value = "";
        }

        if (dspublicationexecute.Tables[0].Rows[0].Fax != null) {
            document.getElementById('txtfaxno').value = dspublicationexecute.Tables[0].Rows[0].Fax;
        }
        else {
            document.getElementById('txtfaxno').value = "";
        }

        if (dspublicationexecute.Tables[0].Rows[0].EmailID != null) {
            document.getElementById('txtemailid').value = dspublicationexecute.Tables[0].Rows[0].EmailID;
        }
        else {
            document.getElementById('txtemailid').value = "";
        }
        document.getElementById('txtpubcode').disabled = true;
        document.getElementById('txtpubname').disabled = true;
        document.getElementById('txtpubalias').disabled = true;
        document.getElementById('drplanguage').disabled = true;
        document.getElementById('txtpriority').disabled = true;
        document.getElementById('txtcontactperson').disabled = true;
        document.getElementById('txteshtabdate').disabled = true;
        document.getElementById('txtphoneno').disabled = true;
        document.getElementById('txtfaxno').disabled = true;
        document.getElementById('txtemailid').disabled = true;
        document.getElementById('txtcountry').disabled = true;
        document.getElementById('drpcity').disabled = true;
        document.getElementById('drpublisher').disabled = true;
        document.getElementById('txtgutter').disabled = true;
        document.getElementById('txtcolspc').disabled = true;

        document.getElementById('txthr').disabled = true;
        document.getElementById('txtmin').disabled = true;
        document.getElementById('txtproduction').disabled = true;
        document.getElementById('txtintegration').disabled = true;
        //change by kanishk
        $('txtsrvcacc').disabled = true
        $('txtsubsrvcacc').disabled = true;
        document.getElementById('txtphone2').disabled = true;
        document.getElementById('txtfaxno1').disabled = true;

        /*change ankur*/
        document.getElementById('txtnoofcolumn').disabled = true;
        document.getElementById('txtprefix').disabled = true;
        ///////////////////////////////////////////////////

        if (dspublicationexecute.Tables[0].Rows.length == 1) {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
            //document.getElementById('btnExit').disabled=false;
            document.getElementById('btnprevious').disabled = true;

        }
        document.getElementById('btnModify').disabled = false;
        setButtonImages();
        //document.getElementById('btnModify').enabled == true;
        return false;
    }
    else {

        document.getElementById('txtpubcode').disabled = true;
        document.getElementById('txtpubname').disabled = true;
        document.getElementById('txtpubalias').disabled = true;
        document.getElementById('drplanguage').disabled = true;
        document.getElementById('txtpriority').disabled = true;
        document.getElementById('txtcontactperson').disabled = true;
        document.getElementById('txteshtabdate').disabled = true;
        document.getElementById('txtphoneno').disabled = true;
        document.getElementById('txtfaxno').disabled = true;
        document.getElementById('txtemailid').disabled = true;
        document.getElementById('txtcountry').disabled = true;
        document.getElementById('drpcity').disabled = true;

        document.getElementById('txtgutter').disabled = true;
        document.getElementById('txtcolspc').disabled = true;

        document.getElementById('txthr').disabled = true;
        document.getElementById('txtmin').disabled = true;
        document.getElementById('txtproduction').disabled = true;

        document.getElementById('txtphone2').disabled = true;
        document.getElementById('txtfaxno1').disabled = true;
        document.getElementById('txtprefix').disabled = true;
        document.getElementById('txtintegration').disabled = true;
        //change by kanishk
        $('txtsrvcacc').disabled = true
        $('txtsubsrvcacc').disabled = true;

        alert("Your Search Criteria Does Not Exist");
        clickcancle1('PublicationMaster');
        return false;
    }
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//*******************************************************************************//
/*function clickfirst1()
{
		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
PublicationMaster.selectpublication(publicationfirst);
		return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	

function clickfirst1() {
    //	var dspublicationexecute =response.value;
    z = 0;
    document.getElementById('txtpubcode').value = dspublicationexecute.Tables[0].Rows[0].Pub_Code;
    document.getElementById('txtpubname').value = dspublicationexecute.Tables[0].Rows[0].Pub_Name;
    document.getElementById('txtpubalias').value = dspublicationexecute.Tables[0].Rows[0].pub_alias;
    document.getElementById('drplanguage').value = dspublicationexecute.Tables[0].Rows[0].Lang_Code;
    document.getElementById('txtpriority').value = dspublicationexecute.Tables[0].Rows[0].Priority;
    document.getElementById('txtmrv').value = dspublicationexecute.Tables[0].Rows[0].MRV_MEMBER_CODE;
    document.getElementById('txtmobno').value = dspublicationexecute.Tables[0].Rows[0].MOBILENO;
    document.getElementById('txtintegration').value = dspublicationexecute.Tables[0].Rows[0].INTEGRATION_ID;
    //change by kanishk

    if (dspublicationexecute.Tables[0].Rows[0].SAC_CODE != null) {
        document.getElementById('txtsrvcacc').value = dspublicationexecute.Tables[0].Rows[0].SAC_CODE;
    }
    else {
        document.getElementById('txtsrvcacc').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[0].SUB_SAC_CODE != null) {
        document.getElementById('txtsubsrvcacc').value = dspublicationexecute.Tables[0].Rows[0].SUB_SAC_CODE;
    }
    else {
        document.getElementById('txtsubsrvcacc').value = "";
    } if (dspublicationexecute.Tables[0].Rows[0].Cont_Person != null) {
        document.getElementById('txtcontactperson').value = dspublicationexecute.Tables[0].Rows[0].Cont_Person;
    }
    else {
        document.getElementById('txtcontactperson').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[0].Phone1 != null) {
        document.getElementById('txtphone2').value = dspublicationexecute.Tables[0].Rows[0].Phone1;
    }
    else {
        document.getElementById('txtphone2').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[0].Fax1 != null) {
        document.getElementById('txtfaxno1').value = dspublicationexecute.Tables[0].Rows[0].Fax1;
    }
    else {
        document.getElementById('txtfaxno1').value = "";
    }

    document.getElementById('txtgutter').value = dspublicationexecute.Tables[0].Rows[0].Gutter_Space;
    document.getElementById('txtcolspc').value = dspublicationexecute.Tables[0].Rows[0].Column_Space;
    if (dspublicationexecute.Tables[0].Rows[0].hr != null) {
        document.getElementById('txthr').value = dspublicationexecute.Tables[0].Rows[0].hr;
    }
    else {
        document.getElementById('txthr').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[0].mint != null) {
        document.getElementById('txtmin').value = dspublicationexecute.Tables[0].Rows[0].mint;
    }
    else {
        document.getElementById('txtmin').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[0].prod != null) {
        document.getElementById('txtproduction').value = dspublicationexecute.Tables[0].Rows[0].prod;
    }
    else {
        document.getElementById('txtproduction').value = "";
    }

    /*change ankur*/
    if (dspublicationexecute.Tables[0].Rows[0].No_Of_Collumn != null) {
        document.getElementById('txtnoofcolumn').value = dspublicationexecute.Tables[0].Rows[0].No_Of_Collumn;
    }
    else {
        document.getElementById('txtnoofcolumn').value = "";
    }

    if (dspublicationexecute.Tables[0].Rows[0].PUBLISHER_CODE != null) {
        document.getElementById('drpublisher').value = dspublicationexecute.Tables[0].Rows[0].PUBLISHER_CODE;
    }
    else {
        document.getElementById('drpublisher').value = "0";
    }
    if (dspublicationexecute.Tables[0].Rows[0].PREFIX != null) {
        document.getElementById('txtprefix').value = dspublicationexecute.Tables[0].Rows[0].PREFIX;
    }
    else {
        document.getElementById('txtprefix').value = "";
    }
    ///////////////////////////////////////////////////

    updateStatus();
    var akh = document.getElementById('txtpubcode').value;
    fillcheckboxes(akh);


    var dateformat = document.getElementById('hiddendateformat').value;
    if (dspublicationexecute.Tables[0].Rows[0].Establish_Date == null || dspublicationexecute.Tables[0].Rows[0].Establish_Date == "") {
        document.getElementById('txteshtabdate').value = "";
    }
    else {
        var enrolldate = dspublicationexecute.Tables[0].Rows[0].Establish_Date;
        var dd = enrolldate.getDate();
        var mm = enrolldate.getMonth() + 1;
        var yyyy = enrolldate.getFullYear();

        //var enrolldate1=mm+'/'+dd+'/'+yyyy;
        if (dateformat == "dd/mm/yyyy") {
            var enrolldate1 = dd + '/' + mm + '/' + yyyy;
        }
        if (dateformat == "yyyy/mm/dd") {
            var enrolldate1 = yyyy + '/' + mm + '/' + dd;
        }
        if (dateformat == "mm/dd/yyyy") {
            var enrolldate1 = mm + '/' + dd + '/' + yyyy;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            var enrolldate1 = mm + '/' + dd + '/' + yyyy;
        }
        document.getElementById('txteshtabdate').value = enrolldate1;
    }
    if (dspublicationexecute.Tables[0].Rows[0].Phone != null) {
        document.getElementById('txtphoneno').value = dspublicationexecute.Tables[0].Rows[0].Phone;
    }
    else {
        document.getElementById('txtphoneno').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[0].Fax != null) {
        document.getElementById('txtfaxno').value = dspublicationexecute.Tables[0].Rows[0].Fax;
    }
    else {
        document.getElementById('txtfaxno').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[0].EmailID != null) {
        document.getElementById('txtemailid').value = dspublicationexecute.Tables[0].Rows[0].EmailID;
    }
    else {
        document.getElementById('txtemailid').value = "";
    }
    document.getElementById('txtcountry').value = dspublicationexecute.Tables[0].Rows[0].publication_type;
    document.getElementById('drpcity').value = dspublicationexecute.Tables[0].Rows[0].preodicity;
    //			  cityvar=dspublicationexecute.Tables[0].Rows[0].City_Code;
    //			addcount(dspublicationexecute.Tables[0].Rows[0].Country_Code);

    updateStatus();
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnExit').disabled = false;

    document.getElementById('txtpubcode').disabled = true;
    document.getElementById('txtpubname').disabled = true;
    document.getElementById('txtpubalias').disabled = true;
    document.getElementById('drplanguage').disabled = true;
    document.getElementById('txtpriority').disabled = true;
    document.getElementById('txtcontactperson').disabled = true;
    document.getElementById('txteshtabdate').disabled = true;
    document.getElementById('txtphoneno').disabled = true;
    document.getElementById('txtfaxno').disabled = true;
    document.getElementById('txtmrv').disabled = true;

    document.getElementById('txtgutter').disabled = true;
    document.getElementById('txtcolspc').disabled = true;

    document.getElementById('txthr').disabled = true;
    document.getElementById('txtmin').disabled = true;
    document.getElementById('txtproduction').disabled = true;

    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('drpcity').disabled = true;

    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtfaxno1').disabled = true;
    document.getElementById('txtintegration').disabled = true;

    //change by kanishk
    $('txtsrvcacc').disabled = true
    $('txtsubsrvcacc').disabled = true;
    /*change ankur*/
    document.getElementById('txtnoofcolumn').disabled = true;
    document.getElementById('txtprefix').disabled = true;
    ///////////////////////////////////////////////////
    setButtonImages();
    return false;
}
//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//
/*function clicklast1()
{
		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
PublicationMaster.selectpublication(publicationlast);
		return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function clicklast1() {
    //var dspublicationexecute=response.value;
    var y = dspublicationexecute.Tables[0].Rows.length;
    z = y - 1;

    document.getElementById('txtpubcode').value = dspublicationexecute.Tables[0].Rows[z].Pub_Code;
    document.getElementById('txtpubname').value = dspublicationexecute.Tables[0].Rows[z].Pub_Name;
    document.getElementById('txtpubalias').value = dspublicationexecute.Tables[0].Rows[z].pub_alias;
    document.getElementById('drplanguage').value = dspublicationexecute.Tables[0].Rows[z].Lang_Code;
    document.getElementById('txtpriority').value = dspublicationexecute.Tables[0].Rows[z].Priority;
    document.getElementById('txtmrv').value = dspublicationexecute.Tables[0].Rows[z].MRV_MEMBER_CODE;
    document.getElementById('txtmobno').value = dspublicationexecute.Tables[0].Rows[z].MOBILENO;
    document.getElementById('txtintegration').value = dspublicationexecute.Tables[0].Rows[z].INTEGRATION_ID;
    //change by kanishk

    if (dspublicationexecute.Tables[0].Rows[z].SAC_CODE != null) {
        document.getElementById('txtsrvcacc').value = dspublicationexecute.Tables[0].Rows[z].SAC_CODE;
    }
    else {
        document.getElementById('txtsrvcacc').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[z].SUB_SAC_CODE != null) {
        document.getElementById('txtsubsrvcacc').value = dspublicationexecute.Tables[0].Rows[z].SUB_SAC_CODE;
    }
    else {
        document.getElementById('txtsubsrvcacc').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[z].Cont_Person != null) {
        document.getElementById('txtcontactperson').value = dspublicationexecute.Tables[0].Rows[z].Cont_Person;
    }
    else {
        document.getElementById('txtcontactperson').value = "";
    }

    document.getElementById('txtgutter').value = dspublicationexecute.Tables[0].Rows[z].Gutter_Space;
    document.getElementById('txtcolspc').value = dspublicationexecute.Tables[0].Rows[z].Column_Space;
    if (dspublicationexecute.Tables[0].Rows[z].hr != null) {
        document.getElementById('txthr').value = dspublicationexecute.Tables[0].Rows[z].hr;
    }
    else {
        document.getElementById('txthr').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[z].mint != null) {
        document.getElementById('txtmin').value = dspublicationexecute.Tables[0].Rows[z].mint;
    }
    else {
        document.getElementById('txtmin').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[z].prod != null) {
        document.getElementById('txtproduction').value = dspublicationexecute.Tables[0].Rows[z].prod;
    }
    else {
        document.getElementById('txtproduction').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[z].Phone1 != null) {
        document.getElementById('txtphone2').value = dspublicationexecute.Tables[0].Rows[z].Phone1;
    }
    else {
        document.getElementById('txtphone2').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[z].Fax1 != null) {
        document.getElementById('txtfaxno1').value = dspublicationexecute.Tables[0].Rows[z].Fax1;
    }
    else {
        document.getElementById('txtfaxno1').value = "";
    }


    /*change ankur*/
    if (dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn != null) {
        document.getElementById('txtnoofcolumn').value = dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn;
    }
    else {
        document.getElementById('txtnoofcolumn').value = "";
    }

    if (dspublicationexecute.Tables[0].Rows[z].PUBLISHER_CODE != null) {
        document.getElementById('drpublisher').value = dspublicationexecute.Tables[0].Rows[z].PUBLISHER_CODE;
    }
    else {
        document.getElementById('drpublisher').value = "0";
    }
    if (dspublicationexecute.Tables[0].Rows[z].PREFIX != null) {
        document.getElementById('txtprefix').value = dspublicationexecute.Tables[0].Rows[z].PREFIX;
    }
    else {
        document.getElementById('txtprefix').value = "";
    }
    ///////////////////////////////////////////////////

    updateStatus();
    var akh = document.getElementById('txtpubcode').value;
    fillcheckboxes(akh);

    var dateformat = document.getElementById('hiddendateformat').value;
    if (dspublicationexecute.Tables[0].Rows[z].Establish_Date == null || dspublicationexecute.Tables[0].Rows[z].Establish_Date == "") {
        document.getElementById('txteshtabdate').value = "";
    }
    else {
        var enrolldate = dspublicationexecute.Tables[0].Rows[z].Establish_Date;
        var dd = enrolldate.getDate();
        var mm = enrolldate.getMonth() + 1;
        var yyyy = enrolldate.getFullYear();

        //var enrolldate1=mm+'/'+dd+'/'+yyyy;
        if (dateformat == "dd/mm/yyyy") {
            var enrolldate1 = dd + '/' + mm + '/' + yyyy;
        }
        if (dateformat == "yyyy/mm/dd") {
            var enrolldate1 = yyyy + '/' + mm + '/' + dd;
        }
        if (dateformat == "mm/dd/yyyy") {
            var enrolldate1 = mm + '/' + dd + '/' + yyyy;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            var enrolldate1 = mm + '/' + dd + '/' + yyyy;
        }
        document.getElementById('txteshtabdate').value = enrolldate1;
    }
    if (dspublicationexecute.Tables[0].Rows[z].Phone != null) {
        document.getElementById('txtphoneno').value = dspublicationexecute.Tables[0].Rows[z].Phone;
    }
    else {
        document.getElementById('txtphoneno').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[z].Fax != null) {
        document.getElementById('txtfaxno').value = dspublicationexecute.Tables[0].Rows[z].Fax;
    }
    else {
        document.getElementById('txtfaxno').value = "";
    }
    if (dspublicationexecute.Tables[0].Rows[z].EmailID != null) {
        document.getElementById('txtemailid').value = dspublicationexecute.Tables[0].Rows[z].EmailID;
    }
    else {
        document.getElementById('txtemailid').value = "";
    }
    document.getElementById('txtcountry').value = dspublicationexecute.Tables[0].Rows[z].publication_type;
    document.getElementById('drpcity').value = dspublicationexecute.Tables[0].Rows[z].preodicity;
    //		  cityvar=dspublicationexecute.Tables[0].Rows[z].City_Code;
    //			addcount(dspublicationexecute.Tables[0].Rows[z].Country_Code);


    document.getElementById('txtpubcode').disabled = true;
    document.getElementById('txtpubname').disabled = true;
    document.getElementById('txtpubalias').disabled = true;
    document.getElementById('drplanguage').disabled = true;
    document.getElementById('txtpriority').disabled = true;
    document.getElementById('txtcontactperson').disabled = true;
    document.getElementById('txteshtabdate').disabled = true;
    document.getElementById('txtphoneno').disabled = true;
    document.getElementById('txtfaxno').disabled = true;
    document.getElementById('txtemailid').disabled = true;
    document.getElementById('txtcountry').disabled = true;
    document.getElementById('drpcity').disabled = true;

    document.getElementById('txtgutter').disabled = true;
    document.getElementById('txtcolspc').disabled = true;
    document.getElementById('txtintegration').disabled = true;
    //change by kanishk
    $('txtsrvcacc').disabled = true
    $('txtsubsrvcacc').disabled = true;
    document.getElementById('txthr').disabled = true;
    document.getElementById('txtmin').disabled = true;
    document.getElementById('txtproduction').disabled = true;
    document.getElementById('txtmrv').disabled = true;

    document.getElementById('txtphone2').disabled = true;
    document.getElementById('txtfaxno1').disabled = true;

    /*change ankur*/
    document.getElementById('txtnoofcolumn').disabled = true;
    document.getElementById('txtprefix').disabled = true;
    ///////////////////////////////////////////////////

    //modify="";

    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnprevious').disabled = false;
    setButtonImages();
    return false;
}
//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//

/*function clicknext1()
{
		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
PublicationMaster.selectpublication(publicationnext);
		return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//

function clicknext1() {
    //var dspublicationexecute=response.value;
    var y = dspublicationexecute.Tables[0].Rows.length;
    z++;
    var k = y - 1;

    if (z != -1 && z >= 0) {
        if (z <= y - 1) {
            document.getElementById('txtpubcode').value = dspublicationexecute.Tables[0].Rows[z].Pub_Code;
            document.getElementById('txtpubname').value = dspublicationexecute.Tables[0].Rows[z].Pub_Name;
            document.getElementById('txtpubalias').value = dspublicationexecute.Tables[0].Rows[z].pub_alias;
            document.getElementById('drplanguage').value = dspublicationexecute.Tables[0].Rows[z].Lang_Code;
            document.getElementById('txtpriority').value = dspublicationexecute.Tables[0].Rows[z].Priority;
            document.getElementById('txtmrv').value = dspublicationexecute.Tables[0].Rows[z].MRV_MEMBER_CODE;
            document.getElementById('txtmobno').value = dspublicationexecute.Tables[0].Rows[z].MOBILENO;
            document.getElementById('txtintegration').value = dspublicationexecute.Tables[0].Rows[z].INTEGRATION_ID;
            //change by kanishk

            if (dspublicationexecute.Tables[0].Rows[z].SAC_CODE != null) {
                document.getElementById('txtsrvcacc').value = dspublicationexecute.Tables[0].Rows[z].SAC_CODE;
            }
            else {
                document.getElementById('txtsrvcacc').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].SUB_SAC_CODE != null) {
                document.getElementById('txtsubsrvcacc').value = dspublicationexecute.Tables[0].Rows[z].SUB_SAC_CODE;
            }
            else {
                document.getElementById('txtsubsrvcacc').value = "";
            } if (dspublicationexecute.Tables[0].Rows[z].Cont_Person != null) {
                document.getElementById('txtcontactperson').value = dspublicationexecute.Tables[0].Rows[z].Cont_Person;
            }
            else {
                document.getElementById('txtcontactperson').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].Phone1 != null) {
                document.getElementById('txtphone2').value = dspublicationexecute.Tables[0].Rows[z].Phone1;
            }
            else {
                document.getElementById('txtphone2').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].Fax1 != null) {
                document.getElementById('txtfaxno1').value = dspublicationexecute.Tables[0].Rows[z].Fax1;
            }
            else {
                document.getElementById('txtfaxno1').value = "";
            }

            document.getElementById('txtgutter').value = dspublicationexecute.Tables[0].Rows[z].Gutter_Space;
            document.getElementById('txtcolspc').value = dspublicationexecute.Tables[0].Rows[z].Column_Space;
            if (dspublicationexecute.Tables[0].Rows[z].hr != null) {
                document.getElementById('txthr').value = dspublicationexecute.Tables[0].Rows[z].hr;
            }
            else {
                document.getElementById('txthr').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].mint != null) {
                document.getElementById('txtmin').value = dspublicationexecute.Tables[0].Rows[z].mint;
            }
            else {
                document.getElementById('txtmin').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].prod != null) {
                document.getElementById('txtproduction').value = dspublicationexecute.Tables[0].Rows[z].prod;
            }
            else {
                document.getElementById('txtproduction').value = "";
            }
            /*change ankur*/
            if (dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn != null) {
                document.getElementById('txtnoofcolumn').value = dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn;
            }
            else {
                document.getElementById('txtnoofcolumn').value = "";
            }


            if (dspublicationexecute.Tables[0].Rows[z].PUBLISHER_CODE != null) {
                document.getElementById('drpublisher').value = dspublicationexecute.Tables[0].Rows[z].PUBLISHER_CODE;
            }
            else {
                document.getElementById('drpublisher').value = "0";
            }
            if (dspublicationexecute.Tables[0].Rows[z].PREFIX != null) {
                document.getElementById('txtprefix').value = dspublicationexecute.Tables[0].Rows[z].PREFIX;
            }
            else {
                document.getElementById('txtprefix').value = "";
            }
            ///////////////////////////////////////////////////


            var akh = document.getElementById('txtpubcode').value;
            fillcheckboxes(akh);

            var dateformat = document.getElementById('hiddendateformat').value;
            if (dspublicationexecute.Tables[0].Rows[z].Establish_Date == null || dspublicationexecute.Tables[0].Rows[z].Establish_Date == "") {
                document.getElementById('txteshtabdate').value = "";
            }
            else {
                var enrolldate = dspublicationexecute.Tables[0].Rows[z].Establish_Date;
                var enrolldateN = new Date(enrolldate);
                var dd = enrolldateN.getDate();
                var mm = enrolldateN.getMonth() + 1;
                var yyyy = enrolldateN.getFullYear();
                //			var dd=enrolldate.getDate();
                //			var mm=enrolldate.getMonth() + 1;
                //			var yyyy=enrolldate.getFullYear();

                //var enrolldate1=mm+'/'+dd+'/'+yyyy;
                if (dateformat == "dd/mm/yyyy") {
                    var enrolldate1 = dd + '/' + mm + '/' + yyyy;
                }
                if (dateformat == "yyyy/mm/dd") {
                    var enrolldate1 = yyyy + '/' + mm + '/' + dd;
                }
                if (dateformat == "mm/dd/yyyy") {
                    var enrolldate1 = mm + '/' + dd + '/' + yyyy;
                }
                if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                    var enrolldate1 = mm + '/' + dd + '/' + yyyy;
                }
                document.getElementById('txteshtabdate').value = enrolldate1;
            }
            if (dspublicationexecute.Tables[0].Rows[z].Phone != null) {
                document.getElementById('txtphoneno').value = dspublicationexecute.Tables[0].Rows[z].Phone;
            }
            else {
                document.getElementById('txtphoneno').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].Fax != null) {
                document.getElementById('txtfaxno').value = dspublicationexecute.Tables[0].Rows[z].Fax;
            }
            else {
                document.getElementById('txtfaxno').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].EmailID != null) {
                document.getElementById('txtemailid').value = dspublicationexecute.Tables[0].Rows[z].EmailID;
            }
            else {
                document.getElementById('txtemailid').value = "";
            }
            document.getElementById('txtcountry').value = dspublicationexecute.Tables[0].Rows[z].publication_type;
            document.getElementById('drpcity').value = dspublicationexecute.Tables[0].Rows[z].preodicity;
            //		  cityvar=dspublicationexecute.Tables[0].Rows[z].City_Code;
            //			addcount(dspublicationexecute.Tables[0].Rows[z].Country_Code);
            //				

            document.getElementById('txtpubcode').disabled = true;
            document.getElementById('txtpubname').disabled = true;
            document.getElementById('txtpubalias').disabled = true;
            document.getElementById('drplanguage').disabled = true;
            document.getElementById('txtpriority').disabled = true;
            document.getElementById('txtcontactperson').disabled = true;
            document.getElementById('txteshtabdate').disabled = true;
            document.getElementById('txtphoneno').disabled = true;
            document.getElementById('txtfaxno').disabled = true;
            document.getElementById('txtemailid').disabled = true;

            document.getElementById('txtgutter').disabled = true;
            document.getElementById('txtcolspc').disabled = true;
            document.getElementById('txtintegration').disabled = true;
            //change by kanishk
            $('txtsrvcacc').disabled = true
            $('txtsubsrvcacc').disabled = true;
            document.getElementById('txthr').disabled = true;
            document.getElementById('txtmin').disabled = true;
            document.getElementById('txtproduction').disabled = true;

            document.getElementById('txtcountry').disabled = true;
            document.getElementById('drpcity').disabled = true;

            document.getElementById('txtphone2').disabled = true;
            document.getElementById('txtfaxno1').disabled = true;

            /*change ankur*/
            document.getElementById('txtnoofcolumn').disabled = true;
            document.getElementById('txtprefix').disabled = true;
            document.getElementById('txtmrv').disabled = true;
            ///////////////////////////////////////////////////

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
    if (z == y - 1) {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
    }
    setButtonImages();
    return false;
}
//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//
/*function clickprevious1()
{
		//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
PublicationMaster.selectpublication(publicationprivious);
		return false;
}*/

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
function clickprevious1() {
    //var dspublicationexecute=response.value;
    var y = dspublicationexecute.Tables[0].Rows.length;
    var p = y - 1;
    z--;

    if (z != -1) {
        if (z >= 0 && z < y) {
            document.getElementById('txtpubcode').value = dspublicationexecute.Tables[0].Rows[z].Pub_Code;
            document.getElementById('txtpubname').value = dspublicationexecute.Tables[0].Rows[z].Pub_Name;
            document.getElementById('txtpubalias').value = dspublicationexecute.Tables[0].Rows[z].pub_alias;
            document.getElementById('drplanguage').value = dspublicationexecute.Tables[0].Rows[z].Lang_Code;
            document.getElementById('txtpriority').value = dspublicationexecute.Tables[0].Rows[z].Priority;
            document.getElementById('txtmrv').value = dspublicationexecute.Tables[0].Rows[z].MRV_MEMBER_CODE;
            document.getElementById('txtmobno').value = dspublicationexecute.Tables[0].Rows[z].MOBILENO;
            document.getElementById('txtintegration').value = dspublicationexecute.Tables[0].Rows[z].INTEGRATION_ID;
            //change by kanishk

            if (dspublicationexecute.Tables[0].Rows[z].SAC_CODE != null) {
                document.getElementById('txtsrvcacc').value = dspublicationexecute.Tables[0].Rows[z].SAC_CODE;
            }
            else {
                document.getElementById('txtsrvcacc').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].SUB_SAC_CODE != null) {
                document.getElementById('txtsubsrvcacc').value = dspublicationexecute.Tables[0].Rows[z].SUB_SAC_CODE;
            }
            else {
                document.getElementById('txtsubsrvcacc').value = "";
            } if (dspublicationexecute.Tables[0].Rows[z].Cont_Person != null) {
                document.getElementById('txtcontactperson').value = dspublicationexecute.Tables[0].Rows[z].Cont_Person;
            }
            else {
                document.getElementById('txtcontactperson').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].Phone1 != null) {
                document.getElementById('txtphone2').value = dspublicationexecute.Tables[0].Rows[z].Phone1;
            }
            else {
                document.getElementById('txtphone2').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].Fax1 != null) {
                document.getElementById('txtfaxno1').value = dspublicationexecute.Tables[0].Rows[z].Fax1;
            }
            else {
                document.getElementById('txtfaxno1').value = "";
            }

            document.getElementById('txthr').value = dspublicationexecute.Tables[0].Rows[z].hr;
            if (dspublicationexecute.Tables[0].Rows[z].mint != null) {
                document.getElementById('txtmin').value = dspublicationexecute.Tables[0].Rows[z].mint;
            }
            else {
                document.getElementById('txtmin').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].prod != null) {
                document.getElementById('txtproduction').value = dspublicationexecute.Tables[0].Rows[z].prod;
            }
            else {
                document.getElementById('txtproduction').value = "";
            }
            document.getElementById('txtgutter').value = dspublicationexecute.Tables[0].Rows[z].Gutter_Space;
            document.getElementById('txtcolspc').value = dspublicationexecute.Tables[0].Rows[z].Column_Space;

            /*change ankur*/
            if (dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn != null) {
                document.getElementById('txtnoofcolumn').value = dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn;
            }
            else {
                document.getElementById('txtnoofcolumn').value = "";
            }

            if (dspublicationexecute.Tables[0].Rows[z].PUBLISHER_CODE != null) {
                document.getElementById('drpublisher').value = dspublicationexecute.Tables[0].Rows[z].PUBLISHER_CODE;
            }
            else {
                document.getElementById('drpublisher').value = "0";
            }
            if (dspublicationexecute.Tables[0].Rows[z].PREFIX != null) {
                document.getElementById('txtprefix').value = dspublicationexecute.Tables[0].Rows[z].PREFIX;
            }
            else {
                document.getElementById('txtprefix').value = "";
            }
            ///////////////////////////////////////////////////

            var akh = document.getElementById('txtpubcode').value;
            fillcheckboxes(akh);

            var dateformat = document.getElementById('hiddendateformat').value;
            if (dspublicationexecute.Tables[0].Rows[z].Establish_Date == null || dspublicationexecute.Tables[0].Rows[z].Establish_Date == "") {
                document.getElementById('txteshtabdate').value = "";
            }
            else {
                var enrolldate = dspublicationexecute.Tables[0].Rows[z].Establish_Date;
                var enrolldateN = new Date(enrolldate);
                var dd = enrolldateN.getDate();
                var mm = enrolldateN.getMonth() + 1;
                var yyyy = enrolldateN.getFullYear();

                //			var enrolldate=dspublicationexecute.Tables[0].Rows[z].Establish_Date;
                //			var dd=enrolldate.getDate();
                //			var mm=enrolldate.getMonth() + 1;
                //			var yyyy=enrolldate.getFullYear();

                //var enrolldate1=mm+'/'+dd+'/'+yyyy;
                if (dateformat == "dd/mm/yyyy") {
                    var enrolldate1 = dd + '/' + mm + '/' + yyyy;
                }
                if (dateformat == "yyyy/mm/dd") {
                    var enrolldate1 = yyyy + '/' + mm + '/' + dd;
                }
                if (dateformat == "mm/dd/yyyy") {
                    var enrolldate1 = mm + '/' + dd + '/' + yyyy;
                }
                if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                    var enrolldate1 = mm + '/' + dd + '/' + yyyy;
                }
                document.getElementById('txteshtabdate').value = enrolldate1;
            }
            if (dspublicationexecute.Tables[0].Rows[z].Phone != null) {
                document.getElementById('txtphoneno').value = dspublicationexecute.Tables[0].Rows[z].Phone;
            }
            else {
                document.getElementById('txtphoneno').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].Fax != null) {
                document.getElementById('txtfaxno').value = dspublicationexecute.Tables[0].Rows[z].Fax;
            }
            else {
                document.getElementById('txtfaxno').value = "";
            }
            if (dspublicationexecute.Tables[0].Rows[z].EmailID != null) {
                document.getElementById('txtemailid').value = dspublicationexecute.Tables[0].Rows[z].EmailID;
            }
            else {
                document.getElementById('txtemailid').value = "";
            }
            document.getElementById('txtcountry').value = dspublicationexecute.Tables[0].Rows[z].publication_type;
            document.getElementById('drpcity').value = dspublicationexecute.Tables[0].Rows[z].preodicity;
            //	  cityvar=dspublicationexecute.Tables[0].Rows[z].City_Code;
            //			addcount(dspublicationexecute.Tables[0].Rows[z].Country_Code);
            //	


            document.getElementById('txtpubcode').disabled = true;
            document.getElementById('txtpubname').disabled = true;
            document.getElementById('txtpubalias').disabled = true;
            document.getElementById('drplanguage').disabled = true;
            document.getElementById('txtpriority').disabled = true;
            document.getElementById('txtcontactperson').disabled = true;
            document.getElementById('txteshtabdate').disabled = true;
            document.getElementById('txtphoneno').disabled = true;
            document.getElementById('txtfaxno').disabled = true;
            document.getElementById('txtemailid').disabled = true;
            document.getElementById('txtcountry').disabled = true;
            document.getElementById('drpcity').disabled = true;
            document.getElementById('txtintegration').disabled = true;

            //change by kanishk
            $('txtsrvcacc').disabled = true
            $('txtsubsrvcacc').disabled = true;
            document.getElementById('txtphone2').disabled = true;
            document.getElementById('txtfaxno1').disabled = true;

            document.getElementById('txtgutter').disabled = true;
            document.getElementById('txtcolspc').disabled = true;
            document.getElementById('txthr').disabled = true;
            document.getElementById('txtmin').disabled = true;
            document.getElementById('txtproduction').disabled = true;
            document.getElementById('txtmrv').disabled = true;
            /*change ankur*/
            document.getElementById('txtnoofcolumn').disabled = true;
            document.getElementById('txtprefix').disabled = true;
            ///////////////////////////////////////////////////


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

    if (z == 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
    }
    setButtonImages();
    return false
}

function showselectday() {
    if (document.getElementById('txtpubcode').value != "") {
    }
    else {
        alert("Please Fill All Mendetory Field Firstly");

        return false;
    }
    if (document.getElementById('txtpubname').value != "") {
    }
    else {
        alert("Please Fill All Mendetory Field Firstly");

        return false;
    }
    if (document.getElementById('txtgutter').value != "") {
    }
    else {
        alert("Please Fill All Mendetory Field Firstly");

        return false;
    }
    if (document.getElementById('txtcolspc').value != "") {
    }
    else {
        alert("Please Fill All Mendetory Field Firstly");

        return false;
    }
    if (document.getElementById('txtpubalias').value != "") {
    }
    else {
        alert("Please Fill All Mendetory Field Firstly");

        return false;
    }
    if (document.getElementById('drplanguage').value != "") {
    }
    else {
        alert("Please Fill All Mendetory Field Firstly");

        return false;
    }
    if (document.getElementById('txtproduction').value == "") {
        if (document.getElementById('txthr').value == "") {
            if (parseInt(document.getElementById('txtmin').value) > 60) {
                alert("Please Fill All Mendetory Field Firstly");

                return false;
            }
        }
    }





}

function selectpubday(response) {
    var compcode = document.getElementById('hiddencompcode').value;
    var pubcode = document.getElementById('txtpubcode').value;
    var userid = document.getElementById('userid1').value;
    PublicationMaster.checkpubcode1(compcode, pubcode, userid, pubcodever);
    return false;
}

function pubcodever(response) {
    var ds = response.value;
    var chk1;
    var chk2;
    var chk3;
    var chk4;
    var chk5;
    var chk6;
    var chk7;
    var chk8;
    var compcode = document.getElementById('hiddencompcode').value;
    var pubcode = document.getElementById('txtpubcode').value;
    var userid = document.getElementById('userid1').value;
    if (document.getElementById('CheckBox1').checked == true) {
        chk1 = "Y";
    }
    else {
        chk1 = "N";
    }
    if (document.getElementById('CheckBox2').checked == true) {
        chk2 = "Y";
    }
    else {
        chk2 = "N";
    }
    if (document.getElementById('CheckBox3').checked == true) {
        chk3 = "Y";
    }
    else {
        chk3 = "N";
    }
    if (document.getElementById('CheckBox4').checked == true) {
        chk4 = "Y";
    }
    else {
        chk4 = "N";
    }
    if (document.getElementById('CheckBox5').checked == true) {
        chk5 = "Y";
    }
    else {
        chk5 = "N";
    }
    if (document.getElementById('CheckBox6').checked == true) {
        chk6 = "Y";
    }
    else {
        chk6 = "N";
    }
    if (document.getElementById('CheckBox7').checked == true) {
        chk7 = "Y";
    }
    else {
        chk7 = "N";
    }
    if (document.getElementById('CheckBox8').checked == true) {
        chk8 = "Y";
        chk1 = "Y";
        chk2 = "Y";
        chk3 = "Y"
        chk4 = "Y"
        chk5 = "Y"
        chk6 = "Y"
        chk7 = "Y"
        chk8 = "Y"
    }
    else {
        chk8 = "N";
    }
    var integration = document.getElementById('txtintegration');
    //change by kanishk
    var acc_cd = document.getElementById('txtsrvcacc').value;
    var sacc_cd = document.getElementById('txtsubsrvcacc').value;
    if (ds.Tables[0].Rows.length > 0) {
        PublicationMaster.selectpubdaymodify1(compcode, pubcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
        return false;
    }
    else {
        PublicationMaster.selectpubdaysave1(compcode, pubcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
        return false;
    }
}

function fillcheckboxes(response) {
    var compcode = document.getElementById('hiddencompcode').value;
    var pubcode = document.getElementById('txtpubcode').value;
    var userid = document.getElementById('userid1').value;
    PublicationMaster.checkpubcode1(compcode, pubcode, userid, fillcheck);
    return false;
}

function fillcheck(response) {
    var ds = response.value;
    if (ds.Tables[0].Rows.length > 0) {
        var sun = ds.Tables[0].Rows[0].sun;
        var mon = ds.Tables[0].Rows[0].mon;
        var tue = ds.Tables[0].Rows[0].tue;
        var wed = ds.Tables[0].Rows[0].wed;
        var thu = ds.Tables[0].Rows[0].thu;
        var fri = ds.Tables[0].Rows[0].fri;
        var sat = ds.Tables[0].Rows[0].sat;
        var all = ds.Tables[0].Rows[0].all;

        if (sun == "Y") {
            document.getElementById('CheckBox1').checked = true;
        }
        else {
            document.getElementById('CheckBox1').checked = false;
        }

        if (mon == "Y") {
            document.getElementById('CheckBox2').checked = true;
        }
        else {
            document.getElementById('CheckBox2').checked = false;
        }
        if (tue == "Y") {
            document.getElementById('CheckBox3').checked = true;
        }
        else {
            document.getElementById('CheckBox3').checked = false;
        }
        if (wed == "Y") {
            document.getElementById('CheckBox4').checked = true;
        }
        else {
            document.getElementById('CheckBox4').checked = false;
        }
        if (thu == "Y") {
            document.getElementById('CheckBox5').checked = true;
        }
        else {
            document.getElementById('CheckBox5').checked = false;
        }
        if (fri == "Y") {
            document.getElementById('CheckBox6').checked = true;
        }
        else {
            document.getElementById('CheckBox6').checked = false;
        }
        if (sat == "Y") {
            document.getElementById('CheckBox7').checked = true;
        }
        else {
            document.getElementById('CheckBox7').checked = false;
        }


        if (all == "Y") {
            document.getElementById('CheckBox1').checked = true;
            document.getElementById('CheckBox2').checked = true;
            document.getElementById('CheckBox3').checked = true;
            document.getElementById('CheckBox4').checked = true;
            document.getElementById('CheckBox5').checked = true;
            document.getElementById('CheckBox6').checked = true;
            document.getElementById('CheckBox7').checked = true;
            document.getElementById('CheckBox8').checked = true;
        }
        else {
            document.getElementById('CheckBox8').checked = false;
        }
    }
}

var flag = 0;
/*function updatecheck()
{
if(flag==0)
{
flag=1;
checkedunchecked();	
}
else
{
flag=0;
checkedunchecked();	
}
}
return false;
}
*/

function checkedunchecked(q) {
    var status = document.getElementById(q).checked;
    if (status == true) {
        document.getElementById('CheckBox1').checked = true;
        document.getElementById('CheckBox2').checked = true;
        document.getElementById('CheckBox3').checked = true;
        document.getElementById('CheckBox4').checked = true;
        document.getElementById('CheckBox5').checked = true;
        document.getElementById('CheckBox6').checked = true;
        document.getElementById('CheckBox7').checked = true;
        document.getElementById('CheckBox8').checked = true;
    }
    else {
        document.getElementById('CheckBox1').checked = false;
        document.getElementById('CheckBox2').checked = false;
        document.getElementById('CheckBox3').checked = false;
        document.getElementById('CheckBox4').checked = false;
        document.getElementById('CheckBox5').checked = false;
        document.getElementById('CheckBox6').checked = false;
        document.getElementById('CheckBox7').checked = false;
        document.getElementById(q).checked = false;
    }
}

function saurabh_chk() {
    if (document.getElementById('CheckBox1').checked == true) {
        if (document.getElementById('CheckBox2').checked == true) {
            if (document.getElementById('CheckBox3').checked == true) {
                if (document.getElementById('CheckBox4').checked == true) {
                    if (document.getElementById('CheckBox5').checked == true) {
                        if (document.getElementById('CheckBox6').checked == true) {
                            if (document.getElementById('CheckBox7').checked == true) {
                                document.getElementById('CheckBox8').checked = true;
                            }
                        }
                    }
                }
            }
        }
    }

}


//*******************************************************************************//
//**************************This Function For New Button*************************//
//*******************************************************************************/

function pubdelete1() {


    //var glapubcode;
    //var glapubname;
    //var glapubalias;
    //var glalanguage;
    //var glapubtype;
    //var glapreodicity;
    updateStatus();
    var compcode = document.getElementById('hiddencompcode').value;
    var pubcode = document.getElementById('txtpubcode').value;
    var pubname = document.getElementById('txtpubname').value;
    var pubalias = document.getElementById('txtpubalias').value;
    var langcode = document.getElementById('drplanguage').value;
    var userid = document.getElementById('userid1').value;
    var phone2 = document.getElementById('txtphone2').value;
    var gtr = document.getElementById('txtgutter').value;
    var colsp = document.getElementById('txtcolspc').value;
    var hr = document.getElementById('txthr').value;
    var mint = document.getElementById('txtmin').value;
    var prod = document.getElementById('txtproduction').value;
    var fax2 = document.getElementById('txtfaxno1').value;
    var prifix = document.getElementById('txtprefix').value;

    boolReturn = confirm("Are you sure you wish to delete this?");
    if (boolReturn == 1) {
        //alert("Data Deleted Successfully");

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
        if (browser != "Microsoft Internet Explorer") {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
        var ip2 = document.getElementById('ip1').value;
        PublicationMaster.pubdelete1(compcode, pubcode, ip2);
        //PublicationMaster.pubexecute1(compcode,pubcode,pubname,pubalias,langcode,pubtype, preocity,executeresponse);//,userid			
        PublicationMaster.pubexecute1(compcode, glapubcode, glapubname, glapubalias, glalanguage, glapubtype, glapreodicity, delcall);
        //PublicationMaster.pubexecute1(compcode,glapubcode,glapubname,glapubalias,glalanguage,glapubtype, glapreodicity,delcall,hr,mint,prod);
        //PublicationMaster.pubexecute1(compcode,pubcode,pubname,pubalias,langcode,pubtype, preocity,executeresponse);//,userid
    }
    else {
        return false;
    }
    return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function delcall(res) {
    dspublicationexecute = res.value;
    len = dspublicationexecute.Tables[0].Rows.length;

    if (dspublicationexecute.Tables[0].Rows.length == 0) {
        alert("No More Data is here to be deleted");

        document.getElementById('txtpubcode').value = "";
        document.getElementById('txtpubname').value = "";
        document.getElementById('txtpubalias').value = "";
        document.getElementById('drplanguage').value = 0;
        document.getElementById('txtpriority').value = "";
        document.getElementById('txtcontactperson').value = "";
        document.getElementById('txteshtabdate').value = "";
        document.getElementById('txtphoneno').value = "";
        document.getElementById('txtfaxno').value = "";
        document.getElementById('txtemailid').value = "";

        document.getElementById('txtgutter').value = "";
        document.getElementById('txtcolspc').value = "";

        document.getElementById('txthr').value = "";
        document.getElementById('txtmin').value = "";
        document.getElementById('txtproduction').value == "";

        document.getElementById('txtphone2').value = "";
        document.getElementById('txtfaxno1').value = "";

        /*change ankur*/
        document.getElementById('txtnoofcolumn').value = "";
        document.getElementById('txttxtprefix').value == "";
        document.getElementById('txtmrv').value == "";
        ///////////////////////////////////////////////////

        disablecheck();
        clickcancle1('PublicationMaster');
        return false;
    }
    else if (z >= len || z == -1) {
        document.getElementById('txtpubcode').value = dspublicationexecute.Tables[0].Rows[0].Pub_Code;
        document.getElementById('txtpubname').value = dspublicationexecute.Tables[0].Rows[0].Pub_Name;
        document.getElementById('txtpubalias').value = dspublicationexecute.Tables[0].Rows[0].pub_alias;
        document.getElementById('drplanguage').value = dspublicationexecute.Tables[0].Rows[0].Lang_Code;
        document.getElementById('txtpriority').value = dspublicationexecute.Tables[0].Rows[0].Priority;
        document.getElementById('txtcontactperson').value = dspublicationexecute.Tables[0].Rows[0].Cont_Person;

        document.getElementById('txtgutter').value = dspublicationexecute.Tables[0].Rows[0].Gutter_space;
        document.getElementById('txtcolspc').value = dspublicationexecute.Tables[0].Rows[0].Column_Space;
        if (dspublicationexecute.Tables[0].Rows[0].hr != null) {
            document.getElementById('txthr').value = dspublicationexecute.Tables[0].Rows[0].hr;
        }
        else {
            document.getElementById('txthr').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].mint != null) {
            document.getElementById('txtmin').value = dspublicationexecute.Tables[0].Rows[0].mint;
        }
        else {
            document.getElementById('txtmin').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].prod != null) {
            document.getElementById('txtproduction').value = dspublicationexecute.Tables[0].Rows[0].prod;
        }
        else {
            document.getElementById('txtproduction').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].Phone1 != null) {
            document.getElementById('txtphone2').value = dspublicationexecute.Tables[0].Rows[0].Phone1;
        }
        else {
            document.getElementById('txtphone2').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].Fax1 != null) {
            document.getElementById('txtfaxno1').value = dspublicationexecute.Tables[0].Rows[0].Fax1;
        }
        else {
            document.getElementById('txtfaxno1').value = ""
        }
        /*change ankur*/
        if (dspublicationexecute.Tables[0].Rows[0].No_Of_Collumn != null) {
            document.getElementById('txtnoofcolumn').value = dspublicationexecute.Tables[0].Rows[0].No_Of_Collumn;
        }
        else {
            document.getElementById('txtnoofcolumn').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].PREFIX != null) {
            document.getElementById('txtprefix').value = dspublicationexecute.Tables[0].Rows[0].PREFIX;
        }
        else {
            document.getElementById('txtprefix').value = "";
        }
        ///////////////////////////////////////////////////

        var akh = document.getElementById('txtpubcode').value;
        fillcheckboxes(akh);

        var dateformat = document.getElementById('hiddendateformat').value;
        if (dspublicationexecute.Tables[0].Rows[0].Establish_Date == null || dspublicationexecute.Tables[0].Rows[0].Establish_Date == "") {
            document.getElementById('txteshtabdate').value = "";
        }
        else {
            var enrolldate = dspublicationexecute.Tables[0].Rows[0].Establish_Date;
            var dd = enrolldate.getDate();
            var mm = enrolldate.getMonth() + 1;
            var yyyy = enrolldate.getFullYear();

            //var enrolldate1=mm+'/'+dd+'/'+yyyy;
            if (dateformat == "dd/mm/yyyy") {
                var enrolldate1 = dd + '/' + mm + '/' + yyyy;
            }
            if (dateformat == "yyyy/mm/dd") {
                var enrolldate1 = yyyy + '/' + mm + '/' + dd;
            }
            if (dateformat == "mm/dd/yyyy") {
                var enrolldate1 = mm + '/' + dd + '/' + yyyy;
            }
            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                var enrolldate1 = mm + '/' + dd + '/' + yyyy;
            }
            document.getElementById('txteshtabdate').value = enrolldate1;
        }
        if (dspublicationexecute.Tables[0].Rows[0].Phone != null) {
            document.getElementById('txtphoneno').value = dspublicationexecute.Tables[0].Rows[0].Phone;
        }
        else {
            document.getElementById('txtphoneno').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].Fax != null) {
            document.getElementById('txtfaxno').value = dspublicationexecute.Tables[0].Rows[0].Fax;
        }
        else {
            document.getElementById('txtfaxno').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[0].EmailID != null) {
            document.getElementById('txtemailid').value = dspublicationexecute.Tables[0].Rows[0].EmailID;
        }
        else {
            document.getElementById('txtemailid').value = "";
        }
        document.getElementById('txtcountry').value = dspublicationexecute.Tables[0].Rows[0].publication_type;
        document.getElementById('drpcity').value = dspublicationexecute.Tables[0].Rows[0].preodicity;
        //	  cityvar=dspublicationexecute.Tables[0].Rows[0].City_Code;
        //			addcount(dspublicationexecute.Tables[0].Rows[0].Country_Code);
        //	
    }
    else {
        document.getElementById('txtpubcode').value = dspublicationexecute.Tables[0].Rows[z].Pub_Code;
        document.getElementById('txtpubname').value = dspublicationexecute.Tables[0].Rows[z].Pub_Name;
        document.getElementById('txtpubalias').value = dspublicationexecute.Tables[0].Rows[z].pub_alias;
        document.getElementById('drplanguage').value = dspublicationexecute.Tables[0].Rows[z].Lang_Code;
        document.getElementById('txtpriority').value = dspublicationexecute.Tables[0].Rows[z].Priority;
        document.getElementById('txtcontactperson').value = dspublicationexecute.Tables[0].Rows[z].Cont_Person;

        document.getElementById('txtgutter').value = dspublicationexecute.Tables[0].Rows[z].Gutter_space;
        document.getElementById('txtcolspc').value = dspublicationexecute.Tables[0].Rows[z].Column_Space;
        if (dspublicationexecute.Tables[0].Rows[z].hr != null) {
            document.getElementById('txthr').value = dspublicationexecute.Tables[0].Rows[z].hr;
        }
        else {
            document.getElementById('txthr').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[z].mint != null) {
            document.getElementById('txtmin').value = dspublicationexecute.Tables[0].Rows[z].mint;
        }
        else {
            document.getElementById('txtmin').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[z].prod != null) {
            document.getElementById('txtproduction').value = dspublicationexecute.Tables[0].Rows[z].prod;
        }
        else {
            document.getElementById('txtproduction').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[z].Phone1 != null) {
            document.getElementById('txtphone2').value = dspublicationexecute.Tables[0].Rows[z].Phone1;
        }
        else {
            document.getElementById('txtphone2').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[z].Fax1 != null) {
            document.getElementById('txtfaxno1').value = dspublicationexecute.Tables[0].Rows[z].Fax1;
        }
        else {
            document.getElementById('txtfaxno1').value = ""
        }
        /*change ankur*/
        if (dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn != null) {
            document.getElementById('txtnoofcolumn').value = dspublicationexecute.Tables[0].Rows[z].No_Of_Collumn;
        }
        else {
            document.getElementById('txtnoofcolumn').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[z].PREFIX != null) {
            document.getElementById('txtprefix').value = dspublicationexecute.Tables[0].Rows[z].PREFIX;
        }
        else {
            document.getElementById('txtprefix').value = "";
        }
        ///////////////////////////////////////////////////

        var akh = document.getElementById('txtpubcode').value;
        fillcheckboxes(akh);

        var dateformat = document.getElementById('hiddendateformat').value;
        if (dspublicationexecute.Tables[0].Rows[z].Establish_Date == null || dspublicationexecute.Tables[0].Rows[z].Establish_Date == "") {
            document.getElementById('txteshtabdate').value = "";
        }
        else {
            var enrolldate = dspublicationexecute.Tables[0].Rows[z].Establish_Date;
            var dd = enrolldate.getDate();
            var mm = enrolldate.getMonth() + 1;
            var yyyy = enrolldate.getFullYear();

            //var enrolldate1=mm+'/'+dd+'/'+yyyy;
            if (dateformat == "dd/mm/yyyy") {
                var enrolldate1 = dd + '/' + mm + '/' + yyyy;
            }
            if (dateformat == "yyyy/mm/dd") {
                var enrolldate1 = yyyy + '/' + mm + '/' + dd;
            }
            if (dateformat == "mm/dd/yyyy") {
                var enrolldate1 = mm + '/' + dd + '/' + yyyy;
            }
            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                var enrolldate1 = mm + '/' + dd + '/' + yyyy;
            }
            document.getElementById('txteshtabdate').value = enrolldate1;
        }
        if (dspublicationexecute.Tables[0].Rows[z].Phone != null) {
            document.getElementById('txtphoneno').value = dspublicationexecute.Tables[0].Rows[z].Phone;
        }
        else {
            document.getElementById('txtphoneno').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[z].Fax != null) {
            document.getElementById('txtfaxno').value = dspublicationexecute.Tables[0].Rows[z].Fax;
        }
        else {
            document.getElementById('txtfaxno').value = "";
        }
        if (dspublicationexecute.Tables[0].Rows[z].EmailID != null) {
            document.getElementById('txtemailid').value = dspublicationexecute.Tables[0].Rows[z].EmailID;
        }
        else {
            document.getElementById('txtemailid').value = "";
        }
        document.getElementById('txtcountry').value = dspublicationexecute.Tables[0].Rows[z].publication_type;
        document.getElementById('drpcity').value = dspublicationexecute.Tables[0].Rows[z].preodicity;
        //	  cityvar=dspublicationexecute.Tables[0].Rows[z].City_Code;
        //			addcount(dspublicationexecute.Tables[0].Rows[z].Country_Code);

    }
    setButtonImages();
    return false;
}


function clickexit() {
    if (confirm("Do You Want To Skip This Page")) {
        //window.location.href='enterpage.aspx';

        window.close();
        return false;
    }
    return false;
}

function disablecheck() {
    document.getElementById('CheckBox1').disabled = true;
    document.getElementById('CheckBox2').disabled = true;
    document.getElementById('CheckBox3').disabled = true;
    document.getElementById('CheckBox4').disabled = true;
    document.getElementById('CheckBox5').disabled = true;
    document.getElementById('CheckBox6').disabled = true;
    document.getElementById('CheckBox7').disabled = true;
    document.getElementById('CheckBox8').disabled = true;
    givebuttonpermission('PublicationMaster');
    return false;
}


function fillvalue() {
    document.getElementById('txtpubalias').value = document.getElementById('txtpubname').value.toUpperCase();
}


//function fillalias()
//{
//document.getElementById('txtpubalias').value=document.getElementById('txtpubname').value.toUpperCase();
//}



// ******************************Code For Auto Generation********************

function autoornot() {
    document.getElementById('txtpubname').value = document.getElementById('txtpubname').value.toUpperCase();

    if (document.getElementById('hiddenauto').value == 1) {
        autochange();

        return false;
    }
    else {
        userdefine();

        return false;
    }
    return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function autochange() {
    //  Saurabh change      if(hiddentext=="new" )

    if ((document.getElementById('hiddenauto').value == "1")) {

        UPPERCASE();

    }
    else {

        document.getElementById('txtpubname').value = document.getElementById('txtpubname').value.toUpperCase();
        return;
    }
    return;
}


//auto generated
//this is used for increment in code

function UPPERCASE() {

    document.getElementById('txtpubname').value = trim(document.getElementById('txtpubname').value);

    document.getElementById('txtpubalias').value = trim(document.getElementById('txtpubalias').value);

    lstr = document.getElementById('txtpubname').value;
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

    if (document.getElementById('txtpubname').value != "") {


        document.getElementById('txtpubname').value = document.getElementById('txtpubname').value.toUpperCase();

        if (hiddentext == "new") {
            document.getElementById('txtpubalias').value = document.getElementById('txtpubname').value;
        }
        str = mstr;
        //		 str=document.getElementById('txtpubname').value;
        //		 cod=document.getElementById('txtpubcode').value
        PublicationMaster.chkpublicationmast(/*cod,*/str, fillcall);
        return false;

    }


    return false;

}

function fillcall(res) {
    var ds = res.value;

    var newstr;

    if (ds.Tables[0].Rows.length != 0) {

        if (saurabh_agarwal == 1) {
            alert("This Publication name has been already assigned !! ");
            document.getElementById('txtpubname').value = "";
            document.getElementById('txtpubalias').value = "";
            document.getElementById('txtpubname').focus();
        }


        return false;
    }

    else {
        if (hiddentext == "new") {
            if (ds.Tables[1].Rows.length == 0) {
                newstr = null;
            }
            else {
                newstr = ds.Tables[1].Rows[0].Pub_Code;
            }
            if (newstr != null) {
                // var code=newstr.substr(2,4);
                var code = newstr;
                str = str.toUpperCase();
                code++;
                document.getElementById('txtpubcode').value = str.substr(0, 2) + code;
            }
            else {
                str = str.toUpperCase();
                document.getElementById('txtpubcode').value = str.substr(0, 2) + "0";
            }
        }
    }
    return false;
}

function userdefine() {
    if (hiddentext == "new") {

        document.getElementById('txtpubcode').disabled = false;

        document.getElementById('txtpubname').value = trim(document.getElementById('txtpubname').value);
        document.getElementById('txtpubalias').value = trim(document.getElementById('txtpubalias').value);
        document.getElementById('txtpubcode').value = trim(document.getElementById('txtpubcode').value);

        document.getElementById('txtpubname').value = document.getElementById('txtpubname').value.toUpperCase();
        document.getElementById('txtpubalias').value = document.getElementById('txtpubname').value;
        auto = document.getElementById('hiddenauto').value;

        var res = PublicationMaster.chkpublicationmast(document.getElementById('txtpubname').value);

        var ds = res.value;

        if (ds.Tables[0].Rows.length != 0) {
            alert("This Publication Name has already assigned !! ");

            document.getElementById('txtpubname').value = "";
            if (hiddentext == "new")
                document.getElementById('txtpubalias').value = "";

            document.getElementById('txtpubname').focus();

            return false;
        }
        return false;
    }

    return false;
}


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


function fillchk_chkbox() {
    if ((document.getElementById('CheckBox1').disabled == false) && (document.getElementById('CheckBox1').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }

    if ((document.getElementById('CheckBox2').disabled == false) && (document.getElementById('CheckBox2').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox3').disabled == false) && (document.getElementById('CheckBox3').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox4').disabled == false) && (document.getElementById('CheckBox4').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox5').disabled == false) && (document.getElementById('CheckBox5').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox6').disabled == false) && (document.getElementById('CheckBox6').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }
    if ((document.getElementById('CheckBox7').disabled == false) && (document.getElementById('CheckBox7').checked == false)) {
        document.getElementById('CheckBox8').checked = false;
    }

    saurabh_chk();

    return;
}


function checkgutter() {
    var num = document.getElementById('txtgutter').value;
    var tomatch = /^\d*(\.\d{1,2})?$/;
    if (tomatch.test(num)) {
        return true;
    }
    else {
        alert("Input error");
        document.getElementById('txtgutter').focus();
        document.getElementById('txtgutter').value = "";
        return false;
    }
}

function checkcol() {
    var num = document.getElementById('txtcolspc').value;
    var tomatch = /^\d*(\.\d{1,2})?$/;
    if (tomatch.test(num)) {
        return true;
    }
    else {
        alert("Input error");
        document.getElementById('txtcolspc').focus();
        document.getElementById('txtcolspc').value = "";
        return false;
    }
}

function chkmin() {
    var i = parseInt(document.getElementById('txtmin').value);
    if (document.getElementById('txtmin').value != "") {
        if (i > 60) {
            alert("The minutes should not be greater than 60 ");
            document.getElementById('txtmin').value = "";
            document.getElementById('txtmin').focus();
            return false;
        }
    }

}


function saurabhClientEmailCheck(q) {
    var theurl = document.getElementById(q).value;

    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById(q).value == "") {
        return (true)
    }
    alert("Invalid E-mail Address! Please re-enter.")
    document.getElementById(q).value = "";
    document.getElementById(q).focus();
    return (false)
}



function chkPriority() {
    var compCodePrio = document.getElementById('hiddencompcode').value;
    if (document.getElementById('txtpriority').value == "")
        return false;
    var prioriry = parseFloat(document.getElementById('txtpriority').value);

    if (prioriry != "") {
        flagPrio = "0";
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
        PublicationMaster.chkPubPriority(compCodePrio, prioriry, chkPriority_call);
        return false;
    }
}

function chkPriority_call(response) {
    var ds = response.value;
    if (ds.Tables[0].Rows.length > 0) {
        if (ds.Tables[0].Rows[0].Pub_Name != document.getElementById('txtpubname').value) {
            alert('The Priority Already Set To ' + ds.Tables[0].Rows[0].Pub_Name);
            document.getElementById('txtpriority').value = "";
            document.getElementById('txtpriority').focus();
            flagPrio = "1";
            return false;
        }
        else {
            flagPrio = "1";
            return;
        }
    }
    else {
        flagPrio = "1";
        return;
    }
    //return;
}


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


/*----------------------*/
function ischarKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && charCode > 32 && (charCode < 97 || charCode > 122) && (charCode < 65 || charCode > 90))
        return false;

    return true;
}


function checkfield(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (event.keyCode == "13" || event.keyCode == "9") {


        if (document.activeElement.id == "txtpubname") {
            if (key == 13 || key == 9) {
                document.getElementById('txtpubalias').focus();
                return false;
            }
        }
        if (document.activeElement.id == "txtpubalias") {
            if (key == 13 || key == 9) {
                document.getElementById('drplanguage').focus();
                return false;
            }
        }

        if (document.activeElement.id == "txteshtabdate") {
            if (key == 13 || key == 9) {
                document.getElementById('txtcontactperson').focus();
                return false;
            }
        }
        if (document.activeElement.id == "txtnoofcolumn") {
            if (key == 13 || key == 9) {
                document.getElementById('txtproduction').focus();
                return false;
            }
        }


    }


}

function chkmobile() {
    if (document.getElementById('txtmobno').value != "") {

        if ((document.getElementById('txtmobno').value).length != 10) {
            alert("Mobile no. must be 10digits")
            document.getElementById('txtmobno').value = ""
            document.getElementById('txtmobno').focus();
            return false;
        }
        else {
            var arym = document.getElementById('txtmobno').value;
            if (arym[0] == "0") {
                alert("First digits not be 0");
                document.getElementById('txtmobno').focus();
            }
        }
    }
}

function fillservicecode(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtsrvcacc") {
            document.getElementById('lstservicecode').value = "";

            var pcompcode = document.getElementById('hiddencompcode').value;
            var psac_code = "";
            var psac_name = document.getElementById('txtsrvcacc').value;
            var pcreated_by = document.getElementById('hiddenuserid').value;
            var pcode = "";
            var pfreez_flag = "";
            var pdateformat = document.getElementById('hiddendateformat').value;
            var ptrn_type = "E";
            var extra1 = "";
            var extra2 = "";
            var extra3 = "";
            var extra4 = "";
            var extra5 = "";
            var extra6 = "";
            var extra7 = "";
            var extra8 = "";
            var extra9 = "";
            var extra10 = "";
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
            var tot = document.getElementById('divservicecode').scrollLeft;
            var scrolltop = document.getElementById('divservicecode').scrollTop;
            document.getElementById('divservicecode').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById('divservicecode').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";



            document.getElementById("divservicecode").style.display = "block";


            document.getElementById('lstservicecode').focus();
            PublicationMaster.fill_Service(pcompcode, psac_code, psac_name, pcreated_by, pcode, pfreez_flag, pdateformat, ptrn_type, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, callback_fillservice)
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
        document.getElementById('txtsrvcacc').value = "";
        document.getElementById('hdnsrvcacc').value = "";

        return false;
    }

    else if (event.ctrlKey == true && event.keyCode == 88) {
        document.getElementById('txtsrvcacc').value = "";

        document.getElementById('hdnsrvcacc').value = "";

        return false;
    }
    else if (event.keyCode == 9) {
        return event.keyCode;
    }

    return true;
}

function onclickservice(event) {
    var browser = navigator.appName;
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstservicecode") {
            if (document.getElementById('lstservicecode').value == "0") {
                document.getElementById('txtsrvcacc').value = "";
                document.getElementById('hdnsrvcacc').value = "";
                document.getElementById("divservicecode").style.display = "none";
                document.getElementById('txtsrvcacc').focus();
                return false;
            }
            document.getElementById("divservicecode").style.display = "none";
            var page = document.getElementById('lstservicecode').value;
            agencycodeglo = page;
            for (var k = 0; k <= document.getElementById("lstservicecode").length - 1; k++) {
                if (document.getElementById('lstservicecode').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstservicecode').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstservicecode').options[k].innerText;
                    }
                    //var abc=$('lstpubtyp').options[k].innerText;
                    var SPT = abc.split('~')
                    document.getElementById('txtsrvcacc').value = SPT[0];
                    document.getElementById('hdnsrvcacc').value = SPT[1];
                    document.getElementById('txtsrvcacc').focus();
                    return false;
                }
            }
        }
    }
    else if (event.keyCode == 27) {
        document.getElementById('divservicecode').style.display = "none";
        document.getElementById('txtsrvcacc').focus();
        return false;
    }
}

function callback_fillservice(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        var pkgitem = document.getElementById("lstservicecode");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Service Accounting Code-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SAC_NAME + "~" + ds.Tables[0].Rows[i].SAC_CODE, ds.Tables[0].Rows[i].SAC_CODE);


            pkgitem.options.length;
        }
    }
    document.getElementById("lstservicecode").value = "0";
    return false;
}

/////////////////////////////////new add for sub service code--kanishk--///////////////////////////////

function fillsubservicecode(event) {

    if ($('txtsrvcacc').value == "") {
        alert("Please Select Service Acoounting Code");
        $('txtsrvcacc').focus();
        return false;
    }

    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtsubsrvcacc") {
            $('lstsubservicecode').value = "";

            var pcompcode = $('hiddencompcode').value;
            var pssac_code = "";
            var psac_code = $('hdnsrvcacc').value;
            var pssac_name = $('txtsubsrvcacc').value;
            var pcode = "";
            var pfreez_flag = "";
            var pcreated_by = $('hiddenuserid').value;
            var pdateformat = $('hiddendateformat').value;
            var ptrn_type = "E";
            var extra1 = "";
            var extra2 = "";
            var extra3 = "";
            var extra4 = "";
            var extra5 = "";
            var extra6 = "";
            var extra7 = "";
            var extra8 = "";
            var extra9 = "";
            var extra10 = "";
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
            var tot = document.getElementById('divsubservicecode').scrollLeft;
            var scrolltop = document.getElementById('divsubservicecode').scrollTop;
            document.getElementById('divsubservicecode').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById('divsubservicecode').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";



            $("divsubservicecode").style.display = "block";


            $('lstsubservicecode').focus();
            PublicationMaster.fill_subService(pcompcode, pssac_code, psac_code, pssac_name, pcode, pfreez_flag, pcreated_by, pdateformat, ptrn_type, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, callback_fillsubservice)
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
        $('txtsubsrvcacc').value = "";
        $('hdnsubsrvcacc').value = "";

        return false;
    }

    else if (event.ctrlKey == true && event.keyCode == 88) {
        $('txtsubsrvcacc').value = "";

        $('hdnsubsrvcacc').value = "";

        return false;
    }
    else if (event.keyCode == 9) {
        return event.keyCode;
    }

    return true;
}

function onclicksubservice(event) {
    var browser = navigator.appName;
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstsubservicecode") {
            if ($('lstsubservicecode').value == "0") {
                $('txtsubsrvcacc').value = "";
                $('hdnsubsrvcacc').value = "";
                $("divsubservicecode").style.display = "none";
                $('txtsubsrvcacc').focus();
                return false;
            }
            $("divsubservicecode").style.display = "none";
            var page = $('lstsubservicecode').value;
            agencycodeglo = page;
            for (var k = 0; k <= $("lstsubservicecode").length - 1; k++) {
                if ($('lstsubservicecode').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = $('lstsubservicecode').options[k].textContent;
                    }
                    else {
                        var abc = $('lstsubservicecode').options[k].innerText;
                    }
                    //var abc=$('lstpubtyp').options[k].innerText;
                    var SPT = abc.split('~')
                    $('txtsubsrvcacc').value = SPT[0];
                    $('hdnsubsrvcacc').value = SPT[1];
                    $('txtsubsrvcacc').focus();
                    return false;
                }
            }
        }
    }
    else if (event.keyCode == 27) {
        $('divsubservicecode').style.display = "none";
        $('txtsubsrvcacc').focus();
        return false;
    }
}

function callback_fillsubservice(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        var pkgitem = $("lstsubservicecode");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select sub Service Accounting Code-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SUB_SAC_NAME + "~" + ds.Tables[0].Rows[i].SUB_SAC_CODE, ds.Tables[0].Rows[i].SUB_SAC_CODE);


            pkgitem.options.length;
        }
    }
    $("lstsubservicecode").value = "0";
    return false;
}
