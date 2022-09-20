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
    Total_Records = 0, dsmain = "", dsmain_hdr = "", next = 0, count = 0, Flag = 0;
     jq('#btnNew,#btnQuery,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnSave,#btnModify,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();
    jq("#txtunitname,#drpagcategory,#txtagency,#txtmail,#txtadd,#txtplace,#txtgst,#txtmob,#txtpincode").attr('disabled', true);
    jq("#txtunitname,#drpagcategory,#txtagency,#txtmail,#txtadd,#txtplace,#txtgst,#txtmob,#txtpincode").val("");
    jq("#txtunitname").val(jq("#hdnunitnm").val());
    jq("#drpagcategory").val("0");

    document.getElementById('btnModify').style.display = "none";
    document.getElementById('btnQuery').style.display = "none";
    document.getElementById('btnExecute').style.display = "none";
    document.getElementById('btnfirst').style.display = "none";
    document.getElementById('btnprevious').style.display = "none";
    document.getElementById('btnlast').style.display = "none";
    document.getElementById('btnDelete').style.display = "none";
    document.getElementById('btnnext').style.display = "none";
   
    if (document.getElementById('hdnrefflag').value == "E") {
        chkexedata();
    }
    if (count_chk > 0 && count_chk != "") {
        BindHaderData();
         
        jq('#btnExit').attr('disabled', false);
        jq('#btnNew,#btnQuery,#btnCancel,#btnSave,#btnModify,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);

    }
    else {
        document.getElementById('btnExit').style.display = "none";
    }
    //jq("#ViewButton").slideUp("slow");
    jq('#btnNew').focus();
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


function OnClickSave() {
    try {
        if (jq("#txtagency").val() == "")
        {
            alert("Please Fill Agency Name Fist. ");
            return false;
        }
         var compcode   = jq("#hdncompcode").val()
         var unitname   = jq("#hdnunitcd").val()
         var agcategory = jq("#drpagcategory").val()
         
         var agency     = jq("#txtagency").val()
         var mail       = jq("#txtmail").val()
         var add        = jq("#txtadd").val()
         var place      = jq("#txtplace").val()
         var gst        = jq("#txtgst").val()
         var mob        = jq("#txtmob").val()
         var pincode    = jq("#txtpincode").val()
         var PHONE      = document.getElementById('txtphone').value
         var userid     = jq('#hdnuserid').val()
         if(agcategory == ""  || agcategory == "0")
         {
            alert("Please select Category");
            return false;
         }
         if(agency == ""  || agency == "0")
         {
            alert("Please Fill Agency Name");
            return false;
         }
          if(place == ""  || place == "0")
         {
            alert("Please City Name");
            return false;
         }
         
         var ptempag_cd = ""
         var pflag      = "I"
        var extra1      = jq('#hdnrefbookingid').val()
        var  extra2     = "";
        var  extra3     = "";
        var  extra4     = "";
        var  extra5     = "";

        var parameterValueArray = [compcode, unitname, agcategory, agency, mail, add, place, gst, mob, pincode,PHONE, userid, ptempag_cd, pflag, extra1, extra2, extra3, extra4, extra5]
        var result = Temp_Agency_Mast.ad_temp_agency_save(parameterValueArray);
        var ds = result.value;
        if (ds != null) {
            SetName(ds.Tables[0].Rows[0].O_MSG)
          //  Temp_Agency_Mast.setSessionmis_run(ds.Tables[0].Rows[0].O_MSG);
            alert(ds.Tables[0].Rows[0].O_MSG)
            var centername = jq("#txtunitname").text();
            //var agcategoryname = jq("#drpagcategory").text();

            var agcategoryname = jq("#drpagcategory option:selected").text();
            var placename = jq("#txtplace option:selected").text();
            var mailres1 = Temp_Agency_Mast.mailfinalsaveagency(compcode, agcategoryname, agency, mail, add,place, placename, gst, mob, pincode, PHONE, userid, ds.Tables[0].Rows[0].O_MSG, unitname ,"","");
                 OnClickClear();
                 window.returnValue = new Array(ds.Tables[0].Rows[0].O_MSG);
                 window.close();
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

function SetName(vall) {
    if (window.opener != null && !window.opener.closed) {
        var txtName = window.opener.document.getElementById("hdntempagcode");
        txtName.value = vall;
    }
    //window.close();
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

function OnClickExit() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
    }
    return false;
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
var ds_main4tagency = "";
var count_chk = "";
function chkexedata()
{
    try {
         
        var compcode        = jq("#hdncompcode").val()
        var unitname        = jq("#hdnunitcd").val()
        var agcategory      = jq("#drpagcategory").val()
        var agency          = jq("#txtagency").val()
        var mail            = jq("#txtmail").val()
        var add             = jq("#txtadd").val()
        var place           = jq("#txtplace").val()
        var gst             = jq("#txtgst").val()
        var mob             = jq("#txtmob").val()
        var pincode         = jq("#txtpincode").val()
        var PHONE           = document.getElementById('txtphone').value
        var userid          = jq('#hdnuserid').val()
        var ptempag_cd      = ""
        var pflag           = "E"
        var extra1          = jq('#hdnrefbookingid').val()
        var extra2          = "";
        var extra3          = "";
        var extra4          = "";
        var extra5          = "";

        var parameterValueArray = [compcode, unitname, agcategory, agency, mail, add, place, gst, mob, pincode,PHONE, userid, ptempag_cd, pflag, extra1, extra2, extra3, extra4, extra5]
        var result = Temp_Agency_Mast.ad_temp_agency_save(parameterValueArray);
          ds_main4tagency = result.value;
        if (ds_main4tagency != null) {
            count_chk = ds_main4tagency.Tables[0].Rows.length;
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
function OnClickNew() {
    Flag = "I";
    
    jq('#btnSave,#btnCancel,#btnExit').attr('disabled', false);
    jq('#btnNew,#btnModify,#btnQuery,#btnExecute,#btnfirst,#btnprevious,#btnnext,#btnlast,#btnDelete').attr('disabled', true);
    setButtonImages();
    jq("#drpagcategory,#txtagency,#txtmail,#txtadd,#txtplace,#txtgst,#txtmob,#txtpincode").attr('disabled', false);
    jq("#drpflag").val("A")
    
    jq('#drpagcategory').focus();
    return false;
}


function BindHaderData() {
    document.getElementById('drpagcategory').value  = fndnull(ds_main4tagency.Tables[0].Rows[0].AGCATEGORY);
    document.getElementById('txtagency').value      = fndnull(ds_main4tagency.Tables[0].Rows[0].AGENCY); 
    document.getElementById('txtmail').value        = fndnull(ds_main4tagency.Tables[0].Rows[0].MAIL);
    document.getElementById('txtadd').value         = fndnull(ds_main4tagency.Tables[0].Rows[0].ADDRESS);
    document.getElementById('txtplace').value       = fndnull(ds_main4tagency.Tables[0].Rows[0].PLACE);
    document.getElementById('txtgst').value         = fndnull(ds_main4tagency.Tables[0].Rows[0].GST);
    document.getElementById('txtmob').value         = fndnull(ds_main4tagency.Tables[0].Rows[0].MOB);
    document.getElementById('txtpincode').value     = fndnull(ds_main4tagency.Tables[0].Rows[0].PINCODE);
    document.getElementById('txtphone').value       = fndnull(ds_main4tagency.Tables[0].Rows[0].PHONE_NO);
    
    setButtonImages();
    return false;
}
