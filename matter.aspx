<%@ Page Language="C#" Debug="true" AutoEventWireup="true" ValidateRequest="false" CodeFile="matter.aspx.cs" Inherits="matter" %>

<!--<%@ Register TagPrefix="fonttlbr" TagName="tools" Src="~/fonttlbr.ascx" %>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>classified matter's</title>

    <script language="javascript" type="text/javascript" src="javascript/classified.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/key.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/keyboard.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/qbc.js"></script>

    <link href="css/booking.css" type="text/css" rel="stylesheet" />
<script language="javascript" type="text/javascript">
function doubleClick()
{
document.getElementById('editordiv').style.cursor
//-moz-user-select:none;
return false;
    //alert("double");
  //  document.getElementById('editordiv').style.
   //ent.getElementById('editordiv'));
    //alert(document.getElementById('editordiv').focus());
   // document.getElementById('editordiv').setAttribute("DefaultFocus","true")
    
}
function prev()
{
document.getElementById('hiddenfontname').value=document.getElementById('fnt_fntname').value;
document.getElementById('hiddenfontsize').value=document.getElementById('fnt_fntsize').value;
//window.open('matterpreview.aspx?fontsize='+document.getElementById('fnt_fntsize').value+'&fontname='+document.getElementById('fnt_fntname').value+'&eyecatch='+document.getElementById('hiddeneyecatcher').value+'&bgcolor='+document.getElementById('hiddenbgcolor').value+'&matter='+document.getElementById('editordiv').innerText,'Preview','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
  //  window.open("matterpreview.aspx?eyecatch=matter="+document.getElementById('editordiv').innerText);
    return false;
}
</script>
</head>
<body onload="document.getElementById('editordiv').focus();">
    <%--onload="javascript:getFonts();"--%>
    <object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px"
        height="0px">
    </object>
    <form id="form1" runat="server">
        <%--<div style="z-index:100; height:330px; width:850px; padding-left: 10px; border-style: double; overflow: auto; position: relative; padding-top: 10px; cursor: default;">--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                       
                        <asp:DropDownList runat="server" ID="KEYBORD">
                            <asp:ListItem Selected="True" Value="Remington">Remington</asp:ListItem>
                            <asp:ListItem  Value="Linotype">Linotype</asp:ListItem>
                            <asp:ListItem  Value="Phonatic">Phonatic</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="CmbLanguage">
                            <asp:ListItem Selected="True" Value="3">Hindi</asp:ListItem>
                            <asp:ListItem  Value="2">english</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    <%--onkeyup="javascript:return countchar();"--%>
                        
                      
                          <div runat="server" id="editordiv" onkeypress="javascript:return replacekey(event)" onkeydown="javascript:return Doc_OnKeyDown()"   contenteditable="true"></div>
                      
                        <div id="div1" ></div>
                    </td>
                    
                </tr>
                <tr align="left"><td class="printTextField" align="left">No of Lines
               <asp:TextBox id="txtnoofline" runat="server" ReadOnly="true" Width="50px" Height="20px" Font-Size="X-Small"></asp:TextBox>
               
                <asp:Button ID="btnprev" Width="75px" runat="server" CssClass="buttonsmall"
                                                                Text="Preview"    />
               <asp:Button ID="btnok" Width="75px" runat="server" CssClass="buttonsmall"
                                                                Text="Ok"/>     
               </td>
               
                </tr>
                <tr align="left">
                    <td align="left" class="printTextField">
                    </td>
                </tr>
                
                <tr align="left">
                    <td align="left" class="printTextField">
                    </td>
                </tr>
              
                <tr>
                <td><table style="display:none;"><tr><td><asp:Label ID="Label1" runat="server" Text="Insert Character" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:ListBox ID="lbpickchar" runat="server"></asp:ListBox></td>
                
                </tr></table></td>
                    <td>
                    
                        <asp:TextBox ID="txtbox1" Visible="false" runat="server" Width="0px"></asp:TextBox>
                        
                        </td>
                        
                        
                        
                </tr>
            </table>
            <input type="hidden" id="hiddeneyecatcher" runat="server" />
                        
                        <input type="hidden" id="hiddenbgcolor" runat="server" />
                          <input type="hidden" id="hiddenfontname" runat="server" />
                        
                        <input type="hidden" id="hiddenfontsize" runat="server" />
                        <input type="hidden" id="hiddeneyecatchlength" runat="server" />
                        <input type="hidden" id="hiddenmatter" runat="server" />
                        <input type="hidden" id="hiddenwidth" runat="server" />
                        <input type="hidden" id="hiddenuom" runat="server" />
                        <input type="hidden" id="hiddeninsert" runat="server" />
                        <input type="hidden" id="cioid" runat="server" />
                        <input type="hidden" id="hiddenedition" runat="server" />
                        <input type="hidden" id="hiddensrno" runat="server" />
                        <input type="hidden" id="hiddenFileName" runat="server" />
                        <input type="hidden" id="hiddenInsertNo" runat="server" />
                        <input type="hidden" id="hiddencoltype" runat="server" />
                        <input type="hidden" id="hiddenuom_desc" runat="server" />
                        <input type="hidden" id="hiddenlogoname" runat="server" />
                        <input type="hidden" id="hiddenmodify" runat="server" />
                        
                        <input type="hidden" id="hiddenlogohei" runat="server" />
                        <input type="hidden" id="hiddenlogowid" runat="server" />
                        <input type="hidden" id="hiddensessionlogo" runat="server" />
                        <input type="hidden" id="hiddenpreviousid" runat="server" />
                        <input type="hidden" id="hiddeneyecatchval" runat="server" />
                        <input type="hidden" id="hiddenbPrem" runat="server" />
                        <input type="hidden" id="hiddenLineCount" runat="server" />
        </div>
        <%--</div>--%>
    </form>
</body>
</html>
