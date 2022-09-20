// JScript File
var bookid="";

function catexitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}
var browser=navigator.appName;
function refreshControl()
{
    document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
    
    document.getElementById('txtagency').style.color= "black";
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
    document.getElementById('txtremarks').style.backgroundColor="#FFFFFF";
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

//function openbookingModify()
//{

//if(document.getElementById('hiddenadtype').value=="DI0")
//{
//win=window.open('Booking_master.aspx?cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
//}
//else if(document.getElementById('hiddenadtype').value=="CL0")
//{
//win=window.open('Classified_Booking.aspx?cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
//}
//document.getElementById('hiddenmodify').value="1";
//}



function openbookingModify()
{
   //win=window.open("bookingauditshowdetailgrid.aspx?cioid="+document.getElementById('hiddenbookingid').value);
    window.open('bookingauditshowdetailgrid.aspx?cioid=' + document.getElementById('hiddenbookingid').value + '&packagename=' + document.getElementById('txtpackage').value, '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
 // alert("show detail");

   /* if(document.getElementById('hiddenadtype').value=="DI0")
    {
        win=window.open('Booking_master.aspx?cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    }
    else if(document.getElementById('hiddenadtype').value=="CL0")
    {
         win=window.open('Classified_Booking.aspx?cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    }  */
    //document.getElementById('hiddenmodify').value="1";   
      return false;
}

function clearfields()
{
 document.getElementById('txtagency').value=="";
 document.getElementById('txtuom').value=="";
 document.getElementById('txtcardrate').value=="";
 document.getElementById('txtclient').value=="";
 document.getElementById('txtpackage').value=="";
 document.getElementById('txtcardamount').value=="";
 document.getElementById('txtpaymode').value=="";
 document.getElementById('txtpublishdate').value=="";
 document.getElementById('txtagreedrate').value=="";
 document.getElementById('txtrono').value=="";
 document.getElementById('txtnoofinsertion').value=="";
 document.getElementById('txtagreedamount').value=="";
 document.getElementById('txtallert').value="";
 
 document.getElementById('txtrostatus').value=="";
 document.getElementById('txtpaid').value=="";
 document.getElementById('txtdiscount').value=="";
 document.getElementById('txtdiscountamt').value=="";
 
 document.getElementById('txtexecutivename').value=="";
 document.getElementById('txtcontractname').value=="";
 document.getElementById('txtPagePrem').value=="";
 document.getElementById('txtPagePremamt').value=="";
 
 document.getElementById('txtoutstanding').value=="";
 document.getElementById('txtheight').value=="";
 document.getElementById('txtwidth').value=="";
 document.getElementById('txtpositionpremium').value=="";
 document.getElementById('txtpositionpremiumamt').value=="";
 
 document.getElementById('txtretainername').value=="";
 document.getElementById('txtlines').value=="";
 document.getElementById('txtspecialdiscount').value=="";
 document.getElementById('txtspecialdiscountamt').value=="";
 
 document.getElementById('txtbookingtype').value=="";
 document.getElementById('txtpageposition').value=="";
 document.getElementById('txtspacediscount').value=="";
 document.getElementById('txtspacediscountamt').value=="";
 
 document.getElementById('txtcolourtype').value=="";
 document.getElementById('txtpositionpre').value=="";
 document.getElementById('txtSumAmt').value=="";
 
 document.getElementById('txtadcategory').value=="";
 document.getElementById('txtarea').value=="";
 document.getElementById('txtspecialcharge').value=="";
 
 document.getElementById('txtadsubcat1').value=="";
 document.getElementById('txtschemetype').value=="";
 document.getElementById('txtgrossamt').value=="";
 
  document.getElementById('txtadsubcat2').value=="";
 document.getElementById('txtratecode').value=="";
 document.getElementById('txtagtradediscount').value=="";
 document.getElementById('txtagtradediscountamt').value=="";
 
 document.getElementById('txtadsubcat3').value=="";
 document.getElementById('txtaddagecomm').value=="";
 document.getElementById('txtaddagecommamt').value=="";
 
 document.getElementById('txtadsubcat4').value=="";
 document.getElementById('txtbillamount').value=="";
 
  document.getElementById('txt_eyecater').value=="";
 document.getElementById('txt_eyecaterprem').value=="";
 document.getElementById('txtretainercommission').value=="";
 document.getElementById('txtretainercommissionamt').value=="";
 document.getElementById('txtremarks').value="";
 document.getElementById('txt_otherlanguage').value=""; 
 
}
function openbooking(cioid,id,length,adtype)
{
    refreshControl();
    clearfields();
    
    var chkid="";
    if(id.indexOf("cio")>=0)
    {
        //chkid="DataGrid1__ctl_CheckBox1"+id.split('cio')[1];
        chkid="chk"+id.split('cio')[1];
    }
    
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
    
    var status=document.getElementById('drpaudit').value;
    if(status=="audit")
    
    {
        document.getElementById('btnaudit').disabled=true;
        document.getElementById('btnpreview').disabled=false;
        document.getElementById('btnunaudit').disabled=false;
        document.getElementById('btnsave1').disabled=false;
    }
    else if (status=="modified" || status=="unaudit")
    {
        if(chkid != "" && document.getElementById(chkid).disabled==false)
            document.getElementById('btnaudit').disabled=false;
        else
            document.getElementById('btnaudit').disabled=true;
        
        document.getElementById('btnunaudit').disabled=true;
        document.getElementById('btnpreview').disabled=false;
        document.getElementById('btnsave1').disabled=false;
    }
    else
    {
        document.getElementById('btnaudit').disabled=false;
        document.getElementById('btnpreview').disabled=false;
        document.getElementById('btnunaudit').disabled=false;
        document.getElementById('btnsave1').disabled=false;
    }
   
//    if(document.getElementById('txtremarks')!=null)&&()
        document.getElementById('txtremarks').disabled=false;

    if(document.getElementById('btnmodify')!=null)
        document.getElementById('btnmodify').disabled=false;        
        document.getElementById('btnrefresh').disabled=false;
bookid=cioid;
    Booking_Audit1.execute(cioid,document.getElementById('hiddencompcode').value,adtype,document.getElementById('hiddendateformat').value,exec_callback);    
}

function exec_callback(response)
{
document.getElementById('txtremarks').value="";
 document.getElementById('txt_otherlanguage').value="";
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
                if(ds.Tables[0].Rows[0].Agency_address!=ds.Tables[2].Rows[0].Agency_address)
                {
                    document.getElementById('txtagencyadders').style.backgroundColor="#FFFF80";
                }
                else
                {
                    document.getElementById('txtagencyadders').style.backgroundColor="#FFFFFF";
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
            else  
            {
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
                document.getElementById('txtagency').value="";
            }
            else
            {
                document.getElementById('txtagency').value=ds.Tables[0].Rows[0].AgencyName;
            }
            
            if(ds.Tables[0].Rows[0].Agency_code==null)
            {
                document.getElementById('txtallert').value="";
            }
            else
            { var res= Booking_Audit1.getagencyRemark(document.getElementById('hiddencompcode').value,bookid,ds.Tables[0].Rows[0].Agency_code,"","A");    
                 if (res.value != null)
                if (res.value.Tables[0].Rows.length > 0)
                  document.getElementById('txtallert').value= res.value.Tables[0].Rows[0].REMARK;
                  else
                  {
                  document.getElementById('txtallert').value="";
                  }
            }
            
             if(ds.Tables[0].Rows[0].Agency_address==null)
            {
                document.getElementById('txtagencyadders').value=="";
            }
            else
            {
                document.getElementById('txtagencyadders').value=ds.Tables[0].Rows[0].Agency_address;
            }
            
           
             if (ds.Tables[0].Rows[0].CGST_AMT == null) {
                 document.getElementById('txtcgst').value = "";
             }
             else {
                 document.getElementById('txtcgst').value = ds.Tables[0].Rows[0].CGST_AMT;
             }
             if (ds.Tables[0].Rows[0].SGST_AMT == null) {
                 document.getElementById('txtsgst').value = "";
             }
             else {
                 document.getElementById('txtsgst').value = ds.Tables[0].Rows[0].SGST_AMT;
             }
             if (ds.Tables[0].Rows[0].IGST_AMT == null) {
                 document.getElementById('txtigst').value = "";
             }
             else {
                 document.getElementById('txtigst').value = ds.Tables[0].Rows[0].IGST_AMT;
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
                        var ds_pkg=Booking_Audit1.getPackageName(document.getElementById('hiddencompcode').value,s1[k_]);
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
                    var ds_pkg=Booking_Audit1.getPackageName(document.getElementById('hiddencompcode').value,ds.Tables[0].Rows[0].Package_code);
                    if(ds_pkg.value!=null)
                    {
                        document.getElementById('txtpackage').value=ds_pkg.value.Tables[0].Rows[0].Package_Name;
                    }
                }
            }
            if(ds.Tables[0].Rows[0].Card_rate==null)
            {
                document.getElementById('txtcardrate').value="";
            }
            else
            {
                document.getElementById('txtcardrate').value=ds.Tables[0].Rows[0].Card_rate;
            }
            if(ds.Tables[0].Rows[0].Client==null)
            {
                document.getElementById('txtclient').value="";
            }
            else
            {
                document.getElementById('txtclient').value=ds.Tables[0].Rows[0].Client;
            }
            if(ds.Tables[0].Rows[0].Agreed_amount==null || ds.Tables[0].Rows[0].Agreed_amount=="" ||ds.Tables[0].Rows[0].Agreed_amount=="0")
            {
                document.getElementById('txtagreedamount').value="";
            }
            else
            {
                document.getElementById('txtagreedamount').value=ds.Tables[0].Rows[0].Agreed_amount;
            }
            if(ds.Tables[0].Rows[0].Space_discount==null)
            {
                document.getElementById('txtspacediscountamt').value="";
            }
            else
            {
                document.getElementById('txtspacediscountamt').value=ds.Tables[0].Rows[0].Space_discount;                
            }
    
            if(ds.Tables[0].Rows[0].Space_disc_per==null)
            {
                document.getElementById('txtspacediscount').value="";
                document.getElementById('txtspacediscountamt').value="";
            }
            else
            {
                document.getElementById('txtspacediscount').value=ds.Tables[0].Rows[0].Space_disc_per;
                if(document.getElementById('txtarea').value!="")
                    document.getElementById('txtspacediscountamt').value=(parseFloat(ds.Tables[0].Rows[0].Space_disc_per)*parseFloat(document.getElementById('txtarea').value)*parseFloat(document.getElementById('txtcardrate').value)/100).toFixed(2);
                   
            }
            if(ds.Tables[0].Rows[0].Special_charges==null ||ds.Tables[0].Rows[0].Special_charges=="" )
            {
                document.getElementById('txtspecialcharge').value="";
            }
            else
            {
                document.getElementById('txtspecialcharge').value=(parseFloat(ds.Tables[0].Rows[0].Special_charges)).toFixed(2);
            }
            if(ds.Tables[0].Rows[0].RETAINER1==null || ds.Tables[0].Rows[0].RETAINER1=="")
            {
                document.getElementById('txtretainername').value="";
            }
            else
            {
                document.getElementById('txtretainername').value=ds.Tables[0].Rows[0].RETAINER1;
            }
            if(ds.Tables[0].Rows[0].PayMode==null || ds.Tables[0].Rows[0].PayMode=="" )
            {
                document.getElementById('txtpaymode').value="";
            }
            else
            {
                document.getElementById('txtpaymode').value=ds.Tables[0].Rows[0].PayMode;
            }
            if(ds.Tables[0].Rows[0].ADD_AGENCY_COMM==null || ds.Tables[0].Rows[0].ADD_AGENCY_COMM=="")
            {
                document.getElementById('txtaddagecomm').value="";
            }
            else
            {
                document.getElementById('txtaddagecomm').value=ds.Tables[0].Rows[0].ADD_AGENCY_COMM;
            }
            if(ds.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT==null || ds.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT=="")
            {
                document.getElementById('txtaddagecommamt').value="";
            }
            else
            {
                document.getElementById('txtaddagecommamt').value=(parseFloat(ds.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT)).toFixed(2);
            }
       
            if(ds.Tables[0].Rows[0].RO_No==null || ds.Tables[0].Rows[0].RO_No=="")
            {
                document.getElementById('txtrono').value="";
            }
            else
            {
                document.getElementById('txtrono').value=ds.Tables[0].Rows[0].RO_No;
            }
            if(ds.Tables[0].Rows[0].Book_type==null ||ds.Tables[0].Rows[0].Book_type=="" )
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
                else
                {
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
                document.getElementById('txtbillamount').value=(parseFloat(ds.Tables[0].Rows[0].Bill_amount)).toFixed(2);
            }
            if(ds.Tables[0].Rows[0].Rate_code==null)
            {
                document.getElementById('txtratecode').value="";
            }
            else
            {
                document.getElementById('txtratecode').value=ds.Tables[0].Rows[0].Rate_code;
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
            if(ds.Tables[0].Rows[0].SUBCAT5==null || ds.Tables[0].Rows[0].SUBCAT5=="")
            {
                document.getElementById('txtadsubcat4').value="";
            }
            else
            {
                document.getElementById('txtadsubcat4').value=ds.Tables[0].Rows[0].SUBCAT5;
            }
            if(ds.Tables[0].Rows[0].PositionPremium==null ||ds.Tables[0].Rows[0].PositionPremium=="")
            {
                document.getElementById('txtpositionpre').value="";
            }
            else
            {
                document.getElementById('txtpositionpre').value=ds.Tables[0].Rows[0].PositionPremium;
            }
            if(ds.Tables[0].Rows[0].RETAINER_COMM1==null || ds.Tables[0].Rows[0].RETAINER_COMM1=="")
            {
                document.getElementById('txtretainercommission').value="";
            }
            else
            {
                document.getElementById('txtretainercommission').value=ds.Tables[0].Rows[0].RETAINER_COMM1;
            }
            if(ds.Tables[0].Rows[0].RETAINER_COMM_AMT==null || ds.Tables[0].Rows[0].RETAINER_COMM_AMT=="")
            {
                document.getElementById('txtretainercommissionamt').value="";
            }
            else
            {
                document.getElementById('txtretainercommissionamt').value=(parseFloat(ds.Tables[0].Rows[0].RETAINER_COMM_AMT)).toFixed(2);
            }
            
            if(ds.Tables[0].Rows[0].Trade_disc==null)
            {
                document.getElementById('txtagtradediscount').value="";
                document.getElementById('txtagtradediscountamt').value="";
            }
            else
            {
                document.getElementById('txtagtradediscount').value=ds.Tables[0].Rows[0].Trade_disc;
                if(ds.Tables[0].Rows[0].Gross_amount!=null)
                    document.getElementById('txtagtradediscountamt').value=(parseFloat(ds.Tables[0].Rows[0].Trade_disc)*parseFloat(ds.Tables[0].Rows[0].Gross_amount)/100).toFixed(2);
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
                document.getElementById('txtcardamount').value=(parseFloat(ds.Tables[0].Rows[0].Card_amount)).toFixed(2);
            }
            if(ds.Tables[0].Rows[0].Agrred_rate==null ||ds.Tables[0].Rows[0].Agrred_rate=="" || ds.Tables[0].Rows[0].Agrred_rate=="0")
            {
                document.getElementById('txtagreedrate').value=""
            }
            else
            {
                document.getElementById('txtagreedrate').value=ds.Tables[0].Rows[0].Agrred_rate;
            }
            if(ds.Tables[0].Rows[0].Color_cod==null)
            {
                document.getElementById('txtcolourtype').value=""
            }
            else
            {
                document.getElementById('txtcolourtype').value=ds.Tables[0].Rows[0].Color_cod;
            }
            if(ds.Tables[0].Rows[0].Gross_amount==null)
            {
                document.getElementById('txtgrossamt').value=""
            }
            else
            {
                document.getElementById('txtgrossamt').value=(parseFloat(ds.Tables[0].Rows[0].Gross_amount)).toFixed(2);
            }
//To Show Translation charge and Box name..
            if (ds.Tables[0].Rows[0].TRANSLATION_PREMIUM == null || ds.Tables[0].Rows[0].TRANSLATION_PREMIUM == "")
            {
                document.getElementById('txttransper').value = "0"
                document.getElementById('txttranamt').value = "0.00"
            }
            else
            {
                document.getElementById('txttransper').value = ds.Tables[0].Rows[0].TRANSLATION_PREMIUM;
                if (ds.Tables[0].Rows[0].Gross_amount != null){
                    if (ds.Tables[0].Rows[0].TRANS_TYPE = "P")
                        document.getElementById('txttranamt').value = (parseFloat(ds.Tables[0].Rows[0].TRANSLATION_PREMIUM) * parseFloat(ds.Tables[0].Rows[0].Gross_amount) / 100).toFixed(2);
                    else
                        document.getElementById('txttranamt').value = (parseFloat(ds.Tables[0].Rows[0].TRANSLATION_PREMIUM)).toFixed(2);
                    }
            }
            if (ds.Tables[0].Rows[0].boxname == null) {
                document.getElementById('txtboxcrg').value = ""
            }
            else {
                document.getElementById('txtboxcrg').value = ds.Tables[0].Rows[0].boxname;
            }

            if (ds.Tables[0].Rows[0].boxcharge == null) {
                document.getElementById('txtboxcharges').value = ""
            }
            else {
                document.getElementById('txtboxcharges').value = ds.Tables[0].Rows[0].boxcharge;
            }
           
//            if(ds.Tables[0].Rows[0].remarks==null)
//            {
//                document.getElementById('txtremarks').value=""
//            }
//            else
//            {
//                document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
//            }
            if(ds.Tables[0].Rows[0].remarks==null)
            {
                document.getElementById('txtremarks').value=""
                document.getElementById('txt_otherlanguage').value="";
            }
            else
            {
              var remark_execute=ds.Tables[0].Rows[0].remarks;
              if(remark_execute.indexOf('~') != -1)
              {
                document.getElementById('txt_otherlanguage').value=ds.Tables[0].Rows[0].remarks;
              }
             else
               {            
                document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
               }
            }
            
            /**************ajay*******************/                
                        if(ds.Tables[0].Rows[0].Bill_remarks==null)
                        {
                            document.getElementById('txtbillremark').value="";//style.backgroundColor="#FFFF80";
                        }
                        else
                        {
                            document.getElementById('txtbillremark').value=ds.Tables[0].Rows[0].Bill_remarks;//.style.backgroundColor="#FFFFFF";
                        }
                        
                        if(ds.Tables[0].Rows[0].Caption==null)//!=ds.Tables[2].Rows[0].Discount)
                        {
                            document.getElementById('txtcaption').value="";//.style.backgroundColor="#FFFF80";
                        }
                        else
                        {
                            document.getElementById('txtcaption').value=ds.Tables[0].Rows[0].Caption;//style.backgroundColor="#FFFFFF";
                        }
       /******************ajay end*******************/ 
            
            
   //document.getElementById('txtschemetype').value=ds.Tables[0].Rows[0].Contract_name;
            if(ds.Tables[0].Rows[0].Special_discount==null)
            {
                document.getElementById('txtspecialdiscountamt').value="";
            }
            else
            {
                document.getElementById('txtspecialdiscountamt').value=ds.Tables[0].Rows[0].Special_discount;               
            }
            if(ds.Tables[0].Rows[0].Special_disc_per==null)
            {
                document.getElementById('txtspecialdiscount').value="";
                document.getElementById('txtspecialdiscountamt').value="";
            }
            else
            {
                document.getElementById('txtspecialdiscount').value=ds.Tables[0].Rows[0].Special_disc_per;
                 if(document.getElementById('txtarea').value!="")
                    document.getElementById('txtspecialdiscountamt').value=(parseFloat(ds.Tables[0].Rows[0].Special_disc_per)*parseFloat(document.getElementById('txtarea').value)*parseFloat(document.getElementById('txtcardrate').value)/100).toFixed(2);
            }
   
            if(ds.Tables[0].Rows[0].Discount==null || ds.Tables[0].Rows[0].Discount=="")
            {
                document.getElementById('txtdiscountamt').value="";
            }
            else
            {
                if(ds.Tables[0].Rows[0].Discount!="0")
                    document.getElementById('txtdiscountamt').value=parseFloat(document.getElementById('txtcardamount').value)-parseFloat(document.getElementById('txtagreedamount').value);//ds.Tables[0].Rows[0].Discount;
            }
            if(ds.Tables[0].Rows[0].Discount_per== null || ds.Tables[0].Rows[0].Discount_per=="" )
            {
                document.getElementById('txtdiscount').value="";
            }
            else
            {
                document.getElementById('txtdiscount').value=ds.Tables[0].Rows[0].Discount_per;
            }
      
            if(ds.Tables[0].Rows[0].Ad_type_code==null || ds.Tables[0].Rows[0].Ad_type_code=="")
            {
                document.getElementById('hiddenadtype').value="";
            }
            else
            {
                document.getElementById('hiddenadtype').value=ds.Tables[0].Rows[0].Ad_type_code;
            }
            
            //for page premium
            var page_premium=0;
            if(ds.Tables[0].Rows[0].Prem_per==null || ds.Tables[0].Rows[0].Prem_per==""||ds.Tables[0].Rows[0].Prem_per=="null")
            {
                document.getElementById('txtPagePrem').value="";
                document.getElementById('txtPagePremamt').value="";
            }
            else
            {
                document.getElementById('txtPagePrem').value=ds.Tables[0].Rows[0].Prem_per;
                if(document.getElementById('txtcardamount').value!="")
                {
                    page_premium=document.getElementById('txtPagePremamt').value=(parseFloat(document.getElementById('txtcardamount').value)*parseFloat(document.getElementById('txtPagePrem').value)/100).toFixed(2);
                }
            }
            //for position premium
            if(ds.Tables[0].Rows[0].Page_amount==null ||ds.Tables[0].Rows[0].Page_amount=="")
            {
                document.getElementById('txtpositionpremium').value="";
                document.getElementById('txtpositionpremiumamt').value="";
            }
            else
            {
                document.getElementById('txtpositionpremium').value=ds.Tables[0].Rows[0].Page_amount;
                if(document.getElementById('txtcardamount').value!="")
                {
                    document.getElementById('txtpositionpremiumamt').value=((parseFloat(page_premium)+parseFloat(document.getElementById('txtcardamount').value))*parseFloat(document.getElementById('txtpositionpremium').value)/100).toFixed(2);
                }
            }
            
            //calculate net amount **********************************************
            if(document.getElementById('txtarea').value!="")
                var tot_area=document.getElementById('txtarea').value;
            else
                var tot_area=1;
            
            if(document.getElementById('txtspacediscountamt').value=="")
                var disc_space=0;
            else
                var disc_space=document.getElementById('txtspacediscountamt').value;
                
            if(document.getElementById('txtspecialdiscountamt').value=="")
                var disc_special=0;
            else
                var disc_special=document.getElementById('txtspecialdiscountamt').value;
                
            if(document.getElementById('txtdiscountamt').value=="")
                var disc_amt=0;
            else
                var disc_amt=document.getElementById('txtdiscountamt').value;
            var pos_premium="0"; 
            if(document.getElementById('txtpositionpremiumamt').value!="")
            {                
                pos_premium=document.getElementById('txtpositionpremiumamt').value;
            }
            if(document.getElementById('txtagreedamount').value!="" && document.getElementById('txtagreedamount').value!="0" )
                document.getElementById('txtSumAmt').value=parseFloat(document.getElementById('txtagreedamount').value).toFixed(2);
            else
            {
            
            
            if(document.getElementById('txtcardamount').value=="")
            {
            document.getElementById('txtcardamount').value=0;
            }
                document.getElementById('txtSumAmt').value=(parseFloat(document.getElementById('txtcardamount').value)+parseFloat(page_premium)+parseFloat(pos_premium)-parseFloat(disc_amt)-parseFloat(disc_space)-parseFloat(disc_special)).toFixed(2);
                
            }
            //*****************************
            
              if(ds.Tables[0].Rows[0].Bullet_Desc==null)
               document.getElementById('txt_eyecater').value="";
            else
                document.getElementById('txt_eyecater').value=ds.Tables[0].Rows[0].Bullet_Desc;
            
            /////////////
            
           if(ds.Tables[0].Rows[0].Bullet_premium==null)
           document.getElementById('txt_eyecaterprem').value="";
            else
                document.getElementById('txt_eyecaterprem').value=ds.Tables[0].Rows[0].Bullet_premium;
            
            
            //////////////
          var count=0;
          if(ds.Tables[1].Rows[0]!=undefined)
          {
          
          count=  ds.Tables[1].Rows[0].count;
            }
            if(count==0)
            {
                document.getElementById('btnaudit').value='Audit';
            }
            else
            {    
                document.getElementById('btnaudit').value='ReAudit';
            //-----------------------------------------------
                if(ds.Tables[3].Rows.length>0)
                {
                    if(ds.Tables[0].Rows[0].AgencyName!=ds.Tables[3].Rows[0].AgencyName)
                    {
                        document.getElementById('txtagency').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtagency').style.backgroundColor="#FFFFFF";
                    }
                    
                      if(ds.Tables[0].Rows[0].Agency_address!=ds.Tables[3].Rows[0].Agency_address)
                    {
                        document.getElementById('txtagencyadders').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtagencyadders').style.backgroundColor="#FFFFFF";
                    }
                    
                  
                    if(ds.Tables[0].Rows[0].AgencySubCode!=ds.Tables[3].Rows[0].AgencySubCode)
                    {
                        document.getElementById('txtagencysubcode').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtagencysubcode').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Client!=ds.Tables[3].Rows[0].Client)
                    {
                        document.getElementById('txtclient').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtclient').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Agency_type!=ds.Tables[3].Rows[0].Agency_type)
                    {
                        document.getElementById('txtagencytype').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtagencytype').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Agency_address!=ds.Tables[3].Rows[0].Agency_address)
                    {
                        document.getElementById('txtadress2').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtadress2').style.backgroundColor="#FFFFFF";
                    }
                    if(ds.Tables[0].Rows[0].Client_address!=ds.Tables[3].Rows[0].Client_address)
                    {
                        document.getElementById('txtaddress1').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtaddress1').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Agency_status!=ds.Tables[3].Rows[0].Agency_status)
                    {
                        document.getElementById('txtstatus').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtstatus').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].PayMode!=ds.Tables[3].Rows[0].PayMode)
                    {
                        document.getElementById('txtpaymode').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtpaymode').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Agency_credit!=ds.Tables[3].Rows[0].Agency_credit)
                    {
                        document.getElementById('txtcreditperiod').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtcreditperiod').style.backgroundColor="#FFFFFF";
                    }
         
                    if(ds.Tables[0].Rows[0].RO_No!=ds.Tables[3].Rows[0].RO_No)
                    {
                        document.getElementById('txtrono').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtrono').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].RO_Date!=ds.Tables[3].Rows[0].RO_Date)
                    {
                        document.getElementById('txtrodate').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtrodate').style.backgroundColor="#FFFFFF";
                    }
                 
                    if(ds.Tables[0].Rows[0].ro_status!=ds.Tables[3].Rows[0].ro_status)
                    {
                        document.getElementById('txtrostatus').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtrostatus').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Dockit_no!=ds.Tables[3].Rows[0].Dockit_no)
                    {
                        document.getElementById('txtdockitno').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtdockitno').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Key_no!=ds.Tables[3].Rows[0].Key_no)
                    {
                        document.getElementById('txtkeyno').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtkeyno').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].execname!=ds.Tables[3].Rows[0].execname)
                    {
                        document.getElementById('txtexecutivename').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtexecutivename').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Executive_zone!=ds.Tables[3].Rows[0].Executive_zone)
                    {
                        document.getElementById('txtexecutivezone').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtexecutivezone').style.backgroundColor="#FFFFFF";
                    }
            
                    if(ds.Tables[0].Rows[0].Agency_out!=ds.Tables[3].Rows[0].Agency_out)
                    {
                        document.getElementById('txtoutstanding').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtoutstanding').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].categoryname!=ds.Tables[3].Rows[0].categoryname)
                    {
                        document.getElementById('txtadcategory').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtadcategory').style.backgroundColor="#FFFFFF";
                    }
         
                    if(ds.Tables[0].Rows[0].subcategoryname!=ds.Tables[3].Rows[0].subcategoryname)
                    {
                        document.getElementById('txtadsubcat').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtadsubcat').style.backgroundColor="#FFFFFF";
                    }
         
           
                    if(ds.Tables[0].Rows[0].Brand!=ds.Tables[3].Rows[0].Brand)
                    {
                        document.getElementById('txtbrand').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtbrand').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].product!=ds.Tables[3].Rows[0].product)
                    {
                        document.getElementById('txtproduct').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtproduct').style.backgroundColor="#FFFFFF";
                    }
         
                    if(ds.Tables[0].Rows[0].UOM!=ds.Tables[3].Rows[0].UOM)
                    {
                        document.getElementById('txtuom').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtuom').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].PagePremium!=ds.Tables[3].Rows[0].PagePremium)
                    {
                        document.getElementById('txtpagepremium').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtpagepremium').style.backgroundColor="#FFFFFF";
                    }
         
                    if(ds.Tables[0].Rows[0].PositionPremium!=ds.Tables[3].Rows[0].PositionPremium)
                    {
                        document.getElementById('txtpositionpremium').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtpositionpremium').style.backgroundColor="#FFFFFF";
                    }
                    if(ds.Tables[0].Rows[0].Ad_size_column!=ds.Tables[3].Rows[0].Ad_size_column)
                    {
                        document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtnoofcolumns').style.backgroundColor="#FFFFFF";
                    }
         
                    if(ds.Tables[0].Rows[0].Ad_size_height!=ds.Tables[3].Rows[0].Ad_size_height)
                    {
                        document.getElementById('txtheight').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtheight').style.backgroundColor="#FFFFFF";
                    }
             
                    if(ds.Tables[0].Rows[0].Ad_size_width!=ds.Tables[3].Rows[0].Ad_size_width)
                    {
                        document.getElementById('txtwidth').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtwidth').style.backgroundColor="#FFFFFF";
                    }
         
                    if(ds.Tables[0].Rows[0].Currency!=ds.Tables[3].Rows[0].Currency)
                    {
                        document.getElementById('txtcurrencytype').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtcurrencytype').style.backgroundColor="#FFFFFF";
                    }  
             
                    if(ds.Tables[0].Rows[0].Insertion_date!=ds.Tables[3].Rows[0].Insertion_date)
                    {
                        document.getElementById('txtpublishdate').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtpublishdate').style.backgroundColor="#FFFFFF";
                    }  
         
                    if(ds.Tables[0].Rows[0].No_of_insertion!=ds.Tables[3].Rows[0].No_of_insertion)
                    {
                        document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtnoofinsertion').style.backgroundColor="#FFFFFF";
                    }  
             
             
                    if(ds.Tables[0].Rows[0].Contract_name!=ds.Tables[3].Rows[0].Contract_name)
                    {
                        document.getElementById('txtcontractname').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtcontractname').style.backgroundColor="#FFFFFF";
                    }  
         
                    if(ds.Tables[0].Rows[0].Paid_ins!=ds.Tables[3].Rows[0].Paid_ins)
                    {
                        document.getElementById('txtpaid').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtpaid').style.backgroundColor="#FFFFFF";
                    } 
                    if(ds.Tables[0].Rows[0].Card_amount!=ds.Tables[3].Rows[0].Card_amount)
                    {
                        document.getElementById('txtcardamount').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtcardamount').style.backgroundColor="#FFFFFF";
                    } 
         
                    if(ds.Tables[0].Rows[0].Agrred_rate!=ds.Tables[3].Rows[0].Agrred_rate)
                    {
                        document.getElementById('txtagreedrate').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtagreedrate').style.backgroundColor="#FFFFFF";
                    } 
             
                    if(ds.Tables[0].Rows[0].Special_discount!=ds.Tables[3].Rows[0].Special_discount)
                    {
                        document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtspecialdiscount').style.backgroundColor="#FFFFFF";
                    } 
             
                    if(ds.Tables[0].Rows[0].Discount!=ds.Tables[3].Rows[0].Discount)
                    {
                        document.getElementById('txtdiscount').style.backgroundColor="#FFFF80";
                    }
                    else
                    {
                        document.getElementById('txtdiscount').style.backgroundColor="#FFFFFF";
                    } 
                }
                else
                {
                    if(ds.Tables[2].Rows.length>0)
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
                }
            }  
        }
    } 
  
}

    function selectall()
    {
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
    document.getElementById('txtremarks').value="";
    document.getElementById('txt_otherlanguage').value="";
 
    var todate=document.getElementById('txtvalidityfrom').value;
    var fromdate=document.getElementById('txttilldate').value;

    if(document.getElementById('drpadtype').value=="0")
    {
          alert("Please Select Ad Type");
          document.getElementById('drpadtype').focus();
          return false;
    }
    else if(document.getElementById('drprevenu').value=="0") 
    {
          alert("Please Select Revenue Center");
          document.getElementById('drprevenu').focus();
          return false;
    }  
  
    
  /*
     else if(document.getElementById('drprate').value=="0") 
    {
          alert("Please Select Category");
          document.getElementById('drprate').focus();
          return false;
    }  
   */ 
    
      else if(document.getElementById('drpaudit').value=="0") 
    {
          alert("Please Select Audit Type");
          document.getElementById('drpaudit').focus();
          return false;
    }       
    
    if(fromdate=="")
    {    
    alert('Please Fill From Date');
         document.getElementById('txtvalidityfrom').focus();
        return false;
    }    
    if(todate=="" )
    {
        alert('Please Fill  To Date');
         document.getElementById('txttilldate').focus();
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

//Booking_Audit1.execute(todate,fromdate,call_back);
}

/*
   if(document.getElementById('drpbranch').selectedIndex!=-1) 
       
       document.getElementById('hiddenbranch').value=document.getElementById('drpbranch').options[document.getElementById('drpbranch').selectedIndex].value;        
 */       
         document.getElementById('hiddenbranch').value=document.getElementById('drpbranch').value;        
       var booking_audit=document.getElementById('hiddenbk_audit').value;
       
       
  var  drp_bank="";     
       
       for(i=0;i<document.getElementById('drprate').options.length-1;i++)
{ 
    if(document.getElementById('drprate').options[i]!=null)
    {
        if(document.getElementById('drprate').options[i].selected==true)
        {
         drp_bank=document.getElementById('drprate').options[i].value;
         document.getElementById('hdnexecutivetxt').value=drp_bank;
        }
    }
}

        outerHTML: "<OPTION value=OB1 selected>OBITUARY 40SQCM</OPTION>" 
       
       //  if(document.getElementById('drprate').selectedIndex!=-1) 
       // document.getElementById('hdnexecutivetxt').value=document.getElementById('drprate').options[document.getElementById('drprate').selectedIndex].text;        
       //var booking_audit=document.getElementById('hiddenbk_audit').value;
  
       
       
       
       if(booking_audit=="n")
       {
       alert('Booking Audit is not required so you are not allowed to view any booking here');
       return false;
       }
  
   
       
        var  pcomp_code=document.getElementById('hiddencomcode').value;
        var  puserid= document.getElementById('hiddenuserid').value;
        var  pformname= "Booking_Audit";     
        var  pdateformat= document.getElementById('hiddendateformat').value;        
        var pextra1="";
        var pextra2=""; 
        var res;
        var  ds;
        
        /*
        
        if(document.getElementById('txtvalidityfrom')!="")
        {
        var  pentry_date= document.getElementById('txtvalidityfrom').value;
        
         res=Booking_Audit1.fetch_date_data(pcomp_code,  pformname,  puserid,  pentry_date,  pdateformat,  pextra1,  pextra2);
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
       
        
     /*  
       
               if(document.getElementById('txttilldate')!="")
        {
        var  pentry_date= document.getElementById('txttilldate').value;
    
        res=Booking_Audit1.fetch_date_data(pcomp_code,  pformname,  puserid,  pentry_date,  pdateformat,  pextra1,  pextra2);
        ds=res.value;
           if(ds.Tables[0].Rows[0].CHKDATE=="N")
        {
        alert('please choose the correct To  Date');
        document.getElementById('txttilldate').value="";
       document.getElementById('txttilldate').focus();
        return false;
        }
        }*/
       
  
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
	Booking_Audit1.selected(bookingid,clientid,call_grid_sel);
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
    document.getElementById('txtdiscountamt').disabled=false;
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
function display() {
    if (document.getElementById('hiddenagency').value != "0") {
        document.getElementById('txtagency').disabled = true;
    }
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
    window.open("OPENAUDITPREVIEW.aspx?cioid="+document.getElementById('hiddenbookingid').value+"&uomdesc="+document.getElementById('hiddenuomdesc').value,'');
   return false;
}
function bindQBC()
{
//Booking_Audit1.fillQBC(document.getElementById('drprevenu').value,bindQBC_callback);
var userid=document.getElementById("hiddenuserid").value;
Booking_Audit1.fillQBC(userid,bindQBC_callback);
}
function bindQBC_callback(response)
{
    //alert(response.value);
    var ds=response.value;
   // agcatby = 
   var pkgitem = document.getElementById("drpbranch");
 pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Branch--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    //var j=1;
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].BRANCH_CODE);
        
         if(ds.Tables[0].Rows[i].BRANCH_CODE==document.getElementById('hdnbranch').value)
        {
                pkgitem.options[pkgitem.options.length-1].selected=true;
               // $('drpbranch').options[i].selected=true;
        }
        
        
        
        
       pkgitem.options.length;
    }
    }
}
function cleardata()
{
        document.getElementById('txttilldate').value="";
		document.getElementById('txtvalidityfrom').value="";
		document.getElementById('drpadtype').value="0";
		document.getElementById('drprevenu').value="All";
		document.getElementById('drpbranch').options.length="0";
		document.getElementById('drpaudit').value="0";
		document.getElementById('drprate').value = "0";
		document.getElementById('txtsgst').value = "";
		document.getElementById('txtigst').value = "";
		document.getElementById('txtcgst').value = "";
//		if(document.getElementById('btnbookingaudit')!=null)
//		    document.getElementById('btnbookingaudit').style.visibility="hidden";
		if(document.getElementById("DataGrid1")!=null)
	    document.getElementById("DataGrid1").outerHTML="";
	    clear_button();
    return false;
		
}
function bookingaudit2()
{



var hiddenserverip=document.getElementById('hiddenserverip').value

var userid=document.getElementById('hiddenuserid').value


    if(document.getElementById("DataGrid1")==null)
    return false;
    str=document.getElementById("DataGrid1");
    var booking_id="";
    var chk_booking_id="";
    var chk_box="0";
        for(var i=0;i<document.getElementById("DataGrid1").rows.length-1;i++)
            {
                var chkid="chk" + i;
                booking_id="";
                if(document.getElementById(chkid).checked==true)
                    {
                        chk_box="1";
                        booking_id = document.getElementById(chkid).value;
                        Booking_Audit1.updateStatus2(booking_id,document.getElementById('hiddenusername').value,hiddenserverip,userid);
                        chk_booking_id=booking_id;
                    }
            }
            
            if(chk_box=="0")
            {
            alert("Please Check atleat one Check Box for Audit");
            return false;
            
            }
            else if(chkid !=undefined)
            alert("Booking Audit Completed Successfully");
            clear_button();
}

 function selectAll()
 {
    if(document.getElementById("checkall").checked==true)
    {
        for(var k=0;k<document.getElementById("DataGrid1").rows.length-1;k++)
        {
            var chkid="chk" + k;
            if(document.getElementById(chkid).disabled==false)
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

//function save1()

//{
//var remarks=document.getElementById('txtremarks').value;
//var cioid=document.getElementById('hiddenbookingid').value;
//if(document.getElementById('txtremarks').value=="")
//              {
//              alert("Please Enter Remarks/comments");
//              //document.getElementById('txtremarks').focus();
//              return false;
//              }
//              

//Booking_Audit1.save(remarks,cioid,call_savecomment)
//    return false;
//}



function save1()

{
var remarks="";
if(document.getElementById('txtremarks').value!="")
{
 remarks=document.getElementById('txtremarks').value;
}
else
{
 remarks=document.getElementById('txt_otherlanguage').value;
 //remarks=remarks+"~";
}
var cioid=document.getElementById('hiddenbookingid').value;
if(document.getElementById('txtremarks').value=="" && document.getElementById('txt_otherlanguage').value=="")
              {
              alert("Please Enter Remarks/comments");
              //document.getElementById('txtremarks').focus();
              return false;
              }
              

Booking_Audit1.save(remarks,cioid,call_savecomment)
    return false;
}






function call_savecomment(response)
{
  var ds=response.value;
  alert("Auditor Comments save Successfully")
    return false;
}







function fetch_categary()
{
 document.getElementById("hdnexecutivetxt").value=document.getElementById("drprate").value;
}

function fetch_package()
{
 document.getElementById("hdn_package").value=document.getElementById("drppackage").value;
}
function fetch_uom()
{
 document.getElementById("hdn_uom").value=document.getElementById("drpuom").value;
}

////////////
function bindcategory_package()
{
binduomname();
bindcategory();
bindpackage();
}

function binduomname()
{
    var comp_code=document.getElementById('hiddencompcode').value;
    var resuom=Booking_Audit1.binduom(comp_code,document.getElementById('drpadtype').value);
    binduom_NEW(resuom);
}
function binduom_NEW(response)
{
    var ds=response.value;
    agcatby = document.getElementById("drpuom");
    agcatby.options.length = 1; 
    //    agcatby.options[0]=new Option("--Select Category--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var j=1;
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Uom_Name,ds.Tables[0].Rows[i].Uom_Code); 
           j++;
           
        }
    }
//document.getElementById("drprate").value = "0";
}

function bindcategory()
{
 var comp_code=document.getElementById('hiddencompcode').value;
Booking_Audit1.getcategory(comp_code,document.getElementById('drpadtype').value,bindcategory_NEW);
}
function bindcategory_NEW(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("drprate");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Category--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    var j=1;
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code,ds.Tables[0].Rows[i].Adv_Cat_Code);   
                             //new Option(ds_AccName.Tables[0].Rows[i].Exec_name+"("+ds_AccName.Tables[0].Rows[i].Exe_no+")",ds_AccName.Tables[0].Rows[i].Exe_no);        
        
       j++;
       
    }
}
//return false;
document.getElementById("drprate").value = "0";
}


function bindpackage()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('drpadtype').value;
Booking_Audit1.bindpackagenew(adtype1,compcode,call_bindpackage);
//billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
}
function call_bindpackage(response)
{
ds= response.value;
    var brand=document.getElementById('drppackage');
    brand.options.length=0;
    brand.options[0]=new Option("--Select Package--");
    document.getElementById("drppackage").options.length = 1;
   
if(ds.Tables[0].Rows.length!=null)
{

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name,ds.Tables[0].Rows[i].Combin_Code);
                brand.options.length;   
             }
 }        
 }
       return false;
}




function FOCUS_FIRST()
{
document.getElementById('drpadtype').focus();

}



function chkfld(a)
{

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
     
   else if(a.keyCode=="13" && document.activeElement.id=="drpadtype")
    {
                   if(document.getElementById('drpadtype').value=="0" || document.getElementById('drpadtype').value!="0")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('drprevenu').focus();
                                          return false;
                                         }
                           
                    }
     }




 
   else if(a.keyCode=="13" && document.activeElement.id=="drprevenu")
    {
                   if(document.getElementById('drprevenu').value=="All")                   
                   {
                   
                   if(document.getElementById('drpadtype').value!="0" )
                   {
                     document.getElementById('drprate').focus();
                                          return false;
                   }
                            
                            else
                            {          
                                      
                                      if( a.keyCode=="13")
                                         {
                                            document.getElementById('txtvalidityfrom').focus();
                                              return false;
                                         
                                       
                                         }
                                         }
                                         
                           
                    }
                    else
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
                   if(document.getElementById('drpbranch').value=="0" || document.getElementById('drpbranch').value!=""||  document.getElementById('drpbranch').value=="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                       document.getElementById('drprate').focus();
                                          return false;
                                         }
                           
                    }
                    else                    
                    {
                    document.getElementById('drprate').focus();
                                          return false;
                    
                    }
     }




  else if(a.keyCode=="13" && document.activeElement.id=="drprate")
    {
                   if(document.getElementById('drprate').value=="0" || document.getElementById('drprate').value!=""|| document.getElementById('drprate').value=="")
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
                                          document.getElementById('drpaudit').focus();
                                          return false;
                                         }
                           
                    }
     }
            
             
         
         
         
         
                    
                    else if(a.keyCode=="13" && document.activeElement.id=="drpaudit")
    {
                   if(document.getElementById('drpaudit').value=="" || document.getElementById('drpaudit').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                           document.getElementById('btnsubmit').focus();
                                          return false;
                                         }
                           
                    }
     }    
          
          
          
             
         
             
             
              
 

     
 
     
       
     
    


     
          }
}



function clear_button()
{

       document.getElementById('txtagency').value="";
          document.getElementById('txtclient').value="";
          document.getElementById('txtadsubcat2').value="";
          document.getElementById('txtcardrate').value="";
          document.getElementById('txtagreedamount').value="";
          document.getElementById('txtretainername').value="";
          document.getElementById('txtpaymode').value="";
          document.getElementById('txtaddagecomm').value="";
          document.getElementById('txtpageposition').value="";
          document.getElementById('txtrono').value="";
          document.getElementById('txtrostatus').value="";
          document.getElementById('txtgrossamt').value="";
          document.getElementById('txtspecialcharge').value="";
          document.getElementById('txtexecutivename').value="";
          document.getElementById('txtbookingtype').value="";
          document.getElementById('txtoutstanding').value="";
          document.getElementById('txtadcategory').value="";
          document.getElementById('txtpositionpre').value="";
          document.getElementById('txtarea').value="";
          document.getElementById('txtretainercommission').value="";
          document.getElementById('txtuom').value="";
          document.getElementById('txtagtradediscount').value="";
          document.getElementById('txtpositionpremium').value="";
         document.getElementById('txtadsubcat1').value="";
          document.getElementById('txtheight').value="";
          document.getElementById('txtwidth').value="";
          document.getElementById('txtpackage').value="";
          document.getElementById('txtcolourtype').value="";
          document.getElementById('txtnoofinsertion').value="";
          document.getElementById('txtpublishdate').value="";
          document.getElementById('txtcontractname').value="";
          document.getElementById('txtschemetype').value="";
          document.getElementById('txtpaid').value="";
          document.getElementById('txtcardamount').value="";
          document.getElementById('txtspecialdiscount').value="";
          document.getElementById('txtdiscount').value="";
         document.getElementById('txtagreedrate').value="";
          document.getElementById('txtlines').value="";
          document.getElementById('txtspacediscount').value="";
          document.getElementById('txtadsubcat3').value="";
          document.getElementById('txtadsubcat4').value="";
          document.getElementById('txtratecode').value="";
          document.getElementById('txtbillamount').value="";
          document.getElementById('txtremarks').value="";
          document.getElementById('txtdiscountamt').value="";
          document.getElementById('txtPagePrem').value="";
          document.getElementById('txtPagePremamt').value="";
          document.getElementById('txtpositionpremiumamt').value="";
          document.getElementById('txtspecialdiscount').value="";
          document.getElementById('txtspecialdiscountamt').value="";
           document.getElementById('txtspacediscount').value="";
           document.getElementById('txtspacediscountamt').value="";
           document.getElementById('txtSumAmt').value="";
         document.getElementById('txtretainercommissionamt').value="";
         document.getElementById('txtagtradediscountamt').value="";
         document.getElementById('txtaddagecommamt').value = "";

         document.getElementById('txtboxcharges').value = "";
         document.getElementById('txtboxcrg').value = "";
         
     }




     function ttttt(event)
{
    if (browser == "Microsoft Internet Explorer") {
        var keycode = event.keyCode
    }
    else {
        var keycode = event.which;
    }


    if (keycode == 8)  
        {
                if(document.activeElement.id=="txt_agency")
                {             

                document.getElementById('txt_agency').value = "";
                document.getElementById('hidden_agency').value = "";
                return false;
                }



                if(document.activeElement.id=="txt_client")
                {             

                document.getElementById('txt_client').value = "";
                document.getElementById('hidden_client').value = "";
                return false;
                }   
         


               if(document.activeElement.id=="txt_section")
                {             

                document.getElementById('txt_section').value = "";
                document.getElementById('hidden_section').value = "";
                return false;
                }   


      }

    
    
        
        if(keycode==27)  
        {
          document.getElementById("divclient").style.display="none";
          document.getElementById("divagency").style.display="none";
           document.getElementById("divsection").style.display="none";
         
         
        }
       
        if(keycode==113)  
         {
         
                    if(document.activeElement.id=="txt_client")
                    {
                    document.getElementById("divclient").style.display="block";
                    document.getElementById('divclient').style.top=140+ "px" ;
                    document.getElementById('divclient').style.left=550+ "px";    
                   var res=  Booking_Audit1.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txt_client').value);
                    
                     document.getElementById("divclient").style.display="block";
                      var divid = "divclient";
                    //bindclientname_callback
                     var ds = res.value;
                    
                        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                        {
                        var pkgitem = document.getElementById("lstclient");
                        pkgitem.options.length = 0; 
                        pkgitem.options[0]=new Option("-Select Client-","0");
                        pkgitem.options.length = 1; 
                        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
                        {
                        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name+"~"+ds.Tables[0].Rows[i].Cust_Code,ds.Tables[0].Rows[i].Cust_Code);
                        pkgitem.options.length;
                        }
                        }
                        aTag = eval(document.getElementById('txt_client'))
                        var btag;
                        var leftpos = 0;
                        var toppos = 0;
                        do {
                        aTag = eval(aTag.offsetParent);
                        leftpos += aTag.offsetLeft;
                        toppos += aTag.offsetTop;
                        btag = eval(aTag)
                        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                        var tot = document.getElementById('divclient').scrollLeft;
                        var scrolltop = document.getElementById('divclient').scrollTop;
                        document.getElementById(divid).style.left = document.getElementById('txt_client').offsetLeft + leftpos - tot + "px";
                        document.getElementById(divid).style.top = document.getElementById('txt_client').offsetTop + toppos - scrolltop + "px"; //"510px";
                        //document.getElementById(activeid).style.backgroundColor="#FFFF80";
                        document.getElementById(divid).style.display = "block";

                        document.getElementById("lstclient").value="0";
                        document.getElementById("txt_client").value="";
                        document.getElementById("lstclient").focus();
                        return false;
                    }



                    if(document.activeElement.id=="txt_agency")
                    {




                    document.getElementById('divagency').value="";
                    var compcode = document.getElementById('hiddencompcode').value;
                    document.getElementById("divagency").style.display="block";
                    document.getElementById('divagency').style.top=140+ "px" ;
                    document.getElementById('divagency').style.left=450+ "px";
                    var dateformat = "'dd/mm/yyyy'";
                    document.getElementById('divagency').focus();      
                    var txtagency1=(document.getElementById('txt_agency').value).toUpperCase();   
                    Booking_Audit1.bindagencyname(compcode,txtagency1,bindagencyname_callback);

                    }
                    
                    if(document.activeElement.id=="txt_section")
                    {
                    
                      document.getElementById("divsection").style.display="block";
                      var divid = "divsection";   
                    var res=Booking_Audit1.section_name(document.getElementById('txt_section').value);
                     var ds = res.value;
                    
                        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                        {
                        var pkgitem = document.getElementById("lstsection");
                        pkgitem.options.length = 0; 
                        pkgitem.options[0]=new Option("-Select Section-","0");
                        pkgitem.options.length = 1; 
                        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
                        {
                        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME+"~"+ds.Tables[0].Rows[i].CODE,ds.Tables[0].Rows[i].CODE);
                        pkgitem.options.length;
                        }
                        }
                        aTag = eval(document.getElementById('txt_section'))
                        var btag;
                        var leftpos = 0;
                        var toppos = 0;
                        do {
                        aTag = eval(aTag.offsetParent);
                        leftpos += aTag.offsetLeft;
                        toppos += aTag.offsetTop;
                        btag = eval(aTag)
                        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                        var tot = document.getElementById('divsection').scrollLeft;
                        var scrolltop = document.getElementById('divsection').scrollTop;
                        document.getElementById(divid).style.left = document.getElementById('txt_section').offsetLeft + leftpos - tot + "px";
                        document.getElementById(divid).style.top = document.getElementById('txt_section').offsetTop + toppos - scrolltop + "px"; //"510px";
                        //document.getElementById(activeid).style.backgroundColor="#FFFF80";
                        document.getElementById(divid).style.display = "block";

                        document.getElementById("lstsection").value="0";
                        document.getElementById("txt_section").value="";
                        document.getElementById("lstsection").focus();
                        return false;
                    }


              
              
                
             
            }
            
            
            
            
            
            
            
            
            ////////
            
            
             if(keycode==9)  
        {
        
        
        
        
        
            if(document.activeElement.id=="lstclient")
            {

            insertclient();
            document.getElementById("dpbill").focus();
            return false;
            }       
        
        
            
            
            
            if(document.activeElement.id=="ListBox1")
            {

            insertagency( document.getElementById('ListBox1').value);
            document.getElementById("drpbillstatus").focus();
            return false;

            }
         
        }
        
        if(keycode==13)
        {
        
        
        
            if(document.activeElement.id=="lstclient")
            {

            insertclient();
            document.getElementById("drpaudit").focus();
            return false;
            }       
        
        
            
            
            
            if(document.activeElement.id=="lstagency")
            {

            insertagency( document.getElementById('lstagency').value);
            document.getElementById("txt_client").focus();
            return false;

            }
        
          if(document.activeElement.id=="lstsection")
            {

            insertagency( document.getElementById('lstsection').value);
            document.getElementById("txt_agency").focus();
            return false;

            }
        
        
        
            if(a.keyCode=="13" && document.activeElement.id=="drpadtype")
            {
            if(document.getElementById('drpadtype').value=="0" || document.getElementById('drpadtype').value!="0")
            {
                          if( a.keyCode=="13")
                             {
                              document.getElementById('drprevenu').focus();
                              return false;
                             }
               
            }
            }




 
            else if(a.keyCode=="13" && document.activeElement.id=="drprevenu")
            {
               if(document.getElementById('drprevenu').value=="All")                   
               {
               
               if(document.getElementById('drpadtype').value!="0" )
               {
                 
                 document.getElementById('drprate').focus();
                                      return false;
               }
                        
                        else
                        {          
                                  
                                  if( a.keyCode=="13")
                                     {
                                        document.getElementById('txtvalidityfrom').focus();
                                          return false;
                                     
                                   
                                     }
                                     }
                                     
                       
                }
                else
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
                   if(document.getElementById('drpbranch').value=="0" || document.getElementById('drpbranch').value!=""||  document.getElementById('drpbranch').value=="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                       document.getElementById('drprate').focus();
                                          return false;
                                         }
                           
                    }
                    else                    
                    {
                    document.getElementById('drprate').focus();
                                          return false;
                    
                    }
     }




  else if(a.keyCode=="13" && document.activeElement.id=="drprate")
    {
                   if(document.getElementById('drprate').value=="0" || document.getElementById('drprate').value!=""|| document.getElementById('drprate').value=="")
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
                                          document.getElementById('txt_agency').focus();
                                          return false;
                                         }
                           
                    }
     }
            
             
         
        
//        
//                        else if(a.keyCode=="13" && document.activeElement.id=="txt_section")
//    {
//                   if(document.getElementById('txt_section').value=="" || document.getElementById('txt_section').value!="")
//                   {
//                                      if( a.keyCode=="13")
//                                         {
//                                          document.getElementById('txt_agency').focus();
//                                          return false;
//                                         }
//                           
//                    }
//     }
         
          
          
                               else if(a.keyCode=="13" && document.activeElement.id=="txt_agency")
    {
                   if(document.getElementById('txt_agency').value=="" || document.getElementById('txt_agency').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('txt_client').focus();
                                          return false;
                                         }
                           
                    }
     }   
         
         
                                      else if(a.keyCode=="13" && document.activeElement.id=="txt_client")
    {
                   if(document.getElementById('txt_client').value=="" || document.getElementById('txt_client').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          document.getElementById('drpaudit').focus();
                                          return false;
                                         }
                           
                    }
     } 
         

else if(a.keyCode=="13" && document.activeElement.id=="drpaudit")
{
    if(document.getElementById('drpaudit').value=="" || document.getElementById('drpaudit').value!="")
    {
        if( a.keyCode=="13")
        {
        document.getElementById('drppackage').focus();
        return false;
        }

    }
} 
         
                    
        else if(a.keyCode=="13" && document.activeElement.id=="drppackage")
        {
        if(document.getElementById('drppackage').value=="" || document.getElementById('drppackage').value!="")
        {
                      if( a.keyCode=="13")
                         {
                           document.getElementById('btnsubmit').focus();
                          return false;
                         }
           
        }
        }    
          
          
          
             
        
          
        
        }
}



var agencycodeglo;



function bindagencyname_callback(res)
{
   
        
        ds =res.value;
        document.getElementById("lstagency").innerHTML = "";
        var divid = "divagency";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Agency Name-","0");
        pkgitem.options.length = 1; 
        
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
       pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+"~"+ds.Tables[0].Rows[i].code_subcode,ds.Tables[0].Rows[i].code_subcode);        
                pkgitem.options.length;
            }







        }
        aTag = eval(document.getElementById('txt_agency'))
        var btag;
        var leftpos = 0;
        var toppos = 0;
        do {
            aTag = eval(aTag.offsetParent);
            leftpos += aTag.offsetLeft;
            toppos += aTag.offsetTop;
            btag = eval(aTag)
        } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
        var tot = document.getElementById('divagency').scrollLeft;
        var scrolltop = document.getElementById('divagency').scrollTop;
        document.getElementById(divid).style.left = document.getElementById('txt_agency').offsetLeft + leftpos - tot + "px";
        document.getElementById(divid).style.top = document.getElementById('txt_agency').offsetTop + toppos - scrolltop + "px"; //"510px";
        //document.getElementById(activeid).style.backgroundColor="#FFFF80";
        document.getElementById(divid).style.display = "block";
    
    
    
    
    
    
    
        document.getElementById("lstagency").focus();
        
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
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name+"~"+ds.Tables[0].Rows[i].Cust_Code,ds.Tables[0].Rows[i].Cust_Code);
        
       pkgitem.options.length;
       
    }
    
    }
    document.getElementById('txt_client').value="";
    document.getElementById("lstclient").value="0";
   document.getElementById("lstclient").focus();
    
     return false;
}







////////////////this function is called when we open the list box of agency than on mouse click it get the agency
/*change*/
function insertclient()
{
//    if (browser == "Microsoft Internet Explorer") {
//        var keycode = event.keyCode
//    }
//    else {
//        var keycode = event.which;
//    }

    
     if(document.activeElement.id=="lstclient")
        {
       if(document.getElementById('lstclient').value=="0")
        {
        alert("Please select the Client");
        return false;
        }
        document.getElementById("divclient").style.display="none";
        var page=document.getElementById('lstclient').value;
        agencycodeglo = page;

   
         for(var k=0;k <= document.getElementById("lstclient").length-1;k++)
                {
                   if(document.getElementById('lstclient').options[k].value==page) {
                   
                       if (browser == "Microsoft Internet Explorer") {
                         
                           var abc = document.getElementById('lstclient').options[k].innerText;
                   
                       }
                       else {


                       
                           var abc = document.getElementById('lstclient').options[k].textContent;
                         
                       }
                    
                  
                    var splitpub = abc;
                    var str = splitpub.split("~");
                    abc=str[0];
                    xyz=str[1];
                    var abc2 = str[0];
                    document.getElementById('txt_client').value=abc;
                    document.getElementById('hidden_client').value = xyz;
                  
                    
                    return false;           
                    }
                }
              }
      
    


}	


function insertagency(mycityval) {

 
   
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
                for(var k=0;k <= document.getElementById("lstagency").length-1;k++) {



                    if (document.getElementById('lstagency').options[k].value == page) {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                        var allvalues = document.getElementById('lstagency').options[k].value;

                        var splitvalue = abc;
                        var fival = abc.split("~");
                        cityval = fival[0];
                        distval = fival[1];
                        // var getvalue=distval.substring(0,distval.length-1) 
                        document.getElementById('txt_agency').value = cityval;
                        document.getElementById('hidden_agency').value = distval;




                    }
                
//                    var abc=document.getElementById('lstagency').options[k].textContent;
//                    if(document.getElementById('lstagency').options[k].value==page)
//                    {
//                    document.getElementById('lstagency').value=abc;
//                    break;
//                    }
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
                                
                                var splitvalue= abc;
                                var fival = abc.split("~");
                                cityval  =  fival[0];
                                distval  =  fival[1];
                               // var getvalue=distval.substring(0,distval.length-1) 
                                document.getElementById('txt_agency').value=cityval;               
                                document.getElementById('hidden_agency').value=distval;
                
                    

           
                    }
                }
            }
            document.getElementById("divagency").style.display='none';

            return false;
            }
            
            
            
            
            if(document.activeElement.id=="lstsection")
        {
            if(document.getElementById('lstsection').value=="0")
            {
            alert("Please select Section");
            return false;
            }
                   
            var page=document.getElementById('lstsection').value;
            agencycodeglo=page;
            if(browser!="Microsoft Internet Explorer")
            {
                for(var k=0;k <= document.getElementById("lstsection").length-1;k++)
                {
                    var abc=document.getElementById('lstsection').options[k].innerHTML;
                    if(document.getElementById('lstsection').options[k].value==page)
                    {
                    document.getElementById('lstsection').value=abc;
                    break;
                    }
                }
            }
            else
            {
                for(var k=0;k <= document.getElementById("lstsection").length-1;k++)
                {

          
                    if(document.getElementById('lstsection').options[k].value==page)
                    {
                                var abc=document.getElementById('lstsection').options[k].innerText;
                                var allvalues=document.getElementById('lstsection').options[k].value;
                              
                                var splitvalue= abc;
                                var fival = abc.split("~");
                                cityval  =  fival[0];
                                distval  =  fival[1];
                                var getvalue=distval;
                                  document.getElementById('txt_section').value=cityval;              
                                document.getElementById('hidden_section').value=getvalue;
                
                    

           
                    }
                }
            }
            document.getElementById("divsection").style.display='none';

            return false;
            }
     
     
 

	}
function openattach1(code)
{
//if(document.getElementById('LinkButton1').disabled==false)
document.getElementById('hidattach1').value=code;
 window.open("ApprovalAttachment/" + document.getElementById('hidattach1').value,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210width='+screen.availWidth+',height='+screen.availHeight+'');
   // window.open('approvalAttachment.aspx?filename='+document.getElementById('hidattach1').value,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
     return false;
}
 function exitclick() {
     if (confirm("Do you want to skip this page.")) {

         window.close();
         return false;
     }
     return false;


 }
 
 function checklenthnew()
{
if(document.getElementById('hidden1').value=="0")
{
alert('Seaching criteria does not produce any result');
return false;
}


}

function openattach11(code) {
    //if(document.getElementById('LinkButton1').disabled==false)
    document.getElementById('hidattach11').value = code;
    window.open("ApprovalAttachment/" + document.getElementById('hidattach11').value, 'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210width=' + screen.availWidth + ',height=' + screen.availHeight + '');
    // window.open('approvalAttachment.aspx?filename='+document.getElementById('hidattach1').value,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
    return false;
}