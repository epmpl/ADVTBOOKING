//this for save and update
var modify="0";
//this flag is for permission
var flag="";
var z=0;

function newclick()
{
document.getElementById('txtadvcode').value="";
document.getElementById('txtadvname').value="";
document.getElementById('txtalias').value="";

document.getElementById('txtadvcode').disabled=false;
document.getElementById('txtadvname').disabled=false;
document.getElementById('txtalias').disabled=false;


chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
flag=0;

return false;
}
function modifyclick()
{
document.getElementById('txtadvcode').disabled=true;
document.getElementById('txtadvname').disabled=false;
document.getElementById('txtalias').disabled=false;



modify="1";
chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;
flag=1;
return false;
}

function queryclick()
{
document.getElementById('txtadvcode').value="";
document.getElementById('txtadvname').value="";
document.getElementById('txtalias').value="";

document.getElementById('txtadvcode').disabled=false;
document.getElementById('txtadvname').disabled=false;
document.getElementById('txtalias').disabled=false;




modify="0";
chkstatus(FlagStatus);

document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
return false;
}

function executeclick()
{
var txtadvcode=document.getElementById('txtadvcode').value;
var txtadvname=document.getElementById('txtadvname').value;
var txtalias=document.getElementById('txtalias').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

AdvStatusMaster.execute(txtadvcode,txtadvname,txtalias,compcode,userid,call_execute);
updateStatus();
return false;
}

function call_execute(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length <= 0)
{
alert("Your Search Doesn't Produce Any Result!!!");

cancelclick('AdvStatusMaster');
return false;
}
else
{
var txtadvcode=document.getElementById('txtadvcode').value=ds.Tables[0].Rows[0].Adv_Status_Code;
var txtadvname=document.getElementById('txtadvname').value=ds.Tables[0].Rows[0].Adv_Status_Name;
var txtalias=document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Status_Alias;

var userid=document.getElementById('hiddenuserid').value;

document.getElementById('txtadvcode').disabled=true;
document.getElementById('txtadvname').disabled=true;
document.getElementById('txtalias').disabled=true;




}
return false;
}

function cancelclick(formname)
{
document.getElementById('txtadvcode').value="";
document.getElementById('txtadvname').value="";
document.getElementById('txtalias').value="";

document.getElementById('txtadvcode').disabled=true;
document.getElementById('txtadvname').disabled=true;
document.getElementById('txtalias').disabled=true;

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
}

function exitclick()
{
if(confirm("Do You Want To Skip This Page"))
{
window.location.href='enterpage.aspx';
return false;
}
return  false;
}

function saveclick()
{

if(document.getElementById('txtadvcode').value=="")
{
alert("Please Enter The Adv Status Code");
document.getElementById('txtadvcode').focus();
return false;
}
else if(document.getElementById('txtadvname').value=="")
{
alert("Please Enter The Adv Status Name");
document.getElementById('txtadvname').focus();
return false;
}
else if(document.getElementById('txtalias').value=="")
{
alert("Please Enter The Alias Name");
document.getElementById('txtalias').focus();
return false
}

var txtadvcode=document.getElementById('txtadvcode').value;
var txtadvname=document.getElementById('txtadvname').value;
var txtalias=document.getElementById('txtalias').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if(modify!="1" && modify!=null)
{
AdvStatusMaster.checkadv(txtadvcode,compcode,userid,call_save);
}
else
{
AdvStatusMaster.update(txtadvcode,txtadvname,txtalias,compcode,userid);
alert("Value is Updated");

document.getElementById('txtadvcode').disabled=true;
document.getElementById('txtadvname').disabled=true;
document.getElementById('txtalias').disabled=true;




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
alert("This Code Has Benn Assigned");
return false;
}
else
{
var txtadvcode=document.getElementById('txtadvcode').value;
var txtadvname=document.getElementById('txtadvname').value;
var txtalias=document.getElementById('txtalias').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

AdvStatusMaster.insert(txtadvcode,txtadvname,txtalias,compcode,userid);

document.getElementById('txtadvcode').value="";
document.getElementById('txtadvname').value="";
document.getElementById('txtalias').value="";

document.getElementById('txtadvcode').disabled=true;
document.getElementById('txtadvname').disabled=true;
document.getElementById('txtalias').disabled=true;

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
cancelclick('AdvStatusMaster');
return false;
}

function firstclick()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
AdvStatusMaster.first(compcode,userid,call_first);

			
return false;
}
function call_first(response)
{
var ds=response.value;
z=0;
var txtadvcode=document.getElementById('txtadvcode').value=ds.Tables[0].Rows[0].Adv_Status_Code;
var txtadvname=document.getElementById('txtadvname').value=ds.Tables[0].Rows[0].Adv_Status_Name;
var txtalias=document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Status_Alias;

updateStatus();

document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;	
return false;
}
function lastclick()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
AdvStatusMaster.first(compcode,userid,call_last);

return false;
}
function call_last(response)
{
var ds=response.value;
var y=ds.Tables[0].Rows.length;
var a=y-1;
//z=ds.Tables[0].Rows.length;
z=a;

var txtadvcode=document.getElementById('txtadvcode').value=ds.Tables[0].Rows[a].Adv_Status_Code;
var txtadvname=document.getElementById('txtadvname').value=ds.Tables[0].Rows[a].Adv_Status_Name;
var txtalias=document.getElementById('txtalias').value=ds.Tables[0].Rows[a].Adv_Status_Alias;
updateStatus();
document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;

return false;
}
function previousclick()
{
 var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
AdvStatusMaster.first(compcode,userid,call_previous);
return false;
}

function call_previous(response)
{
var ds=response.value;
var a=ds.Tables[0].Rows.length;

z--;
if(z != -1  )
		{
			if(z >= 0)
			{
			var txtadvcode=document.getElementById('txtadvcode').value=ds.Tables[0].Rows[z].Adv_Status_Code;
var txtadvname=document.getElementById('txtadvname').value=ds.Tables[0].Rows[z].Adv_Status_Name;
var txtalias=document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Adv_Status_Alias;

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


return false;
}

function nextclick()
{
  var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
AdvStatusMaster.first(compcode,userid,call_next);
return false;
}

function call_next(response)
{
var ds=response.value;
var a=ds.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		var txtadvcode=document.getElementById('txtadvcode').value=ds.Tables[0].Rows[z].Adv_Status_Code;
var txtadvname=document.getElementById('txtadvname').value=ds.Tables[0].Rows[z].Adv_Status_Name;
var txtalias=document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Adv_Status_Alias;
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

function deleteclick()
{
var txtadvcode=document.getElementById('txtadvcode').value;
var txtadvname=document.getElementById('txtadvname').value;
var txtalias=document.getElementById('txtalias').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if(confirm("Are You Sure To Delete The Data"))
{
AdvStatusMaster.deleteit(txtadvcode,compcode,userid);
alert("Value Deleted");
AdvStatusMaster.first(compcode,userid,call_delete);
return false;
}

return false;

}
function call_delete(response)
{
var ds=response.value;
	var a=ds.Tables[0].Rows.length;
	

	
	if(a>= z && z != -1 )
	{
	var f=z++;
	var txtadvcode=document.getElementById('txtadvcode').value=ds.Tables[0].Rows[f].Adv_Status_Code;
var txtadvname=document.getElementById('txtadvname').value=ds.Tables[0].Rows[f].Adv_Status_Name;
var txtalias=document.getElementById('txtalias').value=ds.Tables[0].Rows[f].Adv_Status_Alias;
return false;
	}
	//if( a > 0 && (z==a || z!=0))
	if(z!=0)
	{
	if(a>0)
	{
	if(z>=a)
	{
	
	     var t=z--;
	      if(t<0)
	       {
	  
           var txtadvcode=document.getElementById('txtadvcode').value=ds.Tables[0].Rows[0].Adv_Status_Code;
           var txtadvname=document.getElementById('txtadvname').value=ds.Tables[0].Rows[0].Adv_Status_Name;
           var txtalias=document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Status_Alias;  
           return false;
          }
        else
         {
	      var txtadvcode=document.getElementById('txtadvcode').value=ds.Tables[0].Rows[t].Adv_Status_Code; 
          var txtadvname=document.getElementById('txtadvname').value=ds.Tables[0].Rows[t].Adv_Status_Name;
          var txtalias=document.getElementById('txtalias').value=ds.Tables[0].Rows[t].Adv_Status_Alias;
          return false;
	     }
	return false;
	}
	return false;
	}
	return false;
	}
if( a <=0 )
	{
	alert("There Is No Data In The Database");
	
document.getElementById('txtadvcode').value="";
document.getElementById('txtadvname').value="";
document.getElementById('txtalias').value="";
cancelclick('AdvStatusMaster');
	return false;
	}
return false;
}
