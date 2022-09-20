<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fonttlbr.ascx.cs" Inherits="fonttlbr" %>
<link rel="stylesheet" type="text/css" href="CSS/main.css" />
<div id="fnttools" runat="server" unselectable="on" style="background-color: ButtonFace;">
    <%-- <script type="text/javascript" src="js/enterortab.js"></script>--%>
    <%--<script type="text/javascript" language="javascript" src="js/ctrl.js"></cript>--%>

    <script type="text/javascript" language="javascript" src="javascript\classified.js"></script>

    <table id="tables4" class="" cellpadding="0" cellspacing="0" style="width: 371px"
         align="center" enableviewstate="false">
        <%--onkeydown="javascript:tabvalue();"--%>
        <tbody>
            <tr>
                <td >
                    <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Language"></asp:Label>
                </td>
                <td align="center" style="width: 72px">
                    <select id="alignment" runat="server" class="dropdownsfonts" style="width: 65px; z-index: 50;"
                        onchange="javascript:return getFonts();">
                        
                        <option value="English">English</option>
                        
                        
                    </select>
                </td>
                
                <td>
                    <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Font"></asp:Label>
                </td>
                <td align="center">
                    <%--<object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px" height="0px"></object>--%>
                    <select id="fntname" runat="server" style="width: 90px" class="dropdownsfonts">
                       
                    </select>
                </td>
                <%--<td align="center">
                   <select id="hfont" runat="server" style="width:50px" class="dropdowns">
                     <option selected="selected"></option>
                     <option>mangal</option>
                     <option>kundli</option>
                     <option>4c gandhi</option>
                  </select></td>--%>
                <td >
                    <asp:Label ID="Label1" runat="server" CssClass="proplbl" Text="Size"></asp:Label>
                </td>
                <%--<td align="center">
                    <select id="fntsize" runat="server" style="width: 80px" class="dropdowns" onchange='document.execCommand("FontSize",0,this.options[this.selectedIndex].value)'>
                        <option value="1">xx-small</option>
                        <option value="2">x-small</option>
                        <option value="3">smaller</option>
                        <option value="4">small</option>
                        <option value="5">medium</option>
                        <option value="6">large</option>
                        <option value="7">larger</option>
                        </select>
                </td>--%>
                
                <td align="center">
                  <asp:DropDownList ID="fntsize" Enabled="false" runat ="server" CssClass="dropdownsfonts" AppendDataBoundItems="True" Width="45px" >
                    
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="lblline" runat="server" CssClass="proplbl" Text="LineSpacing"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtline" Enabled="false" runat="server" Width="50px" onchange="javascript:return linespacing();"></asp:TextBox></td>
                <td align="center">
                    <img src="Images/bold.jpg" style="display:none" alt="Bold" name="bold" id="bold" onmouseover="javascript:roll_over('bold','Images/bold_h.jpg');"
                        onmouseout="javascript:roll_over('bold','Images/bold.jpg')" unselectable="on"
                        onclick='document.execCommand("Bold");document.getElementById("editordiv").focus()' />
                </td>
                <%--<td style="width: 10px; height: 7px;">
                </td>--%>
                <td>
                    <img src="Images/italic.jpg" style="display:none" alt="Italic" name="italic" id="italic" onmouseover="javascript:roll_over('italic','Images/italic_h.jpg');"
                        onmouseout="javascript:roll_over('italic','Images/italic.jpg')" unselectable="on"
                        onclick='document.execCommand("Italic");document.getElementById("editordiv").focus();' />
                </td>
                <%--<td style="width: 10px; height: 7px;">
                </td>--%>
                <td>
                    <img src="Images/underline.jpg" style="display:none" alt="Underline" name="underline" id="underline" onmouseover="javascript:roll_over('underline','Images/underline_h.jpg');"
                        onmouseout="javascript:roll_over('underline','Images/underline.jpg')" unselectable="on"
                        onclick='document.execCommand("Underline");document.getElementById("editordiv").focus()' />
                </td>
                <td style="width: 10px;">
                </td>
                <td style=" padding-left: 3px" align="center">
                    <img id="cut" alt="Cut" name="cut" src="Images/Cut.jpg" onmouseover="javascript:roll_over('cut','Images/cut_h.jpg')"
                        onmouseout="javascript:roll_over('cut','Images/cut.jpg')" unselectable="on" onclick="javascript:CutToClipboard();" />
                </td>
                <td style="width: 10px;">
                </td>
                <td style=" padding-left: 3px" align="center">
                    <img id="copy" alt="Copy" name="copy" src="Images/Copy.jpg" onmouseover="javascript:roll_over('copy','Images/copy_h.jpg')"
                        onmouseout="javascript:roll_over('copy','Images/copy.jpg')" unselectable="on"
                        onclick="javascript:CopyToClipboard()" />
                </td>
                <td style="width: 10px;">
                </td>
                <td style=" padding-left: 3px" align="center">
                    <img id="paste" alt="Paste" name="paste" src="Images/paste.jpg" onmouseover="javascript:roll_over('paste','Images/paste_h.jpg')"
                        onmouseout="javascript:roll_over('paste','Images/paste.jpg')" unselectable="on"
                        onclick="javascript:PasteFromClipboard()" />
                </td>
                <%--<td>
                    <input type="button" id="btnpre" runat="server" value="Preview" />
                    <%--<asp:Button ID="btnpre" runat="server" Text="Preview" CssClass="" OnClick="javascript:return preview();" />--%>
                <%--</td>--%>
                
            </tr>
        </tbody>
    </table>
</div>
