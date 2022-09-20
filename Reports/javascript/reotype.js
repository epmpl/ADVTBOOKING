
var hiddentext;
var mod = "0";
var j = 0;
var z = 0;
var globaluser;
var browser = navigator.appName;
var glaobalschedule;
var listbox111 = new Array(9);
var listbox222 = new Array(9);

listbox111[0] = "Scheduling Head";
listbox111[1] = "Allow Block Agency";
listbox111[2] = "Allow Unblock Agency";
listbox111[3] = "Allow Changeing Insertion Fee";
listbox111[4] = "Allow Changeing Late Fee";
listbox111[5] = "Allow Changeing Incentives";
listbox111[6] = "Allow Unfinalize Supply Orders";
listbox111[7] = "Allow to mark bills undispute";
listbox111[8] = "Allow Unsold Cancellation Before Approval"
listbox111[9] = "Allow Unsold Cancellation After Approval"


function blankfield() {



    document.getElementById('dpuserid').disabled = true;
    document.getElementById('drprole').disabled = true;
    document.getElementById('dpuserid').value = "";
    document.getElementById('drpuserid').value = "";
    document.getElementById('txtfistnm').value = "";
    document.getElementById('txtlastnm').value = "";
    document.getElementById('dpagency').value = "";
    document.getElementById('dpd_branch').value = "0";
    document.getElementById('txtempcode').value = "";
    document.getElementById('txtcompanyname').value = "";
    document.getElementById('txtemailid').value = "";
    document.getElementById('txtdis').value = "";
    document.getElementById('txtbranchper').value = "";
    document.getElementById('drprole').value = "";
    document.getElementById('txtedit').value = "";
    document.getElementById('drpstatus').value = "0";
    document.getElementById('drpdes').value = "0";
    //document.getElementById('dpuserid').focus();
    return false;
}


function chkfields() 
{
var key = event.keyCode ? event.keyCode : event.which;

if(key=="13" ||key=="9")
{

    if (document.activeElement.id == "dpuserid" && ($('dpuserid').value == "" || $('dpuserid').value != ""))
     {
         $('drpuserid').focus();
         return false;
     }


     if (document.activeElement.id == "drpuserid" && ($('drpuserid').value == "" || $('drpuserid').value != "")) {
         $('txtfistnm').focus();
         return false;
     }

     if (document.activeElement.id == "txtfistnm" && ($('txtfistnm').value == "" || $('txtfistnm').value != "")) {
         $('txtlastnm').focus();
         return false;
     }

     if (document.activeElement.id == "txtlastnm" && ($('txtlastnm').value == "" || $('txtlastnm').value != "")) {
         $('dpagency').focus();
         return false;
     }

     if (document.activeElement.id == "dpagency" && ($('dpagency').value == "" || $('dpagency').value != "")) {
         $('dpd_branch').focus();
         return false;
     }

     if (document.activeElement.id == "dpd_branch" && ($('dpd_branch').value == "" || $('dpd_branch').value != "")) {
         $('txtempcode').focus();
         return false;
     }

     if (document.activeElement.id == "txtempcode" && ($('txtempcode').value == "" || $('txtempcode').value != "")) {
         $('txtcompanyname').focus();
         return false;
     }

     if (document.activeElement.id == "txtcompanyname" && ($('txtcompanyname').value == "" || $('txtcompanyname').value != "")) {
         $('txtemailid').focus();
         return false;
     }

     if (document.activeElement.id == "txtemailid" && ($('txtemailid').value == "" || $('txtemailid').value != "")) {
         $('txtdis').focus();
         return false;
     }

     if (document.activeElement.id == "txtdis" && ($('txtdis').value == "" || $('txtdis').value != "")) {
         $('txtbranchper').focus();
         return false;
     }

     if (document.activeElement.id == "txtbranchper" && ($('txtbranchper').value == "" || $('txtbranchper').value != "")) {
         $('txtedit').focus();
         return false;
     }

     if (document.activeElement.id == "drprole" && ($('drprole').value == "" || $('drprole').value != "")) {
         $('txtedit').focus();
         return false;
     }

     if (document.activeElement.id == "txtedit" && ($('txtedit').value == "" || $('txtedit').value != "")) {
         $('drpstatus').focus();
         return false;
     }

     if (document.activeElement.id == "drpstatus" && ($('drpstatus').value == "" || $('drpstatus').value != "")) {
         $('drpdes').focus();
         return false;
     }

     if (document.activeElement.id == "drpdes" && ($('drpdes').value == "" || $('drpdes').value != "")) {
         $('BtnRun').focus();
         return false;
     }

     

     if (document.activeElement.id == "BtnRun") 
     {

         checkrundatenetamt();
         //$('BtnRun').focus();
         return false;
     }
   
    
}

}


function binduser(event) {
   
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 27) {
        if (document.activeElement.id == "lst_user") {
            document.getElementById('div1').style.display = "none";
            return false;
        }
    }
    //    if (key == 13) {
    //        if (document.activeElement.id == "lstmaingrp") {
    //            fillmaingrp(event);
    //        }

    //    }
    if ((key == 8) || (key == 46)) {
       // document.getElementById('txtrole').value = "";
       // document.getElementById('usercode').value = "";
        document.getElementById('drpuserid').value = "";
        document.getElementById('dpuserid').value = "";
        document.getElementById('drprole').value = "";
    }

    if (key == 113) {
        var compcode = document.getElementById('hiddencompcode').value;
        var userid = document.getElementById('hiddenuseid').value;
        var userhome = document.getElementById('hiddenuserhome').value;
        var revenue = document.getElementById('hiddenrevenue').value;
        var admin = document.getElementById('hiddenadmin').value;

        document.getElementById("div1").style.display = "block";
        document.getElementById('div1').style.top = findPos(document.getElementById("drpuserid"), "top");
        document.getElementById('div1').style.left = findPos(document.getElementById("drpuserid"), "left");
        document.getElementById('lst_user').value = "0";
        document.getElementById('lst_user').focus();

        var res = Reports_reotype.UserBind(compcode, userid, userhome, revenue, admin);
        var ds = res.value;
        if (ds != null && ds.Tables[0].Rows.length > 0) {
            var pkgitem = document.getElementById("lst_user");
            pkgitem.options.length = 0;
            pkgitem.options[0] = new Option("-Select user-", "0");
            pkgitem.options.length = 1;
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username + "--" + ds.Tables[0].Rows[i].userid + "--" + fndnull(ds.Tables[0].Rows[i].ROLE_NAME)+ "--" + fndnull(ds.Tables[0].Rows[i].ROLE_CODE), ds.Tables[0].Rows[i].userid);
                pkgitem.options.length;
            }
        }
        //  }
    }
    //return false;
}



function fndnull(myval) {
    if (myval == "undefined") {
        myval = "";
    }
    else if (myval == null) {
        myval = "";
    }
    return myval
}

function findPos(obj, val) {
    var curleft = curtop = 0;

    if (obj.offsetParent) {
        curleft = obj.offsetLeft

        curtop = obj.offsetTop

        while (obj = obj.offsetParent) {
            curleft += obj.offsetLeft

            curtop += obj.offsetTop

        }

    }
    curtop = curtop += 5;
    if (val == "top")
        return curtop + "px";
    else
        return curleft + "px";
}


function filluser(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (document.activeElement.id == "lst_user") {
            if (document.getElementById('lst_user').value == "0") {
                alert("Please select user");
                return false;
            }
            document.getElementById("div1").style.display = "none";
            var page = document.getElementById('lst_user').value;
            loccode = page;

            for (var k = 0; k <= document.getElementById("lst_user").length - 1; k++) {
                if (document.getElementById('lst_user').options[k].value == page) {
                    if (browser == "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lst_user').options[k].innerText;
                    }
                    else {
                        var abc = document.getElementById('lst_user').options[k].textContent;
                    }
                    var fival = abc.split("--");
                   // document.getElementById('usercode').value = fival[1];
                    document.getElementById('drpuserid').value = fival[0];
                   // document.getElementById('txtrole').value = fival[2];
                    // document.getElementById('txtrole').disabled = true;
                    document.getElementById('dpuserid').value = fival[1];
                    document.getElementById('drprole').value = fival[2];
                    document.getElementById('hdn_rolecode').value = fival[3];
                    document.getElementById('drpuserid').focus();
                    break;
                }
            }
        }
    }

    else if (keycode == 27) {

    document.getElementById("div1").style.display = "none";
    document.getElementById('drpuserid').focus();
    }

}



function tabvalue1(event, id) {
    if (document.activeElement.id == "cmdAddRow" || document.activeElement.id == "cmdAddRowelec" || document.activeElement.id == "drpdealon" || document.activeElement.id == "btnExit" || document.activeElement.id == "btnDelete" || document.activeElement.id == "btnlast" || document.activeElement.id == "btnnext" || document.activeElement.id == "btnprevious" || document.activeElement.id == "btnCancel" || document.activeElement.id == "btnExecute" || document.activeElement.id == "btnQuery" || document.activeElement.id == "btnModify" || document.activeElement.id == "btnNew" || document.activeElement.id == "btnSave" || document.activeElement.id == "drpindustry" || document.activeElement.id == "lstproduct" || document.activeElement.id == "txtseq" || document.activeElement.id == "chkpatricularad" || document.activeElement.id == "chkseqno" || document.activeElement.id == "chkmultiad" || document.activeElement.id == "chkb2b" || document.activeElement.id == "txtremark" || document.activeElement.id == "drppaymenttype" || document.activeElement.id == "drpservicetax" || document.activeElement.id == "txtdealvol" || document.activeElement.id == "txtdealvalue" || document.activeElement.id == "txtclosedate" || document.activeElement.id == "txtcontractdate" || document.activeElement.id == "lstretainer" || document.activeElement.id == "lstexec" || document.activeElement.id == "lstclient" || document.activeElement.id == "lstagency" || document.activeElement.id == "txtcaption" || document.activeElement.id == "txtfromdate" || document.activeElement.id == "TextBox1" || document.activeElement.id == "drpteamname" || document.activeElement.id == "drprepresentative" || document.activeElement.id == "txtexecutive" || document.activeElement.id == "txtretainer" || document.activeElement.id == "drpproduct" || document.activeElement.id == "drpclientname" || document.activeElement.id == "drpsubagcode" || document.activeElement.id == "drpagencycode" || document.activeElement.id == "drpcurr" || document.activeElement.id == "txtdealname" || document.activeElement.id == "drpdealtype") {
        colName = "";
    }


    if (browser != "Microsoft Internet Explorer") {
        if (event.which == 113) {
            if (document.activeElement.id == "drpagencycode") {
                if (document.getElementById('drpagencycode').value.length <= 2) {
                    alert("Please Enter Minimum 3 Character For Searching.");
                    document.getElementById('drpagencycode').value = "";
                    return false;
                }
                colName = "";
                document.getElementById("divagency").style.display = "block";
                aTag = eval(document.getElementById("drpagencycode"))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById('divagency').style.top = document.getElementById("drpagencycode").offsetTop + toppos + "px";
                document.getElementById('divagency').style.left = document.getElementById("drpagencycode").offsetLeft + leftpos + "px";
                Reports_reotype.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('drpagencycode').value.toUpperCase(), bindagencyname_callback);

            }

            else if (document.activeElement.id == "drpclientname") {
                if (document.getElementById('drpclientname').value.length <= 2) {
                    alert("Please Enter Minimum 3 Character For Searching.");
                    document.getElementById('drpclientname').value = "";
                    return false;
                }
                colName = "";
                document.getElementById("divclient").style.display = "block";
                aTag = eval(document.getElementById("drpclientname"))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById('divclient').style.top = document.getElementById("drpclientname").offsetTop + toppos + "px";
                document.getElementById('divclient').style.left = document.getElementById("drpclientname").offsetLeft + leftpos + "px";
                Reports_reotype.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('drpclientname').value.toUpperCase(), bindclientname_callback);
            }

            else if (document.activeElement.id == "txtde") {
                //            if(document.getElementById('txtde').value.length <=2)
                //            {
                //            alert("Please Enter Minimum 3 Character For Searching.");
                //            document.getElementById('txtde').value="";
                //            return false;
                //            }
                colName = "";
                document.getElementById("divdeal").style.display = "block";
                aTag = eval(document.getElementById("txtde"))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById('divdeal').style.top = document.getElementById("txtde").offsetTop + toppos + "px";
                document.getElementById('divdeal').style.left = document.getElementById("txtde").offsetLeft + leftpos + "px";
                var mod = document.getElementById('drpad').value;
                Reports_reotype.binddealno(document.getElementById('hiddencompcode').value, document.getElementById('txtde').value.toUpperCase(), mod, binddealno_callback);
            }

        }

        if (event.which == 27) {
            if (document.getElementById("divcommon") != null && document.getElementById("divcommon").style.display == "block") {
                document.getElementById("divcommon").style.display = "none";
                try {
                    document.getElementById(activeIDNo).focus();
                }
                catch (err)
         { }
                activeIDNo = "";
            }


            else if (document.getElementById("div1") != null && document.getElementById("div1").style.display == "block") {
                document.getElementById("div1").style.display = "none"
                document.getElementById('drpagencycode').focus();
            }
            else if (document.getElementById("divclient") != null && document.getElementById("divclient").style.display == "block") {
                document.getElementById("divclient").style.display = "none"
                document.getElementById('drpclientname').focus();
            }
            else if (document.getElementById("divdeal") != null && document.getElementById("divdeal").style.display == "block") {
                document.getElementById("divdeal").style.display = "none"
                document.getElementById('txtde').focus();
            }
            else {
                return false;
            }


        }



        if (event.which == 13 || event.type == "click") {
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
                var value = "0";

                var res = Reports_reotype.addclientname(page, datetime, value);
                var id = res.value;
                var split = id.split("+");
                var nameagen = split[0];
                var agenadd = split[1];

                document.getElementById('drpagencycode').value = nameagen;
                agency_change();
                document.getElementById('drpagencycode').focus();
                return false;
            }
            else if (document.activeElement.id == "lstclient") {
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


                document.getElementById('drpclientname').value = namecode;
                //              
                //                 clientChange();
                /* if(document.getElementById('hiddensavemod').value=="0")
                {
                document.getElementById('txtclientadd').value=add;        
                document.getElementById('txtclientadd').focus();
                }
                bind_agen_bill();*/
                document.getElementById('drpclientname').focus();

                return false;
            }
            if (document.activeElement.id == "lstdeal") {
                if (document.getElementById('lstdeal').value == "0")// || document.getElementById('hiddensavemod').value=="01")
                {
                    alert("Please select the agency code");
                    return false;
                }
                document.getElementById("divdeal").style.display = "none";
                var datetime = "";
                //alert(document.getElementById('lstagency').value);

                //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

                var page = document.getElementById('lstdeal').value;
                // document.getElementById('hiddenagency').value=page;
                //                agencycodeglo=page;
                //                 var value="0";

                //                var res=Reports_reotype.addclientname(page,datetime,value);
                //                 var id=res.value;
                //                 var split=id.split("+");
                //                 var nameagen=split[0];
                //                 var agenadd=split[1];
                //                        
                document.getElementById('txtde').value = page;
                deal_change();
                document.getElementById('txtde').focus();
                return false;
            }


        }


    }

    else {
        if (event.keyCode == 113) {
            if (document.activeElement.id == "drpagencycode") {
                if (document.getElementById('drpagencycode').value.length <= 2) {
                    alert("Please Enter Minimum 3 Character For Searching.");
                    document.getElementById('drpagencycode').value = "";
                    return false;
                }
                colName = "";
                document.getElementById("div1").style.display = "block";
                aTag = eval(document.getElementById("drpagencycode"))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById('div1').style.top = document.getElementById("drpagencycode").offsetTop + toppos + "px";
                document.getElementById('div1').style.left = document.getElementById("drpagencycode").offsetLeft + leftpos + "px";
                Reports_reotype.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('drpagencycode').value.toUpperCase(), bindagencyname_callback);

            }
            else if (document.activeElement.id == "drpclientname") {
                if (document.getElementById('drpclientname').value.length <= 2) {
                    alert("Please Enter Minimum 3 Character For Searching.");
                    document.getElementById('drpclientname').value = "";
                    return false;
                }
                colName = "";
                document.getElementById("divclient").style.display = "block";
                aTag = eval(document.getElementById("drpclientname"))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById('divclient').style.top = document.getElementById("drpclientname").offsetTop + toppos + "px";
                document.getElementById('divclient').style.left = document.getElementById("drpclientname").offsetLeft + leftpos + "px";
                Reports_reotype.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('drpclientname').value.toUpperCase(), bindclientname_callback);
            }


            else if (document.activeElement.id == "txtde") {
                //            if(document.getElementById('txtde').value.length <=2)
                //            {
                //            alert("Please Enter Minimum 3 Character For Searching.");
                //            document.getElementById('txtde').value="";
                //            return false;
                //            }
                colName = "";
                document.getElementById("divdeal").style.display = "block";
                aTag = eval(document.getElementById("txtde"))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById('divdeal').style.top = document.getElementById("txtde").offsetTop + toppos + "px";
                document.getElementById('divdeal').style.left = document.getElementById("txtde").offsetLeft + leftpos + "px";
                var mod = document.getElementById('drpad').value;
                Reports_reotype.binddealno(document.getElementById('hiddencompcode').value, document.getElementById('txtde').value.toUpperCase(), mod, binddealno_callback);
            }

        } if (event.keyCode == 27) {
            if (document.getElementById("divcommon") != null && document.getElementById("divcommon").style.display == "block") {
                document.getElementById("divcommon").style.display = "none";
                try {
                    document.getElementById(activeIDNo).focus();
                }
                catch (err)
         { }
                activeIDNo = "";
            }


            else if (document.getElementById("div1") != null && document.getElementById("div1").style.display == "block") {
                document.getElementById("div1").style.display = "none"
                document.getElementById('drpagencycode').focus();
            }
            else if (document.getElementById("divclient") != null && document.getElementById("divclient").style.display == "block") {
                document.getElementById("divclient").style.display = "none"
                document.getElementById('drpclientname').focus();
            }

            else if (document.getElementById("divdeal") != null && document.getElementById("divdeal").style.display == "block") {
                document.getElementById("divdeal").style.display = "none"
                document.getElementById('txtde').focus();
            }
            else {
                return false;
            }


        }
        if (event.keyCode == 13) {
            if (document.activeElement.id == "drpad") {
                document.getElementById("davf").focus();
                return false;
            }

            if (document.activeElement.id == "davf") {
                document.getElementById("davt").focus();
                return false;
            }
            if (document.activeElement.id == "davt") {
                document.getElementById("txtde").focus();
                return false;
            }
            if (document.activeElement.id == "txtde") {
                document.getElementById("drpagencycode").focus();
                return false;
            }
            if (document.activeElement.id == "drpagencycode") {
                document.getElementById("drpclientname").focus();
                return false;
            }
            if (document.activeElement.id == "drpclientname") {
                document.getElementById("drpat").focus();
                return false;
            }
            if (document.activeElement.id == "drpat") {
                document.getElementById("txtremark").focus();
                return false;
            }
            if (document.activeElement.id == "txtremark") {
                document.getElementById("btnsubmit").focus();
                return false;
            }

        }
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
                var value = "0";

                var res = Reports_reotype.addclientname(page, datetime, value);
                var id = res.value;
                var split = id.split("+");
                var nameagen = split[0];
                var agenadd = split[1];

                document.getElementById('drpagencycode').value = nameagen;
                document.getElementById('hiddenagency').value = agenadd;
                agency_change();
                document.getElementById('drpagencycode').focus();
                return false;
            }
            else if (document.activeElement.id == "lstclient") {
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


                document.getElementById('drpclientname').value = namecode;

                //                 clientChange();
                /* if(document.getElementById('hiddensavemod').value=="0")
                {
                document.getElementById('txtclientadd').value=add;        
                document.getElementById('txtclientadd').focus();
                }
                bind_agen_bill();*/
                document.getElementById('drpclientname').focus();

                return false;
            }
            if (document.activeElement.id == "lstdeal") {
                if (document.getElementById('lstdeal').value == "0")// || document.getElementById('hiddensavemod').value=="01")
                {
                    alert("Please select the Deal No ");
                    return false;
                }
                document.getElementById("divdeal").style.display = "none";
                var datetime = "";
                //alert(document.getElementById('lstagency').value);

                //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

                var page = document.getElementById('lstdeal').value;
                // document.getElementById('hiddenagency').value=page;
                //                agencycodeglo=page;
                //                 var value="0";

                //                var res=Reports_reotype.addclientname(page,datetime,value);
                //                 var id=page.value;
                //                 var split=id.split("+");
                //                 var nameagen=split[0];
                //                 var agenadd=split[1];
                //                        
                document.getElementById('txtde').value = page;
                //                agency_change();
                document.getElementById('txtde').focus();
                return false;
            }


        }


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
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name + '+' + ds.Tables[0].Rows[i].CITYNAME, ds.Tables[0].Rows[i].code_subcode);
            pkgitem.options.length;
        }
    }
    document.getElementById('drpagencycode').value = "";
    document.getElementById("lstagency").value = "0";
    //document.getElementById("lstagency").focus();
    return false;
}






function F2fillagencycr_dev(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {

        if (document.activeElement.id == "dpagency") {

            activeid = document.activeElement.id;
            document.getElementById("divagency").style.display = "block";
            var divid = "divagency";
            var listboxid = "lstagency";
            $('lstagency').value = "";


            document.getElementById('lstagency').value = "";
            var compcode = document.getElementById('hiddencompcode').value;
            var agn = document.getElementById('dpagency').value.toUpperCase();

            document.getElementById('lstagency').focus();
            var ds = Reports_reotype.fillF2_CreditAgency(compcode, agn);

           
            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.style.width = "350px"
            objadscat.options[0] = new Option("-Select Main Group-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {

                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Agency_Name, ds.value.Tables[0].Rows[i].Agency_Code);
                objadscat.options.length;
            }


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
            var tot = document.getElementById('divagency').scrollLeft;
            var scrolltop = document.getElementById('divagency').scrollTop;
            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            //document.getElementById(activeid).style.backgroundColor="#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();





        }


    }


}


function bindAgency_callbackbb(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name, ds_AccName.Tables[0].Rows[i].Agency_Code);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstagency").value = "0";
    document.getElementById("divagency").value = "";
    document.getElementById('lstagency').focus();

    return false;

}


function ClickAgaencybb(event) {
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
                    if (browser != "Microsoft Internet Explorer")
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    else
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    document.getElementById('dpagency').value = abc;
                    document.getElementById('hdnagencytxt').value = abc;
                    document.getElementById('hdnagency1').value = page;

                    document.getElementById("divagency").style.display = "none";
                    document.getElementById('dpagency').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

    document.getElementById("divagency").style.display = "none";
        document.getElementById('dpagency').focus();
    }
   
}
  
  




function checkrundatenetamt() 
{

    var userid = document.getElementById('dpuserid').value;
    var usename = document.getElementById('drpuserid').value;
    var firstnm = document.getElementById('txtfistnm').value;
    var lastnm = document.getElementById('txtlastnm').value;
    var agencycode = document.getElementById('dpagency').value;
    var branchnm = document.getElementById('dpd_branch').value;
    var empcode = document.getElementById('txtempcode').value;
    var companyname = document.getElementById('txtcompanyname').value;
    var email = document.getElementById('txtemailid').value;
    var discount = document.getElementById('txtdis').value;
    var branhper = document.getElementById('txtbranchper').value;
    //var role = document.getElementById('drprole').value;
    var role = document.getElementById('hdn_rolecode').value;
    var edit = document.getElementById('txtedit').value;
    //var status = document.getElementById('drpstatus').value;
    var status = document.getElementById('drpstatus').value;
    if (status == "1") 
    {
        status = "";
    
    }
    var desination = document.getElementById('drpdes').value;

    window.open("reotype_view.aspx?userid=" + userid + "&usename=" + usename + "&firstnm=" + firstnm + "&lastnm=" + lastnm + "&agencycode=" + agencycode + "&branchnm=" + branchnm + "&empcode=" + empcode + "&companyname=" + companyname + "&email=" + email + "&discount=" + discount + "&branhper=" + branhper + "&role=" + role + "&edit=" + edit + "&status=" + status + "&desination=" + desination, '');

   
   // window.open("reotype_view.aspx?fromdate=" + $('txtfrmdate').value + "&dateto=" + $('txttodate1').value + "&publication=" + $('dppub1').value + "&pubcenter=" + $('pubcent').value + "&edition=" + $('dpedition').value + "&client=" + $('dpclient').value + "&agency=" + $('dpagency').value + "&branch=" + $('dpbranch').value + "&destination=" + $('Txtdest').value);


}


function email(id) 
{
    if (id.id == "txtemailid")
        var email = $('txtemailid').value;
    if (id.id == "txtemail1")
        email = $('txtemail1').value;
    var at = "@";
    var res = Reports_reotype.call_email(email, at);
    if (res.value != null) {
        if (res.value.Tables[0].Rows[0]["MESSAGE"] == "FALSE") {
            alert("Please Enter Valid Email");
            $('txtemailid').value = "";
            if (id.id == "txtmob")
                $('txtemailid').focus();
            if (id.id == "txtemail1")
                $('txtemail1').focus();
            return false;
        }

        else {
//            if (id.id == "txtmob")
//                $('txtcomments').focus();
//            if (id.id == "txtemail1")
//                $('btnSave').focus();
            return false;
        }
    }
    return false;
}


function isInteger(s) {
    var i;
    for (i = 0; i < s.length; i++) {
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) 
        return false;
    }
    // All characters are numbers.
    return true;
}
function checknos(event) {
    //alert("checknos");
    var key = event.keyCode ? event.keyCode : event.which;

    if ((key >= 48 && key <= 59) || (key == 127) || (key == 8) || (key == 9) || (key == 46) || (key == 13)) {
        return true;
    }
    else {

        alert('Please Enter Number only.')
        key = 0;
        return false;
    }

}  