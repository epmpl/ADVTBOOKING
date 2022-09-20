<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false"  CodeFile="bookingauditshowdetailgrid.aspx.cs" Inherits="bookingauditshowdetailgrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Booking Detail</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
</head>
<body style="margin-top:0px;margin-left:0px;">
    <form id="form1" runat="server">
    <div style="overflow:auto;">
     <asp:DataGrid ID="DataGrid1" CssClass="dtGrid"  runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                Width="120%" 
            onitemdatabound="DataGrid1_ItemDataBound"  >
                                                                <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                                                                <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                                                                    HorizontalAlign="Center" />
                                                               
                                                                <PagerStyle HorizontalAlign="Center" />
         <Columns>
             <asp:BoundColumn DataField="No_Insert" HeaderText="Insert No.">
                 <HeaderStyle Width="3%" />
             </asp:BoundColumn>
             <asp:BoundColumn DataField="PUBLICATION" HeaderText="Publication"></asp:BoundColumn>
              <asp:BoundColumn DataField="" HeaderText="PACKAGE">
                  <HeaderStyle Width="8%" />
             </asp:BoundColumn>
             <asp:BoundColumn DataField="CENTER" HeaderText="Center"></asp:BoundColumn>
             <asp:BoundColumn DataField="Edition" HeaderText="Edition"></asp:BoundColumn>
             <asp:BoundColumn DataField="Insert_Date" HeaderText="Insert_Date"></asp:BoundColumn>
             <asp:BoundColumn DataField="Col_Code" HeaderText="Color"></asp:BoundColumn>
             <asp:BoundColumn DataField="Page_No" HeaderText="Page no"></asp:BoundColumn>
             <asp:BoundColumn DataField="Height" HeaderText="H"></asp:BoundColumn>
             <asp:BoundColumn DataField="Width" HeaderText="W"></asp:BoundColumn>
             <asp:BoundColumn DataField="Size_Book" HeaderText="Size"></asp:BoundColumn>
              <asp:BoundColumn DataField="Remarks" HeaderText="Remark"></asp:BoundColumn>
               <asp:BoundColumn DataField="CAPTION" HeaderText="Caption"></asp:BoundColumn>
             <asp:BoundColumn DataField="ADCATEGORY" HeaderText="Ad Category"></asp:BoundColumn>
             <asp:BoundColumn DataField="ADSUBCATEGORY" HeaderText="Ad SubCategory"></asp:BoundColumn>
             <asp:BoundColumn DataField="Insert_Status" HeaderText="Insert Status"></asp:BoundColumn>
             <asp:BoundColumn DataField="Pai_Free_Ins" HeaderText="Paid"></asp:BoundColumn>
             <asp:BoundColumn DataField="Gross_Rate" HeaderText="Gross Rate" >
                 <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                     Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
             </asp:BoundColumn>
             <asp:BoundColumn DataField="" HeaderText="Insert Amt">
                 <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                     Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
             </asp:BoundColumn>
             <asp:BoundColumn DataField="Bill_Amt" HeaderText="Bill Amount">
                 <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                     Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
             </asp:BoundColumn>
             <asp:BoundColumn DataField="File_Name" HeaderText="File Name"></asp:BoundColumn>
             <asp:BoundColumn DataField="BILL_NO" HeaderText="Bill No"></asp:BoundColumn>
              <asp:BoundColumn DataField="SECTIONCODE" HeaderText="Section"></asp:BoundColumn>
             <asp:BoundColumn DataField="RESOURCE_NO" HeaderText="Resource No"></asp:BoundColumn>
         </Columns>
                                                            </asp:DataGrid>
    </div>
    </form>
</body>
</html>
