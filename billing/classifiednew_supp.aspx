<%@ Page Language="C#" AutoEventWireup="true" CodeFile="classifiednew_supp.aspx.cs" Inherits="classifiednew_supp" %>
<%@ register TagPrefix="uc3" TagName="classifiedcontrol" Src="~/billing/classifiedcontrol.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillrepunebillre" Src="~/billing/punebillre.ascx"%>
<%@ register TagPrefix="uc3" TagName="prahhar_classified_re" Src="~/billing/prahhar_classified_re.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillclassi_re" Src="~/billing/punebillclassi_re.ascx"%>
<%@ register TagPrefix="uc3" TagName="billformat_classified" Src="~/billing/billformat_classified.ascx"%>
<%@ register TagPrefix="uc3" TagName="RCB1" Src="~/billing/RCB1_supp.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Invoice Classified</title>
    <script type="text/javascript"  language="javascript" src="javascript/printbutton.js"></script>
    
</head>
<body oncopy="return false;" onpaste="return false;">



  <form id="form2" runat="server">
      <div ><asp:PlaceHolder id="placeholder1" runat="server"></asp:PlaceHolder></div>
   <%-- <table><tr><td>
    
    </td>
    
  
				
    
    </tr>
    </table>--%>
    </form>
   
		<input id="hiddendateformat" type="hidden" runat="server" />
				<input id="hiddeninsertion" type="hidden" runat="server" />
    
		
			
		
		
		

</body>
</html>
