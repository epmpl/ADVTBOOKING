<%@ Control Language="C#" AutoEventWireup="true" CodeFile="printcoverletter.ascx.cs" Inherits="printcoverletter" %>


<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />
    
    
    <table class ="break" style ="margin-left:40PX" >
    
    <tr align ="RIGHT"  >
    <td colspan ="6" align ="center"  style="font-family:Times New Roman ;font-size:30px;font-weight :bold "  >
    Shree Ambika Printers & Publications</td>
    </tr>
    
    <tr>
    <td colspan ="6" align ="center" >
    <asp:Label ID="lb_center" runat ="server" style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px"></asp:Label>
    
     </td>
    </tr>
     <tr>
     
     
    <td colspan ="6" align ="center">
    
    <asp:Label ID="lb_tel" Text="Phone No."   
     runat ="server" style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px"></asp:Label>
    <asp:Label ID="lb_telephone" runat ="server" style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px"></asp:Label>
    
    </td>
    </tr>
    
      <tr>
    <td colspan ="6" style ="height :50px;" ></td>
    </tr>
    
    
    <tr>
    <td  ><b> Date:-</b>
 <asp:Label ID="lbrundate" runat ="server"  CssClass="dateclasspune" ></asp:Label></td>
    </tr>
     <tr>
    <td colspan ="6" style ="height :20px;" ></td>
    </tr>
    <tr><td><B>To,</B></td></tr>
    <tr><td colspan ="6" ></td></tr>
    <tr><td colspan ="6"><b>
    <asp:Label ID="lb_agency" runat ="server"  CssClass="dateclasspune" ></asp:Label> </b></td></tr>
    <tr><td colspan ="6"><B><asp:Label ID="lb_agencyadd" runat ="server" CssClass="dateclasspune" ></asp:Label></B> </td></tr>
     <tr><td style="height:10PX;" colspan ="6"></td></tr>
    <tr><td colspan ="6">Dear Sir/Madam ,</td></tr>
    <tr><td colspan ="6">Please Find Advertisement Bill</td></tr>
    
     <tr>
    <td colspan ="6" style ="height :20px;" ></td>
    </tr>
    
    <tr>
    <td colspan ="6"   >
    
   
    <table style="width: 587px;" cellspacing ="0"  border="1">
   
    
    <tr>
    
    <td  ><b> Bill No.</b></td>
    <td><b>Bill Date</b></td>
     <td ><b>Amount</b></td>
    <td ><b>Edition</b></td>
    <td ><b>Reference</b></td>
    <td ><b>R.O. No.</b></td>
    </tr>
    
      <tr>
    <td ><asp:Label ID="lb_bill" runat ="server" CssClass="dateclasspune" ></asp:Label> </td>
    <td ><asp:Label ID="lb_billdate" runat ="server" CssClass="dateclasspune" ></asp:Label></td>
    <td ><asp:Label ID="lb_amount" runat ="server" CssClass="dateclasspune"></asp:Label></td>
    <td ><asp:Label ID="lb_edition" runat ="server" CssClass="dateclasspune"></asp:Label></td>
    <td ><asp:Label ID="lb_refrence" runat ="server"  CssClass="dateclasspune" ></asp:Label></td>
    <td  ><asp:Label ID="lb_rono" runat ="server" CssClass="dateclasspune"></asp:Label></td>
    </tr>
    
     </table>
  
    </td>
    </tr>
    
     
     <tr>
    <td colspan ="6" style ="height :20px;" ></td>
    </tr>
    
     <tr>
    <td colspan ="6">Please Note that dispute(s) will not be entertained if not brought to notice of recovery department
</td>
    </tr>
    <tr>
    <td colspan ="6">Within 8 days on the receipt of this letter.</td>
    </tr>
     <tr>
    <td colspan ="6" style ="height :20px;" ></td>
    </tr>
    <tr>
    <td colspan ="6">Thanking You,</td>
    </tr>
    <tr>
    <td colspan ="6">Yours Faithfully,</td>
    </tr>
    
      <tr>
    <td colspan ="6" style ="height :20px;" ></td>
    </tr>
    
     <tr>
    <td colspan ="6">(Recovery Manager)</td>
    </tr>
    <tr>
    <td colspan ="6"></td>
    </tr>
    <tr>
    <td colspan ="6" style ="height :100px;" ></td>
    </tr>
    
    <tr>
    <td colspan ="6" style ="background-color :Gray;"> <B>All Payments  Should be made in   favour   of  "Shree Ambika Printers & Publications"</B> </td>
    </tr>
    </table>

