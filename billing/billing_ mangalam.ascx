<%@ Control Language="C#" AutoEventWireup="true" CodeFile="billing_ mangalam.ascx.cs" Inherits="billing__mangalam" %>
<link href="css/mangalam_bill.css" type="text/css" rel="Stylesheet" />

<head><title>MANGALAM BILL </title><script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>
    <style type="text/css">
        .style1
        {
            border-bottom:thin solid;
            border-left:thin solid;
        }
        .style2
        {
         border-bottom:thin solid;
        }
        .style3
        {
        border-left:thin solid;
        }
    </style>
</head>
<p  id="P1" style="page-break-after:always;border:solid 1px black;width:660px;">
<table border="0" width="660px">
<tr>
                <td colspan="2">
                        <table  border="1"  cellpadding="0" cellspacing="0" width="660px">
                        <tr>
                        <td style="font-size:x-large;font-family:Arial;background-color:Gray;">

                        <b>MANGALAM PUBLICATION (I) PVT LTD</b>

                        </td>
                        </tr>
                        </table>

                </td>
</tr>
<tr>
                <td align="center" style="font:Arial 13px;" colspan="2">

                <b>ADERTISEMENT BILL-MANGALAM DAILY</b>


                </td>
</tr>

<tr>
                <td style="width:330px;">

                        <table>
                        <tr>

                        <td>

                        To;
                        </td>

                        </tr>
                        </table>


                </td>
                <td style="width:330px;">
                <table width="330px" border="0" cellpadding="0" cellspacing="0" >
                        <tr>
                                <td>
                                <asp:Label ID="lblbillno" runat="server"  CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="txtbillno" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="lbldate" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="txtbilldate" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                        </tr>
                        <tr style="background-color:Gray;">
                                <td style="height: 19px">
                                <asp:Label ID="lblrono" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                <asp:Label ID="txtrono" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                <asp:Label ID="lblrodate" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                <asp:Label ID="txtrodate" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                                 <td>
                                <asp:Label ID="lblterms" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="txttermspay" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                </td>
                        </tr>
                </table>
                </td>

</tr>
<tr style="background-color:Gray;">
                <td colspan="2">
                <asp:Label ID="lbladvertiser" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                </td>

</tr>
<tr>
                <td colspan="2" >
                <asp:Label ID="lblcaption" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                </td>

</tr>
<tr style="background-color:Gray;">
                <td colspan="2">
                <asp:Label ID="lbledition" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                </td>

</tr>
<tr>
                <td colspan="2">
                        <table  width="660px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;vertical-align :top" >
                        <tr>
                        <td valign ="top" width="660px" style="border-bottom:solid 1px black;height: 200px;" >
                        <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                </td>
</tr>
<tr>
<td colspan="2">
        <table>
                        <tr>
                                        <td style="width:620px;" align="right">
                                        <asp:Label ID="lblgrossamt" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:40px;">

                                        <asp:Label ID="txtgrossamt" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                                        <td style="width:620px;" align="right">
                                        <asp:Label ID="lbltradedisc" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:40px;background-color:Gray;" align="right">

                                        <asp:Label ID="txttradedisc" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                                        <td style="width:620px;" align="right">
                                        <asp:Label ID="lblbalance" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:40px;">

                                        <asp:Label ID="txtbalance" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                                        <td style="width:620px;" align="right">
                                        <asp:Label ID="lblboxchrgs" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:40px;background-color:Gray;">

                                        <asp:Label ID="txtboxchrgs" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                                        <td style="width:620px;"  align="right">
                                        <asp:Label ID="lblnetbal" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:40px;">

                                        <asp:Label ID="txtnetbal" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                            
                                        </td>
                        </tr>
        </table>
</td>
</tr>
<tr style="width:40px;background-color:Gray;">
            <td colspan="2"> <asp:Label ID="lblrupees" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
</tr>

<tr>
            <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="660px" >
                            <tr>
                            <td style="font-size:11px;font-family :Times New Roman;" rowspan="2">

                            <b><u>Terms & Conditions:</u></b><br />
                            1:&nbsp;All cheques/drafts should be payable to Mangalam ,&nbsp;<br />
                            2:&nbsp;Any query may please be reverted within 7 days of receipt of bill.<br />
                            3:&nbsp;22% Interest will be charged on overdue bills.<br />
                            4:&nbsp;Payment should be made by A/C payee cheque/draft favouring\"Mangalam\" and  payable at<br />
                            5:&nbsp;All disputes are subject to&nbsp;&nbsp;&nbsp;&nbsp;jurisdiction;

                            <asp:Label ID="lbleoe" runat="server" style="text-align:right;padding-left:200px;"></asp:Label>
                            </td>
                            <td valign="top">
                            <asp:Label ID="lblcomname" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td valign="bottom"><asp:Label ID="lblauth" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
                            </tr>
                            </table>


</td>
</tr>
</table>








</p>



