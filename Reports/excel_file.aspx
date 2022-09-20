<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excel_file.aspx.cs" Inherits="excel_file" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
   <%-- <script type="text/javascript" language="javascript" src="javascript/access.js"/>--%>
   <script type="text/javascript" language="javascript" >
    function chk_val()
    {
    excel_file.GetData(call_back_excel);
    
    }
   
  function call_back_excel(res)
{
var ds=res.value;
//var chk=document.getElementById('excel');
//for(var t=0;t<ds.Tables[0].Rows.length;t++)
//{
//chk.options[chk.options.length] = new Option(ds.Tables[0].Rows[t].username,ds.Tables[0].Rows[t].userid);
//       chk.options.length;
//}
 //myControl1.UserData = ds;
 myControl1.UserText="abcd";

}
   </script>
</head>
<body>
<OBJECT id="myControl1" name="myControl1" classid="ActiveXDotNet.dll#ActiveXDotNet.myControl" width=288 height=72>
	 </OBJECT>
    <form id="form1" runat="server">
 <asp:DropDownList ID="excel" runat="server">
                                                              
                                                            </asp:DropDownList>
                                                            <input type=button value="Click me" onClick="chk_val();">
                                                                </form>
</body>
</html>
