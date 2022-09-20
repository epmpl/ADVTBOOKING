




var jq = jQuery.noConflict();
var browser = navigator.appName;
var mul_adamt_sum = 0;
var count21;
function onload()
{
    document.getElementById('txtcenter').value = document.getElementById('hiddencentername').value;
    document.getElementById('txtfromdate').value = "";
    document.getElementById('txttodate').value = "";
    document.getElementById('txtbnkslipdt').value = "";
    document.getElementById('txtvchno').value = "";
}


function submitdata()
{
    mul_adamt_sum = 0;
    if (document.getElementById('txtfromdate').value == "")
    {
        alert("Please fill from date");
        return false;
    }
    if (document.getElementById('txttodate').value == "")
    {
        alert("Please fill To  date");
        return false;
    }
    var compcode = document.getElementById('hiddencomcode').value;
    var branch_code = document.getElementById('hiddenbranchcode').value;
    var frmdt = document.getElementById('txtfromdate').value;
    var todt = document.getElementById('txttodate').value;
    var bankdt = document.getElementById('txtbnkslipdt').value;
    var vchno = document.getElementById('txtvchno').value;
    var extra1 = "";
    var extra2 = "";
    var extra3 = "";
    var extra4 = "";
    var extra5 = "";
    var extra6 = "";
    //document.getElementById('divdg1').style.display = "block"
    //document.getElementById('btnsubmit').click();
    var res = cash_recon_form.submit(compcode, branch_code, frmdt, todt, extra1, extra2, extra3, extra4, extra5, extra6);
    BindExpensesGrid(res);
    document.getElementById('btnsubmit').disabled = true;
    return false;
}


function ExpensesDetailHeader() {
    var hdsview = "";
    hdsview += "<table  id='ExpensesDetailTable' class='gridtable'>";
    hdsview += "<thead><tr>";
    hdsview += "<th style='width:18%; text-align:center;BackColor=#046791;'>Booking Id</th>";
    hdsview += "<th style='width:18%; text-align:center;BackColor=#046791;'>Booking Date</th>";
    hdsview += "<th style='width:18%; text-align:center;BackColor=#046791;'>Reciept No</th>";
    hdsview += "<th style='width:18%; text-align:center;BackColor=#046791;'>Reciept Date</th>";
    hdsview += "<th style='width:18%; text-align:center;BackColor=#046791;'>Reciept Amount</th>";
    hdsview += "<th><input id=\"checkall\" type=\"checkbox\" width='5px' value=\"Check-All\" OnClick=\"fillall(this);\"></th>";
    hdsview += "</tr></thead>";
    hdsview += "</table>";
    return hdsview;
}

function BindExpensesGrid(res) {
    count = 0;
    
    jq("#ExpensesView").empty();
    var ds = res.value;
    if (ds.Tables[0].Rows.length == 0) {
        alert("There is no data produced");
        return false;
        
    }
    var hdsview = "";
    hdsview += ExpensesDetailHeader();
    
    for (var m = 0; m < ds.Tables[0].Rows.length; m++)
    {

        
        
            hdsview += "<table   class='gridinputclass'>";
            hdsview += "<tr>"
            hdsview += "<td><input  name='Disable' class='gridinputclass' style='text-align:center;' disabled id=txtbkid_" + count + " value='" + ds.Tables[0].Rows[m].cio_booking_id + "'></td>"
            hdsview += "<td><input  name='Disable'  class='gridinputclass' style='text-align:left;' disabled  id=txtbkdt_" + count + " value='" + ds.Tables[0].Rows[m].date_time + "' ></td>"
            hdsview += "<td><input  name='Disable'  class='gridinputclass' style='text-align:left;' disabled  id=txtrcptno_" + count + " value='" + ds.Tables[0].Rows[m].Reciept_no + "' ></td>"
            hdsview += "<td><input  name='Disable'  class='gridinputclass' style='text-align:left;' disabled id=txtrcptdt_" + count + " value='" + ds.Tables[0].Rows[m].Reciept_date + "' ></td>"
            if (ds.Tables[0].Rows[m].Bill_amount == "" || ds.Tables[0].Rows[m].Bill_amount == null)
            {
                hdsview += "<td><input  name='Disable'  class='gridinputclass' style='text-align:left;' disabled  id=txtbillamt_" + count + " value='" + "0.0" + "'></td>"
            }
            else
            {
                hdsview += "<td><input  name='Disable'  class='gridinputclass' style='text-align:left;' disabled  id=txtbillamt_" + count + " value='" + ds.Tables[0].Rows[m].Bill_amount + "'></td>"
            }
            hdsview += "<input type=\"hidden\"  name='Disable'  class='gridinputclass' style='text-align:left;'   id=txtagencode_" + count + " value='" + ds.Tables[0].Rows[m].Agency_code + "'>"
            hdsview += "<input type=\"hidden\"  name='Disable'  class='gridinputclass' style='text-align:left;'   id=txtagensubcode_" + count + " value='" + ds.Tables[0].Rows[m].Agency_code + "'>"
            hdsview += "<td><input id=chk_" + count + " type=\"checkbox\"  value='' OnClick=\"fillamount(this);\"></td>"
            hdsview += "</tr>"
          
       
        count21 = count;
        count++;
    }
   
    hdsview += "</table>";
    jq('#ExpensesView').append(hdsview);
    document.getElementById('ExpensesView').style.dispaly = "block";
    return false;
}

function fillall(obj) {
    var chkcurr = obj.id;
    glo_break = true;
    if (document.getElementById('checkall').checked == true) {
        mul_adamt_sum = 0;
        mul_adamt = "txtbillamt_";
        chk = "chk_";
        document.getElementById('txtamt').value = "";
        for ( var i = 0; i < count; ++i) {
            chk = "chk_" + i;
            mul_adamt = "txtbillamt_" + i;
            document.getElementById(chk).disabled = false;
            document.getElementById(chk).checked = true;
            if (glo_break == true) {
                fillamount(chk);
            }
            else {
                document.getElementById(chk).checked = false;
                return false;
            }
        }
    }
    else {
        schk = "chk_";
        glo_break = true;
        for (var i = 0; i < count; ++i) {
            chk = "chk_" + i;
            mul_adamt = "txtbillamt_" + i;
            document.getElementById(chk).disabled = false;
            document.getElementById(chk).checked = false;
            if (glo_break == true) {
                fillamount(chk);
            }
            else {
                return false;
            }
        }
        document.getElementById('txtamt').value = Math.round(0, 2);
        mul_adamt_sum = 0
    }
}

/////////////////////////////////////////////////

var glochk_id;
function fillamount(obj) {
    if (typeof (obj) == "object")
        chk = obj.id;
    glochk_id = chk;
    var myval = "_st";
    if (chk.indexOf("_st") != -1) {
        var _m = 2
        var _n = 6;
    }
    else
        if (chk.indexOf("_tds") != -1) {
            var _m = 3
            var _n = 7;
        }
        else {
            var _m =4
            var _n = 7;
        }
    var chkcurr = chk.substring(_m, chk.length);
    var manualchk = chk.substring(_n, chk.length);
    if (manualchk == "")
        manualchk = chkcurr;
    mul_adamt = "txtbillamt_" + manualchk;

    //==================new changes
    var mul_bookid = "txtbkid_" + manualchk
    var mul_bookdt = "txtbkdt_" + manualchk

    var mul_rcptno = "txtrcptno_" + manualchk
    var mul_rcptdt = "txtrcptdt_" + manualchk
    
    //==============================

    //if (document.getElementById(chk).checked == true) {
    //    //============ new changes===========
    //    document.getElementById(mul_bookid).className = "Textbox18BillNumber_bold"
    //    document.getElementById(mul_bookdt).className = "Textbox18_bold"
    //    document.getElementById(mul_rcptno).className = "Textbox18BillNumber_bold"
    //    document.getElementById(mul_rcptamt).className = "numerictext1_bold"
    //}
    //else {
    //    //============ new changes===========
    //    document.getElementById(mul_bookid).className = "Textbox18BillNumber_bold"
    //    document.getElementById(mul_bookdt).className = "Textbox18_bold"
    //    document.getElementById(mul_rcptno).className = "Textbox18BillNumber_bold"
    //    document.getElementById(mul_rcptamt).className = "numerictext1_bold"
    //    if (glochk_id == mul_tds) {
    //    }
       /// else {
            //if (hds != true) {
                mul_adamt_sum = parseFloat(mul_adamt_sum) + parseFloat(document.getElementById(mul_adamt).value);
                //document.getElementById(mul_adamt).value = "";
                document.getElementById('txtamt').value = Math.round(mul_adamt_sum, 2);
                return false;
            //}
            //else {
            //    hds = false;
            //}
        //}
    //}
    if (glo_break == true) {
        chkall_work(manualchk);
    }
    else // last id
    {
        if (document.getElementById(chk).checked == true) {
            mul_adamt_sum = parseFloat(mul_adamt_sum) + parseFloat(document.getElementById(mul_adamt).value);
            document.getElementById('txtamt').value = roundNumber(mul_adamt_sum, 2);
        }
        else {
            mul_adamt_sum = parseFloat(mul_adamt_sum) - parseFloat(document.getElementById(mul_adamt).value);           
            document.getElementById('txtamt').value = roundNumber(mul_adamt_sum, 2);
        }
        return false;
    }
}




///////////////////////////////////////////////////

function chkall_work(gau) {
    var i = gau;
    var mul_adamt = "txtbillamt_" + i;
    mul_sum_tds_st = 0;
  
    if (document.getElementById(mul_adamt).value != "" && parseFloat(document.getElementById(mul_adamt).value) != 0) {       
        mul_adamt_sum = parseFloat(mul_adamt_sum) + parseFloat(document.getElementById(mul_adamt).value);
      
    }
    
    var roundamount1 = mul_adamt_sum;
    var roundamount1 = Math.round(roundamount1, 2);    
    document.getElementById('txtamt').value = roundamount1;
   
}



function savedata(obj) {
    if (typeof (obj) == "object")
        chk = obj.id;

    var depositnum = "";
    var compcode = document.getElementById('hiddencomcode').value;
    var branch_code = document.getElementById('hiddenbranchcode').value;
    var doctype = "RCP";
    var deposittype = document.getElementById('hiddenoptn').value;
    var depositdate = document.getElementById('txtbnkslipdt').value;
    if (deposittype == "C") {
         depositnum = document.getElementById('txtvchno').value;
    }
    else { 
        var compcode1 = document.getElementById('hiddencomcode').value;
        var deposittype1 = document.getElementById('hiddenoptn').value;
        var ds = cash_recon_form.count(compcode1, deposittype1);
         depositnum = ds.value.Tables[0].Rows[0].MAXNO;
    }

    var userid = document.getElementById('hiddenuserid').value;


    var extra1 = "";
    var extra2 = "";
    var extra3 = "";
    var extra4 = "";
    var extra5 = "";
    var extra6 = "";
    var extra7 = "";
    if (deposittype == "C") {
        if (document.getElementById('txtbnkslipdt').value == "") {
            alert("Please fill Voucher Date");
            return false;
        }
        if (document.getElementById('txtvchno').value == "") {
            alert("Please fill Voucher No.");
            return false;
        }
    }
    else {
        if (document.getElementById('txtbnkslipdt').value == "") {
            alert("Please fill Bank Slip Date");
            return false;
        }
    }
    for (var i = 0; i < count; ++i) {
        chk = "chk_" + i;
        
        
        if (document.getElementById(chk).checked == true) {
            var bkidnum1 = "txtbkid_" + i;
            var recptno1 = "txtrcptno_" + i;
            var recptdt1 = "txtrcptdt_" + i;
            var amount1 = "txtbillamt_" + i;
            var agmaincode1 = "txtagencode_" + i;
            var agsubcode1 = "txtagensubcode_" + i;


            var bkidnum = document.getElementById(bkidnum1).value;
            var recptno = document.getElementById(recptno1).value;
            var recptdt = document.getElementById(recptdt1).value;
            var amount = document.getElementById(amount1).value;
            var agmaincode = document.getElementById(agmaincode1).value;
            var agsubcode = document.getElementById(agsubcode1).value;

            cash_recon_form.savedata(compcode, branch_code, doctype, bkidnum, recptno, recptdt, amount, agmaincode, agsubcode, deposittype, depositnum, depositdate, userid, extra1, extra2, extra3, extra4, extra5, extra6, extra7);
        }

    }
    alert("Data Saved successfully");
    document.getElementById('btnsubmit').disabled = false;
    return false;
}
