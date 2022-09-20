<%@ Page Language="C#" AutoEventWireup="true" CodeFile="summarized_reportview.aspx.cs" Inherits="summarized_reportview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <title>Status Wise Daily Summarized Report</title>
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
  
   

   
    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    
</head>
<body onload="document.getElementById('btnprint').focus();">
<form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>

<div id="abc">



   <table style="width:100%" >
  
<tr><td></td>
<td align="center" style="height: 28px;padding-right:130px" colspan="2"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
</tr>
<tr style="width:100%">


<td align="left" style= "height: 28px;"  >
<asp:Button ID="btnprint" runat="server"  OnClick="btnprint_Click" Text="Print" />
</td>
<td align="center" style="height: 28px;padding-right:130px" colspan="2">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>

</tr>
<tr><td style="width: 69px"></td></tr>

</table>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr >
        <td  class="upper2" valign="top" >DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" valign="top" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" valign="top">RUN DATE:</td><td class="middle2" ><asp:Label ID="lblrundate" CssClass="reporttext2" runat="server" ></asp:Label></td>
       
    <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top" >PUBLICATION:</td><td class="middle2"><asp:Label ID="lblpublication" CssClass="reporttext2" runat="server"></asp:Label></td>    
    <td  class="upper2" valign="top" >CENTER:</td><td class="middle2" ><asp:Label ID="lbcent" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2" valign="top" >EDITION:</td><td class="middle2" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>
     
  


</tr>
 <tr style="border-bottom:dashed">
           <td  class="upper2" valign="top" >AD TYPE:</td><td class="middle2"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server"></asp:Label></td>    
        
</tr>


     
    </table>
   
     <table style="width: 97%"><tr valign="top"><td valign="top" id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr></table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
           
  
        </tr>
    </table>
     <table id="xlsgrid" align="center" style="width: 1000%" >
     <tr>
       
     <td align="center">
     <asp:DataGrid ID="DataGrid1" runat="server"  Width="1000px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
     <SelectedItemStyle Font-Size="X-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
     </HeaderStyle>
     </asp:DataGrid>
     </td>
     </tr>
     </table>
  
    
    
          <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" />
               
                <input id="hiddencioid" type="hidden" runat="server" />
               <input id="hiddenascdesc" type="hidden" runat="server" />
               <input id="hidden1" type="hidden" runat="server" />
               <input id="hiddenadtype" type="hidden" runat="server" />
               </td></tr></table>
 
</div>


    </form>
</body>
</html>
