<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RCB_vision.ascx.cs" Inherits="RCB_vision" %>
<link href="billing/css/vision_group.css" type="text/css" rel="Stylesheet" />
<p id="bhanu" runat="server">


<table width="650px;" align="center">
<tr>
<td height="150px;"></td>
</tr>
</table>

<table width="650px" align="center" cellspacing="0" cellpadding="0" >

<tr >
<td  valign="bottom"       class ="lable_textbox" colspan="1" width="200px;"  >CASH ADVERTISING</td>
<td rowspan="2" colspan="3" class="head" align="left" width="450px;" ><asp:Label class="head" ID="lblhead" runat="server" > </asp:Label></td>
</tr>
<tr class ="lable_textbox"  valign="top"   ><td></td></tr>



</table>
<table width="650px" align="center" >
<tr><td colspan="2" ></td><td  colspan="2" class="lable_textbox" ><b>Order Confirmation</b></td>

</tr>

<tr><td colspan="2" ></td><td  class="subhead" ><asp:Label ID="pbl_pageno" class="lable_textbox" runat="server">Page</asp:Label></td><td><label id="txt_pageno" runat="server"></label></td>

</tr>

</tr>

<tr><td colspan="2" ></td><td  class="subhead" ><asp:Label ID="Label2" class="lable_textbox" runat="server">Phone No.</asp:Label></td><td><label id="Label3" runat="server"></label></td>

</tr>


<tr><td colspan="2" ></td><td  class="subhead" ><asp:Label ID="Label4" class="lable_textbox" runat="server">Fax No.</asp:Label></td><td><label id="Label7" runat="server"></label></td>

</tr>



<tr><td colspan="2" ></td><td  class="subhead" ><asp:Label ID="Label8" class="lable_textbox" runat="server">VAT Reg. No.</asp:Label></td><td><label id="Label9" runat="server" class="lable_textbox">11621-D</label></td>

</tr>

<tr><td colspan="2" ></td><td width="120px;" class="lable_textbox" >TIN No.</td><td>
<asp:Label class="lable_textbox" ID="Label6" runat="server">1000027144</asp:Label>
</td></tr>
<tr><td colspan="2" ></td><td width="120px;" class="lable_textbox" >Bank</td><td>
<asp:Label class="lable_textbox" ID="txt_bank" runat="server"></asp:Label>
</td></tr>
<tr>
<td rowspan="2" class="lable_textbox">Bill-to Customer No.</td>
<td rowspan="2" class="lable_textbox"><asp:Label ID="txt_client_code" runat="server"></asp:Label></td>
<td class="lable_textbox">Account No.</td><td class="lable_textbox"><asp:Label ID="Label1" runat="server"> </asp:Label></td></tr>

<tr><td class="lable_textbox">Manual order</td><td class="lable_textbox"><asp:Label ID="txt_rono" runat="server"> </asp:Label></td></tr>




<td width="100px;"   rowspan="2"  class="lable_textbox">Commision Agent</td><td  rowspan="2" width="250px;" ><asp:Label ID="Label5" runat="server" class="lable_textbox">No</asp:Label></td>




</tr>



<tr><td class="lable_textbox">Shipment Date</td><td class="lable_textbox"><asp:Label ID="txt_posting" runat="server"> </asp:Label></td></tr>

<tr><td rowspan="2" class="lable_textbox">Sales Person</td> <td rowspan="2" class="lable_textbox"><asp:Label ID="txt_salesperson" runat="server"> </asp:Label></td><td class="lable_textbox">Order No.</td><td class="lable_textbox"><asp:Label ID="txt_order" runat="server"> </asp:Label></td></tr>

<tr><td class="lable_textbox">Prices Including VAT</td><td class="lable_textbox"><asp:Label ID="Label12" runat="server" >Yes</asp:Label></td></tr>

<tr><td  height="50px;"></td></tr>


  
 


</table>

 <table  width="650px"   cellspacing="0" cellpadding="0"  align="center" >
 
 
<tr>

<td valign ="top"  height="200px;">
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
  </tr>
  </table>
<table width="650px;" align="center">
<tr><td align="left" class="lable_textbox" colspan="3">Payment Terms</td></tr>
<tr><td align="left" class="lable_textbox"  colspan="3">Shipment Method</td></tr>
<tr><td colspan="3" style="height:50px;"></td></tr>
<tr><td class="lable_textbox" >Prepared By:</td><td class="lable_textbox" >Confirmed By:</td><td class="lable_textbox" align="right">Checked and Approved By:</td></tr>

<tr>
<td>-----------------------</td>
<td>-----------------------</td>
<td align="right">-----------------------</td>
</tr>

</table>
</p>