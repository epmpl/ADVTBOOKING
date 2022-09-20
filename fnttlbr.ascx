<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fnttlbr.ascx.cs" Inherits="fnttlbr" %>
<link rel="stylesheet" type="text/css" href="CSS/main.css" />

<div id="fnttools" runat="server" unselectable="on" style="background-color: ButtonFace;">

    <script type="text/javascript" src="js/enterortab.js"></script>

    <script type="text/javascript" language="javascript" src="js/ctrl.js"></script>
    <table id="tables4" class="" cellpadding="0" cellspacing="0" style="width: 360px"
        height="21px" align="center" onkeydown="javascript:tabvalue();" enableviewstate="false" >
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Font"></asp:Label>
                </td>
                <td align="center">
                    <select id="fntname" runat="server" class="dropdowns"  style="width: 145px">
                      <%--<option selected="selected">Arial</option>
                        <option>Comic sans MS</option>
                        <option>Courier new</option>
                        <option>Tahoma</option>
                        <option>Times New Roman</option>
                        <option>Verdana</option>--%>
                    </select>
                </td>
                
                <td style="height: 20px">
                    <asp:Label ID="Label1" runat="server" CssClass="proplbl" Text="Size"></asp:Label>
                </td>
                  <td align="center">
               <div id="fontsizef1"   runat="server" style="display:none">
               <input  id="fntsize1"  runat="server" type="text" style="width: 40px" onkeypress="return numeric(event);" onchange="javascript:fontsizef1(event);"  maxlength="2"  /></div>
                <div id="fontsizef" runat="server" style="display:block">
                 <select id="fntsize" runat="server" class="dropdowns"  onchange="javascript:fontsize1();" style="width: 45px">
                        <option selected="selected">8</option>
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
                        <option>more</option>
                        
                    </select></div>
                </td>
                <td style="height: 20px">
                    <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Align"></asp:Label>
                </td>
                <td align="center">
                    <select id="alignment" runat="server" class="dropdowns" style="width: 65px; z-index: 50;"
                        onchange="javascript:alignText1();">
                        <option selected="selected">left</option>
                        <option>right</option>
                        <option>center</option>
                        <option>justify</option>
                    </select>
                </td>
                <%--<td style="width: 10px; height: 7px;"></td>--%>
                <td align="center">
                    <img src="icons/bold.jpg"  title="Bold" name="bold" id="bold" onmousedown="return false;" onmouseover="javascript:roll_over('bold','icons/bold_h.jpg');"
                    onmouseout="javascript:roll_over('bold','icons/bold.jpg')" unselectable="on"
                    onclick='document.execCommand("bold", false, "");document.getElementById("editordiv").focus()' />
                </td>
                <%--<td style="width: 10px; height: 7px;">
                </td>--%>
                <td>
                    <img src="icons/italic.jpg" title="Italic" name="italic" id="italic" onmousedown="return false;" onmouseover="javascript:roll_over('italic','icons/italic_h.jpg');"
                        onmouseout="javascript:roll_over('italic','icons/italic.jpg')" unselectable="on"
                        onclick='document.execCommand("italic",false,"");document.getElementById("editordiv").focus()' />
                </td>
                <%--<td style="width: 10px; height: 7px;">
                </td>--%>
                <td>
                    <img src="icons/underline.jpg" title="Underline" name="underline" id="underline" onmousedown="return false;" onmouseover="javascript:roll_over('underline','icons/underline_h.jpg');"
                        onmouseout="javascript:roll_over('underline','icons/underline.jpg')" unselectable="on"
                        onclick='document.execCommand("underline",false,"");document.getElementById("editordiv").focus()' />
                </td>
                <td>
                    <img src="icons/bullets.jpg" title="Bullets" name="bullets" id="bullets" onmousedown="return false;" onmouseover="javascript:roll_over('bullets','icons/bullets_h.jpg');"
                        onmouseout="javascript:roll_over('bullets','icons/bullets.jpg')" unselectable="on"
                        onclick='javascript:bullet();' />
                </td>
                <td>
                    <img src="icons/numbering.jpg" title="Numbering" name="number" id="number" onmousedown="return false;" onmouseover="javascript:roll_over('number','icons/numbering_h.jpg');"
                        onmouseout="javascript:roll_over('number','icons/numbering.jpg')" unselectable="on"
                        onclick="javascript:return numbers()" />
                </td>
            </tr>
        </tbody>
    </table>
</div>
