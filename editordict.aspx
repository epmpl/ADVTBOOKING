<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="editordict.aspx.cs" Inherits="editordict" %>

<%@ Register TagPrefix="fnttoolbar3" TagName="tools" Src="~/fnttoolbar3_dict.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Classified Editor</title>

    
     <script language="javascript" type="text/javascript" src="javascript/classified.js"></script>  
      <script language="javascript" type="text/javascript" src="javascript/key.js"></script>      
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
<script>
function roll_over(img_name, img_src)
 { 
 //alert('8')
 if(document.all)
 {
  document[img_name].src = img_src;
 }
 else
 {
 if(enable==1)
 {
 document[img_name].src = img_src;
 }
 }
 
 }
    function preview()
    {
        document.getElementById('hiddenfontname').value=document.getElementById('fnt_fntname').value;
        document.getElementById('hiddenfontsize').value=document.getElementById('fnt_fntsize').value;    
        return false;
    }
  
</script>
</head>
<body style="font-size:22px;">
    <object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px"
        height="0px">
    </object>
    <form id="form1" runat="server">        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <fnttoolbar3:tools ID="fnt" runat="server" />  
                    </td>
                </tr>
                <tr>
                    <td>
                    <div id="editordiv" contenteditable="true" runat="server" style="line-height: 20px;font-size:22px; 
                            height: 250px; width: 680px; padding-left: 10px; border-style: double; overflow: auto;
                            position: relative; padding-top: 10px; cursor: default; z-index: 99; word-wrap: break-word; left: 0px; top: 0px;"
                               oncopy="javascript:return false;" onkeypress="javascript:return placeSymbol(event);">
                        </div>
                    
                        <div id="div1"></div>
                    </td>
                    
                </tr>
                <tr align="left"><td class="printTextField" align="left">No of Lines/Words
               <asp:TextBox id="txtnoofline" runat="server" Enabled="false" CssClass="btextforbook"></asp:TextBox>
               
                <asp:Button ID="btnprev" Width="75px" runat="server" CssClass="buttonsmall"
                                                                Text="Preview"   />
                                                                  <asp:Button ID="btncalline" Width="110px" runat="server" CssClass="buttonsmall"
                                                                Text="Calculate Lines/Words"   />
               <asp:Button ID="btnok" Width="75px" runat="server" CssClass="buttonsmall"
                                                                Text="Ok"/>     
               </td>
               
                </tr>
                <tr><td id="tdlogo" runat="server" visible="false">
                <table>
                <tr><td class="TextField"><b><u>Logo Details</u></b></td></tr>
                <tr><td class="TextField">Logo Height</td><td><input type="text" id="txtlogohei" class="btextsmallqbc" runat="server" disabled="disabled" /></td>
                <td class="TextField">Logo Width</td><td ><input type="text" id="txtlogowid" class="btextsmallqbc" disabled="disabled" runat="server" /></td></tr>
                <tr><td class="TextField">Logo Name</td><td colspan=2><input type="text" id="txtlogoupload" class="btextforbook" disabled="disabled" runat="server" /></td><td> <asp:Button ID="btnlogoupload" runat="server" Text="Upload Logo" Width="70px" CssClass="buttonsmall" Enabled="False" /></td></tr>
                </table>
                </td></tr>
                <tr>
                <td><table style="display:none;"><asp:Label ID="Label1" runat="server" Text="Insert Character" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:ListBox ID="lbpickchar" runat="server"></asp:ListBox></td>
                
                </tr>
              
                <tr>
                    <td>
                        <asp:TextBox ID="txtbox1" Visible="false" runat="server" Width="0px"></asp:TextBox></td>
                        
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
                        
                </tr>
            </table>
        </div>
        <%--</div>--%>
    </form>
</body>
</html>
