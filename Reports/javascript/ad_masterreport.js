

var bame = "";




function blankfields() {
//    if (document.getElementById("hdn_user_right").value != "8" && document.getElementById("hdn_user_right").value != "7") {
//        alert("You are not Authorized to see this form")
//        window.close();
//        return false;

//    }
//    else {

//        document.getElementById('txtcompcode').disabled = true;
//        document.getElementById('txtcompname').disabled = true;
//        document.getElementById('txtunit').disabled = true;
//        document.getElementById('txtunitname').disabled = true;
//        document.getElementById('txttodate').disabled = false;
//        document.getElementById('drpsorted').disabled = false;
    document.getElementById("txtunit").focus();

   // }
}




function bindtabvalue_log(event) {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtChannel") {
            compcode = document.getElementById('hiddencompcode').value;
            var activeid = document.activeElement.id;
            var ds_1 = Reports_ad_masterreport.BindCustomMaster(compcode, "channel", "");
            if (ds_1.value == null) {
                alert(ds_1.error.description);
                return false;
            }
            var listboxid = "lstchannel_log";
            var objchannel = document.getElementById(listboxid);
            var divid = "divchannel_log";
            objchannel.options.length = 0;
            // objprgtype.options[0]=new Option("--Select--","0");            
            //objprgtype.options.length = 1; 
            for (var i = 0; i < ds_1.value.Tables[0].Rows.length; ++i) {
                objchannel.options[objchannel.options.length] = new Option(ds_1.value.Tables[0].Rows[i].channel + "~" + ds_1.value.Tables[0].Rows[i].channel_name, ds_1.value.Tables[0].Rows[i].channel);
                objchannel.options.length;
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

            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(divid).style.top = document.getElementById("txtChannel").offsetHeight + toppos + "px";
            document.getElementById(divid).style.left = document.getElementById("txtChannel").offsetLeft + leftpos + "px";
            document.getElementById(listboxid).focus();
        }

    }
}
function bindtabvalue_fpc(event) {
    if (document.activeElement.id == "txtChannel") {
        if (event.keyCode == 113) {
            var extra1 = document.getElementById(document.activeElement.id).value;
            var compcode = document.getElementById('hiddencompcode').value;
            var activeid = document.activeElement.id;
            var ds_1 = Reports_ad_masterreport.BindCustomMaster(compcode, "channel", "", extra1, "", "", "", ""); //compcode,"channel","",extra1);
            if (ds_1.value == null) {
                alert(ds_1.error.description);
                return false;
            }
            var listboxid = "lstchannel_fpc";
            var objchannel = document.getElementById(listboxid);
            var divid = "divchannel_fpc";
            objchannel.options.length = 0;
            for (var i = 0; i < ds_1.value.Tables[0].Rows.length; ++i) {
                objchannel.options[objchannel.options.length] = new Option(ds_1.value.Tables[0].Rows[i].channel_name + "~" + ds_1.value.Tables[0].Rows[i].channel, ds_1.value.Tables[0].Rows[i].channel);
                objchannel.options.length;
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
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(divid).style.top = document.getElementById("txtChannel").offsetHeight + toppos + "px";
            document.getElementById(divid).style.left = document.getElementById("txtChannel").offsetLeft + leftpos + "px";
            document.getElementById(listboxid).focus();
        }
        else {
            if (event.keyCode == 8 || event.keyCode == 46) {
                $('txtChannel').value = "";
                $('hdnChannel').value = "";
                return true;
            }
            else if (event.ctrlKey == true && event.keyCode == 88) {
                $('txtChannel').value = "";
                $('hdnChannel').value = "";
                $('txtChannel').focus();
                return true;
            }
            else {
                $('hdnChannel').value = "";
                return event.keyCode;
            }
        }
    }
    if (document.activeElement.id == "txtReports") {
        if (event.keyCode == 113) {
            var extra1 = "2";
            var compcode = document.getElementById('hiddencompcode').value;
            var unit = document.getElementById('hiddenunit').value;
            var cha = document.getElementById('hdnChannel').value;
            var activeid = document.activeElement.id;
            var ds_1 = Reports_ad_masterreport.bindreport(compcode, unit, cha, extra1);
            if (ds_1.value == null) {
                alert(ds_1.error.description);
                return false;
            }
            var listboxid = "lstreport";
            var objreport = document.getElementById(listboxid);
            var divid = "divreport";
            objreport.options.length = 0;
            for (var i = 0; i < ds_1.value.Tables[0].Rows.length; ++i) {
                objreport.options[objreport.options.length] = new Option(ds_1.value.Tables[0].Rows[i].TABLE_DESC + "~" + ds_1.value.Tables[0].Rows[i].SEQ_NO, ds_1.value.Tables[0].Rows[i].TABLE_NAME);
                objreport.options.length;
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
            document.getElementById(activeid).style.backgroundColor = "#FFFF80";
            document.getElementById(divid).style.display = "block";
            document.getElementById(divid).style.top = document.getElementById("txtReports").offsetHeight + toppos + "px";
            document.getElementById(divid).style.left = document.getElementById("txtReports").offsetLeft + leftpos + "px";
            document.getElementById(listboxid).focus();
        }
        else {
            if (event.keyCode == 8 || event.keyCode == 46) {
                $('txtReports').value = "";
                $('hdnreport').value = "";
                return true;
            }
            else if (event.ctrlKey == true && event.keyCode == 88) {
                $('txtReports').value = "";
                $('hdnreport').value = "";
                $('txtReports').focus();
                return true;
            }
            else {
                $('hdnreport').value = "";
                return event.keyCode;
            }
        }
    }
}


function fillSelectedData_fpc() {
    if (document.activeElement.id == "lstreport") {
        document.getElementById("divreport").style.display = "none";
        var prgtype = document.getElementById('lstreport').value;
        if (prgtype != "") {
            var bame = document.getElementById('lstreport').options[document.getElementById('lstreport').selectedIndex].text; //value;
            document.getElementById('hdntablename').value = document.getElementById('lstreport').options[document.getElementById('lstreport').selectedIndex].value
            if (bame.indexOf("~") > 0) {
                document.getElementById('hdnreport').value = bame.split("~")[1];
                document.getElementById('txtReports').innerText = bame.split("~")[0];

            }
            else
                document.getElementById('txtReports').value = bame;

            document.getElementById('txtReports').style.backgroundColor = "white";
        }
        document.getElementById('txtReports').focus();
        bindlist();

        return false;
    }


    if (document.activeElement.id == "lstchannel_fpc") {
        document.getElementById("divchannel_fpc").style.display = "none";
        var prgtype = document.getElementById('lstchannel_fpc').value;
        if (prgtype != "") {
            var bame = document.getElementById('lstchannel_fpc').options[document.getElementById('lstchannel_fpc').selectedIndex].text; //value;
            if (bame.indexOf("~") > 0) {
                document.getElementById('hdnChannel').value = bame.split("~")[1];
                document.getElementById('txtChannel').innerText = bame.split("~")[0];
            }
            else
                document.getElementById('txtChannel').value = bame;

            document.getElementById('txtChannel').style.backgroundColor = "white";
        }
        document.getElementById('txtChannel').focus();
        return false;
    }
}

function bindlist() {
    var extra1 = document.getElementById(document.activeElement.id).value;
    var compcode = document.getElementById('hiddencompcode').value;
    var unit = document.getElementById('hiddenunitcode').value;
    var cha = document.getElementById('hiddenunitcode').value;
    var repo = document.getElementById('hdnreport').value;
    var activeid = document.activeElement.id;
    var ds_1 = Reports_ad_masterreport.bindlis(compcode, unit, cha, repo);
    if (ds_1.value == null) {
        alert(ds_1.error.description);
        return false;
    }
    var listboxid = "ListBox5";
    var objchannel1 = document.getElementById(listboxid);
    var divid = "div1";
    objchannel1.options.length = 0;
    var listboxid1 = "ListBox3";
    var objchannel = document.getElementById(listboxid1);
    var divid = "div3";
    objchannel.options.length = 0;
    for (var i = 0; i < ds_1.value.Tables[0].Rows.length; ++i) {
        objchannel.options[objchannel.options.length] = new Option(ds_1.value.Tables[0].Rows[i].COL_DES, ds_1.value.Tables[0].Rows[i].COL);
        objchannel.options.length;
        objchannel1.options[objchannel1.options.length] = new Option(ds_1.value.Tables[0].Rows[i].COL_DES, ds_1.value.Tables[0].Rows[i].COL);
        objchannel1.options.length;
    }
    var listboxid = "ListBox4";
    var objchannel = document.getElementById(listboxid);
    var divid = "div3";
    objchannel.options.length = 0;
    for (var i = 0; i < ds_1.value.Tables[1].Rows.length; ++i) {
        objchannel.options[objchannel.options.length] = new Option(ds_1.value.Tables[1].Rows[i].COL_DES, ds_1.value.Tables[1].Rows[i].COL + "~" + ds_1.value.Tables[1].Rows[i].DATA_TYPE);
        objchannel.options.length;
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
    document.getElementById(activeid).style.backgroundColor = "#FFFF80";
    document.getElementById(divid).style.display = "block";
    document.getElementById(divid).style.top = document.getElementById("ListBox3").offsetHeight + toppos + "px";
    document.getElementById(divid).style.left = document.getElementById("ListBox3").offsetLeft + leftpos + "px";
    //document.getElementById(drtype).focus();	

}
//  code for filter txtfrom   txtto
var filter_type = "";
var from_val = ""
var to_val = "";
var filter_val = "";
var filter_name = "";

function callfilterfield(id) {
    if (document.getElementById(id).selectedIndex == "-1") {
        document.getElementById(id).selectedIndex = "";
    }
    if (document.getElementById(id).options[document.getElementById(id).selectedIndex].text == "") {
        bame = "";
    }
    else {
        bame = document.getElementById(id).options[document.getElementById(id).selectedIndex].text;
    }
    //    var bame = document.getElementById(id).options[document.getElementById(id).selectedIndex].text;
    var value = document.getElementById(id).options[document.getElementById(id).selectedIndex].value.split("~")[0]
    filter_name = value
    filter_type = document.getElementById(id).options[document.getElementById(id).selectedIndex].value.split("~")[1]
}

function addfilter(id) {
    if (document.getElementById("txtfrom").value == "") {
        alert("Please Enter From Value.")
        document.getElementById("txtfrom").focus();
        return false;
    }
    var lab_fil = document.getElementById("lbl_filterval").innerHTML
    if (lab_fil.indexOf(filter_name + " ") >= 0) {
        alert(filter_name + " already added in filter")
        return false;
    }
    // fill here
    var col = document.getElementById('ListBox4').options[document.getElementById('ListBox4').selectedIndex].text;
    var comcode = document.getElementById('hiddencompcode').value;
    var tablename = document.getElementById('hdntablename').value;
    var res = Reports_ad_masterreport.getdatatype(comcode, col, tablename);
    var ds = res.value;
    if (ds.Tables[0].Rows[0].DATA_TYPE == "DATE") {
        var fr_v = senddatetopackage(document.getElementById("txtfrom").value, document.getElementById('hiddencompcode').value);
        var to_v = senddatetopackage(document.getElementById("txtto").value, document.getElementById('hiddencompcode').value);
    }
    else {
        var fr_v = document.getElementById("txtfrom").value;
        var to_v = document.getElementById("txtto").value;
    }
    
    //    if (filter_type == "D")
    //     {
    ////        fr_v = senddatetopackage(fr_v, document.getElementById("hiddendateformat").value)
    ////        if (to_v != "") 
    ////        {
    ////            to_v = senddatetopackage(to_v, document.getElementById("hiddendateformat").value)
    ////        }
    ////        filter_val = filter_name + "~" + fr_v + "~" + to_v + "`"


    if (fr_v == document.getElementById("hiddendateformat").value && to_v == document.getElementById("hiddendateformat").value) {
        fr_v = senddatetopackage(fr_v, document.getElementById("hiddendateformat").value)
        if (to_v != "") {
            to_v = senddatetopackage(to_v, document.getElementById("hiddendateformat").value)
        }
    }
    filter_val = filter_name + "~" + fr_v + "~" + to_v + "`"
    //    }
    //    else 
    //    {
    //        filter_val = filter_name + "~" + fr_v + "~" + to_v + "`"
    //    }

    make_query(filter_val)

    //  clear here
    document.getElementById("txtfrom").value = ""
    document.getElementById("txtto").value = ""
    filter_type = ""
    from_val = ""
    to_val = "";
    filter_val = ""
    return false;
}

function clearfilter(id) {
    if (confirm("Do you want to clear all filters")) {
        document.getElementById("lbl_filterval").innerHTML = "";
        document.getElementById("txtfrom").value = ""
        document.getElementById("txtto").value = ""
    }
    else
        return false;
    return false;

}

function make_query(val) {
    var lab_fil_val = document.getElementById("lbl_filterval").innerHTML
    var qyr = "";
    var arr_val = val.split("~");
    var field_name = arr_val[0]
    var from_val = arr_val[1]
    var to_val = arr_val[2].replace("`", "")
    var opr = ""
    if (to_val == "" || to_val == "`") {
        opr = " = ";
    }
    else {
        opr = " BETWEEN "
    }
    if (to_val == "" || to_val == "`") {
        qyr = field_name + " " + opr + " " + "'" + from_val + "'" + " AND ";
    }
    else {
        qyr = field_name + " " + opr + " " + "'" + from_val + "'" + " AND " + "'" + to_val + "'" + " AND ";
    }
    lab_fil_val = lab_fil_val.replace("`", " AND ");
    document.getElementById("lbl_filterval").innerHTML = lab_fil_val + " " + qyr;
    return false;
}
function addsortval(id) {
    if (document.getElementById(id).selectedIndex == "-1") {
        document.getElementById(id).selectedIndex = "";
    }
    if (document.getElementById(id).options[document.getElementById(id).selectedIndex].text == "") {
        bame = "";
    }
    else {
        bame = document.getElementById(id).options[document.getElementById(id).selectedIndex].text;
    }
    //var bame = document.getElementById(id).options[document.getElementById(id).selectedIndex].text;
    var value = document.getElementById(id).options[document.getElementById(id).selectedIndex].value.split("~")[0]
    if (document.getElementById("lbl_sort_val").innerHTML == "") {
        document.getElementById("lbl_sort_val").innerHTML = value
    }
    else {
        document.getElementById("lbl_sort_val").innerHTML = document.getElementById("lbl_sort_val").innerHTML + "," + value;
    }
    return false;
}
function clearsortval(id) {
    if (confirm("Do you want to clear all sort")) {
        document.getElementById("lbl_sort_val").innerHTML = "";
        return false;
    }
    else
        return false;
}
function chk_number(val, id) {
    var fld = val;
    var id = id
    if (fld != "") {
        if (fld.match(/^\d+(\.\d{2})?$/i)) {
            return true;
        }
        else {
            alert("Input error")
            document.getElementById(id).focus();
            document.getElementById(id).value = "";
            return false;
        }
    }

    return true;

}
function chkdate(val, dtform, input) {
    var dateformat = dtform
    if (dateformat == "mm/dd/yyyy") {
        var validformat = /^\d{2}\/\d{2}\/\d{4}$/
    }

    if (dateformat == "yyyy/mm/dd") {
        var validformat = /^\d{4}\/\d{2}\/\d{2}$/
    }

    if (dateformat == "dd/mm/yyyy") {
        var validformat = /^\d{2}\/\d{2}\/\d{4}$/
    }

    if (!validformat.test($(input).value)) {
        if ($(input).value == "")
            return true;

        //        // setTimeout(settime12,15);
        //        if (document.activeElement.id.indexOf('nand') < 0 && document.activeElement.id != '') 
        //        {
        //            alert(" Please Fill The Date In " + dateformat + " Format");
        //            input.value = "";
        //            inputid = document.activeElement.id;
        //            $(inputid).focus();
        //            return false;
        //        }
    }
    else { //Detailed check for valid date ranges
        if (dateformat == "yyyy/mm/dd") {
            var yearfield = $(input).value.split("/")[0]
            var monthfield = $(input).value.split("/")[1]
            var dayfield = $(input).value.split("/")[2]
            var dayobj = new Date(yearfield, monthfield - 1, dayfield)
        }
        if (dateformat == "mm/dd/yyyy") {
            var yearfield = $(input).value.split("/")[2]
            var monthfield = $(input).value.split("/")[0]
            var dayfield = $(input).value.split("/")[1]
            var dayobj = new Date(yearfield, monthfield - 1, dayfield)
        }

        if (dateformat == "dd/mm/yyyy") {
            var yearfield = $(input).value.split("/")[2]
            var monthfield = $(input).value.split("/")[1]
            var dayfield = $(input).value.split("/")[0]
            //var dayobj = new Date(dayfield, monthfield-1, yearfield)
            var dayobj = new Date(yearfield, monthfield - 1, dayfield)
        }
    } //end of else


    var abcd = dayobj.getMonth() + 1;
    var date1 = dayobj.getDate();
    var year1 = dayobj.getFullYear();
    if ((abcd != monthfield) || (date1 != dayfield) || (year1 != yearfield)) {
        alert(" Please Fill The Date In " + dateformat + " Format");
        $(input).value = "";
        return false;
    }
    return true
}
function chkvalidinput(id) {
    var res
    var dtformat = document.getElementById("hiddendateformat").value
    var value = document.getElementById(id).value

    if (filter_type == 'D') {
        res = chkdate(value, dtformat, id)
    }
    if (res == false) {
        document.getElementById(id).value = "";
        document.getElementById(id).focus();
        return false;
    }

    if (filter_type == 'N') {
        res = chk_number(value, id)
    }
    if (res == false) {
        document.getElementById(id).value = "";
        document.getElementById(id).focus();
        return false;
    }
    return false;

}
function exit(id) {
    if (confirm("Do you want to skip this page")) {
        window.close();
    }
}
function submitvalue(id) {
    var compcode = document.getElementById("hiddencompcode").value
    var userid = document.getElementById("hiddenuserid").value
    var punit = document.getElementById("hiddenunitcode").value
    var destination = document.getElementById('drtype').value;
    var pchannel = document.getElementById("hiddenunitcode").value;
    var pchannel_name = document.getElementById("txtunit").value;
    var preport_name = document.getElementById("txtReports").value;
    var ptseq_no = document.getElementById("hdnreport").value
    var ptable_name = document.getElementById("hdntablename").value
    var ptable_filter = document.getElementById("lbl_filterval").innerText
    ptable_filter = ptable_filter.substring(0, ptable_filter.length - 4);
    var porder = document.getElementById("lbl_sort_val").innerText
    if (porder == "")
        porder = "1";
    if (ptable_filter == "")
        ptable_filter = "1=1"
    var ptable_col = "";
    var colname = "";

    for (var x = 0; x < document.getElementById("ListBox3").options.length; x++) {
        if (document.getElementById("ListBox3").options[x].selected == true) {
            colname = document.getElementById("ListBox3").options[x].value;
            if (ptable_col == "") {
                ptable_col = colname;
            }
            else {
                ptable_col = ptable_col + "," + colname;
            }
            colname = "";
        }

    }
    if (ptable_col == "") {
        alert("Please select atleast one coloumn for view.")
        document.getElementById("ListBox3").focus();
        return false;
    }
    var ext2 = "";
    var ext3 = "";
    var ext4 = "";
    var ext5 = "";
    var ext6 = "";
    var ext7 = "";
    var ext8 = "";
    var ext9 = "";
    var ext10 = "";
    window.open("ad_master_runreport.aspx?Destination=" + destination + "&Channel=" + pchannel + "&channel_name=" + pchannel_name + "&report_name=" + preport_name + "&seq_no=" + ptseq_no + "&table_name=" + ptable_name + "&table_col=" + ptable_col + "&table_filter=" + ptable_filter + "&Order=" + porder + "&ext2=" + ext2 + "&ext3=" + ext3 + "&ext4=" + ext4 + "&ext5=" + ext5 + "&ext6=" + ext6 + "&ext7=" + ext7 + "&ext8=" + ext8 + "&ext9=" + ext9 + "&ext10=" + ext10);

    return false;
}
function senddatetopackage(val, dtformat) {

    if (val != "" && val != "null") {
        if (dtformat == "dd/mm/yyyy") {
            var tmpdata = val.split("/")
            val = tmpdata[1] + "/" + tmpdata[0] + "/" + tmpdata[2]
        }
        else if (dtformat == "yyyy/mm/dd") {
            var tmpdata = val.split("/")
            val = tmpdata[1] + "/" + tmpdata[2] + "/" + tmpdata[0]
        }
    }
    //    if ($('deltblfields').value == "orcl") 
    //    {
    var m_names = new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
    var dt = new Date(val);
    var curr_date = dt.getDate();
    var curr_month = dt.getMonth();
    var curr_year = dt.getFullYear();
    curr_month = m_names[curr_month]
    val = curr_date + "-" + curr_month + "-" + curr_year;
    //    }
    return val;
}


function chkfield(a) {
    if (a.keyCode == "13") {
        if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "txtunit") {
            if ($('txtunit').value == "" || $('txtunit').value != "") {
                if (a.keyCode == "13") {

                    if ($('txtunit').value == "") {
                        alert('Please select Unit Name');
                        $('txtunit').focus();
                        return false;
                    }
                    else {
                        $('txtReports').focus();
                        return false;
                    }
                }
            }
        }

        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "txtReports") {
            if ($('txtReports').value == "" || $('txtReports').value != "") {
                if (a.keyCode == "13") {

                    if ($('txtReports').value == "") {
                        alert('Please select Report Name');
                        $('txtReports').focus();
                        return false;
                    }
                    else {
                        $('drtype').focus();
                        return false;
                    }
                }
            }
        }

        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "drtype") {

            if (a.keyCode == "13") {
                $('ListBox3').focus();
                return false;
            }

        }

        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "ListBox3") {

            if (a.keyCode == "13") {
                $('ListBox4').focus();
                return false;
            }

        }
        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "ListBox4") {

            if (a.keyCode == "13") {
                $('txtfrom').focus();
                return false;
            }

        }
        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "txtfrom") {
            if ($('txtfrom').value == "") {
                alert("Please Enter From Value.");
                $('txtfrom').focus();
                return false;
            }
            else {
                $('txtto').focus();
                return false;
            }
        }
        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "txtto") {
            if (a.keyCode == "13") {
                $('btnadd').focus();
                return false;
            }
        }
        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "btnadd") {

            if (a.keyCode == "13") {
                $('lbl_filterval').focus();
                return false;
            }

        }
        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "lbl_filterval") {

            if (a.keyCode == "13") {
                $('ListBox5').focus();
                return false;
            }

        }
        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "ListBox5") {

            if (a.keyCode == "13") {
                $('btnaddsort').focus();
                return false;
            }

        }
        else if ((a.keyCode == "13" || a.keycode == "9") && document.activeElement.id == "btnaddsort") {

            if (a.keyCode == "13") {
                $('lbl_sort_val').focus();
                return false;
            }

        }
        else if (document.activeElement.id == "lbl_sort_val") {
            if (a.keyCode == "13") {

                $('btnsubmit').focus();
                return false;
            }
        }


        else if (document.activeElement.id == "btnsubmit") {
            if (a.keyCode == "13") {
                submitvalue();
                return false;
            }
        }

    }

}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function fillunit() {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtunit") {

            $('lstunit').value = "";
            var compcode = $('hiddencompcode').value;
            $("divunit").style.display = "block";
            $('divunit').style.top = 90 + "px";
            $('divunit').style.left = 90 + "px";
            //  var hiddendateformat = $('dateformat').value;
            var companycode = $('hiddencompcode').value;
            var unit = $('hiddenunit').value;
            extra1 = $('txtunit').value;
            $('lstunit').focus();
            Reports_ad_masterreport.fill_unit(extra1, bindpub_callback)
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
        $('txtunit').value = "";
        $('hiddenunitcode').value = "";
        xyz = "";
        //$('txteditionname').value="";
        return true;
    }

    else if (event.ctrlKey == true && event.keyCode == 88) {
        $('txtunit').value = "";
        $('hiddenunitcode').value = "";
        xyz = "";
        // $('txtpublcode').focus();
        return true;
    }
}


function onclickunit() {
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstunit") {
            if ($('lstunit').value == "0") {
                // alert("Please select the publication");
                return false;
            }
            $("divunit").style.display = "none";
            var page = $('lstunit').value;
            agencycodeglo = page;
            for (var k = 0; k <= $("lstunit").length - 1; k++) {
                if ($('lstunit').options[k].value == page) {
                    var abc = $('lstunit').options[k].innerText;
                    $('txtunit').value = agencycodeglo;
                    var splitpub = abc;
                    var str = splitpub.split("-");
                    abc = str[1];
                    xyz = str[0];
                    var abc2 = str[2];
                    $('txtunit').value = abc;
                    $('txtunitcode').value = xyz;
                    //$('txtagencysubcode').value = abc2;
                    // $('hdnpubcode').value=abc1;
                    $('txtpublication').focus();
                    return false;
                }
            }
        }
    }

    else if (event.keyCode == 27) {
        $("divunit").style.display = "none";
        $('txtunit').focus();
    }
}

function bindpub_callback(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = $("lstunit");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Unit-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Pub_cent_Code + "-" + ds.Tables[0].Rows[i].center + "-" + ds.Tables[0].Rows[i].Pub_cent_Code, ds.Tables[0].Rows[i].Pub_cent_Code);
            pkgitem.options.length;
        }
    }
    $("lstunit").value = "0";
    $('hiddenunitcode').value = "";
    $("txtunit").value = "";
    return false;
}


function onclickunit() {
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstunit") {
            if ($('lstunit').value == "0") {
                // alert("Please select the publication");
                return false;
            }
            $("divunit").style.display = "none";
            var page = $('lstunit').value;
            agencycodeglo = page;
            for (var k = 0; k <= $("lstunit").length - 1; k++) {
                if ($('lstunit').options[k].value == page) {
                    var abc = $('lstunit').options[k].innerText;
                    $('txtunit').value = agencycodeglo;
                    var splitpub = abc;
                    var str = splitpub.split("-");
                    abc = str[1];
                    xyz = str[0];
                    var abc2 = str[2];
                    $('txtunit').value = abc;
                    $('hiddenunitcode').value = xyz;
                    //$('txtagencysubcode').value = abc2;
                    // $('hdnpubcode').value=abc1;
                    $('txtunit').focus();
                    return false;
                }
            }
        }
    }

    else if (event.keyCode == 27) {
        $("divunit").style.display = "none";
        $('txtunit').focus();
    }
}


