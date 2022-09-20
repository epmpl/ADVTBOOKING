<%@ Page Language="C#" AutoEventWireup="true" CodeFile="genReference.aspx.cs" Inherits="genReference" EnableEventValidation="false"%>


<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Classified : Reference File</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/genReference.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>	
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>	
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
    .loader {
            border: 16px solid #02090e;
            border-radius: 50%;
            border-top: 16px solid #3498db;
            width: 50px;
            height: 50px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }
	</style>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/tree.js">

</script>
		
</head>
<body style="background-color:#f3f6fd;">
    <form id="Form1" method="post" runat="server">
          <div id="divloader" style="position: absolute; top: 0px; left: 800px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src='Images/loader.gif' id="Img1" height="400" width="400" /></td>
                </tr>
            </table>
        </div>
        &nbsp;
        <table id="OuterTable" width="1000" align="center" border="0" cellpadding="0"
				cellspacing="0">
				<tr valign="top">
					<td colSpan="2" style="height: 59px"><uc1:topbar id="Topbar1" runat="server" Text="Reference File"></uc1:topbar></td>
				</tr>
				<tr valign="top" >
					<td valign="top" style="width: 214px;" ><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" id="frsttd" style="width:742px;" align="left">	
					<table id="RightTable" style="width:780px;">
					<tr valign="top">
							<td style="width: 706px">
                                     	<asp:button id="btnExit" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button>
										<asp:button id="btnReference" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="91px" CssClass="topbutton" OnClick="btnReference_Click"></asp:button>
										<asp:button id="btnCopy" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="91px" CssClass="topbutton" Text="Copy"></asp:button>
										</td></tr>
                                        <tr><td style="display:none;">
											<asp:button id="btnReport" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="91px" CssClass="topbutton" Text="Report" ></asp:button></td>
							</tr>
					
					
						</table>
					<asp:label id="li" runat="server"></asp:label>
					</td>									
			</tr>
		</table>
		
		<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>
                         Reference File</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
		<table cellSpacing="0" cellPadding="0" border="0" style="width:auto;margin:30px 300px;">
					<tr><td style="width:138px">
					<asp:Label ID="lblPublicationDate" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:TextBox ID="PubDate" runat="server" CssClass="btext1" Width="144px"></asp:TextBox>
                       <img src='Images/cal1.gif' id="div1" onclick='popUpCalendar(this, Form1.PubDate, "mm/dd/yyyy")' height=17 width=18></td>
                       <td colspan="3" style="width: 212px">&nbsp;&nbsp;&nbsp;
                       <asp:Label ID="lblcenters" runat="server" CssClass="TextField" Text="Local Flow"></asp:Label>&nbsp;
                       <asp:CheckBox ID="chkcenters" runat="server" Checked="false" /></td>
					</tr>
					<tr>
					<td style="width: 138px"><asp:Label ID="lblPublication" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:DropDownList ID="ddlPublication" runat="server" CssClass="dropdown" Width="152px"><asp:ListItem Value="0">Select Publication</asp:ListItem></asp:DropDownList></td>
                       <td colspan="2" style="width: 212px"></td>
					</tr>
					<tr>
					<td style="width: 138px"><asp:Label ID="lblCenter" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:DropDownList ID="ddlCenter" runat="server" CssClass="dropdown" Width="151px"><asp:ListItem Value="0">Select Center</asp:ListItem></asp:DropDownList></td>
                      <td style="display:none;"><asp:Label ID="lbpackage" runat="server" CssClass="TextField" ></asp:Label></td>
					<td style="display:none;"><asp:CheckBox ID="Chkpackage" runat="server" Checked="false" /></td></tr>
					
					<tr>
					<td style="width: 138px"><asp:Label ID="lblEdition" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:ListBox ID="ddlEdition" runat="server" SelectionMode="Multiple" CssClass="dropdown" Width="151px" Height="76px"><asp:ListItem Value="0">Select Edition</asp:ListItem></asp:ListBox></td>
                         
        <td    style="display:none; " id="tdpackage1" runat="server" class="style3" colspan="3" rowspan="3">
        <asp:ListBox ID="listpackage" runat="server" CssClass="dropdown" 
                  onpaste="return false;" MaxLength="10" SelectionMode="Multiple" 
                Width="251px" Height="76px"></asp:ListBox>
        </td>
					</tr>
					<tr>
					<td style="width: 138px"><asp:Label ID="lblSupplement" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:DropDownList ID="ddlSupplement" runat="server" CssClass="dropdown" Width="150px"><asp:ListItem Value="0">Select Supplement</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td style="width: 138px"><asp:Label ID="lblincludeuom" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:ListBox ID="drpincludeuom" runat="server" SelectionMode="Multiple" CssClass="dropdown" Width="151px" Height="76px"></asp:ListBox></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td style="width: 138px"><asp:Label ID="lblexcludeuom" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:ListBox ID="drpexcludeuom" runat="server" SelectionMode="Multiple" CssClass="dropdown" Width="151px" Height="76px"></asp:ListBox></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td style="width: 138px"><asp:Label ID="lblincludead" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:ListBox ID="drpincludead" runat="server" SelectionMode="Multiple" CssClass="dropdown" Width="151px" Height="76px"></asp:ListBox></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td style="width: 138px"><asp:Label ID="lblexcludead" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:ListBox ID="drpexcludead" runat="server" SelectionMode="Multiple" CssClass="dropdown" Width="151px" Height="76px"></asp:ListBox></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td style="width: 138px"><asp:Label ID="lblFilepath" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 203px">
                       <asp:TextBox ID="txtFilepath" runat="server" CssClass="btext1" Width="147px"></asp:TextBox></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td><asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Include UnAudit Ad"></asp:Label></td>
					<td><asp:CheckBox ID="chkaudit" runat="server" Checked="false" /></td></tr>
					<tr>
					<td style="width: 138px"></td>
                       <td style="width: 203px"></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					
					
					</table>
        <input id="hiddenuserid" runat="server" type="hidden" name="hiddenuserid">&nbsp;
        <input id="hiddenusername" runat="server" type="hidden" name="username">
        <input id="hiddencompcode" runat="server" type="hidden" name="hiddencompcode">
        <input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server"/>
        <input id="hiddenpermission" type="hidden" name="hiddenpermission" runat="server">
        <input id="UserLabel" type="hidden" name="UserLabel" runat="server"/> 
        <input id="hiddenstatuslabel" type="hidden" name="hiddenstatuslabel" runat="server">
        <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server">	
        <input id="hiddenxtgfilepath_local" type="hidden"  runat="server" />
        <input id="hiddenlogincenter" type="hidden"  runat="server" />
        <input id="hiddenclassified_reference" type="hidden"  runat="server" />
        
		</form>
</body>
</html>
