var k="0";
var z=0;
var agencytype="";

var ascmcat;
var hiddentext;
var auto="";
var hiddentext1="";
var dsexecute;
var	gbagency;
var	gbcategory;
var gbasccode;
var	gbascname;
var	gbalias;

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



function ascmNewclick()	
{				
				document.getElementById('drpagencytype').value="0";
				document.getElementById('drpagencycat').value="0";
				document.getElementById('txtasccode').value="";
				document.getElementById('txtascname').value="";
				document.getElementById('txtalias').value="";
				
				if(document.getElementById('hiddenauto').value==1)
                  {
                  document.getElementById('txtasccode').disabled=true;
                  }
                 else
                   {
                   document.getElementById('txtasccode').disabled=false;
                   }

				
				document.getElementById('drpagencytype').disabled=false;			
				document.getElementById('drpagencycat').disabled=false;							
				document.getElementById('txtascname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				if(document.getElementById('hiddenauto').value==1)
                  {
                  document.getElementById('drpagencytype').focus();
                 // document.getElementById('txtascname').focus();
                  }
//                 else
//                   {
//                   //document.getElementById('txtasccode').focus();
//                   }
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
				chkstatus(FlagStatus);
				hiddentext="new";
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
	
				return false;
}

function ascmDeleteclick()
{
		var companycode=document.getElementById('hiddencomcode').value;
		var agency=document.getElementById('drpagencytype').value;
		var category=document.getElementById('drpagencycat').value;
		var code=document.getElementById('txtasccode').value;
		var name=document.getElementById('txtascname').value;
		var alias=document.getElementById('txtalias').value;
		var UserId=document.getElementById('hiddenuserid').value;	
		boolReturn = confirm("Are you sure you wish to delete this?");
		if(boolReturn==1)
			{
			    if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
                }
                else
                {
	                alert(xmlObj.childNodes(0).childNodes(2).text);
	            }
			 //  alert("Data Deleted Successfully");	
				AgencySubCategoryMaster.ascmdelete(companycode,agency,category,code,name,alias,UserId);	
			    AgencySubCategoryMaster.ascmexecute(companycode,gbagency,gbcategory,gbasccode,gbascname,gbalias,UserId,delcall);
		
			}     
		else
		{
			return false;
		}	
	return false;
}
	
function delcall(res)
{
	dsexecute= res.value;
	len=dsexecute.Tables[0].Rows.length;
	
	if(dsexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('drpagencytype').value="0";
		document.getElementById('drpagencycat').value="0";
		document.getElementById('txtasccode').value="";
		document.getElementById('txtascname').value="";
		document.getElementById('txtalias').value="";
		ascmCancelclick('AgencySubCategoryMaster');
				
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[0].Agency_Type_Code;
		//document.getElementById('drpagencycat').value=ds.Tables[0].Rows[0].Agency_Cat_Code;
		document.getElementById('txtasccode').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Code;
		document.getElementById('txtascname').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Name;
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Alias;
		addagencycategory(dsexecute.Tables[0].Rows[0].Agency_Type_Code);
		ascmcat=dsexecute.Tables[0].Rows[0].Agency_Cat_Code;
			
	}
	else
	{
		document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[z].Agency_Type_Code;
		//document.getElementById('drpagencycat').value=ds.Tables[0].Rows[z].Agency_Cat_Code;
		document.getElementById('txtasccode').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Code;
		document.getElementById('txtascname').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Name;
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Alias;
		addagencycategory(dsexecute.Tables[0].Rows[z].Agency_Type_Code);
		ascmcat=dsexecute.Tables[0].Rows[z].Agency_Cat_Code;
			
	}
	
	
return false;
}

function ascmQueryclick()		
{
            hiddentext="query";
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
			chkstatus(FlagStatus);
				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
			
			document.getElementById('drpagencytype').value="0";
			document.getElementById('drpagencycat').value="0";
			document.getElementById('txtasccode').value="";
			document.getElementById('txtascname').value="";
			document.getElementById('txtalias').value="";
			
			document.getElementById('drpagencytype').disabled=false;
			document.getElementById('drpagencycat').disabled=false;								
			document.getElementById('txtasccode').disabled=false;
			document.getElementById('txtascname').disabled=false;
			document.getElementById('txtalias').disabled=false;
			
			return false;
}

function ascmExecuteclick()
{
			
			var companycode=document.getElementById('hiddencomcode').value;
			var agency=document.getElementById('drpagencytype').value;
			var category=document.getElementById('drpagencycat').value;
			var code=document.getElementById('txtasccode').value;
			var name=document.getElementById('txtascname').value;
			var alias=document.getElementById('txtalias').value;
			var UserId=document.getElementById('hiddenuserid').value;	
			
			AgencySubCategoryMaster.ascmexecute(companycode,agency,category,code,name,alias,UserId,checkcall);
			
		    
			
			updateStatus();
			
			document.getElementById('drpagencytype').disabled=true;
			document.getElementById('drpagencycat').disabled=true;								
			document.getElementById('txtasccode').disabled=true;
			document.getElementById('txtascname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			
			
			
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;*/		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnlast').disabled=false;	
			/*document.getElementById('btnExit').disabled=false;*/
			
								
			return false;			
}

function checkcall(response)
{
		ds=response.value;
		if (ds.Tables[0].Rows.length <= 0)
		{
			alert("Your search can't produce any result");
			ascmCancelclick('AgencySubCategoryMaster');
			return false;
		}
		else
		{
		var companycode=document.getElementById('hiddencomcode').value;
		var agency=document.getElementById('drpagencytype').value;
		gbagency=agency;
		var category=document.getElementById('drpagencycat').value;
		gbcategory=category;
		var code=document.getElementById('txtasccode').value;
		gbasccode=code;
		var name=document.getElementById('txtascname').value;
		gbascname=name;
		var alias=document.getElementById('txtalias').value;
		gbalias=alias;
		var UserId=document.getElementById('hiddenuserid').value;	
					
		AgencySubCategoryMaster.ascmexecute1(companycode,agency,category,code,name,alias,UserId,checkcall1);							
		
		return false;
		}
}
						
function checkcall1(response)
{
		dsexecute=response.value;
		if(dsexecute.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
		
		document.getElementById('drpagencytype').value="0";
		document.getElementById('drpagencycat').value="0";
		document.getElementById('txtasccode').value="";
		document.getElementById('txtascname').value="";
			document.getElementById('txtalias').value="";
		
		
		
		return false;
		}
		else
		{
		document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[0].Agency_Type_Code;
		//document.getElementById('drpagencycat').value=ds.Tables[0].Rows[0].Agency_Cat_Code;
		document.getElementById('txtasccode').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Code;
		document.getElementById('txtascname').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Name;
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Alias;
		addagencycategory(dsexecute.Tables[0].Rows[0].Agency_Type_Code);
		ascmcat=dsexecute.Tables[0].Rows[0].Agency_Cat_Code;
		
			if(dsexecute.Tables[0].Rows.length==1)
		     {
		    document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
		    }
		    
		    
		}
	
		
	
		
		return false;
}

function ascmCancelclick(formname)
{
			
				
				//getPermission(formname);

				document.getElementById('drpagencytype').value="0";
				//document.getElementById('drpagencycat').value=("--Select Category--","0");
				var pkgitem=document.getElementById('drpagencycat');
 pkgitem.options.length=1;
 pkgitem.options[0]=new Option("----Select Category----","0");
				document.getElementById('txtasccode').value="";
				document.getElementById('txtascname').value="";
				document.getElementById('txtalias').value="";

				document.getElementById('drpagencytype').disabled=true;
				document.getElementById('drpagencycat').disabled=true;								
				document.getElementById('txtasccode').disabled=true;
				document.getElementById('txtascname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				chkstatus(FlagStatus);
				givebuttonpermission(formname);
				document.getElementById('btnNew').focus();

				/*document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
				document.getElementById('btnNew').disabled=false;
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
				
				return false;
}


function ascmSaveclick()
{
            document.getElementById('txtascname').value=trim(document.getElementById('txtascname').value);
              document.getElementById('txtasccode').value=trim(document.getElementById('txtasccode').value);
                document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);

			if(document.getElementById('drpagencytype').value=="0")
			{
				alert("Please Select Agency Type");
				document.getElementById('drpagencytype').focus();
				return false;
			}
			else if(document.getElementById('drpagencycat').value=="0")
			{
				alert("Please Select Agency Category");
				document.getElementById('drpagencycat').focus();
				return false;
			}
			
			else if((document.getElementById('txtasccode').value=="")&&  (document.getElementById('hiddenauto').value!=1))
			{
				alert("Please Fill Agency Sub Category Code");
				document.getElementById('txtasccode').focus();
				return false;
			}
			else if(document.getElementById('txtascname').value=="")
			{
				alert("Please Fill Agency Sub Category Name");
				document.getElementById('txtascname').focus();
				return false;
			}
			else if(document.getElementById('txtalias').value=="")
			{
				alert("Please Fill Agency Sub Category Alias");
				document.getElementById('txtalias').focus();
				return false;
			}
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var agency=document.getElementById('drpagencytype').value;
				var category=document.getElementById('drpagencycat').value;
				var code=document.getElementById('txtasccode').value;
				var name=document.getElementById('txtascname').value;
				var alias=document.getElementById('txtalias').value;
				var UserId=document.getElementById('hiddenuserid').value;	
				
				if(k!="1" && k!=null)
				{
					AgencySubCategoryMaster.chkascmcode(companycode,UserId,code,call_saveclick);
				}
				else
				{
					AgencySubCategoryMaster.ascmmodify(companycode,agency,category,code,name,alias,UserId); 
			        
			    dsexecute.Tables[0].Rows[z].Agency_Type_Code=document.getElementById('drpagencytype').value;
				dsexecute.Tables[0].Rows[z].Agency_Cat_Code=document.getElementById('drpagencycat').value;
				dsexecute.Tables[0].Rows[z].Agency_SubCat_Code=document.getElementById('txtasccode').value;
				dsexecute.Tables[0].Rows[z].Agency_SubCat_Name=document.getElementById('txtascname').value;
				dsexecute.Tables[0].Rows[z].Agency_SubCat_Alias=document.getElementById('txtalias').value;
			
			        if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                    }
                    else
                    {
	                    alert(xmlObj.childNodes(0).childNodes(1).text);
	                }
					//alert("Data Modified Successfully");
					updateStatus();
					document.getElementById('drpagencytype').disabled=true;
					document.getElementById('drpagencycat').disabled=true;								
					document.getElementById('txtasccode').disabled=true;
					document.getElementById('txtascname').disabled=true;
					document.getElementById('txtalias').disabled=true;
					
					/*document.getElementById('btnNew').disabled=true;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=false;
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;		
											
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;*/
					
					if(z==0)
					{
					document.getElementById('btnfirst').disabled=true;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=true;			
					document.getElementById('btnlast').disabled=false;
										
					}
					
					if(z==dsexecute.Tables[0].Rows.length-1)
					{
					//document.getElementById('btnfirst').disabled=true;				
					document.getElementById('btnnext').disabled=true;					
					//document.getElementById('btnprevious').disabled=true;			
					document.getElementById('btnlast').disabled=true;
										
					}
					
					k="0";
				}
			}
			return false;
}

function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Agency Sub Category Code Is Already Exist, Try Another Code !!!!");
				return false;
			} 
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var agency=document.getElementById('drpagencytype').value;
				var category=document.getElementById('drpagencycat').value;
				var code=document.getElementById('txtasccode').value;
				var name=document.getElementById('txtascname').value;
				var alias=document.getElementById('txtalias').value;
				var UserId=document.getElementById('hiddenuserid').value;	

				AgencySubCategoryMaster.ascmsave(companycode,agency,category,code,name,alias,UserId);
              
                    if(browser!="Microsoft Internet Explorer")
                    {
                        alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                    }
                    else
                    {
	                    alert(xmlObj.childNodes(0).childNodes(0).text);
	                }	
                    //alert("Data Saved Successfully");

				document.getElementById('drpagencytype').value="0";
				document.getElementById('drpagencycat').value="0";
				document.getElementById('txtasccode').value="";
				document.getElementById('txtascname').value="";
				document.getElementById('txtalias').value="";
				
				document.getElementById('drpagencytype').disabled=true;
				document.getElementById('drpagencycat').disabled=true;								
				document.getElementById('txtasccode').disabled=true;
				document.getElementById('txtascname').disabled=true;
				document.getElementById('txtalias').disabled=true;		
				
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
			}
ascmCancelclick('AgencySubCategoryMaster');
			return false;
}


function ascmModifyclick()
{
				document.getElementById('drpagencytype').disabled=false;
				document.getElementById('drpagencycat').disabled=false;								
				document.getElementById('txtasccode').disabled=true;
				document.getElementById('txtascname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				
				
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				
				k="1";
				hiddentext="modify";
					/*document.getElementById('btnNew').disabled=true;
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

/*function ascmfirstclick()
{				
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				
				AgencySubCategoryMaster.ascmfirst(companycode,UserId,firstcall);
				
				document.getElementById('drpagencytype').disabled=true;
				document.getElementById('drpagencycat').disabled=true;								
				document.getElementById('txtasccode').disabled=true;
				document.getElementById('txtascname').disabled=true;
				document.getElementById('txtalias').disabled=true;		
					
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
}*/

function ascmfirstclick()
{
				//ds=response.value;
				
				document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[0].Agency_Type_Code;
				//document.getElementById('drpagencycat').value=ds.Tables[0].Rows[0].Agency_Cat_Code;
				document.getElementById('txtasccode').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Code;
				document.getElementById('txtascname').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Name;
				document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[0].Agency_SubCat_Alias;
				addagencycategory(dsexecute.Tables[0].Rows[0].Agency_Type_Code);
				ascmcat=dsexecute.Tables[0].Rows[0].Agency_Cat_Code;
				z=0;
				
				updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
				return false;
}

/*function ascmpreviousclick()
{
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				
				AgencySubCategoryMaster.ascmprevious(companycode,UserId,previouscall);
				
				return false;
}*/

function ascmpreviousclick()
{
		z=z-1;
		//ds=response.value;
		var x=dsexecute.Tables[0].Rows.length;
	
		
		if(z>x)
		{
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnlast').disabled=true;
				return false;
		}
		if(z!=-1 && z>=0)
		{
		if(dsexecute.Tables[0].Rows.length != z)
		{
				document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[z].Agency_Type_Code;
				//document.getElementById('drpagencycat').value=ds.Tables[0].Rows[z].Agency_Cat_Code;
				document.getElementById('txtasccode').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Code;
				document.getElementById('txtascname').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Name;
				document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Alias;
				updateStatus();
				addagencycategory(dsexecute.Tables[0].Rows[z].Agency_Type_Code);
				ascmcat=dsexecute.Tables[0].Rows[z].Agency_Cat_Code;					
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
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
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnlast').disabled=false;	
				return false;		
		}	
		
		return false;
		
}

/*function ascmnextclick()
{
		        
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				AgencySubCategoryMaster.ascmnext(companycode,UserId,nextcall);
				return false;
}*/

function ascmnextclick()
{		
		z++;
		//ds=response.value;
		var x=dsexecute.Tables[0].Rows.length;
		if(z <= x && z >= 0)
		{
			if(dsexecute.Tables[0].Rows.length != z  && z !=-1)
			{
				document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[z].Agency_Type_Code;
				//document.getElementById('drpagencycat').value=ds.Tables[0].Rows[z].Agency_Cat_Code;
				document.getElementById('txtasccode').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Code;
				document.getElementById('txtascname').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Name;
				document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[z].Agency_SubCat_Alias;
				updateStatus();						
					addagencycategory(dsexecute.Tables[0].Rows[z].Agency_Type_Code);
					ascmcat=dsexecute.Tables[0].Rows[z].Agency_Cat_Code;
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnnext').disabled=false;					
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

/*function ascmlastclick()
{		
				var companycode=document.getElementById('hiddencomcode').value;
				var UserId=document.getElementById('hiddenuserid').value;
				AgencySubCategoryMaster.ascmlast(companycode,UserId,lastcall)
				return false;
}*/

function ascmlastclick()
{
		//ds= response.value;
		//alert("HI");
     	var x=dsexecute.Tables[0].Rows.length;
		z=x-1;
		x=x-1;

		document.getElementById('drpagencytype').value=dsexecute.Tables[0].Rows[x].Agency_Type_Code;
		//document.getElementById('drpagencycat').value=ds.Tables[0].Rows[x].Agency_Cat_Code;
		document.getElementById('txtasccode').value=dsexecute.Tables[0].Rows[x].Agency_SubCat_Code;
		document.getElementById('txtascname').value=dsexecute.Tables[0].Rows[x].Agency_SubCat_Name;
		document.getElementById('txtalias').value=dsexecute.Tables[0].Rows[x].Agency_SubCat_Alias;
	    addagencycategory(dsexecute.Tables[0].Rows[x].Agency_Type_Code);
	    ascmcat=dsexecute.Tables[0].Rows[x].Agency_Cat_Code;
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;

		
		return false;
}

function ascmExitclick()
{
	if(confirm("Do You Want To Skip This Page"))
	{
		window.close();
		return false;
	}
	else
	{
		return false;
	}
}

function uppercase1()
{
document.getElementById('txtasccode').value=document.getElementById('txtasccode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
return ;
}


		
function charval()
{
if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==37)||
(event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||
(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function charval1()
{
if((event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==37)||(event.keyCode==32))
{
return true;
}
else
{
return false;
}
}

function addagencycategory(ab)
{
var agency=document.getElementById('drpagencytype').value;
if(agency!="0")
{
AgencySubCategoryMaster.addcategory(agency,callcount);
}
else
{
var agcat = document.getElementById("drpagencycat");
//alert(pkgitem);
    agcat.options.length = 1; 
    agcat.options[0]=new Option("--Select Category--","0");

}

return false;
}

function callcount(res)
{

var ds=res.value;

if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{

var agcat = document.getElementById("drpagencycat");
//alert(pkgitem);
    agcat.options.length = 1; 
    agcat.options[0]=new Option("--Select Category--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
    {
        agcat.options[agcat.options.length] = new Option(res.value.Tables[0].Rows[i].Agency_Cat_Name,res.value.Tables[0].Rows[i].Agency_Cat_Code);
        
       agcat.options.length;
       
    }
    //alert(cityvar);
 if(ascmcat == undefined || ascmcat=="")
 {
  document.getElementById('drpagencycat').value="0";
 
 }
 else
 {
  document.getElementById('drpagencycat').value=ascmcat;
  ascmcat="";
  } 
}
else
{
alert("There is No Matching value Found");
return false;

}

return false;
}

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
            document.getElementById('txtascname').value=document.getElementById('txtascname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		 document.getElementById('txtascname').value=trim(document.getElementById('txtascname').value);
          	  lstr=document.getElementById('txtascname').value;
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
		
		    if(document.getElementById('txtascname').value!="")
               {
		document.getElementById('txtascname').value=document.getElementById('txtascname').value.toUpperCase();
		document.getElementById('txtalias').value=document.getElementById('txtascname').value;
	    //str=document.getElementById('txtascname').value;
	    str=mstr;
		AgencySubCategoryMaster.chkascmcodename(str,fillcall);
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
		    alert("This Agency Sub Category Name has already assigned !! ");
		     document.getElementById('txtascname').value="";
                 document.getElementById('txtasccode').value="";
                 document.getElementById('txtalias').value="";
             
		    document.getElementById('txtascname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Agency_SubCat_Code;
		                        }
		                    if(newstr !=null )
		                        {//alert(newstr);
		                        var code=newstr;//.substr(2,4);
		                        code++;
		                        str=str.toUpperCase();
		                        //alert(str);
		                        document.getElementById('txtasccode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                         str=str.toUpperCase();
		                          document.getElementById('txtasccode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtasccode').disabled=false;
        document.getElementById('txtascname').value=document.getElementById('txtascname').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtascname').value;
	   
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

	
