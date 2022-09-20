

function clearall() {
    document.getElementById('txtfrmdate').value = "";
    document.getElementById('txttodate1').value = "";
    document.getElementById('txtagency1').value = "";
    document.getElementById('txtciod').value = "";
    document.getElementById('update').disabled = true;

    return false;
}


function checkvalidation() {


    document.getElementById('update').disabled = false;


    if (document.getElementById('txtfrmdate').value == "") {

        alert("Please Select From Date")
        return false;
    }

    if (document.getElementById('txttodate1').value == "") {
        alert("Please Select To Date")
        return false;
    }



}


function update113(id) {


    var aa = document.getElementById('DataGrid1').rows.length


    var flag = false;
    
    for (var i = 0; i < aa - 1; i++) {

        if (document.getElementById('chk' + i).checked == true) {

            flag = true;
            var isertid = document.getElementById('chk' + i).value;
            var res = chngestatuspubltobook.update11(isertid);





        }



    }
    if (flag == false) {
        alert("Please select atleast one cheak box.");
        return false;
    }


    document.getElementById('btnsubmit').click();
    alert("Booking Booked Successfully");



    return false;
}
function selectAll() {

    if (document.getElementById("checkall").checked == true) {
        for (var k = 0; k < document.getElementById("DataGrid1").rows.length - 1; k++) {
            var chkid = "chk" + k;
            if (document.getElementById(chkid).disabled == false)
                document.getElementById(chkid).checked = true;
        }
    }
    else {
        for (var k = 0; k < document.getElementById("DataGrid1").rows.length - 1; k++) {
            var chkid = "chk" + k;
            document.getElementById(chkid).checked = false;
        }
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

            chngestatuspubltobook.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency1').value.toUpperCase(), bindagencyname_callback);

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
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name, ds.Tables[0].Rows[i].CITYNAME + '+' + ds.Tables[0].Rows[i].code_subcode);
            pkgitem.options.length;
        }
    }

    document.getElementById("lstagency").focus();

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
                    document.getElementById('txtagency1').value = abc;
                    //document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hdncode').value = page.split('+')[0];
                    document.getElementById('hdncodesubcode').value = page.split('+')[1];

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