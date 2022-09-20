    function submi() {
        if ( document.getElementById('txtfromdate').value == "") {
            alert("Please Enter From Date")
             document.getElementById('txtfromdate').focus();
            return false;
        }
        if ( document.getElementById('txttodate').value == "") {
            alert("Please Enter To Date")
             document.getElementById('txttodate').focus();
            return false;
        }
         if(browser!="Microsoft Internet Explorer")
    {
   chmandat=document.getElementById('lbbookingid').textContent;
      
      
       
        if(chmandat.indexOf('*')>= 0)
        {
         if ( document.getElementById('txtbookiid').value == "") {
            alert("Please Enter Booking ID")
             document.getElementById('txtbookiid').focus();
            return false;
        }
        }
        
         chmandat=document.getElementById('lbPublicationCenter').textContent;
      
      
       
        if(chmandat.indexOf('*')>= 0)
        {
         if ( document.getElementById('dppubcent').value == "" ||document.getElementById('dppubcent').value == "0") {
            alert("Please Select Booking Center")
             document.getElementById('dppubcent').focus();
            return false;
        }
        }
        
        }
        else
        {
         chmandat=document.getElementById('lbbookingid').innerText;
      
      
       
        if(chmandat.indexOf('*')>= 0)
        {
         if ( document.getElementById('txtbookiid').value == "") {
            alert("Please Enter Booking ID")
             document.getElementById('txtbookiid').focus();
            return false;
        }
        }
        
        chmandat=document.getElementById('lbPublicationCenter').innerText;
      
      
       
        if(chmandat.indexOf('*')>= 0)
        {
         if ( document.getElementById('dppubcent').value == "" ||document.getElementById('dppubcent').value == "0") {
            alert("Please Select Booking Center")
             document.getElementById('dppubcent').focus();
            return false;
        }
        }
        
        }
        
        var fdate = document.getElementById('txtfromdate').value;
        var todate = document.getElementById('txttodate').value;
      
        var logincenter=document.getElementById("hiddencentercode").value;
   var bookingcenter=document.getElementById("dppubcent").value;
    var holdtype=document.getElementById("drpbillholdtype").value;
  var bookini=document.getElementById("txtbookiid").value;
        var compcode = document.getElementById('hiddencompcode').value;
      
        
        var dateformat = document.getElementById('hiddendateformat').value;
        if (document.getElementById('txtfromdate').value != "") {
            if (document.getElementById('txtfromdate').value != "") {
                if (dateformat == "dd/mm/yyyy") {
                    var txt = document.getElementById('txtfromdate').value;
                    var txt1 = txt.split("/");
                    var dd = txt1[0];
                    var mm = txt1[1];
                    var yy = txt1[2];
                    fdate = mm + '/' + dd + '/' + yy;
                }
                else if (dateformat == "mm/dd/yyyy") {
                fdate = document.getElementById('txtfromdate').value;
                }

                else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txtfromdate').value;
                    var txt1 = txt.split("/");
                    var yy = txt1[0];
                    var mm = txt1[1];
                    var dd = txt1[2];
                    fdate = mm + '/' + dd + '/' + yy;
                }
            }
        }
        var todate;
        if (document.getElementById('txttodate').value != "") {
            if (document.getElementById('txttodate').value != "") {
                if (dateformat == "dd/mm/yyyy") {
                    var txt = document.getElementById('txttodate').value;
                    var txt1 = txt.split("/");
                    var dd = txt1[0];
                    var mm = txt1[1];
                    var yy = txt1[2];
                    todate = mm + '/' + dd + '/' + yy;
                }
                else if (dateformat == "mm/dd/yyyy") {
                todate = document.getElementById('txttodate').value;
                }
                else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txttodate').value;
                    var txt1 = txt.split("/");
                    var yy = txt1[0];
                    var mm = txt1[1];
                    var dd = txt1[2];
                    todate = mm + '/' + dd + '/' + yy;
                }
            }
        }
//        if (status == "N") {
            var bran = "";
            billholdclearance.Fetch( fdate, todate,bookingcenter,holdtype,bookini, compcode, dateformat,logincenter,document.getElementById("hiddenuserid").value,"","", call_data)
//        }
////        else if (status == "Y") {
//            var bran = "";
//            agencyunblock.exe(compcode, pcenter, savebranchcode, status, fdate, todate, nam1, nam2, suspendtype, uid, call_datas)
//        }
        //    document.getElementById('bntsub').disabled = true;
        return false;
    }
    var datafetch = ""
    function call_data(resd) {
        data1 = resd.value
        datafetch = resd.value
        var finaldata = "";
        if (data1.Tables[0].Rows.length > 0) {
            datalength = data1.Tables[0].Rows.length;


            finaldata = "<table border=1 width=100%>"
            finaldata += "<tr><td width='2%'bgcolor=#7DAAE3  style='font-size:12px;font-weight:bold;display:none;text-align:left;border:1px solid #7DAAE3;'><input id=Chk_all_box type=checkbox onclick=chkall_123('no') ></td>";
            finaldata += "<td width='3%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>S.No.</td>";
            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Invoice No.</td>";
            finaldata += "<td width='24%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agency</td>";
            finaldata += "<td width='3%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Insertions</td>";
            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Edition</td>";
            finaldata += "<td width='25%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Client</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Gross Amount</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Commision</td>";
            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Bill Amt</td>";
            finaldata += "<td width='8%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Publish Date</td></tr>";
           

//            finaldata += "<td width='5%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Client</td>";
//            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Agency</td>";
//            finaldata += "<td width='10%' align=center bgcolor=#7DAAE3 style='font-size:12px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Insert ID</td></tr>";
          
            //finaldata+="</table>";

            for (i = 0; i < datalength; i++) {
          
             
                finaldata += "<tr><td style='display:none;'><input  type='CheckBox' width='2%' id='chkdel_" + i + "' ></td><td width='3%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" +(i+1) + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BILL_NO) + "</td><td width='24%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].Agency) + "</td><td width='3%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].no_of_insertion) + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].edition) + "</td><td width='25%' class='clickFieldinGrid'    align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].client) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].Gross_Rate) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].Commission) + "</td><td width='5%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].Bill_Amt) + "</td><td width='8%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].pub_date) + "</td></tr>"//<td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].BLOCK_REASON) + "</td><td width='10%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].UNBLOCK_BY) + "</td><td width='15%' align=center  style='font-size:10px;text-align:center;border:1px solid #7DAAE3;'>" + fndnull(data1.Tables[0].Rows[i].SUSPEND_TYPE) + "</td><td><input type='CheckBox' width='25px' id='chkdel_" + i + "' ></td></tr>"
            }
            finaldata += "</table>";
            document.getElementById("result").innerHTML = finaldata;
if(document.getElementById("drpbillholdtype").value!="C")
            {
             document.getElementById("btnsave").disabled = false; 
             document.getElementById("btnmodify").disabled = false; 
             
            }
        }
        else {
            alert("There is no data")
        clear1();
            return false;
        }
        return false;
    }
    
    
    
     function fndnull(myval) {
        if (myval == "undefined") {
            myval = "&nbsp";
        }
        else if (myval == null) {
            myval = "&nbsp";
        }
        else if (myval == "") {
            myval = "&nbsp";
        }
        return myval
    }
    
        function chkall_123() {
        var dtlen = document.getElementById("result").childNodes[0].childNodes[0].children.length;
        if (dtlen > 1) {
            if (document.getElementById("Chk_all_box").checked == true) {
                for (i = 0; i < datalength; i++) {
                    document.getElementById("chkdel_" + i).checked = true;
                }
            }
            else {
                for (i = 0; i < datalength; i++) {
                    document.getElementById("chkdel_" + i).checked = false;
                }
            }
        }
        else {
            return false;
        }
    }
    
    function clear1()
    {
    
    document.getElementById('txtfromdate').value="";
    document.getElementById('txttodate').value="";
    document.getElementById("dppubcent").value="0";
    document.getElementById("drpbillholdtype").value="U";
    document.getElementById("txtbookiid").value="";
    document.getElementById("btnsave").disabled = true; 
    document.getElementById("result").innerHTML ="";
      return false; 
    
    }
    
    
    
     function exit() {
        if (confirm("Do you want to skip this page ?")) {
            window.close();
            return false;
        }
        return false;
    }
    
    function saveclick() {
     var compcode = document.getElementById('hiddencompcode').value;
    var bookingcenter=document.getElementById("dppubcent").value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var billdate =data1.Tables[0].Rows[0].BILL_DATE.replace("-","/").replace("-","/");
    if (document.getElementById('txtfromdate').value != "") {
            if (billdate != "") {
                if (dateformat == "dd/mm/yyyy") {
                    var txt = billdate;
                    var txt1 = txt.split("/");
                    var dd = txt1[0];
                    var mm = txt1[1];
                    var yy = txt1[2];
                    billdate = mm + '/' + dd + '/' + yy;
                }
                else if (dateformat == "mm/dd/yyyy") {
                fdate = billdate;
                }

                else if (dateformat == "yyyy/mm/dd") {
                var txt = billdate;
                    var txt1 = txt.split("/");
                    var yy = txt1[0];
                    var mm = txt1[1];
                    var dd = txt1[2];
                    billdate = mm + '/' + dd + '/' + yy;
                }
            }
        }
    
    
    
         var result = billholdclearance.savebillhold(compcode, bookingcenter, data1.Tables[0].Rows[0].Cio_Booking_Id ,data1.Tables[0].Rows[0].Bill_cycle,document.getElementById("hiddenuserid").value, billdate, data1.Tables[0].Rows[0].BILL_NO, dateformat,"","","","","")
    }
    
    function report1()
    {
    
         if ( document.getElementById('txtfromdate').value == "") {
            alert("Please Enter From Date")
             document.getElementById('txtfromdate').focus();
            return false;
        }
        if ( document.getElementById('txttodate').value == "") {
            alert("Please Enter To Date")
             document.getElementById('txttodate').focus();
            return false;
        }

        
        var fdate = document.getElementById('txtfromdate').value;
        var todate = document.getElementById('txttodate').value;
      
        var logincenter=document.getElementById("hiddencentercode").value;
   var bookingcenter=document.getElementById("dppubcent").value;
    var holdtype=document.getElementById("drpbillholdtype").value;
  var bookini=document.getElementById("txtbookiid").value;
        var compcode = document.getElementById('hiddencompcode').value;
      
        
        var dateformat = document.getElementById('hiddendateformat').value;
        if (document.getElementById('txtfromdate').value != "") {
            if (document.getElementById('txtfromdate').value != "") {
                if (dateformat == "dd/mm/yyyy") {
                    var txt = document.getElementById('txtfromdate').value;
                    var txt1 = txt.split("/");
                    var dd = txt1[0];
                    var mm = txt1[1];
                    var yy = txt1[2];
                    fdate = mm + '/' + dd + '/' + yy;
                }
                else if (dateformat == "mm/dd/yyyy") {
                fdate = document.getElementById('txtfromdate').value;
                }

                else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txtfromdate').value;
                    var txt1 = txt.split("/");
                    var yy = txt1[0];
                    var mm = txt1[1];
                    var dd = txt1[2];
                    fdate = mm + '/' + dd + '/' + yy;
                }
            }
        }
        var todate;
        if (document.getElementById('txttodate').value != "") {
            if (document.getElementById('txttodate').value != "") {
                if (dateformat == "dd/mm/yyyy") {
                    var txt = document.getElementById('txttodate').value;
                    var txt1 = txt.split("/");
                    var dd = txt1[0];
                    var mm = txt1[1];
                    var yy = txt1[2];
                    todate = mm + '/' + dd + '/' + yy;
                }
                else if (dateformat == "mm/dd/yyyy") {
                todate = document.getElementById('txttodate').value;
                }
                else if (dateformat == "yyyy/mm/dd") {
                var txt = document.getElementById('txttodate').value;
                    var txt1 = txt.split("/");
                    var yy = txt1[0];
                    var mm = txt1[1];
                    var dd = txt1[2];
                    todate = mm + '/' + dd + '/' + yy;
                }
            }
        }

            var bran = "";
          //  window.open(fdate, todate,bookingcenter,holdtype,bookini, compcode, dateformat,logincenter,document.getElementById("hiddenuserid").value,"","", call_data);
    window.open('billholdreport.aspx?fdate=' + fdate + '&todate=' + todate+'&bookingcenter='+bookingcenter+'&holdtype='+holdtype+'&bookini='+bookini+'&compcode='+compcode+'&dateformat='+dateformat+'&logincenter='+logincenter+'&userid='+document.getElementById("hiddenuserid").value);
    return false;
    }
    
    
    function  openpage()
{

var adtype=data1.Tables[0].Rows[0].Ad_type_code;



            if(adtype=="CL0")
            {
            
                 win=window.open('Classified_Booking.aspx?cioid='+data1.Tables[0].Rows[0].Cio_Booking_Id+'&userid='+document.getElementById('hiddenuserid').value+'&Billhold=Hold','','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');

            //window.open('Classified_Booking.aspx');
            }
else
            
            {
            // window.open('Booking_master.aspx');
             win=window.open('Booking_master.aspx?cioid='+data1.Tables[0].Rows[0].Cio_Booking_Id+'&userid='+document.getElementById('hiddenuserid').value+'&Billhold=Hold','','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');

            
            }
return false;
}