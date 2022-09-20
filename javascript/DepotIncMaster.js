
//this is for save and update
var insert="0";

var code10;
function submitclick()
{
var fromdate=document.getElementById('txtvalidityfrom').value;
		var todate=document.getElementById('txttilldate').value;
		var fdate=new Date(fromdate);
		var tdate=new Date(todate);


if(document.getElementById('txtslabfrom').value=="")
{
alert("Please Enter The Slab From Value");
document.getElementById('txtslabfrom').focus();
return false;
}
else if(document.getElementById('txtslabto').value=="")
{
alert("Please Enter Slab To Value");
document.getElementById('txtslabto').focus();
return false;
}
else if(document.getElementById('txtpercentage').value=="")
{
alert("Please Enter Percentage");
document.getElementById('txtpercentage').focus();
return false;
}
else if(document.getElementById('txttdsrate').value=="")
{
alert("Please Enter TDS Rate");
document.getElementById('txttdsrate').focus();
return false;
}
else if(document.getElementById('txtvalidityfrom').value=="")
{
alert("Please Enter Validity Date");
document.getElementById('txtvalidityfrom').focus();
return false;
}
else if(document.getElementById('txttilldate').value=="")
{
alert("Please Enter The Till Date");
document.getElementById('txttilldate').focus();
return false;
}
else if(fdate > tdate)
{
alert("Effective From Date Should Be Less Then Till Date");
document.getElementById('txttilldate').focus();
return false;
}

var slabfrom=document.getElementById('txtslabfrom').value;
var slabto=document.getElementById('txtslabto').value;
var percentage=document.getElementById('txtpercentage').value;
var rate=document.getElementById('txttdsrate').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 

var dateformat=document.getElementById('hiddendateformat').value; 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidityfrom').value != "")
{
var txt=document.getElementById('txtvalidityfrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidityfrom').value!="")
{
var txt=document.getElementById('txtvalidityfrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}

//this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txttilldate').value != "")
{
var txt=document.getElementById('txttilldate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txttilldate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txttilldate').value!="")
{
var txt=document.getElementById('txttilldate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txttilldate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txttilldate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txttilldate').value;
}

if(insert!="1" && insert!=null)
{
//DepotIncmaster.insertde(slabfrom,slabto,percentage,rate,txtfromdate,txtefftill,userid,compcode);
DepotIncmaster.chkinsert(slabfrom,slabto,percentage,rate,txtfromdate,txtefftill,userid,compcode,callback_save);
//Converrate.insert(txtconrate,txtfromdate,txtefftill,compcode,userid,currcode);


}
else
{

//DepotIncmaster.update(slabfrom,slabto,percentage,rate,txtfromdate,txtefftill,userid,compcode,code10);
DepotIncmaster.chkupdate(slabfrom,slabto,percentage,rate,txtfromdate,txtefftill,userid,compcode,code10,callback_update);
document.getElementById('btndelete').disabled=true;


}


return false;
}

function selectclick()
{
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');


var j;
var k=0;

//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	//alert(document.getElementById(str).value);
	code10=document.getElementById(str).value;
	
	
	}
	}
	if(k==1)
	{
	document.getElementById('btndelete').disabled=false;
	DepotIncmaster.selected(compcode,userid,code10,selectedvalue);
	//return false;
	
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return false;
	}
	
	return false;



}

function selectedvalue(response)
{
var ds=response.value;
insert="1";

var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var dateformat=document.getElementById('hiddendateformat').value; 

var slabfrom=document.getElementById('txtslabfrom').value=ds.Tables[0].Rows[0].Incentive_Slab_From;
var slabto=document.getElementById('txtslabto').value=ds.Tables[0].Rows[0].Incentive_Slab_To;
var percentage=document.getElementById('txtpercentage').value=ds.Tables[0].Rows[0].Incent_Rate;
var rate=document.getElementById('txttdsrate').value=ds.Tables[0].Rows[0].Tds_Rate;

//this is for from date

if(ds.Tables[0].Rows[0].Eff_From_Date != null && ds.Tables[0].Rows[0].Eff_From_Date != "")
	{

	var enrolldate=ds.Tables[0].Rows[0].Eff_From_Date;
			var dd=enrolldate.getDate();
			var mm=enrolldate.getMonth() + 1;
			var yyyy=enrolldate.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1=mm+'/'+dd+'/'+yyyy;
			}
			document.getElementById('txtvalidityfrom').value=enrolldate1;
	}
	else
	{
	document.getElementById('txtvalidityfrom').value="";
	}
	
	//this for till date
	
	if(ds.Tables[0].Rows[0].Eff_Till_Date != null && ds.Tables[0].Rows[0].Eff_Till_Date != "")
	{

	var enrolldatet=ds.Tables[0].Rows[0].Eff_Till_Date;
			var dd=enrolldatet.getDate();
			var mm=enrolldatet.getMonth() + 1;
			var yyyy=enrolldatet.getFullYear();
			
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="dd/mm/yyyy")
			{
			var enrolldate1t=dd+'/'+mm+'/'+yyyy;
			}
			if(dateformat=="mm/dd/yyyy")
			{
			var enrolldate1t=mm+'/'+dd+'/'+yyyy;
			}
			if(dateformat=="yyyy/mm/dd")
			{
			var enrolldate1t=yyyy+'/'+mm+'/'+dd;
			}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
			var enrolldate1t=mm+'/'+dd+'/'+yyyy;
			}
			document.getElementById('txttilldate').value=enrolldate1t;
	}
	else
	{
	document.getElementById('txttilldate').value="";
	}

return false;
}
function deleteclick()
{

var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
//var currcode=document.getElementById('hiddencurrcode').value; 

DepotIncmaster.deletegrid(compcode,userid,code10);

window.location=window.location;
return false;
return false;
}

function callback_save(response)
{
var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
{
alert("This Date Has Been Assigned");
return false;
}
	else
	{
			var slabfrom=document.getElementById('txtslabfrom').value;
var slabto=document.getElementById('txtslabto').value;
var percentage=document.getElementById('txtpercentage').value;
var rate=document.getElementById('txttdsrate').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 

var dateformat=document.getElementById('hiddendateformat').value; 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidityfrom').value != "")
{
var txt=document.getElementById('txtvalidityfrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidityfrom').value!="")
{
var txt=document.getElementById('txtvalidityfrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}

//this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txttilldate').value != "")
{
var txt=document.getElementById('txttilldate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txttilldate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txttilldate').value!="")
{
var txt=document.getElementById('txttilldate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txttilldate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txttilldate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txttilldate').value;
}
	DepotIncmaster.insertde(slabfrom,slabto,percentage,rate,txtfromdate,txtefftill,userid,compcode);
	
	}
	window.location=window.location;
return false;
}

function callback_update(response)
{


var ds=response.value;
if(ds.Tables[0].Rows.length > 0)
{
alert("This Date Has Been Assigned");
return false;
}
	else
	{
			var slabfrom=document.getElementById('txtslabfrom').value;
var slabto=document.getElementById('txtslabto').value;
var percentage=document.getElementById('txtpercentage').value;
var rate=document.getElementById('txttdsrate').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 

var dateformat=document.getElementById('hiddendateformat').value; 

//this is for from date
if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txtvalidityfrom').value != "")
{
var txt=document.getElementById('txtvalidityfrom').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txtvalidityfrom').value!="")
{
var txt=document.getElementById('txtvalidityfrom').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtfromdate=mm+'/'+dd+'/'+yy;
}
else
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtfromdate=document.getElementById('txtvalidityfrom').value;
}

//this is for till date

if(dateformat=="dd/mm/yyyy")
{
if(document.getElementById('txttilldate').value != "")
{
var txt=document.getElementById('txttilldate').value;
var txt1=txt.split("/");
var dd=txt1[0];
var mm=txt1[1];
var yy=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txttilldate').value;
}

}
if(dateformat=="yyyy/mm/dd")
{
if(document.getElementById('txttilldate').value!="")
{
var txt=document.getElementById('txttilldate').value;
var txt1=txt.split("/");
var yy=txt1[0];
var mm=txt1[1];
var dd=txt1[2];
var txtefftill=mm+'/'+dd+'/'+yy;
}
else
{
var txtefftill=document.getElementById('txttilldate').value;
}
}
if(dateformat=="mm/dd/yyyy")
{
var txtefftill=document.getElementById('txttilldate').value;
}
if(dateformat==null || dateformat=="" || dateformat=="undefined")
{
var txtefftill=document.getElementById('txttilldate').value;
}
	DepotIncmaster.update(slabfrom,slabto,percentage,rate,txtfromdate,txtefftill,userid,compcode,code10);
	
	}
	insert="0";

	window.location=window.location;
return false;
}