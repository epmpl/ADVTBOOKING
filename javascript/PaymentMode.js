	var flag;
    var z="0";
	var auto="";
	var hiddentext;
	var hiddentext1="";
	var mod="0";
	var name_modify="";
//	                 var paycode	 =    document.getElementById('txtpaycode').value;
//					var payname	 =	document.getElementById('txtpayment').value;
//					var compcode =	document.getElementById('hiddencompcode').value;
//					var userid	 =		document.getElementById('hiddenuserid').value;
//	
	
	var dspayexecute;
var glopaycode;
var glopayname;
var dspaydelete;
	
var browser=navigator.appName;

/*-----For---Upper Case-------------*/
function uppercase1()
{
document.getElementById('txtpaycode').value=document.getElementById('txtpaycode').value.toUpperCase();
return ;
}
	


function NewClick11()
{
        var msg=checkSession();
            if(msg==false)
            return false;
		document.getElementById('txtpaycode').value="";
		document.getElementById('txtpayment').value="";	
		document.getElementById('txtpayalias').value="";
	    document.getElementById('drpcash').value=0;
		 if(document.getElementById('hiddenauto').value==1)
         {
          document.getElementById('txtpaycode').disabled=true;
          }
         else
           {
           document.getElementById('txtpaycode').disabled=false;
           }
		
		document.getElementById('txtpayment').disabled=false;
		document.getElementById('txtpayalias').disabled=false;
		document.getElementById('drpcash').disabled=false;
		if(document.getElementById('hiddenauto').value==1)
         {
          document.getElementById('txtpayment').focus();
          }
         else
           {
           document.getElementById('txtpaycode').focus();
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
			function ModifyClick11()
			{
//						flag=1;
//						document.getElementById('btnNew').disabled=true;
//						document.getElementById('btnSave').disabled=false;
//						document.getElementById('btnExit').disabled=true;
//						document.getElementById('btnQuery').disabled=true;
//						document.getElementById('btnNew').disabled=true;
//						document.getElementById('btnModify').disabled=true;
//						document.getElementById('btnExecute').disabled=true;
//						document.getElementById('btnDelete').disabled=true;
//						document.getElementById('btnCancel').disabled=false;
//						document.getElementById('btnfirst').disabled=true;
//						document.getElementById('btnprevious').disabled=true;
//						document.getElementById('btnnext').disabled=true;
//						document.getElementById('btnlast').disabled=true;
//						document.getElementById('btnExit').disabled=false;
//						
//				        
						document.getElementById('txtpaycode').disabled=true;
						document.getElementById('txtpayment').disabled=false;
						document.getElementById('txtpayalias').disabled=false;
						document.getElementById('drpcash').disabled=false;
						name_modify=document.getElementById('txtpayment').value;
						chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
			//	document.getElementById('btnModify').disabled=true;
			setButtonImages();
				document.getElementById('btnSave').focus();
				
			
				mod="1";
				 hiddentext="modify";	
						
			
						return false;
			}
			
function SaveClick11()
{
  var msg=checkSession();
            if(msg==false)
            return false;
		document.getElementById('txtpaycode').value=trim(document.getElementById('txtpaycode').value);
        document.getElementById('txtpayment').value=trim(document.getElementById('txtpayment').value);	
        document.getElementById('txtpayalias').value=trim(document.getElementById('txtpayalias').value);
        document.getElementById('drpcash').value=trim(document.getElementById('drpcash').value);
        if(document.getElementById('hiddenauto').value==1)
              {
        if (document.getElementById('txtpayment').value=="")
							{
							alert("Please Enter the Payment Mode");
							document.getElementById('txtpayment').focus();
							return false;
							}
							else
							{
							var payname=document.getElementById('txtpayment').value;
							}
			}
        
        if(document.getElementById("txtpaycode").value=="" && document.getElementById('hiddenauto').value=="1")
	{
	   
	   // document.getElementById('pnew').value="1";
	    return false;
	}
			
			if(document.getElementById('hiddenauto').value!=1)
              {
			        if(document.getElementById('txtpaycode').value=="")
			        {
			            alert("Please Fill Payment Code");
			            if(document.getElementById('txtpaycode').disabled==false)
			            document.getElementById('txtpaycode').focus();
			            return false;
			        }
			        //return false;
			   }
			        if (document.getElementById('txtpayment').value=="")
							{
							alert("Please Enter the Payment Mode");
							document.getElementById('txtpayment').focus();
							return false;
							}
							else
							{
							var payname=document.getElementById('txtpayment').value;
							}           
				var chmandat="";
             if(browser!="Microsoft Internet Explorer")
                    {
                        chmandat=document.getElementById('lblpayalias').textContent;
                    }
                    else
                    {        
                        chmandat=document.getElementById('lblpayalias').innerText;
                    }
                    if(chmandat.indexOf('*')>= 0)
                    {
                        if(document.getElementById('txtpayalias').value=="")
                        {
                            alert("Please Enter the Alias");
                            document.getElementById('txtpayalias').focus();
                            return false;
                        }  
                      }		
					var compcode =	document.getElementById('hiddencompcode').value;
					var userid	 =	document.getElementById('hiddenuserid').value;
					var paycode=document.getElementById('txtpaycode').value;
					var payname=document.getElementById('txtpayment').value;
					var cash=document.getElementById('drpcash').value;
					
				//if(flag=="0")
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

				
			if(mod!="1" && mod!=null)
				{	
				
					//PaymentMode.chk(paycode,payname,compcode,userid,callchk);
					var ds1=PaymentMode.chk(paycode,payname,compcode,userid);
					callchk(ds1);
					return false;
				}
					
					else
					{
					
			            if(name_modify==document.getElementById('txtpayment').value)
			            {
			                updatepay();
			            }
			            else
			            {
			                var str=document.getElementById('txtpayment').value;
			              
			                PaymentMode.chk(paycode,payname,compcode,userid,modifyclick);
			                return false;
				        }
					}
	
}

function modifyclick(res)
{
  var ds=res.value;	
 
    var newstr;
    if(ds!=null && ds.Tables[1].Rows.length !=0)
    {
        alert("This Payment Name Already Exist!! ");
        document.getElementById('txtpayment').value="";
       //document.getElementById('txtadcatname').focus();


        return false;
    }
    
   //  updatepay();   
   else
   {
   
                    var compcode =	document.getElementById('hiddencompcode').value;
					var userid	 =	document.getElementById('hiddenuserid').value;
					var paycode=document.getElementById('txtpaycode').value;
					var payname=document.getElementById('txtpayment').value;
					var alias=document.getElementById('txtpayalias').value;
					 var cash=document.getElementById('drpcash').value;
                   
                 PaymentMode.modify(paycode,payname, compcode, userid,alias,cash )
                 //
                dspayexecute.Tables[0].Rows[z].Pay_Mode_Code=document.getElementById('txtpaycode').value;
				dspayexecute.Tables[0].Rows[z].Paymant_Mode_Name=document.getElementById('txtpayment').value;
				dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS=document.getElementById('txtpayalias').value;
				dspayexecute.Tables[0].Rows[z].CASH=document.getElementById('drpcash').value;
				   alert("Data Update Successfully");
				     document.getElementById('txtpaycode').disabled=true;
		   document.getElementById('txtpayment').disabled=true;
			//updateStatus();
		    
			
			if(z==0)
			{
			updateStatus();
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			if(document.getElementById('btnModify').disabled == false)				
			    document.getElementById('btnModify').focus();
                    return false;

			}
			if(z==dspayexecute.Tables[0].Rows.length-1)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
		
			}
			mod="0";
			setButtonImages();
	        return false;
   }
}


function updatepay() 
{
  //alert('updatepay')
                 	var compcode =	document.getElementById('hiddencompcode').value;
					var userid	 =	document.getElementById('hiddenuserid').value;
					var paycode=document.getElementById('txtpaycode').value;
					var payname=document.getElementById('txtpayment').value;
					var alias    =      document.getElementById('txtpayalias').value;
                   var cash=document.getElementById('drpcash').value;
                 PaymentMode.modify(paycode,payname, compcode, userid ,alias,cash)
                 //
                dspayexecute.Tables[0].Rows[z].Pay_Mode_Code=document.getElementById('txtpaycode').value;
				dspayexecute.Tables[0].Rows[z].Paymant_Mode_Name=document.getElementById('txtpayment').value;
				dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS=document.getElementById('txtpayalias').value;
				dspayexecute.Tables[0].Rows[z].CASH=document.getElementById('drpcash').value;
				//dszoneexecute.Tables[0].Rows[z].Zone_Alias=document.getElementById('txtzonealias').value;
				


			//alert("Data Modified Successfully");
			//alert(xmlObj.childNodes(0).childNodes(1).text);

               alert("Data Update Successfully");
//            if(browser!="Microsoft Internet Explorer")
//            {
//                alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
//            }
//            else
//            {
//                alert(xmlObj.childNodes(0).childNodes(1).text);
//            }
			
		   document.getElementById('txtpaycode').disabled=true;
		   document.getElementById('txtpayment').disabled=true;
		   document.getElementById('txtpayalias').disabled=true;
		   document.getElementById('drpcash').disabled=true;
			updateStatus();
		    
			
			if(z==0)
			{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;

			}
			if(z==dspayexecute.Tables[0].Rows.length-1)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
		
			}
			mod="0";
			setButtonImages();
	        return false;
}

			
function callchk(res)
			{
			
				var ds=res.value;
				
				if(ds.Tables[0].Rows.length>0)
				{
				    if(document.getElementById('txtpayment').value!="")
				    {
					    alert("This Payemnt Code Already Exist");
					    document.getElementById('txtpaycode').value=""
					    //document.getElementById('txtpayment').value=""
					     if(document.getElementById('txtpaycode').disabled==false)
					    document.getElementById('txtpaycode').focus();
					 
					}
					return false;
				}
					if(ds.Tables[1].Rows.length>0)
					{
					   
							alert("This Payment Name Already Exist");
						    document.getElementById('txtpayment').value="";
							document.getElementById('txtpayment').focus();
							
							return false;
					}
					
				else
				{
						var paycode	 =      document.getElementById('txtpaycode').value;
						var payname	 =	    document.getElementById('txtpayment').value;
						var compcode =	    document.getElementById('hiddencompcode').value;
						var userid	 =		document.getElementById('hiddenuserid').value;
						var alias    =      document.getElementById('txtpayalias').value;
					    var cash    =      document.getElementById('drpcash').value;
					
					PaymentMode.insert(paycode,payname, compcode, userid,alias,cash)
					alert("Data Saved Successfully");
				document.getElementById('txtpaycode').value="";
				document.getElementById('txtpayment').value="";
				document.getElementById('txtpayalias').value="";
                document.getElementById('drpcash').value=0 ;
				document.getElementById('txtpaycode').disabled=true;
				document.getElementById('txtpayment').disabled=true;
				document.getElementById('txtpayalias').disabled=true;
				document.getElementById('drpcash').disabled=true;
				
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
				CancelClick11('PaymentMode');
			  //return false;
	}
			
			
			function QueryClick11()
			{
			    hiddentext="query";
			
			
//				document.getElementById('btnNew').disabled=true;
//				document.getElementById('btnSave').disabled=true;
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//				document.getElementById('btnQuery').disabled=true;
//				document.getElementById('btnExecute').disabled=false;
//				document.getElementById('btnCancel').disabled=false;
//				document.getElementById('btnfirst').disabled=true;
//				document.getElementById('btnnext').disabled=true;
//				document.getElementById('btnlast').disabled=true;
//				document.getElementById('btnExit').disabled=false;
//				document.getElementById('btnprevious').disabled=true;
				
				 document.getElementById('txtpaycode').value="";
				document.getElementById('txtpayment').value="";
				document.getElementById('txtpayalias').value="";
				document.getElementById('drpcash').value=0;
                z=0;
			    document.getElementById('txtpaycode').disabled=false;
				document.getElementById('txtpayment').disabled=false;
				document.getElementById('txtpayalias').disabled=true;
				document.getElementById('drpcash').disabled=true;
				
			
				
				chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	document.getElementById('btnExecute').focus();
	
				hiddentext="query";
			setButtonImages();
			return false;
			}
			
			
	function ExecuteClick11()
	{
			
			 var msg=checkSession();
            if(msg==false)
            return false;

			var paycode =document.getElementById('txtpaycode').value;
			glopaycode=paycode;
			var payname	 =	document.getElementById('txtpayment').value;
			glopayname=payname;
			var compcode =	document.getElementById('hiddencompcode').value;
			var userid	 =		document.getElementById('hiddenuserid').value;
	
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
PaymentMode.exe(paycode,payname, compcode, userid, callexe)
			updateStatus();
			
				 document.getElementById('txtpaycode').disabled=true;
				document.getElementById('txtpayment').disabled=true;
				document.getElementById('txtpayalias').disabled=true;
				document.getElementById('drpcash').disabled=true;
				
				mod="0";
		   document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();	

				
				
			return false;
	}
			
			function callexe(response)
			{
			dspayexecute=response.value;
			if(dspayexecute.Tables[0].Rows.length > 0)
			
			{
			 document.getElementById('txtpaycode').value=dspayexecute.Tables[0].Rows[0].Pay_Mode_Code;
			 document.getElementById('txtpayment').value=dspayexecute.Tables[0].Rows[0].Payment_Mode_Name;
			 if(dspayexecute.Tables[0].Rows[0].PAYMENT_MODE_ALIAS != null)
			 {
			 document.getElementById('txtpayalias').value=dspayexecute.Tables[0].Rows[0].PAYMENT_MODE_ALIAS;
			 }
			 else
			 {
			 document.getElementById('txtpayalias').value="";
			 }
			 document.getElementById('drpcash').value=dspayexecute.Tables[0].Rows[0].CASH;
			
//							document.getElementById('btnNew').disabled=true;
//							document.getElementById('btnSave').disabled=true;
//							document.getElementById('btnModify').disabled=false;
//							document.getElementById('btnDelete').disabled=false;
//							document.getElementById('btnQuery').disabled=false;
//							document.getElementById('btnExecute').disabled=true;
//							document.getElementById('btnCancel').disabled=false;
//							document.getElementById('btnfirst').disabled=false;
//							document.getElementById('btnnext').disabled=false;
//							document.getElementById('btnlast').disabled=false;
//							document.getElementById('btnExit').disabled=false;
//							document.getElementById('btnprevious').disabled=false;

                            document.getElementById('txtpaycode').disabled=true;
				             document.getElementById('txtpayment').disabled=true;       
				             document.getElementById('txtpayalias').disabled=true;
							   document.getElementById('drpcash').disabled=true;
							
			}
			else
			{
			alert("This Search Criteria Does Not Produse Any Result")
			CancelClick11('PaymentMode');
			
			}
			
			
//			    document.getElementById('btnNew').disabled=false;
//				document.getElementById('btnSave').disabled=true;
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//				document.getElementById('btnQuery').disabled=false;
//				document.getElementById('btnExecute').disabled=true;
//				document.getElementById('btnCancel').disabled=false;
//				document.getElementById('btnfirst').disabled=true;
//				document.getElementById('btnnext').disabled=true;
//				document.getElementById('btnlast').disabled=true;
//				document.getElementById('btnExit').disabled=false;
//				document.getElementById('btnprevious').disabled=true;
//			return false;
			if(dspayexecute.Tables[0].Rows.length ==1)
			{
			    //document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;					
			    //document.getElementById('btnprevious').disabled=true;			
			    document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
			return false;
}	
				
function CancelClick11(formname)
{

			    chkstatus(FlagStatus);
				givebuttonpermission(formname);
//				document.getElementById('btnNew').disabled=false;
//				document.getElementById('btnSave').disabled=true;
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//				document.getElementById('btnQuery').disabled=false;
//				document.getElementById('btnExecute').disabled=true;
//				document.getElementById('btnCancel').disabled=false;
//				document.getElementById('btnfirst').disabled=true;
//				document.getElementById('btnnext').disabled=true;
//				document.getElementById('btnlast').disabled=true;
//				document.getElementById('btnExit').disabled=false;
//				document.getElementById('btnprevious').disabled=true;
			
				document.getElementById('txtpaycode').value="";
				document.getElementById('txtpayment').value="";
				document.getElementById('txtpayalias').value="";
				document.getElementById('drpcash').value=0;
			
				document.getElementById('txtpaycode').disabled=true;
				document.getElementById('txtpayment').disabled=true;
				document.getElementById('txtpayalias').disabled=true;
				document.getElementById('drpcash').disabled=true;
				
				
				document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				
				
				
				mod="0";
				
					//chkstatus(FlagStatus);
					
					
					
					//document.getElementById('btnNew').focus();
					
					if(document.getElementById('btnNew').disabled==false)
					{
					   
						document.getElementById('btnNew').focus();
					}
						
					else
					{
						document.getElementById('btnNew').disabled=false;
						document.getElementById('btnNew').focus();
						
					}
					setButtonImages();
                   // givebuttonpermission(formname);
			
			return false;
}
			
			
			
			
			
			
/*function FirstClick11()
{
//z=0;
				    var paycode	 =  document.getElementById('txtpaycode').value;
					var payname	 =	document.getElementById('txtpayment').value;
					var compcode =	document.getElementById('hiddencompcode').value;
					var userid	 =  document.getElementById('hiddenuserid').value;
			
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
PaymentMode.fnpl( compcode, userid, firstcall)
			
			document.getElementById('txtpaycode').disabled=true;
			document.getElementById('txtpayment').disabled=true;
				
			
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			
			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;
			
			
			
		return false;

}*/


function FirstClick11()
{
//ds=response.value;
            var msg=checkSession();
            if(msg==false)
            return false;
					 document.getElementById('txtpaycode').value=dspayexecute.Tables[0].Rows[0].Pay_Mode_Code;
			         document.getElementById('txtpayment').value=dspayexecute.Tables[0].Rows[0].Payment_Mode_Name;
			         if(dspayexecute.Tables[0].Rows[0].PAYMENT_MODE_ALIAS != null)
			         {
			         document.getElementById('txtpayalias').value=dspayexecute.Tables[0].Rows[0].PAYMENT_MODE_ALIAS;
			         }
			         else
			         {
			         document.getElementById('txtpayalias').value="";
			         }
			         document.getElementById('drpcash').value=dspayexecute.Tables[0].Rows[0].CASH;
			         	z=0;
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


/*function PreviousClick11()
{

			        var paycode	 =    document.getElementById('txtpaycode').value;
					var payname	 =	document.getElementById('txtpayment').value;
					var compcode =	document.getElementById('hiddencompcode').value;
					var userid	 =		document.getElementById('hiddenuserid').value;
			
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
PaymentMode.fnpl( compcode, userid, precall)
			document.getElementById('btnfirst').disabled=true;				
		    document.getElementById('btnprevious').disabled=true;
			
			

               return false;

}*/

function PreviousClick11()
{
            var msg=checkSession();
            if(msg==false)
            return false;

var a=dspayexecute.Tables[0].Rows.length;
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
			
			
	 document.getElementById('txtpaycode').value=dspayexecute.Tables[0].Rows[z].Pay_Mode_Code;
	document.getElementById('txtpayment').value=dspayexecute.Tables[0].Rows[z].Payment_Mode_Name;
	if(dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS != null)
	{
	document.getElementById('txtpayalias').value=dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS;
	}
	else
	{
	document.getElementById('txtpayalias').value="";
	}
	document.getElementById('drpcash').value=dspayexecute.Tables[0].Rows[z].CASH;
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
	
	}}
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



/*function NextClick11()
{
//PaymentMode.fnpl(nextcall);
		            var paycode	 =    document.getElementById('txtpaycode').value;
					var payname	 =	document.getElementById('txtpayment').value;
					var compcode =	document.getElementById('hiddencompcode').value;
					var userid	 =		document.getElementById('hiddenuserid').value;
			
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
PaymentMode.fnpl(compcode,userid,next_call)
			
			document.getElementById('txtpaycode').disabled=true;
		    document.getElementById('txtpayment').disabled=true;



return false;

}*/

function NextClick11()
{
            var msg=checkSession();
            if(msg==false)
            return false;
	//var dszoneexecute=response.value;
	var a=dspayexecute.Tables[0].Rows.length;
	z++;
	updateStatus();
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			document.getElementById('txtpaycode').value=dspayexecute.Tables[0].Rows[z].Pay_Mode_Code;
	        document.getElementById('txtpayment').value=dspayexecute.Tables[0].Rows[z].Payment_Mode_Name;
	        if(dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS != null)
	        {
	        document.getElementById('txtpayalias').value=dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS;
	        }
	        else
	        {
	        document.getElementById('txtpayalias').value="";
	        }
	        document.getElementById('drpcash').value=dspayexecute.Tables[0].Rows[z].CASH;
			//document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[z].Zone_Alias;
			
		    
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
			    document.getElementById('btnModify').focus();
			
		}
		else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
			    document.getElementById('btnModify').focus();
	}
	}
	else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
			    document.getElementById('btnModify').focus();
	}
	if(z==a-1)
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
			    document.getElementById('btnModify').focus();
	}
	setButtonImages();
	return false;

}

/*function LastClick11()
{
		            var paycode	 =    document.getElementById('txtpaycode').value;
					var payname	 =	document.getElementById('txtpayment').value;
					var compcode =	document.getElementById('hiddencompcode').value;
					var userid	 =		document.getElementById('hiddenuserid').value;
			
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
PaymentMode.fnpl( compcode, userid,lastcall)
			document.getElementById('txtpaycode').disabled=true;
		    document.getElementById('txtpayment').disabled=true;


               return false;


}*/


function LastClick11()
	{
	            var msg=checkSession();
            if(msg==false)
            return false;
			//var dszoneexecute=response.value;
			var y=dspayexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			document.getElementById('txtpaycode').value=dspayexecute.Tables[0].Rows[z].Pay_Mode_Code;
	        document.getElementById('txtpayment').value=dspayexecute.Tables[0].Rows[z].Payment_Mode_Name;
	        if(dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS != null)
	        {
	        document.getElementById('txtpayalias').value=dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS;
	        }
	        else
	        {
	        document.getElementById('txtpayalias').value="";
	        }
	        document.getElementById('drpcash').value=dspayexecute.Tables[0].Rows[z].CASH;
			//document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[a].Zone_Alias;
			updateStatus();
			
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;
		        setButtonImages();
			return false;
}

//*********************************************EXIT***********************


function exitclick11()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			window.close();
			return false;
		}
		return false;

}

//*********************************************DELETE***********************

function deleteclick11()
	{
	        var msg=checkSession();
            if(msg==false)
            return false;
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
	
			var paycode	 =    document.getElementById('txtpaycode').value;
			var compcode =	document.getElementById('hiddencompcode').value;
			var userid	 =		document.getElementById('hiddenuserid').value;
			
			alert ("Data Deleted Successfully");
		
            PaymentMode.del( compcode, userid,paycode)
			PaymentMode.exe(glopaycode,glopayname, compcode, userid, delcall)
			
			return false;
		  }
//					document.getElementById('btnNew').disabled=true;
//								
//								document.getElementById('btnSave').disabled=true;
//								
//								document.getElementById('btnModify').disabled=false;
//								
//								document.getElementById('btnQuery').disabled=false;
//								
//								document.getElementById('btnExecute').disabled=true;
//								
//								document.getElementById('btnfirst').disabled=false;
//								
//								document.getElementById('btnprevious').disabled=false;
//								
//								document.getElementById('btnnext').disabled=false;
//								
//								document.getElementById('btnlast').disabled=false;
//								
//								document.getElementById('btnCancel').disabled=false;
//								 
//							
//								document.getElementById('btnExit').disabled=false;
//								
//								document.getElementById('btnDelete').disabled = false;
//								
//								document.getElementById('txtpaycode').value="";
//								document.getElementById('txtpayment').value="";

//								document.getElementById('txtpaycode').disabled=true;
//								document.getElementById('txtpayment').disabled=true;
//								
//							
//								
//					
//					alert ("Data Deleted");	
//				
//				}     
//				else
//				
//				{
//				 return false;
//				}
					 return false;
			}
			
function delcall(response)
{
dspayexecute=response.value;
len=dspayexecute.Tables[0].Rows.length;
	
	if(dspayexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtpaycode').value="";
            document.getElementById('txtpayment').value="";
            document.getElementById('txtpayalias').value="";
            document.getElementById('drpcash').value=0;
		CancelClick11('PaymentMode');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		     document.getElementById('txtpaycode').value=dspayexecute.Tables[0].Rows[0].Pay_Mode_Code;
			 document.getElementById('txtpayment').value=dspayexecute.Tables[0].Rows[0].Payment_Mode_Name;
			 if(dspayexecute.Tables[0].Rows[0].PAYMENT_MODE_ALIAS != null)
			 {
			 document.getElementById('txtpayalias').value=dspayexecute.Tables[0].Rows[0].PAYMENT_MODE_ALIAS;
			 }
			 else
			 {
			 document.getElementById('txtpayalias').value
			 }
			document.getElementById('drpcash').value=dspayexecute.Tables[0].Rows[0].CASH;	
							
			
	}
	else
	{
		       document.getElementById('txtpaycode').value=dspayexecute.Tables[0].Rows[z].Pay_Mode_Code;
			 	document.getElementById('txtpayment').value=dspayexecute.Tables[0].Rows[z].Payment_Mode_Name;
			 	if(dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS != null)
			 	{
			 	document.getElementById('txtpayalias').value=dspayexecute.Tables[0].Rows[z].PAYMENT_MODE_ALIAS;
			 	}
			 	else
			 	{
			 	document.getElementById('txtpayalias').value="";
			 	}
				
				document.getElementById('drpcash').value=dspayexecute.Tables[0].Rows[z].CASH;
	}
	if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dspayexecute.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }  
              setButtonImages();     
return false;
}			
			
//*********************************************Auto Generate***********************

//*********************************************Auto Generate***********************



function autoornot()
// {
// if(hiddentext=="new")
 {
 document.getElementById('txtpayment').value=document.getElementById('txtpayment').value.toUpperCase();
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    
    
    
    return false;
    }
else
    {
    userdefine();

    return false;
//    }
   }
return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )

  //if(document.getElementById('hiddenauto').value==1)
			{
	
            uppercase3();
           
           }
            else
            {
           // document.getElementById('txtzonename').value=document.getElementById('txtzonename').value.toUpperCase();
            
            document.getElementById('txtpayment').value=document.getElementById('txtpayment').value.toUpperCase();
            }
return false;
}

		
function uppercase2()
{
document.getElementById('txtpayalias').value=document.getElementById('txtpayalias').value.toUpperCase();
return ;
}

		
function uppercase1()
{
document.getElementById('txtpayment').value=document.getElementById('txtpayment').value.toUpperCase();
return ;
}
		


//auto generated
//this is used for increment in code
			
			
			
			function uppercase3()
		{
		document.getElementById('txtpayment').value=trim(document.getElementById('txtpayment').value);
		lstr=document.getElementById('txtpayment').value;
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
		
		    if(document.getElementById('txtpayment').value!="")
                {

		document.getElementById('txtpayment').value=document.getElementById('txtpayment').value.toUpperCase();
		document.getElementById('txtpayalias').value=document.getElementById('txtpayment').value.toUpperCase();
		
	   // document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
		// str=document.getElementById('txtzonename').value;
		str=mstr;
		PaymentMode.payment_auto(str,fillcall);
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
		    alert("This payment mode has already assigned !! ");
		    
		        document.getElementById('txtpayment').value="";
				document.getElementById('txtpayment').focus();	
				//document.getElementById('txtzonealias').value="";
			
		   //document.getElementById('txtzonename').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Pay_Mode_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        document.getElementById('txtpayment').value=trim(document.getElementById('txtpayment').value);
		                      //  var code=newstr.substr(2,4);
		                        var code=newstr;
		                        code++;
		                        document.getElementById('txtpaycode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtpaycode').value=str.substr(0,2)+ "0";
		                          }
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtpaycode').disabled=false;
         document.getElementById('txtpayment').value=document.getElementById('txtpayment').value.toUpperCase();
     	document.getElementById('txtpayalias').value=document.getElementById('txtpayment').value;
       
       // document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
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
    document.getElementById('txtpaycode').value=trim(document.getElementById('txtpaycode').value);
    
    

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
			
			
			
function cash()
{
document.getElementById('drpcash').value=0;
}

function paymentclear()		
{

document.getElementById('btnNew').focus();

CancelClick11('PaymentMode');
return false;

}	
			
			
			
			
			
			
			
			
			

