<%@ Control Language="C#" AutoEventWireup="true" CodeFile="openlayout1.ascx.cs" Inherits="openlayout1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    <script type="text/javascript" src="js/ctrl.js"></script>

<div id="opendialog1" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
    border-right: double 7px #4a84ff; width: 207px;height:357px;left: 2px;" unselectable="on">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <table id="layouttab" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="images/Open-Template.jpg" usemap="#closemapo1" width="203px" unselectable=on  />
                <map id="closemapo1" name="closemapo1" class="handcursor">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closepropO1();" />
                </map>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" style="top: 5px">
                    <tr>
                        <td colspan="2" style="height: 25px; font-family: Verdana; font-weight: normal; font-size: 11px;
                            background-color: ButtonFace">
                            Select the Template given Below:</td>
                    </tr>
                    
                    <tr>
                <td>
         <asp:Label ID="lblcatname" runat="server" CssClass="proplbl" Style="left: -4px; top: 44px" Text="Category" Width="62px"></asp:Label>
         <asp:DropDownList ID="catname" runat="server"   CssClass="dropdowns" Width="82px"></asp:DropDownList>
         </td>
                    
                    <tr>
                        <td>
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                    <asp:ListBox ID="xmllist1" runat="server" CssClass="listbox" Width="193px" Height="262px" AutoPostBack="false" OnSelectedIndexChanged="xmllist_SelectedIndexChanged"></asp:ListBox>
                                <%--</ContentTemplate>
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
                                    <input type="button" id="cancelL" value="Close" onclick="document.getElementById('opendialog1').style.display='none';"
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
                        <input type="hidden" id="getslcthtml" runat="server" />
                        <input type="hidden" id="Hiddeniru" runat="server" />
                        <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
</div>
