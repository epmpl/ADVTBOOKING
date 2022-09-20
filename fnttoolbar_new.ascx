<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fnttoolbar_new.ascx.cs" Inherits="fnttoolbar_new" %>
<link rel="stylesheet" type="text/css" href="CSS/main.css" />
<div id="fnttools" runat="server" unselectable="on" style="background-color: ButtonFace;">    

    <script type="text/javascript" language="javascript" src="javascript\classifiedEditor.js"></script>
<div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 999; " >
            <table cellpadding="0" cellspacing="0" border="1">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" onclick="return setVal1();" onkEYDOWN="return chkKey(event);" Width="254px" Height="105px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    <table id="tables4" class="" cellpadding="0" cellspacing="0" style="width: 80%"
        height="30px" align="left" border="0" enableviewstate="false">
        
        <tbody>
            <tr>
                <td style="height: 20px; width: 68px;">
                    &nbsp;
                    <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Keyboard"></asp:Label></td>
                <td align="center" style="width: 72px" >
                    <select id="KEYBORD" style="width: 90px" class="dropdowns" onchange="chgLanguage()">
                        <option value="Phonatic">Phonatic</option> 
                        <option value="Roman">Roman</option>
                        <option value="Remington">Remington</option>
                         <option value="Linotype">Linotype</option>                                                
                    </select>
                </td>
                
                <td>
                    &nbsp;
                    <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Language"></asp:Label>
                </td>
                <td align="center">
                   
                    <select id="fntname"  runat="server" style="width: 90px" class="dropdowns">
                       
                    </select>
                </td>                
                              
                <td>
                    <img src="Images/bold.jpg" alt="Bold" name="bold" id="bold" onmouseover="javascript:roll_over('bold','Images/bold_h.jpg');"
                        onmouseout="javascript:roll_over('bold','Images/bold.jpg')" unselectable="on"
                        onclick='document.execCommand("Bold");document.getElementById("editordiv").focus()' />
                </td>
                 <td style="height: 20px">
                    <asp:Label ID="Label1" runat="server" CssClass="proplbl" Text="Size" Visible="false"></asp:Label>
                </td> 
                <td align="center">
                  <asp:DropDownList ID="fntsize"  runat ="server" CssClass="dropdowns" AppendDataBoundItems="True" Width="45px" Visible="false">
                    
                    </asp:DropDownList>
                </td>
                 <td id="tddown" runat="server" ><a style="cursor:hand;cursor:pointer" onclick="window.open('downloadFont.aspx')" class="folder">Download Font</a></td>
                <td style="height: 20px">
                    <asp:Label ID="CioId" runat="server" CssClass="proplbl" Text="File Name" Width="58px"></asp:Label>
                </td>                
                <td align="center" id="td1">
               
                  <asp:TextBox ID="ddlcioid" onkEYDOWN="return chkKey1(event);" tabindex="4" runat ="server" CssClass="dropdowns"  Width="155px">
                    
                    </asp:TextBox>
                     
                </td> 
                
            </tr>
        </tbody>
    </table>
    <input type="hidden" id="hidagcode" runat="server" />
</div>
