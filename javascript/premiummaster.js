//this is for to update
var modify="0";
//this is for f,p,n,l]
var z="0";
///
//this flag is for permission
var flag="";
////////////

//package name bind through Ajax
function fillpackagename()
{
var drpcombin=document.getElementById('drpcombination').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

premium_master.bindpackage(drpcombin,compcode,userid,call_pac);
return false;

}
function call_pac(response)
{
var ds=response.value;
var i;
var packagename=document.getElementById('drppackagename');
packagename.options.length=0
for(i=0;i<= ds.Tables[0].Rows.length-1;i++)
	{
	packagename.options[packagename.options.length]=new Option(ds.Tables[0].Rows[i].package_name,ds.Tables[0].Rows[i].package_name)
	//packagename.option[i].value.selected;
	
	}

return false;

}
////////////////////////////////////////////////////////////

function newclick()
{
document.getElementById('drpcombination').value="0";
document.getElementById('drpadvtype').value="0";
document.getElementById('drpcategory').value="0";
document.getElementById('txtpremiumcode').value="";
document.getElementById('drpprerate').value="0";
document.getElementById('txtrate').value="";
document.getElementById('drppremiumtype').value="0";
document.getElementById('drprategroup').value="0";
document.getElementById('txtvalidfrom').value="";
document.getElementById('txtvalidtil').value="";
document.getElementById('txtremarks').value="";
document.getElementById('drppackagename').value="0";

var packagename=document.getElementById('drppackagename');
packagename.options.length=0

	packagename.options[packagename.options.length]=new Option("","")


document.getElementById('drpcombination').disabled=false;
document.getElementById('drpadvtype').disabled=false;
document.getElementById('drpcategory').disabled=false;
document.getElementById('txtpremiumcode').disabled=false;
document.getElementById('drpprerate').disabled=false;
document.getElementById('txtrate').disabled=false;
document.getElementById('drppremiumtype').disabled=false;
document.getElementById('drprategroup').disabled=false;
document.getElementById('txtvalidfrom').disabled=false;
document.getElementById('txtvalidtil').disabled=false;
document.getElementById('txtremarks').disabled=false;
document.getElementById('drppackagename').disabled=false;

chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
flag=0;

return false;

}

function modifyclick()
{
document.getElementById('drpcombination').disabled=false;
document.getElementById('drpadvtype').disabled=false;
document.getElementById('drpcategory').disabled=false;
document.getElementById('txtpremiumcode').disabled=true;
document.getElementById('drpprerate').disabled=false;
document.getElementById('txtrate').disabled=false;
document.getElementById('drppremiumtype').disabled=false;
document.getElementById('drprategroup').disabled=false;
document.getElementById('txtvalidfrom').disabled=false;
document.getElementById('txtvalidtil').disabled=false;
document.getElementById('txtremarks').disabled=false;

modify="1";

chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;
document.getElementById('btnQuery').disabled = true;
flag=1;		
modify="1";

return false;
}

function queryclick()
{
z=0;
document.getElementById('drpcombination').value="0";
document.getElementById('drpadvtype').value="0";
document.getElementById('drpcategory').value="0";
document.getElementById('txtpremiumcode').value="";
document.getElementById('drpprerate').value="0";
document.getElementById('txtrate').value="";
document.getElementById('drppremiumtype').value="0";
document.getElementById('drprategroup').value="0";
document.getElementById('txtvalidfrom').value="";
document.getElementById('txtvalidtil').value="";
document.getElementById('txtremarks').value="";
document.getElementById('drppackagename').value="0";

var packagename=document.getElementById('drppackagename');
packagename.options.length=0

	packagename.options[packagename.options.length]=new Option("","")

document.getElementById('drpcombination').disabled=true;
document.getElementById('drpadvtype').disabled=false;
document.getElementById('drpcategory').disabled=false;
document.getElementById('txtpremiumcode').disabled=false;
document.getElementById('drpprerate').disabled=false;
document.getElementById('txtrate').disabled=true;
document.getElementById('drppremiumtype').disabled=true;
document.getElementById('drprategroup').disabled=true;
document.getElementById('txtvalidfrom').disabled=false;
document.getElementById('txtvalidtil').disabled=true;
document.getElementById('txtremarks').disabled=true;
document.getElementById('drppackagename').disabled=true;


chkstatus(FlagStatus);

document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
			
modify="0";

return false;

}

function cancelclick(formname)
{

document.getElementById('drpcombination').value="0";
document.getElementById('drpadvtype').value="0";
document.getElementById('drpcategory').value="0";
document.getElementById('txtpremiumcode').value="";
document.getElementById('drpprerate').value="0";
document.getElementById('txtrate').value="";
document.getElementById('drppremiumtype').value="0";
document.getElementById('drprategroup').value="0";
document.getElementById('txtvalidfrom').value="";
document.getElementById('txtvalidtil').value="";
document.getElementById('txtremarks').value="";
document.getElementById('drppackagename').value="";



var packagename=document.getElementById('drppackagename');
packagename.options.length=0

	packagename.options[packagename.options.length]=new Option("","")
	//packagename.option[i].value.selected;
	
	


document.getElementById('drpcombination').disabled=true;
document.getElementById('drpadvtype').disabled=true;
document.getElementById('drpcategory').disabled=true;
document.getElementById('txtpremiumcode').disabled=true;
document.getElementById('drpprerate').disabled=true;
document.getElementById('txtrate').disabled=true;
document.getElementById('drppremiumtype').disabled=true;
document.getElementById('drprategroup').disabled=true;
document.getElementById('txtvalidfrom').disabled=true;
document.getElementById('txtvalidtil').disabled=true;
document.getElementById('txtremarks').disabled=true;
document.getElementById('drppackagename').disabled=true;
z=0;


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
return false;
}

function saveclick()
{

var fromdate=document.getElementById('txtvalidfrom').value;
		var todate=document.getElementById('txtvalidtil').value;
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);

if(document.getElementById('drpadvtype').value=="0")
{
alert("Please Fill The Adv Type");
document.getElementById('drpadvtype').focus();
return false;
}
else if(document.getElementById('drpcategory').value=="0")
{
alert("Please Fill The Category Code");
document.getElementById('drpcategory').focus();
return false;
}
else if(document.getElementById('txtpremiumcode').value=="")
{
alert("Please Fill The Premiuim Code");
document.getElementById('txtpremiumcode').focus();
return false;
}
else if(document.getElementById('drpprerate').value=="0")
{
alert("Please Fill The Premiuim Rate");
document.getElementById('drpprerate').focus();
return false;
}
else if(document.getElementById('txtvalidfrom').value=="")
{
alert("Please Fill The From Date");
document.getElementById('txtvalidfrom').focus();
return false;
}
else if(document.getElementById('txtvalidtil').value!="")
{
if(fdate > tdate )
	{
	alert("Till Date Should be Greater Then From Date");
	document.getElementById('txtvalidtil').focus();
	return false;
	}
}



var drpcombin=document.getElementById('drpcombination').value;
var drpadvtype=document.getElementById('drpadvtype').value;
var drpcategory=document.getElementById('drpcategory').value;
var txtpremiumcode=document.getElementById('txtpremiumcode').value;
var drpprerate=document.getElementById('drpprerate').value;
var txtrate=document.getElementById('txtrate').value;
var drppremiumtype=document.getElementById('drppremiumtype').value;
var drprategroup=document.getElementById('drprategroup').value;
//var txtvalidfrom=document.getElementById('txtvalidfrom').value;
//var txtvalidtil=document.getElementById('txtvalidtil').value;
var txtremarks=document.getElementById('txtremarks').value;
var dateformat=document.getElementById('hiddendateformat').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var drppackagename=document.getElementById('drppackagename').value;

//this is for from date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidfrom').value != "")
{
var txt=document.getElementById('txtvalidfrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidfrom').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidfrom').value!="")
{
var txt=document.getElementById('txtvalidfrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidfrom').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatedate=document.getElementById('txtvalidfrom').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatedate=document.getElementById('txtvalidfrom').value;
}

///////////////////////////////////
// this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidtil').value != "")
{
var txt=document.getElementById('txtvalidtil').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatetill=mm+'/'+dd+'/'+yy;
}
else
{
var validatetill=document.getElementById('txtvalidtil').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidtil').value!="")
{
var txt=document.getElementById('txtvalidtil').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatetill=mm+'/'+dd+'/'+yy;
}
else
{
var validatetill=document.getElementById('txtvalidtil').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatetill=document.getElementById('txtvalidtil').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatetill=document.getElementById('txtvalidtil').value;
}



if(modify!="1" && modify!=null)
{
premium_master.checkcode(txtpremiumcode,compcode,userid,call_chkcode);
}
else

{
premium_master.update(drpcombin,drpadvtype,drpcategory,txtpremiumcode,drpprerate,txtrate,drppremiumtype,txtremarks,validatedate,validatetill,compcode,userid,drppackagename,drprategroup);


					
					
					document.getElementById('drpcombination').disabled=true;
document.getElementById('drpadvtype').disabled=true;
document.getElementById('drpcategory').disabled=true;
document.getElementById('txtpremiumcode').disabled=true;
document.getElementById('drpprerate').disabled=true;
document.getElementById('txtrate').disabled=true;
document.getElementById('drppremiumtype').disabled=true;
document.getElementById('drprategroup').disabled=true;
document.getElementById('txtvalidfrom').disabled=true;
document.getElementById('txtvalidtil').disabled=true;
document.getElementById('txtremarks').disabled=true;


alert("Value Updated");
					
					modify="0";
					
					flag=0;
					updateStatus();
					
					

}
return false;
}

function call_chkcode(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
	{
	
	alert("This Code Has Been Assigned");
	return false;
	}
	else
	{
	var drpcombin=document.getElementById('drpcombination').value;
var drpadvtype=document.getElementById('drpadvtype').value;
var drpcategory=document.getElementById('drpcategory').value;
var txtpremiumcode=document.getElementById('txtpremiumcode').value;
var drpprerate=document.getElementById('drpprerate').value;
var txtrate=document.getElementById('txtrate').value;
var drppremiumtype=document.getElementById('drppremiumtype').value;
var drprategroup=document.getElementById('drprategroup').value;
var drppackagename=document.getElementById('drppackagename').value;
//var txtvalidtil=document.getElementById('txtvalidtil').value;
var txtremarks=document.getElementById('txtremarks').value;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;

//this is for from date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidfrom').value != "")
{
var txt=document.getElementById('txtvalidfrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidfrom').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidfrom').value!="")
{
var txt=document.getElementById('txtvalidfrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidfrom').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatedate=document.getElementById('txtvalidfrom').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatedate=document.getElementById('txtvalidfrom').value;
}

///////////////////////////////////
// this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidtil').value != "")
{
var txt=document.getElementById('txtvalidtil').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatetill=mm+'/'+dd+'/'+yy;
}
else
{
var validatetill=document.getElementById('txtvalidtil').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidtil').value!="")
{
var txt=document.getElementById('txtvalidtil').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatetill=mm+'/'+dd+'/'+yy;
}
else
{
var validatetill=document.getElementById('txtvalidtil').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatetill=document.getElementById('txtvalidtil').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatetill=document.getElementById('txtvalidtil').value;
}






premium_master.insert(drpcombin,drpadvtype,drpcategory,txtpremiumcode,drpprerate,txtrate,drppremiumtype,txtremarks,validatedate,validatetill,compcode,userid,drppackagename,drprategroup);

document.getElementById('drpcombination').value="0";
document.getElementById('drpadvtype').value="0";
document.getElementById('drpcategory').value="0";
document.getElementById('txtpremiumcode').value="";
document.getElementById('drpprerate').value="0";
document.getElementById('txtrate').value="";
document.getElementById('drppremiumtype').value="0";
document.getElementById('drprategroup').value="0";
document.getElementById('txtvalidfrom').value="";
document.getElementById('txtvalidtil').value="";
document.getElementById('txtremarks').value="";

document.getElementById('drpcombination').disabled=true;
document.getElementById('drpadvtype').disabled=true;
document.getElementById('drpcategory').disabled=true;
document.getElementById('txtpremiumcode').disabled=true;
document.getElementById('drpprerate').disabled=true;
document.getElementById('txtrate').disabled=true;
document.getElementById('drppremiumtype').disabled=true;
document.getElementById('drprategroup').disabled=true;
document.getElementById('txtvalidfrom').disabled=false;
document.getElementById('txtvalidtil').disabled=true;
document.getElementById('txtremarks').disabled=true;

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

alert("value save sucessfully");
cancelclick('premium_master');
return false;
	
	}
}
function executeclick()
{
var drpadvtype=document.getElementById('drpadvtype').value;
var drpcategory=document.getElementById('drpcategory').value;
var txtpremiumcode=document.getElementById('txtpremiumcode').value;
var drpprerate=document.getElementById('drpprerate').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
//var document.getElementById('txtvalidfrom').value;
var dateformat=document.getElementById('hiddendateformat').value;

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidfrom').value != "")
{
var txt=document.getElementById('txtvalidfrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidfrom').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidfrom').value!="")
{
var txt=document.getElementById('txtvalidfrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidfrom').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatedate=document.getElementById('txtvalidfrom').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatedate=document.getElementById('txtvalidfrom').value;
}

premium_master.execute(drpadvtype,drpcategory,txtpremiumcode,drpprerate,validatedate,compcode,userid,call_executeclick);



document.getElementById('drpcombination').disabled=true;
document.getElementById('drpadvtype').disabled=true;
document.getElementById('drpcategory').disabled=true;
document.getElementById('txtpremiumcode').disabled=true;
document.getElementById('drpprerate').disabled=true;
document.getElementById('txtrate').disabled=true;
document.getElementById('drppremiumtype').disabled=true;
document.getElementById('drprategroup').disabled=true;
document.getElementById('txtvalidfrom').disabled=true;
document.getElementById('txtvalidtil').disabled=true;
document.getElementById('txtremarks').disabled=true;


						
						updateStatus();
document.getElementById('btnfirst').disabled=true;
	document.getElementById('btnprevious').disabled=true;
return false;
}


function call_executeclick(response)
{
var ds=response.value;

if(ds.Tables[0].Rows.length <= 0)
{
cancelclick('premium_master');

alert("Your Search Criteria Does not Produce Any Result");

return false;
}
else
{
var drpcombin=document.getElementById('drpcombination').value=ds.Tables[0].Rows[0].combin_code ;
var drpadvtype=document.getElementById('drpadvtype').value=ds.Tables[0].Rows[0].adv_type_code;
var drpcategory=document.getElementById('drpcategory').value=ds.Tables[0].Rows[0].adv_cat_code;
var txtpremiumcode=document.getElementById('txtpremiumcode').value=ds.Tables[0].Rows[0].prem_code;
var drpprerate=document.getElementById('drpprerate').value=ds.Tables[0].Rows[0].prem_rate_type;
var txtrate=document.getElementById('txtrate').value=ds.Tables[0].Rows[0].prem_rate;
var drppremiumtype=document.getElementById('drppremiumtype').value=ds.Tables[0].Rows[0].prem_type_code;
var drprategroup=document.getElementById('drprategroup').value=ds.Tables[0].Rows[0].rate_group;

var packagename=document.getElementById('drppackagename');


	packagename.options[0]=new Option(ds.Tables[0].Rows[0].package_name,ds.Tables[0].Rows[0].package_name);
	document.getElementById('drppackagename').value=packagename.options[0].value;
	//packagename.options[packagename.options.length]=new Option(ds.Tables[0].Rows[0].package_name,ds.Tables[0].Rows[0].package_name)
	//packagename.options[packagename.options.length].selected;
	var txtremarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;

//this is for from date

if(ds.Tables[0].Rows[0].valid_from_date != null && ds.Tables[0].Rows[0].valid_from_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].valid_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			
			
			}
			/////////////////////////////////////////////////
			
			////this is for till date
			if(ds.Tables[0].Rows[0].valid_till_date != null && ds.Tables[0].Rows[0].valid_till_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].valid_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidtil').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			
			
			}



}
return false;



}
function firstclick()
{
premium_master.first(call_first);

return false;
}

function call_first(response)
{
var ds=response.value;
z=0;

var drpcombin=document.getElementById('drpcombination').value=ds.Tables[0].Rows[0].combin_code ;
var drpadvtype=document.getElementById('drpadvtype').value=ds.Tables[0].Rows[0].adv_type_code;
var drpcategory=document.getElementById('drpcategory').value=ds.Tables[0].Rows[0].adv_cat_code;
var txtpremiumcode=document.getElementById('txtpremiumcode').value=ds.Tables[0].Rows[0].prem_code;
var drpprerate=document.getElementById('drpprerate').value=ds.Tables[0].Rows[0].prem_rate_type;
var txtrate=document.getElementById('txtrate').value=ds.Tables[0].Rows[0].prem_rate;
var drppremiumtype=document.getElementById('drppremiumtype').value=ds.Tables[0].Rows[0].prem_type_code;
var drprategroup=document.getElementById('drprategroup').value=ds.Tables[0].Rows[0].rate_group;

var packagename=document.getElementById('drppackagename');


	
	//packagename.options[packagename.options.length]=new Option(ds.Tables[0].Rows[0].package_name,ds.Tables[0].Rows[0].package_name)
	packagename.options[0]=new Option(ds.Tables[0].Rows[0].package_name,ds.Tables[0].Rows[0].package_name);
	document.getElementById('drppackagename').value=packagename.options[0].value;
	//packagename.option[packagename.options.length].selected;
	var txtremarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;

//this is for from date

if(ds.Tables[0].Rows[0].valid_from_date != null && ds.Tables[0].Rows[0].valid_from_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].valid_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			
			
			}
			/////////////////////////////////////////////////
			
			////this is for till date
			if(ds.Tables[0].Rows[0].valid_till_date != null && ds.Tables[0].Rows[0].valid_till_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].valid_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidtil').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtvalidtil').value="";
			}
			updateStatus();

document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;	
return false;
}

function lastclick()
{
premium_master.first(call_last);


return false;
}

function call_last(response)
{
var ds=response.value;
var y=ds.Tables[0].Rows.length;
var a=y-1;
z=ds.Tables[0].Rows.length;

var drpcombin=document.getElementById('drpcombination').value=ds.Tables[0].Rows[a].combin_code ;
var drpadvtype=document.getElementById('drpadvtype').value=ds.Tables[0].Rows[a].adv_type_code;
var drpcategory=document.getElementById('drpcategory').value=ds.Tables[0].Rows[a].adv_cat_code;
var txtpremiumcode=document.getElementById('txtpremiumcode').value=ds.Tables[0].Rows[a].prem_code;
var drpprerate=document.getElementById('drpprerate').value=ds.Tables[0].Rows[a].prem_rate_type;
var txtrate=document.getElementById('txtrate').value=ds.Tables[0].Rows[a].prem_rate;
var drppremiumtype=document.getElementById('drppremiumtype').value=ds.Tables[0].Rows[a].prem_type_code;
var drprategroup=document.getElementById('drprategroup').value=ds.Tables[0].Rows[a].rate_group;

var packagename=document.getElementById('drppackagename');


	
	packagename.options[packagename.options.length]=new Option(ds.Tables[0].Rows[a].package_name,ds.Tables[0].Rows[a].package_name)
	//packagename.option[packagename.options.length].selected;
	var txtremarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[a].remarks;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;

//this is for from date

if(ds.Tables[0].Rows[a].valid_from_date != null && ds.Tables[0].Rows[a].valid_from_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].valid_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			
			
			}
			/////////////////////////////////////////////////
			
			////this is for till date
			if(ds.Tables[0].Rows[a].valid_till_date != null && ds.Tables[0].Rows[a].valid_till_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[a].valid_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidtil').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtvalidtil').value="";
			}
			updateStatus();
document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;
return false;
}

function nextclick()
{
premium_master.first(call_next);
return false;
}
function call_next(response)
{
var ds=response.value;
var ds=response.value;
var ds=response.value;
var a=ds.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		
		updateStatus();
		
		var drpcombin=document.getElementById('drpcombination').value=ds.Tables[0].Rows[z].combin_code ;
var drpadvtype=document.getElementById('drpadvtype').value=ds.Tables[0].Rows[z].adv_type_code;
var drpcategory=document.getElementById('drpcategory').value=ds.Tables[0].Rows[z].adv_cat_code;
var txtpremiumcode=document.getElementById('txtpremiumcode').value=ds.Tables[0].Rows[z].prem_code;
var drpprerate=document.getElementById('drpprerate').value=ds.Tables[0].Rows[z].prem_rate_type;
var txtrate=document.getElementById('txtrate').value=ds.Tables[0].Rows[z].prem_rate;
var drppremiumtype=document.getElementById('drppremiumtype').value=ds.Tables[0].Rows[z].prem_type_code;
var drprategroup=document.getElementById('drprategroup').value=ds.Tables[0].Rows[z].rate_group;

var packagename=document.getElementById('drppackagename');


	
	packagename.options[packagename.options.length]=new Option(ds.Tables[0].Rows[z].package_name,ds.Tables[0].Rows[z].package_name)
	//packagename.option[packagename.options.length].selected;
	var txtremarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].remarks;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;

//this is for from date

if(ds.Tables[0].Rows[z].valid_from_date != null && ds.Tables[0].Rows[z].valid_from_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].valid_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			
			
			}
			/////////////////////////////////////////////////
			
			////this is for till date
			if(ds.Tables[0].Rows[z].valid_till_date != null && ds.Tables[0].Rows[z].valid_till_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].valid_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidtil').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtvalidtil').value="";
			}
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

function previousclick()
{
premium_master.first(call_previous);
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
			
			updateStatus();
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
			
			
			var drpcombin=document.getElementById('drpcombination').value=ds.Tables[0].Rows[z].combin_code ;
var drpadvtype=document.getElementById('drpadvtype').value=ds.Tables[0].Rows[z].adv_type_code;
var drpcategory=document.getElementById('drpcategory').value=ds.Tables[0].Rows[z].adv_cat_code;
var txtpremiumcode=document.getElementById('txtpremiumcode').value=ds.Tables[0].Rows[z].prem_code;
var drpprerate=document.getElementById('drpprerate').value=ds.Tables[0].Rows[z].prem_rate_type;
var txtrate=document.getElementById('txtrate').value=ds.Tables[0].Rows[z].prem_rate;
var drppremiumtype=document.getElementById('drppremiumtype').value=ds.Tables[0].Rows[z].prem_type_code;
var drprategroup=document.getElementById('drprategroup').value=ds.Tables[0].Rows[z].rate_group;

var packagename=document.getElementById('drppackagename');


	
	packagename.options[packagename.options.length]=new Option(ds.Tables[0].Rows[z].package_name,ds.Tables[0].Rows[z].package_name)
	//packagename.option[packagename.options.length].selected;
	var txtremarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].remarks;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;

//this is for from date

if(ds.Tables[0].Rows[z].valid_from_date != null && ds.Tables[0].Rows[z].valid_from_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].valid_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			
			
			}
			/////////////////////////////////////////////////
			
			////this is for till date
			if(ds.Tables[0].Rows[z].valid_till_date != null && ds.Tables[0].Rows[z].valid_till_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].valid_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidtil').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			
			
			}
			else
			{
			document.getElementById('txtvalidtil').value="";
			}
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
		if(z=="0")
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
		return false;
}

function deleteclick()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;
var txtpremiumcode=document.getElementById('txtpremiumcode').value;

if(confirm("Are You Dure To Delete The Data"))
	{
	premium_master.deleteed(txtpremiumcode,compcode,userid);
	alert("Data Deleted");
	premium_master.first(call_delete);

	
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
	
document.getElementById('drpcombination').value="0";
document.getElementById('drpadvtype').value="0";
document.getElementById('drpcategory').value="0";
document.getElementById('txtpremiumcode').value="";
document.getElementById('drpprerate').value="0";
document.getElementById('txtrate').value="";
document.getElementById('drppremiumtype').value="0";
document.getElementById('drprategroup').value="0";
document.getElementById('txtvalidfrom').value="";
document.getElementById('txtvalidtil').value="";
document.getElementById('txtremarks').value="";
document.getElementById('drppackagename').value="0";

cancelclick('premium_master');	
return false;
	}
	
	else if(z==-1 ||z>=a)
	{
		var drpcombin=document.getElementById('drpcombination').value=ds.Tables[0].Rows[0].combin_code ;
var drpadvtype=document.getElementById('drpadvtype').value=ds.Tables[0].Rows[0].adv_type_code;
var drpcategory=document.getElementById('drpcategory').value=ds.Tables[0].Rows[0].adv_cat_code;
var txtpremiumcode=document.getElementById('txtpremiumcode').value=ds.Tables[0].Rows[0].prem_code;
var drpprerate=document.getElementById('drpprerate').value=ds.Tables[0].Rows[0].prem_rate_type;
var txtrate=document.getElementById('txtrate').value=ds.Tables[0].Rows[0].prem_rate;
var drppremiumtype=document.getElementById('drppremiumtype').value=ds.Tables[0].Rows[0].prem_type_code;
var drprategroup=document.getElementById('drprategroup').value=ds.Tables[0].Rows[0].rate_group;

var packagename=document.getElementById('drppackagename');


	
	//packagename.options[packagename.options.length]=new Option(ds.Tables[0].Rows[0].package_name,ds.Tables[0].Rows[0].package_name)
	packagename.options[0]=new Option(ds.Tables[0].Rows[0].package_name,ds.Tables[0].Rows[0].package_name);
	document.getElementById('drppackagename').value=packagename.options[0].value;
	//packagename.option[packagename.options.length].selected;
	var txtremarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;

//this is for from date

if(ds.Tables[0].Rows[0].valid_from_date != null && ds.Tables[0].Rows[0].valid_from_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].valid_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			
			
			}
			/////////////////////////////////////////////////
			
			////this is for till date
			if(ds.Tables[0].Rows[0].valid_till_date != null && ds.Tables[0].Rows[0].valid_till_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].valid_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidtil').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			
			
			}
	}
	
	else
	{
		var drpcombin=document.getElementById('drpcombination').value=ds.Tables[0].Rows[z].combin_code ;
var drpadvtype=document.getElementById('drpadvtype').value=ds.Tables[0].Rows[z].adv_type_code;
var drpcategory=document.getElementById('drpcategory').value=ds.Tables[0].Rows[z].adv_cat_code;
var txtpremiumcode=document.getElementById('txtpremiumcode').value=ds.Tables[0].Rows[z].prem_code;
var drpprerate=document.getElementById('drpprerate').value=ds.Tables[0].Rows[z].prem_rate_type;
var txtrate=document.getElementById('txtrate').value=ds.Tables[0].Rows[z].prem_rate;
var drppremiumtype=document.getElementById('drppremiumtype').value=ds.Tables[0].Rows[z].prem_type_code;
var drprategroup=document.getElementById('drprategroup').value=ds.Tables[0].Rows[z].rate_group;

var packagename=document.getElementById('drppackagename');


	
	packagename.options[packagename.options.length]=new Option(ds.Tables[0].Rows[z].package_name,ds.Tables[0].Rows[z].package_name)
	//packagename.option[packagename.options.length].selected;
	var txtremarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].remarks;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value;

//this is for from date

if(ds.Tables[0].Rows[z].valid_from_date != null && ds.Tables[0].Rows[z].valid_from_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].valid_from_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidfrom').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidfrom').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidfrom').value=enrolldate1;
			}
			
			
			}
			/////////////////////////////////////////////////
			
			////this is for till date
			if(ds.Tables[0].Rows[z].valid_till_date != null && ds.Tables[0].Rows[z].valid_till_date != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].valid_till_date;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidtil').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidtil').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidtil').value=enrolldate1;
			}
			
			
			}
		
	}
	
	return false;
	

}