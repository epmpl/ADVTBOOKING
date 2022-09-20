<%@ Page Language="C#" AutoEventWireup="true" CodeFile="agencyanalysisprint.aspx.cs" Inherits="agencyanalysisprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Top Agency/Client Analysis Report</title>
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
               <%-- <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px" ></td> 

<td align="left" style="width: 69px; height: 28px;">

<td align="center" style="height: 28px"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right" style="height: 28px"></td>
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
 
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr >
        <td  class="upper2" valign="top" >DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" valign="top" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" valign="top" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
        
    </tr>  
    <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top" >PUBLICATION:</td><td class="middle2"><asp:Label ID="lblpublication" CssClass="reporttext2" runat="server"></asp:Label></td>    
     <td  class="upper2" valign="top" >EDITION:</td><td class="middle2"><asp:Label ID="lbledition" CssClass="reporttext2" runat="server"></asp:Label></td>    
      <td  class="upper2" valign="top" >AD TYPE:</td><td class="middle2"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server"></asp:Label></td>    
   
          




</tr>

 <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top" >PUBCENT:</td><td class="middle2"><asp:Label ID="lblpubcent" CssClass="reporttext2" runat="server"></asp:Label></td>    
    
      <td  class="upper2" valign="top" >CITY:</td><td class="middle2"><asp:Label ID="lblcity" CssClass="reporttext2" runat="server"></asp:Label></td>  
      <td  class="upper2" valign="top" >EXECUTIVE:</td><td class="middle2"><asp:Label ID="lblexec" CssClass="reporttext2" runat="server"></asp:Label></td>      
   
 

</tr>




 <tr style="border-bottom:dashed">
    

 <%-- <td  class="upper2" valign="top" style="font-size:10px">REVENUE CENTER:</td><td class="middle2"><asp:Label ID="lblrevcent" CssClass="reporttext2" runat="server"></asp:Label></td>    --%>

</tr>




     
    </table>
   
     <table style="width: 97%"><tr valign="top"><td id="tblgrid" runat="server" style="height: 21px" visible ="true" valign="top"></td></tr></table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
        

            
  
        </tr>
    </table>
    
    <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td> <input id="hiddencioid" type="hidden" runat="server" onTextChange="hiddencioid_TextChange" />
               <input id="hiddenascdesc" type="hidden" runat="server" /></td></tr></table>
    </div>
    </form>
</body>
</html>
