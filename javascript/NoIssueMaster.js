var xmlObj;
var code10;
var flag;
var z = 0;
var show = "0";
var flag = "0";
var z = "0";
var auto = "";
var hiddentext = "0";
var hiddentext1 = "";
var modify = "0";
var dsnoissueexecute;
var popwin1;
var mod = "0";
var txtdate;
var nameedi = "";
var drpissday;
var check;
var dsnoissuedelete;
var saurabh_modify;
var saurabh;
var submod = "0";
var saurabh_clear = "";
var global_ds;
var saurabh1;
var saurabh2;
var saurabh3;
var saurabh4;

//	                 var paycode	 =    document.getElementById('txtpaycode').value;
//					var payname	 =	document.getElementById('txtpayment').value;
//					var compcode =	document.getElementById('hiddencompcode').value;
//					var userid	 =		document.getElementById('hiddenuserid').value;
//	

var dspayexecute;

var dspaydelete;


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
    // cancelissue('NoIssueMaster');

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




function exitissue() {
    if (confirm("Do You Want To Skip This Page")) {
        if (typeof (popup) != "undefined") {
            popup.close();
        }
        window.close();
        return false;
    }
    return false;
}

function cancelissue(formname) {


    document.getElementById('table1').style.display = 'none';

    document.getElementById('grid1123').value = "";
    //    document.getElementById('grid1123').value = ""; 

    document.getElementById('grid1123').innerHTML = "";
    submod = "0";
    document.getElementById('hiddensubmit').value = "0";
    saurabh_clear = "0";
    saurabh_modify = "0";

    show = "0";
    flag = "0";
    document.getElementById('dpdedition').value = "0";
    document.getElementById('txtnoissuecode').value = "";



    document.getElementById('dpdedition').disabled = true;
    document.getElementById('txtnoissuecode').disabled = true;
    document.getElementById('Noissuelink').disabled = true;

    mod = "0";
    modify = "0";

    chkstatus(FlagStatus);
    givebuttonpermission(formname);

    if (document.getElementById('btnNew').disable == false)
        document.getElementById('btnNew').focus();

    var noissuecode = document.getElementById('hiddennoissuecode').value;
    var id;
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

        httpRequest.open("GET", "noissuenull.aspx?noissuecode=" + noissuecode, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                id = httpRequest.responseText;
            }
            else {
                alert('There was a problem with the request.');
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "noissuenull.aspx?noissuecode=" + noissuecode, false);
        xml.Send();
    }

    setButtonImages();
    return false;
}


function newissue() {


    document.getElementById('table1').style.display = 'none';
    flag = 0;
    show = "1";
    document.getElementById('hiddenchk').value = "0";
    modify = "0";
    saurabh_clear = "0";
    submod = "0";
    document.getElementById('hiddensubmit').value = "0";
    document.getElementById('Noissuelink').disabled = false;  //saurabh
    document.getElementById('txtnoissuecode').value = "";
    document.getElementById('dpdedition').value = "0";

    //    if(document.getElementById('hiddenauto').value==1)
    //    {
    document.getElementById('txtnoissuecode').disabled = true;
    //    }
    //    else
    //    {
    //    document.getElementById('txtnoissuecode').disabled=false;
    //    }

    document.getElementById('dpdedition').disabled = false;

    //    if(document.getElementById('hiddenauto').value==1)
    //    {
    document.getElementById('dpdedition').focus();
    //    }
    //    else
    //    {
    //    document.getElementById('txtnoissuecode').focus();
    //    }


    hiddentext = "new";
    chkstatus(FlagStatus);

    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('Noissuelink').disabled = false;
    setButtonImages();
    return false;


}


function deleteissue() {



    document.getElementById('grid1123').style.display = 'none';
    document.getElementById('grid1123').value = "";


    var edition = document.getElementById('dpdedition').value.split('~')[0];
    var issuecode = document.getElementById('txtnoissuecode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    boolReturn = confirm("Are you sure you wish to delete this?");
    if (boolReturn == 1) {
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
        var res1 = NoIssueMaster.addeditionsupp(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, edition);
        var dsn_ew = res1.value;
        if (dsn_ew.Tables[0].Rows.length > 0) {
            for (var i = 0; i < dsn_ew.Tables[0].Rows.length; i++) {
                var issuecode1 = dsn_ew.Tables[0].Rows[i].Edition_Code;
                var edition1 = dsn_ew.Tables[0].Rows[i].Edition_Code;
                NoIssueMaster.deletecode(edition1, issuecode1, compcode, userid);
            }
        }
        NoIssueMaster.deletecode(edition, issuecode, compcode, userid);
        //			alert("Data Deleted Successfully");

        //alert(xmlObj.childNodes(0).childNodes(2).text);
        if (browser != "Microsoft Internet Explorer") {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }

        NoIssueMaster.exe(saurabh1, saurabh2, saurabh3, saurabh4, delcall);

    }
    else {
        setButtonImages();
        return false;
    }
    setButtonImages();
    return false;
}

function delcall(res) {
    var ds = res.value;
    len = ds.Tables[0].Rows.length;
    if (ds.Tables[0].Rows.length == 0) {
        alert("No More Data is here to be deleted");

        document.getElementById('dpdedition').value = "0";
        document.getElementById('txtnoissuecode').value = "";
        cancelissue('NoIssueMaster');
        return false;
    }
    else if (z >= len || z == -1) {
        //document.getElementById('dpdedition').value=ds.Tables[0].Rows[0].Edition_Code;
        for (var i1 = 0; i1 < document.getElementById('dpdedition').options.length; i1++) {
            if (document.getElementById('dpdedition').options[i1].value.split('~')[0] == ds.Tables[0].Rows[0].Edition_Code) {
                document.getElementById('dpdedition').options[i1].selected = true;
            }
            else {
                document.getElementById('dpdedition').options[i1].selected = false;
            }
        }
        document.getElementById('txtnoissuecode').value = ds.Tables[0].Rows[0].No_Iss_Code;
    }
    else {
        //document.getElementById('dpdedition').value=ds.Tables[0].Rows[z].Edition_Code;
        for (var i1 = 0; i1 < document.getElementById('dpdedition').options.length; i1++) {
            if (document.getElementById('dpdedition').options[i1].value.split('~')[0] == ds.Tables[0].Rows[z].Edition_Code) {
                document.getElementById('dpdedition').options[i1].selected = true;
            }
            else {
                document.getElementById('dpdedition').options[i1].selected = false;
            }
        }
        document.getElementById('txtnoissuecode').value = ds.Tables[0].Rows[z].No_Iss_Code;
    }
    setButtonImages();
    return false;
}


function modifyissue() {
    saurabh_clear = "1";
    saurabh_modify = "1";
    flag = 1;
    show = "2";
    document.getElementById('hiddenchk').value = "1";
    document.getElementById('hiddensubmit').value = "1";
    submod = "1";
    modify = "1";

    document.getElementById('txtnoissuecode').disabled = true;
    document.getElementById('dpdedition').disabled = false;
    document.getElementById('Noissuelink').disabled = false;


    chkstatus(FlagStatus);

    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = true;


    mod = "1";
    hiddentext = "modify";
    setButtonImages();
    return false;
}

function saveissue() {
    document.getElementById('txtnoissuecode').value = trim(document.getElementById('txtnoissuecode').value);
    var sa = trim(document.getElementById('txtnoissuecode').value);
    //                if(document.getElementById('hiddenauto').value!=1 && sa=="")
    //                {
    //                alert("Please Fill No Issue Code");
    //                document.getElementById('txtnoissuecode').value="";
    //                document.getElementById('txtnoissuecode').focus();
    //                return false;
    //                }
    //                else 
    if (document.getElementById('dpdedition').value == "0" && mod != "1") {
        alert("Please Select Edition");
        if (document.getElementById('dpdedition').disabled == false)
            document.getElementById('dpdedition').focus();
        return false;
    }
    else {
        var payname = document.getElementById('dpdedition').value.split('~')[0];
    }

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
    var edition = document.getElementById('dpdedition').value.split('~')[0];
   // alert(document.getElementById('dpdedition').value)
   // alert(edition)
    var issuecode = document.getElementById('txtnoissuecode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var date = document.getElementById('hiddendate').value;
    var noissueday = document.getElementById('hiddenday').value;





    if ((mod != "1") && (mod != null)) {
        ///////////////////
        var edition = "";
        nameedi = "";
        var counted = 0;
        var tem_edit = "";
        var editionalias = "";
        for (var ui = 0; ui < document.getElementById('dpdedition').options.length; ui++) {
            var noissuecode = document.getElementById('txtnoissuecode').value;
            if (document.getElementById('dpdedition').options[ui].selected == true) {
                if (document.getElementById('dpdedition').options[ui].value != "0") {
                    tem_edit = document.getElementById('dpdedition').options[ui].value.split('~')[0];
                    editionalias = document.getElementById('dpdedition').options[ui].value.split('~')[1];
                    var res = NoIssueMaster.addeditionsupp(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, editionalias/*tem_edit*/);
                    var ds1 = res.value;
                    if (ds1.Tables[0].Rows.length > 0) {
                        for (var i = 0; i < ds1.Tables[0].Rows.length; i++) {
                            lstr = ds1.Tables[0].Rows[i].Edition_Code;
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
                            str = mstr;


                            var rescode = NoIssueMaster.issuecode_auto(str);
                            var ds = rescode.value;

                            var newstr;

                            if (ds.Tables[1].Rows.length == 0) {
                                newstr = null;
                            }
                            else {
                                newstr = ds.Tables[1].Rows[0].No_Iss_Code;
                            }
                            if (newstr != null) {
                                var code = newstr;
                                code++;
                                noissuecode = str.substr(0, 2) + code;
                            }
                            else {
                                noissuecode = str.substr(0, 2) + "0";
                            }
                            if (ds.Tables[0].Rows.length != 0) {

                                nameedi += document.getElementById('dpdedition').options[ui].text + ",";
                                noissuecode = str;
                            }

                            /////////////////////////////////////////////////////////////////////aa
                            var id;
                            if (browser != "Microsoft Internet Explorer") {
                                var httpRequest = null;
                                httpRequest = new XMLHttpRequest();
                                if (httpRequest.overrideMimeType) {
                                    httpRequest.overrideMimeType('text/xml');
                                }

                                httpRequest.onreadystatechange = function () {
                                    alertContents(httpRequest)
                                };

                                httpRequest.open("GET", "savenoissuedate.aspx?issuecode=" + noissuecode + "&editioncd=" + document.getElementById('dpdedition').value.split('~')[1], false);
                                httpRequest.send('');
                                //alert(httpRequest.readyState);
                                if (httpRequest.readyState == 4) {
                                    //alert(httpRequest.status);
                                    if (httpRequest.status == 200) {
                                        dl = httpRequest.responseText;
                                    }
                                    else {
                                        alert('There was a problem with the request.');
                                    }
                                }
                            }
                            else {
                                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                                xml.Open("GET", "savenoissuedate.aspx?issuecode=" + noissuecode + "&editioncd=" + document.getElementById('dpdedition').value.split('~')[1], false);
                                xml.Send();
                                var dl = xml.responseText;
                            }
                            if (dl == "NO") {
                                alert("Please Fill No Issue Date");
                                return false;
                            }

                            {
                                counted = counted + 1;
                                NoIssueMaster.insert(lstr, noissuecode, compcode, userid, editionalias);

                                //return false;
                            }


                        }
                    }
                    //noissuecode=noissuecode+ui;
                    lstr = tem_edit;
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
                    str = mstr;


                    var rescode = NoIssueMaster.issuecode_auto(str);
                    var ds = rescode.value;

                    var newstr;

                    if (ds.Tables[1].Rows.length == 0) {
                        newstr = null;
                    }
                    else {
                        newstr = ds.Tables[1].Rows[0].No_Iss_Code;
                    }
                    if (newstr != null) {
                        var code = newstr;
                        code++;
                        noissuecode = str.substr(0, 2) + code;
                    }
                    else {
                        noissuecode = str.substr(0, 2) + "0";
                    }
                    if (ds.Tables[0].Rows.length != 0) {

                        nameedi += document.getElementById('dpdedition').options[ui].text + ",";
                        noissuecode = str;
                    }
                    /////////////////////////////////////////////////////////////////////aa
                    var id;
//                    if (browser != "Microsoft Internet Explorer") {
//                        var httpRequest = null;
//                        httpRequest = new XMLHttpRequest();
//                        if (httpRequest.overrideMimeType) {
//                            httpRequest.overrideMimeType('text/xml');
//                        }

//                        httpRequest.onreadystatechange = function () {
//                            alertContents(httpRequest)
//                        };

//                        httpRequest.open("GET", "savenoissuedate.aspx?issuecode=" + noissuecode + "&editioncd=" + document.getElementById('dpdedition').value.split('~')[1], false);
//                        httpRequest.send('');
//                        //alert(httpRequest.readyState);
//                        if (httpRequest.readyState == 4) {
//                            //alert(httpRequest.status);
//                            if (httpRequest.status == 200) {
//                                dl = httpRequest.responseText;
//                            }
//                            else {
//                                alert('There was a problem with the request.');
//                            }
//                        }
//                    }
//                    else {
//                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
//                        xml.Open("GET", "savenoissuedate.aspx?issuecode=" + noissuecode + "&editioncd=" + document.getElementById('dpdedition').value.split('~')[1], false);
//                        xml.Send();
//                        var dl = xml.responseText;
//                    }
//                    if (dl == "NO") {
//                        alert("Please Fill No Issue Date");
//                        return false;
//                    }

//                    {
//                        counted = counted + 1;
//                        NoIssueMaster.insert(tem_edit, noissuecode, compcode, userid, editionalias);
//                        document.getElementById('txtnoissuecode').value = noissuecode;
//                        //return false;
//                    }
                    //}
                }
            }

        }
        if (nameedi != "") {
            if (counted != 0)
                alert("Data Saved Successfully. & " + nameedi + " Edition has been already assigned.");
            else
                alert("" + nameedi + " Edition has been already assigned.");
        }
        else
            alert("Data Saved Successfully");

        if (modify == "1") {
            show = "0";
        }





        document.getElementById('txtnoissuecode').value = "";
        document.getElementById('dpdedition').value = "0";

        document.getElementById('txtnoissuecode').disabled = true;
        document.getElementById('dpdedition').disabled = true;

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
        document.getElementById('Noissuelink').disabled = true;
        document.getElementById('btnlast').disabled = true;
        //    cancelissue('NoIssueMaster');   //saurabh added
        //setButtonImages();

        /////////////////////
        /*
        var noissuecode=document.getElementById('hiddennoissuecode').value;
        var id;
        if(browser!="Microsoft Internet Explorer")
        {
        var  httpRequest =null;
        httpRequest= new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
        httpRequest.overrideMimeType('text/xml'); 
        }

        httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

        httpRequest.open("GET","savenoissuedate.aspx?issuecode="+issuecode, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) 
        {
        //alert(httpRequest.status);
        if (httpRequest.status == 200) 
        {
        dl=httpRequest.responseText;   
        }
        else 
        {
        alert('There was a problem with the request.');
        }
        }
        }
        else
        {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open( "GET","savenoissuedate.aspx?issuecode="+issuecode, false );
        xml.Send();
        var dl=xml.responseText;
        }
        if(dl=="NO")
        {
        alert("Please Fill No Issue Date");
        return false;
        }

        {

        NoIssueMaster.chk(issuecode,compcode,userid,callchk);
        return false;
        }
        */
        var noissuecode = document.getElementById('hiddennoissuecode').value;

        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

            httpRequest.open("GET", "noissuenull.aspx?noissuecode=" + noissuecode, false);
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) {
                    id = httpRequest.responseText;
                }
                else {
                    alert('There was a problem with the request.');
                }
            }
        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "noissuenull.aspx?noissuecode=" + noissuecode, false);
            xml.Send();
        }
        submod = "0";
        document.getElementById('hiddensubmit').value = "0";
        // alert(xmlObj.childNodes[0].childNodes[0].text);
        //        if(browser!="Microsoft Internet Explorer")
        //        {
        //        alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
        //        }
        //        else
        //        {
        //        alert(xmlObj.childNodes(0).childNodes(0).text);
        //        }

        setButtonImages();
        return false;
    }
    else {

        var issuecode1 = document.getElementById('txtnoissuecode').value;
        //               for(var ui=0;ui<document.getElementById('dpdedition').options.length;ui++)
        //				{
        //				//var noissuecode=document.getElementById('txtnoissuecode').value;
        //				    if(document.getElementById('dpdedition').options[ui].selected==true)
        //				    {
        //				        if(document.getElementById('dpdedition').options[ui].value!="0")
        //				        {
        edition = document.getElementById('dpdedition').value.split('~')[0];
        editionalias = document.getElementById('dpdedition').value.split('~')[1];
        //				        }
        //				    }
        //				 }
        NoIssueMaster.modify(edition, issuecode1, compcode, userid, editionalias);

        updateStatus();
        global_ds.Tables[0].Rows[z].No_Iss_Code = document.getElementById('txtnoissuecode').value;
        global_ds.Tables[0].Rows[z].Edition_Code = document.getElementById('dpdedition').value.split('~')[0];

        //alert(ds.Tables[0].Rows.Count);

        var x = global_ds.Tables[0].Rows.length;
        y = z;
        if (z == 0) {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        }

        if (z == (global_ds.Tables[0].Rows.length - 1)) {
            document.getElementById('btnNext').disabled = true;
            document.getElementById('btnLast').disabled = true;
        }


        document.getElementById('txtnoissuecode').disabled = true;

        document.getElementById('dpdedition').disabled = true; //false
        //document.getElementById('Noissuelink').disabled=true;
        mod = "0";

        if (modify == "1") {
            show = "0";
        }

        submod = "0";
        document.getElementById('hiddensubmit').value = "0";

        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnModify').focus();

        //alert(xmlObj.childNodes[0].childNodes[1].text);
        if (browser != "Microsoft Internet Explorer") {
            alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
        }
        else {
            alert(xmlObj.childNodes(0).childNodes(1).text);
        }
        setButtonImages();
        return false;
    }

    setButtonImages();
    return false;
}

function callchk(res) {
    var ds = res.value;
    var dt = document.getElementById('hiddendate').value;

    var dy = document.getElementById('hiddenday').value;

    if (ds.Tables[0].Rows.length == 0) {
        var edition = document.getElementById('dpdedition').value.split('~')[0];
        var issuecode = document.getElementById('txtnoissuecode').value;
        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        var date = document.getElementById('hiddendate').value;
        var noissueday = document.getElementById('hiddenday').value;

        NoIssueMaster.insert(edition, issuecode, compcode, userid);

        //		NoIssueMaster.submit(date,noissueday,issuecode, compcode,userid )



        if (modify == "1") {
            show = "0";
        }


        //	alert("Data Saved Successfully");
        if (browser != "Microsoft Internet Explorer") {
            alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
        }
        else {
            alert(xmlObj.childNodes(0).childNodes(0).text);
        }


        document.getElementById('txtnoissuecode').value = "";
        document.getElementById('dpdedition').value = "0";

        document.getElementById('txtnoissuecode').disabled = true;
        document.getElementById('dpdedition').disabled = true;

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
        document.getElementById('Noissuelink').disabled = true;
        document.getElementById('btnlast').disabled = true;
        //    cancelissue('NoIssueMaster');   //saurabh added
        setButtonImages();
        return false;
    }
    else {
        alert("This No.Issue Code Already Exist. Try Another Code!!");
        return false;
    }

    cancelissue('NoIssueMaster');
    return false;
}

function queryissue() {

    document.getElementById('table1').style.display = 'none';
    document.getElementById('view').disabled = true;



    show = "0";
    /*document.getElementById('btnNew').disabled=true;
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
    document.getElementById('btnExit').disabled=false;*/

    chkstatus(FlagStatus);

    document.getElementById('Noissuelink').disabled = true;   //saurabh
    document.getElementById('grid1123').value = "";
    document.getElementById('grid1123').innerHTML = "";
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnSave').disabled = true;

    document.getElementById('dpdedition').value = "0";
    document.getElementById('txtnoissuecode').value = "";
    z = 0;


    document.getElementById('dpdedition').disabled = false;
    document.getElementById('txtnoissuecode').disabled = false;
    mod = "0";
    hiddentext = "query";
    setButtonImages();
    document.getElementById('btnExecute').focus();

    return false;
}

function exeissue() {


    document.getElementById('view').disabled = false;

    saurabh_clear = "1";
    var edition;
    var edition_alias;
    for (i = 0; i < document.getElementById('dpdedition').options.length - 1; i++) {
        if (document.getElementById('dpdedition').options[i] != null) {
            if (document.getElementById('dpdedition').options[i].selected == true) {
                edition = document.getElementById('dpdedition').options[i].value.split('~')[0];
                edition_alias = document.getElementById('dpdedition').options[i].value.split('~')[1];
            }
        }
    }
    //var edition=   document.getElementById('dpdedition').value;
    var issuecode = document.getElementById('txtnoissuecode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    saurabh1 = document.getElementById('dpdedition').value.split('~')[0];
    saurabh2 = document.getElementById('txtnoissuecode').value;
    saurabh3 = document.getElementById('hiddencompcode').value;
    saurabh4 = document.getElementById('hiddenuserid').value;
    if (document.getElementById('dpdedition').value == "0") {
        saurabh5 = "";

    }
    else {
        saurabh5 = document.getElementById('dpdedition').value.split('~')[1];
    }
    document.getElementById('Noissuelink').disabled = false;

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
    NoIssueMaster.exe(saurabh1, saurabh5, issuecode, compcode, userid, callexe);

    document.getElementById('dpdedition').disabled = true;
    document.getElementById('txtnoissuecode').disabled = true;

    updateStatus();

    mod = "0";

    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;
    if (document.getElementById('btnModify').disabled == false)
        document.getElementById('btnModify').focus();

    saurabh_clear = "1";

    return false;
}

function callexe(res) {

    document.getElementById('dpdedition').disabled = true;

    global_ds = res.value;
    if (global_ds.Tables[0].Rows.length > 0) {
        //document.getElementById('dpdedition').value=global_ds.Tables[0].Rows[0].Edition_Code;
        //for(var i1=0;i1<document.getElementById('dpdedition').options.length;i1++)
        //{

        //    if(document.getElementById('dpdedition').options[i1].value.split('~')[0]==global_ds.Tables[0].Rows[0].Edition_Code && document.getElementById('dpdedition').options[i1].value.split('~')[1]==global_ds.Tables[0].Rows[0].EDITIONALIAS)
        //    {
        //        document.getElementById('dpdedition').options[i1].selected=true;
        //    }
        //    else
        //    {
        //    document.getElementById('dpdedition').options[i1].selected=false;
        //    }
        //}
        var companylist = global_ds.Tables[0].Rows[0].EDITIONALIAS;
        for (var t = 0; t < document.getElementById('dpdedition').options.length; t++) {
            document.getElementById('dpdedition').options[t].selected = false;
        }
        if (companylist != "" && companylist != null) {
            var data = companylist.split(",");
            for (var t = 0; t < data.length; t++) {
                for (var n = 1; n < document.getElementById('dpdedition').options.length; n++) {
                    if (data[t] == document.getElementById('dpdedition').options[n].value.split('~')[0]) {
                        document.getElementById('dpdedition').options[n].selected = true;
                    }

                }
            }
        }
        document.getElementById('txtnoissuecode').value = global_ds.Tables[0].Rows[0].No_Iss_Code;

        /*document.getElementById('btnNew').disabled=true;
        document.getElementById('btnSave').disabled=true;
        document.getElementById('btnModify').disabled=false;
        document.getElementById('btnDelete').disabled=false;
        document.getElementById('btnQuery').disabled=false;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnCancel').disabled=false;		
        document.getElementById('btnfirst').disabled=false;				
        document.getElementById('btnnext').disabled=false;					
        document.getElementById('btnprevious').disabled=false;			
        document.getElementById('btnlast').disabled=false;	
        document.getElementById('btnExit').disabled=false;

        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;*/

        if (global_ds.Tables[0].Rows.length == 1) {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        }
        setButtonImages();
        return false;
    }

    else {
        alert("Your Search Criteria Does Not Produce Any Result");
        document.getElementById('dpdedition').disabled = true;
        document.getElementById('txtnoissuecode').disabled = true;
        cancelissue('NoIssueMaster');
        return false;
    }
    setButtonImages();
    return false;
}


function firstissue() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    //	NoIssueMaster.fnpl(compcode,userid)//,firstcall)


    updateStatus();

    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;

    /*  document.getElementById('btnNew').disabled=true;
    document.getElementById('btnSave').disabled=true;
    document.getElementById('btnModify').disabled=false;
    document.getElementById('btnDelete').disabled=false;
    document.getElementById('btnQuery').disabled=false;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnCancel').disabled=false;
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnnext').disabled=false;
    document.getElementById('btnprevious').disabled=true;
    document.getElementById('btnlast').disabled=false;
    document.getElementById('btnExit').disabled=false;*/


    //		return false;
    //}

    //function firstcall(response)
    //{		
    z = 0;
    //	global_ds=response.value;
    //document.getElementById('dpdedition').value=global_ds.Tables[0].Rows[0].Edition_Code;
    //            for(var i1=0;i1<document.getElementById('dpdedition').options.length;i1++)
    //              {
    //                if(document.getElementById('dpdedition').options[i1].value.split('~')[0]==global_ds.Tables[0].Rows[0].Edition_Code)
    //                {
    //                    document.getElementById('dpdedition').options[i1].selected=true;
    //                }
    //                else
    //                {
    //                document.getElementById('dpdedition').options[i1].selected=false;
    //                }
    //              }
    var companylist = global_ds.Tables[0].Rows[0].EDITIONALIAS;
    for (var t = 0; t < document.getElementById('dpdedition').options.length; t++) {
        document.getElementById('dpdedition').options[t].selected = false;
    }
    if (companylist != "" && companylist != null) {
        var data = companylist.split(",");
        for (var t = 0; t < data.length; t++) {
            for (var n = 1; n < document.getElementById('dpdedition').options.length; n++) {
                if (data[t] == document.getElementById('dpdedition').options[n].value.split('~')[0]) {
                    document.getElementById('dpdedition').options[n].selected = true;
                }

            }
        }
    }
    document.getElementById('txtnoissuecode').value = global_ds.Tables[0].Rows[0].No_Iss_Code;
    updateStatus();

    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnExit').disabled = false;
    setButtonImages();
    return false;
}


function preissue() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    //	NoIssueMaster.fnpl(compcode,userid)//,precall)
    //		return false;
    //}

    //function precall(response)
    //{
    z--;
    //	global_ds=response.value;
    var x = global_ds.Tables[0].Rows.length;
    updateStatus();
    if (z > x) {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnlast').disabled = true;
        setButtonImages();
        return false;
    }


    if (z != -1 && z >= 0) {
        if (global_ds.Tables[0].Rows.length != z) {
            //document.getElementById('dpdedition').value=global_ds.Tables[0].Rows[z].Edition_Code;
            //				        for(var i1=0;i1<document.getElementById('dpdedition').options.length;i1++)
            //		                  {
            //		                    if(document.getElementById('dpdedition').options[i1].value.split('~')[0]==global_ds.Tables[0].Rows[z].Edition_Code)
            //		                    {
            //		                        document.getElementById('dpdedition').options[i1].selected=true;
            //		                    }
            //		                    else
            //		                    {
            //		                    document.getElementById('dpdedition').options[i1].selected=false;
            //		                    }
            //		                  }

            var companylist = global_ds.Tables[0].Rows[z].EDITIONALIAS;
            for (var t = 0; t < document.getElementById('dpdedition').options.length; t++) {
                document.getElementById('dpdedition').options[t].selected = false;
            }
            if (companylist != "" && companylist != null) {
                var data = companylist.split(",");
                for (var t = 0; t < data.length; t++) {
                    for (var n = 1; n < document.getElementById('dpdedition').options.length; n++) {
                        if (data[t] == document.getElementById('dpdedition').options[n].value.split('~')[0]) {
                            document.getElementById('dpdedition').options[n].selected = true;
                        }

                    }
                }
            }
            document.getElementById('txtnoissuecode').value = global_ds.Tables[0].Rows[z].No_Iss_Code;
            updateStatus();
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnlast').disabled = false;

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

function nextissue() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    //	NoIssueMaster.fnpl(compcode,userid)//,nextcall)
    //		return false;
    //}

    //function nextcall(response)
    //{
    z++;
    //	global_ds=response.value;
    var x = global_ds.Tables[0].Rows.length;
    if (z <= x && z >= 0) {
        if (global_ds.Tables[0].Rows.length != z && z != -1) {
            //		          for(var i1=0;i1<document.getElementById('dpdedition').options.length;i1++)
            //		          {
            //		            if(document.getElementById('dpdedition').options[i1].value.split('~')[0]==global_ds.Tables[0].Rows[z].Edition_Code)
            //		            {
            //		                document.getElementById('dpdedition').options[i1].selected=true;
            //		            }
            //		            else
            //		            {
            //		            document.getElementById('dpdedition').options[i1].selected=false;
            //		            }
            //		          }
            var companylist = global_ds.Tables[0].Rows[z].EDITIONALIAS;
            for (var t = 0; t < document.getElementById('dpdedition').options.length; t++) {
                document.getElementById('dpdedition').options[t].selected = false;
            }
            if (companylist != "" && companylist != null) {
                var data = companylist.split(",");
                for (var t = 0; t < data.length; t++) {
                    for (var n = 1; n < document.getElementById('dpdedition').options.length; n++) {
                        if (data[t] == document.getElementById('dpdedition').options[n].value.split('~')[0]) {
                            document.getElementById('dpdedition').options[n].selected = true;
                        }

                    }
                }
            }
            // document.getElementById('dpdedition').value=global_ds.Tables[0].Rows[z].Edition_Code;
            document.getElementById('txtnoissuecode').value = global_ds.Tables[0].Rows[z].No_Iss_Code;
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
    return false
}
function lastissue() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    //	NoIssueMaster.fnpl(compcode,userid)//,lastcall)
    //		return false;
    //}

    //function lastcall(response)
    //{
    //		global_ds= response.value;
    var x = global_ds.Tables[0].Rows.length;
    z = x - 1;
    x = x - 1;

    //document.getElementById('dpdedition').value=global_ds.Tables[0].Rows[x].Edition_Code;
    //			for(var i1=0;i1<document.getElementById('dpdedition').options.length;i1++)
    //              {
    //                if(document.getElementById('dpdedition').options[i1].value.split('~')[0]==global_ds.Tables[0].Rows[x].Edition_Code)
    //                {
    //                    document.getElementById('dpdedition').options[i1].selected=true;
    //                }
    //                else
    //                {
    //                document.getElementById('dpdedition').options[i1].selected=false;
    //                }
    //              }
    var companylist = global_ds.Tables[0].Rows[x].EDITIONALIAS;
    for (var t = 0; t < document.getElementById('dpdedition').options.length; t++) {
        document.getElementById('dpdedition').options[t].selected = false;
    }
    if (companylist != "" && companylist != null) {
        var data = companylist.split(",");
        for (var t = 0; t < data.length; t++) {
            for (var n = 1; n < document.getElementById('dpdedition').options.length; n++) {
                if (data[t] == document.getElementById('dpdedition').options[n].value.split('~')[0]) {
                    document.getElementById('dpdedition').options[n].selected = true;
                }

            }
        }
    }
    document.getElementById('txtnoissuecode').value = global_ds.Tables[0].Rows[x].No_Iss_Code;

    updateStatus();
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnprevious').disabled = false;
    setButtonImages();
    return false;
}



var issuecode123 = "";

function popupnoissue() {
    if (document.getElementById('dpdedition').selectedIndex == "0" && hiddentext == "new" && document.getElementById('Noissuelink').disabled == false) {
        alert("Please Select Edition");
        if (document.getElementById('dpdedition').disabled == false)
            document.getElementById('dpdedition').focus();
        return false;
    }
    // for userdefine() mode ;
    if (hiddentext == "new") {
        // checkcode();

        var res = NoIssueMaster.chkpubcatcode(document.getElementById('txtnoissuecode').value, document.getElementById('dpdedition').value.split('~')[0]); //,fillcall12);
        var ds = res.value;

        if (ds.Tables[1].Rows.length == 0) {



            document.getElementById('hdnissuecode').value = "";
        }
        else {

            //    document.getElementById('hdnissuecode').value = ds.Tables[1].Rows[0].No_Iss_Code;
        }
        var newstr;
        if (ds == null) {
            return false;
        }
        if (ds.Tables[0].Rows.length != 0 || ds.Tables[2].Rows.length != 0)//&& ds1.Tables[1].Rows.length!=0)
        {
            alert("This No Issue Code code has already been assigned !! ");
            document.getElementById('txtnoissuecode').value = "";
            //document.getElementById('txtalias').value="";
            if (document.getElementById('txtnoissuecode').disabled == false)
                document.getElementById('txtnoissuecode').focus();
            return false;
        }
        //		 else if(ds.Tables[1].Rows.length!=0 )//&& ds1.Tables[1].Rows.length!=0)
        //	    {
        //		    alert("This Edition has already been assigned !! ");
        //		     document.getElementById('dpdedition').value="0";
        //		     //document.getElementById('txtalias').value="";
        //		     if(document.getElementById('dpdedition').disabled==false)
        //		        document.getElementById('dpdedition').focus();
        //		      return false;
        //		 }

        //return false;

    }
    var issuecode = document.getElementById('txtnoissuecode').value;

    var edition123 = document.getElementById('dpdedition').value.split('~')[0];
    var edition_aliasdate = document.getElementById('dpdedition').value.split('~')[1];
    //  var issuecode123 = ds.Tables[1].Rows[1].No_Iss_Code;

    if (hiddentext == "modify" || hiddentext == "query") {


        var res = NoIssueMaster.chkpubcatcode(document.getElementById('txtnoissuecode').value, document.getElementById('dpdedition').value.split('~')[0]); //,fillcall12);
        var ds = res.value;
        // document.getElementById('hdnissuecode').value = ds.Tables[1].Rows[0].No_Iss_Code;



    }




    //	if(edition=="0")
    //	{
    //	  alert("Please Enter Edition");
    //	  return false;
    //	}
    //	var date=document.getElementById(')
    var ab;
    if (document.getElementById('Noissuelink').disabled == false) {
        //                if(issuecode!=null && issuecode!="")
        //                {
        for (var index = 0; index < 200; index++) {
            //popwin1=window.open('noissuedate.aspx?issuecode1="+issuecode+"&show="+show,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=500px');

            //popwin1=window.open('noissuedate.aspx');

            popwin1 = window.open("noissuedate.aspx?show=" + show + "&issuecode=" + issuecode + "&edition=" + edition123 + "&edition_aliasdate=" + edition_aliasdate, 'Ankur', "resizable=0,toolbar=0,top=140,left=30,scrollbars=yes,width=800px,height=535px");

            //popUpWin = window.open("pcmcontdetails.aspx?centcode="+centercode+"&show="+show,'a1', "status=0,toolbar=0,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px");       

            //  popwin1.focus();
            return false;
        }

        //            return false;
        //            }

        //popup=window.open('noissuedate.aspx?issuecode='+issuecode+' &show='+show,'Ankur','resizable=1,toolbar=0,top=244,left=210,scrollbars=yes,width=780px,height=415px');
        //window.open("SchemeDetails.aspx?SchemeCode="+SchemeCode,"schemedetails","status=0,toolbar=0,resizable=1,scrollbars=yes,width=550px height=600px");

        //		    else
        //		    {
        //		    alert("Please Enter No issue code ");
        //		    return false;
        //		    }
    }

    return false;

}


function nosubmit() {
    // document.getElementById('txtdate').value==

    opener.document.getElementById('hidden1').value = document.getElementById('drpissday').value;
    opener.document.getElementById('hidden2').value = document.getElementById('txtdate').value;
    opener.document.getElementById('hiddencompcode').value = document.getElementById('hiddencompcode').value;
    opener.document.getElementById('hiddenuserid').value = document.getElementById('hiddenuserid').value;
    document.getElementById('hi').value = document.getElementById('drpissday').value;
    document.getElementById('hi1').value = document.getElementById('txtdate').value;

    var nocode = document.getElementById('drpissday').value;
    var abc = document.getElementById('txtdate').value;

    if (document.getElementById('drpissday').value == "0") {
        alert("Please Select No Issue Day");
        document.getElementById('drpissday').focus();
        return false;
    }
    else {
        var noissueday = document.getElementById('drpissday').value;
    }




    var issuecode = document.getElementById('hiddenissuecode').value;
    var edition = document.getElementById('hdnedition').value;
    //alert("1")
   // alert(edition)
    var edition_alias = document.getElementById('hiddeneditionalias').value;
    var res = noissuedate.chkdate123(document.getElementById('txtdate').value, document.getElementById('drpissday').value, edition, edition_alias, document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value)
    var ds = res.value;


    if (ds.Tables[0].Rows[0].COUNT11 > 0) {

        alert("This date is alreay exist");
        document.getElementById('txtdate').value = "";
        document.getElementById('txtdate').focus();
        return false;

    }

    //================add dateformat condition====================//
    var date;
    var dateformat = document.getElementById('hiddendateformat').value;
    if (dateformat == "dd/mm/yyyy") {
        var txt = document.getElementById('txtdate').value;
        var txt1 = txt.split("/");
        var dd = txt1[0];
        var mm = txt1[1];
        var yy = txt1[2];
        date = mm + '/' + dd + '/' + yy;
    }
    else if (dateformat == "mm/dd/yyyy") {
        date = document.getElementById('txtdate').value;
    }

    else if (dateformat == "yyyy/mm/dd") {
        var txt = document.getElementById('txtdate').value;
        var txt1 = txt.split("/");
        var yy = txt1[0];
        var mm = txt1[1];
        var dd = txt1[2];
        date = mm + '/' + dd + '/' + yy;
    }
    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        alert("dateformat  is either null or undefined");
        date = document.getElementById('txtdate').value;
    }
    //=========================================================//
    var currdate = new Date();
    var ftdate = new Date(date);
    if (ftdate <= currdate) {

        alert("Date Should Be Greater Than Today's Date");
        document.getElementById('txtdate').value = "";
        document.getElementById('txtdate').focus();
        return false;
    }
    check = "save";

    var id;
    if (browser != "Microsoft Internet Explorer") {
        var httpRequest = null;
        httpRequest = new XMLHttpRequest();
        if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml');
        }

        httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

        httpRequest.open("GET", "checknoissue.aspx?page=" + check + "&nocode=" + nocode + "&date1=" + date + "&issuecode=" + issuecode + "&dateformat=" + dateformat + "&hiddencode=" + code, false);
        httpRequest.send('');
        //alert(httpRequest.readyState);
        if (httpRequest.readyState == 4) {
            //alert(httpRequest.status);
            if (httpRequest.status == 200) {
                id = httpRequest.responseText;
            }
            else {
                alert('There was a problem with the request.');
            }
        }
    }
    else {
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        xml.Open("GET", "checknoissue.aspx?page=" + check + "&nocode=" + nocode + "&date1=" + date + "&issuecode=" + issuecode + "&dateformat=" + dateformat + "&hiddencode=" + code, false);
        xml.Send();
        var dl = xml.responseText;

    }

    if (dl == "Y") {
        alert("This Day Has Already Been Assigned");
        document.getElementById('drpissday').value = "0";
        document.getElementById('drpissday').focus();
        return false;
    }


    //var date=      document.getElementById('txtdate').value;

    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var code = document.getElementById('hiddencode').value;
    if (trim(document.getElementById('txtdate').value) == "") {
        alert("Please Enter No Issue Date");
        document.getElementById('txtdate').focus();
        return false;
    }
    else {
        var date;
        if (dateformat == "dd/mm/yyyy") {
            var txt = document.getElementById('txtdate').value;
            var txt1 = txt.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            date = mm + '/' + dd + '/' + yy;
        }
        else if (dateformat == "mm/dd/yyyy") {
            date = document.getElementById('txtdate').value;
        }

        else if (dateformat == "yyyy/mm/dd") {
            var txt = document.getElementById('txtdate').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            date = mm + '/' + dd + '/' + yy;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            alert("dateformat  is either null or undefined");
            date = document.getElementById('txtdate').value;
        }
    }
    //====================================== check date in modify case =====================================//   

    if (document.getElementById("hiddenshow").value == "2") {
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

            httpRequest.open("GET", "checknoissue.aspx?page=" + check + "&nocode=" + nocode + "&date1=" + date + "&issuecode=" + issuecode + "&dateformat=" + dateformat + "&hiddencode=" + code, false);
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) {
                    id = httpRequest.responseText;
                }
                else {
                    alert('There was a problem with the request.');
                }
            }
        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "checknoissue.aspx?page=" + check + "&nocode=" + nocode + "&date1=" + date + "&issuecode=" + issuecode + "&dateformat=" + dateformat + "&hiddencode=" + code, false);
            xml.Send();
            var dl = xml.responseText;
        }

        if (dl == "Y") {
            alert("This Day Has Already Been Assigned");
            document.getElementById('drpissday').value = "0";
            document.getElementById('drpissday').focus();
            return false;
        }
        else {
            //  		        if(modify!="1")
            //                {

            if (opener.document.getElementById('hiddenchk').value == "1") {
                if (flag == "1") {
                    var ds1 = noissuedate.chkissue(date, noissueday, issuecode, compcode, code) //,insert_call_back);
                    if (ds1.value == null) {
                        alert(ds1.error.description);
                        return false;
                    }
                    if (ds1.value.Tables[0].Rows.length > 0) {
                        alert("This Date has already been assigned");
                        return false;
                    }
                    noissuedate.modify(date, noissueday, issuecode, compcode, userid, code)
                    window.location = window.location;
                    return false;
                }
                else {
                    var ds1 = noissuedate.chkissue(date, noissueday, issuecode, compcode, code) //,insert_call_back);

                    if (ds1.value == null) {
                        return false;
                    }
                    // var ds1=response.value;
                    if (ds1.value.Tables[0].Rows.length > 0) {
                        alert("This Date has already been assigned");
                        return false;
                    }
                    //                                else   if (ds1.value.Tables[1].Rows.length>0)
                    //                                {
                    //                                    alert("This Date has already been assigned");
                    //                                    return false;
                    //                                }
                    else {
                        //   alert("rinki");
                        var issuecode = document.getElementById('hiddenissuecode').value;
                        //		var catcode=trim(document.getElementById('hiddencatcode').value); 
                        var compcode1 = document.getElementById('hiddencompcode').value;
                        var userid1 = document.getElementById('hiddenuserid').value;
                        var dateformat = document.getElementById('hiddendateformat').value;
                        var nocode = document.getElementById('drpissday').value;
                        var abc = document.getElementById('txtdate').value;
                        var date;
                        if (dateformat == "dd/mm/yyyy") {
                            var txt = document.getElementById('txtdate').value;
                            var txt1 = txt.split("/");
                            var dd = txt1[0];
                            var mm = txt1[1];
                            var yy = txt1[2];
                            date = mm + '/' + dd + '/' + yy;
                        }
                        else if (dateformat == "mm/dd/yyyy") {
                            date = document.getElementById('txtdate').value;
                        }

                        else if (dateformat == "yyyy/mm/dd") {
                            var txt = document.getElementById('txtdate').value;
                            var txt1 = txt.split("/");
                            var yy = txt1[0];
                            var mm = txt1[1];
                            var dd = txt1[2];
                            date = mm + '/' + dd + '/' + yy;
                        }
                        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                            alert("dateformat  is either null or undefined");
                            date = document.getElementById('txtdate').value;
                        }
                        var currdate = new Date();
                        var ftdate = new Date(date);
                        if (ftdate <= currdate) {
                            alert("Date Should Be Greater Then Today's Date");
                            document.getElementById('txtdate').value = "";
                            document.getElementById('txtdate').focus();
                            return false;
                        }

                        if (document.getElementById('drpissday').value == "0") {
                            alert("Please Select No Issue Day");
                            document.getElementById('drpissday').focus();
                            return false;
                        }
                        else {
                            var noissueday = document.getElementById('drpissday').value;
                        }
                        var issuecode = document.getElementById('hiddenissuecode').value;
                        var compcode = document.getElementById('hiddencompcode').value;
                        var userid = document.getElementById('hiddenuserid').value;
                        var dateformat = document.getElementById('hiddendateformat').value;
                        var code = document.getElementById('hiddencode').value;
                        if (document.getElementById('txtdate').value == "") {
                            alert("Please Enter No Issue Date");
                            document.getElementById('txtdate').focus();
                            return false;
                        }
                        else {
                            var date;
                            if (dateformat == "dd/mm/yyyy") {
                                var txt = document.getElementById('txtdate').value;
                                var txt1 = txt.split("/");
                                var dd = txt1[0];
                                var mm = txt1[1];
                                var yy = txt1[2];
                                date = mm + '/' + dd + '/' + yy;
                            }
                            else if (dateformat == "mm/dd/yyyy") {
                                date = document.getElementById('txtdate').value;
                            }

                            else if (dateformat == "yyyy/mm/dd") {
                                var txt = document.getElementById('txtdate').value;
                                var txt1 = txt.split("/");
                                var yy = txt1[0];
                                var mm = txt1[1];
                                var dd = txt1[2];
                                date = mm + '/' + dd + '/' + yy;
                            }
                            if (dateformat == null || dateformat == "" || dateformat == "undefined") {
                                alert("dateformat  is either null or undefined");
                                date = document.getElementById('txtdate').value;
                            }
                        }
                        //  alert("rinki");
                        var iscode = issuecode;
                       
                        var res1 = noissuedate.addeditionsupp(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, edition);
                        //var res=NoIssueMaster.addeditionsupp(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,edition);
                        var dsn_ew = res1.value;
                        if (dsn_ew.Tables[0].Rows.length > 0) {
                            for (var i = 0; i < dsn_ew.Tables[0].Rows.length; i++) {
                                issuecode = dsn_ew.Tables[0].Rows[i].Edition_Code;
                                noissuedate.submit(abc, noissueday, issuecode, compcode, userid, dateformat, edition_alias)
                            }
                        }
                        noissuedate.submit(abc, noissueday, iscode, compcode, userid, dateformat, edition_alias)
                        window.location = window.location;
                        return false;

                    }
                    //  return false;
                }

            }
            else {
                return;
            }


            // }
        }
    }
    else {
        // noissuedate.modify(date,noissueday,issuecode, compcode,userid,code )
        //        noissuedate.chkissue(date,noissueday,issuecode, compcode,insert_call);
        //        window.location=window.location;
        return;
    }

}

/*function insert_call_back(response)
{

var ds1=response.value;
if (ds1.Tables[0].Rows.length>0)
{
alert("This Date has already been assigned");
return false;

}

else
{
var issuecode=document.getElementById('hiddenissuecode').value;
//		var catcode=trim(document.getElementById('hiddencatcode').value); 
var compcode1=document.getElementById('hiddencompcode').value; 
var userid1=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value;
var nocode=document.getElementById('drpissday').value;
var abc=document.getElementById('txtdate').value;
var date;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
date=mm+'/'+dd+'/'+yy;
}
else if(dateformat=="mm/dd/yyyy")
{
date=document.getElementById('txtdate').value;
}
		
else if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
date=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
alert("dateformat  is either null or undefined");
date=document.getElementById('txtdate').value;
}
var currdate=new Date();
var ftdate=new Date(date);
if(ftdate<=currdate)

{
alert("Date Should Be Greater Then Today's Date");
document.getElementById('txtdate').value="";
document.getElementById('txtdate').focus();
return false;
}

if(document.getElementById('drpissday').value=="0")
{
alert("Please Select No Issue Day");
document.getElementById('drpissday').focus();
return false;
}
else
{
var noissueday=document.getElementById('drpissday').value;
}
var issuecode=document.getElementById('hiddenissuecode').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;
var code=document.getElementById('hiddencode').value;
if(document.getElementById('txtdate').value=="")
{
alert("Please Enter No Issue Date");
document.getElementById('txtdate').focus();
return false;
}
else
{
var date;
if(dateformat=="dd/mm/yyyy")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
date=mm+'/'+dd+'/'+yy;
}
else if(dateformat=="mm/dd/yyyy")
{
date=document.getElementById('txtdate').value;
}
        		
else if(dateformat=="yyyy/mm/dd")
{
var txt=document.getElementById('txtdate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
date=mm+'/'+dd+'/'+yy;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
alert("dateformat  is either null or undefined");
date=document.getElementById('txtdate').value;
}
}	
//	pcmcontdetails.insertcontact(contactperson1,txtdob1,txtphoneno1,desi,txtext1,txtfaxno1,mail1,centcode1,compcode1,userid1);

noissuedate.submit(date,noissueday,issuecode, compcode,userid )
        
//alert("Data Saved");
//alert(xmlObj.childNodes(0).childNodes(0).text);

window.location=window.location;


return false ;

}

}*/






////		if(code=="")
////		{
////		noissuedate.submit(date,noissueday,issuecode, compcode,userid )
////		window.location=window.location;
////		return false;
////		}
////		else
////		{
////		noissuedate.modify(date,noissueday,issuecode, compcode,userid,code )
////		window.location=window.location;
////		return false;
////		}


//if (opener.document.getElementById('hiddenchk').value=="1")
//{

//        noissuedate.submit(date,noissueday,issuecode, compcode,userid )
//		window.location=window.location;
//		return false;



//}
//else
//{

////document.getElementById('drpissday').value=drpissday.value;
////document.getElementById('txtdate').value=txtdate.text;
//document.getElementById('hiddenday').value= nocode;   
//document.getElementById('hiddendate').value=abc;
//return;




//}







////if(document.getElementById('htext').value=="mod ")
////	
////	 {
////	 popupedit.chkinsert(txteditionname,txtdate,txtaddate,compcode,userid,editcode,call_insert);
////	 
////   	 window.location=window.location;
////   	  return false;

////	// return ;
////	 }
////      
////      else
////              
////	{
////	opener.document.getElementById('hiddeneditalias').value=txteditionname;
////	opener.document.getElementById('hiddeneditdate').value=txtdate;
////    opener.document.getElementById('hiddeneditaddate').value=txtaddate;
//////  opener.document.getElementById('hiddeneditalias').value="";
//////	opener.document.getElementById('hiddeneditdate').value="";	
//////	opener.document.getElementById('hiddeneditaddate').value="";

////return;
////	}


//////popupedit.insert(txteditionname,txtdate,txtaddate,compcode,userid,editcode);

////}


////}
////else
////{
////popupedit.chkupdate(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10,call_update);
//////popupedit.update(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10);
////document.getElementById('btndelete').disabled=true;
////edinsert="0";

////}



////return false;




//		
//		return false;
//}




//function chkselect(ab)
//{
////alert("entered");
//var id=ab;
////if(document.getElementById(id).checked==false)
////{
//////document.getElementById('txteditionname').value="";
////document.getElementById('txtdate').value="";
////document.getElementById('txtaddate').value="";
////document.getElementById('btndelete').disabled=true;

////document.getElementById(id).checked=false;

////return;
////}
//		var issuecode= document.getElementById('hiddenissuecode').value;
//		var compcode=  document.getElementById('hiddencompcode').value;
//		var userid=	   document.getElementById('hiddenuserid').value;
//		var j;
//		var k=0;
//		//var DataGrid1__ctl_CheckBox1= new Array();
//		var i=document.getElementById("DataGrid1").rows.length -1;

//        
//		for(j=0;j<i;j++)
//		{
//				var str="DataGrid1_ctl_CheckBox1"+j;
//				//document.getElementById(str).checked=false;
//				document.getElementById(str).checked=true;
//                document.getElementById(id).checked=true;
//                
//    if(document.getElementById('hiddendelsau').value=="1")
//	{
//   document.getElementById('btndelete').disabled= false;
//    }
//    if(id==str)
//    {
//				if(document.getElementById(str).checked==true)
//				{
//							k=k+1;
//							//code10=document.getElementById(str).value;
//							code10=document.getElementById(str).value;
//							if(document.getElementById('hiddendelsau').value=="1")
//	                        {
//                            	document.getElementById('btndelete').disabled= false;
//                            }
//	
//				}
//		}
//		}
//		if(k==1)
//		{       
//	            	if((document.getElementById('hiddenshow').value=="1"))
//                	{
//                    	document.getElementById('btndelete').disabled=false;
//                	}    
//		            document.getElementById(str).checked=true;
//				//	document.getElementById('btndelete').disabled=false;
//					noissuedate.select(issuecode, compcode,userid,code10,callselect);
//					return false;
//		}
//		else
//		{
//				alert("You Can Select One Row At A Time");
//				
//				return false;
//		}

//return false;
//}



//function callselect(res)
//{
//	var ds= res.value;
//	var dateformat=document.getElementById('hiddendateformat').value;
//	var date=ds.Tables[0].Rows[0].no_issue_date;
//	document.getElementById('drpissday').value=ds.Tables[0].Rows[0].No_Iss_day;
//	
//	//	var enrolldate=ds.Tables[0].Rows[0].dob;
//						var dd=date.getDate();
//						var mm=date.getMonth() + 1;
//						var yyyy=date.getFullYear();
//						//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//						
//						if(dateformat=="yyyy/mm/dd")
//							{
//							var date=yyyy+'/'+mm+'/'+dd;
//							} 
//							else if (dateformat=="mm/dd/yyyy")
//									{
//									var date=mm+'/'+dd+'/'+yyyy;
//									}
//							else if (dateformat=="dd/mm/yyyy")
//										{
//										var date=dd+'/'+mm+'/'+yyyy;
//										}
//							else
//										{
//										var date=mm+'/'+dd+'/'+yyyy;
//										}
//						
//						
//				
//	
//	
//	document.getElementById('txtdate').value=date;
//	
//	document.getElementById('hiddencode').value=code10;;
//return false;
//}

function chkselect(ab) {
    var id = ab;

    //saurabh code------------------------------------------------------------------------

    if (document.getElementById(id).checked == false) {
        flag = "0";
        document.getElementById('drpissday').value = "0";
        document.getElementById('txtdate').value = "";

        if (opener.document.getElementById('hiddensubmit').value == "1") {
            document.getElementById('btnsubmit').disabled = false;
        }
        else {
            document.getElementById('btnsubmit').disabled = true;
        }

        document.getElementById('btndelete').disabled = true;
        document.getElementById(ab).checked = false;
        return; // false;

    }


    //--------------------------------------------------------------------------------------



    var issuecode = document.getElementById('hiddenissuecode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;

    var j;
    var k = 0;

    //var DataGrid1__ctl_CheckBox1= new Array();
    var i = document.getElementById("DataGrid1").rows.length - 1;

    for (j = 0; j < i; j++) {
        //var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
        var str = "DataGrid1_ctl_CheckBox1" + j;
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
        noissuedate.select(issuecode, compcode, userid, code10, callselect);

        // not return false;otherwise the chech box will be disabled...
        //	pcmcontdetails.pcmcontsel(centcode,compcode,userid,code10,call_selectpcm);

    }
    else if (k == 0) {
        //    chk123.checked=false;
        document.getElementById('drpissday').value = "0";
        document.getElementById('txtdate').value = "";


        return false;
    }
    document.getElementById(ab).checked = true;

    //saurabh code
    //	if(document.getElementById(ab).checked==true)
    //	{
    //	    document.getElementById(ab).checked=true;
    //	}
    //	else
    //	{
    //	    document.getElementById(ab).checked=false;
    //	}

    //saurabh=str;

    if (document.getElementById('hiddenshow').value == "2") {
        if (document.getElementById('btnsubmit').disabled == false) {
            flag = "1";
        }
        else {
            flag = "0";
        }
    }
    else {
        flag = "0";
    }
    //return false;
}

//function callselect(res)
//{
//	var ds= res.value;
//	var dateformat=document.getElementById('hiddendateformat').value;
//	var date=ds.Tables[0].Rows[0].no_issue_date;
//	document.getElementById('drpissday').value=ds.Tables[0].Rows[0].No_Iss_day;
//	
//	//	var enrolldate=ds.Tables[0].Rows[0].dob;
//						var dd=date.getDate();
//						var mm=date.getMonth() + 1;
//						var yyyy=date.getFullYear();
//						//var enrolldate1=mm+'/'+dd+'/'+yyyy;
//						
//						if(dateformat=="yyyy/mm/dd")
//							{
//							var date=yyyy+'/'+mm+'/'+dd;
//							} 
//							else if (dateformat=="mm/dd/yyyy")
//									{
//									var date=mm+'/'+dd+'/'+yyyy;
//									}
//							else if (dateformat=="dd/mm/yyyy")
//										{
//										var date=dd+'/'+mm+'/'+yyyy;
//										}
//							else
//										{
//										var date=mm+'/'+dd+'/'+yyyy;
//										}
//						
//						
//				
//	
//	
//	document.getElementById('txtdate').value=date;
//	
//	document.getElementById('hiddencode').value=code10;;
//return false;
//}

function callselect(response) {

    var ds = response.value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    document.getElementById('hiddencode').value = ds.Tables[0].Rows[0].datecode;

    var dateformat = document.getElementById('hiddendateformat').value;

    if (ds.Tables[0].Rows[0].no_issue_date != null && ds.Tables[0].Rows[0].no_issue_date != "") {
        var enrolldate = new Date(ds.Tables[0].Rows[0].no_issue_date);
        var dd = enrolldate.getDate();
        if (dd.toString().length == 1)
            dd = "0" + dd;
        var mm = enrolldate.getMonth() + 1;
        if (mm.toString().length == 1)
            mm = "0" + mm;
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
        document.getElementById('txtdate').value = "";
    }

    document.getElementById('drpissday').value = ds.Tables[0].Rows[0].No_Iss_day;

    if (ds.Tables[0].Rows[0].no_issue_date != null && ds.Tables[0].Rows[0].no_issue_date != "") {
        document.getElementById('txtdate').value = enrolldate1;
    }
    else {
        document.getElementById('txtdate').value = "";
    }
    document.getElementById('hiddencode').value = ds.Tables[0].Rows[0].datecode;

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




function nodelete() {
    var issuecode = document.getElementById('hiddenissuecode').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var datecode = document.getElementById('hiddencode').value;
    if (document.getElementById('DataGrid1').rows.length - 1 == 1) {
        alert("There should be one no issue day here")
        return false;
    }
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
    noissuedate.delete1(issuecode, compcode, userid, datecode); //,code10)

    document.getElementById('txtdate').value = "";
    document.getElementById('drpissday').value = "";
    document.getElementById('hiddencode').value = "";

    window.location = window.location;

    return false;
}

function uppercase1() {
    document.getElementById('txtnoissuecode').value = document.getElementById('txtnoissuecode').value.toUpperCase();
    return;
}




//*********************************************Auto Generate***********************

//*********************************************Auto Generate***********************



function autoornot()
// {
// if(hiddentext=="new")
{
    //            if(document.getElementById('hiddenauto').value==1)
    //            {
    changeoccured();
    //            return false;
    //            }
    //            else
    //            {
    //            userdefine();

    //            return false;
    //            //    }
    //            }
    return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured() {
    //if(hiddentext=="new" )

    //        if(document.getElementById('hiddenauto').value==1)
    //        {

    uppercase3();

    //        }
    //        else
    //        {
    //        // document.getElementById('txtzonename').value=document.getElementById('txtzonename').value.toUpperCase();

    //        document.getElementById('dpdedition').value=document.getElementById('dpdedition').value.toUpperCase();
    //        }
    return false;
}


//auto generated
//this is used for increment in code



function uppercase3() {
    document.getElementById('dpdedition').value.split('~')[0] = trim(document.getElementById('dpdedition').value.split('~')[0]);
    lstr = document.getElementById('dpdedition').value.split('~')[0];
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

    if (document.getElementById('dpdedition').value != "0") {

        document.getElementById('dpdedition').value = document.getElementById('dpdedition').value.toUpperCase();
        // document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
        // str=document.getElementById('txtzonename').value;
        str = mstr;
        NoIssueMaster.issuecode_auto(str, fillcall);
        //return false;
    }


    //return false;

}

function fillcall(res) {
    var ds = res.value;

    var newstr;

    if (ds.Tables[0].Rows.length != 0) {
        if (hiddentext == "new") {

            alert("This Edition has been already assigned.");

            document.getElementById('txtnoissuecode').value = "";
            document.getElementById('dpdedition').value = "0";
            //document.getElementById('txtzonealias').value="";

            //document.getElementById('txtzonename').focus();

            return false;
        }
        if (hiddentext == "modify") {

            alert("This Edition has been already assigned.");

            //document.getElementById('txtnoissuecode').value="";
            document.getElementById('dpdedition').value = "0";
            //document.getElementById('txtzonealias').value="";

            //document.getElementById('txtzonename').focus();

            return false;
        }

    }

    else {

        if (hiddentext == "new") {
            if (ds.Tables[1].Rows.length == 0) {
                newstr = null;
            }
            else {
                newstr = ds.Tables[1].Rows[0].No_Iss_Code;
            }
            if (newstr != null) {
                document.getElementById('dpdedition').value = trim(document.getElementById('dpdedition').value);
                // var code=newstr.substr(2,4);
                var code = newstr;
                code++;
                document.getElementById('txtnoissuecode').value = str.substr(0, 2) + code;
            }
            else {
                document.getElementById('txtnoissuecode').value = str.substr(0, 2) + "0";
            }
        }
    }
    //  return false;
    //		      alert("This Edition has already assigned !! ");
    //		    
    //		         document.getElementById('txtnoissuecode').value="";
    //				document.getElementById('dpdedition').value="0";
    //	
}

function userdefine() {
    if (hiddentext == "new") {

        document.getElementById('txtnoissuecode').disabled = false;
        document.getElementById('dpdedition').value = document.getElementById('dpdedition').value.toUpperCase();
        // document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
        auto = document.getElementById('hiddenauto').value;
        NoIssueMaster.issuecode_auto(document.getElementById('txtnoissuecode').value, fillcall1);
        return false;
    }

    return false;
}

function fillcall1(res) {
    var ds = res.value;
    if (ds.Tables.length > 0) {
        if (ds.Tables[2].Rows.length != 0) {
            alert("This Code has been already assigned.");
            document.getElementById('txtnoissuecode').value = "";
            document.getElementById('dpdedition').value = "0";
            return false;
        }
    }
}



function LTrim(value) {

    var re = /\s*((\S+\s*)*)/;
    return value.replace(re, "$1");

}

// Removes ending whitespaces
function RTrim(value) {

    var re = /((\s*\S+)*)\s*/;
    return value.replace(re, "$1");

}

// Removes leading and ending whitespaces
function trim(value) {

    return LTrim(RTrim(value));

}
function check() {
    document.getElementById('txtnoissuecode').value = trim(document.getElementById('txtnoissuecode').value);



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

function noclear() {

    flag = "0";
    //alert(saurabh);
    document.getElementById('drpissday').value = "0";
    document.getElementById('txtdate').value = "";



    //var DataGrid1__ctl_CheckBox1= new Array();

    if (((document.getElementById('btndelete').disabled == true) && (document.getElementById('btnsubmit').disabled == true)) || ((document.getElementById('btndelete').disabled == false) && (document.getElementById('btnsubmit').disabled == false))) {

        var j;
        var k = 0;

        var i = document.getElementById("DataGrid1").rows.length - 1;

        for (j = 0; j < i; j++) {
            //var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
            var str = "DataGrid1_ctl_CheckBox1" + j;
            document.getElementById(str).checked = false;
            document.getElementById('btndelete').disabled = true;
            document.getElementById('btnsubmit').disabled = true;
        }
    }
    //document.getElementById('saurabh').checked=false;

    //if(document.getElementById('drpissday').disabled==false)
    //{
    //    document.getElementById('drpissday').disabled= false;
    //}
    //if(document.getElementById('txtdate').disabled==false)
    //{
    //    document.getElementById('txtdate').disabled= false;
    //}    

    return false;
}

function hello() {
    alert("hello");

}

function closewindow() {
    window.close();
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


//*******************************************************************************//

/*
function checkcode()
{
//document.getElementById('txtnoissuecode').value
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
NoIssueMaster.chkpubcatcode(document.getElementById('txtnoissuecode').value,document.getElementById('dpdedition').value,fillcall12);
}
function fillcall12(res)
{
var ds=res.value;
var newstr;
if(ds==null)
{ 
return false;
}
if(ds.Tables[0].Rows.length!=0 )//&& ds1.Tables[1].Rows.length!=0)
{
alert("This No Issue Code code has already been assigned !! ");
document.getElementById('txtnoissuecode').value="";
//document.getElementById('txtalias').value="";
if(document.getElementById('txtnoissuecode').disabled==false)
document.getElementById('txtnoissuecode').focus();
return false;
}
return false;
}*/




function grid(dateformat) {
    document.getElementById('view').disabled = true;
    var compcode = document.getElementById('hiddencompcode').value;

    var edition = document.getElementById('dpdedition').value.split('~')[0];
    if (document.getElementById('dpdedition').value.split('~')[1] == "undefined" || document.getElementById('dpdedition').value.split('~')[1] == undefined) {
        var editionALIAS = "";
    }
    else {
        var editionALIAS = document.getElementById('dpdedition').value.split('~')[1];
    }

    var res = NoIssueMaster.grid(compcode, edition, editionALIAS)


    calbackgrid(res, dateformat);
    return false;
}


function calbackgrid(res, dateformat1) {


    document.getElementById('table1').style.display = 'block';

    var ds = res.value;
    var vi = "";

    vi += "<table width='100%'><tr><td width='100px' align='left'  style='font-family:Verdana;font-size:11px;background-color:#7DAAE3;color: #ffffff;'>EDITION NAME</td><td width='100px' align='left'  style='font-family:Verdana;font-size:11px;background-color:#7DAAE3;color: #ffffff;'>ISSUE DAY</td><td align='right' width='100px' style='font-family:Verdana;font-size:11px;background-color:#7DAAE3;color: #ffffff;'> ISSUE DATE</td></tr>"

    for (var i = 0; i < ds.Tables[0].Rows.length; i++) {

        vi += "<tr><td class='gridview' align='left' >" + ds.Tables[0].Rows[i].EDITION + "</td><td class='gridview' align='left' >" + ds.Tables[0].Rows[i].No_Iss_day + "</td><td class='gridview' align='right' >" + CHKDATE(ds.Tables[0].Rows[i].no_issue_date, dateformat1) + "</td></tr>"


    }


    vi += "</table>"








    document.getElementById('grid1123').innerHTML = vi;


    document.getElementById('grid1123').style.display = 'block';
    return false;
}




var chkdtforupdt = "";
var dateconvert;
function CHKDATE(userdate, dateformat1) {


    var mycondate = ""
    if (userdate == null || userdate == "") {
        mycondate = ""
        userdate = "";
        return mycondate
    }
    else {



        var dateformate = dateformat1
        if (dateformat1 == "dd/mm/yyyy") {
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
        else if (dateformat1 == "mm/dd/yyyy") {
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
        else if (dateformat1 == "yyyy/mm/dd") {
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







function clear() {

    document.getElementById('table1').style.display = 'none';
    return false;
}