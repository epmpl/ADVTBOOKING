<%@ Page Language="C#" AutoEventWireup="true" CodeFile="emailprocessmaster.aspx.cs" Inherits="emailprocessmaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email Process Master</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/Emailprocessmaster.js"></script>
		
				<script language="javascript" type="text/javascript" src="javascript/prototype.js"></script>
		<%--<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>--%>
		
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script language="javascript">
		
		
		
		
		</script>
		
		
</head>
<body onload="javascript:return first(event);">
    <form id="Form1" method="post" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Fmg Reason Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td vAlign="top" style="width: 796px">
			<table cellSpacing="0" cellPadding="0" border="0" id="RightTable" class="RightTable">
				<tr valign="top">
					<td><asp:UpdatePanel ID="upbtnsave" runat="server"><ContentTemplate><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
						BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton></ContentTemplate></asp:UpdatePanel>
					</td>
				</tr>
			</table>
			</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Email Process Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
    <table  cellpadding="0" cellspacing="0" border="0" style="width:20%;margin:30px 300px;">
    <td ><asp:label id="lblbranch" runat="server" CssClass="TextField"></asp:label></td>
								        <td>
                                              <asp:DropDownList ID="drpbranch" runat="server" CssClass="dropdown">
                                              <asp:ListItem Value="0">--Select Branch--</asp:ListItem>
                                              </asp:DropDownList>
                                        </td>
									</tr>
									
									
									<tr>										<td>
											

	                                        <asp:label id="lblprocesstype" runat="server"  CssClass ="TextField"></asp:label></td>
	
                                                  <td >
		
	                                <asp:DropDownList  id="drpprocesstyp" runat="server" CssClass="dropdown" >
	                                
	                                </asp:DropDownList>
                                                    </td></tr>
									
									
									
									<tr>										<td>
											

	                                        <asp:label id="lblmail" runat="server" CssClass="TextField"></asp:label></td>
	
                                                  <td align="left">
		
	                                <asp:textbox  id="txtemailid" runat="server" CssClass="btext1" ></asp:textbox>
                                                    </td></tr>
                                                    
                                                    
                                                    
                                                    
									
                                                    
                                                    
                                                    
                                                    
                                                    

									   			
    
    </table>
    
    
    
    
    <div>
    
    
    </div>
   
    <input id="hiddencompcode" type="hidden" size="5" name="hiddencompcode" runat="server"/>
  <%--  <input id="hiddenuserid" type="hidden" size="6" name="hiddenuserid" runat="server" onserverchange="hiddenuserid_ServerChange"/>--%>
  <input id="hdnsav" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hiddenuserid" type="hidden" size="6" name="hiddenuserid" runat="server" />
    <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
     <input id="hidsysdate" type="hidden" size="1" name="Hidden2" runat="server"/>
	 <input id="hidsysdatesql" type="hidden" size="1" name="Hidden2" runat="server"/>
	    <input id="hdnexecut" type="hidden" size="1" name="Hidden2" runat="server"/>
	    <input id="hdnuserid" type="hidden" size="1" name="Hidden2" runat="server"/>
	    <input id="hdnsav2" type="hidden" size="1" name="Hidden2" runat="server"/>
			       <input id="whercol" type="hidden" size="1" name="Hidden2" runat="server"/>
			       <input id="hdncon" type="hidden" size="1" name="Hidden2" runat="server"/>
    
    </form>
</body>
</html>
