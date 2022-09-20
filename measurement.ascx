<%@ Control Language="C#" AutoEventWireup="true" CodeFile="measurement.ascx.cs" Inherits="measurement" %>

<script type="text/javascript">

</script>

<div id="measuredialog" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
    border-right: double 7px #4a84ff; position: relative; top: -20px; left: -500px; width:207px" unselectable="on">
    <%--onpropertychange="javascript:onloadtxt();">--%>
    <%--<div id="measuredialog" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
    border-right: double 7px #4a84ff; width: 207px;height:351px;left: 2px;" unselectable="on">--%>
    <table onkeydown="javascript:tabvalue();" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">
                <img src="images/new-Template.jpg" usemap="#closemapM" unselectable="on" />
                <map id="closemapM" name="closemapM" class="handcursor">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closepropM();" />
                </map>
            </td>
        </tr>
        
          <tr>
            <td>
                <asp:Label ID="uom88" Text="UOM" CssClass="proplbl" runat="server"></asp:Label>
            </td>
            <%--&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp--%>
            <td>
              <select id="units" class="dropdowns" style="width: 80px; height:15px;" onchange="javascript:changeunits();" tabindex="1">
                    <option value="1" selected="selected">PX</option>
                    <option value="2">Inch</option>
                    <option value="3">CM</option>
                    <option value="4">MM</option>
              </select>
                <%--<asp:DropDownList ID="units" CssClass="dropdowns" Width="50px" runat="server" OnSelectedIndexChanged="units_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1" Text="Px">
                    </asp:ListItem>
                    <asp:ListItem Value="2" Text="CM">
                    </asp:ListItem>
                    <asp:ListItem Value="3" Text="MM">
                    </asp:ListItem>
                    <%--</asp:ListBox>
                </asp:DropDownList>--%>
                <%--<asp:TextBox ID="uom" runat="server"></asp:TextBox>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" Text="Height" CssClass="proplbl" runat="server"></asp:Label>
            </td>
            <td>
                <input type="text" class="proptextsmall" id="hghtTemp" value="330"
                 onchange="return onlynos(this);" onkeypress="return numeric(event);" tabindex="2" style="width: 40px"  maxlength="6" />
                <%--<asp:TextBox ID="hghtTemp" CssClass="btext" Width="47px" runat="server"></asp:TextBox>--%>
            </td>
        </tr>
        <tr>
            <td>
               <%-- <asp:RadioButton ID="if_width" GroupName="selected" Checked="true" runat="server" />--%>
                <asp:Label ID="Label2" Text="Width" CssClass="proplbl" runat="server"></asp:Label>
            </td>
            <td style="width: 102px">
                <input type="text" class="proptextsmall" id="wdthTemp" value="660"
                    onchange="return onlynos(this);" onkeypress="return numeric(event);" tabindex="3" style="width: 40px"   maxlength="6" />
                <%--<asp:TextBox ID="wdthtmp" CssClass="btext" Width="47px" runat="server"></asp:TextBox>--%>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="Label4" Text="Columns" CssClass="proplbl" runat="server"></asp:Label>
            </td>
            <td style="width: 102px">
                <input type="text" class="btext" id="column" value="1" style="width: 47px;" />
                <%--<asp:TextBox ID="column" CssClass="btext" Width="47px" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <%--<tr>
            <td>
                <asp:RadioButton ID="if_column" GroupName="selected" runat="server" />
                <asp:Label ID="Label4" Text="Columns" CssClass="proplbl" runat="server"></asp:Label>
            </td>
            <td>
                <input type="text" id="colmns" class="proptextsmall" maxlength="1" onchange="return onlynos(this);"
                    style="visibility: hidden;" tabindex="5" value="2" />
            </td>
        </tr>--%>
        <%--<tr>
            <td align="right">
                <asp:Label ID="Label5" Text="Gutter" CssClass="proplbl" runat="server" Style="visibility: hidden;"></asp:Label>
            </td>
            <td style="width: 102px">
                <input type="text" class="proptextsmall" id="gutter" maxlength="3" onkeypress="return onlynos();"
                    style="visibility: hidden;" tabindex="6" />
                <%--<asp:TextBox ID="gutter" CssClass="btext" Width="47px" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" Text="Orientation" CssClass="proplbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <input type="radio" id="landscape" checked="checked" name="orient" tabindex="7" />
                <asp:Label ID="Label6" Text="Landscape" CssClass="proplbl" runat="server"></asp:Label>
                <%--<asp:RadioButton ID="portrait" Text="Portrait" Checked="true" GroupName="orient"
                    runat="server" />--%>
            </td>
            <td style="width: 102px">
                <input type="radio" id="portrait" name="orient" tabindex="8" />
                <asp:Label ID="Label7" Text="Portrait" CssClass="proplbl" runat="server"></asp:Label>
                <%--<asp:RadioButton ID="RadioButton1" Text="Landscape" GroupName="orient" runat="server" />--%>
            </td>
        </tr>
        <tr align="right">
            <td>
                <input type="button" id="btnok" value="Ok" class="inputbutton"  onclick="javascript:create();" tabindex="9" />
                <%--<asp:Button ID="btnok" Text="OK" CssClass="inputbutton" runat="server" />--%>
            </td>
            <td style="width: 102px">
                <input type="button" id="btncancel" value="Cancel" class="inputbutton" runat="server" tabindex="10" />
                <%--<asp:Button ID="btncancel" Text="Cancel" CssClass="inputbutton" runat="server" />--%>
            </td>
        </tr>
    </table>
</div>
