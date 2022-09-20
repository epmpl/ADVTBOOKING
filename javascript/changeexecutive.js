
var browser = navigator.appName;


function clearall() {
    document.getElementById('txtfrmdate').value = "";
    document.getElementById('txttodate1').value = "";
    document.getElementById('txtagency1').value = "";
    document.getElementById('txtclient1').value = "";

    document.getElementById('txtciod').value = "";
    document.getElementById('divgrid1').style.display = "none"


}

function updateexecutive112(val, id, bookingid)
{
    var compcode = document.getElementById('hiddencompcode').value;
    var a = val.indexOf(val);
    var val1 = document.getElementById(id).value;   
    var executive = ""
    executive = val1.split('~(')[1].split(')')[0];
    //////////////////bhanu
    var flag = "1"
    var ressupplementb = changeexecutive.billupdatedata(document.getElementById('hiddencompcode').value, document.getElementById('txtciod').value,  document.getElementById('hiddenuserid').value, document.getElementById('hiddendateformat').value, "", "", "", "", "", "1");
    //var ressupplementb = changeexecutive.billupdatedata(document.getElementById('hiddencompcode').value, document.getElementById('txtciod').value, document.getElementById('hiddensupplementbilldate').value, document.getElementById('hiddensupplementbillno').value, document.getElementById('hiddenuserid').value, document.getElementById('hiddendateformat').value, "1");
    if (ressupplementb.value == null) {
        alert(ressupplementb.error.description);
    }
    if (ressupplementb != null && ressupplementb.value.Tables[0].Rows.length > 0) {
        for (var j = 0; j <= ressupplementb.value.Tables[0].Rows.length - 1; j++) {
            
            var ressupplement1 = changeexecutive.adbillsmodificationvalidate(document.getElementById('hiddencompcode').value, document.getElementById('hiddencentcode').value, document.getElementById('hiddenbranchcode').value, ressupplementb.value.Tables[0].Rows[j].BILL_NO, ressupplementb.value.Tables[0].Rows[j].BILL_DATE, document.getElementById('hiddendateformat').value, document.getElementById('hiddenuserid').value, "", "", "", "", "");
            //var ressupplement1 = changeexecutive.adbillsmodificationvalidate(document.getElementById('hiddencompcode').value, document.getElementById('txtciod').value, ressupplementb.value.Tables[0].Rows[j].BILL_NO, ressupplementb.value.Tables[0].Rows[j].BILL_DATE, document.getElementById('hiddenuserid').value, document.getElementById('hiddendateformat').value);
            if (ressupplement1.error != null) {
               alert(ressupplement1.error.description);
                return false;
            }
            if (ressupplement1.value.Tables[0].Rows[0].MESSAGE != null && ressupplement1.value.Tables[0].Rows[0].MESSAGE != "") {
                alert(ressupplement1.value.Tables[0].Rows[0].MESSAGE);
                flag="0";
                break;
                return false;
            }
        }
        if (flag== "1"){
            var res = changeexecutive.updateexe(compcode, bookingid, executive, clientname, clientadd, retainername);
            if (res.error == null) {
                alert("Executive Updated Successfully")
            }
        }


    }
    else {
        var res = changeexecutive.updateexe(compcode, bookingid, executive, clientname, clientadd, retainername);
        if (res.error == null) {
            alert("Executive Updated Successfully")
        }
    }
  
return false
}

function filllist(event, id)
{
    if (event.keyCode == 113) {
        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuserid').value;
        var res = changeexecutive.bindexecutive(compcode, userid); 
        bindexecutive(res, id)
    }
    return false;
}


function bindexecutive(res,id1) {
    var ds_AccName = res.value;
    document.getElementById("hdnglobalid").value = id1;
    

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstexecutive");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Executive Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Exec_name + "~" + "(" + ds_AccName.Tables[0].Rows[i].Exe_no+")", ds_AccName.Tables[0].Rows[i].Exe_no);
            pkgitem.options.length;
        }
    }

    var aTag = eval(document.getElementById(id1))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = 0; //document.getElementById('div2').scrollLeft;
    document.getElementById('div2').style.display = "block";
    var scrolltop =document.getElementById('divgrid1').scrollTop;
    document.getElementById('div2').style.left = document.getElementById(id1).offsetLeft + leftpos - tot + "px";
    document.getElementById('div2').style.top = document.getElementById(id1).offsetTop + toppos - scrolltop + "px"; //"510px";
    document.getElementById("lstexecutive").value = "0";
    document.getElementById("div2").value = "";
    document.getElementById('lstexecutive').disabled = false
    document.getElementById('div2').style.display = "block";
    document.getElementById('lstexecutive').focus();

    return false;

}

function clickexecutive(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstexecutive") {
            if (document.getElementById('lstexecutive').value == "0") {
                alert("Please select Executive Name");
                return false;
            }

            var page = document.getElementById('lstexecutive').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstexecutive').length - 1; k++) {
                if (document.getElementById('lstexecutive').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstexecutive').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstexecutive').options[k].innerText;
                    }
                    var nID = document.getElementById("hdnglobalid").value;
                    document.getElementById(nID).value = abc;
                    document.getElementById('hdnexecutive').value = abc;
                    document.getElementById('hdnexecutive').value = page;

                    document.getElementById("div2").style.display = "none";
                  //  document.getElementById('hdnglobalid').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

        document.getElementById("div2").style.display = "none";
       // document.getElementById('hdnglobalid').focus();
    }
}
		
function tabvalue1(event) {
  
    var browser = navigator.appName;
    if (event.keyCode == 113) {

        if (document.activeElement.id == "txtagency1") {
            if (document.getElementById('txtagency1').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtagency1').value = "";
                return false;
            }
            document.getElementById("div1").style.display = "block";
            document.getElementById("div1").style.display = "block";
            aTag = eval(document.getElementById("txtagency1"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('div1').style.top = document.getElementById("txtagency1").offsetTop + toppos + "px";
            document.getElementById('div1').style.left = document.getElementById("txtagency1").offsetLeft + leftpos + "px";            
            changeexecutive.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency1').value.toUpperCase(), bindagencyname_callback);

        }
        else if (document.activeElement.id == "txtclient1") {
            if (document.getElementById('txtclient1').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtclient1').value = "";
                return false;
            }
            document.getElementById("divclient").style.display = "block";
            aTag = eval(document.getElementById("txtclient1"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divclient').style.top = document.getElementById("txtclient1").offsetTop + toppos + "px";
            document.getElementById('divclient').style.left = document.getElementById("txtclient1").offsetLeft + leftpos + "px";            
            changeexecutive.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient1').value.toUpperCase(), bindclientname_callback);
        }

        else if (document.activeElement.id == "dpretainer")
         {
             if (document.getElementById('dpretainer').value.length <= 2)
             {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('dpretainer').value = "";
                return false;
            }
            document.getElementById("div3").style.display = "block";
            aTag = eval(document.getElementById("dpretainer"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('div3').style.top = document.getElementById("dpretainer").offsetTop + toppos + "px";
            document.getElementById('div3').style.left = document.getElementById("dpretainer").offsetLeft + leftpos + "px";
            Displayqutation.fillF2_Creditretainer(document.getElementById('hiddencompcode').value, document.getElementById('dpretainer').value.toUpperCase(), bindretainer_callback);
        }
       
        else if (document.activeElement.id == "txtexecname")
        {            
            if (document.getElementById('txtexecname').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtexecname').value = "";
                return false;
            }
            //                    document.getElementById('dpretainer').value='';
            document.getElementById("divexec").style.display = "block";
            aTag = eval(document.getElementById("txtexecname"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divexec').style.top = document.getElementById("txtexecname").offsetTop + toppos + "px";
            document.getElementById('divexec').style.left = document.getElementById("txtexecname").offsetLeft + leftpos + "px";          
            Displayqutation.bindExec(document.getElementById('hiddencompcode').value, document.getElementById('txtexecname').value.toUpperCase(), bindexecname_callback);
        }
        

    }

    else if (event.keyCode == 27) {
        if (document.getElementById("div1").style.display == "block") {
            document.getElementById("div1").style.display = "none"
            document.getElementById('txtagency1').focus();
        }
        else if (document.getElementById("divclient").style.display == "block") {
            document.getElementById("divclient").style.display = "none"
            document.getElementById('txtclient1').focus();
        }
//        else if (document.getElementById("divexec").style.display == "block") {
//            document.getElementById("divexec").style.display = "none"
//            document.getElementById('txtexecname').focus();
//        }
//        else if (document.getElementById("div3").style.display == "block") {
//        document.getElementById("div3").style.display = "none"
//        document.getElementById('dpretainer').focus();
//        }
        
    }
    else if (event.keyCode == 13 || event.keyCode == 9 && event.shiftKey == false) {
        
        if (document.activeElement.id == "lstclient") {
            if (document.getElementById('lstclient').value == "0") {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display = "none";
            var datetime = "";
            /*@@ this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
            address and if 0 than agency name and address @@@@@@@@@@@@@@@@@@@*/

            var page = document.getElementById('lstclient').value;
            var id = "";
            document.getElementById("Hiddenclientcode").value = page;
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }
                httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
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
                xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
                xml.Send();
                id = xml.responseText;
            }
            var split = id.split("+");
            var namecode = split[0];
            var add = split[1];
            var split = namecode.split("(");
            var abc= split[0];
            
            document.getElementById('txtclient1').value = abc;

            /* if(document.getElementById('hiddensavemod').value=="0")
            {
            document.getElementById('txtclient1add').value=add;
            document.getElementById('txtclient1add').focus();
            }
            bind_agen_bill();*/
            document.getElementById('txtclient1').focus();
            return false;
        }
        else if (document.activeElement.id == "lstagency") {
            if (document.getElementById('lstagency').value == "0") {
                alert("Please select the agency sub code");
                return false;
            }
            document.getElementById("div1").style.display = "none";
            var datetime = "";
            var page = document.getElementById('lstagency').value;
            //document.getElementById('hiddenagency').value=page;
            document.getElementById("Hiddenagencycode").value = page;
            agencycodeglo = page;

            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }

                httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=0", false);
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
                xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=0", false);
                xml.Send();
                id = xml.responseText;
            }
            var split = id.split("+");
            var nameagen = split[0];
            var agenadd = split[1];

            document.getElementById('txtagency1').value = nameagen;
            /* if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
            {
            document.getElementById('txtagency1address').value=agenadd;                
            document.getElementById('txtclient1').focus();
            Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
            }*/
            document.getElementById('txtagency1').focus();
            return false;
        }

        ///this is for exec name
        else if (document.activeElement.id == "lstexec") {
            if (document.getElementById('lstexec').value == "0") {
                alert("Please select the executive");
                return false;
            }

            document.getElementById("divexec").style.display = "none";
            var datetime = "";

            var page = document.getElementById('lstexec').value;
            document.getElementById("Hiddenexecutivecode").value = page;
            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }
                httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
                httpRequest.send('');
                if (httpRequest.readyState == 4) {
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
                xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
                xml.Send();
                id = xml.responseText;
            }

            document.getElementById('txtexecname').value = id;
            document.getElementById('txtexecname').focus();
           
            return false;
        }
           else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
            event.keyCode = 13;
            return event.keyCode;
        }
        else {
            var idcursor;
            if (event.shiftKey == false) {
                event.keyCode = 9;
                return event.keyCode;
            }
        }
    }
}

function bindagencyname_callback(res) {


    ds = res.value;
    document.getElementById("lstagency").innerHTML = "";
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency Name-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name + "+" + ds.Tables[0].Rows[i].Agency_code + "+" + ds.Tables[0].Rows[i].code_subcode, ds.Tables[0].Rows[i].Agency_code);
            pkgitem.options.length;
        }
    }

    document.getElementById("lstagency").focus();

    return false;


}

function bindclientname_callback(response)
{
    ds = response.value;
    var pkgitem = document.getElementById("lstclient");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Client-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0)
    {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name, ds.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;
        }
    }
  //document.getElementById('txtclient').value = "";
    document.getElementById("lstclient").value = "0";
    document.getElementById("lstclient").focus();

    return false;
}
function insertagency11(event) {
   

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
                    document.getElementById('txtagency1').value = abc.split('+')[0];

                    //document.getElementById('hdnagencytxt').value =page.split('+')[0];
                    document.getElementById('hdncode').value = abc.split('+')[1];
                    document.getElementById('hdncodesubcode').value = abc.split('+')[2];

                    document.getElementById("div1").style.display = "none";
                    document.getElementById('txtagency1').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

        document.getElementById("div1").style.display = "none";
        document.getElementById('txtagency1').focus();
    }
}

function insertagency() 
{   
var browser=navigator.appName;
if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0")// || document.getElementById('hiddensavemod').value=="01")
    {
        alert("Please select the agency code");
        return false;
    }
        document.getElementById("div1").style.display="none";
        var datetime="";
       
        var page=document.getElementById('lstagency').value;
              document.getElementById("Hiddenagencycode").value=page;
        //document.getElementById('hiddenagency').value=page;
        agencycodeglo=page;
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;
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
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
             xml.Send();
             id=xml.responseText;
        }
          if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd=split[1];
                
        document.getElementById('txtagency1').value=nameagen;
        
        /*if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
        {
              document.getElementById('txtagency1address').value=agenadd;
                
              document.getElementById('txtclient1').focus();
              Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
        }*/
        document.getElementById('txtagency1').focus();
        return false;
    }
 else if(document.activeElement.id=="lstclient")
    {
       if(document.getElementById('lstclient').value=="0")
        {
            alert("Please select the client");
            return false;
        }
        document.getElementById("divclient").style.display="none";
        var datetime="";
       
     
        var page=document.getElementById('lstclient').value;
        document.getElementById("Hiddenclientcode").value = page;
       // alert(page);
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;
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
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
             xml.Send();
             id=xml.responseText;
        }
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var namecode = split[0];

         document.getElementById('hdnclientcode').value = namecode.split("(")[1].split(")")[0]
         var add=split[1];        
        document.getElementById('txtclient1').value=namecode;     
        document.getElementById('txtclient1').focus();        
        return false;
    }
    ///this is for ret name                 

 else if (document.activeElement.id == "lstret")
 {
    if (document.getElementById('lstret').value == "0") 
    {
            alert("Please select the Retainer");
            return false;
        }
        document.getElementById("div3").style.display = "none";
        var datetime = "";
        var page = document.getElementById('lstret').value;
        document.getElementById("hiddenretainercode").value = page;
       
        var id = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

            httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
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
            xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
            xml.Send();
            id = xml.responseText;
        }
        if (id == "yes") {
            alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
            return false;
        }
        var split = id.split("+");
        var namecode = split[0];
        var add = split[1];


        document.getElementById('dpretainer').value = namecode;
        document.getElementById('dpretainer').focus();

        return false;
    }
 
 ///this is for exec name
    else if(document.activeElement.id=="lstexec")
    {
     if(document.getElementById('lstexec').value=="0")
        {
        alert("Please select the executive");
        return false;
        }
        document.getElementById("divexec").style.display="none";
           var datetime="";
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address and if 2 than its for product and 3 for exec
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
        var page=document.getElementById('lstexec').value;
        //agencycodeglo=page;
               document.getElementById("Hiddenexecutivecode").value=page;
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
            httpRequest.send('');
           
            if (httpRequest.readyState == 4) 
            {
               
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;
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
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
             xml.Send();
             id=xml.responseText;
        }
         
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
        document.getElementById('txtexecname').value=id;
        
        
       document.getElementById('txtexecname').focus();
      
        return false;
    }
}

function submit3435345()
{

alert("1");
var compcode=document.getElementById('hiddencompcode').value;
var fromdate= document.getElementById('txtfrmdate').value;
var todate=document.getElementById('txttodate1').value;
var agency=document.getElementById('txtagency1').value;
var client=document.getElementById('txtclient1').value;
var cioid=document.getElementById('txtciod').value;

changeexecutive.submit(compcode,fromdate,todate,agency,client,cioid)
return false;
}

function rrr(event)
{
var compcode=document.getElementById('hiddencompcode').value;
var fromdate= document.getElementById('txtfrmdate').value;
var todate=document.getElementById('txttodate1').value;
var agency=document.getElementById('txtagency1').value;
var client=document.getElementById('txtclient1').value;
var cioid = document.getElementById('txtciod').value;
if (document.getElementById('txtfrmdate').value == "") {
    alert("Please fill from date");
    return false;
}
if (document.getElementById('txttodate1').value == "") {
    alert("Please fill To  date");
    return false;
}
document.getElementById('divgrid1').style.display = "block"
//changeexecutive.submit(compcode,fromdate,todate,agency,client,cioid)
//return false;
}

function bindgrid()
{
    changeexecutive.bindexecutive();
    return false;
}

function bindgrid() {
    changeexecutive.bindclientname_2();
    return false;
}

function bindgrid() {
    changeexecutive.fillF2_Creditretainer();
    return false;
}

function bindgrid() {
    changeexecutive.fillAdd();
    return false;
}


  function exit()
    {
    
   
    if(confirm("Do You Want To Skip This Page"))
	{
	window.location.href='Default.aspx';
	//window.close();
	return false;
	}
	return false;
  }
//===========================================Client  f2 grid=======================
  function fillCLIENT(event, id)
    {
     if (event.keyCode == 113)
        {
          var compcode = document.getElementById('hiddencompcode').value;
          //var userid = document.getElementById('hiddenuserid').value;
          var userid = "";
          var res = changeexecutive.fillF2_Creditclient(compcode, userid);
          fillF2_Creditclient(res, id)
        }
      return false;
  }  

  function fillF2_Creditclient(res, id1) {
      var ds_AccName = res.value;
      document.getElementById("hdnglobalid").value = id1;
      if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
          var pkgitem = document.getElementById("lstclientname");
          pkgitem.options.length = 0;
          pkgitem.options[0] = new Option("-Please Select Client Name-", "0");
          pkgitem.options.length = 1;
          for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
              pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name, ds_AccName.Tables[0].Rows[i].Cust_Code);
              pkgitem.options.length;
          }
      }
      var aTag = eval(document.getElementById(id1))
      var btag;
      var leftpos = 0;
      var toppos = 0;
      do {
          aTag = eval(aTag.offsetParent);
          leftpos += aTag.offsetLeft;
          toppos += aTag.offsetTop;
          btag = eval(aTag)
      } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
      var tot = 0; //document.getElementById('div2').scrollLeft;
      document.getElementById('div3').style.display = "block";
      var scrolltop = document.getElementById('divgrid1').scrollTop;
      document.getElementById('div3').style.left = document.getElementById(id1).offsetLeft + leftpos - tot + "px";
      document.getElementById('div3').style.top = document.getElementById(id1).offsetTop + toppos - scrolltop + "px"; //"510px";
      document.getElementById("lstclientname").value = "0";
      document.getElementById("div3").value = "";
      document.getElementById('lstclientname').disabled = false
      document.getElementById('div3').style.display = "block";
      document.getElementById('lstclientname').focus();
      return false;
  }

  function clickclient_name(event) {
      var key = event.keyCode ? event.keyCode : event.which;
      if (key == 13 || event.type == "click") {
          if (document.activeElement.id == "lstclientname") {
              if (document.getElementById('lstclientname').value == "0") {
                  alert("Please select Client Name");
                  return false;
              }

              var page = document.getElementById('lstclientname').value;
              agencycode = page;
              for (var k = 0; k <= document.getElementById('lstclientname').length - 1; k++) {
                  if (document.getElementById('lstclientname').options[k].value == page) {
                      if (browser != "Microsoft Internet Explorer") {
                          var abc = document.getElementById('lstclientname').options[k].textContent;
                      }
                      else {
                          var abc = document.getElementById('lstclientname').options[k].innerText;
                      }
                      var nID = document.getElementById("hdnglobalid").value;
                      document.getElementById(nID).value = abc;
                      document.getElementById('HDNCLIENT').value = abc;
                      document.getElementById('HDNCLIENT').value = page;

                      document.getElementById("div3").style.display = "none";
                      //  document.getElementById('hdnglobalid').focus();
                      return false;
                  }
              }
          }
      }
      else if (key == 27) {

          document.getElementById("div3").style.display = "none";
          // document.getElementById('hdnglobalid').focus();
      }
  }

//===========================================Retainer f2=======================

 function fillretainer(event, id) {
      if (event.keyCode == 113) {
          var compcode = document.getElementById('hiddencompcode').value;
          //var userid = document.getElementById('hiddenuserid').value;
          var userid = "";
          var res = changeexecutive.F2fillretainercr_exe(compcode, userid);
          F2fillretainercr_exe(res, id)
      }
      return false;
  }

 function F2fillretainercr_exe(res, id1) {
      var ds_AccName = res.value;
      document.getElementById("hdnglobalid").value = id1;
      if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
          var pkgitem = document.getElementById("lstretainer");
          pkgitem.options.length = 0;
          pkgitem.options[0] = new Option("-Please Select Retainer Name-", "0");
          pkgitem.options.length = 1;
          for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
              pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Retain_Name, ds_AccName.Tables[0].Rows[i].Retain_Code);
              pkgitem.options.length;
          }
      }
      var aTag = eval(document.getElementById(id1))
      var btag;
      var leftpos = 0;
      var toppos = 0;
      do {
          aTag = eval(aTag.offsetParent);
          leftpos += aTag.offsetLeft;
          toppos += aTag.offsetTop;
          btag = eval(aTag)
      } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
      var tot = 0; //document.getElementById('div2').scrollLeft;
      document.getElementById('div4').style.display = "block";
      var scrolltop = document.getElementById('divgrid1').scrollTop;
      document.getElementById('div4').style.left = document.getElementById(id1).offsetLeft + leftpos - tot + "px";
      document.getElementById('div4').style.top = document.getElementById(id1).offsetTop + toppos - scrolltop + "px"; //"510px";
      document.getElementById("lstretainer").value = "0";
      document.getElementById("div4").value = "";
      document.getElementById('lstretainer').disabled = false
      document.getElementById('div4').style.display = "block";
      document.getElementById('lstretainer').focus();
      return false;
  }

function Clickretainer_exe(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstretainer") {
            if (document.getElementById('lstretainer').value == "0") {
                alert("Please select Client Name");
                return false;
            }

            var page = document.getElementById('lstretainer').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstretainer').length - 1; k++) {
                if (document.getElementById('lstretainer').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstretainer').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstretainer').options[k].innerText;
                    }
                    var nID = document.getElementById("hdnglobalid").value;
                    document.getElementById(nID).value = abc;
                    document.getElementById('hdnretainer').value = abc;
                    document.getElementById('hdnretainer').value = page;
                    document.getElementById("div4").style.display = "none";
                    //  document.getElementById('hdnglobalid').focus();
                    return false;
                }
            }
        }
    }
    else if (key == 27) {

        document.getElementById("div4").style.display = "none";
        // document.getElementById('hdnglobalid').focus();
    }
}

//===========================================end Retainer f2=======================
var compcol = ""
var cioid = ""
var executivecode = ""
var clientadd = ""
var clientname = ""
var retainername = "", extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = ""



  function tabvalue111(event) {

      var browser = navigator.appName;
      if (event.keyCode == 113) {

          if (document.activeElement.id == "txtagency1") {
              if (document.getElementById('txtagency1').value.length <= 2) {
                  alert("Please Enter Minimum 3 Character For Searching.");
                  document.getElementById('txtagency1').value = "";
                  return false;
              }
              document.getElementById("div1").style.display = "block";
              document.getElementById("div1").style.display = "block";
              aTag = eval(document.getElementById("txtagency1"))
              var btag;
              var leftpos = 0;
              var toppos = 0;
              do {
                  aTag = eval(aTag.offsetParent);
                  leftpos += aTag.offsetLeft;
                  toppos += aTag.offsetTop;
                  btag = eval(aTag)
              } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
              document.getElementById('div1').style.top = document.getElementById("txtagency1").offsetTop + toppos + "px";
              document.getElementById('div1').style.left = document.getElementById("txtagency1").offsetLeft + leftpos + "px";
              changeexecutive.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency1').value.toUpperCase(), bindagencyname_callback);

          }
          else if (document.activeElement.id == "txtclient1") {
              if (document.getElementById('txtclient1').value.length <= 2) {
                  alert("Please Enter Minimum 3 Character For Searching.");
                  document.getElementById('lstclientname').value = "";
                  return false;
              }
              document.getElementById("lstclientname").style.display = "block";
              aTag = eval(document.getElementById("txtclient1"))
              var btag;
              var leftpos = 0;
              var toppos = 0;
              do {
                  aTag = eval(aTag.offsetParent);
                  leftpos += aTag.offsetLeft;
                  toppos += aTag.offsetTop;
                  btag = eval(aTag)
              } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
              document.getElementById('lstclientname').style.top = document.getElementById("txtclient1").offsetTop + toppos + "px";
              document.getElementById('lstclientname').style.left = document.getElementById("txtclient1").offsetLeft + leftpos + "px";
              changeexecutive.bindclientname_2(document.getElementById('hiddencompcode').value, document.getElementById('txtclient1').value.toUpperCase(), bindclientname_callback);
          }

          else if (document.activeElement.id == "dpretainer") {
              if (document.getElementById('dpretainer').value.length <= 2) {
                  alert("Please Enter Minimum 3 Character For Searching.");
                  document.getElementById('dpretainer').value = "";
                  return false;
              }
              document.getElementById("div3").style.display = "block";
              aTag = eval(document.getElementById("dpretainer"))
              var btag;
              var leftpos = 0;
              var toppos = 0;
              do {
                  aTag = eval(aTag.offsetParent);
                  leftpos += aTag.offsetLeft;
                  toppos += aTag.offsetTop;
                  btag = eval(aTag)
              } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
              document.getElementById('div3').style.top = document.getElementById("dpretainer").offsetTop + toppos + "px";
              document.getElementById('div3').style.left = document.getElementById("dpretainer").offsetLeft + leftpos + "px";
              Displayqutation.fillF2_Creditretainer(document.getElementById('hiddencompcode').value, document.getElementById('dpretainer').value.toUpperCase(), bindretainer_callback);
          }

          else if (document.activeElement.id == "txtexecname") {
              if (document.getElementById('txtexecname').value.length <= 2) {
                  alert("Please Enter Minimum 3 Character For Searching.");
                  document.getElementById('txtexecname').value = "";
                  return false;
              }
              //                    document.getElementById('dpretainer').value='';
              document.getElementById("divexec").style.display = "block";
              aTag = eval(document.getElementById("txtexecname"))
              var btag;
              var leftpos = 0;
              var toppos = 0;
              do {
                  aTag = eval(aTag.offsetParent);
                  leftpos += aTag.offsetLeft;
                  toppos += aTag.offsetTop;
                  btag = eval(aTag)
              } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
              document.getElementById('divexec').style.top = document.getElementById("txtexecname").offsetTop + toppos + "px";
              document.getElementById('divexec').style.left = document.getElementById("txtexecname").offsetLeft + leftpos + "px";
              Displayqutation.bindExec(document.getElementById('hiddencompcode').value, document.getElementById('txtexecname').value.toUpperCase(), bindexecname_callback);
          }


      }

      else if (event.keyCode == 27) {
          if (document.getElementById("div1").style.display == "block") {
              document.getElementById("div1").style.display = "none"
              document.getElementById('txtagency1').focus();
          }
          else if (document.getElementById("divclient").style.display == "block") {
              document.getElementById("divclient").style.display = "none"
              document.getElementById('txtclient1').focus();
          }
          //        else if (document.getElementById("divexec").style.display == "block") {
          //            document.getElementById("divexec").style.display = "none"
          //            document.getElementById('txtexecname').focus();
          //        }
          //        else if (document.getElementById("div3").style.display == "block") {
          //        document.getElementById("div3").style.display = "none"
          //        document.getElementById('dpretainer').focus();
          //        }

      }
      else if (event.keyCode == 13 || event.keyCode == 9 && event.shiftKey == false) {

          if (document.activeElement.id == "lstclient") {
              if (document.getElementById('lstclient').value == "0") {
                  alert("Please select the client");
                  return false;
              }
              document.getElementById("divclient").style.display = "none";
              var datetime = "";
              /*@@ this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
              address and if 0 than agency name and address @@@@@@@@@@@@@@@@@@@*/

              var page = document.getElementById('lstclient').value;
              var id = "";
              document.getElementById("Hiddenclientcode").value = page;
              if (browser != "Microsoft Internet Explorer") {
                  var httpRequest = null;;
                  httpRequest = new XMLHttpRequest();
                  if (httpRequest.overrideMimeType) {
                      httpRequest.overrideMimeType('text/xml');
                  }
                  httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

                  httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
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
                  xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
                  xml.Send();
                  id = xml.responseText;
              }
              var split = id.split("+");
              var namecode = split[0];
              var add = split[1];
              var split = namecode.split("(");
              var abc = split[0];

              document.getElementById('txtclient1').value = abc;

              /* if(document.getElementById('hiddensavemod').value=="0")
              {
              document.getElementById('txtclient1add').value=add;
              document.getElementById('txtclient1add').focus();
              }
              bind_agen_bill();*/
              document.getElementById('txtclient1').focus();
              return false;
          }
          else if (document.activeElement.id == "lstagency") {
              if (document.getElementById('lstagency').value == "0") {
                  alert("Please select the agency sub code");
                  return false;
              }
              document.getElementById("div1").style.display = "none";
              var datetime = "";
              var page = document.getElementById('lstagency').value;
              //document.getElementById('hiddenagency').value=page;
              document.getElementById("Hiddenagencycode").value = page;
              agencycodeglo = page;

              var id = "";
              if (browser != "Microsoft Internet Explorer") {
                  var httpRequest = null;;
                  httpRequest = new XMLHttpRequest();
                  if (httpRequest.overrideMimeType) {
                      httpRequest.overrideMimeType('text/xml');
                  }

                  httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

                  httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=0", false);
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
                  xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=0", false);
                  xml.Send();
                  id = xml.responseText;
              }
              var split = id.split("+");
              var nameagen = split[0];
              var agenadd = split[1];

              document.getElementById('txtagency1').value = nameagen;
              /* if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
              {
              document.getElementById('txtagency1address').value=agenadd;                
              document.getElementById('txtclient1').focus();
              Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
              }*/
              document.getElementById('txtagency1').focus();
              return false;
          }

              ///this is for exec name
          else if (document.activeElement.id == "lstexec") {
              if (document.getElementById('lstexec').value == "0") {
                  alert("Please select the executive");
                  return false;
              }

              document.getElementById("divexec").style.display = "none";
              var datetime = "";

              var page = document.getElementById('lstexec').value;
              document.getElementById("Hiddenexecutivecode").value = page;
              var id = "";
              if (browser != "Microsoft Internet Explorer") {
                  var httpRequest = null;;
                  httpRequest = new XMLHttpRequest();
                  if (httpRequest.overrideMimeType) {
                      httpRequest.overrideMimeType('text/xml');
                  }
                  httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

                  httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
                  httpRequest.send('');
                  if (httpRequest.readyState == 4) {
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
                  xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
                  xml.Send();
                  id = xml.responseText;
              }

              document.getElementById('txtexecname').value = id;
              document.getElementById('txtexecname').focus();

              return false;
          }
          else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
              event.keyCode = 13;
              return event.keyCode;
          }
          else {
              var idcursor;
              if (event.shiftKey == false) {
                  event.keyCode = 9;
                  return event.keyCode;
              }
          }
      }
  }

  //===========================================Client Add=======================
  function fillAdd(event, id) {
      if (event.keyCode == 113) {
          var compcode = document.getElementById('hiddencompcode').value;
          //var userid = document.getElementById('hiddenuserid').value;
          var userid = "";
          //var res = changeexecutive.F2fillcliadd(compcode, userid);
          //F2fillcliadd(res, id)
      }
      return false;
  }

 