<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mangalam_bill.ascx.cs" Inherits="mangalam_bill" %>



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
<p  id="P1" style="page-break-after:always;border:solid 1px black;">
<table border="1" width="780px" cellpadding="0" cellspacing="0">
<tr>
                <td>
                    <table  cellpadding="0" cellspacing="0" width="800px">  
                        <tr style="border:solid 1px black;background-color:Gray;" valign="top">
                                <td style="width:80px;">
                                    <table style="background-color:Gray;">
                                        <tr>
                                        <td style="padding-left:15px;">
                                        <img src="Images/logo_mangalam.jpg" runat="server"  style="width:80px;"/>
                                        </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width:720px;">
                                        <table style="background-color:Gray; vertical-align:top;width:720px;"  cellpadding="0" cellspacing="0"  >
                                        <tr valign="top">
                                        <td style="font-size:x-large;font-family:Arial; padding-left:15px;" colspan="3" valign="top">

                                        <b>MANGALAM PUBLICATION (I) PVT LTD</b><br />
                                        <asp:Label ID="lbcompaddress" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                       
                                        <asp:Label ID="lbemailtxt" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                         <asp:Label ID="txtmailid" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                                        </tr>
                                                     
                                        </table>
                                 </td>
                         </tr>
                     </table>

                </td>
</tr>
<tr>
                <td align="center" style="font:Arial 13px;" >

                <b>ADERTISEMENT BILL-MANGALAM DAILY</b>


                </td>
</tr>

<tr>
    <td style="width:800px">
        <table style="width:800px" border="1" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:400px">

                        <table width="400px" cellpadding="0" cellspacing="0">
                        <tr>

                        <td>

                        To;
                        </td>
                        

                        </tr>
                        <tr>
                        <td><asp:Label ID="agddxt"  runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
                        </tr>
                        <tr>
                        <td><asp:Label ID="agencyaddtxt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
                        </tr>
                        </table>


                </td>
                <td style="width:400px">
                <table width="415px" border="0" cellpadding="0" cellspacing="0" >
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
              
                
     </table>
     </td>

</tr>
<tr>
        <td >
                    <table width="820px" cellpadding="0" cellspacing="0" >
                            <tr style="background-color:Gray;">
                                            <td colspan="2">
                                            <asp:Label ID="lbladvertiser" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                            <asp:Label ID="txtadv" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                            </td>

                            </tr>


                            <tr>
                                            <td colspan="2" >
                                            <asp:Label ID="lblcaption" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                            <asp:Label ID="txtcap" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                            </td>

                            </tr>
                            <tr style="background-color:Gray;">
                                            <td colspan="2">
                                            <asp:Label ID="lbledition" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                            <asp:Label ID="txtedition" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                            </td>

                            </tr>
                    </table>
        </td>
</tr>

<tr>
                <td>
                        <table  width="820px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;vertical-align :top" >
                        <tr>
                        <td valign ="top" width="820px" style="border-bottom:solid 1px black;height: 200px;" >
                        <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
                        </td>
                        </tr>
                        </table>
                </td>
</tr>




<tr>
<td>
        <table>
                        <tr>
                                        <td style="width:730px;" align="right">
                                        <asp:Label ID="lblgrossamt" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:90px;" align="right">

                                        <asp:Label ID="txtgrossamt" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                                        <td style="width:730px;" align="right">
                                        <asp:Label ID="lbltradedisc" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:90px;background-color:Gray;" align="right">

                                        <asp:Label ID="txttradedisc" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                                        <td style="width:730px;" align="right">
                                        <asp:Label ID="lblbalance" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:90px;"  align="right">

                                        <asp:Label ID="txtbalance" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                                        <td style="width:730px;" align="right">
                                        <asp:Label ID="lblboxchrgs" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:90px;background-color:Gray;" align="right">

                                        <asp:Label ID="txtboxchrgs" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                                        </td>
                        </tr>

                        <tr>
                                        <td style="width:730px;"  align="right">
                                        <asp:Label ID="lblnetbal" runat="server" CssClass="agecnycodeclasspune"></asp:Label>

                                        </td>
                                        <td style="width:90px;" align="right">

                                        <asp:Label ID="txtnetbal" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                            
                                        </td>
                        </tr>
                        <tr>
                        <td>
                        <asp:Label ID="lblchk" runat="server" CssClass="agecnycodeclasspune"></asp:Label><asp:Label ID="txtchk" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
                        </td>
                        </tr>
                        
        </table>
</td>
</tr>
<tr style="width:40px;background-color:Gray;">
            <td> <asp:Label ID="lblrupees" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
            <asp:Label ID="txtrupees" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
            </td>
</tr>

<tr>
            <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="800px" >
                            <tr>
                            <td style="font-size:11px;font-family :Times New Roman;" rowspan="2">

                            <b><u>Terms & Conditions:</u></b><br />
                            1:&nbsp;Remittence should be made by crossed account payee cheque/Demand Draft in favour of Mangalam Publication (I) pvt Ltd<br />
                            2:&nbsp;Only official Receipts issued by us will be binding on us.<br />
                            3:&nbsp;Please quote the Bill Number in all future correspondence<br />
                            4:&nbsp;Error if any should be brought to our notice within 7 days from the date of this bill<br />
                            5:&nbsp;All disputes related to this bill shall be subject to Kottayam jurisdiction;

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




