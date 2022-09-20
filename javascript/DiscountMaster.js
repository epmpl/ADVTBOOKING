
var flag;
var special;
var z=0;

function combpkg()

{

var comb=document.getElementById('drpcomb').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

DiscountMaster.filpkg(comb,compcode,userid,drop);
document.getElementById('drppkg').disabled=false;

return false;
}

function drop(res)
{
var ds=res.value;


var pkgitem = document.getElementById("drppkg");
//alert(pkgitem);
    pkgitem.options.length = 0; 
    //alert(pkgitem.options.length);
    for (var i = 0; i < res.value.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].package_name,res.value.Tables[0].Rows[i].package_name);
        
       pkgitem.options.length;
       //alert(pkgitem.options[i].value)
       //alert(pkgitem.options[i].text)
        
        
        
        
    }

return false;

}


function disnew()
{
		flag=1;

				chkstatus(FlagStatus);
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnmulti').disabled=false;
				
				document.getElementById('txtdiscode').disabled=false;
				document.getElementById('drpadvtyp').disabled=false;
				document.getElementById('drpadvcat').disabled=false;
				document.getElementById('drpcomb').disabled=false;
				document.getElementById('drppkg').disabled=true;
				document.getElementById('txtdis').disabled=false;
				document.getElementById('drpdistyp').disabled=false;
				document.getElementById('txtfrom').disabled=false;
				document.getElementById('txtto').disabled=false;
				document.getElementById('txtremarks').disabled=false;
				
				document.getElementById('txtdiscode').value="";
				document.getElementById('drpadvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpcomb').value="0";
				document.getElementById('drppkg').value="0";
				document.getElementById('txtdis').value="";
				document.getElementById('drpdistyp').value="0";
				document.getElementById('txtfrom').value="";
				document.getElementById('txtto').value="";
				document.getElementById('txtremarks').value="";
				
				
				
				

		return false;
}

function dissave()
{
		if(document.getElementById('txtdiscode').value=="")
		{
		alert("Please Enter Discount Code");
		document.getElementById('txtdiscode').focus();
		return false;
		}
		else if(document.getElementById('drpadvtyp').value=="0")
		{
		alert("Please Enter Adv Type Name");
		document.getElementById('drpadvtyp').focus();
		return false;
		}
		else if(document.getElementById('drpadvcat').value=="0")
		{
		alert("Please Enter Adv Category Name");
		document.getElementById('drpadvcat').focus();
		return false;
		}
		else if(document.getElementById('drpcomb').value=="0")
		{
		alert("Please Enter Combination/Edition name");
		document.getElementById('drpcomb').focus();
		return false;
		}
		else if(document.getElementById('drppkg').value=="0")
		{
		alert("Please Enter Package name");
		document.getElementById('drppkg').focus();
		return false;
		}
		else if(document.getElementById('drpdistyp').value=="0")
		{
		alert("Please Enter Discount Type name");
		document.getElementById('drpdistyp').focus();
		return false;
		}
		else if(document.getElementById('txtdis').value=="")
		{
		alert("Please Enter Discount value");
		document.getElementById('txtdis').focus();
		return false;
		}
		else if(document.getElementById('txtfrom').value=="")
		{
		alert("Please Enter Valid From Date name");
		document.getElementById('txtfrom').focus();
		return false;
		}


		var discode=document.getElementById('txtdiscode').value;
		var comb=document.getElementById('drpcomb').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var advcode=document.getElementById('drpadvtyp').value;
		var catcode=document.getElementById('drpadvcat').value;
		var pkgname=document.getElementById('drppkg').value;
		var distyp=document.getElementById('drpdistyp').value;
		var dateformat=document.getElementById('hiddendateformat').value;
		var disval=document.getElementById('txtdis').value;
		//var fromdate=document.getElementById('txtfrom').value;
		//var todate=document.getElementById('txtto').value;
		var remarks=document.getElementById('txtremarks').value;
		var dateformat = document.getElementById('hiddendateformat').value;


			
		if(dateformat=="dd/mm/yyyy")
							{
								var txtfrom=document.getElementById('txtfrom').value;
								var txtto=document.getElementById('txtto').value;
								
								var txtfrom1=txt.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto1=txtto.split("/");
								var dd1=txtto1[0];
								var mm1=txtto1[1];
								var yy1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtfrom').value;
								todate=document.getElementById('txtto').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtfrom').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txtto').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtfrom').value;
								todate=document.getElementById('txtto').value;
							}
						
		if(todate != "" || todate != null || todate != "undefined")
		{
			tdate = new Date(todate);
			fdate= new Date(fromdate);
			if(tdate<fdate)
			{
			alert("Till Date Must Be Grater Then From Date");
			return false;
			}

		}

if(flag=="1")
{
DiscountMaster.chksave(discode,compcode,userid ,callchk)

return false;

}

else
{
DiscountMaster.update(discode,comb,compcode,userid,advcode,catcode,pkgname, distyp,disval,fromdate,todate,remarks);
				document.getElementById('txtdiscode').disabled=true;
				document.getElementById('drpadvtyp').disabled=true;
				document.getElementById('drpadvcat').disabled=true;
				document.getElementById('drpcomb').disabled=true;
				document.getElementById('drppkg').disabled=true;
				document.getElementById('txtdis').disabled=true;
				document.getElementById('drpdistyp').disabled=true;
				document.getElementById('txtfrom').disabled=true;
				document.getElementById('txtto').disabled=true;
				document.getElementById('txtremarks').disabled=true;
			alert("Data Modified");	
			updateStatus();
			/*document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						document.getElementById('btnModify').disabled=false;
						document.getElementById('btnDelete').disabled=true;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnfirst').disabled=false;
						document.getElementById('btnmulti').disabled=true;													
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=false;	
						document.getElementById('btnExit').disabled=false;
						document.getElementById('btnDelete').disabled = false;*/
						document.getElementById('btnmulti').disabled=false;

return false;
}



return false;
}

function callchk(response)
{
var ds= response.value;
if (ds.Tables[0].Rows.length == 0)
{
var discode=document.getElementById('txtdiscode').value;
var comb=document.getElementById('drpcomb').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var advcode=document.getElementById('drpadvtyp').value;
var catcode=document.getElementById('drpadvcat').value;
var pkgname=document.getElementById('drppkg').value;
var distyp=document.getElementById('drpdistyp').value;

var disval=document.getElementById('txtdis').value;
//var fromdate=document.getElementById('txtfrom').value;
//var todate=document.getElementById('txtto').value;
var remarks=document.getElementById('txtremarks').value;

var dateformat = document.getElementById('hiddendateformat').value;


			
		if(dateformat=="dd/mm/yyyy")
							{
								var txtfrom=document.getElementById('txtfrom').value;
								var txtto=document.getElementById('txtto').value;
								
								var txtfrom1=txt.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto1=txtto.split("/");
								var dd1=txtto1[0];
								var mm1=txtto1[1];
								var yy1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtfrom').value;
								todate=document.getElementById('txtto').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtfrom').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txtto').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtfrom').value;
								todate=document.getElementById('txtto').value;
							}
						
		if(todate != "" || todate != null || todate != "undefined")
		{
			tdate = new Date(todate);
			fdate= new Date(fromdate);
			if(tdate<fdate)
			{
			alert("Till Date Must Be Grater Then From Date");
			return false;
			}

		}

DiscountMaster.insertdis(discode,comb,compcode,userid,advcode,catcode,pkgname, distyp,disval,fromdate,todate,remarks)

alert("Data Saved");
disCancle('DiscountMaster');
document.getElementById('btnmulti').disabled=true;

				/*document.getElementById('btnNew').disabled=false;
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
				document.getElementById('btnDelete').disabled = true;*/
				

document.getElementById('txtdiscode').disabled=true;
				document.getElementById('drpadvtyp').disabled=true;
				document.getElementById('drpadvcat').disabled=true;
				document.getElementById('drpcomb').disabled=true;
				document.getElementById('drppkg').disabled=true;
				document.getElementById('txtdis').disabled=true;
				document.getElementById('drpdistyp').disabled=true;
				document.getElementById('txtfrom').disabled=true;
				document.getElementById('txtto').disabled=true;
				document.getElementById('txtremarks').disabled=true;
				
				
				
				document.getElementById('txtdiscode').value="";
				document.getElementById('drpadvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpcomb').value="0";
				document.getElementById('drppkg').value="0";
				document.getElementById('txtdis').value="";
				document.getElementById('drpdistyp').value="0";
				document.getElementById('txtfrom').value="";
				document.getElementById('txtto').value="";
				document.getElementById('txtremarks').value="";
				
				
return false;

}

else
{
alert("This Discount Code Already Exist")
}

}


function disexe()
{
var discode=document.getElementById('txtdiscode').value;
var comb=document.getElementById('drpcomb').value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;
var advcode=document.getElementById('drpadvtyp').value;
var catcode=document.getElementById('drpadvcat').value;
var distyp=document.getElementById('drpdistyp').value;
var fromdate=document.getElementById('txtfrom').value;



//var pkgname=document.getElementById('drppkg').value;
//var disval=document.getElementById('txtdis').value;
//var todate=document.getElementById('txtto').value;
//var remarks=document.getElementById('txtremarks').value;

DiscountMaster.exedis(discode,comb,compcode,userid,advcode,catcode,distyp,fromdate,callexe)



			/*document.getElementById('btnNew').disabled=true;
						document.getElementById('btnSave').disabled=true;
						document.getElementById('btnModify').disabled=false;
						document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnExecute').disabled=true;
						document.getElementById('btnCancel').disabled=false;		
						document.getElementById('btnfirst').disabled=false;
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=false;	
						document.getElementById('btnExit').disabled=false;
						document.getElementById('btnDelete').disabled = false;
						*/
						document.getElementById('btnmulti').disabled=false;
						updateStatus();
			
						document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;



return false;
}


function callexe(response)
{
ds=response.value;
var fromdate,todate;
if(ds.Tables[0].Rows.length>0)
{
var pkgitem = document.getElementById("drppkg");

			document.getElementById('txtdiscode').value=ds.Tables[0].Rows[0].Disc_Code;
			document.getElementById('drpcomb').value=ds.Tables[0].Rows[0].Edition_combin_code;
			document.getElementById('drpadvtyp').value=ds.Tables[0].Rows[0].Adv_Type_Code;
			document.getElementById('drpadvcat').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
			//var pkgitem=ds.Tables[0].Rows[0].Package_Name;
			pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[0].Package_Name);
			document.getElementById("drppkg").value=pkgitem.options[0].value;
			//document.getElementById('drppkg').value=pkgitem;
			document.getElementById('drpdistyp').value=ds.Tables[0].Rows[0].Disc_Rate_Type;
			document.getElementById('txtdis').value=ds.Tables[0].Rows[0].Discount;
			//document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].Valid_From_Date;
			//document.getElementById('txtto').value=ds.Tables[0].Rows[0].Valid_Till_Date;
			
			var dateformat = document.getElementById('hiddendateformat').value;
				var txt=ds.Tables[0].Rows[0].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(ds.Tables[0].Rows[0].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=ds.Tables[0].Rows[0].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtfrom').value=fromdate;
				document.getElementById('txtto').value=todate;
			
			document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].Remarks;
			//updatedisable();
			special=1;
			
			
			document.getElementById('txtdiscode').disabled=true;
				document.getElementById('drpadvtyp').disabled=true;
				document.getElementById('drpadvcat').disabled=true;
				document.getElementById('drpcomb').disabled=true;
				document.getElementById('drppkg').disabled=true;
				document.getElementById('txtdis').disabled=true;
				document.getElementById('drpdistyp').disabled=true;
				document.getElementById('txtfrom').disabled=true;
				document.getElementById('txtto').disabled=true;
				document.getElementById('txtremarks').disabled=true;
				



return false;
}
else
{
alert("Your Search Criteria Does Not Produce Any Result");
disCancle('DiscountMaster');
return false;
}
}


function dismodify()
{

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
			document.getElementById('btnQuery').disabled=true;	
				flag=2;
				special=2;
				multiple();
				
				document.getElementById('txtdiscode').disabled=true;
				document.getElementById('drpadvtyp').disabled=false;
				document.getElementById('drpadvcat').disabled=false;
				document.getElementById('drpcomb').disabled=false;
				document.getElementById('drppkg').disabled=true;
				document.getElementById('txtdis').disabled=false;
				document.getElementById('drpdistyp').disabled=false;
				document.getElementById('txtfrom').disabled=false;
				document.getElementById('txtto').disabled=false;
				document.getElementById('txtremarks').disabled=false;
				
return false;
}

function multiple()
		{
		var discode=document.getElementById('txtdiscode').value;
		
		var ab;
		//alert(special);
		if(discode!=null && discode!="")
		{
		for ( var index = 0; index < 200; index++ ) 
           { 
		//window.open('multi_adsize.aspx');
		popup=window.open('multi_discount.aspx?passvalue='+discode+','+special,'xyz','status=0,toolbar=0,resizable=0,top=205,left=573,width=200px,height=130px');
		popup.focus();
		
		return false;
			}
		}
		else
		{
		alert("Please Fill Discount Code");
		return false;
		}
		
		}


function disquery()
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
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled = true;*/
				z=0;
				chkstatus(FlagStatus);

			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
				
				document.getElementById('txtdiscode').disabled=false;
				document.getElementById('drpadvtyp').disabled=false;
				document.getElementById('drpadvcat').disabled=false;
				document.getElementById('drpcomb').disabled=false;
				document.getElementById('drppkg').disabled=true;
				document.getElementById('txtdis').disabled=false;
				document.getElementById('drpdistyp').disabled=false;
				document.getElementById('txtfrom').disabled=false;
				document.getElementById('txtto').disabled=false;
				document.getElementById('txtremarks').disabled=false;
				
				
				document.getElementById('txtdiscode').value="";
				document.getElementById('drpadvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpcomb').value="0";
				document.getElementById('drppkg').value="0";
				document.getElementById('txtdis').value="";
				document.getElementById('drpdistyp').value="0";
				document.getElementById('txtfrom').value="";
				document.getElementById('txtto').value="";
				document.getElementById('txtremarks').value="";
				z=0;

return false;
}		


function updatedisable()
{
alert(special);


	multi_discount.updatedis(special,call_disc)
return false;
}
function call_disc(res)
{
 var ds=res.value;
alert(special);
			if(special=="1")

			{
				document.getElementById('btnupdate').disabled=true;
				return false;
			}
			
			else
			{
				document.getElementById('btnupdate').disabled=false;
				return false;
			}
			
	return false;



}

function disfirst()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

DiscountMaster.fnpl(compcode,userid,firstcall)
multiple();
return false;
}	
		
function dispre()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

DiscountMaster.fnpl(compcode,userid,precall)
multiple();
return false;
}



function precall(response)
	{
	z--;
	ds=response.value;
	
	var x=ds.Tables[0].Rows.length;
	
	

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
					var pkgitem = document.getElementById("drppkg");

			document.getElementById('txtdiscode').value=ds.Tables[0].Rows[z].Disc_Code;
			document.getElementById('drpcomb').value=ds.Tables[0].Rows[z].Edition_combin_code;
			document.getElementById('drpadvtyp').value=ds.Tables[0].Rows[z].Adv_Type_Code;
			document.getElementById('drpadvcat').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
			//var pkgitem=ds.Tables[0].Rows[0].Package_Name;
			pkgitem.options[0] = new Option(ds.Tables[0].Rows[z].Package_Name,ds.Tables[0].Rows[z].Package_Name);
			document.getElementById("drppkg").value=pkgitem.options[0].value;
			//document.getElementById('drppkg').value=pkgitem;
			document.getElementById('drpdistyp').value=ds.Tables[0].Rows[z].Disc_Rate_Type;
			document.getElementById('txtdis').value=ds.Tables[0].Rows[z].Discount;
			//document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].Valid_From_Date;
			//document.getElementById('txtto').value=ds.Tables[0].Rows[0].Valid_Till_Date;
			
			var dateformat = document.getElementById('hiddendateformat').value;
				var txt=ds.Tables[0].Rows[z].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(ds.Tables[0].Rows[z].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=ds.Tables[0].Rows[z].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtfrom').value=fromdate;
				document.getElementById('txtto').value=todate;
			
			document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].Remarks;
			//updatedisable();
			special=1;
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
function firstcall(response)
		{
		
				ds=response.value;
		z=0;
				var pkgitem = document.getElementById("drppkg");

			document.getElementById('txtdiscode').value=ds.Tables[0].Rows[0].Disc_Code;
			document.getElementById('drpcomb').value=ds.Tables[0].Rows[0].Edition_combin_code;
			document.getElementById('drpadvtyp').value=ds.Tables[0].Rows[0].Adv_Type_Code;
			document.getElementById('drpadvcat').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
			//var pkgitem=ds.Tables[0].Rows[0].Package_Name;
			pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[0].Package_Name);
			document.getElementById("drppkg").value=pkgitem.options[0].value;
			//document.getElementById('drppkg').value=pkgitem;
			document.getElementById('drpdistyp').value=ds.Tables[0].Rows[0].Disc_Rate_Type;
			document.getElementById('txtdis').value=ds.Tables[0].Rows[0].Discount;
			//document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].Valid_From_Date;
			//document.getElementById('txtto').value=ds.Tables[0].Rows[0].Valid_Till_Date;
			
			var dateformat = document.getElementById('hiddendateformat').value;
				var txt=ds.Tables[0].Rows[0].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(ds.Tables[0].Rows[0].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=ds.Tables[0].Rows[0].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtfrom').value=fromdate;
				document.getElementById('txtto').value=todate;
			
			document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].Remarks;
			//updatedisable();
			special=1;
			updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;

				
		
		return false;
		}	
		
function disnext()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

DiscountMaster.fnpl(compcode,userid,nextcall)
multiple();
return false;
}	

function nextcall(response)
{
	z++;
	ds=response.value;
	
	var x=ds.Tables[0].Rows.length;
	
	if(z <= x && z >= 0)

	{
		if(ds.Tables[0].Rows.length != z && z !=-1)
		
		{
					var pkgitem = document.getElementById("drppkg");
updateStatus();
			document.getElementById('txtdiscode').value=ds.Tables[0].Rows[z].Disc_Code;
			document.getElementById('drpcomb').value=ds.Tables[0].Rows[z].Edition_combin_code;
			document.getElementById('drpadvtyp').value=ds.Tables[0].Rows[z].Adv_Type_Code;
			document.getElementById('drpadvcat').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
			//var pkgitem=ds.Tables[0].Rows[0].Package_Name;
			pkgitem.options[0] = new Option(ds.Tables[0].Rows[z].Package_Name,ds.Tables[0].Rows[z].Package_Name);
			document.getElementById("drppkg").value=pkgitem.options[0].value;
			//document.getElementById('drppkg').value=pkgitem;
			document.getElementById('drpdistyp').value=ds.Tables[0].Rows[z].Disc_Rate_Type;
			document.getElementById('txtdis').value=ds.Tables[0].Rows[z].Discount;
			//document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].Valid_From_Date;
			//document.getElementById('txtto').value=ds.Tables[0].Rows[0].Valid_Till_Date;
			
			var dateformat = document.getElementById('hiddendateformat').value;
				var txt=ds.Tables[0].Rows[z].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(ds.Tables[0].Rows[z].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=ds.Tables[0].Rows[z].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtfrom').value=fromdate;
				document.getElementById('txtto').value=todate;
			
			document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].Remarks;
			//updatedisable();
			special=1;
						
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

function dislast()
{
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

DiscountMaster.fnpl(compcode,userid,lastcall)
multiple();
return false;
}	




function lastcall(response)
			{
				//alert("hi");
			 ds= response.value;
				var x=ds.Tables[0].Rows.length;
				z=x-1;
				x=x-1;

				var pkgitem = document.getElementById("drppkg");

			document.getElementById('txtdiscode').value=ds.Tables[0].Rows[x].Disc_Code;
			document.getElementById('drpcomb').value=ds.Tables[0].Rows[x].Edition_combin_code;
			document.getElementById('drpadvtyp').value=ds.Tables[0].Rows[x].Adv_Type_Code;
			document.getElementById('drpadvcat').value=ds.Tables[0].Rows[x].Adv_Cat_Code;
			//var pkgitem=ds.Tables[0].Rows[0].Package_Name;
			pkgitem.options[0] = new Option(ds.Tables[0].Rows[x].Package_Name,ds.Tables[0].Rows[x].Package_Name);
			document.getElementById("drppkg").value=pkgitem.options[0].value;
			//document.getElementById('drppkg').value=pkgitem;
			document.getElementById('drpdistyp').value=ds.Tables[0].Rows[x].Disc_Rate_Type;
			document.getElementById('txtdis').value=ds.Tables[0].Rows[x].Discount;
			//document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].Valid_From_Date;
			//document.getElementById('txtto').value=ds.Tables[0].Rows[0].Valid_Till_Date;
			
			var dateformat = document.getElementById('hiddendateformat').value;
				var txt=ds.Tables[0].Rows[x].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(ds.Tables[0].Rows[x].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=ds.Tables[0].Rows[x].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtfrom').value=fromdate;
				document.getElementById('txtto').value=todate;
			
			document.getElementById('txtremarks').value=ds.Tables[0].Rows[x].Remarks;
			//updatedisable();
			special=1;
				updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;




return false;
}

function disCancle(formname)
{
				/*document.getElementById('btnNew').disabled=false;
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
				document.getElementById('btnDelete').disabled = true;*/
				
				getPermission(formname);
				document.getElementById('btnmulti').disabled=true;
				
				document.getElementById('txtdiscode').disabled=true;
				document.getElementById('drpadvtyp').disabled=true;
				document.getElementById('drpadvcat').disabled=true;
				document.getElementById('drpcomb').disabled=true;
				document.getElementById('drppkg').disabled=true;
				document.getElementById('txtdis').disabled=true;
				document.getElementById('drpdistyp').disabled=true;
				document.getElementById('txtfrom').disabled=true;
				document.getElementById('txtto').disabled=true;
				document.getElementById('txtremarks').disabled=true;
				
				
				
				document.getElementById('txtdiscode').value="";
				document.getElementById('drpadvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpcomb').value="0";
				document.getElementById('drppkg').value="0";
				document.getElementById('txtdis').value="";
				document.getElementById('drpdistyp').value="0";
				document.getElementById('txtfrom').value="";
				document.getElementById('txtto').value="";
				document.getElementById('txtremarks').value="";
				

return false;
}


function disdelete()
{
boolReturn = confirm("Are you sure you wish to delete this?");
									

						var discode=document.getElementById('txtdiscode').value;
						var comb=document.getElementById('drpcomb').value;
						var compcode=document.getElementById('hiddencompcode').value;
						var userid=document.getElementById('hiddenuserid').value;
						if(confirm("Are You Sure To Delete The Data"))
						{
						DiscountMaster.del(discode,compcode,userid)
						
						DiscountMaster.fnpl(compcode,userid,calldisdel)
						}
						//alert ("Data Deleted");	
				
				   
				

return false;
}


	function calldisdel(res)
	{
	var ds= res.value;
	len=ds.Tables[0].Rows.length;
	
	
	if(ds.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
		document.getElementById('txtdiscode').value="";
				document.getElementById('drpadvtyp').value="0";
				document.getElementById('drpadvcat').value="0";
				document.getElementById('drpcomb').value="0";
				document.getElementById('drppkg').value="0";
				document.getElementById('txtdis').value="";
				document.getElementById('drpdistyp').value="0";
				document.getElementById('txtfrom').value="";
				document.getElementById('txtto').value="";
				document.getElementById('txtremarks').value="";
		disCancle('DiscountMaster');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
	var pkgitem = document.getElementById("drppkg");
		document.getElementById('txtdiscode').value=ds.Tables[0].Rows[0].Disc_Code;
			document.getElementById('drpcomb').value=ds.Tables[0].Rows[0].Edition_combin_code;
			document.getElementById('drpadvtyp').value=ds.Tables[0].Rows[0].Adv_Type_Code;
			document.getElementById('drpadvcat').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
			//var pkgitem=ds.Tables[0].Rows[0].Package_Name;
			pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[0].Package_Name);
			document.getElementById("drppkg").value=pkgitem.options[0].value;
			//document.getElementById('drppkg').value=pkgitem;
			document.getElementById('drpdistyp').value=ds.Tables[0].Rows[0].Disc_Rate_Type;
			document.getElementById('txtdis').value=ds.Tables[0].Rows[0].Discount;
			//document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].Valid_From_Date;
			//document.getElementById('txtto').value=ds.Tables[0].Rows[0].Valid_Till_Date;
			
			var dateformat = document.getElementById('hiddendateformat').value;
				var txt=ds.Tables[0].Rows[0].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(ds.Tables[0].Rows[0].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=ds.Tables[0].Rows[0].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtfrom').value=fromdate;
				document.getElementById('txtto').value=todate;
			
			document.getElementById('txtremarks').value=ds.Tables[0].Rows[0].Remarks;
	}
	
	else
	{
			var pkgitem = document.getElementById("drppkg");

			document.getElementById('txtdiscode').value=ds.Tables[0].Rows[z].Disc_Code;
			document.getElementById('drpcomb').value=ds.Tables[0].Rows[z].Edition_combin_code;
			document.getElementById('drpadvtyp').value=ds.Tables[0].Rows[z].Adv_Type_Code;
			document.getElementById('drpadvcat').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
			//var pkgitem=ds.Tables[0].Rows[0].Package_Name;
			pkgitem.options[0] = new Option(ds.Tables[0].Rows[z].Package_Name,ds.Tables[0].Rows[z].Package_Name);
			document.getElementById("drppkg").value=pkgitem.options[0].value;
			//document.getElementById('drppkg').value=pkgitem;
			document.getElementById('drpdistyp').value=ds.Tables[0].Rows[z].Disc_Rate_Type;
			document.getElementById('txtdis').value=ds.Tables[0].Rows[z].Discount;
			//document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].Valid_From_Date;
			//document.getElementById('txtto').value=ds.Tables[0].Rows[0].Valid_Till_Date;
			
			var dateformat = document.getElementById('hiddendateformat').value;
				var txt=ds.Tables[0].Rows[z].Valid_From_Date;
					var dd=txt.getDate();
					var mm=txt.getMonth() + 1;
					var yyyy=txt.getFullYear();
					if(ds.Tables[0].Rows[z].Valid_Till_Date==null)
					{
					todate="";
					}
					else
					{
				var txtto=ds.Tables[0].Rows[z].Valid_Till_Date;
					var dd1=txtto.getDate();
					var mm1=txtto.getMonth()+1;
					var yyyy1=txtto.getFullYear();
					if(dateformat=="dd/mm/yyyy")
					{
					todate=dd1+'/'+mm1+'/'+yyyy1;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
					todate=mm1+'/'+dd1+'/'+yyyy1;
					}
					else if(dateformat=="yyyy/mm/dd")
					{
					todate=yyyy1+'/'+mm1+'/'+dd1;
					}
					else if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						todate=dd1+'/'+mm1+'/'+yyyy1;			
					}
					
					}			
				if(dateformat=="dd/mm/yyyy")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
				else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=mm+'/'+dd+'/'+yyyy;
					
				}
				else if(dateformat=="yyyy/mm/dd")
				{
					fromdate=yyyy+'/'+mm+'/'+dd;
					
				}
				else if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					fromdate=dd+'/'+mm+'/'+yyyy;
					
				}
								
				document.getElementById('txtfrom').value=fromdate;
				document.getElementById('txtto').value=todate;
			
			document.getElementById('txtremarks').value=ds.Tables[0].Rows[z].Remarks;
	}
	alert ("Data Deleted");	
				
	
	return false;
	}
	
	
	function disexit()
	{
	if(confirm("Do You Want To Skip This Page"))
		{
	
		if(typeof(popup)!="undefined")
				{
				popup.close();
				}
		window.location.href='enterpage.aspx';
				
		return false;
		}
		return false;	
	}
	