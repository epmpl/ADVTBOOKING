var browser = navigator.appName;
var data1;
// var macAddress = "";
//    var ipAddress = "";
//    var computerName = "";
//    var wmi = GetObject("winmgmts:{impersonationLevel=impersonate}");
//    e = new Enumerator(wmi.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True"));
//    for(; !e.atEnd(); e.moveNext()) {
//        var s = e.item();
//        macAddress = s.MACAddress;
//        ipAddress = s.IPAddress(0);
//        computerName = s.DNSHostName;
//    }
//    alert(macAddress+ipAddress+computerName)
function dealf2(event) {
 if(event.keyCode==113)
    {
    if (browser != "Microsoft Internet Explorer") {
        colName = "";
        document.getElementById("divdeal").style.display = "block";
        aTag = eval(document.getElementById("txtdeal"))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        document.getElementById('divdeal').style.top = document.getElementById("txtdeal").offsetTop + toppos + "px";
        document.getElementById('divdeal').style.left = document.getElementById("txtdeal").offsetLeft + leftpos + "px";
        var mod = "print";
        dealprovision.binddealno(document.getElementById('hiddencompcode').value, document.getElementById('txtdeal').value.toUpperCase(), mod, binddealno_callback);
    }
    else {
        colName = "";
        document.getElementById("divdeal").style.display = "block";
        aTag = eval(document.getElementById("txtdeal"))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        document.getElementById('divdeal').style.top = document.getElementById("txtdeal").offsetTop + toppos + "px";
        document.getElementById('divdeal').style.left = document.getElementById("txtdeal").offsetLeft + leftpos + "px";
        var mod = "print";
        dealprovision.binddealno(document.getElementById('hiddencompcode').value, document.getElementById('txtdeal').value.toUpperCase(), mod, binddealno_callback);
    }
    }
}
function binddealno_callback(response) {
    ds = response.value;
    //document.getElementById('drpretainer').value="";
    var pkgitem = document.getElementById("lstdeal");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Deal-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        //alert(pkgitem.options.length);
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].deal_name + '+' + ds.Tables[0].Rows[i].Deal_No, ds.Tables[0].Rows[i].Deal_No);
            pkgitem.options.length;
        }
    }
    document.getElementById('txtdeal').value = "";
    document.getElementById("lstdeal").value = "0";
    document.getElementById("lstdeal").focus();
    return false;
}
function dealclick(event) {
    if (event.keyCode == 13 || event.type == "click") {
        if(document.activeElement.id=="lstdeal")
            {
            if(document.getElementById('lstdeal').value=="0")// || document.getElementById('hiddensavemod').value=="01")
            {
                alert("Please select the agency code");
                return false;
            }
                document.getElementById("divdeal").style.display="none";
                var datetime="";
                //alert(document.getElementById('lstagency').value);                
                 //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/                
                var page=document.getElementById('lstdeal').value;
               // document.getElementById('hiddenagency').value=page;
//                agencycodeglo=page;
//                 var value="0";
//                var res=dealaudit.addclientname(page,datetime,value);
//                 var id=res.value;
//                 var split=id.split("+");
//                 var nameagen=split[0];
//                 var agenadd=split[1];//
                document.getElementById('txtdeal').value = page;      
                document.getElementById('txtdeal').focus();
                return false;
            }
        }
        if (event.keyCode == 27) {
            document.getElementById("divdeal").style.display = "none";
            document.getElementById('txtdeal').focus();
        }
    }
    function agencybindf2(event) {
        if (event.keyCode == 113) {
            if (document.getElementById('txtagency').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtagency').value = "";
                return false;
            }
            colName = "";
            document.getElementById("div1").style.display = "block";
            aTag = eval(document.getElementById("txtagency"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('div1').style.top = document.getElementById("txtagency").offsetTop + toppos + "px";
            document.getElementById('div1').style.left = document.getElementById("txtagency").offsetLeft + leftpos + "px";
            dealprovision.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency').value.toUpperCase(), bindagencyname_callback);
        }
    }
    function clientf2(event) {
        if (event.keyCode == 113) {
            if (document.getElementById('txtclient').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtclient').value = "";
                return false;
            }
            colName = "";
            document.getElementById("divclient").style.display = "block";
            aTag = eval(document.getElementById("txtclient"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divclient').style.top = document.getElementById("txtclient").offsetTop + toppos + "px";
            document.getElementById('divclient').style.left = document.getElementById("txtclient").offsetLeft + leftpos + "px";
            dealprovision.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient').value.toUpperCase(), bindclientname_callback);
        }
    }
    function bindagencyname_callback(response) {
        ds = response.value;
        //document.getElementById('drpretainer').value="";
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency-", "0");
        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            pkgitem.options.length = 1;
            //alert(pkgitem.options.length);
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name + '+' + ds.Tables[0].Rows[i].code_subcode, ds.Tables[0].Rows[i].code_subcode);
                pkgitem.options.length;
            }
        }
        document.getElementById('txtagency').value = "";
        document.getElementById("lstagency").value = "0";
        document.getElementById("lstagency").focus();
        return false;
    }
    function bindclientname_callback(response) {
        ds = response.value;
        var pkgitem = document.getElementById("lstclient");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Client-", "0");
        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //alert(pkgitem.options.length);
            pkgitem.options.length = 1;
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name, ds.Tables[0].Rows[i].Cust_Code);
                pkgitem.options.length;
            }
        }
        document.getElementById('txtclient').value = "";
        document.getElementById("lstclient").value = "0";
        document.getElementById("lstclient").focus();  //uncomment
        return false;
    }
    function onclickagency(event) {
        if (event.keyCode == 13 || event.type == "click") {
            if (document.activeElement.id == "lstagency") {
                if (document.getElementById('lstagency').value == "0")// || document.getElementById('hiddensavemod').value=="01")
                {
                    alert("Please select the agency code");
                    return false;
                }
                document.getElementById("div1").style.display = "none";
                var datetime = "";
                //alert(document.getElementById('lstagency').value);
                //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
                var page = document.getElementById('lstagency').value;
                // document.getElementById('hiddenagency').value=page;
                agencycodeglo = page;
                 for (var k = 0; k <= document.getElementById("lstagency").length - 1; k++) {
                     if (document.getElementById('lstagency').options[k].value == page) {
                         if (browser != "Microsoft Internet Explorer") {
                             var abc = document.getElementById('lstagency').options[k].textContent;
                         }
                         else {
                             var abc = document.getElementById('lstagency').options[k].innerText;
                         }
                         var split = abc.split("+");
                         var nameagen = split[0];
                         var agencycode = split[1];
//                         var agencycode = nameagen.split("(");
//                         agencycode = agencycode[1].replace(")", "");
                         document.getElementById('txtagency').value = nameagen;
//                         document.getElementById('hiddenagency').value = agenadd;
                         document.getElementById('hidenagencycode').value = agencycode;
                         document.getElementById('txtagency').focus();
                         return false;
                     }
                }
            }
        }
        if (event.keyCode == 27) {
            document.getElementById("div1").style.display = "none";
            document.getElementById('txtagency').focus();
        }
    }
    function onclickclient(event) {
        if (event.keyCode == 13 || event.type == "click") {
            if (document.getElementById('lstclient').value == "0") {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display = "none";
            var datetime = "";
            //alert(document.getElementById('lstagency').value);
            /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
            address and if 0 than agency name and address
            @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
            var page = document.getElementById('lstclient').value;
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
            var clintcode = namecode.split("(");
            clintcode = clintcode[1].replace(")", "");
            document.getElementById('txtclient').value = namecode;
            document.getElementById('hdclientcode').value = clintcode;
            //                 clientChange();
            /* if(document.getElementById('hiddensavemod').value=="0")
            {
            document.getElementById('txtclientadd').value=add;        
            document.getElementById('txtclientadd').focus();
            }
            bind_agen_bill();*/
            document.getElementById('txtclient').focus();
            return false;
        }
        if (event.keyCode == 27) {
            document.getElementById("divclient").style.display = "none";
            document.getElementById('txtclient').focus();
        }
    }
//    function executivef2(event) {
//        if (event.keyCode == 113) {
//            if (browser != "Microsoft Internet Explorer") {
//                colName = "";
//                document.getElementById("divexe").style.display = "block";
//                aTag = eval(document.getElementById("txtexecutive"))
//                var btag;
//                var leftpos = 0;
//                var toppos = 0;
//                do {
//                    aTag = eval(aTag.offsetParent);
//                    leftpos += aTag.offsetLeft;
//                    toppos += aTag.offsetTop;
//                    btag = eval(aTag)
//                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
//                document.getElementById('divexe').style.top = document.getElementById("txtexecutive").offsetTop + toppos + "px";
//                document.getElementById('divexe').style.left = document.getElementById("txtexecutive").offsetLeft + leftpos + "px";
//                var mod = "print";
//                dealprovision.bindExec(document.getElementById('hiddencompcode').value, document.getElementById('txtexecutive').value.toUpperCase(), bindexe_callback);
//            }

//            else {
//                colName = "";
//                document.getElementById("divexe").style.display = "block";
//                aTag = eval(document.getElementById("txtexecutive"))
//                var btag;
//                var leftpos = 0;
//                var toppos = 0;
//                do {
//                    aTag = eval(aTag.offsetParent);
//                    leftpos += aTag.offsetLeft;
//                    toppos += aTag.offsetTop;
//                    btag = eval(aTag)
//                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
//                document.getElementById('divexe').style.top = document.getElementById("txtexecutive").offsetTop + toppos + "px";
//                document.getElementById('divexe').style.left = document.getElementById("txtexecutive").offsetLeft + leftpos + "px";
//                var mod = "print";
//                dealprovision.bindExec(document.getElementById('hiddencompcode').value, document.getElementById('txtexecutive').value.toUpperCase(), bindexe_callback);

//            }
//        }

//    }

//    function bindexe_callback(response) {


//        ds = response.value;
//        //document.getElementById('drpretainer').value="";
//        var pkgitem = document.getElementById("lstexe");
//        pkgitem.options.length = 0;
//        pkgitem.options[0] = new Option("-Select Executive-", "0");
//        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
//            pkgitem.options.length = 1;
//            //alert(pkgitem.options.length);
//            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
//                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name + '+' + ds.Tables[0].Rows[i].exe_no, ds.Tables[0].Rows[i].exe_no);
//                pkgitem.options.length;
//            }
//        }
//        document.getElementById('txtexecutive').value = "";
//        document.getElementById("lstexe").value = "0";
//        document.getElementById("lstexe").focus();
//        return false;



//    }
//    function onclickexe(event) {

//        if (event.keyCode == 13 || event.type == "click") {
//            if (document.activeElement.id == "lstexe") {
//                if (document.getElementById('lstexe').value == "0") {
//                    // alert("Please select the publication");
//                    return false;
//                }
//                document.getElementById("divexe").style.display = "none";
//                var page = document.getElementById('lstexe').value;
//                agencycodeglo = page;
//                for (var k = 0; k <= document.getElementById("lstexe").length - 1; k++) {
//                    if (document.getElementById('lstexe').options[k].value == page) {
//                        if (browser != "Microsoft Internet Explorer") {
//                            var abc = document.getElementById('lstexe').options[k].textContent;
//                        }
//                        else {
//                            var abc = document.getElementById('lstexe').options[k].innerText;
//                        }
//                        document.getElementById('txtexecutive').value = agencycodeglo;
//                        var splitpub = abc;
//                        var str = splitpub.split("+");
//                        nam3 = str[1];
//                        nam = str[0];
////                        nam1 = str[2];
////                        nam2 = str[3];
//                        document.getElementById('txtexecutive').value = nam + " " + nam3;
//                        document.getElementById('hidenexecode').value =  nam3; 
//                        //  document.getElementById('txtagencycode').value = abc1;
//                        //  document.getElementById('txtagencysubcode').value = abc2;

//                        //  document.getElementById('txtagencycode').value = abc1;
//                        //  document.getElementById('txtagencysubcode').value = abc2;
//                        //  document.getElementById('hdnpubcode').value=abc1;
//                        //  document.getElementById('txtfromdate').focus();
//                        // document.getElementById('txtfromdate').value = "";
//                        document.getElementById('txtexecutive').focus();
//                        return false;
//                    }
//                }
//            }
//        }

//        else if (event.keyCode == 27) {
//        document.getElementById("divexe").style.display = "none";
//        document.getElementById('txtagency').focus();
//        }
//    }
    function repalcestr2quote(val) {
        if (val == null) {
            var a11 = ""
            return a11;
        }
        //    if (val.indexOf("^") >= 0) {
        //        while (val.indexOf("^") >= 0) {
        //            val = val.replace("^", "'");
        //        }
        //    }
        //    return val;
        try {
            if (val.indexOf("^") >= 0) {
                while (val.indexOf("^") >= 0) {
                    val = val.replace("^", "'");
                }
            }
        }
        catch (er) {

        }
        finally {
            return val;
        }
    }
    function submi() {
        if ( document.getElementById('txtfromdate').value == "") {
            alert("Please Enter From Date")
             document.getElementById('txtfromdate').focus();
            return false;
        }
        if ( document.getElementById('txttodate').value == "") {
            alert("Please Enter To Date")
             document.getElementById('txttodate').focus();
            return false;
        }
        var fdate = document.getElementById('txtfromdate').value
        var todate = document.getElementById('txttodate').value
        var deal = document.getElementById('txtdeal').value
        var agency = document.getElementById('hidenagencycode').value
        var client = document.getElementById('hdclientcode').value
//        var executive = document.getElementById('hidenexecode').value
        var Filter = document.getElementById('drpfilter').value
        var pub = document.getElementById('dppubcent').value
        var compcode = document.getElementById('hiddencompcode').value;
        var uid = document.getElementById('hiddenuserid').value;
        
        var adtype = document.getElementById('drpadtype').value;
        var uom = document.getElementById('drpuom').value;
        
        var dateformat = document.getElementById('hiddendateformat').value;
        if (document.getElementById('txtfromdate').value != "") {
            if (document.getElementById('txtfromdate').value != "") {
                if (dateformat == "dd/mm/yyyy") {
                    var txt = document.getElementById('txtfromdate').value;
                    var txt1 = txt.split("/");
                    var dd = txt1[0];
                    var mm = txt1[1];
                    var yy = txt1[2];
                    fdate = mm + '/' + dd + '/' + yy;
                }
                else if (dateformat == "mm/dd/yyyy") {
                fdate = document.getElementById('txtfromdate').value;
                }

                else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txtfromdate').value;
                    var txt1 = txt.split("/");
                    var yy = txt1[0];
                    var mm = txt1[1];
                    var dd = txt1[2];
                    fdate = mm + '/' + dd + '/' + yy;
                }
            }
        }
        var todate;
        if (document.getElementById('txttodate').value != "") {
            if (document.getElementById('txttodate').value != "") {
                if (dateformat == "dd/mm/yyyy") {
                    var txt = document.getElementById('txttodate').value;
                    var txt1 = txt.split("/");
                    var dd = txt1[0];
                    var mm = txt1[1];
                    var yy = txt1[2];
                    todate = mm + '/' + dd + '/' + yy;
                }
                else if (dateformat == "mm/dd/yyyy") {
                todate = document.getElementById('txttodate').value;
                }
                else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txttodate').value;
                    var txt1 = txt.split("/");
                    var yy = txt1[0];
                    var mm = txt1[1];
                    var dd = txt1[2];
                    todate = mm + '/' + dd + '/' + yy;
                }
            }
        }
//        if (status == "N") {
            var bran = "";
            dealprovision.Fetch(compcode, fdate, todate, deal, agency, client, pub, Filter, uid, dateformat,adtype,uom, call_data)
//        }
////        else if (status == "Y") {
//            var bran = "";
//            agencyunblock.exe(compcode, pcenter, savebranchcode, status, fdate, todate, nam1, nam2, suspendtype, uid, call_datas)
//        }
        //    document.getElementById('bntsub').disabled = true;
        return false;
    }
    var datafetch = ""
    function call_data(resd) {
        data1 = resd.value
        datafetch = resd.value
        var finaldata = "";
        if (data1.Tables[0].Rows.length > 0) {
            datalength = data1.Tables[0].Rows.length;


            finaldata = "<table border=1 width=100%>"
            finaldata += "<tr><td width='2%'bgcolor=#7DAAE3  style='font-size:12px;font-weight:bold;text-align:left;border:1px solid #7DAAE3;'><input id=Chk_all_box type=checkbox onclick=chkall_123('no') ></td>";
            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Booking ID</td>";
            finaldata += "<td width='24%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Client</td>";
            finaldata += "<td width='15%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agency</td>";
            finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Package Name</td>";
                    finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Color</td>";
            finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Deal</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Bill No</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Size</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trade Dis.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Page Prem.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Page Prem.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Page(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Pos. Prem.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Pos. Prem.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Pos.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trans. Chrg.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trans. Chrg.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Trans.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Rate</td>";
            finaldata += "<td width='9%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Provision Rate</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Remarks</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agreed Amount</td>";
finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Provision Amount<td></tr>";
//            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Client</td>";
//            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agency</td>";
//            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Insert ID</td></tr>";
          
            //finaldata+="</table>";

            for (i = 0; i < datalength; i++) {
            var provision=data1.Tables[0].Rows[i].BILL_RATE-data1.Tables[0].Rows[i].DEAL
            var creditnote=((parseFloat(data1.Tables[0].Rows[i].DEAL)*parseFloat(data1.Tables[0].Rows[i].TRADE_DISC))/100)
            creditnote=data1.Tables[0].Rows[i].DEAL-creditnote
            var  color_code="";
            if(data1.Tables[0].Rows[i].COLOR_CODE=="CO0")
            {
                color_code="Color"
            }
            else if(data1.Tables[0].Rows[i].COLOR_CODE=="B")
            {
               color_code="B/W"
            }
                // var Agency_name=get_agency_name(data.Tables[0].Rows[i].AGCD,data.Tables[0].Rows[i].DPCD)
                finaldata += "<tr><td><input type='CheckBox' width='2%' id='chkdel_" + i + "' ></td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].CIO_BOOKING_ID) + "</td><td width='24%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].CLIENT_NAME) + "</td><td width='15%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].AGENCY_NAME) + "(" + fndnull(data1.Tables[0].Rows[i].AG_CITY) + ")" + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].PACKAGE_NAME) + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + color_code + "</td><td width='6%' class='clickFieldinGrid'  onclick='javascript:return excutedeal(this.id);' id='dealcode_" + i + "'  align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].CONTRACT) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BILL_NO) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].SIZE_BOOK) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].TRADE_DISC) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].PREMIUM_CHARGES_NAME) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].PREM_PER) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'> <input type='text' class='txtboxforgridmim'    value='" + fndnull1(data1.Tables[0].Rows[i].SPECIAL_DISC_PER) + "' id='spldisperm_" + i + "' ></td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].POS_TYPE) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].PAGE_AMOUNT) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'> <input type='text' class='txtboxforgridmim'    value='" + fndnull1(data1.Tables[0].Rows[i].POSPREM_DISC) + "' id='spldisposition_" + i + "' ></td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].TRANSLATION_NAME) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].TRANSLATION_PREMIUM) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'> <input type='text' class='txtboxforgridmim'    value='" + fndnull1(data1.Tables[0].Rows[i].TRANSLATION_DISC) + "' id='spldistranslation_" + i + "' ></td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BILL_RATE) + "</td><td width='9%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'> <input type='text' class='txtboxforgridmim1' onkeydown='javascript:return chknum(event);'   value='" + provision + "' id='Provisonalrate_" + i + "' ></td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'> <input type='text' class='txtboxforgridmim'    value='" + fndnull1(data1.Tables[0].Rows[i].REMARKS) + "' id='Remarks_" + i + "' ></td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].CREDIT_NOTE_RATE) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + creditnote + "</td></tr>"//<td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BLOCK_REASON) + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].UNBLOCK_BY) + "</td><td width='15%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].SUSPEND_TYPE) + "</td><td><input type='CheckBox' width='25px' id='chkdel_" + i + "' ></td></tr>"
            }
            finaldata += "</table>";
            document.getElementById("result").innerHTML = finaldata;

             document.getElementById("btnsave").disabled = false; 
            //document.getElementById('btnMAIL').Visible = true;
            //document.getElementById('btnSMS').Visible = true;
        }
        else {
            alert("There is no data")
        clear1();
            return false;
        }
        return false;
    }
    function onloade() {
        document.getElementById("result").innerHTML = "";
        finaldata = "<table border=1 width=100%>"
             finaldata += "<tr><td width='2%'bgcolor=#7DAAE3  style='font-size:12px;font-weight:bold;text-align:left;border:1px solid #7DAAE3;'><input id=Chk_all_box type=checkbox onclick=chkall_123('no') ></td>";
            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Booking ID</td>";
            finaldata += "<td width='24%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Client</td>";
            finaldata += "<td width='15%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agency</td>";
            finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Package Name</td>";
                    finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Color</td>";
            finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Deal</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Bill No</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Size</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trade Dis.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Page Prem.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Page Prem.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Page(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Pos. Prem.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Pos. Prem.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Pos.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trans. Chrg.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trans. Chrg.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Trans.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Rate</td>";
            finaldata += "<td width='9%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Provision Rate</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Remarks</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agreed Amount</td>";
finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Provision Amount<td></tr>";
        finaldata += "</table>";
        document.getElementById("result").innerHTML = finaldata;
        document.getElementById('txtfromdate').value = "";
        document.getElementById('txttodate').value = "";
        document.getElementById('txtdeal').value = "";
        document.getElementById('hidenagencycode').value = "";
        document.getElementById('hdclientcode').value = "";
        document.getElementById('drpfilter').value = "D";
        document.getElementById('dppubcent').value = "0";
        document.getElementById('txtagency').value = "";
        document.getElementById('txtclient').value = "";
    }
    function clear1() {
        document.getElementById("result").innerHTML = "";
        finaldata = "<table border=1 width=100%>"
            finaldata += "<tr><td width='2%'bgcolor=#7DAAE3  style='font-size:12px;font-weight:bold;text-align:left;border:1px solid #7DAAE3;'><input id=Chk_all_box type=checkbox onclick=chkall_123('no') ></td>";
            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Booking ID</td>";
            finaldata += "<td width='24%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Client</td>";
            finaldata += "<td width='15%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agency</td>";
            finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Package Name</td>";
                    finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Color</td>";
            finaldata += "<td width='6%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Deal</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Bill No</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Size</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trade Dis.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Page Prem.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Page Prem.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Page(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Pos. Prem.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Pos. Prem.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Pos.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trans. Chrg.</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Trans. Chrg.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Discounted Trans.(%)</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Rate</td>";
            finaldata += "<td width='9%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Provision Rate</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Remarks</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agreed Amount</td>";
finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Provision Amount<td></tr>";
        finaldata += "</table>";
        document.getElementById("result").innerHTML = finaldata;
        document.getElementById('txtfromdate').value = "";
        document.getElementById('txttodate').value = "";
        document.getElementById('txtdeal').value = "";
        document.getElementById('hidenagencycode').value = "";
        document.getElementById('hdclientcode').value = "";
        document.getElementById("btnsave").disabled = true; 
        document.getElementById('drpfilter').value = "D";
        document.getElementById('dppubcent').value = "0";
         document.getElementById('drpuom').value = "0";
          document.getElementById('drpadtype').value = "0";
        document.getElementById('txtagency').value = "";
        document.getElementById('txtclient').value = "";
        return false;
    }
    function fndnull(myval) {
        if (myval == "undefined") {
            myval = "&nbsp";
        }
        else if (myval == null) {
            myval = "&nbsp";
        }
        else if (myval == "") {
            myval = "&nbsp";
        }
        return myval
    }
    
    function fndnull1(myval) {
        if (myval == "undefined") {
            myval = "";
        }
        else if (myval == null) {
            myval = "";
        }
        else if (myval == "") {
            myval = "";
        }
        return myval
    }
    function exit() {
        if (confirm("Do you want to skip this page ?")) {
            window.close();
            return false;
        }
        return false;
    }
    function chkall_123() {
        var dtlen = document.getElementById("result").childNodes[0].childNodes[0].children.length;
        if (dtlen > 1) {
            if (document.getElementById("Chk_all_box").checked == true) {
                for (i = 0; i < datalength; i++) {
                    document.getElementById("chkdel_" + i).checked = true;
                }
            }
            else {
                for (i = 0; i < datalength; i++) {
                    document.getElementById("chkdel_" + i).checked = false;
                }
            }
        }
        else {
            return false;
        }
    }
    function chknum(event) {

        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 46) || (event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 190)) {
            if (document.getElementById(document.activeElement.id).value.indexOf(".") >= 0) {
                if (event.keyCode == 190) {
                    alert("Input error");
                    document.getElementById(document.activeElement.id).value = "";
                    document.getElementById(document.activeElement.id).focus();
                    return false;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    }
    function saveclick() {
        var flag = "N";
        var agncomm_seq_com_vari = document.getElementById('agncomm_seq_com').value;
        var compcode = document.getElementById("hiddencompcode").value;
        var userid = document.getElementById("hiddenuserid").value;
        var bookingid;
        var insertid;
        var billrate;
        var agencycode;
        var clientcode;
        var traddiscount;
        var discrate;
        var billdate = "";
        var billamt =0;
        var reamarks="";
        var billno = "";
        var creditnoterate=0;
        var contractid;
        var totalsize;

        var grossTot = 0;
        var grossTotFinal = 0;
        var cancelAmount = 0;
        var cancelBillAmount = 0;
        var totarea_g = totalsize;
        var agrate_m = 0;
        var insertsta = "";
        var gross =0;
        var tranalpremtype ="";
        var tranalcharge = 0;
        var tranalchargediscount = 0;
        var trdisc = 0;
        var addcomm = 0;
        var trdisc1 =0;
        var tranlationcharge = 0;
        var Insertgrossamt = 0;
        var tranlationch = ""
        var Specialdiscount = 0;
        var Specialdiscountper = 0;
        var Spacediscount = 0;
        var Specialcharges = 0;
        var Packagecode = "";
        var Packagecodelength = 1;
        var disctype = "";
        var discount = 0;
        var discountper = 0;
        var spacediscper = 0;
        var premper = 0;
        var premiumchargestype = "";
        var gross1;
        var pageamount = 0;
        var paspremdisc = 0;
        var paspremdisctype = "";
        
        for (i = 0; i < datalength; i++) {
            if (document.getElementById("chkdel_" + i).checked == true) {
                flag = "Y"
                if (document.getElementById('Provisonalrate_' + i).value == "" || document.getElementById('Provisonalrate_' + i).value == null) {
                    alert("Please Enter Provisonal Rate");
                    document.getElementById('Provisonalrate_' + i).focus();
                    return false;
                }
                if (document.getElementById('Remarks_' + i).value == "" || document.getElementById('Remarks_' + i).value == null) {
                    alert("Please Enter Remarks");
                    document.getElementById('Remarks_' + i).focus();
                    return false;
                }
                pageamount = 0;
                paspremdisc = 0;
                paspremdisctype = "";
                gross1 = 0;
                bookingid = data1.Tables[0].Rows[i].CIO_BOOKING_ID;
                insertid = data1.Tables[0].Rows[i].INSERT_ID;
                billrate = data1.Tables[0].Rows[i].BILL_RATE;
                agencycode = data1.Tables[0].Rows[i].AGENCY_SUB_CODE;
                clientcode = data1.Tables[0].Rows[i].CLIENT_CODE;
                traddiscount = data1.Tables[0].Rows[i].TRADE_DISC;
                Specialdiscount = data1.Tables[0].Rows[i].SPECIAL_DISCOUNT;
                Specialdiscountper = data1.Tables[0].Rows[i].SPECIAL_DISC_PER; //dy
                if (Specialdiscountper != document.getElementById('spldisperm_' + i).value)
                    Specialdiscountper = document.getElementById('spldisperm_' + i).value;
                Spacediscount = data1.Tables[0].Rows[i].SPACE_DISCOUNT;
                Specialcharges = data1.Tables[0].Rows[i].SPECIAL_CHARGES;
                Packagecode = data1.Tables[0].Rows[i].PACKAGE_CODE;
                disctype = data1.Tables[0].Rows[i].DISC_TYPE;
                discount = data1.Tables[0].Rows[i].DISCOUNT;
                discountper = data1.Tables[0].Rows[i].DISCOUNT_PER;
                spacediscper = data1.Tables[0].Rows[i].SPACE_DISC_PER;
                premiumchargestype = data1.Tables[0].Rows[i].PREMIUM_CHARGES_TYPE;
                premper = data1.Tables[0].Rows[i].PREM_PER;
                pageamount = data1.Tables[0].Rows[i].PAGE_AMOUNT;
                paspremdisc = data1.Tables[0].Rows[i].POSPREM_DISC; //dy
                if (paspremdisc != document.getElementById('spldisposition_' + i).value)
                    paspremdisc = document.getElementById('spldisposition_' + i).value;
                paspremdisctype = data1.Tables[0].Rows[i].PREMIUM;
                Packagecodelength = 1;
                Packagecode = Packagecode.split(',');
                if (Packagecode.length > 1)
                    Packagecodelength = Packagecode.length;

                discrate = parseFloat(document.getElementById('Provisonalrate_' + i).value);

                if (disctype == "S") {
                    discrate = discrate + (discrate * parseFloat((parseFloat(premper) - parseFloat(Specialdiscountper)) / 100));
                }
                else if (premper != 0 && premper != null && premper != "") {
                    discrate = discrate + (discrate * parseFloat(premper / 100));
                }
                if (disctype != "S") {
                    if (Specialdiscountper != 0 && Specialdiscountper != null && Specialdiscountper != "") {
                        discrate = discrate + (discrate * parseFloat(Specialdiscountper / 100));
                    } 
                }
                if (discrate == null) {
                    discrate = "";
                }
                if (data1.Tables[0].Rows[i].BILL_DATE == null) {
                    billdate = "";
                }
                else {
                    billdate = date_fun(data1.Tables[0].Rows[i].BILL_DATE);
                } 
                billamt = data1.Tables[0].Rows[i].BILL_AMT;
                if (data1.Tables[0].Rows[i].BILL_NO == null) {
                    billno = "";
                }
                else {
                    billno = data1.Tables[0].Rows[i].BILL_NO;
                } 
                reamarks = document.getElementById('Remarks_' + i).value;
                creditnoterate = (discrate) * (data1.Tables[0].Rows[i].SIZE_BOOK) * (Packagecodelength);
                contractid = data1.Tables[0].Rows[i].CONTRACT;
                if (contractid == null) {
                    contractid = "";
                }
                //position calculation
                if (paspremdisctype != null && (pageamount != null && pageamount != "" && pageamount != "0")) {
                    gross1 = parseFloat(document.getElementById('Provisonalrate_' + i).value) * (data1.Tables[0].Rows[i].SIZE_BOOK) * (Packagecodelength);
                    if (pageamount != null && pageamount != "" && pageamount != "0") {
                        pageamount = parseInt(pageamount);
                    }
                    if (paspremdisc == null || paspremdisc == "" || paspremdisc == "0")
                        paspremdisc = 0;
                    pageamount = parseFloat(pageamount) - parseFloat(paspremdisc);
                    if (paspremdisctype == 'per') {
                        
                        pageamount = ((gross1) * parseFloat(pageamount)) / 100;
                    }
                    gross1 = pageamount;
                   
                }
                ////
                totalsize="";
                totalsize = data1.Tables[0].Rows[i].SIZE_BOOK;
                              

                 ////newbhanuchange
                grossTot = 0;
                grossTotFinal = 0;
                cancelAmount = 0;
                cancelBillAmount = 0;                                
                totarea_g = totalsize;
                agrate_m = parseFloat(discrate);
                insertsta =  data1.Tables[0].Rows[i].SIZE_BOOK;
                gross = parseFloat(totarea_g) * parseFloat(agrate_m) * (Packagecodelength);
                gross = gross + gross1;
                tranalpremtype = data1.Tables[0].Rows[i].TRANSLATION_TYPE;
                tranalcharge = data1.Tables[0].Rows[i].TRANSLATION_PREMIUM;
                tranalchargediscount = data1.Tables[0].Rows[i].TRANSLATION_DISC; //dy
                if (tranalchargediscount != document.getElementById('spldistranslation_' + i).value)
                    tranalchargediscount = document.getElementById('spldistranslation_' + i).value;
                
                if (data1.Tables[0].Rows[i].CHKTRADEDISC == "1") {
                    trdisc = data1.Tables[0].Rows[i].TRADE_DISC;
                    addcomm = data1.Tables[0].Rows[i].ADD_AGENCY_COMM;
                    if (trdisc == "" || trdisc == null)
                        trdisc = 0;
                    trdisc1 = trdisc;
                    //addcomm = 0;
                    if (addcomm != null) {
                        addcomm = addcomm;
                    }
                    if (addcomm == "") {
                        addcomm = "0";
                    }
                    if(data1.Tables[0].Rows[i].ADDITIONAL_FLAG!="1") {
                        addcomm = 0;
                    }
                    if (addcomm != "0") {
                        trdisc1 = parseInt(trdisc) + parseInt(addcomm);
                    }
                    var billval = 0;
                    if (document.getElementById('agncomm_seq_com').value != "S")
                        billval = parseFloat(gross) - (parseFloat(gross) * parseFloat(trdisc1) / 100);
                    else {
                        billval = parseFloat(gross) - (parseFloat(gross) * parseFloat(trdisc) / 100);
                        if (addcomm != "0" && addcomm != "" && addcomm != 0) {
                            billval = parseFloat(billval) - (parseFloat(billval) * parseFloat(addcomm) / 100);
                        }
                    }
                    creditnoterate = parseFloat(billamt) - parseFloat(billval);
                    creditnoterate =creditnoterate;
                }
                else {
                    creditnoterate = gross
                }
                ///more calculation
                ///// calculation of translationcharges
                if (tranalpremtype != null && (tranalcharge != null && tranalcharge != "" && tranalcharge != "0")) //for on translation charges
                {
                    tranlationcharge = 0;
                    Insertgrossamt = 0;
                    tranlationch="";
                    if (data1.Tables[0].Rows[i].INSERT_ID == 1) {
                        if (gross != "" && gross != null)
                            Insertgrossamt = parseFloat(gross);
                        }
                     if (tranalchargediscount == null)
                         tranalchargediscount = "";
                    if (tranalcharge != null)
                        var tranlationch = tranalcharge;
                    if(tranlationch!="" && tranalchargediscount!="")
                        tranlationch= parseFloat(tranlationch) - parseFloat(tranalchargediscount);
                    if (tranlationch != null && tranlationch != "" && tranlationch != "0") {
                        tranlationcharge = parseInt(tranlationch);
                    }
                    if (tranalpremtype == 'P') {
                        //tranlationcharge = (parseFloat(document.getElementById('txtbillamt').value) * parseFloat(tranlationcharge)) / 100;
                        tranlationcharge = ((Insertgrossamt) * parseFloat(tranlationcharge)) / 100;
                    }
                    creditnoterate = parseFloat(creditnoterate) + parseFloat(tranlationcharge);                    

                  }
                
                ////end more calculation
                creditnoterate = formatDecimal(creditnoterate, true, 2);
                //return false;
                if (traddiscount == null)
                    traddiscount = "";
                if (data1.Tables[0].Rows[i].ADDITIONAL_FLAG == null)
                    data1.Tables[0].Rows[i].ADDITIONAL_FLAG = "";
                if (data1.Tables[0].Rows[i].INSERT_STATUS == null)
                    data1.Tables[0].Rows[i].INSERT_STATUS = "";
                if (data1.Tables[0].Rows[i].DISC_RATE == null)
                    data1.Tables[0].Rows[i].DISC_RATE = "";
                if (addcomm == null)
                    addcomm = "";
                if (data1.Tables[0].Rows[i].CHKTRADEDISC == null)
                    data1.Tables[0].Rows[i].CHKTRADEDISC = "";
                if (data1.Tables[0].Rows[i].TRANSLATION_PREMIUM == null)
                    data1.Tables[0].Rows[i].TRANSLATION_PREMIUM = "";
                if (tranalchargediscount == null || tranalchargediscount == " ")
                    tranalchargediscount = "";
                if (data1.Tables[0].Rows[i].TRANSLATION_TYPE == null)
                    data1.Tables[0].Rows[i].TRANSLATION_TYPE = "";
                if (data1.Tables[0].Rows[i].SPECIAL_DISCOUNT == null)
                    data1.Tables[0].Rows[i].SPECIAL_DISCOUNT = "";
                if (data1.Tables[0].Rows[i].SPACE_DISCOUNT == null)
                    data1.Tables[0].Rows[i].SPACE_DISCOUNT = "";
                if (data1.Tables[0].Rows[i].SPECIAL_CHARGES == null)
                    data1.Tables[0].Rows[i].SPECIAL_CHARGES = "";
                if (data1.Tables[0].Rows[i].PACKAGE_CODE == null)
                    data1.Tables[0].Rows[i].PACKAGE_CODE = "";
                if (data1.Tables[0].Rows[i].DISC_TYPE == null)
                    data1.Tables[0].Rows[i].DISC_TYPE = "";
                if (data1.Tables[0].Rows[i].PREM_PER == null)
                    data1.Tables[0].Rows[i].PREM_PER = "";
                if (Specialdiscountper == null || Specialdiscountper == " ")
                    Specialdiscountper = "";
                if (data1.Tables[0].Rows[i].DISCOUNT == null)
                    data1.Tables[0].Rows[i].DISCOUNT = ""
                if (data1.Tables[0].Rows[i].DISCOUNT_PER == null)
                    data1.Tables[0].Rows[i].DISCOUNT_PER = "";
                if (data1.Tables[0].Rows[i].SPACE_DISC_PER == null)
                    data1.Tables[0].Rows[i].SPACE_DISC_PER = "";
                if (data1.Tables[0].Rows[i].PREMIUM_CHARGES_TYPE == null)
                    data1.Tables[0].Rows[i].PREMIUM_CHARGES_TYPE = "";
                if (data1.Tables[0].Rows[i].AG_CITY == null)
                    data1.Tables[0].Rows[i].AG_CITY = ""
                if (data1.Tables[0].Rows[i].AD_TYPE == null)
                    data1.Tables[0].Rows[i].AD_TYPE = "";
                if (data1.Tables[0].Rows[i].UOM_CODE == null)
                    data1.Tables[0].Rows[i].UOM_CODE = "";
                if (data1.Tables[0].Rows[i].TRANSLATION_CODE == null)
                    data1.Tables[0].Rows[i].TRANSLATION_CODE = "";
                if (data1.Tables[0].Rows[i].PAGE_PREM == null)
                    data1.Tables[0].Rows[i].PAGE_PREM = "";
                if (data1.Tables[0].Rows[i].PAGE_POSITION_CODE == null)
                    data1.Tables[0].Rows[i].PAGE_POSITION_CODE = "";
                if (data1.Tables[0].Rows[i].PAGE_AMOUNT == null)
                    data1.Tables[0].Rows[i].PAGE_AMOUNT = "";
                if (paspremdisc == null || paspremdisc == " ")
                    paspremdisc = "";
                if (data1.Tables[0].Rows[i].BKDATE == null)
                    data1.Tables[0].Rows[i].BKDATE = "";
                if (data1.Tables[0].Rows[i].COLOR_CODE == null)
                    data1.Tables[0].Rows[i].COLOR_CODE = "";
                /////bhanu
                if (document.getElementById('Provisonalrate_' + i).value != "" && document.getElementById('Provisonalrate_' + i).value != "0" && document.getElementById('Provisonalrate_' + i).value!=0)
                    var result = dealprovision.savedealprovision(compcode, agencycode, clientcode, contractid, billno, billdate, billamt, billrate, discrate, creditnoterate, totalsize, userid, insertid, reamarks, bookingid, traddiscount, data1.Tables[0].Rows[i].ADDITIONAL_FLAG, data1.Tables[0].Rows[i].INSERT_STATUS, data1.Tables[0].Rows[i].DISC_RATE, addcomm, data1.Tables[0].Rows[i].CHKTRADEDISC, data1.Tables[0].Rows[i].TRANSLATION_PREMIUM, tranalchargediscount, data1.Tables[0].Rows[i].TRANSLATION_TYPE, data1.Tables[0].Rows[i].SPECIAL_DISCOUNT, data1.Tables[0].Rows[i].SPACE_DISCOUNT, data1.Tables[0].Rows[i].SPECIAL_CHARGES, data1.Tables[0].Rows[i].PACKAGE_CODE, data1.Tables[0].Rows[i].DISC_TYPE, data1.Tables[0].Rows[i].PREM_PER, Specialdiscountper, data1.Tables[0].Rows[i].DISCOUNT, data1.Tables[0].Rows[i].DISCOUNT_PER, data1.Tables[0].Rows[i].SPACE_DISC_PER, data1.Tables[0].Rows[i].PREMIUM_CHARGES_TYPE, data1.Tables[0].Rows[i].AG_CITY, data1.Tables[0].Rows[i].AD_TYPE, data1.Tables[0].Rows[i].UOM_CODE, data1.Tables[0].Rows[i].TRANSLATION_CODE, data1.Tables[0].Rows[i].PAGE_PREM, data1.Tables[0].Rows[i].PAGE_POSITION_CODE, data1.Tables[0].Rows[i].PAGE_AMOUNT, paspremdisc, data1.Tables[0].Rows[i].BKDATE,data1.Tables[0].Rows[i].COLOR_CODE)
            }
        }
        if (flag == "N") {
            alert("Please Select  At Least One Checkbox .")
            return false;
        }     
        alert("Record Saved successfully.")
        return false;
    }
    function excutedeal(TDid) {
        var dealid=TDid.split("_");
        if (browser != "Microsoft Internet Explorer") {
            var deal = document.getElementById("dealcode_" + dealid[1]).textContent;
        }
        else {
            var deal = document.getElementById("dealcode_" + dealid[1]).innerText;
        }
        if (deal != " ") {
            win = window.open('ContractMaster.aspx?Deal=' + deal + '&userid=' + document.getElementById('hiddenuserid').value, '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');

        }
        else {
            return false;
        }
        return false;
    }
    function date_fun(str_date) {
        var final_date = str_date;
        if (final_date != "" && final_date != null) {
            var month = final_date.getMonth() + 1
            var day = final_date.getDate()
            var year = final_date.getFullYear()
            if (day.toString().length < 2)
                day = "0" + day
            if (month.toString().length < 2)
                month = "0" + month
            if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy")
                final_date = day + "/" + month + "/" + year;
            else if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy")
                final_date = month + "/" + day + "/" + year;
            else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd")
                final_date = year + "/" + month + "/" + day;
        }
        return final_date;
    }
    function formatDecimal(argvalue, addzero, decimaln) {
        var numOfDecimal = (decimaln == null) ? 2 : decimaln;
        var number = 1;

        number = Math.pow(10, numOfDecimal);

        argvalue = Math.round(parseFloat(argvalue) * number) / number;
        // If you're using IE3.x, you will get error with the following line.
        // argvalue = argvalue.toString();
        // It works fine in IE4.
        argvalue = "" + argvalue;

        if (argvalue.indexOf(".") == 0)
            argvalue = "0" + argvalue;

        if (addzero == true) {
            if (argvalue.indexOf(".") == -1)
                argvalue = argvalue + ".";

            while ((argvalue.indexOf(".") + 1) > (argvalue.length - numOfDecimal))
                argvalue = argvalue + "0";
        }

        return argvalue;
    }
    
    
    function binduomname()
{
    var comp_code=document.getElementById('hiddencompcode').value;
    var resuom=dealprovision.binduom(comp_code,document.getElementById('drpadtype').value);
    binduom_NEW(resuom);
}
function binduom_NEW(response)
{
    var ds=response.value;
    agcatby = document.getElementById("drpuom");
    agcatby.options.length = 1; 
    //    agcatby.options[0]=new Option("--Select Category--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var j=1;
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Uom_Name,ds.Tables[0].Rows[i].Uom_Code); 
           j++;
           
        }
    }
//document.getElementById("drprate").value = "0";
}