var modify="0";
var z="0";
var flag="";


function clinew()
{
			document.getElementById('txtcode').value="";
			document.getElementById('txtnameofrole').value="";
			document.getElementById('drpagencycode').value="0";
			modify="0";
			z="0";
			document.getElementById('txtcode').disabled=false;
			document.getElementById('txtnameofrole').disabled=false;
			document.getElementById('drpagencycode').disabled=false;
			chkstatus(FlagStatus);
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
			flag=0;
return false;
}

function climodify()
{
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=false;
			document.getElementById('drpagencycode').disabled=false;
			modify="1";
			modify="1";
			chkstatus(FlagStatus);
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;
			flag=1;
return false;
}

function cliquery()
{
			document.getElementById('txtcode').value="";
			document.getElementById('txtnameofrole').value="";
			document.getElementById('drpagencycode').value="0";
			document.getElementById('txtcode').disabled=false;
			document.getElementById('txtnameofrole').disabled=false;
			document.getElementById('drpagencycode').disabled=false;
			z=0;
			modify="0";
			chkstatus(FlagStatus);

			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;

return false;
}

function clicancel(formname)
{
			document.getElementById('txtcode').value="";
			document.getElementById('txtnameofrole').value="";
			document.getElementById('drpagencycode').value="0";
			modify="0";
			z="0";
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
			document.getElementById('drpagencycode').disabled=true;
			document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnDelete').disabled=true;

				modify="0";
				getPermission(formname);
				return false;
return false;
}

function clisave()
{

			var code=document.getElementById('txtcode').value;
			var nameofrole=document.getElementById('txtnameofrole').value;
			var clientcode=document.getElementById('drpagencycode').value;
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;

if(modify!="1" && modify!="")
{
Clientrolemaster.chkcode(code,compcode,userid,call_save);

return false;
}
else
{
Clientrolemaster.modify(code,nameofrole,clientcode,compcode,userid);

			alert("Data updated");
			modify="0";
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
			document.getElementById('drpagencycode').disabled=true;
			modify="0";
			flag=0;
			updateStatus();

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
			var code=document.getElementById('txtcode').value;
			var nameofrole=document.getElementById('txtnameofrole').value;
			var clientcode=document.getElementById('drpagencycode').value;
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			Clientrolemaster.insert(code,nameofrole,clientcode,compcode,userid);
			alert("Value Inserted ");
			
			document.getElementById('txtcode').value="";
			document.getElementById('txtnameofrole').value="";
			document.getElementById('drpagencycode').value="0";
			
			
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
			document.getElementById('drpagencycode').disabled=true;

			
			}
			

clicancel('Clientrolemaster');
return false;
}

function cliexecute()
{
			var code=document.getElementById('txtcode').value;
			var nameofrole=document.getElementById('txtnameofrole').value;
			var clientcode=document.getElementById('drpagencycode').value;
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			Clientrolemaster.execute(code,nameofrole,clientcode,compcode,userid,call_execute);
			
			document.getElementById('txtcode').disabled=true;
			document.getElementById('txtnameofrole').disabled=true;
			document.getElementById('drpagencycode').disabled=true;
			updateStatus();
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
			

return false;
}

function call_execute(response)
{
var ds=response.value;

if(ds.Tables[0].Rows.length <= 0)
			{
			alert("Search Not Match");
			clicancel('Clientrolemaster');
			return false;
			}
			else
			{
			var code=document.getElementById('txtcode').value=ds.Tables[0].Rows[0].Client_Name_Code;
			var nameofrole=document.getElementById('txtnameofrole').value=ds.Tables[0].Rows[0].Client_role;
			var agencycode=document.getElementById('drpagencycode').value=ds.Tables[0].Rows[0].Client_code;;
			
			
			}


return false;
}

function btnfirst()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			Clientrolemaster.first(compcode,userid,call_first);
			z="0";


return false;
}
function call_first(response)
{
			var ds=response.value;
			document.getElementById('txtcode').value=ds.Tables[0].Rows[0].Client_Name_Code;
			document.getElementById('txtnameofrole').value=ds.Tables[0].Rows[0].Client_role;
			document.getElementById('drpagencycode').value=ds.Tables[0].Rows[0].Client_code;;
			updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;



return false;
}

function cliprevious()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			Clientrolemaster.first(compcode,userid,call_pre);

return false;
}
function call_pre(response)
{
var ds=response.value;
var ds=response.value;
		var a=ds.Tables[0].Rows.length;

		z--;
		if(z != -1  )
		{
		if(z >= 0 && z < a)
		{
			document.getElementById('txtcode').value=ds.Tables[0].Rows[z].Client_Name_Code;
			document.getElementById('txtnameofrole').value=ds.Tables[0].Rows[z].Client_role;
			document.getElementById('drpagencycode').value=ds.Tables[0].Rows[z].Client_code;;
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

return false;
}

function clinext()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			Clientrolemaster.first(compcode,userid,call_next);

return false;
}
function call_next(response)
{
var ds=response.value;

var ds=response.value;
		var a=ds.Tables[0].Rows.length;

		z++;
		if(z !=-1 && z >= 0)
		{
		if(z <= a-1)
		{
			document.getElementById('txtcode').value=ds.Tables[0].Rows[z].Client_Name_Code;
			document.getElementById('txtnameofrole').value=ds.Tables[0].Rows[z].Client_role;
			document.getElementById('drpagencycode').value=ds.Tables[0].Rows[z].Client_code;;
			updateStatus();
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


return false;
}

function clilast()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			Clientrolemaster.first(compcode,userid,call_last);



return false;
}
function call_last(response)
{
var ds=response.value;
var ds=response.value;
		var y=ds.Tables[0].Rows.length;
		var a=y-1;
		z=a;
		
			document.getElementById('txtcode').value=ds.Tables[0].Rows[a].Client_Name_Code;
			document.getElementById('txtnameofrole').value=ds.Tables[0].Rows[a].Client_role;
			document.getElementById('drpagencycode').value=ds.Tables[0].Rows[a].Client_code;;
			updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;

return false;
}

function clidelete()
{
			var code=document.getElementById('txtcode').value;
			var nameofrole=document.getElementById('txtnameofrole').value;
			var clientcode=document.getElementById('drpagencycode').value;
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			if(confirm("Are You Sure To Delete The Data"))
			{
			Clientrolemaster.deleterole(code,compcode,userid);
			alert("value deleted sucessfully");
			Clientrolemaster.first(compcode,userid,call_delete);
			
			
			}	

return false;
}

function call_delete(response)
{
var ds=response.value;
var a=ds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
			alert("There Is No Data In The Database");
			document.getElementById('txtcode').value="";
			document.getElementById('txtnameofrole').value="";
			document.getElementById('drpagencycode').value="0";
			clicancel('Clientrolemaster');
	}
	else if(z==-1 ||z>=a )
	{
			document.getElementById('txtcode').value=ds.Tables[0].Rows[0].Client_Name_Code;
			document.getElementById('txtnameofrole').value=ds.Tables[0].Rows[0].Client_role;
			document.getElementById('drpagencycode').value=ds.Tables[0].Rows[0].Client_code;;
	}
	else
	{
			document.getElementById('txtcode').value=ds.Tables[0].Rows[z].Client_Name_Code;
			document.getElementById('txtnameofrole').value=ds.Tables[0].Rows[z].Client_role;
			document.getElementById('drpagencycode').value=ds.Tables[0].Rows[z].Client_code;;
	}

return false;
}
function cliexit()
{
if(confirm("Do You Want To Skip This Page"))
		{
		//window.location.href='enterpage.aspx';
		window.close();
		return false;
		}
		return false;

return false;
}



