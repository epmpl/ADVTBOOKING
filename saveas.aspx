<%@ Page Language="C#" AutoEventWireup="true" CodeFile="saveas.aspx.cs" ValidateRequest="false"
    Inherits="saveas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Save As :: Admaking</title>

    <script type="text/javascript" src="js/ctrl.js"></script>

    <script type="text/javascript" src="js/enterortab.js"></script>

    <link rel="stylesheet" type="text/css" href="css/main.css" />
</head>
<body onkeydown="javascript:tabvalue();" style="background-color: ButtonFace" onload="document.getElementById('filename').focus;document.getElementById('savexml').value = opener.document.getElementById('editordivxml').value;document.getElementById('savehtml').value = opener.document.getElementById('editordivhtml').value;document.getElementById('completehtml').value=opener.document.getElementById('editordivfullhtml').value">
    <form id="form1" runat="server">
        <div>
            <table>
            
            
            <tr>
                   <td style="height: 33px"><asp:Label ID="cname" runat="server" CssClass="proplbl" Width="90px">Category</asp:Label>
                   <asp:DropDownList ID="drpcat" runat="server" CssClass="dropdowns" Width="145px" Height="30px"></asp:DropDownList>
                  </td>
               </tr>
            
             <tr>
                <td style="height: 7px"><asp:Label ID="mylabel" runat="server" CssClass="proplbl" Width="90px">TemplateName</asp:Label>
                    <asp:TextBox ID="filename" runat="server" CssClass="btext" MaxLength="30" Width="141px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="filename"></asp:RequiredFieldValidator>
                </td>
             </tr>
             <tr><td></td></tr>
             <tr>
               <td>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="submit" value="SaveAs" class="button1" id="saveT" style="width: 77px" runat="server" onserverclick="saveT_onclick" tabindex="0" />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" value="Cancel" class="button1" id="Button1" tabindex="2" style="width: 77px" onclick="javascript:closeme();" />
               </td>
             
             </tr>
            
            
                <%--<tr>
                    <td style="width: 100px">
                        <asp:Label ID="mylabel" runat="server" CssClass="proplbl" Width="138px">New Name of Template</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 153px">
                        <asp:TextBox ID="filename" runat="server" Width="100px" Height="17px" MaxLength="30" CssClass="btext" ToolTip="Name of template"></asp:TextBox></td>
                        <%--<asp:TextBox ID="TextBox1" runat="server" Width="100px" CssClass="btext" ToolTip="Name of template"></asp:TextBox>--%>
                    <%--<td>
                        <asp:RequiredFieldValidator ID="Name_Required" runat="server" ErrorMessage="*" ControlToValidate="filename"></asp:RequiredFieldValidator></td>
                </tr>--%>
                <%--<tr>
                    <td>
                        <asp:DropDownList ID="ddl" runat="server" Width="154px" CssClass="dropdowns">
                            <asp:ListItem Value="XML" Selected="True">*.XML(xml document)</asp:ListItem>
                            <asp:ListItem Value="PDF">*.PDF</asp:ListItem>
                            <asp:ListItem Value="PS">*.PS</asp:ListItem>
                            <asp:ListItem Value="JPG">*.jpg</asp:ListItem>
                            <asp:ListItem Value="GIF">*.gif</asp:ListItem>
                            <asp:ListItem Value="PNG">*.png</asp:ListItem>
                            <asp:ListItem Value="TIF">*.tif</asp:ListItem>
                            <asp:ListItem Value="BMP" Enabled="false">*.bmp</asp:ListItem>
                            <asp:ListItem Value="WMF" Enabled="false">*.wmf</asp:ListItem>
                            <asp:ListItem Value="TXT" Enabled="false">*.txt</asp:ListItem>
                            <asp:ListItem Value="PCX" Enabled="false">*.pcx</asp:ListItem>
                            <asp:ListItem Value="EMF" Enabled="false">*.emf</asp:ListItem>
                            <asp:ListItem Value="TGA" Enabled="false">*.tga</asp:ListItem>
                            <asp:ListItem Value="JP2" Enabled="false">*.jp2</asp:ListItem>
                            <asp:ListItem Value="PNM" Enabled="false">*.pnm</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        <input type="hidden" id="xmlval" runat="server" />
                        <input type="hidden" id="temp_id" runat="server" />
                        <input type="hidden" id="completehtml" runat="server" />
                        <input id="savehtml" runat="server" type="hidden" />
                        <input id="savexml" runat="server" type="hidden" />
                        <input id="uomhidden" runat="server" type="hidden" />
                        <input id="newhtml" runat="server" type="hidden" />
                        <input type="hidden" id="adwidth" runat="server" />
                        <input type="hidden" id="adheight" runat="server" />
                        <input type="hidden" id="saveastype" runat="server" />
                    </td>
                    
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
