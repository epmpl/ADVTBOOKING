<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADV_Page_Reservation_Rpt_View.aspx.cs" Inherits="ADV_Page_Reservation_Rpt_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    	    
		    <link href="css/report.css" rel="stylesheet" type="text/css" />
				<script type="text/javascript" language="javascript" src="javascript/ad_rep_roapproval_detail.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .LabelText
        {
            font-family: Trebuchet MS;
            color: Black;
            text-align: right;
            height: 11px;
            font-size: small;
            height: 13px;
            width: 150px;
        }
        
        .Textfield
        {
            border: 1px solid #929292;
            background-color: #ffffff;
            font-family: verdana;
            font-size: 10px;
            color: #000000;
            text-transform: uppercase;
        }
        
        .DrpTextfield
        {
            border: 1px solid #929292;
            background-color: #ffffff;
            font-family: verdana;
            font-size: 10px;
            color: #000000;
            height: 17px;
            width: 200px;
            text-transform: uppercase;
        }
        .auto-style1 {
            width: 135px;
        }
        .btextforbook {}
        .auto-style2 {
            width: 171px;
        }
        .auto-style3 {
            width: 242px;
        }
        .auto-style4 {
            width: 171px;
            height: 15px;
        }
        .auto-style5 {
            width: 242px;
            height: 15px;
        }
        .auto-style6 {
            width: 135px;
            height: 15px;
        }
        .auto-style7 {
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     
          <table cellpadding = "0" cellspacing = "0" width = "100%">
     <tr valign="top">
		      <td style="width:180px; height:40px;display:none"  >
		         <asp:button id="btnPrint" runat="server" Height="24px" Font-Bold="True" Text="Print" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button>
		      </td></tr>
      <tr>
            <td width = "100%" id = "report" runat = "server" valign = "top" height = "23px"></td>
       </tr>
   </table>
         
    <input type="hidden" runat="server" id="hdncompcode" />
    <input type="hidden" runat="server" id="hdncompname" />
    <input type="hidden" runat="server" id="hdnunitcd" />
    <input type="hidden" runat="server" id="hdnunitnm" />
    <input type="hidden" runat="server" id="hdnbrancd" />
    <input type="hidden" runat="server" id="hdnbrannm" />
    <input type="hidden" runat="server" id="hdnusernm" />
    <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hiddendateformat" />
    <input type="hidden" runat="server" id="hdnunitcode" />
    <input type="hidden" runat="server" id="hdnbranccode" />
    <input type="hidden" runat="server" id="hdnusercode" />
    <input type="hidden" runat="server" id="hdntransid" />
        <input type="hidden" runat="server" id="hdnrefbookingid" />
         <input type="hidden" runat="server" id="hdnrefflag" />
    </form>
</body>
</html>
