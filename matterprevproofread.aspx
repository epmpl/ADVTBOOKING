<%@ Page Language="C#" AutoEventWireup="true" CodeFile="matterprevproofread.aspx.cs" Inherits="matterprevproofread" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Matter Prev</title>
     <link href="css/booking.css" type="text/css" rel="stylesheet" />
     <script>
         function fillfilename() {
             var packagecode = opener.document.getElementById('hiddenpublicode').value;
             var res = matterprevproofread.findpub(packagecode);
             var ds = res.value;
             if (opener.document.getElementById('hiddenFileName').value != "") {
                 var hiddenfilename_vari = opener.document.getElementById('hiddenFileName').value;
                 var hiddenfilename_vari1 = hiddenfilename_vari.split('-'); //0007497-LO2 .xtg
                 hiddenfilename_vari1 = hiddenfilename_vari1[1].split('.');
                 var linecount = opener.document.getElementById('hiddenLineCount').value;
             }
             if (ds.Tables[0].Rows.length > 0) {
                 var datalengt = ds.Tables[0].Rows[0].PUBLS.split(',');
                 for (var i = 0; i < datalengt.length; i++) {
                     if (datalengt[i].trim() == hiddenfilename_vari1[0].trim()) {
                         matterprevproofread.findmatterpub(hiddenfilename_vari1[0].trim());
                         ///opener.document.getElementById('hiddenfilenme111').value = hiddenfilename_vari;
                         opener.document.getElementById('filename_' + i).value = hiddenfilename_vari;
                         opener.document.getElementById('linecount_' + i).value = linecount;

                     }
                 }
             }
             window.close();
             return false;

         } 
     </script>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="word-wrap: break-word; position:absolute; zoom:250%;-moz-transform: scale(3);">
    <table  style="width:50%; Max-width:50%; float:left;"><tr><td id="td1" runat="server"></td></tr></table ><table  style="width:50%; float:left;position: absolute;
left: 176px;"><tr><td><asp:Button ID="btndone"  runat="server" CssClass="matterprewbutton" Text="Done" /></td></tr>
   
    </table>
    <input type="hidden" runat="server" id="hiddencio" />
    <input type="hidden" runat="server" id="hid1" />
    <input type="hidden" runat="server" id="Hiddeninser" />
    <input type="hidden" runat="server" id="hiddenagencyratecode" />
    <input type="hidden" runat="server" id="hiddendatabasename" />
    <input type="hidden" runat="server" id="hiddenagencycode" />
    </div> 
    </form>
</body>
</html>
