// JScript File5
var arrNS;
var ALLOWBOOKINGBRANCHMAIL;
var discid = "";
var agencycodeglo;
var gbtradedisc;
var idfocus = "";
var agnf2 = "";
var browser = navigator.appName;
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
    if (agnf2 != "Y") {
        document.getElementById('txtclient').value = "";
        document.getElementById("lstclient").focus();  //uncomment
    }
    document.getElementById("lstclient").value = "0"; //uncomment

    return false;
}
function bindrevenuecenternew_callback(response) {

    ds = response.value;
    var pkgitem = document.getElementById("lstrevenuecenternew");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Revenue Center-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].UNIT_NAME + '~' + ds.Tables[0].Rows[i].UNIT_CODE, ds.Tables[0].Rows[i].UNIT_NAME + '~' + ds.Tables[0].Rows[i].UNIT_CODE + '~' + ds.Tables[0].Rows[i].MAIN_BRANCH);

            pkgitem.options.length;
        }
    }

    return false;
}
function bindreferenceID_callback(response) {
    ds = response.value;
    if (ds == null) {
        alert(response.error.description);
        return false;
    }
    var pkgitem = document.getElementById("lstreference");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select ID-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        //alert(pkgitem.options.length);
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].CIOID, ds.Tables[0].Rows[i].CIOID);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstreference").focus();
}

function bindbrand_callback(response) {
    var dsbrand = response.value;
    if (dsbrand == null) {
        alert(response.error.description);
        return false;
    }
    var pkgitem = document.getElementById("lstbrand");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select ID-", "0");
    if (dsbrand != null && typeof (dsbrand) == "object" && dsbrand.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        //alert(pkgitem.options.length);
        for (var i = 0; i < dsbrand.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(dsbrand.Tables[0].Rows[i].BRANDNAME, dsbrand.Tables[0].Rows[i].BRANDCODE);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstbrand").focus();
}
function bindagencyname_callback(response) {
    ds = response.value;
    if (ds == null) {
        alert(response.error.description);
        return false;
    }
    //   document.getElementById('drpretainer').value="";
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
    if (agnf2 != "Y") {
        document.getElementById('txtagency').value = "";

        document.getElementById("lstagency").focus();
    }
    document.getElementById("lstagency").value = "0";
    return false;
}


function tabvalue(event) {

    if (document.getElementById('Hdnmodbook') != null && document.getElementById('Hdnmodbook').value == "modify") {
        if (event.keyCode == 13 && document.activeElement.id == "txtciobookid") {
            executeClick();
            modifyClick();

        }


    }
    //This is open to upload image tab for all Insertions......
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 123 && document.getElementById('uploadA') != null) {
        //if (document.getElementById('txttotalarea').value == null || document.getElementById('txttotalarea').value == "0" || document.getElementById('txttotalarea').value == "") {
        if (document.getElementById('uploadA').style.color == "red") {
            uploadimageall();
            return false;
        }
    }
    //////this is to chk taht on the grid if we press down than focus should be on down row and if up than focus 
    if (document.activeElement.id.indexOf("txtreference") == 0 && (event.keyCode != 46 && event.keyCode != 39 && event.keyCode != 37 && event.keyCode != 13 && event.keyCode != 9 && event.keyCode != 27 && event.keyCode != 113 && event.keyCode != 8 && event.keyCode != 40 && event.keyCode != 38 && event.keyCode != 16)) {
        event.keyCode = 0;
        return false;
    }
    if (document.activeElement.id.indexOf("txtrodate") == 0) {
        if (event.keyCode == 117 && document.getElementById(document.activeElement.id).disabled == false) {
            document.getElementById(document.activeElement.id).value = document.getElementById('txtdatetime').value;
            document.getElementById(document.activeElement.id).focus();
            return false;
        }
    }
    if (document.activeElement.id.indexOf("txtprintremark") == 0) {
        document.getElementById(document.activeElement.id).title = document.getElementById(document.activeElement.id).value;
    }
    if (document.activeElement.id.indexOf("rem") == 0) {
        document.getElementById(document.activeElement.id).title = document.getElementById(document.activeElement.id).value;
    }
    if (document.activeElement.id.indexOf("Text") == 0) {
        var res = dateenter(event);
        if (event.keyCode == 37 || event.keyCode == 39)
            return true;
        if (res == false)
            return false;
    }
    if (document.activeElement.id.indexOf("rep") == 0) {
        return dateenter(event);
    }
    if (document.activeElement.id.indexOf("lat") == 0) {
        return dateenter(event);
    }
    if (document.activeElement.id.indexOf("hei") == 0) {
        return rateenter(event);
    }
    if (document.activeElement.id.indexOf("wid") == 0) {
        return rateenter(event);
    }
    if (document.activeElement.id.indexOf("nocol") == 0) {
        return rateenter(event);
    }
    if (document.activeElement.id.indexOf("siz") == 0) {
        return rateenter(event);
    }

    if (document.activeElement.id.indexOf("txtcirrate") == 0 || document.activeElement.id.indexOf("txtbartertype") == 0) {
        if (event.keyCode != 113 && event.keyCode != 27 && event.keyCode != 13 && event.keyCode != 9) {
            return false;
        }
    }
    if (document.activeElement.id.indexOf("prem") == 0 || document.activeElement.id.indexOf("pagpos") == 0 || document.activeElement.id.indexOf("inssta") == 0 || document.activeElement.id.indexOf("pgpre") == 0 || document.activeElement.id.indexOf("ads") == 0 || document.activeElement.id.indexOf("col") == 0) {
        if (event.keyCode != 113 && event.keyCode != 27) {
            // return false;
        }
    }

    if (event.keyCode == 40) {
        if (document.getElementById('tblinsert') != null && document.getElementById('tblinsert').innerHTML != "") {
            if (document.activeElement.type == "text") {
                var texid = document.activeElement.id;
                if (texid.indexOf("Text") >= 0 || texid.indexOf("rem") >= 0 || texid.indexOf("pagno") >= 0 || texid.indexOf("hei") >= 0) {
                    var idtext;
                    var i;
                    if (texid.indexOf("Text") >= 0) {
                        idtext = texid.substring(0, 4);
                        i = texid.substring(4, texid.length);;
                    }
                    else if (texid.indexOf("rem") >= 0 || texid.indexOf("hei") >= 0) {
                        idtext = texid.substring(0, 3);
                        i = texid.substring(3, texid.length);;
                    }
                    else if (texid.indexOf("pagno") >= 0) {
                        idtext = texid.substring(0, 5);
                        i = texid.substring(5, texid.length);;
                    }
                    var len = "bookdiv";
                    var y = document.getElementById(len).getElementsByTagName('table')[0].rows.length - 1;
                    var g;
                    if (i != undefined) {
                        for (g = i; g < y; g++) {
                            i = parseInt(i) + 1;
                            while (document.getElementById("card" + i) == null && g < y - 1) {
                                i = i + savtotid;
                            }
                            if (g >= y - 1) {
                                break;
                            }
                            document.getElementById(idtext + i).focus();
                            break;
                        }
                    }
                }

            }

        }

    }

    /////////////////////////////////////////this is to chk taht on the grid if we press down than focus should be on down row
    ////////////////and if up than focus 
    if (event.keyCode == 38) {
        if (document.getElementById('tblinsert').innerHTML != "") {
            if (document.activeElement.type == "text") {
                var texid = document.activeElement.id;
                if (texid.indexOf("Text") >= 0 || texid.indexOf("rem") >= 0 || texid.indexOf("pagno") >= 0 || texid.indexOf("hei") >= 0) {
                    var idtext;
                    var i;
                    if (texid.indexOf("Text") >= 0) {
                        idtext = texid.substring(0, 4);
                        i = texid.substring(4, texid.length);;
                    }
                    else if (texid.indexOf("rem") >= 0 || texid.indexOf("hei") >= 0) {
                        idtext = texid.substring(0, 3);
                        i = texid.substring(3, texid.length);;
                    }
                    else if (texid.indexOf("pagno") >= 0) {
                        idtext = texid.substring(0, 5);
                        i = texid.substring(5, texid.length);;
                    }
                    var len = "bookdiv";
                    var y = document.getElementById(len).getElementsByTagName('table')[0].rows.length - 1;
                    var g;
                    if (i != undefined) {
                        for (g = i; g < y; g--) {
                            if (i == 0) {
                                break;
                            }
                            i = parseInt(i) - 1;
                            while (document.getElementById("card" + i) == null && g > y - 1) {
                                i = i - savtotid;

                            }
                            if (g = 0) {
                                break;
                            }
                            document.getElementById(idtext + i).focus();
                            break;
                        }
                    }
                }

            }

        }

    }

    /////////////////////////////////////////////////
    if (event.keyCode == 113 || (event.shiftKey == true && event.keyCode == 51)) {
        if (document.activeElement.id.indexOf("coldiv") == 0) {
            activeid = document.activeElement.id;
            var userid = document.getElementById('hiddenuserid').value;
            var compcode = document.getElementById('hiddencompcode').value;
            var divid = "agdivpop";
            var listboxid = "aglistpop";
            var ds = Booking_master.bindcolorForGrid(compcode, userid);
            if (ds == null)
                return false;
            var objcol = document.getElementById(listboxid);
            objcol.options.length = 0;
            objcol.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
            objcol.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objcol.options[objcol.options.length] = new Option(ds.value.Tables[0].Rows[i].Col_Name, ds.value.Tables[0].Rows[i].Col_Code);

                objcol.options.length;
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
            var tot = 0; //document.getElementById('bookdiv').scrollLeft;


            var scrolltop = 0; //document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            // document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("divinssta") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdivpop";
            var listboxid = "aglistpop";
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            var c = 1;
            var b = 0;
            if (browser != "Microsoft Internet Explorer") {
                for (b = 1; b <= xmlObj.childNodes[19].childNodes.length - 1;) {
                    objadscat.options[c] = new Option(xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue, xmlObj.childNodes[19].childNodes[b + 2].childNodes[0].nodeValue);
                    b = b + 4;
                    c = c + 1;
                }
            }
            else {
                var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
                loadXML("xml/billcycle.xml");
                for (b = 0; b <= xmlObj.childNodes(9).childNodes.length - 1; b++) {
                    objadscat.options[c] = new Option(xmlObj.childNodes[9].childNodes[b].childNodes[0].nodeValue, xmlObj.childNodes[9].childNodes[b + 1].childNodes[0].nodeValue);
                    b = b + 1;
                    c = c + 1;
                }
            }
            objadscat.options.length;
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
            var tot = 0; //document.getElementById('bookdiv').scrollLeft;


            var scrolltop = 0; //document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            //  document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("txtcolexec") == 0) {
            activeid = document.activeElement.id;
            var compcode = document.getElementById('hiddencompcode').value;
            var colexec = document.getElementById('txtcolexec').value
            var ds = Booking_master.colexec_bind(compcode, colexec);
            if (ds == null)
                return false;
            var objadscat = document.getElementById("lstcolexec");
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Rep_Name, ds.value.Tables[0].Rows[i].Rep_code);
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
            var tot = 0;
            var scrolltop = 0;
            document.getElementById('divcolexec').style.top = document.getElementById(activeid).offsetTop + toppos + "px";
            document.getElementById('divcolexec').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById('divcolexec').style.display = "block";
            document.getElementById('divcolexec').cssclass = "btextlist";
            document.getElementById("lstcolexec").focus();
        }
        else if (document.activeElement.id.indexOf("adsdiv") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdivpop";
            var listboxid = "aglistpop";
            var compcode = document.getElementById('hiddencompcode').value;
            var adcategory = document.activeElement.id.replace("adsdiv", "adcat");
            adcategory = document.getElementById(adcategory).value;
            var ds = Booking_master.getadsubcat_grid(compcode, adcategory);
            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Adv_Subcat_Name, ds.value.Tables[0].Rows[i].Adv_Subcat_Code);

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
            var tot = 0; //document.getElementById('bookdiv').scrollLeft;
            var scrolltop = 0; //document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            //  document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(divid).cssclass = "btextlist";

            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id == "txtreference") {
            document.getElementById("divreference").style.display = "block";
            aTag = eval(document.getElementById("txtreference"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divreference').style.top = document.getElementById("txtreference").offsetTop + toppos + "px";
            document.getElementById('divreference').style.left = document.getElementById("txtreference").offsetLeft + leftpos + "px";
            var agency = "";
            var client = "";
            if (document.getElementById('txtagency').value.indexOf("(".toString()) > 0 && document.getElementById('txtagency').value.indexOf("(".toString()) > 0)
                agency = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
            if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0 && document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
                client = document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf('(') + 1, document.getElementById('txtclient').value.lastIndexOf(')'));
            var resB = Booking_master.bindreferenceID(document.getElementById('hiddencompcode').value, agency, client);
            bindreferenceID_callback(resB);

        }
            ///////////////////add anuja//////////////////////
        else if (document.activeElement.id == "txtindustry") {
            //            if (document.getElementById('txtindustry').value.length <= 2) {
            //                alert("Please Enter Minimum 3 Character For Searching.");
            //                document.getElementById('txtindustry').value = "";
            //                return false;
            //            }
            document.getElementById("divindus").style.display = "block";
            aTag = eval(document.getElementById("txtindustry"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divindus').style.top = document.getElementById("txtindustry").offsetTop + toppos + "px";
            document.getElementById('divindus').style.left = document.getElementById("txtindustry").offsetLeft + leftpos + "px";
            var ext1 = "";
            var ext2 = "";
            var ext3 = "";
            var ext4 = "";
            var ext5 = "";
            var resB = Booking_master.indus(document.getElementById('hiddencompcode').value, "", document.getElementById("txtindustry").value);
            bindindus_callback(resB);
        }
        else if (document.activeElement.id == "txtproduct") {
            if (document.getElementById('drpproductcat').value == "0") {
                alert("Please Select Product Category");
                document.getElementById('txtproduct').value = "";
                document.getElementById('drpproductcat').focus();
                return false;
            }
            document.getElementById("divprosucat").style.display = "block";
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
            document.getElementById('divprosucat').style.top = document.getElementById("txtproduct").offsetTop + toppos + "px";
            document.getElementById('divprosucat').style.left = document.getElementById("txtproduct").offsetLeft + leftpos + "px";
            var indus = document.getElementById('txtindustry').value.substring(document.getElementById('txtindustry').value.lastIndexOf('(') + 1, document.getElementById('txtindustry').value.lastIndexOf(')'));
            var procat = document.getElementById('drpproductcat').value;
            var ext3 = "";
            var ext4 = "";
            var ext5 = "";
            var resB = Booking_master.procatsub(document.getElementById('hiddencompcode').value, indus, procat);
            bindsubcat_callback(resB);
        }
            ///////////////////////////////////////////
        else if (document.activeElement.id == "drpbrand") {
            /*if (document.getElementById('drpbrand').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('drpbrand').value = "";
                return false;
            }*/
            document.getElementById("divbrand").style.display = "block";
            aTag = eval(document.getElementById("drpbrand"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divbrand').style.top = document.getElementById("drpbrand").offsetTop + toppos + "px";
            document.getElementById('divbrand').style.left = document.getElementById("drpbrand").offsetLeft + leftpos + "px";
            var ext1 = "";
            var ext2 = "";
            var ext3 = "";
            var ext4 = "";
            var ext5 = "";
            var resB = Booking_master.bindbrand(document.getElementById('hiddencompcode').value, document.getElementById("drpbrand").value, ext1, ext2, ext3, ext4, ext5);
            bindbrand_callback(resB);
        }
        else if (document.activeElement.id == "txtagency") {
            if (document.getElementById('txtagency').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtagency').value = "";
                return false;
            }
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
            /*if(browser!="Microsoft Internet Explorer")
            {
            document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/
            (-20) + "px";
            /*  document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
            document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-25) + "px";
            document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }*/
            if (document.getElementById('hdnbranchf2req').value == "Y") {
                Booking_master.bindagencyname1(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency').value, "N", document.getElementById('hdnrevenuecentcd').value, bindagencyname_callback);
            }
            else {
                Booking_master.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency').value, "N", bindagencyname_callback);
            }

        }
        //else 
        if (document.activeElement.id == "txtbartertype") {

            aTag = eval(document.getElementById("txtbartertype"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

            document.getElementById("divbarter").style.left = document.getElementById("txtbartertype").offsetLeft + leftpos + "px";
            document.getElementById("divbarter").style.top = document.getElementById("txtbartertype").offsetTop + toppos + "px"; //"510px";
            document.getElementById("divbarter").style.display = "block";
            var res;
            var agencycode = "";
            if (document.getElementById('txtagency').value != "") {
                agencycode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.length + document.getElementById('txtagency').value.lastIndexOf('('));
                agencycode = agencycode.replace(")", "");
            }
            var clientcode = document.getElementById('txtclient').value;
            if (clientcode.indexOf("(".toString()) > 0) {
                var myarray1 = clientcode.split('(');
                client = myarray1[1];
                client = client.replace(")", '');
            }
            res = Booking_master.getBarter(document.getElementById('hiddencompcode').value, document.getElementById('hiddencenter').value, document.getElementById('txtbranch').value, agencycode, client);
            if (res.value != null && res.value.Tables.length > 0) {
                var ds = res.value;
                var objciragency = document.getElementById("lstbarter");
                objciragency.options.length = 0;
                objciragency.options[0] = new Option("-Select-", "0");
                objciragency.options.length = 1;
                for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                    var name = ds.Tables[0].Rows[i].BARTE_DESC;
                    var value = ds.Tables[0].Rows[i].BARTER_CODE + "û" + ds.Tables[0].Rows[i].BARTER_AMOUNT + "û" + ds.Tables[0].Rows[i].STOPBOOKING;
                    objciragency.options[objciragency.options.length] = new Option(name, value);
                    objciragency.options.length;
                }
                objciragency.focus();
            }
        }
        else if (document.activeElement.id == "txtcirrate") {

            aTag = eval(document.getElementById("txtcirrate"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

            document.getElementById("divcirrate").style.left = document.getElementById("txtcirrate").offsetLeft + leftpos + "px";
            document.getElementById("divcirrate").style.top = document.getElementById("txtcirrate").offsetTop + toppos + "px"; //"510px";
            document.getElementById("divcirrate").style.display = "block";
            var res;
            if (document.location.toString().indexOf("advts.aspx") > 0) {
                res = advts.bindcirRate(document.getElementById('hiddencompcode').value, document.getElementById('hiddencenter').value);
            }
            else {
                res = Booking_master.bindcirRate(document.getElementById('hiddencompcode').value, document.getElementById('hiddencenter').value);
            }
            if (res.value != null && res.value.Tables.length > 0) {
                var ds = res.value;
                var objciragency = document.getElementById("lstcirrate");
                objciragency.options.length = 0;
                objciragency.options[0] = new Option("-Select-", "0");
                objciragency.options.length = 1;
                for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                    var name = ds.Tables[0].Rows[i].PUBL_NAME + ' + ' + ds.Tables[0].Rows[i].EDTN_NAME + '(' + ds.Tables[0].Rows[i].SUN_RATE + ')';
                    var value = ds.Tables[0].Rows[i].PUBL + ' + ' + ds.Tables[0].Rows[i].EDTN + '(' + ds.Tables[0].Rows[i].SUN_RATE + ')';;
                    objciragency.options[objciragency.options.length] = new Option(name, value);
                    objciragency.options.length;
                }
                objciragency.focus();
            }
        }
        else if (document.activeElement.id == "txtciragency") {

            aTag = eval(document.getElementById("txtciragency"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

            document.getElementById("divciragency").style.left = document.getElementById("txtciragency").offsetLeft + leftpos + "px";
            document.getElementById("divciragency").style.top = document.getElementById("txtciragency").offsetTop + toppos + "px"; //"510px";
            document.getElementById("divciragency").style.display = "block";
            var res = Booking_master.bindciragency(document.getElementById('hiddencompcode').value, document.getElementById('hiddencenter').value, document.getElementById('txtciragency').value);
            if (res.value != null) {
                var ds = res.value;
                var objciragency = document.getElementById("lstciragency");
                objciragency.options.length = 0;
                objciragency.options[0] = new Option("-Select-", "0");
                objciragency.options.length = 1;
                for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                    objciragency.options[objciragency.options.length] = new Option(ds.Tables[0].Rows[i].AG_NAME + '(' + ds.Tables[0].Rows[i].AGCD + ' + ' + ds.Tables[0].Rows[i].DPCD + ')', ds.Tables[0].Rows[i].AG_NAME + '(' + ds.Tables[0].Rows[i].AGCD + ' + ' + ds.Tables[0].Rows[i].DPCD + ')');
                    objciragency.options.length;
                }
                objciragency.focus();
            }
        }
        else if (document.activeElement.id == "txtclient") {
            //bhanu
            if (clientfromconfig == "UD") {
                if (document.getElementById('drpregular').value == "0") {
                    alert("Please select Client Type");
                    document.getElementById('txtclient').value = "";
                    document.getElementById('drpregular').focus();
                    return false;
                }
                if (document.getElementById('drpregular').value == "NRC" || document.getElementById('drpregular').value == "TBRC") {
                    if (document.getElementById('txtclient').value.lastIndexOf(")") < 0) {
                        alert("you are not authorized to select client with F2 key");
                        document.getElementById('txtclient').value = "";
                        return false;
                    }

                }
            }
            ///bhanu end
            if (document.getElementById('txtclient').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtclient').value = "";
                return false;
            }
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
            /*  if(browser!="Microsoft Internet Explorer")
            {
            document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/+(-20) + "px";
            //    document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            //}
            //else
            //{
            //  document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-25) + "px";
            //document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            //}*/
            Booking_master.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient').value, "N", bindclientname_callback);
        }
        else if (document.activeElement.id == "txtproduct") {
            document.getElementById("divproduct").style.display = "block";
            //document.getElementById('divproduct').style.top=parseInt(document.getElementById('txtproduct').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdproduct').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6;
            document.getElementById('divproduct').style.top = parseInt(document.getElementById('txtproduct').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 380 + "px";
            //document.getElementById('divproduct').style.left=parseInt(document.getElementById('txtproduct').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdproduct').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9;
            document.getElementById('divproduct').style.left = parseInt(document.getElementById('txtproduct').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 92 + "px";
            Booking_master.bindProduct(document.getElementById('hiddencompcode').value, document.getElementById('txtproduct').value, bindproductname_callback);
        }
        else if (document.activeElement.id == "txtexecname") {
            if (document.getElementById('txtexecname').value.length <= 2) {
                alert("Please Enter Minimum 3 Character For Searching.");
                document.getElementById('txtexecname').value = "";
                return false;
            }
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
            /* if(browser!="Microsoft Internet Explorer")
            {
            document.getElementById('divexec').style.top=parseInt(document.getElementById('txtexecname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdexec').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/+(-20) + "px";
            /*  document.getElementById('divexec').style.left=parseInt(document.getElementById('txtexecname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdexec').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
            document.getElementById('divexec').style.top=parseInt(document.getElementById('txtexecname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdexec').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-25) + "px";
            document.getElementById('divexec').style.left=parseInt(document.getElementById('txtexecname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdexec').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }*/
            if (document.getElementById('configclient').value == "SP") {
                var agmain_code = "";
                var agsubcode_code = "";
                var code_subcode = "";
                if (document.getElementById('hiddenagency').value.split('(')[1] == undefined) {
                    code_subcode = document.getElementById('hiddenagency').value
                }
                else {
                    code_subcode = document.getElementById('hiddenagency').value.split('(')[1].split(')')[0];
                }

                var exename = "";
                if (document.getElementById('txtexecname').value.split('(')[1] == undefined) {
                    exename = document.getElementById('txtexecname').value;
                }
                else {
                    exename = document.getElementById('txtexecname').value.split('(')[0];
                }
                var extra1 = "";
                var extra2 = "";
                var extra3 = "";
                var extra4 = "";
                var extra5 = "";
                var extra6 = "";
                var extra7 = "";
                var extra8 = "";
                var extra9 = "";
                var extra10 = "";
                Booking_master.bindExec_agency(document.getElementById('hiddencompcode').value, document.getElementById('hiddenadtype').value, agmain_code, agsubcode_code, code_subcode, exename, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, bindexecname_callback);
            }
            else {
                if (document.getElementById('hdnbranchf2req').value == "Y") {
                    var rev_cent = document.getElementById('hdnrevenuecentcd').value;
                    Booking_master.bindExec_new(document.getElementById('hiddencompcode').value, document.getElementById('txtexecname').value, document.getElementById('hiddenadtype').value, rev_cent, bindexecname_callback);
                }
                else {
                    Booking_master.bindExec(document.getElementById('hiddencompcode').value, document.getElementById('txtexecname').value, document.getElementById('hiddenadtype').value, bindexecname_callback);
                }
            }
        }
            //*6Aug*
        else if (document.activeElement.id == "drpretainer") {
            if (retexeboth != "both") {
                if (document.getElementById('txtexecname').value != "") {
                    var b = "Retainer";
                    if (browser != "Microsoft Internet Explorer") {

                        b = document.getElementById('lblretainer').textContent.replace("*[F2]", "");
                    }
                    else {

                        b = document.getElementById('lblretainer').innerText.replace("*[F2]", "");
                    }
                    if (confirm('Are you sure you want to Take ' + b)) {
                        if (document.getElementById('drpretainer').value.length <= 2) {
                            alert("Please Enter Minimum 3 Character For Searching.");
                            document.getElementById('drpretainer').value = "";
                            return false;
                        }
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
                        document.getElementById('divretainer').style.top = document.getElementById("drpretainer").offsetTop + toppos + "px";
                        document.getElementById('divretainer').style.left = document.getElementById("drpretainer").offsetLeft + leftpos + "px";
                        /*   if(browser!="Microsoft Internet Explorer")
                        {
                        document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/+(-20) + "px";
                        /*  document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
                        }
                        else
                        {
                        document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-25) + "px";
                        document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
                        }*/
                        var agcode = "";
                        if (document.getElementById('txtagency').value != "" && document.getElementById('txtagency').value.indexOf("(") >= 0 && document.getElementById('txtagency').value.indexOf(")") >= 0)
                            agcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
                        if (document.getElementById('hdnbranchf2req').value == "Y") {
                            var rev_centret = document.getElementById('hdnrevenuecentcd').value;
                            Booking_master.bindRetainer_new(document.getElementById('hiddencompcode').value, document.getElementById('drpretainer').value, agcode, rev_centret, bindretainer_callback);
                        }
                        else {
                            Booking_master.bindRetainer(document.getElementById('hiddencompcode').value, document.getElementById('drpretainer').value, agcode, bindretainer_callback);
                        }
                    }
                    else {
                        document.getElementById('drpretainer').value = "";
                        document.getElementById("divretainer").style.display = "none";
                    }
                }
                else {
                    if (document.getElementById('drpretainer').value.length <= 2) {
                        alert("Please Enter Minimum 3 Character For Searching.");
                        document.getElementById('drpretainer').value = "";
                        return false;
                    }
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
                    document.getElementById('divretainer').style.top = document.getElementById("drpretainer").offsetTop + toppos + "px";
                    document.getElementById('divretainer').style.left = document.getElementById("drpretainer").offsetLeft + leftpos + "px";
                    /*    if(browser!="Microsoft Internet Explorer")
                    {
                    document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/+(-6) + "px";
                    /*  document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
                    }
                    else
                    {
                    document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
                    document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
                    }*/
                    var agcode = "";
                    if (document.getElementById('txtagency').value != "" && document.getElementById('txtagency').value.indexOf("(") >= 0 && document.getElementById('txtagency').value.indexOf(")") >= 0)
                        agcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
                    if (document.getElementById('hdnbranchf2req').value == "Y") {
                        var rev_centret1 = document.getElementById('hdnrevenuecentcd').value;
                        Booking_master.bindRetainer_new(document.getElementById('hiddencompcode').value, document.getElementById('drpretainer').value, agcode, rev_centret1, bindretainer_callback);
                    }
                    else {
                        Booking_master.bindRetainer(document.getElementById('hiddencompcode').value, document.getElementById('drpretainer').value, agcode, bindretainer_callback);
                    }
                }
            }
            else {
                if (document.getElementById('drpretainer').value.length <= 2) {
                    alert("Please Enter Minimum 3 Character For Searching.");
                    document.getElementById('drpretainer').value = "";
                    return false;
                }
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
                document.getElementById('divretainer').style.top = document.getElementById("drpretainer").offsetTop + toppos + "px";
                document.getElementById('divretainer').style.left = document.getElementById("drpretainer").offsetLeft + leftpos + "px";
                /*    if(browser!="Microsoft Internet Explorer")
                {
                document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/+(-6) + "px";
                /*  document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
                }
                else
                {
                document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
                document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
                }*/
                var agcode = "";
                if (document.getElementById('txtagency').value != "" && document.getElementById('txtagency').value.indexOf("(") >= 0 && document.getElementById('txtagency').value.indexOf(")") >= 0)
                    agcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
                if (document.getElementById('hdnbranchf2req').value == "Y") {
                    var rev_centret12 = document.getElementById('hdnrevenuecentcd').value;
                    Booking_master.bindRetainer_new(document.getElementById('hiddencompcode').value, document.getElementById('drpretainer').value, agcode, rev_centret12, bindretainer_callback);
                }
                else {
                    Booking_master.bindRetainer(document.getElementById('hiddencompcode').value, document.getElementById('drpretainer').value, agcode, bindretainer_callback);
                }
            }
        }
            //grid line's f2 start here
        else if (document.activeElement.id.indexOf("adcat") == 0) {
            activeid = document.activeElement.id;
            var compcode = document.getElementById('hiddencompcode').value;
            var divid = "agdiv";
            var listboxid = "aglist";
            var ds = Booking_master.advcatinGrid(compcode, document.getElementById('hiddenadtype').value);
            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Adv_Cat_Name, ds.value.Tables[0].Rows[i].Adv_Cat_Code);
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

            var tot = document.getElementById('bookdiv').scrollLeft;

            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";

            document.getElementById(divid).left = document.getElementById(activeid).left + document.getElementById('bookdiv').scrollLeft;
            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("resno") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var val_ = document.getElementById(document.activeElement.id).value;
            var ds = Booking_master.getResourceNo(val_);

            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].NAME, ds.value.Tables[0].Rows[i].CODE);

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
            var tot = document.getElementById('bookdiv').scrollLeft;


            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";

            document.getElementById(divid).left = document.getElementById(activeid).left + document.getElementById('bookdiv').scrollLeft;
            //  document.getElementById(divid).top= document.getElementById(activeid).offsetTop;
            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("seccode") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var val_ = document.getElementById(document.activeElement.id).value;
            var ds = Booking_master.getSectionCode(val_);

            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].NAME, ds.value.Tables[0].Rows[i].CODE);

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
            var tot = document.getElementById('bookdiv').scrollLeft;


            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";

            document.getElementById(divid).left = document.getElementById(activeid).left + document.getElementById('bookdiv').scrollLeft;
            //  document.getElementById(divid).top= document.getElementById(activeid).offsetTop;
            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("col") == 0) {
            activeid = document.activeElement.id;
            var userid = document.getElementById('hiddenuserid').value;
            var compcode = document.getElementById('hiddencompcode').value;
            var divid = "agdiv";
            var listboxid = "aglist";
            var ds = Booking_master.bindcolorForGrid(compcode, userid);
            if (ds == null)
                return false;

            var objcol = document.getElementById(listboxid);
            objcol.options.length = 0;
            objcol.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
            objcol.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objcol.options[objcol.options.length] = new Option(ds.value.Tables[0].Rows[i].Col_Code, ds.value.Tables[0].Rows[i].Col_Code);
                objcol.options.length;
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

            var tot = document.getElementById('bookdiv').scrollLeft;

            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();
        }

        else if (document.activeElement.id.indexOf("pagpos") == 0) {
            activeid = document.activeElement.id;
            var compcode = document.getElementById('hiddencompcode').value;
            var divid = "agdiv";
            var listboxid = "aglist";
            var ds = Booking_master.bindpagePositioninGrid(compcode, document.getElementById('txtdatetime').value, "DI0");
            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Pos_Type, ds.value.Tables[0].Rows[i].Pos_Type_Code);
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

            var tot = document.getElementById('bookdiv').scrollLeft;

            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("prem") == 0) {
            activeid = document.activeElement.id;
            var compcode = document.getElementById('hiddencompcode').value;
            var divid = "agdiv";
            var listboxid = "aglist";
            var ds = Booking_master.bindpageprem_J(compcode, document.getElementById('hiddenadtype').value);
            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].premiumname, ds.value.Tables[0].Rows[i].Premiumcode);
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

            var tot = document.getElementById('bookdiv').scrollLeft;

            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("inssta") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            var c = 1;
            var b = 0;
            if (browser != "Microsoft Internet Explorer") {
                for (b = 1; b <= xmlObj.childNodes[19].childNodes.length - 1;) {
                    objadscat.options[c] = new Option(xmlObj.childNodes[19].childNodes[b].childNodes[0].nodeValue, xmlObj.childNodes[19].childNodes[b + 2].childNodes[0].nodeValue);
                    b = b + 4;
                    c = c + 1;
                }
            }
            else {
                var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
                loadXML("xml/billcycle.xml");
                for (b = 0; b <= xmlObj.childNodes(9).childNodes.length - 1; b++) {
                    objadscat.options[c] = new Option(xmlObj.childNodes[9].childNodes[b].childNodes[0].nodeValue, xmlObj.childNodes[9].childNodes[b + 1].childNodes[0].nodeValue);
                    b = b + 1;
                    c = c + 1;
                }
            }
            objadscat.options.length;
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

            var tot = document.getElementById('bookdiv').scrollLeft;

            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();
        }

        else if (document.activeElement.id.indexOf("mat") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            objadscat.options[1] = new Option("-AttachedMaterial-", "attached");
            objadscat.options[2] = new Option("-AwaitMaterial-", "await");
            objadscat.options[3] = new Option("-RevisedMaterial-", "Revised");
            objadscat.options[4] = new Option("-Hard Copy-", "hardcopy");
            objadscat.options[5] = new Option("-Soft Copy-", "softcopy");
            objadscat.options[6] = new Option("-cd-", "CD");
            objadscat.options[7] = new Option("-Others-", "other");
            objadscat.options[8] = new Option("-As on Matter-", "asonmatter");
            objadscat.options.length;
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

            var tot = document.getElementById('bookdiv').scrollLeft;

            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";

            document.getElementById(divid).style.display = "block";
            document.getElementById(listboxid).focus();
        }

        else if (document.activeElement.id.indexOf("ads") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var compcode = document.getElementById('hiddencompcode').value;
            var adcategory = document.activeElement.id.replace("ads", "adcat");
            adcategory = document.getElementById(adcategory).value;
            var ds = Booking_master.getadsubcat_grid(compcode, adcategory);
            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);

            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1;
            for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Adv_Subcat_Name, ds.value.Tables[0].Rows[i].Adv_Subcat_Code);
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

            var tot = document.getElementById('bookdiv').scrollLeft;

            var scrolltop = document.getElementById('bookdiv').scrollTop;

            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            //document.getElementById(divid).className="btextlist";               
            document.getElementById(listboxid).focus();
        }
            //========************** To Bind Caption Name********==========//
        else if (document.activeElement.id == "txtcaption") {

            document.getElementById("divcap").style.display = "block";
            aTag = eval(document.getElementById("txtcaption"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divcap').style.top = document.getElementById("txtcaption").offsetTop + toppos + "px";
            document.getElementById('divcap').style.left = document.getElementById("txtcaption").offsetLeft + leftpos + "px";
            Booking_master.bindcapnam(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtcaption').value, bindcaption_callback);

        }
    }
    else if (event.keyCode == 27) {
        if (document.getElementById("divciragency").style.display == "block") {
            document.getElementById("divciragency").style.display = "none"
            document.getElementById('lstciragency').options.length = 0;
            document.getElementById('txtciragency').focus();
        }
        else if (document.getElementById("divreference").style.display == "block") {
            document.getElementById("divreference").style.display = "none"
            document.getElementById('lstreference').options.length = 0;
            document.getElementById('txtreference').focus();
        }
        else if (document.getElementById("divbrand").style.display == "block") {
            document.getElementById("divbrand").style.display = "none"
            document.getElementById('lstbrand').options.length = 0;
            document.getElementById('drpbrand').focus();
        }
        else if (document.getElementById("divcolexec").style.display == "block") {
            document.getElementById("divcolexec").style.display = "none"
            document.getElementById('lstcolexec').options.length = 0;
            document.getElementById('txtcolexec').focus();
        }
        else if (document.getElementById("divcirrate").style.display == "block") {
            document.getElementById("divcirrate").style.display = "none"
            document.getElementById('lstcirrate').options.length = 0;
            document.getElementById('txtcirrate').focus();
        }
        else if (document.getElementById("divbarter").style.display == "block") {
            document.getElementById("divbarter").style.display = "none"
            document.getElementById('lstbarter').options.length = 0;
            document.getElementById('txtbartertype').focus();
        }
        else if (document.getElementById("div1").style.display == "block") {
            document.getElementById("div1").style.display = "none"
            document.getElementById('txtagency').focus();
        }
        else if (document.getElementById("divclient").style.display == "block") {
            document.getElementById("divclient").style.display = "none"
            document.getElementById('txtclient').focus();
        }
        else if (document.getElementById("divproduct").style.display == "block") {
            document.getElementById("divproduct").style.display = "none"
            if (document.getElementById('txtproduct').value == "") {
                document.getElementById('drpbrand').value = "";
                document.getElementById('drpvarient').options.length = 0;
            }
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
            ///////////////////////anuja
        else if (document.getElementById("divindus").style.display == "block") {
            document.getElementById("divindus").style.display = "none"
            document.getElementById('lstindus').options.length = 0;
            document.getElementById('txtindustry').focus();
        }
        else if (document.getElementById("divprosucat").style.display == "block") {
            document.getElementById("divprosucat").style.display = "none"
            document.getElementById('lstprosubcat').options.length = 0;
            document.getElementById('txtproduct').focus();
        }
            ////////////////////////////
        else if (document.activeElement.id.indexOf("adcat") == 0 || document.activeElement.id.indexOf("pagpos") == 0 || document.activeElement.id.indexOf("inssta") == 0 || document.activeElement.id.indexOf("mat") == 0 || document.activeElement.id.indexOf("col") == 0 || document.activeElement.id.indexOf("ads") == 0 || document.activeElement.id.indexOf("aglist") == 0 || document.activeElement.id.indexOf("agdiv") == 0) {
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById("agdiv").style.display = "none";
        }
        return false;
    }
    else if (event.keyCode == 13 || event.keyCode == 9 && event.shiftKey == false) {
        if (document.activeElement.id == 'txtagreedrate' && document.getElementById('txtagreedrate').value != "") {
            agreedrate_active = 1;
            agreedamt_active = 0;
        }
        if (document.activeElement.id == 'txtagreedamt' && document.getElementById('txtagreedamt').value != "") {
            agreedrate_active = 0;
            agreedamt_active = 1;
        }
        if (document.activeElement.id.indexOf("txtagency") >= 0) {
            if (document.getElementById('txtagency').value == "") {
                alert("Please Enter Agency");
                document.getElementById('txtagency').focus();
                return false;
            }
        }
        if (document.activeElement.id.indexOf("txtclient") >= 0) {
            if (document.getElementById('txtclient').value == "") {
                alert("Please Enter Client");
                document.getElementById('txtclient').focus();
                return false;
            }
        }
        if (document.activeElement.id.indexOf("aglist") >= 0 || document.activeElement.id.indexOf("aglistpop") >= 0) {
            //           document.getElementById(activeid).value=document.getElementById(document.activeElement.id).value;
            //           document.getElementById(activeid).style.backgroundColor="#FFFFFF";
            //           document.getElementById('agdiv').style.display="none"; 
            //            document.getElementById('txtgrossamt').value="";
            FillSubCatinGrid();
        }
        if (document.activeElement.id == "lstcirrate") {
            if (document.getElementById('lstcirrate').value == "0") {
                alert("Please select the Cir. Rate");
                return false;
            }
            document.getElementById("divcirrate").style.display = "none";

            var page = document.getElementById('lstcirrate').value;
            document.getElementById('hiddencirpub').value = trim(page.toString().split('+')[0]);
            //   document.getElementById('hiddenciredi').value=trim(page.toString().split('+')[1].split('(')[0]);
            var pagename = document.getElementById('lstcirrate').options[document.getElementById('lstcirrate').selectedIndex].text.split('+');

            //   document.getElementById('txtciredition').value=trim(pagename[1].toString()).split('(')[0];
            //   document.getElementById('txtcirrate').value=trim(pagename[1].toString()).split('(')[1].replace(')','');
            if (pagename[1].toString().lastIndexOf("(") >= 0) {
                document.getElementById('txtcirrate').value = pagename[1].toString().substring(pagename[1].toString().lastIndexOf("(") + 1, pagename[1].toString().length - 1);
                document.getElementById('txtciredition').value = pagename[1].toString().substring(0, pagename[1].toString().lastIndexOf("(") - 1);
                document.getElementById('hiddenciredi').value = document.getElementById('txtciredition').value;
            }
            document.getElementById('txtcirrate').focus();

            return false;
        }
        else if (document.activeElement.id == "lstreference") {
            if (document.getElementById('lstreference').value == "0") {
                alert("Please Select Reference ID");
                document.getElementById('txtreference').value = "";
                return false;
            }
            document.getElementById("divreference").style.display = "none";
            var refvalue = document.getElementById('lstreference').value;
            if (refvalue != "") {
                var bame = document.getElementById('lstreference').options[document.getElementById('lstreference').selectedIndex].text;
                document.getElementById('txtreference').value = bame;
            }
            document.getElementById('txtreference').focus();
            return false;
        }
            ///////////////////////////anuja/////////////
        else if (document.activeElement.id == "lstindus") {
            if (document.getElementById('lstindus').value == "0") {
                alert("Please Select Industry");
                document.getElementById('txtindustry').value = "";
                return false;
            }
            document.getElementById("divindus").style.display = "none";
            var refvalue = document.getElementById('lstindus').value;
            if (refvalue != "") {
                var bame = document.getElementById('lstindus').options[document.getElementById('lstindus').selectedIndex].text + '(' + refvalue + ')';
                document.getElementById('txtindustry').value = bame;
                document.getElementById('hdnindus').value = refvalue;
            }
            //            var ext1 = "";
            //            var ext2 = "";
            //            var ext3 = "";
            //            var ext4 = "";
            //            var ext5 = "";
            //            var resc = Booking_master.bindbrandproduct(document.getElementById('hiddencompcode').value, refvalue, ext1, ext2, ext3, ext4, ext5);
            //            if (resc.value == null) {
            //                alert(resc.error.description);
            //                return false;
            //            }
            //            if (resc.value.Tables[0].Rows.length > 0) {
            //                document.getElementById('txtproduct').value = resc.value.Tables[0].Rows[0].PRODUCTCODE;
            //            }
            bindprodcat();
            document.getElementById('txtindustry').focus();
            return false;
        }
        else if (document.activeElement.id == "lstprosubcat") {
            //            if (document.getElementById('lstprosubcat').value == "0") {
            //                alert("Please Select Product Subcat");
            //                document.getElementById('txtproduct').value = "";
            //                return false;
            //            }
            document.getElementById("divprosucat").style.display = "none";
            var refvalue = document.getElementById('lstprosubcat').value;
            if (refvalue != "") {
                var bame = document.getElementById('lstprosubcat').options[document.getElementById('lstprosubcat').selectedIndex].text + '(' + refvalue + ')';
                document.getElementById('txtproduct').value = bame;
                document.getElementById('hdnprosubcat').value = bame;
            }
            //                        var ext1 = "";
            //                        var ext2 = "";
            //                        var ext3 = "";
            //                        var ext4 = "";
            //                        var ext5 = "";
            //                        var resc = Booking_master.bindproductsubcat(document.getElementById('hiddencompcode').value, refvalue, ext1, ext2, ext3, ext4, ext5);
            //                        if (resc.value == null) {
            //                            alert(resc.error.description);
            //                            return false;
            //                        }
            //                        if (resc.value.Tables[0].Rows.length > 0) {
            //                            document.getElementById('txtproduct').value = resc.value.Tables[0].Rows[0].PRODUCTCODE;
            //                        }
            // bindprodcat();
            document.getElementById('txtproduct').focus();
            return false;
        }
            /////////////////////////////////////////////
        else if (document.activeElement.id == "lstbrand") {
            if (document.getElementById('lstbrand').value == "0") {
                alert("Please Select Brand");
                document.getElementById('drpbrand').value = "";
                return false;
            }
            document.getElementById("divbrand").style.display = "none";
            var refvalue = document.getElementById('lstbrand').value;
            if (refvalue != "") {
                var bame = document.getElementById('lstbrand').options[document.getElementById('lstbrand').selectedIndex].text + '(' + refvalue + ')';
                document.getElementById('drpbrand').value = bame;
                document.getElementById('hiddenbrand').value = bame;
            }
            //            var ext1 = "";
            //            var ext2 = "";
            //            var ext3 = "";
            //            var ext4 = "";
            //            var ext5 = "";
            //            var resc = Booking_master.bindbrandproduct(document.getElementById('hiddencompcode').value, refvalue , ext1,ext2,ext3,ext4,ext5);
            //            if (resc.value == null){
            //                alert(resc.error.description);
            //                return false;
            //            }
            //                if (resc.value.Tables[0].Rows.length > 0) {
            //                    document.getElementById('txtproduct').value=resc.value.Tables[0].Rows[0].PRODUCTCODE;
            //                }
            bindvarient();
            document.getElementById('drpbrand').focus();
            return false;
        }
        else if (document.activeElement.id == "lstbarter") {
            if (document.getElementById('lstbarter').value == "0") {
                alert("Please Select Barter Type");
                document.getElementById('txtbartertype').value = "";
                document.getElementById('hiddenbarteramt').value = "";
                document.getElementById('hiddenstopbarterbooking').value = "";
                return false;
            }
            document.getElementById("divbarter").style.display = "none";
            var bartervalue = document.getElementById('lstbarter').value;
            if (bartervalue != "") {
                document.getElementById('hiddenbarteramt').value = bartervalue.split('û')[1];
                document.getElementById('hiddenstopbarterbooking').value = bartervalue.split('û')[2];
                var bame = document.getElementById('lstbarter').options[document.getElementById('lstbarter').selectedIndex].text + '(' + bartervalue.split('û')[0] + ')';
                document.getElementById('txtbartertype').value = bame;
            }

        }
        else if (document.activeElement.id == "lstcolexec") {
            if (document.getElementById('lstcolexec').value == "0") {
                alert("Please select the Collection Executive");
                return false;
            }
            document.getElementById("divcolexec").style.display = "none";
            var page1 = document.getElementById('lstcolexec').options[document.getElementById('lstcolexec').selectedIndex].text + '(' + document.getElementById('lstcolexec').value + ')';
            document.getElementById('txtcolexec').value = page1;
            document.getElementById('txtcolexec').focus();
            return false;
        }
        else if (document.activeElement.id == "lstciragency") {
            if (document.getElementById('lstciragency').value == "0") {
                alert("Please select the Cir. Agency");
                return false;
            }
            document.getElementById("divciragency").style.display = "none";

            var page = document.getElementById('lstciragency').value;





            document.getElementById('txtciragency').value = page;

            document.getElementById('txtciragency').focus();

            return false;
        }
        else if (document.activeElement.id == "lstclient") {
            if (document.getElementById('lstclient').value == "0") {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display = "none";
            var datetime = document.getElementById('txtdatetime').value;
            /*@@ this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
            address and if 0 than agency name and address @@@@@@@@@@@@@@@@@@@*/

            var page = document.getElementById('lstclient').value;
            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null;;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }
                httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&adtype=" + document.getElementById('hiddenadtype').value + "&datetime=" + datetime + "&value=1", false);
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
                xml.Open("GET", "clientName.aspx?page=" + page + "&adtype=" + document.getElementById('hiddenadtype').value + "&datetime=" + datetime + "&value=1", false);
                xml.Send();
                id = xml.responseText;
            }
            var split = id.split("+");
            var namecode = split[0];
            var add = split[1];
            document.getElementById('txtclient').value = namecode;

            if (document.getElementById('hiddensavemod').value == "0") {
                document.getElementById('txtclientadd').value = add;
                document.getElementById('txtclientadd').focus();
            }
            if (document.getElementById("div4").style.display == "block")
                document.getElementById("div4").style.display = "none";
            bind_agen_bill();
            return false;
        }
        else if (document.activeElement.id == "lstagency") {
            if (document.getElementById('lstagency').value == "0") {
                alert("Please select the agency sub code");
                return false;
            }
            document.getElementById("div1").style.display = "none";
            var datetime = document.getElementById('txtdatetime').value;
            var page = document.getElementById('lstagency').value;
            document.getElementById('hiddenagency').value = page;

            agencycodeglo = page;

            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null;;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }

                httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&adtype=" + document.getElementById('hiddenadtype').value + "&datetime=" + datetime + "&value=0", false);
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
                xml.Open("GET", "clientName.aspx?page=" + page + "&adtype=" + document.getElementById('hiddenadtype').value + "&datetime=" + datetime + "&value=0", false);
                xml.Send();
                id = xml.responseText;
            }
            var split = id.split("+");
            var nameagen = split[0];
            var agenadd = split[1];

            document.getElementById('txtagency').value = nameagen;
            if (document.getElementById('hiddensavemod').value == "0" || document.getElementById('hiddensavemod').value == "01") {
                document.getElementById('txtagencyaddress').value = agenadd;
                //BHANU
                if (clientfromconfig == "UD")
                    document.getElementById('drpregular').focus();
                else
                    document.getElementById('txtclient').focus();
                ///BHANU END    
                Booking_master.bindagencusub(page, document.getElementById('hiddencompcode').value, call_bindagsub);
            }
            return false;
        }

        else if (document.activeElement.id == "lstretainer") {
            if (document.getElementById('lstretainer').value == "0") {
                var b = "Retainer";
                if (browser != "Microsoft Internet Explorer") {

                    b = document.getElementById('lblretainer').textContent.replace("*[F2]", "");
                }
                else {

                    b = document.getElementById('lblretainer').innerText.replace("*[F2]", "");
                }
                alert("Please select the " + b);
                return false;
            }
            document.getElementById('drpretainer').value = document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text + "(" + document.getElementById('lstretainer').value + ")";
            document.getElementById("divretainer").style.display = "none";
            //            document.getElementById('txtaddagencycommrateamt').value=""; //rajneesh jalendher  
            //            if(document.getElementById('txtaddagencycommrate')!=null)
            //            document.getElementById('txtaddagencycommrate').value="";
            if (document.getElementById('drpretainer').value != "" && document.getElementById('drpretainer').value != "0") {
                document.getElementById('txtRetainercomm').value = "";
                var retain_name = document.getElementById('drpretainer').value.split('(');
                var retain_code = retain_name[1].replace(')', '');
                //////////add retainer anuja
                var agencycodesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')')); /*bhanu*/
                var res = Booking_master.getretaineragencycheck(retain_code, document.getElementById('hiddencompcode').value, agencycodesubcode);
                ds = res.value;
                if (ds != null) {
                    if (ds.Tables.length > 1 && ds.Tables[1].Rows[0].Column1 == "N") {
                        alert("Retainer have no premission of this Agency");
                        document.getElementById('drpretainer').value = "";
                        return false;
                    }
                }
                //////////////////////////////////////
                var ds_ret = Booking_master.getRetainerComm(retain_code, document.getElementById('hiddencompcode').value);
                if (ds_ret.value == null)
                    return false;
                if (ds_ret.value.Tables[0].Rows.length > 0) {
                    document.getElementById('retcommtype').value = ds_ret.value.Tables[0].Rows[0].Discount;
                    document.getElementById('txtRetainercomm').value = ds_ret.value.Tables[0].Rows[0].retainercomm;
                    document.getElementById('retcomm').value = ds_ret.value.Tables[0].Rows[0].retainercomm;
                    if (document.getElementById('retcommtype').value == "Gross" && document.getElementById('txtgrossamt').value != "" && document.getElementById('txtRetainercomm').value != "" && document.getElementById('txtRetainercomm').value != null) {
                        document.getElementById('txtRetainercommamt').value = (parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) / 100).toFixed(2);
                    }
                    else if (document.getElementById('retcommtype').value == "Net" && document.getElementById('txtbillamt').value != "" && document.getElementById('txtRetainercomm').value != "" && document.getElementById('txtRetainercomm').value != null) {
                        document.getElementById('txtRetainercommamt').value = (parseFloat(document.getElementById('txtbillamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) / 100).toFixed(2);
                    }
                }
                var agencycodesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')')); /*bhanu*/
                var ds_ret_b = Booking_master.adretain_billbase_outstanding(document.getElementById('hiddencompcode').value, agencycodesubcode, retain_code, document.getElementById('txtdatetime').value, document.getElementById('hiddendateformat').value, document.getElementById('txtagencytype').value);
                if (ds_ret_b.value == null) {
                    alert(ds_ret_b.error.description);
                    return false;
                }
                if (ds_ret_b.value.Tables[0].Rows.length > 0) {
                    if (ds_ret_b.value.Tables[0].Rows[0].REC_COUNT != null && ds_ret_b.value.Tables[0].Rows[0].OUT_AMT != null) {
                        alert("This Retainer have " + ds_ret_b.value.Tables[0].Rows[0].REC_COUNT + " Pending Bill and Outstanding is " + ds_ret_b.value.Tables[0].Rows[0].OUT_AMT);
                    }
                }

            }
            changediv();
        }
            ///////////////for product

        else if (document.activeElement.id == "lstproduct") {
            if (document.getElementById('lstproduct').value == "0") {
                alert("Please select the product");
                return false;
            }
            document.getElementById("divproduct").style.display = "none";
            var datetime = document.getElementById('txtdatetime').value;

            var page = document.getElementById('lstproduct').value;
            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null;;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }

                httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&adtype=" + document.getElementById('hiddenadtype').value + "&datetime=" + datetime + "&value=2", false);
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
                xml.Open("GET", "clientName.aspx?page=" + page + "&adtype=" + document.getElementById('hiddenadtype').value + "&datetime=" + datetime + "&value=2", false);
                xml.Send();
                id = xml.responseText;
            }
            //document.getElementById('txtproduct').value = id;
            document.getElementById('drpproductcat').value = id;
            document.getElementById('drpbrand').focus();
            //Booking_master.getbrand(page, document.getElementById('hiddencompcode').value, call_bindproduct);
            return false;
        }
            ///this is for exec name
        else if (document.activeElement.id == "lstexec") {
            if (document.getElementById('lstexec').value == "0") {
                var a = "Executive name";
                if (browser != "Microsoft Internet Explorer") {
                    a = document.getElementById('lbececname').textContent.replace("*[F2]", "");
                }
                else {
                    a = document.getElementById('lbececname').innerText.replace("*[F2]", "");
                }
                alert("Please select the " + a);
                return false;
            }

            document.getElementById("divexec").style.display = "none";
            var datetime = document.getElementById('txtdatetime').value;

            var page = document.getElementById('lstexec').value;

            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null;;
                httpRequest = new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml');
                }
                httpRequest.onreadystatechange = function () { alertContents(httpRequest) };

                httpRequest.open("GET", "clientName.aspx?page=" + page + "&adtype=" + document.getElementById('hiddenadtype').value + "&datetime=" + datetime + "&value=3", false);
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
                xml.Open("GET", "clientName.aspx?page=" + page + "&adtype=" + document.getElementById('hiddenadtype').value + "&datetime=" + datetime + "&value=3", false);
                xml.Send();
                id = xml.responseText;
            }

            document.getElementById('txtexecname').value = id;
            var teamcode = id.substring(id.lastIndexOf('~') + 1, id.lastIndexOf('('));
            var teamname = id.substring(id.lastIndexOf('?') + 1, id.lastIndexOf('~'));
            document.getElementById('lblteamname').innerHTML = teamname;
            teamcode = page + '~' + teamcode;
            document.getElementById('hdnteamcode').value = id.substring(id.lastIndexOf('~') + 1, id.lastIndexOf('('));
            var agencycodesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')')); /*bhanu*/
            Booking_master.getexeczone(teamcode, document.getElementById('hiddencompcode').value, agencycodesubcode, call_bindexeczone);
            if (document.getElementById('txtagencyoutstand').disabled == false) {
                document.getElementById('txtagencyoutstand').focus();
            }
            else {
                //changediv();
                document.getElementById('drpretainer').focus();
            }
            return false;
        }
        else if (document.activeElement.id == "lstpackmgrp") 
        {
                  if (document.getElementById('lstpackmgrp').value == "0" || document.getElementById('lstpackmgrp').value == "") 
                   {
                        alert("Please select GROUP");
                        return false;
                    }
                    document.getElementById("divpackmgrp").style.display = "none";
                    var datetime = "";
                    var page = document.getElementById('lstpackmgrp').value;

                    var id = "";
                    var split = page.split("+");
                    var namecode = split[0];
                    var add = split[1];
                    document.getElementById('hdnpackmaingrp').value = add;
                    document.getElementById('txtpackmaingrp').value = namecode;
                        document.getElementById('txtpacksubgrp').focus();
                    return false;
                
        }
        else if (document.activeElement.id == "lstpacksgrp") 
        { 
                        if (document.getElementById('lstpacksgrp').value == "0"  || document.getElementById('lstpacksgrp').value == "") 
                        {
                            alert("Please select SUB GROUP");
                            return false;
                        }
                        document.getElementById("divpacksgrp").style.display = "none";
                        var datetime = "";
                        var page = document.getElementById('lstpacksgrp').value;

                        var id = "";
                        var split = page.split("+");
                        var namecode = split[0];
                        var add = split[1];
                        document.getElementById('hdnpacksubgrp').value = add;
                        document.getElementById('txtpacksubgrp').value = namecode;

                        if( document.getElementById('hdnpackmaingrp').value != "" ||document.getElementById('hdnpacksubgrp').value!="" ||document.getElementById('hdnpacksubgrp').value!="undefined")
                        {
                            var compcode = document.getElementById('hiddencompcode').value;
                            var varpacksubgrp = document.getElementById('hdnpacksubgrp').value;
                            var varpackmaingrp = document.getElementById('hdnpackmaingrp').value;
                       
                            Booking_master.bindpackagegroup(compcode,"DI0" ,"","",varpackmaingrp,varpacksubgrp ,call_fillpackage);
                            //return false;
                        }
                       
                        return false;
        }

        else if (document.activeElement.id == "drpretainer") {
            document.getElementById('LinkButton1').focus();
            document.getElementById('divpopup').style.display = "block";
            document.getElementById('hidehref').innerHTML = "Hide";
            var st_div = changediv();
            if (st_div == false)
                return false;
            if (document.getElementById('drpcolor').offsetWidth != "")
                document.getElementById('drpcolor').focus();
            event.keyCode = 13;
            return event.keyCode;
        }
        else if (document.activeElement.id == "txtcaption") {
            if (document.getElementById('drpmatsta').disabled != true) {
                document.getElementById('drpmatsta').focus();
                return false;
            }

        }
        else if (document.activeElement.id == "txtdummydate") {
            document.getElementById('chktfn').focus();
            return false;
        }
            //else if (document.activeElement.id == 'drpmatsta' && document.getElementById('txtbartertype').disabled == true) {
        else if (document.activeElement.id == 'txtcaption' && document.getElementById('txtbartertype').disabled == true) {
            document.getElementById('LinkButton5').focus();
            changepackage();
            return false;
            //  event.keyCode=13;
            //  return event.keyCode;    
        }
        else if (document.activeElement.id == 'txtbartertype') {
            document.getElementById('LinkButton5').focus();
            changepackage();
            event.keyCode = 13;
            return event.keyCode;
        }
        else if (document.activeElement.id == "txtpageno") {
            document.getElementById('LinkButton4').focus();
            changedivrate();
            event.keyCode = 13;
            return event.keyCode;
        }
        else if (document.activeElement.id == "txtextracharges") {
            if (document.getElementById('txtaddagencycommrate') != null)
                document.getElementById('txtaddagencycommrate').focus();
            return false;
        }
        else if (document.activeElement.id == "txtprintremark") {
            // document.getElementById('LinkButton2').focus();
            changediv1();
            // document.getElementById('drpadstype').focus();
            return false;
            //changedivrate();               
            //event.keyCode=13;
            //return event.keyCode;    
        }
        else if (document.activeElement.id == "btnshgrid") {
            if (event.keyCode == 9) {
                document.getElementById('LinkButton3').focus();
                event.keyCode = 13;
                return event.keyCode;
            }
        }
        else if (document.activeElement.id == "txtbillremark") {
            document.getElementById('LinkButton6').focus();
            //changedivrate();
            event.keyCode = 13;
            return event.keyCode;
        }

        else if (document.activeElement.id == "txtboxaddress") {
            document.getElementById('LinkButton7').focus();
            //changedivrate();
            event.keyCode = 13;
            return event.keyCode;
        }
        else if (document.activeElement.id == "txtagencyoutstand") {
            if (document.getElementById('txtexecname').value == "") {
                document.getElementById('drpretainer').focus();
                return false;
            }
            else {
                document.getElementById('LinkButton1').focus();
                event.keyCode = 13;
                return event.keyCode;
            }
        }
        else if (document.activeElement.id == "txtrodate") {
            if (document.getElementById('txtkeyno').disabled == false)
                document.getElementById('txtkeyno').focus();
            return false;
        }
        else if (document.activeElement.id == "txtclientadd") {
            if (document.getElementById('txtMobile').disabled == false)
                document.getElementById('txtMobile').focus();
            return false;
        }
        else if (document.activeElement.id == "Button1") {
            return event.keyCode;

        }
            //else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.id=="LinkButton1" || document.activeElement.id=="LinkButton2" || document.activeElement.id=="LinkButton3" || document.activeElement.id=="LinkButton4" || document.activeElement.id=="LinkButton5")
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
    else if (event.shiftKey == true && event.keyCode == 9) {
        if (document.activeElement.id == "drpbooktype") {
            if (document.getElementById('drpretainer').disabled == false)
                document.getElementById('drpretainer').focus();
            return false;
        }
            //        else if(document.activeElement.id=="txtprintremark")
            //        {
            //            document.getElementById('txtbillremark').focus();
            //            return false;
            //        }
        else if (document.activeElement.id == "drpadstype") {
            //document.getElementById('LinkButton1').focus();
            changepackage();
            return false;
        }
        else if (document.activeElement.id == "txtratecode") {
            //document.getElementById('LinkButton2').focus();
            changediv1();
            return false;
        }
        else if (document.activeElement.id == "chkcoupan") {
            //document.getElementById('LinkButton4').focus();        
            changediv();
            return false;
        }
        else if (document.activeElement.id == "drpbillcycle") {
            //document.getElementById('LinkButton5').focus();
            changedivrate();
            return false;
        }
        else if (document.activeElement.id == "drpboxcode") {
            //document.getElementById('LinkButton3').focus();
            changebilldiv();
            return false;
        }
        else if (document.activeElement.id == "txtvts") {
            //document.getElementById('LinkButton3').focus();
            openboxpopup();
            return false;
        }
    }
        ////this is  for short cut keys whern ctrl+d is press than ad detail tab is open
    else if (event.ctrlKey == true && (event.keyCode == 68 || event.keyCode == 100)) {
        if (document.getElementById('LinkButton1').disabled == false)
            changediv();
        return false;
    }
        ////when ctrl+g than page detail tab is open
    else if (event.ctrlKey == true && (event.keyCode == 71 || event.keyCode == 103))// && document.getElementById('LinkButton2').disabled==false)
    {
        if (document.getElementById('LinkButton2').disabled == false)
            changediv1();
        return false;
    }
        ////when ctrl+t than Rate detail tab is open
    else if (event.ctrlKey == true && (event.keyCode == 84 || event.keyCode == 116))// && document.getElementById('LinkButton4').disabled==false)
    {
        if (document.getElementById('LinkButton4').disabled == false)
            changedivrate();
        return false;
    }
        ////when ctrl+q than Rate detail tab is open and get rate buttion is clicked
    else if (event.ctrlKey == true && (event.keyCode == 81 || event.keyCode == 113))// && document.getElementById('LinkButton4').disabled == false && document.getElementById('btnshgrid').disabled == false) 
    {
        if (document.getElementById('LinkButton4').disabled == false && document.getElementById('btnshgrid').disabled == false) {
            changedivrate();
            checkGridDate_Validation();
        }
        return false;
    }
        ////when ctrl+k than package detail tab is open
    else if (event.ctrlKey == true && (event.keyCode == 75 || event.keyCode == 107))// && document.getElementById('LinkButton5').disabled==false)
    {
        if (document.getElementById('LinkButton5').disabled == false)
            changepackage();
        return false;
    }
        ////when ctrl+s than bill detail tab is open
    else if (event.ctrlKey == true && (event.keyCode == 83 || event.keyCode == 115))// && document.getElementById('LinkButton3').disabled==false)
    {
        if (document.getElementById('LinkButton3').disabled == false)
            changebilldiv();
        return false;
    }
        ////when ctrl+x than box detail tab is open
    else if (event.ctrlKey == true && (event.keyCode == 88 || event.keyCode == 120)) //&& document.getElementById('LinkButton6').disabled==false)
    {
        if (document.getElementById('LinkButton6').disabled == false)
            openboxpopup();
        return false;
    }
        ////when ctrl+y than Vts detail tab is open
    else if (event.ctrlKey == true && (event.keyCode == 89 || event.keyCode == 121))// && document.getElementById('LinkButton7').disabled==false)
    {
        if (document.getElementById('LinkButton7').disabled == false)
            openvts();
        return false;
    }

        ////when f8 save data
    else if (event.keyCode == 119 && document.getElementById('btnSave').disabled == false) {
        checkValidation();
    }
    else if ((event.keyCode == 9) && (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.id == "LinkButton1" || document.activeElement.id == "LinkButton2" || document.activeElement.id == "LinkButton3" || document.activeElement.id == "LinkButton4" || document.activeElement.id == "LinkButton5" || document.activeElement.type == "image")) {
        event.keyCode = 9;
        if (document.activeElement.id == "LinkButton1") {
            changediv1();
        }
        else if (document.activeElement.id == "LinkButton2") {
            changedivrate();
        }
        else if (document.activeElement.id == "LinkButton3") {
            openboxpopup();
        }
        else if (document.activeElement.id == "LinkButton4") {
            changepackage();
        }
        else if (document.activeElement.id == "LinkButton5") {
            changebilldiv();
        }
        else if (document.activeElement.id == "LinkButton6") {
            changediv();
        }
        return event.keyCode;
    }
}


function call_bindagsub(response) {
    ds = response.value;
    document.getElementById('txtagencytype').value = "";
    document.getElementById('txtagencystatus').value = "";
    document.getElementById('txtcreditperiod').value = "";
    document.getElementById('txtagencypaymode').value = "";
    document.getElementById('txttradedisc').value = "";
    document.getElementById('txttd').value = "";
    document.getElementById('txtdesignation').value = "";
    document.getElementById('hiddenagcommflag').value = "";
    document.getElementById('txtgrossamt').value = "";
    if (document.getElementById('txtaddagencycommrate') != null)
        document.getElementById('txtaddagencycommrate').value = "";

    document.getElementById('hiddentradedisc').value = "";
    document.getElementById('lstagency').options.length = 0;
    var pkgitem = document.getElementById("drpagscode");
    //pkgitem.options.length=0;
    // pkgitem.options[0] = new Option("-Select-","0");

    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 0;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name, ds.Tables[0].Rows[i].Agency_Code);
            pkgitem.options.length;
        }
    }

    getpayandstatus();


    return false;

}

function getpayandstatus() {
    document.getElementById('hiddensubcode').value = document.getElementById('drpagscode').value
    var subagency = document.getElementById("drpagscode").value;
    var datetime = document.getElementById('txtdatetime').value;
    var agencycode = document.getElementById('txtagency').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var dateformat = document.getElementById('hiddendateformat').value;

    if (subagency == "0") {
        alert("Please select sub agency");
        return false;
    }

    Booking_master.getpayandstatus(agencycodeglo, subagency, compcode, datetime, dateformat, document.getElementById('hiddenadtype').value, call_fillpay);
    return false;
}

function call_fillpay(res) {
    var ds = res.value;
    document.getElementById('hndagalert1').value = "";
    document.getElementById('txtgrossamt').value = "";
    document.getElementById('txtbillamt').value = "";
    if (ds.Tables[1].Rows.length > 0) {
        if (ds.Tables[1].Rows[0].status_name == "INACTIVE" || ds.Tables[1].Rows[0].status_name == "BANNED") {
            alert("You Can't Book Ad with InActive/Banned Agency");
            document.getElementById("drpagscode").options.length = 0;
            document.getElementById("txtagency").value = "";
            document.getElementById('txtagency').title = "";
            document.getElementById('txtagencytype').value = "";
            document.getElementById('txtagencystatus').value = "";
            document.getElementById('txtcreditperiod').value = "";
            document.getElementById('txtagencypaymode').value = "";
            document.getElementById('txttradedisc').value = "";
            document.getElementById('txttd').value = "";
            document.getElementById('txtdesignation').value = "";
            document.getElementById('hiddenagcommflag').value = "";
            document.getElementById('txtgrossamt').value = "";
            if (document.getElementById('txtaddagencycommrate') != null)
                document.getElementById('txtaddagencycommrate').value = "";

            document.getElementById('hiddentradedisc').value = "";
            //
            document.getElementById('txtagencyaddress').value = "";
            document.getElementById('txtagencyaddress').title = "";
            document.getElementById("txtagency").focus();
            return false;
        }
    }
    if (ds != null) {
        if (ds.Tables[2].Rows[0].CREDIT_LIMIT != "" && ds.Tables[2].Rows[0].CREDIT_LIMIT != null) {
            if (parseFloat(ds.Tables[7].Rows[0].outstand) > parseFloat(ds.Tables[2].Rows[0].CREDIT_LIMIT) && (ds.Tables[7].Rows[0].OUTSTANDING_AMT_CRITERIA != null && ds.Tables[7].Rows[0].OUTSTANDING_AMT_CRITERIA != '3')) {
                if (!confirm('Outstanding amount of this agency exceeding the Credit Limit. Do you still want to book an Advertisement?')) {
                    document.getElementById("drpagscode").options.length = 0;
                    document.getElementById("txtagency").value = "";
                    document.getElementById('txtagency').title = "";
                    document.getElementById('txtagencytype').value = "";
                    document.getElementById('txtagencystatus').value = "";
                    document.getElementById('txtcreditperiod').value = "";
                    document.getElementById('txtagencypaymode').value = "";
                    document.getElementById('txttradedisc').value = "";
                    document.getElementById('txttd').value = "";
                    document.getElementById('txtdesignation').value = "";
                    document.getElementById('hiddenagcommflag').value = "";
                    document.getElementById('txtgrossamt').value = "";
                    if (document.getElementById('txtaddagencycommrate') != null)
                        document.getElementById('txtaddagencycommrate').value = "";

                    document.getElementById('hiddentradedisc').value = "";
                    //
                    document.getElementById('txtagencyaddress').value = "";
                    document.getElementById('txtagencyaddress').title = "";
                    document.getElementById("txtagency").focus();
                    return false;
                }
            }
        }

        bindBookType_Agency();
        if (ds.Tables[2].Rows[0].VAT != null) {
            if (ds.Tables[2].Rows[0].VAT == "1")
                vat_app = "1";
            else
                vat_app = "0";

        }
        if (ds.Tables[2].Rows[0].EDTN_WISE_BILL_REQ != null) {
            if (ds.Tables[2].Rows[0].EDTN_WISE_BILL_REQ == "Y")
                if (roundoff != "off")
                    roundoff = "editionwise";
        }
        else {
            if (roundoff != "off")
                roundoff = "insertionwise";
        }
        if (ds.Tables[2].Rows[0].BOOKING_TYPE != null && ds.Tables[2].Rows[0].BOOKING_TYPE != "") {
            var btype = ds.Tables[2].Rows[0].BOOKING_TYPE;
            btype = btype.split(",");
            var k = btype.length;
            var obj = document.getElementById('drpbooktype');
            var len = obj.options.length;
            for (var i = 0; i < k; i++) {
                for (var j = 0; j < len; j++) {
                    if (obj[j].value == btype[i]) {
                        obj[j].label = "R";
                    }
                }
            }

            for (var j = 0; j < len;) {
                if (obj[j].label != "R") {
                    obj.options.remove(j);
                    len = len - 1;

                    //j=0;
                }
                else {
                    obj[j].label = "";
                    len = len - 1;
                    j++
                }
            }
        }
        document.getElementById('txtagency').title = document.getElementById('txtagency').value;
        document.getElementById('txtagencyaddress').title = document.getElementById('txtagencyaddress').value;
        if (ds.Tables[0].Rows.length > 0)
            document.getElementById('txtagencytype').value = ds.Tables[0].Rows[0].agency_type_name
        if (ds.Tables[1].Rows.length > 0) {
            document.getElementById('txtagencystatus').value = ds.Tables[1].Rows[0].status_name;
            document.getElementById('hiddenstatus').value = ds.Tables[1].Rows[0].status_name;

        }
        if (ds.Tables[2].Rows.length > 0) {
            document.getElementById('txtdesignation').value = ds.Tables[2].Rows[0].AGENCY_DESIGNATION;
            document.getElementById('txtcreditperiod').value = ds.Tables[2].Rows[0].Credit_Days;
            if (ds.Tables[2].Rows[0].ALERT != null && ds.Tables[2].Rows[0].ALERT != "") {
                document.getElementById('hndagalert1').value = ds.Tables[2].Rows[0].ALERT;
                alert(ds.Tables[2].Rows[0].ALERT);
            }
            if (ds.Tables[2].Rows[0].AGENCY_DEAL_ALERT != null && ds.Tables[2].Rows[0].AGENCY_DEAL_ALERT != "") {
                alert("Agency has this Deal " + ds.Tables[2].Rows[0].AGENCY_DEAL_ALERT);
            }
        }
        if (ds.Tables.length > 7) {
            if (ds.Tables[7].Rows.length > 0) {
                document.getElementById('txtagencyoutstand').value = ds.Tables[7].Rows[0].outstand;
            }
        }

        if (ds.Tables[3].Rows.length > 0) {

            document.getElementById('drpbillcycle').value = ds.Tables[3].Rows[0].BILL_FREQUENCY;
            ///////////////////////anuja//////////////
            if (ds.Tables[3].Rows[0].EXECUTIVE_NAME != null) {
                document.getElementById('txtexecname').value = ds.Tables[3].Rows[0].EXECUTIVE_NAME;
            }
            if (ds.Tables[3].Rows[0].RETAINER_NAME != null) {
                document.getElementById('drpretainer').value = ds.Tables[3].Rows[0].RETAINER_NAME;
            }
            if (ds.Tables[3].Rows[0].CLIENT_NAME != null) {
                document.getElementById('txtclient').value = ds.Tables[3].Rows[0].CLIENT_NAME;
            }
        }

        if (ds.Tables[4].Rows.length > 0) {
            if (ds.Tables[4].Rows[0].CASH_DISCOUNT1 != null)
                document.getElementById('txtcashdiscount').value = ds.Tables[4].Rows[0].CASH_DISCOUNT1;
            if (ds.Tables[4].Rows[0].CASH_DISCOUNT != null)
                document.getElementById('txtcashdiscount').value = ds.Tables[4].Rows[0].CASH_DISCOUNT;
            if (ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1 != null)
                document.getElementById('hiddencashrecieved').value = ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1;
            if (ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE != null)
                document.getElementById('hiddencashrecieved').value = ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE;
            document.getElementById('txttradedisc').value = ds.Tables[4].Rows[0].comm_rate;
            document.getElementById('txttd').value = ds.Tables[4].Rows[0].comm_rate;
            document.getElementById('hiddenagcommflag').value = ds.Tables[4].Rows[0].FLAG;
            document.getElementById('txtgrossamt').value = "";
            if (ds.Tables[4].Rows[0].Addl_Comm_Rate != null && document.getElementById('txtaddagencycommrate') != null)
                document.getElementById('txtaddagencycommrate').value = ds.Tables[4].Rows[0].Addl_Comm_Rate;
            document.getElementById('hiddentradedisc').value = document.getElementById('txttradedisc').value;
            gbtradedisc = ds.Tables[4].Rows[0].comm_rate;
            document.getElementById('hiddencattype').value = ds.Tables[4].Rows[0].agencytypecode;
            ////            if(document.getElementById('txtgrossamt').value!="")
            ////            {
            ////                getagrredamou();
            ////            }
        }
        else {
            alert("Please update the " + document.getElementById('txtagency').value + " Commission detail");
            document.getElementById("txtagency").value = "";
            document.getElementById('txtagencytype').value = "";
            document.getElementById('txtagencystatus').value = "";
            document.getElementById('txtcreditperiod').value = "";
            document.getElementById('txtagencypaymode').value = "";
            document.getElementById('txttradedisc').value = "";
            document.getElementById('txttd').value = "";
            document.getElementById('txtdesignation').value = "";
            document.getElementById('hiddenagcommflag').value = "";
            document.getElementById('txtgrossamt').value = "";
            if (document.getElementById('txtaddagencycommrate') != null)
                document.getElementById('txtaddagencycommrate').value = "";
            document.getElementById('hiddentradedisc').value = "";
            //
            document.getElementById('txtagencyaddress').value = "";
            document.getElementById("txtagency").focus();
            return false;
        }
        if (ds.Tables[5].Rows.length > 0) {
            ///this is to bind the payment drop down and bill to drop down
            var pkgitem = document.getElementById('txtagencypaymode');
            var billobj = document.getElementById('drppaymenttype');
            pkgitem.options.length = 0;
            billobj.options.length = 0;
            billobj.options[0] = new Option("Select", "0");
            billobj.options.length;
            //pkgitem.options[0]=new Option("--Select City--","0");
            //alert(pkgitem.options.length);
            for (var i = 0; i < ds.Tables[5].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[5].Rows[i].payment_mode_name, ds.Tables[5].Rows[i].pay_mode_code);
                billobj.options[billobj.options.length] = new Option(ds.Tables[5].Rows[i].payment_mode_name, ds.Tables[5].Rows[i].pay_mode_code);

                billobj.options.length;
                pkgitem.options.length;

            }
            if (document.getElementById('hdndefpayment').value == null || document.getElementById('hdndefpayment').value == "") {
                document.getElementById('txtagencypaymode').value = ds.Tables[5].Rows[0].pay_mode_code;
                document.getElementById('drppaymenttype').value = ds.Tables[5].Rows[0].pay_mode_code;
                document.getElementById('hiddenpay').value = ds.Tables[5].Rows[0].pay_mode_code;
                document.getElementById('hiddenbillpay').value = ds.Tables[5].Rows[0].pay_mode_code;
            }
            else {
                document.getElementById('txtagencypaymode').value = document.getElementById('hdndefpayment').value;
                document.getElementById('drppaymenttype').value = document.getElementById('hdndefpayment').value;
                document.getElementById('hiddenpay').value = document.getElementById('hdndefpayment').value;
                document.getElementById('hiddenbillpay').value = document.getElementById('hdndefpayment').value;
            }
            var ag = Booking_master.GETCASH_PAY(document.getElementById('hiddencompcode').value, document.getElementById('drppaymenttype').value);
            var ds_n = ag.value;
            var cashdiscount = 'N';
            if (ds_n != null && ds_n.Tables[0].Rows.length > 0) {
                cashdiscount = ds_n.Tables[0].Rows[0].CASHDISCOUNT;
            }
            ///if pay mode is credit card than open the card name,its type and no div
            if (document.getElementById('drppaymenttype').value == "CA0")  //CR0 is Credit Card code
            {
                document.getElementById('cashrecvd').style.display = "";
                // document.getElementById('tdcashrecvd').style.display="";
                // document.getElementById('drpcashrecieved').value=executequery.Tables[0].Rows[0].CASH_RECIEVED;
                document.getElementById('drpcashrecieved').disabled = false;
                document.getElementById('txtcashdiscount').disabled = false;
                document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value;
            }
            else if (document.getElementById('drppaymenttype').value == "CR0")  //CR0 is Credit Card code
            {
                document.getElementById('tdcarname').style.display = "";
                document.getElementById('tdtxtcarname').style.display = "";
                document.getElementById('tdtype').style.display = "";
                document.getElementById('tddrptyp').style.display = "";
                document.getElementById('tdexdat').style.display = "";

                document.getElementById('tdtxtexdat').style.display = "";
                document.getElementById('tdcardno').style.display = "";
                document.getElementById('tdtxtcarno').style.display = "";
                document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value;

                //             document.getElementById('txtcardname').disabled=false;
                //            document.getElementById('drptype').disabled=false;
                //            document.getElementById('drpmonth').disabled=false;
                //            document.getElementById('drpyear').disabled=false;
                //            document.getElementById('txtcardno').disabled=false;

                document.getElementById('tdrec').style.display = "none";
                document.getElementById('receipt').style.display = "none";
                document.getElementById('print').style.display = "none";

                document.getElementById('tdchqno').style.display = "none";
                document.getElementById('tdchqdate').style.display = "none";
                document.getElementById('tdchqamt').style.display = "none";
                document.getElementById('tdbankname').style.display = "none";

                document.getElementById('tdtextchqno').style.display = "none";
                document.getElementById('tdtextchqdate').style.display = "none";
                document.getElementById('tdtextchqamt').style.display = "none";
                document.getElementById('tdtextbankname').style.display = "none";
                document.getElementById('cashrecvd').style.display = "none";
                document.getElementById("txtreceipt").value = "";
            }
            else if (document.getElementById('drppaymenttype').value == "CH0" || document.getElementById('drppaymenttype').value == "DD0" || document.getElementById('drppaymenttype').value == 'PO0')  //CR0 is Credit Card code and DD0 is demand draft
            {
                //            document.getElementById('ttextchqno').disabled = false;
                //            document.getElementById('ttextchqdate').disabled = false;
                //            document.getElementById('ttextchqamt').disabled = false;
                //            document.getElementById('ttextbankname').disabled = false;
                document.getElementById('tdchqno').style.display = "";
                document.getElementById('tdchqdate').style.display = "";
                document.getElementById('tdchqamt').style.display = "";
                document.getElementById('tdbankname').style.display = "";

                document.getElementById('tdtextchqno').style.display = "";
                document.getElementById('tdtextchqdate').style.display = "";
                document.getElementById('tdtextchqamt').style.display = "";
                document.getElementById('tdtextbankname').style.display = "";
                document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value;

                document.getElementById('tdrec').style.display = "none";
                document.getElementById('receipt').style.display = "none";
                document.getElementById('print').style.display = "none";
                document.getElementById('tdcarname').style.display = "none";
                document.getElementById('tdtxtcarname').style.display = "none";
                document.getElementById('tdtype').style.display = "none";
                document.getElementById('tddrptyp').style.display = "none";
                document.getElementById('tdexdat').style.display = "none";

                document.getElementById('tdtxtexdat').style.display = "none";
                document.getElementById('tdcardno').style.display = "none";
                document.getElementById('tdtxtcarno').style.display = "none";
                document.getElementById('cashrecvd').style.display = "none";
                document.getElementById("txtreceipt").value = "";
            }
            else {
                document.getElementById('tdcarname').style.display = "none";
                document.getElementById('tdtxtcarname').style.display = "none";
                document.getElementById('tdtype').style.display = "none";
                document.getElementById('tddrptyp').style.display = "none";
                document.getElementById('tdexdat').style.display = "none";

                document.getElementById('tdtxtexdat').style.display = "none";
                document.getElementById('tdcardno').style.display = "none";
                document.getElementById('tdtxtcarno').style.display = "none";

                document.getElementById('txtcardname').value = "";
                document.getElementById('drptype').value = "0";
                document.getElementById('drpmonth').value = "0";
                document.getElementById('drpyear').value = "0";
                document.getElementById('txtcardno').value = "";
                document.getElementById("txtreceipt").value = "";

                document.getElementById('tdchqno').style.display = "none";
                document.getElementById('tdchqdate').style.display = "none";
                document.getElementById('tdchqamt').style.display = "none";
                document.getElementById('tdbankname').style.display = "none";

                document.getElementById('tdtextchqno').style.display = "none";
                document.getElementById('tdtextchqdate').style.display = "none";
                document.getElementById('tdtextchqamt').style.display = "none";
                document.getElementById('tdtextbankname').style.display = "none";

                document.getElementById('ttextchqno').value = "";
                document.getElementById('ttextchqdate').value = "";
                document.getElementById('ttextchqamt').value = "";
                document.getElementById('ttextbankname').value = "";
                document.getElementById('cashrecvd').style.display = "none";
                document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value;
            }
            if (cashdiscount == 'Y') {
                document.getElementById('cashrecvd').style.display = "";
                // document.getElementById('tdcashrecvd').style.display="";
                // document.getElementById('drpcashrecieved').value=executequery.Tables[0].Rows[0].CASH_RECIEVED;
                document.getElementById('drpcashrecieved').disabled = false;
                document.getElementById('txtcashdiscount').disabled = false;
                document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value;
            }
            else {
                document.getElementById('cashrecvd').style.display = "none";
            }
            ///////if pay mode is check,cash or current dated chk than show the div of receipt no and hide vts and no. of invoices
            /*        if(ds.Tables[5].Rows[0].pay_mode_code=="CA0" || ds.Tables[5].Rows[0].pay_mode_code=="CH0" || ds.Tables[5].Rows[0].pay_mode_code=="CA1" || ds.Tables[5].Rows[0].pay_mode_code=="DD0")
            {
            document.getElementById('tdrec').style.display="block";
            document.getElementById('receipt').style.display="block";
            document.getElementById('print').style.display="block";   
                         
            //                         document.getElementById('vts').style.display="none";
            //                         document.getElementById('tdvts').style.display="none";
            //                         document.getElementById('invoice').style.display="none";
            //                         document.getElementById('tdinvoice').style.display="none";
            ////to generate the receipt no. auto
            if(document.getElementById('receipt').style.display=="block")
            {
            var pre=document.getElementById("hiddenprefix").value
            var suf=document.getElementById("hiddensufix").value
            var center="";
            var preferreceipt=document.getElementById('hiddenprereceipt').value;
                                
            var zero="";
            if(ds.Tables[6].Rows.length>0  && ds.Tables[6].Rows[0].recno!=null)
            {                            
            var val=ds.Tables[6].Rows[0].recno;
            var vallen=val.toString().length;
            //val=parseInt(val)+1;
                                
            //var tempno = Convert.ToString(xy1);
                                  
            if(preferreceipt=="1")
            {
            center=document.getElementById('txtbranch').value.substring(0,3);
                               
            }
            else if(preferreceipt=="2")
            {
            center=document.getElementById('txtagency').value.substring(0,3);
            }
            if(vallen==0)
            {
            zero="000000";
            }
            else if(vallen==1)
            {
            zero="00000"+val;
            }
            else if(vallen==2)
            {
            zero="0000"+val;
            }
            else if(vallen==3)
            {
            zero="000"+val;
            }
            else if(vallen==4)
            {
            zero="000"+val;
            }
            else if(vallen==5)
            {
            zero="00"+val;
            }    
            else if(vallen==6)
            {
            zero="0"+val;
            }
            document.getElementById("txtreceipt").value=center+zero;
            if(preferreceipt=="3")
            {
            document.getElementById("txtreceipt").value="";
            document.getElementById("txtreceipt").value=pre+val+suf;
            }
            //document.getElementById("txtreceipt").value=pre+val+suf;
            }
            else
            {
            document.getElementById("txtreceipt").value=pre+0000+suf;
            }
                            
            }
            document.getElementById('hiddenreceiptno').value=document.getElementById("txtreceipt").value
            
            } */
            //Comment on24th Oct,09
        }
        if (document.getElementById('txtagencystatus').value == "Banned") {
            alert("You Cannot book the ad with this agency");
            return false;
        }
        bind_agen_bill();
    }

}



///////////////this is to bind the product name hiddenbillpay
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
    if (document.getElementById("lstproduct").style.visibility == "hidden")
        document.getElementById("lstproduct").style.visibility = "visible";
    document.getElementById("lstproduct").focus();

    return false;

}

///this is to bind the brand on change of product

function call_bindproduct(response) {
    ds = response.value;
    var pkgitem = document.getElementById("drpbrand");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].brand_name, ds.Tables[0].Rows[i].brand_code);
            pkgitem.options.length;
        }
    }
    return false;
}

//this is to bind the list box for exec name

function bindexecname_callback(response) {
    ds = response.value;
    var pkgitem = document.getElementById("lstexec");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name + "(" + ds.Tables[0].Rows[i].exe_no + ")", ds.Tables[0].Rows[i].exe_no);
            pkgitem.options.length;
        }
    }
    document.getElementById('txtexecname').value = "";
    document.getElementById("lstexec").value = "0";
    if (document.getElementById("lstexec").style.visibility == "hidden")
        document.getElementById("lstexec").style.visibility = "visible";
    document.getElementById("lstexec").focus();
    return false;

}
///this is to bind zone on change of list box of exec

function call_bindexeczone(res) {
    var ds = res.value;
    if (document.getElementById('drpretainer').value != '0' && document.getElementById('drpretainer').value != '' && retexeboth != "both") {
        var a = "Executive name";
        if (browser != "Microsoft Internet Explorer") {
            a = document.getElementById('lbececname').textContent.replace("*[F2]", "");
        }
        else {
            a = document.getElementById('lbececname').innerText.replace("*[F2]", "");
        }
        if (confirm('Are you sure you want to Take ' + a)) {
            document.getElementById('drpretainer').value = "";
            document.getElementById('txtRetainercomm').value = "";
            document.getElementById('txtRetainercommamt').value = ""
        }
        else {
            document.getElementById('txtexeczone').value = "";
            document.getElementById('txtexecname').value = "";
            return false;
        }
    }
    if (ds != null) {
        if (ds.Tables.length > 1 && ds.Tables[1].Rows[0].Column1 == "N") {
            alert("Executive have no premission of this Agency");
            document.getElementById('txtexeczone').value = "";
            document.getElementById('txtexecname').value = "";
            return false;
        }
    }
    if (ds != null) {
        if (ds.Tables[0].Rows.length > 0) {
            document.getElementById('txtexeczone').value = ds.Tables[0].Rows[0].zone_name
            document.getElementById('hiddenzone').value = document.getElementById('txtexeczone').value;
        }
    }
    if (ds != null) {
        var exec_name = document.getElementById('txtexecname').value.split('(');
        var exec_code = exec_name[1].replace(')', '');
        var agencycodesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')')); /*bhanu*/
        var ds_ret_b = Booking_master.adexec_billbase_outstanding(document.getElementById('hiddencompcode').value, agencycodesubcode, exec_code, document.getElementById('txtdatetime').value, document.getElementById('hiddendateformat').value, document.getElementById('txtagencytype').value);
        if (ds_ret_b.value == null) {
            alert(ds_ret_b.error.description);
            return false;
        }
        if (ds_ret_b.value.Tables[0].Rows.length > 0) {
            if (ds_ret_b.value.Tables[0].Rows[0].REC_COUNT != null && ds_ret_b.value.Tables[0].Rows[0].OUT_AMT != null) {
                alert("This Executive have " + ds_ret_b.value.Tables[0].Rows[0].REC_COUNT + " Pending Bill and Outstanding is " + ds_ret_b.value.Tables[0].Rows[0].OUT_AMT);
            }
        }
    }
}

//this is to bind the bill to drop down on change of agency s code
function bind_agen_bill() {
    var compcode = document.getElementById('hiddencompcode').value
    if (agencycodeglo == "undefined" || agencycodeglo == undefined || agencycodeglo == "") {
        //alert("bhanu");
        agencycodeglo = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
    }
    if (agencycodeglo != "undefined" && agencycodeglo != undefined)
        Booking_master.bindbillto_ag(agencycodeglo, compcode, call_bindbillto);
}


function call_bindbillto(response) {
    ds = response.value;
    var pkgitem = document.getElementById("drpbillto");

    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 0;
        var client_val = document.getElementById('txtclient').value;
        var client_name = document.getElementById('txtclient').value;
        if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0) {
            client_val = document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(") + 1, document.getElementById('txtclient').value.length - 1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
            client_name = document.getElementById('txtclient').value.substring(0, document.getElementById('txtclient').value.lastIndexOf("("));
            alertfun();
        }
        pkgitem.options[0] = new Option(client_name, client_val);

        //pkgitem.options[0]=new Option("-Client-","client");
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            if (ds.Tables[0].Rows[i].bill_to == "")
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name, ds.Tables[1].Rows[0].sub_agency_code);
            else
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name, ds.Tables[0].Rows[i].bill_to);
            // pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].bill_to);                
            pkgitem.options.length;
        }
        //          if(pkgitem.options.length > 1)
        //          pkgitem.options.options[1].selected = true;

    }
    if (ds.Tables[1].Rows.length > 0) {
        document.getElementById("drpbillto").value = ds.Tables[1].Rows[0].sub_agency_code
        document.getElementById('hiddenbillto').value = ds.Tables[1].Rows[0].sub_agency_code
    }
    // alert(document.getElementById("drpbillto").value);
    return false;
}

function bindretainer_callback(res) {
    var ds = res.value;
    var pkgitem = document.getElementById("lstretainer");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select-", "0");

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
function documentClick(event) {
    if (browser != "Microsoft Internet Explorer") {
        //          document.activeElement.id=arguments[0].target.id == "uploadA")
        var activeid = arguments[0].target.id;
        if (activeid == "" && document.activeElement.id != "")
            activeid = document.activeElement.id;
        if (activeid.indexOf("btn_Pg_") == 0) {
            getButtonIdGrid(event);
        }
        else if (activeid.indexOf("ins") == 0 && document.getElementById(activeid).title != "") {
            opencopyDivInsertion(activeid);
        }
        else if (activeid.indexOf("vtsbtn") == 0) {
            openVtsPopup(activeid);
        }
        else if (activeid.indexOf("splt") == 0) {
            var n1 = activeid;

            var idnum = document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('splt', ''), 10) + 1].cells[1].innerHTML;
            var editid = "edit" + idnum;
            opensplitedition(document.getElementById(editid).value, idnum);
        }
        else if (activeid.indexOf("subedi") == 0) {
            if (document.getElementById('txttotalarea').value == "") {
                alert("Please fill Size");
                return false;
            }
            var n1 = activeid;
            var idnum = activeid.replace("subedi", "");
            var editid = "edit" + idnum;
            var size = "siz" + idnum;
            var hei = "hei" + idnum;
            var wid = "wid" + idnum;
            var id = "Text" + idnum;
            var pageno_inserts = "pagno" + idnum;
            var data = "subedidata" + idnum;
            showid = "sho" + idnum;
            var insertsta = "inssta" + idnum;
            var showidval = "";
            var pkgcode = "hiddenpckcode" + idnum;
            if (document.getElementById(showid) != null)
                showidval = document.getElementById(showid).value;
            var pkglength = document.getElementById('drppackagecopy').options.length;
            var pkgname = document.getElementById('drppackagecopy').options[0].value;
            pkgname = pkgname.replace('+', '~');
            window.open('booking_subeditiondetail.aspx?pkgname=' + pkgname + '&adtype=DI0&pkglength=' + pkglength + '&package=' + document.getElementById(pkgcode).value + '&cioid=' + document.getElementById('txtciobookid').value + '&uomdesc=' + document.getElementById('hiddenuomdesc').value + '&compcode=' + document.getElementById('hiddencompcode').value + '&insertdate=' + document.getElementById(id).value + '&width=' + document.getElementById(wid).value + '&data=' + document.getElementById(data).value + '&height=' + document.getElementById(hei).value + '&edition=' + document.getElementById(editid).value + '&insertid=' + showidval + '&insertstatus=' + document.getElementById(insertsta).value + '&btnstatus=' + chkbtnStatus + '&totarea=' + document.getElementById(size).value + '&idnum=' + idnum + '&dateformat=' + document.getElementById('hiddendateformat').value + '&receiptno=' + document.getElementById('txtreceipt').value + '&pageno=' + document.getElementById(pageno_inserts).value + '&chkuserperm=' + document.getElementById(hdnchkdetailperm).value, 'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=560px,height=300px');
        }
        else if (activeid.indexOf("pagno") == 0) {
            rateenter(event);
        }
        else if (activeid.indexOf("uploadA") == 0) {
            uploadimageall();
        }
        else if (activeid.indexOf("upload") == 0 && activeid.indexOf("uploadA") < 0) {
            var n1 = activeid;
            var idnum = document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('upload', ''), 10) + 1].cells[1].innerHTML;
            return uploadimage(n1.replace('upload', 'pic'), idnum, n1.replace('upload', 'edit'), n1.replace('upload', 'fil'), n1.replace('upload', ''));
        }

        else if (activeid.indexOf("aglist") == 0) {
            FillSubCatinGrid();
        }
        else if (activeid.indexOf("pai") == 0) {
            document.getElementById('txtgrossamt').value = "";
            document.getElementById('txtbillamt').value = "";
            if (document.getElementById(activeid).value == "Y") {
                paivar = "Y";
            }
            else {
                paivar = "";
            }
        }
    }
    else {
        if (document.activeElement.id.indexOf("btn_Pg_") == 0) {
            getButtonIdGrid();
        }
        else if (document.activeElement.id.indexOf("ins") == 0 && document.getElementById(document.activeElement.id).title != "") {
            opencopyDivInsertion(document.activeElement.id);
        }
        else if (document.activeElement.id.indexOf("vtsbtn") == 0) {
            openVtsPopup(document.activeElement.id);
        }
        else if (document.activeElement.id.indexOf("splt") == 0) {
            var n1 = document.activeElement.id;

            var idnum = document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('splt', ''), 10) + 1].cells[1].innerHTML;
            var editid = "edit" + idnum;
            opensplitedition(document.getElementById(editid).value, idnum);
        }
        else if (document.activeElement.id.indexOf("subedi") == 0) {
            if (document.getElementById('txttotalarea').value == "") {
                alert("Please fill Size");
                return false;
            }
            var n1 = document.activeElement.id;
            var idnum = document.activeElement.id.replace("subedi", "");
            var editid = "edit" + idnum;
            var size = "siz" + idnum;
            var hei = "hei" + idnum;
            var wid = "wid" + idnum;
            var id = "Text" + idnum;
            var pageno_inserts = "pagno" + idnum;
            var data = "subedidata" + idnum;
            showid = "sho" + idnum;
            var insertsta = "inssta" + idnum;
            var showidval = "";
            var pkgcode = "hiddenpckcode" + idnum;
            if (document.getElementById(showid) != null)
                showidval = document.getElementById(showid).value;
            var pkglength = document.getElementById('drppackagecopy').options.length;
            var pkgname = document.getElementById('drppackagecopy').options[0].value;
            pkgname = pkgname.replace('+', '~');
            window.open('booking_subeditiondetail.aspx?pkgname=' + pkgname + '&adtype=DI0&pkglength=' + pkglength + '&package=' + document.getElementById(pkgcode).value + '&cioid=' + document.getElementById('txtciobookid').value + '&uomdesc=' + document.getElementById('hiddenuomdesc').value + '&compcode=' + document.getElementById('hiddencompcode').value + '&insertdate=' + document.getElementById(id).value + '&width=' + document.getElementById(wid).value + '&data=' + document.getElementById(data).value + '&height=' + document.getElementById(hei).value + '&edition=' + document.getElementById(editid).value + '&insertid=' + showidval + '&insertstatus=' + document.getElementById(insertsta).value + '&btnstatus=' + chkbtnStatus + '&totarea=' + document.getElementById(size).value + '&idnum=' + idnum + '&dateformat=' + document.getElementById('hiddendateformat').value + '&receiptno=' + document.getElementById('txtreceipt').value + '&pageno=' + document.getElementById(pageno_inserts).value + '&chkuserperm=' + document.getElementById('hdnchkdetailperm').value, 'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=560px,height=300px');
        }
        else if (document.activeElement.id.indexOf("pagno") == 0) {
            rateenter(event);
        }
        else if (document.activeElement.id.indexOf("uploadA") == 0) {
            uploadimageall();
        }
        else if (document.activeElement.id.indexOf("upload") == 0 && document.activeElement.id.indexOf("uploadA") < 0) {
            var n1 = document.activeElement.id;
            var idnum = document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('upload', ''), 10) + 1].cells[1].innerHTML;
            return uploadimage(n1.replace('upload', 'pic'), idnum, n1.replace('upload', 'edit'), n1.replace('upload', 'fil'), n1.replace('upload', ''));
        }

        else if (document.activeElement.id.indexOf("aglist") == 0) {
            FillSubCatinGrid();
        }
        else if (document.activeElement.id.indexOf("pai") == 0) {
            document.getElementById('txtgrossamt').value = "";
            document.getElementById('txtbillamt').value = "";
            if (document.getElementById(document.activeElement.id).value == "Y") {
                paivar = "Y";
            }
            else {
                paivar = "";
            }
        }
    }
}
function openVtsPopup(id) {
    win = window.open('advts.aspx?id=' + id + '&mode=' + chkbtnStatus, 'Ankur1', 'toolbar=0,resizable=0,top=244,left=210,scrollbars=yes,width=480px,height=200px');
    win.focus();
}
function fillvts() {
    if (document.getElementById('txtcirrate').value == "") {
        alert("Please Select Rate by Pressing F2");
        document.getElementById('txtcirrate').focus();
        return false;
    }
    else if (document.getElementById('txtciredition').value == "") {
        alert("Please Select Edition");
        return false;
    }
    else if (document.getElementById('txtvts').value == "") {
        alert("Please Select No. Of Copies");
        document.getElementById('txtvts').focus();
        return false;
    }
    else if (document.getElementById('txtpubdate').value == "") {
        alert("Please Enter Publish Date");
        document.getElementById('txtpubdate').focus();
        return false;
    }
    var dateformat = document.getElementById('hiddendateformat').value;
    var currdate = window.opener.document.getElementById('txtdatetime').value;
    if (dateformat == "yyyy/mm/dd") {
        var yearfield = currdate.split("/")[0]
        var monthfield = currdate.split("/")[1]
        var dayfield = currdate.split("/")[2]
        var currd = new Date(yearfield, monthfield - 1, dayfield)
    }
    if (dateformat == "mm/dd/yyyy") {
        var yearfield = currdate.split("/")[2]
        var monthfield = currdate.split("/")[0]
        var dayfield = currdate.split("/")[1]
        //var dayobj = new Date(monthfield-1, dayfield, yearfield)
        var currd = new Date(yearfield, monthfield - 1, dayfield)

    }
    if (dateformat == "dd/mm/yyyy") {
        var yearfield = currdate.split("/")[2]
        var monthfield = currdate.split("/")[1]
        var dayfield = currdate.split("/")[0]
        //var dayobj = new Date(dayfield, monthfield-1, yearfield)
        var currd = new Date(yearfield, monthfield - 1, dayfield)
    }

    var pubdate = document.getElementById('txtpubdate').value;
    if (dateformat == "yyyy/mm/dd") {
        var yearfield = pubdate.split("/")[0]
        var monthfield = pubdate.split("/")[1]
        var dayfield = pubdate.split("/")[2]
        var pubd = new Date(yearfield, monthfield - 1, dayfield)
    }
    if (dateformat == "mm/dd/yyyy") {
        var yearfield = pubdate.split("/")[2]
        var monthfield = pubdate.split("/")[0]
        var dayfield = pubdate.split("/")[1]
        //var dayobj = new Date(monthfield-1, dayfield, yearfield)
        var pubd = new Date(yearfield, monthfield - 1, dayfield)

    }
    if (dateformat == "dd/mm/yyyy") {
        var yearfield = pubdate.split("/")[2]
        var monthfield = pubdate.split("/")[1]
        var dayfield = pubdate.split("/")[0]
        //var dayobj = new Date(dayfield, monthfield-1, yearfield)
        var pubd = new Date(yearfield, monthfield - 1, dayfield)
    }
    if (pubd < currd) {
        alert("Publish Date can't be less than Current Date");
        return false;
    }
    window.opener.document.getElementById('txtbillamt').value = "";
    var id = document.getElementById('hiddenid').value.replace("vtsbtn", "vts");
    window.opener.document.getElementById(id).value = document.getElementById('txtvts').value + "ÿ" + document.getElementById('hiddencirpub').value + "ÿ" + document.getElementById('hiddenciredi').value + "ÿ" + document.getElementById('txtcirrate').value + "ÿ" + document.getElementById('txtpubdate').value + "ÿ" + document.getElementById('txtciredition').value;
    window.close();
}
function onloadCall() {
    var id = document.getElementById('hiddenid').value.replace("vtsbtn", "");
    var hiddenpar = window.opener.document.getElementById('vts' + id).value;
    if (hiddenpar != "") {
        var arr = hiddenpar.split('ÿ');
        if (arr[0].toString() != null && arr[0].toString() != "null")
            document.getElementById('txtvts').value = arr[0].toString();
        if (arr[1].toString() != null && arr[1].toString() != "null")
            document.getElementById('hiddencirpub').value = arr[1].toString();
        if (arr[2].toString() != null && arr[2].toString() != "null")
            document.getElementById('hiddenciredi').value = arr[2].toString();
        if (arr[3].toString() != null && arr[3].toString() != "null")
            document.getElementById('txtcirrate').value = arr[3].toString();
        if (arr[4].toString() != "" && arr[4].toString() != null && arr[4].toString() != "null") {
            var dateformat = document.getElementById('hiddendateformat').value;
            // document.getElementById('txtpubdate').value=arr[4];
            var pubdate = arr[4].toString();
            if (dateformat == "yyyy/mm/dd") {
                var yearfield = pubdate.split("/")[0]
                var monthfield = pubdate.split("/")[1]
                var dayfield = pubdate.split("/")[2]
                var pubd = new Date(yearfield, monthfield - 1, dayfield)
            }
            if (dateformat == "mm/dd/yyyy") {
                var yearfield = pubdate.split("/")[2]
                var monthfield = pubdate.split("/")[0]
                var dayfield = pubdate.split("/")[1]
                //var dayobj = new Date(monthfield-1, dayfield, yearfield)
                var pubd = new Date(yearfield, monthfield - 1, dayfield)

            }
            if (dateformat == "dd/mm/yyyy") {
                var yearfield = pubdate.split("/")[2]
                var monthfield = pubdate.split("/")[1]
                var dayfield = pubdate.split("/")[0]
                //var dayobj = new Date(dayfield, monthfield-1, yearfield)
                var pubd = new Date(yearfield, monthfield - 1, dayfield)
            }
            var newdate = new Date(pubd.toString());
            var mm = parseInt(newdate.getMonth(), 10) + 1;
            if (mm.toString().length == 1)
                mm = "0" + mm.toString();
            if (dateformat == "yyyy/mm/dd") {
                document.getElementById('txtpubdate').value = newdate.getYear() + "/" + mm + "/" + newdate.getDate();
            }
            if (dateformat == "mm/dd/yyyy") {
                document.getElementById('txtpubdate').value = mm + "/" + newdate.getDate() + "/" + newdate.getYear();

            }
            if (dateformat == "dd/mm/yyyy") {
                document.getElementById('txtpubdate').value = newdate.getDate() + "/" + mm + "/" + newdate.getYear();
            }
        }
        if (arr.length > 4) {
            if (arr[5].toString() != null && arr[5].toString() != "null")
                document.getElementById('txtciredition').value = arr[5].toString();
        }
    }
    if (document.getElementById('hiddenmode').value == "execute") {
        document.getElementById('txtvts').disabled = true;
        document.getElementById('txtcirrate').disabled = true;
        document.getElementById('txtpubdate').disabled = true;
        document.getElementById('btnSubmit').disabled = true;
    }
    else {
        document.getElementById('txtvts').disabled = false;
        document.getElementById('txtcirrate').disabled = false;
        document.getElementById('txtpubdate').disabled = false;
        document.getElementById('btnSubmit').disabled = false;
        document.getElementById('txtvts').focus();
    }
}
///////bhanu
function alertfun() {
    document.getElementById('hndalert1').value = "";
    var clientcode = document.getElementById('txtclient').value;
    if (clientcode.indexOf("(") > 0) {
        var clientsplit = clientcode.split("(");
        var compcode = document.getElementById('hiddencompcode').value;
        clientsplit = clientsplit[1];
        clientsplit = clientsplit.replace(")", "");
        var re = Booking_master.chkcasualclient(clientsplit, compcode);
        var ds = re.value;
        if (ds !== null && ds.Tables[0] != null && ds.Tables[0] != undefined) {
            if (ds.Tables[0].Rows.length > 0) {
                if (ds.Tables[0].Rows[0].Remarks != null && ds.Tables[0].Rows[0].Remarks != "") {
                    document.getElementById('hndalert1').value = ds.Tables[0].Rows[0].Remarks;
                    alert(ds.Tables[0].Rows[0].Remarks);
                }
                if (ds.Tables[0].Rows[0].DISC_AMT != null && ds.Tables[0].Rows[0].DISC_AMT != "") {
                    document.getElementById('txtclientcatdisc').value = ds.Tables[0].Rows[0].DISC_AMT;
                    document.getElementById('hdnclientcatdistype').value = ds.Tables[0].Rows[0].DISC_TY;
                }
                if (ds.Tables[0].Rows[0].F_FREQ_DISC_AMT != null && ds.Tables[0].Rows[0].F_FREQ_DISC_AMT != "") {
                    document.getElementById('txtflatfreqdisc').value = ds.Tables[0].Rows[0].F_FREQ_DISC_AMT;
                    document.getElementById('hdnflatfreqdisctype').value = ds.Tables[0].Rows[0].F_FREQ_DISC_TY;
                }
            }
        }
        return false;
    }
}

function f2query(event) {
    if (agnf2 == "Y" && event.keyCode != 113 && event.keyCode != 27) {
        if (document.activeElement.id == "txtagency") {
            //            if(document.getElementById('txtagency').value.length <=2)
            //            {
            //            alert("Please Enter Minimum 3 Character For Searching.");
            //            document.getElementById('txtagency').value="";
            //            return false;
            //            }
            if (document.getElementById('txtagency').value == "") {
                if (document.getElementById("div1").style.display == "block") {
                    document.getElementById("div1").style.display = "none"
                    document.getElementById('txtagency').focus();
                    return false;
                }
                return false;
            }
            if (event.keyCode == 40) {
                document.getElementById("lstagency").focus();
                return false;
            }
            if (document.getElementById("div1").style.display == "none") {
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
                document.getElementById('div1').style.top = document.getElementById("txtagency").offsetTop + (toppos + 15) + "px";
                document.getElementById('div1').style.left = document.getElementById("txtagency").offsetLeft + leftpos + "px";
            }
            /*if(browser!="Microsoft Internet Explorer")
            {
            document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/
            (-20) + "px";
            /*  document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
            document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-25) + "px";
            document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }*/

            if (document.getElementById('hdnbranchf2req').value == "Y") {
                Booking_master.bindagencyname1(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency').value, "Y", document.getElementById('hdnrevenuecentcd').value, bindagencyname_callback);
            }
            else {
                Booking_master.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency').value, "Y", bindagencyname_callback);
            }
        }
        else if (document.activeElement.id == "txtclient") {
            // bhanu
            if (clientfromconfig == "UD") {
                if (document.getElementById('txtclient').value != "" && document.getElementById('drpregular').value == "0") {
                    document.getElementById('txtclient').value = "";
                    alert("Please select Client Type");
                    document.getElementById('drpregular').focus();
                    return false;
                }
                if (document.getElementById('drpregular').value == "NRC" || document.getElementById('drpregular').value == "TBRC") {
                    return false;
                }
            }
            ////bhanu end 
            if (document.getElementById('txtclient').value == "") {
                if (document.getElementById("divclient").style.display == "block") {
                    document.getElementById("divclient").style.display = "none"
                    document.getElementById('txtclient').focus();
                    return false;
                }
                return false;
            }
            if (event.keyCode == 40) {
                document.getElementById("lstclient").focus();
                return false;
            }
            else if (event.keyCode == 27) {
                if (document.getElementById("divclient").style.display == "block") {
                    document.getElementById("divclient").style.display = "none"
                    document.getElementById('txtclient').value = "";
                    document.getElementById('txtclient').focus();
                }
                return false;
            }

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
            document.getElementById('divclient').style.top = document.getElementById("txtclient").offsetTop + (toppos + 15) + "px";
            document.getElementById('divclient').style.left = document.getElementById("txtclient").offsetLeft + leftpos + "px";
            Booking_master.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient').value, "Y", bindclientname_callback);
        }

    }
    else if (document.activeElement.id == "txtrevenuecenternew") {
        if (event.keyCode == 113) {
            document.getElementById("divrevenuecenternew").style.display = "block";
            aTag = eval(document.getElementById("txtrevenuecenternew"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divrevenuecenternew').style.top = document.getElementById("txtrevenuecenternew").offsetTop + (toppos + 15) + "px";
            document.getElementById('divrevenuecenternew').style.left = document.getElementById("txtrevenuecenternew").offsetLeft + leftpos + "px";
            document.getElementById('lstrevenuecenternew').focus();
            Booking_master.abc_get_unit_allocation(document.getElementById('hiddencompcode').value, document.getElementById("txtrevenuecenternew").value, "", "A", "", "", bindrevenuecenternew_callback);
        }
        else if (event.keyCode == 40) {
            document.getElementById("lstrevenuecenternew").focus();
            return false;
        }
        else if (event.keyCode == 27) {
            if (document.getElementById("divrevenuecenternew").style.display == "block") {
                document.getElementById("divrevenuecenternew").style.display = "none"
                document.getElementById('txtrevenuecenternew').focus();
            }
            return false;
        }


    }
}
function opencopyDivInsertion(activeid) {
    var no = activeid.replace("ins", "");
    var disc_ = "";
	var payg = "";
    if (document.getElementById("disc_" + no) != null && document.getElementById("disc_" + no).value != "null" && document.getElementById("disc_" + no).value != null)
        disc_ = document.getElementById("disc_" + no).value;
	if (document.getElementById("pai" + no) != null && document.getElementById("pai" + no).value != "null" && document.getElementById("pai" + no).value != null)
        payg = document.getElementById("pai" + no).value;
    var billno = "";
    var billdate = "";
    var insbillamt = calculateinsbillamt(no, activeid);
    var insdiscrate = calculateinsdisrate(no, activeid);
    var re = Booking_master.getbillnobilldate(document.getElementById('txtciobookid').value, document.getElementById(activeid).innerHTML);
    var ds = re.value;
    if (ds !== null && ds.Tables[0] != null && ds.Tables[0] != undefined) {
        if (ds.Tables[0].Rows.length > 0) {
            if (ds.Tables[0].Rows[0].BILL_NO != null && ds.Tables[0].Rows[0].BILL_NO != "") {
                billno = ds.Tables[0].Rows[0].BILL_NO;
            }
            if (ds.Tables[0].Rows[0].BILL_DATE != null && ds.Tables[0].Rows[0].BILL_DATE != "") {
                billdate = ds.Tables[0].Rows[0].BILL_DATE;
            }

        }
    }
    var str = "<table  border=1><tr><td><table  border=0  style='background-color: #ffffff;'><tr bgcolor=\"#7DAAF3\" class=\"dtGridHd12\"><td>Sr. No.</td><td>Date</td><td>Subcategory</td><td>Color</td><td>Height</td><td>Width</td><td>Size</td><td>Insert Bill Amt.</td><td>Status</td><td>Bill No.</td><td>Bill Date</td><td>Discount</td><td>Pageno</td><td>Caption</td><td>Remarks</td><td>Agreed Rate</td><td>Paid Ins.</td></tr>";
    if (chkbtnStatus != "execute") {
        if (document.getElementById("hiddenuomdesc").value == "CD") {
            str = str + "<tr><td class=TextField valign=top>" + document.getElementById(activeid).innerHTML + "</td><td valign=top><input class=\"btextforgriddate\" type=\"text\" id='Textdiv" + no + "' onchange=\"return chkDateforGrid(this);\"  value='" + document.getElementById("Text" + no).value + "' ></td><td valign=top><input id='adsdiv" + no + "' onchange=\"return blankGross();\" class=\"btextforgrid\" type=\"text\"  value=" + document.getElementById("ads" + no).value + " ><div id='agdivpop' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglistpop'  id='aglistpop' CssClass='btextlist' size=4 Width=100px Height=50px></select></div></td><td valign=top><input class=\"btextsmallsize\" id='coldiv" + no + "' onchange=\"return blankGross();\" type=\"text\" value=" + document.getElementById("col" + no).value + " ></td><td valign=top><input  class=\"btextsmallsize\" id='heidiv" + no + "'  type=\"text\" onChange=\"divAddclick('" + no + "','" + activeid + "');\" value=" + document.getElementById("hei" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" id='widdiv" + no + "'  type=\"text\" onChange=\"divAddclick('" + no + "','" + activeid + "');\" value=" + document.getElementById("wid" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" disabled id='sizdiv" + no + "'  type=\"text\" value=" + document.getElementById("siz" + no).value + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='insbillamtdiv" + no + "'  type=\"text\" value=" + insbillamt + "></td><td valign=top><input class=\"btextforgrid\"  type=\"text\" id='divinssta" + no + "' value=" + "'" + document.getElementById("inssta" + no).value + "'" + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billnodiv" + no + "'  type=\"text\" value=" + billno + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billdtdiv" + no + "'  type=\"text\" value=" + billdate + "></td>";
            if (document.getElementById('hiddisceditgrid').value == "Y")
                str = str + "<td valign=top><input  class=\"btextsmallsize\"  id='discdiv" + no + "'  type=\"text\"' onkeypress=\"return greterthan(event);\"value=" + disc_ + "></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\"  id='capdiv" + no + "'   type=\"text\" title='" + document.getElementById("cap" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("cap" + no).value + "</textarea></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("rem" + no).value + "</textarea></td>";
            else
                str = str + "<td valign=top><input  class=\"btextsmallsize\" disabled id='discdiv" + no + "'  type=\"text\" value=" + disc_ + "></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\"  id='capdiv" + no + "'   type=\"text\" title='" + document.getElementById("cap" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("cap" + no).value + "</textarea></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("rem" + no).value + "</textarea></td>";
            if (VISIBLEAGREEDRATE == "Y" && document.getElementById('hiddensavemod').value != "0") {
                str = str + "<td><input  class=\"btextforgrid\" id='disratediv" + no + "'  type=\"text\" value=" + insdiscrate + "></td><td><select id='paiddiv" + no + "' class=\"dropdownforgridsmall\"><option value=\"Y\">Yes</option><option value=\"N\">No</option><option value=\"P\">Paid</option></select></td></tr>";
            }
            else {
                str = str + "<td><input  class=\"btextforgrid\" id='disratediv" + no + "'  type=\"text\" value=" + insdiscrate + "></td><td><select id='paiddiv" + no + "' class=\"dropdownforgridsmall\"><option value=\"Y\">Yes</option><option value=\"N\">No</option><option value=\"P\">Paid</option></select></td></tr>";
            }
        }
        else {
            str = str + "<tr><td class=TextField valign=top>" + document.getElementById(activeid).innerHTML + "</td><td valign=top><input class=\"btextforgriddate\" type=\"text\" id='Textdiv" + no + "' onchange=\"return chkDateforGrid(this);\"  value='" + document.getElementById("Text" + no).value + "' ></td><td valign=top><input id='adsdiv" + no + "' onchange=\"return blankGross();\" class=\"btextforgrid\" type=\"text\"  value=" + document.getElementById("ads" + no).value + " ><div id='agdivpop' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglistpop'  id='aglistpop' CssClass='btextlist' size=4 Width=100px Height=50px></select></div></td><td valign=top><input class=\"btextsmallsize\" id='coldiv" + no + "' onchange=\"return blankGross();\" type=\"text\" value=" + document.getElementById("col" + no).value + " ></td><td valign=top><input  class=\"btextsmallsize\" disabled id='heidiv" + no + "'  type=\"text\" value=" + document.getElementById("hei" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" disabled id='widdiv" + no + "'  type=\"text\" value=" + document.getElementById("wid" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" onchange=\"return blankGross();\" id='sizdiv" + no + "'  type=\"text\" value=" + document.getElementById("siz" + no).value + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='insbillamtdiv" + no + "'  type=\"text\" value=" + insbillamt + "></td><td valign=top><input class=\"btextforgrid\"  type=\"text\" id='divinssta" + no + "' value=" + "'" + document.getElementById("inssta" + no).value + "'" + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billnodiv" + no + "'  type=\"text\" value=" + billno + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billdtdiv" + no + "'  type=\"text\" value=" + billdate + "></td>";
            if (document.getElementById('hiddisceditgrid').value == "Y")
                str = str + "<td valign=top><input  class=\"btextsmallsize\"  id='discdiv" + no + "'  type=\"text\"  onkeypress=\"return greterthan(event);\"value=" + disc_ + "></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\"  id='capdiv" + no + "'   type=\"text\" title='" + document.getElementById("cap" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("cap" + no).value + "</textarea></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("rem" + no).value + "</textarea></td>";
            else
                str = str + "<td valign=top><input  class=\"btextsmallsize\" disabled id='discdiv" + no + "'  type=\"text\" value=" + disc_ + "></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\"  id='capdiv" + no + "'   type=\"text\" title='" + document.getElementById("cap" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("cap" + no).value + "</textarea></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("rem" + no).value + "</textarea></td>";
            if (VISIBLEAGREEDRATE == "Y" && document.getElementById('hiddensavemod').value != "0") {
                str = str + "<td><input  class=\"btextforgrid\" id='disratediv" + no + "'  type=\"text\" value=" + insdiscrate + "></td><td><select id='paiddiv" + no + "' class=\"dropdownforgridsmall\"><option value=\"Y\">Yes</option><option value=\"N\">No</option><option value=\"P\">Paid</option></select></td></tr>";
            }
            else {
                str = str + "<td><input  class=\"btextforgrid\"  id='disratediv" + no + "'  type=\"text\" value=" + insdiscrate + "></td><td><select id='paiddiv" + no + "' class=\"dropdownforgridsmall\"><option value=\"Y\">Yes</option><option value=\"N\">No</option><option value=\"P\">Paid</option></select></td></tr>";
            }
        }
    }
    else {
        if (document.getElementById("hiddenuomdesc").value == "CD") {
            str = str + "<tr><td class=TextField valign=top>" + document.getElementById(activeid).innerHTML + "</td><td valign=top><input class=\"btextforgriddate\" type=\"text\" disabled id='Textdiv" + no + "' onchange=\"return chkDateforGrid(this);\"  value='" + document.getElementById("Text" + no).value + "' ></td><td valign=top><input id='adsdiv" + no + "' disabled onchange=\"return blankGross();\" class=\"btextforgrid\" type=\"text\"  value=" + document.getElementById("ads" + no).value + " ><div id='agdivpop' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglistpop'  id='aglistpop' CssClass='btextlist' size=4 Width=100px Height=50px></select></div></td><td valign=top><input class=\"btextsmallsize\" id='coldiv" + no + "' disabled onchange=\"return blankGross();\" type=\"text\" value=" + document.getElementById("col" + no).value + " ></td><td valign=top><input  class=\"btextsmallsize\" id='heidiv" + no + "' disabled  type=\"text\" onChange=\"divAddclick('" + no + "','" + activeid + "');\" value=" + document.getElementById("hei" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" id='widdiv" + no + "' disabled  type=\"text\" onChange=\"divAddclick('" + no + "','" + activeid + "');\" value=" + document.getElementById("wid" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" disabled id='sizdiv" + no + "'  type=\"text\" value=" + document.getElementById("siz" + no).value + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='insbillamtdiv" + no + "'  type=\"text\" value=" + insbillamt + "></td><td valign=top><input class=\"btextforgrid\"  type=\"text\" id='divinssta" + no + "' disabled value=" + "'" + document.getElementById("inssta" + no).value + "'" + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billnodiv" + no + "'  type=\"text\" value=" + billno + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billdtdiv" + no + "'  type=\"text\" value=" + billdate + "></td>";
            if (document.getElementById('hiddisceditgrid').value == "Y")
                str = str + "<td valign=top><input  class=\"btextsmallsize\" disabled  id='discdiv" + no + "'  type=\"text\"' onkeypress=\"return greterthan(event);\"value=" + disc_ + "></td><td valign=top><input class=\"btextsmallsizeH\" disabled id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\" disabled id='capdiv" + no + "'   type=\"text\" title='" + document.getElementById("cap" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("cap" + no).value + "</textarea></td><td valign=top><textarea  class=\"btextforgrid\" disabled  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("rem" + no).value + "</textarea></td>";
            else
                str = str + "<td valign=top><input  class=\"btextsmallsize\" disabled id='discdiv" + no + "'  type=\"text\" value=" + disc_ + "></td><td valign=top><input class=\"btextsmallsizeH\" disabled id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\" disabled  id='capdiv" + no + "'   type=\"text\" title='" + document.getElementById("cap" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("cap" + no).value + "</textarea></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv" + no + "' disabled   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("rem" + no).value + "</textarea></td>";
            if (VISIBLEAGREEDRATE == "Y" && document.getElementById('hiddensavemod').value != "0") {
                str = str + "<td><input  class=\"btextforgrid\" id='disratediv" + no + "'  type=\"text\" value=" + insdiscrate + "></td><td><select id='paiddiv" + no + "' class=\"dropdownforgridsmall\"><option value=\"Y\">Yes</option><option value=\"N\">No</option><option value=\"P\">Paid</option></select></td></tr>";
            }
            else {
                str = str + "<td><input  class=\"btextforgrid\"  id='disratediv" + no + "'  type=\"text\" value=" + insdiscrate + "></td><td><select id='paiddiv" + no + "' class=\"dropdownforgridsmall\" disabled><option value=\"Y\">Yes</option><option value=\"N\">No</option><option value=\"P\">Paid</option></select></td></tr>";
            }
        }
        else {
            str = str + "<tr><td class=TextField valign=top>" + document.getElementById(activeid).innerHTML + "</td><td valign=top><input class=\"btextforgriddate\" disabled type=\"text\" id='Textdiv" + no + "' onchange=\"return chkDateforGrid(this);\"  value='" + document.getElementById("Text" + no).value + "' ></td><td valign=top><input disabled id='adsdiv" + no + "' onchange=\"return blankGross();\" class=\"btextforgrid\" type=\"text\"  value=" + document.getElementById("ads" + no).value + " ><div id='agdivpop' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglistpop'  id='aglistpop' CssClass='btextlist' size=4 Width=100px Height=50px></select></div></td><td valign=top><input class=\"btextsmallsize\" disabled id='coldiv" + no + "' onchange=\"return blankGross();\" type=\"text\" value=" + document.getElementById("col" + no).value + " ></td><td valign=top><input  class=\"btextsmallsize\" disabled id='heidiv" + no + "'  type=\"text\" value=" + document.getElementById("hei" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" disabled id='widdiv" + no + "'  type=\"text\" value=" + document.getElementById("wid" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" disabled onchange=\"return blankGross();\" id='sizdiv" + no + "'  type=\"text\" value=" + document.getElementById("siz" + no).value + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='insbillamtdiv" + no + "'  type=\"text\" value=" + insbillamt + "></td><td valign=top><input class=\"btextforgrid\"  type=\"text\" disabled id='divinssta" + no + "' value=" + "'" + document.getElementById("inssta" + no).value + "'" + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billnodiv" + no + "'  type=\"text\" value=" + billno + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billdtdiv" + no + "'  type=\"text\" value=" + billdate + "></td>";
            if (document.getElementById('hiddisceditgrid').value == "Y")
                str = str + "<td valign=top><input  class=\"btextsmallsize\"  id='discdiv" + no + "'  type=\"text\"  onkeypress=\"return greterthan(event);\"value=" + disc_ + "></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\"  id='capdiv" + no + "'   type=\"text\" title='" + document.getElementById("cap" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("cap" + no).value + "</textarea></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("rem" + no).value + "</textarea></td>";
            else
                str = str + "<td valign=top><input  class=\"btextsmallsize\" disabled id='discdiv" + no + "'  type=\"text\" value=" + disc_ + "></td><td valign=top><input class=\"btextsmallsizeH\" disabled id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\" disabled id='capdiv" + no + "'   type=\"text\" title='" + document.getElementById("cap" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("cap" + no).value + "</textarea></td><td valign=top><textarea  class=\"btextforgrid\" disabled  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:120px'>" + document.getElementById("rem" + no).value + "</textarea></td>";
            if (VISIBLEAGREEDRATE == "Y" && document.getElementById('hiddensavemod').value != "0") {
                str = str + "<td><input  class=\"btextforgrid\" id='disratediv" + no + "'  type=\"text\" value=" + insdiscrate + "></td><td><select id='paiddiv" + no + "' class=\"dropdownforgridsmall\"><option value=\"Y\">Yes</option><option value=\"N\">No</option><option value=\"P\">Paid</option></select></td></tr>";
            }
            else {
                str = str + "<td><input  class=\"btextforgrid\" id='disratediv" + no + "'  type=\"text\" value=" + insdiscrate + "></td><td><select id='paiddiv" + no + "' class=\"dropdownforgridsmall\"><option value=\"Y\">Yes</option><option value=\"N\">No</option><option value=\"P\">Paid</option></select></td></tr>";
            }
        }
    }
    //str = str + "<tr ><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td colspan='2' align=right><input type=button class=\"buttonsplit\" value=Ok onClick=\"divokclick(" + no + "," + activeid + ");\"><input type=button class=\"buttonsplit\" value=Close onClick=\"divcancelclick();\"></td><td></td></tr>";
    str = str + "<tr ><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td colspan='2' align=right><input type=button class=\"buttonsplit\" value=Ok onClick=\"divokclick('" + no + "','" + document.getElementById(activeid).innerHTML + "');\"><input type=button class=\"buttonsplit\" value=Close onClick=\"divcancelclick();\"></td><td></td></tr>";
    str = str + "</table>";
    document.getElementById('divcopyinsertion').innerHTML = str;
    document.getElementById('divcopyinsertion').style.display = "block";
	document.getElementById('paiddiv' + no).value=payg;
    arrNS = new Array();
    arrNS[0] = document.getElementById('adsdiv' + no).value;
    arrNS[1] = document.getElementById('Textdiv' + no).value;
    arrNS[2] = document.getElementById('coldiv' + no).value;
    arrNS[3] = document.getElementById('sizdiv' + no).value;
    arrNS[4] = document.getElementById('divinssta' + no).value;
    arrNS[5] = document.getElementById('pagnodiv' + no).value;
    arrNS[6] = document.getElementById('remdiv' + no).value;
    arrNS[7] = document.getElementById('rem' + no).value;
    arrNS[8] = document.getElementById('capdiv' + no).value;
    arrNS[9] = document.getElementById('cap' + no).value;
    arrNS[10] = document.getElementById('heidiv' + no).value;
    arrNS[11] = document.getElementById('widdiv' + no).value;
    arrNS[12] = document.getElementById('discdiv' + no).value;
    arrNS[13] = document.getElementById('paiddiv' + no).value;
    aTag = eval(document.getElementById("ins0"))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    document.getElementById('divcopyinsertion').style.top = document.getElementById('ins0').offsetTop + toppos + "px";
    document.getElementById('divcopyinsertion').style.left = document.getElementById('ins0').offsetLeft + leftpos + "px";

}
function calculateinsbillamt(no, activeid) {
    var valT = document.getElementById(activeid).innerHTML; //.innerHTML;
    var billamt = 0;
    var count1 = document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length - 1;
    for (var i = parseInt(no, 10) ; i < count1; i++) {
        if (valT == document.getElementById("ins" + i).innerHTML)// && document.getElementById("inssta" + i).value != "billed" && document.getElementById("inssta" + i).value != "publish" && document.getElementById("inssta" + i).value != "cancel") {
        {
            if (document.getElementById('ba' + i).value != "" && document.getElementById('ba' + i).value != null)
                billamt = parseFloat(billamt) + parseFloat(document.getElementById('ba' + i).value);

        }
        else {
            break;
        }
    }
    return billamt.toFixed(2);
}
function divcancelclick() {
    document.getElementById('divcopyinsertion').style.display = "none";
}
function divAddclick(no, activeid) {
    document.getElementById('txtgrossamt').value = '';
    var hei = document.getElementById('heidiv' + no).value;
    var wid = document.getElementById('widdiv' + no).value;
    if (hei != "" && wid != "") {
        document.getElementById('sizdiv' + no).value = parseFloat(hei) * parseFloat(wid);

    }
}
function divokclick(no, activeid) {
    var res = greterthan1();
    if (res != false) {
        var countval = 0;
        var valT = activeid; //.innerHTML;
        var count1 = document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length - 1;
        var t_flag = true;
        for (var i = parseInt(no, 10) ; i < count1; i++) {
            if (document.getElementById('inssta' + i).value == "publish" && document.getElementById("inssta" + i).value == "billed")
                t_flag = false;
        }
        for (var i = parseInt(no, 10) ; i < count1; i++) {
            if (valT == document.getElementById("ins" + i).innerHTML) {
                countval = countval + 1;
            }
            else {
                break;
            }
        }
        for (var i = parseInt(no, 10) ; i < count1; i++) {
            if (valT == document.getElementById("ins" + i).innerHTML) {
                if (document.getElementById("inssta" + i).value != "cancel") {
                    if (arrNS[0].toString() != document.getElementById('adsdiv' + no).value)
                        document.getElementById('ads' + i).value = document.getElementById('adsdiv' + no).value;
                    if (arrNS[1].toString() != document.getElementById('Textdiv' + no).value)// && document.getElementById("inssta" + i).value != "billed")
                    {
                        if (document.getElementById("insstapub" + i) != null && document.getElementById("insstapub" + i).value == "booked") {
                            // var t_res = compareDatewithBilledDate(dateformat, document.getElementById('Text' + i).value, billdate, ds.Tables[0].Rows[i].INSERT_STATUS_PUB);
                            document.getElementById('Text' + i).value = document.getElementById('Textdiv' + no).value;
                        }
                        else if (document.getElementById("insstapub" + i) == null) {
                            document.getElementById('Text' + i).value = document.getElementById('Textdiv' + no).value;
                            var date_res = dropDateCheck(document.getElementById('Text' + i).value, document.getElementById('Text' + i), document.getElementById('hiddenpckcode' + i).value, document.getElementById('pkg_alias' + i).value, document.getElementById('card' + i).value);
                            if (date_res == false) {
                                alert(document.getElementById('Text' + i).value + " Date is no issue date of edition " + document.getElementById('pkg_alias' + i).value);
                                document.getElementById('Text' + i).value = "";
                            }
                        }

                    }
                    if (arrNS[2].toString() != document.getElementById('coldiv' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('col' + i).value = document.getElementById('coldiv' + no).value;
                    if (arrNS[3].toString() != document.getElementById('sizdiv' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('siz' + i).value = document.getElementById('sizdiv' + no).value;
                    if (t_flag = true && arrNS[4].toString() != document.getElementById('divinssta' + no).value && document.getElementById('inssta' + i).value != "publish" && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('inssta' + i).value = document.getElementById('divinssta' + no).value;
                    if (arrNS[5].toString() != document.getElementById('pagnodiv' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('pagno' + i).value = document.getElementById('pagnodiv' + no).value;
                    if (arrNS[6].toString() != document.getElementById('remdiv' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('rem' + i).value = document.getElementById('remdiv' + no).value;
                    if (arrNS[7].toString() != document.getElementById('rem' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('rem' + i).title = document.getElementById('rem' + i).value;
                    if (arrNS[8].toString() != document.getElementById('capdiv' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('cap' + i).value = document.getElementById('capdiv' + no).value;
                    if (arrNS[9].toString() != document.getElementById('cap' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('cap' + i).title = document.getElementById('cap' + i).value;
                    if (arrNS[10].toString() != document.getElementById('heidiv' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('hei' + i).value = document.getElementById('heidiv' + no).value;
                    if (arrNS[11].toString() != document.getElementById('widdiv' + no).value && document.getElementById("inssta" + i).value != "billed")
                        document.getElementById('wid' + i).value = document.getElementById('widdiv' + no).value;
                    if (arrNS[12].toString() != document.getElementById('discdiv' + no).value && (document.getElementById("inssta" + i).value != "billed" || document.getElementById('hiddensupplimentflag').value != "")) {
                        if (document.getElementById('disc_' + i) != null)
                            document.getElementById('disc_' + i).value = document.getElementById('discdiv' + no).value;
                        discid = "";
                    }
                    if ((document.getElementById("inssta" + i).value != "billed" || document.getElementById('hiddensupplimentflag').value != "")) {
                        if (document.getElementById('disrat' + i) != null)
                            document.getElementById('disrat' + i).value = parseFloat(document.getElementById('disratediv' + no).value) / parseFloat(countval);
                    }
                    if (arrNS[13].toString() != document.getElementById('paiddiv' + no).value && (document.getElementById("inssta" + i).value != "billed"|| document.getElementById('hiddensupplimentflag').value != ""))
                        document.getElementById('pai' + i).value = document.getElementById('paiddiv' + no).value;
                }
            }
            else {
                break;
            }
        }
        document.getElementById('divcopyinsertion').style.display = "none";
    }
    tooltipadsubcat();
}
////////////bhnau end

//===*******Call back funcion to bind caption***********===/
function bindcaption_callback(response) {
    ds = response.value;
    if (ds == null) {
        alert(response.error.description);
        return false;
    }
    var pkgitem = document.getElementById("lstcap");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Caption-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        // pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].CAPTION_NAME, ds.Tables[0].Rows[i].CAPTION_CODE);
            pkgitem.options.length;
        }
    }

    document.getElementById("lstcap").value = "0";
    document.getElementById("lstcap").focus();
    return false;
}
function capnamelst(event) {
    var key = event.keyCode ? event.keyCode : event.which;

    if (key == 13 || event.type == "click") {
        if (document.getElementById('lstcap').value == "0") {
            alert("Please select Caption.");
            return false;
        }
        document.getElementById("divcap").style.display = "none";
        var page = document.getElementById('lstcap').value;

        for (var k = 0; k <= document.getElementById("lstcap").length - 1; k++) {
            if (document.getElementById('lstcap').options[k].value == page) {
                if (browser != "Microsoft Internet Explorer")
                    var abc = document.getElementById('lstcap').options[k].textContent;
                else
                    var abc = document.getElementById('lstcap').options[k].innerText;

                document.getElementById('txtcaption').value = abc;
                //                    document.getElementById('txtagcode').value = page;
                document.getElementById('txtcaption').focus();
                return false;
            }
        }
    }

    else if (key == 27) {
        document.getElementById("divcap").style.display = "none";
        document.getElementById('txtcaption').focus();
    }
    //return false;
}
function greterthan(event) {
    var activid = document.activeElement.id;
    discid = activid;
    blankGross();
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 46 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0) || (event.which == 190) || (event.which == 110)) {
            if (parseFloat(document.getElementById(activid).value) > 100) {
                alert('discount can not be greated than 100%');
                document.getElementById(activid).value = "";
                return false;
            }
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 190) || (event.keyCode == 110)) {
            if (parseFloat(document.getElementById(activid).value) > 100) {
                alert('discount can not be greated than 100%');
                document.getElementById(activid).value = "";
                return false;
            }
            return true;
        }
        else {
            return false;
        }

    }
}


function greterthan1() {
    if (discid != "") {
        blankGross();
        if (parseFloat(document.getElementById(discid).value) > 100) {
            alert('discount can not be greated than 100%');
            document.getElementById(discid).value = "";
            document.getElementById(discid).focus();
            return false;
        }
    }
    else {
        return true;
    }
}
function calculateinsdisrate(no, activeid) {
    var valT = document.getElementById(activeid).innerHTML; //.innerHTML;
    var billamt = 0;
    var count1 = document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length - 1;
    for (var i = parseInt(no, 10) ; i < count1; i++) {
        if (valT == document.getElementById("ins" + i).innerHTML)// && document.getElementById("inssta" + i).value != "billed" && document.getElementById("inssta" + i).value != "publish" && document.getElementById("inssta" + i).value != "cancel") {
        {
            if (document.getElementById('disrat' + i).value != "" && document.getElementById('disrat' + i).value != null)
                billamt = parseFloat(billamt) + parseFloat(document.getElementById('disrat' + i).value);

        }
        else {
            break;
        }
    }
    return billamt.toFixed(2);
}
function modifyAddItem(objListBox, strText, strId) {
    suboradd = "1";
    previnsertion = "0";
    noissueflag = true;
    getid = "";
    if (strText.lastIndexOf('(') < 0) {
        strText = strText + '(1)';
        strId = strId + '(1)';
    }
    if (objListBox.length > 0) {

        var arr = new Array();
        var arr1 = new Array();
        for (j = 0; j <= objListBox.length - 1; j++) {
            arr[j] = objListBox.options[j].text;
            arr1[j] = objListBox.options[j].value;
        }

        for (k = objListBox.length - 1; k >= 0; k--)
        { objListBox.remove(k); }

        var opt = document.createElement("OPTION");
        opt.text = strText;
        opt.value = strId;
        objListBox.options.add(opt);

        var x = 0;
        for (x in arr) {
            if (x != "remove") {
                var option = document.createElement("OPTION");
                option.text = arr[x];
                option.value = arr1[x];
                objListBox.options.add(option);
            }
        }

    }
    else {
        //alert("bhanu");
        var opt = document.createElement("OPTION");
        opt.text = strText;
        opt.value = strId;
        objListBox.options.add(opt);


    }
    var objpack = document.getElementById('drppackagecopy');
    var temp = "";
    var tempcode = "";
    var tempval = "";
    var tempvalcode = "";
    var desc = "";
    var code = "";
    var i = objpack.options.length;
    var j;

    for (j = 0; j < i; j++) {
        if (parseInt(i) > 0) {
            tempval = objpack[j].value;
            //tempvalcode=objpack[j].value;
            if (temp != "") {
                temp = tempval.split("@");
                tempvalcode = temp[0];
                tempcode = temp[1];
                cyop_code = tempvalcode + "^" + cyop_code;
                cyop_desc = tempcode + "^" + cyop_desc;
                code = tempvalcode + "," + code;
                desc = tempcode + "," + desc;
            }
            else {
                temp = tempval.split("@");
                tempvalcode = temp[0];
                tempcode = temp[1];
                code = tempvalcode;
                desc = tempcode;
                cyop_code = tempvalcode;
                cyop_desc = tempcode;
            }
        }

    }
    document.getElementById('hiddenpackage').value = code;
}
function modifyLine_callback(response) {
    var ds = response.value;


    if (ds == null) {
        alert("There is Some Network Error. Please Do the Booking Again");
        return false;
    }
    fillinsert = ds.Tables[0].Rows.length;
    var i = 0;
    var str = "";
    var adtype_vari = document.getElementById('hiddenadtype');
    var chkall_vari = document.getElementById('chkall');
    var pagepremcopy = document.getElementById('drppageprem'); //chnage for negative amt mimoh
    var pagepremper = document.getElementById('txtpremper');
    var center_vari = document.getElementById('hiddencenter');
    var adsubcat_vari = document.getElementById('drpadsubcategory');
    var color_vari = document.getElementById('drpcolor');
    var column_vari = document.getElementById('txtcolum');
    var uom_vari = document.getElementById('drpuom');
    var hiddenuom_vari = document.getElementById('hiddenuomdesc');
    var matsta_vari = document.getElementById('drpmatsta');
    var drppagepos_vari = document.getElementById('drppageposition');
    var adcat_vari = document.getElementById('drpadcategory');
    var pkgcopy_vari = document.getElementById('drppackagecopy');
    var gridtab_vari = document.getElementById('gridtab');
    var dateformat_vari = document.getElementById('hiddendateformat');
    var caption_per = document.getElementById('txtcaption');
    var remarks_per = document.getElementById('txtprintremark');
    var dat = "mm+" / "+" / "+dd+" / "+yyyy";
    var j = 0;
    var k = 0;
    var l = 0;
    var m = 0;
    var n = 0;
    var o = 0;
    var p = 0;
    var premid;
    var premper;
    var colid;
    var height;
    var width;
    var size;
    var late;
    var adtypid;
    var uomid;
    var cardid;
    var premper1;
    var prem1id;
    var name;
    var inserts;
    var pagepost;
    var preall;
    var adcat;
    var adsubcat;
    var matsta;
    var filename;
    var discrate;
    var insertsta;
    var billstat;
    var editid;
    var repeat;
    var picfieldl;
    var colid;
    var paid;
    var agrred;
    var solo;
    var gross;
    var s;
    var count;
    var len = "bookdiv";
    var pageno_inserts;
    var remark_inserts;
    var caption_inserts;
    var page;
    var pageprem;
    var billamt;
    var billrate;
    var agnamnt;
    var adlgn;
    var spldisc;
    var cashdisc;
    var roundoffval;
    var pagstr;
    //new change for bind grid line
    var dcat1 = "";
    var dcol = "";
    var dinsert = "";
    var dstatus = "";
    var dposition = "";
    var dprem1 = "";
    var dpre = "";
    var dmcat = "";
    var dbill = "";
    var dadcat3 = "";
    var dadcat4 = "";
    var dadcat5 = "";
    var dpaid = "";
    var dcou = 0;
    //***************************
    var objedition = document.getElementById('drpedition');
    if (spdiscper == 1) {
        document.getElementById('txtspedisc').value = "";
    }
    else if (spdisc == 1) {
        document.getElementById('txtspediscper').value = "";
    }
    if (document.getElementById('hiddensavemod').value != "0") {
        count = document.getElementById(len).getElementsByTagName('table')[0].rows.length - 1;
        idnew = parseInt(count);
        document.getElementById('hiddenrowcount').value = count;
        //insertval=count;
        if (document.getElementById('hiddeninsertion').value != "") {
            gridItemCount = parseInt(count) / parseInt(document.getElementById('hiddeninsertion').value);
            insertval = document.getElementById('hiddeninsertion').value;
            tempins = document.getElementById('hiddeninsertion').value;
            count = parseInt(ds.Tables[0].Rows.length, 10) / parseInt(document.getElementById('txtinsertion').value, 10);
            count = parseInt(count) * parseInt(document.getElementById('hiddeninsertion').value);
            document.getElementById('hiddeninsertion').value = count
        }


    }
    else {
        count = document.getElementById('hiddenrowcount').value;
        document.getElementById('hiddenrowcount').value = ds.Tables[0].Rows.length;
    }
    // count=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;
    /*if(document.getElementById('txtrepeatingdate').value!="")
    {
    count=0;
    }*/

    var temp = document.getElementById(len).getElementsByTagName('table')[0].rows.length - 1;
    //i=count;
    i = document.getElementById(len).getElementsByTagName('table')[0].rows.length - 1;
    var adsize1val = document.getElementById('txtadsize1').value;
    var adsize2val = document.getElementById('txtadsize2').value;
    var colval = document.getElementById('txtcolum').value;
    var areaval = document.getElementById('txttotalarea').value;
    var agreedamt1 = document.getElementById('txtagreedrate').value;
    dcou = i;
    var insprev = 0;
    var ins_vari_m = document.getElementById('ins' + (parseInt(count, 10) - 1).toString());
    var data_arr = new Array();
    if (ins_vari_m != null) {
        var tsec = parseInt(count, 10) - 1;
        var insidM = "1";
        if (ds.Tables[0].Rows.length > 0 && ds.Tables[0].Rows[count] != null)
            insidM = ds.Tables[0].Rows[count].IDNUM;
        var sd = 0;
        while (parseInt(ins_vari_m.innerHTML) == insidM) {
            var strN = document.getElementById('edit' + tsec).value + "~" + document.getElementById('Text' + tsec).value;
            strN = strN + "~" + document.getElementById('hei' + tsec).value + "~" + document.getElementById('wid' + tsec).value;
            strN = strN + "~" + document.getElementById('siz' + tsec).value + "~" + document.getElementById('nocol' + tsec).value;
            data_arr[sd] = strN;
            tsec = tsec - 1;
            sd = sd + 1;
            ins_vari_m = document.getElementById('ins' + tsec);
            if (ins_vari_m == null)
                break;
        }
    }
    document.getElementById('txtinsertion').value = parseInt(document.getElementById('txtinsertion').value) + 1;
    for (s = 0; s < ds.Tables[0].Rows.length; s++) {

        if (getid != "" && parseInt(i) < parseInt(getid)) {
            i = getid;
            // i=parseInt(i)+1;
        }
        var vvalue = "";
        if (checkflag == 1) {
            caldate[cali] = dateSelected;
            caldatemonth[cali] = parseInt(monthSelected) + 1;
            caldateyear[cali] = yearSelected;
            // cali=cali+1;
        }
        //var dCheck = checkValidEdition(ds.Tables[0].Rows[s].Edition_Name, ds.Tables[0].Rows[s].EDITION_CODE);
        var dCheck = true;
        if (dCheck == true) {
            var id = "Text" + i;
            uomid = "uom" + i;
            inserts = "ins" + i;
            editid = "edit" + i;
            colid = "col" + i;
            agrred = "agr" + i;
            btn_Pg_ = "btn_Pg_" + i;
            //bind button pageset for pagination
            Make_Row = document.createElement("tr");
            make_td = document.createElement("td");
            make_td.align = "center";
            str = "<input  class='buttonpgset' id='" + btn_Pg_ + "' type='button' Value='PageSet'>";
            make_td.innerHTML = str;
            Make_Row.appendChild(make_td);


            insertval = document.getElementById('txtinsertion').value;
            // Make_Row=document.createElement("tr");
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.setAttribute("class", "TextField");
            make_td.innerHTML = insertval;
            make_td.id = inserts;
            if (insprev != insertval) {
                insprev = insertval;
                make_td.title = "Edit Insert";
            }
            Make_Row.appendChild(make_td);

            // edition
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.setAttribute("class", "dtGrid");
            str = "<input class=\"btextforgrid7\" type=\"text\" disabled id=" + editid + " value='" + ds.Tables[0].Rows[s].Edition_Name + "'>";
            make_td.innerHTML = str;
            Make_Row.appendChild(make_td);

            //date
            var nDate = "";
            if (ds.Tables[0].Rows[s].Date != null) {
                nDate = ds.Tables[0].Rows[s].Date;
            }

            for (var e = 0; e < data_arr.length; e++) {
                var d_ = data_arr[e].split("~")[1];
                var E_ = data_arr[e].split("~")[0];
                if (ds.Tables[0].Rows[s].Edition_Name == E_.toString()) {
                    if (noissueflag == true) {
                        nDate = d_;
                        if (nDate != "") {
                            nDate = getRepeat(nDate, document.getElementById('txtrepeatingdate').value, dateformat_vari.value);
                        }
                    }
                    adsize1val = data_arr[e].split("~")[2];
                    adsize2val = data_arr[e].split("~")[3];
                    areaval = data_arr[e].split("~")[4];
                    colval = data_arr[e].split("~")[5];
                    data_arr[e] = E_ + "~" + nDate + "~" + adsize1val + "~" + adsize2val + "~" + areaval + "~" + colval;
                    e = data_arr.length;
                }
            }
            make_td = document.createElement("td");
            make_td.align = "center";
            //str="<input class=\"btextforgrid\" type=\"text\" id="+id+"   onfocus=\"popUpCalendar(Form1."+id+", Form1."+id+", "+dat+");\"  onkeydown=\"return nodateentry(event);\" value="+nDate+" ><img src=\"Images/cal1.gif\"  onclick=\"popUpCalendar(Form1."+id+", Form1."+id+", "+dat+");\" height=\"14\" width=\"14\" />";      
            str = "<input class=\"btextforgriddate\" type=\"text\" id=" + id + "    value=" + nDate + ">";
            make_td.innerHTML = str;
            Make_Row.appendChild(make_td);

            // Ad Sub Cat
            adsubcat = "ads" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.setAttribute("class", "dtGrid");
            if (adsubcat_vari.value != '0') {
                str = "<input class=\"btextforgrid\" type=\"text\"  id=" + adsubcat + " value=" + adsubcat_vari.value + ">";
            }
            else {
                str = "<input class=\"btextforgrid\" type=\"text\"  id=" + adsubcat + " value=''>";
            }

            make_td.innerHTML = str;
            Make_Row.appendChild(make_td);

            //color
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.setAttribute("class", "dropdownforgrid");
            if (color_vari.value != '0') {
                str = "<input class=\"btextforgrid\" type=\"text\"  id=" + colid + " value=" + color_vari.value + " >";
            }
            else {
                str = "<input class=\"btextforgrid\" type=\"text\"  id=" + colid + " value='' >";
            }

            make_td.innerHTML = str;
            Make_Row.appendChild(make_td);

            premid = "prem" + i;
            prem1id = "premone" + i;
            height = "hei" + i;
            width = "wid" + i;
            size = "siz" + i;
            pagepost = "pagpos" + i;
            noofcol = "nocol" + i;
            //*************bind siz and col
            if (column_vari.disabled == true) {
                make_td = document.createElement("td");
                make_td.align = "center";
                str = "<input class=\"btextsmallsizeH\" style=\" background-color: White;\" id=" + height + "   type=\"text\"  value=" + adsize1val + ">";
                make_td.innerHTML = str;
                Make_Row.appendChild(make_td);

                make_td = document.createElement("td");
                make_td.align = "center";
                str = "<input class=\"btextsmallsizeH\" id=" + width + " style=\"background-color:White;\"   type=\"text\"  value=" + adsize2val + ">";
                make_td.innerHTML = str;
                Make_Row.appendChild(make_td);

                make_td = document.createElement("td");
                make_td.align = "center";
                str = "<input class=\"btextsmallsizeH\" disabled id=" + noofcol + "   type=\"text\"  value=" + colval + ">";
                make_td.innerHTML = str;
                Make_Row.appendChild(make_td);

                make_td = document.createElement("td");
                make_td.align = "center";
                str = "<input class=\"btextsmallsize\" disabled id=" + size + " type=\"text\"  value=" + areaval + ">";
                make_td.innerHTML = str;
                Make_Row.appendChild(make_td);

            }
            else {
                if (document.getElementById('hdnprefcomngrd').value == 'Y') {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<input class=\"btextsmallsizeH\" style=\" background-color: White;\" id=" + height + "  type=\"text\"  value=" + adsize1val + ">";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<input class=\"btextsmallsizeH\"  id=" + width + " style=\"background-color:White;\"   type=\"text\"  value=" + adsize2val + ">";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<input class=\"btextsmallsizeH\"  id=" + noofcol + "   type=\"text\"  value=" + colval + ">";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<input class=\"btextsmallsize\" disabled id=" + size + " type=\"text\"  value=" + areaval + ">";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<input class=\"btextsmallsizeH\" disabled style=\" background-color: White;\" id=" + height + "  type=\"text\"  value=" + adsize1val + ">";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<input class=\"btextsmallsizeH\" disabled  id=" + width + " style=\"background-color:White;\"   type=\"text\"  value=" + adsize2val + ">";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<input class=\"btextsmallsizeH\" disabled  id=" + noofcol + "   type=\"text\"  value=" + colval + ">";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<input class=\"btextsmallsize\" disabled id=" + size + " type=\"text\"  value=" + areaval + ">";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);
                }

            }


            //insert status
            insertsta = "inssta" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input class=\"btextforgrid\" disabled  type=\"text\" id=" + insertsta + "  value='booked'>";
            Make_Row.appendChild(make_td);



            //pageno,remark,upload
            pageno_inserts = "pagno" + i;
            remark_inserts = "rem" + i;
            caption_inserts = "cap" + i;
            picfield = "pic" + i;

            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input  class=\"btextforinsertright\"   type=\"text\" id=" + pageno_inserts + "  value=\"\">";
            Make_Row.appendChild(make_td);
            if (chkbtnStatus == "modify") {
                make_td = document.createElement("td");
                make_td.align = "center";
                make_td.innerHTML = "<input class=\"btextforgrid\" id='insstapub" + i + "' disabled  type=\"text\" value='booked''>";
                Make_Row.appendChild(make_td);
            }
            // for resource no

            var resourceno = "resno" + i;
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[23].childNodes[79].childNodes[0].nodeValue == "enable") {

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\"  type=\"text\" id=" + resourceno + "  value=''>";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes(11).childNodes(39).text == "enable") {

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\"  type=\"text\" id=" + resourceno + "  value=''>";
                    Make_Row.appendChild(make_td);

                }
            }

            // for sectioncode

            var sectioncode = "seccode" + i;
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[23].childNodes[77].childNodes[0].nodeValue == "enable") {

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\"  type=\"text\" id=" + sectioncode + "  value=''>";
                    Make_Row.appendChild(make_td);
                }
                else {
                    //                        make_td=document.createElement("td");
                    //                         make_td.align="center";
                    //                         make_td.innerHTML="";
                    //                         Make_Row.appendChild(make_td);
                    // str=str+"<td ></td>";
                }
            }
            else {
                if (xmlObj.childNodes(11).childNodes(38).text == "enable") {

                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\"  type=\"text\" id=" + sectioncode + "  value=''>";
                    Make_Row.appendChild(make_td);

                }
                else {
                    //	                     make_td=document.createElement("td");
                    //                         make_td.align="center";
                    //                         make_td.innerHTML="";
                    //                         Make_Row.appendChild(make_td);
                }
            }

            /////////////this is to bind the status material drop down
            matsta = "mat" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            if (matsta_vari.value != "0") {
                str = "<input class=\"btextforgrid\"  id=" + matsta + " type=\"text\"  value=" + matsta_vari.value + ">";
            }
            else {
                str = "<input class=\"btextforgrid\"  id=" + matsta + " type=\"text\">";
            }
            make_td.innerHTML = str;
            Make_Row.appendChild(make_td);

            filename = "fil" + i;
            var upl = "upload" + i
            make_td = document.createElement("td");
            make_td.align = "center";
            str = "<input class=\"btextforgrid\" type=\"text\" id=" + filename + " disabled  value=\"\">";
            make_td.innerHTML = str;
            Make_Row.appendChild(make_td);

            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input  class=\"button1\" type=\"button\"  id=" + upl + " Value=\"Attachment\">";
            Make_Row.appendChild(make_td);

            //// split Button
            var splt = "splt" + i;

            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[23].childNodes[75].childNodes[0].nodeValue == "enable" && document.getElementById('hiddenuomdesc').value == "CD" && ds.Tables[0].Rows[s].PRIORITY != '1' && ds.Tables[0].Rows[s].SPLIT == 'Y')//ds.Tables[0].Rows[s].PUBCODE!=document.getElementById('hiddenqbcpub').value && document.getElementById('hiddenqbcpub').value!="0")
                {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input  class=\"buttonsplit\" type=\"button\" Value=\"Split\" id=" + splt + " >";
                    Make_Row.appendChild(make_td);
                    //str=str+"<td width=\"50px\"><input  class=\"buttonsplit\" type=\"button\" Value=\"Split\" id="+splt+" ></td>";//onclick=\"return opensplitedition('"+ds.Tables[0].Rows[s].Edition_Name+"','"+i+"');\" 
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes(11).childNodes(37).text == "enable" && document.getElementById('hiddenuomdesc').value == "CD" && ds.Tables[0].Rows[s].PRIORITY != '1' && ds.Tables[0].Rows[s].SPLIT == 'Y')//ds.Tables[0].Rows[s].PUBCODE!=document.getElementById('hiddenqbcpub').value && document.getElementById('hiddenqbcpub').value!="0")
                {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input  class=\"buttonsplit\" type=\"button\" Value=\"Split\" id=" + splt + " >";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "";
                    Make_Row.appendChild(make_td);
                }
            }
            //// sub edition detail Button
            var subedi = "subedi" + i;

            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[23].childNodes[73].childNodes[0].nodeValue == "enable")//ds.Tables[0].Rows[s].PUBCODE!=document.getElementById('hiddenqbcpub').value && document.getElementById('hiddenqbcpub').value!="0")
                {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input  class=\"buttonsplit\" type=\"button\" Value=\"Detail\" id=" + subedi + ">";
                    Make_Row.appendChild(make_td);
                    //str=str+"<td width=\"50px\"><input  class=\"buttonsplit\" type=\"button\" Value=\"Detail\" id="+subedi+"></td>";
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes(11).childNodes(36).text == "enable")//ds.Tables[0].Rows[s].PUBCODE!=document.getElementById('hiddenqbcpub').value && document.getElementById('hiddenqbcpub').value!="0")
                {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input  class=\"buttonsplit\" type=\"button\" Value=\"Detail\" id=" + subedi + " >";
                    Make_Row.appendChild(make_td);
                    //  str=str+"<td width=\"50px\"><input  class=\"buttonsplit\" type=\"button\" Value=\"Detail\" id="+subedi+" ></td>";
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "";
                    Make_Row.appendChild(make_td);
                }
            }

            make_td = document.createElement("td");
            make_td.align = "center";
            if (caption_per.value != '') {
                make_td.innerHTML = "<input  class=\"btextforgrid\" type=\"text\" id=" + caption_inserts + " value='" + caption_per.value + "'>";
            }
            else {
                make_td.innerHTML = "<input  class=\"btextforgrid\"    type=\"text\" id=" + caption_inserts + "  value=\"\">";
            }
            Make_Row.appendChild(make_td);

            //bind Remark
            make_td = document.createElement("td");
            make_td.align = "center";
            if (remarks_per.value != '') {
                make_td.innerHTML = "<input  class=\"btextforgrid\" type=\"text\" id=" + remark_inserts + " value='" + remarks_per.value + "'>";
            }
            else {
                make_td.innerHTML = "<input  class=\"btextforgrid\"    type=\"text\" id=" + remark_inserts + "  value=\"\">";
            }
            Make_Row.appendChild(make_td);

            cardid = "card" + i;
            //this is the function cretaed to get the solo edition rate break up with referrence  to the package selected 
            var cs = 0;
            for (cs = 0; cs <= ds.Tables[8].Rows.length - 1; cs++) {
                if (ds.Tables[0].Rows[i].Edition_Name != undefined) {
                    if (ds.Tables[0].Rows[i].Edition_Name == ds.Tables[8].Rows[cs].Edition_Name) {
                        //str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value="+ds.Tables[8].Rows[cs].weekrate+">";
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" title='" + "Insert No:" + insertval + ",Edition:" + ds.Tables[0].Rows[s].Edition_Name + ",Date:" + nDate + "' id=" + cardid + " value=" + ds.Tables[8].Rows[cs].weekrate + ">";
                        Make_Row.appendChild(make_td);
                    }
                }
            }
            ///////////////////////

            if (ds.Tables[8].Rows.length == 0) {
                //str=str+"<input class=\"btextforgrid\" disabled type=\"text\" id="+cardid+" value=\"\">";
                make_td = document.createElement("td");
                make_td.align = "center";
                make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" title='" + "Insert No:" + insertval + ",Edition:" + ds.Tables[0].Rows[s].Edition_Name + ",Date:" + nDate + "' id=" + cardid + " value=\"\">";
                Make_Row.appendChild(make_td);
            }

            discrate = "disrat" + i;
            insertsta = "inssta" + i;
            billstat = "bill" + i;

            ////////this is to bind the status of insertion drop down  agrred

            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input class=\"btextforgrid\"  type=\"text\" id=" + discrate + "  value=" + agreedamt1 + ">";
            Make_Row.appendChild(make_td);

            // str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+agrred+"  value=\"\"></td>";
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + agrred + "  value=\"\">";
            Make_Row.appendChild(make_td);


            ////this loop is to bind the page position
            pagstr = "fir";
            make_td = document.createElement("td");
            make_td.align = "center";
            if (drppagepos_vari.value == '0') {
                make_td.innerHTML = "<input class=\"btextsmallsize\" type=\"text\" id=" + pagepost + "   value=\"\">";
            }
            else {
                make_td.innerHTML = "<input class=\"btextsmallsize\" type=\"text\" id=" + pagepost + "   value='" + drppagepos_vari.value + "'>";
            }

            Make_Row.appendChild(make_td);




            ////////////this is to for larest date

            late = "lat" + i;
            repeat = "rep" + i;
            var dat = "mm+" / "+" / "+dd+" / "+yyyy";

            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[1].childNodes[0].nodeValue != "hide") {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgriddate\" type=\"text\" id=" + late + "   value=\"\" >";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgriddate\" type=\"text\" id=" + late + "   value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
                if (xmlObj.childNodes[25].childNodes[3].childNodes[0].nodeValue != "hide") {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgriddate\" type=\"text\" id=" + repeat + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgriddate\" type=\"text\" id=" + repeat + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }

            }
            else {
                if (xmlObj.childNodes[12].childNodes[0].childNodes[0].nodeValue != "hide") {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgriddate\" type=\"text\" id=" + late + "   value=\"\" >";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgriddate\" type=\"text\" id=" + late + "   value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
                if (xmlObj.childNodes[12].childNodes[1].childNodes[0].nodeValue != "hide") {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgriddate\" type=\"text\" id=" + repeat + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgriddate\" type=\"text\" id=" + repeat + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }

            }

            namecode = "one";

            premper = "premper" + i;
            premper1 = "premperone" + i;
            adtypid = "adtyp" + i;
            var namecode2 = "two";
            preall = "preall" + i;
            adcat = "adcat" + i;
            page = "pgpre" + i;
            pageprem = "pagper" + i;
            var h;
            ///this is to bind the page prem 2 drp down
            pagstr = "sec"
            make_td = document.createElement("td");
            make_td.align = "center";
            if (pagepremcopy.value == "0" || pagepremcopy.value == "")//chnage for negative amt mimoh
            {
                make_td.innerHTML = "<input class=\"btextsmallsizeH\" type=\"text\" id=" + premid + " value=\"\">";
            }
            else {
                make_td.innerHTML = "<input class=\"btextsmallsizeH\" type=\"text\" id=" + premid + " value='" + pagepremcopy.value + "'>";
            }
            Make_Row.appendChild(make_td);
            make_td = document.createElement("td");
            make_td.align = "center";
            if (pagepremper.value == "" || pagepremper.value == "0")//chnage for negative amt mimoh
            {
                make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id=" + premper + " value=\"\">";
            }
            else {
                make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id=" + premper + " value='" + pagepremper.value + "'>";
            }
            Make_Row.appendChild(make_td);
            //////////////this is to bind the drop down for accepting the premium
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[5].childNodes[0].nodeValue != "hide") {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<select id=" + preall + " disabled class=\"dropdownforgrid\">";
                    str = str + "<option value=\"0\">Select</option>";
                    str = str + "<option value=\"1\">Yes</option>";
                    str = str + "<option value=\"2\">No</option>";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<select id=" + preall + "  class=\"dropdownforgrid\">";
                    str = str + "<option value=\"0\">Select</option>";
                    str = str + "<option value=\"1\">Yes</option>";
                    str = str + "<option value=\"2\">No</option>";
                    make_td.innerHTML = str;
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            } else {
                if (xmlObj.childNodes[12].childNodes[2].childNodes[0].nodeValue != "hide") {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<select id=" + preall + " disabled class=\"dropdownforgrid\">";
                    str = str + "<option value=\"0\">Select</option>";
                    str = str + "<option value=\"1\">Yes</option>";
                    str = str + "<option value=\"2\">No</option>";
                    make_td.innerHTML = str;
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    str = "<select id=" + preall + "  class=\"dropdownforgrid\">";
                    str = str + "<option value=\"0\">Select</option>";
                    str = str + "<option value=\"1\">Yes</option>";
                    str = str + "<option value=\"2\">No</option>";
                    make_td.innerHTML = str;
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }

            //to bind the ad category    
            make_td = document.createElement("td");
            make_td.align = "center";
            if (adcat_vari.value != '0') {
                make_td.innerHTML = "<input  class=\"dropdownforgrid\" type=\"text\" id=" + adcat + " value='" + adcat_vari.value + "'>";
            }
            else {
                make_td.innerHTML = "<input  class=\"dropdownforgrid\" type=\"text\" id=" + adcat + " >";
            }
            Make_Row.appendChild(make_td);

            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[7].childNodes[0].nodeValue != "hide") {
                    if (dbill == "") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        dbill = dbill + "<select id=" + billstat + " class=\"dropdownforgrid\">";
                        /////////////this function is to bind the bill status dropdown
                        var c = 0;
                        for (c = 1; c <= xmlObj.childNodes[3].childNodes.length - 1; c = c + 4) {
                            dbill = dbill + "<option value=" + xmlObj.childNodes[3].childNodes[c + 2].childNodes[0].nodeValue + ">" + xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue + "</option>";
                        }
                        dbill = dbill + "</select>";
                        make_td.innerHTML = dbill;
                        Make_Row.appendChild(make_td);
                    }
                    else {
                        // str=str+dbill.replace("bill"+dcou,billstat);          
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        str = dbill.replace("bill" + dcou, billstat);
                        make_td.innerHTML = str;
                        Make_Row.appendChild(make_td);
                    }
                }
                else {
                    if (dbill == "") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        dbill = dbill + "<select id=" + billstat + " class=\"dropdownforgrid\">";
                        /////////////this function is to bind the bill status dropdown
                        var c = 0;
                        for (c = 1; c <= xmlObj.childNodes[3].childNodes.length - 1; c = c + 4) {
                            dbill = dbill + "<option value=" + xmlObj.childNodes[3].childNodes[c + 2].childNodes[0].nodeValue + ">" + xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue + "</option>";
                        }
                        dbill = dbill + "</select>";
                        make_td.innerHTML = dbill;
                        make_td.style.display = "none";
                        Make_Row.appendChild(make_td);
                    }
                    else {
                        // str=str+dbill.replace("bill"+dcou,billstat);          
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        str = dbill.replace("bill" + dcou, billstat);
                        make_td.innerHTML = str;
                        make_td.style.display = "none";
                        Make_Row.appendChild(make_td);
                    }
                }
            }
            else {
                if (xmlObj.childNodes[12].childNodes[3].childNodes[0].nodeValue != "hide") {
                    if (dbill == "") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        dbill = dbill + "<select id=" + billstat + " class=\"dropdownforgrid\">";
                        /////////////this function is to bind the bill status dropdown
                        var c = 0;
                        for (c = 1; c <= xmlObj.childNodes[3].childNodes.length - 1; c = c + 4) {
                            dbill = dbill + "<option value=" + xmlObj.childNodes[3].childNodes[c + 2].childNodes[0].nodeValue + ">" + xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue + "</option>";
                        }
                        dbill = dbill + "</select>";
                        make_td.innerHTML = dbill;
                        Make_Row.appendChild(make_td);
                    }
                    else {
                        // str=str+dbill.replace("bill"+dcou,billstat);          
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        str = dbill.replace("bill" + dcou, billstat);
                        make_td.innerHTML = str;
                        Make_Row.appendChild(make_td);
                    }
                }
                else {
                    if (dbill == "") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        dbill = dbill + "<select id=" + billstat + " class=\"dropdownforgrid\">";
                        /////////////this function is to bind the bill status dropdown
                        var c = 0;
                        for (c = 1; c <= xmlObj.childNodes[3].childNodes.length - 1; c = c + 4) {
                            dbill = dbill + "<option value=" + xmlObj.childNodes[3].childNodes[c + 2].childNodes[0].nodeValue + ">" + xmlObj.childNodes[3].childNodes[c].childNodes[0].nodeValue + "</option>";
                        }
                        dbill = dbill + "</select>";
                        make_td.innerHTML = dbill;
                        make_td.style.display = "none";
                        Make_Row.appendChild(make_td);
                    }
                    else {
                        // str=str+dbill.replace("bill"+dcou,billstat);          
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        str = dbill.replace("bill" + dcou, billstat);
                        make_td.innerHTML = str;
                        make_td.style.display = "none";
                        Make_Row.appendChild(make_td);
                    }
                }
            }

            paid = "pai" + i;
            solo = "sol" + i;
            gross = "gro" + i;
            var discount_ = "disc_" + i;
            ///////////////this is to bind the drop down for paid/free insertion
            if (ds.Tables[9].Rows[0].Paid_permission == "0") {
                if (browser != "Microsoft Internet Explorer") {
                    if (xmlObj.childNodes[25].childNodes[13].childNodes[0].nodeValue != "hide") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        if (document.getElementById('hiddisceditgrid').value == "Y")
                            make_td.innerHTML = "<input class=\"btextsmallsizeH\" type=\"text\" id=" + discount_ + "   value=\"\" >";
                        else
                            make_td.innerHTML = "<input class=\"btextsmallsizeH\" disabled type=\"text\" id=" + discount_ + "   value=\"\" >";
                        Make_Row.appendChild(make_td);
                    }
                    if (dpaid == "") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        dpaid = dpaid + "<select id=" + paid + " class=\"dropdownforgridsmall\" disabled>";
                        dpaid = dpaid + "<option value=\"Y\">Yes</option>";
                        dpaid = dpaid + "<option value=\"N\">No</option>";
                        dpaid = dpaid + "<option value=\"P\">Paid</option>";
                        if (document.getElementById('hidnprint').value == "Y")
                            dpaid = dpaid + "<option value=\"NP\">NPrint</option>";
                        dpaid = dpaid + "</select>";
                        make_td.innerHTML = dpaid;
                        Make_Row.appendChild(make_td);
                    }
                    else {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        str = dpaid.replace("pai" + dcou, paid);
                        make_td.innerHTML = str;
                        Make_Row.appendChild(make_td);
                    }
                }
                else {
                    if (xmlObj.childNodes[12].childNodes[6].childNodes[0].nodeValue != "hide") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        if (document.getElementById('hiddisceditgrid').value == "Y")
                            make_td.innerHTML = "<input class=\"btextsmallsizeH\" type=\"text\" id=" + discount_ + "   value=\"\" >";
                        else
                            make_td.innerHTML = "<input class=\"btextsmallsizeH\" disabled type=\"text\" id=" + discount_ + "   value=\"\" >";
                        Make_Row.appendChild(make_td);
                    }
                    if (dpaid == "") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        dpaid = dpaid + "<select id=" + paid + " class=\"dropdownforgridsmall\" disabled >";
                        dpaid = dpaid + "<option value=\"Y\">Yes</option>";
                        dpaid = dpaid + "<option value=\"N\">No</option>";
                        dpaid = dpaid + "<option value=\"P\">Paid</option>";
                        if (document.getElementById('hidnprint').value == "Y")
                            dpaid = dpaid + "<option value=\"NP\">NPrint</option>";
                        dpaid = dpaid + "</select>";
                        make_td.innerHTML = dpaid;
                        Make_Row.appendChild(make_td);
                    }
                    else {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        str = dpaid.replace("pai" + dcou, paid);
                        make_td.innerHTML = str;
                        Make_Row.appendChild(make_td);
                    }
                }
            }
            else {
                if (browser != "Microsoft Internet Explorer") {
                    if (xmlObj.childNodes[25].childNodes[13].childNodes[0].nodeValue != "hide") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        if (document.getElementById('hiddisceditgrid').value == "Y")
                            make_td.innerHTML = "<input class=\"btextsmallsizeH\" type=\"text\" id=" + discount_ + "   value=\"\" >";
                        else
                            make_td.innerHTML = "<input class=\"btextsmallsizeH\" disabled type=\"text\" id=" + discount_ + "   value=\"\" >";
                        Make_Row.appendChild(make_td);
                    }
                    if (xmlObj.childNodes[23].childNodes[37].childNodes[0].nodeValue == "enable") {
                        if (dpaid == "") {
                            make_td = document.createElement("td");
                            make_td.align = "center";
                            dpaid = dpaid + "<select id=" + paid + " class=\"dropdownforgridsmall\">";
                            dpaid = dpaid + "<option value=\"Y\">Yes</option>";
                            dpaid = dpaid + "<option value=\"N\">No</option>";
                            dpaid = dpaid + "<option value=\"P\">Paid</option>";
                            if (document.getElementById('hidnprint').value == "Y")
                                dpaid = dpaid + "<option value=\"NP\">NPrint</option>";
                            dpaid = dpaid + "</select>";
                            make_td.innerHTML = dpaid;
                            Make_Row.appendChild(make_td);
                        }
                        else {
                            make_td = document.createElement("td");
                            make_td.align = "center";
                            str = dpaid.replace("pai" + dcou, paid);
                            make_td.innerHTML = str;
                            Make_Row.appendChild(make_td);
                        }
                    }
                    else {
                        if (dpaid == "") {
                            make_td = document.createElement("td");
                            make_td.align = "center";
                            dpaid = dpaid + "<select id=" + paid + " class=\"dropdownforgridsmall\" disabled>";
                            dpaid = dpaid + "<option value=\"Y\">Yes</option>";
                            dpaid = dpaid + "<option value=\"N\">No</option>";
                            dpaid = dpaid + "<option value=\"P\">Paid</option>";
                            if (document.getElementById('hidnprint').value == "Y")
                                dpaid = dpaid + "<option value=\"NP\">NPrint</option>";
                            dpaid = dpaid + "</select>";
                            make_td.innerHTML = dpaid;
                            Make_Row.appendChild(make_td);
                        }
                        else {
                            make_td = document.createElement("td");
                            make_td.align = "center";
                            str = dpaid.replace("pai" + dcou, paid);
                            make_td.innerHTML = str;
                            Make_Row.appendChild(make_td);
                        }
                    }
                }
                else {
                    if (xmlObj.childNodes[12].childNodes[6].childNodes[0].nodeValue != "hide") {
                        make_td = document.createElement("td");
                        make_td.align = "center";
                        if (document.getElementById('hiddisceditgrid').value == "Y")
                            make_td.innerHTML = "<input class=\"btextsmallsizeH\" type=\"text\" id=" + discount_ + "   value=\"\" >";
                        else
                            make_td.innerHTML = "<input class=\"btextsmallsizeH\" disabled type=\"text\" id=" + discount_ + "   value=\"\" >";
                        Make_Row.appendChild(make_td);
                    }
                    if (xmlObj.childNodes[11].childNodes[18].childNodes[0].nodeValue == "enable") {
                        if (dpaid == "") {
                            make_td = document.createElement("td");
                            make_td.align = "center";
                            dpaid = dpaid + "<select id=" + paid + " class=\"dropdownforgridsmall\" >";
                            dpaid = dpaid + "<option value=\"Y\">Yes</option>";
                            dpaid = dpaid + "<option value=\"N\">No</option>";
                            dpaid = dpaid + "<option value=\"P\">Paid</option>";
                            if (document.getElementById('hidnprint').value == "Y")
                                dpaid = dpaid + "<option value=\"NP\">NPrint</option>";
                            dpaid = dpaid + "</select>";
                            make_td.innerHTML = dpaid;
                            Make_Row.appendChild(make_td);
                        }
                        else {
                            make_td = document.createElement("td");
                            make_td.align = "center";
                            str = dpaid.replace("pai" + dcou, paid);
                            make_td.innerHTML = str;
                            Make_Row.appendChild(make_td);
                        }
                    }
                    else {
                        if (dpaid == "") {
                            make_td = document.createElement("td");
                            make_td.align = "center";
                            dpaid = dpaid + "<select id=" + paid + " class=\"dropdownforgridsmall\" disabled >";
                            dpaid = dpaid + "<option value=\"Y\">Yes</option>";
                            dpaid = dpaid + "<option value=\"N\">No</option>";
                            dpaid = dpaid + "<option value=\"P\">Paid</option>";
                            if (document.getElementById('hidnprint').value == "Y")
                                dpaid = dpaid + "<option value=\"NP\">NPrint</option>";
                            dpaid = dpaid + "</select>";
                            make_td.innerHTML = dpaid;
                            Make_Row.appendChild(make_td);
                        }
                        else {
                            make_td = document.createElement("td");
                            make_td.align = "center";
                            str = dpaid.replace("pai" + dcou, paid);
                            make_td.innerHTML = str;
                            Make_Row.appendChild(make_td);
                        }
                    }
                }
            }

            billamt = "ba" + i;
            billrate = "br" + i;
            agnamnt = "agmn" + i;
            adlgn = "adlag" + i;
            spldisc = "spld" + i;
            cashdisc = "cashd" + i;
            roundoffval = "roundoffval" + i;
            str = str + "</select></td>";

            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + solo + "  value=\"\">";
            Make_Row.appendChild(make_td);

            //str=str+"<td><input class=\"btextforgrid\" disabled type=\"text\" id="+gross+"  value=\"\"></td>";
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + gross + "  value=\"\">";
            Make_Row.appendChild(make_td);

            // str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billamt+"  value=\"\"></td>";
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + billamt + "  value=\"\">";
            Make_Row.appendChild(make_td);

            // new field for local gross and local bill amount
            var grosslocal = "grolocal" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + grosslocal + "  value=\"\">";
            Make_Row.appendChild(make_td);

            // str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billamt+"  value=\"\"></td>";
            var billamtlocal = "balocal" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + billamtlocal + "  value=\"\">";
            Make_Row.appendChild(make_td);
            //---
            //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[9].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + billrate + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + billrate + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes[12].childNodes[4].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + billrate + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + billrate + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[15].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + agnamnt + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + agnamnt + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes[12].childNodes[7].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + agnamnt + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + agnamnt + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }

            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[17].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + adlgn + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + adlgn + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes[12].childNodes[8].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + adlgn + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + adlgn + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }

            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[19].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + spldisc + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + spldisc + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes[12].childNodes[9].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + spldisc + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + spldisc + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }

            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[21].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + cashdisc + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + cashdisc + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes[12].childNodes[10].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + cashdisc + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + cashdisc + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[23].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + roundoffval + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + roundoffval + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }
            else {
                if (xmlObj.childNodes[12].childNodes[11].childNodes[0].nodeValue != "hide") {
                    //str=str+"<td><input class=\"btextforgrid\"    type=\"text\" id="+billrate+"  value=\"\"></td>";
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + roundoffval + "  value=\"\">";
                    Make_Row.appendChild(make_td);
                }
                else {
                    make_td = document.createElement("td");
                    make_td.align = "center";
                    make_td.innerHTML = "<input class=\"btextforgrid\" disabled type=\"text\" id=" + roundoffval + "  value=\"\">";
                    make_td.style.display = "none";
                    Make_Row.appendChild(make_td);
                }
            }

            // for VTS Button
            var vtsbtnid = "vtsbtn" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input  class=\"button1\" id=" + vtsbtnid + " type=\"button\" Value=\"VTS\">";
            Make_Row.appendChild(make_td);
            var vtsid = "vts" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input  type=\"hidden\" id=" + vtsid + ">";
            Make_Row.appendChild(make_td);

            ////bhanu
            var dealerh = "dealerh" + i;
            var dealerw = "dealerw" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input  class=\"btextsmallsizeH\"    type=\"text\" id=" + dealerh + "  value=\"\">";
            Make_Row.appendChild(make_td);


            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input  class=\"btextsmallsizeH\"    type=\"text\" id=" + dealerw + "  value=\"\">";
            Make_Row.appendChild(make_td);
            ////bhanu end

            showid = "sho" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            str = "<input class=\"btextforgrid\" style=\"display:none;\" type=\"text\" id=" + showid + "  value='0'>";
            make_td.innerHTML = str;
            Make_Row.appendChild(make_td);

            pkgcodegrid = 'hiddenpckcode' + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + pkgcodegrid + "' value='" + ds.Tables[0].Rows[s].EDITION_CODE + "'>";
            Make_Row.appendChild(make_td);

            var pubcode = 'pubcode' + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + pubcode + "' value='" + ds.Tables[0].Rows[s].PUBCODE + "'>";
            Make_Row.appendChild(make_td);

            //This below code for  puting the number of occurance of packages into grid
            var pkg_ins = 'pkg_ins' + i;
            //for (var countpkg = 0; countpkg < pkgcopy_vari.length; countpkg++) {
            var pkgcopy = pkgcopy_vari.options[0].value;
            var arrpkgcopy = pkgcopy.split('@');
            var pkgcopycode = arrpkgcopy[0];
            var arr_pkg_ins_value = arrpkgcopy[1].split('(');
            var pkg_ins_value = arr_pkg_ins_value[1].replace(')', '');
            if (pkgcopycode == ds.Tables[0].Rows[s].EDITION_CODE) {
                // str=str+"<td><input disabled class=\"btextsmallsize\" type=\"text\" id='"+pkg_ins+"' value="+pkg_ins_value+"></td>";
                make_td = document.createElement("td");
                make_td.align = "center";
                make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + pkg_ins + "' value='" + pkg_ins_value + "'>";
                Make_Row.appendChild(make_td);
            }
            /*else {
                make_td = document.createElement("td");
                make_td.align = "center";
                make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + pkg_ins + "' value='" + pkg_ins_value + "'>";
                Make_Row.appendChild(make_td);
            }*/
            //}

            pkg_alias = 'pkg_alias' + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + pkg_alias + "' value='" + ds.Tables[0].Rows[s].PKGNAME + "'>";
            Make_Row.appendChild(make_td);

            var spltdata = "spltdata" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + spltdata + "' value=\"\">";
            Make_Row.appendChild(make_td);
            //   str=str+"<td><input disabled class=\"btextsmallsize\" type=\"text\" id='"+spltdata+"' value=\"\"></td>";

            var subedidata = "subedidata" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + subedidata + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var vat = "vat" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + vat + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var boxc = "boxc" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + boxc + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var vat_inc = "vat_inc" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + vat_inc + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var coupan = "coupan" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + coupan + "' value=\"\">";
            Make_Row.appendChild(make_td);


            var clicatamt = "clicatamt" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + clicatamt + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var flatfreqamt = "flatfreqamt" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + flatfreqamt + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var catamt = "catamt" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + catamt + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var premamt = "premamt" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + premamt + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var GSTAMT = "GSTAMT" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + GSTAMT + "' value=\"\">";
            Make_Row.appendChild(make_td);

            var GSTGD = "GSTGD" + i;
            make_td = document.createElement("td");
            make_td.align = "center";
            make_td.innerHTML = "<input disabled class=\"btextsmallsize\" type=\"text\" id='" + GSTGD + "' value=\"\">";
            Make_Row.appendChild(make_td);

            gridtab_vari.getElementsByTagName("tbody")[0].appendChild(Make_Row);
            if (nDate != "") {
                var date_res = dropDateCheck(nDate, document.getElementById(id), ds.Tables[0].Rows[s].EDITION_CODE, ds.Tables[0].Rows[s].PKGNAME, ds.Tables[0].Rows[s].Edition_Name);
                if (date_res == false) {
                    alert(document.getElementById(id).value + " Date is no issue date of edition " + ds.Tables[0].Rows[s].PKGNAME);
                    document.getElementById(id).value = "";

                }
            }
            idnew = parseInt(idnew) + 1;

            i = parseInt(i) + 1;
        }

    } //end of for    
    if (browserversion > 6) {
        $(".dropdownforgridsmall").change(function () {
            if (document.activeElement.id.indexOf("pai") >= 0) {
                blankGross();
            }
        });
        $(".btextsmallsizeH").change(function () {
            if (document.activeElement.id.indexOf("prem") >= 0 || document.activeElement.id.indexOf("pgpre") >= 0 || document.activeElement.id.indexOf("nocol") >= 0 || document.activeElement.id.indexOf("hei") >= 0 || document.activeElement.id.indexOf("wid") >= 0 || document.activeElement.id.indexOf("ins") >= 0) {
                var i;
                if (document.activeElement.id.indexOf("disc_") >= 0) {
                    blankGross();

                }
                if (document.activeElement.id.indexOf("prem") >= 0) {
                    i = document.activeElement.id.substring(4, document.activeElement.id.length + 1);
                    var premid = "prem" + i;
                    var f = getpercenprem(premid, i, namecode)
                    if (f == false)
                        return false;
                }
                else if (document.activeElement.id.indexOf("pgpre") >= 0) {
                    i = document.activeElement.id.substring(5, document.activeElement.id.length + 1);
                    var page = "pgpre" + i;
                    var pagstr = "sec";
                    var f = getpageprem(page, i, pagstr);
                    if (f == false)
                        return false;
                }
                else {
                    if (document.activeElement.id.indexOf("nocol") >= 0) {
                        i = document.activeElement.id.substring(5, document.activeElement.id.length + 1);

                    }
                    else {
                        i = document.activeElement.id.substring(3, document.activeElement.id.length + 1);

                    }
                    var height = "hei" + i;
                    var width = "wid" + i;
                    var inserts = "ins" + i;
                    var insertval = document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(i, 10) + 1].cells[0].innerHTML;
                    var noofcol = "nocol" + i;
                    var f = gettotalsize(height, width, i, inserts, insertval, noofcol);
                    if (f == false)
                        return false;
                }
            }
        });
        $(".btextforgriddate").change(function () {
            if (document.activeElement.id.indexOf("Text") >= 0) {
                var f = chkDateforGrid(this);
                if (f == false)
                    return false;
            }
            else if (document.activeElement.id.indexOf("rep") >= 0 || document.activeElement.id.indexOf("lat") >= 0) {
                checkdate(document.getElementById(document.activeElement.id));
            }
        });
        for (i = count; i < gridtab_vari.getElementsByTagName("tbody")[0].rows.length - 1; i++) {

            if (repeatdate == "0" || repeatdate == "1") {
                var id = "Text" + temp;
                if (document.getElementById('Text' + temp) == null)
                    return false;
                //   if(caldatemonth[temp]!=undefined)
                //  {
                // var mmM=caldatemonth[temp].toString();
                //}else{
                var mmM = parseInt(monthSelected, 10) + 1;
                mmM = mmM.toString();
                //}
                if (mmM.toString().length == 1)
                    mmM = "0" + mmM.toString();
                if (dateSelected != undefined) {
                    if (dateSelected.toString().length == 1)
                        dateSelected = "0" + dateSelected.toString();
                    if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
                        vvalue = mmM + "/" + dateSelected + "/" + yearSelected;
                    }
                    else if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
                        vvalue = dateSelected + "/" + mmM + "/" + yearSelected;;
                    }
                    else if (document.getElementById('hiddendateformat').value = "yyyy/mm/dd") {
                        vvalue = yearSelected + "/" + mmM + "/" + dateSelected;;
                    }
                }
                if (document.getElementById('Text' + i) != null && document.getElementById('Text' + i).value != "" && checkflag == "2") {
                    vvalue = document.getElementById('Text' + i).value;

                }

                if (dateSelected != undefined && (checkflag == 1 || checkflag == 2)) {
                    if (browser != "Microsoft Internet Explorer") {
                        var pkgfullname = document.getElementById('pkg_alias' + i).value;
                        var pkgid = document.getElementById('hiddenpckcode' + i).value;
                        var pkgname = document.getElementById('pkg_alias' + i).value;
                        var compcode = document.getElementById('hiddencompcode').value;

                        dateday = vvalue;

                        document.getElementById('Text' + i).value = vvalue;
                    }
                    else {
                        var pkgfullname = document.getElementById('pkg_alias' + i).value;
                        var pkgid = document.getElementById('hiddenpckcode' + i).value;
                        var pkgname = document.getElementById('pkg_alias' + i).value;
                        var compcode = document.getElementById('hiddencompcode').value;
                        dateday = vvalue;

                        document.getElementById('Text' + i).value = vvalue;
                    }
                    if (browser != "Microsoft Internet Explorer") {
                        var httpRequest = null;;
                        httpRequest = new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                            httpRequest.overrideMimeType('text/xml');
                        }

                        httpRequest.onreadystatechange = function () { alertContents(httpRequest) };
                        var adcat = adcat_vari.value;
                        httpRequest.open("GET", "packagename.aspx?center=" + center + "&adtype=" + adtype_vari.value + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + pkgid + "&dateday=" + dateday + "&pkgname=" + pkgfullname + "&pkgalias=" + pkgname, false);
                        httpRequest.send('');
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) {
                                strtext = httpRequest.responseText;
                            }
                            else {
                                alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                            }
                        }
                    }
                    else {
                        validuse = "";
                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                        var adcat = adcat_vari;
                        var center = '';
                        if (center_vari != null) {
                            center = center_vari.value;
                            if (chkall_vari != null) {
                                if (chkall_vari.checked == true) {
                                    center = '0';
                                }
                            }
                            else {
                                center = '0';
                            }
                        }
                        xml.Open("GET", "packagename.aspx?center=" + center + "&adtype=" + adtype_vari.value + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + pkgid + "&dateday=" + dateday + "&pkgname=" + pkgfullname + "&pkgalias=" + pkgname, false);
                        xml.Send();
                        strtext = xml.responseText;
                    }
                    if (strtext == "NOT A VALID DATE") {
                        alert("NOT A VALID DATE");
                        document.getElementById(id).value = "";
                        document.getElementById(id).focus();
                        //  return false;
                    }
                    if (strtext == "0") {
                        alert("Day is not the publishing day");
                        document.getElementById(id).value = "";
                        //   return false;
                    }
                    else {
                        if (strtext == "1")
                            document.getElementById(id).value = vvalue;
                        else {
                            if (strtext != "") {
                                if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
                                    var txt = strtext;
                                    var txt1 = txt.split("/");
                                    var dd = txt1[0];
                                    var mm1 = txt1[1];
                                    var mm = txt1[1]; //getMonthNo(mm1);
                                    var yy = txt1[2];
                                    caldate[cali] = dd;
                                    caldatemonth[cali] = mm;
                                    caldateyear[cali] = yy;
                                    cali = parseInt(cali, 10) + 1;
                                }
                                else if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
                                    var txt = strtext;
                                    var txt1 = txt.split("/");
                                    var dd = txt1[1];
                                    var mm1 = txt1[0];
                                    var mm = txt1[0]; //getMonthNo(mm1);
                                    var yy = txt1[2];
                                    caldate[cali] = dd;
                                    caldatemonth[cali] = mm;
                                    caldateyear[cali] = yy;
                                    cali = parseInt(cali, 10) + 1;
                                }
                                else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd") {
                                    var txt = strtext;
                                    var txt1 = txt.split("/");
                                    var dd = txt1[2];
                                    var mm1 = txt1[1];
                                    var mm = txt1[1]; //getMonthNo(mm1);
                                    var yy = txt1[0];
                                    caldate[cali] = dd;
                                    caldatemonth[cali] = mm;
                                    caldateyear[cali] = yy;
                                    cali = parseInt(cali, 10) + 1;
                                }
                            }
                            document.getElementById(id).value = strtext;
                            if (vvalue != strtext) {
                                //alert(vvalue + " Date is no issue date of edition " + pkgname);
                                document.getElementById(id).value = "";
                                cali = cali - 1;
                            }
                        }
                    }
                }
            }
            temp = parseInt(temp) + 1;
        }
        checkflag = 1;
    }
    else {

        for (i = count; i < gridtab_vari.getElementsByTagName("tbody")[0].rows.length - 1; i++) {

            var height = "hei" + i;
            var late = "lat" + i;
            var repeat = "rep" + i;
            var page = "pagpos" + i;
            var pagstr = "sec";
            var adcat = "adcat" + i;
            var adsubcat = "ads" + i;
            var premid = "prem" + i;
            var id = "Text" + i;
            var width = "wid" + i;
            var noofcol = "nocol" + i;
            inserts = "ins" + i;
            var paid = "pai" + i;
            var disc = "disc_" + i;
            var discrate1 = "disrat" + i;
            var insertval = document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(i, 10) + 1].cells[1].innerHTML;
            var height_vari = document.getElementById(height);
            var par1 = (height_vari.parentNode).parentNode;
            if (browser != "Microsoft Internet Explorer") {
                document.getElementById(height).onchange = new Function("return gettotalsize('" + height + "','" + width + "'," + i + ",'" + inserts + "'," + insertval + ",'" + noofcol + "');");
                document.getElementById(width).onchange = new Function("return gettotalsize('" + height + "','" + width + "'," + i + ",'" + inserts + "'," + insertval + ",'" + noofcol + "');");
                document.getElementById(noofcol).onchange = new Function("return gettotalsize('" + height + "','" + width + "'," + i + ",'" + inserts + "'," + insertval + ",'" + noofcol + "');");

                document.getElementById(late).onchange = new Function("return checkdate(Form1." + late + ");");
                document.getElementById(repeat).onchange = new Function("return checkdate(Form1." + repeat + ");");
                document.getElementById(page).onchange = "return getpageprem('" + page + "'," + i + ",'" + pagstr + "');";
                document.getElementById(id).onchange = new Function("return chkDateforGrid(this);");
                document.getElementById(premid).onchange = new Function("getpercenprem('" + premid + "'," + i + ",'" + namecode + "')");
                if (document.getElementById(paid) != undefined && document.getElementById(paid) != "undefined" && document.getElementById(paid) != null)
                    document.getElementById(paid).onchange = new Function("return blankGross();");
                if (document.getElementById(disc) != undefined && document.getElementById(disc) != "undefined" && document.getElementById(disc) != null)
                    document.getElementById(disc).onchange = new Function("return blankGross();");
                if (document.getElementById(discrate1) != undefined && document.getElementById(discrate1) != "undefined" && document.getElementById(discrate1) != null)
                    document.getElementById(discrate1).onchange = new Function("return blankGross();");
            }
            else {
                par1.all[height].onchange = new Function("return gettotalsize('" + height + "','" + width + "'," + i + ",'" + inserts + "'," + insertval + ",'" + noofcol + "');");
                par1.all[width].onchange = new Function("return gettotalsize('" + height + "','" + width + "'," + i + ",'" + inserts + "'," + insertval + ",'" + noofcol + "');");
                par1.all[noofcol].onchange = new Function("return gettotalsize('" + height + "','" + width + "'," + i + ",'" + inserts + "'," + insertval + ",'" + noofcol + "');");

                par1.all[late].onchange = new Function("return checkdate(Form1." + late + ");");
                par1.all[repeat].onchange = new Function("return checkdate(Form1." + repeat + ");");
                par1.all[page].onchange = "return getpageprem('" + page + "'," + i + ",'" + pagstr + "');";
                par1.all[id].onchange = new Function("return chkDateforGrid(this);");
                par1.all[premid].onchange = new Function("getpercenprem('" + premid + "'," + i + ",'" + namecode + "')");
                if (par1.all[paid] != undefined && par1.all[paid] != "undefined" && par1.all[paid] != null)
                    par1.all[paid].onchange = new Function("return blankGross();");
                if (par1.all[disc] != undefined && par1.all[disc] != "undefined" && par1.all[disc] != null)
                    par1.all[disc].onchange = new Function("return blankGross();");
                if (par1.all[discrate1] != undefined && par1.all[discrate1] != "undefined" && par1.all[discrate1] != null)
                    par1.all[discrate1].onchange = new Function("return blankGross();");
            }
            if (repeatdate == "0" || repeatdate == "1") {
                var id = "Text" + temp;
                //if (document.getElementById('Text' + temp) == null)
                // return false;
                //  if(caldatemonth[temp]!=null)
                //var mmM=caldatemonth[temp].toString();
                //else{
                var mmM = parseInt(monthSelected, 10) + 1;
                mmM = mmM.toString();
                //}
                if (mmM.toString().length == 1)
                    mmM = "0" + mmM.toString();
                if (dateSelected != undefined) {

                    if (dateSelected.toString().length == 1)
                        dateSelected = "0" + dateSelected.toString();
                    if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
                        vvalue = mmM + "/" + dateSelected + "/" + yearSelected;
                    }
                    else if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
                        vvalue = dateSelected + "/" + mmM + "/" + yearSelected;;
                    }
                    else if (document.getElementById('hiddendateformat').value = "yyyy/mm/dd") {
                        vvalue = yearSelected + "/" + mmM + "/" + dateSelected;;
                    }
                }
                if (document.getElementById('Text' + i) != null && document.getElementById('Text' + i).value != "" && checkflag == "2") {
                    vvalue = document.getElementById('Text' + i).value;

                }
                if (dateSelected != undefined && (checkflag == 1 || checkflag == 2)) {
                    if (browser != "Microsoft Internet Explorer") {
                        var pkgfullname = document.getElementById('pkg_alias' + i).value;
                        var pkgid = document.getElementById('hiddenpckcode' + i).value;
                        var pkgname = document.getElementById('pkg_alias' + i).value;
                        var compcode = document.getElementById('hiddencompcode').value;

                        dateday = vvalue;

                        document.getElementById('Text' + i).value = vvalue;
                    }
                    else {
                        var pkgfullname = par1.all['pkg_alias' + i].value;
                        var pkgid = par1.all['hiddenpckcode' + i].value;
                        var pkgname = par1.all['pkg_alias' + i].value;
                        var compcode = document.getElementById('hiddencompcode').value;
                        dateday = vvalue;

                        par1.all['Text' + i].value = vvalue;
                    }
                    if (browser != "Microsoft Internet Explorer") {
                        var httpRequest = null;;
                        httpRequest = new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                            httpRequest.overrideMimeType('text/xml');
                        }

                        httpRequest.onreadystatechange = function () { alertContents(httpRequest) };
                        var adcat = adcat_vari.value;
                        httpRequest.open("GET", "packagename.aspx?center=" + center + "&adtype=" + adtype_vari.value + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + pkgid + "&dateday=" + dateday + "&pkgname=" + pkgfullname + "&pkgalias=" + pkgname, false);
                        httpRequest.send('');
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) {
                                strtext = httpRequest.responseText;
                            }
                            else {
                                alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                            }
                        }
                    }
                    else {
                        validuse = "";
                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                        var adcat = adcat_vari;
                        var center = '';
                        if (center_vari != null) {
                            center = center_vari.value;
                            if (chkall_vari != null) {
                                if (chkall_vari.checked == true) {
                                    center = '0';
                                }
                            }
                            else {
                                center = '0';
                            }
                        }
                        xml.Open("GET", "packagename.aspx?center=" + center + "&adtype=" + adtype_vari.value + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + pkgid + "&dateday=" + dateday + "&pkgname=" + pkgfullname + "&pkgalias=" + pkgname, false);
                        xml.Send();
                        strtext = xml.responseText;
                    }
                    if (strtext == "NOT A VALID DATE") {
                        alert("NOT A VALID DATE");
                        document.getElementById(id).value = "";
                        document.getElementById(id).focus();
                        // return false;
                    }
                    if (strtext == "0") {
                        alert("Day is not the publishing day");
                        document.getElementById(id).value = "";
                        // return false;
                    }
                    else {
                        if (strtext == "1")
                            document.getElementById(id).value = vvalue;
                        else {
                            if (strtext != "") {
                                if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
                                    var txt = strtext;
                                    var txt1 = txt.split("/");
                                    var dd = txt1[0];
                                    var mm1 = txt1[1];
                                    var mm = txt1[1]; //getMonthNo(mm1);
                                    var yy = txt1[2];
                                    caldate[cali] = dd;
                                    caldatemonth[cali] = mm;
                                    caldateyear[cali] = yy;
                                    cali = parseInt(cali, 10) + 1;
                                }
                                else if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
                                    var txt = strtext;
                                    var txt1 = txt.split("/");
                                    var dd = txt1[1];
                                    var mm1 = txt1[0];
                                    var mm = txt1[0]; //getMonthNo(mm1);
                                    var yy = txt1[2];
                                    caldate[cali] = dd;
                                    caldatemonth[cali] = mm;
                                    caldateyear[cali] = yy;
                                    cali = parseInt(cali, 10) + 1;
                                }
                                else if (document.getElementById('hiddendateformat').value == "yyyy/mm/dd") {
                                    var txt = strtext;
                                    var txt1 = txt.split("/");
                                    var dd = txt1[2];
                                    var mm1 = txt1[1];
                                    var mm = txt1[1]; //getMonthNo(mm1);
                                    var yy = txt1[0];
                                    caldate[cali] = dd;
                                    caldatemonth[cali] = mm;
                                    caldateyear[cali] = yy;
                                    cali = parseInt(cali, 10) + 1;
                                }
                            }
                            document.getElementById(id).value = strtext;
                            if (vvalue != strtext) {
                                //alert(vvalue + " Date is no issue date of edition " + pkgname);
                                document.getElementById(id).value = "";
                                cali = cali - 1;
                            }
                        }
                    }
                }
            }
            temp = parseInt(temp) + 1;
        }
        checkflag = 1;
    }
    checkflag = "0";
    previnsertion = document.getElementById('txtinsertion').value;
    fillcopyfilename();
    constructCalendar();
    noissueflag = false;
    return false;
}
function dateincrease(dat, id, count) {
    var sadate = dat;
    var setdate;
    var dateformat = document.getElementById('hiddendateformat').value;
    if (id == "1") {
        var txt = sadate.split("/");
        if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
            sadate = txt[0] + "/" + txt[1] + "/" + txt[2];
        }
        else if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
            sadate = txt[1] + "/" + txt[0] + "/" + txt[2];;
        }
        else if (document.getElementById('hiddendateformat').value = "yyyy/mm/dd") {
            sadate = txt[1] + "/" + txt[2] + "/" + txt[0];;
        }
        var currdate = new Date(sadate);
        currdate.setDate(currdate.getDate() + count);
        var dd = currdate.getDate();
        var mm = currdate.getMonth() + 1;
        var yyyy = currdate.getFullYear();
        if (mm.toString().length == 1)
            mm = "0" + mm;
        if (dd.toString().length == 1)
            dd = "0" + dd;
        var currdate1 = mm + '/' + dd + '/' + yyyy;
        var currda = dd + '/' + mm + '/' + yyyy;
        var curryear = yyyy + '/' + mm + '/' + dd;

        if (dateformat == "mm/dd/yyyy") {
            return currdate1;

        }
        else if (dateformat == "dd/mm/yyyy") {
            return currda;

        }
        if (dateformat == "yyyy/mm/dd") {
            return curryear;

        }
    }
}


///////////////////anuja
function bindindus_callback(response) {
    var dsinds = response.value;
    if (dsinds == null) {
        alert(response.error.description);
        return false;
    }
    var pkgitem = document.getElementById("lstindus");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select ID-", "0");
    if (dsinds != null && typeof (dsinds) == "object" && dsinds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        //alert(pkgitem.options.length);
        for (var i = 0; i < dsinds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(dsinds.Tables[0].Rows[i].PRODUCT_NAME, dsinds.Tables[0].Rows[i].PRODUCT_CAT);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstindus").focus();
}
function bindsubcat_callback(response) {
    var dsinds = response.value;
    if (dsinds == null) {
        alert(response.error.description);
        return false;
    }
    var pkgitem = document.getElementById("lstprosubcat");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select ID-", "0");
    if (dsinds != null && typeof (dsinds) == "object" && dsinds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        //alert(pkgitem.options.length);
        for (var i = 0; i < dsinds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(dsinds.Tables[0].Rows[i].pro_sub_name, dsinds.Tables[0].Rows[i].pro_subcat_code);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstprosubcat").focus();
}

function funbtnmail() {
    var a = "";
    if (browser != "Microsoft Internet Explorer") {
        document.getElementById('divmail').innerHTML = "";
        a = document.getElementById('divmail').innerHTML;
    }
    else {
        document.getElementById('divmail').innerText = "";
        a = document.getElementById('divmail').innerText;
    }
    if (a == "") {
        var pub = Booking_master.bindpublication_formail();
        var str = "<table  border=1><tr><td><table  style='background-color: #ffffff;' class=\"dtGridHd121\">";
        var str10 = "<tr ><td style=\"width: 20%;\">Publication</td>";
        var pubnamet = "";
        var pubcodet = "";
        str10 += "<td colspan='2'>";
        for (var i = 0; i < pub.value.Tables[0].Rows.length; i) {
            pubcodet = pub.value.Tables[0].Rows[i].Pub_Code;
            pubnamet = pub.value.Tables[0].Rows[i].Pub_Name;
            //str10 += "<td><input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:70%; text-transform: uppercase;'  id=txtpublication" + i + " value = '" + pubnamet + "' disabled><input type='hidden' id=hdnpublication_" + i + " value = '" + pubcodet + "'><input type=checkbox /*onchange=\"checkbranchselect('" + pubcodet + "','" + i + "','" + j + "');\"*/ style=\"width: 10%;\" id=mailprichk" + i + " /></td>";
            //str10 += "<input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:18%; text-transform: uppercase;'  id=txtpublication" + i + " value = '" + pubnamet + "' disabled><input type='hidden' id=hdnpublication_" + i + " value = '" + pubcodet + "'><input type=checkbox /*onclick=\"checkpublicationselect('" + pubcodet + "','" + i + "','" + pub.value.Tables[0].Rows.length + "');\"*/ style=\"width: 10%;\" id=mailprichk" + i + ">";
            str10 += "<input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:20%; text-transform: uppercase;'  id=txtpublication" + i + " value = '" + pubnamet + "' disabled><input type='hidden' id=hdnpublication_" + i + " value = '" + pubcodet + "'><input type=checkbox style=\"width: 10%;\" id=mailprichk" + i + ">";
            if (i == 2 ||  i==5) {
                str10 += "</td>";
                str10 += "</tr>";
                str10 += "<tr> <td></td>";
                str10 += "<td colspan='2'>";
            }
            i = i + 1;
        }
        str10 += "</td>";
        str10 += "</tr>";
        str += str10;

        str += "</table></td></tr><tr><td><input type=button class=\"buttonsplit\" id=btnpubokmail value=Ok onClick=\"checkpublicationselect('" + pub.value.Tables[0].Rows.length + "');\"><input type=button class=\"buttonsplit\" id=btnclomail value=Close onClick=\"divcloseclick();\"> </td></tr></table>";
        document.getElementById('divmail').innerHTML = str;
        document.getElementById('divmail').style.display = "block";
        aTag = eval(document.getElementById("btnmail"))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        document.getElementById('divmail').style.top = toppos + "px";
        document.getElementById('divmail').style.left = leftpos + "px";

    }
    return false;
}

function checkpublicationselect(val) {
    document.getElementById('divmail').style.display = "none";
    var checkpripub = "";
    var allpublicationcheck = "";
    var publicationwisedata = "";
    for (var i = 0; i < val; ++i) {
        if (document.getElementById("hdnpublication_" + i) != null) {
            if (document.getElementById("mailprichk" + i).checked == true) {
                if (checkpripub != "") {
                    checkpripub = checkpripub + "," + document.getElementById("hdnpublication_" + i).value;
                    allpublicationcheck = checkpripub;
                }
                else {
                    checkpripub = checkpripub + "," + document.getElementById("hdnpublication_" + i).value;
                    allpublicationcheck = checkpripub;
                }
            }

        }
    }// FIERST FOR CLOSE

    if (browser != "Microsoft Internet Explorer") {
        document.getElementById('divmail').innerHTML = "";
    }
    else {
        document.getElementById('divmail').innerText = "";
    }
    //alert("mail test52225");
    funbtnmail2(allpublicationcheck);
    return false;
}

function funbtnmail2(abc) {
    var a = "";
    if (browser != "Microsoft Internet Explorer") {
        a = document.getElementById('divmail').innerHTML;
    }
    else {
        a = document.getElementById('divmail').innerText;
    }
    if (a == "") {
        //alert("mail test55");
        // if (a == "") {
        //             var re = Booking_master.pub_centbind( );
        re = Booking_master.pub_centbind(abc);

        var str = "<table  border=1><tr><td><table  style='background-color: #ffffff;' class=\"dtGridHd121\">";

        str = str + "<tr style=\"font-size:12px;  \"><td style=\"width: 15%;\">Group ( All )<input type=checkbox onclick=\"selectallgp(" + re.value.Tables[0].Rows.length + ");\" style=\"width: 10%;\" id=mailcengpallchk0  /></td><td style=\"width: 20%;\">Center</td><td style=\"width: 75%;\">Branch</td></tr>";
        var centergp = "";
        var centercd = "";
        var centernm = "";
        var i1 = 0;
        var k = 0;
        var t = 0;
        for (var i = 0; i < re.value.Tables[0].Rows.length; i) {
            str += "<tr>";
            centercd = re.value.Tables[0].Rows[i].Pub_cent_Code;
            centernm = re.value.Tables[0].Rows[i].CENTER;
            //var re1 = Booking_master.branchbind(re.value.Tables[0].Rows[i].Pub_cent_Code,document.getElementById('txtciobookid').value);
            if (centergp == re.value.Tables[0].Rows[i].CENTER_GROUP_NAME) {
                str += "<td></td><td style='display:none;'><input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:70%; text-transform: uppercase;'  id=txtcentergpname" + i + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_NAME + "' disabled><input type='hidden' id=hdncentergp_" + i + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "'><input type=checkbox onchange=\"checkgpbranchselect('" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "','" + re.value.Tables[0].Rows.length + "','" + i + "');\" style=\"width: 10%;\" id=mailcengpchk" + i + " /></td>";
            }
            else {
                centergp = re.value.Tables[0].Rows[i].CENTER_GROUP_NAME;
                str += "<td><input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:70%; text-transform: uppercase;'  id=txtcentergpname" + i + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_NAME + "' disabled><input type='hidden' id=hdncentergp_" + i + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "'><input type=checkbox onchange=\"checkgpbranchselect('" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "','" + re.value.Tables[0].Rows.length + "','" + i + "');\" style=\"width: 10%;\" id=mailcengpchk" + i + " /></td>";
            }

            var str1 = "<td>";
            //for (var j = 0; j < re1.value.Tables[0].Rows.length; ++j) {
            var j = 0;
            t = parseInt(i);
            while (i1 < re.value.Tables[0].Rows.length && centercd == re.value.Tables[0].Rows[i1].Pub_cent_Code) {
                str1 += "<input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:18%; text-transform: uppercase;'  id=txtbranchname" + i + j + " value = '" + re.value.Tables[0].Rows[t].BRANCH_NAME + "' disabled><input type='hidden' id=hdnbranch_" + i + j + " value = '" + re.value.Tables[0].Rows[t].BRANCH_CODE + "'><input type='hidden' id=hdnemail_" + i + j + " value = '" + re.value.Tables[0].Rows[t].BRANCH_EMAIL + "'><input type=checkbox id=mailbrachk" + i + j + " />"
                //str1 += "<input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:18%; text-transform: uppercase;'  id=txtbranchname" + i + j + " value = '" + re.value.Tables[0].Rows[j].BRANCH_NAME + "' disabled><input type='hidden' id=hdnbranch_" + i + j + " value = '" + re.value.Tables[0].Rows[j].BRANCH_CODE + "'><input type='hidden' id=hdnemail_" + i + j + " value = '" + re.value.Tables[0].Rows[j].BRANCH_EMAIL + "'><input type=checkbox id=mailbrachk" + i + j + " />"
                i1 = parseInt(i1) + 1;
                j = parseInt(j) + 1;
                t = parseInt(t) + 1;
            }
            if (parseInt(j) > parseInt(k)) {
                k = j;
            }
            str += "<td><input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:70%; text-transform: uppercase;'  id=txtcentername" + i + " value = '" + centernm + "' disabled><input type='hidden' id=hdncenter_" + i + " value = '" + centercd + "'><input type=checkbox onchange=\"checkbranchselect('" + centercd + "','" + i + "','" + j + "');\" style=\"width: 10%;\" id=mailcenchk" + i + " /></td>";
            str += str1;
            i = i1;
            str += "</td>";
            str += "</tr>"
        }

        str += "</table></td></tr><tr><td><input type=button class=\"buttonsplit\" id=btnokmail value=Ok onClick=\"divokclick1('" + re.value.Tables[0].Rows.length + "','" + k + "');\"><input type=button class=\"buttonsplit\" id=btnclomail value=Close onClick=\"divcloseclick();\"> </td></tr></table>"
        document.getElementById('divmail').innerHTML = str;
        document.getElementById('divmail').style.display = "block";
        aTag = eval(document.getElementById("btnmail"))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        document.getElementById('divmail').style.top = toppos + "px";
        document.getElementById('divmail').style.left = leftpos + "px";
    }
    else {
        document.getElementById('divmail').style.display = "block";
    }
    return false;
}

function checkbranchselect(val, i, j1) {
    for (var j = 0; j < j1; ++j) {
        if (document.getElementById("mailcenchk" + i).checked == true) {
            document.getElementById("mailbrachk" + i + j).checked = true;
        }
        else {
            document.getElementById("mailbrachk" + i + j).checked = false;
        }
    }
}
function checkgpbranchselect(val, i, k) {
    for (var j = 0; j < i; ++j) {
        if (document.getElementById("mailcengpchk" + k).checked == true) {
            if (document.getElementById("hdncentergp_" + j) != null && document.getElementById("hdncentergp_" + j).value == val) {
                document.getElementById("mailcenchk" + j).checked = true;
                if ("createEvent" in document) { var evt = document.createEvent("HTMLEvents"); evt.initEvent("change", false, true); document.getElementById("mailcenchk" + j).dispatchEvent(evt); } else document.getElementById("mailcenchk" + j).fireEvent("onchange");
            }
        }
        else {
            if (document.getElementById("hdncentergp_" + j) != null && document.getElementById("hdncentergp_" + j).value == val) {
                document.getElementById("mailcenchk" + j).checked = false;
                if ("createEvent" in document) { var evt = document.createEvent("HTMLEvents"); evt.initEvent("change", false, true); document.getElementById("mailcenchk" + j).dispatchEvent(evt); } else document.getElementById("mailcenchk" + j).fireEvent("onchange");
            }
        }
        /* if (document.getElementById("mailcengpchk" + j).checked == true) {
            if (document.getElementById("hdncentergp_"+j).value==val)
             document.getElementById("mailcenchk" + j).checked = true;
             if ("createEvent" in document) { var evt = document.createEvent("HTMLEvents"); evt.initEvent("change", false, true); document.getElementById("mailcenchk" + j).dispatchEvent(evt); } else document.getElementById("mailcenchk" + j).fireEvent("onchange");
         }
         else {
             if (document.getElementById("hdncentergp_"+j).value==val)
             document.getElementById("mailcenchk" + j).checked = false;
             if ("createEvent" in document) { var evt = document.createEvent("HTMLEvents"); evt.initEvent("change", false, true); document.getElementById("mailcenchk" + j).dispatchEvent(evt); } else document.getElementById("mailcenchk" + j).fireEvent("onchange");
         }*/
    }
}
var mailsavestring = "";
var mailsendstr = "";
function divokclick1(i1, j1) {
    document.getElementById('divmail').style.display = "none";
    mailsavestr = "";
    mailsendstr = "";
    for (var i = 0; i < i1; ++i) {
        ///var re1 = Booking_master.branchbind(document.getElementById("hdncenter_" + i).value,document.getElementById('txtciobookid').value);
        if (document.getElementById("hdncenter_" + i) != null) {
            for (var j = 0; j < j1; ++j) {
                if (document.getElementById("mailbrachk" + i + j) != null) {
                    if (document.getElementById("mailbrachk" + i + j).checked == true) {
                        if (mailsavestr == "") {
                            mailsavestr = document.getElementById("hdncenter_" + i).value + '~~~~' + document.getElementById("hdnbranch_" + i + j).value + '~~~~' + document.getElementById("hdnemail_" + i + j).value;
                            mailsendstr = document.getElementById("hdnemail_" + i + j).value;
                        }
                        else {
                            mailsavestr = mailsavestr + '^^^^^' + document.getElementById("hdncenter_" + i).value + '~~~~' + document.getElementById("hdnbranch_" + i + j).value + '~~~~' + document.getElementById("hdnemail_" + i + j).value;
                            mailsendstr = mailsendstr + ',' + document.getElementById("hdnemail_" + i + j).value;
                        }
                    }
                }
            }
        }
    }

}
function divcloseclick() {
    document.getElementById('divmail').innerHTML = "";
    mailsavestr = "";
    mailsendstr = "";

    checkpripub = "";
    allpublicationcheck = "";
    publicationwisedata = "";
}

///this is to bind zone on change of list box of exec

function call_bindretain(res) {
    var ds = res.value;
    if (document.getElementById('drpretainer').value != '0' && document.getElementById('drpretainer').value != '' && retexeboth != "both") {
        var a = "Executive name";
        if (browser != "Microsoft Internet Explorer") {
            a = document.getElementById('lbececname').textContent.replace("*[F2]", "");
        }
        else {
            a = document.getElementById('lbececname').innerText.replace("*[F2]", "");
        }
        if (confirm('Are you sure you want to Take ' + a)) {
            document.getElementById('drpretainer').value = "";
            document.getElementById('txtRetainercomm').value = "";
            document.getElementById('txtRetainercommamt').value = ""
        }
        else {
            document.getElementById('txtexeczone').value = "";
            document.getElementById('txtexecname').value = "";
            return false;
        }
    }
    if (ds != null) {
        if (ds.Tables.length > 1 && ds.Tables[1].Rows[0].Column1 == "N") {
            alert("Retainer have no premission of this Agency");
            document.getElementById('txtexeczone').value = "";
            document.getElementById('drpretainer').value = "";
            return false;
        }
    }
    if (ds != null) {
        if (ds.Tables[0].Rows.length > 0) {
            document.getElementById('txtexeczone').value = ds.Tables[0].Rows[0].zone_name
            document.getElementById('hiddenzone').value = document.getElementById('txtexeczone').value;
        }
    }
    if (ds != null) {
        var exec_name = document.getElementById('txtexecname').value.split('(');
        var exec_code = exec_name[1].replace(')', '');
        var agencycodesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')')); /*bhanu*/
        var ds_ret_b = Booking_master.adexec_billbase_outstanding(document.getElementById('hiddencompcode').value, agencycodesubcode, exec_code, document.getElementById('txtdatetime').value, document.getElementById('hiddendateformat').value, document.getElementById('txtagencytype').value);
        if (ds_ret_b.value == null) {
            alert(ds_ret_b.error.description);
            return false;
        }
        if (ds_ret_b.value.Tables[0].Rows.length > 0) {
            if (ds_ret_b.value.Tables[0].Rows[0].REC_COUNT != null && ds_ret_b.value.Tables[0].Rows[0].OUT_AMT != null) {
                alert("This Executive have " + ds_ret_b.value.Tables[0].Rows[0].REC_COUNT + " Pending Bill and Outstanding is " + ds_ret_b.value.Tables[0].Rows[0].OUT_AMT);
            }
        }
    }
}

function BindUnit1(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 113) {
        offset(document.activeElement.id, "divunit", "lstunit");
        var compcode = document.getElementById('hdncompcode').value;
        var userid = document.getElementById('hdnuserid').value;
        var extra1 = document.getElementById('txtunitnm').value.toUpperCase();
        var extra2 = "";
        jq.ajax({
            type: "POST",
            url: "CommonFunctionPage.aspx/BindUnit",
            contentType: "application/json; charset=utf-8",
            data: "{'compcode':'" + compcode + "', 'userid':'" + userid + "', 'extra1':'" + extra1 + "', 'extra2':'" + extra2 + "' }",
            dataType: "json",
            success: function (result) {
                BindUnit_CallBack1(jq.parseJSON(result.d));
            }
        });
        return false;
    }
    else if (keycode == 8 || keycode == 46) {
        jq("#hdnunitcd,#txtbranchnm,#hdnbranchcd").val('');
    }
    else if (keycode != 13 && keycode != 37 && keycode != 39 && keycode != 9 && keycode != 17 && event.shiftKey == false && event.ctrlKey == false && event.altKey == false) {
        jq("#hdnunitcd,#txtbranchnm,#hdnbranchcd").val('');
    }
    if (event.ctrlKey == true && keycode == 88) {
        jq("#hdnunitcd,#txtbranchnm,#hdnbranchcd").val('');
    }
}
function BindUnit_CallBack1(ds) {
    var objadscat = document.getElementById("lstunit");
    objadscat.options.length = 0;
    if (ds != null && typeof (ds) == "object" && ds.length > 0) {
        objadscat.options[0] = new Option("-Select Unit -", "");
        objadscat.options.length = 1;
        for (var i = 0; i < ds.length; ++i)
            objadscat.options[objadscat.options.length] = new Option(ds[i].center + "~" + ds[i].Pub_cent_Code, ds[i].center + "~" + ds[i].Pub_cent_Code);
    }
    else {
        objadscat.options[0] = new Option("---There is no data according your search---", "");
        return false;
    }
    document.getElementById('lstunit').focus();
    return false;
}
function FillUnit1(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (document.getElementById('lstunit').value == "") {
            alert("Please select the unit");
            document.getElementById('lstunit').focus();
            return false;
        }
        var page = document.getElementById('lstunit').value;
        var str = page.split("~");
        document.getElementById('txtunitnm').value = str[0];
        document.getElementById('hdnunitcd').value = str[1];
        document.getElementById("divunit").style.display = "none";
        document.getElementById('txtunitnm').focus();
        return false;
    }
    else if (keycode == 27) {
        document.getElementById("divunit").style.display = "none";
        document.getElementById('txtunitnm').focus();
        return false;
    }
}
function selectallgp(i) {
    for (var j = 0; j < i; ++j) {
        if (document.getElementById("mailcengpallchk0").checked == true) {
            if (document.getElementById("mailcengpchk" + j) != null) {
                document.getElementById("mailcengpchk" + j).checked = true;
                if ("createEvent" in document) { var evt = document.createEvent("HTMLEvents"); evt.initEvent("change", false, true); document.getElementById("mailcengpchk" + j).dispatchEvent(evt); } else document.getElementById("mailcengpchk" + j).fireEvent("onchange");
            }
        }
        else {
            if (document.getElementById("mailcengpchk" + j) != null) {
                document.getElementById("mailcengpchk" + j).checked = false;
                if ("createEvent" in document) { var evt = document.createEvent("HTMLEvents"); evt.initEvent("change", false, true); document.getElementById("mailcengpchk" + j).dispatchEvent(evt); } else document.getElementById("mailcengpchk" + j).fireEvent("onchange");
            }
        }
    }
}
