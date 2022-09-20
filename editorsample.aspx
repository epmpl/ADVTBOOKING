<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editorsample.aspx.cs" Inherits="editorsample" %>
<%@ Register TagPrefix="fnttoolbar3" TagName="tools" Src="~/fnttoolbar3.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript" src="javascript/classifiedEditor.js"></script>
    <script language="javascript">
    function verify() 
{ 
     // 0 Object is not initialized 
     // 1 Loading object is loading data 
     // 2 Loaded object has loaded data 
     // 3 Data from object can be worked with 
     // 4 Object completely initialized 
     if (xmlDoc.readyState != 4) 
     { 
       return false; 
     } 
}
    function loadXML(xmlFile) 
{
var browser=navigator.appName;  
    var  httpRequest =null;
    
    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }

}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <fnttoolbar3:tools ID="fnt" runat="server" />  
                    </td>
                </tr>
                <tr>
                    <td>
                    <div id="editordiv" contenteditable="true" runat="server" style="line-height: 20px; font-size:20px;
                            height: 250px; width: 680px; padding-left: 10px; border-style: double; overflow: auto;
                            position: relative; padding-top: 10px; cursor: default; z-index: 99; word-wrap: break-word; left: 0px; top: 0px;"
                             onkeypress="replacekey(event);"  onkeydown="javascript:return Doc_OnKeyDown(event)">
                        </div>
                    
                        <div id="div1"></div>
                    </td>
                    
                </tr>
                </table>
    </div>
    </form>
</body>
</html>
