// JScript File


	var z=0;
	var flag;
	var hiddentext;
    var auto="";
    var hiddentext1="";
    var dsregionexecute;
    var gbregioncode;
    var gbregionname;
    var gbalias;
    var browser=navigator.appName;

var xmlDoc=null;
var xmlObj=null;

var req=null;

function loadXML(xmlFile) 
{
    var  httpRequest =null;
    
    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }

}

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
                //alert(response);
            }
        }
        
        var parser=new DOMParser();
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
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
//*********************************************************************************************************    
	function newclick()
		{
			flag=1;
			document.getElementById('txtregioncode').value="";
			document.getElementById('txtregionname').value="";
			document.getElementById('txtalias').value="";
			if(document.getElementById('hiddenauto').value==1)
		         {
		          document.getElementById('txtregioncode').disabled=true;
    	          }
		    else
		        {
		         document.getElementById('txtregioncode').disabled=false;
    	        }
			//document.getElementById('txtregioncode').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('txtregionname').disabled=false;
			
			
//			if(document.getElementById('hiddenauto').value==1)
//		            {
//				     document.getElementById('txtregionname').focus();
//    	            }
//		    else
//		        {
//		         document.getElementById('txtregioncode').focus();
//    	        }
    	        
			chkstatus(FlagStatus);
			hiddentext="new";
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
			
			if(document.getElementById('hiddenauto').value==1)
		            {
				     document.getElementById('txtregionname').focus();
    	            }
		    else
		        {
		         document.getElementById('txtregioncode').focus();
    	        }
		
	
		
			return false;
		}
//********************************************************************************************************		

function cancelclick()
	{
			//getPermission('variable');
		
			document.getElementById('txtregioncode').value="";
			document.getElementById('txtregionname').value="";
			document.getElementById('txtalias').value="";
			
			document.getElementById('txtregioncode').disabled=true;
			document.getElementById('txtregionname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			
			chkstatus(FlagStatus);
			givebuttonpermission('variable');
			
				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnExit').disabled=false;
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnExecute').disabled= true;	
			
			document.getElementById('btnNew').focus();		
	
			
		return false;
	}
//*********************************************************************************************************	

	function save()
	{
		
	document.getElementById('txtregioncode').value=trim(document.getElementById('txtregioncode').value);
	document.getElementById('txtregionname').value=trim(document.getElementById('txtregionname').value);
	document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
		     
//			if (flag==1)
//			{
         //  if((document.getElementById('txtregioncode').value!="") $$ (document.getElementById('hiddenauto').value!=1))
//			    if(document.getElementById('hiddenauto').value!=1)
//			    {
//			     
//				    if(document.getElementById('txtregioncode').value!="")
//				    {}
//				    else
//				    {
//				    alert("Please Enter the Region Code");
//				    document.getElementById('txtregionname').focus();
//				    return false;
//			        }	
//			        
//			    }			
//				
//				 if(document.getElementById('txtregionname').value!="")
//					{}
//					else
//					{
//					alert("please Enter Region Name");
//					document.getElementById('txtregionname').focus();
//					return false;
//					}
//					
//			   if(document.getElementById('txtalias').value!="")
//				{}
//				else
//				{
//				alert("Please Alias Name");
//			   document.getElementById('txtalias').focus();
//				return false;
//				}

          if((document.getElementById('txtregioncode').value=="") &&(document.getElementById('hiddenauto').value!=1))
		       {

				alert("Please Enter Variable Code");
				document.getElementById('txtregioncode').focus();
				return false;
		        }
		    
		 
		else if(document.getElementById('txtregionname').value=="")
		{
				alert("Please Enter Variable name");
				document.getElementById('txtregionname').focus();
				return false;
		}
		else if(document.getElementById('txtalias').value=="")
		{
				alert("Please Enter Alias");
				document.getElementById('txtalias').focus();
				return false
		}
				
		
			var regioncode=document.getElementById('txtregioncode').value;
			var regionname=document.getElementById('txtregionname').value;
			var compcode=document.getElementById('hiddencompanycode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			if(flag!=2)
			{
			 
			 variable.chkvariable(compcode,regionname,regioncode,userid,saveclick);
			
			}
			else
			{
			variable.chkname(regioncode,regionname,compcode,modifysave);
			//modifysave();
			}
			return false;
		}
//*******************************************************************
function saveclick(response)
	{
			var ds=response.value;
			
			if(ds.Tables[0].Rows.length >0)
			{
//			    alert("This Region Name has already assigned");
//			    document.getElementById('txtregionname').focus();
//			    return false;

	        if(ds.Tables[0].Rows[0].Region_Name==document.getElementById('txtregionname').value)
			{
			alert("This Variable Name has already assigned");
			document.getElementById('txtregionname').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('txtregionname').focus();
			return false;

			}
			else if(ds.Tables[0].Rows[0].Region_Code==document.getElementById('txtregioncode').value)
			{
			alert("This Variable code has already assigned");
			document.getElementById('txtregioncode').value="";
			document.getElementById('txtregioncode').focus();
			return false;
			}
			return false;
			}
		

			if(ds.Tables[0].Rows.length==0)
			
			{
					if(document.getElementById('txtregioncode').value!="")
					{}
					else
					{
					alert("Please Enter the Variable Code");
					return false;
					}	
						if(document.getElementById('txtregionname').value!="")
						{}
						else
						{
						alert("please Enter Variable Name");
						document.getElementById('txtregionname').focus();
						return false;
						}
					if(document.getElementById('txtalias').value!="")
					{}
					else
					{
					alert("Please Alias Name");
					document.getElementById('txtalias').focus();
					return false;
					}
		
			var regioncode=document.getElementById('txtregioncode').value;
			var regionname=document.getElementById('txtregionname').value;
			var alias=document.getElementById('txtalias').value;
			var compcode=document.getElementById('hiddencompanycode').value;
			var userid=document.getElementById('hiddenuserid').value;
			variable.variablemastersave(compcode,regioncode,regionname,alias,userid);
	
				document.getElementById('txtregioncode').disabled=true;
				document.getElementById('txtregionname').disabled=true;
				document.getElementById('txtalias').disabled=true;
		
		alert("Data Saved Successfully")
		
		//alert(xmlObj.childNodes(0).childNodes(0).text);
        		
		        document.getElementById('txtregioncode').value="";
		        document.getElementById('txtregionname').value="";
		        document.getElementById('txtalias').value="";
        		
		
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
				
		cancelclick('variable');
        document.getElementById('btnNew').focus();
        
		return false;
		}
		else
		{
		alert("This Variable Code Already Asigned");
		return false;
		}
		cancelclick('variable');
		return false;
}
//*********************************************************************************************************	
function modifysave(response)
	{
	    	var ds=response.value;
			if(ds.Tables[0].Rows.length >0)
			{
			    alert("This Variable Name has already assigned");
			    document.getElementById('txtregionname').focus();
			    return false;
			}
			else
			{
//				if(document.getElementById('txtregionname').value!="")
//				{}
//				else
//				{
//				alert("please Enter Region Name");
//				
//				return false;
//				}
//			if(document.getElementById('txtalias').value!="")
//			{}
//			else
//			{
//			alert("Please Alias Name");
//			return false;
//			}

			var regioncode=document.getElementById('txtregioncode').value;
			var regionname=document.getElementById('txtregionname').value;
			var alias=document.getElementById('txtalias').value;
			var compcode=document.getElementById('hiddencompanycode').value;
			var userid=document.getElementById('hiddenuserid').value;
								
		variable.variablemodify_save(compcode,regioncode,regionname,alias,userid);
            updateStatus();
			dsregionexecute.Tables[0].Rows[z].Region_Name=document.getElementById('txtregionname').value;
		    dsregionexecute.Tables[0].Rows[z].Region_Alias=document.getElementById('txtalias').value;
		

			document.getElementById('txtregioncode').disabled = true;
			document.getElementById('txtregionname').disabled = true;
			document.getElementById('txtalias').disabled = true;
			//alert("Data Modified")
			
			if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(1).text);
                }
			
				updateStatus();
				        if (z==0)
                        {
                        document.getElementById('btnfirst').disabled=true;
                        document.getElementById('btnprevious').disabled=true;
                        }

                        if(z==(dsregionexecute.Tables[0].Rows.length-1))
                        {
                        document.getElementById('btnnext').disabled=true;
                        document.getElementById('btnlast').disabled=true;
                        }   
	
			
			}
					
			return false;
	}

//*******************************************************************************************************	

function modifyclick()
		{
			flag=2;
			
				hiddentext="modify";
//				chkstatus(FlagStatus);
//				document.getElementById('btnSave').disabled = false;
//				document.getElementById('btnQuery').disabled=true;	
								
				document.getElementById('txtregioncode').disabled=true;
				document.getElementById('txtregionname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
				
		/*	document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
		    document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;*/
				
				
		return false;
	}
//************************************************************************************************	

	function queryclick()
		{
		  hiddentext="query";
		  
			document.getElementById('txtregioncode').value="";
			document.getElementById('txtregionname').value="";
			document.getElementById('txtalias').value="";
			
				document.getElementById('txtregioncode').disabled = false;
			    document.getElementById('txtregionname').disabled = false;
			    document.getElementById('txtalias').disabled = false;
		     z=0;
			chkstatus(FlagStatus);
			
			   document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			
			document.getElementById('btnExecute').focus();
			
		return false;
	}
//********************************************************************************************************
function executeclick()
	{
				var regioncode=document.getElementById('txtregioncode').value;
				gbregioncode=regioncode;
				var regionname=document.getElementById('txtregionname').value;
				gbregionname=regionname;
				var alias=document.getElementById('txtalias').value;
				gbalias=alias;
				var compcode=document.getElementById('hiddencompanycode').value;
				var userid=document.getElementById('hiddenuserid').value;

		variable.variablesearchexecute(compcode,regioncode,regionname,alias,userid,regionsearchexecute_callBack);
								
				updateStatus();

				document.getElementById('txtregioncode').disabled = true;
				document.getElementById('txtregionname').disabled = true;
				document.getElementById('txtalias').disabled = true;
				document.getElementById('btnfirst').disabled=true;
				
				document.getElementById('btnModify').focus();
			//document.getElementById('btnprevious').disabled=true;
			
			/*document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnExit').disabled=false;
			document.getElementById('btnModify').disabled=false;
				document.getElementById('btnDelete').disabled = false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;	*/
			
			return false;
	}



function regionsearchexecute_callBack(response)
		{
		 dsregionexecute=response.value;

		//if(ds=="n")
		if(dsregionexecute.Tables[0].Rows.length == 0)
		{
		alert("Your Search Criteria Does not Produce Any Search!!!");
		
			cancelclick('variable');
			
			document.getElementById('txtregioncode').value="";
			document.getElementById('txtregionname').value="";
			document.getElementById('txtalias').value="";
		return false;
		}
	else
		{
			
		document.getElementById('txtregioncode').value=dsregionexecute.Tables[0].Rows[0].Region_Code;
		document.getElementById('txtregionname').value=dsregionexecute.Tables[0].Rows[0].Region_Name;
		document.getElementById('txtalias').value=dsregionexecute.Tables[0].Rows[0].Region_Alias;
		 document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
		
		}
		
		if(dsregionexecute.Tables[0].Rows.length==1)
		{
		    document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
		
		
		}
		
return false;
}
//***********************************************************************************************************



function firstclick1()
		{
		        
				document.getElementById('txtregioncode').value=dsregionexecute.Tables[0].Rows[0].Region_Code;
				document.getElementById('txtregionname').value=dsregionexecute.Tables[0].Rows[0].Region_Name;
				document.getElementById('txtalias').value=dsregionexecute.Tables[0].Rows[0].Region_Alias;
	z=0;
				updateStatus();

				document.getElementById('txtregioncode').disabled = true;
				document.getElementById('txtregionname').disabled = true;
				document.getElementById('txtalias').disabled = true;
				
				document.getElementById('btnfirst').disabled=true;				
			   document.getElementById('btnprevious').disabled=true;
				//alert('hi');
				return false;
				
		}
//*******************************************************************************************************	


function lastclick1()
		{
			
			
			var y=dsregionexecute.Tables[0].Rows.length;
				z=y-1;
				y=y-1;
		document.getElementById('txtregioncode').value=dsregionexecute.Tables[0].Rows[y].Region_Code;
		document.getElementById('txtregionname').value=dsregionexecute.Tables[0].Rows[y].Region_Name;
		document.getElementById('txtalias').value=dsregionexecute.Tables[0].Rows[y].Region_Alias;

		document.getElementById('txtregioncode').disabled = true;
		document.getElementById('txtregionname').disabled = true;
		document.getElementById('txtalias').disabled = true;
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;

	return false;
}
//***************************************************************************************************
		
	function preclick1()
		{
		z--;
		//var ds=response.value;
		var y=dsregionexecute.Tables[0].Rows.length;
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
		if(dsregionexecute.Tables[0].Rows.length != z)
		{
		document.getElementById('txtregioncode').value=dsregionexecute.Tables[0].Rows[z].Region_Code;
		document.getElementById('txtregionname').value=dsregionexecute.Tables[0].Rows[z].Region_Name;
		document.getElementById('txtalias').value=dsregionexecute.Tables[0].Rows[z].Region_Alias;
		updateStatus();
	
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
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
			document.getElementById('txtregioncode').disabled = true;
			document.getElementById('txtregionname').disabled = true;
			document.getElementById('txtalias').disabled = true;
			return false;	
}
//*******************************************************************************************************
						
function nextclick1()
{
		
		    var y=dsregionexecute.Tables[0].Rows.length;
		    z++;
		    document.getElementById('txtregioncode').disabled = true;
	        document.getElementById('txtregionname').disabled = true;
	        document.getElementById('txtalias').disabled = true;	
		    if(z <= y && z >= 0)
			{
			    if(dsregionexecute.Tables[0].Rows.length != z && z !=-1)
				    {
					   	document.getElementById('txtregioncode').value=dsregionexecute.Tables[0].Rows[z].Region_Code;
						document.getElementById('txtregionname').value=dsregionexecute.Tables[0].Rows[z].Region_Name;
						document.getElementById('txtalias').value=dsregionexecute.Tables[0].Rows[z].Region_Alias;
	                    updateStatus();
	
						document.getElementById('btnnext').disabled=false;
						document.getElementById('btnlast').disabled=false;
						document.getElementById('btnfirst').disabled=false;
						document.getElementById('btnprevious').disabled=false;
						
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
			z=0;
		    }
			if(z==y-1)
			{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			return false;						
			}
			return false;
}
//**********************************************************************************************************
									
							       
function deleteclick()
{
		boolReturn = confirm("Are you sure you wish to delete this?");
		if(boolReturn==1)
		{
		
		var regioncode=document.getElementById('txtregioncode').value;
		var compcode=document.getElementById('hiddencompanycode').value;
		var userid=document.getElementById('hiddenuserid').value;

		variable.delete1(compcode,regioncode,userid);
        variable.variablesearchexecute(compcode,gbregioncode,gbregionname,gbalias,userid,calldel);
		
	//variable.regionfirst(regioncode,calldel);
		
		document.getElementById('txtregioncode').disabled = true;
		document.getElementById('txtregionname').disabled = true;
		document.getElementById('txtalias').disabled = true;
		
		
	return false;
	}
	else
	{
	return false;
	}
return false;
}

function calldel(res)
	{
	dsregionexecute= res.value;
	len=dsregionexecute.Tables[0].Rows.length;
	
	if(dsregionexecute.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
		document.getElementById('txtregioncode').value="";
		document.getElementById('txtregionname').value="";
		document.getElementById('txtalias').value="";
		cancelclick('variable');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
		                document.getElementById('txtregioncode').value=dsregionexecute.Tables[0].Rows[0].Region_Code;
						document.getElementById('txtregionname').value=dsregionexecute.Tables[0].Rows[0].Region_Name;
						document.getElementById('txtalias').value=dsregionexecute.Tables[0].Rows[0].Region_Alias;
	}
	
	else
	{
		                document.getElementById('txtregioncode').value=dsregionexecute.Tables[0].Rows[z].Region_Code;
						document.getElementById('txtregionname').value=dsregionexecute.Tables[0].Rows[z].Region_Name;
						document.getElementById('txtalias').value=dsregionexecute.Tables[0].Rows[z].Region_Alias;
	}
	//alert ("Data Deleted");	
	
	if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
	
	return false;
}

function regionexit()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			window.close();
			return false;
		}
		return false;	
}

//***********************************************************************************************************

function autoornot()
 {
  
  if(document.getElementById('hiddenauto').value==1)
    {
    changeoccured();
    //return false;
    }
else
    {
    userdefine();
    //return false;
    }
//return false;
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
            document.getElementById('txtregionname').value=document.getElementById('txtregionname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		document.getElementById('txtregionname').value=document.getElementById('txtregionname').value.toUpperCase();
		// document.getElementById('txtregioncode').value=trim(document.getElementById('txtregioncode').value);
	document.getElementById('txtregionname').value=trim(document.getElementById('txtregionname').value);
	document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
      lstr=document.getElementById('txtregionname').value;
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
		    if(document.getElementById('txtregionname').value!="")
                {
                
              
         document.getElementById('txtregionname').value=document.getElementById('txtregionname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtregionname').value;
		// str=document.getElementById('txtregionname').value;
		str=mstr;
		variable.chkvariablecodename(str,fillcall);
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
		    alert("This variable name has already assigned !! ");
		    
		    document.getElementById('txtregioncode').value="";
			document.getElementById('txtregionname').value="";
			document.getElementById('txtalias').value="";
			
		    document.getElementById('txtregionname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Region_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        document.getElementById('txtregioncode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtregioncode').value=str.substr(0,2)+ "0";
		                         }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtregioncode').disabled=false;
        document.getElementById('txtregionname').value=document.getElementById('txtregionname').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtregionname').value;
        auto=document.getElementById('hiddenauto').value;
         //return false;
        }

return false;
}
	
//********************************************************************************************************	

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
//*********************************************************************************************************
   //Code for enter in case of query button
//*****************************************************************************************************

function tabvalue (id)
{

    if(event.keyCode==13)
    {
        if(document.activeElement.id==id)
        {
                    if(document.getElementById('btnSave').disabled==false)
                        {
                            document.getElementById('btnSave').focus();
                            event.keyCode=13;
                            return event.keyCode;
                        }
                    else
                        {
                            document.getElementById('btnExecute').focus();
                            event.keyCode=13;
                            return event.keyCode;
                        }    
        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
            {
            event.keyCode=13;
            return event.keyCode;
            }
     else
     {
            event.keyCode=9;
            return event.keyCode;
     }
  }
}
//**********************************************************************************************************
