<%@ Page Language="C#" AutoEventWireup="true" CodeFile="keymapper.aspx.cs" Inherits="keymapper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" src="javascript/key.js" type="text/javascript"></script>
    <script language="javascript">
    function disabled()
    {
    //document.getElementById('KM').style.display="none";
    //return false;
    }
    </script>
</head>
<body onload="return disabled();">
    <form id="form1" runat="server">
    <div>
    <table><tr><td>
    
            <object id="KM"  codebase="InternetMapper.CAB#version=1,0,0,0" 
            classid="CLSID:87CB3D9B-71E2-42A0-83A1-B946A8C59DA1"  VIEWASTEXT>
            
	<param name="_ExtentX" value="2514">
	<param name="_ExtentY" value="556">
	</object>
								</td></tr>
								<tr><td style="height: 42px"><div id="editordiv" onkeypress="replacekey(event);" tabIndex="29" contentEditable="true"
										style="OVERFLOW: auto; WIDTH: 700px; HEIGHT: 100px; WORD-WRAP: break-word">
									</div></td></tr>
								<tr><td><input type="text" value="Bhaskar" id="DD_language"  /></td></tr>
								</table>
    </div>
    </form>
</body>
</html>
