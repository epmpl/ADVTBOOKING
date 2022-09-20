<%@ Control Language="C#" AutoEventWireup="true" CodeFile="open_ads.ascx.cs" Inherits="open_ads" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<div id="openaddialog" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
    border-right: double 7px #4a84ff; width: 207px;height:352px;left: 2px;" unselectable="on">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <table id="layouttab" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="images/open-ad.jpg" usemap="#closemapoad" width="203px" unselectable=on  />
                <map id="closemapo" name="closemapoad" class="handcursor">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closepropoad();" />
                </map>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" style="top: 5px">
                    <tr>
                        <td colspan="2" style="height: 25px; font-family: Verdana; font-weight: normal; font-size: 11px;
                            background-color: ButtonFace">
                            Select the Ads given Below:</td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                    <asp:ListBox ID="xmllist3" runat="server" CssClass="listbox" Width="193px" Height="262px"
                                        ></asp:ListBox>
                               <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                </table>
                <%--</div>--%>
            </td>
            <%--<td align="center" style="padding-left: 10px; background-color:ButtonFace">
                <br />
                    <iframe id="preview" runat="server" style=" background-color:ButtonFace ;height : 331px; width: 630px; overflow: scroll"
                        contenteditable="false"></iframe>
                </td>--%>
        </tr>
        <tr>
            <td align="right">
                <table align="right">
                    <tr>
                        <%--<td align="right">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="openL" Text="Open" CssClass="topbutton" runat="server" OnClick="openL_Click" /></ContentTemplate>
                                </asp:UpdatePanel>
                            </td>--%>
                        <td align="right">
                            <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>--%>
                                    <input type="button" id="cancelL" value="Ok" onclick="document.getElementById('openaddialog').style.display='none';"
                                        class="inputbutton" /><%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                            <%--javascript:closeme();--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right">
                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
                        <input type="hidden" id="getslcthtml" runat="server" /><%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
</div>
