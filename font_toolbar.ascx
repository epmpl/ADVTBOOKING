<%@ Control Language="C#" AutoEventWireup="true" CodeFile="font_toolbar.ascx.cs" Inherits="font_toolbar" %>
<link rel="stylesheet" type="text/css" href="CSS/main.css" />
<div id="fnttools" runat="server" unselectable="on" style="background-color: ButtonFace;">    
<link href="css/booking.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="javascript\classifiedEditor.js"></script>
 <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 999; " >
            <table cellpadding="0" cellspacing="0" border="1">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" onclick="return setVal();" onkEYDOWN="return chkKey(event);" Width="254px" Height="105px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    <table id="tables4" class="" cellpadding="0" cellspacing="0" style="width: 561px"
        height="30px" align="left" enableviewstate="false">
        
        <tbody>
            <tr>
                <td style="height: 20px; width: 68px;">
                    <asp:Label ID="Label2" runat="server" CssClass="proplbl" Text="Keyboard"></asp:Label></td>
                <td align="center" style="width: 62px">
                    <select id="KEYBORD" style="width: 90px" class="dropdowns" onchange="chgLanguage()">
                        <%--<option value="Phonatic">Phonatic</option> 
                        <option value="Roman">Roman</option>
                        <option value="Remington">Remington</option> --%>
                        <option value="Roman">Roman</option>
                          <option value="4CRemington2">4CRemington2</option>
                            <option value="4CTypewrite">4CTypewrite</option>
		                     <option value="Phonatic">4CPhonetic</option>
                            <option value="4CGodrej">4CGodrej</option>
                        
                        <%--<option value="Linotype">Linotype</option> 
                        <option value="Alternate">Alternate</option>--%>                                               
                    </select>
                </td>
                
                <td>
                    
                    <asp:Label ID="Label4" runat="server" CssClass="proplbl" Text="Language"></asp:Label>
                </td>
                <td align="center">
                   
                    <select id="fntname" tabindex="2" runat="server" style="width: 80px" class="dropdowns">
                       
                    </select>
                </td>                
                <td style="height: 20px">
                    <asp:Label ID="Label1" runat="server" CssClass="proplbl" Text="Size"></asp:Label>
                </td>                
                
                <td align="center">
                  <asp:DropDownList ID="fntsize" tabindex="3" Enabled="false" runat ="server" CssClass="dropdowns" AppendDataBoundItems="True" Width="45px" >
                    
                    </asp:DropDownList>
                </td>
                <td style="height: 20px">
                    <asp:Label ID="CioId" runat="server" CssClass="proplbl" Text="File Name" Width="58px"></asp:Label>
                </td>                
                <td align="center" id="td1">
               
                  <asp:TextBox ID="ddlcioid" onkEYDOWN="return chkKey(event);" tabindex="4" runat ="server" CssClass="dropdowns"  Width="155px">
                    
                    </asp:TextBox>
                     
                </td>               
              
            </tr>
           
        </tbody>
    </table>
       <input type="hidden" id="hidagcode" runat="server" />
</div>
