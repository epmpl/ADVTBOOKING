<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retaincomviewprint.aspx.cs" Inherits="retaincomviewprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Retainer Commision Report</title>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
  <script language="javascript" type="text/javascript">
    function print1()
    { 
   
    window.print();
   
    }
    </script> 
</head>
<body onload="print1();">
    <form id="form1" runat="server">
    <div>
                <%--<table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px">
    &nbsp;</td> 

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>--%>
 <table style="width:100%" >
   <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
          </tr>

</table>
 <%--   <table align="center">
<tr>
<td><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
</tr>
<tr><td></td></tr>
</table>--%>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
     
     
     
     <tr >
       
        <td  class="upper2" valign="top" >PUBLICATION:</td><td class="middle2"  ><asp:Label ID="lblproduct" CssClass="reporttext2" runat="server" ></asp:Label></td>
         <td  class="upper2" valign="top" >EDITION:</td><td class="middle2"  ><asp:Label ID="lbledition" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" align="right" valign="top" >RUN DATE:</td><td class="middle2" align="right"><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
        
    </tr>
     <tr >
       
        <td  class="upper2" valign="top" >REGION:</td><td class="middle2"  ><asp:Label ID="lblregion" CssClass="reporttext2" runat="server" ></asp:Label></td>
         <td  class="upper2" valign="top" >BRANCH:</td><td class="middle2"  ><asp:Label ID="lblbranch" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" align="right" valign="top" >RETAINER:</td><td class="middle2" align="right"><asp:Label ID="lblretainer" CssClass="reporttext2" runat="server" ></asp:Label></td>
        
    </tr>
    <tr >
        
         <td  class="upper2" valign="top" >DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
          <td  class="upper2" valign="top" >AD TYPE:</td><td class="middle2"  ><asp:Label ID="lbladtype11" CssClass="reporttext2" runat="server" ></asp:Label></td>
         <td  class="upper2" align="right" valign="top">DATE TO:</td><td class="middle2" align="right" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
        
   </tr>
  
 
     
    </table>
   
     <table style="width: 97%">
     <tr valign='top'><td valign="top" id="tblgrid" runat="server" style="height: 11px" visible ="true"></td></tr> 
     
     <tr valign="top"><td valign="top">    <asp:Label ID="dynamictable" runat="server" ></asp:Label> </td></tr>
   
    </table>

     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
           <%-- <td   align="center" style="width:800px; height: 21px;">
                <asp:Label ID="heading" CssClass ="heading" runat ="server" style="z-index: 100; left: 387px; position: absolute; top: 2px"></asp:Label>
            </td>--%>

            
       
        </tr>
    </table>
    
      <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" />
               <input id="hiddencioid" type="hidden" runat="server"  />
               <input id="hiddenascdesc" type="hidden" runat="server" />
               <input id="dscount" type="hidden" runat="server" /></td></tr></table>
    </div>
    </form>
</body>
</html>
