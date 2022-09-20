 
 var modi;
 var z;
 
   function docnew()
   {
	modi=0;
	document.getElementById('txtdoccode').disabled=false;
	document.getElementById('txtdocalias').disabled=false;
	document.getElementById('txtdoctyp').disabled=false;
	document.getElementById('txtmultiplier').disabled=false;
	
	chkstatus(FlagStatus);			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	return false;
   }
   
   
 function canceldoc(formname)
		{
			
			document.getElementById('txtdoccode').disabled=true;
			document.getElementById('txtdocalias').disabled=true;
			document.getElementById('txtdoctyp').disabled=true;
			document.getElementById('txtmultiplier').disabled=true;
			
			document.getElementById('txtdoccode').value="";
			document.getElementById('txtdocalias').value="";
			document.getElementById('txtdoctyp').value="";
			document.getElementById('txtmultiplier').value="";
			getPermission('DocumentMaster');
			return false;
		}
		
function docsave()
	{
			if(document.getElementById('txtdoccode').value=="")
			{
			alert("Please Enter Document Code");
			document.getElementById('txtdoccode').focus();
			return false;
			}
			if(document.getElementById('txtdoctyp').value=="")
			{
			alert("Please Enter Document Name");
			document.getElementById('txtdoctyp').focus();
			return false;
			}
			if(document.getElementById('txtdocalias').value=="")
			{
			alert("Please Enter Alias");
			document.getElementById('txtdocalias').focus();
			return false;
			}
			if(document.getElementById('txtmultiplier').value=="")
			{
			alert("Please Enter Multiplier");
			document.getElementById('txtmultiplier').focus();
			return false;
			}
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var doccode=document.getElementById('txtdoccode').value;
			var doctype=document.getElementById('txtdoctyp').value;
			var alias=document.getElementById('txtdocalias').value;
			var multi=document.getElementById('txtmultiplier').value;
		if(modi==0)
		{	
			DocumentMaster.docchk(compcode,userid,doccode,callchk)
			return false;
		}
		else
		{
			DocumentMaster.modify(compcode,userid,doccode,doctype,alias,multi);
			alert("Data Modified");
			updateStatus();
			document.getElementById('txtdoccode').disabled=true;
			document.getElementById('txtdocalias').disabled=true;
			document.getElementById('txtdoctyp').disabled=true;
			document.getElementById('txtmultiplier').disabled=true;
		return false;
		}
			return false;
	}
		

function callchk(res)
	{
		var ds= res.value;
		if(ds.Tables[0].Rows.length==0)
		{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var doccode=document.getElementById('txtdoccode').value;
			var doctype=document.getElementById('txtdoctyp').value;
			var alias=document.getElementById('txtdocalias').value;
			var multi=document.getElementById('txtmultiplier').value;
			
			DocumentMaster.save(compcode,userid,doccode,doctype,alias,multi)
			
			document.getElementById('txtdoccode').disabled=true;
			document.getElementById('txtdocalias').disabled=true;
			document.getElementById('txtdoctyp').disabled=true;
			document.getElementById('txtmultiplier').disabled=true;
			
			document.getElementById('txtdoccode').value="";
			document.getElementById('txtdocalias').value="";
			document.getElementById('txtdoctyp').value="";
			document.getElementById('txtmultiplier').value="";
			alert("Data Saved");
			canceldoc('DocumentMaster');
			return false;
		}
		else
		{
		alert("This Document Code already Exist!!!  Please Try Another Code");
		
		document.getElementById('txtdoccode').disabled=false;
		document.getElementById('txtdocalias').disabled=false;
		document.getElementById('txtdoctyp').disabled=false;
		document.getElementById('txtmultiplier').disabled=false;
		
		return false;
		}
	}
		
		
function docmodify()
		{
			modi= "2";
			//document.getElementById('btnQuery').disabled = true;
				chkstatus(FlagStatus);
				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				
				document.getElementById('txtdoccode').disabled=true;
				document.getElementById('txtdocalias').disabled=false;
				document.getElementById('txtdoctyp').disabled=false;
				document.getElementById('txtmultiplier').disabled=false;
				
		return false;		
		}
		
		
		
function docquery(formname)
		{	
				document.getElementById('txtdoccode').disabled=false;
				document.getElementById('txtdocalias').disabled=false;
				document.getElementById('txtdoctyp').disabled=false;
				document.getElementById('txtmultiplier').disabled=false;
				
				document.getElementById('txtdoccode').value="";
				document.getElementById('txtdocalias').value="";
				document.getElementById('txtdoctyp').value="";
				document.getElementById('txtmultiplier').value="";
				
				chkstatus(FlagStatus);
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=false;
				document.getElementById('btnSave').disabled=true;
				z=0;
				return false;
		}
		
		
function docexe()
		{
		
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var doccode=document.getElementById('txtdoccode').value;
			var doctype=document.getElementById('txtdoctyp').value;
			var alias=document.getElementById('txtdocalias').value;
			var multi=document.getElementById('txtmultiplier').value;
			DocumentMaster.exe(compcode,userid,doccode,doctype,alias,multi,callexe)
			
			updateStatus();
			document.getElementById('txtdoccode').disabled=true;
			document.getElementById('txtdocalias').disabled=true;
			document.getElementById('txtdoctyp').disabled=true;
			document.getElementById('txtmultiplier').disabled=true;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
		return false;
		}
		
function callexe(res)
		{
			var ds=res.value;
				if(ds.Tables[0].Rows.length==0)
				{
					alert("Your Search Can Not Produce Any Result");
					canceldoc('DocumentMaster');
					return false;
				}
				else
				{
					document.getElementById('txtdoccode').value=ds.Tables[0].Rows[0].Doc_Code;
					document.getElementById('txtdoctyp').value=ds.Tables[0].Rows[0].Doc_Type;
					document.getElementById('txtdocalias').value=ds.Tables[0].Rows[0].Doc_Alias;
					document.getElementById('txtmultiplier').value=ds.Tables[0].Rows[0].Multiplier;
					return false;		
				}
			return false;
		}


function docfirst()
{
z=0;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			DocumentMaster.fnpl(compcode,userid,claafirst);
		
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			return false;
}


function claafirst(response)
		{
		//alert("first");

			var	ds=response.value;
					document.getElementById('txtdoccode').value=ds.Tables[0].Rows[0].Doc_Code;
					document.getElementById('txtdoctyp').value=ds.Tables[0].Rows[0].Doc_Type;
					document.getElementById('txtdocalias').value=ds.Tables[0].Rows[0].Doc_Alias;
					document.getElementById('txtmultiplier').value=ds.Tables[0].Rows[0].Multiplier;
					
					updateStatus();

document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;	
					
					return false;
		}

function docpre()
	{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			DocumentMaster.fnpl(compcode,userid,precall);
			return false;
	}

function precall(response)
	{
	//alert("pre");

		z--;
		var ds=response.value;
		var x=ds.Tables[0].Rows.length;
		
			if(z>x)
			{
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
			return false;
			}
		if(z!=-1 && z>=0)
		{
			if(ds.Tables[0].Rows.length != z)
			{
					document.getElementById('txtdoccode').value=ds.Tables[0].Rows[z].Doc_Code;
					document.getElementById('txtdoctyp').value=ds.Tables[0].Rows[z].Doc_Type;
					document.getElementById('txtdocalias').value=ds.Tables[0].Rows[z].Doc_Alias;
					document.getElementById('txtmultiplier').value=ds.Tables[0].Rows[z].Multiplier;
					
					updateStatus();
		
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=false;
			
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
	if (z<=0)
		{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			return false;		
		}
		return false;
}

function docnext()
	{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			DocumentMaster.fnpl(compcode,userid,nextcall)
			return false;
}

function nextcall(response)
{
//alert("next");
z++;
	var ds=response.value;
	var x=ds.Tables[0].Rows.length;
	if(z <= x && z >= 0)
	{
		if(ds.Tables[0].Rows.length != z && z !=-1)
		{
				document.getElementById('txtdoccode').value=ds.Tables[0].Rows[z].Doc_Code;
				document.getElementById('txtdoctyp').value=ds.Tables[0].Rows[z].Doc_Type;
				document.getElementById('txtdocalias').value=ds.Tables[0].Rows[z].Doc_Alias;
				document.getElementById('txtmultiplier').value=ds.Tables[0].Rows[z].Multiplier;
				
				updateStatus();
	
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
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
		return false;
}

function doclast()
		{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
		
			DocumentMaster.fnpl(compcode,userid,lastcall)
			return false;
		}


function lastcall(response)
	{
			var ds= response.value;
			var x=ds.Tables[0].Rows.length;
			z=x-1;
			x=x-1;
					document.getElementById('txtdoccode').value=ds.Tables[0].Rows[x].Doc_Code;
					document.getElementById('txtdoctyp').value=ds.Tables[0].Rows[x].Doc_Type;
					document.getElementById('txtdocalias').value=ds.Tables[0].Rows[x].Doc_Alias;
					document.getElementById('txtmultiplier').value=ds.Tables[0].Rows[x].Multiplier;
					
					updateStatus();
		
			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;
	}
	
function deletedoc()
	{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var doccode=document.getElementById('txtdoccode').value;
		boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	DocumentMaster.del(compcode,userid,doccode,delcall);
	}     
	else
	{
	return false;
	}	
	return false;
	}
	
	function delcall(res)
	{
	var ds= res.value;
	len=ds.Tables[0].Rows.length;
	
	if(ds.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
		document.getElementById('txtdoccode').value="";
		document.getElementById('txtdocalias').value="";
		document.getElementById('txtdoctyp').value="";
		document.getElementById('txtmultiplier').value="";
		canceldoc('DocumentMaster');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
		document.getElementById('txtdoccode').value=ds.Tables[0].Rows[0].Doc_Code;
		document.getElementById('txtdoctyp').value=ds.Tables[0].Rows[0].Doc_Type;
		document.getElementById('txtdocalias').value=ds.Tables[0].Rows[0].Doc_Alias;
		document.getElementById('txtmultiplier').value=ds.Tables[0].Rows[0].Multiplier;
	}
	
	else
	{
		document.getElementById('txtdoccode').value=ds.Tables[0].Rows[z].Doc_Code;
		document.getElementById('txtdoctyp').value=ds.Tables[0].Rows[z].Doc_Type;
		document.getElementById('txtdocalias').value=ds.Tables[0].Rows[z].Doc_Alias;
		document.getElementById('txtmultiplier').value=ds.Tables[0].Rows[z].Multiplier;
	}
	alert ("Data Deleted");	
				
	
	return false;
	}
	
	
function docexit()
{
if(confirm("Do You Want To Skip This Page"))
	{
	window.location.href='EnterPage.aspx';
	return false;
	}
	
	return false;
}
	