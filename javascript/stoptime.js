var klen = 0;

var browser = navigator.appName;
var genitemcode = "";
var dsmain;
var next = "0";
var total_records = "0";
var flag = "";
var createhtml = new StringBuffer();
function StringBuffer() {
    this.buffer = [];

}
StringBuffer.prototype.append = function append(string) {
    this.buffer.push(string);
    return this;
};

function StringBuffer() {
    this.buffer = [];
}

StringBuffer.prototype.append = function append(string) {
    this.buffer.push(string);
    return this;
}

StringBuffer.prototype.toString = function toString() {
    return this.buffer.join("");
}



function opengrid() {

    document.getElementById("hdsviewgrid").innerHTML = "";
    var temp_del1 = "";
    var createhtml = new StringBuffer();
    flg_req = "yes"
    var aa1 = "";
    var aa = "";
    var hs = 0;
    var hs1 = 0;
    document.getElementById('divcost').style.display = "block";
    document.getElementById('hdsviewgrid').style.display = "block";
  

    if (document.getElementById("hdsviewgrid").children.length == "0") {
        klen = 0;

    }
    else {


        IntializeNumber = klen + 1;
    }


    if (document.getElementById("hdsviewgrid").innerHTML == "") {
        createhtml += "<table Width='250px' style='border:1px solid black' >"
        createhtml += "<tr>"

        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>DAYS</td>"        
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>TIME</td>"
       
        createhtml += "</tr>"

        glength = 0;
        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest();
        }
        else {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.open("GET", "XMl/stoptime.xml", false);
        xmlhttp.send();
        xmlDoc = xmlhttp.responseXML;
        var categories = xmlDoc.getElementsByTagName("weekdays");
        var numCats = categories.length;
        for (var i = 0; i < numCats; i++) {
            var items = categories[i].getElementsByTagName('day');
            var numItems = items.length;
            for (klen = 0; klen < numItems; klen++) {
                createhtml += "<tr>"
                createhtml += "<td class='btextsmallsize'>"
                createhtml += "<input disabled type='text' style='width:125px;text-align:center;' align='left' class='dropdown_large_corr'  value='" + items[klen].firstChild.nodeValue + "'  id='days_" + klen + "'  />"
                createhtml += "</td>"               
                createhtml += "<td class='btextsmallsize'>"
                createhtml += "<input disabled  type='text' style='width:125px;text-align:right;' align='left' class='dropdown_large_corr'; onblur=javascript:checktime(this);   id='time_" + klen + "'  />"
                createhtml += "</td>"
                createhtml += "</tr>"
            }
        }
        createhtml += "</table>"
        var hdsview = "";
        temp_del1 = createhtml.toString();
        temp_del1 = temp_del1.replace("<TBODY>", "")

        document.getElementById('hdsviewgrid').innerHTML = createhtml.toString();
    }
    document.getElementById('btnExecute').disabled = true
    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnNew').focus();
    // setButtonImages();
    return false;



}


function checktime(obj) {
    var timeValue = obj.value;
    if (timeValue == "" || timeValue.indexOf(":") < 0) {
        alert("Invalid Time format");
        obj.value = "";
        return false;
    }
    else {
        var sHours = timeValue.split(':')[0];
        var sMinutes = timeValue.split(':')[1];

        if (sHours == "" || isNaN(sHours) || parseInt(sHours) > 23) {
            alert("Invalid Time format");
            obj.value = "";
            return false;
        }
        else if (parseInt(sHours) == 0)
            sHours = "00";
        else if (sHours < 10)
            sHours = "0" + sHours;

        if (sMinutes == "" || isNaN(sMinutes) || parseInt(sMinutes) > 59) {
            alert("Invalid Time format");
            obj.value = "";
            return false;
        }
        else if (parseInt(sMinutes) == 0)
            sMinutes = "00";
        else if (sMinutes < 10)
            sMinutes = "0" + sMinutes;

        obj.value = sHours + ":" + sMinutes;
    }

    return true;
}

function isnumKey1(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode == 31 || charCode == 45) || (charCode == 8) || (charCode >= 48 && charCode <= 57)) {
        return true;
    }
    else
        alert("Please Fill Numeric Value");

    return false;
}


function fndnull(myval) {
    if (myval == "undefined") {
        myval = "";
    }
    else if (myval == null) {
        myval = "";
    }
    else if (myval == "") {
        myval = "";
    }

    return myval
}


/*------------------------set button image function-------------------*/
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

/*---------------------------------NEW CLICK----------------------*/

function newclick() {

    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnExit').disabled = false;
    setButtonImages();
    for (i = 0; i < klen; i++){
    document.getElementById('time_' + i).disabled = false;  
    }
        genitemcode = "N";
    flag = "";
    return false;
}


function onload_clear() {

    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnExit').disabled = false;
   setButtonImages();
    genitemcode = "";
    flag = "";
    for (i = 0; i < klen; i++) {
        document.getElementById('time_' + i).value = "";
    }
   
    return false;
}
function exitclick() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
        return false;
    }

    return false;

}

function queryclick() {

    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    setButtonImages();
    genitemcode = "Q";    
    document.getElementById('btnExecute').focus();
    return false;
}
function executelick() {

    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnExit').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnfirst').disabled = true;
     document.getElementById('btnlast').disabled = true; 
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnDelete').disabled = false;
    document.getElementById('btnModify').disabled = false;
    document.getElementById('btnModify').focus();
    var compcode = document.getElementById('hiddencompcode').value;
    var unitcode = document.getElementById('hdnunit').value;
    var createdby = document.getElementById('hiddenuserid').value;
    var createddt = "";
    var updatedby = "";
    var updateddt = "";
    var extra1 = "";
    var extra2 = "";
    var extra3 = "";
    var extra4 = "";
    var seq = "";
    var dateformat = document.getElementById('hiddendateformat').value;
    var days = "";
    var hour = "";
    var res = stoptime.save_exec(compcode, unitcode, days, hour, createdby, seq, extra1, extra2, extra3, extra4)
    if (res.value.Tables[0].Rows.length > 0) {
        callback_exec(res);
    }
    else {
        opengrid();
       
        
    }
    return false;
}



function callback_exec(res) {
    var amount_total_new = 0;
    dsmain = "";
    IntializeNumber = 1;
    buf1 = "";
    dsmain = res.value;
    document.getElementById('divcost').style.display = "block";
    document.getElementById('hdsviewgrid').innerHTML = "";
    var hdsview = "";
    klen = "";
    if (document.getElementById("hdsviewgrid").children.length == "0") {
        klen = "0"
    }
    else {
        klen = document.getElementById("hdsviewgrid").childNodes[0].childNodes[0].childNodes.length - 1;
    }

    if (document.getElementById("hdsviewgrid").innerHTML.indexOf("width:950px;display:block") <= 0) {

        if (browser != "Microsoft Internet Explorer") {
            aa = document.getElementById("hdsviewgrid").innerHTML.replace("</tbody></table>", "")
        }
        else {


            aa = document.getElementById("hdsviewgrid").innerHTML.replace("</TBODY></TABLE>", "")
        }
    }

    buf1 = "";
    document.getElementById('btnModify').enable = true; 
    createhtml += "<table Width='250px' style='border:1px solid black' >"
    createhtml += "<tr>"
    createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>DAYS</td>"
    createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>TIME</td>"
    createhtml += "</tr>"
    klen = 0;

    if (dsmain.Tables[0].Rows.length > "0") {
        var expcount = dsmain.Tables[0].Rows.length;
        for (klen = 0; klen < expcount; klen++) {
            buf1 += "<tr>"
            createhtml += "<td class='btextsmallsize'>"
            createhtml += "<input disabled type='text' style='width:125px;text-align:center;' align='left' class='dropdown_large_corr'  value='" + dsmain.Tables[0].Rows[klen]['DAYS'] + "'  id='days_" + klen + "'  />"
            createhtml += "</td>"
            createhtml += "<td class='btextsmallsize'>"
            createhtml += "<input disabled  type='text' style='width:125px;text-align:right;' align='left' class='dropdown_large_corr'; value='" + fndnull(dsmain.Tables[0].Rows[klen]['HOUR'] )+ "' onblur=javascript:checktime(this);   id='time_" + klen + "'  />"
            createhtml += "</td>"
            createhtml += "</tr>"
            IntializeNumber = IntializeNumber + 1;
        }

    }
    createhtml += "</tr>"
    createhtml += "</table>"
    var hdsview = "";
    document.getElementById("hdsviewgrid").innerHTML = createhtml.toString();
    createhtml = "";
   
    return false;
   


}


function modfiyclick() {
    flag = "M";
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    for (i = 0; i < klen; i++) {
        document.getElementById('time_' + i).disabled = false;
    }
    setButtonImages();
    return false;


}
function deleteclick() {
    var str = document.getElementById('hdnwherecloase').value;
    var str1 = str.split("$~$");
    var tablename = str1[str1.length - 2];
    var action = str1[str1.length - 1];
    var finalaction = action.split("#");
    var insert = finalaction[0];
    var update = finalaction[1];
    var del = finalaction[2];
    var select = finalaction[3];

    var fields = document.getElementById('hdnwherecloase').value.replace("$~$" + tablename, "")
    fields = fields.replace("$~$" + action, "");
    fields = fields + "$~$";


    var compcode = "'" + document.getElementById('hdncompcode').value + "'";

    var typecode = "'" + document.getElementById('txttypecode').value + "'";
    var dateformat = document.getElementById('hdndateformat').value;

    var finalval = compcode + "$~$" + typecode + "$~$";
    if (confirm("Are you sure to delete the data.")) {
        var result = ExpanceTypeMaster.Delete(tablename, fields, finalval, del, dateformat, "", "")

        if (result.value == "true") {
            alert("Data Delete successfully")
            opengrid();
            return false;
        }
    }



    opengrid();
    return false;
}

/*****************************NEXT CLICK************************/

function nextclick() {

    next = parseInt(next) + 1;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnfirst').disabled = true;

    setButtonImages();
    if (next < dsmain.Tables[0].Rows.length) {

        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;
    }

    if (next == total_records - 1) {
        document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;    

        setButtonImages();

    }

    return false;
}

/*----------------------------Previous CLICK------------------*/
function Previousclick() {

    next = parseInt(next) - 1;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    setButtonImages();
 
    if (next == 0) {
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnnext').focus();
        setButtonImages();

    }

    return false;
}

/**********************************FIRST CLICK**********************/

function firstclick() {

    var total_records = dsmain.Tables[0].Rows.length;
    next = 0;
    total_records = total_records - 1;
    next = 0;
    if (dsmain.Tables[0].Rows.length > 0) {

       
    }

    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnnext').focus();

    setButtonImages();
    return false;

}
/*----------------------------------last click-----------------*/

function lastclick() {

    var total_records = dsmain.Tables[0].Rows.length;
    next = total_records - 1;
    total_records = total_records - 1;

    if (dsmain.Tables[0].Rows.length > 0) {
    }


    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnprevious').focus();
    setButtonImages();

    return false;
}




function itemsave() {
    var hour1 = "";
    for (i = 0; i < klen; i++) {
        hour1 = hour1 + document.getElementById('time_' + i).value;
     }
     if (hour1 == "") {
         alert('Please fill time  first')
         return false;
     }
        if (flag == "M") {
        modifysave();
        return false;
    }
    else {

        var compcode = document.getElementById('hiddencompcode').value;        
        var unitcode = document.getElementById('hdnunit').value;
        var createdby = document.getElementById('hiddenuserid').value;
        var createddt = "";
        var updatedby = "";
        var updateddt = "";
        var extra1 = "";
        var extra2 = "";
        var extra3 = "";
        var extra4 = "";
//      var res= stoptime.autogen()
        //      var seq = res.value.Tables[0].Rows[0].SEQNO;
        var seq = "1";
        var dateformat = document.getElementById('hiddendateformat').value;
        for (i = 0; i < klen; i++) {
            var days = document.getElementById('days_' + i).value;
            var hour = document.getElementById('time_' + i).value;
            stoptime.save_data(compcode, unitcode, days, hour, createdby,seq, extra1, extra2, extra3, extra4)
        }
        alert("Data Saved Succesfully ");
        executelick();
        return false;
    }

}


function modifysave() {
    flag = "";
    var compcode = document.getElementById('hiddencompcode').value;
    var unitcode = document.getElementById('hdnunit').value;
    var createdby = document.getElementById('hiddenuserid').value;
    var createddt = "";
    var updatedby = "";
    var updateddt = "";
    var extra1 = "";
    var extra2 = "";
    var extra3 = "";
    var extra4 = "";
    //      var res= stoptime.autogen()
    //      var seq = res.value.Tables[0].Rows[0].SEQNO;
    var seq = "1";
    var dateformat = document.getElementById('hiddendateformat').value;
    for (i = 0; i < klen; i++) {
        var days = document.getElementById('days_' + i).value;
        var hour = document.getElementById('time_' + i).value;
        stoptime.save_data(compcode, unitcode, days, hour, createdby, seq, extra1, extra2, extra3, extra4)
    }
        alert("Data Modify Successfully");
        executelick();
    return false;
}
