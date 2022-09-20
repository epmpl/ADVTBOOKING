// JScript File

var z=0;

var flag;	
	//var k=0;



var hiddentext;
var allmoduleds;
var gname;
var glcode;
var gldesig;
var glname;
var gllevel;
var glmail;
var gldisc;


function newall()
{
	 var msg=checkSession();
        if(msg==false)
        return false;
	
        //alert("hi");
				
				flag=1;
				
				 if(document.getElementById('hiddenauto').value==1)
		         {
		        document.getElementById('txtcode').disabled=true;
    	         }
		        else
		         {
		        document.getElementById('txtcode').disabled=false;
    	         }

				
			//==============navigation================
				/*document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=false;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExit').disabled=false;*/
				hiddentext="new";
				
				document.getElementById('drpdesignation').value=0;
				document.getElementById('txtcode').value="";
				document.getElementById('txtname').value="";
				document.getElementById('txtlevel').value="";
				document.getElementById('txtmailid').value="";
				document.getElementById('txtdiscount').value="";
				document.getElementById('drpstatus').value=0;
		
				
			    chkstatus(FlagStatus);
			    document.getElementById('btnSave').disabled = false;	
                document.getElementById('btnNew').disabled = true;	
                document.getElementById('btnQuery').disabled=true;
				
				document.getElementById('drpdesignation').disabled=false;
	        	document.getElementById('txtname').disabled=false;
				document.getElementById('txtlevel').disabled=false;
				document.getElementById('txtmailid').disabled=false;
				document.getElementById('txtdiscount').disabled=false;
				document.getElementById('drpstatus').disabled=false;
				
				if(document.getElementById('hiddenauto').value==1)
				{
				
				  document.getElementById('txtname').focus();
			    } 
			    else
			    {
			    document.getElementById('txtcode').focus();
				}
				
				
				setButtonImages();
			return false;
			}
			
			
function cancel(formname)
{
			   
				/*document.getElementById('btnNew').disabled=false;
				document.getElementById('btnNew').focus();
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;*/
				
			    chkstatus(FlagStatus);
                givebuttonpermission(formname);
				
				document.getElementById('drpdesignation').disabled=true;
	        	document.getElementById('txtcode').disabled=true;
				document.getElementById('txtname').disabled=true;
				document.getElementById('txtlevel').disabled=true;
				document.getElementById('txtmailid').disabled=true;
				document.getElementById('txtdiscount').disabled=true;
			    document.getElementById('drpstatus').disabled=true;
				
			    document.getElementById('drpdesignation').value=0;
				document.getElementById('txtcode').value="";
				document.getElementById('txtname').value="";
				document.getElementById('txtlevel').value="";
				document.getElementById('txtmailid').value="";
				document.getElementById('txtdiscount').value="";
				document.getElementById('drpstatus').value=0;
                setButtonImages();
                if(document.getElementById('btnNew').disable==false)
                  document.getElementById('btnNew').focus();
				return false;
			}
			
function saveall()
{
   var msg=checkSession();
        if(msg==false)
        return false;
        
        //dan
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

       if (flag == 1)
	{

	    if (document.getElementById('txtname').value == "") {
	        alert("Please Enter  Name");
	        document.getElementById('txtname').focus();
	        return false;
	    }

	
	
		if(document.getElementById('drpdesignation').value=="0")
		{
		    alert("Please select Designation");
		    document.getElementById('drpdesignation').focus();
		    return false;
		}

		var chmandat;
		if (browser != "Microsoft Internet Explorer") {
		    chmandat = document.getElementById('status').textContent;
		}
		else {
		    chmandat = document.getElementById('status').innerText;
		}
		if (chmandat.indexOf('*') >= 0) {
		    if (document.getElementById('drpstatus').value == "0" || document.getElementById('drpstatus').value == "") {
		        alert("Please Select Status ");
		        return false;
		    }
		}
		
		
		if(document.getElementById('hiddenauto').value!=1)
		{
		document.getElementById('txtcode').value=trim(document.getElementById('txtcode').value);
		if(document.getElementById('txtcode').value=="")
		{
		    alert("Please Enter  Code");
		    document.getElementById('txtcode').focus();
		    return false;
		}
		}
		

		
		if(document.getElementById('txtlevel').value=="")
		{
		    alert("Please Enter Level");
		    document.getElementById('txtlevel').focus();
		    return false;
		}
		
		
		 if(document.getElementById('txtmailid').value=="")
		{
		    alert("Please Enter Mail-Id");
		    document.getElementById('txtmailid').focus();
		    return false;
		}
		
		
		if(document.getElementById('txtdiscount').value=="")
		{
		    alert("Please Enter Discount Amount!");
		    document.getElementById('txtdiscount').focus();
		    return false;
		}
		
		

		
		
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpdesignation').value;
		var code =trim(document.getElementById('txtcode').value);
		var name =trim(document.getElementById('txtname').value);
		var level =trim(document.getElementById('txtlevel').value);
		var mailid =trim(document.getElementById('txtmailid').value);
		var disc=trim(document.getElementById('txtdiscount').value);
		var userid=document.getElementById('hiddenuserid').value; 
		
		
		All_module_master.codechk(compcode,code,userid,savenew)
		return false;
		
	}
	else
	{
		savemodify();
	    return false;
	}

}


function savenew(res)
{     
 var msg=checkSession();
        if(msg==false)
        return false;
        var ds=res.value;
        if(ds==null)
        {
          alert(res.error.description);
          return false;
        }
        if(document.getElementById('txtcode').value=="")
		{
			    alert("Please Enter Code");
			    if(document.getElementById('txtcode').disabled==false)
				{
				    document.getElementById('txtcode').focus();
				}
			    return false;
		}
			
		if(ds.Tables[0].Rows.length > 0)
		{
				alert("This  Code Is Already Exist, Try Another Code !!!!");
				document.getElementById('txtcode').value="";
				if(document.getElementById('txtcode').disabled==false)
				{
				    document.getElementById('txtcode').focus();
				    return false;
				}
				return false;
		} 
        if(ds.Tables[0].Rows.length==0)
        {
            if(document.getElementById('drpdesignation').value=="0")
		    {
    		
		        alert("Please select Designation ");
		        document.getElementById('drpdesignation').focus();
		        return false;
		    }
		
		  if((document.getElementById('txtcode').value=="")&&(document.getElementById('hiddenauto').value!=1))
		   {
		        alert("Please Enter  Code");
		        document.getElementById('txtcode').focus();
		        return false;
		   }
		
		
		if (document.getElementById('txtname').value=="")
		{
		    alert("Please Enter  Name");
		    document.getElementById('txtname').focus();
		    return false;
		}
		
		 if(document.getElementById('txtlevel').value=="")
		{
		    alert("Please Enter Level");
		    document.getElementById('txtlevel').focus();
		    return false;
		}
		
		
		 if(document.getElementById('txtmailid').value=="")
		{
		alert("Please Enter Mail-Id");
		document.getElementById('txtmailid').focus();
		return false;
		}
		
		
		if(document.getElementById('txtdiscount').value=="")
		{
		alert("Please Enter Discount Amount!");
		document.getElementById('txtdiscount').focus();
		return false;
		}
		
		
		if(document.getElementById('txtdiscount').value>100)
		{
		alert(" Discount Amount can't Exceed 100!");
		document.getElementById('txtdiscount').focus();
		return false;
		}
		var chmandat;
if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('status').textContent;
}
else
{
chmandat=document.getElementById('status').innerText;
}
if(chmandat.indexOf('*')>= 0)
{
if(document.getElementById('drpstatus').value=="0" || document.getElementById('drpstatus').value=="")
{
alert("Please Select Status ");
return false;
}
}
		
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpdesignation').value;
		var code =trim(document.getElementById('txtcode').value);
		var name =trim(document.getElementById('txtname').value);
		var level =trim(document.getElementById('txtlevel').value);
		var mailid =trim(document.getElementById('txtmailid').value);
		var disc=trim(document.getElementById('txtdiscount').value);
		var userid=document.getElementById('hiddenuserid').value; 
		var status=document.getElementById('drpstatus').value;
		All_module_master.all_modsave(compcode,catcode,code,name,level,mailid,disc,userid,status)
		
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
					
		document.getElementById('drpdesignation').value=0;
		document.getElementById('txtcode').value="";
		document.getElementById('txtname').value="";
		document.getElementById('txtlevel').value="";
		document.getElementById('txtmailid').value="";
		document.getElementById('txtdiscount').value="";
		document.getElementById('drpstatus').value=0;

		document.getElementById('drpdesignation').disabled=true;
    	document.getElementById('txtcode').disabled=true;
		document.getElementById('txtname').disabled=true;
		document.getElementById('txtlevel').disabled=true;
		document.getElementById('txtmailid').disabled=true;
		document.getElementById('txtdiscount').disabled=true;
		document.getElementById('drpstatus').disabled=true;	
				
		alert("Data Saved");
		setButtonImages();
		return false;
}
else
{
	       // document.getElementById('txtalias').value="";
		    document.getElementById('txtname').value="";
		    alert("This  Code has already assigned !! ");
		    
		    document.getElementById('txtname').focus();
  
//return false;
}
return false;
}


function savemodify()
{

        
      if(document.getElementById('drpdesignation').value=="0")
		{
		
		alert("Please select Designation ");
		document.getElementById('drpdesignation').focus();
		return false;
		}
		
		if (document.getElementById('txtname').value=="")
		{
		alert("Please Enter  Name");
		document.getElementById('txtname').focus();
		return false;
		}
		
		 if(document.getElementById('txtlevel').value=="")
		{
		alert("Please Enter Level");
		document.getElementById('txtlevel').focus();
		return false;
		}
		
		if(document.getElementById('txtmailid').value=="")
		{
		alert("Please Enter Mail-Id");
		document.getElementById('txtmailid').focus();
		return false;
		}
		
		if(document.getElementById('txtdiscount').value=="")
		{
		alert("Please Enter Discount Amount!");
		document.getElementById('txtdiscount').focus();
		return false;
		}
				
		if(document.getElementById('txtdiscount').value>100)
		{
		alert(" Discount Amount can't Exceed 100!");
		document.getElementById('txtdiscount').focus();
		return false;
		}
			
			var chmandat;
if(browser!="Microsoft Internet Explorer")
{
chmandat=document.getElementById('status').textContent;
}
else
{
chmandat=document.getElementById('status').innerText;
}
if(chmandat.indexOf('*')>= 0)
{
if(document.getElementById('drpstatus').value=="0" || document.getElementById('drpstatus').value=="")
{
alert("Please Select Status ");
return false;
}
}
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpdesignation').value;
		var code =trim(document.getElementById('txtcode').value);
		var name =trim(document.getElementById('txtname').value);
		var level =trim(document.getElementById('txtlevel').value);
		var mailid =trim(document.getElementById('txtmailid').value);
		var disc=trim(document.getElementById('txtdiscount').value);
		var userid=document.getElementById('hiddenuserid').value; 
		var status=document.getElementById('drpstatus').value;
		All_module_master.allmodupdate(compcode,catcode,code,name,level,mailid,disc,userid,status)
		
		alert("Data Modified");
	
		allmoduleds.Tables[0].Rows[z].All_module_code=code;
		allmoduleds.Tables[0].Rows[z].Designation=catcode;
		allmoduleds.Tables[0].Rows[z].Name_all=name;
		allmoduleds.Tables[0].Rows[z].all_level=level;
		allmoduleds.Tables[0].Rows[z].mail_id=mailid;
		allmoduleds.Tables[0].Rows[z].discount_allow=disc;
		
		updateStatus();
		
		if(allmoduleds.Tables[0].Rows.length==1)
			{
			    document.getElementById('btnfirst').disabled=true;
			    document.getElementById('btnprevious').disabled=true;				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
			}
		if(z==0)
			{
			    document.getElementById('btnfirst').disabled=true;
			    document.getElementById('btnprevious').disabled=true;				
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
			}
		else if(z==allmoduleds.Tables[0].Rows.length-1)
			{
			    document.getElementById('btnfirst').disabled=false;
			    document.getElementById('btnprevious').disabled=false;				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
			}	
	    if(document.getElementById('btnModify').disabled==false)	
	     document.getElementById('btnModify').focus();
	      		
		document.getElementById('drpdesignation').disabled=true;
    	document.getElementById('txtcode').disabled=true;
		document.getElementById('txtname').disabled=true;
		document.getElementById('txtlevel').disabled=true;
		document.getElementById('txtmailid').disabled=true;	
		document.getElementById('txtdiscount').disabled=true;
		document.getElementById('drpstatus').disabled=true;	
		setButtonImages();
		return false;

}


function modify()
{
	    flag=2 ;
	    hiddentext="modify";
	   /* document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=false;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnQuery').disabled=true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnCancel').disabled=false;		
		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnnext').disabled=true;					
		document.getElementById('btnprevious').disabled=true;			
		document.getElementById('btnlast').disabled=true;			
		document.getElementById('btnExit').disabled=false;*/
		chkstatus(FlagStatus);

        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnSave').focus();
		gname=document.getElementById('txtname').value;		
		document.getElementById('drpdesignation').disabled=false;
    	document.getElementById('txtcode').disabled=true;
		document.getElementById('txtname').disabled=false;
		document.getElementById('txtlevel').disabled=false;
		document.getElementById('txtmailid').disabled=false;
		document.getElementById('txtdiscount').disabled=true;
		document.getElementById('txtdiscount').disabled=false;
		document.getElementById('drpstatus').disabled=false;	
        setButtonImages();
		return false;
}



function query()
{
       chkstatus(FlagStatus);

		document.getElementById('btnNew').disabled=true;
		document.getElementById('btnQuery').disabled=true;
		document.getElementById('btnExecute').disabled=false;
		document.getElementById('btnSave').disabled=true;
				
	    hiddentext="query";	
		document.getElementById('drpdesignation').disabled=false;
    	document.getElementById('txtcode').disabled=false;
		document.getElementById('txtname').disabled=false;
		document.getElementById('txtlevel').disabled=false;
		document.getElementById('txtmailid').disabled=false;
		document.getElementById('txtdiscount').disabled=false;	
		
		document.getElementById('drpdesignation').value=0;
		document.getElementById('txtcode').value="";
		document.getElementById('txtname').value="";
		document.getElementById('txtlevel').value="";
		document.getElementById('txtmailid').value="";
		document.getElementById('txtdiscount').value="";
		document.getElementById('drpstatus').value=0;
		document.getElementById('txtcode').focus();
				
		z=0;
		setButtonImages();
		return false;

}



function execute()
{
//alert(All_Module_master);
     var msg=checkSession();
        if(msg==false)
        return false;
	
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpdesignation').value;
		var code =document.getElementById('txtcode').value;
		var name =document.getElementById('txtname').value;
		var level =document.getElementById('txtlevel').value;
		var mailid =document.getElementById('txtmailid').value;
		var disc=document.getElementById('txtdiscount').value;
		var userid=document.getElementById('hiddenuserid').value; 
		
		//dan
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
All_module_master.allmodexecute(compcode,catcode,code,name,level,mailid,disc,userid,execall)
		updateStatus();
		
		 glcode=code;
		 gldesig=catcode;
         glname=name;
         gllevel=level;
         glmail=mailid;
         gldisc=disc;

		document.getElementById('btnfirst').disabled=true;				
        document.getElementById('btnnext').disabled=false;					
        document.getElementById('btnprevious').disabled=true;			
        document.getElementById('btnlast').disabled=false;	
        if(document.getElementById('btnModify').disabled==false)					
           document.getElementById('btnModify').focus();	
		
					
		document.getElementById('drpdesignation').disabled=true;
    	document.getElementById('txtcode').disabled=true;
		document.getElementById('txtname').disabled=true;
		document.getElementById('txtlevel').disabled=true;
		document.getElementById('txtmailid').disabled=true;	
		document.getElementById('txtdiscount').disabled=true;
		document.getElementById('drpstatus').disabled=true;	
							
		return false;

}

function execall(response)
{
	
	allmoduleds=response.value;
	if(allmoduleds!=null)
	{
	  if(allmoduleds.Tables[0].Rows.length>0)
	  {
		    document.getElementById('drpdesignation').value=allmoduleds.Tables[0].Rows[0].Designation;
		    document.getElementById('txtcode').value=allmoduleds.Tables[0].Rows[0].All_module_code	;
		    document.getElementById('txtname').value=allmoduleds.Tables[0].Rows[0].Name_all	;
		    document.getElementById('txtlevel').value=allmoduleds.Tables[0].Rows[0].all_level;
		    document.getElementById('txtmailid').value=allmoduleds.Tables[0].Rows[0].mail_id;
		    document.getElementById('txtdiscount').value=allmoduleds.Tables[0].Rows[0].discount_allow;
		document.getElementById('drpstatus').value=allmoduleds.Tables[0].Rows[0].STATUS;
//			document.getElementById('btnfirst').disabled=true;
//	        document.getElementById('btnprevious').disabled=true;
	        
        	if(allmoduleds.Tables[0].Rows.length==1)
		   	{
		   	document.getElementById('btnprevious').disabled=true;	
            document.getElementById('btnlast').disabled=true;	
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnnext').disabled=true;
            }
	        setButtonImages();
			return false;
	}
				
	else
	{
	        document.getElementById('btnModify').disabled=true;
	        document.getElementById('btnDelete').disabled=true;
	        alert("Your search Criteria Does Not Exist");
	        cancel('All_module_master');
	        return false;
	}
  }
  setButtonImages();
		return false;
}
		
		
	

function first()
{
 var msg=checkSession();
        if(msg==false)
        return false;
           z=0;
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var code=document.getElementById('txtcode').value;
			
			document.getElementById('drpdesignation').value=allmoduleds.Tables[0].Rows[0].Designation;
			document.getElementById('txtcode').value=allmoduleds.Tables[0].Rows[0].All_module_code	;
			document.getElementById('txtname').value=allmoduleds.Tables[0].Rows[0].Name_all	;
			document.getElementById('txtlevel').value=allmoduleds.Tables[0].Rows[0].all_level;
			document.getElementById('txtmailid').value=allmoduleds.Tables[0].Rows[0].mail_id;
			document.getElementById('txtdiscount').value=allmoduleds.Tables[0].Rows[0].discount_allow;
			document.getElementById('drpstatus').value=allmoduleds.Tables[0].Rows[0].STATUS;		
            document.getElementById('btnCancel').disabled=false;
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnnext').disabled=false;
            document.getElementById('btnprevious').disabled=true;
            document.getElementById('btnlast').disabled=false;
            document.getElementById('btnExit').disabled=false;
            setButtonImages();
		    return false;

}

function previous()
{
 var msg=checkSession();
        if(msg==false)
        return false;

		var compcode=document.getElementById('hiddencomcode').value;
		var userid=document.getElementById('hiddenuserid').value;
	    var code=document.getElementById('txtcode').value;
		
		z--;
	
	    var x=allmoduleds.Tables[0].Rows.length;
	
		if(z>x)
		{
            document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
        return false;
		}
		
		if(z!=-1 && z>=0)
		{
			if(allmoduleds.Tables[0].Rows.length != z && z < x)
			{
					
			    document.getElementById('drpdesignation').value=allmoduleds.Tables[0].Rows[z].Designation;
			    document.getElementById('txtcode').value=allmoduleds.Tables[0].Rows[z].All_module_code	;
			    document.getElementById('txtname').value=allmoduleds.Tables[0].Rows[z].Name_all	;
			    document.getElementById('txtlevel').value=allmoduleds.Tables[0].Rows[z].all_level;
			    document.getElementById('txtmailid').value=allmoduleds.Tables[0].Rows[z].mail_id;
			    document.getElementById('txtdiscount').value=allmoduleds.Tables[0].Rows[z].discount_allow;
    			document.getElementById('drpstatus').value=allmoduleds.Tables[0].Rows[z].STATUS;
    			
			    document.getElementById('btnfirst').disabled=false;				
			    document.getElementById('btnnext').disabled=false;					
			    document.getElementById('btnprevious').disabled=false;			
			    document.getElementById('btnlast').disabled=false;
						
			}
			else
			{
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=false;
				return false;
		    }
			
			
		}
		else
		{
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=false;
				return false;

		}	

        if (z<=0)
        {
	        document.getElementById('btnfirst').disabled=true;				
	        document.getElementById('btnnext').disabled=false;					
	        document.getElementById('btnprevious').disabled=true;			
	        document.getElementById('btnlast').disabled=false;	
	        setButtonImages();
            return false;		
        }

setButtonImages();
return false;

}

function next()
{
 var msg=checkSession();
        if(msg==false)
        return false;
	var compcode=document.getElementById('hiddencomcode').value;
	var userid=document.getElementById('hiddenuserid').value;
    var code=document.getElementById('txtcode').value;
	z++;
	var x=allmoduleds.Tables[0].Rows.length;
	
	if(z <= x && z !=-1)
	{
		if(allmoduleds.Tables[0].Rows.length != z && z >= 0)
		{
            document.getElementById('drpdesignation').value=allmoduleds.Tables[0].Rows[z].Designation;
			document.getElementById('txtcode').value=allmoduleds.Tables[0].Rows[z].All_module_code	;
			document.getElementById('txtname').value=allmoduleds.Tables[0].Rows[z].Name_all	;
			document.getElementById('txtlevel').value=allmoduleds.Tables[0].Rows[z].all_level;
			document.getElementById('txtmailid').value=allmoduleds.Tables[0].Rows[z].mail_id;
			document.getElementById('txtdiscount').value=allmoduleds.Tables[0].Rows[z].discount_allow;
			document.getElementById('drpstatus').value=allmoduleds.Tables[0].Rows[z].STATUS;
			
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=false;
					
	} 
	else
	{
            document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
			return false;
		
	}

  }
  else
    {
        document.getElementById('btnfirst').disabled=false;				
	    document.getElementById('btnnext').disabled=true;					
	    document.getElementById('btnprevious').disabled=false;			
	    document.getElementById('btnlast').disabled=true;
	    return false;

    }
    if(z==x-1)
    {
        document.getElementById('btnnext').disabled=true;
	    document.getElementById('btnlast').disabled=true;
	    document.getElementById('btnfirst').disabled=false;
	    document.getElementById('btnprevious').disabled=false;
    }
    setButtonImages();
return false;

}


function last()
{
 var msg=checkSession();
        if(msg==false)
        return false;
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
		    var code=document.getElementById('txtcode').value;
			//All_Module_master.subcatlast(compcode,catcode,userid,lastcall)
			
		    var x=allmoduleds.Tables[0].Rows.length;
		    z=x-1;
		    x=x-1;

			document.getElementById('drpdesignation').value=allmoduleds.Tables[0].Rows[x].Designation;
			document.getElementById('txtcode').value=allmoduleds.Tables[0].Rows[x].All_module_code	;
			document.getElementById('txtname').value=allmoduleds.Tables[0].Rows[x].Name_all	;
			document.getElementById('txtlevel').value=allmoduleds.Tables[0].Rows[x].all_level;
			document.getElementById('txtmailid').value=allmoduleds.Tables[0].Rows[x].mail_id;
			document.getElementById('txtdiscount').value=allmoduleds.Tables[0].Rows[x].discount_allow;
document.getElementById('drpstatus').value=allmoduleds.Tables[0].Rows[x].STATUS;


			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;
            setButtonImages();
            return false;


}

function deleteall()
{
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpdesignation').value;
		var code =document.getElementById('txtcode').value;
		var name =document.getElementById('txtname').value;
		var level =document.getElementById('txtlevel').value;
		var mailid =document.getElementById('txtmailid').value;
		var disc=document.getElementById('txtdiscount').value;
		var userid=document.getElementById('hiddenuserid').value; 
		var userid=document.getElementById('drpstatus').value;
		if(confirm("Are You Sure To Delete The Data ?"))
		{
		//dan
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
All_module_master.allmoddel(compcode,code,userid);
		alert("Record Deleted Successfully.");
		
		All_module_master.allmodexecute(compcode,gldesig,glcode,glname,gllevel,glmail,gldisc,userid,call_deleteall)
		//All_Module_master.subcatlast(compcode,catcode,userid,call_deleteadsubcode);
		}
		return false;
		
}
		
function call_deleteall(response)
{

    allmoduleds=response.value;
	var a=allmoduleds.Tables[0].Rows.length;
	var y=a-1;
	
	if( y <=0 )
	{
	    alert("No More Data is here to be deleted");
	    document.getElementById('drpdesignation').value=0;
		document.getElementById('txtcode').value="";
		document.getElementById('txtname').value="";
		document.getElementById('txtlevel').value="";
		document.getElementById('txtmailid').value="";
		document.getElementById('txtdiscount').value="";
		document.getElementById('drpstatus').value = 0;
        cancel('All_module_master');
	}
	
	else if(z==-1 ||z>=a)
	{
	
		document.getElementById('drpdesignation').value=allmoduleds.Tables[0].Rows[0].Designation;
		document.getElementById('txtcode').value=allmoduleds.Tables[0].Rows[0].All_module_code	;
		document.getElementById('txtname').value=allmoduleds.Tables[0].Rows[0].Name_all	;
		document.getElementById('txtlevel').value=allmoduleds.Tables[0].Rows[0].all_level;
		document.getElementById('txtmailid').value=allmoduleds.Tables[0].Rows[0].mail_id;
		document.getElementById('txtdiscount').value=allmoduleds.Tables[0].Rows[0].discount_allow;
		document.getElementById('drpstatus').value=allmoduleds.Tables[0].Rows[0].STATUS;
        return false;
	}
	
	else
	{
	    document.getElementById('drpdesignation').value=allmoduleds.Tables[0].Rows[z].Designation;
		document.getElementById('txtcode').value=allmoduleds.Tables[0].Rows[z].All_module_code	;
		document.getElementById('txtname').value=allmoduleds.Tables[0].Rows[z].Name_all	;
		document.getElementById('txtlevel').value=allmoduleds.Tables[0].Rows[z].all_level;
		document.getElementById('txtmailid').value=allmoduleds.Tables[0].Rows[z].mail_id;
		document.getElementById('txtdiscount').value=allmoduleds.Tables[0].Rows[z].discount_allow;
		document.getElementById('drpstatus').value=allmoduleds.Tables[0].Rows[z].status;
	    return false;
	}
	setButtonImages();
	return false;
}
	
	
	function exitall()
	{
	if(confirm("Do You Really Want To Exit"))
	{
//	window.location.href='Default.aspx';
    window.close();
	return false;
	}
	return false;
	}
	
	
	///////////////////////////////////////////
	
	
	
	
	
	
	
	
	
	function autoornot()
    {
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    return false;
    }
 else
    {
    userdefine();

    return false;
    }
return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
 document.getElementById('txtname').value=trim(document.getElementById('txtname').value);
if(hiddentext=="new" )
			{
	
            uppercase3();
           
           }
            else
            {
            document.getElementById('txtname').value=trim(document.getElementById('txtname').value);
            document.getElementById('txtname').value=document.getElementById('txtname').value.toUpperCase();
            str=document.getElementById('txtname').value;
            if(hiddentext!="query" )
			{
            if(gname !=document.getElementById('txtname').value)
            {
		       var res1=All_module_master.chksallmodcode(str);
		       var ds=res1.value;
		       if(ds.Tables[0].Rows.length!=0)
		    {
		    
		    document.getElementById('txtname').value="";
		    alert("This Name has already assigned !! ");
		    
		    document.getElementById('txtname').focus();
		 
		    return false;
		    }
		    }
		    }
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		    if(document.getElementById('txtname').value!="")
                {
                 document.getElementById('txtname').value=document.getElementById('txtname').value.toUpperCase();
	           // document.getElementById('txtalias').value=document.getElementById('txtadsubcatname').value;
		        str=document.getElementById('txtname').value;
		        All_module_master.chksallmodcode(str,fillcall);
		        return false;
                }
		     return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    
		    document.getElementById('txtname').value="";
		    alert("This Name has already assigned !! ");
		    
		    document.getElementById('txtname').focus();
		    
 
    		
		    return false;
		    }
		
		        else
		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].ALL_MODULE_CODE;
		                        }
		                    if(newstr !=null )
		                        {
		                            var code=newstr;
		                            code++;
		                            document.getElementById('txtcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtcode').disabled=false;
        document.getElementById('txtname').value=trim(document.getElementById('txtname').value);
        document.getElementById('txtname').value=document.getElementById('txtname').value.toUpperCase();
        str=document.getElementById('txtname').value;
		       var res1=All_module_master.chksallmodcode(str);
		       var ds=res1.value;
		       if(ds.Tables[0].Rows.length!=0)
		    {
		    
		    document.getElementById('txtname').value="";
		    alert("This Name has already assigned !! ");
		    
		    document.getElementById('txtname').focus();
		 
		    return false;
		    }
       
        //document.getElementById('txtalias').value=document.getElementById('txtadsubcatname').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }
        

return false;
}
	
	
	function eventcalling(event)
{

if(document.activeElement.id!="txtmailid")
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
if(event.keyCode==113) 
    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;
    }
}

function trim( value) 
{
      return (value.replace(/^\s+/g, '').replace(/\s+$/g, ''));
	
}


function Discount()
{
var sau=parseFloat(document.getElementById('txtdiscount').value);
//document.getElementById('txtsharing').value=sau;

if(sau>100)
{
    alert("Discount Amount can't Exceed 100!");
    document.getElementById('txtdiscount').value="";
    document.getElementById('txtdiscount').focus();
    return false;
}
		
var num=document.getElementById('txtdiscount').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtdiscount').value="";
document.getElementById('txtdiscount').focus();

return false; 

}

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

function clearall_module()
{
givebuttonpermission('All_module_master');
cancel('All_module_master');
return false;
}






