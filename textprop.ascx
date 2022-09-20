<%@ Control Language="C#" AutoEventWireup="true" CodeFile="textprop.ascx.cs" Inherits="textprop" %>

<script type="text/javascript" src="js/201a.js"></script>

<script type="text/javascript" src="js/enterortab.js"></script>

<div id="textdialog" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
    border-right: double 7px #4a84ff; width: 207px; top: -32px; left: 2px" unselectable="on" onkeydown="javascript:tabvalue();">
 <%-- onpropertychange="javascript:onloadtxt();"> --%>
    <table  cellpadding="0" cellspacing="0" unselectable="on">
        <tr>
            <td colspan="2">
                <img src="images/Text-box-properties.jpg" usemap="#closemapT" width="203px" unselectable="on" />
                <map id="closemapT" name="closemapT">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closeprop();"
                        style="cursor: hand;" />
                </map>
            </td>
        </tr>
        <tr>
            <td unselectable="on">
                <asp:Label ID="change_case" Text="Change case" CssClass="proplbl" runat="server" Width="90px"></asp:Label>
            </td>
            <td align="left" style="height: 21px" unselectable="on">
                <select id="changecase" runat="server" style="width: 110px;" class="dropdowns" onchange="javascript:change_case();">
                    <option value="0" selected="selected">--Select--</option>
                    <option value="1">Sentence</option>
                    <option value="2">ALL CAPITAL</option>
                    <option value="3">all small</option>
                    <%--<option value =4>tOGGLe</option>--%>
                </select>
            </td>
        </tr>
        <tr unselectable="on">
            <td>
                <asp:Label ID="Label3" Text="Font Name" CssClass="proplbl" runat="server"></asp:Label>
            </td>
            <td align="left">
                <select id="fntname" runat="server" class="dropdowns" style="width: 110px;" >
                    <%-- <option>--Select--</option>
                    onchange="javascript:fontName();"
                    <option>Arial</option>
                    <option>Comic sans MS</option>
                    <option>Courier new</option>
                    <option>Tahoma</option>
                    <option>Times New Ro.</option>
                    <option>Verdana</option>--%>
                </select>
            </td>
        </tr>
        <tr unselectable="on">
            <td style="height: 20px">
                <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Size"></asp:Label>
            </td>
            <td align="left">
                <select id="fntsize" runat="server" class="dropdowns" style="width: 110px;" onchange="javascript:fontsize();">
                    <option>8</option>
                    <option>9</option>
                    <option>10</option>
                    <option>11</option>
                    <option>12</option>
                    <option>14</option>
                    <option>16</option>
                    <option>20</option>
                    <option>22</option>
                    <option>24</option>
                    <option>26</option>
                    <option>28</option>
                    <option>36</option>
                    <option>48</option>
                    <option>55</option>
                    <option>60</option>
                    <option>62</option>
                    <option>72</option>
                    <%--<option value=8>x-large</option>
                        <option value=9>xx-large</option>--%>
                </select>
            </td>
        </tr>
        <tr unselectable="on">
            <td style="height: 20px">
                <asp:Label ID="Label5" runat="server" CssClass="proplbl" Text="Align"></asp:Label>
            </td>
            <td>
              <select id="alignment" runat="server" class="dropdowns" style="width: 110px; z-index: 50;" onchange="javascript:alignText();">
                    <option selected="selected">left</option>
                    <option>right</option>
                    <option>center</option>
                    <option>justify</option>
                </select>
            </td>
        </tr>
        <tr unselectable="on">
            <td>
                <asp:Label ID="Label6" Text="Font color" CssClass="proplbl" runat="server"></asp:Label>
            </td>
            <td>
                <img name="clrpckr" src='icons/cpiksel.gif' onmouseover="javascript:roll_over('clrpckr','icons/cpiksel.gif');"
                    onmouseout="javascript:roll_over('clrpckr','icons/cpiksel.gif')" unselectable="on"
                    onclick="showColorGrid1('colorcode1',currentid);">
                <input type="text" id="sampleclrfont" class="btext" style="width: 20px; background-color: Black;"
                    contenteditable="false" />
                <input type="hidden" id="colorcode1" style="width: 5px" class="btext" />
            </td>
        </tr>
        <tr unselectable="on">
            <td>
                <asp:Label ID="Label1" Text="Back color" CssClass="proplbl" runat="server"></asp:Label>
            </td>
            <td>
                <img name="bckgrnd" src='icons/cpiksel.gif' onmouseover="javascript:roll_over('bckgrnd','icons/cpiksel.gif');"
                    onmouseout="javascript:roll_over('bckgrnd','icons/cpiksel.gif')" unselectable="on"
                    onclick="showColorGrid2('colorcode',currentid);">
                <input type="text" id="sampleclrbckT" name="sampleclrbck" class="btext" style="width: 20px;"
                    contenteditable="false" />
                <input type="hidden" id="colorcode" style="width: 5px" class="btext" contenteditable="false" /></td>
        </tr>
        <tr unselectable="on">
            <td colspan="2" style="height: 13px">
                <asp:Label ID="Label7" runat="server" CssClass="proplbl" Text="Size"></asp:Label>
            </td>
        </tr>
        <tr unselectable="on">
            <td style="height: 10px;">
                <asp:Label ID="Label8" runat="server" CssClass="proplbl" Text="Height"></asp:Label></td>
            <td style="height: 10px;">
                <input type="text" id="input_hght" style="width: 40px" class="btext" maxlength="6"
                  onkeypress="return numeric(event);" onchange="javascript:changeH();" /><span style="font-size: 9pt; font-family: Verdana"></span></td>
        </tr>
        <!--onblur="return onlynos(this);"-->
        <tr unselectable="on">
            <td align="left" style="height: 19px;">
                <asp:Label ID="Label9" runat="server" CssClass="proplbl" Text="Width"></asp:Label></td>
            <td style="height: 19px;">
                <input type="text" id="input_wdth" style="width: 40px" class="btext" maxlength="6"
                   onkeypress="return numeric(event);"  onchange="javascript:changeW();" /><span style="font-size: 9pt;
                        font-family: Verdana"></span></td>
        </tr>
           <tr>
              <td colspan="2">
                <asp:Label ID="Label14" runat="server" CssClass="proplbl" Text="Border"></asp:Label>
             </td>
          </tr>
        <tr unselectable="on">
            <td align="left">
                <asp:Label ID="Label11" runat="server" CssClass="proplbl" Text="Border Type"></asp:Label></td>
            <td>
                <select id="borderlist" runat="server" class="dropdowns" onchange="javascript:changeB();"
                    style="width: 78px">
                    <option>dashed</option>
                    <option>dotted</option>
                    <option>groove</option>
                    <option>inset</option>
                    <option>none</option>
                    <option>outset</option>
                    <option>ridge</option>
                    <option selected="selected">solid</option>
                </select>
            </td>
        </tr>
        <tr unselectable="on">
            <td align="left">
                <asp:Label ID="Label12" runat="server" CssClass="proplbl" Text="Border Color"></asp:Label></td>
            <td>
                <%--<input type="text" id="sampleclr1" class="btext" style="width: 32px" contenteditable="false" onclick ="javascript:borderclr();"/>--%>
                <img src='icons/cpiksel.gif' name="brdrclr" onmouseover="javascript:roll_over('brdrclr','icons/cpiksel.gif');"
                    onmouseout="javascript:roll_over('brdrclr','icons/cpiksel.gif')" unselectable="on"
                    onclick="showColorGrid3('colorcode1',currentid);">
                <input type="text" id="sampleclrbrdrT" name="sampleclrbrdr" class="btext" style="width: 20px;
                    background-color: Black;" contenteditable="false" />
                <input type="hidden" id="Hidden1" style="width: 7px" class="btext" /></td>
        </tr>
        <tr unselectable="on">
            <td align="left">
                <asp:Label ID="Label13" runat="server" CssClass="proplbl" Text="Border Size"></asp:Label></td>
            <td>
                <%--<asp:TextBox ID="bsize" Width=32px CssClass=btext Text=1 runat=server ></asp:TextBox>--%>
                <input type="text" id="bsize" style="width: 40px" class="btext" maxlength="5" onblur="javascript:changeBsize();"
                    onchange="return onlynos(this);" onkeypress="return numeric(event);" value="1" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" CssClass="proplbl" Text="Line Spacing"></asp:Label>
            </td>
            <td>
                <input type="text" id="txtlinespacing" style="width: 40px" class="btext" maxlength="5"
                    onblur="javascript:spacing();" onkeypress="return numeric(event);" value="1" />
            </td>
        </tr>
        <tr unselectable="on">
            <td style="background-position: top;">
                <input type="checkbox" id="dropcheck" value="drop" onclick="return dropcheck_onclick()" />
                <asp:Label ID="Label2" Text="Drop Cap" CssClass="proplbl" runat="server" Style="left: -10px; top: 21px"></asp:Label>
            </td>
        </tr>
        <%-- <tr id="drop1" style="display: none;">
            <td style="width: 180px; height: 21px;">
                <asp:Label ID="Label3" runat="server" CssClass="proplbl" Text="Position" Width="78px"
                    Style="left: 0px; top: -1px"></asp:Label></td>
            <td style="height: 21px">
                <select id="dropcap" class="dropdowns" style="width: 91px;" onchange="" >
                    <option id="1">None </option>
                    <option id="2">Dropped </option>
                    <option id="3">In-Margin</option>
                </select>
            </td>
        </tr>
        <tr id="drop2" style="display: none;">
            <td style="width: 180px; height: 14px;">
                <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Font" Width="78px"
                    Style="left: -7px; top: 18px"></asp:Label></td>
            <td style="height: 14px">
                <select id="fntname" class="dropdowns" style="width: 91px;" onchange='document.execCommand("FontName",0,this.options[this.selectedIndex].text)'>
                    <option style="font-family: Arial" value="Arial">Arial</option>
                    <option style="font-family: Comic Sans MS" value="Comic sans MS">Comic sans</option>
                    <option style="font-family: Courier New">Courier new</option>
                    <option style="font-family: Tahoma">Tahoma</option>
                    <option style="font-family: Times New Roman">Times New</option>
                    <option style="font-family: Verdana">Verdana</option>
                </select>
            </td>
        </tr>
        <tr id="drop3" style="display: none;">
            <td style="width: 180px; height: 19px;">
                <asp:Label ID="Label5" runat="server" CssClass="proplbl" Text="Lines to Drop"
                    Width="78px"></asp:Label></td>
            <td style="height: 19px">
                <input id="nooflines" value="3" style="width: 32px" class="btext" maxlength="1" onchange="return onlynos();" /></td>
        </tr>
        <tr id="drop4" style="display: none;">
            <td>
                <asp:Label ID="Label10" runat="server" CssClass="proplbl" Style="left: -4px; top: 44px"
                    Text="Distance From Text" Width="115px"></asp:Label></td>
            <td style="height: 20px">
                <input type="text" id="distfrmtxt" value="1" style="width: 32px" class="btext" maxlength="3"
                    onchange="return onlynos();" /><span style="font-size: 9pt; font-family: Verdana">px</span></td>
        </tr>
        <tr id="drop5" style="display: none;">
            <td colspan="2" align="right">
                <input type="button" id="applydropcap" class="button1" value="Apply" onclick="javascript:dropped();" />
            </td>
        </tr>--%>
    </table>
</div>
