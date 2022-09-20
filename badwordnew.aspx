<%@ Page Language="C#" AutoEventWireup="true" CodeFile="badwordnew.aspx.cs" Inherits="badwordnew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <form id="form1" runat="server">
       <table cellpadding="0" cellspacing="0" width="380px" height="400px" >
            <tr>
               <td>
                  <div class="editor" id="bword" contenteditable="true"></div>
                </td>
             </tr>                   
      </table>
      <table>
           <tr>
             <td><asp:Button ID="submit" runat="server" Text="submit" /></td>
          </tr>
     </table>
  </form>
  </body>
</html>
