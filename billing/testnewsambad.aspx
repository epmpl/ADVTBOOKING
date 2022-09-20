<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testnewsambad.aspx.cs" Inherits="testnewsambad" %>
<%@ register TagPrefix="uc3" TagName="testcontrolsambad" Src="~/billing/testcontrolsambad.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillre" Src="~/billing/punebillre.ascx"%>
<%@ register TagPrefix="uc3" TagName="prhaarre" Src="~/billing/prhaarre.ascx"%>
<%@ register TagPrefix="uc1" TagName="udavani" Src="~/billing/udayvani_bill.ascx"%>
<%@ register TagPrefix="uc1" TagName="pratidinbill" Src="~/billing/pratidinbill.ascx"%>
<%@ register TagPrefix="magzin" TagName="Abp_bill" Src="~/billing/Abp_bill.ascx"%>
<%@ register TagPrefix="magzin" TagName="Abp_bill_pre" Src="~/billing/Abp_bill_pre.ascx"%>
<%@ Register TagPrefix="pratidinbill_f" TagName="pratidinbill_f" Src="~/billing/pratidinbill_f.ascx"%>
<%@ Reference Control="~/billing/pratidinbill_f.ascx" %>
<%@ register TagPrefix="vigilant_media" TagName="vigilant_media" Src="~/billing/vigilant_media.ascx"%>
<%@ register TagPrefix="kannad_prabha" TagName="kannad_prabha" Src="~/billing/kannad_prabha.ascx"%>
<%@ register TagPrefix="kannad_prabha" TagName="vision_group" Src="~/billing/vision_group.ascx"%>
<%@ register TagPrefix="arapmedia_bill" TagName="arapmedia_bill" Src="~/billing/arapmedia_bill.ascx"%>
<%@ register TagPrefix="haribhoomi" TagName="haribhoomi" Src="~/billing/haribhoomi_bill.ascx"%>
<%@ register TagPrefix="daniksaweral" TagName="daniksaweral" Src="~/billing/daniksaweral.ascx"%>
<%@ register TagPrefix="RP" TagName="RP" Src="~/billing/RP_bill.ascx"%>
<%@ register TagPrefix="RPC" TagName="RPC" Src="~/billing/RP_bill_combined.ascx"%>
<%@ register TagPrefix="haribhoomi1" TagName="haribhoomi1" Src="~/billing/haribhoomi_display.ascx"%>

<%@ register TagPrefix="haribhoomi1_gst" TagName="haribhoomi1_gst" Src="~/billing/haribhoomi_display_gst.ascx"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Invoice</title>
    
  </head>
<body>
  
		<form id="Form1"  runat="server">
			<%--<table valign="top" >
				<tr>
					<td valign="top"><asp:Button id="lblprint" Runat="server"  Visible ="false"  ></asp:Button>--%>
					<asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
				<%--</tr>
			</table>--%>
					</form>
	<input id="hiddendateformat" type="hidden" runat="server" />
				<input id="hiddeninsertion" type="hidden" runat="server" />
</body>
</html>
