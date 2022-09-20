



var currenttime = new Date();

var montharray=new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec")
var serverdate=new Date(currenttime)

function padlength(what){
var output=(what.toString().length==1)? "0"+what : what
return output
}

function displaytime()
{

	serverdate.setSeconds(serverdate.getSeconds()+1)
	var username = document.getElementById('Username').value;
	var datestring=montharray[serverdate.getMonth()]+" "+padlength(serverdate.getDate())+", "+serverdate.getFullYear()
	var timestring=padlength(serverdate.getHours())+":"+padlength(serverdate.getMinutes())+":"+padlength(serverdate.getSeconds())
	document.getElementById("tP1").innerHTML= username + "&nbsp;" + datestring+" "+timestring
}
function Clock()
{
	setInterval("displaytime()", 1000);
}



var FlagStatus;
function getPermission(formname)
{
//alert("hipermission");
	var userid = document.getElementById('hiddenuserid').value;
	var compcode = document.getElementById('hiddencompcode').value;
	ClientMaster.submitpermission(compcode,userid,formname,getPermission_CallBack);
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
//			document.getElementById('Topbar1_lbldisplay').style.visibility="hidden";
//			document.getElementById('Topbar1_Label3').style.visibility="hidden";
//			document.getElementById('Topbar1_Label4').style.visibility="hidden";
//			document.getElementById('Topbar1_Label5').style.visibility="hidden";
//			document.getElementById('Topbar1_Label2').style.visibility="hidden";
			
		
			window.location.href = 'EnterPage.aspx';
			alert("You Are Not Authorised To See This Form");
			FlagStatus = 1;
			window.location.href = 'EnterPage.aspx';
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
			FlagStatus = 4;
			return false;
		}
		if(id=="5" ||id=="13")
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
		alert("Please Register your form for!!!!!! Administrator only");
		return false;
	}
	return false;
}



//Set Permission is used to Update/Change the current permission level of the form
/*function setPermission(formname)
{
	var userid = document.getElementById('hiddenuserid').value;
	var compcode = document.getElementById('hiddencompcode').value;
	Master.MasterPrev(userid,compcode,formname);
	return false;
}
*/

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

function updateStatus()
{
	chkstatus(FlagStatus);
	//alert(FlagStatus);
	if(FlagStatus==2||FlagStatus==3)
	{
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnModify').disabled=false;
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=false;			
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnDelete').disabled=true;
	}
	if(FlagStatus==4)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=false;			
		document.getElementById('btnlast').disabled=false;
	
	}
	if(FlagStatus==5)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=false;			
		document.getElementById('btnlast').disabled=false;
		
	}
	if(FlagStatus==6||FlagStatus==7)
	{
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=false;
		document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=false;			
		document.getElementById('btnlast').disabled=false;
		
	}
	if(FlagStatus==1 || FlagStatus==0)
	{
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnnext').disabled=true;					
		document.getElementById('btnprevious').disabled=true;			
		document.getElementById('btnlast').disabled=true;
		
	}
	
	return false;
	
}

function formabc()
{
alert("hillo");
}
function givebuttonpermission(formname)
{
//alert("hi");

if(document.getElementById('hiddencompcode').value==null)
{

window.location.href='login.aspx'
}

        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
            httpRequest.overrideMimeType('text/xml'); 
            }
            
            httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","button.aspx?page="+formname, false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    id=httpRequest.responseText;   
                }
                else 
                {
                    alert('There was a problem with the request.');
                }
            }
        }
        else
    
    
        {

                var page;
		        var xml = new ActiveXObject("Microsoft.XMLHTTP");
		        xml.Open( "GET","button.aspx?page="+formname, false );
		        xml.Send();
		         id=xml.responseText;
        }


//alert(id);
//var ds = response.value;
	
	//if(ds.Tables[0].Rows.length>0)
	if(id!=0)
	{
		//var id = ds.Tables[0].Rows[0].button_id;
		
		
		
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
//			document.getElementById('Topbar1_lbldisplay').style.visibility="hidden";
//			document.getElementById('Topbar1_Label3').style.visibility="hidden";
//			document.getElementById('Topbar1_Label4').style.visibility="hidden";
//			document.getElementById('Topbar1_Label5').style.visibility="hidden";
//			document.getElementById('Topbar1_Label2').style.visibility="hidden";
//			
		
			window.location.href = 'EnterPage.aspx';
			alert("You Are Not Authorised To See This Form");
			FlagStatus = 0;
			window.close();
			//return false;
					
		}
		if(id=="1"||id=="9")
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnQuery').disabled=false;
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
			//return false;
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
			//return false;
			
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
			//return false;

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
			//return false;
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
			//return false;
			
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
			//return false;
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
			//return false;
		}
	}
	else
	{
		alert("Please Register your form for!!!!!! Administrator only");
		window.close();
		return false;
	}
	
	if(formname=="Agent_master")
	{
	checkthevisibility();
	}
	if(formname=="Booking_master")
	{
	    if(document.getElementById('hiddenaudit').value!="")
	    {
	            document.getElementById('btnNew').disabled=true;
	            document.getElementById('btnQuery').disabled=true;
	            document.getElementById('btnCancel').disabled=true;
	            document.getElementById('txtciobookid').value=document.getElementById('hiddenaudit').value;
	            document.getElementById('btnExecute').disabled=false;
	            document.getElementById('txtciobookid').style.backgroundColor="#FFFF80";
	             document.getElementById('txtciobookid').disabled=true;
	            document.getElementById('btnExecute').focus();
	            
	    }
	}
	return false;






return false;
}

var formopen = new Array(100);
var formopen12 =new Array(100);
var  handleform=new Array(100);
for(var z=0;z<99;z++)
    {
    
    formopen[z]="";
    
    }