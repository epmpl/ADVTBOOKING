<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editor_new.aspx.cs" Inherits="editor_new" %>
<%@ Register TagPrefix="fnttoolbar_new" TagName="tools" Src="~/fnttoolbar_new.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-Type" content="text/html; charset=windows-1252" />
    <title>Classified Editor New</title>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="javascript/classifiedEditor.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/classified.js"></script>  
    <script language="javascript" type="text/javascript" src="javascript/key.js"></script>  
    <script type="text/javascript">
           var clientfromconfig1;
           clientfromconfig1 = '<%=ConfigurationManager.AppSettings["CLIENTNAME"].ToString()%>'
    </script> 
 
        <![if IE]>
     <script language="javascript" type="text/javascript" src="javascript/texteditorcode_ie.js"></script>
   <![endif]>
   <![if !IE]>
     <script language="javascript"  type="text/javascript"src="javascript/textboxkbrd_gecko.js"></script>
   <![endif]>
   
 <script type="text/javascript">
     var crome = false;
</script>

<script type="text/javascript">
    if (navigator.userAgent.toLowerCase().indexOf('chrome') > 1)
        crome = true;
    </script>  
    
<script type="text/javascript">
    function roll_over(img_name, img_src)
    { 
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
    clientfromconfig = '<%=ConfigurationManager.AppSettings["CLIENTNAME"].ToString()%>'
</script>
<script type="text/javascript">
    var fnamechange = "";
    function chgLanguage() {
      
        if (browser != "Microsoft Internet Explorer") {
            if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "Roman") {
                document.getElementById('fnt_fntname').selectedIndex = 1; //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
                document.getElementById('editordiv').focus();
                fnamechange = document.getElementById('fnt_fntname').value;
                return true;
            }
            else {
                document.getElementById('fnt_fntname').selectedIndex = 0;  //options[document.getElementById('fnt_fntname').selectedIndex].textContent = "Hindi";
                document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
                document.getElementById('editordiv').focus();
                fnamechange = document.getElementById('fnt_fntname').value;
              //  alert(fnamechange);
            }
        }
        else {//fnt_KEYBORD
            if (document.getElementById('KEYBORD').options[document.getElementById('KEYBORD').selectedIndex].textContent == "Roman") {
                document.getElementById('fnt_fntname').selectedIndex = 1;     //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
                
            }
            else {
                document.getElementById('fnt_fntname').selectedIndex = 0;    //options[document.getElementById('fnt_fntname').selectedIndex].selected = true;
                document.getElementById('editordiv').focus();
                document.execCommand("FontName", false, document.getElementById('fnt_fntname').value);
                
            }
        }
        return false;
    }
</script>
</head>
<body style="font-size:22px;"  onkeydown="return chgkeyboard(event);">
    <script type="text/javascript">
          if (navigator.userAgent.toLowerCase().indexOf('chrome') > 1)
              crome = true;
    </script>
    <object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px"
        height="0px">
    </object>
    <form id="form1" runat="server">        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <fnttoolbar_new:tools ID="fnt" runat="server" />  
                    </td>
                </tr>
                <tr>
                    <td>
                    <div id="editordiv"  onkeydown="return Doc_OnKeyDown(event);" contenteditable="true"  runat="server" style="line-height: 20px;font-size:22px; 
                            height: 250px; width: 680px; padding-left: 10px; border-style: double; overflow: auto;
                            position: relative; padding-top: 10px; cursor: default; z-index: 99; word-wrap: break-word; left: 0px; top: 0px;font-family:eDBBhaskarmetrix"
                               oncopy="javascript:return false;" onkeypress="replacekey(event);"   > <%--onkeypress="javascript:return placeSymbol(event);"--%>                               
                        </div>
                    
                        <div id="div1"></div>
                    </td>
                     <td id="Td1" style="width:170px" runat="server">
                    <div id="divmatter" contenteditable="true" runat="server" style="line-height: 20px;height: 250px; padding-left: 10px; 
                     border-style: double; overflow: auto;position: relative; padding-top: 10px;word-wrap: break-word;"></div>
                    </td>
                </tr>
                <tr align="left"><td class="printTextField" align="left">No of Lines/Words
               <asp:TextBox id="txtnoofline" runat="server" Enabled="false" CssClass="btextforbook"></asp:TextBox>
               
                <asp:Button ID="btnprev" Width="75px" runat="server" CssClass="buttonsmall" Text="Preview"   />
                <asp:Button ID="btncalline" style="display:none" Width="110px" runat="server" CssClass="buttonsmall" Text="Calculate Lines/Words"  />
               <asp:Button ID="btnok" Width="75px" runat="server" CssClass="buttonsmall" Text="Ok"/> 
			    <asp:Button ID="btnCopytoEditor" Width="150px" runat="server" CssClass="buttonsmall"  Text="Copy to Editor"/>
               </td>
               
                </tr>
                <tr><td id="tdlogo" runat="server"> <%--visible="false">--%>
                <table>
                <tr><td class="TextField"><b><u>Logo Details</u></b></td></tr>
                <tr><td class="TextField">Logo Height</td><td><input type="text" id="txtlogohei" class="btextsmallqbc" runat="server"  /></td> <%--disabled="disabled"--%>
                <td class="TextField">Logo Col.</td><td ><input type="text" id="txtlogowid" class="btextsmallqbc"  runat="server" /></td></tr><%--disabled="disabled"--%>
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
                        <input type="hidden" id="hiddenboldchar" runat="server" />     
                        <input type="hidden" id="hiddeninsertstatus" runat="server" />     
                        <input type="hidden" id="hiddenlogoprem" runat="server" />                   
 <input type="hidden" id="hidformname" runat="server" />  
  <input type="hidden" id="hidreceipt" runat="server" />   
                </tr>
            </table>
        </div>
        <%--</div>--%>
    </form>
</body>
</html>
