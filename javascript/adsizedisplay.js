var codesize=0;
var codeclassified=0;
function  submitclick()
{

if(document.getElementById('btnminheight').value=="")
{
alert("Please Fill The Min. Height");
document.getElementById('btnminheight').focus();
return false
}
else if(document.getElementById('btnmaxheight').value=="")
{
alert("Please Fill The Max. Height");
document.getElementById('btnmaxheight').focus();
return false;
}
else if(document.getElementById('btnminwidth').value=="")
{
alert("Please Fill The Min. Width");
document.getElementById('btnminwidth').focus();
return false;
}
else if(document.getElementById('btnmaxwidth').value=="")
{
alert("Please Fill The Max. Width");
document.getElementById('btnmaxwidth').focus();
return false;
}

var minheight=document.getElementById('btnminheight').value;
var maxheight=document.getElementById('btnmaxheight').value;
var minwidth=document.getElementById('btnminwidth').value;
var maxwidth=document.getElementById('btnmaxwidth').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var sizecode=document.getElementById('hiddensizecode').value;


if(codesize == "0")
{

Dispay_Ad.insertdisplay(minheight,maxheight,minwidth,maxwidth,compcode,userid,sizecode);
}
else
{
Dispay_Ad.updatedisplay(minheight,maxheight,minwidth,maxwidth,compcode,userid,sizecode,codesize);
codesize=0;
}

window.location=window.location;

return false;

}
function selectclick()
{

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var sizecode=document.getElementById('hiddensizecode').value;

var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	codesize=document.getElementById(str).value;
	
	}
	}
	if(k==1)
	{
	document.getElementById('btndelete').disabled=false; 
	
	Dispay_Ad.selectdisplay(compcode,userid,sizecode,codesize,call_select);
	return false;
	
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return false;
	}
	return false;


}

function call_select(response)
{
var ds=response.value;

document.getElementById('btnminheight').value=ds.Tables[0].Rows[0].min_height;
document.getElementById('btnmaxheight').value=ds.Tables[0].Rows[0].max_height;
document.getElementById('btnminwidth').value=ds.Tables[0].Rows[0].min_width;
document.getElementById('btnmaxwidth').value=ds.Tables[0].Rows[0].max_width;


return false;

}

function deleteclick()

{

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var sizecode=document.getElementById('hiddensizecode').value;


var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	
	}
	}
	if(k==1)
	{
	Dispay_Ad.deletedisplay(compcode,userid,sizecode,codesize);
	codesize=0;
	document.getElementById('btndelete').disabled=true; 
	
	window.location=window.location;
	return false;
	
	}
	else
	{
	alert("You Can Select One Row To Delete");
	return false;
	}
	
	
	return false;

}

//classified pop up

function submitclassified()
{
var fromline=document.getElementById('txtfromline').value;
var toline=document.getElementById('txttoline').value;
var maxcharacter=document.getElementById('txtcharacter').value;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var sizecode=document.getElementById('hiddensizecode').value;

if(codeclassified=="0")
{
Classified_Ad.insertclassified(fromline,toline,maxcharacter,compcode,userid,sizecode);


}
else
{
Classified_Ad.updateclassified(fromline,toline,maxcharacter,compcode,userid,sizecode,codeclassified);
codeclassified=0;



}
window.location=window.location;
return false;
}
function selectclassified()
{

var fromline=document.getElementById('txtfromline').value;
var toline=document.getElementById('txttoline').value;
var maxcharacter=document.getElementById('txtcharacter').value;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var sizecode=document.getElementById('hiddensizecode').value;
var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	//var str="DataGrid1__ctl"+(j+1)+"_CheckBox1";
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	codeclassified=document.getElementById(str).value;
	
	}
	}
	if(k==1)
	{
	document.getElementById('btndelete').disabled=false; 
	
	Classified_Ad.selectclassified(compcode,userid,codeclassified,call_classified);
	return false;
	
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return false;
	}
	return false;

}

function call_classified(response)
{
var ds=response.value;
document.getElementById('txtfromline').value=ds.Tables[0].Rows[0].from_line;
document.getElementById('txttoline').value=ds.Tables[0].Rows[0].to_line;
document.getElementById('txtcharacter').value=ds.Tables[0].Rows[0].max_character;

return false;

}

function deleteclassified()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var j;
var k=0;
//var DataGrid1__ctl_CheckBox1= new Array();
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	//alert(str);
//	alert(document.getElementById(str));

	if(document.getElementById(str).checked==true)
	{
	k=k+1;
	
	}
	}
	if(k==1)
	{
	Classified_Ad.deleteclassify(compcode,userid,codeclassified);
	codeclassified=0;
	document.getElementById('btndelete').disabled=true; 
	
	window.location=window.location;
	return false;
	
	}
	else
	{
	alert("You Can Select One Row To Delete");
	return false;
	}
	
	
	return false;

}