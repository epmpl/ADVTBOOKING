<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductCategory.aspx.cs" EnableEventValidation="false"  Inherits="ProductCategory" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Product Category Master</title>
    
	<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
	<meta name="CODE_LANGUAGE" content="C#"/>
	<meta name="vs_defaultClientScript" content="JavaScript"/>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>	
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/productcategory.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
	<script language="javascript" type="text/ecmascript">
	function capsCode()
	{
	     document.getElementById('txtproductcode').value=trim(document.getElementById('txtproductcode').value.toUpperCase());
	}
	function capsAlias()
	{
	    document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value.toUpperCase());
	}
	</script>

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/webcontrol.css" type="text/css" rel="stylesheet">
</head>
<body onload="javascript:return blankcat();"  onkeydown="javascript:return tabvalue(event,'txtalias');" onkeypress="javascript:return eventcalling(event);" style="background-color:#f3f6fd;">
   <form id="bdy" method="post" runat="server" cellpadding="0" cellspacing="0" align="center">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
			<%--<table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="Product Category Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                    
                    </td>
					<td valign="top" style="width: 785px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">--%>

       
             <table id="OuterTable" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Box Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					<td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
							<td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  OnClick="btnNew_Click1" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
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
					</td> </tr> 
				
				
			</table>
			
			</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Product Category </center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table align="center" class="styl2"  >
							<tr>
								<td><asp:label id="lbindustry" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate><asp:DropDownList  id="drpindustry" runat="server" CssClass="dropdowns" MaxLength="8" Enabled="False"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td>
							</tr>
							<tr>
								<td><asp:label id="lbproductcat" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtproductcode" runat="server" CssClass="btext1" MaxLength="8" Enabled="False"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
							</tr>
							<tr>
								<td><asp:label id="lbproddesc" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtprodesc" runat="server" CssClass="btext" MaxLength="25" Enabled="False" AutoPostBack="True"></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
							</tr>
							<tr>
								<td><asp:label id="laalias" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><asp:textbox  onkeypress="return ClientSpecialchar(event);" id="txtalias" runat="server" CssClass="btext" MaxLength="25" Enabled="False" ></asp:textbox></ContentTemplate></asp:UpdatePanel></td>
							</tr>
							
							
							
						</table>
			<input id="hiddencompcode" type="hidden" size="14" runat="server" name="hiddencompcode"/>
			<input id="hiddenuserid" type="hidden" size="17" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<asp:Label ID="d1" runat="server"></asp:Label>
		<asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><input id="query" type="hidden" runat ="server" style="width: 14px" />
            <input id="pnew" type="hidden" runat ="server" style="width: 12px" />
            <input id="save" type="hidden" runat ="server" style="width: 17px" />
            <input id="modify" type="hidden" runat ="server" style="width: 21px" />
            <input id="ip1" type="hidden" name="ip1" runat="server" />
                <input id="hiddenchkprodname" type="hidden" name="hiddenchkprodname" runat="server" />
        </ContentTemplate></asp:UpdatePanel>
			
		</form>
	</body>
</html>
