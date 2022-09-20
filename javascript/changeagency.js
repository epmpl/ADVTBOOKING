
var browser = navigator.appName;
function executeclick()
{


adtype= document.getElementById('hiddenusername').value
cioid=document.getElementById('txt_refno').value

  Changeagency.execute(cioid,document.getElementById('hiddencompcode').value,adtype,document.getElementById('hiddendateformat').value,exec_callback);   
 // Changeagency.execute(cioid,document.getElementById('hiddencompcode').value,exec_callback);     


return false;
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
              ///  document.getElementById('txtallert').value="";
            }
            else
            
            
            { 
               var    bookid= document.getElementById('txt_refno').value
            var res= Changeagency.getagencyRemark(document.getElementById('hiddencompcode').value,bookid,ds.Tables[0].Rows[0].Agency_code,"","A");
            if (res.value != null)
                if (res.value.Tables[0].Rows.length > 0) {
            }
            // document.getElementById('txtallert').value= res.value.Tables[0].Rows[0].REMARK;
            else {
                // document.getElementById('txtallert').value="";
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
                        var ds_pkg=Changeagency.getPackageName(document.getElementById('hiddencompcode').value,s1[k_]);
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
                    var ds_pkg=Changeagency.getPackageName(document.getElementById('hiddencompcode').value,ds.Tables[0].Rows[0].Package_code);
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
//                document.getElementById('txtremarks').value=""
//                document.getElementById('txt_otherlanguage').value="";
            }
            else
            {
              var remark_execute=ds.Tables[0].Rows[0].remarks;
              if(remark_execute.indexOf('~') != -1)
              {
              //  document.getElementById('txt_otherlanguage').value=ds.Tables[0].Rows[0].remarks;
              }
             else
               {            
             //   document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
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

        }
    } 
  
}




function f2query(event) {
    if ( agnf2 == "Y" &&  event.keyCode != 113) {
        if (document.activeElement.id == "txt_agency") {
           if (document.getElementById('txt_agency').value == "") {
                if (document.getElementById("div1").style.display == "block") {
                    document.getElementById("div1").style.display = "none"
                    document.getElementById('txt_agency').focus();
                    return false;
                }
                return false;
            }
            if (event.keyCode == 40) {
                document.getElementById("lstagency").focus();
                return false;
            }
            if (document.getElementById("div1").style.display == "none") {
                document.getElementById("div1").style.display = "block";
                aTag = eval(document.getElementById("txt_agency"))
                var btag;
                var leftpos = 0;
                var toppos = 0;
                do {
                    aTag = eval(aTag.offsetParent);
                    leftpos += aTag.offsetLeft;
                    toppos += aTag.offsetTop;
                    btag = eval(aTag)
                } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                document.getElementById('div1').style.top = document.getElementById("txt_agency").offsetTop + (toppos + 15) + "px";
                document.getElementById('div1').style.left = document.getElementById("txt_agency").offsetLeft + leftpos + "px";
            }
            /*if(browser!="Microsoft Internet Explorer")
            {
            document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/
            (-20) + "px";
            
            Changeagency.bindagencyname(document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, document.getElementById('txt_agency').value, "Y", bindagencyname_callback);

        }
        else if (document.activeElement.id == "txtclient") {
           if (clientfromconfig == "UD") {
                if (document.getElementById('txtclient').value != "" && document.getElementById('drpregular').value == "0") {
                    document.getElementById('txtclient').value = "";
                    alert("Please select Client Type");
                    document.getElementById('drpregular').focus();
                    return false;
                }
                if (document.getElementById('drpregular').value == "NRC" || document.getElementById('drpregular').value == "TBRC") {
                    return false;
                }
            }
           
            if (document.getElementById('txtclient').value == "") {
                if (document.getElementById("divclient").style.display == "block") {
                    document.getElementById("divclient").style.display = "none"
                    document.getElementById('txtclient').focus();
                    return false;
                }
                return false;
            }
            if (event.keyCode == 40) {
                document.getElementById("lstclient").focus();
                return false;
            }
            else if (event.keyCode == 27) {
                if (document.getElementById("divclient").style.display == "block") {
                    document.getElementById("divclient").style.display = "none"
                    document.getElementById('txtclient').value = "";
                    document.getElementById('txtclient').focus();
                }
                return false;
            }

            document.getElementById("divclient").style.display = "block";
            aTag = eval(document.getElementById("txtclient"))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            document.getElementById('divclient').style.top = document.getElementById("txtclient").offsetTop + (toppos + 15) + "px";
            document.getElementById('divclient').style.left = document.getElementById("txtclient").offsetLeft + leftpos + "px";
            Booking_master.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtclient').value, "Y", bindclientname_callback);
        }
    }
}


function bindagencyname_callback(response) {
    ds = response.value;
    if (ds == null) {
        alert(response.error.description);
        return false;
    }
    //   document.getElementById('drpretainer').value="";
    var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select Agency-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        //alert(pkgitem.options.length);
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name, ds.Tables[0].Rows[i].Agency_Code + '+' + ds.Tables[0].Rows[i].code_subcode);
            pkgitem.options.length;
        }
    }
    if (agnf2 != "Y") {
        document.getElementById('txt_agency').value = "";

        document.getElementById("lstagency").focus();
    }
    document.getElementById("lstagency").value = "0";
    return false;
}

function insertagency(event) {
 
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstagency")
        {
        if(document.getElementById('lstagency').value=="0")
            {
                 alert("Please select Agency Name");
                 return false;
            }
            
            var page = document.getElementById('lstagency').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstagency').length-1;k++)
            {
                if (document.getElementById('lstagency').options[k].value == page) {

                   
                    if (browser != "Microsoft Internet Explorer") {
                        
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('txt_agency').value = abc;
                    //document.getElementById('hdnagencytxt').value =abc;
                    document.getElementById('hdncode').value = page.split('+')[0];
                    document.getElementById('hdncodesubcode').value = page.split('+')[1];
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txt_agency').focus();
                     return false; 
                    
                }
            }
        }
      }
      else if (key == 27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }

    
    function updateclick()
    {


        if (document.getElementById("txt_refno").value == "") {
            alert("Please fill Correct Booking id,Refrence No,Ro No ")
        }

        var compcode = document.getElementById("hiddencompcode").value;
        var agencycode = document.getElementById("hdncode").value;
        var agencysubcode = document.getElementById("hdncodesubcode").value;
        var id = document.getElementById("txt_refno").value;

        var res = Changeagency.updateagency(compcode, agencycode, agencysubcode, id);

        if (res.error == null) {
        
        alert("Agency Updated Successfully")
        }

        return false;

    }
    
    
    function exit()
    {
    
   
    if(confirm("Do You Want To Skip This Page"))
	{
	window.location.href='Default.aspx';
	//window.close();
	return false;
	}
	return false;
    }