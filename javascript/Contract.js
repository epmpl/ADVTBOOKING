
// JScript File
var arrlist;
var regclient="";
 var browser=navigator.appName;
var rownumEx;
var executequery;
var mode="";
var FlagStatus;
var ddealcode, dagencycode, dsubagency, dclient, dproduct, dreprest,ddealtype,ddealname;
var idcode="";
var curr;
var popUpWin;
var cou=0;
var dateformat,compcode,userid;
var fpnl,saveormodify,chkquery,saving;
var formname="ContractMaster";
var validfromdate, validtill, message, numberDiv;
var centercodemod="";
var edinsert="0";	
var dealno="";
//var gbchkperiod;
//var lchk=0;
//var kchk=0;
var popwin1;
var htext;
function saveInSessionPrint(i)
{
   var str="";
    if(browser!="Microsoft Internet Explorer")
        {
           str=document.getElementById('tblGrid').rows[i+1].cells[0].textContent; 
           str=txtOld;   
        }
        else{
            str=document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML;    
        }    
if(str.indexOf("value=")>=0)
{
    str=document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML.substring(document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML.indexOf("value="),document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML.indexOf(">"));
    str=str.replace("value=","");
}
str=str + "~"+document.getElementById('tblGrid').rows[i+1].cells[1].innerHTML;     
str=str + "~"+ document.getElementById('tblGrid').rows[i+1].cells[2].innerHTML;     
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[3].innerHTML;     
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[4].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[6].innerHTML;        
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[5].innerHTML;      
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[7].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[8].innerHTML;        
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[9].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[10].innerHTML;        
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[11].innerHTML;     
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[12].innerHTML;     
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[13].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[14].innerHTML;        
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[15].innerHTML;     
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[16].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[17].innerHTML;        
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[18].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[19].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[20].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[21].innerHTML;        
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[22].innerHTML;     
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[23].innerHTML;      
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[24].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[25].innerHTML;         
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[26].innerHTML;        
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[27].innerHTML;       
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[28].innerHTML;       
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[29].innerHTML;       
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[30].innerHTML;        
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[31].innerHTML;    
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[33].innerHTML;
str=str +  "~"+document.getElementById('tblGrid').rows[i+1].cells[34].innerHTML;        
str=str.replace("&amp;","&");   
str=str.replace("&AMP;","&");  
ContractMaster.saveRowInSession(str);

}
function saveInSession(i){
   var str="";
    if(browser!="Microsoft Internet Explorer")
    {
//    str=document.getElementById('tblGrid').rows[i+1].cells[0].textContent; 
//     alert(str);
    str=txtOld; 
   //  alert(str);  
    }
    else{
    str=document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML;    
    }    
   
    if(str.indexOf("value=")>=0)
    {
    str=document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML.substring(document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML.indexOf("value="),document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML.indexOf(">"));
    str=str.replace("value=","");
    }
             str=str + "~"+document.getElementById('tblGridelec').rows[i+1].cells[1].innerHTML;     
str=str + "~"+ document.getElementById('tblGridelec').rows[i+1].cells[2].innerHTML;     
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[3].innerHTML;     
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[4].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[6].innerHTML;        
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[5].innerHTML;      
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[7].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[8].innerHTML;        
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[9].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[10].innerHTML;        
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[11].innerHTML;     
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[12].innerHTML;     
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[13].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[14].innerHTML;        
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[15].innerHTML;     
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[16].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[17].innerHTML;        
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[18].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[19].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[20].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[21].innerHTML;        
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[22].innerHTML;     
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[23].innerHTML;      
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[24].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[25].innerHTML;         
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[26].innerHTML;        
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[27].innerHTML;       
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[28].innerHTML;       
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[29].innerHTML;       
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[30].innerHTML;        
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[31].innerHTML;       

str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[32].innerHTML;      
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[33].innerHTML;     
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[34].innerHTML;     
str=str + "~"+ document.getElementById('tblGridelec').rows[i+1].cells[35].innerHTML;      
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[36].innerHTML;     
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[37].innerHTML;    
str=str + "~"+ document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML;   
str=str +  "~"+document.getElementById('tblGridelec').rows[i+1].cells[40].innerHTML;    
str=str + "~"+ document.getElementById('tblGridelec').rows[i+1].cells[42].innerHTML;     
str=str + "~"+ document.getElementById('tblGridelec').rows[i+1].cells[43].innerHTML;    
 ContractMaster.saveRowInSession(str);
 }
function openElecPopUp()
{
    if(document.getElementById('drpdealon').value=="elec")
    {
        openElectronics();
        activeRow=1;
        var Return;
         var agcode="";
       if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
            agcode=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
       var subagencycode = document.getElementById('drpsubagcode').value;  
       var seqno=document.getElementById('tblGridelec').rows[activeRow].cells[41].innerHTML;   
       if(seqno.indexOf("<INPUT")>=0)
        seqno="";
       var consumed=document.getElementById('tblGridelec').rows[activeRow].cells[37].innerHTML;
       var balance=document.getElementById('tblGridelec').rows[activeRow].cells[38].innerHTML
       saveInSession(activeRow-1);
       Return = window.showModalDialog("contractChild.aspx?contdate="+document.getElementById('txtcontractdate').value+"&rcptcurr="+document.getElementById('drprptcurrency').value+"&balance="+balance+"&consumed="+consumed+"&seqno="+seqno+"&dealno="+document.getElementById('txtdealno').value+"&validto="+document.getElementById('TextBox1').value+"&validfrom="+document.getElementById('txtfromdate').value+"&agsubcode="+subagencycode+"&agcode="+agcode+"&mode="+mode,"","dialogWidth:1100px; dialogHeight:350px;resizable: yes");
      //  document.getElementById('txtremark').value = Return.remarks;
        //alert(Return);
        
        if(Return!=null)
        {
            binddatainGrid(Return);
            
            //arrlist[activeRow-1]=Return;
        }
       
        return false;

    }
    if (document.getElementById('drpdealon').value == "print") {
       
        openprint();
        activeRow = 1;
        saveInSessionPrint(activeRow-1);
     //  Return = window.showModalDialog("contractchildprint.aspx?contdate=" + document.getElementById('txtcontractdate').value + "&dealno=" + document.getElementById('txtdealno').value + "&validto=" + document.getElementById('TextBox1').value + "&validfrom=" + document.getElementById('txtfromdate').value + "&mode=" + mode+"&agencycod=" + document.getElementById('hdnagency').value+"&clientcod=" + document.getElementById('hdnclientcod').value, "", "dialogWidth:1100px; dialogHeight:350px;resizable: yes");
        Return = window.showModalDialog("contractchildprint.aspx?contdate=" + document.getElementById('txtcontractdate').value + "&dealno=" + document.getElementById('txtdealno').value + "&validto=" + document.getElementById('TextBox1').value+"&agnsubcod=" + document.getElementById('drpsubagcode').value + "&validfrom=" + document.getElementById('txtfromdate').value + "&mode=" + mode+"&agencycod=" + document.getElementById('hdnagency').value+"&clientcod=" + document.getElementById('hdnclientcod').value, "", "dialogWidth:1100px; dialogHeight:350px;resizable: yes");


        //  document.getElementById('txtremark').value = Return.remarks;
        //alert(Return);
        if (Return != null) {
            binddatainGridprint(Return);
        }
        return false;

    }
}
function bindIndusProduct()
{
    document.getElementById('lstproduct').options.length=0;
    document.getElementById('lstproduct').options[0]=new Option("--Select Product--","0");
    var res=ContractMaster.bindProduct_A(document.getElementById('hiddencompcode').value,document.getElementById('drpindustry').value);
    var ds=res.value;
      if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                document.getElementById('lstproduct').options[document.getElementById('lstproduct').options.length] = new Option(ds.Tables[0].Rows[i].prod_desc,ds.Tables[0].Rows[i].prod_cat_code);
                document.getElementById('lstproduct').options.length;   
            }
        }
    } 
}
function bindFields()
{
    document.getElementById('drppackagecode').options.length=0;
    document.getElementById('drppackagecode').options[0]=new Option("--Select Package--","0");
   document.getElementById('drpbooked').value='';
    document.getElementById('drpadvcat').options.length=0;
    document.getElementById('drpadvcat').options[0]=new Option("--Select AdCategory--","0");
    
     document.getElementById('drpuom').options.length=0;
    document.getElementById('drpuom').options[0]=new Option("--Select Uom--","0");
    
    document.getElementById('drppremium').options.length=0;
    document.getElementById('drppremium').options[0]=new Option("--Select Premium--","0");
    
    var res=ContractDetail.bindadvcategory_A(document.getElementById('drpadtype').value,document.getElementById('hiddencompcode').value);
    var ds=res.value;
     if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                document.getElementById('drpadvcat').options[document.getElementById('drpadvcat').options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                document.getElementById('drpadvcat').options.length;   
            }
        }
    } 
    ds=null;
    res=ContractDetail.bindpackage_A(document.getElementById('hiddencompcode').value,document.getElementById('drpadtype').value) ;
    ds=res.value;
         if(ds!=null)
    {
        if(ds.Tables[1].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[1].Rows.length; ++i)
            {
                document.getElementById('drppackagecode').options[document.getElementById('drppackagecode').options.length] = new Option(ds.Tables[1].Rows[i].Package_Name,ds.Tables[1].Rows[i].Combin_Code);
                document.getElementById('drppackagecode').options.length;   
            }
        }
    } 
    
      ds=null;
    res=ContractDetail.binduom_A(document.getElementById('hiddencompcode').value,document.getElementById('drpadtype').value,document.getElementById('hiddenuserid').value) ;
    ds=res.value;
         if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                document.getElementById('drpuom').options[document.getElementById('drpuom').options.length] = new Option(ds.Tables[0].Rows[i].UOM_Name,ds.Tables[0].Rows[i].UOM_Code);
                document.getElementById('drpuom').options.length;   
            }
        }
    } 
    
       ds=null;
    res=ContractDetail.bindpremium_A(document.getElementById('hiddencompcode').value,document.getElementById('drpadtype').value) ;
    ds=res.value;
         if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                document.getElementById('drppremium').options[document.getElementById('drppremium').options.length] = new Option(ds.Tables[0].Rows[i].premiumname,ds.Tables[0].Rows[i].Premiumcode);
                document.getElementById('drppremium').options.length;   
            }
        }
    } 
}
function checksavevalidation()
{
//ContractMaster.btnSavecall(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,"CM1216",document.getElementById('hdnquation').value);
//return false;


    dateformat=document.getElementById('hiddendateformat').value;
    var fromdate=document.getElementById('txtfromdate').value;
    var todate=document.getElementById('TextBox1').value;
		//this is for from date
    if(dateformat=="dd/mm/yyyy")
    {
        if(fromdate != "")
        {
            var txt=fromdate;
            var txt1=txt.split("/");
            var dd=txt1[0];
            var mm=txt1[1];
            var yy=txt1[2];
            fromdate=mm+'/'+dd+'/'+yy;
        }
    }
    else if(dateformat=="yyyy/mm/dd")
    {
        if(fromdate!="")
        {
            var txt=fromdate;
            var txt1=txt.split("/");
            var yy=txt1[0];
            var mm=txt1[1];
            var dd=txt1[2];
            fromdate=mm+'/'+dd+'/'+yy;
        }
    }        
        
    //this is for till date

    if(dateformat=="dd/mm/yyyy")
    {
        if(todate != "")
        {
            var txt=todate;
            var txt1=txt.split("/");
            var dd=txt1[0];
            var mm=txt1[1];
            var yy=txt1[2];
            todate=mm+'/'+dd+'/'+yy;
        }
    
    }
    if(dateformat=="yyyy/mm/dd")
    {
        if(todate!="")
        {
            var txt=todate;
            var txt1=txt.split("/");
            var yy=txt1[0];
            var mm=txt1[1];
            var dd=txt1[2];
            todate=mm+'/'+dd+'/'+yy;
        }
       
    }

	var fdate=new Date(fromdate);
	var tdate=new Date(todate);

    

    if(document.getElementById('txtdealno').value=="")
    {
        if(document.getElementById('hiddendealno').value!="1")
        {
            alert("Please Enter The Contract No.");
            //document.getElementById('txtdealno').focus();
            return false;
        }
    }
    if(document.getElementById('drpdealtype').value=="0")
    {
        alert("Please Select The Contract Type");
        document.getElementById('drpdealtype').focus();
        return false;
    }

    if(document.getElementById('txtdealname').value=="")
    {
        if(document.getElementById('hiddendealname').value=="1")
        {
            alert("Please Enter The Contract Name");
            document.getElementById('txtdealname').focus();
            return false;
        }
    }

//    if(document.getElementById('drpagencycode').value=="")
//    {
//        if(document.getElementById('hiddenagcode').value=="1")
//        {
//            alert("Please Select The Agency Name");
//            document.getElementById('drpagencycode').focus();
//            return false;
//        }
//    }
//       if(document.getElementById('drpagencycode').value != "" && document.getElementById('drpagencycode').value.lastIndexOf('(')>=0)
//        {
//             var agency=document.getElementById('selectcode').value ;            
//		     var agencyarr=agency.split("(");             
//		     var agencysplit=agencyarr[1];             
//		     agencysplit=agencysplit.replace(")","");
//           }
//           else
            if((document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.lastIndexOf('(')<0))
             {
             alert("Please select correct Agency by Pressing F2");
             document.getElementById('drpagencycode').value="";
             document.getElementById('drpagencycode').focus();
             return false;
             }
              else if(document.getElementById('drpagencycode').value=="")
             {
                 if(document.getElementById('hiddenagcode').value=="1")
                 {
                 alert("Please select Agency by Pressing F2");
                // document.getElementById('selectcode').value="";
                 document.getElementById('drpagencycode').focus();
                 return false;
                }
             }
             else if(document.getElementById('drpagencycode').value=="")
             {
                 if(document.getElementById('hiddenagcode').value=="1")
                 {
                 alert("Please select Agency by Pressing F2");
                // document.getElementById('selectcode').value="";
                 document.getElementById('drpagencycode').focus();
                 return false;
                }
             }
//             if((document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.lastIndexOf('(')<0) || document.getElementById('drpclientname').value!="" && document.getElementById('drpclientname').value.lastIndexOf('(')<0)
//             {
//             alert("Please select correct Client by Pressing F2");
//             document.getElementById('drpclientname').value="";
//             document.getElementById('drpclientname').focus();
//             return false;
//             }
//             else if(document.getElementById('drpclientname').value=="" || document.getElementById('drpagencycode').value=="")
//             {
//                 if(document.getElementById('hiddenclientname').value=="1")
//                 {
//                 alert("Please select Client by Pressing F2");
//                // document.getElementById('selectcode').value="";
//                 document.getElementById('drpclientname').focus();
//                 return false;
//                }
//             }
    if(document.getElementById('drpsubagcode').value=="0" || document.getElementById('drpclientname').value=="")
    {
        if(document.getElementById('hiddensubagcode').value=="1")
        {
            alert("Please Select The Sub Agency Name");
            document.getElementById('drpsubagcode').focus();
            return false;
        }
    }

//    if(document.getElementById('drpclientname').value=="")
//    {
//        if(document.getElementById('hiddenclientname').value=="1")
//        {
//            alert("Please Select The Client Name");
//            document.getElementById('drpclientname').focus();
//            return false;
//        }
//    }


    if(document.getElementById('drpproduct').value=="0")
    {
        if(document.getElementById('hiddenproduct').value=="1")
        {
            alert("Please Select The Product");
            document.getElementById('drpproduct').focus();
            return false;
        }
    }
    var alrt;
    
     alrt=document.getElementById('lblretainer').innerText;
   
    if(alrt.indexOf('*')>=0)
    {
   
 if(document.getElementById('txtretainer').value=="")
    {
        alert("Please Enter Retainer");
        document.getElementById('txtretainer').focus();
        return false;       
    }
    }
    
      alrt=document.getElementById('lbteamname').innerText;
   
    if(alrt.indexOf('*')>=0)
    {
   
 if(document.getElementById('drpteamname').value=="0")
    {
        alert("Please Select The Team Name");
        document.getElementById('drpteamname').focus();
        return false;       
    }
    }
    
   
      alrt=document.getElementById('Representative').innerText;
   
    if(alrt.indexOf('*')>=0)
    {
   

    if(document.getElementById('drprepresentative').value=="0" ||document.getElementById('drprepresentative').value=="")
    {
        if(document.getElementById('hiddenrep').value=="1")
        {
            alert("Please Select The Representative");
            document.getElementById('drprepresentative').focus();
            return false;
        }       
    }
    }
    if(document.getElementById('txtfromdate').value=="")
    {
        if(document.getElementById('hiddenvalidfrom').value=="1")
        {
            alert("Please Enter The Valid From Date");
            document.getElementById('txtfromdate').focus();
            return false;
        }
    }

    if(document.getElementById('TextBox1').value=="")
    {
        if(document.getElementById('hiddento').value=="1")
        {
            alert("Please Enter The Valid To Date");
            document.getElementById('TextBox1').focus();
            return false;
        }               
    }
    if(fdate > tdate)
    {
        alert("Valid From Date Should Be Less Than Valid To Date");
        document.getElementById('TextBox1').value="";
        document.getElementById('TextBox1').focus();
        return false;
    }
    if(document.getElementById('txtcontractdate').value=="")
    {
            alert("Please Enter Contract Date");
            document.getElementById('txtcontractdate').focus();
            return false;
    }
//    if(document.getElementById('txtclosedate').value=="")
//    {
//            alert("Please Enter Close Date");
//            document.getElementById('txtclosedate').focus();
//            return false;
//    }
     var contdate=document.getElementById('txtcontractdate').value;
    var closedate=document.getElementById('txtclosedate').value;
		//this is for from date
    if(dateformat=="dd/mm/yyyy")
    {
        if(contdate != "")
        {
            var txt=contdate;
            var txt1=txt.split("/");
            var dd=txt1[0];
            var mm=txt1[1];
            var yy=txt1[2];
            contdate=mm+'/'+dd+'/'+yy;
        }
    }
    else if(dateformat=="yyyy/mm/dd")
    {
        if(contdate!="")
        {
            var txt=contdate;
            var txt1=txt.split("/");
            var yy=txt1[0];
            var mm=txt1[1];
            var dd=txt1[2];
            contdate=mm+'/'+dd+'/'+yy;
        }
    }        
        
    //this is for till date

    if(dateformat=="dd/mm/yyyy")
    {
        if(todate != "")
        {
            var txt=closedate;
            var txt1=txt.split("/");
            var dd=txt1[0];
            var mm=txt1[1];
            var yy=txt1[2];
            closedate=mm+'/'+dd+'/'+yy;
        }
    
    }
    if(dateformat=="yyyy/mm/dd")
    {
        if(closedate!="")
        {
            var txt=closedate;
            var txt1=txt.split("/");
            var yy=txt1[0];
            var mm=txt1[1];
            var dd=txt1[2];
            closedate=mm+'/'+dd+'/'+yy;
        }
       
    }

	var fcontdate=new Date(contdate);
	var tclosedate=new Date(closedate);
	 if(fcontdate > tclosedate)
    {
        alert("Contract Date Should Be Less Than Close Date");
        document.getElementById('txtclosedate').value="";
        document.getElementById('txtclosedate').focus();
        return false;
    }
    if(document.getElementById('txtdealvol').value=="" && document.getElementById('txtdealvalue').value=="")
    {
////        if(document.getElementById('txtdealvol').style.backgroundColor=="white" && document.getElementById('txtdealvalue').style.backgroundColor=="white")
////        {
////            alert("The deal should be in value or volume base");
////            return false;
////        }
//        if(document.getElementById('txtdealvalue').style.backgroundColor=="white")
//        {
//            alert("The deal should be in value  base");
//            document.getElementById('txtdealvalue').focus();
//            return false;
//        }
        if(document.getElementById('txtdealvol').style.backgroundColor=="white")
        {
            alert("The deal should be in volume  base");
            document.getElementById('txtdealvol').focus();
            return false;
        }
        if(document.getElementById('txtdealvol').style.backgroundColor=="white" && document.getElementById('txtdealvalue').style.backgroundColor=="white")
        {
            alert("The deal should be in value or volume base");
            return false;
        }
    }

   
    if(document.getElementById('lblpaymenttype').innerHTML.indexOf("*")>0 && (document.getElementById('drppaymenttype').value=="" || document.getElementById('drppaymenttype').value=="0") )
    {
            alert("Please Select The Payment Type");
            document.getElementById('drppaymenttype').focus();
            return false;
    }
    var res=checkGridValidations();
    if(res==false)
        return false;
    savecontract();
    
    ContractMaster.btnSavecall(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtdealno').value,document.getElementById('hdnquation').value);
    
    return false;
    
}


var popUpWin=null;
function opencontractdetails()
{
//if(document.getElementById('lbcontractdetails').disabled==false)
    if(document.getElementById('txtdealno').value!="")
    {
        var dealno=document.getElementById('txtdealno').value;
        var txtdealvalue=document.getElementById('txtdealvalue').value;
        var txtdealvol=document.getElementById('txtdealvol').value;
        var currsess=document.getElementById('drpcurr').value;
        var hiddenforpop=document.getElementById('hiddenforpop').value;
        var modifydet=document.getElementById('hiddenmodify').value;
        var adtype=document.getElementById('drpadtype').value;
        var fromdate=document.getElementById('txtfromdate').value;
        var todate=document.getElementById('TextBox1').value;
        var agency=document.getElementById('drpagencycode').value;
        var client=document.getElementById('drpclientname').value;
        var prod=document.getElementById('drpproduct').value;
        if(popUpWin && !popUpWin.closed)
        {
            popUpWin.focus();
        }
        else
        {
            if(dealno!=""  && currsess!="" )
            {
               //popUpWin = window.open('ContractDetail.aspx?dealno='+dealno+'&txtdealvalue='+txtdealvalue+'&txtdealvol='+txtdealvol+'&currsess='+currsess+'&hiddenforpop='+hiddenforpop+'&modifydet='+modifydet+'&adtype='+adtype+'&fromdate='+fromdate+'&todate='+todate+'&agency='+agency+'&client='+client+'&prod='+prod,'Ankur','resizable=0,toolbar=0,top=100,left=10,scrollbars=yes,width=1000px,height=635px'); 
               popUpWin = window.open('Deal_Detail.aspx?fromdate='+fromdate+'&todate='+todate,'detail','resizable=0,toolbar=0,top=100,left=10,scrollbars=yes,width=1000px,height=635px'); 
               popUpWin.focus();
                return false;    
            }
            else
            {
                alert("Please Enter mandatory fields");
                return false;
            }    
        }   
    }
    return false;
}

//********************************

function insertforcontract(id,code)
{
    var id=id;
    if(document.getElementById(id).checked==false)
    {
        document.getElementById(id).checked=false;
        document.getElementById('ckbapproved').checked=false;
        document.getElementById('txtincentive').value="";
        document.getElementById('drpadvcat').value="0";
        document.getElementById('drppublication').value="0";
        document.getElementById('drpsuppliment').value="0";
        document.getElementById('drpedition').value="0";
        document.getElementById('drpbooked').value="";
        document.getElementById('drppackagecode').value="0";
        document.getElementById('drpcolor').value="0";
        document.getElementById('txtremark').value="";
         document.getElementById('drpday').value="0";
        document.getElementById('txtsizefrom').value="";
        document.getElementById('txtsizeto').value="";
        document.getElementById('drpdisctype').value="0";
        document.getElementById('txtdiscamount').value="";
        document.getElementById('txtinsertion').value="";
        document.getElementById('txtcardrate').value="";
        document.getElementById('txtdealrate').value="";
        document.getElementById('drppremium').value="0";
        document.getElementById('txtcardpremium').value="";
        document.getElementById('txtdealpremium').value="";
        document.getElementById('txtvolbilled').value="";
        document.getElementById('txtvoldisc').value="";
        document.getElementById('txtvalfrom').value="";
        document.getElementById('txtvalto').value="";
        document.getElementById('drpuom').value="0";
        document.getElementById('txttotal').value="";
        document.getElementById('drpratecode').value="0";
        document.getElementById('txtdeviation').value="";
        //document.getElementById('drpcurr').value="0";

        document.getElementById('hiddensavemod').value="0";

        document.getElementById('txtquantity').value="";
        document.getElementById('txtweight').value="";
        document.getElementById('drpdisc').value="";
        document.getElementById('txtdeviation').value="";
        document.getElementById('hideopen').value="0";
        document.getElementById('drppublication').disabled=false;
        document.getElementById('drpsuppliment').disabled=false;
        document.getElementById('drpedition').disabled=false;
        document.getElementById('drpratecode').disabled=false;
        return;
    }
    var i=document.getElementById("GridView1").rows.length -2;
    for(var j=0;j<=i;j++)
    {
        var str="checkbox_"+j;
        document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(id==str)
        {
            if(document.getElementById(id).checked==true)
            {           

            }
        }
    }
    document.getElementById(id).checked=true;
    callfunction(id,code);
}


function selectforcontract(id,code)
{
    idcode=id;

    if(document.getElementById(id).checked==false)
    {
        document.getElementById(id).checked=false;
        document.getElementById('ckbapproved').checked=false;
        document.getElementById('drpadvcat').value="0";
        document.getElementById('drppublication').value="0";
        document.getElementById('drpsuppliment').value="0";
        document.getElementById('drpedition').value="0";
        document.getElementById('drpbooked').value="";
        document.getElementById('drppackagecode').value="0";
        document.getElementById('drpcolor').value="0";
        document.getElementById('txtremark').value="";
        document.getElementById('drpday').value="0";
        document.getElementById('txtsizefrom').value="";
        document.getElementById('txtsizeto').value="";
        document.getElementById('drpdisctype').value="0";
        document.getElementById('txtdiscamount').value="";
        document.getElementById('txtinsertion').value="";
        document.getElementById('txtcardrate').value="";
        document.getElementById('txtdealrate').value="";
        document.getElementById('drppremium').value="0";
        document.getElementById('txtcardpremium').value="";
        document.getElementById('txtdealpremium').value="";
        document.getElementById('txtvolbilled').value="";
        document.getElementById('txtvoldisc').value="";
        document.getElementById('txtvalfrom').value="";
        document.getElementById('txtvalto').value="";
        document.getElementById('drpuom').value="0";
        document.getElementById('txttotal').value="";
        document.getElementById('drpratecode').value="";
        document.getElementById('txtdeviation').value="";
        document.getElementById('txtincentive').value="";

        document.getElementById('hiddensavemod').value="0";

        document.getElementById('txtquantity').value="";
        document.getElementById('txtweight').value="";
        document.getElementById('drpdisc').value="";
        document.getElementById('txtdeviation').value="";
        document.getElementById('hideopen').value="0";
        document.getElementById('drppublication').disabled=false;
        document.getElementById('drpsuppliment').disabled=false;
        document.getElementById('drpedition').disabled=false;
        document.getElementById('drpratecode').disabled=false;

        return;
    }

    document.getElementById('hideopen').value="1";
    document.getElementById('hiddendeal').value=code;
    document.getElementById('hiddensavemod').value="1";

    var i=document.getElementById("GridView1").rows.length -2;
    for(var j=0;j<=i;j++)
    {
        document.getElementById('btnclick').disabled=false;
        var str="checkbox"+j;
        document.getElementById(str).checked=false;
        document.getElementById(id).checked=true;
        if(id==str)
        {
            if(document.getElementById(id).checked==true)
            {
            }
        }
    }
    document.getElementById(id).checked=true;
    if(opener.document.getElementById('hiddenmodify').value=="0"||opener.document.getElementById('hiddenmodify').value=="1")
    {
        document.getElementById('btnselect').disabled=false;

    }
    else
    {
        document.getElementById('btnselect').disabled=true;
        document.getElementById('btnclick').disabled=true;
    }
    callfunction(id,code);
}
function callfunction(id,code)
{
    //this will egt the value for upper dropdown from the server side
    var deal=document.getElementById('hiddendealcode').value;
    var code=code;

    compcode=document.getElementById('hiddencompcode').value;
    userid=document.getElementById('hiddenuserid').value;
    ContractDetail.getthevalue(compcode,userid,code,deal,call_valuecontract);
    return false;
}

function call_valuecontract(response)
{
    var ds=response.value;
    var z;
    var t;
    if(ds.Tables[0].Rows[0].COMMITION_ALLOW != null)
    {
        document.getElementById('drpcommallow').value=ds.Tables[0].Rows[0].COMMITION_ALLOW;
    }
    if(ds.Tables[0].Rows[0].INCENTIVE != null)
    {
        document.getElementById('txtincentive').value=ds.Tables[0].Rows[0].INCENTIVE;
    }
    if(ds.Tables[0].Rows[0].DEAL_START != null)
    {
        document.getElementById('drpdealstrt').value=ds.Tables[0].Rows[0].DEAL_START;
    }
    if(ds.Tables[0].Rows[0].Advcategory!=null && ds.Tables[0].Rows[0].Advcategory!="")
    { 
        document.getElementById('drpadvcat').value=ds.Tables[0].Rows[0].Advcategory;
    }
    else
    {
        document.getElementById('drpadvcat').value="0";
    }
    if(ds.Tables[0].Rows[0].publication!=null && ds.Tables[0].Rows[0].publication!="")
    {
        document.getElementById('drppublication').value=ds.Tables[0].Rows[0].publication;
    }
    else
    {
        document.getElementById('drppublication').value="0";
    }

    if(ds.Tables[0].Rows[0].deviation==null || ds.Tables[0].Rows[0].deviation=="")
    {
        document.getElementById('txtdeviation').value="";
    }
    else
    {
        document.getElementById('txtdeviation').value=ds.Tables[0].Rows[0].deviation;
    }
    if(ds.Tables[0].Rows[0].convertrate==null || ds.Tables[0].Rows[0].convertrate=="")
    {
        document.getElementById('txttotal').value=""
    }
    else
    {
        document.getElementById('txttotal').value=ds.Tables[0].Rows[0].convertrate;
    }

    if(ds.Tables[0].Rows[0].currency!=null && ds.Tables[0].Rows[0].currency!="")
    {
        document.getElementById('drpcurr').value=ds.Tables[0].Rows[0].currency;
    }
    else
    {
        document.getElementById('drpcurr').value="0";
    }

    if(ds.Tables[0].Rows[0].Rate_code==null)
    {
    //document.getElementById('txtedidisc').value="";
        document.getElementById('drpratecode').value="";
    }
    else
    {
     document.getElementById('drpratecode').value=ds.Tables[0].Rows[0].Rate_code;
    }
    if(ds.Tables[0].Rows[0].quantity==null)
    {
        document.getElementById('txtquantity').value="";
    }
    else
    {
        document.getElementById('txtquantity').value=ds.Tables[0].Rows[0].quantity;
    }
    if(ds.Tables[0].Rows[0].weight==null)
    {
        document.getElementById('txtweight').value="";
    }
    else
    {
        document.getElementById('txtweight').value=ds.Tables[0].Rows[0].weight;
    }
    document.getElementById('drpdisc').value=ds.Tables[0].Rows[0].discounted;

    if(ds.Tables[0].Rows[0].approved=="Y")
    {
        document.getElementById('ckbapproved').checked=true;
    }
    else
    {
        document.getElementById('ckbapproved').checked=false;
    }

    //document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition
    var editobject=document.getElementById('drpedition');
    var suppobject=document.getElementById('drpsuppliment');
    /////this the xml to fetch the value of edition and supplement 
        var str="0";
        var page;
        var supp;
       
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open("GET","editonforcontractaspx.aspx?page="+document.getElementById('drppublication').value+"&str="+str+"&supp="+document.getElementById('drpedition').value, false );
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
		    xml.Open( "GET","editonforcontractaspx.aspx?page="+document.getElementById('drppublication').value+"&str="+str+"&supp="+document.getElementById('drpedition').value, false );
		    xml.Send();
		    id=xml.responseText;
		}
		var split=id.split("+");
		var editcode=split[0];
		var editcode1=editcode.split(",");
		var editname=split[1];
		var editname1=editname.split(",");
		editobject.options.length=0;
		for(z=0;z<=editcode1.length-1;z++)
		{
		    if(editcode1[z]!=",")
		    {
		        if(editcode1[z]!="0")
		        {
		        editobject.options[editobject.options.length]=new Option(editname1[z],editcode1[z]);
                editobject.options.length;
		        }
		    }
		}


document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition;

////this is to fetch supplement

 //var str="0";
        var page;
        var tstr="1";
        var supp;
        var idsupp="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open("GET","editonforcontractaspx.aspx?page="+document.getElementById('drppublication').value+"&str="+tstr+"&supp="+document.getElementById('drpedition').value, false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    idsupp=httpRequest.responseText;   
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
		    xml.Open( "GET","editonforcontractaspx.aspx?page="+document.getElementById('drppublication').value+"&str="+tstr+"&supp="+document.getElementById('drpedition').value, false );
		    xml.Send();
		    idsupp=xml.responseText;
		}
		
		suppobject.options.length=0;
		var split1=idsupp.split("+");
		var suppcode=split1[0];
		var suppcode1=suppcode.split(",");
		
		var suppname=split1[1];
		var suppname1=suppname.split(",");
		
		for(t=0;t<=suppcode1.length-1;t++)
		{
		    if(suppcode1[t]!=",")
		    {
		        if(suppcode1[t]!="0")
		        {
		        suppobject.options[suppobject.options.length]=new Option(suppname1[t],suppcode1[t]);
                suppobject.options.length;
		        }
		    }
		}        


document.getElementById('drpsuppliment').value=ds.Tables[0].Rows[0].suppliment;
//;




    if(ds.Tables[0].Rows[0].Bookedfor==null || ds.Tables[0].Rows[0].Bookedfor=="")
    {
        document.getElementById('drpbooked').value="";
    }
    else
    {
        document.getElementById('drpbooked').value=ds.Tables[0].Rows[0].Bookedfor;
    }


    if(ds.Tables[0].Rows[0].packagecode==null || ds.Tables[0].Rows[0].packagecode=="")
    {
        document.getElementById('drppackagecode').value="";
    }
    else
    {
        document.getElementById('drppackagecode').value=ds.Tables[0].Rows[0].packagecode;
    }


    if(ds.Tables[0].Rows[0].packagecode==""||ds.Tables[0].Rows[0].packagecode=="0")
    {
        document.getElementById('drpsuppliment').disabled=true;
        document.getElementById('drppublication').disabled=true;
        document.getElementById('drpedition').disabled=true;
    }
    else
    {
        document.getElementById('drpsuppliment').disabled=true;
        document.getElementById('drppublication').disabled=true;
        document.getElementById('drpedition').disabled=true;
        document.getElementById('drppackagecode').disabled=true;
    }


    document.getElementById('drpcolor').value=ds.Tables[0].Rows[0].color;
    if(ds.Tables[0].Rows[0].cardrate==null || ds.Tables[0].Rows[0].cardrate=="")
    {
        document.getElementById('txtcardrate').value="";
    }
    else
    {
        document.getElementById('txtcardrate').value=ds.Tables[0].Rows[0].cardrate;
    }
    
      if(ds.Tables[0].Rows[0].REMARKS==null || ds.Tables[0].Rows[0].REMARKS=="")
    {
        document.getElementById('txtremark').value="";
    }
    else
    {
        document.getElementById('txtremark').value=ds.Tables[0].Rows[0].REMARKS;
    }
    
       if(ds.Tables[0].Rows[0].DAYNAME==null || ds.Tables[0].Rows[0].DAYNAME=="0")
    {
        document.getElementById('drpday').value="0";
    }
    else
    {
        document.getElementById('drpday').value=ds.Tables[0].Rows[0].DAYNAME;
    }
    
     if(ds.Tables[0].Rows[0].SIZEFROM==null || ds.Tables[0].Rows[0].SIZEFROM=="")
    {
        document.getElementById('txtsizefrom').value="";
    }
    else
    {
        document.getElementById('txtsizefrom').value=ds.Tables[0].Rows[0].SIZEFROM;
    }
    
      if(ds.Tables[0].Rows[0].SIZETO==null || ds.Tables[0].Rows[0].SIZETO=="")
    {
        document.getElementById('txtsizeto').value="";
    }
    else
    {
        document.getElementById('txtsizeto').value=ds.Tables[0].Rows[0].SIZETO;
    }
    
      if(ds.Tables[0].Rows[0].DISCTYPE==null || ds.Tables[0].Rows[0].DISCTYPE=="")
    {
        document.getElementById('drpdisctype').value="";
    }
    else
    {
        document.getElementById('drpdisctype').value=ds.Tables[0].Rows[0].DISCTYPE;
    }
    
      if(ds.Tables[0].Rows[0].DISCPER==null || ds.Tables[0].Rows[0].DISCPER=="")
    {
        document.getElementById('txtdiscamount').value="";
    }
    else
    {
        document.getElementById('txtdiscamount').value=ds.Tables[0].Rows[0].DISCPER;
    }
    
      if(ds.Tables[0].Rows[0].INSERTION==null || ds.Tables[0].Rows[0].INSERTION=="")
    {
        document.getElementById('txtinsertion').value="";
    }
    else
    {
        document.getElementById('txtinsertion').value=ds.Tables[0].Rows[0].INSERTION;
    }
    

    if(ds.Tables[0].Rows[0].Dealarte==null || ds.Tables[0].Rows[0].Dealarte=="")
    {
        document.getElementById('txtdealrate').value="";
    }
    else
    {
        document.getElementById('txtdealrate').value=ds.Tables[0].Rows[0].Dealarte;
    }

    document.getElementById('drppremium').value=ds.Tables[0].Rows[0].premiumcode;

    if(ds.Tables[0].Rows[0].cardpremium==null || ds.Tables[0].Rows[0].cardpremium=="")
    {
        document.getElementById('txtcardpremium').value="";
    }
    else
    {
        document.getElementById('txtcardpremium').value=ds.Tables[0].Rows[0].cardpremium;
    }

    if(ds.Tables[0].Rows[0].dealpremium==null || ds.Tables[0].Rows[0].dealpremium=="")
    {
        document.getElementById('txtdealpremium').value="";
    }
    else
    {
        document.getElementById('txtdealpremium').value=ds.Tables[0].Rows[0].dealpremium;
    }

    if(ds.Tables[0].Rows[0].volumebilled==null || ds.Tables[0].Rows[0].volumebilled=="")
    {
        document.getElementById('txtvolbilled').value="";
    }
    else
    {
        document.getElementById('txtvolbilled').value=ds.Tables[0].Rows[0].volumebilled;
    }

    if(ds.Tables[0].Rows[0].volumedisc==null || ds.Tables[0].Rows[0].volumedisc=="")
    {
        document.getElementById('txtvoldisc').value="";
    }
    else
    {
        document.getElementById('txtvoldisc').value=ds.Tables[0].Rows[0].volumedisc;
    }

    if(ds.Tables[0].Rows[0].valuefrom==null || ds.Tables[0].Rows[0].valuefrom=="")
    {
        document.getElementById('txtvalfrom').value="";
    }
    else
    {
        document.getElementById('txtvalfrom').value=ds.Tables[0].Rows[0].valuefrom;
    }

    if(ds.Tables[0].Rows[0].valueto==null || ds.Tables[0].Rows[0].valueto=="")
    {
        document.getElementById('txtvalto').value="";
    }
    else
    {
        document.getElementById('txtvalto').value=ds.Tables[0].Rows[0].valueto;
    }
    document.getElementById('drpuom').value=ds.Tables[0].Rows[0].Uom;

    return false;
}

function clearcontractdetail()
{
    document.getElementById('hideopen').value="0";
    document.getElementById('drpadvcat').value="0";
    document.getElementById('drppublication').value="0";
    document.getElementById('drpsuppliment').value="0";
    document.getElementById('drpedition').value="0";
    document.getElementById('drpbooked').value="";
    document.getElementById('drppackagecode').value="0";
    document.getElementById('drpcolor').value="0";
    document.getElementById('txtremark').value="";
     document.getElementById('drpday').value="0";
        document.getElementById('txtsizefrom').value="";
        document.getElementById('txtsizeto').value="";
        document.getElementById('drpdisctype').value="0";
        document.getElementById('txtdiscamount').value="";
        document.getElementById('txtinsertion').value="";

    document.getElementById('txtcardrate').value="";
    document.getElementById('txtdealrate').value="";
    document.getElementById('drppremium').value="0";
    document.getElementById('txtcardpremium').value="";
    document.getElementById('txtdealpremium').value="";
    document.getElementById('txtvolbilled').value="";
    document.getElementById('txtvoldisc').value="";
    document.getElementById('txtvalfrom').value="";
    document.getElementById('txtvalto').value="";
    document.getElementById('drpuom').value="0";
    document.getElementById('hiddensavemod').value="0";
    document.getElementById('txttotal').value="";
    document.getElementById('txtincentive').value="";
    document.getElementById('drpratecode').value="0";
    document.getElementById('txtquantity').value="";
    document.getElementById('txtweight').value="";
    document.getElementById('drpdisc').value="0";
    document.getElementById('txtdeviation').value="";
    document.getElementById('drppublication').disable=false;
    document.getElementById('drpsuppliment').disable=false;
    document.getElementById('drpedition').disable=false;

    document.getElementById('drppublication').disable=false;
    document.getElementById('drpsuppliment').disable=false;
    document.getElementById('drpedition').disable=false;
    document.getElementById('drpratecode').disabled=false;
    document.getElementById('chbcyop').disabled=false;

    if(idcode!="" && document.getElementById(idcode).checked==true)
    {
        document.getElementById(idcode).checked=false;
    }
    document.getElementById('ckbapproved').checked=false;
    return ;
}

function deletecontact()
{
    var deal=document.getElementById('hiddendeal').value;
    compcode=document.getElementById('hiddencompcode').value;
    userid=document.getElementById('hiddenuserid').value;

    //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
ContractDetail.deletethevalue(compcode,userid,deal);
    alert("Data Deleted Successfully");
    window.location=window.location;

    return false;
}

function chkuom(e)
{
    var fld=e.value;
	if(fld!="")
	{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
		if(fld.match(/^\d+(\.\d{1,2})?$/i))
		{
		    //return true;
		}
		else
		{
		    alert("Input error")
		    var str=e.id;
		    e.value="";
		    document.getElementById(str).focus();
		    //e.id.focus();
		    return false;
		}
			
	}


    if(document.getElementById('drpuom').value=="0")
    {
        alert("Please select the value from volume unit");
        document.getElementById('txtvoldisc').value="";
        return false;
    }    
    var txtedidisc=document.getElementById('txtvoldisc').value;

    var j=parseFloat(txtedidisc);

    if( j<1 || j>100 )
    {
        alert("This discount in not valid");
        document.getElementById('txtvoldisc').focus();
        return false;
    }

    return true;
}

function chkuomfrom(e)
{
	var fld=e.value;
	if(fld!="")
	{
	    if(fld.match(/^\d+(\.\d{1,2})?$/i))
		{
		    //return true;
		}
		else
		{
		    alert("Input error")		   
		    var str=e.id;
		    e.value="";
		    document.getElementById(str).focus();		    
		    return false;
		}		
	}
    var fromval=parseFloat(document.getElementById('txtvalfrom').value);
    var toval=parseFloat(document.getElementById('txtvalto').value);
    if(toval!="")
    {
        if(fromval>toval)
        {
            alert("Value from should be less then to val");
            document.getElementById('txtvalfrom').focus();
            return false;
        }
    }

    if(document.getElementById('txtvalto').value!="")
    {
        givecurrencyvalue();
    }
    return true;
}

function chkcurrencyval(e)
{
	var fld=e.value;
	if(fld!="")
	{
	   if(fld.match(/^\d+(\.\d{1,2})?$/i))
	   {
	   }
	   else
	   {
	        alert("Input error")
		    var str=e.id;
	        e.value="";
	        document.getElementById(str).focus();
	        return false;
	    }		
	}			

    var from =parseFloat(document.getElementById('txtvalfrom').value);
    var to=parseFloat(document.getElementById('txtvalto').value);

    if(from>to)
    {
        alert("Value from should be smaller then Value to");
        document.getElementById('txtvalto').focus();
        return false;
    }
    givecurrencyvalue();
    return true;
}

function chkcurrencybill(e)
{
    var fld=e.value;
	if(fld!="")
	{
	//var expression= ^-{0,1}\d*\.{0,1}\d+$;
	    if(fld.match(/^\d+(\.\d{1,2})?$/i))
	    {
	    //return true;
	    }
	    else
	    {
	        alert("Input error")	    
	        var str=e.id;
	        e.value="";
	        document.getElementById(str).focus();
	        return false;
	    }	
	}
    if(document.getElementById('drpuom').value=="0")
    {
        alert("Please select the value from UOM");
        document.getElementById('txtvolbilled').value="";
        return false;
    }
    return true;
}

function chkvol()
{
    return false;
}

function chkval()
{
    /*if(document.getElementById('txtdealvalue').value!="")
    {
    alert("The contract should be either in Volume or in value based");
    document.getElementById('txtdealvol').value="";
    return false;
    }*/

    return false;
}

function chkvolume()
{
    /*if(document.getElementById('txtvalfrom').value!="" || document.getElementById('txtvalto').value!="")
    {
    alert("The contract should be either in Volume or in value based");
    document.getElementById('txtvoldisc').value="" ;
    document.getElementById('txtvolbilled').value=""

    return false;
    }*/

    return false;
}

function chkvalue()
{
    /*if(document.getElementById('txtvoldisc').value!="" || document.getElementById('txtvolbilled').value!="")
    {
    alert("The contract should be either in Volume or in value based");
    document.getElementById('txtvalfrom').value="" ;
    document.getElementById('txtvalto').value="";

    return false;
    }*/

    return false;
}

function givecurrencyvalue()
{
    if(document.getElementById('txtvalfrom').value=="" )
    {
        alert("Please Fill Value from ");
        document.getElementById('txtvalfrom').focus() ;
        return false;
    }
/////////////////this xml is to get the value of preferences
//if(document.getElementById('drpcurr').value=="0")
//{
    var pre=document.getElementById('hiddencurrency').value;
//}
//else
//{
        //var pre=document.getElementById('drpcurr').value;
        
//}
        
        var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","convertrate.aspx?curr="+pre, false );
		xml.Send();
		var rate=xml.responseText;
		
		var rateid=parseInt(rate);

////this xml is to calcule the covert rate ox xml
        var valfrom=document.getElementById('txtvalfrom').value;
        var valto=document.getElementById('txtvalto').value;
        curr=document.getElementById('hidecurr').value;
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","convertrate.aspx?curr="+curr, false );
		xml.Send();
		var id=xml.responseText;
		
		var intcode=parseInt(id);
		
		var convalfrom=parseInt(valfrom)*intcode/rateid;
		var convalto=parseInt(valto)*intcode/rateid;
		
		document.getElementById('txttotal').value=convalfrom + convalto;
        return false;
}



function submitted()
{
    var xml = new ActiveXObject("Microsoft.XMLHTTP");
	xml.Open( "GET","checksession.aspx", false );
	xml.Send();
	var check=xml.responseText;
	  var browser=navigator.appName;
	  var chmandat="";
	     if(browser!="Microsoft Internet Explorer")
        {
            chmandat=document.getElementById('Volumefrom').textContent;
        }
        else{
             chmandat=document.getElementById('Volumefrom').innerText;
        }    
	if(check=="0")
	{
    	window.close();
	    return false;
	}
    if(document.getElementById('chbcyop').checked==false)
    {
        if(document.getElementById('drpuom').value=="0")
        {
            alert("Please select the volume unit");
            document.getElementById('drpuom').focus();
            return false;
        }
        else if(document.getElementById('txtcardrate').value=="")
        {
            alert("Please fill Card Rate");
            if(document.getElementById('txtcardrate').disabled==false)
            document.getElementById('txtcardrate').focus();
            return false;
        }
        else if(document.getElementById('hiddenvolume').value!="")
        {
            if(document.getElementById('txtvoldisc').value=="")
            {
                alert("Please fill the volume disc.");
                document.getElementById('txtvoldisc').focus();
                return false;
            }
        }
        else if(document.getElementById('hiddenvolume').value!="")
        {
            if(document.getElementById('txtvolbilled').value=="")
            {
                alert("Please select the volume billed");
                document.getElementById('txtvolbilled').focus();
                return false;
            }
        }
      
       else if(document.getElementById('hiddenvalue').value!="" && chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtvalfrom').value=="")
            {
                alert("Please fill value from");
                document.getElementById('txtvalfrom').focus();
                return false;
            }
        }
       else if(document.getElementById('hiddenvalue').value!="" && chmandat.indexOf('*')>= 0)
        {
            if(document.getElementById('txtvalto').value=="")
            {
                alert("Please fill value to");
                document.getElementById('txtvalto').focus();
                return false;
            }
        }
//        else if(document.getElementById('hiddenvalue').value=="" && document.getElementById('hiddenvolume').value=="")
//        {
//             if(document.getElementById('txtquantity').value=="")
//             {
//                    alert("Please fill quantity");                    
//                    return false;
//             }
//        
//        }
//        else if(document.getElementById('hiddenvalue').value=="" && document.getElementById('hiddenvolume').value=="")
//        {
//             if(document.getElementById('txtweight').value=="")
//             {
//                alert("Please fill weight");
//                //document.getElementById('txtvalto').focus();
//                return false;
//             }            
//        }
    }   
//    else if(document.getElementById('txtcardrate').value=="")
//    {
//        alert("Please fill card rate");
//        document.getElementById('txtcardrate').focus();
//        return false;
//    }
   else if(document.getElementById('txtdealrate').value=="")
    {
        alert("Please fill contract rate");
        document.getElementById('txtdealrate').focus();
        return false;
    }

    else if(document.getElementById('drpuom').value=="0")
    {
        alert("Please select the volume unit");
        document.getElementById('drpuom').focus();
        return false;
    }
    else if(document.getElementById('hiddenvolume').value!="")
    {
        if(document.getElementById('txtvoldisc').value=="")
        {
            alert("Please fill the volume disc.");
            document.getElementById('txtvoldisc').focus();
            return false;
        }
     }
     else if(document.getElementById('hiddenvolume').value!="")
     {
        if(document.getElementById('txtvolbilled').value=="")
        {
            alert("Please select the volume billed");
            document.getElementById('txtvolbilled').focus();
            return false;
        }
     }

     else if(document.getElementById('hiddenvalue').value!="" &&  chmandat.indexOf('*')>= 0)
     {
        if(document.getElementById('txtvalfrom').value=="")
        {
            alert("Please fill value from");
            document.getElementById('txtvalfrom').focus();
            return false;
        }
    }
    else if(document.getElementById('hiddenvalue').value!="" && chmandat.indexOf('*')>= 0)
    {
        if(document.getElementById('txtvalto').value=="")
        {
            alert("Please fill value to");
            document.getElementById('txtvalto').focus();
            return false;
        }
    }
//    else if(document.getElementById('hiddenvalue').value=="" && document.getElementById('hiddenvolume').value=="")
//    {
//         if(document.getElementById('txtquantity').value=="")
//         {
//                alert("Please fill quantity");
//                //document.getElementById('txtvalto').focus();
//                return false;
//         }
//            
//    }
//    else if(document.getElementById('hiddenvalue').value=="" && document.getElementById('hiddenvolume').value=="")
//    {
//         if(document.getElementById('txtweight').value=="")
//         { 
//            alert("Please fill weight");
//            //document.getElementById('txtvalto').focus();
//            return false;
//          }            
//    }

////////////////////this xml is to check whether the currency is same for a single deal

        var paise=document.getElementById('hiddendealcode').value;
        
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","checkcurrency.aspx?paise="+paise, false );
		xml.Send();
		var check=xml.responseText;
		
		if(check!="" && check!=null)
		{
		    if(check!=document.getElementById('drpcurr').value)
		    {
		        alert("All the deals record should be in the same currency");
		        return false;
		    }		    
		}

    var adcat=document.getElementById('drpadvcat').value;
    var pub=document.getElementById('drppublication').value;
    //document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition
    var edit=document.getElementById('drpedition').value;
    var supp=document.getElementById('drpsuppliment').value;
    var booked=document.getElementById('hiddenpackagedesc').value=document.getElementById('drpbooked').value;
    var packagecc=document.getElementById('drppackagecode').value;
    var color=document.getElementById('drpcolor').value;
    var cardrate=document.getElementById('hiddencardrate').value=document.getElementById('txtcardrate').value;
    var dealrate=document.getElementById('txtdealrate').value;
    var premi=document.getElementById('drppremium').value;
    var cardpre=document.getElementById('hiddencardpremium').value=document.getElementById('txtcardpremium').value;
    var dealpre=document.getElementById('hiddencontractpremium').value=document.getElementById('txtdealpremium').value;
    var volbilled=document.getElementById('txtvolbilled').value;
    var voldisc=document.getElementById('txtvoldisc').value;
    var validfrom=document.getElementById('txtvalfrom').value;
    var valto=document.getElementById('txtvalto').value;
    var uom=document.getElementById('drpuom').value;
    var currency=document.getElementById('drpcurr').value;
    var editdisc=document.getElementById('drpratecode').value;
    var quantity=document.getElementById('txtquantity').value;
    var weight=document.getElementById('txtweight').value;
    var free=document.getElementById('drpdisc').value;
    var flag;
    var cyoppac=document.getElementById('hiddencyop').value;
    var deviation=document.getElementById('hiddendeviation').value=document.getElementById('txtdeviation').value;
    if(document.getElementById('ckbapproved').checked==true)
    {
        flag="Y";
    }
    else
    {
        flag="N";
    }

     //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       }
    document.getElementById('drppackagecode_var').value=document.getElementById('drppackagecode').value;
    document.getElementById('drpadvcat_var').value=document.getElementById('drpadvcat').value;
    document.getElementById('drpuom_var').value=document.getElementById('drpuom').value
    document.getElementById('drppremium_var').value =document.getElementById('drppremium').value;
     document.getElementById('drppackagecodetext_var').value=document.getElementById('drppackagecode').options[document.getElementById('drppackagecode').selectedIndex].text;
    document.getElementById('drpadvcattext_var').value=document.getElementById('drpadvcat').options[document.getElementById('drpadvcat').selectedIndex].text;
    document.getElementById('drpuomtext_var').value=document.getElementById('drpuom').options[document.getElementById('drpuom').selectedIndex].text
    document.getElementById('drppremiumtext_var').value =document.getElementById('drppremium').options[document.getElementById('drppremium').selectedIndex].text;
    if(document.getElementById('hiddensavemod').value=="0")
    {
        if(document.getElementById('hiddenofpop').value=="0" || document.getElementById('hiddenofpop').value=="")
        {
        
            alert("Data Saved Successfully");
            colName="";
            document.getElementById('lblfinalvalue').innerHTML="";
            return;
        }
        else
        {
    ////////////this to chk the duplicacy in the contract master
            var a_gency=document.getElementById('hiddenagency').value;
            var c_lient=document.getElementById('hiddenclient').value;
            var p_roduct=document.getElementById('hiddenproduct').value;
            var c_ompcode=document.getElementById('hiddencompcode').value
            var a_dtype=document.getElementById('hiddenadtype').value;
            var ad_cat=document.getElementById('drpadvcat').value;
            var pkg_code=document.getElementById('drppackagecode').value;
            var rate_code=document.getElementById('drpratecode').value;
            var c_olor=document.getElementById('drpcolor').value;
            
         
ContractDetail.chkduplicacy(a_gency,c_lient,p_roduct,c_ompcode,a_dtype,ad_cat,pkg_code,rate_code,c_olor,"save","save",document.getElementById('drpday').value,call_chkduplicacyinsert);
            return false;
          }
    }
    else
    {
        var i=document.getElementById("GridView1").rows.length -2;
        var flag;
        for(var j=0;j<=i;j++)
        {
            var str="checkbox"+j;
            if(document.getElementById(str).checked==true)
            {
                flag="1";
                break;
            }
            else
            {
                flag="0";
            }   
        }

        if(flag=="0")
        {
            //ContractDetail.insertvalue(dealno, advcat, publication, drpsuppliment, drpedition, bookedfor, color, cardrate, dealrate, premium, cardprem, dealprem, volbilled, voldisc, valfrom, valto, uom, package, compcode, userid, totalrate, currency, editionaldisc, flag, quantity, weight, free, cyoppac, deviation);
            var remarks = document.getElementById('txtremark').value;
        var sizefrom = document.getElementById('txtsizefrom').value;
        var sizeto = document.getElementById('txtsizeto').value;
        var disctype = document.getElementById('drpdisctype').value;
        var discper = document.getElementById('txtdiscamount').value;
        var insertion = document.getElementById('txtinsertion').value;
        var dayname=document.getElementById('drpday').value;
        var comm_allow=document.getElementById('drpcommallow').value;
        var deal_start=document.getElementById('drpdealstrt').value;
        var incentive = document.getElementById('txtincentive').value;
            ContractDetail.insertvalue(document.getElementById('hiddendealcode').value,adcat,pub,supp,edit,booked,color,cardrate,dealrate,premi,cardpre,dealpre,volbilled,voldisc,validfrom,valto,uom,packagecc,document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txttotal').value,currency,editdisc,flag,quantity,weight,free,cyoppac,deviation,remarks,sizefrom,sizeto,disctype,discper,insertion,dayname,comm_allow, deal_start,incentive);
            return;        
        }
        else
        {
            ////////////this to chk the duplicacy in the contract master
            var a_gency=document.getElementById('hiddenagency').value;
            var c_lient=document.getElementById('hiddenclient').value;
            var p_roduct=document.getElementById('hiddenproduct').value;
            var c_ompcode=document.getElementById('hiddencompcode').value
            var a_dtype=document.getElementById('hiddenadtype').value;
            var ad_cat=document.getElementById('drpadvcat').value;
            var pkg_code=document.getElementById('drppackagecode').value;
            var rate_code=document.getElementById('drpratecode').value;
            var c_olor=document.getElementById('drpcolor').value;
            
            ContractDetail.chkduplicacy(a_gency,c_lient,p_roduct,c_ompcode,a_dtype,ad_cat,pkg_code,rate_code,c_olor,document.getElementById('hiddendealcode').value,document.getElementById('hiddendeal').value,document.getElementById('drpday').value,call_chkduplicacy);
            return false;
        }
    }
    return false;
}

function call_chkduplicacyinsert(res)
{
    var fl=res.value;
    fl=fl.split("^");
    if(fl[0]=="1" )
    {
        alert("Duplicate contract not allowed");
        return false;
    }
            
        var adcat=document.getElementById('drpadvcat').value;
        var pub=document.getElementById('drppublication').value;
        //document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition
        var edit=document.getElementById('drpedition').value;
        var supp=document.getElementById('drpsuppliment').value;
        var booked=document.getElementById('drpbooked').value;
        var packagecc=document.getElementById('drppackagecode').value;
        var color=document.getElementById('drpcolor').value;
        var cardrate=document.getElementById('txtcardrate').value;
        var dealrate=document.getElementById('txtdealrate').value;
        var premi=document.getElementById('drppremium').value;
        var cardpre=document.getElementById('txtcardpremium').value;
        var dealpre=document.getElementById('txtdealpremium').value;
        var volbilled=document.getElementById('txtvolbilled').value;
        var voldisc=document.getElementById('txtvoldisc').value;
        var validfrom=document.getElementById('txtvalfrom').value;
        var valto=document.getElementById('txtvalto').value;
        var uom=document.getElementById('drpuom').value;
        var currency=document.getElementById('drpcurr').value;
        var editdisc=document.getElementById('drpratecode').value;
        var quantity=document.getElementById('txtquantity').value;
        var weight=document.getElementById('txtweight').value;
        var free=document.getElementById('drpdisc').value;
        var flag;
        var cyoppac=document.getElementById('hiddencyop').value;
        var deviation=document.getElementById('txtdeviation').value;
        var remarks = document.getElementById('txtremark').value;
        var sizefrom = document.getElementById('txtsizefrom').value;
        var sizeto = document.getElementById('txtsizeto').value;
        var disctype = document.getElementById('drpdisctype').value;
        var discper = document.getElementById('txtdiscamount').value;
        var insertion = document.getElementById('txtinsertion').value;
        var dayname = document.getElementById('drpday').value;
        var comm_allow=document.getElementById('drpcommallow').value;
        var deal_start=document.getElementById('drpdealstrt').value;
        var incentive = document.getElementById('txtincentive').value;
        if(document.getElementById('ckbapproved').checked==true)
        {
            flag="Y";
        }
        else
        {
            flag="N";
        }
            
        ContractDetail.insertvalue(document.getElementById('hiddendealcode').value,adcat,pub,supp,edit,booked,color,cardrate,dealrate,premi,cardpre,dealpre,volbilled,voldisc,validfrom,valto,uom,packagecc,document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txttotal').value,currency,editdisc,flag,quantity,weight,free,cyoppac,deviation,remarks,sizefrom,sizeto,disctype,discper,insertion,dayname,comm_allow, deal_start,incentive);
//ContractDetail.insertvalue(document.getElementById('hiddendealcode').value,adcat,pub,supp,edit,booked,color,cardrate,dealrate,premi,cardpre,dealpre,volbilled,voldisc,validfrom,valto,uom,packagecc,document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txttotal').value,editdisc,flag);

        alert("Data Saved Successfully");
colName="";

document.getElementById('lblfinalvalue').innerHTML="";
        document.getElementById('txtincentive').value="";
        document.getElementById('drpadvcat').value="0";
        document.getElementById('drppublication').value="0";
        document.getElementById('drpsuppliment').value="0";
        document.getElementById('drpedition').value="0";
        document.getElementById('drpbooked').value="";
        document.getElementById('drppackagecode').value="0";
        document.getElementById('drpcolor').value="0";
        document.getElementById('txtremark').value="";
        document.getElementById('drpday').value="0";
        document.getElementById('txtsizefrom').value="";
        document.getElementById('txtsizeto').value="";
        document.getElementById('drpdisctype').value="0";
        document.getElementById('txtdiscamount').value="";
        document.getElementById('txtinsertion').value="";

        document.getElementById('txtcardrate').value="";
        document.getElementById('txtdealrate').value="";
        document.getElementById('drppremium').value="0";
        document.getElementById('txtcardpremium').value="";
        document.getElementById('txtdealpremium').value="";
        document.getElementById('txtvolbilled').value="";
        document.getElementById('txtvoldisc').value="";
        document.getElementById('txtvalfrom').value="";
        document.getElementById('txtvalto').value="";
        document.getElementById('drpuom').value="0";
        document.getElementById('txtquantity').value="";
        document.getElementById('txtweight').value="";
        document.getElementById('drpdisc').value="0";
        document.getElementById('txttotal').value="";
        document.getElementById('hiddencyop').value="";
        document.getElementById('txtdeviation').value="";
        window.location=window.location;

}

function call_chkduplicacy(res)
{
    var fl=res.value;
    fl=fl.split("^");
    if(fl[0]=="1" )
    {
        alert("Duplicate contract not allowed");
        return false;
    }

    var adcat=document.getElementById('drpadvcat').value;
    var pub=document.getElementById('drppublication').value;
    //document.getElementById('drpedition').value=ds.Tables[0].Rows[0].edition
    var edit=document.getElementById('drpedition').value;
    var supp=document.getElementById('drpsuppliment').value;
    var booked=document.getElementById('drpbooked').value;
    var packagecc=document.getElementById('drppackagecode').value;
    var color=document.getElementById('drpcolor').value;
    var cardrate=document.getElementById('txtcardrate').value;
    var dealrate=document.getElementById('txtdealrate').value;
    var premi=document.getElementById('drppremium').value;
    var cardpre=document.getElementById('txtcardpremium').value;
    var dealpre=document.getElementById('txtdealpremium').value;
    var volbilled=document.getElementById('txtvolbilled').value;
    var voldisc=document.getElementById('txtvoldisc').value;
    var validfrom=document.getElementById('txtvalfrom').value;
    var valto=document.getElementById('txtvalto').value;
    var uom=document.getElementById('drpuom').value;
    var currency=document.getElementById('drpcurr').value;
    var editdisc=document.getElementById('drpratecode').value;
    var quantity=document.getElementById('txtquantity').value;
    var weight=document.getElementById('txtweight').value;
    var free=document.getElementById('drpdisc').value;
    var flag;
    if(document.getElementById('ckbapproved').checked==true)
    {
         flag="Y";
    }
    else
    {
         flag="N";
    }
           
    var cyoppac=document.getElementById('hiddencyop').value;
    var deviation=document.getElementById('txtdeviation').value;

        var remark=document.getElementById('txtremark').value;
        var sizefrom=document.getElementById('txtsizefrom').value;
        var sizeto=document.getElementById('txtsizeto').value;
        var disctype=document.getElementById('drpdisctype').value;
        var discamt=document.getElementById('txtdiscamount').value;
        var insertion=document.getElementById('txtinsertion').value;
        var dayname=document.getElementById('drpday').value;
         var comm_allow=document.getElementById('drpcommallow').value;
        var deal_start=document.getElementById('drpdealstrt').value;
        var incentive = document.getElementById('txtincentive').value;
    ContractDetail.updatevalue(document.getElementById('hiddendealcode').value,adcat,pub,supp,edit,booked,color,cardrate,dealrate,premi,cardpre,dealpre,volbilled,voldisc,validfrom,valto,uom,packagecc,document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('hiddendeal').value,document.getElementById('txttotal').value,currency,editdisc,flag,quantity,weight,free,cyoppac,deviation,remark,sizefrom,sizeto,disctype,discamt,insertion,dayname,comm_allow,deal_start,incentive);
    //ContractDetail.updatevalue(document.getElementById('hiddendealcode').value,adcat,pub,supp,edit,booked,color,cardrate,dealrate,premi,cardpre,dealpre,volbilled,voldisc,validfrom,valto,uom,packagecc,document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('hiddendeal').value,document.getElementById('txttotal').value,editdisc,flag);
    alert("Value updated sucessfully");

    document.getElementById('hiddensavemod').value="0";
    window.location=window.location;
}

function chkcurrency()
{
    if(document.getElementById('drpuom').value!="0")
    {
        alert("The Deal Should be on Value or volume based");
        document.getElementById('drpcurr').value="0";
        return false;
    }
    else if(document.getElementById('txtvoldisc').value!="")
    {
        alert("The Deal Should be on Value or volume based");
        return false;
    }
    else if(document.getElementById('txtvolbilled').value!="")
    {
        alert("The Deal Should be on Value or volume based");
        return false;
    }
    opener.document.getElementById('drpcurr').value=document.getElementById('drpcurr').value;

    if(document.getElementById('txtvalfrom').value!="" && document.getElementById('txtvalto').value!="")
    {
        givecurrencyvalue();
    }

}




function chkpercent()
{
    var txtedidisc=document.getElementById('txtedidisc').value;
    var j=parseFloat(txtedidisc);

    if(txtedidisc!="" && (j<1 || j>100 ))
    {
        alert("This discount in not valid");
        document.getElementById('txtedidisc').value="";
        document.getElementById('txtedidisc').focus();
        return false;
    }

    if(document.getElementById('ckbapproved').checked==true)
    {
        chkdisc();
    }
    return ;
}

function closewindow1()
{
    self.close();
}

function chkdisc()
{
    if(document.getElementById('ckbapproved').checked==false)
    {
        document.getElementById('ckbapproved').checked=false;
        return;
    }
    var discount=document.getElementById('txtedidisc').value;
    if(discount=="" || discount=="null")
    {
        alert("Please Fill Additional Discount");
        document.getElementById('txtedidisc').focus();
        return false;
    }

//this is the xml to check the discount given

        var page;
        
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","getdiscount.aspx?page="+discount, false );
		xml.Send();
		var id=xml.responseText;
		
		var j=parseFloat(document.getElementById('txtedidisc').value);
		
		var k=parseFloat(id);
		if(j>k)
		{
		    alert("You are not authorised to approve this deal");
		    document.getElementById('txtedidisc').value="";
		    document.getElementById('ckbapproved').checked=false;
		    return;
		}
		else
		{
		    document.getElementById('ckbapproved').checked=true;
		}
        return;
}

function closedeal()
{
    if(popUpWin && !popUpWin.closed)
    {
        popUpWin.close();
    }
    return false;
}

function closedael()
{
    if(confirm("Do you want to skip this page"))
    {
        window.close();
    }
    return false;
}

function eventcalling(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
if(event.keyCode==113) 
    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;

}

function chkenabled()
{
if(document.getElementById('ckbapproved').checked==true)
{
document.getElementById('ckbapproved').checked=false;
return;
}

}
function cyop()
{


//document.getElementById('drppackagecode').value="0";
//document.getElementById('drpbooked').value="";

//document.getElementById('drppackagecode').disabled=true;
document.getElementById('drpbooked').disabled=true;
var popUpWincyop;
if(document.getElementById('hideopen').value=="0" || document.getElementById('hideopen').value=="" )
{
  popUpWincyop =
window.open('cyop.aspx','Ankur21','resizable=0,toolbar=0,top=140,left=30,scrollbars=yes,width=600px,height=435px'); 
popUpWincyop.focus();
 } 
 else
 {
 alert("You Can not Update The Package To CYOP");
 return false;
 }     


return ;
}



function openGridcont(str,imgname)
{
    //alert("hi");
    if(document.getElementById(imgname).src.indexOf("plus.gif",0)>=0)
    {
        document.getElementById(imgname).src=document.getElementById(imgname).src.replace("plus","minus");
        document.getElementById(str).style.display="block";
    }
    else
    {
      document.getElementById(imgname).src=document.getElementById(imgname).src.replace("minus","plus");
      document.getElementById(str).style.display="none";
      
    }
  
  
}


function columncheck(columncheck,rownum,checkId)
{
    var len="uniquename"+rownum;
	var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
   if(document.getElementById(checkId).checked==true )
    {
	    for(var w=0;w<y-1;w++)
	    {
	        var stra1 = rownum+columncheck + w;
	        if(document.getElementById(stra1).disabled==false)
	        {
	            document.getElementById(stra1).checked=true;
	        }
	    }
	}
	
	if(document.getElementById(checkId).checked==false )
    {
    for(var t=0;t<y-1;t++)
	    {
	        var stra1 = rownum+columncheck + t;
	        if(document.getElementById(stra1).disabled==false)
	        {
	            document.getElementById(stra1).checked=false;
	        }
	    }
    }
	
}


////////////////////////////////////////////////////////////////////

function unchk (idstr,val,j)
{


	var len="uniquename"+j;
	var str="DataGrid1__ctl_CheckBox"+val+ j;
    var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
	var chk_box=0;
	var b=0;
for(var w=0;w<y-1;w++)
	    {
	    var stra1=j+ val +w;
    if(document.getElementById(stra1).disabled==false)
    {
         //var str="DataGrid1__ctl_CheckBox"+val+ j;
	         if(document.getElementById(stra1).checked==true)
	         {
	            if(chk_box==0)
	            {
	        	document.getElementById(str).checked=true;
	        	chk_box=0;
	        	   	b++;
                }
               
             }
     }           
          }    
          if(b==y-1)
          {
          document.getElementById(str).checked=true;
          }  
          else
          {
           document.getElementById(str).checked=false;
          }
                

}

function selectall()
{
document.getElementById('txtname').value="";
opener.document.getElementById('drpbooked').value="";
            var j,ja,js,jd,jf,jg,jh,jj,jk,jl;
var k,x;
var v="";
var m="";

var abc=new Array();


var childabc=new Array();






var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i/2;j++)
	{
	
	var str="DataGrid1__ctl_CheckBox1"+j;
//	
   

	        if(document.getElementById(str).checked==true)
	        {
        	
	        k=document.getElementById(str).value;
	        abc[j]=k;
        	
	        }
	
	
	
	
	var len="uniquename"+j;
	
    var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length;
	
	 if(document.getElementById(str).checked==false)
	        {
	for(var a=0;a<y-1;a++)
	{
	 var stra = j+"1" + a;
	  if(document.getElementById(stra).checked==true)
	        {
        	
	        x=document.getElementById(stra).value;
	        childabc[a]=x;
        	
	        }
	        }
	 
    
    
                        
                         
                    	
	
	
	}

	
	}
	
	///////////////to select values
	var temp="";
	var extemp="";
	for(var l=0;l<=abc.length-1;l++)
	{
	if(abc[l]!=undefined)
	    {
	    temp=abc[l];
	    if(extemp=="")
	    {extemp=temp;}
	    else
	    {
	    extemp=temp+"+"+extemp;
	    }
	    }
	}
	var childtemp="";
	var exchildtemp="";
	for(var c=0;c<=childabc.length-1;c++)
	{
	if(childabc[c]!=undefined)
	    {
	    childtemp=childabc[c];
	    if(exchildtemp=="")
	    {
	    exchildtemp=childtemp;
	    }
	    else
	    {
	    exchildtemp=childtemp+"+"+exchildtemp;
	    }
	    }
	    
	    
	}
	
	if(extemp!="" && exchildtemp!="")
	{
	var total=extemp+"+"+exchildtemp;
	}
	else
	{
	var total=extemp+exchildtemp;
	}
	
	
	if(total=="")
	{
	alert("Please Create CYOP");
	return false;
	}
	
	    var page;
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","chkpackage.aspx?page="+total, false );
		xml.Send();
		var id=xml.responseText;
		
		if(id!="")
		{
		    //alert("This "+id+" Package Has been already there ");
		    alert("This Combination Already Exists Under The Package Name "+id+"");
		    return false;
		}
	
	
	document.getElementById('txtname').value=total;
	opener.document.getElementById('hiddencyop').value=total;
	opener.document.getElementById('drpbooked').value=total;
        document.getElementById('txtname').value=total;
      total="";  
        return false;

}

function closecyop()
{
window.close();
//opener.document.getElementById('chbcyop').checked=false;

return false;
}

function deviation(e)
{
//return allamount121(e);

var fld=e.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,2})?$/i))
			{
			//return true;
			}
			else
			{
			alert("Input error")
			//alert(e.id);
			var str=e.id;
			e.value="";
			document.getElementById(str).focus();
			//e.id.focus();
			return false;
			}
			
			}


var cardrate=parseFloat(document.getElementById('txtcardrate').value);
var contrcatdrate=parseFloat(document.getElementById('txtdealrate').value);
if(document.getElementById('txtcardrate').value!="")
{
    document.getElementById('txtdeviation').value=cardrate-contrcatdrate;
}
else
{
    document.getElementById('txtdeviation').value="";
}

return ;
}
function getweight()
{
var quan=document.getElementById('txtquantity').value;
var uom=document.getElementById('drpuom').value;
var quan1=parseInt(document.getElementById('txtquantity').value);

        var page;
		var xml = new ActiveXObject("Microsoft.XMLHTTP");
		xml.Open( "GET","chkweight.aspx?page="+uom, false );
		xml.Send();
		var id=xml.responseText;
		
		if(id=="1")
		{
		    document.getElementById('txtweight').value=quan1*10;
		
		}

return;
}

function amount(e)
		{
		//var fld =document.getElementById('txtcommrate').value;
		var fld=e.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,2})?$/i))
			{
			return true;
			}
			else
			{
			alert("Input error")
			//alert(e.id);
			var str=e.id;
			e.value="";
			document.getElementById(str).focus();
			//e.id.focus();
			return false;
			}
			
			}
			}
			
			function givefocus()
			{
			document.getElementById('drpdealtype').focus();
			}
			
			
function autoornot()
{
    if(mode=="new" || mode=="modify")
    {

        if(document.getElementById('hiddenauto').value=="1")
        {
//            changeoccured();

        }
        else
        {
            userdefine();

        }
    }

}


function userdefine()
    {
        
        
        document.getElementById('txtdealname').disabled=false;
        document.getElementById('txtdealname').value=document.getElementById('txtdealname').value.toUpperCase();
        var dealname=document.getElementById('txtdealname').value;
        ContractMaster.checkcode(dealname,fillcall);
        return false;
        

return false;

}

function changeoccured()
{
    if(document.getElementById('txtdealname').value!="")
    {
    var dealname=document.getElementById('txtdealname').value;
    ContractMaster.checkcode(dealname,fillcall);
    return false;
    }
    return false;

}

function fillcall(res)
{
    		var ds=res.value;
	   	        
		    if(ds.Tables[0].Rows.length!=0)
		    {
//		        if(document.getElementById('hiddenchkq').value=="0")
//		        {
		        alert("This Deal Name has been already assigned.");
		        document.getElementById('txtdealname').value="";
		        document.getElementById('txtdealname').focus();
		        return false;
//		        }
		    }
		    
}

//button click  ********************************
function newcontract()
{
    mode="new";
    document.getElementById('hiddenflagstatus').value="1";
    newClick();
    return false;
}

function querycontract()
{
    mode="qyery";
    
 document.getElementById('drpclientnamelist').innerHTML="";  
    document.getElementById('hiddenflagstatus').value="3";
    document.getElementById('hiddenchkq').value = "1";
    document.getElementById('txtdealno').value = "";
    document.getElementById('txtdealno').disabled=false;
    document.getElementById('txtdealname').value= "";
    document.getElementById('txtdealname').disabled = false;
    document.getElementById('drpagencycode').value = "";
    document.getElementById('drpagencycode').disabled = false;
    document.getElementById('drpsubagcode').value = "0";
    document.getElementById('drpclientname').value = "";
    document.getElementById('drpclientname').disabled=false;
    document.getElementById('drpdealtype').value="0";
    document.getElementById('drpdealtype').disabled=false;
    document.getElementById('drpproduct').value = "0";
    document.getElementById('drprepresentative').value = "0";
    document.getElementById('txttilldate').value = "";
    document.getElementById('validfrom').value = "";    
    document.getElementById('txtremark').value = "";
    document.getElementById('attachment1').disabled = true;
    document.getElementById('hidattach1').value = '';
    document.getElementById('drpcenter').value = "0";
    document.getElementById('drptransation').value = "N";
    document.getElementById('drpcenter').disabled = true;
    document.getElementById('drptransation').disabled = true;
    //document.getElementById('validfrom').disabled=true;
    chkstatus1(document.getElementById('hiddenflagstatus').value);
    setButtonImages();
    return false;
}

function modifycontract()
 {
       var res= checkmodify();

     var ds = res.value;
     if (ds.Tables[0].Rows.length >= 1) {
 alert("Audited Deal Can Not Be Modified")

         mode = "modify";
         document.getElementById('hiddenflagstatus').value = "5";
         document.getElementById('hiddenname').value = document.getElementById('txtdealname').value;
         //document.getElementById('lbcontractdetails').disabled = false;
         document.getElementById('hiddenmodify').value = "1";
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

         ContractMaster.blankvalueInsertSession();
         document.getElementById('hiddenforpop').value = "2";
         saving = "1";
         //document.getElementById('drpdealon').disabled=false;
//         document.getElementById('cmdAddRow').disabled = false;
//         document.getElementById('cmdAddRowelec').disabled = false;
//         document.getElementById('txtexecutive').disabled = false;
//         document.getElementById('txtretainer').disabled = false;
//         document.getElementById('txtcontractdate').disabled = false;
//         document.getElementById('txtclosedate').disabled = false;
//         document.getElementById('drpservicetax').disabled = false;
//         document.getElementById('txtcaption').disabled = false;
//         document.getElementById('drppaymenttype').disabled = false;
//         document.getElementById('txtdealno').disabled = true;
//         document.getElementById('txtdealname').disabled = false;
//         document.getElementById('drpagencycode').disabled = false;
//         document.getElementById('drpsubagcode').disabled = false;
//         document.getElementById('drpclientname').disabled = false;
//         document.getElementById('drpproduct').disabled = false;
//         document.getElementById('drprepresentative').disabled = false;
//         document.getElementById('txtfromdate').disabled = false;
//         document.getElementById('txtremark').disabled = false;
//         document.getElementById('TextBox1').disabled = false;
//         document.getElementById('drpcurr').disabled = true;
//         document.getElementById('txtdealvol').disabled = false;
//         document.getElementById('txtdealvalue').disabled = false;
//         document.getElementById('drpteamname').disabled = false;
//         document.getElementById('drpdealtype').disabled = true;
//         document.getElementById('drpdealtype').disabled = true;
//         document.getElementById('chkb2b').disabled = false;
//         document.getElementById('chkmultiad').disabled = false;
//         document.getElementById('chkseqno').disabled = false;
//         document.getElementById('txtseq').disabled = false;
//         document.getElementById('chkpatricularad').disabled = false;
//         document.getElementById('drpindustry').disabled = false;
//         document.getElementById('lstproduct').disabled = false;

//         //document.getElementById('drpadtype').disabled = true;
//         if (document.getElementById('txtdealvol').value != "") {
//             document.getElementById('txtdealvalue').disabled = true;
//         }
//         if (document.getElementById('txtdealvalue').value != "") {
//             document.getElementById('txtdealvol').disabled = true;
//         }
//         document.getElementById('tblGrid').disabled = false;
//         document.getElementById('tblGridelec').disabled = false;
         saveormodify = "1";
         chkstatus1(document.getElementById('hiddenflagstatus').value);
         //    getbuttoncheck(formname);
                 document.getElementById('btnSave').disabled=true ;
         setButtonImages();
         return false;

     }
     else {
         mode = "modify";
         document.getElementById('hiddenflagstatus').value = "5";
         document.getElementById('hiddenname').value = document.getElementById('txtdealname').value;
         //document.getElementById('lbcontractdetails').disabled = false;
         document.getElementById('hiddenmodify').value = "1";
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

         ContractMaster.blankvalueInsertSession();
         document.getElementById('hiddenforpop').value = "2";
         saving = "1";
         //document.getElementById('drpdealon').disabled=false;
         document.getElementById('cmdAddRow').disabled = false;
         document.getElementById('cmdAddRowelec').disabled = false;
         document.getElementById('txtexecutive').disabled = false;
         document.getElementById('txtretainer').disabled = false;
         document.getElementById('txtcontractdate').disabled = false;
         document.getElementById('txtclosedate').disabled = false;
         document.getElementById('drpservicetax').disabled = false;
         document.getElementById('txtcaption').disabled = false;
         document.getElementById('drppaymenttype').disabled = false;
         document.getElementById('txtdealno').disabled = true;
         document.getElementById('txtdealname').disabled = false;
         document.getElementById('drpagencycode').disabled = false;
         document.getElementById('drpsubagcode').disabled = false;
         document.getElementById('drpclientname').disabled = false;
         document.getElementById('drpproduct').disabled = false;
         document.getElementById('drprepresentative').disabled = false;
         document.getElementById('txtfromdate').disabled = false;
         document.getElementById('txtremark').disabled = false;
         document.getElementById('TextBox1').disabled = false;
         document.getElementById('drpcurr').disabled = true;
         document.getElementById('txtdealvol').disabled = false;
         document.getElementById('txtdealvalue').disabled = false;
         document.getElementById('drpteamname').disabled = false;
         document.getElementById('drpdealtype').disabled = true;
         document.getElementById('drpdealtype').disabled = true;
         document.getElementById('chkb2b').disabled = false;
         document.getElementById('chkmultiad').disabled = false;
         document.getElementById('chkseqno').disabled = false;
         document.getElementById('txtseq').disabled = false;
         document.getElementById('chkpatricularad').disabled = false;
         document.getElementById('drpindustry').disabled = false;
         document.getElementById('lstproduct').disabled = false;
         document.getElementById('attachment1').disabled = false;
//         document.getElementById('drpcenter').value = "0";
//         document.getElementById('drptransation').value = "N";
         document.getElementById('drpcenter').disabled = false;
         document.getElementById('drptransation').disabled = false;
      
 document.getElementById('txtrono').disabled = false;
document.getElementById('txtrodate').disabled = false;
 document.getElementById('drprostatus').disabled = false;
document.getElementById('drprptcurrency').disabled = false;
         //document.getElementById('drpadtype').disabled = true;
         if (document.getElementById('txtdealvol').value != "") {
             document.getElementById('txtdealvalue').disabled = true;
         }
         if (document.getElementById('txtdealvalue').value != "") {
             document.getElementById('txtdealvol').disabled = true;
         }
         document.getElementById('tblGrid').disabled = false;
         document.getElementById('tblGridelec').disabled = false;
         saveormodify = "1";
         chkstatus1(document.getElementById('hiddenflagstatus').value);
         //    getbuttoncheck(formname);
         setButtonImages();
     }
    return false;
}

    function cancelcontract()
    {
        mode="";
        arrlist=null;
        colName="";
        document.getElementById('lblfinalvalue').innerHTML="";
        document.getElementById('drpclientnamelist').innerHTML="";
        document.getElementById('cmdAddRow').disabled=true;
        document.getElementById('cmdAddRowelec').disabled=true;
        document.getElementById('hiddenflagstatus').value="6";
        document.getElementById('hiddenchkq').value = "0";
        //document.getElementById('lbcontractdetails').disabled = true;
        document.getElementById('hiddenmodify').value = "0";
        document.getElementById('tblGrid').disabled=true;
        document.getElementById('tblGridelec').disabled=true;
        document.getElementById('attachment1').src = "Images/index.jpeg"
         deleteClickGrid();
        //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 

ContractMaster.blankvalueInsertSession();
           document.getElementById('chkb2b').disabled=true;
        document.getElementById('chkmultiad').disabled=true;
        document.getElementById('chkseqno').disabled=true;
        document.getElementById('txtseq').disabled=true;
        document.getElementById('chkpatricularad').disabled=true;
        document.getElementById('drpindustry').disabled=true;
        document.getElementById('lstproduct').disabled=true;
        document.getElementById('chkb2b').checked=false;
document.getElementById('chkmultiad').checked=false;
document.getElementById('chkseqno').checked=false;
document.getElementById('txtseq').value="";
document.getElementById('chkpatricularad').checked=false;
document.getElementById('drpindustry').value="0";
document.getElementById('lstproduct').options.length=0;
        document.getElementById('hiddenforpop').value = "1";
        saving = "0";
        chkquery = "0";
        document.getElementById('txtdealno').value = "";
        ddealcode = "";
        dagencycode="";
        dsubagency="";
        dclient="";
        dproduct="";
        dreprest="";
        ddealtype="";
        ddealname="";
        document.getElementById('drpagencycode').value = "";
        document.getElementById('AgencyCode').value = "";
        document.getElementById('drpsubagcode').value = "0";
        if(document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('drpagencycode').focus();
        }
        else if(document.getElementById("divclient").style.display=="block")
        {
            document.getElementById("divclient").style.display="none"
            document.getElementById('drpclientname').focus();
        }
        document.getElementById('drpclientname').value = "";
        dclient = "";
        document.getElementById('drpproduct').value = "0";
        dproduct = "";
        document.getElementById('drprepresentative').value = "0";
        dreprest = "";
        document.getElementById('txtfromdate').value = "";
        document.getElementById('TextBox1').value = "";
        document.getElementById('txtdealvalue').value = "";
        document.getElementById('txtdealvol').value = "";
        document.getElementById('drpteamname').value = "0";
        document.getElementById('drpdealtype').value = "0";
      //  document.getElementById('drpcurr').value = Session["currency"].ToString();
        document.getElementById('drpdealtype').disabled = true;
        document.getElementById('txtdealname').value = "";
         document.getElementById('txtremark').value="";
          document.getElementById('txtremark').disabled=true;
        document.getElementById('txtdealname').disabled = true;
        //document.getElementById('drpadtype').value = "0";
        //document.getElementById('drpadtype').disabled = true;
        document.getElementById('txtdealno').disabled = true;
        document.getElementById('drpagencycode').disabled = true;
        document.getElementById('drpsubagcode').disabled = true;
        document.getElementById('drpclientname').disabled = true;
        document.getElementById('drpproduct').disabled = true;
        document.getElementById('drprepresentative').disabled = true;
//        document.getElementById('txttilldate').disabled = true;
//        document.getElementById('validfrom').disabled = true;
        document.getElementById('txtdealvalue').disabled = true;
        document.getElementById('txtdealvol').disabled = true;
        document.getElementById('drpcurr').disabled = true;
        document.getElementById('drpteamname').disabled = true;
        document.getElementById('txtfromdate').disabled = true;
        document.getElementById('TextBox1').disabled = true;
        document.getElementById('txtretainer').value='';
      //  document.getElementById('txtcontractdate').value='';
        document.getElementById('txtclosedate').value=""; 
        //document.getElementById('drpservicetax').value="Y";  
        document.getElementById('txtcaption').value=""; 
        document.getElementById('txtexecutive').value='';
        for(var n=0;n<document.getElementById('drppaymenttype').options.length;n++)
        {
        document.getElementById('drppaymenttype').options[n].selected=false; 
        }
         document.getElementById('txtretainer').disabled = true;
        document.getElementById('txtcontractdate').disabled = true;
        document.getElementById('txtclosedate').disabled = true;
        document.getElementById('drpservicetax').disabled = true;
        document.getElementById('txtcaption').disabled = true;
        document.getElementById('txtexecutive').disabled = true;
        document.getElementById('drppaymenttype').disabled = true;
        document.getElementById('txtrono').value="";
        document.getElementById('txtrono').disabled = true;
    document.getElementById('txtrodate').value="";
     document.getElementById('txtrodate').disabled = true;
    document.getElementById('drprostatus').value="0";
    document.getElementById('drprostatus').disabled = true;
     document.getElementById('drprptcurrency').value=document.getElementById('hiddencurrency').value;
      document.getElementById('drprptcurrency').disabled = true;
      //  ScriptManager1.SetFocus(btnNew);

        document.getElementById('txtdealvalue').style.backgroundColor= "white";
        document.getElementById('txtdealvol').style.backgroundColor= "white";
        document.getElementById('attachment1').disabled = true;
        document.getElementById('hidattach1').value = '';
        saveormodify="0";
        fpnl = 0;
        document.getElementById('drpcenter').value = "0";
        document.getElementById('drptransation').value = "N";
        document.getElementById('drpcenter').disabled = true;
        document.getElementById('drptransation').disabled = true;
        
        document.getElementById('txtdealfrom').value = document.getElementById('centarnamejs').value;
       // getbuttoncheck(formname);
        chkstatus1(document.getElementById('hiddenflagstatus').value);
      //  fillGridView(document.getElementById('txtdealno').value);
        if(FlagStatus==7 || FlagStatus==15 || FlagStatus==11 || FlagStatus==13 || FlagStatus==9 || FlagStatus==1 || FlagStatus==5 || FlagStatus==3)
            document.getElementById('btnNew').disabled = false;
        document.getElementById('btnNew').focus();
    setButtonImages();
     //   bindgridview("Advcategory");      
        return false;
    }

    function newClick()
    {
       saveormodify = "0";      
       colName="";
       saving = "0";
       chkquery = "0";
        document.getElementById('txtremark').value="";
         document.getElementById('txtremark').disabled=false;
       if (document.getElementById('hiddenauto').value == "1")
        {
            document.getElementById('txtdealname').disabled = false;
            document.getElementById('txtdealno').disabled = true;
            document.getElementById('txtdealname').focus();
        }
        else
        {
            document.getElementById('txtdealno').disabled = false;
            document.getElementById('txtdealno').focus();
        }
        document.getElementById('attachment1').disabled = false;
        document.getElementById('hidattach1').value = '';
        document.getElementById('attachment1').src = "Images/index.jpeg"
        document.getElementById('txtexecutive').value='';
        document.getElementById('txtretainer').value='';
        //document.getElementById('txtcontractdate').value='';
        document.getElementById('txtclosedate').value=""; 
        //document.getElementById('drpservicetax').value="Y";  
        document.getElementById('txtcaption').value="";
        document.getElementById('hiddenmodify').value = "0";     
        document.getElementById('hiddenforpop').value = "0";
        
        document.getElementById('txtdealno').value = "";
        document.getElementById('drpagencycode').value = "";
        document.getElementById('drpsubagcode').value = "0";
        document.getElementById('drpclientname').value = "";
        document.getElementById('drpproduct').value = "0";
        document.getElementById('drprepresentative').value = "0";
        document.getElementById('TextBox1').vaue = "";
        document.getElementById('txtfromdate').value = "";

        document.getElementById('hiddenchkq').value = "0";

        document.getElementById('txtdealvalue').value = "";
        document.getElementById('txtdealvol').value = "";
        document.getElementById('drpteamname').value = "0";
        document.getElementById('drpdealtype').value = "0";
        document.getElementById('txtdealname').value = "";
        document.getElementById('drpcenter').value = "0";
        document.getElementById('drptransation').value = "N";
        document.getElementById('txtdealfrom').value = document.getElementById('centarnamejs').value;
        //document.getElementById('drpadtype').value = "0";
        document.getElementById('drpdealon').disabled=false;
        document.getElementById('drpdealon').value="print";
        document.getElementById('chkb2b').disabled=false;
        document.getElementById('chkmultiad').disabled=false;
        document.getElementById('chkseqno').disabled=false;
        document.getElementById('txtseq').disabled=false;
        document.getElementById('chkpatricularad').disabled=false;
        document.getElementById('drpindustry').disabled=false;
        document.getElementById('lstproduct').disabled=false;
        document.getElementById('chkb2b').checked=false;
document.getElementById('chkmultiad').checked=false;
document.getElementById('chkseqno').checked = false;

document.getElementById('drpcenter').disabled = false;
document.getElementById('drptransation').disabled = false;
document.getElementById('txtseq').value="";
document.getElementById('chkpatricularad').checked=false;
document.getElementById('drpindustry').value="0";
document.getElementById('lstproduct').options.length=0;;

         document.getElementById('cmdAddRow').disabled=false;
        document.getElementById('cmdAddRowelec').disabled=false;
         document.getElementById('tblGrid').disabled=false;
        document.getElementById('tblGridelec').disabled=false;
        document.getElementById('txtcontractdate').disabled = false;
        document.getElementById('txtclosedate').disabled = false;
         document.getElementById('txtcaption').disabled = false;
         document.getElementById('drppaymenttype').disabled = false;
         document.getElementById('drpservicetax').disabled = false;
         document.getElementById('txtexecutive').disabled = false;
         document.getElementById('txtretainer').disabled = false;
         
        document.getElementById('txtdealname').disabled = false;
       // document.getElementById('drpadtype').disabled = false;
       
        document.getElementById('drpagencycode').disabled = false;
        document.getElementById('drpsubagcode').disabled = false;
        document.getElementById('drpclientname').disabled = false;
        document.getElementById('drpproduct').disabled = false;
        document.getElementById('drprepresentative').disabled = false;
        document.getElementById('TextBox1').disabled = false;
        document.getElementById('txtfromdate').disabled = false;
        document.getElementById('totaldealvolume').disabled = false;
        document.getElementById('totaldealvalue').disabled = false;

        document.getElementById('txtdealvalue').disabled = false;
        document.getElementById('txtdealvol').disabled = false;
        document.getElementById('drpcurr').disabled = false;
        document.getElementById('drpteamname').disabled = false;
        document.getElementById('drpdealtype').disabled = false;
       // document.getElementById('lbcontractdetails').disabled = false;        

        document.getElementById('txtexecutive').disabled = false;
    document.getElementById('txtretainer').disabled = false;
    document.getElementById('txtcontractdate').disabled = false;
    document.getElementById('txtclosedate').disabled = false;
    document.getElementById('drpservicetax').disabled = false;
    document.getElementById('txtcaption').disabled = false;
    document.getElementById('drppaymenttype').disabled = false;
    
    document.getElementById('txtrono').disabled = false;
    document.getElementById('txtrodate').disabled = false;
    document.getElementById('drprostatus').disabled = false;
    document.getElementById('drprptcurrency').disabled = false;
    document.getElementById('txtrono').value="";
    document.getElementById('txtrodate').value="";
    document.getElementById('drprostatus').value="0";
     document.getElementById('drprptcurrency').value=document.getElementById('hiddencurrency').value;
        chkstatus1(document.getElementById('hiddenflagstatus').value);        

 document.getElementById('drpclientnamelist').innerHTML="";  
    ////////////////////////this is for autogenerated code
        if (document.getElementById('hiddenauto').value == "1" && chkquery == "0")
        {
            autogenerated();
        }
        setButtonImages();
        return false;
    }
 
    
     function autogenerated()
     {
        document.getElementById('txtdealno').disabled = true;
        var auto = "CM";
        var autogen = auto + cou;
        var res=ContractMaster.autogenerateID(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,auto);
        var da = res.value;
        if(da==null)
        {
            alert(res.error.description);
            return false;
        }
        if (da.Tables[0].Rows.length > 0 && da.Tables[0].Rows[0].code!="")
        {
            var ab = da.Tables[0].Rows[0].code;
            var cou1=parseInt(ab);
            cou1++;            
            document.getElementById('txtdealno').value = auto + cou1;
        }
        else
        {
            document.getElementById('txtdealno').value = autogen;
        }
    }
    
    function dealType_Change()
    {if(document.getElementById('drpdealtype').selectedIndex==-1)
    {
    document.getElementById('drpdealtype').selectedIndex=0;
    }
        if (document.getElementById('drpdealtype').options[document.getElementById('drpdealtype').selectedIndex].text == "VALUE")
        {
            document.getElementById('txtdealvalue').disabled = false;
            document.getElementById('txtdealvol').disabled = true;
            document.getElementById('txtdealvol').readOnly = true;
            document.getElementById('txtdealvol').style.backgroundColor= "gray";
            document.getElementById('txtdealvalue').style.backgroundColor= "white";
            document.getElementById('txtdealvalue').readOnly = false;
            document.getElementById('txtdealvol').value = "";

        }
        else if (document.getElementById('drpdealtype').options[document.getElementById('drpdealtype').selectedIndex].text  == "VOLUME")
        {
            document.getElementById('txtdealvalue').disabled = true;
            document.getElementById('txtdealvalue').value = "";
            document.getElementById('txtdealvol').disabled = false;
            document.getElementById('txtdealvalue').readOnly = true;
            document.getElementById('txtdealvalue').style.backgroundColor= "gray";
            document.getElementById('txtdealvol').style.backgroundColor= "white";
            document.getElementById('txtdealvol').disabled = false;
            document.getElementById('txtdealvol').readOnly = false;

        }
        else if (document.getElementById('drpdealtype').options[document.getElementById('drpdealtype').selectedIndex].text  == "INSERTS")
        {
            document.getElementById('txtdealvalue').disabled = true;
            document.getElementById('txtdealvalue').value = "";
            document.getElementById('txtdealvol').value = "";
            document.getElementById('txtdealvol').disabled = true;
            document.getElementById('txtdealvalue').readOnly = false;
            document.getElementById('txtdealvalue').style.backgroundColor= "gray";
            document.getElementById('txtdealvol').style.backgroundColor= "gray";
            document.getElementById('txtdealvol').disabled = true;
            document.getElementById('txtdealvol').readOnly = false;

        }
        else if (document.getElementById('drpdealtype').options[document.getElementById('drpdealtype').selectedIndex].text  == "FIXED RATE")
        {
            document.getElementById('txtdealvalue').disabled = true;
            document.getElementById('txtdealvalue').value = "";
            document.getElementById('txtdealvol').value = "";
            document.getElementById('txtdealvol').disabled = true;
            document.getElementById('txtdealvalue').readOnly = false;
            document.getElementById('txtdealvalue').style.backgroundColor= "gray";
            document.getElementById('txtdealvol').style.backgroundColor= "gray";
            document.getElementById('txtdealvol').disabled = true;
            document.getElementById('txtdealvol').readOnly = false;

        }
        else
        {
            document.getElementById('txtdealvalue').disabled = false;
            document.getElementById('txtdealvalue').value = "";
            document.getElementById('txtdealvalue').readOnly = false;
            document.getElementById('txtdealvol').disabled = false;
            document.getElementById('txtdealvol').value = "";
            document.getElementById('txtdealvol').readOnly = false;
            document.getElementById('txtdealvol').style.backgroundColor= "gray";
            document.getElementById('txtdealvalue').style.backgroundColor= "white";
        }
        return false;
    }
    
    function agency_change()
    {
//        if (document.getElementById('hiddenmodify').value != "2")
//        {
//            if (document.getElementById('drpdealtype').value == "0")
//            {
//                var message = "Please select the value from deal type";
//                alert(message);
//                document.getElementById('drpagencycode').value = "";
//                return false;

//            }
//        }
     
        var agencysplit = document.getElementById('drpagencycode').value;
        var agencyarr=agencysplit.split("(");             
		 var agency=agencyarr[1];             
		 agency=agency.replace(")","");
        var res=ContractMaster.agencyChange(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,agency)
        var ds = res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
      

        document.getElementById('drpsubagcode').options.length=0;
        document.getElementById('drpsubagcode').options[0]=new Option("-Select Sub Agency-","0");
        document.getElementById('drpsubagcode').options.length;

        for (var j = 0; j <= ds.Tables[0].Rows.length - 1; j++)
        {
            document.getElementById('drpsubagcode').options[document.getElementById('drpsubagcode').options.length] = new Option(ds.Tables[0].Rows[j].Agency_Name+"--"+ds.Tables[0].Rows[j].SUB_Agency_Code,ds.Tables[0].Rows[j].SUB_Agency_Code);
            document.getElementById('drpsubagcode').options.length;
        }
         if (document.getElementById('drpsubagcode').options.length > 1)
              document.getElementById('drpsubagcode').selectedIndex = 1;
          else
              document.getElementById('drpsubagcode').value = "0";
        return false;
    }
    
    function clientChange()
    {
//        var client = document.getElementById('drpclientname').value
            var client=document.getElementById('drpclientname').value ;  
            if(client.indexOf("(")>=0)
            {          
		     var agencyarr=client.split("(");             
		     var client=agencyarr[1];             
		     client=client.replace(")","");
        res=ContractMaster.client_Change(client,document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value);
        var ds=res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
     

        document.getElementById('drpproduct').options.length=0;
        document.getElementById('drpproduct').options[0]=new Option("Product","0");
        document.getElementById('drpproduct').options.length;


        for (var j = 0; j <= ds.Tables[0].Rows.length - 1; j++)
        {
            document.getElementById('drpproduct').options[document.getElementById('drpproduct').options.length] = new Option(ds.Tables[0].Rows[j].Product_Name,ds.Tables[0].Rows[j].Product_Code);
            document.getElementById('drpproduct').options.length;

        }
        
        return false;
        }
  }  
  function teamName_Change()
  {
        var name = document.getElementById('drpteamname').value;
        var res=ContractMaster.teamName(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,name);
        var ds=res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
        
       
        if (ds.Tables[0].Rows.length >= 0)
        {
            document.getElementById('drprepresentative').options.length=0;
            document.getElementById('drprepresentative').options[0]=new Option("Select Representative","0");
            document.getElementById('drprepresentative').options.length;

            if (ds.Tables[0].Rows.length > 0)
            {
                for (var i = 0; i <= ds.Tables[0].Rows.length-1; i++)
                {
                   document.getElementById('drprepresentative').options[document.getElementById('drprepresentative').options.length] = new Option(ds.Tables[0].Rows[i].Exec_name,ds.Tables[0].Rows[i].Exe_no);
                   document.getElementById('drprepresentative').options.length;
                }

            }
        }
        else
        {
            message = "There is no matching value:";
            alert(message);
            return;
        }
        return false;
  }
//  function color_change()
//  {
//        if(document.getElementById('drppackagecode').value!="0")
//            document.getElementById('drpbooked').value=document.getElementById('drppackagecode').options[document.getElementById('drppackagecode').selectedIndex].text;
//        getCardRate();
//        return false;
//  }

function date_frmt_orcl_no(dateformat,value1)
{
    var dd="";
    var mm="";
    var yy="";
    var newdate="";
    if(dateformat=="dd/mm/yyyy")
    {
        var arrvalue1=value1.split('/');
        dd=arrvalue1[0];
        mm=arrvalue1[1];
        yy=arrvalue1[2];        
    }
    else if(dateformat=="mm/dd/yyyy")
    {
        var arrvalue1=value1.split('/');
        dd=arrvalue1[1];
        mm=arrvalue1[0];
        yy=arrvalue1[2];        
    }
    else if(dateformat=="yyyy/mm/dd")
    {
        var arrvalue1=value1.split('/');
        dd=arrvalue1[2];
        mm=arrvalue1[1];
        yy=arrvalue1[0];        
    }
    //mm=getmonthstr(mm);
    
    newdate=mm + "/" + dd + "/" + yy;
    
    return newdate;    
}

//function getCardRate()
//{
//    if(document.getElementById('drpadvcat').value != "0" && document.getElementById('drppackagecode').value != "0" && document.getElementById('drpuom').value != "0" && document.getElementById('drpcurr').value != "0")
//    {
//        var adcat = document.getElementById('drpadvcat').value;
//        var pkgcode = document.getElementById('drppackagecode').value;
//        var color = document.getElementById('drpcolor').value;
//        var currency = document.getElementById('drpcurr').value;
//        var uom = document.getElementById('drpuom').value;
//        var validfrom = document.getElementById('hiddenfromdate').value; //date_frmt_orcl_no(document.getElementById('hiddendateformat').value, document.getElementById('hiddenfromdate').value);
//        var validto = document.getElementById('hiddentodate').value; //date_frmt_orcl_no(document.getElementById('hiddendateformat').value, document.getElementById('hiddentodate').value);
//        var res=ContractDetail.getrateforcontract(adcat, pkgcode, color, currency, uom, document.getElementById('hiddenadtype').value, validfrom, validto, document.getElementById('hiddencompcode').value,document.getElementById('hiddendateformat').value);
//        var dcon=res.value;
//        if(dcon==null)
//        {
//            alert(res.error.description);
//            return false;
//        }            

//        if (dcon.Tables[0].Rows.length > 0)
//        {
//            document.getElementById('txtcardrate').value = dcon.Tables[0].Rows[0].Week_Day_Rate;

//        }
//    }
//}

function publication_change()
{
    var pubcode = document.getElementById('drppublication').value;
    var res=ContractDetail.editionbind(document.getElementById('hiddencompcode').value,pubcode);
    var ds=res.value;
    if(ds==null)
    {
        alert(res.error.description);
        return false;
    }
     
        if (ds.Tables[0].Rows.length >= 0)
        {
            document.getElementById('drpedition').options.length=0;
             document.getElementById('drpedition').options[0]=new Option("Select Edition","0");
            document.getElementById('drpedition').options.length;

            if (ds.Tables[0].Rows.length > 0)
            {
                for (var i = 0; i < ds.Tables[0].Rows.length; i++)
                {
                   document.getElementById('drpedition').options[document.getElementById('drpedition').options.length] = new Option(ds.Tables[0].Rows[0].Edition_Name,ds.Tables[0].Rows[0].Edition_Code);
                   document.getElementById('drpedition').options.length;
                }

            }
        }
        else
        {
            message = "There is no data for the selected publication";
            alert(message);
            return false;
        }

        if (pubcode != "0")
        {
            document.getElementById('drppackagecode').disabled = true;
            document.getElementById('drppackagecode').value = "0";
            document.getElementById('drpbooked').value = "";
        }
        else
        {
            document.getElementById('drppackagecode').disabled = false;
            document.getElementById('drppackagecode').value = "0";
            //drppackagecode.Text = "";
            document.getElementById('drpedition').options.length=0;
            document.getElementById('drpsuppliment').options.length=0;
            //drpsuppliment.SelectedItem.Text = null;
            //drpsuppliment.Text = "";

        }
        return false;
}

function edition_change()
{
        var editioncode = document.getElementById('drpedition').value;
        var res=ContractDetail.supplimentbind(document.getElementById('hiddencompcode').value,editioncode);
        var ds=res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
        
        if (ds.Tables[0].Rows.length - 1 >= 0)
        {
            document.getElementById('drpsuppliment').options.length=0;
              document.getElementById('drpsuppliment').options[0]=new Option("Select Suppliment","0");
            document.getElementById('drpsuppliment').options.length;

            if (ds.Tables[0].Rows.length > 0)
            {
                for (var i = 0; i < ds.Tables[0].Rows.length; i++)
                {
                   document.getElementById('drpsuppliment').options[document.getElementById('drpsuppliment').options.length] = new Option(ds.Tables[0].Rows[0].Supp_Name,ds.Tables[0].Rows[0].Supp_Code);
                   document.getElementById('drpsuppliment').options.length;
                }

            }
        }
        else
        {
            message = "There is no data for selected Edition";
            alert(message);
            return false;
        }
        return false;
}

function bindgridview(sortfield)
{
  //  var res = ContractMaster.BindDataGrid(document.getElementById('txtdealno').value);
    var res = ContractMaster.BindDataGrid(sortfield);
    if(document.getElementById("GridView1")!=null)
        document.getElementById("GridView1").outerHTML = res.value;
}

//bind gridview
function fillGridView(sortfield)
{
   var res = ContractMaster.GetgridInfo(sortfield);
   var ds_Grid=res.value ;
   if(ds_Grid==null)
   {
       alert(res.error.description);
       return false;
   }
   if(GridView1.rows.length>1)
   {
        for(var j=1;j<GridView1.rows.length;j++)
            GridView1.deleteRow(j);
   }
   if(ds_Grid.Tables[0].Rows.length!=0)
   {
        for(var i=1;i<=ds_Grid.Tables[0].Rows.length;i++)
        {
             var GridViewNewRow=GridView1.insertRow(i);
             var cell1=GridViewNewRow.insertCell(0);
             var cell2=GridViewNewRow.insertCell(1); 
             var cell3=GridViewNewRow.insertCell(2);
             var cell4=GridViewNewRow.insertCell(3);
             var cell5=GridViewNewRow.insertCell(4);
             var cell6=GridViewNewRow.insertCell(5);
             var cell7=GridViewNewRow.insertCell(6);
             var cell8=GridViewNewRow.insertCell(7);
             var cell9=GridViewNewRow.insertCell(8);
             var cell10=GridViewNewRow.insertCell(9);
             var cell11=GridViewNewRow.insertCell(10);
             var cell12=GridViewNewRow.insertCell(11);
             var cell13=GridViewNewRow.insertCell(12);
             var cell14=GridViewNewRow.insertCell(13);
             var cell15=GridViewNewRow.insertCell(14);
             var cell16=GridViewNewRow.insertCell(15);
             var cell17=GridViewNewRow.insertCell(16);
             var cell18=GridViewNewRow.insertCell(17);
             var cell19=GridViewNewRow.insertCell(18);
             var cell20=GridViewNewRow.insertCell(19);
             var cell21=GridViewNewRow.insertCell(20);
             var cell22=GridViewNewRow.insertCell(21);
             
              var cell23=GridViewNewRow.insertCell(22);
              var cell24=GridViewNewRow.insertCell(23);
              var cell25=GridViewNewRow.insertCell(24);
              var cell26=GridViewNewRow.insertCell(25);
              var cell27=GridViewNewRow.insertCell(26);
               var cell28=GridViewNewRow.insertCell(27);
               
                var cell29=GridViewNewRow.insertCell(28);
                var cell30=GridViewNewRow.insertCell(29);
                var cell31=GridViewNewRow.insertCell(30);
                var cell32=GridViewNewRow.insertCell(31);
             
             cell1.appendChild(GridView1);
             cell2.appendChild(GridView1);
             cell3.appendChild(GridView1);
             cell4.appendChild(GridView1);
             cell5.appendChild(GridView1);
             cell6.appendChild(GridView1);
             cell7.appendChild(GridView1);
             cell8.appendChild(GridView1);
             cell9.appendChild(GridView1);
             cell10.appendChild(GridView1);
             cell11.appendChild(GridView1);
             cell12.appendChild(GridView1);
             cell13.appendChild(GridView1);
             cell14.appendChild(GridView1);
             cell15.appendChild(GridView1);
             cell16.appendChild(GridView1);
             cell17.appendChild(GridView1);
             cell18.appendChild(GridView1);
             cell19.appendChild(GridView1);
             cell20.appendChild(GridView1);
             cell21.appendChild(GridView1);
             cell22.appendChild(GridView1);
             
             cell23.appendChild(GridView1);
             cell24.appendChild(GridView1);
             cell25.appendChild(GridView1);
             cell26.appendChild(GridView1);
             cell27.appendChild(GridView1);
              cell28.appendChild(GridView1);
               cell29.appendChild(GridView1);
               cell30.appendChild(GridView1);
               cell31.appendChild(GridView1);
               cell32.appendChild(GridView1);
             
             if(ds_Grid.Tables[0].Rows[i-1]["Advcategory"]==null)
                ds_Grid.Tables[0].Rows[i-1]["Advcategory"]="";
             else
                document.getElementById("GridView1").rows[i].cells[0].innerHTML=ds_Grid.Tables[0].Rows[i-1]["Advcategory"];
            if(ds_Grid.Tables[0].Rows[i-1]["packagecode"]==null)
                ds_Grid.Tables[0].Rows[i-1]["packagecode"]="";
            else
                document.getElementById("GridView1").rows[i].cells[1].innerHTML=ds_Grid.Tables[0].Rows[i-1]["packagecode"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["Bookedfor"]==null)
                ds_Grid.Tables[0].Rows[i-1]["Bookedfor"]="";
            else
                document.getElementById("GridView1").rows[i].cells[2].innerHTML=ds_Grid.Tables[0].Rows[i-1]["Bookedfor"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["color"]==null)
                ds_Grid.Tables[0].Rows[i-1]["color"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[3].innerHTML=ds_Grid.Tables[0].Rows[i-1]["color"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["cardrate"]==null)
                ds_Grid.Tables[0].Rows[i-1]["cardrate"]="";
            else
                document.getElementById("GridView1").rows[i].cells[4].innerHTML=ds_Grid.Tables[0].Rows[i-1]["cardrate"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["Dealarte"]==null)
                ds_Grid.Tables[0].Rows[i-1]["Dealarte"]="";
            else
                document.getElementById("GridView1").rows[i].cells[5].innerHTML=ds_Grid.Tables[0].Rows[i-1]["Dealarte"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["deviation"]==null)
                ds_Grid.Tables[0].Rows[i-1]["deviation"]="";
            else
                document.getElementById("GridView1").rows[i].cells[6].innerHTML=ds_Grid.Tables[0].Rows[i-1]["deviation"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["premiumcode"]==null)
                ds_Grid.Tables[0].Rows[i-1]["premiumcode"]="";
            else
                document.getElementById("GridView1").rows[i].cells[7].innerHTML=ds_Grid.Tables[0].Rows[i-1]["premiumcode"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["cardpremium"]==null)
                ds_Grid.Tables[0].Rows[i-1]["cardpremium"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[8].innerHTML=ds_Grid.Tables[0].Rows[i-1]["cardpremium"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["dealpremium"]==null)
                ds_Grid.Tables[0].Rows[i-1]["dealpremium"]="";
            else   
                document.getElementById("GridView1").rows[i].cells[9].innerHTML=ds_Grid.Tables[0].Rows[i-1]["dealpremium"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["Uom"]==null)
                ds_Grid.Tables[0].Rows[i-1]["Uom"]="";
            else
                document.getElementById("GridView1").rows[i].cells[10].innerHTML=ds_Grid.Tables[0].Rows[i-1]["Uom"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["volumebilled"]==null)
                ds_Grid.Tables[0].Rows[i-1]["volumebilled"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[11].innerHTML=ds_Grid.Tables[0].Rows[i-1]["volumebilled"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["volumedisc"]==null)
                ds_Grid.Tables[0].Rows[i-1]["volumedisc"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[12].innerHTML=ds_Grid.Tables[0].Rows[i-1]["volumedisc"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["currency"]==null)
                ds_Grid.Tables[0].Rows[i-1]["currency"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[13].innerHTML=ds_Grid.Tables[0].Rows[i-1]["currency"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["valuefrom"]==null)
                ds_Grid.Tables[0].Rows[i-1]["valuefrom"]="";
            else
                document.getElementById("GridView1").rows[i].cells[14].innerHTML=ds_Grid.Tables[0].Rows[i-1]["valuefrom"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["valueto"]==null)
                ds_Grid.Tables[0].Rows[i-1]["valueto"]="";
            else
                document.getElementById("GridView1").rows[i].cells[15].innerHTML=ds_Grid.Tables[0].Rows[i-1]["valueto"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["convertrate"]==null)
                ds_Grid.Tables[0].Rows[i-1]["convertrate"]="";
            else
                document.getElementById("GridView1").rows[i].cells[16].innerHTML=ds_Grid.Tables[0].Rows[i-1]["convertrate"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["Rate_code"]==null)
                ds_Grid.Tables[0].Rows[i-1]["Rate_code"]="";
            else
                document.getElementById("GridView1").rows[i].cells[17].innerHTML=ds_Grid.Tables[0].Rows[i-1]["Rate_code"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["approved"]==null)
                ds_Grid.Tables[0].Rows[i-1]["approved"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[18].innerHTML=ds_Grid.Tables[0].Rows[i-1]["approved"];
            
            if(ds_Grid.Tables[0].Rows[i-1]["quantity"]==null)
                ds_Grid.Tables[0].Rows[i-1]["quantity"]="";
            else
                document.getElementById("GridView1").rows[i].cells[19].innerHTML=ds_Grid.Tables[0].Rows[i-1]["quantity"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["weight"]==null)
                ds_Grid.Tables[0].Rows[i-1]["weight"]="";
            else
                document.getElementById("GridView1").rows[i].cells[20].innerHTML=ds_Grid.Tables[0].Rows[i-1]["weight"];
                
            if(ds_Grid.Tables[0].Rows[i-1]["discounted"]==null)
                ds_Grid.Tables[0].Rows[i-1]["discounted"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[21].innerHTML=ds_Grid.Tables[0].Rows[i-1]["discounted"];   
                
              if(ds_Grid.Tables[0].Rows[i-1]["REMARKS"]==null)
                ds_Grid.Tables[0].Rows[i-1]["REMARKS"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[22].innerHTML=ds_Grid.Tables[0].Rows[i-1]["REMARKS"];  
                
            if(ds_Grid.Tables[0].Rows[i-1]["SIZEFROM"]==null)
                ds_Grid.Tables[0].Rows[i-1]["SIZEFROM"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[23].innerHTML=ds_Grid.Tables[0].Rows[i-1]["SIZEFROM"]; 
                
            if(ds_Grid.Tables[0].Rows[i-1]["SIZETO"]==null)
                ds_Grid.Tables[0].Rows[i-1]["SIZETO"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[24].innerHTML=ds_Grid.Tables[0].Rows[i-1]["SIZETO"]; 
                
            if(ds_Grid.Tables[0].Rows[i-1]["DISCPER"]==null)
                ds_Grid.Tables[0].Rows[i-1]["DISCPER"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[26].innerHTML=ds_Grid.Tables[0].Rows[i-1]["DISCPER"]; 
                
            if(ds_Grid.Tables[0].Rows[i-1]["INSERTION"]==null)
                ds_Grid.Tables[0].Rows[i-1]["INSERTION"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[27].innerHTML=ds_Grid.Tables[0].Rows[i-1]["INSERTION"]; 
                
            if(ds_Grid.Tables[0].Rows[i-1]["DAYNAME"]==null)
                ds_Grid.Tables[0].Rows[i-1]["DAYNAME"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[28].innerHTML=ds_Grid.Tables[0].Rows[i-1]["DAYNAME"];      
                
            if(ds_Grid.Tables[0].Rows[i-1]["COMMITION_ALLOW"]==null)
                ds_Grid.Tables[0].Rows[i-1]["COMMITION_ALLOW"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[29].innerHTML=ds_Grid.Tables[0].Rows[i-1]["COMMITION_ALLOW"];      
                
            if(ds_Grid.Tables[0].Rows[i-1]["DEAL_START"]==null)
                ds_Grid.Tables[0].Rows[i-1]["DEAL_START"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[30].innerHTML=ds_Grid.Tables[0].Rows[i-1]["DEAL_START"];      
            
             if(ds_Grid.Tables[0].Rows[i-1]["INCENTIVE"]==null)
                ds_Grid.Tables[0].Rows[i-1]["INCENTIVE"]="";
            else    
                document.getElementById("GridView1").rows[i].cells[31].innerHTML=ds_Grid.Tables[0].Rows[i-1]["INCENTIVE"];      
                               
         }
     }
         return false;
}
//*************************************


//save  ***********************************************************************************
function savecontract()
{
   // checksavevalidation();
    
  //  document.getElementById('lbcontractdetails').disabled = false;
    var DealNo = document.getElementById('txtdealno').value;
    var dealname = document.getElementById('txtdealname').value;
    var dealtype = document.getElementById('drpdealtype').value;
    var teamname = document.getElementById('drpteamname').value;
         var agency=document.getElementById('drpagencycode').value ; 
         var agencycode="";
         if(agency!="")
         {           
	     var agencyarr=agency.split("(");             
	     var agencycode=agencyarr[1];             
	     agencycode=agencycode.replace(")","");
	     }
//    var agencycode = document.getElementById('drpagencycode').value;
    var subagencycode = document.getElementById('drpsubagcode').value;
    var clientname ="";
    if ((document.getElementById('drpclientnamelist').length !="") && (document.getElementById('drpclientnamelist').length !=null))
    {
var clientname=""
var length=document.getElementById('drpclientnamelist').length;
for(var i=0;i<length;i++)
{
if(length>1)
{
if(clientname=="")
{
clientname=document.getElementById('drpclientnamelist').options[i].value;
}
else
{
clientname = clientname +","+document.getElementById('drpclientnamelist').options[i].value;
}
}
else
{
clientname = document.getElementById('drpclientnamelist').options[i].value;
}
}
        // var clint=document.getElementById('drpclientnamelist').split(',') ;            
	    // var agencyarr=clint.split("(");             
	     //var clientname=agencyarr[1];             
	    // clientname=clientname.replace(")","");
}
    var product = document.getElementById('drpproduct').value;
    var fromdate = document.getElementById('txtfromdate').value;
    var tilldate = document.getElementById('TextBox1').value;
    var representative = document.getElementById('drprepresentative').value;
    var totalvalue = document.getElementById('txtdealvalue').value;
    var totalvolume = document.getElementById('txtdealvol').value;
    var currencys = document.getElementById('drpcurr').value;
    var adtype ="";// document.getElementById('drpadtype').value;
    compcode=document.getElementById('hiddencompcode').value ;
    user_id=document.getElementById('hiddenuserid').value ;
    
    var dsession=ContractMaster.getvalueInsertSession();
////    var valueinsert=document.getElementById('hiddenvalueinsert').value;
    dateformat=document.getElementById('hiddendateformat').value;
    if(dateformat=="" || dateformat == null)
    {
        alert('Please set dateformat');
        return false;
    }

    validfromdate = setDate(dateformat,fromdate);
    validtill = setDate(dateformat, tilldate);
     var executive_var=document.getElementById('txtexecutive').value.substring(document.getElementById('txtexecutive').value.lastIndexOf('(')+1,document.getElementById('txtexecutive').value.lastIndexOf(')'));
                    var retainer_var=document.getElementById('txtretainer').value.substring(document.getElementById('txtretainer').value.lastIndexOf('(')+1,document.getElementById('txtretainer').value.lastIndexOf(')'));
                    var contdate_var=document.getElementById('txtcontractdate').value;
                    var closedate_var=document.getElementById('txtclosedate').value;
                    var servicetax_var=document.getElementById('drpservicetax').value;
                    var caption_var=document.getElementById('txtcaption').value;
                    var paymode_var='';
                    contdate_var = setDate(dateformat,contdate_var);
                    closedate_var = setDate(dateformat, closedate_var);
                    for(var n=0;n<document.getElementById('drppaymenttype').options.length;n++)
                    {
                        if(document.getElementById('drppaymenttype').options[n].selected==true)
                        {
                            if(paymode_var=='')
                                paymode_var=document.getElementById('drppaymenttype').options[n].value;
                            else
                                paymode_var=paymode_var + "," + document.getElementById('drppaymenttype').options[n].value;
                                    
                        }
                    }
        //code for save
         if (saveormodify == "0")
         {   
             ////to check whether the user has also entered the details in contact detail                         
////            ContractMaster.chk_contractdetail(DealNo, compcode,user_id);

//             if (dsession.value=="" || dsession.value==null)
//             {
//                 alert("Please Enter The Contract Details of " + DealNo + " ");
//                 //AspNetMessageBox(message);
//                 return false;
//             }
//             else
//             {
                 var ret=null;
                 ret=ContractMaster.Contract_Code(DealNo, compcode, dealname, dealtype)
                 /////////////this code is to check there should be not any duplicacy in contract name and contract type taken as together
                 var ds3=ret.value;
                 if(ds3==null)
                 {
                    alert(ret.error.description);
                    return false;
                 }
                 
                 if (ds3.Tables[1].Rows.Count > 0)
                 {
                    alert("Contract name and contract type should be unique.");                    
                    return;
                 }                 
                 else
                 {
                     var deal_name = document.getElementById('txtdealname').value;                     
                     var dn = dealname.substring(0, 2);
                                       
                     /////this is to chk the duplicacy for contract master
                     var ret=ContractMaster.chk_unique(agencycode, clientname, product, compcode, adtype);
                     var de=ret.value;
                     if(de==null)
                     {
                        alert(ret.error.description);
                        return false;
                     }
//                     ret=ContractMaster.getvalueInsertSession();
//                     var db1 = ret.value;
//                     var gf1 = db1.Tables.length;
//                     for (var b = 0; b <= gf1 - 1; b++)
//                     {
//                         var advcat = db1.Tables[b].Rows[0].Advcategory;
//                         var color = db1.Tables[b].Rows[0].color;
//                         var package = db1.Tables[b].Rows[0].packagecode;
//                         var ratecode = db1.Tables[b].Rows[0].Rate_code;
//                         var dayname=db1.Tables[b].Rows[0].DAYNAME;
//                         ret=ContractMaster.chk_uniquedetail(advcat, package, ratecode, color, compcode,dayname);
//                         var da=ret.value;
//                         if(da==null)
//                         {
//                            alert(ret.error.description);
//                            return false;
//                         }
//                         

//                         if (de.Tables[0].Rows.Count > 0 && da.Tables[0].Rows.Count > 0)
//                         {
//                             alert('Duplicate contract not allowed');                             
//                             return false;
//                         }                         
//                     }
                   
                       var b2b=document.getElementById('chkb2b').value;
                        if(document.getElementById('chkb2b').checked==false)
                            b2b="N";
                        else
                            b2b="Y";    
                       var chkmulti=document.getElementById('chkmultiad').value; 
                       if(document.getElementById('chkmultiad').checked==false)
                            chkmulti="N";
                       else
                             chkmulti="Y";     
                       var chkseq=document.getElementById('chkseqno').value; 
                       if(document.getElementById('chkseqno').checked==false)
                            chkseq="N";
                       else
                            chkseq="Y";     
                       var seqno=document.getElementById('txtseq').value; 
                       var chkparti=document.getElementById('chkpatricularad').value; 
                       if(document.getElementById('chkpatricularad').checked==false)
                            chkparti="N";
                       else
                            chkparti="Y";     
                       var indus=document.getElementById('drpindustry').value;
                       var induspro = "";
                       var transition = document.getElementById('drptransation').value;
                       var centername = document.getElementById('hiddencentercode').value;
                       var printcenter = document.getElementById('drpcenter').value; 
                       for(var t=0;t<document.getElementById('lstproduct').options.length;t++)
                       {
                        if(document.getElementById('lstproduct').options[t].selected==true)
                        {
                            if(induspro=="")
                                induspro=document.getElementById('lstproduct').options[t].value;
                            else
                                induspro=induspro + "," + document.getElementById('lstproduct').options[t].value;    
                        }
                    }
                    var attach1 = document.getElementById('hidattach1').value;
                     
                       var dealon=document.getElementById('drpdealon').value;
                       var rono=document.getElementById('txtrono').value;
                        var rodate=document.getElementById('txtrodate').value;
                         var rostatus=document.getElementById('drprostatus').value;
                         if(document.getElementById('hiddensepcashier').value="Y" && paymode_var.indexOf("CA0")>=0)
                         {
                            rostatus="2";
                         }
                       var rcptno=document.getElementById('txtreceipt').value;
                       var rcptcurr=document.getElementById('drprptcurrency').value;
                         rodate = setDate(dateformat, rodate);
                         var quotation=document.getElementById('hdnquation').value;
                         
                       ContractMaster.insert_contact(DealNo, dealname, agencycode, subagencycode, clientname, product, validfromdate, validtill, representative, compcode, user_id, totalvalue, totalvolume, currencys, teamname, dealtype, adtype, document.getElementById('txtremark').value, executive_var, retainer_var, contdate_var, closedate_var, servicetax_var, caption_var, paymode_var, b2b, chkmulti, chkseq, seqno, chkparti, indus, induspro, dealon, attach1, transition, centername, printcenter,rono,rodate,rostatus,rcptno,rcptcurr,quotation);
                     saveContractDetails();
//                     DataSet db = (DataSet)Session["valueinsert"];
//////                     ret=ContractMaster.getvalueInsertSession();
//////                     var db=ret.value;
//////                     var er=db.Tables[0].Rows.length;
//////                     var gf = db.Tables.length;
//////                     for (var b = 0;b<=gf-1; b++)
//////                     {
//////                         var dealno12 = db.Tables[b].Rows[0].deal_code;   //ItemArray[16]
//////                         var advcat = db.Tables[b].Rows[0].Advcategory;   //ItemArray[0]
//////                         var publication = db.Tables[b].Rows[0].publication; //ItemArray[1]..ToString()
//////                         var drpsuppliment = db.Tables[b].Rows[0].suppliment;//ItemArray[2]..ToString()
//////                         var drpedition = db.Tables[b].Rows[0].edition;//ItemArray[19]..ToString()
//////                         var bookedfor = db.Tables[b].Rows[0].Bookedfor;//ItemArray[3].ToString()
//////                         var color = db.Tables[b].Rows[0].color;//ItemArray[4].ToString()
//////                         var cardrate = db.Tables[b].Rows[0].cardrate;//ItemArray[5]
//////                         var dealrate = db.Tables[b].Rows[0].Dealarte;//IteArray[6]
//////                         var premium = db.Tables[b].Rows[0].premiumcode;//ItemArray[7]
//////                         var cardprem = db.Tables[b].Rows[0].cardpremium;//ItemArray[8]
//////                         var dealprem = db.Tables[b].Rows[0].dealpremium;//ItemArray[9]
//////                         var volbilled = db.Tables[b].Rows[0].volumebilled;//ItemArray[10]
//////                         var voldisc = db.Tables[b].Rows[0].volumedisc;//.ItemArray[11]
//////                         var valfrom = db.Tables[b].Rows[0].valuefrom;//ItemArray[12]
//////                         var valto = db.Tables[b].Rows[0].valueto;//ItemArray[13]
//////                         var uom = db.Tables[b].Rows[0].Uom;//ItemArray[14]
//////                         var package = db.Tables[b].Rows[0].packagecode;//ItemArray[15]
//////                         var compcode = db.Tables[b].Rows[0].comp_code;//ItemArray[17]
//////                         var userid = db.Tables[b].Rows[0].userid;//ItemArray[18]
//////                         var totalrate = db.Tables[b].Rows[0].convertrate;//ItemArray[20]
//////                         var currency = db.Tables[b].Rows[0].currency;//ItemArray[21]
//////                         var ratecode = db.Tables[b].Rows[0].Rate_code;//ItemArray[22]
//////                         var flag = db.Tables[b].Rows[0].approved;//ItemArray[23]
//////                         var quantity = db.Tables[b].Rows[0].quantity;//ItemArray[24]
//////                         var weight = db.Tables[b].Rows[0].weight;//ItemArray[25]
//////                         var free = db.Tables[b].Rows[0].discounted;//ItemArray[26]
//////                         var cyop = db.Tables[b].Rows[0].ContractCode;//ItemArray[28]
//////                         var deviation = db.Tables[b].Rows[0].deviation;//ItemArray[29]
//////                         
//////                         var remarks = db.Tables[b].Rows[0].REMARKS;//ItemArray[29]
//////                         var sizefrom = db.Tables[b].Rows[0].SIZEFROM;//ItemArray[29]
//////                         var sizeto = db.Tables[b].Rows[0].SIZETO;//ItemArray[29]
//////                         var disctype = db.Tables[b].Rows[0].DISCTYPE;//ItemArray[29]
//////                         var discper = db.Tables[b].Rows[0].DISCPER;//ItemArray[29]
//////                           var insertion = db.Tables[b].Rows[0].INSERTION;//ItemArray[29]
//////                              var dayname = db.Tables[b].Rows[0].DAYNAME;//ItemArray[29]
//////                              var comm_allow = db.Tables[b].Rows[0].COMMITION_ALLOW;
//////                              var deal_start = db.Tables[b].Rows[0].DEAL_START;
//////                              var incentive = db.Tables[b].Rows[0].INCENTIVE;
//////                         ContractMaster.insert_detail(dealno12, advcat, publication, drpsuppliment, drpedition, bookedfor, color, cardrate, dealrate, premium, cardprem, dealprem, volbilled, voldisc, valfrom, valto, uom, package, compcode, userid, totalrate, currency, ratecode, flag, quantity, weight, free, cyop,deviation,remarks,sizefrom,sizeto,disctype,discper,insertion,dayname,comm_allow,deal_start,incentive);                         
//////                    }
                     //Session["valueinsert"] = null;
                     document.getElementById('txtdealno').value = "";
                     document.getElementById('drpagencycode').value = "";
                     document.getElementById('drpsubagcode').value = "0";
                     document.getElementById('drpclientname').value = "";
                     document.getElementById('drpproduct').value = "0";
                     document.getElementById('drprepresentative').value = "0";
                     document.getElementById('TextBox1').value = "";
                     document.getElementById('txtfromdate').value = "";
                     document.getElementById('txtdealvol').value = "";
                     document.getElementById('txtdealvalue').value = "";
                     document.getElementById('drpteamname').value = "0";
                     document.getElementById('drpdealtype').value = "0";
                     document.getElementById('txtdealname').value = "";
                      document.getElementById('txtremark').value="";
                      document.getElementById('txtexecutive').value='';
                    document.getElementById('txtretainer').value='';
                    document.getElementById('txtcontractdate').value='';
                    document.getElementById('txtclosedate').value=""; 
                    //document.getElementById('drpservicetax').value="Y";  
                    document.getElementById('txtcaption').value="";
                     for(var n=0;n<document.getElementById('drppaymenttype').options.length;n++)
                            {
                               document.getElementById('drppaymenttype').options[n].selected=false; 
                            }
                            document.getElementById('txtexecutive').disabled=true;
                         document.getElementById('txtretainer').disabled=true;
                    document.getElementById('txtcontractdate').disabled=true;
                    document.getElementById('txtclosedate').disabled=true;
                    document.getElementById('drpservicetax').disabled=true;
                    document.getElementById('txtcaption').disabled=true;
                    document.getElementById('drppaymenttype').disabled=true;
                       document.getElementById('txtremark').disabled=true;
                     //document.getElementById('drpadtype').value = "0";
                     //document.getElementById('drpadtype').disabled = true;
                     document.getElementById('txtdealname').disabled = true;
                     document.getElementById('drpagencycode').disabled = true;
                     document.getElementById('drpsubagcode').disabled = true;
                     document.getElementById('drpclientname').disabled = true;
                     document.getElementById('drpproduct').disabled = true;
                     document.getElementById('drprepresentative').disabled = true;
                     document.getElementById('TextBox1').disabled = true;
                     document.getElementById('txtfromdate').disabled = true;
                     document.getElementById('txtdealvol').disabled = true;
                     document.getElementById('txtdealvalue').disabled = true;
                     document.getElementById('drpcurr').disabled = true;
                     document.getElementById('drpteamname').disabled = true;
                     document.getElementById('drpdealtype').disabled = true;
                     
                     document.getElementById('chkb2b').disabled=true;
                    document.getElementById('chkmultiad').disabled=true;
                    document.getElementById('chkseqno').disabled=true;
                    document.getElementById('txtseq').disabled=true;
                    document.getElementById('chkpatricularad').disabled=true;
                    document.getElementById('drpindustry').disabled=true;
                    document.getElementById('lstproduct').disabled=true;
        document.getElementById('chkb2b').checked=false;
document.getElementById('chkmultiad').checked=false;
document.getElementById('chkseqno').checked=false;
document.getElementById('txtseq').value="";
document.getElementById('chkpatricularad').checked=false;
document.getElementById('drpindustry').value="0";
document.getElementById('lstproduct').options.length=0;
 document.getElementById('txtrono').value="";
        document.getElementById('txtrono').disabled = true;
    document.getElementById('txtrodate').value="";
     document.getElementById('txtrodate').disabled = true;
    document.getElementById('drprostatus').value="0";
    document.getElementById('drprostatus').disabled = true;
     document.getElementById('drprptcurrency').value=document.getElementById('hiddencurrency').value;
      document.getElementById('drprptcurrency').disabled = true;
                     document.getElementById('hiddenforpop').Value = "1";
                     deleteClickGrid();
                     document.getElementById('tblGrid').disabled=true;
                     document.getElementById('tblGridelec').disabled=true;
                      document.getElementById('cmdAddRow').disabled=true;
                    document.getElementById('cmdAddRowelec').disabled=true;
                     document.getElementById('hiddenchkq').value = "0";
                      document.getElementById('drpdealon').disabled=true;
                      document.getElementById('drpdealon').value="print";
                     alert("data saved Successfully with deal No. "+DealNo);
                     document.getElementById('lblfinalvalue').innerHTML="";
                     colName="";
                     document.getElementById('hiddenflagstatus').value="2";
                     chkstatus1(document.getElementById('hiddenflagstatus').value); 
                   //  getbuttoncheck(formname);
                   setButtonImages();
                     return false;
               //  }
             }
         }
         //modify   ***********************************************
         else
         {
             document.getElementById('hiddenchkq').value = "1";
             var dealno = document.getElementById('txtdealno').value;
             var deal_name = document.getElementById('txtdealname').value;
             var deal_type = document.getElementById('drpdealtype').value;

             var flagd = "";
             if (document.getElementById('hiddenname').value != document.getElementById('txtdealname').value)
             {
                 var ret=ContractMaster.deal_modifychk(dealno, deal_name, compcode,deal_type);
                 var dsz=ret.value;
                 if(dsz==null)
                 {
                    alert(ret.error.description);
                    return false;
                 }

                 if (dsz.Tables[0].Rows.Count > 0)
                 {
                     flagd = "Y";
                 }
                 else
                 {
                     flagd = "N";
                 }
                 if (flagd == "Y")
                 {
                     alert('This Deal Name already exists');                     
                     document.getElementById('txtdealname').value = "";
                     return false;
                 }
             }
            
             var res1=ContractMaster.chk_incontractdetail(DealNo, compcode, user_id);
             var d1=res1.value;
             if(d1==null)
             {
                alert(res1.error.description);
                return false;
             }

//             if (d1.Tables[0].Rows.length <= 0)
//             {
//                 alert("Please Enter The Contract Detail of " + DealNo + " ");
//                // AspNetMessageBox(message);
//                 return false;
//             }
//             else
//             {
                       var b2b=document.getElementById('chkb2b').value;
                       if(document.getElementById('chkb2b').checked==false)
                            b2b="N";
                       else
                            b2b="Y";     
                       var chkmulti=document.getElementById('chkmultiad').value; 
                       if(document.getElementById('chkmultiad').checked==false)
                            chkmulti="N";
                       else
                            chkmulti="Y";     
                       var chkseq=document.getElementById('chkseqno').value; 
                       if(document.getElementById('chkseqno').checked==false)
                            chkseq="N";
                       else
                            chkseq="Y";     
                       var seqno=document.getElementById('txtseq').value; 
                       var chkparti=document.getElementById('chkpatricularad').value; 
                       if(document.getElementById('chkpatricularad').checked==false)
                            chkparti="N";
                       else
                            chkparti="Y";     
                       var indus=document.getElementById('drpindustry').value;  
                       var induspro="";
                       for(var t=0;t<document.getElementById('lstproduct').options.length;t++)
                       {
                        if(document.getElementById('lstproduct').options[t].selected==true)
                        {
                            if(induspro=="")
                                induspro=document.getElementById('lstproduct').options[t].value;
                            else
                                induspro=induspro + "," + document.getElementById('lstproduct').options[t].value;    
                        }
                       }
                       var dealon = document.getElementById('drpdealon').value;
                       var attach1 = document.getElementById('hidattach1').value;
                       var transition = document.getElementById('drptransation').value;
//                       var centername = document.getElementById('hiddencentercode').value; 
                       var printcenter = document.getElementById('drpcenter').value;
                       var rono=document.getElementById('txtrono').value;
                        var rodate=document.getElementById('txtrodate').value;
                         var rostatus=document.getElementById('drprostatus').value;
                       var rcptno=document.getElementById('txtreceipt').value;
                       var rcptcurr=document.getElementById('drprptcurrency').value;
                        if(document.getElementById('hiddensepcashier').value="Y" && paymode_var.indexOf("CA0")>=0)
                         {
                            rostatus="2";
                         }
                       ContractMaster.modifycontact(DealNo, dealname, agencycode, subagencycode, clientname, product, validfromdate, validtill, representative, compcode, user_id, totalvalue, totalvolume, currencys, teamname, dealtype, adtype, document.getElementById('txtremark').value, executive_var, retainer_var, contdate_var, closedate_var, servicetax_var, caption_var, paymode_var, b2b, chkmulti, chkseq, seqno, chkparti, indus, induspro, dealon, attach1, transition, centercodemod, printcenter,rono,rodate,rostatus,rcptno,rcptcurr);
                    saveContractDetails();
                 document.getElementById('txtdealno').disabled = true;
                 document.getElementById('txtdealname').disabled = true;
                 document.getElementById('drpagencycode').disabled = true;
                 document.getElementById('drpsubagcode').disabled = true;
                 document.getElementById('drpclientname').disabled = true;
                 document.getElementById('drpproduct').disabled = true;
                 document.getElementById('drprepresentative').disabled = true;
                 document.getElementById('TextBox1').disabled = true;
                 document.getElementById('txtfromdate').disabled = true;;
                 document.getElementById('txtdealvalue').disabled = true;
                 document.getElementById('txtdealvol').disabled = true;
                 document.getElementById('drpteamname').disabled = true;
                 document.getElementById('drpdealtype').disabled = true;
                 //document.getElementById('drpadtype').disabled = true;
                document.getElementById('txtretainer').disabled = true;
                document.getElementById('txtcontractdate').disabled = true;
                document.getElementById('txtclosedate').disabled = true;
                document.getElementById('drpservicetax').disabled = true;
                document.getElementById('txtcaption').disabled = true;
                document.getElementById('txtexecutive').disabled = true; 
                document.getElementById('drppaymenttype').disabled = true;  
                document.getElementById('tblGrid').disabled = true; 
                document.getElementById('tblGridelec').disabled = true;  
                document.getElementById('chkb2b').disabled=true;
                document.getElementById('chkmultiad').disabled=true;
                document.getElementById('chkseqno').disabled=true;
                document.getElementById('txtseq').disabled=true;
                document.getElementById('chkpatricularad').disabled=true;
                document.getElementById('drpindustry').disabled=true;
                document.getElementById('lstproduct').disabled = true;
                document.getElementById('drptransation').disabled = true;
                document.getElementById('drpcenter').disabled = true;
                 
 document.getElementById('txtrono').disabled = true;
document.getElementById('txtrodate').disabled = true;
 document.getElementById('drprostatus').disabled = true;
document.getElementById('drprptcurrency').disabled = true;
var quotation=document.getElementById('hdnquation').value;
                 res1=ContractMaster.query_contract(ddealcode,ddealname, dagencycode, dsubagency, dclient, dproduct, dreprest, compcode, user_id,ddealtype,quotation);
                 var ds=res1.value;
                 if(ds==null)
                 {
                    alert(res1.error.description);
                    return false;
                 }                

                 document.getElementById('txtdealno').value = ds.Tables[0].Rows[rownumEx]["Deal_No"]; //ItemArray[0].ToString();
                 document.getElementById('drpagencycode').value = ds.Tables[0].Rows[rownumEx]["Agency_code"];//ItemArray[2].ToString();
                 if( ds.Tables[0].Rows[rownumEx]["Total_volu"]!=null)
                    document.getElementById('txtdealvol').value = ds.Tables[0].Rows[rownumEx]["Total_volu"];//ItemArray[11].ToString();
                 else
                    document.getElementById('txtdealvol').value ="";   
                 if(ds.Tables[0].Rows[rownumEx]["Total_val"]!=null)   
                    document.getElementById('txtdealvalue').value = ds.Tables[0].Rows[rownumEx]["Total_val"];//ItemArray[10].ToString();
                 else
                    document.getElementById('txtdealvalue').value ="";   
                 document.getElementById('drpdealtype').value = ds.Tables[0].Rows[rownumEx]["deal_type"];//ItemArray[13].ToString();
                 document.getElementById('txtdealname').value = ds.Tables[0].Rows[rownumEx]["deal_name"];//ItemArray[14].ToString();   
                   if(ds.Tables[0].Rows[0]["DEALON"]!=null)
                    document.getElementById('drpdealon').value=ds.Tables[0].Rows[0]["DEALON"];
                   else
                    document.getElementById('drpdealon').value="0";  
                 
                 
                  if(ds.Tables[0].Rows[0]["B2B"]!=null && ds.Tables[0].Rows[0]["B2B"]=="Y")
                document.getElementById('chkb2b').checked=true;
                else
                    document.getElementById('chkb2b').checked=false;
                    
            if(ds.Tables[0].Rows[0]["CHKMULTIAD"]!=null && ds.Tables[0].Rows[0]["CHKMULTIAD"]=="Y")
               document.getElementById('chkmultiad').checked=true;
            else
                document.getElementById('chkmultiad').checked=false; 
                
         if(ds.Tables[0].Rows[0]["SEQNO_ALLOW"]!=null && ds.Tables[0].Rows[0]["SEQNO_ALLOW"]=="Y")
                 document.getElementById('chkseqno').checked=true; 
            else
                document.getElementById('chkseqno').checked=false; 
                
         if(ds.Tables[0].Rows[0]["SEQNO"]!=null)
                document.getElementById('txtseq').value=ds.Tables[0].Rows[0]["SEQNO"];
            else
                document.getElementById('txtseq').value="";   
                
          if(ds.Tables[0].Rows[0]["AFT_PRTCLR_AD"]!=null && ds.Tables[0].Rows[0]["AFT_PRTCLR_AD"]=="Y")
                 document.getElementById('chkpatricularad').checked=true; 
            else
                document.getElementById('chkpatricularad').checked=false;     
                
           if(ds.Tables[0].Rows[0]["INDUSTRY"]!=null)
                document.getElementById('drpindustry').value=ds.Tables[0].Rows[0]["INDUSTRY"];
            else
                document.getElementById('drpindustry').value="0";
            document.getElementById('lstproduct').options.length=0;
            document.getElementById('lstproduct').options[0]=new Option("--Select Product--","0");     
           if(ds.Tables[0].Rows[rownumEx]["INDUSTRY_PRODUCT"]!=null)
           {
                bindIndusProduct();
                var induspro=ds.Tables[0].Rows[0]["INDUSTRY_PRODUCT"];
                var arr=induspro.split(",");
                 for(var o1=0;o1<document.getElementById('lstproduct').options.length;o1++)
                {
                    for(var o=0;o<arr.length;o++)
                    {
                        if(document.getElementById('lstproduct').options[o1].value == arr[o])
                            document.getElementById('lstproduct').options[o1].selected=true;
                    }
                 }   
           }                                 
        //---------
                             
                   if(ds.Tables[0].Rows[0]["EXECUTIVE"]!=null)
                document.getElementById('txtexecutive').value=ds.Tables[0].Rows[0]["EXECUTIVE"];
            else
                document.getElementById('txtexecutive').value="";
             if(ds.Tables[0].Rows[0]["RETAINER"]!=null)
                document.getElementById('txtretainer').value=ds.Tables[0].Rows[0]["RETAINER"];
            else
                document.getElementById('txtretainer').value="";    
                
              if(ds.Tables[0].Rows[0]["CONTRACTDATE"]!=null)
                document.getElementById('txtcontractdate').value=getDate(dateformat, ds.Tables[0].Rows[0]["CONTRACTDATE"]);
            else
                document.getElementById('txtcontractdate').value="";    
                
              if(ds.Tables[0].Rows[0]["CLOSEDATE"]!=null)
                document.getElementById('txtclosedate').value=getDate(dateformat, ds.Tables[0].Rows[0]["CLOSEDATE"]);
            else
                document.getElementById('txtclosedate').value="";   
                
            if(ds.Tables[0].Rows[0]["SERVICETAX"]!=null)
                document.getElementById('drpservicetax').value=ds.Tables[0].Rows[0]["SERVICETAX"];
            else
                document.getElementById('drpservicetax').value="Y";  
                
             if(ds.Tables[0].Rows[0]["CAPTION"]!=null)
                document.getElementById('txtcaption').value=ds.Tables[0].Rows[0]["CAPTION"];
            else
                document.getElementById('txtcaption').value="";                   
            
            if(ds.Tables[0].Rows[0]["PAYMENTTYPE"]!=null)
            {
                var paymode=ds.Tables[0].Rows[0]["PAYMENTTYPE"].toString();
                var arr=paymode.split(",");
                for(var n1=0;n1<document.getElementById('drppaymenttype').options.length;n1++)
                {
                    for(var n2=0;n2<arr.length;n2++)
                    {
                        if(document.getElementById('drppaymenttype').options[n1].value==arr[n2].toString())
                        {
                            document.getElementById('drppaymenttype').options[n1].selected=true;
                            n2=arr.length;
                        }
                    }
                }
            }     
                 
                 //fill the sub agency code on execute
                 var agencycode1="";
                if(document.getElementById('drpagencycode').value != "" && document.getElementById('drpagencycode').value.lastIndexOf('(')>=0)
                {
                 var agency=document.getElementById('drpagencycode').value ;            
	             var agencyarr=agency.split("(");             
	             agencycode1=agencyarr[1];             
	             agencycode1=agencycode1.replace(")","");
	             }
//                 var agency = document.getElementById('drpagencycode').value;
                 
                 res1=ContractMaster.bind_subagency(agencycode1,compcode,user_id);
                 var ex=res1.value;
                 if(ex==null)
                 {
                    alert(res1.error.description);
                    return false;
                 }
                document.getElementById('drpsubagcode').options.length=0;
                document.getElementById('drpsubagcode').options[0]=new Option("Select Sub Agency","0");
                document.getElementById('drpsubagcode').options.length = 1; 
                for (var i = 0  ; i < ex.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('drpsubagcode').options[document.getElementById('drpsubagcode').options.length] = new Option(ex.Tables[0].Rows[i]["Agency_Name"],ex.Tables[0].Rows[i]["SUB_Agency_Code"]);                
                    document.getElementById('drpsubagcode').options.length;       
                }
                 
                 /////////////////////////////////////////////////////////////

                 document.getElementById('drpsubagcode').value = ds.Tables[0].Rows[rownumEx]["Sub_Agency_Code"];//ItemArray[3].ToString();
                 if(ds.Tables[0].Rows[rownumEx]["Client_code"]!=null)
                    document.getElementById('drpclientname').value = ds.Tables[0].Rows[rownumEx]["Client_code"];//ItemArray[4].ToString();
                 else
                    document.getElementById('drpclientname').value ="";   
                 //document.getElementById('drpadtype').value = ds.Tables[0].Rows[rownumEx]["Ad_type"];//ItemArray[16].ToString();
                 //this is for product fill on execute
                 var client="";
                if(document.getElementById('drpclientname').value != "" && document.getElementById('drpclientname').value.lastIndexOf('(')>=0)
                {
                 var clint=document.getElementById('drpclientname').value ;            
	             var agencyarr=clint.split("(");             
	             client=agencyarr[1];             
	             client=client.replace(")","");
               }
                // string client = drpclientname.SelectedItem.Value;
//                 var client=document.getElementById('drpclientname').value;
// now product not bind from client  6 apr 2012
/*
                 res1=ContractMaster.product_bind(client, compcode, user_id);
                 var ex1=res1.value;
                 if(ex1==null)
                 {
                    alert(ex1.error.description);
                    return false;
                 }
                document.getElementById('drpproduct').options.length=0;
                document.getElementById('drpproduct').options[0]=new Option("Select Product","0");
                document.getElementById('drpproduct').options.length = 1; 
                for (var i = 0  ; i < ex1.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('drpproduct').options[document.getElementById('drpproduct').options.length] = new Option(ex1.Tables[0].Rows[i]["Product_Name"],ex1.Tables[0].Rows[i]["Product_Code"]);                
                    document.getElementById('drpproduct').options.length;       
                }
                 */
                //////////////////////////////////////////////////////////

                 document.getElementById('drpproduct').value = ds.Tables[0].Rows[rownumEx]["Product_code"];//ItemArray[5].ToString();
                // drprepresentative.SelectedValue = ds.Tables[0].Rows[fpnl].ItemArray[8].ToString();

                 var fromdat = ds.Tables[0].Rows[rownumEx]["From_date"];//ItemArray[6].ToString();
                 var tdat = ds.Tables[0].Rows[rownumEx]["Till_date"];//ItemArray[7].ToString();
                 document.getElementById('txtfromdate').value = getDate(dateformat, fromdate); //clsdate.getDate(dateformat, fromdate);
                 document.getElementById('TextBox1').value = getDate(dateformat, tdat); //clsdate.getDate(dateformat, tdat);
                
                 //////////////////////////////////////////////////////////////////////////////////////////////                 
                document.getElementById('hiddenflagstatus').value="2";    
                chkstatus1(document.getElementById('hiddenflagstatus').value);

                 if (executequery.Tables[0].Rows.length == 1)
                 {
                     document.getElementById('btnfirst').disabled = true;
                     document.getElementById('btnprevious').disabled = true;
                     document.getElementById('btnnext').disabled = true;
                     document.getElementById('btnlast').disabled = true;
                 }
                 else if (executequery.Tables[0].Rows.length - 1 == rownumEx)
                 {
                     document.getElementById('btnfirst').disabled = false;
                     document.getElementById('btnprevious').disabled = false;
                     document.getElementById('btnnext').disabled = true;
                     document.getElementById('btnlast').disabled = true;
                 }
                 else if (executequery.Tables[0].Rows.length > 0)
                 {
                     document.getElementById('btnfirst').disabled = true;
                     document.getElementById('btnprevious').disabled = true;
                     document.getElementById('btnnext').disabled = false;
                     document.getElementById('btnlast').disabled = false;
                 }                 
                alert("Data Updated Successfully.");
                setButtonImages();
                return false;
           //  }

      } 
 }

//*********************************************************************

    function setDate(dateformat, dateValue)
    {
        var dateReturn = "";
        if (dateValue != "")
        {            
            var dd, mm, yyyy;
            //for from date
            if (dateformat == "dd/mm/yyyy")
            {                
                dd = dateValue.split("/")[0];
                mm = dateValue.split("/")[1];
                yyyy = dateValue.split("/")[2];
                dateReturn = mm + "/" + dd + "/" + yyyy;
            }
            else if (dateformat == "yyyy/mm/dd")
            {
                yyyy = dateValue.split("/")[0];
                mm = dateValue.split("/")[1];
                dd = dateValue.split("/")[2];
                dateReturn = mm + "/" + dd + "/" + yyyy;
            }
            else
            {
                dateReturn = dateValue;
            }
        }
        return dateReturn;
    }

    function getDate(dateformat, dateValue)
    {
        var dateReturn = "";
        var dd, mm, yyyy;
        if (dateValue == "" || dateValue == "0")
        {
            return dateReturn;
        }
        if (dateformat == "dd/mm/yyyy")
        {
            //for from date
            dd = dateValue.split('/')[0];
            mm = dateValue.split('/')[1];
            yyyy = dateValue.split('/')[2];

            dateReturn = mm + "/" + dd + "/" + yyyy;
        }

        if (dateformat == "yyyy/mm/dd")
        {
            //for from date
            dd = dateValue.split('/')[2];
            mm = dateValue.split('/')[1];
            yyyy = dateValue.split('/')[0];
            dateReturn = yyyy + "/" + mm + "/" + dd;
        }
        if (dateformat == "" || dateformat == null)
        {
            dateReturn = dateValue;
        }
        return dateReturn;
    }
    
    
    /*
    function getbuttoncheck(formname)
    {
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        
        var ret=ContractMaster.get_buttonpermission(compcode,userid,formname);
        var butt=ret.value;
        if(butt==null)
        {
            alert(butt.error.description);
            return  false;
        }

        var id=butt.Tables[0].Rows[0].Button_id;

        if(id!="0")
	    {				
		    if(id=="0"||id=="8")
		    {
                document.getElementById('hiddenflagstatus').value = "0";    			
			    document.getElementById('btnNew').disabled=true;
			    document.getElementById('btnQuery').disabled=true;
			    document.getElementById('btnExecute').disabled=true;
			    document.getElementById('btnCancel').disabled=true;		
			    document.getElementById('btnExit').disabled=true;
			    document.getElementById('btnDelete').disabled=true;
			    document.getElementById('btnModify').disabled=true;
    			
			    document.getElementById('btnSave').disabled=true;
			    document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			    document.getElementById('btnlast').disabled=true;
                alert('You Are Not Authorised To View This Form');
                window.close();
                return  false;					
		    }
		    if(id=="1"||id=="9")
		    {
			    document.getElementById('btnNew').disabled=false;
			    document.getElementById('btnQuery').disabled=true;
			    document.getElementById('btnCancel').disabled=true;	
			    document.getElementById('btnExit').disabled=false;
			    document.getElementById('btnDelete').disabled=true;
			    document.getElementById('btnExecute').disabled=true;
    			
			    document.getElementById('btnSave').disabled=true;
			    document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnfirst').disabled=true;			
			    document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			    document.getElementById('btnlast').disabled=true;
                document.getElementById('hiddenflagstatus').value = "1";
    			
		    }
		    if(id=="2"||id=="10")
		    {			
			    document.getElementById('btnNew').disabled=true;
			    document.getElementById('btnExecute').disabled=false;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnCancel').disabled==false;		
			    document.getElementById('btnExit').disabled=false;		
			    document.getElementById('btnDelete').disabled=true;
			    document.getElementById('btnModify').disabled=false;
    			
			    document.getElementById('btnSave').disabled=true;
			    document.getElementById('btnfirst').disabled=false;				
			    document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			    document.getElementById('btnlast').disabled=true;			
			    document.getElementById('btnExit').disabled=false;
                document.getElementById('hiddenflagstatus').value = "2";   			
    			
		    }
		    if(id=="3"||id=="11")
		    {
			    document.getElementById('btnNew').disabled=false;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnExecute').disabled=true;
			    document.getElementById('btnDelete').disabled=true;
			    document.getElementById('btnModify').disabled=true;		
			    document.getElementById('btnCancel').disabled==false;			
			    document.getElementById('btnExit').disabled=false;    			
    			
			    document.getElementById('btnSave').disabled=true;
			    document.getElementById('btnfirst').disabled=true;						
			    document.getElementById('btnnext').disabled=true;				
			    document.getElementById('btnprevious').disabled=true;				
			    document.getElementById('btnlast').disabled=true;

                document.getElementById('hiddenflagstatus').value = "3";
		    }
		    if(id=="4"||id=="12" )
		    {
			    document.getElementById('btnNew').disabled=true;			    	
			    document.getElementById('btnDelete').disabled=true;
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;				
			    document.getElementById('btnprevious').disabled=true;				
			    document.getElementById('btnlast').disabled=true;
			    document.getElementById('btnExecute').disabled=true;
			    document.getElementById('btnModify').disabled=true;    			
			    document.getElementById('btnSave').disabled=true;
			    
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnCancel').disabled==false;			
			    document.getElementById('btnExit').disabled=false;   		    
                document.getElementById('hiddenflagstatus').value = "4";
		    }
		    if(id=="5" ||id=="13")
		    {
			    document.getElementById('btnNew').disabled=true;			    	
			    document.getElementById('btnDelete').disabled=true;
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;				
			    document.getElementById('btnprevious').disabled=true;				
			    document.getElementById('btnlast').disabled=true;
			    document.getElementById('btnExecute').disabled=true;
			    document.getElementById('btnModify').disabled=true;    			
			    document.getElementById('btnSave').disabled=true;
			    
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnCancel').disabled==false;			
			    document.getElementById('btnExit').disabled=false;   
                document.getElementById('hiddenflagstatus').value = "5";			
    			
		    }
		    if(id=="6"||id=="14")
		    {
			    document.getElementById('btnNew').disabled=true;			    	
			    document.getElementById('btnDelete').disabled=true;
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;				
			    document.getElementById('btnprevious').disabled=true;				
			    document.getElementById('btnlast').disabled=true;
			    document.getElementById('btnExecute').disabled=true;
			    document.getElementById('btnModify').disabled=true;    			
			    document.getElementById('btnSave').disabled=true;
			    
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnCancel').disabled==false;			
			    document.getElementById('btnExit').disabled=false;   
                document.getElementById('hiddenflagstatus').value = "6";
		    }
		    if(id=="7"||id=="15")
		    {
			    document.getElementById('btnNew').disabled=false;			    	
			    document.getElementById('btnDelete').disabled=true;
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;				
			    document.getElementById('btnprevious').disabled=true;				
			    document.getElementById('btnlast').disabled=true;
			    document.getElementById('btnExecute').disabled=true;
			    document.getElementById('btnModify').disabled=true;    			
			    document.getElementById('btnSave').disabled=true;
			    
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnCancel').disabled==false;			
			    document.getElementById('btnExit').disabled=false;   
                document.getElementById('hiddenflagstatus').value = "7";		
		    }
	    }

    }*/
    
    
   
    function chkstatus1(FlagStatus)
    {
        if(FlagStatus=="1")  //new
		{
		    document.getElementById('btnSave').disabled = false;
	        document.getElementById('btnNew').disabled = true;
            document.getElementById('btnQuery').disabled = true;			
			document.getElementById('btnDelete').disabled=true;			
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;		
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;						
		}
		if(FlagStatus=="2")  //save
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnExecute').disabled=true;			
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;		
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnCancel').disabled=false;			
		}
		if(FlagStatus=="3") //query
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnExecute').disabled=false;			
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;		
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnCancel').disabled=false;			
		}		
		
		if(FlagStatus=="4")  //execute
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnDelete').disabled=false;	
			document.getElementById('btnExecute').disabled=true;			
			document.getElementById('btnModify').disabled=false;		
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;		
			document.getElementById('btnlast').disabled=false;			
			document.getElementById('btnExit').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
		}
		if(FlagStatus=="5")  //modify
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnExecute').disabled=true;			
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;		
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
		}
		if(FlagStatus=="6")  //cancel
		{
		    document.getElementById('btnSave').disabled = true;
	        document.getElementById('btnNew').disabled = true;
            document.getElementById('btnQuery').disabled = false;			
			document.getElementById('btnDelete').disabled=true;			
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;		
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;						
		}
		if(FlagStatus=="7")  //delete
		{
		    document.getElementById('btnSave').disabled = true;
	        document.getElementById('btnNew').disabled = true;
            document.getElementById('btnQuery').disabled = true;			
			document.getElementById('btnDelete').disabled=true;			
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnModify').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;		
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;						
		}
    }
    
    
    function executeclick()
    {
        rownumEx=0;
        document.getElementById('hiddenchkq').value = "1";
        document.getElementById('hiddenflagstatus').value="4";
      //  document.getElementById('lbcontractdetails').disabled = false;
        document.getElementById('hiddenmodify').value = "2";
//        Session["valueinsert"] = null;
        document.getElementById('hiddenforpop').value = "1";
        saving = "1";
        var DealNo = document.getElementById('txtdealno').value;
        ddealcode = DealNo.toUpperCase();
        var dealname = document.getElementById('txtdealname').value;
        ddealname = dealname;
        var agencycode="";
        if(document.getElementById('drpagencycode').value != "" && document.getElementById('drpagencycode').value.lastIndexOf('(')>=0)
        {
         var agency=document.getElementById('drpagencycode').value ;            
	     var agencyarr=agency.split("(");             
	     var agencycode=agencyarr[1];             
	     agencycode=agencycode.replace(")","");
       }
       else if(document.getElementById('drpagencycode').value!="")
         {
         alert("Please select correct Agency by Pressing F2");
         document.getElementById('drpagencycode').value="";
         document.getElementById('drpagencycode').focus();
         return false;
         }
//        var agencycode = document.getElementById('drpagencycode').value;
        dagencycode = agencycode;
        var subagencycode = document.getElementById('drpsubagcode').value;
        dsubagency = subagencycode;
        //var clientname = document.getElementById('drpclientname').value;
        var clientcode = document.getElementById('drpclientname').value;
        var client = "";
        ///this is to split and get the client code

        if (clientcode.indexOf("(".toString()) > 0 && clientcode != "")
        {
            //clientcode.IndexOf(
           // char[] splitterclie = { '(' };
            var myarray1 = clientcode.split('(');
            client = myarray1[1];
            client = client.replace(")", '');

            /////this is to chk whether this code exixts in the database if exists than it is a register client else
            ///it is walkinn client
            ///
            var res=ContractMaster.chkwalkinClient(client,document.getElementById('hiddencompcode').value);
            var dcl = res.value;
            if(dcl==null)
            {
                alert(res.error.description);
                return false;
            }
                if (dcl.Tables[0].Rows.length > 0)
                {

                }
                else
                {
                    client = clientcode;
                }

        }
        else
        {
            client = clientcode;
        }
        dclient = client;
        var product = document.getElementById('drpproduct').value;
        dproduct = product;
        var representative = document.getElementById('drprepresentative').value;
        dreprest = representative;
        var dealtype = document.getElementById('drpdealtype').value;
        ddealtype = dealtype;
        compcode=document.getElementById('hiddencompcode').value;
        userid=document.getElementById('hiddenuserid').value;
         dateformat=document.getElementById('hiddendateformat').value;
         
        document.getElementById('drpagencycode').disabled = true;
        document.getElementById('drpsubagcode').disabled = true;
        document.getElementById('drpclientname').disabled = true;
        document.getElementById('drpproduct').disabled = true;
        document.getElementById('drprepresentative').disabled = true;
        document.getElementById('TextBox1').disabled = true;
        document.getElementById('txtfromdate').disabled = true;
        document.getElementById('drpcurr').disabled = true;
        document.getElementById('drpdealtype').disabled = true;
        document.getElementById('txtdealvalue').disabled = true;
        document.getElementById('txtdealvol').disabled = true;

        document.getElementById('txtdealno').disabled = true;
        document.getElementById('txtdealname').disabled = true;
        document.getElementById('txtdealvol').disabled= true;
 var quotation=document.getElementById('hdnquation').value;
        fpnl = 0;
        var res2=ContractMaster.query_contract(ddealcode,ddealname,dagencycode,dsubagency,dclient,dproduct,dreprest,compcode,userid,ddealtype,quotation)
        executequery=res2.value;
        if(executequery==null)
        {
            alert(res2.error.description);
            return false;
        }
        updateStatus()
        
        if (executequery.Tables[0].Rows.length > 0)
        {
         if(executequery.Tables[0].Rows[0]["DEALON"]!=null)
            document.getElementById('drpdealon').value=executequery.Tables[0].Rows[0]["DEALON"];
        else
            document.getElementById('drpdealon').value="print"; 
                    
         if(executequery.Tables[0].Rows[0]["B2B"]!=null && executequery.Tables[0].Rows[0]["B2B"]=="Y")
                document.getElementById('chkb2b').checked=true;
            else
                document.getElementById('chkb2b').checked=false;
                
        if(executequery.Tables[0].Rows[0]["CHKMULTIAD"]!=null && executequery.Tables[0].Rows[0]["CHKMULTIAD"]=="Y")
                document.getElementById('chkmultiad').checked=true;
            else
                document.getElementById('chkmultiad').checked=false; 
                
         if(executequery.Tables[0].Rows[0]["SEQNO_ALLOW"]!=null && executequery.Tables[0].Rows[0]["SEQNO_ALLOW"]=="Y")
                document.getElementById('chkseqno').checked=true; 
            else
                document.getElementById('chkseqno').checked=false; 
                
         if(executequery.Tables[0].Rows[0]["SEQNO"]!=null)
                document.getElementById('txtseq').value=executequery.Tables[0].Rows[0]["SEQNO"];
            else
                document.getElementById('txtseq').value="";   
                
          if(executequery.Tables[0].Rows[0]["AFT_PRTCLR_AD"]!=null && executequery.Tables[0].Rows[0]["AFT_PRTCLR_AD"]=="Y")
                document.getElementById('chkpatricularad').checked=true;
            else
                document.getElementById('chkpatricularad').checked=false;     
                
           if(executequery.Tables[0].Rows[0]["INDUSTRY"]!=null)
                document.getElementById('drpindustry').value=executequery.Tables[0].Rows[0]["INDUSTRY"];
            else
                document.getElementById('drpindustry').value="0";
            document.getElementById('lstproduct').options.length=0;
            document.getElementById('lstproduct').options[0]=new Option("--Select Product--","0");     
           if(executequery.Tables[0].Rows[0]["INDUSTRY_PRODUCT"]!=null)
           {
                bindIndusProduct();
                var induspro=executequery.Tables[0].Rows[0]["INDUSTRY_PRODUCT"];
                var arr=induspro.split(",");
                 for(var o1=0;o1<document.getElementById('lstproduct').options.length;o1++)
                {
                    for(var o=0;o<arr.length;o++)
                    {
                        if(document.getElementById('lstproduct').options[o1].value == arr[o])
                            document.getElementById('lstproduct').options[o1].selected=true;
                    }
                 }   
           }                                 
        //---------
        if(executequery.Tables[0].Rows[0]["RO_NO"]!=null)
                document.getElementById('txtrono').value=executequery.Tables[0].Rows[0]["RO_NO"];
            else
                document.getElementById('txtrono').value="";
                
             if(executequery.Tables[0].Rows[0]["RO_DATE"]!=null)
                document.getElementById('txtrodate').value=executequery.Tables[0].Rows[0]["RO_DATE"];
            else
                document.getElementById('txtrodate').value="";
            
            if(executequery.Tables[0].Rows[0]["RO_STATUS"]!=null)
                document.getElementById('drprostatus').value=executequery.Tables[0].Rows[0]["RO_STATUS"];
            else
                document.getElementById('drprostatus').value="";    
                
               if(executequery.Tables[0].Rows[0]["RECEIPT_NO"]!=null)
                document.getElementById('txtreceipt').value=executequery.Tables[0].Rows[0]["RECEIPT_NO"];
            else
                document.getElementById('txtreceipt').value=""; 
                
             if(executequery.Tables[0].Rows[0]["RCPT_CURRENCY"]!=null)
                document.getElementById('drprptcurrency').value=executequery.Tables[0].Rows[0]["RCPT_CURRENCY"];
            else
                document.getElementById('drprptcurrency').value="";             
                
            if(executequery.Tables[0].Rows[0]["EXECUTIVE"]!=null)
                document.getElementById('txtexecutive').value=executequery.Tables[0].Rows[0]["EXECUTIVE"];
            else
                document.getElementById('txtexecutive').value="";
             if(executequery.Tables[0].Rows[0]["RETAINER"]!=null)
                document.getElementById('txtretainer').value=executequery.Tables[0].Rows[0]["RETAINER"];
            else
                document.getElementById('txtretainer').value="";    
                
              if(executequery.Tables[0].Rows[0]["CONTRACTDATE"]!=null)
                document.getElementById('txtcontractdate').value=getDate(dateformat, executequery.Tables[0].Rows[0]["CONTRACTDATE"]);
            else
                document.getElementById('txtcontractdate').value="";    
                
              if(executequery.Tables[0].Rows[0]["CLOSEDATE"]!=null)
                document.getElementById('txtclosedate').value=getDate(dateformat, executequery.Tables[0].Rows[0]["CLOSEDATE"]);
            else
                document.getElementById('txtclosedate').value="";   
                
            if(executequery.Tables[0].Rows[0]["SERVICETAX"]!=null)
                document.getElementById('drpservicetax').value=executequery.Tables[0].Rows[0]["SERVICETAX"];
            else
                document.getElementById('drpservicetax').value="Y";  
                
             if(executequery.Tables[0].Rows[0]["CAPTION"]!=null)
                document.getElementById('txtcaption').value=executequery.Tables[0].Rows[0]["CAPTION"];
            else
                document.getElementById('txtcaption').value = "";


            if (executequery.Tables[0].Rows[0].ATTACHMENT != null && executequery.Tables[0].Rows[0].ATTACHMENT != "") {
                document.getElementById('hidattach1').value = executequery.Tables[0].Rows[0].ATTACHMENT;
                document.getElementById('attachment1').src = "Images/indexred.jpg";
            }
            else {
                document.getElementById('hidattach1').value = "";
                document.getElementById('attachment1').src = "Images/index.jpeg"
            }
               
            document.getElementById('txtdealno').value = executequery.Tables[0].Rows[0]["Deal_No"];//ItemArray[0].ToString();
            if(executequery.Tables[0].Rows[0]["Agency_code"]!=null && executequery.Tables[0].Rows[0]["Agency_code"]!="NULL")
            document.getElementById('drpagencycode').value = executequery.Tables[0].Rows[0]["Agency_code"];//ItemArray[2].ToString();
            //fill the sub agency code on execute
            var agencycode1="";
            if(document.getElementById('drpagencycode').value != "" && document.getElementById('drpagencycode').value.lastIndexOf('(')>=0)
                {
            var agency=document.getElementById('drpagencycode').value ;            
	         var agencyarr=agency.split("(");             
	         agencycode1=agencyarr[1];             
	         agencycode1=agencycode1.replace(")","");
	         }
//            var agency = document.getElementById('drpagencycode').value;
            var res3=ContractMaster.agencyChange(compcode,userid,agencycode1);
            var ex=res3.value;
            if(ex==null)
            {
                alert(res3.error.description);
                return false;
            }
            document.getElementById('drpsubagcode').options.length=0;
            document.getElementById('drpsubagcode').options[0]=new Option("Select Sub Agency","0");
            document.getElementById('drpsubagcode').options.length = 1; 
            for (var i = 0  ; i < ex.Tables[0].Rows.length; ++i)
            {
                document.getElementById('drpsubagcode').options[document.getElementById('drpsubagcode').options.length] = new Option(ex.Tables[0].Rows[i]["Agency_Name"],ex.Tables[0].Rows[i]["SUB_Agency_Code"]);                
                document.getElementById('drpsubagcode').options.length;       
            }
            /////////////////////////////////////////////////////////////

            document.getElementById('drpsubagcode').value = executequery.Tables[0].Rows[0]["Sub_Agency_Code"];//ItemArray[3].ToString();
            
              bindpaymentType(document.getElementById('drpagencycode').value,document.getElementById('drpsubagcode').value);
            if(executequery.Tables[0].Rows[0]["PAYMENTTYPE"]!=null)
            {
                var paymode=executequery.Tables[0].Rows[0]["PAYMENTTYPE"].toString();
                var arr=paymode.split(",");
                for(var n1=0;n1<document.getElementById('drppaymenttype').options.length;n1++)
                {
                    for(var n2=0;n2<arr.length;n2++)
                    {
                        if(document.getElementById('drppaymenttype').options[n1].value==arr[n2].toString())
                        {
                            document.getElementById('drppaymenttype').options[n1].selected=true;
                            n2=arr.length;
                        }
                    }
                }
            }    
            
//            if(executequery.Tables[0].Rows[0]["Client_code"]!=null)
//                document.getElementById('drpclientname').value = executequery.Tables[0].Rows[0]["Client_code"];//ItemArray[4].ToString();
//            else
//                document.getElementById('drpclientname').value ="";
//            //this is for product fill on execute
//            var client="";
//                if(document.getElementById('drpclientname').value != "" && document.getElementById('drpclientname').value.lastIndexOf('(')>=0)
//                {
//                 var clint=document.getElementById('drpclientname').value ;            
//	             var agencyarr=clint.split("(");             
//	             client=agencyarr[1];             
//	             client=client.replace(")","");
//               }
document.getElementById("drpclientnamelist").innerHTML="";
               var agencyarr="";
                var clientarr="";
                alert(executequery.Tables[0].Rows[0]["CLIENT_NAME"])
                if(executequery.Tables[0].Rows[0]["CLIENT_NAME"]!=null && executequery.Tables[0].Rows[0]["CLIENT_NAME"]!="")
               {
                    var clint=executequery.Tables[0].Rows[0]["CLIENT_NAME"];   
                    var clintcode=executequery.Tables[0].Rows[0]["Client_code"];          
	            agencyarr=clint.split(",");         
               clientarr=clintcode.split(",");
               }
               for(var i=0;i<agencyarr.length;i++)
               {
               
             var pkgitem = document.getElementById("drpclientnamelist");
         pkgitem.options[pkgitem.options.length] = new Option(agencyarr[i],clientarr[i]);
      
               }
//            var client = document.getElementById('drpclientname').value;
// now product not bind from client  6 apr 2012
         /*   res3=ContractMaster.product_bind(client, compcode, userid);
            var ex1=res3.value;
            if(ex1==null)
            {
                alert(res3.error.description);
                return false;
            }
            document.getElementById('drpproduct').options.length=0;
            document.getElementById('drpproduct').options[0]=new Option("Select Product","0");
            document.getElementById('drpproduct').options.length = 1; 
            for (var i = 0  ; i < ex1.Tables[0].Rows.length; ++i)
            {
                document.getElementById('drpproduct').options[document.getElementById('drpproduct').options.length] = new Option(ex1.Tables[0].Rows[i]["Product_Name"],ex1.Tables[0].Rows[i]["Product_Code"]);                
                document.getElementById('drpproduct').options.length;       
            }*/
// 6 apr 2012
            //////////////////////////////////////////////////////////

            document.getElementById('drpproduct').value = executequery.Tables[0].Rows[0]["Product_code"];//ItemArray[5].ToString();
           // drprepresentative.SelectedValue = executequery.Tables[0].Rows[0].ItemArray[8].ToString();
            if(executequery.Tables[0].Rows[0]["Total_volu"]==null)
                executequery.Tables[0].Rows[0]["Total_volu"]="";
            else
                document.getElementById('txtdealvol').value = executequery.Tables[0].Rows[0]["Total_volu"];//ItemArray[11].ToString();
            if(executequery.Tables[0].Rows[0]["Total_val"]==null)
                executequery.Tables[0].Rows[0]["Total_val"]="";
            else
                document.getElementById('txtdealvalue').value = executequery.Tables[0].Rows[0]["Total_val"];//ItemArray[10].ToString();
            if(executequery.Tables[0].Rows[0]["deal_type"]==null)
                executequery.Tables[0].Rows[0]["deal_type"]="";
            else
                document.getElementById('drpdealtype').value = executequery.Tables[0].Rows[0]["deal_type"];//ItemArray[13].ToString();

            if(executequery.Tables[0].Rows[0]["deal_name"]==null)
                executequery.Tables[0].Rows[0]["deal_name"]="";
            else
                document.getElementById('txtdealname').value = executequery.Tables[0].Rows[0]["deal_name"];//ItemArray[14].ToString();

            var fromdat = executequery.Tables[0].Rows[0]["From_date"];//ItemArray[6].ToString();
            var tdat = executequery.Tables[0].Rows[0]["Till_date"]; //ItemArray[7].ToString();

            if (executequery.Tables[0].Rows[0]["DEAL_FROM"] == null || executequery.Tables[0].Rows[0]["DEAL_FROM"] == "") {
                document.getElementById('txtdealfrom').value = "";
            }
            else {
                document.getElementById('txtdealfrom').value = executequery.Tables[0].Rows[0]["DEAL_FROM"];
                var ccode=executequery.Tables[0].Rows[0]["DEAL_FROM"];

                centercodemod = ccode.split("(");
                centercodemod = centercodemod[1];
                centercodemod = centercodemod.replace(")", "");
            }
            if (executequery.Tables[0].Rows[0]["DEAL_CENTER"] == null || executequery.Tables[0].Rows[0]["DEAL_CENTER"] == "")
                document.getElementById('drpcenter').value = "";
            else
                document.getElementById('drpcenter').value = executequery.Tables[0].Rows[0]["DEAL_CENTER"];

            if (executequery.Tables[0].Rows[0]["TRANSLATION_CHARGES"] == null || executequery.Tables[0].Rows[0]["TRANSLATION_CHARGES"] == "")
                document.getElementById('drptransation').value = "";
            else
                document.getElementById('drptransation').value = executequery.Tables[0].Rows[0]["TRANSLATION_CHARGES"];     

            document.getElementById('txtfromdate').value = getDate(dateformat, fromdat);// clsdate.getDate(dateformat, fromdat);
            document.getElementById('TextBox1').value = getDate(dateformat, tdat); //clsdate.getDate(dateformat, tdat);
            //////////////////////////////////////this is for repre

            document.getElementById('drpteamname').value = executequery.Tables[0].Rows[0]["team_code"];//ItemArray[12].ToString();
            //////////////////////////////////////////code to fill representative
            if(executequery.Tables[0].Rows[0]["REMARKS"]==null)
                 document.getElementById('txtremark').value="";
            else
                document.getElementById('txtremark').value=executequery.Tables[0].Rows[0]["REMARKS"]; 
                    
            var name = document.getElementById('drpteamname').value;
            res3=ContractMaster.teamName(compcode,userid,name);
            var ds1=res3.value;
            if(ds1==null)
            {
                alert(res3.error.description);
                return false;
            }
            

            if (ds1.Tables[0].Rows.length >= 0)
            {
                document.getElementById('drprepresentative').options.length=0;
                document.getElementById('drprepresentative').options[0]=new Option("Select Representative","0");
                document.getElementById('drprepresentative').options.length = 1; 
                for (var i = 0  ; i < ds1.Tables[0].Rows.length; ++i)
                {
                    document.getElementById('drprepresentative').options[document.getElementById('drprepresentative').options.length] = new Option(ds1.Tables[0].Rows[i]["Exec_name"],ds1.Tables[0].Rows[i]["Exe_no"]);                
                    document.getElementById('drprepresentative').options.length;       
                }
            }
            
            ////////////////////////////////////////////////////////////////////////////////////////////////
            document.getElementById('drprepresentative').value = executequery.Tables[0].Rows[0]["representative"];
            document.getElementById('drpteamname').value = executequery.Tables[0].Rows[0]["team_code"];
            //drprepresentative.SelectedValue = executequery.Tables[0].Rows[0].ItemArray [8].ToString();
            //document.getElementById('drpadtype').value = executequery.Tables[0].Rows[0]["Ad_type"];
            
            /////////////////////////////////////////////////////////////////////////////////////////////////
        }
        else
        {
////            message = "Your Search Produce No Result";
////            AspNetMessageBox(message);
            alert('Your Search Produce No Result');
            cancelclickdeal("ContractMaster");
            return  false;
        }

        chkstatus1(document.getElementById('hiddenflagstatus').value); 
        chkstatus12(FlagStatus);  
//        document.getElementById('btnnext').disabled = false;
//             document.getElementById('btnlast').disabled = false;     
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true; 
        if (FlagStatus == 2 || FlagStatus == 6 || FlagStatus == 3 || FlagStatus == 7)
           document.getElementById('btnModify').disabled = false;
        if (FlagStatus == 6 || FlagStatus == 4 || FlagStatus == 5 || FlagStatus == 7)
            document.getElementById('btnDelete').disabled = false;
               
      //  bindgridview(document.getElementById('txtdealno').value); //"Advcategory");
     //   fillGridView(document.getElementById('txtdealno').value);
        document.getElementById('btnQuery').disabled = false;
          if(executequery.Tables[0].Rows.length==1)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
    }
    else
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
        dealType_Change();
         document.getElementById('txtdealvol').disabled= true;
          document.getElementById('txtdealvalue').disabled= true;
          bindGridDetails();
        setButtonImages();
        return false;
    }
    
   
    function firstclick()
    {
        rownumEx=0;
        //document.getElementById('lbcontractdetails').disabled = false;
        document.getElementById('hiddenmodify').value = "2";
       // Session["valueinsert"] = null;
        document.getElementById('hiddenforpop').value = "1";
        //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 

ContractMaster.blankvalueInsertSession();
        fpnl = 0; 
        buttonmovement(rownumEx);
        chkstatus12(FlagStatus);
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = false; 
        if(rownumEx==executequery.Tables[0].Rows.length - 1)
        {
           document.getElementById('btnnext').disabled = true;
           document.getElementById('btnlast').disabled=true; 
        }
        if (FlagStatus == 2 || FlagStatus == 6 || FlagStatus == 3 || FlagStatus == 7)
           document.getElementById('btnModify').disabled = false;
        if (FlagStatus == 6 || FlagStatus == 4 || FlagStatus == 5 || FlagStatus == 7)
            document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        //document.getElementById('btnModify').disabled=false;
        dealType_Change();
          document.getElementById('txtdealvol').disabled= true;
          document.getElementById('txtdealvalue').disabled= true;
           bindGridDetails();
        setButtonImages();
        return false;   
    }
    
    function lastclick()
    {
       rownumEx=executequery.Tables[0].Rows.length - 1;
       //document.getElementById('lbcontractdetails').disabled = false;
       document.getElementById('hiddenmodify').value = "2";       
       document.getElementById('hiddenforpop').value = "1";
       //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 

ContractMaster.blankvalueInsertSession();
       buttonmovement(rownumEx);
       chkstatus12(FlagStatus); 
       document.getElementById('btnfirst').disabled = false;
       document.getElementById('btnlast').disabled = true;
       document.getElementById('btnprevious').disabled = false;
       document.getElementById('btnnext').disabled = true; 
       if(rownumEx==0)
        {
           document.getElementById('btnfirst').disabled = true;
           document.getElementById('btnprevious').disabled=true; 
        }
        if (FlagStatus == 2 || FlagStatus == 6 || FlagStatus == 3 || FlagStatus == 7)
           document.getElementById('btnModify').disabled = false;
        if (FlagStatus == 6 || FlagStatus == 4 || FlagStatus == 5 || FlagStatus == 7)
            document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        //document.getElementById('btnModify').disabled=false;    
        dealType_Change(); 
          document.getElementById('txtdealvol').disabled= true;
          document.getElementById('txtdealvalue').disabled= true;
           bindGridDetails();
        setButtonImages();  
       return false;
    }
    
    function previousclick()
    {
        rownumEx--;
        //document.getElementById('lbcontractdetails').disabled = false;
        document.getElementById('hiddenmodify').value = "2";       
        document.getElementById('hiddenforpop').value = "1";
        //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
 
ContractMaster.blankvalueInsertSession();
                
        buttonmovement(rownumEx);
        chkstatus12(FlagStatus);
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = false; 
        if(rownumEx==0)
        {
           document.getElementById('btnfirst').disabled = true;
           document.getElementById('btnprevious').disabled=true; 
        }
        if (FlagStatus == 2 || FlagStatus == 6 || FlagStatus == 3 || FlagStatus == 7)
           document.getElementById('btnModify').disabled = false;
        if (FlagStatus == 6 || FlagStatus == 4 || FlagStatus == 5 || FlagStatus == 7)
            document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        //document.getElementById('btnModify').disabled=false;
        dealType_Change();
          document.getElementById('txtdealvol').disabled= true;
          document.getElementById('txtdealvalue').disabled= true;
           bindGridDetails();
        setButtonImages();
        return false;   
    }
    
    function nextclick()
    {
        rownumEx++; 
        //document.getElementById('lbcontractdetails').disabled = false;
        document.getElementById('hiddenmodify').value = "2";        
        document.getElementById('hiddenforpop').value = "1"; 
        //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 

ContractMaster.blankvalueInsertSession();
             
        buttonmovement(rownumEx);    
        chkstatus12(FlagStatus);    
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = false; 
        if(rownumEx==executequery.Tables[0].Rows.length - 1)
        {
           document.getElementById('btnnext').disabled = true;
           document.getElementById('btnlast').disabled=true; 
        }
        if (FlagStatus == 2 || FlagStatus == 6 || FlagStatus == 3 || FlagStatus == 7)
           document.getElementById('btnModify').disabled = false;
        if (FlagStatus == 6 || FlagStatus == 4 || FlagStatus == 5 || FlagStatus == 7)
            document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        //document.getElementById('btnModify').disabled=false;
        dealType_Change();
          document.getElementById('txtdealvol').disabled= true;
          document.getElementById('txtdealvalue').disabled= true;
           bindGridDetails();
        setButtonImages();
        return false;        
    }
    
    function  buttonmovement(rownumEx)
    {
        cancelcontract();  
        compcode=document.getElementById('hiddencompcode').value;
        userid=document.getElementById('hiddenuserid').value;
         if(executequery.Tables[0].Rows[rownumEx]["DEALON"]!=null)
            document.getElementById('drpdealon').value=executequery.Tables[0].Rows[rownumEx]["DEALON"];
        else
            document.getElementById('drpdealon').value="print"; 
        if(executequery.Tables[0].Rows[rownumEx]["B2B"]!=null && executequery.Tables[0].Rows[rownumEx]["B2B"]=="Y")
                document.getElementById('chkb2b').checked=true;
            else
                document.getElementById('chkb2b').checked=false;
                
        if(executequery.Tables[0].Rows[rownumEx]["CHKMULTIAD"]!=null && executequery.Tables[0].Rows[rownumEx]["CHKMULTIAD"]=="Y")
                document.getElementById('chkseqno').checked=true;
            else
                document.getElementById('chkmultiad').checked=false; 
                
         if(executequery.Tables[0].Rows[rownumEx]["SEQNO_ALLOW"]!=null && executequery.Tables[0].Rows[rownumEx]["SEQNO_ALLOW"]=="Y")
               document.getElementById('chkseqno').checked=true;
            else
                document.getElementById('chkseqno').checked=false; 
                
         if(executequery.Tables[0].Rows[rownumEx]["SEQNO"]!=null)
                document.getElementById('txtseq').value=executequery.Tables[0].Rows[rownumEx]["SEQNO"];
            else
                document.getElementById('txtseq').value="";   
                
          if(executequery.Tables[0].Rows[rownumEx]["AFT_PRTCLR_AD"]!=null && executequery.Tables[0].Rows[rownumEx]["AFT_PRTCLR_AD"]=="Y")
                document.getElementById('chkpatricularad').checked=true;   
            else
                document.getElementById('chkpatricularad').checked=false;     
                
           if(executequery.Tables[0].Rows[rownumEx]["INDUSTRY"]!=null)
                document.getElementById('drpindustry').value=executequery.Tables[0].Rows[rownumEx]["INDUSTRY"];
            else
                document.getElementById('drpindustry').value="0";
            document.getElementById('lstproduct').options.length=0;
            document.getElementById('lstproduct').options[0]=new Option("--Select Product--","0");     
           if(executequery.Tables[0].Rows[rownumEx]["INDUSTRY_PRODUCT"]!=null)
           {
                bindIndusProduct();
                var induspro=executequery.Tables[0].Rows[rownumEx]["INDUSTRY_PRODUCT"];
                var arr=induspro.split(",");
                 for(var o1=0;o1<document.getElementById('lstproduct').options.length;o1++)
                {
                    for(var o=0;o<arr.length;o++)
                    {
                        if(document.getElementById('lstproduct').options[o1].value == arr[o])
                            document.getElementById('lstproduct').options[o1].selected=true;
                    }
                 }   
           }                                 
        //---------
          if(executequery.Tables[0].Rows[rownumEx]["RO_NO"]!=null)
                document.getElementById('txtrono').value=executequery.Tables[0].Rows[rownumEx]["RO_NO"];
            else
                document.getElementById('txtrono').value="";
                
             if(executequery.Tables[0].Rows[rownumEx]["RO_DATE"]!=null)
                document.getElementById('txtrodate').value=executequery.Tables[0].Rows[rownumEx]["RO_DATE"];
            else
                document.getElementById('txtrodate').value="";
            
            if(executequery.Tables[0].Rows[rownumEx]["RO_STATUS"]!=null)
                document.getElementById('drprostatus').value=executequery.Tables[0].Rows[rownumEx]["RO_STATUS"];
            else
                document.getElementById('drprostatus').value="";    
                
               if(executequery.Tables[0].Rows[rownumEx]["RECEIPT_NO"]!=null)
                document.getElementById('txtreceipt').value=executequery.Tables[0].Rows[rownumEx]["RECEIPT_NO"];
            else
                document.getElementById('txtreceipt').value=""; 
                
             if(executequery.Tables[0].Rows[rownumEx]["RCPT_CURRENCY"]!=null)
                document.getElementById('drprptcurrency').value=executequery.Tables[0].Rows[rownumEx]["RCPT_CURRENCY"];
            else
                document.getElementById('drprptcurrency').value="";   
         if(executequery.Tables[0].Rows[rownumEx]["EXECUTIVE"]!=null)
                document.getElementById('txtexecutive').value=executequery.Tables[0].Rows[rownumEx]["EXECUTIVE"];
            else
                document.getElementById('txtexecutive').value="";
             if(executequery.Tables[0].Rows[rownumEx]["RETAINER"]!=null)
                document.getElementById('txtretainer').value=executequery.Tables[0].Rows[rownumEx]["RETAINER"];
            else
                document.getElementById('txtretainer').value="";    
                
              if(executequery.Tables[0].Rows[rownumEx]["CONTRACTDATE"]!=null)
                document.getElementById('txtcontractdate').value=getDate(dateformat, executequery.Tables[0].Rows[rownumEx]["CONTRACTDATE"]);
            else
                document.getElementById('txtcontractdate').value="";    
                
              if(executequery.Tables[0].Rows[rownumEx]["CLOSEDATE"]!=null)
                document.getElementById('txtclosedate').value=getDate(dateformat, executequery.Tables[0].Rows[rownumEx]["CLOSEDATE"]);
            else
                document.getElementById('txtclosedate').value="";   
                
            if(executequery.Tables[0].Rows[rownumEx]["SERVICETAX"]!=null)
                document.getElementById('drpservicetax').value=executequery.Tables[0].Rows[rownumEx]["SERVICETAX"];
            else
                document.getElementById('drpservicetax').value="Y";  
                
             if(executequery.Tables[0].Rows[rownumEx]["CAPTION"]!=null)
                document.getElementById('txtcaption').value=executequery.Tables[0].Rows[rownumEx]["CAPTION"];
            else
                document.getElementById('txtcaption').value = "";


            if (executequery.Tables[0].Rows[rownumEx].ATTACHMENT != null && executequery.Tables[0].Rows[rownumEx].ATTACHMENT != "") {
                document.getElementById('hidattach1').value = executequery.Tables[0].Rows[rownumEx].ATTACHMENT;
                document.getElementById('attachment1').src = "Images/indexred.jpg";
            }
            else {
                document.getElementById('hidattach1').value = "";
                document.getElementById('attachment1').src = "Images/index.jpeg"
            }

            if (executequery.Tables[0].Rows[rownumEx]["DEAL_FROM"] == null || executequery.Tables[0].Rows[rownumEx]["DEAL_FROM"] == "") {
                document.getElementById('txtdealfrom').value = "";
            }
            else {
                document.getElementById('txtdealfrom').value = executequery.Tables[0].Rows[rownumEx]["DEAL_FROM"];
                var ccode = executequery.Tables[0].Rows[0]["DEAL_FROM"];
                if(ccode!=null)
                {
                centercodemod = ccode.split("(");
                centercodemod = centercodemod[1];
                centercodemod = centercodemod.replace(")", "");
                }
            }
            if (executequery.Tables[0].Rows[rownumEx]["DEAL_CENTER"] == null || executequery.Tables[0].Rows[rownumEx]["DEAL_CENTER"] == "")
                document.getElementById('drpcenter').value = "";
            else
                document.getElementById('drpcenter').value = executequery.Tables[0].Rows[rownumEx]["DEAL_CENTER"];

            if (executequery.Tables[0].Rows[rownumEx]["TRANSLATION_CHARGES"] == null || executequery.Tables[0].Rows[rownumEx]["TRANSLATION_CHARGES"] == "")
                document.getElementById('drptransation').value = "";
            else
                document.getElementById('drptransation').value = executequery.Tables[0].Rows[rownumEx]["TRANSLATION_CHARGES"];   
            
                    
        document.getElementById('txtdealno').value = executequery.Tables[0].Rows[rownumEx]["Deal_No"];
        document.getElementById('drpagencycode').value = executequery.Tables[0].Rows[rownumEx]["Agency_code"];
          if( executequery.Tables[0].Rows[rownumEx]["Total_volu"]!=null)
                    document.getElementById('txtdealvol').value = executequery.Tables[0].Rows[rownumEx]["Total_volu"];//ItemArray[11].ToString();
                 else
                    document.getElementById('txtdealvol').value ="";   
                 if(executequery.Tables[0].Rows[rownumEx]["Total_val"]!=null)   
                    document.getElementById('txtdealvalue').value = executequery.Tables[0].Rows[rownumEx]["Total_val"];//ItemArray[10].ToString();
                 else
                    document.getElementById('txtdealvalue').value ="";
        document.getElementById('drpdealtype').value = executequery.Tables[0].Rows[rownumEx]["deal_type"];
         if(executequery.Tables[0].Rows[0]["REMARKS"]==null)
                 document.getElementById('txtremark').value="";
            else
                document.getElementById('txtremark').value=executequery.Tables[0].Rows[0]["REMARKS"]; 
        document.getElementById('txtdealname').value = executequery.Tables[0].Rows[rownumEx]["deal_name"];
        //fill the sub agency code on execute
        var agencycode1="";
        if(document.getElementById('drpagencycode').value != "" && document.getElementById('drpagencycode').value.lastIndexOf('(')>=0)
           {
            var agency=document.getElementById('drpagencycode').value ;            
	         var agencyarr=agency.split("(");             
	         agencycode1=agencyarr[1];             
	         agencycode1=agencycode1.replace(")","");
	         }
//        var agency = document.getElementById('drpagencycode').value;
        res3 =ContractMaster.agencyChange(compcode,userid,agencycode1);
        var ex=res3.value;
        if(ex==null)
        {
            alert(res3.error.description);
            return false;
        }
        document.getElementById('drpsubagcode').options.length=0;
        document.getElementById('drpsubagcode').options[0]=new Option("Select Sub Agency","0");
        document.getElementById('drpsubagcode').options.length = 1; 
        for (var j = 0; j< ex.Tables[0].Rows.length; j++)
        {
            document.getElementById('drpsubagcode').options[document.getElementById('drpsubagcode').options.length] = new Option(ex.Tables[0].Rows[j].Agency_Name,ex.Tables[0].Rows[j].SUB_Agency_Code);                
            document.getElementById('drpsubagcode').options.length;       
        }
        /////////////////////////////////////////////////////////////
       
        if(executequery.Tables[0].Rows[rownumEx]["Sub_Agency_Code"]!=null)
        {
            document.getElementById('drpsubagcode').value = executequery.Tables[0].Rows[rownumEx]["Sub_Agency_Code"];
        }
        bindpaymentType(document.getElementById('drpagencycode').value,document.getElementById('drpsubagcode').value);
            if(executequery.Tables[0].Rows[rownumEx]["PAYMENTTYPE"]!=null)
            {
                var paymode=executequery.Tables[0].Rows[rownumEx]["PAYMENTTYPE"].toString();
                var arr=paymode.split(",");
                for(var n1=0;n1<document.getElementById('drppaymenttype').options.length;n1++)
                {
                    for(var n2=0;n2<arr.length;n2++)
                    {
                        if(document.getElementById('drppaymenttype').options[n1].value==arr[n2].toString())
                        {
                            document.getElementById('drppaymenttype').options[n1].selected=true;
                            n2=arr.length;
                        }
                    }
                }
            }       
////        if(executequery.Tables[0].Rows[rownumEx]["Client_code"]!=null)
////        {
////            document.getElementById('drpclientname').value = executequery.Tables[0].Rows[rownumEx]["Client_code"];
////        }
//////        var client = document.getElementById('drpclientname').value;
////        //this is for product fill on execute
////           var client="";
////                if(document.getElementById('drpclientname').value != "" && document.getElementById('drpclientname').value.lastIndexOf('(')>=0)
////                {
////                 var clint=document.getElementById('drpclientname').value ;            
////	             var agencyarr=clint.split("(");             
////	             client=agencyarr[1];             
////	             client=client.replace(")","");
////               } 
             document.getElementById("drpclientnamelist").innerHTML="";  
           var agencyarr="";
                var clientarr="";
                if(executequery.Tables[0].Rows[rownumEx]["CLIENT_NAME"]!=null && executequery.Tables[0].Rows[rownumEx]["CLIENT_NAME"]!="")
               {
                    var clint=executequery.Tables[0].Rows[rownumEx]["CLIENT_NAME"];   
                    var clintcode=executequery.Tables[0].Rows[rownumEx]["Client_code"];          
	            agencyarr=clint.split(",");         
               clientarr=clintcode.split(",");
               }
               for(var i=0;i<agencyarr.length;i++)
               {
               
             var pkgitem = document.getElementById("drpclientnamelist");
         pkgitem.options[pkgitem.options.length] = new Option(agencyarr[i],clientarr[i]);
      
               }          
               
               // now product not bind from client  6 apr 2012
        /*res3=ContractMaster.product_bind(client, compcode, userid);
        var ex1=res3.value;
        if(ex1==null)
        {
            alert(res3.error.description);
            return false;
        }
        document.getElementById('drpproduct').options.length=0;
        document.getElementById('drpproduct').options[0]=new Option("Select Product","0");
        document.getElementById('drpproduct').options.length = 1; 
        for (var i = 0  ; i < ex1.Tables[0].Rows.length; ++i)
        {
            document.getElementById('drpproduct').options[document.getElementById('drpproduct').options.length] = new Option(ex1.Tables[0].Rows[i]["Product_Name"],ex1.Tables[0].Rows[i]["Product_Code"]);                
            document.getElementById('drpproduct').options.length;       
        }
      */
        document.getElementById('drpproduct').value = executequery.Tables[0].Rows[0]["Product_code"];//ItemArray[5].ToString();
         //////////////////////////////////////////////////////////
         var fromdat = executequery.Tables[0].Rows[0]["From_date"];//ItemArray[6].ToString();
         var tdat = executequery.Tables[0].Rows[0]["Till_date"];//ItemArray[7].ToString();           

         document.getElementById('txtfromdate').value = getDate(dateformat, fromdat);// clsdate.getDate(dateformat, fromdat);
         document.getElementById('TextBox1').value = getDate(dateformat, tdat); //clsdate.getDate(dateformat, tdat);
         //////////////////////////////////////this is for repre

         document.getElementById('drpteamname').value = executequery.Tables[0].Rows[0]["team_code"];//ItemArray[12].ToString();            
            
         //////////////////////////////////////////code to fill representative
        var name = document.getElementById('drpteamname').value;
        res3=ContractMaster.teamName(compcode,userid,name);
        var ds1=res3.value;
        if(ds1==null)
        {
            alert(res3.error.description);
            return false;
        }            

        if (ds1.Tables[0].Rows.Count >= 0)
        {
            document.getElementById('drprepresentative').options.length=0;
            document.getElementById('drprepresentative').options[0]=new Option("Select Representative","0");
            document.getElementById('drprepresentative').options.length = 1; 
            for (var i = 0  ; i < ds1.Tables[0].Rows.length; ++i)
            {
                document.getElementById('drprepresentative').options[document.getElementById('drprepresentative').options.length] = new Option(ds1.Tables[0].Rows[i]["Exec_name"].ToString(),ds1.Tables[0].Rows[i]["Exe_no"].ToString());                
                document.getElementById('drprepresentative').options.length;       
            }
        }                      
        ////////////////////////////////////////////////////////////////////////////////////////////////
        document.getElementById('drprepresentative').value = executequery.Tables[0].Rows[0]["representative"];
        document.getElementById('drpteamname').value = executequery.Tables[0].Rows[0]["team_code"];
        //document.getElementById('drpadtype').value = executequery.Tables[0].Rows[0]["Ad_type"];        
      
////        bindgridview(document.getElementById('txtdealno').value); //"Advcategory");
     //   fillGridView(document.getElementById('txtdealno').value);
        return false;
    }
    
    
    
    function cancelclickdeal(formname)
    {
        chkquery = "0";
        arrlist=null;
        document.getElementById('txtexecutive').value='';
        document.getElementById('txtretainer').value='';
        document.getElementById('txtcontractdate').value='';
        document.getElementById('txtclosedate').value=""; 
        //document.getElementById('drpservicetax').value="Y";  
        document.getElementById('txtcaption').value="";
        for(var n=0;n<document.getElementById('drppaymenttype').options.length;n++)
        {
           document.getElementById('drppaymenttype').options[n].selected=false; 
        }
        document.getElementById('txtdealno').value = "";
        document.getElementById('txtdealname').value = "";
        ddealcode = "";
        document.getElementById('drpagencycode').value = "";
        dagencycode = "";
        document.getElementById('drpsubagcode').value = "0";
        dsubagency = "";
        document.getElementById('drpclientname').value = "";
        dclient = "";
        document.getElementById('drpproduct').value = "0";
        dproduct = "";
        document.getElementById('drprepresentative').value = "0";
        dreprest = "";
        document.getElementById('txtfromdate').value = "";
        document.getElementById('TextBox1').value = "";
        document.getElementById('txtdealvalue').value = "";
        document.getElementById('txtdealvol').value = "";
        document.getElementById('drpcurr').value = document.getElementById('hiddencurrency').value; //Session["currency"].ToString();
        document.getElementById('drpdealon').disabled=true;
        document.getElementById('drpdealon').value="print";
        document.getElementById('txtdealno').disabled = true;
        document.getElementById('txtdealname').disabled = true;
        document.getElementById('drpagencycode').disabled = true;
        document.getElementById('drpsubagcode').disabled = true;
        document.getElementById('drpclientname').disabled = true;
        document.getElementById('drpproduct').disabled = true;
        document.getElementById('drprepresentative').disabled = true;
//        document.getElementById('txttilldate').disabled = true;
//        document.getElementById('validfrom').disabled = true;
        document.getElementById('txtdealvalue').disabled = true;
        document.getElementById('txtdealvol').disabled = true;
        document.getElementById('drpcurr').disabled = true;
        
          document.getElementById('txtcontractdate').value = "";
        document.getElementById('txtclosedate').value = "";
         document.getElementById('txtcaption').value = "";
         document.getElementById('drppaymenttype').value = "0";
        // document.getElementById('drpservicetax').value = "Y";
         document.getElementById('txtexecutive').value = "";
         document.getElementById('txtretainer').value = "";
         
           document.getElementById('txtcontractdate').disabled = false;
        document.getElementById('txtclosedate').disabled = false;
         document.getElementById('txtcaption').disabled = false;
         document.getElementById('drppaymenttype').disabled = false;
         document.getElementById('drpservicetax').disabled = false;
         document.getElementById('txtexecutive').disabled = false;
         document.getElementById('txtretainer').disabled = false;
         
        saveormodify = "0";
////        fpnl = 0;
////        getbuttoncheck(formname);
////        bindgridview("Advcategory");
    //    fillGridView(document.getElementById('txtdealno').value);
    }
    
 
   function checktodate(input)
   {
        var dateformat=document.getElementById('hiddendateformat').value;
        if(document.getElementById('txtfromdate').value=="")
        {
            alert("please enter valid fromdate in "+dateformat+" Format.");  
            document.getElementById('txtfromdate').focus();
            return false;
        }
        else
        {
            var fromdate=document.getElementById('txtfromdate').value;
        }
        if(dateformat=="mm/dd/yyyy") 
        {
            var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity 
        }
        if(dateformat=="yyyy/mm/dd") 
        {
            var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
        }
        if(dateformat=="dd/mm/yyyy")
        {
            var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
        }

        if (!validformat.test(input.value))
        {
            if(input.value=="")
            {
                return true;
            }
            setTimeout(settime1,15);
            daid=input;
            return;
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
                //var dayobj = new Date(monthfield-1, dayfield, yearfield)
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
        }

        var abcd= dayobj.getMonth()+1;
        var date1=dayobj.getDate();
        var year1=dayobj.getFullYear();
        if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
        {
            alert(" Please Fill The Date In "+dateformat+" Format");
            input.value="";
            return false;
        }

        if(fromdate>input.value)
        {
            alert("Valid From Date Should Be Less Than Valid To Date");
            document.getElementById('txtfromdate').value="";
            document.getElementById('txtfromdate').focus();
        }
        returnval=true
        if (returnval==false) 
            input.select()
        return returnval

}

function deleteclick()
{
    if(confirm('Are you sure you want to delete?')==false)
        return false;
        
    document.getElementById('hiddenflagstatus').value="7";
    //document.getElementById('lbcontractdetails').disabled = false;
    //dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 

ContractMaster.blankvalueInsertSession();
    var dealcontract=document.getElementById('txtdealno').value;
    ContractMaster.delete_contractdetails(dealcontract,document.getElementById('hiddencompcode').value);
var quotation=document.getElementById('hdnquation').value;
    var ret1=ContractMaster.query_contract(ddealcode, ddealname, dagencycode, dsubagency, dclient, dproduct, dreprest, document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, ddealtype,quotation);
    var excutequery=ret1.value;
    alert('Data Deleted Successfully');    

    var a=excutequery.Tables[0].Rows.length;
    if (a <= 0)
    {
        alert('There is no data');
        cancelclickdeal("ContractMaster");
        cancelcontract();
        return false;

    }
    else if (rownumEx == -1 || rownumEx >= a)
    {
    executequery=excutequery;
     document.getElementById('txtdealno').value = excutequery.Tables[0].Rows[0]["Deal_No"];  //.ItemArray[0].ToString();
            rownumEx=0;
            buttonmovement(rownumEx);
            chkstatus12(FlagStatus);
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = false; 
        if(rownumEx==executequery.Tables[0].Rows.length - 1)
        {
           document.getElementById('btnnext').disabled = true;
           document.getElementById('btnlast').disabled=true; 
        }
        if (FlagStatus == 2 || FlagStatus == 6 || FlagStatus == 3 || FlagStatus == 7)
           document.getElementById('btnModify').disabled = false;
        if (FlagStatus == 6 || FlagStatus == 4 || FlagStatus == 5 || FlagStatus == 7)
            document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        //document.getElementById('btnModify').disabled=false;
        dealType_Change();
          document.getElementById('txtdealvol').disabled= true;
          document.getElementById('txtdealvalue').disabled= true;
           bindGridDetails();
        setButtonImages();
//        document.getElementById('txtdealno').value = excutequery.Tables[0].Rows[0]["Deal_No"];  //.ItemArray[0].ToString();
//        document.getElementById('drpagencycode').value = excutequery.Tables[0].Rows[0]["Agency_code"];  //.ItemArray[2].ToString();
//           if( excutequery.Tables[0].Rows[0]["Total_volu"]!=null)
//                    document.getElementById('txtdealvol').value = excutequery.Tables[0].Rows[0]["Total_volu"];//ItemArray[11].ToString();
//                 else
//                    document.getElementById('txtdealvol').value ="";   
//                 if(excutequery.Tables[0].Rows[0]["Total_val"]!=null)   
//                    document.getElementById('txtdealvalue').value = excutequery.Tables[0].Rows[0]["Total_val"];//ItemArray[10].ToString();
//                 else
//                    document.getElementById('txtdealvalue').value ="";
//        document.getElementById('drpdealtype').value = excutequery.Tables[0].Rows[0]["deal_type"];//.ItemArray[13].ToString();

//        document.getElementById('txtdealname').value = excutequery.Tables[0].Rows[0]["deal_name"];//.ItemArray[14].ToString();

//        //fill the sub agency code on execute
//        var agencycode1="";
//        if(document.getElementById('drpagencycode').value != "" && document.getElementById('drpagencycode').value.lastIndexOf('(')>=0)
//         {
//            var agency=document.getElementById('drpagencycode').value ;            
//	         var agencyarr=agency.split("(");             
//	         agencycode1=agencyarr[1];             
//	         agencycode1=agencycode1.replace(")","");
//	    }
////        var agency = document.getElementById('drpagencycode').value;
//            
//        var res_1=ContractMaster.bind_subagency(agencycode1,compcode,userid);
//        var ex=res_1.value;
//        if(ex==null)
//        {
//            alert(res1.error.description);
//            return false;
//        }
//        document.getElementById('drpsubagcode').options.length=0;
//        document.getElementById('drpsubagcode').options[0]=new Option("Select Sub Agency","0");
//        document.getElementById('drpsubagcode').options.length = 1; 
//        for (var i = 0  ; i < ex.Tables[0].Rows.length; ++i)
//        {
//            document.getElementById('drpsubagcode').options[document.getElementById('drpsubagcode').options.length] = new Option(ex.Tables[0].Rows[i]["Agency_Name"].ToString(),ex.Tables[0].Rows[i]["SUB_Agency_Code"].ToString());                
//            document.getElementById('drpsubagcode').options.length;       
//        }
//         
//         /////////////////////////////////////////////////////////////

//         document.getElementById('drpsubagcode').value = excutequery.Tables[0].Rows[0]["Sub_Agency_Code"];//ItemArray[3].ToString();
//         if(executequery.Tables[0].Rows[0]["Client_code"]!=null)
//            document.getElementById('drpclientname').value = excutequery.Tables[0].Rows[0]["Client_code"];//ItemArray[4].ToString();
//         else
//            document.getElementById('drpclientname').value ="";   
//         //document.getElementById('drpadtype').value = excutequery.Tables[0].Rows[0]["Ad_type"];//ItemArray[16].ToString();
//         
//         //this is for product fill on execute
//            var client="";
//                if(document.getElementById('drpclientname').value != "" && document.getElementById('drpclientname').value.lastIndexOf('(')>=0)
//                {
//                 var clint=document.getElementById('drpclientname').value ;            
//	             var agencyarr=clint.split("(");             
//	             client=agencyarr[1];             
//	             client=client.replace(")","");
//               } 
////         var client=document.getElementById('drpclientname').value;
//// now product not bind from client  6 apr 2012
//         /*res_1=ContractMaster.product_bind(client, compcode, userid);
//         var ex1=res_1.value;
//         if(ex1==null)
//         {
//            alert(ex1.error.description);
//            return false;
//         }
//        document.getElementById('drpproduct').options.length=0;
//        document.getElementById('drpproduct').options[0]=new Option("Select Product","0");
//        document.getElementById('drpproduct').options.length = 1; 
//        for (var i = 0  ; i < ex1.Tables[0].Rows.length; ++i)
//        {
//            document.getElementById('drpproduct').options[document.getElementById('drpproduct').options.length] = new Option(ex.Tables[0].Rows[i]["Product_Name"],ex.Tables[0].Rows[i]["Product_Code"]);                
//            document.getElementById('drpproduct').options.length;       
//        }
//                 */
//        //////////////////////////////////////////////////////////

//        document.getElementById('drpproduct').value = excutequery.Tables[0].Rows[0]["Product_code"];//ItemArray[5].ToString();
//        //////////////////////////////////////////////////////////
//        var fromdat = excutequery.Tables[0].Rows[0]["From_date"];//ItemArray[6].ToString();
//        var tdat = excutequery.Tables[0].Rows[0]["Till_date"];//ItemArray[6].ToString();
//        
//        //splitting of date
//        document.getElementById('txtfromdate').value = getDate(dateformat, fromdat); 
//        document.getElementById('TextBox1').value = getDate(dateformat, tdat); 
        //////////////////////////////////////////////////////////////////////////////////////////////////////
    }
    else
    {
    executequery=excutequery;
     document.getElementById('txtdealno').value = excutequery.Tables[0].Rows[rownumEx]["Deal_No"];  //.ItemArray[0].ToString();
    buttonmovement(rownumEx);
    chkstatus12(FlagStatus);
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = false; 
        if(rownumEx==executequery.Tables[0].Rows.length - 1)
        {
           document.getElementById('btnnext').disabled = true;
           document.getElementById('btnlast').disabled=true; 
        }
        if (FlagStatus == 2 || FlagStatus == 6 || FlagStatus == 3 || FlagStatus == 7)
           document.getElementById('btnModify').disabled = false;
        if (FlagStatus == 6 || FlagStatus == 4 || FlagStatus == 5 || FlagStatus == 7)
            document.getElementById('btnDelete').disabled = false;
        document.getElementById('btnQuery').disabled = false;
        //document.getElementById('btnModify').disabled=false;
        dealType_Change();
          document.getElementById('txtdealvol').disabled= true;
          document.getElementById('txtdealvalue').disabled= true;
           bindGridDetails();
        setButtonImages();
//        document.getElementById('txtdealno').value = excutequery.Tables[0].Rows[rownumEx]["Deal_No"];  //.ItemArray[0].ToString();
//        document.getElementById('drpagencycode').value = excutequery.Tables[0].Rows[rownumEx]["Agency_code"];  //.ItemArray[2].ToString();
//          if( excutequery.Tables[0].Rows[rownumEx]["Total_volu"]!=null)
//                    document.getElementById('txtdealvol').value = excutequery.Tables[0].Rows[rownumEx]["Total_volu"];//ItemArray[11].ToString();
//                 else
//                    document.getElementById('txtdealvol').value ="";   
//                 if(excutequery.Tables[0].Rows[rownumEx]["Total_val"]!=null)   
//                    document.getElementById('txtdealvalue').value = excutequery.Tables[0].Rows[rownumEx]["Total_val"];//ItemArray[10].ToString();
//                 else
//                    document.getElementById('txtdealvalue').value ="";
//        document.getElementById('drpdealtype').value = excutequery.Tables[0].Rows[rownumEx]["deal_type"];//.ItemArray[13].ToString();

//        document.getElementById('txtdealname').value = excutequery.Tables[0].Rows[rownumEx]["deal_name"];//.ItemArray[14].ToString();
//        
//         //fill the sub agency code on execute
//         var agencycode1="";
//         if(document.getElementById('drpagencycode').value != "" && document.getElementById('drpagencycode').value.lastIndexOf('(')>=0)
//             {
//             var agency=document.getElementById('drpagencycode').value ;            
//	         var agencyarr=agency.split("(");             
//	         agencycode1=agencyarr[1];             
//	         agencycode1=agencycode1.replace(")","");
//	        }
////        var agency = document.getElementById('drpagencycode').value;
//            
//        var res_1=ContractMaster.bind_subagency(agencycode1,compcode,userid);
//        var ex=res_1.value;
//        if(ex==null)
//        {
//            alert(res1.error.description);
//            return false;
//        }
//        document.getElementById('drpsubagcode').options.length=0;
//        document.getElementById('drpsubagcode').options[0]=new Option("Select Sub Agency","0");
//        document.getElementById('drpsubagcode').options.length = 1; 
//        for (var i = 0  ; i < ex.Tables[0].Rows.length; ++i)
//        {
//            document.getElementById('drpsubagcode').options[document.getElementById('drpsubagcode').options.length] = new Option(ex.Tables[0].Rows[i]["Agency_Name"].toString(),ex.Tables[0].Rows[i]["SUB_Agency_Code"].toString());                
//            document.getElementById('drpsubagcode').options.length;       
//        }
//         
//         /////////////////////////////////////////////////////////////

//         document.getElementById('drpsubagcode').value = excutequery.Tables[0].Rows[rownumEx]["Sub_Agency_Code"];//ItemArray[3].ToString();
//         if(excutequery.Tables[0].Rows[rownumEx]["Client_code"]!=null)
//            document.getElementById('drpclientname').value = excutequery.Tables[0].Rows[rownumEx]["Client_code"];//ItemArray[4].ToString();
//         else
//            document.getElementById('drpclientname').value ="";   
//         //document.getElementById('drpadtype').value = excutequery.Tables[0].Rows[rownumEx]["Ad_type"];//ItemArray[16].ToString();
//        
//            //this is for product fill on execute
//            var client="";
//                if(document.getElementById('drpclientname').value != "" && document.getElementById('drpclientname').value.lastIndexOf('(')>=0)
//                {
//                 var clint=document.getElementById('drpclientname').value ;            
//	             var agencyarr=clint.split("(");             
//	             client=agencyarr[1];             
//	             client=client.replace(")","");
//               } 
////         var client=document.getElementById('drpclientname').value;
//// now product not bind from client  6 apr 2012
///*
//         res_1=ContractMaster.product_bind(client, compcode, userid);
//         var ex1=res_1.value;
//         if(ex1==null)
//         {
//            alert(ex1.error.description);
//            return false;
//         }
//        document.getElementById('drpproduct').options.length=0;
//        document.getElementById('drpproduct').options[0]=new Option("Select Product","0");
//        document.getElementById('drpproduct').options.length = 1; 
//        for (var i = 0  ; i < ex1.Tables[0].Rows.length; ++i)
//        {
//            document.getElementById('drpproduct').options[document.getElementById('drpproduct').options.length] = new Option(ex.Tables[0].Rows[i]["Product_Name"],ex.Tables[0].Rows[i]["Product_Code"]);                
//            document.getElementById('drpproduct').options.length;       
//        }
//             */    
//        //////////////////////////////////////////////////////////

//        document.getElementById('drpproduct').value = excutequery.Tables[0].Rows[rownumEx]["Product_code"];//ItemArray[5].ToString();
//        var fromdat = excutequery.Tables[0].Rows[rownumEx]["From_date"];//.ItemArray[6].ToString();
//        var tdat = excutequery.Tables[0].Rows[rownumEx]["Till_date"];//.ItemArray[7].ToString();

//            //splitting of date
//         document.getElementById('txtfromdate').value = getDate(dateformat, fromdat); //clsdate.getDate(dateformat, fromdat);
//         document.getElementById('TextBox1').value = getDate(dateformat, tdat); //clsdate.getDate(dateformat, tdat);
    }
    chkstatus1(document.getElementById('hiddenflagstatus').value);
    return false;
}
function chkstatus12(FlagStatus)
{
	if(FlagStatus==0||FlagStatus==8)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnSave').disabled=true;	
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=true;	
			alert("You Are Not Authorised To See This Form");
			return false;
					
		}
		if(FlagStatus==1||FlagStatus==9)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnSave').disabled=true;	
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;	
			return false;
		}
		if(FlagStatus==2||FlagStatus==10)
		{
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnExit').disabled=false;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;	
			return false;
		
		}
		
		if(FlagStatus==3||FlagStatus==11)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		
		if(FlagStatus==4||FlagStatus==12)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==5||FlagStatus==13)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==6||FlagStatus==14)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==7||FlagStatus==15)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=false;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
	return false;
}

function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}
//////////////////========Function for tab Value=====================//////////
function tabvalue1 (event,id)
{
   // alert("12");
    if (document.activeElement.id == "lstproduct" && (event.keyCode == 13 || event.keyCode == 9)) {
        document.getElementById('drpcenter').focus();
        return false;
    }
    
    if (document.activeElement.id == "drpcenter" && (event.keyCode == 13 ||event.keyCode == 9)) {
        document.getElementById('drptransation').focus();
        return false;
    }
    if (document.activeElement.id == "drptransation" && (event.keyCode == 13 || event.keyCode == 9)) {
     
//        activeIDNo.value = Channe;
//  
//
        //           activeIDNo.focus();
        document.getElementById('btnSave').focus();
        return false;
    }
try{
if(document.activeElement.id=="cmdAddRow" || document.activeElement.id=="cmdAddRowelec" || document.activeElement.id=="drpdealon" || document.activeElement.id=="btnExit" || document.activeElement.id=="btnDelete" || document.activeElement.id=="btnlast" || document.activeElement.id=="btnnext" || document.activeElement.id=="btnprevious" || document.activeElement.id=="btnCancel" || document.activeElement.id=="btnExecute" || document.activeElement.id=="btnQuery" || document.activeElement.id=="btnModify" || document.activeElement.id=="btnNew" || document.activeElement.id=="btnSave" || document.activeElement.id=="drpindustry" || document.activeElement.id=="lstproduct" || document.activeElement.id=="txtseq"  || document.activeElement.id=="chkpatricularad"  || document.activeElement.id=="chkseqno" || document.activeElement.id=="chkmultiad" || document.activeElement.id=="chkb2b" ||  document.activeElement.id=="txtremark" || document.activeElement.id=="drppaymenttype" || document.activeElement.id=="drpservicetax" || document.activeElement.id=="txtdealvol" || document.activeElement.id=="txtdealvalue" || document.activeElement.id=="txtclosedate" || document.activeElement.id=="txtcontractdate" || document.activeElement.id=="lstretainer" || document.activeElement.id=="lstexec" || document.activeElement.id=="lstclient" || document.activeElement.id=="lstagency" || document.activeElement.id=="txtcaption" || document.activeElement.id=="txtfromdate" || document.activeElement.id=="TextBox1" || document.activeElement.id=="drpteamname" || document.activeElement.id=="drprepresentative" || document.activeElement.id=="txtexecutive" || document.activeElement.id=="txtretainer" || document.activeElement.id=="drpproduct" || document.activeElement.id=="drpclientname" || document.activeElement.id=="drpsubagcode" || document.activeElement.id=="drpagencycode" || document.activeElement.id=="drpcurr" ||  document.activeElement.id=="txtdealname" || document.activeElement.id=="drpdealtype")
{
    colName="";
}

var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
if(event.ctrlKey==true && event.which=="68")
{
     if(colName!="undefined" && colName!=undefined && (colName=="Channel" || colName=="Ad Type") && mode=="new")
    {
         var srcElm=getEventRow();
          if(confirm('Are you sure you want to delete Row?')==false)
             return false;
          else{
             
              activeRow=srcElm.rowIndex;
              deleteRow(activeRow-1);
              arrlist.deleteRow(activeRow-1);
              return false;
          }   
    }
}

if (event.ctrlKey == true && event.which == "67") {
    if (colName != "undefined" && colName != undefined && (colName == "Channel" || colName == "Ad Type") && mode == "new") {
        var srcElm = getEventRow();
        if (confirm('Are you sure you want to copy Row?') == false)
            return false;
        else {

            if (document.getElementById('div_electronics').style.display == "none") {
                addRow('', '', '', '', '', '', '0', '0', '0', '0', '0', '', '0', '', '', '', '', '', '', '', 'Yes(Y)', '', document.getElementById('hiddencurrency').value, '', '', '', '', '', '','','','','','','');
            }
            else {
                addRow('', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', document.getElementById('hiddencurrency').value, '', '', '', 'Yes(Y)', '', '', '', '', '', '', '', '', '', '', '', '','','','','');
            }
            activeRow = srcElm.rowIndex;
            copyrow(activeRow);
            return false;
        }
    }
}
if(event.which==13 || event.which==9)
{
    if(document.activeElement.id=="txtdealname")
    {
        document.getElementById('drpagencycode').focus();
        return false;
    }  
    else if(document.activeElement.id=="drpagencycode")
    {
     var res=checkValidAgency();
        if(res==false)
        {
            alert("Please Enter Valid Agency Name");
            document.getElementById('drpagencycode').focus();
            return false;
        }    
        document.getElementById('drpsubagcode').focus();
        return false;
    } 
     else if(document.activeElement.id=="drpsubagcode")
    {
        document.getElementById('drpclientname').focus();
        return false;
    } 
    else if(document.activeElement.id=="drpclientname")
    {
        var res=checkValidClient();
        if(res==false)
        {
            alert("Please Enter Valid Client Name");
            document.getElementById('drpclientname').focus();
            return false;
        }    
        document.getElementById('txtfromdate').focus();
        return false;
    }   
     else if(document.activeElement.id=="txtfromdate")
    {
  //  alert("ss");
        document.getElementById('TextBox1').focus();
        return false;
    }
     else if(document.activeElement.id=="TextBox1") {
     if (document.getElementById('drpdealtype').disabled != true) {
         document.getElementById('drpdealtype').focus();
         return false;
     }
     else {
         document.getElementById('drpservicetax').focus();
         return false;
     }
    }
    else if(document.activeElement.id=="drpdealtype")
    {
        document.getElementById('drpservicetax').focus();
        return false;
    }
      else if(document.activeElement.id=="drpservicetax")
    {
        document.getElementById('drpproduct').focus();
        return false;
    }
      else if(document.activeElement.id=="drpproduct")
    {
        document.getElementById('txtexecutive').focus();
        return false;
    }
      else if(document.activeElement.id=="txtexecutive")
    {
         var res=checkValidExecutive();
        if(res==false)
        {
            alert("Please Enter Valid Executive");
            document.getElementById('txtexecutive').focus();
            return false;
        }    
        document.getElementById('txtretainer').focus();
        return false;
    }
      else if(document.activeElement.id=="txtretainer")
    {
          var res=checkValidRetainer();
        if(res==false)
        {
            alert("Please Enter Valid Retainer");
            document.getElementById('txtretainer').focus();
            return false;
        }    
        document.getElementById('drpteamname').focus();
        return false;
    }
     else if(document.activeElement.id=="drpteamname")
    {
        document.getElementById('drprepresentative').focus();
        return false;
    }
      else if(document.activeElement.id=="drprepresentative")
    {
        document.getElementById('txtclosedate').focus();
        return false;
    }
     else if(document.activeElement.id=="txtclosedate")
    {
        document.getElementById('drppaymenttype').focus();
        return false;
    }
    else if(document.activeElement.id=="drppaymenttype")
    {
        if(document.getElementById('txtdealvol').disabled==false)
            document.getElementById('txtdealvol').focus();
        else if(document.getElementById('txtdealvalue').disabled==false)
            document.getElementById('txtdealvalue').focus();    
        else    
            document.getElementById('txtremark').focus();    
        return false;
    }
    else if(document.activeElement.id=="txtdealvol")
    {
        if(document.getElementById('txtdealvalue').disabled==false)
            document.getElementById('txtdealvalue').focus();
        else    
            document.getElementById('txtremark').focus();  
             return false;
    }
     else if(document.activeElement.id=="txtdealvalue")
    {   
            document.getElementById('txtremark').focus();  
             return false;
    }
    else if(document.activeElement.id=="txtremark")
    {
        document.getElementById('txtcaption').focus();  
         return false;
    }
     else if(document.activeElement.id=="txtcaption")
    {
        document.getElementById('drpdealon').focus();  
         return false;
    }
      else if(document.activeElement.id=="drpdealon")
    {
        document.getElementById('txtrono').focus();  
         return false;
    }
      else if(document.activeElement.id=="txtrono")
    {
        document.getElementById('txtrodate').focus();  
         return false;
    }
      else if(document.activeElement.id=="txtrodate")
    {
        document.getElementById('drprostatus').focus();  
         return false;
    }
      else if(document.activeElement.id=="drprostatus")
    {
        document.getElementById('drprptcurrency').focus();  
         return false;
    }
      else if(document.activeElement.id=="drprptcurrency")
    {
        document.getElementById('chkb2b').focus();  
         return false;
    }
       else if(document.activeElement.id=="chkb2b")
    {
        document.getElementById('chkmultiad').focus();  
         return false;
    }
     else if(document.activeElement.id=="chkmultiad")
    {
        document.getElementById('chkseqno').focus();  
         return false;
    }
     else if(document.activeElement.id=="chkseqno")
    {
        document.getElementById('txtseq').focus();  
         return false;
    }
     else if(document.activeElement.id=="txtseq")
    {
        document.getElementById('chkpatricularad').focus();  
         return false;
    }
     else if(document.activeElement.id=="chkpatricularad")
    {
        document.getElementById('drpindustry').focus();  
         return false;
    }
     else if(document.activeElement.id=="drpindustry")
    {
        document.getElementById('lstproduct').focus();  
         return false;
    }
    else if(document.activeElement.id=="lstproduct")
    {
        document.getElementById('drpcenter').focus();  
         return false;
    }
      else if(document.activeElement.id=="drpcenter")
    {
        document.getElementById('drptransation').focus();  
         return false;
    }
    else if (document.activeElement.id == "") {
    document.getElementById('btnNew').focus(); 
        return false;
    }
}
if(event.which==117)
{
    if(colName!="undefined" && colName!=undefined && colName=="Channel")
    {
  
         var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var Return;
         var agcode="";
       if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
            agcode=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
       var subagencycode = document.getElementById('drpsubagcode').value;  
       var seqno=document.getElementById('tblGridelec').rows[activeRow].cells[41].innerHTML;   
       if(seqno.indexOf("<INPUT")>=0)
        seqno="";
       var consumed=document.getElementById('tblGridelec').rows[activeRow].cells[37].innerHTML;
       var balance=document.getElementById('tblGridelec').rows[activeRow].cells[38].innerHTML
         saveInSession(activeRow-1);
       Return = window.showModalDialog("contractChild.aspx?contdate="+document.getElementById('txtcontractdate').value+"&rcptcurr="+document.getElementById('drprptcurrency').value+"&balance="+balance+"&consumed="+consumed+"&seqno="+seqno+"&dealno="+document.getElementById('txtdealno').value+"&validto="+document.getElementById('TextBox1').value+"&validfrom="+document.getElementById('txtfromdate').value+"&agsubcode="+subagencycode+"&agcode="+agcode+"&mode="+mode,"","dialogWidth:1090px; dialogHeight:350px;resizable: yes");
      //  document.getElementById('txtremark').value = Return.remarks;
        //alert(Return);
      
        if(Return!=null)
        {
            binddatainGrid(Return);
            
        }
        return false;
    }
     else if (colName != "undefined" && colName != undefined && colName == "Ad Type") {

    var srcElm = getEventRow();
    activeRow = srcElm.rowIndex;
    saveInSessionPrint(activeRow-1);
  // Return = window.showModalDialog("contractchildprint.aspx?contdate=" + document.getElementById('txtcontractdate').value + "&dealno=" + document.getElementById('txtdealno').value + "&validto=" + document.getElementById('TextBox1').value + "&validfrom=" + document.getElementById('txtfromdate').value + "&mode=" + mode+"&agencycod=" + document.getElementById('hdnagency').value+"&clientcod=" + document.getElementById('hdnclientcod').value, "", "dialogWidth:1100px; dialogHeight:350px;resizable: yes");
    Return = window.showModalDialog("contractchildprint.aspx?contdate=" + document.getElementById('txtcontractdate').value + "&dealno=" + document.getElementById('txtdealno').value + "&validto=" + document.getElementById('TextBox1').value+"&agnsubcod=" + document.getElementById('drpsubagcode').value + "&validfrom=" + document.getElementById('txtfromdate').value + "&mode=" + mode+"&agencycod=" + document.getElementById('hdnagency').value+"&clientcod=" + document.getElementById('hdnclientcod').value, "", "dialogWidth:1100px; dialogHeight:350px;resizable: yes");


    //  document.getElementById('txtremark').value = Return.remarks;
    //alert(Return);
    if (Return != null) {
        binddatainGridprint(Return);
    }
    return false;
    }
}
if(colName=="Total Value" || colName=="Card Prem" || colName=="Contract Prem." || colName=="Contract Rate" || colName=="Card Rate" || colName=="Deviation" || colName=="Disc. Per." || colName=="Min Size" || colName=="Max Size" || colName=="Value From" || colName=="Value To" || colName=="Insertion" || colName=="Total Rate" || colName=="Incentive" || colName=="FCT/NOI/Words" || colName=="Consumed" || colName=="Balance"|| colName == "Contract Amount")
{
try{
  var srcElm1=getEventCell();
    activeCell=srcElm1.cellIndex;
    }
    catch(err){}
   var res=notchar2(event);
   if(res==false)
    return false;
}
if (event.which != 13 && event.which != 9 && event.which != 27 && event.which != 113 && event.keyCode != 8 && event.keyCode != 40 && event.keyCode != 38 && event.keyCode != 16 && event.type != "click")
{
    if (colName == "Section Code" ||colName == "Resource No" || colName == "Source" || colName == "Ad Type" || colName == "Hue" || colName == "Uom" || colName == "Package" || colName == "Category" || colName == "Premium" || colName == "Disc Type" || colName == "Disc On" || colName == "Day" || colName == "Days" || colName == "Comm. Allow" || colName == "Deal Start" || colName == "Currency" || colName == "Rate Code" || colName == "Status" || colName == "Channel" || colName == "Location" || colName == "Adv Type" || colName == "Paid/Bonus" || colName == "Rate Type" || colName == "Program Name" || colName == "BTB" || colName == "Time Band" || colName == "Program Type" || colName == "Position Premium")
    {
        if ((event.which >= 48 && event.which <= 57) || (event.keyCode >= 65 && event.keyCode <= 90)) {
            return true;
        }
        else {
            event.which = 0;
            return false;
        }
    
    }
}
if (event.which != 13 && event.which != 9 && event.which != 27 && event.which != 113 && event.which != 8 && event.which != 40 && event.which != 38 && event.which != 16 && event.which != "click") {
    if (colName == "Deviation" || colName == "Disc. Per." || colName == "Min Size" || colName == "Max Size" || colName == "Value From" || colName == "Value To" || colName == "Insertion" || colName == "Total Rate" || colName == "Contract Amount") {

        if ((event.which >= 48 && event.which <= 57) || (event.which >= 96 && event.which <= 105) || event.which == 110 || event.which == 37 || event.which == 39 || event.which == 34 || event.which == 46) {
            return true;
        }
        else {
            event.keyCode = 0;
            return false;
        }
    }
}
if((event.which== 13 || event.which== 9) && document.activeElement.id!="lstcommon" && document.getElementById('divprint').style.display=="none")
{
 activeIDNo=document.activeElement;
 var srcElm=getEventRow();
 if(activeRow=="")
 activeRow=srcElm.rowIndex;
     if(colName=="Contract Rate" || colName=="Card Rate")
           {
                if(activeRow!="")
               {
                   var srcElem=document.getElementById('tblGridelec').rows[activeRow];
                   var srcElm1=getEventCell();
                   activeCell=srcElm1.cellIndex;
                   var cardrate="";
                   var contractrate="";
                   if(activeCell=="18")
                    {
                        if(srcElem.cells[18].childNodes[0]!="undefined" && srcElem.cells[18].childNodes[0]!=undefined && srcElem.cells[18].childNodes[0].value!=undefined)
                        cardrate=srcElem.cells[18].childNodes[0].value;
                        else
                        cardrate=srcElem.cells[18].childNodes[1].value;  
                    }
                    else{
                        cardrate=srcElem.cells[18].innerHTML;
                    }
                   
                  if(activeCell=="17")
                    {
                        if(srcElem.cells[17].childNodes[0]!="undefined" && srcElem.cells[17].childNodes[0]!=undefined && srcElem.cells[17].childNodes[0].value!=undefined)
                        contractrate=srcElem.cells[17].childNodes[0].value;
                        else
                        contractrate=srcElem.cells[17].childNodes[1].value;  
                    }
                    else{
                        contractrate=srcElem.cells[17].innerHTML;
                    }  
                    if(contractrate!="" && cardrate!="")
                    {
                        var dev=parseFloat(cardrate) - parseFloat(contractrate);
                        document.getElementById('tblGridelec').rows[activeRow].cells[19].innerHTML=dev;
                    }
               }    
          //  return false;
           }
}
else if((event.which== 13 || event.which== 9) && document.activeElement.id!="lstcommon" && document.getElementById('div_electronics').style.display=="none")
{
 activeIDNo=document.activeElement;
     if(colName=="Contract Rate" || colName=="Card Rate")
           {
                if(activeRow!="")
               {
                   var srcElem=document.getElementById('tblGrid').rows[activeRow];
                   var srcElm1=getEventCell();
                   activeCell=srcElm1.cellIndex;
                   var cardrate="";
                   var contractrate="";
                   if(activeCell=="9")
                    {
                        if(srcElem.cells[9].childNodes[0]!="undefined" && srcElem.cells[9].childNodes[0]!=undefined && srcElem.cells[9].childNodes[0].value!=undefined)
                        cardrate=srcElem.cells[9].childNodes[0].value;
                        else
                        cardrate=srcElem.cells[9].childNodes[1].value;  
                    }
                    else{
                        cardrate=srcElem.cells[9].innerHTML;
                    }
                   
                  if(activeCell=="8")
                    {
                        if(srcElem.cells[8].childNodes[0]!="undefined" && srcElem.cells[8].childNodes[0]!=undefined && srcElem.cells[8].childNodes[0].value!=undefined)
                        contractrate=srcElem.cells[8].childNodes[0].value;
                        else
                        contractrate=srcElem.cells[8].childNodes[1].value;  
                    }
                    else{
                        contractrate=srcElem.cells[8].innerHTML;
                    }  
                    if(contractrate!="" && cardrate!="")
                    {
                        var dev=parseFloat(cardrate) - parseFloat(contractrate);
                        document.getElementById('tblGrid').rows[activeRow].cells[10].innerHTML=dev;
                    }
               }    
          //  return false;
           }
}
if ((event.which == 13 || event.type == "click") && document.activeElement.id == "lstcommon")
     {
       
        document.getElementById("divcommon").style.display="none";
        if(activeIDNo!=null)
        {
          // document.getElementById(activeIDNo).value=document.getElementById("lstcommon").value;
          if(document.getElementById("lstcommon").selectedIndex!=-1)
          {
             //alert("in1");
             //alert(document.getElementById("lstcommon").options[document.getElementById("lstcommon").selectedIndex].text + "("+document.getElementById("lstcommon").value+")");
            activeIDNo.value=document.getElementById("lstcommon").options[document.getElementById("lstcommon").selectedIndex].text + "("+document.getElementById("lstcommon").value+")";
            //alert(activeIDNo.value);
           } 
           if(document.getElementById('divprint').style.display=="none" && (colName=="Channel" || colName=="Location" || colName=="Adv Type" || colName=="Rate Type" || colName=="Day" || colName=="Category"  || colName=="BTB" || colName=="FCT/NOI/Words" || colName=="Package" || colName=="Value From" || colName=="Value To" || colName=="Disc Type" || colName=="Disc. Per." || colName=="Premium" || colName=="Card Prem" || colName=="Contract Prem." || colName=="Min Size" || colName=="Max Size" || colName=="Program Type" || colName=="Program Name"  || colName=="Comm. Allow" || colName=="Rate Code" || colName=="Source" || colName=="Section Code" || colName=="Resource No"))
          
          // if(colName=="Rate Code" || colName=="Adv Type" || colName=="Rate Type" || colName=="Category" || colName=="BTB" || colName=="FCT/NOI/Words" || colName=="Package" || colName=="Source" || colName=="Currency")
           {
                if(activeRow!="")
               {
                   var srcElem=document.getElementById('tblGridelec').rows[activeRow];
//                   string compcode_p, string unit_p, string channel_p, string location_p, string adtype_p, string ratetype, string day_p, 
//                   string category_p, string btb_p, string fct_p, string validfrom_p, string validto_p, 
//                   string package_p, string valufrom_p, string valueto_p, string disctype_p, string disper, string premium, string cardprem_p, 
//                   string contprem_p, string minsize_p, string maxsize_p, string progtype_p, string progname_p, string commallow_p, string ratecode_p, string source_p, string dateformat)
                   var compcode_p=document.getElementById('hiddencompcode').value;
                   var unit_p=document.getElementById('hiddencenter').value;
                   var currency_p="";
                    if(activeCell=="23")
                    {
                        if(srcElem.cells[23].childNodes[0]!="undefined" && srcElem.cells[23].childNodes[0]!=undefined && srcElem.cells[23].childNodes[0].value!=undefined)
                        currency_p=srcElem.cells[23].childNodes[0].value;
                        else
                        currency_p=srcElem.cells[23].childNodes[1].value;  
                    }
                    else{
                        currency_p=srcElem.cells[23].innerHTML;
                    }
                    
                   if(currency_p.indexOf("(")>0)
                        currency_p=currency_p.substring(currency_p.lastIndexOf('(')+1,currency_p.lastIndexOf(')'));
                        
                   var channel_p="";
                    if(activeCell=="0")
                    {
                        if(srcElem.cells[0].childNodes[0]!="undefined" && srcElem.cells[0].childNodes[0]!=undefined && srcElem.cells[0].childNodes[0].value!=undefined)
                        channel_p=srcElem.cells[0].childNodes[0].value;
                        else
                        channel_p=srcElem.cells[0].childNodes[1].value;  
                    }
                    else{
                        channel_p=srcElem.cells[0].innerHTML;
                    }
                   if(channel_p.indexOf("(")>0)
                        channel_p=channel_p.substring(channel_p.lastIndexOf('(')+1,channel_p.lastIndexOf(')'));
                   var location_p="";
                   if(activeCell=="1")
                    {
                        if(srcElem.cells[1].childNodes[0]!="undefined" && srcElem.cells[1].childNodes[0]!=undefined && srcElem.cells[1].childNodes[0].value!=undefined)
                        location_p=srcElem.cells[1].childNodes[0].value;
                        else
                        location_p=srcElem.cells[1].childNodes[1].value;  
                    }
                    else{
                        location_p=srcElem.cells[1].innerHTML;
                    }
                    if(location_p.indexOf("(")>0)
                        location_p=location_p.substring(location_p.lastIndexOf('(')+1,location_p.lastIndexOf(')'));
                   var adtype_p="";
                   if(activeCell=="2")
                    {
                        if(srcElem.cells[2].childNodes[0]!="undefined" && srcElem.cells[2].childNodes[0]!=undefined && srcElem.cells[2].childNodes[0].value!=undefined)
                        adtype_p=srcElem.cells[2].childNodes[0].value;
                        else
                        adtype_p=srcElem.cells[2].childNodes[1].value;  
                    }
                    else{
                        adtype_p=srcElem.cells[2].innerHTML;
                    }
                    if(adtype_p.indexOf("(")>0)
                        adtype_p=adtype_p.substring(adtype_p.lastIndexOf('(')+1,adtype_p.lastIndexOf(')'));
                   var ratetype="";
                    if(activeCell=="4")
                    {
                        if(srcElem.cells[4].childNodes[0]!="undefined" && srcElem.cells[4].childNodes[0]!=undefined && srcElem.cells[4].childNodes[0].value!=undefined)
                        ratetype=srcElem.cells[4].childNodes[0].value;
                        else
                        {
                        try{
                        ratetype=srcElem.cells[4].childNodes[1].value;  
                        }
                        catch(err){
                         ratetype=srcElem.cells[4].innerHTML;
                        }
                        }
                    }
                    else{
                        ratetype=srcElem.cells[4].innerHTML;
                    }
                    if(ratetype.indexOf("(")>0)
                        ratetype=ratetype.substring(ratetype.lastIndexOf('(')+1,ratetype.lastIndexOf(')'));
                   var day_p="";
                    if(activeCell=="8")
                    {
                        if(srcElem.cells[8].childNodes[0]!="undefined" && srcElem.cells[8].childNodes[0]!=undefined && srcElem.cells[8].childNodes[0].value!=undefined)
                        day_p=srcElem.cells[8].childNodes[0].value;
                        else
                        day_p=srcElem.cells[8].childNodes[1].value;  
                    }
                    else{
                        day_p=srcElem.cells[8].innerHTML;
                    }
                   var category_p="";
                    if(activeCell=="26")
                    {
                        if(srcElem.cells[26].childNodes[0]!="undefined" && srcElem.cells[26].childNodes[0]!=undefined && srcElem.cells[26].childNodes[0].value!=undefined)
                        category_p=srcElem.cells[26].childNodes[0].value;
                        else
                        category_p=srcElem.cells[26].childNodes[1].value;  
                    }
                    else{
                        category_p=srcElem.cells[26].innerHTML;
                    }
                    if(category_p.indexOf("(")>0)
                        category_p=category_p.substring(category_p.lastIndexOf('(')+1,category_p.lastIndexOf(')'));
                   var btb_p="";
                    if(activeCell=="5")
                    {
                        if(srcElem.cells[5].childNodes[0]!="undefined" && srcElem.cells[5].childNodes[0]!=undefined && srcElem.cells[5].childNodes[0].value!=undefined)
                        btb_p=srcElem.cells[5].childNodes[0].value;
                        else
                        btb_p=srcElem.cells[5].childNodes[1].value;  
                    }
                    else{
                        btb_p=srcElem.cells[5].innerHTML;
                    }
                    if(btb_p.indexOf("(")>0)
                        btb_p=btb_p.substring(btb_p.lastIndexOf('(')+1,btb_p.lastIndexOf(')'));
                   var fct_p="";
                    if(activeCell=="9")
                    {
                        if(srcElem.cells[9].childNodes[0]!="undefined" && srcElem.cells[9].childNodes[0]!=undefined && srcElem.cells[9].childNodes[0].value!=undefined)
                        fct_p=srcElem.cells[9].childNodes[0].value;
                        else
                        fct_p=srcElem.cells[9].childNodes[1].value;  
                    }
                    else{
                        fct_p=srcElem.cells[9].innerHTML;
                    }
                    if(fct_p.indexOf("(")>0)
                        fct_p=fct_p.substring(fct_p.lastIndexOf('(')+1,fct_p.lastIndexOf(')'));
                   var validfrom_p=document.getElementById('txtfromdate').value;
                   var validto_p=document.getElementById('TextBox1').value;
                   var package_p="";
                   if(activeCell=="10")
                    {
                        if(srcElem.cells[10].childNodes[0]!="undefined" && srcElem.cells[10].childNodes[0]!=undefined && srcElem.cells[10].childNodes[0].value!=undefined)
                        package_p=srcElem.cells[10].childNodes[0].value;
                        else
                        package_p=srcElem.cells[10].childNodes[1].value;  
                    }
                    else{
                        package_p=srcElem.cells[10].innerHTML;
                    }
                    if(package_p.indexOf("(")>0)
                        package_p=package_p.substring(package_p.lastIndexOf('(')+1,package_p.lastIndexOf(')'));
                   var valufrom_p="";
                     if(activeCell=="11")
                    {
                        if(srcElem.cells[11].childNodes[0]!="undefined" && srcElem.cells[11].childNodes[0]!=undefined && srcElem.cells[11].childNodes[0].value!=undefined)
                        valufrom_p=srcElem.cells[11].childNodes[0].value;
                        else
                        valufrom_p=srcElem.cells[11].childNodes[1].value;  
                    }
                    else{
                        valufrom_p=srcElem.cells[11].innerHTML;
                    }
                   var valueto_p="";
                     if(activeCell=="12")
                    {
                        if(srcElem.cells[12].childNodes[0]!="undefined" && srcElem.cells[12].childNodes[0]!=undefined && srcElem.cells[12].childNodes[0].value!=undefined)
                        valueto_p=srcElem.cells[12].childNodes[0].value;
                        else
                        valueto_p=srcElem.cells[12].childNodes[1].value;  
                    }
                    else{
                        valueto_p=srcElem.cells[12].innerHTML;
                    }
                   var disctype_p="";
                     if(activeCell=="13")
                    {
                        if(srcElem.cells[13].childNodes[0]!="undefined" && srcElem.cells[13].childNodes[0]!=undefined && srcElem.cells[13].childNodes[0].value!=undefined)
                        disctype_p=srcElem.cells[13].childNodes[0].value;
                        else
                        disctype_p=srcElem.cells[13].childNodes[1].value;  
                    }
                    else{
                        disctype_p=srcElem.cells[13].innerHTML;
                    }
                    if(disctype_p.indexOf("(")>0)
                        disctype_p=disctype_p.substring(disctype_p.lastIndexOf('(')+1,disctype_p.lastIndexOf(')'));
                   var disper="";
                    if(activeCell=="14")
                    {
                        if(srcElem.cells[14].childNodes[0]!="undefined" && srcElem.cells[14].childNodes[0]!=undefined && srcElem.cells[14].childNodes[0].value!=undefined)
                        disper=srcElem.cells[14].childNodes[0].value;
                        else
                        disper=srcElem.cells[14].childNodes[1].value;  
                    }
                    else{
                        disper=srcElem.cells[14].innerHTML;
                    }
                   var premium="";
                     if(activeCell=="15")
                    {
                        if(srcElem.cells[15].childNodes[0]!="undefined" && srcElem.cells[15].childNodes[0]!=undefined && srcElem.cells[15].childNodes[0].value!=undefined)
                        premium=srcElem.cells[15].childNodes[0].value;
                        else
                        premium=srcElem.cells[15].childNodes[1].value;  
                    }
                    else{
                        premium=srcElem.cells[15].innerHTML;
                    }
                    if(premium.indexOf("(")>0)
                        premium=premium.substring(premium.lastIndexOf('(')+1,premium.lastIndexOf(')'));
                   var cardprem_p="";
                     if(activeCell=="20")
                    {
                        if(srcElem.cells[20].childNodes[0]!="undefined" && srcElem.cells[20].childNodes[0]!=undefined && srcElem.cells[20].childNodes[0].value!=undefined)
                        cardprem_p=srcElem.cells[20].childNodes[0].value;
                        else
                        cardprem_p=srcElem.cells[20].childNodes[1].value;  
                    }
                    else{
                        cardprem_p=srcElem.cells[20].innerHTML;
                    }
       
                   var contprem_p="";
                    if(activeCell=="16")
                    {
                        if(srcElem.cells[16].childNodes[0]!="undefined" && srcElem.cells[16].childNodes[0]!=undefined && srcElem.cells[16].childNodes[0].value!=undefined)
                        contprem_p=srcElem.cells[16].childNodes[0].value;
                        else
                        contprem_p=srcElem.cells[16].childNodes[1].value;  
                    }
                    else{
                        contprem_p=srcElem.cells[16].innerHTML;
                    }
                   var minsize_p="";
                     if(activeCell=="21")
                    {
                        if(srcElem.cells[21].childNodes[0]!="undefined" && srcElem.cells[21].childNodes[0]!=undefined && srcElem.cells[21].childNodes[0].value!=undefined)
                        minsize_p=srcElem.cells[21].childNodes[0].value;
                        else
                        minsize_p=srcElem.cells[21].childNodes[1].value;  
                    }
                    else{
                        minsize_p=srcElem.cells[21].innerHTML;
                    }
                   var maxsize_p="";
                    if(activeCell=="22")
                    {
                        if(srcElem.cells[22].childNodes[0]!="undefined" && srcElem.cells[22].childNodes[0]!=undefined && srcElem.cells[22].childNodes[0].value!=undefined)
                        maxsize_p=srcElem.cells[22].childNodes[0].value;
                        else
                        maxsize_p=srcElem.cells[22].childNodes[1].value;  
                    }
                    else{
                        maxsize_p=srcElem.cells[22].innerHTML;
                    }
                   var progtype_p="";
                   if(activeCell=="25")
                    {
                        if(srcElem.cells[25].childNodes[0]!="undefined" && srcElem.cells[25].childNodes[0]!=undefined && srcElem.cells[25].childNodes[0].value!=undefined)
                        progtype_p=srcElem.cells[25].childNodes[0].value;
                        else
                        progtype_p=srcElem.cells[25].childNodes[1].value;  
                    }
                    else{
                        progtype_p=srcElem.cells[25].innerHTML;
                    }
                     if(progtype_p.indexOf("(")>0)
                        progtype_p=progtype_p.substring(progtype_p.lastIndexOf('(')+1,progtype_p.lastIndexOf(')'));
                   var progname_p="";
                    if(activeCell=="6")
                    {
                        if(srcElem.cells[6].childNodes[0]!="undefined" && srcElem.cells[6].childNodes[0]!=undefined && srcElem.cells[6].childNodes[0].value!=undefined)
                        progname_p=srcElem.cells[6].childNodes[0].value;
                        else
                        progname_p=srcElem.cells[6].childNodes[1].value;  
                    }
                    else{
                        progname_p=srcElem.cells[6].innerHTML;
                    }
                     if(progname_p.indexOf("(")>0)
                        progname_p=progname_p.substring(progname_p.lastIndexOf('(')+1,progname_p.lastIndexOf(')'));
                   var commallow_p="";
                    if(activeCell=="27")
                    {
                        if(srcElem.cells[27].childNodes[0]!="undefined" && srcElem.cells[27].childNodes[0]!=undefined && srcElem.cells[27].childNodes[0].value!=undefined)
                        commallow_p=srcElem.cells[27].childNodes[0].value;
                        else
                        commallow_p=srcElem.cells[27].childNodes[1].value;  
                    }
                    else{
                        commallow_p=srcElem.cells[27].innerHTML;
                    }
                    if(commallow_p.indexOf("(")>0)
                        commallow_p=commallow_p.substring(commallow_p.lastIndexOf('(')+1,commallow_p.lastIndexOf(')'));
                   var ratecode_p="";
                    if(activeCell=="29")
                    {
                        if(srcElem.cells[29].childNodes[0]!="undefined" && srcElem.cells[29].childNodes[0]!=undefined && srcElem.cells[29].childNodes[0].value!=undefined)
                        ratecode_p=srcElem.cells[29].childNodes[0].value;
                        else
                        ratecode_p=srcElem.cells[29].childNodes[1].value;  
                    }
                    else{
                        ratecode_p=srcElem.cells[29].innerHTML;
                    }
                    if(ratecode_p.indexOf("(")>0)
                        ratecode_p=ratecode_p.substring(ratecode_p.lastIndexOf('(')+1,ratecode_p.lastIndexOf(')'));
                   var source_p="";
                    if(activeCell=="33")
                    {
                        if(srcElem.cells[33].childNodes[0]!="undefined" && srcElem.cells[33].childNodes[0]!=undefined && srcElem.cells[33].childNodes[0].value!=undefined)
                        source_p=srcElem.cells[33].childNodes[0].value;
                        else
                        source_p=srcElem.cells[33].childNodes[1].value;  
                    }
                    else{
                        source_p=srcElem.cells[33].innerHTML;
                    }
                     if(source_p.indexOf("(")>0)
                        source_p=source_p.substring(source_p.lastIndexOf('(')+1,source_p.lastIndexOf(')'));
                   var dateformat=document.getElementById('hiddendateformat').value;
                   var contratcrate=srcElem.cells[17].innerHTML;
                   var agcode="";
                   if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
                        agcode=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
                   var subagencycode = document.getElementById('drpsubagcode').value     
                   var res=ContractMaster.getrateforcontract_Elec( compcode_p, unit_p, channel_p, location_p, adtype_p, ratetype, day_p,category_p, btb_p, fct_p, validfrom_p, validto_p,package_p, valufrom_p, valueto_p, disctype_p, disper, premium, cardprem_p,contprem_p, minsize_p, maxsize_p, progtype_p, progname_p, commallow_p, ratecode_p, source_p, dateformat,currency_p,contratcrate,agcode,subagencycode);
                   var ds=res.value;
                   if(ds==null)
                   {
                    alert(res.error.description);
                    return false;
                   }
                   document.getElementById('tblGridelec').rows[activeRow].cells[18].innerHTML="";
                   document.getElementById('tblGridelec').rows[activeRow].cells[34].innerHTML="";
                    document.getElementById('tblGridelec').rows[activeRow].cells[17].innerHTML="";
                   if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
                   {
                        if(ds.Tables[0].Rows[0].card_rate!=null)
                            document.getElementById('tblGridelec').rows[activeRow].cells[18].innerHTML=ds.Tables[0].Rows[0].card_rate;
                        if(ds.Tables[0].Rows[0].TOTALVAL!=null)   
                            document.getElementById('tblGridelec').rows[activeRow].cells[34].innerHTML=ds.Tables[0].Rows[0].TOTALVAL;
                            printTotal();
                   }
               }
           }
           else if(document.getElementById('div_electronics').style.display=="none" && (colName=="Ad Type" || colName=="Category" || colName=="Package" || colName=="Hue" || colName=="Uom" || colName=="Currency"  || colName=="Rate Code") )
           {
          
           if(activeRow!="")
           {
           var srcElem=document.getElementById('tblGrid').rows[activeRow];
           var adcat="";
           var pkgcode=""; 
           var color="";
           var currency="";
           var uom="";
           var advtype="";
         var  ratecode="";
           if(activeCell=="4")
           {
               if(srcElem.cells[4].childNodes[0]!="undefined" && srcElem.cells[4].childNodes[0]!=undefined && srcElem.cells[4].childNodes[0].value!=undefined)
                 adcat=srcElem.cells[4].childNodes[0].value;
               else
               {
                if(srcElem.cells[4].childNodes[1]!="undefined" && srcElem.cells[4].childNodes[1]!=undefined && srcElem.cells[4].childNodes[1].value!=undefined)
                    adcat=srcElem.cells[4].childNodes[1].value;  
                else
                    adcat=srcElem.cells[4].innerHTML;    
               }  
           }
           else{
             adcat=srcElem.cells[4].innerHTML;
           }
           
           if(activeCell=="3")
           {
            if(srcElem.cells[3].childNodes[0]!="undefined" && srcElem.cells[3].childNodes[0]!=undefined && srcElem.cells[3].childNodes[0].value!=undefined)
                pkgcode=srcElem.cells[3].childNodes[0].value;
             else
             {
                if(srcElem.cells[3].childNodes[1]!="undefined" && srcElem.cells[3].childNodes[1]!=undefined && srcElem.cells[3].childNodes[1].value!=undefined)
                    pkgcode=srcElem.cells[3].childNodes[1].value; 
                else
                    pkgcode=srcElem.cells[3].innerHTML;    
             }    
           }
           else{
             pkgcode=srcElem.cells[3].innerHTML;
           }
            if(activeCell=="1")
           {
            if(srcElem.cells[1].childNodes[0]!="undefined" && srcElem.cells[1].childNodes[0]!=undefined && srcElem.cells[1].childNodes[0].value!=undefined)
                color=srcElem.cells[1].childNodes[0].value;
            else
            {
                if(srcElem.cells[1].childNodes[1]!="undefined" && srcElem.cells[1].childNodes[1]!=undefined && srcElem.cells[1].childNodes[1].value!=undefined)
                    color=srcElem.cells[1].childNodes[1].value;  
                else
                    color=srcElem.cells[1].innerHTML;      
            }    
           }
           else{
             color=srcElem.cells[1].innerHTML;
           }
            if(activeCell=="22")
           {
            if(srcElem.cells[22].childNodes[0]!="undefined" && srcElem.cells[22].childNodes[0]!=undefined && srcElem.cells[22].childNodes[0].value!=undefined)
                currency=srcElem.cells[22].childNodes[0].value;
            else
            {
                if(srcElem.cells[22].childNodes[1]!="undefined" && srcElem.cells[22].childNodes[1]!=undefined && srcElem.cells[22].childNodes[1].value!=undefined)
                    currency=srcElem.cells[22].childNodes[1].value; 
                else
                    currency=srcElem.cells[22].innerHTML;       
            }    
           }
           else{
             currency=srcElem.cells[22].innerHTML;
           }
            if(activeCell=="2")
           {
            if(srcElem.cells[2].childNodes[0]!="undefined" && srcElem.cells[2].childNodes[0]!=undefined && srcElem.cells[2].childNodes[0].value!=undefined)
                uom=srcElem.cells[2].childNodes[0].value;
            else
            {
                if(srcElem.cells[2].childNodes[1]!="undefined" && srcElem.cells[2].childNodes[1]!=undefined && srcElem.cells[2].childNodes[1].value!=undefined)
                    uom=srcElem.cells[2].childNodes[1].value;  
                else
                   uom=srcElem.cells[2].innerHTML;       
            }   
           }
           else{
             uom=srcElem.cells[2].innerHTML;
           }
            if(activeCell=="0")
           {
           // alert("activeCell");
          //  alert(srcElem.cells[0]);
          //  alert(srcElem.cells[0].innerHTML);
            if(srcElem.cells[0].childNodes[0]!="undefined" && srcElem.cells[0].childNodes[0]!=undefined && srcElem.cells[0].childNodes[0].value!=undefined)
                advtype=srcElem.cells[0].childNodes[0].value;
            else
            {
                if(srcElem.cells[0].childNodes[1]!="undefined" && srcElem.cells[0].childNodes[1]!=undefined && srcElem.cells[0].childNodes[1].value!=undefined)
                    advtype=srcElem.cells[0].childNodes[1].value;  
                else    
                    advtype=srcElem.cells[0].innerHTML;      
            }    
           }
           else{
             advtype=srcElem.cells[0].innerHTML;
           }
           
           
             if(activeCell=="23")
           {
            if(srcElem.cells[23].childNodes[0]!="undefined" && srcElem.cells[23].childNodes[0]!=undefined && srcElem.cells[23].childNodes[0].value!=undefined)
                ratecode=srcElem.cells[23].childNodes[0].value;
            else
                ratecode=srcElem.cells[23].childNodes[1].value;    
           }
           else{
             ratecode=srcElem.cells[23].innerHTML;
           }
           
           
           
            getCardRate(adcat,pkgcode,color,currency,uom,advtype,document.getElementById('txtfromdate').value,document.getElementById('TextBox1').value,document.getElementById('hiddencompcode').value,document.getElementById('hiddendateformat').value,ratecode);
            }
           }
           else if(colName=="Premium")
           {
                bindPremCharges(document.getElementById("lstcommon").value);
            }

            else if (colName == "Position Premium") {
                bindpositionPremCharges(document.getElementById("lstcommon").value);
            }
           else  if(colName=="Days" || colName=="Time Band")
           {
            var day="";
            for(var i=0;i<document.getElementById("lstcommon").options.length;i++)
            {
             if(document.getElementById("lstcommon").options[i].selected==true)
             {
                if(day=="")
                    day=document.getElementById("lstcommon").options[i].value;
                else
                    day=day + "," + document.getElementById("lstcommon").options[i].value;    
             }   
            }
            activeIDNo.value=day;
           }


           activeIDNo.focus();
         //  alert(activeIDNo.value);
        }   
     //   alert("activeIDNo");
        activeIDNo="";
       //alert(activeIDNo);
        return false;
     }
     else if (event.which== 13 && colName=="Premium")
     {
        bindPremCharges(document.getElementById("lstcommon").value);
         checkForEnter();
     }
     else if (event.which== 13 &&colName == "Position Premium") {
         bindpositionPremCharges(document.getElementById("lstcommon").value);
    checkForEnter();
     }
     else if( event.which== 13 && colName=="FCT/NOI/Words" || colName=="Value From" || colName=="Value To" || colName=="Disc. Per."  || colName=="Card Prem" || colName=="Contract Prem." || colName=="Min Size" || colName=="Max Size")
    {
    try{
	 if(activeRow!="" && document.getElementById('divprint').style.display=="none")
               {
                   var srcElem=document.getElementById('tblGridelec').rows[activeRow];
//                   string compcode_p, string unit_p, string channel_p, string location_p, string adtype_p, string ratetype, string day_p, 
//                   string category_p, string btb_p, string fct_p, string validfrom_p, string validto_p, 
//                   string package_p, string valufrom_p, string valueto_p, string disctype_p, string disper, string premium, string cardprem_p, 
//                   string contprem_p, string minsize_p, string maxsize_p, string progtype_p, string progname_p, string commallow_p, string ratecode_p, string source_p, string dateformat)
                   var compcode_p=document.getElementById('hiddencompcode').value;
                   var unit_p=document.getElementById('hiddencenter').value;
                   var currency_p="";
                    if(activeCell=="23")
                    {
                        if(srcElem.cells[23].childNodes[0]!="undefined" && srcElem.cells[23].childNodes[0]!=undefined && srcElem.cells[23].childNodes[0].value!=undefined)
                        currency_p=srcElem.cells[23].childNodes[0].value;
                        else
                        currency_p=srcElem.cells[23].childNodes[1].value;  
                    }
                    else{
                        currency_p=srcElem.cells[23].innerHTML;
                    }
                   if(currency_p.indexOf("(")>0)
                        currency_p=currency_p.substring(currency_p.lastIndexOf('(')+1,currency_p.lastIndexOf(')'));
                        
                   var channel_p="";
                    if(activeCell=="0")
                    {
                        if(srcElem.cells[0].childNodes[0]!="undefined" && srcElem.cells[0].childNodes[0]!=undefined && srcElem.cells[0].childNodes[0].value!=undefined)
                        channel_p=srcElem.cells[0].childNodes[0].value;
                        else
                        channel_p=srcElem.cells[0].childNodes[1].value;  
                    }
                    else{
                        channel_p=srcElem.cells[0].innerHTML;
                    }
                   if(channel_p.indexOf("(")>0)
                        channel_p=channel_p.substring(channel_p.lastIndexOf('(')+1,channel_p.lastIndexOf(')'));
                   var location_p="";
                   if(activeCell=="1")
                    {
                        if(srcElem.cells[1].childNodes[0]!="undefined" && srcElem.cells[1].childNodes[0]!=undefined && srcElem.cells[1].childNodes[0].value!=undefined)
                        location_p=srcElem.cells[1].childNodes[0].value;
                        else
                        location_p=srcElem.cells[1].childNodes[1].value;  
                    }
                    else{
                        location_p=srcElem.cells[1].innerHTML;
                    }
                    if(location_p.indexOf("(")>0)
                        location_p=location_p.substring(location_p.lastIndexOf('(')+1,location_p.lastIndexOf(')'));
                   var adtype_p="";
                   if(activeCell=="2")
                    {
                        if(srcElem.cells[2].childNodes[0]!="undefined" && srcElem.cells[2].childNodes[0]!=undefined && srcElem.cells[2].childNodes[0].value!=undefined)
                        adtype_p=srcElem.cells[2].childNodes[0].value;
                        else
                        adtype_p=srcElem.cells[2].childNodes[1].value;  
                    }
                    else{
                        adtype_p=srcElem.cells[2].innerHTML;
                    }
                    if(adtype_p.indexOf("(")>0)
                        adtype_p=adtype_p.substring(adtype_p.lastIndexOf('(')+1,adtype_p.lastIndexOf(')'));
                   var ratetype="";
                    if(activeCell=="4")
                    {
                        if(srcElem.cells[4].childNodes[0]!="undefined" && srcElem.cells[4].childNodes[0]!=undefined && srcElem.cells[4].childNodes[0].value!=undefined)
                        ratetype=srcElem.cells[4].childNodes[0].value;
                        else
                        ratetype=srcElem.cells[4].childNodes[1].value;  
                    }
                    else{
                        ratetype=srcElem.cells[4].innerHTML;
                    }
                    if(ratetype.indexOf("(")>0)
                        ratetype=ratetype.substring(ratetype.lastIndexOf('(')+1,ratetype.lastIndexOf(')'));
                   var day_p="";
                    if(activeCell=="8")
                    {
                        if(srcElem.cells[8].childNodes[0]!="undefined" && srcElem.cells[8].childNodes[0]!=undefined && srcElem.cells[8].childNodes[0].value!=undefined)
                        day_p=srcElem.cells[8].childNodes[0].value;
                        else
                        day_p=srcElem.cells[8].childNodes[1].value;  
                    }
                    else{
                        day_p=srcElem.cells[8].innerHTML;
                    }
                   var category_p="";
                    if(activeCell=="26")
                    {
                        if(srcElem.cells[26].childNodes[0]!="undefined" && srcElem.cells[26].childNodes[0]!=undefined && srcElem.cells[26].childNodes[0].value!=undefined)
                        category_p=srcElem.cells[26].childNodes[0].value;
                        else
                        category_p=srcElem.cells[26].childNodes[1].value;  
                    }
                    else{
                        category_p=srcElem.cells[26].innerHTML;
                    }
                    if(category_p.indexOf("(")>0)
                        category_p=category_p.substring(category_p.lastIndexOf('(')+1,category_p.lastIndexOf(')'));
                   var btb_p="";
                    if(activeCell=="5")
                    {
                        if(srcElem.cells[5].childNodes[0]!="undefined" && srcElem.cells[5].childNodes[0]!=undefined && srcElem.cells[5].childNodes[0].value!=undefined)
                        btb_p=srcElem.cells[5].childNodes[0].value;
                        else
                        btb_p=srcElem.cells[5].childNodes[1].value;  
                    }
                    else{
                        btb_p=srcElem.cells[5].innerHTML;
                    }
                    if(btb_p.indexOf("(")>0)
                        btb_p=btb_p.substring(btb_p.lastIndexOf('(')+1,btb_p.lastIndexOf(')'));
                   var fct_p="";
                    if(activeCell=="9")
                    {
                        if(srcElem.cells[9].childNodes[0]!="undefined" && srcElem.cells[9].childNodes[0]!=undefined && srcElem.cells[9].childNodes[0].value!=undefined)
                        fct_p=srcElem.cells[9].childNodes[0].value;
                        else
                        fct_p=srcElem.cells[9].childNodes[1].value;  
                    }
                    else{
                        fct_p=srcElem.cells[9].innerHTML;
                    }
                    if(fct_p.indexOf("(")>0)
                        fct_p=fct_p.substring(fct_p.lastIndexOf('(')+1,fct_p.lastIndexOf(')'));
                   var validfrom_p=document.getElementById('txtfromdate').value;
                   var validto_p=document.getElementById('TextBox1').value;
                   var package_p="";
                   if(activeCell=="10")
                    {
                        if(srcElem.cells[10].childNodes[0]!="undefined" && srcElem.cells[10].childNodes[0]!=undefined && srcElem.cells[10].childNodes[0].value!=undefined)
                        package_p=srcElem.cells[10].childNodes[0].value;
                        else
                        package_p=srcElem.cells[10].childNodes[1].value;  
                    }
                    else{
                        package_p=srcElem.cells[10].innerHTML;
                    }
                    if(package_p.indexOf("(")>0)
                        package_p=package_p.substring(package_p.lastIndexOf('(')+1,package_p.lastIndexOf(')'));
                   var valufrom_p="";
                     if(activeCell=="11")
                    {
                        if(srcElem.cells[11].childNodes[0]!="undefined" && srcElem.cells[11].childNodes[0]!=undefined && srcElem.cells[11].childNodes[0].value!=undefined)
                        valufrom_p=srcElem.cells[11].childNodes[0].value;
                        else
                        valufrom_p=srcElem.cells[11].childNodes[1].value;  
                    }
                    else{
                        valufrom_p=srcElem.cells[11].innerHTML;
                    }
                   var valueto_p="";
                     if(activeCell=="12")
                    {
                        if(srcElem.cells[12].childNodes[0]!="undefined" && srcElem.cells[12].childNodes[0]!=undefined && srcElem.cells[12].childNodes[0].value!=undefined)
                        valueto_p=srcElem.cells[12].childNodes[0].value;
                        else
                        valueto_p=srcElem.cells[12].childNodes[1].value;  
                    }
                    else{
                        valueto_p=srcElem.cells[12].innerHTML;
                    }
                   var disctype_p="";
                     if(activeCell=="13")
                    {
                        if(srcElem.cells[13].childNodes[0]!="undefined" && srcElem.cells[13].childNodes[0]!=undefined && srcElem.cells[13].childNodes[0].value!=undefined)
                        disctype_p=srcElem.cells[13].childNodes[0].value;
                        else
                        disctype_p=srcElem.cells[13].childNodes[1].value;  
                    }
                    else{
                        disctype_p=srcElem.cells[13].innerHTML;
                    }
                    if(disctype_p.indexOf("(")>0)
                        disctype_p=disctype_p.substring(disctype_p.lastIndexOf('(')+1,disctype_p.lastIndexOf(')'));
                   var disper="";
                    if(activeCell=="14")
                    {
                        if(srcElem.cells[14].childNodes[0]!="undefined" && srcElem.cells[14].childNodes[0]!=undefined && srcElem.cells[14].childNodes[0].value!=undefined)
                        disper=srcElem.cells[14].childNodes[0].value;
                        else
                        disper=srcElem.cells[14].childNodes[1].value;  
                    }
                    else{
                        disper=srcElem.cells[14].innerHTML;
                    }
                   var premium="";
                     if(activeCell=="15")
                    {
                        if(srcElem.cells[15].childNodes[0]!="undefined" && srcElem.cells[15].childNodes[0]!=undefined && srcElem.cells[15].childNodes[0].value!=undefined)
                        premium=srcElem.cells[15].childNodes[0].value;
                        else
                        premium=srcElem.cells[15].childNodes[1].value;  
                    }
                    else{
                        premium=srcElem.cells[15].innerHTML;
                    }
                    if(premium.indexOf("(")>0)
                        premium=premium.substring(premium.lastIndexOf('(')+1,premium.lastIndexOf(')'));
                   var cardprem_p="";
                     if(activeCell=="20")
                    {
                        if(srcElem.cells[20].childNodes[0]!="undefined" && srcElem.cells[20].childNodes[0]!=undefined && srcElem.cells[20].childNodes[0].value!=undefined)
                        cardprem_p=srcElem.cells[20].childNodes[0].value;
                        else
                        cardprem_p=srcElem.cells[20].childNodes[1].value;  
                    }
                    else{
                        cardprem_p=srcElem.cells[20].innerHTML;
                    }
                   var contprem_p="";
                    if(activeCell=="16")
                    {
                        if(srcElem.cells[16].childNodes[0]!="undefined" && srcElem.cells[16].childNodes[0]!=undefined && srcElem.cells[16].childNodes[0].value!=undefined)
                        contprem_p=srcElem.cells[16].childNodes[0].value;
                        else
                        contprem_p=srcElem.cells[16].childNodes[1].value;  
                    }
                    else{
                        contprem_p=srcElem.cells[16].innerHTML;
                    }
                   var minsize_p="";
                     if(activeCell=="21")
                    {
                        if(srcElem.cells[21].childNodes[0]!="undefined" && srcElem.cells[21].childNodes[0]!=undefined && srcElem.cells[21].childNodes[0].value!=undefined)
                        minsize_p=srcElem.cells[21].childNodes[0].value;
                        else
                        minsize_p=srcElem.cells[21].childNodes[1].value;  
                    }
                    else{
                        minsize_p=srcElem.cells[21].innerHTML;
                    }
                   var maxsize_p="";
                    if(activeCell=="22")
                    {
                        if(srcElem.cells[22].childNodes[0]!="undefined" && srcElem.cells[22].childNodes[0]!=undefined && srcElem.cells[22].childNodes[0].value!=undefined)
                        maxsize_p=srcElem.cells[22].childNodes[0].value;
                        else
                        maxsize_p=srcElem.cells[22].childNodes[1].value;  
                    }
                    else{
                        maxsize_p=srcElem.cells[22].innerHTML;
                    }
                   var progtype_p="";
                   if(activeCell=="25")
                    {
                        if(srcElem.cells[25].childNodes[0]!="undefined" && srcElem.cells[25].childNodes[0]!=undefined && srcElem.cells[25].childNodes[0].value!=undefined)
                        progtype_p=srcElem.cells[25].childNodes[0].value;
                        else
                        progtype_p=srcElem.cells[25].childNodes[1].value;  
                    }
                    else{
                        progtype_p=srcElem.cells[25].innerHTML;
                    }
                     if(progtype_p.indexOf("(")>0)
                        progtype_p=progtype_p.substring(progtype_p.lastIndexOf('(')+1,progtype_p.lastIndexOf(')'));
                   var progname_p="";
                    if(activeCell=="6")
                    {
                        if(srcElem.cells[6].childNodes[0]!="undefined" && srcElem.cells[6].childNodes[0]!=undefined && srcElem.cells[6].childNodes[0].value!=undefined)
                        progname_p=srcElem.cells[6].childNodes[0].value;
                        else
                        progname_p=srcElem.cells[6].childNodes[1].value;  
                    }
                    else{
                        progname_p=srcElem.cells[6].innerHTML;
                    }
                     if(progname_p.indexOf("(")>0)
                        progname_p=progname_p.substring(progname_p.lastIndexOf('(')+1,progname_p.lastIndexOf(')'));
                   var commallow_p="";
                    if(activeCell=="27")
                    {
                        if(srcElem.cells[27].childNodes[0]!="undefined" && srcElem.cells[27].childNodes[0]!=undefined && srcElem.cells[27].childNodes[0].value!=undefined)
                        commallow_p=srcElem.cells[27].childNodes[0].value;
                        else
                        commallow_p=srcElem.cells[27].childNodes[1].value;  
                    }
                    else{
                        commallow_p=srcElem.cells[27].innerHTML;
                    }
                    if(commallow_p.indexOf("(")>0)
                        commallow_p=commallow_p.substring(commallow_p.lastIndexOf('(')+1,commallow_p.lastIndexOf(')'));
                   var ratecode_p="";
                    if(activeCell=="29")
                    {
                        if(srcElem.cells[29].childNodes[0]!="undefined" && srcElem.cells[29].childNodes[0]!=undefined && srcElem.cells[29].childNodes[0].value!=undefined)
                        ratecode_p=srcElem.cells[29].childNodes[0].value;
                        else
                        ratecode_p=srcElem.cells[29].childNodes[1].value;  
                    }
                    else{
                        ratecode_p=srcElem.cells[29].innerHTML;
                    }
                    if(ratecode_p.indexOf("(")>0)
                        ratecode_p=ratecode_p.substring(ratecode_p.lastIndexOf('(')+1,ratecode_p.lastIndexOf(')'));
                   var source_p="";
                    if(activeCell=="33")
                    {
                        if(srcElem.cells[33].childNodes[0]!="undefined" && srcElem.cells[33].childNodes[0]!=undefined && srcElem.cells[33].childNodes[0].value!=undefined)
                        source_p=srcElem.cells[33].childNodes[0].value;
                        else
                        source_p=srcElem.cells[33].childNodes[1].value;  
                    }
                    else{
                        source_p=srcElem.cells[33].innerHTML;
                    }
                     if(source_p.indexOf("(")>0)
                        source_p=source_p.substring(source_p.lastIndexOf('(')+1,source_p.lastIndexOf(')'));
                   var dateformat=document.getElementById('hiddendateformat').value;
                   var contratcrate=srcElem.cells[17].innerHTML;
                   var agcode="";
                   if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
                        agcode=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
                   var subagencycode = document.getElementById('drpsubagcode').value     
                   var res=ContractMaster.getrateforcontract_Elec( compcode_p, unit_p, channel_p, location_p, adtype_p, ratetype, day_p,category_p, btb_p, fct_p, validfrom_p, validto_p,package_p, valufrom_p, valueto_p, disctype_p, disper, premium, cardprem_p,contprem_p, minsize_p, maxsize_p, progtype_p, progname_p, commallow_p, ratecode_p, source_p, dateformat,currency_p,contratcrate,agcode,subagencycode);
                   var ds=res.value;
                   if(ds==null)
                   {
                    alert(res.error.description);
                    return false;
                   }
                   document.getElementById('tblGridelec').rows[activeRow].cells[18].innerHTML="";
                   document.getElementById('tblGridelec').rows[activeRow].cells[34].innerHTML="";
                    document.getElementById('tblGridelec').rows[activeRow].cells[17].innerHTML="";
                   if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
                   {
                        if(ds.Tables[0].Rows[0].card_rate!=null)
                            document.getElementById('tblGridelec').rows[activeRow].cells[18].innerHTML=ds.Tables[0].Rows[0].card_rate;
                        if(ds.Tables[0].Rows[0].TOTALVAL!=null)   
                            document.getElementById('tblGridelec').rows[activeRow].cells[34].innerHTML=ds.Tables[0].Rows[0].TOTALVAL;
                            printTotal();
                   }
               }
                
                activeIDNo.focus();
                checkForEnter();
               }
               catch(err){}
               
                             
}
     else if((event.which== 13 || event.which== 9) && document.activeElement.id!="div_electronics" && document.activeElement.id!="divprint" && document.activeElement.id!="cmdAddRow" && document.activeElement.id!="cmdAddRowelec" && document.activeElement.id!="drpdealon" && document.activeElement.id!="btnExit" && document.activeElement.id!="btnDelete" && document.activeElement.id!="btnlast" && document.activeElement.id!="btnnext" && document.activeElement.id!="btnprevious" && document.activeElement.id!="btnCancel" && document.activeElement.id!="btnExecute" && document.activeElement.id!="btnQuery" && document.activeElement.id!="btnModify" && document.activeElement.id!="btnNew" && document.activeElement.id!="btnSave" && document.activeElement.id!="drpindustry" && document.activeElement.id!="lstproduct" && document.activeElement.id!="txtseq"  && document.activeElement.id!="chkpatricularad"  && document.activeElement.id!="chkseqno" && document.activeElement.id!="chkmultiad" && document.activeElement.id!="chkb2b" &&  document.activeElement.id!="txtremark" && document.activeElement.id!="drppaymenttype" && document.activeElement.id!="drpservicetax" && document.activeElement.id!="txtdealvol" && document.activeElement.id!="txtdealno" && document.activeElement.id!="txtdealvalue" && document.activeElement.id!="txtclosedate" && document.activeElement.id!="txtcontractdate" && document.activeElement.id!="lstretainer" && document.activeElement.id!="lstexec" && document.activeElement.id!="lstclient" && document.activeElement.id!="lstagency" && document.activeElement.id!="txtcaption" && document.activeElement.id!="txtfromdate" && document.activeElement.id!="TextBox1" && document.activeElement.id!="drpteamname" && document.activeElement.id!="drprepresentative" && document.activeElement.id!="txtexecutive" && document.activeElement.id!="txtretainer" && document.activeElement.id!="drpproduct" && document.activeElement.id!="drpclientname" && document.activeElement.id!="drpsubagcode" && document.activeElement.id!="drpagencycode" && document.activeElement.id!="drpcurr" &&  document.activeElement.id!="txtdealname" && document.activeElement.id!="drpdealtype"&& document.activeElement.id != "Listcontract" && document.activeElement.id != "txtrono" && document.activeElement.id != "txtrodate" && document.activeElement.id != "drprostatus" && document.activeElement.id != "drprptcurrency")
     {
        checkForEnter();
        return false;
     }
    
      if (event.which== 113 && document.activeElement.id!="txtseq" && document.activeElement.id!="cmdAddRowelec" && document.activeElement.id!="cmdAddRow" &&  document.activeElement.id!="txtremark" && document.activeElement.id!="drppaymenttype" && document.activeElement.id!="drpservicetax" && document.activeElement.id!="txtdealvol" && document.activeElement.id!="txtdealvalue" && document.activeElement.id!="txtclosedate" && document.activeElement.id!="txtcontractdate" && document.activeElement.id!="lstretainer" && document.activeElement.id!="lstexec" && document.activeElement.id!="lstclient" && document.activeElement.id!="lstagency" && document.activeElement.id!="txtcaption" && document.activeElement.id!="txtfromdate" && document.activeElement.id!="TextBox1" && document.activeElement.id!="drpteamname" && document.activeElement.id!="drprepresentative" && document.activeElement.id!="txtexecutive" && document.activeElement.id!="txtretainer" && document.activeElement.id!="drpproduct" && document.activeElement.id!="drpclientname" && document.activeElement.id!="drpsubagcode" && document.activeElement.id!="drpagencycode" && document.activeElement.id!="drpcurr" &&  document.activeElement.id!="txtdealname" && document.activeElement.id!="txtdealno" && document.activeElement.id!="drpdealtype")
     {
       
         var srcElem = getEventCell ();
         var cellindex=srcElem.cellIndex;
       colName=element.tHead.childNodes[0].childNodes[cellindex].childNodes[0].nextSibling.data;
       if (colName == "Source" || colName == "Adv Type" || colName == "Status" || colName == "Ad Type" || colName == "Hue" || colName == "Uom" || colName == "Rate Code" || colName == "Premium" || colName == "Day" || colName == "Days" || colName == "Comm. Allow" || colName == "Deal Start" || colName == "Package" || colName == "Category" || colName == "Disc Type" || colName == "Disc On" || colName == "Currency" || colName == "Channel" || colName == "Location" || colName == "Program Type" || colName == "Program Name" || colName == "BTB" || colName == "Time Band" || colName == "Paid/Bonus" || colName == "Rate Type" || colName == "Position Premium" || colName=="Section Code" || colName=="Resource No")
        { 
            activeIDNo=document.activeElement;
           // alert(document.activeElement.clientID);
          //   alert(document.activeElement);
            document.getElementById("divcommon").style.display="block";


            //  aTag = eval( document.getElementById(document.activeElement.uniqueID))
            //aTag = eval(document.all[document.activeElement.uniqueID])
              aTag = eval(document.activeElement);  
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                    if(document.getElementById('div_electronics').style.display!="none")
	                    {
	                         var tot=document.getElementById('div_electronics').scrollLeft;		
                            var scrolltop=document.getElementById('div_electronics').scrollTop;
                        } 
                        else{
                              var tot=document.getElementById('divprint').scrollLeft;		
                            var scrolltop=document.getElementById('divprint').scrollTop;
                        }   
//	                     document.getElementById('divcommon').style.top=(document.getElementById(document.activeElement.uniqueID).offsetTop + toppos - scrolltop) + "px";
                        //	                     document.getElementById('divcommon').style.left=(document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos - tot) + "px";
//                        document.getElementById('divcommon').style.top = (document.all[document.activeElement.uniqueID].offsetTop + toppos - scrolltop) + "px";
//                        document.getElementById('divcommon').style.left = (document.all[document.activeElement.uniqueID].offsetLeft + leftpos - tot) + "px";
                        document.getElementById('divcommon').style.top = (document.activeElement.offsetTop + toppos - scrolltop) + "px";
                        document.getElementById('divcommon').style.left = (document.activeElement.offsetLeft + leftpos - tot) + "px";
	                     bindListBox(colName);
	                     return false;
	    }                 
     }

     if (event.which==9) {
         if (document.activeElement.id == "lstros") {
             document.getElementById('txtros').value = document.getElementById('lstros').options[document.getElementById('lstros').selectedIndex].text + "(" + document.getElementById('lstros').value + ")";
             document.getElementById("divros").style.display = "none";
             document.getElementById('txtfromdate').focus();
             return false;
         }
         if (document.activeElement.id == "lstbtb") {
             document.getElementById('txtbtb').value = document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text + "(" + document.getElementById('lstbtb').value + ")";
             document.getElementById("divbtb").style.display = "none";
             document.getElementById('drpprogramtype').focus();
             return false;
         }
         if (document.activeElement.id == "lstcommon") {

             document.getElementById('txtprogramcode').value = document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text + "(" + document.getElementById('lstcommon').value + ")";
             document.getElementById("divcommon").style.display = "none";
             document.getElementById('txtros').focus();
             return false;
         }
         if (document.activeElement.id == "lstretainer") {
             if (document.getElementById('lstretainer').value == "0") {
                 alert("Please select the Retainer");
                 return false;
             }
             document.getElementById('txtretainer').value = document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text + "(" + document.getElementById('lstretainer').value + ")";
             document.getElementById("divretainer").style.display = "none";
             document.getElementById('drpteamname').focus();
             return false;
         }
         if (document.activeElement.id == "Listcontract") {
             if (document.getElementById('Listcontract').value == "0") {
                 alert("Please select contract");
                 return false;
             }
             document.getElementById('txtdealname').value = document.getElementById('Listcontract').value;
             document.getElementById("divcontract").style.display = "none";
             document.getElementById('drpagencycode').focus();
             return false;
         }
         if (document.activeElement.id == "lstexec") {
             if (document.getElementById('lstexec').value == "0")// || document.getElementById('hiddensavemod').value=="01")
             {
                 alert("Please select the Executive");
                 return false;
             }
             document.getElementById("divexec").style.display = "none";
             document.getElementById('txtexecutive').value = document.getElementById('lstexec').options[document.getElementById('lstexec').selectedIndex].text + "(" + document.getElementById('lstexec').value + ")";
             document.getElementById('txtretainer').focus();
             return false;
             //                var datetime=document.getElementById('txtdatetime').value;
             //            
             //                var page=document.getElementById('lstexec').value;
             //                   
             //                var id="";
             //                if(browser!="Microsoft Internet Explorer")
             //                {
             //                    var  httpRequest =null;;
             //                    httpRequest= new XMLHttpRequest();
             //                    if (httpRequest.overrideMimeType) {
             //                        httpRequest.overrideMimeType('text/xml'); 
             //                    }
             //                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

             //                    httpRequest.open( "GET","clientName.aspx?page="+page+"&value=3", false );
             //                    httpRequest.send('');
             //                    if (httpRequest.readyState == 4) 
             //                    {
             //                        if (httpRequest.status == 200) 
             //                        {
             //                            id=httpRequest.responseText;
             //                        }
             //                        else 
             //                        {
             //                            alert('There was a problem with the request.');
             //                        }
             //                    }
             //                }
             //                else
             //                {
             //                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
             //                    xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
             //                    xml.Send();
             //                    id=xml.responseText;
             //                }
             //            
             //                document.getElementById('txtexecutive').value=id;
         }
         if (document.activeElement.id == "lstagency") {
             if (document.getElementById('lstagency').value == "0")// || document.getElementById('hiddensavemod').value=="01")
             {
                 alert("Please select the agency code");
                 return false;
             }
             document.getElementById("div1").style.display = "none";
             var datetime = "";
             //alert(document.getElementById('lstagency').value);

             //alert(document.getElementById('lstagency').value);
             /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
             this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
             address and if 0 than agency name and address
             @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

             var page = document.getElementById('lstagency').value;
             // document.getElementById('hiddenagency').value=page;
             agencycodeglo = page;
             var value = "0";

             var res = ContractMaster.addclientname(page, datetime, value);
             var id = res.value;
             var split = id.split("+");
             var nameagen = split[0];
             var agenadd = split[1];
    var codbrk=nameagen.split("(");
                         document.getElementById('hdnagency').value=(codbrk[1].split(")"))[0];
             document.getElementById('drpagencycode').value = nameagen;
             agency_change();
             document.getElementById('drpagencycode').focus();
             return false;
         }
         else if (document.activeElement.id == "lstclient") {
             if (document.getElementById('lstclient').value == "0") {
                 alert("Please select the client");
                 return false;
             }
             document.getElementById("divclient").style.display = "none";
             var datetime = "";
             //alert(document.getElementById('lstagency').value);
             /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
             this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
             address and if 0 than agency name and address
             @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/

             var page = document.getElementById('lstclient').value;


             var id = "";
             if (browser != "Microsoft Internet Explorer") {
                 var httpRequest = null; ;
                 httpRequest = new XMLHttpRequest();
                 if (httpRequest.overrideMimeType) {
                     httpRequest.overrideMimeType('text/xml');
                 }

                 httpRequest.onreadystatechange = function() { alertContents(httpRequest) };

                 httpRequest.open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
                 httpRequest.send('');
                 //alert(httpRequest.readyState);
                 if (httpRequest.readyState == 4) {
                     //alert(httpRequest.status);
                     if (httpRequest.status == 200) {
                         id = httpRequest.responseText;
                     }
                     else {
                         alert('There was a problem with the request.');
                     }
                 }
             }
             else {
                 var xml = new ActiveXObject("Microsoft.XMLHTTP");
                 xml.Open("GET", "clientName.aspx?page=" + page + "&datetime=" + datetime + "&value=1", false);
                 xml.Send();
                 id = xml.responseText;
             }
             if (id == "yes") {
                 alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                 return false;
             }
             var split = id.split("+");
             var namecode = split[0];
             var add = split[1];


             document.getElementById('drpclientname').value = namecode;

          //   clientChange();
             /* if(document.getElementById('hiddensavemod').value=="0")
             {
             document.getElementById('txtclientadd').value=add;        
             document.getElementById('txtclientadd').focus();
             }
             bind_agen_bill();*/
             document.getElementById('drpclientname').focus();

             return false;
         }
         if (document.activeElement.id == id) {
             if (document.getElementById('btnSave').disabled == false) {
                 document.getElementById('btnSave').focus();
             }
             return;

         }
         else if (document.activeElement.type == "button" || document.activeElement.type == "submit" || document.activeElement.type == "image") {
             event.keyCode = 13;
             return event.keyCode;

         }
         else {
             //alert(event.keyCode);
             try {
                 if (document.activeElement.id == "drpagencycode") {
                     document.getElementById('drpsubagcode').focus();
                     return false;
                 }
                 event.keyCode = 9;
                 //alert(event.keyCode);
                 return event.keyCode;
             }
             catch (err)
            { }
         }
     }
 }
 else{
if(window.event.ctrlKey==true && event.keyCode=="68")
{
     if(colName!="undefined" && colName!=undefined && (colName=="Channel" || colName=="Ad Type") && mode=="new")
    {
         var srcElm=getEventRow();
          if(confirm('Are you sure you want to delete Row?')==false)
             return false;
          else{
              
              activeRow=srcElm.rowIndex;
              deleteRow(activeRow-1);
              return false;
          }   
    }
}

if (window.event.ctrlKey == true && event.keyCode == "67") {
    if (colName != "undefined" && colName != undefined && (colName == "Channel" || colName == "Ad Type") && mode == "new") {
        var srcElm = getEventRow();
        if (confirm('Are you sure you want to copy Row?') == false)
            return false;
        else {
            if (document.getElementById('div_electronics').style.display == "none") {
                addRow('', '', '', '', '', '', '0', '0', '0', '0', '0', '', '0', '', '', '', '', '', '', '', 'Yes(Y)', '', document.getElementById('hiddencurrency').value, '', '', '', '', '', '','','','','','','');
            }
            else {
                addRow('', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', document.getElementById('hiddencurrency').value, '', '', '', 'Yes(Y)', '', '', '', '', '', '', '', '', '', '', '', '','','','','');
            }
            activeRow = srcElm.rowIndex;
            copyrow(activeRow);
            return false;
        }
    }
}
if((event.keyCode==13 || event.keyCode==9) && document.activeElement.id=="txtdealname")
{
    document.getElementById('drpagencycode').focus();
    return false;
}
if(event.keyCode==117)
{
    if (colName != "undefined" && colName != undefined && colName == "Channel") {
        var srcElm = getEventRow();
        activeRow = srcElm.rowIndex;
        var Return;
        var agcode = "";
        if (document.getElementById('drpagencycode').value != "" && document.getElementById('drpagencycode').value.indexOf("(") >= 0 && document.getElementById('drpagencycode').value.indexOf(")") >= 0)
            agcode = document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(') + 1, document.getElementById('drpagencycode').value.lastIndexOf(')'));
        var subagencycode = document.getElementById('drpsubagcode').value;
        var seqno = document.getElementById('tblGridelec').rows[activeRow].cells[41].innerHTML;
        if (seqno.indexOf("<INPUT") >= 0)
            seqno = "";
        var consumed = document.getElementById('tblGridelec').rows[activeRow].cells[37].innerHTML;
        var balance = document.getElementById('tblGridelec').rows[activeRow].cells[38].innerHTML
         saveInSession(activeRow-1);
        Return = window.showModalDialog("contractChild.aspx?contdate=" + document.getElementById('txtcontractdate').value + "&rcptcurr=" + document.getElementById('drprptcurrency').value + "&balance=" + balance + "&consumed=" + consumed + "&seqno=" + seqno + "&dealno=" + document.getElementById('txtdealno').value + "&validto=" + document.getElementById('TextBox1').value + "&validfrom=" + document.getElementById('txtfromdate').value + "&agsubcode=" + subagencycode + "&agcode=" + agcode + "&mode=" + mode, "window.self", "dialogWidth:1090px; dialogHeight:350px;resizable: yes");
        //  document.getElementById('txtremark').value = Return.remarks;
        //alert(Return);
       
        if (Return != null) {
            binddatainGrid(Return);
            
        }
        return false;
    }
    else if (colName != "undefined" && colName != undefined && colName == "Ad Type") {

    var srcElm = getEventRow();
    activeRow = srcElm.rowIndex;
    saveInSessionPrint(activeRow-1);
 //   Return = window.showModalDialog("contractchildprint.aspx?contdate=" + document.getElementById('txtcontractdate').value + "&dealno=" + document.getElementById('txtdealno').value + "&validto=" + document.getElementById('TextBox1').value + "&validfrom=" + document.getElementById('txtfromdate').value + "&mode=" + mode+"&agencycod=" + document.getElementById('hdnagency').value+"&clientcod=" + document.getElementById('hdnclientcod').value, "", "dialogWidth:1100px; dialogHeight:350px;resizable: yes");
   Return = window.showModalDialog("contractchildprint.aspx?contdate=" + document.getElementById('txtcontractdate').value + "&dealno=" + document.getElementById('txtdealno').value + "&validto=" + document.getElementById('TextBox1').value+"&agnsubcod=" + document.getElementById('drpsubagcode').value + "&validfrom=" + document.getElementById('txtfromdate').value + "&mode=" + mode+"&agencycod=" + document.getElementById('hdnagency').value+"&clientcod=" + document.getElementById('hdnclientcod').value, "", "dialogWidth:1100px; dialogHeight:350px;resizable: yes");


   
    //  document.getElementById('txtremark').value = Return.remarks;
    //alert(Return);
    if (Return != null) {
        binddatainGridprint(Return);
    }
    return false;
    }
}
if (colName == "Total Value" || colName == "Card Prem" || colName == "Contract Prem." || colName == "Contract Rate" || colName == "Card Rate" || colName == "Deviation" || colName == "Disc. Per." || colName == "Min Size" || colName == "Max Size" || colName == "Value From" || colName == "Value To" || colName == "Insertion" || colName == "Total Rate" || colName == "Incentive" || colName == "FCT/NOI/Words" || colName == "Consumed" || colName == "Balance" || colName == "Contract Amount")
{
try{
  var srcElm1=getEventCell();
    activeCell=srcElm1.cellIndex;
    }
    catch(err){}
   var res=notchar2();
   if(res==false)
    return false;
}
if (event.keyCode != 13 && event.keyCode != 9 && event.keyCode != 27 && event.keyCode != 113 && event.keyCode != 8 && event.keyCode != 40 && event.keyCode != 38 && event.keyCode != 16 && event.type != "click")
{
    if (colName == "Source" || colName == "Ad Type" || colName == "Hue" || colName == "Uom" || colName == "Package" || colName == "Category" || colName == "Premium" || colName == "Disc Type" || colName == "Disc On" || colName == "Day" || colName == "Days" || colName == "Comm. Allow" || colName == "Deal Start" || colName == "Currency" || colName == "Rate Code" || colName == "Status" || colName == "Channel" || colName == "Location" || colName == "Adv Type" || colName == "Paid/Bonus" || colName == "Rate Type" || colName == "Program Name" || colName == "BTB" || colName == "Time Band" || colName == "Program Type" || colName == "Position Premium" || colName=="Section Code" || colName=="Resource No") {

        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode >= 96 && event.keyCode <= 105) || event.keyCode == 110 || event.keyCode == 37 || event.keyCode == 39 || event.keyCode == 34 || event.keyCode == 46) {
            return true;
        }
        else {
            event.keyCode = 0;
            return false;
        }
    }
}
if (event.keyCode != 13 && event.keyCode != 9 && event.keyCode != 27 && event.keyCode != 113 && event.keyCode != 8 && event.keyCode != 40 && event.keyCode != 38 && event.keyCode != 16 && event.type != "click") {
    if (colName == "Deviation" || colName == "Disc. Per." || colName == "Min Size" || colName == "Max Size" || colName == "Value From" || colName == "Value To" || colName == "Insertion" || colName == "Total Rate" || colName == "Contract Amount") {

        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode >= 37 && event.keyCode <= 40) || event.keyCode == 110) {
            return true;
        }
        else {
            event.keyCode = 0;
            return false;
        }
    }
}
if((event.keyCode == 13 || event.keyCode == 9) && document.activeElement.id!="lstcommon" && document.getElementById('divprint').style.display=="none")
{
 activeIDNo=document.activeElement;
 var srcElm=getEventRow();
 if(activeRow=="")
 activeRow=srcElm.rowIndex;
     if(colName=="Contract Rate" || colName=="Card Rate")
           {
                if(activeRow!="")
               {
                   var srcElem=document.getElementById('tblGridelec').rows[activeRow];
                   var srcElm1=getEventCell();
                   activeCell=srcElm1.cellIndex;
                   var cardrate="";
                   var contractrate="";
                   if(activeCell=="18")
                    {
                        if(srcElem.cells[18].childNodes[0]!="undefined" && srcElem.cells[18].childNodes[0]!=undefined && srcElem.cells[18].childNodes[0].value!=undefined)
                        cardrate=srcElem.cells[18].childNodes[0].value;
                        else
                        cardrate=srcElem.cells[18].childNodes[1].value;  
                    }
                    else{
                        cardrate=srcElem.cells[18].innerHTML;
                    }
                   
                  if(activeCell=="17")
                    {
                        if(srcElem.cells[17].childNodes[0]!="undefined" && srcElem.cells[17].childNodes[0]!=undefined && srcElem.cells[17].childNodes[0].value!=undefined)
                        contractrate=srcElem.cells[17].childNodes[0].value;
                        else
                        contractrate=srcElem.cells[17].childNodes[1].value;  
                    }
                    else{
                        contractrate=srcElem.cells[17].innerHTML;
                    }  
                    if(contractrate!="" && cardrate!="")
                    {
                        var dev=parseFloat(cardrate) - parseFloat(contractrate);
                        document.getElementById('tblGridelec').rows[activeRow].cells[19].innerHTML=dev;
                    }
               }    
          //  return false;
           }
}
else if((event.keyCode == 13 || event.keyCode == 9) && document.activeElement.id!="lstcommon" && document.getElementById('div_electronics').style.display=="none")
{
 activeIDNo=document.activeElement;
     if(colName=="Contract Rate" || colName=="Card Rate")
           {
                if(activeRow!="")
               {
                   var srcElem=document.getElementById('tblGrid').rows[activeRow];
                   var srcElm1=getEventCell();
                   activeCell=srcElm1.cellIndex;
                   var cardrate="";
                   var contractrate="";
                   if(activeCell=="9")
                    {
                        if(srcElem.cells[9].childNodes[0]!="undefined" && srcElem.cells[9].childNodes[0]!=undefined && srcElem.cells[9].childNodes[0].value!=undefined)
                        cardrate=srcElem.cells[9].childNodes[0].value;
                        else
                        cardrate=srcElem.cells[9].childNodes[1].value;  
                    }
                    else{
                        cardrate=srcElem.cells[9].innerHTML;
                    }
                   
                  if(activeCell=="8")
                    {
                        if(srcElem.cells[8].childNodes[0]!="undefined" && srcElem.cells[8].childNodes[0]!=undefined && srcElem.cells[8].childNodes[0].value!=undefined)
                        contractrate=srcElem.cells[8].childNodes[0].value;
                        else
                        contractrate=srcElem.cells[8].childNodes[1].value;  
                    }
                    else{
                        contractrate=srcElem.cells[8].innerHTML;
                    }  
                    if(contractrate!="" && cardrate!="")
                    {
                        var dev=parseFloat(cardrate) - parseFloat(contractrate);
                        document.getElementById('tblGrid').rows[activeRow].cells[10].innerHTML=dev;
                    }
               }    
          //  return false;
           }
       }
       if ((event.keyCode == 13 || event.type == "click") && document.activeElement.id == "lstcommon")
     {
        document.getElementById("divcommon").style.display="none";
        if(activeIDNo!=null)
        {
          // document.getElementById(activeIDNo).value=document.getElementById("lstcommon").value;
          if(document.getElementById("lstcommon").selectedIndex!=-1)
            activeIDNo.value=document.getElementById("lstcommon").options[document.getElementById("lstcommon").selectedIndex].text + "("+document.getElementById("lstcommon").value+")";
           if(document.getElementById('divprint').style.display=="none" && (colName=="Channel" || colName=="Location" || colName=="Adv Type" || colName=="Rate Type" || colName=="Day" || colName=="Category"  || colName=="BTB" || colName=="FCT/NOI/Words" || colName=="Package" || colName=="Value From" || colName=="Value To" || colName=="Disc Type" || colName=="Disc. Per." || colName=="Premium" || colName=="Card Prem" || colName=="Contract Prem." || colName=="Min Size" || colName=="Max Size" || colName=="Program Type" || colName=="Program Name"  || colName=="Comm. Allow" || colName=="Rate Code" || colName=="Source"))
          
          // if(colName=="Rate Code" || colName=="Adv Type" || colName=="Rate Type" || colName=="Category" || colName=="BTB" || colName=="FCT/NOI/Words" || colName=="Package" || colName=="Source" || colName=="Currency")
           {
                if(activeRow!="")
               {
                   var srcElem=document.getElementById('tblGridelec').rows[activeRow];
//                   string compcode_p, string unit_p, string channel_p, string location_p, string adtype_p, string ratetype, string day_p, 
//                   string category_p, string btb_p, string fct_p, string validfrom_p, string validto_p, 
//                   string package_p, string valufrom_p, string valueto_p, string disctype_p, string disper, string premium, string cardprem_p, 
//                   string contprem_p, string minsize_p, string maxsize_p, string progtype_p, string progname_p, string commallow_p, string ratecode_p, string source_p, string dateformat)
                   var compcode_p=document.getElementById('hiddencompcode').value;
                   var unit_p=document.getElementById('hiddencenter').value;
                   var currency_p="";
                    if(activeCell=="23")
                    {
                        if(srcElem.cells[23].childNodes[0]!="undefined" && srcElem.cells[23].childNodes[0]!=undefined && srcElem.cells[23].childNodes[0].value!=undefined)
                        currency_p=srcElem.cells[23].childNodes[0].value;
                        else
                        currency_p=srcElem.cells[23].childNodes[1].value;  
                    }
                    else{
                        currency_p=srcElem.cells[23].innerHTML;
                    }
                   if(currency_p.indexOf("(")>0)
                        currency_p=currency_p.substring(currency_p.lastIndexOf('(')+1,currency_p.lastIndexOf(')'));
                        
                   var channel_p="";
                    if(activeCell=="0")
                    {
                        if(srcElem.cells[0].childNodes[0]!="undefined" && srcElem.cells[0].childNodes[0]!=undefined && srcElem.cells[0].childNodes[0].value!=undefined)
                        channel_p=srcElem.cells[0].childNodes[0].value;
                        else
                        channel_p=srcElem.cells[0].childNodes[1].value;  
                    }
                    else{
                        channel_p=srcElem.cells[0].innerHTML;
                    }
                   if(channel_p.indexOf("(")>0)
                        channel_p=channel_p.substring(channel_p.lastIndexOf('(')+1,channel_p.lastIndexOf(')'));
                   var location_p="";
                   if(activeCell=="1")
                    {
                        if(srcElem.cells[1].childNodes[0]!="undefined" && srcElem.cells[1].childNodes[0]!=undefined && srcElem.cells[1].childNodes[0].value!=undefined)
                        location_p=srcElem.cells[1].childNodes[0].value;
                        else
                        location_p=srcElem.cells[1].childNodes[1].value;  
                    }
                    else{
                        location_p=srcElem.cells[1].innerHTML;
                    }
                    if(location_p.indexOf("(")>0)
                        location_p=location_p.substring(location_p.lastIndexOf('(')+1,location_p.lastIndexOf(')'));
                   var adtype_p="";
                   if(activeCell=="2")
                    {
                        if(srcElem.cells[2].childNodes[0]!="undefined" && srcElem.cells[2].childNodes[0]!=undefined && srcElem.cells[2].childNodes[0].value!=undefined)
                        adtype_p=srcElem.cells[2].childNodes[0].value;
                        else
                        adtype_p=srcElem.cells[2].childNodes[1].value;  
                    }
                    else{
                        adtype_p=srcElem.cells[2].innerHTML;
                    }
                    if(adtype_p.indexOf("(")>0)
                        adtype_p=adtype_p.substring(adtype_p.lastIndexOf('(')+1,adtype_p.lastIndexOf(')'));
                   var ratetype="";
                    if(activeCell=="4")
                    {
                        if(srcElem.cells[4].childNodes[0]!="undefined" && srcElem.cells[4].childNodes[0]!=undefined && srcElem.cells[4].childNodes[0].value!=undefined)
                        ratetype=srcElem.cells[4].childNodes[0].value;
                        else
                        {
                        try{
                        ratetype=srcElem.cells[4].childNodes[1].value;  
                        }
                        catch(err){
                         ratetype=srcElem.cells[4].innerHTML;
                        }
                        }
                    }
                    else{
                        ratetype=srcElem.cells[4].innerHTML;
                    }
                    if(ratetype.indexOf("(")>0)
                        ratetype=ratetype.substring(ratetype.lastIndexOf('(')+1,ratetype.lastIndexOf(')'));
                   var day_p="";
                    if(activeCell=="8")
                    {
                        if(srcElem.cells[8].childNodes[0]!="undefined" && srcElem.cells[8].childNodes[0]!=undefined && srcElem.cells[8].childNodes[0].value!=undefined)
                        day_p=srcElem.cells[8].childNodes[0].value;
                        else
                        day_p=srcElem.cells[8].childNodes[1].value;  
                    }
                    else{
                        day_p=srcElem.cells[8].innerHTML;
                    }
                   var category_p="";
                    if(activeCell=="26")
                    {
                        if(srcElem.cells[26].childNodes[0]!="undefined" && srcElem.cells[26].childNodes[0]!=undefined && srcElem.cells[26].childNodes[0].value!=undefined)
                        category_p=srcElem.cells[26].childNodes[0].value;
                        else
                        category_p=srcElem.cells[26].childNodes[1].value;  
                    }
                    else{
                        category_p=srcElem.cells[26].innerHTML;
                    }
                    if(category_p.indexOf("(")>0)
                        category_p=category_p.substring(category_p.lastIndexOf('(')+1,category_p.lastIndexOf(')'));
                   var btb_p="";
                    if(activeCell=="5")
                    {
                        if(srcElem.cells[5].childNodes[0]!="undefined" && srcElem.cells[5].childNodes[0]!=undefined && srcElem.cells[5].childNodes[0].value!=undefined)
                        btb_p=srcElem.cells[5].childNodes[0].value;
                        else
                        btb_p=srcElem.cells[5].childNodes[1].value;  
                    }
                    else{
                        btb_p=srcElem.cells[5].innerHTML;
                    }
                    if(btb_p.indexOf("(")>0)
                        btb_p=btb_p.substring(btb_p.lastIndexOf('(')+1,btb_p.lastIndexOf(')'));
                   var fct_p="";
                    if(activeCell=="9")
                    {
                        if(srcElem.cells[9].childNodes[0]!="undefined" && srcElem.cells[9].childNodes[0]!=undefined && srcElem.cells[9].childNodes[0].value!=undefined)
                        fct_p=srcElem.cells[9].childNodes[0].value;
                        else
                        fct_p=srcElem.cells[9].childNodes[1].value;  
                    }
                    else{
                        fct_p=srcElem.cells[9].innerHTML;
                    }
                    if(fct_p.indexOf("(")>0)
                        fct_p=fct_p.substring(fct_p.lastIndexOf('(')+1,fct_p.lastIndexOf(')'));
                   var validfrom_p=document.getElementById('txtfromdate').value;
                   var validto_p=document.getElementById('TextBox1').value;
                   var package_p="";
                   if(activeCell=="10")
                    {
                        if(srcElem.cells[10].childNodes[0]!="undefined" && srcElem.cells[10].childNodes[0]!=undefined && srcElem.cells[10].childNodes[0].value!=undefined)
                        package_p=srcElem.cells[10].childNodes[0].value;
                        else
                        package_p=srcElem.cells[10].childNodes[1].value;  
                    }
                    else{
                        package_p=srcElem.cells[10].innerHTML;
                    }
                    if(package_p.indexOf("(")>0)
                        package_p=package_p.substring(package_p.lastIndexOf('(')+1,package_p.lastIndexOf(')'));
                   var valufrom_p="";
                     if(activeCell=="11")
                    {
                        if(srcElem.cells[11].childNodes[0]!="undefined" && srcElem.cells[11].childNodes[0]!=undefined && srcElem.cells[11].childNodes[0].value!=undefined)
                        valufrom_p=srcElem.cells[11].childNodes[0].value;
                        else
                        valufrom_p=srcElem.cells[11].childNodes[1].value;  
                    }
                    else{
                        valufrom_p=srcElem.cells[11].innerHTML;
                    }
                   var valueto_p="";
                     if(activeCell=="12")
                    {
                        if(srcElem.cells[12].childNodes[0]!="undefined" && srcElem.cells[12].childNodes[0]!=undefined && srcElem.cells[12].childNodes[0].value!=undefined)
                        valueto_p=srcElem.cells[12].childNodes[0].value;
                        else
                        valueto_p=srcElem.cells[12].childNodes[1].value;  
                    }
                    else{
                        valueto_p=srcElem.cells[12].innerHTML;
                    }
                   var disctype_p="";
                     if(activeCell=="13")
                    {
                        if(srcElem.cells[13].childNodes[0]!="undefined" && srcElem.cells[13].childNodes[0]!=undefined && srcElem.cells[13].childNodes[0].value!=undefined)
                        disctype_p=srcElem.cells[13].childNodes[0].value;
                        else
                        disctype_p=srcElem.cells[13].childNodes[1].value;  
                    }
                    else{
                        disctype_p=srcElem.cells[13].innerHTML;
                    }
                    if(disctype_p.indexOf("(")>0)
                        disctype_p=disctype_p.substring(disctype_p.lastIndexOf('(')+1,disctype_p.lastIndexOf(')'));
                   var disper="";
                    if(activeCell=="14")
                    {
                        if(srcElem.cells[14].childNodes[0]!="undefined" && srcElem.cells[14].childNodes[0]!=undefined && srcElem.cells[14].childNodes[0].value!=undefined)
                        disper=srcElem.cells[14].childNodes[0].value;
                        else
                        disper=srcElem.cells[14].childNodes[1].value;  
                    }
                    else{
                        disper=srcElem.cells[14].innerHTML;
                    }
                   var premium="";
                     if(activeCell=="15")
                    {
                        if(srcElem.cells[15].childNodes[0]!="undefined" && srcElem.cells[15].childNodes[0]!=undefined && srcElem.cells[15].childNodes[0].value!=undefined)
                        premium=srcElem.cells[15].childNodes[0].value;
                        else
                        premium=srcElem.cells[15].childNodes[1].value;  
                    }
                    else{
                        premium=srcElem.cells[15].innerHTML;
                    }
                    if(premium.indexOf("(")>0)
                        premium=premium.substring(premium.lastIndexOf('(')+1,premium.lastIndexOf(')'));
                   var cardprem_p="";
                     if(activeCell=="20")
                    {
                        if(srcElem.cells[20].childNodes[0]!="undefined" && srcElem.cells[20].childNodes[0]!=undefined && srcElem.cells[20].childNodes[0].value!=undefined)
                        cardprem_p=srcElem.cells[20].childNodes[0].value;
                        else
                        cardprem_p=srcElem.cells[20].childNodes[1].value;  
                    }
                    else{
                        cardprem_p=srcElem.cells[20].innerHTML;
                    }
                   var contprem_p="";
                    if(activeCell=="16")
                    {
                        if(srcElem.cells[16].childNodes[0]!="undefined" && srcElem.cells[16].childNodes[0]!=undefined && srcElem.cells[16].childNodes[0].value!=undefined)
                        contprem_p=srcElem.cells[16].childNodes[0].value;
                        else
                        contprem_p=srcElem.cells[16].childNodes[1].value;  
                    }
                    else{
                        contprem_p=srcElem.cells[16].innerHTML;
                    }
                   var minsize_p="";
                     if(activeCell=="21")
                    {
                        if(srcElem.cells[21].childNodes[0]!="undefined" && srcElem.cells[21].childNodes[0]!=undefined && srcElem.cells[21].childNodes[0].value!=undefined)
                        minsize_p=srcElem.cells[21].childNodes[0].value;
                        else
                        minsize_p=srcElem.cells[21].childNodes[1].value;  
                    }
                    else{
                        minsize_p=srcElem.cells[21].innerHTML;
                    }
                   var maxsize_p="";
                    if(activeCell=="22")
                    {
                        if(srcElem.cells[22].childNodes[0]!="undefined" && srcElem.cells[22].childNodes[0]!=undefined && srcElem.cells[22].childNodes[0].value!=undefined)
                        maxsize_p=srcElem.cells[22].childNodes[0].value;
                        else
                        maxsize_p=srcElem.cells[22].childNodes[1].value;  
                    }
                    else{
                        maxsize_p=srcElem.cells[22].innerHTML;
                    }
                   var progtype_p="";
                   if(activeCell=="25")
                    {
                        if(srcElem.cells[25].childNodes[0]!="undefined" && srcElem.cells[25].childNodes[0]!=undefined && srcElem.cells[25].childNodes[0].value!=undefined)
                        progtype_p=srcElem.cells[25].childNodes[0].value;
                        else
                        progtype_p=srcElem.cells[25].childNodes[1].value;  
                    }
                    else{
                        progtype_p=srcElem.cells[25].innerHTML;
                    }
                     if(progtype_p.indexOf("(")>0)
                        progtype_p=progtype_p.substring(progtype_p.lastIndexOf('(')+1,progtype_p.lastIndexOf(')'));
                   var progname_p="";
                    if(activeCell=="6")
                    {
                        if(srcElem.cells[6].childNodes[0]!="undefined" && srcElem.cells[6].childNodes[0]!=undefined && srcElem.cells[6].childNodes[0].value!=undefined)
                        progname_p=srcElem.cells[6].childNodes[0].value;
                        else
                        progname_p=srcElem.cells[6].childNodes[1].value;  
                    }
                    else{
                        progname_p=srcElem.cells[6].innerHTML;
                    }
                     if(progname_p.indexOf("(")>0)
                        progname_p=progname_p.substring(progname_p.lastIndexOf('(')+1,progname_p.lastIndexOf(')'));
                   var commallow_p="";
                    if(activeCell=="27")
                    {
                        if(srcElem.cells[27].childNodes[0]!="undefined" && srcElem.cells[27].childNodes[0]!=undefined && srcElem.cells[27].childNodes[0].value!=undefined)
                        commallow_p=srcElem.cells[27].childNodes[0].value;
                        else
                        commallow_p=srcElem.cells[27].childNodes[1].value;  
                    }
                    else{
                        commallow_p=srcElem.cells[27].innerHTML;
                    }
                    if(commallow_p.indexOf("(")>0)
                        commallow_p=commallow_p.substring(commallow_p.lastIndexOf('(')+1,commallow_p.lastIndexOf(')'));
                   var ratecode_p="";
                    if(activeCell=="29")
                    {
                        if(srcElem.cells[29].childNodes[0]!="undefined" && srcElem.cells[29].childNodes[0]!=undefined && srcElem.cells[29].childNodes[0].value!=undefined)
                        ratecode_p=srcElem.cells[29].childNodes[0].value;
                        else
                        ratecode_p=srcElem.cells[29].childNodes[1].value;  
                    }
                    else{
                        ratecode_p=srcElem.cells[29].innerHTML;
                    }
                    if(ratecode_p.indexOf("(")>0)
                        ratecode_p=ratecode_p.substring(ratecode_p.lastIndexOf('(')+1,ratecode_p.lastIndexOf(')'));
                   var source_p="";
                    if(activeCell=="33")
                    {
                        if(srcElem.cells[33].childNodes[0]!="undefined" && srcElem.cells[33].childNodes[0]!=undefined && srcElem.cells[33].childNodes[0].value!=undefined)
                        source_p=srcElem.cells[33].childNodes[0].value;
                        else
                        source_p=srcElem.cells[33].childNodes[1].value;  
                    }
                    else{
                        source_p=srcElem.cells[33].innerHTML;
                    }
                     if(source_p.indexOf("(")>0)
                        source_p=source_p.substring(source_p.lastIndexOf('(')+1,source_p.lastIndexOf(')'));
                   var dateformat=document.getElementById('hiddendateformat').value;
                   var contratcrate=srcElem.cells[17].innerHTML;
                   var agcode="";
                   if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
                        agcode=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
                   var subagencycode = document.getElementById('drpsubagcode').value     
                   var res=ContractMaster.getrateforcontract_Elec( compcode_p, unit_p, channel_p, location_p, adtype_p, ratetype, day_p,category_p, btb_p, fct_p, validfrom_p, validto_p,package_p, valufrom_p, valueto_p, disctype_p, disper, premium, cardprem_p,contprem_p, minsize_p, maxsize_p, progtype_p, progname_p, commallow_p, ratecode_p, source_p, dateformat,currency_p,contratcrate,agcode,subagencycode);
                   var ds=res.value;
                   if(ds==null)
                   {
                    alert(res.error.description);
                    return false;
                   }
                   document.getElementById('tblGridelec').rows[activeRow].cells[18].innerHTML="";
                   document.getElementById('tblGridelec').rows[activeRow].cells[34].innerHTML="";
                    document.getElementById('tblGridelec').rows[activeRow].cells[17].innerHTML="";
                   if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
                   {
                        if(ds.Tables[0].Rows[0].card_rate!=null)
                            document.getElementById('tblGridelec').rows[activeRow].cells[18].innerHTML=ds.Tables[0].Rows[0].card_rate;
                        if(ds.Tables[0].Rows[0].TOTALVAL!=null)   
                            document.getElementById('tblGridelec').rows[activeRow].cells[34].innerHTML=ds.Tables[0].Rows[0].TOTALVAL;
                            printTotal();
                   }
               }
           }
           else if(document.getElementById('div_electronics').style.display=="none" && (colName=="Ad Type" || colName=="Category" || colName=="Package" || colName=="Hue" || colName=="Uom" || colName=="Currency" || colName=="Rate Code") )
           {
           if(activeRow!="")
           {
           var srcElem=document.getElementById('tblGrid').rows[activeRow];
           var adcat="";
           var pkgcode=""; 
           var color="";
           var currency="";
           var uom="";
           var advtype="";
            var ratecode="";
           if(activeCell=="4")
           {
               if(srcElem.cells[4].childNodes[0]!="undefined" && srcElem.cells[4].childNodes[0]!=undefined && srcElem.cells[4].childNodes[0].value!=undefined)
                 adcat=srcElem.cells[4].childNodes[0].value;
               else
                 adcat=srcElem.cells[4].childNodes[1].value;  
           }
           else{
             adcat=srcElem.cells[4].innerHTML;
           }
           if(activeCell=="3")
           {
            if(srcElem.cells[3].childNodes[0]!="undefined" && srcElem.cells[3].childNodes[0]!=undefined && srcElem.cells[3].childNodes[0].value!=undefined)
                pkgcode=srcElem.cells[3].childNodes[0].value;
             else
                 pkgcode=srcElem.cells[3].childNodes[1].value; 
           }
           else{
             pkgcode=srcElem.cells[3].innerHTML;
           }
            if(activeCell=="1")
           {
            if(srcElem.cells[1].childNodes[0]!="undefined" && srcElem.cells[1].childNodes[0]!=undefined && srcElem.cells[1].childNodes[0].value!=undefined)
                color=srcElem.cells[1].childNodes[0].value;
            else
                color=srcElem.cells[1].childNodes[1].value;    
           }
           else{
             color=srcElem.cells[1].innerHTML;
           }
            if(activeCell=="22")
           {
            if(srcElem.cells[22].childNodes[0]!="undefined" && srcElem.cells[22].childNodes[0]!=undefined && srcElem.cells[22].childNodes[0].value!=undefined)
                currency=srcElem.cells[22].childNodes[0].value;
            else
                currency=srcElem.cells[22].childNodes[1].value;    
           }
           else{
             currency=srcElem.cells[22].innerHTML;
           }
            if(activeCell=="2")
           {
            if(srcElem.cells[2].childNodes[0]!="undefined" && srcElem.cells[2].childNodes[0]!=undefined && srcElem.cells[2].childNodes[0].value!=undefined)
                uom=srcElem.cells[2].childNodes[0].value;
            else
                uom=srcElem.cells[2].childNodes[1].value;    
           }
           else{
             uom=srcElem.cells[2].innerHTML;
           }
            if(activeCell=="0")
           {
            if(srcElem.cells[0].childNodes[0]!="undefined" && srcElem.cells[0].childNodes[0]!=undefined && srcElem.cells[0].childNodes[0].value!=undefined)
                advtype=srcElem.cells[0].childNodes[0].value;
            else
                advtype=srcElem.cells[0].childNodes[1].value;    
           }
           else{
             advtype=srcElem.cells[0].innerHTML;
           }
           
            if(activeCell=="23")
           {
            if(srcElem.cells[23].childNodes[0]!="undefined" && srcElem.cells[23].childNodes[0]!=undefined && srcElem.cells[23].childNodes[0].value!=undefined)
                ratecode=srcElem.cells[23].childNodes[0].value;
            else
                ratecode=srcElem.cells[23].childNodes[1].value;    
           }
           else{
             ratecode=srcElem.cells[23].innerHTML;
           }
            getCardRate(adcat,pkgcode,color,currency,uom,advtype,document.getElementById('txtfromdate').value,document.getElementById('TextBox1').value,document.getElementById('hiddencompcode').value,document.getElementById('hiddendateformat').value,ratecode);
            }
           }
           else if(colName=="Premium")
           {
               bindPremCharges(document.getElementById("lstcommon").value);
            }

            else if (colName == "Position Premium") {
            bindpositionPremCharges(document.getElementById("lstcommon").value);
            }
           else  if(colName=="Days" || colName=="Time Band")
           {
            var day="";
            for(var i=0;i<document.getElementById("lstcommon").options.length;i++)
            {
             if(document.getElementById("lstcommon").options[i].selected==true)
             {
                if(day=="")
                    day=document.getElementById("lstcommon").options[i].value;
                else
                    day=day + "," + document.getElementById("lstcommon").options[i].value;    
             }   
            }
            activeIDNo.value=day;
           }
           activeIDNo.focus();
        }   
        activeIDNo="";
        return false;
     }
     else if (event.keyCode == 13 && colName=="Premium")
     {
        bindPremCharges(document.getElementById("lstcommon").value);
         checkForEnter();
     }
     else if (event.keyCode == 13 && colName == "Position Premium") {
         bindpositionPremCharges(document.getElementById("lstcommon").value);
         checkForEnter();
     }
     else if( event.keyCode == 13 && colName=="FCT/NOI/Words" || colName=="Value From" || colName=="Value To" || colName=="Disc. Per."  || colName=="Card Prem" || colName=="Contract Prem." || colName=="Min Size" || colName=="Max Size")
    {
    try{
	 if(activeRow!="" && document.getElementById('divprint').style.display=="none")
               {
                   var srcElem=document.getElementById('tblGridelec').rows[activeRow];
//                   string compcode_p, string unit_p, string channel_p, string location_p, string adtype_p, string ratetype, string day_p, 
//                   string category_p, string btb_p, string fct_p, string validfrom_p, string validto_p, 
//                   string package_p, string valufrom_p, string valueto_p, string disctype_p, string disper, string premium, string cardprem_p, 
//                   string contprem_p, string minsize_p, string maxsize_p, string progtype_p, string progname_p, string commallow_p, string ratecode_p, string source_p, string dateformat)
                   var compcode_p=document.getElementById('hiddencompcode').value;
                   var unit_p=document.getElementById('hiddencenter').value;
                   var currency_p="";
                    if(activeCell=="23")
                    {
                        if(srcElem.cells[23].childNodes[0]!="undefined" && srcElem.cells[23].childNodes[0]!=undefined && srcElem.cells[23].childNodes[0].value!=undefined)
                        currency_p=srcElem.cells[23].childNodes[0].value;
                        else
                        currency_p=srcElem.cells[23].childNodes[1].value;  
                    }
                    else{
                        currency_p=srcElem.cells[23].innerHTML;
                    }
                   if(currency_p.indexOf("(")>0)
                        currency_p=currency_p.substring(currency_p.lastIndexOf('(')+1,currency_p.lastIndexOf(')'));
                        
                   var channel_p="";
                    if(activeCell=="0")
                    {
                        if(srcElem.cells[0].childNodes[0]!="undefined" && srcElem.cells[0].childNodes[0]!=undefined && srcElem.cells[0].childNodes[0].value!=undefined)
                        channel_p=srcElem.cells[0].childNodes[0].value;
                        else
                        channel_p=srcElem.cells[0].childNodes[1].value;  
                    }
                    else{
                        channel_p=srcElem.cells[0].innerHTML;
                    }
                   if(channel_p.indexOf("(")>0)
                        channel_p=channel_p.substring(channel_p.lastIndexOf('(')+1,channel_p.lastIndexOf(')'));
                   var location_p="";
                   if(activeCell=="1")
                    {
                        if(srcElem.cells[1].childNodes[0]!="undefined" && srcElem.cells[1].childNodes[0]!=undefined && srcElem.cells[1].childNodes[0].value!=undefined)
                        location_p=srcElem.cells[1].childNodes[0].value;
                        else
                        location_p=srcElem.cells[1].childNodes[1].value;  
                    }
                    else{
                        location_p=srcElem.cells[1].innerHTML;
                    }
                    if(location_p.indexOf("(")>0)
                        location_p=location_p.substring(location_p.lastIndexOf('(')+1,location_p.lastIndexOf(')'));
                   var adtype_p="";
                   if(activeCell=="2")
                    {
                        if(srcElem.cells[2].childNodes[0]!="undefined" && srcElem.cells[2].childNodes[0]!=undefined && srcElem.cells[2].childNodes[0].value!=undefined)
                        adtype_p=srcElem.cells[2].childNodes[0].value;
                        else
                        adtype_p=srcElem.cells[2].childNodes[1].value;  
                    }
                    else{
                        adtype_p=srcElem.cells[2].innerHTML;
                    }
                    if(adtype_p.indexOf("(")>0)
                        adtype_p=adtype_p.substring(adtype_p.lastIndexOf('(')+1,adtype_p.lastIndexOf(')'));
                   var ratetype="";
                    if(activeCell=="4")
                    {
                        if(srcElem.cells[4].childNodes[0]!="undefined" && srcElem.cells[4].childNodes[0]!=undefined && srcElem.cells[4].childNodes[0].value!=undefined)
                        ratetype=srcElem.cells[4].childNodes[0].value;
                        else
                        ratetype=srcElem.cells[4].childNodes[1].value;  
                    }
                    else{
                        ratetype=srcElem.cells[4].innerHTML;
                    }
                    if(ratetype.indexOf("(")>0)
                        ratetype=ratetype.substring(ratetype.lastIndexOf('(')+1,ratetype.lastIndexOf(')'));
                   var day_p="";
                    if(activeCell=="8")
                    {
                        if(srcElem.cells[8].childNodes[0]!="undefined" && srcElem.cells[8].childNodes[0]!=undefined && srcElem.cells[8].childNodes[0].value!=undefined)
                        day_p=srcElem.cells[8].childNodes[0].value;
                        else
                        day_p=srcElem.cells[8].childNodes[1].value;  
                    }
                    else{
                        day_p=srcElem.cells[8].innerHTML;
                    }
                   var category_p="";
                    if(activeCell=="26")
                    {
                        if(srcElem.cells[26].childNodes[0]!="undefined" && srcElem.cells[26].childNodes[0]!=undefined && srcElem.cells[26].childNodes[0].value!=undefined)
                        category_p=srcElem.cells[26].childNodes[0].value;
                        else
                        category_p=srcElem.cells[26].childNodes[1].value;  
                    }
                    else{
                        category_p=srcElem.cells[26].innerHTML;
                    }
                    if(category_p.indexOf("(")>0)
                        category_p=category_p.substring(category_p.lastIndexOf('(')+1,category_p.lastIndexOf(')'));
                   var btb_p="";
                    if(activeCell=="5")
                    {
                        if(srcElem.cells[5].childNodes[0]!="undefined" && srcElem.cells[5].childNodes[0]!=undefined && srcElem.cells[5].childNodes[0].value!=undefined)
                        btb_p=srcElem.cells[5].childNodes[0].value;
                        else
                        btb_p=srcElem.cells[5].childNodes[1].value;  
                    }
                    else{
                        btb_p=srcElem.cells[5].innerHTML;
                    }
                    if(btb_p.indexOf("(")>0)
                        btb_p=btb_p.substring(btb_p.lastIndexOf('(')+1,btb_p.lastIndexOf(')'));
                   var fct_p="";
                    if(activeCell=="9")
                    {
                        if(srcElem.cells[9].childNodes[0]!="undefined" && srcElem.cells[9].childNodes[0]!=undefined && srcElem.cells[9].childNodes[0].value!=undefined)
                        fct_p=srcElem.cells[9].childNodes[0].value;
                        else
                        fct_p=srcElem.cells[9].childNodes[1].value;  
                    }
                    else{
                        fct_p=srcElem.cells[9].innerHTML;
                    }
                    if(fct_p.indexOf("(")>0)
                        fct_p=fct_p.substring(fct_p.lastIndexOf('(')+1,fct_p.lastIndexOf(')'));
                   var validfrom_p=document.getElementById('txtfromdate').value;
                   var validto_p=document.getElementById('TextBox1').value;
                   var package_p="";
                   if(activeCell=="10")
                    {
                        if(srcElem.cells[10].childNodes[0]!="undefined" && srcElem.cells[10].childNodes[0]!=undefined && srcElem.cells[10].childNodes[0].value!=undefined)
                        package_p=srcElem.cells[10].childNodes[0].value;
                        else
                        package_p=srcElem.cells[10].childNodes[1].value;  
                    }
                    else{
                        package_p=srcElem.cells[10].innerHTML;
                    }
                    if(package_p.indexOf("(")>0)
                        package_p=package_p.substring(package_p.lastIndexOf('(')+1,package_p.lastIndexOf(')'));
                   var valufrom_p="";
                     if(activeCell=="11")
                    {
                        if(srcElem.cells[11].childNodes[0]!="undefined" && srcElem.cells[11].childNodes[0]!=undefined && srcElem.cells[11].childNodes[0].value!=undefined)
                        valufrom_p=srcElem.cells[11].childNodes[0].value;
                        else
                        valufrom_p=srcElem.cells[11].childNodes[1].value;  
                    }
                    else{
                        valufrom_p=srcElem.cells[11].innerHTML;
                    }
                   var valueto_p="";
                     if(activeCell=="12")
                    {
                        if(srcElem.cells[12].childNodes[0]!="undefined" && srcElem.cells[12].childNodes[0]!=undefined && srcElem.cells[12].childNodes[0].value!=undefined)
                        valueto_p=srcElem.cells[12].childNodes[0].value;
                        else
                        valueto_p=srcElem.cells[12].childNodes[1].value;  
                    }
                    else{
                        valueto_p=srcElem.cells[12].innerHTML;
                    }
                   var disctype_p="";
                     if(activeCell=="13")
                    {
                        if(srcElem.cells[13].childNodes[0]!="undefined" && srcElem.cells[13].childNodes[0]!=undefined && srcElem.cells[13].childNodes[0].value!=undefined)
                        disctype_p=srcElem.cells[13].childNodes[0].value;
                        else
                        disctype_p=srcElem.cells[13].childNodes[1].value;  
                    }
                    else{
                        disctype_p=srcElem.cells[13].innerHTML;
                    }
                    if(disctype_p.indexOf("(")>0)
                        disctype_p=disctype_p.substring(disctype_p.lastIndexOf('(')+1,disctype_p.lastIndexOf(')'));
                   var disper="";
                    if(activeCell=="14")
                    {
                        if(srcElem.cells[14].childNodes[0]!="undefined" && srcElem.cells[14].childNodes[0]!=undefined && srcElem.cells[14].childNodes[0].value!=undefined)
                        disper=srcElem.cells[14].childNodes[0].value;
                        else
                        disper=srcElem.cells[14].childNodes[1].value;  
                    }
                    else{
                        disper=srcElem.cells[14].innerHTML;
                    }
                   var premium="";
                     if(activeCell=="15")
                    {
                        if(srcElem.cells[15].childNodes[0]!="undefined" && srcElem.cells[15].childNodes[0]!=undefined && srcElem.cells[15].childNodes[0].value!=undefined)
                        premium=srcElem.cells[15].childNodes[0].value;
                        else
                        premium=srcElem.cells[15].childNodes[1].value;  
                    }
                    else{
                        premium=srcElem.cells[15].innerHTML;
                    }
                    if(premium.indexOf("(")>0)
                        premium=premium.substring(premium.lastIndexOf('(')+1,premium.lastIndexOf(')'));
                   var cardprem_p="";
                     if(activeCell=="20")
                    {
                        if(srcElem.cells[20].childNodes[0]!="undefined" && srcElem.cells[20].childNodes[0]!=undefined && srcElem.cells[20].childNodes[0].value!=undefined)
                        cardprem_p=srcElem.cells[20].childNodes[0].value;
                        else
                        cardprem_p=srcElem.cells[20].childNodes[1].value;  
                    }
                    else{
                        cardprem_p=srcElem.cells[20].innerHTML;
                    }
                   var contprem_p="";
                    if(activeCell=="16")
                    {
                        if(srcElem.cells[16].childNodes[0]!="undefined" && srcElem.cells[16].childNodes[0]!=undefined && srcElem.cells[16].childNodes[0].value!=undefined)
                        contprem_p=srcElem.cells[16].childNodes[0].value;
                        else
                        contprem_p=srcElem.cells[16].childNodes[1].value;  
                    }
                    else{
                        contprem_p=srcElem.cells[16].innerHTML;
                    }
                   var minsize_p="";
                     if(activeCell=="21")
                    {
                        if(srcElem.cells[21].childNodes[0]!="undefined" && srcElem.cells[21].childNodes[0]!=undefined && srcElem.cells[21].childNodes[0].value!=undefined)
                        minsize_p=srcElem.cells[21].childNodes[0].value;
                        else
                        minsize_p=srcElem.cells[21].childNodes[1].value;  
                    }
                    else{
                        minsize_p=srcElem.cells[21].innerHTML;
                    }
                   var maxsize_p="";
                    if(activeCell=="22")
                    {
                        if(srcElem.cells[22].childNodes[0]!="undefined" && srcElem.cells[22].childNodes[0]!=undefined && srcElem.cells[22].childNodes[0].value!=undefined)
                        maxsize_p=srcElem.cells[22].childNodes[0].value;
                        else
                        maxsize_p=srcElem.cells[22].childNodes[1].value;  
                    }
                    else{
                        maxsize_p=srcElem.cells[22].innerHTML;
                    }
                   var progtype_p="";
                   if(activeCell=="25")
                    {
                        if(srcElem.cells[25].childNodes[0]!="undefined" && srcElem.cells[25].childNodes[0]!=undefined && srcElem.cells[25].childNodes[0].value!=undefined)
                        progtype_p=srcElem.cells[25].childNodes[0].value;
                        else
                        progtype_p=srcElem.cells[25].childNodes[1].value;  
                    }
                    else{
                        progtype_p=srcElem.cells[25].innerHTML;
                    }
                     if(progtype_p.indexOf("(")>0)
                        progtype_p=progtype_p.substring(progtype_p.lastIndexOf('(')+1,progtype_p.lastIndexOf(')'));
                   var progname_p="";
                    if(activeCell=="6")
                    {
                        if(srcElem.cells[6].childNodes[0]!="undefined" && srcElem.cells[6].childNodes[0]!=undefined && srcElem.cells[6].childNodes[0].value!=undefined)
                        progname_p=srcElem.cells[6].childNodes[0].value;
                        else
                        progname_p=srcElem.cells[6].childNodes[1].value;  
                    }
                    else{
                        progname_p=srcElem.cells[6].innerHTML;
                    }
                     if(progname_p.indexOf("(")>0)
                        progname_p=progname_p.substring(progname_p.lastIndexOf('(')+1,progname_p.lastIndexOf(')'));
                   var commallow_p="";
                    if(activeCell=="27")
                    {
                        if(srcElem.cells[27].childNodes[0]!="undefined" && srcElem.cells[27].childNodes[0]!=undefined && srcElem.cells[27].childNodes[0].value!=undefined)
                        commallow_p=srcElem.cells[27].childNodes[0].value;
                        else
                        commallow_p=srcElem.cells[27].childNodes[1].value;  
                    }
                    else{
                        commallow_p=srcElem.cells[27].innerHTML;
                    }
                    if(commallow_p.indexOf("(")>0)
                        commallow_p=commallow_p.substring(commallow_p.lastIndexOf('(')+1,commallow_p.lastIndexOf(')'));
                   var ratecode_p="";
                    if(activeCell=="29")
                    {
                        if(srcElem.cells[29].childNodes[0]!="undefined" && srcElem.cells[29].childNodes[0]!=undefined && srcElem.cells[29].childNodes[0].value!=undefined)
                        ratecode_p=srcElem.cells[29].childNodes[0].value;
                        else
                        ratecode_p=srcElem.cells[29].childNodes[1].value;  
                    }
                    else{
                        ratecode_p=srcElem.cells[29].innerHTML;
                    }
                    if(ratecode_p.indexOf("(")>0)
                        ratecode_p=ratecode_p.substring(ratecode_p.lastIndexOf('(')+1,ratecode_p.lastIndexOf(')'));
                   var source_p="";
                    if(activeCell=="33")
                    {
                        if(srcElem.cells[33].childNodes[0]!="undefined" && srcElem.cells[33].childNodes[0]!=undefined && srcElem.cells[33].childNodes[0].value!=undefined)
                        source_p=srcElem.cells[33].childNodes[0].value;
                        else
                        source_p=srcElem.cells[33].childNodes[1].value;  
                    }
                    else{
                        source_p=srcElem.cells[33].innerHTML;
                    }
                     if(source_p.indexOf("(")>0)
                        source_p=source_p.substring(source_p.lastIndexOf('(')+1,source_p.lastIndexOf(')'));
                   var dateformat=document.getElementById('hiddendateformat').value;
                   var contratcrate=srcElem.cells[17].innerHTML;
                   var agcode="";
                   if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
                        agcode=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
                   var subagencycode = document.getElementById('drpsubagcode').value     
                   var res=ContractMaster.getrateforcontract_Elec( compcode_p, unit_p, channel_p, location_p, adtype_p, ratetype, day_p,category_p, btb_p, fct_p, validfrom_p, validto_p,package_p, valufrom_p, valueto_p, disctype_p, disper, premium, cardprem_p,contprem_p, minsize_p, maxsize_p, progtype_p, progname_p, commallow_p, ratecode_p, source_p, dateformat,currency_p,contratcrate,agcode,subagencycode);
                   var ds=res.value;
                   if(ds==null)
                   {
                    alert(res.error.description);
                    return false;
                   }
                   document.getElementById('tblGridelec').rows[activeRow].cells[18].innerHTML="";
                   document.getElementById('tblGridelec').rows[activeRow].cells[34].innerHTML="";
                    document.getElementById('tblGridelec').rows[activeRow].cells[17].innerHTML="";
                   if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
                   {
                        if(ds.Tables[0].Rows[0].card_rate!=null)
                            document.getElementById('tblGridelec').rows[activeRow].cells[18].innerHTML=ds.Tables[0].Rows[0].card_rate;
                        if(ds.Tables[0].Rows[0].TOTALVAL!=null)   
                            document.getElementById('tblGridelec').rows[activeRow].cells[34].innerHTML=ds.Tables[0].Rows[0].TOTALVAL;
                            printTotal();
                   }
               }
                activeIDNo.focus();
                checkForEnter();
               }
               catch(err){}
               
                             
}
else if ((event.keyCode == 13 || event.keyCode == 9) && document.activeElement.id != "div_electronics" && document.activeElement.id != "divprint" && document.activeElement.id != "cmdAddRow" && document.activeElement.id != "cmdAddRowelec" && document.activeElement.id != "drpdealon" && document.activeElement.id != "btnExit" && document.activeElement.id != "btnDelete" && document.activeElement.id != "btnlast" && document.activeElement.id != "btnnext" && document.activeElement.id != "btnprevious" && document.activeElement.id != "btnCancel" && document.activeElement.id != "btnExecute" && document.activeElement.id != "btnQuery" && document.activeElement.id != "btnModify" && document.activeElement.id != "btnNew" && document.activeElement.id != "btnSave" && document.activeElement.id != "drpindustry" && document.activeElement.id != "lstproduct" && document.activeElement.id != "txtseq" && document.activeElement.id != "chkpatricularad" && document.activeElement.id != "chkseqno" && document.activeElement.id != "chkmultiad" && document.activeElement.id != "chkb2b" && document.activeElement.id != "txtremark" && document.activeElement.id != "drppaymenttype" && document.activeElement.id != "drpservicetax" && document.activeElement.id != "txtdealvol" && document.activeElement.id != "txtdealno" && document.activeElement.id != "txtdealvalue" && document.activeElement.id != "txtclosedate" && document.activeElement.id != "txtcontractdate" && document.activeElement.id != "lstretainer" && document.activeElement.id != "lstexec" && document.activeElement.id != "lstclient" && document.activeElement.id != "lstagency" && document.activeElement.id != "txtcaption" && document.activeElement.id != "txtfromdate" && document.activeElement.id != "TextBox1" && document.activeElement.id != "drpteamname" && document.activeElement.id != "drprepresentative" && document.activeElement.id != "txtexecutive" && document.activeElement.id != "txtretainer" && document.activeElement.id != "drpproduct" && document.activeElement.id != "drpclientname" && document.activeElement.id != "drpsubagcode" && document.activeElement.id != "drpagencycode" && document.activeElement.id != "drpcurr" && document.activeElement.id != "txtdealname" && document.activeElement.id != "drpdealtype" && document.activeElement.id != "Listcontract" && document.activeElement.id != "txtrono" && document.activeElement.id != "txtrodate" && document.activeElement.id != "drprostatus" && document.activeElement.id != "drprptcurrency")
     {
        checkForEnter();
        return false;
     }
      else if (event.keyCode == 113 && document.activeElement.id!="txtseq" && document.activeElement.id!="cmdAddRowelec" && document.activeElement.id!="cmdAddRow" &&  document.activeElement.id!="txtremark" && document.activeElement.id!="drppaymenttype" && document.activeElement.id!="drpservicetax" && document.activeElement.id!="txtdealvol" && document.activeElement.id!="txtdealvalue" && document.activeElement.id!="txtclosedate" && document.activeElement.id!="txtcontractdate" && document.activeElement.id!="lstretainer" && document.activeElement.id!="lstexec" && document.activeElement.id!="lstclient" && document.activeElement.id!="lstagency" && document.activeElement.id!="txtcaption" && document.activeElement.id!="txtfromdate" && document.activeElement.id!="TextBox1" && document.activeElement.id!="drpteamname" && document.activeElement.id!="drprepresentative" && document.activeElement.id!="txtexecutive" && document.activeElement.id!="txtretainer" && document.activeElement.id!="drpproduct" && document.activeElement.id!="drpclientname" && document.activeElement.id!="drpsubagcode" && document.activeElement.id!="drpagencycode" && document.activeElement.id!="drpcurr" &&  document.activeElement.id!="txtdealname" && document.activeElement.id!="txtdealno" && document.activeElement.id!="drpdealtype")
     {
         var srcElem = getEventCell ();
         var cellindex=srcElem.cellIndex;
       colName=element.tHead.childNodes[0].childNodes[cellindex].childNodes[0].nextSibling.data;
       if (colName == "Source" || colName == "Adv Type" || colName == "Status" || colName == "Ad Type" || colName == "Hue" || colName == "Uom" || colName == "Rate Code" || colName == "Premium" || colName == "Day" || colName == "Days" || colName == "Comm. Allow" || colName == "Deal Start" || colName == "Package" || colName == "Category" || colName == "Disc Type" || colName == "Disc On" || colName == "Currency" || colName == "Channel" || colName == "Location" || colName == "Program Type" || colName == "Program Name" || colName == "BTB" || colName == "Time Band" || colName == "Paid/Bonus" || colName == "Rate Type" || colName == "Position Premium" || colName == "Section Code" || colName == "Resource No")
        { 
            activeIDNo=document.activeElement;
          
            document.getElementById("divcommon").style.display="block";


            //aTag = eval( document.getElementById(document.activeElement.uniqueID))
            aTag = eval(document.activeElement)
	                    var btag;
	                    var leftpos=0;
	                    var toppos=0;        
	                    do
	                    {
		                    aTag = eval(aTag.offsetParent);
		                    leftpos	+= aTag.offsetLeft;
		                    toppos += aTag.offsetTop;
		                    btag=eval(aTag)
	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	                    if(document.getElementById('div_electronics').style.display!="none")
	                    {
	                         var tot=document.getElementById('div_electronics').scrollLeft;		
                            var scrolltop=document.getElementById('div_electronics').scrollTop;
                        } 
                        else{
                              var tot=document.getElementById('divprint').scrollLeft;		
                            var scrolltop=document.getElementById('divprint').scrollTop;
                        }   
//	                     document.getElementById('divcommon').style.top=(document.getElementById(document.activeElement.uniqueID).offsetTop + toppos - scrolltop) + "px";
                        //	                     document.getElementById('divcommon').style.left=(document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos - tot) + "px";
                         document.getElementById('divcommon').style.top=(document.activeElement.offsetTop + toppos - scrolltop) + "px";
                         document.getElementById('divcommon').style.left=(document.activeElement.offsetLeft + leftpos - tot) + "px";
	                     bindListBox(colName);
	                     return false;
	    }                 
     }
 }
//alert(event.which);
 if(browser!="Microsoft Internet Explorer")
 {
       if(event.which==113)
    {
        if(document.activeElement.id=="drpagencycode")
        {
            if(document.getElementById('drpagencycode').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('drpagencycode').value="";
            return false;
            }
            colName="";
            document.getElementById("div1").style.display="block";
             aTag = eval( document.getElementById("drpagencycode"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('div1').style.top=document.getElementById("drpagencycode").offsetTop + toppos + "px";
			             document.getElementById('div1').style.left=document.getElementById("drpagencycode").offsetLeft + leftpos+"px";
            ContractMaster.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('drpagencycode').value.toUpperCase(),bindagencyname_callback);
        
        }
        else if(document.activeElement.id=="drpclientname")
        {
            if(document.getElementById('drpclientname').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('drpclientname').value="";
            return false;
            }
            colName="";
            document.getElementById("divclient").style.display="block";
            aTag = eval( document.getElementById("drpclientname"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divclient').style.top=document.getElementById("drpclientname").offsetTop + toppos + "px";
			             document.getElementById('divclient').style.left=document.getElementById("drpclientname").offsetLeft + leftpos+"px";
            ContractMaster.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('drpclientname').value.toUpperCase(),bindclientname_callback);
        }
         else if(document.activeElement.id=="txtexecutive")
        {
            if(document.getElementById('txtexecutive').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtexecutive').value="";
            return false;
            }
            colName="";
            document.getElementById("divexec").style.display="block";
             aTag = eval( document.getElementById("txtexecutive"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divexec').style.top=document.getElementById("txtexecutive").offsetTop + toppos + "px";
			             document.getElementById('divexec').style.left=document.getElementById("txtexecutive").offsetLeft + leftpos+"px";
            ContractMaster.bindExec(document.getElementById('hiddencompcode').value,document.getElementById('txtexecutive').value,bindexecname_callback);			             
           
        }
         else if(document.activeElement.id=="txtretainer")
        {
            if(document.getElementById('txtretainer').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtretainer').value="";
            return false;
            }
            colName="";
            document.getElementById("divretainer").style.display="block";
           aTag = eval( document.getElementById("txtretainer"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divretainer').style.top=document.getElementById("txtretainer").offsetTop + toppos + "px";
			                 document.getElementById('divretainer').style.left=document.getElementById("txtretainer").offsetLeft + leftpos+"px";
			                 var agcode="";
                            if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
                            agcode=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
                            ContractMaster.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('txtretainer').value,agcode,bindretainer_callback);
            
        }
         else if(document.activeElement.id=='txtbtb')
        {
            document.getElementById("divbtb").style.display="block";
           aTag = eval( document.getElementById("txtbtb"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divbtb').style.top=document.getElementById("txtbtb").offsetTop + toppos + "px";
			                 document.getElementById('divbtb').style.left=document.getElementById("txtbtb").offsetLeft + leftpos+"px";
                            ContractDetail.bindBTB(document.getElementById('hiddencompcode').value,bindbtb_callback);
        }
          else if(document.activeElement.id=='txtros')
        {
             if(document.getElementById('txtbtb').value=="")
            {
            alert("Please Select BTB.");
            document.getElementById('txtbtb').focus();
            return false;
            }
            document.getElementById("divros").style.display="block";
           aTag = eval( document.getElementById("txtros"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divros').style.top=document.getElementById("txtros").offsetTop + toppos + "px";
			                 document.getElementById('divros').style.left=document.getElementById("txtros").offsetLeft + leftpos+"px";
                            ContractDetail.bindRos(document.getElementById('hiddencompcode').value,document.getElementById('txtbtb').value.substring(document.getElementById('txtbtb').value.indexOf("(")+1,document.getElementById('txtbtb').value.length-1),bindros_callback);
        }
        else if(document.activeElement.id=='txtprogramcode')
        {
             if(document.getElementById('drpprogramtype').value=="" || document.getElementById('drpprogramtype').value=="0")
            {
            alert("Please Select Program Type.");
            document.getElementById('drpprogramtype').focus();
            return false;
            }
            document.getElementById("divcommon").style.display="block";
           aTag = eval( document.getElementById("txtprogramcode"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divcommon').style.top=document.getElementById("txtprogramcode").offsetTop + toppos + "px";
			                 document.getElementById('divcommon').style.left=document.getElementById("txtprogramcode").offsetLeft + leftpos+"px";
                            ContractDetail.bindProgram(document.getElementById('hiddencompcode').value,document.getElementById('drpprogramtype').value,bindprogram_callback);
                        }
                        else if (document.activeElement.id == "txtdealname") {
                            //                            if (document.getElementById('drpclientname').value.length <= 2) {
                            //                                alert("Please Enter Minimum 3 Character For Searching.");
                            //                                document.getElementById('drpclientname').value = "";
                            //                                return false;
                            //                            }
                            colName = "";
                            document.getElementById("divcontract").style.display = "block";
                            aTag = eval(document.getElementById("txtdealname"))
                            var btag;
                            var leftpos = 0;
                            var toppos = 0;
                            do {
                                aTag = eval(aTag.offsetParent);
                                leftpos += aTag.offsetLeft;
                                toppos += aTag.offsetTop;
                                btag = eval(aTag)
                            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                            document.getElementById('divcontract').style.top = document.getElementById("txtdealname").offsetTop + toppos + "px";
                            document.getElementById('divcontract').style.left = document.getElementById("txtdealname").offsetLeft + leftpos + "px";
                            ContractMaster.bindcontarctname(document.getElementById('hiddencompcode').value, document.getElementById('txtdealname').value.toUpperCase(), bindcontract);
                        }
    }
    else if(event.which==27)
     {
      if(document.getElementById("divcommon")!=null && document.getElementById("divcommon").style.display=="block")
      {
         document.getElementById("divcommon").style.display="none";
         try{
         activeIDNo.focus();
         }
         catch(err)
         {}
         activeIDNo="";
      }   
//        if(document.getElementById("divcommon")!=null && document.getElementById("divcommon").style.display=="block")
//        {
//            document.getElementById("divcommon").style.display="none"
//            document.getElementById('txtprogramcode').focus();
//        }
//        else  if(document.getElementById("divbtb")!=null && document.getElementById("divbtb").style.display=="block")
//        {
//            document.getElementById("divbtb").style.display="none"
//            document.getElementById('txtbtb').focus();
//        }
//         else  if(document.getElementById("divros")!=null && document.getElementById("divros").style.display=="block")
//        {
//            document.getElementById("divros").style.display="none"
//            document.getElementById('txtros').focus();
//        }
        else if(document.getElementById("div1")!=null && document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('drpagencycode').focus();
        }
        else if(document.getElementById("divclient")!=null && document.getElementById("divclient").style.display=="block")
        {
            document.getElementById("divclient").style.display="none"
            document.getElementById('drpclientname').focus();
        }
         else if(document.getElementById("divexec")!=null && document.getElementById("divexec").style.display=="block")
        {
            document.getElementById("divexec").style.display="none"
            document.getElementById('txtexecutive').focus();
        }
         else if(document.getElementById("divretainer")!=null && document.getElementById("divretainer").style.display=="block")
        {
            document.getElementById("divretainer").style.display="none"
            document.getElementById('txtretainer').focus();
        }
        else if (document.getElementById("divcontract") != null && document.getElementById("divcontract").style.display == "block") {
        document.getElementById("divcontract").style.display = "none"
        document.getElementById('txtdealname').focus();
        }
        else{
            return false;
        }
     }
     if(event.which==13)
        {
              if(document.activeElement.id=="lstros")
            {
            document.getElementById('txtros').value=document.getElementById('lstros').options[document.getElementById('lstros').selectedIndex].text +"("+document.getElementById('lstros').value+")";
            document.getElementById("divros").style.display="none";
            document.getElementById('txtfromdate').focus();
             return false;
            }
              if(document.activeElement.id=="lstbtb")
            {
            document.getElementById('txtbtb').value=document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text +"("+document.getElementById('lstbtb').value+")";
            document.getElementById("divbtb").style.display="none";
            document.getElementById('drpprogramtype').focus();
             return false;
            }
              if(document.activeElement.id=="lstcommon")
            {
               
            document.getElementById('txtprogramcode').value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
            document.getElementById("divcommon").style.display="none";
            document.getElementById('txtros').focus();
             return false;
            }
            if(document.activeElement.id=="lstretainer")
            {
                if(document.getElementById('lstretainer').value=="0" )
                {
                    alert("Please select the Retainer");
                    return false;
                }
            document.getElementById('txtretainer').value=document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text +"("+document.getElementById('lstretainer').value+")";
            document.getElementById("divretainer").style.display="none";
            document.getElementById('drpteamname').focus();
             return false;
         }
         if (document.activeElement.id == "Listcontract") {
             if (document.getElementById('Listcontract').value == "0") {
                 alert("Please select contract");
                 return false;
             }
             document.getElementById('txtdealname').value = document.getElementById('Listcontract').value ;
             document.getElementById("divcontract").style.display = "none";
             document.getElementById('drpagencycode').focus();
             return false;
         }
            if(document.activeElement.id=="lstexec")
            {
                if(document.getElementById('lstexec').value=="0")// || document.getElementById('hiddensavemod').value=="01")
                {
                    alert("Please select the Executive");
                    return false;
                }
                document.getElementById("divexec").style.display="none";
                document.getElementById('txtexecutive').value=document.getElementById('lstexec').options[document.getElementById('lstexec').selectedIndex].text +"("+document.getElementById('lstexec').value+")";
                document.getElementById('txtretainer').focus();
                 return false;
//                var datetime=document.getElementById('txtdatetime').value;
//            
//                var page=document.getElementById('lstexec').value;
//                   
//                var id="";
//                if(browser!="Microsoft Internet Explorer")
//                {
//                    var  httpRequest =null;;
//                    httpRequest= new XMLHttpRequest();
//                    if (httpRequest.overrideMimeType) {
//                        httpRequest.overrideMimeType('text/xml'); 
//                    }
//                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

//                    httpRequest.open( "GET","clientName.aspx?page="+page+"&value=3", false );
//                    httpRequest.send('');
//                    if (httpRequest.readyState == 4) 
//                    {
//                        if (httpRequest.status == 200) 
//                        {
//                            id=httpRequest.responseText;
//                        }
//                        else 
//                        {
//                            alert('There was a problem with the request.');
//                        }
//                    }
//                }
//                else
//                {
//                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
//                    xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
//                    xml.Send();
//                    id=xml.responseText;
//                }
//            
//                document.getElementById('txtexecutive').value=id;
            }
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
               // document.getElementById('hiddenagency').value=page;
                agencycodeglo=page;
                 var value="0";

                var res=ContractMaster.addclientname(page,datetime,value);
                 var id=res.value;
                 var split=id.split("+");
                 var nameagen=split[0];
                 var agenadd=split[1];
                       var codbrk=nameagen.split("(");
                         document.getElementById('hdnagency').value=(codbrk[1].split(")"))[0];
                document.getElementById('drpagencycode').value=nameagen;
                agency_change();
                document.getElementById('drpagencycode').focus();
                return false;
            }
        else if(document.activeElement.id=="lstclient")
            {
               if(document.getElementById('lstclient').value=="0")
                {
                    alert("Please select the client");
                    return false;
                }
                document.getElementById("divclient").style.display="none";
                var datetime="";
                //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
             
                var page=document.getElementById('lstclient').value;
               
                
                var id="";
                if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                    }
                    
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                    httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
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
                     xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
                     xml.Send();
                     id=xml.responseText;
                }
                 if(id=="yes")
                 {
                     alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                     return false;
                 }
                 var split=id.split("+");
                 var namecode=split[0];
                 var add=split[1];

                document.getElementById('hdnclientcod').value=page; 
                document.getElementById('drpclientname').value=namecode;
              
               //  clientChange();
               /* if(document.getElementById('hiddensavemod').value=="0")
                {
                    document.getElementById('txtclientadd').value=add;        
                    document.getElementById('txtclientadd').focus();
                }
                 bind_agen_bill();*/
                document.getElementById('drpclientname').focus();
                
                return false;
            }
            if(document.activeElement.id==id)
            {
                if(document.getElementById('btnSave').disabled==false)
                {
            document.getElementById('btnSave').focus();
                }
            return;

            }
            else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
            {
                event.which=13;
                return event.which;

            }
            else
            {
            //alert(event.which);
            try{
            if(document.activeElement.id=="drpagencycode")
            {
                document.getElementById('drpsubagcode').focus();
                return false;
            }
            event.which=9;
            //alert(event.which);
            return event.which;
            }
            catch(err)
            {}
            }
        }
        
        if(event.which==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
 }       
else
{
    if(event.keyCode==113)
    {
        if(document.activeElement.id=="drpagencycode")
        {
            if(document.getElementById('drpagencycode').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('drpagencycode').value="";
            return false;
            }
            colName="";
            document.getElementById("div1").style.display="block";
             aTag = eval( document.getElementById("drpagencycode"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('div1').style.top=document.getElementById("drpagencycode").offsetTop + toppos + "px";
			             document.getElementById('div1').style.left=document.getElementById("drpagencycode").offsetLeft + leftpos+"px";
            ContractMaster.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('drpagencycode').value.toUpperCase(),bindagencyname_callback);
        
        }
        else if(document.activeElement.id=="drpclientname")
        {
            if(document.getElementById('drpclientname').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('drpclientname').value="";
            return false;
            }
            colName="";
            document.getElementById("divclient").style.display="block";
            aTag = eval( document.getElementById("drpclientname"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divclient').style.top=document.getElementById("drpclientname").offsetTop + toppos + "px";
			             document.getElementById('divclient').style.left=document.getElementById("drpclientname").offsetLeft + leftpos+"px";
            ContractMaster.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('drpclientname').value.toUpperCase(),bindclientname_callback);
        }
         else if(document.activeElement.id=="txtexecutive")
        {
            if(document.getElementById('txtexecutive').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtexecutive').value="";
            return false;
            }
            colName="";
            document.getElementById("divexec").style.display="block";
             aTag = eval( document.getElementById("txtexecutive"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divexec').style.top=document.getElementById("txtexecutive").offsetTop + toppos + "px";
			             document.getElementById('divexec').style.left=document.getElementById("txtexecutive").offsetLeft + leftpos+"px";
            ContractMaster.bindExec(document.getElementById('hiddencompcode').value,document.getElementById('txtexecutive').value,bindexecname_callback);			             
           
        }
         else if(document.activeElement.id=="txtretainer")
        {
            if(document.getElementById('txtretainer').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtretainer').value = "";
            document.getElementById('txtretainer').focus();
            return false;
            }
            colName="";
            document.getElementById("divretainer").style.display="block";
           aTag = eval( document.getElementById("txtretainer"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divretainer').style.top=document.getElementById("txtretainer").offsetTop + toppos + "px";
			                 document.getElementById('divretainer').style.left=document.getElementById("txtretainer").offsetLeft + leftpos+"px";
			                 var agcode="";
                            if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
                            agcode=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
                            ContractMaster.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('txtretainer').value,agcode,bindretainer_callback);
            
        }
         else if(document.activeElement.id=='txtbtb')
        {
            document.getElementById("divbtb").style.display="block";
           aTag = eval( document.getElementById("txtbtb"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divbtb').style.top=document.getElementById("txtbtb").offsetTop + toppos + "px";
			                 document.getElementById('divbtb').style.left=document.getElementById("txtbtb").offsetLeft + leftpos+"px";
                            ContractDetail.bindBTB(document.getElementById('hiddencompcode').value,bindbtb_callback);
        }
          else if(document.activeElement.id=='txtros')
        {
             if(document.getElementById('txtbtb').value=="")
            {
            alert("Please Select BTB.");
            document.getElementById('txtbtb').focus();
            return false;
            }
            document.getElementById("divros").style.display="block";
           aTag = eval( document.getElementById("txtros"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divros').style.top=document.getElementById("txtros").offsetTop + toppos + "px";
			                 document.getElementById('divros').style.left=document.getElementById("txtros").offsetLeft + leftpos+"px";
                            ContractDetail.bindRos(document.getElementById('hiddencompcode').value,document.getElementById('txtbtb').value.substring(document.getElementById('txtbtb').value.indexOf("(")+1,document.getElementById('txtbtb').value.length-1),bindros_callback);
        }
        else if(document.activeElement.id=='txtprogramcode')
        {
             if(document.getElementById('drpprogramtype').value=="" || document.getElementById('drpprogramtype').value=="0")
            {
            alert("Please Select Program Type.");
            document.getElementById('drpprogramtype').focus();
            return false;
            }
            document.getElementById("divcommon").style.display="block";
           aTag = eval( document.getElementById("txtprogramcode"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divcommon').style.top=document.getElementById("txtprogramcode").offsetTop + toppos + "px";
			                 document.getElementById('divcommon').style.left=document.getElementById("txtprogramcode").offsetLeft + leftpos+"px";
                            ContractDetail.bindProgram(document.getElementById('hiddencompcode').value,document.getElementById('drpprogramtype').value,bindprogram_callback);
                        }
                        else if (document.activeElement.id == "txtdealname") {
//                            if (document.getElementById('drpclientname').value.length <= 2) {
//                                alert("Please Enter Minimum 3 Character For Searching.");
//                                document.getElementById('drpclientname').value = "";
//                                return false;
//                            }
                            colName = "";
                            document.getElementById("divcontract").style.display = "block";
                            aTag = eval(document.getElementById("txtdealname"))
                            var btag;
                            var leftpos = 0;
                            var toppos = 0;
                            do {
                                aTag = eval(aTag.offsetParent);
                                leftpos += aTag.offsetLeft;
                                toppos += aTag.offsetTop;
                                btag = eval(aTag)
                            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
                            document.getElementById('divcontract').style.top = document.getElementById("txtdealname").offsetTop + toppos + "px";
                            document.getElementById('divcontract').style.left = document.getElementById("txtdealname").offsetLeft + leftpos + "px";
                            ContractMaster.bindcontarctname(document.getElementById('hiddencompcode').value, document.getElementById('txtdealname').value.toUpperCase(), bindcontract);
                        }
    }
    else if(event.keyCode==27)
     {
      if(document.getElementById("divcommon")!=null && document.getElementById("divcommon").style.display=="block")
      {
         document.getElementById("divcommon").style.display="none";
         try{
         activeIDNo.focus();
         }
         catch(err)
         {}
         activeIDNo="";
      }   
//        if(document.getElementById("divcommon")!=null && document.getElementById("divcommon").style.display=="block")
//        {
//            document.getElementById("divcommon").style.display="none"
//            document.getElementById('txtprogramcode').focus();
//        }
//        else  if(document.getElementById("divbtb")!=null && document.getElementById("divbtb").style.display=="block")
//        {
//            document.getElementById("divbtb").style.display="none"
//            document.getElementById('txtbtb').focus();
//        }
//         else  if(document.getElementById("divros")!=null && document.getElementById("divros").style.display=="block")
//        {
//            document.getElementById("divros").style.display="none"
//            document.getElementById('txtros').focus();
//        }
        else if(document.getElementById("div1")!=null && document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('drpagencycode').focus();
        }
        else if(document.getElementById("divclient")!=null && document.getElementById("divclient").style.display=="block")
        {
            document.getElementById("divclient").style.display="none"
            document.getElementById('drpclientname').focus();
        }
         else if(document.getElementById("divexec")!=null && document.getElementById("divexec").style.display=="block")
        {
            document.getElementById("divexec").style.display="none"
            document.getElementById('txtexecutive').focus();
        }
         else if(document.getElementById("divretainer")!=null && document.getElementById("divretainer").style.display=="block")
        {
            document.getElementById("divretainer").style.display="none"
            document.getElementById('txtretainer').focus();
        }
        else if (document.getElementById("divcontract") != null && document.getElementById("divcontract").style.display == "block") {
        document.getElementById("divcontract").style.display = "none"
        document.getElementById('txtdealname').focus();
        }
        else{
            return false;
        }
     }
     if(event.keyCode==13)
        {
              if(document.activeElement.id=="lstros")
            {
            document.getElementById('txtros').value=document.getElementById('lstros').options[document.getElementById('lstros').selectedIndex].text +"("+document.getElementById('lstros').value+")";
            document.getElementById("divros").style.display="none";
            document.getElementById('txtfromdate').focus();
             return false;
            }
              if(document.activeElement.id=="lstbtb")
            {
            document.getElementById('txtbtb').value=document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text +"("+document.getElementById('lstbtb').value+")";
            document.getElementById("divbtb").style.display="none";
            document.getElementById('drpprogramtype').focus();
             return false;
            }
              if(document.activeElement.id=="lstcommon")
            {
               
            document.getElementById('txtprogramcode').value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
            document.getElementById("divcommon").style.display="none";
            document.getElementById('txtros').focus();
             return false;
            }
            if(document.activeElement.id=="lstretainer")
            {
                if(document.getElementById('lstretainer').value=="0" )
                {
                    alert("Please select the Retainer");
                    return false;
                }
            document.getElementById('txtretainer').value=document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text +"("+document.getElementById('lstretainer').value+")";
            document.getElementById("divretainer").style.display="none";
            document.getElementById('drpteamname').focus();
             return false;
         }
         if (document.activeElement.id == "Listcontract") {
             if (document.getElementById('Listcontract').value == "0") {
                 alert("Please select contract");
                 return false;
             }
             document.getElementById('txtdealname').value = document.getElementById('Listcontract').value;
             document.getElementById("divcontract").style.display = "none";
             document.getElementById('drpagencycode').focus();
             return false;
         }
            if(document.activeElement.id=="lstexec")
            {
                if(document.getElementById('lstexec').value=="0")// || document.getElementById('hiddensavemod').value=="01")
                {
                    alert("Please select the Executive");
                    return false;
                }
                document.getElementById("divexec").style.display="none";
                document.getElementById('txtexecutive').value=document.getElementById('lstexec').options[document.getElementById('lstexec').selectedIndex].text +"("+document.getElementById('lstexec').value+")";
                document.getElementById('txtretainer').focus();
                 return false;
//                var datetime=document.getElementById('txtdatetime').value;
//            
//                var page=document.getElementById('lstexec').value;
//                   
//                var id="";
//                if(browser!="Microsoft Internet Explorer")
//                {
//                    var  httpRequest =null;;
//                    httpRequest= new XMLHttpRequest();
//                    if (httpRequest.overrideMimeType) {
//                        httpRequest.overrideMimeType('text/xml'); 
//                    }
//                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

//                    httpRequest.open( "GET","clientName.aspx?page="+page+"&value=3", false );
//                    httpRequest.send('');
//                    if (httpRequest.readyState == 4) 
//                    {
//                        if (httpRequest.status == 200) 
//                        {
//                            id=httpRequest.responseText;
//                        }
//                        else 
//                        {
//                            alert('There was a problem with the request.');
//                        }
//                    }
//                }
//                else
//                {
//                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
//                    xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
//                    xml.Send();
//                    id=xml.responseText;
//                }
//            
//                document.getElementById('txtexecutive').value=id;
            }
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
               // document.getElementById('hiddenagency').value=page;
                agencycodeglo=page;
                 var value="0";

                var res=ContractMaster.addclientname(page,datetime,value);
                 var id=res.value;
                 var split=id.split("+");
                 var nameagen=split[0];
                 var agenadd=split[1];
                 var codbrk=nameagen.split("(");
                         document.getElementById('hdnagency').value=(codbrk[1].split(")"))[0];
                document.getElementById('drpagencycode').value=nameagen;
                agency_change();
                bindpaymentType(document.getElementById('drpagencycode').value,document.getElementById('drpsubagcode').value);
                document.getElementById('drpagencycode').focus();
                return false;
            }
        else if(document.activeElement.id=="lstclient")
            {
               if(document.getElementById('lstclient').value=="0")
                {
                    alert("Please select the client");
                    return false;
                }
                document.getElementById("divclient").style.display="none";
                var datetime="";
                //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
             
                var page=document.getElementById('lstclient').value;
               
                
                var id="";
                if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                    }
                    
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                    httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
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
                     xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
                     xml.Send();
                     id=xml.responseText;
                }
                 if(id=="yes")
                 {
                     alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
                     return false;
                 }
                 var split=id.split("+");
                 var namecode=split[0];
                 var add=split[1];

                document.getElementById('hdnclientcod').value=page; 
                document.getElementById('drpclientname').value=namecode;
              
//                 clientChange();
               /* if(document.getElementById('hiddensavemod').value=="0")
                {
                    document.getElementById('txtclientadd').value=add;        
                    document.getElementById('txtclientadd').focus();
                }
                 bind_agen_bill();*/
                document.getElementById('drpclientname').focus();
                 multipleclientschk(document.getElementById('hdnclientcod').value,document.getElementById('hdnclientnamelist').value);
                return false;
            }
            if(document.activeElement.id==id)
            {
                if(document.getElementById('btnSave').disabled==false)
                {
            document.getElementById('btnSave').focus();
                }
            return;

            }
            else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
            {
                event.keyCode=13;
                return event.keyCode;

            }
            else
            {
            //alert(event.keyCode);
            try{
            if(document.activeElement.id=="drpagencycode")
            {
                document.getElementById('drpsubagcode').focus();
                return false;
            }
            event.keyCode=9;
            //alert(event.keyCode);
            return event.keyCode;
            }
            catch(err)
            {}
            }
        }
        
        if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
}
}
catch(err){
}
}
//bind agency callback
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
    document.getElementById('drpagencycode').value="";
    document.getElementById("lstagency").value="0";
    document.getElementById("lstagency").focus();
    return false;
}
////////////////this function is called when we open the list box of agency than on mouse click it get the agency

function insertagency(event)
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
       // document.getElementById('hiddenagency').value=page;
        agencycodeglo=page;
        var value="0";
//        var id="";
//        if(browser!="Microsoft Internet Explorer")
//        {
//            var  httpRequest =null;;
//            httpRequest= new XMLHttpRequest();
//            if (httpRequest.overrideMimeType) {
//            httpRequest.overrideMimeType('text/xml'); 
//            }
//            
//            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

//            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
//            httpRequest.send('');
//            //alert(httpRequest.readyState);
//            if (httpRequest.readyState == 4) 
//            {
//                //alert(httpRequest.status);
//                if (httpRequest.status == 200) 
//                {
//                    id=httpRequest.responseText;
//                }
//                else 
//                {
//                    alert('There was a problem with the request.');
//                }
//            }
//        }
//        else
//        {          
//             var xml = new ActiveXObject("Microsoft.XMLHTTP");
//             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
//             xml.Send();
//             id=xml.responseText;
//        }
//          if(id=="yes")
//         {
//             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
//             return false;
//         }
//         var split=id.split("+");
//         var nameagen=split[0];
//         var agenadd=split[1];
        var res=ContractMaster.addclientname(page,datetime,value);
         var id=res.value;
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd=split[1];
         var codbrk=nameagen.split("(");
         document.getElementById('hdnagency').value=(codbrk[1].split(")"))[0];
        document.getElementById('drpagencycode').value=nameagen;
        agency_change();
         bindpaymentType(document.getElementById('drpagencycode').value,document.getElementById('drpsubagcode').value);
        document.getElementById('drpagencycode').focus();
        return false;
    }
 else if(document.activeElement.id=="lstclient")
    {
       if(document.getElementById('lstclient').value=="0")
        {
            alert("Please select the client");
            return false;
        }
        document.getElementById("divclient").style.display="none";
        var datetime="";
        //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
     
        var page=document.getElementById('lstclient').value;
       
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

            httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
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
             xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
             xml.Send();
             id=xml.responseText;
        }
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var namecode=split[0];
         var add=split[1];

        document.getElementById('hdnclientcod').value=page; 
        document.getElementById('drpclientname').value=namecode;
//        if(document.getElementById('hdnclientcodlist').value==null ||document.getElementById('hdnclientcodlist').value=="")
//      {
//      document.getElementById('hdnclientcodlist').value=page;
//      document.getElementById('hdnclientnamelist').value=namecode;
//      }
//      
//       document.getElementById('hdnclientcodlist').value= document.getElementById('hdnclientcod').value+",";
//      document.getElementById('hdnclientnamelist').value=document.getElementById('drpclientname').value+",";
//         clientChange();
       /* if(document.getElementById('hiddensavemod').value=="0")
        {
            document.getElementById('txtclientadd').value=add;        
            document.getElementById('txtclientadd').focus();
        }
         bind_agen_bill();*/
        document.getElementById('drpclientname').focus();
        multipleclientschk(document.getElementById('hdnclientcod').value,document.getElementById('hdnclientnamelist').value);
        return false;
    }
    else  if(document.activeElement.id=="lstros")
            {
            document.getElementById('txtros').value=document.getElementById('lstros').options[document.getElementById('lstros').selectedIndex].text +"("+document.getElementById('lstros').value+")";
            document.getElementById("divros").style.display="none";
            if(document.getElementById('txtfromdate').disabled==false)
            document.getElementById('txtfromdate').focus();
             return false;
            }
     else if(document.activeElement.id=="lstbtb")
            {
            document.getElementById('txtbtb').value=document.getElementById('lstbtb').options[document.getElementById('lstbtb').selectedIndex].text +"("+document.getElementById('lstbtb').value+")";
            document.getElementById("divbtb").style.display="none";
            document.getElementById('drpprogramtype').focus();
             return false;
            }
     else if(document.activeElement.id=="lstcommon")
            {
               
            document.getElementById('txtprogramcode').value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
            document.getElementById("divcommon").style.display="none";
            document.getElementById('txtros').focus();
             return false;
            }
     else if(document.activeElement.id=="lstretainer")
            {
                if(document.getElementById('lstretainer').value=="0" )
                {
                    alert("Please select the Retainer");
                    return false;
                }
            document.getElementById('txtretainer').value=document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text +"("+document.getElementById('lstretainer').value+")";
            document.getElementById("lstretainer").style.display="none";
            document.getElementById('txtretainer').focus();
             return false;
            }
      else if(document.activeElement.id=="lstexec")
            {
                if(document.getElementById('lstexec').value=="0")// || document.getElementById('hiddensavemod').value=="01")
                {
                    alert("Please select the Executive");
                    return false;
                }
                document.getElementById("divexec").style.display="none";
                document.getElementById('txtexecutive').value=document.getElementById('lstexec').options[document.getElementById('lstexec').selectedIndex].text +"("+document.getElementById('lstexec').value+")";
                document.getElementById('txtexecutive').focus();
                 return false;
//                var datetime=document.getElementById('txtdatetime').value;
//            
//                var page=document.getElementById('lstexec').value;
//                   
//                var id="";
//                if(browser!="Microsoft Internet Explorer")
//                {
//                    var  httpRequest =null;;
//                    httpRequest= new XMLHttpRequest();
//                    if (httpRequest.overrideMimeType) {
//                        httpRequest.overrideMimeType('text/xml'); 
//                    }
//                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

//                    httpRequest.open( "GET","clientName.aspx?page="+page+"&value=3", false );
//                    httpRequest.send('');
//                    if (httpRequest.readyState == 4) 
//                    {
//                        if (httpRequest.status == 200) 
//                        {
//                            id=httpRequest.responseText;
//                        }
//                        else 
//                        {
//                            alert('There was a problem with the request.');
//                        }
//                    }
//                }
//                else
//                {
//                    var xml = new ActiveXObject("Microsoft.XMLHTTP");
//                    xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
//                    xml.Send();
//                    id=xml.responseText;
//                }
//            
//                document.getElementById('txtexecutive').value=id;
             }

             else if (document.activeElement.id == "Listcontract") {
             if (document.getElementById('Listcontract').value == "0") {
                     alert("Please select the Contract");
                     return false;
                 }
                 document.getElementById('txtdealname').value = document.getElementById('Listcontract').value;
                 document.getElementById("Listcontract").style.display = "none";
                 document.getElementById('txtdealname').focus();
                 return false;
             }
}

function multipleclientschk()
{

     // document.getElementById('hdnclientcodlist').value="," + document.getElementById('hdnclientcod').value;
      //document.getElementById('hdnclientnamelist').value="," + document.getElementById('drpclientname').value;
    //ds=response.value;
    document.getElementById('hdnclientcodlist').value.split(',');
    var code=new Array();
    var name=new Array();
   
    var pkgitem = document.getElementById("drpclientnamelist");
    //pkgitem.options.length = 0; 
    //pkgitem.options[0]=new Option("-Select Client-","0");
    if(document.getElementById('hdnclientcod').value!= null && document.getElementById('hdnclientcod').value!="") 
    { 
            //alert(pkgitem.options.length);
       
//        for (var i = 0  ; i < ds.Tables[0].Rows.length-1; ++i)
//        {
            pkgitem.options[pkgitem.options.length] = new Option(document.getElementById('drpclientname').value,document.getElementById('hdnclientcod').value);
        
//            pkgitem.options.length;   
 //pkgitem.options.length++;     
//        }    
    }
    //document.getElementById('drpclientname').value="";
    //document.getElementById("lstclient").value="0";
   // document.getElementById("lstclient").focus();  //uncomment
    
     return false;


}


function multipleclientclear()
{
 var index1=document.getElementById('drpclientnamelist').options.selectedIndex;
if(index1 == -1)
        {
         alert('Please select Client to remove');
         return false;
        }
for(var i=0;i<document.getElementById("drpclientnamelist").length;i++)
{
if(document.getElementById("drpclientnamelist").options[i].selected==false) 
{
//document.getElementById("drpclientnamelist").options[i]="";
  var pkgitem = document.getElementById("drpclientnamelist1");
   pkgitem.options[pkgitem.options.length] = new Option(document.getElementById("drpclientnamelist").options[i].text,document.getElementById("drpclientnamelist").options[i].value);
        
}
}

document.getElementById("drpclientnamelist").innerHTML="";
for(var i=0;i<document.getElementById("drpclientnamelist1").length;i++)
{

  var pkgitem1 = document.getElementById("drpclientnamelist");
   pkgitem1.options[pkgitem1.options.length] = new Option(document.getElementById("drpclientnamelist1").options[i].text,document.getElementById("drpclientnamelist1").options[i].value);
}
document.getElementById("drpclientnamelist1").innerHTML="";
document.getElementById('hdnclientcod').value="";
document.getElementById('drpclientname').value="";
return false;
}


function multipleclientclearall()
{
 
document.getElementById("drpclientnamelist").innerHTML="";
document.getElementById('hdnclientcod').value="";
document.getElementById('drpclientname').value="";
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
            //alert(pkgitem.options.length);
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
        
            pkgitem.options.length;       
        }    
    }
    document.getElementById('drpclientname').value="";
    document.getElementById("lstclient").value="0";
    document.getElementById("lstclient").focus();  //uncomment
    
     return false;
}
   function bindexecname_callback(response)
    {
         ds=response.value;
         var pkgitem = document.getElementById("lstexec");
         pkgitem.options.length = 0; 
         pkgitem.options[0]=new Option("-Select-","0");
         if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
         {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name,ds.Tables[0].Rows[i].exe_no);                
               pkgitem.options.length;               
            }
         }
         document.getElementById('txtexecutive').value="";
         document.getElementById("lstexec").value="0";
         if(document.getElementById("lstexec").style.visibility=="hidden")
            document.getElementById("lstexec").style.visibility="visible";
         document.getElementById("lstexec").focus();
         return false;

    }
 function bindbtb_callback(res)
 {
    var ds=res.value;
    var pkgitem = document.getElementById("lstbtb");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select-","0");
    
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BTB_DESC,ds.Tables[0].Rows[i].BTB_CODE);                
                pkgitem.options.length;               
            }
            
        }
        document.getElementById("divbtb").style.display="block";
        document.getElementById('txtbtb').value="";          
        document.getElementById("lstbtb").value="0";
        document.getElementById("lstbtb").focus();
        return false;    
 }   
  function bindros_callback(res)
 {
    var ds=res.value;
    var pkgitem = document.getElementById("lstros");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select-","0");
    
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BND_DESC,ds.Tables[0].Rows[i].BND_CODE);                
                pkgitem.options.length;               
            }
            
        }
        document.getElementById("divros").style.display="block";
        document.getElementById('txtros').value="";          
        document.getElementById("lstros").value="0";
        document.getElementById("lstros").focus();
        return false;    
 }  
 function bindprogram_callback(res)
 {
    var ds=res.value;
    var pkgitem = document.getElementById("lstcommon");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select-","0");
    
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SHORT_NAME,ds.Tables[0].Rows[i].PRG_ID);                
                pkgitem.options.length;               
            }
            
        }
        document.getElementById("divcommon").style.display="block";
        document.getElementById('txtprogramcode').value="";          
        document.getElementById("lstcommon").value="0";
        document.getElementById("lstcommon").focus();
        return false;    
 }   
    function bindretainer_callback(res)
{
    var ds=res.value;
    var pkgitem = document.getElementById("lstretainer");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select-","0");
    
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name,ds.Tables[0].Rows[i].Retain_Code);                
                pkgitem.options.length;               
            }
            
        }
        document.getElementById("divretainer").style.display="block";
        document.getElementById("lstretainer").style.display="block";
        document.getElementById('txtretainer').value="";          
        document.getElementById("lstretainer").value="0";
        document.getElementById("lstretainer").focus();
        return false;    
}
function checkGridValidations()
{
   
      if(document.getElementById('tblGrid').rows.length>1)
    {
        var arr=MultiDimensionalArray(document.getElementById('tblGrid').rows.length-1,4); 
        for(var i=1;i<document.getElementById('tblGrid').rows.length;i++)
        {
            if(document.getElementById('drpdealon').value=="print" || document.getElementById('drpdealon').value=="print&ele")
            {
//                var category=document.getElementById('tblGrid').rows[i].cells[4].innerHTML;
//                if(category.indexOf("(")>0)
//                    category=category.substring(category.lastIndexOf('(')+1,category.lastIndexOf(')'));
//                if(category=="")
//                {
//                    alert("Category can't be blank in Print Details");
//                    return false;
//                }    
//                var hue=document.getElementById('tblGrid').rows[i].cells[1].innerHTML;
//                if(hue.indexOf("(")>0)
//                    hue=hue.substring(hue.lastIndexOf('(')+1,hue.lastIndexOf(')'));
//                 if(hue=="")
//                {
//                    alert("Hue can't be blank in Print Details");
//                    return false;
//                }       
                var package=document.getElementById('tblGrid').rows[i].cells[3].innerHTML;
                if(package.indexOf("(")>0)
                    package=package.substring(package.lastIndexOf('(')+1,package.lastIndexOf(')'));   
                 if(package=="")
                {
                    alert("Package can't be blank in Print Details");
                    return false;
                } 
                
//                  var contrate=document.getElementById('tblGrid').rows[i].cells[8].innerHTML;
//                 var cardrate=document.getElementById('tblGrid').rows[i].cells[9].innerHTML;
//                  if(cardrate=="")
//                {
//                    alert("Card Rate can't be blank in Print Details");
//                    return false;
//                }  
//                 if(contrate=="")
//                {
//                    alert("Contract Rate can't be blank in Print Details");
//                    return false;
//                }
//                var day = document.getElementById('tblGrid').rows[i].cells[18].innerHTML;
//                var insertion = document.getElementById('tblGrid').rows[i].cells[19].innerHTML;   
//                var mins=document.getElementById('tblGrid').rows[i].cells[14].innerHTML;        
//                var maxs=document.getElementById('tblGrid').rows[i].cells[15].innerHTML;        
//                var valuef=document.getElementById('tblGrid').rows[i].cells[16].innerHTML;        
//                var valuet=document.getElementById('tblGrid').rows[i].cells[17].innerHTML;        
//                arr[i-1][0]= category;
//                arr[i-1][1]= hue;
//                arr[i-1][2]= package;
//                arr[i - 1][3] = day;
//                arr[i - 1][4] = insertion;
//                arr[i - 1][5] = mins;
//                arr[i - 1][6] = maxs;
//                arr[i - 1][7] = valuef;
//                arr[i - 1][8] = valuet;
           }     
        }
//        for(var j=0;j<arr.length;j++)
//        {
//            var category=arr[j][0];
//            var hue=arr[j][1];
//            var package=arr[j][2];
//            var day = arr[j][3];
//            var insertion = arr[j][4];
//            var mins = arr[j][5];
//            var maxs = arr[j][6];
//            var valuef = arr[j][7];
//            var valuet = arr[j][8];
//            for(var i=0;i<arr.length;i++)
//            {
//                if(i!=j)
//                {
//                    if (valuet = arr[i][8] && valuef == arr[i][7] && maxs == arr[i][6] && mins == arr[i][5] && category == arr[i][0] && hue == arr[i][1] && package == arr[i][2] && day == arr[i][3] && insertion == arr[i][4])
//                    {
//                        alert("Category, Hue, Package, Day, Min Size, Max Size, Value From and Value To should be unique in Print Details.");
//                        return false;
//                    }
//                }
//            }
//        }
    }    
      if(document.getElementById('tblGridelec').rows.length>1)
    {
        var arr=MultiDimensionalArray(document.getElementById('tblGridelec').rows.length-1,4); 
        if(document.getElementById('drpdealon').value=="elec" || document.getElementById('drpdealon').value=="print&ele")
        {
            for(var i=1;i<document.getElementById('tblGridelec').rows.length;i++)
            {
            var channel=document.getElementById('tblGridelec').rows[i].cells[0].innerHTML;
            if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')')); 
            if(channel=="")
            {
                alert("Channel can't be blank in Electronics Details");
                return false;
            } 
            var location=document.getElementById('tblGridelec').rows[i].cells[1].innerHTML;
            if(location.indexOf("(")>0)
            location=location.substring(location.lastIndexOf('(')+1,location.lastIndexOf(')')); 
//            if(location=="")
//            {
//                alert("Location can't be blank in Electronics Details");
//                return false;
//            }

            var progname=document.getElementById('tblGridelec').rows[i].cells[6].innerHTML;
            if(progname.indexOf("(")>0)
            progname=progname.substring(progname.lastIndexOf('(')+1,progname.lastIndexOf(')'));   


            var ratetype=document.getElementById('tblGridelec').rows[i].cells[4].innerHTML;
            if(ratetype.indexOf("(")>0)
            ratetype=ratetype.substring(ratetype.lastIndexOf('(')+1,ratetype.lastIndexOf(')'));
            if(ratetype=="")
            {
                alert("Rate Type can't be blank in Electronics Details");
                return false;
            }
            var advtype=document.getElementById('tblGridelec').rows[i].cells[2].innerHTML;
            if(advtype.indexOf("(")>0)
            advtype=advtype.substring(advtype.lastIndexOf('(')+1,advtype.lastIndexOf(')'));  
            if(advtype=="")
            {
                alert("Adv Type can't be blank in Electronics Details");
                return false;
            }
            var paidbonus=document.getElementById('tblGridelec').rows[i].cells[3].innerHTML;
            if(paidbonus.indexOf("(")>0)
            paidbonus=paidbonus.substring(paidbonus.lastIndexOf('(')+1,paidbonus.lastIndexOf(')'));  
             if(paidbonus=="")
            {
                alert("Paid/Bonus can't be blank in Electronics Details");
                return false;
            }
            var fct=document.getElementById('tblGridelec').rows[i].cells[9].innerHTML;
             if(fct=="")
            {
                alert("FCT/NOI/Words can't be blank in Electronics Details");
                return false;
            }
//             var package1=document.getElementById('tblGridelec').rows[i].cells[10].innerHTML;
//             if(package1.indexOf("(")>0)
//             package1=package1.substring(package1.lastIndexOf('(')+1,package1.lastIndexOf(')')); 
//             if(package1=="")
//            {
//                alert("Package can't be blank in Electronics Details");
//                return false;
//            }
            
             var btb=document.getElementById('tblGridelec').rows[i].cells[5].innerHTML;
             if(btb.indexOf("(")>0)
             btb=btb.substring(btb.lastIndexOf('(')+1,btb.lastIndexOf(')')); 
             if(btb=="")
            {
                alert("BTB can't be blank in Electronics Details");
                return false;
            }
            var valuefrom=document.getElementById('tblGridelec').rows[i].cells[10].innerHTML;
            var valueto=document.getElementById('tblGridelec').rows[i].cells[11].innerHTML; 
            arr[i-1][0]= channel;
            arr[i-1][1]= location;
            arr[i-1][2]= progname;
            arr[i-1][3]= ros;
            arr[i-1][4]= advtype;
            arr[i-1][5]= paidbonus;
            arr[i-1][6]= valuefrom;
            arr[i-1][7]= valueto;
            arr[i-1][8]= btb;
        }
        for(var j=0;j<arr.length;j++)
        {
            var channel=arr[j][0];
            var location=arr[j][1];
            var progname=arr[j][2];
            var ros=arr[j][3];
            var advtype=arr[j][4];
            var paidbonus=arr[j][5];
            var valuefrom=arr[j][6];
            var valueto=arr[j][7]
            var btb=arr[j][8]
            for(var i=0;i<arr.length;i++)
            {
                if(i!=j)
                {
                    if(channel==arr[i][0] && location==arr[i][1] && progname==arr[i][2] && ros==arr[i][3] && advtype==arr[i][4] && paidbonus==arr[i][5] && valuefrom==arr[i][6] && valueto==arr[i][7] && btb==arr[i][8])
                    {
                        alert("Channel, Location, ProgramName, Rate Type, Adv Type, Paid/Bonus, BTB, Value From and Value To should be unique in Electronics Details.");
                        return false;
                    }
                }
            }
        }
        }
    }  
   //return false;
}
function MultiDimensionalArray(iRows,iCols)
{
var i;
var j;
   var a = new Array(iRows);
   for (i=0; i < iRows; i++)
   {
       a[i] = new Array(iCols);
       for (j=0; j < iCols; j++)
       {
           a[i][j] = "";
       }
   }
   return(a);
} 
function saveContractDetails()
{
    if(document.getElementById('tblGrid').rows.length>1)
    {
     if(document.getElementById('drpdealon').value=="print" || document.getElementById('drpdealon').value=="print&ele")
     {
        for(var i=1;i<document.getElementById('tblGrid').rows.length;i++)
        {
            var adtype=document.getElementById('tblGrid').rows[i].cells[0].innerHTML;
            if(adtype.indexOf("(")>0)
                adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));
            if(adtype=="<input style=\"width: 100%;\" type=\"text\">")  
                adtype="";
            var hue=document.getElementById('tblGrid').rows[i].cells[1].innerHTML;
            if(hue.indexOf("(")>0)
                hue=hue.substring(hue.lastIndexOf('(')+1,hue.lastIndexOf(')'));
            if(hue=="<input style=\"width: 100%;\" type=\"text\">")
                hue="";    
            var uom=document.getElementById('tblGrid').rows[i].cells[2].innerHTML;
            if(uom.indexOf("(")>0)
                uom=uom.substring(uom.lastIndexOf('(')+1,uom.lastIndexOf(')'));
            if(uom=="<input style=\"width: 100%;\" type=\"text\">")
                uom="";    
            var package=document.getElementById('tblGrid').rows[i].cells[3].innerHTML;
            if(package.indexOf("(")>0)
                package=package.substring(package.lastIndexOf('(')+1,package.lastIndexOf(')'));
             if(package=="<input style=\"width: 100%;\" type=\"text\">")
                package="";   
            var category=document.getElementById('tblGrid').rows[i].cells[4].innerHTML;
            if(category.indexOf("(")>0)
                category=category.substring(category.lastIndexOf('(')+1,category.lastIndexOf(')'));
            if(category=="<input style=\"width: 100%;\" type=\"text\">")
                category="";    
            var premium=document.getElementById('tblGrid').rows[i].cells[5].innerHTML;
            if(premium.indexOf("(")>0)
                premium=premium.substring(premium.lastIndexOf('(')+1,premium.lastIndexOf(')'));
            if(premium=="<input style=\"width: 100%;\" type=\"text\">")
                premium="";    
            var cardprem=document.getElementById('tblGrid').rows[i].cells[6].innerHTML;
            if(cardprem=="<input style=\"width: 100%;\" type=\"text\">")
                cardprem="";
            var contractprem=document.getElementById('tblGrid').rows[i].cells[7].innerHTML;
            if(contractprem=="<input style=\"width: 100%;\" type=\"text\">")
                contractprem="";
            var contrate=document.getElementById('tblGrid').rows[i].cells[8].innerHTML;
             if(contrate=="<input style=\"width: 100%;\" type=\"text\">")
                contrate="";
            var cardrate=document.getElementById('tblGrid').rows[i].cells[9].innerHTML;
            if(cardrate=="<input style=\"width: 100%;\" type=\"text\">")
                cardrate="";
            var deviation=document.getElementById('tblGrid').rows[i].cells[10].innerHTML;
            if(deviation=="<input style=\"width: 100%;\" type=\"text\">")
                deviation="";
            var disctype=document.getElementById('tblGrid').rows[i].cells[11].innerHTML;
            if(disctype.indexOf("(")>0)
                disctype=disctype.substring(disctype.lastIndexOf('(')+1,disctype.lastIndexOf(')'));
             if(disctype=="<input style=\"width: 100%;\" type=\"text\">")
                disctype="";
            var discper = document.getElementById('tblGrid').rows[i].cells[12].innerHTML;
            
             if(discper=="<input style=\"width: 100%;\" type=\"text\">")
                discper=""; 
            var discon=document.getElementById('tblGrid').rows[i].cells[13].innerHTML;
            if(discon.indexOf("(")>0)
                discon=discon.substring(discon.lastIndexOf('(')+1,discon.lastIndexOf(')'));
            if(discon=="<input style=\"width: 100%;\" type=\"text\">")
                discon="";     
            var minsize=document.getElementById('tblGrid').rows[i].cells[14].innerHTML;
            if(minsize=="<input style=\"width: 100%;\" type=\"text\">")
                minsize="";  
            var maxsize=document.getElementById('tblGrid').rows[i].cells[15].innerHTML;
            if(maxsize=="<input style=\"width: 100%;\" type=\"text\">")
                maxsize="";  
            var valuefrom=document.getElementById('tblGrid').rows[i].cells[16].innerHTML;
            if(valuefrom=="<input style=\"width: 100%;\" type=\"text\">")
                valuefrom="";  
            var valueto=document.getElementById('tblGrid').rows[i].cells[17].innerHTML;
            if(valueto=="<input style=\"width: 100%;\" type=\"text\">")
                valueto="";  
            var day=document.getElementById('tblGrid').rows[i].cells[18].innerHTML;
            if(day=="<input style=\"width: 100%;\" type=\"text\">")
                day=""; 
            var insertion=document.getElementById('tblGrid').rows[i].cells[19].innerHTML;
            if(insertion=="<input style=\"width: 100%;\" type=\"text\">")
                insertion=""; 
             var commallow1=document.getElementById('tblGrid').rows[i].cells[20].innerHTML;
            if(commallow1=='YES')
            {
            commallow='Y';
            }
            else
            {
             var commallow=document.getElementById('tblGrid').rows[i].cells[20].innerHTML;
          
            } if(commallow.indexOf("(")>0)
                commallow=commallow.substring(commallow.lastIndexOf('(')+1,commallow.lastIndexOf(')'));
            if(commallow=="<input style=\"width: 100%;\" type=\"text\">")
                commallow="";     
            var dealstart=document.getElementById('tblGrid').rows[i].cells[21].innerHTML;
            if(dealstart.indexOf("(")>0)
                dealstart=dealstart.substring(dealstart.lastIndexOf('(')+1,dealstart.lastIndexOf(')'));
             if(dealstart=="<input style=\"width: 100%;\" type=\"text\">")
                dealstart="";        
            var currency=document.getElementById('tblGrid').rows[i].cells[22].innerHTML;
            if(currency.indexOf("(")>0)
                currency=currency.substring(currency.lastIndexOf('(')+1,currency.lastIndexOf(')'));
              if(currency=="<input style=\"width: 100%;\" type=\"text\">")
                currency="";            
            var ratecode=document.getElementById('tblGrid').rows[i].cells[23].innerHTML;
            if(ratecode.indexOf("(")>0)
                ratecode=ratecode.substring(ratecode.lastIndexOf('(')+1,ratecode.lastIndexOf(')')); 
            if(ratecode=="<input style=\"width: 100%;\" type=\"text\">")
                ratecode="";           
            var totalrate=document.getElementById('tblGrid').rows[i].cells[24].innerHTML;
              if(totalrate=="<input style=\"width: 100%;\" type=\"text\">")
                totalrate="";    
            var incentive=document.getElementById('tblGrid').rows[i].cells[25].innerHTML;
              if(incentive=="<input style=\"width: 100%;\" type=\"text\">")
                incentive="";  
            var remarks=document.getElementById('tblGrid').rows[i].cells[26].innerHTML;
            if(remarks=="<input style=\"width: 100%;\" type=\"text\">")
                remarks="";  
            var approved=document.getElementById('tblGrid').rows[i].cells[27].innerHTML;
            if(approved.indexOf("(")>0)
                approved=approved.substring(approved.lastIndexOf('(')+1,approved.lastIndexOf(')')); 
             if(approved=="<input style=\"width: 100%;\" type=\"text\">")
                 approved = "";
             var position = document.getElementById('tblGrid').rows[i].cells[28].innerHTML;
             if (position.indexOf("(") > 0)
                 position = position.substring(position.lastIndexOf('(') + 1, position.lastIndexOf(')'));
             if (position == "<input style=\"width: 100%;\" type=\"text\">")
                 position = "";
             var contractamount = document.getElementById('tblGrid').rows[i].cells[29].innerHTML;
             if (contractamount.indexOf("(") > 0)
                 contractamount = contractamount.substring(contractamount.lastIndexOf('(') + 1, contractamount.lastIndexOf(')'));
             if (contractamount == "<input style=\"width: 100%;\" type=\"text\">")
                 contractamount = "";

             var contractpositionprem = document.getElementById('tblGrid').rows[i].cells[30].innerHTML;
             if (contractpositionprem.indexOf("(") > 0)
                 contractpositionprem = contractpositionprem.substring(contractpositionprem.lastIndexOf('(') + 1, contractpositionprem.lastIndexOf(')'));
             if (contractpositionprem == "<input style=\"width: 100%;\" type=\"text\">")
                 contractpositionprem = "";

             var positionpremdisc = document.getElementById('tblGrid').rows[i].cells[31].innerHTML;
             if (positionpremdisc.indexOf("(") > 0)
                 positionpremdisc = positionpremdisc.substring(positionpremdisc.lastIndexOf('(') + 1, positionpremdisc.lastIndexOf(')'));
             if (positionpremdisc == "<input style=\"width: 100%;\" type=\"text\">")
                 positionpremdisc = "";          
                    
            var id=document.getElementById('tblGrid').rows[i].cells[32].innerHTML;
            //<input style=\"width: 100%;\" type=\"text\">
             if(id=="<INPUT style=\"WIDTH: 100%\"" || id=="<input style=\"width: 100%;\" type=\"text\">")
                id="";
            if(id.indexOf("<INPUT")>=0 || id.indexOf("<input")>=0)
            {
                var n = document.getElementById('tblGrid').rows[i].cells[32].innerHTML.substring(document.getElementById('tblGrid').rows[i].cells[28].innerHTML.indexOf('value='));
                if (n.indexOf("<INPUT") >= 0 || n.indexOf("<input")>=0)
                    n = "";
                n=n.replace("value=","");
                 n=n.replace("VALUE=","");
                n=n.replace(">","");
                id=n;
            }
            
            var toinsert=document.getElementById('tblGrid').rows[i].cells[33].innerHTML;
            if (toinsert == "<input style=\"width: 100%;\" type=\"text\">")
                 toinsert = "";
                 
                  var Barter = document.getElementById('tblGrid').rows[i].cells[34].innerHTML;
             if (Barter.indexOf("(") > 0)
                 Barter = Barter.substring(Barter.lastIndexOf('(') + 1, Barter.lastIndexOf(')'));
             if (Barter == "<input style=\"width: 100%;\" type=\"text\">")
                 Barter = "";   
                 
          //  return false;
            if(adtype!="")
                ContractMaster.savecontractdetail_new(document.getElementById('txtdealno').value, adtype, hue, uom, package, category, premium, cardprem, contractprem, contrate, cardrate, deviation, disctype, discper, discon, minsize, maxsize, valuefrom, valueto, day, insertion, commallow, dealstart, currency, ratecode, totalrate, incentive, remarks, approved, document.getElementById('hiddencompcode').value, document.getElementById('hiddenuserid').value, id, position, contractamount, contractpositionprem, positionpremdisc,toinsert,Barter);
        }
        }    
    }
    if(document.getElementById('tblGridelec').rows.length>1)
    {
     if(document.getElementById('drpdealon').value=="elec" || document.getElementById('drpdealon').value=="print&ele")
     {
        for(var i=1;i<document.getElementById('tblGridelec').rows.length;i++)
        {
            var channel=document.getElementById('tblGridelec').rows[i].cells[0].innerHTML;
            if(channel.indexOf("(")>0)
                channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')')); 
            if(channel=="<input style=\"width: 100%;\" type=\"text\">")   
                channel=""; 
            var location=document.getElementById('tblGridelec').rows[i].cells[1].innerHTML;
            if(location.indexOf("(")>0)
                location=location.substring(location.lastIndexOf('(')+1,location.lastIndexOf(')')); 
            if(location=="<input style=\"width: 100%;\" type=\"text\">")   
                location="";     
            var advtype=document.getElementById('tblGridelec').rows[i].cells[2].innerHTML;
            if(advtype.indexOf("(")>0)
                advtype=advtype.substring(advtype.lastIndexOf('(')+1,advtype.lastIndexOf(')')); 
            if(advtype=="<input style=\"width: 100%;\" type=\"text\">")   
                advtype="";      
            var paidbonus=document.getElementById('tblGridelec').rows[i].cells[3].innerHTML;
            if(paidbonus.indexOf("(")>0)
                paidbonus=paidbonus.substring(paidbonus.lastIndexOf('(')+1,paidbonus.lastIndexOf(')'));  
            if(paidbonus=="<input style=\"width: 100%;\" type=\"text\">")   
                paidbonus=""; 
            var ratetype=document.getElementById('tblGridelec').rows[i].cells[4].innerHTML;
            if(ratetype.indexOf("(")>0)
                ratetype=ratetype.substring(ratetype.lastIndexOf('(')+1,ratetype.lastIndexOf(')'));   
             if(ratetype=="<input style=\"width: 100%;\" type=\"text\">")   
                ratetype="";        
            var progname=document.getElementById('tblGridelec').rows[i].cells[6].innerHTML;
            if(progname.indexOf("(")>0)
                progname=progname.substring(progname.lastIndexOf('(')+1,progname.lastIndexOf(')')); 
            if(progname=="<input style=\"width: 100%;\" type=\"text\">")   
                progname="";       
            var btb=document.getElementById('tblGridelec').rows[i].cells[5].innerHTML;
            if(btb.indexOf("(")>0)
                btb=btb.substring(btb.lastIndexOf('(')+1,btb.lastIndexOf(')'));   
            if(btb=="<input style=\"width: 100%;\" type=\"text\">")   
                btb="";      
            var ros=document.getElementById('tblGridelec').rows[i].cells[7].innerHTML;
            if(ros.indexOf("(")>0)
                ros=ros.substring(ros.lastIndexOf('(')+1,ros.lastIndexOf(')'));
            if(ros=="<input style=\"width: 100%;\" type=\"text\">")   
                ros="";     
            var day=document.getElementById('tblGridelec').rows[i].cells[8].innerHTML;
            if(day=="<input style=\"width: 100%;\" type=\"text\">")   
                day=""; 
            var fct=document.getElementById('tblGridelec').rows[i].cells[9].innerHTML;
            if(fct=="<input style=\"width: 100%;\" type=\"text\">")   
                fct=""; 
            var package=document.getElementById('tblGridelec').rows[i].cells[10].innerHTML;
            if(package.indexOf("(")>0)
                package=package.substring(package.lastIndexOf('(')+1,package.lastIndexOf(')'));
            if(package=="<input style=\"width: 100%;\" type=\"text\">")   
                package="";     
            var valuefrom=document.getElementById('tblGridelec').rows[i].cells[11].innerHTML;
            if(valuefrom=="<input style=\"width: 100%;\" type=\"text\">")   
                valuefrom=""; 
            var valueto=document.getElementById('tblGridelec').rows[i].cells[12].innerHTML;
            if(valueto=="<input style=\"width: 100%;\" type=\"text\">")   
                valueto=""; 
            var disctype=document.getElementById('tblGridelec').rows[i].cells[13].innerHTML;
            if(disctype.indexOf("(")>0)
                disctype=disctype.substring(disctype.lastIndexOf('(')+1,disctype.lastIndexOf(')'));
            if(disctype=="<input style=\"width: 100%;\" type=\"text\">")   
                disctype="";     
            var discper=document.getElementById('tblGridelec').rows[i].cells[14].innerHTML;
            if(discper=="<input style=\"width: 100%;\" type=\"text\">")   
                discper=""; 
            var premium=document.getElementById('tblGridelec').rows[i].cells[15].innerHTML;
            if(premium.indexOf("(")>0)
                premium=premium.substring(premium.lastIndexOf('(')+1,premium.lastIndexOf(')'));
            if(premium=="<input style=\"width: 100%;\" type=\"text\">")   
                premium="";     
            var contpremium=document.getElementById('tblGridelec').rows[i].cells[16].innerHTML;
            if(contpremium=="<input style=\"width: 100%;\" type=\"text\">")   
                contpremium=""; 
            var contrate=document.getElementById('tblGridelec').rows[i].cells[17].innerHTML;
            if(contrate=="<input style=\"width: 100%;\" type=\"text\">")   
                contrate=""; 
            var cardrate=document.getElementById('tblGridelec').rows[i].cells[18].innerHTML;
            if(cardrate=="<input style=\"width: 100%;\" type=\"text\">")   
                cardrate=""; 
            var deviation=document.getElementById('tblGridelec').rows[i].cells[19].innerHTML;
            if(deviation=="<input style=\"width: 100%;\" type=\"text\">")   
                deviation=""; 
            var cardprem=document.getElementById('tblGridelec').rows[i].cells[20].innerHTML;
            if(cardprem=="<input style=\"width: 100%;\" type=\"text\">")   
                cardprem=""; 
            var minsize=document.getElementById('tblGridelec').rows[i].cells[21].innerHTML;
            if(minsize=="<input style=\"width: 100%;\" type=\"text\">")   
                minsize=""; 
            var maxsize=document.getElementById('tblGridelec').rows[i].cells[22].innerHTML;
            if(maxsize=="<input style=\"width: 100%;\" type=\"text\">")   
                maxsize=""; 
            var currency=document.getElementById('tblGridelec').rows[i].cells[23].innerHTML;
            if(currency.indexOf("(")>0)
                currency=currency.substring(currency.lastIndexOf('(')+1,currency.lastIndexOf(')'));
            if(currency=="<input style=\"width: 100%;\" type=\"text\">")   
                currency="";     
            var dealstart=document.getElementById('tblGridelec').rows[i].cells[24].innerHTML;
            if(dealstart.indexOf("(")>0)
                dealstart=dealstart.substring(dealstart.lastIndexOf('(')+1,dealstart.lastIndexOf(')'));
            if(dealstart=="<input style=\"width: 100%;\" type=\"text\">")   
                dealstart="";     
            var progtype=document.getElementById('tblGridelec').rows[i].cells[25].innerHTML;
            if(progtype.indexOf("(")>0)
                progtype=progtype.substring(progtype.lastIndexOf('(')+1,progtype.lastIndexOf(')')); 
            if(progtype=="<input style=\"width: 100%;\" type=\"text\">")   
                progtype="";     
            var category=document.getElementById('tblGridelec').rows[i].cells[26].innerHTML;
            if(category.indexOf("(")>0)
                category=category.substring(category.lastIndexOf('(')+1,category.lastIndexOf(')'));  
            if(category=="<input style=\"width: 100%;\" type=\"text\">")   
                category="";     
            var commallow=document.getElementById('tblGridelec').rows[i].cells[27].innerHTML;
            if(commallow.indexOf("(")>0)
                commallow=commallow.substring(commallow.lastIndexOf('(')+1,commallow.lastIndexOf(')'));   
            if(commallow=="<input style=\"width: 100%;\" type=\"text\">")   
                commallow="";     
            var remarks=document.getElementById('tblGridelec').rows[i].cells[28].innerHTML;
            if(remarks=="<input style=\"width: 100%;\" type=\"text\">")   
                remarks=""; 
            var ratecode=document.getElementById('tblGridelec').rows[i].cells[29].innerHTML;
            if(ratecode.indexOf("(")>0)
                ratecode=ratecode.substring(ratecode.lastIndexOf('(')+1,ratecode.lastIndexOf(')'));  
            if(ratecode=="<input style=\"width: 100%;\" type=\"text\">")   
                ratecode="";     
            var discon=document.getElementById('tblGridelec').rows[i].cells[30].innerHTML;
            if(discon.indexOf("(")>0)
                discon=discon.substring(discon.lastIndexOf('(')+1,discon.lastIndexOf(')'));
            if(discon=="<input style=\"width: 100%;\" type=\"text\">")   
                discon="";       
            var sponfrom=document.getElementById('tblGridelec').rows[i].cells[31].innerHTML;
            if(sponfrom=="<input style=\"width: 100%;\" type=\"text\">")   
                sponfrom=""; 
            var sponto=document.getElementById('tblGridelec').rows[i].cells[32].innerHTML;
            if(sponto=="<input style=\"width: 100%;\" type=\"text\">")   
                sponto=""; 
            var source=document.getElementById('tblGridelec').rows[i].cells[33].innerHTML;
             if(source.indexOf("(")>0)
                source=source.substring(source.lastIndexOf('(')+1,source.lastIndexOf(')'));  
            if(source=="<input style=\"width: 100%;\" type=\"text\">")   
                source="";     
            var totalval=document.getElementById('tblGridelec').rows[i].cells[34].innerHTML;
            if(totalval=="<input style=\"width: 100%;\" type=\"text\">")   
                totalval=""; 
            var incentive=document.getElementById('tblGridelec').rows[i].cells[35].innerHTML;
            if(incentive=="<input style=\"width: 100%;\" type=\"text\">")   
                incentive=""; 
            var approved=document.getElementById('tblGridelec').rows[i].cells[36].innerHTML;
            if(approved.indexOf("(")>0)
                approved=approved.substring(approved.lastIndexOf('(')+1,approved.lastIndexOf(')'));  
            if(approved=="<input style=\"width: 100%;\" type=\"text\">")   
                approved="";     
             var id=document.getElementById('tblGridelec').rows[i].cells[41].innerHTML;
             if(id=="<INPUT style=\"WIDTH: 100%\"" || id=="<input style=\"width: 100%;\" type=\"text\">")
                id="";
              if(id.indexOf("<INPUT")>=0  || id.indexOf("<input")>=0)
            {
                var n = document.getElementById('tblGridelec').rows[i].cells[41].innerHTML.substring(document.getElementById('tblGridelec').rows[i].cells[41].innerHTML.indexOf('value='));
                if (n.indexOf("<INPUT") >= 0 || n.indexOf("<input") >= 0)
                    n = "";
                n=n.replace("value=","");
                n=n.replace("VALUE=","");
                n=n.replace(">","");
                id=n;
            }
            // section code
              var sectioncode=document.getElementById('tblGridelec').rows[i].cells[39].innerHTML;
            if(sectioncode.indexOf("(")>0)
                sectioncode=sectioncode.substring(sectioncode.lastIndexOf('(')+1,sectioncode.lastIndexOf(')'));  
            if(sectioncode=="<input style=\"width: 100%;\" type=\"text\">")   
                sectioncode="";     
           // resource no
             var resourceno=document.getElementById('tblGridelec').rows[i].cells[40].innerHTML;
            if(resourceno.indexOf("(")>0)
                resourceno=resourceno.substring(resourceno.lastIndexOf('(')+1,resourceno.lastIndexOf(')'));  
            if(resourceno=="<input style=\"width: 100%;\" type=\"text\">")   
                resourceno="";     
                // for local totvalue value
                  var localtotalval=document.getElementById('tblGridelec').rows[i].cells[42].innerHTML;
            if(localtotalval=="<input style=\"width: 100%;\" type=\"text\">")   
                localtotalval="";  
                // convrsion rate
                   var conversionrate=document.getElementById('tblGridelec').rows[i].cells[43].innerHTML;
            if(conversionrate=="<input style=\"width: 100%;\" type=\"text\">")   
                conversionrate="";   
                
            var reserror=ContractMaster.saveElecDetails(document.getElementById('txtdealno').value,channel,location,advtype,paidbonus,progname,btb,ros,day,fct,package,valuefrom,valueto,disctype,discper,premium,contpremium,contrate,cardrate,deviation,cardprem,minsize,maxsize,currency,dealstart,progtype,category,commallow,remarks,ratecode,discon,sponfrom,sponto,document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('hiddenusername').value,incentive,approved,document.getElementById('hiddencenter').value,i.toString(),id,ratetype,document.getElementById('hiddendateformat').value,source,totalval,sectioncode,resourceno,localtotalval,conversionrate);
            if(reserror.error!=null)
            {
                alert(reserror.error.description);
                return false;
                
            }
            
        }   
       }  
    }
}

function bindGridDetails(dealcode)
{
   var res= ContractMaster.bindGridDetails_Contract(document.getElementById('hiddencompcode').value,document.getElementById('txtdealno').value);
   var ds=res.value;
   if(ds!=null)
   {
    if(ds.Tables[0].Rows.length>0)
    {
        for(var i=0;i<ds.Tables[0].Rows.length;i++)
        {
             element = document.getElementById ('tblGrid');
            if(i>0)
            {
                addRow('', '', '', '', '', '', '0', '0', '0', '0', '0', '', '0', '', '', '', '', '', '', '', 'Yes(Y)', '', document.getElementById('hiddencurrency').value, '', '', '', '', '', '','','','','','','');
            }
            if(ds.Tables[0].Rows[i].ADTYPE!=null)
                document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML=ds.Tables[0].Rows[i].ADTYPE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML="";    
            if(ds.Tables[0].Rows[i].COLOR!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[1].innerHTML=ds.Tables[0].Rows[i].COLOR;
            else
                document.getElementById('tblGrid').rows[i+1].cells[1].innerHTML="";    
            if(ds.Tables[0].Rows[i].UOM!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[2].innerHTML=ds.Tables[0].Rows[i].UOM;
            else
                document.getElementById('tblGrid').rows[i+1].cells[2].innerHTML=""; 
            if(ds.Tables[0].Rows[i].PACKAGECODE!=null)       
                document.getElementById('tblGrid').rows[i+1].cells[3].innerHTML=ds.Tables[0].Rows[i].PACKAGECODE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[3].innerHTML="";    
            if(ds.Tables[0].Rows[i].ADVCATEGORY!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[4].innerHTML=ds.Tables[0].Rows[i].ADVCATEGORY;
            else
                document.getElementById('tblGrid').rows[i+1].cells[4].innerHTML="";    
            if(ds.Tables[0].Rows[i].PREMIUMCODE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[5].innerHTML=ds.Tables[0].Rows[i].PREMIUMCODE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[5].innerHTML="";    
            if(ds.Tables[0].Rows[i].CARDPREMIUM!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[6].innerHTML=ds.Tables[0].Rows[i].CARDPREMIUM;
            else
                document.getElementById('tblGrid').rows[i+1].cells[6].innerHTML="";   
            if(ds.Tables[0].Rows[i].DEALPREMIUM!=null)     
                document.getElementById('tblGrid').rows[i+1].cells[7].innerHTML=ds.Tables[0].Rows[i].DEALPREMIUM;
            else
                document.getElementById('tblGrid').rows[i+1].cells[7].innerHTML="";    
            if(ds.Tables[0].Rows[i].DEALARTE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[8].innerHTML=ds.Tables[0].Rows[i].DEALARTE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[8].innerHTML="";    
            if(ds.Tables[0].Rows[i].CARDRATE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[9].innerHTML=ds.Tables[0].Rows[i].CARDRATE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[9].innerHTML="";    
            if(ds.Tables[0].Rows[i].DEVIATION!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[10].innerHTML=ds.Tables[0].Rows[i].DEVIATION;
            else
                document.getElementById('tblGrid').rows[i+1].cells[10].innerHTML="";    
            if(ds.Tables[0].Rows[i].DISCTYPE!=null)
                document.getElementById('tblGrid').rows[i + 1].cells[11].innerHTML = ds.Tables[0].Rows[i].DISCOUNTED;
            else
                document.getElementById('tblGrid').rows[i+1].cells[11].innerHTML="";   
            if(ds.Tables[0].Rows[i].DISCPER!=null)     
                document.getElementById('tblGrid').rows[i+1].cells[12].innerHTML=ds.Tables[0].Rows[i].DISCPER;
            else
                document.getElementById('tblGrid').rows[i+1].cells[12].innerHTML="";    
            if(ds.Tables[0].Rows[i].DISCOUNTED!=null)
                document.getElementById('tblGrid').rows[i + 1].cells[13].innerHTML = ds.Tables[0].Rows[i].DISCTYPE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[13].innerHTML="";   
            if(ds.Tables[0].Rows[i].SIZEFROM!=null)     
                document.getElementById('tblGrid').rows[i+1].cells[14].innerHTML=ds.Tables[0].Rows[i].SIZEFROM;
            else
                document.getElementById('tblGrid').rows[i+1].cells[14].innerHTML="";    
            if(ds.Tables[0].Rows[i].SIZETO!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[15].innerHTML=ds.Tables[0].Rows[i].SIZETO;
            else
                document.getElementById('tblGrid').rows[i+1].cells[15].innerHTML="";  
            if(ds.Tables[0].Rows[i].VALUEFROM!=null)      
                document.getElementById('tblGrid').rows[i+1].cells[16].innerHTML=ds.Tables[0].Rows[i].VALUEFROM;
            else
                document.getElementById('tblGrid').rows[i+1].cells[16].innerHTML="";   
            if(ds.Tables[0].Rows[i].VALUETO!=null)     
                document.getElementById('tblGrid').rows[i+1].cells[17].innerHTML=ds.Tables[0].Rows[i].VALUETO;
            else
                document.getElementById('tblGrid').rows[i+1].cells[17].innerHTML="";    
            if(ds.Tables[0].Rows[i].DAYNAME!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[18].innerHTML=ds.Tables[0].Rows[i].DAYNAME;
            else
                document.getElementById('tblGrid').rows[i+1].cells[18].innerHTML="";
            if(ds.Tables[0].Rows[i].INSERTION!=null)        
                document.getElementById('tblGrid').rows[i+1].cells[19].innerHTML=ds.Tables[0].Rows[i].INSERTION;
            else
                document.getElementById('tblGrid').rows[i+1].cells[19].innerHTML="";
            if(ds.Tables[0].Rows[i].COMMITION_ALLOW!=null)        
                document.getElementById('tblGrid').rows[i+1].cells[20].innerHTML=ds.Tables[0].Rows[i].COMMITION_ALLOW;
            else
                document.getElementById('tblGrid').rows[i+1].cells[20].innerHTML="";   
            if(ds.Tables[0].Rows[i].DEAL_START!=null)     
                document.getElementById('tblGrid').rows[i+1].cells[21].innerHTML=ds.Tables[0].Rows[i].DEAL_START;
            else
                document.getElementById('tblGrid').rows[i+1].cells[21].innerHTML="";  
            if(ds.Tables[0].Rows[i].CURRENCY!=null)      
                document.getElementById('tblGrid').rows[i+1].cells[22].innerHTML=ds.Tables[0].Rows[i].CURRENCY;
            else
                document.getElementById('tblGrid').rows[i+1].cells[22].innerHTML="";    
            if(ds.Tables[0].Rows[i].RATE_CODE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[23].innerHTML=ds.Tables[0].Rows[i].RATE_CODE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[23].innerHTML="";    
            if(ds.Tables[0].Rows[i].CONVERTRATE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[24].innerHTML=ds.Tables[0].Rows[i].CONVERTRATE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[24].innerHTML="";    
            if(ds.Tables[0].Rows[i].INCENTIVE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[25].innerHTML=ds.Tables[0].Rows[i].INCENTIVE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[25].innerHTML="";    
            if(ds.Tables[0].Rows[i].REMARKS!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[26].innerHTML=ds.Tables[0].Rows[i].REMARKS;
            else
                document.getElementById('tblGrid').rows[i+1].cells[26].innerHTML="";    
            if(ds.Tables[0].Rows[i].APPROVED!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[27].innerHTML=ds.Tables[0].Rows[i].APPROVED;
            else
                document.getElementById('tblGrid').rows[i + 1].cells[27].innerHTML = "";

            if (ds.Tables[0].Rows[i].POSITION_PREM != null)
                document.getElementById('tblGrid').rows[i + 1].cells[28].innerHTML = ds.Tables[0].Rows[i].POSITION_PREM;
            else
                document.getElementById('tblGrid').rows[i + 1].cells[28].innerHTML = "";

            if (ds.Tables[0].Rows[i].CONTRACT_AMOUNT != null)
                document.getElementById('tblGrid').rows[i + 1].cells[29].innerHTML = ds.Tables[0].Rows[i].CONTRACT_AMOUNT;
            else
                document.getElementById('tblGrid').rows[i + 1].cells[29].innerHTML = "";

            if (ds.Tables[0].Rows[i].CONTRACT_POSITION_PREM != null)
                document.getElementById('tblGrid').rows[i + 1].cells[30].innerHTML = ds.Tables[0].Rows[i].CONTRACT_POSITION_PREM;
            else
                document.getElementById('tblGrid').rows[i + 1].cells[30].innerHTML = "";

            if (ds.Tables[0].Rows[i].POSITION_PREM_DISC != null)
                document.getElementById('tblGrid').rows[i + 1].cells[31].innerHTML = ds.Tables[0].Rows[i].POSITION_PREM_DISC;
            else
                document.getElementById('tblGrid').rows[i + 1].cells[31].innerHTML = "";   
           
            if(ds.Tables[0].Rows[i].CONTRACTCODE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[32].innerHTML=ds.Tables[0].Rows[i].CONTRACTCODE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[32].innerHTML=""; 
                
                 if(ds.Tables[0].Rows[i].TOINSERTION!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[33].innerHTML=ds.Tables[0].Rows[i].TOINSERTION;
            else
                document.getElementById('tblGrid').rows[i+1].cells[33].innerHTML=""; 
                
                 if(ds.Tables[0].Rows[i].BARTER!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[34].innerHTML=ds.Tables[0].Rows[i].BARTER;
            else
                document.getElementById('tblGrid').rows[i+1].cells[34].innerHTML="";     
        }
    }
     if(ds.Tables[1].Rows.length>0)
    {
        for(var i=0;i<ds.Tables[1].Rows.length;i++)
        {
             element = document.getElementById ('tblGridelec');
            if(i>0)
            {
                addRow('', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', document.getElementById('hiddencurrency').value, '', '', '', 'Yes(Y)', '', '', '', '', '', '', '', '', '', '', '', '','','','','');
            }
            if(ds.Tables[1].Rows[i].CHANNEL!=null)
                document.getElementById('tblGridelec').rows[i+1].cells[0].innerHTML=ds.Tables[1].Rows[i].CHANNEL;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[0].innerHTML="";    
            if(ds.Tables[1].Rows[i].LOCATION_CODE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[1].innerHTML=ds.Tables[1].Rows[i].LOCATION_CODE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[1].innerHTML="";
            if(ds.Tables[1].Rows[i].AD_TYPE!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[2].innerHTML=ds.Tables[1].Rows[i].AD_TYPE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[2].innerHTML="";
            if(ds.Tables[1].Rows[i].PB_FLG!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[3].innerHTML=ds.Tables[1].Rows[i].PB_FLG;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[3].innerHTML="";    
                
             if(ds.Tables[1].Rows[i].RATE_TYPE!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[4].innerHTML=ds.Tables[1].Rows[i].RATE_TYPE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[4].innerHTML="";   
                    
            if(ds.Tables[1].Rows[i].PRG_CODE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[6].innerHTML=ds.Tables[1].Rows[i].PRG_CODE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[6].innerHTML="";    
            if(ds.Tables[1].Rows[i].BTB_CODE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[5].innerHTML=ds.Tables[1].Rows[i].BTB_CODE;
            else    
                document.getElementById('tblGridelec').rows[i+1].cells[5].innerHTML=""; 
            if(ds.Tables[1].Rows[i].ROS_CODE!=null)
                document.getElementById('tblGridelec').rows[i+1].cells[7].innerHTML=ds.Tables[1].Rows[i].ROS_CODE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[7].innerHTML="";    
            if(ds.Tables[1].Rows[i].DAYS!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[8].innerHTML=ds.Tables[1].Rows[i].DAYS;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[8].innerHTML="";    
            if(ds.Tables[1].Rows[i].NO_OF_INS!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[9].innerHTML=ds.Tables[1].Rows[i].NO_OF_INS;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[9].innerHTML="";    
            if(ds.Tables[1].Rows[i].PACKAGE_CODE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[10].innerHTML=ds.Tables[1].Rows[i].PACKAGE_CODE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[10].innerHTML="";   
            if(ds.Tables[1].Rows[i].VALUE_FROM!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[11].innerHTML=ds.Tables[1].Rows[i].VALUE_FROM;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[11].innerHTML="";
            if(ds.Tables[1].Rows[i].VALUE_TO!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[12].innerHTML=ds.Tables[1].Rows[i].VALUE_TO;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[12].innerHTML="";
            if(ds.Tables[1].Rows[i].DISC_TYPE!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[13].innerHTML=ds.Tables[1].Rows[i].DISC_TYPE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[13].innerHTML="";    
            if(ds.Tables[1].Rows[i].DISC_VAL!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[14].innerHTML=ds.Tables[1].Rows[i].DISC_VAL;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[14].innerHTML="";    
            if(ds.Tables[1].Rows[i].PREM_CODE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[15].innerHTML=ds.Tables[1].Rows[i].PREM_CODE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[15].innerHTML="";
            if(ds.Tables[1].Rows[i].CONTRACT_PREM_VALUE!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[16].innerHTML=ds.Tables[1].Rows[i].CONTRACT_PREM_VALUE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[16].innerHTML="";    
            if(ds.Tables[1].Rows[i].CONTRACT_RATE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[17].innerHTML=ds.Tables[1].Rows[i].CONTRACT_RATE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[17].innerHTML="";    
            if(ds.Tables[1].Rows[i].CARD_RATE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[18].innerHTML=ds.Tables[1].Rows[i].CARD_RATE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[18].innerHTML="";    
            if(ds.Tables[1].Rows[i].DEVIATION_RATE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[19].innerHTML=ds.Tables[1].Rows[i].DEVIATION_RATE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[19].innerHTML="";    
            if(ds.Tables[1].Rows[i].CARD_PREM_VALUE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[20].innerHTML=ds.Tables[1].Rows[i].CARD_PREM_VALUE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[20].innerHTML="";    
            if(ds.Tables[1].Rows[i].MIN_SIZE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[21].innerHTML=ds.Tables[1].Rows[i].MIN_SIZE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[21].innerHTML="";   
            if(ds.Tables[1].Rows[i].MAX_SIZE!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[22].innerHTML=ds.Tables[1].Rows[i].MAX_SIZE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[22].innerHTML="";    
            if(ds.Tables[1].Rows[i].CURRENCY!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[23].innerHTML=ds.Tables[1].Rows[i].CURRENCY;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[23].innerHTML=""; 
            if(ds.Tables[1].Rows[i].DEAL_START!=null)       
                document.getElementById('tblGridelec').rows[i+1].cells[24].innerHTML=ds.Tables[1].Rows[i].DEAL_START;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[24].innerHTML="";    
            if(ds.Tables[1].Rows[i].PRG_TYPE!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[25].innerHTML=ds.Tables[1].Rows[i].PRG_TYPE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[25].innerHTML="";    
            if(ds.Tables[1].Rows[i].AD_CTG!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[26].innerHTML=ds.Tables[1].Rows[i].AD_CTG;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[26].innerHTML="";   
            if(ds.Tables[1].Rows[i].COMM_ALLOW!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[27].innerHTML=ds.Tables[1].Rows[i].COMM_ALLOW;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[27].innerHTML="";  
            if(ds.Tables[1].Rows[i].REMARKS!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[28].innerHTML=ds.Tables[1].Rows[i].REMARKS;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[28].innerHTML="";  
            if(ds.Tables[1].Rows[i].RATE_CODE!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[29].innerHTML=ds.Tables[1].Rows[i].RATE_CODE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[29].innerHTML="";  
            if(ds.Tables[1].Rows[i].DISC_ON!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[30].innerHTML=ds.Tables[1].Rows[i].DISC_ON;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[30].innerHTML="";   
            if(ds.Tables[1].Rows[i].SPN_ST_DT!=null && ds.Tables[1].Rows[i].SPN_ST_DT!='Mon Jan 1 00:00:00 UTC+0530 1900')   
            {
                  var dFrom="";
                 dFrom=ds.Tables[1].Rows[i].SPN_ST_DT;
                 var arr=dFrom.split("/");
                 if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
                 {
                    dFrom=arr[1].toString() + "/" + arr[0].toString() + "/" + arr[2].toString();
                 }
                 else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                 {
                    dFrom=arr[2].toString() + "/" + arr[1].toString() + "/" + arr[0].toString();
                 }  
                document.getElementById('tblGridelec').rows[i+1].cells[31].innerHTML=dFrom;
            }    
            else
                document.getElementById('tblGridelec').rows[i+1].cells[31].innerHTML="";  
            if(ds.Tables[1].Rows[i].SPN_END_DT!=null && ds.Tables[1].Rows[i].SPN_END_DT!='Mon Jan 1 00:00:00 UTC+0530 1900')      
            {
                 var dFrom="";
                 dFrom=ds.Tables[1].Rows[i].SPN_END_DT;
                 var arr=dFrom.split("/");
                 if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
                 {
                    dFrom=arr[1].toString() + "/" + arr[0].toString() + "/" + arr[2].toString();
                 }
                 else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
                 {
                    dFrom=arr[2].toString() + "/" + arr[1].toString() + "/" + arr[0].toString();
                 }
                document.getElementById('tblGridelec').rows[i+1].cells[32].innerHTML=dFrom;
            }    
            else
                document.getElementById('tblGridelec').rows[i+1].cells[32].innerHTML=""; 
                
            if(ds.Tables[1].Rows[i].SOURCE!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[33].innerHTML=ds.Tables[1].Rows[i].SOURCE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[33].innerHTML=""; 
                
                
               if(ds.Tables[1].Rows[i].TOTALVAL!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[34].innerHTML=ds.Tables[1].Rows[i].TOTALVAL;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[34].innerHTML=""; 
                
                       
            if(ds.Tables[1].Rows[i].INCENTIVE!=null)       
                document.getElementById('tblGridelec').rows[i+1].cells[35].innerHTML=ds.Tables[1].Rows[i].INCENTIVE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[35].innerHTML="";   
            if(ds.Tables[1].Rows[i].APPROVED!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[36].innerHTML=ds.Tables[1].Rows[i].APPROVED;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[36].innerHTML="";    
            if(ds.Tables[1].Rows[i].SEQNO!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[41].innerHTML=ds.Tables[1].Rows[i].SEQNO;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[41].innerHTML="";     
                // for sectincode and resourceno
                
                if(ds.Tables[1].Rows[i].SECTIONCODE!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML=ds.Tables[1].Rows[i].SECTIONCODE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML="";     
                
                if(ds.Tables[1].Rows[i].RESOURCE_NO!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[40].innerHTML=ds.Tables[1].Rows[i].RESOURCE_NO;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[40].innerHTML="";     
            
               if(ds.Tables[1].Rows[i].LOCALTOTALVAL!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[42].innerHTML=ds.Tables[1].Rows[i].LOCALTOTALVAL;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[42].innerHTML=""; 
                
                   if(ds.Tables[1].Rows[i].CONVRATE!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[43].innerHTML=ds.Tables[1].Rows[i].CONVRATE;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[43].innerHTML="";     
                
           var channel="";
           if(ds.Tables[1].Rows[i].CHANNEL!=null)
            channel=ds.Tables[1].Rows[i].CHANNEL;          
           if(channel.indexOf("(")>0)
                channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));       
           var location="";
           if(ds.Tables[1].Rows[i].LOCATION_CODE!=null)
            location=ds.Tables[1].Rows[i].LOCATION_CODE;   
           if(location.indexOf("(")>0)
                location=location.substring(location.lastIndexOf('(')+1,location.lastIndexOf(')'));  
           var adtype="";
           if(ds.Tables[1].Rows[i].AD_TYPE!=null)
                adtype=ds.Tables[1].Rows[i].AD_TYPE;
           if(adtype.indexOf("(")>0)
                adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));      
           var btb="";
           if(ds.Tables[1].Rows[i].BTB_CODE!=null)
                btb=ds.Tables[1].Rows[i].BTB_CODE;
           if(btb.indexOf("(")>0)
                btb=btb.substring(btb.lastIndexOf('(')+1,btb.lastIndexOf(')'));      
           var pbflag="";
           if(ds.Tables[1].Rows[i].PB_FLG!=null)
                pbflag=btb,ds.Tables[1].Rows[i].PB_FLG;   
           if(pbflag.indexOf("(")>0)
                pbflag=pbflag.substring(pbflag.lastIndexOf('(')+1,pbflag.lastIndexOf(')'));                 
           var resD=ContractMaster.tv_paid_balance_cal(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value,channel,location,adtype,document.getElementById('txtdealno').value,btb,pbflag);
           var dsD=resD.value;
           if(dsD==null)
           {
            alert(resD.error.description);
            return false;
           }  
           if(dsD.Tables.length>0 && dsD.Tables[0].Rows.length>0)
           {
                if(dsD.Tables[0].Rows[0].vdur!=null)
                    document.getElementById('tblGridelec').rows[i+1].cells[37].innerHTML=dsD.Tables[0].Rows[0].vdur;
                if(dsD.Tables[0].Rows[0].vbal!=null)    
                    document.getElementById('tblGridelec').rows[i+1].cells[38].innerHTML=dsD.Tables[0].Rows[0].vbal;  
           }   
        }
         printTotal();
    }        
   }
   element = document.getElementById ('tblGrid');
   openPrint();
}
function binddatainGrid(Return)
{
            var i=parseInt(activeRow,10)-1;
//              if(Return.hidcurrency_convrate!=null)
//                document.getElementById('hidcurrency_convrate').value=Return.hidcurrency_convrate;
//            else
//                document.getElementById('hidcurrency_convrate').value="";    
             
            if(Return.txtchannel!=null)
                document.getElementById('tblGridelec').rows[i+1].cells[0].innerHTML=Return.txtchannel;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[0].innerHTML="";    

            if(Return.txtlocation!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[1].innerHTML=Return.txtlocation;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[1].innerHTML="";

            if(Return.txtadvtype!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[2].innerHTML=Return.txtadvtype;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[2].innerHTML="";
            
            if(Return.txtpb!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[3].innerHTML=Return.txtpb;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[3].innerHTML="";    
            
             if(Return.txtratetype!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[4].innerHTML=Return.txtratetype;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[4].innerHTML="";   
            
            if(Return.txtprogramname!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[6].innerHTML=Return.txtprogramname;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[6].innerHTML=""; 
            
            if(Return.txtbtb!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[5].innerHTML=Return.txtbtb;
            else    
                document.getElementById('tblGridelec').rows[i+1].cells[5].innerHTML="";
            
            if(Return.txtros!=null)
                document.getElementById('tblGridelec').rows[i+1].cells[7].innerHTML=Return.txtros;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[7].innerHTML="";
            
            if(Return.txtday!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[8].innerHTML=Return.txtday;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[8].innerHTML=""; 
            
            if(Return.txtfct!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[9].innerHTML=Return.txtfct;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[9].innerHTML="";
            
            if(Return.txtpackage!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[10].innerHTML=Return.txtpackage;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[10].innerHTML="";
            
            if(Return.txtvaluefrom!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[11].innerHTML=Return.txtvaluefrom;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[11].innerHTML="";
            
            if(Return.txtvalueto!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[12].innerHTML=Return.txtvalueto;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[12].innerHTML="";
            
            if(Return.txtdisctype!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[13].innerHTML=Return.txtdisctype;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[13].innerHTML="";
            
            if(Return.txtdiscper!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[14].innerHTML=Return.txtdiscper;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[14].innerHTML=""; 
            
            if(Return.txtprem!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[15].innerHTML=Return.txtprem;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[15].innerHTML="";
            
            if(Return.txtcontprem!=null)        
                document.getElementById('tblGridelec').rows[i+1].cells[16].innerHTML=Return.txtcontprem;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[16].innerHTML="";
                
            if(Return.txtcontrate!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[17].innerHTML=Return.txtcontrate;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[17].innerHTML=""; 
            
            if(Return.txtcardrate!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[18].innerHTML=Return.txtcardrate;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[18].innerHTML="";
            
            if(Return.txtdev!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[19].innerHTML=Return.txtdev;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[19].innerHTML="";
            
            if(Return.txtcardprem!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[20].innerHTML=Return.txtcardprem;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[20].innerHTML="";
            
            if(Return.txtminsize!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[21].innerHTML=Return.txtminsize;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[21].innerHTML="";
            
            if(Return.txtmaxsize!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[22].innerHTML=Return.txtmaxsize;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[22].innerHTML="";    
            
            if(Return.txtcurrency!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[23].innerHTML=Return.txtcurrency;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[23].innerHTML="";
            
            if(Return.txtdealstart!=null)       
                document.getElementById('tblGridelec').rows[i+1].cells[24].innerHTML=Return.txtdealstart;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[24].innerHTML="";
                
            if(Return.txtprogtype!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[25].innerHTML=Return.txtprogtype;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[25].innerHTML="";
            
            if(Return.txtcategory!=null)    
                document.getElementById('tblGridelec').rows[i+1].cells[26].innerHTML=Return.txtcategory;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[26].innerHTML="";
            
            if(Return.txtcommallow!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[27].innerHTML=Return.txtcommallow;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[27].innerHTML="";
            
            if(Return.txtremarks!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[28].innerHTML=Return.txtremarks;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[28].innerHTML="";
            
            if(Return.txtratecode!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[29].innerHTML=Return.txtratecode;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[29].innerHTML="";
            
            if(Return.txtdiscon!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[30].innerHTML=Return.txtdiscon;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[30].innerHTML="";
            
            if(Return.txtsponfrom!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[31].innerHTML=Return.txtsponfrom;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[31].innerHTML="";
            
            if(Return.txtsponto!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[32].innerHTML=Return.txtsponto;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[32].innerHTML="";
            
                
            if(Return.txtsource!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[33].innerHTML=Return.txtsource;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[33].innerHTML=""; 
                
            
               if(Return.txttotvalue!=null)      
                document.getElementById('tblGridelec').rows[i+1].cells[34].innerHTML=Return.txttotvalue;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[34].innerHTML=""; 
            
                       
            if(Return.txtincentive!=null)       
                document.getElementById('tblGridelec').rows[i+1].cells[35].innerHTML=Return.txtincentive;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[35].innerHTML="";  
            
            if(Return.txtapproved!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[36].innerHTML=Return.txtapproved;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[36].innerHTML="";    
            
            if(Return.txtconsumed!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[37].innerHTML=Return.txtconsumed;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[37].innerHTML="";    
             
             if(Return.txtsectioncode!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML=Return.txtsectioncode;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML="";    
              
               if(Return.txtresourceno!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[40].innerHTML=Return.txtresourceno;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[40].innerHTML="";  
             
              if(Return.txtlocaltotvalue!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[42].innerHTML=Return.txtlocaltotvalue;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[42].innerHTML="";  
            
               if(Return.hidcurrency_convrate!=null)     
                document.getElementById('tblGridelec').rows[i+1].cells[43].innerHTML=Return.hidcurrency_convrate;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[43].innerHTML="";              
             
                printTotal();
//            if(ds.Tables[1].Rows[i].SEQNO!=null)     
//                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML=ds.Tables[1].Rows[i].SEQNO;
//            else
//                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML=""; 
}
function printTotal()
{
     if(document.getElementById('tblGridelec').rows.length>1)
    {
        var tot=0;
        for(var i=1;i<document.getElementById('tblGridelec').rows.length;i++)
        {
            if(document.getElementById('tblGridelec').rows[i].cells[34].innerHTML!="")
            {
                tot=tot + parseFloat(document.getElementById('tblGridelec').rows[i].cells[34].innerHTML);
            }
        }
        document.getElementById('lblfinalvalue').innerHTML="Total Value: " + tot;
    }    
}
function checkValidAgency()
{
var agency1 = document.getElementById('drpagencycode').value;
if(agency1!="")
{
              if (agency1.indexOf("(".toString()) > 0 && agency1.indexOf(")".toString()) > 0)
                {
                   var myarray1 = agency1.split('(');
                   agency1 = myarray1[1];
                   agency1 = agency1.replace(")", '');
                }
           
               var ds_ag=ContractMaster.chkvalidateintable("agency_mast","Agency_Code",agency1);
               
               if(ds_ag.value.Tables[0].Rows[0].RESULT==0)
               {                
                  var browser=navigator.appName;
                 if(browser=="Microsoft Internet Explorer")
                 {  
                   alert("Please Enter Valid Agency Name");
                 }  
                   document.getElementById('drpagencycode').focus();
                   return false;
               }
}               
}
function checkValidClient()
{
 if(document.getElementById('drpclientname').value!=""){
var agency1 = document.getElementById('drpclientname').value;
    if(document.getElementById('drpclientname').value.lastIndexOf(")")<0)
    {
        if(regclient!="no")
        {
            if(confirm('Do you want to register this client?'))
            {
            var frombooking="2";// 1 from booking 2 from deal
            var clientname=document.getElementById('drpclientname').value;
            window.open('ClientMaster.aspx?frombooking='+frombooking+'&clientname='+clientname,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
            }
        }		    
//    else{        		    
//        if(agency1!="")
//        {
//            if (agency1.indexOf("(".toString()) > 0 && agency1.indexOf(")".toString()) > 0)
//            {
//            var myarray1 = agency1.split('(');
//            agency1 = myarray1[1];
//            agency1 = agency1.replace(")", '');
//            }

//        var ds_ag=ContractMaster.chkvalidateintable("cust_mast","Cust_Code",agency1);

//            if(ds_ag.value.Tables[0].Rows[0].RESULT==0)
//            {      
//            var browser=navigator.appName;
//                if(browser=="Microsoft Internet Explorer")
//                {          
//                alert("Please Enter Valid Client Name");
//                }  
//            document.getElementById('drpclientname').focus();
//            return false;
//            }
//        }   
//    }       
    } 
    }    
}
function checkValidExecutive()
{
var agency1 = document.getElementById('txtexecutive').value;
if(agency1!="")
{
              if (agency1.indexOf("(".toString()) > 0 && agency1.indexOf(")".toString()) > 0)
                {
                   var myarray1 = agency1.split('(');
                   agency1 = myarray1[1];
                   agency1 = agency1.replace(")", '');
                }
           
               var ds_ag=ContractMaster.chkvalidateintable("exec_mast","Exe_no",agency1);
               
               if(ds_ag.value.Tables[0].Rows[0].RESULT==0)
               {       
                      var browser=navigator.appName;
                 if(browser=="Microsoft Internet Explorer")
                 {          
                   alert("Please Enter Valid Executive");
                 }  
                   document.getElementById('txtexecutive').focus();
                   return false;
               }
}               
}
function checkValidRetainer()
{
var agency1 = document.getElementById('txtretainer').value;
if(agency1!="")
{
              if (agency1.indexOf("(".toString()) > 0 && agency1.indexOf(")".toString()) > 0)
                {
                   var myarray1 = agency1.split('(');
                   agency1 = myarray1[1];
                   agency1 = agency1.replace(")", '');
                }
           
               var ds_ag=ContractMaster.chkvalidateintable("retainermaster","Retain_Code",agency1);
               
               if(ds_ag.value.Tables[0].Rows[0].RESULT==0)
               {          
                        var browser=navigator.appName;
                 if(browser=="Microsoft Internet Explorer")
                 {         
                   alert("Please Enter Right Retainer");
                 }  
                   document.getElementById('txtretainer').focus();
                   return false;
               }
}               
}
function checkDateValid()
{
     dateformat=document.getElementById('hiddendateformat').value;
    var fromdate=document.getElementById('txtfromdate').value;
    var todate=document.getElementById('TextBox1').value;
		//this is for from date
		if(fromdate!="" && todate!="")
		{
    if(dateformat=="dd/mm/yyyy")
    {
        if(fromdate != "")
        {
            var txt=fromdate;
            var txt1=txt.split("/");
            var dd=txt1[0];
            var mm=txt1[1];
            var yy=txt1[2];
            fromdate=mm+'/'+dd+'/'+yy;
        }
    }
    else if(dateformat=="yyyy/mm/dd")
    {
        if(fromdate!="")
        {
            var txt=fromdate;
            var txt1=txt.split("/");
            var yy=txt1[0];
            var mm=txt1[1];
            var dd=txt1[2];
            fromdate=mm+'/'+dd+'/'+yy;
        }
    }        
        
    //this is for till date

    if(dateformat=="dd/mm/yyyy")
    {
        if(todate != "")
        {
            var txt=todate;
            var txt1=txt.split("/");
            var dd=txt1[0];
            var mm=txt1[1];
            var yy=txt1[2];
            todate=mm+'/'+dd+'/'+yy;
        }
    
    }
    if(dateformat=="yyyy/mm/dd")
    {
        if(todate!="")
        {
            var txt=todate;
            var txt1=txt.split("/");
            var yy=txt1[0];
            var mm=txt1[1];
            var dd=txt1[2];
            todate=mm+'/'+dd+'/'+yy;
        }
       
    }

	var fdate=new Date(fromdate);
	var tdate=new Date(todate);

  if(fdate > tdate)
    {
        alert("Valid From Date Should Be Less Than Valid To Date");
        document.getElementById('TextBox1').value="";
        document.getElementById('TextBox1').focus();
        return false;
    }
    }
}

function checkmodify() {
  var dealno=   document.getElementById("txtdealno").value;
  var res = ContractMaster.chekmod(document.getElementById('hiddencompcode').value, dealno)
 
  return res;
}


function copyrow(rowNum) {
    var tbody = element.tBodies[0];
    if (!tbody || rowNum < 0) return;

    addTextNodes(rowNum);
//    tbody.childNodes[rowNum].removeNode(true);
    resizeDivs();
}



function addTextNodes(rowNum) {
//    for (var i = 0; t.childNodes[i].length; i++) {
    //        if (!t.childNodes[i].tagName) {
    if (document.getElementById('div_electronics').style.display == "none") {
        element = document.getElementById('tblGrid');
        var j = document.getElementById('tblGrid').rows.length;
        j = j - 1;
        var i = rowNum;

        document.getElementById('tblGrid').rows[j].cells[0].innerHTML = document.getElementById('tblGrid').rows[i].cells[0].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[1].innerHTML = "";



        document.getElementById('tblGrid').rows[j].cells[2].innerHTML = document.getElementById('tblGrid').rows[i].cells[2].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[3].innerHTML ="";



        document.getElementById('tblGrid').rows[j].cells[4].innerHTML = document.getElementById('tblGrid').rows[i].cells[4].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[5].innerHTML = document.getElementById('tblGrid').rows[i].cells[5].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[6].innerHTML = document.getElementById('tblGrid').rows[i].cells[6].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[7].innerHTML = document.getElementById('tblGrid').rows[i].cells[7].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[8].innerHTML = document.getElementById('tblGrid').rows[i].cells[8].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[9].innerHTML = document.getElementById('tblGrid').rows[i].cells[9].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[10].innerHTML = document.getElementById('tblGrid').rows[i].cells[10].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[11].innerHTML = document.getElementById('tblGrid').rows[i].cells[11].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[12].innerHTML = document.getElementById('tblGrid').rows[i].cells[12].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[13].innerHTML = document.getElementById('tblGrid').rows[i].cells[13].innerHTML;


        document.getElementById('tblGrid').rows[j].cells[14].innerHTML = document.getElementById('tblGrid').rows[i].cells[14].innerHTML;


        document.getElementById('tblGrid').rows[j].cells[15].innerHTML = document.getElementById('tblGrid').rows[i].cells[15].innerHTML


        document.getElementById('tblGrid').rows[j].cells[16].innerHTML = document.getElementById('tblGrid').rows[i].cells[16].innerHTML



        document.getElementById('tblGrid').rows[j].cells[17].innerHTML = document.getElementById('tblGrid').rows[i].cells[17].innerHTML;


        document.getElementById('tblGrid').rows[j].cells[18].innerHTML = "";



        document.getElementById('tblGrid').rows[j].cells[19].innerHTML = document.getElementById('tblGrid').rows[i].cells[19].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[20].innerHTML = document.getElementById('tblGrid').rows[i].cells[20].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[21].innerHTML = document.getElementById('tblGrid').rows[i].cells[21].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[22].innerHTML = document.getElementById('tblGrid').rows[i].cells[22].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[23].innerHTML = document.getElementById('tblGrid').rows[i].cells[23].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[24].innerHTML = document.getElementById('tblGrid').rows[i].cells[24].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[25].innerHTML = document.getElementById('tblGrid').rows[i].cells[25].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[26].innerHTML = document.getElementById('tblGrid').rows[i].cells[26].innerHTML;



        document.getElementById('tblGrid').rows[j].cells[27].innerHTML = document.getElementById('tblGrid').rows[i].cells[27].innerHTML;




        document.getElementById('tblGrid').rows[j].cells[28].innerHTML = document.getElementById('tblGrid').rows[i].cells[28].innerHTML;

        document.getElementById('tblGrid').rows[j].cells[29].innerHTML = document.getElementById('tblGrid').rows[i].cells[29].innerHTML;
        document.getElementById('tblGrid').rows[j].cells[30].innerHTML = document.getElementById('tblGrid').rows[i].cells[30].innerHTML;
        document.getElementById('tblGrid').rows[j].cells[31].innerHTML = document.getElementById('tblGrid').rows[i].cells[31].innerHTML;

        document.getElementById('tblGrid').rows[j].cells[32].innerHTML = document.getElementById('tblGrid').rows[i].cells[32].innerHTML;
        document.getElementById('tblGrid').rows[j].cells[33].innerHTML = document.getElementById('tblGrid').rows[i].cells[33].innerHTML;
        document.getElementById('tblGrid').rows[j].cells[34].innerHTML = document.getElementById('tblGrid').rows[i].cells[34].innerHTML;
    }
    else {
        element = document.getElementById('tblGridelec');
        var j = document.getElementById('tblGridelec').rows.length;
        j = j - 1;
        var i = rowNum;

        document.getElementById('tblGridelec').rows[j].cells[0].innerHTML = document.getElementById('tblGridelec').rows[i].cells[0].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[1].innerHTML = document.getElementById('tblGridelec').rows[i].cells[1].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[2].innerHTML = document.getElementById('tblGridelec').rows[i].cells[2].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[3].innerHTML = document.getElementById('tblGridelec').rows[i].cells[3].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[4].innerHTML = document.getElementById('tblGridelec').rows[i].cells[4].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[5].innerHTML = document.getElementById('tblGridelec').rows[i].cells[5].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[6].innerHTML = document.getElementById('tblGridelec').rows[i].cells[6].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[7].innerHTML = document.getElementById('tblGridelec').rows[i].cells[7].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[8].innerHTML = document.getElementById('tblGridelec').rows[i].cells[8].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[9].innerHTML = document.getElementById('tblGridelec').rows[i].cells[9].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[10].innerHTML = document.getElementById('tblGridelec').rows[i].cells[10].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[11].innerHTML = document.getElementById('tblGridelec').rows[i].cells[11].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[12].innerHTML = document.getElementById('tblGridelec').rows[i].cells[12].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[13].innerHTML = document.getElementById('tblGridelec').rows[i].cells[13].innerHTML;


        document.getElementById('tblGridelec').rows[j].cells[14].innerHTML = document.getElementById('tblGridelec').rows[i].cells[14].innerHTML;


        document.getElementById('tblGridelec').rows[j].cells[15].innerHTML = document.getElementById('tblGridelec').rows[i].cells[15].innerHTML


        document.getElementById('tblGridelec').rows[j].cells[16].innerHTML = document.getElementById('tblGridelec').rows[i].cells[16].innerHTML



        document.getElementById('tblGridelec').rows[j].cells[17].innerHTML = document.getElementById('tblGridelec').rows[i].cells[17].innerHTML;


        document.getElementById('tblGridelec').rows[j].cells[18].innerHTML = document.getElementById('tblGridelec').rows[i].cells[18].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[19].innerHTML = document.getElementById('tblGridelec').rows[i].cells[19].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[20].innerHTML = document.getElementById('tblGridelec').rows[i].cells[20].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[21].innerHTML = document.getElementById('tblGridelec').rows[i].cells[21].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[22].innerHTML = document.getElementById('tblGridelec').rows[i].cells[22].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[23].innerHTML = document.getElementById('tblGridelec').rows[i].cells[23].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[24].innerHTML = document.getElementById('tblGridelec').rows[i].cells[24].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[25].innerHTML = document.getElementById('tblGridelec').rows[i].cells[25].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[26].innerHTML = document.getElementById('tblGridelec').rows[i].cells[26].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[27].innerHTML = document.getElementById('tblGridelec').rows[i].cells[27].innerHTML;




        document.getElementById('tblGridelec').rows[j].cells[28].innerHTML = document.getElementById('tblGridelec').rows[i].cells[28].innerHTML;




        document.getElementById('tblGridelec').rows[j].cells[29].innerHTML = document.getElementById('tblGridelec').rows[i].cells[29].innerHTML;



        document.getElementById('tblGridelec').rows[j].cells[30].innerHTML = document.getElementById('tblGridelec').rows[i].cells[30].innerHTML;


        document.getElementById('tblGridelec').rows[j].cells[30].innerHTML = document.getElementById('tblGridelec').rows[i].cells[30].innerHTML;


        document.getElementById('tblGridelec').rows[j].cells[31].innerHTML = document.getElementById('tblGridelec').rows[i].cells[31].innerHTML;

        document.getElementById('tblGridelec').rows[j].cells[32].innerHTML = document.getElementById('tblGridelec').rows[i].cells[32].innerHTML;


        document.getElementById('tblGridelec').rows[j].cells[33].innerHTML = document.getElementById('tblGridelec').rows[i].cells[33].innerHTML;

        document.getElementById('tblGridelec').rows[j].cells[34].innerHTML = document.getElementById('tblGridelec').rows[i].cells[34].innerHTML;

        document.getElementById('tblGridelec').rows[j].cells[35].innerHTML = document.getElementById('tblGridelec').rows[i].cells[35].innerHTML;
        document.getElementById('tblGridelec').rows[j].cells[36].innerHTML = document.getElementById('tblGridelec').rows[i].cells[36].innerHTML;
        document.getElementById('tblGridelec').rows[j].cells[37].innerHTML = document.getElementById('tblGridelec').rows[i].cells[37].innerHTML;
        document.getElementById('tblGridelec').rows[j].cells[38].innerHTML = document.getElementById('tblGridelec').rows[i].cells[38].innerHTML;
        
        
        
        
        
    }
                
//        }
//        else {
//            for (var j = 0; t.childNodes[i].childNodes[j]; j++) {
//                document.getElementById('tblGrid').rows[i + 1].cells[0].innerHTML = document.getElementById('tblGrid').rows[i].cells[0].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[1].innerHTML = document.getElementById('tblGrid').rows[i].cells[1].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[2].innerHTML = document.getElementById('tblGrid').rows[i].cells[2].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[3].innerHTML = document.getElementById('tblGrid').rows[i].cells[3].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[4].innerHTML = document.getElementById('tblGrid').rows[i].cells[4].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[5].innerHTML = document.getElementById('tblGrid').rows[i].cells[5].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[6].innerHTML = document.getElementById('tblGrid').rows[i].cells[6].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[7].innerHTML = document.getElementById('tblGrid').rows[i].cells[7].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[8].innerHTML = document.getElementById('tblGrid').rows[i].cells[8].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[9].innerHTML = document.getElementById('tblGrid').rows[i].cells[9].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[10].innerHTML = document.getElementById('tblGrid').rows[i].cells[10].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[11].innerHTML = document.getElementById('tblGrid').rows[i].cells[11].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[12].innerHTML = document.getElementById('tblGrid').rows[i].cells[12].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[13].innerHTML = document.getElementById('tblGrid').rows[i].cells[13].innerHTML;


//                document.getElementById('tblGrid').rows[i + 1].cells[14].innerHTML = document.getElementById('tblGrid').rows[i].cells[14].innerHTML;


//                document.getElementById('tblGrid').rows[i + 1].cells[15].innerHTML = document.getElementById('tblGrid').rows[i].cells[15].innerHTML


//                document.getElementById('tblGrid').rows[i + 1].cells[16].innerHTML = document.getElementById('tblGrid').rows[i].cells[16].innerHTML



//                document.getElementById('tblGrid').rows[i + 1].cells[17].innerHTML = document.getElementById('tblGrid').rows[i].cells[17].innerHTML;


//                document.getElementById('tblGrid').rows[i + 1].cells[18].innerHTML = document.getElementById('tblGrid').rows[i].cells[18].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[19].innerHTML = document.getElementById('tblGrid').rows[i].cells[19].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[20].innerHTML = document.getElementById('tblGrid').rows[i].cells[20].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[21].innerHTML = document.getElementById('tblGrid').rows[i].cells[21].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[22].innerHTML = document.getElementById('tblGrid').rows[i].cells[22].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[23].innerHTML = document.getElementById('tblGrid').rows[i].cells[23].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[24].innerHTML = document.getElementById('tblGrid').rows[i].cells[24].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[25].innerHTML = document.getElementById('tblGrid').rows[i].cells[25].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[26].innerHTML = document.getElementById('tblGrid').rows[i].cells[26].innerHTML;



//                document.getElementById('tblGrid').rows[i + 1].cells[27].innerHTML = document.getElementById('tblGrid').rows[i].cells[27].innerHTML;




//                document.getElementById('tblGrid').rows[i + 1].cells[28].innerHTML = document.getElementById('tblGrid').rows[i].cells[28].innerHTML;
//            }
//        }
//    }

}

function resizeDivs() {
    for (var i = 0; i < intColCount; i++) {
        var objDiv = element.document.getElementById("DragMark" + (i));
        var objTD = element.tHead.childNodes[0].childNodes[i];

        if ((!objDiv) || (!objTD) || (objTD.tagName != "TD")) return;
        objDiv.style.height = (element.tBodies[0].childNodes.length + 1) * (objTD.offsetHeight - 1);
    }



}



function openattach1() {
//    if (document.getElementById('LinkButton1').disabled == false)
        window.open('approvalAttachment.aspx?filename=' + document.getElementById('hidattach1').value, 'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
    return false;
}


function bindcontract(response) {

    ds = response.value;
    var pkgitem = document.getElementById("Listcontract");
    pkgitem.options.length = 0;
    pkgitem.options[0] = new Option("-Select contract-", "0");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        //alert(pkgitem.options.length);
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].deal_name, ds.Tables[0].Rows[i].deal_name);

            pkgitem.options.length;
        }
    }
    document.getElementById('txtdealname').value = "";
    document.getElementById("Listcontract").value = "0";
    document.getElementById("Listcontract").style.display = "block";
    document.getElementById("Listcontract").focus();  //uncomment

    return false;
}

function can() {

    givebuttonpermission('ContractMaster');
    cancelcontract();
    if (document.getElementById('hddeal').value != "") {
        rownumEx = 0;
        document.getElementById('txtdealno').value = document.getElementById('hddeal').value;
        executeclick();

    }
}

function bindpositionPremCharges(premcode) {
    var res = ContractMaster.pagebindpremium(document.getElementById("hiddencompcode").value, premcode);
    var ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var cardprem = ds.Tables[0].Rows[0].Amount;
    
            document.getElementById('tblGrid').rows[activeRow].cells[30].innerHTML = cardprem;
     
    }
}
function bindpaymentType(agencycode,agencysubcode)
{
 var agencycode1="";
  if(agencycode != "" && agencycode.lastIndexOf('(')>=0)
           {
            var agency=agencycode ;            
	         var agencyarr=agency.split("(");             
	         agencycode1=agencyarr[1];             
	         agencycode1=agencycode1.replace(")","");
	         }
    var res=ContractMaster.getstatuspaymodeAgency(document.getElementById("hiddencompcode").value,agencycode1+agencysubcode);
    var ds=res.value;
            var billobj=document.getElementById('drppaymenttype');
             billobj.options.length = 0; 
             billobj.options[0]=new Option("Select","0");
             billobj.options.length;
     for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                billobj.options[billobj.options.length] = new Option(ds.Tables[0].Rows[i].payment_mode_name,ds.Tables[0].Rows[i].pay_mode_code);
                billobj.options.length;
            }
}
function checkdateforcurr(input)
 {
 var dateformat=document.getElementById('hiddendateformat').value;
 if(dateformat=="mm/dd/yyyy")
 
 {
 var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
 
 }
 if(dateformat=="yyyy/mm/dd")
 
 {
var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
}
if(dateformat=="dd/mm/yyyy")
{
var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
}

if (!validformat.test(input.value))
{
if(input.value=="")
{
return true;
}

alert(" Please Fill The Date In "+dateformat+" Format");

//setTimeout(settime12,15);
daid=input;
//return false;
return;
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
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
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
}

//if ((dayobj.getMonth()+1!=monthfield)||(dayobj.getDate()!=dayfield)||(dayobj.getFullYear()!=yearfield)) 
var abcd= dayobj.getMonth()+1;

var date1=dayobj.getDate();
var year1=dayobj.getFullYear();
if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
{
alert(" Please Fill The Date In "+dateformat+" Format");
input.value="";
return false;
}

  var currdate=document.getElementById('txtcontractdate').value;
  if(dateformat=="yyyy/mm/dd")
{
var yearfield=currdate.split("/")[0]
var monthfield=currdate.split("/")[1]
var dayfield=currdate.split("/")[2]
var currd = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=currdate.split("/")[2]
var monthfield=currdate.split("/")[0]
var dayfield=currdate.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var currd = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=currdate.split("/")[2]
var monthfield=currdate.split("/")[1]
var dayfield=currdate.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var currd = new Date(yearfield, monthfield-1, dayfield)
}
     
        var rodate=new Date(input.value);
        //dayobj is rodate
        if(dayobj>currd)
        {
                alert("Ro date should be less than or equal to current date");
                document.getElementById('txtrodate').focus();
                input.value="";
                 returnval=false;
        }
        else
            returnval=true
 


if (returnval==false) 

input.select()
return returnval

}
function roStatusChange()
{
  var paymode_var='';
for(var n=0;n<document.getElementById('drppaymenttype').options.length;n++)
{
    if(document.getElementById('drppaymenttype').options[n].selected==true)
    {
        if(paymode_var=='')
            paymode_var=document.getElementById('drppaymenttype').options[n].value;
        else
            paymode_var=paymode_var + "," + document.getElementById('drppaymenttype').options[n].value;
                
    }
}
    if(document.getElementById('hiddensepcashier').value='Y' && paymode_var.indexOf("CA0")>=0)
    {
        document.getElementById('drprostatus').value="2";
    }
}

function binddatainGridprint(Return) {
    //var i = parseInt(activeRow, 10) - 1;
    var j = parseInt(activeRow, 10) - 1;
    //              if(Return.hidcurrency_convrate!=null)
    //                document.getElementById('hidcurrency_convrate').value=Return.hidcurrency_convrate;
    //            else
    //                document.getElementById('hidcurrency_convrate').value="";

var len= document.getElementById('tblGrid').rows.length;
    len=len-1;
    var packagesplit=Return.listpackage.split(",");
for(var k=len;k<(len+(packagesplit.length-1));k++)
{ 
//addRow('', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', document.getElementById('hiddencurrency').value, '', '', '', 'Yes(Y)', '', '', '', '', '', '', '', '', '', '', '', '','','','','');
addRow('', '', '', '', '', '', '0', '0', '0', '0', '0', '', '0', '', '', '', '', '', '', '', 'Yes(Y)', '', document.getElementById('hiddencurrency').value, '', '', '', '', '', '','','','','','','');
}

var l=0;
for(var i=len-1;i<(len+(packagesplit.length-1));i++ )
{
 if (Return.txtadtype != null)
        document.getElementById('tblGrid').rows[i + 1].cells[0].innerHTML = Return.txtadtype;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[0].innerHTML = "";
    if (Return.txthue != null)
        document.getElementById('tblGrid').rows[i + 1].cells[1].innerHTML = Return.txthue;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[1].innerHTML = "";
    if (Return.txtumo != null)
        document.getElementById('tblGrid').rows[i + 1].cells[2].innerHTML = Return.txtumo;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[2].innerHTML = "";
    if (Return.listpackage != null)
        document.getElementById('tblGrid').rows[i + 1].cells[3].innerHTML = packagesplit[l];
    else
        document.getElementById('tblGrid').rows[i + 1].cells[3].innerHTML = "";
        
          var validfrom = document.getElementById('txtfromdate').value;

    var validto = document.getElementById('TextBox1').value;

    var compcode = document.getElementById('hiddencompcode').value;

    var dateformat = document.getElementById('hiddendateformat').value;
    var pkgcode=packagesplit[l];
     if (pkgcode.indexOf("(") > 0)
            pkgcode = pkgcode.substring(pkgcode.lastIndexOf('(') + 1, pkgcode.lastIndexOf(')'));
    var adtype=Return.txtadtype;
     if (adtype.indexOf("(") > 0)
            adtype = adtype.substring(adtype.lastIndexOf('(') + 1, adtype.lastIndexOf(')'));
    var umo =Return.txtumo;
     if (umo.indexOf("(") > 0)
            umo = umo.substring(umo.lastIndexOf('(') + 1, umo.lastIndexOf(')'));
        // var category = document.getElementById('txtcategory').value;
    var currency= Return.txtcurrency;
//    if (currency.indexOf("(") > 0)
//            currency = currency.substring(currency.lastIndexOf('(') + 1, currency.lastIndexOf(')'));
         var category = Return.txtcategory;
        if (category.indexOf("(") > 0)
            category = category.substring(category.lastIndexOf('(') + 1, category.lastIndexOf(')'));
    
        var rate_Code = Return.txtratecode;
        if (rate_Code.indexOf("(") > 0)
            rate_Code = rate_Code.substring(rate_Code.lastIndexOf('(') + 1, rate_Code.lastIndexOf(')'));
            
     var hue = Return.txthue;
     if (hue.indexOf("(") > 0)
        hue = hue.substring(hue.lastIndexOf('(') + 1, hue.lastIndexOf(')'));
    var res = ContractMaster.getrateforcontract_detail(category, pkgcode, hue, currency, umo,adtype, validfrom, validto, compcode, dateformat,rate_Code)
    var ds2 = res.value;
    if (res.value != null && res.value != "" && ds2.Tables.length>0 && ds2.Tables[0].Rows.length>0) {
        var cardrate = ds2.Tables[0].Rows[0].Week_Day_Rate;

}

//    if (Return.txtadtype != null)
//        document.getElementById('tblGrid').rows[i + 1].cells[0].innerHTML = Return.txtadtype;
//    else
//        document.getElementById('tblGrid').rows[i + 1].cells[0].innerHTML = "";
//    if (Return.txthue != null)
//        document.getElementById('tblGrid').rows[i + 1].cells[1].innerHTML = Return.txthue;
//    else
//        document.getElementById('tblGrid').rows[i + 1].cells[1].innerHTML = "";
//    if (Return.txtumo != null)
//        document.getElementById('tblGrid').rows[i + 1].cells[2].innerHTML = Return.txtumo;
//    else
//        document.getElementById('tblGrid').rows[i + 1].cells[2].innerHTML = "";
//    if (Return.listpackage != null)
//        document.getElementById('tblGrid').rows[i + 1].cells[3].innerHTML = Return.listpackage;
//    else
//        document.getElementById('tblGrid').rows[i + 1].cells[3].innerHTML = "";

    if (Return.txtcategory != null)
        document.getElementById('tblGrid').rows[i + 1].cells[4].innerHTML = Return.txtcategory;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[4].innerHTML = "";

    if (Return.txtcardprem != null)
        document.getElementById('tblGrid').rows[i + 1].cells[6].innerHTML = Return.txtcardprem;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[6].innerHTML = "";
    if (Return.txtpremium != null)
        document.getElementById('tblGrid').rows[i + 1].cells[5].innerHTML = Return.txtpremium;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[5].innerHTML = "";
    if (Return.txtcontractperm != null)
        document.getElementById('tblGrid').rows[i + 1].cells[7].innerHTML = Return.txtcontractperm;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[7].innerHTML = "";
    if (Return.txtcontractrate != null)
        document.getElementById('tblGrid').rows[i + 1].cells[8].innerHTML =  Return.txtcontractrate;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[8].innerHTML = "";
        
         var contractrate = Return.txtcontractrate;
   
    if(contractrate=="")
    {
    contractrate="0";
    }
   
    if (contractrate != "" || cardrate != "") {
        var dev = parseFloat(cardrate) - parseFloat(contractrate);
        if(dev!=cardrate)
        {
        var res=  ContractMaster.chk_null(dev)
        var deviation =res.value;
        }
        else    
        {
         var deviation ="0";
        }
      
      
      
    }
        
    if (Return.txtcardrate != null)
        document.getElementById('tblGrid').rows[i + 1].cells[9].innerHTML = Return.txtcardrate;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[9].innerHTML = "";
    if (Return.txtdeviation != null)
        document.getElementById('tblGrid').rows[i + 1].cells[10].innerHTML =deviation // Return.txtdeviation;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[10].innerHTML = "";
    if (Return.txtdisctype != null)
        document.getElementById('tblGrid').rows[i + 1].cells[11].innerHTML = Return.txtdisctype;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[11].innerHTML = "";
    if (Return.txtdiscper != null)
        document.getElementById('tblGrid').rows[i + 1].cells[12].innerHTML = Return.txtdiscper;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[12].innerHTML = "";
    if (Return.txtdiscon != null)
        document.getElementById('tblGrid').rows[i + 1].cells[13].innerHTML = Return.txtdiscon;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[13].innerHTML = "";
    if (Return.txtminsize != null)
        document.getElementById('tblGrid').rows[i + 1].cells[14].innerHTML = Return.txtminsize;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[14].innerHTML = "";
    if (Return.txtmaxsize != null)
        document.getElementById('tblGrid').rows[i + 1].cells[15].innerHTML = Return.txtmaxsize;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[15].innerHTML = "";
    if (Return.txtvaluefrom != null)
        document.getElementById('tblGrid').rows[i + 1].cells[16].innerHTML = Return.txtvaluefrom;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[16].innerHTML = "";
    if (Return.txtvalueto != null)
        document.getElementById('tblGrid').rows[i + 1].cells[17].innerHTML = Return.txtvalueto;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[17].innerHTML = "";
    if (Return.txtday != null)
        document.getElementById('tblGrid').rows[i + 1].cells[18].innerHTML = Return.txtday;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[18].innerHTML = "";
    if (Return.txtinsertion != null)
        document.getElementById('tblGrid').rows[i + 1].cells[19].innerHTML = Return.txtinsertion;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[19].innerHTML = "";
    if (Return.txtcomallow != null)
        document.getElementById('tblGrid').rows[i + 1].cells[20].innerHTML = Return.txtcomallow;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[20].innerHTML = "";
    if (Return.txtdealstart != null)
        document.getElementById('tblGrid').rows[i + 1].cells[21].innerHTML = Return.txtdealstart;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[21].innerHTML = "";
    if (Return.txtcurrency != null)
        document.getElementById('tblGrid').rows[i + 1].cells[22].innerHTML = Return.txtcurrency;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[22].innerHTML = "";
    if (Return.txtratecode != null)
        document.getElementById('tblGrid').rows[i + 1].cells[23].innerHTML = Return.txtratecode;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[23].innerHTML = "";
    if (Return.txttotalrate != null)
        document.getElementById('tblGrid').rows[i + 1].cells[24].innerHTML = Return.txttotalrate;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[24].innerHTML = "";
    if (Return.txtincentive != null)
        document.getElementById('tblGrid').rows[i + 1].cells[25].innerHTML = Return.txtincentive;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[25].innerHTML = "";
    if (Return.txtremarks != null)
        document.getElementById('tblGrid').rows[i + 1].cells[26].innerHTML = Return.txtremarks;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[26].innerHTML = "";
    if (Return.txtstatus != null)
        document.getElementById('tblGrid').rows[i + 1].cells[27].innerHTML = Return.txtstatus;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[27].innerHTML = "";
    if (Return.txtpositiomprem != null)
        document.getElementById('tblGrid').rows[i + 1].cells[28].innerHTML = Return.txtpositiomprem;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[28].innerHTML = "";
    if (Return.txtcontractamount != null)
        document.getElementById('tblGrid').rows[i + 1].cells[29].innerHTML = Return.txtcontractamount;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[29].innerHTML = "";
    if (Return.txtcardpositionprem != null)
        document.getElementById('tblGrid').rows[i + 1].cells[30].innerHTML = Return.txtcardpositionprem;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[30].innerHTML = "";
    if (Return.txtcontarctpositionprem != null)
        document.getElementById('tblGrid').rows[i + 1].cells[31].innerHTML = Return.txtcontarctpositionprem;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[31].innerHTML = "";
  
    if (Return.txtinsert != null)
        document.getElementById('tblGrid').rows[i + 1].cells[33].innerHTML = Return.txtinsert;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[33].innerHTML = "";
  
    if (Return.txtbarter != null)
        document.getElementById('tblGrid').rows[i + 1].cells[34].innerHTML = Return.txtbarter;
    else
        document.getElementById('tblGrid').rows[i + 1].cells[34].innerHTML = "";
l++
  
}
    //            if(ds.Tables[1].Rows[i].SEQNO!=null)     
    //                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML=ds.Tables[1].Rows[i].SEQNO;
    //            else
    //                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML="";
}


function openprint() {
    document.getElementById('divprint').style.display = "block";
    document.getElementById('div_electronics').style.display = "none";
    document.getElementById('an_print').className = "selected";
    document.getElementById('an_elec').className = "";
    document.getElementById('an_web').className = "";
    tableName = 'tblGrid';
    if (document.getElementById)
        element = document.getElementById(tableName);
    else  //TODO: Need to test this piece of code still. Happens only in NN4 so far 
        eval(element = "document." + tableName);
    return false;
}

function openfont() {

hiddentext="mod"
    if (document.getElementById('lblfont').disabled== true) {
        return false;
    }

    if (document.getElementById('txtdealno').value == "") {

        alert("Please Enter Deal Code");
        return false;
    }
    var editioncode = document.getElementById('txtdealno').value;
    dealno=document.getElementById('txtdealno').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var show="2";
    if (hiddentext == "mod") 
    {
        popwin1=window.open('dealmarketstatus.aspx?compcode='+compcode+'&editioncode=' + editioncode+'&hiddentext='+hiddentext+'&show='+show,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=500px');
        popwin1.focus();

    }
    else {
        popwin1=window.open('dealmarketstatus.aspx?compcode='+compcode+'&editioncode=' + editioncode+'&hiddentext='+hiddentext+' &show='+show,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=500px');
        popwin1.focus();
    }


    return false;
}


function submitclick()
{
////this is to chk the periodicity





        var page;
        var edition="";
        var date1="";
        var date2="";
        var date3="";
        var ds="";

	
if(edinsert!="1" && edinsert!=null)
{
//dealmarketstatus.chkinsert(txteditionname,txtdate,txtaddate,compcode,userid,editcode,call_insert);
if((document.getElementById('DataGrid1'))!=null  )
{
//if(document.getElementById('DataGrid1').rows.length==1)
//{
//    alert('Single row should de inserted.');
//    return false;
//    }
} 
        var page="";
        var edition1=document.getElementById('hiddendealno').value;
        var date1="";
        var date2="";
        var date3="";
      //  var year="";
          var id;

		var compcode=document.getElementById('hiddencompcode').value;
		var pubcent=document.getElementById('txtpubcenter').value;
	var publication=document.getElementById('txtpub').value;
	var marketstatus=document.getElementById('txtmarstatus').value;
	 if(document.getElementById('htext').value=="mod")
	 {
	    var compcode=document.getElementById('hiddencompcode').value; 
            var userid=document.getElementById('hiddenuserid').value; 
            var dateformat=document.getElementById('hiddendateformat').value; 
            var editcode=document.getElementById('hiddendealno').value; 
            
            var pubcent=document.getElementById('txtpubcenter').value;
	var publication=document.getElementById('txtpub').value;
	var marketstatus=document.getElementById('txtmarstatus').value;
	
	
	opener.document.getElementById('hiddeneditdate').value=pubcent;
    opener.document.getElementById('hiddeneditaddate').value=publication;
    opener.document.getElementById('hiddenedityear').value=marketstatus;

 dealmarketstatus.insert(compcode,editcode,pubcent,publication,marketstatus,"","");		

//document.getElementById('txteditionname').value="";
document.getElementById('txtpubcenter').value="";
document.getElementById('txtpub').value="";
document.getElementById('txtmarstatus').value="";
window.location=window.location
        
        //dealmarketstatus.insert(compcode,edition1,pubcent,publication,marketstatus,"","");
	    //dealmarketstatus.chkinsert(compcode,edition1,pubcent,publication,marketstatus,call_insert);
	 
   	 //window.location=window.location;
   	  return false;

	// return ;
	 }
      
      else
   	{
	//opener.document.getElementById('hiddeneditalias').value=txteditionname;
	document.getElementById('hiddeneditdate').value=pubcent;
    document.getElementById('hiddeneditaddate').value=publication;
    document.getElementById('hiddenedityear').value=marketstatus;
 
return;
	}

}
else
{
//opener.document.getElementById('hiddeneditalias').value=txteditionname;
opener.document.getElementById('hiddeneditdate').value=pubcent;
opener.document.getElementById('hiddeneditaddate').value=publication;
opener.document.getElementById('hiddenedityear').value=marketstatus;

var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var editcode=document.getElementById('hiddendealno').value;
 var pubcent=document.getElementById('txtpubcenter').value;
	var publication=document.getElementById('txtpub').value;
	var marketstatus=document.getElementById('txtmarstatus').value;


dealmarketstatus.update(compcode,editcode,pubcent,publication,marketstatus);	
window.location=window.location
return false;
//dealmarketstatus.chkinsert(compcode,editcode,pubcent,publication,marketstatus,code10,call_update);

//dealmarketstatus.update(txteditionname,txtdate,txtaddate,compcode,userid,editcode,code10);
document.getElementById('btndelete').disabled=true;
edinsert="0";


}



return false;

}

function selectclick(ab)
{
var id=ab;
if(document.getElementById(id).checked==false)
{

document.getElementById('txtpubcenter').value="0";
document.getElementById('txtpub').value="0";
document.getElementById('txtmarstatus').value="";


document.getElementById('btndelete').disabled=true;
document.getElementById('btnsubmit').disabled=true;
document.getElementById(id).checked=false;

return;
}
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
var editcode=document.getElementById('hiddendealno').value;

var j;
var k=0;

var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{

	var str="DataGrid1__ctl_CheckBox1"+j;
	document.getElementById(str).checked=false;
    document.getElementById(id).checked=true;

     if(id==str)
        {
	if(document.getElementById(id).checked==true)
	{
	k=k+1;

	code10=document.getElementById(str).value;
	chk123=document.getElementById(id);
	}
	}
	}
	if(k==1)
	{
    if(document.getElementById('hiddenshow').value=="1")
	    {
	    document.getElementById('btndelete').disabled=false;
	    document.getElementById('btnsubmit').disabled=false;
	    }
	dealmarketstatus.selected(editcode,compcode,userid,code10,call_select12);
	
	}
	else if(k==0)
	{
document.getElementById('txtpubcenter').value="";
document.getElementById('txtpub').value="";
document.getElementById('txtmarstatus').value="";
	
	return false;
	}
	document.getElementById(ab).checked=true;
	

}










function call_select12(response)
{
var ds=response.value;
edinsert="1";
//var txteditionname=document.getElementById('txteditionname').value=ds.Tables[0].Rows[0].Edition_Alias;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var pubcent=ds.Tables[0].Rows[0].PUBCENTER;
var pub=ds.Tables[0].Rows[0].PUBLICATION;
document.getElementById('txtpubcenter').value=pubcent;
document.getElementById('txtpub').value=pub;

document.getElementById('txtmarstatus').value=ds.Tables[0].Rows[0].MARKET_STATUS;



return false;
}

function deletegridclick()
{

var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var editcode=document.getElementById('hiddendealno').value;
//if(document.getElementById('DataGrid1').rows.length-1==1)
//{
//    alert('One row should be present here');
//    return false;
//} 

 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
           if (httpRequest.readyState == 4) 
            {
                
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                   
                    if(browser!="Microsoft Internet Explorer")
                    {
                        
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
dealmarketstatus.deletegrid(compcode,editcode,userid,code10);
document.getElementById('txtpubcenter').enabled=true;
document.getElementById('txtpub').enabled=true;
document.getElementById('txtmarstatus').enabled=true;




window.location=window.location;
return false;
}

//********************************************************
function clearclick()
{
document.getElementById('txtpubcenter').value="0";
document.getElementById('txtpub').value="0";
document.getElementById('txtmarstatus').value="";


return false;
}



function call_insert(response)
{

var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("Issue Date has already been assigned ");
	return false;
	}
	else
		{
            //var txteditionname=document.getElementById('txteditionname').value;
            var compcode=document.getElementById('hiddencompcode').value; 
            var userid=document.getElementById('hiddenuserid').value; 
            var dateformat=document.getElementById('hiddendateformat').value; 
            var editcode=document.getElementById('txtdealno').value; 
            
            var pubcent=document.getElementById('txtpubcenter').value;
	var publication=document.getElementById('txtpub').value;
	var marketstatus=document.getElementById('txtmarstatus').value;
	
	
	opener.document.getElementById('hiddeneditdate').value=pubcent;
    opener.document.getElementById('hiddeneditaddate').value=publication;
    opener.document.getElementById('hiddenedityear').value=marketstatus;

 dealmarketstatus.insert(compcode,editcode,pubcent,publication,marketstatus,"","");		

//document.getElementById('txteditionname').value="";
document.getElementById('txtpubcenter').value="";
document.getElementById('txtpub').value="";
document.getElementById('txtmarstatus').value="";
window.location=window.location
    }

		return false;
}

function call_update(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("This Date Has Been Assigned");
	return false;
	}
	else
		{
//var txteditionname=document.getElementById('txteditionname').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var editcode=trim(document.getElementById('txtdealno').value);
 var pubcent=document.getElementById('txtpubcenter').value;
	var publication=document.getElementById('txtpub').value;
	var marketstatus=document.getElementById('txtmarstatus').value;


dealmarketstatus.update(compcode,userid,editcode,pubcent,publication,marketstatus,code10);	
		}
		window.location=window.location
		return false;
}


function fillpubcent(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode != 13) {
        if (document.activeElement.id == "txtpubcenter") {
            document.getElementById('txtpubcenter').value = "";
        }

    }
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtpubcenter") {
            var aTag = eval(document.getElementById('txtpubcenter'))
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

            var tot = document.getElementById('div1').scrollLeft;

            var scrolltop = document.getElementById('div1').scrollTop;
            document.getElementById('div1').style.display = "block";
            document.getElementById('div1').style.left = document.getElementById('hdnpubcent').offsetLeft + leftpos - tot + "px";
            document.getElementById('div1').style.top = document.getElementById('hdnpubcent').offsetTop + toppos - scrolltop + "px";
            document.getElementById('lstpubcent').focus();
            var compcode = document.getElementById('hiddencompcode').value;
            var extra1 = document.getElementById('txtpubcenter').value.toUpperCase();
            var chargetypecode = document.getElementById('hiddenuserid').value.toUpperCase();
            dealmarketstatus.fill_pubcent(compcode, chargetypecode, "", extra1, "", bindchargecode_callback);
        }

        return event.keyCode;
    }


}

function bindchargecode_callback(response) {

    var ds = response.value;
    var pkgitem = document.getElementById("lstpubcent");
    if (ds == null) {
        pkgitem.style.width = "254px"
        pkgitem.options.length = 0;
    }
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        pkgitem.style.width = "254px"
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select pub cent Type-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Pub_cent_Code + "~" + ds.Tables[0].Rows[i].CENTER, ds.Tables[0].Rows[i].Pub_cent_Code);
            pkgitem.options.length;

        }

    }
    document.getElementById('hdnpubcent').value = "";
    document.getElementById('txtpubcenter').value = "";
    document.getElementById("lstpubcent").value = "0";
    document.getElementById("lstpubcent").focus();
    return false;
}
function fillpubcenter(event) {
    var browser = navigator.appName;
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstpubcent") {
            if (document.getElementById('lstpubcent').value == "0") {
                alert("Please select the Pub Center");
                return false;
            }
            document.getElementById("div1").style.display = "none";
            var page = document.getElementById('lstpubcent').value;
            agencycodeglo = page;
            for (var k = 0; k <= document.getElementById("lstpubcent").length - 1; k++) {

                if (document.getElementById('lstpubcent').options[k].value == page) {
                    var abc;
                    if (browser != "Microsoft Internet Explorer") {
                        abc = document.getElementById('lstpubcent').options[k].textContent;
                    }
                    else {
                        abc = document.getElementById('lstpubcent').options[k].innerText;
                    }

                   // document.getElementById('txtmaingrname').value = agencycodeglo;
                    var splitpub = abc;
                    var str = splitpub.split("~");
                    var ab = str[1];
                    var ab1= str[0];


                    document.getElementById('hdnpubcent').value = ab1;
                    document.getElementById('txtpubcenter').value = ab;
                    document.getElementById("txtpub").focus();
                    return false;

                }


            }

        }
    }

    else if (event.keyCode == 27) {
    document.getElementById("div1").style.display = 'none';
    document.getElementById("txtpubcenter").focus();

    }
}

function fillpub(event) {
    var keycode = event.keyCode ? event.keyCode : event.which;
    if (keycode != 13) {
        if (document.activeElement.id == "txtpub") {
            document.getElementById('txtpub').value = "";
        }

    }
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtpub") {
            var aTag = eval(document.getElementById('txtpub'))
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

            var tot = document.getElementById('div2').scrollLeft;

            var scrolltop = document.getElementById('div2').scrollTop;
            document.getElementById('div2').style.display = "block";
            document.getElementById('div2').style.left = document.getElementById('hdnpub').offsetLeft + leftpos - tot + "px";
            document.getElementById('div2').style.top = document.getElementById('hdnpub').offsetTop + toppos - scrolltop + "px";
            document.getElementById('lstpub').focus();
            var compcode = document.getElementById('hiddencompcode').value;
            var extra1 = "";
            var chargetypecode = document.getElementById('hdnpubcent').value.toUpperCase();
            dealmarketstatus.fill_pub(compcode, chargetypecode, "", extra1, "", bindchargecode1_callback);
        }

        return event.keyCode;
    }


}

function bindchargecode1_callback(response) {

    var ds = response.value;
    var pkgitem = document.getElementById("lstpub");
    if (ds == null) {
        pkgitem.style.width = "254px"
        pkgitem.options.length = 0;
    }
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


        pkgitem.style.width = "254px"
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Publication-", "0");
        pkgitem.options.length = 1;

        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Pub_Code + "~" + ds.Tables[0].Rows[i].Pub_Name, ds.Tables[0].Rows[i].Pub_Code);
            pkgitem.options.length;

        }

    }
    document.getElementById('hdnpub').value = "";
    document.getElementById('txtpub').value = "";
    document.getElementById("lstpub").value = "0";
    document.getElementById("lstpub").focus();
    return false;
}


function fillpublication(event) {
    var browser = navigator.appName;
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstpub") {
            if (document.getElementById('lstpub').value == "0") {
                alert("Please select the Main Asset Cat");
                return false;
            }
            document.getElementById("div2").style.display = "none";
            var page = document.getElementById('lstpub').value;
            agencycodeglo = page;
            for (var k = 0; k <= document.getElementById("lstpub").length - 1; k++) {

                if (document.getElementById('lstpub').options[k].value == page) {
                    var abc;
                    if (browser != "Microsoft Internet Explorer") {
                        abc = document.getElementById('lstpub').options[k].textContent;
                    }
                    else {
                        abc = document.getElementById('lstpub').options[k].innerText;
                    }

                   // document.getElementById('txtmaingrname').value = agencycodeglo;
                    var splitpub = abc;
                    var str = splitpub.split("~");
                    var ab = str[1];
                    var ab1= str[0];


                    document.getElementById('hdnpub').value = ab1;
                    document.getElementById('txtpub').value = ab;
                    document.getElementById("txtmarstatus").focus();
                    return false;

                }


            }

        }
    }

    else if (event.keyCode == 27) {
    document.getElementById("div2").style.display = 'none';
    document.getElementById("txtpub").focus();

    }
}