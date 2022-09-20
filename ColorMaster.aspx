<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColorMaster.aspx.cs" Inherits="ColorMaster" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Color Master</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript" language="javascript" src="javascript/ColorMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>
		<script src="javascript/popUpCalender.js" type="text/javascript"></script>
		
		 
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;

        }
        function isalphaKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && (charCode < 97 || charCode > 123))
                return false;
            return true;

        }



//		    function isNumberKey(evt) {
//		        //alert(event.keyCode);
//		        var charCode = (evt.which) ? evt.which : event.keyCode
//		        if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
//		            return false;

//		        return true;
//		    }




		    var splitsign = 0;
		    var greatersign = 0;
		    var sql_inject = 0;
		    var unicodespl = "";
		    function chksplchar(a, b) {
		        unicodespl = b;
		        var result = "false";
		        var code = "abcdefghijklmnopqrstuvwxyz0123456789"
		        var myval = b;
		        if (b == "") {
		            return true;
		        }
		        if (b.indexOf("^") >= 0) {
		            splitsign = 1;
		            return result
		        }

		        if (b.indexOf("$~$") >= 0) {
		            splitsign = 1;
		            return result
		        }

		        if (b.indexOf("<") >= 0 || b.indexOf(">") >= 0 || b.indexOf("&lt;") >= 0 || b.indexOf("&LT;") >= 0 || b.indexOf("&gt;") >= 0 || b.indexOf("&GT;") >= 0 || b.indexOf("&lt") >= 0 || b.indexOf("&LT") >= 0 || b.indexOf("&gt") >= 0 || b.indexOf("&GT") >= 0) {
		            greatersign = 1;
		            return result
		        }

		        if (b.indexOf("select ") >= 0 || b.indexOf("update ") >= 0 || b.indexOf("insert ") >= 0 || b.indexOf("delete ") >= 0 || b.indexOf("SELECT ") >= 0 || b.indexOf("UPDATE ") >= 0 || b.indexOf("INSERT ") >= 0 || b.indexOf("DELETE ") >= 0) {
		            sql_inject = 1;
		            return result
		        }

		        code = code.toLowerCase()
		        myval = myval.toLowerCase()
		        for (i = 0; i <= myval.length - 1; i++) {
		            for (j = 0; j <= code.length - 1; j++) {
		                if (myval.charAt(i) == code.charAt(j)) {
		                    result = "true";
		                    break;
		                }
		            }
		        }
		        if (myval.length == "0") {
		            return "true";
		        }
		        if (result == "false") {
		            alert('You cannot enter special character in the text field');
		            $(a).focus();
		            return false
		        }
		        else {
		            return b;
		        }
		    }
    
    
    
    
    
    
    
    
    

		
		</script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
    <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
	
	</head>
	
	
	
	
	<body leftmargin="5" topmargin="0"   id="bdy"  onload=" loadXML('xml/errorMessage.xml');document.getElementById('btnNew').focus();javascript:return givebuttonpermission('ColorMaster');"  onkeydown="javascript:return tabvalue(event,'txtAlias');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
	
		<form id="Form1" method="post" runat="server">
			<%--<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Color Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">--%>
             <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"  text="Color Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					
                    <td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                          <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0"cellpadding="0" cellspacing="0" class="styl63">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Color Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  class="styl64" cellpadding="0" cellspacing="0" >
										<tr>
											<td><asp:label id="lbColorcode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return isNumberKey(event);" id="txtColorCode" runat="server" CssClass="btext1"
													MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
										<td><asp:label id="lbColorname" runat="server" CssClass="TextField"></asp:label></td>
												<%--<td><asp:textbox onkeypress="chksplchar(event);" id="txtColorName" runat="server" CssClass="btext"
		 										MaxLength="20"></asp:textbox>
		 										
		 										</td>
		 										<asp:RegularExpressionValidator ID="regexpName" runat="server" ErrorMessage="This expression does not validate"
		 										 ControlToValidate="txtColorName" ValidationExpression="^[a-zA-Z'.\s]" />
		 										 --%>
		 										 
		 										 <td><asp:textbox onkeypress="return isalphaKey(event)" id="txtColorName" runat="server" CssClass="btext1"
													MaxLength="10"></asp:textbox> </td>
		 						
		 						
		 						
    <td><asp:Button ID="btnSubmit" runat="server" style="visibility:hidden;"  />
    <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="This expression does not validate." 
                                    ControlToValidate="txtColorName"     
                                    ValidationExpression="^[a-zA-Z'.\s]{1,40}$" /></td>	
		 										
										</tr>
										<tr>
											<td ><asp:label id="Lbalias" runat="server" CssClass="TextField"></asp:label></td>
											<td ><asp:textbox onkeypress="return isNumberKey(event);" id="txtAlias" runat="server" CssClass="btextcode"
													MaxLength="20"></asp:textbox></td>
										</tr>
									</table>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		     <input id="ip1" type="hidden" name="ip1" runat="server" />
		</form>
	</body>
</html>
