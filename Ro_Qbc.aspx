<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ro_Qbc.aspx.cs" Inherits="Ro_Qbc" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
         <script type="text/javascript" language="javascript" src="javascript/Roav_qbc.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/prototype.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript">
		
		
		function onlynum(event) {
   
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
            return true;
        }
        else {
            return false;
        }
    }
}

	</script>
		<link href="css/Roavqbc.css" type="text/css" rel="stylesheet" />
		<link href="css/main.css" type="text/css" rel="stylesheet" />
</head>


<body onload="first(event);" onkeydown="tabval(event);">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scrptmng" runat="server"></asp:ScriptManager>
    <div id="divagn" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:2;">
    <table cellpadding="0" cellspacing="0"><tr><td>
    <asp:UpdatePanel  ID="UpdatePanel71" runat="server"><ContentTemplate>
    <asp:ListBox ID="lstagn" Width="700px" Height="300px" runat="server" CssClass="btextlist121" >
    </asp:ListBox>
    <%--<asp:Button ID="buttonlist1" runat="server" text="More" />--%>
    </ContentTemplate></asp:UpdatePanel></td></tr></table></div> 
    
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ro Qbc Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="outrtblav" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbtnav"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbtnav" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbtnav" runat="server"  Font-Size="XX-Small" BackColor="Control"
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
			<div>
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>RO Book Issue Entry</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            
            <table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
										<tr>
											<td><asp:label id="lblagnm" runat="server" CssClass="LblFldav"></asp:label></td>
											<td colspan=3 ><asp:textbox  id="txtagnm" runat="server" Width="375px" CssClass="text1" 
													></asp:textbox></td>
											
										</tr>
										<tr>
											<td><asp:label id="lblisudt" runat="server" CssClass="LblFldav"></asp:label></td>
											<td ><asp:textbox Width="138px" id="txtisudt" runat="server" CssClass="text1"></asp:textbox>
											<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtisudt, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
											</td>
											
												<td><asp:label id="lblisuno" runat="server" CssClass="LblFldav"></asp:label></td>
											<td ><asp:textbox Width="138px" id="txtisuno" runat="server" CssClass="text1"></asp:textbox></td>
											
										</tr>
										<tr>
											<td><asp:label id="lblfrmno" runat="server" CssClass="LblFldav"></asp:label></td>
											<td ><asp:textbox Width="138px" id="txtfrmno" runat="server" MaxLength="38" CssClass="text1" onkeypress="return onlynum(event);"></asp:textbox></td>
											<td><asp:label id="lbltlrono" runat="server" CssClass="LblFldav"></asp:label></td>
											<td ><asp:textbox Width="138px" id="txtlrono" onkeypress="return onlynum(event);" runat="server" MaxLength="38" CssClass="text1"></asp:textbox></td>
											
										</tr>
										<tr>
											<td><asp:label id="lblstatus" runat="server" CssClass="LblFldav"></asp:label></td>
											<td><asp:dropdownlist id="ddlstatus" runat="server" width="144px" CssClass="drpdwn">
                                                </asp:dropdownlist></td>


                                            <td><asp:label id="lblagenexec" runat="server" CssClass="LblFldav"></asp:label></td>
											<td><asp:dropdownlist id="drpagenexec" runat="server" width="144px" CssClass="drpdwn">
                                                </asp:dropdownlist></td>
											
											
										</tr>
										
										
									</table>
		
									
									
    
    </div>
    <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hdnuserid" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hdnagcod" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hdnsav" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hdnsavsql" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hidsysdate" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hdnsav2" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="whercol" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hidsysdatesql" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hdnexecut" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hdncon" type="hidden" size="1" name="Hidden2" runat="server"/>
    </form>
</body>
</html>
