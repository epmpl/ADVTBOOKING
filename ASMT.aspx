<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ASMT.aspx.cs" Inherits="ASMT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript" language="javascript" src="ASMT.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    <title>Agency Security Amount</title>
</head>
<body onload="blankfields();" onkeydown="javascript:return tabvalue();" style="background-color:#f3f6fd;margin:0px 0px 0px 0px">
   <form id="form1" runat="server">
    <div>
    <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
     <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000"  border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar" runat="server" Text="Agency Security Amount"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td style="height: 24px; width: 758px;"><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
    <table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Agency Security Amount</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
   <table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
										<tr style="padding-top: 4px; padding-left: 4px">
											<td><asp:Label id="Agencylabel" runat="server" CssClass="TextField" ></asp:Label></td>
											<td><asp:TextBox id="textagency" runat="server" cssclass="btext1" Height="14px"></asp:TextBox></td>
										</tr>
										<tr style="padding-top: 4px; padding-left: 4px">
											<td><asp:Label id="securityamountlabel" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox id="textsecurityamount" runat="server" cssclass="btext1" Height="14px"></asp:TextBox></td>
										</tr>
										<tr style="padding-top: 4px; padding-left: 4px">
											<td><asp:Label id="commisionlabel" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox id="textcommision" runat="server" cssclass="btext1" Height="14px"></asp:TextBox></td>
										</tr>
										<tr style="padding-top: 4px; padding-left: 4px">
											<td><asp:Label id="statuslabel" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:DropDownList ID="textstatus" runat="server" CssClass="btext" Width="150px">
                                                 <asp:ListItem Text="--Select Status--" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Active" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Inactive" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
												</td>
										
										
										</tr>
										</table>
											
    </div>
     <input id="hdn_user_right" type="hidden" runat="server" name="hdncompname"/>
     <input type="hidden" id="hdncompcode" runat="server" /> 
     <input type="hidden" id="hdnuser" runat="server" /> 
     <input type="hidden" id="hdncurdate" runat="server" /> 
       <input type="hidden" id="whercol" runat="server" /> 
     <input type="hidden" id="hiddendateformat" runat="server" /> 
       <input type="hidden" id="subagencycode" runat="server" /> 
	         <input type="hidden" id="hdnagency" runat="server" />
	          <input type="hidden" runat="server" id="executedeletesaveoperation" />
	           <input type="hidden" runat="server" id="tablefield" />
	             <input type="hidden" runat="server" id="modifyoperation" />
	        <input type="hidden" runat="server" id="hdnduplicacy" />
	        <input type="hidden" runat="server" id="cheakorclsql" />
	          <input type="hidden" runat="server" id="cheakorclsql1" />
	         </form>
</body>
</html>
