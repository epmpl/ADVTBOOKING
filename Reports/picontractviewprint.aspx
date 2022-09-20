<%@ Page Language="C#" AutoEventWireup="true" CodeFile="picontractviewprint.aspx.cs" Inherits="picontractviewprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PI Contract Report</title>
     <link href="css/report.css" rel="stylesheet" type="text/css" />
     
    <script language="javascript" type="text/javascript">



    function print1()
    { 
   
    window.print();
   
    }
 
function table1_onclick()
 {

}
function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();


</script>
 <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
</head>
<body onload="print1();">
    <form id="form1" runat="server">
             <div>
                        <%--  <table style="width: 934px" >
  
                                    <tr style="width:100px">
                                               <td align="left" style="width: 10px" ></td>

                                               <td align="center" style="width: 750px">
                                                                  <asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
                                               <td align="right" style="width: 200px"></td>
                                    </tr>
                                    <tr>
                                               <td style="width: 69px"></td>
                                    </tr>
                          </table>--%>
                          
                <table style="width:100%" >
   <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
          </tr>

</table>

    
                          <table id="table1" style="vertical-align:bottom;" cellpadding="0" cellspacing="0" align="center" border="0" onclick="return table1_onclick()" >
                                     <tr>
                                                 <td class="upper2" valign="top" >&nbsp;&nbsp;&nbsp;&nbsp;DATE FROM:</td><td class="middle2" style="width:600px ; vertical-align:top ;"><asp:Label ID="lblfrom" CssClass="reporttext1" runat="server" ></asp:Label></td>
                                                 <td class="upper2" valign="top" >DATE TO:</td><td class="middle2" style="width:600px ; vertical-align:top ;"><asp:Label ID="lblto" CssClass="reporttext1" runat="server" ></asp:Label></td>
                                                 <td  class="upper2" valign="top">RUN DATE:</td><td class="middle2" style=" vertical-align:top ; width:600px;"><asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
     
                                     </tr>
                                    <tr style="border-bottom:dashed">
        
                                                 <td class="upper2" valign="top" >&nbsp;&nbsp;&nbsp;&nbsp;PUBLICATION:</td><td class="middle2" style="width:600px ; vertical-align:top ;"><asp:Label ID="lblproduct" CssClass="reporttext1" runat="server" ></asp:Label></td>
                                                 <td class="upper2" valign="top">REGION:</td><td class="middle2" style="width:600px ; vertical-align:top ;"><asp:Label ID="lblregion" CssClass="reporttext1" runat="server" ></asp:Label></td>
                                                 <td  class="upper2" valign="top" >CATEGORY:</td><td class="middle2" style="vertical-align:top ; width:600px;"><asp:Label ID="lbladcat" CssClass="reporttext2" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr style="border-bottom:dashed">
        
                                                 <td class="upper2" valign="top" >&nbsp;&nbsp;&nbsp;&nbsp;AGENCY:</td><td class="middle2" style="width:600px;vertical-align:top ;"><asp:Label ID="lblagency" CssClass="reporttext1" runat="server" ></asp:Label></td>
                                                 <td class="upper2" ></td><td class="middle2" style="width:600px; vertical-align:top ;"></td>
                                                 <td  class="upper2" valign="top" >CLIENT:</td><td class="middle2"  style="vertical-align:top ; width:600px;"><asp:Label ID="lblclient" CssClass="reporttext2" runat="server"></asp:Label></td>
     
                                    </tr>     
                       <%--</table>  
                        <table width="100%" style="vertical-align:top;">--%>
                                        <tr valign="top">
                                                 <td colspan="6" valign="top">
                                                               <table width="100%" style="vertical-align:top;">
                                                                        <tr valign="top">
                                                                                      <td id="tblgrid" runat="server" valign="top"></td>
                                                                        </tr>
                                                                        <tr>
                                                                                       <td><asp:Label ID="dynamictable" runat="server"></asp:Label> </td>
                                                                        </tr>
                                       
                                                               </table>
                                                  </td>
                                        </tr>
                        </table>                   
                        
                           <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
                           <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
                           <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
             </div>
    </form>
</body>
</html>
