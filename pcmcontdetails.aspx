<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"CodeFile="pcmcontdetails.aspx.cs" Inherits="pcmcontdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Publication Center Master Contact Detail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/PubCatMast.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotabpopup.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript">
	function alpha1(event)
{

if(browser!="Microsoft Internet Explorer")
 {
if((event.which>=65 && event.which<=90) ||(event.which>=97 && event.which<=122)||(event.which==32)||(event.which==0))

{
if(document.getElementById('txtcontactperson').value=="")
{
    if(event.which==32)
    {
        return false;
    }
}
return true;
}

else
{
//alert("Please Enter only Alphabet Values");
return false;
}
}
else
{
if((event.keyCode>=65 && event.keyCode<=90) ||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==32)||(event.which==0))

{
if(document.getElementById('txtcontactperson').value=="")
{
    if(event.keyCode==32)
    {
        return false;
    }
}
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
//alert(event.which);
 if(browser!="Microsoft Internet Explorer")
 {
 if ((event.which>=48 && event.which<=57)||(event.which==9) || (event.which==8) ||(event.which==32) ||(event.which==11)|| (event.which==13)||(event.which==0))
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
 if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9) || (event.keyCode==8)||(event.keyCode==32) ||(event.keyCode==11)|| (event.keyCode==13)||(event.which==0))
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
		
				<script type="text/javascript" language="javascript">
	function dateenter(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
       if ((event.which>=48 && event.which<=57)||(event.which==9)  || (event.which==8)|| (event.which==0) ||(event.which==11)|| (event.which==13)||(event.which==0))
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
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)|| (event.keyCode==8)||(event.keyCode==11)|| (event.keyCode==13)||(event.which==0))
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
	<body onload="loadXML('xml/errorMessage.xml');" onkeydown="javascript:return tabvalue();">
		<form id="Form1" method="post" runat="server">
			<table id="Table4" style="Z-INDEX: 101; LEFT: 24px; WIDTH: 639px; POSITION: absolute; TOP: 16px; HEIGHT: 432px"
				bordercolor="#000000" cellspacing="0"  cellpadding="0" width="639" border="1" ms_2d_layout="TRUE">
				<tr>
					<td valign=top>
						<table id="Table2" style="WIDTH: 633px; HEIGHT: 15px" cellspacing="0" cellpadding="0" width="633"
							align="center" bgcolor="#7daae3" border="0" >
							<tr>
								<td class="btnlinksau" bgcolor="#7daae3" style="height: 19px" valign=top align="center" >Contact Detail</td>
							</tr>
						</table>
						<table id="Table1"  cellspacing="0" cellpadding="0"
							width="562" align="center" border="0">
							<tr>
							</tr>
							<tr>
								<td align="center">
									<table id="Table5" width="585px" cellspacing="0" cellpadding="0"
										align="center" border="0">
										<tr  onkeypress="eventcalling(event)">
											<td align="left"><asp:Label id="lbcontperson" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox onkeypress="return alpha1(event)"  id="txtcontactperson" runat="server" CssClass="btext1"
													MaxLength="50"></asp:textbox></td>
											<td align="left"><asp:Label id="lbphoneno" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox onkeypress="return phone(event)" id="txtphoneno" runat="server" CssClass="numerictext" MaxLength="13"></asp:textbox></td>
										</tr>
										<tr onkeypress="eventcalling(event)">
											<td align="left"><asp:Label id="lbdob" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox onkeypress="return clientdate(event);" id="txtdob" runat="server" CssClass="btext1" MaxLength="10"  ></asp:textbox>
												<%--<img src='Images/cal1.gif' id="div123"  onclick='popUpCalendar(this, form1.txtdob, "mm/dd/yyyy")' onfocus=abc();  height=14 width=14> 
									--%>
												<script type="text/javascript"language="javascript">
																		
			                           if (!document.layers) 
									     {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtdob, \"mm/dd/yyyy\")' onfocus=abc();  height=14 width=14> ")
									     }
																			
												</script>
											</td>
											<td align="left">
												<asp:Label id="lbdesignation" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left">
												<asp:textbox onkeypress="return alpha1(event)" id="txtdesignation" runat="server" CssClass="btext1"
													MaxLength="30"></asp:textbox></td>
										</tr>
										<tr onkeypress="eventcalling(event)">
											<td align="left"><asp:Label id="lbFaxNo" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox id="txtfaxno" onkeypress="return phone(event)" runat="server" CssClass="numerictext" MaxLength="13"></asp:textbox></td>
											<td align="left"><asp:Label id="lbExtension" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox onkeypress="return phone(event)" id="txtext" runat="server" CssClass="numerictext" MaxLength="10"></asp:textbox></td>
										</tr>
										<tr>
											<td align="left"><asp:Label id="lbEmailID" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox id="txtemailid" runat="server" CssClass="btext1" MaxLength="50" ></asp:textbox></td>
											<td align="left"><asp:Label id="lblempcod" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox id="txtemcode" runat="server" Height="17px" CssClass="btextmail" MaxLength="50"></asp:textbox></td>
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
											<td colspan="1"  <%--style="margin-left"--%> align="right"><asp:button id="btnsubmit" runat="server" CssClass="button1" Width="56px" OnClick="btnsubmit_Click" ></asp:button><asp:Button ID="btnclear" runat="server" CssClass="button1" /></td>
                                               
										</tr>
										<tr>
											<td></td>
											<td></td>
											<%--<td></td>
											<td></td>--%>
										</tr>
									</table>
									<div id="Divgrid1" runat="server" style="OVERFLOW: auto; WIDTH: 587px; HEIGHT: 208px">
										<table id="Table3" style="WIDTH: 562px; HEIGHT: 168px" align="center">
											<tr>
												<td><asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="575px" OnSortCommand="abc" AllowSorting="True" cellpadding="0" AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="775"   >
														<SelectedItemStyle Font-Size="XX-Small" Font-Names="Trebuchet MS" HorizontalAlign="Center" VerticalAlign="Middle"></SelectedItemStyle>
														<HeaderStyle Height="20px" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server" />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Cont_Person" SortExpression="Cont_Person" ReadOnly="True" HeaderText="Contact Person">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DOB" SortExpression="DOB" ReadOnly="True" HeaderText="Date Of Birth"
																DataFormatString="{0:d}">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Designation" HeaderText="Designation" SortExpression="Designation">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundColumn>
															<asp:BoundColumn DataField="Phone" SortExpression="Phone" ReadOnly="True" HeaderText="Phone No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Extention" SortExpression="Extention" ReadOnly="True" HeaderText="Ext.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Fax" SortExpression="Fax" ReadOnly="True" HeaderText="Fax No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
                                                            <asp:BoundColumn DataField="EmailID" HeaderText="Email ID" ReadOnly="True" SortExpression="EmailID">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="Cont_Code" ReadOnly="True" HeaderText="contcode" SortExpression="Cont_Code">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid>
												</td>
											</tr>
										</table>
									</div>
									<div id="Divgrid2" runat="server" style="OVERFLOW: auto; WIDTH: 587px; HEIGHT: 208px">
										<table id="Table7" style="WIDTH: 562px; HEIGHT: 168px" align="center">
											<tr>
												<td><asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="575px"
														cellpadding="0" AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="775"  OnSortCommand="abc" AllowSorting="True" OnSelectedIndexChanged="DataGrid2_SelectedIndexChanged">
														<SelectedItemStyle Font-Size="XX-Small" Font-Names="Trebuchet MS" HorizontalAlign="Center" VerticalAlign="Middle"></SelectedItemStyle>
														<HeaderStyle Height="20px" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="Cont_Person" SortExpression="Cont_Person" ReadOnly="True" HeaderText="Contact Person">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DOB" SortExpression="DOB" ReadOnly="True" HeaderText="Date Of Birth"
																DataFormatString="{0:d}">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Designation" HeaderText="Designation" SortExpression="Designation">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:BoundColumn>
															<asp:BoundColumn DataField="Phone" SortExpression="Phone" ReadOnly="True" HeaderText="Phone No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Extention" SortExpression="Extention" ReadOnly="True" HeaderText="Ext.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Fax" SortExpression="Fax" ReadOnly="True" HeaderText="Fax No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EmailID" SortExpression="EmailID" ReadOnly="True" HeaderText="Email Id">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="Cont_Code" ReadOnly="True" HeaderText="contcode" SortExpression="Cont_Code">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid>
												</td>
											</tr>
											
										</table>
									</div>
								</td>
								
							</tr>
									
									        <tr align="right">
												<td align="right">
                                                    <asp:Button ID="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click" /><asp:Button ID="btndelete" runat="server" CssClass="button1" /></td>
                                            </tr>
						</table>
						<table id="Table6" style="WIDTH: 634px; HEIGHT: 19px" cellspacing="0" cellpadding="0" width="634"
							align="center" bgcolor="#7daae3" border="0">
							<tr>
								<td align="center"></td>
							</tr>
						</table>
					<div></div>
					</td>
				</tr>
			</table>
			                                        <input type="hidden" size="12" name="hiddencomcode" runat="server" id="hiddencompcode"/>
													<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/> 
													<input id="hiddencentcode" type="hidden" name="hiddencent" runat="server"/>
													<input id="hiddendateformat" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddenccode" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddenshow" type="hidden" size="1" name="hideshow" runat="server"/>
													<input id="hiddenchk" type="hidden" size="1" name="hide" runat="server"/>
													<input id="hiddencontsau" type="hidden" name="hiddencontsau" runat="server"/>
													<input id="hiddencsau" type="hidden" size="1" name="hiddencsau" runat="server"/>
													<input id="hiddendelsau" type="hidden" size="1" name="hiddendelsau" runat="server"/>
														<input id="hdempcode" runat="server" name="hiddendelsau" size="1" type="hidden" />
            <input id="hiddenDup" runat="server" name="hiddendelsau" size="1" type="hidden" />
		</form>
	</body>
</html>
