// JScript File5
var agencycodeglo;
var idfocus="";
var agnf2="";
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
function bindagencyname_callback(response)
{       
    ds=response.value;
    document.getElementById('drpretainer').value="";
    var pkgitem = document.getElementById("lstagency");
     pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);

   
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name+'+'+ds.Tables[0].Rows[i].CITYNAME,ds.Tables[0].Rows[i].code_subcode);
        //pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].code_subcode);
       pkgitem.options.length;
       
    }
    }
        if(agnf2!="Y")
 {
    document.getElementById('txtagency').value="";
    
    document.getElementById("lstagency").focus();
  }
    //document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
    //document.getElementById("lstagency").focus();
     return false;
}

function tabvalue(event)
{
    //////////this is for the down arrow moving cursor down in grid
      if(document.activeElement.id.indexOf("rep")==0)
    {
        return dateenter(event);
    }
      if(document.activeElement.id.indexOf("lat")==0)
    {
        return dateenter(event);
    }
    if(document.activeElement.id.indexOf("Text")==0)
    {
        return dateenter(event);
    }
     if(document.activeElement.id.indexOf("hei")==0)
    {
        return rateenter(event);
    }
    if(document.activeElement.id.indexOf("wid")==0)
    {
        return rateenter(event);
    }
      if(document.activeElement.id.indexOf("nocol")==0)
    {
        return rateenter(event);
    }
      if(document.activeElement.id.indexOf("siz")==0)
    {
        return rateenter(event);
    }
         if(document.activeElement.id.indexOf("txtcirrate")==0 || document.activeElement.id.indexOf("txtbartertype")==0)
    {
        if(event.keyCode!=113 &&  event.keyCode!=27 &&   event.keyCode!=13 &&  event.keyCode!=9)
         {
            return false;
         }
    }
    if(document.activeElement.id.indexOf("inssta")==0 || document.activeElement.id.indexOf("pgpre")==0 || document.activeElement.id.indexOf("ads")==0 || document.activeElement.id.indexOf("col")==0)
    {
         if(event.keyCode!=113 &&  event.keyCode!=27)
         {
            return false;
         }
    }
      if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
    if(event.keyCode==40)
    {
          if(document.getElementById('tblinsert').innerHTML!="")
          {
               if(document.activeElement.type=="text")
               {
                    var texid=document.activeElement.id;
                    //3 if start
                    if(texid.indexOf("Text")>=0 || texid.indexOf("rem")>=0 || texid.indexOf("pagno")>=0 || texid.indexOf("hei")>=0)
                    {
                         var idtext;
                         var i;
                         if(texid.indexOf("Text")>=0)
                         {
                               idtext=texid.substring(0,4);
                               i=texid.substring(4,texid.length);;
                         }
                         else if(texid.indexOf("rem")>=0 || texid.indexOf("hei")>=0)
                         {
                               idtext=texid.substring(0,3);
                               i=texid.substring(3,texid.length);;
                         }
                         else if(texid.indexOf("pagno")>=0)
                         {
                               idtext=texid.substring(0,5);
                               i=texid.substring(5,texid.length);;
                         }
                          
                         var len="bookdiv";
                         var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;  
                         var g;
                         if(i!=undefined)
                         {
                             for(g=i;g<y;g++)
                             {
                                 i=parseInt(i)+1;
                                 while(document.getElementById("card"+i)==null && g<y-1)
                                 {
                                     i=i+savtotid;
                                 }
                                 if(g>=y-1)
                                 {
                                    break;
                                 }
                                 document.getElementById(idtext+i).focus();
                                 break;
                         }
                     }  //end of 3 if
                  } 
                    
               }
                
          }

    }
            
            /////////////////////////////////////////this is to chk taht on the grid if we press down than focus should be on down row
////////////////and if up than focus 
      if(event.keyCode==38)
      {
            if(document.getElementById('tblinsert').innerHTML!="")
            {
                  if(document.activeElement.type=="text")
                  {
                         var texid=document.activeElement.id;
                         if(texid.indexOf("Text")>=0 || texid.indexOf("rem")>=0 || texid.indexOf("pagno")>=0 || texid.indexOf("hei")>=0)
                         {
                                var idtext;
                                var i;
                                if(texid.indexOf("Text")>=0)
                                {
                                      idtext=texid.substring(0,4);
                                      i=texid.substring(4,texid.length);;
                                }
                                else if(texid.indexOf("rem")>=0 || texid.indexOf("hei")>=0)
                                {
                                      idtext=texid.substring(0,3);
                                      i=texid.substring(3,texid.length);;
                                }
                                else if(texid.indexOf("pagno")>=0)
                                {
                                      idtext=texid.substring(0,5);
                                      i=texid.substring(5,texid.length);;
                                }
                                var len="bookdiv";
                                var y=document.getElementById(len).getElementsByTagName('table')[0].rows.length-1;  
                                var g;
                                if(i!=undefined)
                                {
                                     for(g=i;g<y;g--)
                                     {
                                          if(i==0)
                                          {
                                              break;
                                          }
                                          i=parseInt(i)-1;
                                          while(document.getElementById("card"+i)==null && g>y-1)
                                          {
                                              i=i-savtotid;
                                          }
                                          if(g=0)
                                          {
                                              break;
                                          }
                                          document.getElementById(idtext+i).focus();
                                          break;
                                     }
                                 }
                            }
                    
                        }
                
                    }

                }

        if(event.keyCode==113)  
        {
       if(document.activeElement.id=="txtagency")
        {
           if(document.getElementById('txtagency').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtagency').value="";
            return false;
            }
            document.getElementById("div1").style.display="block";
              aTag = eval( document.getElementById("txtagency"))
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
			             document.getElementById('div1').style.top=document.getElementById("txtagency").offsetTop + toppos + "px";
			             document.getElementById('div1').style.left=document.getElementById("txtagency").offsetLeft + leftpos+"px";
           /* if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-40) + "px";
              /*  document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-35) + "px";
                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }*/
            Classified_Booking_temp_b.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtagency').value,bindagencyname_callback);
        
        }
          else if(document.activeElement.id=="txtbartertype")
        {
           
              aTag = eval( document.getElementById("txtbartertype"))
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
			
            document.getElementById("divbarter").style.left=document.getElementById("txtbartertype").offsetLeft + leftpos+"px";
            document.getElementById("divbarter").style.top= document.getElementById("txtbartertype").offsetTop + toppos + "px";//"510px";
            document.getElementById("divbarter").style.display="block";
            var res;
            var agencycode="";
            if(document.getElementById('txtagency').value!="")
            {
             agencycode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(')+1,document.getElementById('txtagency').value.length  + document.getElementById('txtagency').value.lastIndexOf('('));
             agencycode = agencycode.replace(")", "");
            } 
             var clientcode = document.getElementById('txtclient').value;
               if (clientcode.indexOf("(".toString()) > 0)
             {
                var myarray1 = clientcode.split('(');
                client = myarray1[1];
                client = client.replace(")", '');
            }
            res=Classified_Booking_temp_b.getBarter(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value,document.getElementById('txtbranch').value,agencycode,client);
            if(res.value!=null && res.value.Tables.length>0)
            {
                var ds=res.value;
            var objciragency=document.getElementById("lstbarter");
            objciragency.options.length = 0; 
            objciragency.options[0]=new Option("-Select-","0");            
            objciragency.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                var name=ds.Tables[0].Rows[i].BARTE_DESC;
                var value=ds.Tables[0].Rows[i].BARTER_CODE+"û"+ds.Tables[0].Rows[i].BARTER_AMOUNT+"û"+ds.Tables[0].Rows[i].STOPBOOKING;
                objciragency.options[objciragency.options.length] = new Option(name,value);            
                objciragency.options.length;       
            }
            objciragency.focus();
            }
        }
          else if(document.activeElement.id=="txtcirrate")
        {
           
              aTag = eval( document.getElementById("txtcirrate"))
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
			
            document.getElementById("divcirrate").style.left=document.getElementById("txtcirrate").offsetLeft + leftpos+"px";
            document.getElementById("divcirrate").style.top= document.getElementById("txtcirrate").offsetTop + toppos + "px";//"510px";
            document.getElementById("divcirrate").style.display="block";
            var res;
            if(document.URLUnencoded.indexOf("advts.aspx")>0)
            {
            res=advts.bindcirRate(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value);
            }
            else
            {
            res=Classified_Booking_temp_b.bindcirRate(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value);
            }
            if(res.value!=null && res.value.Tables.length>0)
            {
                var ds=res.value;
            var objciragency=document.getElementById("lstcirrate");
            objciragency.options.length = 0; 
            objciragency.options[0]=new Option("-Select-","0");            
            objciragency.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                var name=ds.Tables[0].Rows[i].PUBL_NAME + ' + ' + ds.Tables[0].Rows[i].EDTN_NAME + '(' + ds.Tables[0].Rows[i].SUN_RATE + ')';
                var value=ds.Tables[0].Rows[i].PUBL + ' + ' + ds.Tables[0].Rows[i].EDTN + '(' + ds.Tables[0].Rows[i].SUN_RATE + ')';;
                objciragency.options[objciragency.options.length] = new Option(name,value);            
                objciragency.options.length;       
            }
            objciragency.focus();
            }
        }
          else if(document.activeElement.id=="txtciragency")
        {
           
              aTag = eval( document.getElementById("txtciragency"))
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
			
            document.getElementById("divciragency").style.left=document.getElementById("txtciragency").offsetLeft + leftpos+"px";
            document.getElementById("divciragency").style.top= document.getElementById("txtciragency").offsetTop + toppos + "px";//"510px";
             document.getElementById("divciragency").style.display="block";
            var res=Classified_Booking_temp_b.bindciragency(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value,document.getElementById('txtciragency').value);
            if(res.value!=null)
            {
                var ds=res.value;
            var objciragency=document.getElementById("lstciragency");
            objciragency.options.length = 0; 
            objciragency.options[0]=new Option("-Select-","0");            
            objciragency.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objciragency.options[objciragency.options.length] = new Option(ds.Tables[0].Rows[i].AG_NAME + '('+ ds.Tables[0].Rows[i].AGCD + ' + ' + ds.Tables[0].Rows[i].DPCD +')',ds.Tables[0].Rows[i].AG_NAME + '('+ ds.Tables[0].Rows[i].AGCD + ' + ' + ds.Tables[0].Rows[i].DPCD  +')');            
                objciragency.options.length;       
            }
            objciragency.focus();
            }
        }
        else if(document.activeElement.id=="txtclient")
        {
            if(document.getElementById('txtclient').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtclient').value="";
            return false;
            }
            document.getElementById("divclient").style.display="block";
              aTag = eval( document.getElementById("txtclient"))
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
			             document.getElementById('divclient').style.top=document.getElementById("txtclient").offsetTop + toppos + "px";
			             document.getElementById('divclient').style.left=document.getElementById("txtclient").offsetLeft + leftpos+"px";
           /* if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/+(-40) + "px";
               /* document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-35) + "px";
                document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }*/
            Classified_Booking_temp_b.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
        }
        else if(document.activeElement.id=="txtproduct")
        {
           if(document.getElementById('txtproduct').value=="")
                document.getElementById('drpbrand').options.length=0;
            document.getElementById("divproduct").style.display="block";
            //document.getElementById('divproduct').style.top=parseInt(document.getElementById('txtproduct').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdproduct').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6;
            document.getElementById('divproduct').style.top=parseInt(document.getElementById('txtproduct').offsetTop) +  parseInt(document.getElementById('OuterTable').offsetTop) + 420 + "px";
            //document.getElementById('divproduct').style.left=parseInt(document.getElementById('txtproduct').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdproduct').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9;
            document.getElementById('divproduct').style.left=parseInt(document.getElementById('txtproduct').offsetLeft) +  parseInt(document.getElementById('OuterTable').offsetLeft) + 92 + "px";
            Classified_Booking_temp_b.bindProduct(document.getElementById('hiddencompcode').value,document.getElementById('txtproduct').value,bindproductname_callback);
        }
        else if(document.activeElement.id=="txtexecname")
        {
        if(document.getElementById('txtexecname').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtexecname').value="";
            return false;
            }
            document.getElementById("divexec").style.display="block";      
              aTag = eval( document.getElementById("txtexecname"))
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
			             document.getElementById('divexec').style.top=document.getElementById("txtexecname").offsetTop + toppos + "px";
			             document.getElementById('divexec').style.left=document.getElementById("txtexecname").offsetLeft + leftpos+"px";  
          /*  if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById('divexec').style.top=parseInt(document.getElementById('txtexecname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdexec').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/ +(-40) + "px";
           /*     document.getElementById('divexec').style.left=parseInt(document.getElementById('txtexecname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdexec').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                document.getElementById('divexec').style.top=parseInt(document.getElementById('txtexecname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdexec').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-35) + "px";
                document.getElementById('divexec').style.left=parseInt(document.getElementById('txtexecname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdexec').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }*/
            Classified_Booking_temp_b.bindExec(document.getElementById('hiddencompcode').value,document.getElementById('txtexecname').value,bindexecname_callback);
        }
    //*14Aug*
        else if(document.activeElement.id=="drpretainer")
        {
         if(retexeboth!="both")
        {
         if(document.getElementById('txtexecname').value!="")
        {
               if(confirm('Are you sure you want to Take Retainer'))
                {
                 if(document.getElementById('drpretainer').value.length <=2)
                    {
                    alert("Please Enter Minimum 3 Character For Searching.");
                    document.getElementById('drpretainer').value="";
                    return false;
                    }
                   document.getElementById('txtexecname').value="";
                   document.getElementById('txtexeczone').value="";
                    document.getElementById("divretainer").style.display="block";
                      aTag = eval( document.getElementById("drpretainer"))
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
			             document.getElementById('divretainer').style.top=document.getElementById("drpretainer").offsetTop + toppos + "px";
			             document.getElementById('divretainer').style.left=document.getElementById("drpretainer").offsetLeft + leftpos+"px";
                  /*  if(browser!="Microsoft Internet Explorer")
                    {
                        document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/ +(-40) + "px";
                     /*   document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
                    }
                    else
                    {
                        document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-35) + "px";
                        document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
                    }*/
                    Classified_Booking_temp_b.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('drpretainer').value,bindretainer_callback);
                   
                }
                else{
                 document.getElementById('drpretainer').value="";
                 document.getElementById("divretainer").style.display="none";
             }  
            }
            else
             {
             if(document.getElementById('drpretainer').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('drpretainer').value="";
            return false;
            }
             
                  document.getElementById("divretainer").style.display="block";
                   aTag = eval( document.getElementById("drpretainer"))
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
			             document.getElementById('divretainer').style.top=document.getElementById("drpretainer").offsetTop + toppos + "px";
			             document.getElementById('divretainer').style.left=document.getElementById("drpretainer").offsetLeft + leftpos+"px";
                 /*   if(browser!="Microsoft Internet Explorer")
                    {
                        document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/ +(-40) + "px";
                 /*       document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
                    }
                    else
                    {
                        document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-35) + "px";
                        document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
                    }*/
                    Classified_Booking_temp_b.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('drpretainer').value,bindretainer_callback);
             }
           }
            else
             {
             if(document.getElementById('drpretainer').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('drpretainer').value="";
            return false;
            }
             
                  document.getElementById("divretainer").style.display="block";
                   aTag = eval( document.getElementById("drpretainer"))
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
			             document.getElementById('divretainer').style.top=document.getElementById("drpretainer").offsetTop + toppos + "px";
			             document.getElementById('divretainer').style.left=document.getElementById("drpretainer").offsetLeft + leftpos+"px";
                 /*   if(browser!="Microsoft Internet Explorer")
                    {
                        document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) /*+ parseInt(document.getElementById('OuterTable').offsetTop)*/ +(-40) + "px";
                 /*       document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
                    }
                    else
                    {
                        document.getElementById('divretainer').style.top=parseInt(document.getElementById('drpretainer').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdretainer').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-35) + "px";
                        document.getElementById('divretainer').style.left=parseInt(document.getElementById('drpretainer').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdretainer').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
                    }*/
                    Classified_Booking_temp_b.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('drpretainer').value,bindretainer_callback);
             }
          
        }
         else if(document.activeElement.id.indexOf("adcat")==0)
         {
            activeid=document.activeElement.id;
            var compcode=document.getElementById('hiddencompcode').value;
            var divid="agdiv";
            var listboxid="aglist";
            var ds=Classified_Booking_temp_b.advcatinGrid(compcode);
            if(ds==null)
                return false;
            var objadscat=document.getElementById(listboxid);
            objadscat.options.length = 0; 
            objadscat.options[0]=new Option("-Select-","0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1; 
            for (var i = 0  ; i < ds.value.Tables[0].Rows.length; ++i)
            {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Adv_Cat_Name,ds.value.Tables[0].Rows[i].Adv_Cat_Code);
            
                objadscat.options.length;       
            }
              aTag = eval( document.getElementById(activeid))
				var btag;
				var leftpos=0;
				var toppos=0;        
				do {
					aTag = eval(aTag.offsetParent);
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
					btag=eval(aTag)
				} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			 var tot=document.getElementById('bookdiv').scrollLeft;
		
			 	
              var scrolltop=document.getElementById('bookdiv').scrollTop;
			 	
             document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft	+ leftpos-tot+"px";
             document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
             document.getElementById(activeid).style.backgroundColor="#FFFF80";
             document.getElementById(divid).style.display="block";
             	
              document.getElementById(divid).left= document.getElementById(activeid).left + document.getElementById('bookdiv').scrollLeft;
            //  document.getElementById(divid).top= document.getElementById(activeid).offsetTop;
             document.getElementById(listboxid).focus();    
         }
         else if(document.activeElement.id.indexOf("pgpre")==0)
         {
            activeid=document.activeElement.id;
            var compcode=document.getElementById('hiddencompcode').value;
            var divid="agdiv";
            var listboxid="aglist";
            var ds=Classified_Booking_temp_b.bindpagePositioninGrid(compcode);
            if(ds==null)
                return false;
            var objadscat=document.getElementById(listboxid);
            objadscat.options.length = 0; 
            objadscat.options[0]=new Option("-Select-","0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1; 
            for (var i = 0  ; i < ds.value.Tables[0].Rows.length; ++i)
            {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Pos_Type,ds.value.Tables[0].Rows[i].Pos_Type_Code);
            
                objadscat.options.length;       
            }
              aTag = eval( document.getElementById(activeid))
				var btag;
				var leftpos=0;
				var toppos=0;        
				do {
					aTag = eval(aTag.offsetParent);
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
					btag=eval(aTag)
				} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			 var tot=document.getElementById('bookdiv').scrollLeft;
		
			 	
               var scrolltop=document.getElementById('bookdiv').scrollTop;
			 	
             document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft	+ leftpos-tot+"px";
             document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
             document.getElementById(activeid).style.backgroundColor="#FFFF80";
             document.getElementById(divid).style.display="block";
             document.getElementById(listboxid).focus();     
         }
        else if(document.activeElement.id.indexOf("col")==0)
        {
            activeid=document.activeElement.id;
            var userid=document.getElementById('hiddenuserid').value;
            var compcode=document.getElementById('hiddencompcode').value;
            var divid="agdiv";
            var listboxid="aglist";
            var ds=Classified_Booking_temp_b.bindcolorForGrid(compcode,userid);
             if(ds==null)
                return false;
            var objcol=document.getElementById(listboxid);
            objcol.options.length = 0; 
            objcol.options[0]=new Option("-Select-","0");
            //alert(pkgitem.options.length);
            objcol.options.length = 1; 
            for (var i = 0  ; i < ds.value.Tables[0].Rows.length; ++i)
            {
                objcol.options[objcol.options.length] = new Option(ds.value.Tables[0].Rows[i].Col_Name,ds.value.Tables[0].Rows[i].Col_Code);
            
                objcol.options.length;       
            }
              aTag = eval( document.getElementById(activeid))
				var btag;
				var leftpos=0;
				var toppos=0;        
				do {
					aTag = eval(aTag.offsetParent);
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
					btag=eval(aTag)
				} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			 var tot=document.getElementById('bookdiv').scrollLeft;
		
			 	
      var scrolltop=document.getElementById('bookdiv').scrollTop;
			 	
             document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft	+ leftpos-tot+"px";
             document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
             document.getElementById(activeid).style.backgroundColor="#FFFF80";
             document.getElementById(divid).style.display="block";
             document.getElementById(listboxid).focus();
        }
         else if(document.activeElement.id.indexOf("inssta")==0)
        {
             activeid=document.activeElement.id;
            var divid="agdiv";
            var listboxid="aglist";
             var objadscat=document.getElementById(listboxid);
             objadscat.options.length = 0; 
          //  objadscat.options[0]=new Option("-Select-","0");
            var c=0;
            var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
            loadXML("xml/billcycle.xml");
            for(b=0;b<=xmlObj.childNodes(9).childNodes.length-1;b++)
             {
                 objadscat.options[c]=new Option(xmlObj.childNodes[9].childNodes[b].childNodes[0].nodeValue,xmlObj.childNodes[9].childNodes[b+1].childNodes[0].nodeValue);
                  b=b+1;
                 c=c+1;
             }
             objadscat.options.length; 
               aTag = eval( document.getElementById(activeid))
				var btag;
				var leftpos=0;
				var toppos=0;        
				do {
					aTag = eval(aTag.offsetParent);
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
					btag=eval(aTag)
				} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			 var tot=document.getElementById('bookdiv').scrollLeft;
		
			 	
            var scrolltop=document.getElementById('bookdiv').scrollTop;
			 	
             document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft	+ leftpos-tot+"px";
             document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
             document.getElementById(activeid).style.backgroundColor="#FFFF80";
             document.getElementById(divid).style.display="block";
             document.getElementById(listboxid).focus();  
        }
         else if(document.activeElement.id.indexOf("mat")==0)
        {
            activeid=document.activeElement.id;
            var divid="agdiv";
            var listboxid="aglist";
             var objadscat=document.getElementById(listboxid);
            objadscat.options.length = 0; 
            objadscat.options[0]=new Option("-Select-","0");
            objadscat.options[1]=new Option("-Hard Copy-","hardcopy");
            objadscat.options[2]=new Option("-Soft Copy-","softcopy");
            objadscat.options[3]=new Option("-cd-","CD");
            objadscat.options[4]=new Option("-Others-","other");
            objadscat.options[5]=new Option("-As on Matter-","asonmatter");
            objadscat.options.length; 
                aTag = eval( document.getElementById(activeid))
				var btag;
				var leftpos=0;
				var toppos=0;        
				do {
					aTag = eval(aTag.offsetParent);
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
					btag=eval(aTag)
				} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			 var tot=document.getElementById('bookdiv').scrollLeft;
		
			 	
               var scrolltop=document.getElementById('bookdiv').scrollTop;
			 	
             document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft	+ leftpos-tot+"px";
             document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
             document.getElementById(activeid).style.backgroundColor="#FFFF80";
             
             document.getElementById(divid).style.display="block";
             document.getElementById(listboxid).focus();  
        }
         else if(document.activeElement.id.indexOf("ads")==0)
        {
            activeid=document.activeElement.id;
            var divid="agdiv";
            var listboxid="aglist";
            var compcode=document.getElementById('hiddencompcode').value;
            var adcategory=document.activeElement.id.replace("ads","adcat");
            adcategory=document.getElementById(adcategory).value;
            var ds=Classified_Booking_temp_b.getadsubcat(compcode,adcategory);
            if(ds==null)
                return false;
             var objadscat=document.getElementById(listboxid);
            objadscat.options.length = 0; 
            objadscat.options[0]=new Option("-Select-","0");
            //alert(pkgitem.options.length);
            objadscat.options.length = 1; 
            for (var i = 0  ; i < ds.value.Tables[0].Rows.length; ++i)
            {
                objadscat.options[objadscat.options.length] = new Option(ds.value.Tables[0].Rows[i].Adv_Subcat_Name,ds.value.Tables[0].Rows[i].Adv_Subcat_Code);
            
                objadscat.options.length;       
            }
                aTag = eval( document.getElementById(activeid))
				var btag;
				var leftpos=0;
				var toppos=0;        
				do {
					aTag = eval(aTag.offsetParent);
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
					btag=eval(aTag)
				} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			 var tot=document.getElementById('bookdiv').scrollLeft;
		    var scrolltop=document.getElementById('bookdiv').scrollTop;
			 	
             document.getElementById(divid).style.left=document.getElementById(activeid).offsetLeft	+ leftpos-tot+"px";
             document.getElementById(divid).style.top= document.getElementById(activeid).offsetTop + toppos - scrolltop + "px";//"510px";
             document.getElementById(activeid).style.backgroundColor="#FFFF80";
             document.getElementById(divid).style.display="block";
            document.getElementById(divid).cssclass="btextlist";
               
             document.getElementById(listboxid).focus();
        }
    }

    else if(event.keyCode==27)
    {
            if(document.getElementById("divciragency").style.display=="block")
        {
            document.getElementById("divciragency").style.display="none"
             document.getElementById('lstciragency').options.length=0;
            document.getElementById('txtciragency').focus();
        }
         else if(document.getElementById("divcirrate").style.display=="block")
        {
            document.getElementById("divcirrate").style.display="none"
             document.getElementById('lstcirrate').options.length=0;
            document.getElementById('txtcirrate').focus();
        }
           else if(document.getElementById("divbarter").style.display=="block")
        {
            document.getElementById("divbarter").style.display="none"
             document.getElementById('lstbarter').options.length=0;
            document.getElementById('txtbartertype').focus();
        }
       else if(document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('txtagency').focus();
        }
        else if(document.getElementById("divclient").style.display=="block")
        {
            document.getElementById("divclient").style.display="none"
            document.getElementById('txtclient').focus();
        }
        else if(document.getElementById("divproduct").style.display=="block")
        {
            document.getElementById("divproduct").style.display="none"
            document.getElementById('txtproduct').focus();
        }
        else if(document.getElementById("divexec").style.display=="block")
        {
            document.getElementById("divexec").style.display="none"
            document.getElementById('txtexecname').focus();
        }
        else if(document.getElementById("divretainer").style.display=="block")
        {
            document.getElementById("divretainer").style.display="none"
            document.getElementById('drpretainer').focus();
        }
       
          else if(document.activeElement.id.indexOf("adcat")==0 ||document.activeElement.id.indexOf("pgpre")==0 || document.activeElement.id.indexOf("inssta")==0 || document.activeElement.id.indexOf("mat")==0 || document.activeElement.id.indexOf("col")==0 || document.activeElement.id.indexOf("ads")==0 || document.activeElement.id.indexOf("aglist")==0  || document.activeElement.id.indexOf("agdiv")==0 )
        {
           
              document.getElementById(activeid).style.backgroundColor="#FFFFFF";
            document.getElementById("agdiv").style.display="none";
        }

    }

    else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
    {
        if(document.activeElement.id.indexOf("txtagency")>=0)
        {
            if(document.getElementById('txtagency').value=="")
            {
                alert("Please Enter Agency");
                document.getElementById('txtagency').focus();
                return false;
            }
        }
          if(document.activeElement.id.indexOf("txtclient")>=0)
        {
          if(document.getElementById('txtclient').value=="")
          {
            alert("Please Enter Client");
            document.getElementById('txtclient').focus();
            return false;
          }  
        }  
        if(document.activeElement.id.indexOf("aglist")>=0)
        {
 
//           document.getElementById(activeid).value=document.getElementById(document.activeElement.id).value;
//              document.getElementById(activeid).style.backgroundColor="#FFFFFF";
//           document.getElementById('agdiv').style.display="none"; 
  
        FillSubCatinGrid();
       
           return false;
        }
            
    if(document.activeElement.id.indexOf("splt")==0)
    {
        var n1=document.activeElement.id;

        var idnum=document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('splt',''),10)+1].cells[0].innerHTML;
        var editid="edit"+idnum;
        opensplitedition(document.getElementById(editid).value,idnum);
    }   
    if(document.activeElement.id.indexOf("subedi")==0)
    {
        if(document.getElementById('txttotalarea').value=="")
        {
        alert("Please fill Size");
        return false;
        }
        var n1=document.activeElement.id;
        var idnum=document.activeElement.id.replace("subedi","");
        var editid="edit"+idnum;
        var size="siz" + idnum;
        var hei="hei" + idnum;
        var wid="wid" + idnum;
        var id="Text" + idnum;
        var data="subedidata" + idnum;
        showid="sho"+idnum; 
        var insertsta="inssta" +idnum;
        var pkgcode="hiddenpckcode"+idnum;
        var showidval="";
        if(document.getElementById(showid)!=null)
        showidval=document.getElementById(showid).value;
        var pkglength=document.getElementById('drppackagecopy').options.length;
          var pkgname= document.getElementById('drppackagecopy').options[0].value;
          pkgname=pkgname.replace('+','~');
        window.open('booking_subeditiondetail.aspx?pkgname='+pkgname+'&adtype=DI0&pkglength='+pkglength+'&package='+document.getElementById(pkgcode).value+'&cioid='+document.getElementById('txtciobookid').value+'&uomdesc='+document.getElementById('hiddenuomdesc').value+'&compcode='+document.getElementById('hiddencompcode').value+'&insertdate='+document.getElementById(id).value+'&width='+document.getElementById(wid).value+'&data='+document.getElementById(data).value+'&height='+document.getElementById(hei).value+'&edition='+document.getElementById(editid).value+'&insertid='+showidval+'&insertstatus='+document.getElementById(insertsta).value+'&btnstatus='+chkbtnStatus+'&totarea='+document.getElementById(size).value+'&idnum='+idnum+'&dateformat='+document.getElementById('hiddendateformat').value+'&receiptno='+document.getElementById('txtreceipt').value,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=560px,height=300px');
    }
            if(document.activeElement.id=="lstcirrate")
        {
           if(document.getElementById('lstcirrate').value=="0")
            {
                alert("Please select the Cir. Rate");
                return false;
            }
            document.getElementById("divcirrate").style.display="none";
           
            var page=document.getElementById('lstcirrate').value;
            document.getElementById('hiddencirpub').value=trim(page.toString().split('+')[0]);
        document.getElementById('hiddenciredi').value=trim(page.toString().split('+')[1].split('(')[0]);
            var pagename=document.getElementById('lstcirrate').options[document.getElementById('lstcirrate').selectedIndex].text.split('+');
       
       document.getElementById('txtciredition').value=trim(pagename[1].toString()).split('(')[0];
        document.getElementById('txtcirrate').value=trim(pagename[1].toString()).split('(')[1].replace(')','');
      
             document.getElementById('txtcirrate').focus();
          
            return false;
        }
          else  if(document.activeElement.id=="lstbarter")
        {
             if(document.getElementById('lstbarter').value=="0")
            {
                alert("Please Select Barter Type");
                document.getElementById('txtbartertype').value="";
                document.getElementById('hiddenbarteramt').value="";
                document.getElementById('hiddenstopbarterbooking').value="";
                return false;
            }
            document.getElementById("divbarter").style.display="none";
            var bartervalue=document.getElementById('lstbarter').value;
              if(bartervalue!="")
            {
            document.getElementById('hiddenbarteramt').value=bartervalue.split('û')[1];
             document.getElementById('hiddenstopbarterbooking').value=bartervalue.split('û')[2];
            var bame=document.getElementById('lstbarter').options[document.getElementById('lstbarter').selectedIndex].text + '(' + bartervalue.split('û')[0] + ')';
            document.getElementById('txtbartertype').value=bame;
            }
            
        }
        else if(document.activeElement.id=="lstciragency")
        {
           if(document.getElementById('lstciragency').value=="0")
            {
                alert("Please select the Cir. Agency");
                return false;
            }
            document.getElementById("divciragency").style.display="none";
           
            var page=document.getElementById('lstciragency').value;
           
            
           

            
            document.getElementById('txtciragency').value=page;
          
             document.getElementById('txtciragency').focus();
          
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
            var datetime=document.getElementById('txtdatetime').value;
        
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
                if (httpRequest.overrideMimeType) 
                {
                    httpRequest.overrideMimeType('text/xml'); 
                }
            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
                httpRequest.send('');
            
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
         
            var split=id.split("+");
            var namecode=split[0];
            var add=split[1];
            document.getElementById('txtclient').value=namecode;
            if(document.getElementById('hiddensavemod').value=="0")
            {
                document.getElementById('txtclientadd').value=add;
                document.getElementById('txtclientadd').focus();
            }
            disbledroandcredit();     
            bind_agen_bill();
            return false;
        }
          if(document.activeElement.id=="txttotalarea")
    {
        changedivrate();
        return false;
    }
        else if(document.activeElement.id=="lstretainer")
        {
            if(document.getElementById('drpretainer').value=="0")
            {
                alert("Please Select Retainer");
                return false;
            }
            showretainervalue();
        }  
        else if(document.activeElement.id=="lstagency")
        {
            if(document.getElementById('lstagency').value=="0")
            {
                alert("Please select the agency sub code");
                return false;
            }
            document.getElementById("div1").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
            var page=document.getElementById('lstagency').value;
            agencycodeglo=page;
        
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) 
                {
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
            document.getElementById('txtagency').value=nameagen;
            document.getElementById('hiddenagency').value=document.getElementById('lstagency').value;
            if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
            {
                document.getElementById('txtagencyaddress').value=agenadd;                
                document.getElementById('txtclient').focus();
                Classified_Booking_temp_b.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
            }
            return false;
        }
    ///////////////for product
    
        else if(document.activeElement.id=="lstproduct")
        {
            if(document.getElementById('lstproduct').value=="0")
            {
                alert("Please select the product");
                return false;
            }
            document.getElementById("divproduct").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address and if 2 than its for product
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
            var page=document.getElementById('lstproduct').value;
        //agencycodeglo=page;
        
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) 
                {
                    httpRequest.overrideMimeType('text/xml'); 
                }
            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=2", false );
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
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=2", false );
                xml.Send();
                id=xml.responseText;
            }
         
            document.getElementById('txtproduct').value=id;
         
        
         document.getElementById('drpbrand').options.length=0;
            document.getElementById('drpbrand').focus();
            Classified_Booking_temp_b.getbrand(page,document.getElementById('hiddencompcode').value,call_bindproduct);
            return false;
        }
    ///this is for exec name
        else if(document.activeElement.id=="lstexec")
        {
            if(document.getElementById('lstexec').value=="0")
            {
                alert("Please select the executive");
                return false;
            }
            document.getElementById("divexec").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
        //alert(document.getElementById('lstagency').value);
        
         //alert(document.getElementById('lstagency').value);
        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
        address and if 0 than agency name and address and if 2 than its for product and 3 for exec
        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
        
            var page=document.getElementById('lstexec').value;
        //agencycodeglo=page;
        
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) 
                {
                    httpRequest.overrideMimeType('text/xml'); 
                }
            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
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
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
                xml.Send();
                id=xml.responseText;
            }
            document.getElementById('txtexecname').value=id;
        
        
        //document.getElementById('txtcaption').focus();
            Classified_Booking_temp_b.getexeczone(page,document.getElementById('hiddencompcode').value,call_bindexeczone);
          //  changediv();
           document.getElementById('drpretainer').focus();
            return false;
        }
    
    ///////this is when we enter on the print remark than it will open the ad size tab
  
        else if(document.activeElement.id=="txtagencyoutstand")
        {
    
            document.getElementById('LinkButton1').focus();
            event.keyCode=13;
            return event.keyCode;            
        }
        else if(document.activeElement.id=="drpuom")
        {
            document.getElementById('LinkButton5').focus();
                 //changediv1();
                // changedivrate();
            changepackage();
                   // event.keyCode=13;
                   // return event.keyCode;
    
    }
   /* else if(document.activeElement.id=="txttotalarea")
    { // alert("hi");
        document.getElementById('LinkButton4').focus();
                  //changedivrate();
                    event.keyCode=13;
                    return event.keyCode;
    
    
    }*/
        else if(document.activeElement.id=="txtextracharges")
        {  
            document.getElementById('btnshgrid').focus();
                  //changedivrate();
            event.keyCode=13;
            return event.keyCode;
        }
         else if(document.activeElement.id=="drpretainer")
        {  
            changediv();
            //event.keyCode=13;
            //return event.keyCode;
            return false;
        }
        
        else if(document.activeElement.id=="txtprintremark" )
        {
            document.getElementById('LinkButton2').focus();
                  changediv1();
                  //document.getElementById('drppageposition').focus();
            return false;
            //event.keyCode=13;
           // return event.keyCode;    
        }
        else if(document.activeElement.id=="txtbillremark")
        {  
            document.getElementById('LinkButton6').focus();
                  openboxpopup();
                   return false;
                 // drpboxcode
//            event.keyCode=13;
//            return event.keyCode;    
        }
   else if(document.activeElement.id=="txtdummydate")
        {  
            document.getElementById('chktfn').focus();
                  //changedivrate();
             
             return false;
        }
        else if(document.activeElement.id=="txtboxaddress")
        {
            document.getElementById('LinkButton7').focus();
                  //changedivrate();
            event.keyCode=13;
            return event.keyCode;
        } 
       else if(document.activeElement.id=="txtcolum")
    {
        changedivrate();
        return false;
    }  
    //else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.id=="LinkButton1" || document.activeElement.id=="LinkButton2" || document.activeElement.id=="LinkButton3" || document.activeElement.id=="LinkButton4" || document.activeElement.id=="LinkButton5")
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
    else if(event.shiftKey==true && event.keyCode==9)
//else if(event.keyCode===16 )
{
    //alert("hi");
//    if(document.activeElement.id=="LinkButton3") 
//    {
//        changepackage();
//    }
//    else if(document.activeElement.id=="LinkButton5")
//    {
//        changedivrate();
//    }
//    else if(document.activeElement.id=="LinkButton4")
//    {
//        changediv1();
//    }
//    else if(document.activeElement.id=="LinkButton2")
//    {
//        changediv();
//    }
//    else if(document.activeElement.id=="LinkButton6")
//    {
//        changebilldiv();
//    }

///////////////this is used when we use shift+tab
   
    if(document.activeElement.id=="drpbooktype")
    {
        document.getElementById('txtexecname').focus();
        return false;
    }
    else if(document.activeElement.id=="txtprintremark")
    {
         document.getElementById('txtbillremark').focus();
         return false;
    }
    else if(document.activeElement.id=="drppageposition")
    {
        //document.getElementById('LinkButton1').focus();
       // changediv();
       changepackage();
        return false;
    }
    else if(document.activeElement.id=="txtratecode")
    {
        //document.getElementById('LinkButton2').focus();
        //changepackage();
        //changediv();
        changediv1();
        return false;
    }
    else if(document.activeElement.id=="drpcurrency")
    {
        //document.getElementById('LinkButton4').focus();
        
        //changediv1();
        changediv();
        return false;
    }
    else if(document.activeElement.id=="drpbillcycle")
    {
        //document.getElementById('LinkButton5').focus();
        changedivrate();
        return false;
    }
    else if(document.activeElement.id=="drpboxcode")
    {//alert("5");
        //document.getElementById('LinkButton3').focus();
        changebilldiv();
        return false;
    }
        else if(document.activeElement.id=="txtvts")
    {//alert("5");
        //document.getElementById('LinkButton3').focus();
        openboxpopup();
        return false;
    }
    
}
////this is  for short cut keys whern ctrl+d is press than ad detail tab is open
    else if(event.ctrlKey==true && event.keyCode==68 && document.getElementById('LinkButton1').disabled==false)
    {
        changediv();
    }
    ////when ctrl+g than page detail tab is open
    else if(event.ctrlKey==true && event.keyCode==71 && document.getElementById('LinkButton2').disabled==false)
    {
        changediv1();
    }
    ////when ctrl+t than Rate detail tab is open
    else if(event.ctrlKey==true && event.keyCode==84 && document.getElementById('LinkButton4').disabled==false)
    {
        changedivrate();
    }
     ////when ctrl+k than package detail tab is open
    else if(event.ctrlKey==true && event.keyCode==75 && document.getElementById('LinkButton5').disabled==false)
    {
        changepackage();
    }
    ////when ctrl+s than bill detail tab is open
    else if(event.ctrlKey==true && event.keyCode==83 && document.getElementById('LinkButton3').disabled==false)
    {
        changebilldiv();
    }
    ////when ctrl+x than box detail tab is open
    else if(event.ctrlKey==true && event.keyCode==88 && document.getElementById('LinkButton6').disabled==false)
    {
        openboxpopup();
    }
      ////when ctrl+v than box detail tab is open
    else if(event.ctrlKey==true && event.keyCode==86 && document.getElementById('LinkButton7').disabled==false)
    {
        openvts();
    }



else if((event.keyCode==9) && (document.activeElement.type=="button" || document.activeElement.type=="image" || document.activeElement.type=="submit" || document.activeElement.id=="LinkButton1" || document.activeElement.id=="LinkButton2" || document.activeElement.id=="LinkButton3" || document.activeElement.id=="LinkButton4" || document.activeElement.id=="LinkButton5"))
{
 
       event.keyCode=9;
   // alert(document.activeElement.id);
//    event.keyCode=13;
    if(document.activeElement.id=="LinkButton1")
    {
        changediv1();
    }
    else if(document.activeElement.id=="LinkButton2")
    {
        changedivrate();
    }
    else if(document.activeElement.id=="LinkButton3")
    {//alert("7");
        openboxpopup();
    }
    else if(document.activeElement.id=="LinkButton4")
    {
        changepackage();
    }
    else if(document.activeElement.id=="LinkButton5")
    {
        changebilldiv();
    }
    else if(document.activeElement.id=="LinkButton6")
    {
    //alert("8");
    changediv();
    }
    return event.keyCode;

}

}

//bind retainer *6Aug
function bindretainer_callback(res)
{
    var ds=res.value;
    var pkgitem = document.getElementById("lstretainer");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Retainer-","0");
    
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
            document.getElementById('drpretainer').value="";
          //  document.getElementById("drpretainer").value="0";
           //document.getElementById("drpretainer").focus();
           document.getElementById("lstretainer").value="0";
           document.getElementById("lstretainer").focus();
           // document.getElementById("divretainer").style.display="block"
             return false;

    
}
//***************************************




function call_bindagsub(response)
{
ds=response.value;
document.getElementById('txtagencytype').value="";
document.getElementById('txtagencystatus').value="";
document.getElementById('txtcreditperiod').value="";
document.getElementById('txtagencypaymode').value="";
document.getElementById('txttradedisc').value="";
 document.getElementById('hiddenagcommflag').value="";
document.getElementById('txtgrossamt').value="";
if(document.getElementById('txtaddagencycommrate')!=null)
 document.getElementById('txtaddagencycommrate').value="";
document.getElementById('hiddentradedisc').value="";
document.getElementById("lstagency").options.length=0;

  var pkgitem = document.getElementById("drpagscode");
  //pkgitem.options.length=0;
   // pkgitem.options[0] = new Option("-Select-","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
  
    pkgitem.options.length = 0; 
    //pkgitem.options[0]=new Option("--Select City--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].Agency_Code);
        
       pkgitem.options.length;
       
    }
    }
    
    getpayandstatus();
   
    
     return false;

}

function getpayandstatus()
{
document.getElementById('hiddensubcode').value=document.getElementById('drpagscode').value
var subagency=document.getElementById("drpagscode").value;
var datetime=document.getElementById('txtdatetime').value;
var agencycode=document.getElementById('txtagency').value;
var compcode=document.getElementById('hiddencompcode').value
var dateformat=document.getElementById('hiddendateformat').value
if(subagency=="0") 
{
alert("Please select sub agency");
return false;
}

Classified_Booking_temp_b.getpayandstatus(agencycodeglo,subagency,compcode,datetime,dateformat,call_fillpay);
return false;
}

function call_fillpay(res)
{
var ds=res.value;
   document.getElementById('txtgrossamt').value="";
	         document.getElementById('txtbillamt').value="";
if(ds==null)
{
    alert(res.error.description);
    return false;
}    
if(ds.Tables[1].Rows.length>0)
{
    if(ds.Tables[1].Rows[0].status_name=="INACTIVE" || ds.Tables[1].Rows[0].status_name=="BANNED")
    {
        alert("You Can't Book Ad with InActive/Banned Agency");
        document.getElementById("drpagscode").options.length=0;
        document.getElementById("txtagency").value="";
        document.getElementById('txtagency').title="";
        document.getElementById('txtagencytype').value="";
        document.getElementById('txtagencystatus').value="";
        document.getElementById('txtcreditperiod').value="";
        document.getElementById('txtagencypaymode').value="";
        document.getElementById('txttradedisc').value="";
        document.getElementById('hiddenagcommflag').value="";
        document.getElementById('txtgrossamt').value="";
        if(document.getElementById('txtaddagencycommrate')!=null)
         document.getElementById('txtaddagencycommrate').value="";
        document.getElementById('hiddentradedisc').value="";
        //
        document.getElementById('txtagencyaddress').value="";
        document.getElementById('txtagencyaddress').title="";
        document.getElementById("txtagency").focus();
        return false;
    }
}    
if(ds.Tables[2].Rows[0].CREDIT_LIMIT!="" && ds.Tables[2].Rows[0].CREDIT_LIMIT!=null)
    if(parseFloat(ds.Tables[7].Rows[0].outstand)>parseFloat(ds.Tables[2].Rows[0].CREDIT_LIMIT))
    {
      if(!confirm('Outstanding amount of this agency exceeding the Credit Limit. Do you still want to book an Advertisement?'))
        {
            document.getElementById("drpagscode").options.length=0;
            document.getElementById("txtagency").value="";
            document.getElementById('txtagency').title="";
            document.getElementById('txtagencytype').value="";
            document.getElementById('txtagencystatus').value="";
            document.getElementById('txtcreditperiod').value="";
            document.getElementById('txtagencypaymode').value="";
            document.getElementById('txttradedisc').value="";
             document.getElementById('hiddenagcommflag').value="";
            document.getElementById('txtgrossamt').value="";
            if(document.getElementById('txtaddagencycommrate')!=null)
             document.getElementById('txtaddagencycommrate').value="";
            
            document.getElementById('hiddentradedisc').value="";
            //
            document.getElementById('txtagencyaddress').value="";
            document.getElementById('txtagencyaddress').title="";
            document.getElementById("txtagency").focus();
            return false;     
        }
    }
      if(ds.Tables[2].Rows.length>0)
    {
         if(ds.Tables[2].Rows[0].BOOKING_TYPE!=null && ds.Tables[2].Rows[0].BOOKING_TYPE!="")
         {
            var btype=ds.Tables[2].Rows[0].BOOKING_TYPE;
            var obj=document.getElementById('drpbooktype');
            var len=obj.options.length;
                 for(var j=1;j<len;j++)
                {
                    if(btype.indexOf(obj[j].value)<0)
                    {
                         obj.options.remove(j);
                         len=len-1;
                    }
                }
          }
        
    }
 document.getElementById('txtagency').title=document.getElementById('txtagency').value;
 document.getElementById('txtagencyaddress').title=document.getElementById('txtagencyaddress').value;
        if(ds.Tables[0].Rows.length>0)
        {
        document.getElementById('txtagencytype').value=ds.Tables[0].Rows[0].agency_type_name
        }
        if(ds.Tables[1].Rows.length>0)
        {
            document.getElementById('txtagencystatus').value=ds.Tables[1].Rows[0].status_name;
            document.getElementById('hiddenstatus').value=ds.Tables[1].Rows[0].status_name;
         
           
        }
         if(ds.Tables[2].Rows.length>0)
        {
           document.getElementById('txtcreditperiod').value=ds.Tables[2].Rows[0].Credit_Days;
            if(ds.Tables[2].Rows[0].ALERT!=null && ds.Tables[2].Rows[0].ALERT!="")
            {
                alert(ds.Tables[2].Rows[0].ALERT);
            }
        }
         if(ds.Tables.length>7)
        {
            if(ds.Tables[7].Rows.length>0)
                document.getElementById('txtagencyoutstand').value=ds.Tables[7].Rows[0].outstand;
         }       
        if(ds.Tables[4].Rows.length>0)
        {
               if(ds.Tables[4].Rows[0].CASH_DISCOUNT1!=null)
                document.getElementById('txtcashdiscount').value=ds.Tables[4].Rows[0].CASH_DISCOUNT1;
            if(ds.Tables[4].Rows[0].CASH_DISCOUNT!=null)
                document.getElementById('txtcashdiscount').value=ds.Tables[4].Rows[0].CASH_DISCOUNT;
            if(ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1!=null)    
                document.getElementById('hiddencashrecieved').value=ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1;
            if(ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE!=null)    
                document.getElementById('hiddencashrecieved').value=ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE;
            document.getElementById('txttradedisc').value=ds.Tables[4].Rows[0].comm_rate;
            document.getElementById('hiddenagcommflag').value=ds.Tables[4].Rows[0].FLAG;
            document.getElementById('txtgrossamt').value="";
            if(ds.Tables[4].Rows[0].Addl_Comm_Rate!=null && document.getElementById('txtaddagencycommrate')!=null)
            document.getElementById('txtaddagencycommrate').value=ds.Tables[4].Rows[0].Addl_Comm_Rate;
            document.getElementById('hiddentradedisc').value=document.getElementById('txttradedisc').value;
        }
        else
        {
            alert("Please update the "+document.getElementById('txtagency').value+" Commission detail");
            document.getElementById("txtagency").value="";
            document.getElementById('txtagencytype').value="";
            document.getElementById('txtagencystatus').value="";
            document.getElementById('txtcreditperiod').value="";
            document.getElementById('txtagencypaymode').value="";
            document.getElementById('txttradedisc').value="";
             document.getElementById('hiddenagcommflag').value="";
            document.getElementById('txtgrossamt').value="";
            if(document.getElementById('txtaddagencycommrate')!=null)
             document.getElementById('txtaddagencycommrate').value="";
            //
            document.getElementById('hiddentradedisc').value="";
            document.getElementById('txtagencyaddress').value="";
            document.getElementById("txtagency").focus();
            return false;
        }
        if(ds.Tables[5].Rows.length>0)
        {
            //document.getElementById('txtagencypaymode').value=ds.Tables[5].Rows[0].payment_mode_name;
            ///this is to bind the payment drop down and bill to drop down
             var pkgitem=document.getElementById('txtagencypaymode');
             var billobj=document.getElementById('drppaymenttype');
             pkgitem.options.length = 0; 
             billobj.options.length = 0; 
               billobj.options[0]=new Option("Select","0");
             billobj.options.length;
            //billobj.options[0]=new Option("--Select City--","0");
            //alert(pkgitem.options.length);
            for (var i = 0  ; i < ds.Tables[5].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[5].Rows[i].payment_mode_name,ds.Tables[5].Rows[i].pay_mode_code);
                billobj.options[billobj.options.length] = new Option(ds.Tables[5].Rows[i].payment_mode_name,ds.Tables[5].Rows[i].pay_mode_code);
                
                billobj.options.length;
                pkgitem.options.length;
               
            }
            
              document.getElementById('txtagencypaymode').value=ds.Tables[5].Rows[0].pay_mode_code;
            document.getElementById('drppaymenttype').value=ds.Tables[5].Rows[0].pay_mode_code;
            document.getElementById('hiddenpay').value=ds.Tables[5].Rows[0].pay_mode_code;
            document.getElementById('hiddenbillpay').value=ds.Tables[5].Rows[0].pay_mode_code;
            ///if pay mode is credit card than open the card name,its type and no div
              if(document.getElementById('drppaymenttype').value=="CA0")  //CR0 is Credit Card code
            {       
                document.getElementById('cashrecvd').style.display="";
                // document.getElementById('tdcashrecvd').style.display="";
                // document.getElementById('drpcashrecieved').value=executequery.Tables[0].Rows[0].CASH_RECIEVED;
                  document.getElementById('drpcashrecieved').disabled =false;  
                  document.getElementById('txtcashdiscount').disabled =false;  
                   document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            }
            else if(document.getElementById('drppaymenttype').value=="CR0")  //CR0 is Credit Card code
        {          
            document.getElementById('tdcarname').style.display="";
            document.getElementById('tdtxtcarname').style.display="";
            document.getElementById('tdtype').style.display="";
            document.getElementById('tddrptyp').style.display="";
            document.getElementById('tdexdat').style.display="";
            
            document.getElementById('tdtxtexdat').style.display="";
            document.getElementById('tdcardno').style.display="";
            document.getElementById('tdtxtcarno').style.display="";
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            
//             document.getElementById('txtcardname').disabled=false;
//            document.getElementById('drptype').disabled=false;
//            document.getElementById('drpmonth').disabled=false;
//            document.getElementById('drpyear').disabled=false;
//            document.getElementById('txtcardno').disabled=false;
            
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";   
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none";     
             document.getElementById('cashrecvd').style.display="none";         
             
            document.getElementById("txtreceipt").value=""; 
        }
        else if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0"   || document.getElementById('drppaymenttype').value=='PO0')  //CR0 is Credit Card code and DD0 is demand draft
        {          
//            document.getElementById('ttextchqno').disabled = false;
//            document.getElementById('ttextchqdate').disabled = false;
//            document.getElementById('ttextchqamt').disabled = false;
//            document.getElementById('ttextbankname').disabled = false;
            document.getElementById('tdchqno').style.display="";
            document.getElementById('tdchqdate').style.display="";
            document.getElementById('tdchqamt').style.display="";
            document.getElementById('tdbankname').style.display="";
            
            document.getElementById('tdtextchqno').style.display="";            
            document.getElementById('tdtextchqdate').style.display="";
            document.getElementById('tdtextchqamt').style.display="";
            document.getElementById('tdtextbankname').style.display="";
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";   
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
             
             document.getElementById("txtreceipt").value=""; 
               document.getElementById('cashrecvd').style.display="none";         
        }
        else
        {
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
            
            document.getElementById('txtcardname').value="";
            document.getElementById('drptype').value="0";
            document.getElementById('drpmonth').value="0";
            document.getElementById('drpyear').value="0";
            document.getElementById('txtcardno').value="";
            document.getElementById("txtreceipt").value="";
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none";
            
            document.getElementById('ttextchqno').value="";            
            document.getElementById('ttextchqdate').value="";   
            document.getElementById('ttextchqamt').value="";   
            document.getElementById('ttextbankname').value="";   
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
              document.getElementById('cashrecvd').style.display="none";         
        }
            ///////if pay mode is check,cash or current dated chk than show the div of receipt no and hide vts and no. of invoices
//            if(ds.Tables[5].Rows[0].pay_mode_code=="CA0" || ds.Tables[5].Rows[0].pay_mode_code=="CH0" || ds.Tables[5].Rows[0].pay_mode_code=="DD0" || ds.Tables[5].Rows[0].pay_mode_code=="CA1")
//            {
//                         document.getElementById('tdrec').style.display="block";
//                         document.getElementById('receipt').style.display="block";
//                         document.getElementById('print').style.display="block";   
//                         
//////                         document.getElementById('vts').style.display="none";
//////                         document.getElementById('tdvts').style.display="none";
//////                         document.getElementById('invoice').style.display="none";
//////                         document.getElementById('tdinvoice').style.display="none";

//                         ////to generate the receipt no. auto
//                         if(document.getElementById('receipt').style.display=="block")
//                         {
//                                var pre=document.getElementById("hiddenprefix").value
//                                var suf=document.getElementById("hiddensufix").value
//                                var center="";
//                                var preferreceipt=document.getElementById('hiddenprereceipt').value;
//                                
//                                var zero="";
//                            if(ds.Tables[6].Rows.length>0  && ds.Tables[6].Rows[0].recno!=null)
//                            {
//                            
//                                var val=ds.Tables[6].Rows[0].recno;
//                                var vallen=val.toString().length;
//                                //val=parseInt(val)+1;
//                                
//                                 //var tempno = Convert.ToString(xy1);
//                                  
//                                if(preferreceipt=="1")
//                               {
//                                center=document.getElementById('txtbranch').value.substring(0,3);
//                               
//                               }
//                               else if(preferreceipt=="2")
//                               {
//                                center=document.getElementById('txtagency').value.substring(0,3);
//                               }
//                               if(vallen==0)
//                               {
//                                zero="000000";
//                               }
//                               else if(vallen==1)
//                               {
//                                zero="00000"+val;
//                               }
//                                 else if(vallen==2)
//                               {
//                                zero="0000"+val;
//                               }
//                                 else if(vallen==3)
//                               {
//                                zero="000"+val;
//                               }
//                                 else if(vallen==4)
//                               {
//                                zero="000"+val;
//                               }
//                                 else if(vallen==5)
//                               {
//                                zero="00"+val;
//                               }
//                                 else if(vallen==6)
//                               {
//                                zero="0"+val;
//                               }
//                                         document.getElementById("txtreceipt").value=center+zero;
//                                 if(preferreceipt=="3")
//                               {
//                                 document.getElementById("txtreceipt").value="";
//                                document.getElementById("txtreceipt").value=pre+val+suf;
//                               }   
//                            }
//                            else
//                            {
//                                document.getElementById("txtreceipt").value=pre+0000+suf;
//                            }
//                            
//                         }
//                         document.getElementById('hiddenreceiptno').value=document.getElementById("txtreceipt").value
//            
//            }
        }
        if(document.getElementById('txtagencystatus').value=="Banned")
        {
        alert("You Cannot book the ad with this agency");
        return false;
        
        }
        bind_agen_bill();
}

///////////////this is to bind the product name hiddenbillpay
function bindproductname_callback(response)
{
    ds=response.value;
    var pkgitem = document.getElementById("lstproduct");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Product-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
          pkgitem.options.length = 1; 
          for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
          {
               pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].prod_desc,ds.Tables[0].Rows[i].prod_cat_code);
                
               pkgitem.options.length;
               
          }
    }
    document.getElementById('txtproduct').value="";
    document.getElementById("lstproduct").value="0";
    document.getElementById("lstproduct").focus();            
    return false;

}

///this is to bind the brand on change of product

function call_bindproduct(response)
{
      ds=response.value;
      var pkgitem = document.getElementById("drpbrand");
      pkgitem.options.length=0;
      pkgitem.options[0] = new Option("-Select-","0");
      if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
      {
            pkgitem.options.length = 1; 
            //pkgitem.options[0]=new Option("--Select City--","0");
            //alert(pkgitem.options.length);
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].brand_name,ds.Tables[0].Rows[i].brand_code);
                
               pkgitem.options.length;               
            }
      }
      return false;

}

//this is to bind the list box for exec name

function bindexecname_callback(response)
{
      ds=response.value;
      var pkgitem = document.getElementById("lstexec");
      pkgitem.options.length = 0; 
      pkgitem.options[0]=new Option("-Select Exec-","0");
      if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
      {
           pkgitem.options.length = 1; 
           for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
           {
               pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name,ds.Tables[0].Rows[i].exe_no);
                
               pkgitem.options.length;
            }
            
      }
      document.getElementById('txtexecname').value="";
      document.getElementById("lstexec").value="0";
         if(document.getElementById("lstexec").style.visibility=="hidden")
            document.getElementById("lstexec").style.visibility="visible";
      document.getElementById("lstexec").focus();
      return false;
}
///this is to bind zone on change of list box of exec

function call_bindexeczone(res)
{
    var ds=res.value;
    if(ds!=null)
    {
    if(document.getElementById('drpretainer').value!='0'  && document.getElementById('drpretainer').value!='' && retexeboth!="both")
    {
        if(confirm('Are you sure you want to Take Executive'))
        {
             document.getElementById('drpretainer').value="";
             document.getElementById('txtRetainercomm').value="";
        }
        else
        {
             document.getElementById('txtexeczone').value="";
             document.getElementById('txtexecname').value="";
             return false;
        }
    }
    if(ds.Tables[0].Rows.length>0)
    {
        document.getElementById('txtexeczone').value=ds.Tables[0].Rows[0].zone_name
        document.getElementById('hiddenzone').value=document.getElementById('txtexeczone').value;
    }
    }
}

//this is to bind the bill to drop down on change of agency s code
function bind_agen_bill()
{
var compcode=document.getElementById('hiddencompcode').value
if(agencycodeglo!="undefined" && agencycodeglo!=undefined)
    Classified_Booking_temp_b.bindbillto_ag(agencycodeglo,compcode,call_bindbillto);


}


function call_bindbillto(response)
{
     ds=response.value;
     var pkgitem = document.getElementById("drpbillto");
  
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
     {
          pkgitem.options.length = 0; 
           var client_val=document.getElementById('txtclient').value;
           var client_name=document.getElementById('txtclient').value;
            if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
        {
            client_val =document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(")+1,document.getElementById('txtclient').value.length-1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
            client_name=document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
         }   
            pkgitem.options[0]=new Option(client_name,client_val);

          //pkgitem.options[0]=new Option("-Client-","client");
          for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
          {
          if(ds.Tables[0].Rows[i].bill_to=="")
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[1].Rows[0].sub_agency_code);      
          else
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].bill_to);        
              // pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].bill_to);                
               pkgitem.options.length;               
          }
            
      }
      if(ds.Tables[1].Rows.length>0)
      {
        document.getElementById("drpbillto").value=ds.Tables[1].Rows[0].sub_agency_code;
        document.getElementById('hiddenbillto').value=ds.Tables[1].Rows[0].sub_agency_code;
      }  
      return false;
}

function documentClick(event)
{
    if(document.activeElement.id.indexOf("uploadA")==0)
    {
        uploadimageall();   
    }
      else  if(document.activeElement.id.indexOf("vtsbtn")==0)
    {
        openVtsPopup(document.activeElement.id);
    }
    else if(document.activeElement.id.indexOf("upload")==0 && document.activeElement.id.indexOf("uploadA")<0)   
    {
       var n1=document.activeElement.id;
        var idnum=document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('upload',''),10)+1].cells[0].innerHTML;
       return uploadimage(n1.replace('upload','pic'),idnum,n1.replace('upload','edit'),n1.replace('upload','fil'),n1.replace('upload',''));
    }
  
    else if(document.activeElement.id.indexOf("aglist")==0)
    {
        FillSubCatinGrid();
    }    
     	  else if(document.activeElement.id.indexOf("pai")==0)
    {
		  document.getElementById('txtgrossamt').value="";
		   document.getElementById('txtbillamt').value="";
		   if(document.getElementById(document.activeElement.id).value=="Y")
		   {
		       paivar="Y";
		   }
		   else{
		     paivar="";
		   }
		   
	}
	  else if(document.activeElement.id.indexOf("splt")==0)
    {
        var n1=document.activeElement.id;
      
        var idnum=document.getElementById('gridtab').getElementsByTagName("tbody")[0].rows[parseInt(n1.replace('splt',''),10)+1].cells[0].innerHTML;
          var editid="edit"+idnum;
        opensplitedition(document.getElementById(editid).value,idnum);
    }   
    else if(document.activeElement.id.indexOf("subedi")==0)
    {
    if(document.getElementById('txttotalarea').value=="")
    {
        alert("Please fill Size");
        return false;
    }
    var n1=document.activeElement.id;
          var idnum=document.activeElement.id.replace("subedi","");
          var editid="edit"+idnum;
          var size="siz" + idnum;
          var hei="hei" + idnum;
          var wid="wid" + idnum;
            var id="Text" + idnum;
          var data="subedidata" + idnum;
          showid="sho"+idnum; 
           var insertsta="inssta" +idnum;
           var pkgcode="hiddenpckcode"+idnum;
         var showidval="";
         if(document.getElementById(showid)!=null)
            showidval=document.getElementById(showid).value;
          window.open('booking_subeditiondetail.aspx?package='+document.getElementById(pkgcode).value+'&cioid='+document.getElementById('txtciobookid').value+'&uomdesc='+document.getElementById('hiddenuomdesc').value+'&compcode='+document.getElementById('hiddencompcode').value+'&insertdate='+document.getElementById(id).value+'&width='+document.getElementById(wid).value+'&data='+document.getElementById(data).value+'&height='+document.getElementById(hei).value+'&edition='+document.getElementById(editid).value+'&insertid='+showidval+'&insertstatus='+document.getElementById(insertsta).value+'&btnstatus='+chkbtnStatus+'&totarea='+document.getElementById(size).value+'&idnum='+idnum+'&dateformat='+document.getElementById('hiddendateformat').value+'&receiptno='+document.getElementById('txtreceipt').value,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=560px,height=300px');
    }
}
function openVtsPopup(id)
{
     win = window.open('advts.aspx?id='+id+'&mode='+chkbtnStatus,'Ankur1', 'toolbar=0,resizable=0,top=244,left=210,scrollbars=yes,width=480px,height=200px'); 
                    win.focus();
}
function fillvts()
{
if(document.getElementById('txtcirrate').value=="")
{
    alert("Please Select Rate by Pressing F2");
    document.getElementById('txtcirrate').focus();
    return false;
}
else if(document.getElementById('txtciredition').value=="")
{
    alert("Please Select Edition");
    return false;
}
else if(document.getElementById('txtvts').value=="")
{
    alert("Please Select No. Of Copies");
    document.getElementById('txtvts').focus();
    return false;
}
else if(document.getElementById('txtpubdate').value=="")
{
    alert("Please Enter Publish Date");
    document.getElementById('txtpubdate').focus();
    return false;
}
var dateformat=document.getElementById('hiddendateformat').value;
  var currdate=window.opener.document.getElementById('txtdatetime').value;
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

 var pubdate=document.getElementById('txtpubdate').value;
  if(dateformat=="yyyy/mm/dd")
{
var yearfield=pubdate.split("/")[0]
var monthfield=pubdate.split("/")[1]
var dayfield=pubdate.split("/")[2]
var pubd = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=pubdate.split("/")[2]
var monthfield=pubdate.split("/")[0]
var dayfield=pubdate.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var pubd = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=pubdate.split("/")[2]
var monthfield=pubdate.split("/")[1]
var dayfield=pubdate.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var pubd = new Date(yearfield, monthfield-1, dayfield)
}
if(pubd<currd)
{
    alert("Publish Date can't be less than Current Date");
    return false;
}
    var id=document.getElementById('hiddenid').value.replace("vtsbtn","vts");
    window.opener.document.getElementById(id).value=document.getElementById('txtvts').value + "ÿ" + document.getElementById('hiddencirpub').value + "ÿ" + document.getElementById('hiddenciredi').value + "ÿ" + document.getElementById('txtcirrate').value + "ÿ" + document.getElementById('txtpubdate').value+"ÿ" + document.getElementById('txtciredition').value;
    window.close();
}
 function onloadCall()
    {
        var id=document.getElementById('hiddenid').value.replace("vtsbtn","");
        var hiddenpar=window.opener.document.getElementById('vts'+id).value;
        if(hiddenpar!=""){
            var arr=hiddenpar.split('ÿ');
            if(arr[0].toString()!=null && arr[0].toString()!="null")
                document.getElementById('txtvts').value=arr[0].toString();
            if(arr[1].toString()!=null && arr[1].toString()!="null")    
                document.getElementById('hiddencirpub').value=arr[1].toString();
            if(arr[2].toString()!=null && arr[2].toString()!="null")    
                document.getElementById('hiddenciredi').value=arr[2].toString();
            if(arr[3].toString()!=null && arr[3].toString()!="null")    
                 document.getElementById('txtcirrate').value=arr[3].toString();
            if(arr[4].toString()!="" && arr[4].toString()!=null && arr[4].toString()!="null")
            {
                var dateformat=document.getElementById('hiddendateformat').value;
               // document.getElementById('txtpubdate').value=arr[4];
               var newdate=new Date(arr[4].toString());
               var mm=parseInt(newdate.getMonth(),10)+1;
               if(mm.toString().length==1)
                    mm="0"+ mm.toString();
                if(dateformat=="yyyy/mm/dd")
                {
                document.getElementById('txtpubdate').value=newdate.getYear() + "/" + mm + "/" + newdate.getDate();
                }
                if(dateformat=="mm/dd/yyyy")

                {
                 document.getElementById('txtpubdate').value=mm + "/" + newdate.getDate() + "/" + newdate.getYear();

                }
                if(dateformat=="dd/mm/yyyy")
                {
                document.getElementById('txtpubdate').value = newdate.getDate() + "/" + mm + "/"  + newdate.getYear();
                }
            }
            if(arr.length>4)
            {
                if(arr[5].toString()!=null && arr[5].toString()!="null")  
                    document.getElementById('txtciredition').value = arr[5].toString();
            }
        }
            if(document.getElementById('hiddenmode').value=="execute")
            {
                document.getElementById('txtvts').disabled=true;
                document.getElementById('txtcirrate').disabled=true;
                document.getElementById('txtpubdate').disabled=true;
                document.getElementById('btnSubmit').disabled=true;
            }
            else
            {
                document.getElementById('txtvts').disabled=false;
                document.getElementById('txtcirrate').disabled=false;
                document.getElementById('txtpubdate').disabled=false;
                 document.getElementById('btnSubmit').disabled=false;
                 document.getElementById('txtvts').focus();
            }
    }
  function f2query(event)
 {
 if(agnf2=="Y")
 {
 if(document.activeElement.id=="txtagency")
        {
//            if(document.getElementById('txtagency').value.length <=2)
//            {
//            alert("Please Enter Minimum 3 Character For Searching.");
//            document.getElementById('txtagency').value="";
//            return false;
//            }
if(document.getElementById('txtagency').value=="")
{
if(document.getElementById("div1").style.display=="block")
        {
            document.getElementById("div1").style.display="none"
            document.getElementById('txtagency').focus();
            return false;
        }
        return false;
}
if(event.keyCode==40)
{
document.getElementById("lstagency").focus();
return false;
}
if(document.getElementById("div1").style.display=="none")
{
            document.getElementById("div1").style.display="block";
          aTag = eval( document.getElementById("txtagency"))
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
			             document.getElementById('div1').style.top=document.getElementById("txtagency").offsetTop + (toppos+15) + "px";
			             document.getElementById('div1').style.left=document.getElementById("txtagency").offsetLeft + leftpos+"px";
}			             
            /*if(browser!="Microsoft Internet Explorer")
            {
                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-20) + "px";
              /*  document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
            }
            else
            {
                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + (-25) + "px";
                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
            }*/
            Classified_Booking_temp_b.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtagency').value,bindagencyname_callback);
        
        }
  }
 }
  
  
  ////////////bhnau end