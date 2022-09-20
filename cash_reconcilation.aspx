<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cash_reconcilation.aspx.cs" Inherits="cash_reconcilation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> Cash Reconcilation</title> 
      <link href="css/main.css" type="text/css" rel="stylesheet" />
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="C#" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>

    <script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/cash_reconcilation.js"></script>
    <style type="text/css">
        .auto-style1
        {
            width: 412px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div>
    <table align="center" border="1" bordercolor="#000000" cellpadding="0"
                    cellspacing="0"><tr><td>
     <table align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0"
                                style="width:100%;height:100%">
                                <tr>
                                    <td align="center" class="btnlink">
                                        Cash Reconsilation</td>
                                </tr>
                            </table>
                            <table align="center" style="height:100%;margin-top:20px;">
                            
                            <tr valign="bottom"><td align="center" valign="middle"><asp:Label ID="lbloptn" runat="server" CssClass="TextField" Text="Select Reconcilation  Type">Reconcilation Type</asp:Label></td>
                            <td valign="middle">
                             <asp:DropDownList ID="drpoptn" TabIndex="0" runat="server" CssClass="dropdown">
                                 <asp:ListItem Value="C">Cashier</asp:ListItem>
                    <asp:ListItem Value="B">Bank</asp:ListItem>
                             </asp:DropDownList>
                                  
                            </td>
                            </tr>
                            
                           
                            
                            <tr><td></td>
                            <td align="right"><asp:Button ID="btnsubmit" TabIndex="0" runat="server" CssClass="button1" Text="Submit" /></td>
                            </tr>
                            </table>
    </td></tr></table>
    </div>


             <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
    
    
    
    </form>
</body>
</html>
