<%@ Page Language="C#" AutoEventWireup="true" CodeFile="scheduleregister_new_edition.aspx.cs" Inherits="scheduleregister_new_edition" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" language="javascript" src="javascript/rept.js">
   function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
   </script>
<script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    <title>Schedule Register Report</title>
</head>
<body >
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
<div id="abc">



  <table style="width: 1415px" border="0">
  <tr>
          <td align="center" style="height: 28px" colspan="10"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
<tr style="width:100px">


<td align="left" style= "height: 28px;"  >
<asp:Button ID="btnprint" runat="server"   Text="Print" />
</td>
<td align="left" style="height: 28px;padding-left:220px" colspan="2">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="heading" CssClass ="headingp" runat ="server">Edition wise Schedule Register Report</asp:Label></td>

</tr>
<tr><td style="width: 69px"></td></tr>
</table>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr>
        <td  class="upper2">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
  
    </tr>
    <%--<tr style="border-bottom:dashed">
   
   <td class="upper2">
    
    </td>
    <td class="middle2"></td>    
   
        <td class="upper2">
  
    </td>
    <td class="middle2"></td> 
         <td class="upper2"  align="right" style="width:170px" >Page No:</td><td class="middle2"><asp:Label ID="pgn" CssClass="reporttext2" runat="server"></asp:Label></td>    
   
       --%>



<%--</tr>
<tr style="border-bottom:dashed">
    <td  class="upper2" >ADTYPE:</td><td class="middle2"><asp:Label ID="lbadtype" CssClass="reporttext2" runat="server"></asp:Label></td>
     <td  class="upper2" >ADCATEGORY:</td><td class="middle2"><asp:Label ID="lbadcategory" CssClass="reporttext2" runat="server"></asp:Label></td>
     <td  class="upper2" >EDITION:</td><td class="middle2" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>
</tr>--%>

     
    </table>
   
    <table style="width: 97%"><tr valign="top"><td  valign="top" id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr>
      <tr><td id="tblgrid1" colspan="19" runat="server" style="height: 21px" visible ="true"></td></tr></table>
       <%--<table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
         
            
  
        </tr>
    </table>--%>
         <input id="hiddendatefrom" type="hidden" runat="server" />
            <input id="hiddendateto" type="hidden" runat="server" />
                <input id="hiddencioid" type="hidden" runat="server" onTextChange="hiddencioid_TextChange" />
               <input id="hiddenascdesc" type="hidden" runat="server" />
               <input id="hiddendateformat" type="hidden" runat="server" />
     <input id="hiddenunit" type="hidden" runat="server" />
               		<%--<TD rowSpan=2>
            <asp:Label id="errLabel" runat="server" Width="335px" Height="24px"></asp:Label></TD>--%>
    </form>
</body>
</html>