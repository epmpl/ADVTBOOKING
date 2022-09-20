<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdCategoryMaster.aspx.cs" EnableEventValidation="false" Inherits="AdCategoryMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//Dtd Xhtml 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title><%--Display Ad. Booking & Sheduling --%>Ad Category Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/AdCategoryMaster.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<%--<script language=javascript type="text/javascript">
		function chkcode()
		{
		      if(document.getElementById('adtype').value=="0" )
				   {	
				        alert('Please Select Ad Type');
        				document.getElementById('adtype').focus();
		        		return false;
				    }
		}
		</script>--%>
		<style>
	
	.Txtfld
    {
	height:13px;	
	font-family: Trebuchet MS;
	font-size: 13px;
	color:black;
	text-align:center;
	width:55px;
	
	
    }
	        .style1
            {
                width: 160px;
            }
	</style>
	</head>
	<body leftmargin="0" topmargin="0" onload="loadXML('xml/errorMessage.xml');givebuttonpermission('AdCategoryMaster');return disablecheck();" onkeydown="javascript:return tabvalue(event,'CheckBox8');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Category Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server" ></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" style="left: 0px; top: 0px">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Ad Category Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table style=" width:100%;margin:-20px 230px" cellpadding="0" cellspacing="0" >	
				<tr>
					<td>
                      <asp:LinkButton ID="lbdetails" runat="server"  CssClass="btnlink_n"></asp:LinkButton>
                    </td>
				</tr>
			</table>
			<table cellpadding="0" cellspacing="0" border="0" style="width:65%;margin:40px 300px;">
			    <tr>
					<td><asp:Label id="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:DropDownList  id="adtype" runat="server" CssClass="dropdown"
							MaxLength="8"></asp:DropDownList></td>
				</tr>
				<tr>
					<td><asp:Label id="lbadvcatcode" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="txtadvcatcode" runat="server" CssClass="btext1"
							MaxLength="8"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:Label id="lbadvcatname" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="txtcatname" onkeypress="javascript:return chkcode();" runat="server" CssClass="btext"
							MaxLength="50"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:Label id="lbalias" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="txtalias" runat="server" CssClass="btext"
							MaxLength="50"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:Label id="lbregclient" runat="server" CssClass="TextField"></asp:Label></td>
					<td>
						<asp:dropdownlist id="drpregclient" Enabled="false" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:Label id="lblfilename" runat="server" CssClass="TextField">Category Image</asp:Label></td>
					<td><asp:TextBox  id="txtfilename" runat="server" CssClass="btext1007" 
							MaxLength="50"></asp:TextBox></td>
				</tr>
			      <tr>
										<td><asp:label id="Status" runat="server" CssClass="TextField"></asp:label></td>
                                        <td><asp:dropdownlist id="drpstatus" runat="server" CssClass="dropdown">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">InActive</asp:ListItem></asp:dropdownlist></td>
										</tr>
										
										
										
										
										<tr>
						<td align="left"><asp:Label id="lbrotime" runat="server" CssClass="TextField"></asp:Label></td>
						<td align="left"><asp:TextBox  onkeypress="return ClientisNumber(event);" id="txthr" runat="server" CssClass="numerictext"
						MaxLength="2"></asp:TextBox><asp:Label id="lbhr" runat="server" CssClass="TextField"></asp:Label><asp:TextBox  onkeypress="return ClientisNumber(event);" ID="txtmin" runat="server" CssClass="numerictext" MaxLength="2" ></asp:TextBox><asp:Label id="lbmin" runat="server" CssClass="TextField"></asp:Label></td>
						
					</tr>
					<tr>
					    <td align="left"><asp:Label id="lbproduction" runat="server" CssClass="TextField"></asp:Label></td>
						<td align="left"><asp:dropdownlist id="txtproduction" runat="server" CssClass="dropdown"
								>
						    <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Sunday</asp:ListItem>
                            <asp:ListItem Value="2">Monday</asp:ListItem>
                            <asp:ListItem Value="3">Tuesday</asp:ListItem>
                            <asp:ListItem Value="4">Wednesday</asp:ListItem>
                            <asp:ListItem Value="5">Thursday</asp:ListItem>
                            <asp:ListItem Value="6">Friday</asp:ListItem>
                            <asp:ListItem Value="7">Saturday</asp:ListItem>
                          
                            </asp:dropdownlist><asp:Label id="lbdaysbefore" runat="server" CssClass="TextField"></asp:Label></td>
					</tr>
					<tr>
					<td><asp:Label id="lblpreod" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="txtpreod" runat="server" CssClass="btext1"
							MaxLength="3"></asp:TextBox></td>
				</tr>	
				
				<tr><td colspan="4"><table>
										<tr>
            <td class="style1">
                    <asp:Label ID="lbldiscount" runat="server" CssClass="TextField">Discount</asp:Label></td>
                <td class="style6">
                    <asp:DropDownList  ID="drpdiscount" runat="server"  CssClass="dropdown"  enable="true">
                    <asp:ListItem Text="--Select Discount--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                    <asp:ListItem Text="Percentage" Value="P"></asp:ListItem></asp:DropDownList></td>
                    
                    <td class="style4">
                    <asp:Label ID="lblamount" runat="server" CssClass="TextField">Amount</asp:Label></td>
                <td class="style3">
                <asp:TextBox ID="txtamount" CssClass="btext1" runat="server"></asp:TextBox></td>
                
            </tr>
              <tr style="display:none;">
            <td class="style1">
                    <asp:Label ID="lblffdis" runat="server" CssClass="TextField" style="width: 200px;">Flat Frequency Dis.</asp:Label></td>
                <td class="style6">
                    <asp:DropDownList  ID="drpffdis" runat="server"  CssClass="dropdown"  enable="true">
                    <asp:ListItem Text="--Select Flat Frequency Discount--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                    <asp:ListItem Text="Percentage" Value="P"></asp:ListItem></asp:DropDownList></td>
                    
                    <td  class="style5">
                    <asp:Label ID="lblffdisc" runat="server" CssClass="TextField">Flat Frequency Amount</asp:Label></td>
                <td class="style3">
                <asp:TextBox ID="txtffdisc" CssClass="btext1" runat="server"></asp:TextBox></td>
            </tr>
            
            <tr>
            <td class="style1">
                    <asp:Label ID="lblcadis" runat="server" CssClass="TextField">Cash Discount</asp:Label></td>
                <td class="style6">
                    <asp:DropDownList  ID="drpcsdis" runat="server"  CssClass="dropdown"  enable="true">
                    <asp:ListItem Text="--Select Cash Discount--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                    <asp:ListItem Text="Percentage" Value="P"></asp:ListItem></asp:DropDownList></td>
                    
                     <td class="style4">
                    <asp:Label ID="lblcsdisc" runat="server" CssClass="TextField">Cash Amount</asp:Label></td>
                <td class="style3">
                <asp:TextBox ID="txtcsdisc" CssClass="btext1" runat="server"></asp:TextBox></td>
                   </tr>
                    <tr>
                     <td class="style4">
                    <asp:Label ID="lbldgenday" runat="server" CssClass="TextField">Lead Generating Days</asp:Label></td>
                
                <td class="style3">
                <asp:TextBox ID="txtldgenday" CssClass="btext1" runat="server"></asp:TextBox></td>

                          <td class="style1">
                    <asp:Label ID="lbldgenflag" runat="server" CssClass="TextField">Lead Generating Flag </asp:Label></td>
                <td class="style6">
                    <asp:DropDownList  ID="drpldgenflag" runat="server"  CssClass="dropdown"  enable="true">
                   
                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem></asp:DropDownList></td>
               
            </tr>

                    <tr>
                        <td class="style1">
                    <asp:Label ID="lbleddisflag" runat="server" CssClass="TextField">Edition Discount Flag </asp:Label></td>
               
                        <td class="style6">
                    <asp:DropDownList  ID="drpeddiscflag" runat="server"  CssClass="dropdown"  enable="true">     
                      <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem></asp:DropDownList></td>
                   </tr>
           </table></td></tr>					
										
										
										
				<tr>
				<td style="height: 19px">
                    <td style="display:none; height: 19px;"><input id="hiddendrpadtype" runat="server" type="hidden"/></td> 
                    <td style="display:none; height: 19px;"><input  id="hiddencode" runat="server" type="hidden"/></td> 
                    <td style="display:none; height: 19px;"><input  id="hiddenadname" runat="server" type="hidden" /></td> 
                    <td style="display:none; height: 19px;"><input id="hiddenadalias" runat="server" type="hidden"/></td> 
                    </td>
               </tr>
			</table>
			<table id="Table5" runat="server" style="margin:0px 300px;"  height="85px" cellspacing="0" cellpadding="0" width="576" border="1">
			    <tr>
				    <td valign="top" align="center" bgColor="#7daae3" colspan="8"><asp:Label id="lbadcatday" runat="server" ForeColor="White" Width="135px" CssClass="TextField"></asp:Label></td>
			    </tr>
			    <tr valign="top">
				    <td align="center"><asp:Label id="Label12" runat="server" CssClass="TextField">SUN</asp:Label></td>
				    <td align="center"><asp:Label id="Label13" runat="server" CssClass="TextField">MON</asp:Label></td>
				    <td align="center"><asp:Label id="Label14" runat="server" CssClass="TextField">TUE</asp:Label></td>
				    <td align="center"><asp:Label id="Label15" runat="server" CssClass="TextField">WED</asp:Label></td>
				    <td align="center"><asp:Label id="Label16" runat="server" CssClass="TextField">THU</asp:Label></td>
				    <td align="center"><asp:Label id="Label17" runat="server" CssClass="TextField">FRI</asp:Label></td>
				    <td align="center"><asp:Label id="Label19" runat="server" CssClass="TextField">SAT</asp:Label></td>
				    <td align="center"><asp:Label id="Label18" runat="server" CssClass="TextField">ALL</asp:Label></td>
			    </tr>
			    <tr valign="top">
				    <td align="center"><asp:CheckBox id="CheckBox1" runat="server" CssClass="textfield" onload="CheckBox1_Load"></asp:CheckBox></td>
				    <td align="center"><asp:CheckBox id="CheckBox2" runat="server" CssClass="textfield"></asp:CheckBox></td>
				    <td align="center"><asp:CheckBox id="CheckBox3" runat="server" CssClass="textfield"></asp:CheckBox></td>
				    <td align="center"><asp:CheckBox id="CheckBox4" runat="server" CssClass="textfield"></asp:CheckBox></td>
				    <td align="center"><asp:CheckBox id="CheckBox5" runat="server" CssClass="textfield"></asp:CheckBox></td>
				    <td align="center"><asp:CheckBox id="CheckBox6" runat="server" CssClass="textfield"></asp:CheckBox></td>
				    <td align="center"><asp:CheckBox id="CheckBox7" runat="server" CssClass="textfield"></asp:CheckBox></td>
				    <td align="center"><asp:CheckBox id="CheckBox8" runat="server" CssClass="textfield"></asp:CheckBox></td>
			    </tr>
			    
			     <tr valign="middle">
								<td align="center"><asp:TextBox runat="server" ID="txt1" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt2" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt3" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt4" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt5" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt6" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center"><asp:TextBox runat="server" ID="txt7" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
								<td align="center" style="display:none"><asp:TextBox runat="server" ID="txt8" CssClass="Txtfld" onkeypress="javascript:return ischarKey(event);" MaxLength="5"></asp:TextBox></td>
				</tr>
			</table>
			
			<input id="hiddencomcode" type="hidden" size="1" runat="server" name="hiddencomcode"/>
			<input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="userid1" type="hidden" name="userid1" runat="server"/>
            <input id="hiddenchk" type="hidden" size="5" name="hide" runat="server" />
			<input id="hiddencatmodify" type="hidden" name="hiddencatmodify" runat="server"/>
			<input id="txtadcate" type="hidden" runat="server" />
			<input id="hiddenccode" type="hidden" size="1" name="Hidden2" runat="server" />
		<input id="ip1" type="hidden" name="ip1" runat="server" />
			
			<input id="hid" type="hidden" size="1" name="Hidden2" runat="server" />
			<asp:Label ID="d1" runat="server"></asp:Label>
		</form>
	</body>
</html>

