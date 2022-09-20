

var browser = navigator.appName;

var xmlDoc = null;
var xmlObj = null;
var flag2 = "0";
var popup = "0";
var ankit = "0";

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




function NewClick2() {

    //document.getElementById('drppageno').value="0";
    popup = "1";
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }
        //httpRequest.onreadystatechange = function() { alertContents(httpRequest) };
        var retcode = 1;
        httpRequest.open("GET", "logosession.aspx?retcode=" + retcode, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                id = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
                return false;
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");

        var retcode = "";
        xml.Open("GET", "logosession.aspx?retcode=" + retcode, false);
        xml.Send();
        var dl = xml.responseText;
    }


    
    document.getElementById('txtPosTypCode').value = "";
    document.getElementById('txtPosType').value = "";
    document.getElementById('txtAlias').value = "";
    document.getElementById('txtamount').value = "";
    document.getElementById('drpremium').value = "0";
    document.getElementById('txtvalid').value = "";
    document.getElementById('txtvalidtill').value = "";

    if (document.getElementById('hiddenauto').value == 1) {
        document.getElementById('txtPosTypCode').disabled = true;
    }
    else {
        document.getElementById('txtPosTypCode').disabled = false;
    }
    document.getElementById('lbcommdetail').disabled = false;
    document.getElementById('txtPosType').disabled = false;
    document.getElementById('txtAlias').disabled = false;
    document.getElementById('txtamount').disabled = false;
    document.getElementById('drpremium').disabled = false;
    document.getElementById('txtvalid').disabled = false;
    document.getElementById('txtvalidtill').disabled = false;
    document.getElementById('txtdessigndesc').disabled = false;
    document.getElementById('txtdessigndesc').disabled = false;
    
 var adcatlen = document.getElementById('drpadcategory').options.length;
    for (var t2 = 0; t2 < document.getElementById('drpadcategory').options.length; t2++) {
        document.getElementById('drpadcategory').options[t2].selected = false;
    }
    document.getElementById('drpadcategory').value = "0";
    document.getElementById('drpadcategory').disabled = false;


    //document.getElementById('drppageno').disabled=false;


    chkstatus(FlagStatus);

    hiddentext = "new";
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;

    if (document.getElementById('hiddenauto').value == 1) {
        document.getElementById('txtPosType').focus();
    }
    else {
        document.getElementById('txtPosTypCode').focus();
    }


    //document.getElementById('drpremium').value=document.getElementById('hiddenprem').value;
    //document.getElementById('drpremium').disabled=true;

    flag = 0;
    setButtonImages();
    return false;
}



function CancelClick2() {
    document.getElementById('lbcommdetail').disabled = true;
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        //httpRequest.onreadystatechange = function() { alertContents(httpRequest) };
        var retcode = 1;
        httpRequest.open("GET", "logosession.aspx?retcode=" + retcode, false);
        httpRequest.send('');


        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                id = httpRequest.responseText;
            }
            else {
                alert('Session Expired.Please Login Again.');
                return false;
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");

        var retcode = "";
        xml.Open("GET", "logosession.aspx?retcode=" + retcode, false);
        xml.Send();
        var dl = xml.responseText;
    }
    //document.getElementById('drppageno').value="0";
    document.getElementById('txtPosTypCode').value = "";
    document.getElementById('txtPosType').value = "";
    document.getElementById('txtAlias').value = "";
    document.getElementById('txtamount').value = "";
    document.getElementById('drpremium').value = "0";
    document.getElementById('txtvalid').value = "";
    document.getElementById('txtvalidtill').value = "";
    document.getElementById('txtdessigndesc').value = "";
    //document.getElementById('btnNew').disabled=false;
    //document.getElementById('btnSave').disabled=true;
    //document.getElementById('btnModify').disabled=true;
    //document.getElementById('btnDelete').disabled=true;
    //document.getElementById('btnQuery').disabled=false;
    //document.getElementById('btnExecute').disabled=true;
    //document.getElementById('btnCancel').disabled=false;
    //document.getElementById('btnfirst').disabled=true;
    //document.getElementById('btnnext').disabled=true;
    //document.getElementById('btnlast').disabled=true;
    //document.getElementById('btnExit').disabled=false;
    //document.getElementById('btnprevious').disabled=true;

    document.getElementById('txtPosTypCode').disabled = true;
    document.getElementById('txtPosType').disabled = true;
    document.getElementById('txtAlias').disabled = true;
    document.getElementById('txtamount').disabled = true;
    document.getElementById('drpremium').disabled = true;
    document.getElementById('txtvalid').disabled = true;
    document.getElementById('txtvalidtill').disabled = true;
    document.getElementById('txtdessigndesc').disabled = true;

    document.getElementById('drpadcategory').disabled = true;
    
    if (document.getElementById('btnNew').disabled == false)
        document.getElementById('btnNew').focus();


    //document.getElementById('drppageno').disabled=true;

    givebuttonpermission('DesigntypeMst');
    setButtonImages();
    return false;
}


function QueryClick2() {
    document.getElementById('lbcommdetail').disabled = true;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    hiddentext = "query";
    chkstatus(FlagStatus);
    z = 0;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnSave').disabled = true;

    var PosTypCode = document.getElementById('txtPosTypCode').value;
    var PosType = document.getElementById('txtPosType').value;
    var Alias = document.getElementById('txtAlias').value;
    var Amount = document.getElementById('txtamount').value;
    var premium = document.getElementById('drpremium').value;

    document.getElementById('txtdessigndesc').value = "";
    document.getElementById('txtPosTypCode').value = "";
    document.getElementById('txtPosType').value = "";
    document.getElementById('txtAlias').value = "";
    document.getElementById('txtamount').value = "";
    document.getElementById('txtvalid').value = "";
    document.getElementById('txtvalidtill').value = "";
    //document.getElementById('drpremium').value=document.getElementById('hiddenprem').value;
    document.getElementById('txtdessigndesc').disabled = false;
    document.getElementById('hiddencompcode').disabled = false;
    document.getElementById('hiddenuserid').disabled = false;
    document.getElementById('txtPosTypCode').disabled = false;
    document.getElementById('txtPosType').disabled = false;
    document.getElementById('txtAlias').disabled = false;
    document.getElementById('txtamount').disabled = false;
    document.getElementById('drpremium').disabled = true;
    document.getElementById('txtvalid').disabled = true;

    document.getElementById('txtdessigndesc').disabled = false;
    document.getElementById('txtvalidtill').disabled = true;
    document.getElementById('btnExecute').focus();

    setButtonImages();

    return false;
}




function SaveClick2(compcode1) {

    //if (document.getElementById('txtEditonCode').value!="1")
    document.getElementById('txtPosType').value = trim(document.getElementById('txtPosType').value);
    document.getElementById('txtPosTypCode').value = trim(document.getElementById('txtPosTypCode').value);
    document.getElementById('txtAlias').value = trim(document.getElementById('txtAlias').value);
    document.getElementById('txtamount').value = trim(document.getElementById('txtamount').value);
    document.getElementById('txtvalid').value = trim(document.getElementById('txtvalid').value);
    document.getElementById('txtvalidtill').value = trim(document.getElementById('txtvalidtill').value);
   
    var compcode = compcode1;
    var userid = document.getElementById('hiddenuserid').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var PosTypCode = document.getElementById('txtPosTypCode').value;
    var PosType = document.getElementById('txtPosType').value;
    var Alias = document.getElementById('txtAlias').value;
    var Amount = document.getElementById('txtamount').value;
    var premium = document.getElementById('drpremium').value;
    //var pageno=document.getElementById('drppageno').value;
    /*if(PosType.indexOf("'")>=0)
    {
    PosType.replace("'","''");
    }
		
		
		
		if(Alias.indexOf("'")>=0)
    {
    Alias.replace("'","''");
    }*/

    if ((document.getElementById('txtPosTypCode').value == "") && (document.getElementById('hiddenauto').value != 1)) {
        alert("Please Enter Design Type Code");
        document.getElementById('txtPosTypCode').focus();
        return false;
    }
    else {
        var PosTypCode = document.getElementById('txtPosTypCode').value;
    }

    if (document.getElementById('txtPosType').value == "") {
        alert("Please Enter Design Type");
        document.getElementById('txtPosType').focus();
        return false;
    }
    else {
        var PosType = document.getElementById('txtPosType').value;
    }

    if (document.getElementById('txtAlias').value == "") {
        alert("Please Enter Alias");
        document.getElementById('txtAlias').focus();
        return false;
    }
    else {
        var Alias = document.getElementById('txtAlias').value;
    }

    if (document.getElementById('txtvalid').value == "") {
        alert("Please Enter Valid From");
        document.getElementById('txtvalid').focus();
        return false;
    }
    if (document.getElementById('txtvalidtill').value == "") {
        alert("Please Enter Valid To");
        document.getElementById('txtvalidtill').focus();
        return false;
    }

    var fdate = document.getElementById('txtvalid').value;
    var tdate = document.getElementById('txtvalidtill').value;
    var dateformat = document.getElementById('hiddendateformat').value;

    //This is to chek dat tdate should be less then fdate
    var txtfdate = "";
    var txttdate = "";
    if (dateformat == "dd/mm/yyyy") {
        if (document.getElementById('txtvalid').value != "") {
            var txt = document.getElementById('txtvalid').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            txtfdate = mm + '/' + dd + '/' + yy;
        }
        else {
            txtfdate = document.getElementById('txtvalid').value;
        }
        if (document.getElementById('txtvalidtill').value != "") {
            var txt = document.getElementById('txtvalidtill').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            txttdate = mm + '/' + dd + '/' + yy;
        }
        else {
            txttdate = document.getElementById('txtvalidtill').value;
        }

    }
    if (dateformat == "yyyy/mm/dd") {
        if (document.getElementById('txtvalid').value != "") {
            var txt = document.getElementById('txtvalid').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            txtfdate = mm + '/' + dd + '/' + yy;
        }
        else {
            txtfdate = document.getElementById('txtvalid').value;
        }
        if (document.getElementById('txtvalidtill').value != "") {
            var txt = document.getElementById('txtvalidtill').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            txttdate = mm + '/' + dd + '/' + yy;
        }
        else {
            txttdate = document.getElementById('txtvalidtill').value;
        }
    }
    if (dateformat == "mm/dd/yyyy" || dateformat == null || dateformat == "" || dateformat == "undefined") {
        txtfdate = document.getElementById('txtvalid').value;
        txttdate = document.getElementById('txtvalidtill').value;
    }

    txtfdate = new Date(txtfdate);
    txttdate = new Date(txttdate);
    if (txttdate < txtfdate) {
        alert("Valid To Date Must Be Greater Than Valid From Date");
        return false;
    }
    /*change ankur*/

    var premium = document.getElementById('drpremium').value;
    
      var length = document.getElementById('drpadcategory').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drpadcategory').options[li].selected == true) {
                if (document.getElementById('drpadcategory').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drpadcategory').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drpadcategory').options[li].value;
                }

            }
        }
        var adcat = abc;

 // var fontcol = document.getElementById('txtfontcolor').value;

        var amount1 = document.getElementById('txtamount').value;
    var description = document.getElementById('txtdessigndesc').value;
    ////////////////////// to check Duplicacy of date and name/////////////////////////////////////
 
  var reschk = DesigntypeMst.chkpastypename(PosTypCode, PosType, compcode, userid, flag, fdate, tdate);
    var ds = reschk.value;
    if (ds.Tables[0].Rows.length > 0) {
        alert("This Ad Design Type has already assigned !! ");
        //document.getElementById('txtPosType').value = "";
        document.getElementById('txtPosType').focus();
        return false;
    }


    if (flag == 1)
    {
     
        DesigntypeMst.modify(compcode, PosTypCode, PosType, Alias, amount1, premium, userid, fdate, tdate, description, adcat);

        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnprevious').disabled = false;

        updateStatus();

        document.getElementById('txtPosTypCode').disabled = true;
        document.getElementById('txtPosType').disabled = true;
        document.getElementById('txtAlias').disabled = true;
        document.getElementById('txtamount').disabled = true;
        document.getElementById('drpremium').disabled = true;
        document.getElementById('txtvalid').disabled = true;
        document.getElementById('txtvalidtill').disabled = true;
        document.getElementById('txtdessigndesc').disabled = true;
        //document.getElementById('drppageno').disabled=true;

        /*document.getElementById('txtPosTypCode').value="";
        document.getElementById('txtPosType').value="";
        document.getElementById('txtAlias').value="";*/

        //alert("Update Successfully");
        if (browser != "Microsoft Internet Explorer") {
            alert("Update Successfully");
        }
        else {
            alert("Update Successfully");
        }
        //alert(xmlObj.childNodes(0).childNodes(1).text);

        advpostypeds.Tables[0].Rows[z].DES_TYPE_CODE = PosTypCode;
        advpostypeds.Tables[0].Rows[z].DES_TYPE = PosType;
        advpostypeds.Tables[0].Rows[z].DES_TYPE_ALIAS = Alias;
        advpostypeds.Tables[0].Rows[z].AMOUNT = Amount;
        advpostypeds.Tables[0].Rows[z].PREMIUM = premium;
        advpostypeds.Tables[0].Rows[z].FROMDATE = document.getElementById('txtvalid').value;
        advpostypeds.Tables[0].Rows[z].TODATE = document.getElementById('txtvalidtill').value;

       
        var x = advpostypeds.Tables[0].Rows.length;
        //y=z;	
        if (z == 0) {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        }

        if (z == (advpostypeds.Tables[0].Rows.length - 1)) {
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
        }
        document.getElementById('btnModify').focus();

        //advpostypeds.Tables[0].Rows[z].Page_no=pageno;
        flag = 0;
        return false;
    }
    else {
        DesigntypeMst.chksave(PosTypCode, compcode, userid, callsave);

        return false;
    }
    setButtonImages();
}

function callsave(res) {
    var ds = res.value;
    if (ds.Tables[0].Rows.length == 0) {
        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        var dateformat = document.getElementById('hiddendateformat').value;
        if ((document.getElementById('txtPosTypCode').value == "") && (document.getElementById('hiddenauto').value != 1)) {
            alert("Please Enter Design Type Code");
            document.getElementById('txtPosTypCode').focus();
            return false;
        }
        else {
            var PosTypCode = document.getElementById('txtPosTypCode').value;
        }

        if (document.getElementById('txtPosType').value == "") {
            alert("Please Enter Design Type");
            document.getElementById('txtPosType').focus();
            return false;
        }
        else {
            var PosType = document.getElementById('txtPosType').value;
        }

        if (document.getElementById('txtAlias').value == "") {
            alert("Please Enter Alias");
            document.getElementById('txtAlias').focus();
            return false;
        }
        else {
            var Alias = document.getElementById('txtAlias').value;
        }

        if (document.getElementById('drpremium').value == "0") {
            alert("Please Enter Premium");
            document.getElementById('drpremium').focus();
            return false;
        }
        else {
            var Alias = document.getElementById('drpremium').value;
        }

        if (document.getElementById('txtamount').value == "") {
            alert("Please Enter Premium");
            document.getElementById('txtamount').focus();
            return false;
        }
        else {
            var Alias = document.getElementById('txtamount').value;
        }
        /*change*/
        var amount1 = document.getElementById('txtamount').value;
        var PosTypCode = document.getElementById('txtPosTypCode').value;
        var PosType = document.getElementById('txtPosType').value;
        var Alias = document.getElementById('txtAlias').value;
        var Amount = document.getElementById('txtamount').value;
        var premium = document.getElementById('drpremium').value;
        var fdate = document.getElementById('txtvalid').value;
        var tdate = document.getElementById('txtvalidtill').value;
        var length=document.getElementById('drpadcategory').length;
         var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drpadcategory').options[li].selected == true) {
                if (document.getElementById('drpadcategory').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drpadcategory').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drpadcategory').options[li].value;
                }

            }
        }
        var adcat = abc;
        
       // var fontcol = document.getElementById('txtfontcolor').value;
             //var pageno=document.getElementById('drppageno').value;
        if (PosType.indexOf("'") >= 0) {
            PosType.replace("'", "''");
        }
        if (Alias.indexOf("'") >= 0) {
            Alias.replace("'", "''");
        }
        var description = document.getElementById('txtdessigndesc').value;
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            //httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

            httpRequest.open("GET", "savedesignpopup.aspx?desingcode=" + PosTypCode, false);
            httpRequest.send('');
            if (httpRequest.readyState == "yes") {
                alert('Session Expired Please Login Again.');
                return false;
            }
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) {
                    id = httpRequest.responseText;
                }
                else {
                    alert('Session Expired Please Login Again.');
                }
            }
        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "savedesignpopup.aspx?desingcode=" + PosTypCode, false);
            xml.Send();
            var dl = xml.responseText;
        }
       
        DesigntypeMst.insert(PosTypCode, PosType, Alias, Amount, premium, compcode, userid, fdate, tdate, description,adcat);

        document.getElementById('btnNew').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('txtPosTypCode').disabled = true;
        document.getElementById('txtPosType').disabled = true;
        document.getElementById('txtAlias').disabled = true;
        document.getElementById('txtamount').disabled = true;
        document.getElementById('drpremium').disabled = true;
        document.getElementById('txtvalid').disabled = true;
        document.getElementById('txtvalidtill').disabled = true;
        //document.getElementById('drppageno').disabled=true;
        document.getElementById('hiddencompcode').disabled = true;
        document.getElementById('hiddenuserid').disabled = true;
        //alert('browser');
        if (browser != "Microsoft Internet Explorer")
        {
           
            alert("Data Saved Successfully");
        }
        else {
            alert("Data Saved Successfully");
        }
        //alert(xmlObj.childNodes(0).childNodes(0).text);
        //alert("Save Successfully");
        document.getElementById('txtvalid').value = "";
        document.getElementById('txtvalidtill').value = "";
        document.getElementById('txtPosTypCode').value = "";
        document.getElementById('txtPosType').value = "";
        document.getElementById('txtAlias').value = "";
        document.getElementById('txtamount').value = "";
        document.getElementById('drpremium').value = "0";
        CancelClick2();

        return false;
    }
    else {
        alert("This Design Type Code Already Exist");
        document.getElementById('txtPosTypCode').value = "";

        document.getElementById('txtPosTypCode').disabled = false;
        document.getElementById('txtPosTypCode').focus();


        return false;
    }
    CancelClick2();
    setButtonImages();
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

function autoornot() {
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


function changeoccured() {
    if (hiddentext == "new") {

        uppercase3();

    }
    else {
        document.getElementById('txtPosType').value = document.getElementById('txtPosType').value.toUpperCase();
    }
    return false;
}


function uppercase3() {
    document.getElementById('txtPosType').value = trim(document.getElementById('txtPosType').value);
    lstr = document.getElementById('txtPosType').value;
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
    if (document.getElementById('txtPosType').value != "") {
        document.getElementById('txtPosType').value = document.getElementById('txtPosType').value.toUpperCase();
        document.getElementById('txtAlias').value = document.getElementById('txtPosType').value;
        if (document.getElementById('txtPosType').value.indexOf("'") >= 0)
        {
            document.getElementById('txtPosType').value.replace("'", "''");
        }
        if (document.getElementById('txtAlias').value.indexOf("'") >= 0)
        {
            document.getElementById('txtAlias').value.replace("'", "''");
        }
        //str=document.getElementById('txtPosType').value;
        str = mstr;
        DesigntypeMst.chkadvposition(str, fillcall);
        return false;
    }
    return false;

}


function fillcall(res)
{
    var ds = res.value;
    var newstr;

    //		    if(ds.Tables[0].Rows.length!=0)
    //		    {
    //		     document.getElementById('txtAlias').value="";
    //		    alert("This Ad Position Type has already assigned !! ");
    //		    document.getElementById('txtPosType').value="";
    //		    
    //		    document.getElementById('txtPosType').focus();
    //    		
    //		    return false;
    //		    }
    //		
    //		        else
    {
        if (ds.Tables[0].Rows.length == 0) {
            newstr = null;
        }
        else {
            newstr = ds.Tables[1].Rows[0].DES_TYPE_CODE;
        }
        if (newstr != null) {
            var code = newstr; //.substr(2,4);
            code++;
            str = str.toUpperCase();
            document.getElementById('txtPosTypCode').value = str.substr(0, 2) + code;
        }
        else {
            str = str.toUpperCase();
            document.getElementById('txtPosTypCode').value = str.substr(0, 2) + "0";
        }
    }
    return false;
}


function userdefine() {
    if (hiddentext == "new") {
        var str = document.getElementById('txtPosType').value;
        //        var res1=AdvPositionTypMst.chkadvposition(str);
        //        var ds=res1.value;
        //        if(ds.Tables[0].Rows.length!=0)
        //		    {i
        //		     document.getElementById('txtAlias').value="";
        //		    alert("This Ad Position Type has already assigned !! ");
        //		    document.getElementById('txtPosType').value="";
        //		    
        //		    document.getElementById('txtPosType').focus();
        //    		
        //		    return false;
        //		    }

        document.getElementById('txtPosTypCode').disabled = false;
        document.getElementById('txtPosType').value = document.getElementById('txtPosType').value.toUpperCase();
        document.getElementById('txtAlias').value = document.getElementById('txtPosType').value;
        auto = document.getElementById('hiddenauto').value;
        return false;
    }
    //        else if(hiddentext=="modify" && document.getElementById('txtPosType').value != hiddenmod)
    //        {
    //        var str=document.getElementById('txtPosType').value;
    //        var res1=AdvPositionTypMst.chkadvposition(str);
    //        var ds=res1.value;
    //        if(ds.Tables[0].Rows.length!=0)
    //		    {
    //		    alert("This Ad Position Type has already assigned !! ");
    //		    document.getElementById('txtPosType').value="";
    //		    
    //		    document.getElementById('txtPosType').focus();
    //    		
    //		    return false;
    //		    }
    //        }

    return false;
}




function ExecuteClick2(compcode1)
{
    ankit = "1";   
    var compcode = compcode1;
    var userid = document.getElementById('hiddenuserid').value;
    var PosTypCode = document.getElementById('txtPosTypCode').value;
    var PosType = document.getElementById('txtPosType').value;
    var Alias = document.getElementById('txtAlias').value;
    var Amount = document.getElementById('txtamount').value;
    var premium = document.getElementById('drpremium').value;
    var adcat = document.getElementById('drpadcategory').value;
    var dateformat = document.getElementById('hiddendateformat').value;
     glaobaladcat = adcat;
    glpostypcode = PosTypCode;
    glpostype = PosType;
    glalias = Alias;
    glamount = Amount;
    glpremium = premium;
    DesigntypeMst.Selectpage(PosTypCode, PosType, Alias, Amount, premium, compcode, userid, dateformat, call_Execute);
   // updateStatus();
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;
    if (document.getElementById('btnModify').disabled == false)
        document.getElementById('btnModify').focus();
    setButtonImages();
    document.getElementById('lbcommdetail').disabled = false;   
    return false;
}

function call_Execute(response)
{
        advpostypeds = response.value;
        //var ds=response.value;
        if (advpostypeds.Tables[0].Rows.length > 0) {
        document.getElementById('txtPosTypCode').value = advpostypeds.Tables[0].Rows[0].DES_TYPE_CODE;
        document.getElementById('txtPosType').value = advpostypeds.Tables[0].Rows[0].DES_TYPE;
        document.getElementById('txtAlias').value = advpostypeds.Tables[0].Rows[0].DES_TYPE_ALIAS;
        /*change ankur*/
        if (advpostypeds.Tables[0].Rows[0].AMOUNT == "0" || advpostypeds.Tables[0].Rows[0].AMOUNT == null) {
            document.getElementById('txtamount').value = "";
        }
        else {
            document.getElementById('txtamount').value = advpostypeds.Tables[0].Rows[0].AMOUNT;
        }
        if (advpostypeds.Tables[0].Rows[0].FROMDATE == "" || advpostypeds.Tables[0].Rows[0].FROMDATE == null) {
            document.getElementById('txtvalid').value = "";
        }
        else {
            document.getElementById('txtvalid').value = (advpostypeds.Tables[0].Rows[0].FROMDATE);
        }
        if (advpostypeds.Tables[0].Rows[0].TODATE == "" || advpostypeds.Tables[0].Rows[0].TODATE == null) {
            document.getElementById('txtvalidtill').value = "";
        }
        else {
            document.getElementById('txtvalidtill').value = (advpostypeds.Tables[0].Rows[0].TODATE);
        }

        if (advpostypeds.Tables[0].Rows[0].DES_DESCRIPTION == "" || advpostypeds.Tables[0].Rows[0].DES_DESCRIPTION == null) {
            document.getElementById('txtdessigndesc').value = "";
        }
        else {

            document.getElementById('txtdessigndesc').value = advpostypeds.Tables[0].Rows[0].DES_DESCRIPTION;
        }
        ///////////////////////////////////////
        document.getElementById('drpremium').value = advpostypeds.Tables[0].Rows[0].PREMIUM;
        document.getElementById('hiddencompcode').value = advpostypeds.Tables[0].Rows[0].COMP_CODE;
        document.getElementById('hiddenuserid').value = advpostypeds.Tables[0].Rows[0].USERID;
        document.getElementById('hiddendateformat').value = advpostypeds.Tables[0].Rows[0].cdt;
        //document.getElementById('drppageno').value=advpostypeds.Tables[0].Rows[0].Page_no;
        
       // document.getElementById('txtfontcolor').value = advpostypeds.Tables[0].Rows[0].FONT;
        
        var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (advpostypeds.Tables[0].Rows[0].ADV_CAT_CODE != null && advpostypeds.Tables[0].Rows[0].ADV_CAT_CODE != "") {
    var adcat = advpostypeds.Tables[0].Rows[0].ADV_CAT_CODE;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
                document.getElementById('drpadcategory').disabled = false;
            }
        }
    }

}

        //updateStatus();
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnprevious').disabled = true;

        if (document.getElementById('btnModify').disbled == false)
            document.getElementById('btnModify').focus();


        if (advpostypeds.Tables[0].Rows.length == 1) {

            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        }

        document.getElementById('txtdessigndesc').disabled = true;
        document.getElementById('txtPosTypCode').disabled = true;
        document.getElementById('txtPosType').disabled = true;
        document.getElementById('txtAlias').disabled = true;
        document.getElementById('txtamount').disabled = true;
        document.getElementById('drpremium').disabled = true;
        //document.getElementById('drppageno').disabled=true;


        z = 0;
    }
    else {

        document.getElementById('txtdessigndesc').disabled = true;
        document.getElementById('txtPosTypCode').disabled = true;
        document.getElementById('txtPosType').disabled = true;
        document.getElementById('txtAlias').disabled = true;
        document.getElementById('txtamount').disabled = true;
        document.getElementById('drpremium').disabled = true;
        CancelClick2();
        alert("Your Search Criteria Does Not Produce Any Result.");
        return false;

    }
    setButtonImages();
}



function showDate(datevalue) {
    var dateformate = document.getElementById("hiddendateformat").value;
    var datev = new Date(datevalue);
    var dd = datev.getDate();
    var mm = datev.getMonth() + 1;
    var yy = datev.getFullYear();

    if (dd < 10)


        dd = "0" + dd;

    if (mm < 10)
        mm = "0" + mm;

    var returndate = "";

    if (dateformate == "dd/mm/yyyy") {
        returndate = dd + "/" + mm + "/" + yy;
    }
    else if (dateformate == "mm/dd/yyyy") {
        returndate = mm + "/" + dd + "/" + yy;
    }
    else if (dateformate == "yyyy/mm/dd") {
        returndate = yy + "/" + mm + "/" + dd;
    }
    return returndate;
}


function FirstClick2() {
    z = 0;
    //var ds=response.value;
    document.getElementById('txtPosTypCode').value = advpostypeds.Tables[0].Rows[0].DES_TYPE_CODE;
    document.getElementById('txtPosType').value = advpostypeds.Tables[0].Rows[0].DES_TYPE;
    document.getElementById('txtAlias').value = advpostypeds.Tables[0].Rows[0].DES_TYPE_ALIAS;
    //document.getElementById('txtamount').value=advpostypeds.Tables[0].Rows[0].Amount;
    /*change ankur*/
    if (advpostypeds.Tables[0].Rows[0].AMOUNT == "0" || advpostypeds.Tables[0].Rows[z].AMOUNT == null) {
        document.getElementById('txtamount').value = "";
    }
    else {
        document.getElementById('txtamount').value = advpostypeds.Tables[0].Rows[0].AMOUNT;
    }

    if (advpostypeds.Tables[0].Rows[0].FROMDATE == "" || advpostypeds.Tables[0].Rows[0].FROMDATE == null) {
        document.getElementById('txtvalid').value = "";
    }
    else {
        document.getElementById('txtvalid').value = advpostypeds.Tables[0].Rows[0].FROMDATE;
    }
    if (advpostypeds.Tables[0].Rows[0].TODATE == "" || advpostypeds.Tables[0].Rows[0].TODATE == null) {
        document.getElementById('txtvalidtill').value = "";
    }
    else {
        document.getElementById('txtvalidtill').value = advpostypeds.Tables[0].Rows[0].TODATE;
    }

    if (advpostypeds.Tables[0].Rows[0].ADTYPE == "" || advpostypeds.Tables[0].Rows[0].ADTYPE == null) {
        document.getElementById('txtdessigndesc').value = "";
    }
    else {

        document.getElementById('txtdessigndesc').value = advpostypeds.Tables[0].Rows[0].ADTYPE;
    }
    
    var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (advpostypeds.Tables[0].Rows[0].ADV_CAT_CODE != null && advpostypeds.Tables[0].Rows[0].ADV_CAT_CODE != "") {
    var adcat = advpostypeds.Tables[0].Rows[0].ADV_CAT_CODE;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}
    ///////////////////////////////////////
    document.getElementById('drpremium').value = advpostypeds.Tables[0].Rows[0].PREMIUM;
    document.getElementById('hiddencompcode').value = advpostypeds.Tables[0].Rows[0].COMP_CODE;
    document.getElementById('hiddenuserid').value = advpostypeds.Tables[0].Rows[0].USERID;
    document.getElementById('hiddendateformat').value = advpostypeds.Tables[0].Rows[0].cdt;
    updateStatus();
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    setButtonImages();
    return false;
}




function NextClick2() {

    //var ds=response.value;
    var y = advpostypeds.Tables[0].Rows.length;
    z++;
    var k = y - 1;

    if (z != -1 && z >= 0) {
        if (z <= y - 1) {
            document.getElementById('txtPosTypCode').value = advpostypeds.Tables[0].Rows[z].DES_TYPE_CODE;
            document.getElementById('txtPosType').value = advpostypeds.Tables[0].Rows[z].DES_TYPE;
            document.getElementById('txtAlias').value = advpostypeds.Tables[0].Rows[z].DES_TYPE_ALIAS;
            //document.getElementById('txtamount').value=advpostypeds.Tables[0].Rows[z].Amount;

            /*change ankur*/
            if (advpostypeds.Tables[0].Rows[z].AMOUNT == "0" || advpostypeds.Tables[0].Rows[z].AMOUNT == null) {
                document.getElementById('txtamount').value = "";
            }
            else {
                document.getElementById('txtamount').value = advpostypeds.Tables[0].Rows[z].AMOUNT;
            }

            if (advpostypeds.Tables[0].Rows[z].FROMDATE == "" || advpostypeds.Tables[0].Rows[z].FROMDATE == null) {
                document.getElementById('txtvalid').value = "";
            }
            else {
                document.getElementById('txtvalid').value = advpostypeds.Tables[0].Rows[z].FROMDATE;
            }
            if (advpostypeds.Tables[0].Rows[z].TODATE == "" || advpostypeds.Tables[0].Rows[z].TODATE == null) {
                document.getElementById('txtvalidtill').value = "";
            }
            else {
                document.getElementById('txtvalidtill').value = advpostypeds.Tables[0].Rows[z].TODATE;
            }
            ///////////////////////////////////////

            document.getElementById('drpremium').value = advpostypeds.Tables[0].Rows[z].PREMIUM;
            document.getElementById('hiddencompcode').value = advpostypeds.Tables[0].Rows[z].COMP_CODE;
            document.getElementById('hiddenuserid').value = advpostypeds.Tables[0].Rows[z].USERID;
            document.getElementById('hiddendateformat').value = advpostypeds.Tables[0].Rows[0].cdt;


            if (advpostypeds.Tables[0].Rows[z].AD_TYPE == "" || advpostypeds.Tables[0].Rows[z].AD_TYPE == null) {
                document.getElementById('txtdessigndesc').value = "";
            }
            else {

                document.getElementById('txtdessigndesc').value = advpostypeds.Tables[0].Rows[z].AD_TYPE;
            }
            
            var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE != null && advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE != "") {
    var adcat = advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}
          
           
            document.getElementById('txtPosTypCode').disabled = true;
            document.getElementById('txtPosType').disabled = true;
            document.getElementById('txtAlias').disabled = true;
            document.getElementById('txtamount').disabled = true;
            document.getElementById('drpremium').disabled = true;
            updateStatus();
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;

            if (document.getElementById('btnModify').disabled == false)
                document.getElementById('btnModify').focus();
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

function PreviousClick2() {
    //var ds=response.value;
    var y = advpostypeds.Tables[0].Rows.length;
    //var p=y-1;
    z--;

    if (document.getElementById('btnnext').disabled = true) {
        document.getElementById('btnnext').disabled = false;
    }
    if (document.getElementById('btnlast').disabled = true) {
        document.getElementById('btnlast').disabled = false;
    }

    if (z != -1 && z >= 0) {
        if (advpostypeds.Tables[0].Rows.length != z && z < y) {



            document.getElementById('txtPosTypCode').value = advpostypeds.Tables[0].Rows[z].DES_TYPE_CODE;
            document.getElementById('txtPosType').value = advpostypeds.Tables[0].Rows[z].DES_TYPE;
            document.getElementById('txtAlias').value = advpostypeds.Tables[0].Rows[z].DES_TYPE_ALIAS;
            //document.getElementById('txtamount').value=advpostypeds.Tables[0].Rows[z].Amount;
            /*change ankur*/
            if (advpostypeds.Tables[0].Rows[z].AMOUNT == "0" || advpostypeds.Tables[0].Rows[z].AMOUNT == null) {
                document.getElementById('txtamount').value = "";
            }
            else {
                document.getElementById('txtamount').value = advpostypeds.Tables[0].Rows[z].AMOUNT;
            }

            if (advpostypeds.Tables[0].Rows[z].FROMDATE == "" || advpostypeds.Tables[0].Rows[z].FROMDATE == null) {
                document.getElementById('txtvalid').value = "";
            }
            else {
                document.getElementById('txtvalid').value = advpostypeds.Tables[0].Rows[z].FROMDATE;
            }
            if (advpostypeds.Tables[0].Rows[z].TODATE == "" || advpostypeds.Tables[0].Rows[z].TODATE == null) {
                document.getElementById('txtvalidtill').value = "";
            }
            else {
                document.getElementById('txtvalidtill').value = advpostypeds.Tables[0].Rows[z].TODATE;
            }

            if (advpostypeds.Tables[0].Rows[z].DES_DESCRIPTION == "" || advpostypeds.Tables[0].Rows[z].DES_DESCRIPTION == null) {
                document.getElementById('txtdessigndesc').value = "";
            }
            else {

                document.getElementById('txtdessigndesc').value = advpostypeds.Tables[0].Rows[z].DES_DESCRIPTION;
            }
            
              var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE != null && advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE != "") {
    var adcat = advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}

            
            
            ///////////////////////////////////////
            document.getElementById('drpremium').value = advpostypeds.Tables[0].Rows[z].PREMIUM;
            document.getElementById('hiddencompcode').value = advpostypeds.Tables[0].Rows[z].COMP_CODE;
            document.getElementById('hiddenuserid').value = advpostypeds.Tables[0].Rows[z].USERID;
            document.getElementById('hiddendateformat').value = advpostypeds.Tables[0].Rows[0].cdt;
            //updateStatus();
            document.getElementById('txtPosTypCode').disabled = true;
            document.getElementById('txtPosType').disabled = true;
            document.getElementById('txtAlias').disabled = true;
            document.getElementById('txtamount').disabled = true;
            document.getElementById('drpremium').disabled = true;


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
    }
    setButtonImages();
    return false;
}

function LastClick2() {
    //var advpostypeds=response.value;
    var y = advpostypeds.Tables[0].Rows.length;
    z = y - 1;
    document.getElementById('txtPosTypCode').value = advpostypeds.Tables[0].Rows[z].DES_TYPE_CODE;
    document.getElementById('txtPosType').value = advpostypeds.Tables[0].Rows[z].DES_TYPE;
    document.getElementById('txtAlias').value = advpostypeds.Tables[0].Rows[z].DES_TYPE_ALIAS;
    //document.getElementById('txtamount').value=advpostypeds.Tables[0].Rows[z].Amount;
    /*change ankur*/
    if (advpostypeds.Tables[0].Rows[z].AMOUNT == "0" || advpostypeds.Tables[0].Rows[z].AMOUNT == null) {
        document.getElementById('txtamount').value = "";
    }
    else {
        document.getElementById('txtamount').value = advpostypeds.Tables[0].Rows[z].AMOUNT;
    }

    if (advpostypeds.Tables[0].Rows[z].FROMDATE == "" || advpostypeds.Tables[0].Rows[z].FROMDATE == null) {
        document.getElementById('txtvalid').value = "";
    }
    else {
        document.getElementById('txtvalid').value = advpostypeds.Tables[0].Rows[z].FROMDATE;
    }
    if (advpostypeds.Tables[0].Rows[z].TODATE == "" || advpostypeds.Tables[0].Rows[z].TODATE == null) {
        document.getElementById('txtvalidtill').value = "";
    }
    else {
        document.getElementById('txtvalidtill').value = advpostypeds.Tables[0].Rows[z].TODATE;
    }


    if (advpostypeds.Tables[0].Rows[z].DES_DESCRIPTION == "" || advpostypeds.Tables[0].Rows[z].DES_DESCRIPTION == null) {
        document.getElementById('txtdessigndesc').value = "";
    }
    else {

        document.getElementById('txtdessigndesc').value = advpostypeds.Tables[0].Rows[z].DES_DESCRIPTION;
    }
    
    var adcatlen = document.getElementById('drpadcategory').options.length;
for (var t2 = 0; t2 < adcatlen; t2++) {
    document.getElementById('drpadcategory').options[t2].selected = false;
}
if (advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE != null && advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE != "") {
    var adcat = advpostypeds.Tables[0].Rows[z].ADV_CAT_CODE;
    var len1 = adcat.split(",");
    for (var a1 = 0; a1 < len1.length; a1++) {
        for (var j = 1; j < adcatlen; j++) {
            if (document.getElementById('drpadcategory').options[j].value == len1[a1]) {
                document.getElementById('drpadcategory').options[j].selected = true;
            }
        }
    }

}
  
    ///////////////////////////////////////

    document.getElementById('drpremium').value = advpostypeds.Tables[0].Rows[z].PREMIUM;
    document.getElementById('hiddencompcode').value = advpostypeds.Tables[0].Rows[z].COMP_CODE;
    document.getElementById('hiddenuserid').value = advpostypeds.Tables[0].Rows[z].USERID;
    document.getElementById('hiddendateformat').value = advpostypeds.Tables[0].Rows[0].cdt;

    document.getElementById('txtPosTypCode').disabled = true;
    document.getElementById('txtPosType').disabled = true;
    document.getElementById('txtAlias').disabled = true;
    document.getElementById('txtamount').disabled = true;
    document.getElementById('drpremium').disabled = true;


    //updateStatus();
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnprevious').disabled = false;

    setButtonImages();
    return false;


}

function ExitClick2() {
    if (confirm("Do You Want To Skip This Page")) {
        //window.location.href='Default.aspx';
        window.close();
        return false;
    }
    setButtonImages();
    return false;
}

function DeleteClick2(compcode1) {
    boolReturn = confirm("Are you sure you wish to delete this?");
   // var compcode = document.getElementById('hiddencompcode').value;
    if (boolReturn == 1) {

        var compcode = compcode1;
        var userid = document.getElementById('hiddenuserid').value;
        var PosTypCode = document.getElementById('txtPosTypCode').value;
        var PosType = document.getElementById('txtPosType').value;
        var Alias = document.getElementById('txtAlias').value;
        var Amount = document.getElementById('txtamount').value;
        var premium = document.getElementById('drpremium').value;
        var dateformat = document.getElementById('hiddendateformat').value;

        DesigntypeMst.delete1(PosTypCode, compcode, userid);
        if (browser != "Microsoft Internet Explorer") {
            alert("Data Deleted Successfully");
        }
        else {
            alert("Data Deleted Successfully");
        }
        //alert(xmlObj.childNodes(0).childNodes(2).text);

        DesigntypeMst.Selectpage(glpostypcode, glpostype, glalias, glamount, glpremium, compcode, userid, call_delete);
        //AdvPositionTypMst.Selectfnpl(PosTypCode,PosType,Alias,pageno,compcode,userid,call_delete);
    }
    else {
        return false;

        setButtonImages();
    }
    return false;
}

function call_delete(res) {
    advpostypeds = res.value;
    len = advpostypeds.Tables[0].Rows.length;

    if (advpostypeds.Tables[0].Rows.length == 0) {
        alert("No More Data is here to be deleted");
        document.getElementById('txtPosTypCode').value = "";
        document.getElementById('txtPosType').value = "";
        document.getElementById('txtAlias').value = "";
        document.getElementById('txtamount').value = "";
        document.getElementById('drpremium').value = "0";

        CancelClick2();
        return false;

    }
    else if (z == -1 || z >= len) {
    document.getElementById('txtPosTypCode').value = advpostypeds.Tables[0].Rows[0].Pos_Type_Code;
    document.getElementById('txtPosType').value = advpostypeds.Tables[0].Rows[0].Pos_Type;
    document.getElementById('txtAlias').value = advpostypeds.Tables[0].Rows[0].Pos_Type_Alias; 
        //document.getElementById('txtamount').value=advpostypeds.Tables[0].Rows[0].Amount;

        /*change ankur*/
    if (advpostypeds.Tables[0].Rows[0].AMOUNT == "0" || advpostypeds.Tables[0].Rows[0].AMOUNT == null) {
            document.getElementById('txtamount').value = "";
        }
        else {
            document.getElementById('txtamount').value = advpostypeds.Tables[0].Rows[0].AMOUNT;
        }
    if (advpostypeds.Tables[0].Rows[0].FROM_DATE == "" || advpostypeds.Tables[0].Rows[0].FROM_DATE == null) {
            document.getElementById('txtvalid').value = "";
        }
        else {
            document.getElementById('txtvalid').value = advpostypeds.Tables[0].Rows[0].FROM_DATE;
        }
        if (advpostypeds.Tables[0].Rows[0].TO_DATE == "" || advpostypeds.Tables[0].Rows[0].TO_DATE == null) {
            document.getElementById('txtvalidtill').value = "";
        }
        else {
            document.getElementById('txtvalidtill').value = advpostypeds.Tables[0].Rows[0].TO_DATE;
        }



        if (advpostypeds.Tables[0].Rows[0].AD_TYPE == "" || advpostypeds.Tables[0].Rows[0].AD_TYPE == null) {
            document.getElementById('txtdessigndesc').value = "";
        }
        else {

            document.getElementById('txtdessigndesc').value = advpostypeds.Tables[0].Rows[0].AD_TYPE;
        }
        ///////////////////////////////////////

        document.getElementById('drpremium').value = advpostypeds.Tables[0].Rows[0].premium;
        //document.getElementById('drpremium').value = advpostypeds.Tables[0].Rows[z].premium;
        document.getElementById('hiddencompcode').value = advpostypeds.Tables[0].Rows[0].COMP_CODE;
        document.getElementById('hiddenuserid').value = advpostypeds.Tables[0].Rows[0].userid;
        document.getElementById('hiddendateformat').value = advpostypeds.Tables[0].Rows[0].cdt;
    }

    else {
        document.getElementById('txtPosTypCode').value = advpostypeds.Tables[0].Rows[0].Pos_Type_Code;
        document.getElementById('txtPosType').value = advpostypeds.Tables[0].Rows[0].Pos_Type;
        document.getElementById('txtAlias').value = advpostypeds.Tables[0].Rows[0].Pos_Type_Alias; ;
        //document.getElementById('txtamount').value=advpostypeds.Tables[0].Rows[z].Amount;


        /*change ankur*/
        if (advpostypeds.Tables[0].Rows[z].Amount == "0" || advpostypeds.Tables[0].Rows[0].AMOUNT == null) {
            document.getElementById('txtamount').value = "";
        }
        else {
            document.getElementById('txtamount').value = advpostypeds.Tables[0].Rows[0].AMOUNT;
        }

        if (advpostypeds.Tables[0].Rows[z].FROM_DATE == "" || advpostypeds.Tables[0].Rows[0].FROM_DATE == null) {
            document.getElementById('txtvalid').value = "";
        }
        else {
            document.getElementById('txtvalid').value = advpostypeds.Tables[0].Rows[0].FROM_DATE;
        }
        if (advpostypeds.Tables[0].Rows[z].TO_DATE == "" || advpostypeds.Tables[0].Rows[0].TO_DATE == null) {
            document.getElementById('txtvalidtill').value = "";
        }
        else {
            document.getElementById('txtvalidtill').value = advpostypeds.Tables[0].Rows[0].TO_DATE;
        }

        if (advpostypeds.Tables[0].Rows[z].AD_TYPE == "" || advpostypeds.Tables[0].Rows[0].AD_TYPE == null) {
            document.getElementById('txtdessigndesc').value = "";
        }
        else {

            document.getElementById('txtdessigndesc').value = advpostypeds.Tables[0].Rows[0].AD_TYPE;
        }
        
        ///////////////////////////////////////


        document.getElementById('drpremium').value = advpostypeds.Tables[0].Rows[0].premium;
        document.getElementById('hiddencompcode').value = advpostypeds.Tables[0].Rows[0].COMP_CODE;
        document.getElementById('hiddenuserid').value = advpostypeds.Tables[0].Rows[0].userid;
        document.getElementById('hiddendateformat').value = advpostypeds.Tables[0].Rows[0].cdt;
    }
    //alert ("Data Deleted");	

    setButtonImages();

    return false;

}

function ModifyClick2() {
    flag = 1;
    flag2 = "1";

    ankit = "0";
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnExit').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnExit').disabled = false;

    chkstatus(FlagStatus);
    hiddentext = "modify";
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;

    hiddenmod = document.getElementById('txtPosType').value;
    document.getElementById('txtPosTypCode').disabled = true;
    document.getElementById('txtPosType').disabled = false;
    document.getElementById('txtAlias').disabled = false;
    document.getElementById('txtamount').disabled = false;
   // document.getElementById('drpremium').value = document.getElementById('hiddenprem').value
    document.getElementById('drpremium').disabled = false;
    document.getElementById('txtvalid').disabled = false;
    document.getElementById('txtvalidtill').disabled = false;
    document.getElementById('txtdessigndesc').disabled = false;
    
  //  document.getElementById('txtfontcolor').disabled = false;
document.getElementById('drpadcategory').disabled = false;

    document.getElementById('btnSave').focus();


    //document.getElementById('drppageno').disabled=false;

    setButtonImages();
    return false;
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






function checkamount() {
    var sau = parseFloat(document.getElementById('txtamount').value);
    document.getElementById('txtamount').value = sau;
    if (document.getElementById('drpremium').value == "per") {
        if (sau > 500) {
            alert("Amount Percentage should not be greater than 500");
            document.getElementById('txtamount').value = "";
            document.getElementById('txtamount').focus();
            return false;
        }

    }
}




function Cleartext() {
    document.getElementById("txtamount").value = "";
}


function Exit() {

    window.close();
    return false;
}

function commission()
 {

     var logocode = document.getElementById('txtPosTypCode').value; 
   // var logocode = document.getElementById('txtPosTypCode').value;
   // var strReturn = window.open('logo_Premium.aspx?' + '&logocode=' + logocode + '&temp=' + temp + '&flag2=' + flag2 + '&ankit=' + ankit, '', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=900px,height=400px');
     if (document.getElementById('lbcommdetail').disabled == true)
     {
         return false;
     }   
     if (popup == "1")
     {       
         if (document.getElementById('txtPosType').value == "") {
             alert("Please Fill Design Type");
             document.getElementById('txtPosType').focus(); 
             return false;
         }
     }
     var strReturn = window.open('design_premium.aspx?' + '&logocode=' + logocode + '&flag2=' + flag2 + '&ankit=' + ankit, '', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=700px,height=400px');
    return false;

}
