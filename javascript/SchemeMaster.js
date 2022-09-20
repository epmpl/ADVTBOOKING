
		var z=0;
var show="0";

	function combpkg()
		{
				var comb=document.getElementById('drpCombName').value;
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				SchemeMaster.filpkg(comb,compcode,userid,drop);
				document.getElementById('drpPackName').disabled=false;
				return false;
		}

	function drop(res)
		{
			var ds=res.value;
			var pkgitem = document.getElementById("drpPackName");
				pkgitem.options.length = 0; 
				for (var i = 0; i < res.value.Tables[0].Rows.length; ++i)
				{
					pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].package_name,res.value.Tables[0].Rows[i].package_name);
				pkgitem.options.length;
				}
			return false;
		}

	function NewClick1()
			{
			show="1";
				document.getElementById('drpAdvType').value="0";
				document.getElementById('drpAdvCat').value="0";
				document.getElementById('txtSchemeCode').value="";
				document.getElementById('drpSchemeType').value="0";
				document.getElementById('drpCombName').value="0";
				document.getElementById('drpPackName').value="0";
				document.getElementById('drpColour').value="0";
				document.getElementById('txtRemarks').value="";

				document.getElementById('drpAdvType').disabled=false;
				document.getElementById('drpAdvCat').disabled=false;
				document.getElementById('txtSchemeCode').disabled=false;
				document.getElementById('drpSchemeType').disabled=false;
				document.getElementById('drpCombName').disabled=false;
				document.getElementById('drpPackName').disabled=false;
				document.getElementById('drpColour').disabled=false;
				document.getElementById('txtRemarks').disabled=false;

				document.getElementById('CheckBox1').checked=false;
				document.getElementById('CheckBox2').checked=false;
				document.getElementById('CheckBox3').checked=false;
				document.getElementById('CheckBox4').checked=false;
				document.getElementById('CheckBox5').checked=false;
				document.getElementById('CheckBox6').checked=false;
				document.getElementById('CheckBox7').checked=false;
				document.getElementById('CheckBox8').checked=false;
				
				document.getElementById('CheckBox1').disabled=false;
				document.getElementById('CheckBox2').disabled=false;
				document.getElementById('CheckBox3').disabled=false;
				document.getElementById('CheckBox4').disabled=false;
				document.getElementById('CheckBox5').disabled=false;
				document.getElementById('CheckBox6').disabled=false;
				document.getElementById('CheckBox7').disabled=false;
				document.getElementById('CheckBox8').disabled=false;

				chkstatus(FlagStatus);
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
				flag=0;
				return false;
			}

		function CancelClick1(formname)
			{
			show="0";
				document.getElementById('drpAdvType').value="0";
				document.getElementById('drpAdvCat').value="0";
				document.getElementById('txtSchemeCode').value="";
				document.getElementById('drpSchemeType').value="0";
				document.getElementById('drpCombName').value="0";
				document.getElementById('drpPackName').value="0";
				document.getElementById('drpColour').value="0";
				document.getElementById('txtRemarks').value="";

				document.getElementById('drpAdvType').disabled=true;
				document.getElementById('drpAdvCat').disabled=true;
				document.getElementById('txtSchemeCode').disabled=true;
				document.getElementById('drpSchemeType').disabled=true;
				document.getElementById('drpCombName').disabled=true;
				document.getElementById('drpPackName').disabled=true;
				document.getElementById('drpColour').disabled=true;
				document.getElementById('txtRemarks').disabled=true;
				
				document.getElementById('CheckBox1').checked=false;
				document.getElementById('CheckBox2').checked=false;
				document.getElementById('CheckBox3').checked=false;
				document.getElementById('CheckBox4').checked=false;
				document.getElementById('CheckBox5').checked=false;
				document.getElementById('CheckBox6').checked=false;
				document.getElementById('CheckBox7').checked=false;
				document.getElementById('CheckBox8').checked=false;
				
				document.getElementById('CheckBox1').disabled=true;
				document.getElementById('CheckBox2').disabled=true;
				document.getElementById('CheckBox3').disabled=true;
				document.getElementById('CheckBox4').disabled=true;
				document.getElementById('CheckBox5').disabled=true;
				document.getElementById('CheckBox6').disabled=true;
				document.getElementById('CheckBox7').disabled=true;
				document.getElementById('CheckBox8').disabled=true;

				getPermission('SchemeMaster');
			return false;
		}


	function ModifyClick1()
		{
				flag=1;
				show="1";
				chkstatus(FlagStatus);
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;

				document.getElementById('drpAdvType').disabled=false;
				document.getElementById('drpAdvCat').disabled=false;
				document.getElementById('txtSchemeCode').disabled=true;
				document.getElementById('drpSchemeType').disabled=false;
				document.getElementById('drpCombName').disabled=false;
				document.getElementById('drpPackName').disabled=false;
				document.getElementById('drpColour').disabled=false;
				document.getElementById('txtRemarks').disabled=false;
				
				document.getElementById('CheckBox1').disabled=false;
				document.getElementById('CheckBox2').disabled=false;
				document.getElementById('CheckBox3').disabled=false;
				document.getElementById('CheckBox4').disabled=false;
				document.getElementById('CheckBox5').disabled=false;
				document.getElementById('CheckBox6').disabled=false;
				document.getElementById('CheckBox7').disabled=false;
				document.getElementById('CheckBox8').disabled=false;
			return false;
		}

		var flag="";


		function SaveClick1()
		{
			
						var compcode=document.getElementById('hiddencompcode').value;
						var userid=document.getElementById('hiddenuserid').value;

							if (document.getElementById('drpAdvType').value==0)
							{
							alert("Please Select Adv Type");
							document.getElementById('drpAdvType').focus();
							return false;
							}
							else
							{
							var AdvType=document.getElementById('drpAdvType').value;
							}

							if (document.getElementById('drpAdvCat').value==0)
							{
							alert("Please Select Adv Category");
							document.getElementById('drpAdvCat').focus();
							return false;
							}
							else
							{
							var AdvCat=document.getElementById('drpAdvCat').value;
							}

							if (document.getElementById('txtSchemeCode').value=="")
							{
							alert("Please Enter Scheme Code");
							document.getElementById('txtSchemeCode').focus();
							return false;
							}
							else
							{
							var SchemeCode=document.getElementById('txtSchemeCode').value;
							}
							if (document.getElementById('drpSchemeType').value==0)
							{
							alert("Please Select Scheme Type");
							document.getElementById('drpSchemeType').focus();
							return false;
							}
							else
							{
							var SchemeType=document.getElementById('drpSchemeType').value;
							}
							if (document.getElementById('drpCombName').value==0)
							{
							alert("Please Select Combination Name");
							document.getElementById('drpCombName').focus();
							return false;
							}
							else
							{
							var CombName=document.getElementById('drpCombName').value;
							}
							if (document.getElementById('drpPackName').value==0)
							{
							alert("Please Select Package Name");
							document.getElementById('drpPackName').focus();
							return false;
							}
							else
							{
							var PackName=document.getElementById('drpPackName').value;
							}
							if (document.getElementById('drpColour').value==0)
							{
							alert("Please Select Color");
							document.getElementById('drpColour').focus();
							return false;
							}
							else
							{
							var Color=document.getElementById('drpColour').value;
							}

							var Remarks=document.getElementById('txtRemarks').value;
							
				if (flag==1)
				{			
				if(document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
					{
					alert("Please Select Publish Day First...");
					return false;
					}
						chkbox(SchemeCode);	
			SchemeMaster.modify(AdvType,AdvCat,SchemeCode,SchemeType,CombName,PackName,Color,Remarks,compcode,userid);

								updateStatus();
								show="0";
								document.getElementById('drpAdvType').disabled=true;
								document.getElementById('drpAdvCat').disabled=true;
								document.getElementById('txtSchemeCode').disabled=true;
								document.getElementById('drpSchemeType').disabled=true;
								document.getElementById('drpCombName').disabled=true;
								document.getElementById('drpPackName').disabled=true;
								document.getElementById('drpColour').disabled=true;
								document.getElementById('txtRemarks').disabled=true;
								disablecheck();
					alert("Update Successfully");
					flag=0;
					return false;
				}
else
				{
				SchemeMaster.chkschemecode(SchemeCode,compcode,userid,callsave);
				return false;
				}
	}
	
	
	function callsave(res)
	{
	var ds=res.value;
	if(ds.Tables[0].Rows.length==0)
	{
		var compcode=document.getElementById('hiddencompcode').value;
					var userid=document.getElementById('hiddenuserid').value;

					if (document.getElementById('drpAdvType').value==0)
					{
					alert("Please Select Adv Type");
					document.getElementById('drpAdvType').focus();
					return false;
					}
					else
					{
					var AdvType=document.getElementById('drpAdvType').value;
					}

					if (document.getElementById('drpAdvCat').value==0)
					{
					alert("Please Select Adv Category");
					document.getElementById('drpAdvCat').focus();
					return false;
					}
					else
					{
					var AdvCat=document.getElementById('drpAdvCat').value;
					}

					if (document.getElementById('txtSchemeCode').value=="")
					{
					alert("Please Enter Scheme Code");
					document.getElementById('txtSchemeCode').focus();
					return false;
					}
					else
					{
					var SchemeCode=document.getElementById('txtSchemeCode').value;
					}
					if (document.getElementById('drpSchemeType').value==0)
					{
					alert("Please Select Scheme Type");
					document.getElementById('drpSchemeType').focus();
					return false;
					}
					else
					{
					var SchemeType=document.getElementById('drpSchemeType').value;
					}
					if (document.getElementById('drpCombName').value==0)
					{
					alert("Please Select Combination Name");
					document.getElementById('drpCombName').focus();
					return false;
					}
					else
					{
					var CombName=document.getElementById('drpCombName').value;
					}
					if (document.getElementById('drpPackName').value==0)
					{
					alert("Please Select Package Name");
					document.getElementById('drpPackName').focus();
					return false;
					}
					else
					{
					var PackName=document.getElementById('drpPackName').value;
					}
					if (document.getElementById('drpColour').value==0)
					{
					alert("Please Select Color");
					document.getElementById('drpColour').focus();
					return false;
					}
					else
					{
					var Color=document.getElementById('drpColour').value;
					}

					var Remarks=document.getElementById('txtRemarks').value;

					if(document.getElementById('CheckBox1').checked!=true && document.getElementById('CheckBox2').checked!=true && document.getElementById('CheckBox3').checked!=true && document.getElementById('CheckBox4').checked!=true && document.getElementById('CheckBox5').checked!=true && document.getElementById('CheckBox6').checked!=true && document.getElementById('CheckBox7').checked!=true && document.getElementById('CheckBox8').checked!=true)
					{
					alert("Please Select Publish Day First...");
					return false;
					}
					chkbox(SchemeCode);
	SchemeMaster.insert(AdvType,AdvCat,SchemeCode,SchemeType,CombName,PackName,Color,Remarks,compcode,userid);
					
					document.getElementById('btnNew').disabled=false;
					document.getElementById('btnSave').disabled=true;
					document.getElementById('btnModify').disabled=true;
					document.getElementById('btnDelete').disabled=true;	
					document.getElementById('btnQuery').disabled=false;
					document.getElementById('btnExecute').disabled=true;
					document.getElementById('btnCancel').disabled=false;
					document.getElementById('btnfirst').disabled=true;
					document.getElementById('btnnext').disabled=true;
					document.getElementById('btnlast').disabled=true;
					
					document.getElementById('drpAdvType').value="0";
				document.getElementById('drpAdvCat').value="0";
				document.getElementById('txtSchemeCode').value="";
				document.getElementById('drpSchemeType').value="0";
				document.getElementById('drpCombName').value="0";
				document.getElementById('drpPackName').value="0";
				document.getElementById('drpColour').value="0";
				document.getElementById('txtRemarks').value="";

					document.getElementById('drpAdvType').disabled=false;
					document.getElementById('drpAdvCat').disabled=false;
					document.getElementById('txtSchemeCode').disabled=false;
					document.getElementById('drpSchemeType').disabled=false;
					document.getElementById('drpCombName').disabled=false;
					document.getElementById('drpPackName').disabled=false;
					document.getElementById('drpColour').disabled=false;
					document.getElementById('txtRemarks').disabled=false;

					document.getElementById('CheckBox1').checked=false;
					document.getElementById('CheckBox2').checked=false;
					document.getElementById('CheckBox3').checked=false;
					document.getElementById('CheckBox4').checked=false;
					document.getElementById('CheckBox5').checked=false;
					document.getElementById('CheckBox6').checked=false;
					document.getElementById('CheckBox7').checked=false;
					document.getElementById('CheckBox8').checked=false;
					
					document.getElementById('CheckBox1').disabled=false;
					document.getElementById('CheckBox2').disabled=false;
					document.getElementById('CheckBox3').disabled=false;
					document.getElementById('CheckBox4').disabled=false;
					document.getElementById('CheckBox5').disabled=false;
					document.getElementById('CheckBox6').disabled=false;
					document.getElementById('CheckBox7').disabled=false;
					document.getElementById('CheckBox8').disabled=false;
					alert("Save Successfully");
					CancelClick1('SchemeMaster');
					
					return false;
	
	}
	else
	{
	alert("This Code Has Already Been Assigned");
	
	return false;	
	}
	CancelClick1('SchemeMaster');
	return false;
	
	
	
	}

		function QueryClick1()
		{
				chkstatus(FlagStatus);
show="0";
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			z=0;
				var AdvType=document.getElementById('drpAdvType').value;
				var AdvCat=document.getElementById('drpAdvCat').value;
				var SchemeCode=document.getElementById('txtSchemeCode').value;
				var SchemeType=document.getElementById('drpSchemeType').value;
				var CombName=document.getElementById('drpCombName').value;
				var PackName=document.getElementById('drpPackName').value;
				var Color=document.getElementById('drpColour').value;
				var Remarks=document.getElementById('txtRemarks').value;
				
				document.getElementById('drpAdvType').value="0";
				document.getElementById('drpAdvCat').value="0";
				document.getElementById('txtSchemeCode').value="";
				document.getElementById('drpSchemeType').value="0";
				document.getElementById('drpCombName').value="0";
				document.getElementById('drpPackName').value="0";
				document.getElementById('drpColour').value="0";
				document.getElementById('txtRemarks').value="";

				document.getElementById('hiddencompcode').disabled=false;
				document.getElementById('hiddenuserid').disabled=false;
				document.getElementById('drpAdvType').disabled=false;
				document.getElementById('drpAdvCat').disabled=false;
				document.getElementById('txtSchemeCode').disabled=false;
				document.getElementById('drpSchemeType').disabled=false;
				document.getElementById('drpCombName').disabled=false;
				document.getElementById('drpPackName').disabled=false;
				document.getElementById('drpColour').disabled=false;
				document.getElementById('txtRemarks').disabled=false;


				return false;
		}

		function ExecuteClick1()
		{

				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var AdvType=document.getElementById('drpAdvType').value;
				var AdvCat=document.getElementById('drpAdvCat').value;
				var SchemeCode=document.getElementById('txtSchemeCode').value;
				var SchemeType=document.getElementById('drpSchemeType').value;
				var CombName=document.getElementById('drpCombName').value;
				var PackName=document.getElementById('drpPackName').value;
				var Color=document.getElementById('drpColour').value;

				SchemeMaster.select(AdvType,AdvCat,SchemeCode,SchemeType,CombName,PackName,Color,compcode,userid,call_Execute)
				updateStatus();
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
				return false;
		}

		function call_Execute(response)

		{
				var ds=response.value;

				if (ds.Tables[0].Rows.length>0)
					{
							var pkgitem = document.getElementById("drpPackName");

							document.getElementById('drpAdvType').value=ds.Tables[0].Rows[0].Adv_Type_Code;
							document.getElementById('drpAdvCat').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
							document.getElementById('txtSchemeCode').value=ds.Tables[0].Rows[0].Scheme_Code;
							document.getElementById('drpSchemeType').value=ds.Tables[0].Rows[0].Scheme_Type_Code;
							document.getElementById('drpCombName').value=ds.Tables[0].Rows[0].Combin_Code;
							pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[0].Package_Name);
							document.getElementById("drpPackName").value=pkgitem.options[0].value;
							document.getElementById('drpColour').value=ds.Tables[0].Rows[0].Col_Code;
							document.getElementById('txtRemarks').value=ds.Tables[0].Rows[0].Remarks;

							var SchemeCode=document.getElementById('txtSchemeCode').value;
							fillcheckboxes(SchemeCode);

							document.getElementById('btnNew').disabled=true;
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
							document.getElementById('btnprevious').disabled=false;
							
							document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;

							document.getElementById('drpAdvType').disabled=true;
							document.getElementById('drpAdvCat').disabled=true;
							document.getElementById('txtSchemeCode').disabled=true;
							document.getElementById('drpSchemeType').disabled=true;
							document.getElementById('drpCombName').disabled=true;
							document.getElementById('drpPackName').disabled=true;
							document.getElementById('drpColour').disabled=true;
							document.getElementById('txtRemarks').disabled=true;

						z=0;
			}
	else
			{
				CancelClick1('SchemeMaster');

				document.getElementById('drpAdvType').disabled=true;
				document.getElementById('drpAdvCat').disabled=true;
				document.getElementById('txtSchemeCode').disabled=true;
				document.getElementById('drpSchemeType').disabled=true;
				document.getElementById('drpCombName').disabled=true;
				document.getElementById('drpPackName').disabled=true;
				document.getElementById('drpColour').disabled=true;
				document.getElementById('txtRemarks').disabled=true;

				alert("Search Not Match");
				return false;
				}
		return false;
}

		function FirstClick1()
		{
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;
				var SchemeCode=document.getElementById('txtSchemeCode').value;
	
		SchemeMaster.Selectfnpl(compcode,SchemeCode,userid,call_First);
		return false;
		}

		function call_First(response)
		{
				z=0;
				var ds=response.value;
				var pkgitem = document.getElementById("drpPackName");

							document.getElementById('drpAdvType').value=ds.Tables[0].Rows[0].Adv_Type_Code;
							document.getElementById('drpAdvCat').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
							document.getElementById('txtSchemeCode').value=ds.Tables[0].Rows[0].Scheme_Code;
							document.getElementById('drpSchemeType').value=ds.Tables[0].Rows[0].Scheme_Type_Code;
							document.getElementById('drpCombName').value=ds.Tables[0].Rows[0].Combin_Code;
							pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[0].Package_Name);
		
							document.getElementById("drpPackName").value=pkgitem.options[0].value;
							document.getElementById('drpColour').value=ds.Tables[0].Rows[0].Col_Code;
							document.getElementById('txtRemarks').value=ds.Tables[0].Rows[0].Remarks;

							var SchemeCode=document.getElementById('txtSchemeCode').value;
							fillcheckboxes(SchemeCode);
							
		updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		return false;
		}


		function NextClick1()
		{
		var SchemeCode=document.getElementById('txtSchemeCode').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;

		SchemeMaster.Selectfnpl(compcode,SchemeCode,userid,call_Next);
		return false;
		}

		function call_Next(response)
		{
var ds=response.value;
var a=ds.Tables[0].Rows.length;

z++;
if(z !=-1 && z >= 0)
	{
	if(z <= a-1)
		{
		var pkgitem = document.getElementById("drpPackName");
							document.getElementById('drpAdvType').value=ds.Tables[0].Rows[z].Adv_Type_Code;
							document.getElementById('drpAdvCat').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
							document.getElementById('txtSchemeCode').value=ds.Tables[0].Rows[z].Scheme_Code;
							document.getElementById('drpSchemeType').value=ds.Tables[0].Rows[z].Scheme_Type_Code;
							document.getElementById('drpCombName').value=ds.Tables[0].Rows[z].Combin_Code;
							pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[z].Package_Name);
							document.getElementById("drpPackName").value=pkgitem.options[0].value;
							document.getElementById('drpColour').value=ds.Tables[0].Rows[z].Col_Code;
							document.getElementById('txtRemarks').value=ds.Tables[0].Rows[z].Remarks;
							
							document.getElementById('drpAdvType').disabled=true;
						document.getElementById('drpAdvCat').disabled=true;
						document.getElementById('txtSchemeCode').disabled=true;
						document.getElementById('drpSchemeType').disabled=true;
						document.getElementById('drpCombName').disabled=true;
						document.getElementById('drpPackName').disabled=true;
						document.getElementById('drpColour').disabled=true;
						document.getElementById('txtRemarks').disabled=true;
updateStatus();
var SchemeCode=document.getElementById('txtSchemeCode').value;
							fillcheckboxes(SchemeCode);
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
		
		}










		function PreviousClick1()
		{

		var AdvType=document.getElementById('drpAdvType').value;
		var AdvCat=document.getElementById('drpAdvCat').value;
		var SchemeCode=document.getElementById('txtSchemeCode').value;
		var SchemeType=document.getElementById('drpSchemeType').value;
		var CombName=document.getElementById('drpCombName').value;
		var PackName=document.getElementById('drpPackName').value;
		var Color=document.getElementById('drpColour').value;
		var Remarks=document.getElementById('txtRemarks').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;

		SchemeMaster.Selectfnpl(compcode,SchemeCode,userid,call_Previous);
		return false;
		}




		function call_Previous(response)
		{
				var ds=response.value;
var a=ds.Tables[0].Rows.length;

z--;
if(z != -1  )
		{
			if(z >= 0 && z < a)
			{
			var pkgitem = document.getElementById("drpPackName");
							document.getElementById('drpAdvType').value=ds.Tables[0].Rows[z].Adv_Type_Code;
							document.getElementById('drpAdvCat').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
							document.getElementById('txtSchemeCode').value=ds.Tables[0].Rows[z].Scheme_Code;
							document.getElementById('drpSchemeType').value=ds.Tables[0].Rows[z].Scheme_Type_Code;
							document.getElementById('drpCombName').value=ds.Tables[0].Rows[z].Combin_Code;
							pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[z].Package_Name);
							document.getElementById("drpPackName").value=pkgitem.options[0].value;
							document.getElementById('drpColour').value=ds.Tables[0].Rows[z].Col_Code;
							document.getElementById('txtRemarks').value=ds.Tables[0].Rows[z].Remarks;
							
							document.getElementById('drpAdvType').disabled=true;
						document.getElementById('drpAdvCat').disabled=true;
						document.getElementById('txtSchemeCode').disabled=true;
						document.getElementById('drpSchemeType').disabled=true;
						document.getElementById('drpCombName').disabled=true;
						document.getElementById('drpPackName').disabled=true;
						document.getElementById('drpColour').disabled=true;
						document.getElementById('txtRemarks').disabled=true;

updateStatus();

var SchemeCode=document.getElementById('txtSchemeCode').value;
							fillcheckboxes(SchemeCode);
							
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

		function LastClick1()
		{

				var AdvType=document.getElementById('drpAdvType').value;
				var AdvCat=document.getElementById('drpAdvCat').value;
				var SchemeCode=document.getElementById('txtSchemeCode').value;
				var SchemeType=document.getElementById('drpSchemeType').value;
				var CombName=document.getElementById('drpCombName').value;
				var PackName=document.getElementById('drpPackName').value;
				var Color=document.getElementById('drpColour').value;
				var Remarks=document.getElementById('txtRemarks').value;
				var compcode=document.getElementById('hiddencompcode').value;
				var userid=document.getElementById('hiddenuserid').value;

				SchemeMaster.Selectfnpl(compcode,SchemeCode,userid,call_Last);
				return false;
		}

		function call_Last(response)
		{
		var ds=response.value;
		var y=ds.Tables[0].Rows.length;
		z=y-1;

		var pkgitem = document.getElementById("drpPackName");

							document.getElementById('drpAdvType').value=ds.Tables[0].Rows[z].Adv_Type_Code;
							document.getElementById('drpAdvCat').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
							document.getElementById('txtSchemeCode').value=ds.Tables[0].Rows[z].Scheme_Code;
							document.getElementById('drpSchemeType').value=ds.Tables[0].Rows[z].Scheme_Type_Code;
							document.getElementById('drpCombName').value=ds.Tables[0].Rows[z].Combin_Code;
							pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[z].Package_Name);
					document.getElementById("drpPackName").value=pkgitem.options[0].value;
							
							//document.getElementById('drpPackName').value=ds.Tables[0].Rows[0].Package_Name;
							document.getElementById('drpColour').value=ds.Tables[0].Rows[z].Col_Code;
							document.getElementById('txtRemarks').value=ds.Tables[0].Rows[z].Remarks;

							var SchemeCode=document.getElementById('txtSchemeCode').value;
							fillcheckboxes(SchemeCode);

				document.getElementById('drpAdvType').disabled=true;
				document.getElementById('drpAdvCat').disabled=true;
				document.getElementById('txtSchemeCode').disabled=true;
				document.getElementById('drpSchemeType').disabled=true;
				document.getElementById('drpCombName').disabled=true;
				document.getElementById('drpPackName').disabled=true;
				document.getElementById('drpColour').disabled=true;
				document.getElementById('txtRemarks').disabled=true;

		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;

		return false;


		}

		


		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		 
		function disablecheck()
		{
		document.getElementById('CheckBox1').disabled=true;
		document.getElementById('CheckBox2').disabled=true;
		document.getElementById('CheckBox3').disabled=true;
		document.getElementById('CheckBox4').disabled=true;
		document.getElementById('CheckBox5').disabled=true;
		document.getElementById('CheckBox6').disabled=true;
		document.getElementById('CheckBox7').disabled=true;
		document.getElementById('CheckBox8').disabled=true;
		getPermission('SchemeMaster');
		return false;

		}


		function chkbox(response)
		{
		var compcode=document.getElementById('hiddencompcode').value;
		var SchemeCode=document.getElementById('txtSchemeCode').value;
		var userid=document.getElementById('hiddenuserid').value;
		SchemeMaster.checkedtioncode1(compcode,SchemeCode,userid,pubcodever);
		return false;

		}


		function pubcodever(response)
		{
		var ds=response.value;
		var chk1;
		var chk2;
		var chk3;
		var chk4;
		var chk5;
		var chk6;
		var chk7;
		var chk8;
		var compcode=document.getElementById('hiddencompcode').value;
		var SchemeCode=document.getElementById('txtSchemeCode').value;
		var userid=document.getElementById('hiddenuserid').value;
		if(document.getElementById('CheckBox1').checked==true)
		{
		chk1="Y";
		}
		else
		{
		chk1="N";
		}
		if(document.getElementById('CheckBox2').checked==true)
		{
		chk2="Y";
		}
		else
		{
		chk2="N";
		}
		if(document.getElementById('CheckBox3').checked==true)
		{
		chk3="Y";
		}
		else
		{
		chk3="N";
		}
		if(document.getElementById('CheckBox4').checked==true)
		{
		chk4="Y";
		}
		else
		{
		chk4="N";
		}
		if(document.getElementById('CheckBox5').checked==true)
		{
		chk5="Y";
		}
		else
		{
		chk5="N";
		}
		if(document.getElementById('CheckBox6').checked==true)
		{
		chk6="Y";
		}
		else
		{
		chk6="N";
		}
		if(document.getElementById('CheckBox7').checked==true)
		{
		chk7="Y";
		}
		else
		{
		chk7="N";
		}
		if(document.getElementById('CheckBox8').checked==true)
		{
		chk8="Y";
		chk1="Y";
		chk2="Y";
		chk3="Y"
		chk4="Y"
		chk5="Y"
		chk6="Y"
		chk7="Y"
		chk8="Y"
		}
		else
		{
		chk8="N";
		}
		if(ds.Tables[0].Rows.length>0)
		{
		SchemeMaster.edtiondaymodify1(compcode,SchemeCode,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,userid);
		return false;
		}
		else
		{
		SchemeMaster.editionpubdaysave1(compcode,SchemeCode,chk1,chk2,chk3,chk4,chk5,chk6,chk7,chk8,userid);
		return false;
		}
		}


		function fillcheckboxes(response)
		{
		var compcode=document.getElementById('hiddencompcode').value;
		var SchemeCode=document.getElementById('txtSchemeCode').value;
		var userid=document.getElementById('hiddenuserid').value;
		SchemeMaster.checkpubcode1(compcode,SchemeCode,userid,fillcheck);
		return false;
		}




		function fillcheck(response)
		{
		var ds=response.value;
		if(ds.Tables[0].Rows.length>0)
		{
		var sun=ds.Tables[0].Rows[0].sun;
		var mon=ds.Tables[0].Rows[0].mon;
		var tue=ds.Tables[0].Rows[0].tue;
		var wed=ds.Tables[0].Rows[0].wed;
		var thu=ds.Tables[0].Rows[0].thu;
		var fri=ds.Tables[0].Rows[0].fri;
		var sat=ds.Tables[0].Rows[0].sat;
		var all=ds.Tables[0].Rows[0].all;

		if(sun=="Y")
		{
		document.getElementById('CheckBox1').checked=true;
		}
		else
		{
		document.getElementById('CheckBox1').checked=false;
		}

		if(mon=="Y")
		{
		document.getElementById('CheckBox2').checked=true;
		}
		else
		{
		document.getElementById('CheckBox2').checked=false;
		}
		if(tue=="Y")
		{
		document.getElementById('CheckBox3').checked=true;
		}
		else
		{
		document.getElementById('CheckBox3').checked=false;
		}
		if(wed=="Y")
		{
		document.getElementById('CheckBox4').checked=true;
		}
		else
		{
		document.getElementById('CheckBox4').checked=false;
		}
		if(thu=="Y")
		{
		document.getElementById('CheckBox5').checked=true;
		}
		else
		{
		document.getElementById('CheckBox5').checked=false;
		}
		if(fri=="Y")
		{
		document.getElementById('CheckBox6').checked=true;
		}
		else
		{
		document.getElementById('CheckBox6').checked=false;
		}
		if(sat=="Y")
		{
		document.getElementById('CheckBox7').checked=true;
		}
		else
		{
		document.getElementById('CheckBox7').checked=false;
		}
		if(all=="Y")
		{
		document.getElementById('CheckBox1').checked=true;
		document.getElementById('CheckBox2').checked=true;
		document.getElementById('CheckBox3').checked=true;
		document.getElementById('CheckBox4').checked=true;
		document.getElementById('CheckBox5').checked=true;
		document.getElementById('CheckBox6').checked=true;
		document.getElementById('CheckBox7').checked=true;
		document.getElementById('CheckBox8').checked=false;
		}
		else
		{
		document.getElementById('CheckBox8').checked=false;
		}
		}
		}


		function exitclick1()
		{
			if(confirm ("Do You Really Want To Exit"))
			{
				if(typeof(popupwin)!="undefined")
				{
				popupwin.close();
				}
				window.location.href='Enterpage.aspx';
				return false;
			}
			return false;
		}
		
		function schemedetailpopup()
		{
			var SchemeCode=document.getElementById('txtSchemeCode').value;
			var ab;
			if(document.getElementById('txtSchemeCode').value!="")
			{
			for ( var index = 0; index < 200; index++ ) 
			{ 
			//popupwin=window.open("SchemeDetails.aspx?SchemeCode="+SchemeCode+"&show="+show,"schemedetails","status=0,toolbar=0,menubar=0 ,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px");
			popupwin=window.open("SchemeDetails.aspx?SchemeCode="+SchemeCode,"schemedetails","status=0,toolbar=0,menubar=0 ,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px");
			popupwin.focus();
			return false;
			}
			}
			
			else
			{
			alert('You must enter Scheme Code ');
			}
			return false;
			}
		
		
		
		
		
		function checkedunchecked(q)
{
	var status = document.getElementById(q).checked;
	if(status==true)
	{
		document.getElementById('CheckBox1').checked=true;
		document.getElementById('CheckBox2').checked=true;
		document.getElementById('CheckBox3').checked=true;
		document.getElementById('CheckBox4').checked=true;
		document.getElementById('CheckBox5').checked=true;
		document.getElementById('CheckBox6').checked=true;
		document.getElementById('CheckBox7').checked=true;
		document.getElementById('CheckBox8').checked=true;
	}
	else
	{
		document.getElementById('CheckBox1').checked=false;
		document.getElementById('CheckBox2').checked=false;
		document.getElementById('CheckBox3').checked=false;
		document.getElementById('CheckBox4').checked=false;
		document.getElementById('CheckBox5').checked=false;
		document.getElementById('CheckBox6').checked=false;
		document.getElementById('CheckBox7').checked=false;
		document.getElementById(q).checked=false;
	}
	}


function deletedoc()
	{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var SchemeCode=document.getElementById('txtSchemeCode').value;
		boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	SchemeMaster.del(compcode,SchemeCode,userid,delcall);
	alert ("Data Deleted");	
	
	}     
	else
	{
	return false;
	}	
	return false;
	}
	
	function delcall(res)
	{
	var ds= res.value;
	len=ds.Tables[0].Rows.length;
	
	if(ds.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
		document.getElementById('drpAdvType').value="0";
				document.getElementById('drpAdvCat').value="0";
				document.getElementById('txtSchemeCode').value="";
				document.getElementById('drpSchemeType').value="0";
				document.getElementById('drpCombName').value="0";
				document.getElementById('drpPackName').value="0";
				document.getElementById('drpColour').value="0";
				document.getElementById('txtRemarks').value="";
		
		
		CancelClick1('SchemeMaster');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
	
	var pkgitem = document.getElementById("drpPackName");
		document.getElementById('drpAdvType').value=ds.Tables[0].Rows[0].Adv_Type_Code;
							document.getElementById('drpAdvCat').value=ds.Tables[0].Rows[0].Adv_Cat_Code;
							document.getElementById('txtSchemeCode').value=ds.Tables[0].Rows[0].Scheme_Code;
							document.getElementById('drpSchemeType').value=ds.Tables[0].Rows[0].Scheme_Type_Code;
							document.getElementById('drpCombName').value=ds.Tables[0].Rows[0].Combin_Code;
							pkgitem.options[0] = new Option(ds.Tables[0].Rows[0].Package_Name,ds.Tables[0].Rows[0].Package_Name);
		
							document.getElementById("drpPackName").value=pkgitem.options[0].value;
							document.getElementById('drpColour').value=ds.Tables[0].Rows[0].Col_Code;
							document.getElementById('txtRemarks').value=ds.Tables[0].Rows[0].Remarks;

							var SchemeCode=document.getElementById('txtSchemeCode').value;
							fillcheckboxes(SchemeCode);
	}
	
	else
	{
		var pkgitem = document.getElementById("drpPackName");
							document.getElementById('drpAdvType').value=ds.Tables[0].Rows[z].Adv_Type_Code;
							document.getElementById('drpAdvCat').value=ds.Tables[0].Rows[z].Adv_Cat_Code;
							document.getElementById('txtSchemeCode').value=ds.Tables[0].Rows[z].Scheme_Code;
							document.getElementById('drpSchemeType').value=ds.Tables[0].Rows[z].Scheme_Type_Code;
							document.getElementById('drpCombName').value=ds.Tables[0].Rows[z].Combin_Code;
							pkgitem.options[0] = new Option(ds.Tables[0].Rows[z].Package_Name,ds.Tables[0].Rows[z].Package_Name);
							document.getElementById("drpPackName").value=pkgitem.options[0].value;
							document.getElementById('drpColour').value=ds.Tables[0].Rows[z].Col_Code;
							document.getElementById('txtRemarks').value=ds.Tables[0].Rows[z].Remarks;
		

							var SchemeCode=document.getElementById('txtSchemeCode').value;
							fillcheckboxes(SchemeCode);
	}
	
				
	
	return false;
	}