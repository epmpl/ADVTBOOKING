<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pdf_insertion.aspx.cs" Inherits="pdf_insertion" %>
<%@ register TagPrefix="uc3" TagName="testcontrolsambad" Src="~/billing/testcontrolsambad.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillre" Src="~/billing/punebillre.ascx"%>
<%@ register TagPrefix="uc3" TagName="prhaarre" Src="~/billing/prhaarre.ascx"%>
<%@ register TagPrefix="uc1" TagName="udavani" Src="~/billing/udayvani_bill.ascx"%>
<%@ register TagPrefix="uc1" TagName="pratidinbill" Src="~/billing/pratidinbill.ascx"%>
<%@ register TagPrefix="magzin" TagName="Abp_bill" Src="~/billing/Abp_bill.ascx"%>
<%@ Register TagPrefix="pratidinbill_f" TagName="pratidinbill_f" Src="~/billing/pratidinbill_f.ascx"%>
<%@ Register TagPrefix="kannad_prabha_pdf" TagName="kannad_prabha_pdf" Src="~/billing/kannad_prabha_pdf.ascx"%>
<%@ Reference Control="~/billing/pratidinbill_f.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
  
		<form id="Form1" method="post" runat="server">
			<table >			
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
</html>
