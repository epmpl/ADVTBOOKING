var jq = jQuery.noConflict();
var agnf2 = "";
var clientf2;
var agencycodeglo;
var roundoff;

function bindpackage_cen() {
    var no = 0;
    if (document.getElementById('chkhindi').checked == true && document.getElementById('chkhindu').checked == true)
        no = 0;
    else if (document.getElementById('chkhindi').checked == true)
        no = 2;
    if (document.getElementById('chkhindu').checked == true)
        no = 1;
    QBC.bindpackage_javascript(document.getElementById('chkall').checked, no, bindpackage_javascript_callback);
}
function bindpackage_javascript_callback(response) {
    ds = response.value;
    var pkgitem = document.getElementById("drppackage");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Package-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[1].Rows.length > 0) {
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[1].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[1].Rows[i].pkg, ds.Tables[1].Rows[i].pck_code);
            pkgitem.options.length;
        }

    }

    //return false;
}





function tabvalue(event) {
    var browser = navigator.appName;
    //This is open to upload image tab for all Insertions......
    var key = event.keyCode ? event.keyCode : event.which;

    if (event.altKey == true && event.keyCode == "78" && document.getElementById('btnNew').disabled == false) {
        newClick();
        return false;
    }



    if (event.altKey == true && event.keyCode == "83" && document.getElementById('btnSave').disabled == false) {
        checkValidation();
        return false;
    }

    if (event.altKey == true && event.keyCode == "71" && document.getElementById('btnshgrid').disabled == false) {
        checkGridDate_Validation();
        return false;
    }
    if (event.altKey == true && event.keyCode == "70" && document.getElementById('btnconfirm').disabled == false) {
        confirmClick1();
        return false;
    }

    if (key == 123 && document.getElementById('uploadA') != null) {
        //if (document.getElementById('txttotalarea').value == null || document.getElementById('txttotalarea').value == "0" || document.getElementById('txttotalarea').value == "") {
        if (document.getElementById('uploadA').style.color == "red") {
            uploadimageall();
            return false;
        }
    }


    if (key == 40 && document.activeElement.id.indexOf("Text") == 0) {
        var id = document.activeElement.id.toString().replace("Text", "");
        id = "Text" + (parseInt(id, 10) + 1).toString();
        if (document.getElementById(id) != null && document.getElementById(id).disabled == false) {
            document.getElementById(id).focus();
            return false;
        }
    }
    if (key == 38 && document.activeElement.id.indexOf("Text") == 0) {
        var id = document.activeElement.id.toString().replace("Text", "");
        id = "Text" + (parseInt(id, 10) - 1).toString();
        if (document.getElementById(id) != null && document.getElementById(id).disabled == false) {
            document.getElementById(id).focus();
            return false;
        }
    }

    if (key == 39 || key == 37) {


        return true;
    }

    if (event.keyCode == 119 && document.getElementById('btnSave').disabled == false) {
        checkValidation();
    }
    if (document.activeElement.id.indexOf("txtrodate") == 0) {
        if (event.keyCode == 117 && document.getElementById(document.activeElement.id).disabled == false) {
            document.getElementById(document.activeElement.id).value = document.getElementById('txtdatetime').value;
            document.getElementById(document.activeElement.id).focus();
            return false;
        }
    }
    if (document.activeElement.id.indexOf("rem") == 0) {
        document.getElementById(document.activeElement.id).title = document.getElementById(document.activeElement.id).value;
    }
    if (document.activeElement.id.indexOf("Text") == 0) {
        return dateenter(event);
    }
    if (document.activeElement.id.indexOf("rep") == 0) {
        return dateenter(event);
    }
    if (document.activeElement.id.indexOf("lat") == 0) {
        return dateenter(event);
    }
    if (document.activeElement.id.indexOf("hei") == 0) {
        var res = rateenter(event);
        if (res == false)
            return false;
    }
    if (document.activeElement.id.indexOf("wid") == 0) {
        var res = rateenter(event);
        if (res == false)
            return false;
    }
    if (document.activeElement.id.indexOf("nocol") == 0) {
        var res = rateenter(event);
        if (res == false)
            return false;
    }
    if (document.activeElement.id.indexOf("siz") == 0) {
        var res = rateenter(event);
        if (res == false)
            return false;
    }
    if (document.activeElement.id.indexOf("pageno") == 0) {
        var res = rateenter(event);
        if (res == false)
            return false;
    }
    if (event.keyCode == 40) {
        if (document.getElementById('tblinsert').innerHTML != "") {
            if (document.activeElement.type == "text") {
                var texid = document.activeElement.id;
                if (texid.indexOf("Text") >= 0 || texid.indexOf("rem") >= 0 || texid.indexOf("pagno") >= 0 || texid.indexOf("hei") >= 0) {
                    var idtext;
                    var i;
                    if (texid.indexOf("Text") >= 0) {
                        idtext = texid.substring(0, 4);
                        i = texid.substring(4, texid.length); ;
                    }
                    else if (texid.indexOf("rem") >= 0 || texid.indexOf("hei") >= 0) {
                        idtext = texid.substring(0, 3);
                        i = texid.substring(3, texid.length); ;
                    }
                    else if (texid.indexOf("pagno") >= 0) {
                        idtext = texid.substring(0, 5);
                        i = texid.substring(5, texid.length); ;
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
                        i = texid.substring(4, texid.length); ;
                    }
                    else if (texid.indexOf("rem") >= 0 || texid.indexOf("hei") >= 0) {
                        idtext = texid.substring(0, 3);
                        i = texid.substring(3, texid.length); ;
                    }
                    else if (texid.indexOf("pagno") >= 0) {
                        idtext = texid.substring(0, 5);
                        i = texid.substring(5, texid.length); ;
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

    if (event.keyCode == 113) {

        if (document.activeElement.id.indexOf("coldiv") == 0) {
            activeid = document.activeElement.id;
            var userid = document.getElementById('hiddenuserid').value;
            var compcode = document.getElementById('hiddencompcode').value;
            var divid = "agdivpop";
            var listboxid = "aglistpop";
            var ds = QBC.bindcolorForGrid(compcode, userid);
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
            //  objadscat.options[0]=new Option("-Select-","0");
            var c = 0;
            var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
            loadXML("xml/billcycle.xml");
            for (b = 0; b <= xmlObj.childNodes(9).childNodes.length - 1; b++) {
                objadscat.options[c] = new Option(xmlObj.childNodes[9].childNodes[b].childNodes[0].nodeValue, xmlObj.childNodes[9].childNodes[b + 1].childNodes[0].nodeValue);
                b = b + 1;
                c = c + 1;
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
        else if (document.activeElement.id.indexOf("adsdiv") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdivpop";
            var listboxid = "aglistpop";
            var compcode = document.getElementById('hiddencompcode').value;
            var adcategory = document.activeElement.id.replace("adsdiv", "adcat");
            if (document.getElementById(adcategory) != null)
                adcategory = document.getElementById(adcategory).value;
            else
                adcategory = document.getElementById('drpadcategory').value;
            var ds = QBC.getadsubcat(compcode, adcategory);
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
        else if (document.activeElement.id.indexOf("adcat") == 0) {
            activeid = document.activeElement.id;
            var compcode = document.getElementById('hiddencompcode').value;
            var divid = "agdiv";
            var listboxid = "aglist";
            var ds = QBC.advcatinGrid(compcode);
            if (ds == null)
                return false;
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            //alert(pkgitem.options.length);
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
            //  document.getElementById(divid).top= document.getElementById(activeid).offsetTop;
            document.getElementById(listboxid).focus();
        }


        if (document.activeElement.id.indexOf("mat") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            objadscat.options[0] = new Option("-Select-", "0");
            objadscat.options[1] = new Option("-Hard Copy-", "hardcopy");
            objadscat.options[2] = new Option("-Soft Copy-", "softcopy");
            objadscat.options[3] = new Option("-cd-", "CD");
            objadscat.options[4] = new Option("-Others-", "other");
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
        else if (document.activeElement.id.indexOf("adscat3") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var compcode = document.getElementById('hiddencompcode').value;
            var adcategory = document.activeElement.id.replace("adscat3", "ads");
            adcategory = document.getElementById(adcategory).value;

            var ds = QBC.bindadcat3(adcategory, compcode, "0");

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
            document.getElementById(divid).cssclass = "btextlist";

            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("adscat4") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var compcode = document.getElementById('hiddencompcode').value;
            var adcategory = document.activeElement.id.replace("adscat4", "adscat3");
            adcategory = document.getElementById(adcategory).value;

            var ds = QBC.bindadcat3(adcategory, compcode, "1");

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
            document.getElementById(divid).cssclass = "btextlist";

            document.getElementById(listboxid).focus();
        }
        else if (document.activeElement.id.indexOf("adscat5") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var compcode = document.getElementById('hiddencompcode').value;
            var adcategory = document.activeElement.id.replace("adscat5", "adscat4");
            adcategory = document.getElementById(adcategory).value;

            var ds = QBC.bindadcat3(adcategory, compcode, "2");

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
            document.getElementById(divid).cssclass = "btextlist";

            document.getElementById(listboxid).focus();
        }

        if (document.activeElement.id.indexOf("inssta") == 0) {
            activeid = document.activeElement.id;
            var divid = "agdiv";
            var listboxid = "aglist";
            var objadscat = document.getElementById(listboxid);
            objadscat.options.length = 0;
            //                    objadscat.options[0]=new Option("-Select-","0");
            var c = 0;
            var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
            loadXML("xml/billcycle.xml");
            for (b = 0; b <= xmlObj.childNodes(9).childNodes.length - 1; b++) {
                objadscat.options[c] = new Option(xmlObj.childNodes[9].childNodes[b].childNodes[0].nodeValue, xmlObj.childNodes[9].childNodes[b + 1].childNodes[0].nodeValue);
                b = b + 1;
                c = c + 1;
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

        if (document.activeElement.id.indexOf("pgpre") == 0) {
            activeid = document.activeElement.id;
            var compcode = document.getElementById('hiddencompcode').value;
            var divid = "agdiv";
            var listboxid = "aglist";
            var ds = QBC.bindpagePositioninGrid(compcode);
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
        if (document.activeElement.id == "txtclient" && clientf2 == "Y") {
            if (document.getElementById('txtclient').value.indexOf('(') >= 0) {
                var client = "";
                client = document.getElementById('txtclient').value.split('(');
                document.getElementById('txtclient').value = client[0];
            }
            document.getElementById("divclient").style.display = "block";

            //                    document.getElementById("drpadcategory").style.visibility="hidden";
            //                    document.getElementById("drpadsubcategory").style.visibility="hidden";
            //                    document.getElementById("drpcolor").style.visibility="hidden";
            //                    document.getElementById("drpadcat3").style.visibility="hidden";
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
            document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop-6)+"px";
            document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 3+"px";
            }
            else
            {
            document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6+"px";
            document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9+"px";
            }*/

            QBC.bindclientname1(document.getElementById('hiddencompcode').value, document.getElementById('txtclient').value, "", bindclientname_callback);

        }



        if (document.activeElement.id == "txtagency") {
            if (document.getElementById('txtagency').value.length <= 2) {
                document.getElementById('txtagency').value = "";
                alert("Please Enter Minimum 3 Character For Searching.");
                return false;
            }
            if (document.getElementById('txtagency').readOnly == false) {
                if (document.getElementById('hdnf2').value == "")
                { }
                else if (document.getElementById('Hdn_f2').value == "no")
                { }
                else {
                    if (document.getElementById('btnNew').disabled == true) {

                        document.getElementById("divagencymain").style.display = "block";
                        document.getElementById("lstagencymain").style.visibility = "visible";
                        document.getElementById("lstagencymain").focus();
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
                        document.getElementById('divagencymain').style.top = document.getElementById("txtagency").offsetTop + toppos + "px";
                        document.getElementById('divagencymain').style.left = document.getElementById("txtagency").offsetLeft + leftpos + "px";
                        /*  if(browser!="Microsoft Internet Explorer")
                        {
                        document.getElementById('divagencymain').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 10 +"px";
                        document.getElementById('divagencymain').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 580+"px";
                        }
                        else
                        {
                        document.getElementById('divagencymain').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 24+"px";
                        document.getElementById('divagencymain').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 590+"px";
                        }*/
                        var mystring1 = ""
                        var mystring2 = ""
                        var mystring = ""
                        if (document.getElementById('txtagency').value != "") {
                            mystring1 = document.getElementById('txtagency').value.indexOf("(")
                            mystring2 = document.getElementById('txtagency').value.indexOf(")")
                            if (mystring1 < mystring2) {
                                mystring = document.getElementById('txtagency').value.substring(mystring1, parseInt(mystring2) + 1)
                                mystring = document.getElementById('txtagency').value.replace(mystring, "");
                            }

                        }
                        else {
                            mystring = document.getElementById('txtagency').value;
                        }
                        if (mystring == "") {
                            mystring = document.getElementById('txtagency').value;
                            var mystr = mystring.toUpperCase();
                        }
                        // document.getElementById('txtagency').value.indexOf("(")
                        //QBC.getagencyf(mystring,document.getElementById('hiddencompcode').value,bindagencyname_callback);
                        QBC.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, mystring, "N", bindagencyname_callback);
                    }

                }
            }
        }
        /*end herte*/
    }

    else if (event.keyCode == 27) {

        if (document.getElementById("divclient").style.display == "block") {
            document.getElementById("divclient").style.display = "none"

            document.getElementById("drpadcategory").style.visibility = "visible";
            document.getElementById("drpadsubcategory").style.visibility = "visible";
            document.getElementById("drpcolor").style.visibility = "visible";
            document.getElementById("drpadcat3").style.visibility = "visible";
            document.getElementById('txtclient').focus();
        }

        else if (document.getElementById("divagencymain").style.display == "block") {
            document.getElementById("divagencymain").style.display = "none"

            var pkgitem = document.getElementById("lstagencymain");
            pkgitem.options.length = 0;
            document.getElementById('txtclient').focus();
        }
        else if (document.activeElement.id.indexOf("adscat3") == 0 || document.activeElement.id.indexOf("adscat4") == 0 || document.activeElement.id.indexOf("adscat5") == 0 || document.activeElement.id.indexOf("adcat") == 0 || document.activeElement.id.indexOf("pgpre") == 0 || document.activeElement.id.indexOf("inssta") == 0 || document.activeElement.id.indexOf("mat") == 0 || document.activeElement.id.indexOf("col") == 0 || document.activeElement.id.indexOf("ads") == 0 || document.activeElement.id.indexOf("aglist") == 0 || document.activeElement.id.indexOf("agdiv") == 0) {
            document.getElementById(activeid).style.backgroundColor = "#FFFFFF";
            document.getElementById("agdiv").style.display = "none";
        }

    }

    else if (event.keyCode == 13 || event.keyCode == 9 || event.keyCode == 115 && event.shiftKey == false) {
    /////////////////////////////////////
           // EnterTab(event, document.activeElement.id); ///add by anuja

        if (document.activeElement.id == "txtclientadd") {
            if (document.getElementById("txtclientadd").value == "" || document.getElementById("txtclientadd").value != "") {
                if (document.getElementById("txtagency").disabled == false) {
                   // document.getElementById('txtagency').style.backgroundColor = "#0000FF";
                    document.getElementById("txtagency").focus();
                    return false;
                }
            }
        }
        else if (document.activeElement.id == "txtagency") {
            if (document.getElementById("txtagency").value == "" || document.getElementById("hiddenagencynew").value == "") {
                if (document.getElementById("txtagency").disabled == false) {
                    alert("Please Select Agency Using By F2");
                   // document.getElementById('txtagency').style.backgroundColor = "#0000FF";
                    document.getElementById("txtagency").focus();
                    return false;
                }
            }
            else {
                document.getElementById("divagencymain").style.display = "none"
                if (document.getElementById("txtMobile").disabled == false) {
                  //  document.getElementById('txtMobile').style.backgroundColor = "#0000FF";
                    document.getElementById("txtMobile").focus();
                    return false;
                }
            }
        }
        //    else if (document.activeElement.id == "txtreceipt") {
        //        if (document.getElementById("txtreceipt").value == "" || document.getElementById("txtreceipt").value != "") {
        //            document.getElementById("txtboxadd").focus();
        //            return false;
        //        }
        //    }
//        else if (document.activeElement.id == "txtMobile") {
//            if (document.getElementById("txtMobile").value == "") {
//                if (document.getElementById("txtMobile").disabled == false) {
//                    document.getElementById("txtMobile").focus();
//                    return false;
//                }
//            }
//        }
        else if (document.activeElement.id == "txtMobile") {
            if (document.getElementById("txtMobile").value == "") {
                if (document.getElementById("txtMobile").disabled == false) {
                    alert("Please enter mobile no.");
                    document.getElementById("txtMobile").focus();
                    return false;
                }
            }
            else {
                if (document.getElementById("txtsapid").disabled == false) {
                    document.getElementById("txtsapid").focus();
                    return false;
                }
            }
        }
        else if (document.activeElement.id == "txtsapid") {
            if (document.getElementById("txtsapid").value == "" || document.getElementById("txtsapid").value != "") {
                if (document.getElementById("drpbillto_qbc").disabled == false) {
                    document.getElementById("drpbillto_qbc").focus();
                    return false;
                }
            }

        }
        else if (document.activeElement.id == "drpbillto_qbc") {
            if (document.getElementById("drpbillto_qbc").value == "" || document.getElementById("drpbillto_qbc").value != "") {
                if (document.getElementById("txtrono").disabled == false) {
                    document.getElementById("txtrono").focus();
                    return false;
                }
            }

        }
        else if (document.activeElement.id == "txtrono") {
            if (document.getElementById("txtrono").value == "" || document.getElementById("txtrono").value != "") {
                if (document.getElementById("txtrodate").disabled == false) {
                    document.getElementById("txtrodate").focus();
                    return false;
                }
            }

        }
        else if (document.activeElement.id == "txtrodate") {
            if (document.getElementById("txtrodate").value == "" || document.getElementById("txtrodate").value != "") {
                if (document.getElementById("drpstate").disabled == false) {
                    document.getElementById("drpstate").focus();
                    return false;
                }
            }

        }
        else if (document.activeElement.id == "drpstate") {
            if (document.getElementById("drpstate").value == "" || document.getElementById("drpstate").value != "" || document.getElementById("drpstate").value == "0") {
                if (document.getElementById("drpadtype").disabled == false) {
                    document.getElementById("drpadtype").focus();
                    return false;
                }
            }

        }
        else if (document.activeElement.id == "drpadtype") {
            if (document.getElementById("drpadtype").value == "" || document.getElementById("drpadtype").value != "" || document.getElementById("drpadtype").value == "0") {
                if (document.getElementById("drpadcategory").disabled == false) {
                    document.getElementById("drpadcategory").focus();
                    return false;
                }
            }

        }
        else if (document.activeElement.id == "drpadcategory") {
            if (document.getElementById("drpadcategory").value == "" || document.getElementById("drpadcategory").value == "0") {
                if (document.getElementById("drpadcategory").disabled == false) {
                    alert("Please Select Ad Categories");
                    document.getElementById("drpadcategory").focus();
                    return false;
                }
            }
            else {
                if (document.getElementById("drpadsubcategory").disabled == false) {
                    document.getElementById("drpadsubcategory").focus();
                    return false;
                }
            }

        }
        else if (document.activeElement.id == "drpadcat5") {
            if (document.getElementById("drpadcat5").value == "" || document.getElementById("drpadcat5").value == "0") {
                if (document.getElementById("drpuom").disabled == false) {
                    document.getElementById("drpuom").focus();
                    return false;
                }
            }

        }

        else if (document.activeElement.id == "drpuom") {
            if (document.getElementById("drpuom").value == "" || document.getElementById("drpuom").value == "0") {
                if (document.getElementById("drpuom").disabled == false) {
                    alert("Please Select UOM");
                    document.getElementById("drpuom").focus();
                    return false;
                }
            }
            else {
                if (document.getElementById("drpboxcodenew").disabled == false) {
                    document.getElementById("drpboxcodenew").focus();
                    return false;
                }
            }

        }
        else if (document.activeElement.id == "drpcolor") {
            if (document.getElementById("drpcolor").value == "" || document.getElementById("drpcolor").value == "0" || document.getElementById("drpcolor").value != "") {
                if (document.getElementById("drppackage").disabled == false) {
                    document.getElementById("drppackage").focus();
                    return false;
                }
            }
        }
        else if (document.activeElement.id == "drppackage") {
            if (document.getElementById("drppackage").value == "" || document.getElementById("drppackage").value == "0") {
                if (document.getElementById("drppackage").disabled == false) {
                    alert("Please Select package");
                    document.getElementById("drppackage").focus();
                    return false;
                }
            }
            else if (document.getElementById("drppackage").value != "") {
                if (document.getElementById("btncopy").disabled == false) {

                    document.getElementById("btncopy").focus();
                    return false;
                }

            }
            else {
                    if (document.getElementById("drpbgcolor").disabled == false) {
                    document.getElementById("drpbgcolor").focus();
                    return false;
                    }
                else if (document.getElementById("txtkeyno").disabled == false) 
                    {
                        document.getElementById("txtkeyno").focus();
                        return false;
                    }
                }

            }
            else if (document.activeElement.id == "chkall") {
                if (document.getElementById("chkall").checked == true || document.getElementById("chkall").checked == false) {
                    if (document.getElementById("btncopy").disabled == false) {
                        document.getElementById("btncopy").focus();
                        return false;
                    }
                }
               
            }
            else if (document.activeElement.id == "btncopy") {
               // if (document.getElementById("drppackagecopy").value=="") {
                    addpkgname();
                   // return false;
               // }
                if (document.getElementById("drpbgcolor").disabled == false) {
                    document.getElementById("drpbgcolor").focus();
                    return false;
                }
                else if (document.getElementById("txtkeyno").disabled == false) {
                    document.getElementById("txtkeyno").focus();
                    return false;
                }
            }

            else if (document.activeElement.id == "drpbgcolor") {
                    if (document.getElementById("drpbgcolor").value == "" || document.getElementById("drpbgcolor").value == "0") {
                        if (document.getElementById("drpbgcolor").disabled == false) {
                        alert('Please select background color');
                        document.getElementById("drpbgcolor").focus();
                        return false;
                    }
                    }
                    else {
                        if (document.getElementById("txtkeyno").disabled == false) {
                            document.getElementById("txtkeyno").focus();
                            return false;
                        }
                    }
                }
          
            else if (document.activeElement.id == "txtkeyno") {
                if (document.getElementById("txtkeyno").value == "" || document.getElementById("txtkeyno").value != "") {
                    if (document.getElementById("drpstyle").disabled == false) {
                        document.getElementById("drpstyle").focus();
                        return false;
                    }
                }

            }
            else if (document.activeElement.id == "drplogoprem") {
                if (document.getElementById("drplogoprem").value == "" || document.getElementById("drplogoprem").value != "" || document.getElementById("drplogoprem").value == "0") {
                    if (document.getElementById("drppaymenttype").disabled == false) {
                        document.getElementById("drppaymenttype").focus();
                        return false;
                    }
                }
            }
            else if (document.activeElement.id == "drppaymenttype") {
            if (document.getElementById("drppaymenttype").value == "" || document.getElementById("drppaymenttype").value == "0") {
                if (document.getElementById("drppaymenttype").disabled == false) {
                    alert("Please Select Payment Type");
                    document.getElementById("drppaymenttype").focus();
                    return false;
                }
            }
            else if (document.getElementById('drppaymenttype').value == "CH0" || document.getElementById('drppaymenttype').value == "PR0" || document.getElementById('drppaymenttype').value == "DD0" || document.getElementById('drppaymenttype').value == "SW0") {
                chequedetail();
                if (document.getElementById("txtdummydate").disabled == false) {
                    document.getElementById("txtdummydate").focus();
                    return false;
                }
            }
            else {
                if (document.getElementById("txtdummydate").disabled == false) {
                    document.getElementById("txtdummydate").focus();
                    return false;
                }
            }
            }
        ////////////////////////////////////////////////end/////////////////
//        if (document.activeElement.id == "txtdummydate") {

//            if (event.keyCode == 115) {

//                popUpCalendar(document.getElementById("Img3"), Form1.txtdummydate, "mm/dd/yyyy")
//            }

//        }

        else if (document.activeElement.id == "txtdummydate") {

            if (event.keyCode == 115) {

                popUpCalendar(document.getElementById("Img3"), Form1.txtdummydate, "mm/dd/yyyy")
            }
           else if (document.getElementById("txtdummydate").value == "" ) {
                if (document.getElementById("txtdummydate").disabled == false) {
                    alert("Please Select Start With");
                    document.getElementById("txtdummydate").focus();
                    return false;
                }
            }
            else {
                if (document.getElementById("txtinsertion").disabled == false) {
                    document.getElementById("txtinsertion").focus();
                    return false;
                }
            }
        }
                else if (document.activeElement.id == "txtinsertion") {
            if (document.getElementById("txtinsertion").value == "" ) {
                if (document.getElementById("txtinsertion").disabled == false) {
                alert('Please enter  no. of insertion');
                    document.getElementById("txtinsertion").focus();
                    return false;
                }
            }
            else{
            if (document.getElementById("txtrepeatingdate").disabled == false) {
            
                  document.getElementById("txtrepeatingdate").focus();
                    return false;
                }
            
            }
        }
        else if (document.activeElement.id == "txtrepeatingdate") {
            if (document.getElementById("txtrepeatingdate").value == "") {
                if (document.getElementById("txttotalarea").disabled == false) {
                document.getElementById("btnshdl").disabled=true;
                    document.getElementById("txttotalarea").focus();
                    return false;
                }
                else {
                if(document.getElementById("txtprintremark").disabled == false){
                document.getElementById("txtprintremark").focus();
                    return false;
                    }
                }
            }
            else if(document.getElementById("txtrepeatingdate").value != ""){
                        document.getElementById("btnshdl").disabled=false;
                        //document.getElementById("btnshdl").focus();
                        CreateMfgDetail("btnshdl");
                           //return false;
            }
        }
        else if (document.activeElement.id == "txtprintremark") {
            if (document.getElementById("txtprintremark").value == "" || document.getElementById("txtprintremark").value == "0" || document.getElementById("txtprintremark").value != "") {
                if (document.getElementById("drpratecode").disabled == false) {
                    document.getElementById("drpratecode").focus();
                    return false;
                }
            }
        }
        else if (document.activeElement.id == "drpratecode") {
            if (document.getElementById("drpratecode").value == "" || document.getElementById("txtprintremark").value == "0") {
                if (document.getElementById("drpratecode").disabled == false) {
                    alert("Please Select Rate Code");
                    document.getElementById("drpratecode").focus();
                    return false;
                }
            }
            else {
                if (document.getElementById("btnshgrid").disabled == false) {
                    document.getElementById("btnshgrid").focus();
                    return false;
                }
            }
        }
//        else if (document.activeElement.id == "btnshgrid") {
//            document.getElementById('btnSave').focus();

//        }
        if (document.activeElement.id == "txtreceiptdate") {

            if (event.keyCode == 115) {

                popUpCalendar(document.getElementById("Img5"), Form1.txtreceiptdate, "mm/dd/yyyy")
            }

        }







        if (document.activeElement.id.indexOf("aglistpop") >= 0) {
            //            var id=document.activeElement.id.replace("aglist","");
            //            document.getElementById('ads'+id).value=document.getElementById('aglist'+id).value;
            //	        document.getElementById('agdiv'+id).style.display="none"; 
            document.getElementById(activeid).value = document.getElementById(document.activeElement.id).value;
            document.getElementById(activeid).style.backgroundColor = "#FFFFFF";
            document.getElementById('agdivpop').style.display = "none";
            return false;
        }
        if (document.activeElement.id.indexOf("aglist") >= 0) {
            //            var id=document.activeElement.id.replace("aglist","");
            //            document.getElementById('ads'+id).value=document.getElementById('aglist'+id).value;
            //	        document.getElementById('agdiv'+id).style.display="none"; 
            document.getElementById(activeid).value = document.getElementById(document.activeElement.id).value;
            document.getElementById(activeid).style.backgroundColor = "#FFFFFF";
            document.getElementById('agdiv').style.display = "none";
            return false;
        }

        if (document.activeElement.id == "lstclient") {
            if (document.getElementById('lstclient').value == "0") {
                alert("Please select the client");
                return false;
            }

            else if (document.getElementById('lstclient').value == "c") {
                document.getElementById('txtclient').value = document.getElementById('hiddenClient').value;
                document.getElementById("divclient").style.display = "none";
                document.getElementById('hiddenClient').value = '';
                if (document.getElementById('txtclientadd').disabled == false) {
                    document.getElementById('txtclientadd').focus();
                }

                /*22april*/

                ////this is to add the client in the drop down of billto////
                var lenofbillto = 1; //document.getElementById('drpbillto_qbc').options.length;
                //var lenofbillto=parseInt(lenofbillto)+1;
                //alert(client_val);
                document.getElementById('drpbillto_qbc').length = lenofbillto;
                var client_val = document.getElementById('txtclient').value
                document.getElementById('drpbillto_qbc').options[lenofbillto] = new Option(client_val, client_val);
                /*new change ankur 9 feb*/
                /*mysql*/
                //   if(document.getElementById('hiddentypedatabase').value=="mysql")
                // {
                //     document.getElementById('drpbillto_qbc').value=client_val;
                //  }
                /*22april*/
                document.getElementById('hiddenbillto').value = document.getElementById('drpbillto_qbc').value
                /////////////////

                return false;
            }
            /*22april*/
            else if (document.getElementById('lstclient').value == "r") {
                var frombooking = "1";
                document.getElementById('txtclient').value = document.getElementById('hiddenClient').value;
                var clientname = document.getElementById('txtclient').value;
                window.open('ClientMaster.aspx?frombooking=' + frombooking + '&clientname=' + clientname, '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
                document.getElementById("divclient").style.display = "none";
                document.getElementById('hiddenClient').value = '';
                if (document.getElementById('txtclientadd').disabled == false) {
                    document.getElementById('txtclientadd').focus();
                }

                /*22april*/

                ////this is to add the client in the drop down of billto////
                var lenofbillto = 1; //document.getElementById('drpbillto_qbc').options.length;
                //var lenofbillto=parseInt(lenofbillto)+1;
                //alert(client_val);                
                document.getElementById('drpbillto_qbc').length = lenofbillto;
                var client_val = document.getElementById('txtclient').value
                document.getElementById('drpbillto_qbc').options[lenofbillto] = new Option(client_val, client_val);
                /*new change ankur 9 feb*/
                /*mysql*/
                //   if(document.getElementById('hiddentypedatabase').value=="mysql")
                //   {
                //     document.getElementById('drpbillto_qbc').value=client_val;
                //  }
                /*22april*/
                document.getElementById('hiddenbillto').value = document.getElementById('drpbillto_qbc').value
                /////////////////

                return false;
            }

            document.getElementById("divclient").style.display = "none";
            var datetime = document.getElementById('txtdatetime').value;
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
            var add_street = split[2];


            document.getElementById('txtclient').value = namecode;
            //   if(document.getElementById('hiddensavemod').value=="0")
            //{
            document.getElementById('txtclientadd').value = add; //+ " "+ add_street;
            if (document.getElementById('txtclientadd').disabled == false) {
                document.getElementById('txtclientadd').focus();
            }
            //}
            //document.getElementById('txtagencyaddress').focus();

            document.getElementById("drpadcategory").style.visibility = "visible";
            document.getElementById("drpadsubcategory").style.visibility = "visible";
            document.getElementById("drpcolor").style.visibility = "visible";
            document.getElementById("drpadcat3").style.visibility = "visible";

            /*22april*/

            ////this is to add the client in the drop down of billto////

            var lenofbillto = 1; //document.getElementById('drpbillto_qbc').options.length;
            //var lenofbillto=parseInt(lenofbillto)+1;
            //alert(client_val);
            document.getElementById('drpbillto_qbc').length = lenofbillto;
            var client_val = document.getElementById('txtclient').value
            document.getElementById('drpbillto_qbc').options[lenofbillto] = new Option(client_val, client_val);
            /*new change ankur 9 feb*/
            /*mysql*/
            //  if(document.getElementById('hiddentypedatabase').value=="mysql")
            //   {
            //  document.getElementById('drpbillto_qbc').value=client_val;
            //  }
            /*22 april*/
            document.getElementById('hiddenbillto').value = document.getElementById('drpbillto_qbc').value
            /////////////////

            disbledroandcredit();
            return false;
        }
        else if (document.activeElement.id == "lstagencymain") {

            if (document.getElementById('lstagencymain').value == "0") {
                alert("Please select the Agency");
                return false;
            }
            else {
                document.getElementById("divagencymain").style.display = "none";
                var len = document.getElementById('lstagencymain').options.length;
                for (i = 0; i < len; i++) {

                    if (document.getElementById('lstagencymain').options[i].selected == true) {
                        document.getElementById('txtagency').value = "";

                        document.getElementById('txtagency').value = document.getElementById('lstagencymain').options[i].innerHTML;
                        if (document.getElementById('txtagency').value.indexOf('(') >= 0) {
                            /////////////////////////////add by anuja
                            //                                 var codesubcode=document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.indexOf('(')+1,document.getElementById('txtagency').value.length-1);
                            //var codesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.indexOf('(') + 1, document.getElementById('txtagency').value.length - 1);
                            var codesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
                            var respaymode = QBC.bindPaymentMode(codesubcode, document.getElementById('hiddencompcode').value);
                            if (respaymode.value != null && respaymode.value.Tables[0].Rows.length > 0)
                                bindpayM(respaymode.value)///////////////////////////end
                            // for agency balance
                            if (document.getElementById('txtagency').value != "") {
                                var res = QBC.getBalance(document.getElementById('hiddencompcode').value, document.getElementById('txtagency').value)
                                var ds = res.value;
                                if (ds != null && ds.Tables[0].Rows.length > 0) {
                                    if (ds.Tables[0].Rows[0].BALANCE == "0")
                                        document.getElementById('txtagencybalance').value = "0";
                                    else {
                                        if (ds.Tables[0].Rows[0].AMOUNT != null)
                                            document.getElementById('txtagencybalance').value = ds.Tables[0].Rows[0].AMOUNT;
                                    }
                                }
                                else
                                    document.getElementById('txtagencybalance').value = "0";
                            }
                            //  
                            /*var res=QBC.getAgencyStatus(document.getElementById('hiddencompcode').value,codesubcode);
                            var val=res.value;
                            if(val=="INACTIVE")
                            {
                            alert("You can't Book Ad with InActive Agency");
                            document.getElementById('txtagency').value="";
                            document.getElementById('lstagencymain').options.length=0;
                            document.getElementById('txtagency').focus();
                            return false;
                            }*/
                        }
                        document.getElementById('hiddenagencynew').value = document.getElementById('txtagency').value;

                        // for biilto
                        if (document.getElementById('drpbillto_qbc').options.length > 0) {
                            document.getElementById('drpbillto_qbc').options[0].value = document.getElementById('lstagencymain').options[i].value;
                            document.getElementById('drpbillto_qbc').options[0].innerHTML = document.getElementById('lstagencymain').options[i].innerHTML;
                        }
                        else {
                            document.getElementById('drpbillto_qbc').options[document.getElementById('drpbillto_qbc').options.length] = new Option();
                            document.getElementById('drpbillto_qbc').options[0].value = document.getElementById('lstagencymain').options[i].value;
                            document.getElementById('drpbillto_qbc').options[0].innerHTML = document.getElementById('lstagencymain').options[i].innerHTML;
                        }
                        //
                        document.getElementById('hiddenbillto').value = document.getElementById('drpbillto_qbc').value
                        //  QBC.getRec(document.getElementById('txtagency').value,getRec_callback);
                        // document.getElementById('txtreceipt').value=document.getElementById('txtagency').value.substring(0,2)+"-"+document.getElementById('hdnagencyname').value;
                        document.getElementById('txtclient').focus();
                        //fal = 0;
                        //document.getElementById('lstagencymain').options.length=0;
                        break;
                    }
                }
            }
            //=======================***************** To Fill Agency Address in Hidden fields ****************===============\\document.getElementById("div1").style.display = "none";
            var datetime = document.getElementById('txtdatetime').value;
            //alert(document.getElementById('lstagency').value);

            //alert(document.getElementById('lstagency').value);
            /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
            address and if 0 than agency name and address
            @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

            var page = document.getElementById('lstagencymain').value;
            //document.getElementById('hiddenagency').value = page;
            agencycodeglo = page;

            var id = "";
            if (browser != "Microsoft Internet Explorer") {
                var httpRequest = null; ;
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
            if (id == "yes") {
                alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                return false;
            }
            var split = id.split("+");
            var nameagen = split[0];
            var agenadd = split[1];

            document.getElementById('lstagencymain').options.length = 0;
            //document.getElementById('txtagency').value = nameagen;
            if (document.getElementById('hiddensavemod').value == "0" || document.getElementById('hiddensavemod').value == "01") {
                document.getElementById('txtagencyaddress').value = agenadd;
                QBC.bindagencusub(page, document.getElementById('hiddencompcode').value, call_bindagsub);
            }

        }





        else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
            //alert("hi");
            //alert(document.activeElement.id);
            //alert(event.keyCode);
            event.keyCode = 13;
            return event.keyCode;

        }
        else {
            var idcursor;
            if (event.shiftKey == false) {
             //  EnterTab(event, document.activeElement.id); ///add by anuja
                event.keyCode = 9;

                return event.keyCode;
            }

        }
        if (document.getElementById("btnNew").disabled == false) {
            document.getElementById("btnNew").focus();
        }
    }
   
}
function getRec_callback(response) {
    var ds = response.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var cou1 = ds.Tables[0].Rows[0].recno;
        var zeros = '';
        if (cou1.toString().length == 1) {
            zeros = "000" + cou1.toString();
        }
        if (cou1.toString().length == 2) {
            zeros = "00" + cou1.toString();
        }
        if (cou1.toString().length == 3) {
            zeros = "0" + cou1.toString();
        }
        if (cou1.toString().length == 4) {
            zeros = cou1.toString();
        }


        var agencyinitial = "";
        if (ds.Tables[0].Rows[0].depocode == null) {
            agencyinitial = document.getElementById('txtagency').value.substr(0, 2);
        }
        else {
            agencyinitial = ds.Tables[0].Rows[0].depocode;
        }
        document.getElementById('txtreceipt').value = agencyinitial + "-" + zeros;
        document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value;
    }
    document.getElementById('txtclient').focus();
}
function bindagencyname_callback(response) {
    ds = response.value;
    var pkgitem = document.getElementById("lstagencymain");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Agency-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        document.getElementById("lstagencymain").style.visibility = "visible";

        //alert(pkgitem);


        //alert(pkgitem.options.length);
        var add1 = "";

        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            /*if(ds.Tables[0].Rows[i].Agency_Name==null)
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name1+"("+ds.Tables[0].Rows[i].code_subcode+")",ds.Tables[0].Rows[i].code_subcode);
            else
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+"("+ds.Tables[0].Rows[i].code_subcode+")",ds.Tables[0].Rows[i].code_subcode);
            */
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name + '+' + ds.Tables[0].Rows[i].CITYNAME + "(" + ds.Tables[0].Rows[i].code_subcode + ")", ds.Tables[0].Rows[i].code_subcode);
            pkgitem.options.length;

        }

    }
    // document.getElementById("lstagencymain").value = "0";
    return false;
}

function bindclientname_callback(response) {

    ds = response.value;
    var pkgitem = document.getElementById("lstclient");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Client-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        //alert(pkgitem);


        //alert(pkgitem.options.length);
        var add1 = "";

        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            if (ds.Tables[0].Rows[i].Add1 != null) {
                add1 = ds.Tables[0].Rows[i].Add1;
            }
            else {
                add1 = "";
            }
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name + "+" + add1, ds.Tables[0].Rows[i].Cust_Code);

            pkgitem.options.length;

        }

    }
    document.getElementById('txtclient').value = "";
    document.getElementById('txtclientadd').value = "";
    document.getElementById("lstclient").value = "0";
    document.getElementById("lstclient").focus();

    return false;
}

////////////////this function is called when we open the list box of agency than on mouse click it get the agency

function insertagency() {
    if (document.activeElement.id == "lstclient") {
        if (document.getElementById('lstclient').value == "0") {
            alert("Please select the client");
            return false;
        }
        else if (document.getElementById('lstclient').value == "c") {

            document.getElementById('txtclient').value = document.getElementById('hiddenClient').value;
            document.getElementById("divclient").style.display = "none";
            document.getElementById('hiddenClient').value = '';
            if (document.getElementById('txtclientadd').disabled == false) {
                document.getElementById('txtclientadd').focus();
            }

            /*2may*/
            ////this is to add the client in the drop down of billto////
            var lenofbillto = document.getElementById('drpbillto_qbc').options.length;
            //var lenofbillto=parseInt(lenofbillto)+1;
            //alert(client_val);
            var client_val = document.getElementById('txtclient').value

            document.getElementById('drpbillto_qbc').options[1] = new Option(client_val, client_val);
            /*new change ankur 9 feb*/
            /*mysql*/

            //if(document.getElementById('hiddentypedatabase').value=="mysql")
            //             {

            //document.getElementById('drpbillto_qbc').value=client_val;
            //   }
            /*22april*/

            document.getElementById('hiddenbillto').value = document.getElementById('drpbillto_qbc').value
            /////////////////

            return false;
        }
        /*22april*/
        else if (document.getElementById('lstclient').value == "r") {
            var frombooking = "1";

            document.getElementById('txtclient').value = document.getElementById('hiddenClient').value;
            var clientname = document.getElementById('txtclient').value;

            window.open('ClientMaster.aspx?frombooking=' + frombooking + '&clientname=' + clientname, '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
            document.getElementById("divclient").style.display = "none";
            document.getElementById('hiddenClient').value = '';
            if (document.getElementById('txtclientadd').disabled == false) {
                document.getElementById('txtclientadd').focus();
            }

            /*22april*/

            ////this is to add the client in the drop down ofbillto////
            var lenofbillto = document.getElementById('drpbillto_qbc').options.length;
            //var lenofbillto=parseInt(lenofbillto)+1;
            //alert(client_val);
            var client_val = document.getElementById('txtclient').value

            document.getElementById('drpbillto_qbc').options[1] = new Option(client_val, client_val);
            /*new change ankur 9 feb*/
            /*mysql*/

            //if(document.getElementById('hiddentypedatabase').value=="mysql")
            //                    {

            //document.getElementById('drpbillto_qbc').value=client_val;
            //                     }
            /*22april*/

            document.getElementById('hiddenbillto').value = document.getElementById('drpbillto_qbc').value
            /////////////////

            return false;
        }





        document.getElementById("divclient").style.display = "none";
        var datetime = document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as
        the add ress of client if 0 than client name and
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

            httpRequest.onreadystatechange = function ()
            { alertContents(httpRequest) };

            httpRequest.open(
"GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1",
false);
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
            xml.Open(
"GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1",
false);
            xml.Send();
            id = xml.responseText;
        }

        var split = id.split("+");
        var namecode = split[0];
        var add = split[1];
        var add_street = split[2];


        document.getElementById('txtclient').value = namecode;
        if (document.getElementById('hiddensavemod').value == "0" ||
document.getElementById('hiddensavemod').value == "01") {
            document.getElementById('txtclientadd').value = add; // + " " + add_street;

            if (document.getElementById('txtclientadd').disabled == false) {
                document.getElementById('txtclientadd').focus();
            }
        }


        document.getElementById("drpadcategory").style.visibility = "visible";

        document.getElementById("drpadsubcategory").style.visibility = "visible";

        document.getElementById("drpcolor").style.visibility = "visible";

        document.getElementById("drpadcat3").style.visibility = "visible";

        /*22april*/

        ////this is to add the client in the drop down of billto////
        var lenofbillto = document.getElementById('drpbillto_qbc').options.length;
        //var lenofbillto=parseInt(lenofbillto)+1;
        //alert(client_val);
        var client_val = document.getElementById('txtclient').value
        document.getElementById('drpbillto_qbc').options[1] = new Option(client_val, client_val);
        /*new change ankur 9 feb*/
        /*mysql*/
        //    if(document.getElementById('hiddentypedatabase').value=="mysql")
        //  {
        //   document.getElementById('drpbillto_qbc').value=client_val;
        //   }
        /*22 april*/

        document.getElementById('hiddenbillto').value = document.getElementById('drpbillto_qbc').value
        /////////////////

        disbledroandcredit();
        return false;
    }

}

function lstagencymain1() {
    if (document.activeElement.id == "lstagencymain") {
        if (document.getElementById('lstagencymain').value == "0") {
            alert("Please select the Agency");
            return false;
        }
        document.getElementById("divagencymain").style.display = "none";
        var len = document.getElementById('lstagencymain').options.length;
        for (i = 0; i < len; i++) {
            if (document.getElementById('lstagencymain').options[i].selected == true) {
                document.getElementById('txtagency').value = ""
                document.getElementById('txtagency').value = document.getElementById('lstagencymain').options[i].innerHTML;
                if (document.getElementById('txtagency').value.indexOf('(') >= 0) {
                    ////add by anuja
                    //var codesubcode=document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.indexOf('(')+1,document.getElementById('txtagency').value.length-1);
                    //var codesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.indexOf('(') + 1, document.getElementById('txtagency').value.length - 1);
                    var codesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
                    var respaymode = QBC.bindPaymentMode(codesubcode, document.getElementById('hiddencompcode').value);
                    if (respaymode.value != null && respaymode.value.Tables[0].Rows.length > 0)
                        bindpayM(respaymode.value)//////////////////////end
                    // for agency balance
                    if (document.getElementById('txtagency').value != "") {
                        var res = QBC.getBalance(document.getElementById('hiddencompcode').value, document.getElementById('txtagency').value)
                        var ds = res.value;
                        if (ds != null && ds.Tables[0].Rows.length > 0) {
                            if (ds.Tables[0].Rows[0].BALANCE == "0")
                                document.getElementById('txtagencybalance').value = "0";
                            else {
                                if (ds.Tables[0].Rows[0].AMOUNT != null)
                                    document.getElementById('txtagencybalance').value = ds.Tables[0].Rows[0].AMOUNT;
                            }
                        }
                        else
                            document.getElementById('txtagencybalance').value = "0";
                    }
                    //
                    /*  var res=QBC.getAgencyStatus(document.getElementById('hiddencompcode').value,codesubcode);
                    var val=res.value;
                    if(val=="INACTIVE")
                    {
                    alert("You can't Book Ad with InActive Agency");
                    document.getElementById('txtagency').value="";
                    document.getElementById('lstagencymain').options.length=0;
                    document.getElementById('txtagency').focus();
                    return false;
                    }*/
                }
                document.getElementById('hiddenagencynew').value = document.getElementById('txtagency').value;

                if (document.getElementById('drpbillto_qbc').options.length > 0) {
                    document.getElementById('drpbillto_qbc').options[0].value = document.getElementById('lstagencymain').options[i].value;
                    document.getElementById('drpbillto_qbc').options[0].innerHTML = document.getElementById('lstagencymain').options[i].innerHTML;
                }
                else {
                    document.getElementById('drpbillto_qbc').options[document.getElementById('drpbillto_qbc').options.length] = new Option();
                    document.getElementById('drpbillto_qbc').options[0].value = document.getElementById('lstagencymain').options[i].value;
                    document.getElementById('drpbillto_qbc').options[0].innerHTML = document.getElementById('lstagencymain').options[i].innerHTML;
                }
                document.getElementById('hiddenbillto').value = document.getElementById('drpbillto_qbc').value
                //    QBC.getRec(document.getElementById('txtagency').value,getRec_callback);      
                //      document.getElementById('txtreceipt').value=document.getElementById('txtagency').value.substring(0,2)+"-"+document.getElementById('hdnagencyname').value;
                //document.getElementById('lstagencymain').options.length=0;
                break;
            }
        }
        //=======================***************** To Fill Agency Address in Hidden fields ****************===============\\document.getElementById("div1").style.display = "none";
        var datetime = document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);

        //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

        var page = document.getElementById('lstagencymain').value;
        //document.getElementById('hiddenagency').value = page;
        agencycodeglo = page;

        var id = "";
        if (browser != "Microsoft Internet Explorer") {
            var httpRequest = null; ;
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
        if (id == "yes") {
            alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
            return false;
        }
        var split = id.split("+");
        var nameagen = split[0];
        var agenadd = split[1];

        document.getElementById('lstagencymain').options.length = 0;
        //document.getElementById('txtagency').value = nameagen;
        if (document.getElementById('hiddensavemod').value == "0" || document.getElementById('hiddensavemod').value == "01") {
            document.getElementById('txtagencyaddress').value = agenadd;
            QBC.bindagencusub(page, document.getElementById('hiddencompcode').value, call_bindagsub);
        }
    }
    else if (document.getElementById('agnlogin').value == "Y") {
      
                    //var codesubcode =  document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.indexOf('(') + 1, document.getElementById('txtagency').value.length - 1);
                    var codesubcode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
                    var respaymode = QBC.bindPaymentModedepo(codesubcode, document.getElementById('hiddencompcode').value);
                    if (respaymode.value != null && respaymode.value.Tables[0].Rows.length > 0)
                        bindpayM(respaymode.value);
                        //////////////////////end 
        
    }
    return false;
}


function documentClick(event) {

    var activeElementid = "";
    if (browser != "Microsoft Internet Explorer") {
        activeElementid = arguments[0].target.id;
    }
    else {
        activeElementid = document.activeElement.id;
    }

    if (activeElementid.indexOf("test_grid_ctl") == 0) {
        find_package(activeElementid);
    }
    else if (activeElementid.indexOf("ins") == 0 && document.getElementById(activeElementid).title != "") {
        opencopyDivInsertion(activeElementid);
    }
    else if (activeElementid.indexOf("pai") == 0) {
        document.getElementById('txtgrossamt').value = "";
        if (document.getElementById(activeElementid).value == "Y") {
            paivar = "Y";
        }
        else {
            paivar = "";
        }
    }
    else if (activeElementid.indexOf("coldiv") == 0) {
        activeid = activeElementid;
        var userid = document.getElementById('hiddenuserid').value;
        var compcode = document.getElementById('hiddencompcode').value;
        var divid = "agdivpop";
        var listboxid = "aglistpop";
        var ds = QBC.bindcolorForGrid(compcode, userid);
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
        var tot = 0; //document.getElementById('bookdiv').scrollLeft;


        var scrolltop = 0; //document.getElementById('bookdiv').scrollTop;

        document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
        //  document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
        document.getElementById(activeid).style.backgroundColor = "#FFFF80";
        document.getElementById(divid).style.display = "block";
        document.getElementById(listboxid).focus();
    }
    else if (activeElementid.indexOf("adsdiv") == 0) {
        activeid = activeElementid;
        var divid = "agdivpop";
        var listboxid = "aglistpop";
        var compcode = document.getElementById('hiddencompcode').value;
        var adcategory = activeElementid.replace("ads", "adcat");
        if (document.getElementById(adcategory) == null) {
            adcategory = document.getElementById('drpadcategory').value;
        }
        else {
            adcategory = document.getElementById(adcategory).value;
        }
        var ds = QBC.getadsubcat(compcode, adcategory);

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
    else if (activeElementid.indexOf("divinssta") == 0) {
        activeid = activeElementid;
        var divid = "agdivpop";
        var listboxid = "aglistpop";
        var objadscat = document.getElementById(listboxid);
        objadscat.options.length = 0;
        //                    objadscat.options[0]=new Option("-Select-","0");
        var c = 0;
        if (browser != "Microsoft Internet Explorer") {
            //                req = new XMLHttpRequest();
            //                req.onreadystatechange = getMessage;
            //                req.open("GET", "xml/billcycle.xml", true);
            //                req.send('');
            for (b = 1; b <= xmlObj.childNodes[19].childNodes.length - 1; ) {
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
    else if (activeElementid.indexOf("adcat") == 0) {
        activeid = activeElementid;
        var compcode = document.getElementById('hiddencompcode').value;
        var divid = "agdiv";
        var listboxid = "aglist";
        var ds = QBC.advcatinGrid(compcode);
        if (ds == null)
            return false;
        var objadscat = document.getElementById(listboxid);
        objadscat.options.length = 0;
        objadscat.options[0] = new Option("-Select-", "0");
        //alert(pkgitem.options.length);
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
        //  document.getElementById(divid).top= document.getElementById(activeid).offsetTop;
        document.getElementById(listboxid).focus();
    }
    else if (activeElementid.indexOf("mat") == 0) {
        activeid = activeElementid;
        var divid = "agdiv";
        var listboxid = "aglist";
        var objadscat = document.getElementById(listboxid);
        objadscat.options.length = 0;
        objadscat.options[0] = new Option("-Select-", "0");
        objadscat.options[1] = new Option("-Hard Copy-", "hardcopy");
        objadscat.options[2] = new Option("-Soft Copy-", "softcopy");
        objadscat.options[3] = new Option("-cd-", "CD");
        objadscat.options[4] = new Option("-Others-", "other");
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
    else if (activeElementid.indexOf("adscat3") == 0) {
        activeid = activeElementid;
        var divid = "agdiv";
        var listboxid = "aglist";
        var compcode = document.getElementById('hiddencompcode').value;
        var adcategory = activeElementid.replace("adscat3", "ads");
        adcategory = document.getElementById(adcategory).value;

        var ds = QBC.bindadcat3(adcategory, compcode, "0");

        if (ds == null)
            return false;
        var objadscat = document.getElementById(listboxid);
        objadscat.options.length = 0;
        objadscat.options[0] = new Option("-Select-", "0");
        //alert(pkgitem.options.length);
        objadscat.options.length = 1;
        for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
            objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].catname, ds.value.Tables[0].Rows[i].catcode);

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
        document.getElementById(divid).cssclass = "btextlist";
        document.getElementById(listboxid).focus();
    }
    else if (activeElementid.indexOf("adscat4") == 0) {
        activeid = activeElementid;
        var divid = "agdiv";
        var listboxid = "aglist";
        var compcode = document.getElementById('hiddencompcode').value;
        var adcategory = activeElementid.replace("adscat4", "adscat3");
        adcategory = document.getElementById(adcategory).value;

        var ds = QBC.bindadcat3(adcategory, compcode, "1");

        if (ds == null)
            return false;
        var objadscat = document.getElementById(listboxid);
        objadscat.options.length = 0;
        objadscat.options[0] = new Option("-Select-", "0");
        //alert(pkgitem.options.length);
        objadscat.options.length = 1;
        for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
            objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Cat_Name, ds.value.Tables[0].Rows[i].Cat_Code);

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
        document.getElementById(divid).cssclass = "btextlist";

        document.getElementById(listboxid).focus();
    }
    else if (activeElementid.indexOf("adscat5") == 0) {
        activeid = activeElementid;
        var divid = "agdiv";
        var listboxid = "aglist";
        var compcode = document.getElementById('hiddencompcode').value;
        var adcategory = activeElementid.replace("adscat5", "adscat4");
        adcategory = document.getElementById(adcategory).value;

        var ds = QBC.bindadcat3(adcategory, compcode, "2");

        if (ds == null)
            return false;
        var objadscat = document.getElementById(listboxid);
        objadscat.options.length = 0;
        objadscat.options[0] = new Option("-Select-", "0");
        //alert(pkgitem.options.length);
        objadscat.options.length = 1;
        for (var i = 0; i < ds.value.Tables[0].Rows.length; ++i) {
            objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].catname, ds.value.Tables[0].Rows[i].catcode);

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
        document.getElementById(divid).cssclass = "btextlist";

        document.getElementById(listboxid).focus();
    }
    else if (activeElementid.indexOf("col") == 0) {
        activeid = activeElementid;
        var userid = document.getElementById('hiddenuserid').value;
        var compcode = document.getElementById('hiddencompcode').value;
        var divid = "agdiv";
        var listboxid = "aglist";
        var ds = QBC.bindcolorForGrid(compcode, userid);
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
    else if (activeElementid.indexOf("ads") == 0) {
        activeid = activeElementid;
        var divid = "agdiv";
        var listboxid = "aglist";
        var compcode = document.getElementById('hiddencompcode').value;
        var adcategory = activeElementid.replace("ads", "adcat");
        if (document.getElementById(adcategory) == null) {
            adcategory = document.getElementById('drpadcategory').value;
        }
        else {
            adcategory = document.getElementById(adcategory).value;
        }
        var ds = QBC.getadsubcat(compcode, adcategory);

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
        document.getElementById(divid).cssclass = "btextlist";
        document.getElementById(listboxid).focus();
    }
    else if (activeElementid.indexOf("inssta") == 0) {
        activeid = activeElementid;
        var divid = "agdiv";
        var listboxid = "aglist";
        var objadscat = document.getElementById(listboxid);
        objadscat.options.length = 0;
        //                    objadscat.options[0]=new Option("-Select-","0");
        var c = 0;

        if (browser != "Microsoft Internet Explorer") {
            //                req = new XMLHttpRequest();
            //                req.onreadystatechange = getMessage;
            //                req.open("GET", "xml/billcycle.xml", true);
            //                req.send('');
            for (b = 1; b <= xmlObj.childNodes[19].childNodes.length - 1; ) {
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
    else if (activeElementid.indexOf("pagno") == 0) {
        var res = rateenter(event);
        if (res == false)
            return false;
    }
    //   else if(document.activeElement.id.indexOf("uploadA")==0)
    //    {
    //        uploadimageall();   
    //    }
    else if (activeElementid.indexOf("upload") == 0 && activeElementid.indexOf("uploadA") < 0) {
        var n1 = activeElementid;
        var idnum = document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('upload', ''), 10) + 1].cells[0].innerHTML;
        return uploadimage(document.getElementById('edit0').value, n1.replace('upload', 'pic'), idnum, n1.replace('upload', 'edit'), n1.replace('upload', 'fil'), n1.replace('upload', ''));
    }
    else if (activeElementid.indexOf("aglist") == 0) {
        FillSubCatinGrid();
    }
    else if (activeElementid.indexOf("splt") == 0) {
        var n1 = activeElementid;

        var idnum = document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('splt', ''), 10) + 1].cells[0].innerHTML;
        var editid = "edit" + idnum;
        opensplitedition(document.getElementById(editid).value, idnum);
    }
    else if (activeElementid.indexOf("subedi") == 0) {
        if (document.getElementById('txttotalarea').value == "") {
            alert("Please fill Size");
            return false;
        }
        var n1 = activeElementid;
        var idnum = activeElementid.replace("subedi", "");
        var editid = "edit" + idnum;
        var size = "siz" + idnum;
        var hei = "hei" + idnum;
        var wid = "wid" + idnum;
        var id = "Text" + idnum;
        var pageno_inserts = "pagno" + idnum;
        var data = "subedidata" + idnum;
        showid = "sho" + idnum;
        var pkgcode = "hiddenpckcode" + idnum;
        var insertsta = "inssta" + idnum;
        var showidval = "";
        if (document.getElementById(showid) != null)
            showidval = document.getElementById(showid).value;
        window.open('booking_subeditiondetail.aspx?package=' + document.getElementById(pkgcode).value + '&cioid=' + document.getElementById('txtciobookid').value + '&uomdesc=' + document.getElementById('hiddenuomdesc').value + '&compcode=' + document.getElementById('hiddencompcode').value + '&insertdate=' + document.getElementById(id).value + '&width=' + document.getElementById(wid).value + '&data=' + document.getElementById(data).value + '&height=' + document.getElementById(hei).value + '&edition=' + document.getElementById(editid).value + '&insertid=' + showidval + '&insertstatus=' + document.getElementById(insertsta).value + '&btnstatus=' + chkbtnStatus + '&totarea=' + document.getElementById(size).value + '&idnum=' + idnum + '&dateformat=' + document.getElementById('hiddendateformat').value + '&receiptno=' + document.getElementById('txtreceipt').value + '&pageno=' + document.getElementById(pageno_inserts).value, 'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=560px,height=300px');
    }
}
function uploadimageQBCAll() {

    if (document.getElementById('uploadA').style.color == "red")
        uploadimageall();
}
function opencopyDivInsertion(activeid) {
    var no = activeid.replace("ins", "");
    var billno = "";
    var billdate = "";
    var insbillamt = calculateinsbillamt(no, activeid);
    var re = QBC.getbillnobilldate(document.getElementById('txtciobookid').value, document.getElementById(activeid).innerHTML);
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

    var str = "<table  border=1><tr><td><table  border=0  style='background-color: #ffffff;'><tr bgcolor=\"#7DAAF3\" class=\"dtGridHd12\"><td>Sr. No.</td><td>Date</td><td>Subcategory</td><td>Color</td><td>Height</td><td>Width</td><td>Size</td><td>Insert Bill Amt.</td><td>Status</td><td>Bill No.</td><td>Bill Date</td><td>Pageno</td><td>Remarks</td></tr>";
    if (document.getElementById("hiddenuomdesc").value == "CD") {
        //str=str+"<tr><td class=TextField valign=top>"+document.getElementById(activeid).innerHTML+"</td><td valign=top><input class=\"btextforgriddate\" type=\"text\" id='Textdiv"+no+"' value='"+document.getElementById("Text"+no).value+"' ></td><td valign=top><input id='adsdiv"+no+"' class=\"btextforgrid\" type=\"text\"  value="+document.getElementById("ads"+no).value+" ><div id='agdivpop' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglistpop'  id='aglistpop' CssClass='btextlist' size=4 Width=100px Height=50px></select></div></td><td valign=top><input class=\"btextforgrid\" id='coldiv"+no+"' type=\"text\" value="+document.getElementById("col"+no).value+" ></td><td valign=top><input  class=\"btextsmallsize\" id='heidiv"+no+"'  type=\"text\" onChange=\"divAddclick("+no+","+activeid+");\" value="+document.getElementById("hei"+no).value+"></td><td valign=top><input  class=\"btextsmallsize\" id='widdiv"+no+"'  type=\"text\" onChange=\"divAddclick("+no+","+activeid+");\" value="+document.getElementById("wid"+no).value+"></td><td valign=top><input  class=\"btextsmallsize\" disabled id='sizdiv"+no+"'  type=\"text\" value="+document.getElementById("siz"+no).value+"></td><td valign=top><input class=\"btextforgrid\"  type=\"text\" id='divinssta"+no+"' value="+document.getElementById("inssta"+no).value+"></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv"+no+"' type=\"text\" value="+document.getElementById("pagno"+no).value+"></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv"+no+"'   type=\"text\" title='"+document.getElementById("rem"+no).value+"' value='"+document.getElementById("rem"+no).value+"' style='height:30px;width:180px'></textarea></td></tr>";
        str = str + "<tr><td class=TextField valign=top>" + document.getElementById(activeid).innerHTML + "</td><td valign=top><input class=\"btextforgriddate\" type=\"text\" id='Textdiv" + no + "' onchange=\"return chkDateforGrid();\"  value='" + document.getElementById("Text" + no).value + "' ></td><td valign=top><input id='adsdiv" + no + "' onchange=\"return blankGross();\" class=\"btextforgrid\" type=\"text\"  value=" + document.getElementById("ads" + no).value + " ><div id='agdivpop' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglistpop' onClick=\"FillSubCatinGrid();\"  id='aglistpop' CssClass='btextlist' size=4 Width=100px Height=50px></select></div></td><td valign=top><input class=\"btextsmallsize\" id='coldiv" + no + "' onchange=\"return blankGross();\" type=\"text\" value=" + document.getElementById("col" + no).value + " ></td><td valign=top><input  class=\"btextsmallsize\" id='heidiv" + no + "'  type=\"text\" value=" + document.getElementById("hei" + no).value + " onChange=\"divAddclick(" + no + "," + activeid + ");\"></td><td valign=top><input  class=\"btextsmallsize\" id='widdiv" + no + "'  type=\"text\" onChange=\"divAddclick(" + no + "," + activeid + ");\" value=" + document.getElementById("wid" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" disabled id='sizdiv" + no + "'  type=\"text\" value=" + document.getElementById("siz" + no).value + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='insbillamtdiv" + no + "'  type=\"text\" value=" + insbillamt + "></td><td valign=top><input class=\"btextforgrid\"  type=\"text\" id='divinssta" + no + "' value=" + document.getElementById("inssta" + no).value + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billnodiv" + no + "'  type=\"text\" value=" + billno + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billdtdiv" + no + "'  type=\"text\" value=" + billdate + "></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:140px'>" + document.getElementById("rem" + no).value + "</textarea></td></tr>";
    }
    else {
        //str=str+"<tr><td class=TextField valign=top>"+document.getElementById(activeid).innerHTML+"</td><td valign=top><input class=\"btextforgriddate\" type=\"text\" id='Textdiv"+no+"' value='"+document.getElementById("Text"+no).value+"' ></td><td valign=top><input id='adsdiv"+no+"' class=\"btextforgrid\" type=\"text\"  value="+document.getElementById("ads"+no).value+" ><div id='agdivpop' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglistpop'  id='aglistpop' CssClass='btextlist' size=4 Width=100px Height=50px></select></div></td><td valign=top><input class=\"btextforgrid\" id='coldiv"+no+"' type=\"text\" value="+document.getElementById("col"+no).value+" ></td><td valign=top><input  class=\"btextsmallsize\" disabled id='heidiv"+no+"'  type=\"text\" value="+document.getElementById("hei"+no).value+"></td><td valign=top><input  class=\"btextsmallsize\" disabled id='widdiv"+no+"'  type=\"text\" value="+document.getElementById("wid"+no).value+"></td><td valign=top><input  class=\"btextsmallsize\" id='sizdiv"+no+"'  type=\"text\" value="+document.getElementById("siz"+no).value+"></td><td valign=top><input class=\"btextforgrid\"  type=\"text\" id='divinssta"+no+"' value="+document.getElementById("inssta"+no).value+"></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv"+no+"' type=\"text\" value="+document.getElementById("pagno"+no).value+"></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv"+no+"'   type=\"text\" title='"+document.getElementById("rem"+no).value+"' value='"+document.getElementById("rem"+no).value+"' style='height:30px;width:180px'></textarea></td></tr>";    
        str = str + "<tr><td class=TextField valign=top>" + document.getElementById(activeid).innerHTML + "</td><td valign=top><input class=\"btextforgriddate\" type=\"text\" id='Textdiv" + no + "' onchange=\"return chkDateforGrid();\"  value='" + document.getElementById("Text" + no).value + "' ></td><td valign=top><input id='adsdiv" + no + "' onchange=\"return blankGross();\" class=\"btextforgrid\" type=\"text\"  value=" + document.getElementById("ads" + no).value + " ><div id='agdivpop' Width=100px Height=50px style='position:absolute;display: none;'><select name='aglistpop' onClick=\"FillSubCatinGrid();\"  id='aglistpop' CssClass='btextlist' size=4 Width=100px Height=50px></select></div></td><td valign=top><input class=\"btextsmallsize\" id='coldiv" + no + "' onchange=\"return blankGross();\" type=\"text\" value=" + document.getElementById("col" + no).value + " ></td><td valign=top><input  class=\"btextsmallsize\" disabled id='heidiv" + no + "'  type=\"text\" value=" + document.getElementById("hei" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" disabled id='widdiv" + no + "'  type=\"text\" value=" + document.getElementById("wid" + no).value + "></td><td valign=top><input  class=\"btextsmallsize\" onchange=\"return blankGross();\" id='sizdiv" + no + "'  type=\"text\" value=" + document.getElementById("siz" + no).value + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='insbillamtdiv" + no + "'  type=\"text\" value=" + insbillamt + "></td><td valign=top><input class=\"btextforgrid\"  type=\"text\" id='divinssta" + no + "' value=" + document.getElementById("inssta" + no).value + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billnodiv" + no + "'  type=\"text\" value=" + billno + "></td><td valign=top><input  class=\"btextforgrid\" disabled id='billdtdiv" + no + "'  type=\"text\" value=" + billdate + "></td><td valign=top><input class=\"btextsmallsizeH\" id='pagnodiv" + no + "' type=\"text\" value=" + document.getElementById("pagno" + no).value + "></td><td valign=top><textarea  class=\"btextforgrid\"  id='remdiv" + no + "'   type=\"text\" title='" + document.getElementById("rem" + no).value + "'  style='height:30px;width:140px'>" + document.getElementById("rem" + no).value + "</textarea></td></tr>";
    }
    //str=str+"<tr ><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td align=right><input type=button class=\"buttonsplit\" value=Ok onClick=\"divokclick("+no+","+activeid+");\"><input type=button class=\"buttonsplit\" value=Close onClick=\"divcancelclick();\"></td></tr>";
    str = str + "<tr ><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td colspan='2' align=right><input type=button class=\"buttonsplit\" value=Ok onClick=\"divokclick('" + no + "','" + document.getElementById(activeid).innerHTML + "');\"><input type=button class=\"buttonsplit\" value=Close onClick=\"divcancelclick();\"></td><td></td></tr>";
    str = str + "</table></TD></TR></TABLE>";
    document.getElementById('divcopyinsertion').innerHTML = str;
    document.getElementById('divcopyinsertion').style.display = "block";
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
    for (var i = parseInt(no, 10); i < count1; i++) {
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
    var hei = document.getElementById('heidiv' + no).value;
    var wid = document.getElementById('widdiv' + no).value;
    if (hei != "" && wid != "") {
        document.getElementById('sizdiv' + no).value = parseFloat(hei) * parseFloat(wid);

    }
}
function divokclick(no, activeid) {
    var valT = activeid; //.innerHTML;
    var count1 = document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length - 1;
    for (var i = parseInt(no, 10); i < count1; i++) {
        if (valT == document.getElementById("ins" + i).innerHTML && document.getElementById("inssta" + i).value != "cancel" && document.getElementById("inssta" + i).value != "billed" && document.getElementById("inssta" + i).value != "publish") {
            document.getElementById('ads' + i).value = document.getElementById('adsdiv' + no).value;
            document.getElementById('Text' + i).value = document.getElementById('Textdiv' + no).value;
            document.getElementById('col' + i).value = document.getElementById('coldiv' + no).value;
            document.getElementById('siz' + i).value = document.getElementById('sizdiv' + no).value;
            document.getElementById('inssta' + i).value = document.getElementById('divinssta' + no).value;
            document.getElementById('pagno' + i).value = document.getElementById('pagnodiv' + no).value;
            document.getElementById('rem' + i).value = document.getElementById('remdiv' + no).value;
            document.getElementById('rem' + i).title = document.getElementById('rem' + i).value;
            document.getElementById('hei' + i).value = document.getElementById('heidiv' + no).value;
            document.getElementById('wid' + i).value = document.getElementById('widdiv' + no).value;

        }
        else {
            break;
        }
    }
    document.getElementById('divcopyinsertion').style.display = "none";
}
//To Bind Agency and client Name on key press ...
function f2query(event) {
    if (agnf2 == "Y" && event.keyCode != 113) {
        if (document.activeElement.id == "txtagency") {
            if (document.getElementById('txtagency').value == "") {
                if (document.getElementById("divagencymain").style.display == "block") {
                    document.getElementById("divagencymain").style.display = "none"
                    document.getElementById('txtagency').focus();
                    return false;
                }
                return false;
            }
            if (event.keyCode == 40) {
                document.getElementById("lstagencymain").focus();
                return false;
            }
            if (document.getElementById("divagencymain").style.display == "none") {
                document.getElementById("divagencymain").style.display = "block";
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
                document.getElementById('divagencymain').style.top = document.getElementById("txtagency").offsetTop + (toppos + 15) + "px";
                document.getElementById('divagencymain').style.left = document.getElementById("txtagency").offsetLeft + leftpos + "px";
            }
            QBC.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txtagency').value, "Y", bindagencyname_callback);

        }
    }
}
function call_bindagsub(response) {
    if (document.activeElement.id == "txtclientadd") {
        if (document.getElementById("txtMobile").disabled == false) {
           // document.getElementById('txtMobile').style.backgroundColor = "#0000FF";
                    document.getElementById("txtMobile").focus();
                    return false;
                }
        }
    ds = response.value;
    var pkgitem = document.getElementById("drpagscode");
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
    var compcode = document.getElementById('hiddencompcode').value
    var dateformat = document.getElementById('hiddendateformat').value
    if (subagency == "0") {
        alert("Please select sub agency");
        return false;
    }
    QBC.getpayandstatus(agencycodeglo, subagency, compcode, datetime, dateformat, call_fillpay);
    return false;
}
function call_fillpay(res) {
    var ds = res.value;
    if (ds == null) {
        alert(res.error.description);
        return false;
    }
    if (document.getElementById('drppaymenttype').value == "CR0") {
        if (ds.Tables[2].Rows[0].CREDIT_LIMIT != "" && ds.Tables[2].Rows[0].CREDIT_LIMIT != null) {
            if (parseFloat(ds.Tables[7].Rows[0].outstand) > parseFloat(ds.Tables[2].Rows[0].CREDIT_LIMIT) && (ds.Tables[7].Rows[0].OUTSTANDING_AMT_CRITERIA != null && ds.Tables[7].Rows[0].OUTSTANDING_AMT_CRITERIA != '3')) {
                alert('Outstanding amount of this agency exceeding the Credit Limit');
                document.getElementById('hiddensubcode').value = "";
                return false;
            }
        }
    }
    if (ds.Tables[2].Rows.length > 0) {
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
    }
    document.getElementById('txtagency').title = document.getElementById('txtagency').value;
    document.getElementById('txtagencyaddress').title = document.getElementById('txtagencyaddress').value;
    if (ds.Tables.length > 7) {
        if (ds.Tables[7].Rows.length > 0)
            document.getElementById('txtagencyoutstand').value = ds.Tables[7].Rows[0].outstand;
        if (document.getElementById('drppaymenttype').value == "CR0") {
            document.getElementById('txtagencybalance').value = ds.Tables[7].Rows[0].outstand;
        }
        else {
            document.getElementById('txtagencybalance').value = "";
        }
    }
    if (ds.Tables[4].Rows.length > 0) {
        if (ds.Tables[4].Rows[0].CASH_DISCOUNT1 != null)
            document.getElementById('txtcashdiscount').value = ds.Tables[4].Rows[0].CASH_DISCOUNT1;
        if (ds.Tables[4].Rows[0].CASH_DISCOUNT != null)
            document.getElementById('txtcashdiscount').value = ds.Tables[4].Rows[0].CASH_DISCOUNT;
        if (ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1 != null)
            document.getElementById('hiddencashdiscper').value = ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1;
        if (ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE != null)
            document.getElementById('hiddencashdiscper').value = ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE;
        document.getElementById('hiddenagcommflag').value = ds.Tables[4].Rows[0].FLAG;
    }
}
///////////////////////add by anuja for payment type

function bindpayM(ds) {
    var objcol = document.getElementById('drppaymenttype');
    objcol.options.length = 0;
    if (document.getElementById('agnlogin').value == "N")
        objcol.options[0] = new Option("-Select-", "0");
    //alert(pkgitem.options.length);
    objcol.options.length = 1;
    for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
        objcol.options[objcol.options.length] = new Option(ds.Tables[0].Rows[i].payment_mode_name, ds.Tables[0].Rows[i].pay_mode_code);

        objcol.options.length;
    }
    if (document.getElementById('hdndepo').value == "depo") {
        document.getElementById('drppaymenttype').value = "CA0";
    }
}
function insertcashdetailQBC(bookid, hdnbutton, paymode) {
    var res = QBC.insertcashdetail(bookid, hdnbutton, paymode);
    if (res.error != null) {
        alert(res.error.description);
    }
    if (res.value.Tables[0].Rows[0].RECPTNO != null && res.value.Tables[0].Rows[0].RECPTNO != "null")
        temp = res.value.Tables[0].Rows[0].RECPTNO;
    else
        temp = "";
    updatercptQBC(temp, bookid, paymode, hdnbutton);
    //document.getElementById('txtbillamt').value = "";
    return false;

}
function updatercptQBC(temp, bookid, drppaymode) {
    var kk = 0;
    var bookingid = "";
    var crdmnth = ""; //document.getElementById('drpmonth').value;
    var crdyear = ""; //document.getElementById('drpyear').value;
    var crdname = ""; //document.getElementById('txtcardname').value;
    var crdtype = ""; //document.getElementById('drptype').value;
    var crdnumber = ""; //document.getElementById('txtcardno').value;
    var chkno = ""; //document.getElementById('ttextchqno').value;
    var chkdate = ""; //document.getElementById('ttextchqdate').value;
    var chkamt = ""; //document.getElementById('ttextchqamt').value;
    var chkbankname = ""; //document.getElementById('ttextbankname').value;
    ro = QBC.updatero(document.getElementById('hiddencompcode').value, drppaymode, bookid, temp, crdmnth, crdyear, crdname, crdtype, crdnumber, chkno, chkdate, chkamt, chkbankname, document.getElementById("hdnbutton").value);
    bookingid = bookid
    printreceiptQBC(temp, bookingid);
    //print_receipt(temp, bookingid)
    return false;

}
function printreceiptQBC(receiptno, cioid) {

    var ds_mode = "";
    var paymode = "";
    var recptno = receiptno;
    cioid = cioid + ',';
    var cls_matter = "";
    // document.getElementById('btnsubmit').click();
    var lngth = cioid.split(',');
    //  document.getElementById('hdnlength').value = lngth.length;

    var ln = lngth.length; //document.getElementById('hdnlength').value;
    var agency = ""; // document.getElementById('txtagency12').value;
    var coid = ""; //document.getElementById('txtbookingid').value;
    if (agency != "" || coid != "") {
        print_receipt(receiptno, cioid);
    }
    else if (cioid != "") {
        if (ds_mode == undefined || ds_mode == "")
            window.open('rcptformultiplebookid.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&length=' + ln, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
        else {
            if (paymode == "Cash" || paymode == "CASH" || paymode == "cash")
                window.open('rcptformultiplebookid.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&length=' + ln, '', 'width=700px,height=550px,resizable=1,left=0,top=0,menubar=yes,scrollbars=yes');

            else
                window.open('Receiptonly.aspx?cioid=' + cioid + '&rcptno=' + rcptno + '&compcode=' + compcode, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
        }
    }

    else {
        alert("Please get the Booking id");
    }
    return false;
}


function binddate() {
    if (document.getElementById('txtrepeatingdate').value !== "") {
        var compcode = document.getElementById('hiddencompcode').value;
        var firstinsert = document.getElementById('txtdummydate').value;
        var repatingdate = document.getElementById('txtrepeatingdate').value;
        var rowcount = parseInt(document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length);
        var insertval = "0";
        var dayflag = [];
        if (document.getElementById('checkbox_1').checked == false && document.getElementById('checkbox_2').checked == false && document.getElementById('checkbox_3').checked == false && document.getElementById('checkbox_4').checked == false && document.getElementById('checkbox_5').checked == false && document.getElementById('checkbox_6').checked == false && document.getElementById('checkbox_7').checked == false) {
            alert("Please select at least one check box.")
            return false;
        }
        if (document.getElementById('checkbox_1').checked == true && document.getElementById('checkbox_2').checked == true && document.getElementById('checkbox_3').checked == true && document.getElementById('checkbox_4').checked == true && document.getElementById('checkbox_5').checked == true && document.getElementById('checkbox_6').checked == true && document.getElementById('checkbox_7').checked == true) {
            alert("Please Deselect at least one check box.")
            return false;
        }
        var arrdate = "";
        if (document.getElementById('checkbox_1').checked == false)
            dayflag.push("SUN");
        if (document.getElementById('checkbox_2').checked == false)
            dayflag.push("MON");
        if (document.getElementById('checkbox_3').checked == false)
            dayflag.push("TUE")
        if (document.getElementById('checkbox_4').checked == false)
            dayflag.push("WED")
        if (document.getElementById('checkbox_5').checked == false)
            dayflag.push("THU")
        if (document.getElementById('checkbox_6').checked == false)
            dayflag.push("FRI")
        if (document.getElementById('checkbox_7').checked == false)
            dayflag.push("SAT")

        //dayflag = ["SUN","SAT"];         
        for (var i = 0; i < parseInt(rowcount) - 1; i++) {
            var text_var = document.getElementById("Text" + i);
            var pkgname = document.getElementById("edit" + i).value;
            var pkgalias = document.getElementById('pkg_alias' + i);
            var insert = document.getElementById('ins' + i);
            var insg = "";
            if (browser != "Microsoft Internet Explorer") {
                insg = document.getElementById('ins' + i).textContent;
            }
            else {
                insg = document.getElementById('ins' + i).innerText;
            }
            if (document.getElementById("inssta" + i).value != "billed") {
                if (insertval != insg) {

                    for (i1 = 0; i1 < dayflag.length; i1++) {

                        if (insg == "1") {
                            var resdate = QBC.binddata(document.getElementById('hiddencompcode').value, firstinsert, "0", dayflag[i1], pkgname, "", "", "", "", "")
                            if (resdate.error != null) {
                                alert(resdate.error.description);
                            }
                            var dsresdate = resdate.value;
                            if (dsresdate.Tables[0].Rows[0].MSG == "FALSE") {
                                firstinsert = dsresdate.Tables[0].Rows[0].NEWDATE;
                                text_var.value = "";
                                i1 = (-1);
                            }
                            else {
                                if (i1 == (dayflag.length - 1)) {
                                    firstinsert = dsresdate.Tables[0].Rows[0].NEWDATE;
                                    text_var.value = dsresdate.Tables[0].Rows[0].NEWDATE;
                                    editid = "edit" + i;
                                    var pkgid = document.getElementById('hiddenpckcode' + i).value;
                                    var pkgalias = document.getElementById('pkg_alias' + i).value;
                                    var pkgname = document.getElementById(editid).value;
                                    pkgname = pkgname.replace("+", "^");
                                    var value = "1";
                                    var dateday = text_var.value;

                                    var strtext = "";
                                    var center = '0';
                                    center = document.getElementById('hiddencenter').value;
                                    if (browser != "Microsoft Internet Explorer") {
                                        var httpRequest = null; ;
                                        httpRequest = new XMLHttpRequest();
                                        if (httpRequest.overrideMimeType) {
                                            httpRequest.overrideMimeType('text/xml');
                                        }

                                        httpRequest.onreadystatechange = function () { alertContents(httpRequest) };
                                        var adcat = document.getElementById('drpadcategory').value;
                                        httpRequest.open("GET", "packagename.aspx?center=" + center + "&adtype=" + document.getElementById('hiddenadtype').value + "&pkgalias=" + pkgalias + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + value + "&dateday=" + dateday + "&pkgname=" + pkgname, false);
                                        httpRequest.send('');
                                        //alert(httpRequest.readyState);
                                        if (httpRequest.readyState == 4) {
                                            //alert(httpRequest.status);
                                            if (httpRequest.status == 200) {
                                                strtext = httpRequest.responseText;
                                            }
                                            else {
                                                alert('There was a problem with the request.');
                                            }
                                        }
                                    }
                                    else {
                                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                                        var adcat = document.getElementById('drpadcategory').value;
                                        xml.Open("GET", "packagename.aspx?center=" + center + "&adtype=" + document.getElementById('hiddenadtype').value + "&pkgalias=" + pkgalias + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + value + "&dateday=" + dateday + "&pkgname=" + pkgname, false);
                                        xml.Send();
                                        strtext = xml.responseText;
                                    }

                                    if (strtext == "0") {
                                        alert("Publication day doesnot match with day for Edition " + pkgname);
                                        document.getElementById(name).value = tempdate;

                                    }
                                    if (strtext != "1" && strtext != "0") {
                                        if (dateday != strtext) {
                                            alert(dateday + " is No Issue Day for  Edition " + pkgname);
                                            text_var.value = "";
                                        }
                                    }

                                }
                            }
                        }
                        else {
                            var resdate = QBC.binddata(document.getElementById('hiddencompcode').value, firstinsert, repatingdate, dayflag[i1], pkgname, "", "", "", "", "")
                            if (resdate.error != null) {
                                alert(resdate.error.description);
                            }
                            var dsresdate = resdate.value;
                            if (dsresdate.Tables[0].Rows[0].MSG == "FALSE") {
                                firstinsert = dsresdate.Tables[0].Rows[0].NEWDATE;
                                text_var.value = "";
                                i1 = (-1);
                            }
                            else {
                                if (i1 == (dayflag.length - 1)) {
                                    firstinsert = dsresdate.Tables[0].Rows[0].NEWDATE;
                                    text_var.value = dsresdate.Tables[0].Rows[0].NEWDATE;
                                    editid = "edit" + i;
                                    var pkgid = document.getElementById('hiddenpckcode' + i).value;
                                    var pkgalias = document.getElementById('pkg_alias' + i).value;
                                    var pkgname = document.getElementById(editid).value;
                                    pkgname = pkgname.replace("+", "^");
                                    var value = "1";
                                    var dateday = text_var.value;

                                    var strtext = "";
                                    var center = '0';
                                    center = document.getElementById('hiddencenter').value;
                                    if (browser != "Microsoft Internet Explorer") {
                                        var httpRequest = null; ;
                                        httpRequest = new XMLHttpRequest();
                                        if (httpRequest.overrideMimeType) {
                                            httpRequest.overrideMimeType('text/xml');
                                        }

                                        httpRequest.onreadystatechange = function () { alertContents(httpRequest) };
                                        var adcat = document.getElementById('drpadcategory').value;
                                        httpRequest.open("GET", "packagename.aspx?center=" + center + "&adtype=" + document.getElementById('hiddenadtype').value + "&pkgalias=" + pkgalias + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + value + "&dateday=" + dateday + "&pkgname=" + pkgname, false);
                                        httpRequest.send('');
                                        //alert(httpRequest.readyState);
                                        if (httpRequest.readyState == 4) {
                                            //alert(httpRequest.status);
                                            if (httpRequest.status == 200) {
                                                strtext = httpRequest.responseText;
                                            }
                                            else {
                                                alert('There was a problem with the request.');
                                            }
                                        }
                                    }
                                    else {
                                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                                        var adcat = document.getElementById('drpadcategory').value;
                                        xml.Open("GET", "packagename.aspx?center=" + center + "&adtype=" + document.getElementById('hiddenadtype').value + "&pkgalias=" + pkgalias + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + value + "&dateday=" + dateday + "&pkgname=" + pkgname, false);
                                        xml.Send();
                                        strtext = xml.responseText;
                                    }

                                    if (strtext == "0") {
                                        alert("Publication day doesnot match with day for Edition " + pkgname);
                                        document.getElementById(name).value = tempdate;

                                    }
                                    if (strtext != "1" && strtext != "0") {
                                        if (dateday != strtext) {
                                            alert(dateday + " is No Issue Day for  Edition " + pkgname);
                                            text_var.value = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    insertval = insg;
                }
                else {
                    text_var.value = firstinsert
                    editid = "edit" + i;
                    var pkgid = document.getElementById('hiddenpckcode' + i).value;
                    var pkgalias = document.getElementById('pkg_alias' + i).value;
                    var pkgname = document.getElementById(editid).value;
                    pkgname = pkgname.replace("+", "^");
                    var value = "1";
                    var dateday = text_var.value;

                    var strtext = "";
                    var center = '0';
                    center = document.getElementById('hiddencenter').value;
                    if (browser != "Microsoft Internet Explorer") {
                        var httpRequest = null; ;
                        httpRequest = new XMLHttpRequest();
                        if (httpRequest.overrideMimeType) {
                            httpRequest.overrideMimeType('text/xml');
                        }

                        httpRequest.onreadystatechange = function () { alertContents(httpRequest) };
                        var adcat = document.getElementById('drpadcategory').value;
                        httpRequest.open("GET", "packagename.aspx?center=" + center + "&adtype=" + document.getElementById('hiddenadtype').value + "&pkgalias=" + pkgalias + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + value + "&dateday=" + dateday + "&pkgname=" + pkgname, false);
                        httpRequest.send('');
                        //alert(httpRequest.readyState);
                        if (httpRequest.readyState == 4) {
                            //alert(httpRequest.status);
                            if (httpRequest.status == 200) {
                                strtext = httpRequest.responseText;
                            }
                            else {
                                alert('There was a problem with the request.');
                            }
                        }
                    }
                    else {
                        var xml = new ActiveXObject("Microsoft.XMLHTTP");
                        var adcat = document.getElementById('drpadcategory').value;
                        xml.Open("GET", "packagename.aspx?center=" + center + "&adtype=" + document.getElementById('hiddenadtype').value + "&pkgalias=" + pkgalias + "&adcat=" + adcat + "&pkgid=" + pkgid + "&compcode=" + compcode + "&value=" + value + "&dateday=" + dateday + "&pkgname=" + pkgname, false);
                        xml.Send();
                        strtext = xml.responseText;
                    }

                    if (strtext == "0") {
                        alert("Publication day doesnot match with day for Edition " + pkgname);
                        document.getElementById(name).value = tempdate;

                    }
                    if (strtext != "1" && strtext != "0") {
                        if (dateday != strtext) {
                            alert(dateday + " is No Issue Day for  Edition " + pkgname);
                            text_var.value = "";
                        }
                    }
                }
            }
        }
    }
    //document.getElementById('daysdiv4').innerHTML = "";
    document.getElementById('daysdiv4').style.display = "none";
   
}

///add by anuja
function EnterTab(evt, id) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 13) && (node.className != "btextlist") && ((node.type == "text") || (node.type == "select-one") || (node.type == "radio") || (node.type == "checkbox") || (node.type == "button"))) {

        getNextElement(node).focus();

        return false;
    }
}
function getNextElement(field) {
    var form = field.form;
    for (var e = 0; e < form.elements.length; e++) {
        if (field == form.elements[e]) {
            // toggleFocus(field);
            break;
        }
    }
    e++;
    while (form.elements[e % form.elements.length].type == undefined || form.elements[e % form.elements.length].type == "hidden" || form.elements[e % form.elements.length].disabled == true || form.elements[e % form.elements.length].readOnly == true) {
        e++;
    }
    //  
    return form.elements[e % form.elements.length];
}
