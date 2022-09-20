// JScript File

var mod="0";
var z="0";
var hiddentext;
var auto="";
var hiddentext1="";
var a;
var dsbillexecute;
var y;
var dsbilldelete;
////////////////////////these are the global values which are used at the time of deletion for f,p,n,l
var glaobalbillid;
var glaobalbillstatus;
var glaobalbillalias;
var chknamemod;
var name_modify="";


//var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
//		var xmlObj;
//        function loadXML(xmlFile) 
//         { 
//            xmlDoc.async="false"; 
//            xmlDoc.onreadystatechange=verify; 
//            xmlDoc.load(xmlFile); 
//            xmlObj=xmlDoc.documentElement; 
//           // alert(xmlObj.childNodes(0).childNodes(0).text);  
//            
//          }
//          
//          function verify() 
//{ 
// // 0 Object is not initialized 
// // 1 Loading object is loading data 
// // 2 Loaded object has loaded data 
// // 3 Data from object can be worked with 
// // 4 Object completely initialized 
// if (xmlDoc.readyState != 4) 
// { 
//   return false; 
// } 
//}

//*******************************************************************************//
//**************************This Function For New Button*************************//
//*******************************************************************************//
function billnewclick()
{
   var msg=checkSession();
        if(msg==false)
        return false;
				document.getElementById('txtbillid').value="";
				document.getElementById('txtbillstatus').value="";	
				document.getElementById('txtbillalias').value="";
				 if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtbillid').disabled=true;
    	          }
		         else
		           {
		           document.getElementById('txtbillid').disabled=false;
    	           }
				
				document.getElementById('txtbillstatus').disabled=false;
				document.getElementById('txtbillalias').disabled=false;
				
				
				if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtbillstatus').focus();
    	          }
		         else
		           {
		            if(document.getElementById('txtbillid').disabled==false)
		                document.getElementById('txtbillid').focus();
    	           }
				
				/*document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=false;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExit').disabled=false;*/
				
				//chkstatus(FlagStatus);
				hiddentext="new";
			chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		setButtonImages();
				return false;

}



//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function billmodifyclick()
{

				document.getElementById('txtbillid').disabled=true;
				document.getElementById('txtbillstatus').disabled=false;
				document.getElementById('txtbillalias').disabled=false;
				
				
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').focus();
				//document.getElementById('btnModify').disabled=false;
				
				chknamemod=	document.getElementById('txtbillstatus').value;
				
				name_modify=document.getElementById('txtbillstatus').value;
			//document.getElementById('btnSave').disabled = false;
			//document.getElementById('btnQuery').disabled=true;

				mod="1";
				 hiddentext="mod";	
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
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnModify').disabled=true;*/
				setButtonImages();
				return false;
}

//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//

function billqueryclick()
{
				document.getElementById('txtbillid').value="";
				document.getElementById('txtbillstatus').value="";	
				document.getElementById('txtbillalias').value="";
				z=0;
				document.getElementById('txtbillid').disabled=false;
				document.getElementById('txtbillstatus').disabled=false;
				document.getElementById('txtbillalias').disabled=false;
				
				chkstatus(FlagStatus);
            				
	            document.getElementById('btnQuery').disabled=true;
	            document.getElementById('btnExecute').disabled=false;
	            document.getElementById('btnSave').disabled=true;
	            document.getElementById('btnExecute').focus();
				hiddentext="query";
				
				/*document.getElementById('btnNew').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExecute').disabled=false;*/
setButtonImages();
			
				return false;
}
//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//


function billcancelclick(formname)
{
                chkstatus(FlagStatus);
                givebuttonpermission(formname);
				document.getElementById('txtbillid').value="";
				document.getElementById('txtbillstatus').value="";	
				document.getElementById('txtbillalias').value="";
				
				document.getElementById('txtbillid').disabled=true;
				document.getElementById('txtbillstatus').disabled=true;
				document.getElementById('txtbillalias').disabled=true;
				
				mod="0";
				
				if(document.getElementById('btnNew').disabled==false)
					{
					   
						document.getElementById('btnNew').focus();
					}
						
//					else
//					{
//						document.getElementById('btnNew').disabled=false;
//						document.getElementById('btnNew').focus();
//						
//					}
//			
					setButtonImages();
				return false;
}
			
//*******************************************************************************//
//**************************This Function For save Button*************************//
//*******************************************************************************//


function billsaveclick()
{
   var msg=checkSession();
        if(msg==false)
        return false;
 // event.keyCode==32;
 document.getElementById('txtbillid').value=trim(document.getElementById('txtbillid').value);
 document.getElementById('txtbillstatus').value=trim(document.getElementById('txtbillstatus').value);
 document.getElementById('txtbillalias').value=trim(document.getElementById('txtbillalias').value);
 
    if ((document.getElementById('txtbillid').value=="")&&(document.getElementById('hiddenauto').value!=1))
    {
        alert("Please Fill Bill Id");
        if(document.getElementById('txtbillid').disabled==false)
            document.getElementById('txtbillid').focus();
        return false;
    }
//			 if(document.getElementById('hiddenauto').value!=1)
//              {
//			    if(document.getElementById('txtbillid').value=="")
//			    {
//			    alert("Please Fill Bill Id");
//			    document.getElementById('txtbillid').focus();
//			    return false;
//			    }
//			return false;
//			}
			else if((document.getElementById('txtbillstatus').value==""))
			{
			alert("Please Fill Bill Status");
			document.getElementById('txtbillstatus').focus();
			return false;
			}
			else if(document.getElementById('txtbillalias').value=="")
			{
			alert("Please Fill bill Alias");
			document.getElementById('txtbillalias').focus();
			return false;
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
			var companycode=document.getElementById('hiddencomcode').value;
			var billid=document.getElementById('txtbillid').value;
			var billstatus=document.getElementById('txtbillstatus').value;
			billstatus=trim(billstatus);
						
			var billalias=document.getElementById('txtbillalias').value;
			var UserId=document.getElementById('hiddenuserid').value;			

			if(mod !="1" && mod !=null)
			{
			//BillStatus.chkbillid(companycode,UserId,billid,call_saveclick);
			
BillStatus.chkbillid(billid,billstatus,mod,call_saveclick);
			}
			else
			{
			 if(name_modify==document.getElementById('txtbillstatus').value)
			    {
			        updatecat4();
			    }
			    else
			    {
			        var str=document.getElementById('txtbillstatus').value;
			        BillStatus.billidauto(str,modifysave);
			    }
			
//			    var str=document.getElementById('txtbillstatus').value;
//			    
//                BillStatus.billidauto(str,modifysave);		
                		
                return false;
			}
			return false;
}

//*******************************************************************************//
//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function call_saveclick(response)
{
			var ds=response.value;
			
			if(ds.Tables[0].Rows.length > 0)
			{
			         //if( document.getElementById('txtbillid').value==ds.Tables[0].Rows[0].Bill_Id)
			        // {
        			     alert("This Bill Id Is Already Exist, Try Another Code !!!!");
        			     document.getElementById('txtbillid').value="";
			             if(document.getElementById('txtbillid').disabled==false)
			               document.getElementById('txtbillid').focus();
			        // }
			  
			return false;
			}
		   else if(ds.Tables[1].Rows.length > 0)
	                {
	                     alert("This Bill Status Is Already Exist, Try Another Code !!!!");
                    		document.getElementById('txtbillstatus').value="";	
                            document.getElementById('txtbillalias').value="";
                            document.getElementById('txtbillstatus').focus();
                            return false;
	                } 
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var billid=document.getElementById('txtbillid').value;
				var billstatus=document.getElementById('txtbillstatus').value;
				var billalias=document.getElementById('txtbillalias').value;
				var UserId=document.getElementById('hiddenuserid').value;			

				//BillStatus.billsave1(companycode,billid,billstatus,billalias,UserId);
				BillStatus.billsave1(billid,billstatus,billalias);
				
				alert("Data Saved Successfully");
				//alert(xmlObj.childNodes(0).childNodes(0).text);


				document.getElementById('txtbillid').value="";
				document.getElementById('txtbillstatus').value="";
				document.getElementById('txtbillalias').value="";
						
				document.getElementById('txtbillid').disabled=true;
				document.getElementById('txtbillstatus').disabled=true;
				document.getElementById('txtbillalias').disabled=true;
								
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
			}
			billcancelclick('BillStatus');
			return false;
}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//

function billexecuteclick()
{
   var msg=checkSession();
        if(msg==false)
        return false;
//var glaobalzonecode;
//var glaobalzonename;
//var glaobalzonealias;
z=0;
			var companycode=document.getElementById('hiddencomcode').value.toUpperCase();
			var billid=document.getElementById('txtbillid').value;
			glaobalbillid=billid;
			var billstatus=document.getElementById('txtbillstatus').value.toUpperCase();
			glaobalbillstatus=billstatus;
			var billalias=document.getElementById('txtbillalias').value.toUpperCase();
			glaobalbillalias=billalias;
			var UserId=document.getElementById('hiddenuserid').value.toUpperCase();			

			//BillStatus.billexecute1(companycode,zonecode,zonename,alias,UserId,checkcall);	
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
BillStatus.billexecute1(billid,billstatus,billalias,checkcall);	
				   				
			        updateStatus();
			document.getElementById('txtbillid').disabled=true;
			document.getElementById('txtbillstatus').disabled=true;
			document.getElementById('txtbillalias').disabled=true;
			
			
			mod="0";
			           
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();


			return false;
}
				
				
//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function checkcall(response)
{
			//var ds=response.value;
			dsbillexecute=response.value;
				if(dsbillexecute==null)
			{
			    alert(response.error.description);
			    return false;
			}    
			if(dsbillexecute.Tables[0].Rows.length > 0)
			{
			 	document.getElementById('txtbillid').value=dsbillexecute.Tables[0].Rows[0].bill_id;
				document.getElementById('txtbillstatus').value=dsbillexecute.Tables[0].Rows[0].billstatus;
				document.getElementById('txtbillalias').value=dsbillexecute.Tables[0].Rows[0].billalias;
					
				document.getElementById('txtbillid').disabled=true;
				document.getElementById('txtbillstatus').disabled=true;
				document.getElementById('txtbillalias').disabled=true;
						
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
				billcancelclick('BillStatus');
			}

            if(dsbillexecute.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			   document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			   document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
			return false;
}


//*******************************************************************************//
//*************************This Function For First Button************************//
//*******************************************************************************//
//function billfirstclick()
//{
//	BillStatus.billfpnl(firstcall);
//						
//			document.getElementById('txtbillid').disabled=true;
//		    document.getElementById('txtbillstatus').disabled=true;
//			document.getElementById('txtbillalias').disabled=true;
//			
//			document.getElementById('btnprevious').disabled=true;	
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnnext').disabled=false;
//			
//			document.getElementById('btnNew').disabled=true;
//			document.getElementById('btnSave').disabled=true;
//			document.getElementById('btnModify').disabled=false;
//			document.getElementById('btnDelete').disabled=false;
//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnExecute').disabled=true;
//			document.getElementById('btnCancel').disabled=false;		
//			document.getElementById('btnfirst').disabled=true;				
//			document.getElementById('btnnext').disabled=false;					
//			document.getElementById('btnprevious').disabled=true;			
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnExit').disabled=false;
//			
//			return false;
//}
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	
function billfirstclick()
{
   var msg=checkSession();
        if(msg==false)
        return false;
			//var dszoneexecute=response.value;
	
			    document.getElementById('txtbillid').value=dsbillexecute.Tables[0].Rows[0].bill_id;
				document.getElementById('txtbillstatus').value=dsbillexecute.Tables[0].Rows[0].billstatus;
				document.getElementById('txtbillalias').value=dsbillexecute.Tables[0].Rows[0].billalias;
			z=0;
			updateStatus();

		     document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
		if(dsbillexecute.Tables[0].Rows.length>0)
		{
		    document.getElementById('btnnext').disabled=false;			
		    document.getElementById('btnlast').disabled=false;			
		}
		setButtonImages();
			return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//

function billlastclick()
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
BillStatus.billfpnl(lastcall);

			   document.getElementById('txtbillid').disabled=true;
				document.getElementById('txtbillstatus').disabled=true;
				document.getElementById('txtbillalias').disabled=true;
						
			return false;
}

//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function lastcall(response)
{
			//var dszoneexecute=response.value;
			//dsbillexecute=response.value;
			var y=dsbillexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			    document.getElementById('txtbillid').value=dsbillexecute.Tables[0].Rows[z].bill_id;
				document.getElementById('txtbillstatus').value=dsbillexecute.Tables[0].Rows[z].billstatus;
				document.getElementById('txtbillalias').value=dsbillexecute.Tables[0].Rows[z].billalias;
			updateStatus();
			
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;
		        setButtonImages();
			return false;
}


//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//


//function billpreviousclick()
//{			
//BillStatus.billfpnl(previouscall);

//			    document.getElementById('txtbillid').disabled=true;
//				document.getElementById('txtbillstatus').disabled=true;
//				document.getElementById('txtbillalias').disabled=true;
//			return false;
//}

//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
function billpreviousclick()
{
   var msg=checkSession();
        if(msg==false)
        return false;
		//var dszoneexecute=response.value;
		var a=dsbillexecute.Tables[0].Rows.length;
		z--;
		if(z>a)
			{
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnlast').disabled=true;
				return false;
			}
		
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
				 document.getElementById('txtbillid').value=dsbillexecute.Tables[0].Rows[z].bill_id;
				document.getElementById('txtbillstatus').value=dsbillexecute.Tables[0].Rows[z].billstatus;
				document.getElementById('txtbillalias').value=dsbillexecute.Tables[0].Rows[z].billalias;
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
				return false;
			}
		}
		else
		{		document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				return false;
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

function billnextclick()
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
BillStatus.billfpnl(nextcall);

		        document.getElementById('txtbillid').disabled=true;
				document.getElementById('txtbillstatus').disabled=true;
				document.getElementById('txtbillalias').disabled=true;
		
		return false;
}
//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function nextcall(response)
{
	//var dszoneexecute=response.value;
	//dsbillexecute=response.value;
	var a=dsbillexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			document.getElementById('txtbillid').value=dsbillexecute.Tables[0].Rows[z].bill_id;
				document.getElementById('txtbillstatus').value=dsbillexecute.Tables[0].Rows[z].billstatus;
				document.getElementById('txtbillalias').value=dsbillexecute.Tables[0].Rows[z].billalias;
			
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

function billexitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}




//*******************************************************************************//
//*************************This Function For Delete Button***********************//
//*******************************************************************************//
function billdeleteclick()
{
   var msg=checkSession();
        if(msg==false)
        return false;

//        updateStatus();
//var glaobalzonecode;
//var glaobalzonename;
//var glaobalzonealias;
		var companycode=document.getElementById('hiddencomcode').value;
		var billid=document.getElementById('txtbillid').value;
		var billstatus=document.getElementById('txtbillstatus').value;
		var billalias=document.getElementById('txtbillalias').value;
		var UserId=document.getElementById('hiddenuserid').value;			
		boolReturn = confirm("Are you sure you wish to delete this?");
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
		if(boolReturn==1)
		{
		alert ("Data Deleted Successfully");
		
		document.getElementById('txtbillid').value="";
		document.getElementById('txtbillstatus').value="";	
		document.getElementById('txtbillalias').value="";
		
		
        BillStatus.billdelete(billid);
		BillStatus.billexecute1(glaobalbillid,glaobalbillstatus,glaobalbillalias,delcall);
		//z--;
//		document.getElementById('txtbillid').value="";
//		document.getElementById('txtbillstatus').value="";
//		document.getElementById('txtbillalias').value="";
		//billnextclick();
//		document.getElementById('txtbillid').value=dsbillexecute.Tables[0].Rows[z].bill_id;
//				document.getElementById('txtbillstatus').value=dsbillexecute.Tables[0].Rows[z].billstatus;
//				document.getElementById('txtbillalias').value=dsbillexecute.Tables[0].Rows[z].billalias;
		//BillStatus.billexecute2(glaobalbillid,glaobalbillstatus,glaobalbillalias,delcall);	
		}     
	else
	{
	return false;
	}
	return false;
}

//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//

function delcall(res)
{
	 dsbillexecute= res.value;
    var len=dsbillexecute.Tables[0].Rows.length;
	
	if(dsbillexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtbillid').value="";
		document.getElementById('txtbillstatus').value="";	
		document.getElementById('txtbillalias').value="";
		billcancelclick('BillStatus');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('txtbillid').value=dsbillexecute.Tables[0].Rows[0].bill_id;
				document.getElementById('txtbillstatus').value=dsbillexecute.Tables[0].Rows[0].billstatus;
				document.getElementById('txtbillalias').value=dsbillexecute.Tables[0].Rows[0].billalias;
	}
	else
	{
		document.getElementById('txtbillid').value=dsbillexecute.Tables[0].Rows[z].bill_id;
				document.getElementById('txtbillstatus').value=dsbillexecute.Tables[0].Rows[z].billstatus;
				document.getElementById('txtbillalias').value=dsbillexecute.Tables[0].Rows[z].billalias;
	}
		setButtonImages();
	
return false;
}

	
//*******************************************************************************//
//*********************This For The Do The laters in capital laters**************//
//*******************************************************************************//	
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



//*********************************************Auto Generate***********************
function autoornot()
{
 if(hiddentext=="new" )
   {
 
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    return false;
    }
else
    {
    userdefine();

    return false;
    }
//return false;
  }
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )
{
  if(document.getElementById('hiddenauto').value==1)
			{
	
            uppercase3();
           
           }
            else
            {
            document.getElementById('txtbillstatus').value=document.getElementById('txtbillstatus').value.toUpperCase();
            }
return false;
}
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtbillstatus').value=trim(document.getElementById('txtbillstatus').value);
		lstr=document.getElementById('txtbillstatus').value;
		  cstr=lstr.substring(0,1);
            var mstr="";
            			   if(lstr.indexOf(" ")==1)
			            {
			            var leng=lstr.length;
			           mstr= cstr + lstr.substring(2,leng);
			            }
			            else
			            {
			             var leng=lstr.length;
			            mstr=cstr + lstr.substring(1,leng);
			            }
		
		    if(document.getElementById('txtbillstatus').value!="")
                {

		document.getElementById('txtbillstatus').value=document.getElementById('txtbillstatus').value.toUpperCase();
	    document.getElementById('txtbillalias').value=document.getElementById('txtbillstatus').value;
	       document.getElementById('txtbillalias').focus();
		// str=document.getElementById('txtzonename').value;
		str=mstr;
		BillStatus.billidauto(str,fillcall);
		return false;
                }
		       
               
 return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length !=0)
		    {
		    alert("This Bill Stastus has already been assigned !! ");
		    
		         document.getElementById('txtbillid').value="";
				document.getElementById('txtbillstatus').value="";	
				document.getElementById('txtbillalias').value="";
			document.getElementById('txtbillstatus').focus();
		  
    		
		    return false;
		    }
		
		        else
		        {
		        
		        if(hiddentext=="new" )
		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].bill_id;
		                        }
		                    if(newstr !=null )
		                        {
		                        document.getElementById('txtbillstatus').value=trim(document.getElementById('txtbillstatus').value);
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        str=str.toUpperCase();
		                        document.getElementById('txtbillid').value=str.substr(0,2)+ code;
		                       // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
		                         }
		                    else
		                         {
		                            str=str.toUpperCase();
		                          document.getElementById('txtbillid').value=str.substr(0,2)+ "0";
		                          //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
		                          }
		                          }
		     }
		     document.getElementById('btnSave').focus();
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtbillid').disabled=false;
        document.getElementById('txtbillstatus').value=document.getElementById('txtbillstatus').value.toUpperCase();
        document.getElementById('txtbillalias').value=document.getElementById('txtbillstatus').value;
        document.getElementById('txtbillalias').focus();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}



function LTrim( value )
 {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) {
	
	return LTrim(RTrim(value));
	
}
function check()
{
    document.getElementById('txtbillstatus').value=trim(document.getElementById('txtbillstatus').value);
    
    

}

//function autoalias()
//{
//if (document.getElementById('txtbillstatus').value != "0")
//// document.getElementById('txtbillalias').value=document.getElementById('txtbillstatus').value;
// return document.getElementById('txtbillalias').value=document.getElementById('txtbillstatus').value;

//}


function modifysave(response)
{
    var ds=response.value;
    if(	chknamemod!=document.getElementById('txtbillstatus').value)
    {
        if(ds.Tables[0].Rows.length !=0)
        {
        alert("This Bill Status has already been assigned !! ");

        //document.getElementById('txtbillid').value="";
        document.getElementById('txtbillstatus').value="";	
        //document.getElementById('txtbillalias').value="";
        document.getElementById('txtbillstatus').focus();


     return false;
        }
        updatecat4();
    }
  }
  function updatecat4()
  {
        var billid=document.getElementById('txtbillid').value;
		var billstatus=document.getElementById('txtbillstatus').value;
		var billalias=document.getElementById('txtbillalias').value;

        BillStatus.billmodify(billid,billstatus,billalias);

        dsbillexecute.Tables[0].Rows[z].bill_id=document.getElementById('txtbillid').value;
        dsbillexecute.Tables[0].Rows[z].billststus=document.getElementById('txtbillstatus').value;
        dsbillexecute.Tables[0].Rows[z].billalias=document.getElementById('txtbillalias').value;
				

		alert("Data Modified Successfully");
			
//			    document.getElementById('txtbillid').value="";
//				document.getElementById('txtbillstatus').value="";	
//				document.getElementById('txtbillalias').value="";
			//alert(xmlObj.childNodes(0).childNodes(1).text);


			document.getElementById('txtbillid').disabled=true;
			document.getElementById('txtbillstatus').disabled=true;
			document.getElementById('txtbillalias').disabled=true;
			
			
			//document.getElementById('btnSave').disabled=true;
			
			updateStatus();
			mod="0";
			if(z == 0)
			{
				document.getElementById('btnfirst').disabled=true;		
		    	document.getElementById('btnprevious').disabled=true;		
		    }
		    if(z==parseInt(dsbillexecute.Tables[0].Rows.length)-1)
		    {
		    document.getElementById('btnnext').disabled=true;
		    document.getElementById('btnlast').disabled=true;
		    }
			
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
			setButtonImages();
			
			return false;
    }
    
function capsAlias()
{
    document.getElementById('txtbillalias').value=document.getElementById('txtbillalias').value.toUpperCase();
    return false;
}
function capsCode()
{
    document.getElementById('txtbillid').value=document.getElementById('txtbillid').value.toUpperCase();
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

function clearbillstatus()
{
billcancelclick('BillStatus');
document.getElementById('btnNew').focus();
givebuttonpermission('BillStatus');

}