<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fileupload.aspx.cs" Inherits="fileupload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert Image</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />

    <script src="js/ctrl.js" type="text/javascript"></script>

    <script src="js/enterortab.js"></script>

</head>
<body  onload="javascript:toggle(); ">
    <form id="form1" runat="server">
        <div>
            <table onkeydown="javascript:tabvalue();">
                <%--<tr>
                <td colspan="4">bgcolor="ButtonFace"
                <img src="images/new-document.jpg" usemap="#closemapM" />
                <map id="closemapM" name="closemapM" class="handcursor">
                    <area shape="rect" coords="210,15,222,2" alt="close" href="javascript:closepropM();" />
                </map>
            </td>
        </tr>--%>
                <tr>
                    <td>
                    
                        <asp:Label ID="label0" Text="Location" CssClass="proplbl" runat="server"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="insertimage"></asp:RequiredFieldValidator></td>
                    <td colspan="3">
                        <input type="file" id="insertimage" accept="jpeg" class="topbutton" style="width: 240px"
                            runat="server" />
                    </td>
                    <td>
                        
                        <input type="button" id="okupload" value="Ok" class="inputbutton" style="width: 61px"
                            onserverclick="okupload_ServerClick" runat="server" tabindex="7" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:Label ID="Label1" Text="Name of image" CssClass="proplbl" runat="server"></asp:Label>--%>
                    </td>
                    <td>
                    </td>
                    <td colspan="3">
                       <%-- <input type="text" id="alternatetxt" class="btextlarge" runat="server" tabindex="1"
                            maxlength="20" />--%>
                    </td>
                    <td>
                        <input type="button" id="cancelupload" value="Cancel" class="inputbutton" onclick="javascript:closeme();"
                            runat="server" tabindex="8" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" CssClass="proplbl" Text="Size" Width="82px"></asp:Label></td>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButton CssClass="proplbl" ID="fit_t_bx" runat="server" Text="Fit to Box"
                            TabIndex="6" Checked="true" GroupName="size" /></td>
                    <td colspan="2">
                        <asp:RadioButton CssClass="proplbl" ID="actual_s" runat="server" Text="Actual Size"
                            TabIndex="6" GroupName="size" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Margin"></asp:Label></td>
                    <td>
                    </td>
                    <td colspan="5">
                        <asp:CheckBox CssClass="proplbl" ID="selectmargin" runat="server" Text="Please checked it, If apply Margin"
                            TabIndex="6" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" Text="Right" CssClass="proplbl" runat="server"></asp:Label></td>
                    <td>
                    </td>
                    <td>
                        <input type="text" id="rght" class="btext" style="width: 70px" runat="server" tabindex="3"
                            onchange="return onlynos(this);"  onkeypress="return numeric(event);" maxlength="3" /></td>
                    <td>
                        <asp:Label ID="Label5" Text="Top" CssClass="proplbl" runat="server" Width="69px"></asp:Label></td>
                    <td style="width: 90px">
                        <input type="text" id="top" class="btext" style="width: 69px" runat="server" tabindex="5"
                            onchange="return onlynos(this);"  onkeypress="return numeric(event);" maxlength="3" /></td>
                </tr>
                <tr>
                    <td style="height: 21px">
                        <asp:Label ID="Label4" Text="Left" CssClass="proplbl" runat="server"></asp:Label></td>
                    <td style="height: 21px">
                    </td>
                    <td style="height: 21px">
                        <input type="text" id="left" class="btext" style="width: 70px" runat="server" tabindex="3"
                            onchange="return onlynos(this);"  onkeypress="return numeric(event);" maxlength="3" />
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" CssClass="proplbl" Text="Bottom" Width="69px"></asp:Label></td>
                    <td>
                        <input type="text" id="btm" class="btext" style="width: 69px" runat="server" tabindex="5"
                            onchange="return onlynos(this);"  onkeypress="return numeric(event);" maxlength="3" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" Text="Border Size" CssClass="proplbl" runat="server" Width="82px"></asp:Label></td>
                    <td>
                    </td>
                    <td>
                        <input type="text" id="imgbrdr" class="btext" style="width: 70px" runat="server"
                            tabindex="4" onchange="return onlynos(this);"  onkeypress="return numeric(event);" maxlength="3" /></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <input type="hidden" id="hidctrl" runat="server" />
                        <input type="hidden" id="insimage" runat="server" />
                        
                       
                    </td>
                    <%--<td colspan="4">
                        <asp:Label ID="labelcheck" Text="Please checked it to Apply in Background" runat="server"></asp:Label>
                    </td>--%>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
