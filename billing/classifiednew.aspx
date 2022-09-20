<%@ Page Language="C#" AutoEventWireup="true" CodeFile="classifiednew.aspx.cs" Inherits="classifiednew" %>
<%@ register TagPrefix="uc3" TagName="classifiedcontrol" Src="~/billing/classifiedcontrol.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillrepunebillre" Src="~/billing/punebillre.ascx"%>
<%@ register TagPrefix="uc3" TagName="prahhar_classified_re" Src="~/billing/prahhar_classified_re.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillclassi_re" Src="~/billing/punebillclassi_re.ascx"%>
<%@ register TagPrefix="uc3" TagName="billformat_classified" Src="~/billing/billformat_classified.ascx"%>
<%@ register TagPrefix="uc3" TagName="RCB1" Src="~/billing/RCB1.ascx"%>
<%@ register TagPrefix="uc31" TagName="udavanibill" Src="~/billing/udayvani_bill_classi.ascx"%>
<%@ register TagPrefix="uc3" TagName="billing_sea_controlclassified" Src="sea_controlclassified.ascx"%>
<%@ register TagPrefix="uc3" TagName="bill_haribhoomi_classified" Src="bill_haribhoomi_classified.ascx"%>
<%@ register TagPrefix="uc3" TagName="bill_format" Src="bill_format.ascx"%>
<%@ register TagPrefix="uc3" TagName="haribhoomi_billnew1" Src="haribhoomi_billnew1.ascx"%>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Invoice Classified</title>
    <script type="text/javascript"  language="javascript" src="javascript/printbutton.js"></script>
    
  
</head>
<body oncopy="return false;" onpaste="return false;">
   
		<form id="Form1" method="post" runat="server">
           <%-- <table style="WIDTH: 245px; HEIGHT: 48px">
				<tr>
				</tr>
				<tr>--%>
					<%--<td>--%><asp:Button id="lblprint" Runat="server"  Visible ="false"  ></asp:Button><asp:placeholder id="placeholder1" Runat="server"></asp:placeholder><%--</td>--%>
			<%--	</tr>
			</table>
			<table >
			<tr>
				
			</tr>
			</table>--%>
			<%--<div  id="printprogress" runat="server" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;">
			<asp:Label ID="printprog" runat ="server" Text ="Printing On Progress"></asp:Label>
 			
			
			
			</div>--%>
		
		</form>
<input id="hiddendateformat" type="hidden" runat="server" />
				<input id="hiddeninsertion" type="hidden" runat="server" />
</body>
</html>
