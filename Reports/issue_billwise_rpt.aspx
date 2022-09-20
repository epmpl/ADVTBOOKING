<%@ Page Language="C#" AutoEventWireup="true" CodeFile="issue_billwise_rpt.aspx.cs" Inherits="issue_billwise_rpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Issue Bill Wise Report</title>
    
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
    /*text-align:center;*/
}
</style>
</head>
<body onload="document.getElementById('btnprint').focus();">
    <form id="form1" runat="server">
    <div>
     <table width="100%">
        <tr>
            <td align="left">
                <asp:button ID="btnprint" runat="server" Text="Print" ></asp:button>
            </td>
        </tr>
        <tr>
           <td style="width:100%;" align="center" colspan ="4"><asp:Label ID="Compname" runat="server" CssClass="headingc"></asp:Label></td>
        </tr>
        
        <tr>
            <td colspan="4" style="text-align:center ">
                <asp:Label ID = "lblHeading" runat = "server" CssClass = "headingp"></asp:Label>
            </td>
        </tr>
        
        <tr style="display:none">
               <td style="width :40%; height: 19px;" align="right">
                <asp:Label ID = "lblFromDate" runat = "server" CssClass = "upper2"></asp:Label>
            </td>
            <td style="width:10%; height: 19px;" >
                <asp:Label ID = "lblDate" runat = "server" CssClass = "reporttext2"></asp:Label>
            </td>
            
            <td style="width :10%; height: 19px;" align='right' >
                <asp:Label ID = "lblToDate" runat = "server" CssClass = "upper2"></asp:Label>
            </td>
                 <td style="width :40%; height: 19px" >
                    <asp:Label ID = "lblTDate" runat = "server" CssClass = "reporttext2"></asp:Label>
                </td>
            </tr>
            
            <tr style="display:none">
                <td  align="left" colspan="2"></td>
                <td  align="right" colspan="2">
                    <asp:Label ID = "lblRunningDate" runat = "server" CssClass = "upper2"></asp:Label> 
                    <asp:Label ID = "lblRdate" runat = "server" CssClass = "reporttext2"></asp:Label>
                </td>
           </tr>
        
        
       </table>
    
      <div id="div1" visible ="false" runat ="server" ></div>
      
    </div>
    
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
