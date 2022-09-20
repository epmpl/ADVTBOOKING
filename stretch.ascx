<%@ Control Language="C#" AutoEventWireup="true" CodeFile="stretch.ascx.cs" Inherits="stretch" %>
<div id="stretchdiv" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
    border-right: double 7px #4a84ff; width: 203px; top: -105px; left: 2px;" unselectable="on">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="images/Stretch-and-flip.jpg" usemap="#closemapstr" width="203px" unselectable=on  />
                <map id="closemapstr" name="closemapstr">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closestretch();"
                        style="cursor: hand;" />
                </map>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Stretch" CssClass="proplbl"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%--<input type="radio" id="Radio1" name="stretch" onclick="document.getElementById('ver').style.visibility='hidden';document.getElementById('hor').style.visibility='visible'" />--%>
                <asp:Label ID="Label2" runat="server" Text="Horizontal" CssClass="proplbl"></asp:Label>
            </td>
            <td>
                <input type="text" id="hor" class="proptextsmall" maxlength="3" onkeypress="return onlynos(this);"
                    onblur="javascript:stretch_horizontal();" /></td>
        </tr>
        <tr>
            <td>
                <%-- <input type="radio" id="Radio2" name="stretch" onclick="document.getElementById('hor').style.visibility='hidden';document.getElementById('ver').style.visibility='visible'" />--%>
                <asp:Label ID="Label3" runat="server" Text=" Vertical" CssClass="proplbl"></asp:Label>
            </td>
            <td>
                <input type="text" id="ver" class="proptextsmall" maxlength="3" onkeypress="return onlynos(this);"
                    onblur="javascript:stretch_vertical();" /></td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Flip"></asp:Label></td>
        </tr>--%>
        <tr>
            <%--<td>
                <input type="radio" id="horf" name="flip" /><asp:Label ID="Label5" runat="server"
                    CssClass="proplbl" Text="Horizontal"></asp:Label><br />
                <%-- <input type="radio" id="Verf" name="flip" /><asp:Label ID="Label6" runat="server"
                    CssClass="proplbl" Text=" Vertical"></asp:Label>
            </td>--%>
            <td>
                <input type="button" value="Ok" style="width: 60px" class="inputbutton" onclick="javascript:flipHor(); document.getElementById('stretchdiv').style.display='none';" /></td>
        </tr>
    </table>
</div>
