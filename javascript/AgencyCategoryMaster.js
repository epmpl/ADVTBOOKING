var k="0";
var z=0;
var hiddentext;
var auto="";
var hiddentext1="";
var dsexecute;
var gbagencytype;
var	gbcode;
var	gbname;
var	gbalias;


///************************************************************************************************************//

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





	
function acmNewclick()	
{				
                k="0";
				document.getElementById('txtacccode').value="";
				document.getElementById('txtacnname').value="";	
				document.getElementById('txtalias').value="";
				if(document.getElementById('hiddenauto').value==1)
                  {
                  document.getElementById('txtacccode').disabled=true;
                  }
                 else
                   {
                   document.getElementById('txtacccode').disabled=false;
                   }

				
				document.getElementById('txtacnname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				document.getElementById('drpagencytype').disabled=false;
                if(document.getElementById('hiddenauto').value==1)
                  {
                  document.getElementById('drpagencytype').focus();//=false;
                 //document.getElementById('txtacnname').focus();
                  }
//                 else
//                   {
//                   document.getElementById('txtacccode').focus();
//                   }


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
				chkstatus(FlagStatus);
				hiddentext="new";
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
	        setButtonImages();
				return false;
}


function acmDeleteclick()
{
		var companycode=document.getElementById('hiddencomcode').value;
		var code=document.getElementById('txtacccode').value;
		var name=document.getElementById('txtacnname').value;
		var alias=document.getElementById('txtalias').value;
		var UserId=document.getElementById('hiddenuserid').value;	
	boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
		AgencyCategoryMaster.acmdelete(companycode,code,name,alias,UserId);
		AgencyCategoryMaster.acmexecute(companycode,gbcode,gbname,gbalias,gbagencytype,UserId,delcall);
			
		
		}     
	else
	{
	setButtonImages();
	return false;
	}
		setButtonImages();
		return false;
}
	
function delcall(res)
{
	dsexecute= res.value;
	len=dsexecute.Tables[0].Rows.length;
	
	if(dsexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtacccode').value="";
		document.getElementById('txtacnname').value="";
		document.getElementById('txtalias').value="";
		
		acmCancelclick('AgencyCategoryMaster');
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('txtacccode').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Code;
		document.getElementById('txtacnname').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Name;
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Alias;
		document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[0].agencytype;
	}
	else
	{
		document.getElementById('txtacccode').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Code;
		document.getElementById('txtacnname').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Name;
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Alias;
		document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[z].agencytype;
	}
	if(browser!="Microsoft Internet Explorer")
    {
        alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
    }
    else
    {
	    alert(xmlObj.childNodes(0).childNodes(2).text);
	}
	//alert("Data Deleted Successfully");	
	setButtonImages();
return false;
}

function acmQueryclick()		
{
            hiddentext="query";
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
			z=0;
			chkstatus(FlagStatus);
            document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			
			document.getElementById('txtacccode').value="";
			document.getElementById('txtacnname').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('drpagencytype').value="0";
											
			document.getElementById('txtacccode').disabled=false;
			document.getElementById('txtacnname').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('drpagencytype').disabled=false;
			setButtonImages();
			return false;
}

function acmExecuteclick()
{              
            var agencytype=document.getElementById('drpagencytype').value;
            
			var companycode=document.getElementById('hiddencomcode').value;
			var code=document.getElementById('txtacccode').value;
			var name=document.getElementById('txtacnname').value;
			var alias=document.getElementById('txtalias').value;
			var UserId=document.getElementById('hiddenuserid').value;
					
			
			AgencyCategoryMaster.acmexecute(companycode,code,name,alias,agencytype,UserId,checkcall);
			
			updateStatus();
			
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;*/
								
			document.getElementById('txtacccode').disabled=true;
			document.getElementById('txtacnname').disabled=true;
			document.getElementById('txtalias').disabled=true;
		    document.getElementById('drpagencytype').disabled=true;
		    
		                document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;	
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;*/
				
			setButtonImages();
			return false;			
}

function checkcall(response)
{
		dsexecute=response.value;
		if (dsexecute.Tables[0].Rows.length <= 0)
		{
			alert("Your search can't produce any result");
			acmCancelclick('AgencyCategoryMaster');
			return false;
		}
		else
		{
		var agencytype=document.getElementById('drpagencytype').value;
		gbagencytype=agencytype;
		var companycode=document.getElementById('hiddencomcode').value;
		var code=document.getElementById('txtacccode').value;
		gbcode=code;
		var name=document.getElementById('txtacnname').value;
		gbname=name;
		var alias=document.getElementById('txtalias').value;
		gbalias=alias;
		var UserId=document.getElementById('hiddenuserid').value;	
					
		AgencyCategoryMaster.acmexecute1(companycode,code,name,alias,agencytype,UserId,checkcall1);							
		setButtonImages();
		return false;
		}
}
						
function checkcall1(response)
{
		ds=response.value;
		document.getElementById('txtacccode').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Code;
		document.getElementById('txtacnname').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Name;
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Alias;
		document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[0].agencytype;
		
		if(ds.Tables[0].Rows.length==1)
		{
		        document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
		
		
		}
		setButtonImages();
		return false;
}

function acmCancelclick(formname)
{
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
					chkstatus(FlagStatus);
					givebuttonpermission(formname);
				//getPermission(formname);
				document.getElementById('txtacccode').value="";
				document.getElementById('txtacnname').value="";
				document.getElementById('txtalias').value="";
				  document.getElementById('drpagencytype').value="0";
				document.getElementById('txtacccode').disabled=true;
				document.getElementById('txtacnname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('drpagencytype').disabled=true;
				document.getElementById('btnNew').focus();
                setButtonImages();
				return false;
}


function acmSaveclick()
{           
 document.getElementById('txtacnname').value=trim(document.getElementById('txtacnname').value);
 document.getElementById('txtacccode').value=trim(document.getElementById('txtacccode').value);
 document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
               
            if(document.getElementById('drpagencytype').value=="0")
			{
				alert("Please Select Agency Type");
				document.getElementById('drpagencytype').focus();
				return false;
			}
			else if((document.getElementById('txtacccode').value=="")&&  (document.getElementById('hiddenauto').value!=1))
			{
				alert("Please Fill Agency Category Code");
				document.getElementById('txtacccode').focus();
				return false;
			}
			else if(document.getElementById('txtacnname').value=="")
			{
				alert("Please Fill Agency Category Name");
				document.getElementById('txtacnname').focus();
				return false;
			}
			else if(document.getElementById('txtalias').value=="")
			{
				alert("Please Fill Agency Alias");
				document.getElementById('txtalias').focus();
				return false;
			}
			
			
			else
			  {
			     
			           
				var agencytype=document.getElementById('drpagencytype').value;
				var companycode=document.getElementById('hiddencomcode').value;
				var code=document.getElementById('txtacccode').value;
				var name=document.getElementById('txtacnname').value;
				var alias=document.getElementById('txtalias').value;
				var UserId=document.getElementById('hiddenuserid').value;	
					if(k!="1" && k!=null)
				{
					AgencyCategoryMaster.chkacmcode(companycode,UserId,code,call_saveclick);
				}
				else
				{
					AgencyCategoryMaster.acmmodify(companycode,code,name,alias,agencytype,UserId); 
			       dsexecute.Tables[0].Rows[z].Agency_Cat_Name= document.getElementById('txtacnname').value;
		           dsexecute.Tables[0].Rows[z].Agency_Cat_Alias=document.getElementById('txtalias').value;
		           dsexecute.Tables[0].Rows[z].agencytype=document.getElementById('drpagencytype').value;
	                if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                    }
                    else
                    {
	                    alert(xmlObj.childNodes(0).childNodes(1).text);
	                }
					//alert("Data Modified Successfully");
					updateStatus();
					
					document.getElementById('txtacccode').disabled=true;
					document.getElementById('txtacnname').disabled=true;
					document.getElementById('txtalias').disabled=true;
					  document.getElementById('drpagencytype').disabled=true;
					   
					/*document.getElementById('btnNew').disabled=true;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=false;
					document.getElementById('btnQuery').disabled=true;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;		
					
							
											
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;*/
					
					k="0";
				}
			}
			setButtonImages();
			return false;
}

function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Agency Category Code Is Already Exist, Try Another Code !!!!");
				return false;
			} 
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var code=document.getElementById('txtacccode').value;
				var name=document.getElementById('txtacnname').value;
				var alias=document.getElementById('txtalias').value;
				var UserId=document.getElementById('hiddenuserid').value;	
               var agencytype=document.getElementById('drpagencytype').value;
			
				AgencyCategoryMaster.acmsave(companycode,code,name,alias,agencytype,UserId);
                if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
		            alert(xmlObj.childNodes(0).childNodes(0).text);
		        }
				//alert("Data Saved Successfully");

				document.getElementById('txtacccode').value="";
				document.getElementById('txtacnname').value="";
				document.getElementById('txtalias').value="";
			   document.getElementById('drpagencytype').value="0";		
				document.getElementById('txtacccode').disabled=true;
				document.getElementById('txtacnname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('drpagencytype').disabled=true;				
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
			acmCancelclick('AgencyCategoryMaster');
			setButtonImages();
			return false;
}


function acmModifyclick()
{
				document.getElementById('txtacccode').disabled=true;
				document.getElementById('txtacnname').disabled=false;
				document.getElementById('txtalias').disabled=false;
					document.getElementById('drpagencytype').disabled=false;
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
				chkstatus(FlagStatus);
				hiddentext="modify";
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnDelete').disabled=true;

				k="1";
			setButtonImages();
				
				return false;
}

/*function acmfirstclick()
{				
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				
				AgencyCategoryMaster.acmfirst(companycode,UserId,firstcall);
					
				document.getElementById('txtacccode').disabled=true;
				document.getElementById('txtacnname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('drpagencytype').disabled=true;
				
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;	
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;	
		
				return false;
}*/

function acmfirstclick()
{
				//ds=response.value;
				document.getElementById('txtacccode').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Code;
				document.getElementById('txtacnname').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Name;
				document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_Cat_Alias;
			    document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[0].agencytype;
				z=0;
				updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;	
			setButtonImages();
				return false;
}

/*function acmpreviousclick()
{
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				
				AgencyCategoryMaster.acmprevious(companycode,UserId,previouscall);
				
				return false;
}*/



function acmpreviousclick()
{
		//var ds=response.value;
		var a=dsexecute.Tables[0].Rows.length;

		z--;
		if(z != -1  )
		{
		if(z >= 0 && z < a)
		{
		
		    document.getElementById('txtacccode').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Code;
			document.getElementById('txtacnname').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Name;
			document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Alias;
		   document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[z].agencytype;
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


/*function acmnextclick()
{
		
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				AgencyCategoryMaster.acmnext(companycode,UserId,nextcall);
				return false;
}*/

function acmnextclick()
{		
		z++;
		//ds=response.value;
		var x=dsexecute.Tables[0].Rows.length;
		if(z <= x && z >= 0)
		{
			if(dsexecute.Tables[0].Rows.length != z && z !=-1)
			{
				document.getElementById('txtacccode').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Code;
				document.getElementById('txtacnname').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Name;
				document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_Cat_Alias;
				   document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[z].agencytype;
				updateStatus();
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnlast').disabled=false;
				
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
		
		if(z==x-1)
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		setButtonImages();
		return false;
}

/*function acmlastclick()
{		
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				AgencyCategoryMaster.acmlast(companycode,UserId,lastcall)
				return false;
}*/


function acmexitclick()
	{
	if(confirm("Do You Want To Skip This Page"))
	{
	window.close();
	return false;
	}
	
	return false;
	
	}

function acmlastclick()
{
		 //ds= response.value;
     	 var x=dsexecute.Tables[0].Rows.length;
		 z=x-1;
		 x=x-1;

		document.getElementById('txtacccode').value=dsexecute.Tables[0].Rows[x].Agency_Cat_Code;
		document.getElementById('txtacnname').value=dsexecute.Tables[0].Rows[x].Agency_Cat_Name;
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[x].Agency_Cat_Alias;
		document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[x].agencytype;
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
		return false;
}


/*-------------------------------------------------------------------------------------------*/
function uppercase1()
{
document.getElementById('txtacccode').value=document.getElementById('txtacccode').value.toUpperCase();
return ;
}
		


function uppercase2()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
return ;
}
		
function charval()
{
if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==37)||
(event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||
(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function charval1()
{
if((event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==37)||(event.keyCode==32))
{
return true;
}
else
{
return false;
}
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

    return false;
    }
return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
document.getElementById('txtacnname').value=document.getElementById('txtacnname').value.toUpperCase();
if(hiddentext=="new" )
			{
	
            uppercaseacm();
           
           }
            else
            {
            document.getElementById('txtacnname').value=document.getElementById('txtacnname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercaseacm()
		{
		document.getElementById('txtacnname').value=trim(document.getElementById('txtacnname').value);
        	  lstr=document.getElementById('txtacnname').value;
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
		
		    if(document.getElementById('txtacnname').value!="")
               {
		document.getElementById('txtacnname').value=document.getElementById('txtacnname').value.toUpperCase();
		document.getElementById('txtalias').value=document.getElementById('txtacnname').value;
	   // str=document.getElementById('txtacnname').value;
	   str=mstr;
		AgencyCategoryMaster.chkacmcodename(str,document.getElementById('drpagencytype').value,fillcall);
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
		    alert("This Agency Sub Category Name has already assigned !! ");
		    document.getElementById('txtacnname').value="";
             document.getElementById('txtacccode').value="";
             document.getElementById('txtalias').value="";
               
		    document.getElementById('txtacnname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Agency_Cat_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                      //  var code=newstr.substr(2,4);
		                      var code=newstr;
		                      str=str.toUpperCase();
		                        code++;
		                        document.getElementById('txtacccode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                           str=str.toUpperCase();
		                          document.getElementById('txtacccode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtacccode').disabled=false;
        document.getElementById('txtacnname').value=document.getElementById('txtacnname').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtacnname').value;
	   
         auto=document.getElementById('hiddenauto').value;
         return false;
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




function onload_fun() {

    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnModify').disabled = true;
    document.getElementById('btnQuery').disabled = false;
    document.getElementById('btnExecute').disabled = true;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnDelete').disabled = true;
    document.getElementById('btnExit').disabled = false;
    setButtonImages();
    return false;
}