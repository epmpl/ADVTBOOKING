// JScript File

function changedivrate()
{
  if(document.getElementById('LinkButton4').disabled==true)
        return false;
 var adcategory=document.getElementById('drpadcategory').value;
 if(document.getElementById('txtratecode').options.length==1) 
 {  
    bindrategroupvode(adcategory);
 }   
if(document.getElementById('LinkButton1').disabled==false)
        {
      if(document.getElementById('drpretainer').disabled==false)
      {
        if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
        {
            alert('Please fill Executive Name or Retainer.');
          
                document.getElementById('drpretainer').focus();
            return false;
        }
       }       
      }      
    if(document.getElementById('LinkButton1').disabled==true)
        return false;
        if(document.getElementById('drpbooktype').value=="0")
{
    alert("Please Select Booking Type");
    return false;
}    
if(document.getElementById('drpcolor').value=="0")
{
    alert("Please Select Color");
    return false;
}   
if(document.getElementById('drpadcategory').value=="0")
{
    alert("Please Select Ad Category");
    return false;
}   
if(document.getElementById('drpuom').value=="0")
{
    alert("Please Select UOM");
    return false;
}  
if(document.getElementById('drppackagecopy').options.length==0)
{
    alert("Please Select Package");
    return false;
}  
if(document.getElementById('txtdummydate').value=="")
{
    alert("Please Enter Date");
    return false;
} 
if(document.getElementById('drpcurrency').value=="0")
{
    alert("Please Select Currency");
    return false;
}  
if(document.getElementById('txttotalarea').value=="")
{
    alert("Please Enter Size/Lines");
    return false;
}  
    if(enLink=="1")
     {
         document.getElementById('LinkButton1').disabled=false;
         document.getElementById('LinkButton2').disabled=false;
         document.getElementById('LinkButton3').disabled=false;
         document.getElementById('LinkButton4').disabled=false;
         document.getElementById('LinkButton5').disabled=false;
         document.getElementById('LinkButton6').disabled=false;
         document.getElementById('LinkButton7').disabled=false;
     }
    if(document.getElementById('LinkButton4').disabled==false)
    {		
        if(document.getElementById('txtagency').value=="")
        {
            alert("Please fill the agency name");
            document.getElementById('txtagency').focus();
            return false;
        }
        else if(document.getElementById('drpagscode').value=="" || document.getElementById('drpagscode').value=="0")
        {
            alert("Please select the agency sub code");
            if(document.getElementById('drpagscode').disabled==false)   
            document.getElementById('drpagscode').focus();
            return false;

        }
        if(document.getElementById('txtrono').value!="" && document.getElementById('txtrono').disabled==false)
         {
              if(document.getElementById('txtrodate').value=="")
              {
                  alert("Please fill ro date");
                  document.getElementById('txtrodate').focus();
                  return false;            
              }

          }
          
          
          
          
          
          
          
		
	    document.getElementById('LinkButton4').style.fontWeight="bold";
	    document.getElementById('LinkButton4').style.color="#FFFF80";
	    document.getElementById('LinkButton3').style.fontWeight="normal";
	    document.getElementById('LinkButton3').style.color="White";
	    document.getElementById('LinkButton2').style.fontWeight="normal";
	    document.getElementById('LinkButton2').style.color="White";
	    document.getElementById('LinkButton5').style.fontWeight="normal";
	    document.getElementById('LinkButton5').style.color="White";
	    document.getElementById('LinkButton1').style.fontWeight="normal";
	    document.getElementById('LinkButton1').style.color="White";
	    document.getElementById('LinkButton6').style.fontWeight="normal";
	    document.getElementById('LinkButton6').style.color="White";
	    document.getElementById('LinkButton7').style.fontWeight="normal";
	    document.getElementById('LinkButton7').style.color="White";
	    document.getElementById('tbvts').style.display="none";
	    //alert(document.getElementById('LinkButton1').click);
	    document.getElementById('tblrate').style.display="block";
	    if(document.getElementById('txtratecode').disabled==false)
	    {
	        document.getElementById('txtratecode').focus();
	    }
	    document.getElementById('tblbill').style.display="none";
	    document.getElementById('addetails').style.display="none";
	    document.getElementById('pagedetail').style.display="none";
		//document.getElementById('tblsize').style.display="none";
        document.getElementById('tblpackage').style.display="none";
        document.getElementById('tbbox').style.display="none";
        //retainer text box fill *4sep*



        if (hidcopy == "copy")
        {
            var count1 = document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length - 1;
            for (var j1 = 0; j1 < count1; j1++)
            {
                var paid = document.getElementById("pai" + j1);
                if (paid != null)
                {
                    paid.value = 'Y';
                }
            }
        }
        var objpack = document.getElementById('drppackagecopy');
        var temp = "";
        var tempcode = "";
        var tempval = "";
        var tempvalcode = "";
        var desc = "";
        var code = "";
        var i = objpack.options.length;
        var j;
        var temp_length = "";
        var temp_code = "";

        for (j = 0; j < i; j++) {
            if (parseInt(i) > 0) {
                tempval = objpack[j].value;
                //tempvalcode=objpack[j].value;
                if (temp != "") {
                    temp = tempval.split("@");
                    tempvalcode = temp[0];
                    tempcode = temp[1];


                    temp_length = parseInt(temp[1].split("(")[1].split(")")[0]);
                    if (temp_length == 1) {
                        temp_code = tempvalcode;
                    }
                    else {
                        for (var k1 = 0; k1 < temp_length; k1++) {

                            temp_code += tempvalcode + ",";

                        }
                        temp_code = temp_code.substring(0, temp_code.length - 1);
                    }


                    // code = temp_code;

                    code = temp_code + "," + code;
                    desc = tempcode + "," + desc;
                    temp_code = "";
                }
                else {
                    temp = tempval.split("@");
                    tempvalcode = temp[0];
                    tempcode = temp[1];
                    temp_length = parseInt(temp[1].split("(")[1].split(")")[0]);
                    if (temp_length == 1) {
                        temp_code = tempvalcode;

                    }
                    else {
                        for (var k1 = 0; k1 < temp_length; k1++) {

                            temp_code += tempvalcode + ",";

                        }
                        temp_code = temp_code.substring(0, temp_code.length - 1);
                    }


                    code = temp_code;

                    desc = tempcode;
                    temp_code = "";
                }
            }
        }



        var data = Classified_Booking.discount_count(document.getElementById('hiddencompcode').value, "CL0", code);
        edition_discount = "";

        if (data.value.Tables[0].Rows.length > 0) {


            if (data.value.Tables[0].Rows[0].DISCOUNT == null) {
                document.getElementById('txtspediscper').value = parseInt("0");
            }
            else {

                document.getElementById('txtspediscper').value = data.value.Tables[0].Rows[0].DISCOUNT;
            }

        }
  
        
        
        if(document.getElementById('drpretainer').value!="" && document.getElementById('drpretainer').value!="0" && document.getElementById('txtRetainercomm').value=="")
        {
            document.getElementById('txtRetainercomm').value="";
            var retain_name=document.getElementById('drpretainer').value.split('(');
            if(retain_name.length>1)
           {
            var retain_code=retain_name[1].replace(')','');
            var ds_ret=Classified_Booking.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);
            
            if(ds_ret.value==null)
                return false;
               
            if(ds_ret.value.Tables[0].Rows.length>0)
                document.getElementById('txtRetainercomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
           }
               
        }
		//getrateonchangecurr();
		 return false;
	}
}
//check dateformat
function checkdate(input)
{
    var dateformat=document.getElementById('hiddendateformat').value;
    if(dateformat=="mm/dd/yyyy") 
    {
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/  
    }
    
    if(dateformat=="yyyy/mm/dd") 
    {
        var validformat=/^\d{4}\/\d{2}\/\d{2}$/ 
    }
    
    if(dateformat=="dd/mm/yyyy")
    {
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/ 
    }

    if (!validformat.test(input.value))
    {
        if(input.value=="")
           return true;
        
       // setTimeout(settime12,15);
       if(document.activeElement.id.indexOf('nand')<0 && document.activeElement.id!='')
        {
            alert(" Please Fill The Date In "+dateformat+" Format");
            input.value="";
            return;
        }
    }
    else
    { //Detailed check for valid date ranges
        if(dateformat=="yyyy/mm/dd")
        {
            var yearfield=input.value.split("/")[0]
            var monthfield=input.value.split("/")[1]
            var dayfield=input.value.split("/")[2]
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
        if(dateformat=="mm/dd/yyyy")
        {
            var yearfield=input.value.split("/")[2]
            var monthfield=input.value.split("/")[0]
            var dayfield=input.value.split("/")[1]
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
        
        if(dateformat=="dd/mm/yyyy")
        {
            var yearfield=input.value.split("/")[2]
            var monthfield=input.value.split("/")[1]
            var dayfield=input.value.split("/")[0]
            //var dayobj = new Date(dayfield, monthfield-1, yearfield)
            var dayobj = new Date(yearfield, monthfield-1, dayfield)
        }
    } //end of else


    var abcd= dayobj.getMonth()+1;
    var date1=dayobj.getDate();
    var year1=dayobj.getFullYear();
    if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
    {
        alert(" Please Fill The Date In "+dateformat+" Format");
        input.value="";
        return false;
    }    
    input.select()
    return true
}
function showgridexecute1(hidcopy) {
    var msg = checkSession();
    if (msg == false) {
        window.location.href = "login.aspx";
        return false;
    }
    var cioid = document.getElementById('txtciobookid').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var call_show = Classified_Booking.showgridforexe(cioid, compcode);
    call_showgrid1(call_show);
    return false;
}
function call_showgrid1(res) {
var ds=res.value;
    var dateformat = document.getElementById('hiddendateformat').value;
    var showordisable = document.getElementById('hiddensavemod').value;
    var noinsertgrid = document.getElementById('txtinsertion').value;
    var column_vari = document.getElementById('txtcolum');
    var hiddenuomdesc_vari = document.getElementById('hiddenuomdesc');
    var drppagepos_vari = document.getElementById('drppageposition');
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        //this is the for loop we are implementing so that the rows appear the same as the rows in tbl_booking_insert table
        var count = ds.Tables[0].Rows.length - 1;
        var i = 0;
        if (showordisable == "1") {
           //str = str + "<td valign=\"top\" id='uploadA' disabled >Upload</td><td></td><td></td><td valign=\"top\" >VTS</td>";
           //document.getElementById('uploadA').style.
       }
       else {
           document.getElementById('uploadA').disabled = false;
           document.getElementById('uploadA').style.color = "Red";
           document.getElementById('uploadA').style.cursor = "pointer";
       }
        
        for (i = 0; i <= count; i++) {
            var id = "Text" + i;
            if (showordisable != "1" && ds.Tables[0].Rows[i].Insert_status != "billed" && (ds.Tables[0].Rows[i].Insert_status != "publish" && document.getElementById('hiddenrateauditflag').value != "rateaudit" && document.getElementById('hiddenrateauditpreferrence').value != "Y"))
                document.getElementById('btnshgrid').disabled = false;
            var mode = "1";
            var insdat = ds.Tables[0].Rows[i].Insert_date
            if (insdat == "" || insdat == null || insdat == "null")
                var getdateforexe = "";
            else
                var getdateforexe = savedateinto(ds.Tables[0].Rows[i].Insert_date, mode);
            var billdate = ds.Tables[0].Rows[i].BILL_DATE;
            if (billdate == "" || billdate == null || billdate == "null")
                billdate = "";
            else
                billdate = savedateinto(billdate, mode);
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "") && hidcopy != "copy"))) {
                if (ds.Tables[0].Rows[i].Insert_status != "cancel" && showordisable == "01") {
                    var t_res = compareDatewithBilledDate(dateformat, getdateforexe, billdate);
                    if (t_res == true)
                        document.getElementById(id).disabled = false;
                    else
                        document.getElementById(id).disabled = true;
                }
                else
                    document.getElementById(id).disabled = true;
                
            }
            else {
                document.getElementById(id).disabled = false;
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                var t_res = compareDatewithBilledDate(dateformat,billdate ,document.getElementById('currdate').value);
                if (t_res == true && ds.Tables[0].Rows[i].Insert_status == "billed" && document.getElementById('ena_adsubcataftbill').value == "Y")
                    document.getElementById("ads" + i).disabled = false;
                else
                           document.getElementById("ads" + i).disabled = true;
            }
            else {
                if (i == 0) {
                    document.getElementById("ads" + i).disabled = false;
                }
                else {
                    document.getElementById("ads" + i).disabled = false;
                }
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                document.getElementById("col" + i).disabled = true;
            }
            else {
                document.getElementById("col" + i).disabled = false;
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                document.getElementById("hei" + i).disabled = true;
                document.getElementById("wid" + i).disabled = true;
                document.getElementById("nocol" + i).disabled = true;
                document.getElementById("siz" + i).disabled = true;
            }
            else {
                if (hiddenuomdesc_vari.value == "CD" && column_vari.value == "") {
                    document.getElementById("hei" + i).disabled = false;
                    document.getElementById("wid" + i).disabled = false;                    
                }
                else if (hiddenuomdesc_vari.value == "CD" && column_vari.value != "") {
                }
                else {
                    document.getElementById("siz" + i).disabled = false;                    
                    document.getElementById("splboldsize" + i).disabled = false;

                }
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                if (ds.Tables[0].Rows[i].Status_material != null) {
                    document.getElementById("mat" + i).disabled = true;
                }
                else {
                    document.getElementById("mat" + i).disabled = true;
                }
            }
            else {
                if (ds.Tables[0].Rows[i].Status_material == null) {
                    document.getElementById("mat" + i).disabled = false;
                }
                else {
                    document.getElementById("mat" + i).disabled = false;
                }
            }
            if (hidcopy == "copy") {
                document.getElementById("inssta" + i).disabled = true;
                      document.getElementById("inssta" + i).value="booked";
            }
            else if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                document.getElementById("inssta" + i).disabled = true;
            }
            else {
                document.getElementById("inssta" + i).disabled = false;
            }
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[23].childNodes[79].childNodes[0].nodeValue == "enable") {
                    if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                        document.getElementById("resno" + i).disabled = true;
                    }
                    else {
                        document.getElementById("resno" + i).disabled = false;
                    }
                }
            }
            else {
                if (xmlObj.childNodes(11).childNodes(39).text == "enable") {
                    if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                        document.getElementById("resno" + i).disabled = true;
                    }
                    else {
                        document.getElementById("resno" + i).disabled = false;
                    }
                }
            }
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[23].childNodes[77].childNodes[0].nodeValue == "enable") {
                    if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                        document.getElementById("seccode" + i).disabled = true;
                    }
                    else {
                        document.getElementById("seccode" + i).disabled = false;
                    }
                }
            }
            else {
                if (xmlObj.childNodes(11).childNodes(38).text == "enable") {
                    if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                        document.getElementById("seccode" + i).disabled = true;
                    }
                    else {
                        document.getElementById("seccode" + i).disabled = false;
                    }
                }
            }
            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[1].childNodes[0].nodeValue != "hide") {
                    if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                        document.getElementById("lat" + i).disabled = true;
                    }
                    else {
                        document.getElementById("lat" + i).disabled = false;
                    }
                }
                else {
                    document.getElementById("lat" + i).disabled = false;
                }
                if (xmlObj.childNodes[25].childNodes[3].childNodes[0].nodeValue != "hide") {
                    if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                        document.getElementById("rep" + i).disabled = true;
                    }
                    else {
                        document.getElementById("rep" + i).disabled = false;
                    }
                }
                else {
                    document.getElementById("rep" + i).disabled = false;
                }

            }
            else {
                if (xmlObj.childNodes[12].childNodes[0].childNodes[0].nodeValue != "hide") {
                    if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                        document.getElementById("lat" + i).disabled = true;
                    }
                    else {
                        document.getElementById("lat" + i).disabled = false;
                    }
                }
                else {
                    document.getElementById("lat" + i).disabled = false;
                }
                if (xmlObj.childNodes[12].childNodes[1].childNodes[0].nodeValue != "hide") {
                    if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                        document.getElementById("rep" + i).disabled = true;
                    }
                    else {
                        document.getElementById("rep" + i).disabled = false;
                    }
                }
                else {
                    document.getElementById("rep" + i).disabled = false;
                }

            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) && hidcopy != "copy")) {
                document.getElementById("pgpre" + i).disabled = true;
                document.getElementById("pagper" + i).disabled = true;
            }
            else {
                document.getElementById("pgpre" + i).disabled = false;
                document.getElementById("pagper" + i).disabled = false;
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                var t_res = compareDatewithBilledDate(dateformat,billdate, document.getElementById('currdate').value);
                if (t_res==true && ds.Tables[0].Rows[i].Insert_status == "billed" && document.getElementById('ena_adsubcataftbill').value == "Y")
                    document.getElementById("adcat" + i).disabled = false;
                else
                document.getElementById("adcat" + i).disabled = true;
            }
            else {
                document.getElementById("adcat" + i).disabled = false;
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy"))
                document.getElementById("bill" + i).disabled = true;
            else
                document.getElementById("bill" + i).disabled = false;

            if (browser != "Microsoft Internet Explorer") {
                if (xmlObj.childNodes[25].childNodes[13].childNodes[0].nodeValue != "hide") {
                    if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ds.Tables[8].Rows[0].Paid_permission == "0" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                        document.getElementById("disc_" + i).disabled = true;
                    }
                    else if (document.getElementById('hiddisceditgrid').value == "Y")
                        document.getElementById("disc_" + i).disabled = false;
                    else
                        document.getElementById("disc_" + i).disabled = true;
                }
                if (xmlObj.childNodes[23].childNodes[37].childNodes[0].nodeValue != "enable") {
                    document.getElementById("pai" + i).disabled = true;
                }
                else {
                    if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ds.Tables[8].Rows[0].Paid_permission == "0" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                        document.getElementById("pai" + i).disabled = true;
                    }
                    else {
                        if (ds.Tables[8].Rows[0].Paid_permission == "0") {
                            document.getElementById("pai" + i).disabled = true;
                        }
                        else {
                            document.getElementById("pai" + i).disabled = false;
                        }
                    }
                }
            }
            else {
                if (xmlObj.childNodes[12].childNodes[6].childNodes[0].nodeValue != "hide") {
                    if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ds.Tables[8].Rows[0].Paid_permission == "0" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                        document.getElementById("disc_" + i).disabled = true;
                    }
                    else if (document.getElementById('hiddisceditgrid').value == "Y")
                        document.getElementById("disc_" + i).disabled = false;
                    else
                        document.getElementById("disc_" + i).disabled = true;
                }
                if (xmlObj.childNodes[11].childNodes[18].childNodes[0].nodeValue != "enable") {
                    document.getElementById("pai" + i).disabled = true;
                }
                else {
                    if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ds.Tables[8].Rows[0].Paid_permission == "0" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                        document.getElementById("pai" + i).disabled = true;
                    }
                    else {
                        if (ds.Tables[8].Rows[0].Paid_permission == "0") {
                            document.getElementById("pai" + i).disabled = true;
                        }
                        else {
                            document.getElementById("pai" + i).disabled = false;
                        }
                    }
                }
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) && hidcopy != "copy")) {
                document.getElementById("pagno" + i).disabled = true;
            }
            else {
                document.getElementById("pagno" + i).disabled = false;
            }
            if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                document.getElementById("cap" + i).disabled = true;
            }
            else {
                document.getElementById("cap" + i).disabled = false;
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                document.getElementById("rem" + i).disabled = true;
            }
            else {
                document.getElementById("rem" + i).disabled = false;
            }
            if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                document.getElementById("upload" + i).disabled = true;
            }
            else {
                document.getElementById("upload" + i).disabled = false;
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                document.getElementById("vtsbtn" + i).disabled = true;
            }
            else {
                document.getElementById("vtsbtn" + i).disabled = false;
            }            
        }
    }
}
function executeClick1() {
    if (document.getElementById('txtciobookid').value == "" && document.getElementById('txtdockitno1').value == "" && document.getElementById('txtkeyno').value == "" && document.getElementById('txtrono').value == "" && document.getElementById('txtagency').value == "" && document.getElementById('txtclient').value == "") {
        alert("Please Select Booking Id or one another Filter")
        return false;
    }
    boxstatus = "";
    if (rownumEx == undefined || rownumEx == "undefined")
        rownumEx = 0;
    var msg = checkSession();
    if (msg == false) {
        window.location.href = "login.aspx";
        return false;
    }
    //if (document.activeElement.id == "btnExecute") {
        if (document.getElementById('hiddencopybooking').value == "y") {
            if (confirm("Do you want to copy the data ?")) {
                hidcopy = "copy";
            }
            else {
                hidcopy = "";
            }
        }
    //}
    //dan
    var strtextd = "";
    chkbtnStatus = "execute";
    var httpRequest = null;
    httpRequest = new XMLHttpRequest();
    if (httpRequest.overrideMimeType) {
        httpRequest.overrideMimeType('text/xml');
    }
    //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

    httpRequest.open("GET", "checksessiondan.aspx", false);
    httpRequest.send('');
    //alert(httpRequest.readyState);
    if (httpRequest.readyState == 4) {
        //alert(httpRequest.status);
        if (httpRequest.status == 200) {
            strtextd = httpRequest.responseText;
        }
        else {
            //alert('There was a problem with the request.');
            if (browser != "Microsoft Internet Explorer") {
                //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
            }
        }
    }
    if (strtextd != "sess") {
        alert('session expired');
        window.location.href = "Default.aspx";
        return false;
    }

    document.getElementById('tblinsert').innerHTML = '';
    document.getElementById('hiddensavemod').value = "1";
    document.getElementById('LinkButton1').disabled = false;
    document.getElementById('LinkButton2').disabled = false;
    document.getElementById('LinkButton3').disabled = false;
    document.getElementById('LinkButton4').disabled = false;
    document.getElementById('LinkButton5').disabled = false;
    document.getElementById('LinkButton6').disabled = false;
    document.getElementById('LinkButton7').disabled = false;

    //////////////////////////////////////////////////////////////////////////
    document.getElementById('txttranslationdisc').disabled = true;
    document.getElementById('txtpospremdisc').disabled = true;
    document.getElementById('txtdatetime').disabled = true;
    document.getElementById('txtbillwidth').disabled = true;
    document.getElementById('txtbillheight').disabled = true;
    document.getElementById('btnshgrid').disabled = true;
    //btnupload.Enabled = false;
    document.getElementById('txtRetainercommamt').disabled = true;
    document.getElementById('txtRetainercomm').disabled = true;
    document.getElementById('drpbooktype').disabled = true;
    document.getElementById('txtciobookid').disabled = true;
    // txtappby.Enabled = true;
    //txtaudit.Enabled = true;
    document.getElementById('txtrevisedate').disabled = true;
    document.getElementById('txtrono').disabled = true;
    document.getElementById('txtrodate').disabled = true;
    document.getElementById('txtMobile').disabled = true;
    document.getElementById('drpbillstatus').disabled = true;
    document.getElementById('drprostatus').disabled = true;
    document.getElementById('txtagency').disabled = true;
    document.getElementById('txtclient').disabled = true;
    // txtagencyaddress.Enabled = true;
    document.getElementById('txtclientadd').disabled = true;
    document.getElementById('drpagscode').disabled = true;
    document.getElementById('txtdockitno1').disabled = true;
    document.getElementById('txtexecname').disabled = true;
    document.getElementById('txtexeczone').disabled = true;
    document.getElementById('txtproduct').disabled = true;
    document.getElementById('drpbrand').disabled = true;
    document.getElementById('txtkeyno').disabled = true;
    document.getElementById('txtbillremark').disabled = true;
    document.getElementById('txtprintremark').disabled = true;
    document.getElementById('drppackage').disabled = true;
    document.getElementById('txtinsertion').disabled = true;
    document.getElementById('txtdummydate').disabled = true;
    document.getElementById('txtrepeatingdate').disabled = true;
    document.getElementById('drpbooktype').disabled = true;
    document.getElementById('drpadcategory').disabled = true;
    document.getElementById('drpadsubcategory').disabled = true;
    document.getElementById('drpadcat3').disabled = true;
    document.getElementById('drpadcat4').disabled = true;
    document.getElementById('drpadcat5').disabled = true;
    document.getElementById('drpbgcolor').disabled = true;
    document.getElementById('drpcolor').disabled = true;
    document.getElementById('drpuom').disabled = true;
    document.getElementById('drppageposition').disabled = true;

    // txtadsizetypeheight.Enabled = true;
    //txtadsizetypewidth.Enabled = true;
    document.getElementById('txtratecode').disabled = true;
    document.getElementById('drpscheme').disabled = true;
    //  drpschemepck.Enabled = false;
    document.getElementById('drpcurrency').disabled = true;
    document.getElementById('drprptcurrency').disabled = true;
    document.getElementById('txtagreedrate').disabled = true;
    document.getElementById('txtagreedamt').disabled = true;

    document.getElementById('txtextracharges').disabled = true;
    document.getElementById('txtspedisc').disabled = true;
    document.getElementById('txtspediscper').disabled = true;
    document.getElementById('txtspacedisc').disabled = true;
    document.getElementById('txtspadiscper').disabled = true;
    document.getElementById('txtdatetime').disabled = true;
    document.getElementById('txtrepeatingdate').disabled = true;

    document.getElementById('drpbillcycle').disabled = true;
    document.getElementById('drprevenue').disabled = true;
    //drpbilltype.Enabled = true;
    document.getElementById('drpbillstatus').disabled = true;
    //drpbillcurrency.Enabled = true;
    document.getElementById('drppaymenttype').disabled = true;
    document.getElementById('txtinvoice').disabled = true;
    document.getElementById('txtvts').disabled = true;
    document.getElementById('txtcirrate').disabled = true;
    document.getElementById('txtciragency').disabled = true;
    document.getElementById('txtciredition').disabled = true;
    document.getElementById('txtbillwidth').disabled = true;
    document.getElementById('txtbillheight').disabled = true;
    document.getElementById('drpbillto').disabled = true;
    document.getElementById('txttradedisc').disabled = true;
    document.getElementById('chktrade').disabled = true;
    document.getElementById('txtagencyoutstand').disabled = true;
    document.getElementById('txtcardrate').disabled = true;
    document.getElementById('txtcardamt').disabled = true;
    document.getElementById('txtdiscount').disabled = true;
    document.getElementById('txtdiscpre').disabled = true;
    document.getElementById('txtadsize2').disabled = true;
    document.getElementById('txtadsize1').disabled = true;
    document.getElementById('txttotalarea').disabled = true;
    document.getElementById('txtbilladdress').disabled = true;

    document.getElementById('drpboxcode').disabled = true;
    //txtboxno.Enabled = true;
    document.getElementById('txtboxaddress').disabled = true;

    document.getElementById('txtbillamt').disabled = true;

    document.getElementById('txtgrossamt').disabled = true;
    //checkinfo
    document.getElementById('ttextchqno').disabled = true;
    document.getElementById('ttextchqdate').disabled = true;
    document.getElementById('ttextchqamt').disabled = true;
    document.getElementById('ttextbankname').disabled = true;
    document.getElementById('drpourbank').disabled = true;
    document.getElementById('drpboxcode').disabled = true;
    document.getElementById('chkage').disabled = true;
    document.getElementById('chkclie').disabled = true;
    document.getElementById('chktfn').disabled = true;

    document.getElementById('txtboxaddress').disabled = true;
    document.getElementById('txtinsertion').disabled = true;

    document.getElementById('txtcolum').disabled = true;

    document.getElementById('txtboxno').disabled = true;

    ///////////////////////
    document.getElementById('txtcontractname').disabled = true;
    document.getElementById('txtcontracttype').disabled = true;
    document.getElementById('txtcardname').disabled = true;
    document.getElementById('drptype').disabled = true;
    document.getElementById('drpmonth').disabled = true;
    document.getElementById('drpyear').disabled = true;
    document.getElementById('txtcardno').disabled = true;
    document.getElementById('txtagencypaymode').disabled = true;

    document.getElementById('btncopy').disabled = true;
    document.getElementById('btndel').disabled = true;
    document.getElementById('btnshgrid').disabled = true;
    document.getElementById('btndeal').disabled = true;
    document.getElementById('drpmatstat').disabled = true;
    document.getElementById('drpdiscountprem').disabled = true;
    document.getElementById('drpbullet').disabled = true;
    document.getElementById('drpretainer').disabled = true;
    if (document.getElementById('txtaddagencycommrate') != null) {
        document.getElementById('txtaddagencycommrate').disabled = true;
        document.getElementById('txtaddagencycommrateamt').disabled = true;
    }

    ///////////////////////////////////////////////////////////////////////////

    // document.getElementById('txtciobookidv').disabled = true;
    document.getElementById('Button1').disabled = true;
    var ciobookid = document.getElementById('txtciobookid').value;
    document.getElementById('hiddencioid').value = ciobookid;
    gciobookid = ciobookid;
    var docno = document.getElementById('txtdockitno1').value;
    gdockitno = docno;
    var keyno = document.getElementById('txtkeyno').value;
    gkeyno = keyno;
    var rono = document.getElementById('txtrono').value;
    grono = rono;

    var agencycod = document.getElementById('txtagency').value;
    var agencycode = "";
    //////////////this is to split the  and get the code
    if (agencycod != "") {
        //char[] splitter = { '(' };
        var myarray = agencycod.split('(');
        agencycode = myarray[1];
        agencycode = agencycode.replace(")", "");
        gagencyscode = agencycode;
    }
    ////for client

    ////////////////////////////////////


    var clientcode = document.getElementById('txtclient').value;
    var client = "";
    ///this is to split and get the client code

    if (clientcode.indexOf("(".toString()) > 0 && clientcode != "") {
        //clientcode.IndexOf(
        // char[] splitterclie = { '(' };
        var myarray1 = clientcode.split('(');
        client = myarray1[1];
        client = client.replace(")", '');

        /////this is to chk whether this code exixts in the database if exists than it is a register client else
        ///it is walkinn client
        ///
        var res = Classified_Booking.chkwalkinClient(client, document.getElementById('hiddencompcode').value);
        var dcl = res.value;
        if (dcl == null) {
            alert(res.error.description);
            return false;
        }
        if (dcl.Tables[0].Rows.length > 0) {

        }
        else {
            client = clientcode;
        }

    }
    else {
        client = clientcode;
    }
    gclient = client;
    ////////////////////////////////////////////////////////////////////////////////////////
    var res1 = Classified_Booking.executeBooking(document.getElementById('hiddencompcode').value, ciobookid, docno, keyno, rono, agencycode, client, "CL0", document.getElementById('hiddendateformat').value, document.getElementById('hiddenuserid').value);
    executequery = res1.value;
    if (executequery == null) {
        alert(res1.error.description);
        return false;
    }
    // dateinsert getdatechk = new dateinsert();
    rownumEx = 0;
    fillDATA();
    setButtonImages();
    return false;
}