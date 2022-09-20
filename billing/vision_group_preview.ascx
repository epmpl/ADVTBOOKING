<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vision_group_preview.ascx.cs" Inherits="vision_group_preview" %>

<link href="css/vision_group.css" type="text/css" rel="Stylesheet" />
<p style="page-break-after:always;">


<table width="650px;" align="center">
<tr>
<td height="150px;"></td>
</tr>
</table>

<table width="650px" align="center" cellspacing="0" cellpadding="0" >

<tr >
<td  valign="bottom"       class ="lable_textbox" colspan="1" width="200px;"  >MORINGA LIMITED</td>
<td rowspan="2" colspan="3" class="head" align="left" width="450px;" >Tax- Invoice</td>
</tr>
<tr class ="lable_textbox"  valign="top"   ><td>0753 25112</td></tr>



</table>
<table width="650px" align="center" >
<tr><td colspan="2" ></td><td  colspan="2" class="lable_textbox" >VAT Reg No. 11621-D</td>

</tr>

<tr><td colspan="2" ></td><td  colspan="2"  class="subhead" >Tin No 1000027144</td>

</tr>

<tr><td colspan="2" ></td><td width="120px;" class="lable_textbox" >Bank</td><td>
<asp:Label class="lable_textbox" ID="txt_bank" runat="server"></asp:Label>
</td></tr>
<tr><td colspan="2"></td><td class="lable_textbox">Acct Name</td><td class="lable_textbox"><asp:Label ID="txt_accname" runat="server"> </asp:Label></td></tr>
<tr><td colspan="2"></td><td class="lable_textbox">Acct Number</td><td class="lable_textbox"><asp:Label ID="Label1" runat="server"> </asp:Label></td></tr>

<tr><td width="100px;"   rowspan="2"  class="lable_textbox">Customer TIN No.:</td><td  rowspan="2" width="250px;" ><asp:Label ID="Label5" runat="server" class="lable_textbox">1000020551</asp:Label></td> <td class="lable_textbox">Branch</td><td class="lable_textbox"><asp:Label ID="txt_branch" runat="server"> </asp:Label></td></tr>

<tr><td class="lable_textbox">Swift Code</td><td class="lable_textbox"><asp:Label ID="Label6" runat="server"> </asp:Label></td></tr>

<tr><td rowspan="2" class="lable_textbox">Bill-to Customer No.</td>
<td rowspan="2" class="lable_textbox">
<asp:Label ID="txt_client_code" runat="server"></asp:Label>
</td>
<td class="lable_textbox">Manual order</td><td class="lable_textbox"><asp:Label ID="txt_rono" runat="server"> </asp:Label></td></tr>

<tr><td ></td><td ></td></tr>

<tr><td colspan="2" style="height: 26px"></td><td class="lable_textbox" style="height: 26px">Invoice No.</td><td style="height: 26px" class="lable_textbox"><asp:Label ID="txt_invoice" runat="server"> </asp:Label></td></tr>

<tr><td colspan="2"></td><td class="lable_textbox">Order No.</td><td class="lable_textbox"><asp:Label ID="txt_order" runat="server"> </asp:Label></td></tr>

<tr><td colspan="2"></td><td class="lable_textbox">Posting Date</td><td class="lable_textbox"><asp:Label ID="txt_posting" runat="server"> </asp:Label></td></tr>

<tr><td rowspan="2" class="lable_textbox">Sales Person</td> <td rowspan="2" class="lable_textbox"><asp:Label ID="txt_salesperson" runat="server"> </asp:Label></td><td class="lable_textbox">Due Date</td><td class="lable_textbox"><asp:Label ID="txt_due" runat="server"> </asp:Label></td></tr>

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
<tr><td colspan="3"></td></tr>
<tr><td class="lable_textbox" >Prepared By:</td><td class="head_second" align="center" ><b>WHT EXEMPT</b></td><td class="lable_textbox" align="right">Checked and Approved By:</td></tr>

<tr>
<td>----------------</td>
<td></td>
<td align="right">----------------</td>
</tr>

</table>
</p>
