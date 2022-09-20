		
		var code10;
		
		function Submit()
		{
		var paid =document.getElementById('txtPaidIns').value;
		var free =document.getElementById('txtFreeIns').value;
		var disno =document.getElementById('txtDisNoOfIns').value;
		var distype =document.getElementById('drpDisType').value;
		var discount =document.getElementById('txtdiscount').value;
		var freins =document.getElementById('txtfreinsedi').value;
		
		var period =document.getElementById('SchConPeriod').value;
		var periodtyp =document.getElementById('ConsPeriodType').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SchemeCode=document.getElementById('hiddenSchemeCode').value;
		var Code=document.getElementById('hiddenccode').value;
		var dateformat=document.getElementById('hiddendateformat').value;
	//	var fromdate =document.getElementById('txtSchValFrom').value;
	//	var todate =document.getElementById('txtSchValTill').value;
	
	
		
		
		var fromdate,todate;
			if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtSchValFrom').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
			else if(dateformat=="mm/dd/yyyy")
				{
					fromdate=document.getElementById('txtSchValFrom').value;
				}
		
	else if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtSchValFrom').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					fromdate=mm+'/'+dd+'/'+yy;
				}
	if(dateformat==null || dateformat=="" || dateformat=="undefined")
					{
						alert("dateformat  is either null or undefined");
						fromdate=document.getElementById('txtSchValFrom').value;
					}


	/*===========================todate===================*/


	if(dateformat=="dd/mm/yyyy")
				{
					var txt=document.getElementById('txtSchValTill').value;
					var txt1=txt.split("/");
					var dd=txt1[0];
					var mm=txt1[1];
					var yy=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
	if(dateformat=="mm/dd/yyyy")
				{
					todate=document.getElementById('txtSchValTill').value;
				}
					
	if(dateformat=="yyyy/mm/dd")
				{
					var txt=document.getElementById('txtSchValTill').value;
					var txt1=txt.split("/");
					var yy=txt1[0];
					var mm=txt1[1];
					var dd=txt1[2];
					todate=mm+'/'+dd+'/'+yy;
				}
	if(dateformat==null || dateformat=="" || dateformat=="undefined")
				{
					alert("dateformat  is either null or undefined");
					todate=document.getElementById('txtSchValTill').value;
				}


				var fdate=new Date(fromdate);
				var tdate=new Date(todate);

		
			if( fdate > tdate)
					{
						alert("To Date Must Be Greater Then From Date");
						return false;
					}
		
	//	alert(Code);
		//alert(SchemeCode);
		
		if( paid=="" )
		{
		alert("Please Enter Paid Ins");
		document.getElementById('txtPaidIns').focus();
		return false;
		}
		
		if( fromdate=="" )
		{
		alert("Please Enter From Date");
		document.getElementById('txtSchValFrom').focus();
		return false;
		}
		
		if(free!= "" && freins=="" )
		{
		alert("Please Enter Free Ins Edition");
		document.getElementById('txtfreinsedi').focus();
		return false;
		}
		
		if(free== "" && freins !="" )
		{
		alert("Please Enter Free Ins");
		document.getElementById('txtFreeIns').focus();
		return false;
		}
		
		if(period!= "" && periodtyp=="0")
		{
		alert("Please Select Period Type from list");
		document.getElementById('ConsPeriodType').focus();
		return false;		
		}
		
		if(period== "" && periodtyp!="0")
		{
		alert("Please Enetr Period  ");
		document.getElementById('SchConPeriod').focus();
		return false;		
		}
			
		if(disno!= "" && distype=="0" )
		{
		alert("Please Select Discount Type From list");
		document.getElementById('drpDisType').focus();
		return false;
		}
		if(disno== "" && distype!="0")
		{
		alert("Please Enter Discount No Of Ins");
		document.getElementById('txtDisNoOfIns').focus();
		return false;
		}
		
		if(discount!= "" && distype=="0" )
		{
		alert("Please Select Discount Type From list");
		document.getElementById('drpDisType').focus();
		return false;
		}
		
		if(discount== "" && distype!="0" )
		{
		alert("Please Enter  Discount ");
		document.getElementById('txtdiscount').focus();
		return false;
		}
		
		if(period!="" && periodtyp=="0")
		{
		alert("Please Enter Cons Period from list");
		document.getElementById('SchConPeriod').focus();
		return false;
		}
		if(period=="" && periodtyp!="0")
		{
		alert("Please Enter Cons Period");
		document.getElementById('SchConPeriod').focus();
		return false;
		}
		
		
		
		
		if(Code=="")
				{
				SchemeDetails.insert(compcode,userid,SchemeCode,paid,free,disno ,distype,discount,freins,fromdate,todate,period,periodtyp);
				window.location=window.location;
				return false;
				}
			else
				{
				SchemeDetails.modify(Code,compcode,userid,SchemeCode,paid,free,disno ,distype,discount,freins,fromdate,todate,period,periodtyp)
				window.location=window.location;
				return false;
				}
				
		return false;
		}
		
		
		function selectsec()
		{
		
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SchemeCode=document.getElementById('hiddenSchemeCode').value;
		
			var datagrid=document.getElementById('DataGrid1')

		var j;
			var k=0;
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;

			for(j=0;j<i;j++)
				{
						var str="DataGrid1__ctl_CheckBox1"+j;
								

						if(document.getElementById(str).checked==true)
						{
							k=k+1;
							code10=document.getElementById(str).value;
						}
				}
		if(k==1)
			{
					document.getElementById('btndelete').disabled=false;
					SchemeDetails.sele(SchemeCode,compcode,userid,code10,callselect);
					return false;
			}
		else
				{
				alert("You Can Select One Row At A Time");
				return false;
				}
		return false;
		}

	function callselect(res)
	{
	ds=res.value;
		var dateformat=document.getElementById('hiddendateformat').value;
		
		if(ds.Tables[0].Rows[0].Valid_Till_Date==null)
		{
		var todate1="";
		}
		else
		{
		var todate=ds.Tables[0].Rows[0].Valid_Till_Date;
		var dd=todate.getDate();
		var mm=todate.getMonth() + 1;
		var yyyy=todate.getFullYear();
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
		var todate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="mm/dd/yyyy")
		{
		var todate1=mm+'/'+dd+'/'+yyyy;
		}
		else if (dateformat=="dd/mm/yyyy")
		{
		var todate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
		var todate1=mm+'/'+dd+'/'+yyyy;
		}
		}
		
		if(ds.Tables[0].Rows[0].Valid_From_Date==null)
		{
		var fromdate1="";
		}
		else
		{
		var fromdate=ds.Tables[0].Rows[0].Valid_From_Date;
		var dd=fromdate.getDate();
		var mm=fromdate.getMonth() + 1;
		var yyyy=fromdate.getFullYear();
		//var enrolldate1=mm+'/'+dd+'/'+yyyy;
		
		if(dateformat=="yyyy/mm/dd")
		{
		var fromdate1=yyyy+'/'+mm+'/'+dd;
		} 
		else if (dateformat=="mm/dd/yyyy")
		{
		var fromdate1=mm+'/'+dd+'/'+yyyy;
		}
		else if (dateformat=="dd/mm/yyyy")
		{
		var fromdate1=dd+'/'+mm+'/'+yyyy;
		}
		else
		{
		var fromdate1=mm+'/'+dd+'/'+yyyy;
		}
		}
		
		if(ds.Tables[0].Rows[0].Paid_Ins==null)
		{
		document.getElementById('txtPaidIns').value=="";
		}
		else
		{
		document.getElementById('txtPaidIns').value=ds.Tables[0].Rows[0].Paid_Ins;
		}
		if(ds.Tables[0].Rows[0].Free_Ins==null)
		{
		document.getElementById('txtFreeIns').value="";
		}
		else
		{
		document.getElementById('txtFreeIns').value=ds.Tables[0].Rows[0].Free_Ins;
		}
		if(ds.Tables[0].Rows[0].Disc_On_Ins==null)
		{}
		else
		{
		document.getElementById('txtDisNoOfIns').value=ds.Tables[0].Rows[0].Disc_On_Ins;
		}
		if(ds.Tables[0].Rows[0].Disc_Type==null || ds.Tables[0].Rows[0].Disc_Type=="")
		{
		document.getElementById('drpDisType').value="0";
		}
		else
		{
		document.getElementById('drpDisType').value=ds.Tables[0].Rows[0].Disc_Type;
		}
		
		if(ds.Tables[0].Rows[0].Discount==null)
		{
		document.getElementById('txtdiscount').value="";
		}
		else
		{
		document.getElementById('txtdiscount').value=ds.Tables[0].Rows[0].Discount;
		}
		
		if(ds.Tables[0].Rows[0].Free_Ins_Edition==null)
		{
		document.getElementById('txtfreinsedi').value=""
		}
		else
		{
		document.getElementById('txtfreinsedi').value=ds.Tables[0].Rows[0].Free_Ins_Edition;
		}
		
		document.getElementById('txtSchValFrom').value=fromdate1;
		
		document.getElementById('txtSchValTill').value=todate1;
		if(ds.Tables[0].Rows[0].Cons_Period==null)
		{
		document.getElementById('SchConPeriod').value=="";
		}
		else
		{
		document.getElementById('SchConPeriod').value=ds.Tables[0].Rows[0].Cons_Period;
		}
		
		if(ds.Tables[0].Rows[0].Cons_Period_Type==null)
		{
		document.getElementById('ConsPeriodType').value=="";
		}
		else
		{
		document.getElementById('ConsPeriodType').value=ds.Tables[0].Rows[0].Cons_Period_Type;
		}
		if(ds.Tables[0].Rows[0].sch_code==null)
		{
		document.getElementById('hiddenccode').value=="";
		}
		else
		{
		document.getElementById('hiddenccode').value=ds.Tables[0].Rows[0].sch_code;
		}
	return false;
	}
	
	function deletesch()
	{
	
	var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SchemeCode=document.getElementById('hiddenSchemeCode').value;
	var code=document.getElementById('hiddenccode').value
	SchemeDetails.dele(SchemeCode,compcode,userid,code)
	window.location=window.location;
	return false;
	}

