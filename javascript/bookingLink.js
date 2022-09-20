// JScript File

function changedivrate()
{
var chmandat="";
    if(document.getElementById('LinkButton4').disabled==true)
	        return false;
// for validation
    //*25Aug* check for retainer or Executive
    if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
    {
        alert('Please fill Execute Name or Retainer.');
        if(document.getElementById('drpretainer').disabled==false)
            document.getElementById('drpretainer').focus();
        return false;
    }
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
if(browser!="Microsoft Internet Explorer")
{
    chmandat=document.getElementById('lbadscat').textContent;
}
else
{        
    chmandat=document.getElementById('lbadscat').innerText;
}
if(chmandat.indexOf('*')>= 0)
{
    if(document.getElementById('drpadsubcategory').value=="0")
    {
         alert("Please Select Ad Sub Category");
        //document.getElementById('drpadsubcategory').focus();
        return false;
    }
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
    if(document.getElementById('txtadsize1').value=="")
    document.getElementById('txtadsize1').focus();
    else
    document.getElementById('txtadsize2').focus();
    return false;
}  

 if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('lbpageno').textContent;
        }
        else
        {        
            chmandat=document.getElementById('lbpageno').innerText;
        }
        if(chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtpageno').value=="" || document.getElementById('txtpageno').value=="0")
            {
                alert("Page No. Can't be Blanck or 0");
                document.getElementById('txtpageno').focus();
                return false;
            }  
}
//if(document.getElementById('txtratecode').value=="0")
//{
//    alert("Please Select Rate Code");
//    return false;
//}  
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
        
        if(document.getElementById('drpretainer').value!="" && document.getElementById('drpretainer').value!="0" && document.getElementById('txtRetainercomm').value=="")
        {
            document.getElementById('txtRetainercomm').value="";
            var retain_name=document.getElementById('drpretainer').value.split('(');
            var retain_code=retain_name[1].replace(')','');
            var ds_ret=Booking_master.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);
            
            if(ds_ret.value==null)
                return false;
               
           if(ds_ret.value.Tables[0].Rows.length>0)
            {
                document.getElementById('retcommtype').value=ds_ret.value.Tables[0].Rows[0].Discount;
                document.getElementById('txtRetainercomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                document.getElementById('retcomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                if(document.getElementById('retcommtype').value=="Gross" && document.getElementById('txtgrossamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                {
                    document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                }
                else  if(document.getElementById('retcommtype').value=="Net" && document.getElementById('txtbillamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                {
                    document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtbillamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                }
            }    
               
        }
		//getrateonchangecurr();
		 return false;
	}
}

//bill link button
function changebilldiv()
{
 if(document.getElementById('LinkButton1').disabled==true)
        return false;
    //*25Aug* check for retainer or Executive
    if(document.getElementById('drpretainer').value=="" && document.getElementById('txtexecname').value=="")
    {
        alert('Please fill Execute Name or Retainer.');
        document.getElementById('drpretainer').focus();
        return false;
    }
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
if(document.getElementById('txtratecode').value=="0")
{
    alert("Please Select Rate Code");
    document.getElementById('txtratecode').focus();
    return false;
}  
    if(document.getElementById('txttradedisc').value=="")
        document.getElementById('txttradedisc').value="0";
    if(document.getElementById('txttradedisc').value=="")
        document.getElementById('txttradedisc').value="0";
    if(document.getElementById('LinkButton3').disabled==true)
	        return false;
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
    if(document.getElementById('LinkButton3').disabled==false)
    {
        if(document.getElementById('txtagency').value=="")
        {
            alert("Please fill the Agency Sub Code");
            document.getElementById('txtagency').focus();
            return false;
        }
        else if(document.getElementById('drpagscode').value=="" || document.getElementById('drpagscode').value=="0")
        {
            alert("Please select the agency sub code");
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
		
        document.getElementById('LinkButton3').style.fontWeight="bold";
        document.getElementById('LinkButton3').style.color="#FFFF80";
        document.getElementById('LinkButton1').style.fontWeight="normal";
        document.getElementById('LinkButton1').style.color="White";
        document.getElementById('LinkButton2').style.fontWeight="normal";
        document.getElementById('LinkButton2').style.color="White";
        document.getElementById('LinkButton5').style.fontWeight="normal";
        document.getElementById('LinkButton5').style.color="White";
        document.getElementById('LinkButton4').style.fontWeight="normal";
        document.getElementById('LinkButton4').style.color="White";
        document.getElementById('LinkButton6').style.fontWeight="normal";
        document.getElementById('LinkButton6').style.color="White";
        document.getElementById('LinkButton7').style.fontWeight="normal";
        document.getElementById('LinkButton7').style.color="White";
        //alert(document.getElementById('LinkButton1').click);
        document.getElementById('tblrate').style.display="none";
        //document.getElementById('tblbill').style.display="none";
        document.getElementById('tblbill').style.display="block";
        if(document.getElementById('drpbillcycle').disabled==false)
        {
            document.getElementById('drpbillcycle').focus();
        }
        document.getElementById('addetails').style.display="none";
        document.getElementById('pagedetail').style.display="none";
        document.getElementById('tblpackage').style.display="none";
        document.getElementById('tbbox').style.display="none";
        document.getElementById('tbvts').style.display="none";
		        
        //this  is to calculate the bill amount 
//////        if(document.getElementById('txtagreedamt').value!="")
//////        {
//////            var agamt=document.getElementById('txtgrossamt').value;
//////            var tradisc=document.getElementById('txttradedisc').value;
//////            if(tradisc=="")
//////                tradisc="0";
//////            var trdisc1=tradisc;
//////            var addcomm =0;
//////            if(document.getElementById('txtaddagencycommrate')!=null)
//////            {
//////                 addcomm=document.getElementById('txtaddagencycommrate').value;
//////            }
//////            if(addcomm=="")
//////            {
//////                 addcomm="0";
//////            }
//////            if(addcomm!="0")
//////            {
//////                trdisc1=parseInt(tradisc) + parseFloat(addcomm);
//////            }
//////    
//////              var tot1=0;
//////                      var tot=0;
//////                  var tota=0;
//////                  if(document.getElementById('agncomm_seq_com').value!="S")
//////                  {
//////		            tot1=(parseFloat(trdisc1))/100;
//////		            tot=parseFloat(agamt)*parseFloat(tot1);
//////		            tota=parseFloat(agamt)-parseFloat(tot);
//////		         }
//////		         else
//////		         {
//////		             tot1=(parseFloat(tradisc))/100;
//////		            tot=parseFloat(agamt)*parseFloat(tot1);
//////		            tota=parseFloat(agamt)-parseFloat(tot);
//////		              if(addcomm!="0" && addcomm!="")
//////		              {
//////		                tot1=(parseFloat(addcomm))/100;
//////		                tot=parseFloat(tota)*parseFloat(tot1);
//////		                tota=parseFloat(tota)-parseFloat(tot);
//////		               } 
//////		            
//////		         }
//////            document.getElementById('txtbillamt').value=tota.toFixed(2);
//////        }
//////        else 
//////        {
//////            if(document.getElementById('txtcardamt').value!="" && document.getElementById('txttradedisc').value!="")
//////            {
//////                var caramt=document.getElementById('txtgrossamt').value;
//////                var tradisc=document.getElementById('txttradedisc').value;
//////                 if(tradisc=="")
//////		                    tradisc=0;
//////                var trdisc1=tradisc;
//////                var addcomm =0;
//////                if(document.getElementById('txtaddagencycommrate')!=null)
//////                {
//////                    addcomm=document.getElementById('txtaddagencycommrate').value;
//////                }
//////                if(addcomm=="")
//////                {
//////                    addcomm="0";
//////                }
//////                if(addcomm!="0")
//////                {
//////                    trdisc1=parseInt(tradisc) + parseFloat(addcomm);
//////                }
//////                 var tot=0;
//////                        if(document.getElementById('agncomm_seq_com').value!="S")
//////                             tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(trdisc1)/100;
//////                        else
//////                        {
//////                             tot=parseFloat(caramt)-parseFloat(caramt)*parseFloat(tradisc)/100;
//////                              if(addcomm!="0")
//////                                  tot=parseFloat(tot)-parseFloat(tot)*parseFloat(addcomm)/100;
//////                        }
//////                document.getElementById('txtbillamt').value=tot.toFixed(2);
//////            }		        
//////        }
//////		        
//////		
//////        if(document.getElementById('drpbooktype').value=="2" || document.getElementById('drpbooktype').value=="4" || document.getElementById('drpbooktype').value=="5")
//////        {
//////            document.getElementById('txtbillamt').value="0";

//////        }
//////        if(document.getElementById('txtbillamt').value=="NaN")
//////        {
//////            document.getElementById('txtbillamt').value="";
//////        }
        
        //bind paymenttype of bill details div
//		if(document.getElementById('txtagencypaymode').value!="")
//		    document.getElementById('drppaymenttype').value=document.getElementById('txtagencypaymode').value;
		if(document.getElementById('hiddensavemod').value == "1")
		{
			if(document.getElementById('txtagencypaymode').value=="CR1" && document.getElementById('creditreceipt_allow').value=="N"){
			    document.getElementById('tdrec').style.display="none";
                document.getElementById('receipt').style.display="none";
				document.getElementById('print').style.display="none";         
		    }
			else{
			    document.getElementById('tdrec').style.display="";
                document.getElementById('receipt').style.display="";
				document.getElementById('print').style.display="";  
		    }		
        }     
        else
        {
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";    
        }
		////////////////////////////////////////
		//booking type is for FMG then bill amount =0
//////		 if(browser!="Microsoft Internet Explorer")
//////        {
//////		if((document.getElementById('drpbooktype').options[document.getElementById('drpbooktype').selectedIndex].textContent).toUpperCase()=="FMG")
//////		   document.getElementById('txtbillamt').value="0";		   
//////	    }	
//////	    else
//////	    {
//////	        if((document.getElementById('drpbooktype').options[document.getElementById('drpbooktype').selectedIndex].innerHTML).toUpperCase()=="FMG")
//////		   document.getElementById('txtbillamt').value="0";	
        //////	    }
		if (document.getElementById('drpbillcycle').options.length > 1) {
		    document.getElementById('drpbillcycle').selectedIndex = "1";
		    document.getElementById('drpbillcycle').value = "1";
		}
		else
		    document.getElementById('drpbillcycle').value = "0";
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
            return false;
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
    if (document.getElementById('txtciobookid').value == '') {
        document.getElementById('txtciobookid').value = document.getElementById('hiddencioid').value;
    }
    var cioid = document.getElementById('txtciobookid').value;
    var compcode = document.getElementById('hiddencompcode').value;

    var call_showg = Booking_master.showgridforexe(cioid, compcode);
    call_showgrid1(call_showg);
    return false;
}
function call_showgrid1(res) {
    var ds = res.value;
    var showordisable = document.getElementById('hiddensavemod').value;
    var drppagepos_vari = document.getElementById('drppageposition');
    var dateformat = document.getElementById('hiddendateformat').value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var count = ds.Tables[0].Rows.length;
        var status = "";
//        var insprev1 = "";
//        var insertval1 = "";
if (showordisable == "1") {
           //str = str + "<td valign=\"top\" id='uploadA' disabled >Upload</td><td></td><td></td><td valign=\"top\" >VTS</td>";
           //document.getElementById('uploadA').style.
       }
       else {
           document.getElementById('uploadA').disabled = false;
           document.getElementById('uploadA').style.color = "Red";
           document.getElementById('uploadA').style.cursor = "pointer";
       }
        for (var i = 0; i < count; i++) {
            var id = "Text" + i;
            status = document.getElementById("inssta" + i).value;
            if (showordisable != "1" && ds.Tables[0].Rows[i].Insert_status != "billed" && (ds.Tables[0].Rows[i].Insert_status != "publish" && document.getElementById('hiddenrateauditflag').value != "rateaudit" && document.getElementById('hiddenrateauditpreferrence').value != "Y"))
                document.getElementById('btnshgrid').disabled = false;
            var insdat = document.getElementById("Text" + i).value
            var mode = "1";
//            insertval1 = ds.Tables[0].Rows[i].no_insert;
//            if (insprev1 != insertval1 && showordisable != "1") {
//                insprev1 = insertval1;
//                //make_td.title = "Edit Insert";
//            }
            if (insdat == "" || insdat == null || insdat == "null")
                var getdateforexe = "";
            else
                var getdateforexe = savedateinto(insdat, mode);
            var billdate = ds.Tables[0].Rows[i].BILL_DATE;
            if (billdate == "" || billdate == null || billdate == "null")
                billdate = "";
            else
                billdate = savedateinto(billdate, mode);
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
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
               // var t_res = compareDatewithBilledDate(dateformat, getdateforexe, billdate);
               // if (t_res==true && ds.Tables[0].Rows[i].Insert_status == "billed" && document.getElementById('ena_adsubcataftbill').value == "Y")
                  //  document.getElementById("ads" + i).disabled = false;
               // else
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
                document.getElementById("hei" + i).disabled = false;

                document.getElementById("wid" + i).disabled = false;

                document.getElementById("nocol" + i).disabled = false;

                document.getElementById("siz" + i).disabled = false;
            }


            if (hidcopy == "copy" && showordisable == "0") {
                document.getElementById("inssta" + i).disabled = false;
                document.getElementById("inssta" + i).value="booked";
            }
            else if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                document.getElementById("inssta" + i).disabled = true;
            }
            else {
                document.getElementById("inssta" + i).disabled = false;
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                document.getElementById("pagno" + i).disabled = true;
            }
            else {
                document.getElementById("pagno" + i).disabled = false;
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
            if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                document.getElementById("upload" + i).disabled = true;
            }
            else {
                document.getElementById("upload" + i).disabled = false;
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
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                if (drppagepos_vari.value == '0') {
                    document.getElementById("pagpos" + i).disabled = false;
                }
                else {
                    document.getElementById("pagpos" + i).disabled = false;
                }
            }
            else {
                if (drppagepos_vari.value == '0') {
                    document.getElementById("pagpos" + i).disabled = true;
                }
                else {
                    document.getElementById("pagpos" + i).disabled = true;
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
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                document.getElementById("prem" + i).disabled = true;

                document.getElementById("premper" + i).disabled = true;

                document.getElementById("preall" + i).disabled = true;

                
            }
            else {
                document.getElementById("prem" + i).disabled = false;

                document.getElementById("premper" + i).disabled = false;

                document.getElementById("preall" + i).disabled = false;
            }
            if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
              //  var t_res = compareDatewithBilledDate(dateformat, getdateforexe, billdate);
               // if (t_res == true && ds.Tables[0].Rows[i].Insert_status == "billed" && document.getElementById('ena_adsubcataftbill').value == "Y")
                  //  document.getElementById("adcat" + i).disabled = false;
                //else
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
                if (showordisable == "1" || ((ds.Tables[0].Rows[i].Insert_status == "cancel" || (ds.Tables[0].Rows[i].Insert_status == "billed" && getdateforexe != "") || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y") && getdateforexe != "")) && hidcopy != "copy")) {
                   
                    document.getElementById("vtsbtn" + i).disabled = true;
                    
                }
                else {
                    document.getElementById("vtsbtn" + i).disabled = false;

                }
                if (showordisable == "1" || ds.Tables[0].Rows[i].Insert_status == "cancel" || ds.Tables[0].Rows[i].Insert_status == "billed" || ((ds.Tables[0].Rows[i].Insert_status == "publish" || ds.Tables[0].Rows[i].Insert_status == "audit by rate") && (document.getElementById('hiddenrateauditflag').value != "rateaudit" || document.getElementById('hiddenrateauditpreferrence').value != "Y"))) {
                    document.getElementById("dealerh" + i).disabled = true;

                    document.getElementById("dealerw" + i).disabled = true;

                }
                else {
                    document.getElementById("dealerh" + i).disabled = false;

                    document.getElementById("dealerw" + i).disabled = false;

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
    chkbtnStatus = "execute";
    var msg = checkSession();
    if (rownumEx == undefined || rownumEx == "undefined")
        rownumEx = 0;
    if (msg == false) {
        window.location.href = "login.aspx";
        return false;
    }
    //dan
    var strtextd = "";
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

    document.getElementById('btnshgrid').disabled = true;
    //btnupload.Enabled = false;
    document.getElementById('txttranslationdisc').disabled = true;
    document.getElementById('txtpospremdisc').disabled = true;
    document.getElementById('drpbooktype').disabled = true;
    document.getElementById('txtciobookid').disabled = true;
    // txtappby.Enabled = true;
    //txtaudit.Enabled = true;
    document.getElementById('txtrono').disabled = true;
    document.getElementById('txtrevisedate').disabled = true;
    document.getElementById('txtrodate').disabled = true;
    document.getElementById('txtcaption').disabled = true;
    document.getElementById('txtMobile').disabled = true;
    document.getElementById('txtdatetime').disabled = true;
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
    document.getElementById('drpcolor').disabled = true;
    document.getElementById('drpuom').disabled = true;
    document.getElementById('drppageposition').disabled = true;
    document.getElementById('drpdiscountprem').disabled = true;
    document.getElementById('drppagetype').disabled = true;
    document.getElementById('txtpageno').disabled = true;
    document.getElementById('drpadstype').disabled = false;
    document.getElementById('txtRetainercommamt').disabled = true;
    if (document.getElementById('txtaddagencycommrateamt') != null)
        document.getElementById('txtaddagencycommrateamt').disabled = true;

    document.getElementById('txtratecode').disabled = true;
    document.getElementById('drpscheme').disabled = true;
    document.getElementById('drpcurrency').disabled = true;
    document.getElementById('drprptcurrency').disabled = true;
    document.getElementById('txtagreedrate').disabled = true;
    document.getElementById('txtagreedamt').disabled = true;
    document.getElementById('txtspedisc').disabled = true;
    document.getElementById('txtspacedisc').disabled = true;

    document.getElementById('txtextracharges').disabled = true;
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
    document.getElementById('Button1').disabled = true;
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
    document.getElementById('txtcamp').disabled = true;
    document.getElementById('txtbillamt').disabled = true;
    document.getElementById('drppageprem').disabled = true;
    document.getElementById('txtgrossamt').disabled = true;

    document.getElementById('drpboxcode').disabled = true;
    document.getElementById('chkage').disabled = true;
    document.getElementById('chkclie').disabled = true;
    document.getElementById('chktfn').disabled = true;
    document.getElementById('chkadon').disabled = true;
    document.getElementById('chkcoupan').disabled = true;

    document.getElementById('txtinsertion').disabled = true;

    document.getElementById('txtcolum').disabled = true;
    document.getElementById('txtspediscper').disabled = true;
    document.getElementById('txtspadiscper').disabled = true;
    document.getElementById('txtboxno').disabled = true;
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
    document.getElementById('btndeal').disabled = true;
    document.getElementById('drpmatsta').disabled = true;

    document.getElementById('drpretainer').disabled = true;
    if (document.getElementById('txtaddagencycommrate') != null) {
        document.getElementById('txtaddagencycommrate').disabled = true;
    }

    //checkinfo
    document.getElementById('ttextchqno').disabled = true;
    document.getElementById('drpourbank').disabled = true;
    document.getElementById('ttextchqdate').disabled = true;
    document.getElementById('ttextchqamt').disabled = true;
    document.getElementById('ttextbankname').disabled = true;
    //  chkbtnStatus = "";
    ///////////////////////////////////////////////////////////////////////////

    var ciobookid = document.getElementById('hiddencioid').value = document.getElementById('txtciobookid').value;
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
        var myarray = agencycod.split('(');
        agencycode = myarray[1];
        agencycode = agencycode.replace(")", "");
        gagencyscode = agencycode;
    }
    ////for client
    var clientcode = document.getElementById('txtclient').value;
    var client = "";
    ///this is to split and get the client code

    if (clientcode.indexOf("(".toString()) > 0 && clientcode != "") {
        var myarray1 = clientcode.split('(');
        client = myarray1[1];
        client = client.replace(")", '');
        var res = Booking_master.chkwalkinClient(client, document.getElementById('hiddencompcode').value);
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
    var res1 = Booking_master.executeBooking(document.getElementById('hiddencompcode').value, ciobookid, docno, keyno, rono, agencycode, client, document.getElementById('hiddenadtype').value, document.getElementById('hiddendateformat').value, document.getElementById('hiddenuserid').value);
    executequery = res1.value;
    if (executequery == null) {
        alert(res1.error.description);
        return false;
    }
    // dateinsert getdatechk = new dateinsert();
    if (executequery.Tables[0].Rows.length > 0) {
        if (executequery.Tables[0].Rows[0].prev_booking != null && executequery.Tables[0].Rows[0].prev_booking != "") {
            var res = Booking_master.checkCIOIDReference(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[0].cio_booking_id);
            if (res.value != null) {
                if (executequery.Tables[0].Rows[0].cio_booking_id != res.value) {
                    alert("CIO ID " + executequery.Tables[0].Rows[0].cio_booking_id + " has been ReScheduled to New CIO ID " + res.value);
                    return false;
                }
            }
        }
        if (executequery.Tables[0].Rows[0].PACKAGE_TYPE != null) {
            if (executequery.Tables[0].Rows[0].PACKAGE_TYPE == "A") {
                document.getElementById('chkadon').checked = true;
                document.getElementById('lbreference').style.display = "block";
                document.getElementById('tdref').style.display = "block";
                //  document.getElementById('btnrefid').style.display="block";
            }
            else {
                document.getElementById('chkadon').checked = false;
                document.getElementById('lbreference').style.display = "none";
                document.getElementById('tdref').style.display = "none";
                //  document.getElementById('btnrefid').style.display="none";
            }
        }
        if (executequery.Tables[0].Rows[0].AD_REFID != null) {
            document.getElementById('txtreference').value = executequery.Tables[0].Rows[0].AD_REFID;
        }
        else {
            document.getElementById('txtreference').value = "";
        }
        if (executequery.Tables[0].Rows[0].Caption != null) {
            document.getElementById('txtcaption').value = executequery.Tables[0].Rows[0].Caption;
        }
        else {
            document.getElementById('txtcaption').value = "";
        }
        if (executequery.Tables[0].Rows[0].DISC_PREMIUM != null) {
            document.getElementById('drpdiscountprem').value = executequery.Tables[0].Rows[0].DISC_PREMIUM;
        }
        if (executequery.Tables[0].Rows[0].DISC_TYPE != null) {
            hiddisctype = executequery.Tables[0].Rows[0].DISC_TYPE;
        }
        if (executequery.Tables[0].Rows[0].ATTACHMENT1 != null && executequery.Tables[0].Rows[0].ATTACHMENT1 != "") {
            document.getElementById('hidattach1').value = executequery.Tables[0].Rows[0].ATTACHMENT1;
            document.getElementById('attachment1').src = "Images/indexred.jpg";
        }
        if (executequery.Tables[0].Rows[0].ATTACHMENT2 != null && executequery.Tables[0].Rows[0].ATTACHMENT2 != "") {
            document.getElementById('hidattach2').value = executequery.Tables[0].Rows[0].ATTACHMENT2;
            document.getElementById('attachment2').src = "Images/indexred.jpg";
        }

        if (executequery.Tables[0].Rows[0].MOBILENO != null) {
            document.getElementById('txtMobile').value = executequery.Tables[0].Rows[0].MOBILENO;
        }
        else {
            document.getElementById('txtMobile').value = "";
        }
        if (executequery.Tables[0].Rows[0].CREATION_DATETIME != null) {
            document.getElementById('lblcreationdatetime').innerHTML = executequery.Tables[0].Rows[0].CREATION_DATETIME;
        }
        else {
            document.getElementById('lblcreationdatetime').innerHTML = "";
        }
        if (executequery.Tables[0].Rows[0].branch != null) {
            document.getElementById('txtbranch').value = executequery.Tables[0].Rows[0].branch;
        }
        if (executequery.Tables[0].Rows[0].BRANCH_NAME != null) {
            document.getElementById('txtbranch_name').value = executequery.Tables[0].Rows[0].BRANCH_NAME;
        }
        else {
            document.getElementById('txtbranch_name').value = "";
        }
        if (executequery.Tables[0].Rows[0].CLIENT_TYPE != null) {
            document.getElementById('drpregular').value = executequery.Tables[0].Rows[0].CLIENT_TYPE;
        }
        else {
            document.getElementById('drpregular').value = "0";
        }
        if (executequery.Tables[0].Rows[0].TRANSLATION_DISC != null) {
            document.getElementById('txttranslationdisc').value = executequery.Tables[0].Rows[0].TRANSLATION_DISC;
        }
        else {
            document.getElementById('txttranslationdisc').value = "";
        }
        if (executequery.Tables[0].Rows[0].POSPREM_DISC != null) {
            document.getElementById('txtpospremdisc').value = executequery.Tables[0].Rows[0].POSPREM_DISC;
        }
        else {
            document.getElementById('txtpospremdisc').value = "";
        }
        if (executequery.Tables[0].Rows[0].TRANSLATION_CODE != null) {
            document.getElementById('drptranslation').value = executequery.Tables[0].Rows[0].TRANSLATION_CODE;
        }
        else {
            document.getElementById('drptranslation').value = "0";
        }
        if (executequery.Tables[0].Rows[0].TRANSLATION_PREMIUM != null) {
            document.getElementById('txttranslationcharges').value = executequery.Tables[0].Rows[0].TRANSLATION_PREMIUM;
            document.getElementById('hiddentranalpremtype').value = executequery.Tables[0].Rows[0].TRANSLATION_TYPE;
        }
        else {
            document.getElementById('txttranslationcharges').value = "";
            document.getElementById('hiddentranalpremtype').value = "";
        }
        if (executequery.Tables[0].Rows[0].REVISE_DATE != null) {
            document.getElementById('txtrevisedate').value = executequery.Tables[0].Rows[0].REVISE_DATE;
        }
        else {
            document.getElementById('txtrevisedate').value = "";
        }
        if (executequery.Tables[0].Rows[0].BARTE_AMOUNT != null) {
            document.getElementById('hiddenbarteramt').value = executequery.Tables[0].Rows[0].BARTE_AMOUNT;
        }
        if (executequery.Tables[0].Rows[0].BARTERTYPE != null && executequery.Tables[0].Rows[0].BARTE_DESC != null) {
            document.getElementById('txtbartertype').value = executequery.Tables[0].Rows[0].BARTE_DESC + '(' + executequery.Tables[0].Rows[0].BARTERTYPE + ')';
        }
        if (executequery.Tables[0].Rows[0].CIRRATE != null) {
            document.getElementById('txtcirrate').value = executequery.Tables[0].Rows[0].CIRRATE;
        }
        else {
            document.getElementById('txtcirrate').value = "";
        }
        if (executequery.Tables[0].Rows[0].CIRPUBLICATION != null) {
            document.getElementById('hiddencirpub').value = executequery.Tables[0].Rows[0].CIRPUBLICATION;
        }
        else {
            document.getElementById('hiddencirpub').value = "";
        }
        if (executequery.Tables[0].Rows[0].CIREDITION != null) {
            document.getElementById('hiddenciredi').value = executequery.Tables[0].Rows[0].CIREDITION;
        }
        else {
            document.getElementById('hiddenciredi').value = "";
        }
        document.getElementById('txtciragency').value = "";
        // for getting circulation agency name
        if (executequery.Tables[0].Rows[0].CIRAGENCY != null && executequery.Tables[0].Rows[0].CIRAGENCY_SUBCODE != null && executequery.Tables[0].Rows[0].CIRAGENCY != "") {
            var resagname = Booking_master.getcirAgency(document.getElementById('hiddencompcode').value, document.getElementById('txtbranch').value, executequery.Tables[0].Rows[0].CIRAGENCY, executequery.Tables[0].Rows[0].CIRAGENCY_SUBCODE);
            if (resagname.value == null) {
                alert(resagname.error.description);
                return false;
            }
            if (resagname.value.Tables.length > 0 && resagname.value.Tables[0].Rows.length > 0) {
                if (resagname.value.Tables[0].Rows[0].AGENCYNAME != null)
                    document.getElementById('txtciragency').value = resagname.value.Tables[0].Rows[0].AGENCYNAME + '(' + executequery.Tables[0].Rows[0].CIRAGENCY + ' + ' + executequery.Tables[0].Rows[0].CIRAGENCY_SUBCODE + ')';
                else
                    document.getElementById('txtciragency').value = "";
            }
        }
        // for getting circulation EDITION name
        document.getElementById('txtciredition').value = "";
        if (executequery.Tables[0].Rows[0].CIREDITION != null) {
            var resagname = Booking_master.getcirEdition(document.getElementById('hiddencompcode').value, document.getElementById('hiddenciredi').value);
            if (resagname.value == null) {
                alert(resagname.error.description);
                return false;
            }
            if (resagname.value.Tables.length > 0 && resagname.value.Tables[0].Rows.length > 0 && resagname.value.Tables[0].Rows[0].EDITIONNAME != null && resagname.value.Tables[0].Rows[0].EDITIONNAME != "null") {
                document.getElementById('txtciredition').value = resagname.value.Tables[0].Rows[0].EDITIONNAME;
            }
        }
        if (executequery.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT != null) {
            if (document.getElementById('txtaddagencycommrateamt') != null)
                document.getElementById('txtaddagencycommrateamt').value = executequery.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT;
        }
        else {
            if (document.getElementById('txtaddagencycommrateamt') != null)
                document.getElementById('txtaddagencycommrateamt').value = "";
        }
        if (executequery.Tables[0].Rows[0].RETAINER_COMM_AMT != null) {
            document.getElementById('txtRetainercommamt').value = executequery.Tables[0].Rows[0].RETAINER_COMM_AMT;
        }
        else {
            document.getElementById('txtRetainercommamt').value = "";
        }
        if (executequery.Tables[0].Rows[0].RETAINER_COMM != null) {
            if (executequery.Tables[0].Rows[0].RETAINER_COMM1 != null)
                document.getElementById('txtRetainercomm').value = executequery.Tables[0].Rows[0].RETAINER_COMM1;
            else
                document.getElementById('txtRetainercomm').value = executequery.Tables[0].Rows[0].RETAINER_COMM;
        }
        else {
            document.getElementById('txtRetainercomm').value = "";
        }

        if (executequery.Tables[0].Rows[0].APP_USER != null) {
            document.getElementById('txtappby').value = executequery.Tables[0].Rows[0].APP_USER;
        }
        else {
            document.getElementById('txtappby').value = "";
        }


        if (executequery.Tables[0].Rows[0].audit != null) {
            document.getElementById('txtaudit').value = executequery.Tables[0].Rows[0].audit;
        }
        else {
            document.getElementById('txtaudit').value = "";
        }
        if (executequery.Tables[0].Rows[0].booked_by != null) {
            document.getElementById('txtbookedby').value = executequery.Tables[0].Rows[0].booked_by;
        }
        if (executequery.Tables[0].Rows[0].prev_booking != null) {
            document.getElementById('txtprevbook').value = executequery.Tables[0].Rows[0].prev_booking;
        }
        if (executequery.Tables[0].Rows[0].boxchrg != null) {
            boxpercen = executequery.Tables[0].Rows[0].boxchrg;
            document.getElementById('hiddenboxchrgtype').value = executequery.Tables[0].Rows[0].boxchargetype;
        }
        if (hidcopy != "copy") {
            var datetime = executequery.Tables[0].Rows[0].DATE_TIME;
            if (datetime != null) {
                document.getElementById('txtdatetime').value = datetime; //getdatechk.getDate(dateformat, datetime);
            }
        }
        if (executequery.Tables[0].Rows[0].cio_booking_id != null) {
            document.getElementById('txtciobookid').value = executequery.Tables[0].Rows[0].cio_booking_id;
        }

        if (executequery.Tables[0].Rows[0].RO_No != null) {
            document.getElementById('txtrono').value = executequery.Tables[0].Rows[0].RO_No;
        }
        var ro_date = executequery.Tables[0].Rows[0].RO_Date;
        if (ro_date != null) {
            document.getElementById('txtrodate').value = ro_date; //getdatechk.getDate(dateformat, ro_date);
        }
        if (executequery.Tables[0].Rows[0].bill_status != null) {
            document.getElementById('drpbillstatus').value = executequery.Tables[0].Rows[0].bill_status;
        }
        if (executequery.Tables[0].Rows[0].ro_status != null) {
            document.getElementById('drprostatus').value = executequery.Tables[0].Rows[0].ro_status;
            rostatusmain = document.getElementById('drprostatus').value;
        }
        if (executequery.Tables[0].Rows[0].AgencyName != null) {
            document.getElementById('txtagency').value = document.getElementById('hiddenagency').value = executequery.Tables[0].Rows[0].AgencyName;
        }
        if (executequery.Tables[0].Rows[0].EDTN_WISE_BILL_REQ != null) {

            if (executequery.Tables[0].Rows[0].EDTN_WISE_BILL_REQ == "Y")
                if (roundoff != "off")
                roundoff = "editionwise";
            else {
                if (roundoff != "off")
                    roundoff = "insertionwise";
            }
        }
        else {
            if (roundoff != "off")
                roundoff = "insertionwise";
        }
        document.getElementById('txtagency').title = document.getElementById('txtagency').value;
        var res2 = Booking_master.bindsubagency(executequery.Tables[0].Rows[0].Agency_sub_code, document.getElementById('hiddencompcode').value);

        var dsbsa = res2.value;
        if (dsbsa == null) {
            alert(res2.error.description);
            return false;
        }
        document.getElementById('drpagscode').options.length = 0;
        document.getElementById('drpagscode').options[0] = new Option("Select Agency", "0");
        document.getElementById('drpagscode').options.length = 1;
        for (var i = 0; i < dsbsa.Tables[0].Rows.length; ++i) {
            document.getElementById('drpagscode').options[document.getElementById('drpagscode').options.length] = new Option(dsbsa.Tables[0].Rows[i].agency_name, dsbsa.Tables[0].Rows[i].Agency_Code);
            document.getElementById('drpagscode').options.length;
        }


        //////////////////////////////////////////////////////
        if (executequery.Tables[0].Rows[0].Client_code != null) {
            if (executequery.Tables[0].Rows[0].Client != null) {
                if (executequery.Tables[0].Rows[0].Client == "")
                    document.getElementById('txtclient').value = executequery.Tables[0].Rows[0].Client_code;
                else
                    document.getElementById('txtclient').value = executequery.Tables[0].Rows[0].Client + "(" + executequery.Tables[0].Rows[0].Client_code + ")";


            }
            else
                document.getElementById('txtclient').value = executequery.Tables[0].Rows[0].Client_code;     //.ItemArray[14].ToString();
        }
        else {
            document.getElementById('txtclient').value = "";
        }
        //            if(executequery.Tables[0].Rows[0].Client!=null)
        //            {
        //                document.getElementById('txtclient').value = document.getElementById('hiddenclientname').value=executequery.Tables[0].Rows[0].Client;     //.ItemArray[14].ToString();
        //            }    
        if (executequery.Tables[0].Rows[0].Agency_address != null) {
            document.getElementById('txtagencyaddress').value = executequery.Tables[0].Rows[0].Agency_address;
        }
        document.getElementById('txtagencyaddress').title = document.getElementById('txtagencyaddress').value;
        if (executequery.Tables[0].Rows[0].Client_address != null) {
            document.getElementById('txtclientadd').value = executequery.Tables[0].Rows[0].Client_address;
        }
        if (executequery.Tables[0].Rows[0].Agency_code != null) {
            document.getElementById('hiddensubcode').value = document.getElementById('drpagscode').value = executequery.Tables[0].Rows[0].Agency_code;
        }
        if (executequery.Tables[0].Rows[0].Dockit_no != null) {
            document.getElementById('txtdockitno1').value = executequery.Tables[0].Rows[0].Dockit_no;
        }
        if (executequery.Tables[0].Rows[0].execname != null) {
            document.getElementById('txtexecname').value = executequery.Tables[0].Rows[0].execname;
        }
        if (executequery.Tables[0].Rows[0].Executive_zone != null) {
            document.getElementById('hiddenzone').value = document.getElementById('txtexeczone').value = executequery.Tables[0].Rows[0].Executive_zone;
        }
        if (executequery.Tables[0].Rows[0].product != null) {
            document.getElementById('txtproduct').value = executequery.Tables[0].Rows[0].product;
        }

        /////////////////////////////////////////////this is to bind the brand drop down
        res2 = null;
        if (executequery.Tables[0].Rows[0].Product_code != null) {
            res2 = Booking_master.brandbind(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[0].Product_code);
            var dsbrand = res2.value;
            if (dsbrand == null) {
                alert(res2.error.description);
                return false;
            }

            document.getElementById('drpbrand').options.length = 0;
            document.getElementById('drpbrand').options[0] = new Option("Select Brand", "0");
            document.getElementById('drpbrand').options.length = 1;
            for (var i = 0; i < dsbrand.Tables[0].Rows.length; ++i) {
                document.getElementById('drpbrand').options[document.getElementById('drpbrand').options.length] = new Option(dsbrand.Tables[0].Rows[i].brand_name, dsbrand.Tables[0].Rows[i].brand_code);
                document.getElementById('drpbrand').options.length;
            }
        }

        if (executequery.Tables[0].Rows[0].Brand_code == null || executequery.Tables[0].Rows[0].Brand_code.toString() == "") {
            document.getElementById('drpbrand').options.length = 0;
            document.getElementById('hiddenbrand').value = "";
        }
        else {
            if (executequery.Tables[0].Rows[0].Brand_code != null) {
                document.getElementById('hiddenbrand').value = document.getElementById('drpbrand').value = executequery.Tables[0].Rows[0].Brand_code.toString();
            }
        }

        res2 = Booking_master.varientbind(document.getElementById('hiddencompcode').value, document.getElementById('hiddenbrand').value);
        var dsvarient = res2.value;
        if (dsvarient == null) {
            alert(res2.error.description)
            return false;
        }
        document.getElementById('drpvarient').options.length = 0;
        document.getElementById('drpvarient').options[0] = new Option("Select Varient", "0");
        document.getElementById('drpvarient').options.length = 1;
        for (var i = 0; i < dsvarient.Tables[0].Rows.length; ++i) {
            document.getElementById('drpvarient').options[document.getElementById('drpvarient').options.length] = new Option(dsvarient.Tables[0].Rows[i].varient_name, dsvarient.Tables[0].Rows[i].varient_code);
            document.getElementById('drpvarient').options.length;
            if (executequery.Tables[0].Rows[0].Brand_code != null && executequery.Tables[0].Rows[0].Variant_code == document.getElementById('drpvarient').options[i].value) {
                document.getElementById('hiddenvar').value = document.getElementById('drpvarient').value = executequery.Tables[0].Rows[0].Variant_code.toString();
            }
        }
        if (executequery.Tables[0].Rows[0].Variant_code == null || executequery.Tables[0].Rows[0].Variant_code.toString() == "") {
            document.getElementById('drpvarient').options.length = 0;
            document.getElementById('hiddenvar').value = "";
        }

        ////////////////////////////////////////////////////////////////////////////////
        if (executequery.Tables[0].Rows[0].Key_no != null) {
            document.getElementById('txtkeyno').value = executequery.Tables[0].Rows[0].Key_no;
        }
        if (executequery.Tables[0].Rows[0].Bill_remarks != null) {
            document.getElementById('txtbillremark').value = executequery.Tables[0].Rows[0].Bill_remarks;
        }
        if (executequery.Tables[0].Rows[0].Print_remark != null) {
            document.getElementById('txtprintremark').value = executequery.Tables[0].Rows[0].Print_remark;
        }
        if (executequery.Tables[0].Rows[0].Package_code != null) {
            var listpck = executequery.Tables[0].Rows[0].Package_code;
            document.getElementById('hiddenpackage').value = listpck;
            //////////////////this is to bind the package grid on what the value is saved in the database

            res2 = null;
            res2 = Booking_master.bindpacforexe(document.getElementById('hiddencompcode').value, listpck);
            var dsexecut = res2.value;
            if (dsexecut == null) {
                alert(res2.error.description);
                return false;
            }
            if (document.getElementById('chkadon').checked == true) {
                bindpackage_adon();
            }
            document.getElementById('drppackagecopy').options.length = 0;
            for (i = 0; i <= dsexecut.Tables[0].Rows.length - 1; i++) {
                if (dsexecut.Tables[0].Rows[i].pck_code.toString() != "") {
                    if (dsexecut.Tables[0].Rows[i].pck_code.toString() != "0") {
                        var arrfor_uom = dsexecut.Tables[0].Rows[i].pck_code.toString().split('@');
                        var res3 = Booking_master.getPackageInsert(arrfor_uom[0].toString(), document.getElementById('txtciobookid').value);
                        var dsinsert = res3.value;
                        if (dsinsert == null) {
                            alert(res3.error.description);
                            return false;
                        }
                        var T = dsexecut.Tables[0].Rows[i].Package_Name + "(" + dsinsert.Tables[0].Rows[0].inserts + ")";
                        var V = dsexecut.Tables[0].Rows[i].pck_code + "(" + dsinsert.Tables[0].Rows[0].inserts + ")";
                        if (dsinsert.Tables[0].Rows[0].inserts != null) {
                            document.getElementById('drppackagecopy').options[document.getElementById('drppackagecopy').options.length] = new Option(T, V);
                            document.getElementById('drppackagecopy').options.length;
                        }
                    }
                }
            }

        }

        if (executequery.Tables[0].Rows[0].No_of_insertion != null) {
            document.getElementById('txtinsertion').value = executequery.Tables[0].Rows[0].No_of_insertion;
            document.getElementById('hiddeninsertion').value = executequery.Tables[0].Rows[0].No_of_insertion;
        }

        var start_date = executequery.Tables[0].Rows[0].Insertion_date;
        if (start_date != null) {
            document.getElementById('txtdummydate').value = start_date; //getdatechk.getDate(dateformat, start_date);
        }
        if (executequery.Tables[0].Rows[0].Repeating_day != null) {
            document.getElementById('txtrepeatingdate').value = executequery.Tables[0].Rows[0].Repeating_day;
        }
        var mag = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(') + 1, document.getElementById('txtagency').value.lastIndexOf(')'));
        var resT = Booking_master.bindAdTypeAgencyWise(mag, document.getElementById('hiddencompcode').value);
        bindBookType_Agency();
        var obj = document.getElementById('drpbooktype');
        /* var resType=Booking_master.bindAdTypeAgencyWiseXML();
           
        obj.options.length = 0; 
        if(resType!=null && resType.value!="")
        {
            
        var arr=resType.value.split(",");
        obj.options[0]=new Option("Select Booking Type","0");
        for(var i=0;i<arr.length;i++)
        {
        obj.options[obj.options.length] = new Option(arr[i].toString(),arr[parseFloat(i,10)+1].toString());
        i++;
        }
        }*/
        if (resT.value != "") {
            for (var i = 1; i < obj.options.length; i++) {
                if (resT.value.indexOf(obj[i].value) < 0) {
                    //obj.options.remove(i);
                    obj.remove(i);
                }
            }
        }
        if (executequery.Tables[0].Rows[0].Booking_type != null) {
            document.getElementById('drpbooktype').value = executequery.Tables[0].Rows[0].Booking_type;
        }
        if (executequery.Tables[0].Rows[0].Ad_cat_code != null) {
            document.getElementById('drpadcategory').value = executequery.Tables[0].Rows[0].Ad_cat_code;
        }
        //            if (executequery.Tables[0].Rows[0].Ad_sub_cat_code==null || executequery.Tables[0].Rows[0].Ad_sub_cat_code == "" || executequery.Tables[0].Rows[0].Ad_sub_cat_code=="0")
        //            {
        //                document.getElementById('drpadsubcategory').options.length=0;
        //                document.getElementById('hiddenadsubcategory').value = "";
        //            }
        //            else
        //            {
        if (executequery.Tables[0].Rows[0].Ad_cat_code != null) {
            var ds_adsubcat = null;
            ds_adsubcat = Booking_master.getadsubcat(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[0].Ad_cat_code, document.getElementById('hiddencattype').value);
            var dacat = ds_adsubcat.value;
            if (dacat == null) {
                alert(ds_adsubcat.error.description);
                return false;
            }

            ////////////////////////////////////////////////////////////////
            document.getElementById('drpadsubcategory').options.length = 0;
            document.getElementById('drpadsubcategory').options[0] = new Option("Select", "0");
            for (var k = 0; k < dacat.Tables[0].Rows.length; k++) {
                document.getElementById('drpadsubcategory').options[document.getElementById('drpadsubcategory').options.length] = new Option(dacat.Tables[0].Rows[k].Adv_Subcat_Name, dacat.Tables[0].Rows[k].Adv_Subcat_Code);
                document.getElementById('drpadsubcategory').options.length;
            }

        }
        if (executequery.Tables[0].Rows[0].Ad_sub_cat_code != null) {
            document.getElementById('hiddenadsubcategory').value = document.getElementById('drpadsubcategory').value = executequery.Tables[0].Rows[0].Ad_sub_cat_code;
        }
        if (executequery.Tables[0].Rows[0].Color_code != null) {
            document.getElementById('drpcolor').value = executequery.Tables[0].Rows[0].Color_code;
        }
        if (executequery.Tables[0].Rows[0].Uom_code != null) {
            document.getElementById('drpuom').value = executequery.Tables[0].Rows[0].Uom_code;
        }
        if (executequery.Tables[0].Rows[0].Page_position_code != null) {
            document.getElementById('drppageposition').value = executequery.Tables[0].Rows[0].Page_position_code;
            pgposprem = "per";
        }
        if (executequery.Tables[0].Rows[0].Page_type_code != null) {
            document.getElementById('drppagetype').value = executequery.Tables[0].Rows[0].Page_type_code;
        }
        if (executequery.Tables[0].Rows[0].Page_no != null) {
            document.getElementById('txtpageno').value = executequery.Tables[0].Rows[0].Page_no;
        }

        res3 = null;
        res3 = Booking_master.gettheuom_desc(document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[0].Uom_code);
        var ds_uom_ = res3.value;
        if (ds_uom_ == null) {
            alert(res3.error.description);
            return false;
        }
        if (ds_uom_.Tables[0].Rows.length > 0) {
            document.getElementById('hiddenuomdesc').value = ds_uom_.Tables[0].Rows[0].uom_desc;
        }


        if (executequery.Tables[0].Rows[0].Ad_size_height != null) {
            document.getElementById('txtadsize1').value = executequery.Tables[0].Rows[0].Ad_size_height;
        }
        if (executequery.Tables[0].Rows[0].FIXED_BOOKING != null) {
            fixed_booking = executequery.Tables[0].Rows[0].FIXED_BOOKING;
        }


        if (executequery.Tables[0].Rows[0].VAT_CODE != null) {
            document.getElementById('hdnvts').value = executequery.Tables[0].Rows[0].VAT_CODE;
        }



        if (executequery.Tables[0].Rows[0].Ad_size_width != null) {
            document.getElementById('txtadsize2').value = executequery.Tables[0].Rows[0].Ad_size_width;
        }
        // for dealer panel
        if (executequery.Tables[0].Rows[0].DEALERPANEL != null && executequery.Tables[0].Rows[0].DEALERPANEL == "Y") {
            document.getElementById('chkDealerPanel').checked = true;
        }
        else {
            document.getElementById('chkDealerPanel').checked = false;
        }
        if (executequery.Tables[0].Rows[0].DEALER_H != null) {
            document.getElementById('txtadsize1dealer').value = executequery.Tables[0].Rows[0].DEALER_H;
        }
        if (executequery.Tables[0].Rows[0].DEALER_W != null) {
            document.getElementById('txtadsize2dealer').value = executequery.Tables[0].Rows[0].DEALER_W;
        }
        if (executequery.Tables[0].Rows[0].DEALERTYPE != null) {
            document.getElementById('drpdealertype').value = executequery.Tables[0].Rows[0].DEALERTYPE;
        }
        ////this is to bind the ratecode drpdown
        res3 = null
        if (executequery.Tables[0].Rows[0].Ad_cat_code != null) {
            if (executequery.Tables[0].Rows[0].REVISE_DATE != null && executequery.Tables[0].Rows[0].REVISE_DATE != "" && executequery.Tables[0].Rows[0].REVISE_DATE != "0") {
                res3 = Booking_master.bindratecodeforreviserate(executequery.Tables[0].Rows[0].Ad_cat_code, document.getElementById('hiddencompcode').value, executequery.Tables[0].Rows[0].REVISE_DATE);
                var dx = res3.value;
                if (dx == null) {
                    alert(dx.error.description);
                    return false;
                }
                document.getElementById('txtratecode').options.length = 0;
                document.getElementById('txtratecode').options[0] = new Option("-Select Rate Code-", "0");
                document.getElementById('txtratecode').options.length = 1;

                for (var i = 0; i < dx.Tables[0].Rows.length; ++i) {
                    document.getElementById('txtratecode').options[document.getElementById('txtratecode').options.length] = new Option(dx.Tables[0].Rows[i].rate_mast_code, dx.Tables[0].Rows[i].rate_mast_code);

                    document.getElementById('txtratecode').options.length;
                }
            }
            else {
                // res3 = Booking_master.ratebind(executequery.Tables[0].Rows[0].Ad_cat_code, document.getElementById('hiddencompcode').value);
                res3 = Booking_master.bindratecodecenterwise(executequery.Tables[0].Rows[0].Ad_cat_code, document.getElementById('hiddencompcode').value, document.getElementById('txtbranch').value, document.getElementById('txtdatetime').value, document.getElementById('hiddendateformat').value);
                var dx = res3.value;
                if (dx == null) {
                    alert(dx.error.description);
                    return false;
                }
                document.getElementById('txtratecode').options.length = 0;
                document.getElementById('txtratecode').options[0] = new Option("-Select Rate Code-", "0");
                document.getElementById('txtratecode').options.length = 1;

                for (var i = 0; i < dx.Tables[0].Rows.length; ++i) {
                    document.getElementById('txtratecode').options[document.getElementById('txtratecode').options.length] = new Option(dx.Tables[0].Rows[i].rate_mast_code, dx.Tables[0].Rows[i].rate_mast_code);

                    document.getElementById('txtratecode').options.length;
                }
            }

        }
        if (executequery.Tables[0].Rows[0].Rate_code != null) {
            document.getElementById('txtratecode').value = executequery.Tables[0].Rows[0].Rate_code;
        }
        if (executequery.Tables[0].Rows[0].Scheme_type_code != null) {
            document.getElementById('drpscheme').value = executequery.Tables[0].Rows[0].Scheme_type_code;
        }
        if (executequery.Tables[0].Rows[0].SCHEMEID != null) {
            schemeid = executequery.Tables[0].Rows[0].SCHEMEID;
        }
        else
            schemeid = "";
        if (executequery.Tables[0].Rows[0].Scheme_type_code != null) {
            document.getElementById('hiddenscheme').value = executequery.Tables[0].Rows[0].Scheme_type_code;
        }

        if (executequery.Tables[0].Rows[0].Currency_code != null) {
            document.getElementById('drpcurrency').value = executequery.Tables[0].Rows[0].Currency_code;
        }
        if (executequery.Tables[0].Rows[0].RECEIPT_CURRENCY != null) {
            document.getElementById('drprptcurrency').value = executequery.Tables[0].Rows[0].RECEIPT_CURRENCY;
        }
        if (executequery.Tables[0].Rows[0].CONV_CURR_RATE != null) {
            document.getElementById('hidcurrency_convrate').value = executequery.Tables[0].Rows[0].CONV_CURR_RATE;
        }
        if (executequery.Tables[0].Rows[0].Agrred_rate != null) {
            document.getElementById('txtagreedrate').value = executequery.Tables[0].Rows[0].Agrred_rate;
        }
        if (executequery.Tables[0].Rows[0].Agreed_amount != null) {
            document.getElementById('txtagreedamt').value = executequery.Tables[0].Rows[0].Agreed_amount;
        }
        if (executequery.Tables[0].Rows[0].ACTIVE_AGREEDRATE != null) {
            agreedrate_active = executequery.Tables[0].Rows[0].ACTIVE_AGREEDRATE;
        }
        else {
            agreedrate_active = 0;
        }
        if (executequery.Tables[0].Rows[0].ACTIVE_AGREEDAMT != null) {
            agreedamt_active = executequery.Tables[0].Rows[0].ACTIVE_AGREEDAMT;
        }
        else {
            agreedamt_active = 0;
        }
        if (agreedrate_active == 1) {
            document.getElementById('txtagreedrate').className = ' btextforbookrightsmallbold';
        }
        else {
            document.getElementById('txtagreedrate').className = ' btextforbookrightsmall';
        }
        if (agreedamt_active == 1) {
            document.getElementById('txtagreedamt').className = ' btextforbookrightsmallbold';
        }
        else {
            document.getElementById('txtagreedamt').className = ' btextforbookrightsmall';
        }
        if (executequery.Tables[0].Rows[0].Special_charges != null) {
            document.getElementById('txtextracharges').value = executequery.Tables[0].Rows[0].Special_charges;
        }
        if (executequery.Tables[0].Rows[0].Agency_status != null) {
            document.getElementById('hiddenstatus').value = document.getElementById('txtagencystatus').value = executequery.Tables[0].Rows[0].Agency_status;
        }
        if (executequery.Tables[0].Rows[0].Agency_type != null) {
            document.getElementById('txtagencytype').value = executequery.Tables[0].Rows[0].Agency_type;
        }

        res3 = null;
        if (executequery.Tables[0].Rows[0].Agency_sub_code != null) {
            res3 = Booking_master.getstatuspaymode(executequery.Tables[0].Rows[0].Agency_sub_code, executequery.Tables[0].Rows[0].Agency_code, document.getElementById('hiddencompcode').value, document.getElementById('txtdatetime').value, document.getElementById('hiddendateformat').value, document.getElementById('hiddenadtype').value);
            var dch = res3.value;
            if (dch == null) {
                alert(res3.error.description);
                return false;
            }

            document.getElementById('txtagencypaymode').options.length = 0;
            if (dch.Tables[5].Rows.length > 0) {
                for (var i = 0; i < dch.Tables[5].Rows.length; i++) {
                    document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name, dch.Tables[5].Rows[i].pay_mode_code);
                    document.getElementById('txtagencypaymode').options.length;
                }
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        if (executequery.Tables[0].Rows[0].Agency_pay != null) {
            document.getElementById('hiddenpay').value = document.getElementById('txtagencypaymode').value = executequery.Tables[0].Rows[0].Agency_pay;
            if (document.getElementById('txtagencypaymode').selectedIndex != -1)
                document.getElementById('hiddenpaymode').value = document.getElementById('txtagencypaymode').options[document.getElementById('txtagencypaymode').selectedIndex].text;
        }
        if (executequery.Tables[0].Rows[0].Agency_credit != null) {
            document.getElementById('txtcreditperiod').value = executequery.Tables[0].Rows[0].Agency_credit;
        }
        if (executequery.Tables[0].Rows[0].Total_area != null) {
            document.getElementById('txttotalarea').value = executequery.Tables[0].Rows[0].Total_area;
        }
        if (executequery.Tables[0].Rows[0].Card_rate != null) {
            document.getElementById('txtcardrate').value = executequery.Tables[0].Rows[0].Card_rate;
        }
        if (executequery.Tables[0].Rows[0].Card_amount != null) {
            document.getElementById('txtcardamt').value = executequery.Tables[0].Rows[0].Card_amount;
        }
        if (executequery.Tables[0].Rows[0].Discount != null) {
            document.getElementById('txtdiscount').value = executequery.Tables[0].Rows[0].Discount;
        }
        if (executequery.Tables[0].Rows[0].Discount_per != null) {
            document.getElementById('txtdiscpre').value = executequery.Tables[0].Rows[0].Discount_per;
        }
        if (executequery.Tables[0].Rows[0].Bill_cycle != null) {
            document.getElementById('drpbillcycle').value = executequery.Tables[0].Rows[0].Bill_cycle;
        }
        if (executequery.Tables[0].Rows[0].Revenue_center != null) {
            document.getElementById('drprevenue').value = executequery.Tables[0].Rows[0].Revenue_center;
        }
        if (document.getElementById('drprevenue').selectedIndex != "-1") {
            document.getElementById('hiddenbranch').value = document.getElementById('drprevenue').options[document.getElementById('drprevenue').selectedIndex].text; //drprevenue.SelectedItem.Text.ToString();
        }
        ////this is to bind the bill pay mode
        document.getElementById('drppaymenttype').options.length = 0;
        if (dch.Tables[5].Rows.length > 0) {
            for (var i = 0; i < dch.Tables[5].Rows.length; i++) {
                document.getElementById('drppaymenttype').options[document.getElementById('drppaymenttype').options.length] = new Option(dch.Tables[5].Rows[i].payment_mode_name, dch.Tables[5].Rows[i].pay_mode_code);
                document.getElementById('drppaymenttype').options.length;
            }
        }
        if (executequery.Tables[0].Rows[0].Bill_pay != null) {
            document.getElementById('hiddenbillpay').value = document.getElementById('drppaymenttype').value = executequery.Tables[0].Rows[0].Bill_pay;
        }
        var ag = Booking_master.GETCASH_PAY(document.getElementById('hiddencompcode').value, document.getElementById('drppaymenttype').value);
        var ds_n = ag.value;
        var cashdiscount = 'N';
        if (ds_n != null && ds_n.Tables[0].Rows.length > 0) {
            cashdiscount = ds_n.Tables[0].Rows[0].CASHDISCOUNT;
        }
        if (document.getElementById('drppaymenttype').value == "CH0" || document.getElementById('drppaymenttype').value == "DD0" || document.getElementById('drppaymenttype').value == 'PO0' || document.getElementById('drppaymenttype').value == 'AD0')  //CR0 is Credit Card code and DD0 is demand draft
        {
            document.getElementById('tdchqno').style.display = "";
            document.getElementById('tdchqdate').style.display = "";
            document.getElementById('tdchqamt').style.display = "";
            document.getElementById('tdbankname').style.display = "";
            document.getElementById('tdourbank').style.display = "";


            document.getElementById('tdtextchqno').style.display = "";
            document.getElementById('tdtextchqdate').style.display = "";
            document.getElementById('tdtextchqamt').style.display = "";
            document.getElementById('tdtextbankname').style.display = "";
            document.getElementById('tdtextourbank').style.display = "";
        }
        if (document.getElementById('drppaymenttype').value == "CR0")  //CR0 is Credit Card code
        {
            document.getElementById('tdcarname').style.display = "";
            document.getElementById('tdtxtcarname').style.display = "";
            document.getElementById('tdtype').style.display = "";
            document.getElementById('tddrptyp').style.display = "";
            document.getElementById('tdexdat').style.display = "";

            document.getElementById('tdtxtexdat').style.display = "";
            document.getElementById('tdcardno').style.display = "";
            document.getElementById('tdtxtcarno').style.display = "";
            //                document.getElementById('txtcardname').value=executequery.Tables[0].Rows[rownumEx].Card_name;
            //                document.getElementById('drptype').value=executequery.Tables[0].Rows[rownumEx].Card_type;
            //                document.getElementById('txtcardno').value=executequery.Tables[0].Rows[rownumEx].Card_number;  
            //                document.getElementById('drpmonth').value=executequery.Tables[0].Rows[rownumEx].Card_month;  
            //                document.getElementById('drpyear').value=executequery.Tables[0].Rows[rownumEx].Card_year;

            document.getElementById('tdchqno').style.display = "none";
            document.getElementById('tdchqdate').style.display = "none";
            document.getElementById('tdchqamt').style.display = "none";
            document.getElementById('tdbankname').style.display = "none";
            document.getElementById('tdourbank').style.display = "none";
            z
            document.getElementById('tdtextchqno').style.display = "none";
            document.getElementById('tdtextchqdate').style.display = "none";
            document.getElementById('tdtextchqamt').style.display = "none";
            document.getElementById('tdtextbankname').style.display = "none";
            document.getElementById('tdtextourbank').style.display = "none";

        }
        else if (document.getElementById('drppaymenttype').value == "CA0") {
            document.getElementById('cashrecvd').style.display = "";
            // document.getElementById('tdcashrecvd').style.display="";
            if (executequery.Tables[0].Rows[0].CASHDISCOUNT == null || executequery.Tables[0].Rows[0].CASHDISCOUNT == "null")
                document.getElementById('txtcashdiscount').value = "0";
            else
                document.getElementById('txtcashdiscount').value = executequery.Tables[0].Rows[0].CASHDISCOUNT;
            if (executequery.Tables[0].Rows[0].CASHDISCTYPE == null || executequery.Tables[0].Rows[0].CASHDISCTYPE == "null")
                document.getElementById('hiddencashdiscper').value = "";
            else
                document.getElementById('hiddencashdiscper').value = executequery.Tables[0].Rows[0].CASHDISCTYPE;

            if (executequery.Tables[0].Rows[0].CASH_RECIEVED == null || executequery.Tables[0].Rows[0].CASH_RECIEVED == "null")
                document.getElementById('drpcashrecieved').value = "0";
            else
                document.getElementById('drpcashrecieved').value = executequery.Tables[0].Rows[0].CASH_RECIEVED;
            document.getElementById('hiddencashrecieved').value = executequery.Tables[0].Rows[0].CASH_RECIEVED;

            document.getElementById('drpcashrecieved').disabled = true;
            document.getElementById('txtcashdiscount').disabled = true;
        }
        if (cashdiscount == 'Y') {
            document.getElementById('cashrecvd').style.display = "";
            // document.getElementById('tdcashrecvd').style.display="";
            if (executequery.Tables[0].Rows[0].CASHDISCOUNT == null || executequery.Tables[0].Rows[0].CASHDISCOUNT == "null")
                document.getElementById('txtcashdiscount').value = "0";
            else
                document.getElementById('txtcashdiscount').value = executequery.Tables[0].Rows[0].CASHDISCOUNT;
            if (executequery.Tables[0].Rows[0].CASHDISCTYPE == null || executequery.Tables[0].Rows[0].CASHDISCTYPE == "null")
                document.getElementById('hiddencashdiscper').value = "";
            else
                document.getElementById('hiddencashdiscper').value = executequery.Tables[0].Rows[0].CASHDISCTYPE;

            if (executequery.Tables[0].Rows[0].CASH_RECIEVED == null || executequery.Tables[0].Rows[0].CASH_RECIEVED == "null")
                document.getElementById('drpcashrecieved').value = "0";
            else
                document.getElementById('drpcashrecieved').value = executequery.Tables[0].Rows[0].CASH_RECIEVED;
            document.getElementById('hiddencashrecieved').value = executequery.Tables[0].Rows[0].CASH_RECIEVED;

            document.getElementById('drpcashrecieved').disabled = true;
            document.getElementById('txtcashdiscount').disabled = true;
        }
        else {
            document.getElementById('cashrecvd').style.display = "none";
        }
        if (executequery.Tables[0].Rows[0].Bill_height != null) {
            document.getElementById('txtbillheight').value = executequery.Tables[0].Rows[0].Bill_height;
        }
        if (executequery.Tables[0].Rows[0].Bill_width != null) {
            document.getElementById('txtbillwidth').value = executequery.Tables[0].Rows[0].Bill_width;
        }
        //////////////this is to bind the bill to 
        res3 = null;
        if (executequery.Tables[0].Rows[0].Agency_sub_code != null) {
            res3 = Booking_master.getbillval(executequery.Tables[0].Rows[0].Agency_sub_code, document.getElementById('hiddencompcode').value);
            var dbt = res3.value;
            if (dbt == null) {
                alert(res3.error.description);
                return false;
            }

            ////////////////////////////////////////////////////
            document.getElementById('drpbillto').options.length = 0;
            var client_val = document.getElementById('txtclient').value;
            var client_name = document.getElementById('txtclient').value;
            if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0) {
                client_val = document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(") + 1, document.getElementById('txtclient').value.length - 1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                client_name = document.getElementById('txtclient').value.substring(0, document.getElementById('txtclient').value.lastIndexOf("("));
            }
            document.getElementById('drpbillto').options[0] = new Option(client_name, client_val);
            for (var k = 0; k < dbt.Tables[0].Rows.length; k++) {
                if (dbt.Tables[0].Rows[k].bill_to == "")
                    document.getElementById('drpbillto').options[document.getElementById('drpbillto').options.length] = new Option(dbt.Tables[0].Rows[k].agency_name, dbt.Tables[0].Rows[k].SUB_agency_code);
                else
                    document.getElementById('drpbillto').options[document.getElementById('drpbillto').options.length] = new Option(dbt.Tables[0].Rows[k].agency_name, dbt.Tables[0].Rows[k].bill_to);
                document.getElementById('drpbillto').options.length;
            }
        }
        if (executequery.Tables[0].Rows[0].Bill_to != null) {
            document.getElementById('hiddenbillto').value = executequery.Tables[0].Rows[0].Bill_to;
        }
        if (executequery.Tables[0].Rows[0].Bill_to != null) {
            document.getElementById('drpbillto').value = executequery.Tables[0].Rows[0].Bill_to;
        }
        if (executequery.Tables[0].Rows[0].Invoices != null) {
            document.getElementById('txtinvoice').value = executequery.Tables[0].Rows[0].Invoices;
        }
        if (executequery.Tables[0].Rows[0].Vts != null) {
            document.getElementById('txtvts').value = executequery.Tables[0].Rows[0].Vts;
        }
        if (executequery.Tables[0].Rows[0].Bill_add != null) {
            document.getElementById('txtbilladdress').value = executequery.Tables[0].Rows[0].Bill_add;
        }
        if (executequery.Tables[0].Rows[0].Trade_disc != null) {
            document.getElementById('txttradedisc').value = executequery.Tables[0].Rows[0].Trade_disc;
            document.getElementById('txttd').value = executequery.Tables[0].Rows[0].Trade_disc;
            //                document.getElementById('hiddentradedisc').value= executequery.Tables[0].Rows[0].COMM_RATE;
            //                document.getElementById('hiddenagcommflag').value=executequery.Tables[0].Rows[0].ADDFLAG;
        }
        if (executequery.Tables[0].Rows[0].ADDFLAG != null) {
            document.getElementById('hiddenagcommflag').value = executequery.Tables[0].Rows[0].ADDFLAG;
        }
        if (executequery.Tables[0].Rows[0].COMM_RATE != null) {
            document.getElementById('hiddentradedisc').value = executequery.Tables[0].Rows[0].COMM_RATE;
        }
        if (executequery.Tables[0].Rows[0].CHKTRADE != null) {
            if (executequery.Tables[0].Rows[0].CHKTRADE == "1")
                document.getElementById('chktrade').checked = true;
            else
                document.getElementById('chktrade').checked = false;
        }
        if (executequery.Tables[0].Rows[0].BILL_HOLD != null) {
            if (executequery.Tables[0].Rows[0].BILL_HOLD == "Y")
                document.getElementById('chkholdbill').checked = true;
            else
                document.getElementById('chkholdbill').checked = false;
        }
        if (executequery.Tables[0].Rows[0].CANCELLATION_CHARGE != null) {
            if (executequery.Tables[0].Rows[0].CANCELLATION_CHARGE == "1")
                document.getElementById('chkcanclecharges').checked = true;
            else
                document.getElementById('chkcanclecharges').checked = false;
        }
        if (executequery.Tables[0].Rows[0].Agency_out != null) {
            document.getElementById('txtagencyoutstand').value = executequery.Tables[0].Rows[0].Agency_out;
        }
        //recorrect it
        if (executequery.Tables[0].Rows[0].Campaign != null)
            document.getElementById('txtcamp').value = executequery.Tables[0].Rows[0].Campaign;
        if (executequery.Tables[0].Rows[0].Page_prem != null)
            document.getElementById('drppageprem').value = executequery.Tables[0].Rows[0].Page_prem;
        if (executequery.Tables[0].Rows[0].Prem_per != null) {
            document.getElementById('txtpremper').value = executequery.Tables[0].Rows[0].Prem_per;
        }

        //***

        if (executequery.Tables[0].Rows[0].Page_amount != null) {
            document.getElementById('txtpageamt').value = executequery.Tables[0].Rows[0].Page_amount;
        }
        if (executequery.Tables[0].Rows[0].Gross_amount != null) {
            document.getElementById('txtgrossamt').value = executequery.Tables[0].Rows[0].Gross_amount;
        }

        //Inserting in hidden field to compare new and  Previous amount 
        if (executequery.Tables[0].Rows[0].Bill_amount != null) {
            document.getElementById('hiddenprevamt').value = executequery.Tables[0].Rows[0].Bill_amount;
        }
        //new field
        if (executequery.Tables[0].Rows[0].LOCALGROSSAMT != null) {
            document.getElementById('txtgrossamtlocal').value = executequery.Tables[0].Rows[0].LOCALGROSSAMT;
        }

        //Inserting in hidden field to compare new and  Previous amount 
        if (executequery.Tables[0].Rows[0].LOCALBILLAMT != null) {
            document.getElementById('txtbillamtlocal').value = executequery.Tables[0].Rows[0].LOCALBILLAMT;
        }

        if (executequery.Tables[0].Rows[0].Bill_amount != null) {
            document.getElementById('txtbillamt').value = executequery.Tables[0].Rows[0].Bill_amount;
            document.getElementById('hiddenbillamt').value = document.getElementById('txtbillamt').value;
        }
        if (executequery.Tables[0].Rows[0].Box_code != null) {
            document.getElementById('drpboxcode').value = executequery.Tables[0].Rows[0].Box_code;
        }
        if (executequery.Tables[0].Rows[0].Box_no != null) {
            document.getElementById('txtboxno').value = executequery.Tables[0].Rows[0].Box_no;
        }
        if (executequery.Tables[0].Rows[0].Box_agency.toString() == "1") {
            document.getElementById('chkage').checked = true;
        }
        else {
            document.getElementById('chkage').checked = false;
        }
        if (executequery.Tables[0].Rows[0].Box_client.toString() == "1") {
            document.getElementById('chkclie').checked = true;
        }
        else {
            document.getElementById('chkclie').checked = false;
        }
        if (executequery.Tables[0].Rows[0].Box_address != null) {
            document.getElementById('txtboxaddress').value = executequery.Tables[0].Rows[0].Box_address;
        }
        if (executequery.Tables[0].Rows[0].Tfn == "1") {
            document.getElementById('chktfn').value = true;
        }
        else {
            document.getElementById('chktfn').value = false;
        }
        if (executequery.Tables[0].Rows[0].Ad_size_column != null) {
            document.getElementById('txtcolum').value = executequery.Tables[0].Rows[0].Ad_size_column;
        }
        //recorrect it
        if (executequery.Tables[0].Rows[0].Special_disc_per != null) {
            document.getElementById('txtspediscper').value = executequery.Tables[0].Rows[0].Special_disc_per;
        }
        if (executequery.Tables[0].Rows[0].Space_disc_per != null) {
            document.getElementById('txtspadiscper').value = executequery.Tables[0].Rows[0].Space_disc_per;
        }
        //***
        if (executequery.Tables[0].Rows[0].Special_discount != null) {
            document.getElementById('txtspedisc').value = executequery.Tables[0].Rows[0].Special_discount;
        }
        if (executequery.Tables[0].Rows[0].Space_discount != null) {
            document.getElementById('txtspacedisc').value = executequery.Tables[0].Rows[0].Space_discount;
        }
        if (executequery.Tables[0].Rows[0].Paid_ins != null) {
            document.getElementById('txtpaid').value = executequery.Tables[0].Rows[0].Paid_ins;
        }
        if (executequery.Tables[0].Rows[0].Contract_rate != null) {
            document.getElementById('txtdealrate').value = executequery.Tables[0].Rows[0].Contract_rate;
        }
        if (document.getElementById('txtdealrate').value != "") {
            document.getElementById('chkcontract').checked = true;
        }
        if (executequery.Tables[0].Rows[0].Deviation != null) {
            document.getElementById('txtdeviation').value = executequery.Tables[0].Rows[0].Deviation;
        }
        if (executequery.Tables[0].Rows[0].Contract_name != null) {
            document.getElementById('txtcontractname').value = executequery.Tables[0].Rows[0].Contract_name;
            hidcontract = executequery.Tables[0].Rows[0].CONTRACT_NAME1;
        }
        if (executequery.Tables[0].Rows[0].Contract_type != null) {
            document.getElementById('txtcontracttype').value = executequery.Tables[0].Rows[0].Contract_type;
        }
        if (executequery.Tables[0].Rows[0].Variant_code == "") {
            document.getElementById('drpvarient').options.length = 0;
        }
        document.getElementById('hiddenvar').value = document.getElementById('drpvarient').value = executequery.Tables[0].Rows[0].Variant_code;

        if (executequery.Tables[0].Rows[0].Card_name != null) {
            document.getElementById('txtcardname').value = executequery.Tables[0].Rows[0].Card_name;
        }
        if (executequery.Tables[0].Rows[0].Card_type != null) {
            document.getElementById('drptype').value = executequery.Tables[0].Rows[0].Card_type;
        }
        if (executequery.Tables[0].Rows[0].Card_month != null) {
            document.getElementById('drpmonth').value = executequery.Tables[0].Rows[0].Card_month;
        }
        if (executequery.Tables[0].Rows[0].Card_year != null) {
            document.getElementById('drpyear').value = executequery.Tables[0].Rows[0].Card_year;
        }
        if (executequery.Tables[0].Rows[0].Card_number != null) {
            document.getElementById('txtcardno').value = executequery.Tables[0].Rows[0].Card_number;
        }
        if (executequery.Tables[0].Rows[0].Receipt_no != null) {
            document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value = executequery.Tables[0].Rows[0].Receipt_no;
        }
        else
            document.getElementById('hiddenreceiptno').value = document.getElementById('txtreceipt').value = "";
        //get check info
        if (document.getElementById('drppaymenttype').value == "CH0" || document.getElementById('drppaymenttype').value == "DD0" || document.getElementById('drppaymenttype').value == 'PO0' || document.getElementById('drppaymenttype').value == 'AD0') {
            /* var ds_chq=Booking_master.ChequeInfo(document.getElementById('hiddencompcode').value,document.getElementById('txtreceipt').value);
            if(ds_chq.value!=null)
            {
            if(ds_chq.value.Tables[0].Rows.length>0)
            {
            if(ds_chq.value.Tables[0].Rows[0].chno!=null)
            document.getElementById('ttextchqno').value=ds_chq.value.Tables[0].Rows[0].chno;  
            else
            document.getElementById('ttextchqno').value="";    
            var cDate="";
            if(ds_chq.value.Tables[0].Rows[0].chdt!=null)
            {
            if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
            {
            cDate=ds_chq.value.Tables[0].Rows[0].chdt;  
            }          
            else if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
            {
            var txt=ds_chq.value.Tables[0].Rows[0].chdt.split("/");
            cDate=txt[1] + "/" + txt[0] + "/" + txt[2];
            }
            else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
            {
            var txt=ds_chq.value.Tables[0].Rows[0].chdt.split("/");
            cDate=txt[2] + "/" + txt[1] + "/" + txt[0];
            }
            }        
            document.getElementById('ttextchqdate').value=cDate; 
            if(ds_chq.value.Tables[0].Rows[0].amount!=null) 
            document.getElementById('ttextchqamt').value=ds_chq.value.Tables[0].Rows[0].amount;  
            else
            document.getElementById('ttextchqamt').value="";    
            if(document.getElementById('ttextchqamt').value.indexOf("-")>=0)
            document.getElementById('ttextchqamt').value=document.getElementById('ttextchqamt').value.replace("-","");
            if(ds_chq.value.Tables[0].Rows[0].bank!=null)    
            document.getElementById('ttextbankname').value=ds_chq.value.Tables[0].Rows[0].bank;                          
            else
            document.getElementById('ttextbankname').value="";   
                                
            if(ds_chq.value.Tables[0].Rows[0].cashbank!=null)    
            document.getElementById('drpourbank').value=ds_chq.value.Tables[0].Rows[0].cashbank;                          
            else
            document.getElementById('drpourbank').value="0";  
                                 
            }
            }*/
            if (executequery.Tables[0].Rows[0].CHK_DATE != null) {
                document.getElementById('ttextchqdate').value = executequery.Tables[0].Rows[0].CHK_DATE;
            }
            if (executequery.Tables[0].Rows[0].CHK_AMT != null) {
                document.getElementById('ttextchqamt').value = executequery.Tables[0].Rows[0].CHK_AMT;
            }
            if (executequery.Tables[0].Rows[0].CHK_BANK_NAME != null) {
                document.getElementById('ttextbankname').value = executequery.Tables[0].Rows[0].CHK_BANK_NAME;
            }
            if (executequery.Tables[0].Rows[0].OUR_BANK != null) {
                document.getElementById('drpourbank').value = executequery.Tables[0].Rows[0].OUR_BANK;
            }
            if (executequery.Tables[0].Rows[0].CHK_NO != null) {
                document.getElementById('ttextchqno').value = executequery.Tables[0].Rows[0].CHK_NO;
            }

        }

        else if (document.getElementById('drppaymenttype').value == "CR0") {
            var ds_chq = Booking_master.ChequeInfo(document.getElementById('hiddencompcode').value, document.getElementById('txtreceipt').value);
            if (ds_chq.value != null) {
                if (ds_chq.value.Tables[0].Rows.length > 0) {
                    if (ds_chq.value.Tables[0].Rows[0].bank != null)
                        document.getElementById('txtcardname').value = ds_chq.value.Tables[0].Rows[0].bank;
                    else
                        document.getElementById('txtcardname').value = "";
                    if (ds_chq.value.Tables[0].Rows[0].remark != null)
                        document.getElementById('drptype').value = ds_chq.value.Tables[0].Rows[0].remark;
                    else
                        document.getElementById('drptype').value = "";
                    if (ds_chq.value.Tables[0].Rows[0].chno != null)
                        document.getElementById('txtcardno').value = ds_chq.value.Tables[0].Rows[0].chno;
                    else
                        document.getElementById('txtcardno').value = "";
                    if (ds_chq.value.Tables[0].Rows[0].chdt != null) {
                        var txt = ds_chq.value.Tables[0].Rows[0].chdt.split("/");
                        document.getElementById('drpmonth').value = parseInt(txt[1], 10);
                        document.getElementById('drpyear').value = txt[2];
                    }
                }
            }
        }
        //*********************
        //}    
        if (executequery.Tables[0].Rows[0].Material_status != null) {
            document.getElementById('drpmatsta').value = executequery.Tables[0].Rows[0].Material_status;
        }



        if (executequery.Tables[0].Rows[0].Ad_sub_cat_code == null) // || executequery.Tables[0].Rows[0].Ad_Subcat3.toString() == "")
        {
            document.getElementById('drpadcat3').options.length = 0;
            document.getElementById('hiddenadscat3').value = "";
        }
        else {
            res3 = null;
            res3 = Booking_master.getvalfromadcat3(executequery.Tables[0].Rows[0].Ad_sub_cat_code, document.getElementById('hiddencompcode').value, "0");
            var dacat = res3.value;
            if (dacat == null) {
                alert(dacat.error.description);
                return false;
            }

            ////////////////////////////////////////////////////////////////
            document.getElementById('drpadcat3').options.length = 0;
            document.getElementById('drpadcat3').options[0] = new Option("Select", "0");
            for (var k = 0; k < dacat.Tables[0].Rows.length; k++) {
                document.getElementById('drpadcat3').options[document.getElementById('drpadcat3').options.length] = new Option(dacat.Tables[0].Rows[k].catname, dacat.Tables[0].Rows[k].catcode);
                document.getElementById('drpadcat3').options.length;
            }

        }

        if (executequery.Tables[0].Rows[0].Ad_Subcat3 != null) {
            document.getElementById('hiddenadscat3').value = document.getElementById('drpadcat3').value = executequery.Tables[0].Rows[0].Ad_Subcat3;
        }

        ////////////////////this is to bind the adcat4 drp down
        if (executequery.Tables[0].Rows[0].Ad_Subcat3 == null || executequery.Tables[0].Rows[0].Ad_Subcat3.toString() == "") {
            document.getElementById('drpadcat4').options.length = 0;
            document.getElementById('hiddenadscat4').value = "";
        }
        else {
            ////////////when 1 than bind the adscat4 drp down
            res3 = null;
            res3 = Booking_master.getvalfromadcat3(executequery.Tables[0].Rows[0].Ad_Subcat3, document.getElementById('hiddencompcode').value, "1");
            var dacat = res3.value;
            if (dacat == null) {
                alert(dacat.error.description);
                return false;
            }


            ////////////////////////////////////////////////////////////////
            document.getElementById('drpadcat4').options.length = 0;
            document.getElementById('drpadcat4').options[0] = new Option("Select", "0");
            for (var k = 0; k < dacat.Tables[0].Rows.length; k++) {
                document.getElementById('drpadcat4').options[document.getElementById('drpadcat4').options.length] = new Option(dacat.Tables[0].Rows[k].Cat_Name, dacat.Tables[0].Rows[k].Cat_Code);
                document.getElementById('drpadcat4').options.length;
            }
        }
        if (executequery.Tables[0].Rows[0].Ad_Subcat4 != null) {
            document.getElementById('hiddenadscat4').value = document.getElementById('drpadcat4').value = executequery.Tables[0].Rows[0].Ad_Subcat4;
        }

        ///bind adcat5 drpdown
        if (executequery.Tables[0].Rows[0].Ad_Subcat4 == null || executequery.Tables[0].Rows[0].Ad_Subcat4.toString() == "") {
            document.getElementById('drpadcat5').options.length = 0;
            document.getElementById('hiddenadscat5').value = "";
        }
        else {
            ////////////when 1 than bind the adscat4 drp down
            res3 = null;
            res3 = Booking_master.getvalfromadcat3(executequery.Tables[0].Rows[0].Ad_Subcat4, document.getElementById('hiddencompcode').value, "2");
            var dacat = res3.value;
            if (dacat == null) {
                alert(dacat.error.description);
                return false;
            }


            ////////////////////////////////////////////////////////////////
            document.getElementById('drpadcat5').options.length = 0;
            document.getElementById('drpadcat5').options[0] = new Option("Select", "0");
            for (var k = 0; k < dacat.Tables[0].Rows.length; k++) {
                document.getElementById('drpadcat5').options[document.getElementById('drpadcat5').options.length] = new Option(dacat.Tables[0].Rows[k].Cat_Name, dacat.Tables[0].Rows[k].Cat_Code);
                document.getElementById('drpadcat5').options.length;
            }
        }
        if (executequery.Tables[0].Rows[0].Ad_subcat5 != null) {
            document.getElementById('hiddenadscat5').value = document.getElementById('drpadcat5').value = executequery.Tables[0].Rows[0].Ad_subcat5;
        }


        //////bind the bg color drp down 
        ////            if(executequery.Tables[0].Rows[0].Bg_color!=null)
        ////            {
        ////                document.getElementById('drpbgcolor').value = executequery.Tables[0].Rows[0].Bg_color;
        ////            }    
        ////            if(executequery.Tables[0].Rows[0].Bullet_code!=null)
        ////            {
        ////                document.getElementById('drpbullet').value = executequery.Tables[0].Rows[0].Bullet_code;
        ////            }    
        ////            if(executequery.Tables[0].Rows[0].Bullet_premium!=null)
        ////            {
        ////                document.getElementById('txtbullprem').value = executequery.Tables[0].Rows[0].Bullet_premium;
        ////            }   

        if (executequery.Tables[0].Rows[0].RETAINER1 != null) {
            document.getElementById('drpretainer').value = executequery.Tables[0].Rows[0].RETAINER1;
        }
        if (executequery.Tables[0].Rows[0].ADD_AGENCY_COMM != null) {
            if (document.getElementById('txtaddagencycommrate') != null) {
                document.getElementById('txtaddagencycommrate').value = executequery.Tables[0].Rows[0].ADD_AGENCY_COMM;
            }
        }
        getSharing();
        if (document.getElementById('drpbooktype').value == "2" || document.getElementById('drpbooktype').value == "6")
            getFMGRef();
        getmultiexe();
    }

    else {
        alert("Your Search Produces No Result");
        clearClick();
        return false;
    }

    // }
    updateStatus();
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;

    if (executequery.Tables[0].Rows.length - 1 == 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
    }
    ////// we have called a javascript function to show the grid during execution mode
    //ScriptManager.RegisterClientScriptBlock(this, typeof(Booking_master), "cc", "bindpackage()", true);
    document.getElementById('btndel').disabled = true;

    showcardinfo(executequery.Tables[0].Rows[0].Bill_pay);
    showgridexecute();
    document.getElementById('txtRetainercomm').disabled = true;
    if (document.getElementById('txtaddagencycommrateamt') != null) {
        document.getElementById('txtaddagencycommrateamt').disabled = true;
        document.getElementById('txtaddagencycommrate').disabled = true;
    }
    document.getElementById('drpadstype').disabled = true;
    //        if (document.getElementById('hiddenaudit').value != "")
    //        {
    //            modifyClick();
    //        }        

    setButtonImages();
    return false;
}