<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mozilla.aspx.cs" Inherits="mozilla" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
    <script language="javascript">
    function checkmoz()
           {
             var browser=navigator.appName;
             var  httpRequest =null;
            if(window.XMLHttpRequest)
                {
                  httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) {
                        httpRequest.overrideMimeType('text/xml'); 
                     }
                  
                }
            else if (window.ActiveXObject) { // IE
                try {
                    httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
                    } 
                catch (e) {
                    try {
                        httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
                        }
                    catch (e) {}
                 }
            }
httpRequest.onreadystatechange = function() { alertContents(httpRequest); };
httpRequest.open('GET', "moz1.aspx", true);
httpRequest.send('');
return false;
}
function alertContents(httpRequest) {

    if (httpRequest.readyState == 4) {
        if (httpRequest.status == 200) {
            alert(httpRequest.responseText);
        } else {
        alert('There was a problem with the request.');
        }
    }

}

function result()
{
    alert(document.getElementById('hid1').value);
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" id="bt1" onclick="javascript:return checkmoz();" />
    <asp:Button ID="btn1" runat="server" Text="go" OnClick="btn1_Click" />
    <input type="button" OnClick="javascript:return result();" />
    <input type="hidden" id="hid1" runat="server" />
    </div>
    </form>
</body>
</html>
