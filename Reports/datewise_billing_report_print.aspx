<%@ Page Language="C#" AutoEventWireup="true" CodeFile="datewise_billing_report_print.aspx.cs" Inherits="datewise_billing_report_print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
        <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="javascript/datewise_billing_report.js"></script>
    <title>Date Wise Billing Summary</title>
</head>
   
<body onload="javascript:return print1();">
    <form id="form1" runat="server">
    <div>
    
            
   
             <table style="width: 97%" >
                                     <%--<tr>
                                             <td align="left">
                                                       <asp:Button ID="btnprint" runat="server" Text="Print"  />       
                                             </td>
                                      </tr> --%>  
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
      <asp:DataGrid ID="DataGrid2" runat="server" CssClass="dtGrid" Width="570px" AutoGenerateColumns="False"> <%--OnItemDataBound="DataGrid1_ItemDataBound"  >--%>
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
           	
           	
           		<input id="hdnmainagency11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnsubagency11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnagname11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnfromdate11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdntodate11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnprinting_centercode11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnprinting_centername11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnbranchcode11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnbranchname11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdncom_out11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnrcpt_uptodate11" type="hidden" name="hdnuserid" runat="server" />
           		<input id="hdnretype" type="hidden" name="hdnretype" runat="server" />
           		<input id="hdnretype11" type="hidden" name="hdnretype" runat="server" />
           		<input id="hdnreptype11" type="hidden" name="hdnreptype" runat="server" />
           		<input id="hdntype11" type="hidden" name="hdntype11" runat="server" />
           		<input id="hdnextra111" type="hidden" name="hdnextra1" runat="server" />
           		<input id="hdnextra211" type="hidden" name="hdnextra2" runat="server" />
           		<input id="hdnextra311" type="hidden" name="hdnextra2" runat="server" />
           		<input id="hdnextra411" type="hidden" name="hdnextra2" runat="server" />
           		<input id="hdnextra511" type="hidden" name="hdnextra2" runat="server" />
           		<input id="hdnpublication" type="hidden" name="hdnpublication" runat="server" />
           		<input id="hdnpubname" type="hidden" name="hdnpubname" runat="server" />
           		<input id="hdnadtype" type="hidden" name="hdnadtype" runat="server" />
           		<input id="hdnad_type" type="hidden" name="hdnad_type" runat="server" />
           		<input id="hdnadcat" type="hidden" name="hdnadcat" runat="server" />
           		<input id="hdnad_cat" type="hidden" name="hdnad_cat" runat="server" />
           		
           		
    </form>
    
   
        
        
</body>
</html>
