<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Agency_EXL_Uploader.aspx.cs" Inherits="Agency_EXL_Uploader" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import Agency/ Client</title>
        <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
  
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
              <input type="hidden" id="hiddendateformat" runat="server" />
              <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div>
    <table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Import/Export Rate"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server" ></uc2:leftbar></td>
					<td valign="top">
				</tr>
	</table>
    </div>
    <div>
    <table align="center"      style="border: 4px solid #0066FF; margin-top:50px; caption-side: top;"> 
    <tr>
    <td colspan="4" align="center" bgcolor="#FAC5D8" 
            style="font-family: 'Arial Black'; font-size: x-large; font-weight: bold; color: #3366FF">&nbsp;Import Agency/Client</td>
    </tr>   
        <tr><td class="TextField" align="right">&nbsp;</td><td>
                                           <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel></td><td class="TextField" align="right">&nbsp;</td><td><asp:UpdatePanel ID="UpdatePanel8" runat="server"></asp:UpdatePanel></td></tr>
       <tr><td><asp:Label ID="Label1" runat="server" CssClass="TextField"> File Name<font color="red">*</font></asp:Label></td><td colspan=3><asp:FileUpload ID="FileUpload1" runat="server" />
        
       &nbsp;</td></tr>
       <tr>
       <td>
       <asp:RadioButton ID="RadioButton1" Checked="true" Text="Agency" GroupName="D" runat="server" /><asp:RadioButton Text="Client" GroupName="D" ID="RadioButton2" runat="server" />
       </td>
       </tr>
        <tr align="right"><td colspan="3" runat="server" id="td2"   >
          <asp:Button ID="btnupload" CssClass="button1" runat="server" Text="Upload Excel" onclick="btnupload_Click" Width="100px"  /><asp:Button ID="btnimport" CssClass="button1" runat="server" Text="Import" onclick="btnimport_Click"   Width="100px" /><asp:Button ID="bnnClear" CssClass="button1" runat="server" Text="Clear"  onclick="bnnClear_Click" Width="100px"  /></td>
        </tr>
      <tr align="right">
          <td class="style1"  colspan='2' align="left"><asp:Label ID="Label2" runat="server"  CssClass="TextField"></asp:Label></td><td class="style1" colspan="2" align="center">
          
        </tr>
       
        <%--<tr>
        <td colspan="4" align="center"> <asp:Button ID="btnupload" runat="server" Width="200px" Text="Upload Excel"  
                                     CssClass="topbutton" BackColor="LightSteelBlue" onclick="btnupload_Click" ></asp:Button></td>
        </tr>--%>
              </table>
     <table align="center"      style="margin-top:50px; caption-side: top;"> 
     <tr>
        <td align="center"><asp:Label ID="lblerror" runat="server" style="color:Red" CssClass="TextField"></asp:Label></td>
        </tr>
    </table>
    </div>
     <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>  <input type="hidden" id="packagecode1" runat="server" /></ContentTemplate> </asp:UpdatePanel>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>  <input type="hidden" id="hiddenadcategary" runat="server" /></ContentTemplate> </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>  <input type="hidden" id="Hiddenumo" runat="server" /></ContentTemplate> </asp:UpdatePanel>
     
    </form>
    
    <input type="hidden" id="hiddencompcode" runat="server" />
        <input type="hidden" id="hiddenuserid" runat="server" />
       

</body>

          
</html>
