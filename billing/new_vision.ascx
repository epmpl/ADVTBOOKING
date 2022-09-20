<%@ Control Language="C#" AutoEventWireup="true" CodeFile="new_vision.ascx.cs" Inherits="new_vision" %>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">--%>
    <title>New Vision</title>
    <style type="text/css">
        .style2
        {
            width: 587px;
        }
        .style4
        {
            width: 234px;
        }
    </style>
    
<table style="margin-top:0px;vertical-align:top;text-align:center;" 
    border="0" cellpadding="0" cellspacing="0" >

<tr><td>
 <table style="width: 100%; margin-left: 0px;">
    <tr>
    <td style="font-weight:bold;font-size:25px;font-family:Arial"><asp:Label ID="compname" runat="server"></asp:Label></td></tr>
    <tr style="font-size:11px;font-family:Arial"><td><asp:Label ID="compaddress" runat="server"></asp:Label></td></tr>
    
    <tr style="font-size:11px;font-family:Arial"><td><asp:Label ID="add1" runat="server"></asp:Label></td></tr>
    <tr style="font-size:11px;font-family:Arial"><td><asp:Label ID="add2" runat="server"></asp:Label><br />
        <br />
                                </td></tr>
   </table>
</td></tr>


</table>
   
   
    <table style="font-size:large">
   
    <tr><td class="style4" style="font-family:Arial;font-size:15px"><asp:Label ID="lbldate" runat="server"  Text=""></asp:Label>
        &nbsp;
        <br />
        </td>
        <td style="border-bottom-width:thin;border-bottom-style:dotted; font-family:Arial; font-size:15px;" class="style2"><asp:Label ID="lblblank" runat="server"></asp:Label></td></tr>
    <tr><td class="style4" style="font-family:Arial;font-size:15px"><asp:Label ID="lblour" runat="server" Text=""></asp:Label>
        <br />
        </td>
        <td style="border-bottom-width:thin;border-bottom-style:dotted; font-family:Arial;font-size:15px" class="style2"><asp:Label ID="lblblank1" Text="&nbsp;" runat="server"></asp:Label></td></tr>
    <tr><td class="style4" style="font-family:Arial;font-size:15px"><asp:Label ID="lblyour" runat="server" Text=""></asp:Label></td>
      <td style="border-bottom-width:thin;border-bottom-style:dotted; font-family:Arial;font-size:15px" class="style2"><asp:Label ID="lblagency" runat="server"></asp:Label></td></tr>  
      <tr><td class="style4" style="font-family:Arial;font-size:15px"></td>
      <td style="font-family:Arial;font-size:15px" class="style4"><asp:Label ID="lbladdress" runat="server"></asp:Label></td></tr>
      
        <tr>
            <td class="style4">
                <br />
            </td>
        </tr>
        
      <tr><td class="style4" style="font-family:Arial;font-size:15px"><asp:Label ID="lbl_agencyname" runat="server"></asp:Label>
          <br />
          </td>
          <td class="style2" style="font-family:Arial;font-size:15px">
          </td></tr>
     
       
       <%-- <tr><asp:Label ID="lbl_agencyname" runat="server"></asp:Label></tr>--%>
      
    </table>
   <tr>
    <td style="font-size:large;font-family:Arial;font-size:15px">
   <asp:Label ID="lbl_1" runat="server"></asp:Label>
 
    
        <br />
        <br />
 
    
    </td>
    </tr>
         
         <tr>   <td style="font-size:large;font-family:Arial;font-size:15px">
                <asp:Label ID="lbl_2" runat="server"></asp:Label>
    
    
                <br />
                <br />
    
    
    </td></tr>
    <tr>
            <td style="font-size:large;font-family:Arial;font-size:15px">
             <asp:Label ID="lbl_3" runat="server"></asp:Label>                                
                                <br />
                <br />
                                </td></tr>
       <table style="width: 91%;font-family:Arial;font-size:15px">
     <tr ><td style="border-bottom-width:thin;border-bottom-style:dotted; width:70%;font-family:Arial;font-size:15px">
         <asp:Label ID="lbl_invoiceno" runat="server" Width="70%"></asp:Label><br /></td></tr>
     
     </table> 
     <table >  
     <tr><td>
     <br />
              </td> </tr>
    
        
      <tr><td style="font-size:large;font-family:Arial;font-size:15px">
     <asp:Label ID="lbl_4" runat="server"></asp:Label>         
              <br />
    <br />
        <asp:Label ID="lbl_5" runat="server"></asp:Label>                       
        
    <br />
    <br />
        
    </td></tr>
    <tr><td style="font-size:large;font-family:Arial;font-size:15px">
                                
    <asp:Label ID="lbl_6" runat="server"></asp:Label>
    
    <br />
    
    <br />
    
    </td></tr>
       <tr> <td style="font-size:large;font-family:Arial;font-size:15px">
       <asp:Label ID="lbl_7" runat="server"></asp:Label>
               </td></tr>
               
                 <tr> <td style="font-size:large;font-family:Arial;font-size:15px">
       <br />
       <asp:Label ID="lbl_8" runat="server"></asp:Label>
               </td></tr>
                
         <input id="HDN_server_date" runat="server" type="hidden"/>
          <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />       
  </td>

</table>
<table style="page-break-before:always"></table>
