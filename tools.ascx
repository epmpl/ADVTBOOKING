<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tools.ascx.cs" Inherits="tools" %>
<div id="toolboxdialog" class="dragprop" align="center" style="display: block; cursor: default;
    background-color: buttonface; border-bottom: double 4px #4a84ff; border-top: double 4px #4a84ff;
    border-left: double 4px #4a84ff; border-right: double 4px #4a84ff; position: relative;
    width: 36px; height: 360px" unselectable="on" contenteditable="false">
    <%--  width: 20px;">--%>
    <%-- left: -500px;">--%>
    <%--onpropertychange="javascript:onloadtxt();">--%>
    <%--<div id=titles >
    <img src="images/tools2.jpg" usemap="#closemapTools" unselectable="on" />
                <map id="Map1" name="closemapTools" class="handcursor">
                    <area shape="rect" coords="20,15,33,2" alt="close" href="javascript:closepropTool();" />
                </map>
    </div>--%>
    <table onkeydown="javascript:tabvalue();" cellpadding="0" cellspacing="0" unselectable="on"
        contenteditable="false">
        <thead class="dragprop">
            <tr>
                <td align="right">
                    <img src="images/tools2.jpg" usemap="#closemapTools" unselectable="on"/>
                    <map id="closemapTools" name="closemapTools" class="handcursor">
                        <area shape="rect" coords="20,15,33,2" alt="close" href="javascript:closepropTool();" />
                    </map>
                </td>
            </tr>
        </thead>
        <%--</table>
        <div>
        <table   >--%>
        <tr>
            <td >
                <img src="icons/pointer.jpg" id="pointer" title="resize" name="pointer" onmousedown="return false;" onmouseover="javascript:roll_over('pointer','icons/pointer_h.jpg');"
                    onmouseout="javascript:roll_over('pointer','icons/pointer.jpg')" onclick="javascript:enable_resize();"
                    unselectable="on" />
            </td>
        </tr>
        <tr>
            <td >
                <img src="icons/hand.jpg" id="hand" title="Drag drop" name="hand" onmousedown="return false;" onmouseover="javascript:roll_over('hand','icons/hand.jpg');"
                    onmouseout="javascript:roll_over('hand','icons/hand.jpg')" onclick="javascript:enable_drag();"
                    unselectable="on" />
            </td>
        </tr>
        <tr>
            <td >
                <img id="line" src="icons/line.jpg" title="Draw line" name="line" onmousedown="return false;" onmouseover="javascript:roll_over('line','icons/line_h.jpg');"
                    onmouseout="javascript:roll_over('line','icons/line.jpg')" onclick="javascript:addelement3();"
                    unselectable="on" />
            </td>
        </tr>
        <tr>
            <td>
                <img id="texttool" title="Insert Text Box" src="icons/textbox.jpg" name="txtbox" onmousedown="return false;" onmouseover="javascript:roll_over('txtbox','icons/textbox_h.jpg')"
                    onmouseout="javascript:roll_over('txtbox','icons/textbox.jpg')" onclick="javascript:addelement1();"
                    unselectable="on" />
            </td>
        </tr>
        <tr>
            <td>
                <img id="imagetool" title="Insert Image Box" name="pict" src="icons/image boxT.jpg" onmousedown="return false;"
                    onmouseover="javascript:roll_over('pict','icons/image boxT_h.jpg')" onmouseout="javascript:roll_over('pict','icons/image boxT.jpg')"
                    onclick="javascript:addelement2();" unselectable="on" />
            </td>
        </tr>
        <tr>
            <td>
                <img src="icons/crop.jpg" title="Crop Image" name="crop" id="cropme" onmousedown="return false;" onmouseover="javascript:roll_over('crop','icons/crop_h.jpg');"
                    onmouseout="javascript:roll_over('crop','icons/crop.jpg')" onclick="javascript:getcropped();"
                    unselectable="on" />
            </td>
        </tr>
        <tr>
            <td>
                <img id="rotatetool" src="icons/rotateT.jpg" title="Rotate" name="rotate" onmousedown="return false;" onmouseover="javascript:roll_over('rotate','icons/rotateT_h.jpg')"
                    onmouseout="javascript:roll_over('rotate','icons/rotateT.jpg')" onclick="javascript:rotatedialog();"
                    unselectable="on" />
            </td>
        </tr>
        <%--<tr>
            <td>
                <img id="Stretchtool" src="icons/StretchT.jpg" alt="Stretch" name="stretch" onmouseover="javascript:roll_over('stretch','icons/StretchT_h.jpg')"
                    onmouseout="javascript:roll_over('stretch','icons/StretchT.jpg')" onclick="javascript:Stretch();"
                    unselectable="on" />
            </td>
        </tr>--%>
        <tr>
            <td>
                <img id="fliptool" src="icons/flipT.jpg" title="Flip" name="flip" onmousedown="return false;" onmouseover="javascript:roll_over('flip','icons/flipT_h.jpg')"
                    onmouseout="javascript:roll_over('flip','icons/flipT.jpg')" onclick="javascript:flipHor();"
                    unselectable="on" />
            </td>
        </tr>
        <%--<tr>
            <td>
                <img id="clrpckrtool" src="icons/color picker.jpg" alt="Colors" name="clrTpckr" onmouseover="javascript:roll_over('clrTpckr','icons/colorboxT_h.jpg')"
                    onmouseout="javascript:roll_over('clrTpckr','icons/color picker.jpg')" /><%--onclick="#showColorGrid2('colorcode1',currentid);">
                <input type="hidden" id="colorcode1" class="proptext" />
            </td>
        </tr>--%>
        <tr>
            <td>
                <img id="tagtool" src="icons/tags.jpg" title="Tags" name="tags" onmousedown="return false;" onmouseover="javascript:roll_over('tags','icons/tags_h.jpg')"
                    onmouseout="javascript:roll_over('tags','icons/tags.jpg')" onclick="javascript:opentags();"
                    unselectable="on" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="fcolor" Enabled="false" runat="server" class="handcursor" ToolTip="Fore Color" Style="z-index: 100;
                    background-color: ButtonFace; position: relative; height: 15px; width: 15px;
                    border: solid 1px black;" ReadOnly="true"></asp:TextBox>
                <%-- <input type="text" id="fcolor" contenteditable="false" runat="server" style="z-index: 100;
                    background-color: ButtonFace; position: relative; height: 15px; width: 15px; border: solid 1px black;"
                    onclick="showColorGridT1('colorcodeT_F',currentid);" />--%>
                <input type="hidden" id="colorcodeT_F" style="width:5px" class="btext" />
                <%--<div id="fcolor" contenteditable="false" style="position: relative; height: 7px; width: 15px; border: solid 1px black;
                    z-index: 100" onclick="">
                </div>--%>
                   <asp:TextBox ID="bgcolor" Enabled="false" runat="server" ToolTip="Back Color" Style="z-index: 98;
                    background-color: ButtonFace; position: relative; height: 15px; width: 15px;
                    border: solid 1px black; left: -6px; top: 5px;" ReadOnly="true"></asp:TextBox>
                <%-- <input type="text" id="bgcolor" contenteditable="false" runat="server" style="z-index: 98;
                    background-color: ButtonFace; position: relative; height: 15px; width: 15px;
                    border: solid 1px black; left: 6px; top: -13px;" onclick="showColorGridT2('colorcodeT_B',currentid);" />--%>
                <input type="hidden" id="colorcodeT_B" style="width: 5px" class="btext" />
                <%--<div id="bgcolor" style="position: relative; height: 7px; width: 15px; border: solid 1px black;
                    left: 5px; top: -13px; z-index: 98">
                </div>--%>
            </td>
        </tr>
    </table>
    <%-- </div>--%>
</div>
