<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ad_master_runreport.aspx.cs" Inherits="Reports_ad_master_runreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <table style="width: 97%" >
             <%--<tr>
                        <td align="left">
                            <asp:Button ID="btnprint" runat="server" Text="Print"  />       
                        </td>
                 </tr>  --%> 
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
                                  <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791">
                                  </SelectedItemStyle>
                                  <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
                                  </HeaderStyle>
                        </asp:DataGrid>
                    </td>
                </tr>
            </table>
                 
         </div>
    
    
            <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
            <input id="hiddencompname" type="hidden" name="hiddencompname" runat="server" />
            <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server" />
            <input id="hiddenusername" type="hidden" name="hiddenusername" runat="server" />
            <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
            <input id="hiddenunit" type="hidden" name="hiddenunit" runat="server" />
            
    </form>
</body>
</html>
