
var show="0";
/*Genric Library for Master Priviledges*/

//Get Permission is used to retrieve the current permission level of the form
var z=0;
var currenttime = new Date();

//'<!--#config timefmt="%B %d, %Y %H:%M:%S"--><!--#echo var="DATE_LOCAL" -->' //SSI method of getting server date
//var currenttime = '<? print date("F d, Y H:i:s", time())?>' //PHP method of getting server date

///////////Stop editting here/////////////////////////////////

var montharray=new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec")
var serverdate=new Date(currenttime)

function padlength(what){
var output=(what.toString().length==1)? "0"+what : what
return output
}

function displaytime()
{
	serverdate.setSeconds(serverdate.getSeconds()+1)
	var comp_="";
	var admin_="";
	var username = document.getElementById('hiddenusername').value;
	
	
	var datestring=montharray[serverdate.getMonth()]+" "+padlength(serverdate.getDate())+", "+serverdate.getFullYear()
	var timestring=padlength(serverdate.getHours())+":"+padlength(serverdate.getMinutes())+":"+padlength(serverdate.getSeconds())
	document.getElementById("tP1").innerHTML= "<br>"+username+": "+datestring+" "+timestring
	//document.getElementById("tP1").innerHTML= "<br>:&nbsp"+ datestring+" "+timestring
	
}

function Clock()
{
	setInterval("displaytime()", 1000);
	
	//getPermission(ClientMaster);
}


function ChangeCss()
{
	if(navigator.appName.indexOf("Microsoft")!=-1)
	{
		document.writeln('<LINK href ="css/main.css" type= "text/css" rel = "stylesheet">');
	}
	else
	{
		document.writeln('<LINK href ="css/main_mozilla.css" type= "text/css" rel = "stylesheet">');
	}
}

//window.onload=function(){
//setInterval("displaytime()", 1000)
//}

function EnableAdBooking(formname)
{
	//document.getElementById('1').style.visibility="visible";
//	document.getElementById('2').style.visibility="visible";
	
	//document.getElementById('Topbar1_lbldisplay').style.color = "red";
	window.open(''+formname+'.aspx','','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
	return false;
}


var FlagStatus;
function getPermission(formname)
{

	var userid = document.getElementById('hiddenuserid').value;
	var compcode = document.getElementById('hiddencompcode').value;
	//ClientMaster.submitpermission(compcode,userid,formname,getPermission_CallBack);
	UOM.submitpermission(compcode,userid,formname,getPermission_CallBack);
	
	return false;
}


//Get Permission CallBack
function getPermission_CallBack(response)
{


	var ds = response.value;
	
	if(ds.Tables[0].Rows.length>0)
	{
		var id = ds.Tables[0].Rows[0].button_id;
		
		if(id=="0"||id=="8")
		{
			document.getElementById('bdy').style.visibility="hidden";
			
			FlagStatus = 0;
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=true;		
			document.getElementById('btnExit').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnModify').disabled=true;	
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('Topbar1_lbldisplay').style.visibility="hidden";
			document.getElementById('Topbar1_Label3').style.visibility="hidden";
			document.getElementById('Topbar1_Label4').style.visibility="hidden";
			document.getElementById('Topbar1_Label5').style.visibility="hidden";
			document.getElementById('Topbar1_Label2').style.visibility="hidden";
			
		
			window.location.href = 'EnterPage.aspx';
			alert("You Are Not Authorised To See This Form");
			FlagStatus = 0;
			return false;
					
		}
		if(id=="1"||id=="9")
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			FlagStatus = 1;
			return false;
		}
		if(id=="2"||id=="10")
		{
			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnModify').disabled=true;
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;	
			FlagStatus = 2;
			return false;
			
		}
		if(id=="3"||id=="11")
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			document.getElementById('btnDelete').disabled=true;
			
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
						
			
			FlagStatus = 3;
			return false;

		}
		if(id=="4"||id=="12" )
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
			
			
			FlagStatus = 4;
			return false;
		}
		if(id=="5" ||id=="13")
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			FlagStatus = 5;
			return false;
			
		}
		if(id=="6"||id=="14")
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			FlagStatus = 6;
			return false;
		}
		if(id=="7"||id=="15")
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			FlagStatus = 7;
			return false;
		}
	}
	else
	{
		alert("Please Register your form for Administrator only");
		return false;
	}
	return false;
}



//Set Permission is used to Update/Change the current permission level of the form
function setPermission(formname)
{
	var userid = document.getElementById('hiddenuserid').value;
	var compcode = document.getElementById('hiddencompcode').value;
	Master.MasterPrev(userid,compcode,formname);
	return false;
}


function chkstatus(FlagStatus)
{
	if(FlagStatus==0||FlagStatus==8)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnSave').disabled=true;	
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=true;	
			alert("You Are Not Authorised To See This Form");
			return false;
					
		}
		if(FlagStatus==1||FlagStatus==9)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnSave').disabled=false;	
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;		
			return false;
		}
		if(FlagStatus==2||FlagStatus==10)
		{
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnExit').disabled=false;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;	
			return false;
		
		}
		
		if(FlagStatus==3||FlagStatus==11)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		
		if(FlagStatus==4||FlagStatus==12)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==5||FlagStatus==13)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==6||FlagStatus==14)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==7||FlagStatus==15)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
	return false;
}


/*-----------------------------Client Master coding starts-------------------------- */


function ClientExit(formname)
{
	if(confirm("Do You Want To Skip This Page"))
		{
		
			if(typeof(paywind)!="undefined")
				{
				paywind.close();
				}
				if(typeof(statuswind)!="undefined")
				{
				statuswind.close();
				}
				if(typeof(contwind)!="undefined")
				{
				contwind.close();
				}
		window.location.href='enterpage.aspx';
		return false;
		}
	
	return false;
}

function NewClick(formname)
{
	show="1";
	ValidateStatus="1";
	document.getElementById('txtstatus1').style.visibility = "hidden";
	document.getElementById('txtstatusdate').style.visibility = "hidden";
	document.getElementById('Status').style.visibility="hidden";
	document.getElementById('StatusDate').style.visibility="hidden";
	
	document.getElementById('txtcustcode').disabled=false;			
	document.getElementById('txtcustomername').disabled=false;			
	document.getElementById('txtalias').disabled=false;		
	document.getElementById('txtadd1').disabled=false;					
	document.getElementById('txtstreet').disabled=false;			
	document.getElementById('drpcity').disabled=false;			
	document.getElementById('txtdistrict').disabled=false;				
	document.getElementById('txtcountry').disabled=false;					
	document.getElementById('txtphone1').disabled=false;			
	document.getElementById('txtphone2').disabled=false;			
	document.getElementById('txtemailid').disabled=false;		
	document.getElementById('txtUrl').disabled=false;					
	document.getElementById('txtvts').disabled=false;			
	document.getElementById('txtservicetax').disabled=false;			
	document.getElementById('txtPan').disabled=false;	
	document.getElementById('txtcreditdays').disabled=false;					
	document.getElementById('txtstatusreason').disabled=false;			
	document.getElementById('drpzone').disabled=false;					
	document.getElementById('drpregion').disabled=false;			
	
	
	document.getElementById('txtalert').disabled=false;		
	document.getElementById('txtpincode').disabled=false;					
	document.getElementById('txtstate').disabled=false;			
	document.getElementById('txtfax').disabled=false;			
	

	document.getElementById('txtstatus1').visible=false;			
	document.getElementById('txtstatusdate').visible=false;	



	document.getElementById('txtcustcode').value="";
	document.getElementById('txtcustomername').value="";			
	document.getElementById('txtalias').value="";		
	document.getElementById('txtadd1').value="";					
	document.getElementById('txtstreet').value="";			
	document.getElementById('drpcity').value=0;			
	document.getElementById('txtdistrict').value="";				
	document.getElementById('txtcountry').value="0";					
	document.getElementById('txtphone1').value="";			
	document.getElementById('txtphone2').value="";			
	document.getElementById('txtemailid').value="";		
	document.getElementById('txtUrl').value="";					
	document.getElementById('txtvts').value="";			
	document.getElementById('txtservicetax').value="";			
	document.getElementById('txtPan').value="";	
	document.getElementById('txtcreditdays').value="";					
	document.getElementById('txtstatusreason').value="";			
	document.getElementById('txtstatus1').value="";			
	document.getElementById('txtalert').value="";		
	document.getElementById('txtpincode').value="";					
	document.getElementById('txtstate').value="";			
	document.getElementById('txtfax').value="";			
	document.getElementById('txtstatusdate').value="";							
	document.Form1.txtcustcode.focus();
	chkstatus(FlagStatus);
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	
	return false;		
			
}
var Mycustcode;
var custcodestatus;

function CancelClick(formname)
{
show="0";
ValidateStatus="0";
	var compcode=document.getElementById('hiddencompcode').value;
	custcodestatus = document.getElementById('txtcustcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	//check whether the user has been registered in retainer master or not
	//if not then delete all data in pop ups
	//or do nothing just clear the values
	//delete data from all popups
	/*if(custcodestatus =="")
	{
	
	}
	else
	{
		ClientMaster.CheckClientPopup(compcode,custcodestatus,userid,1,CheckClientUser_CallBack);
	}*/
	
	document.getElementById('btnSave').disabled = true;
	document.getElementById('txtcustcode').disabled=true;			
	document.getElementById('txtcustomername').disabled=true;			
	document.getElementById('txtalias').disabled=true;		
	document.getElementById('txtadd1').disabled=true;					
	document.getElementById('txtstreet').disabled=true;			
	document.getElementById('drpcity').disabled=true;			
	document.getElementById('txtdistrict').disabled=true;				
	document.getElementById('txtcountry').disabled=true;					
	document.getElementById('txtphone1').disabled=true;			
	document.getElementById('txtphone2').disabled=true;			
	document.getElementById('txtemailid').disabled=true;		
	document.getElementById('txtUrl').disabled=true;					
	document.getElementById('txtvts').disabled=true;			
	document.getElementById('txtservicetax').disabled=true;			
	document.getElementById('txtPan').disabled=true;	
	document.getElementById('txtcreditdays').disabled=true;					
	document.getElementById('txtstatusreason').disabled=true;			
	document.getElementById('txtstatus1').disabled=true;			
	document.getElementById('txtalert').disabled=true;		
	document.getElementById('txtpincode').disabled=true;					
	document.getElementById('txtstate').disabled=true;			
	document.getElementById('txtfax').disabled=true;			
	document.getElementById('txtstatusdate').disabled=true;		
	document.getElementById('drptaluka').disabled=true;
	document.getElementById('txtcrlimit').disabled=true;
	document.getElementById('txtcustcode').value="";
	document.getElementById('txtcustomername').value="";			
	document.getElementById('txtalias').value="";		
	document.getElementById('txtadd1').value="";					
	document.getElementById('txtstreet').value="";			
	document.getElementById('drpcity').value=0;			
	document.getElementById('txtdistrict').value="";				
	document.getElementById('txtcountry').value="0";					
	document.getElementById('txtphone1').value="";			
	document.getElementById('txtphone2').value="";			
	document.getElementById('txtemailid').value="";		
	document.getElementById('txtUrl').value="";					
	document.getElementById('txtvts').value="";			
	document.getElementById('txtservicetax').value="";			
	document.getElementById('txtPan').value="";	
	document.getElementById('txtcreditdays').value="";					
	document.getElementById('txtstatusreason').value="";			
	document.getElementById('txtstatus1').value="";			
	document.getElementById('txtalert').value="";		
	document.getElementById('txtpincode').value="";					
	document.getElementById('txtstate').value="";			
	document.getElementById('txtfax').value="";			
	document.getElementById('txtstatusdate').value="";						
	document.getElementById('modify').value="";
	document.getElementById('drptaluka').options.length=0;
	document.getElementById('txtcrlimit').value="";
	//getPermission(formname);
	givebuttonpermission(formname);
	return false;
}
function CheckClientUser_CallBack(response)
{
	var ds = response.value;
	if(ds.Tables[0].Rows.length==0)
	{
	var compcode=document.getElementById('hiddencompcode').value;
	custcodestatus = document.getElementById('txtcustcode').value;
	var userid=document.getElementById('hiddenuserid').value;
		ClientMaster.ClientDelete(compcode,custcodestatus,userid);
		return false;
	}
	return false;		
}

function QueryClick(formname)
{
show="0";
z=0;
	document.getElementById('txtcustcode').disabled=false;
	document.getElementById('txtcustomername').disabled=false;			
	document.getElementById('txtalias').disabled=false;		
	document.getElementById('txtadd1').disabled=true;					
	document.getElementById('txtstreet').disabled=true;			
	document.getElementById('drpcity').disabled=false;			
	document.getElementById('txtdistrict').disabled=true;				
	document.getElementById('txtcountry').disabled=true;					
	document.getElementById('txtphone1').disabled=true;			
	document.getElementById('txtphone2').disabled=true;			
	document.getElementById('txtemailid').disabled=true;		
	document.getElementById('txtUrl').disabled=true;					
	document.getElementById('txtvts').disabled=true;			
	document.getElementById('txtservicetax').disabled=true;			
	document.getElementById('txtPan').disabled=true;	
	document.getElementById('txtcreditdays').disabled=true;					
	document.getElementById('txtstatusreason').disabled=true;			
	document.getElementById('txtstatus1').disabled=false;			
	document.getElementById('txtalert').disabled=true;		
	document.getElementById('txtpincode').disabled=true;					
	document.getElementById('txtstate').disabled=true;			
	document.getElementById('txtfax').disabled=true;			
	document.getElementById('txtstatusdate').disabled=true;	


	document.getElementById('txtcustcode').value="";
	document.getElementById('txtcustomername').value="";			
	document.getElementById('txtalias').value="";		
	document.getElementById('txtadd1').value="";					
	document.getElementById('txtstreet').value="";			
	document.getElementById('drpcity').value="0";			
	document.getElementById('txtdistrict').value="";				
	document.getElementById('txtcountry').value="0";					
	document.getElementById('txtphone1').value="";			
	document.getElementById('txtphone2').value="";			
	document.getElementById('txtemailid').value="";		
	document.getElementById('txtUrl').value="";					
	document.getElementById('txtvts').value="";			
	document.getElementById('txtservicetax').value="";			
	document.getElementById('txtPan').value="";	
	document.getElementById('txtcreditdays').value="";					
	document.getElementById('txtstatusreason').value="";			
	document.getElementById('txtstatus1').value="";			
	document.getElementById('txtalert').value="";		
	document.getElementById('txtpincode').value="";					
	document.getElementById('txtstate').value="";			
	document.getElementById('txtfax').value="";			
	document.getElementById('txtstatusdate').value="";	
	document.getElementById('txtstatus1').style.visibility = "hidden";
	document.getElementById('txtstatusdate').style.visibility = "hidden";
	document.getElementById('Status').style.visibility="hidden";
	document.getElementById('StatusDate').style.visibility="hidden";
	document.Form1.txtcustcode.focus();
	chkstatus(FlagStatus);
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	z=0;
	return false;
	
}

function Modify(formname)
{
show="1";
	document.getElementById('modify').value="modify";
	document.getElementById('btnSave').disabled=false;
	document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnnext').disabled=true;					
	document.getElementById('btnprevious').disabled=true;			
	document.getElementById('btnlast').disabled=true;			
	document.getElementById('btnExit').disabled=false;

	document.getElementById('txtcustcode').disabled=true;			
	document.getElementById('txtcustomername').disabled=false;			
	document.getElementById('txtalias').disabled=false;		
	document.getElementById('txtadd1').disabled=false;					
	document.getElementById('txtstreet').disabled=false;			
	document.getElementById('drpcity').disabled=false;			
	document.getElementById('txtdistrict').disabled=false;				
	document.getElementById('txtcountry').disabled=false;					
	document.getElementById('txtphone1').disabled=false;			
	document.getElementById('txtphone2').disabled=false;			
	document.getElementById('txtemailid').disabled=false;		
	document.getElementById('txtUrl').disabled=false;					
	document.getElementById('txtvts').disabled=false;			
	document.getElementById('txtservicetax').disabled=false;			
	document.getElementById('txtPan').disabled=false;	
	document.getElementById('txtcreditdays').disabled=false;					
	document.getElementById('txtstatusreason').disabled=false;			
	document.getElementById('txtstatus1').disabled=false;			
	document.getElementById('txtalert').disabled=false;		
	document.getElementById('txtpincode').disabled=false;					
	document.getElementById('txtstate').disabled=false;			
	document.getElementById('txtfax').disabled=false;			
	document.getElementById('txtstatusdate').disabled=false;	
	document.getElementById('btnDelete').disabled=true;	
	document.getElementById('btnQuery').disabled=true
	chkstatus(FlagStatus);
	document.getElementById('btnSave').disabled = false;
	flag=1;
	return false;
}


function clickexecute(formname)
{
	
	var compcode=document.getElementById('hiddencompcode').value;
	var custcode=document.getElementById('txtcustcode').value;
	var custname=document.getElementById('txtcustomername').value;
	var alias=document.getElementById('txtalias').value;
	var city=document.getElementById('drpcity').value;
	var status1=document.getElementById('txtstatus1').value;
	var userid=document.getElementById('hiddenuserid').value;
	ClientMaster.clientexecute(compcode,custcode,custname,alias,city,status1,userid,call_clientexecute12);
	chkstatus(FlagStatus);
	
	
	if(FlagStatus==2||FlagStatus==3||FlagStatus==6)
	{
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnModify').disabled=false;
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=true;			
		document.getElementById('btnlast').disabled=false;	
		
	}
	if(FlagStatus==4)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=true;			
		document.getElementById('btnlast').disabled=false;	
		
	}
	if(FlagStatus==5)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=true;			
		document.getElementById('btnlast').disabled=false;	
		
	}
	if(FlagStatus==6||FlagStatus==7)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=false;
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=true;			
		document.getElementById('btnlast').disabled=false;	
		
	}
	
	return false;
	
}

function call_clientexecute12(response)
{
	var ds=response.value;
	if(ds.value==""||ds.value=="Undefined"||ds.Tables[0].Rows.length==0)
	{
	CancelClick('ClientMaster');
		alert("Your Search Criteria Does not Produce Any Search");
		document.getElementById('txtcustcode').value="";
		document.getElementById('txtcustomername').value="";			
		document.getElementById('txtalias').value="";		
		document.getElementById('txtadd1').value="";					
		document.getElementById('txtstreet').value="";			
		//document.getElementById('drpcity').value=0;			
		document.getElementById('txtdistrict').value="";				
		document.getElementById('txtcountry').value="0";					
		document.getElementById('txtphone1').value="";			
		document.getElementById('txtphone2').value="";			
		document.getElementById('txtemailid').value="";		
		document.getElementById('txtUrl').value="";					
		document.getElementById('txtvts').value="";			
		document.getElementById('txtservicetax').value="";			
		document.getElementById('txtPan').value="";	
		document.getElementById('txtcreditdays').value="";					
		document.getElementById('txtstatusreason').value="";			
		document.getElementById('txtstatus1').value="";			
		document.getElementById('txtalert').value="";		
		document.getElementById('txtpincode').value="";					
		document.getElementById('txtstate').value="";			
		document.getElementById('txtfax').value="";			
		document.getElementById('txtstatusdate').value="";	
			
		document.getElementById('txtcustcode').disabled=true;
		document.getElementById('txtcustomername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;			
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtUrl').disabled=true;					
		document.getElementById('txtvts').disabled=true;			
		document.getElementById('txtservicetax').disabled=true;			
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtstatusreason').disabled=true;			
		document.getElementById('txtstatus1').disabled=true;			
		document.getElementById('txtalert').disabled=true;		
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;			
		document.getElementById('txtfax').disabled=true;			
		document.getElementById('txtstatusdate').disabled=true;	
		
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		
		return false;
	}
	
	if(ds.Tables[0].Rows.length>0)
	{	
		document.getElementById('txtcustcode').value=ds.Tables[0].Rows[0].Cust_Code;
		document.getElementById('txtcustomername').value=ds.Tables[0].Rows[0].Cust_Name;
		document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Cust_Alias;
		
		document.getElementById('txtstreet').value=ds.Tables[0].Rows[0].Stree;
		document.getElementById('txtpincode').value=ds.Tables[0].Rows[0].Zip;
		document.getElementById('txtphone1').value=ds.Tables[0].Rows[0].phone1; 
		document.getElementById('txtphone2').value=ds.Tables[0].Rows[0].Phone2;
		document.getElementById('txtfax').value=ds.Tables[0].Rows[0].Fax;
		//No_of_VTS
		document.getElementById('txtvts').value=ds.Tables[0].Rows[0].No_of_VTS;
		document.getElementById('txtemailid').value=ds.Tables[0].Rows[0].EmailID;
		document.getElementById('txtUrl').value=ds.Tables[0].Rows[0].URL;
		document.getElementById('txtservicetax').value=ds.Tables[0].Rows[0].ST_ACC_No;
		document.getElementById('txtPan').value=ds.Tables[0].Rows[0].PAN_No;
		document.getElementById('txtcreditdays').value=ds.Tables[0].Rows[0].Credit_Days;
		  
		document.getElementById('txtstatusreason').value=ds.Tables[0].Rows[0].Status_Reason;
		//alert(ds.Tables[0].Rows[0].Country_code);
		document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].Country_code;
		cityvar=ds.Tables[0].Rows[0].City_Code;
			addcount(ds.Tables[0].Rows[0].City_Code);
			
			
			document.getElementById('txtstate').value=ds.Tables[0].Rows[0].State_code;
			document.getElementById('txtdistrict').value=ds.Tables[0].Rows[0].Dist_code;
			//addregcity();
			document.getElementById('drpzone').value=ds.Tables[0].Rows[0].Zone_code;
		document.getElementById('drpregion').value=ds.Tables[0].Rows[0].Region_code;
		document.getElementById('txtcrlimit').value=ds.Tables[0].Rows[0].Credit_limit;
		
		document.getElementById('txtstatus1').style.visibility = "hidden";
		document.getElementById('txtstatusdate').style.visibility = "hidden";
		document.getElementById('Status').style.visibility="hidden";
		document.getElementById('StatusDate').style.visibility="hidden";
		var dateformat=document.getElementById('hiddenDateFormat').value;
		var currentdate=ds.Tables[0].Rows[0].Creation_Datetime;
		var dd=currentdate.getDate();
		var mm=currentdate.getMonth() + 1;
		var yyyy=currentdate.getFullYear();
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
		var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="mm/dd/yyyy")
		{
		var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		else if (dateformat=="dd/mm/yyyy")
		{
		var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
		var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		
		
		
		var todate=ds.Tables[0].Rows[0].To_date;
		var dd=todate.getDate();
		var mm=todate.getMonth() + 1;
		var yyyy=todate.getFullYear();
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
		var todate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="mm/dd/yyyy")
		{
		var todate1=mm+'/'+dd+'/'+yyyy;
		}
		else if (dateformat=="dd/mm/yyyy")
		{
		var todate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
		var todate1=mm+'/'+dd+'/'+yyyy;
		}
				
		
	
		
		document.getElementById('txtstatusdate').value = currentdate1;
		document.getElementById('txtalert').value=ds.Tables[0].Rows[0].Remarks;
		document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[0].UserId;
		document.getElementById('txtadd1').value=ds.Tables[0].Rows[0].Add1;
		document.getElementById('txtstatus1').style.visibility = "visible";
		document.getElementById('txtstatusdate').style.visibility = "visible";
		document.getElementById('Status').style.visibility="visible";
		document.getElementById('StatusDate').style.visibility="visible";
		
		var tdate=new Date(todate1);
		var cdate= new Date(currentdate1);
		if(cdate>tdate)
		{
		document.getElementById('txtstatus1').value="Banned"
		}
		else
		{
		document.getElementById('txtstatus1').value=ds.Tables[0].Rows[0].Cust_Status;
		}
		document.getElementById('txtcustcode').disabled=true;
		document.getElementById('txtcustomername').disabled=true;			
		document.getElementById('txtalias').disabled=true;		
		document.getElementById('txtadd1').disabled=true;					
		document.getElementById('txtstreet').disabled=true;			
		document.getElementById('drpcity').disabled=true;			
		document.getElementById('txtdistrict').disabled=true;				
		document.getElementById('txtcountry').disabled=true;					
		document.getElementById('txtphone1').disabled=true;			
		document.getElementById('txtphone2').disabled=true;			
		document.getElementById('txtemailid').disabled=true;		
		document.getElementById('txtUrl').disabled=true;					
		document.getElementById('txtvts').disabled=true;			
		document.getElementById('txtservicetax').disabled=true;			
		document.getElementById('txtPan').disabled=true;	
		document.getElementById('txtcreditdays').disabled=true;					
		document.getElementById('txtstatusreason').disabled=true;			
		document.getElementById('txtstatus1').disabled=true;			
		document.getElementById('txtalert').disabled=true;		
		document.getElementById('txtpincode').disabled=true;					
		document.getElementById('txtstate').disabled=true;			
		document.getElementById('txtfax').disabled=true;			
		document.getElementById('txtstatusdate').disabled=true;	
	}
	document.getElementById('btnfirst').disabled=true;				
					
		document.getElementById('btnprevious').disabled=true;			
		
	return false;

}


function clientaddcode1(response)
{
	var ds=response.value;
	if(ds.Tables[1].Rows.length>0 || ds.Tables[2].Rows.length>0 || ds.Tables[0].Rows.length>0)
	{
		document.getElementById('drpcity').value=ds.Tables[3].Rows[0].City_Name;
		document.getElementById('txtdistrict').value=ds.Tables[1].Rows[0].dist_name;
		document.getElementById('txtstate').value=ds.Tables[2].Rows[0].state_name;
		document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].country_name;
		document.getElementById('txtdistrict').disabled=true;
		document.getElementById('txtstate').disabled=true;
		document.getElementById('txtcountry').disabled=true;
	}
	return false;
}
var z;
function ClientFirst()
{
	z=0;
	var compcode=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	var custcode=document.getElementById('txtcustcode').value;
	
	ClientMaster.first(compcode,userid,custcode,ClientFirst_CallBack);
	return false;
}

//Function  CallBack 
			
function ClientFirst_CallBack(response)
{
	var ds = response.value;
	var city=ds.Tables[0].Rows[0].City_Code;
	
	
	document.getElementById('txtcustcode').value=ds.Tables[0].Rows[0].Cust_Code;
	document.getElementById('txtcustomername').value=ds.Tables[0].Rows[0].Cust_Name;
	document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Cust_Alias;
	
	//Function  CallBack 
	
	document.getElementById('txtstreet').value=ds.Tables[0].Rows[0].Stree;
	document.getElementById('txtpincode').value=ds.Tables[0].Rows[0].Zip;
	document.getElementById('txtdistrict').value=ds.Tables[0].Rows[0].Dist_code;
	document.getElementById('txtstate').value=ds.Tables[0].Rows[0].State_code;
	document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].Country_code;
	document.getElementById('txtphone1').value=ds.Tables[0].Rows[0].phone1; 
	document.getElementById('txtphone2').value=ds.Tables[0].Rows[0].Phone2;
	document.getElementById('txtfax').value=ds.Tables[0].Rows[0].Fax;
	document.getElementById('txtvts').value=ds.Tables[0].Rows[0].No_of_VTS;
	document.getElementById('txtemailid').value=ds.Tables[0].Rows[0].EmailID;
	document.getElementById('txtUrl').value=ds.Tables[0].Rows[0].URL;
	document.getElementById('txtservicetax').value=ds.Tables[0].Rows[0].ST_ACC_No;
	document.getElementById('txtPan').value=ds.Tables[0].Rows[0].PAN_No;
	document.getElementById('txtcreditdays').value=ds.Tables[0].Rows[0].Credit_Days;
	document.getElementById('txtstatus1').value=ds.Tables[0].Rows[0].Cust_Status;
	document.getElementById('txtstatusreason').value=ds.Tables[0].Rows[0].Status_Reason;
	document.getElementById('txtalert').value=ds.Tables[0].Rows[0].Remarks;
	document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[0].UserId;
	document.getElementById('txtadd1').value=ds.Tables[0].Rows[0].Add1;
	
	document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].Country_code;
		cityvar=ds.Tables[0].Rows[0].City_Code;
			addcount(ds.Tables[0].Rows[0].City_Code);
			
			document.getElementById('drpzone').value=ds.Tables[0].Rows[0].Zone_code;
		document.getElementById('drpregion').value=ds.Tables[0].Rows[0].Region_code;
		document.getElementById('txtcrlimit').value=ds.Tables[0].Rows[0].Credit_limit;
	
	
	var dateformat=document.getElementById('hiddenDateFormat').value;
		var currentdate=ds.Tables[0].Rows[0].Creation_Datetime;
		var dd=currentdate.getDate();
		var mm=currentdate.getMonth() + 1;
		var yyyy=currentdate.getFullYear();
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
		var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="mm/dd/yyyy")
		{
		var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		else if (dateformat=="dd/mm/yyyy")
		{
		var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
		var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		
		
		
		var todate=ds.Tables[0].Rows[0].To_date;
		var dd=todate.getDate();
		var mm=todate.getMonth() + 1;
		var yyyy=todate.getFullYear();
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
		var todate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="mm/dd/yyyy")
		{
		var todate1=mm+'/'+dd+'/'+yyyy;
		}
		else if (dateformat=="dd/mm/yyyy")
		{
		var todate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
		var todate1=mm+'/'+dd+'/'+yyyy;
		}
				
		
	
		
		document.getElementById('txtstatusdate').value = currentdate1;
		document.getElementById('txtalert').value=ds.Tables[0].Rows[0].Remarks;
		document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[0].UserId;
		document.getElementById('txtadd1').value=ds.Tables[0].Rows[0].Add1;
		document.getElementById('txtstatus1').style.visibility = "visible";
		document.getElementById('txtstatusdate').style.visibility = "visible";
		document.getElementById('Status').style.visibility="visible";
		document.getElementById('StatusDate').style.visibility="visible";
		
		var tdate=new Date(todate1);
		var cdate= new Date(currentdate1);
		if(cdate>tdate)
		{
		document.getElementById('txtstatus1').value="Banned"
		}
		else
		{
		document.getElementById('txtstatus1').value=ds.Tables[0].Rows[0].Cust_Status;
		}
	
	//Disabled Fields
	
	document.getElementById('txtcustcode').disabled=true;
	document.getElementById('txtcustomername').disabled=true;			
	document.getElementById('txtalias').disabled=true;		
	document.getElementById('txtadd1').disabled=true;					
	document.getElementById('txtstreet').disabled=true;			
	document.getElementById('drpcity').disabled=true;			
	document.getElementById('txtdistrict').disabled=true;				
	document.getElementById('txtcountry').disabled=true;					
	document.getElementById('txtphone1').disabled=true;			
	document.getElementById('txtphone2').disabled=true;			
	document.getElementById('txtemailid').disabled=true;		
	document.getElementById('txtUrl').disabled=true;					
	document.getElementById('txtvts').disabled=true;			
	document.getElementById('txtservicetax').disabled=true;			
	document.getElementById('txtPan').disabled=true;	
	document.getElementById('txtcreditdays').disabled=true;					
	document.getElementById('txtstatusreason').disabled=true;			
	document.getElementById('txtstatus1').disabled=true;			
	document.getElementById('txtalert').disabled=true;		
	document.getElementById('txtpincode').disabled=true;					
	document.getElementById('txtstate').disabled=true;			
	document.getElementById('txtfax').disabled=true;			
	document.getElementById('txtstatusdate').disabled=true;	
	
	//ToolBar Disabled Status
	
	chkstatus(FlagStatus);	
	if(FlagStatus==2||FlagStatus==3||FlagStatus==6)
	{
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnModify').disabled=false;
		
	}
	if(FlagStatus==4)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		
	}
	if(FlagStatus==5)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		
	}
	if(FlagStatus==6||FlagStatus==7)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=false;
		
	}
	
		
	
	document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnnext').disabled=false;					
	document.getElementById('btnprevious').disabled=true;			
	document.getElementById('btnlast').disabled=false;			
	
	document.getElementById('btnExit').disabled=false;	
	
	return false;
	
}

function ClientNext()
{
	var Comp_Code=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	var Client_Code=document.getElementById('txtcustcode').value;
	
	ClientMaster.next(Comp_Code,userid,Client_Code,ClientNext_CallBack);
	return false;
}

//Function  CallBack 
			
function ClientNext_CallBack(response)
{
	z++;
	//alert(z);
	var ds = response.value;
	var y=ds.Tables[0].Rows.length;
		
	if(z <= y && z !=-1)
	{
		if(ds.Tables[0].Rows.length != z && z >= 0)
		{
			var city=ds.Tables[0].Rows[z].City_Code;
			
			document.getElementById('txtcustcode').value=ds.Tables[0].Rows[z].Cust_Code;
			document.getElementById('txtcustomername').value=ds.Tables[0].Rows[z].Cust_Name;
			document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Cust_Alias;
			//document.getElementById('drpcity').value=ds.Tables[0].Rows[z].City_Code;
			
			//Function  CallBack 
		//	ClientMaster.addcity(city,clientaddcode1);
			
			document.getElementById('txtstreet').value=ds.Tables[0].Rows[z].Stree;
			//document.getElementById('txtcountry').value=ds.Tables[0].Rows[z].country_code;
			document.getElementById('txtpincode').value=ds.Tables[0].Rows[z].Zip;
			document.getElementById('txtdistrict').value=ds.Tables[0].Rows[z].Dist_code;
			document.getElementById('txtstate').value=ds.Tables[0].Rows[z].State_code;
			document.getElementById('txtcountry').value=ds.Tables[0].Rows[z].Country_code;
			document.getElementById('txtphone1').value=ds.Tables[0].Rows[z].phone1; 
			document.getElementById('txtphone2').value=ds.Tables[0].Rows[z].Phone2;
			
			document.getElementById('txtfax').value=ds.Tables[0].Rows[z].Fax;
			document.getElementById('txtvts').value=ds.Tables[0].Rows[z].No_of_VTS;
			document.getElementById('txtemailid').value=ds.Tables[0].Rows[z].EmailID;
			document.getElementById('txtUrl').value=ds.Tables[0].Rows[z].URL;
			document.getElementById('txtservicetax').value=ds.Tables[0].Rows[z].ST_ACC_No;
			document.getElementById('txtPan').value=ds.Tables[0].Rows[z].PAN_No;
			document.getElementById('txtcreditdays').value=ds.Tables[0].Rows[z].Credit_Days;
			document.getElementById('txtstatus1').value=ds.Tables[0].Rows[z].Cust_Status;
			document.getElementById('txtstatusreason').value=ds.Tables[0].Rows[z].Status_Reason;
			document.getElementById('txtalert').value=ds.Tables[0].Rows[z].Remarks;
			document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[z].UserId;
			document.getElementById('txtadd1').value=ds.Tables[0].Rows[z].Add1;
			
			document.getElementById('txtcountry').value=ds.Tables[0].Rows[z].Country_code;
		cityvar=ds.Tables[0].Rows[z].City_Code;
			addcount(ds.Tables[0].Rows[z].City_Code);
			
			document.getElementById('drpzone').value=ds.Tables[0].Rows[z].Zone_code;
		document.getElementById('drpregion').value=ds.Tables[0].Rows[z].Region_code;
		document.getElementById('txtcrlimit').value=ds.Tables[0].Rows[z].Credit_limit;
		
			var dateformat=document.getElementById('hiddenDateFormat').value;
			var currentdate=ds.Tables[0].Rows[z].Creation_Datetime;
			var dd=currentdate.getDate();
			var mm=currentdate.getMonth() + 1;
			var yyyy=currentdate.getFullYear();
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="yyyy/mm/dd")
			{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
			} 
			else if (dateformat=="mm/dd/yyyy")
			{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
			}
			else if (dateformat=="dd/mm/yyyy")
			{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
			}
			else
			{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
			}
			
			
			
			var todate=ds.Tables[0].Rows[z].To_date;
			var dd=todate.getDate();
			var mm=todate.getMonth() + 1;
			var yyyy=todate.getFullYear();
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="yyyy/mm/dd")
			{
			var todate1=yyyy+'/'+mm+'/'+dd;
			} 
			else if (dateformat=="mm/dd/yyyy")
			{
			var todate1=mm+'/'+dd+'/'+yyyy;
			}
			else if (dateformat=="dd/mm/yyyy")
			{
			var todate1=dd+'/'+mm+'/'+yyyy;
			}
			else
			{
			var todate1=mm+'/'+dd+'/'+yyyy;
			}
					
			
		
			
			document.getElementById('txtstatusdate').value = currentdate1;
			document.getElementById('txtalert').value=ds.Tables[0].Rows[z].Remarks;
			document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[z].UserId;
			document.getElementById('txtadd1').value=ds.Tables[0].Rows[z].Add1;
			document.getElementById('txtstatus1').style.visibility = "visible";
			document.getElementById('txtstatusdate').style.visibility = "visible";
			document.getElementById('Status').style.visibility="visible";
			document.getElementById('StatusDate').style.visibility="visible";
			
			var tdate=new Date(todate1);
			var cdate= new Date(currentdate1);
			if(cdate>tdate)
			{
			document.getElementById('txtstatus1').value="Banned"
			}
			else
			{
			document.getElementById('txtstatus1').value=ds.Tables[0].Rows[z].Cust_Status;
			}
			
			//Disabled Fields
			
			document.getElementById('txtcustcode').disabled=true;
			document.getElementById('txtcustomername').disabled=true;			
			document.getElementById('txtalias').disabled=true;		
			document.getElementById('txtadd1').disabled=true;					
			document.getElementById('txtstreet').disabled=true;			
			document.getElementById('drpcity').disabled=true;			
			document.getElementById('txtdistrict').disabled=true;				
			document.getElementById('txtcountry').disabled=true;					
			document.getElementById('txtphone1').disabled=true;			
			document.getElementById('txtphone2').disabled=true;			
			document.getElementById('txtemailid').disabled=true;		
			document.getElementById('txtUrl').disabled=true;					
			document.getElementById('txtvts').disabled=true;			
			document.getElementById('txtservicetax').disabled=true;			
			document.getElementById('txtPan').disabled=true;	
			document.getElementById('txtcreditdays').disabled=true;					
			document.getElementById('txtstatusreason').disabled=true;			
			document.getElementById('txtstatus1').disabled=true;			
			document.getElementById('txtalert').disabled=true;		
			document.getElementById('txtpincode').disabled=true;					
			document.getElementById('txtstate').disabled=true;			
			document.getElementById('txtfax').disabled=true;			
			document.getElementById('txtstatusdate').disabled=true;	
			
			//ToolBar Disabled Status
			
			chkstatus(FlagStatus);
			if(FlagStatus==2||FlagStatus==3||FlagStatus==6)
			{
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=false;
			
			}
			if(FlagStatus==4)
			{
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnModify').disabled=true;
			
			}
			if(FlagStatus==5)
			{
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnModify').disabled=true;
				
			}
			if(FlagStatus==6||FlagStatus==7)
			{
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnModify').disabled=false;
				
			}
			
				
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=false;	
				document.getElementById('btnlast').disabled=false;			
				
				document.getElementById('btnExit').disabled=false;	
			
		}
		else
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			return false;
		
		}
	}
	else
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			return false;
		
		}
	if(z==y-1)
	{
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
	}
	return false;
}


//Previous Record Fetching Function



function ClientPrevious()
{
	
	var Comp_Code=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	var Client_Code=document.getElementById('txtcustcode').value;
	
	ClientMaster.previous(Comp_Code,userid,Client_Code,ClientPrevious_CallBack);
	return false;
}

//Function  CallBack 
			
function ClientPrevious_CallBack(response)
{
	z--;
	var ds = response.value;
	var y=ds.Tables[0].Rows.length;
	
	if(z > y)
	{
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		return false;
	}

	
	
	if(z != -1 && z >= 0 )
	{
		if(ds.Tables[0].Rows.length != z)
		
		{
			var city=ds.Tables[0].Rows[z].City_Code;
			
			document.getElementById('txtcustcode').value=ds.Tables[0].Rows[z].Cust_Code;
			document.getElementById('txtcustomername').value=ds.Tables[0].Rows[z].Cust_Name;
			document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Cust_Alias;
			
			//Function  CallBack 
			
			document.getElementById('txtstreet').value=ds.Tables[0].Rows[z].Stree;
			document.getElementById('txtpincode').value=ds.Tables[0].Rows[z].Zip;
			document.getElementById('txtdistrict').value=ds.Tables[0].Rows[z].Dist_code;
			document.getElementById('txtstate').value=ds.Tables[0].Rows[z].State_code;
			document.getElementById('txtcountry').value=ds.Tables[0].Rows[z].Country_code;
			document.getElementById('txtphone1').value=ds.Tables[0].Rows[z].phone1; 
			document.getElementById('txtphone2').value=ds.Tables[0].Rows[z].Phone2;
			document.getElementById('txtfax').value=ds.Tables[0].Rows[z].Fax;
			document.getElementById('txtvts').value=ds.Tables[0].Rows[z].No_of_VTS;
			document.getElementById('txtemailid').value=ds.Tables[0].Rows[z].EmailID;
			document.getElementById('txtUrl').value=ds.Tables[0].Rows[z].URL;
			document.getElementById('txtservicetax').value=ds.Tables[0].Rows[z].ST_ACC_No;
			document.getElementById('txtPan').value=ds.Tables[0].Rows[z].PAN_No;
			document.getElementById('txtcreditdays').value=ds.Tables[0].Rows[z].Credit_Days;
			document.getElementById('txtstatus1').value=ds.Tables[0].Rows[z].Cust_Status;
			document.getElementById('txtstatusreason').value=ds.Tables[0].Rows[z].Status_Reason;
			document.getElementById('txtalert').value=ds.Tables[0].Rows[z].Remarks;
			document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[z].UserId;
			document.getElementById('txtadd1').value=ds.Tables[0].Rows[z].Add1;
		
		
			document.getElementById('txtcountry').value=ds.Tables[0].Rows[z].Country_code;
		cityvar=ds.Tables[0].Rows[z].City_Code;
			addcount(ds.Tables[0].Rows[z].City_Code);
			
			document.getElementById('drpzone').value=ds.Tables[0].Rows[z].Zone_code;
		document.getElementById('drpregion').value=ds.Tables[0].Rows[z].Region_code;
		document.getElementById('txtcrlimit').value=ds.Tables[0].Rows[z].Credit_limit;
			
			var dateformat=document.getElementById('hiddenDateFormat').value;
			var currentdate=ds.Tables[0].Rows[z].Creation_Datetime;
			var dd=currentdate.getDate();
			var mm=currentdate.getMonth() + 1;
			var yyyy=currentdate.getFullYear();
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="yyyy/mm/dd")
			{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
			} 
			else if (dateformat=="mm/dd/yyyy")
			{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
			}
			else if (dateformat=="dd/mm/yyyy")
			{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
			}
			else
			{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
			}
			
			
			
			var todate=ds.Tables[0].Rows[z].To_date;
			var dd=todate.getDate();
			var mm=todate.getMonth() + 1;
			var yyyy=todate.getFullYear();
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="yyyy/mm/dd")
			{
			var todate1=yyyy+'/'+mm+'/'+dd;
			} 
			else if (dateformat=="mm/dd/yyyy")
			{
			var todate1=mm+'/'+dd+'/'+yyyy;
			}
			else if (dateformat=="dd/mm/yyyy")
			{
			var todate1=dd+'/'+mm+'/'+yyyy;
			}
			else
			{
			var todate1=mm+'/'+dd+'/'+yyyy;
			}
					
			
		
			
			document.getElementById('txtstatusdate').value = currentdate1;
			document.getElementById('txtalert').value=ds.Tables[0].Rows[z].Remarks;
			document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[z].UserId;
			document.getElementById('txtadd1').value=ds.Tables[0].Rows[z].Add1;
			document.getElementById('txtstatus1').style.visibility = "visible";
			document.getElementById('txtstatusdate').style.visibility = "visible";
			document.getElementById('Status').style.visibility="visible";
			document.getElementById('StatusDate').style.visibility="visible";
			
			var tdate=new Date(todate1);
			var cdate= new Date(currentdate1);
			if(cdate>tdate)
			{
			document.getElementById('txtstatus1').value="Banned"
			}
			else
			{
			document.getElementById('txtstatus1').value=ds.Tables[0].Rows[z].Cust_Status;
			}
			
			//Disabled Fields
			
			document.getElementById('txtcustcode').disabled=true;
			document.getElementById('txtcustomername').disabled=true;			
			document.getElementById('txtalias').disabled=true;		
			document.getElementById('txtadd1').disabled=true;					
			document.getElementById('txtstreet').disabled=true;			
			document.getElementById('drpcity').disabled=true;			
			document.getElementById('txtdistrict').disabled=true;				
			document.getElementById('txtcountry').disabled=true;					
			document.getElementById('txtphone1').disabled=true;			
			document.getElementById('txtphone2').disabled=true;			
			document.getElementById('txtemailid').disabled=true;		
			document.getElementById('txtUrl').disabled=true;					
			document.getElementById('txtvts').disabled=true;			
			document.getElementById('txtservicetax').disabled=true;			
			document.getElementById('txtPan').disabled=true;	
			document.getElementById('txtcreditdays').disabled=true;					
			document.getElementById('txtstatusreason').disabled=true;			
			document.getElementById('txtstatus1').disabled=true;			
			document.getElementById('txtalert').disabled=true;		
			document.getElementById('txtpincode').disabled=true;					
			document.getElementById('txtstate').disabled=true;			
			document.getElementById('txtfax').disabled=true;			
			document.getElementById('txtstatusdate').disabled=true;	
			
			//ToolBar Disabled Status
			
			chkstatus(FlagStatus);	
			if(FlagStatus==2||FlagStatus==3||FlagStatus==6)
			{
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=false;
				
			}
			if(FlagStatus==4)
			{
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnModify').disabled=true;
				
			}
			if(FlagStatus==5)
			{
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnModify').disabled=true;
				
			}
			if(FlagStatus==6||FlagStatus==7)
			{
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnModify').disabled=false;
				
			}
		
			
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
	if(z <= 0)
	{
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnprevious').disabled=true;
		return false;

	}
	return false;
	
}



//Last Record Fetching Function
function ClientLast()
{
	
	var Comp_Code=document.getElementById('hiddencompcode').value;
	var userid=document.getElementById('hiddenuserid').value;
	var Client_Code=document.getElementById('txtcustcode').value;
	
	ClientMaster.last(Comp_Code,userid,Client_Code,ClientLast_CallBack);
	return false;
}

//Function  CallBack 
			
function ClientLast_CallBack(response)
{
	var ds = response.value;
	var y=ds.Tables[0].Rows.length;
	
	z=y-1;
	y=y-1;
	

	var city=ds.Tables[0].Rows[y].City_Code;
	
	document.getElementById('txtcustcode').value=ds.Tables[0].Rows[y].Cust_Code;
	document.getElementById('txtcustomername').value=ds.Tables[0].Rows[y].Cust_Name;
	document.getElementById('txtalias').value=ds.Tables[0].Rows[y].Cust_Alias;
	
	//Function  CallBack 
	
	document.getElementById('txtstreet').value=ds.Tables[0].Rows[y].Stree;
	document.getElementById('txtpincode').value=ds.Tables[0].Rows[y].Zip;
	document.getElementById('txtdistrict').value=ds.Tables[0].Rows[y].Dist_code;
	document.getElementById('txtstate').value=ds.Tables[0].Rows[y].State_code;
	document.getElementById('txtphone1').value=ds.Tables[0].Rows[y].phone1; 
	document.getElementById('txtphone2').value=ds.Tables[0].Rows[y].Phone2;
	document.getElementById('txtfax').value=ds.Tables[0].Rows[y].Fax;
	document.getElementById('txtvts').value=ds.Tables[0].Rows[y].No_of_VTS;
	document.getElementById('txtemailid').value=ds.Tables[0].Rows[y].EmailID;
	document.getElementById('txtUrl').value=ds.Tables[0].Rows[y].URL;
	document.getElementById('txtservicetax').value=ds.Tables[0].Rows[y].ST_ACC_No;
	document.getElementById('txtPan').value=ds.Tables[0].Rows[y].PAN_No;
	document.getElementById('txtcreditdays').value=ds.Tables[0].Rows[y].Credit_Days;
	document.getElementById('txtstatus1').value=ds.Tables[0].Rows[y].Cust_Status;
	document.getElementById('txtstatusreason').value=ds.Tables[0].Rows[y].Status_Reason;
	document.getElementById('txtalert').value=ds.Tables[0].Rows[y].Remarks;
	document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[y].UserId;
	document.getElementById('txtadd1').value=ds.Tables[0].Rows[y].Add1;
	
	
	document.getElementById('txtcountry').value=ds.Tables[0].Rows[y].Country_code;
		cityvar=ds.Tables[0].Rows[y].City_Code;
			addcount(ds.Tables[0].Rows[y].City_Code);
			
			document.getElementById('drpzone').value=ds.Tables[0].Rows[y].Zone_code;
		document.getElementById('drpregion').value=ds.Tables[0].Rows[y].Region_code;
		document.getElementById('txtcrlimit').value=ds.Tables[0].Rows[y].Credit_limit;
			
			
	var dateformat=document.getElementById('hiddenDateFormat').value;
	var currentdate=ds.Tables[0].Rows[y].Creation_Datetime;
	var dd=currentdate.getDate();
	var mm=currentdate.getMonth() + 1;
	var yyyy=currentdate.getFullYear();
	//var enrolldate1=mm+'/'+dd+'/'+yyyy;
	
	if(dateformat=="yyyy/mm/dd")
	{
	var currentdate1=yyyy+'/'+mm+'/'+dd;
	} 
	else if (dateformat=="mm/dd/yyyy")
	{
	var currentdate1=mm+'/'+dd+'/'+yyyy;
	}
	else if (dateformat=="dd/mm/yyyy")
	{
	var currentdate1=dd+'/'+mm+'/'+yyyy;
	}
	else
	{
	var currentdate1=mm+'/'+dd+'/'+yyyy;
	}
	
	
	
	var todate=ds.Tables[0].Rows[y].To_date;
	var dd=todate.getDate();
	var mm=todate.getMonth() + 1;
	var yyyy=todate.getFullYear();
	//var enrolldate1=mm+'/'+dd+'/'+yyyy;
	
	if(dateformat=="yyyy/mm/dd")
	{
	var todate1=yyyy+'/'+mm+'/'+dd;
	} 
	else if (dateformat=="mm/dd/yyyy")
	{
	var todate1=mm+'/'+dd+'/'+yyyy;
	}
	else if (dateformat=="dd/mm/yyyy")
	{
	var todate1=dd+'/'+mm+'/'+yyyy;
	}
	else
	{
	var todate1=mm+'/'+dd+'/'+yyyy;
	}
			
	

	
	document.getElementById('txtstatusdate').value = currentdate1;
	document.getElementById('txtalert').value=ds.Tables[0].Rows[y].Remarks;
	document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[y].UserId;
	document.getElementById('txtadd1').value=ds.Tables[0].Rows[y].Add1;
	document.getElementById('txtstatus1').style.visibility = "visible";
	document.getElementById('txtstatusdate').style.visibility = "visible";
	document.getElementById('Status').style.visibility="visible";
	document.getElementById('StatusDate').style.visibility="visible";
	
	var tdate=new Date(todate1);
	var cdate= new Date(currentdate1);
	if(cdate>tdate)
	{
	document.getElementById('txtstatus1').value="Banned"
	}
	else
	{
	document.getElementById('txtstatus1').value=ds.Tables[0].Rows[y].Cust_Status;
	}
	
	//Disabled Fields
	
	document.getElementById('txtcustcode').disabled=true;
	document.getElementById('txtcustomername').disabled=true;			
	document.getElementById('txtalias').disabled=true;		
	document.getElementById('txtadd1').disabled=true;					
	document.getElementById('txtstreet').disabled=true;			
	document.getElementById('drpcity').disabled=true;			
	document.getElementById('txtdistrict').disabled=true;				
	document.getElementById('txtcountry').disabled=true;					
	document.getElementById('txtphone1').disabled=true;			
	document.getElementById('txtphone2').disabled=true;			
	document.getElementById('txtemailid').disabled=true;		
	document.getElementById('txtUrl').disabled=true;					
	document.getElementById('txtvts').disabled=true;			
	document.getElementById('txtservicetax').disabled=true;			
	document.getElementById('txtPan').disabled=true;	
	document.getElementById('txtcreditdays').disabled=true;					
	document.getElementById('txtstatusreason').disabled=true;			
	document.getElementById('txtstatus1').disabled=true;			
	document.getElementById('txtalert').disabled=true;		
	document.getElementById('txtpincode').disabled=true;					
	document.getElementById('txtstate').disabled=true;			
	document.getElementById('txtfax').disabled=true;			
	document.getElementById('txtstatusdate').disabled=true;	
	
	//ToolBar Disabled Status
	chkstatus(FlagStatus);	
	if(FlagStatus==2||FlagStatus==3||FlagStatus==6)
	{
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnModify').disabled=false;
		
	}
	if(FlagStatus==4)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		
	}
	if(FlagStatus==5)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		
	}
	if(FlagStatus==6||FlagStatus==7)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=false;
		
	}
		
	document.getElementById('btnfirst').disabled=false;				
	document.getElementById('btnnext').disabled=true;					
	document.getElementById('btnprevious').disabled=false;	
	document.getElementById('btnlast').disabled=true;	
			
	document.getElementById('btnExit').disabled=false;	
	return false;
	
}


//Delete Function  
function ClientDelete()
{
	var compcode=document.getElementById('hiddencompcode').value;
	var custcode=document.getElementById('txtcustcode').value;
	var userid=document.getElementById('userid2').value;

	if (confirm("Are you sure you want to delete")) 
	{
		ClientMaster.ClientDeletedetail(compcode,custcode,userid,Client_CallBack);
		//ClientMaster.first(compcode,userid,custcode,Client_CallBack);
		alert("Record is Deleted Successfully");
	}
	
	return false;
}

function Client_CallBack(response)
{
	var ds = response.value;
	var len=ds.Tables[0].Rows.length;
	if(ds.Tables[0].Rows.length==0)
	{
			alert("No More Data is here to be deleted");
			
			document.getElementById('btnSave').disabled = true;
	document.getElementById('txtcustcode').disabled=true;			
	document.getElementById('txtcustomername').disabled=true;			
	document.getElementById('txtalias').disabled=true;		
	document.getElementById('txtadd1').disabled=true;					
	document.getElementById('txtstreet').disabled=true;			
	document.getElementById('drpcity').disabled=true;			
	document.getElementById('txtdistrict').disabled=true;				
	document.getElementById('txtcountry').disabled=true;					
	document.getElementById('txtphone1').disabled=true;			
	document.getElementById('txtphone2').disabled=true;			
	document.getElementById('txtemailid').disabled=true;		
	document.getElementById('txtUrl').disabled=true;					
	document.getElementById('txtvts').disabled=true;			
	document.getElementById('txtservicetax').disabled=true;			
	document.getElementById('txtPan').disabled=true;	
	document.getElementById('txtcreditdays').disabled=true;					
	document.getElementById('txtstatusreason').disabled=true;			
	document.getElementById('txtstatus1').disabled=true;			
	document.getElementById('txtalert').disabled=true;		
	document.getElementById('txtpincode').disabled=true;					
	document.getElementById('txtstate').disabled=true;			
	document.getElementById('txtfax').disabled=true;			
	document.getElementById('txtstatusdate').disabled=true;		
	document.getElementById('txtcustcode').value="";
	document.getElementById('txtcustomername').value="";			
	document.getElementById('txtalias').value="";		
	document.getElementById('txtadd1').value="";					
	document.getElementById('txtstreet').value="";			
	document.getElementById('drpcity').value=0;			
	document.getElementById('txtdistrict').value="";				
	document.getElementById('txtcountry').value="0";					
	document.getElementById('txtphone1').value="";			
	document.getElementById('txtphone2').value="";			
	document.getElementById('txtemailid').value="";		
	document.getElementById('txtUrl').value="";					
	document.getElementById('txtvts').value="";			
	document.getElementById('txtservicetax').value="";			
	document.getElementById('txtPan').value="";	
	document.getElementById('txtcreditdays').value="";					
	document.getElementById('txtstatusreason').value="";			
	document.getElementById('txtstatus1').value="";			
	document.getElementById('txtalert').value="";		
	document.getElementById('txtpincode').value="";					
	document.getElementById('txtstate').value="";			
	document.getElementById('txtfax').value="";			
	document.getElementById('txtstatusdate').value="";						
	document.getElementById('modify').value="";
	CancelClick('ClientMaster');		
		
	}
	else if(z==-1 ||z>=len)
		{
		var city=ds.Tables[0].Rows[0].City_Code;
	
	
	document.getElementById('txtcustcode').value=ds.Tables[0].Rows[0].Cust_Code;
	document.getElementById('txtcustomername').value=ds.Tables[0].Rows[0].Cust_Name;
	document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Cust_Alias;
	document.getElementById('drpcity').value=ds.Tables[0].Rows[0].City_Code;
	
	//Function  CallBack 
	ClientMaster.addcity(city,clientaddcode1);
	
	document.getElementById('txtstreet').value=ds.Tables[0].Rows[0].Stree;
	document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].country_code;
	document.getElementById('txtpincode').value=ds.Tables[0].Rows[0].Zip;
	document.getElementById('txtdistrict').value=ds.Tables[0].Rows[0].Dist_code;
	document.getElementById('txtstate').value=ds.Tables[0].Rows[0].State_code;
	document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].Country_code;
	document.getElementById('txtphone1').value=ds.Tables[0].Rows[0].phone1; 
	document.getElementById('txtphone2').value=ds.Tables[0].Rows[0].Phone2;
	document.getElementById('txtfax').value=ds.Tables[0].Rows[0].Fax;
	document.getElementById('txtemailid').value=ds.Tables[0].Rows[0].EmailID;
	document.getElementById('txtUrl').value=ds.Tables[0].Rows[0].URL;
	document.getElementById('txtservicetax').value=ds.Tables[0].Rows[0].ST_ACC_No;
	document.getElementById('txtPan').value=ds.Tables[0].Rows[0].PAN_No;
	document.getElementById('txtcreditdays').value=ds.Tables[0].Rows[0].Credit_Days;
	document.getElementById('txtstatus1').value=ds.Tables[0].Rows[0].Cust_Status;
	document.getElementById('txtstatusreason').value=ds.Tables[0].Rows[0].Status_Reason;
	document.getElementById('txtalert').value=ds.Tables[0].Rows[0].Remarks;
	document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[0].UserId;
	document.getElementById('txtadd1').value=ds.Tables[0].Rows[0].Add1;
	
	
	var dateformat=document.getElementById('hiddenDateFormat').value;
		var currentdate=ds.Tables[0].Rows[0].Creation_Datetime;
		var dd=currentdate.getDate();
		var mm=currentdate.getMonth() + 1;
		var yyyy=currentdate.getFullYear();
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
		var currentdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="mm/dd/yyyy")
		{
		var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		else if (dateformat=="dd/mm/yyyy")
		{
		var currentdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
		var currentdate1=mm+'/'+dd+'/'+yyyy;
		}
		
		
		
		var todate=ds.Tables[0].Rows[0].To_date;
		var dd=todate.getDate();
		var mm=todate.getMonth() + 1;
		var yyyy=todate.getFullYear();
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
		var todate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="mm/dd/yyyy")
		{
		var todate1=mm+'/'+dd+'/'+yyyy;
		}
		else if (dateformat=="dd/mm/yyyy")
		{
		var todate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
		var todate1=mm+'/'+dd+'/'+yyyy;
		}
				
		
	
		
		document.getElementById('txtstatusdate').value = currentdate1;
		document.getElementById('txtalert').value=ds.Tables[0].Rows[0].Remarks;
		document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[0].UserId;
		document.getElementById('txtadd1').value=ds.Tables[0].Rows[0].Add1;
		document.getElementById('txtstatus1').style.visibility = "visible";
		document.getElementById('txtstatusdate').style.visibility = "visible";
		document.getElementById('Status').style.visibility="visible";
		document.getElementById('StatusDate').style.visibility="visible";
		
		var tdate=new Date(todate1);
		var cdate= new Date(currentdate1);
		if(cdate>tdate)
		{
		document.getElementById('txtstatus1').value="Banned"
		}
		else
		{
		document.getElementById('txtstatus1').value=ds.Tables[0].Rows[0].Cust_Status;
		}
		
		}
		
		else
		{
		
		var city=ds.Tables[0].Rows[z].City_Code;
			
			document.getElementById('txtcustcode').value=ds.Tables[0].Rows[z].Cust_Code;
			document.getElementById('txtcustomername').value=ds.Tables[0].Rows[z].Cust_Name;
			document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Cust_Alias;
			document.getElementById('drpcity').value=ds.Tables[0].Rows[z].City_Code;
			
			//Function  CallBack 
			ClientMaster.addcity(city,clientaddcode1);
			
			document.getElementById('txtstreet').value=ds.Tables[0].Rows[z].Stree;
			document.getElementById('txtcountry').value=ds.Tables[0].Rows[z].country_code;
			document.getElementById('txtpincode').value=ds.Tables[0].Rows[z].Zip;
			document.getElementById('txtdistrict').value=ds.Tables[0].Rows[z].Dist_code;
			document.getElementById('txtstate').value=ds.Tables[0].Rows[z].State_code;
			document.getElementById('txtcountry').value=ds.Tables[0].Rows[z].Country_code;
			document.getElementById('txtphone1').value=ds.Tables[0].Rows[z].phone1; 
			document.getElementById('txtphone2').value=ds.Tables[0].Rows[z].Phone2;
			document.getElementById('txtfax').value=ds.Tables[0].Rows[z].Fax;
			document.getElementById('txtemailid').value=ds.Tables[0].Rows[z].EmailID;
			document.getElementById('txtUrl').value=ds.Tables[0].Rows[z].URL;
			document.getElementById('txtservicetax').value=ds.Tables[0].Rows[z].ST_ACC_No;
			document.getElementById('txtPan').value=ds.Tables[0].Rows[z].PAN_No;
			document.getElementById('txtcreditdays').value=ds.Tables[0].Rows[z].Credit_Days;
			document.getElementById('txtstatus1').value=ds.Tables[0].Rows[z].Cust_Status;
			document.getElementById('txtstatusreason').value=ds.Tables[0].Rows[z].Status_Reason;
			document.getElementById('txtalert').value=ds.Tables[0].Rows[z].Remarks;
			document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[z].UserId;
			document.getElementById('txtadd1').value=ds.Tables[0].Rows[z].Add1;
			
			var dateformat=document.getElementById('hiddenDateFormat').value;
			var currentdate=ds.Tables[0].Rows[z].Creation_Datetime;
			var dd=currentdate.getDate();
			var mm=currentdate.getMonth() + 1;
			var yyyy=currentdate.getFullYear();
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="yyyy/mm/dd")
			{
			var currentdate1=yyyy+'/'+mm+'/'+dd;
			} 
			else if (dateformat=="mm/dd/yyyy")
			{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
			}
			else if (dateformat=="dd/mm/yyyy")
			{
			var currentdate1=dd+'/'+mm+'/'+yyyy;
			}
			else
			{
			var currentdate1=mm+'/'+dd+'/'+yyyy;
			}
			
			
			
			var todate=ds.Tables[0].Rows[z].To_date;
			var dd=todate.getDate();
			var mm=todate.getMonth() + 1;
			var yyyy=todate.getFullYear();
			//var enrolldate1=mm+'/'+dd+'/'+yyyy;
			
			if(dateformat=="yyyy/mm/dd")
			{
			var todate1=yyyy+'/'+mm+'/'+dd;
			} 
			else if (dateformat=="mm/dd/yyyy")
			{
			var todate1=mm+'/'+dd+'/'+yyyy;
			}
			else if (dateformat=="dd/mm/yyyy")
			{
			var todate1=dd+'/'+mm+'/'+yyyy;
			}
			else
			{
			var todate1=mm+'/'+dd+'/'+yyyy;
			}
			
			document.getElementById('txtstatusdate').value = currentdate1;
			document.getElementById('txtalert').value=ds.Tables[0].Rows[z].Remarks;
			document.getElementById('hiddenuserid').value=ds.Tables[0].Rows[z].UserId;
			document.getElementById('txtadd1').value=ds.Tables[0].Rows[z].Add1;
			document.getElementById('txtstatus1').style.visibility = "visible";
			document.getElementById('txtstatusdate').style.visibility = "visible";
			document.getElementById('Status').style.visibility="visible";
			document.getElementById('StatusDate').style.visibility="visible";
			
			var tdate=new Date(todate1);
			var cdate= new Date(currentdate1);
			if(cdate>tdate)
			{
			document.getElementById('txtstatus1').value="Banned"
			}
			else
			{
			document.getElementById('txtstatus1').value=ds.Tables[0].Rows[z].Cust_Status;
			}
			}
	alert ("Data Deleted");	
	return false;
}




function ClientUpdate()
{
	//Condition Check 
	document.getElementById('btnSave').disabled=false;
	var compcode=document.getElementById('hiddencompcode').value;
	var custcode=document.getElementById('txtcustcode').value;
	var custname=document.getElementById('txtcustomername').value;
	var alias=document.getElementById('txtalias').value;
	var add1=document.getElementById('txtadd1').value;
	var city=document.getElementById('drpcity').value;
	var street=document.getElementById('txtstreet').value;
	var country=document.getElementById('txtcountry').value;
	var pincode=document.getElementById('txtpincode').value;
	var dist=document.getElementById('txtdistrict').value;
	var state=document.getElementById('txtstate').value;
	var country=document.getElementById('txtcountry').value;
	var phone1=document.getElementById('txtphone1').value; 
	var phone2=document.getElementById('txtphone2').value;
	var fax=document.getElementById('txtfax').value;
	var emailid=document.getElementById('txtemailid').value;
	var url=document.getElementById('txtUrl').value;
	var vts=document.getElementById('txtvts').value;
	var servicetax=document.getElementById('txtservicetax').value;
	var pan=document.getElementById('txtPan').value;
	var creditdays=document.getElementById('txtcreditdays').value;
	var paymode="";
	var zone=document.getElementById('drpzone').value;
			var region=document.getElementById('drpregion').value;
			var crdlimit=document.getElementById('txtcrlimit').value;
			
	var status=document.getElementById('txtstatus1').value;
	var statusreason=document.getElementById('txtstatusreason').value;
	var alert1=document.getElementById('txtalert').value;
	var userid=document.getElementById('userid2').value;

	ClientMaster.clientsave(compcode,custcode,custname,alias,add1,street,city,pincode,dist,state,country,phone1,phone2,fax,emailid,url,vts,servicetax,pan,creditdays,paymode,status,statusreason,alert1,userid,zone,region,crdlimit,1);
	alert("Data Modified Sucessfully");
	
	
	
	document.getElementById('modify').value="";
	document.getElementById('btnSave').disabled = true;
	document.getElementById('txtcustcode').disabled=true;			
	document.getElementById('txtcustomername').disabled=true;			
	document.getElementById('txtalias').disabled=true;		
	document.getElementById('txtadd1').disabled=true;					
	document.getElementById('txtstreet').disabled=true;			
	document.getElementById('drpcity').disabled=true;			
	document.getElementById('txtdistrict').disabled=true;				
	document.getElementById('txtcountry').disabled=true;					
	document.getElementById('txtphone1').disabled=true;			
	document.getElementById('txtphone2').disabled=true;			
	document.getElementById('txtemailid').disabled=true;		
	document.getElementById('txtUrl').disabled=true;					
	document.getElementById('txtvts').disabled=true;			
	document.getElementById('txtservicetax').disabled=true;			
	document.getElementById('txtPan').disabled=true;	
	document.getElementById('txtcreditdays').disabled=true;					
	document.getElementById('txtstatusreason').disabled=true;			
	document.getElementById('txtstatus1').disabled=true;			
	document.getElementById('txtalert').disabled=true;		
	document.getElementById('txtpincode').disabled=true;					
	document.getElementById('txtstate').disabled=true;			
	document.getElementById('txtfax').disabled=true;			
	document.getElementById('txtstatusdate').disabled=true;		
	document.getElementById('btnSave').disabled=true;
	//document.getElementById('btnModify').disabled=false;
	document.getElementById('btnModify').disabled=false;
	document.getElementById('btnfirst').disabled=false;
	document.getElementById('btnnext').disabled=false;
	document.getElementById('btnprevious').disabled=false;
	document.getElementById('btnlast').disabled=false;
	document.getElementById('btnQuery').disabled=false;
	document.getElementById('btnDelete').disabled=false;
	



	return false;
}

var ValidateStatus;
function ValidateFields()
{
//	if(document.getElementById('txtcustcode').value=="")
//	{
//		alert("Please Enter Customer Code");
//		document.getElementById('txtcustcode').focus();
//		ValidateStatus =0;
//		return false;
//	}
	if(document.getElementById('txtcustomername').value=="")
	{
		alert("Please Enter Customer Name");
		document.getElementById('txtcustomername').focus();
		ValidateStatus =0;
		return false;
	}
	
	if(document.getElementById('txtalias').value=="")							
	{
		alert("Please Enter Alias Name");
		document.getElementById('txtalias').focus();
		ValidateStatus =0;
		return false;
	}
	if(document.getElementById('drpcity').value==0 )
	{
		alert("Please Select  City Name");
		document.getElementById('drpcity').focus();
		ValidateStatus =0;
		return false;
	}
	else
	{ValidateStatus =1;}
	
}

var test = "false";
function ClientSave()
{
	test = "true";
	ValidateFields();
	
	var mod = document.getElementById('modify').value;
		
		if(mod=="modify")
		{
			ClientUpdate();
			return false;
		}
	
	if(ValidateStatus==1 && mod!="modify")
	{
		var compcode=document.getElementById('hiddencompcode').value;
		var custcode=document.getElementById('txtcustcode').value;
		var userid=document.getElementById('userid2').value;
		ClientMaster.CheckClientPopup(compcode,custcode,userid,0,CheckClientPopup_CallBack);
	}
	return false;
}

function CheckClientPopup_CallBack(response)
{
	var ds = response.value;
	
	if(ds.Tables[0].Rows.length==0)
	{
		alert("Please Enter Paymode Details");
		return false;
	}
	else if(ds.Tables[1].Rows.length==0)
	{
		alert("Please Enter Status Details");
		return false;
	}
	else if(ds.Tables[2].Rows.length==0)
	{
		alert("Please Enter Contact Details");
		return false;
	}
	else if(ds.Tables[3].Rows.length > 0)
	{
	alert("This Code Is Assigned");
	return false;
	}
	else
	{
		
		if(document.getElementById('modify').value=="")
		{
			var compcode=document.getElementById('hiddencompcode').value;
			var custcode=document.getElementById('txtcustcode').value;
			var custname=document.getElementById('txtcustomername').value;
			var alias=document.getElementById('txtalias').value;
			var add1=document.getElementById('txtadd1').value;
			var city=document.getElementById('drpcity').value;
			
			var street=document.getElementById('txtstreet').value;
			var country=document.getElementById('txtcountry').value;
			var pincode=document.getElementById('txtpincode').value;
			var dist=document.getElementById('txtdistrict').value;
			var state=document.getElementById('txtstate').value;
			var country=document.getElementById('txtcountry').value;
			var phone1=document.getElementById('txtphone1').value; 
			var phone2=document.getElementById('txtphone2').value;
			var fax=document.getElementById('txtfax').value;
			var emailid=document.getElementById('txtemailid').value;
			var url=document.getElementById('txtUrl').value;
			var vts=document.getElementById('txtvts').value;
			var servicetax=document.getElementById('txtservicetax').value;
			var pan=document.getElementById('txtPan').value;
			var creditdays=document.getElementById('txtcreditdays').value;
			var paymode="";
			var status1=document.getElementById('txtstatus1').value;
			var statusreason=document.getElementById('txtstatusreason').value;
			
			var zone=document.getElementById('drpzone').value;
			var region=document.getElementById('drpregion').value;
			var crdlimit=document.getElementById('txtstatusdate').value;
			
			var alert1=document.getElementById('txtalert').value;
			var userid2=document.getElementById('userid2').value;
			

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


			ClientMaster.clientsave(compcode,custcode,custname,alias,add1,street,city,pincode,dist,state,country,phone1,phone2,fax,emailid,url,vts,servicetax,pan,creditdays,paymode,status1,statusreason,alert1,userid2,zone,region,crdlimit,0);
		
		
			document.getElementById('txtcustcode').value="";
			document.getElementById('txtcustomername').value=""
			document.getElementById('txtalias').value=""
			document.getElementById('txtadd1').value=""
			document.getElementById('drpcity').value=""
			
			document.getElementById('txtstreet').value=""
			document.getElementById('txtcountry').value=""
			document.getElementById('txtpincode').value=""
			document.getElementById('txtdistrict').value=""
			document.getElementById('txtstate').value=""
			document.getElementById('txtcountry').value=""
			document.getElementById('txtphone1').value=""
			document.getElementById('txtphone2').value=""
			document.getElementById('txtfax').value=""
			document.getElementById('txtemailid').value=""
			document.getElementById('txtUrl').value=""

			document.getElementById('txtvts').value=""
			document.getElementById('txtservicetax').value=""
			document.getElementById('txtPan').value=""
			document.getElementById('txtcreditdays').value=""
			var paymode="";
			document.getElementById('txtstatus1').value=""
			document.getElementById('txtstatusreason').value=""

			document.getElementById('txtalert').value=""
			
			alert("Your Data is Saved");		
			CancelClick('ClientMaster');
		}
	}
return false;
}

/*-----------------------------Pop up coding starts-------------------------- */

/*Paymode Coding starts */
var mystatus;
//Client Pay Mode Submission

function ClientPayModeSubmit()
{
	var chkList234= document.getElementById("chklstSubmit");
	
	var MyArray = new Array(3)
	var str = new Array(3);
	MyArray[0]= document.getElementById ("chklstSubmit_0").nextSibling;
	MyArray[1]= document.getElementById ("chklstSubmit_1").nextSibling;
	MyArray[2]= document.getElementById ("chklstSubmit_2").nextSibling;
	var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
		
	if(arrayOfCheckBoxes[0].checked==false && arrayOfCheckBoxes[1].checked==false && arrayOfCheckBoxes[2].checked==false)	
	{
		alert('Please Checked Atleast One Mode of Payment');
		return false;
	}
	else
	{
	
		var compcode=document.getElementById('hiddencomcode').value;
		var custcode=document.getElementById('hiddenclientcode').value; 
		var userid = document.getElementById('hiddenuserid').value; 
		Mycustcode = custcode;
		for(var i=0;i<arrayOfCheckBoxes.length;i++)
		{
			if(arrayOfCheckBoxes[i].checked==true)
			{
				str[i]=MyArray[i].innerHTML;
		
			}
		}
		var compcode=document.getElementById('hiddencomcode').value;
		var custcode=document.getElementById('hiddenclientcode').value; 
		var userid = document.getElementById('hiddenuserid').value;
		
		ClientPaymode.ClientPayModeInsert(compcode,custcode,userid,str);
		ClientPayModeUpdatedData();
		arrayOfCheckBoxes[0].checked=false ;
		arrayOfCheckBoxes[1].checked=false ;
		arrayOfCheckBoxes[2].checked=false;
		document.getElementById("chklstSubmit").disabled=true;
		document.getElementById("btnSubmit").disabled=true;
		mystatus=1;
	}
		chk123();
	return false;
}


//Client Refereshed Data

function ClientPayModeUpdatedData()
{
	
	var chkListSubmit= document.getElementById("chklstSubmit");
	var arrayOfCheckBoxesSubmit= chkListSubmit.getElementsByTagName("input");
	
	var chklstUpdate1= document.getElementById("chklstUpdate");
	var arrayOfCheckBoxesUpdate= chklstUpdate1.getElementsByTagName("input");
	
	var compcode=document.getElementById('hiddencomcode').value;
	var custcode=document.getElementById('hiddenclientcode').value; 
	var userid = document.getElementById('hiddenuserid').value; 
		
	for(var i =0;i<=arrayOfCheckBoxesSubmit.length-1;i++)
	{
		if(arrayOfCheckBoxesSubmit[i].checked==true)
		{
			arrayOfCheckBoxesUpdate[i].checked=true;
		}
	}
	
	
	
	document.getElementById('chklstUpdate').disabled=false;
	
	document.getElementById("btnUpdate").disabled=false;
	return false;
}


//Updating Values 


function ClientPayModeUpdate()
{
	var chkList234= document.getElementById("chklstUpdate");
	
	var MyArray = new Array(3)
	var str = new Array(3);
	MyArray[0]= document.getElementById ("chklstUpdate_0").nextSibling;
	MyArray[1]= document.getElementById ("chklstUpdate_1").nextSibling;
	MyArray[2]= document.getElementById ("chklstUpdate_2").nextSibling;
	
	var arrayOfCheckBoxes= chkList234.getElementsByTagName("input");
		
	if(arrayOfCheckBoxes[0].checked==false && arrayOfCheckBoxes[1].checked==false && arrayOfCheckBoxes[2].checked==false)	
	{
		alert('Please Checked Atleast One Mode of Payment');
		return false;
	}
	else
	{
		var compcode=document.getElementById('hiddencomcode').value;
		var custcode=document.getElementById('hiddenclientcode').value; 
		var userid = document.getElementById('hiddenuserid').value; 
		for(var i=0;i<arrayOfCheckBoxes.length;i++)
		{
			if(arrayOfCheckBoxes[i].checked==true)
			{
				str[i]=MyArray[i].innerHTML;
		
			}
		}
		var compcode=document.getElementById('hiddencomcode').value;
		var custcode=document.getElementById('hiddenclientcode').value; 
		var userid = document.getElementById('hiddenuserid').value;
		
		ClientPaymode.ClientPayModeInsert(compcode,custcode,userid,str);
		//alert("Data saved");
	}
	return false;
}




//POP UP 
function ClientPay()
{
	var ClientCode= document.getElementById('txtcustcode').value;
	var ab;
	if(document.getElementById('txtcustcode').value!="")
	{
	for ( var index = 0; index < 200; index++ ) 
           { 
	paywind=window.open("ClientPaymode.aspx?ClCode="+ClientCode+'&show='+show,'c',"status=0,toolbar=0,menubar=0 ,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px");
	
	paywind.focus();
	//alert(paywind);
	return false;
	}
	}
	else
	{
	alert('You must enter Client Code ');
	}
	return false;
}

function ClientStatusDetail()
{
	var ClientCode= document.getElementById('txtcustcode').value;
	var ab;
	if(document.getElementById('txtcustcode').value!="")
	{
	for ( var index = 0; index < 200; index++ ) 
           { 
		statuswind=window.open("clientstatusmaster.aspx?custcode="+ClientCode+'&show='+show,'a', "status=0,toolbar=0,resizable=1,scrollbars=yes,top=244,left=210,width=780px,height=415px");
		statuswind.focus();
	return false;
	}
	}
	else
	{
		alert('You must enter Client Code ');
	}
	return false;
}

function ClientContactDetail()
{
	var ClientCode= document.getElementById('txtcustcode').value;
	var ab;
	if(document.getElementById('txtcustcode').value!="")
	{
	for ( var index = 0; index < 200; index++ ) 
           { 
		contwind=window.open("clientcontactdetails.aspx?custcode="+ClientCode+'&show='+show,'b',"status=0,toolbar=0,menubar=0 ,resizable=1,scrollbars=yes,top=244,left=210,,width=780px,height=415px");
		contwind.focus();
		return false;
		}
	}
	else
	{
		alert('You must enter Client Code ');
	}
	return false;
}

function clientaddcode()
{
document.getElementById('hiddencitycode').value=document.getElementById('drpcity').value;
var city=document.getElementById('hiddencitycode').value;
ClientMaster.addcity(city,clientaddcode1);
}

function addcity()
{
	document.getElementById('hiddencitycode').value=document.getElementById('drpcity').value;
	var	city=document.getElementById('hiddencitycode').value;
	ClientMaster.addcity(city,clientaddcode1);
}


function clientaddcode1(response)
{
	var ds=response.value;
	if(ds.Tables[1].Rows.length>0 || ds.Tables[2].Rows.length>0 || ds.Tables[0].Rows.length>0)
	{
		document.getElementById('txtdistrict').value=ds.Tables[1].Rows[0].dist_name;
		document.getElementById('txtstate').value=ds.Tables[2].Rows[0].state_name;
		document.getElementById('txtcountry').value=ds.Tables[0].Rows[0].country_name;
		document.getElementById('txtdistrict').disabled=true;
		document.getElementById('txtstate').disabled=true;
		document.getElementById('txtcountry').disabled=true;
	}
	else
	{
		document.getElementById('txtdistrict').value="";
		document.getElementById('txtstate').value="";
		document.getElementById('txtcountry').value="0";
		document.getElementById('txtdistrict').disabled=true;
		document.getElementById('txtstate').disabled=true;
		document.getElementById('txtcountry').disabled=true;
	}
	return false;
}

