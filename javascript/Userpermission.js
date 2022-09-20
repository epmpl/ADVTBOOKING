// JScript File
var hiddentext;
var mod="0";
var j=0;
var z=0;
var globaluser;
var browser=navigator.appName;
var glaobalschedule;
var listbox111 = new Array(9);
var listbox222 = new Array(9);

listbox111[0] = "Scheduling Head";
listbox111[1] = "Allow Block Agency";
listbox111[2] = "Allow Unblock Agency";
listbox111[3] = "Allow Changeing Insertion Fee";
listbox111[4] = "Allow Changeing Late Fee";
listbox111[5] = "Allow Changeing Incentives";
listbox111[6] = "Allow Unfinalize Supply Orders";
listbox111[7] = "Allow to mark bills undispute";
listbox111[8] = "Allow Unsold Cancellation Before Approval"
listbox111[9] = "Allow Unsold Cancellation After Approval"
//listbox111[10] = "Allow Editing Discount Item Line Wise"






function btnNewClick2()
{
    document.getElementById('drpuserid').value="";
    document.getElementById('drpschedule').value="0";

    //chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;
		
	hiddentext="new";
	document.getElementById('drpuserid').disabled=false;
    document.getElementById('drpschedule').disabled=false;
    
    document.getElementById('drpuserid').focus();
   // flag=0;
setButtonImages();
return false;
}
function btnCancelClick2(formname)
{
//chkstatus(FlagStatus);
//givebuttonpermission(formname);

    document.getElementById('drpuserid').value="";
    document.getElementById('drpschedule').value="0";
    
     document.getElementById('drpuserid').disabled=true;
    document.getElementById('drpschedule').disabled=true;
    
    document.getElementById('btnModify').disabled=true;
    document.getElementById('btnQuery').disabled=false;
    document.getElementById('btnnext').disabled=true;
	document.getElementById('btnlast').disabled=true;
	document.getElementById('btnDelete').disabled=true;
	document.getElementById('btnfirst').disabled=true;
	document.getElementById('btnprevious').disabled=true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnSave').disabled=true;
				
				mod="0";
    
    if(document.getElementById('btnNew').disabled==false)
    {
   // document.getElementById('btnNew').focus();
    }
    else
    {
    document.getElementById('btnNew').disabled=false;
	document.getElementById('btnNew').focus();
	}
	
setButtonImages();
return false;
}
function btnModifyClick2()
{
 mod="1";
	 hiddentext="mod";	
    document.getElementById('drpuserid').disabled=true;
    document.getElementById('drpschedule').disabled=false;
    chkstatus(FlagStatus);
    document.getElementById('btnQuery').disabled = true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnModify').disabled=false;
	document.getElementById('btnSave').disabled = false;
	document.getElementById('btnSave').focus();
    setButtonImages();
return false;
}
//var flag="";
function saveclick()
{
 
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       }
    if(document.getElementById('drpuserid').value=="" || document.getElementById('drpuserid').value=="0")
        {
        alert("Please Select User Name.");
        document.getElementById('drpuserid').focus();
        return false;
        }

//var user=document.getElementById('drpuserid').value;
//var compcode=document.getElementById('hiddencompcode').value;
//var schedule = document.getElementById('drpschedule').value;
callsave();
//if(mod !="1")
//    {
//    Userpermission.chkuser(compcode,user,callsave);
//    return false;
//    }
//    else
//    {
//     updateuser();
//    }
return false;
}
function  updateuser()
{
var user=document.getElementById('drpuserid').value;
var compcode=document.getElementById('hiddencompcode').value;
var schedule=document.getElementById('drpschedule').value;

Userpermission.update(compcode,user,schedule);

dspubexecute.Tables[0].Rows[z].SCHEDULING_HEAD=document.getElementById('drpschedule').value;

 alert("Data Updated Successfully");
        updateStatus();
        if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dspubexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       

    document.getElementById('drpuserid').disabled=true;
    document.getElementById('drpschedule').disabled=true;
         setButtonImages();
			 if(document.getElementById('btnModify').disabled==false)      
	          document.getElementById('btnModify').focus();
	mod="0";
			return false;
}   
    
function callsave()
{
//var ds;
//ds=res.value;
//if(ds.Tables[0].Rows.length > 0)
//    {
//    alert("This User Name is already assigned.");
//    document.getElementById('drpuserid').focus();
//    return false;
//    }
var user=document.getElementById('usercode').value;
var compcode=document.getElementById('hiddencompcode').value;
var schedule=document.getElementById('drpschedule').value;
var loguser=document.getElementById('hiddenuserid').value;
var listbox2j= document.getElementById('listbox1');
var permission_desc=document.getElementById('listbox2').options[0].text;
var delflag="NO";
        // Userpermission.persave(compcode, user, schedule, loguser, permission_desc, delflag, document.getElementById('txtkeyboard').value, document.getElementById('KEYBORD').value) 
            //for(var m=0; m <listbox2j.options.length; m++)
for (var m = 0; m < document.getElementById('listbox2').length; m++)
{
            //permission_desc=listbox2.options[m].text;
    permission_desc= document.getElementById('listbox2').options[m].text;
            // delflag="YES";
  if(permission_desc != "")
  {
      var res = Userpermission.persave(compcode, user, schedule, loguser, permission_desc, delflag, document.getElementById('txtkeyboard').value, document.getElementById('KEYBORD').value) 
    if(permission_desc == "Allow Unblock Agency")
    {
      if(document.getElementById('txtfrom_osbal').value == "")
      {
        alert("Please enter From O/S Balanace.");
//        document.getElementById('txtfrom_osbal').focus();
        return false;
      }
      else if(document.getElementById('txtto_osbal').value == "")
      {
        alert("Please enter To O/S Balanace.");
//        document.getElementById('txtto_osbal').focus();
        return false;
      }
      else if(document.getElementById('txtno_times').value == "")
      {
        alert("Please enter No of times.");
//        document.getElementById('txtno_times').focus();
        return false;
      }
       else if(document.getElementById('drpperiod').value == "0")
      {
        alert("Please enter Period.");
//        document.getElementById('drpperiod').focus();
        return false;
      }
      var from_osbal=document.getElementById('txtfrom_osbal').value;
      var to_osbal=document.getElementById('txtto_osbal').value;
      var no_oftimes=document.getElementById('txtno_times').value;
      var period=document.getElementById('drpperiod').value;
      var allow_flag="Y";
      Userpermission.persave_detail(user,permission_desc,from_osbal,to_osbal,no_oftimes,period,allow_flag,loguser);
    }
   
  }
}

//document.getElementById('btnNew').disabled=false;
//document.getElementById('btnSave').disabled=true;
//document.getElementById('btnModify').disabled=true;
//document.getElementById('btnDelete').disabled=true;
//document.getElementById('btnQuery').disabled=false;
//document.getElementById('btnExecute').disabled=true;
//document.getElementById('btnCancel').disabled=false;
//document.getElementById('btnfirst').disabled=true;
//document.getElementById('btnnext').disabled=true;
//document.getElementById('btnlast').disabled=true;

 document.getElementById('drpuserid').disabled=false;
document.getElementById('txtrole').disabled=false;
alert("Permission Updated Sucessfully");
document.getElementById('drpuserid').value="";
document.getElementById('txtrole').value = "";
listbox2j.options.length = 0;
document.getElementById('lbldetail').style.display = "none";
document.getElementById('txtdetail').style.display = "none";
document.getElementById('drpuserid').focus();
//btnCancelClick2('Userpermission');

return false;
}
function btnQueryClick2()
{
chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	hiddentext="query";
z=0;
document.getElementById('drpuserid').value="0";
document.getElementById('drpschedule').value="0";

 document.getElementById('drpuserid').disabled=false;
document.getElementById('drpschedule').disabled=false;
setButtonImages();

return false;
}

function btnExecuteClick2()
{
z=0;
var user=document.getElementById('drpuserid').value;
globaluser=user;
var compcode=document.getElementById('hiddencompcode').value;
var schedule=document.getElementById('drpschedule').value;
glaobalschedule=schedule;

 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
Userpermission.executeuser(compcode,user,schedule,callexec);
    updateStatus();
    
     document.getElementById('drpuserid').disabled=true;
    document.getElementById('drpschedule').disabled=true;
     
    mod="0";
			            document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;
						
					    if(document.getElementById('btnModify').disabled==false)
			                document.getElementById('btnModify').focus();
			return false;
    
}
function callexec(response)
{
    var ds=response.value;
	dspubexecute=response.value;
	    if(dspubexecute.Tables[0].Rows.length > 0)
	    {
			 	document.getElementById('drpuserid').value=GetUsername(dspubexecute.Tables[0].Rows[0].USERID);
			 	document.getElementById('drpschedule').value=dspubexecute.Tables[0].Rows[0].SCHEDULING_HEAD;
				
				document.getElementById('txtrole').value=GetRole(dspubexecute.Tables[0].Rows[0].USERID);
				document.getElementById('drpuserid').disabled=true;
                document.getElementById('drpschedule').disabled=true;
	    }
	    else
	    {
	        alert("Your Search Produce No Result!!!!");
			btnCancelClick2('Userpermission');
		}

         if(dspubexecute.Tables[0].Rows.length ==1)
			{
		        document.getElementById('btnfirst').disabled=true;				
		       document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnprevious').disabled=true;			
		       document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
			return false;
}
function GetUsername(userid)
{
    var username;
    if(userid != null && userid !="")
    {
      var res=Userpermission.get_username(userid);
      var ds=res.value;
      if(ds !=null && ds.Tables[0].Rows.length >0)
      {
         if(ds.Tables[0].Rows[0].user_name != undefined)
             username=ds.Tables[0].Rows[0].user_name;
         else
             username="";
         
      }
      return username; 
    }
}

function GetRole(userid)
{
    var rolename;
    if(userid != null && userid !="")
    {
      var res=Userpermission.Get_Rolename(userid);
      var ds=res.value;
      if(ds !=null && ds.Tables[0].Rows.length >0)
      {
         if(ds.Tables[0].Rows[0].role_name != undefined)         
            rolename=ds.Tables[0].Rows[0].role_name;
         else
            rolename="";
      }
      return rolename; 
    }
}
function firstclick()
{
            document.getElementById('drpuserid').value=dspubexecute.Tables[0].Rows[0].USERID;
			document.getElementById('drpschedule').value=dspubexecute.Tables[0].Rows[0].SCHEDULING_HEAD;
				
				z=0;
			updateStatus();

		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnExit').disabled=false;
		//fillAdCat1();
		setButtonImages();
			return false;
}
function previousclick()
{
var a=dspubexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
			    
			    document.getElementById('drpuserid').value=dspubexecute.Tables[0].Rows[z].USERID;
			 	document.getElementById('drpschedule').value=dspubexecute.Tables[0].Rows[z].SCHEDULING_HEAD;
			updateStatus();
				document.getElementById('btnfirst').disabled=false;				
		        document.getElementById('btnnext').disabled=false;				
		        document.getElementById('btnprevious').disabled=false;				
		        document.getElementById('btnlast').disabled=false;			
		        document.getElementById('btnExit').disabled=false;
				//fillAdCat1();
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
		{		document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				return false;
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
var a=dspubexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{

		    document.getElementById('drpuserid').value=dspubexecute.Tables[0].Rows[z].USERID;
			document.getElementById('drpschedule').value=dspubexecute.Tables[0].Rows[z].SCHEDULING_HEAD;
		    
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			//fillAdCat1();
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
function lastclick()
{
var y=dspubexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			//document.getElementById('drpuncent').value=dspubexecute.Tables[0].Rows[z].CENTERCODE;
			document.getElementById('drpuserid').value=dspubexecute.Tables[0].Rows[z].USERID;
			document.getElementById('drpschedule').value=dspubexecute.Tables[0].Rows[z].SCHEDULING_HEAD;
			
			updateStatus();
			//fillAdCat1();
		    document.getElementById('btnnext').disabled=true;
            document.getElementById('btnlast').disabled=true;
            document.getElementById('btnfirst').disabled=false;
            document.getElementById('btnprevious').disabled=false;
            setButtonImages();
			return false;
}
function exitclick()
{
//if(confirm("Do You Want To Skip This Page"))
			//{
				window.close();
				return false;
			//}
			//return false;
}
function deleteclick()
{
    updateStatus();
var user=document.getElementById('drpuserid').value;
var compcode=document.getElementById('hiddencompcode').value;
    
    if( confirm("Are You Sure To Delete The Data ?"));
			{
			 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
       Userpermission.userdelete(compcode, user);

			alert ("Data Deleted Successfully");
			document.getElementById('drpuserid').value="0";
            document.getElementById('drpschedule').value="0";
		

		       Userpermission.executeuser(compcode,globaluser,glaobalschedule,delcall);
		     }
		     return false;
}
function delcall(res)
{
 dscatexecute= res.value;
	len=dscatexecute.Tables[0].Rows.length;
	
	if(dscatexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
	        document.getElementById('drpuserid').value="0";
            document.getElementById('drpschedule').value="0";
		 btnCancelClick2('Userpermission');
		return false;
	}
	        else if(z>=len || z==-1)
	        {
			//document.getElementById('drpuncent').value=dscatexecute1.Tables[0].Rows[0].CENTERCODE;
				document.getElementById('drpuserid').value=dspubexecute.Tables[0].Rows[0].USERID;
			    document.getElementById('drpschedule').value=dspubexecute.Tables[0].Rows[0].SCHEDULING_HEAD;
        			
	        }
	        else
	        {
	        //document.getElementById('drpuncent').value=dscatexecute1.Tables[0].Rows[z].CENTERCODE;
	            document.getElementById('drpuserid').value=dspubexecute.Tables[0].Rows[z].USERID;
			    document.getElementById('drpschedule').value=dspubexecute.Tables[0].Rows[z].SCHEDULING_HEAD;
	        
	        }
		if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dscatexecute.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       
            if(dscatexecute.Tables[0].Rows.length ==1)
			{
		        document.getElementById('btnfirst').disabled=true;				
		       document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnprevious').disabled=true;			
		       document.getElementById('btnlast').disabled=true;
			}
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
//=========function to change image of buttons
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

function binduser(event)
{
//  if(document.activeElement.id=="drpuserid")
    //  {
var key=event.keyCode?event.keyCode:event.which;
if (key == 27) {
    if (document.activeElement.id == "lst_user") {
        document.getElementById('div1').style.display = "none";

    }
    }
//    if (key == 13) {
//        if (document.activeElement.id == "lstmaingrp") {
//            fillmaingrp(event);
//        }

//    }
     if((key == 8)||(key == 46))
       {
           document.getElementById('txtrole').value = "";
           document.getElementById('usercode').value = "";
           document.getElementById('drpuserid').value = "";
           document.getElementById('listbox2').options.length = 0; 
       }

       if (key == 113) {
           var compcode = document.getElementById('hiddencompcode').value;
           var userid = document.getElementById('hiddenuserid').value;
           var userhome = document.getElementById('hiddenuserhome').value;
           var revenue = document.getElementById('hiddenrevenue').value;
           var admin = document.getElementById('hiddenadmin').value;

           document.getElementById("div1").style.display = "block";
           document.getElementById('div1').style.top = findPos(document.getElementById("drpuserid"), "top");
           document.getElementById('div1').style.left = findPos(document.getElementById("drpuserid"), "left");
           document.getElementById('lst_user').value = "0";
           document.getElementById('lst_user').focus();

           var res = Userpermission.UserBind(compcode, userid, userhome, revenue, admin);
           var ds = res.value;
           if (ds != null && ds.Tables[0].Rows.length > 0) {
               var pkgitem = document.getElementById("lst_user");
               pkgitem.options.length = 0;
               pkgitem.options[0] = new Option("-Select user-", "0");
               pkgitem.options.length = 1;
               for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                   pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username + "--" + ds.Tables[0].Rows[i].userid + "--" + fndnull(ds.Tables[0].Rows[i].ROLE_NAME), ds.Tables[0].Rows[i].userid);
                   pkgitem.options.length;
               }
           }
           //  }
       }
    return false;
}

function filluser(event)
 {
        var keycode=event.keyCode?event.keyCode:event.which;
        if(keycode==13 ||event.type=="click")
         {
            if(document.activeElement.id=="lst_user")
            {
                     if(document.getElementById('lst_user').value=="0")
                     {
                          alert("Please select user");
                          return false;
                     }
                     document.getElementById("div1").style.display="none";              
                     var page=document.getElementById('lst_user').value;
                     loccode=page;     
          
                     for(var k=0;k <= document.getElementById("lst_user").length-1;k++)
                     {
                            if(document.getElementById('lst_user').options[k].value==page)
                            {
                            if(browser=="Microsoft Internet Explorer")
                            {
                                var abc=document.getElementById('lst_user').options[k].innerText;
                                }
                                else
                                {
                                var abc=document.getElementById('lst_user').options[k].textContent;
                                }
                                var fival = abc.split("--");  
                                 document.getElementById('usercode').value=fival[1];
                                 document.getElementById('drpuserid').value = fival[0];
                                 document.getElementById('txtrole').value=fival[2];
                                 document.getElementById('txtrole').disabled=true;
                                 document.getElementById('drpuserid').focus();
                                 break;
                            }
                       }
                   }
               }
               
      }
      
      function findPos(obj,val) {
    var curleft = curtop = 0;

    if (obj.offsetParent) {
        curleft = obj.offsetLeft

        curtop = obj.offsetTop

        while (obj = obj.offsetParent) {
            curleft += obj.offsetLeft

            curtop += obj.offsetTop

        }

    }
    curtop = curtop += 5;
    if (val == "top")
        return curtop +"px";
    else
        return curleft + "px";
}

function Copyfield()
{
        var listbox1j= document.getElementById('listbox1');
        var listbox2j= document.getElementById('listbox2');
        var index1 = document.getElementById('listbox1').options.selectedIndex;
        if(index1 == -1)
        {
       
              alert('Please select the value ');
              return false;
       
        }
         var value1 = document.getElementById('listbox1').options[index1].text
         for (var i = 0; i < listbox1j.options.length; i++)
        {
                if(listbox222[i] == value1)
                {
                    alert('Permission is already selected.');
                    return false;
                }    
        }

        for (var i = 0; i < listbox1j.options.length; i++)
        {
            //if(listbox111[i] == value1)
            if(listbox1j.options[i].selected == true)
            {
                listbox2j.options[listbox2j.options.length] = new Option(listbox1j[i].text);//listbox111[i]);
                    listbox222[j] = listbox111[i];
                    listbox1j.options[i].selected=false;
                    j++;    
            } 
        }
        return false;
}


function removefieldname()
{
  
       var listbox1j= document.getElementById('listbox1');
       var listbox2j= document.getElementById('listbox2');
       var index1 = document.getElementById('listbox2').options.selectedIndex;
       if(index1 == -1 )
       {
           alert('There is no value in selected field');
           return false;
       }
       
       var value1 = document.getElementById('listbox2').options[index1].text
       var length1 = listbox2j.options.length

     //   listbox2j.options.length=0;
       // listbox2j.value="0";
//        for(var i=0 ; i<length1; i++)
//        {
//            if(listbox111[i] != value1)
//            {
//                 listbox2j.options[listbox2j.options.length] = new Option(listbox111[i]);
//      
//            }     
//        }

         for(var i=0 ; i<length1; i++)
         {
             //if(listbox222[i] != undefined)
              if(listbox2j.options[i].selected == true)
             {
                   // if(listbox222[i] == value1)
                   // {
                    listbox222[i] = ""; 
                    listbox2j.options[i].text   ="";
                  //  } 
             }
         }
    return false;
}

function Copyall()
{
     var listbox1j= document.getElementById('listbox1');
     var listbox2j= document.getElementById('listbox2');
//     for(var i=listbox2j.options.length - 1 ; i >=0; i--)
//     {
//         listbox2j.options[i] = null;
//     }
     listbox2j.selectedIndex = -1;
//     for(var j=0 ; j<8 ; j++)
//     {    
//         listbox111[j] = "";
//     } 

    listbox2j.options.length = 0;
    for (var i = 0; i < listbox1j.options.length; i++)
    {
        listbox2j.options[listbox2j.options.length] = new Option(listbox1j[i].text); //jlistbox111[i]);
       listbox222[i] = listbox111[i];
 
    }
    return false;
}

function removeallfieldname()
{
    var listbox2j=document.getElementById('listbox2');
    for(var i=listbox2j.options.length - 1 ; i >=0; i--)
    {
     
        listbox2j.options[i] = null;
      
    }
    listbox2j.selectedIndex = -1;
    for(var j=0 ; j< 29 ; j++)
    {    
         listbox222[j] = "";
    } 
   return false;
}

function showdetail(listboxid)
{
    if(listboxid == "listbox1")
    {
          var listbox1j= document.getElementById('listbox1');
          for(var i=0; i<listbox1j.options.length; i++)
          {
               if(listbox1j.options[i].selected == true)
               {
                    if(listbox1j.options[i].text == "Allow Unblock Agency")
                    {
                       document.getElementById('lbldetail').style.display="block";
                       document.getElementById('txtdetail').style.display="block";
                    }
                    else
                    {
                       document.getElementById('lbldetail').style.display="none";
                       document.getElementById('txtdetail').style.display="none";
                    }
               }
           }
      }
      else if(listboxid == "listbox2")
      {
          var listbox2j= document.getElementById('listbox2');
          for(var i=0; i<listbox2j.options.length; i++)
          {
               if(listbox2j.options[i].selected == true)
               {
                    if(listbox2j.options[i].text == "Allow Unblock Agency")
                    {
                       document.getElementById('lbldetail').style.display="block";
                       document.getElementById('txtdetail').style.display="block";
                    }
                    else
                    {
                       document.getElementById('lbldetail').style.display="none";
                       document.getElementById('txtdetail').style.display="none";
                    }
               }
           }
      }
  return false;   
 }

function filluser_permission()
{
   var listbox2j= document.getElementById('listbox2');
   var userid = document.getElementById('usercode').value;
   var drpuserid = document.getElementById('drpuserid').value;
   var compcode=document.getElementById('hiddencompcode').value;
   var login_userid=document.getElementById('hiddenuserid').value;
   var per_desc="";
   if (userid != "" && drpuserid != "")
   {
       var res=Userpermission.Fetchuser_permission(userid,compcode,login_userid,per_desc);
       var ds=res.value;
       if(ds != null && ds.Tables[0].Rows.length >0)
       {
            listbox2j.options.length=0;            
            for (i = 0; i < ds.Tables[0].Rows.length; ++i)
            {
                listbox2j.options[listbox2j.options.length] = new Option(ds.Tables[0].Rows[i].PERMISSION_DESC);
                listbox2j.options.length; 
            }
            document.getElementById("div1").style.display="none";
       }
       if(ds.Tables[1].Rows.length >0)
       {
         document.getElementById('lbldetail').style.display="block";
         document.getElementById('txtdetail').style.display="block";
         document.getElementById('txtfrom_osbal').value=ds.Tables[1].Rows[0].FROM_OS_BAL;
         document.getElementById('txtto_osbal').value=ds.Tables[1].Rows[0].TILL_OS_BAL;
         document.getElementById('txtno_times').value=ds.Tables[1].Rows[0].NO_OF_TIMES;
         document.getElementById('drpperiod').value = ds.Tables[1].Rows[0].PERIOD_FREQ;
     }
     if (ds.Tables[0].Rows.length > 0) {
         document.getElementById('txtkeyboard').value = fndnull(ds.Tables[0].Rows[0].KEYBOARD);
         document.getElementById('KEYBORD').value = fndnull(ds.Tables[0].Rows[0].KEYBOARDTYPE);
     }
   }
   return false;
}

function fndnull(myval) {
    if (myval == "undefined") {
        myval = "";
    }
    else if (myval == null) {
        myval = "";
    }
    return myval
}