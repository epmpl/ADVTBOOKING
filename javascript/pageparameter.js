//this for update and save

var modify="0";
//var for exe f/n/p/l  
var dataexe="";
//this is for f,p,n,l

var z="0";
//this flag is for permission
var flag="";
var editionvar="";
var hiddentext;
var gbdrpadvtype;
var gbtxtpagecode;
var gbdrpedition;
var gbdrpadvcategory;
var gbdrocolor;
var gbtxtpageno;
var gbtxtadvsize;

function newclick()
{
  hiddentext="new";			
	       
document.getElementById('drpadvtype').value="0";
document.getElementById('txtpagecode').value="";
document.getElementById('drpedition').value="0";
document.getElementById('drpadvcategory').value="0";
document.getElementById('drpcolor').value="0";
document.getElementById('txtpageno').value="";
document.getElementById('txtadvsize').value="";
document.getElementById('txtcolno').value="";
document.getElementById('drpuom').value="0";
document.getElementById('txtremarks').value="";
document.getElementById('drpPubName').value="0";

document.getElementById('drpPubName').disabled=false;
document.getElementById('drpadvtype').disabled=false;
if(document.getElementById('hiddenauto').value==1)
     {
     document.getElementById('txtpagecode').disabled=true;
     document.getElementById('drpadvtype').focus();
     autoornot();
     }
else
    {
    document.getElementById('txtpagecode').disabled=false;
    document.getElementById('txtpagecode').focus();
    }
			
document.getElementById('drpedition').disabled=false;


document.getElementById('drpcolor').disabled=false;
document.getElementById('txtpageno').disabled=false;
document.getElementById('txtadvsize').disabled=false;
document.getElementById('drpadvcategory').disabled=false;
document.getElementById('txtcolno').disabled=false;
document.getElementById('drpuom').disabled=false;
document.getElementById('txtremarks').disabled=false;

chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
flag=0;


return false;

}
function modifyclick()
{
document.getElementById('drpadvtype').disabled=false;
document.getElementById('txtpagecode').disabled=true;
document.getElementById('drpedition').disabled=false;
document.getElementById('drpadvcategory').disabled=false;
document.getElementById('drpcolor').disabled=false;
document.getElementById('txtpageno').disabled=false;
document.getElementById('txtadvsize').disabled=false;
document.getElementById('txtcolno').disabled=false;
document.getElementById('drpuom').disabled=false;
document.getElementById('txtremarks').disabled=false;
document.getElementById('drpPubName').disabled=false;
chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;
document.getElementById('btnQuery').disabled = true;


document.getElementById('btnNew').disabled=true;
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
flag=1;		document.getElementById('btnSave').focus();

modify="1";
return false;
}
function queryclick()
{
z=0;
document.getElementById('drpadvtype').disabled=false;
document.getElementById('txtpagecode').disabled=false;
document.getElementById('drpedition').disabled=false;
document.getElementById('drpadvcategory').disabled=false;
document.getElementById('drpcolor').disabled=false;
document.getElementById('txtpageno').disabled=false;
document.getElementById('txtadvsize').disabled=false;
document.getElementById('drpPubName').disabled=false;

document.getElementById('drpadvtype').value="0";
document.getElementById('txtpagecode').value="";
document.getElementById('drpedition').value="0";
document.getElementById('drpadvcategory').value="0";
document.getElementById('drpcolor').value="0";
document.getElementById('txtpageno').value="";
document.getElementById('txtadvsize').value="";
document.getElementById('txtcolno').value="";
document.getElementById('drpuom').value="0";
document.getElementById('txtremarks').value="";
document.getElementById('drpPubName').value="0";
chkstatus(FlagStatus);

document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=false;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;
			
	document.getElementById('btnExecute').focus();

modify="0";
return false;
}

function cancelclick(formname)
{
    document.getElementById('drpadvtype').value="0";
    document.getElementById('txtpagecode').value="";
    document.getElementById('drpedition').value="0";
    document.getElementById('drpedition').options.length=1;
    document.getElementById('drpadvcategory').value="0";
    document.getElementById('drpcolor').value="0";
    document.getElementById('txtpageno').value="";
    document.getElementById('txtadvsize').value="";
    document.getElementById('txtcolno').value="";
    document.getElementById('drpuom').value="0";
    document.getElementById('txtremarks').value="";
    document.getElementById('drpPubName').value="0";

    document.getElementById('drpadvtype').disabled=true;
    document.getElementById('txtpagecode').disabled=true;
    document.getElementById('drpedition').disabled=true;
    document.getElementById('drpadvcategory').disabled=true;
    document.getElementById('drpcolor').disabled=true;
    document.getElementById('txtpageno').disabled=true;
    document.getElementById('txtadvsize').disabled=true;
    document.getElementById('txtcolno').disabled=true;
    document.getElementById('drpuom').disabled=true;
    document.getElementById('drpPubName').disabled=true;

    document.getElementById('txtremarks').disabled=true;


				
    givebuttonpermission(formname);

    if(document.getElementById('btnNew').disabled==false)
        document.getElementById('btnNew').focus();
				


    modify="0";
    return false;
}


function exitclick()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			window.close();
			return false;
		}
		return false;

}



function saveclick()
{
if(document.getElementById('txtpagecode').value=="")
{
alert("Please Enter The Page Code");
document.getElementById('txtpagecode').focus();
return false;
}
else if(document.getElementById('drpadvtype').value=="0")
{
alert("Please Fill The Ad Type");
document.getElementById('drpadvtype').focus();
return false;
}

else if(document.getElementById('drpPubName').value=="0")
{
alert("Please Enter Publication");
document.getElementById('drpPubName').focus();
return false;
}
else if(document.getElementById('drpedition').value=="0")
{
alert("Please Fill The Edition");
document.getElementById('drpedition').focus();
return false;
}
else if(document.getElementById('drpadvcategory').value=="0")
{
alert("Please Fill The Ad Category ");
document.getElementById('drpadvcategory').focus();
return false;
}
else if(document.getElementById('drpcolor').value=="0")
{
alert("Please Fill The Color");
document.getElementById('drpcolor').focus();
return false;
}
else if(document.getElementById('txtpageno').value=="")
{
alert("Please Enter The Page No.");
document.getElementById('txtpageno').focus();
return false;
}
else if(document.getElementById('txtadvsize').value=="")
{
alert("Please Enter The Max Ad Size");
document.getElementById('txtadvsize').focus();
return false;
}
else if(document.getElementById('drpuom').value=="0")
{
alert("Please Select UOM");
document.getElementById('drpuom').focus();
return false;
}


var drpadvtype=document.getElementById('drpadvtype').value;
var txtpagecode=document.getElementById('txtpagecode').value;
var drpedition=document.getElementById('drpedition').value;
var drpadvcategory=document.getElementById('drpadvcategory').value;
var drocolor=document.getElementById('drpcolor').value;
var txtpageno=document.getElementById('txtpageno').value;
var txtadvsize=document.getElementById('txtadvsize').value;
var txtcolno=document.getElementById('txtcolno').value;
var drpuom=document.getElementById('drpuom').value;
var txtremarks=document.getElementById('txtremarks').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var pub=document.getElementById('drpPubName').value;
if(modify!="1" && modify!=null)
{
Pageparametermaster.checkpagecode(txtpagecode,compcode,userid,call_save);


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
else
{
Pageparametermaster.update(drpadvtype,txtpagecode,drpedition,drocolor,txtpageno,txtadvsize,txtcolno,drpuom,txtremarks,compcode,userid,drpadvcategory,pub);
dataexe.Tables[0].Rows[z].Adv_Type_Code=document.getElementById('drpadvtype').value;
dataexe.Tables[0].Rows[z].Pg_param_code=document.getElementById('txtpagecode').value;
dataexe.Tables[0].Rows[z].Edition_code=document.getElementById('drpedition').value;
dataexe.Tables[0].Rows[z].Adv_Cat_Code=document.getElementById('drpadvcategory').value;
dataexe.Tables[0].Rows[z].Col_Code=document.getElementById('drpcolor').value;
dataexe.Tables[0].Rows[z].Page_No=document.getElementById('txtpageno').value;
dataexe.Tables[0].Rows[z].Adv_Max_Space=document.getElementById('txtadvsize').value;
dataexe.Tables[0].Rows[z].Column_No=document.getElementById('txtcolno').value;
dataexe.Tables[0].Rows[z].UOM_Code=document.getElementById('drpuom').value;
dataexe.Tables[0].Rows[z].Remarks=document.getElementById('txtremarks').value;
dataexe.Tables[0].Rows[z].publication=document.getElementById('drpPubName').value;
flag=0;
					//updateStatus();

alert("Data Updated Successfully");

document.getElementById('drpadvtype').disabled=true;
document.getElementById('txtpagecode').disabled=true;
document.getElementById('drpedition').disabled=true;
document.getElementById('drpadvcategory').disabled=true;
document.getElementById('drpcolor').disabled=true;
document.getElementById('txtpageno').disabled=true;
document.getElementById('txtadvsize').disabled=true;
document.getElementById('txtcolno').disabled=true;
document.getElementById('drpuom').disabled=true;
document.getElementById('drpPubName').disabled=true;

document.getElementById('txtremarks').disabled=true;


document.getElementById('btnNew').disabled=true;

	
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=false;
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;		
					
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					document.getElementById('btnExit').disabled=false;
					
		    if(z==0)
			{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;

			}
			if(z==dataexe.Tables[0].Rows.length-1)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
		
			}


modify="0";
return false;
}

return false;


}

function call_save(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	alert("This Code Has Been Assigned");
	return false;
	}
	else
	{
	var drpadvtype=document.getElementById('drpadvtype').value;
var txtpagecode=document.getElementById('txtpagecode').value;
var drpedition=document.getElementById('drpedition').value;
var drpadvcategory=document.getElementById('drpadvcategory').value;
var drocolor=document.getElementById('drpcolor').value;
var txtpageno=document.getElementById('txtpageno').value;
var txtadvsize=document.getElementById('txtadvsize').value;
var txtcolno=document.getElementById('txtcolno').value;
var drpuom=document.getElementById('drpuom').value;
var txtremarks=document.getElementById('txtremarks').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var pub=document.getElementById('drpPubName').value;

Pageparametermaster.savecode(drpadvtype,txtpagecode,drpedition,drocolor,txtpageno,txtadvsize,txtcolno,drpuom,txtremarks,compcode,userid,drpadvcategory,pub);

document.getElementById('drpadvtype').value="0";
document.getElementById('txtpagecode').value="";
document.getElementById('drpedition').value="0";
document.getElementById('drpadvcategory').value="0";
document.getElementById('drpcolor').value="0";
document.getElementById('txtpageno').value="";
document.getElementById('txtadvsize').value="";
document.getElementById('txtcolno').value="";
document.getElementById('drpuom').value="0";
document.getElementById('txtremarks').value="";
document.getElementById('drpPubName').value="0";

document.getElementById('drpadvtype').disabled=true;
document.getElementById('txtpagecode').disabled=true;
document.getElementById('drpedition').disabled=true;
document.getElementById('drpadvcategory').disabled=true;
document.getElementById('drpcolor').disabled=true;
document.getElementById('txtpageno').disabled=true;
document.getElementById('txtadvsize').disabled=true;
document.getElementById('txtcolno').disabled=true;
document.getElementById('drpuom').disabled=true;
document.getElementById('txtremarks').disabled=true;
document.getElementById('drpPubName').disabled=true;

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

cancelclick('Pageparametermaster');

alert("Data Saved Successfully");
	
	}
	return false;
}

function executeclick()
{
var drpadvtype=document.getElementById('drpadvtype').value;
gbdrpadvtype=drpadvtype;
var txtpagecode=document.getElementById('txtpagecode').value;
gbtxtpagecode=txtpagecode;
var drpedition=document.getElementById('drpedition').value;
gbdrpedition=drpedition;
var drpadvcategory=document.getElementById('drpadvcategory').value;
gbdrpadvcategory=drpadvcategory;
var drocolor=document.getElementById('drpcolor').value;
gbdrocolor=drocolor;
var txtpageno=document.getElementById('txtpageno').value;
gbtxtpageno=txtpageno;
var txtadvsize=document.getElementById('txtadvsize').value;
gbtxtadvsize=txtadvsize;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

Pageparametermaster.execute(drpadvtype,txtpagecode,drpedition,drpadvcategory,drocolor,txtpageno,txtadvsize,compcode,userid,call_execute);


document.getElementById('drpadvtype').disabled=true;
document.getElementById('txtpagecode').disabled=true;
document.getElementById('drpedition').disabled=true;
document.getElementById('drpadvcategory').disabled=true;
document.getElementById('drpcolor').disabled=true;
document.getElementById('txtpageno').disabled=true;
document.getElementById('txtadvsize').disabled=true;
document.getElementById('txtcolno').disabled=true;
document.getElementById('drpuom').disabled=true;
document.getElementById('txtremarks').disabled=true;
document.getElementById('drpPubName').disabled=true;
//updateStatus();

document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
return false;
}
function call_execute(response)
{
dataexe=response.value;
if(dataexe.Tables[0].Rows.length <= 0)
	{
	//cancelclick('Pageparametermaster');
	alert("Your Search Criteria Doesn't Produce Any Result!!!");	
	 
	    document.getElementById('drpadvtype').value="0";
    document.getElementById('txtpagecode').value="";
    document.getElementById('drpedition').value="0";
    document.getElementById('drpadvcategory').value="0";
    cancelclick('Pageparametermaster');    
	return false;
	}
	else
	{
	var drpadvtype=document.getElementById('drpadvtype').value=dataexe.Tables[0].Rows[0].Adv_Type_Code;
var txtpagecode=document.getElementById('txtpagecode').value=dataexe.Tables[0].Rows[0].Pg_param_code;
//var drpedition=document.getElementById('drpedition').value=dataexe.Tables[0].Rows[0].Edition_code;
var drpadvcategory=document.getElementById('drpadvcategory').value=dataexe.Tables[0].Rows[0].Adv_Cat_Code;
var drocolor=document.getElementById('drpcolor').value=dataexe.Tables[0].Rows[0].Col_Code;
var txtpageno=document.getElementById('txtpageno').value=dataexe.Tables[0].Rows[0].Page_No;
var txtadvsize=document.getElementById('txtadvsize').value=dataexe.Tables[0].Rows[0].Adv_Max_Space;

if(dataexe.Tables[0].Rows[0].Column_No!=null)
{
var txtcolno=document.getElementById('txtcolno').value=dataexe.Tables[0].Rows[0].Column_No;
}
else
{
var txtcolno=document.getElementById('txtcolno').value="";
}
var drpuom=document.getElementById('drpuom').value=dataexe.Tables[0].Rows[0].UOM_Code;
if(dataexe.Tables[0].Rows[0].Remarks!=null)
{
var txtremarks=document.getElementById('txtremarks').value=dataexe.Tables[0].Rows[0].Remarks;
}
else
{
var txtremarks=document.getElementById('txtremarks').value="";
}
document.getElementById('drpPubName').value=dataexe.Tables[0].Rows[0].publication;
editionvar=dataexe.Tables[0].Rows[0].Edition_code;
addcount(dataexe.Tables[0].Rows[0].publication);
updateStatus();

//                        document.getElementById('btnNew').disabled=true;
//						document.getElementById('btnSave').disabled=true;
//						document.getElementById('btnModify').disabled=false;
//						document.getElementById('btnDelete').disabled=false;
//						document.getElementById('btnQuery').disabled=false;
//						document.getElementById('btnExecute').disabled=true;
//						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;	
						document.getElementById('btnExit').disabled=false;
    
	}
	if(dataexe.Tables[0].Rows.length==1)
	{
	                document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=true;	
						
	}
document.getElementById('drpedition').disabled=true;
	document.getElementById('btnQuery').disabled=false;
    document.getElementById('btnExecute').disabled=true;
    
    if(document.getElementById('btnModify').disabled==false)
    	document.getElementById('btnModify').focus();
    

    
    
return false;
}

function firstclick()
{
Pageparametermaster.first(call_first);

return false;
}
function call_first(response)
{
//var dataexe=response.value;
z=0;

var drpadvtype=document.getElementById('drpadvtype').value=dataexe.Tables[0].Rows[0].Adv_Type_Code;
var txtpagecode=document.getElementById('txtpagecode').value=dataexe.Tables[0].Rows[0].Pg_param_code;
//var drpedition=document.getElementById('drpedition').value=dataexe.Tables[0].Rows[0].Edition_code;
var drpadvcategory=document.getElementById('drpadvcategory').value=dataexe.Tables[0].Rows[0].Adv_Cat_Code;
var drocolor=document.getElementById('drpcolor').value=dataexe.Tables[0].Rows[0].Col_Code;
var txtpageno=document.getElementById('txtpageno').value=dataexe.Tables[0].Rows[0].Page_No;
var txtadvsize=document.getElementById('txtadvsize').value=dataexe.Tables[0].Rows[0].Adv_Max_Space;

if(dataexe.Tables[0].Rows[0].Column_No!=null)
{
var txtcolno=document.getElementById('txtcolno').value=dataexe.Tables[0].Rows[0].Column_No;
}
else
{
var txtcolno=document.getElementById('txtcolno').value="";
}
var drpuom=document.getElementById('drpuom').value=dataexe.Tables[0].Rows[0].UOM_Code;
if(dataexe.Tables[0].Rows[0].Remarks!=null)
{
var txtremarks=document.getElementById('txtremarks').value=dataexe.Tables[0].Rows[0].Remarks;
}
else
{
var txtremarks=document.getElementById('txtremarks').value="";
}
document.getElementById('drpPubName').value=dataexe.Tables[0].Rows[0].publication;	
editionvar=dataexe.Tables[0].Rows[0].Edition_code;
addcount(dataexe.Tables[0].Rows[0].publication);


//updateStatus();



//document.getElementById('btnfirst').disabled=true;				
//	document.getElementById('btnprevious').disabled=true;	
	document.getElementById('drpedition').disabled=true;
	document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=false;	
				document.getElementById('btnModify').focus();


return false;
}

function lastclick()
{
Pageparametermaster.first(call_last);


return false;
}
function call_last(response)
{
//var dataexe=response.value;
var y=dataexe.Tables[0].Rows.length;
var a=y-1;
//z=dataexe.Tables[0].Rows.length;
z=a;
var drpadvtype=document.getElementById('drpadvtype').value=dataexe.Tables[0].Rows[a].Adv_Type_Code;
var txtpagecode=document.getElementById('txtpagecode').value=dataexe.Tables[0].Rows[a].Pg_param_code;
//var drpedition=document.getElementById('drpedition').value=dataexe.Tables[0].Rows[a].Edition_code;
var drpadvcategory=document.getElementById('drpadvcategory').value=dataexe.Tables[0].Rows[a].Adv_Cat_Code;
var drocolor=document.getElementById('drpcolor').value=dataexe.Tables[0].Rows[a].Col_Code;
var txtpageno=document.getElementById('txtpageno').value=dataexe.Tables[0].Rows[a].Page_No;
var txtadvsize=document.getElementById('txtadvsize').value=dataexe.Tables[0].Rows[a].Adv_Max_Space;
if(dataexe.Tables[0].Rows[a].Column_No!=null)
{
var txtcolno=document.getElementById('txtcolno').value=dataexe.Tables[0].Rows[a].Column_No;
}
else
{
var txtcolno=document.getElementById('txtcolno').value="";
}
var drpuom=document.getElementById('drpuom').value=dataexe.Tables[0].Rows[a].UOM_Code;
if(dataexe.Tables[0].Rows[a].Remarks!=null)
{
var txtremarks=document.getElementById('txtremarks').value=dataexe.Tables[0].Rows[a].Remarks;
}
else
{
var txtremarks=document.getElementById('txtremarks').value="";
}
	document.getElementById('drpPubName').value=dataexe.Tables[0].Rows[a].publication;
	editionvar=dataexe.Tables[0].Rows[a].Edition_code;
		addcount(dataexe.Tables[0].Rows[a].publication);

updateStatus();
document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;	
	document.getElementById('drpedition').disabled=true;
	document.getElementById('btnModify').focus();

return false;
}

function previousclick()
{
Pageparametermaster.first(call_previous);
return false;
}

function call_previous(response)
{
//var dataexe=response.value;
var a=dataexe.Tables[0].Rows.length;

z--;
if(z != -1  )
		{
			if(z >= 0 && z<a)
			{
			var drpadvtype=document.getElementById('drpadvtype').value=dataexe.Tables[0].Rows[z].Adv_Type_Code;
var txtpagecode=document.getElementById('txtpagecode').value=dataexe.Tables[0].Rows[z].Pg_param_code;
//var drpedition=document.getElementById('drpedition').value=dataexe.Tables[0].Rows[z].Edition_code;
var drpadvcategory=document.getElementById('drpadvcategory').value=dataexe.Tables[0].Rows[z].Adv_Cat_Code;
var drocolor=document.getElementById('drpcolor').value=dataexe.Tables[0].Rows[z].Col_Code;
var txtpageno=document.getElementById('txtpageno').value=dataexe.Tables[0].Rows[z].Page_No;
var txtadvsize=document.getElementById('txtadvsize').value=dataexe.Tables[0].Rows[z].Adv_Max_Space;
if(dataexe.Tables[0].Rows[z].Column_No!=null)
{
var txtcolno=document.getElementById('txtcolno').value=dataexe.Tables[0].Rows[z].Column_No;
}
else
{
var txtcolno=document.getElementById('txtcolno').value="";
}
var drpuom=document.getElementById('drpuom').value=dataexe.Tables[0].Rows[z].UOM_Code;
if(dataexe.Tables[0].Rows[z].Remarks!=null)
{
var txtremarks=document.getElementById('txtremarks').value=dataexe.Tables[0].Rows[z].Remarks;
}
else
{
var txtremarks=document.getElementById('txtremarks').value="";
}
document.getElementById('drpPubName').value=dataexe.Tables[0].Rows[z].publication;
editionvar=dataexe.Tables[0].Rows[z].Edition_code;
addcount(dataexe.Tables[0].Rows[z].publication);

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
document.getElementById('drpedition').disabled=true;
if(document.getElementById('btnModify').disabled==false)
    document.getElementById('btnModify').focus();
		return false;
}

function nextclick()
{
Pageparametermaster.first(call_next);

return false;
}
function call_next(response)
{

var a=dataexe.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		updateStatus();
		var drpadvtype=document.getElementById('drpadvtype').value=dataexe.Tables[0].Rows[z].Adv_Type_Code;
var txtpagecode=document.getElementById('txtpagecode').value=dataexe.Tables[0].Rows[z].Pg_param_code;
//var drpedition=document.getElementById('drpedition').value=dataexe.Tables[0].Rows[z].Edition_code;
var drpadvcategory=document.getElementById('drpadvcategory').value=dataexe.Tables[0].Rows[z].Adv_Cat_Code;
var drocolor=document.getElementById('drpcolor').value=dataexe.Tables[0].Rows[z].Col_Code;
var txtpageno=document.getElementById('txtpageno').value=dataexe.Tables[0].Rows[z].Page_No;
var txtadvsize=document.getElementById('txtadvsize').value=dataexe.Tables[0].Rows[z].Adv_Max_Space;
if(dataexe.Tables[0].Rows[z].Column_No!=null)
{
var txtcolno=document.getElementById('txtcolno').value=dataexe.Tables[0].Rows[z].Column_No;
}
else
{
var txtcolno=document.getElementById('txtcolno').value="";
}
var drpuom=document.getElementById('drpuom').value=dataexe.Tables[0].Rows[z].UOM_Code;
if(dataexe.Tables[0].Rows[z].Remarks!=null)
{
var txtremarks=document.getElementById('txtremarks').value=dataexe.Tables[0].Rows[z].Remarks;
}
else
{
var txtremarks=document.getElementById('txtremarks').value="";
}
document.getElementById('drpPubName').value=dataexe.Tables[0].Rows[z].publication;
editionvar=dataexe.Tables[0].Rows[z].Edition_code;
		addcount(dataexe.Tables[0].Rows[z].publication);
	
//document.getElementById('btnnext').disabled=true;
			//document.getElementById('btnlast').disabled=true;
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
		document.getElementById('drpedition').disabled=true;
		if(document.getElementById('btnModify').disabled==false)
		    document.getElementById('btnModify').focus();
return false;
}
function deleteclick()
{
var txtpagecode=document.getElementById('txtpagecode').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if(confirm("Are You Confirm To Delete The Data"))
{
Pageparametermaster.deletepage(txtpagecode,compcode,userid);
alert("Data Deleted Sucessfully");
//Pageparametermaster.first(call_delete);
Pageparametermaster.execute(gbdrpadvtype,gbtxtpagecode,gbdrpedition,gbdrpadvcategory,gbdrocolor,gbtxtpageno,gbtxtadvsize,compcode,userid,call_delete);


}


return false;
}
function call_delete(response)
{
 dataexe=response.value;
	var a=dataexe.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
	alert("There Is No Data In The Database");
document.getElementById('drpadvtype').value="0";
document.getElementById('txtpagecode').value="";
document.getElementById('drpedition').value="0";
document.getElementById('drpadvcategory').value="0";
document.getElementById('drpcolor').value="0";
document.getElementById('txtpageno').value="";
document.getElementById('txtadvsize').value="";
document.getElementById('txtcolno').value="";
document.getElementById('drpuom').value="0";
document.getElementById('txtremarks').value="";	
document.getElementById('drpPubName').value="";
cancelclick('Pageparametermaster');
return false;
	}
	
	else if(z==-1 ||z>=a)
	{
	var drpadvtype=document.getElementById('drpadvtype').value=dataexe.Tables[0].Rows[0].Adv_Type_Code;
var txtpagecode=document.getElementById('txtpagecode').value=dataexe.Tables[0].Rows[0].Pg_param_code;
var drpedition=document.getElementById('drpedition').value=dataexe.Tables[0].Rows[0].Edition_code;
var drpadvcategory=document.getElementById('drpadvcategory').value=dataexe.Tables[0].Rows[0].Adv_Cat_Code;
var drocolor=document.getElementById('drpcolor').value=dataexe.Tables[0].Rows[0].Col_Code;
var txtpageno=document.getElementById('txtpageno').value=dataexe.Tables[0].Rows[0].Page_No;
var txtadvsize=document.getElementById('txtadvsize').value=dataexe.Tables[0].Rows[0].Adv_Max_Space;
var txtcolno=document.getElementById('txtcolno').value=dataexe.Tables[0].Rows[0].Column_No;
var drpuom=document.getElementById('drpuom').value=dataexe.Tables[0].Rows[0].UOM_Code;
if(dataexe.Tables[0].Rows[0].Remarks!=null)
{
var txtremarks=document.getElementById('txtremarks').value=dataexe.Tables[0].Rows[0].Remarks;
}
else
{
var txtremarks=document.getElementById('txtremarks').value="";
}
document.getElementById('drpPubName').value=dataexe.Tables[0].Rows[0].publication;
editionvar=dataexe.Tables[0].Rows[0].Edition_code;
		addcount(dataexe.Tables[0].Rows[0].publication);
	}
	else
	{
	var drpadvtype=document.getElementById('drpadvtype').value=dataexe.Tables[0].Rows[z].Adv_Type_Code;
var txtpagecode=document.getElementById('txtpagecode').value=dataexe.Tables[0].Rows[z].Pg_param_code;
var drpedition=document.getElementById('drpedition').value=dataexe.Tables[0].Rows[z].Edition_code;
var drpadvcategory=document.getElementById('drpadvcategory').value=dataexe.Tables[0].Rows[z].Adv_Cat_Code;
var drocolor=document.getElementById('drpcolor').value=dataexe.Tables[0].Rows[z].Col_Code;
var txtpageno=document.getElementById('txtpageno').value=dataexe.Tables[0].Rows[z].Page_No;
var txtadvsize=document.getElementById('txtadvsize').value=dataexe.Tables[0].Rows[z].Adv_Max_Space;
if(dataexe.Tables[0].Rows[z].Column_No!=null)
{
var txtcolno=document.getElementById('txtcolno').value=dataexe.Tables[0].Rows[z].Column_No;
}
else
{
var txtcolno=document.getElementById('txtcolno').value="";
}
var drpuom=document.getElementById('drpuom').value=dataexe.Tables[0].Rows[z].UOM_Code;
if(dataexe.Tables[0].Rows[z].Remarks!=null)
{
var txtremarks=document.getElementById('txtremarks').value=dataexe.Tables[0].Rows[z].Remarks;
}
else
{
var txtremarks=document.getElementById('txtremarks').value="";
}
document.getElementById('drpPubName').value=dataexe.Tables[0].Rows[z].publication;
editionvar=dataexe.Tables[0].Rows[z].Edition_code;
		addcount(dataexe.Tables[0].Rows[z].publication);
	}
	document.getElementById('drpedition').disabled=true;
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
if(hiddentext=="new" )
			{
	
           Pageparametermaster.chkpagecode(fillcall);
           }
           
return false;
}


//auto generated
//this is used for increment in code


function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		           if(ds.Tables[0].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[0].Rows[0].Pg_param_code;
		                        }
		                    if(newstr !=null )
		                        {
		                       var code=newstr.substr(2,4);
		                        code++;
		                        document.getElementById('txtpagecode').value="PP"+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtpagecode').value="PP"+ "0";
		                          }
		     return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtpagecode').disabled=false;
         auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}

////////////This function is used to generate city corresponding to particular country/////////
function addcount(ab)
{

if(document.getElementById('drpPubName').value!="0")
{
var pubname=document.getElementById('drpPubName').value;
document.getElementById('drpedition').disabled=false;

Pageparametermaster.addedition(pubname,callbind);
return false;

}
else
{
   document.getElementById('drpedition').value="0";
   return false;
     
}

return false;
}
/////////This function is call back response for filling city///////
function callbind(res)
{

var ds=res.value;
var pkgitem = document.getElementById("drpedition");


if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{
        var pkgitem=document.getElementById('drpedition');
         pkgitem.options[0]=new Option("------Select Edititon------","0");
     
//var pkgitem = document.getElementById("drpcity");
//alert(pkgitem);
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].Edition_Alias,res.value.Tables[0].Rows[i].Edition_Code);
        
       pkgitem.options.length;
       
    }
    
 if(editionvar == undefined || editionvar=="")
 {
 // document.getElementById('drpcity').value=res.value.Tables[0].Rows[0].City_Code;
 document.getElementById('drpedition').value="0";
 }
 else
 {
  document.getElementById('drpedition').value=editionvar;
  editionvar="";
  } 
 /* if((hiddentext=="new")||(hiddentext=="modify"))
  {
  document.getElementById('drpcity').focus();
  return false;
  }*/
  }
 
else
{
alert("There is No Matching value Found");
pkgitem.options.length=1;
return false;

}

return false;
}


function checkadsize()
{
var num=document.getElementById('txtadvsize').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtadvsize').focus();
document.getElementById('txtadvsize').value="";
return false; 
}
}


