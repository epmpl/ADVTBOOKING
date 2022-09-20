<%@ Page Language="C#" AutoEventWireup="true" CodeFile="issue_billwise_print.aspx.cs" Inherits="Reports_issue_billwise_print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Issue Billwise Report</title>
    
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .upper2
{/*style="font-size:12px;font-family:Arial"*/
	height:0px; 
	width: 130px; 
	font-size:12px;
	font-family:Arial;
	font-weight:bolder;
}

.middle31
{

	font-size:11px;
	font-family:Arial;
    font-weight :bold;
	border-bottom:solid;
	border-bottom-color:Black;
    border-bottom-width:thin ;
    vertical-align:top;
    
}

.middle21
{
	
	 height:0px;
	 width:300px;
	 text-align:left;
	 font-size:x-small;
	/* border-bottom:dashed;*/
	 border-bottom-color:Black;
	 border-bottom-width:thin;
}
</style>

<script type="text/javascript" language ="javascript" >
     function print1()
     {
     window.print();
     }
    </script>
    
</head>
<body onload="javascript:return print1();">
    <form id="form1" runat="server">
    <table style="width:100%" >
   <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="heading" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>

</table>

<table style="width:100%" id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
      
    <tr >
   
   
        <td  class="upper2">From Date:</td><td class="middle2" style="width:480px;" ><asp:Label ID="lblfromdate" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2" style="text-align:right;" >To Date:</td><td class="middle2" style="width:120px; text-align:right;"><asp:Label ID="lbltodate" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <%--<td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>

</tr>

    <tr style="border-bottom:dashed">
    
   <td  class="upper2" >Printing Center:</td><td class="middle2" style="width:480px;"><asp:Label ID="lblprintcent" CssClass="reporttext2" runat="server"></asp:Label></td>    
   <%--<td  class="upper2" style="text-align:right;" >Branch:</td><td class="middle2" style="width:120px; text-align:right;"><asp:Label ID="lblbranch" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
   <td  class="upper2" style="text-align:right;" >Publication:</td><td class="middle2" style="width:120px; text-align:right;"><asp:Label ID="lblpublication" CssClass="reporttext2" runat="server"></asp:Label></td>    
    <%--<td  class="upper2">ADTYPE:</td><td class="middle2" ><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
</tr>
 <tr style="border-bottom:dashed">
 <%--<td  class="upper2">Publication:</td><td class="middle2" style="width:480px;"><asp:Label ID="lblpublication" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
   <td  class="upper2" style="text-align:left;">Main Edition:</td><td class="middle2" style="width:120px; text-align:left;"><asp:Label ID="lbledition" CssClass="reporttext2" runat="server" ></asp:Label></td>
 <td  class="upper2" style="text-align:right;">Suppliment:</td><td class="middle2" style="width:120px; text-align:right;"><asp:Label ID="lblsuppliment" CssClass="reporttext2" runat="server" ></asp:Label></td>
    </tr>
    <tr style="border-bottom:dashed">
 <%--<td  class="upper2">Suppliment:</td><td class="middle2" style="width:480px;"><asp:Label ID="lblsuppliment" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
   <td  class="upper2" style="text-align:left;">District:</td><td class="middle2" style="width:120px; text-align:left;"><asp:Label ID="lbldistrict" CssClass="reporttext2" runat="server" ></asp:Label></td>
 
    </tr>

     
    </table>
    
    <%--<div>
    <div runat="server" id="div1" visible ="false"></div>
    </div>--%>
    
    <table width="100%" cellpadding="0" cellspacing="0" align="center" border="0"  ><tr valign="top"><td valign="top" id="div1" runat="server" align="center" ></td></tr></table>
    
    <input id="hiddencompcode" runat="server" name="hiddencompcode" type="hidden" />
    <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
        <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
        <input id="chk_access" runat="server" name="chk_access" type="hidden" />
        <input id="reportname" runat="server" name="reportname" type="hidden" />
        <input id="from_date" runat="server" name="from_date" type="hidden" />
        <input id="to_date" runat="server" name="to_date" type="hidden" />
        <input id="pubcent" runat="server" name="pubcent" type="hidden" />
        <input id="publication" runat="server" name="publication" type="hidden" />
        <input id="district" runat="server" name="district" type="hidden" />
        <input id="suppliment" runat="server" name="suppliment" type="hidden" />
        <input id="branch" runat="server" name="branch" type="hidden" />
        <input id="mainedition" runat="server" name="reportname" type="hidden" />
    </form>
</body>
</html>
