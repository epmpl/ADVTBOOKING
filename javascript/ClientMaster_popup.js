 	var code10;
	var code11;
	var client;
	var save;
	var flag1="0";
	
	function submitcontact()
	{
	
	
	var custcode=document.getElementById('hiddencustcode').value;
		if(document.getElementById('txtcontactperson').value=="")
			{
				alert("Contact Person Field Should Not Be Blank");
				document.getElementById('txtcontactperson').focus();
				return false;
			}


	
	    else if(abc(document.getElementById('txtphoneno').value)=="")
	    {
		    alert("please enter the Valid Phone no.");
		    document.getElementById('txtphoneno').focus();
		    return false;
	    }  
	    
	
	
	//======================== check DOB ================================================//
	
	    
//**********************************************<CHECK DUPLICATE NAME>*****************************************
        var hidden=document.getElementById('hiddenDupName');
		  
		   if(hidden.value!="")
		   {
		        var hiddata=hidden.value;
		        var arr=hiddata.split(",");
		    
		        for(var a=0;a<arr.length;a++)
		        {
    		        if(arr[a]==document.getElementById('txtcontactperson').value)
	    	        {
		                alert('This contact name already exists');
		                document.getElementById('txtcontactperson').focus();
		                return false;
		            }
		        }
		   }

//**********************************************</CHECK DUPLICATE NAME>*****************************************
	    
//       client="new"; 
//       save="N_CONT";
// 
//        var xml = new ActiveXObject("Microsoft.XMLHTTP");
//		xml.Open( "GET","chkclient.aspx?client="+client+'&save='+save+'&code='+custcode, false );
//		xml.Send();
//		var ds=xml.responseText;
		
//	if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null)
//			{


				var contactperson=document.getElementById('txtcontactperson').value;
				//var txtdob=document.getElementById('txtdob').value;
				var txtphoneno=document.getElementById('txtphoneno').value;
				var txtext=document.getElementById('txtext').value; 
				var txtfaxno=document.getElementById('txtfaxno').value;
				var mail=document.getElementById('txtemailid').value;
				var custcode=document.getElementById('hiddencustcode').value; 
				var compcode=document.getElementById('hiddencomcode').value; 
				var userid=document.getElementById('hiddenuserid').value; 
				var hiddenccode=document.getElementById('hiddenccode').value; 
				var dateformat=document.getElementById('hiddendateformat').value;
			    var txtmobile=document.getElementById('txtmobile').value;
				var txtdob;
			if(document.getElementById('txtdob').value!="")
            {
              
				if(document.getElementById('txtdob').value!="")
				{
				    if(dateformat=="dd/mm/yyyy")
					{
						var txt=document.getElementById('txtdob').value;
						var txt1=txt.split("/");
						var dd=txt1[0];
						var mm=txt1[1];
						var yy=txt1[2];
						txtdob=mm+'/'+dd+'/'+yy;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
						txtdob=document.getElementById('txtdob').value;
					}
								
					else if(dateformat=="yyyy/mm/dd")
					{
						var txt=document.getElementById('txtdob').value;
						var txt1=txt.split("/");
						var yy=txt1[0];
						var mm=txt1[1];
						var dd=txt1[2];
						txtdob=mm+'/'+dd+'/'+yy;
					}
					if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						txtdob=document.getElementById('txtdob').value;
					}
							
				    var dt=txtdob;
                    var dts=new Date(dt);
                    var dn=new Date();
				    if(dn<=dts)
				    {
				        alert("Date should be less than  current Date.");
				        document.getElementById('txtdob').value="";
				        document.getElementById('txtdob').focus();
				        return false;
    				    
				    }
				}
	      }
	//----------------------------------------------------------------------------------//
				/*if(dateformat=="dd/mm/yyyy")
							{
								var txt=document.getElementById('txtdob').value;
								var txt1=txt.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								txtdob=mm+'/'+dd+'/'+yy;
								
								var currDate=new Date();
                                var userDate=document.getElementById('txtdob').value.split('/'); 
                                if(parseInt(userDate[1])>currDate.getMonth()+1)
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[2])>currDate.getFullYear())
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[0])>=currDate.getDate() && parseInt(userDate[1])==currDate.getMonth()+1 && parseInt(userDate[2])==currDate.getFullYear())
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								var currDate=new Date();
                                var userDate=document.getElementById('txtdob').value.split('/'); 
                                if(parseInt(userDate[0])>currDate.getMonth()+1)
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[2])>currDate.getFullYear())
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[1])>=currDate.getDate() && parseInt(userDate[0])==currDate.getMonth()+1 && parseInt(userDate[2])==currDate.getFullYear())
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtdob').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								txtdob=mm+'/'+dd+'/'+yy;
								
								var currDate=new Date();
                                var userDate=document.getElementById('txtdob').value.split('/'); 
                                if(parseInt(userDate[1])>currDate.getMonth()+1)
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[0])>currDate.getFullYear())
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
                                else if(parseInt(userDate[2])>=currDate.getDate() && parseInt(userDate[1])==currDate.getMonth()+1 && parseInt(userDate[0])==currDate.getFullYear())
                                {
                                    alert("Date of Birth should be less than Current Date");
                                    return false;
                                }
								
							}*/
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								txtdob=document.getElementById('txtdob').value;
							}

	var txtanniversary;
			if(document.getElementById('txtanniversary').value!="")
            {
              
				if(document.getElementById('txtanniversary').value!="")
				{
				    if(dateformat=="dd/mm/yyyy")
					{
						var txt=document.getElementById('txtanniversary').value;
						var txt1=txt.split("/");
						var dd=txt1[0];
						var mm=txt1[1];
						var yy=txt1[2];
						txtanniversary=mm+'/'+dd+'/'+yy;
					}
					else if(dateformat=="mm/dd/yyyy")
					{
						txtanniversary=document.getElementById('txtanniversary').value;
					}
								
					else if(dateformat=="yyyy/mm/dd")
					{
						var txt=document.getElementById('txtanniversary').value;
						var txt1=txt.split("/");
						var yy=txt1[0];
						var mm=txt1[1];
						var dd=txt1[2];
						txtanniversary=mm+'/'+dd+'/'+yy;
					}
					if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						txtanniversary=document.getElementById('txtanniversary').value;
					}
							
				    var dt=txtanniversary;
                    var dts=new Date(dt);
                    var dn=new Date();
				    if(dn<=dts)
				    {
				        alert("Date should be less than  current Date.");
				        document.getElementById('txtanniversary').value="";
				        document.getElementById('txtanniversary').focus();
				        return false;
    				    
				    }
				}
	      }

				if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								txtanniversary=document.getElementById('txtanniversary').value;
							}		

//				clientcontactdetails.submitcontact(contactperson,txtdob,txtphoneno,txtext,txtfaxno,mail,custcode,compcode,userid,hiddenccode);

//				document.getElementById('txtcontactperson').value="";
//				document.getElementById('txtdob').value="";
//				document.getElementById('txtphoneno').value="";
//				document.getElementById('txtext').value=""; 
//				document.getElementById('txtfaxno').value="";
//				document.getElementById('txtemailid').value="";
//				document.getElementById('hiddenccode').value=""; 
                if(document.getElementById('hiddenchk').value=="1")
                {
				//window.location=window.location;
					
				return;
			    }

	    else
		{
//			var contactperson1=document.getElementById('txtcontactperson').value;
//			var txtdob1=document.getElementById('txtdob').value;
//			var txtphoneno1=document.getElementById('txtphoneno').value;
//			var txtext1=document.getElementById('txtext').value; 
//			var txtfaxno1=document.getElementById('txtfaxno').value;
//			var mail1=document.getElementById('txtemailid').value;
//			var custcode1=document.getElementById('hiddencustcode').value; 
//			var compcode1=document.getElementById('hiddencomcode').value; 
//			var userid1=document.getElementById('hiddenuserid').value; 
            
			if(flag1=="1")
			{
            clientcontactdetails.checkcontact(contactperson,custcode,compcode,hiddenccode,callback_chkcont)
            
			}
			else
			{
			hiddenccode="";
			//clientcontactdetails.checkcontact(contactperson,custcode,compcode,hiddenccode,callback_chkcont1)
			clientcontactdetails.checkcontact(contactperson,custcode,compcode,hiddenccode,callback_chkcont)
			}
			//window.location=window.location;

			return false;

		}
			document.getElementById('txtcontactperson').value="";
			document.getElementById('txtdob').value="";
			document.getElementById('txtphoneno').value="";
			document.getElementById('txtext').value=""; 
			document.getElementById('txtfaxno').value="";
			document.getElementById('txtemailid').value="";
            document.getElementById('txtanniversary').value="";
            document.getElementById('txtmobile').value="";

}

function callback_chkcont(resp10001)
{
var ds10001=resp10001.value;
				var contactperson=document.getElementById('txtcontactperson').value;
				//var txtdob=document.getElementById('txtdob').value;
				var txtphoneno=document.getElementById('txtphoneno').value;
				var txtext=document.getElementById('txtext').value; 
				var txtfaxno=document.getElementById('txtfaxno').value;
				var mail=document.getElementById('txtemailid').value;
				var custcode=document.getElementById('hiddencustcode').value; 
				var compcode=document.getElementById('hiddencomcode').value; 
				var userid=document.getElementById('hiddenuserid').value; 
				var hiddenccode=document.getElementById('hiddenccode').value; 
				var dateformat=document.getElementById('hiddendateformat').value;
				var txtmobile=document.getElementById('txtmobile').value;
				var txtdob="";
				if(document.getElementById('txtdob').value!="")
				{
				    if(dateformat=="dd/mm/yyyy")
							{
								var txt=document.getElementById('txtdob').value;
								var txt1=txt.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								txtdob=mm+'/'+dd+'/'+yy;
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								txtdob=document.getElementById('txtdob').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtdob').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								txtdob=mm+'/'+dd+'/'+yy;
							}
						}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								txtdob=document.getElementById('txtdob').value;
							}
							
							
				var txtanniversary="";
				if(document.getElementById('txtanniversary').value!="")
				{
				    if(dateformat=="dd/mm/yyyy")
							{
								var txt=document.getElementById('txtanniversary').value;
								var txt1=txt.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								txtanniversary=mm+'/'+dd+'/'+yy;
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								txtanniversary=document.getElementById('txtanniversary').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtanniversary').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								txtanniversary=mm+'/'+dd+'/'+yy;
							}
						}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								txtanniversary=document.getElementById('txtanniversary').value;
						    }	

if(ds10001.Tables[0].Rows.length>0)
{
alert("Contact already assigned");
return false;
}
else
{
    if(flag1=="1")
	{
        clientcontactdetails.submitcontact(contactperson,txtdob,txtphoneno,txtext,txtfaxno,mail,compcode,userid,custcode,hiddenccode,txtanniversary,txtmobile);
		window.location=window.location;

		return false;
	}
	else
	{
	    clientcontactdetails.insertcontactdtl(contactperson,txtdob,txtphoneno,txtext,txtfaxno,mail,userid,custcode,compcode,txtanniversary,txtmobile);	                                       
	    window.location=window.location;

		return false;
	}
}
}

function callback_chkcont1(resp100001)
{
var ds100001=resp100001.value;
				var contactperson=document.getElementById('txtcontactperson').value;
				//var txtdob=document.getElementById('txtdob').value;
				var txtphoneno=document.getElementById('txtphoneno').value;
				var txtext=document.getElementById('txtext').value; 
				var txtfaxno=document.getElementById('txtfaxno').value;
				var mail=document.getElementById('txtemailid').value;
				var custcode=document.getElementById('hiddencustcode').value; 
				var compcode=document.getElementById('hiddencomcode').value; 
				var userid=document.getElementById('hiddenuserid').value; 
				var hiddenccode=document.getElementById('hiddenccode').value; 
				var dateformat=document.getElementById('hiddendateformat').value;
				var txtmobile=document.getElementById('txtmobile').value;
				var txtdob;
				if(dateformat=="dd/mm/yyyy")
							{
								var txt=document.getElementById('txtdob').value;
								var txt1=txt.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								txtdob=mm+'/'+dd+'/'+yy;
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								txtdob=document.getElementById('txtdob').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtdob').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								txtdob=mm+'/'+dd+'/'+yy;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								txtdob=document.getElementById('txtdob').value;
							}

	var txtanniversary;
				if(dateformat=="dd/mm/yyyy")
							{
								var txt=document.getElementById('txtanniversary').value;
								var txt1=txt.split("/");
								var dd=txt1[0];
								var mm=txt1[1];
								var yy=txt1[2];
								txtanniversary=mm+'/'+dd+'/'+yy;
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								txtanniversary=document.getElementById('txtanniversary').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtanniversary').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								txtanniversary=mm+'/'+dd+'/'+yy;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								txtanniversary=document.getElementById('txtanniversary').value;
							}							
							
if(ds100001.Tables[0].Rows.length>0)
{
alert("Contact already assigned");
return false;
}
else
{
clientcontactdetails.insertcontact(contactperson,txtdob,txtphoneno,txtext,txtfaxno,mail,userid,custcode,compcode,txtanniversary,txtmobile);
			window.location=window.location;

			return false;
}
}

function clearclick()
{

	document.getElementById('txtcontactperson').value="";
			document.getElementById('txtdob').value="";
			document.getElementById('txtphoneno').value="";
			document.getElementById('txtext').value=""; 
			document.getElementById('txtfaxno').value="";
			document.getElementById('txtemailid').value="";
			document.getElementById('txtanniversary').value="";
			document.getElementById('txtmobile').value = "";
			document.getElementById('txtemcode').value = "";
			if (document.getElementById('hiddenchk').value != "1") 
			{
			var j;
			var k=0;
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;

			for(j=0;j<i;j++)
				{
						var str="DataGrid1__ctl_CheckBox1"+j;
						document.getElementById(str).checked=false;
				}
        }
        document.getElementById('btndelete').disabled=true;
        
       //document.getElementById('btnsubmit').disabled=true;
       flag1="0";
       if(document.getElementById('txtcontactperson').disabled==false)
        document.getElementById('txtcontactperson').focus();
       return false;
	}




	function selected(ab)
		{
	        var id=ab;
	        //document.getElementById(ab).checked=true;
			var custcode=document.getElementById('hiddencustcode').value;
			var compcode=document.getElementById('hiddencomcode').value; 
			var userid=document.getElementById('hiddenuserid').value; 
			var datagrid=document.getElementById('DataGrid1')
			 if(document.getElementById(id).checked==false)
             {
            //flag="0";
            clearclick();
            //document.getElementById(ab).checked=false;
            return;// false;
       
            }

			var j;
			var k=0;
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;

			for(j=0;j<i;j++)
				{
						var str="DataGrid1__ctl_CheckBox1"+j;
//						if(id==str)
//                        {
//                        document.getElementById(str).checked=false;
//                        document.getElementById(id).checked=false;
//                        }
//                        else
//                        {
						document.getElementById(str).checked=false;
                        document.getElementById(id).checked=true;	
//                        }
    					if(document.getElementById(str).checked==true)
						{
							k=k+1;
							code10=document.getElementById(str).value;
						}
//						}
				}


		if(k==1)
			{
			if(document.getElementById('hiddenchk').value!="2")
                {
					document.getElementById('btndelete').disabled=false;
					if(document.getElementById('btnsubmit').disabled==true)
				    {
				    flag1="0";
				    }
				    else
				    {
				    flag1="1";
				    }
				}
				else
				{
				    document.getElementById('btndelete').disabled=true;
				    
				}
				//document.getElementById(ab).checked=true;
					clientcontactdetails.bandcontact(custcode,compcode,userid,code10,call_select);
					
					//document.getElementById(ab).checked=true;
					return;
			}
		else
				{
				alert("You Can Select One Row At A Time");
				return;
				}
		return false;
		
				
}





	function call_select(response)
	{

			var ds=response.value;
			document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;
			
			var dateformat=document.getElementById('hiddendateformat').value;
			
			if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
				{
						var enrolldate=ds.Tables[0].Rows[0].dob;
						var dd=enrolldate.getDate();
						if(dd.toString().length==1)
			              dd="0"+dd;
						var mm=enrolldate.getMonth() + 1;
						if(mm.toString().length==1)
			              mm="0"+mm;
						var yyyy=enrolldate.getFullYear();
						//var enrolldate1=mm+'/'+dd+'/'+yyyy;
						
						if(dateformat=="yyyy/mm/dd")
							{
							var enrolldate1=yyyy+'/'+mm+'/'+dd;
							} 
							else if (dateformat=="mm/dd/yyyy")
									{
									var enrolldate1=mm+'/'+dd+'/'+yyyy;
									}
							else if (dateformat=="dd/mm/yyyy")
										{
										var enrolldate1=dd+'/'+mm+'/'+yyyy;
										}
							else
										{
										var enrolldate1=mm+'/'+dd+'/'+yyyy;
										}
						
						
				
				
				}
			else
					{
						document.getElementById('txtdob').value="";
					}
				


if(ds.Tables[0].Rows[0].ANNIVERSARY != null && ds.Tables[0].Rows[0].ANNIVERSARY != "")
				{
						var enrolldate=ds.Tables[0].Rows[0].ANNIVERSARY;
						var dd=enrolldate.getDate();
						if(dd.toString().length==1)
			              dd="0"+dd;
						var mm=enrolldate.getMonth() + 1;
						if(mm.toString().length==1)
			              mm="0"+mm;
						var yyyy=enrolldate.getFullYear();
						//var enrolldate1=mm+'/'+dd+'/'+yyyy;
						
						if(dateformat=="yyyy/mm/dd")
							{
							var enrolldate1=yyyy+'/'+mm+'/'+dd;
							} 
							else if (dateformat=="mm/dd/yyyy")
									{
									var enrolldate1=mm+'/'+dd+'/'+yyyy;
									}
							else if (dateformat=="dd/mm/yyyy")
										{
										var enrolldate1=dd+'/'+mm+'/'+yyyy;
										}
							else
										{
										var enrolldate1=mm+'/'+dd+'/'+yyyy;
										}
						
						
				
				
				}
			else
					{
						document.getElementById('txtanniversary').value="";
					}
	document.getElementById('txtcontactperson').value=ds.Tables[0].Rows[0].cont_person;
	
	if(ds.Tables[0].Rows[0].dob != null && ds.Tables[0].Rows[0].dob != "")
		{
			document.getElementById('txtdob').value=enrolldate1;
		}
	else
	{
	document.getElementById('txtdob').value="";
	}
	if(ds.Tables[0].Rows[0].phone!=null)
	{
	document.getElementById('txtphoneno').value=ds.Tables[0].Rows[0].phone;
	}
	else
	{
	document.getElementById('txtphoneno').value="";
	}
	if(ds.Tables[0].Rows[0].extension!=null)
	{
	document.getElementById('txtext').value=ds.Tables[0].Rows[0].extension; 
	}
	else
	{
		document.getElementById('txtext').value="";
	}
	if(ds.Tables[0].Rows[0].fax!=null)
	{
	document.getElementById('txtfaxno').value=ds.Tables[0].Rows[0].fax;
	}
	else
	{
		document.getElementById('txtfaxno').value="";
	}
	if(ds.Tables[0].Rows[0].emailid!=null)
	{
	document.getElementById('txtemailid').value=ds.Tables[0].Rows[0].emailid;
	}
	else
	{
	document.getElementById('txtemailid').value="";
		}
if(ds.Tables[0].Rows[0].ANNIVERSARY != null && ds.Tables[0].Rows[0].ANNIVERSARY != "")
		{
			document.getElementById('txtanniversary').value=enrolldate1;
		}
	else
	{
	document.getElementById('txtanniversary').value="";
	}
	if(ds.Tables[0].Rows[0].MOBILENO!=null)
	{
	document.getElementById('txtmobile').value=ds.Tables[0].Rows[0].MOBILENO;
	}
	else
	{
	document.getElementById('txtmobile').value="";
	}


	document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].cont_code;

	//document.getElementById('btndelete').disabled= false;

	return false;

	}










	function deletebtn()
	{
	document.getElementById('btndelete').disabled= true;

	//var custcode=document.getElementById('txtcontactperson').value;
	var custcode=document.getElementById('hiddencustcode').value; 
	var compcode=document.getElementById('hiddencomcode').value; 
	var update=document.getElementById('hiddenccode').value; 
	//var datagrid=document.getElementById('DataGrid1')
	//var update=document.getElementById('hiddenccode').value;
	var userid=document.getElementById('hiddenuserid').value;

//boolReturn = confirm("Are you sure you wish to delete this?");
//if(confirm("Are You Sure To Delete The Data"))

    var gridrowlen=document.getElementById('DataGrid1').rows.length-1;
    if(gridrowlen==1)
    {
        alert('One record should be present here');
        return false;
    }
    else
	{		
		clientcontactdetails.deletecontact(custcode,compcode,userid,update);
	}

	document.getElementById('txtcontactperson').value="";
	document.getElementById('txtdob').value="";
	document.getElementById('txtphoneno').value="";
	document.getElementById('txtext').value=""; 
	document.getElementById('txtfaxno').value="";
	document.getElementById('txtemailid').value="";
	document.getElementById('hiddenccode').value=""; 
	document.getElementById('txtanniversary').value="";
	document.getElementById('txtmobile').value="";

//else
//{
//return false;
//}
	window.location=window.location;
		
	return false;



	}


function LTrim( value ) {
	
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

	function uppercase()
			{
			
			
			document.getElementById('txtcontactperson').value=trim(document.getElementById('txtcontactperson').value.toUpperCase());
							
			return false;
			
			
			}
			
			
			
	




/* ================ status client===========*/


























//var status_name_global;
//function call_name_bind(res101)
//{
//var ds=res101.value;
//status_name_global=ds.Tables[0].Rows[0].Status_name;
//}

function ClientStatusSubmit123()

{
var flag;

				//alert("hello");
				var status=document.getElementById('drpstatus').value; 
				var custcode=document.getElementById('hiddencustcode').value; 
				var compcode=document.getElementById('hiddencomcode').value; 
				var userid=document.getElementById('hiddenuserid').value; 
				var dateformat=document.getElementById('hiddendateformat').value;
				var hiddenccode = document.getElementById('hiddenccode').value;
				var circular=document.getElementById('txtcircular').value;
				var attach = document.getElementById('hidattach1').value;
			//	var remark = document.getElementById('txtremark').value;
			var remark="";
				//alert("txtcircular");
				var fromdate,todate;		
       // clientstatusmaster.deduce_status(status,compcode,call_name_bind);
		if(document.getElementById('drpstatus').value=="0")
					{
						alert("Status Field Should Not Be Blank");
						document.getElementById('drpstatus').focus();
						return false;
					}


		else if(document.getElementById('txtfrom').value=="")
					{
						alert("You Must Enter From Date");
						document.getElementById('txtfrom').focus();
						return false;
					}

			else if(document.getElementById('txtto').value=="")
			{
				alert("You Must Enter To Date");
				document.getElementById('txtto').focus();
				return false;
			}  


			if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtfrom').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
			else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=document.getElementById('txtfrom').value;
				}
		
			else if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtfrom').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						fromdate=document.getElementById('txtfrom').value;
					}


	/*===========================todate===================*/


			if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtto').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
			if(dateformat=="mm/dd/yyyy")
				{
					todate=document.getElementById('txtto').value;
				}
					
			if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtto').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					alert("dateformat  is either null or undefined");
					todate=document.getElementById('txtto').value;
				}


				var fdate=new Date(fromdate);
				var tdate=new Date(todate);

		
			if( fdate > tdate)
					{
						alert("To Date Must Be Greater Than From Date");
						document.getElementById('txtto').value="";
						document.getElementById('txtto').focus();
						return false;
					}
	 if(document.getElementById('hiddenchk').value=="1")
                {
				//window.location=window.location;
                var hidfdate=document.getElementById('hiddenfdate').value;
			    var hidtdate=document.getElementById('hiddentdate').value;
			    if(hidfdate!="")
			    {
			        var arrfdate=hidfdate.split(",");
			        var arrtdate=hidtdate.split(",");
			        for(var a=0;a<arrfdate.length;a++)
			        {
			            var fdate=arrfdate[a].split("/");
			            var fday=fdate[1];
			            var fmonth=fdate[0];
			            var fyear=fdate[2];			        
    			        
			            var txtfdatev=document.getElementById('txtfrom').value;
			            var txtfdate=txtfdatev.split("/");
			            var txtfday=txtfdate[1];
			            var txtfmonth=txtfdate[0];
			            var txtfyear=txtfdate[2];
    			        
			            var tdate=arrtdate[a].split("/");
			            var tday=tdate[1];
			            var tmonth=tdate[0];
			            var tyear=tdate[2];			        
    			        
			            var txttdatev=document.getElementById('txtto').value;
			            var txttdate=txttdatev.split("/");
			            var txttday=txttdate[1];
			            var txttmonth=txttdate[0];
			            var txttyear=txttdate[2];
    			        
			            if(((txtfyear>=fyear) && (txtfyear<=tyear)) || ((txttyear>=fyear) && (txttyear<=tyear)))
			            {
			                if(((txtfmonth>=fmonth) && (txtfmonth<=tmonth)) || ((txttmonth>=fmonth) && (txttmonth<=tmonth)))
			                {
			                    if(((txtfday>=fday) && (txtfday<=tday)) || ((txttday>=fday) && (txttday<=tday)))
			                    {
			                        alert("This date is already assigned");
			                        return false;
			                    }
			                }
			            }
			        }
			    }
				return;
			    }
		else
		{
			if(document.getElementById('hiddenccode').value != "" && document.getElementById('hiddenccode').value != null)
		{
			//alert(clientstatusmaster);
			
			
			clientstatusmaster.submitstatus(status,fromdate,todate,custcode,compcode,userid,hiddenccode,dateformat,circular,callhello_update);

			//alert("aaaa");

			
			//return false;
		}

	else
	{
			//alert(clientstatusmaster);
	
	
	clientstatusmaster.insertstatus(status,fromdate,todate,custcode,compcode,userid,dateformat,circular,callbackinsert123);
	
	
	
	//return false;
	}
	//window.location=window.location;
	return false;
		}
		document.getElementById('txtfrom').value="";
			document.getElementById('txtto').value="";
			document.getElementById('drpstatus').value="0";
			document.getElementById('txtcircular').value="";
		return false;
}	

/*=======================================================================*/


			
/***************************************************************/
function callbackinsert123(response)
	{
	
	var flag;
		var ds=response.value;
		if(ds=="true")
			{
			flag="0";
				alert("This Date Has Been Assigned");
				return false;
			}
			else
			{
			flag ="1";
			//alert("in func insert");
			var status=document.getElementById('drpstatus').value; 
				var custcode=document.getElementById('hiddencustcode').value; 
				var compcode=document.getElementById('hiddencomcode').value; 
				var userid=document.getElementById('hiddenuserid').value; 
				var dateformat=document.getElementById('hiddendateformat').value;
				var hiddenccode = document.getElementById('hiddenccode').value;
				var circular=document.getElementById('txtcircular').value;
				var update= document.getElementById('hiddenccode').value;
				var attach = document.getElementById('hidattach1').value;
				var remark = document.getElementById('txtremark').value;
			var remark="";
				var fromdate,todate;
			if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtfrom').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
			else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=document.getElementById('txtfrom').value;
				}
		
			else if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtfrom').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						fromdate=document.getElementById('txtfrom').value;
					}


	/*===========================todate===================*/


	if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtto').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
	if(dateformat=="mm/dd/yyyy")
				{
					todate=document.getElementById('txtto').value;
				}
					
	if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtto').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
	if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					alert("dateformat  is either null or undefined");
					todate=document.getElementById('txtto').value;
				}


				var fdate=new Date(fromdate);
				var tdate=new Date(todate);

		
			if( fdate > tdate)
					{
						alert("To Date Must Be Greater Then From Date");
						return false;
					}
		
	clientstatusmaster.insertstatus11(status,fromdate,todate,custcode,compcode,userid,circular,attach,remark);		
			
				
	if(flag=="1")
	{
	//alert("Data Saved");
	document.getElementById('txtfrom').value="";
	document.getElementById('txtto').value="";
	document.getElementById('drpstatus').value="0";
	document.getElementById('txtcircular').value="";
	
	}
	else
	{
	document.getElementById('txtfrom').value="";
	document.getElementById('txtto').value="";
	document.getElementById('drpstatus').value="0";
	document.getElementById('txtcircular').value="";
	}
			window.location=window.location;
		return false;
		}
}

/*=========================================update status=================*/
function callhello_update(response)
{		
var flag;
		//alert("1")
		//alert("hi");
		
		var da =response.value;
		if(da== "true")
		{
		 flag="0";
			alert("This Date Has Been Assigned");
			return false;
		}
			else
			{
			flag="1";
			
			//alert("in func");
			var status=document.getElementById('drpstatus').value; 
				var custcode=document.getElementById('hiddencustcode').value; 
				var compcode=document.getElementById('hiddencomcode').value; 
				var userid=document.getElementById('hiddenuserid').value; 
				var dateformat=document.getElementById('hiddendateformat').value;
				var hiddenccode = document.getElementById('hiddenccode').value;
				var circular=document.getElementById('txtcircular').value;
				var update= document.getElementById('hiddenccode').value;
				var attach = document.getElementById('hidattach1').value;
			//	var remark = document.getElementById('txtremark').value;
			var remark="";
				var fromdate,todate;
			if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtfrom').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
			else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=document.getElementById('txtfrom').value;
				}
		
	else if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtfrom').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
	if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						fromdate=document.getElementById('txtfrom').value;
					}


	/*===========================todate===================*/


	if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtto').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
	if(dateformat=="mm/dd/yyyy")
				{
					todate=document.getElementById('txtto').value;
				}
					
	if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtto').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
	if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					alert("dateformat  is either null or undefined");
					todate=document.getElementById('txtto').value;
				}


				var fdate=new Date(fromdate);
				var tdate=new Date(todate);

		
			if( fdate > tdate)
					{
						alert("To Date Must Be Greater Then From Date");
						return false;
					}
		
			
			
			clientstatusmaster.submitstatus11(status,fromdate,todate,compcode,userid,custcode,update,circular,attach,remark)
		//alert("Data Modified")
		if(status == "AC0")
		window.opener.document.getElementById('txtstatus1').value="ACTIVE";
		else if(status == "IN0")
		window.opener.document.getElementById('txtstatus1').value="INACTIVE";
		window.location=window.location;
			if (flag=="1")
			{
			//alert("Data Modified");
			document.getElementById('txtfrom').value="";
			document.getElementById('txtto').value="";
			document.getElementById('drpstatus').value="0";
			document.getElementById('txtcircular').value="";
		
			}
			else
			{
			document.getElementById('txtfrom').value="";
			document.getElementById('txtto').value="";
			document.getElementById('drpstatus').value="0";
			document.getElementById('txtcircular').value="";
			}
					
					
		return false;
		}
}


function clearclick11()
{
            document.getElementById('txtfrom').value="";
			document.getElementById('txtto').value="";
			document.getElementById('drpstatus').value="0";
			document.getElementById('txtcircular').value="";
			document.getElementById('hidattach1').value="";
			document.getElementById('attachment1').src = "Images/index.jpeg"
		//	document.getElementById('txtremark').value = "";
			if(document.getElementById('hiddenchk').value!="1")
			{
			var j;
			var k=0;
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;

			for(j=0;j<i;j++)
				{
						var str="DataGrid1__ctl_CheckBox1"+j;
						document.getElementById(str).checked=false;
				}
        }
        document.getElementById('btndelete').disabled=true;
        
       //document.getElementById('btnsubmit').disabled=true;
       //flag="0";
       window.location=window.location;
       return false;
}	


	/*========================select=========================*/

	function ClientSelected(ab)
		{
			var id=ab;
			var custcode=document.getElementById('hiddencustcode').value;
			var compcode=document.getElementById('hiddencomcode').value;
			var userid = document.getElementById('hiddenuserid').value;
		//	var remark = document.getElementById('txtremark').value; 
			var remark="";
			var datagrid=document.getElementById('DataGrid1')
			var dateformat=document.getElementById('hiddendateformat').value;
			var j;
			var k=0;
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;
            if( document.getElementById(id).checked==false)
            {
            clearclick11();
            return;
            }
			for(j=0;j<i;j++)
				{
						var str="DataGrid1__ctl_CheckBox1"+j;
						document.getElementById(str).checked=false;
                        document.getElementById(id).checked=true;		

						if(document.getElementById(str).checked==true)
						{
							k=k+1;
							code11=document.getElementById(str).value;
						}
				}
		if(k==1)
			{
			if(document.getElementById('hiddenchk').value!="2")
                {
					document.getElementById('btndelete').disabled=false;
					}
					else
					{
					    document.getElementById('btndelete').disabled=true;
					}
					clientstatusmaster.bandstatus(custcode,compcode,userid,code11,dateformat,call_selectstatus);
			
			//clientstatusmaster.bandstatus(custcode,compcode,userid,code11,dateformat,call_hey);
			return;
			
			}
			else
			{
			alert("You Can Select One Row At A Time");
			return false;
			}
			return false;
			
					
	}





	function call_selectstatus(response)
	{

			var ds=response.value;



			document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].stat_code;
				document.getElementById('drpstatus').value=ds.Tables[0].Rows[0].cust_status;
				
				
				
				document.getElementById('txtfrom').value=ds.Tables[0].Rows[0].From_date;
				document.getElementById('txtto').value=ds.Tables[0].Rows[0].to_date;
				if(ds.Tables[0].Rows[0].circular!=null)
				{
				document.getElementById('txtcircular').value=ds.Tables[0].Rows[0].circular;
				}
				else
				{
					document.getElementById('txtcircular').value="";
				}
				if(ds.Tables[0].Rows[0].ATTACHMENT!=null)
				{
				document.getElementById('hidattach1').value=ds.Tables[0].Rows[0].ATTACHMENT;
				document.getElementById('attachment1').src="Images/indexred.jpg";
				
				}
				else
				{
					document.getElementById('hidattach1').value="";
					document.getElementById('attachment1').src="Images/index.jpeg"
				}


				if (ds.Tables[0].Rows[0].REMARK != null) {
				 //   document.getElementById('txtremark').value = ds.Tables[0].Rows[0].REMARK;
				}
				else {
				  //  document.getElementById('txtremark').value = "";
				}

			//document.getElementById('btnDelete').disabled= false;

			return false;

	}
	
	function Uppercase()
		{
		
		document.getElementById('txtcontactperson').value=document.getElementById('txtcontactperson').value.toUpperCase();
		return ;
		
		}
		














	/*====================delete================*/




	function ClientDelete()
	{
				

				var custcode=document.getElementById('hiddencustcode').value; 
				var compcode=document.getElementById('hiddencomcode').value; 
				var delete1=document.getElementById('hiddenccode').value;   
				var userid=document.getElementById('hiddenuserid').value;
//boolReturn = confirm("Are you sure you wish to delete this?");
//if(confirm("Are You Sure To Delete This Data"))
			//{
			        document.getElementById('btndelete').disabled= true;
			        var gridrowlen=document.getElementById('DataGrid1').rows.length-1;
	                if(gridrowlen==1)
	                {
	                    alert('One record should be present here');
	                    return false;
	                }
	                else
	                {
					    clientstatusmaster.deletestatus(custcode,compcode,userid,delete1);
					}
			//}
			//else
			//{
			//return false;
			//}
				document.getElementById('drpstatus').value="";
				document.getElementById('txtfrom').value="";
				document.getElementById('txtto').value="";
				document.getElementById('hiddenccode').value=""; 

			window.location=window.location;
				
			return false;

	}

//************************************Manish*******************************************************

function tabvalue (id)
{
    if(event.keyCode==13)
    {
        if(document.activeElement.id==id)
        {
            if(document.getElementById('btnsubmit').disabled==false)
            {
                document.getElementById('btnsubmit').focus();
            }
            return;

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
//****************************************************************************************************


function Checkdate(input)
{
	var dateformat=document.getElementById('hiddendateformat').value;
	
    if(dateformat=="mm/dd/yyyy")
	{ 
		 var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	   
	}
	if(dateformat=="yyyy/mm/dd")
	 
	{
		var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
	}
	if(dateformat=="dd/mm/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	}

	if (!validformat.test(input.value))
	{
		if(input.value=="")
		{
		return true;
		}
		alert(" Please fill the date in "+dateformat+" format");
		document.getElementById(input.id).value="";
		document.getElementById(input.id).focus();
		return false;
	}
}
function pholeminlength(id)
{
if(document.getElementById(id).value.length < 4)
    {
    alert("Min length can't be less than 4 digit");
    document.getElementById(id).value="";
    document.getElementById(id).focus();
    return false;
    }
}


function clientdate()
{
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
    {

        return true;
    }
    else
    {
        return false;
    }
}


function closewindow()
{
    window.close();
}

function openattach3()
{
//if(document.getElementById('LinkButton1').disabled==false)
    window.open('agencyattachment.aspx?filename='+document.getElementById('hidattach1').value,'Ankur2', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=350px,height=300px');
     return false;
}

function checkEmail() 
{ 
if(document.getElementById('txtemailid').value!="")
{
    var String = document.getElementById('txtemailid').value.split(",")
    var flag=0;
    for(var i=0;i<String.length;i++)
    {
        var theurl=String[i];
        //var theurl=document.getElementById('txtemail').value;

	  //  if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl))
	  if (theurl.indexOf("@") != "-1" && theurl.indexOf(".") != "-1" )
	    {
		    flag=0;
	    }
	    else{
	        flag=1;
	        i=String.length;
	    }
    }
	if(flag==1){
	alert("Invalid E-mail Address! Please re-enter.")
	document.getElementById('txtemailid').value="";
	//alert("mail");
	document.getElementById('txtemailid').focus();
	return false;
	}
	else{
	    return true;
	}
}	
else{
    return true;
}
}



function dateenter(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))

    if ((key >= 46 && key <= 57) || (key == 111) || (key == 127) || (key == 191) || (key == 8) || (key == 9) || (key == 13) || (key >= 96 && key <= 105))

    //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
    //if((event.keyCode>=46 && event.keyCode<=57) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13)|| (event.keyCode>=96 && event.keyCode<=105))
    {
        return true;
    }
    else {
        return false;
    }
}