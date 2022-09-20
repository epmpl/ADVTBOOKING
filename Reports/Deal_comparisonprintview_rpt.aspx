<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Deal_comparisonprintview_rpt.aspx.cs" Inherits="Deal_comparisonprintview_rpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Page Of Dealcomparison</title>
<link href="css/hemant.css" type="text/css" rel="stylesheet"/>
     <script type="text/javascript" language="javascript" src="javascript/Deal_comparison_rpt.js"></script>
</head>
<body onload="javascript:return window.print(); ">
    &nbsp;<form id="form1" runat="server">
   <table>
<tr><td  class="heading_l"  ><asp:Label ID="lbltitle" runat ="server" ></asp:Label></td>
       </tr>
        <tr><td class="heading_l"  ><asp:Label ID="lblhead" runat ="server" ></asp:Label></td>
       </tr>
       </table> 
   <%-- <asp:Button ID="printbutton" runat="server" Text="print" />--%>
    <div>
    <table style="width:5100px">
        <tr><td id="subregrepDiv" runat ="server" ></td>
       </tr>
       </table> 
    </div>
     <input id="hiddenconnection" type="hidden" runat="server" />
            <input id="hdncompcode" type="hidden" runat="server" />
	        <input id="hiddendateformat" type="hidden" runat="server"  />
	        <input id="hdnshid" type="hidden" runat="server"  />
	        <input id="hdnloc" type="hidden" runat="server"  />
	        <input type="hidden" id="hiddenconnection1" runat="server" />
	         <input type="hidden" id="hiddenagency" runat="server" />
	        <input type="hidden" id="hiddenagency1" runat="server" /> 
	         <input type="hidden" id="hiddenclient" runat="server" />
	        <input type="hidden" id="hiddenclient1" runat="server" /> 
	         <input type="hidden" id="hiddenproduct" runat="server" />
	        <input type="hidden" id="hiddenproduct1" runat="server" /> 
	         <input type="hidden" id="hiddencity" runat="server" />
	         <input type="hidden" id="hiddendist" runat="server" />
	         <input type="hidden" id="hiddencust" runat="server" />
	         <input type="hidden" id="hiddenstate" runat="server" />
	        

<input id="hdn_user_right" type="hidden" runat="server" name="hdncompname"/>

<input id="hdnunit" type="hidden" runat="server" name="hdnunit"/>

<input id="hdnuserid" type="hidden" runat="server" name="hdnuserid"/>
 <input type="hidden" id="hdndateformat" runat="server" />

    
    </form>
    
    
    
</body>
</html>

