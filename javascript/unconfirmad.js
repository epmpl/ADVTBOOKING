// JScript File


function refreshControl()
{
document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
document.getElementById('txtretainername').style.backgroundColor="#FFFFFF";
document.getElementById('txtratecode').style.backgroundColor="#FFFFFF";
document.getElementById('txtclient').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat4').style.backgroundColor="#FFFFFF";
document.getElementById('txtpaymode').style.backgroundColor="#FFFFFF";
document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFFFF";
document.getElementById('txtcardrate').style.backgroundColor="#FFFFFF";
document.getElementById('txtagreedamount').style.backgroundColor="#FFFFFF";
document.getElementById('txtarea').style.backgroundColor="#FFFFFF";
document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";
document.getElementById('txtgrossamt').style.backgroundColor="#FFFFFF";
document.getElementById('txtspacediscount').style.backgroundColor="#FFFFFF";
document.getElementById('txtcardamount').style.backgroundColor="#FFFFFF";
document.getElementById('txtcontractname').style.backgroundColor="#FFFFFF";
document.getElementById('txtaddagecomm').style.backgroundColor="#FFFFFF";
document.getElementById('txtpackage').style.backgroundColor="#FFFFFF";
document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
document.getElementById('txtbillamount').style.backgroundColor="#FFFFFF";
document.getElementById('txtpageposition').style.backgroundColor="#FFFFFF";
document.getElementById('txtexecutivename').style.backgroundColor="#FFFFFF";
document.getElementById('txtlines').style.backgroundColor="#FFFFFF";
document.getElementById('txtbookingtype').style.backgroundColor="#FFFFFF";
document.getElementById('txtheight').style.backgroundColor="#FFFFFF";
document.getElementById('txtcolourtype').style.backgroundColor="#FFFFFF";
document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
//document.getElementById('txtbrand').style.backgroundColor="#FFFFFF";
document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFFFF";
//document.getElementById('txtproduct').style.backgroundColor="#FFFFFF";
document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";

document.getElementById('txtschemetype').style.backgroundColor="#FFFFFF";
document.getElementById('txtpositionpre').style.backgroundColor="#FFFFFF";
//document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFFFF";
document.getElementById('txtpaid').style.backgroundColor="#FFFFFF";
document.getElementById('txtpublishdate').style.backgroundColor="#FFFFFF";
document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
//document.getElementById('txtcurrencytype').style.backgroundColor="#FFFFFF";
document.getElementById('txtpositionpremium').style.backgroundColor="#FFFFFF";
document.getElementById('txtretainercommission').style.backgroundColor="#FFFFFF";
document.getElementById('txtadcategory').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat1').style.backgroundColor="#FFFFFF";
document.getElementById('txtuom').style.backgroundColor="#FFFFFF";
document.getElementById('txtoutstanding').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat2').style.backgroundColor="#FFFFFF";
document.getElementById('txtspecialcharge').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat3').style.backgroundColor="#FFFFFF";
document.getElementById('txtrono').style.backgroundColor="#FFFFFF";
document.getElementById('txtrostatus').style.backgroundColor="#FFFFFF";
document.getElementById('txtremarks').style.backgroundColor = "#FFFFFF";
document.getElementById('txtagency').value = '';
document.getElementById('txtretainername').value = '';
document.getElementById('txtratecode').value = '';
document.getElementById('txtclient').value = '';
document.getElementById('txtadsubcat4').value = '';
document.getElementById('txtpaymode').value = '';
document.getElementById('txtnoofinsertion').value = '';
document.getElementById('txtcardrate').value = '';
document.getElementById('txtagreedamount').value = '';
document.getElementById('txtarea').value = '';
document.getElementById('txtagreedrate').value = '';
document.getElementById('txtgrossamt').value = '';
document.getElementById('txtspacediscount').value = '';
document.getElementById('txtcardamount').value = '';
document.getElementById('txtcontractname').value = '';
document.getElementById('txtaddagecomm').value = '';
document.getElementById('txtpackage').value = '';
document.getElementById('txtdiscount').value = '';
document.getElementById('txtbillamount').value = '';
document.getElementById('txtpageposition').value = '';
document.getElementById('txtexecutivename').value = '';
document.getElementById('txtlines').value = '';
document.getElementById('txtbookingtype').value = '';
document.getElementById('txtheight').value = '';
document.getElementById('txtcolourtype').value = '';
document.getElementById('txtwidth').value = '';
//document.getElementById('txtbrand').value='';
document.getElementById('txtspecialdiscount').value = '';
//document.getElementById('txtproduct').value='';
document.getElementById('txtdiscount').value = '';
document.getElementById('txtagreedrate').value = '';

document.getElementById('txtschemetype').value = '';
document.getElementById('txtpositionpre').value = '';
//document.getElementById('txtnoofcolumns').value='';
document.getElementById('txtpaid').value = '';
document.getElementById('txtpublishdate').value = '';
document.getElementById('txtwidth').value = '';
//document.getElementById('txtcurrencytype').value='';
document.getElementById('txtpositionpremium').value = '';
document.getElementById('txtretainercommission').value = '';
document.getElementById('txtadcategory').value = '';
document.getElementById('txtadsubcat1').value = '';
document.getElementById('txtuom').value = '';
document.getElementById('txtoutstanding').value = '';
document.getElementById('txtadsubcat2').value = '';
document.getElementById('txtspecialcharge').value = '';
document.getElementById('txtadsubcat3').value = '';
document.getElementById('txtrono').value = '';
document.getElementById('txtrostatus').value = '';
document.getElementById('txtremarks').value = '';
}
function refresh()
{
if(document.getElementById('hiddenmodify').value=="1")
{
    openbooking(document.getElementById('hiddenbookingid').value,document.getElementById('hiddenid').value,document.getElementById('hiddenrowcount').value,document.getElementById('hiddenadtype').value,'refresh');
   document.getElementById('hiddenrefresh').value='1';
   document.getElementById('hiddenmodify').value="0";
 }
   return false;
}
function openbookingModify()
{

document.getElementById('btnrefresh').disabled=false;
if(document.getElementById('hiddenadtype').value=="DI0")
{
     win=window.open('Booking_master.aspx?cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
}
else if(document.getElementById('hiddenadtype').value=="CL0")
{
     win=window.open('Classified_Booking.aspx?cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
}  
document.getElementById('hiddenmodify').value="1";   
}
function openbooking(cioid,id,length,adtype)
{
refreshControl();
if(id!="undefined")
{
    document.getElementById('hiddenid').value = id;
}
var i=0;
for(i=0;i<parseInt(length);i++)
{
    document.getElementById('cio'+i).style.color="blue";
}

document.getElementById(document.getElementById('hiddenid').value).style.color="red";
document.getElementById('hiddenbookingid').value=cioid;


document.getElementById('btnaudit').disabled=false;
document.getElementById('btnpreview').disabled=false;
document.getElementById('btnunaudit').disabled=false;
document.getElementById('btnsave1').disabled=false;
if(document.getElementById('txtremarks')!=null)
    document.getElementById('txtremarks').disabled=false;

if(document.getElementById('btnmodify')!=null)
    document.getElementById('btnmodify').disabled=false;

unconfirmad.execute(cioid,document.getElementById('hiddencompcode').value,adtype,exec_callback);

    //alert(cioid);
}
function exec_callback(response)
{
    var ds=response.value;
    if(ds!=null)
    {
    var len=ds.Tables[0].Rows.length;
    if(len!="0")
    {
    document.getElementById('hiddenuomdesc').value=ds.Tables[0].Rows[0].uom_desc;
    if(document.getElementById('hiddenrefresh').value=='1' && ds.Tables[2].Rows.length>0)
    {
        if(ds.Tables[0].Rows[0].AgencyName!=ds.Tables[2].Rows[0].AgencyName)
        {
         document.getElementById('txtagency').style.backgroundColor="#FFFF80";
        }
        else
        {
         document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
        }
        if(ds.Tables[0].Rows[0].AgencySubCode!=ds.Tables[2].Rows[0].AgencySubCode)
         {
             document.getElementById('txtagencysubcode').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtagencysubcode').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].Client!=ds.Tables[2].Rows[0].Client)
         {
             document.getElementById('txtclient').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtclient').style.backgroundColor="#FFFFFF";
         }
         
           if(ds.Tables[0].Rows[0].Agency_type!=ds.Tables[2].Rows[0].Agency_type)
         {
             document.getElementById('txtagencytype').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtagencytype').style.backgroundColor="#FFFFFF";
         }
         
             if(ds.Tables[0].Rows[0].Agency_address!=ds.Tables[2].Rows[0].Agency_address)
         {
             document.getElementById('txtadress2').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtadress2').style.backgroundColor="#FFFFFF";
         }
         
            if(ds.Tables[0].Rows[0].Client_address!=ds.Tables[2].Rows[0].Client_address)
         {
             document.getElementById('txtaddress1').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtaddress1').style.backgroundColor="#FFFFFF";
         }
         
               if(ds.Tables[0].Rows[0].Agency_status!=ds.Tables[2].Rows[0].Agency_status)
         {
             document.getElementById('txtstatus').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtstatus').style.backgroundColor="#FFFFFF";
         }
         
               if(ds.Tables[0].Rows[0].PayMode!=ds.Tables[2].Rows[0].PayMode)
         {
             document.getElementById('txtpaymode').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpaymode').style.backgroundColor="#FFFFFF";
         }
         
                  if(ds.Tables[0].Rows[0].Agency_credit!=ds.Tables[2].Rows[0].Agency_credit)
         {
             document.getElementById('txtcreditperiod').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcreditperiod').style.backgroundColor="#FFFFFF";
         }
         
                     if(ds.Tables[0].Rows[0].RO_No!=ds.Tables[2].Rows[0].RO_No)
         {
             document.getElementById('txtrono').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtrono').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].RO_Date!=ds.Tables[2].Rows[0].RO_Date)
         {
             document.getElementById('txtrodate').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtrodate').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].ro_status!=ds.Tables[2].Rows[0].ro_status)
         {
             document.getElementById('txtrostatus').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtrostatus').style.backgroundColor="#FFFFFF";
         }
         
            if(ds.Tables[0].Rows[0].Dockit_no!=ds.Tables[2].Rows[0].Dockit_no)
         {
             document.getElementById('txtdockitno').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtdockitno').style.backgroundColor="#FFFFFF";
         }
         
              if(ds.Tables[0].Rows[0].Key_no!=ds.Tables[2].Rows[0].Key_no)
         {
             document.getElementById('txtkeyno').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtkeyno').style.backgroundColor="#FFFFFF";
         }
         
                  if(ds.Tables[0].Rows[0].execname!=ds.Tables[2].Rows[0].execname)
         {
             document.getElementById('txtexecutivename').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtexecutivename').style.backgroundColor="#FFFFFF";
         }
         
        if(ds.Tables[0].Rows[0].Executive_zone!=ds.Tables[2].Rows[0].Executive_zone)
         {
             document.getElementById('txtexecutivezone').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtexecutivezone').style.backgroundColor="#FFFFFF";
         }
        
        if(ds.Tables[0].Rows[0].Agency_out!=ds.Tables[2].Rows[0].Agency_out)
         {
             document.getElementById('txtoutstanding').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtoutstanding').style.backgroundColor="#FFFFFF";
         }
         
           if(ds.Tables[0].Rows[0].categoryname!=ds.Tables[2].Rows[0].categoryname)
         {
             document.getElementById('txtadcategory').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtadcategory').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].subcategoryname!=ds.Tables[2].Rows[0].subcategoryname)
         {
             document.getElementById('txtadsubcat').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtadsubcat').style.backgroundColor="#FFFFFF";
         }
         
           
         if(ds.Tables[0].Rows[0].Brand!=ds.Tables[2].Rows[0].Brand)
         {
             document.getElementById('txtbrand').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtbrand').style.backgroundColor="#FFFFFF";
         }
         
           if(ds.Tables[0].Rows[0].product!=ds.Tables[2].Rows[0].product)
         {
             document.getElementById('txtproduct').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtproduct').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].UOM!=ds.Tables[2].Rows[0].UOM)
         {
             document.getElementById('txtuom').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtuom').style.backgroundColor="#FFFFFF";
         }
         
          if(ds.Tables[0].Rows[0].PagePremium!=ds.Tables[2].Rows[0].PagePremium)
         {
             document.getElementById('txtpagepremium').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpagepremium').style.backgroundColor="#FFFFFF";
         }
         
         if(ds.Tables[0].Rows[0].PositionPremium!=ds.Tables[2].Rows[0].PositionPremium)
         {
             document.getElementById('txtpositionpremium').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpositionpremium').style.backgroundColor="#FFFFFF";
         }
           if(ds.Tables[0].Rows[0].Ad_size_column!=ds.Tables[2].Rows[0].Ad_size_column)
         {
             document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFFFF";
         }
         
          if(ds.Tables[0].Rows[0].Ad_size_height!=ds.Tables[2].Rows[0].Ad_size_height)
         {
             document.getElementById('txtheight').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtheight').style.backgroundColor="#FFFFFF";
         }
         
          if(ds.Tables[0].Rows[0].Ad_size_width!=ds.Tables[2].Rows[0].Ad_size_width)
         {
             document.getElementById('txtwidth').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
         }
         
           if(ds.Tables[0].Rows[0].Currency!=ds.Tables[2].Rows[0].Currency)
         {
             document.getElementById('txtcurrencytype').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcurrencytype').style.backgroundColor="#FFFFFF";
         }  
         
         if(ds.Tables[0].Rows[0].Insertion_date!=ds.Tables[2].Rows[0].Insertion_date)
         {
             document.getElementById('txtpublishdate').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpublishdate').style.backgroundColor="#FFFFFF";
         }  
         
         if(ds.Tables[0].Rows[0].No_of_insertion!=ds.Tables[2].Rows[0].No_of_insertion)
         {
             document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFFFF";
         }  
         
         
          if(ds.Tables[0].Rows[0].Contract_name!=ds.Tables[2].Rows[0].Contract_name)
         {
             document.getElementById('txtcontractname').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcontractname').style.backgroundColor="#FFFFFF";
         }  
         
          if(ds.Tables[0].Rows[0].Paid_ins!=ds.Tables[2].Rows[0].Paid_ins)
         {
             document.getElementById('txtpaid').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtpaid').style.backgroundColor="#FFFFFF";
         } 
          if(ds.Tables[0].Rows[0].Card_amount!=ds.Tables[2].Rows[0].Card_amount)
         {
             document.getElementById('txtcardamount').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcardamount').style.backgroundColor="#FFFFFF";
         } 
         
           if(ds.Tables[0].Rows[0].Agrred_rate!=ds.Tables[2].Rows[0].Agrred_rate)
         {
             document.getElementById('txtagreedrate').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";
         } 
         
           if(ds.Tables[0].Rows[0].Special_discount!=ds.Tables[2].Rows[0].Special_discount)
         {
             document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFFFF";
         } 
         
           if(ds.Tables[0].Rows[0].Discount!=ds.Tables[2].Rows[0].Discount)
         {
             document.getElementById('txtdiscount').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
         } 
          
     }   
      if(ds.Tables[0].Rows[0].uom_desc==null)
    {
        document.getElementById('txtlines').value="";
        document.getElementById('txtarea').value="";
     }   
      else  {
        if(ds.Tables[0].Rows[0].uom_desc=='CD')
        {
           document.getElementById('txtlines').value="";
           document.getElementById('txtarea').value=ds.Tables[0].Rows[0].Total_area;
           
        }
        else
        {
            document.getElementById('txtlines').value=ds.Tables[0].Rows[0].Total_area;
            document.getElementById('txtarea').value="";
        }
         //document.getElementById('txtlines').value=ds.Tables[0].Rows[0].Total_area;
    }
    if(ds.Tables[0].Rows[0].AgencyName==null)
    {
        document.getElementById('txtagency').value=="";
    }
    else
    {
        document.getElementById('txtagency').value=ds.Tables[0].Rows[0].AgencyName;
     }
         
     
     
     if(ds.Tables[0].Rows[0].Package_cod==null)
     {
     document.getElementById('txtpackage').value="";
     }
     else
     {
     document.getElementById('txtpackage').value=ds.Tables[0].Rows[0].Package_cod;
     }
    if(ds.Tables[0].Rows[0].Client==null)
    {
    document.getElementById('txtclient').value="";
    }
    else
    {
    document.getElementById('txtclient').value=ds.Tables[0].Rows[0].Client;
    }
    if(ds.Tables[0].Rows[0].Agreed_amount==null)
    {
    document.getElementById('txtagreedamount').value="";
    }
    else
    {
     document.getElementById('txtagreedamount').value=ds.Tables[0].Rows[0].Agreed_amount;
    }
    if(ds.Tables[0].Rows[0].Space_discount==null)
    {
    document.getElementById('txtspacediscount').value="";
    }
    else
    {
    document.getElementById('txtspacediscount').value=ds.Tables[0].Rows[0].Space_discount;
    }
   if(ds.Tables[0].Rows[0].Special_charges==null)
   {
   document.getElementById('txtspecialcharge').value="";
   }
   else
   {
   document.getElementById('txtspecialcharge').value=ds.Tables[0].Rows[0].Special_charges;
   }
   if(ds.Tables[0].Rows[0].RETAINER1==null)
   {
   document.getElementById('txtretainername').value="";
   }
   else
   {
   document.getElementById('txtretainername').value=ds.Tables[0].Rows[0].RETAINER1;
   }
   if(ds.Tables[0].Rows[0].PayMode==null)
   {
   document.getElementById('txtpaymode').value="";
   }
   else
   {
   document.getElementById('txtpaymode').value=ds.Tables[0].Rows[0].PayMode;
   }
   if(ds.Tables[0].Rows[0].ADD_AGENCY_COMM==null)
   {
   document.getElementById('txtaddagecomm').value="";
   }
   else
   {
   document.getElementById('txtaddagecomm').value=ds.Tables[0].Rows[0].ADD_AGENCY_COMM;
   }
   if(ds.Tables[0].Rows[0].RO_No==null)
   {
   document.getElementById('txtrono').value="";
   }
   else
   {
   document.getElementById('txtrono').value=ds.Tables[0].Rows[0].RO_No;
   }
   if(ds.Tables[0].Rows[0].Book_type==null)
   {
   document.getElementById('txtbookingtype').value="";
   }
   else
   {
   document.getElementById('txtbookingtype').value=ds.Tables[0].Rows[0].Book_type;
   }
   if(ds.Tables[0].Rows[0].ro_status==null)
   {
   document.getElementById('txtrostatus').value="";
   }
   else
   {
   if(ds.Tables[0].Rows[0].ro_status=='1')
   {
    document.getElementById('txtrostatus').value='Confirm';
   }
   else{
    document.getElementById('txtrostatus').value='UnConfirm';
    }
   }
   if(ds.Tables[0].Rows[0].PagePremium==null)
   {
   document.getElementById('txtpageposition').value="";
   }
   else
   {
   document.getElementById('txtpageposition').value=ds.Tables[0].Rows[0].PagePremium;
   }
   if(ds.Tables[0].Rows[0].Subcat3==null || ds.Tables[0].Rows[0].Subcat3=="0")
   {
   document.getElementById('txtadsubcat2').value="";
   }
   else
   {
   document.getElementById('txtadsubcat2').value=ds.Tables[0].Rows[0].Subcat3;
   }
   if(ds.Tables[0].Rows[0].execname==null)
   {
   document.getElementById('txtexecutivename').value="";
   }
   else
   {
   document.getElementById('txtexecutivename').value=ds.Tables[0].Rows[0].execname;
   }
   if(ds.Tables[0].Rows[0].Scheme_type_code==null)
   {
   document.getElementById('txtschemetype').value="";
   }
   else
   {
   document.getElementById('txtschemetype').value=ds.Tables[0].Rows[0].Scheme_type_code;
   }
   if(ds.Tables[0].Rows[0].Agency_out==null)
   {
   document.getElementById('txtoutstanding').value="";
   }
   else
   {
   document.getElementById('txtoutstanding').value=ds.Tables[0].Rows[0].Agency_out;
   }
   if(ds.Tables[0].Rows[0].categoryname==null)
   {
   document.getElementById('txtadcategory').value="";
   }
   else
   {
   document.getElementById('txtadcategory').value=ds.Tables[0].Rows[0].categoryname;
   }
  
   if(ds.Tables[0].Rows[0].Bill_amount==null)
   {
   document.getElementById('txtbillamount').value="";
   }
   else
   {
   document.getElementById('txtbillamount').value=ds.Tables[0].Rows[0].Bill_amount;
   }
   if(ds.Tables[0].Rows[0].Rate_code==null)
    {
        document.getElementById('txtratecode').value="";
    }
    else
    {
        document.getElementById('txtratecode').value=ds.Tables[0].Rows[0].Rate_code;
    }
    if(ds.Tables[0].Rows[0].Card_rate==null)
    {
    document.getElementById('txtcardrate').value="";
    }
    else
    {
    document.getElementById('txtcardrate').value=ds.Tables[0].Rows[0].Card_rate;
    }
   if(ds.Tables[0].Rows[0].UOM==null)
   {
   document.getElementById('txtuom').value=""
   }
   else
   {
   document.getElementById('txtuom').value=ds.Tables[0].Rows[0].UOM;
   }
   if(ds.Tables[0].Rows[0].Subcat4==null || ds.Tables[0].Rows[0].Subcat4=="null")
   {
   document.getElementById('txtadsubcat3').value="";
   }
   else
   {
   document.getElementById('txtadsubcat3').value=ds.Tables[0].Rows[0].Subcat4;
   }
   if(ds.Tables[0].Rows[0].Subcat5==null)
   {
   document.getElementById('txtadsubcat4').value="";
   }
   else
   {
   document.getElementById('txtadsubcat4').value=ds.Tables[0].Rows[0].Subcat5;
   }
   if(ds.Tables[0].Rows[0].PositionPremium==null)
   {
    document.getElementById('txtpositionpre').value="";
   }
   else
   {
   document.getElementById('txtpositionpre').value=ds.Tables[0].Rows[0].PositionPremium;
   }
   if(ds.Tables[0].Rows[0].RETAINER_COMM==null)
   {
    document.getElementById('txtretainercommission').value="";
   }
   else
   {
   document.getElementById('txtretainercommission').value=ds.Tables[0].Rows[0].RETAINER_COMM;
   }
   if(ds.Tables[0].Rows[0].Trade_disc==null)
   {
   document.getElementById('txtagtradediscount').value="";
   }
   else
   {
   document.getElementById('txtagtradediscount').value=ds.Tables[0].Rows[0].Trade_disc;
   }
   if(ds.Tables[0].Rows[0].Ad_size_height==null)
   {
   document.getElementById('txtheight').value="";
   }
   else
   {
   document.getElementById('txtheight').value=ds.Tables[0].Rows[0].Ad_size_height;
   }
   if(ds.Tables[0].Rows[0].Ad_size_width==null)
   {
   document.getElementById('txtwidth').value=""
   }
   else
   {
   document.getElementById('txtwidth').value=ds.Tables[0].Rows[0].Ad_size_width;
   }
   if(ds.Tables[0].Rows[0].subcategoryname==null)
   {
   document.getElementById('txtadsubcat1').value="";
   }
   else
   {
    document.getElementById('txtadsubcat1').value=ds.Tables[0].Rows[0].subcategoryname;
   }
   if(ds.Tables[0].Rows[0].Ad_size_height==null)
   {
   document.getElementById('txtheight').value="";
   }
   else
   {
    document.getElementById('txtheight').value=ds.Tables[0].Rows[0].Ad_size_height;
   }
   if(ds.Tables[0].Rows[0].Ad_size_width==null)
   {
   document.getElementById('txtwidth').value="";
   }
   else
   {
    document.getElementById('txtwidth').value=ds.Tables[0].Rows[0].Ad_size_width;
   }
   if(ds.Tables[0].Rows[0].Insertion_date==null)
   {
   document.getElementById('txtpublishdate').value="";
   }
   else
   {
   document.getElementById('txtpublishdate').value=ds.Tables[0].Rows[0].Insertion_date;
   }
   if(ds.Tables[0].Rows[0].No_of_insertion==null)
   {
   document.getElementById('txtnoofinsertion').value="";
   }
   else
   {
   document.getElementById('txtnoofinsertion').value=ds.Tables[0].Rows[0].No_of_insertion;
   }
   
   if(ds.Tables[0].Rows[0].Contract_name==null)
   {
   document.getElementById('txtcontractname').value="";
   }
   else
   {
   document.getElementById('txtcontractname').value=ds.Tables[0].Rows[0].Contract_name;
   }
  if(ds.Tables[0].Rows[0].Paid_ins==null)
  {
  document.getElementById('txtpaid').value="";
  }
  else
  {
  document.getElementById('txtpaid').value=ds.Tables[0].Rows[0].Paid_ins;
  }
   if(ds.Tables[0].Rows[0].Card_amount==null)
   {
   document.getElementById('txtcardamount').value="";
   }
   else
   {
   document.getElementById('txtcardamount').value=ds.Tables[0].Rows[0].Card_amount;
   }
   if(ds.Tables[0].Rows[0].Agrred_rate==null)
   {
   document.getElementById('txtagreedrate').value==""
   }
   else
   {
    document.getElementById('txtagreedrate').value=ds.Tables[0].Rows[0].Agrred_rate;
   }
   if(ds.Tables[0].Rows[0].Color_cod==null)
   {
   document.getElementById('txtcolourtype').value==""
   }
   else
   {
    document.getElementById('txtcolourtype').value=ds.Tables[0].Rows[0].Color_cod;
   }
   if(ds.Tables[0].Rows[0].Gross_amount==null)
   {
   document.getElementById('txtgrossamt').value==""
   }
   else
   {
    document.getElementById('txtgrossamt').value=ds.Tables[0].Rows[0].Gross_amount;
   }
   if(document.getElementById('txtgrossamt').value!="" && document.getElementById('txtbillamount').value)
   {
    document.getElementById('txtagencydiscinarte').value= parseFloat(document.getElementById('txtgrossamt').value) - parseFloat(document.getElementById('txtbillamount').value);
   }
//    if(ds.Tables[0].Rows[0].remarks==null)
//   {
//   document.getElementById('txtremarks').value=""
//   }
//   else
//   {
//    document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
//   }
   
   //document.getElementById('txtschemetype').value=ds.Tables[0].Rows[0].Contract_name;
   if(ds.Tables[0].Rows[0].Special_discount==null)
   {
   document.getElementById('txtspecialdiscount').value="";
   }
   else
   {
   document.getElementById('txtspecialdiscount').value=ds.Tables[0].Rows[0].Special_discount;
   }
   
  if(ds.Tables[0].Rows[0].Discount==null)
  {
   document.getElementById('txtdiscount').value="";
  }
  else
  {
  document.getElementById('txtdiscount').value=ds.Tables[0].Rows[0].Discount;
  }
  
  if(ds.Tables[0].Rows[0].Ad_type_code==null)
  {
   document.getElementById('hiddenadtype').value="";
  }
  else
  {
  document.getElementById('hiddenadtype').value=ds.Tables[0].Rows[0].Ad_type_code;
  }
//  var count=ds.Tables[1].Rows[0].count;
//  if(count==0)
//  {
//    document.getElementById('btnaudit').value='Audit';
//  }
//  else
//  {
//    
//    document.getElementById('btnaudit').value='ReAudit';
//    //-----------------------------------------------
//    if(ds.Tables[3].Rows.length>0)
//    {
//     if(ds.Tables[0].Rows[0].AgencyName!=ds.Tables[3].Rows[0].AgencyName)
//        {
//         document.getElementById('txtagency').style.backgroundColor="#FFFF80";
//        }
//        else
//        {
//         document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
//        }
//        if(ds.Tables[0].Rows[0].AgencySubCode!=ds.Tables[3].Rows[0].AgencySubCode)
//         {
//             document.getElementById('txtagencysubcode').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtagencysubcode').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].Client!=ds.Tables[3].Rows[0].Client)
//         {
//             document.getElementById('txtclient').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtclient').style.backgroundColor="#FFFFFF";
//         }
//         
//           if(ds.Tables[0].Rows[0].Agency_type!=ds.Tables[3].Rows[0].Agency_type)
//         {
//             document.getElementById('txtagencytype').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtagencytype').style.backgroundColor="#FFFFFF";
//         }
//         
//             if(ds.Tables[0].Rows[0].Agency_address!=ds.Tables[3].Rows[0].Agency_address)
//         {
//             document.getElementById('txtadress2').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtadress2').style.backgroundColor="#FFFFFF";
//         }
//         
//            if(ds.Tables[0].Rows[0].Client_address!=ds.Tables[3].Rows[0].Client_address)
//         {
//             document.getElementById('txtaddress1').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtaddress1').style.backgroundColor="#FFFFFF";
//         }
//         
//               if(ds.Tables[0].Rows[0].Agency_status!=ds.Tables[3].Rows[0].Agency_status)
//         {
//             document.getElementById('txtstatus').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtstatus').style.backgroundColor="#FFFFFF";
//         }
//         
//               if(ds.Tables[0].Rows[0].PayMode!=ds.Tables[3].Rows[0].PayMode)
//         {
//             document.getElementById('txtpaymode').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpaymode').style.backgroundColor="#FFFFFF";
//         }
//         
//                  if(ds.Tables[0].Rows[0].Agency_credit!=ds.Tables[3].Rows[0].Agency_credit)
//         {
//             document.getElementById('txtcreditperiod').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcreditperiod').style.backgroundColor="#FFFFFF";
//         }
//         
//                     if(ds.Tables[0].Rows[0].RO_No!=ds.Tables[3].Rows[0].RO_No)
//         {
//             document.getElementById('txtrono').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtrono').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].RO_Date!=ds.Tables[3].Rows[0].RO_Date)
//         {
//             document.getElementById('txtrodate').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtrodate').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].ro_status!=ds.Tables[3].Rows[0].ro_status)
//         {
//             document.getElementById('txtrostatus').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtrostatus').style.backgroundColor="#FFFFFF";
//         }
//         
//            if(ds.Tables[0].Rows[0].Dockit_no!=ds.Tables[3].Rows[0].Dockit_no)
//         {
//             document.getElementById('txtdockitno').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtdockitno').style.backgroundColor="#FFFFFF";
//         }
//         
//              if(ds.Tables[0].Rows[0].Key_no!=ds.Tables[3].Rows[0].Key_no)
//         {
//             document.getElementById('txtkeyno').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtkeyno').style.backgroundColor="#FFFFFF";
//         }
//         
//                  if(ds.Tables[0].Rows[0].execname!=ds.Tables[3].Rows[0].execname)
//         {
//             document.getElementById('txtexecutivename').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtexecutivename').style.backgroundColor="#FFFFFF";
//         }
//         
//        if(ds.Tables[0].Rows[0].Executive_zone!=ds.Tables[3].Rows[0].Executive_zone)
//         {
//             document.getElementById('txtexecutivezone').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtexecutivezone').style.backgroundColor="#FFFFFF";
//         }
//        
//        if(ds.Tables[0].Rows[0].Agency_out!=ds.Tables[3].Rows[0].Agency_out)
//         {
//             document.getElementById('txtoutstanding').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtoutstanding').style.backgroundColor="#FFFFFF";
//         }
//         
//           if(ds.Tables[0].Rows[0].categoryname!=ds.Tables[3].Rows[0].categoryname)
//         {
//             document.getElementById('txtadcategory').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtadcategory').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].subcategoryname!=ds.Tables[3].Rows[0].subcategoryname)
//         {
//             document.getElementById('txtadsubcat').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtadsubcat').style.backgroundColor="#FFFFFF";
//         }
//         
//           
//         if(ds.Tables[0].Rows[0].Brand!=ds.Tables[3].Rows[0].Brand)
//         {
//             document.getElementById('txtbrand').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtbrand').style.backgroundColor="#FFFFFF";
//         }
//         
//           if(ds.Tables[0].Rows[0].product!=ds.Tables[3].Rows[0].product)
//         {
//             document.getElementById('txtproduct').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtproduct').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].UOM!=ds.Tables[3].Rows[0].UOM)
//         {
//             document.getElementById('txtuom').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtuom').style.backgroundColor="#FFFFFF";
//         }
//         
//          if(ds.Tables[0].Rows[0].PagePremium!=ds.Tables[3].Rows[0].PagePremium)
//         {
//             document.getElementById('txtpagepremium').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpagepremium').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].PositionPremium!=ds.Tables[3].Rows[0].PositionPremium)
//         {
//             document.getElementById('txtpositionpremium').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpositionpremium').style.backgroundColor="#FFFFFF";
//         }
//           if(ds.Tables[0].Rows[0].Ad_size_column!=ds.Tables[3].Rows[0].Ad_size_column)
//         {
//             document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFFFF";
//         }
//         
//          if(ds.Tables[0].Rows[0].Ad_size_height!=ds.Tables[3].Rows[0].Ad_size_height)
//         {
//             document.getElementById('txtheight').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtheight').style.backgroundColor="#FFFFFF";
//         }
//         
//          if(ds.Tables[0].Rows[0].Ad_size_width!=ds.Tables[3].Rows[0].Ad_size_width)
//         {
//             document.getElementById('txtwidth').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
//         }
//         
//           if(ds.Tables[0].Rows[0].Currency!=ds.Tables[3].Rows[0].Currency)
//         {
//             document.getElementById('txtcurrencytype').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcurrencytype').style.backgroundColor="#FFFFFF";
//         }  
//         
//         if(ds.Tables[0].Rows[0].Insertion_date!=ds.Tables[3].Rows[0].Insertion_date)
//         {
//             document.getElementById('txtpublishdate').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpublishdate').style.backgroundColor="#FFFFFF";
//         }  
//         
//         if(ds.Tables[0].Rows[0].No_of_insertion!=ds.Tables[3].Rows[0].No_of_insertion)
//         {
//             document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFFFF";
//         }  
//         
//         
//          if(ds.Tables[0].Rows[0].Contract_name!=ds.Tables[3].Rows[0].Contract_name)
//         {
//             document.getElementById('txtcontractname').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcontractname').style.backgroundColor="#FFFFFF";
//         }  
//         
//          if(ds.Tables[0].Rows[0].Paid_ins!=ds.Tables[3].Rows[0].Paid_ins)
//         {
//             document.getElementById('txtpaid').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpaid').style.backgroundColor="#FFFFFF";
//         } 
//          if(ds.Tables[0].Rows[0].Card_amount!=ds.Tables[3].Rows[0].Card_amount)
//         {
//             document.getElementById('txtcardamount').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcardamount').style.backgroundColor="#FFFFFF";
//         } 
//         
//           if(ds.Tables[0].Rows[0].Agrred_rate!=ds.Tables[3].Rows[0].Agrred_rate)
//         {
//             document.getElementById('txtagreedrate').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";
//         } 
//         
//           if(ds.Tables[0].Rows[0].Special_discount!=ds.Tables[3].Rows[0].Special_discount)
//         {
//             document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFFFF";
//         } 
//         
//           if(ds.Tables[0].Rows[0].Discount!=ds.Tables[3].Rows[0].Discount)
//         {
//             document.getElementById('txtdiscount').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
//         } 
//       }
//      else
//      {
//        if(ds.Tables[2].Rows.length>0)
//        {
//         if(ds.Tables[0].Rows[0].AgencyName!=ds.Tables[2].Rows[0].AgencyName)
//        {
//         document.getElementById('txtagency').style.backgroundColor="#FFFF80";
//        }
//        else
//        {
//         document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
//        }
//        if(ds.Tables[0].Rows[0].AgencySubCode!=ds.Tables[2].Rows[0].AgencySubCode)
//         {
//             document.getElementById('txtagencysubcode').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtagencysubcode').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].Client!=ds.Tables[2].Rows[0].Client)
//         {
//             document.getElementById('txtclient').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtclient').style.backgroundColor="#FFFFFF";
//         }
//         
//           if(ds.Tables[0].Rows[0].Agency_type!=ds.Tables[2].Rows[0].Agency_type)
//         {
//             document.getElementById('txtagencytype').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtagencytype').style.backgroundColor="#FFFFFF";
//         }
//         
//             if(ds.Tables[0].Rows[0].Agency_address!=ds.Tables[2].Rows[0].Agency_address)
//         {
//             document.getElementById('txtadress2').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtadress2').style.backgroundColor="#FFFFFF";
//         }
//         
//            if(ds.Tables[0].Rows[0].Client_address!=ds.Tables[2].Rows[0].Client_address)
//         {
//             document.getElementById('txtaddress1').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtaddress1').style.backgroundColor="#FFFFFF";
//         }
//         
//               if(ds.Tables[0].Rows[0].Agency_status!=ds.Tables[2].Rows[0].Agency_status)
//         {
//             document.getElementById('txtstatus').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtstatus').style.backgroundColor="#FFFFFF";
//         }
//         
//               if(ds.Tables[0].Rows[0].PayMode!=ds.Tables[2].Rows[0].PayMode)
//         {
//             document.getElementById('txtpaymode').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpaymode').style.backgroundColor="#FFFFFF";
//         }
//         
//                  if(ds.Tables[0].Rows[0].Agency_credit!=ds.Tables[2].Rows[0].Agency_credit)
//         {
//             document.getElementById('txtcreditperiod').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcreditperiod').style.backgroundColor="#FFFFFF";
//         }
//         
//                     if(ds.Tables[0].Rows[0].RO_No!=ds.Tables[2].Rows[0].RO_No)
//         {
//             document.getElementById('txtrono').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtrono').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].RO_Date!=ds.Tables[2].Rows[0].RO_Date)
//         {
//             document.getElementById('txtrodate').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtrodate').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].ro_status!=ds.Tables[2].Rows[0].ro_status)
//         {
//             document.getElementById('txtrostatus').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtrostatus').style.backgroundColor="#FFFFFF";
//         }
//         
//            if(ds.Tables[0].Rows[0].Dockit_no!=ds.Tables[2].Rows[0].Dockit_no)
//         {
//             document.getElementById('txtdockitno').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtdockitno').style.backgroundColor="#FFFFFF";
//         }
//         
//              if(ds.Tables[0].Rows[0].Key_no!=ds.Tables[2].Rows[0].Key_no)
//         {
//             document.getElementById('txtkeyno').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtkeyno').style.backgroundColor="#FFFFFF";
//         }
//         
//                  if(ds.Tables[0].Rows[0].execname!=ds.Tables[2].Rows[0].execname)
//         {
//             document.getElementById('txtexecutivename').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtexecutivename').style.backgroundColor="#FFFFFF";
//         }
//         
//        if(ds.Tables[0].Rows[0].Executive_zone!=ds.Tables[2].Rows[0].Executive_zone)
//         {
//             document.getElementById('txtexecutivezone').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtexecutivezone').style.backgroundColor="#FFFFFF";
//         }
//        
//        if(ds.Tables[0].Rows[0].Agency_out!=ds.Tables[2].Rows[0].Agency_out)
//         {
//             document.getElementById('txtoutstanding').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtoutstanding').style.backgroundColor="#FFFFFF";
//         }
//         
//           if(ds.Tables[0].Rows[0].categoryname!=ds.Tables[2].Rows[0].categoryname)
//         {
//             document.getElementById('txtadcategory').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtadcategory').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].subcategoryname!=ds.Tables[2].Rows[0].subcategoryname)
//         {
//             document.getElementById('txtadsubcat').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtadsubcat').style.backgroundColor="#FFFFFF";
//         }
//         
//           
//         if(ds.Tables[0].Rows[0].Brand!=ds.Tables[2].Rows[0].Brand)
//         {
//             document.getElementById('txtbrand').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtbrand').style.backgroundColor="#FFFFFF";
//         }
//         
//           if(ds.Tables[0].Rows[0].product!=ds.Tables[2].Rows[0].product)
//         {
//             document.getElementById('txtproduct').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtproduct').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].UOM!=ds.Tables[2].Rows[0].UOM)
//         {
//             document.getElementById('txtuom').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtuom').style.backgroundColor="#FFFFFF";
//         }
//         
//          if(ds.Tables[0].Rows[0].PagePremium!=ds.Tables[2].Rows[0].PagePremium)
//         {
//             document.getElementById('txtpagepremium').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpagepremium').style.backgroundColor="#FFFFFF";
//         }
//         
//         if(ds.Tables[0].Rows[0].PositionPremium!=ds.Tables[2].Rows[0].PositionPremium)
//         {
//             document.getElementById('txtpositionpremium').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpositionpremium').style.backgroundColor="#FFFFFF";
//         }
//           if(ds.Tables[0].Rows[0].Ad_size_column!=ds.Tables[2].Rows[0].Ad_size_column)
//         {
//             document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFFFF";
//         }
//         
//          if(ds.Tables[0].Rows[0].Ad_size_height!=ds.Tables[2].Rows[0].Ad_size_height)
//         {
//             document.getElementById('txtheight').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtheight').style.backgroundColor="#FFFFFF";
//         }
//         
//          if(ds.Tables[0].Rows[0].Ad_size_width!=ds.Tables[2].Rows[0].Ad_size_width)
//         {
//             document.getElementById('txtwidth').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
//         }
//         
//           if(ds.Tables[0].Rows[0].Currency!=ds.Tables[2].Rows[0].Currency)
//         {
//             document.getElementById('txtcurrencytype').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcurrencytype').style.backgroundColor="#FFFFFF";
//         }  
//         
//         if(ds.Tables[0].Rows[0].Insertion_date!=ds.Tables[2].Rows[0].Insertion_date)
//         {
//             document.getElementById('txtpublishdate').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpublishdate').style.backgroundColor="#FFFFFF";
//         }  
//         
//         if(ds.Tables[0].Rows[0].No_of_insertion!=ds.Tables[2].Rows[0].No_of_insertion)
//         {
//             document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFFFF";
//         }  
//         
//         
//          if(ds.Tables[0].Rows[0].Contract_name!=ds.Tables[2].Rows[0].Contract_name)
//         {
//             document.getElementById('txtcontractname').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcontractname').style.backgroundColor="#FFFFFF";
//         }  
//         
//          if(ds.Tables[0].Rows[0].Paid_ins!=ds.Tables[2].Rows[0].Paid_ins)
//         {
//             document.getElementById('txtpaid').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtpaid').style.backgroundColor="#FFFFFF";
//         } 
//          if(ds.Tables[0].Rows[0].Card_amount!=ds.Tables[2].Rows[0].Card_amount)
//         {
//             document.getElementById('txtcardamount').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcardamount').style.backgroundColor="#FFFFFF";
//         } 
//         
//           if(ds.Tables[0].Rows[0].Agrred_rate!=ds.Tables[2].Rows[0].Agrred_rate)
//         {
//             document.getElementById('txtagreedrate').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";
//         } 
//         
//           if(ds.Tables[0].Rows[0].Special_discount!=ds.Tables[2].Rows[0].Special_discount)
//         {
//             document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFFFF";
//         } 
//         
//           if(ds.Tables[0].Rows[0].Discount!=ds.Tables[2].Rows[0].Discount)
//         {
//             document.getElementById('txtdiscount').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
//         } 
//         }
//      }
//  }
  
 }
  } 
  //  alert(ds);
}
function selectall()
 {
 //alert('ok');
      if(document.getElementById('Chkselectall').checked==true )
            {
            document.getElementById('chkagencysubcode').checked=true;
            document.getElementById('chkclient').checked=true;
            document.getElementById('CheckBox1').checked=true;
            document.getElementById('chkaddress').checked=true;
            document.getElementById('chkadre').checked=true;
            document.getElementById('chkstatus').checked=true;
            document.getElementById('chkpaymode').checked=true;
            document.getElementById('chkcredit').checked=true;
            document.getElementById('chkrono').checked=true;
            document.getElementById('chkrodate').checked=true;
            document.getElementById('chkkeyno').checked=true;
            document.getElementById('chkexecutivename').checked=true;
            document.getElementById('CheckBox2').checked=true;
            document.getElementById('chkoutstanding').checked=true;
            document.getElementById('chkadcategory').checked=true;
            document.getElementById('chkadsubcat').checked=true;
            document.getElementById('chkbrand').checked=true;
            document.getElementById('chkproduct').checked=true;
            document.getElementById('chkuom').checked=true;
            document.getElementById('chkpagepremium').checked=true;
            document.getElementById('CheckBox3').checked=true;
            document.getElementById('chknoofcolumns').checked=true;
            document.getElementById('chkheight').checked=true;
            document.getElementById('chkwidth').checked=true;
            document.getElementById('chkcurrency').checked=true;
            document.getElementById('chkpublishdate').checked=true;
            document.getElementById('chknoofinsertion').checked=true;
            document.getElementById('CheckBox4').checked=true;
            document.getElementById('chkschemetype').checked=true;
            document.getElementById('chkpaid').checked=true;
            document.getElementById('chkagreedrate').checked=true;
            document.getElementById('chkspecialdiscount').checked=true;
            document.getElementById('chkdiscount').checked=true;
            document.getElementById('chkrostatus').checked=true;
            document.getElementById('chkdockitno').checked=true;
            document.getElementById('chkcardamount').checked=true;
            document.getElementById('Chkagencytype').checked=true;
            }
            else
            {
            document.getElementById('Chkagencytype').checked=false;
            document.getElementById('chkcardamount').checked=false;
            document.getElementById('chkdockitno').checked=false;
            document.getElementById('chkrostatus').checked=false;
            document.getElementById('chkagencysubcode').checked=false;
            document.getElementById('chkclient').checked=false;
            document.getElementById('CheckBox1').checked=false;
            document.getElementById('chkaddress').checked=false;
            document.getElementById('chkadre').checked=false;
            document.getElementById('chkstatus').checked=false;
            document.getElementById('chkpaymode').checked=false;
            document.getElementById('chkcredit').checked=false;
            document.getElementById('chkrono').checked=false;
            document.getElementById('chkrodate').checked=false;
            document.getElementById('chkkeyno').checked=false;
            document.getElementById('chkexecutivename').checked=false;
            document.getElementById('CheckBox2').checked=false;
            document.getElementById('chkoutstanding').checked=false;
            document.getElementById('chkadcategory').checked=false;
            document.getElementById('chkadsubcat').checked=false;
            document.getElementById('chkbrand').checked=false;
            document.getElementById('chkproduct').checked=false;
            document.getElementById('chkuom').checked=false;
            document.getElementById('chkpagepremium').checked=false;
            document.getElementById('CheckBox3').checked=false;
            document.getElementById('chknoofcolumns').checked=false;
            document.getElementById('chkheight').checked=false;
            document.getElementById('chkwidth').checked=false;
            document.getElementById('chkcurrency').checked=false;
            document.getElementById('chkpublishdate').checked=false;
            document.getElementById('chknoofinsertion').checked=false;
            document.getElementById('CheckBox4').checked=false;
            document.getElementById('chkschemetype').checked=false;
            document.getElementById('chkpaid').checked=false;
            document.getElementById('chkagreedrate').checked=false;
            document.getElementById('chkspecialdiscount').checked=false;
            document.getElementById('chkdiscount').checked=false;
           }
 }
 function changselect()
{
 if(document.getElementById('chkagencysubcode').checked==true && document.getElementById('chkclient').checked==true && document.getElementById('CheckBox1').checked==true && document.getElementById('chkaddress').checked==true &&  document.getElementById('chkadre').checked==true && document.getElementById('chkstatus').checked==true && document.getElementById('chkpaymode').checked==true &&  document.getElementById('chkcredit').checked==true && document.getElementById('chkrono').checked==true && document.getElementById('chkrodate').checked==true && document.getElementById('chkkeyno').checked==true && document.getElementById('chkexecutivename').checked==true &&  document.getElementById('CheckBox2').checked==true && document.getElementById('chkoutstanding').checked==true &&  document.getElementById('chkadcategory').checked==true && document.getElementById('chkadsubcat').checked==true && document.getElementById('chkbrand').checked==true && document.getElementById('chkproduct').checked==true && document.getElementById('chkuom').checked==true && document.getElementById('chkpagepremium').checked==true && document.getElementById('CheckBox3').checked==true && document.getElementById('chknoofcolumns').checked==true && document.getElementById('chkheight').checked==true && document.getElementById('chkwidth').checked==true &&  document.getElementById('chkcurrency').checked==true && document.getElementById('chkpublishdate').checked==true && document.getElementById('chknoofinsertion').checked==true && document.getElementById('CheckBox4').checked==true && document.getElementById('chkschemetype').checked==true && document.getElementById('chkpaid').checked==true && document.getElementById('chkagreedrate').checked==true &&  document.getElementById('chkspecialdiscount').checked==true && document.getElementById('chkdiscount').checked==true && document.getElementById('chkrostatus').checked==true && document.getElementById('chkdockitno').checked==true && document.getElementById('chkcardamount').checked==true && document.getElementById('Chkagencytype').checked==true)
  {
 document.getElementById('Chkselectall').checked=true;
  }
 else
  {
 document.getElementById('Chkselectall').checked=false;
  }
}
function executeclick()
{


var todate=document.getElementById('txtvalidityfrom').value;
var fromdate=document.getElementById('txttilldate').value;

   
 if(document.getElementById('drpadtype').value=="0") 
              {
              alert("Please Select Ad Type");
              document.getElementById('drpadtype').focus();
              return false;
              }            
if(todate=="" || fromdate=="")
{
    alert('Please Fill Date');
    return false;
}
else
{
var dateformat = document.getElementById('hiddendateformat').value;
	document.getElementById('divgrid1').style.display='block';
	//document.getElementById('DataGrid1').style.Visibility=true;	
		if(dateformat=="dd/mm/yyyy")
							{
								var txtfrom=document.getElementById('txtvalidityfrom').value;
								var txtto=document.getElementById('txttilldate').value;
								
								var txtfrom1=txtfrom.split("/");
								var dd=txtfrom1[0];
								var mm=txtfrom1[1];
								var yy=txtfrom1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto1=txtto.split("/");
								var dd1=txtto1[0];
								var mm1=txtto1[1];
								var yy1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtvalidityfrom').value;
								todate=document.getElementById('txttilldate').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtvalidityfrom').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txttilldate').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtvalidityfrom').value;
								todate=document.getElementById('txttilldate').value;
							}
						
		if(todate != "" || todate != null || todate != "undefined")
		{
			tdate = new Date(todate);
			fdate= new Date(fromdate);
			if(tdate<fdate)
			{
			alert("Valid To date must be greater than Valid From date");
			document.getElementById('txttilldate').disabled=false;
			document.getElementById('txttilldate').focus();
			return false;
			}

		}


}
   
}

function call_back(response)
{
document.getElementById('divgrid1').style.display='block';
var ds=response.value;
var booking_date = ds.Tables[0].Rows[0].date_time;

}

function selectclick(ab)
{
var id=ab;
var j;
var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;

//	alert(document.getElementById(str));
     if(id==str)
        {
	if(document.getElementById(id).checked==true)
	{
	k=k+1;
	//alert(document.getElementById(str).value);
	code10=document.getElementById(str).value;
	chk123=document.getElementById(id);
	}
	}
	}
	if(k==1)
	{
////	if(document.getElementById('hiddenshow').value=="1")
////	{
////	document.getElementById('btndelete').disabled=false;
////	}
var bookingid = document.getElementById(id).value;
var clientid = document.getElementById(id).value1;
//if(clientid==" ")
//{
//clientid="";
//}
	unconfirmad.selected(bookingid,clientid,call_grid_sel);
////	
	}
	if(k==0)
	{
	//chk123.checked=false;
	//document.getElementById('txteditionname').value="";
    ////document.getElementById('txtdate').value="";
    ////document.getElementById('txtaddate').value="";
	return false;
	}
	document.getElementById(ab).checked=true;
	
	//return false;

}

function call_grid_sel(res)
{
    ds = res.value;
    document.getElementById('txtdatetime').value = ds.Tables[0].Rows[0].date_time;
    document.getElementById('txtdatetime').disabled=false;
    document.getElementById('txtbranch').value = ds.Tables[0].Rows[0].branch;
    document.getElementById('txtbranch').disabled=false;
    document.getElementById('txtbookedby').value = ds.Tables[0].Rows[0].booked_by
    document.getElementById('txtbookedby').disabled=false;
    document.getElementById('txtciobookid').value = ds.Tables[0].Rows[0].cio_booking_id;
    document.getElementById('txtciobookid').disabled=false;
    //document.getElementById('txtprevbook').value = ds.Tables[0].Rows[0].prev_booking;
    //document.getElementById('txtprevbook').disabled=false;
    document.getElementById('txtagency').value = ds.Tables[0].Rows[0].Agency_code;
    document.getElementById('txtagency').disabled=false;
    document.getElementById('txtclient').value = ds.Tables[0].Rows[0].Client_code;
    document.getElementById('txtclient').disabled=false;
    document.getElementById('txtagencyaddress').value = ds.Tables[0].Rows[0].Agency_address;
    document.getElementById('txtagencyaddress').disabled=false;
    document.getElementById('txtclientadd').value = ds.Tables[0].Rows[0].Client_address;
    document.getElementById('txtclientadd').disabled=false;
    document.getElementById('drpagscode').value = ds.Tables[0].Rows[0].Agency_sub_code
    document.getElementById('drpagscode').disabled=false;
    document.getElementById('txtagencytype').value = ds.Tables[0].Rows[0].Agency_type;
    document.getElementById('txtagencytype').disabled=false;
    document.getElementById('txtagencystatus').value = ds.Tables[0].Rows[0].Agency_status;
    document.getElementById('txtagencystatus').disabled=false;
    document.getElementById('txtagencypaymode').value = ds.Tables[0].Rows[0].Agency_pay;
    document.getElementById('txtagencypaymode').disabled=false;
    document.getElementById('txtcreditperiod').value = ds.Tables[0].Rows[0].Agency_credit;
    document.getElementById('txtcreditperiod').disabled=false;
    document.getElementById('txtrono').value = ds.Tables[0].Rows[0].RO_No;
    document.getElementById('txtrono').disabled=false;
    document.getElementById('txtrodate').value = ds.Tables[0].Rows[0].RO_Date;
    document.getElementById('txtrodate').disabled=false;
    document.getElementById('drprostatus').value = ds.Tables[0].Rows[0].ro_status;
    document.getElementById('drprostatus').disabled=false;
    document.getElementById('txtdockitno1').value = ds.Tables[0].Rows[0].Dockit_no;
    document.getElementById('txtdockitno1').disabled=false;
    document.getElementById('txtkeyno').value = ds.Tables[0].Rows[0].Key_no;
    document.getElementById('txtkeyno').disabled=false;
    document.getElementById('txtexecname').value = ds.Tables[0].Rows[0].Executive_code;
    document.getElementById('txtexecname').disabled=false;
    document.getElementById('txtexeczone').value = ds.Tables[0].Rows[0].Executive_zone;
    document.getElementById('txtexeczone').disabled=false;
    document.getElementById('txtadcat').value = ds.Tables[0].Rows[0].Ad_cat_code;
    document.getElementById('txtadcat').disabled=false;
    document.getElementById('txtpackage').value = ds.Tables[0].Rows[0].Package_cod;
    document.getElementById('txtpackage').disabled=false;
    document.getElementById('txtadsubcat1').value = ds.Tables[0].Rows[0].Ad_sub_cat_code;
    document.getElementById('txtadsubcat').disabled=false;
    document.getElementById('txtpageprem').value = ds.Tables[0].Rows[0].Page_prem;
    document.getElementById('txtpageprem').disabled=false;
    document.getElementById('txtpubdate').value = ds.Tables[0].Rows[0].Insertion_date;
    document.getElementById('txtpubdate').disabled=false;
    document.getElementById('txtbrand').value = ds.Tables[0].Rows[0].Brand_code;
    document.getElementById('txtbrand').disabled=false;
    document.getElementById('txtpos').value = ds.Tables[0].Rows[0].Page_position_cod;
    document.getElementById('txtpos').disabled=false;
    document.getElementById('txtnoofins').value = ds.Tables[0].Rows[0].No_of_insertion;
    document.getElementById('txtnoofins').disabled=false
    document.getElementById('txtproduct').value = ds.Tables[0].Rows[0].Product_code;
    document.getElementById('txtproduct').disabled=false;
    document.getElementById('txtadheight').value = ds.Tables[0].Rows[0].Ad_size_height;
    document.getElementById('txtadheight').disabled=false;
    document.getElementById('txtcontractname').value = ds.Tables[0].Rows[0].Contract_name;
    document.getElementById('txtcontractname').disabled=false;
    document.getElementById('txtuom').value = ds.Tables[0].Rows[0].Uom_code;
    document.getElementById('txtuom').disabled=false;
    document.getElementById('txtwidth').value = ds.Tables[0].Rows[0].Ad_size_width;
    document.getElementById('txtwidth').disabled=false;
    document.getElementById('txtschemetype').value = ds.Tables[0].Rows[0].Scheme_type_code;
    document.getElementById('txtscheme').disabled=false;
    document.getElementById('txtcol').value = ds.Tables[0].Rows[0].Ad_size_column;
    document.getElementById('txtcol').disabled=false;
    document.getElementById('txtarea').value = ds.Tables[0].Rows[0].Total_area;
    document.getElementById('txtarea').disabled=false;
    document.getElementById('txtcardamt').value = ds.Tables[0].Rows[0].Card_amount;
    document.getElementById('txtcardamt').disabled=false;
    document.getElementById('txtagreedamount').value = ds.Tables[0].Rows[0].Agreed_amount;
    document.getElementById('txtagreedamount').disabled=false;
    document.getElementById('txtspecialamount').value = ds.Tables[0].Rows[0].Special_discount;
    document.getElementById('txtspecialamount').disabled=false;
    document.getElementById('txtboxno').value = ds.Tables[0].Rows[0].Box_no;
    document.getElementById('txtboxno').disabled=false;
    //document.getElementById('txtcol').value = ds.Tables[0].Rows[0].Ad_size_column;
}

var data;
function fetch(ab)
{
var id=ab.srcElement.id;
data = document.getElementById(id).value;

}

function changecolor(ab)
{
    var id=ab.srcElement.id;
    var data1 = document.getElementById(id).value;
    if(data1!=data)
        {
            document.getElementById(id).style.backgroundColor="Yellow";
        }
    else
        {
            document.getElementById(id).style.backgroundColor="";
        }
}

var count = 0;
//var count=0;
function display()
{
if(count==0)
{
   document.getElementById('divgrid1').style.display='none';
   count = count + 1;
}
else
{
    document.getElementById('divgrid1').style.display='block';
}
}
function openPrev()
{
    window.open("OPENAUDITPREVIEW.aspx?cioid="+document.getElementById('hiddenbookingid').value+"&uomdesc="+document.getElementById('hiddenuomdesc').value,'','width=300,height=300');
   
}

function cleardata()
{
        document.getElementById('txttilldate').value="";
		document.getElementById('txtvalidityfrom').value="";
		document.getElementById('drpconfirm').value="1";
		//document.getElementById('drpadtype').value="0";
		if(document.getElementById('drprevenu').disabled==false)
		    document.getElementById('drprevenu').value="0";
		//document.getElementById('drpbranch').options.length="0";
		//document.getElementById('drpaudit').value="0";
//		if(document.getElementById('btnbookingaudit')!=null)
//		    document.getElementById('btnbookingaudit').style.visibility="hidden";
//		if(document.getElementById("DataGrid1")!=null)
//		    document.getElementById("DataGrid1").outerHTML="";
    return false;
		
}
function bookingaudit2()
{
    if(document.getElementById("DataGrid1")==null)
    return false;
    str=document.getElementById("DataGrid1");
    var booking_id="";
    var chk_booking_id="";
    var chkid_f="";
    var flag=false;
        for(var i=0;i<document.getElementById("DataGrid1").rows.length-1;i++)
            {
                var chkid="chk" + i;
                booking_id="";
                if(document.getElementById(chkid).checked==true)
                    {
                        booking_id = document.getElementById(chkid).value;
                        unconfirmad.updateStatus2(booking_id);
                        chk_booking_id = booking_id;
                        var agencyname = document.getElementById('drprevenu').value.substring(document.getElementById('drprevenu').value.lastIndexOf("(") + 1, document.getElementById('drprevenu').value.length - 1);
                        unconfirmad.AUTOtag(chk_booking_id, agencyname);
                        var resp = unconfirmad.updateStatus3(chk_booking_id);
                   
//                        if(chkid_f=="")
//                        chkid_f="'"+booking_id+"'";
//                        else
//                        chkid_f=chkid_f+","+"'"+booking_id+"'";
                        flag=true;
                    }
                    
            }
            //var resp=unconfirmad.updateStatus3(chkid_f);
            if (flag == true) {
                alert("Ad Confirm Successfully");
                refreshControl();
            }
      //return false;      
}

 function selectAll()
 {
    if(document.getElementById("checkall").checked==true)
    {
        for(var k=0;k<document.getElementById("DataGrid1").rows.length-1;k++)
        {
            var chkid="chk" + k;
            document.getElementById(chkid).checked=true;
        }
    }
    else
    {
        for(var k=0;k<document.getElementById("DataGrid1").rows.length-1;k++)
        {
            var chkid="chk" + k;
            document.getElementById(chkid).checked=false;
        }
    }
}

function tabvalue1(event)
{
var browser=navigator.appName;
 if(event.keyCode==113)  
    {
           
        if(document.activeElement.id=="drprevenu")
        {
            if(document.getElementById('drprevenu').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('drprevenu').value="";
            return false;
            }
            document.getElementById("div1").style.display = "block";
            aTag = eval(document.getElementById('drprevenu'))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = 0;


            var scrolltop = 0;

            document.getElementById('div1').style.top = document.getElementById("drprevenu").offsetTop + toppos + "px";
            document.getElementById('div1').style.left = document.getElementById("drprevenu").offsetLeft + leftpos + "px";
//            if(browser != "Microsoft Internet Explorer")
//            {
//                  document.getElementById('div1').style.top= 120;
//                  document.getElementById('div1').style.left= 390;
////                document.getElementById('div1').style.top=parseInt(document.getElementById('drprevenu').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-6) + "px";
////                document.getElementById('div1').style.left=parseInt(document.getElementById('drprevenu').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
//            }
//            else
//            {
//                  document.getElementById('div1').style.top= 110;
//                  document.getElementById('div1').style.left= 390;
////                document.getElementById('div1').style.top=parseInt(document.getElementById('drprevenu').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
////                document.getElementById('div1').style.left=parseInt(document.getElementById('drprevenu').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
//            }
            unconfirmad.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('drprevenu').value.toUpperCase(), "N", bindagencyname_callback);
        
        }
}
else if(event.keyCode==27)
    {
    if(document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('drprevenu').focus();
        }
        }

else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
    {
       
      if(document.activeElement.id=="lstagency")
        {
            if(document.getElementById('lstagency').value=="0" )
            {
                alert("Please select the agency sub code");
                return false;
            }
            document.getElementById("div1").style.display="none";
            var datetime="";
            var page=document.getElementById('lstagency').value;
            //document.getElementById('hiddenagency').value=page;
        
            agencycodeglo=page;
        
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                }
            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
                httpRequest.send('');
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) 
                    {
                        id=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
                xml.Send();
                id=xml.responseText;
            }
            var split=id.split("+");
            var nameagen=split[0];
            var agenadd=split[1];
        
            document.getElementById('drprevenu').value=nameagen;
           /* if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
            {
                document.getElementById('drprevenuaddress').value=agenadd;                
                document.getElementById('txtclient1').focus();
                Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
            }*/
            document.getElementById('drpconfirm').focus();
            return false;
        }
        
      else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            event.keyCode=13;
            return event.keyCode;
        }
        else
        {
            var idcursor;
            if(event.shiftKey==false)
            {
                event.keyCode=9;                     
                return event.keyCode;
            }    
        }
    }
    
    }
    function bindagencyname_callback(response)
{       
    ds=response.value;
    //document.getElementById('drpretainer').value="";
    var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name +'+'+ds.Tables[0].Rows[i].CITYNAME,ds.Tables[0].Rows[i].code_subcode);        
            pkgitem.options.length;       
        }
    }
    document.getElementById('drprevenu').value="";
    document.getElementById("lstagency").value="0";
    document.getElementById("lstagency").focus();
    return false;
}

function insertagency()
{
var browser=navigator.appName;
if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0")// || document.getElementById('hiddensavemod').value=="01")
    {
        alert("Please select the agency code");
        return false;
    }
        document.getElementById("div1").style.display="none";
        var datetime="";
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
        var page=document.getElementById('lstagency').value;
        //document.getElementById('hiddenagency').value=page;
        agencycodeglo=page;
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
        {          
             var xml = new ActiveXObject("Microsoft.XMLHTTP");
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
             xml.Send();
             id=xml.responseText;
        }
          if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd=split[1];
                
        document.getElementById('drprevenu').value=nameagen;
        
        /*if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
        {
              document.getElementById('drprevenuaddress').value=agenadd;
                
              document.getElementById('txtclient1').focus();
              Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
        }*/
        document.getElementById('drpconfirm').focus();
        return false;
    }
    }