//  function clientChange()
//    {
////        var client = document.getElementById('drpclientname').value
//            var clint=document.getElementById('drpclientname').value ;            
//		     var agencyarr=clint.split("(");             
//		     var client=agencyarr[1];             
//		     client=client.replace(")","");
//        res=dealaudit.client_Change(client,document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value);
//        var ds=res.value;
//        if(ds==null)
//        {
//            alert(res.error.description);
//            return false;
//        }
//     

//       
//        return false;
//  }  
  
 var flag1="N"
  var browser=navigator.appName;
  
  function tabvalue1 (event,id)
  
{ 
if(document.activeElement.id=="cmdAddRow" || document.activeElement.id=="cmdAddRowelec" || document.activeElement.id=="drpdealon" || document.activeElement.id=="btnExit" || document.activeElement.id=="btnDelete" || document.activeElement.id=="btnlast" || document.activeElement.id=="btnnext" || document.activeElement.id=="btnprevious" || document.activeElement.id=="btnCancel" || document.activeElement.id=="btnExecute" || document.activeElement.id=="btnQuery" || document.activeElement.id=="btnModify" || document.activeElement.id=="btnNew" || document.activeElement.id=="btnSave" || document.activeElement.id=="drpindustry" || document.activeElement.id=="lstproduct" || document.activeElement.id=="txtseq"  || document.activeElement.id=="chkpatricularad"  || document.activeElement.id=="chkseqno" || document.activeElement.id=="chkmultiad" || document.activeElement.id=="chkb2b" ||  document.activeElement.id=="txtremark" || document.activeElement.id=="drppaymenttype" || document.activeElement.id=="drpservicetax" || document.activeElement.id=="txtdealvol" || document.activeElement.id=="txtdealvalue" || document.activeElement.id=="txtclosedate" || document.activeElement.id=="txtcontractdate" || document.activeElement.id=="lstretainer" || document.activeElement.id=="lstexec" || document.activeElement.id=="lstclient" || document.activeElement.id=="lstagency" || document.activeElement.id=="txtcaption" || document.activeElement.id=="txtfromdate" || document.activeElement.id=="TextBox1" || document.activeElement.id=="drpteamname" || document.activeElement.id=="drprepresentative" || document.activeElement.id=="txtexecutive" || document.activeElement.id=="txtretainer" || document.activeElement.id=="drpproduct" || document.activeElement.id=="drpclientname" || document.activeElement.id=="drpsubagcode" || document.activeElement.id=="drpagencycode" || document.activeElement.id=="drpcurr" ||  document.activeElement.id=="txtdealname" || document.activeElement.id=="drpdealtype")
{
    colName="";
}


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
            dealaudit.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('drpagencycode').value.toUpperCase(),bindagencyname_callback);
        
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
            dealaudit.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('drpclientname').value.toUpperCase(),bindclientname_callback);
        }
        
        else if(document.activeElement.id=="txtde")
        {
//            if(document.getElementById('txtde').value.length <=2)
//            {
//            alert("Please Enter Minimum 3 Character For Searching.");
//            document.getElementById('txtde').value="";
//            return false;
//            }
            colName="";
            document.getElementById("divdeal").style.display="block";
            aTag = eval( document.getElementById("txtde"))
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
			             document.getElementById('divdeal').style.top=document.getElementById("txtde").offsetTop + toppos + "px";
			             document.getElementById('divdeal').style.left=document.getElementById("txtde").offsetLeft + leftpos+"px";
			             var mod =document.getElementById('drpad').value;
            dealaudit.binddealno(document.getElementById('hiddencompcode').value,document.getElementById('txtde').value.toUpperCase(),mod,binddealno_callback);
        }
  
  }
 
 if(event.which==27)
     {
      if(document.getElementById("divcommon")!=null && document.getElementById("divcommon").style.display=="block")
      {
         document.getElementById("divcommon").style.display="none";
         try{
         document.getElementById(activeIDNo).focus();
         }
         catch(err)
         {}
         activeIDNo="";
      }   


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
         else if(document.getElementById("divdeal")!=null && document.getElementById("divdeal").style.display=="block")
        {
            document.getElementById("divdeal").style.display="none"
            document.getElementById('txtde').focus();
        }
        else
        {
        return false;
        }
        
        
        }
 
 
 
 if(event.which==13|| event.type=="click")
        {if(document.activeElement.id=="lstagency")
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

                var res=dealaudit.addclientname(page,datetime,value);
                 var id=res.value;
                 var split=id.split("+");
                 var nameagen=split[0];
                 var agenadd=split[1];
                 var branchcode=split[2];
                 
                 document.getElementById('hiddenbranchcode').value=branchcode;       
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

                
                document.getElementById('drpclientname').value=namecode;
//              
//                 clientChange();
               /* if(document.getElementById('hiddensavemod').value=="0")
                {
                    document.getElementById('txtclientadd').value=add;        
                    document.getElementById('txtclientadd').focus();
                }
                 bind_agen_bill();*/
                document.getElementById('drpclientname').focus();
                
                return false;
            }
          if(document.activeElement.id=="lstdeal")
            {
            if(document.getElementById('lstdeal').value=="0")// || document.getElementById('hiddensavemod').value=="01")
            {
                alert("Please select the agency code");
                return false;
            }
                document.getElementById("divdeal").style.display="none";
                var datetime="";
                //alert(document.getElementById('lstagency').value);
                
                 //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
                
                var page=document.getElementById('lstdeal').value;
               // document.getElementById('hiddenagency').value=page;
//                agencycodeglo=page;
//                 var value="0";

//                var res=dealaudit.addclientname(page,datetime,value);
//                 var id=res.value;
//                 var split=id.split("+");
//                 var nameagen=split[0];
//                 var agenadd=split[1];
//                        
                document.getElementById('txtde').value=page;
                deal_change();
                document.getElementById('txtde').focus();
                return false;
            }      
                
        
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
            dealaudit.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('drpagencycode').value.toUpperCase(),bindagencyname_callback);
        
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
            dealaudit.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('drpclientname').value.toUpperCase(),bindclientname_callback);
        }
   
   
   else if(document.activeElement.id=="txtde")
        {
//            if(document.getElementById('txtde').value.length <=2)
//            {
//            alert("Please Enter Minimum 3 Character For Searching.");
//            document.getElementById('txtde').value="";
//            return false;
//            }
            colName="";
            document.getElementById("divdeal").style.display="block";
            aTag = eval( document.getElementById("txtde"))
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
			             document.getElementById('divdeal').style.top=document.getElementById("txtde").offsetTop + toppos + "px";
			             document.getElementById('divdeal').style.left=document.getElementById("txtde").offsetLeft + leftpos+"px";
			                  var mod =document.getElementById('drpad').value;
            dealaudit.binddealno(document.getElementById('hiddencompcode').value,document.getElementById('txtde').value.toUpperCase(),mod,binddealno_callback);
        }
   
   }if(event.keyCode==27)
     {
      if(document.getElementById("divcommon")!=null && document.getElementById("divcommon").style.display=="block")
      {
         document.getElementById("divcommon").style.display="none";
         try{
         document.getElementById(activeIDNo).focus();
         }
         catch(err)
         {}
         activeIDNo="";
      }   


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
        
          else if(document.getElementById("divdeal")!=null && document.getElementById("divdeal").style.display=="block")
        {
            document.getElementById("divdeal").style.display="none"
            document.getElementById('txtde').focus();
        }
        else
        {
        return false;
        }
        
        
        }
         if(event.keyCode==13)
         {
         if(document.activeElement.id=="drpad")
            {
            document.getElementById("davf").focus();
            return false;
            }
            
            if(document.activeElement.id=="davf")
            {
            document.getElementById("davt").focus();
            return false;
            }
            if(document.activeElement.id=="davt")
            {
            document.getElementById("txtde").focus();
             return false;
            }
            if(document.activeElement.id=="txtde")
            {
            document.getElementById("drpagencycode").focus();
             return false;
            }
            if(document.activeElement.id=="drpagencycode")
            {
            document.getElementById("drpclientname").focus();
            return false;
            }
            if(document.activeElement.id=="drpclientname")
            {
            document.getElementById("drpat").focus();
            return false;
            }
            if(document.activeElement.id=="drpat")
            {
            document.getElementById("txtremark").focus();
             return false;
            }
            if(document.activeElement.id=="txtremark")
            {
            document.getElementById("btnsubmit").focus();
             return false;
            }
        
        }
        if(event.keyCode==13|| event.type=="click")
        { 
       
            
            
        
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

                var res=dealaudit.addclientname(page,datetime,value);
                 var id=res.value;
                 var split=id.split("+");
                 var nameagen=split[0];
                 var agenadd=split[1];
                        
                document.getElementById('drpagencycode').value=nameagen;
                document.getElementById('hiddenagency').value=agenadd;
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

                
                document.getElementById('drpclientname').value=namecode;
              
//                 clientChange();
               /* if(document.getElementById('hiddensavemod').value=="0")
                {
                    document.getElementById('txtclientadd').value=add;        
                    document.getElementById('txtclientadd').focus();
                }
                 bind_agen_bill();*/
                document.getElementById('drpclientname').focus();
                
                return false;
            }
          if(document.activeElement.id=="lstdeal")
            {
            if(document.getElementById('lstdeal').value=="0")// || document.getElementById('hiddensavemod').value=="01")
            {
                alert("Please select the Deal No ");
                return false;
            }
                document.getElementById("divdeal").style.display="none";
                var datetime="";
                //alert(document.getElementById('lstagency').value);
                
                 //alert(document.getElementById('lstagency').value);
                /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                address and if 0 than agency name and address
                @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
                
                var page=document.getElementById('lstdeal').value;
               // document.getElementById('hiddenagency').value=page;
//                agencycodeglo=page;
//                 var value="0";

//                var res=dealaudit.addclientname(page,datetime,value);
//                 var id=page.value;
//                 var split=id.split("+");
//                 var nameagen=split[0];
//                 var agenadd=split[1];
//                        
                document.getElementById('txtde').value=page;
//                agency_change();
                document.getElementById('txtde').focus();
                return false;
            }           
                
        
        }
         
   
   }}
   
   
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
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name +'+'+ds.Tables[0].Rows[i].CITYNAME+'+'+ds.Tables[0].Rows[i].Branch_code,ds.Tables[0].Rows[i].code_subcode);        
            pkgitem.options.length;       
        }
    }
    document.getElementById('drpagencycode').value="";
    document.getElementById("lstagency").value="0";
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
        var res=dealaudit.agencyChange(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,agency)
        var ds = res.value;
        if(ds==null)
        {
            alert(res.error.description);
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
		//	return false;
}


//function submclick()


//{

//var dateforma= document.getElementById('hiddendateformat').value;
//var compcode= document.getElementById('hiddencompcode').value;
//var adtype = document.getElementById('drpad').value;



//var vf;
//			if(document.getElementById('davf').value!="")
//            {
//              
//				if(document.getElementById('davf').value!="")
//				{
//				    if(dateforma=="dd/mm/yyyy")
//					{
//						var txt=document.getElementById('davf').value;
//						var txt1=txt.split("/");
//						var dd=txt1[0];
//						var mm=txt1[1];
//						var yy=txt1[2];
//						vf=mm+'/'+dd+'/'+yy;
//					}
//					else if(dateforma=="mm/dd/yyyy")
//					{
//						vf=document.getElementById('davf').value;
//					}
//								
//					else if(dateforma=="yyyy/mm/dd")
//					{
//						var txt=document.getElementById('davf').value;
//						var txt1=txt.split("/");
//						var yy=txt1[0];
//						var mm=txt1[1];
//						var dd=txt1[2];
//						vf=mm+'/'+dd+'/'+yy;
//					}
//					if(dateforma==null || dateforma=="" || dateforma=="undefined")
//					{
//						alert("dateformat  is either null or undefined");
//						vf=document.getElementById('davf').value;
//					}
//							
//				    var dt=vf;
//                    var dts=new Date(dt);
//                    var dn=new Date();
//				    if(dn<=dts)
//				    {
//				        alert("Date should be less than  current Date.");
//				        document.getElementById('davf').value="";
//				        document.getElementById('davf').focus();
//				        return false;
//    				    
//				    }
//				}
//	      }

//				if(dateforma==null || dateforma=="" || dateforma=="undefined")
//							{
//								alert("dateformat  is either null or undefined");
//								vf=document.getElementById('davf').value;
//							}		





//var vt;




//	if(document.getElementById('davt').value!="")
//            {
//              
//				if(document.getElementById('davt').value!="")
//				{
//				    if(dateforma=="dd/mm/yyyy")
//					{
//						var txt=document.getElementById('davt').value;
//						var txt1=txt.split("/");
//						var dd=txt1[0];
//						var mm=txt1[1];
//						var yy=txt1[2];
//						vt=mm+'/'+dd+'/'+yy;
//					}
//					else if(dateforma=="mm/dd/yyyy")
//					{
//						vt=document.getElementById('davt').value;
//					}
//								
//					else if(dateforma=="yyyy/mm/dd")
//					{
//						var txt=document.getElementById('davt').value;
//						var txt1=txt.split("/");
//						var yy=txt1[0];
//						var mm=txt1[1];
//						var dd=txt1[2];
//						vt=mm+'/'+dd+'/'+yy;
//					}
//					if(dateforma==null || dateforma=="" || dateforma=="undefined")
//					{
//						alert("dateformat  is either null or undefined");
//						vt=document.getElementById('davt').value;
//					}
//							
//				    var dt=vt;
//                    var dts=new Date(dt);
//                    var dn=new Date(vf);
//				    if(dts<=dn)
//				    {
//				        alert("Date should be greater than  Valid frome Date.");
//				        document.getElementById('davt').value="";
//				        document.getElementById('davt').focus();
//				        return false;
//    				    
//				    }
//				}
//	      }

//				if(dateforma==null || dateforma=="" || dateforma=="undefined")
//							{
//								alert("dateformat  is either null or undefined");
//								vt=document.getElementById('davf').value;
//							}		




//var de = document.getElementById('txtde').value;
//var at = document.getElementById('drpat').value;


//if(document.getElementById('drpagencycode').value!="" && document.getElementById('drpagencycode').value.indexOf("(")>=0 && document.getElementById('drpagencycode').value.indexOf(")")>=0)
// {var agencycodee=document.getElementById('drpagencycode').value.substring(document.getElementById('drpagencycode').value.lastIndexOf('(')+1,document.getElementById('drpagencycode').value.lastIndexOf(')'));
//   }

//if(document.getElementById('drpclientname').value!="" && document.getElementById('drpclientname').value.indexOf("(")>=0 && document.getElementById('drpclientname').value.indexOf(")")>=0)
// {var clintname=document.getElementById('drpclientname').value.substring(document.getElementById('drpclientname').value.lastIndexOf('(')+1,document.getElementById('drpclientname').value.lastIndexOf(')'));
//   }

//dealaudit.submit(compcode,adtype,vf,vt,agencycodee,clintname,de,at,dateforma)
//}

//function blank()
//{

//document.getElementById('txtde').value='';
//document.getElementById('drpad').value='print';
//document.getElementById('drpagencycode').value='';
//document.getElementById('drpclientname').value='';
//document.getElementById('davt').value='';
//document.getElementById('davf').value='';
//document.getElementById('drpat').value='0';




//}
function deleteLastRow1 ()
  {
    removeTextNodes (element.tBodies[0]);
    this.deleteRow (element.tBodies[0].childNodes.length - 1);
  }
  function deleteClickGrid1()
{
    var count=document.getElementById('tblGrid').rows.length;
    for(var i=1;i<count;i++)
    {
       element = document.getElementById ('tblGrid');
       deleteLastRow1();
    }
     addRow('','','','','','','0','0','0','0','0','','','','','','','','','','','',document.getElementById('hiddencurrency').value,'','','','','','');
    count=document.getElementById('tblGridelec').rows.length;
    for(var i=1;i<count;i++)
    {
       element = document.getElementById ('tblGridelec');
       deleteLastRow1();
    }
    addRow('','','','','','','','','','','','','','','','','','','','','','','',document.getElementById('hiddencurrency').value,'','','','','','','','','','','','','','','','');
    return false;
}

function bindGridDetails(dealcode)
{
   var res= dealaudit.bindGridDetails_Contract(document.getElementById('hiddencompcode').value,dealcode);
   var ds=res.value;
   if(ds!=null)
   {
   deleteClickGrid1();
    if(ds.Tables[0].Rows.length>0)
    {
        for(var i=0;i<ds.Tables[0].Rows.length;i++)
        {
             element = document.getElementById ('tblGrid');
            if(i>0)
            {
                addRow('','','','','','','0','0','0','0','0','','','','','','','','','','','',document.getElementById('hiddencurrency').value,'','','','','','');
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
            if(ds.Tables[0].Rows[i].DISCOUNTED!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[11].innerHTML=ds.Tables[0].Rows[i].DISCOUNTED;
            else
                document.getElementById('tblGrid').rows[i+1].cells[11].innerHTML="";   
            if(ds.Tables[0].Rows[i].DISCPER!=null)     
                document.getElementById('tblGrid').rows[i+1].cells[12].innerHTML=ds.Tables[0].Rows[i].DISCPER;
            else
                document.getElementById('tblGrid').rows[i+1].cells[12].innerHTML="";    
            if(ds.Tables[0].Rows[i].DISCTYPE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[13].innerHTML=ds.Tables[0].Rows[i].DISCTYPE;
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
                document.getElementById('tblGrid').rows[i+1].cells[27].innerHTML="";    
           
            if(ds.Tables[0].Rows[i].CONTRACTCODE!=null)    
                document.getElementById('tblGrid').rows[i+1].cells[28].innerHTML=ds.Tables[0].Rows[i].CONTRACTCODE;
            else
                document.getElementById('tblGrid').rows[i+1].cells[28].innerHTML="";     
        }
        openPrint();
    }
     if(ds.Tables[1].Rows.length>0)
    {
        for(var i=0;i<ds.Tables[1].Rows.length;i++)
        {
             element = document.getElementById ('tblGridelec');
            if(i>0)
            {
                addRow('','','','','','','','','','','','','','','','','','','','','','','',document.getElementById('hiddencurrency').value,'','','','','','','','','','','','','','','','');
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
                document.getElementById('tblGridelec').rows[i+1].cells[31].innerHTML=ds.Tables[1].Rows[i].SPN_ST_DT;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[31].innerHTML="";  
            if(ds.Tables[1].Rows[i].SPN_END_DT!=null && ds.Tables[1].Rows[i].SPN_END_DT!='Mon Jan 1 00:00:00 UTC+0530 1900')      
                document.getElementById('tblGridelec').rows[i+1].cells[32].innerHTML=ds.Tables[1].Rows[i].SPN_END_DT;
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
                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML=ds.Tables[1].Rows[i].SEQNO;
            else
                document.getElementById('tblGridelec').rows[i+1].cells[39].innerHTML="";     
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
           var resD=dealaudit.tv_paid_balance_cal(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value,channel,location,adtype,dealcode,btb,pbflag);
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
        openElectronics();
    }        
   }
   element = document.getElementById ('tblGrid'); 
   return false;  
}
function addRow ()
  {
    var objTR = document.createElement ("TR");
    var objTD = document.createElement ("TD");

    for (var i = 0; i < addRow.arguments.length; i++) 
    {
      objTD = document.createElement ("TD");
      objTD.className="tdcls";
      var str=arguments[i];
      if(str=="null" || str==null || str=="undefined")
        str="";
      objTD.appendChild (document.createTextNode ((str=="")?"":str));
      objTR.insertAdjacentElement ("beforeEnd", objTD);
    }

    objTBody = element1.tBodies [1];
    objTBody.insertAdjacentElement ("beforeEnd", objTR);

    resizeDivs ();
  }
  var intColCount = 0;
  function resizeDivs ()
  {
    for (var i = 0; i < intColCount; i++)
    {  
      var objDiv = element1.document.getElementById ("DragMark" + (i));
      var objTD = element1.tHead.childNodes[0].childNodes[i];

      if ((!objDiv) || (!objTD) || (objTD.tagName != "TD")) return;
      objDiv.style.height = (element1.tBodies[0].childNodes.length + 1) * (objTD.offsetHeight - 1);
    }
  }
  function deleteClickGrid()
{
    var count=document.getElementById('tblGrid').rows.length;
    for(var i=1;i<count;i++)
    {
       element = document.getElementById ('tblGrid');
       deleteLastRow();
    }
    addRow('','','','','','','0','0','0','0','0','','','','','','','','','','','',document.getElementById('hiddencurrency').value,'','','','','','');
    count=document.getElementById('tblGridelec').rows.length;
    for(var i=1;i<count;i++)
    {
       element = document.getElementById ('tblGridelec');
       deleteLastRow();
    }
    addRow('','','','','','','','','','','','','','','','','','','','','','','',document.getElementById('hiddencurrency').value,'','','','','','','','','','','','','','','','');
    return false;
}
function auditdeal()
{
    var j1=1;
    var i;
    var j;
    var str1="DataGrid1_ctl02_CheckBox1";
    var txtremark=document.getElementById('txtremark').value
    var userid=document.getElementById('hiddenuserid').value;
    if(document.getElementById('txtremark').value=="")
    {
        alert("Please Fill Remark")
        return false;
    }
    for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)				
    {      //alert("1")       
        if(document.getElementById(str1)!="null" && document.getElementById(str1)!=null)
        { // alert("2") 
            if(document.getElementById(str1).checked==true )
            {  // alert("3") 
            //alert(document.getElementById("DataGrid1").rows[j].cells[2].value)
                //var dealid=	document.getElementById("DataGrid1").rows[j].cells[2].innerText;
                 //var dealid=	document.getElementById("DataGrid1").rows[j].cells[2].innerHTML;
                 if(browser!="Microsoft Internet Explorer")
                 {
                 var dealid=	document.getElementById("DataGrid1").rows[j].cells[2].textContent;
                 }
                 else
                 {
                 var dealid=	document.getElementById("DataGrid1").rows[j].cells[2].innerText;
                 }
               // alert(dealid) 
                //var from_date= document.getElementById('txtvalidityfrom').value;
                //var date_format=document.getElementById('hiddenDateFormat').value;
                j1=2;
                dealaudit.updatestatus(document.getElementById('hiddencompcode').value,dealid,userid,txtremark ,"","","","","","");
            }
         
    }

    
        var  str2=str1.split('_')[1]
        //alert(str2)
        var str3=str2.split('l')[1]
        //alert(str3)
        var str4=str2.split('l')[0]
        //alert(str4)
        str3=str3
        str3=Number(str3)+1;
        if(str3>=10)
        {
        
        str1="DataGrid1_ctl"+str3+"_CheckBox1";
        //alert(str1)
        }
        else
        {
        str1="DataGrid1_ctl0"+str3+"_CheckBox1";
        //alert(str1)
        } 				                 

        }
        //alert(j1)
        if(j1==2)
        {
        //alert("7")
        alert('Deal has been Successfully Audit');
        Cancel();
        return false;
        }

        if(j1==1)
        {
        alert('Please Select atlest one CheckBox for Audit');
}

    return false;
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
			
	function foc()
	{
	document.getElementById("drpad").focus();
	if(document.getElementById('drpat').value=="2")
            {
            document.getElementById('btnaudit').disabled=false;
            }
            else
            {
            document.getElementById('btnaudit').disabled=true;
            }
	document.getElementById('tb1').style.display="block";
	return false;
		
	}		
	function binddealno_callback(response)
	{
	
	
	  ds=response.value;
    //document.getElementById('drpretainer').value="";
    var pkgitem = document.getElementById("lstdeal");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Deal-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].deal_name +'+'+ds.Tables[0].Rows[i].Deal_No,ds.Tables[0].Rows[i].Deal_No);        
            pkgitem.options.length;       
        }
    }
    document.getElementById('txtde').value="";
    document.getElementById("lstdeal").value="0";
    document.getElementById("lstdeal").focus();
    return false;
	
	
	
	}	
	
	
	
	function submclick()
	
	{
	flag1="Y";
	 if (document.getElementById('davf').value == "" ) {
         
                alert("Please Enter valid from date");
                return false;
            }

	if (document.getElementById('davt').value == "" ) {
         
                alert("Please Enter valid to date");
                return false;
            }
            if (document.getElementById('drpat').value == "0" ) {
         
                alert("Please Select Audit Type");
                return false;
            }
          
	document.getElementById('btnclear').disabled=false;
	document.getElementById('tb1').style.display="block";
	//dealaudit.setviewstatevalue();
	}	
	
	
function Cancel()
{
document.getElementById('txtde').value="";
document.getElementById('drpad').value="print";
document.getElementById('davf').value="";
document.getElementById('davt').value="";
document.getElementById('drpagencycode').value="";
document.getElementById('drpclientname').value="";

document.getElementById('txtremark').value="";
document.getElementById('drpat').value="0";
document.getElementById('btnaudit').disabled=true;

document.getElementById('tb1').style.display="none";

deleteClickGrid();
addRow('','','','','','','0','0','0','0','0','','','','','','','','','','','',document.getElementById('hiddencurrency').value,'','','','','','');


//  for(var i=0;i<ds.Tables[0].Rows.length;i++)
//        {
//             element = document.getElementById ('tblGrid');
//            if(i>0)
//            {
//                addRow('','','','','','','0','0','0','0','0','','','','','','','','','','','',document.getElementById('hiddencurrency').value,'','','','','','');
//            }
//document.getElementById('tblGrid').rows[i+1].cells[0].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[1].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[2].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[3].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[4].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[5].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[6].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[7].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[8].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[9].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[10].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[11].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[12].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[13].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[14].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[15].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[16].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[18].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[19].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[20].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[21].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[22].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[23].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[24].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[25].innerHTML="";   
//document.getElementById('tblGrid').rows[i+1].cells[26].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[27].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[28].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[29].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[30].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[31].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[32].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[33].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[34].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[35].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[36].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[37].innerHTML=""; 
//document.getElementById('tblGrid').rows[i+1].cells[38].innerHTML=""; 
//}
return false;

}

function diabel()
{


  if(document.getElementById('drpat').value=="2")
            {
            document.getElementById('btnaudit').disabled=false;
            }
            else
            {
            document.getElementById('btnaudit').disabled=true;
            }
return false;
}