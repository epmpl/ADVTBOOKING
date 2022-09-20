var divid = "";
var listboxid = "";
var txtboxid = "";
var txtbxid = "";
var browser = navigator.appName;
function bind_summary() {
    var module = document.getElementById('hdnmoduleid').value;
    var status = document.getElementById('dpdtatus').value;
    var userid = document.getElementById('hdnuserid').value;
   
    var creationdtfrom = document.getElementById('txtfrmdate').value;
    var alrt;
    alrt = document.getElementById('lblcreationdtfrom').innerText;

    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txtfrmdate').value == "") {
            //alrt.Replace("*","");
            var fromdate = alrt.replace("*", "");
            alert('Please Enter Creation From Date ');
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    }
    var creationtodate = document.getElementById('txtcreationtodt').value;
    alrt = document.getElementById('lblcreationdtfrom').innerText;

    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txtcreationtodt').value == "") {
            //alrt.Replace("*","");
            var todate = alrt.replace("*", "");
            alert('Please Enter Creation To Date  ' + creationtodate);
            document.getElementById('txtcreationtodt').focus();
            return false;
        }
    }
    var lastuseddtfrm = document.getElementById('txtuseddtfrom').value;
    alrt = document.getElementById('lbllastuseddtform').innerText;

    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txtuseddtfrom').value == "") {
            //alrt.Replace("*","");
            var todate = alrt.replace("*", "");
            alert('Please Enter Last Used From Date ' + lastuseddtfrm);
            document.getElementById('txtuseddtfrom').focus();
            return false;
        }
    }
    var lastusedtodt = document.getElementById('txtusedtodt').value;
    alrt = document.getElementById('lbllastusedtodt').innerText;

    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txtusedtodt').value == "") {
            //alrt.Replace("*","");
            var todate = alrt.replace("*", "");
            alert('Please Enter Last Used To Date ' + lastusedtodt);
            document.getElementById('txtusedtodt').focus();
            return false;
        }
    }
    var destination = document.getElementById('dpdest').value;
    
    window.open("detail_table.aspx?&module=" + module + "&status=" + status + "&userid=" + userid + "&creation_date_from=" + creationdtfrom + "&creation_to_date=" + creationtodate + "&last_used_date_from=" + lastuseddtfrm + "&last_used_to_date=" + lastusedtodt + "&destination=" + destination);
    return false;
}

function bind_exit() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
        return false;
    }
    return false;
}
function bind_clear()
{
    document.getElementById('txtmodule').value = "";
    document.getElementById('dpdtatus').value = "A";
    document.getElementById('txtuserid').value = "";
    document.getElementById('txtfrmdate').value == "";
    document.getElementById('txtcreationtodt').value == "";
    document.getElementById('txtuseddtfrom').value == "";
    document.getElementById('txtusedtodt').value == "";
    document.getElementById('dpdest').value = "";
}

//------------------------------------------------------------------Function For User Name ---------------------------------------------------------------------


function FillUserId(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtuserid") {
            document.getElementById('lstuser').value = "";
            document.getElementById('divuser').style.display = "block";
            document.getElementById('divuser').style.width = '50px';
            document.getElementById('divuser').style.top = 80 + "px";
            document.getElementById('divuser').style.left = 550 + "px";
            aTag = eval(document.getElementById('txtuserid'))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = document.getElementById('divuser').scrollLeft;
            var scrolltop = document.getElementById('divuser').scrollTop;
            document.getElementById('divuser').style.left = document.getElementById('txtuserid').offsetLeft + leftpos - tot + "px";
            document.getElementById('divuser').style.top = document.getElementById('txtuserid').offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById('divuser').style.display = "block";
            document.getElementById('lstuser').focus();
            extra1 = document.getElementById('txtuserid').value.toUpperCase();
            get_user_detail.fill_user(extra1, BindUserIdCallBack)
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
        document.getElementById('txtuserid').value = "";
        return true;
    }
    else if (event.ctrlKey == true && event.keyCode == 88) {
        document.getElementById('txtuserid').value = "";
        return true;
    }
    else if (event.keyCode == 27) {
        document.getElementById("divuser").style.display = "none";

    }
}

function BindUserIdCallBack(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstuser");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select User-", "0");
        pkgitem.options.length = 1;
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username + "-" + ds.Tables[0].Rows[i].userid, ds.Tables[0].Rows[i].userid);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstuser").value = "0";
    document.getElementById("txtuserid").value = "";
    document.getElementById("lstuser").focus();
    return false;
}

function onclickuser(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstuser") {
            if (document.getElementById('lstuser').value == "0") {
                return false;
            }
            document.getElementById("divuser").style.display = "none";
            var page = document.getElementById('lstuser').value;
            for (var k = 0; k <= document.getElementById("lstuser").length - 1; k++) {
                if (document.getElementById('lstuser').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstuser').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstuser').options[k].innerText;
                    }
                    abc = abc.split('-');

                    document.getElementById('txtuserid').value = abc[0];
                    document.getElementById('hdnuserid').value = abc[1];
                    document.getElementById('txtuserid').focus();
                    return false;
                }
            }
        }
    }
    else if (event.keyCode == 27) {
        document.getElementById("divuser").style.display = "none";
    }
}



function FillModule(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtmodule") {
            document.getElementById('lstmodule').value = "";
            document.getElementById('div1').style.display = "block";
            document.getElementById('div1').style.width = '50px';
            document.getElementById('div1').style.top = 80 + "px";
            document.getElementById('div1').style.left = 550 + "px";
            aTag = eval(document.getElementById('txtmodule'))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = document.getElementById('div1').scrollLeft;
            var scrolltop = document.getElementById('div1').scrollTop;
            document.getElementById('div1').style.left = document.getElementById('txtmodule').offsetLeft + leftpos - tot + "px";
            document.getElementById('div1').style.top = document.getElementById('txtmodule').offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById('div1').style.display = "block";
            document.getElementById('lstmodule').focus();
            extra1 = document.getElementById('txtmodule').value.toUpperCase();
            get_user_detail.get_module(extra1, BindModuleCallBack)
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
        document.getElementById('txtmodule').value = "";
        return true;
    }
    else if (event.ctrlKey == true && event.keyCode == 88) {
        document.getElementById('txtmodule').value = "";
        return true;
    }
    else if (event.keyCode == 27) {
        document.getElementById("div1").style.display = "none";

    }
}

function BindModuleCallBack(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstmodule");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Module-", "0");
        pkgitem.options.length = 1;
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].MODULE_NAME + "-" + ds.Tables[0].Rows[i].MODULE_ID, ds.Tables[0].Rows[i].MODULE_ID);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstmodule").value = "0";
    document.getElementById("txtmodule").value = "";
    document.getElementById("lstmodule").focus();
    return false;
    
  

}
function onclickmodule(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstmodule") {
            if (document.getElementById('lstmodule').value == "0") {
                return false;
            }
            document.getElementById("div1").style.display = "none";
            var page = document.getElementById('lstmodule').value;
            for (var k = 0; k <= document.getElementById("lstmodule").length - 1; k++) {
                if (document.getElementById('lstmodule').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstmodule').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstmodule').options[k].innerText;
                    }
                    abc = abc.split('-');
                    document.getElementById('txtmodule').value = abc[0];
                    document.getElementById('hdnmoduleid').value = abc[1];
                    document.getElementById('txtmodule').focus();
                    return false;
                }
            }
        }
    }
}