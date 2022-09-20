//this is for upadte and save

var browser=navigator.appName;

var currmodify="0";
// this is for f,p,n,l
var z=0;
//this is for pop up
var show="0";
//this is for popup
var code10;
var insertcomm="0";
var hiddentext;
var auto="";
var hiddentext1="";
var chk123="";
var popwin;

var dscurrencyexecute;

var modcurrname="";


////////////////////////these are the global values which are used at the time of deletion for f,p,n,l
var glcurrencycode;
var glcurrencyname;
var glcurrencyalias;
var glcurrctryname;
var countrycode;
var glSYMBOL_P;

var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;

function loadXML(xmlFile) 
{
    var  httpRequest =null;

    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }
    //cancelclick('CurrencyMaster');

}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
                //alert(response);
            }
        }
        
        var parser=new DOMParser();
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
}

function verify() 
{ 
 // 0 Object is not initialized 
 // 1 Loading object is loading data 
 // 2 Loaded object has loaded data 
 // 3 Data from object can be worked with 
 // 4 Object completely initialized 
 if (xmlDoc.readyState != 4) 
 { 
   return false; 
 } 
}


function openrate()
{
 var msg=checkSession();
            if(msg==false)
            return false;
//document.getElementById('pnl1').style.display="block";
if(	document.getElementById('lbconrate').disabled == false)	
{
		if(document.getElementById('hiddenauto').value!=1)
          {
            if(document.getElementById('txtcurrcode').value=="")
            {
            alert('Please Enter All Mandatory Fields');
            if(document.getElementById('txtcurrcode').disabled==false)
                document.getElementById('txtcurrcode').focus();
            return false;
            }
          // return false;
          }
    if(document.getElementById('txtcurrcode').value=="")
            {
            alert('Please Enter All Mandatory Fields');
            if(document.getElementById('txtcurrcode').disabled==false)
                document.getElementById('txtcurrcode').focus();
            return false;
            }
else if(document.getElementById('drpcountryname').value=="0")
{
alert("Please Enter All Mandatory Fields");
document.getElementById('drpcountryname').focus();
		
return false;
}
else if(document.getElementById('txtcurrname').value=="")
{
alert("Please Enter All Mandatory Fields");
document.getElementById('txtcurrname').focus();
		
return false;
}
else if(document.getElementById('txtalias').value=="")
{
alert("Please Enter All Mandatory Fields");
document.getElementById('txtalias').focus();
		
return false;
}
var chmandat;
if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('SYMBOL_P').textContent;
}
else
{
chmandat=document.getElementById('SYMBOL_P').innerText;
}
if(chmandat.indexOf('*')>= 0)
{
if(document.getElementById('txtSYMBOL_P').value=="0" || document.getElementById('txtSYMBOL_P').value=="")
{
alert("Please Select Currency Symbol ");
document.getElementById('txtSYMBOL_P').focus();
return false;
}
}
//------------------------------------------------------//
//======================================================//
var currcode=document.getElementById('txtcurrcode').value;
var currcode1;

    for ( var index = 0; index < 200; index++ ) 
      { 
      
    popwin=window.open('Converrate.aspx?currcode1='+currcode+'&show='+show,'Ankur','resizable=0,toolbar=0,top=244,left=210,width=780px,height=515px');
    popwin.focus();

    return false;
    }
}
return false;
}

function newclick()
{
			var msg=checkSession();
            if(msg==false)
            return false;
            
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

CurrencyMaster.blankSession();
			document.getElementById('txtcurrname').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('drpcountryname').value="0";
			document.getElementById('txtSYMBOL_P').value="";
				document.getElementById('txtcurrsymbol').value="";
			
			
			 if(document.getElementById('hiddenauto').value==1)
		 {
		  document.getElementById('txtcurrcode').disabled=true;
		  //document.getElementById('txtcurrencycode').readonly=true;
    	  }
		 else
		   {
		   document.getElementById('txtcurrcode').disabled=false;
    	   }
			document.getElementById('txtcurrname').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('drpcountryname').disabled=false;
			document.getElementById('txtSYMBOL_P').disabled=false;
			document.getElementById('txtcurrsymbol').disabled=false;
			
			    document.getElementById('drpcountryname').focus();
			

			chkstatus(FlagStatus);
			hiddentext="new";
			document.getElementById('lbconrate').disabled = false;	
		    document.getElementById('hiddenchk').value="0";
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
			show="1";
			flag=0;
			var currency="currency";
        var date1="dcancel";
        var date2="d2";
        var convrate="0";
        var insertcom="7";
   
//		var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		//xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+show, false );
//		xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+insertcomm, false );
//		xml.Send();
//		var dl=xml.responseText;
		
		setButtonImages();

			return false;
}

function modifyclick()
{
			document.getElementById('txtcurrcode').disabled=true;
			document.getElementById('txtcurrname').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('drpcountryname').disabled=true;
			document.getElementById('txtSYMBOL_P').disabled=false;
			document.getElementById('txtcurrsymbol').disabled=false;
			
			
			
             document.getElementById('hiddenchk').value="1";
		
			chkstatus(FlagStatus);
			hiddentext="modify";
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('lbconrate').disabled = false;	
		
		
			modcurrname=document.getElementById('txtcurrname').value;
			
				
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;*/
			flag=1;		

			currmodify="1";
			insertcomm="1";
           document.getElementById('btnSave').focus();
          show="1";

	   setButtonImages();
			return false;
}

function queryclick()
{
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

CurrencyMaster.blankSession();
            z=0;
			document.getElementById('txtcurrcode').value="";
			document.getElementById('txtcurrname').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('drpcountryname').value="0";
	document.getElementById('txtSYMBOL_P').value="";
		document.getElementById('txtcurrsymbol').value="";
	
			
			document.getElementById('txtcurrcode').disabled=false;
			document.getElementById('txtcurrname').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('drpcountryname').disabled=false;
	document.getElementById('txtSYMBOL_P').disabled=true;
		document.getElementById('txtcurrsymbol').value="";
	

			chkstatus(FlagStatus);
				hiddentext="query";
			document.getElementById('btnQuery').disabled=true;
	        document.getElementById('btnExecute').disabled=false;
	        document.getElementById('btnSave').disabled=true;
	        	document.getElementById('lbconrate').disabled = true;	
		document.getElementById('btnExecute').focus();
		
        	

			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;*/
			
			
		var currency="currency";
        var date1="dcancel";
        var date2="d2";
        var convrate="0";
        var insertcom="7";
   
	/*	var xml = new ActiveXObject("Microsoft.XMLHTTP");
		//xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+show, false );
		xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+insertcomm, false );
		xml.Send();
		var dl=xml.responseText;*/
		setButtonImages();
			return false;
}

function cancelclick(formname)
{   
              var msg=checkSession();
            if(msg==false)
            return false;    
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

            CurrencyMaster.blankSession();
            //chkstatus(FlagStatus);
		    //givebuttonpermission(formname);
               show="0";
			currmodify="0";
			document.getElementById('txtcurrcode').value="";
			document.getElementById('txtcurrname').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('drpcountryname').value="0";
            document.getElementById('txtSYMBOL_P').value="";
            document.getElementById('txtcurrsymbol').value="";

			document.getElementById('txtcurrcode').disabled=true;
			document.getElementById('txtcurrname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('drpcountryname').disabled=true;
			document.getElementById('txtSYMBOL_P').disabled=true;
			document.getElementById('txtcurrsymbol').disabled=true;
			
				document.getElementById('lbconrate').disabled = true;	
		
		
			
			//	givebuttonpermission(formname);
					hiddentext="clear";
	
			
			/*document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExit').disabled=false;*/

			//getPermission(formname);
				var currency="currency";
        var date1="dcancel";
        var date2="d2";
        var convrate="0";
        var insertcom="7";
   
		/*var xml = new ActiveXObject("Microsoft.XMLHTTP");
		//xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+show, false );
		xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+insertcomm, false );
		xml.Send();
		var dl=xml.responseText;*/
		setButtonImages();
		if(document.getElementById('btnNew').disable==false)
				  document.getElementById('btnNew').focus();
		
         return false;
}

function exitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
			
			if(popwin && !popwin.closed)
		    {
    		
		    popwin.close();
		    }
			window.close();
			return false;
			}
			
			return false;
}

function saveclick()
        {
            var msg=checkSession();
            if(msg==false)
            return false;
            document.getElementById('txtcurrcode').value=trim(document.getElementById('txtcurrcode').value);
            document.getElementById('txtcurrname').value=trim(document.getElementById('txtcurrname').value);
            document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
            document.getElementById('txtSYMBOL_P').value=trim(document.getElementById('txtSYMBOL_P').value);
            document.getElementById('txtcurrsymbol').value=trim(document.getElementById('txtcurrsymbol').value);
             
              if(document.getElementById('drpcountryname').value=="0")
			{
			alert("Please Select Country Name");
			document.getElementById('drpcountryname').focus();
			return false;
			}

			else if(document.getElementById('hiddenauto').value!=1)
              {
			if(document.getElementById('txtcurrcode').value=="")
			{
			alert("Please Enter The Currency Code");
			document.getElementById('txtcurrcode').focus();
			return false;
			}
			//return false;
			}
			else if(document.getElementById('txtcurrname').value=="")
			{
			alert("Please Enter Currency Name");
			document.getElementById('txtcurrname').focus();
			return false;
			}
			else if(document.getElementById('txtalias').value=="")
			{
			alert("Please Enter Alias Name");
			document.getElementById('txtalias').focus();
			return false;
			}
			var chmandat;
if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('SYMBOL_P').textContent;
}
else
{
chmandat=document.getElementById('SYMBOL_P').innerText;
}
if(chmandat.indexOf('*')>= 0)
{
if(document.getElementById('txtSYMBOL_P').value=="0" || document.getElementById('txtSYMBOL_P').value=="")
{
alert("Please Select Currency Symbol ");
return false;
}
}
			
				var txtcurcode=document.getElementById('txtcurrcode').value;
			    document.getElementById('TextBox1').value=txtcurcode;
			    //document.getElementById('hiddencode').value="1";
			   var txtcurname=document.getElementById('txtcurrname').value;
			   var txtcalias=document.getElementById('txtalias').value;
			   var drpctryname=document.getElementById('drpcountryname').value;
			   document.getElementById('hiddencountry').value=document.getElementById('drpcountryname').value;
               var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value;               
               var cursymbol=document.getElementById('txtcurrsymbol').value;			
			   var compcode=document.getElementById('hiddencompcode').value;
			   var userid=document.getElementById('hiddenuserid').value;

			
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
			if(currmodify!="1" && currmodify!=null)
			{
			var page="";
            var currency=txtcurcode;
            var date1="d1";
            var date2="d2";
            var convrate="0";
            var insertcom="7";
            var dl="";
            
            //alert(browser);
            
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+insertcomm, false );
                httpRequest.send('');
                 if (httpRequest.readyState == "yes") 
                 {
                         alert('Session Expired Please Login Again.');
                        return false;
                 }
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) 
                    {
                        dl=httpRequest.responseText;
                    }
                    else 
                    {
                         alert('Session Expired Please Login Again.');
                        return false;
                    }
                }
                else
                {
                        alert('Session Expired Please Login Again.');
                        return false;
                }
                
            }
            else
            {
		        var xml = new ActiveXObject("Microsoft.XMLHTTP");
		        //xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+show, false );
		        xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+insertcomm, false );
		        xml.Send();
		        dl=xml.responseText;
		    }
		  if(dl=="yes")
            {
                  alert('Session Expired Please Login Again.');
                        return false;
            }
//		if(dl=="add")
//            {
//                  alert('Please Fill Conversion Rate Popup.');
//                        return false;
//            }
		 if(dl=="as")
		    {
    		
		    alert("This Currency Code Is Already Assigned");
		    return false;
    		}
		  else 
		   {
		    var currency="currency";
            var date1="d1";
            var date2="d2";
            var convrate="0";
            var insertcom="7";
       
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+insertcomm, false );
                httpRequest.send('');
                 if (httpRequest.readyState == "yes") 
                 {
                         alert('Session Expired Please Login Again.');
                        return false;
                 }
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) 
                    {
                        dl=httpRequest.responseText;
                    }
                    else 
                    {
                      alert('Session Expired Please Login Again.');
                    }
                }
                else 
                {
                    alert('Session Expired.Please Login Again.');
                    return false;
                }
            }
            else
            {
		        var xml = new ActiveXObject("Microsoft.XMLHTTP");
		        //xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+show, false );
		        xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+insertcomm, false );
		        xml.Send();
		        dl=xml.responseText;
		    }
		    
		      if(dl=="yes")
	            {
	                   alert('Session Expired.Please Login Again.');
                        return false;
	            }
		    if(dl=="0")
		        {
		        alert("Please Enter The Details Of Conversion Rate");
		        return false;
        		
		        }
		}
		
			    show="1";
//			    if(browser!="Microsoft Internet Explorer")
//                {
//                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
//                }
//                else
//                {
//                    alert(xmlObj.childNodes(0).childNodes(0).text);
//                }

//			    document.getElementById('btnNew').disabled=false;
//			    document.getElementById('btnQuery').disabled=false;
//			    document.getElementById('btnCancel').disabled=false;		
//			    document.getElementById('btnExit').disabled=false;	
//			    document.getElementById('btnSave').disabled=true;
//			    document.getElementById('btnModify').disabled=true;
//			    document.getElementById('btnDelete').disabled=true;
//			    document.getElementById('btnExecute').disabled=true;
//			    document.getElementById('btnfirst').disabled=true;				
//			    document.getElementById('btnnext').disabled=true;					
//			    document.getElementById('btnprevious').disabled=true;			
//			    document.getElementById('btnlast').disabled=true;

            var txtcurrcode=document.getElementById('txtcurrcode').value;
			var txtcurrname=document.getElementById('txtcurrname').value;
			var txtalias=document.getElementById('txtalias').value;
			var drpcountryname=document.getElementById('drpcountryname').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
            var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value;
				//CurrencyMaster.checkcode(txtcurrcode,compcode,userid,call_save);
				CurrencyMaster.checkcode(txtcurrcode,compcode,userid,call_save);
				return false;
			}
			else
			{
			    if(modcurrname==document.getElementById('txtcurrname').value)
			    {
			        modifydatacurr();
			    }
			    else
			    {
                    var str=document.getElementById('txtcurrname').value;
                    var strctry=document.getElementById('drpcountryname').value;
                    CurrencyMaster.chkcurrencycode(str,strctry,fillcallmodify);			        
			    }
			}
			return false;				
}

function modifydatacurr()
{
    var txtcurrcode=document.getElementById('txtcurrcode').value;
	var txtcurrname=document.getElementById('txtcurrname').value;
	var txtalias=document.getElementById('txtalias').value;
	var drpcountryname=document.getElementById('drpcountryname').value;
	var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value;
	 var cursymbol=document.getElementById('txtcurrsymbol').value;
	
	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;

	CurrencyMaster.modify(compcode,userid,txtcurrcode,txtcurrname,txtalias,drpcountryname,txtSYMBOL_P,cursymbol);
   // CurrencyMaster.modify(txtcurrcode,txtcurrname,txtalias,drpcountryname,compcode,userid,txtSYMBOL_P,cursymbol);
	dscurrencyexecute.Tables[0].Rows[z].Curr_Code=document.getElementById('txtcurrcode').value;
    dscurrencyexecute.Tables[0].Rows[z].Curr_Name=document.getElementById('txtcurrname').value;
    dscurrencyexecute.Tables[0].Rows[z].Curr_Alias=document.getElementById('txtalias').value;
    dscurrencyexecute.Tables[0].Rows[z].Country_Code=document.getElementById('drpcountryname').value;
    dscurrencyexecute.Tables[0].Rows[z].SYMBOL=document.getElementById('txtSYMBOL_P').value;
    
     dscurrencyexecute.Tables[0].Rows[z].CURR_SYMBOL_NAME=document.getElementById('txtcurrsymbol').value;
    
    
      //	 var cursymbol=document.getElementById('txtcurrsymbol').value=dscurrencyexecute.Tables[0].Rows[0].CURR_SYMBOL_NAME; 
    

	document.getElementById('txtcurrcode').disabled=true;
	document.getElementById('txtcurrname').disabled=true;
	document.getElementById('txtalias').disabled=true;
	document.getElementById('drpcountryname').disabled=true;
	document.getElementById('txtSYMBOL_P').disabled=true;
	document.getElementById('txtcurrsymbol').disabled=true;
	
	

   updateStatus();

	flag=0;
	if(z==0)
	{
	  document.getElementById('btnfirst').disabled=true;				
      document.getElementById('btnprevious').disabled=true;					
    }
	 if(z==(dscurrencyexecute.Tables[0].Rows.length-1))
    {
       // document.getElementById('btnNext').disabled=true;
        //document.getElementById('btnLast').disabled=true;
    }
	if(browser!="Microsoft Internet Explorer")
    {
        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
    }
    else
    {
        alert(xmlObj.childNodes(0).childNodes(1).text);
    }
    
    show="0";
	//updateStatus();

//	alert("Value Updated Successfully");
	/*document.getElementById('btnNew').disabled=true;
    document.getElementById('btnSave').disabled=true;
    document.getElementById('btnModify').disabled=false;
    document.getElementById('btnDelete').disabled=false;
    document.getElementById('btnQuery').disabled=false;
    document.getElementById('btnExecute').disabled=true;
    document.getElementById('btnCancel').disabled=false;		
						
    document.getElementById('btnfirst').disabled=false;				
    document.getElementById('btnnext').disabled=false;					
    document.getElementById('btnprevious').disabled=false;			
    document.getElementById('btnlast').disabled=false;*/

	currmodify="0";
	setButtonImages();
    document.getElementById('btnModify').focus();
    return false;
}


function call_save(response)
        {
			var txtcurrcode=document.getElementById('txtcurrcode').value;
			var txtcurrname=document.getElementById('txtcurrname').value;
			var txtalias=document.getElementById('txtalias').value;
			var drpcountryname=document.getElementById('drpcountryname').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value;
			var userid=document.getElementById('hiddenuserid').value;

			var ds=response.value;

			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Currency Code Is Already Assigned");
				return false;
			}
			else
			{		
				CurrencyMaster.checkrate(txtcurrcode,compcode,userid,saveitcurr);
				return false;
			}
			return false;
        }


function saveitcurr(response)
{

			var ds=response.value;
			//if(ds.Tables[0].Rows.length <= 0)
			//{
				//alert("Please Fill The Details Of Conversion Rate");
				//return false;
			//}
			//else
			//{
				var txtcurrcode=document.getElementById('txtcurrcode').value;
				var txtcurrname=document.getElementById('txtcurrname').value;
				var txtalias=document.getElementById('txtalias').value;
				var drpcountryname=document.getElementById('drpcountryname').value;
				var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value;
				  var cursymbol=document.getElementById('txtcurrsymbol').value;
				
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				//CurrencyMaster.save(txtcurrcode, txtcurrname, txtalias, drpcountryname, compcode, userid, txtSYMBOL_P, cursymbol);
				CurrencyMaster.save(compcode, userid, txtcurrcode, txtcurrname, txtalias, drpcountryname, txtSYMBOL_P, cursymbol);
				compcode,
 
				alert("Data Saved Successfully");
				
				
				if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open( "GET","chkcurrency.aspx?currency=''&date1='d1'&date2=''&convrate=''&insertcom=''&saveconver=save&currcode="+txtcurrcode, false );
                httpRequest.send('');
                 if (httpRequest.readyState == "yes") 
                 {
                         alert('Session Expired Please Login Again.');
                        return false;
                 }
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) 
                    {
                        dl=httpRequest.responseText;
                    }
                    else 
                    {
                          alert('Session Expired Please Login Again.');
                    }
                }
                else 
                {
                    alert('Session Expired.Please Login Again.');
                    return false;
                }
                
            }
            else
            {
		        var xml = new ActiveXObject("Microsoft.XMLHTTP");
		        //xml.Open( "GET","chkcurrency.aspx?currency="+currency+"&date1="+date1+"&date2="+date2+"&convrate="+convrate+"&insertcom="+show, false );
		        xml.Open( "GET","chkcurrency.aspx?currency=''&date1=d1&date2=''&convrate=''&insertcom=''&saveconver=save&currcode="+txtcurrcode, false );
		        xml.Send();
		        dl=xml.responseText;
		    }
				
				document.getElementById('txtcurrcode').value="";
				document.getElementById('txtcurrname').value="";
				document.getElementById('txtalias').value="";
				document.getElementById('drpcountryname').value="0";
				document.getElementById('txtSYMBOL_P').value="";
				document.getElementById('txtcurrsymbol').value="";
				
				
				
			//CurrencyMaster.insert(txtconrate,txtfromdate,txtefftill,compcode,userid,txtcurrcode);


				document.getElementById('txtcurrcode').disabled=true;
				document.getElementById('txtcurrname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('drpcountryname').disabled=true;
				document.getElementById('txtSYMBOL_P').disabled=true;
					document.getElementById('txtcurrsymbol').disabled=true;

				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnExit').disabled=false;	
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;

				cancelclick('CurrencyMaster');
				//}
				return false;
}

function executeclick()
{
             var msg=checkSession();
            if(msg==false)
            return false;
			var txtcurcode=document.getElementById('txtcurrcode').value;
			
			glcurrencycode=txtcurcode;

			
			var txtcurname=document.getElementById('txtcurrname').value;
			glcurrencyname=txtcurname;
			var txtcalias=document.getElementById('txtalias').value;
			glcurrencyalias = txtcalias;
			//var drpctryname=document.getElementById('hiddencountry').value = document.getElementById('drpcountryname').value;
			var drpctryname = document.getElementById('drpcountryname').value;
			//document.getElementById('hiddencountry').value = document.getElementById('drpcountryname').value;
			glcurrctryname=drpctryname;
			var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value;
			glSYMBOL_P=txtSYMBOL_P;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
        
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

//CurrencyMaster.execute(txtcurcode,txtcurname,txtcalias,drpctryname,compcode,userid,call_execute);
              CurrencyMaster.execute(compcode, userid, txtcurcode, txtcurname, txtcalias, drpctryname, call_execute);
			updateStatus();
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();	

		
		
			
				show="0";
					hiddentext="execute";
			return false;
}

function call_execute(response)
{
		//var ds=response.value;
		dscurrencyexecute=response.value;
		if(dscurrencyexecute==null)
			{
			    alert(response.error.description);
			    return false;
			}    
		if(dscurrencyexecute.Tables[0].Rows.length < 0)
		{
			cancelclick('CurrencyMaster');
			alert("Your search criteria does not Exist");
			return false;
		}
		else
		{	
			var txtcurrcode=document.getElementById('txtcurrcode').value=dscurrencyexecute.Tables[0].Rows[0].Curr_Code;
			var txtcurrname=document.getElementById('txtcurrname').value=dscurrencyexecute.Tables[0].Rows[0].Curr_Name;
			var txtalias = document.getElementById('txtalias').value = dscurrencyexecute.Tables[0].Rows[0].Curr_Alias;
			if (dscurrencyexecute.Tables[0].Rows[0].Country_Code == "0" || dscurrencyexecute.Tables[0].Rows[0].Country_Code == null) {
			    document.getElementById('drpcountryname').value = "";
			}
			else {
			    document.getElementById('drpcountryname').value = dscurrencyexecute.Tables[0].Rows[0].Country_Code;
			}
			//var drpcountryname = document.getElementById('drpcountryname').value = dscurrencyexecute.Tables[0].Rows[0].Country_Code;

            var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value=dscurrencyexecute.Tables[0].Rows[0].SYMBOL; 
            
             	 var cursymbol=document.getElementById('txtcurrsymbol').value=dscurrencyexecute.Tables[0].Rows[0].CURR_SYMBOL_NAME; 
             	 
             	 
             	 
                	document.getElementById('lbconrate').disabled = false;
             if(dscurrencyexecute.Tables[0].Rows.length == 1)
             {
           	document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=true;	
		
             }
		   
                
                
			document.getElementById('txtcurrcode').disabled=true;
			document.getElementById('txtcurrname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('drpcountryname').disabled=true;
			document.getElementById('txtSYMBOL_P').disabled=true;
			document.getElementById('txtcurrsymbol').disabled=true;
			
			
		}
		setButtonImages();					
		return false;
}
//*******************************************************************************//
//**************************This Function For First Button*************************//
//*******************************************************************************//


function firstclick()
{
      var msg=checkSession();
            if(msg==false)
            return false;
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

             CurrencyMaster.blankSession();
			CurrencyMaster.first(call_first);
			return false;
}

function call_first(response)
{
	//	var dscurrencyexecute=response.value;
		z=0;
		var txtcurrcode=document.getElementById('txtcurrcode').value=dscurrencyexecute.Tables[0].Rows[0].Curr_Code;
		var txtcurrname=document.getElementById('txtcurrname').value=dscurrencyexecute.Tables[0].Rows[0].Curr_Name;
		var txtalias=document.getElementById('txtalias').value=dscurrencyexecute.Tables[0].Rows[0].Curr_Alias;
		var drpcountryname=document.getElementById('drpcountryname').value=dscurrencyexecute.Tables[0].Rows[0].Country_Code;
        var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value=dscurrencyexecute.Tables[0].Rows[0].SYMBOL;
        
        var cursymbol=document.getElementById('txtcurrsymbol').value=dscurrencyexecute.Tables[0].Rows[0].CURR_SYMBOL_NAME; 
             	 
        
		updateStatus();

	document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
		setButtonImages();	
		return false;
}
//*******************************************************************************//
//**************************This Function For Last Button*************************//
//*******************************************************************************//

function lastclick()
{
 var msg=checkSession();
            if(msg==false)
            return false;
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

CurrencyMaster.blankSession();
		CurrencyMaster.first(call_last);
		return false;
}

function call_last(response)
{
		//var dscurrencyexecute=response.value;
		var y=dscurrencyexecute.Tables[0].Rows.length;
		var a=y-1;
		z=a;

		var txtcurrcode=document.getElementById('txtcurrcode').value=dscurrencyexecute.Tables[0].Rows[a].Curr_Code;
		var txtcurrname=document.getElementById('txtcurrname').value=dscurrencyexecute.Tables[0].Rows[a].Curr_Name;
		var txtalias=document.getElementById('txtalias').value=dscurrencyexecute.Tables[0].Rows[a].Curr_Alias;
		var drpcountryname=document.getElementById('drpcountryname').value=dscurrencyexecute.Tables[0].Rows[a].Country_Code;
        var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value=dscurrencyexecute.Tables[0].Rows[a].SYMBOL;
          var cursymbol=document.getElementById('txtcurrsymbol').value=dscurrencyexecute.Tables[0].Rows[a].CURR_SYMBOL_NAME; 
       
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
		return false;
}
//*******************************************************************************//
//**************************This Function For Previous Button*************************//
//*******************************************************************************//

function previousclick()
{
 var msg=checkSession();
            if(msg==false)
            return false;
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

CurrencyMaster.blankSession();
CurrencyMaster.first(call_previous);
return false;
}

function call_previous(response)
{
//var dscurrencyexecute=response.value;
var a=dscurrencyexecute.Tables[0].Rows.length;

z--;
if(z>a)
{
	document.getElementById('btnfirst').disabled=false;				
	document.getElementById('btnnext').disabled=true;					
	document.getElementById('btnprevious').disabled=false;			
	document.getElementById('btnlast').disabled=true;
	setButtonImages();
	return false;
}
		
if(z != -1  )
		{
			if(z >= 0 && z < a )
			{
			var txtcurrcode=document.getElementById('txtcurrcode').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Code;
            var txtcurrname=document.getElementById('txtcurrname').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Name;
            var txtalias=document.getElementById('txtalias').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Alias;
			var drpcountryname=document.getElementById('drpcountryname').value=dscurrencyexecute.Tables[0].Rows[z].Country_Code;
			var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value=dscurrencyexecute.Tables[0].Rows[z].SYMBOL;
			  var cursymbol=document.getElementById('txtcurrsymbol').value=dscurrencyexecute.Tables[0].Rows[z].CURR_SYMBOL_NAME; 
       
				updateStatus();
				document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
			}
			else
			{
				document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
			}
		}
		else
			{
				document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
			}
		
			if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
		setButtonImages();
			return false;
}
//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//

function nextclick()
{
 var msg=checkSession();
            if(msg==false)
            return false;
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

CurrencyMaster.blankSession();
CurrencyMaster.first(call_next);
return false;
}

function call_next(response)
{
//var dscurrencyexecute=response.value;
var a=dscurrencyexecute.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		
			var txtcurrcode=document.getElementById('txtcurrcode').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Code;
            var txtcurrname=document.getElementById('txtcurrname').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Name;
            var txtalias=document.getElementById('txtalias').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Alias;
			var drpcountryname=document.getElementById('drpcountryname').value=dscurrencyexecute.Tables[0].Rows[z].Country_Code;
			var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value=dscurrencyexecute.Tables[0].Rows[z].SYMBOL;
			
			var cursymbol=document.getElementById('txtcurrsymbol').value=dscurrencyexecute.Tables[0].Rows[z].CURR_SYMBOL_NAME; 
             	
			
			
			updateStatus();
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
			else
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
		}	
	}
		else
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
		}	
			if(z==a-1)
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		setButtonImages();
		return false;
}

function deleteclick()
{//debugger;
 var msg=checkSession();
            if(msg==false)
            return false;
var txtcurrcode=document.getElementById('txtcurrcode').value;
var txtcurrname=document.getElementById('txtcurrname').value;
var txtalias=document.getElementById('txtalias').value;
var drpcountryname=document.getElementById('drpcountryname').value;
var txtSYMBOL_P=document.getElementById('txtSYMBOL_P').value;

  var cursymbol=document.getElementById('txtcurrsymbol').value;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if(confirm("Are You Sure You want to delete this?"))
	{
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
CurrencyMaster.deleteit(txtcurrcode,compcode,userid);
	//alert("Data Deleted Sucessfuly");
	if(browser!="Microsoft Internet Explorer")
    {
        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
    }
    else
    {
        alert(xmlObj.childNodes(0).childNodes(2).text);
    }
	
	CurrencyMaster.execute(glcurrencycode,glcurrencyname,glcurrencyalias,glcurrctryname,compcode,userid,call_delete);

	//CurrencyMaster.first(call_delete);

	}

return false;
}

function call_delete(response)
{
 dscurrencyexecute=response.value;
	var a=dscurrencyexecute.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
	alert("There Is No Data to be deleted");
	
	document.getElementById('txtcurrcode').value="";
	document.getElementById('txtcurrname').value="";
	document.getElementById('txtalias').value="";
	document.getElementById('drpcountryname').value="0";
	document.getElementById('txtSYMBOL_P').value="";
	document.getElementById('txtcurrsymbol').value="";
	
	cancelclick('CurrencyMaster');
	}
	
	else if(z==-1 ||z>=a )
	{
			document.getElementById('txtcurrcode').value=dscurrencyexecute.Tables[0].Rows[0].Curr_Code;
          document.getElementById('txtcurrname').value=dscurrencyexecute.Tables[0].Rows[0].Curr_Name;
         document.getElementById('txtalias').value=dscurrencyexecute.Tables[0].Rows[0].Curr_Alias;
		document.getElementById('drpcountryname').value=dscurrencyexecute.Tables[0].Rows[0].Country_Code;
		 document.getElementById('txtSYMBOL_P').value=dscurrencyexecute.Tables[0].Rows[0].SYMBOL;
		  document.getElementById('txtcurrsymbol').value=dscurrencyexecute.Tables[0].Rows[0].CURR_SYMBOL_NAME;
		 
	}
	else
	{
			document.getElementById('txtcurrcode').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Code;
           document.getElementById('txtcurrname').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Name;
           document.getElementById('txtalias').value=dscurrencyexecute.Tables[0].Rows[z].Curr_Alias;
			document.getElementById('drpcountryname').value=dscurrencyexecute.Tables[0].Rows[z].Country_Code;
	        document.getElementById('txtSYMBOL_P').value=dscurrencyexecute.Tables[0].Rows[z].SYMBOL;
	          document.getElementById('txtcurrsymbol').value=dscurrencyexecute.Tables[0].Rows[z].CURR_SYMBOL_NAME;
	        
	}
	setButtonImages();
	return false;
}


//////////////this is for pop up

function submitclick()
{
 var msg=checkSession();
            if(msg==false)
            return false;
var fromdate=document.getElementById('txteffrate').value;
		var todate=document.getElementById('txtefftill').value;
		document.getElementById('hidfrom').value=fromdate;
		document.getElementById('hidto').value=todate;
		var txtfromdate="";
		var txtefftill="";
//		var fdate=new Date(fromdate);
//		var tdate=new Date(todate);
		var currdate=new Date();




//else if(fdate > tdate)
//{
//alert("Valid To Date Should Be Greater Than Valid From Date");
//document.getElementById('txtefftill').focus();
//return false;
//}

var txtconrate=document.getElementById('txtconrate').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var currcode=document.getElementById('hiddencurrcode').value; 
var conv_currency=document.getElementById('drpcurrency').value; 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txteffrate').value != "")
{
var txt=document.getElementById('txteffrate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
txtfromdate=document.getElementById('txteffrate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txteffrate').value!="")
{
var txt=document.getElementById('txteffrate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
txtfromdate=document.getElementById('txteffrate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
txtfromdate=document.getElementById('txteffrate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
txtfromdate=document.getElementById('txteffrate').value;

}
//this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtefftill').value != "")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
txtefftill=document.getElementById('txtefftill').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtefftill').value!="")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
txtefftill=document.getElementById('txtefftill').value;
}
}


if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txtefftill').value;
}

var fdate=new Date(txtfromdate);
var tdate=new Date(txtefftill);

if(document.getElementById('txtconrate').value=="")
{
alert("Please Enter  Convert Rate");
document.getElementById('txtconrate').focus();
return false;
}
else if(document.getElementById('txtconrate').value=="")
{
alert("Please Enter  Convert Rate");
document.getElementById('txtconrate').focus();
return false;
}

else if(document.getElementById('drpcurrency').value=="" || document.getElementById('drpcurrency').value=="0")
{
alert("Please Enter  Currency");
document.getElementById('drpcurrency').focus();
return false;
}
//else if(fdate < currdate)
//{
//alert("Valid From Date should be greater than Current date ");
//document.getElementById('txteffrate').focus();
//return false;
//}

else if(document.getElementById('txtefftill').value=="")
{
alert("Please Enter  Valid To Date");
document.getElementById('txtefftill').focus();
return false;
}
    
else if(fdate > tdate)
{
    alert("Valid To Date Should Be Greater Than Valid From Date");
    document.getElementById('txtefftill').focus();
    return false;
}
if(document.getElementById('txtunit').value=="")
{
alert("Please Enter  Unit");
document.getElementById('txtunit').focus();
return false;
}

if(insertcomm!="1" && insertcomm!=null)
{
var page="";
        var currency=currcode;
        var date1="";
        var date2="";
        var convrate="";
        
        var dl="";
            
            
            
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                httpRequest.overrideMimeType('text/xml'); 
                }
                
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
     
                httpRequest.open( "GET","chkcurrency.aspx?currency="+currcode+"&date1="+txtfromdate+"&date2="+txtefftill+"&convrate="+txtconrate+"&insertcom="+insertcomm, false );
                httpRequest.send('');
                 if (httpRequest.readyState == "yes") 
                 {
                         alert('Session Expired Please Login Again.');
                        return false;
                 }

                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
                    if (httpRequest.status == 200) 
                    {
                        dl=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('Session Expired Please Login Again.');
                    }
                }
                 else 
                    {
                        alert('Session Expired.Please Login Again.');
                        return false;
                    }

            }
            else
            {
        
		        var xml = new ActiveXObject("Microsoft.XMLHTTP");
		        xml.Open( "GET","chkcurrency.aspx?currency="+currcode+"&date1="+txtfromdate+"&date2="+txtefftill+"&convrate="+txtconrate+"&insertcom="+insertcomm+"&conv_currency="+conv_currency, false );
		        xml.Send();
		        dl=xml.responseText;
		    
		    }
		
		
		  if(dl=="yes")
            {
               alert('Session Expired.Please Login Again.');
                return false;
            }
		if(dl=="Y")
	        {
	        alert("Issue Date has already been assigned ");
	        return false;
	        }
	/*else
	{
	opener.document.getElementById('hiddencurrate').value=txtconrate;
	
    opener.document.getElementById('hiddenfromdate').value=txtfromdate;
    opener.document.getElementById('hiddentilldate').value=txtefftill;
	
	}*/





    //var xml=new ActiveXObject("Microsoft.XMLHTTP");
    if  (opener.document.getElementById('hiddenchk').value=="1")
    {
        Converrate.chkinsert(compcode, userid, txtconrate, txtfromdate, txtefftill, currcode, conv_currency, call_insert);
        //Converrate.chkinsert(txtconrate,txtfromdate,txtefftill,compcode,userid,currcode,conv_currency,call_insert);
       
        }
    else
        {
        return;
        }
}
else
{
    Converrate.chkupdate(compcode, userid, txtconrate, txtfromdate, txtefftill, currcode, code10, currency, call_update);
//Converrate.update(txtconrate,txtfromdate,txtefftill,compcode,userid,currcode,code10);
document.getElementById('btndelete').disabled=true;
//insertcomm="0";

  }
 return false;
}
function selectclick(ab)
 {
var id=ab;
if(document.getElementById(id).checked==false)
 {
   document.getElementById('txtconrate').value="";
   document.getElementById('txteffrate').value="";
   document.getElementById('txtefftill').value="";
   document.getElementById('drpcurrency').value="0";
   document.getElementById('txtunit').value="";
   document.getElementById('btndelete').disabled=true;
   document.getElementById(id).checked=false;
   insertcomm="0";
   return;
   }
    var compcode=document.getElementById('hiddencompcode').value; 
    var userid=document.getElementById('hiddenuserid').value; 
    var datagrid=document.getElementById('DataGrid2');
    var currcode=document.getElementById('hiddencurrcode').value

    var j;
    var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById('DataGrid2').rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid2__ctl_CheckBox1"+j;
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
	if(document.getElementById('hiddenshow').value=="1")
	{
	document.getElementById('btndelete').disabled=false;
	}
	document.getElementById(ab).checked=true;
	
	Converrate.selected(compcode, userid, currcode, code10, call_select12);
	
	return ;
	
	}
	else if(k==0)
	{
	//chk123.checked=false;
	document.getElementById('txtconrate').value="";
    document.getElementById('txteffrate').value="";
    document.getElementById('txtefftill').value="";
    document.getElementById('txtunit').value="";
    document.getElementById('drpcurrency').value="0";
	return false;
	}
	document.getElementById(ab).checked=true;
	
	return;
	//return false;
}

function call_select12(response)
{
var ds=response.value;
insertcomm="1";
var txtconrate=document.getElementById('txtconrate').value=ds.Tables[0].Rows[0].Conv_Rate;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
if(ds.Tables[0].Rows[0].UNIT != null && ds.Tables[0].Rows[0].UNIT != "")
	{
	    document.getElementById('txtunit').value=ds.Tables[0].Rows[0].UNIT;
	}
	else
	{
	 document.getElementById('txtunit').value="";
	}

if(ds.Tables[0].Rows[0].CONV_CURRENCY != null && ds.Tables[0].Rows[0].CONV_CURRENCY != "")
	{
	    document.getElementById('drpcurrency').value=ds.Tables[0].Rows[0].CONV_CURRENCY;
	}
	else
	{
	    document.getElementById('drpcurrency').value="0";
	}
//this is for from date

if(ds.Tables[0].Rows[0].Valid_From_Date != null && ds.Tables[0].Rows[0].Valid_From_Date != "")
	{

	var enrolldate=ds.Tables[0].Rows[0].Valid_From_Date;
			var dd=enrolldate.getDate();
			var mm=enrolldate.getMonth() + 1;
			var yyyy=enrolldate.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			document.getElementById('txteffrate').value=enrolldate1;
	}
	else
	{
	document.getElementById('txteffrate').value="";
	}
	
	//this for till date
	
	if(ds.Tables[0].Rows[0].Valid_Till_Date != null && ds.Tables[0].Rows[0].Valid_Till_Date != "")
	{

	var enrolldatet=ds.Tables[0].Rows[0].Valid_Till_Date;
			var dd=enrolldatet.getDate();
			var mm=enrolldatet.getMonth() + 1;
			var yyyy=enrolldatet.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1t=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1t=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1t=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1t=mm+'/'+dd+'/'+yyyy;
			}
			document.getElementById('txtefftill').value=enrolldate1t;
	}
	else
	{
	document.getElementById('txtefftill').value="";
	}


return false;
}

function deletegridclick()
{
 var msg=checkSession();
            if(msg==false)
            return false;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var currcode=document.getElementById('hiddencurrcode').value; 

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
Converrate.deletegrid(currcode,compcode,userid,code10);

window.location=window.location;
return false;
}

function clearclick()
{
document.getElementById('txtefftill').value="";
document.getElementById('txteffrate').value="";
document.getElementById('txtconrate').value="";
document.getElementById('drpcurrency').value="0";
 if(chk123.checked==true)
 {
 chk123.checked=false;
 }
return false;
}
function call_insert(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("This Date Has Been Assigned");
	return false;
	}
	else
		{
var txtconrate=document.getElementById('txtconrate').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var currcode=document.getElementById('hiddencurrcode').value; 
var currency=document.getElementById('drpcurrency').value; 
var txtunit=document.getElementById('txtunit').value; 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txteffrate').value != "")
{
var txt=document.getElementById('txteffrate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txteffrate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txteffrate').value!="")
{
var txt=document.getElementById('txteffrate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txteffrate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtfromdate=document.getElementById('txteffrate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtfromdate=document.getElementById('txteffrate').value;
}

//this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtefftill').value != "")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txtefftill').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtefftill').value!="")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txtefftill').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txtefftill').value;
}
Converrate.insert(compcode, userid, txtconrate, txtfromdate, txtefftill, currcode, currency, txtunit);
//Converrate.insert(txtconrate,txtfromdate,txtefftill,compcode,userid,currcode,currency,txtunit);		
//
document.getElementById('txtconrate').value="";
document.getElementById('txteffrate').value="";
document.getElementById('txtefftill').value="";
document.getElementById('drpcurrency').value="0";
document.getElementById('txtunit').value="";

		}
		window.location=window.location
		return false;
}

function call_update(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("This Date Has Been Assigned");
	insertcomm="1";
	return false;
	}
	else
		{
insertcomm="0";
var txtconrate=document.getElementById('txtconrate').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 
var currcode=document.getElementById('hiddencurrcode').value; 
var currency=document.getElementById('drpcurrency').value; 
var unit=document.getElementById('txtunit').value; 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txteffrate').value != "")
{
var txt=document.getElementById('txteffrate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txteffrate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txteffrate').value!="")
{
var txt=document.getElementById('txteffrate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txteffrate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtfromdate=document.getElementById('txteffrate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtfromdate=document.getElementById('txteffrate').value;
}

//this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtefftill').value != "")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txtefftill').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtefftill').value!="")
{
var txt=document.getElementById('txtefftill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txtefftill').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txtefftill').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txtefftill').value;
}	

Converrate.update(txtconrate,txtfromdate,txtefftill,compcode,userid,currcode,code10,currency,unit);	
		}
		window.location=window.location
		return false;
}

function autoornot()
 {
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    return false;
    }
else
    {
    userdefine();

    //return false;
    }
//return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )
			{
	
            uppercase3();
           
           }
            else
            {
            document.getElementById('txtcurrname').value=document.getElementById('txtcurrname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		     document.getElementById('txtcurrname').value=trim(document.getElementById('txtcurrname').value);
         
		    if(document.getElementById('txtcurrname').value!="" && document.getElementById('drpcountryname').value!="0")
               {
		document.getElementById('txtcurrname').value=document.getElementById('txtcurrname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtcurrname').value;

		 str=document.getElementById('txtcurrname').value;
		 strctry=document.getElementById('drpcountryname').value;
		CurrencyMaster.chkcurrencycode(str,strctry,fillcall);
		  return false;
		}
		else if (document.getElementById('drpcountryname').value=="0")
		{
		//alert("Please Select Country Name");
		document.getElementById('drpcountryname').focus();
    		
		
		return false;
		}
//		else if(document.getElementById('drpcountryname').value!="0")
//		{
//	//	 str=document.getElementById('txtcurrname').value;
//         strctry=document.getElementById('drpcountryname').value;
//		CurrencyMaster.chkcurrencycodectry(strctry,fillcallctry);
//		  return false;
//		}
//		
		return false;
		
}

function chkdupCurr()
{
    
}
function fillcallctry(res)
		{
		var ds=res.value;
		
			
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("Currency has been already assigned for this Country");
		     document.getElementById('txtcurrcode').value="";
	       
		    document.getElementById('txtcurrname').value="";
	        document.getElementById('txtalias').value="";
			document.getElementById('drpcountryname').value="0";
	        document.getElementById('txtSYMBOL_P').value="";
		    
		    document.getElementById('drpcountryname').focus();
    		
		    return false;
		    }
		    else  if(document.getElementById('hiddenauto').value!=1)
              {
              document.getElementById('drpcountryname').focus();
               return false;
            }
            else if(document.getElementById('hiddenauto').value==1)
            {
              document.getElementById('drpcountryname').focus();
               return false;
            }
             
		 
		    return false;
	}	    

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("Currency has already assigned for this Country!! ");
		    document.getElementById('txtcurrcode').value="";
		    document.getElementById('txtcurrname').value="";
	        document.getElementById('txtalias').value="";
	        document.getElementById('txtSYMBOL_P').value="";
			//document.getElementById('drpcountryname').value="0";
	
		    
		    document.getElementById('txtcurrname').focus();
    		
		    return false;
		    }
		
		        else
		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Curr_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                      //   document.getElementById('txtcurrname').value=trim(document.getElementById('txtcurrname').value);
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        document.getElementById('txtcurrcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                       
		                          document.getElementById('txtcurrcode').value=str.substr(0,2)+ "0";
		                      //    alert(document.getElementById('txtcurrcode').value);
		                          }
		     }
	return ;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
            document.getElementById('txtcurrcode').disabled=false;
            document.getElementById('txtcurrname').value=document.getElementById('txtcurrname').value.toUpperCase();
            document.getElementById('txtalias').value=document.getElementById('txtcurrname').value;
            auto=document.getElementById('hiddenauto').value;
            var str=document.getElementById('txtcurrname').value;
            var strctry=document.getElementById('drpcountryname').value;
            CurrencyMaster.chkcurrencycode(str,strctry,fillcalluserdefine);
            return false;
        }

//return false;
}

function fillcalluserdefine(res)
{
    var ds=res.value;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length!=0)
        {
            alert("Currency has already assigned for this Country!! ");
            document.getElementById('txtcurrname').value="";
            document.getElementById('txtalias').value="";
            //document.getElementById('drpcountryname').value="0";


            document.getElementById('txtcurrname').focus();

            return false;
        }
    }
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
function getsave()
{

alert("Data Saved Sucessfullly");
return false;
}


///////////////sorting of a drop down

function keySort(dropdownlist,caseSensitive) {
  // check the keypressBuffer attribute is defined on the dropdownlist 
  var undefined; 
  if (dropdownlist.keypressBuffer == undefined) { 
    dropdownlist.keypressBuffer = ''; 
  } 
  // get the key that was pressed 
  var key = String.fromCharCode(window.event.keyCode); 
  dropdownlist.keypressBuffer += key;
  if (!caseSensitive) {
    // convert buffer to lowercase
    dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
  }
  // find if it is the start of any of the options 
  var optionsLength = dropdownlist.options.length; 
  for (var n=0; n<optionsLength; n++) { 
    var optionText = dropdownlist.options[n].text; 
    if (!caseSensitive) {
      optionText = optionText.toLowerCase();
    }
    if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0) { 
      dropdownlist.selectedIndex = n; 
      return false; // cancel the default behavior since 
                    // we have selected our own value 
    } 
  } 
  // reset initial key to be inline with default behavior 
  dropdownlist.keypressBuffer = key; 
  return true; // give default behavior 
} 
/////////////////////////////////////////////////////////////////////////////
function RetCheckdate_currfrm(input)
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
		document.getElementById('txteffrate').value="";
		return false;
	}
}

/////////////////////////////////////////////////////////////////////////////
function RetCheckdate_currtill(input)
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
		document.getElementById('txtefftill').value="";
		return false;
	}
}

function allamountbullet(ab)
		{
		//var fld =document.getElementById(ab).value;
		var fld=ab.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,2})?$/i))
			{
			return true;
			}
			else
			{
			alert("input error");
			document.getElementById('txtconrate').value="";
			//document.getElementById(ab).focus();
			document.getElementById('txtconrate').focus();
			ab.focus();
			return false;
			}
			
			}
	return true;
		}
		
		
		
		
function alertContents(httpRequest) 
{
    
    if (httpRequest.readyState == 4) 
    {
        if (httpRequest.status == 200) 
        {
              var flag=httpRequest.responseText;
        }
        else 
        {
            alert('There was a problem with the request.');
        }
    }

}


function fillcallmodify(res)
{
    var ds=res.value;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length!=0)
        {
            alert("Currency has already assigned for this Country!! ");
            document.getElementById('txtcurrname').value="";
            document.getElementById('txtalias').value="";
            //document.getElementById('drpcountryname').value="0";


            document.getElementById('txtcurrname').focus();

            return false;
        }
        modifydatacurr();
    }
}
function chkdupCurr()
{
document.getElementById('txtcurrcode').value=document.getElementById('txtcurrcode').value.toUpperCase();
    if(hiddentext=="new" )
    {
    	var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
    var res=CurrencyMaster.checkcode( document.getElementById('txtcurrcode').value,compcode,userid);
    if(res.value!=null)
    {
        if(res.value.Tables[0].Rows.length>0)
        {
            alert("This Currency Code already Exist");
            if(document.getElementById('txtcurrcode').disabled==false)
            document.getElementById('txtcurrcode').value="";
                document.getElementById('txtcurrcode').focus();
            return false;
        }
    }
    }
}
function capsAlias()
{
     document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
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