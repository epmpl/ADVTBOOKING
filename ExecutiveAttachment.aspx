<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExecutiveAttachment.aspx.cs" Inherits="ExecutiveAttachment" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Executive Attachment</title>
    <script language="javascript">
    function closeattach()
    {var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer") {
         window.opener.document.getElementById('hidattachment').value=document.getElementById('lebforattach').textContent;

}
else {

        //window.opener.document.getElementById('hidattach1').value=document.getElementById('lblfilename').innerHTML;
    window.opener.document.getElementById('hidattachment').value = document.getElementById('lebforattach').innerText;
   // alert(window.opener.document.getElementById('hidattachment').value)
} if (window.opener.document.getElementById('hidattachment').value != "")
    window.opener.document.getElementById('hidattachment').src = "Images/indexred.jpg";
        window.close();
    }
    function openfile()
    {
        window.open("Attachment/" + document.getElementById('lblfilename').innerHTML);
        return false;
    }
     function openfilenew(filename)
    {
        window.open("Attachment/" + filename);
        return false;
    }
    function delfilenew(filename)
    {
        //alert("bhanu");
        document.getElementById('hid').value=document.getElementById('lebforattach').innerHTML=document.getElementById('hid').value.replace("<a onclick=openfilenew('"+filename+"')><font style=\"HEIGHT: 25px\" color=\"blue\">"+filename+"</font></a><img onclick=delfilenew('"+filename+"') src=Images/del.jpg>","");
        if(document.getElementById('hid').value.substring(document.getElementById('hid').value.length-1,document.getElementById('hid').value.length)==",")
        document.getElementById('hid').value=document.getElementById('lebforattach').innerHTML=document.getElementById('hid').value.substring(0,document.getElementById('hid').value.length-1)
        if(document.getElementById('hid').value.substring(0,1)==",")
        document.getElementById('hid').value=document.getElementById('lebforattach').innerHTML=document.getElementById('hid').value.substring(1,document.getElementById('hid').value.length)
        
        return false;
    }
    function addlabel(filename)
    {
        //alert(document.getElementById('lebforattach').innerHTML);
        if(document.getElementById('hid').value=="")
           document.getElementById('hid').value=document.getElementById('lebforattach').innerHTML="<a onclick=openfilenew('"+filename+"')><font style=\"HEIGHT: 25px\" color=\"blue\">"+filename+"</font></a><img onclick=delfilenew('"+filename+"') src=Images/del.jpg>";
           else
        document.getElementById('hid').value=document.getElementById('lebforattach').innerHTML = document.getElementById('hid').value +"," + "<a onclick=openfilenew('"+filename+"')><font style=\"HEIGHT: 25px\" color=\"blue\">"+filename+"</font></a><img onclick=delfilenew('"+filename+"') src=Images/del.jpg>";
        //document.getElementById('lebforattach').title   = filename;
        return false;
    }
    
    function selval(filename)
    {
    if(document.getElementById('hid').value=="")
    {
        var hidvalue = window.opener.document.getElementById('hidattachment').value;
        if (window.opener.document.getElementById('hidattachment').value != "")
        {
        var splitselect=hidvalue.split(",")
        for(var t=0;t< splitselect.length;t++)
        {
         if(document.getElementById('hid').value=="")
           document.getElementById('hid').value=document.getElementById('lebforattach').innerHTML="<a onclick=openfilenew('"+splitselect[t]+"')><font style=\"HEIGHT: 25px\" color=\"blue\">"+splitselect[t]+"</font></a><img onclick=delfilenew('"+splitselect[t]+"') src=Images/del.jpg>";
           else
          document.getElementById('hid').value=document.getElementById('lebforattach').innerHTML = document.getElementById('hid').value +"," + "<a onclick=openfilenew('"+splitselect[t]+"')><font style=\"HEIGHT: 25px\" color=\"blue\">"+splitselect[t]+"</font></a><img onclick=delfilenew('"+splitselect[t]+"') src=Images/del.jpg>";
        }
        }
        }
        
        return false;
    }
    
    </script>
</head>
<body onload="javascript:return selval();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
    <div>
    <table><tr><td>
      <asp:Label ID="lblattach" runat="server" style="font-family: verdana;font-size: x-small" Text="Upload Attachment"></asp:Label>
      </td></tr>
      <tr><td><asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button1" 
              runat="server"  Text="Save" style="font-family: verdana;font-size: small;background-color:#e1e1e1;" onclick="Button1_Click" /></td></tr>
      <tr><td style="height:10px"></td></tr>
      <tr><td><asp:LinkButton ID="lblfilename" runat="server" style="font-family: verdana;font-size: small"></asp:LinkButton><asp:Label ID="lebforattach" runat="server" style="font-family: verdana;font-size: x-small"></asp:Label><asp:Button ID="btnok" style="font-family: verdana;font-size:small; background-color:#e1e1e1;" runat="server" Text="OK" />
          </td></tr>
      </table>
    </div>
    <div style="overflow:auto; height:100">
                                <table cellpadding="0" cellspacing="0" border="0" align="left">
                                <tr>
                                  <td style="height:100px" id="gridopen" runat="server"></td>  
                                                              
                               </tr>
                               
                             
                               
                               <tr>
                                 
                                  <td id="save" runat="server"></td>
                               </tr>
                         
                             </table></div>
                             <input id="hid" type="hidden" size="1" name="Hidden2" runat="server" />
    </form>
</body>
</html>
