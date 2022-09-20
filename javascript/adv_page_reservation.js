var jq = jQuery.noConflict();
var browser = navigator.appName;

var Total_Records = 0;
var dsmain = "";
var dsmain_hdr = "";
var next = 0;
var count = 0;
var Flag = "";
window.onload = function () {
    OnClickClear();
    return false;
}
function Change(obj, evt) {
    if (evt.type == "mouseover")
        obj.style.backgroundColor = "#afc7ed";
    else if (evt.type == "mouseout")
        obj.style.backgroundColor = "#f6f2dc";
}
function check_mendetory(id) {
    var label_text = jq('#' + id).text();
    return label_text;
}
function fndnull(val) {
    if (val == null || val == undefined || val == "undefined")
        val = ""
    return val
}
function OnClickClear() {
    Total_Records = 0, dsmain = "", dsmain_hdr = "", next = 0, Flag = 0;
    jq('#btnNew,#btnQuery,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnSave,#btnModify,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();
    jq("#txtrcode,#txtcreatedby,#txtschdate,#txtw,#txth,#txtclient,#drppageprem,#drppubl,#drpedtn,#drpstatus").attr('disabled', true);
    jq("#txtrcode,#txtcreatedby,#txtschdate,#txtw,#txth,#txtclient,#drppageprem,#drppubl,#drpedtn,#txtremark,#drpstatus").val("");
    jq("#drppageprem").val("0");
    jq("#drpstatus").val("O");
    jq("#txtcreatedby").val(jq("#hdnusernm").val());
   
    fundrppubl();
    document.getElementById("mailallcengpchk_0").checked = false;
    disable_enable("D");
    if (document.getElementById('hdnmode').value == "EXEC") {
        OnClickExecute();
    }
   
    jq('#btnNew').focus();
    return false;
}
function ststuschange() {
    if (document.getElementById('drpstatus').value == "C") {
        document.getElementById('txtremark').disabled = false;
    }
    else {
        document.getElementById('txtremark').disabled = false;
        document.getElementById('txtremark').value = "";
    }
    return false;
}
function OnClickQuery() {
    Flag = "E";
    jq('#btnExecute,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnNew,#btnSave,#btnModify,#btnQuery,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();

    jq("#txtrcode,#txtschdate,#txtw,#txth,#txtclient,#drppageprem,#drppubl,#drpedtn,#drpstatus").attr('disabled', false);
    jq("#drpflag").val("A")
    disable_enable("D");
    jq('#txtschdate').focus();
    return false;
}
function OnClickNew() {
    OnClickClear();
    Flag = "I";
    jq('#btnSave,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnNew,#btnModify,#btnQuery,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();

    jq("#txtschdate,#txtw,#txth,#txtclient,#drppageprem,#drppubl,#drpedtn,#drpstatus").attr('disabled', false);
    jq("#drpflag").val("A")
    disable_enable("E");
    jq('#txtschdate').focus();
    return false;
}
var dsmain_hdr = "";
function OnClickExecute() {
    try {
        /*------------------EXECUTE DATA-------------------------------*/

        var P_COMP_CODE = jq("#hiddencompcode").val();
        var P_UNIT_CODE = jq("#hdncenter").val();
        var P_BRAN_CODE = jq("#hdnbrancd").val();
        var P_TRN_ID = "";
        if (document.getElementById('hdnmode').value == "EXEC") {
            P_TRN_ID = document.getElementById('hdntrnid').value;
        }
        else {
            P_TRN_ID = document.getElementById('txtrcode').value;
        }
        var str = document.getElementById('drppubl').value;

        var length = document.getElementById('drppubl').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drppubl').options[li].selected == true) {
                if (document.getElementById('drppubl').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drppubl').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drppubl').options[li].value;
                }

            }
        }
        var P_PUBLICATION = abc;
        var P_PRINTING_CENTER = "";
        var abc2 = "";
        for (var s2 = 0; s2 < count; s2++) {
            var s3 = parseInt(s2) + 1;
            var lentt = document.getElementById("hdnlenval_" + s3).value;
            for (var s1 = 0; s1 < lentt ; s1++) {
                if (document.getElementById('mailbrachk_' + s3 + s1).checked == true) {
                    if (abc2 == "") {
                        abc2 = document.getElementById('hdnbranch_' + s3 + s1).value;
                    }
                    else {
                        abc2 = abc2 + "," + document.getElementById('hdnbranch_' + s3 + s1).value;
                    }
                }
            }


        }
        P_PRINTING_CENTER = abc2;
        var P_CLIENT_NAME = jq("#hdnclientcode").val();
        var P_PAGE_POSITION = jq("#drppageprem").val();
        var P_AD_HEIGHT = jq("#txth").val();
        var P_AD_WEIDTH = jq("#txtw").val();
        var P_INSERT_DATE = jq("#txtschdate").val();
        if (P_INSERT_DATE != "") {
            var dd = P_INSERT_DATE.split("/")[0];
            var mm = P_INSERT_DATE.split("/")[1];
            var yy = P_INSERT_DATE.split("/")[2];
            P_INSERT_DATE = yy + "/" + mm + "/" + dd;
        }
        var P_USERID = jq("#hdnuserid").val();
        var P_IUD = Flag;
        var P_DATE_FORMAT = jq("#hiddendateformat").val();
        var P_EXTRA1 = "";
        var P_EXTRA2 = "";
        var P_EXTRA3 = "";
        var P_EXTRA4 = "";
        var P_EXTRA5 = "";
        var p_edtn = "";
        var p_remark = jq("#txtremark").val();
        var p_status = jq("#drpstatus").val();
        var str1 = document.getElementById('drpedtn').value;

        var length1 = document.getElementById('drpedtn').options.length;
        var abc1 = "";
        for (var li1 = 0; li1 < length1; li1++) {

            if (document.getElementById('drpedtn').options[li1].selected == true) {
                if (document.getElementById('drpedtn').options[li1].value != "") {
                    if (abc1 == "")
                        abc1 = document.getElementById('drpedtn').options[li1].value;
                    else
                        abc1 = abc1 + "," + document.getElementById('drpedtn').options[li1].value;
                }

            }
        }
        p_edtn = abc1;
        var parameterValueArray = [P_COMP_CODE, P_UNIT_CODE, P_BRAN_CODE, P_TRN_ID, P_PUBLICATION, p_edtn, P_PRINTING_CENTER, P_CLIENT_NAME, P_PAGE_POSITION, P_AD_HEIGHT, P_AD_WEIDTH, P_INSERT_DATE, P_USERID, P_IUD,
                                   P_DATE_FORMAT, p_status, p_remark, P_EXTRA1, P_EXTRA2, P_EXTRA3, P_EXTRA4, P_EXTRA5]
        var result = ADV_Page_Reservation.AD_RESERVE_DTL_IUD(parameterValueArray);
        dsmain_hdr = result.value;
        /*------------------EXECUTE DATA-------------------------------*/
        if (dsmain_hdr.Tables[0].Rows.length == 0) {
            alert('There is no data accourding your search');
            OnClickClear();
            return false;
        }
        else {
            next = 0;
            total_records = dsmain_hdr.Tables[0].Rows.length;
            jq('#btnModify,#btnCancel,#btnDelete,#btnExit').attr('disabled', false);
            jq('#btnNew,#btnSave,#btnQuery,#btnExecute,#btnfirst,#btnprevious').attr('disabled', true);
            if (dsmain_hdr.Tables[0].Rows.length == 1) {
                jq('#btnnext,#btnlast').attr('disabled', true);
            }
            else if (dsmain_hdr.Tables[0].Rows.length > 1) {
                jq('#btnnext,#btnlast').attr('disabled', false);
            }

            jq("#txtrcode,#txtcreatedby,#txtschdate,#txtw,#txth,#txtclient,#drppageprem,#drppubl,#drpedtn,#drpstatus").attr('disabled', true);
            BindHaderData();
            return false;
        }
    }
    catch (Ex) {
        alert(Ex);
        return false;
    }
    return false;
}
function OnClickModify() {
    Flag = "U";
    jq('#btnSave,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnNew,#btnModify,#btnQuery,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();

    jq("#txtschdate,#txtw,#txth,#txtclient,#drppageprem,#drppubl,#drpedtn,#drpstatus").attr('disabled', false);
    disable_enable("E");
    jq('#txtunitname').focus();
    return false;
}
function BindHaderData() {
    document.getElementById('txtrcode').value = fndnull(dsmain_hdr.Tables[0].Rows[next].TRN_ID);
    document.getElementById('txtcreatedby').value = fndnull(dsmain_hdr.Tables[0].Rows[next].USERID);
    document.getElementById('txtschdate').value = fndnull(dsmain_hdr.Tables[0].Rows[next].INSERT_DATE);
    document.getElementById('txtw').value = fndnull(dsmain_hdr.Tables[0].Rows[next].AD_WEIDTH);
    document.getElementById('txth').value = fndnull(dsmain_hdr.Tables[0].Rows[next].AD_HEIGHT);
    document.getElementById('txtclient').value = fndnull(dsmain_hdr.Tables[0].Rows[next].CLIENT_NAME_val);
    document.getElementById('hdnclientcode').value = fndnull(dsmain_hdr.Tables[0].Rows[next].CLIENT_NAME);
    document.getElementById('drppageprem').value = fndnull(dsmain_hdr.Tables[0].Rows[next].PAGE_POSITION);
    document.getElementById('drpstatus').value = fndnull(dsmain_hdr.Tables[0].Rows[next].CANCEL_STATUS);
    //document.getElementById('txtremark').value = fndnull(dsmain_hdr.Tables[0].Rows[next].P_REMARK);
    document.getElementById('txtremark').value = fndnull(dsmain_hdr.Tables[0].Rows[next].CANCEL_REMARK);

    var edtn = fndnull(dsmain_hdr.Tables[0].Rows[next].EDITION);



    // jq('#drppubl').val(fndnull(dsmain_hdr.Tables[0].Rows[next].FREEZE_FLAG));

    // jq('#drpedtn').val(fndnull(dsmain_hdr.Tables[0].Rows[next].TRN_ID));
    setButtonImages();
    return false;
}
function OnClickNext() {
    next = parseInt(next) + 1;
    jq('#btnprevious').attr('disabled', false);
    jq('#btnfirst').attr('disabled', false);
    if (next == total_records - 1) {
        jq('#btnnext').attr('disabled', true);
        jq('#btnlast').attr('disabled', true);
        jq('#btnprevious').attr('disabled', false);
        jq('#btnfirst').attr('disabled', false);
        jq('#btnprevious').focus();
    }
    BindHaderData();
    return false;
}
function OnClickPrevious() {
    next = parseInt(next) - 1;
    jq('#btnnext').attr('disabled', false);
    jq('#btnlast').attr('disabled', false);
    if (next == 0) {
        jq('#btnprevious').attr('disabled', true);
        jq('#btnnext').attr('disabled', false);
        jq('#btnfirst').attr('disabled', true);
        jq('#btnlast').attr('disabled', false);
        jq('#btnnext').focus();
    }
    BindHaderData();
    return false;
}
function OnClickLast() {
    next = total_records - 1;
    jq('#btnprevious').attr('disabled', false);
    jq('#btnnext').attr('disabled', true);
    jq('#btnfirst').attr('disabled', false);
    jq('#btnlast').attr('disabled', true);
    jq('#btnprevious').focus();
    BindHaderData();
    return false;
}
function OnClickFirst() {
    next = 0;
    jq('#btnnext').attr('disabled', false);
    jq('#btnlast').attr('disabled', false);
    jq('#btnprevious').attr('disabled', true);
    jq('#btnfirst').attr('disabled', true);
    jq('#btnnext').focus();
    BindHaderData();
    return false;
}
function fundrppubl() {
    var a = "";
    if (document.getElementById('divmail').innerText == "") {
        var re = ADV_Page_Reservation.pub_centbind();
        var str = "<table  border=0><tr><td><table   class=\"dtGridHd121\"><tr >"
        str = str + "<tr style=\"font-size:12px;  \"><td style=\"width: 15%;\">Center Group<input type=checkbox onclick=\"checkgpbranchselect('" + "ALL" + "','" + re.value.Tables[0].Rows.length + "','" + 0 + "');\" style=\"width: 10%;\" id=mailallcengpchk_0" + " /></td><td style=\"width: 85%;\">Center</td></tr>";
        var centergp = "";
        var centercd = "";
        var centernm = "";
        var i1 = 0;
        var k = 0;
        count = 0;
        centercd = re.value.Tables[0].Rows[0].Pub_cent_Code;
        centernm = re.value.Tables[0].Rows[0].CENTER;
        var str1 = "";
        var j = 0;
        var j1 = 0;
        var j2 = 0;
        str += "<tr>";
        for (var i = 0; i < re.value.Tables[0].Rows.length; i) {
            if (centergp == re.value.Tables[0].Rows[i].CENTER_GROUP_CODE) {
                str1 += "<td>";
                j1 = count;
                j2 = 0;
                while (i1 < re.value.Tables[0].Rows.length && centergp == re.value.Tables[0].Rows[i].CENTER_GROUP_CODE) {
                    if (centercd != re.value.Tables[0].Rows[i].Pub_cent_Code) {
                        str1 += "<input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:10%; text-transform: uppercase;'  id=txtbranchname_" + j1 + j2 + " value = '" + re.value.Tables[0].Rows[i].CENTER + "' disabled><input type='hidden' id=hdnbranch_" + j1 + j2 + " value = '" + re.value.Tables[0].Rows[i].Pub_cent_Code + "'><input type=checkbox id=mailbrachk_" + j1 + j2 + " />"
                        centergp = re.value.Tables[0].Rows[i].CENTER_GROUP_CODE;
                        i1 = parseInt(i1) + 1;
                        j = parseInt(j) + 1;
                        centercd = re.value.Tables[0].Rows[i].Pub_cent_Code;
                        j2++;

                    }
                    else {
                        str1 += "<input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:10%; text-transform: uppercase;'  id=txtbranchname_" + j1 + j2 + " value = '" + re.value.Tables[0].Rows[i].CENTER + "' disabled><input type='hidden' id=hdnbranch_" + j1 + j2 + " value = '" + re.value.Tables[0].Rows[i].Pub_cent_Code + "'><input type=checkbox id=mailbrachk_" + j1 + j2 + " />"
                        centergp = re.value.Tables[0].Rows[i].CENTER_GROUP_CODE;
                        i1 = parseInt(i1) + 1;
                        j = parseInt(j) + 1;
                        centercd = re.value.Tables[0].Rows[i].Pub_cent_Code;
                        j2++;
                    }
                    i++;
                    if (i == re.value.Tables[0].Rows.length) {
                        break;
                    }
                }
                str1 += "<input type='hidden' id=hdnlenval_" + count + " value = '" + j2 + "'></td>";
            }
            else {
                if (i != 0) {
                    str += str1;
                    str += "</tr>";
                    str1 = "";

                }
                centercd = re.value.Tables[0].Rows[i].Pub_cent_Code;
                centernm = re.value.Tables[0].Rows[i].CENTER;
                centergp = re.value.Tables[0].Rows[i].CENTER_GROUP_CODE;
                str += "<tr>";
                str += "<td><input type = 'text' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:70%; text-transform: uppercase;'  id=txtcentergpname_" + count + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_NAME + "' disabled><input type='hidden' id=hdncentergp_" + count + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "'><input type=checkbox onclick=\"checkgpbranchselect('" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "','" + re.value.Tables[0].Rows.length + "','" + count + "');\" style=\"width: 10%;\" id=mailcengpchk_" + count + " /></td>";
                count++;
                j1 = count;
            }
        }
        str1 = "";
        str1 += "<td>";
        j1 = count;
        j2 = 0;
        j2 = 0;
        var j3 = parseInt(re.value.Tables[0].Rows.length) - 1;
        str1 += "<input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:10%; text-transform: uppercase;'  id=txtbranchname_" + j1 + j2 + " value = '" + re.value.Tables[0].Rows[j3].CENTER + "' disabled><input type='hidden' id=hdnbranch_" + j1 + j2 + " value = '" + re.value.Tables[0].Rows[j3].Pub_cent_Code + "'><input type=checkbox id=mailbrachk_" + j1 + j2 + " />"
        i1 = parseInt(i1) + 1;
        j = parseInt(j) + 1;
        j2++;
        str1 += "<input type='hidden' id=hdnlenval_" + count + " value = '" + j2 + "'></td>";
        str += str1;
        str += "</tr>";
        str += "</table>"
        document.getElementById('divmail').innerHTML = str;
        document.getElementById('divmail').style.display = "block";
        aTag = eval(document.getElementById("drppubl"))
        var btag;
        var leftpos = 350;
        var toppos = 370;
        document.getElementById('divmail').style.top = toppos + "px";
        document.getElementById('divmail').style.left = leftpos + "px";
    }
    else {
        document.getElementById('divmail').style.display = "block";
    }
    return false;
}

function checkgpbranchselect(val, i, k) {
    if (val != "ALL") {
        for (var j = 0; j < i; ++j) {
            if (document.getElementById("mailcengpchk_" + k).checked == true) {
                if (document.getElementById("hdncentergp_" + j) != null && document.getElementById("hdncentergp_" + j).value == val) {
                    //document.getElementById("mailcenchk" + j).checked = true;
                    var s4 = parseInt(j) + 1;
                    var k1 = parseInt(k) + 1;
                    var lentt = document.getElementById("hdnlenval_" + s4).value;
                    if (lentt > 0) {
                        for (var s1 = 0; s1 < lentt ; s1++) {
                            document.getElementById('mailbrachk_' + k1 + s1).checked = true;

                        }
                    }
                }
            }
            else {
                if (document.getElementById("hdncentergp_" + j) != null && document.getElementById("hdncentergp_" + j).value == val) {
                    // document.getElementById("mailcenchk" + j).checked = false;

                    var s4 = parseInt(j) + 1;
                    var k1 = parseInt(k) + 1;
                    var lentt = document.getElementById("hdnlenval_" + s4).value;
                    if (lentt > 0) {
                        for (var s1 = 0; s1 < lentt ; s1++) {
                            document.getElementById('mailbrachk_' + k1 + s1).checked = false;

                        }
                    }
                }
            }

        }
    }
    else {
        for (var s2 = 0; s2 < count; s2++) {
            var s3 = parseInt(s2) + 1;
            var lentt = document.getElementById("hdnlenval_" + s3).value;
            if (document.getElementById("mailallcengpchk_0").checked == true) {
                document.getElementById("mailcengpchk_" + s2).checked = true;
                for (var s1 = 0; s1 < lentt ; s1++) {
                    document.getElementById('mailbrachk_' + s3 + s1).checked = true;
                }



            }
            else {
                document.getElementById("mailcengpchk_" + s2).checked = false;
                for (var s1 = 0; s1 < lentt ; s1++) {
                    document.getElementById('mailbrachk_' + s3 + s1).checked = false;
                }
            }

        }
    }
}
function disable_enable(val) {
    var t_valle = val;
    if (t_valle == "E") {
        for (var s2 = 0; s2 < count; s2++) {
            var s3 = parseInt(s2) + 1;
            var lentt = document.getElementById("hdnlenval_" + s3).value;
            document.getElementById("mailallcengpchk_0").checked = false;
            document.getElementById("mailallcengpchk_0").disabled = false;
            document.getElementById("mailcengpchk_" + s2).checked = false;
            document.getElementById("mailcengpchk_" + s2).disabled = false;
            for (var s1 = 0; s1 < lentt ; s1++) {
                document.getElementById('mailbrachk_' + s3 + s1).checked = false;
                document.getElementById('mailbrachk_' + s3 + s1).disabled = false;
            }


        }
    }
    else {

        for (var s2 = 0; s2 < count; s2++) {
            var s3 = parseInt(s2) + 1;
            var lentt = document.getElementById("hdnlenval_" + s3).value;
            document.getElementById("mailallcengpchk_0").checked = false;
            document.getElementById("mailallcengpchk_0").disabled = true;
            document.getElementById("mailcengpchk_" + s2).checked = false;
            document.getElementById("mailcengpchk_" + s2).disabled = true;
            for (var s1 = 0; s1 < lentt ; s1++) {
                document.getElementById('mailbrachk_' + s3 + s1).checked = false;
                document.getElementById('mailbrachk_' + s3 + s1).disabled = true;
            }


        }
    }
}
var mailsavestring = "";
var mailsendstr = "";
function divokclick1(i1, j1) {
    document.getElementById('divmail').style.display = "none";
    mailsavestr = "";
    mailsendstr = "";
    for (var i = 0; i < i1; ++i) {
        ///var re1 = ADV_Page_Reservation.branchbind(document.getElementById("hdncenter_" + i).value,document.getElementById('txtciobookid').value);
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
function fundrppubl3() {
    var a = "";
    if (browser != "Microsoft Internet Explorer") {
        a = document.getElementById('divmail').innerHTML;
    }
    else {
        a = document.getElementById('divmail').innerText;
    }
    if (document.getElementById('divmail').innerText == "") {
        // if (a == "") {
        var re = ADV_Page_Reservation.pub_centbind();
        var str = "<table  border=1><tr><td><table  style='background-color: #ffffff;' class=\"dtGridHd121\"><tr bgcolor=\"#7DAAF3\">"
        str = str + "<tr style=\"font-size:12px;  \"><td style=\"width: 30%;\">Group</td><td style=\"width: 70%;\">Center</td>";
        var centergp = "";
        var centercd = "";
        var centernm = "";
        var i1 = 0;
        var k = 0;
        for (var i = 0; i < re.value.Tables[0].Rows.length; i) {
            str += "<tr>";
            centercd = re.value.Tables[0].Rows[i].Pub_cent_Code;
            centernm = re.value.Tables[0].Rows[i].CENTER;
            //var re1 = ADV_Page_Reservation.branchbind(re.value.Tables[0].Rows[i].Pub_cent_Code,document.getElementById('txtciobookid').value);
            if (centergp == re.value.Tables[0].Rows[i].CENTER_GROUP_NAME) {
                str += "<td></td><td style='display:none;'><input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:70%; text-transform: uppercase;'  id=txtcentergpname" + i + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_NAME + "' disabled><input type='hidden' id=hdncentergp_" + i + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "'><input type=checkbox onclick=\"checkgpbranchselect('" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "','" + re.value.Tables[0].Rows.length + "','" + i + "');\" style=\"width: 10%;\" id=mailcengpchk" + i + " /></td>";
            }
            else {
                centergp = re.value.Tables[0].Rows[i].CENTER_GROUP_NAME;
                str += "<td><input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:70%; text-transform: uppercase;'  id=txtcentergpname" + i + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_NAME + "' disabled><input type='hidden' id=hdncentergp_" + i + " value = '" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "'><input type=checkbox onclick=\"checkgpbranchselect('" + re.value.Tables[0].Rows[i].CENTER_GROUP_CODE + "','" + re.value.Tables[0].Rows.length + "','" + i + "');\" style=\"width: 10%;\" id=mailcengpchk" + i + " /></td>";
            }

            var str1 = "<td>";
            //for (var j = 0; j < re1.value.Tables[0].Rows.length; ++j) {
            var j = 0;
            while (i1 < re.value.Tables[0].Rows.length && centercd == re.value.Tables[0].Rows[i1].Pub_cent_Code) {
                // str1 += "<input type = 'text' class='dtGridHd121' style='font-size:small;font-family:Trebuchet MS;color:black;cursor:pointer;vertical-align:top; padding-right:2px; text-align:left;width:18%; text-transform: uppercase;'  id=txtbranchname" + i + j + " value = '" + re.value.Tables[0].Rows[i].BRANCH_NAME + "' disabled><input type='hidden' id=hdnbranch_" + i + j + " value = '" + re.value.Tables[0].Rows[i].BRANCH_CODE + "'><input type='hidden' id=hdnemail_" + i + j + " value = '" + re.value.Tables[0].Rows[i].BRANCH_EMAIL + "'><input type=checkbox id=mailbrachk" + i + j + " />"
                i1 = parseInt(i1) + 1;
                j = parseInt(j) + 1;
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
        str += "</table>"
        document.getElementById('divmail').innerHTML = str;
        document.getElementById('divmail').style.display = "block";
        aTag = eval(document.getElementById("drppubl"))
        var btag;
        var leftpos = 350;
        var toppos = 400;

        document.getElementById('divmail').style.top = toppos + "px";
        document.getElementById('divmail').style.left = leftpos + "px";
    }
    else {
        document.getElementById('divmail').style.display = "block";
    }
    return false;
}

function setButtonImages() {
    if (document.getElementById('btnNew').disabled == true)
        document.getElementById('btnNew').src = "btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src = "btimages/new.jpg";

    if (document.getElementById('btnSave').disabled == true)
        document.getElementById('btnSave').src = "btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src = "btimages/save.jpg";

    if (document.getElementById('btnModify').disabled == true)
        document.getElementById('btnModify').src = "btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src = "btimages/modify.jpg";

    if (document.getElementById('btnQuery').disabled == true)
        document.getElementById('btnQuery').src = "btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src = "btimages/query.jpg";

    if (document.getElementById('btnExecute').disabled == true)
        document.getElementById('btnExecute').src = "btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src = "btimages/execute.jpg";

    if (document.getElementById('btnCancel').disabled == true)
        document.getElementById('btnCancel').src = "btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src = "btimages/clear.jpg";

    if (document.getElementById('btnfirst').disabled == true)
        document.getElementById('btnfirst').src = "btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src = "btimages/first.jpg";

    if (document.getElementById('btnprevious').disabled == true)
        document.getElementById('btnprevious').src = "btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src = "btimages/previous.jpg";

    if (document.getElementById('btnnext').disabled == true)
        document.getElementById('btnnext').src = "btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src = "btimages/next.jpg";

    if (document.getElementById('btnlast').disabled == true)
        document.getElementById('btnlast').src = "btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src = "btimages/last.jpg";

    if (document.getElementById('btnDelete').disabled == true)
        document.getElementById('btnDelete').src = "btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src = "btimages/delete.jpg";

    if (document.getElementById('btnExit').disabled == true)
        document.getElementById('btnExit').src = "btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src = "btimages/exit.jpg";
}
function EnterTab(evt, id) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 13) && (node.className != "btextlist") && ((node.type == "text") || (node.type == "select-one") || (node.type == "radio") || (node.type == "checkbox"))) {
        getNextElement(node).focus();
        return false;
    }
}
function getNextElement(field) {
    var form = field.form;
    for (var e = 0; e < form.elements.length; e++) {
        if (field == form.elements[e]) {
            break;
        }
    }
    e++;
    while (form.elements[e % form.elements.length].type == undefined || form.elements[e % form.elements.length].type == "hidden" || form.elements[e % form.elements.length].disabled == true || form.elements[e % form.elements.length].id == "BtnTransporterDetail" || form.elements[e % form.elements.length].id.split('_')[0] == "btnshowstock" || form.elements[e % form.elements.length].type == "fieldset") {
        e++;
    }
    return form.elements[e % form.elements.length];
}
var idfocus = "";
///this is the function which changes the background color on focus
function changebackcolor(e) {
    var idfoc = e.id;
    if (idfocus != "") {
        document.getElementById(idfocus).style.backgroundColor = "";
    }
    document.getElementById(idfoc).style.backgroundColor = "#FFFF80";

    idfocus = e.id;
}

/*==========================================================================Unit F2==============================================================*/

function BindUnit(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        var lb = document.getElementById("lstunit");
        for (var i = lb.options.length - 1; i > 1; i--) {
            lb.options[i] = null;
        }
        lb.selectedIndex = -1;
        offset(document.activeElement.id, "divunit", "lstunit");
        var compcode = jq('#hiddencompcode').val()
        var parameterValueArray = [compcode]
        Ad_Branch_Mail_Master.bind_unit(parameterValueArray, Callback_BindUnit);
        return false;
    }
    else if (key == 8 || key == 46) {
        document.getElementById("hdnunitcode").value = "";
    }
    else if (event.keyCode != 13 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 9 && event.keyCode != 17 && event.shiftKey == false && event.ctrlKey == false && event.altKey == false) {
        document.getElementById("hdnunitcode").value = "";
    }
    if (event.ctrlKey == true && event.keyCode == 88) {
        document.getElementById("hdnunitcode").value = "";
    }
}

function Callback_BindUnit(res) {
    var ds = res.value;
    var pkgitem = document.getElementById("lstunit");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Publication Center-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Pub_Cent_Name + "~" + ds.Tables[0].Rows[i].Pub_cent_Code, ds.Tables[0].Rows[i].Pub_Cent_Name + "~" + ds.Tables[0].Rows[i].Pub_cent_Code);
            pkgitem.options.length;
        }
    }
    else {
        pkgitem.options[0] = new Option("---There is no data accourding your search---", "");
        return false;
    }
    document.getElementById('lstunit').focus();
    return false;
}
function fillunit(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (document.getElementById('lstunit').value == "0") {
            alert("Please select the unitname");
            return false;
        }
        var page = document.getElementById('lstunit').value;
        var str = page.split("~");
        document.getElementById('txtunitname').value = str[0];
        document.getElementById('hdnunitcode').value = str[1];
        document.getElementById("divunit").style.display = 'none';
        document.getElementById('txtunitname').focus();
        return false;
    }
    else if (keycode == 27) {
        document.getElementById("divunit").style.display = 'none';
        document.getElementById('txtunitname').focus();
    }
}

function f2query(event) {
    if (event.keyCode != 113 && event.keyCode != 27) {
        if (document.activeElement.id == "txtclient") {
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
            ADV_Page_Reservation.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient').value, "Y", bindclientname_callback);
        }

    }

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

    //  document.getElementById('txtclient').value = "";
    //document.getElementById("lstclient").focus();  //uncomment

    document.getElementById("lstclient").value = "0"; //uncomment

    return false;
}

////////////////this function is called when we open the list box of agency than on mouse click it get the agency

function insertagency() {
    if (document.activeElement.id == "lstclient") {
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
        if (id == "yes") {
            alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
            return false;
        }
        var split = id.split("+");
        var namecode = split[0];
        var add = split[1];
        document.getElementById('hdnclientcode').value = page;

        document.getElementById('txtclient').value = namecode;




        return false;
    }
}



function tabvalue(event) {

    //This is open to upload image tab for all Insertions......
    var key = event.keyCode ? event.keyCode : event.which;




    /////////////////////////////////////////////////
    if (event.keyCode == 113 || (event.shiftKey == true && event.keyCode == 51)) {

        if (document.activeElement.id == "txtclient") {

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
            ADV_Page_Reservation.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient').value, "N", bindclientname_callback);
        }




    }
    else if (event.keyCode == 27) {
        if (document.getElementById("divclient").style.display == "block") {
            document.getElementById("divclient").style.display = "none"
            document.getElementById('txtclient').focus();
        }
        return false;
    }
    else if (event.keyCode == 13 || event.keyCode == 9 && event.shiftKey == false) {

        if (document.activeElement.id.indexOf("txtclient") >= 0) {
            if (document.getElementById('txtclient').value == "") {
                alert("Please Enter Client");
                document.getElementById('txtclient').focus();
                return false;
            }
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
        else {
            var idcursor;
            if (event.shiftKey == false) {
                event.keyCode = 9;
                return event.keyCode;
            }
        }
    }





}
function OnClickExit() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
    }
    return false;
}

function OnClickSave() {
    try {

        var currdate = document.getElementById('hdncurrdate').value;
        var schdate = document.getElementById('txtschdate').value;
        //if (compare_date("hdncurrdate", "txtschdate") == false) {
        //    return false;
        //}
        var P_COMP_CODE = jq("#hiddencompcode").val();
        var P_UNIT_CODE = jq("#hdncenter").val();
        var P_BRAN_CODE = jq("#hdnbrancd").val();
        var P_TRN_ID = "";
        if (Flag != "I") {
            P_TRN_ID = jq("#txtrcode").val();
        }
       
        var str = jq("#drppubl").val();
        var length = document.getElementById('drppubl').options.length;
        var abc = "";
        for (var li = 0; li < length; li++) {

            if (document.getElementById('drppubl').options[li].selected == true) {
                if (document.getElementById('drppubl').options[li].value != "") {
                    if (abc == "")
                        abc = document.getElementById('drppubl').options[li].value;
                    else
                        abc = abc + "," + document.getElementById('drppubl').options[li].value;
                }

            }
        }
        
        var P_PUBLICATION = abc;
        var P_PRINTING_CENTER = "";
        var abc2 = "";
        for (var s2 = 0; s2 < count; s2++) {
            var s3 = parseInt(s2) + 1;
            var lentt = document.getElementById("hdnlenval_" + s3).value;
            for (var s1 = 0; s1 < lentt ; s1++) {
                if (document.getElementById('mailbrachk_' + s3 + s1).checked == true) {
                    if (abc2 == "") {
                        abc2 = document.getElementById('hdnbranch_' + s3 + s1).value;
                    }
                    else {
                        abc2 = abc2 + "," + document.getElementById('hdnbranch_' + s3 + s1).value;
                    }
                }
            }
        }
        
        P_PRINTING_CENTER = abc2;
        var P_CLIENT_NAME = "";
        if (jq("#hdnclientcode").val() != "") {
            P_CLIENT_NAME = jq("#hdnclientcode").val();
        }
        else {
            P_CLIENT_NAME = jq("#txtclient").val();
        }
       
        var P_PAGE_POSITION = jq("#drppageprem").val();
        var P_AD_HEIGHT = jq("#txth").val();
        var P_AD_WEIDTH = jq("#txtw").val();
        var P_INSERT_DATE = jq("#txtschdate").val();
        var dd = P_INSERT_DATE.split("/")[0];
        var mm = P_INSERT_DATE.split("/")[1];
        var yy = P_INSERT_DATE.split("/")[2];
        P_INSERT_DATE = yy + "/" + mm + "/" + dd;
        var P_USERID = jq("#hdnuserid").val();
        var P_IUD = Flag;
        var P_DATE_FORMAT = jq("#hiddendateformat").val();
        var P_EXTRA1 = "";
        var P_EXTRA2 = "";
        var P_EXTRA3 = "";
        var P_EXTRA4 = "";
        var P_EXTRA5 = "";
        var p_edtn = "";
        var p_remark = jq("#txtremark").val();
        var p_status = jq("#drpstatus").val();
        var str1 = document.getElementById('drpedtn').value;
       

        var length1 = document.getElementById('drpedtn').options.length;
        var abc1 = "";
        for (var li1 = 0; li1 < length1; li1++) {
            if (document.getElementById('drpedtn').options[li1].selected == true) {
                if (document.getElementById('drpedtn').options[li1].value != "") {
                    if (abc1 == "")
                        abc1 = document.getElementById('drpedtn').options[li1].value;
                    else
                        abc1 = abc1 + "," + document.getElementById('drpedtn').options[li1].value;
                }
            }
        }
        
        p_edtn = abc1;
        var parameterValueArray = [P_COMP_CODE, P_UNIT_CODE, P_BRAN_CODE, P_TRN_ID, P_PUBLICATION, p_edtn, P_PRINTING_CENTER,
                                   P_CLIENT_NAME, P_PAGE_POSITION, P_AD_HEIGHT, P_AD_WEIDTH, P_INSERT_DATE, P_USERID, P_IUD,
                                   P_DATE_FORMAT, p_status, p_remark, P_EXTRA1, P_EXTRA2, P_EXTRA3, P_EXTRA4, P_EXTRA5
        ];
        var result = ADV_Page_Reservation.AD_RESERVE_DTL_IUD(parameterValueArray);
        var ds = result.value;
        if (ds != null) {
            var bookingid = ds.Tables[0].Rows[0].O_MSG;
            var id = bookingid.split(".")[1];
            funbtnmail(id);
            alert(bookingid);
            OnClickClear();

            return false;

        }
        else {
            alert(result.error.description)
            OnClickClear();
            return false;
        }
    }
    catch (Ex) {
        alert(Ex);
        return false;
    }
    return false;
}
function OnClickDelete() {
    Flag = "D";
    try {
        /*------------------Delete DATA-------------------------------*/
        OnClickSave();
        /*------------------Delete DATA-------------------------------*/
        return false;
    }
    catch (Ex) {
        alert(Ex);
        return false;
    }
    return false;
}
//-------------------------------------------------------------------------------------------------//
function funbtnmail(id) {
    var comp_code = jq("#hiddencompcode").val();
    var unit_code = jq("#hdncenter").val();
    var extra1 = id;
    var extra2 = jq("#txtschdate").val();
    if (extra1 == "")
    {
        extra1 = jq("#txtrcode").val();
    }
    var extraflagm=Flag;
    
    var result = ADV_Page_Reservation.bind_pubcent(comp_code, unit_code,  extra1, extra2,extraflagm);
    var res = result.value;
    //send_mail(res)
    return false;
}
function send_mail(res) {
    var re = res.value
    for (var i = 0; i < re.value.Tables[0].Rows.length; i) {
            var centercd = re.value.Tables[0].Rows[i].unit_code;
            var user_id = re.value.Tables[0].Rows[i].user_id;
            var mail_id = re.value.Tables[0].Rows[i].mail_id;
            var result = ADV_Page_Reservation.send_mail(user_id, mail_id);
        }
    return false;
}
//-------------------------------------------date compare-----------------------------------//

function chk_height() {
    if (jq("#txth").val() == "") {
        alert("Please fill Ad Size(W*H)");
        jq("#txtw").focus();
        return false;
    }
    return false;
}
function chk_client() {
    if (jq("#txtclient").val() == "") {
        alert("Please fill Client Name");
        
        return false;
    }
    return false;
}
    
function compare_date() {
    if (jq("#txtschdate").val() == "") {
        alert("Please fill Schedule Date");
        jq("#txtschdate").focus();
        return false;
    }
    compare_date_new("hdncurrdate", "txtschdate")
return false
}

function compare_date_new(pfromdate, ptodate) {
    var pfrdt = document.getElementById(pfromdate).value
    var stodate = pfrdt.split("/");
    var dd = stodate[0];
    var mm = stodate[1];
    var yy = stodate[2];

    var ptodt = document.getElementById(ptodate).value
    var stfrdate = ptodt.split("/");
    var day = stfrdate[0];
    var month = stfrdate[1];
    var year = stfrdate[2];

    if ((year < yy) || ((dd > day && mm >= month) && year <= yy) || ((dd < day && mm > month) && year <= yy)) {
        alert("Invalid Date Range!\n'Schedule Date should be  greater than Current Date!")
        document.getElementById(ptodate).value = "";
        document.getElementById(ptodate).focus();
        return false;
    }
    else {
        return true;
    }
}


