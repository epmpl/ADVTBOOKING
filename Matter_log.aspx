<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Matter_log.aspx.cs" Inherits="Matter_log" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MatterLog</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/matterlog.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div2" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstuser" Width="400px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
				 <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Booking Audit"></uc1:topbar></td>
    </tr>
    
    </table>
    <table width="65%" border="0" cellspacing="0" cellpadding="0" align="center" style=" margin-top:60px">
   <%-- <tr><td><asp:Label ID="lbl" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:TextBox ID="txt_agency" runat="server" CssClass="btext1" ></asp:TextBox></td>
    
    <td><asp:Label ID="Label1" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:TextBox ID="TextBox1" runat="server" CssClass="btext1" ></asp:TextBox></td>
    </tr>--%>
    <tr>
                                                <td align="left" style="display:none">
                                                    <asp:Label ID="lbl_printcent" runat="server" CssClass="TextField" ></asp:Label>
                                                </td>
                                                <td align="left" style="display:none">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                    <asp:DropDownList ID="dpd_printcent" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                    <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbl_branch" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                    <asp:DropDownList ID="dpd_branch" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                    <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
    <tr><td><asp:Label ID="lbluserid" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:TextBox ID="txtusrid" runat="server" CssClass="btext1" ></asp:TextBox></td>
    <td><asp:Label ID="lblusrnam" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:TextBox ID="txtusrnam" runat="server" CssClass="btext1" ></asp:TextBox></td>
    </tr>
    <tr><td><asp:Label ID="lblfrmdt" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:TextBox ID="txtfrmdat" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"   AutoPostBack="True"></asp:TextBox>
     
      <img alt="Calender"  src='Images/cal1.gif' id="dav2" onclick='popUpCalendar(this, form1.txtfrmdat, "mm/dd/yyyy")'  height="14" width="14"/></td>
    <td><asp:Label ID="lbltodt" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:TextBox ID="txttodt" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"   AutoPostBack="True"></asp:TextBox>
     
      <img alt="Calender"  src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, form1.txttodt, "mm/dd/yyyy")'  height="14" width="14"/></td>
    </tr>
    <tr>
    <td><asp:Label ID="lblmainlog" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:DropDownList ID="ddlmainlog" runat="server" CssClass="dropdown"></asp:DropDownList></td>
    <td><asp:Label ID="lblbukid" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:TextBox ID="txtbukid" runat="server" CssClass="btext1" Enabled="true"    AutoPostBack="True"></asp:TextBox>
     
    </tr>
    <tr><td>&nbsp;</td></tr>
    </table>
    <table width="40%" border="0" cellspacing="0" cellpadding="0" align="center">
    
    <tr>
    <td></td><td></td>
    <td align="right">
        <asp:Button ID="btnrun" runat="server" Text="Import" CssClass="button1" />
        <asp:Button ID="btnclr" runat="server" Text="clear" CssClass="button1" />
        <asp:Button ID="btnexit" runat="server" Text="Exit" CssClass="button1" /></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    </table>
    <div id="Div1" runat="server"   style="width:90%;height:470px;overflow:auto;margin-left:30px">
          <table align="center">
          <tr>        
          <td runat="server" id="Td_supply_final" > </td>	 
         </tr>
          </table>
      </div>
    
    </div>
    <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
    <input id="hdnusrid" type="hidden" name="hiddendateformat" runat="server"/>
    <input id="hiddensessionuser" type="hidden" name="hiddendateformat" runat="server"/>
    </form>
</body>
</html>
