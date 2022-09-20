<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lineproperties.ascx.cs" Inherits="linedialog" %>
  <%--<script type="text/javascript" src="js/enterortab.js"></script>--%>
  <script type="text/javascript" src="js/enterortab.js"></script>

<%--<div id="outerDiv" style="left:0px;top:0px;">
  <span onmousedown="dragStart(event, 'outerDiv')">Drag Me</span>
  <p>Some text.</p>
</div>--%>
<div id="linedialog" class="dragprop" contenteditable="false" unselectable="on" style="position: relative;
    display: none; cursor: default; background-color: Buttonface; border-bottom: double 7px #4a84ff;
    border-top: double 7px #4a84ff; border-left: double 7px #4a84ff; border-right: double 7px #4a84ff;
    width: 207px; top: -58px; left: 2px">
    <table id="TABLE1" onkeydown="javascript:tabvalue();" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" bgcolor="">
                <img src="images/Line-properties.JPG" usemap="#closemapl" style="width: 203px" unselectable="on" />
                <map id="closemapl" name="closemapl" class="handcursor">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closepropl();" />
                </map>
            </td>
        </tr>
        <tr>
        <!--  onblur="javascript:changeH_L();"   -->
            <td>
                &nbsp;
                <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Height"></asp:Label></td>
            <td>
                <input type="text" id="input_hghtL" class="proptextsmall" maxlength="6" style="width: 40px"
                    onchange="return onlynos(this);" onkeypress="return numeric(event);" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <asp:Label ID="Label3" runat="server" CssClass="proplbl" Text="Width "></asp:Label></td>
            <td>
                <input type="text" id="input_wdthL" class="proptextsmall" maxlength="6" style="width: 40px" 
                    onchange="return onlynos(this);" onkeypress="return numeric(event);" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="hlr" CssClass="proplbl" runat="server" Checked="true" GroupName="g" Text="Vertical Line" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="vlr" runat="server" CssClass=proplbl GroupName="g" Text="Horizontal Line"/>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label8" runat="server" CssClass="proplbl" Text="Line Color"></asp:Label></td>
            <td>
                <%--<input type="text" id="sampleclr" class="btext" style="width: 32px" contenteditable="false"
                    onclick="javascript:apply_color();" />--%>
                <input type="text" id="sampleclrbckL" name="sampleclrbck" class="proptextsmall" contenteditable="false"
                    style="background-color: #9900FF;" />
                <img name="bckgrndL" src='icons/cpiksel.gif' onmouseover="javascript:roll_over('bckgrndP','icons/cpiksel.gif');"
                    onmouseout="javascript:roll_over('bckgrndP','icons/cpiksel.gif')" onclick="showColorGrid2('colorcode',currentid);">
                <input type="hidden" id="colorcode" class="proptext" />
            </td>
        </tr>
        
    </table>
</div>
