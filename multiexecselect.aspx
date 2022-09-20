<%@ Page Language="C#" AutoEventWireup="true" CodeFile="multiexecselect.aspx.cs" Inherits="multiexecselect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multiple Executive</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	<script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
	<script language="javascript"  type="text/javascript" src="javascript/multiexecselect.js"></script>
	
</head>
<body onload="javascript:return selval();" onkeydown="javascript:return tabvalue1(event);">
    <form id="form1" runat="server">
    
    <div id="divexec" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                     <asp:ListBox ID="lstexec" Width="254px" Height="65px" runat="server" SelectionMode="Multiple" CssClass="btextlist"></asp:ListBox>
                              
                    </td>
                    <td style="font-family: Arial;font-size:xx-small;font-weight:bold;height:24px;width:20px;">
                        <asp:button id="btnsubmit" runat="server" Text="Select"></asp:button>
                        <asp:button id="btad" runat="server" Text="Add   " Enabled="false"></asp:button>
                    </td>
                            
                </tr>
            </table>
        </div>
    
    <div>
    <table id="OuterTable"  border="0" cellpadding="0" cellspacing="0">
    <tr>
    <td>
    <table>
    <tr>
    
    <td align="left"><asp:Label id="Label7" runat="server" CssClass="TextField">Executive<font color="red">[F2]</font></asp:Label></td>
    <td ><asp:TextBox id="txtexecname" runat="server" CssClass="btext1" ></asp:TextBox></td> 
    
    </tr>
    </table>
    </td>
    </tr>
     <div style="overflow:auto; height:100">
                                <table cellpadding="0" cellspacing="0" border="0" align="left">
                                <tr>
                                  <td style="height:100px" id="gridopen" runat="server"></td>  
                                                              
                               </tr>
                               
                             
                               
                               <tr>
                                 
                                  <td id="save" runat="server"></td>
                               </tr>
                         
                             </table></div>
    </table>
    </div>
   
    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddencioid" type="hidden"  name="hiddencioid" runat="server"/>
			<input id="hiddenmod" type="hidden" name="hiddenmod" runat="server"/>
    </form>
</body>
</html>
