//this is for save and modify
var modify="0";
//
//searching variable
var z=0;
//
//this flag is for permission
var flag="";
////////////////////////////
function submitintotext()
{
//var textarray=new Array[100];
var total="";
var x;
var z="";
var abc=new Array(1000);
var perce=new Array(1000);
var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	var k=document.getElementById(str).value ;
	perce[j]=k;
	var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}
	
	 for(x=0;x<=abc.length;x++)
	{
	if(abc[x]==undefined || perce[x]=="")
	{}
	else
	{
	 z=z+abc[x]+",";
	 }
	 
	 }
	 total=z;
	 document.getElementById('txtsharedescription').value=total;
	 return false;
	

}
function newclick()
{

var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	//var k=document.getElementById(str).value ;
	//perce[j]=k;
	document.getElementById(str).disabled=false;
	document.getElementById(str).value="";
	//var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	//abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}



document.getElementById('txtsharecode').value="";
document.getElementById('txtsharedescription').value="";
document.getElementById('txtvalidaetdate').value="";
document.getElementById('txtvalidatetill').value="";
document.getElementById('txtremarks').value="";

document.getElementById('btnsubmit').disabled=false;
document.getElementById('txtsharecode').disabled=false;
document.getElementById('txtsharedescription').disabled=false;
document.getElementById('txtvalidaetdate').disabled=false;
document.getElementById('txtvalidatetill').disabled=false;
document.getElementById('txtremarks').disabled=false;

var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");



chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;	
document.getElementById('btnNew').disabled = true;	
document.getElementById('btnQuery').disabled=true;
flag=0;


return false;
}
function cancelclick(formname)
{

var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	//var k=document.getElementById(str).value ;
	//perce[j]=k;
	document.getElementById(str).disabled=true;
	document.getElementById(str).value="";
	//var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	//abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}

document.getElementById('txtsharecode').value="";
document.getElementById('txtsharedescription').value="";
document.getElementById('txtvalidaetdate').value="";
document.getElementById('txtvalidatetill').value="";
document.getElementById('txtremarks').value="";

document.getElementById('btnsubmit').disabled=true;
document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;

getPermission(formname);
			
			modify="0";


return false;
}
function queryclick()
{
z=0;
var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	//var k=document.getElementById(str).value ;
	//perce[j]=k;
	document.getElementById(str).disabled=true;
	document.getElementById(str).value="";
	//var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	//abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}

document.getElementById('txtsharecode').value="";
document.getElementById('txtsharedescription').value="";
document.getElementById('txtvalidaetdate').value="";
document.getElementById('txtvalidatetill').value="";
document.getElementById('txtremarks').value="";

document.getElementById('btnsubmit').disabled=false;
document.getElementById('txtsharecode').disabled=false;
document.getElementById('txtsharedescription').disabled=false;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;


chkstatus(FlagStatus);

document.getElementById('btnQuery').disabled=true;
document.getElementById('btnExecute').disabled=false;
document.getElementById('btnSave').disabled=true;
	
	modify="0";


return false;
}
function modifyclick()
{


var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	//var k=document.getElementById(str).value ;
	//perce[j]=k;
	document.getElementById(str).disabled=false;
	document.getElementById(str).value="";
	//var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	//abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}


document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=false;
document.getElementById('txtvalidaetdate').disabled=false;
document.getElementById('txtvalidatetill').disabled=false;
document.getElementById('txtremarks').disabled=false;
document.getElementById('btnsubmit').disabled=false;


chkstatus(FlagStatus);
document.getElementById('btnSave').disabled = false;
document.getElementById('btnQuery').disabled=true;
flag=1;	




modify="1";

return false;
}
function submittedclick()
{
var fromdate=document.getElementById('txtvalidaetdate').value;
		var todate=document.getElementById('txtvalidatetill').value;
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);
if(document.getElementById('txtsharecode').value=="")
{
alert("Please Enter The Share Code");
document.getElementById('txtsharecode').focus();
return false;
}
else if(document.getElementById('txtsharedescription').value=="")
{
alert("Please Enter The Share Description");
document.getElementById('txtsharedescription').focus();
return false;
}
else if(document.getElementById('txtvalidaetdate').value=="")
{
alert("Please Enter The From Date");
document.getElementById('txtvalidaetdate').focus();
return false;
}
else if(document.getElementById('txtvalidatetill').value=="")
{
alert("Please Enter The Till Date");
document.getElementById('txtvalidatetill').focus();
return false;
}
else if(fromdate !='' && todate !='' && fdate > tdate)
{
alert("Till Date must be Greater Then From Date");
//document.getElementById('txtefftill').focus();
return false;
}



/*document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;*/

var sharecode=document.getElementById('txtsharecode').value;
var sharedescription=document.getElementById('txtsharedescription').value;
//var validatedate=document.getElementById('txtvalidaetdate');
//var validatetill=document.getElementById('txtvalidatetill');
var remarks=document.getElementById('txtremarks').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 


if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidaetdate').value != "")
{
var txt=document.getElementById('txtvalidaetdate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidaetdate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidaetdate').value!="")
{
var txt=document.getElementById('txtvalidaetdate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidaetdate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatedate=document.getElementById('txtvalidaetdate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatedate=document.getElementById('txtvalidaetdate').value;
}



if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidatetill').value != "")
{
var txt=document.getElementById('txtvalidatetill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatetill=mm+'/'+dd+'/'+yy;
}
else
{
var validatetill=document.getElementById('txtvalidatetill').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidatetill').value!="")
{
var txt=document.getElementById('txtvalidatetill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatetill=mm+'/'+dd+'/'+yy;
}
else
{
var txtvalidatetill=document.getElementById('txtvalidatetill').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatetill=document.getElementById('txtvalidatetill').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatetill=document.getElementById('txtvalidatetill').value;
}


document.getElementById('btnsubmit').disabled=true;
if(modify!="1" && modify!="")
{
Revenue_master.checkcode(sharecode,compcode,userid,call_saveclick);
return false;
}
else
{

Revenue_master.update(sharecode,sharedescription,validatedate,validatetill,remarks,compcode,userid);

document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;

var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	//var k=document.getElementById(str).value ;
	//perce[j]=k;
	document.getElementById(str).disabled=true;
	document.getElementById(str).value="";
	//var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	//abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}

flag=0;
updateStatus();
alert("Data Updated Successfully");
			
modify="0";
}
return false;
}
function call_saveclick(response)
{
var ds=response.value;


var sharecode=document.getElementById('txtsharecode').value;
var sharedescription=document.getElementById('txtsharedescription').value;
var remarks=document.getElementById('txtremarks').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 


if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidaetdate').value != "")
{
var txt=document.getElementById('txtvalidaetdate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidaetdate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidaetdate').value!="")
{
var txt=document.getElementById('txtvalidaetdate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatedate=mm+'/'+dd+'/'+yy;
}
else
{
var validatedate=document.getElementById('txtvalidaetdate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatedate=document.getElementById('txtvalidaetdate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatedate=document.getElementById('txtvalidaetdate').value;
}



if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidatetill').value != "")
{
var txt=document.getElementById('txtvalidatetill').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var validatetill=mm+'/'+dd+'/'+yy;
}
else
{
var validatetill=document.getElementById('txtvalidatetill').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidatetill').value!="")
{
var txt=document.getElementById('txtvalidatetill').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var validatetill=mm+'/'+dd+'/'+yy;
}
else
{
var txtvalidatetill=document.getElementById('txtvalidatetill').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var validatetill=document.getElementById('txtvalidatetill').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var validatetill=document.getElementById('txtvalidatetill').value;
}



if(ds.Tables[0].Rows.length > 0)
	{
	//cancelclick('Revenue_master');
	alert("This Code Is Already Assigned");
	return false;
	} 
	else
	{
	Revenue_master.insert(sharecode,sharedescription,validatedate,validatetill,remarks,compcode,userid);
	
	alert("Data Saved Successfully");
	
	document.getElementById('txtsharecode').value="";
	document.getElementById('txtsharedescription').value="";
	document.getElementById('txtvalidaetdate').value="";
	document.getElementById('txtvalidatetill').value="";
	document.getElementById('txtremarks').value="";
	
	var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

	
	for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	//var k=document.getElementById(str).value ;
	//perce[j]=k;
	document.getElementById(str).disabled=true;
	document.getElementById(str).value="";
	//var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	//abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}

	}
	
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
	
	

document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;


var total="";
var x;
var z="";
var abc=new Array(1000);
var perce=new Array(1000);
var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	document.getElementById(str).value="" ;
	perce[j]=k;
	var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}


cancelclick('Revenue_master');

return false;
}
function executeclick()
{

var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for(j=0;j<i;j++)
	{
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	//var k=document.getElementById(str).value ;
	//perce[j]=k;
	document.getElementById(str).disabled=true;
	document.getElementById(str).value="";
	//var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	//abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}





var sharecode=document.getElementById('txtsharecode').value;
var sharedescription=document.getElementById('txtsharedescription').value;
//var validatedate=document.getElementById('txtvalidaetdate');
//var validatetill=document.getElementById('txtvalidatetill');
var remarks=document.getElementById('txtremarks').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 
document.getElementById('btnsubmit').disabled=true;
document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;


Revenue_master.execute(sharecode,sharedescription,compcode,userid,call_excute);
updateStatus();

document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
modify="0";
return false;
}
function call_excute(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length <= 0)
	{
	cancelclick('Revenue_master');
	alert("Your Search Criteria Doesn't produce any result!!!");
	return false;
	} 
	else
	{
	var sharecode=document.getElementById('txtsharecode').value=ds.Tables[0].Rows[0].share_code;
	var sharedescription=document.getElementById('txtsharedescription').value=ds.Tables[0].Rows[0].share_desc;
//var validatedate=document.getElementById('txtvalidaetdate');
//var validatetill=document.getElementById('txtvalidatetill');
	var remarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
	var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(ds.Tables[0].Rows[0].validate_fromdate != null && ds.Tables[0].Rows[0].validate_fromdate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].validate_fromdate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidaetdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			
			
			}
			
			
			if(ds.Tables[0].Rows[0].validate_tilldate != null && ds.Tables[0].Rows[0].validate_tilldate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].validate_tilldate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidatetill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			
			
			}
			
			
			
			}
	
	
	return false;
	
	}
	function firstclick()
	{
	Revenue_master.firstrev(call_firstclick);
	
	
			document.getElementById('btnsubmit').disabled=true;
	return false;
	}

function call_firstclick(response)
{
var ds=response.value;


var sharecode=document.getElementById('txtsharecode').value=ds.Tables[0].Rows[0].share_code;
	var sharedescription=document.getElementById('txtsharedescription').value=ds.Tables[0].Rows[0].share_desc;
//var validatedate=document.getElementById('txtvalidaetdate');
//var validatetill=document.getElementById('txtvalidatetill');
	var remarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
	var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(ds.Tables[0].Rows[0].validate_fromdate != null && ds.Tables[0].Rows[0].validate_fromdate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].validate_fromdate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidaetdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			
			
			}
			
			
			if(ds.Tables[0].Rows[0].validate_tilldate != null && ds.Tables[0].Rows[0].validate_tilldate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[0].validate_tilldate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidatetill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			
			
			}
			
			document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;
			
			
		z=0;	
		updateStatus();

document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;		
	
	
	return false;

}

function lastclick()
{
Revenue_master.firstrev(call_lastclick);



			
			document.getElementById('btnsubmit').disabled=true;
	return false;
}
function call_lastclick(response)
{
var ds=response.value;
var y=ds.Tables[0].Rows.length;
var a=y-1;
z=a;
var sharecode=document.getElementById('txtsharecode').value=ds.Tables[0].Rows[a].share_code;
	var sharedescription=document.getElementById('txtsharedescription').value=ds.Tables[0].Rows[a].share_desc;
//var validatedate=document.getElementById('txtvalidaetdate');
//var validatetill=document.getElementById('txtvalidatetill');
	var remarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[a].remarks;
	var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(ds.Tables[0].Rows[a].validate_fromdate != null && ds.Tables[0].Rows[a].validate_fromdate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[a].validate_fromdate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidaetdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			
			
			}
			
			
			if(ds.Tables[0].Rows[a].validate_tilldate != null && ds.Tables[0].Rows[a].validate_tilldate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[a].validate_tilldate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidatetill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			
			
			}
			
			document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;
			
			
		
			
	updateStatus();
document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnprevious').disabled=false;	
	
	return false;



}

function previousclick()
{
Revenue_master.firstrev(call_previousclick);
document.getElementById('btnsubmit').disabled=true;
document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;
	return false;
}
function call_previousclick(response)
{
var ds=response.value;
var a=ds.Tables[0].Rows.length;
z--;
if(z != -1)
		{
			//if(z >= 0 && z <= a-1)
			if(z >= 0 && z < a )
			{
			updateStatus();
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
		
			var sharecode=document.getElementById('txtsharecode').value=ds.Tables[0].Rows[z].share_code;
	var sharedescription=document.getElementById('txtsharedescription').value=ds.Tables[0].Rows[z].share_desc;
//var validatedate=document.getElementById('txtvalidaetdate');
//var validatetill=document.getElementById('txtvalidatetill');
	var remarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].remarks;
	var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(ds.Tables[0].Rows[z].validate_fromdate != null && ds.Tables[0].Rows[z].validate_fromdate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].validate_fromdate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidaetdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			
			
			}
			
			
			if(ds.Tables[0].Rows[z].validate_tilldate != null && ds.Tables[0].Rows[z].validate_tilldate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].validate_tilldate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidatetill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
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
			{
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			return false;
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
function nextclick()
{
Revenue_master.firstrev(call_nextclick);
document.getElementById('txtsharecode').disabled=true;
document.getElementById('txtsharedescription').disabled=true;
document.getElementById('txtvalidaetdate').disabled=true;
document.getElementById('txtvalidatetill').disabled=true;
document.getElementById('txtremarks').disabled=true;
	return false;
}
function call_nextclick(response)
{
var ds=response.value;
var ds=response.value;
var a=ds.Tables[0].Rows.length;
z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		updateStatus();
		document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		var sharecode=document.getElementById('txtsharecode').value=ds.Tables[0].Rows[z].share_code;
	var sharedescription=document.getElementById('txtsharedescription').value=ds.Tables[0].Rows[z].share_desc;
//var validatedate=document.getElementById('txtvalidaetdate');
//var validatetill=document.getElementById('txtvalidatetill');
	var remarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].remarks;
	var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(ds.Tables[0].Rows[z].validate_fromdate != null && ds.Tables[0].Rows[z].validate_fromdate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].validate_fromdate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidaetdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			
			
			}
			
			
			if(ds.Tables[0].Rows[z].validate_tilldate != null && ds.Tables[0].Rows[z].validate_tilldate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].validate_tilldate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidatetill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			
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
		
		
			
			
	}	


return false;
}
function deleteclick()
{
		var sharecode=document.getElementById('txtsharecode').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var dateformat=document.getElementById('hiddendateformat').value; 
		if(confirm("Are You Sure To Delete The Data"))
			{
			Revenue_master.deleterev(sharecode,compcode,userid);
			alert("Data Deleted Sucessfully");
			Revenue_master.firstrev(call_deleteclick);
			
			}
		return false;

}
function call_deleteclick(response)
{
	var ds=response.value;
	var a=ds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
			alert("There Is No Data");
			document.getElementById('txtsharecode').value="";
document.getElementById('txtsharedescription').value="";
document.getElementById('txtvalidaetdate').value="";
document.getElementById('txtvalidatetill').value="";
document.getElementById('txtremarks').value="";
cancelclick('Revenue_master');
return false;
	}
	
	else if(z==-1 ||z>=a )
	{
	var sharecode=document.getElementById('txtsharecode').value=ds.Tables[0].Rows[0].share_code;
	var sharedescription=document.getElementById('txtsharedescription').value=ds.Tables[0].Rows[0].share_desc;
	//var validatedate=document.getElementById('txtvalidaetdate');
	//var validatetill=document.getElementById('txtvalidatetill');
	var remarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].remarks;
	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	var dateformat=document.getElementById('hiddendateformat').value; 

	if(ds.Tables[0].Rows[0].validate_fromdate != null && ds.Tables[0].Rows[0].validate_fromdate != "")
	{
			var validate_fromdate=ds.Tables[0].Rows[0].validate_fromdate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidaetdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
	}
			
	if(ds.Tables[0].Rows[0].validate_tilldate != null && ds.Tables[0].Rows[0].validate_tilldate != "")
	{
			var validate_fromdate=ds.Tables[0].Rows[0].validate_tilldate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidatetill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			
	}return false;}
	else
	{
	
	var sharecode=document.getElementById('txtsharecode').value=ds.Tables[0].Rows[z].share_code;
	var sharedescription=document.getElementById('txtsharedescription').value=ds.Tables[0].Rows[z].share_desc;
//var validatedate=document.getElementById('txtvalidaetdate');
//var validatetill=document.getElementById('txtvalidatetill');
	var remarks=document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].remarks;
	var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('hiddendateformat').value; 

	
	if(ds.Tables[0].Rows[z].validate_fromdate != null && ds.Tables[0].Rows[z].validate_fromdate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].validate_fromdate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidaetdate').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidaetdate').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidaetdate').value=enrolldate1;
			}
			
			
			}
			
			
			if(ds.Tables[0].Rows[z].validate_tilldate != null && ds.Tables[0].Rows[z].validate_tilldate != "")
			{
			var validate_fromdate=ds.Tables[0].Rows[z].validate_tilldate;
			var dd=validate_fromdate.getDate();
			var mm=validate_fromdate.getMonth() + 1;
			var yyyy=validate_fromdate.getFullYear();
			
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			var enrolldateday=dd+'/'+mm+'/'+yyyy;
			var enrollyear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			document.getElementById('txtvalidatetill').value=enrollyear;
			}
			if(dateformat=="dd/mm/yyyy")
			{
			document.getElementById('txtvalidatetill').value=enrolldateday;
			}
			if(dateformat==null || dateformat=="")
			{
			document.getElementById('txtvalidatetill').value=enrolldate1;
			}
	
	}}
	
	

return false;}

function allamount(ab)
		{
		//var fld =document.getElementById(ab).value;
		var fld=ab.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{2})?$/i))
			{
			return true;
			}
			else
			{
			alert("Input error")
			//document.getElementById(ab).focus();
			ab.focus();
			return false;
			}
			
			}
	return true;
		}
		
		function exitclick()
		{
		if(confirm("Do You Want To Skip This Page"))
		{
		window.location.href='EnterPage.aspx';
		return false;
		}
		return false;
		}
		
		/*function uppervalue()
		{
		var abc=document.getElementById('txtsharedescription').value;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

Revenue_master.bindf(compcode,userid,call_abc);


		}
		function call_abc(response)
		{
		var ds=response.value;
		var abc=document.getElementById('txtsharedescription').value;

		var ab=abc.split('');
var a=ab[0];
var b=ab[1];

var i=document.getElementById("DataGrid1").rows.length -1;
var grid=document.getElementById("DataGrid1");

for( var j=0;j<i;j++)
	{
	if(ds.Tables[0].Rows[j].
	var str="textbox" + j;
	var str1="DataGrid1__ctl_CheckBox1" + j;;
	var k=document.getElementById(str).value ;
	perce[j]=k;
	var editionvalue=grid.rows[j+1].cells[0].innerHTML;
	abc[j]=editionvalue+" "+k;
	//alert(grid.rows[j].cells[0].innerHTML); 
	}
	
	 for(x=0;x<=abc.length;x++)
	{
	if(abc[x]==undefined || perce[x]=="")
	{}
	else
	{
	 z=z+abc[x]+",";
	 }
	 
	 }
		
		
		}*/
		