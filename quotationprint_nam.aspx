<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quotationprint_nam.aspx.cs" Inherits="quotationprint_nam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quotation Print</title>
    <link type="text/css" href="css/main.css" rel="Stylesheet" />
    <link type="text/css" href="css/quotationprint_nam.css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript">
        function print1() {
            window.print();
        }
    </script>
</head>

<body onload="javascript:return print1();">
    <form id="form1" runat="server">
    <div>
    <div id="div1" runat="server" style="vertical-align:top" ></div>
    </div>
    
     <input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
			<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hdnbranch" type="hidden" name="hdnbranch" runat="server" />
			<input id="hdnfdate" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hdntdate" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hdnbasedon" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hidattach1" type="hidden" name="hidattach1" runat="server" />
			<input id="Hiddenagencycode" type="hidden" name="hidattach1" runat="server" />
			<input id="Hiddenexecutivecode" type="hidden" name="hidattach1" runat="server" />
			<input id="Hiddenclientcode" type="hidden" name="hidattach1" runat="server" />
			<input id="Hiddencentercode" type="hidden" name="hidattach1" runat="server" />
			<input id="hiddenretainercode" type="hidden" name="hidattach1" runat="server" />
			<input id="hiddenretainer" type="hidden"   runat="server" />
                <input id="hiddenretainertxt"   type="hidden"   runat="server" />
			<input id="hidden_client" type="hidden"   runat="server" />
			<input id="hidden_agency" type="hidden"   runat="server" />
			<input id="hdnexecutivetxt" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			  <input type="hidden" id="hiddencioidformat" runat="server" />
    </form>
</body>
</html>
