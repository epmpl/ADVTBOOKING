var browser = navigator.appName;
var dsmain = "";
var IntializeNumber = 1;
var glength;
var klen = 0;
var datamodify = 0;
var insertnewrow = false;
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

function search_data() {
  
    document.getElementById('hdnagency').value=""
  document.getElementById('txtcreditdays').value=""
   document.getElementById('txtcreditlimit').value=""
    document.getElementById('txtrecovery').value=""
  document.getElementById('txteffectivefrom').value=""
  document.getElementById('txteffectiveto').value = ""
  document.getElementById('txtagency').value = ""
  

    var compcode = document.getElementById('hiddencompcode').value;
    var execcode = document.getElementById('hiddenretcode').value;
    retainpoup.bindgrid(compcode, execcode, callback_data);


}

function callback_data(res) {
    dsmain = res.value;
    if (dsmain.Tables[0].Rows.length == 0) {
        opengrid();

        return false;
    }
    else {
        excutegrid(dsmain);
        datamodify = 1;
    }

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
//    document.getElementById('addrow').style.display = "block";

    if (document.getElementById("hdsviewgrid").children.length == "0") {
        klen = 0;

    }
    else {


        IntializeNumber = klen + 1;
    }


    if (document.getElementById("hdsviewgrid").innerHTML == "") {
        createhtml += "<table Width='700px' style='border:1px solid black' >"
        createhtml += "<tr>"

        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agency Type<font color=red>[F2*] </font></td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Credit Days</td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Credit Limit</td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Recovery %</td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Effective From<font color=red>* </font></td>"
        createhtml += "<td  bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'></td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Effective To<font color=red>* </font></td>"
        createhtml += "<td  bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'></td>"
        createhtml += "</tr>"

        len = 1;


        createhtml += "<tr>"
        glength = 0;

        createhtml += "<input type='checkbox' style='width:10px;text-align:right;display:none;' align='left' class='dropdown_large_corr'; id='check_" + klen + "'  onclick=javascript:fillvalueingrid(id);    />"
     
        createhtml += "<td class='btextsmallsize'>"
        createhtml += "<input disabled type='text' style='width:80px;' align='left' class='dropdown_large_corr';   id='agency_" + klen + "' onkeydown=javascript:fillagency(event,id); />"
        createhtml += "<input  type='hidden' id='hdnagency_" + klen + "'>";
        createhtml += "<input  type='hidden' id='hdnretainslab_no_" + klen + "'>";
      // createhtml += "<input  type='hidden' id='check_" + klen + "'>";
      

        createhtml += "</td>"

        createhtml += "<td class='btextsmallsize'>"
        createhtml += "<input disabled type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='days_" + klen + "'  />"
        createhtml += "</td>"

        createhtml += "<td class='btextsmallsize'>"
        createhtml += "<input disabled type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='limit_" + klen + "'  />"
        createhtml += "</td>"

        createhtml += "<td class='btextsmallsize'>"
        createhtml += "<input disabled type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='recovery_" + klen + "'  />"
        createhtml += "</td>"

        createhtml += "<td  class='btextsmallsize'>"
        createhtml += "<input disabled width='50px'  type='text' class=\"text_grid\"   id=fromdate_" + klen + " style='text-align:right;  ' >"
        createhtml += "</td>"
        createhtml += "<td  class='btextsmallsize' >"
        createhtml += "<img disabled id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.fromdate_" + klen + ",'mm/dd/yyyy',event);\" />"
        createhtml += "</td>"

        createhtml += "<td width='50px' >"
        createhtml += "<input disabled width='50px'  type='text' class=\"text_grid\"   id=todate_" + klen + " style='text-align:right;  ' >"
        createhtml += "</td>"
        createhtml += "<td  width='10px' >"
        createhtml += "<img disabled id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.todate_" + klen + ",'mm/dd/yyyy',event);\" />"
        createhtml += "</td>"




        createhtml += "</tr>"


        createhtml += "</table>"
        var hdsview = "";
        temp_del1 = createhtml.toString();
        temp_del1 = temp_del1.replace("<TBODY>", "")
        temp_del1 = temp_del1.replace("</TBODY>", "")

        document.getElementById('hdsviewgrid').innerHTML = createhtml.toString();
    }



    // setButtonImages();
    return false;



}






///-----------------------------------------------------------------------------------------------------------------------

function getInternetExplorerVersion() {
    var rv = -1;
    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    return rv;
}
//---------------------------------------------------------------------------------------------------------------------
var gridlen = 0;
var counter = 0;
function creatnewrow() {
    insertnewrow = true;

    var createhtml = new StringBuffer();
    var createhtml_nw = new StringBuffer(9999999999999);
    var klen = ""
    var aa = ""

    var brow_ver = "";
    var ver = getInternetExplorerVersion();
    if (ver > -1) {
        if (ver >= 9)
            brow_ver = "9.0";
        else if (ver == 8.0)
            brow_ver = "8.0";
        else if (ver == 7.0)
            brow_ver = "7.0";
        else if (ver == 6.0)
            brow_ver = "6.0";
    }
    counter++;
    if (confirm("Do You Want to add new Row!")) {
        if (document.getElementById("hdsviewgrid").children.length == "0") {
            klen = "0"
        }
        else {

            klen = counter;
        }

        if (brow_ver >= "9.0" || browser !== "Microsoft Internet Explorer") {

            if (trim(document.getElementById("hdsviewgrid").innerHTML) != "") {
                aa = document.getElementById("hdsviewgrid").innerHTML.replace("</tbody></table>", "")

                var agency = new Array()
                var agencycode = new Array()
                var days = new Array()
                var limit = new Array()
                var recovery = new Array()
                var fromdate = new Array()
                var todate = new Array()
                var slabno = new Array()



                for (var k = 0; k < klen; k++) {

                    agency[k] = document.getElementById('agency_' + k).value;
                    agencycode[k] = document.getElementById('hdnagency_' + i).value
                    days[k] = document.getElementById('days_' + k).value;
                    limit[k] = document.getElementById('limit_' + k).value;
                    recovery[k] = document.getElementById('recovery_' + k).value;
                    fromdate[k] = document.getElementById('fromdate_' + k).value;
                    todate[k] = document.getElementById('todate_' + k).value;
                    slabno[k] = document.getElementById('hdnretainslab_no_' + k).value;


                }
            }
            else {
                aa = "";

                createhtml.append("<table Width='680px' style='border:1px solid black' >")
                createhtml.append("<tr>")
                createhtml.append("<td class='btextsmallsize'>")
                createhtml.append("<input type='text' style='width:80px;' align='left' class='dropdown_large_corr';   id='agency_" + klen + "' onkeydown=javascript:fillagency(event,id); />")
                createhtml.append("<input  type='hidden' id='hdnagency_" + klen + "'>")
                createhtml.append("<input  type='hidden' id='hdnretainslab_no_" + klen + "'>")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize'>")
                createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='days_" + klen + "'  />")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize'>")
                createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='limit_" + klen + "'  />")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize'>")
                createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='recovery_" + klen + "'  />")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize' >")
                createhtml.append("<input width='50px'  type='text' class=\"text_grid\"   id=fromdate_" + klen + " style='text-align:right;  ' >")
                createhtml.append("</td>")
                createhtml.append("<td width='10px'>")
                createhtml.append("<img id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.fromdate_" + klen + ",'mm/dd/yyyy',event);\" />")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize' >")
                createhtml.append("<input width='50px'  type='text' class=\"text_grid\"   id=todate_" + klen + " style='text-align:right;  ' >")
                createhtml.append("</td>")
                createhtml.append("<td width='10px'>")
                createhtml.append("<img id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.todate_" + klen + ",'mm/dd/yyyy',event);\" />")
                createhtml.append("</td>")



                createhtml.append("</tr>")
                gridlen = gridlen + 1;
            }

        }

        else {
            if (document.getElementById("hdsviewgrid").innerHTML.indexOf("BORDER-RIGHT: #7daae3 1px solid") >= 0) {
                aa = document.getElementById("hdsviewgrid").innerHTML.replace("</TBODY></TABLE>", "")
            }
            else {
                aa = "";

                createhtml.append("<table Width='680px' style='border:1px solid black' >")
                createhtml.append("<tr>")
                createhtml.append("<td class='btextsmallsize'>")
                createhtml.append("<input type='text' style='width:80px;' align='left' class='dropdown_large_corr';   id='agency_" + klen + "' onkeydown=javascript:fillagency(event,id); />")
                createhtml.append("<input  type='hidden' id='hdnagency_" + klen + "'>")
                createhtml.append("<input  type='hidden' id='hdnretainslab_no_" + klen + "'>")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize'>")
                createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='days_" + klen + "'  />")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize'>")
                createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='limit_" + klen + "'  />")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize'>")
                createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='recovery_" + klen + "'  />")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize' >")
                createhtml.append("<input width='50px'  type='text' class=\"text_grid\"   id=fromdate_" + klen + " style='text-align:right;  ' >")
                createhtml.append("</td>")
                createhtml.append("<td width='10px'>")
                createhtml.append("<img id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.fromdate_" + klen + ",'mm/dd/yyyy',event);\" />")
                createhtml.append("</td>")

                createhtml.append("<td class='btextsmallsize' >")
                createhtml.append("<input width='50px'  type='text' class=\"text_grid\"   id=todate_" + klen + " style='text-align:right;  ' >")
                createhtml.append("</td>")
                createhtml.append("<td width='10px'>")
                createhtml.append("<img id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.todate_" + klen + ",'mm/dd/yyyy',event);\" />")
                createhtml.append("</td>")



                createhtml.append("</tr>")
                gridlen = gridlen + 1;
            }
        }



        createhtml.append("<table Width='680px' style='border:1px solid black' >")
        createhtml.append("<tr>")
        createhtml.append("<td class='btextsmallsize'>")
        createhtml.append("<input type='text' style='width:80px;' align='left' class='dropdown_large_corr';   id='agency_" + klen + "' onkeydown=javascript:fillagency(event,id); />")
        createhtml.append("<input  type='hidden' id='hdnagency_" + klen + "'>")
        createhtml.append("<input  type='hidden' id='hdnretainslab_no_" + klen + "'>")
        createhtml.append("</td>")

        createhtml.append("<td class='btextsmallsize'>")
        createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='days_" + klen + "'  />")
        createhtml.append("</td>")

        createhtml.append("<td class='btextsmallsize'>")
        createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='limit_" + klen + "'  />")
        createhtml.append("</td>")

        createhtml.append("<td class='btextsmallsize'>")
        createhtml.append("<input type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='recovery_" + klen + "'  />")
        createhtml.append("</td>")

        createhtml.append("<td class='btextsmallsize' >")
        createhtml.append("<input width='50px'  type='text' class=\"text_grid\"   id=fromdate_" + klen + " style='text-align:right;  ' >")
        createhtml.append("</td>")
        createhtml.append("<td width='10px'>")
        createhtml.append("<img id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.fromdate_" + klen + ",'mm/dd/yyyy',event);\" />")
        createhtml.append("</td>")

        createhtml.append("<td class='btextsmallsize' >")
        createhtml.append("<input width='50px'  type='text' class=\"text_grid\"   id=todate_" + klen + " style='text-align:right;  ' >")
        createhtml.append("</td>")
        createhtml.append("<td width='10px'>")
        createhtml.append("<img id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.todate_" + klen + ",'mm/dd/yyyy',event);\" />")
        createhtml.append("</td>")

        createhtml.append("</tr>")
        gridlen = gridlen + 1;
        createhtml.append("</table>")
        var createhtml_last = new StringBuffer(999999999999999);
        createhtml_last.append(aa.toString())
        createhtml_last.append(createhtml.toString())
        document.getElementById("hdsviewgrid").innerHTML = createhtml_last.toString();
        for (var k = 0; k < klen; k++) {


            document.getElementById('agency_' + k).value = agency[k]
            document.getElementById('hdnagency_' + i).value = agencycode[k]
            document.getElementById('days_' + k).value = days[k]
            document.getElementById('limit_' + k).value = limit[k]
            document.getElementById('recovery_' + k).value = recovery[k]
            document.getElementById('fromdate_' + k).value = fromdate[k]
            document.getElementById('todate_' + k).value = todate[k]
            document.getElementById('hdnretainslab_no_' + k).value = slabno[k]

        }

    }
    else {

    }
    return false;
}




/**********************Bind Agency By F2   **********************************************************/


function fillagency(event, id) {
    var keycode = event.keyCode ? event.keyCode : event.which;

    if (event.keyCode == 113) {
        document.getElementById('hdnagency').value = document.activeElement.id;
        var aTag = eval(document.getElementById(document.activeElement.id))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        }
        while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

        var tot = document.getElementById('divagency').scrollLeft;

        var scrolltop = document.getElementById('divagency').scrollTop;
        document.getElementById('divagency').style.display = "block";
        document.getElementById('divagency').style.left = "200px";
        document.getElementById('divagency').style.top = document.getElementById(document.getElementById('hdnagency').value).offsetTop + toppos - scrolltop + "px";
        document.getElementById('lstagency').focus();



        var compcode = document.getElementById('hiddencompcode').value;
        var fromdateformat = document.getElementById('hiddendateformat').value;
        var extra1 = "";
        var extra2 = "";
        var unit = "";
        var extra3 = "";
        var extra4 = "";
        var extra5 = "";

        retainpoup.bindagencyname(document.getElementById('hiddencompcode').value, "", document.getElementById('hiddenuserid').value, document.getElementById('hiddendateformat').value, "", "", "", "", "", bindreport_callback);
        return event.keyCode;
    }


}


function bindreport_callback(response) {
    var pkgitem = document.getElementById("lstagency");
    ds = response.value;
    if (ds == null) {
        pkgitem.style.width = "254px"
        pkgitem.options.length = 0;
    }
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        pkgitem.style.width = "254px"
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {

            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Type_Name + "~" + ds.Tables[0].Rows[i].Agency_Type_Code, ds.Tables[0].Rows[i].Agency_Type_Name);
            pkgitem.options.length;

        }

    }
    document.getElementById(document.getElementById('hdnagency').value).value = "";
    document.getElementById("lstagency").value = "0";
    document.getElementById("lstagency").focus();
    return false;
}















//------------------------
function insertagency(event) {

    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstagency") {
            var abc = "";
            document.getElementById("divagency").style.display = "none";
            var page = document.getElementById('lstagency').value;
            for (var k = 0; k <= document.getElementById("lstagency").length - 1; k++) {
                if (browser != "Microsoft Internet Explorer") {
                    abc = document.getElementById('lstagency').options[k].textContent;
                }
                else {
                    abc = document.getElementById('lstagency').options[k].innerText;
                }
                if (document.getElementById('lstagency').options[k].value == page) {
                    document.getElementById(document.getElementById('hdnagency').value).value = abc;
                    var splitmaincode = abc;
                    var str = splitmaincode.split("~");
                    var agcd = str[0];
                    var subagcd = str[1];

                    var activeid = document.getElementById('hdnagency').value;
//                    var id = activeid.substr(7, activeid.length);

                    //                    document.getElementById(document.getElementById('hdnagency').value).value = subagcd;
                    document.getElementById('hdnagency').value = subagcd;
                    document.getElementById('txtagency').value = agcd;



                    document.getElementById('txtcreditdays').focus();
                    return false;


                }

            }

        }




    }
    else if (event.keyCode == 27) {
        document.getElementById("divagency").style.display = "none";
        return false;


    }
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



function isnumKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode == 31 || charCode == 45) || (charCode == 8) || (charCode == 46) || (charCode >= 48 && charCode <= 57) || (charCode == 13)) {
        return true;
    }
    else
        alert("Please Fill Numeric Value");

    return false;
}

function cleardata() {
    for (var i = 0; i <= gridlen; i++) {
        document.getElementById('check_' + i).checked = false;
        
    }
    document.getElementById('hdnagency').value = ""
    document.getElementById('txtcreditdays').value = ""
    document.getElementById('txtcreditlimit').value = ""
    document.getElementById('txtrecovery').value = ""
    document.getElementById('txteffectivefrom').value = ""
    document.getElementById('txteffectiveto').value = ""

    document.getElementById('txtagency').value = ""
    document.getElementById('divagency').style.display = "none";
    datamodify = 0;
    return false;
}

function closepage() {
    if (confirm("Do You Want To Skip This Page")) {
        window.close();
        return false;
    }

    return false;
}


function datasubmit() {
    var inew = 0;
       
for (var i = 0; i <= gridlen; i++) {
        if (document.getElementById('check_' + i).checked == true)
        { 
    inew=i;
        }
        }

        if (document.getElementById('check_' + inew).checked == true) {
            mdy_save();
        }

        else {

            if (document.getElementById('hdnagency').value == "") {
                alert('Please Select Agency first')
                document.getElementById('txtagency').focus();
                return false;
            }
            if (document.getElementById('txteffectivefrom').value == "") {
                alert('Please Select Effective From first')
                document.getElementById('txteffectivefrom').focus();
                return false;
            }
            if (document.getElementById('txteffectiveto').value == "") {
                alert('Please Select Effective To first')
                document.getElementById('txteffectiveto').focus();

                return false;
            }






            var compcode = document.getElementById('hiddencompcode').value;
            var execcode = document.getElementById('hiddenretcode').value;
            var agencycode = document.getElementById('hdnagency').value
            var fromdate = document.getElementById('txteffectivefrom').value
            var todate = document.getElementById('txteffectiveto').value
            var dateformat = document.getElementById('hiddendateformat').value;

            var items = retainpoup.duplicasy(compcode, execcode, agencycode, fromdate, todate, dateformat);
            var ds = items.value;

            if (ds.Tables[0].Rows[0].REC_COUNT >= 1) {

                alert("This Data is Already Exist ");

                //            blankfields();
                return false;

            }
            else {

                var compcode = document.getElementById('hiddencompcode').value;
                var agencycode = document.getElementById('hdnagency').value
                var days = document.getElementById('txtcreditdays').value
                var limit = document.getElementById('txtcreditlimit').value
                var recovery = document.getElementById('txtrecovery').value
                var fromdate = document.getElementById('txteffectivefrom').value
                var todate = document.getElementById('txteffectiveto').value
                var execcode = document.getElementById('hiddenretcode').value;
                var createdby = document.getElementById('hiddenuserid').value
                var createddt = document.getElementById('HDN_server_date').value
                var dateformat = document.getElementById('hiddendateformat').value;
                var updatedby = "";
                var updateddt = "";

                retainpoup.savedata(compcode, agencycode, days, limit, recovery, fromdate, todate, execcode, createdby, createddt, updatedby, updateddt, dateformat);

//                alert("Data Saved Succesfully")
                cleardata();
                search_data();
            }
            //  var string = datasave;
            //  document.getElementById('hdnexecval').value = datasave;
            //  retainpoup.execmast(retainpoup)

            document.getElementById('txtagency').focus();
            //  window.opener.document.getElementById('hiddenexecutive').value = string;
            return false;
        }
}




function excutegrid(res) {
    gridlen = 0;

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
    document.getElementById('clear').disabled = false;
    document.getElementById('del').disabled = false;

    if (document.getElementById("hdsviewgrid").children.length == "0") {
        klen = 0;

    }
    else {


        IntializeNumber = klen + 1;
    }



    if (document.getElementById("hdsviewgrid").innerHTML == "") {
        createhtml += "<table Width='700px' style='border:1px solid black' >"
        createhtml += "<tr>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'></td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agency Type<font color=red>[F2*] </font></td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Credit Days</td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Credit Limit</td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Recovery %</td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Effective From</td>"
        createhtml += "<td  bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'></td>"
        createhtml += "<td   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Effective TO</td>"
        createhtml += "<td  bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'></td>"
        createhtml += "</tr>"

        len = 1;


        createhtml += "<tr>"
        glength = 0;
        var expcount = dsmain.Tables[0].Rows.length;
        for (klen = 0; klen < expcount; klen++) {
            createhtml += "<td class='btextsmallsize'>"
            createhtml += "<input type='checkbox' style='width:10px;text-align:right;' align='left' id='check_" + klen + "' class='dropdown_large_corr';  onclick=javascript:fillvalueingrid(id);    />"
            createhtml += "</td>"


            createhtml += "<td class='btextsmallsize'>"
            var report = retainpoup.reportname_agency(document.getElementById('hiddencompcode').value, fndnull(dsmain.Tables[0].Rows[klen].AG_TYPE_CODE));
            if (report.value.Tables[0].Rows.length > 0) {
                var exec_name = report.value.Tables[0].Rows[0].AGENCY_NAME;

            }
            createhtml += "<input  disabled type='text' style='width:80px;' align='left' class='dropdown_large_corr';   id='agency_" + klen + "' onkeydown=javascript:fillagency(event,id);  value='" + fndnull(exec_name) + "'  />"
            createhtml += "<input  type='hidden' id='hdnagency_" + klen + "' value='" + fndnull(dsmain.Tables[0].Rows[klen].AG_TYPE_CODE) + "'>";
            createhtml += "<input  type='hidden' id='hdnretainslab_no_" + klen + "' value='" + fndnull(dsmain.Tables[0].Rows[klen].RETAIN_SLAB_SNO) + "'>";
            createhtml += "</td>"

            createhtml += "<td class='btextsmallsize'>"
            createhtml += "<input disabled type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='days_" + klen + "' value='" + fndnull(dsmain.Tables[0].Rows[klen].CREDIT_DAYS) + "' />"
            createhtml += "</td>"

            createhtml += "<td class='btextsmallsize'>"
            createhtml += "<input disabled type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='limit_" + klen + "' value='" + fndnull(dsmain.Tables[0].Rows[klen].CREDIT_LIMIT) + "' />"
            createhtml += "</td>"

            createhtml += "<td class='btextsmallsize'>"
            createhtml += "<input disabled type='text' style='width:80px;text-align:right;' align='left' class='dropdown_large_corr'; onkeypress=javascript:isnumKey(event);  id='recovery_" + klen + "' value='" + fndnull(dsmain.Tables[0].Rows[klen].RECOVERY_LIMIT) + "' />"
            createhtml += "</td>"

            createhtml += "<td  class='btextsmallsize'>"
            createhtml += "<input disabled width='50px'  type='text' class=\"text_grid\"   id=fromdate_" + klen + " style='text-align:right;' value='" + CHKDATE(dsmain.Tables[0].Rows[klen].EFF_FROM_DATE) + "' >"
            createhtml += "</td>"
            createhtml += "<td  class='btextsmallsize' >"
            createhtml += "<img id=calender_" + klen + " disabled  src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.fromdate_" + klen + ",'mm/dd/yyyy',event);\" />"
            createhtml += "</td>"

            createhtml += "<td width='50px' >"
            createhtml += "<input disabled  width='50px'  type='text' class=\"text_grid\"   id=todate_" + klen + " style='text-align:right;  '  value='" + CHKDATE(dsmain.Tables[0].Rows[klen].EFF_TILL_DATE) + "' >"
            createhtml += "</td>"
            createhtml += "<td  width='10px' >"
            createhtml += "<img disabled id=calender_" + klen + "   src=\"Images/cal1.gif\"   onclick=\"popUpCalendar(this,form1.todate_" + klen + ",'mm/dd/yyyy',event);\" />"
            createhtml += "</td>"





            createhtml += "</tr>"
            gridlen = gridlen + 1;
        }


        createhtml += "</table>"
        var hdsview = "";
        temp_del1 = createhtml.toString();
        temp_del1 = temp_del1.replace("<TBODY>", "")
        temp_del1 = temp_del1.replace("</TBODY>", "")

        document.getElementById('hdsviewgrid').innerHTML = createhtml.toString();
        gridlen = gridlen - 1;
    }



    // setButtonImages();
    return false;



}


function fndnull(myval) {
    if (myval == "undefined") {
        myval = "";
    }
    else if (myval == null) {
        myval = "";
    }
    return myval
}




function CHKDATE(userdate) {

    var mycondate = ""

    if (userdate == null || userdate == "") {
        mycondate = ""
        return mycondate
    }
    else {

        var myDate = new Date(userdate);
        var dd = myDate.getDate();
        var d;

        if (dd <= 9 && dd >= 1) {
            d = '0' + dd;
            dd = d;
        }
        var mm = myDate.getMonth() + 1;
        var m;
        if (mm <= 9 && mm >= 1) {
            m = '0' + mm;
            mm = m;
        }
        var year = myDate.getFullYear();
        if (document.getElementById('hiddendateformat').value == "mm/dd/yyyy") {
            mycondate = mm + "/" + dd + "/" + year;
        }
        else if (document.getElementById('hiddendateformat').value == "dd/mm/yyyy") {
            mycondate = dd + "/" + mm + "/" + year;
        }
        else {
            mycondate = yyyy + "/" + mm + "/" + dd;
        }


        return mycondate;

    }
}



function mdy_save() {
    for (var i = 0; i <= gridlen; i++) {
        if (document.getElementById('check_' + i).checked == true) {
            var compcode = document.getElementById('hiddencompcode').value;
            var agencycode = document.getElementById('hdnagency').value
            var days = document.getElementById('txtcreditdays').value
            var limit = document.getElementById('txtcreditlimit').value
            var recovery = document.getElementById('txtrecovery').value
            var fromdate = document.getElementById('txteffectivefrom').value
            var todate = document.getElementById('txteffectiveto').value
            var execcode = document.getElementById('hiddenretcode').value;
            var createdby = "";
            var createddt = "";
            var updatedby = document.getElementById('hiddenuserid').value;
            var updateddt = document.getElementById('HDN_server_date').value;
            var slab_no = document.getElementById('hdnretainslab_no_' + i).value;
            var dateformat = document.getElementById('hiddendateformat').value;


            retainpoup.modify_save(compcode, agencycode, days, limit, recovery, fromdate, todate, execcode, createdby, createddt, updatedby, updateddt, dateformat, slab_no)
        }
    }
       
//        else{
//            alert('please check checkbox')
//            return false;
//        }

//            alert('Data updated sucessfully')
            search_data();
    return false;
}



function datadel() {
    for (var i = 0; i <= gridlen; i++) {
        if (document.getElementById('check_' + i).checked == true) {
            var compcode = document.getElementById('hiddencompcode').value;

            var execcode = document.getElementById('hiddenretcode').value;

            var slab_no = document.getElementById('hdnretainslab_no_' + i).value;


            retainpoup.del_dta(compcode, execcode, slab_no)
        }
    }
    //alert('Data Delete sucessfully')

}


function fillvalueingrid(id) {
    var spl = id.split('_')
    var id = spl[1];
    for (var i = 0; i <= gridlen; i++) {
        if (i != id) {

            document.getElementById('check_' + i).checked = false;
        }
    }
    if (document.getElementById('check_' + id).checked == true) {
        var report = retainpoup.reportname_agency(document.getElementById('hiddencompcode').value, document.getElementById('hdnagency_' + id).value);
        if (report.value.Tables[0].Rows.length > 0) {
            var exec_name = report.value.Tables[0].Rows[0].AGENCY_NAME     }


        document.getElementById('txtagency').value = exec_name
        
        document.getElementById('txtcreditdays').value = document.getElementById('days_' + id).value
        document.getElementById('txtcreditlimit').value = document.getElementById('limit_' + id).value
        document.getElementById('txtrecovery').value = document.getElementById('recovery_' + id).value
        document.getElementById('txteffectivefrom').value = document.getElementById('fromdate_' + id).value
        document.getElementById('txteffectiveto').value = document.getElementById('todate_' + id).value
        document.getElementById('hdnagency').value = document.getElementById('hdnagency_' + id).value;
        
       
    }
    else {
        document.getElementById('hdnagency').value = ""
        document.getElementById('txtcreditdays').value = ""
        document.getElementById('txtcreditlimit').value =""
        document.getElementById('txtrecovery').value = ""
        document.getElementById('txteffectivefrom').value = ""
        document.getElementById('txteffectiveto').value = ""
       
        document.getElementById('txtagency').value =""
       
    }




}



function chkfield(event) {

    if (event.keyCode == "13" || event.keyCode == "9") {
        var key = event.keyCode;

        if (document.activeElement.id == "txtagency") {
            if (key == 13) {
                if (document.getElementById('txtagency').value == "") {

                    document.getElementById('txtagency').focus();
                    return false;
                }
                else {
                    document.getElementById('txtcreditdays').focus();
                    return false;
                }
            }
        }





        if (document.activeElement.id == "txtcreditdays") {
            if (key == 13) {
                if (document.getElementById('txtcreditdays').value == "") {
                    document.getElementById('txtcreditlimit').focus();
                    return false;
                }


                else {
                    document.getElementById('txtcreditlimit').focus();
                    return false;
                }
            }
        }

        if (document.activeElement.id == "txtcreditlimit") {
            if (key == 13) {
                if (document.getElementById('txtcreditlimit').value == "") {
                    document.getElementById('txtrecovery').focus();
                    return false;
                }


                else {
                    document.getElementById('txtrecovery').focus();
                    return false;
                }
            }
        }









        if (document.activeElement.id == "txtrecovery") {
            if (key == 13) {
                if (document.getElementById('txtrecovery').value == "") {

                    document.getElementById('txteffectivefrom').focus();

                    return true;
                }


                else {
                    document.getElementById('txteffectivefrom').focus();
                    return false;
                }
            }
        }

        if (document.activeElement.id == "txteffectivefrom") {
            if (key == 13) {
                if (document.getElementById('txteffectivefrom').value == "") {

                    document.getElementById('txteffectiveto').focus();

                    return true;
                }


                else {
                    document.getElementById('txteffectiveto').focus();
                    return false;
                }
            }
        }

        if (document.activeElement.id == "txteffectiveto") {
            if (key == 13) {
                if (document.getElementById('txteffectiveto').value == "") {

                    document.getElementById('submit').focus();

                    return true;
                }


                else {
                    document.getElementById('submit').focus();
                    return false;
                }
            }
        }
        return false;

    }

}



