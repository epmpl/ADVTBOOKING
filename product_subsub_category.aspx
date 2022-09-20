<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_subsub_category.aspx.cs" EnableEventValidation="false" Inherits="product_subsub_category" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Product Sub Sub Category</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/product_subsub_category.js"></script>
    	<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
				<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
</head>
<body id =bdy onload="javascript:return givebuttonpermission('product_subsub_category');"  onkeydown="javascript:return tabvalue(event,'txtalias');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
    <form id="form1" runat="server">
     <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Product Sub Sub Category Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                 
					<td valign="top">
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
						<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Product Sub Sub Cat</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
						<table  cellpadding="0" cellspacing="0" border="0" style="width:auto;margin:30px 300px;">
				        <tr>
				           <td><asp:Label ID ="lbproductdescription" runat ="server" CssClass ="TextField"></asp:Label></td>
				           <td><asp:UpdatePanel ID="Update1" runat ="server"><ContentTemplate><asp:DropDownList ID="drpproduct" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="drpproduct_SelectedIndexChanged"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
				        
				           
				        </tr>
				        
				        <tr>
				           <td><asp:Label ID ="lbprosubdeccription" runat ="server" CssClass ="TextField"></asp:Label></td>
				           <td><asp:UpdatePanel ID="UpdatePanel2" runat ="server"><ContentTemplate>
				           <asp:DropDownList ID="drpsubproduct" runat="server" CssClass="dropdown" Enabled="False"  >
				           <asp:ListItem Selected="True"  Value="0">--Select Sub Product--</asp:ListItem>
				           
				           </asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
				        
				        </tr>
				        <tr>
				          <td><asp:Label ID="lbprosubsubcode" runat ="server" CssClass ="TextField"></asp:Label> </td>
				          <td><asp:UpdatePanel ID="Update2" runat ="server" ><ContentTemplate><asp:TextBox ID="txtprosubsubcode" runat="server" CssClass="btext1" MaxLength="8" OnTextChanged="txtprosubsubcode_TextChanged"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
				        
				        </tr>
				        <tr>
				           <td><asp:Label ID="lbsubsubprodes" runat ="server" CssClass="TextField"></asp:Label> </td>
				           <td><asp:UpdatePanel ID ="Update3" runat="server"><ContentTemplate><asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txtprosubsubname" runat="server" CssClass ="btext" MaxLength="30" AutoPostBack="True"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
				        
				        </tr>
				        <tr>
				          <td><asp:Label ID="lbalias" runat ="server" CssClass="TextField"></asp:Label></td>
				          <td><asp:UpdatePanel ID="Update4" runat="server"><ContentTemplate><asp:TextBox onkeypress="return ClientSpecialchar(event);" ID ="txtalias" runat="server" CssClass="btext" MaxLength="30"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
				        
				        </tr>
				
				
				        </table>
			<input id="hiddencompcode" type="hidden" size="14" runat="server" name="hiddencompcode"/>
			<input id="hiddenuserid" type="hidden" size="17" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			
			<input id="hidedrpproduct" type="hidden" size="14" runat="server" />
			<input id="hidedrpsubproduct" type="hidden" size="17" runat="server" />
			<input id="hidsubsubcode" type="hidden" size="1"  runat="server" />
			<input id="hidesubsubname" type="hidden"  runat="server" />
			<input id="hidesubsubalias" type="hidden"  runat="server" />
			
			<asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><input id="query" type="hidden" runat ="server" /></ContentTemplate></asp:UpdatePanel> 
    </form>
</body>
</html>
