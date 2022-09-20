var browser = navigator.appName; 


function blankfields() {

    if (document.getElementById("hdn_user_right").value == "0" || document.getElementById("hdn_user_right").value == "") {
        //alert("You are not Authorized to see this form")
        //window.close();
        //return false;
    }
    else {


        document.getElementById('txtagencyname').value = "";
        document.getElementById('txtclientname').value = "";
        document.getElementById('txtproductname').value = "";
        document.getElementById('txtfromdate').value = "";
        document.getElementById('txttodate').value = "";
        document.getElementById('drpdestination').value = "";
        return false;
    } 
}



function checkkdate(input, box) {
    var inputid1 = document.activeElement.id;
    var dateformat = document.getElementById('hiddendateformat').value;
    if (dateformat == "mm/dd/yyyy") {
        var validformat = /^\d{2}\/\d{2}\/\d{4}$/
    }

    if (dateformat == "yyyy/mm/dd") {
        var validformat = /^\d{4}\/\d{2}\/\d{2}$/
    }

    if (dateformat == "dd/mm/yyyy") {
        var validformat = /^\d{2}\/\d{2}\/\d{4}$/
    }

    if (!validformat.test(input)) {
        if (input == "")
            return true;

        // setTimeout(settime12,15);
        if (document.activeElement.id.indexOf('nand') < 0 && document.activeElement.id != '') {
            alert(" Please Fill The Date In " + dateformat + " Format");
            input = "";
            document.getElementById(box).value = "";
            //$('txttodate').value="";
            inputid = document.activeElement.id;
            document.getElementById(box).focus();
            return false;
        }
    }
    else { //Detailed check for valid date ranges
        if (dateformat == "yyyy/mm/dd") {
            var yearfield = input.split("/")[0]
            var monthfield = input.split("/")[1]
            var dayfield = input.split("/")[2]
            var dayobj = new Date(yearfield, monthfield - 1, dayfield)
        }
        if (dateformat == "mm/dd/yyyy") {
            var yearfield = input.split("/")[2]
            var monthfield = input.split("/")[0]
            var dayfield = input.split("/")[1]
            var dayobj = new Date(yearfield, monthfield - 1, dayfield)
        }

        if (dateformat == "dd/mm/yyyy") {
            var yearfield = input.split("/")[2]
            var monthfield = input.split("/")[1]
            var dayfield = input.split("/")[0]
            //var dayobj = new Date(dayfield, monthfield-1, yearfield)
            var dayobj = new Date(yearfield, monthfield - 1, dayfield)
        }
    } //end of else


    var abcd = dayobj.getMonth() + 1;
    var date1 = dayobj.getDate();
    var year1 = dayobj.getFullYear();
    if ((abcd != monthfield) || (date1 != dayfield) || (year1 != yearfield)) {
        alert(" Please Fill The Date In " + dateformat + " Format");
        input = "";
        // $('txttodate').value="";
        //   $(box).value="";
        // $(box).focus();
        // $('txtRedemfromdate').value="";
        return false;
    }


    //inputid1.select();

    return true

}

function onclickagency(event) {
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
                    document.getElementById('txtagencyname').value = abc;
                    document.getElementById('hiddenagency').value = abc;
                    document.getElementById('hiddenagency1').value = page;

                    document.getElementById("divagency").style.display = "none";
                    document.getElementById('txtagencyname').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

    document.getElementById("divagency").style.display = "none";
        document.getElementById('txtagencyname').focus();
    }
}
function onclickproduct(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstproduct") {
            if (document.getElementById('lstproduct').value == "0") {
                alert("Please select client Name");
                return false;
            }

            var page = document.getElementById('lstproduct').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstproduct').length - 1; k++) {
                if (document.getElementById('lstproduct').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstproduct').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstproduct').options[k].innerText;
                    }
                    document.getElementById('txtproductname').value = abc;
                    document.getElementById('hiddenproduct').value = abc;
                    document.getElementById('hiddenproduct1').value = page;

                    document.getElementById("divproduct").style.display = "none";
                    document.getElementById('txtproductname').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

    document.getElementById("divproduct").style.display = "none";
        document.getElementById('txtproductname').focus();
    }
}


function F2fillagencycr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtagencyname") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value;
            var agn = document.getElementById('txtagencyname').value;
            document.getElementById("divagency").style.display = "block";
            document.getElementById('divagency').style.top = 350 + "px"; //314//290
            document.getElementById('divagency').style.left = 278 + "px"; //395//1004
            document.getElementById('lstagency').focus();
            Deal_comparison_rpt.fillF2_CreditAgency(compcode, agn, bindAgency_callback1);
        }
    }

}
function F2fillagencycr1(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtclientname") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value;
            var client = document.getElementById('txtclientname').value;
            document.getElementById("divclient").style.display = "block";
            document.getElementById('divclient').style.top = 350 + "px"; //314//290
            document.getElementById('divclient').style.left = 278 + "px"; //395//1004
            document.getElementById('lstclient').focus();
            Deal_comparison_rpt.fillF2_Creditclient(compcode, client, bindAgency_callback2);
        }
    }

}

function F2fillagencycr2(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtproductname") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hdncompcode').value;
            var pro = document.getElementById('txtproductname').value;
            document.getElementById("divproduct").style.display = "block";
            document.getElementById('divproduct').style.top = 350 + "px"; //314//290
            document.getElementById('divproduct').style.left = 278 + "px"; //395//1004
            document.getElementById('divproduct').focus();
            Deal_comparison_rpt.bindbrand(compcode, pro, bindAgency_callback3);
        }
    }

}

function bindAgency_callback3(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstproduct");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Product Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].brand_name, ds_AccName.Tables[0].Rows[i].brand_code);
            pkgitem.options.length;
        }
    }

    var aTag = eval(document.getElementById('txtproductname'))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById('divproduct').scrollLeft;
    var scrolltop = document.getElementById('divproduct').scrollTop;
    document.getElementById('divproduct').style.left = document.getElementById('txtproductname').offsetLeft + leftpos - tot + "px";
    document.getElementById('divproduct').style.top = document.getElementById('txtproductname').offsetTop + toppos - scrolltop + "px"; //"510px";



    document.getElementById("lstproduct").value = "0";
    document.getElementById("divproduct").value = "";
    document.getElementById('lstproduct').focus();
    //alert(ds_AccName.Tables[0].Rows[i].Agency_Name)
    return false;

}


function bindAgency_callback1(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agencynam, ds_AccName.Tables[0].Rows[i].Agency_Code);
            pkgitem.options.length;
        }
    }

    var aTag = eval(document.getElementById('txtagencyname'))
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
    document.getElementById('divagency').style.left = document.getElementById('txtagencyname').offsetLeft + leftpos - tot + "px";
    document.getElementById('divagency').style.top = document.getElementById('txtagencyname').offsetTop + toppos - scrolltop + "px"; //"510px";



    document.getElementById("lstagency").value = "0";
    document.getElementById("divagency").value = "";
    document.getElementById('lstagency').focus();
    //alert(ds_AccName.Tables[0].Rows[i].Agency_Name)
    return false;

}
function bindAgency_callback2(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstclient");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select client Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name, ds_AccName.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;
        }
    }

    var aTag = eval(document.getElementById('txtclientname'))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById('divclient').scrollLeft;
    var scrolltop = document.getElementById('divclient').scrollTop;
    document.getElementById('divclient').style.left = document.getElementById('txtclientname').offsetLeft + leftpos - tot + "px";
    document.getElementById('divclient').style.top = document.getElementById('txtclientname').offsetTop + toppos - scrolltop + "px"; //"510px";



    document.getElementById("lstclient").value = "0";
    document.getElementById("divclient").value = "";
    document.getElementById('divclient').focus();
    //alert(ds_AccName.Tables[0].Rows[i].Agency_Name)
    return false;

}



function onclickagency(event) {
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
                    document.getElementById('txtagencyname').value = abc;
                    //document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hiddenagency').value = page;

                    document.getElementById("divagency").style.display = "none";
                    document.getElementById('txtagencyname').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

    document.getElementById("divagency").style.display = "none";
    document.getElementById('txtagencyname').focus();
    }
}

function onclickclient(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstclient") {
            if (document.getElementById('lstclient').value == "0") {
                alert("Please select client Name");
                return false;
            }
            var page = document.getElementById('lstclient').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstclient').length - 1; k++) {
                if (document.getElementById('lstclient').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstclient').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstclient').options[k].innerText;
                    }
                    document.getElementById('txtclientname').value = abc;
                    //document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hiddenclient').value = page;

                    document.getElementById("divclient").style.display = "none";
                    document.getElementById('txtclientname').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

    document.getElementById("divclient").style.display = "none";
    document.getElementById('txtclientname').focus();
    }
}

function onclickproduct(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstproduct") {
            if (document.getElementById('lstproduct').value == "0") {
                alert("Please select product Name");
                return false;
            }
            var page = document.getElementById('lstproduct').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstproduct').length - 1; k++) {
                if (document.getElementById('lstproduct').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstproduct').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstproduct').options[k].innerText;
                    }
                    document.getElementById('txtproductname').value = abc;
                    //document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hiddenproduct').value = page;

                    document.getElementById("divproduct").style.display = "none";
                    document.getElementById('txtproductname').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

        document.getElementById("divclient").style.display = "none";
        document.getElementById('txtclientname').focus();
    }
}





function run(event) {
        var destination = document.getElementById('drpdestination').value;

        var fromdate = document.getElementById('txtfromdate').value;
        var todate = document.getElementById('txttodate').value;
        var product = document.getElementById('txtproductname').value;
        var client = document.getElementById('txtclientname').value;
        var agency = document.getElementById('txtagencyname').value;

        var agency_code=document.getElementById('hiddenagency').value;

        var product_code = document.getElementById('hiddenproduct').value;

        var client_code = document.getElementById('hiddenclient').value;
        
        if (document.getElementById('txtfromdate').value == "") {
            alert("please fill from date");
            return false;
        }

        if (document.getElementById('txttodate').value == "") {
            alert("please fill to date");
            return false;
        }

        if (document.getElementById('txtagencyname').value == "" || document.getElementById('hiddenagency').value == "") {
            alert('Please Select Agency By Pressing F2 Key');
            document.getElementById('txtagencyname').focus();
            return false;
        }


        window.open("Deal_comparisonprint_rpt.aspx?destination=" + destination + "&fromdate=" + fromdate + "&todate=" + todate + "&product=" + product + "&client=" + client + "&agency=" + agency + "&agency_code=" + agency_code + "&product_code=" + product_code + "&client_code=" + client_code);

        return false;
    }

