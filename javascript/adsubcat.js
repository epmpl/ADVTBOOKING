var z=0;

		/*	function codecat()
		{
		
	 var  catname=	document.getElementById('drpadvcatcode').value ;

		adsubcat1.catcod(catname,codecall)
		return false;
		}

function codecall(response)
		{
		ds=response.value;
		document.getElementById('hiddencatcode').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
		}*/




function subcatinsert()
				{
				//alert("hi");
				
				z=1;

				/*==============navigation================*/
				document.getElementById('btnNew').disabled=true;
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
				document.getElementById('btnExit').disabled=false;
				
				document.getElementById('drpadvcatcode').disabled=false;
				document.getElementById('txtsubcatcode').disabled=false;
				document.getElementById('txtadsubcatname').disabled=false;
				document.getElementById('txtalias').disabled=false;
			return false;
			}
			
			
function canceladsubcat()

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
				
				document.getElementById('drpadvcatcode').disabled=true;
				document.getElementById('txtsubcatcode').disabled=true;
				document.getElementById('txtadsubcatname').disabled=true;
				document.getElementById('txtalias').disabled=true;
						
				
				document.getElementById('drpadvcatcode').value=0;
				document.getElementById('txtsubcatcode').value="";
				document.getElementById('txtadsubcatname').value="";
				document.getElementById('txtalias').value="";	
				return false;
			}
			
function saveadsubcat()
{
				if(z==1)
				{
					savenew();
					return false;
				}
				else
				{
					savemodify();
				return false;
				}

}


function savenew()
{     
if(document.getElementById('drpadvcatcode').value==0)
		{
		
		alert("You Must Select Ad Category Name");
		document.getElementById('drpadvcatcode').focus();
		return false;
		}
		else
		{}
		
		
		 if(document.getElementById('txtsubcatcode').value=="")
		{
		alert("You Must Enter Sub Category Code");
		document.getElementById('txtsubcatcode').focus();
		return false;
		}
		else
		{}
		if (document.getElementById('txtadsubcatname').value=="")
		{
		alert("You Must Enter Ad Sub Category Name");
		document.getElementById('txtadsubcatname').focus();
		return false;
		}
		else
		{}
		 if(document.getElementById('txtalias').value=="")
		{
		alert("You must Enter The Alias Name");
		document.getElementById('txtalias').focus();
		return false;
		}
		else
		{}
		
		
		
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpadvcatcode').value;
		var subcatcode =document.getElementById('txtsubcatcode').value;
		var subcatname =document.getElementById('txtadsubcatname').value;
		var subcatalias =document.getElementById('txtalias').value;
		var userid=document.getElementById('hiddenuserid').value; 
		
		adsubcat1.subcatsave(compcode,catcode,subcatcode,subcatname,subcatalias,userid)
		
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
					
					
				document.getElementById('drpadvcatcode').value=0;
				document.getElementById('txtsubcatcode').value="";
				document.getElementById('txtadsubcatname').value="";
				document.getElementById('txtalias').value="";
				
				document.getElementById('drpadvcatcode').disabled=true;
				document.getElementById('txtsubcatcode').disabled=true;
				document.getElementById('txtadsubcatname').disabled=true;
				document.getElementById('txtalias').disabled=true;
				
				alert("Data Saved");
					return false;

}


function savemodify()
{

			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('drpadvcatcode').value;
			var subcatcode =document.getElementById('txtsubcatcode').value;
			var subcatname =document.getElementById('txtadsubcatname').value;
			var subcatalias =document.getElementById('txtalias').value;
			var userid=document.getElementById('hiddenuserid').value; 


			adsubcat1.subcatupdate(compcode,catcode,subcatcode,subcatname,subcatalias,userid)
					document.getElementById('btnNew').disabled=true;
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
					
					alert("Data Modified");
					
					
					
						document.getElementById('drpadvcatcode').disabled=true;
						document.getElementById('txtsubcatcode').disabled=true;
						document.getElementById('txtadsubcatname').disabled=false;
						document.getElementById('txtalias').disabled=false;	
						
						document.getElementById('drpadvcatcode').value=0;
						document.getElementById('txtsubcatcode').value="";
						document.getElementById('txtadsubcatname').value="";
						document.getElementById('txtalias').value="";
				
						
					return false;


}


function modifyadsubcat()
{
			z=2 ;
				document.getElementById('btnNew').disabled=true;
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
				
				
				document.getElementById('drpadvcatcode').disabled=true;
				document.getElementById('txtsubcatcode').disabled=true;
				document.getElementById('txtadsubcatname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				
				
				
				
				return false;



}



function queryadsubcat()
{

			
		
				document.getElementById('btnNew').disabled=true;
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
				
				
				document.getElementById('drpadvcatcode').disabled=false;
				document.getElementById('txtsubcatcode').disabled=false;
				document.getElementById('txtadsubcatname').disabled=false;
				document.getElementById('txtalias').disabled=false;
				
				document.getElementById('drpadvcatcode').value=0;
						document.getElementById('txtsubcatcode').value="";
						document.getElementById('txtadsubcatname').value="";
						document.getElementById('txtalias').value="";
				
				return false;



}



function executeadsubcat()
{


		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpadvcatcode').value;
		var subcatcode =document.getElementById('txtsubcatcode').value;
		var subcatname =document.getElementById('txtadsubcatname').value;
		var subcatalias =document.getElementById('txtalias').value;
		var userid=document.getElementById('hiddenuserid').value; 
		adsubcat1.subcatexe(compcode,catcode,subcatcode,subcatname,subcatalias,userid,execall)
		

						document.getElementById('btnNew').disabled=true;
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
						
						
						document.getElementById('drpadvcatcode').disabled=true;
				document.getElementById('txtsubcatcode').disabled=true;
				document.getElementById('txtadsubcatname').disabled=true;
				document.getElementById('txtalias').disabled=true;
						
							
						return false;

}

		function execall(response)
			{
			
			
				ds=response.value;
				
				if(ds=="fail")
				{
				
				alert("Your search Criteria Does Not Exist");
				return false;
				}
				else
				{
				subexe();
				return false;
				}
		
		}
		
		
		
		function subexe()
		{
		var compcode=document.getElementById('hiddencomcode').value;
		var catcode=document.getElementById('drpadvcatcode').value;
		var subcatcode =document.getElementById('txtsubcatcode').value;
		var subcatname =document.getElementById('txtadsubcatname').value;
		var subcatalias =document.getElementById('txtalias').value;
		var userid=document.getElementById('hiddenuserid').value; 
		//alert("hi");
		adsubcat1.exesub(compcode,catcode,subcatcode,subcatname,subcatalias,userid,exerecall)
		//alert("hello");
		return false;
		
		
		}
		
		function exerecall(response)
		{
		ds= response.value;
		
		document.getElementById('drpadvcatcode').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=ds.Tables[0].Rows[0].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=ds.Tables[0].Rows[0].Adv_Subcat_Name;
					document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Subcat_Alias;
		
		}





function firstadsubcat()
{
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			 var catcode=document.getElementById('drpadvcatcode').value;
			adsubcat1.subcatfirst(compcode,catcode,userid,firstcall)
			
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			
			
		return false;

}


function firstcall(response)
{
ds=response.value;

					document.getElementById('drpadvcatcode').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=ds.Tables[0].Rows[0].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=ds.Tables[0].Rows[0].Adv_Subcat_Name;
					document.getElementById('txtalias').value=ds.Tables[0].Rows[0].Adv_Subcat_Alias;


		

return false;
}


function previousadsubcat()
{

			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			 var catcode=document.getElementById('drpadvcatcode').value;
			adsubcat1.subcatpre(compcode,catcode,userid,precall)

return false;

}

function precall(response)
{

z=z-1;
	ds=response.value;
	
	var x=ds.Tables[0].Rows.length;
	
	if (z<0)
	{
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
	return false;		
	}

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
					if(ds.Tables[0].Rows.length != z)
					{
					document.getElementById('drpadvcatcode').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=ds.Tables[0].Rows[z].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=ds.Tables[0].Rows[z].Adv_Subcat_Name;
					document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Adv_Subcat_Alias;
					
					
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					return false;	
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




}



function nextadsubcat()
{
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			 var catcode=document.getElementById('drpadvcatcode').value;
			adsubcat1.subcatnext(compcode,catcode,userid,nextcall)



return false;

}

function nextcall(response)
{
z=z+1;
	ds=response.value;
	
	var x=ds.Tables[0].Rows.length;
	
	if(z <= x)

	{
		if(ds.Tables[0].Rows.length != z)
		
		{
		document.getElementById('drpadvcatcode').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=ds.Tables[0].Rows[z].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=ds.Tables[0].Rows[z].Adv_Subcat_Name;
					document.getElementById('txtalias').value=ds.Tables[0].Rows[z].Adv_Subcat_Alias;
					
					document.getElementById('btnfirst').disabled=false;				
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
					return false;
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

}
function lastadsubcat()
{
			var compcode=document.getElementById('hiddencomcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			 var catcode=document.getElementById('drpadvcatcode').value;
			adsubcat1.subcatlast(compcode,catcode,userid,lastcall)


return false;


}


function lastcall(response)
	{

			ds= response.value;
				var x=ds.Tables[0].Rows.length;
				z=x-1;
				x=x-1;

					document.getElementById('drpadvcatcode').value=ds.Tables[0].Rows[x].Adv_Cat_Code;
					document.getElementById('txtsubcatcode').value=ds.Tables[0].Rows[x].Adv_Subcat_Code;
					document.getElementById('txtadsubcatname').value=ds.Tables[0].Rows[x].Adv_Subcat_Name;
					document.getElementById('txtalias').value=ds.Tables[0].Rows[x].Adv_Subcat_Alias;
					



			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;



	}