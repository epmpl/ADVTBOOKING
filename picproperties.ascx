<%@ Control Language="C#" AutoEventWireup="true" CodeFile="picproperties.ascx.cs" Inherits="picproperties" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<script type="text/javascript" src="js/enterortab.js"></script>

<%--<script type="text/javascript" src="js/cropped.js">

</script>--%>

<%--<div id="outerDiv" style="left:0px;top:0px;">
  <span onmousedown="dragStart(event, 'outerDiv')">Drag Me</span>
  <p>Some text.</p>
</div>--%>
<div id="picdialog" class="dragprop" contenteditable="false" unselectable="on" style="position: relative;
    display: none; cursor: default; background-color: Buttonface; border-bottom: double 7px #4a84ff;
    border-top: double 7px #4a84ff; border-left: double 7px #4a84ff; border-right: double 7px #4a84ff;
    width: 207px; top: -58px; left: 2px"> <%--unselectable="on">--%>
    <table id="TABLE1" onkeydown="javascript:tabvalue();" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" bgcolor="">
                <img src="images/Picture-box-properties.jpg" usemap="#closemapP" style="width: 203px"
                    unselectable="on" />
                <map id="closemapP" name="closemapP" class="handcursor">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closeprop1();" />
                </map>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" class="lbl">
                <asp:Label ID="inputimg" runat="server" CssClass="proplbl" Text="Insert Image"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="inputimage" class="button1" value="Insert" onclick="javascript:showupload();" />
                <br />
                <a href="javascript:getcropped();" class="proplbl" id="link">Crop Image</a> <br /><a href="javascript:showcrop();"
                    class="proplbl" id="applylink" style="visibility: hidden;">Apply</a>
                <input type="hidden" id="imagepath" />
                <%--<asp:LinkButton ID="LinkButton1" runat="server">Cropdocument.getElementById(currentid).src= image</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" CssClass="proplbl" Text="Size"></asp:Label></td>
        </tr>
        <tr>
            <td >&nbsp;
                <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Height"></asp:Label></td>
            <td>
                <input type="text" id="input_hghtP" class="proptextsmall" maxlength="6" style="width: 40px" onchange="return onlynos(this);" onkeypress="return numeric(event);"  />
            </td>
        </tr>
        <tr>
            <td >&nbsp;
                <asp:Label ID="Label3" runat="server" CssClass="proplbl" Text="Width " ></asp:Label></td>
            <td>
                <input type="text" id="input_wdthP" class="proptextsmall" maxlength="6" style="width: 40px" onkeypress="return numeric(event);" onchange="return onlynos(this);" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Border"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label5" runat="server" CssClass="proplbl" Text="Border Type" Width="85px"></asp:Label></td>
            <td>
                <select id="borderlist" runat="server" class="dropdowns" onchange="javascript:changeB_P();"
                    style="width: 60px">
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
        <tr>
            <td align="center">
                <asp:Label ID="Label6" runat="server" CssClass="proplbl" Text="Border Color" Width="85px"></asp:Label></td>
            <td>
                <div id="colorpicker201" class="colorpicker201">
                </div>
                <input type="text" id="sampleclrbrdrP" name="sampleclrbrdr" class="proptextsmall" style="background-color:Black;"
                    contenteditable="false" />
                <img name="brdrclrP" src='icons/cpiksel.gif' onmouseover="javascript:roll_over('brdrclrP','icons/cpiksel.gif');"
                    onmouseout="javascript:roll_over('brdrclrP','icons/cpiksel.gif')" onclick="showColorGrid3('colorcode1',currentid);">
                <input type="hidden" id="colorcode1" class="proptext" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label7" runat="server" CssClass="proplbl" Text="Border Size" Width="85px"></asp:Label></td>
            <td>
                <input type="text" id="bsize_p" class="proptextsmall" maxlength="5" onkeypress="return numeric(event);" onchange="return onlynos(this);"
                   onblur="javascript:changeBsize_P();" value="3" />
                <%--<span style="font-size: 9pt; font-family: Verdana">px</span>--%></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label8" runat="server" CssClass="proplbl" Text="Background Color"></asp:Label></td>
            <td>
                <%--<input type="text" id="sampleclr" class="btext" style="width: 32px" contenteditable="false"
                    onclick="javascript:apply_color();" />--%>
                <input type="text" id="sampleclrbckP" name="sampleclrbck" class="proptextsmall" contenteditable="false"
                    style="background-color: #9900FF;" />
                <img name="bckgrndP" src='icons/cpiksel.gif' onmouseover="javascript:roll_over('bckgrndP','icons/cpiksel.gif');"
                    onmouseout="javascript:roll_over('bckgrndP','icons/cpiksel.gif')" onclick="showColorGrid2('colorcode',currentid);">
                <input type="hidden" id="colorcode" class="proptext" />
            </td>
        </tr>
        <%--<tr>
            <td id="sr4">
                <asp:Label ID="Label9" runat="server" Text="Shape Type" CssClass="proplbl"></asp:Label>
            </td>
            <td id="sr5">
                <select id="shape" runat="server" class="dropdowns" onchange="javascript:shape_select();"
                    style="width: 78px">
                    <option value="0">--Select--</option>
                    <option value="1">Rectangle</option>
                    <option value="2">Square</option>
                    <%--<option value="3">Rounded Corner</option>--%>
                    <%--<option value="3">Circle</option>
                </select>
            </td>
        </tr>--%>
        <%--<tr>
            <td colspan="2">
                <input type="file" id="thumimg" class="proplbl" style="width: 189px" />
            </td>
        </tr>--%>
    </table>
</div>
