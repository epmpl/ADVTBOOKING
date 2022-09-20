<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fnttoolbar3.ascx.cs" Inherits="fnttoolbar3" %>
<link rel="stylesheet" type="text/css" href="CSS/main.css" />
<div id="fnttools" runat="server" unselectable="on" style="background-color: ButtonFace;">    

    <script type="text/javascript" language="javascript" src="javascript\classifiedEditor.js"></script>

    <table id="tables4" class="" cellpadding="0" cellspacing="0" style="width: 80%"
        height="30px" align="left" border="0" enableviewstate="false">
        
        <tbody>
            <tr>
                <td style="height: 20px; width: 68px;">
                    &nbsp;
                    <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Keyboard"></asp:Label></td>
                <td align="center" style="width: 72px">
                    <select id="KEYBORD" runat="server" class="dropdowns" onchange="javascript:getKeyboard();" style="width: 65px; z-index: 50;">
                        <option value="0">Select</option>
                        <option value="Remington">Remington</option> 
                        <option value="Phonatic">Phonatic</option>  
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
                <td style="height: 20px">
                    <asp:Label ID="Label1" runat="server" CssClass="proplbl" Text="Size"></asp:Label>
                </td>                
                
                <td align="center">
                  <asp:DropDownList ID="fntsize" Enabled="false" runat ="server" CssClass="dropdowns" AppendDataBoundItems="True" Width="45px" >
                    
                    </asp:DropDownList>
                </td>
                 <td id="tddown" runat="server" ><a style="cursor:hand;cursor:pointer" onclick="window.open('downloadFont.aspx')" class="folder">Download Font</a></td>
                
                
            </tr>
        </tbody>
    </table>
</div>
