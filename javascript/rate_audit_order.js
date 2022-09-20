// JScript File

var browser=navigator.appName;
function catexitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}

function catexitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}



function refreshControl()
{
document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
document.getElementById('txtretainername').style.backgroundColor="#FFFFFF";
document.getElementById('txtratecode').style.backgroundColor="#FFFFFF";
document.getElementById('txtclient').style.backgroundColor="#FFFFFF";
document.getElementById('txtadsubcat4').style.backgroundColor="#FFFFFF";
document.getElementById('txtpaymode').style.backgroundColor="#FFFFFF";
document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFFFF";
document.getElementById('txtcardrate1').style.backgroundColor="#FFFFFF";
document.getElementById('txtagreedamount').style.backgroundColor="#FFFFFF";
document.getElementById('txtarea').style.backgroundColor="#FFFFFF";
document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";
document.getElementById('txtgrossamt').style.backgroundColor="#FFFFFF";
document.getElementById('txtspacediscount').style.backgroundColor="#FFFFFF";
document.getElementById('txtcardamount1').style.backgroundColor="#FFFFFF";
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
//document.getElementById('txtpositionpre').style.backgroundColor="#FFFFFF";
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
}




function openbooking(cioid,id,length,edition,insertion)
{
refreshControl();
if(id!="undefined")
{
    document.getElementById('hiddenid').value = id;
}
var i=0;
for(i=0;i<parseInt(length);i++)
{
    //document.getElementById('cio'+i).style.color="blue";
}

document.getElementById(document.getElementById('hiddenid').value).style.color="red";
document.getElementById('hiddenbookingid').value=cioid;
var adtype=document.getElementById('drpadtype').value;


document.getElementById('btnaudit').disabled=false;
document.getElementById('btnmodify').disabled=false;

rate_audit_orderwise.execute(cioid,document.getElementById('hiddencompcode').value,adtype,document.getElementById('hiddenDateFormat').value,exec_callback);    

    //alert(cioid);
}
function exec_callback(response)
{
    var ds=response.value;
    var len=ds.Tables[0].Rows.length;
    if(len!="0")
    {
    if(document.getElementById('hiddenrefresh').value=='1')
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
             document.getElementById('txtcardamount1').style.backgroundColor="#FFFF80";
         }
         else
         {
            document.getElementById('txtcardamount1').style.backgroundColor="#FFFFFF";
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
     
     //////////////////////////////////////////////////////////////////////
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
         
     
     
     if(ds.Tables[0].Rows[0].Package_code==null)
            {
                document.getElementById('txtpackage').value="";
            }
            else
            {
                if(ds.Tables[0].Rows[0].Package_code.indexOf(",")>0)
                {
                    var s1=ds.Tables[0].Rows[0].Package_code.split(",");
                    var pkg_name="";
                    for(var k_=0;k_<s1.length;k_++)
                    {
                        var ds_pkg=rate_audit_orderwise.getPackageName(document.getElementById('hiddencompcode').value,s1[k_]);
                        if(ds_pkg.value!=null)
                        {                   
                            if(pkg_name=="")
                                pkg_name=ds_pkg.value.Tables[0].Rows[0].Package_Name;
                            else
                                pkg_name=pkg_name + "," + ds_pkg.value.Tables[0].Rows[0].Package_Name;
                        }
                    }    
                    document.getElementById('txtpackage').value=pkg_name;
                }
                else
                {
                    var ds_pkg=rate_audit_orderwise.getPackageName(document.getElementById('hiddencompcode').value,ds.Tables[0].Rows[0].Package_code);
                    if(ds_pkg.value!=null)
                    {
                        document.getElementById('txtpackage').value=ds_pkg.value.Tables[0].Rows[0].Package_Name;
                    }
                }
            }
            
            
    if(ds.Tables[0].Rows[0].Client==null)
    {
    document.getElementById('txtclient').value="";
    }
    else
    {
    document.getElementById('txtclient').value=ds.Tables[0].Rows[0].Client;
    }
    if(ds.Tables[0].Rows[0].Agreed_amount==null || ds.Tables[0].Rows[0].Agreed_amount=="0")
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
   if(ds.Tables[0].Rows[0].RETAINER1==null ||ds.Tables[0].Rows[0].RETAINER1=="0")
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
   if(ds.Tables[0].Rows[0].Page_position_cod==null)
   {
   document.getElementById('txtpageposition').value="";
   }
   else
   {
   document.getElementById('txtpageposition').value=ds.Tables[0].Rows[0].PagePremium;
   }
   if(ds.Tables[0].Rows[0].SUBCAT3==null || ds.Tables[0].Rows[0].SUBCAT3=="0")
   {
   document.getElementById('txtadsubcat2').value="";
   }
   else
   {
   document.getElementById('txtadsubcat2').value=ds.Tables[0].Rows[0].SUBCAT3;
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
    document.getElementById('txtcardrate1').value="";
    }
    else
    {
    document.getElementById('txtcardrate1').value=ds.Tables[0].Rows[0].Card_rate;
    }
   if(ds.Tables[0].Rows[0].UOM==null)
   {
   document.getElementById('txtuom').value=""
   }
   else
   {
   document.getElementById('txtuom').value=ds.Tables[0].Rows[0].UOM;
   }
   if(ds.Tables[0].Rows[0].SUBCAT4==null || ds.Tables[0].Rows[0].SUBCAT4=="null")
   {
   document.getElementById('txtadsubcat3').value="";
   }
   else
   {
   document.getElementById('txtadsubcat3').value=ds.Tables[0].Rows[0].SUBCAT4;
   }
   if(ds.Tables[0].Rows[0].SUBCAT5==null)
   {
   document.getElementById('txtadsubcat4').value="";
   }
   else
   {
   document.getElementById('txtadsubcat4').value=ds.Tables[0].Rows[0].SUBCAT5;
   }
   if(ds.Tables[0].Rows[0].PositionPremium==null)
   {
    document.getElementById('txtpositionpremium').value="";
   }
   else
   {
   document.getElementById('txtpositionpremium').value=ds.Tables[0].Rows[0].PositionPremium;
   }
   if(ds.Tables[0].Rows[0].RETAINER_COMM1==null)
   {
    document.getElementById('txtretainercommission').value="";
   }
   else
   {
   document.getElementById('txtretainercommission').value=ds.Tables[0].Rows[0].RETAINER_COMM1;
   }
   
   if(ds.Tables[0].Rows[0].RETAINER_COMM_AMT==null)
   {
    document.getElementById('txtretainercommissionamt').value="";
   }
   else
   {
   document.getElementById('txtretainercommissionamt').value=ds.Tables[0].Rows[0].RETAINER_COMM_AMT;
   }
   
   
    if(ds.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT==null)
   {
    document.getElementById('txtaddagecommamt').value="";
   }
   else
   {
   document.getElementById('txtaddagecommamt').value=ds.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT;
   }
   
   if(ds.Tables[0].Rows[0].Trade_disc==null)
   {
   document.getElementById('txtagtradediscount').value="";
   }
   else
   {
   document.getElementById('txtagtradediscount').value=ds.Tables[0].Rows[0].Trade_disc;
   }
   if(ds.Tables[0].Rows[0].height==null)
   {
   document.getElementById('txtheight').value="";
   }
   else
   {
   document.getElementById('txtheight').value=ds.Tables[0].Rows[0].height;
   }
   if(ds.Tables[0].Rows[0].width==null)
   {
   document.getElementById('txtwidth').value=""
   }
   else
   {
   document.getElementById('txtwidth').value=ds.Tables[0].Rows[0].width;
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
   document.getElementById('txtcardamount1').value="";
   }
   else
   {
   document.getElementById('txtcardamount1').value=ds.Tables[0].Rows[0].Card_amount;
   }
   if(ds.Tables[0].Rows[0].Agrred_rate==null ||ds.Tables[0].Rows[0].Agrred_rate=="0")
   {
   document.getElementById('txtagreedrate').value=""
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
   
   //document.getElementById('txtschemetype').value=ds.Tables[0].Rows[0].Contract_name;
   if(ds.Tables[0].Rows[0].Special_discount==null)
   {
   document.getElementById('txtspecialdiscount').value="";
   }
   else
   {
   document.getElementById('txtspecialdiscount').value=ds.Tables[0].Rows[0].Special_discount;
   }
   
   
   
   
     if(ds.Tables[0].Rows[0].Discount==null || ds.Tables[0].Rows[0].Discount=="")
            {
                document.getElementById('txtdiscountamt').value="";
            }
            else
            {
                if(ds.Tables[0].Rows[0].Discount!="0")
                    document.getElementById('txtdiscountamt').value=parseFloat(document.getElementById('txtcardamount1').value)-parseFloat(document.getElementById('txtagreedamount').value);//ds.Tables[0].Rows[0].Discount;
            }
   
   
   
  if(ds.Tables[0].Rows[0].Discount_per==null)
  {
   document.getElementById('txtdiscount').value="";
  }
  else
  {
  document.getElementById('txtdiscount').value=ds.Tables[0].Rows[0].Discount_per;
  }
  
  if(ds.Tables[0].Rows[0].Ad_type_code==null)
  {
   document.getElementById('hiddenadtype').value="";
  }
  else
  {
  document.getElementById('hiddenadtype').value=ds.Tables[0].Rows[0].Ad_type_code;
  }
  
  
  
  
  if(ds.Tables[0].Rows[0].Bullet_Desc==null)
               document.getElementById('txt_eyecater').value="";
            else
                document.getElementById('txt_eyecater').value=ds.Tables[0].Rows[0].Bullet_Desc;
            
            /////////////
            
           if(ds.Tables[0].Rows[0].Bullet_premium==null)
           document.getElementById('txt_eyecaterprem').value="";
            else
                document.getElementById('txt_eyecaterprem').value=ds.Tables[0].Rows[0].Bullet_premium;
                
                
                
                 if(ds.Tables[0].Rows[0].remarks==null)
            {
                document.getElementById('txtremarks').value=""
            }
            else
            {
                document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
            }
  ////////////////////////////////////////////
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
//             document.getElementById('txtcardamount1').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcardamount1').style.backgroundColor="#FFFFFF";
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
//             document.getElementById('txtcardamount1').style.backgroundColor="#FFFF80";
//         }
//         else
//         {
//            document.getElementById('txtcardamount1').style.backgroundColor="#FFFFFF";
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
//      }
//  }
  
 }
   
  //  alert(ds);
}




	function SelectHiclass(grdid,obj,objlist)
			{ 		
			
			
				if(document.getElementById("DataGrid2_ctl01_CheckBox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid2_ctl02_CheckBox1";
				for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				
				
				
				   
				if(objlist=="Checkbox4")
				{		 
				
				
				if(document.getElementById(str1).disabled==false)
				{
			document.getElementById(str1).checked=true;
			}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				 if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_CheckBox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				//return false;
				
				
				}
				//return false;
				}
				else
				{ 
				var j1;
				var j;
				var str1="DataGrid2_ctl02_CheckBox1";
				for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				
				
				   // document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].checked=true;
				if(objlist=="Checkbox4")
				{		 
				
				
			document.getElementById(str1).checked=false;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_CheckBox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}  
                           
function SelectHi(grdid,obj,objlist)
			{ 					
			
				if(document.getElementById("DataGrid1_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_CheckBox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				   // document.getElementById("DataGrid1").rows[j].cells[16].childNodes[0].checked=true;
				if(objlist=="Checkbox4")
				{		 
				
				
			document.getElementById(str1).checked=true;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				 if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				//return false;
				
				
				}
				//return false;
				}
				else
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_CheckBox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				   // document.getElementById("DataGrid1").rows[j].cells[16].childNodes[0].checked=true;
				if(objlist=="Checkbox4")
				{		 
				
				
			document.getElementById(str1).checked=false;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}                                                               

///////////////
function  checkboxid()
{
var j1=1;
var i;
				var j;
				
				
				var str1="DataGrid1_ctl02_CheckBox1";




var hiddenserverip=document.getElementById('hiddenserverip').value

var userid=document.getElementById('hiddenuserid').value


                 for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)				
				 {                  
				 
				
				if(document.getElementById(str1)!="null" && document.getElementById(str1)!=null)
				{
				
				if(document.getElementById(str1).checked==true )
				{

				    if (browser == "Microsoft Internet Explorer") {

				        var ciobookid = document.getElementById("DataGrid1").rows[j].cells[2].innerText;
				        var insertion = document.getElementById("DataGrid1").rows[j].cells[7].innerText;
				        var edition = document.getElementById("DataGrid1").rows[j].cells[4].innerText;
				    }

				    else {
				        var ciobookid = document.getElementById("DataGrid1").rows[j].cells[2].textContent;
				        var insertion = document.getElementById("DataGrid1").rows[j].cells[7].textContent;
				        var edition = document.getElementById("DataGrid1").rows[j].cells[4].textContent;
				    }
			var from_date= document.getElementById('txtvalidityfrom').value;
			var date_format=document.getElementById('hiddenDateFormat').value;
			j1=2;
			rate_audit_orderwise.updatestatus(ciobookid,insertion,edition,from_date,date_format,hiddenserverip,userid);
			
			
				}
					 
				}
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
				 } 				                 
				
				 }
				 if(j1==2)
				 {
				 alert('Rate has been Successfully Audit');
				 }
				 
				 if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for Audit');
				 }


}


function  openpage()
{

document.getElementById('hiddenadcategory').text=document.getElementById('drpadtype').value;



            if(document.getElementById('hiddenadcategory').text=="CL0")
            {
            
                 win=window.open('Classified_Booking.aspx?cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value +'&rateauditflag=rateaudit','','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');

            //window.open('Classified_Booking.aspx');
            }
else
            
            {
            // window.open('Booking_master.aspx');
             win=window.open('Booking_master.aspx?cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value +'&rateauditflag=rateaudit','','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');

            
            }
}



function checklenthnew()
{
if(document.getElementById('hidden1').value=="0")
{
//document.getElementById('divgrid1').display="none";
alert('Seaching criteria does not produce any result');
return false;
}


}

function checklenth()
{


  
               if(document.getElementById('drpadtype').value=="0")
             {
            
                alert('Please Enter  Adtype');
               document.getElementById('drpadtype').focus();
               return false;
            
              }
              
//              
//                     if(document.getElementById('drpbranch').value=="0")
//             {
//            
//                alert('Please Enter  Branch');
//                return false;
//            
//              }
              
              if(document.getElementById('txtvalidityfrom').value=="")
             {
            
                alert('Please Enter  From Date');
                  document.getElementById('txtvalidityfrom').focus();
                return false;
            
              }
               if(document.getElementById('txttilldate').value=="")
             {
            
                alert('Please Enter  Dateto');
                document.getElementById('txttilldate').focus(); 
                return false;
            
              }
              
                   if(document.getElementById('drpstatus').value=="0")
             {
            
                alert('Please Enter Status Type');
                document.getElementById('drpstatus').focus(); 
                return false;
            
              }
           
             
            
            

 var edition=document.getElementById('dpedition').value; 
 
 document.getElementById('hiddenedition').value=edition;
 
 
 
  var supplement=document.getElementById('dpsupplement').value; 
 
 document.getElementById('hiddensupplement').value=supplement;
 
 
 var rate_audit=document.getElementById('hiddenrtaudit_audit').value;
 if(rate_audit=="n")
 {
 alert('Rate Audit is not Required so you are not allowed to view any booking  here')
 return false;
 }

//if(document.getElementById('hidden1').value=="0")
//{
//alert('Seaching criteria does not produce any result');
//return false;
//}




 var  pcomp_code=document.getElementById('hiddencomcode').value;
        var  puserid= document.getElementById('hiddenuserid').value;
        var  pformname= "Rate_Audit";     
        var  pdateformat= document.getElementById('hiddenDateFormat').value;        
        var pextra1="";
        var pextra2=""; 

/*
var res;
var  ds;
        if(document.getElementById('txtvalidityfrom')!="")
        {
        var  pentry_date= document.getElementById('txtvalidityfrom').value;
        
         res=rate_audit_orderwise.fetch_date_data(pcomp_code,  pformname,  puserid,  pentry_date,  pdateformat,  pextra1,  pextra2);
          ds=res.value;
          
           if(ds.Tables[0].Rows[0].CHKDATE=="N")
        {
        alert('please choose the correct Date in From Date ');
        document.getElementById('txtvalidityfrom').value="";
        document.getElementById('txtvalidityfrom').focus();
        return false;
        }
        }

*/

}




function filledition()
{


rate_audit_orderwise.fillEdition2(document.getElementById('dppub1').value,document.getElementById('dppubcent').value,document.getElementById('hiddencompcode').value,fillCat2_callback);
    
}
function fillCat2_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("dpedition");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Edition--","0");
    
   // document.getElementById("drpadvcatcode").options.length = 1; 
    //document.getElementById("drpadvcatcode").options[0]=new Option("--Select Ad Category3--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias,ds.Tables[0].Rows[i].edition_code);
        
       pkgitem.options.length;
       
    }
   // document.getElementById("drpadsubcategory").value=glo_cat2;
  //  fillAdCat3();
    return false;
}



function suppbind()
{

var compcode=document.getElementById('hiddencomcode').value;
var edition=document.getElementById('dpedition').value;
rate_audit_orderwise.bindsupp(compcode,edition,call_suppbind);
}
function call_suppbind(response)
{
ds= response.value;
    var edition=document.getElementById('dpsupplement');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Supplement--");
    document.getElementById("dpsupplement").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
                edition.options.length;    
             }
 }         
 
       return false;

}





 
 function keySort(dropdownlist,caseSensitive) 
 {
       // check the keypressBuffer attribute is defined on the dropdownlist
         var undefined;
         if (dropdownlist.keypressBuffer == undefined)
         {
             dropdownlist.keypressBuffer = '';
         }
         // get the key that was pressed
         var key = String.fromCharCode(window.event.keyCode);
         dropdownlist.keypressBuffer += key;
         if (!caseSensitive)
          {
              // convert buffer to lowercase
              dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
          }
          // find if it is the start of any of the options
          var optionsLength = dropdownlist.options.length;
          for (var n=0; n<optionsLength; n++) 
          {
                  var optionText = dropdownlist.options[n].text;
                  if (!caseSensitive)
                  {
                       optionText = optionText.toLowerCase();
                  }
                  if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0)
                  {
                      dropdownlist.selectedIndex = n;
                      return false; 
                      // cancel the default behavior since
                                // we have selected our own value
                  }
           }
          // reset initial key to be inline with default behavior
          dropdownlist.keypressBuffer = key;
          return true; // give default behavior
}






function chkfld(a)
{


 if(event.keyCode==27)
{
    
    
   
       document.getElementById('divclient').style.display="none";     
       document.getElementById('divagency').style.display="none"; 
       document.getElementById('div4').style.display="none"; 
       document.getElementById('div5').style.display="none"; 
  }
  



if( a.keyCode=="13")
{
  
      if(document.activeElement.id=="btnNew")
          {
                if( a.keyCode=="13")
                  {
                  EnabledOnNew();
                  return false;
                  } 
       

     }
   else if(document.activeElement.id=="btnQuery")
      
       {
                   if( a.keyCode=="13")
                       {
                       EnabledonQuery();
                       return false;
                       } 
            
    
       }   
       
       //////////////////////
       
       
       else if(a.keyCode=="13" && document.activeElement.id=="lstagency")
    {
                   if(document.getElementById('lstagency').value=="" || document.getElementById('lstagency').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                           insertagency('code');
                                           return false;
                                         }
                           
                    }
     }                                     
     
     
     
     //////////////////////////
     
     
     else if(a.keyCode=="13" && document.activeElement.id=="lstclient")
    {
                   if(document.getElementById('lstclient').value=="" || document.getElementById('lstclient').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                           insertclient();
                                           return false;
                                         }
                           
                    }
     }
     ///////////////////////////
     
     
     
     else if(a.keyCode=="13" && document.activeElement.id=="lstretainer")
    {
                   if(document.getElementById('lstretainer').value=="" || document.getElementById('lstretainer').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                           fillmaingrp('code');
                                           return false;
                                         }
                           
                    }
     }
     /////////////////////////
     
     
     else if(a.keyCode=="13" && document.activeElement.id=="lstexecutive")
    {
                   if(document.getElementById('lstexecutive').value=="" || document.getElementById('lstexecutive').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                           fillexecutivegrp('code');
                                           return false;
                                         }
                           
                    }
     }
     /////////////////////////////
   else if(a.keyCode=="13" && document.activeElement.id=="drpadtype")
    {
                   if(document.getElementById('drpadtype').value=="0" || document.getElementById('drpadtype').value!="0")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('dppubcent').focus();
                                          return false;
                                         }
                           
                    }
     }




 
   else if(a.keyCode=="13" && document.activeElement.id=="dppubcent")
    {
                   if(document.getElementById('dppubcent').value=="0" || document.getElementById('dppubcent').value!="0")
                   {
                                      if( a.keyCode=="13")
                                         {
                                         document.getElementById('drpbranch').focus();
                                          return false;
                                         }
                           
                    }
     }



   else if(a.keyCode=="13" && document.activeElement.id=="drpbranch")
    {
                   if(document.getElementById('drpbranch').value=="0" || document.getElementById('drpbranch').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                       document.getElementById('dppub1').focus();
                                          return false;
                                         }
                           
                    }
     }




  else if(a.keyCode=="13" && document.activeElement.id=="dppub1")
    {
                   if(document.getElementById('dppub1').value=="0" || document.getElementById('dppub1').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                         
                                         if(document.getElementById('dpedition').value!="")
                                         {
                                           document.getElementById('dpedition').focus();
                                              return false;
                                         }
                                         else
                                         {
                                         document.getElementById('dpagencyna').focus();
                                              return false;
                                         
                                         }
                                         
                                       
                                         }
                           
                    }
     }


  
  
  
  else if(a.keyCode=="13" && document.activeElement.id=="dpedition")
    {
                   if(document.getElementById('dpedition').value=="0" || document.getElementById('dpedition').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                         if(document.getElementById('dpsupplement').value!="")
                                         {
                                          document.getElementById('dpsupplement').focus();
                                          return false;
                                          }
                                         }
                           
                    }
     }
     
     
     
       else if(a.keyCode=="13" && document.activeElement.id=="dpsupplement")
    {
                   if(document.getElementById('dpsupplement').value=="0" || document.getElementById('dpsupplement').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('dpagencyna').focus();
                                          return false;
                                         }
                           
                    }
     }




       else if(a.keyCode=="13" && document.activeElement.id=="dpagencyna")
    {
                   if(document.getElementById('dpagencyna').value=="0" ||document.getElementById('dpagencyna').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('dpagencycli').focus();
                                          return false;
                                         }
                           
                    }
     }
     
     
     
           else if(a.keyCode=="13" && document.activeElement.id=="dpagencycli")
    {
                   if(document.getElementById('dpagencycli').value=="0" || document.getElementById('dpagencycli').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                         document.getElementById('dpretainer').focus();
                                          return false;
                                         }
                           
                    }
     }
     
     
                else if(a.keyCode=="13" && document.activeElement.id=="dpretainer")
    {
                   if(document.getElementById('dpretainer').value=="0" || document.getElementById('dpretainer').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('dpexecutive').focus();
                                          return false;
                                         }
                           
                    }
     }
       
       
       
       
                    else if(a.keyCode=="13" && document.activeElement.id=="dpexecutive")
    {
                   if(document.getElementById('dpexecutive').value=="0" || document.getElementById('dpexecutive').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('txtvalidityfrom').focus();
                                          return false;
                                         }
                           
                    }
     }
             
       
       
       
       
              
       
                    else if(a.keyCode=="13" && document.activeElement.id=="txtvalidityfrom")
    {
                   if(document.getElementById('txtvalidityfrom').value=="" || document.getElementById('txtvalidityfrom').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('txttilldate').focus();
                                          return false;
                                         }
                           
                    }
     }
                 
           
           
           
           
           
                    else if(a.keyCode=="13" && document.activeElement.id=="txttilldate")
    {
                   if(document.getElementById('txttilldate').value=="" || document.getElementById('txttilldate').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('drpstatus').focus();
                                          return false;
                                         }
                           
                    }
     }
            
             
         
         
         
         
                    
                    else if(a.keyCode=="13" && document.activeElement.id=="drpstatus")
    {
                   if(document.getElementById('drpstatus').value=="" || document.getElementById('drpstatus').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                           document.getElementById('btnsubmit').focus();
                                          return false;
                                         }
                           
                    }
     }    
          
          
          
             
         
             
             
              
 /*             
else if(a.keyCode=="13" && document.activeElement.id=="txt_alias" && $('btnExecute').disabled ==false && $('btnCancel').disabled == false && $('btnExit').disabled == false)
    {
                   if($('txt_alias').value=="" || $('txt_alias').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          $('txt_misc_type_n').focus();
                                          return false;
                                         }
                     }
    }
    */
    
             
              
              
   
   /*           
 else if(a.keyCode=="13" && document.activeElement.id=="txt_misc_type_n" && $('btnExecute').disabled ==false && $('btnCancel').disabled == false && $('btnExit').disabled == false)
    {
                   if($('txt_misc_type_n').value=="" || $('txt_misc_type_n').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          $('ddff').focus();
                                          return false;
                                         }
                     }
    }
    
     else if(a.keyCode=="13" && document.activeElement.id=="txt_misc_type_n" && $('btnSave').disabled ==false && $('btnCancel').disabled == false && $('btnExit').disabled == false)
                {
                    if($('txt_misc_type_n').value=="")
                    {
                        alert(alrtzonemgr)
                       
                        return false;
                    }
                    else
                    {
                        $('ddff').focus();
                        return false;
                    }
              }                             
           */ 
                

     
 
     
       
     
    


     
          }
}


function FOCUS_FIRST()
{
document.getElementById('drpadtype').focus();

}


function Enterf2(event)
{

var a = event ;

if(document.activeElement.id == 'txtclient1')
{

 if((event.keyCode == 8)||(event.keyCode == 46))
   {
          document.getElementById('hidden_client').value ="";
          document.getElementById('txtclient1').value ="";
         
         return true;
   }
   
     else if(event.ctrlKey==true && event.keyCode==88)
     {
           document.getElementById('hidden_client').value ="";
          document.getElementById('txtclient1').value ="";
          
              document.getElementById('txtclient1').focus();
             return true;
     }
 
 
}



if(document.activeElement.id == 'txtagency1')
{

 if((event.keyCode == 8)||(event.keyCode == 46))
   {
          document.getElementById('hidden_agency').value ="";
          document.getElementById('txtagency1').value ="";
         
         return true;
   }
   
     else if(event.ctrlKey==true && event.keyCode==88)
     {
        document.getElementById('hidden_agency').value ="";
        document.getElementById('txtagency1').value ="";          
        document.getElementById('txtagency1').focus();
             return true;
     }
 
 
}



if(document.activeElement.id == 'dpretainer')
{

 if((event.keyCode == 8)||(event.keyCode == 46))
   {
          document.getElementById('hiddenretainer').value ="";
          document.getElementById('dpretainer').value ="";
         
         return true;
   }
   
     else if(event.ctrlKey==true && event.keyCode==88)
     {
        document.getElementById('hiddenretainer').value ="";
        document.getElementById('dpretainer').value ="";          
        document.getElementById('dpretainer').focus();
             return true;
     }
 
 
}




if(document.activeElement.id == 'dpexecutive')
{

 if((event.keyCode == 8)||(event.keyCode == 46))
   {
          document.getElementById('hdnexecutivetxt').value ="";
          document.getElementById('dpexecutive').value ="";
         
         return true;
   }
   
     else if(event.ctrlKey==true && event.keyCode==88)
     {
        document.getElementById('hdnexecutivetxt').value ="";
        document.getElementById('dpexecutive').value ="";          
        document.getElementById('dpexecutive').focus();
             return true;
     }
 
 
}






  if(event.keyCode==27)
{
    
    
   
       document.getElementById('divclient').style.display="none";     
       document.getElementById('divagency').style.display="none"; 
       document.getElementById('div4').style.display="none"; 
       document.getElementById('div5').style.display="none"; 
  }
  







            if(event.keyCode==113)  
            {
            
            
             if(document.activeElement.id=="txtclient1")
                {
                    document.getElementById("divclient").style.display="block";
                    document.getElementById('divclient').style.top=190;
                    document.getElementById('divclient').style.left=570;    
                    rate_audit_orderwise.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient1').value,bindclientname_callback);
                    
                    return false;
             }
                
              
                
                  if(document.activeElement.id=="txtagency1")
                {
                    
            
            
        
                    document.getElementById('divagency').value="";
                    var compcode = document.getElementById('hiddencompcode').value;
                    document.getElementById("divagency").style.display="block";
                    document.getElementById('divagency').style.top=140+ "px" ;
                    document.getElementById('divagency').style.left=550+ "px";
                    var dateformat = "'dd/mm/yyyy'";
                    document.getElementById('divagency').focus();      
                    var txtagency1=(document.getElementById('txtagency1').value).toUpperCase();   
                    rate_audit_orderwise.bindagencyname(compcode,txtagency1,bindagencyname_callback);
                    return false;
                 
                }
                
              
              
              
              
              
                
                  if(document.activeElement.id=="dpretainer")
                {
                    
                    
                    
                       var extra1=(document.getElementById('dpretainer').value).toUpperCase();
        var extra2="";
        
        document.getElementById('lstretainer').value="";
        var compcode = document.getElementById('hiddencompcode').value;
        document.getElementById("div5").style.display="block";
        document.getElementById('div5').style.top=140+ "px" ;
        document.getElementById('div5').style.left=10+ "px";
        var dateformat = "'dd/mm/yyyy'";

        document.getElementById('lstretainer').focus();      
       
       
 
  rate_audit_orderwise.fillF2_Creditretainer(compcode,extra1,bindretainer_callback);
  return false;
                }
                
                
                  
                  if(document.activeElement.id=="dpexecutive")
                {
                    
        
        
                       var extra1=(document.getElementById('dpexecutive').value).toUpperCase();     
                    document.getElementById('lstexecutive').value="";
                    var compcode = document.getElementById('hiddencompcode').value;
                    document.getElementById("div4").style.display="block";
                    document.getElementById('div4').style.top=140+ "px" ;
                    document.getElementById('div4').style.left=50+ "px";
                    var dateformat = "'dd/mm/yyyy'";
                    document.getElementById('lstexecutive').focus();    
                    rate_audit_orderwise.fillF2_Creditexecutive(compcode,extra1,bindexecutive_callback);
                    return false;
                }



            }


}







function bindagencyname_callback(res)
{   
    
        
        ds =res.value;
     document.getElementById("ListBox1").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem = document.getElementById("ListBox1");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Agency Name-","0");
        pkgitem.options.length = 1; 
        
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
       pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+"("+ds.Tables[0].Rows[i].code_subcode+")",ds.Tables[0].Rows[i].code_subcode);        
                pkgitem.options.length;
        }
    }
    
        document.getElementById("ListBox1").focus();
        
        return false;

        
        
        
        
        

}




function bindclientname_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstclient");
     pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Client-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);

   
    //alert(pkgitem.options.length);
    pkgitem.options.length = 1; 
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
        
       pkgitem.options.length;
       
    }
    
    }
    document.getElementById('txtclient').value="";
    document.getElementById("lstclient").value="0";
   document.getElementById("lstclient").focus();
    
     return false;
}







////////////////this function is called when we open the list box of agency than on mouse click it get the agency
/*change*/
function insertclient()
{


    if(document.activeElement.id=="lstclient")
    {
    if(document.getElementById('lstclient').value=="0")
        {
        alert("Please select the client");
        return false;
        }
        document.getElementById("divclient").style.display="none";
        
 
           
        var page=document.getElementById('lstclient').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agencylist2.aspx?page="+page+"&value=1", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
        document.getElementById('txtclient').value=nameagen;

       
        
        document.getElementById("divclient").style.display='none';
        
        return false;
    }
    
    


}	






function insertclient()
{

   
   
   
   ////////////
   
    if(document.activeElement.id=="lstclient")
        {
            if(document.getElementById('lstclient').value=="0")
            {
            alert("Please select Client Name");
            return false;
            }
                   
            var page=document.getElementById('lstclient').value;
            agencycodeglo=page;
            if(browser!="Microsoft Internet Explorer")
            {
                for(var k=0;k <= document.getElementById("lstclient").length-1;k++)
                {
                    var abc=document.getElementById('lstclient').options[k].innerHTML;
                    if(document.getElementById('lstclient').options[k].value==page)
                    {
                    document.getElementById('lstclient').value=abc;
                    break;
                    }
                }
            }
            else
            {
                for(var k=0;k <= document.getElementById("lstclient").length-1;k++)
                {

          
                    if(document.getElementById('lstclient').options[k].value==page)
                    {
                    var abc=document.getElementById('lstclient').options[k].innerText;
                    var allvalues=document.getElementById('lstclient').options[k].value;

                        
                        
                        
                       
                        
                    document.getElementById('txtclient1').value=abc;
                   var splitvalue= abc;
                  var fival = abc.split("(");
                    cityval  =  fival[0];
                   distval  =  fival[1];
                   
                   
                   
                  //var getvalue=distval.substring(0,distval.length-1)                 
                   
                 document.getElementById('hidden_client').value=allvalues;
                
                    

           
                    }
                }
            }
            document.getElementById("divclient").style.display='none';

            return false;
            }
     
   
   
   ///////
   
   
   
    
    


	}
	
	



function insertagency(mycityval)
{

   
   
   
   ////////////
   
    if(document.activeElement.id=="lstagency")
        {
            if(document.getElementById('lstagency').value=="0")
            {
            alert("Please select Agency Name");
            return false;
            }
                   
            var page=document.getElementById('lstagency').value;
            agencycodeglo=page;
            if(browser!="Microsoft Internet Explorer")
            {
                for(var k=0;k <= document.getElementById("lstagency").length-1;k++)
                {
                    var abc=document.getElementById('lstagency').options[k].innerHTML;
                    if(document.getElementById('lstagency').options[k].value==page)
                    {
                    document.getElementById('lstagency').value=abc;
                    break;
                    }
                }
            }
            else
            {
                for(var k=0;k <= document.getElementById("lstagency").length-1;k++)
                {

          
                    if(document.getElementById('lstagency').options[k].value==page)
                    {
                    var abc=document.getElementById('lstagency').options[k].innerText;
                    var allvalues=document.getElementById('lstagency').options[k].value;

                        
                        
                        
                       
                        
                    document.getElementById('txtagency1').value=abc;
                   var splitvalue= abc;
                  var fival = abc.split("(");
                    cityval  =  fival[0];
                   distval  =  fival[1];
                   
                   
                   
                  var getvalue=distval.substring(0,distval.length-1)                 
                   
                 document.getElementById('hidden_agency').value=getvalue;
                
                    

           
                    }
                }
            }
            document.getElementById("divagency").style.display='none';

            return false;
            }
     
   
   
   ///////
   
   
   
    
    


	}
	
	
	
	function bindretainer_callback(res)
{   
    
        
        ds =res.value;
     document.getElementById("lstretainer").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem = document.getElementById("lstretainer");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Reatiner Name-","0");
        pkgitem.options.length = 1; 
        
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
       pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name+"("+ds.Tables[0].Rows[i].Retain_Code+")",ds.Tables[0].Rows[i].Retain_Code);        
                pkgitem.options.length;
        }
    }
    
        
        
        return false;

        
        
        
        
        

}


var agencycodeglo;



function bindagencyname_callback(res)
{   
    
        
        ds =res.value;
     document.getElementById("lstagency").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Agency Name-","0");
        pkgitem.options.length = 1; 
        
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
       pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+"("+ds.Tables[0].Rows[i].code_subcode+")",ds.Tables[0].Rows[i].code_subcode);        
                pkgitem.options.length;
        }
    }
    
        document.getElementById("lstagency").focus();
        
        return false;

        
        
        
        
        

}




function blankf2field()
{
        //  document.getElementById('txtmaingrcode').value ="";
        
        if(document.activeElement.id == "txtagency1")
        {
                  //document.getElementById('txtagency1').value ="";
               
                 // return true;
        }
        
          if(document.activeElement.id == "txtclient1")
        {
                 // document.getElementById('txtclient1').value ="";
               
                 // return true;
        }
       //  return event.keycode ;
          //return false;
}




function fillmaingrp(mycityval)
{
   


    if(document.activeElement.id=="lstretainer")
        {
            if(document.getElementById('lstretainer').value=="0")
            {
            alert("Please select Retainer Name");
            return false;
            }
                   
            var page=document.getElementById('lstretainer').value;
            agencycodeglo=page;
            if(browser!="Microsoft Internet Explorer")
            {
                for(var k=0;k <= document.getElementById("lstretainer").length-1;k++)
                {
                    var abc=document.getElementById('lstretainer').options[k].innerHTML;
                    if(document.getElementById('lstretainer').options[k].value==page)
                    {
                    document.getElementById('lstretainer').value=abc;
                    break;
                    }
                }
            }
            else
            {
                for(var k=0;k <= document.getElementById("lstretainer").length-1;k++)
                {

                //var abc=doAument.getElementById('lstretainer').options[k].innerText;
                    if(document.getElementById('lstretainer').options[k].value==page)
                    {
                    var abc=document.getElementById('lstretainer').options[k].innerText;
                    var allvalues=document.getElementById('lstretainer').options[k].value;
                  //  
//                     stateval  = fival[2];
//                     countryval = fival[3];
//                        
//                    cityname  =  fndnull(fival[4]);
//                    distname  =  fndnull(fival[5]);
//                    statename  = fndnull(fival[6]);
//                    countryname = fndnull(fival[7]);
                        
                        
                        
                       
                        
                    document.getElementById('dpretainer').value=abc;
                    
                    
                    var splitvalue= abc;
                  var fival = abc.split("(");
                    cityval  =  fival[0];
                   distval  =  fival[1];
                   
                  var getvalue=distval.substring(0,distval.length-1)
                   
                   
                 document.getElementById('hiddenretainer').value=getvalue;
                     
                 //   savemaingrcode = allvalues;
                  //  savemaingrname = fival[0]; 
                    
                    
                    
//                    document.getElementById('ddstats').value=statename;
//                    document.getElementById('ddcountry').value=countryname;
                   
                //    var splitpub = abc;                   
                //    document.getElementById('txtmaingrcode').value=splitpub;
                   
                    //document.getElementById('txtpublicationname').value=pubspace;
           
                    }
                }
            }
            document.getElementById("div5").style.display='none';
         //   document.getElementById("txtP_Subgrpdes").focus();
            return false;
            }
     

    
}



function fillexecutivegrp(mycityval)
{
   


    if(document.activeElement.id=="lstexecutive")
        {
            if(document.getElementById('lstexecutive').value=="0")
            {
            alert("Please select Executive Name");
            return false;
            }
                   
            var page=document.getElementById('lstexecutive').value;
            agencycodeglo=page;
            if(browser!="Microsoft Internet Explorer")
            {
                for(var k=0;k <= document.getElementById("lstexecutive").length-1;k++)
                {
                    var abc=document.getElementById('lstexecutive').options[k].innerHTML;
                    if(document.getElementById('lstexecutive').options[k].value==page)
                    {
                    document.getElementById('lstexecutive').value=abc;
                    break;
                    }
                }
            }
            else
            {
                for(var k=0;k <= document.getElementById("lstexecutive").length-1;k++)
                {

          
                    if(document.getElementById('lstexecutive').options[k].value==page)
                    {
                    var abc=document.getElementById('lstexecutive').options[k].innerText;
                    var allvalues=document.getElementById('lstexecutive').options[k].value;

                        
                        
                        
                       
                        
                    document.getElementById('dpexecutive').value=abc;
                   var splitvalue= abc;
                  var fival = abc.split("(");
                    cityval  =  fival[0];
                   distval  =  fival[1];
                   
                   
                   
                  var getvalue=distval.substring(0,distval.length-1)                 
                   
                 document.getElementById('hdnexecutivetxt').value=getvalue;
                
                    

           
                    }
                }
            }
            document.getElementById("div4").style.display='none';
         //   document.getElementById("txtP_Subgrpdes").focus();
            return false;
            }
     

    
}






function bindexecutive_callback(res)
{
     var ds_AccName=res.value;     
         document.getElementById("lstexecutive").innerHTML = "";
      
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0)
        {
            var pkgitem = document.getElementById("lstexecutive");
            pkgitem.options.length = 0;
            pkgitem.options[0]=new Option("-Select Executive Name-","0");
            pkgitem.options.length = 1;
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(trim(ds_AccName.Tables[0].Rows[i].Exec_name)+"("+ds_AccName.Tables[0].Rows[i].Exe_no+")",ds_AccName.Tables[0].Rows[i].Exe_no);        
                pkgitem.options.length;
            }
        }
//        document.getElementById("lstexecutive").value="0";
//        document.getElementById("div3").value="";
//   
  
        return false;

}


function trim(stringToTrim) 
 {

	return stringToTrim.replace(/^\s+|\s+$/g,"");
 }