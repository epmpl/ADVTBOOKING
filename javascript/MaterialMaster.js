var flag;
var z=0;
function matnew()
{
				flag="1";

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

				document.getElementById('txtmatcode').disabled= false;
				document.getElementById('txtmatname').disabled= false;
				document.getElementById('txtmatalias').disabled= false;

				document.getElementById('txtmatcode').value="";
				document.getElementById('txtmatname').value="";
				document.getElementById('txtmatalias').value="";
				
				chkstatus(FlagStatus);			
	
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;

				return false;
}

function matsave()
{
				if(document.getElementById('txtmatcode').value=="")
				{
						alert("Please Enter Material Code");
						document.getElementById('txtmatcode').focus;
						return false;
				}
				else if(document.getElementById('txtmatname').value=="")
				{
						alert("Please Enter Material Name");
						document.getElementById('txtmatname').focus;
						return false;
				}
				else if(document.getElementById('txtmatalias').value=="")
				{
						alert("Please Enter Alias");
						document.getElementById('txtmatalias').focus;
						return false;
				}

				var compcode=document.getElementById('hiddencompcode').value;
				var matcode=document.getElementById('txtmatcode').value;
				var matname=document.getElementById('txtmatname').value;
				var matalias=document.getElementById('txtmatalias').value;
				var userid=document.getElementById('hiddenuserid').value;

				if(flag=="1")
				{
					MaterialMaster.chk(compcode,matcode,matname,userid,callsave)
					return false;
				}
				else
				{
					MaterialMaster.updatemat(compcode,matcode,matname,userid,matalias)

					document.getElementById('btnNew').disabled=true;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=false;
					document.getElementById('btnDelete').disabled=true;
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;		
					document.getElementById('btnDelete').disabled=false;
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;	
					
					document.getElementById('txtmatcode').disabled= true;
					document.getElementById('txtmatname').disabled= true;
					document.getElementById('txtmatalias').disabled= true;
					
					alert("Data Modified Successfully");
					return false;
				}

				return false;
}

function callsave(response)
{
					var ds= response.value;
					if(ds.Tables[0].Rows.length>0)
					{
						alert("This Material Code Already Exist");
						return false;
					}
					else if(ds.Tables[1].Rows.length>0)
					{
						alert("This Material Name Already Exist");
						return false;
					}
					else
					{
						var compcode=document.getElementById('hiddencompcode').value;
						var matcode=document.getElementById('txtmatcode').value;
						var matname=document.getElementById('txtmatname').value;
						var matalias=document.getElementById('txtmatalias').value;
						var userid=document.getElementById('hiddenuserid').value;

						MaterialMaster.insertmat(compcode,matcode,matname,userid,matalias)

						alert("Data Saved Successfully");

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
						document.getElementById('btnDelete').disabled = true;
						
						document.getElementById('txtmatcode').disabled= true;
						document.getElementById('txtmatname').disabled= true;
						document.getElementById('txtmatalias').disabled= true;
						
						document.getElementById('txtmatcode').value="";
						document.getElementById('txtmatname').value="";
						document.getElementById('txtmatalias').value="";
	 
						return false;
					}
 
					return false;
}

function matmodify()
{
				flag="2";
 
				/*document.getElementById('btnNew').disabled=true;
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
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled = true;*/
				chkstatus(FlagStatus);
				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('txtmatcode').disabled= true;
				document.getElementById('txtmatname').disabled= false;
				document.getElementById('txtmatalias').disabled= false;
				return false;
}


function matexe()
{
				var compcode=document.getElementById('hiddencompcode').value;
				var matcode=document.getElementById('txtmatcode').value;
				var matname=document.getElementById('txtmatname').value;
				var matalias=document.getElementById('txtmatalias').value;
				var userid=document.getElementById('hiddenuserid').value;

				MaterialMaster.exemat(compcode,matcode,matname,userid,matalias,execall)

				document.getElementById('txtmatcode').disabled= true;
				document.getElementById('txtmatname').disabled= true;
				document.getElementById('txtmatalias').disabled= true;
				
				updateStatus();
					document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
				return false;
}

function execall(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length>0)
			{
						document.getElementById('txtmatcode').value=ds.Tables[0].Rows[0].Mat_Code;
						document.getElementById('txtmatname').value=ds.Tables[0].Rows[0].Mat_Name;
						document.getElementById('txtmatalias').value=ds.Tables[0].Rows[0].Mat_Alias;

						/*document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						document.getElementById('btnModify').disabled=false;
						document.getElementById('btnDelete').disabled=true;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=false;	
						document.getElementById('btnExit').disabled=false;
						document.getElementById('btnDelete').disabled = false;*/

						return false;
			}
			else
			{
						alert("This Search Criteria DoesNot Produce Any Result");
						return false;
			}
}


function firstmat()
{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;

				MaterialMaster.fnplmat(compcode,userid,firstcall)

				document.getElementById('txtmatcode').disabled= true;
				document.getElementById('txtmatname').disabled= true;
				document.getElementById('txtmatalias').disabled= true;

				return false;
}


function firstcall(response)
{
				ds=response.value;
		z=0;
				document.getElementById('txtmatcode').value=ds.Tables[0].Rows[0].Mat_Code;
				document.getElementById('txtmatname').value=ds.Tables[0].Rows[0].Mat_Name;
				document.getElementById('txtmatalias').value=ds.Tables[0].Rows[0].Mat_Alias;
				
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=false;	
				return false;
}


function premat()
{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;

				MaterialMaster.fnplmat(compcode,userid,precall)

				document.getElementById('txtmatcode').disabled= true;
				document.getElementById('txtmatname').disabled= true;
				document.getElementById('txtmatalias').disabled= true;
				return false;
}


function precall(response)
{
				var ds=response.value;
var a=ds.Tables[0].Rows.length;

z--;
if(z != -1  )
		{
			if(z >= 0 && z < a)
			{
					document.getElementById('txtmatcode').value=ds.Tables[0].Rows[z].Mat_Code;
					document.getElementById('txtmatname').value=ds.Tables[0].Rows[z].Mat_Name;
					document.getElementById('txtmatalias').value=ds.Tables[0].Rows[z].Mat_Alias;

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

function nextmat()
{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;

				MaterialMaster.fnplmat(compcode,userid,nextcall)

				document.getElementById('txtmatcode').disabled= true;
				document.getElementById('txtmatname').disabled= true;
				document.getElementById('txtmatalias').disabled= true;
				return false;
}

function nextcall(response)
{
	var ds=response.value;
var a=ds.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
				document.getElementById('txtmatcode').value=ds.Tables[0].Rows[z].Mat_Code;
				document.getElementById('txtmatname').value=ds.Tables[0].Rows[z].Mat_Name;
				document.getElementById('txtmatalias').value=ds.Tables[0].Rows[z].Mat_Alias;
updateStatus();
document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
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

return false;
		
}

function lastmat()
{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;

				MaterialMaster.fnplmat(compcode,userid,lastcall);

				document.getElementById('txtmatcode').disabled= true;
				document.getElementById('txtmatname').disabled= true;
				document.getElementById('txtmatalias').disabled= true;
				return false;
}


function lastcall(response)
{
			ds= response.value;
			var x=ds.Tables[0].Rows.length;
			z=x-1;
			x=x-1;

			document.getElementById('txtmatcode').value=ds.Tables[0].Rows[x].Mat_Code;
			document.getElementById('txtmatname').value=ds.Tables[0].Rows[x].Mat_Name;
			document.getElementById('txtmatalias').value=ds.Tables[0].Rows[x].Mat_Alias;				
			
			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;

			return false;
}

function matcancle(formname)
{
			document.getElementById('btnNew').disabled=false;
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
			document.getElementById('btnExit').disabled=false;	
			document.getElementById('btnDelete').disabled = true;
				
			document.getElementById('txtmatcode').disabled= true;
			document.getElementById('txtmatname').disabled= true;
			document.getElementById('txtmatalias').disabled= true;

			document.getElementById('txtmatcode').value="";
			document.getElementById('txtmatname').value="";
			document.getElementById('txtmatalias').value="";
			
			getPermission('MaterialMaster');

			return false;
}

function querymat()
{
			/*	document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=false;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled = true;*/
				
				document.getElementById('txtmatcode').disabled= false;
				document.getElementById('txtmatname').disabled= false;
				document.getElementById('txtmatalias').disabled= false;

				document.getElementById('txtmatcode').value="";
				document.getElementById('txtmatname').value="";
				document.getElementById('txtmatalias').value="";
				
				chkstatus(FlagStatus);
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=false;
				document.getElementById('btnSave').disabled=true;
				z=0;
				return false;
}

function matexit()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			window.location.href='EnterPage.aspx';
			return false;
		}
		return false;

}

function matdelete()
{
			var compcode=document.getElementById('hiddencompcode').value;
			var matcode=document.getElementById('txtmatcode').value;
			var matname=document.getElementById('txtmatname').value;
			var matalias=document.getElementById('txtmatalias').value;
			var userid=document.getElementById('hiddenuserid').value;
	
			if(confirm("Are You Sure To Delete The Data"))
			{
				MaterialMaster.deletemat(compcode,matcode,matname,matalias,userid); 
					
				alert("Data Deleted Sucessfully");
				
				MaterialMaster.fnplmat(compcode,userid,call_delete);
					
				document.getElementById('txtmatcode').disabled=true;
				document.getElementById('txtmatname').disabled=true;
				document.getElementById('txtmatalias').disabled=true;	
			}
			return false;

}

function call_delete(response)
{
	var ds= response.value;
	len=ds.Tables[0].Rows.length;
	var a=ds.Tables[0].Rows.length;
	
	if( a <=0 )
	{
			alert("There Is No Data");
			document.getElementById('txtmatcode').value="";
			document.getElementById('txtmatname').value="";
			document.getElementById('txtmatalias').value="";
			matcancle('MaterialMaster');
	}
	
	else if(z==-1 ||z>=len )
	{
	        
	        document.getElementById('txtmatcode').value=ds.Tables[0].Rows[0].Mat_Code;
			document.getElementById('txtmatname').value=ds.Tables[0].Rows[0].Mat_Name;
	        document.getElementById('txtmatalias').value=ds.Tables[0].Rows[0].Mat_Alias;
	}
	else
	{
	        document.getElementById('txtmatcode').value=ds.Tables[0].Rows[z].Mat_Code;
			document.getElementById('txtmatname').value=ds.Tables[0].Rows[z].Mat_Name;
	        document.getElementById('txtmatalias').value=ds.Tables[0].Rows[z].Mat_Alias;
	}
	
	return false;
}