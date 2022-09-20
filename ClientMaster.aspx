<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientMaster.aspx.cs" Inherits="ClientMaster" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Client Master</title> 
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/Agencyforclient.js"></script>
		
		<script language="javascript" src="javascript/ClientMaster.js"></script>
		<script language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript" src="javascript/entertotabclient.js"></script>
		<script language="javascript" src="javascript/TreeLibraryforclient.js"></script>
		<script language="javascript">		    ChangeCssss();</script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                width: 102px;
            }
            .style2
            {
                height: 19px;
                width: 122px;
            }
            .style3
            {
                width: 122px;
            }
        </style>
	</HEAD>
	<body  leftMargin="5" id="bdy" topmargin="0" onload="javascript:return blankclient(),loadXML('xml/errorMessage.xml');" onkeydown="javascript:return tabvalue(event,'txtalert');" style="background-color:#f3f6fd;" onkeypress="javascript:return checkfield(event)">



		<form id="Form1" method="post" runat="server">
		<asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
		<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstclient" Width="500px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
		<div id="divclien" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstclien" Width="500px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>  
	<%--	/////////anuja--%>
		<div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="500px"  Height="100px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
		
		 <div id="divgstclty" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstgstclty" Width="500px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Client Master"></uc1:topbar></td>
				</tr>




				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
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
          </td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>
                         Client Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table style=" width:100%;margin:-20px 230px" cellpadding="0" cellspacing="0" >
			    <tr >
					<td >
					    <asp:linkbutton ID="lbClientProductDetail" runat="server" CssClass="btnlink_n" ></asp:linkbutton>
					    <asp:linkbutton id="lbClientContactDetail" runat="server" CssClass="btnlink_n" Font-Underline="False"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="lbStatusDetail" runat="server" CssClass="btnlink_n"></asp:linkbutton>
						<asp:linkbutton id="lbtnClientPaymode" runat="server" CssClass="btnlink_n"></asp:linkbutton>
						<asp:linkbutton id="lbClientExecDetail" runat="server" CssClass="btnlink_n" Text="|Client Executive Detail"></asp:linkbutton>
						<asp:linkbutton id="lbClientBrandDetail" runat="server" CssClass="btnlink_n" Text="|Client Brand Detail"></asp:linkbutton>
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" style="width:auto;margin:35px 300px;">
            
            <tr>
            <td class="style3"><asp:Label ID="lbtype" runat="server"  CssClass="TextField"></asp:Label>
            </td>
            <td>
            <asp:DropDownList ID="drptype" runat="server"  CssClass="dropdown">
                <asp:ListItem Value="P">Parent</asp:ListItem>
                <asp:ListItem Value="C">Child</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:Label ID="lbparent" runat="server" CssClass="TextField" style="display:none"></asp:Label>
            </td>
            <td>
             <asp:TextBox ID="txtparent" runat="server"  CssClass="btext1"  style="display:none" ></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="CustomerCode" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="width: 213px; height: 19px;">
                    <asp:TextBox ID="txtcustcode" runat="server" onpaste="return false;" CssClass="btext1" MaxLength="8" onkeypress="return ClientSpecialchar(event);"></asp:TextBox></td>
                <td style="height: 19px">
                <asp:Label ID="RateGroup" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px; height: 19px;">
                    <asp:DropDownList ID="drprategroup" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
											<td class="style3" >
												<asp:label id="agdesig" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3">
												<asp:textbox id="txtdesg" runat="server"   CssClass="btext_client" MaxLength="50" onkeypress="return special_character(event);" ></asp:textbox></td>
										</tr>
            
            
            <tr>
                <td class="style3">
                    <asp:Label ID="CustomerName" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtcustomername" onpaste="return false;" runat="server" CssClass="btext_client" MaxLength="50" onkeypress="eventcalling(event);javascript:return ClientSpecialcharname(event);" OnBlur ="return Clientchar(event)"></asp:TextBox></td>
                <td>
                </td>
                <td>
                <asp:UpdatePanel ID="up1" runat="server"><ContentTemplate> <asp:Button ID="btnagencyname" runat="server"   CssClass="topbutton" Width="65px" 
                        text="Client Name" /></ContentTemplate></asp:UpdatePanel>






                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Alias" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3" style="height: 19px">
                    <asp:TextBox ID="txtalias" runat="server" CssClass="btext_client" MaxLength="50" onkeypress="javascript:return ClientSpecialcharname(event);" ></asp:TextBox></td>
                <td style="height: 19px">
                </td>
                <td style="height: 19px">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Address1" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtadd1" runat="server" onkeypress="eventcalling(event);" CssClass="btext_client" MaxLength="50"></asp:TextBox></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Street" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtstreet" runat="server" onkeypress="eventcalling(event);" CssClass="btext_client" MaxLength="50"></asp:TextBox></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Country" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px">
                    <asp:DropDownList ID="txtcountry" runat="server" CssClass="dropdown" OnSelectedIndexChanged="txtcountry_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="state" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtstate" runat="server" ReadOnly="True" CssClass="btext1"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="City" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px">
                    <asp:DropDownList ID="drpcity" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">-------Select City-------</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="PinCode" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtpincode" runat="server" CssClass="btext1numeric" MaxLength="12"
                        onkeypress="return ClientisNumber(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="District" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px">
                    <asp:TextBox ID="txtdistrict" runat="server" CssClass="btext1" ReadOnly="True" Enabled="False"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Region" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="drpregion" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">-------Select Region-------</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
            
            <td class="style2">
                    <asp:Label ID="lbltaluka" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="height: 19px">
                    <asp:DropDownList ID="drptaluka" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">-------Select Taluka-------</asp:ListItem>
                    </asp:DropDownList></td>
                
                <td style="height: 19px">
                    <asp:Label ID="Zone" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="height: 19px">
                    <asp:DropDownList ID="drpzone" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">-------Select Zone-------</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
            <td class="style2">
                    <asp:Label ID="Phone" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px; height: 19px;">
                    <asp:TextBox ID="txtphone1" onpaste="return false;" style="text-align:right" runat="server" CssClass="btextsmallphone" MaxLength="4" onkeypress="return ClientisNumber(event)"></asp:TextBox><asp:TextBox ID="txtphone2" onpaste="return false;" style="text-align:right" runat="server" CssClass="btextsmall"
                            MaxLength="19" onkeypress="return ClientisNumberforcompany(event);"></asp:TextBox></td>
                
                <td style="height: 19px">
                    <asp:Label ID="EmailId" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtemailid" runat="server" CssClass="btextmail" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
            <td class="style2">
                    <asp:Label ID="Fax" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px; height: 19px;">
                    <asp:TextBox ID="txtfax" onpaste="return false;" runat="server" CssClass="btext1numeric" MaxLength="30"
                        onkeypress="return numeric(event)"></asp:TextBox></td>
                
                <td>
                    <asp:Label ID="NoofVTS" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtvts" onpaste="return false;" runat="server" CssClass="btext1numeric" MaxLength="20" onkeypress="return ClientisNumber(event)"></asp:TextBox></td>
            </tr>
            <tr>
            <td class="style3">
                    <asp:Label ID="URL" runat="server" CssClass="TextField" ></asp:Label></td>
                <td colspan="" style="width: 213px">
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="btext1" MaxLength="30" onkeypress="eventcalling(event);"></asp:TextBox></td>
                
                <td>
                    <asp:Label ID="ServiceTaxAcNo" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtservicetax" onpaste="return false;" runat="server" CssClass="btext1numeric" MaxLength="30" onkeypress="return ClientisNumber(event)"></asp:TextBox></td>
            </tr>
            <tr>
            
            <td class="style3">
                    <asp:Label ID="PAN" runat="server" CssClass="TextField" ></asp:Label></td>
                <td colspan="" style="width: 213px">
                    <asp:TextBox ID="txtPan" runat="server" CssClass="btext1numeric" MaxLength="30"
                     onkeypress="return ClientPanchar(event)" ></asp:TextBox></td><!---->
                <td>
                    <asp:Label ID="CreditDays" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px">
                    <asp:TextBox ID="txtcreditdays" runat="server"  onpaste="return false;" CssClass="btext1numeric" MaxLength="4"
                        onkeypress="return ClientisNumber(event)"></asp:TextBox></td>
                </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lbcliencat" runat="server" CssClass="TextField"></asp:Label></td>
                                <td colspan="1" style="width: 213px">
                                    <asp:DropDownList ID="drpclientcat" runat="server" CssClass="dropdown" Enabled="False">
                                    </asp:DropDownList></td>
                                <td>
                    <asp:Label ID="Creditlimit" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtcrlimit" onpaste="return false;" runat="server" CssClass="btext1numeric" MaxLength="6" onkeypress="return ClientisNumber(event)"></asp:TextBox></td>
            
                            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Status" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px">
                    <asp:TextBox ID="txtstatus1" runat="server" CssClass="btext1" MaxLength="20"></asp:TextBox></td>
                <td>
                    <asp:Label ID="StatusDate" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtstatusdate" runat="server" CssClass="btext1" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="StatusReason" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtstatusreason" runat="server" CssClass="btext_client" MaxLength="200" onkeypress="eventcalling(event);"
                        OnBlur="return ClientSpecialchar(event)"></asp:TextBox></td>
                <td>
                </td>
                <td style="width: 3px">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Alert" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtalert" runat="server" CssClass="btext_client" MaxLength="200" OnBlur="return ClientSpecialchar(event)" onkeypress="eventcalling(event);" ></asp:TextBox></td>
                <td>
                </td>
                <td style="width: 3px">
                </td>
            </tr>
            <tr>
            <td class="style2">
                    <asp:Label ID="lbldiscount" runat="server" CssClass="TextField">Discount</asp:Label></td>
                <td style="width: 213px; height: 19px;">
                    <asp:DropDownList  ID="drpdiscount" runat="server"  CssClass="dropdown"  enable="true">
                    <asp:ListItem Text="--Select Discount--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                    <asp:ListItem Text="Percentage" Value="P"></asp:ListItem></asp:DropDownList></td>
                    
                    <td style="height: 19px">
                    <asp:Label ID="lblamount" runat="server" CssClass="TextField">Amount</asp:Label></td>
                <td style="width: 213px; height: 19px;">
                <asp:TextBox ID="txtamount" CssClass="btext1" runat="server"></asp:TextBox></td>
                
            </tr>
            <tr>
            <td class="style2">
                    <asp:Label ID="lblffdis" runat="server" CssClass="TextField">Flat Frequency Dis.</asp:Label></td>
                <td style="width: 213px; height: 19px;">
                    <asp:DropDownList  ID="drpffdis" runat="server"  CssClass="dropdown"  enable="true">
                    <asp:ListItem Text="--Select Flat Frequency Discount--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                    <asp:ListItem Text="Percentage" Value="P"></asp:ListItem></asp:DropDownList></td>
                    
                    <td style="height: 19px">
                    <asp:Label ID="lblffdisc" runat="server" CssClass="TextField">Flat Frequency Amount</asp:Label></td>
                <td style="width: 213px; height: 19px;">
                <asp:TextBox ID="txtffdisc" CssClass="btext1" runat="server"></asp:TextBox></td>
            </tr>
            
            <tr>
            <td class="style2">
                    <asp:Label ID="lblcadis" runat="server" CssClass="TextField">Cash Discount</asp:Label></td>
                <td style="width: 213px; height: 19px;">
                    <asp:DropDownList  ID="drpcsdis" runat="server"  CssClass="dropdown"  enable="true">
                    <asp:ListItem Text="--Select Cash Discount--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                    <asp:ListItem Text="Percentage" Value="P"></asp:ListItem></asp:DropDownList></td>
                    
                     <td style="height: 19px">
                    <asp:Label ID="lblcsdisc" runat="server" CssClass="TextField">Cash Amount</asp:Label></td>
                <td style="width: 213px; height: 19px;">
                <asp:TextBox ID="txtcsdisc" CssClass="btext1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            <td class="style2">
                <asp:Label ID="lbclinttype" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="" style="width: 213px; height: 19px;">
                    <asp:DropDownList ID="drpclinttype" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
               
    
                  <td>
            <asp:Label ID="lboldclientcode" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="txtclientcode" runat="server" CssClass="btext1"></asp:TextBox>
            </td>
                </tr>
                <tr>
            <td class="style2">
                    <asp:Label ID="lbagencycode" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="width: 213px; height: 19px;">
                    <asp:TextBox ID="txtagencycode" runat="server"  CssClass="btext1"  enable="false"></asp:TextBox></td>
                <td align="left" ><asp:Label id="Label3" runat="server" CssClass="TextField" >Branch</asp:Label></td>
                <td align="left"><asp:DropDownList CssClass="dropdown" id="drpbranch" runat="server" ></asp:DropDownList></td>  
 
            </tr>

                <tr>
                     <td class="style3"><asp:Label ID="lblgstatus" runat="server" CssClass="TextField" Text="Gst Applicable"></asp:Label></td>
										<td class="style10"><asp:DropDownList ID="drpgstatus" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList></td>
												<td class="style3"><asp:Label ID="lblgstus" runat="server" CssClass="TextField"></asp:Label></td>
										<td><asp:DropDownList ID="drpgstus" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Registered</asp:ListItem>
                                            <asp:ListItem Value="N">Unregistered</asp:ListItem>
                                            </asp:DropDownList></td>
                                            <%--//////////////////add by anuja for security lokmat/////////////--%>
                                            
										</tr>

                
                                              <tr>
                                            <td><asp:label id="lblarnno" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtarno" runat="server" CssClass="btext" MaxLength="15" Width="141px" ></asp:textbox></td>
                                            <td><asp:label id="lblgstprovid" runat="server" CssClass="TextField" ></asp:label></td>
											<td><asp:textbox id="txtgstprovid" runat="server" CssClass="btext"  MaxLength="15" Width="141px"></asp:textbox>
                                                											</td>
                                            
                                        </tr>
                                        <tr>
                                            <td><asp:label id="lblgst" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtgstin" runat="server" CssClass="btext1"  MaxLength="15"></asp:textbox></td>
                                             <td><asp:label id="lblgstdt" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtgstdt" runat="server"  ></asp:textbox>
                                                <img alt="Calender"  src='Images/cal1.gif'  id="Img2" onclick='popUpCalendar(this, Form1.txtgstdt, "mm/dd/yyyy")' onfocus="abc()" height="14" width="14"/>
											</td>

                                        </tr>

                   <tr>
                                            <td><asp:label id="lblgstclty" runat="server" CssClass="TextField" ></asp:label></td>
											<td><asp:textbox id="txtgstclty" runat="server" CssClass="btext" Width="137px" ></asp:textbox></td>
                                            <td><asp:label id="lblgsteftvdt" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtgsteftdt" runat="server"  ></asp:textbox>
                                                <img alt="Calender"  src='Images/cal1.gif'  id="Img3" onclick='popUpCalendar(this, Form1.txtgsteftdt, "mm/dd/yyyy")' onfocus="abc()" height="14" width="14"/>
											</td>
                                        </tr>
            
            <tr>
            <td  colspan="3" align="RIGHT"><asp:Button ID="btnshowremark" Text="Remark Detail" Width="120px" runat="server" Enabled="false" /></td>
            </tr>
            
            
            
            
            
        </table>
        <div id="Divgrid1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0; background-color:White; overflow:auto; width:445px; height:390px"  runat="server" >
       
										<table id="Table3" style="WIDTH: 435px; HEIGHT: 268px" align="center">
											<tr>
												  <td runat="server" id="view19" padding-left="10px" align="center" valign="top" class="style1">
												
														</td>
											</tr>
											
										</table>
										  <table cellpadding="0" cellspacing="0" id="pagingtab" runat="server" width="250px" style="display:none;padding-left:6px;">
                     <tr>
                          <td id="prepage" colspan="3" runat="server" onclick="javascript:return pageprev(this.value);" class="previousPage1">Previous</td>
                           <td id="next1" colspan='0' runat="server" class="style4" ></td>
                        <td id="nextpage" class ="nextpage" runat="server" width="10px" onclick="javascript:return pagenext(this.value);">Next</td>
               </tr>
                       </table>
                       
                         <asp:Button ID="Button1" runat="server"   CssClass="topbutton" Width="40px" 
                        text="Close"   />
									</div>
      
			<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/> 
			<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
			<input id="hiddenusername" type="hidden" name="username" runat="server" onserverchange="hiddenusername_ServerChange"/> 
			<input id="modify" type="hidden" name="modify" runat="server"/>
			<input id="hiddencitycode" type="hidden" name="hiddencitycode" runat="server"/> 
			<input id="userid2" type="hidden" name="userid2" runat="server"/>
			<input id="hiddencompcode" type="hidden" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenauto" runat="server"/>
			<input id="hiddenrate" type="hidden" name="hiddenrate" runat="server"/>
			<input id="hiddencont" type="hidden" name="hiddencont" runat="server"/>
			<input id="hiddenquery" type="hidden" name="hiddencont" runat="server"/>
            <input id="hiddenclientbook" type="hidden" name="hiddencont" runat="server" style="width: 32px"/>
            <input id="hiddenbookclientname" type="hidden" name="hiddencont" runat="server" style="width: 32px"/>
            <input id="hiddenagency" type="hidden" name="hiddencont" runat="server" style="width: 32px"/>
               <input id="hiddenbookclientname1" type="hidden" name="hiddencont" runat="server" style="width: 32px"/>
               <input id="hiddenagency_uer" type="hidden" name="hiddencont" runat="server" style="width: 32px"/>
               <input id="ip1" type="hidden" name="ip1" runat="server" />
               <input id="hdnmobiledetail" runat="server" name="hiddendelsau" size="1" type="hidden" />	
<%--
               /////////////////////anuja--%>
                     <input id="hdnagencyclientflag" runat="server" name="hiddendelsau" type="hidden" />	

            
			<input id="hdngstclty" type="hidden" name="hidkyc" runat="server"/>
           <input id="hiddencenter" type="hidden" name="hiddencenter" runat="server" />
             <input id="hiddenstatecode" type="hidden" name="hiddendistcode" runat="server" />
             
               
		</form>
		
	</body>
</HTML>

