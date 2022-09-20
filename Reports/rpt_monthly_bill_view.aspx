<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rpt_monthly_bill_view.aspx.cs" Inherits="Reports_rpt_monthly_bill_view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Month Wise Billing Report</title>
   </style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
    	<script type="text/javascript" language="javascript" src="javascript/rpt_monthly.js"></script>

		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
</head>
<body>
   <body>
    <form id="form1" runat="server">
     <table cellpadding = "0" cellspacing = "0" width = "100%">
     <tr>
     <td align="left" style="width: 59px; height: 28px;">
<asp:Button ID="btnprint" runat="server"  Text="Print" />
</td>
</tr>
       

        
      <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr>
        
   </table>
            <input type="hidden" id="hdnunitcode"  runat ="server" name="dateformat"/>
    <input type="hidden" id="hiddendateformat"  runat ="server" name="dateformat"/>
    <input type="hidden" id="hdnunit" runat="server" name="hdnunit"/>
    <input type="hidden" id="hdncompcode" runat="server" name="hdncompcode"/>
    <input type="hidden" id="hdnuserid" runat ="server" name="hdnuserid"/>
    <input type="hidden" id="hdncompname" runat="server" name="hdncompname"/>
    <input type="hidden" id="hdnalert" runat="server" name="hdnalert"/>
    <input type="hidden" runat="server" id="hdn_user_right"/>
    <input type="hidden" id="dateformat"  runat ="server" name="dateformat"/>
    <input type="hidden" id="hdnunitname" runat="server" name="hdnunitname"/>
    <input type="hidden" id="hdnpubtype" runat="server" name="hdnpubtype"/>
    <input type="hidden" id="hdn_agency_type_code" runat="server" name="hdn_agency_type_code"/>
    <input type="hidden" id="hdnagclscode" runat="server" name="hdnagclscode"/>
    <input id="unit_flag" type="hidden" name="unit_flag" runat="server" />
        <input id="Hiddenbranchcode" type="hidden" name="Hiddenbranchcode" runat="server" />
    </form>
</body>
</html>