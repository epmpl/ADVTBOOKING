var jq = jQuery.noConflict();
var browser = navigator.appName;

var Total_Records = 0;
var dsmain = "";
var dsmain_hdr = "";
var next = 0;
var count = 0;
var Flag = "";
var idfocus = "";


window.onload = function () {
    OnClickClear();
    return false;
}
function OnClickClear() {
    Total_Records = 0, dsmain = "", dsmain_hdr = "", next = 0, count = 0, Flag = 0;
    jq("#drppageprem,#txtschdate,#txtschdate0,#drpdestination").attr('disabled', false);
    jq("#drppageprem,#txtschdate,#txtschdate0,#drpdestination").val("");
    jq("#drppageprem").val("0");
    jq("#drpdestination").val("O");
    jq("#View").slideUp("slow");
    jq('#drppageprem').focus();
    return false;
}
function Change(obj, evt) {
    if (evt.type == "mouseover")
        obj.style.backgroundColor = "#afc7ed";
    else if (evt.type == "mouseout")
        obj.style.backgroundColor = "#f6f2dc";
}
///this is the function which changes the background color on focus
function changebackcolor(e) {
    var idfoc = e.id;
    if (idfocus != "") {
        document.getElementById(idfocus).style.backgroundColor = "";
    }
    document.getElementById(idfoc).style.backgroundColor = "#FFFF80";

    idfocus = e.id;
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
 
function OnClickView() {
    try {
        var P_COMP_CODE     = jq("#hiddencompcode").val()
        var P_FRDT          = jq("#txtschdate").val()
        var P_TODT          = jq("#txtschdate0").val()
        var P_DATEFORMAT    = jq("#hiddendateformat").val()
        var pageprem        = jq("#drppageprem").val()
        var parameterValueArray = [P_COMP_CODE,pageprem, P_FRDT, P_TODT, P_DATEFORMAT];
        var result = ADV_Page_Reservation_Rpt.AD_RESERVE_REP(parameterValueArray);
        dsmain_hdr = result.value;
        dsmain = result.value;
        if (dsmain != null) {
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
    var ColName = ["Sr.No.", "ID", "Page Position", "Size(W*H)", "Client Name", "Publication", "Edition", "Publication Center", "Booking Center", "Booked By", "Schedule Date", "Booking Date", "Cancellation Date"];
    var ColWidth = ["2", "5", "8", "18", "10", "10", "10", "5", "10", "10", "5", "5", "5"];
    var hdsview = "";
    hdsview += "<table  id='mytable' class='mytable' border='1' style='width: 100%;border-color: #7DAAE3;' cellpadding='0' cellspacing='0' overflow: scroll;>";
    hdsview += "<thead><tr style='height:25px;'>"
    jq.each(ColName, function (index, ColName) {
        hdsview += "<th style='width:" + ColWidth[index] + "%;  text-align:center;background: #7DAAE3;color:white;font-size:14px;'>" + ColName + "</th>";
    });
    hdsview += "</tr></thead>"
    return hdsview;
}
function fndnull(val) {
    if (val == null || val == undefined || val == "undefined")
        val = ""
    return val
}
function filldetail(id) {
    id = id.split('_')[1];
    next = id;
    
    var trn_id = document.getElementById('TRNID_' + next).value
    popup = window.open("ADV_Page_Reservation.aspx?form=" + "ADV_Page_Reservation_EXE" + "&trn_id=" + trn_id, "");
    return false;
}
function BindLabelGrid() {
    jq("#View").empty();
    var hdsview = "";
    hdsview += LabelDetailHeader();
    for (count = 0; count < dsmain.Tables[0].Rows.length; count++) {

        hdsview += "<tr style='height:20px;' id=rowid_" + count + " onmouseover  ='Change(this, event);' onmouseout ='Change(this, event);' onclick='javascript:return filldetail(this.id);'>";
        hdsview += "<td style='text-align:center;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=srno_" + count + " >" + (parseInt(count) + parseInt(1)) + "</label></td>";
        hdsview += "<td style='text-align:center;' ><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=TRNID_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].TRN_ID).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:center;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=pageposition_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].PAGE_POSITION_NM).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:center;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=size_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].SIZE).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=client_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].CLIENT_NAME_VAL).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=publname_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].PUBLICATION_NM).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=edition_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].EDITION).toUpperCase() + "</label></td>";
        var pubcentername = "";
        var pubcenternamed11 = dsmain.Tables[0].Rows[count].PRINTING_CENTER;
        if (pubcenternamed11.length >= 30)
        {
            pubcentername = pubcenternamed11.substr(0, 30);
            if (pubcenternamed11.length >= 31 && pubcenternamed11.length <=60)
                {
                    pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(30, 60);
                }
            else if (pubcenternamed11.length >= 61 && pubcenternamed11.length <= 90)
            {
                    pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(30, 30);
                    pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(60, 30);
                }
            else if (pubcenternamed11.length >= 91 && pubcenternamed11.length <= 120)
                {
                pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(30, 30);
                pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(60, 30);
                pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(90, 30);
                }
            else if (pubcenternamed11.length >= 121 && pubcenternamed11.length <= 150) {
                pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(30, 30);
                pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(60, 30);
                pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(90, 30);
                pubcentername = pubcentername + "</br>" + pubcenternamed11.substr(120, 30);
                }
        }
        else
        {
            pubcentername = pubcenternamed11;
        }
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=publ_" + count + " >" + pubcentername.toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:left;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=publ_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].UNIT_CODE).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:center;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid7_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].USERNAME).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:center;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid8_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].INSERT_DATE).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:center;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid9_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].CREATION_DATE).toUpperCase() + "</label></td>";
        hdsview += "<td style='text-align:center;'><label style='font-size:12px;font-family:Verdana;color:black;cursor:pointer;vertical-align:top; padding-left:2px;' id=rowid10_" + count + " >" + fndnull(dsmain.Tables[0].Rows[count].CANCEL_DATE).toUpperCase() + "</label></td>";
        hdsview += "</tr>";
        pubcenternamed11 = "";
        pubcentername = "";
    }
    hdsview += "</table>";
    jq('#View').append(hdsview);
    if (dsmain.Tables[0].Rows.length > 16) {
        jq("#mytable").freezeHeader({ 'height': '325px' });
    }
    //filldetail('rowid_0')
    return false
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
function openTempPagereservationPopUp() { 
    var P_FRDT      = jq("#txtschdate").val()
    var P_TODT      = jq("#txtschdate0").val() 
    var pageprem    = jq("#drppageprem").val()
    var dest        = jq("#drpdestination").val()
    popup = window.open("ADV_Page_Reservation_Rpt_View.aspx?P_FRDT=" + P_FRDT + "&P_TODT=" + P_TODT + "&pageprem=" + pageprem + "&dest=" + dest, "");
    popup.focus();
        
    return false;
}