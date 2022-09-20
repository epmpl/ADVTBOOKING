<%@ Page Language="C#" AutoEventWireup="true" CodeFile="saveme.aspx.cs" ValidateRequest="false" Inherits="saveme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Save ::Admaking</title>
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <script type="text/javascript" src="js/ctrl.js"></script>
    <script language="javascript" type="text/javascript" src="js/enterortab.js"></script>
    <%--<script language="javascript" type="text/javascript" src="js/entertab.js"></script>--%>

</head>
<body onkeydown="javascript:tabvalue();" style="background-color: ButtonFace" onload="document.getElementById('savexml').value = opener.document.getElementById('editordivxml').value; document.getElementById('savehtml').value = opener.document.getElementById('editordivhtml').value;document.getElementById('completehtml').value=opener.document.getElementById('editordivfullhtml').value;document.getElementById('adheight').value=opener.document.getElementById('adheight').value;document.getElementById('adwidth').value=opener.document.getElementById('adwidth').value;document.getElementById('uom').value=opener.document.getElementById('sel_unit_disp').value;">
    <form id="form1" method="post" runat="server">
        <div>
            <table border="0">
                <tr>
                    <td><asp:Label ID="mylabel" runat="server" CssClass="proplbl">Template Name:</asp:Label>
                       <asp:TextBox ID="filename" runat="server" Width="100px" Height="17px" MaxLength="30" CssClass="btext" ToolTip="Name of template"></asp:TextBox>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="filename"></asp:RequiredFieldValidator></td>
                </tr>
              
                <tr>
                    <td>
                      <asp:Label ID="lblcatname" runat="server" CssClass="proplbl" Style="left: -4px; top: 44px" Text="Category" Width="62px"></asp:Label>
                      <asp:DropDownList ID="catname" runat="server"   CssClass="dropdowns" Width="82px"></asp:DropDownList>
                     </td>
               </tr>
                
                <tr>
                 <td align="center" style="width: 92px"></td>
                </tr>
                
                  <tr>
                    <td><asp:Button ID="saveT" runat="server" Text="save" CssClass="button1"  TabIndex="1" OnClick="saveT_Click" /> 
                        <input type="button" id="cancelT" value="Cancel" class="button1" style="width: 77px;"  onclick="javascript:closeme();" tabindex="2" />
                    </td>  
                        <%-- <input type="hidden" id="savehidden" runat="server" />--%>
                         <%--<asp:Button ID="saveT" runat="server" class="button1" Text="Save" Width="77px" TabIndex="1" /> --%>
                         <%--<input type="button" value="Save" class="button1" id="saveT" style="width: 77px" onserverclick="saveT_Click1" runat="server" tabindex="1" />--%>
                  </tr>
                     <tr><td>
                       <input type="hidden" id="xmlval" runat="server" />
                        <%--<asp:TextBox ID=temp_id runat=server Width="149px" CssClass="btext" ></asp:TextBox>--%>
                        <input type="hidden" id="temp_id" runat="server" />
                        <input type="hidden" id="completehtml" runat="server" />
                        <input id="savehtml" runat="server" type="hidden" />
                        <input id="savexml" runat="server" type="hidden" />
                         <input type="hidden" id="uom" runat="server" />
                          <input type="hidden" id="adwidth" runat="server" />
                         <input type="hidden" id="adheight" runat="server" />
                         <input type="hidden" id="tempnamehidden" runat="server"/>
                         <input type="hidden" id="cat_code" runat="server" />
               </td></tr>
                
            </table>
        </div>
    </form>
</body>
</html>
