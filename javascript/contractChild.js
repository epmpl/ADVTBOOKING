var colName="";
function checkValidField(id,field)
{
    if(document.getElementById(id).value!="" && (document.getElementById(id).value.indexOf("(")<0 || document.getElementById(id).value.indexOf(")")<0))
    {
        alert("Please Enter Valid "+ field);
        document.getElementById(id).focus();
        return false;
    }
}
function setData(event)
{

    if(document.getElementById('txtchannel').value=="")
    {
        alert("Please Enter Channel");
        document.getElementById('txtchannel').focus();
        return false;
    }
      else if(document.getElementById('txtpb').value=="")
    {
        alert("Please Enter Paid/Bonus");
        document.getElementById('txtpb').focus();
        return false;
    }
//    else if(document.getElementById('txtpackage').value=="")
//    {
//        alert("Please Enter Package");
//        document.getElementById('txtpackage').focus();
//        return false;
//    }
    else if(document.getElementById('txtadvtype').value=="")
    {
        alert("Please Enter Adv Type");
        document.getElementById('txtadvtype').focus();
        return false;
    }
    else if(document.getElementById('txtbtb').value=="")
    {
        alert("Please Enter BTB");
        document.getElementById('txtbtb').focus();
        return false;
    }
    else if(document.getElementById('txtratetype').value=="")
    {
        alert("Please Enter Rate Type");
        document.getElementById('txtratetype').focus();
        return false;
    }
     else if(document.getElementById('txtfct').value=="")
    {
        alert("Please Enter FCT/NOI/Words");
        document.getElementById('txtfct').focus();
        return false;
    }
  
    else if(document.getElementById('txtcurrency').value=="")
    {
        alert("Please Enter Currency");
        document.getElementById('txtcurrency').focus();
        return false;
    }
     var alrt;
       // for sectioncode
     alrt=document.getElementById('lblsectioncode').innerHTML;
   
    if(alrt.indexOf('*')>=0)
    {
   
 if(document.getElementById('txtsectioncode').value=="")
    {
        alert("Please Enter Section Code");
        document.getElementById('txtsectioncode').focus();
        return false;       
    }
    }
    // for resource No
       // for sectioncode
     alrt=document.getElementById('lblresourceno').innerHTML;
   
    if(alrt.indexOf('*')>=0)
    {
   
    if(document.getElementById('txtresourceno').value=="")
    {
        alert("Please Enter Resource No");
        document.getElementById('txtresourceno').focus();
        return false;       
    }
    }
    alrt=document.getElementById('lblremarks').innerHTML;
   
    if(alrt.indexOf('*')>=0)
    {
   
 if(document.getElementById('txtremarks').value=="")
    {
        alert("Please Enter Remarks");
        document.getElementById('txtremarks').focus();
        return false;       
    }
    }
    

  if((document.getElementById('txttotvalue').value=="" || document.getElementById('txttotvalue').value=="0") && (document.getElementById('txtpb').value=="Paid(P)"))
  {
    alert("Please Get Rate");
    return false;
  }
    var o = new Object();
    o.txtchannel = document.getElementById('txtchannel').value;
    o.txtlocation = document.getElementById('txtlocation').value;
    o.txtadvtype = document.getElementById('txtadvtype').value;
    o.txtpb = document.getElementById('txtpb').value;
    o.txtratetype = document.getElementById('txtratetype').value;
    o.txtprogramname = document.getElementById('txtprogramname').value;
    o.txtbtb = document.getElementById('txtbtb').value;
    o.txtros = document.getElementById('txtros').value;
    o.txtday = document.getElementById('txtday').value;
    o.txtfct = document.getElementById('txtfct').value;
    o.txtpackage = document.getElementById('txtpackage').value;
    o.txtvaluefrom = document.getElementById('txtvaluefrom').value;
    o.txtvalueto = document.getElementById('txtvalueto').value;
    o.txtdisctype = document.getElementById('txtdisctype').value;
    o.txtdiscper = document.getElementById('txtdiscper').value;
    o.txtprem = document.getElementById('txtprem').value;
    o.txtcontprem = document.getElementById('txtcontprem').value;
    o.txtcontrate = document.getElementById('txtcontrate').value;
    o.txtcardrate = document.getElementById('txtcardrate').value;
    o.txtdev = document.getElementById('txtdev').value;
    o.txtcardprem = document.getElementById('txtcardprem').value;
    o.txtminsize = document.getElementById('txtminsize').value;
    o.txtmaxsize = document.getElementById('txtmaxsize').value;
    o.txtcurrency = document.getElementById('txtcurrency').value;
    o.txtdealstart = document.getElementById('txtdealstart').value;
    o.txtprogtype = document.getElementById('txtprogtype').value;
    o.txtcategory = document.getElementById('txtcategory').value;
    o.txtcommallow = document.getElementById('txtcommallow').value;
    o.txtremarks = document.getElementById('txtremarks').value;
    o.txtratecode = document.getElementById('txtratecode').value;
    o.txtdiscon = document.getElementById('txtdiscon').value;
    o.txtsponfrom = document.getElementById('txtsponfrom').value;
    o.txtsponto = document.getElementById('txtsponto').value;
    o.txtsource = document.getElementById('txtsource').value;
    o.txttotvalue = document.getElementById('txttotvalue').value;
    o.hidcurrency_convrate = document.getElementById('hidcurrency_convrate').value;
    o.txtlocaltotvalue = document.getElementById('txtlocaltotvalue').value;
    
    o.txtincentive = document.getElementById('txtincentive').value;
    o.txtapproved = document.getElementById('txtapproved').value;
    o.txtconsumed = document.getElementById('txtconsumed').value;
    o.txtbalance = document.getElementById('txtbalance').value;
    o.txtsectioncode = document.getElementById('txtsectioncode').value;
    o.txtresourceno = document.getElementById('txtresourceno').value;
    o.txtslot = document.getElementById('txtslot').value;
  window.returnValue = o; 
 window.close();
 return false;
}
function tabvalue (event,id)
{
var browser=navigator.appName;
//alert(event.which);
 if(browser!="Microsoft Internet Explorer")
 {
         if(document.activeElement.id=="txttotvalue" || document.activeElement.id=="txtcardprem" || document.activeElement.id=="txtcontprem" || document.activeElement.id=="txtcontrate" || document.activeElement.id=="txtcardrate" || document.activeElement.id=="txtdev" || document.activeElement.id=="txtdiscper" || document.activeElement.id=="txtminsize" || document.activeElement.id=="txtmaxsize" || document.activeElement.id=="txtvaluefrom" || document.activeElement.id=="txtvalueto" || document.activeElement.id=="txtincentive" || document.activeElement.id=="txtfct" || document.activeElement.id=="txtconsumed" || document.activeElement.id=="txtbalance")
{
   var res=notchar2(event);
   if(res==false)
    return false;
}

     if(event.which==13)
        {
            
            if(document.activeElement.id=="txtsponfrom" || document.activeElement.id=="txtsponto" )
            {
                var res=checkdateG(document.getElementById(document.activeElement.id));   
                if(res==false)
                {
                    return false;
                }    
            }
            else if(document.activeElement.id=="txtcontrate" || document.activeElement.id=="txtcardrate")
            {
                if(document.getElementById('txtcardrate').value!="" && document.getElementById('txtcontrate').value!="")
                {
                    document.getElementById('txtdev').value=parseFloat(document.getElementById('txtcardrate').value) - parseFloat(document.getElementById('txtcontrate').value);
                }
            }
            else if(document.activeElement.id=="txtchannel" || document.activeElement.id=="txtlocation" || document.activeElement.id=="txtadvtype" || document.activeElement.id=="txtratetype" || document.activeElement.id=="txtday" || document.activeElement.id=="txtcategory"  || document.activeElement.id=="txtbtb" || document.activeElement.id=="txtfct" || document.activeElement.id=="txtpackage" || document.activeElement.id=="txtvaluefrom" || document.activeElement.id=="txtvalueto" || document.activeElement.id=="txtdisctype" || document.activeElement.id=="txtdiscper" || document.activeElement.id=="txtprem" || document.activeElement.id=="txtcardprem" || document.activeElement.id=="txtcontprem" || document.activeElement.id=="txtminsize" || document.activeElement.id=="txtmaxsize" || document.activeElement.id=="txtprogtype" || document.activeElement.id=="txtprogramname"  || document.activeElement.id=="txtcommallow" || document.activeElement.id=="txtratecode" || document.activeElement.id=="txtcontrate" || document.activeElement.id=="txtcurrency")
            {
                 var agcode="";
                   if(document.getElementById('hiddenagcode').value!="" && document.getElementById('hiddenagcode').value.indexOf("(")>=0 && document.getElementById('hiddenagcode').value.indexOf(")")>=0)
                        agcode=document.getElementById('hiddenagcode').value.substring(document.getElementById('hiddenagcode').value.lastIndexOf('(')+1,document.getElementById('hiddenagcode').value.lastIndexOf(')'));
                   var subagencycode = document.getElementById('hiddenagsubcode').value;     
                   var res=contractChild.getrateforcontract_Elec( document.getElementById('hiddencompcode').value, document.getElementById('hiddenunit').value, document.getElementById('txtchannel').value, document.getElementById('txtlocation').value, document.getElementById('txtadvtype').value, document.getElementById('txtratetype').value, document.getElementById('txtday').value,document.getElementById('txtcategory').value, document.getElementById('txtbtb').value, document.getElementById('txtfct').value, document.getElementById('txtvalidfrom').value, document.getElementById('txtvalidto').value,document.getElementById('txtpackage').value, document.getElementById('txtvaluefrom').value, document.getElementById('txtvalueto').value, document.getElementById('txtdisctype').value, document.getElementById('txtdiscper').value, document.getElementById('txtprem').value, document.getElementById('txtcardprem').value,document.getElementById('txtcontprem').value, document.getElementById('txtminsize').value, document.getElementById('txtmaxsize').value, document.getElementById('txtprogtype').value, document.getElementById('txtprogramname').value, document.getElementById('txtcommallow').value, document.getElementById('txtratecode').value, document.getElementById('txtsource').value, document.getElementById('hiddendateformat').value,document.getElementById('txtcurrency').value,document.getElementById('txtcontrate').value,agcode,subagencycode);
                   var ds=res.value;
                   if(ds==null)
                   {
                    alert(res.error.description);
                    return false;
                   }
                   document.getElementById('txtcardrate').value="";
                 //   document.getElementById('txtcontrate').value="";
                   document.getElementById('txttotvalue').value="";
                   document.getElementById('txtlocaltotvalue').value="";
                   if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
                   {
                        if(ds.Tables[0].Rows[0].card_rate!=null)
                            document.getElementById('txtcardrate').value=ds.Tables[0].Rows[0].card_rate;
                        if(ds.Tables[0].Rows[0].TOTALVAL!=null) 
                        {  
                            document.getElementById('txttotvalue').value=ds.Tables[0].Rows[0].TOTALVAL;
                            document.getElementById('txtlocaltotvalue').value=ds.Tables[0].Rows[0].TOTALVAL;
                            if(document.getElementById('txtcurrency').value!=document.getElementById('hidcurr').value || document.getElementById('txtcurrency').value!=document.getElementById('hidreceiptcurr').value)
                            getAmount_Currency();
                        }
                             
                   }
            }
             if(document.activeElement.id=="txtchannel")
             {
                 document.getElementById('txtpb').focus();
                 return false;
             }
             else  if(document.activeElement.id=="txtpb")
             {
                 document.getElementById('txtpackage').focus();
                 return false;
             }
             else  if(document.activeElement.id=="txtpackage")
             {
                 document.getElementById('txtadvtype').focus();
                 return false;
             }
             else  if(document.activeElement.id=="txtadvtype")
             {
                 document.getElementById('txtbtb').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtbtb")
             {
                 document.getElementById('txtprogramname').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtprogramname")
             {
                 document.getElementById('txtros').focus();
                 return false;
             }
                else  if(document.activeElement.id=="txtros")
             {
                 document.getElementById('txtday').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtday")
             {
                 document.getElementById('txtratetype').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtratetype")
             {
                 document.getElementById('txtfct').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtfct")
             {
                 document.getElementById('txtminsize').focus();
                 return false;
             }
             else  if(document.activeElement.id=="txtminsize")
             {
                 document.getElementById('txtmaxsize').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtmaxsize")
             {
                 document.getElementById('txtcontrate').focus();
                 return false;
             }
//              else  if(document.activeElement.id=="txtcardrate")
//             {
//                 document.getElementById('txtcontrate').focus();
//                 return false;
//             }
               else  if(document.activeElement.id=="txtcontrate")
             {
                 document.getElementById('txtprem').focus();
                 return false;
             }
//              else  if(document.activeElement.id=="txtdev")
//             {
//                 document.getElementById('txtprem').focus();
//                 return false;
//             }
               else  if(document.activeElement.id=="txtprem")
             {
                 document.getElementById('txtcontprem').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtcontprem")
             {
                 document.getElementById('txtsource').focus();
                 return false;
             }
//               else  if(document.activeElement.id=="txtcardprem")
//             {
//                 document.getElementById('txtsource').focus();
//                 return false;
//             }
               else  if(document.activeElement.id=="txtsource")
             {
                 document.getElementById('txtcategory').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtcategory")
             {
                 document.getElementById('txtcurrency').focus();
                 return false;
             }
             else  if(document.activeElement.id=="txtcurrency")
             {
                 document.getElementById('txtsponfrom').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtsponfrom")
             {
                 document.getElementById('txtsponto').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtsponto")
             {
                 document.getElementById('txtvaluefrom').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtvaluefrom")
             {
                 document.getElementById('txtvalueto').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtvalueto")
             {
                 document.getElementById('txtdisctype').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtdisctype")
             {
                 document.getElementById('txtdiscper').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtdiscper")
             {
                 document.getElementById('txtdealstart').focus();
                 return false;
             }
             else  if(document.activeElement.id=="txtdealstart")
             {
                 document.getElementById('txtprogtype').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtprogtype")
             {
                 document.getElementById('txtratecode').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtratecode")
             {
                 document.getElementById('txtdiscon').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtdiscon")
             {
                 document.getElementById('txtcommallow').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtcommallow")
             {
                 document.getElementById('txtincentive').focus();
                 return false;
             }
//                else  if(document.activeElement.id=="txttotvalue")
//             {
//                 document.getElementById('txtincentive').focus();
//                 return false;
//             }
               else  if(document.activeElement.id=="txtincentive")
             {
                 document.getElementById('txtapproved').focus();
                 return false;
             }
                  else  if(document.activeElement.id=="txtapproved")
             {
                 document.getElementById('txtsectioncode').focus();
                 return false;
             }
              else  if(document.activeElement.id=="txtsectioncode")
             {
                 document.getElementById('txtresourceno').focus();
                 return false;
             }
               else  if(document.activeElement.id=="txtresourceno")
             {
                 document.getElementById('txtremarks').focus();
                 return false;
             }
                else  if(document.activeElement.id=="txtremarks")
             {
                 document.getElementById('btnOk').focus();
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
             else if(document.activeElement.id=="lstcommon")
             {
                  if(colName=="txtprem")
                   {
                        bindPremCharges(document.getElementById("lstcommon").value);
                        document.getElementById(colName).value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
                   }
                   else  if(colName=="txtday" || colName=="txtros")
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
                    document.getElementById(colName).value=day;
                  }
                else{
                if(document.getElementById('lstcommon').selectedIndex!=-1)
                    document.getElementById(colName).value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
                  }  
                document.getElementById("divcommon").style.display="none";
                try{
                document.getElementById(colName).focus();
                }
                catch(err){}
                colName="";
                return false;
             }
            else
            {
            //alert(event.which);
            event.which=9;
            //alert(event.which);
            return event.which;
            }
        }
        
        if(event.which==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
        if (event.which!=46 && event.which!=39 && event.which!=37 && event.which != 13 && event.which != 9 && event.which != 27 && event.which != 113 && event.which!=8 && event.which!=40 && event.which!=38 && event.which!=16)
        { 
          //  var colName=document.activeElement.id;
            if(document.activeElement.id=="txtsource" || document.activeElement.id=="txtadvtype"  || document.activeElement.id=="txtpackage" || document.activeElement.id=="txtcategory" || document.activeElement.id=="txtprem" || document.activeElement.id=="txtdisctype" || document.activeElement.id=="txtdiscon" || document.activeElement.id=="txtday" || document.activeElement.id=="txtcommallow" || document.activeElement.id=="txtdealstart" || document.activeElement.id=="txtcurrency" || document.activeElement.id=="txtratecode" || document.activeElement.id=="txtapproved" || document.activeElement.id=="txtchannel" || document.activeElement.id=="txtlocation" || document.activeElement.id=="txtpb" || document.activeElement.id=="txtratetype" || document.activeElement.id=="txtprogramname" || document.activeElement.id=="txtbtb" || document.activeElement.id=="txtros" || document.activeElement.id=="txtprogtype" || document.activeElement.id=="txtsectioncode" || document.activeElement.id=="txtresourceno")
            {
                event.which=0;    
                return false;
            }
        }
        if(event.which==27)
        {
          if(document.getElementById("divcommon")!=null && document.getElementById("divcommon").style.display=="block")
          {
             document.getElementById("divcommon").style.display="none";
             if(colName!="" && colName!=undefined && colName!="undefined")
             {
                document.getElementById(colName).focus();
             }
          }
          colName="";
          return false;
       }   
        if(event.which==113)
        {
            colName=document.activeElement.id;
         if(colName=="txtsource" || colName=="txtadvtype" || colName=="txtapproved" || colName=="txtratecode" ||  colName=="txtprem" || colName=="txtday" || colName=="txtcommallow" || colName=="txtdealstart" || colName=="txtpackage" || colName=="txtcategory"  || colName=="txtdisctype" || colName=="txtdiscon" || colName=="txtcurrency" || colName=="txtchannel" || colName=="txtlocation" || colName=="txtprogtype" || colName=="txtprogramname" || colName=="txtbtb" || colName=="txtros" || colName=="txtpb" || colName=="txtratetype"  || document.activeElement.id=="txtsectioncode" || document.activeElement.id=="txtresourceno")
        {
            colName=document.activeElement.id;
           document.getElementById("divcommon").style.display="block";   
           
           aTag = eval( document.getElementById(colName))
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
	                     document.getElementById('divcommon').style.top=document.getElementById(colName).offsetTop + toppos + "px";
	                     document.getElementById('divcommon').style.left=document.getElementById(colName).offsetLeft + leftpos+"px";
	                     bindListBox(colName);
	                     return false;
	      }               
        }
        
 }       
else
{
    if(document.activeElement.id=="txttotvalue" || document.activeElement.id=="txtcardprem" || document.activeElement.id=="txtcontprem" || document.activeElement.id=="txtcontrate" || document.activeElement.id=="txtcardrate" || document.activeElement.id=="txtdev" || document.activeElement.id=="txtdiscper" || document.activeElement.id=="txtminsize" || document.activeElement.id=="txtmaxsize" || document.activeElement.id=="txtvaluefrom" || document.activeElement.id=="txtvalueto" || document.activeElement.id=="txtincentive" || document.activeElement.id=="txtfct" || document.activeElement.id=="txtconsumed" || document.activeElement.id=="txtbalance")
{
   var res=notchar2(event);
   if(res==false)
    return false;
}

     if(event.keyCode==13)
        {
            if(document.activeElement.id=="txtsponfrom" || document.activeElement.id=="txtsponto" )
            {
                var res=checkdateG(document.getElementById(document.activeElement.id));   
                if(res==false)
                {
                    return false;
                }    
            }
            else if(document.activeElement.id=="txtcontrate" || document.activeElement.id=="txtcardrate")
            {
                if(document.getElementById('txtcardrate').value!="" && document.getElementById('txtcontrate').value!="")
                {
                    document.getElementById('txtdev').value=parseFloat(document.getElementById('txtcardrate').value) - parseFloat(document.getElementById('txtcontrate').value);
                }
            }
            if(document.activeElement.id=="txtchannel" || document.activeElement.id=="txtlocation" || document.activeElement.id=="txtadvtype" || document.activeElement.id=="txtratetype" || document.activeElement.id=="txtday" || document.activeElement.id=="txtcategory"  || document.activeElement.id=="txtbtb" || document.activeElement.id=="txtfct" || document.activeElement.id=="txtpackage" || document.activeElement.id=="txtvaluefrom" || document.activeElement.id=="txtvalueto" || document.activeElement.id=="txtdisctype" || document.activeElement.id=="txtdiscper" || document.activeElement.id=="txtprem" || document.activeElement.id=="txtcardprem" || document.activeElement.id=="txtcontprem" || document.activeElement.id=="txtminsize" || document.activeElement.id=="txtmaxsize" || document.activeElement.id=="txtprogtype" || document.activeElement.id=="txtprogramname"  || document.activeElement.id=="txtcommallow" || document.activeElement.id=="txtratecode" || document.activeElement.id=="txtcontrate" || document.activeElement.id=="txtcurrency")
            {
                 var agcode="";
                   if(document.getElementById('hiddenagcode').value!="" && document.getElementById('hiddenagcode').value.indexOf("(")>=0 && document.getElementById('hiddenagcode').value.indexOf(")")>=0)
                        agcode=document.getElementById('hiddenagcode').value.substring(document.getElementById('hiddenagcode').value.lastIndexOf('(')+1,document.getElementById('hiddenagcode').value.lastIndexOf(')'));
                   var subagencycode = document.getElementById('hiddenagsubcode').value;     
                   var res=contractChild.getrateforcontract_Elec( document.getElementById('hiddencompcode').value, document.getElementById('hiddenunit').value, document.getElementById('txtchannel').value, document.getElementById('txtlocation').value, document.getElementById('txtadvtype').value, document.getElementById('txtratetype').value, document.getElementById('txtday').value,document.getElementById('txtcategory').value, document.getElementById('txtbtb').value, document.getElementById('txtfct').value, document.getElementById('txtvalidfrom').value, document.getElementById('txtvalidto').value,document.getElementById('txtpackage').value, document.getElementById('txtvaluefrom').value, document.getElementById('txtvalueto').value, document.getElementById('txtdisctype').value, document.getElementById('txtdiscper').value, document.getElementById('txtprem').value, document.getElementById('txtcardprem').value,document.getElementById('txtcontprem').value, document.getElementById('txtminsize').value, document.getElementById('txtmaxsize').value, document.getElementById('txtprogtype').value, document.getElementById('txtprogramname').value, document.getElementById('txtcommallow').value, document.getElementById('txtratecode').value, document.getElementById('txtsource').value, document.getElementById('hiddendateformat').value,document.getElementById('txtcurrency').value,document.getElementById('txtcontrate').value,agcode,subagencycode);
                   var ds=res.value;
                   if(ds==null)
                   {
                    alert(res.error.description);
                    return false;
                   }
                   document.getElementById('txtcardrate').value="";
                 //   document.getElementById('txtcontrate').value="";
                   document.getElementById('txttotvalue').value="";
                   document.getElementById('txtlocaltotvalue').value="";
                   if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
                   {
                        if(ds.Tables[0].Rows[0].card_rate!=null)
                            document.getElementById('txtcardrate').value=ds.Tables[0].Rows[0].card_rate;
                        if(ds.Tables[0].Rows[0].TOTALVAL!=null)   {
                                document.getElementById('txttotvalue').value=ds.Tables[0].Rows[0].TOTALVAL;
                                document.getElementById('txtlocaltotvalue').value=ds.Tables[0].Rows[0].TOTALVAL;
                                if(document.getElementById('txtcurrency').value!=document.getElementById('hidcurr').value || document.getElementById('txtcurrency').value!=document.getElementById('hidreceiptcurr').value)
                                    getAmount_Currency();
                            }
                   }
            }
              if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
            {
                event.keyCode=13;
                return event.keyCode;

            }
            else if(document.activeElement.id==id)
            {
                if(document.getElementById('btnOk').disabled==false)
                {
            document.getElementById('btnOk').focus();
                }
            return;

            }
          
             else if(document.activeElement.id=="lstcommon")
             {
                  if(colName=="txtprem")
                   {
                        bindPremCharges(document.getElementById("lstcommon").value);
                        document.getElementById(colName).value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
                   }
                   else  if(colName=="txtday" || colName=="txtros")
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
                    document.getElementById(colName).value=day;
                  }
                  else if(colName=="txtcurrency"){
                  if(document.getElementById('lstcommon').selectedIndex!=-1)
                    document.getElementById(colName).value=document.getElementById('lstcommon').value;
                  }
                else{
                if(document.getElementById('lstcommon').selectedIndex!=-1)
                    document.getElementById(colName).value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
                  }  
                document.getElementById("divcommon").style.display="none";
                try{
                document.getElementById(colName).focus();
                }
                catch(err){}
                colName="";
                return false;
             }
            else
            {
            //alert(event.keyCode);
            event.keyCode=9;
            //alert(event.keyCode);
            return event.keyCode;
            }
        }
        
        if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
        if (event.keyCode!=46 && event.keyCode!=39 && event.keyCode!=37 && event.keyCode != 13 && event.keyCode != 9 && event.keyCode != 27 && event.keyCode != 113 && event.keyCode!=8 && event.keyCode!=40 && event.keyCode!=38 && event.keyCode!=16)
        { 
          //  var colName=document.activeElement.id;
            if(document.activeElement.id=="txtsource" || document.activeElement.id=="txtadvtype"  || document.activeElement.id=="txtpackage" || document.activeElement.id=="txtcategory" || document.activeElement.id=="txtprem" || document.activeElement.id=="txtdisctype" || document.activeElement.id=="txtdiscon" || document.activeElement.id=="txtday" || document.activeElement.id=="txtcommallow" || document.activeElement.id=="txtdealstart" || document.activeElement.id=="txtcurrency" || document.activeElement.id=="txtratecode" || document.activeElement.id=="txtapproved" || document.activeElement.id=="txtchannel" || document.activeElement.id=="txtlocation" || document.activeElement.id=="txtpb" || document.activeElement.id=="txtratetype" || document.activeElement.id=="txtprogramname" || document.activeElement.id=="txtbtb" || document.activeElement.id=="txtros" || document.activeElement.id=="txtprogtype")
            {
                event.keyCode=0;    
                return false;
            }
        }
        if(event.keyCode==27)
        {
        try{
          if(document.getElementById("divcommon")!=null && document.getElementById("divcommon").style.display=="block")
          {
             document.getElementById("divcommon").style.display="none";
             if(colName!="" && colName!=undefined && colName!="undefined")
             {
                document.getElementById(colName).focus();
             }
          }
          }
          catch(err){}
          colName="";
          return false;
       }   
        if(event.keyCode==113)
        {
            colName=document.activeElement.id;
         if(colName=="txtsource" || colName=="txtadvtype" || colName=="txtapproved" || colName=="txtratecode" ||  colName=="txtprem" || colName=="txtday" || colName=="txtcommallow" || colName=="txtdealstart" || colName=="txtpackage" || colName=="txtcategory"  || colName=="txtdisctype" || colName=="txtdiscon" || colName=="txtcurrency" || colName=="txtchannel" || colName=="txtlocation" || colName=="txtprogtype" || colName=="txtprogramname" || colName=="txtbtb" || colName=="txtros" || colName=="txtpb" || colName=="txtratetype"  || document.activeElement.id=="txtsectioncode" || document.activeElement.id=="txtresourceno")
        {
            colName=document.activeElement.id;
           document.getElementById("divcommon").style.display="block";   
           
           aTag = eval( document.getElementById(colName))
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
	                     document.getElementById('divcommon').style.top=document.getElementById(colName).offsetTop + toppos + "px";
	                     document.getElementById('divcommon').style.left=document.getElementById(colName).offsetLeft + leftpos+"px";
	                     bindListBox(colName);
	                     return false;
	      }               
        }
        
}

}
function bindPremCharges(premcode)
{
     var res=contractChild.getPremPage_detail(premcode);
     var ds=res.value;
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
     {
        var cardprem=ds.Tables[0].Rows[0].premium_charges;
            document.getElementById('txtcardprem').value=cardprem;    
     }
}
function bindListBox(colName)
{
    if(colName=="txtsource")
    {
        var res=contractChild.bindSource_TV_Contract(document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].SOURCE_TYPE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if(colName=="txtsectioncode")
    {
         var val_=document.getElementById(colName).value;
            var res=contractChild.getSectionCode(val_);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else if(colName=="txtresourceno")
    {
          var val_=document.getElementById(colName).value;
        var res=contractChild.getResourceNo(val_);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else if(colName=="txtratetype")
    {
        var adtype="EL0";
        var res=contractChild.binduom_A_detail(document.getElementById('hiddencompcode').value,adtype,document.getElementById('hiddenuserid').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].UOM_Name,ds.Tables[0].Rows[i].UOM_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if(colName=="txtpackage")
    {
        var adtype="EL0";    
          var channel=document.getElementById('txtchannel').value;
        if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));    
        var res=contractChild.bindpackage_A_detail(document.getElementById('hiddencompcode').value,adtype,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name,ds.Tables[0].Rows[i].Combin_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtcategory")
    {
        var  adtype="EL0";    
        var res=contractChild.bindadvcategory_A_detail(adtype,document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if(colName=="txtprem")
    {
       var adtype="EL0";    
        var res=contractChild.bindpremium_A_detail(document.getElementById('hiddencompcode').value,adtype);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].premiumname,ds.Tables[0].Rows[i].Premiumcode);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtdisctype")
    {
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Free","1");    
        pkgitem.options[pkgitem.options.length] = new Option("Discounted","2");  
        pkgitem.options[pkgitem.options.length] = new Option("Fixed Rate","3");              
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
    else  if(colName=="txtdiscon")
    {
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Discount On Bill","1");    
        pkgitem.options[pkgitem.options.length] = new Option("Discount through Credit Note","2");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtdealstart")
    {
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("After Target Achived","A");    
        pkgitem.options[pkgitem.options.length] = new Option("From Begining","B");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtapproved")
    {
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Yes","Y");    
        pkgitem.options[pkgitem.options.length] = new Option("No","N");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
    else  if(colName=="txtcommallow")
    {
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Yes","Y");    
        pkgitem.options[pkgitem.options.length] = new Option("No","N");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtday")
    {
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple=true;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("SUN","sun");    
        pkgitem.options[pkgitem.options.length] = new Option("MON","mon");     
        pkgitem.options[pkgitem.options.length] = new Option("TUE","tue");       
        pkgitem.options[pkgitem.options.length] = new Option("WED","wed");       
        pkgitem.options[pkgitem.options.length] = new Option("THU","thu");       
        pkgitem.options[pkgitem.options.length] = new Option("FRI","fri");       
        pkgitem.options[pkgitem.options.length] = new Option("SAT","sat");          
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtcurrency")
    {
        var adtype="EL0";   
        var res=contractChild.bindcurrency_detail(document.getElementById('hiddencompcode').value,adtype,document.getElementById('hiddenuserid').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Curr_Name,ds.Tables[0].Rows[i].Curr_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtratecode")
    {
        var adtype="EL0";
        var res=contractChild.bindratecode_detail(document.getElementById('hiddencompcode').value,adtype);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].rate_mast_code,ds.Tables[0].Rows[i].rate_mast_code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtchannel")
    {
        var res=contractChild.bindChannel_detail(document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].CHANNEL);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
      else  if(colName=="txtlocation")
    {
        var res=contractChild.bindLocation_detail(document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].LOCCD);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtprogtype")
    {
          var channel=document.getElementById('txtchannel').value;
        if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));        
        var res=contractChild.bindProgramType_detail(document.getElementById('hiddencompcode').value,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].PROGRAMME_TY);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtprogramname")
    {
        var programtype=document.getElementById('txtprogtype').value;
        if(programtype.indexOf("(")>0)
            programtype=programtype.substring(programtype.lastIndexOf('(')+1,programtype.lastIndexOf(')'));
         var btb=document.getElementById('txtbtb').value;
        if(btb.indexOf("(")>0)
            btb=btb.substring(btb.lastIndexOf('(')+1,btb.lastIndexOf(')'));    
         var channel=document.getElementById('txtchannel').value;
        if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));         
        var res=contractChild.bindProgram_detail(document.getElementById('hiddencompcode').value,programtype,btb,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SHORT_NAME,ds.Tables[0].Rows[i].PRG_ID);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtbtb")
    {
      var channel=document.getElementById('txtchannel').value;
      if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
        var res=contractChild.bindBTB_detail(document.getElementById('hiddencompcode').value,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BTB_DESC,ds.Tables[0].Rows[i].BTB_CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtadvtype")
    {
          var channel=document.getElementById('txtchannel').value;
      if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
        var res=contractChild.bindAdvType_TV_detail(document.getElementById('hiddencompcode').value,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].DES,ds.Tables[0].Rows[i].AD_TYPE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
      else  if(colName=="txtros")
    {
     var channel=document.getElementById('txtchannel').value;
       if(channel.indexOf("(")>0)
        channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
        var btb=document.getElementById('txtbtb').value;
        if(btb.indexOf("(")>0)
            btb=btb.substring(btb.lastIndexOf('(')+1,btb.lastIndexOf(')'));
        var res=contractChild.bindRos_detail(document.getElementById('hiddencompcode').value,btb,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=true;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BND_DESC,ds.Tables[0].Rows[i].BND_CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="txtpb")
    {
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Paid","P");    
        pkgitem.options[pkgitem.options.length] = new Option("Bonus","B");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
}
function notchar2(event)
{
//alert(event.keyCode);
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 37 && event.which <= 40) || (event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 46) || (event.which == 13))
{
return true;
}
else
{
return false;
}
 }
 else{
if((event.keyCode>=37 && event.keyCode<=40)||(event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46) || (event.keyCode==13))
{
return true;
}
else
{
return false;
}
}
}
function checkdateG(input)
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
//alert(document.activeElement.id);
input.value="";

alert(" Please Fill The Date In "+dateformat+" Format");

//popUpCalendar(document.activeElement,document.activeElement,dateformat);
//setTimeout(settime1,15);
//daid=input;
return false;
//return;c
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


 
returnval=true
 


if (returnval==false) 

input.select()
return returnval

}
function documentClick(event)
{
    if(document.activeElement.id=="lstcommon")
             {
                  if(colName=="txtprem")
                   {
                        bindPremCharges(document.getElementById("lstcommon").value);
                        document.getElementById(colName).value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
                   }
                   else  if(colName=="txtday" || colName=="txtros")
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
                    document.getElementById(colName).value=day;
                  }
                  else if(colName=="txtcurrency"){
                  if(document.getElementById('lstcommon').selectedIndex!=-1)
                    document.getElementById(colName).value=document.getElementById('lstcommon').value;
                  }
                else{
                if(document.getElementById('lstcommon').selectedIndex!=-1)
                    document.getElementById(colName).value=document.getElementById('lstcommon').options[document.getElementById('lstcommon').selectedIndex].text +"("+document.getElementById('lstcommon').value+")";
                  }  
                document.getElementById("divcommon").style.display="none";
                try{
                document.getElementById(colName).focus();
                }
                catch(err){}
                colName="";
                return false;
             }
}
function setData1(event)
{
    alert("l");
}
function checkDateValid()
{
     dateformat=document.getElementById('hiddendateformat').value;
    var fromdate=document.getElementById('txtsponfrom').value;
    var todate=document.getElementById('txtsponto').value;
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
        alert("Sponsorship From Date Should Be Less Than Sponsorship To Date");
        document.getElementById('txtsponto').value="";
        document.getElementById('txtsponto').focus();
        return false;
    }
    }
}
function checkMinMax()
{
    var minsize=document.getElementById('txtminsize').value;
    var maxsize=document.getElementById('txtmaxsize').value;
    if(minsize!="" && maxsize!="")
    {
        if(parseInt(minsize,10)>parseInt(maxsize,10))
        {
            alert("Min Size can'be greater than Max Size");
            document.getElementById('txtmaxsize').focus();
            return false;
        }
    }
}
function checkFromTo()
{
      var minsize=document.getElementById('txtvaluefrom').value;
    var maxsize=document.getElementById('txtvalueto').value;
    if(minsize!="" && maxsize!="")
    {
        if(parseInt(minsize,10)>parseInt(maxsize,10))
        {
            alert("Value From can'be greater than Value To");
            document.getElementById('txtvalueto').focus();
            return false;
        }
    }
}

function getAmount_Currency()
{
    
    if(document.getElementById('txtcurrency').value==document.getElementById('hidcurr').value && document.getElementById('txtcurrency').value==document.getElementById('hidreceiptcurr').value)
    {
         document.getElementById('txtlocaltotvalue').value=document.getElementById('txttotvalue').value;
    }
    else  if(document.getElementById('txtcurrency').value==document.getElementById('hidcurr').value && document.getElementById('txtcurrency').value!=document.getElementById('hidreceiptcurr').value)
    {
        document.getElementById('txtlocaltotvalue').value=document.getElementById('txttotvalue').value;
      
        var datep=document.getElementById('hidcontractdate').value;
        var compcode=document.getElementById('hiddencompcode').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        var res=contractChild.CONVERTTOLOCAL_CURRENCY(compcode,document.getElementById('txtcurrency').value,document.getElementById('txttotvalue').value,document.getElementById('txttotvalue').value,datep,dateformat,document.getElementById('hidreceiptcurr').value);
        var ds=res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
        if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
        {
               if(ds.Tables[0].Rows[0].STATUS!=null && ds.Tables[0].Rows[0].STATUS=="OK")
               {
                document.getElementById('txtlocaltotvalue').value=ds.Tables[0].Rows[0].GROSS;
                document.getElementById('hidcurrency_convrate').value=ds.Tables[0].Rows[0].CONV_RATE;
               }
        }
    } 
     else  if(document.getElementById('txtcurrency').value!=document.getElementById('hidcurr').value && document.getElementById('txtcurrency').value!=document.getElementById('hidreceiptcurr').value)
     {
         document.getElementById('txtlocaltotvalue').value=document.getElementById('txttotvalue').value;
     var datep=document.getElementById('hidcontractdate').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var dateformat=document.getElementById('hiddendateformat').value;
     var res=contractChild.CONVERTTOLOCAL_CURRENCY(compcode,document.getElementById('txtcurrency').value,document.getElementById('txttotvalue').value,document.getElementById('txttotvalue').value,datep,dateformat,document.getElementById('hidcurr').value);
        var ds=res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
        if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
        {
               if(ds.Tables[0].Rows[0].STATUS!=null && ds.Tables[0].Rows[0].STATUS=="OK")
               {
                document.getElementById('txtlocaltotvalue').value=ds.Tables[0].Rows[0].GROSS;
                document.getElementById('hidcurrency_convrate').value=ds.Tables[0].Rows[0].CONV_RATE;
               }
        }
   
    // again converting rate into receipt currencyfrom local
    
       
        var datep=document.getElementById('hidcontractdate').value;
        var compcode=document.getElementById('hiddencompcode').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        var res=contractChild.CONVERTTOLOCAL_CURRENCY(compcode,document.getElementById('txtcurrency').value,document.getElementById('txtlocaltotvalue').value,document.getElementById('txtlocaltotvalue').value,datep,dateformat,document.getElementById('hidreceiptcurr').value);
        var ds=res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
        if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
        {
               if(ds.Tables[0].Rows[0].STATUS!=null && ds.Tables[0].Rows[0].STATUS=="OK")
               {
                document.getElementById('txtlocaltotvalue').value=ds.Tables[0].Rows[0].GROSS;
                document.getElementById('hidcurrency_convrate').value=ds.Tables[0].Rows[0].CONV_RATE;
               }
        }
    }
    else  if(document.getElementById('txtcurrency').value!=document.getElementById('hidcurr').value && document.getElementById('txtcurrency').value==document.getElementById('hidreceiptcurr').value)
    {
     document.getElementById('txtlocaltotvalue').value=document.getElementById('txttotvalue').value;
     var datep=document.getElementById('hidcontractdate').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var dateformat=document.getElementById('hiddendateformat').value;
     var res=contractChild.CONVERTTOLOCAL_CURRENCY(compcode,document.getElementById('txtcurrency').value,document.getElementById('txtlocaltotvalue').value,document.getElementById('txtlocaltotvalue').value,datep,dateformat,document.getElementById('hidcurr').value);
        var ds=res.value;
        if(ds==null)
        {
            alert(res.error.description);
            return false;
        }
        if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
        {
               if(ds.Tables[0].Rows[0].STATUS!=null && ds.Tables[0].Rows[0].STATUS=="OK")
               {
                document.getElementById('txtlocaltotvalue').value=ds.Tables[0].Rows[0].GROSS;
                document.getElementById('hidcurrency_convrate').value=ds.Tables[0].Rows[0].CONV_RATE;
               }
        }
   }
}
function getRate(){
  var agcode="";
                   if(document.getElementById('hiddenagcode').value!="" && document.getElementById('hiddenagcode').value.indexOf("(")>=0 && document.getElementById('hiddenagcode').value.indexOf(")")>=0)
                        agcode=document.getElementById('hiddenagcode').value.substring(document.getElementById('hiddenagcode').value.lastIndexOf('(')+1,document.getElementById('hiddenagcode').value.lastIndexOf(')'));
                   var subagencycode = document.getElementById('hiddenagsubcode').value;     
                   var res=contractChild.getrateforcontract_Elec( document.getElementById('hiddencompcode').value, document.getElementById('hiddenunit').value, document.getElementById('txtchannel').value, document.getElementById('txtlocation').value, document.getElementById('txtadvtype').value, document.getElementById('txtratetype').value, document.getElementById('txtday').value,document.getElementById('txtcategory').value, document.getElementById('txtbtb').value, document.getElementById('txtfct').value, document.getElementById('txtvalidfrom').value, document.getElementById('txtvalidto').value,document.getElementById('txtpackage').value, document.getElementById('txtvaluefrom').value, document.getElementById('txtvalueto').value, document.getElementById('txtdisctype').value, document.getElementById('txtdiscper').value, document.getElementById('txtprem').value, document.getElementById('txtcardprem').value,document.getElementById('txtcontprem').value, document.getElementById('txtminsize').value, document.getElementById('txtmaxsize').value, document.getElementById('txtprogtype').value, document.getElementById('txtprogramname').value, document.getElementById('txtcommallow').value, document.getElementById('txtratecode').value, document.getElementById('txtsource').value, document.getElementById('hiddendateformat').value,document.getElementById('txtcurrency').value,document.getElementById('txtcontrate').value,agcode,subagencycode);
                   var ds=res.value;
                   if(ds==null)
                   {
                    alert(res.error.description);
                    return false;
                   }
                   document.getElementById('txtcardrate').value="";
                 //   document.getElementById('txtcontrate').value="";
                   document.getElementById('txttotvalue').value="";
                   document.getElementById('txtlocaltotvalue').value="";
                   if(ds.Tables.length>0 && ds.Tables[0].Rows.length>0)
                   {
                        if(ds.Tables[0].Rows[0].card_rate!=null)
                            document.getElementById('txtcardrate').value=ds.Tables[0].Rows[0].card_rate;
                        if(ds.Tables[0].Rows[0].TOTALVAL!=null) 
                        {  
                            document.getElementById('txttotvalue').value=ds.Tables[0].Rows[0].TOTALVAL;
                            document.getElementById('txtlocaltotvalue').value=ds.Tables[0].Rows[0].TOTALVAL;
                            if(document.getElementById('txtcurrency').value!=document.getElementById('hidcurr').value || document.getElementById('txtcurrency').value!=document.getElementById('hidreceiptcurr').value)
                            getAmount_Currency();
                        }
                             
                   }
               }

               //---------------------------------

               function ClientisNumber11(event) {
                   var keycode = event.keyCode ? event.keyCode : event.which;
                   var browser = navigator.appName;
                   if (browser != "Microsoft Internet Explorer") {
                       if ((keycode >= 48 && keycode <= 57) || (keycode == 9) || (keycode == 11) || (keycode == 8)) {

                           return true;
                       }
                       else {
                           return false;
                       }
                   }
                   else {

                       if ((keycode >= 48 && keycode <= 57) || (keycode == 9) || (keycode == 11) || (keycode == 8)) {

                           return true;
                       }
                       else {
                           return false;
                       }

                   }

               }