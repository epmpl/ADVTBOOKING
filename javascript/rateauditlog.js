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
            rateauditlogreport.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency').value.toUpperCase(), bindagencyname_callback);
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
            rateauditlogreport.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient').value.toUpperCase(), bindclientname_callback);

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
    
    function BindUom()
{
    var comp_code=document.getElementById('hiddencompcode').value;
    var resuom=rateauditlogreport.binduom(comp_code,document.getElementById('drpadtype').value);
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



 function bookingidF2(event) {
   
   if(event.keyCode==40)
   {if(document.getElementById("listbookingid").disabled!=true)   
   {
   document.getElementById("listbookingid").value = "0";
        document.getElementById("listbookingid").focus();  //unc
   return false;
   }
   }
   if(document.getElementById('txtbookingid').value !="")
   {
//            if (document.getElementById('txtbookingid').value.length <= 2) {
//                alert("Please Enter Minimum 3 Character For Searching.");
//                document.getElementById('txtclient').value = "";
//                return false;
//            }
            colName = "";
            document.getElementById("divbookingid").style.display = "block";
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
            document.getElementById('divbookingid').style.top = document.getElementById("txtagency").offsetTop + toppos + "px";
            document.getElementById('divbookingid').style.left = document.getElementById("txtagency").offsetLeft + leftpos + "px";
            rateauditlogreport.bindbookingid(document.getElementById('hiddencompcode').value, document.getElementById('txtbookingid').value.toUpperCase(), bindbookingid_callback);
             document.getElementById('txtagency').disabled=false;
   
   
    document.getElementById('txtagency').disabled=true;
    document.getElementById('txtclient').disabled=true;
    document.getElementById('txtfromdate').disabled=true;
    document.getElementById('txttodate').disabled=true;
    document.getElementById('drpadtype').disabled=true;
    document.getElementById('dppubcent').disabled=true;
    document.getElementById('drpbranch').disabled=true;
     document.getElementById('drpuom').disabled=true;
       
    document.getElementById('txtagency').value="";
    document.getElementById('txtclient').value="";
    document.getElementById('txtfromdate').value="";
    document.getElementById('txttodate').value="";
    document.getElementById('drpadtype').value="0";
    document.getElementById('dppubcent').value="0";
    document.getElementById('drpbranch').value="0";
     document.getElementById('drpuom').value="0";
   

}
else
{
 document.getElementById("divbookingid").style.display = "none";
  
     document.getElementById('txtagency').disabled=false; 
    document.getElementById('txtclient').disabled=false;
    document.getElementById('txtfromdate').disabled=false;
    document.getElementById('txttodate').disabled=false;
    document.getElementById('drpadtype').disabled=false;
    document.getElementById('dppubcent').disabled=false;
    document.getElementById('drpbranch').disabled=false;
     document.getElementById('drpuom').disabled=false;
     
}
        

    }


    function bindbookingid_callback(response) {
        ds = response.value;
        //document.getElementById('drpretainer').value="";
        var pkgitem = document.getElementById("listbookingid");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Booking ID-", "0");
        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            pkgitem.options.length = 1;
            //alert(pkgitem.options.length);
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].cio_booking_id , ds.Tables[0].Rows[i].cio_booking_id);
                pkgitem.options.length;
            }
        }

        document.getElementById("listbookingid").value = "0";
    
        return false;
    }
    
    
    
    function onclicbooking(event) {

        if (event.keyCode == 13 || event.type == "click") {




            if (document.activeElement.id == "listbookingid") {
                if (document.getElementById('listbookingid').value == "0")
                {
                    alert("Please select the Booking Id");
                    return false;
                }
                document.getElementById("divbookingid").style.display = "none";
                var datetime = "";
                //alert(document.getElementById('lstagency').value);

                //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

                var page = document.getElementById('listbookingid').value;
                // document.getElementById('hiddenagency').value=page;
                agencycodeglo = page;
                 for (var k = 0; k <= document.getElementById("listbookingid").length - 1; k++) {
                     if (document.getElementById('listbookingid').options[k].value == page) {
                         if (browser != "Microsoft Internet Explorer") {
                             var abc = document.getElementById('listbookingid').options[k].textContent;
                         }
                         else {
                             var abc = document.getElementById('listbookingid').options[k].innerText;
                         }

                         var split = abc.split("+");
                         var nameagen = split[0];
                         var agencycode = split[1];
//                         var agencycode = nameagen.split("(");
//                         agencycode = agencycode[1].replace(")", "");
                         document.getElementById('txtbookingid').value = nameagen;
//                         document.getElementById('hiddenagency').value = agenadd;
                         
                         document.getElementById('txtbookingid').focus();
                         return false;
                     }
                }
            }
        }

        if (event.keyCode == 27) {
            document.getElementById("divbookingid").style.display = "none";
            document.getElementById('txtbookingid').focus();
        }
    }
    
    function cleardata()
    {
    document.getElementById('txtbookingid').value="";
    document.getElementById('txtagency').value="";
    document.getElementById('txtclient').value="";
    document.getElementById('txtfromdate').value="";
    document.getElementById('txttodate').value="";
    document.getElementById('drpadtype').value="0";
    document.getElementById('dppubcent').value="0";
    document.getElementById('drpbranch').value="0";
     document.getElementById('drpuom').value="0";
     return false;
    }
    
     function exit() {
        if (confirm("Do you want to skip this page ?")) {
            window.close();
            return false;
        }
        return false;


    }