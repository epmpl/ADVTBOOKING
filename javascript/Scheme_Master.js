// JScript File

var global_ds;

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

var scheme_id;
//*********************************************************************************************************

//*******************************************************************************************************

function savescheme() {
    //debugger;
    var bc = "";
    document.getElementById('txtschemename').value = trim(document.getElementById('txtschemename').value);
    document.getElementById('txtschemecode').value = trim(document.getElementById('txtschemecode').value);
    if (document.getElementById('hiddenauto').value != 1) {
        document.getElementById('txtschemecode').value = trim(document.getElementById('txtschemecode').value);
        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lblschemecode').textContent;
        }
        else {
            bc = document.getElementById('lblschemecode').innerText;
        }
        if (bc.indexOf('*') >= 0) {
            if (document.getElementById('txtschemecode').value == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtschemecode').focus();
                return false;
            }
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lblschemename').textContent;
    }
    else {
        bc = document.getElementById('lblschemename').innerText;
    }

    if (bc.indexOf('*') >= 0) {
        if (document.getElementById('txtschemename').value == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtschemename').focus();
            return false;
        }
    }

    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lblschemecode').textContent;
    }
    else {
        bc = document.getElementById('lblschemecode').innerText;
    }
    if (bc.indexOf('*') >= 0) {
        if (document.getElementById('txtschemecode').value == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtschemecode').focus();
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lblfrominsert').textContent;
    }
    else {
        bc = document.getElementById('lblfrominsert').innerText;
    }

    if (bc.indexOf('*') >= 0) {
        if (document.getElementById('txtfrominsert').value == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtfrominsert').focus();
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbltoinsert').textContent;
    }
    else {
        bc = document.getElementById('lbltoinsert').innerText;
    }

    if (bc.indexOf('*') >= 0) {
        if (document.getElementById('txttoinsert').value == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txttoinsert').focus();
            return false;
        }
    }

    if (parseInt(document.getElementById('txtfrominsert').value) > parseInt(document.getElementById('txttoinsert').value)) {
        alert('To Insertion No. should be greater than From Insertion No. ');
        document.getElementById('txttoinsert').value = "";
        document.getElementById('txttoinsert').focus();
    }
    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lblvalidfrom').textContent;
    }
    else {
        bc = document.getElementById('lblvalidfrom').innerText;
    }

    if (bc.indexOf('*') >= 0) {
        if (document.getElementById('txtvalidfrom').value == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtvalidfrom').focus();
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lblvalidto').textContent;
    }
    else {
        bc = document.getElementById('lblvalidto').innerText;
    }

    if (bc.indexOf('*') >= 0) {
        if (document.getElementById('txtvalidto').value == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtvalidto').focus();
            return false;
        }
    }
    if (browser != "Microsoft Internet Explorer") {
        bc = document.getElementById('lbldiscount').textContent;
    }
    else {
        bc = document.getElementById('lbldiscount').innerText;
    }

    if (bc.indexOf('*') >= 0) {
        if (document.getElementById('drpdiscount').value == "0") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('drpdiscount').focus();
            return false;
        }
        if (document.getElementById('txtdiscount').value == "") {
            alert('Please Enter ' + (bc.replace('*', "")));
            document.getElementById('txtdiscount').focus();
            return false;
        }
    }


    var dis = parseFloat(document.getElementById('txtdiscount').value);
    document.getElementById('txtdiscount').value = dis;



    //if(dis==0)
    //{
    //    alert("Discount can not be zero");
    //    document.getElementById('txtdiscount').value="";
    //    document.getElementById('txtdiscount').focus();
    //    return false;
    //}
    if (dis == NaN) {
        document.getElementById('txtdiscount').value = "";
        document.getElementById('txtdiscount').focus();
        return false;
    }
    else if (dis == "NaN") {
        document.getElementById('txtdiscount').value = "";
        document.getElementById('txtdiscount').focus();
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

    var schemecode = trim(document.getElementById('txtschemecode').value);

    var scheme_name = trim(document.getElementById('txtschemename').value);

    var frominsert = document.getElementById('txtfrominsert').value;
    var toinsert = document.getElementById('txttoinsert').value;
    var validfrom = document.getElementById('txtvalidfrom').value;
    var validto = document.getElementById('txtvalidto').value;
    var discount = document.getElementById('txtdiscount').value;
    var contidate = "";
    if (document.getElementById('chkcontidate').checked == true) {
        contidate = "1";
    }
    else {
        contidate = "0";
    }
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var dateformat = document.getElementById('hiddendateformat').value;


    if (dateformat == "dd/mm/yyyy") {
        var txtfrom = document.getElementById('txtvalidfrom').value;
        var txtto = document.getElementById('txtvalidto').value;

        var txt1 = txtfrom.split("/");
        var dd = txt1[0];
        var mm = txt1[1];
        var yy = txt1[2];
        fromdate = mm + '/' + dd + '/' + yy;
        var txtto1 = txtto.split("/");
        var dd1 = txtto1[0];
        var mm1 = txtto1[1];
        var yy1 = txtto1[2];
        todate = mm1 + '/' + dd1 + '/' + yy1;

    }
    else if (dateformat == "mm/dd/yyyy") {
        fromdate = document.getElementById('txtvalidfrom').value;
        todate = document.getElementById('txtvalidto').value;
    }

    else if (dateformat == "yyyy/mm/dd") {
        var txt = document.getElementById('txtvalidfrom').value;
        var txt1 = txt.split("/");
        var yy = txt1[0];
        var mm = txt1[1];
        var dd = txt1[2];
        fromdate = mm + '/' + dd + '/' + yy;
        var txtto = document.getElementById('txtvalidto').value;
        var txtto1 = txtto.split("/");
        var yy1 = txtto1[0];
        var mm1 = txtto1[1];
        var dd1 = txtto1[2];
        todate = mm1 + '/' + dd1 + '/' + yy1;
    }
    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        alert("dateformat  is either null or undefined");
        fromdate = document.getElementById('txtvalidfrom').value;
        todate = document.getElementById('txtvalidto').value;
    }

    if (todate != "" || todate != null || todate != "undefined") {
        tdate = new Date(todate);
        fdate = new Date(fromdate);
        if (tdate < fdate) {
            alert("To Date should be greater than From Date");
            document.getElementById('txtvalidto').value = "";
            document.getElementById('txtvalidto').focus();
            return false;
        }

    }

    var sc = scheme_name.substring(0, 2);

    scheme_id = schemecode + frominsert + toinsert;

    if (document.getElementById('hiddenmod').value == "1") {
        //debugger;
        Scheme_Master.savechk(scheme_id, schemecode, frominsert, toinsert, fromdate, todate, discount, compcode, userid, scheme_name, sc, contidate, callsave, "")

        return false;
    }

    else if (document.getElementById('hiddenmod').value == "2") {

        return;

    }

    //  Code transferred to design file by saurabh Agarwal--------------



    //        Scheme_Master.modifychk(scheme_id,schemecode,frominsert,toinsert,validfrom,validto,discount,compcode,userid,callmodify)
    //        return false;


    //                scheme_id=schemecode+frominsert+toinsert;
    //        flag="1";
    //        
    //        Scheme_Master.update(scheme_id,schemecode,frominsert,toinsert,validfrom,validto,discount,compcode,userid, flag);

    //					document.getElementById('txtschemecode').disabled=true;
    //					document.getElementById('txtfrominsert').disabled=true;
    //					document.getElementById('txttoinsert').disabled=true;
    //					document.getElementById('txtvalidfrom').disabled=true;
    //					document.getElementById('txtvalidto').disabled=true;
    //					document.getElementById('txtdiscount').disabled=true;
    //					
    //		flag=0;
    ////updateStatus();
    //        var x=global_ds.Tables[0].Rows.length;
    //	y=z;	
    //if (z==0)
    //{
    //document.getElementById('btnfirst').disabled=true;
    //document.getElementById('btnprevious').disabled=true;
    //}

    //if(z==(global_ds.Tables[0].Rows.length-1))
    //{
    //    document.getElementById('btnNext').disabled=true;
    //	document.getElementById('btnLast').disabled=true;
    //}
    //        document.getElementById('btnModify').focus();
    ////		alert(xmlObj.childNodes(0).childNodes(1).text);
    ////alert(xmlObj.childNodes(0).childNodes(1).text);  
    //alert('Data Updated Successfully');
    //		return false;
    //		}

    //------------------------Saurabh code transferred over--------------------------


    return false;
}



function callmodify(rr) {
    var ds = rr.value;

    //    if(ds.Tables[0].Rows.length!=1)
    //    {
    //    alert('This Scheme Code Already Exists.');
    //    document.getElementById('txtschemecode').disabled=false;
    //    document.getElementById('txtschemecode').value="";
    //    document.getElementById('txtschemecode').focus();
    //    }
    //    else
    //    {

    var schemecode = trim(document.getElementById('txtschemecode').value);

    var scheme_name = trim(document.getElementById('txtschemename').value);

    var frominsert = document.getElementById('txtfrominsert').value;
    var toinsert = document.getElementById('txttoinsert').value;
    var validfrom = document.getElementById('txtvalidfrom').value;
    var validto = document.getElementById('txtvalidto').value;
    var discount = document.getElementById('txtdiscount').value;
    var discount_type = document.getElementById('drpdiscount').value;

    if (document.getElementById('chkcontidate').checked == true) {
        contidate = "1";
    }
    else {
        contidate = "0";
    }

    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var dateformat = document.getElementById('hiddendateformat').value;
    //var adcat=document.getElementById('drpadcat').value;		


    if (dateformat == "dd/mm/yyyy") {
        var txtfrom = document.getElementById('txtvalidfrom').value;
        var txtto = document.getElementById('txtvalidto').value;

        var txt1 = txtfrom.split("/");
        var dd = txt1[0];
        var mm = txt1[1];
        var yy = txt1[2];
        fromdate = mm + '/' + dd + '/' + yy;
        var txtto1 = txtto.split("/");
        var dd1 = txtto1[0];
        var mm1 = txtto1[1];
        var yy1 = txtto1[2];
        todate = mm1 + '/' + dd1 + '/' + yy1;

    }
    else if (dateformat == "mm/dd/yyyy") {
        fromdate = document.getElementById('txtvalidfrom').value;
        todate = document.getElementById('txtvalidto').value;
    }

    else if (dateformat == "yyyy/mm/dd") {
        var txt = document.getElementById('txtvalidfrom').value;
        var txt1 = txt.split("/");
        var yy = txt1[0];
        var mm = txt1[1];
        var dd = txt1[2];
        fromdate = mm + '/' + dd + '/' + yy;
        var txtto = document.getElementById('txtvalidto').value;
        var txtto1 = txtto.split("/");
        var yy1 = txtto1[0];
        var mm1 = txtto1[1];
        var dd1 = txtto1[2];
        todate = mm1 + '/' + dd1 + '/' + yy1;
    }
    if (dateformat == null || dateformat == "" || dateformat == "undefined") {
        alert("dateformat  is either null or undefined");
        fromdate = document.getElementById('txtvalidfrom').value;
        todate = document.getElementById('txtvalidto').value;
    }

    if (todate != "" || todate != null || todate != "undefined") {
        tdate = new Date(todate);
        fdate = new Date(fromdate);
        if (tdate < fdate) {
            alert("To Date should be greater than From Date");
            return false;
        }

    }

    scheme_id = schemecode + frominsert + toinsert;
    flag = "1";

    //        	var xml = new ActiveXObject("Microsoft.XMLHTTP");
    //		xml.Open( "GET","schememodifychk.aspx?scheme_id="+scheme_id+"&schemecode="+schemecode+"scheme_name="+scheme_name, false );
    //		xml.Send();
    //		var id=xml.responseText;

    //if(id=="Y")
    //{
    //alert("This Scheme Name already exists");
    //return false;
    //}







    Scheme_Master.update(schemecode, frominsert, toinsert, validfrom, validto, discount_type, discount, compcode, userid, flag, scheme_name, contidate)

    document.getElementById('txtschemecode').disabled = true;
    document.getElementById('txtschemename').disabled = true;
    document.getElementById('txtfrominsert').disabled = true;
    document.getElementById('txttoinsert').disabled = true;
    document.getElementById('txtvalidfrom').disabled = true;
    document.getElementById('txtvalidto').disabled = true;
    document.getElementById('txtdiscount').disabled = true;

    flag = 0;
    updateStatus();
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
    document.getElementById('btnModify').focus();
    //		alert(xmlObj.childNodes(0).childNodes(1).text);
    //alert(xmlObj.childNodes(0).childNodes(1).text);  
    alert('Data Updated Successfully');
    return false;
    //		}
    //		return false;
}


function callsave(res) {
    //debugger;
    ds = res.value;
    //	if(ds.Tables[0].Rows.length!=0)
    //		{
    //		    alert("This Scheme Name has already been assigned");
    //		    document.getElementById('txtschemename').focus();
    //		    

    //		    return false;
    //		}
    if (res.error != null) {
        alert(res.error);
        return false;
    }
    if (ds.Tables[0].Rows.length > 0) {
        //  if(ds.Tables[1].Rows.length>0)
        //  {
        alert("This Scheme Name is Already Assign with this Scheme Code");
        return false;
        //}
    }
        //else if(ds.Tables[1].Rows.length>0)
        //{
        // if(ds.Tables[0].Rows.length>0)
        //{
        //  alert("This Scheme Name Already Exist");
        //  return false;
        //  }
        //}
    else {
        var fromdate, todate;
        //	if(document.getElementById('drpedition').value == "0")
        //	{
        //	alert("Please select Edition Name From List")
        //	document.getElementById('drpedition').focus();
        //	return false;
        //	}



        if (document.getElementById('hiddenauto').value != 1) {
            if (browser != "Microsoft Internet Explorer") {
                bc = document.getElementById('lblschemecode').textContent;
            }
            else {
                bc = document.getElementById('lblschemecode').innerText;
            }

            if (bc.indexOf('*') >= 0) {
                if (document.getElementById('txtschemecode').value == "") {
                    alert('Please Enter ' + (bc.replace('*', "")));
                    document.getElementById('txtschemecode').focus();
                    return false;
                }
            }
        }
        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lblfrominsert').textContent;
        }
        else {
            bc = document.getElementById('lblfrominsert').innerText;
        }

        if (bc.indexOf('*') >= 0) {
            if (document.getElementById('txtfrominsert').value == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtfrominsert').focus();
                return false;
            }
        }


        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbltoinsert').textContent;
        }
        else {
            bc = document.getElementById('lbltoinsert').innerText;
        }

        if (bc.indexOf('*') >= 0) {
            if (document.getElementById('txttoinsert').value == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txttoinsert').focus();
                return false;
            }
        }


        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lblvalidfrom').textContent;
        }
        else {
            bc = document.getElementById('lblvalidfrom').innerText;
        }

        if (bc.indexOf('*') >= 0) {
            if (document.getElementById('txtvalidfrom').value == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtvalidfrom').focus();
                return false;
            }
        }


        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lblvalidto').textContent;
        }
        else {
            bc = document.getElementById('lblvalidto').innerText;
        }

        if (bc.indexOf('*') >= 0) {
            if (document.getElementById('txtvalidto').value == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtvalidto').focus();
                return false;
            }
        }


        if (browser != "Microsoft Internet Explorer") {
            bc = document.getElementById('lbldiscount').textContent;
        }
        else {
            bc = document.getElementById('lbldiscount').innerText;
        }

        if (bc.indexOf('*') >= 0) {
            if (document.getElementById('txtdiscount').value == "") {
                alert('Please Enter ' + (bc.replace('*', "")));
                document.getElementById('txtdiscount').focus();
                return false;
            }
        }


        var dis = parseFloat(document.getElementById('txtdiscount').value);
        document.getElementById('txtdiscount').value = dis;



        //if(dis==0)
        //{
        //    alert("Discount can not be zero");
        //    document.getElementById('txtdiscount').value="";
        //    document.getElementById('txtdiscount').focus();
        //    return false;
        //}
        if (dis == NaN) {
            document.getElementById('txtdiscount').value = "";
            document.getElementById('txtdiscount').focus();
            return false;
        }
        else if (dis == "NaN") {
            document.getElementById('txtdiscount').value = "";
            document.getElementById('txtdiscount').focus();
            return false;
        }

        var schemecode = trim(document.getElementById('txtschemecode').value);
        var scheme_name = trim(document.getElementById('txtschemename').value);

        var frominsert = document.getElementById('txtfrominsert').value;
        var toinsert = document.getElementById('txttoinsert').value;
        var validfrom = document.getElementById('txtvalidfrom').value;
        var validto = document.getElementById('txtvalidto').value;
        var discount_type = document.getElementById('drpdiscount').value;
        var discount = document.getElementById('txtdiscount').value;
        var contidate = "";
        if (document.getElementById('chkcontidate').checked == true) {
            contidate = "1";
        }
        else {
            contidate = "0";
        }

        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        var dateformat = document.getElementById('hiddendateformat').value;


        if (dateformat == "dd/mm/yyyy") {
            var txtfrom = document.getElementById('txtvalidfrom').value;
            var txtto = document.getElementById('txtvalidto').value;

            var txt1 = txtfrom.split("/");
            var dd = txt1[0];
            var mm = txt1[1];
            var yy = txt1[2];
            fromdate = mm + '/' + dd + '/' + yy;
            var txtto1 = txtto.split("/");
            var dd1 = txtto1[0];
            var mm1 = txtto1[1];
            var yy1 = txtto1[2];
            todate = mm1 + '/' + dd1 + '/' + yy1;

        }
        else if (dateformat == "mm/dd/yyyy") {
            fromdate = document.getElementById('txtvalidfrom').value;
            todate = document.getElementById('txtvalidto').value;
        }

        else if (dateformat == "yyyy/mm/dd") {
            var txt = document.getElementById('txtvalidfrom').value;
            var txt1 = txt.split("/");
            var yy = txt1[0];
            var mm = txt1[1];
            var dd = txt1[2];
            fromdate = mm + '/' + dd + '/' + yy;
            var txtto = document.getElementById('txtvalidto').value;
            var txtto1 = txtto.split("/");
            var yy1 = txtto1[0];
            var mm1 = txtto1[1];
            var dd1 = txtto1[2];
            todate = mm1 + '/' + dd1 + '/' + yy1;
        }
        if (dateformat == null || dateformat == "" || dateformat == "undefined") {
            alert("dateformat  is either null or undefined");
            fromdate = document.getElementById('txtvalidfrom').value;
            todate = document.getElementById('txtvalidto').value;
        }

        if (todate != "" || todate != null || todate != "undefined") {
            tdate = new Date(todate);
            fdate = new Date(fromdate);
            if (tdate < fdate) {
                alert("To Date should be greater than From Date");
                return false;
            }

        }


        //		if(document.getElementById('hiddenauto').value==1)
        //        {
        //            
        //        
        //		
        //		var sc1=scheme_name.substring(0,2);
        //		
        //		var sau=ds.Tables[0].Rows[0].scheme_number;
        //		sau=sau+1;
        //		
        //		if(document.getElementById('hiddenauto').value==1)
        //		{
        //		
        //		    if(ds.Tables[0].Rows[0].scheme_number=='null'||ds.Tables[0].Rows[0].scheme_number==null||ds.Tables[0].Rows[0].scheme_number=='undefined'||ds.Tables[0].Rows[0].scheme_number==undefined)
        //            {
        //                document.getElementById('txtschemecode').value=sc1+'0';
        //            }
        //            else
        //            {
        //               document.getElementById('txtschemecode').value=sc1+sau;
        //            }		
        //		}
        //		
        //		}
        var schemecode = trim(document.getElementById('txtschemecode').value);
        // var adcat=document.getElementById('drpadcat').value;

        //var adcat1=document.getElementById('drpadcat');
        //adcat1.options.length = 0; 
        //adcat1.options[0]=new Option("------Select Ad Category------","0");



        //        var xml = new ActiveXObject("Microsoft.XMLHTTP");
        //		xml.Open( "GET","schememodifychk.aspx?scheme_id="+scheme_id+"&schemecode="+schemecode+"scheme_name="+scheme_name, false );
        //		xml.Send();
        //		var id=xml.responseText;

        //if(id=="Y")
        //{
        //alert("This Scheme Name already exists");
        //return false;
        //}










        scheme_id = schemecode + frominsert + toinsert;

        flag = "0";

        //Scheme_Master.savesch(scheme_id,schemecode,frominsert,toinsert,fromdate,todate,discount_type,discount,compcode,userid, flag)
        //debugger;
        var sun, mon, tue, wed, thu, fri, sat
        if (document.getElementById('CheckBox1').checked == true) {
            sun = "Y"
        }
        else {
            sun = "N"
        }
        if (document.getElementById('CheckBox2').checked == true) {
            mon = "Y"
        }
        else {
            mon = "N"
        }

        if (document.getElementById('CheckBox3').checked == true) {
            tue = "Y"
        }
        else {
            tue = "N"
        }
        if (document.getElementById('CheckBox4').checked == true) {
            wed = "Y"
        }
        else {
            wed = "N"
        }
        if (document.getElementById('CheckBox5').checked == true) {
            thu = "Y"
        }
        else {
            thu = "N"
        }
        if (document.getElementById('CheckBox6').checked == true) {
            fri = "Y"
        }
        else {
            fri = "N"
        }

        if (document.getElementById('CheckBox8').checked == true) {
            sat = "Y"
        }
        else {
            sat = "N"
        }





        Scheme_Master.saveschme(scheme_id, schemecode, frominsert, toinsert, fromdate, todate, discount_type, discount, compcode, userid, flag, scheme_name, sun, mon, tue, wed, thu, fri, sat, contidate);

        //debugger;
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

        var schemecode = document.getElementById('txtschemecode').value;

        var scheme_name = document.getElementById('txtschemename').value;

        var frominsert = document.getElementById('txtfrominsert').value;
        var toinsert = document.getElementById('txttoinsert').value;
        var validfrom = document.getElementById('txtvalidfrom').value;
        var validto = document.getElementById('txtvalidto').value;
        var discount = document.getElementById('txtdiscount').value;
        var discount_type = document.getElementById('drpdiscount').value;

        var contidate = "";
        if (document.getElementById('chkcontidate').checked == true) {
            contidate = "1";
        }
        else {
            contidate = "0";
        }

        document.getElementById('txtschemecode').value = "";

        document.getElementById('txtschemename').value = "";

        document.getElementById('txtfrominsert').value = "";
        document.getElementById('txttoinsert').value = "";
        document.getElementById('txtvalidfrom').value = "";
        document.getElementById('txtvalidto').value = "";
        document.getElementById('txtdiscount').value = "";
        document.getElementById('drpdiscount').value = "0";

        document.getElementById('txtschemecode').disabled = true;

        document.getElementById('txtschemename').disabled = true;

        document.getElementById('txtfrominsert').disabled = true;
        document.getElementById('txttoinsert').disabled = true;
        document.getElementById('txtvalidfrom').disabled = true;
        document.getElementById('txtvalidto').disabled = true;
        document.getElementById('txtdiscount').disabled = true;
        document.getElementById('drpdiscount').disabled = true;


        document.getElementById('chkcontidate').checked = false;
        document.getElementById('CheckBox1').checked = false
        document.getElementById('CheckBox2').checked = false
        document.getElementById('CheckBox3').checked = false
        document.getElementById('CheckBox4').checked = false
        document.getElementById('CheckBox5').checked = false
        document.getElementById('CheckBox6').checked = false
        document.getElementById('CheckBox6').checked = false






        //alert(xmlObj.childNodes(0).childNodes(0).text);  

        alert('Data Saved Successfully With Scheme Code ' + schemecode);
        setButtonImages();
        return false;
    }
    //else

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




    var keycode = event.keyCode ? event.keyCode : event.which;


    if (keycode == 13) {







        if (document.activeElement.id == "txtschemecode") {
            if (document.getElementById("txtschemecode").value == "") {
                alert("please enter Scheme Code")
                document.getElementById("txtschemecode").focus();
                return false;
            }
            else {
                document.getElementById("txtschemename").focus();
                return false;
            }
        }
        else if (document.activeElement.id == "txtschemename") {
            if (document.getElementById("txtschemename").value == "") {
                alert("please enter Scheme Name1")
                document.getElementById("txtschemename").focus();
                return false;
            }
            else {

                document.getElementById("txtfrominsert").focus();
                return false;


            }
        }

        else if (document.activeElement.id == "txtfrominsert") {
            if (document.getElementById("txtfrominsert").value == "") {
                alert("please select From Insretion No")
                document.getElementById("txtfrominsert").focus();
                return false;
            }
            else {

                document.getElementById("txttoinsert").focus();
                return false;


            }
        }


        else if (document.activeElement.id == "txttoinsert") {
            if (document.getElementById("txttoinsert").value == "") {
                alert("please Select to Insertion No")
                document.getElementById("txttoinsert").focus();
                return false;
            }
            else {

                document.getElementById("txtvalidfrom").focus();
                return false;


            }
        }


        else if (document.activeElement.id == "txtvalidfrom") {
            if (document.getElementById("txtvalidfrom").value == "") {
                alert("please select From Date")
                document.getElementById("txtvalidfrom").focus();
                return false;
            }
            else {

                document.getElementById("txtvalidto").focus();
                return false;


            }
        }


        else if (document.activeElement.id == "txtvalidto") {
            if (document.getElementById("txtvalidto").value == "") {
                alert("please Select To Date")
                document.getElementById("txtvalidto").focus();
                return false;
            }
            else {

                document.getElementById("drpdiscount").focus();
                return false;


            }
        }

        else if (document.activeElement.id == "drpdiscount") {
            if (document.getElementById("drpdiscount").value == "") {
                alert("please Select Discount")
                document.getElementById("drpdiscount").focus();
                return false;
            }
            else {

                document.getElementById("txtdiscount").focus();
                return false;


            }
        }



        else if (document.activeElement.id == "txtdiscount") {
            if (document.getElementById("txtdiscount").value == "") {
                alert("please Select discount")
                document.getElementById("txtdiscount").focus();
                return false;
            }
            else {

                document.getElementById("btnSave").focus();
                return false;


            }
        }













    }

}


//function checkdiscount()
//{
//var num=document.getElementById('txtdiscount').value;
//var num2=parseFloat(document.getElementById('txtdiscount').value);
//document.getElementById('txtdiscount').value=num2;

//var tomatch=/^\d*(\.\d{1,2})?$/;
//if (tomatch.test(num2))
//{
//return true;
//}
//else
//{
//document.getElementById('txtdiscount').value="";
//alert("Input error");
//document.getElementById('txtdiscount').focus();
//document.getElementById('txtdiscount').value="";
//return false; 
//}
//}



function checkdiscount() {

    if (document.getElementById('drpdiscount').value != "fixed") {
        var sau = parseFloat(document.getElementById('txtdiscount').value);
        document.getElementById('txtdiscount').value = sau;

        if (sau > 100) {
            alert("Discount should not be greater than 100");
            document.getElementById('txtdiscount').value = "";
            document.getElementById('txtdiscount').focus();
            return false;
        }

        var num = document.getElementById('txtdiscount').value;
        //var tomatch=/^\d*(\.\d{1,2})?$/;
        //if (tomatch.test(num))
        //{
        //return true;
        //}
        //else
        //{
        //document.getElementById('txtdiscount').value="";
        //alert("Input error");
        //document.getElementById('txtdiscount').value="";
        //document.getElementById('txtdiscount').focus();

        //return false; 

        //}
    }

    else {
        var num2 = document.getElementById('txtdiscount').value;
        var num = parseFloat(document.getElementById('txtdiscount').value);
        document.getElementById('txtdiscount').value = num;


        //var tomatch=/^\d*(\.\d{1,2})?$/;
        //if (tomatch.test(num2))
        //{
        //return true;
        //}
        //else
        //{
        //document.getElementById('txtdiscount').value="";
        //alert("Input error");
        //document.getElementById('txtdiscount').focus();
        //document.getElementById('txtdiscount').value="";
        //return false; 
        //}


    }

}




function closescheme() {
    if (confirm("Do you want to skip this page")) {
        window.close();

    }

    return false;
}

function checkinsertionno() {
    if (parseInt(document.getElementById('txtfrominsert').value) > parseInt(document.getElementById('txttoinsert').value)) {
        alert('To Insertion No. should be greater than From Insertion No. ');
        document.getElementById('txttoinsert').value = "";
        document.getElementById('txttoinsert').focus();
        return false;
    }
    num = document.getElementById('txttoinsert').value;
    var tomatch = /^\d*(\.\d{1,2})?$/;
    if (tomatch.test(num)) {
        return true;
    }
    else {
        document.getElementById('txttoinsert').value = "";
        alert("Input error");
        document.getElementById('txttoinsert').value = "";
        document.getElementById('txttoinsert').focus();

        return false;

    }
}

function checkinsertionno1() {
    //    if(parseInt(document.getElementById('txtfrominsert').value)>parseInt(document.getElementById('txttoinsert').value) )
    //    {
    //        alert('To Insertion No. should be greater than From Insertion No. ');
    //        document.getElementById('txttoinsert').value="";
    //        document.getElementById('txttoinsert').focus();
    //        return false;
    //    }
    num = document.getElementById('txtfrominsert').value;
    var tomatch = /^\d*(\.\d{1,2})?$/;
    if (tomatch.test(num)) {
        return true;
    }
    else {
        document.getElementById('txtfrominsert').value = "";
        alert("Input error");
        document.getElementById('txtfrominsert').value = "";
        document.getElementById('txtfrominsert').focus();

        return false;

    }
}
//*********************************************************************************************************

function autoornot() {
    if (document.getElementById('hiddenauto').value == "1") {
        //changeoccured();
        // return false ;
    }
    else {
        userdefine();
        return false;
    }

}
//**************************************************************************************

function userdefine() {
    if (document.getElementById('hiddenauto').value != "1") {

        document.getElementById('txtschemecode').disabled = false;
        document.getElementById('txtschemename').value = document.getElementById('txtschemename').value.toUpperCase();
        if (document.getElementById('txtschemename').value != "") {
            var scheme_name = document.getElementById('txtschemename').value;
            var scheme_code = document.getElementById('txtschemecode').value;
            Scheme_Master.checkcode(scheme_name, fillcall);
            return false;
        }
        return false;
    }

    return false;

}
//****************************************************************************************
function changeoccured() {
    if (document.getElementById('txtschemename').value != "") {
        var scheme_name = document.getElementById('txtschemename').value;
        Scheme_Master.checkcode(scheme_name, fillcall);
        return false;
    }
    return false;

}

//*****************************************************************************************
function fillcall(res) {
    var ds = res.value;

    if (ds.Tables[0].Rows.length != 0) {
        alert("This Scheme Name has been already assigned.");
        document.getElementById("txtschemename").value = "";
        document.getElementById('txtschemename').focus();
        return false;
    }
    else {

        document.getElementById('txtfrominsert').focus()
    }
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
//**************************************************************************************************************
function refreshDisc() {
    document.getElementById('txtdiscount').value = "";
}


function dateenter(event) {
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 0)) {

            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 11)) {

            return true;
        }
        else {
            return false;
        }
    }
}


function clearscheme_master() {
    document.getElementById('txtschemecode').value = "";
    document.getElementById('txtfrominsert').value = "";
    document.getElementById('txttoinsert').value = "";
    document.getElementById('txtdiscount').value = "";
    document.getElementById('txtvalidfrom').value = "";
    document.getElementById('txtschemename').value = "";
    document.getElementById('txtvalidto').value = "";
    document.getElementById('drpdiscount').value = "0";
    //    document.getElementById('drpadcat').value = "0";
    document.getElementById('chkcontidate').checked = false;
    document.getElementById('CheckBox1').checked = false
    document.getElementById('CheckBox2').checked = false
    document.getElementById('CheckBox3').checked = false
    document.getElementById('CheckBox4').checked = false
    document.getElementById('CheckBox5').checked = false
    document.getElementById('CheckBox6').checked = false
    document.getElementById('CheckBox6').checked = false

    givebuttonpermission('Scheme_Master');
}



function enter2tab(event) {





}



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