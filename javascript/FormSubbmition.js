// JScript File
var globalformtyp;
var globalmodulecode;
var globalfrmcode;
var gloablfrmname;
var gloablfrmalias;
var hiddentext;
var mod="0";
var z=0;
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
var hiddenauto="";
function autogen()
 {

            if((document.getElementById('hiddenauto').value=="1"))
   
              {
                    changeoccured();
                    return false;
              }
                else
                {
                    userdefine();
                    return false;
                 }
    
     


return ;
}




function changeoccured()
{

  
  if((document.getElementById('hiddenauto').value=="1" && hiddentext=="new"))
			{
	
           uppercase3();
           
           }
            else
            {
            document.getElementById('txtname').value=document.getElementById('txtname').value;
            return ;
            }
return ;
}

//function fillcall_modify(res)
//{
//}
//auto generated
//this is used for increment in code
function uppercase3()
		{
		  document.getElementById('txtname').value=trim(document.getElementById('txtname').value);
		 // document.getElementById('txtalias').value=document.getElementById('txtprodesc').value;
		  lstr=document.getElementById('txtname').value;
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
		    if(document.getElementById('txtname').value!="")
                {
               
        
		document.getElementById('txtname').value=document.getElementById('txtname').value;
	    document.getElementById('txtalias').value=document.getElementById('txtname').value;
		// str=document.getElementById('txtprodesc').value;
		// cod=document.getElementById('txtadvcatcode').value;
		str=mstr;
		FormSubbmition.chkcode(/*cod,*/str,fillcall);
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
		    alert("This Form Name has already Exist !! ");
		    
		    document.getElementById("txtname").value="";
		    document.getElementById("txtalias").value="";
		    
		    document.getElementById('txtname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].form_code;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        //document.getElementById('txtid').value=str.substr(0,2)+ code;
		                        document.getElementById('txtid').value = str.substr(0, 2).toUpperCase()+ padDigits(code, 3);
		                         }
		                    else
		                         {
		                        document.getElementById('txtid').value = str.substr(0, 2).toUpperCase() +padDigits(1, 3);
		                          }
		     }
	return false;
		}
		

function userdefine()
    {
        if(document.getElementById('hiddenauto').value!="1")
        {
        
            document.getElementById('txtid').disabled=false;
           // document.getElementById('txtname').value=document.getElementById('txtname').value.toUpperCase();
            document.getElementById('txtalias').value=document.getElementById('txtname').value;
            auto=document.getElementById('hiddenauto').value;
            document.getElementById('txtalias').focus();
            return false;
        }

//return false;


}

function btnNewClick2()
{
    document.getElementById('txtid').value="";
    document.getElementById('drpformtype').value="0";
    document.getElementById('drpmodcode').value="0";
    document.getElementById('txtname').value="";
    document.getElementById('txtalias').value="";

    //chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;
		
	hiddentext="new";
	 
    document.getElementById('drpformtype').disabled=false;
    document.getElementById('drpmodcode').disabled=false;
    document.getElementById('txtname').disabled=false; 
    document.getElementById('txtalias').disabled=false;
    
    if(document.getElementById('hiddenauto').value=="1")
    document.getElementById('txtid').disabled=true;
    else
    document.getElementById('txtid').disabled=false;
    document.getElementById('drpformtype').focus();
   // flag=0;
setButtonImages();
return false;
}
function saveform()
{
document.getElementById('txtname').value=trim(document.getElementById('txtname').value);
document.getElementById("txtalias").value=trim(document.getElementById("txtalias").value);



 if(document.getElementById("drpformtype").value=="0")  
    {
           alert("Please Select Form Type");
            document.getElementById('drpformtype').focus();
            return false;
    
    }

 if(document.getElementById("drpmodcode").value=="0" || document.getElementById("drpmodcode").value=="")  
    {
           alert("Please Select Module Code");
            document.getElementById('drpmodcode').focus();
            return false;
    
    }
    
 if(document.getElementById('hiddenauto').value!="1")
 {
 document.getElementById("txtid").value=trim(document.getElementById("txtid").value);
 if(document.getElementById("txtid").value=="")
    {
        alert("Please Enter Form Code");
        document.getElementById('txtid').focus();
        return false;
         
    }
    //return false;
  }
  
    
  if(document.getElementById("txtname").value=="")  
    {

            alert("Please Enter Form Name");
            document.getElementById('txtname').focus();
            return false;
    
    }
    
  if(document.getElementById("txtalias").value=="")  
    {
           alert("Please Enter Form Alias");
            document.getElementById('txtalias').focus();
            return false;
    
    }
    
   if(mod =="1")
    {
        var formtyp=document.getElementById('drpformtype').value;
        var modulecode=document.getElementById('drpmodcode').value;
        var frmcode=document.getElementById('txtid').value;
        var frmname=document.getElementById('txtname').value;
        var frmalias=document.getElementById('txtalias').value; 
        var compcode=document.getElementById('hiddencompcode').value;

        FormSubbmition.update(compcode,formtyp,modulecode,frmcode,frmname,frmalias);

        //dspubexecute.Tables[0].Rows[z].ENGLISH_BOX=document.getElementById('txtengboxadd').value;
        dspubexecute.Tables[0].Rows[z].FORMTYPE=document.getElementById('drpformtype').value;
        dspubexecute.Tables[0].Rows[z].MODULECODE=document.getElementById('drpmodcode').value;
        dspubexecute.Tables[0].Rows[z].Form_Name=document.getElementById('txtname').value;
        dspubexecute.Tables[0].Rows[z].Form_Alias=document.getElementById('txtalias').value;

         alert("Data Updated Successfully");
                updateStatus();
                if (z==0)
                       {
                        document.getElementById('btnfirst').disabled=true;
                        document.getElementById('btnprevious').disabled=true;
                        }

                     if(z==(dspubexecute.Tables[0].Rows.length-1))
                      {
                        document.getElementById('btnnext').disabled=true;
	                    document.getElementById('btnlast').disabled=true;
                      }       

                document.getElementById('txtid').disabled=true;
                document.getElementById('drpformtype').disabled=true;
                document.getElementById('drpmodcode').disabled=true;
                document.getElementById('txtname').disabled=true;
                document.getElementById('txtalias').disabled=true;
                 setButtonImages();
			         if(document.getElementById('btnModify').disabled==false)      
	                  document.getElementById('btnModify').focus();
	        mod="0";
    return false;
    }
    return;

}
function closeform()
{
  if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
   

}
function btnModifyClick2()
{
 mod="1";
	 hiddentext="mod";	
    document.getElementById('txtid').disabled=true;
    document.getElementById('drpformtype').disabled=false;
    document.getElementById('drpmodcode').disabled=false;
    document.getElementById('txtname').disabled=false;
    document.getElementById('txtalias').disabled=false;
    chkstatus(FlagStatus);
    document.getElementById('btnQuery').disabled = true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnModify').disabled=true;
	document.getElementById('btnSave').disabled = false;
	document.getElementById('btnSave').focus();
    setButtonImages();
return false;
}

function btnQueryClick2()
{
chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	hiddentext="query";
z=0;
document.getElementById('drpformtype').value="0";
document.getElementById('drpmodcode').value="0";
document.getElementById('txtid').value="";
document.getElementById('txtname').value="";
document.getElementById('txtalias').value=""; 

 document.getElementById('txtid').disabled=false;
    document.getElementById('drpformtype').disabled=false;
    document.getElementById('drpmodcode').disabled=false;
    document.getElementById('txtname').disabled=false;
    document.getElementById('txtalias').disabled=false;
setButtonImages();

return false;
}

function btnExecuteClick2()
{
z=0;
var formtyp=document.getElementById('drpformtype').value;
var modulecode=document.getElementById('drpmodcode').value;
var frmcode=document.getElementById('txtid').value;
var frmname=document.getElementById('txtname').value;
var frmalias=document.getElementById('txtalias').value; 
var compcode=document.getElementById('hiddencompcode').value;
globalformtyp=formtyp;
globalmodulecode=modulecode;
globalfrmcode=frmcode;
gloablfrmname=frmname;
gloablfrmalias=frmalias;

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
FormSubbmition.frmexecute(compcode,formtyp,modulecode,frmcode,frmname,frmalias,callexec);
    updateStatus();
    
    document.getElementById('txtid').disabled=true;
    document.getElementById('drpformtype').disabled=true;
    document.getElementById('drpmodcode').disabled=true;
    document.getElementById('txtname').disabled=true;
    document.getElementById('txtalias').disabled=true;
     
    mod="0";
			            document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;
						
					    if(document.getElementById('btnModify').disabled==false)
			                document.getElementById('btnModify').focus();
			return false;
    
}
function callexec(response)
{
    var ds=response.value;
	dspubexecute=response.value;
	    if(dspubexecute.Tables[0].Rows.length > 0)
	    {
			 	//document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[0].CENTERCODE;
			 	document.getElementById('drpformtype').value=dspubexecute.Tables[0].Rows[0].FORMTYPE;
                document.getElementById('drpmodcode').value=dspubexecute.Tables[0].Rows[0].MODULECODE;
                document.getElementById('txtid').value=dspubexecute.Tables[0].Rows[0].Form_code;
                document.getElementById('txtname').value=dspubexecute.Tables[0].Rows[0].Form_Name;
                document.getElementById('txtalias').value=dspubexecute.Tables[0].Rows[0].Form_Alias;
				
				document.getElementById('txtid').disabled=true;
                document.getElementById('drpformtype').disabled=true;
                document.getElementById('drpmodcode').disabled=true;
                document.getElementById('txtname').disabled=true;
                document.getElementById('txtalias').disabled=true;
	    }
	    else
	    {
	        alert("Your Search Produce No Result!!!!");
			btnCancelClick2('FormSubbmition');
		}

         if(dspubexecute.Tables[0].Rows.length ==1)
			{
		        document.getElementById('btnfirst').disabled=true;				
		       document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnprevious').disabled=true;			
		       document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
			return false;
}

function pubcentfirstclick()
{
            	document.getElementById('drpformtype').value=dspubexecute.Tables[0].Rows[0].FORMTYPE;
                document.getElementById('drpmodcode').value=dspubexecute.Tables[0].Rows[0].MODULECODE;
                document.getElementById('txtid').value=dspubexecute.Tables[0].Rows[0].Form_code;
                document.getElementById('txtname').value=dspubexecute.Tables[0].Rows[0].Form_Name;
                document.getElementById('txtalias').value=dspubexecute.Tables[0].Rows[0].Form_Alias;
				
				z=0;
			updateStatus();

		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnExit').disabled=false;
		//fillAdCat1();
		setButtonImages();
			return false;
}
function pubcentpreviousclick()
{
var a=dspubexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
			   // document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[z].CENTERCODE;
			    document.getElementById('drpformtype').value=dspubexecute.Tables[0].Rows[z].FORMTYPE;
                document.getElementById('drpmodcode').value=dspubexecute.Tables[0].Rows[z].MODULECODE;
                document.getElementById('txtid').value=dspubexecute.Tables[0].Rows[z].Form_code;
                document.getElementById('txtname').value=dspubexecute.Tables[0].Rows[z].Form_Name;
                document.getElementById('txtalias').value=dspubexecute.Tables[0].Rows[z].Form_Alias;
			updateStatus();
				document.getElementById('btnfirst').disabled=false;				
		        document.getElementById('btnnext').disabled=false;				
		        document.getElementById('btnprevious').disabled=false;				
		        document.getElementById('btnlast').disabled=false;			
		        document.getElementById('btnExit').disabled=false;
				//fillAdCat1();
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
function pubcentnextclick()
{
var a=dspubexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		   // document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[z].CENTERCODE;
		     	document.getElementById('drpformtype').value=dspubexecute.Tables[0].Rows[z].FORMTYPE;
                document.getElementById('drpmodcode').value=dspubexecute.Tables[0].Rows[z].MODULECODE;
                document.getElementById('txtid').value=dspubexecute.Tables[0].Rows[z].Form_code;
                document.getElementById('txtname').value=dspubexecute.Tables[0].Rows[z].Form_Name;
                document.getElementById('txtalias').value=dspubexecute.Tables[0].Rows[z].Form_Alias;
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			//fillAdCat1();
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
function pubcatlastclick()
{
var y=dspubexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			//document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[z].CENTERCODE;
			 	document.getElementById('drpformtype').value=dspubexecute.Tables[0].Rows[z].FORMTYPE;
                document.getElementById('drpmodcode').value=dspubexecute.Tables[0].Rows[z].MODULECODE;
                document.getElementById('txtid').value=dspubexecute.Tables[0].Rows[z].Form_code;
                document.getElementById('txtname').value=dspubexecute.Tables[0].Rows[z].Form_Name;
                document.getElementById('txtalias').value=dspubexecute.Tables[0].Rows[z].Form_Alias;
			
			updateStatus();
			//fillAdCat1();
		    document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            document.getElementById('btnfirst').disabled=false;
            document.getElementById('btnprevious').disabled=false;
            setButtonImages();
			return false;
}
function btnDeleteClick2()
{
    updateStatus();
var frmcode=document.getElementById('txtid').value;
var compcode=document.getElementById('hiddencompcode').value;
    
    if( confirm("Are You Sure To Delete The Data ?"));
			{
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
       FormSubbmition.frmdelete(compcode, frmcode);

			alert ("Data Deleted Successfully");
			document.getElementById('txtid').value="";
            document.getElementById('drpformtype').value="0";
            document.getElementById('drpmodcode').value="0";
            document.getElementById('txtname').value="";
            document.getElementById('txtalias').value="";
		

		       FormSubbmition.frmexecute(compcode,globalformtyp,globalmodulecode,globalfrmcode,gloablfrmname,gloablfrmalias,delcall);
		     }
		     return false;
}
function delcall(res)
{
 dspubexecute= res.value;
	len=dspubexecute.Tables[0].Rows.length;
	
	if(dspubexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
	      	document.getElementById('txtid').value="";
            document.getElementById('drpformtype').value="0";
            document.getElementById('drpmodcode').value="0";
            document.getElementById('txtname').value="";
            document.getElementById('txtalias').value="";
		 btnCancelClick2('FormSubbmition');
		return false;
	}
	        else if(z>=len || z==-1)
	        {
			    //document.getElementById('drpuncent').value=dscatexecute1.Tables[0].Rows[0].CENTERCODE;
			 	document.getElementById('drpformtype').value=dspubexecute.Tables[0].Rows[0].FORMTYPE;
                document.getElementById('drpmodcode').value=dspubexecute.Tables[0].Rows[0].MODULECODE;
                document.getElementById('txtid').value=dspubexecute.Tables[0].Rows[0].Form_code;
                document.getElementById('txtname').value=dspubexecute.Tables[0].Rows[0].Form_Name;
                document.getElementById('txtalias').value=dspubexecute.Tables[0].Rows[0].Form_Alias;
				
        			
	        }
	        else
	        {
	        //document.getElementById('drpuncent').value=dscatexecute1.Tables[0].Rows[z].CENTERCODE;
	            document.getElementById('drpformtype').value=dspubexecute.Tables[0].Rows[z].FORMTYPE;
                document.getElementById('drpmodcode').value=dspubexecute.Tables[0].Rows[z].MODULECODE;
                document.getElementById('txtid').value=dspubexecute.Tables[0].Rows[z].Form_code;
                document.getElementById('txtname').value=dspubexecute.Tables[0].Rows[z].Form_Name;
                document.getElementById('txtalias').value=dspubexecute.Tables[0].Rows[z].Form_Alias;
	        }
		if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dspubexecute.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       
            if(dspubexecute.Tables[0].Rows.length ==1)
			{
		        document.getElementById('btnfirst').disabled=true;				
		       document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnprevious').disabled=true;			
		       document.getElementById('btnlast').disabled=true;
			}
	setButtonImages();
return false;
}
function btnCancelClick2(formname)
{
//chkstatus(FlagStatus);
//givebuttonpermission(formname);

	document.getElementById('txtid').value="";
    document.getElementById('drpformtype').value="0";
    document.getElementById('drpmodcode').value="0";
    document.getElementById('txtname').value="";
    document.getElementById('txtalias').value="";
    
  	document.getElementById('txtid').disabled=true;
    document.getElementById('drpformtype').disabled=true;
    document.getElementById('drpmodcode').disabled=true;
    document.getElementById('txtname').disabled=true;
    document.getElementById('txtalias').disabled=true;
    
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
return false;
}
//=========function to change image of buttons
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