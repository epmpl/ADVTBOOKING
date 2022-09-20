<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bookingmaterialdata_rpt.aspx.cs" Inherits="Reports_bookingmaterialdata_rpt" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<script language="javascript" type="text/javascript" src="javascript/prototype.js" ></script> 
		<link href="css/main.css" type="text/css" rel="stylesheet"/>

    <title> Booking Import Data </title>
</head>
<body>
    <form id="form1" runat="server">
    
    <table width="100%">
    <tr>
    <td  width="100%" id= "report"  runat="server">
    
    </td>
    </tr>
    </table>
    
    
    <div>
    
    </div>
    
    
    
     <input id="Hidden1" type="hidden" runat="server" name="hdncompcode"/>
     <input id="hdncompname" type="hidden" runat="server" name="hdncompname"/>
     <input type="hidden" id="HDN_dateformat" runat="server" />
     <input type="hidden" id="hiddendateformat" runat="server" />
     <input type="hidden" id="hdncompcode" runat="server" />
     <input type="hidden" id="HDNunit" runat="server" />
     <input type="hidden" id="dateformat" runat="server" />
     <input type="hidden" id="hdnuserid" runat="server" />
     <input type="hidden" id="HDN_server_date" runat="server" />
     <input type="hidden" id="hdncomname" runat="server" />
    </form>
</body>
</html>

