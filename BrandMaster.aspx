<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrandMaster.aspx.cs" Inherits="BrandMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title> Brand Master </title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="C#" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/BrandMaster.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
			
</head>
<body id="bdy" onload="javascript:return givebuttonpermission('BrandMaster');"  onkeydown="javascript:return tabvalue(event,'txtbrandalias');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;"><%--document.getElementById('btnnew').focus();--%>


    <form id="form1" runat="server" >
    <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Brand Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                 
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" >
							<tr valign="top">
					<td> <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        <asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnNew_Click1" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnModify_Click" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnQuery_Click1" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExecute_Click" ></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnCancel_Click1" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnfirst_Click" ></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnprevious_Click" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnnext_Click" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnlast_Click" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnDelete_Click" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExit_Click" ></asp:ImageButton></ContentTemplate></asp:UpdatePanel>
					</td>
				</tr>
				
						</table> 
						</td>
						</tr>
						</table>
						<table border="0" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Brand Master </center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:770px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
						<table  align="center" cellpadding="0" cellspacing="0" border="0">
				        <tr>
        			        <td><asp:Label ID ="lbproductcategory" runat ="server" CssClass ="TextField"></asp:Label></td>
		                   <td><asp:UpdatePanel ID="UpdatePanel2" runat ="server"><ContentTemplate><asp:DropDownList ID="dpdproductcategory" runat="server" CssClass="dropdown" OnSelectedIndexChanged="dpdproductcategory_SelectedIndexChanged"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>

				        </tr>
				        <tr>
    				       <td><asp:Label ID ="lbproductsubcategory" runat ="server" CssClass ="TextField" Visible="False"></asp:Label></td>
				           <td><asp:UpdatePanel ID="UpdatePanel3" runat ="server"><ContentTemplate><asp:DropDownList ID="dpdproductsubcategory" runat="server" CssClass="dropdown" OnSelectedIndexChanged="dpdproductsubcategory_SelectedIndexChanged" AutoPostBack="True" Visible="False">
                               <asp:ListItem Selected="True" Value="0">-Select Sub Category-</asp:ListItem>
                           </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>

				        </tr>
				        <tr>
				           <td><asp:Label ID ="lbproductdescription" runat ="server" CssClass ="TextField" Visible="False"></asp:Label></td>
				           <td><asp:UpdatePanel ID="Update1" runat ="server"><ContentTemplate><asp:DropDownList ID="drpproduct" runat="server" CssClass="dropdown" Visible="False">
                               <asp:ListItem Selected="True" Value="0">--Select Product Name--</asp:ListItem>
                           </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
				        
				        </tr>
				        <tr>
				          <td><asp:Label ID="lbbrandcode" runat ="server" CssClass ="TextField"></asp:Label> </td>
				          <td><asp:UpdatePanel ID="Update2" runat ="server" ><ContentTemplate><asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txtbrandcode" runat="server" CssClass="btext1" MaxLength="8"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
				        
				        </tr>
				        <tr>
				           <td><asp:Label ID="lbbrandname" runat ="server" CssClass="TextField"></asp:Label> </td>
				           <td><asp:UpdatePanel ID ="Update3" runat="server"><ContentTemplate><asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txtbrandname" runat="server" CssClass ="btext" MaxLength="25"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
				        
				        </tr>
				        <tr>
				          <td><asp:Label ID="lbbrandalias" runat ="server" CssClass="TextField"></asp:Label></td>
				          <td><asp:UpdatePanel ID="Update4" runat="server"><ContentTemplate><asp:TextBox onkeypress="return ClientSpecialchar(event);" ID ="txtbrandalias" runat="server" CssClass="btext" MaxLength="25"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
				        
				        </tr>
				
				
				        </table>
						<input id="hiddencompcode" type="hidden" size="14" runat="server" name="hiddencompcode"/>
			<input id="hiddenuserid" type="hidden" size="17" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			
			<input id="hiddendrpproduct" type="hidden" runat="server" />
			<input id="hiddensubprocode" type="hidden"  runat="server" />
			<input id="hiddensubproname" type="hidden" size="1"  runat="server" />
			<input id="hiddensubproalias" type="hidden"  runat="server" />
			<asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><input id="pnew" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> 
						
						
    </form>
</body>
</html>
