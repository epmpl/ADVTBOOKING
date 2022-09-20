<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rotate.ascx.cs" Inherits="rotate" %>
<div id="rotatediv" class="dragprop" style="display: none; cursor: default; background-color: buttonface;
    border-bottom: double 4px #4a84ff; border-top: double 4px #4a84ff; border-left: double 4px #4a84ff;
    border-right: double 4px #4a84ff; width: 207px;left:2px;top:-108px;" unselectable="on">
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="images/Rotate.jpg" usemap="#closemaprotate" width="203px" unselectable=on  />
                <map id="closemaprotate" name="closemaprotate">
                    <area shape="rect" coords="188,15,200,2" alt="close" href="javascript:closerotatediv();"
                        style="cursor: hand;" />
                </map>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="label" Text="Specify Angle" runat="server" CssClass="proplbl"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 21px">
                <!-- <input id="Radio1" name="rotat" type="radio" /></td> -->
                <asp:RadioButton ID="radio0" runat="server" GroupName="g" Checked="true" />
            <td>
                <asp:Label ID="Label1" Text="Rotate By 0˚" runat="server" CssClass="proplbl"></asp:Label>
                <!-- <input type="button" id="rotatebtn1" class="topbutton" value="Rotate 90*" onclick="javascript:rotate1();" />-->
            </td>
        </tr>
        <tr>
            <td style="width: 21px">
                <!-- <input id="Radio1" name="rotat" type="radio" /></td> -->
                <asp:RadioButton ID="radio90" runat="server" GroupName="g" Checked="false" />
            <td>
                <asp:Label ID="Label4" Text="Rotate By 90˚" runat="server" CssClass="proplbl"></asp:Label>
                <!-- <input type="button" id="rotatebtn1" class="topbutton" value="Rotate 90*" onclick="javascript:rotate1();" />-->
            </td>
        </tr>
        <tr>
            <td style="width: 21px">
                <!--<input id="Radio2" name="rotat" type="radio" />-->
                <asp:RadioButton ID="radio180" runat="server" GroupName="g" />
            </td>
            <td>
                <asp:Label ID="Label5" Text="Rotate By 180˚" runat="server" CssClass="proplbl"></asp:Label>
                <!--<input type="button" id="rotatebtn2" name="Rotate1" class="topbutton" value="Rotate 180*" onclick=javascript:rotate2(); />-->
            </td>
        </tr>
        <tr>
            <td style="width: 21px">
                <!--<input id="Radio3"  name="rotat" type="radio" /></td>-->
                <asp:RadioButton ID="radio270" runat="server" GroupName="g" />
            </td>
            <td>
                <asp:Label ID="Label7" Text="Rotate By 270˚" runat="server" CssClass="proplbl"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 21px">
            </td>
            <td>
                <input type="button" id="rotatebtn" name="Rotate" class="inputbutton" value="Rotate"
                    onclick="javascript:turn90(); " />
            </td>
        </tr>
        <%--<asp:Button ID="Button1" runat="server" Text="Rotate" Width="71px" CssClass= />
            </td>
        </tr>--%>
    </table>
</div>
