<%@ Control Language="C#" AutoEventWireup="true" CodeFile="config.ascx.cs" Inherits="config" %>
<div id="configdiv" class="drag" contenteditable="false" style="display: none; cursor: default;
    background-color: Buttonface; border-bottom: double 7px black; border-top: double 7px black;
    border-left: double 7px black; border-right: double 7px black;" unselectable="on">
    <table>
    <tr>
    <td colspan="2">
                <img src="images/Configurationbar.jpg" usemap="#closemapconfig" />
                <map id="closemapconfig" name="closemapconfig">
                    <area shape="rect" coords="210,15,222,2" alt="close" href="javascript:closeconfigdiv();"
                        style="cursor: hand;" />
                </map>
            </td>
    </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Change location for Templates" CssClass="proplbl"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <input type="file" id="loc_file" style="width: 215px" class="button1" contenteditable="false" runat="server" />
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Change location for Images" CssClass="proplbl"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <input type="file" id="loc_pic" style="width: 215px" class="button1" contenteditable="false" runat="server" /></td>
        </tr>
        <tr>
            <td align="right">
                <input type="button" id="settingok" value="Ok" style="width: 66px" class="button1" runat="server" onserverclick="settingok_ServerClick" />
                <%--<input type="button" id="settingcancel" value="Cancel" style="width: 66px" onclick="javascript:closeme();"
                    class="button1" />--%></td>
        </tr>
    </table>
</div>
