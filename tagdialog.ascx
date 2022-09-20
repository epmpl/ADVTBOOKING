<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tagdialog.ascx.cs" Inherits="tagdialog" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<div id="tagsdiv" class="dragprop" contenteditable="false" style="display: none;
    cursor: default; background-color: Buttonface; border-bottom: double 7px #4a84ff;
    border-top: double 7px #4a84ff; border-left: double 7px #4a84ff; border-right: double 7px #4a84ff;
    width: 207px; top: -83px; left: 2px">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" onclick="javascript:closetags();">
                <img src="images/Special-Tags.jpg" usemap="#closemaptag" alt="" style="cursor: hand; width: 205px;" unselectable="on" />
                <map id="closemaptag" name="closemaptag">
                    <area shape="rect" coords="188,15,200,2" alt="close" />
                </map>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="l2" runat="server" CssClass="proplbl" Text="Browse Images" Width="100px"></asp:Label>
            </td>
            <td colspan="2">
                <input type="button" id="browimg" runat="server" value="Browse" onclick="javascript:showupload1();" />
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="abc" runat="server" title="check here for Currency Library" onclick="javascript:showsymbol(this);" />
            </td>
            <td>
                <asp:Label ID="lbl1" runat="server" CssClass="proplbl" Text="Library" Width="90px"></asp:Label>
            </td>
        </tr>
        <%--<tr>Currency
        Style="left: 10px; top: 30px"
        style="width: 20px"
            <td colspan="2" style="width: 133px; height: 20px;">
                <input type="checkbox" id="tags" checked="checked" onclick="javascript:checktag();" />
                <asp:Label ID="Label7" runat="server" CssClass="proplbl" Text="Tags from Library"
                    Width="108px" Style="left: -4px; top: 44px"></asp:Label>
            </td>
        </tr>--%>
        <tr id="r1" style="display: block;">
            <td style="width: 65px">
                <asp:Label ID="Label9" runat="server" CssClass="proplbl" Style="left: -4px; top: 44px"
                    Text="Prefix" Width="62px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="prefix" runat="server" CssClass="dropdowns" Width="52px">
                    <asp:ListItem Value="$U" Selected="true">$U</asp:ListItem>
                    <asp:ListItem Value="Rp">Rp</asp:ListItem>
                    <asp:ListItem Value="$">$</asp:ListItem>
                    <asp:ListItem Value="CHF">CHF</asp:ListItem>
                    <asp:ListItem Value="Php">Php</asp:ListItem>
                    <asp:ListItem Value="R$">R$</asp:ListItem>
                    <asp:ListItem Value="€">€</asp:ListItem>
                    <asp:ListItem Value="¥">¥</asp:ListItem>
                    <asp:ListItem Value="£">£</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr id="r2" style="display: block;">
            <td style="width: 65px">
                <asp:Label ID="Label8" runat="server" CssClass="proplbl" Style="left: -4px; top: 44px" Text="Suffix" Width="62px"></asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdowns" Width="52px">
                    <asp:ListItem Value=".00">.00</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 65px">
                <asp:Label ID="Label1" runat="server" CssClass="proplbl" Style="left: -4px; top: 30px"
                    Text="Amount" Width="100px"></asp:Label></td>
            <td style="height:auto; width:auto;">
                <input id="spltxt" type="text" onchange="return onlynos(this);" onkeypress="return numeric(event);" maxlength="7" class="btext" style="width: 80px" /></td>
        </tr>
        <tr>
            <td style="width: 65px">
            </td>
            <td align="left">
                <input type="hidden" id="arrayname" runat="server" class="inputhidden" /></td>
            <td align="left">
                <input type="hidden" id="path11" runat="server" class="inputhidden" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <input type="button" id="apply" value="Apply" class="inputbutton" onclick="javascript:spltags();" />
            </td>
        </tr>
    </table>
</div>
