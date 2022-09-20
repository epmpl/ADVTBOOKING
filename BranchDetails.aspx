<%@ Page language="C#" CodeFile="BranchDetails.aspx.cs" EnableEventValidation="false"  AutoEventWireup="true" Inherits="BranchDetails" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN" >
<html  xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Display Ad. Booking & Scheduling Branch Master Contact Details</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientscript" content="Javascript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/BranchMaster.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	    <script type="text/javascript"  language="javascript" src="javascript/Validations.js"></script>
	    <script type="text/javascript"language="javascript">
function alpha1(event)
    {
            var browser=navigator.appName;

              if(browser!="Microsoft Internet Explorer")
                { 
               // alert(event.which);
                 if((event.which>=65 && event.which<=90)||(event.which>=97 && event.which<=122)||(event.which==32)||(event.which==8)||(event.which==0))
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
                if((event.keyCode>=65 && event.keyCode<=90) ||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==32)||(event.which==0))
                    {
                    return true;
                    }

                else
                    {
                    //alert("Please Enter only Alphabet Values");
                    return false;
                    }
               }
}

		
		function clientdate(event)
		{
		 var browser=navigator.appName;

              if(browser!="Microsoft Internet Explorer")
                { 
                  if ((event.which>=48 && event.which<=57)||(event.which==47)||(event.which==11)||(event.which==8)||(event.which==0))
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
                 //alert(event.keyCode);
		             if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11)||(event.which==0))
	                {
                		
		                return true;
	                }
	                else
	                {
		                return false;
	                }
	   }
 }
		
		
function phone(event)
{
var browser=navigator.appName;

              if(browser!="Microsoft Internet Explorer")
                { 
                    if((event.which>=48 && event.which<=57)||(event.which==32) ||(event.which==8)||(event.which==0))
                    {
                        return true;
                        }
                    else
                        {
                        //alert("Please enter only numeric values");
                        return false;
                        }
                }
             else
             {
                if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==32)||(event.which==0))
                {
                    return true;
                    }
                else
                    {
                    //alert("Please enter only numeric values");
                    return false;
                    }
                }
}

	
		</script>
	</head>
	<body  onload="loadXML('xml/errorMessage.xml');"    onkeydown="javascript:return tabvalue(event);" ><%--onkeypress="eventcalling(event);">--%>
	<form id="Form1" method="post" runat="server">
			<table id="Table7" style="Z-INDEX: 101; LEFT: 24px; WIDTH: 639px; POSITION: absolute; TOP: 16px; HEIGHT: 432px"
				borderColor="#000000" cellspacing="0" cellpadding="0" width="639" border="1" ms_2d_layout="TRUE">
				<tr>
					<td valign="top">
						<table id="Table8" style="WIDTH: 633px; HEIGHT: 15px" cellspacing="0" cellpadding="0" width="633"
							align="center"  bgColor="#7daae3" border="0" >
							<tr valign="top">
								<td class="btnlink" align="center" >Contact Details</td>
							</tr>
						</table>
						<table id="Table9"  cellspacing="0" cellpadding="0"
							width="562" align="center" border="0">
							<tr>
								<td align="center">
									<table id="Table10" WIDTH="585px" cellspacing="0" cellpadding="0"
										align="center" border="0">
										<tr>
										<td colspan="4" ></td>
										</tr>
										<tr>
											<td align="left" ><asp:Label id="ContactPerson" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left" ><asp:textbox onkeypress="return alpha1(event)" Height="15px" id="txtcontactperson" runat="server" CssClass="btext1"
													MaxLength="30"></asp:textbox></td>
											<td align="left" ><asp:Label id="Designation" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left" ><asp:textbox onkeypress="return alpha1(event)" Height="15px" id="txtdesignation" runat="server" CssClass="btext1" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td align="left"><asp:Label id="DateOfBirth" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox onkeypress="return clientdate(event);" id="txtdob" runat="server" Height="15px" CssClass="btext1" MaxLength="10"></asp:textbox>
												<%--<img src='Images/cal1.gif' id="div123"  onclick='popUpCalendar(this, form1.txtdob, "mm/dd/yyyy")' onfocus=abc();  height=14 width=14> 
									--%>
												<script type="text/javascript"language="javascript">
																		
			                           if (!document.layers) 
									     {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtdob, \"mm/dd/yyyy\")' onfocus=abc();  height=14 width=14> ")
									     }
																			
												</script>
											</td>
											<td align="left" >
												<asp:Label id="PhoneNo" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left">
												<asp:textbox onkeypress="return phone(event)" onpaste="return false;" Height="15px" id="txtphoneno" runat="server" CssClass="numerictext"
													MaxLength="15"></asp:textbox></td>
										</tr>
										<tr>
											<td align="left" style="height: 18px" ><asp:Label id="Extension"  runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left" style="height: 18px" ><asp:textbox id="txtext" onkeypress="return phone(event);" onpaste="return false;" Height="15px" runat="server" CssClass="numerictext" MaxLength="13"></asp:textbox></td>
											<td align="left" style="height: 18px" ><asp:Label id="Fax" runat="server" CssClass="TextField" ></asp:Label></td>
											<td align="left" style="height: 18px" ><asp:textbox onkeypress="return phone(event)" onpaste="return false;" Height="15px" id="txtfaxno" runat="server" CssClass="numerictext" MaxLength="10"></asp:textbox></td>
										</tr>
										<tr>
											<td align="left"><asp:Label id="EmailID" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox id="txtemail" runat="server" Height="17px" CssClass="btextmail" MaxLength="50"></asp:textbox></td>
											<td align="left"><asp:Label id="lblempcod" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox id="txtemcode" runat="server" Height="17px" CssClass="btextmail" MaxLength="50"></asp:textbox></td>
											
										<tr id="tr1" runat ="server"></tr>
										</tr>
										<tr>
										<td></td>
										<td></td>
										<td colspan="2"><asp:ListBox ID="lstempcode" Width="300px" Height="65px" runat="server" CssClass="btextlist" style="display:none;" ></asp:ListBox></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td colspan="1" align="right">
											<asp:button id="Button1" runat="server" CssClass="button1" Width="56px" OnClick="Button1_Click1" ></asp:button><asp:button id="btnClear" runat="server" CssClass="button1"></asp:button>
												
												</td>
									
										
                                               
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td></td>
										</tr>
									</table>
		
									
									<div style="OVERFLOW: auto; WIDTH: 587px; HEIGHT: 176px">
								
										<table id="table3" style="WIDTH: 526px; HEIGHT: 158px" align="center">
											<tr align="left">
												<td align="left">
											      <div id="divdg1" runat="server">
													<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="520px" cellpadding="0" AutoGenerateColumns="False"
														AllowSorting="true" OnSortCommand="abc" OnItemDataBound="DataGrid1_ItemDataBound1">
														<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
														<headerStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></headerStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="cont_person" SortExpression="cont_person" ReadOnly="true" headerText="Contact Person">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="designation" SortExpression="designation" ReadOnly="true" headerText="Designation">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="dob" SortExpression="dob" ReadOnly="true" headerText="Date Of Birth">
																<headerStyle HorizontalAlign="Center"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="phone" SortExpression="phone" ReadOnly="true" headerText="Phone No">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="extension" SortExpression="extension" ReadOnly="true" headerText="Ext.">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="fax" SortExpression="fax" ReadOnly="true" headerText="Fax No">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="emailid" SortExpression="emailid" ReadOnly="true" headerText="Email Id">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="cont_code" ReadOnly="true" headerText="contcode">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" headerText="Update">
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" headerText="Delete"></asp:TemplateColumn>
														</Columns>
													</asp:datagrid></DIV>
													
													
										                <div id="divdg2" runat="server">
														<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="520px" cellpadding="0" AutoGenerateColumns="False"
														AllowSorting="true">
														<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
														<headerStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></headerStyle>
														<Columns>
																	<asp:BoundColumn DataField="cont_person" SortExpression="cont_person" ReadOnly="true" headerText="Contact Person">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="designation" SortExpression="designation" ReadOnly="true" headerText="Designation/Role">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="dob" SortExpression="dob" ReadOnly="true" headerText="Date Of Birth">
																<headerStyle HorizontalAlign="Center"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="phone" SortExpression="phone" ReadOnly="true" headerText="Phone No">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="extension" SortExpression="extension" ReadOnly="true" headerText="Ext">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="fax" SortExpression="fax" ReadOnly="true" headerText="Fax No">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="emailid" SortExpression="emailid" ReadOnly="true" headerText="Email Id">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="cont_code" ReadOnly="true" headerText="contcode">
																<headerStyle HorizontalAlign="Center" VerticalAlign="Middle"></headerStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" headerText="Update">
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" headerText="Delete"></asp:TemplateColumn>
														</Columns>
													</asp:datagrid>
													</div>
													</td>
													</tr>
													</table>
													</div>
													<input id="hiddencomcode" type="hidden" size="5" name="hiddencomcode" runat="server"/>
													<input id="hiddenuserid" type="hidden" size="5" name="hiddenuserid" runat="server"/>
													<input type="hidden" name="hiddenagevcode" size="5" runat="server"/>
													<input type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddenccode" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddenbranchcode" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
													<input id="hiddenshow"  type="hidden" size="9" name="hiddenshow" runat="server"/>
													<input id="hiddendelsau"  type="hidden" size="9" name="hiddenshow" runat="server"/>
													<input id="hiddenDup" runat="server" name="hiddendelsau" size="1" type="hidden" />
													<input id="hdempcode" runat="server" name="hiddendelsau" size="1" type="hidden" />
													<input id="hiddenfinancecode" runat="server" name="hiddenfinancecode" size="1" type="hidden" />
												</td>
											</tr>
											<tr align="right">
												<td align="right" >
													<asp:button id="btnupdate" runat="server" CssClass="button1"  ></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" Enabled="False"></asp:button></td>
											</tr>
										
									
							</table>
					<table id="table6" style="WIDTH: 633px; HEIGHT: 15px" bgColor="#7daae3" cellspacing="0" cellpadding="0" width="634" align="center"  border="0">
													
							<tr>
								<td align="center" ></td>
							</tr>
						</table>
						
							</td>
							</tr>
						</table>
						
					
		</form>
	</body>
</html>
