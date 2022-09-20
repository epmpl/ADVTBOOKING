<%@ Control Language="C#" AutoEventWireup="true" CodeFile="confirm.ascx.cs" Inherits="confirm" %>
 <div id="confirmdialog" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 7px #4a84ff; border-top: double 7px #4a84ff; border-left: double 7px #4a84ff;
    border-right: double 7px #4a84ff; position: relative; top: -20px; left: -500px;" unselectable="on">
            <table cellpadding="5" cellspacing="5" height="100%" width="100%" style="background-color: ButtonFace;">
                <tr>
                    <td colspan="3">
                        <span class="proplbl">Please save before opening New Template</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <input type="button" id="yes_click" class="inputbutton" value="Yes" runat="server"
                            onclick="javascript:ifyes();" />
                    </td>
                    <td align="center">
                        <input type="button" id="no_click" class="inputbutton" value="No" runat="server"
                            onclick="javascript:ifno();" />
                    </td>
                    <td align="left">
                        <input type="button" id="cancel_click" class="inputbutton" value="Cancel" runat="server"
                            onclick="javascript:ifcancel();" />
                    </td>
                </tr>
            </table>
        </div>