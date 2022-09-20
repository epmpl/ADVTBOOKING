<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QBCDETAIL.aspx.cs" Inherits="QBCDETAIL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Discount/Premium</title>
        <script language="javascript" src="javascript/qbcdetail.js" type="text/javascript"></script>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
</head>
<body onkeydown="javascript:return tabvalue(event);" style="margin-top:0px;" >
    <form id="form1" runat="server">
     <div id="divretainer" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstretainer" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divproduct" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstproduct" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divexec" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstexec" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
    <div>
<table>
<tr><td CssClass="TextField" colspan="6"><b><u>Discount/Premium</u></b></td></tr>
    <tr>
        <td valign="top">
        <asp:Label ID="lbececname" runat="server" CssClass="TextField" Text="Executive Name"></asp:Label></td>
        <td valign="top" id="tdexec">                                            
        <asp:TextBox ID="txtexecname" runat="server" CssClass="btextforbook" MaxLength="50" Enabled="True"></asp:TextBox></td>
        <td>
        </td>
        <td valign="top">
        <asp:Label ID="lbexeczone" runat="server" Text="Executive Zone" CssClass="TextField"></asp:Label></td>
        <td valign="top">
        <asp:TextBox ID="txtexeczone" runat="server" CssClass="btextforbook" ReadOnly="True" Enabled="False"></asp:TextBox></td>
</tr>
<tr>
     <td>
     <asp:Label ID="lblretainer" runat="server" CssClass="TextField" Text="Retainer"></asp:Label></td>
     <td valign="top" id="tdretainer">                                                                           
     <asp:TextBox ID="drpretainer" runat="server" CssClass="btextforbook" Enabled="True" MaxLength="50"></asp:TextBox></td>
     <td></td>
     <td>
    <asp:Label ID="lbpageprem" runat="server" CssClass="TextField" Text="Page Premium"></asp:Label></td>
    <td>
    <asp:DropDownList ID="drppageprem" runat="server" CssClass="dropdownforbook" Enabled="True"></asp:DropDownList></td>
  
</tr>
<tr>
    <td>
    <asp:Label ID="lblRetainercomm" runat="server" CssClass="TextField" Text="Retainer Comm."></asp:Label></td>
    <td>
    <asp:TextBox ID="txtRetainercomm" CssClass="btextforbookrightsmall"  runat="server" Enabled="False"
                                                            MaxLength="10"></asp:TextBox></td>
    <td>
    </td>
    <td>
     <asp:Label ID="lbpremium" runat="server" CssClass="TextField" Text="Premium(%)"></asp:Label></td>
    <td>
     <asp:TextBox ID="txtpremper" runat="server" CssClass="btextforbookrightsmall" Enabled="False"></asp:TextBox></td>
</tr>
<tr>
    <td>
    <asp:Label ID="lbproduct" runat="server" CssClass="TextField" Text="Product"></asp:Label></td>
    <td>
    <asp:TextBox ID="txtproduct" runat="server" CssClass="btextforbook" MaxLength="50"></asp:TextBox></td>
    <td></td>
      <td>
    <asp:Label ID="lblpaymenttype" runat="server" CssClass="TextField" Text="Payment Type"></asp:Label></td>
    <td>
    <asp:DropDownList ID="drppaymenttype" runat="server" CssClass="dropdownforbook" Enabled="True">
    </asp:DropDownList></td>
</tr>
<tr id="Agreedamt" runat="server" >
     <td>
    <asp:Label ID="lbagreamo" runat="server" CssClass="TextField" Text="Agreed Amount"></asp:Label></td>
    <td>
    <asp:TextBox ID="txtagreedamt" onpaste="return false;" style="text-align:right" CssClass="btextforbook" onkeypress="return rateenter(event);"   runat="server" Enabled="True"
    MaxLength="10"></asp:TextBox></td>
    <td></td>
    <td>
    <asp:Label ID="lbspechar" runat="server" CssClass="TextField" Text="Special Charges"></asp:Label></td>
    <td>
    <asp:TextBox ID="txtextracharges" CssClass="btextforbook" style="text-align:right" onkeypress="return rateenter(event);" runat="server" Enabled="True"
    MaxLength="10"></asp:TextBox>
    </td>
</tr>
<tr id="Specialamt" runat="server" >
    <td>
    <asp:Label ID="lbspecialamo" runat="server" CssClass="TextField" Text="Special Discount"></asp:Label></td>
    <td>
    <asp:TextBox ID="txtspedisc" CssClass="btextforbook" style="text-align:right" onkeypress="return rateenter(event);" runat="server" Enabled="True"
    MaxLength="10"></asp:TextBox></td>
    <td>
    </td>
    <td>
    <asp:Label ID="lbspediscper" runat="server" Text="Special Discount(Per)" CssClass="TextField"></asp:Label></td>
    <td>
    <asp:TextBox ID="txtspediscper" runat="server" onkeypress="return rateenter(event);" CssClass="btextforbook" style="text-align:right" Enabled="True"
    MaxLength="10"></asp:TextBox></td>
</tr>



<tr>
    <td>
                                                <asp:Label ID="lbpagepost" runat="server" CssClass="TextField" Text="Page Position"></asp:Label></td>
                                            <td>
                                              
                                                        <asp:DropDownList ID="drppageposition" runat="server" CssClass="dropdownforbook"
                                                            Enabled="true">
                                                        </asp:DropDownList>
                                            </td>
    <td></td>
                                            <td>
                                                <asp:Label ID="lbpagepostamt" runat="server" CssClass="TextField" Text="Post Prem. Amt."></asp:Label></td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtpageamt" runat="server" CssClass="btextforbook" Enabled="false"></asp:TextBox>
                                                    
                                            </td>
</tr>
<tr>
                                            <td>
                                                <asp:Label ID="lblclientcatdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtclientcatdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td><td></td>                                            
                                            <td>
                                                <asp:Label ID="lblclientcatamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtclientcatam" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblflatfreqdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtflatfreqdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td><td></td>                                            
                                            <td>
                                                <asp:Label ID="lblflatfreqamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtflatfreqamt" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcatdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcatdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td> <td></td>                                           
                                            <td>
                                                <asp:Label ID="lblcatamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcatamt" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>
                                            
                                        </tr>
<tr><td></td><td></td><td></td><td></td><td align="right"><asp:Button ID="btnok" runat="server" CssClass="buttonsmall"  Text="Submit" /></td></tr>
    </table>
    </div>
    <input type="hidden" id="hiddencompcode" runat="server" />
    <input type="hidden" id="hiddencardrate" runat="server" />
    <input type="hidden" id="txtdatetime" runat="server" />
    <input type="hidden" id="hiddendateformat" runat="server" />
    </form>
</body>
</html>
