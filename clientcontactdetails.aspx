<%@ Page Language="C#" AutoEventWireup="true" CodeFile="clientcontactdetails.aspx.cs" Inherits="clientcontactdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad Master Client Master ContactDetails</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/ClientMaster_popup.js"></script>
		<script language="javascript" src="javascript/ClientMaster.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/datechkforcurrdate.js" type="text/javascript"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
	</style>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
		
	


function alpha1()
{
if((event.keyCode>=65 && event.keyCode<=90) ||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==32) ||(event.keyCode==13))
{
return true;
}

else
{
//alert("Please Enter only Alphabet Values");
return false;
}


}


function datecurr(event)
{
var browser=navigator.appName;
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


function phone(event) {

var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 48 && event.which <= 57) || ((event.which == 127) || (event.which == 37) || (event.which == 46) || (event.which == 8) || (event.which == 9) || (event.which == 13) || (event.which == 0) || (event.which == 47) || (event.which == 44) || (event.keyCode == 37) || (event.keyCode == 53)))
        {

        return true;
        }
        else
        {
        //alert("Please Enter Only Numeric Value");
        return false;
        }
}
else
{
    if ((event.keyCode >= 48 && event.keyCode <= 57) || ((event.keyCode == 127) || (event.keyCode == 37) || (event.keyCode == 46) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 13) || (event.keyCode == 47) || (event.keyCode == 44)))
        {

        return true;
        }
        else
        {
        //alert("Please Enter Only Numeric Value");
        return false;
        }  
}        
}









				



		</script>
</HEAD>
	<body id = "bdy" onkeydown="tabvalue('txtemailid')">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 64px; WIDTH: 495px; POSITION: absolute; TOP: 48px; HEIGHT: 364px" borderColor="#000000" cellSpacing="0" cellPadding="0" width="495" border="1">
				<TR>
					<TD>
						<TABLE id="Table2" style="WIDTH: 633px; HEIGHT: 15px" cellSpacing="0" cellPadding="0" width="633"
							align="center" bgColor="#7daae3" border="0">
							<TR>
								<TD class="btnlink" align="center" style="height: 17px">Contact Detail</TD>
							</TR>
						</TABLE>
						<TABLE id="Table1" style="WIDTH: 562px; HEIGHT: 216px" cellSpacing="0" cellPadding="0"
							width="562" align="center" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table5" style="WIDTH: 585px" cellSpacing="0" cellPadding="0"
										align="center" border="0">
										<TR onkeypress="eventcalling(event);">
											<TD align="left"><asp:label id="lbcontact" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="left"><asp:textbox onkeypress="return alpha1()" id="txtcontactperson" runat="server" CssClass="btext1"
													MaxLength="50"></asp:textbox></TD>
											<TD align="left"><asp:label id="lbphone" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="right"><asp:textbox onkeypress="return phone(event)" id="txtphoneno" runat="server" CssClass="btext1numeric" MaxLength="8"></asp:textbox></TD>
										</TR>
										<TR>
											<TD align="left"><asp:label id="lbdob" runat="server" CssClass="TextField"></asp:label></TD>
											<%--<TD align="left"><asp:textbox onkeydown="return datecurr(event);" id="txtdob" runat="server" MaxLength="10" CssClass="btext1" ></asp:textbox>
												<SCRIPT language="javascript">
																		
			                           if (!document.layers) 
									     {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtdob, \"mm/dd/yyyy\")' height=14 width=14> ")
									     }
																			
												</SCRIPT>
											</TD>--%>
											<TD align="left">
											 <asp:TextBox ID="txtdob" runat="server" CssClass="btext1" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtdob, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />
											</TD>
											 <td style="display:none">
                                                        
                                                         <asp:TextBox ID="txtdatetime" runat="server" CssClass="btext3" Enabled="False">Date/Time</asp:TextBox>
                                                       
                                                    </td>
											
											
											<TD align="left"><asp:label id="lblmobile" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="right"><asp:textbox id="txtmobile" onkeypress="return phone(event)" runat="server" CssClass="btext1numeric" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD align="left"><asp:label id="lblanniversary" runat="server" CssClass="TextField"></asp:label></TD>
											<%--<TD align="left"><asp:textbox onkeydown="return datecurr(event);" id="txtanniversary" runat="server" MaxLength="10" CssClass="btext1" ></asp:textbox>
												<SCRIPT language="javascript">
																		
			                           if (!document.layers) 
									     {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtanniversary, \"mm/dd/yyyy\")' height=14 width=14> ")
									     }
																			
												</SCRIPT>--%>
												
												
												
												<td align="left">
												<asp:TextBox ID="txtanniversary" runat="server" CssClass="btext1" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, Form1.txtanniversary, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />
												
												
												</td>
											<TD align="left"><asp:label id="lbfax" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="right"><asp:textbox id="txtfaxno" onkeypress="return phone(event)" runat="server" CssClass="btext1numeric" MaxLength="30"></asp:textbox></TD>
										</TR>
										<TR>
											<TD align="left"><asp:label id="lbemailid" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="left"><asp:textbox id="txtemailid" runat="server" CssClass="btextmail" MaxLength="200"></asp:textbox></TD>
											<TD align="left"><asp:label id="lbextension" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="right"><asp:textbox onkeypress="return phone(event)" id="txtext" runat="server" CssClass="btext1numeric" MaxLength="10"></asp:textbox></TD>
										</TR>
										
										<td></td><td></td>
										
										<td align="left"><asp:Label id="lblempcod" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="right"><asp:textbox id="txtemcode" runat="server" Height="17px" CssClass="btextmail" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
										<td></td>
										<td></td>
										<td colspan="2"><asp:ListBox ID="lstempcode" Width="300px" Height="65px" runat="server" CssClass="btextlist" style="display:none;" ></asp:ListBox></td>
										</tr>
										<tr>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<td colspan="1" align="right"><asp:button id="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click"></asp:button><asp:Button ID="btnclear" runat="server" CssClass="button1" /></td>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
									<div id="Divgrid1" runat="server" style="OVERFLOW: auto; WIDTH: 587px; HEIGHT: 208px">
										<TABLE id="Table3" style="WIDTH: 562px; HEIGHT: 168px" align="center">
											<TR>
												<TD><asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="554px" AllowSorting="True"
														CellPadding="0" AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="775" onsortcommand="DataGrid1_SortCommand">
														<SelectedItemStyle Font-Size="XX-Small" Font-Names="Trebuchet MS" HorizontalAlign="Center" VerticalAlign="Middle"></SelectedItemStyle>
														<HeaderStyle Height="20px" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server" />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="cont_person" SortExpression="Contact Person" ReadOnly="True" HeaderText="Contact Person">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="dob" SortExpression="Date Of Birth" ReadOnly="True" HeaderText="Date Of Birth" 
 DataFormatString="{0:d}">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="phone" SortExpression="Phone No." ReadOnly="True" HeaderText="Phone No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="extension" SortExpression="Ext" ReadOnly="True" HeaderText="Ext.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="fax" SortExpression="Fax No." ReadOnly="True" HeaderText="Fax No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="emailid" SortExpression="Email Id" ReadOnly="True" HeaderText="Email Id">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="cont_code" ReadOnly="True" HeaderText="contcode">
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
															<asp:BoundColumn DataField="anniversary" SortExpression="Anniversary Date" ReadOnly="True" HeaderText="Anniversary Date" 
                                                                    DataFormatString="{0:d}">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="MOBILENO" SortExpression="Mobile No." ReadOnly="True" HeaderText="Mobile No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
													</asp:datagrid>
														</td>
											</tr>
										</table>
									</div>
													<div id="Divgrid2" runat="server" style="OVERFLOW: auto; WIDTH: 587px; HEIGHT: 208px">
										<table id="Table7" style="WIDTH: 562px; HEIGHT: 168px" align="center">
											<tr>
												<td><asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="554px"
														cellpadding="0" AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="775" AllowSorting="True">
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
															<asp:BoundColumn DataField="Phone" SortExpression="Phone" ReadOnly="True" HeaderText="Phone No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Extension" SortExpression="Extention" ReadOnly="True" HeaderText="Ext.">
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
															<asp:BoundColumn DataField="ANNIVERSARY" SortExpression="ANNIVERSARY" ReadOnly="True" HeaderText="Anniversary Date"
																DataFormatString="{0:d}">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="MOBILENO" SortExpression="MOBILENO" ReadOnly="True" HeaderText="Mobile No.">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" CssClass="dtGridtext" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
													</asp:datagrid>
												</td>
											</tr>
											
										</table>
									</div>
							
								</TD>
							</TR>
													
										
											<TR align="right">
												<TD align="right"><asp:Button ID="btnclose" runat="server" CssClass="button1" /><asp:button id="btndelete" runat="server" CssClass="button1"></asp:button></TD>
											</TR>
						</TABLE>
						<TABLE id="Table6" style="WIDTH: 634px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="634"
							align="center" bgColor="#7daae3" border="0">
							<TR>
								<TD align="center"></TD>
							</TR>
						</TABLE>
						
					</TD>
				</TR>
			</TABLE>
			<INPUT id="hiddencomcode" type="hidden" size="12" name="hiddencomcode" runat="server">
			<INPUT id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server">
			<INPUT id="hiddencustcode" type="hidden" name="hiddenagevcode" runat="server">
			<INPUT id="hiddenchk" type="hidden" name="hiddenchk" runat="server">
			<INPUT id="hidden" type="hidden" size="1" name="hiddenagensubcode" runat="server">
			<INPUT id="hiddenccode" type="hidden" size="1" name="hiddenagensubcode" runat="server">
			<INPUT id="hidden1" type="hidden" size="1" name="hiddenagensubcode" runat="server">
			<INPUT id="hiddendateformat" type="hidden" size="1" name="hiddenagensubcode" runat="server">&nbsp;
			<INPUT id="hiddenDupName"  type=hidden size=1 name="hiddenagensubcode" runat="server" />	
				<input id="hdempcode" runat="server" name="hiddendelsau" size="1" type="hidden" />								
		</form>
	</body>
</HTML>