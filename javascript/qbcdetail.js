// JScript File
var browser = navigator.appName;
function insertagency() {
    if (document.activeElement.id == "lstproduct") {
        if (document.getElementById('lstproduct').value == "0") {
            alert("Please select the product");
            return false;
        }
        document.getElementById("divproduct").style.display = "none";
        var datetime = "";

        var page = document.getElementById('lstproduct').value;
        //agencycodeglo=page;

        var id = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

            httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=2", false);
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
            if (id == "yes") {
                alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                return false;
            }
        }
        else {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=2", false);
            xml.Send();
            id = xml.responseText;
        }

        if (id == "yes") {
            alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
            return false;
        }


        document.getElementById('txtproduct').value = id;
        if (document.getElementById('drppaymenttype').disabled == false)
            document.getElementById('drppaymenttype').focus();

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
        //agencycodeglo=page;

        var id = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
            httpRequest = new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml');
            }

            httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

            httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
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
            xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=3", false);
            xml.Send();
            id = xml.responseText;
        }

        if (id == "yes") {
            alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
            return false;
        }
        document.getElementById('txtexecname').value = id;


        //document.getElementById('txtexeczone').focus();
        QBCDETAIL.getexeczone(page, document.getElementById('hiddencompcode').value, call_bindexeczone);
        return false;
    }
}
function rateenter(event) {
    //alert(event.keyCode);
    if (document.all) {
        if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 190)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.which >= 46 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9)) {
            return true;
        }
        else {
            return false;
        }
    }
}
function tabvalue(event) {
    if (event.keyCode == 13) {
        if (document.activeElement.id == "lstretainer") {
            if (document.getElementById('lstretainer').value == "0") {
                alert("Please select the retainer");
                return false;
            }
            document.getElementById('drpretainer').value = document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text + "(" + document.getElementById('lstretainer').value + ")";
            document.getElementById("divretainer").style.display = "none";
            if (document.getElementById('drpretainer').value != "" && document.getElementById('drpretainer').value != "0") {
                document.getElementById('txtRetainercomm').value = "";
                var retain_name = document.getElementById('drpretainer').value.split('(');
                var retain_code = retain_name[1].replace(')', '');
                var ds_ret = QBCDETAIL.getRetainerComm(retain_code, document.getElementById('hiddencompcode').value);

                if (ds_ret.value == null)
                    return false;

                if (ds_ret.value.Tables[0].Rows.length > 0) {
                    // document.getElementById('retcommtype').value=ds_ret.value.Tables[0].Rows[0].Discount;
                    document.getElementById('txtRetainercomm').value = ds_ret.value.Tables[0].Rows[0].retainercomm;
                    //  document.getElementById('retcomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                    //                        if(document.getElementById('retcommtype').value=="Gross" && document.getElementById('txtgrossamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                    //                        {
                    //                            document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                    //                        }
                    //                        else  if(document.getElementById('retcommtype').value=="Net" && document.getElementById('txtbillamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                    //                        {
                    //                            document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtbillamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                    //                        }
                }
                if (document.getElementById('drppageprem').disabled == false)
                    document.getElementById('drppageprem').focus();
                return false;
            }
        }
        else if (document.activeElement.id == "lstexec") {
            if (document.getElementById('lstexec').value == "0") {
                alert("Please select the executive");
                return false;
            }

            document.getElementById("divexec").style.display = "none";
            var datetime = "";

            var page = document.getElementById('lstexec').value;

            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
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

            QBCDETAIL.getexeczone(page, document.getElementById('hiddencompcode').value, call_bindexeczone);
            return false;
        }
        else if (document.activeElement.id == "lstproduct") {
            if (document.getElementById('lstproduct').value == "0") {
                alert("Please select the product");
                return false;
            }
            document.getElementById("divproduct").style.display = "none";
            var datetime = "";

            var page = document.getElementById('lstproduct').value;
            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }

                httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=2", false);
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
                xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=2", false);
                xml.Send();
                id = xml.responseText;
            }
            document.getElementById('txtproduct').value = id;
            if (document.getElementById('drppaymenttype').disabled == false)
                document.getElementById('drppaymenttype').focus();
            return false;
        }
        else {
            event.keyCode = 9;
            return event.keyCode;
        }
    }
    else if (event.keyCode == 27) {
        if (document.getElementById("divproduct").style.display == "block") {
            document.getElementById("divproduct").style.display = "none"
            document.getElementById('txtproduct').focus();
        }
        else if (document.getElementById("divexec").style.display == "block") {
            document.getElementById("divexec").style.display = "none"
            document.getElementById('txtexecname').focus();
        }
        else if (document.getElementById("divretainer").style.display == "block") {
            document.getElementById("divretainer").style.display = "none"
            document.getElementById('drpretainer').focus();
        }
    }
    else if (event.keyCode == 113) {
        if (document.activeElement.id == "txtproduct") {
            document.getElementById("divproduct").style.display = "block";
            aTag = eval(document.getElementById("txtproduct"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById("divproduct").style.left = document.getElementById("txtproduct").offsetLeft + leftpos + "px";
            document.getElementById("divproduct").style.top = document.getElementById("txtproduct").offsetTop + toppos + "px"; //"510px";
            // document.getElementById('divproduct').style.top=parseInt(document.getElementById('txtproduct').offsetTop) +  parseInt(document.getElementById('OuterTable').offsetTop) + 380 + "px";
            // document.getElementById('divproduct').style.left=parseInt(document.getElementById('txtproduct').offsetLeft) +  parseInt(document.getElementById('OuterTable').offsetLeft) + 92 + "px";
            QBCDETAIL.bindProduct(document.getElementById('hiddencompcode').value, document.getElementById('txtproduct').value, bindproductname_callback);
        }
        else if (document.activeElement.id == "txtexecname") {
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
            document.getElementById("divexec").style.left = document.getElementById("txtexecname").offsetLeft + leftpos + "px";
            document.getElementById("divexec").style.top = document.getElementById("txtexecname").offsetTop + toppos + "px"; //"510px";

            QBCDETAIL.bindExec(document.getElementById('hiddencompcode').value, document.getElementById('txtexecname').value, bindexecname_callback);
        }
        else if (document.activeElement.id == "drpretainer") {
            if (document.getElementById('txtexecname').value != "") {
                if (confirm('Are you sure you want to Take Retainer')) {
                    document.getElementById('txtexecname').value = "";
                    document.getElementById('txtexeczone').value = "";
                    document.getElementById("divretainer").style.display = "block";
                    aTag = eval(document.getElementById("drpretainer"))
                    var btag;
                    var leftpos = 0;
                    var toppos = 0;
                    do {
                        aTag = eval(aTag.offsetParent);
                        leftpos += aTag.offsetLeft;
                        toppos += aTag.offsetTop;
                        btag = eval(aTag)
                    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                    document.getElementById("divretainer").style.left = document.getElementById("drpretainer").offsetLeft + leftpos + "px";
                    document.getElementById("divretainer").style.top = document.getElementById("drpretainer").offsetTop + toppos + "px"; //"510px";
                    QBCDETAIL.bindRetainer(document.getElementById('hiddencompcode').value, document.getElementById('drpretainer').value, bindretainer_callback);

                }
                else {
                    document.getElementById('drpretainer').value = "";
                    document.getElementById("divretainer").style.display = "none";
                }

            }
            else {
                document.getElementById("divretainer").style.display = "block";
                aTag = eval(document.getElementById("drpretainer"))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById("divretainer").style.left = document.getElementById("drpretainer").offsetLeft + leftpos + "px";
                document.getElementById("divretainer").style.top = document.getElementById("drpretainer").offsetTop + toppos + "px"; //"510px";
                QBCDETAIL.bindRetainer(document.getElementById('hiddencompcode').value, document.getElementById('drpretainer').value, bindretainer_callback);
            }
        }
    }
}
function bindproductname_callback(response) {
    ds = response.value;
    var pkgitem = document.getElementById("lstproduct");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Product-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].prod_desc, ds.Tables[0].Rows[i].prod_cat_code);
            pkgitem.options.length;
        }

    }
    document.getElementById('txtproduct').value = "";
    document.getElementById("lstproduct").value = "0";
    document.getElementById("lstproduct").focus();

    return false;

}
function bindretainer_callback(res) {
    var ds = res.value;
    var pkgitem = document.getElementById("lstretainer");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Retainer-", "0");

    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name, ds.Tables[0].Rows[i].Retain_Code);
            pkgitem.options.length;
        }

    }
    document.getElementById("divretainer").style.display = "block";
    document.getElementById('drpretainer').value = "";
    document.getElementById("lstretainer").value = "0";
    document.getElementById("lstretainer").focus();
    return false;
}
function bindexecname_callback(response) {
    ds = response.value;
    var pkgitem = document.getElementById("lstexec");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Exec-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Exec_name, ds.Tables[0].Rows[i].Exe_no);
            pkgitem.options.length;
        }
    }
    document.getElementById('txtexecname').value = "";
    document.getElementById("lstexec").value = "0";
    document.getElementById("lstexec").focus();
    return false;

}
function call_bindexeczone(res) {
    var ds = res.value;
    if (document.getElementById('drpretainer').value != '0') {

        if (confirm('Are you sure you want to Take Executive')) {
            document.getElementById('drpretainer').value = "";
            document.getElementById('txtRetainercomm').value = "";
        }
        else {
            document.getElementById('txtexeczone').value = "";
            document.getElementById('txtexecname').value = "";
            return false;
        }
    }
    if (ds != null) {
        if (ds.Tables[0].Rows.length > 0) {
            document.getElementById('txtexeczone').value = ds.Tables[0].Rows[0].zone_name;
            if (document.getElementById('drpretainer').disabled == false)
                document.getElementById('drpretainer').focus();
        }
    }
}

function getpremper() {
    document.getElementById('txtagreedamt').value = "";
    // if(document.getElementById('drppageprem').value!="0")
    {
        QBCDETAIL.getPremPage(document.getElementById('drppageprem').value, '0', getPremPage_callBack);
    }
}
function getPremPage_callBack(res) {
    var ds = res.value;
    document.getElementById('txtpremper').value = "";
    if (ds != null) {
        if (ds.Tables[0].Rows.length > 0) {
            // if(ds.Tables[0].Rows[0].page_no!=null)
            // document.getElementById('txtpageno').value=ds.Tables[0].Rows[0].page_no;
            document.getElementById('txtpremper').value = ds.Tables[0].Rows[0].premium_charges;
        }
    }
}

function showretainervalue() {
    if (document.getElementById('lstretainer').value == "0") {
        alert("Please Select Retainer");
        return false;
    }
    document.getElementById('drpretainer').value = document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text + "(" + document.getElementById('lstretainer').value + ")";
    document.getElementById('lstretainer').options.length = 0
    document.getElementById("divretainer").style.display = "none";
    if (document.getElementById('drpretainer').value != "" && document.getElementById('drpretainer').value != "0") {
        document.getElementById('txtRetainercomm').value = "";
        var retain_name = document.getElementById('drpretainer').value.split('(');
        var retain_code = retain_name[1].replace(')', '');
        var ds_ret = QBCDETAIL.getRetainerComm(retain_code, document.getElementById('hiddencompcode').value);

        if (ds_ret.value == null)
            return false;

        if (ds_ret.value.Tables[0].Rows.length > 0) {
            document.getElementById('txtRetainercomm').value = ds_ret.value.Tables[0].Rows[0].retainercomm;
        }
        if (document.getElementById('drppageprem').disabled == false)
            document.getElementById('drppageprem').focus();
    }
    return false;

}
function setDefaultval() {
    window.opener.document.getElementById('hiddenexecname').value = document.getElementById('txtexecname').value;
    window.opener.document.getElementById('hiddenproduct').value = document.getElementById('txtproduct').value;
    window.opener.document.getElementById('hiddendrppageprem').value = document.getElementById('drppageprem').value;
    window.opener.document.getElementById('hiddentxtpremper').value = document.getElementById('txtpremper').value;
    window.opener.document.getElementById('hiddenagreedamt').value = document.getElementById('txtagreedamt').value;
    window.opener.document.getElementById('hiddenspediscper').value = document.getElementById('txtspediscper').value;
    window.opener.document.getElementById('hiddenspedisc').value = document.getElementById('txtspedisc').value;
    window.opener.document.getElementById('hiddenretainer').value = document.getElementById('drpretainer').value;
    window.opener.document.getElementById('hiddenpay').value = document.getElementById('drppaymenttype').value;
    window.opener.document.getElementById('hiddenzone').value = document.getElementById('txtexeczone').value;
    window.opener.document.getElementById('hiddenretainercomm').value = document.getElementById('txtRetainercomm').value;
    window.opener.document.getElementById('hiddenspecharges').value = document.getElementById('txtextracharges').value;
    window.opener.document.getElementById('Hiddendrppageposition').value = document.getElementById('drppageposition').value;
    window.opener.document.getElementById('Hiddentxtpageamt').value = document.getElementById('txtpageamt').value;
}
function setValue() {
    if (document.getElementById('txtspedisc').value != "") {
        if (parseFloat(document.getElementById('hiddencardrate').value) < parseFloat(document.getElementById('txtspedisc').value)) {
            alert('Special discount can not be greater than card rate');
            document.getElementById('txtspedisc').value = "";
            return false;
        }
    }
    if (parseFloat(document.getElementById('txtspediscper').value) > 100) {
        alert('Special discount can not be greated than 100%');
        document.getElementById('txtspediscper').value = "";
        document.getElementById('txtspediscper').focus();
        return false;
    }
    window.opener.document.getElementById('hiddenexecname').value = document.getElementById('txtexecname').value;
    window.opener.document.getElementById('hiddenproduct').value = document.getElementById('txtproduct').value;
    window.opener.document.getElementById('hiddendrppageprem').value = document.getElementById('drppageprem').value;
    window.opener.document.getElementById('hiddentxtpremper').value = document.getElementById('txtpremper').value;
    window.opener.document.getElementById('hiddenagreedamt').value = document.getElementById('txtagreedamt').value;
    window.opener.document.getElementById('hiddenspediscper').value = document.getElementById('txtspediscper').value;
    window.opener.document.getElementById('hiddenspedisc').value = document.getElementById('txtspedisc').value;
    window.opener.document.getElementById('hiddenretainer').value = document.getElementById('drpretainer').value;
    window.opener.document.getElementById('hiddenpay').value = document.getElementById('drppaymenttype').value;
    window.opener.document.getElementById('hiddenzone').value = document.getElementById('txtexeczone').value;
    window.opener.document.getElementById('hiddenretainercomm').value = document.getElementById('txtRetainercomm').value;
    window.opener.document.getElementById('hiddenspecharges').value = document.getElementById('txtextracharges').value;
    //  alert(window.opener.document.getElementById('Hiddendrppageposition'));
    //  alert(document.getElementById('drppageposition'));
    if (document.getElementById('drppageposition') != null)
        window.opener.document.getElementById('Hiddendrppageposition').value = document.getElementById('drppageposition').value;
    if (document.getElementById('txtpageamt') != null)
        window.opener.document.getElementById('Hiddentxtpageamt').value = document.getElementById('txtpageamt').value;
    window.close();
}
function setspediscper() {
    if (document.getElementById('txtspedisc').value != "")
        document.getElementById('txtspediscper').value = "";
}
function setspedisc() {
    if (document.getElementById('txtspediscper').value != "")
        document.getElementById('txtspedisc').value = "";
}


function getpageamt() {

    var pagename = document.getElementById('drppageposition').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var bookdate = document.getElementById('txtdatetime').value;
    if (pagename == "0") {
        document.getElementById('txtpageamt').value = "";
        //            document.getElementById('txtgrossamt').value = "";
        //            document.getElementById('txtgrossamtlocal').value = "";
        //            document.getElementById('txtbillamtlocal').value = "";
    }
    var res = QBCDETAIL.getpageamount(pagename, compcode, bookdate, document.getElementById('hiddendateformat').value);
    call_getpageamt(res);


}

function call_getpageamt(res) {
    var ds = res.value;
    document.getElementById('txtpageamt').value = "";
    //        document.getElementById('txtgrossamt').value = "";
    //        document.getElementById('txtgrossamtlocal').value = "";
    //        document.getElementById('txtbillamtlocal').value = "";
    if (ds.Tables[0].Rows.length > 0) {
        document.getElementById('txtpageamt').value = ds.Tables[0].Rows[0].Amount
        //              var len="bookdiv";
        //            var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
        //            var i=0;
        //            var k;
        //            var page;
        //            var pagstr="sec";
        var pagename = document.getElementById('drppageposition').value;
        //            for(k=0;i<y-1;k++)
        //            { 
        //                    
        //                    page=document.getElementById("pgpre"+i);
        //                    if(document.getElementById("pgpre"+i)!=null)
        //                        page.value=pagename; //document.getElementById('drppageposition').options[document.getElementById('drppageposition').selectedIndex].value;            
        //                    if(document.getElementById("pagper"+i)!=null)
        //                        document.getElementById("pagper"+i).value= document.getElementById('txtpageamt').value;      
        //                    i++;        
        //            }
    }
    //        else
    //        {
    //              var len="bookdiv";
    //            var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
    //            var i=0;
    //            var k;
    //              for(k=0;i<y-1;k++)
    //            { 
    //                     var pagename=document.getElementById('drppageposition').value;
    //                     if(pagename==0)
    //                        pagename="";
    //                    var page=document.getElementById("pgpre"+i);
    //                    if(document.getElementById("pgpre"+i)!=null)
    //                        page.value=pagename; 
    //                    if(document.getElementById("pagper"+i)!=null)
    //                        document.getElementById("pagper"+i).value="";    
    //                        i++;  
    //             }           
    //        }
    //        if(document.getElementById('tblinsert').innerHTML!="")
    //        {
    //            flagins="0";
    //        }

}