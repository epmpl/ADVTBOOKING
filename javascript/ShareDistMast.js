// JScript File
var modi;
 var z;
 var hiddentext;
 var auto;
 var dsshare;
 var code;
 var name;
 
 var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
		var xmlObj;
        function loadXML(xmlFile) 
         { 
            xmlDoc.async="false"; 
            xmlDoc.onreadystatechange=verify; 
            xmlDoc.load(xmlFile); 
            xmlObj=xmlDoc.documentElement; 
           // alert(xmlObj.childNodes(0).childNodes(0).text);  
            
          }
function verify() 
{ 
 // 0 Object is not initialized 
 // 1 Loading object is loading data 
 // 2 Loaded object has loaded data 
 // 3 Data from object can be worked with 
 // 4 Object completely initialized 
 if (xmlDoc.readyState != 4) 
 { 
   return false; 
 } 
}

 
 
   function Sharenew()
   {
	modi=0;
	         if(document.getElementById('hiddenauto').value==1)
		       {
		      document.getElementById('txtShareCode').disabled=true;
    	        }
		     else
		       {
		       document.getElementById('txtShareCode').disabled=false;
    	       }
	//document.getElementById('txtShareCode').disabled=false;
	document.getElementById('txtSharename').disabled=false;
	if(document.getElementById('hiddenauto').value==1)
		       {
		      document.getElementById('txtSharename').focus();
    	        }
		     else
		       {
		       document.getElementById('txtShareCode').focus();
    	       }
	
	
	chkstatus(FlagStatus);	
	hiddentext="new";		
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	return false;
   }
   
   
   function cancelShare(formname)
		{
			
			document.getElementById('txtShareCode').disabled=true;
			document.getElementById('txtSharename').disabled=true;
			
			document.getElementById('txtShareCode').value="";
			document.getElementById('txtSharename').value="";
			
			chkstatus(FlagStatus);
			
			givebuttonpermission(formname);
			
			/*document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExit').disabled=false;*/
			
			//getPermission('ShareDistMaster');
			return false;
		}


function ShareSave()
	{
	
	document.getElementById('txtSharename').value=trim(document.getElementById('txtSharename').value);
	
			if((document.getElementById('txtShareCode').value=="") && (document.getElementById('hiddenauto').value!=1))
			{
			alert("Please Enter Share Code");
			document.getElementById('txtShareCode').focus();
			return false;
			}
			if(document.getElementById('txtSharename').value=="")
			{
			alert("Please Enter Share Name");
			document.getElementById('txtSharename').focus();
			return false;
			}
			
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ShareCode=document.getElementById('txtShareCode').value;
			var Sharename=document.getElementById('txtSharename').value;
			
		if(modi==0)
		{	
			ShareDistMaster.Sharechk(compcode,userid,ShareCode,callchk)
			return false;
		}
		else
		{
			ShareDistMaster.modify(compcode,userid,ShareCode,Sharename);
			//alert("Data Modified");
			alert(xmlObj.childNodes(0).childNodes(1).text);
			updateStatus();
			document.getElementById('txtShareCode').disabled=true;
			document.getElementById('txtSharename').disabled=true;
			
			dsshare.Tables[0].Rows[z].share_dist_code=document.getElementById('txtShareCode').value
			dsshare.Tables[0].Rows[z].share_dist_name=document.getElementById('txtSharename').value
			
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;*/		
								
			/*document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=false;*/
			
		return false;
		}
			return false;
	}
		

function callchk(res)
	{
		var ds= res.value;
		if(ds.Tables[0].Rows.length==0)
		{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ShareCode=document.getElementById('txtShareCode').value;
			var Sharename=document.getElementById('txtSharename').value;
			
			ShareDistMaster.save(compcode,userid,ShareCode,Sharename);
			
			document.getElementById('txtShareCode').disabled=true;
			document.getElementById('txtSharename').disabled=true;
			
			//alert("Data Saved");
			alert(xmlObj.childNodes(0).childNodes(0).text);
			
			document.getElementById('txtShareCode').value="";
			document.getElementById('txtSharename').value="";
			
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
			cancelShare('ShareDistMaster');
			return false;
		}
		else
		{
		alert("This Share Code already Exist   Please Try Another Code");
		
			document.getElementById('txtShareCode').disabled=false;
			document.getElementById('txtSharename').disabled=false;
		return false;
		
		}
		
		
		
		
		
	}
	
	
	function Sharemodify()
		{
			modi= "2";
			//document.getElementById('btnQuery').disabled = true;
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				hiddentext="modify";
			/*	document.getElementById('btnNew').disabled=true;
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
				
				document.getElementById('txtShareCode').disabled=true;
			document.getElementById('txtSharename').disabled=false;
				
		return false;		
		}
		
		
		
function Sharequery(formname)
		{	
				document.getElementById('txtShareCode').disabled=false;
			document.getElementById('txtSharename').disabled=false;
			
				document.getElementById('txtShareCode').value="";
			document.getElementById('txtSharename').value="";
				
				chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;*/
				z=0;
				return false;
		}
		
		
		
		
		function Shareexe()
		{
		
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ShareCode=document.getElementById('txtShareCode').value;
			var Sharename=document.getElementById('txtSharename').value;
			
			code=ShareCode;
			name=Sharename;
			
			ShareDistMaster.exe(compcode,userid,ShareCode,Sharename,callexe)
			
			updateStatus();
			
			
			
			
			document.getElementById('txtShareCode').disabled=true;
			document.getElementById('txtSharename').disabled=true;
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;*/
			
					document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnlast').disabled=false;	
			
		return false;
		}
		
function callexe(res)
		{
		//	var ds=res.value;
		    dsshare=res.value;
				if(dsshare.Tables[0].Rows.length==0)
				{
					alert("Your Search Can Not Produce Any Result");
					cancelShare('ShareDistMaster');
					return false;
				}
				else
				{
					document.getElementById('txtShareCode').value=dsshare.Tables[0].Rows[0].share_dist_code;
					document.getElementById('txtSharename').value=dsshare.Tables[0].Rows[0].share_dist_name;
					
						
				}
				
				
				if(dsshare.Tables[0].Rows.length==1)
				{
				document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=true;
				
				
				}
			return false;
		}
		
		
		
		
		
function Sharefirst()
{
z=0;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			ShareDistMaster.fnpl(compcode,userid,claafirst);
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;			
			document.getElementById('btnExit').disabled=false;
		
			
			return false;
}


function claafirst(response)
		{
		//alert("first");

			//var	ds=response.value;
			   // dsshare=response.value;
			
					document.getElementById('txtShareCode').value=dsshare.Tables[0].Rows[0].share_dist_code;
					document.getElementById('txtSharename').value=dsshare.Tables[0].Rows[0].share_dist_name;
					
					updateStatus();

document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;	
					
					return false;
		}

function Sharepre()
	{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			ShareDistMaster.fnpl(compcode,userid,precall);
			return false;
	}

function precall(response)
	{
	//alert("pre");

		z--;
		//var ds=response.value;
		 //dsshare=response.value;
	    var x=dsshare.Tables[0].Rows.length;
		
		
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
			if(dsshare.Tables[0].Rows.length != z)
			{
					document.getElementById('txtShareCode').value=dsshare.Tables[0].Rows[z].share_dist_code;
					document.getElementById('txtSharename').value=dsshare.Tables[0].Rows[z].share_dist_name;
					
					updateStatus();
		
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=false;
			
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
	if (z<=0)
		{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			return false;		
		}
		return false;
}

function Sharenext()
	{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			ShareDistMaster.fnpl(compcode,userid,nextcall)
			return false;
}

function nextcall(response)
{
//alert("next");
z++;
	//var ds=response.value;
	// dsshare=response.value;
	var x=dsshare.Tables[0].Rows.length;
	if(z <= x && z >= 0)
	{
		if(dsshare.Tables[0].Rows.length != z && z !=-1)
		{
				    document.getElementById('txtShareCode').value=dsshare.Tables[0].Rows[z].share_dist_code;
					document.getElementById('txtSharename').value=dsshare.Tables[0].Rows[z].share_dist_name;
				updateStatus();
	
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=false;
			
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
		if(z==x-1)
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		return false;
}

function Sharelast()
		{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
		
			ShareDistMaster.fnpl(compcode,userid,lastcall)
			return false;
		}


function lastcall(response)
	{
			// dsshare= response.value;
			var x=dsshare.Tables[0].Rows.length;
			z=x-1;
			x=x-1;
					document.getElementById('txtShareCode').value=dsshare.Tables[0].Rows[x].share_dist_code;
					document.getElementById('txtSharename').value=dsshare.Tables[0].Rows[x].share_dist_name;
					
					updateStatus();
		
			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;
	}
	
function deleteShare()
	{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var ShareCode=document.getElementById('txtShareCode').value;
		boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	ShareDistMaster.del(compcode,userid,ShareCode);
		ShareDistMaster.exe(compcode,userid,code,name,delcall);
	
	}     
	else
	{
	return false;
	}	
	return false;
	}
	
	function delcall(res)
	{
	//var ds= res.value;
				 dsshare= res.value;
	
	len=dsshare.Tables[0].Rows.length;
	
	if(dsshare.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
	document.getElementById('txtShareCode').value="";
			document.getElementById('txtSharename').value="";
		cancelShare('ShareDistMaster');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
		            document.getElementById('txtShareCode').value=dsshare.Tables[0].Rows[0].share_dist_code;
					document.getElementById('txtSharename').value=dsshare.Tables[0].Rows[0].share_dist_name;
	}
	
	else
	{
		document.getElementById('txtShareCode').value=dsshare.Tables[0].Rows[z].share_dist_code;
					document.getElementById('txtSharename').value=dsshare.Tables[0].Rows[z].share_dist_name;
	}
	//alert ("Data Deleted");	
	alert(xmlObj.childNodes(0).childNodes(2).text);
				
	
	return false;
	}
	
	
function Shareexit()
{
if(confirm("Do You Want To Skip This Page"))
	{
	//window.location.href='EnterPage.aspx';
	window.close();
	return false;
	}
	
	return false;
}







////////////////////////////////////////


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
if(hiddentext=="new" )
			{
	
            uppercase3();
           
           }
            else
            {
            document.getElementById('txtSharename').value=document.getElementById('txtSharename').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		 //document.getElementById('txtShareCode').value=trim(document.getElementById('txtShareCode').value);
document.getElementById('txtSharename').value=trim(document.getElementById('txtSharename').value);
                lstr=document.getElementById('txtSharename').value;
            cstr=lstr.substring(0,1);
            var mstr="";
            			   if(lstr.indexOf(" ")==1)
			            {
			            var leng=lstr.length;
			           mstr= cstr + lstr.substring(2,leng);
			            }
			            else
			            {
			             var leng=lstr.length;
			            mstr=cstr + lstr.substring(1,leng);
			            }
		    if(document.getElementById('txtSharename').value!="")
                {
         
                
                 document.getElementById('txtSharename').value=document.getElementById('txtSharename').value.toUpperCase();
	            // str=document.getElementById('txtSharename').value;
	            str=mstr;
		         ShareDistMaster.chksharecode(str,fillcall);
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
		    alert("This Share Name  has already assigned !! ");
		    
		    document.getElementById('txtShareCode').value="";
			document.getElementById('txtSharename').value="";
		    
		    document.getElementById('txtSharename').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].share_dist_code;
		                        }
		                    if(newstr !=null )
		                        {
		                        //var code=newstr.substr(2,4);
		                        var code=newstr;
		                        code++;
		                        document.getElementById('txtShareCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtShareCode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtShareCode').disabled=false;
        document.getElementById('txtSharename').value=document.getElementById('txtSharename').value.toUpperCase();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}
	











	function eventcalling(event)
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
