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
function OnClickClear() {
    Total_Records = 0, dsmain = "", dsmain_hdr = "", next = 0, count = 0, Flag = 0;
    jq('#btnNew,#btnQuery,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnSave,#btnModify,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();

    jq("#txtunitname,#txtbranch,#drpmoduleid,#txtmail,#txtremarks,#drpflag,#txtuserid").attr('disabled', true);
    jq("#txtunitname,#txtbranch,#drpmoduleid,#txtmail,#txtremarks,#drpflag,#txtuserid").val("");
    jq("#hdnunitcode,#hdnbranccode,#hdnusercode,#hdntransid").val("");
    jq("#ViewButton,#View").slideUp("slow");
    jq('#btnNew').focus();
    return false;
}
function OnClickNew() {
    Flag = "I";
    jq('#btnSave,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnNew,#btnModify,#btnQuery,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();

    jq("#txtunitname,#txtbranch,#drpmoduleid,#txtmail,#txtremarks,#drpflag,#txtuserid").attr('disabled', false);
    jq("#drpflag").val("A")
    jq('#txtunitname').focus();
    return false;
}
function OnClickSave() {
    if (Flag != "E") {
        if (check_mendetory('lblunitname').indexOf('*') >= 0) {
            if (jq('#hdnunitcode').val() == "") {
                alert("Please Fill Unit By [F2].");
                jq('#txtunitname').focus();
                return false;
            }
        }
        if (check_mendetory('lbbranchname').indexOf('*') >= 0) {
            if (jq('#hdnbranccode').val() == "") {
                alert("Please Fill Branch By [F2].");
                jq('#txtbranch').focus();
                return false;
            }
        }
        if (check_mendetory('lbluser').indexOf('*') >= 0) {
            if (jq('#hdnusercode').val() == "") {
                alert("Please Fill User By [F2].");
                jq('#txtuserid').focus();
                return false;
            }
        }
    }
    try {
        var compcode = jq("#hdncompcode").val()
        var unitcode = jq("#hdnunitcd").val()
        var brancode = jq("#hdnbrancd").val()
        var moduleid = jq("#drpmoduleid").val()
        var transid = jq("#hdntransid").val()
        var user_id = jq("#hdnusercode").val()
        var mailid = jq("#txtmail").val()
        var remarks = jq("#txtremarks").val()
        var freezeflag = jq("#drpflag").val()
        var dmltype = Flag;
        var dateformat = jq('#hiddendateformat').val()
        var userid = jq('#hdnuserid').val()
        var extra1 = "";
        var extra2 = "";
        var extra3 = "";
        var extra4 = "";
        var extra5 = "";

        var parameterValueArray = [compcode, unitcode, brancode, moduleid, transid, user_id, mailid, remarks, freezeflag,
                               dmltype, dateformat, userid, extra1, extra2, extra3, extra4, extra5
    ]
        var result = Ad_Branch_Mail_Master.Ad_Mailing_Ins_Upd_Del(parameterValueArray);
        var ds = result.value;
        if (ds != null) {
            if (Flag == "E") {
                dsmain_hdr = ds;
            }
            else {
                alert(ds.Tables[0].Rows[0].MSG)
                OnClickClear();
                return false;
            }
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
function OnClickQuery() {
    Flag = "E";
    jq('#btnExecute,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnNew,#btnSave,#btnModify,#btnQuery,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();

    jq("#txtunitname,#txtbranch,#drpmoduleid,#txtmail,#txtremarks,#drpflag,#txtuserid").attr('disabled', false);
    jq("#ViewButton").slideDown("slow");
    jq('#txtunitname').focus();
    return false;
}
function OnClickExecute() {
    try {
        /*------------------EXECUTE DATA-------------------------------*/
        OnClickSave();
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
            jq("#txtunitname,#txtbranch,#drpmoduleid,#txtmail,#txtremarks,#drpflag,#txtuserid").attr('disabled', true);
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
function BindHaderData() {
    jq('#txtunitname').val(fndnull(dsmain_hdr.Tables[0].Rows[next].UNIT_NAME));
    jq('#hdnunitcode').val(fndnull(dsmain_hdr.Tables[0].Rows[next].UNIT_CODE));

    jq('#txtbranch').val(fndnull(dsmain_hdr.Tables[0].Rows[next].BRAN_CODE));
    jq('#hdnbranccode').val(fndnull(dsmain_hdr.Tables[0].Rows[next].BRANCH_NAME));

    jq('#txtuserid').val(fndnull(dsmain_hdr.Tables[0].Rows[next].USERNAME));
    jq('#hdnusercode').val(fndnull(dsmain_hdr.Tables[0].Rows[next].USER_ID));

    jq('#txtmail').val(fndnull(dsmain_hdr.Tables[0].Rows[next].MAIL_ID));
    jq('#drpmoduleid').val(fndnull(dsmain_hdr.Tables[0].Rows[next].MODULE_ID));

    jq('#txtremarks').val(fndnull(dsmain_hdr.Tables[0].Rows[next].REMARKS));
    jq('#drpflag').val(fndnull(dsmain_hdr.Tables[0].Rows[next].FREEZE_FLAG));

    jq('#hdntransid').val(fndnull(dsmain_hdr.Tables[0].Rows[next].TRN_ID));
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
function OnClickModify() {
    Flag = "U";
    jq('#btnSave,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnNew,#btnModify,#btnQuery,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();

    jq("#txtunitname,#txtbranch,#drpmoduleid,#txtmail,#txtremarks,#drpflag,#txtuserid").attr('disabled', false);
    jq('#txtunitname').focus();
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

function OnClickView() {
    try {
        var compcode = jq("#hdncompcode").val()
        var unitcode = jq("#hdnunitcd").val()
        var brancode = jq("#hdnbrancd").val()
        var moduleid = jq("#drpmoduleid").val()
        var transid = jq("#hdntransid").val()
        var user_id = jq("#hdnusercode").val()
        var mailid = jq("#txtmail").val()
        var remarks = jq("#txtremarks").val()
        var freezeflag = jq("#drpflag").val()
        var dmltype = "E";
        var dateformat = jq('#hiddendateformat').val()
        var userid = jq('#hdnuserid').val()
        var extra1 = "";
        var extra2 = "";
        var extra3 = "";
        var extra4 = "";
        var extra5 = "";
        var parameterValueArray = [compcode, unitcode, brancode, moduleid, transid, user_id, mailid, remarks, freezeflag,
                               dmltype, dateformat, userid, extra1, extra2, extra3, extra4, extra5
    ];
        var result = Ad_Branch_Mail_Master.Ad_Mailing_Ins_Upd_Del(parameterValueArray);
        dsmain_hdr = result.value;
        dsmain = result.value;
        if (dsmain != null) {
            jq('#btnModify,#btnCancel,#btnDelete,#btnExit').attr('disabled', false);
            jq('#btnNew,#btnSave,#btnQuery,#btnExecute,#btnfirst,#btnprevious').attr('disabled', true);
            setButtonImages();

            jq("#View").slideDown("slow");
            BindLabelGrid();
        }
        else {
            alert(res.error.description)
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
function LabelDetailHeader() {
    var ColName = ["Sr.No.", "Publication Center", "Branch", "Module Id", "User Id", "Mail", "Flag", "Remark"];
    var ColWidth = ["2", "15", "15", "15", "15", "15", "5", "18"];
    var hdsview = "";
    hdsview += "<table  id='mytable' class='mytable' border='1' style='width: 100%;border-color: #7DAAE3;' cellpadding='0' cellspacing='0'>";
    hdsview += "<thead><tr style='height:25px;'>"
    jq.each(ColName, function (index, ColName) {
        hdsview += "<th style='width:" + ColWidth[index] + "%;  text-align:center;background: #7DAAE3;color:white;font-size:14px;'>" + ColName + "</th>";
    });
    hdsview += "</tr></thead>"
    return hdsview;
}
function BindLabelGrid() {
    jq("#View").empty();
    var hdsview = "";
    hdsview += LabelDetailHeader();
    for (count = 0; count < dsmain.Tables[0].Rows.length; count++) {
        hdsview += "<tr style='height:20px;' id=rowid_" + count + " onmouseover  ='Change(this, event);' onmouseout ='Change(this, event);' onclick='javascript:return filldetail(this.id);'>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid1_" + count + " >" + (parseInt(count) + parseInt(1)) + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid2_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].UNIT_NAME).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid3_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].BRANCH_NAME).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid4_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].MODULE_NAME).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid5_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].USERNAME).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid6_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].MAIL_ID).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid7_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].FREEZE_FLAG_NAME).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid8_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].REMARKS).toUpperCase() + "</label></td>";
        hdsview += "</tr>";
    }
    hdsview += "</table>";
    jq('#View').append(hdsview);
    if (dsmain.Tables[0].Rows.length > 16) {
        jq("#mytable").freezeHeader({ 'height': '325px' });
    }
    filldetail('rowid_0')
    return false
}
function filldetail(id) {
    id = id.split('_')[1];
    next = id;
    BindHaderData();
    return false;
}
function Change(obj, evt) {
    if (evt.type == "mouseover")
        obj.style.backgroundColor = "#afc7ed";
    else if (evt.type == "mouseout")
        obj.style.backgroundColor = "#f6f2dc";
}
/*==================================================================================Bind [F2]=========================================================*/
function check_mendetory(id) {
    var label_text = jq('#' + id).text();
    return label_text;
}
function fndnull(val) {
    if (val == null || val == undefined || val == "undefined")
        val = ""
    return val
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
function offset(activeid, divid, listboxid) {
    aTag = eval(document.getElementById(activeid))
    var btag;
    var leftpos = 0;
    var toppos = 18;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById(divid).scrollLeft;
    var scrolltop = document.getElementById(divid).scrollTop;
    document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";
    document.getElementById(divid).style.display = "block";
    document.getElementById(listboxid).focus();

    /*==========================================================================Unit F2==============================================================*/

}
function BindUnit(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        var lb = document.getElementById("lstunit");
        for (var i = lb.options.length - 1; i > 1; i--) {
            lb.options[i] = null;
        }
        lb.selectedIndex = -1;
        offset(document.activeElement.id, "divunit", "lstunit");
        var compcode = jq('#hdncompcode').val()
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
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Pub_Cent_Name + "~" + ds.Tables[0].Rows[i].Pub_Cent_Code, ds.Tables[0].Rows[i].Pub_Cent_Name + "~" + ds.Tables[0].Rows[i].Pub_Cent_Code);
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
/*===============================================================================Branch F2===============================================================*/

function BindBranch(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        var lb = document.getElementById("lstbranch");
        for (var i = lb.options.length - 1; i > 1; i--) {
            lb.options[i] = null;
        }
        lb.selectedIndex = -1;
        offset(document.activeElement.id, "divbranch", "lstbranch");
        var compcode = jq('#hdncompcode').val()
        var parameterValueArray = [compcode]
        Ad_Branch_Mail_Master.bind_branch(parameterValueArray, Callback_BindBranch);
        return false;
    }
    else if (key == 8 || key == 46) {
        document.getElementById("hdnbranccode").value = "";
    }
    else if (event.keyCode != 13 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 9 && event.keyCode != 17 && event.shiftKey == false && event.ctrlKey == false && event.altKey == false) {
        document.getElementById("hdnbranccode").value = "";
    }
    if (event.ctrlKey == true && event.keyCode == 88) {
        document.getElementById("hdnbranccode").value = "";
    }
}
function Callback_BindBranch(res) {
    var ds = res.value;
    var pkgitem = document.getElementById("lstbranch");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Branch Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name + "~" + ds.Tables[0].Rows[i].Branch_Code, ds.Tables[0].Rows[i].Branch_Name + "~" + ds.Tables[0].Rows[i].Branch_Code);
            pkgitem.options.length;
        }
    }
    else {
        pkgitem.options[0] = new Option("---There is no data accourding your search---", "");
        return false;
    }
    document.getElementById('lstbranch').focus();
    return false;
}
function fillBranch(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (document.getElementById('lstbranch').value == "0") {
            alert("Please select the BranchName");
            return false;
        }
        var page = document.getElementById('lstbranch').value;
        var str = page.split("~");
        document.getElementById('txtbranch').value = str[0];
        document.getElementById('hdnbranccode').value = str[1];
        document.getElementById("divbranch").style.display = 'none';
        document.getElementById('txtbranch').focus();
        return false;
    }
    else if (keycode == 27) {
        document.getElementById("divbranch").style.display = 'none';
        document.getElementById('txtbranch').focus();
    }
}

/*========================================================================================= f2 userid ==============================================================*/
function BindUserid(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        var lb = document.getElementById("lstuser");
        for (var i = lb.options.length - 1; i > 1; i--) {
            lb.options[i] = null;
        }
        lb.selectedIndex = -1;
        offset(document.activeElement.id, "divuser", "lstuser");
        var login_code = document.getElementById('txtuserid').value;
        var dateformat = jq('#hiddendateformat')
        var extra1 = '';
        var extra2 = '';
        var parameterValueArray = [login_code, dateformat, extra1, extra2]
        Ad_Branch_Mail_Master.bind_userid(parameterValueArray, Callback_BindUserid);
        return false;
    }
    else if (key == 8 || key == 46) {
        document.getElementById("hdnusercode").value = "";
    }
    else if (event.keyCode != 13 && event.keyCode != 37 && event.keyCode != 39 && event.keyCode != 9 && event.keyCode != 17 && event.shiftKey == false && event.ctrlKey == false && event.altKey == false) {
        document.getElementById("hdnusercode").value = "";
    }
    if (event.ctrlKey == true && event.keyCode == 88) {
        document.getElementById("hdnusercode").value = "";
    }
}
function Callback_BindUserid(res) {
    var ds = res.value;
    var pkgitem = document.getElementById("lstuser");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Userid-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username + "~" + ds.Tables[0].Rows[i].userid, ds.Tables[0].Rows[i].username + "~" + ds.Tables[0].Rows[i].userid);
            pkgitem.options.length;
        }
    }
    else {
        pkgitem.options[0] = new Option("---There is no data accourding your search---", "");
        return false;
    }
    document.getElementById('lstuser').focus();
    return false;
}
function fillUserid(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode == 13 || event.type == "click") {
        if (document.getElementById('lstuser').value == "0") {
            alert("Please select the Userid");
            return false;
        }
        var page = document.getElementById('lstuser').value;
        var str = page.split("~");
        document.getElementById('txtuserid').value = str[0];
        document.getElementById('hdnusercode').value = str[1];
        document.getElementById("divuser").style.display = 'none';
        document.getElementById('txtuserid').focus();
        return false;
    }
    else if (keycode == 27) {
        document.getElementById("divuser").style.display = 'none';
        document.getElementById('txtuserid').focus();
    }
}