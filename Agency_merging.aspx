<%@ Page Language="C#" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="Agency_merging.aspx.cs" Inherits="Agency_merging" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agency Merging</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="javascript/Agenmerging.js"></script>
    <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
</head>
<body  style="background-color:#f3f6fd;margin:0px 0px 0px 0px" >
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div id="divagn"style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:2;">
   <table cellpadding="0" cellspacing="0"><tr><td>
   <asp:UpdatePanel  ID="UpdatePanel71" runat="server"><ContentTemplate>
   <asp:ListBox ID="lstagn" Width="700px" Height="300px"
runat="server" CssClass="btextlist121" >
   </asp:ListBox></ContentTemplate></asp:UpdatePanel></td></tr></table></div>
   
    <div id="div1"style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:2;">
   <table cellpadding="0" cellspacing="0"><tr><td>
   <asp:UpdatePanel  ID="UpdatePanel1" runat="server"><ContentTemplate>
   <asp:ListBox ID="agecy" Width="500px" Height="200px"
runat="server" CssClass="btextlist121" ></asp:ListBox></ContentTemplate></asp:UpdatePanel></td></tr></table></div>

    <table id="OuterTable"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Opening Balance Entry"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					
				</tr>
			</table>
			
			<table border="0" cellpadding="0" cellspacing="0" style="width:100% ;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Agency Merging</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
    <table align="center"><%--<tr>--%>
                <tr>
                <td style="height: 19px"><asp:label id="lblagencytype" runat="server" CssClass="TextField"></asp:label></td>
                <td style="height: 19px" colspan="4"><asp:DropDownList ID="drpagencytype" css="dropdown" runat="server">
                <asp:ListItem Value="P">Parent</asp:ListItem>
                <asp:ListItem Value="C">Child</asp:ListItem></asp:DropDownList></td>
                </tr>
            
                <tr>
                <td style="height: 19px"></td>
                <td style="height: 19px"><b><asp:label id="agencyn" runat="server" CssClass="TextField"></asp:label></b></td>
                <td style="height: 19px"><b><asp:label id="agencyc" runat="server" CssClass="TextField"></asp:label></b></td>
                <td style="height: 19px"><b><asp:label id="agencysc" runat="server" CssClass="TextField"></asp:label></b></td>
                <td style="height: 19px"><b><asp:label id="agencyssc" runat="server" CssClass="TextField"></asp:label></b></td>

                </tr>
                
            <tr runat="server" id="tdpagency" ><%--style="display:block"--%>
                <td style="height: 19px"><asp:label id="lblparentagency" runat="server" CssClass="TextField"></asp:label></td>
                <td style="height: 19px"><asp:textbox id="txtpagname" runat="server" Enabled=false CssClass="btext" Width="250px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox id="txtpagcode" Enabled="false" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox id="txtpagsubcode" Enabled="false" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox id="txtpcodesubcode" Enabled="false" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
            </tr>
            
            <tr>
                <td style="height: 19px"><asp:label id="lbagency" runat="server" CssClass="TextField"></asp:label></td>
                <td style="height: 19px"><asp:textbox id="txtagency" runat="server" CssClass="btext" Width="250px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox id="txtagcode" Enabled="false" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox id="txtagsub" Enabled="false" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox id="txtcosubco" Enabled="false" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
            </tr>
            <tr>
             
                <td><asp:label id="lblfagalert" runat="server" CssClass="TextField"></asp:label></td>
                <td><asp:TextBox ID="txtfagalert" Width="250px" Enabled="false"  runat="server" CssClass="btextnarpro" TextMode="MultiLine" ></asp:TextBox></td>
               <td><asp:label id="lblfcommper" runat="server"  CssClass="TextField"></asp:label></td>
               <td><asp:textbox id="txtfcommper" Enabled="false" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
              <td></td>
               </tr>
             <tr>
             
                <td style="height: 19px"><asp:label id="Aggency" runat="server" Text="Agency Address" CssClass="TextField"></asp:label></td>
                <td colspan="4"><asp:TextBox ID="TextBox1" Width="515px" Enabled="false"  runat="server" CssClass="btextnarpro" TextMode="MultiLine" >
                </asp:TextBox></td>
                <%--<td></td>
              <td></td>
              <td></td>--%>
               </tr>
               <%--</tr>--%>
            <tr>
                <td style="height: 19px"><asp:label id="lbagency1" runat="server" CssClass="TextField"></asp:label></td>
                <td style="height: 19px"><asp:textbox id="txtagency1" runat="server" CssClass="btext" Width="250px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox  Enabled="false" id="txtagcode1" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox Enabled="false" id="txtagsub1" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
                <td style="height: 19px"><asp:textbox Enabled="false" id="txtcosubco1" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
            </tr>
             <tr>
             
                <td><asp:label id="lbltagalert" runat="server" CssClass="TextField"></asp:label></td>
                <td><asp:TextBox ID="txttagalert" Width="250px" Enabled="false"  runat="server" CssClass="btextnarpro" TextMode="MultiLine" ></asp:TextBox></td>
               <td><asp:label id="lbltcommper" runat="server"  CssClass="TextField"></asp:label></td>
               <td><asp:textbox id="txttcommper" Enabled="false" runat="server" CssClass="btext" Width="80px"></asp:textbox></td>
              <td></td>
               </tr>
            <tr>
             
                <td style="height: 19px"><asp:label id="Label1" runat="server" Text="Agency Address" CssClass="TextField"></asp:label></td>
                <td colspan="4"><asp:TextBox ID="TextBox2" Enabled="false" Width="515px" runat="server" CssClass="btextnarpro" TextMode="MultiLine"  Rows="2">
                </asp:TextBox></td>
                <%--<td></td>
              <td></td>--%>
               </tr>
            <tr>
                <td rowspan="2" style="width: 159px;height: 40px;"><asp:label id="lbremark" runat="server" CssClass="TextField"></asp:label></td>
                <td  rowspan="2" colspan="4"><asp:UpdatePanel ID="UpdatePanel19" runat="server">
                <ContentTemplate><asp:TextBox ID="txtremark" Width="515px" runat="server" CssClass="btextnarpro" MaxLength="199"  Rows="2" TextMode="MultiLine">
                </asp:TextBox></ContentTemplate></asp:UpdatePanel></td>                               
            </tr>
            <tr>
            <td>&nbsp;</td></tr>
            <tr>
            <td></td>
            <td>
            <asp:Button id="btnProcess" runat="server" Font-Size="Medium" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:Button>
            <asp:Button id="btnCancel" runat="server"  Font-Size="Medium" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:Button>
            <asp:Button id="btnexit" runat="server" Font-Size="Medium" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:Button>
            </td>

            </tr>
							</table>
    
    
    <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"/>
    <input id="hdnuserid" type="hidden" size="1" name="Hidden2" runat="server"/>
    
    </form>
</body>
</html>
