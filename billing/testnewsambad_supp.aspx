<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testnewsambad_supp.aspx.cs" Inherits="testnewsambad_supp" %>
<%@ register TagPrefix="uc3" TagName="testcontrolsambad_supp" Src="~/billing/sambad_supp.ascx"%>
<%@ register TagPrefix="uc3" TagName="testcontrolsambad" Src="~/billing/testcontrolsambad.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillre" Src="~/billing/punebillre.ascx"%>
<%@ register TagPrefix="uc3" TagName="prhaarre" Src="~/billing/prhaarre.ascx"%>
<%@ register TagPrefix="uc1" TagName="udavani" Src="~/billing/udayvani_bill.ascx"%>
<%@ register TagPrefix="uc1" TagName="pratidinbill" Src="~/billing/pratidinbill_supp.ascx"%>
<%@ register TagPrefix="magzin" TagName="Abp_bill" Src="~/billing/Abp_bill.ascx"%>
<%@ register TagPrefix="magzin" TagName="Abp_bill_pre" Src="~/billing/Abp_bill_pre.ascx"%>
<%@ Register TagPrefix="pratidinbill_f_supp" TagName="pratidinbill_f_supp" Src="~/billing/pratidinbill_f_supp.ascx"%>
<%@ Reference Control="~/billing/pratidinbill_f.ascx" %>
<%@ register TagPrefix="kannad_prabha" TagName="kannad_prabha" Src="~/billing/kannad_prabha.ascx"%>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Invoice</title>
</head>
<body>
    <body >
		<form id="Form1" method="post" runat="server">
			<table style="WIDTH: 245px; HEIGHT: 48px">
				
				<tr>
					<td><asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
				</tr>
			</table>
			<table >
			<tr>
				<td><input id="hiddendateformat" type="hidden" runat="server" /></td>
				<td><input id="hiddeninsertion" type="hidden" runat="server" /></td>
			</tr>
			</table>
		
		
		</form>
	</body>
</body>
</html>

