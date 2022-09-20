<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultPageConfigurationMaster.aspx.cs" Inherits="DefaultPageConfigurationMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>Default Page Configuration</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		
		<script type="text/javascript"language="javascript" src="javascript/DefaultPageConfig.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Tree.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/entertotab_pagestatus.js"></script>
     	<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script> 
		<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
		
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	     .style2 { COLOR: #ffffff }
	    </style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"/>
</head>
<body onload="document.getElementById('btnNew').focus();" onkeydown="javascript:return tabvalue(event,'txtValidateDateTo');" style="background-color:#f3f6fd; margin:0px 0px 0px 0px;">
    <form id="form1" runat="server">
    <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Default Page Configuration" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
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
				 </td><asp:label id="li" runat="server"></asp:label>
				</tr>
		</table>
		<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:167PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Default Page Configuration</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:700px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
		<table cellspacing="0" cellpadding="0"  border="0" style="width:65%;margin:30px 300px;">
		            <tr><td><asp:Label ID="radiobt1" runat="server" CssClass="TextField">
		            <asp:RadioButton ID="Rdbt1" Font-Bold="true" runat="server" Text="Main" CssClass="TextField" Width="100px" Checked="true" GroupName="Radio" />
		            </asp:Label></td>
		            <td><asp:Label ID="radiobt2" runat="server" CssClass="TextField"><asp:RadioButton ID="Rdbt2" Font-Bold="true" runat="server" Text="Suppliment" CssClass="TextField" GroupName="Radio" /></asp:Label></td>
		            </tr>
					<tr>
					<td>
					<asp:Label ID="lblPublication" Height="25px" runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:DropDownList ID="ddlPublication" runat="server" CssClass="dropdown" ><asp:ListItem Value="0">Select Publication</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr>
					<td><asp:Label ID=lblCenter runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:DropDownList ID="ddlCenter" runat="server" CssClass="dropdown" ><asp:ListItem Value="0">Select Center</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr>
					<td><asp:Label ID=lblEdition runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:DropDownList ID="ddlEdition" runat="server" CssClass="dropdown" ><asp:ListItem Value="0">Select Edition</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr>
					<td><asp:Label ID=lblSupplement runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:DropDownList ID="ddlSupplement" runat="server" CssClass="dropdown"><asp:ListItem Value="0">Select Supplement</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 182px"></td>
                       
					</tr>
					<tr><td>
                       <asp:Label ID="lblAdFilling" runat="server" CssClass="TextField"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlAdFilling" runat="server" CssClass="dropdown"><asp:ListItem Value="0">Select Ad Filling</asp:ListItem></asp:DropDownList></td>
                    <td colspan=1 style="width:22px"></td>
					
                        
                    </tr>
					<tr>
					<td><asp:Label ID=lblCategory runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:DropDownList  id="txtCategory" runat="server" CssClass="dropdown" Width="144px"><asp:ListItem Value="0">-- Select Category --</asp:ListItem></asp:DropDownList></td>
                       <td></td>
                       <td>
                       <asp:Label ID="lblNoofPage" runat="server" CssClass="TextField"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlNoofPage" runat="server" CssClass="dropdown" ><asp:ListItem Value="0">Select Pages</asp:ListItem></asp:DropDownList></td>
                   <%-- <td>
                       <asp:Label ID="lblSubcategory" runat="server" CssClass="TextField" Visible="false"></asp:Label></td>
                    <td>
                        <asp:textbox  id="txtSubcategory" runat="server" CssClass="txtPage" Width="138px" MaxLength="10" Visible="false"></asp:textbox></td>--%>
                      
					</tr>
					<tr>
					<td><asp:Label ID=lblPageno runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:textbox  id="txtPageno" onkeypress="return ClientisNumber();"  runat="server" CssClass="txtPage" Width="138px" MaxLength="3"></asp:textbox></td>
                    <td></td>
                    <td>
                       <asp:Label ID="lblPageHeading" runat="server" CssClass="TextField"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlPageHeading" runat="server" CssClass="dropdown" ></asp:DropDownList></td>
                        
					</tr>
					<tr><td>
                       <asp:Label ID="lblPageColor" runat="server" CssClass="TextField"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlPageColor" runat="server" CssClass="dropdown" ><asp:ListItem Value="0">Select Page Color</asp:ListItem></asp:DropDownList></td>
                        <td></td>
                        <td><asp:Label ID=lblPageVolume runat="server" CssClass="TextField"></asp:Label></td>
                      <td> <asp:textbox  id="txtPageVolume" onkeypress="return ClientisNumber();" runat="server" CssClass="txtPage" Width="138px" MaxLength="4"></asp:textbox></td>
                    
                    </tr>
					<tr>
					<td><asp:Label ID=lblPageHeight onkeypress="return ClientisNumber();" runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:textbox  id="txtPageHeight" onkeypress="return ClientisNumber();" runat="server" CssClass="txtPage" Width="138px" MaxLength="2"></asp:textbox></td>
                    <td></td>
                       <td><asp:Label ID=lblPageWidth runat="server" CssClass="TextField"></asp:Label></td>
                       <td><asp:textbox  id="txtPageWidth" onkeypress="return ClientisNumber();" runat="server" CssClass="txtPage" Width="138px" MaxLength="2"></asp:textbox></td>
                       
					
					</tr>
					<tr>
					 
					<td><asp:Label ID=lblPremiumRequired runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:DropDownList ID="ddlPremiumRequired" runat="server" CssClass="dropdown" ><asp:ListItem Value="0">Select Premium</asp:ListItem>
                       <asp:ListItem Value="Y">YES</asp:ListItem>
                       <asp:ListItem Value="N">NO</asp:ListItem>
                       </asp:DropDownList></td>
                    <td></td>
                    <td><asp:Label ID=lblMaxAdAllow runat="server" CssClass="TextField"></asp:Label></td>
                   
                    <td>
                        <asp:textbox  id="txtMadAdAllow" onkeypress="return ClientisNumber();" runat="server" CssClass="txtPage" Width="138px"></asp:textbox></td>
                      
					</tr>
					<tr>
					 
					<td><asp:Label ID=lblHouseAdRequired runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:DropDownList ID="ddlHouseAdRequired" runat="server" CssClass="dropdown" ><asp:ListItem Value="0">Select House Ad Required</asp:ListItem>
					<asp:ListItem Value="Y">YES</asp:ListItem>
                     <asp:ListItem Value="N">NO</asp:ListItem>
					</asp:DropDownList></td>
                    <td></td>
                    <td><asp:Label ID=lblMaxAdSize runat="server" CssClass="TextField"></asp:Label></td>
                    
					<td><asp:textbox ID="txtMaxAdSize" onkeypress="return ClientisNumber();" runat="server" CssClass="txtPage" Width="138px" ></asp:textbox></td>
                    
					</tr>
					<tr>
					 
					<td><asp:Label ID=lblStartingRow runat="server" CssClass="TextField"></asp:Label></td>
					<td>                       
                       <asp:textbox  id="txtStartingRow" onkeypress="return ClientisNumber();" runat="server" CssClass="txtPage" Width="138px" MaxLength="2"></asp:textbox></td>
                    <td></td>
                    <td><asp:Label ID=lblStartingCol runat="server" CssClass="TextField"></asp:Label></td>
                    <td>
                       <asp:textbox  id="txtStartingCol" onkeypress="return ClientisNumber();"  runat="server" CssClass="txtPage" Width="138px" MaxLength="2"></asp:textbox></td>
                      
					</tr>
					
					<tr>
					<td><asp:Label ID=lblSharepageStatus runat="server" CssClass="TextField"></asp:Label></td>
					<td>
                       <asp:DropDownList  id="txtSharepageStatus" runat="server" CssClass="dropdown"><asp:ListItem Value="0">-Select SharePageStatus-</asp:ListItem>
                       <asp:ListItem Value="Y">YES</asp:ListItem>
                       <asp:ListItem Value="N">NO</asp:ListItem>
                       </asp:DropDownList></td>
                    <td></td>
                    
                       <td><asp:Label ID=lblSharePageno runat="server" CssClass="TextField"></asp:Label></td>
                       <td><asp:textbox  id="txtSharePageno" onkeypress="return ClientisNumber();"  runat="server" CssClass="txtPage" Width="138px" MaxLength="2"></asp:textbox></td>
                       
					
					</tr>
					<tr>
					 
					<td><asp:Label ID=lblValidateDateFrom runat="server" CssClass="TextField"></asp:Label></td>
					<td>                      
                        <asp:textbox  id="txtValidateDateFrom" runat="server" CssClass="txtPage" Width="138px"></asp:textbox>
                        <img src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, form1.txtValidateDateFrom, "mm/dd/yyyy")' height="17" width="18" style="clip: rect(auto auto auto auto)"/></td>
                     <td></td>
                    <td><asp:Label ID=lblvalidateDateTo runat="server" CssClass="TextField" ></asp:Label></td>
                    <td>
                       <asp:textbox  id="txtValidateDateTo" runat="server" CssClass="txtPage" Width="138px" ></asp:textbox>
                       <img src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, form1.txtValidateDateTo, "mm/dd/yyyy")' height="17" width="18" style="clip: rect(auto auto auto auto)"/></td>
                  
                      </table>
    </form>
    
        <INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server">
        <INPUT id="hiddenstatuslabel" type="hidden" name="hiddenstatuslabel" runat="server">
        <INPUT id="hiddenuserid" runat="server" type="hidden" NAME="hiddenuserid">&nbsp;
        <INPUT id="hiddenusername" runat="server" type="hidden" NAME="username">
        <INPUT id="hiddencompcode" runat="server" type="hidden" NAME="hiddencompcode">
        <INPUT id="hiddenauto" type="hidden" name="hiddenuserid" runat="server">
        <INPUT id="hiddenpermission" type="hidden" name="hiddenpermission" runat="server">
        <input id="UserLabel" type="hidden" name="UserLabel" runat="server"> 
</body>
</html>
