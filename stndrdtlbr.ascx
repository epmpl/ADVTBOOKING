<%@ Control Language="C#" AutoEventWireup="true" CodeFile="stndrdtlbr.ascx.cs" Inherits="stndrdtlbr" %>

<script type="text/javascript" language="javascript" src="js/ctrl.js"></script>

<script type="text/javascript" src="js/enterortab.js"></script>

<div id="stndrd" runat="server" contenteditable="false" style="background-color: ButtonFace;
    height: 20px" unselectable="on">
    <table id="tables" cellpadding="0" cellspacing="0" bgcolor="buttonface" style="width: 280px;
        height:20px" align="center" onkeydown="javascript:tabvalue();" enableviewstate="false">
        <tbody>
            <tr>
                <%--td bgcolor="silver" style="width: 9px; height: 20px;padding-left:3px">
                <img ID="closetool" src="icons/close.jpg"/>
                    </td>--%>
                <td id="newicon" style="width: 16px; height: 20px;" align="center">
                    <img id="newt"  title="New Template" name="newt" src="icons/New.jpg" onmousedown="return false;"  onmouseover="javascript:roll_over('newt','icons/New_h.jpg');"
                        onmouseout="javascript:roll_over('newt','icons/New.jpg')" unselectable="on" onclick="javascript:createlayout();"
                        accesskey="c" />
                </td>
                <td style="width: 10px; height: 20px;">
                </td>
                <td style="width: 16px; height: 20px; padding-left: 3px" align="center">
                    <img id="open" title="Open" name="open" src="icons/open.jpg" onmousedown="return false;" onmouseover="javascript:roll_over('open','icons/open_h.jpg')"
                        onmouseout="javascript:roll_over('open','icons/open.jpg')" unselectable="on"
                        onclick="javascript:openlayout();" />
                </td>
                <td style="width: 10px; height: 20px;">
                </td>
                <td bordercolordark="black" style="height: 20px; padding-left: 3px" align="center">
                    <img id="save" title="Save" name="save" src="icons/save.jpg" onmousedown="return false;" onmouseover="javascript:roll_over('save','icons/save_h.jpg')"
                        onmouseout="javascript:roll_over('save','icons/save.jpg')" unselectable="on"
                        onclick="javascript:savedialog();" />
                </td>
                <%--td>
                    <img id="undo" alt="Undo" name="Undo" src="icons/undo.jpg" onmouseover="javascript:roll_over('Undo','icons/undo_h.jpg')"
                        onmouseout="javascript:roll_over('Undo','icons/undo.jpg')" unselectable="on"
                        onclick="document.execCommand('undo', false, null);" />
                </td>
                <td>
                    <img id="redo" alt="Redo" name="redo" src="icons/redo.jpg" onmouseover="javascript:roll_over('redo','icons/redo_h.jpg')"
                        onmouseout="javascript:roll_over('redo','icons/redo.jpg')" unselectable="on"
                        onclick="document.execCommand('redo', false, null);" />
                </td>--%>
                <td style="width: 10px; height: 20px;">
                </td>
                <td style="height: 20px; padding-left: 3px" align="center">
                    <img id="cut" title="Cut" name="cut" src="icons/cut.jpg" onmousedown="return false;" onmouseover="javascript:roll_over('cut','icons/cut_h.jpg')"
                        onmouseout="javascript:roll_over('cut','icons/cut.jpg')" unselectable="on" onclick="javascript:CutToClipboard();" />
                </td>
                <td style="width: 10px; height: 20px;">
                </td>
                <td style="height: 20px; padding-left: 3px" align="center">
                    <img id="copy" title="Copy" name="copy" src="icons/copy.jpg" onmousedown="return false;" onmouseover="javascript:roll_over('copy','icons/copy_h.jpg')"
                        onmouseout="javascript:roll_over('copy','icons/copy.jpg')" unselectable="on"
                        onclick="javascript:CopyToClipboard()" />
                </td>
                <td style="width: 10px; height: 20px;">
                </td>
                <td style="height: 20px; padding-left: 3px" align="center">
                    <img id="paste" title="Paste" name="paste" src="icons/paste.jpg" onmousedown="return false;" onmouseover="javascript:roll_over('paste','icons/paste_h.jpg')"
                        onmouseout="javascript:roll_over('paste','icons/paste.jpg')" unselectable="on" onclick="javascript:paste_selected()" />
                </td>
                <td style="width: 10px; height: 20px;">
                </td>
                <td style="height: 20px; padding-left: 3px" align="center">
                    <img id="deletes" title="Delete" name="delete" src="icons/delete.jpg" onmousedown="return false;" onmouseover="javascript:roll_over('delete','icons/delete_h.jpg')"
                        onmouseout="javascript:roll_over('delete','icons/delete_d.jpg')" onclick="javascript:delete_selected(event);" unselectable="on"  />
                </td>
                <td style="width: 10px; height: 20px;">
                </td>
                <td style="width: 15px; height: 20px; padding-left: 5px">
                    <img title="Insert Image" src="icons/Picture-box.jpg" name="Picture-box2" id="insertP"
                        onmouseover="javascript:roll_over('Picture-box2','icons/Picture-box_h.jpg');"
                        onmouseout="javascript:roll_over('Picture-box2','icons/Picture-box.jpg')" onmousedown="return false;" unselectable="on"
                        onclick="javascript:showupload();" /><%--document.getElementById("editordiv").focus();document.execCommand("InsertImage",1);'--%>
                </td>
                <td style="height: 20px; padding-left: 3px" align="center">
                    <img id="checkad" title="Check Ad" name="checkad" src="icons/check-ad.jpg" onmouseover="javascript:roll_over('checkad','icons/check-ad_h.jpg')" onmousedown="return false;"
                        onmouseout="javascript:roll_over('checkad','icons/check-ad.jpg')" unselectable="on"
                        onclick="javascript:CheckAd();" />
                </td>
                <td style="width: 10px; height: 20px;">
                </td>
                <td style="height: 20px; padding-left: 3px" align="center">
                    <img id="printer" title="Print" name="printer" src="icons/print.jpg" onmouseover="javascript:roll_over('printer','icons/print_h.jpg')" onmousedown="return false;"
                        onmouseout="javascript:roll_over('printer','icons/print.jpg')" unselectable="on"
                        onclick="javascript:previewdialog();" />
                </td>
                <td style="width: 10px; height: 20px;">
                </td>
                <td style="height: 20px; padding-left: 3px" align="center">
                    <img id="text" title="Text Box" src="icons/textbox.jpg" name="txtbx"  onmousedown="return false;" onmouseover="javascript:roll_over('txtbx','icons/textbox_h.jpg')"
                        onmouseout="javascript:roll_over('txtbx','icons/textbox.jpg')" unselectable="on"
                        onclick="javascript:addelement1();" />
                </td>
                <td style="width: 10px">
                </td>
                <td style="width: 17px; height: 20px; padding-left: 3px" align="center">
                    <img id="image" title="Image Box" name="pcbx" src="icons/image boxT.jpg" onmousedown="return false;" onmouseover="javascript:roll_over('pcbx','icons/image boxT_h.jpg')"
                        onmouseout="javascript:roll_over('pcbx','icons/image boxT.jpg')" unselectable="on"
                        onclick="javascript:addelement2();" />
                </td>
                <td style="width: 10px">
                </td>
                <td style="width: 17px; height: 20px; padding-left: 3px" align="center">
                    <img id="help" title="Help" name="help" src="icons/help.jpg" onmousedown="return false;" onmouseover="javascript:roll_over('help','icons/help_h.jpg')"
                        onmouseout="javascript:roll_over('help','icons/help.jpg')" unselectable="on" />
                </td>
            </tr>
        </tbody>
    </table>
</div>
