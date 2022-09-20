<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdCat4.aspx.cs" Inherits="AdCat4" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
         <title>AdCategory</title>
         <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		
		
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Adcat4.js"></script>
		<%--<script type="text/javascript" language="javascript" src="javascript/adcat3.js"></script>--%>
		</head>
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/stab.css" type="text/css" rel="stylesheet" />
       <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />


<body onkeypress="eventcalling(event);"onkeydown="tabvalue(event,'txtalias');"onload="javascript:return clearadcat4();" style="background-color:#f3f6fd;">
      <form id="frmcat3" method="post" runat="server">
    			<%--<table id="OuterTable" width="980" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Sub Category4 Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 179px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">--%>
           <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Sub Category4 Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
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
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Ad Sub Category4</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  class="addsubcat4" cellpadding="0" cellspacing="0" >
									<tr>
									       <td style="height: 18px">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
									        <td style="height: 18px">
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdownaddsubcat4" 
                                                                 ></asp:DropDownList>
                                                               </td>
									</tr> <tr>
                                                        
                                                       <td align="left">
                                                           <asp:label id="adcat1" runat="server" CssClass="TextField"></asp:label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePaneJ7" runat="server">
                                                                <ContentTemplate>--%><asp:dropdownlist id="drpadcategory" runat="server" CssClass="dropdownaddsubcat4"></asp:dropdownlist>
                                                        </td>
                                                        
                                                       </tr>
									<tr>
									       <td><asp:label id="adcat2" runat="server" CssClass="TextField"></asp:label></td>
									        <td><asp:dropdownlist id="drpadsubcategory" runat="server" CssClass="dropdownaddsubcat4" ></asp:dropdownlist></td>
									</tr>
									<tr>
									       <td><asp:label id="AdCategoryName" runat="server" CssClass="TextField"></asp:label></td>
									        <td><asp:dropdownlist id="drpadvcatcode" runat="server" CssClass="dropdownaddsubcat4"></asp:dropdownlist></td>
									</tr>
										<tr>
										    <td><asp:label id="AdCatCode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtadcatcode" runat="server" CssClass="btext1" MaxLength="8"></asp:textbox></td>
											
										</tr>
										<tr>
											<td><asp:label id="AdCatName" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtadcatname" runat="server" CssClass="btext" MaxLength="50"></asp:textbox></td>
													
										</tr>
										<tr>
											<td style="height: 19px"><asp:label id="Alias" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px"><asp:textbox id="txtalias" runat="server" CssClass="btext"	MaxLength="50"></asp:textbox></td>
										</tr>
									</table>
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		<input id="ip1" type="hidden" name="ip1" runat="server" />
    
    </form>
</body>
</html>