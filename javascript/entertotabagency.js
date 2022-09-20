// JScript File5
var agencycodeglo;
//function bindclientname_callback(response)
//{
//         
//    ds=response.value;
//    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
//{


//var pkgitem = document.getElementById("lstclient");
//    pkgitem.options.length = 0; 
//    pkgitem.options[0]=new Option("-Select Client-","0");
//    //alert(pkgitem.options.length);
//    pkgitem.options.length = 1; 
//    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
//    {
//        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
//        
//       pkgitem.options.length;
//       
//    }
//    
//    }
//    document.getElementById('txtclient').value="";
//    document.getElementById("lstclient").value="0";
//    document.getElementById("lstclient").focus();
//    
//     return false;
//}


function bindagencyname_callback(response)
{       
    ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name+'+'+ds.Tables[0].Rows[i].CITYNAME+'+'+ds.Tables[0].Rows[i].code_subcode+'+'+ds.Tables[0].Rows[i].Agency_Code+'+'+ds.Tables[0].Rows[i].SUB_Agency_Code,ds.Tables[0].Rows[i].code_subcode);
        
       pkgitem.options.length;
       
    }
    }
    else
    {
    document.getElementById("lstagency").options.length = 0;
    }
    document.getElementById('txtagenname').value="";
    document.getElementById("lstagency").value="0";
    document.getElementById("lstagency").focus();
     return false;
}

function tabvalue(event,id)
{
    if(event.keyCode==120)
    {
       var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
       window.open("Help.aspx?formname="+formname);
      
    }
    else  if(event.keyCode==113)
    {
    if(document.activeElement.id=="selectcode")
        {
            if(document.getElementById('selectcode').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('selectcode').value="";
            return false;
            }
            document.getElementById("div2").style.display="block";
        
          aTag = eval( document.getElementById("selectcode"))
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
			             document.getElementById('div2').style.top=document.getElementById("selectcode").offsetTop + toppos + "px";
			             document.getElementById('div2').style.left=document.getElementById("selectcode").offsetLeft + leftpos+"px";
//            if(browser != "Microsoft Internet Explorer")
//            {
//                  document.getElementById('div2').style.top= 228;
//                  document.getElementById('div2').style.left= 445;
////                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + /*parseInt(document.getElementById('OuterTable').offsetTop)*/(-6) + "px";
////                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 1 + "px";
//            }
//            else
//            {
//                  document.getElementById('div2').style.top= 155;
//                  document.getElementById('div2').style.left= 390;
////                document.getElementById('div1').style.top=parseInt(document.getElementById('txtagency').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6 + "px";
////                document.getElementById('div1').style.left=parseInt(document.getElementById('txtagency').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9 + "px";
//            }
var parent=document.getElementById("drpparent").value;
            Agent_master.bindagencyname1(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('selectcode').value.toUpperCase(),"",parent,bindagencyname_callback1);
        
        }
        }
else if(event.keyCode==27)
    {
    if(document.getElementById("div2").style.display=="block")
        {
            document.getElementById("div2").style.display="none"
            document.getElementById('selectcode').focus();
        }
        }
       
if(document.getElementById('hiddenquery').value=="query")
{
if(event.keyCode==27)  
{
    document.getElementById("divagency").style.display="none";
}
else if(event.keyCode==113)  
{
 if(document.activeElement.id=="txtagenname")
    {
        document.getElementById("divagency").style.display="block";
          aTag = eval( document.getElementById("txtagenname"))
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
			             document.getElementById('divagency').style.top=document.getElementById("txtagenname").offsetTop + toppos + "px";
			             document.getElementById('divagency').style.left=document.getElementById("txtagenname").offsetLeft + leftpos+"px";
//        document.getElementById('divagency').style.top=parseInt(document.getElementById('txtagenname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen3').offsetTop) + parseInt(document.getElementById('frsttd').offsetTop) + parseInt(document.getElementById('td3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6;
//document.getElementById('divagency').style.top=parseInt(document.getElementById('txtagenname').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdagen3').offsetTop) + parseInt(document.getElementById('td3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 18;
        
      //  document.getElementById('divagency').style.left=parseInt(document.getElementById('txtagenname').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdagen3').offsetLeft) + parseInt(document.getElementById('frsttd').offsetLeft) + parseInt(document.getElementById('td3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 67;
        Agent_master.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtagenname').value,"",bindagencyname_callback);
        
    }
//    else if(document.activeElement.id=="txtclient")
//    {
//        document.getElementById("divclient").style.display="block";
//        document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6;
//        document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9;
//        Booking_master.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
//    }

}

else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
{


//alert(event.shiftKey);
//if(document.activeElement.id=="lstclient")
//    {
//       if(document.getElementById('lstclient').value=="0")
//        {
//        alert("Please select the client");
//        return false;
//        }
//        document.getElementById("divclient").style.display="none";
//        //alert(document.getElementById('lstagency').value);
//        /*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//        this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
//        address and if 0 than agency name and address
//        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22222*/
//     
//        var page=document.getElementById('lstclient').value;
//       
//         var xml = new ActiveXObject("Microsoft.XMLHTTP");
//         xml.Open( "GET","AgencyNameList.aspx?page="+page+"&value=1", false );
//         xml.Send();
//         var id=xml.responseText;
//         
//         var split=id.split("+");
//         var namecode=split[0];
//         var add=split[1];

//        
//        document.getElementById('txtclient').value=namecode;
//        document.getElementById('txtclientadd').value=add;
//        document.getElementById('txtclientadd').focus();
//        
//        //document.getElementById('txtagencyaddress').focus();
//        
//        return false;
//    }
    if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0")
        {
        alert("Please select the agency");
        return false;
        }
        document.getElementById("divagency").style.display="none";
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
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
             httpRequest.onreadystatechange = function() {alertContents_name(httpRequest) };
        
          
            httpRequest.open('GET', "AgencyNameList.aspx?page="+page+"&value=0", false);
            httpRequest.send('');
            id=httpRequest.responseText;
          
            

        }
        else if(browser=="Microsoft Internet Explorer")
        {
         
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","AgencyNameList.aspx?page="+page+"&value=0", false );
         xml.Send();
         id=xml.responseText;       
         
        
        }
         
         var split=id.split("+");
         var nameagen=split[0];
         var code=split[1];
         var agenadd1=split[2];
         var agenadd2=split[3];
         var agenadd3=split[4];
        
         
        
        document.getElementById('txtagenname').value=nameagen;
        document.getElementById('txtadd').value=agenadd1;
        document.getElementById('txtaddress1').value=agenadd2;
        document.getElementById('txtaddress2').value=agenadd3;
        document.getElementById('drpagetyp').focus();
        
        
//        Agent_master.SubAgencyBind(page,document.getElementById('hiddencompcode').value,"0",call_bindagsub);
        return false;
    }
    
    
    else if(document.activeElement.type=="button" || document.activeElement.type=="submit" )
    {
  
    event.keyCode=13;
    return event.keyCode;

    }
    else
    {
            if(event.shiftKey==false)
            {
            event.keyCode=9;
            return event.keyCode;
            }
    
    }
}
else if(event.shiftKey==true && event.keyCode==9)
{
 
 
}
else if((event.keyCode==9) && (document.activeElement.type=="button" || document.activeElement.type=="submit"))      
{   
 event.keyCode=9;
 return event.keyCode;  
}
}
else
{
    if(event.keyCode==13)
    {
    var browser=navigator.appName;
if(document.activeElement.id=="lstagency1")
    {
    if(document.getElementById('lstagency1').value=="0")// || document.getElementById('hiddensavemod').value=="01")
    {
        alert("Please select the agency code");
        return false;
    }
        document.getElementById("div2").style.display="none";
        var datetime="";
        var value="0";
        
        var page=document.getElementById('lstagency1').value;
        document.getElementById('hiddenagency').value=page;
        agencycodeglo=page;
        
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
         var res=Agent_master.addclientname(page,datetime,value);
         var id=res.value;
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd=split[1];
                
        document.getElementById('selectcode').value=nameagen;
        
        /*if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
        {
              document.getElementById('txtagencyaddress').value=agenadd;
                
              document.getElementById('txtclient').focus();
              Booking_master.bindagencusub(page,document.getElementById('hiddencompcode').value,call_bindagsub);
        }*/
        document.getElementById('selectcode').focus();
        setcode();
        return false;
    }
    else if(document.activeElement.id=="selectcode")
    {
		var a="'";
		if(document.getElementById('selectcode').value != "" && document.getElementById('selectcode').value.lastIndexOf('(')>=0)
        {
             var agency=document.getElementById('selectcode').value ;            
		     var agencyarr=agency.split("(");             
		     var agencysplit=agencyarr[1];             
		     agencysplit=agencysplit.replace(")","");
           }
           else if(document.getElementById('selectcode').value!="")
             {
             alert("Please select correct Agency by Pressing F2");
             document.getElementById('selectcode').value="";
             document.getElementById('selectcode').focus();
             return false;
             }
             else if(document.getElementById('selectcode').value=="")
             {
             alert("Please select Agency by Pressing F2");
            // document.getElementById('selectcode').value="";
             document.getElementById('selectcode').focus();
             return false;
             }
		auto=document.getElementById('hiddenauto').value;
		document.getElementById('txtagencode').disabled=true;
		
		var agencode=document.getElementById('txtagencode').value=agencysplit; //document.getElementById('selectcode').value;
		//document.getElementById('selectagencode').style.visibility="hidden";
		//document.getElementById('getagcode').value=document.getElementById('txtagencode').value;
		if(auto==1)
		{
		        var txtagenname1= document.getElementById('txtagenname').value;
		        if(txtagenname1=="")
		        {
		            alert("Please Enter Agency Name");
		            document.getElementById('txtagenname').focus();
		            document.getElementById('selectcode').value="";
		            return false;
		        }
		        if(txtagenname1.indexOf("'")>=0)
	            {
	                txtagenname1=txtagenname1.replace("'","''");
	            }
        			
        		
		        var str=txtagenname1//document.getElementById('txtagenname').value;
		        var type=document.getElementById('drpparent').value;
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
                Agent_master.chksubcode(str,agencode,type,subfillcall);
	     }
		    
		   var compcode=document.getElementById('hiddencompcode').value;
           var userid=document.getElementById('hiddenuserid').value;
           Agent_master.bindbillto(agencode,compcode,userid,call_billto);	

           Agent_master.bindbillto(agencode,compcode,userid,billtodrpcall);
           document.getElementById('drpagetyp').focus();
           document.getElementById('drpagetyp').value="0";
       	   return false;
 }
 else if(document.activeElement.id==id)
        {
          if(document.getElementById('btnSave').disabled==false)
          {
document.getElementById('btnSave').focus();
event.keyCode=13;
return event.keyCode;

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
        if(document.getElementById('selectagencode').style.visibility == "visible" && document.activeElement.id=="txtagenname")
            document.getElementById('selectcode').focus();
            else
            {
        event.keyCode=9;
        return event.keyCode;
        }
        }
    }
  }
   if(event.keyCode==9)
    {
      if(document.getElementById('selectagencode').style.visibility == "visible" && document.activeElement.id=="btnagencyname")
         {   document.getElementById('selectcode').focus();
            return false;
        }

        else if (document.activeElement.id == "selectcode") {
            if (document.getElementById('selectcode').value == "" || document.getElementById('selectcode').value != "") {

                document.getElementById('drpagetyp').focus();
                return false;
            }


        }
            
            
           else if(document.getElementById('selectcode').value=="")
             {
//                 if (document.getElementById('drpparent').value != "P") {
//                     // alert("Please select Agency by Pressing F2");
//                     // document.getElementById('selectcode').value="";
//                     //document.getElementById('drpagetyp').focus();
//                     // return false;
//                 }





             }

           
             
             
             
         }
       
}

function bindagencyname_callback1(response)
{       
    ds=response.value;
    //document.getElementById('drpretainer').value="";
    var pkgitem = document.getElementById("lstagency1");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        //alert(pkgitem.options.length);
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name +'+'+ds.Tables[0].Rows[i].CITYNAME+'+'+ds.Tables[0].Rows[i].code_subcode,ds.Tables[0].Rows[i].code_subcode);        
            pkgitem.options.length;       
        }
    }
    document.getElementById('selectcode').value="";
    document.getElementById("lstagency1").value="0";
    document.getElementById("lstagency1").focus();
    return false;
}
// no need to give this code as we are not binding the agency sub code on the basis of agency code.

function call_bindagsub(response)
{
ds=response.value;
  var pkgitem = document.getElementById("txtsagencycode");
  pkgitem.options.length=0;
    pkgitem.options[0] = new Option("-Select-","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
    pkgitem.options.length = 1; 
   
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].SUB_Agency_Code);
        
       pkgitem.options.length;
       
    }
    }
    
     return false;

}


