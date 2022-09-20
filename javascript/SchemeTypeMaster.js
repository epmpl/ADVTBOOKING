var z=0;
var flag="0";
var hiddentext;
var auto="";
var sctds;
var glschemecode="";
var glschemename="";

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



function schemenew()
{
		  if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtSchemeTypCode').disabled=true;
    	      }
		     else
		       {
		       document.getElementById('txtSchemeTypCode').disabled=false;
    	       }

		
		document.getElementById('txtSchemeTypCode').value="";
		document.getElementById('txtSchemeTypeName').value="";

		//document.getElementById('txtSchemeTypCode').disabled=false;
		document.getElementById('txtSchemeTypeName').disabled=false;

		if(document.getElementById('hiddenauto').value==1)
		     {
		     document.getElementById('txtSchemeTypeName').focus();
    	      }
		     else
		       {
		       document.getElementById('txtSchemeTypCode').focus();
    	       }

		/*document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=false;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnQuery').disabled=true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;
		document.getElementById('btnprevious').disabled=true;*/
		
		chkstatus(FlagStatus);
					hiddentext="new";
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
		flag=0;
		return false;
}

function schemecancel(formname)
{
		document.getElementById('txtSchemeTypCode').value="";
		document.getElementById('txtSchemeTypeName').value="";

		//getPermission('SchemeTypeMaster');

		         document.getElementById('txtSchemeTypCode').disabled=true;
		         document.getElementById('txtSchemeTypeName').disabled=true;
		         
		         chkstatus(FlagStatus);
		         givebuttonpermission(formname);
		         
			  /*  document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
			    document.getElementById('btnCancel').disabled=false;
			
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
			
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;*/
			
		return false;
}

function schememodify()
{
		flag=1;
		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;
		
		chkstatus(FlagStatus);
		hiddentext="modify";
		  document.getElementById('btnModify').disabled = true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled=true;
			
		document.getElementById('txtSchemeTypCode').disabled=true;
		document.getElementById('txtSchemeTypeName').disabled=false;
		return false;
}

function schemesave()
{
			document.getElementById('txtSchemeTypCode').value=trim(document.getElementById('txtSchemeTypCode').value);
			document.getElementById('txtSchemeTypeName').value=trim(document.getElementById('txtSchemeTypeName').value);
			
			if ((document.getElementById('txtSchemeTypCode').value=="") &&(document.getElementById('hiddenauto').value!=1))
            
			{
				alert("Please Fill Scheme Type Code");
				document.getElementById('txtSchemeTypCode').focus();
				return false;
			}
			else if(document.getElementById('txtSchemeTypeName').value=="")
			{
				alert("Please Fill Scheme Type Name");
				document.getElementById('txtSchemeTypeName').focus();
				return false;
			}
			else
			{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var SchemTypeCode=document.getElementById('txtSchemeTypCode').value;
				var SchemeTypeName=document.getElementById('txtSchemeTypeName').value;
			
				if(flag!="1" && flag!=null)
				{
					SchemeTypeMaster.checkscheme(SchemTypeCode,compcode,userid,call_saveclick); 
				}
				else
				{
					SchemeTypeMaster.modify(SchemTypeCode,SchemeTypeName,compcode,userid);
			
					//alert("Data Modified Successfully");
					alert(xmlObj.childNodes(0).childNodes(1).text);
					
					sctds.Tables[0].Rows[z].Scheme_Type_Code=document.getElementById('txtSchemeTypCode').value;
			        sctds.Tables[0].Rows[z].Scheme_Type_Name=document.getElementById('txtSchemeTypeName').valuess;
					
					document.getElementById('txtSchemeTypCode').disabled=true;
					document.getElementById('txtSchemeTypeName').disabled=true;
										
				/*	document.getElementById('btnNew').disabled=true;
			        document.getElementById('btnSave').disabled=true;
			        document.getElementById('btnModify').disabled=false;
			        document.getElementById('btnDelete').disabled=false;
			        document.getElementById('btnQuery').disabled=false;
			        document.getElementById('btnExecute').disabled=true;
			        document.getElementById('btnCancel').disabled=false;
			        document.getElementById('btnfirst').disabled=false;
			        document.getElementById('btnnext').disabled=false;
			        document.getElementById('btnlast').disabled=false;
			        document.getElementById('btnExit').disabled=false;
			        document.getElementById('btnprevious').disabled=false;*/


					updateStatus();
					
					flag="0";
				}
			}
			return false;
}

function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Scheme Type Code Is Already Exist, Try Another Code !!!!");
				return false;
			} 
			else
			{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var SchemTypeCode=document.getElementById('txtSchemeTypCode').value;
				var SchemeTypeName=document.getElementById('txtSchemeTypeName').value;

				SchemeTypeMaster.insert(SchemTypeCode,SchemeTypeName,compcode,userid);

				//alert("Data Saved Successfully");
alert(xmlObj.childNodes(0).childNodes(0).text);
				document.getElementById('txtSchemeTypCode').value="";
				document.getElementById('txtSchemeTypeName').value="";
										
				document.getElementById('txtSchemeTypCode').disabled=true;
				document.getElementById('txtSchemeTypeName').disabled=true;
												
				/*document.getElementById('btnNew').disabled=false;
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
				document.getElementById('btnlast').disabled=true;*/
			}
schemecancel('SchemeTypeMaster');
			return false;
}

function schemequery()
{
        /*document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnModify').disabled=true;
		document.getElementById('btnDelete').disabled=true;
		document.getElementById('btnQuery').disabled=true;
		document.getElementById('btnExecute').disabled=false;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnExit').disabled=false;
		document.getElementById('btnprevious').disabled=true;*/
		z=0;
		hiddentext="query";
		chkstatus(FlagStatus);
		
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;

		document.getElementById('txtSchemeTypCode').value="";
		document.getElementById('txtSchemeTypeName').value="";

		document.getElementById('txtSchemeTypCode').disabled=false;
		document.getElementById('txtSchemeTypeName').disabled=false;
		return false;
}

function schemeexecute()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SchemTypeCode=document.getElementById('txtSchemeTypCode').value;
		var SchemeTypeName=document.getElementById('txtSchemeTypeName').value;

		SchemeTypeMaster.Select(SchemTypeCode,SchemeTypeName,compcode,userid,call_Execute);
		updateStatus();
			/*document.getElementById('btnNew').disabled=true;
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
			document.getElementById('btnExit').disabled=false;*/

			
			return false;
}

function call_Execute(response)
{
		//var ds=response.value;
		sctds=response.value;
		if (sctds.Tables[0].Rows.length>0)
		{
			document.getElementById('txtSchemeTypCode').value=sctds.Tables[0].Rows[0].Scheme_Type_Code;
			document.getElementById('txtSchemeTypeName').value=sctds.Tables[0].Rows[0].Scheme_Type_Name;
            glschemecode=document.getElementById('txtSchemeTypCode').value
            glschemename=document.getElementById('txtSchemeTypeName').value
                             		
            
		/*	document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			//document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnExit').disabled=false;
			//document.getElementById('btnprevious').disabled=false;*/
			
			//document.getElementById('btnfirst').disabled=true;
			//document.getElementById('btnprevious').disabled=true;

			document.getElementById('txtSchemeTypCode').disabled=true;
			document.getElementById('txtSchemeTypeName').disabled=true;

			z=0;
		}
		else
		{
			
//				document.getElementById('btnModify').disabled=true;
//				document.getElementById('btnDelete').disabled=true;
//			document.getElementById('txtSchemeTypCode').disabled=true;
//			document.getElementById('txtSchemeTypeName').disabled=true;
			alert("Search Criteria Does Not Match");
			schemecancel('SchemeTypeMaster');
			
		}
		
		if(sctds.Tables[0].Rows.length==1)
		{
		document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		
		}
		
		return false;
		
		
}


function schemefirst()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SchemTypeCode=document.getElementById('txtSchemeTypCode').value;
		var SchemeTypeName=document.getElementById('txtSchemeTypeName').value;
		
		SchemeTypeMaster.Selectfnpl(SchemTypeCode,SchemeTypeName,compcode,userid,call_First);
		return false;
}

function call_First(response)
{
		z=0;
		//var ds=response.value;
		document.getElementById('txtSchemeTypCode').value=sctds.Tables[0].Rows[0].Scheme_Type_Code;
		document.getElementById('txtSchemeTypeName').value=sctds.Tables[0].Rows[0].Scheme_Type_Name;
updateStatus();
document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;
	document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;	
		/*document.getElementById('btnNew').disabled=true;
		document.getElementById('btnSave').disabled=true;
		document.getElementById('btnModify').disabled=false;
		document.getElementById('btnDelete').disabled=false;
		document.getElementById('btnQuery').disabled=false;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnCancel').disabled=false;
		document.getElementById('btnfirst').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnExit').disabled=false;*/
}


function schemenext()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SchemTypeCode=document.getElementById('txtSchemeTypCode').value;
		var SchemeTypeName=document.getElementById('txtSchemeTypeName').value;
		
		SchemeTypeMaster.Selectfnpl(SchemTypeCode,SchemeTypeName,compcode,userid,call_Next);
		return false;
}

function call_Next(response)
{
		z++;
		//var ds=response.value;
		var y=sctds.Tables[0].Rows.length;
		var k=y-1;

		if(document.getElementById('btnprevious').disabled=true)
		{
		document.getElementById('btnprevious').disabled=false;
		}
		if(document.getElementById('btnfirst').disabled=true)
		{
		document.getElementById('btnfirst').disabled=false;
		}

		if(z !=-1 && z >= 0)
		{
		  if(z <= y-1)
		   {
			document.getElementById('txtSchemeTypCode').value=sctds.Tables[0].Rows[z].Scheme_Type_Code;
			document.getElementById('txtSchemeTypeName').value=sctds.Tables[0].Rows[z].Scheme_Type_Name;
			updateStatus();
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
		
		if(z==y-1)
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
return false;
}


function schemeprevious()
{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SchemTypeCode=document.getElementById('txtSchemeTypCode').value;
		var SchemeTypeName=document.getElementById('txtSchemeTypeName').value;

		SchemeTypeMaster.Selectfnpl(SchemTypeCode,SchemeTypeName,compcode,userid,call_Previous);
		return false;
}

function call_Previous(response)
{
		//var ds=response.value;
		var y=sctds.Tables[0].Rows.length;
		var p=y-1;
		z--;

		if(document.getElementById('btnnext').disabled=true)
		{
		document.getElementById('btnnext').disabled=false;
		}
		if(document.getElementById('btnlast').disabled=true)
		{
		document.getElementById('btnlast').disabled=false;
		}
		if(z != -1  )
		{
			if(z >= 0 &&  z < y)
			{
				document.getElementById('txtSchemeTypCode').value=sctds.Tables[0].Rows[z].Scheme_Type_Code;
				document.getElementById('txtSchemeTypeName').value=sctds.Tables[0].Rows[z].Scheme_Type_Name;
				updateStatus();
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
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}	
return false;
}

function schemelast()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var SchemTypeCode=document.getElementById('txtSchemeTypCode').value;
			var SchemeTypeName=document.getElementById('txtSchemeTypeName').value;

			SchemeTypeMaster.Selectfnpl(SchemTypeCode,SchemeTypeName,compcode,userid,call_Last);
			return false;
}

function call_Last(response)
{
		//	var sctds=response.value;
			var y=sctds.Tables[0].Rows.length;
			z=y-1;

			document.getElementById('txtSchemeTypCode').value=sctds.Tables[0].Rows[z].Scheme_Type_Code;
			document.getElementById('txtSchemeTypeName').value=sctds.Tables[0].Rows[z].Scheme_Type_Name;
			updateStatus();
			document.getElementById('txtSchemeTypCode').disabled=true;
			document.getElementById('txtSchemeTypeName').disabled=true;
			
			document.getElementById('btnnext').disabled=true;
	        document.getElementById('btnlast').disabled=true;
	        document.getElementById('btnfirst').disabled=false;
	        document.getElementById('btnprevious').disabled=false;

			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnprevious').disabled=false;
			document.getElementById('btnExit').disabled=false;*/
			return false;
}

function schemeexit()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			//window.location.href='EnterPage.aspx';
			window.close();
			return false;
		}
		return false;	
}

function schemedelete()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;

			var SchemTypeCode=document.getElementById('txtSchemeTypCode').value;
			var SchemeTypeName=document.getElementById('txtSchemeTypeName').value;

			if(confirm("Are You Sure To Delete The Data"))
			{
				
				SchemeTypeMaster.deleteScheme(SchemTypeCode,compcode,userid);
				
				//alert("Value Deleted Sucessfully");
				alert(xmlObj.childNodes(0).childNodes(2).text);
				
				SchemeTypeMaster.Select(glschemecode,glschemename,compcode,userid,call_deleteclick);
				
				//SchemeTypeMaster.Selectfnpl(SchemTypeCode,SchemeTypeName,compcode,userid,call_deleteclick);
			}
			return false;
}

function call_deleteclick(response)
{
	
	sctds=response.value;
	//var ds=response.value;
	var a=sctds.Tables[0].Rows.length;
	var y=a-1;
	
	if(a==0)
	{
			alert("There Is No Data");
			document.getElementById('txtSchemeTypCode').value="";
			document.getElementById('txtSchemeTypeName').value="";
			schemecancel('SchemeTypeMaster');
	}
	else if(z==-1 ||z>=a )
	{
		document.getElementById('txtSchemeTypCode').value=sctds.Tables[0].Rows[0].Scheme_Type_Code;
		document.getElementById('txtSchemeTypeName').value=sctds.Tables[0].Rows[0].Scheme_Type_Name;
	}
	else
	{
			document.getElementById('txtSchemeTypCode').value=sctds.Tables[0].Rows[z].Scheme_Type_Code;
		document.getElementById('txtSchemeTypeName').value=sctds.Tables[0].Rows[z].Scheme_Type_Name;
	
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
            document.getElementById('txtSchemeTypeName').value=document.getElementById('txtSchemeTypeName').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		 // document.getElementById('txtSchemeTypCode').value=trim(document.getElementById('txtSchemeTypCode').value);
			document.getElementById('txtSchemeTypeName').value=trim(document.getElementById('txtSchemeTypeName').value);
			 lstr=document.getElementById('txtSchemeTypeName').value;
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
		    if(document.getElementById('txtSchemeTypeName').value!="")
                {
                
          
                
                 document.getElementById('txtSchemeTypeName').value=document.getElementById('txtSchemeTypeName').value.toUpperCase();
	            //document.getElementById('txtAlias').value=document.getElementById('txtColorName').value;
		       // str=document.getElementById('txtSchemeTypeName').value;
		       str=mstr;
		        SchemeTypeMaster.chkschemecode(str,fillcall);
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
		    alert("This Scheme Type Name  has already assigned !! ");
		    document.getElementById('txtSchemeTypCode').value="";
		    document.getElementById('txtSchemeTypeName').value="";

		    
		    document.getElementById('txtSchemeTypeName').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Scheme_Type_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                      //  var code=newstr.substr(2,4);
		                      var code=newstr;
		                        code++;
		                        document.getElementById('txtSchemeTypCode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtSchemeTypCode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtSchemeTypCode').disabled=false;
        document.getElementById('txtSchemeTypeName').value=document.getElementById('txtSchemeTypeName').value.toUpperCase();
       // document.getElementById('txtAlias').value=document.getElementById('txtColorName').value;
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