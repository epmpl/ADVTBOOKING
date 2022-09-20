//this for save and update
var modify="0";
//this flag is for permission
var flag="";
var z="0";

function newclick()
{
document.getElementById('txtproductcode').value="";
document.getElementById('txtprodsubcode').value="";
document.getElementById('txtprodname').value="";

document.getElementById('txtproductcode').disabled=false;
document.getElementById('txtprodsubcode').disabled=false;
document.getElementById('txtprodname').disabled=false;
document.getElementById('drpclientname').disabled=false;
document.getElementById('txtproductcode').focus();
chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
flag=0;
setButtonImages();
return false;


}

function modifyclick()
{
document.getElementById('txtproductcode').disabled=true;
document.getElementById('txtprodsubcode').disabled=false;
document.getElementById('txtprodname').disabled=false;
document.getElementById('drpclientname').disabled=false;



modify="1";
chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;
document.getElementById('btnQuery').disabled = true;
flag=1;
setButtonImages();
return false;
}

function queryclick()
{
document.getElementById('txtproductcode').value="";
document.getElementById('txtprodsubcode').value="";
document.getElementById('txtprodname').value="";
document.getElementById('drpclientname').value="0";

document.getElementById('txtproductcode').disabled=false;
document.getElementById('txtprodsubcode').disabled=false;
document.getElementById('txtprodname').disabled=false;
document.getElementById('drpclientname').disabled=false;


z=0;

modify="0";
chkstatus(FlagStatus);

document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	setButtonImages();
return false;
}

function executeclick()
{
var txtproductcode=document.getElementById('txtproductcode').value;
var txtprodsubcode=document.getElementById('txtprodsubcode').value;
var txtprodname=document.getElementById('txtprodname').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var clientname=document.getElementById('drpclientname').value;
ProductMaster.execute(txtproductcode,txtprodsubcode,txtprodname,clientname,compcode,userid,call_execute);
updateStatus();
return false;
}




function cancelclick(formname)
{
document.getElementById('txtproductcode').value="";
document.getElementById('txtprodsubcode').value="";
document.getElementById('txtprodname').value="";
document.getElementById('drpclientname').value="0";

document.getElementById('txtproductcode').disabled=true;
document.getElementById('txtprodsubcode').disabled=true;
document.getElementById('txtprodname').disabled=true;
document.getElementById('drpclientname').disabled=true;

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
givebuttonpermission(formname);
setButtonImages();
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
function trim( value ) 
{
	
	return LTrim(RTrim(value));
	
}
function saveclick()
{
document.getElementById('txtproductcode').value=trim(document.getElementById('txtproductcode').value);
document.getElementById('txtprodsubcode').value=trim(document.getElementById('txtprodsubcode').value);
document.getElementById('txtprodname').value=trim(document.getElementById('txtprodname').value);
if(document.getElementById('txtproductcode').value=="")
{
alert("Please Enter The Product Code");
document.getElementById('txtproductcode').focus();
return false;
}
else if(document.getElementById('txtprodsubcode').value=="")
{
alert("Please Enter The Product Sub Code");
document.getElementById('txtprodsubcode').focus();
return false;
}
else if(document.getElementById('drpclientname').value=="0")
{
alert("Please Enter The Client Name");
document.getElementById('drpclientname').focus();
return false;
}
else if(document.getElementById('txtprodname').value=="")
{
alert("Please Enter The Product Name");
document.getElementById('txtprodname').focus();

return false;
}


var txtproductcode=document.getElementById('txtproductcode').value;
var txtprodsubcode=document.getElementById('txtprodsubcode').value;
var txtprodname=document.getElementById('txtprodname').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var clientname=document.getElementById('drpclientname').value;

if(modify !="1" && modify!=null)
{

ProductMaster.chkcode(txtproductcode,txtprodsubcode,compcode,userid,call_save);
}
else
{
ProductMaster.update(txtproductcode,txtprodsubcode,txtprodname,clientname,compcode,userid);


alert("Data updated  Successfully");
document.getElementById('txtproductcode').disabled=true;
document.getElementById('txtprodsubcode').disabled=true;
document.getElementById('txtprodname').disabled=true;
document.getElementById('drpclientname').disabled=true;

flag=0;
updateStatus();
}

setButtonImages();
return false;
}

function call_save(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
{
alert("This Product Code Is Assigned ");
return false;
}
else
{
var txtproductcode=document.getElementById('txtproductcode').value;
var txtprodsubcode=document.getElementById('txtprodsubcode').value;
var txtprodname=document.getElementById('txtprodname').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var clientname=document.getElementById('drpclientname').value;

ProductMaster.save(txtproductcode,txtprodsubcode,txtprodname,clientname,compcode,userid);

document.getElementById('txtproductcode').value="";
document.getElementById('txtprodsubcode').value="";
document.getElementById('txtprodname').value="";
document.getElementById('drpclientname').value="0";

document.getElementById('txtproductcode').disabled=true;
document.getElementById('txtprodsubcode').disabled=true;
document.getElementById('txtprodname').disabled=true;
document.getElementById('drpclientname').disabled=true;

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

alert("Data Saved sucessfully");

}
cancelclick('ProductMaster');
return false;
}

function call_execute(response)
{

var ds=response.value;
if(ds.Tables[0].Rows.length <=0)
	{
	cancelclick('ProductMaster');
	alert("Your Searching Criteria Doesn't Produce Any Result!!!");
	return false;
	}
	else
	{
	var txtproductcode=document.getElementById('txtproductcode').value=ds.Tables[0].Rows[0].Product_Code;
    var txtprodsubcode=document.getElementById('txtprodsubcode').value=ds.Tables[0].Rows[0].Product_Sub_Code;
    var txtprodname=document.getElementById('txtprodname').value=ds.Tables[0].Rows[0].Product_Name;
    document.getElementById('drpclientname').value=ds.Tables[0].Rows[0].Client_Name;

document.getElementById('txtproductcode').disabled=true;
document.getElementById('txtprodsubcode').disabled=true;
document.getElementById('txtprodname').disabled=true;
document.getElementById('drpclientname').disabled=true;
//*******************Pankaj
            document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			//document.getElementById('btnExecute').disabled=true;
	
	//**************************************
	
	}
	setButtonImages();
return false;
}

function firstclick()
{
ProductMaster.first(call_first);
return false;
}

function call_first(response)
{
z=0;
var ds=response.value;
var txtproductcode=document.getElementById('txtproductcode').value=ds.Tables[0].Rows[0].Product_Code;
var txtprodsubcode=document.getElementById('txtprodsubcode').value=ds.Tables[0].Rows[0].Product_Sub_Code;
var txtprodname=document.getElementById('txtprodname').value=ds.Tables[0].Rows[0].Product_Name;
document.getElementById('drpclientname').value=ds.Tables[0].Rows[0].Client_Name;

updateStatus();

document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;	
	setButtonImages();
return false;
}

function lastclick()
{
ProductMaster.first(call_last);
return false;
}

function call_last(response)
{
var ds=response.value;
var ds=response.value;
var y=ds.Tables[0].Rows.length;
var a=y-1;
z=a;
var txtproductcode=document.getElementById('txtproductcode').value=ds.Tables[0].Rows[z].Product_Code;
var txtprodsubcode=document.getElementById('txtprodsubcode').value=ds.Tables[0].Rows[z].Product_Sub_Code;
var txtprodname=document.getElementById('txtprodname').value=ds.Tables[0].Rows[z].Product_Name;
document.getElementById('drpclientname').value=ds.Tables[0].Rows[z].Client_Name;

updateStatus();
document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;
setButtonImages();
return false;
}

function previousclick()
{
ProductMaster.first(call_previous);
return false;
}

function call_previous(response)
{
var ds=response.value;
var a=ds.Tables[0].Rows.length;

z--;
if(z != -1  )
		{
			if(z >= 0 && z < a)
			{
			var txtproductcode=document.getElementById('txtproductcode').value=ds.Tables[0].Rows[z].Product_Code;
var txtprodsubcode=document.getElementById('txtprodsubcode').value=ds.Tables[0].Rows[z].Product_Sub_Code;
var txtprodname=document.getElementById('txtprodname').value=ds.Tables[0].Rows[z].Product_Name;
document.getElementById('drpclientname').value=ds.Tables[0].Rows[z].Client_Name;

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
function nextclick()
{
ProductMaster.first(call_next);
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
		var txtproductcode=document.getElementById('txtproductcode').value=ds.Tables[0].Rows[z].Product_Code;
var txtprodsubcode=document.getElementById('txtprodsubcode').value=ds.Tables[0].Rows[z].Product_Sub_Code;
var txtprodname=document.getElementById('txtprodname').value=ds.Tables[0].Rows[z].Product_Name;
document.getElementById('drpclientname').value=ds.Tables[0].Rows[z].Client_Name;

updateStatus();
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
{
var txtproductcode=document.getElementById('txtproductcode').value;
var txtprodsubcode=document.getElementById('txtprodsubcode').value;
var txtprodname=document.getElementById('txtprodname').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

if(confirm("Are You Sure To Delete The Date"))
	{
ProductMaster.deletevalue(txtproductcode,compcode,userid);
alert("Value Deleted");
ProductMaster.first(call_delete);

	}
return false;
}

function call_delete(response)
{
var ds=response.value;
var ds=response.value;
	var a=ds.Tables[0].Rows.length;
	var y=a-1;
	
	if( y <=0 )
	{
	alert("There Is No Data In The Database");
	var txtproductcode=document.getElementById('txtproductcode').value="";
var txtprodsubcode=document.getElementById('txtprodsubcode').value="";
var txtprodname=document.getElementById('txtprodname').value="";
document.getElementById('drpclientname').value="0";
cancelclick('ProductMaster');
	}
	
	else if(z==-1 ||z>=a)
	{
	
var txtproductcode=document.getElementById('txtproductcode').value=ds.Tables[0].Rows[0].Product_Code;
var txtprodsubcode=document.getElementById('txtprodsubcode').value=ds.Tables[0].Rows[0].Product_Sub_Code;
var txtprodname=document.getElementById('txtprodname').value=ds.Tables[0].Rows[0].Product_Name;
document.getElementById('drpclientname').value=ds.Tables[0].Rows[0].Client_Name;	;
return false;
	}
	
	else
	{
	
var txtproductcode=document.getElementById('txtproductcode').value=ds.Tables[0].Rows[z].Product_Code;
var txtprodsubcode=document.getElementById('txtprodsubcode').value=ds.Tables[0].Rows[z].Product_Sub_Code;
var txtprodname=document.getElementById('txtprodname').value=ds.Tables[0].Rows[z].Product_Name;	
document.getElementById('drpclientname').value=ds.Tables[0].Rows[z].Client_Name;	;
return false;
	}
	
setButtonImages();	
return false;
}

//function exitclick()
//{
//if(confirm("Do You Want To Skip This Page"))
//{
//window.location.href="EnterPage.aspx";
//}
//return false;
//}

function exitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
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

function clearproductmaster() {
    givebuttonpermission('ProductMaster');
    cancelclick('ProductMaster');
}

function keycalling(event)
{
var key = event.keyCode ? event.keyCode : event.which;
if(key==13 || key==9)
{
if(document.activeElement.id=="txtproductcode")
{
document.getElementById("txtprodsubcode").focus();
return false;

}
if(document.activeElement.id=="txtprodsubcode")
{
document.getElementById("drpclientname").focus();
return false;

}
if(document.activeElement.id=="drpclientname")
{
document.getElementById("txtprodname").focus();
return false;

}
if(document.activeElement.id=="txtprodname")
{
document.getElementById("btnSave").focus();
return false;

}

}
}