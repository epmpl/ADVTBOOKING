
<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="contact_detail.aspx.cs" Inherits="contact_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
		<title>Agency Master Contact Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <script language="javascript" type="text/javascript" src="javascript/jquery.min.js"></script>
<script language="javascript" type="text/javascript" src="javascript/jquery-ui.min.js"></script>
<script language="javascript" type="text/javascript" src="javascript/jquery-1.5.js"></script>
<script language="javascript" type="text/javascript" src="javascript/jquery-1.7.1.min.js"></script>
		<script  type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/contact.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/saveagent.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript"src="javascript/Validations.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript" language="javascript">
		
	function notchar2(event)
{
//alert(event.keyCode);
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9) || (event.which==0))
        {
        return true;
        }
        else
        {
        return false;
        }
 }
 else
 {
      if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
        {
        return true;
        }
        else
        {
        return false;
        }   
 }       
}
	
	
	
	function delete1(a,b,c,d,e,f,g,code)
		{
		
		
		contact_detail.delete1(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,document.getElementById(d).value,document.getElementById(e).value,document.getElementById(f).value,document.getElementById(g).value,code,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,callbackdelete1);
		return false;
		
		//alert("hi");
		}
		
		function callbackdelete1(response)
		{
		var ds;
		ds=response.value;
		alert( " Record Deleted");
		
		window.location=window.location;
		}
		
		function issueaccelerate(a,b,c,d,e,f,g,code)
		{
		//alert(document.getElementById(a).value);
		//alert(document.getElementById(d).value);
		//alert(document.getElementById(g).value);
		
		if(document.getElementById(a).value=="")
		{
		alert("Please Fill The Contact Person Name");
		
		return false;
		}
		
		
contact_detail.update(document.getElementById(a).value,document.getElementById(b).value,document.getElementById(c).value,document.getElementById(d).value,document.getElementById(e).value,document.getElementById(f).value,document.getElementById(g).value,code,document.getElementById("hiddencomcode").value,document.getElementById("hiddenuserid").value,document.getElementById("hiddenagevcode").value,document.getElementById("hiddenagensubcode").value,callbackdelete);
		return false;
		
		//alert("hi");
		}
		
		function callbackdelete(response)
		{
		var ds;
		ds=response.value;
		alert( " Record Updated");
		window.location=window.location;
		}
		
		
		
		function uppercase()
		{
		
		document.getElementById('txtcontactperson').value=document.getElementById('txtcontactperson').value.toUpperCase();
		return ;
		
		}
		
		function uppercasedesi()
		{
		
		document.getElementById('txtdesignation').value=document.getElementById('txtdesignation').value.toUpperCase();
		return ;
		
		}
		function closeWindow()
		{
		   window.close();
		 
		}
//=====================================Function For Fax & Phone No=======================		
function notchar()
 {
   if((event.keyCode>=48 && event.keyCode<=57)||
	(event.keyCode==8)||
	(event.keyCode==189)||
	(event.keyCode==36)||
	(event.keyCode==35)||
	(event.keyCode==46)||
	(event.keyCode==37)||
	(event.keyCode==39)||
	(event.keyCode==9 || event.keyCode==32))
  {
	return true;
  }
	else
	{
		return false;
	}
}


function charvalue()
 {
   if(
	(event.keyCode==8)||
	(event.keyCode==189)||
	(event.keyCode==36)||
	(event.keyCode==35)||
	(event.keyCode==46)||
	(event.keyCode==37)||
	(event.keyCode==39)||
	(event.keyCode>=96 && event.keyCode<=122)||
	
	(event.keyCode>=65 && event.keyCode<=90)||
	(event.keyCode==9 || event.keyCode==32))
  {
	return true;
  }
	else
	{
		return false;
	}
}

//=====================================Function For EMail-ID=======================		

function checkEmail() 
{
var theurl=document.Form1.TextBox2.value;

if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById('TextBox2').value=="")
{
return (true)
}
alert("Invalid E-mail Address! Please re-enter.")
document.getElementById('TextBox2').focus();
document.getElementById('TextBox2').value="";
//document.getElementById('TextBox2').style;

return (false)

}

function value(str)
{
if(str.keycode > "30" || str.keycode < "39")

{
return true;
}
return false;
}

function abc(str)
{
var a="0123456789()-";
var i=0;
do
{
var pos=0;
for(var j=0;j<a.length;j++)
if(str.charAt(i)==a.charAt(j))
{
pos=1;
break;
}
i++;

}
while(pos==1 && i<str.length)
if(pos ==0)
return false;
return true;
}
//===================================Validation For Text=======================
function xyz()
{

var a="0123456789";
var i=0;
var str=document.getElementById('txtext').value;
do
{
var pos=0;
for(var j=0;j<a.length;j++)
if(str.charAt(i)==a.charAt(j))
{
pos=1;
break;
}
i++;

}
while(pos==1 && i<str.length)
if(pos ==0)
{
alert("Invalid Extension Please Re-Enter");
document.getElementById('txtext').focus();
//document.getElementById('txtext')

return false;
}
return true;
}
//========================== Validation ForFax & Phone No===============================
function xyz1()
{

var a="0123456789";
var i=0;
var str=document.getElementById('txtfaxno').value;
do
{
var pos=0;
for(var j=0;j<a.length;j++)
if(str.charAt(i)==a.charAt(j))
{
pos=1;

break;
}
i++;

}
while(pos==1 && i<str.length)
if(pos ==0)
{
alert("Invalid Fax No. Please Re-Enter");
document.getElementById('txtfaxno').focus();
//document.getElementById('txtfaxno').title
return false;
}
return true;
}
//========================================End========================================
function validateform(form)
{


if(document.getElementById('txtcontactperson').value=="")
{
alert("Contact Person Field Should Not Be Blank");
document.getElementById('txtcontactperson').focus();

return false;
}


else if(document.getElementById('txtdob').value=="")
{
alert("The DOB Should Be In MM/DD/YYYY Format");

return false;
}

/*else if(abc(document.getElementById('txtphoneno').value)=="")
{
alert("please enter the Valid Phone no.");
document.getElementById('txtphoneno').focus();
return(false);
} */ 



//else if(checkEmail(document.getElementById('TextBox2').value)=="")
//{
//alert("please enter yoyur mail");
//document.getElementById('txtmail').focus();
//return(false);
//}
}

function bussinessdate()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==47))
{
return true;
}
else
{
return false;
}
}

function dateenter()
{
if((event.keyCode>=47 && event.keyCode<=57))
{
return true;
}
else
{
return false;
}
}
function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 9))
     {

       return true;
     }
    else
     {
       return false;
     }
 }
 else
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
}




function phoneno(event)
{
//alert(event.keyCode);
var browser=navigator.appName;
if(event.shiftKey==true)
    return false;
 if(browser!="Microsoft Internet Explorer")
 {
 if ((event.which==47) ||(event.which==44))
  {
  	return true;
  }
  
  
  
  else if((event.which==46))
   {
   return false;
   }
   
    
else	if ((event.which>=48 && event.which<=57)||(event.which==9) || (event.which==0) || (event.which==8) ||(event.which==11))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}
else
{
if ((event.keyCode==47) ||(event.keyCode==44))
  {
  	return true;
  }

  else if((event.keyCode==46))
   {
   return false;
   }

  else  if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13)||(event.keyCode==8)||(event.keyCode==11))
	{
		
		return true;
	}
	else
	{
		return false;
	}
}	
}






		</script>
	</head> 
	<body onkeydown="javascript:return tabvalue(event);">
		<form id="Form1" method="post" runat="server">
		
			<table id="Table4" style="Z-INDEX: 100; LEFT: 88px; WIDTH: 632px; POSITION: absolute; TOP: 32px; HEIGHT: 316px"
				borderColor="#000000" cellSpacing="0" cellPadding="0" width="632" border="1">
				
					<tr>
						<td style="width: 636px">
							<table id="Table2" cellSpacing="0" cellPadding="0" width="633" align="center" bgColor="#7daae3"
								border="0">
								<tr>
									<td class="btnlink" align="center">Contact Detail</td>
								</tr>
							</table>
							<table id="Table1" cellSpacing="0" cellPadding="0" width="562" align="center" border="0">
								<tr>
									<td class="style1" align="center">Contract Details</td>
								</tr>
								<tr>
									<td align="center">
										<table id="Table5" cellSpacing="0" cellPadding="0" align="center" border="0" width="520">
											<tr onkeypress="eventcalling(event);">
												<td align="left"><asp:label id="ContactPerson" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left"><asp:textbox id="txtcontactperson" onkeypress="return ClientSpecialchar(event);" runat="server" CssClass="btext1"
														MaxLength="28"></asp:textbox></td>
												<td align="left"><asp:label id="Designation" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left"><asp:textbox id="txtdesignation" onkeypress="return ClientSpecialchar(event);" runat="server" CssClass="btext1"
														MaxLength="28" ></asp:textbox></td>
											</tr>
											<tr>
												<td  align="left"><asp:label id="DateOfBirth" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left"><asp:textbox onkeydown="return datecurr(event);" id="txtdob" onpaste="return false;" runat="server" MaxLength="10" CssClass="startandenddate"></asp:textbox>
													<img src='Images/cal1.gif' id="dan1" onclick='popUpCalendar(this, Form1.txtdob, "mm/dd/yyyy")' onfocus="abc()" height=14 width=14> 
									     
																			
													
												</td>
												<td style="HEIGHT: 13px" align="left">
													<asp:Label id="Role" runat="server" CssClass="NewTextField"></asp:Label></td>
												<td style="HEIGHT: 13px" align="left">
													<asp:DropDownList id="drprole" runat="server" Width="144px" CssClass="dropdown"></asp:DropDownList></td>
											</tr>
											<tr>
												<td align="left"><asp:label id="PhoneNo" runat="server" CssClass="NewTextField"></asp:label></td>
												<td  align="left"><asp:textbox id="txtphoneno" onkeypress="return phoneno(event);" runat="server" CssClass="numerictext" MaxLength="12" onpaste="return false;"
														></asp:textbox></td>
												<td align="left" ><asp:label id="Extension" runat="server" CssClass="NewTextField" Width="72px"></asp:label></td>
												<td  align="left"><asp:textbox id="txtext" onkeypress="return phoneno(event);" onpaste="return false;" runat="server" CssClass="numerictext" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr>
												<td align="left" ><asp:label id="FaxNo" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left"><asp:textbox id="txtfaxno" onkeypress="return phoneno(event);" onpaste="return false;" runat="server" CssClass="numerictext" MaxLength="12"
														></asp:textbox></td>
												<td align="left"><asp:label id="EmailID" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left"><asp:textbox id="TextBox2" runat="server" CssClass="btextmail" MaxLength="200"></asp:textbox></td>
											</tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="product1" runat="server" CssClass="NewTextField"></asp:Label></td>
                                                <td align="left"><asp:button id="add" runat="server" CssClass="button1" Width="75px" ToolTip="To Add different Product for a contact person" OnClick="add_Click" ></asp:button>
                                                </td>
                                                    
                                                    
                                                    
                                               <td align="left"><asp:label id="lblmobile" runat="server" CssClass="NewTextField"></asp:label></td>
												<td  align="left"><asp:textbox id="txtmobile" onkeypress="return phoneno(event);" runat="server" CssClass="numerictext" MaxLength="12" onpaste="return false;"
														></asp:textbox></td>
                                            </tr>
                                            <tr><td></td>
                                            <td>
                                            <td align="left"><asp:Label id="lblempcod" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox id="txtemcode" runat="server" Height="17px" CssClass="btextmail" MaxLength="50"></asp:textbox></td>
										
										
										
										</tr>
										<tr>
										<td></td>
										<td></td>
										<td colspan="2"><asp:ListBox ID="lstempcode" Width="300px" Height="65px" runat="server" CssClass="btextlist" style="display:none;" ></asp:ListBox></td>
										</tr>
                                            
                                            
                                            
                                            </td></tr>
                                            <tr></tr>
                                            <tr>
                                                <td colspan="3" rowspan="3">
                                                
                                                <div id="Div1" style="position:relative; visibility:hidden; overflow:auto;">
                                                <table><tr><td><asp:Label ID="Label3" runat="server" CssClass="NewTextField">Select Client</asp:Label></td></tr>
                                               <tr><td> <asp:ListBox ID="ListBox2" runat="server" CssClass="btext1" Height="66px"></asp:ListBox></td></tr>
                                                </table>
                                                 </div>
                                                <!--<iframe enableviewstate=true src=productag.aspx contenteditable=true style="background-color:AliceBlue" >fghfghfg-->
                                                
                                                
                                                
                                                 
                                                <!--</iframe>-->
                                               
                                                </td>
                                                
                                                
                                            </tr>
                                            <tr>
                                                
                                                
                                            </tr>
                                            <tr>
                                                
                                                
                                            </tr>
											<tr>
												<td style="HEIGHT: 23px" colspan=""></td>
												<td style="HEIGHT: 23px"></td>
												<td style="HEIGHT: 23px"></td>
												<td align="right" style="HEIGHT: 23px">
													<asp:button id="Button1" runat="server" CssClass="button1" OnClick="Button1_Click2" ></asp:button>
													<asp:button id="brnClear" runat="server" CssClass="button1"></asp:button>
													</td>
											</tr>
											<tr>
												<td colspan="2" rowspan="2" class="btextdivitem">
                                                    <div id="showgrid" ></div></td>
												<td></td>
												<td></td>
												<td></td>
											                                          
                                              
                                                
                                                
                                            </tr>
										</table>
										<div id ="Divgrid1" runat="server" style="OVERFLOW: auto;">
										<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="536px" CellPadding="0" AutoGenerateColumns="False"
															AllowSorting="True" >
															<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
															<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="cont_person" SortExpression="cont_person" ReadOnly="True" HeaderText="Contact Person">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="designation" SortExpression="designation" ReadOnly="True" HeaderText="Designation">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="rolename"  HeaderText="Role" SortExpression="rolename"></asp:BoundColumn>
																<asp:BoundColumn DataField="dob" SortExpression="dob" ReadOnly="True" HeaderText="Date Of Birth">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="phone" SortExpression="phone" ReadOnly="True" HeaderText="Phone No.">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="extension" SortExpression="extension" ReadOnly="True" HeaderText="Ext.">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="fax" SortExpression="fax" ReadOnly="True" HeaderText="Fax No.">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="emailid" SortExpression="emailid" ReadOnly="True" HeaderText="Email Id">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="MOBILENO" SortExpression="MOBILENO" ReadOnly="True" HeaderText="Mobile No.">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="cont_code" ReadOnly="True" HeaderText="cont_code">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:TemplateColumn>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:TemplateColumn>
																<asp:TemplateColumn Visible="False" HeaderText="Update">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:TemplateColumn>
																<asp:TemplateColumn Visible="False" HeaderText="Delete"></asp:TemplateColumn>
															</Columns>
														</asp:datagrid>
														</div>
														
														<div id ="Divgrid2" runat="server" style="OVERFLOW: auto;">
										<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="536px" CellPadding="0" AutoGenerateColumns="False"
															AllowSorting="True"  OnItemDataBound="DataGrid2_ItemDataBound">
															<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
															<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
															<Columns>
																<%--<asp:TemplateColumn>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:TemplateColumn>--%>
																<asp:BoundColumn DataField="cont_person" SortExpression="cont_person" ReadOnly="True" HeaderText="Contact Person">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="designation" SortExpression="designation" ReadOnly="True" HeaderText="Designation">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="rolename"  HeaderText="Role" SortExpression="rolename"></asp:BoundColumn>
																<asp:BoundColumn DataField="dob" SortExpression="dob" ReadOnly="True" HeaderText="Date Of Birth">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="phone" SortExpression="phone" ReadOnly="True" HeaderText="Phone No.">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="extension" SortExpression="extension" ReadOnly="True" HeaderText="Ext.">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="fax" SortExpression="fax" ReadOnly="True" HeaderText="Fax No.">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="emailid" SortExpression="emailid" ReadOnly="True" HeaderText="Email Id">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="mobile" SortExpression="mobile" ReadOnly="True" HeaderText="Mobile No.">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="cont_code" ReadOnly="True" HeaderText="contcode">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:TemplateColumn>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:TemplateColumn>
																<asp:TemplateColumn Visible="False" HeaderText="Update">
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:TemplateColumn>
																<asp:TemplateColumn Visible="False" HeaderText="Delete"></asp:TemplateColumn>
															</Columns>
														</asp:datagrid>
														</div>
														
													<table style="WIDTH: 526px; HEIGHT: 158px" align="center">
													<tr align="right">
													<td align="right"><asp:button id="btnclose" runat="server" CssClass="button1"></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" Enabled="False"></asp:button></td>
												</tr>
												<tr>
												<td>
												        <input id="hiddencomcode" type="hidden" size="12" name="hiddencomcode" runat="server"><input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/><input id="hiddenagevcode" type="hidden" name="hiddenagevcode" runat="server"/><input id="hiddenagensubcode" type="hidden" size="1" name="hiddenagensubcode" runat="server"><input id="hiddenccode" type="hidden" size="1" name="hiddenagensubcode" runat="server">
														<input id="hiddenagencycode" type="hidden" size="1" name="hiddenagensubcode" runat="server">
														<input id="hiddenpro" runat="server" type="hidden">
													<input id="hiddendateformat" runat="server" type="hidden">
													<input id="hiddenDupName" runat="server" type="hidden">
                                                <input id="hiddensaurabh" type="hidden" name="hiddenuserid" runat="server"/>
                                               <input id="hdempcode" runat="server" name="hiddendelsau" size="1" type="hidden" />
												
												</td>
												</tr>
											</table>
										
									</td>
								</tr>
							</table>
						</td>
					</tr>
				
			</table>
			<div id="dislaypro" class="btextdiv" style="position:absolute; z-index:101; visibility:hidden;  width:125px; background-image:url(http://localhost/NewAdbooking/images/newdiv.jpg);">
			
			
			</div>
			
			<div id="productbind"  class="btextdiv" style="position:absolute; z-index:101; visibility:hidden;overflow:auto; left:500px; height:66px;  top:185px; ">
                                                     </div>
                                                     
			</form>
		
	</body>
</html> 