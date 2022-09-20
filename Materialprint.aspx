<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Materialprint.aspx.cs" Inherits="Reports_Materialprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
     <link href="css/Materiallog.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 52px;
        }
        .style8
        {
            height: 0px;
            width: 58px;
            font-size: 12px;
            font-family: Arial;
            font-weight: bolder;
            text-align: left;
        }
        .style10
        {
            height: 0px;
            width: 75px;
            font-size: 12px;
            font-family: Arial;
            font-weight: bolder;
            text-align: left;
        }
        .style12
        {
            height: 0px;
            width: 180px;
            text-align: left;
            font-size: x-small;
            border-bottom-color: Black;
            border-bottom-width: thin;
        }
        .style17
        {
            width: 180px;
        }
        .style18
        {
            width: 180px;
        }
        .style20
        {
            height: 28px;
            width: 1099px;
        }
        .style21
        {
            height: 0px;
            width: 45px;
            font-size: 12px;
            font-family: Arial;
            font-weight: bolder;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table style="width:100%" >
  
      <tr>
     

          <td align="center" colspan="4" class="style20"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr style="width:100%">


  <td align="center" colspan="6">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td></tr>

 


</table>
    <div>
    <table style="width:100%">
        <tr><td id="subregrepDiv" runat ="server" ></td>
       </tr>
       </table> 
    </div>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0"  >
    <tr><%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
        
         <td  class="style21"><b>User:</b></td><td class="style17" ><asp:Label ID="lbluser" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="style10" >PUB CENT:</td><td class="style18"><asp:Label ID="lblpubcent" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="style10"><b>Pub Date:</b></td><td class="style12" align="left"><asp:Label ID="lblpdate" CssClass="reporttext2" runat="server" ></asp:Label></td>
 
        <td class="style8">Run Date</td><td class="style18"><asp:Label ID="lblrdate" CssClass="reporttext2" runat="server"></asp:Label></td>

    </tr>
        
     
    </table>
    <table width="100%"><tr valign="top"><td valign="top" id="tblgrid" runat="server"></td></tr></table>
    </div>
    <input id="hiddendateformat" type="hidden" runat="server" />          
    </form>
</body>
</html>
