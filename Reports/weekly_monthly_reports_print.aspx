<%@ Page Language="C#" AutoEventWireup="true" CodeFile="weekly_monthly_reports_print.aspx.cs" Inherits="weekly_monthly_reports_print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
        <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="javascript/weekly_monthly_reports.js"></script>
    <title>Weekwise and Publication wise Revenue</title>
</head>
<body  onload="javascript:return print1();">
    <form id="form1" runat="server">
    <div>
    
            
   
             <table style="width: 97%" >
                                     <%--<tr>
                                             <td align="left">
                                                       <asp:Button ID="btnprint" runat="server" Text="Print"  />       
                                             </td>
                                      </tr>   --%>
                                      <tr valign="top" >
                                                    <td id="tblgrid" runat="server"  visible ="true"></td>
                                      </tr> 
             
             
           
             </table>

             <table>
                                      <tr> 
                                                    <td>
                                                               <input id="hidden1" type="hidden" runat="server" />
                                                    </td>
                                      </tr>
             </table>
             <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
                                      <tr>
            
    

            
       
                                     </tr>
             </table>
             
 <table id="Table3" align="center">
     <tr>
       
     <td align="center">       
      <asp:DataGrid ID="DataGrid2" runat="server" CssClass="dtGrid" Width="1500px" AutoGenerateColumns="False"> <%--OnItemDataBound="DataGrid1_ItemDataBound"  >--%>
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
     </HeaderStyle>
     </asp:DataGrid>
     </td>
     </tr>
     </table>

    
    </div>
           	<input id="HDN_dateformat" type="hidden" name="HDN_dateformat" runat="server" />
        	<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
           	<input id="hdncompcode" type="hidden" name="hdncompcode" runat="server" />
           	<input id="hdnuserid" type="hidden" name="hdnuserid" runat="server" />
           	<input type="hidden" id="hdnunit" runat="server" name="hdnunit" />
           	
           	
           		<input id="hdnfromdate11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdntodate11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnbasedon" type="hidden" name="hdnbasedon" runat="server" />
           		<input id="hdnprinting_centercode11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnprinting_centername11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnbranchcode11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnbranchname11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnextra111" type="hidden" name="hdnextra1" runat="server" />
           		<input id="hdnextra211" type="hidden" name="hdnextra2" runat="server" />
           		<input id="hdnextra311" type="hidden" name="hdnextra3" runat="server" />
           		<input id="hdnextra411" type="hidden" name="hdnextra4" runat="server" />
           		<input id="hdnextra511" type="hidden" name="hdnextra5" runat="server" />
           		<input id="hdnextra611" type="hidden" name="hdnextra6" runat="server" />
           		<input id="hdnextra711" type="hidden" name="hdnextra7" runat="server" />
           		<input id="hdnextra811" type="hidden" name="hdnextra8" runat="server" />
           		<input id="hdnextra911" type="hidden" name="hdnextra9" runat="server" />
           		<input id="hdnextra10" type="hidden" name="hdnextra10" runat="server" />
           		<input id="hdnpublication" type="hidden" name="hdnpublication" runat="server" />
           		<input id="hdnpubname" type="hidden" name="hdnpubname" runat="server" />
           		<input id="hdnadtype" type="hidden" name="hdnadtype" runat="server" />
           		<input id="hdnad_type" type="hidden" name="hdnad_type" runat="server" />
           		<input id="hdnadcat" type="hidden" name="hdnadcat" runat="server" />
           		<input id="hdnad_cat" type="hidden" name="hdnad_cat" runat="server" />
           		
           		
    </form>
    
   
        
        
</body>
</html>

